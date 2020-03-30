using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToyFactory.Models
{
    public partial class OrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(Products.OrderDetails))]
        public virtual Products Product { get; set; }
    }
}
