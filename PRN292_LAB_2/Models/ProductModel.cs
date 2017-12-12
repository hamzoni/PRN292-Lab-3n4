using PRN292_LAB_2.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PRN292_LAB_2.Models
{
    public class ProductModel : Model
    {
        public ProductModel(string tb) : base(tb)
        {
            
        }

        public Product searchById(object x)
        {
            string query = "SELECT * FROM  " + tb + "  WHERE ProductID = " + x;
            DataTable tbl = getTable(query);

            foreach (DataRow r in tbl.Rows)
            {
                Product p = new Product();
                p.id = Convert.ToInt32(r["ProductID"]);
                p.name = r["ProductName"].ToString();
                p.price = Convert.ToDouble(r["UnitPrice"]);
                p.category = DataModel.ctg.searchByID(r["CategoryID"]);
                p.discontinue = Convert.ToBoolean(r["Discontinued"]);
                return p;
            }

            return null;
        }

        public DataTable searchById2(object x)
        {
            string query = "SELECT * FROM " + tb + " WHERE ProductID = " + x;
            return getTable(query);
        }

        public List<Product> searchByCategory(object x)
        {
            List<Product> list = new List<Product>();

            string query = "SELECT * FROM  " + tb + "  WHERE CategoryID = " + x;
            DataTable tbl = getTable(query);

            foreach (DataRow r in tbl.Rows)
            {
                Product p = new Product();
                p.id = Convert.ToInt32(r["ProductID"]);
                p.name = r["ProductName"].ToString();
                p.price = Convert.ToDouble(r["UnitPrice"]);
                p.category = DataModel.ctg.searchByID(r["CategoryID"]);
                p.discontinue = Convert.ToBoolean(r["Discontinued"]);

                list.Add(p);
                
            }

            return list;
        }

        public DataTable searchByCategory2(object x)
        {
            List<Product> list = new List<Product>();

            string query = "SELECT * FROM  " + tb + "  WHERE CategoryID = " + x;
            return getTable(query);

        }
    }
}