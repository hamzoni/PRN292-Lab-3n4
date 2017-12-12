using PRN292_LAB_2.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PRN292_LAB_2.Models
{
    public class OrderModel : Model
    {
        public OrderModel(string tb) : base(tb)
        {
        }
        public int insertGetId(Order order)
        {
            string query = "INSERT INTO " + tb + "(\"OrderDate\") OUTPUT inserted.OrderID VALUES(GETDATE())";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            int orderID = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            return orderID;
        }
    }
}