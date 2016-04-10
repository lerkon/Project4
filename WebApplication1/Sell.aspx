<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sell.aspx.cs" Inherits="Sell" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container" style="width: 270px; display: none; top: 40%; left: 50%; position: absolute;" runat="server" id="infoFrame">
        <div class="panel-heading" style="text-align:center;">
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
                        <img id="bigPicture" src="Icons/Picture.png" class="img-rounded" alt="Cinque Terre" width="170" height="150" />
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
                            <asp:TextBox runat="server" ID="date" CssClass="form-control" type="text" ReadOnly="true" />
                            <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                        </div>
                    </div>
                </div>
                <div style="width: 358px; margin-top: 200px;">
                    <label for="usr">Description</label>
                    <asp:TextBox ID="description" TextMode="multiline" Rows="5" runat="server" CssClass="form-control" />
                    <asp:Button Style="width: 358px; margin-top: 10px;" runat="server" OnClick="sell" Text="Sell" CssClass="btn btn-success" />
                </div>
            </div>
            <div id="bought" class="tab-pane fade">
                <h3>Menu 2</h3>
                <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam.</p>
            </div>
            <div id="sold" class="tab-pane fade">
                <table id="example" class="table table-striped table-bordered" cellspacing="3" width="100%">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Price</th>
                            <th>Stock</th>
                            <th>Start date</th>
                            <th>End date</th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <th>Name</th>
                            <th>Price</th>
                            <th>Stock</th>
                            <th>Start date</th>
                            <th>End date</th>
                        </tr>
                    </tfoot>
                    <tbody>
                        <tr>
                            <td>Tiger Nixon</td>
                            <td>System Architect</td>
                            <td>61</td>
                            <td>2011/04/25</td>
                            <td>$320,800</td>
                        </tr>
                        <tr>
                            <td>Garrett Winters</td>
                            <td>Accountant</td>
                            <td>63</td>
                            <td>2011/07/25</td>
                            <td>$170,750</td>
                        </tr>
                        <tr>
                            <td>Ashton Cox</td>
                            <td>Junior Technical Author</td>
                            <td>66</td>
                            <td>2009/01/12</td>
                            <td>$86,000</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
