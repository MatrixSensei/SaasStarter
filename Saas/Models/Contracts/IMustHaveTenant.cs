using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Models.Contracts
{
    // All the entity classes that implement this interface will have a Tenant Id.
    //  You will see the importance of having this contract later
    public interface IMustHaveTenant
    {
        public string TenantId { get; set; }
    }
}
