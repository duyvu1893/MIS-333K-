<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LonghornMusic.Master" CodeBehind="SignUp.aspx.vb" Inherits="Team06.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="page-header">
            <h1>Sign Up<small> Becoming a member of Longhorn Music</small></h1>
        </div>
        <div class="row">
            <div class="col-xs-6 col-md-3">
                <asp:Button ID="btnModify" runat="server" Text="Sign Up" CssClass="btn btn-primary" />
                <br />
                <br />
                <asp:Panel ID="pnlModify" runat="server">
                    <asp:Button ID="btnCancle" runat="server" Text="Cancel" CssClass="btn btn-primary" Enabled="true" />
                </asp:Panel>
            </div>
            <div class="col-xs-18 col-md-9">
                <div id="login" class="form-horizontal">
                    <div class="form-group">
                        <label class="col-sm-2" style="text-align: right">Last Name</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtLastname" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2" style="text-align: right">First Name</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtFirstname" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2" style="text-align: right">Phone Number</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2" style="text-align: right">Adresss</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2" style="text-align: right">City</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="TxtCity" runat="server" CssClass="form-control" Width="350px" Enabled="False"></asp:TextBox>
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
                            <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>
                        </div>
                    </div>        
                    <div class="form-group">
                        <label class="col-sm-2" style="text-align: right">Username</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"  placeholder="Enter Email Here" Width="350px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2" style="text-align: right">Password</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"  placeholder="Password" Width="350px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2" style="text-align: right">Comfirm Password</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"  placeholder="Enter Password Again" Width="350px"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
