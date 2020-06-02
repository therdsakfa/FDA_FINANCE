Imports Telerik.Web.UI
Partial Public Class UC_Recivers
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' กำหนดคอลัมน์ใหกับ radgrd ผู้รับเงิน
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rgMoneyReceiver_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgMoneyReceiver.Init
        Dim dao_money_receiver As New DAO_MAS.TB_MAS_MONEY_RECEIVER
        Dim rg_MoneyReceiver As RadGrid = rgMoneyReceiver
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgMoneyReceiver
        Rad_Utility.addColumnBound("RECEIVER_MONEY_ID", "RECEIVER_MONEY_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnCheckbox("IS_RECEIVER", "ผู้รับเงิน")
        Rad_Utility.addColumnBound("RECEIVER_NAME", "ชื่อ-นามสกุล")
        Rad_Utility.addColumnBound("POSITION_NAME", "ตำแหน่ง")
        Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        'Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
        Rad_Utility.addColumnIMG("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")

       
    End Sub
    ''' <summary>
    ''' กำหนดฟิลด์คำสั่งให้ radgrid คำสั่ง
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rgMoneyReceiver_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgMoneyReceiver.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao_money_receiver As New DAO_MAS.TB_MAS_MONEY_RECEIVER
                dao_money_receiver.Getdata_by_RECEIVER_MONEY_ID(item("RECEIVER_MONEY_ID").Text)
                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "ลบข้อมูลผู้รับเงิน " & dao_money_receiver.fields.RECEIVER_NAME, "MAS_MONEY_RECEIVER", item("RECEIVER_MONEY_ID").Text)
                dao_money_receiver.delete()
                rgMoneyReceiver.Rebind()
                'Response.Redirect("/Module06/Frm_Reciver.aspx")
                'ElseIf e.CommandName = "E" Then
                '    Response.Redirect("/Module06/Frm_Reciver_Edit.aspx?rc_id=" & item("RECEIVER_MONEY_ID").Text)
            End If

        End If
    End Sub

    Private Sub rgMoneyReceiver_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgMoneyReceiver.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("RECEIVER_MONEY_ID").Text
            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim url As String = "Frm_Reciver_Edit.aspx?rc_id=" & id
            h2.Attributes.Add("OnClick", "Popups2('" & url & "'); return false;")


        End If
    End Sub
    ''' <summary>
    ''' ดึงข้อมูลผู้รับเงินใส่ radgrid
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rgMoneyReceiver_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgMoneyReceiver.NeedDataSource
        Dim dao_money_receiver As New DAO_MAS.TB_MAS_MONEY_RECEIVER
        Dim Rad_Utility As New Radgrid_Utility
        dao_money_receiver.Getdata()
        Dim dt_money_receiver As DataTable = dao_money_receiver.dt
      
        rgMoneyReceiver.DataSource = dt_money_receiver
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgMoneyReceiver)
    End Sub
    Public Sub rg_rebind()
        rgMoneyReceiver.Rebind()
    End Sub
End Class