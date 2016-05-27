<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Bought.aspx.cs" Inherits="WebClient.Bought" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table table-bordered">
        <thead>
            <tr>
                <th>Product</th>
                <th>Name</th>
                <th>Bought</th>
                <th>Category</th>
                <th>Amount</th>
                <th>Price</th>
                <th>Total price</th>
            </tr>
        </thead>
        <tbody id="addCell" runat="server">
        </tbody>
    </table>
</asp:Content>