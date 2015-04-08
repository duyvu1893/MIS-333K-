<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LonghornMusic.Master" CodeBehind="SearchSong.aspx.vb" Inherits="Team06.SearchSong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="padding-top: 50px">
        <div class="page-header">
            <h1>Search Songs<small>Enter information to search for songs</small></h1>
        </div>
        <div class="row">
        
            <div class="col-md-3"></div>
            <div class="col-md-4">
            <div class="form-group">
            <label>Title</label>
            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Genre</label>
            <asp:TextBox ID="txtGenre" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Artist</label>
            <asp:TextBox ID="txtArtist" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>
        </div>
          <label>Album</label>
            <asp:TextBox ID="TxtAlbum" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <div class="form-group">
            <label>Rating</label>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:DropDownList>
            </div>
            
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem Selected="True" Value="0">Patial Search</asp:ListItem>
                <asp:ListItem Value="1">Keyword Search</asp:ListItem>
            </asp:RadioButtonList>
    </div></div>
        
        <button type="submit" class="btn btn-default">Search By All Criterias</button>

   </div>
</asp:Content>
