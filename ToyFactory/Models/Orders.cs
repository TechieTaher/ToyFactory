using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToyFactory.Models
{
    public partial class Orders
    {
        [Key]
        public int OrderId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public int Discount { get; set; }
        public int PaymentId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Orders")]
        public virtual Address Address { get; set; }
        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Models.Customers.Orders))]
        public virtual Customers Customer { get; set; }
        [ForeignKey(nameof(PaymentId))]
        [InverseProperty(nameof(Payments.Orders))]
        public virtual Payments Payment { get; set; }
    }
}
