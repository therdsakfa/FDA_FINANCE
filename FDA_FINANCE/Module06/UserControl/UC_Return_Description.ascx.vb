Imports Telerik.Web.UI
Public Class UC_Return_Description
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgReturn_Description_Init(sender As Object, e As EventArgs) Handles rgReturn_Description.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgReturn_Description
        Rad_Utility.addColumnBound("RETURN_DESCRIPTION_ID", "RETURN_DESCRIPTION_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("RETURN_DESCRIPTION", "รายละเอียดการคืน")
        Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        '  Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
        Rad_Utility.addColumnIMG("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
    End Sub

    Private Sub rgReturn_Description_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgReturn_Description.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao As New DAO_MAS.TB_MAS_RETURN_DESCRIPTION
                dao.Getdata_by_ID(item("RETURN_DESCRIPTION_ID").Text)
                dao.delete()
                rgReturn_Description.Rebind()
                ' Response.Redirect("/Module06/Frm_PayList.aspx")
                'ElseIf e.CommandName = "E" Then
                '    Response.Redirect("/Module06/Frm_PayList_Edit.aspx?pid=" & item("PATLIST_ID").Text)
            End If
        End If
    End Sub

    Private Sub rgReturn_Description_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rgReturn_Description.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("RETURN_DESCRIPTION_ID").Text
            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim url As String = "../../Module06/Frm_Return_Description_Edit.aspx?id=" & id
            h2.Attributes.Add("OnClick", "return k('" & url & "');")


        End If
    End Sub

    Private Sub rgReturn_Description_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgReturn_Description.NeedDataSource
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_RETURN_DESCRIPTION()
        rgReturn_Description.DataSource = dt
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgReturn_Description)
    End Sub
    Public Sub rg_rebind()
        rgReturn_Description.Rebind()
    End Sub
End Class