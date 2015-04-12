<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LonghornMusic.Master" CodeBehind="ChangePassword.aspx.vb" Inherits="Team06.ChangePassword" %>

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
                        <li class="active"><a href="ChangePassword.aspx">Change Password</a></li>
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
            <h1>Change Password<small> Here</small></h1>
        </div>
        <div class="row">
            <div class="col-xs-6 col-md-4">
                <asp:Button ID="btnSavePassword" runat="server" Text="Save" CssClass="btn btn-primary" Enabled="true" OnClick="btnSavePassword_Click" />
                <br />
                <br />
                <asp:Panel ID="pnlConfirmChange" runat="server" Visible="False">
                    <asp:Button ID="btnConfirm" runat="server" Text="Confirm" CssClass="btn btn-primary" OnClick="btnConfirm_Click" />
                    <br />
                    <br />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-primary" OnClick="btnCancel_Click" />
                    <br />
                    <br />
                </asp:Panel>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-xs-18 col-md-8">
                <div id="login" class="form-group">
                    <div class="form-group">
                        <label>Current Password</label>
                        <asp:TextBox ID="txtCurrentPassword" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>New Password</label>
                        <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Confirm New Password</label>
                        <asp:TextBox ID="txtPasswordAgain" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        &nbsp;<div class="col-sm-6">
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--<button type="submit" class="btn btn-info" id="btnCreateAccount">Create An Account Now</button>--%>
    </div>
</asp:Content>
