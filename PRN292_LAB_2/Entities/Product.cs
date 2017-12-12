using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRN292_LAB_2.Entities
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public Category category { get; set; }
        public double price { get; set; }
        public bool discontinue { get; set; }
    }
}