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
    [Table("Datalinks", Schema = "sas")]
    [Index(nameof(Name), IsUnique = true)]
    public class Datalink
    {
        [Key]
        [Column(Order = 1)]
        [Required]
        [Display(Name = "Id")]
        public string? Id { get; set; }

        [Column(Order = 2)]
        [Display(Name = "Nic Name")]
        [StringLength(255)]
        [Required]
        public string? Name { get; set; }

        [Column(Order = 3)]
        [Display(Name = "Provider")]
        [StringLength(255)]
        public string Provider { get; set; } = "mssql";

        [Column(Order = 4)]
        [Display(Name = "Connection String")]
        [StringLength(255)]
        public string? ConnectionString { get; set; }

        [Column(Order = 5)]
        [Display(Name = "Active")]
        public bool Active { get; set; } = true;
    }
}
