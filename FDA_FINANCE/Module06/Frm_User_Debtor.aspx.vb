﻿Public Class Frm_User_Debtor
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        'Try
        '    _CLS = Session("CLS")
        'Catch ex As Exception
        '    Response.Redirect("http://privus.fda.moph.go.th/")
        'End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        Try
            Dim arrLink As String() = Request.Url.Segments
            Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
            Dim uti As New Utility_other
            Page.Title = uti.get_title_name(apsx_name)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_User_Debtor1.rg_rebind()
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim str As String
        str = UC_Search_User_Debtor1.getSearchMsg()
        UC_User_Debtor1.rgFilter(str)
    End Sub
End Class