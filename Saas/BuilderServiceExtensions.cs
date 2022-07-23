using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Saas.Data;
using Saas.Models;
using TenantResources.Data;
//using TenantResources.Data;

namespace Saas
{
    public static class BuilderServiceExtensions
    {
        public static IServiceCollection SetupApplicationDb(this IServiceCollection services, string connectionString) {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            using var scope = services.BuildServiceProvider().CreateScope(); // Won't create if already exists
                                                                             // Now we will use the DbContext to create the database
                                                                             // and, using the migrations, build all the tables too.
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (dbContext.Database.GetMigrations().Any())
            {
                // The new database will be created in the Up() function within the Migration file
                dbContext.Database.Migrate();  // This will not overwrite existing tables
            }
            return services;
        }

        public static IServiceCollection AddAndMigrateDatalinkContexts(this IServiceCollection services, IConfiguration config)
        {
            using var scope = services.BuildServiceProvider().CreateScope(); // Won't create if already exists
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            Datalink defaultDatalink = dbContext.SaasDatalinks.FirstOrDefault(x => x.Name == "defaultSharedDatalink");

            // Load our default connection details into variables
            string defaultDatalinkId = defaultDatalink.Id;
            //var defaultConnectionString = defaultDatalink.ConnectionString;
            //var defaultDbProvider = defaultDatalink.Provider;

            // Create the default TenantDbContext to our services
            if (defaultDatalink.Provider.ToLower() == "mssql")
            {
                // Registers TenantDbContext using the SQLServer package.
                services.AddDbContext<TenantDbContext>(m => m.UseSqlServer(defaultDatalink.ConnectionString));
            }

            var allDatalinks = dbContext.SaasDatalinks.ToList();
            foreach (var item in allDatalinks)
            {
                // Collect the appropriate connection string
                //   Datalinks without a connection string will use the default shared datalink connection
                string connectionString;
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    connectionString = defaultDatalink.ConnectionString;
                }
                else
                {
                    connectionString = item.ConnectionString;
                }
                using var tenantScope = services.BuildServiceProvider().CreateScope();
                //Won't create if already exists;

                // Now we will use the TenantDbContext to create the datalink databases
                // and, using the migrations, build all the tables too.

                var dbTenantContext = tenantScope.ServiceProvider.GetRequiredService<TenantDbContext>();
                dbTenantContext.Database.SetConnectionString(connectionString);
                if (dbTenantContext.Database.GetMigrations().Any())
                {
                    // The new database will be created in the Up() function within the Migration file
                    try
                    {
                        dbTenantContext.Database.Migrate();  // This will not overwrite existing tables

                        // For testing purposes only
                        if (item.Name == "alphaDatalink")
                        {
                            dbTenantContext.Database.ExecuteSqlRaw(
                                "INSERT INTO [Products]" +
                                " (name, description, rate, tenantid)" +
                                " VALUES ('Zenatroid Robot', 'with Surround Environment Sensors and Speech', 11500, 'e895cc49-3266-44a0-0f8e-08da5ed157b0');"
                            );
                        }
                    }
                    catch
                    {
                        //throw new InvalidOperationException("Connection string '" + dbTenantContext.Database.GetConnectionString + "' for '" + item.Name + "' not found.");
                        //alert("Connection string '" + dbTenantContext.Database.GetConnectionString + "' for '" + item.Name + "' not found.");
                    }
                }
            }

            return services;
        }
    }
}
