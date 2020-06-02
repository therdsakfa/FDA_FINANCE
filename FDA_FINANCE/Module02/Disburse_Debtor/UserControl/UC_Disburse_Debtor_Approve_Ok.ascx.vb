Imports Telerik.Web.UI
Partial Public Class UC_Disburse_Debtor_Approve_Ok
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgAppOK_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgAppOK.Init
        Dim rg_Debtor As RadGrid = rgAppOK
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgAppOK
        Rad_Utility.addColumnBound("DEBTOR_BILL_ID", "DEBTOR_BILL_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่", Display:=False)
        Rad_Utility.addColumnBound("FullName", "ชื่อ-นามสกุลผู้ยืม", width:=200)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        'Rad_Utility.addColumnDate("Bill_RECIEVE_DATE", "วันที่รับเอกสาร", False)
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร", False)
        'Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข GFMIS", False)
        'Rad_Utility.addColumnDate("BILL_DATE", "วันที่เบิก", False)
        'Rad_Utility.addColumnBound("BILL_NUMBER", "เลขบย.")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", width:=300)
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินยืม", is_money:=True)
        Rad_Utility.addColumnBound("debtor_type", "แหล่งเงิน")
        Rad_Utility.addColumnBound("pay_type", "ประเภทจ่าย")
        Rad_Utility.addColumnBound("App", "App", False)
        'Rad_Utility.addColumnDate("APPROVE_DATE", "วันที่อนุมัติ")
        'Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "หน่วยงาน")
        Rad_Utility.addColumnButton("A", "เลือก", "A", 0, "", headertext:="เลือกประเภทจ่าย")
        'Rad_Utility.addColumnButton("C", "แก้ไข", "C", 0, "", headertext:="แก้ไข", _display:=False)
    End Sub

    Private Sub rgAppOK_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rgAppOK.ItemCommand
        'If TypeOf e.Item Is GridDataItem Then
        '    Dim item As GridDataItem = e.Item

        '    'If e.CommandName = "A" Then
        '    '    Select Case BudgetUseID
        '    '        Case 1
        '    '            Response.Redirect("/Module02/Disburse_Debtor/Frm_Disburse_Debtor_Approve_Detail.aspx?bid=" & item("DEBTOR_BILL_ID").Text)
        '    '        Case 3
        '    '            Response.Redirect("/Module02/Disburse_Debtor/Frm_Disburse_Debtor_Approve_Detail.aspx?bid=" & item("DEBTOR_BILL_ID").Text)

        '    '    End Select

        '    'End If
        'End If
    End Sub

    Private Sub rgAppOK_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgAppOK.ItemDataBound

        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim id As Integer = item("DEBTOR_BILL_ID").Text
            Dim url As String = ""
            If BudgetUseID = 1 Then
                url = "../../Module02/Disburse_Debtor/Frm_Disburse_Debtor_Approve_Detail.aspx?bid=" & id & "&g=" & g & "&bt=" & bt & "&stat=" & stat
            Else
                url = "../../Module05/Disburse_OutsideDebtor/Frm_Disburse_OutsideDebtor_Approve_Detail.aspx?bid=" & id & "&g=" & g & "&bt=" & bt & "&stat=" & stat
            End If
            'Frm_Disburse_OutsideDebtor_Approve_Detail
            Dim url_edit As String = "../../Module05/Disburse_OutsideDebtor/Frm_Disburse_Debtor_Approve_Edit.aspx?bid=" & id
            Dim h2 As LinkButton = DirectCast(item("A").Controls(0), LinkButton)
            'Dim C1 As LinkButton = DirectCast(item("C").Controls(0), LinkButton)
            h2.Attributes.Add("OnClick", "Popups('" & url & "'); return false;")
            'C1.Attributes.Add("OnClick", "Popups2('" & url_edit & "'); return false;")

        End If
    End Sub

    Private Sub rgAppOK_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgAppOK.NeedDataSource
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As DataTable
        If is_support = True Then
            dt = bao.getApprove_Debtor_bill_sup_det(bgyear, sub_BudgetID, BudgetID)
        Else
            'dt = bao.getApprove_Debtor_bill(bgyear, BudgetUseID)
            dt = bao.getApprove_Debtor_bill_bt_group_v2(bgyear, BudgetUseID, stat - 1, g)
        End If
        If BudgetUseID = 3 Then
            'dt = bao.getApprove_Debtor_bill_out(bgyear, BudgetUseID, BudgetID, dept)
            dt = bao.getApprove_Debtor_bill_out2(bgyear, BudgetUseID, stat - 1, g)
        End If


        rgAppOK.DataSource = dt
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgAppOK, str)
    End Sub
    Public Sub rg_rebind()
        rgAppOK.Rebind()
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgAppOK)
        'rg_Disburse_Budget.Rebind()
    End Sub
    Public Sub set_color_rg()
        If rgAppOK.Items.Count > 0 Then
            Dim i As Integer = 0
            For Each item As GridDataItem In rgAppOK.Items
                If i = 0 Then
                    item.ForeColor = Drawing.Color.Crimson

                End If
                i = i + 1
            Next
        End If
    End Sub
End Class