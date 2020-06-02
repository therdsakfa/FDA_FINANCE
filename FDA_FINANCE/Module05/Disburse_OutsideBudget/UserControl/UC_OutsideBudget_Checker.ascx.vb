Imports Telerik.Web.UI
Public Class UC_OutsideBudget_Checker
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
    Private _sub_BudgetID As Integer
    Public Property sub_BudgetID() As Integer
        Get
            Return _sub_BudgetID
        End Get
        Set(ByVal value As Integer)
            _sub_BudgetID = value
        End Set
    End Property
    Private _BudgetYear As Integer
    Public Property BudgetYear() As Integer
        Get
            Return _BudgetYear
        End Get
        Set(ByVal value As Integer)
            _BudgetYear = value
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
    Private _is_support As Boolean
    Public Property is_support() As Boolean
        Get
            Return _is_support
        End Get
        Set(ByVal value As Boolean)
            _is_support = value
        End Set
    End Property
    Private _is_benefit As Boolean
    Public Property is_benefit() As Boolean
        Get
            Return _is_benefit
        End Get
        Set(ByVal value As Boolean)
            _is_benefit = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_Checker_Init(sender As Object, e As EventArgs) Handles rg_Checker.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_Checker
        Rad_Utility.Rad_css_setting(rg_Checker)
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnBound("PAY_TYPE_ID", "PAY_TYPE_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnCheckbox("IS_APPROVE", "การอนุมัติ", display:=False)
        Rad_Utility.addColumnIMG("img", "การอนุมัติ")
        Rad_Utility.addColumnBound("app", "app", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", width:=300)
        Rad_Utility.addColumnBound("CUSTOMER_NAME", "เจ้าหนี้")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True, footer_txt:="รวม", width:=120)
        Rad_Utility.addColumnButton("E", "พิจารณา", "E", 0, "", width:=120)
        'Rad_Utility.addColumnButton("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", width:=120)
    End Sub

    Private Sub rg_Checker_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_Checker.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("BUDGET_DISBURSE_BILL_ID").Text
            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)

            h2.Attributes.Add("OnClick", "Popups2('../../Module05/Disburse_OutsideBudget/Frm_Disburse_Outside_Budget_Checker_Insert.aspx.aspx?bid=" & id & "&bgid=" & BudgetID & "&bgYear=" & BudgetYear & "'); return false;")

            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(id)
            Dim img As Image = DirectCast(item("img").Controls(0), Image)
            If dao.fields.IS_APPROVE IsNot Nothing Then
                If dao.fields.IS_APPROVE = True Then
                    img.ImageUrl = "~/images/cb.png"
                Else
                    img.ImageUrl = "~/images/emp_cb.png"
                End If
            Else
                img.ImageUrl = "~/images/emp_cb.png"
            End If

        End If
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_Checker, str)
    End Sub
    Public Sub rebind_grid()
        rg_Checker.Rebind()
    End Sub

    Private Sub rg_Checker_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_Checker.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        dt = bao.get_checker_list(BudgetYear, BudgetUseID)

        rg_Checker.DataSource = dt
    End Sub
End Class