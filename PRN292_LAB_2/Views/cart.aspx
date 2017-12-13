<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="PRN292_LAB_2.Views.cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cart</title>
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bulma/0.6.1/css/bulma.min.css">
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <h1 class="title is-1">Cart</h1>
        <asp:GridView ID="table_products" runat="server" AutoGenerateColumns="False" CssClass="table is-striped is-bordered" EnableModelValidation="True" OnRowCommand="table_products_RowCommand">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:BoundField DataField="Category" HeaderText="Category" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:ButtonField ButtonType="Button" Text="+" CommandName="addQty" ControlStyle-CssClass="button" />
                <asp:ButtonField ButtonType="Button" Text="-" CommandName="decQty" ControlStyle-CssClass="button" />
            </Columns>
        </asp:GridView>
        <div class="notification">
            <asp:Label ID="label_notification" runat="server"></asp:Label>
        </div>
        <div>
        <asp:Button ID="Button1" CssClass="button is-primary" runat="server" Text="Submit" OnClick="Button1_Click" />
        </div>
    </div>
    </form>
</body>
</html>
