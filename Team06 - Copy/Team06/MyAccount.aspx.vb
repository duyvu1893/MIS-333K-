Public Class MyAccount
    Inherits System.Web.UI.Page

    Dim db As New ClassCustomersDB

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim intID As Integer
        Dim drCustomer As DataRow
        intID = 10001

        db.GetCustomerWithID(intID)
        drCustomer = db.CustDataset.Tables("tblCustomers").Rows(0)

        txtEmail.Text = drCustomer.Item("Email")
        txtLastname.Text = drCustomer.Item("Last Name")
        txtFirstname.Text = drCustomer.Item("First Name")
        txtAddress.Text = drCustomer.Item("Address")
        txtPhone.Text = drCustomer.Item("Phone")
        TxtCity.Text = drCustomer.Item("City")
        txtState.Text = drCustomer.Item("State")
        txtZipCode.Text = drCustomer.Item("Zip Code")
    End Sub

End Class