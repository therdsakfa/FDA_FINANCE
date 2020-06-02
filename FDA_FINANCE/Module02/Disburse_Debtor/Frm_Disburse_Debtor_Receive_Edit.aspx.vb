Public Class Frm_Disburse_Debtor_Receive_Edit
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
            UC_Disburse_Debtor_Detail1.set_date_receive()
            UC_Disburse_Debtor_Detail1.bind_dd_gl()
            UC_Disburse_Debtor_Detail1.bind_cus()
            Dim dao_head As New DAO_DISBURSE.TB_DEBTOR_BILL
            Dim dao_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
            If Request.QueryString("bid") IsNot Nothing Then
                If Request.QueryString("bid") <> "sup" Then
                    dao_head.Getdata_by_DEBTOR_BILL_ID(CInt(Request.QueryString("bid")))

                    UC_Disburse_Debtor_Detail1.getdata(dao_head)

                    dao_detail.Getdata_by_DEBTOR_BILL_ID(CInt(Request.QueryString("bid")))
                End If

            End If
        End If
    End Sub

    Private Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        Dim dao_disburse_bill As New DAO_DISBURSE.TB_DEBTOR_BILL
        Dim dao_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
        Dim bao As New BAO_BUDGET.Budget
        If Request.QueryString("bid") IsNot Nothing Then
            If Request.QueryString("bid") <> "sup" Or Request.QueryString("bid") <> "out" Then
                dao_disburse_bill.Getdata_by_DEBTOR_BILL_ID(CInt(Request.QueryString("bid")))
                UC_Disburse_Debtor_Detail1.bg_use = dao_disburse_bill.fields.BUDGET_USE_ID
                UC_Disburse_Debtor_Detail1.BudgetYear = dao_disburse_bill.fields.BUDGET_YEAR
                UC_Disburse_Debtor_Detail1.update(dao_disburse_bill, NameUserAD())
                dao_disburse_bill.update()
                dao_detail.Getdata_by_DEBTOR_BILL_ID(CInt(Request.QueryString("bid")))
                UC_Disburse_Debtor_Detail1.insert_detail(dao_detail, dao_disburse_bill.fields.DEBTOR_BILL_ID)
                dao_detail.update()
                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "บันทึกรับเรื่องลูกหนี้เลขที่หนังสือ " & _
                               dao_disburse_bill.fields.DOC_NUMBER, "DEBTOR_BILL", Request.QueryString("bid"))
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
            End If
            'Response.Redirect("Frm_Disburse_Budget.aspx")
        End If
    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Disburse_Debtor_Detail1.disable_detail()
    End Sub
End Class