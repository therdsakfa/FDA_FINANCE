Public Class Frm_Disburse_OutsideDebtor_Bill_Insert
    Inherits System.Web.UI.Page
    Public bgYear As Integer
    Private _dept As Integer
    Private _bgid As Integer
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Sub runQuery()
        _dept = Request.QueryString("dept")
        _bgid = Request.QueryString("bgid")
        bgYear = Request.QueryString("bgyear")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()
        'Dim dept_id As Integer = bao_user.get_dept(NameUserAD())
        UC_Disburse_Debtor_Detail1.BudgetYear = bgyear
        'If Request.QueryString("dept") IsNot Nothing Then
        UC_Disburse_Debtor_Detail1.dept = _dept
        

        'Else
        '    UC_Disburse_Debtor_Detail1.dept = bao_user.get_dept(NameUserAD())

        'End If

        UC_Disburse_Debtor_Detail1.bg_use = 3
        UC_Disburse_Debtor_Detail1.is_insert = True
        If Not IsPostBack Then
            UC_Disburse_Debtor_Detail1.bind_cus()
            UC_Disburse_Debtor_Detail1.bind_dd_gl()
        End If
    End Sub

    Private Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        Dim ad As String = NameUserAD()
        Dim dao_head As New DAO_DISBURSE.TB_DEBTOR_BILL
        UC_Disburse_Debtor_Detail1.insert(dao_head, ad)
        dao_head.fields.IS_APPROVE = True
        dao_head.fields.APPROVE_DATE = Date.Now
        dao_head.insert()
        Dim log As New log_event.log
        log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                       Request.Url.AbsoluteUri.ToString(), "บันทึกสัญญาเงินยืมเลขที่หนังสือ " & _
                       dao_head.fields.DOC_NUMBER, "DEBTOR_BILL", dao_head.fields.DEBTOR_BILL_ID)

        Dim id_head As Integer = dao_head.fields.DEBTOR_BILL_ID
        Dim dao_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
        UC_Disburse_Debtor_Detail1.insert_detail(dao_detail, id_head)
        dao_detail.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub

End Class