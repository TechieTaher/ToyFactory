using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToyFactory.Models
{
    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }
        public int? HsnCode { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ManufactureDate { get; set; }
        public int ManufaturingUnitId { get; set; }

        [ForeignKey(nameof(ManufaturingUnitId))]
        [InverseProperty(nameof(ManufactureUnits.Products))]
        public virtual ManufactureUnits ManufaturingUnit { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
