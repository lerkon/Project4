<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Sold.aspx.cs" Inherits="WebClient.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function addCell(a, b, c, d, e, f, g, h) {
            var tab = document.getElementById("addCell");
            var tr = document.createElement("tr");
            tab.appendChild(tr);
            var td0 = document.createElement("td");
            var img = document.createElement("img");
            img.setAttribute("src", f);
            img.setAttribute("height", "100");
            img.setAttribute("width", "100");
            img.setAttribute("alt", "Cinque Terre");
            td0.appendChild(img);
            tr.appendChild(td0);
            var td1 = document.createElement("td");
            td1.id = h;
            td1.innerHTML = a;
            tr.appendChild(td1);
            //var link = document.createElement("a");
            //link.href = "./Details.aspx";
            //link.innerHTML = a;
            //link.style.color = 'blue';
            //link.id = h;
            //td1.appendChild(link);
            var td2 = document.createElement("td");
            td2.innerHTML = b;
            tr.appendChild(td2);
            var td3 = document.createElement("td");
            td3.innerHTML = c;
            tr.appendChild(td3);
            var td4 = document.createElement("td");
            td4.innerHTML = d;
            tr.appendChild(td4);
            var td5 = document.createElement("td");
            td5.innerHTML = e;
            tr.appendChild(td5);
            var td6 = document.createElement("td");
            td6.innerHTML = g;
            tr.appendChild(td6);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table table-bordered">
        <thead>
            <tr>
                <th>Product</th>
                <th>Name</th>
                <th>Price</th>
                <th>Amount</th>
                <th>Start date</th>
                <th>End date</th>
                <th>Category</th>
            </tr>
        </thead>
        <tbody id="addCell">
            <tr style="display: none;">
                <td>
                    <img width="60" src="themes/images/products/4.jpg" alt="" /></td>
                <td>MASSA AST<br />
                    Color : black, Material : metal</td>
                <td>fdgdfs</td>
                <td>$120.00</td>
                <td>$25.00</td>
                <td>$15.00</td>
                <td>$110.00</td>
            </tr>
        </tbody>
    </table>
</asp:Content>
