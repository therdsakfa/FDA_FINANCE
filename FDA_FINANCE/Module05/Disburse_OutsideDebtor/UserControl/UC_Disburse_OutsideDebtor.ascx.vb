Imports Telerik.Web.UI
Partial Public Class UC_Disburse_OutsideDebtor
    Inherits System.Web.UI.UserControl
    Private _dept_id As Integer
    Public Property dept_id() As Integer
        Get
            Return _dept_id
        End Get
        Set(ByVal value As Integer)
            _dept_id = value
        End Set
    End Property
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgDebtorOutside_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgDebtorOutside.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgDebtorOutside
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("Bill_RECIEVE_DATE", "วันที่รับเอกสาร")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnBound("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        Rad_Utility.addColumnBound("GFMIS", "เลข ขบ.")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน ง.ป.ม.", is_money:=True)
        Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        Rad_Utility.addColumnIMG("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
    End Sub

    Private Sub rgDebtorOutside_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgDebtorOutside.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
                Dim dao_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
                dao.Getdata_by_DEBTOR_BILL_ID(item("DEBTOR_BILL_ID").Text)
                dao_detail.Getdata_by_DEBTOR_BILL_ID(item("DEBTOR_BILL_ID").Text)
                dao.delete()
                dao_detail.delete()
                rgDebtorOutside.Rebind()
                'Response.Redirect("/Module02/Disburse_Debtor/Frm_Disburse_Budget_Bill.aspx")
                'ElseIf e.CommandName = "E" Then
                ' Response.Redirect("/Module02/Disburse_Debtor/Frm_Disburse_Debtor_Bill_Edit.aspx?bid=" & item("DEBTOR_BILL_ID").Text & "&dept=" & dept_id)
            End If

        End If
    End Sub

    Private Sub rgDebtorOutside_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgDebtorOutside.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("DEBTOR_BILL_ID").Text
            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            h2.Attributes.Add("OnClick", "return k(" & id & "," & dept_id & ");")


        End If
    End Sub

    Private Sub rgDebtorOutside_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgDebtorOutside.NeedDataSource
        Dim DebtorBill As New BAO_BUDGET.DISBURSE_BUDGET
        ' rgDebtorOutside.DataSource = DebtorBill.get_DEBTOR_BILL(1)
    End Sub
End Class