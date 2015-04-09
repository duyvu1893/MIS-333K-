Public Class SearchSong
    Inherits System.Web.UI.Page
    Dim DB As New ClassSongDB

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            DB.GetAllGenre()
            DB.CustView.Sort = "genre"
            cblGenre.DataSource = DB.CustView()
            cblGenre.DataTextField = "genre"
            cblGenre.DataBind()
            cblGenre.Items.Insert(0, "Select All")
        End If
    End Sub

    Protected Sub cblGenre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cblGenre.SelectedIndexChanged
      


        'For i = 1 To cblGenre.Items.Count - 1
        '    If Me.cblGenre.Items.Item(i).Selected = False Then
        '        cblGenre.Items.Item(0).Selected = False
        '    End If
        'Next i

        If cblGenre.SelectedValue = "Select All" Then
            For i = 1 To cblGenre.Items.Count - 1
                Me.cblGenre.Items.Item(i).Selected = True
            Next i
        End If

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        DB.GetAllSongs()
        gvSongsResult.DataSource = DB.CustView
        gvSongsResult.DataBind()
        lblReordsCount.Text = CStr(DB.CustView.Count)

    End Sub
End Class