Imports Telerik.Web.UI
Partial Public Class UC_BudgetPlan_Adjust
    Inherits System.Web.UI.UserControl
    'Private _dept_id As Integer
    'Public Property dept_id() As Integer
    '    Get
    '        Return _dept_id
    '    End Get
    '    Set(ByVal value As Integer)
    '        _dept_id = value
    '    End Set
    'End Property
    Private _budget_id As Integer
    Public Property budget_id() As Integer
        Get
            Return _budget_id
        End Get
        Set(ByVal value As Integer)
            _budget_id = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'rgBudgetAdjust.Rebind()
    End Sub

    '  Private dtMain As New DataTable


    Public Sub BindData()
        Dim bao As New BAO_BUDGET.Budget
        '    rgBudgetAdjust.DataSource = bao.get_BUDGET_ADJUST(budget_id)
        rgBudgetAdjust.Rebind()

    End Sub


    Private Sub rgBudgetAdjust_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgBudgetAdjust.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgBudgetAdjust

        Rad_Utility.addColumnBound("BUDGET_ADJUST_ID", "BUDGET_ADJUST_ID", False, width:=10)
        Rad_Utility.addColumnBound("id", "ลำดับที่", width:=15)
        Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "หน่วยงาน")
        Rad_Utility.addColumnBound("BUDGET_DEPARTMENT_MONEY", "จำนวนเงินที่ได้รับการจัดสรร", is_money:=True)
        'Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่")
        'Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
        Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        Rad_Utility.addColumnIMG("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
    End Sub

    Private Sub rgBudgetAdjust_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgBudgetAdjust.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao As New DAO_BUDGET.TB_BUDGET_ADJUST
                dao.Getdata_by_BUDGET_ADJUST_ID(item("BUDGET_ADJUST_ID").Text)
                dao.delete()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
                'Response.Redirect("Frm_BudgetPlan_Adjust.aspx")
                'ElseIf e.CommandName = "E" Then

                '    Dim dao As New DAO_BUDGET.TB_BUDGET_ADJUST
                '    dao.Getdata_by_BUDGET_ADJUST_ID(item("BUDGET_ADJUST_ID").Text)
                '    Response.Redirect("Frm_BudgetPlan_Adjust_Edit.aspx?ad=" & item("BUDGET_ADJUST_ID").Text & "&dept=" & dept_id & "&bgid=" & dao.fields.BUDGET_PLAN_ID)
            End If

        End If
    End Sub

    Private Sub rgBudgetAdjust_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgBudgetAdjust.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)


            Dim id As Integer = item("BUDGET_ADJUST_ID").Text
            Dim dao As New DAO_BUDGET.TB_BUDGET_ADJUST
            dao.Getdata_by_BUDGET_ADJUST_ID(id)
            'Dim url As String = "Frm_BudgetPlan_Adjust_Edit.aspx?ad=" & id & "&dept=" & dept_id & "&bgid=" & dao.fields.BUDGET_PLAN_ID
            Dim url As String = "Frm_BudgetPlan_Adjust_Edit.aspx?ad=" & id & "&bgid=" & dao.fields.BUDGET_PLAN_ID

            h2.Attributes.Add("OnClick", "return k('" & url & "');")


        End If
    End Sub

    Private Sub rgBudgetAdjust_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgBudgetAdjust.NeedDataSource
        Dim bao As New BAO_BUDGET.Budget
        ' rgBudgetAdjust.DataSource = bao.get_BUDGET_ADJUST(dept_id, budget_id)
        Dim dt As New DataTable
        dt = bao.get_BUDGET_ADJUST(budget_id)

        rgBudgetAdjust.DataSource = dt
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgBudgetAdjust)
        'rg_Disburse_Budget.Rebind()
    End Sub

    Public Sub rg_rebind()
        rgBudgetAdjust.Rebind()
    End Sub

End Class