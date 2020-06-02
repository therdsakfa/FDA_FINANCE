Imports Telerik.Web.UI
Public Class UC_MoneyType_Information
    Inherits System.Web.UI.UserControl
    Private _bg_ID As Integer
    Public Property bg_ID() As Integer
        Get
            Return _bg_ID
        End Get
        Set(ByVal value As Integer)
            _bg_ID = value
        End Set
    End Property

    Private dtMain As New DataTable


    Public Sub BindDt(ByVal dt As DataTable)
        dtMain = dt
        rgMoneyTypeInformation.Rebind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgMoneyTypeInformation_Init(sender As Object, e As EventArgs) Handles rgMoneyTypeInformation.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgMoneyTypeInformation
        Rad_Utility.addColumnBound("MONEY_TYPE_ID", "MONEY_TYPE_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับ")
        Rad_Utility.addColumnBound("MONEY_TYPE_DESCRIPTION", "ชื่อรายการย่อย")
        Rad_Utility.addColumnBound("MONEY_AMOUNT", "ยอดยกมา", is_money:=True)
        Rad_Utility.addColumnIMG("E", "เพิ่มยอดยกมา", "E", 0, "คุณต้องการเพิ่มข้อมูลหรือไม่", img:=True, type_img:="edit")
    End Sub

    Private Sub rgMoneyTypeInformation_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rgMoneyTypeInformation.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("MONEY_TYPE_ID").Text
            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim url As String = "Frm_MoneyType_Information_Edit.aspx?id=" & id
            h2.Attributes.Add("OnClick", "return k('" & url & "');")

        End If
    End Sub

    Private Sub rgMoneyTypeInformation_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgMoneyTypeInformation.NeedDataSource
        rgMoneyTypeInformation.DataSource = dtMain
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgMoneyTypeInformation)
    End Sub
    Public Sub rg_rebind()
        rgMoneyTypeInformation.Rebind()
    End Sub
End Class