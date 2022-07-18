using Microsoft.AspNetCore.Mvc.ModelBinding.Validation; // for [ValidateNever]
using Microsoft.AspNetCore.Mvc.Rendering;  // For SelectListItem
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Models.ViewModels
{
    public class TenantUserViewModel
    {
        // create variable for Upsert
        public TenantUser? TenantUser { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? TenantList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? UserList { get; set; }
    }
}
