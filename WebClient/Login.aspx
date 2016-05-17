<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebClient.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #div1 { /* bring your own prefixes */
            width: 300px;
            background-color: #f5f5f5;
            margin-left: 30%;
        }

        #h4_1 {
            text-align: center;
        }

        #div2 {
            text-align: center;
            padding-bottom: 0px;
        }
    </style>

    <script>
        function login() {
            var username = document.getElementById("username").value;
            var password = document.getElementById("password").value;
            PageMethods.login(username, password, onSucess, onError);
        }
        function onSucess(result) {
            if (result == null)
                window.location = "MainPage.aspx";
            else {
                document.getElementById("infoFrame").style.display = "";
                var message = document.getElementById("message");
                message.innerHTML = result;
            }
        }
        function onError(result) {
            alert("Error");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div1">
        <div class="panel-heading" style="padding-top:10px; padding-bottom:10px">
            <h4 id="h4_1">Login</h4>
        </div>
        <div class="panel-body">
            <div class="panel-body" id="div2">
                <div class="form-group">
                    <label for="usr">Username</label>
                    <input class="form-control" id="username" type="text" />
                </div>
                <div class="form-group" style="margin-bottom: 0px;">
                    <label for="pwd">Password</label>
                    <input class="form-control" id="password" type="password" />
                </div>
                <div style="text-align: right; margin-right: 45px;">
                    <asp:HyperLink NavigateUrl="Register.aspx" Text="Register" runat="server" />
                </div>
                <asp:Button runat="server" OnClientClick="login();return false;" Text="Log in" CssClass="btn btn-success" />
                <div style="margin-top: 10px; display: none;" id="infoFrame">
                    <p id="message" class="label label-warning"></p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
