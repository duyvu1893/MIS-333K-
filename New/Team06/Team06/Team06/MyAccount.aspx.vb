Public Class MyAccount
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
            Response.Redirect("Login.aspx")
        End If

        'get customer id
        mintID = Session("CustID")

        'reset error
        lblError.Text = ""

        'if first time load page
        If IsPostBack = False Then
            'populate customer info
            PopulateFields()

            'Check and fill zip code when user change zip
            'Else
            '    'if on post back, fill city and state of new zip
            '    valid.CheckZip(txtZipCode.Text, "")
            '    If valid.IsValid = True Then
            '        db.GetCityStateByZip(txtZipCode.Text)
            '        txtCity.Text = db.CustDataset.Tables("tblZip").Rows(0).Item("City")
            '        txtState.Text = db.CustDataset.Tables("tblZip").Rows(0).Item("State")
            '    Else
            '        txtCity.Text = ""
            '        txtState.Text = ""
            '    End If
        End If
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
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

        'if any error
        If valid.IsValid = False Then
            'display error and exit sub
            lblError.Text = valid.ErrorMessage
            Exit Sub
        End If

        'update customer info
        db.UpdateCustomer(txtEmail.Text, txtLastname.Text, txtFirstname.Text, txtAddress.Text, txtZipCode.Text, txtPhone.Text, mintID)

        'get customer info
        db.GetCustomerWithID(mintID)

        'populate fields
        PopulateFields()

        'disable textboxes
        ToggleTextboxes(False)

        'hide save/cancel button
        pnlModify.Visible = False

        'show modify button
        btnModify.Enabled = True
    End Sub

    Protected Sub PopulateFields(Optional bolEdit As Boolean = False)
        'declare variables
        Dim drCustomer As DataRow
        'get customer info
        db.GetCustomerWithID(mintID)
        'get customer info
        drCustomer = db.CustDataset.Tables("tblCustomers").Rows(0)

        'fill fields
        txtEmail.Text = drCustomer.Item("Email").ToString
        txtLastname.Text = drCustomer.Item("Last Name").ToString
        txtFirstname.Text = drCustomer.Item("First Name").ToString
        txtAddress.Text = drCustomer.Item("Address").ToString
        txtCity.Text = drCustomer.Item("City").ToString
        txtState.Text = drCustomer.Item("State").ToString
        txtZipCode.Text = drCustomer.Item("Zip Code").ToString

        'if in view mode
        If bolEdit = False Then
            'format phone
            txtPhone.Text = format.FormatPhoneNumber(drCustomer.Item("Phone").ToString)
        Else
            'edit mode, just display number
            txtPhone.Text = drCustomer.Item("Phone").ToString
        End If
    End Sub

    Protected Sub btnCancle_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'repopulate form with data from database
        PopulateFields()

        'disable textboxes
        ToggleTextboxes(False)

        'hide save/cancel button
        pnlModify.Visible = False

        'show modify button
        btnModify.Enabled = True
    End Sub

    Protected Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        'show save/cancel button
        pnlModify.Visible = True

        'enable textboxes
        ToggleTextboxes(True)

        'populate info in edit mode
        PopulateFields(True)

        'hide modify button
        btnModify.Enabled = False
    End Sub

    Protected Sub ToggleTextboxes(bolEnable As Boolean)
        'toggle textboxes
        txtAddress.Enabled = bolEnable
        txtEmail.Enabled = bolEnable
        txtFirstname.Enabled = bolEnable
        txtLastname.Enabled = bolEnable
        txtPhone.Enabled = bolEnable
        txtZipCode.Enabled = bolEnable
    End Sub
End Class