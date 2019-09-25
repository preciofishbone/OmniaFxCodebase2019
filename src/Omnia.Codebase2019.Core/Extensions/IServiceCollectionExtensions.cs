﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Omnia.Codebase2019.Core.Repositories;
using Omnia.Codebase2019.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omnia.Codebase2019.Core.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCodeBaseServices(this IServiceCollection services)
        {
            //Connect the interface to the repo implementation (Interface is internal as well as the implementation, i.e. repos are used from services to enable a good caching point)
            services.AddScoped<IBikeRepository, BikeRepository>();

            //Connect the interface to the service implementation (Interface is public, implementation is internal)
            services.AddScoped<IBikeService, BikeService>();
 
            return services;
        }

        /// <summary>
        /// Extension method configuring the DBContext to use the current connectionstring for the DB requested in omnia.services.ts
        /// I.e. the DB with id: f8debb44-be08-4ae2-9cf5-c1cebc839123
        /// 
        /// (We expose this as an extension method to be able to keep the DBContext an internal affair)
        /// </summary>
        /// <param name="services">The service collection to configure</param>
        /// <returns></returns>
        public static IServiceCollection AddCodeBaseDB(this IServiceCollection services)
        {
            services.AddOmniaSqlDBContext<CodeBaseDBContext>(new Guid("f8debb44-be08-4ae2-9cf5-c1cebc839123"),
                (sqlInfo, serviceProvider, optionsBuilder) =>
                {
                    //Read the connection string for the db with id "f8debb44-be08-4ae2-9cf5-c1cebc839123"
                    optionsBuilder.UseSqlServer(sqlInfo.ConnectionString)

                    //Configure other db options, in this case no tracking as default.
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                });

            return services;
        }
    }
}
