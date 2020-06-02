Public Class Frm_Disburse_OutsideBudget_Bill_Edit1
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
        UC_Disburse_Budget_Detail1.is_insert = True
        If Not IsPostBack Then
            'UC_Disburse_Budget_Detail1.set_date()

            Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
            Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
            If Request.QueryString("bid") <> "" Then
                UC_Disburse_Budget_Detail1.bind_cus()
                UC_Disburse_Budget_Detail1.bind_dd_gl()
                dao_head.Getdata_by_BUDGET_DISBURSE_BILL_ID(CInt(Request.QueryString("bid")))
                UC_Disburse_Budget_Detail1.getdata_head(dao_head)
                dao_detail.Getdata_by_Disburse_id(CInt(Request.QueryString("bid")))
                UC_Disburse_Budget_Detail1.getdata_detail(dao_detail)

            End If
            UC_Disburse_Budget_Detail1.is_insert = True
        End If
    End Sub

    Private Sub btn_bill_edit_Click(sender As Object, e As EventArgs) Handles btn_bill_edit.Click
        Dim dao_disburse_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        Dim bao As New BAO_BUDGET.Budget
        If Request.QueryString("bid") IsNot Nothing Then
            If Request.QueryString("bid") <> "sup" Then
                dao_disburse_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(CInt(Request.QueryString("bid")))
                UC_Disburse_Budget_Detail1.update(dao_disburse_bill)
                dao_disburse_bill.update()
                dao_detail.Getdata_by_Disburse_id(CInt(Request.QueryString("bid")))
                UC_Disburse_Budget_Detail1.update_detail(dao_detail)
                dao_detail.update()

                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "แก้ไขใบเบิกจ่ายนอกงบประมาณเลขที่หนังสือ " & dao_disburse_bill.fields.DOC_NUMBER, _
                               "BUDGET_BILL", Request.QueryString("bid"))
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
            End If
            'Response.Redirect("Frm_Disburse_Budget.aspx")
        End If

    End Sub
End Class