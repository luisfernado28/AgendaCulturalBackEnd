using Events.DAO;
using Events.Domain;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;


namespace Events.Service
{
  public class AuthenticationService : IAuthenticationService
  {
    private IAuthenticationDAO _authDao;
    private IAppSettings _appSettings;
    public AuthenticationService(IAppSettings appSettings, IAuthenticationDAO authDAO)
    {
      _authDao = authDAO;
      _appSettings = appSettings;
    }

    public UserCredentailResponse Authenticate(UserCredential userCred)
    {
      User account = _authDao.getUsersByUserName(userCred.Username);
      if (account == null)
      {
        throw new Exception("Authentication Error");
      }
      if (!BC.Verify(userCred.Password, account.Password))
      {
        throw new UnauthorizedAccessException();
      }

      return fillUserCredentialsResponse(account);
    }

    public async Task deleteUser(string userId)
    {
      await _authDao.deleteUser(userId);
    }

    public async Task<User> getUserById(string userId)
    {
      return await _authDao.getUserById(userId);
    }

    public async Task<List<User>> getUsers()
    {
      var users = await _authDao.getUsers();
      return users;
    }

    public void Logoff(UserCredentailResponse userCred)
    {
      Logger.Info($"Authservice - User log off at {System.DateTime.Now} by user {userCred.Firstname}  {userCred.Lastname} with username {userCred.Username}");
    }

    public async Task<User> patchUser(string userId, User userObj)
    {
      try
      {
        if (!string.IsNullOrEmpty(userObj.Password))
        {
          userObj.Password = BC.HashPassword(userObj.Password);
        }
        var updated = await _authDao.patchUser(userId, userObj);
        var account = await _authDao.getUserById(userId);
        return account;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<User> postUser(User userObj)
    {
      Logger.Info($"Authservice - Trying to create user with the name of {userObj.Username}.");
      userObj.Password = BC.HashPassword(userObj.Password);

      var User = await _authDao.postUser(userObj);
      return User;
    }


    UserCredentailResponse fillUserCredentialsResponse(User user)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var tokenKey = Encoding.ASCII.GetBytes(_appSettings.JwtTokenKey);

      const string Id = "id";
      const string Username = "Username";
      const string Firstname = "Firstname";
      const string Lastname = "Lastname";
      const string Admin = "Admin";
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[]
          {
                        new Claim(Username, user.Username),
                        new Claim(Id, user.Id.ToString()),
                        new Claim(Firstname, user.Firstname),
                        new Claim(Admin, user.Admin.ToString()),
                        new Claim(Lastname, user.Lastname),
                    }),
        Expires = DateTime.UtcNow.AddHours(1),
        SigningCredentials =
          new SigningCredentials(
              new SymmetricSecurityKey(tokenKey),
              SecurityAlgorithms.HmacSha256Signature),
        Issuer = _appSettings.Issuer,
        Audience = _appSettings.Audience
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      Logger.Info($"Authservice - User log in at {System.DateTime.Now} by user {user.Firstname}  {user.Lastname} with username {user.Username}");
      return new UserCredentailResponse
      {
        Id = user.Id,
        Username = user.Username,
        Firstname = user.Firstname,
        Lastname = user.Lastname,
        Admin = user.Admin,
        Token = tokenHandler.WriteToken(token)
      };
    }
  }
}
