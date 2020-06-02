Imports Telerik.Web.UI
Public Class UC_Disburse_Debtor_No_Rebill_Add
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
        Rad_Utility.addColumnBound("RETURN_MONEY_DEBTOR_ID", "RETURN_MONEY_DEBTOR_ID", False)
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_DEBTOR_BILL_ID", "BUDGET_DISBURSE_DEBTOR_BILL_ID", False)
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขบย.")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขหนังสือ")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่หนังสือ")
        Rad_Utility.addColumnBound("RETURN_DESCRIPTION", "รายการ", width:=120)
        Rad_Utility.addColumnBound("RETURN_AMOUNT", "จำนวนเงินในบค.", width:=120, is_money:=True)
    End Sub

    Private Sub rgAddRebill_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgAddRebill.NeedDataSource
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As DataTable = bao.get_debtor_no_rebill_add()
        rgAddRebill.DataSource = dt
    End Sub

    Public Sub insert()
        For Each item As GridDataItem In rgAddRebill.SelectedItems
            Dim dao_debt_head As New DAO_DISBURSE.TB_DEBTOR_BILL
            Dim dao_deb_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
            Dim dao_return As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL

            Dim dao_r As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
            Dim dao_type4 As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
            dao_r.Getdata_by_return_type_3(item("BUDGET_DISBURSE_DEBTOR_BILL_ID").Text)
            dao_type4.Getdata_by_return_type_4(item("BUDGET_DISBURSE_DEBTOR_BILL_ID").Text)
            dao_return.Getdata_by_RETURN_MONEY_DEBTOR_ID(item("RETURN_MONEY_DEBTOR_ID").Text)
            Dim type3_amount As Double = 0
            Dim type4_amount As Double = 0
            If dao_r.fields.RETURN_AMOUNT IsNot Nothing Then
                type3_amount = dao_r.fields.RETURN_AMOUNT
            End If
            If dao_type4.fields.RETURN_AMOUNT IsNot Nothing Then
                type4_amount = dao_type4.fields.RETURN_AMOUNT
            End If


            If dao_return.fields.BUDGET_DISBURSE_DEBTOR_BILL_ID IsNot Nothing Then
                dao_debt_head.Getdata_by_DEBTOR_BILL_ID(dao_return.fields.BUDGET_DISBURSE_DEBTOR_BILL_ID)
                dao_deb_detail.Getdata_by_DEBTOR_BILL_ID(dao_return.fields.BUDGET_DISBURSE_DEBTOR_BILL_ID)

                dao.fields.BUDGET_YEAR = dao_debt_head.fields.BUDGET_YEAR
                dao.fields.BUDGET_PLAN_ID = dao_debt_head.fields.BUDGET_PLAN_ID
                dao.fields.Bill_RECIEVE_DATE = dao_debt_head.fields.Bill_RECIEVE_DATE
                dao.fields.DOC_NUMBER = dao_debt_head.fields.DOC_NUMBER
                dao.fields.DOC_DATE = dao_debt_head.fields.DOC_DATE
                ' dao.fields.BILL_NUMBER = dao_debt_head.fields.BILL_NUMBER
                ' dao.fields.BILL_DATE = dao_debt_head.fields.BILL_DATE
                dao.fields.DESCRIPTION = "โอนชดใช้ใบสำคัญคืนเงิน_บย." & dao_debt_head.fields.BILL_NUMBER & "/" & Right(dao_debt_head.fields.BUDGET_YEAR, 2)
                dao.fields.PATLIST_ID = dao_debt_head.fields.PAYLIST_ID
                dao.fields.IS_APPROVE = False
                dao.fields.IS_DEPARTMENT = False
                dao.fields.CUSTOMER_TYPE_ID = 0
                dao.fields.CUSTOMER_ID = 1137 'เจ้าหนี้เป็นกรมแพทย์เอง
                dao.fields.BUDGET_USE_ID = 1
                dao.fields.GFMIS_NUMBER = ""
                dao.fields.GFMIS_DATE = Nothing
                dao.fields.INVOICES_DATE = Nothing
                dao.fields.INVOICES_NUMBER = ""
                dao.fields.RECEIPT_NUMBER = ""
                dao.fields.RECEIPT_DATE = Nothing
                dao.fields.RETURN_APPROVE_DATE = Nothing
                dao.fields.RETURN_APPROVE_NUMBER = ""
                dao.fields.DEPARTMENT_ID = dao_debt_head.fields.DEPARTMENT_ID
                dao.fields.DEBTOR_ID = 0
                dao.fields.RETURN_MONEY_ID = dao_return.fields.RETURN_MONEY_DEBTOR_ID
                dao.fields.CHECK_APPROVE = False
                dao.fields.IS_CHECK_RECEIVE = False
                dao.fields.PAY_TYPE_ID = 2
                dao.fields.USER_AD = dao_debt_head.fields.USER_AD
                dao.fields.IS_PO = False
                dao.fields.MAX_PRIZE = dao_return.fields.RETURN_AMOUNT + type3_amount - type4_amount
                dao.fields.STATUS_ID = 1
                dao.fields.GROUP_ID = 4

                dao.insert()

                Dim bill_id As Integer
                bill_id = dao.fields.BUDGET_DISBURSE_BILL_ID

                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลใบเบิกจ่าย(ไม่วางเบิก)เลขที่หนังสือ " & _
                               dao.fields.DOC_NUMBER, "BUDGET_BILL", dao.fields.BUDGET_DISBURSE_BILL_ID)

                Dim dao_debt_det As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
                dao_debt_det.Getdata_by_DEBTOR_BILL_ID(dao_return.fields.BUDGET_DISBURSE_DEBTOR_BILL_ID)

                dao_detail.fields.BUDGET_DISBURSE_BILL_ID = dao.fields.BUDGET_DISBURSE_BILL_ID
                dao_detail.fields.AMOUNT = dao_return.fields.RETURN_AMOUNT + type3_amount - type4_amount
                dao_detail.fields.TAX_AMOUNT = 0
                dao_detail.fields.IS_ENABLE = True
                dao_detail.fields.GL_ID = dao_debt_det.fields.GL_ID
                Try
                    dao_detail.fields.CUSTOMER_ID = dao_deb_detail.fields.CUSTOMER_ID
                Catch ex As Exception

                End Try

                dao_detail.insert()

                Dim dao_bill_main As New DAO_DISBURSE.TB_BUDGET_BILL
                dao_bill_main.Getdata_by_BUDGET_DISBURSE_BILL_ID(bill_id)
                dao_bill_main.fields.MAIN_BILL = bill_id
                dao_bill_main.update()


                Dim dao_app As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
                '--------------------เบิก------------------------
                dao_app.fields.BILL_TYPE = bt
                '------------------------------------------------
                dao_app.fields.DATE_ADD = Date.Now
                dao_app.fields.FK_IDA = item("BUDGET_DISBURSE_DEBTOR_BILL_ID").Text
                dao_app.fields.IDENTITY_NUMBER = _CLS.CITIZEN_ID_AUTHORIZE
                dao_app.fields.REASON_DATE = Date.Now
                dao_app.fields.STATUS_ID = 1
                dao_app.fields.GROUP_ID = 4

                dao_app.insert()
            End If
            
        Next


    End Sub
End Class