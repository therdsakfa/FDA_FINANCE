Imports Telerik.Web.UI
Partial Public Class UC_Welfares
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' กำหนดคอลัมน์ให้ radgrid ประเภทสวัสดิการ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rgWelfare_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgWelfare.Init

        Dim rg_Welfare As RadGrid = rgWelfare
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgWelfare
        Rad_Utility.addColumnBound("WELFARE_ID", "WELFARE_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("WELFARE_TYPE_CODE", "รหัสสวัสดิการ")
        Rad_Utility.addColumnBound("WELFARE_TYPE_DESCRIPTION", "ชื่อสวัสดิการ")
        Rad_Utility.addColumnBound("WELFARE_TYPE_SHORT_DESCRIPTION", "ชื่อย่อ")
        Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        'Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
        Rad_Utility.addColumnIMG("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
    End Sub
    ''' <summary>
    ''' กำหนดฟิลด์คำสั่ง radgrid ประเภทสวัสดิการ
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rgWelfare_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgWelfare.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao_welfare As New DAO_MAS.TB_MAS_WELFARE
                dao_welfare.Getdata_by_WELFARE_ID(item("WELFARE_ID").Text)
                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "ลบข้อมูลประเภทสวัสดิการ " & dao_welfare.fields.WELFARE_TYPE_DESCRIPTION, "MAS_WELFARE", item("WELFARE_ID").Text)
                dao_welfare.delete()
                rgWelfare.Rebind()
                ' Response.Redirect("/Module06/Frm_Welfare.aspx")
                'ElseIf e.CommandName = "E" Then
                '    Response.Redirect("/Module06/Frm_Welfare_Edit.aspx?wid=" & item("WELFARE_ID").Text)
            End If

        End If
    End Sub

    Private Sub rgWelfare_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgWelfare.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("WELFARE_ID").Text
            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim url As String = "Frm_Welfare_Edit.aspx?wid=" & id
            h2.Attributes.Add("OnClick", "return k('" & url & "');")


        End If
    End Sub
    ''' <summary>
    ''' ดึงข้อมูลประเภทสวัสดิการใส่ radgrid
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rgWelfare_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgWelfare.NeedDataSource
        Dim dao_welfare As New DAO_MAS.TB_MAS_WELFARE
        dao_welfare.Getdata()
        Dim dt_Welfare As DataTable = dao_welfare.dt
        rgWelfare.DataSource = dt_Welfare
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgWelfare)
    End Sub
    Public Sub rg_rebind()
        rgWelfare.Rebind()
    End Sub
End Class