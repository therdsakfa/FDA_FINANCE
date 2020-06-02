Imports Telerik.Web.UI
Public Class UC_deeka_withdraw_add_Show_v2
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
    Private _PAY_TYPE_ID As Integer
    Public Property PAY_TYPE_ID() As Integer
        Get
            Return _PAY_TYPE_ID
        End Get
        Set(ByVal value As Integer)
            _PAY_TYPE_ID = value
        End Set
    End Property
    Private _Budgetyear As Integer
    Public Property Budgetyear() As Integer
        Get
            Return _Budgetyear
        End Get
        Set(ByVal value As Integer)
            _Budgetyear = value
        End Set
    End Property
    Private _ispo As String
    Public Property ispo() As String
        Get
            Return _ispo
        End Get
        Set(ByVal value As String)
            _ispo = value
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
    Private _is_rebill As Boolean
    Public Property is_rebill() As Boolean
        Get
            Return _is_rebill
        End Get
        Set(ByVal value As Boolean)
            _is_rebill = value
        End Set
    End Property
    Private _is_no_rebill As Boolean
    Public Property is_no_rebill() As Boolean
        Get
            Return _is_no_rebill
        End Get
        Set(ByVal value As Boolean)
            _is_no_rebill = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rdAddDeekaNumber_Init(sender As Object, e As EventArgs) Handles rdAddDeekaNumber.Init
        Dim rg_Approve As RadGrid = rdAddDeekaNumber
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rdAddDeekaNumber
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnBound("ID", "ID", False, width:=45)
        Rad_Utility.addColumnDate("Date_deka", "วันที่ขอเบิกเงินฏีกา")
        Rad_Utility.addColumnBound("CUSTOMER_NAME", "ชื่อผู้ขอเบิก")
        Rad_Utility.addColumnBound("Description", "รายละเอียด", width:=200)
        Rad_Utility.addColumnBound("CUSTOMER_NAME", "ชื่อผู้ขอเบิก")
        Rad_Utility.addColumnBound("typeMoney", "ประเภทเงิน")
        Rad_Utility.addColumnBound("GL_NAME", "หมวดรายจ่าย")
        Rad_Utility.addColumnBound("Amount", "จำนวนเงินขอเบิก", width:=120, is_money:=True)
        Rad_Utility.addColumnBound("Tax", "ภาษี", width:=120, is_money:=True)
        Rad_Utility.addColumnButton("R", "รายงาน", "R", 0, "")
        'Rad_Utility.addColumnButton("A", "เพิ่มเลขฎีกา", "A", 0, "")
        'Rad_Utility.addColumnButton("E", "ลบเลขขบ.", "E", 0, "คุณต้องการลบเลขขบ. หรือไม่")
    End Sub

    Private Sub rdAddDeekaNumber_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rdAddDeekaNumber.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim lnk_ist As String = ""
            Dim rp_dka As String = ""
            lnk_ist = "../../Module02/Disburse_Budget/Frm_Disburse_Budget_Deeka_Number_Insert.aspx?bid=" & item("BUDGET_DISBURSE_BILL_ID").Text & "&bt=" & bt & "&stat=" & stat & "&g=" & _g
            rp_dka = "../Module02/Report/Frm_Report_R2_027.aspx"
            If BudgetUseID = 3 Then
                lnk_ist = lnk_ist & "&debt=1"
            End If
            'Dim h2 As LinkButton = DirectCast(item("A").Controls(0), LinkButton)
            Dim r1 As LinkButton = DirectCast(item("R").Controls(0), LinkButton)
            r1.Attributes.Add("OnClick", "Popups('" & rp_dka & "'); return false;")


        End If
    End Sub

    Private Sub rdAddDeekaNumber_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rdAddDeekaNumber.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET()


        dt = bao.get_tb_deeka_withdraw()

        rdAddDeekaNumber.DataSource = dt
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rdAddDeekaNumber, str)
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rdAddDeekaNumber)
        'rg_Disburse_Budget.Rebind()
    End Sub
    Public Sub rgRebind()
        rdAddDeekaNumber.Rebind()
    End Sub


End Class