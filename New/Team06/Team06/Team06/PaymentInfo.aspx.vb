Public Class WebForm1
    Inherits System.Web.UI.Page

    Dim db As New ClassCustomersDB

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim intID As Integer
        Dim strCreditCard1 As String
        Dim strCreditCard2 As String


        intID = 10039
        db.GetCustomerWithID(intID)

        strCreditCard1 = db.CustDataset.Tables("tblCustomers").Rows(0).Item("Credit Card 1").ToString
        strCreditCard2 = db.CustDataset.Tables("tblCustomers").Rows(0).Item("Credit Card 2").ToString

        If strCreditCard1 <> "" Then
            lblCreditCardEnding1.Text = strCreditCard1
        Else
            lblCreditCardEnding1.Text = "N/A"
        End If

        If strCreditCard2 <> "" Then
            lblCreditCardEnding2.Text = strCreditCard2
        Else
            lblCreditCardEnding2.Text = "N/A"
        End If
    End Sub

End Class