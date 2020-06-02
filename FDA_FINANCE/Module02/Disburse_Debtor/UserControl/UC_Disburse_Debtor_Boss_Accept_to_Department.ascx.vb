Imports Telerik.Web.UI

Public Class UC_Disburse_Debtor_Boss_Accept_to_Department
    Inherits System.Web.UI.UserControl
    Private _BudgetUseID As Integer
    Public Property BudgetUseID() As Integer
        Get
            Return _BudgetUseID
        End Get
        Set(ByVal value As Integer)
            _BudgetUseID = value
        End Set
    End Property
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
    Private _is_support As Boolean
    Public Property is_support() As Boolean
        Get
            Return _is_support
        End Get
        Set(ByVal value As Boolean)
            _is_support = value
        End Set
    End Property
    Private _sub_BudgetID As Integer
    Public Property sub_BudgetID() As Integer
        Get
            Return _sub_BudgetID
        End Get
        Set(ByVal value As Integer)
            _sub_BudgetID = value
        End Set
    End Property
    Private _dept As Integer
    Public Property dept() As String
        Get
            Return _dept
        End Get
        Set(ByVal value As String)
            _dept = value
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
    Private _g As Integer
    Public Property g() As Integer
        Get
            Return _g
        End Get
        Set(ByVal value As Integer)
            _g = value
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
    Private _g2 As Integer
    Public Property g2() As Integer
        Get
            Return _g2
        End Get
        Set(ByVal value As Integer)
            _g2 = value
        End Set
    End Property
    Private _stat2 As Integer
    Public Property stat2() As Integer
        Get
            Return _stat2
        End Get
        Set(ByVal value As Integer)
            _stat2 = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub rgApprove_Init(sender As Object, e As EventArgs) Handles rgBoss_Approve.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgBoss_Approve
        Rad_Utility.addColumnBound("DEBTOR_BILL_ID", "DEBTOR_BILL_ID", False)
        Rad_Utility.addColumnBound("app", "app", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", width:=300)
        Rad_Utility.addColumnBound("CUSTOMER_NAME", "ชื่อลูกหนี้")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True, footer_txt:="รวม", width:=120)
        Rad_Utility.addColumnBound("reason", "การอนุมัติส่งเรื่อง อย.")
    End Sub
    Private Sub rgApprove_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgBoss_Approve.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        dt = bao.get_boss_approve_debtorv2(bgyear, BudgetUseID, stat - 1, g2)
        dt.Columns.Add("reason")
        For Each dr As DataRow In dt.Rows
            If dr("STATUS_ID") = stat Then
                dr("reason") = "หัวหน้าฝ่ายการคลังอนุมัติแล้ว"
            End If
        Next

        rgBoss_Approve.DataSource = dt
    End Sub
    Public Sub update_true(ByVal date_input As Date, ByVal iden As String)
        For Each item As GridDataItem In rgBoss_Approve.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
            dao.Getdata_by_DEBTOR_BILL_ID(item("DEBTOR_BILL_ID").Text)
            dao.fields.STATUS_ID = stat
            dao.fields.GROUP_ID = g
            dao.update()

            Dim dao2 As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            dao2.fields.STATUS_ID = stat
            dao2.fields.GROUP_ID = g
            dao2.fields.BILL_TYPE = bt
            dao2.fields.REASON_DATE = date_input
            dao2.fields.IDENTITY_NUMBER = iden
            dao2.fields.DATE_ADD = Date.Now
            dao2.fields.FK_IDA = item("DEBTOR_BILL_ID").Text
            dao2.insert()
        Next
    End Sub
    Public Sub rg_rebind()
        rgBoss_Approve.Rebind()
    End Sub
End Class