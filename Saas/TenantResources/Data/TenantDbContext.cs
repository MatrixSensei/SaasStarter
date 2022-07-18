using Microsoft.EntityFrameworkCore;
using Saas.Data;
using Saas.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantResources.Models;

namespace TenantResources.Data
{
    // It is assumed that, whenever the application tries to access the database via EFCore context, there
    // is a valid DatalinkId present in the request header, or at least provided by the Tenant Service.

    public class TenantDbContext : DbContext
    {
        public string _tenantId { get; set; }

        private readonly IDatalinkRepository _datalinkRepository;

        public TenantDbContext(DbContextOptions options, IDatalinkRepository datalinkRepository) : base(options)
        {
            //_tenantService = tenantService;
            _datalinkRepository = datalinkRepository;
            //TenantId = _tenantService.GetTenant()?.TID;
            if (_datalinkRepository.GetCurrentDatalink() != null)
            {
                _tenantId = _datalinkRepository.GetCurrentTenant().Id;
            }
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // This is the part where we define the Global Query Filter for the DBContext. Everytime a new
            // request is passed to the DBContext, the TenantDbContext will be smart enough to work
            // with the data the is relavant to the current DatalinkId only.
            modelBuilder.Entity<Product>().HasQueryFilter(a => a.TenantId == _tenantId);
        }

        // Here, everytime a new instance of ApplicationContext is invoked, the connection string is pulled
        // from the tenant settings and set to EFCore Context.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var tenantConnectionString = _datalinkRepository.GetConnectionString();
            if (!string.IsNullOrEmpty(tenantConnectionString))
            {
                var DBProvider = _datalinkRepository.GetDatabaseProvider();
                if (DBProvider.ToLower() == "mssql")
                {
                    optionsBuilder.UseSqlServer(_datalinkRepository.GetConnectionString());
                }
            }
        }

        // We override the SaveChanges method. In this method, whenever there is a modification of the
        // Entity of type IMustHaveTenant, DatalinkId is written to the entity during the Save process.
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                    case EntityState.Modified:
                        entry.Entity.TenantId = _tenantId;
                        break;
                }
            }
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
