Imports Telerik.Web.UI
Public Class UC_Reason_Reject
    Inherits System.Web.UI.UserControl

    Private _fk_ida As Integer
    Private _stat As Integer
    Private _bt As Integer
    Sub runQuery()
        _fk_ida = Request.QueryString("fk_ida")
        _bt = Request.QueryString("bt")
        Try
            _stat = Request.QueryString("stat")
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
    End Sub


    Private Sub rg_reason_Init(sender As Object, e As EventArgs) Handles rg_reason.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_reason
        Rad_Utility.addColumnBound("IDA", "IDA", False)
        Rad_Utility.addColumnBound("REASON", "ข้อความ")
        Rad_Utility.addColumnDate("REASON_DATE", "วันที่")
        Rad_Utility.addColumnIMG("Delete", "ลบ", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
    End Sub

    Private Sub rg_reason_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_reason.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
                dao.GetDataby_IDA(item("IDA").Text)
                dao.delete()
                rg_reason.Rebind()
            End If
        End If
    End Sub

    Private Sub rg_reason_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_reason.NeedDataSource
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_reason_by_fk_ida_bill_type_and_stat(_fk_ida, _bt, _stat)
        rg_reason.DataSource = dt
    End Sub

    Public Sub rg_rebind()
        rg_reason.Rebind()
    End Sub
End Class