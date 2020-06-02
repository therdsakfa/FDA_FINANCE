Imports Telerik.Web.UI
Public Class UC_Budget_Transfer_Share_Type
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgTransferShare_Init(sender As Object, e As EventArgs) Handles rgTransferShare.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgTransferShare
        Rad_Utility.addColumnBound("TRANSFER_OUT_DETAIL_ID", "TRANSFER_OUT_DETAIL_ID", False)
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnBound("TYPE_TRANSFER", "ประเภทโอนเบิกแทน")
        Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        Rad_Utility.addColumnIMG("Delete", "ลบ", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
    End Sub

    Private Sub rgTransferShare_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rgTransferShare.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                ' del_item(item("BUDGET_DISBURSE_BILL_ID").Text)
                Dim dao_head As New DAO_BUDGET.TB_BUDGET_TRANSFER_DETAIL
                dao_head.Getdata_by_ID(item("TRANSFER_OUT_DETAIL_ID").Text)
                'Dim log As New log_event.log
                'log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                '               Request.Url.AbsoluteUri.ToString(), "ลบรายการโอนให้หน่วยงานภายนอกเลขหนังสือ " & _
                '               dao_head.fields.BUDGET_TRANSFER_DOC_NUMBER, "BUDGET_TRANSFER", item("BUDGET_TRANSFER_ID").Text)

                dao_head.delete()

                rgTransferShare.Rebind()
            End If
        End If
    End Sub

    Private Sub rgTransferShare_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgTransferShare.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("TRANSFER_OUT_DETAIL_ID").Text
            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim url As String = "../Module01/Frm_Budget_Transfer_Share_Type_Edit.aspx?id=" & id
            h2.Attributes.Add("OnClick", "return k('" & url & "');")
        End If
    End Sub

    Private Sub rgTransferShare_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgTransferShare.NeedDataSource
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_Transfer_detail(Request.QueryString("tid"))

        rgTransferShare.DataSource = dt
    End Sub
    Public Sub rg_rebind()
        rgTransferShare.Rebind()
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgTransferShare, str)
    End Sub
End Class