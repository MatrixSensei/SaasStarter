using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Saas.Models;

namespace Saas.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Datalink>? SaasDatalinks { get; set; }
        public DbSet<Tenant>? SaasTenants { get; set; }
        public DbSet<TenantDatalink>? SaasTenantDatalinks { get; set; }
        //public DbSet<ApplicationUser>? ApplicationUsers { get; set; }
        public DbSet<TenantUser>? SaasTenantUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // multiple primary keys
            builder.Entity<TenantDatalink>().HasKey(table => new {
                table.TenantId,
                table.DatalinkId
            });

            builder.Entity<TenantUser>().HasKey(table => new {
                table.TenantId,
                table.UserId
            });

            // default data
            builder.Entity<Datalink>().HasData(
                new { Id = "f63f4ca8-2c92-41bf-8918-ee18e80580af", Name = "defaultSharedDatalink", Provider = "mssql", ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Database=saasTenantsShared;Integrated Security=True;MultipleActiveResultSets=True", Active = true },
                new { Id = "d976e7ea-58da-4e9c-8d4f-765e9160bd73", Name = "alphaDatalink", Provider = "mssql", ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Database=saasTenantAlpha;Integrated Security=True;MultipleActiveResultSets=True", Active = true },
                new { Id = "ed5b0fe5-ea64-43df-b315-fe4f39734eb1", Name = "betaDatalink", Provider = "mssql", ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Database=saasTenantBeta;Integrated Security=True;MultipleActiveResultSets=True", Active = true },
                // A Tenant using a Datalink with a blank or missing connection string should revert back
                //  to the defaultSharedDatalink
                new { Id = "d9da83f1-19ae-48be-a1ab-e141861ea8e9", Name = "charlieDatalink", Provider = "mssql", ConnectionString = "", Active = true }
            );

            builder.Entity<Tenant>().HasData(
                new
                {
                    Id = "e895cc49-3266-44a0-0f8e-08da5ed157b0",
                    Name = "Alpha",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Description = "Test Tenant called Alpha",
                    Comment = "This Tenant is for testing purposes only and is not a guenuine company."
                },
                new
                {
                    Id = "e7600b12-0c8a-41f1-0f8f-08da5ed157b0",
                    Name = "Beta",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Description = "Test Tenant called Beta",
                    Comment = "This Tenant is for testing purposes only and is not a guenuine company."
                },
                new
                {
                    Id = "3eeb9e55-2dea-4e60-0f90-08da5ed157b0",
                    Name = "Charlie",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Description = "Test Tenant called Charlie",
                    Comment = "This Tenant is for testing purposes only and is not a guenuine company."
                },
                new
                {
                    Id = "3694cda0-b999-4920-0f91-08da5ed157b0",
                    Name = "Delta",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Description = "Test Tenant called Delta",
                    Comment = "This Tenant is for testing purposes only and is not a guenuine company."
                }
            );

            builder.Entity<TenantDatalink>().HasData(
                // The first two have their own separate databases
                new { Id = 1, TenantId = "e895cc49-3266-44a0-0f8e-08da5ed157b0", DatalinkId = "d976e7ea-58da-4e9c-8d4f-765e9160bd73" },
                new { Id = 2, TenantId = "e7600b12-0c8a-41f1-0f8f-08da5ed157b0", DatalinkId = "ed5b0fe5-ea64-43df-b315-fe4f39734eb1" },

                // The next tenant shares the DefaultSharedDatalink database because there is no Datalink connection string
                new { Id = 3, TenantId = "3eeb9e55-2dea-4e60-0f90-08da5ed157b0", DatalinkId = "d9da83f1-19ae-48be-a1ab-e141861ea8e9" } //,

                // The next tenant shares the DefaultSharedDatalink because
                // this purposefully not included in the Datalink and therefore has connection string
                //new { Id = 4, TenantId = "3694cda0-b999-4920-0f91-08da5ed157b0", DatalinkId = "75727320-b538-455d-8ff5-5ba9d7353cb6" } /* deltaDatalink */
            );

            //builder.Entity<ApplicationUser>().HasData(new
            builder.Entity<IdentityUser>().HasData(new
            {
                Id = "9a3a5b47-fd9a-4c57-9131-d0be482efc57",
                Discriminator = "IdentityUser",
                UserName = "admin@saas.com",
                NormalizedUserName = "ADMIN@SAAS.COM",
                Email = "admin@saas.com",
                NormalizedEmail = "ADMIN@SAAS.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEKCwX5auoOUJ5ZtSFNdyuthSCXSNRu8YfIFuJqIsgKAfgwtdcNdhtzTc8gyHPu+k/g==",
                SecurityStamp = "FIYZB33JXW3JD3A47A5V5UEEU5AMULG5",
                ConcurrencyStamp = "d2975948-23a9-4d96-80eb-31cb822b53fb",
                AccessFailedCount = 0,
                EmailConfirmed = false,
                LockoutEnabled = false,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
            });

            builder.Entity<TenantUser>().HasData(
                new { Id = 1, UserId = "9a3a5b47-fd9a-4c57-9131-d0be482efc57", TenantId = "e895cc49-3266-44a0-0f8e-08da5ed157b0" },
                new { Id = 2, UserId = "9a3a5b47-fd9a-4c57-9131-d0be482efc57", TenantId = "e7600b12-0c8a-41f1-0f8f-08da5ed157b0" },
                new { Id = 3, UserId = "9a3a5b47-fd9a-4c57-9131-d0be482efc57", TenantId = "3eeb9e55-2dea-4e60-0f90-08da5ed157b0" },
                new { Id = 4, UserId = "9a3a5b47-fd9a-4c57-9131-d0be482efc57", TenantId = "3694cda0-b999-4920-0f91-08da5ed157b0" }
            );

        }
    }
}