Imports Telerik.Web.UI
Public Class UC_Disburse_Budget_Multi_Bill
    Inherits System.Web.UI.UserControl
    Private _group_id As Integer
    Public Property group_id() As Integer
        Get
            Return _group_id
        End Get
        Set(ByVal value As Integer)
            _group_id = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub rg_Disburse_Budget_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rg_Disburse_Budget.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_Disburse_Budget
        Rad_Utility.Rad_css_setting(rg_Disburse_Budget)
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnBound("mark", "mark", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("CUSTOMER_NAME", "ชื่อเจ้าหนี้")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน ง.ป.ม.", footer_txt:="รวม : ")
        'Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        Rad_Utility.addColumnIMG("Delete", "ลบ", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
        'Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
    End Sub

    Private Sub rg_Disburse_Budget_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_Disburse_Budget.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                ' del_item(item("BUDGET_DISBURSE_BILL_ID").Text)
                Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
                Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                dao_head.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
                dao_detail.Getdata_by_Disburse_id(item("BUDGET_DISBURSE_BILL_ID").Text)
                dao_detail.delete()
                dao_head.delete()
                rg_Disburse_Budget.Rebind()
            End If
        End If
    End Sub

    Private Sub rg_Disburse_Budget_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_Disburse_Budget.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim h2 As ImageButton = DirectCast(item("DeleteColumn").Controls(0), ImageButton)
            If item("mark").Text = "1" Then
                h2.Visible = False
            End If

        End If
    End Sub

    Private Sub rg_Disburse_Budget_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_Disburse_Budget.NeedDataSource
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As DataTable = bao.get_multi_bill_add(group_id)

        rg_Disburse_Budget.DataSource = dt
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rg_Disburse_Budget)
    End Sub

    Public Sub rg_rebind()
        rg_Disburse_Budget.Rebind()
    End Sub
End Class