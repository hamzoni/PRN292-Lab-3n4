using PRN292_LAB_2.Data;
using PRN292_LAB_2.Entities;
using PRN292_LAB_2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRN292_LAB_2.Views
{
    public partial class detail : System.Web.UI.Page
    {
        private object list;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string productID = Request.QueryString["productID"];
                DataTable dt = DataModel.prd.searchById2(productID);
                table_product.DataSource = dt;
                table_product.DataBind();
            }
        }
    }
}