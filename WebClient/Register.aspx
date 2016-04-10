<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebClient.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function toggleCheckbox() {
            $("#box").toggle();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="width: 496px;">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 id="h4_1">Register</h4>
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
                        <div class="checkbox" style="margin-top: 0px;">
                            <label>
                                <input type="checkbox" onchange="toggleCheckbox()" />I have a company.</label>
                        </div>
                        <div id="box" style="display: none; margin-bottom: 15px;">
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
                    <asp:Button Style="width: 400px;" runat="server" OnClick="registerr" Text="Continue" CssClass="btn btn-success" />
                    <div style="margin-top: 10px;">
                        <p id="message" class="label label-warning"></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
