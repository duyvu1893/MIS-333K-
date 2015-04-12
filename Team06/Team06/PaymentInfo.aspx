<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LonghornMusic.Master" CodeBehind="PaymentInfo.aspx.vb" Inherits="Team06.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
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
                        <li class="active"><a href="PaymentInfo.aspx">Payment Info</a></li>
                        <li><a href="MyMusic.aspx">My Music</a></li>
                        <li><a href="OrderHistory.aspx">Order History</a></li>
                    </ul>
                </div>
                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
        </nav>
        <div class="page-header">
            <h1>Payment Info<small> Edit Payment Information</small></h1>
        </div>
        <div class="row col-xs-12" style="font-size: 16px;">

            <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                <div class="col-xs-6">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="cursor: pointer;" role="tab" id="headingOne" data-toggle="collapse" data-target="#collapseOne" aria-controls="collapseOne">
                            <div class="col-xs-6">
                                <asp:Label ID="lblCreditCardEnding1" runat="server" Text="Credit Card 1"></asp:Label>
                            </div>
                            <div class="col-xs-6">
                                <asp:Label ID="lblCreditCardExpires1" runat="server" Text=""></asp:Label>
                                <%--<span class="glyphicon glyphicon-chevron-down pull-right" aria-hidden="true" style="font-size: 16px; padding-top: 0.2em;"></span>--%>
                                <asp:Label ID="Label1" style="font-size: 16px; padding-top: 0.2em;" runat="server" Text="" CssClass="glyphicon glyphicon-chevron-down pull-right"></asp:Label>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div id="collapseOne" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                            <div class="panel-body">
                                <asp:Label ID="lblCreditCardContent1" runat="server" Text=""></asp:Label>
                                <br />
                                <div class="pull-right">
                                    <asp:LinkButton ID="btnDelete1" runat="server" CssClass="btn btn-danger">Delete</asp:LinkButton>
                                    <asp:LinkButton ID="btnEdit1" runat="server" CssClass="btn btn-warning">Edit</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-xs-6">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="cursor: pointer;" role="tab" id="headingTwo" data-toggle="collapse" data-target="#collapseTwo" aria-controls="collapseTwo">
                            <div class="col-xs-6">
                                <asp:Label ID="lblCreditCardEnding2" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-xs-6">
                                <asp:Label ID="lblCreditCardExpires2" runat="server" Text=""></asp:Label>
                                <asp:Label ID="Label2" style="font-size: 16px; padding-top: 0.2em;" runat="server" Text="" CssClass="glyphicon glyphicon-chevron-down pull-right"></asp:Label>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                            <div class="panel-body">
                                <asp:Label ID="lblCreditCardContent2" runat="server" Text=""></asp:Label>
                                <br />
                                <div class="pull-right">
                                    <asp:LinkButton ID="btnDelete2" runat="server" CssClass="btn btn-danger">Delete</asp:LinkButton>
                                    <asp:LinkButton ID="btnEdit2" runat="server" CssClass="btn btn-warning">Edit</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $('.collapse').on('shown.bs.collapse', function () {
            $(this).parent().find(".glyphicon-chevron-down").removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-up");
        }).on('hidden.bs.collapse', function () {
            $(this).parent().find(".glyphicon-chevron-up").removeClass("glyphicon-chevron-up").addClass("glyphicon-chevron-down");
        });
    </script>

</asp:Content>
