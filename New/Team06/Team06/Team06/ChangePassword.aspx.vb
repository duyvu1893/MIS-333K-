Public Class ChangePassword
    Inherits System.Web.UI.Page

    'define new instance of the customer database
    Dim db As New ClassCustomersDB
    Dim valid As New ClassFormValidation
    Dim format As New ClassFormat

    'declare customer id
    Dim mintID As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'redirect if not login
        If Session("CustID") Is Nothing Then
            Response.Redirect("Login.aspx?lp=ChangePassword")
        End If

        'get customer id
        mintID = Session("CustID")

        'reset error message
        lblError.Text = ""
    End Sub

    Protected Sub btnSavePassword_Click(sender As Object, e As EventArgs) Handles btnSavePassword.Click
        'check old password
        valid.CheckChangePassword(mintID, txtCurrentPassword.Text, txtNewPassword.Text, txtPasswordAgain.Text, "Invalid current password", "Password cannot be blank", "New password not match")

        'check if any error
        If valid.IsValid = False Then
            'display error message and exit sub
            lblError.Text = valid.ErrorMessage
            Exit Sub
        End If

        'show confirm button, disable save
        ToggleButtonTextboxes(True)
    End Sub

    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        'change password
        db.UpdatePassword(txtNewPassword.Text, mintID)

        'hide confirm button, enable save
        ToggleButtonTextboxes(False)
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'hide confirm button, enable save
        ToggleButtonTextboxes(False)
    End Sub

    Protected Sub ToggleButtonTextboxes(bolShowConfirm As Boolean)
        'set bolShowConfirm to true to show panel, disable save button and textboxes. set to false otherwise
        pnlConfirmChange.Visible = bolShowConfirm
        btnSavePassword.Enabled = Not (bolShowConfirm)
        txtCurrentPassword.Enabled = Not (bolShowConfirm)
        txtNewPassword.Enabled = Not (bolShowConfirm)
        txtPasswordAgain.Enabled = Not (bolShowConfirm)
    End Sub
End Class