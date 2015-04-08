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
            lblError.Text = "Login failed, please try again!"
        End If

        'set session variable
        Session("CustID") = db.CustDataset.Tables("tblCustomers").Rows(0).Item("Account")

        'redirect back to the page customer was on

    End Sub
End Class