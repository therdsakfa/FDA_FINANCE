﻿Public Class Frm_Maintain_ReceiveMoney
    Inherits System.Web.UI.Page
    Public bgYear As Integer
    Private _dept As Integer
    Private _bgid As Integer
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Sub runQuery()
        _dept = Request.QueryString("dept")
        _bgid = Request.QueryString("bgid")
        bgYear = Request.QueryString("myear")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
        'bgYear = Request.QueryString("myear")
        'UC_Maintain_ReceiveMoney_Information1.BudgetYear = bgYear
        UC_Maintain_ReceiveMoney1.BudgetYear = bgYear
        '  UC_Maintain_ReceiveMoney.rebindRg()
    End Sub


    Private Sub Frm_Maintain_ReceiveMoney_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        ' UC_Maintain_ReceiveMoney.bindseq()
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Maintain_ReceiveMoney1.rebindRg()
    End Sub
End Class