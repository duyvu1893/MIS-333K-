Option Strict On

Public Class LonghornMusic
    Inherits System.Web.UI.MasterPage

    Dim db As New ClassCustomersDB

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'when user logged in as customer
        If Not (Session("CustID") Is Nothing) Then
            'show customer menu, hide the other menu
            pnlBeforeLogin.Attributes("class") = "dropdown-menu sr-only"
            pnlLoggedinCustomer.Attributes("class") = "dropdown-menu"

            'change myaccount text to customer name
            db.GetCustomerWithID(CInt(Session("CustID")))
            lblMyAccount.Text = db.CustDataset.Tables("tblCustomers").Rows(0).Item("First Name").ToString

            'show cart count
            lblCartCount.Text = "Show cart count here when logged in"
        End If

        ''highlight selected page
        ''declare variables
        'Dim strPageName As String
        ''get page name
        'strPageName = Request.Url.AbsolutePath.Substring(1).ToLower
        'strPageName = strPageName.Substring(0, strPageName.Length - 5)
        ''highlight page based on page name
        'Select Case strPageName
        '    Case "index"
        '        lnkIndex.Attributes("class") = "active"
        '    Case "searchsong"
        '        lnkSearchSong.Attributes("class") = "active"
        'End Select
    End Sub

    Private Sub lnkLogout_Click(sender As Object, e As EventArgs) Handles lnkLogout.Click
        'log user out = remove session variable + redirect
        Session.Remove("CustID")
        Response.Redirect("Index.aspx")
    End Sub
End Class