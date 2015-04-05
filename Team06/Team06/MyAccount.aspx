<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LonghornMusic.Master" CodeBehind="MyAccount.aspx.vb" Inherits="Team06.MyAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="padding-top: 50px">
      <div class="page-header">
        <h1>My Account<small>See my info</small></h1>
      </div>
    <div class="row">
  <div class="col-xs-6 col-md-4">
        <asp:Button ID="btnModify" runat="server" Text="Modify My Account" CssClass="btn btn-primary" OnClick="btnModify_Click" /><br /><br />
      <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" Enabled="false" OnClick="btnSave_Click" />
      <asp:Button ID="btnAbort" runat="server" Text="Abort" CssClass="btn btn-primary" Enabled="false" OnClick="btnAbort_Click" />
      <asp:Button ID="btnCancle" runat="server" Text="Cancle" CssClass="btn btn-primary" Enabled="false" OnClick="btnCancle_Click" />
  </div>  
  <div class="col-xs-18 col-md-8">
        <div id="login" class="form-horizontal">
            <div class="form-group">
                <label class="col-sm-2" style="text-align: right">Lastname</label>
                <div class="col-sm-6">
                <asp:TextBox ID="txtLastname" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>            
            </div>
                </div>
            <div class="form-group">
                <label class="col-sm-2" style="text-align: right">Firstname</label>
                <div class="col-sm-6">
                <asp:TextBox ID="txtFirstname" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>     
            </div></div>
          <div class="form-group">
                <label class="col-sm-2" style="text-align: right">Username</label>
              <div class="col-sm-6">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>     
            </div></div>
          <div class="form-group">
                <label class="col-sm-2" style="text-align: right">Password</label>
              <div class="col-sm-6">
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>     
            </div></div>
          <div class="form-group">
                <label class="col-sm-2" style="text-align: right">Phone</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>     
            </div></div>
           <div class="form-group">
                <label class="col-sm-2" style="text-align: right">Adresss</label>
               <div class="col-sm-6">
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>     
            </div></div>
           <div class="form-group">
                <label class="col-sm-2" style="text-align: right">City</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="TxtCity" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>     
            </div></div>
           <div class="form-group">
                <label class="col-sm-2" style="text-align: right">State</label>
                <div class="col-sm-6">
                <asp:TextBox ID="txtState" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>     
            </div></div>
           <div class="form-group">
                <label class="col-sm-2" style="text-align: right">Zip Code</label>
               <div class="col-sm-6">
                <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>     
            </div></div>
        </div>
    </div>
</div>

            <%--<button type="submit" class="btn btn-info" id="btnCreateAccount">Create An Account Now</button>--%>
        </div>

</asp:Content>
