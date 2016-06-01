<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="WebClient.Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table table-bordered">
        <thead>
            <tr>
                <th>ID</th>
                <th>Amount</th>
                <th>Total price</th>
                <th>Transaction day</th>
                <th>Customer</th>
                <th>Customer phone & email</th>
                <th>Customer address</th>
            </tr>
        </thead>
        <tbody id="addCell" runat="server">
        </tbody>
    </table>
</asp:Content>