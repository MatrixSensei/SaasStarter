using Saas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantResources.Data
{
    // This interface should return the current DBProvider, Connection string, and Tenant Data.
    public interface IDatalinkRepository
    {
        // This how we identify the tenant from the incoming requests.   Using:
        public string GetDatabaseProvider();
        public string GetConnectionString();
        public Datalink GetCurrentDatalink();
        public Tenant GetCurrentTenant();
    }
}
