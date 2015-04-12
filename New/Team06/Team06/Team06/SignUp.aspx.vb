Public Class SignUp
    Inherits System.Web.UI.Page

    'define instance of classes
    Dim db As New ClassCustomersDB
    Dim valid As New ClassFormValidation

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'clear error messages
        lblError.Text = ""
    End Sub
   
    Protected Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        'declare variable
        Dim intNewAccount As Integer

        'check email
        valid.CheckEmail(txtEmail.Text, "Invalid email")

        'check phone number
        valid.CheckPhone(txtPhone.Text, "Invalid phone number")

        'check zip code
        valid.CheckZip(txtZipCode.Text, "Invalid zip code")

        'check require field
        valid.CheckFirstName(txtFirstname.Text, "First name required")
        valid.CheckLastName(txtLastname.Text, "Last name required")
        valid.CheckAddress(txtAddress.Text, "Address required")

        'check new password
        valid.CheckNewPasswordMatchRepeatPassword(txtPassword.Text, txtPasswordAgain.Text, "Password cannot be blank", "Password not match")

        'if any error
        If valid.IsValid = False Then
            'show messages and exit sub
            lblError.Text = valid.ErrorMessage
            Exit Sub
        End If

        'get new account id
        intNewAccount = db.GetNewAccountID

        'add customer to database
        db.AddCustomer(txtEmail.Text, txtLastname.Text, txtMiddlename.Text, txtFirstname.Text, txtAddress.Text, txtZipCode.Text, txtPhone.Text, txtPassword.Text, intNewAccount)

        'log customer in
        Session("CustID") = intNewAccount

        'redirect customer to index
        Response.Redirect("index.aspx")
    End Sub
End Class