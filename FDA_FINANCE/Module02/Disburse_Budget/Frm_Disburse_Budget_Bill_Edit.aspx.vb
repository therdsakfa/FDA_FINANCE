Public Partial Class Frm_Disburse_Budget_Bill_Edit
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

        Dim dept_id As Integer = 0 'bao_user.get_dept(NameUserAD())
        UC_Disburse_Budget_Detail1.is_insert = True
        Dim dao_b As New DAO_DISBURSE.TB_BUDGET_BILL
        dao_b.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
        Try
            UC_Disburse_Budget_Detail1.dept_id = dao_b.fields.DEPARTMENT_ID
        Catch ex As Exception
            UC_Disburse_Budget_Detail1.dept_id = 0
        End Try
        UC_Disburse_Budget_Detail1.bind_cus()
        If Not IsPostBack Then
            'UC_Disburse_Budget_Detail1.set_date()
            UC_Disburse_Budget_Detail1.bind_dd_gl()
            Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
            Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
            If Request.QueryString("bid") IsNot Nothing Then
                If Request.QueryString("bid") <> "sup" Or Request.QueryString("bid") <> "out" Then
                    dao_head.Getdata_by_BUDGET_DISBURSE_BILL_ID(CInt(Request.QueryString("bid")))
                    UC_Disburse_Budget_Detail1.getdata_head(dao_head)
                    dao_detail.Getdata_by_Disburse_id(CInt(Request.QueryString("bid")))
                    UC_Disburse_Budget_Detail1.getdata_detail(dao_detail)

                    Dim dao_h As New DAO_DISBURSE.TB_CURE_STUDY
                    dao_h.Getdata_by_bill_id(Request.QueryString("bid"))
                    'UC_Disburse_Budget_Detail1.getdata_home(dao_h)
                    'Dim dao_h As New DAO_DISBURSE.
                End If

            End If
        End If
    End Sub

    Private Sub btn_bill_edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_bill_edit.Click
        Dim dao_disburse_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        Dim bao As New BAO_BUDGET.Budget
        If Request.QueryString("bid") IsNot Nothing Then
            If Request.QueryString("bid") <> "sup" Then
                dao_disburse_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(CInt(Request.QueryString("bid")))
                UC_Disburse_Budget_Detail1.update(dao_disburse_bill)
                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "แก้ไขข้อมูลใบเบิกจ่ายเลขที่หนังสือ " & dao_disburse_bill.fields.DOC_NUMBER, "BUDGET_BILL", Request.QueryString("bid"))
                dao_disburse_bill.update()
                dao_detail.Getdata_by_Disburse_id(CInt(Request.QueryString("bid")))
                UC_Disburse_Budget_Detail1.update_detail(dao_detail)
                dao_detail.update()

                Try
                    Dim dao_h As New DAO_DISBURSE.TB_CURE_STUDY
                    dao_h.Getdata_by_bill_id(Request.QueryString("bid"))
                    'UC_Disburse_Budget_Detail1.update_home(dao_h)
                    dao_h.update()
                Catch ex As Exception

                End Try

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขเรียบร้อย') ; parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
            End If
            'Response.Redirect("Frm_Disburse_Budget.aspx")
        End If

    End Sub

End Class