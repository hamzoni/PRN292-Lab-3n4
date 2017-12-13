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
                return convertRow(r);
            }

            return null;
        }

        public Product convertRow(DataRow r)
        {
            
            Product p = new Product();

            if (!r.IsNull("ProductID")) p.id = Convert.ToInt32(r["ProductID"]);
            if (!r.IsNull("ProductName")) p.name = (string)r["ProductName"];
            if (!r.IsNull("UnitPrice")) p.price = Double.Parse(r["UnitPrice"].ToString());

            if (!r.IsNull("CategoryID")) p.category = DataModel.ctg.searchByID(r["CategoryID"]);
            if (!r.IsNull("Discontinued")) p.discontinue = Convert.ToBoolean(r["Discontinued"]);

            return p;
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
                list.Add(convertRow(r));
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