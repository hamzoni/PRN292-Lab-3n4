using PRN292_LAB_2.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PRN292_LAB_2.Data
{
    public class ProductUI
    {
        public static DataTable getDataTable(List<Product> prds)
        {
            DataColumn[] cols = new DataColumn[] {
                new DataColumn("ID", typeof(int)),
                new DataColumn("Name", typeof(string)),
                new DataColumn("Price",typeof(string)),
                new DataColumn("Category",typeof(string)),
            };

            DataTable dt = new DataTable();

            dt.Columns.AddRange(cols);
            foreach (Product p in prds)
            {
                dt.Rows.Add(p.id, p.name, p.price, p.category.name);
            }

            return dt;
        }
    }
}