using MorningCoffee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.Entities.Concrete
{
    public class Frappuccino : IEntity
    {
        public int Id { get; set; }
        public int FrappuccinoBlendedBeverageId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 UnitsInStock { get; set; }
    }
}
