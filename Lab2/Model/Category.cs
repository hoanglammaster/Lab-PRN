using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Model
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Category(int iD, string name)
        {
            ID = iD;
            Name = name;
        }
    }
}
