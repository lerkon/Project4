<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        #div1 { /* bring your own prefixes */
            width: 400px;
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
            var message = document.getElementById("message");
            message.innerHTML = result;
        }

        function onError(result) {
            alert("Error");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container" id="div1">
        <div class="panel panel-default" >
            <div class="panel-heading">
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
                    <form id="form1" runat="server">
                        <div style="text-align: right;"><asp:HyperLink NavigateUrl="Register.aspx" Text="Register" runat="server"/></div>
                        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
                        <asp:Button runat="server" OnClientClick="login();return false;" Text="Log in" CssClass="btn btn-success" />
                    </form>
                    <div style="margin-top: 10px;">
                        <p id="message" class="label label-warning"></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
