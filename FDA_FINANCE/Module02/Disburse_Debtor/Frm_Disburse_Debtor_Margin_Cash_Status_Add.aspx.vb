﻿Public Class Frm_Disburse_Debtor_Margin_Cash_Status_Add
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
            'UC_Disburse_Debtor_Margin_Cash_Status_detail1.set_date()
            If Request.QueryString("bid") IsNot Nothing Then
                Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL
                dao.Getdata_by_DEBTOR_BILL_ID(Request.QueryString("bid"))
                UC_Disburse_Debtor_Margin_Cash_Status_detail1.getdata(dao)

            End If
        End If
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL()
        dao.Getdata_by_DEBTOR_BILL_ID(Request.QueryString("bid"))
        Dim dao_head As New DAO_DISBURSE.TB_DEBTOR_BILL
        dao_head.Getdata_by_DEBTOR_BILL_ID(Request.QueryString("bid"))
        UC_Disburse_Debtor_Margin_Cash_Status_detail1.insert(dao)
        Dim log As New log_event.log
        log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                       Request.Url.AbsoluteUri.ToString(), "บันทึกสถานะสัญญาเงินยืม(เงินทดรอง)เลขที่หนังสือ " & _
                       dao_head.fields.DOC_NUMBER, "DEBTOR_BILL_MARGIN_DETAIL", Request.QueryString("bid"))
        dao.update()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
End Class