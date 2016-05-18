<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Buy.aspx.cs" Inherits="WebClient.Buy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Products Name <small class="pull-right">40 products are available </small></h3>
    <hr class="soft" />



    <div id="addProduct" runat="server">
        <div class="row">
            <div class="span2">
                <img src="themes/images/products/3.jpg" alt="" />
            </div>
            <div class="span4">
                <h3>Product Name </h3>
                <p>Nowadays the lingerie industry is one</p>
                <a class="btn btn-small pull-right" href="product_details.html">View Details</a>
                <br class="clr" />
            </div>
            <div class="span3 alignR">
                <h3>$140.00</h3>
                <a href="product_details.html" class="btn btn-large btn-primary">Add to <i class=" icon-shopping-cart"></i></a>
            </div>
        </div>
    </div>
</asp:Content>
