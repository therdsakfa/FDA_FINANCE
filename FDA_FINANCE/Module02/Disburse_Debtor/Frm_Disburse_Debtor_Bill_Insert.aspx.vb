Public Class Frm_Disburse_Debtor_Bill_Insert
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
        Dim bgyear As String = Request.QueryString("bgyear")

        Dim dept_id As Integer = 0 'o_user.get_dept(NameUserAD())

        UC_Disburse_Debtor_Detail1.BudgetYear = bgyear

        If Request.QueryString("dept") IsNot Nothing Then
            UC_Disburse_Debtor_Detail1.dept = Request.QueryString("dept")
        Else
            UC_Disburse_Debtor_Detail1.dept = dept_id
        End If

        If Request.QueryString("flag") IsNot Nothing Then
            UC_Disburse_Debtor_Detail1.bg_use = 2
            UC_Disburse_Debtor_Detail1.dept = 23
        Else
            UC_Disburse_Debtor_Detail1.bg_use = 1
        End If

        UC_Disburse_Debtor_Detail1.is_insert = True
        If Not IsPostBack Then
            UC_Disburse_Debtor_Detail1.set_date()
            UC_Disburse_Debtor_Detail1.bind_cus()
            UC_Disburse_Debtor_Detail1.bind_dd_gl()
        End If

    End Sub

    Private Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        Dim bool As Boolean = UC_Disburse_Debtor_Detail1.chk_document()
        If bool = False Then
            Dim ad As String = NameUserAD()
            Dim dao_head As New DAO_DISBURSE.TB_DEBTOR_BILL
            UC_Disburse_Debtor_Detail1.insert(dao_head, ad)
            If Request.QueryString("flag") IsNot Nothing Then
                dao_head.fields.BUDGET_USE_ID = 2
                dao_head.fields.DEPARTMENT_ID = 23
            End If
            dao_head.insert()

            Dim id_head As Integer = dao_head.fields.DEBTOR_BILL_ID
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "บันทึกสัญญาเงินยืมเลขที่หนังสือ " & _
                           dao_head.fields.DOC_NUMBER, "DEBTOR_BILL", dao_head.fields.DEBTOR_BILL_ID)

            Dim dao_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
            UC_Disburse_Debtor_Detail1.insert_detail(dao_detail, id_head)
            dao_detail.insert()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย') ; parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)

        Else
            Dim ad As String = NameUserAD()
            Dim dao_head As New DAO_DISBURSE.TB_DEBTOR_BILL
            UC_Disburse_Debtor_Detail1.insert(dao_head, ad)
            If Request.QueryString("flag") IsNot Nothing Then
                dao_head.fields.BUDGET_USE_ID = 2
                dao_head.fields.DEPARTMENT_ID = 23
            End If
            dao_head.insert()

            Dim id_head As Integer = dao_head.fields.DEBTOR_BILL_ID
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "บันทึกสัญญาเงินยืมเลขที่หนังสือ " & _
                           dao_head.fields.DOC_NUMBER, "DEBTOR_BILL", dao_head.fields.DEBTOR_BILL_ID)
            Dim dao_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
            UC_Disburse_Debtor_Detail1.insert_detail(dao_detail, id_head)
            dao_detail.insert()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('คำเตือน มีการกรอกเลขเอกสารซ้ำ แต่ท่านยังสามารถบันทึกข้อมูลเข้าสู่ระบบได้ตามปกติ'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If
    End Sub
End Class