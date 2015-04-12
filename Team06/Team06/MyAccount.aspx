<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LonghornMusic.Master" CodeBehind="MyAccount.aspx.vb" Inherits="Team06.MyAccount" %>

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
                    <li class="active"><a href="MyAccount.aspx">Portfolio</a></li>
                    <li><a href="ChangePassword.aspx">Change Password</a></li>
                    <li><a href="PaymentInfo.aspx">Payment Info</a></li>
                    <li><a href="MyMusic.aspx">My Music</a></li>
                    <li><a href="OrderHistory.aspx">Order History</a></li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </nav>
    <div class="container">
        <div class="page-header">
            <h1>My Account<small> See my info</small></h1>
        </div>
        <div class="row">
            <div class="col-xs-6 col-md-3">
                <asp:Button ID="btnModify" runat="server" Text="Modify My Account" CssClass="btn btn-primary" />
                <br />
                <br />
                <asp:Panel ID="pnlModify" runat="server" Visible="False">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" Enabled="true" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-primary" Enabled="true" />
                </asp:Panel>
                <br />
                <br />
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </div>
            <div class="col-xs-18 col-md-9">
                <div id="login" class="form-horizontal">
                    <div class="form-group">
                        <label class="col-sm-2" style="text-align: right">Lastname</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtLastname" runat="server" CssClass="form-control" Width="350px" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2" style="text-align: right">Firstname</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtFirstname" runat="server" CssClass="form-control" Width="350px" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2" style="text-align: right">Email</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Width="350px" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2" style="text-align: right">Password</label>
                        <div class="col-sm-6">
                            <a href="ChangePassword.aspx">Change password?</a>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2" style="text-align: right">Phone</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" Width="350px" MaxLength="10" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2" style="text-align: right">Adresss</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Width="350px" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2" style="text-align: right">City</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" Width="350px" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2" style="text-align: right">State</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtState" runat="server" CssClass="form-control" Width="350px" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2" style="text-align: right">Zip Code</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control" Width="350px" AutoPostBack="True" MaxLength="5" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                      <div class="form-group">
                        <label class="col-sm-2" style="text-align: right">Credit Card</label>
                        <div class="col-sm-6">
                            <a href="PaymentInfo.aspx">Change credit card?</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
      
        <%--<button type="submit" class="btn btn-info" id="btnCreateAccount">Create An Account Now</button>--%>
    </div>
</asp:Content>
