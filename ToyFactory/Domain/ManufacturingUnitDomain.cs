using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToyFactory.Context;
using ToyFactory.Models;

namespace ToyFactory.Domain
{
    public class ManufacturingUnitDomain : BaseContext
    {
        public void AddManufactureUnit(ManufactureUnits manufactureUnit)
        {
            ManufactureUnits.AddAsync(manufactureUnit);
            SaveChanges();
        }
        public List<ManufactureUnits> GetManufactureUnits()
        {
            return ManufactureUnits.ToList();
        }
    }
}
