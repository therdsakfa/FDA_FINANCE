Imports Telerik.Web.UI
Public Class UC_Maintain_ReturnMoney_Debtor_Change_List
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgChange_Init(sender As Object, e As EventArgs) Handles rgChange.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgChange
        Rad_Utility.addColumnBound("RETURN_MONEY_DEBTOR_ID", "RETURN_MONEY_DEBTOR_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสารส่งใช้หนี้")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสารส่งใช้หนี้")
        Rad_Utility.addColumnBound("RETURN_DESCRIPTION", "รายละเอียดการคืน", width:=400)
        Rad_Utility.addColumnBound("BT_NUMBER", "บฝ.เลขที่")
        Rad_Utility.addColumnBound("CHANGE_DESCRIPTION", "รายละเอียดการโอนคืนลูกหนี้")
        Rad_Utility.addColumnBound("RETURN_AMOUNT", "จำนวนเงินคืน", is_money:=True)
        Rad_Utility.addColumnIMG("E", "เพิ่มรายละเอียด", "E", 0, "", img:=True, type_img:="edit")
    End Sub

    Private Sub rgChange_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rgChange.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim id As Integer = item("RETURN_MONEY_DEBTOR_ID").Text
            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim url As String = "Frm_Maintain_ReturnMoney_Debtor_Change_List_Edit.aspx?id=" & id
            h2.Attributes.Add("OnClick", "return k('" & url & "');")

        End If
    End Sub

    Private Sub rgChange_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgChange.NeedDataSource
        Dim id As Integer = 0
        id = Request.QueryString("id")
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_debtor_return_money_by_bill()
        rgChange.DataSource = dt
    End Sub
    Public Sub rg_rebind()
        rgChange.Rebind()
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgChange)
    End Sub
End Class