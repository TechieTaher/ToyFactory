using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToyFactory.Context;
using ToyFactory.Models;

namespace ToyFactory.Domain
{
    public class OrderDomain : BaseContext
    {
        public void AddOrder(Orders order)
        {
            Orders.AddAsync(order);
            SaveChanges();
        }
        public List<Orders> GetOrders()
        {
            return Orders
                .Include(t => t.Customer)
                .Include(t => t.Payment)
                .ToList();
        }
    }
}
