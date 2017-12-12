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
    public partial class cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Order order = (Order)Session["order"];

                bool hasOrder = order != null;
                bool hasMessage = Session["message"] != null;
                if (hasOrder)
                {
                    List<OrderDetail> carts = order.carts;
                    DataTable dt = CartUI.getDataTable(carts);
                    table_products.DataSource = dt;
                    table_products.DataBind();

                    Button1.Text = "Submit";
                } 
                    

                if (hasMessage)
                {
                    label_notification.Text = Session["message"].ToString();
                    Session["message"] = null;
                }

                if (!hasOrder)
                {
                    Button1.Text = "Go back";
                    if (!hasMessage)
                    {
                        label_notification.Text = "Order is empty.";
                    }
                }
            }
        }

        protected void table_products_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            Order order = (Order)Session["order"];
            List<OrderDetail> carts = order.carts;
            OrderDetail item = carts[index];

            if (e.CommandName == "addQty")
            {
                item.quantity += 1;
            } else if (e.CommandName == "decQty")
            {
                if (item.quantity == 0) return;
                item.quantity -= 1;
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // submit data
            Order order = (Order)Session["order"];
            if (order == null)
            {
                Response.Redirect("./default.aspx");
                return;
            }

            int orderID = DataModel.ord.insertGetId(order);

            foreach (OrderDetail item in order.carts)
            {
                item.orderID = orderID;
                DataModel.odt.insert(item);
            }
            Session["order"] = null;
            Session["message"] = "CREATE ORDER SUCCESS. --ORDER ID: " + orderID  + " --TOTAL ITEMS: " + order.carts.Count;
            Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}