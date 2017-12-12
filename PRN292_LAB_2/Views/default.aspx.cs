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
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                List<Category> categories = DataModel.ctg.list();
                foreach (Category c in categories)
                {
                    ListItem item = new ListItem();
                    item.Value = c.id.ToString();
                    item.Text = c.name;

                    list_categories.Items.Add(item);
                }
                List<Product> list = DataModel.prd.searchByCategory(categories[0].id);
                setProductsTable(list);
            }

            if (Session["message2"] != null)
            {
                Label1.Text = Session["message2"].ToString();
                Session["message2"] = null;
            }
        }

        private void setProductsTable(List<Product> list)
        {
            DataTable table = ProductUI.getDataTable(list);
            table_products.DataSource = table;
            table_products.DataBind();

            // set viewstate for sorting
            ViewState["dirState"] = table;
            ViewState["sortdr"] = "Asc";
        }

        protected void list_categories_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem item = list_categories.SelectedItem;
            List<Product> list = DataModel.prd.searchByCategory(item.Value);
            setProductsTable(list);
        }

        protected void table_products_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("btnAdd"))
            {
                string id = e.CommandArgument.ToString();
                Product p = DataModel.prd.searchById(id);

                Order order = (Order)Session["order"];
                // if order is not initiated, create new
                if (order == null) {
                    order = new Order();
                }

                List<OrderDetail> carts = order.carts;
                
                // check for duplicate record
                bool isDup = false;
                foreach (OrderDetail item in carts)
                {
                    if (item.Product.id == p.id)
                    {
                        item.quantity += 1;
                        isDup = true;
                        break;
                    }
                }

                // if not duplicate, create new order detail
                if (!isDup)
                {
                    OrderDetail detail = new OrderDetail();
                    detail.Product = p;
                    order.carts.Add(detail);
                }

                Session["order"] = order;

                // set notification
                Session["message2"] = "Added <b>" + p.name + "</b> to cart.";
                Label1.Text = Session["message2"].ToString();
            }
        }

        protected void table_products_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void table_products_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            table_products.PageIndex = e.NewPageIndex;
            ListItem item = list_categories.SelectedItem;
            List<Product> list = DataModel.prd.searchByCategory(item.Value);
            setProductsTable(list);
        }

        protected void table_products_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["sortdr"]) == "Asc")
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdr"] = "Desc";
                }
                else
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdr"] = "Asc";
                }
                table_products.DataSource = dtrslt;
                table_products.DataBind();


            }
        }

    }
}