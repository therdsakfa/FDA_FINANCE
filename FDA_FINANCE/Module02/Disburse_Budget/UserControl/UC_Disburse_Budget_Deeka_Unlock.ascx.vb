Imports Telerik.Web.UI

Public Class UC_Disburse_Budget_Deeka_Unlock
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
    Private _is_po As Boolean
    Public Property is_po() As Boolean
        Get
            Return _is_po
        End Get
        Set(ByVal value As Boolean)
            _is_po = value
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
    Private Sub rg_Disburse_Budget_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rg_Disburse_Budget.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_Disburse_Budget
        Rad_Utility.Rad_css_setting(rg_Disburse_Budget)
        Rad_Utility.addColumnIMG("img", "ปลดฎีกา")
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnBound("PAY_TYPE_ID", "PAY_TYPE_ID", False)
        Rad_Utility.addColumnCheckbox("IS_APPROVE", "การอนุมัติ", display:=False)
        Rad_Utility.addColumnBound("app", "app", False)
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข ขบ.", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", width:=300)
        'Rad_Utility.addColumnBound("CUSTOMER_NAME", "เจ้าหนี้")
        Rad_Utility.addColumnBound("sum_amount", "จำนวนเงิน", is_money:=True, footer_txt:="รวม", width:=120)

    End Sub

    Private Sub rg_Disburse_Budget_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_Disburse_Budget.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("BUDGET_DISBURSE_BILL_ID").Text
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(id)

            Dim img As Image = DirectCast(item("img").Controls(0), Image)
            If dao.fields.DEEKA_UNLOCK IsNot Nothing Then
                If dao.fields.DEEKA_UNLOCK = True Then
                    img.ImageUrl = "~/images/cb.png"
                Else
                    img.ImageUrl = "~/images/emp_cb.png"
                End If
            Else
                img.ImageUrl = "~/images/emp_cb.png"
            End If

        End If
    End Sub

    Private Sub rg_Disburse_Budget_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_Disburse_Budget.NeedDataSource
        Dim BudgetBill As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As New DataTable

        If is_po = True Then
            dt = BudgetBill.get_BUDGET_BILL_Deeka_PO_V2(BudgetUseID, BudgetYear, stat - 1, g)
        Else
            If _is_rebill = True Then
                dt = BudgetBill.get_BUDGET_BILL_Deeka_rebill_V2(BudgetUseID, BudgetYear, stat - 1, g)
            ElseIf is_no_rebill = True Then
                dt = BudgetBill.get_BUDGET_BILL_Deeka_no_rebill(BudgetUseID, BudgetYear, stat - 1, g)
            Else
                dt = BudgetBill.get_BUDGET_BILL_Deeka_V2(BudgetUseID, BudgetYear, stat - 1, g)
            End If

        End If
        
        rg_Disburse_Budget.DataSource = dt
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_Disburse_Budget, str)
    End Sub
    Public Sub rebind_grid()
        rg_Disburse_Budget.Rebind()
    End Sub
    Public Sub update_true(ByVal date_input As Date, ByVal iden As String)
        For Each item As GridDataItem In rg_Disburse_Budget.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
            dao.fields.DEEKA_UNLOCK = True
            dao.fields.DEEKA_UNLOCK_DATE = date_input
            dao.fields.STATUS_ID = stat
            dao.fields.GROUP_ID = g
            dao.update()

            Dim dao2 As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            dao2.fields.FK_IDA = item("BUDGET_DISBURSE_BILL_ID").Text
            dao2.fields.BILL_TYPE = bt
            dao2.fields.DATE_ADD = Date.Now
            dao2.fields.IDENTITY_NUMBER = iden
            dao2.fields.REASON_DATE = Date.Now
            dao2.fields.STATUS_ID = stat
            dao2.fields.GROUP_ID = g
            dao2.insert()

            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "ปลดล็อคฎีกาเลขที่หนังสือ " & dao.fields.DOC_NUMBER, "BUDGET_BILL", item("BUDGET_DISBURSE_BILL_ID").Text)


        Next
    End Sub
    Public Sub update_false(ByVal stat As Integer)
        For Each item As GridDataItem In rg_Disburse_Budget.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
            dao.fields.DEEKA_UNLOCK = False
            dao.fields.DEEKA_UNLOCK_DATE = Nothing
            dao.fields.STATUS_ID = stat - 1
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "ยกเลิกปลดล็อคฎีกาเลขที่หนังสือ " & dao.fields.DOC_NUMBER, "BUDGET_BILL", item("BUDGET_DISBURSE_BILL_ID").Text)

            dao.update()

            Dim dao2 As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            dao2.get_deeka_stat_g_del(item("BUDGET_DISBURSE_BILL_ID").Text, bt, stat, g)

            For Each dao2.fields In dao2.datas
                Dim dao3 As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
                Try
                    dao3.GetDataby_IDA(dao2.fields.IDA)
                    dao3.delete()
                Catch ex As Exception

                End Try
            Next
        Next
    End Sub
End Class