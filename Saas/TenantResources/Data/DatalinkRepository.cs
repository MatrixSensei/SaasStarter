using Saas.Data;
using Saas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantResources.Data
{
    public class DatalinkRepository : IDatalinkRepository
    {
        private readonly ApplicationDbContext _db;

        private HttpContext _httpContext;
        private Datalink _currentDatalink;
        private Tenant _currentTenant;

        public DatalinkRepository(ApplicationDbContext db, IHttpContextAccessor contextAccessor)
        {
            _db = db;

            // Collect the DatalinkSettings with the associated SeparateDatalinks Array
            //_DatalinkSettings = DatalinkSettings.Value;
            _httpContext = contextAccessor.HttpContext;

            // We first check if HTTP context is not null, then we try to read the tenant key from the
            // header of the request. If a tenant value is found, we set the tenant using the
            // SetTenant(string tenantGuid) method
            if (_httpContext != null)
            {
                if (_httpContext.Request.Headers.TryGetValue("tenant", out var tenantRequest))
                {
                    SetTenant(tenantRequest);
                }
                else
                {
//                    throw new Exception("Invalid Tenant!");
                }
            }
        }

        // Here, we take in tenant from the request header and compare it against the data we have
        // already set in the appsettings of the application. If the matching tenant is not found,
        // it throws an exception. If the found tenant doesn’t have a connection string defined,
        // we simply take the default connection string and attach it to the connection string property
        // of the current tenant, as simple as that.
        private void SetTenant(string tenantRequest)
        {
            _currentTenant = _db.SaasTenants.Where(t => t.Name == tenantRequest).FirstOrDefault();
            if (_currentTenant == null || _currentTenant.Id == null)
            {
                _currentTenant = _db.SaasTenants.Where(t => t.Id == tenantRequest).FirstOrDefault();
            }
            if (_currentTenant == null || _currentTenant.Id == null)
            {
                throw new Exception("Invalid Tenant!");
            }
            else
            {
                TenantDatalink _currentTenantDatalink = _db.SaasTenantDatalinks.Where(td => td.TenantId == _currentTenant.Id).FirstOrDefault();
                if (!(_currentTenantDatalink == null || _currentTenantDatalink.Id == 0))
                {
                    _currentDatalink = _db.SaasDatalinks.Where(d => d.Id == _currentTenantDatalink.DatalinkId).FirstOrDefault();
                }
                if (_currentDatalink==null || string.IsNullOrEmpty(_currentDatalink.ConnectionString))
                {
                    SetDefaultConnectionStringToCurrentTenant();
                }
            }
        }

        private void SetDefaultConnectionStringToCurrentTenant()
        {
            _currentDatalink = _db.SaasDatalinks.Where(a => a.Name == "defaultSharedDatalink").FirstOrDefault();
            if (_currentDatalink == null) throw new Exception("Shared Data Link Missing!!!");
        }

        // This how we identify the tenant from the incoming requests.   Using:
        //  public string GetDatabaseProvider();
        //  public string GetConnectionString();
        //  public Tenant GetTenantDatalink();
        public string GetConnectionString()
        {
            return _currentDatalink?.ConnectionString;
        }
        public string GetDatabaseProvider()
        {
            return _currentDatalink?.Provider;
        }

        public Datalink GetCurrentDatalink()
        {
            return _currentDatalink;
        }
        public Tenant GetCurrentTenant()
        {
            return _currentTenant;
        }
    }
}
