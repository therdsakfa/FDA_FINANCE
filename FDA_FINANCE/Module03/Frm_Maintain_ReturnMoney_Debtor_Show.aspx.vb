﻿Public Class Frm_Maintain_ReturnMoney_Debtor_Show
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
        If Not IsPostBack Then
            Dim dao_disburse_debtor As New DAO_DISBURSE.TB_DEBTOR_BILL
            dao_disburse_debtor.Getdata_by_DEBTOR_BILL_ID(Request.QueryString("DEBTOR_BILL_ID"))
            'UC_Maintain_ReturnMoney_Debtor_Information1.getdata(dao_disburse_debtor)
        End If
    End Sub

    Private Sub Frm_Maintain_ReturnMoney_Debtor_Show_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Maintain_ReturnMoney1.bindseq()
    End Sub
End Class