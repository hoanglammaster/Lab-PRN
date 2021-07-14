using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Model
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Decimal UnitPrice { get; set; }

        public Product()
        {
        }

        public Product(int iD, string name, decimal unitPrice)
        {
            ID = iD;
            Name = name;
            UnitPrice = unitPrice;
        }
    }
}
