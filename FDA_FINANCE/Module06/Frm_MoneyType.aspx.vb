﻿Public Class Frm_MoneyType
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
        Dim temp As Integer = UC_MoneyType1.nodeId
        'UC_MoneyType_Information1.bg_ID = temp
        UC_MoneyType1.bgyear = Request.QueryString("myear")
    End Sub

    Protected Sub lbt_new_bg_Click(sender As Object, e As EventArgs) Handles lbt_new_bg.Click
        'Response.Redirect("Frm_MoneyType_Insert.aspx?typeid=1")
    End Sub
    Public Sub bind_inf()
        'UC_MoneyType_Information1.BindDt(UC_MoneyType1.getChild())
        'UC_MoneyType_Level1.bindTxtbox(UC_MoneyType1.getPlanBack())
    End Sub

    Private Sub Frm_MoneyType_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'UC_MoneyType_Information1.bindseq()
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_MoneyType1.rt_rebind()
        'UC_MoneyType_Information1.rg_rebind()
    End Sub
End Class