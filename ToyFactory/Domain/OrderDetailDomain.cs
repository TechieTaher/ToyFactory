using System;
using System.Collections.Generic;
using System.Text;
using ToyFactory.Context;
using ToyFactory.Models;

namespace ToyFactory.Domain
{
    public class OrderDetailDomain : BaseContext
    {
        public void AddOrderDetails(List<OrderDetails> orderDetails)
        {
            OrderDetails.AddRange(orderDetails);
            SaveChanges();
        }
    }
}
