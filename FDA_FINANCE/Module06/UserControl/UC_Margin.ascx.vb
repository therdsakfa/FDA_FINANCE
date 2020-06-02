Imports Telerik.Web.UI

Public Class UC_Margin
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub rgMargin_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgMargin.Init
        Dim dao_money_receiver As New DAO_MAS.TB_MAS_MONEY_RECEIVER
        Dim rg_MoneyReceiver As RadGrid = rgMargin
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgMargin
        Rad_Utility.addColumnBound("ID_RUN", "ID_RUN", False)
        'Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnDate("DO_DATE", "วันที่")
        Rad_Utility.addColumnBound("DESCRIPITON", "รายละเอียด")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True) '
        'txt_dotype
        Rad_Utility.addColumnBound("txt_dotype", "ประเภท")
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
    Private Sub rgMargin_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgMargin.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao_money_receiver As New DAO_MAS.TB_MAS_MARGIN_RECEIVE
                dao_money_receiver.Getdata_by_ID_RUN(item("ID_RUN").Text)
                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "ลบข้อมูลเงินทดรอง " & dao_money_receiver.fields.DESCRIPITON, "MAS_MARGIN_RECEIVE", item("ID_RUN").Text)
                dao_money_receiver.delete()
                rgMargin.Rebind()

            End If

        End If
    End Sub

    Private Sub rgMoneyReceiver_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgMargin.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("ID_RUN").Text
            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim url As String = "Frm_Margin_Receive_Edit.aspx?id=" & id
            h2.Attributes.Add("OnClick", "return k('" & url & "');")


        End If
    End Sub

    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgMargin)
    End Sub
    Public Sub rg_rebind()
        rgMargin.Rebind()
    End Sub

    Private Sub rgMargin_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgMargin.NeedDataSource
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_margin_receive

        rgMargin.DataSource = dt
    End Sub
End Class