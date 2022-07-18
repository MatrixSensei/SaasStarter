using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Models.ViewModels
{
    public class TenantDatalinkViewModel
    {
        public TenantDatalink TenantDatalink { get; set; }
        public IEnumerable<SelectListItem>? TenantList { get; set; }
        public IEnumerable<SelectListItem>? DatalinkList { get; set; }
    }
}
