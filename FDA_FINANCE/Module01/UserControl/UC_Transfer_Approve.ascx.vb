Imports Telerik.Web.UI

Public Class UC_Transfer_Approve
    Inherits System.Web.UI.UserControl
    Private _budget_id As Integer
    Public Property budget_id() As Integer
        Get
            Return _budget_id
        End Get
        Set(ByVal value As Integer)
            _budget_id = value
        End Set
    End Property
    Private _budget_year As Integer
    Public Property budget_year() As Integer
        Get
            Return _budget_year
        End Get
        Set(ByVal value As Integer)
            _budget_year = value
        End Set
    End Property
    Private _dept_id As Integer
    Public Property dept_id() As Integer
        Get
            Return _dept_id
        End Get
        Set(ByVal value As Integer)
            _dept_id = value
        End Set
    End Property
    Private _Is_outside_dept As Boolean
    Public Property Is_outside_dept() As Boolean
        Get
            Return _Is_outside_dept
        End Get
        Set(ByVal value As Boolean)
            _Is_outside_dept = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgTransferApp_Init(sender As Object, e As EventArgs) Handles rgTransferApp.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgTransferApp
        Rad_Utility.addColumnBound("BUDGET_TRANSFER_ID", "BUDGET_TRANSFER_ID", False)
        Rad_Utility.addColumnIMG("img", "การอนุมัติ")
        Rad_Utility.addColumnDate("BUDGET_TRANSFER_DATE", "วันที่ทำรายการ")
        Rad_Utility.addColumnBound("BUDGET_TRANSFER_DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("BUDGET_TRANSFER_DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("bg_from_des", "งบค่าใช้จ่าย")
        Rad_Utility.addColumnBound("dept_from", "หน่วยงานที่โอน")
        Rad_Utility.addColumnBound("t_type", "ประเภทการโอน")
        Rad_Utility.addColumnBound("bg_to_des", "งบค่าใช้จ่ายที่รับโอน")
        Rad_Utility.addColumnBound("dept_to", "หน่วยงานที่รับโอน")
        'Rad_Utility.addColumnBound("BUDGET_TRANSFER_COUNT", "ครั้งที่โอน")
        Rad_Utility.addColumnBound("BUDGET_TRANSFER_AMOUNT", "จำนวนเงินที่ขอโอน", is_money:=True)
    End Sub

    Private Sub rgTransferApp_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rgTransferApp.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim id As Integer = item("BUDGET_TRANSFER_ID").Text
            Dim img As Image = DirectCast(item("img").Controls(0), Image)
            Dim dao As New DAO_BUDGET.TB_BUDGET_TRANSFER
            dao.Getdata_by_BUDGET_TRANSFER_ID(id)
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

    Private Sub rgTransferApp_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgTransferApp.NeedDataSource
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_transfer_for_approve(budget_year)
        rgTransferApp.DataSource = dt
    End Sub
    Public Sub update_true(ByVal date_input As Date)
        For Each item As GridDataItem In rgTransferApp.SelectedItems
            Dim dao As New DAO_BUDGET.TB_BUDGET_TRANSFER
            dao.Getdata_by_BUDGET_TRANSFER_ID(item("BUDGET_TRANSFER_ID").Text)
            dao.fields.IS_APPROVE = True
            dao.fields.APPROVE_DATE = date_input
            dao.update()
        Next
    End Sub
    Public Sub update_false()
        For Each item As GridDataItem In rgTransferApp.SelectedItems
            Dim dao As New DAO_BUDGET.TB_BUDGET_TRANSFER
            dao.Getdata_by_BUDGET_TRANSFER_ID(item("BUDGET_TRANSFER_ID").Text)
            dao.fields.IS_APPROVE = False
            dao.fields.APPROVE_DATE = Nothing
            dao.update()
        Next
    End Sub
    Public Sub rg_rebind()
        rgTransferApp.Rebind()
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgTransferApp, str)
    End Sub
End Class