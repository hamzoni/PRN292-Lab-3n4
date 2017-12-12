using PRN292_LAB_2.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PRN292_LAB_2.Models
{
    public class CategoryModel : Model
    {
        public CategoryModel(string tb) : base(tb)
        {
            
        }
        public List<Category> list()
        {
            List<Category> list = new List<Category>();
            string query = "SELECT * FROM " + tb;

            DataTable tbl = getTable(query);
            foreach (DataRow r in tbl.Rows)
            {
                Category entity = new Category();
                entity.id = Convert.ToInt32(r["CategoryID"]);
                entity.name = r["CategoryName"].ToString();
                list.Add(entity);
            }

            return list;
        }

        public Category searchByID(object x)
        {
            string query = "SELECT * FROM " + tb + " WHERE CategoryID = " + x;

            DataTable tbl = getTable(query);
            foreach (DataRow r in tbl.Rows)
            {
                Category entity = new Category();
                entity.id = Convert.ToInt32(r["CategoryID"]);
                entity.name = r["CategoryName"].ToString();
                return entity;
            }

            return null;
        }
    }
}