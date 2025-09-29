using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    public enum Category
    {
        Food,
        Appliances
    }
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public Category Category { get; set; }
    }
}
