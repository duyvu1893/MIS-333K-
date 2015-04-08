<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LonghornMusic.Master" CodeBehind="SearchMusic.aspx.vb" Inherits="Team06.SearchMusic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="padding-top: 50px">
      <div class="page-header">
        <h1>My Account<small>See my info</small></h1>
      </div>
 <form class="form-inline">
   <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-4" style="text-align: right">Title</label>
                <div class="col-md-8">
                <asp:TextBox ID="txtLastname" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>            
            </div>
                </div>
</div>     
      <asp:RadioButton ID="radSong" runat="server" />
  <button type="submit" class="btn btn-default">Sign in</button>
</form>
</div>
</asp:Content>
