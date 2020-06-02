Public Class Frm_Disburse_PO_Detail_List_Insert2
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
            Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
            Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
            If Request.QueryString("bid") IsNot Nothing Then
                Dim id As String = Request.QueryString("bid")

                dao_head.Getdata_by_BUDGET_DISBURSE_BILL_ID(id)
                UC_Disburse_Budget_DetailV21.get_data(dao_head)
            End If
            '  UC_Disburse_PO_Detail_Table21.bind_ddl_period()
        End If
    End Sub

    Private Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click

        Dim dao_head_po As New DAO_DISBURSE.TB_BUDGET_BILL
        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
        Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL

        dao_head_po.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))

        UC_Disburse_Budget_DetailV21.set_data(dao)
        dao.fields.IS_PO = True
        dao.fields.BUDGET_USE_ID = dao_head_po.fields.BUDGET_USE_ID
        dao.fields.PO_HEAD_ID = Request.QueryString("bid")
        dao.fields.BUDGET_YEAR = Request.QueryString("bgYear")
        dao.fields.DEPARTMENT_ID = Request.QueryString("dept")
        dao.fields.STATUS_ID = 1
        dao.fields.GROUP_ID = 0
        dao.fields.PAY_TYPE_ID = 1
        dao.fields.BUDGET_PLAN_ID = 0
        dao.fields.BILL_NUMBER = ""
        dao.insert()


        Dim dao2 As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
        dao2.fields.STATUS_ID = 1
        dao2.fields.GROUP_ID = 0
        dao2.fields.BILL_TYPE = 2
        dao2.fields.REASON_DATE = Date.Now
        dao2.fields.IDENTITY_NUMBER = _CLS.CITIZEN_ID
        dao2.fields.DATE_ADD = Date.Now
        dao2.fields.FK_IDA = dao.fields.BUDGET_DISBURSE_BILL_ID
        dao2.insert()

        Dim bill_id As Integer
        bill_id = dao.fields.BUDGET_DISBURSE_BILL_ID
        UC_Disburse_PO_Detail_Table21.insert(bill_id)

        Dim dao_bill_main As New DAO_DISBURSE.TB_BUDGET_BILL
        dao_bill_main.Getdata_by_BUDGET_DISBURSE_BILL_ID(bill_id)
        dao_bill_main.fields.MAIN_BILL = bill_id
        dao_bill_main.update()

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)

    End Sub
End Class