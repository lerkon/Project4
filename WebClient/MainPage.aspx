<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="WebClient.MainPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FileUpload ID="FileUpload1" runat="server" />
<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick = "Upload" />
<hr />
<asp:Panel ID = "Panel1" runat = "server" Visible = "false" >
    <asp:Image ID="Image1" runat="server"/>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick = "Save" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick = "Cancel" />
</asp:Panel>
</asp:Content>
