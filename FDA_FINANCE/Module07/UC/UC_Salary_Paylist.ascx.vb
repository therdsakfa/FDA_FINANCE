Imports Telerik.Web.UI
Public Class UC_Salary_Paylist
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_salary_paylist_Init(sender As Object, e As EventArgs) Handles rg_salary_paylist.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_salary_paylist
        Rad_Utility.addColumnBound("SALARY_DETAIL_ID", "SALARY_DETAIL_ID", False)
        Rad_Utility.addColumnBound("SALARY_ID", "SALARY_ID", False)
        Rad_Utility.addColumnBound("SALARY_PAYLIST_NAME", "ชื่อรายรับ/รายจ่าย")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnBound("big_type", "ประเภทรายการ")
        'Rad_Utility.addColumnIMG("E", "แก้ไข", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        Rad_Utility.addColumnButton("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", width:=120)
    End Sub

    Private Sub rg_salary_paylist_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_salary_paylist.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao As New DAO_SALARY.TB_SALARY_DETAIL
                dao.Getdata_by_ID(item("SALARY_DETAIL_ID").Text)
                dao.delete()
                rg_salary_paylist.Rebind()
            End If
        End If
    End Sub

    Private Sub rg_salary_paylist_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_salary_paylist.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            'Dim h1 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            'Dim url As String = "../Module07/Frm_Salary_List_Edit.aspx?id=" & item("SALARY_DETAIL_ID").Text
            'h1.Attributes.Add("OnClick", "return k('" & url & "');")

        End If
    End Sub

    Private Sub rg_salary_paylist_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_salary_paylist.NeedDataSource
        Dim bao As New BAO_BUDGET.Salary
        Dim dt As New DataTable
        dt = bao.get_salary_list(Request.QueryString("id"))

        rg_salary_paylist.DataSource = dt
    End Sub
    Public Sub rg_rebind()
        rg_salary_paylist.Rebind()
    End Sub
End Class