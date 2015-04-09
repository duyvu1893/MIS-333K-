﻿Public Class SearchArtist
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

End Class