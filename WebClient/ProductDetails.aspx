<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="WebClient.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div id="gallery" class="span3">
            <a href="themes/images/products/large/f1.jpg" title="Fujifilm FinePix S2950 Digital Camera">
                <img src="themes/images/products/large/3.jpg" style="width: 100%" alt="Fujifilm FinePix S2950 Digital Camera" />
            </a>
            <div id="differentview" class="moreOptopm carousel slide">
                <div class="carousel-inner">
                    <div class="item active">
                        <a href="themes/images/products/large/f1.jpg">
                            <img style="width: 29%" src="themes/images/products/large/f1.jpg" alt="" /></a>
                        <a href="themes/images/products/large/f2.jpg">
                            <img style="width: 29%" src="themes/images/products/large/f2.jpg" alt="" /></a>
                        <a href="themes/images/products/large/f3.jpg">
                            <img style="width: 29%" src="themes/images/products/large/f3.jpg" alt="" /></a>
                    </div>
                </div>
            </div>
            <div class="controls">
                <button type="submit" class="btn btn-large btn-primary pull-right">Add to cart <i class=" icon-shopping-cart"></i></button>
            </div>
        </div>
        <div class="span6">
            <h2 id="name" runat="server"></h2>
            <hr class="soft" />
            <h4>Details:</h4>
            <div id="content" runat="server"></div>
            <hr class="soft clr" />
            <h4>Description:</h4>
            <p id="descriptin" runat="server"></p>
            <hr class="soft" />
            <h4>Ask & Answer:</h4>
            <p id="comments" runat="server"></p>
            <hr class="soft" />
        </div>
    </div>
</asp:Content>