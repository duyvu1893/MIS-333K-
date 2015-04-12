<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LonghornMusic.Master" CodeBehind="MyMusic.aspx.vb" Inherits="Team06.MyMusic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="navbar navbar-primary">
        <div class="container-fluid">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav nav-tabs navbar-nav navbar-right">
                    <li><a href="MyAccount.aspx">Portfolio</a></li>
                    <li><a href="ChangePassword.aspx">Change Password</a></li>
                    <li><a href="PaymentInfo.aspx">Payment Info</a></li>
                    <li class="active"><a href="MyMusic.aspx">My Music</a></li>
                    <li><a href="OrderHistory.aspx">Order History</a></li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </nav>
    <div class="container">
        <div class="page-header">
            <h1><small>My Music</small></h1>
        </div>

        <div class="form-group">
            <div class="form-control">
                <div class="row">
                    <div class="col-md-6">
                        <div class="input-group">
                            <asp:TextBox ID="txtSearchCriteria" runat="server" CssClass="form-control" Width="60%" placeholder="Filter by ..."></asp:TextBox>
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="btn btn-info" Style="margin: 0px">
                                <asp:ListItem>Title</asp:ListItem>
                                <asp:ListItem>Artist</asp:ListItem>
                                <asp:ListItem>Album</asp:ListItem>
                                <asp:ListItem>Genre</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div style="margin-top: 30px">
                            <asp:Button ID="btnFilter" runat="server" Text="Filter" CssClass="btn btn-primary" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-primary" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <p>Sort by :</p>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True">
                            <asp:ListItem>Title</asp:ListItem>
                            <asp:ListItem>Artist</asp:ListItem>
                            <asp:ListItem>Genre</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="col-md-3">
                        Records per Page 
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" CssClass="btn-success">
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
            </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <asp:GridView ID="gvCustomers" runat="server"
                CssClass="table table-hover table-striped" GridLines="None"
                AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Phone" HeaderText="ID" Visible="false" />
                    <asp:BoundField DataField="Last Name" HeaderText="Title" />
                    <asp:BoundField DataField="Last Name" HeaderText="Album" />
                    <asp:BoundField DataField="First Name" HeaderText="Genre(s)" />
                    <asp:BoundField DataField="Phone" HeaderText="Artist(s)" />
                </Columns>
                <RowStyle CssClass="cursor-pointer" />
            </asp:GridView>
            <div>
                <ul class="pagination pagination-sm">
                    <li><a href="#">&laquo;</a></li>
                    <li><a href="#">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">5</a></li>
                    <li><a href="#">&raquo;</a></li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
