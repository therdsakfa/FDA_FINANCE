Imports Telerik.Web.UI
Public Class UC_Disburse_Debtor_Rebill_Add
    Inherits System.Web.UI.UserControl
    Private _BudgetID As Integer
    Public Property BudgetID() As Integer
        Get
            Return _BudgetID
        End Get
        Set(ByVal value As Integer)
            _BudgetID = value
        End Set
    End Property

    Private _bgyear As Integer
    Public Property bgyear() As Integer
        Get
            Return _bgyear
        End Get
        Set(ByVal value As Integer)
            _bgyear = value
        End Set
    End Property
    Private _bt As Integer
    Public Property bt() As Integer
        Get
            Return _bt
        End Get
        Set(ByVal value As Integer)
            _bt = value
        End Set
    End Property
    Private _stat As Integer
    Public Property stat() As Integer
        Get
            Return _stat
        End Get
        Set(ByVal value As Integer)
            _stat = value
        End Set
    End Property
    Private _g As Integer
    Public Property g() As Integer
        Get
            Return _g
        End Get
        Set(ByVal value As Integer)
            _g = value
        End Set
    End Property
    Private _CLS As New CLS_SESSION

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    Private Sub rgAddRebill_Init(sender As Object, e As EventArgs) Handles rgAddRebill.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgAddRebill
        Rad_Utility.addColumnCheckbox_client("chkColumn", "")
        Rad_Utility.addColumnBound("DEBTOR_BILL_ID", "DEBTOR_BILL_ID", False)
        Rad_Utility.addColumnBound("BUDGET_PLAN_ID", "BUDGET_PLAN_ID", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขหนังสือ")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", width:=120)
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินยืม", width:=120, is_money:=True)
        'Rad_Utility.addColumnButton("A", "เบิก", "A", 0, "")
    End Sub

    Private Sub rgAddRebill_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgAddRebill.ItemCommand

    End Sub

    Private Sub rgAddRebill_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgAddRebill.NeedDataSource
        Dim bao As New BAO_BUDGET.Budget
        rgAddRebill.DataSource = bao.get_debtor_rebill(bgyear, 1)
    End Sub
    Public Sub insert()
        For Each item As GridDataItem In rgAddRebill.SelectedItems
            Dim dao_debt_head As New DAO_DISBURSE.TB_DEBTOR_BILL
            Dim dao_deb_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL


            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL

            dao_debt_head.Getdata_by_DEBTOR_BILL_ID(CInt(item("DEBTOR_BILL_ID").Text))
            dao_deb_detail.Getdata_by_DEBTOR_BILL_ID(CInt(item("DEBTOR_BILL_ID").Text))

            dao.fields.IS_APPROVE = True
            dao.fields.APPROVE_DATE = CDate(System.DateTime.Now)
            dao.fields.BUDGET_YEAR = dao_debt_head.fields.BUDGET_YEAR
            dao.fields.BUDGET_PLAN_ID = dao_debt_head.fields.BUDGET_PLAN_ID
            dao.fields.Bill_RECIEVE_DATE = dao_debt_head.fields.Bill_RECIEVE_DATE
            dao.fields.DOC_NUMBER = dao_debt_head.fields.DOC_NUMBER
            dao.fields.DOC_DATE = dao_debt_head.fields.DOC_DATE
            dao.fields.BILL_NUMBER = dao_debt_head.fields.BILL_NUMBER
            dao.fields.BILL_DATE = dao_debt_head.fields.BILL_DATE
            dao.fields.DESCRIPTION = "วางเบิกลูกหนี้ " & dao_debt_head.fields.BILL_NUMBER & "/" & Right(dao_debt_head.fields.BUDGET_YEAR, 2) & " " & dao_debt_head.fields.DESCRIPTION
            dao.fields.PATLIST_ID = dao_debt_head.fields.PAYLIST_ID
            dao.fields.IS_DEPARTMENT = False
            dao.fields.CUSTOMER_TYPE_ID = 3
            dao.fields.CUSTOMER_ID = 1137
            dao.fields.BUDGET_USE_ID = dao_debt_head.fields.BUDGET_USE_ID
            dao.fields.GFMIS_NUMBER = ""
            dao.fields.GFMIS_DATE = Nothing
            dao.fields.INVOICES_DATE = Nothing
            dao.fields.INVOICES_NUMBER = ""
            dao.fields.RECEIPT_NUMBER = ""
            dao.fields.RECEIPT_DATE = Nothing
            dao.fields.RETURN_APPROVE_DATE = Nothing
            dao.fields.RETURN_APPROVE_NUMBER = ""
            dao.fields.DEPARTMENT_ID = dao_debt_head.fields.DEPARTMENT_ID
            dao.fields.DEBTOR_ID = dao_debt_head.fields.DEBTOR_BILL_ID
            dao.fields.CHECK_APPROVE = False
            dao.fields.IS_CHECK_RECEIVE = False
            dao.fields.PAY_TYPE_ID = 2
            dao.fields.MAX_PRIZE = dao_deb_detail.fields.AMOUNT
            dao.fields.STATUS_ID = 1
            dao.fields.GROUP_ID = 3

            dao.insert()
            Dim log As New log_event.log
            log.insert_log("", System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลใบเบิกจ่าย(วางเบิก)เลขที่หนังสือ " & _
                           dao.fields.DOC_NUMBER, "BUDGET_BILL", dao.fields.BUDGET_DISBURSE_BILL_ID)

            dao_detail.fields.BUDGET_DISBURSE_BILL_ID = dao.fields.BUDGET_DISBURSE_BILL_ID
            dao_detail.fields.AMOUNT = dao_deb_detail.fields.AMOUNT
            dao_detail.fields.TAX_AMOUNT = dao_deb_detail.fields.TAX_AMOUNT
            dao_detail.fields.IS_ENABLE = True
            dao_detail.fields.GL_ID = dao_deb_detail.fields.GL_ID
            dao_detail.fields.BUDGET_PLAN_ID = dao_deb_detail.fields.BUDGET_PLAN_ID
            dao_detail.fields.CUSTOMER_ID = 1137
            dao_detail.insert()

            Dim dao_bill_main As New DAO_DISBURSE.TB_BUDGET_BILL
            dao_bill_main.Getdata_by_BUDGET_DISBURSE_BILL_ID(dao.fields.BUDGET_DISBURSE_BILL_ID)
            dao_bill_main.fields.MAIN_BILL = dao.fields.BUDGET_DISBURSE_BILL_ID
            dao_bill_main.update()


            Dim dao_app As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            '--------------------เบิก------------------------
            dao_app.fields.BILL_TYPE = bt
            '------------------------------------------------
            dao_app.fields.DATE_ADD = Date.Now
            dao_app.fields.FK_IDA = item("DEBTOR_BILL_ID").Text
            dao_app.fields.IDENTITY_NUMBER = _CLS.CITIZEN_ID_AUTHORIZE
            dao_app.fields.REASON_DATE = Date.Now
            dao_app.fields.STATUS_ID = 1
            dao_app.fields.GROUP_ID = 3

            dao_app.insert()
        Next

        
    End Sub

End Class