<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LonghornMusic.Master" CodeBehind="Index.aspx.vb" Inherits="Team06.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="padding-top: 50px">
        <div class="page-header">
            <h1>Welcome! <small>Longhorn Music Today's Pick</small></h1>
        </div>
        <div class="row">
            <div class="col-sm-6 col-md-4">
                <div class="thumbnail">
                    <img src="Images/Maroon-5-Sugar.jpg" class="img-rounded" style="width: 200px" alt="..." />
                    <div class="caption">
                        <h3>SONG NAME</h3>
                        <p>...</p>
                        <p><a href="#" class="btn btn-primary" role="button">Button</a> <a href="#" class="btn btn-default" role="button">Button</a></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
