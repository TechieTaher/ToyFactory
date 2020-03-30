using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToyFactory.Models
{
    public partial class ManufactureUnits
    {
        public ManufactureUnits()
        {
            Products = new HashSet<Products>();
        }

        [Key]
        public int ManufactureUnitId { get; set; }
        [Required]
        [StringLength(50)]
        public string ManufactureUnitName { get; set; }
        public string Address { get; set; }
        public bool IsWorking { get; set; }

        [InverseProperty("ManufaturingUnit")]
        public virtual ICollection<Products> Products { get; set; }
    }
}
