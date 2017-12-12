using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRN292_LAB_2.Entities
{
    public class Order
    {
        public int id { get; set; }
        public DateTime orderDate { get; set; }
        public List<OrderDetail> carts { get; set; }

        public Order()
        {
            carts = new List<OrderDetail>();
        }
    }
}