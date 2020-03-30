using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToyFactory.Context;
using ToyFactory.Models;

namespace ToyFactory.Domain
{
    public class AddressDomain : BaseContext
    {
        public void AddAddress(List<Address> address)
        {
            Address.AddRange(address);
            SaveChanges();
        }
        public List<Address> GetByCustomerId(int customerId)
        {
            return Address.Where(t => t.CustomerId == customerId).ToList();
        }
    }
}
