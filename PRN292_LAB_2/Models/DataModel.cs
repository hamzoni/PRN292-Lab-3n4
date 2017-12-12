using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRN292_LAB_2.Models
{
    public class DataModel
    {
        public static OrderModel ord = new OrderModel("Orders");
        public static ProductModel prd = new ProductModel("Products");
        public static CategoryModel ctg = new CategoryModel("Categories");
        public static OrderDetailModel odt = new OrderDetailModel("[Order Details]");
    }
}