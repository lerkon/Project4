<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="WebClient.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="width: 270px; display: none; top: 40%; left: 50%; position: absolute;" runat="server" id="infoFrame">
        <div class="panel-heading" style="text-align: center;">
            <h3><a href="./Login.aspx">Login</a> or <a href="./Register.aspx">register</a>.</h3>
        </div>
    </div>
    <div class="container" style="width: 496px; display: none;" runat="server" id="updateFrame">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 id="h4_1">Update</h4>
            </div>
            <div class="panel-body">
                <div class="panel-body" id="div2">
                    <div>
                        <div class="form-group" style="display: inline-block; width: 200px;">
                            <label for="usr">Login</label>
                            <asp:TextBox runat="server" ID="login" CssClass="form-control" />
                        </div>
                        <div class="form-group" style="display: inline-block; width: 200px;">
                            <label for="usr">Password</label>
                            <asp:TextBox runat="server" ID="password" TextMode="Password" CssClass="form-control" />
                        </div>
                    </div>
                    <div>
                        <div class="form-group" style="display: inline-block; width: 200px;">
                            <label for="usr">Name</label>
                            <asp:TextBox runat="server" ID="name" CssClass="form-control" />
                        </div>
                        <div class="form-group" style="display: inline-block; width: 200px;">
                            <label for="usr">Surname</label>
                            <asp:TextBox runat="server" ID="surname" CssClass="form-control" />
                        </div>
                    </div>
                    <div>
                        <div class="form-group" style="display: inline-block; width: 200px;">
                            <label for="usr">Email</label>
                            <asp:TextBox runat="server" ID="email" CssClass="form-control" />
                        </div>
                        <div class="form-group" style="display: inline-block; width: 200px;">
                            <label for="usr">Phone No.</label>
                            <asp:TextBox runat="server" ID="phone" CssClass="form-control" />
                        </div>
                    </div>
                    <div>
                        <div class="form-group" style="display: inline-block; width: 200px;">
                            <label for="usr">Address</label>
                            <asp:TextBox runat="server" ID="address" CssClass="form-control" />
                        </div>
                        <div class="form-group" style="display: inline-block; width: 200px; margin-bottom: 0px;">
                            <label for="usr">Zip Code</label>
                            <asp:TextBox runat="server" ID="zipCode" CssClass="form-control" />
                        </div>
                    </div>
                    <div>
                        <div style="margin-top: 0px;">
                            <asp:CheckBox ID="checkBox" runat="server" OnCheckedChanged="tick" AutoPostBack="true" Text="&nbsp I have a company." />
                        </div>
                        <div id="box" style="display: none; margin-bottom: 15px;" runat="server">
                            <div class="form-group" style="display: inline-block; width: 200px;">
                                <label for="usr">Company name</label>
                                <asp:TextBox runat="server" ID="companyName" CssClass="form-control" />
                            </div>
                            <div class="form-group" style="display: inline-block; width: 200px; margin-bottom: 0px;">
                                <label for="usr">Website</label>
                                <asp:TextBox runat="server" ID="website" CssClass="form-control" />
                            </div>
                            <div class="form-group" style="display: inline-block; width: 400px; margin-bottom: 0px;">
                                <label for="usr">Description</label>
                                <asp:TextBox ID="description" TextMode="multiline" Rows="5" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                    </div>
                    <asp:Button Style="width: 400px;" runat="server" OnClick="update" Text="Accept" CssClass="btn btn-success" />
                    <div style="margin-top: 10px; display: none;" id="labelBox" runat="server">
                        <asp:Label ID="label" runat="server" CssClass="label label-warning"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
