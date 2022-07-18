using Microsoft.AspNetCore.Identity;
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
    [Table("TenantUsers", Schema = "sas")]
    public class TenantUser
    {
        [Column("TenantUserID", Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Tenant/User ID")]
        [Required(ErrorMessage = "'TenantUser ID' is a required field.")]
        public int Id { get; set; }

        //[Key] // Composite Primary Keys are managed in ApplicationDbContext.OnModelCreating
        [Column(Order = 2)]
        [Display(Name = "Tenant Id")]
        [Required(ErrorMessage = "TenantId is required."), StringLength(450)]
        public string? TenantId { get; set; }
        [ForeignKey("TenantId")]
        [ValidateNever]
        public Tenant? Tenant { get; set; }

        //[Key] // Composite Primary Keys are managed in ApplicationDbContext.OnModelCreating
        [Column(Order = 3)]
        [Display(Name = "User Id")]
        [Required(ErrorMessage = "UserId is required."), StringLength(450)] // Identity User ID is an nvarstring(450)
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        //public ApplicationUser? User { get; set; }
        public IdentityUser? User { get; set; }
    }
}
