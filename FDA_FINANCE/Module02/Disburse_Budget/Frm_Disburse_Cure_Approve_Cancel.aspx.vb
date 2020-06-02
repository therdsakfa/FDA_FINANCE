﻿Public Class Frm_Disburse_Cure_Approve_Cancel
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
        UC_Disburse_Cure_Approve_Cancel1.BillType = 1
        UC_Disburse_Cure_Approve_Cancel1.bgyear = Request.QueryString("myear")
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_Form1.getSearchMsg()
        UC_Disburse_Cure_Approve_Cancel1.rgFilter(str)
    End Sub

    Private Sub Frm_Disburse_Cure_Approve_Cancel_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Disburse_Cure_Approve_Cancel1.BillType = 1
        UC_Disburse_Cure_Approve_Cancel1.bindseq()
    End Sub
End Class