Option Strict On
Public Class Login
    Inherits System.Web.UI.Page

    'define customer db class
    Dim db As New ClassCustomersDB

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'clear error
        lblError.Text = ""

        'if login is incorrect
        If db.CheckCustomerLogin(txtEmail.Text, txtPassword.Text) = False Then
            'display error
            lblError.Text = "Login failed. Please try again!"
            Exit Sub
        End If

        'set session variable
        Session("CustID") = db.CustDataset.Tables("tblCustomers").Rows(0).Item("Account")

        'redirect to last page
        RedirectToLastPage()
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'if logged in
        If Not (Session("CustID") Is Nothing) Then
            'redirect to last page
            RedirectToLastPage()
        End If
    End Sub

    Protected Sub RedirectToLastPage()
        'redirect back to the page customer was on
        If Request.QueryString("lp") Is Nothing Then
            'if customer click directly on customer button, redirect to myaccount page
            Response.Redirect("MyAccount.aspx")
        Else
            Response.Redirect(Request.QueryString("lp") & ".aspx")
        End If
    End Sub

    Protected Sub btnCreateCustomer_Click(sender As Object, e As EventArgs) Handles btnCreateCustomer.Click
        Response.Redirect("SignUp.aspx")
    End Sub
End Class