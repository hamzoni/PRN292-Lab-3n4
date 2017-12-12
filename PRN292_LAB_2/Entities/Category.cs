using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRN292_LAB_2.Entities
{
    public class Category
    {
        public int id { get; set;  }
        public string name { get; set; }

        public Category()
        {

        }

        public Category(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}