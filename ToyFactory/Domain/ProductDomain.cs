using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToyFactory.Context;
using ToyFactory.Models;

namespace ToyFactory.Domain
{
    public class ProductDomain:BaseContext
    {
        public void AddProduct(Products product)
        {
            Products.AddAsync(product);
            SaveChanges();
        }
        public List<Products> GetByProductName(string productName)
        {
            return Products.Where<Products>(c => c.ProductName.Contains(productName)).ToList();
        }
    }
}
