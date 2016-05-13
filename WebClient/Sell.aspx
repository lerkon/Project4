<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Sell.aspx.cs" Inherits="WebClient.Sell" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="http://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/css/datepicker.css" rel="stylesheet" type="text/css" />
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <script src="http://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/js/bootstrap-datepicker.js"></script>
    <link href="https://cdn.datatables.net/1.10.11/css/dataTables.bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="https://cdn.datatables.net/1.10.11/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.11/js/dataTables.bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#example').DataTable();
        });
        $(function () {
            $("#datepicker").datepicker({
                autoclose: true,
                todayHighlight: true
            }).datepicker('update', new Date());;
        });
        function addCell(a, b, c, d, e, f) {
            var tab = document.getElementById("addCell");
            var tr = document.createElement("tr");
            tab.appendChild(tr);
            var td0 = document.createElement("td");
            var img = document.createElement("img");
            img.setAttribute("src", f);
            img.setAttribute("height", "50");
            img.setAttribute("width", "50");
            img.setAttribute("alt", "Cinque Terre");
            td0.appendChild(img);
            tr.appendChild(td0);
            var td1 = document.createElement("td");
            td1.innerHTML = a;
            tr.appendChild(td1);
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
        }
    </script>
    <style>
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="width: 270px; display: none; top: 40%; left: 50%; position: absolute;" runat="server" id="infoFrame">
        <div class="panel-heading" style="text-align: center;">
            <h3><a href="./Login.aspx">Login</a> or <a href="./Register.aspx">register</a>.</h3>
        </div>
    </div>
    <div runat="server" id="sellFrame" style="display: none;">
        <ul class="nav nav-tabs">
            <li class="active"><a data-toggle="tab" href="#sell">Sell item</a></li>
            <li><a data-toggle="tab" href="#bought">Bought</a></li>
            <li><a data-toggle="tab" href="#sold">Sold</a></li>
        </ul>
        <div class="tab-content">
            <div id="sell" class="tab-pane fade in active">
                <div>
                    <div style="float: left;">
                        <h3>Product Name</h3>
                    </div>
                    <div style="width: 200px; float: left; margin-top: 17px; margin-left: 5px;">
                        <asp:TextBox runat="server" ID="name" CssClass="form-control" />
                    </div>
                </div>
                <div style="clear: left;">
                    <div style="float: left;">
                        <asp:Image runat="server" ID="bigPicture" class="img-rounded" alt="Cinque Terre" Width="172" Height="150" />
                        <div>
                            <div style="display: inline-block;">
                                <a href="Icons/Picture.png" class="thumbnail">
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
                        <div style="width: 60px; display: inline-block;">
                            <label for="usr">Price</label>
                            <asp:TextBox runat="server" ID="price" CssClass="form-control" />
                        </div>
                        <div style="width: 60px; display: inline-block; margin-left: 15px;">
                            <label for="usr">Amount</label>
                            <asp:TextBox runat="server" ID="amount" CssClass="form-control" />
                        </div>
                    </div>
                    <div style="width: 139px; margin-top: 10px;">
                        <label>End of sell</label>
                        <div id="datepicker" class="input-group date" data-date-format="mm-dd-yyyy">
                            <asp:TextBox runat="server" ID="date" CssClass="form-control" />
                            <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                        </div>
                    </div>
                </div>
                <div style="width: 358px; margin-top: 210px; clear: left;">
                    <div>
                        <asp:Button runat="server" ID="uploadedFile" Text="Upload" OnClick="uploadFile_Click" Style="display: inline-block; height: 24px;" />
                        <asp:FileUpload runat="server" ID="UploadImages" AllowMultiple="true" Style="display: inline-block;"/>
                    </div>
                    <label for="usr">Description</label>
                    <asp:TextBox ID="description" TextMode="multiline" Rows="5" runat="server" CssClass="form-control" Style="resize: none;" />
                    <asp:Button Style="width: 358px; margin-top: 10px;" runat="server" OnClick="sell" Text="Sell" CssClass="btn btn-success" />
                </div>
            </div>
            <div id="bought" class="tab-pane fade">
                <h3>Menu 2</h3>
                <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam.</p>
            </div>
            <div id="sold" class="tab-pane fade">
                <table id="example" class="table table-striped table-bordered" width="100%" style="text-align: center;">
                    <thead>
                        <tr>
                            <th></th>
                            <th>Name</th>
                            <th>Price</th>
                            <th>Amount</th>
                            <th>Start date</th>
                            <th>End date</th>
                        </tr>
                    </thead>
                    <tfoot style="display: none;">
                        <tr>
                            <th></th>
                            <th>Name</th>
                            <th>Price</th>
                            <th>Amount</th>
                            <th>Start date</th>
                            <th>End date</th>
                        </tr>
                    </tfoot>
                    <tbody id="addCell">
                        <tr style="display: none;">
                            <td>61</td>
                            <td style="vertical-align: middle;">
                                <img src="Icons/Basket.png" id="icon1b" />aaa</td>
                            <td style="vertical-align: middle;">System Architect</td>
                            <td>61</td>
                            <td>2011/04/25</td>
                            <td>$320,800</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
