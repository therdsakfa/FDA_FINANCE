﻿Public Class Frm_Return_Description
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
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
    End Sub

    Private Sub Frm_Return_Description_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Return_Description1.bindseq()
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Return_Description1.rg_rebind()
    End Sub
End Class