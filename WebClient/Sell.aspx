<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Sell.aspx.cs" Inherits="WebClient.Sell" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tab-content">
        <div style="clear: left;">
            <div style="float: left;">
                <asp:Image runat="server" ID="bigPicture" class="img-rounded" alt="Cinque Terre" Width="172" Height="155" />
                <div>
                    <div style="display: inline-block;">
                        <a class="thumbnail">
                            <asp:Image runat="server" ID="smallPicture1" alt="Cinque Terre" Style="width: 40px; height: 40px" />
                        </a>
                    </div>
                    <div style="display: inline-block;">
                        <a href="Icons/Picture.png" class="thumbnail">
                            <asp:Image runat="server" ID="smallPicture2" alt="Cinque Terre" Style="width: 40px; height: 40px" />
                        </a>
                    </div>
                    <div style="display: inline-block;">
                        <a href="Icons/Picture.png" class="thumbnail">
                            <asp:Image runat="server" ID="smallPicture3" alt="Cinque Terre" Style="width: 40px; height: 40px" />
                        </a>
                    </div>
                </div>
            </div>
        </div>
        <div style="float: left; margin-top: 17px; margin-left: 48px;">
            <div>
                <div style="display: inline-block;">
                    <label style="clear: left;">Product&nbsp;name</label>
                    <asp:TextBox runat="server" ID="name" CssClass="form-control" Width="150px" />
                </div>
            </div>
            <div>
                <div style="display: inline-block;">
                    <label>Price</label>
                    <asp:TextBox runat="server" ID="price" CssClass="form-control" Width="60px" />
                </div>
                <div style="display: inline-block; margin-left: 15px;">
                    <label>Amount</label>
                    <asp:TextBox runat="server" ID="amount" CssClass="form-control" Width="60" />
                </div>
            </div>
            <div>
                <div style="display: inline-block;">
                    <label>End of sell</label>
                    <asp:TextBox runat="server" ID="date" CssClass="form-control" Width="60px" />
                </div>
                <div style="display: inline-block; margin-left: 15px;">
                    <label>Category</label>
                    <asp:TextBox runat="server" ID="category" CssClass="form-control" Width="60" />
                </div>
            </div>
        </div>
        <div style="margin-top: 210px; clear: left; width: 450px">
            <div>
                <asp:Button runat="server" ID="uploadedFile" Text="Upload" OnClick="uploadFile_Click" Style="display: inline-block; height: 24px;" />
                <asp:FileUpload runat="server" ID="UploadImages" AllowMultiple="true" Style="display: inline-block;" />
            </div>
            <label>Description</label>
            <asp:TextBox ID="description" TextMode="multiline" Rows="5" runat="server" CssClass="form-control" Style="resize: none;" Width="370px" />
            <asp:Button Style="width: 385px; margin-top: 10px;" runat="server" OnClick="sell" Text="Sell" CssClass="btn btn-success" />
        </div>
    </div>
</asp:Content>
