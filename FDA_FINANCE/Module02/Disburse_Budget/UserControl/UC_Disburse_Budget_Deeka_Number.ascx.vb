Imports Telerik.Web.UI

Public Class UC_Disburse_Budget_Deeka_Number
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
        Rad_Utility.addColumnBound("id", "ลำดับที่", width:=45)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข GFMIS")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", width:=200)
        Rad_Utility.addColumnBound("sum_amount", "จำนวนเงิน", width:=120, is_money:=True)
        Rad_Utility.addColumnBound("DEEKA_NUMBER", "เลขฎีกา")
        Rad_Utility.addColumnButton("A", "เพิ่มเลขฎีกา", "A", 0, "")
        'Rad_Utility.addColumnButton("E", "ลบเลขขบ.", "E", 0, "คุณต้องการลบเลขขบ. หรือไม่")
    End Sub

    Private Sub rdAddDeekaNumber_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rdAddDeekaNumber.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim lnk_ist As String = ""
            lnk_ist = "../../Module02/Disburse_Budget/Frm_Disburse_Budget_Deeka_Number_Insert.aspx?bid=" & item("BUDGET_DISBURSE_BILL_ID").Text & "&bt=" & bt & "&stat=" & stat & "&g=" & _g
            If BudgetUseID = 3 Then
                lnk_ist = lnk_ist & "&debt=1"
            End If
            Dim h2 As LinkButton = DirectCast(item("A").Controls(0), LinkButton)
            h2.Attributes.Add("OnClick", "Popups('" & lnk_ist & "'); return false;")

        End If
    End Sub

    Private Sub rdAddDeekaNumber_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rdAddDeekaNumber.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET()
        If ispo = "True" Then
            dt = bao.get_bill_add_deeka_number_po_V2(BudgetUseID, Budgetyear, stat - 1, g)
        Else
            If is_rebill = True Then
                dt = bao.get_bill_add_deeka_number_rebill_V2(BudgetUseID, Budgetyear, stat - 1, g)
            ElseIf is_no_rebill = True Then
                dt = bao.get_bill_add_deeka_number_no_rebill(BudgetUseID, Budgetyear, stat - 1, g)
            Else
                dt = bao.get_bill_add_deeka_number_V2(BudgetUseID, Budgetyear, ispo, stat - 1, g)
            End If

        End If
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