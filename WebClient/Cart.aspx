<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebClient.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Your cart</h3>
    <hr class="soft" />
    <table class="table table-bordered">
        <thead>
            <tr>
                <th>Product</th>
                <th>Name</th>
                <th>Quantity</th>
                <th>Stock</th>
                <th>Price</th>
            </tr>
        </thead>
        <tbody id="addCell" runat="server">
            <tr style="display: none;">
                <td><img width="60" src="themes/images/products/4.jpg" alt="" /></td>
                <td>MASSA AST<br /> Color : black, Material : metal</td>
                <td>
                    <div class="input-append">
                        <input class="span1" style="max-width: 34px" placeholder="1" id="appendedInputButtons" size="16" type="text">
                        <button class="btn" type="button"><i class="icon-minus"></i></button>
                        <button class="btn" type="button"><i class="icon-plus"></i></button>
                        <button class="btn btn-danger" type="button"><i class="icon-remove icon-white"></i></button>
                    </div>
                </td>
                <td>$120.00</td>
                <td>$120.00</td>
            </tr>
        </tbody>
    </table>
    <asp:LinkButton ID="buyButton" OnClick="buy" runat="server" CssClass="btn btn-large pull-right" Visible="false"></asp:LinkButton> 
</asp:Content>
