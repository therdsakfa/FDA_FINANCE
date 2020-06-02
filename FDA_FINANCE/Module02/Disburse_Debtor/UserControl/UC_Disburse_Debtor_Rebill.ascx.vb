Imports Telerik.Web.UI
Public Class UC_Disburse_Debtor_Rebill
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_Disburse_Debtor_Rebill_Init(sender As Object, e As EventArgs) Handles rg_Disburse_Debtor_Rebill.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_Disburse_Debtor_Rebill
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnCheckbox("IS_APPROVE", "การอนุมัติ", display:=False)
        Rad_Utility.addColumnIMG("img", "การอนุมัติ")
        Rad_Utility.addColumnBound("app", "app", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnIMG("Delete", "แก้ไขข้อมูล", "DeleteCol", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="delete")
    End Sub

    Private Sub rg_Disburse_Debtor_Rebill_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_Disburse_Debtor_Rebill.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
                Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
                dao_detail.Getdata_by_Disburse_id(item("BUDGET_DISBURSE_BILL_ID").Text)
                dao.delete()
                dao_detail.delete()
                rg_Disburse_Debtor_Rebill.Rebind()

            End If

        End If
    End Sub

    Private Sub rg_Disburse_Debtor_Rebill_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_Disburse_Debtor_Rebill.ItemDataBound

        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim id As Integer = item("BUDGET_DISBURSE_BILL_ID").Text
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

    Private Sub rg_Disburse_Debtor_Rebill_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_Disburse_Debtor_Rebill.NeedDataSource
        Dim BudgetBill As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As DataTable = BudgetBill.get_bg_bill_rebill_debtor_bt_group(BudgetUseID, BudgetYear, stat, g)
        dt.Columns.Add("status_bill", Type.GetType("System.String"))
        dt.Columns.Add("app")

        'For Each dr As DataRow In dt.Rows
        '    If IsDBNull(dr("IS_APPROVE")) = False Then
        '        If CBool(dr("IS_APPROVE")) = True Then
        '            dr("app") = "1"
        '        Else
        '            dr("app") = "2"
        '        End If
        '    Else
        '        dr("app") = "2"
        '    End If

        'Next


        rg_Disburse_Debtor_Rebill.DataSource = dt
    End Sub

    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_Disburse_Debtor_Rebill, str)
    End Sub
    Public Sub rg_rebind()
        rg_Disburse_Debtor_Rebill.Rebind()
    End Sub

    Public Sub update_true(ByVal date_input As Date)
        For Each item As GridDataItem In rg_Disburse_Debtor_Rebill.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
            dao.fields.IS_APPROVE = True
            dao.fields.APPROVE_DATE = date_input
            dao.update()
        Next
    End Sub
    Public Sub update_false()
        For Each item As GridDataItem In rg_Disburse_Debtor_Rebill.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
            dao.fields.IS_APPROVE = False

            dao.update()
        Next
    End Sub
End Class