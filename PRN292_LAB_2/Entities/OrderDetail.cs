using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRN292_LAB_2.Entities
{
    public class OrderDetail
    {
        private Product product;
        public int orderID { get; set; }
        public int quantity { get; set; }
        public double discount { get; set; }
        public double price { get; set; }

        public Product Product
        {
            get
            {
                return product;
            }

            set
            {
                product = value;
                price = value.price;
            }
        }

        public OrderDetail()
        {
            quantity = 1;
            discount = 0;
        }
    }
}