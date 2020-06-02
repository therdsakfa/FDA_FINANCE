﻿Public Class Frm_Maintain_ReturnMoney_Debtor_OutsideBudget_Edit
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
            Dim bao As New BAO_BUDGET.Maintain
            Dim dt As DataTable = bao.get_DEBTOR_BILL_out_BUDGET_by_DEBTOR_BILL_ID(Request.QueryString("DEBTOR_BILL_ID"))
            UC_Maintain_ReturnMoney_OutsideBudget_Debtor_Information1.getdata(dt)
            UC_Maintain_ReturnMoney_OutsideBudget_Detail.getdata(bao)
        End If
    End Sub

    Protected Sub btn_Edit_Click(sender As Object, e As EventArgs) Handles btn_Edit.Click
        Dim qstr_RETURN_MONEY_DEBTOR_ID As Integer
        Dim dao_return_money_debtor As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
        If Request.QueryString("DEBTOR_BILL_ID") IsNot Nothing Then
            qstr_RETURN_MONEY_DEBTOR_ID = Request.QueryString("DEBTOR_BILL_ID").ToString()
            dao_return_money_debtor.Getdata_by_DEBTOR_ID(qstr_RETURN_MONEY_DEBTOR_ID)
            UC_Maintain_ReturnMoney_OutsideBudget_Detail.insert(dao_return_money_debtor)
            dao_return_money_debtor.update()
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "แก้ไขข้อมูลการคืนเงินลูกหนี้เงินยืม(เงินนอก)", _
                           "RETURN_MONEY_DEBTOR", Request.QueryString("DEBTOR_BILL_ID"))
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
            ' System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('แก้ไขข้อมูลเรียบร้อยแล้ว');window.location.href = 'Frm_Maintain_ReturnMoney_Debtor_OutsideBudget.aspx';", True)
        End If
        'Response.Redirect("Frm_Maintain_ReturnMoney_Debtor_OutsideBudget.aspx")
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        ' Response.Redirect("Frm_Maintain_ReturnMoney_Debtor_OutsideBudget.aspx")
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
End Class