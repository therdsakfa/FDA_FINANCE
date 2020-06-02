Imports Telerik.Web.UI
Partial Public Class UC_PayLists
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' กำหนดคอลัมน์ให้ radgrid ค่าใช้จ่าย
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rgPayList_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgPayList.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgPayList
        Rad_Utility.addColumnBound("PATLIST_ID", "PATLIST_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("PAYLIST_DESCRIPTION", "ค่าใช้จ่าย")
        Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        '  Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
        Rad_Utility.addColumnIMG("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
        'Dim rgPayList As RadGrid = UC_PayLists1.FindControl("rgPayList")
      
    End Sub
    ''' <summary>
    ''' กำหนดฟิลด์คำสั่งให้ radgrid ค่าใช้จ่าย
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rgPayList_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgPayList.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao_paylist As New DAO_MAS.TB_MAS_PAYLIST
                dao_paylist.Getdata_by_PAYLIST_ID(item("PATLIST_ID").Text)
                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "ลบข้อมูลประเภทค่าใช้จ่าย " & dao_paylist.fields.PAYLIST_DESCRIPTION, "MAS_PAYLIST", item("PATLIST_ID").Text)
                dao_paylist.delete()
                rgPayList.Rebind()
                ' Response.Redirect("/Module06/Frm_PayList.aspx")
                'ElseIf e.CommandName = "E" Then
                '    Response.Redirect("/Module06/Frm_PayList_Edit.aspx?pid=" & item("PATLIST_ID").Text)
            End If
        End If
    End Sub

    Private Sub rgPayList_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgPayList.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("PATLIST_ID").Text
            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim url As String = "../Module06/Frm_PayList_Edit.aspx?pid=" & id
            h2.Attributes.Add("OnClick", "return k('" & url & "');")


        End If
    End Sub
    ''' <summary>
    ''' ดึงข้อมูลค่าใช้จ่ายใส่ radgrid
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rgPayList_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgPayList.NeedDataSource
        Dim dao_PayList As New DAO_MAS.TB_MAS_PAYLIST
        Dim Rad_Utility As New Radgrid_Utility
        dao_PayList.Getdata()
        Dim dt_PayList As DataTable = dao_PayList.dt
      
        rgPayList.DataSource = dt_PayList

    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgPayList)
    End Sub
    Public Sub rg_rebind()
        rgPayList.Rebind()
    End Sub
End Class