using PRN292_LAB_2.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PRN292_LAB_2.Models
{
    public class OrderDetailModel : Model
    {
        public OrderDetailModel(string tb) : base(tb)
        {
        }

        public void insert(OrderDetail entity)
        {
            string query = "INSERT INTO " + tb + " VALUES(@p1, @p2, @p3, @p4, @p5)";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);

            SqlParameter p1 = new SqlParameter("@p1", entity.orderID);
            SqlParameter p2 = new SqlParameter("@p2", entity.Product.id);
            SqlParameter p3 = new SqlParameter("@p3", entity.price);
            SqlParameter p4 = new SqlParameter("@p4", entity.quantity);
            SqlParameter p5 = new SqlParameter("@p5", entity.discount);

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}