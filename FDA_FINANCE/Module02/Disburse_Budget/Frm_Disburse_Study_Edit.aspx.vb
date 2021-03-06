﻿Public Class Frm_Disburse_Study_Edit
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
        Dim bgYear As Integer = Request.QueryString("mYear")
        UC_Disburse_Cure_Study_Detail1.BudgetYear = bgYear
        UC_Disburse_Cure_Study_Detail1.BillType = 2
        UC_Disburse_Cure_Study_Detail1.is_insert = True
        If Not IsPostBack Then
            Dim dao_head As New DAO_DISBURSE.TB_CURE_STUDY
            If Request.QueryString("bid") IsNot Nothing Then

                dao_head.Getdata_by_CURE_STUDY_ID(CInt(Request.QueryString("bid")))
                UC_Disburse_Cure_Study_Detail1.getdata(dao_head)

            End If
        End If
    End Sub

    Private Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        Dim dao_disburse_bill As New DAO_DISBURSE.TB_CURE_STUDY
        Dim ad As String = NameUserAD()
        If Request.QueryString("bid") IsNot Nothing Then

            dao_disburse_bill.Getdata_by_CURE_STUDY_ID(CInt(Request.QueryString("bid")))
            UC_Disburse_Cure_Study_Detail1.update(dao_disburse_bill, ad)
            dao_disburse_bill.update()
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "แก้ไขใบเบิกจ่ายค่าเล่าเรียนเลขที่หนังสือ " & _
                           dao_disburse_bill.fields.DOC_NUMBER, "CURE_STUDY", Request.QueryString("bid"))
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If
    End Sub
End Class