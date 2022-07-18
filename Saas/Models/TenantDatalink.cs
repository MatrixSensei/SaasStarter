using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Models
{
    [Table("TenantDatalinks", Schema = "sas")]
    public class TenantDatalink
    {
        [Column("TenantDatalinkID", Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Tenant/Datalink ID")]
        [Required(ErrorMessage = "'TenantDatalinkID' is a required field.")]
        public int Id { get; set; }

        //[Key] // Composite Primary Keys are managed in ApplicationDbContext.OnModelCreating
        [Column(Order = 2)]
        [Display(Name = "Tenant Id")]
        [Required(ErrorMessage = "Tenant Id is required."), StringLength(450)] // Identity User ID is an nvarstring(450)
        public string? TenantId { get; set; }
        [ForeignKey("TenantId")]
        [ValidateNever]
        public Tenant? Tenant { get; set; }

        //[Key] // Composite Primary Keys are managed in ApplicationDbContext.OnModelCreating
        [Column(Order = 3)]
        [Display(Name = "Datalink Id")]
        [Required(ErrorMessage = "Datalink Id is required."), StringLength(450)]
        public string? DatalinkId { get; set; }
        [ForeignKey("DatalinkId")]
        [ValidateNever]
        public Datalink? Datalink { get; set; }
    }
}
