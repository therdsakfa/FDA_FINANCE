﻿Public Class Frm_Budget_Transfer_Receive_User
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
        UC_Budget_Transfer_Receive1.bgyear = bgYear
        UC_Budget_Transfer_Receive1.dept_id = _dept
        UC_Budget_Transfer_Receive1.user = "1"
    End Sub
    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Budget_Transfer_Receive1.rg_rebind()
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim strMsg As String = ""
        strMsg = UC_Budget_Search_Form1.getSearchMsg()
        UC_Budget_Transfer_Receive1.rgFilter(strMsg)
    End Sub
End Class