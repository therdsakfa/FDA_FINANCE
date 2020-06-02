Imports Telerik.Web.UI

Public Class Frm_Checker
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_checker_Init(sender As Object, e As EventArgs) Handles rg_checker.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_checker
        Rad_Utility.addColumnBound("IDA", "IDA", False, width:=10)
        Rad_Utility.addColumnBound("FULLNAME", "ชื่อผู้ตรวจสอบ")
        Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        Rad_Utility.addColumnIMG("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
    End Sub

    Private Sub rg_checker_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_checker.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao As New DAO_MAS.TB_MAS_CHECKER
                dao.GetDataby_IDA(item("IDA").Text)
                dao.fields.IS_ENABLE = False
                dao.fields.UPDATE_DATE = Date.Now
                dao.update()
                rg_checker.Rebind()

            End If
        End If
    End Sub

    Private Sub rg_checker_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rg_checker.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim IDA As Integer = item("IDA").Text
            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim url As String = "Frm_Checker_Edit.aspx?IDA=" & IDA
            h2.Attributes.Add("OnClick", "Popups2('" & url & "'); return false;")
        End If
    End Sub

    Private Sub rg_checker_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_checker.NeedDataSource
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As New DataTable
        Try
            dt = bao.GET_MAS_CHECKER()
        Catch ex As Exception

        End Try

        rg_checker.DataSource = dt
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        rg_checker.Rebind()
    End Sub
End Class