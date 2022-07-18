using Microsoft.EntityFrameworkCore; // for Index, IsUnique
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Models
{
    [Table("Tenants", Schema = "sas")]
    [Index(nameof(Name), IsUnique = true)]
    public class Tenant
    {
        [Key]
        [Column(Order = 1)]
        [Required]
        [Display(Name = "Id")]
        public string? Id { get; set; }

        [Column(Order = 2)]
        [Display(Name = "Tenant Name")]
        [StringLength(255)]
        [Required]
        public string? Name { get; set; }

        [Column(Order = 3)]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:ddd dd-MMM-yyyy hh:mmtt}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; } = DateTime.Now;

        [Column(Order = 4)]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:ddd dd-MMM-yyyy hh:mmtt}", ApplyFormatInEditMode = true)]
        public DateTime Updated { get; set; } = DateTime.Now;

        [Column(Order = 5)]
        [Display(Name = "Description")]
        [StringLength(255)]
        public string? Description { get; set; }

        [Column(Order = 6)]
        [Display(Name = "Comments")]
        [StringLength(255)]
        public string? Comment { get; set; }
    }
}
