<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="PRN292_LAB_2.Views.detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Detail</title>
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bulma/0.6.1/css/bulma.min.css">
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
         <h1 class="title is-1">Product Detail</h1>
        <asp:GridView ID="table_product" CssClass="table is-striped is-bordered" runat="server" AutoGenerateColumns="True">
        </asp:GridView>
        <a CssClass="button is-text" href="<%= Request.UrlReferrer.ToString() %>">Return previous page</a>
    </div>
    </form>
</body>
</html>
