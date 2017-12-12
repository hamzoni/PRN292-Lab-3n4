using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PRN292_LAB_2.Models
{
    public class Model
    {
        protected string cs;
        protected string tb;

        public Model(string tb)
        {
            this.tb = tb;
            this.cs = ConfigurationManager.ConnectionStrings["db"].ToString();
        }

        public DataTable getTable(string sql)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adt.Fill(ds);

            DataTable tbl = ds.Tables[0];

            return tbl;
        }
    }
}