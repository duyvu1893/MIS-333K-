Imports System.Data
Imports System.Data.SqlClient

Public Class MyMusic
    Inherits System.Web.UI.Page

    'instantiate objects
    Dim db As New ClassCustomersDB
    Private Sub ShowView()
        'sort view
        'db.Sort(radSort.SelectedValue)

        'bind customers in view to grid
        gvCustomers.DataSource = db.CustView
        gvCustomers.DataBind()
        gvCustomers.UseAccessibleHeader = True
        gvCustomers.HeaderRow.TableSection = TableRowSection.TableHeader

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'redirect to login if not logged in
        ' If Session("Employee") Is Nothing Then
        'Response.Redirect("Login.aspx")
        'End If

        'get customers data
        db.GetAllCustomers()

        'first time page loads
        If IsPostBack = False Then
            'show customers in view
            ShowView()
        End If
    End Sub

End Class

