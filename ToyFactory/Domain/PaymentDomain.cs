using System;
using System.Collections.Generic;
using System.Text;
using ToyFactory.Context;
using ToyFactory.Models;

namespace ToyFactory.Domain
{
    public class PaymentDomain : BaseContext
    {
        public void AddPayment(Payments payment)
        {
            Payments.AddAsync(payment);
            SaveChanges();
        }
    }
}
