Imports Telerik.Web.UI
Partial Public Class UC_Budget_Transfer_In
    Inherits System.Web.UI.UserControl
    Private _budget_id As Integer
    Public Property budget_id() As Integer
        Get
            Return _budget_id
        End Get
        Set(ByVal value As Integer)
            _budget_id = value
        End Set
    End Property
    Private _budget_year As Integer
    Public Property budget_year() As Integer
        Get
            Return _budget_year
        End Get
        Set(ByVal value As Integer)
            _budget_year = value
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
    Private _Is_outside_dept As Boolean
    Public Property Is_outside_dept() As Boolean
        Get
            Return _Is_outside_dept
        End Get
        Set(ByVal value As Boolean)
            _Is_outside_dept = value
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
   
    End Sub

    Private Sub rgTransferIn_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgTransferIn.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgTransferIn
        Rad_Utility.addColumnBound("BUDGET_TRANSFER_ID", "BUDGET_TRANSFER_ID", False)
        Rad_Utility.addColumnIMG("img", "การอนุมัติ")
        Rad_Utility.addColumnDate("BUDGET_TRANSFER_DATE", "วันที่ทำรายการ")
        Rad_Utility.addColumnBound("BUDGET_TRANSFER_DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("BUDGET_TRANSFER_DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("bg_from_des", "งบค่าใช้จ่าย")
        Rad_Utility.addColumnBound("dept_from", "หน่วยงานที่โอน")
        'Rad_Utility.addColumnBound("t_type", "ประเภทการโอน")
        Rad_Utility.addColumnBound("bg_to_des", "งบค่าใช้จ่ายที่รับโอน")
        Rad_Utility.addColumnBound("dept_to", "หน่วยงานที่รับโอน")
        'Rad_Utility.addColumnBound("BUDGET_TRANSFER_COUNT", "ครั้งที่โอน")
        Rad_Utility.addColumnBound("BUDGET_TRANSFER_AMOUNT", "จำนวนเงินที่ขอโอน", is_money:=True)
        'Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        'Rad_Utility.addColumnIMG("Delete", "ลบ", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "", width:=120)
        Rad_Utility.addColumnButton("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", width:=120)
    End Sub

    Private Sub rgTransferIn_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgTransferIn.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            'If e.CommandName = "T" Then
            '    If Is_outside_dept = False Then
            '        Response.Redirect("../Module01/Frm_Budget_Transfer_In_insert.aspx?dept=" & dept_id & "&bgid=" & item("BUDGET_PLAN_ID").Text)
            '    Else
            '        'Frm_Budget_Transfer_Outside_insert.aspx
            '        Response.Redirect("../Module01/Frm_Budget_Transfer_Outside_insert.aspx?dept=" & dept_id & "&bgid=" & item("BUDGET_PLAN_ID").Text)
            '    End If


            'End If

            If e.CommandName = "Delete" Then
                Dim dao_head As New DAO_BUDGET.TB_BUDGET_TRANSFER
                dao_head.Getdata_by_BUDGET_TRANSFER_ID(item("BUDGET_TRANSFER_ID").Text)

                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "ลบรายการโอนภายในเลขหนังสือ " & _
                               dao_head.fields.BUDGET_TRANSFER_DOC_NUMBER, "BUDGET_TRANSFER", item("BUDGET_TRANSFER_ID").Text)
                dao_head.delete()
                rgTransferIn.Rebind()
            End If
        End If
    End Sub

    Private Sub rgTransferIn_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgTransferIn.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("BUDGET_TRANSFER_ID").Text
            'Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim h2 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            Dim img As Image = DirectCast(item("img").Controls(0), Image)

            Dim url As String = ""
            If user = "" Then
                url = "../Module01/Frm_Budget_Transfer_In_Edit.aspx?id=" & id & "&bgYear=" & budget_year

            Else
                url = "../Module01/Frm_Budget_Transfer_In_User_Edit.aspx?id=" & id & "&bgYear=" & budget_year & "&dept=" & dept_id

            End If

            'h2.Attributes.Add("OnClick", "return k('" & url & "');")
            h2.Attributes.Add("OnClick", "Popups2('" & url & "'); return false;")

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

    Private Sub rgTransferIn_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgTransferIn.NeedDataSource
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As New DataTable
        If user = "" Then
            dt = bao.get_transfer_inside(budget_year)
        Else
            dt = bao.get_transfer_inside_user(budget_year, dept_id)
        End If
        rgTransferIn.DataSource = dt
    End Sub
    Public Function return_money_from(bgyear As Integer, bgid As Integer, deptid As Integer)
        Dim bao As New BAO_BUDGET.Budget
        Dim value As Double = 0
        value = bao.get_transfer_from_dept(bgyear, bgid, deptid)
        Return value
    End Function
    Public Function return_money_to(bgyear As Integer, bgid As Integer, deptid As Integer)
        Dim bao As New BAO_BUDGET.Budget
        Dim value As Double = 0
        value = bao.get_transfer_to_dept(bgyear, bgid, deptid)
        Return value
    End Function
    Public Sub rg_rebind()
        rgTransferIn.Rebind()
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgTransferIn, str)
    End Sub

End Class