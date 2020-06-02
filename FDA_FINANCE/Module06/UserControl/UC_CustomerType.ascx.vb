Imports Telerik.Web.UI
Partial Public Class UC_CustomerType
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim ut_seq As New Radgrid_Utility
            rg_Customer_Type.Rebind()
            ut_seq.addSeqRG(rg_Customer_Type)
        End If
    End Sub
    ''' <summary>
    ''' กำหนดคอลัมน์ให้ radgrid ประเภทเจ้าหนี้
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rg_Customer_Type_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rg_Customer_Type.Init
        Dim rgCustomerType As RadGrid = rg_Customer_Type
        Dim dao_customer_type As New DAO_MAS.TB_MAS_CUSTOMER_TYPE
        Dim Rad_Utility As New Radgrid_Utility

        Rad_Utility.Rad = rg_Customer_Type
        Rad_Utility.addColumnBound("CUSTOMER_TYPE_ID", "CUSTOMER_TYPE_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่", width:=45)
        Rad_Utility.addColumnBound("CUSTOMER_TYPE", "ประเภทเจ้าหนี้")
        Rad_Utility.addColumnBound("VAT", "VAT")
        Rad_Utility.addColumnBound("TAX", "ภาษี")
        Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        'Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
        Rad_Utility.addColumnIMG("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
       
    End Sub

    ''' <summary>
    ''' กำหนดฟิลด์คำสั่งของ radgrid ประเภทเจ้าหนี้
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rg_Customer_Type_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_Customer_Type.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao_customer_type As New DAO_MAS.TB_MAS_CUSTOMER_TYPE
                dao_customer_type.Getdata_by_CUSTOMER_TYPE_ID(item("CUSTOMER_TYPE_ID").Text)
                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "ลบข้อมูลประเภทลูกหนี้ " & dao_customer_type.fields.CUSTOMER_TYPE, "MAS_CUSTOMER_TYPE", item("CUSTOMER_TYPE_ID").Text)
                dao_customer_type.delete()
                rg_Customer_Type.Rebind()
                'Response.Redirect("/Module06/Frm_CustomerType.aspx")
                'ElseIf e.CommandName = "E" Then
                '    Response.Redirect("/Module06/Frm_CustomerType_Edit.aspx?cusid=" & item("CUSTOMER_TYPE_ID").Text)
            End If


        End If
    End Sub

    Private Sub rg_Customer_Type_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_Customer_Type.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("CUSTOMER_TYPE_ID").Text
            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim url As String = "Frm_CustomerType_Edit.aspx?cusid=" & id
            h2.Attributes.Add("OnClick", "Popups2('" & url & "'); return false;")


        End If
    End Sub
    ''' <summary>
    ''' ดึงค่าประเภทเจ้าหนี้ใส่ radgrid
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rg_Customer_Type_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_Customer_Type.NeedDataSource
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable
        dt = bao.get_customer_type()

        rg_Customer_Type.DataSource = dt
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rg_Customer_Type)
    End Sub
    Public Sub rg_rebind()
        rg_Customer_Type.Rebind()
    End Sub
End Class