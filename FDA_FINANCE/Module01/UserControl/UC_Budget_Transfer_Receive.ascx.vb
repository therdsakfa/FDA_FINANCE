Imports Telerik.Web.UI
Partial Public Class UC_Budget_Transfer_Receive
    Inherits System.Web.UI.UserControl
    Private _bgyear As Integer
    Public Property bgyear() As Integer
        Get
            Return _bgyear
        End Get
        Set(ByVal value As Integer)
            _bgyear = value
        End Set
    End Property
    Private _user As String
    Public Property user() As String
        Get
            Return _user
        End Get
        Set(ByVal value As String)
            _user = value
        End Set
    End Property
    Private _dept_id As Integer
    Public Property dept_id() As Integer
        Get
            Return _dept_id
        End Get
        Set(ByVal value As Integer)
            _dept_id = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgTransfer_receive_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgTransfer_receive.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgTransfer_receive
        Rad_Utility.addColumnIMG("img", "การอนุมัติ")
        Rad_Utility.addColumnBound("BUDGET_TRANSFER_ID", "BUDGET_TRANSFER_ID", False)
        Rad_Utility.addColumnDate("BUDGET_TRANSFER_DATE", "วันที่ทำรายการ")
        Rad_Utility.addColumnBound("BUDGET_TRANSFER_DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("BUDGET_TRANSFER_DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("OUTSIDE_DEPARTMENT_NAME", "หน่วยงานภายนอกที่โอน")
        'Rad_Utility.addColumnBound("t_type", "ประเภทการโอน")
        Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "หน่วยงานที่รับโอน")
        Rad_Utility.addColumnBound("BUDGET_DESCRIPTION", "งบค่าใช้จ่าย")
        'Rad_Utility.addColumnBound("BUDGET_TRANSFER_COUNT", "ครั้งที่โอน")
        Rad_Utility.addColumnBound("BUDGET_TRANSFER_AMOUNT", "จำนวนเงินที่รับโอน", is_money:=True)
        'Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        'Rad_Utility.addColumnIMG("Delete", "ลบ", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "", width:=120)
        Rad_Utility.addColumnButton("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", width:=120)
    End Sub

    Private Sub rgTransfer_receive_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgTransfer_receive.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            'If e.CommandName = "T" Then

            '    Response.Redirect("/Module01/Frm_Budget_Transfer_Receive_Insert.aspx?dept=" & item("DEPARTMENT_ID").Text)


            'End If
            If e.CommandName = "Delete" Then
                ' del_item(item("BUDGET_DISBURSE_BILL_ID").Text)
                Dim dao_head As New DAO_BUDGET.TB_BUDGET_TRANSFER
                dao_head.Getdata_by_BUDGET_TRANSFER_ID(item("BUDGET_TRANSFER_ID").Text)
                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "ลบรายการรับโอนหน่วยงานภายนอกเลขหนังสือ " & _
                               dao_head.fields.BUDGET_TRANSFER_DOC_NUMBER, "BUDGET_TRANSFER", item("BUDGET_TRANSFER_ID").Text)
                dao_head.delete()

                rgTransfer_receive.Rebind()
                ' Response.Redirect("/Module02/Disburse_Budget/Frm_Disburse_Budget.aspx")
            End If
        End If
    End Sub

    Private Sub rgTransfer_receive_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgTransfer_receive.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("BUDGET_TRANSFER_ID").Text
            'Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim h2 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            Dim url As String = ""
            If user = "" Then
                url = "../Module01/Frm_Budget_Transfer_Receive_Edit.aspx?id=" & id & "&bgYear=" & bgyear
            Else
                url = "../Module01/Frm_Budget_Transfer_Receive_User_Edit.aspx?id=" & id & "&bgYear=" & bgyear & "&dept=" & dept_id
            End If

            h2.Attributes.Add("OnClick", "Popups2('" & url & "'); return false;")
            'h2.Attributes.Add("OnClick", "return k('" & url & "');")
            Dim img As Image = DirectCast(item("img").Controls(0), Image)

            Dim dao As New DAO_BUDGET.TB_BUDGET_TRANSFER
            dao.Getdata_by_BUDGET_TRANSFER_ID(id)
            If dao.fields.IS_APPROVE IsNot Nothing Then
                If dao.fields.IS_APPROVE = True Then
                    img.ImageUrl = "~/images/cb.png"
                Else
                    img.ImageUrl = "~/images/emp_cb.png"
                End If
            Else
                img.ImageUrl = "~/images/emp_cb.png"
            End If
        End If
    End Sub

    Private Sub rgTransfer_receive_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgTransfer_receive.NeedDataSource
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As New DataTable
        If user = "" Then
            dt = bao.get_transfer_receive(bgyear)
        Else
            dt = bao.get_transfer_receive_user(bgyear, dept_id)
        End If

        rgTransfer_receive.DataSource = dt
    End Sub
    Public Sub rg_rebind()
        rgTransfer_receive.Rebind()
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgTransfer_receive, str)
    End Sub
End Class