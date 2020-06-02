Imports Telerik.Web.UI
Partial Public Class UC_Disburse_Debtor_Approve_Cancel
    Inherits System.Web.UI.UserControl
    Private _bg_use As String
    Public Property bg_use() As String
        Get
            Return _bg_use
        End Get
        Set(ByVal value As String)
            _bg_use = value
        End Set
    End Property
    Private _bg_year As String
    Public Property bg_year() As String
        Get
            Return _bg_year
        End Get
        Set(ByVal value As String)
            _bg_year = value
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
    Public Property dept() As Integer
        Get
            Return _dept
        End Get
        Set(ByVal value As Integer)
            _dept = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgAppCancel_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgAppCancel.Init
        Dim rg_Approve As RadGrid = rgAppCancel
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgAppCancel
        Rad_Utility.addColumnBound("DEBTOR_BILL_ID", "DEBTOR_BILL_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnButton("C", "ยกเลิกการอนุมัติ", "C", 0, "คุณต้องการยกเลิกการอนุมัติหรือไม่", 75, headertext:="การอนุมัติ")
        Rad_Utility.addColumnBound("FullName", "ชื่อ-นามสกุลผู้ยืม")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขบย.")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินยืม", is_money:=True)
        ' Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "หน่วยงาน")
    End Sub

    Private Sub rgAppCancel_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rgAppCancel.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "C" Then
                Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
                dao.Getdata_by_DEBTOR_BILL_ID(CInt(item("DEBTOR_BILL_ID").Text))
                dao.fields.IS_APPROVE = False
                dao.fields.APPROVE_DATE = Nothing
                dao.fields.EXPRESS_TYPE_ID = Nothing

                dao.update()
                rgAppCancel.Rebind()
                'Response.Redirect("../Disburse_Budget/Frm_Disburse_Debtor_Approve_Cancel.aspx")
                'Response.Redirect("/Module02/Disburse_Debtor/Frm_Disburse_Debtor_Approve_Detail.aspx?bid=" & item("DEBTOR_BILL_ID").Text)
            End If
        End If
    End Sub

    Private Sub rgAppCancel_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgAppCancel.ItemDataBound
        'If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
        '    Dim item As GridDataItem
        '    item = e.Item
        '    Dim id As Integer = item("DEBTOR_BILL_ID").Text
        '    Dim url As String = "Frm_Disburse_Debtor_Approve_Detail.aspx?bid=" & id
        '    Dim h2 As LinkButton = DirectCast(item("C").Controls(0), LinkButton)
        '    h2.Attributes.Add("OnClick", "return k('" & url & "');")


        'End If
    End Sub

    Private Sub rgAppCancel_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgAppCancel.NeedDataSource
         Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As DataTable
        If is_support = True Then
            dt = bao.getApprove_Cancel_Debtor_bill_sup_dept(bg_year, sub_BudgetID, BudgetID)
        Else
            dt = bao.getApprove_Cancel_Debtor_bill(bg_year, bg_use, BudgetID)
        End If
        If bg_use = 3 Then
            'dt = bao.getApprove_Cancel_Debtor_bill_out(bg_year, bg_use, BudgetID, dept)
            dt = bao.getApprove_Cancel_Debtor_bill_out2(bg_year, bg_use, BudgetID)
        End If

        rgAppCancel.DataSource = dt
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgAppCancel, str)
    End Sub
    Public Sub rg_rebind()
        rgAppCancel.Rebind()
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgAppCancel)
        'rg_Disburse_Budget.Rebind()
    End Sub
End Class