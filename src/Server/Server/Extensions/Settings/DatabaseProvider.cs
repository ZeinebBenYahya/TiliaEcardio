﻿using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace Server.Extensions.Settings
{
    public static class DatabaseProvider
    {
        private const string MigrationsAssembly = "Server";

        public static DbContextOptionsBuilder SetupDatabaseEngine(
            this DbContextOptionsBuilder options,
            DbConnectionConfig dbConnectionConfig) =>
            dbConnectionConfig.Provider.ToLower(CultureInfo.CurrentCulture) switch
            {
                "oracle" => SetupOracle(options, dbConnectionConfig.Url),
                _ => SetupMysql(options, dbConnectionConfig.Url)
            };

        private static DbContextOptionsBuilder SetupMysql(DbContextOptionsBuilder options,
            string connectionString)
        {
            return null;
        }

        private static DbContextOptionsBuilder SetupOracle(DbContextOptionsBuilder options,
            string connectionString)
        {
            return options.UseOracle(connectionString,
                    builder => builder.MigrationsAssembly(MigrationsAssembly))
                .EnableDetailedErrors();
        }
    }
}
