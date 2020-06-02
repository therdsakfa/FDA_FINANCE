Imports Telerik.Web.UI
Partial Public Class UC_Bank
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load  
        If Not IsPostBack Then
            Dim ut_seq As New Radgrid_Utility
            rg_Bank.Rebind()
            ut_seq.addSeqRG(rg_Bank)
        End If

    End Sub

    ''' <summary>
    ''' กำหนดชื่อคอลัมน์ของตารางธนาคาร
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rg_Bank_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rg_Bank.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_Bank
        Rad_Utility.addColumnBound("BANK_ID", "BANK_ID", False, width:=10)
        Rad_Utility.addColumnBound("id", "ลำดับที่", width:=15)
        Rad_Utility.addColumnBound("BANK_NAME", "ชื่อธนาคาร")
        Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        Rad_Utility.addColumnIMG("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
        ' Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
    End Sub

    ''' <summary>
    ''' กำหนดคำสั่งให้กับ radgrid
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rg_Bank_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_Bank.ItemCommand

        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao_bank As New DAO_MAS.TB_MAS_BANK
                dao_bank.Getdata_by_BANK_ID(item("BANK_ID").Text)
                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), Request.Url.AbsoluteUri.ToString(), "ลบข้อมูลธนาคารชื่อ " & dao_bank.fields.BANK_NAME, "MAS_BANK", item("BANK_ID").Text)

                dao_bank.delete()
                rg_Bank.Rebind()
              
            End If
        End If
    End Sub

    Private Sub rg_Bank_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_Bank.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("BANK_ID").Text
            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim url As String = "Frm_Bank_Edit.aspx?bank_id=" & id
            h2.Attributes.Add("OnClick", "Popups2('" & url & "'); return false;")
        End If
    End Sub

    ''' <summary>
    ''' ดึงข้อมูลจากตารางธนาคาร
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rg_Bank_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_Bank.NeedDataSource
        Dim dao_bank As New DAO_MAS.TB_MAS_BANK
        dao_bank.Getdata()
        Dim dt_Welfare As DataTable = dao_bank.dt
        rg_Bank.DataSource = dt_Welfare
    End Sub
    Public Sub rg_rebind()
        rg_Bank.Rebind()
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rg_Bank)

    End Sub
End Class