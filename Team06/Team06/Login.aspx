<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LonghornMusic.Master" CodeBehind="Login.aspx.vb" Inherits="Team06.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container" style="padding-top: 50px">
      <div class="page-header">
        <h1>Sign In <small>for customer</small></h1>
      </div>
      <div id="login">
            <div class="form-group">
                <label for="lblEmail">Username</label>
                    <%--<input type="email" class="form-control" id="txtEmail" placeholder="Enter email" />--%>
                
                <br />
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                
            </div>
            <div class="form-group">
                <label for="lblPassword">Password</label>
                    <%--<input type="password" class="form-control" id="txtPassword" placeholder="Password" />--%>
                
                <br />
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>
                
            </div>
            <%--<button type="submit" class="btn btn-primary" id="btnLogin">Log in</button>--%>

            <asp:Button ID="btnLogin" runat="server" Text="Log in" CssClass="btn btn-primary" OnClick="btnLogin_Click" />


            <br /><br /><br />
            <p>Don't have an account?</p>
            <%--<button type="submit" class="btn btn-info" id="btnCreateAccount">Create An Account Now</button>--%>
          <asp:Button ID="txtCreateCustomer" runat="server" Text="Create An Account Now" CssClass="btn btn-info" OnClick="txtCreateCustomer_Click" />
        </div>
  </div>
  

</asp:Content>
