<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="WebClient.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div id="gallery" class="span3">
            <a id="bigPictureA" runat="server" title="Fujifilm FinePix S2950 Digital Camera">
                <asp:Image runat="server" ID="bigPictureB" Style="width: 100%; height: 100%"/></a>
            <div id="differentview" class="moreOptopm carousel slide">
                <div class="carousel-inner">
                    <div class="item active">
                        <a id="pic1a" runat="server">
                            <asp:Image runat="server" ID="pic1b" Style="width: 29%"/></a>
                        <a id="pic2a" runat="server">
                            <asp:Image runat="server" ID="pic2b" Style="width: 29%"/></a>
                        <a id="pic3a" runat="server">
                            <asp:Image runat="server" ID="pic3b" Style="width: 29%"/></a>
                    </div>
                </div>
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
            <h4>Comments:</h4>
            <p id="comments" runat="server"></p>
            <hr class="soft" />
        </div>
    </div>
</asp:Content>