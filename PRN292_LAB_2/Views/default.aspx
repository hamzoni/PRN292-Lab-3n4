<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PRN292_LAB_2.Views._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bulma/0.6.1/css/bulma.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
             <h1 class="title is-1">Home Page</h1>
            <h1 class="title is-6">Ta Quy - LAB PRN292</h1>

            <div class="field is-horizontal">
              <div class="field-label is-normal has-text-left">
                <label class="label">Categories</label>
              </div>
              <div class="field-body">
                <div class="field">
                    <div class="select">
                        <asp:DropDownList ID="list_categories" runat="server" AutoPostBack="True" OnSelectedIndexChanged="list_categories_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
              </div>
            </div>

            <div class="notification">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </div>

            <div class="field">
            <asp:GridView ID="table_products"  CssClass="table is-striped is-bordered" runat="server" AutoGenerateColumns="False" OnRowCommand="table_products_RowCommand" AllowPaging="True" AllowSorting="True" OnPageIndexChanged="table_products_PageIndexChanged" OnPageIndexChanging="table_products_PageIndexChanging" PageSize="5" OnSorting="table_products_Sorting">
                  <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID"/>

                    <asp:TemplateField HeaderText="Name" SortExpression="Name">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server"  NavigateUrl='<%#"detail.aspx?productID="+Eval("ID") %>'>
                                <%# Eval("Name") %>
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"/>
                    <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />

                    <asp:TemplateField HeaderText="Add to cart">
                        
                        <ItemTemplate>
                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="button" CommandName="btnAdd" CommandArgument='<%# Eval("ID") %>' />
                        </ItemTemplate>

                        <FooterStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                         <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    </Columns>
            </asp:GridView>

            </div>

            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="button is-text" NavigateUrl="~/Views/cart.aspx">Go to cart</asp:HyperLink>
        </div>
            
            
            
    </form>
</body>
</html>
