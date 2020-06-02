Imports Telerik.Web.UI
Partial Public Class UC_SendMoneyDepartments
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' กำหนดคอลัมน์ให้ radgrid หน่วยงานที่นำส่งเงิน
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rgSendMoney_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgSendMoney.Init
        Dim dao_send_money As New DAO_MAS.TB_MAS_SEND_MONEY_DEPARTMENT
        Dim rg_SendMoney As RadGrid = rgSendMoney
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgSendMoney
        Rad_Utility.addColumnBound("SEND_MONEY_DEPARTMENT_ID", "SEND_MONEY_DEPARTMENT_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("BANK_ACCOUNT", "เลขบัญชี")
        Rad_Utility.addColumnBound("DEPARTMENT_OR_BANK_NAME", "ชื่อธนาคาร/หน่วยงานที่นำส่งเงิน")
        Rad_Utility.addColumnBound("BRANCH_NAME", "สาขา")
        Rad_Utility.addColumnBound("SHORT_DEPARTMENT_NAME", "ชื่อย่อ")
        Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        'Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
        Rad_Utility.addColumnIMG("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
       
    End Sub
    ''' <summary>
    ''' กำหนดฟิลด์คำสั่ง radgrid หน่วยงานที่นำส่งเงิน
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rgSendMoney_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgSendMoney.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao_send_money As New DAO_MAS.TB_MAS_SEND_MONEY_DEPARTMENT
                dao_send_money.Getdata_by_SEND_MONEY_DEPARTMENT_ID(item("SEND_MONEY_DEPARTMENT_ID").Text)
                dao_send_money.delete()
                rgSendMoney.Rebind()
                'Response.Redirect("/Module06/Frm_SendMoneyDepartment.aspx")
                'ElseIf e.CommandName = "E" Then
                '    Response.Redirect("/Module06/Frm_SendMoneyDepartment_Edit.aspx?sid=" & item("SEND_MONEY_DEPARTMENT_ID").Text)
            End If

        End If
    End Sub

    Private Sub rgSendMoney_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgSendMoney.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("SEND_MONEY_DEPARTMENT_ID").Text
            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim url As String = "Frm_SendMoneyDepartment_Edit.aspx?sid=" & id
            h2.Attributes.Add("OnClick", "return k('" & url & "');")


        End If
    End Sub
    ''' <summary>
    ''' ดึงข้อมูลหน่วยงานที่นำส่งเงินใส่ radgrid
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rgSendMoney_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgSendMoney.NeedDataSource
        Dim dao_send_money As New DAO_MAS.TB_MAS_SEND_MONEY_DEPARTMENT
        Dim Rad_Utility As New Radgrid_Utility
        dao_send_money.Getdata()
        Dim dt_send_money As DataTable = dao_send_money.dt
        rgSendMoney.DataSource = dt_send_money


    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgSendMoney)
    End Sub
    Public Sub rg_rebind()
        rgSendMoney.Rebind()
    End Sub
End Class