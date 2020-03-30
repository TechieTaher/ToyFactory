using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToyFactory.Context;
using ToyFactory.Models;

namespace ToyFactory.Domain
{
    public class CustomerDomain : BaseContext
    {
        public void AddCustomer(Customers customer)
        {
            Customers.AddAsync(customer);
            SaveChanges();
        }
        public List<Customers> GetByCustomerName(string customerName)
        {
            return Customers.Where<Customers>(c => c.CustomerName.Contains(customerName)).ToList();
        }
    }
}
