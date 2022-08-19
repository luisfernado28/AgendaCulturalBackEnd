/*
 * Project: Agenda Cultural Back End Net Core
 * Author: Luis Fernando Choque (luisfernandochoquea@gmail.com)
 * -----
 * Copyright 2021 - 2022 Universidad Privada Boliviana La Paz, Luis Fernando Choque Arana
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain
{
    public class AppSettings: IAppSettings
    {
        public string JwtTokenKey { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }

    }

    public interface IAppSettings
    {
        string JwtTokenKey { get; set; }
        string Audience { get; set; }
        string Issuer { get; set; }
    }
}
