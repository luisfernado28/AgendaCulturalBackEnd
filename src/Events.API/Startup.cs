//-----------------------------------------------------------------------------
// <copyright file="Startup.cs" company=".NET Foundation">
//      Copyright (c) .NET Foundation and Contributors. All rights reserved.
//      See License.txt in the project root for license information.
// </copyright>
//------------------------------------------------------------------------------

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData.Routing.Conventions;
using Microsoft.AspNetCore.OData;
using Microsoft.OData;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Reflection;
using Events.Service;
using Events.DAO;
using Events.Domain;
using Microsoft.Extensions.Options;

namespace Events.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Codes for backup and use to compare with preview design/implementation
            //services.AddControllers(options => {
            //{
            //    options.Conventions.Add(new MetadataApplicationModelConventionAttribute());
            //    options.Conventions.Add(new MetadataActionModelConvention());
            //});

            /*services.AddConvention<MyConvention>();
            
            services.AddOData()
                .AddODataRouting(options => options
                    .AddModel(EdmModelBuilder.GetEdmModel())
                    .AddModel("v1", EdmModelBuilder.GetEdmModelV1())
                    .AddModel("v2{data}", EdmModelBuilder.GetEdmModelV2()));

            services.AddODataFormatter();
            services.AddODataQuery(options => options.Count().Filter().Expand().Select().OrderBy().SetMaxTop(5));
            */
            #endregion

            services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));
            services.AddSingleton<IAppSettings>(sp => sp.GetRequiredService<IOptions<AppSettings>>().Value);
            services.Configure<AgendaCulturalDatabaseSettings>(Configuration.GetSection(nameof(AgendaCulturalDatabaseSettings)));
            services.AddSingleton<IAgendaCulturalDatabaseSettings>(sp => sp.GetRequiredService<IOptions<AgendaCulturalDatabaseSettings>>().Value);

            services.AddScoped<IEventsService, EventsService>();
            services.AddScoped<IEventsDAO, EventsDAO>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthenticationDAO, AuthenticationDAO>();


            IEdmModel model0 = EdmModelBuilder.GetEdmModel();
        
            services.AddControllers()
             
                .AddOData(opt => opt.Count().Filter().Expand().Select().OrderBy().SetMaxTop(5)
                    .AddRouteComponents(model0)
                       .Conventions.Add(new MyConvention())
                );

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Use odata route debug, /$odata
            app.UseODataRouteDebug();

            // If you want to use /$openapi, enable the middleware.
            //app.UseODataOpenApi();

            // Add OData /$query middleware
            app.UseODataQueryRequest();

            // Add the OData Batch middleware to support OData $Batch
            app.UseODataBatching();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Agenda Cultural");
            });

            app.UseRouting();

            // Test middleware
            app.Use(next => context =>
            {
                var endpoint = context.GetEndpoint();
                if (endpoint == null)
                {
                    return next(context);
                }

                return next(context);
            });

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class RemoveMetadataControllerFeatureProvider : ControllerFeatureProvider
    {
        protected override bool IsController(TypeInfo typeInfo)
        {
            if (typeInfo.FullName == "Microsoft.AspNetCore.OData.Routing.Controllers.MetadataController")
            {
                return false;
            }

            return base.IsController(typeInfo);
        }
    }

    /// <summary>
    /// My simple convention
    /// </summary>
    public class MyConvention : IODataControllerActionConvention
    {
        /// <summary>
        /// Order value.
        /// </summary>
        public int Order => -100;

        /// <summary>
        /// Apply to action,.
        /// </summary>
        /// <param name="context">Http context.</param>
        /// <returns>true/false</returns>
        public bool AppliesToAction(ODataControllerActionContext context)
        {
            return true; // apply to all controller
        }

        /// <summary>
        /// Apply to controller
        /// </summary>
        /// <param name="context">Http context.</param>
        /// <returns>true/false</returns>
        public bool AppliesToController(ODataControllerActionContext context)
        {
            return false; // continue for all others
        }
    }
}
