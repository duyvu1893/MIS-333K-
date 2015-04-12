<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LonghornMusic.Master" CodeBehind="SearchArtist.aspx.vb" Inherits="Team06.SearchArtist" %>
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
                        <li><a href="SearchSong.aspx">Search Song</a></li>
                        <li><a href="SearchAlbum.aspx">Search Album</a></li>
                        <li class="active"><a href="SearchArtist.aspx">Search Artist</a></li>
                    </ul>
                </div>
                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
        </nav>
    <div class="container" style="padding-top: 50px">
        <div class="page-header">
            <h1>Search Artist<small> Enter criterias to search for artists</small></h1>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div align="center">
                    <div class="form-group">
                        <div class="form-control">
                        <label>Genre</label>
                        <asp:CheckBoxList ID="cblGenre" runat="server" AutoPostBack="True" RepeatColumns="2" CssClass="genrecheckboxlist">
                        </asp:CheckBoxList>
                    </div>
                    </div>
                </div>
            </div>
            <div class="col-md-8" style="display: block; box-sizing: border-box; border-bottom: ridge; padding-top: 20px">
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Name</label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-2" style="margin: 20px 20px 20px 20px">
                    <asp:RadioButtonList ID="radName" runat="server" Width="180px">
                        <asp:ListItem Selected="True" Value="0">Patial Search</asp:ListItem>
                        <asp:ListItem Value="1">Keyword Search</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="col-md-4"></div>
            <div class="col-md-8" style="display: block; box-sizing: border-box; border-bottom: ridge; padding-top: 20px">
                <div class="col-md-1" style="padding-top:10px">
                    <%--<div class="form-group">--%>
                    <label>Rating </label>
                </div>
                <div class="col-md-1">
                    <asp:RadioButtonList ID="radRating" runat="server" Width="180px">
                        <asp:ListItem Selected="True" Value="0"> &lt </asp:ListItem>
                        <asp:ListItem Value="1"> &gt </asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-md-3" style="padding-top:10px">
                    <asp:DropDownList ID="ddlRating" runat="server" CssClass="btn btn-info dropdown-toggle" data-toggle="dropdown">
                        <asp:ListItem>1.0</asp:ListItem>
                        <asp:ListItem>1.1</asp:ListItem>
                        <asp:ListItem>1.2</asp:ListItem>
                        <asp:ListItem>1.3</asp:ListItem>
                        <asp:ListItem>1.4</asp:ListItem>
                        <asp:ListItem>1.5</asp:ListItem>
                        <asp:ListItem>1.6</asp:ListItem>
                        <asp:ListItem>1.7</asp:ListItem>
                        <asp:ListItem>1.8</asp:ListItem>
                        <asp:ListItem>1.9</asp:ListItem>
                        <asp:ListItem>2.0</asp:ListItem>
                        <asp:ListItem>2.1</asp:ListItem>
                        <asp:ListItem>2.2</asp:ListItem>
                        <asp:ListItem>2.3</asp:ListItem>
                        <asp:ListItem>2.4</asp:ListItem>
                        <asp:ListItem>2.5</asp:ListItem>
                        <asp:ListItem>2.6</asp:ListItem>
                        <asp:ListItem>2.7</asp:ListItem>
                        <asp:ListItem>2.8</asp:ListItem>
                        <asp:ListItem>2.9</asp:ListItem>
                        <asp:ListItem>3.0</asp:ListItem>
                        <asp:ListItem>3.1</asp:ListItem>
                        <asp:ListItem>3.2</asp:ListItem>
                        <asp:ListItem>3.3</asp:ListItem>
                        <asp:ListItem>3.4</asp:ListItem>
                        <asp:ListItem>3.5</asp:ListItem>
                        <asp:ListItem>3.6</asp:ListItem>
                        <asp:ListItem>3.7</asp:ListItem>
                        <asp:ListItem>3.8</asp:ListItem>
                        <asp:ListItem>3.9</asp:ListItem>
                        <asp:ListItem>4.0</asp:ListItem>
                        <asp:ListItem>4.1</asp:ListItem>
                        <asp:ListItem>4.2</asp:ListItem>
                        <asp:ListItem>4.3</asp:ListItem>
                        <asp:ListItem>4.4</asp:ListItem>
                        <asp:ListItem>4.5</asp:ListItem>
                        <asp:ListItem>4.6</asp:ListItem>
                        <asp:ListItem>4.7</asp:ListItem>
                        <asp:ListItem>4.8</asp:ListItem>
                        <asp:ListItem>4.9</asp:ListItem>
                        <asp:ListItem>5.0</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:RadioButtonList ID="radSort" runat="server" Width="180px">
                        <asp:ListItem Selected="True" Value="0">Sort By Name</asp:ListItem>
                        <asp:ListItem Value="2">Sort By Rating</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <asp:RadioButtonList ID="radSortAD" runat="server" Width="200px">
                        <asp:ListItem Selected="True" Value="0">Ascending</asp:ListItem>
                        <asp:ListItem Value="1">Descending</asp:ListItem>
                    </asp:RadioButtonList>
            </div>
        </div>
         <div class="col-md-12">
            <div align="center">
                <asp:Button ID="btnSearch"  Text="Search By All Criterias" runat="server" CssClass="btn btn-primary" type="submit" />
                <asp:Button ID="btnReset"  Text="Reset" runat="server" CssClass="btn btn-default" type="submit" />
                <br />
                <asp:Label ID="lblError" runat="server"></asp:Label><br />
                <label>Search Records: </label>
                <asp:Label ID="lblReordsCount" runat="server"></asp:Label>
                <br />
                <asp:GridView ID="gvSongsResult" runat="server" >
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
