Imports Telerik.Web.UI

Public Class Frm_Budget_Add_Project
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txt_doc_date.Text = Date.Now.ToShortDateString()
            bind_ddl_dept()
            bind_ddl_bg()
            bind_ddl_plan()
            bind_ddl_product()
            bind_ddl_act()
            RadGrid1.Rebind()
        End If
    End Sub
    Public Sub bind_ddl_bg()
        Dim dao As New DAO_MAS.TB_BUDGET_PLAN
        dao.Getdata_by_BG_YEAR(Request.QueryString("myear"))
        dd_BudgetYear.DataSource = dao.datas
        dd_BudgetYear.DataTextField = "BUDGET_DESCRIPTION"
        dd_BudgetYear.DataValueField = "BUDGET_PLAN_ID"
        dd_BudgetYear.DataBind()
    End Sub
    Public Sub bind_ddl_plan()
        Dim dao As New DAO_MAS.TB_BUDGET_PLAN
        Try
            dao.Getdata_by_head(dd_BudgetYear.SelectedValue)
            ddl_plan.DataSource = dao.datas
        Catch ex As Exception

        End Try

        ddl_plan.DataTextField = "BUDGET_DESCRIPTION"
        ddl_plan.DataValueField = "BUDGET_PLAN_ID"
        ddl_plan.DataBind()

    End Sub
    Public Sub bind_ddl_product()
        Dim dao As New DAO_MAS.TB_BUDGET_PLAN
        Try
            dao.Getdata_by_head(ddl_plan.SelectedValue)
            ddl_product.DataSource = dao.datas
        Catch ex As Exception

        End Try

        ddl_product.DataTextField = "BUDGET_DESCRIPTION"
        ddl_product.DataValueField = "BUDGET_PLAN_ID"
        ddl_product.DataBind()

    End Sub
    Public Sub bind_ddl_act()
        Dim dao As New DAO_MAS.TB_BUDGET_PLAN
        Try
            dao.Getdata_by_head(ddl_product.SelectedValue)
            ddl_act.DataSource = dao.datas
        Catch ex As Exception

        End Try

        ddl_act.DataTextField = "BUDGET_DESCRIPTION"
        ddl_act.DataValueField = "BUDGET_PLAN_ID"
        ddl_act.DataBind()

    End Sub
    Public Sub bind_ddl_dept()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_Department()
        dd_Department.DataSource = dt
        dd_Department.DataBind()
    End Sub
    Private Sub dd_BudgetYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_BudgetYear.SelectedIndexChanged
        bind_ddl_plan()
        bind_ddl_product()
        bind_ddl_act()
        RadGrid1.Rebind()
    End Sub

    Private Sub ddl_plan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_plan.SelectedIndexChanged
        bind_ddl_product()
        bind_ddl_act()
        RadGrid1.Rebind()
    End Sub

    Private Sub ddl_product_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_product.SelectedIndexChanged
        bind_ddl_act()
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_Init(sender As Object, e As EventArgs) Handles RadGrid1.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = RadGrid1
        Rad_Utility.Rad_css_setting(RadGrid1)
        Rad_Utility.addColumnBound("BUDGET_PLAN_ID", "BUDGET_PLAN_ID", False)
        Rad_Utility.addColumnBound("BUDGET_CODE", "รหัสโครงการ/กิจกรรม")
        Rad_Utility.addColumnBound("BUDGET_DESCRIPTION", "ชื่อโครงการ/กิจกรรม", width:=600)
        'Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "หน่วยงาน")
        Rad_Utility.addColumnButton("act", "เพิ่มกิจกรรมย่อย", "act", 0, "", width:=150)
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "act" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "Frm_Budget_Add_Activities.aspx?ida=" & item("BUDGET_PLAN_ID").Text & "&myear=" & Request.QueryString("myear") & "');", True)
            End If
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim BudgetBill As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As New DataTable
        'SC_get_Child_BG
        Try
            dt = BudgetBill.SC_get_Child_BG(ddl_act.SelectedValue)
        Catch ex As Exception

        End Try
        RadGrid1.DataSource = dt
    End Sub

    Private Sub ddl_act_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_act.SelectedIndexChanged
        RadGrid1.Rebind()
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim bao_max As New BAO_BUDGET.MASS
        Dim id_max As Integer = 0
        Try
            id_max = bao_max.get_max_id_budget_plan()
        Catch ex As Exception

        End Try
        Dim dao As New DAO_MAS.TB_BUDGET_PLAN
        dao.fields.BUDGET_CHILD_ID = ddl_act.SelectedValue
        dao.fields.BUDGET_AMOUNT = 0
        dao.fields.BUDGET_CODE = txt_bg_code.Text
        dao.fields.BUDGET_DESCRIPTION = txt_proj_name.Text
        dao.fields.BUDGET_IS_ENABLE = True
        dao.fields.BUDGET_IS_OVERLAP = Nothing
        dao.fields.BUDGET_MAIN_TYPE = 0
        dao.fields.BUDGET_TYPE_ID = 5
        dao.fields.BUDGET_YEAR = Request.QueryString("myear")
        dao.fields.BUDGET_PLAN_ID = id_max + 1
        dao.insert()
        Dim head_id As Integer = 0
        Try
            head_id = dao.fields.BUDGET_PLAN_ID
        Catch ex As Exception

        End Try
        Dim dao2 As New DAO_MAS.TB_BUDGET_PLAN_NODE
        dao2.fields.HEAD_ID = ddl_act.SelectedValue
        dao2.fields.CHILD_ID = head_id
        Try
            dao2.fields.BUDGET_YEAR = Request.QueryString("myear")
        Catch ex As Exception

        End Try
        dao2.insert()


        Dim bao_max2 As New BAO_BUDGET.MASS
        Dim id_max2 As Integer = 0
        Try
            id_max2 = bao_max.get_max_id_budget_plan()
        Catch ex As Exception

        End Try
        Dim dao3 As New DAO_MAS.TB_BUDGET_PLAN
        dao3.fields.BUDGET_CHILD_ID = head_id
        dao3.fields.BUDGET_AMOUNT = 0
        dao3.fields.BUDGET_CODE = Nothing
        dao3.fields.BUDGET_DESCRIPTION = DropDownList1.SelectedItem.Text
        dao3.fields.BUDGET_IS_ENABLE = True
        dao3.fields.BUDGET_IS_OVERLAP = Nothing
        dao3.fields.BUDGET_MAIN_TYPE = 0
        dao3.fields.BUDGET_TYPE_ID = 6
        dao3.fields.BUDGET_YEAR = Request.QueryString("myear")
        dao3.fields.BUDGET_PLAN_ID = id_max2 + 1
        dao3.insert()
        Dim head_id2 As Integer = 0
        Try
            head_id2 = dao3.fields.BUDGET_PLAN_ID
        Catch ex As Exception

        End Try
        Dim dao4 As New DAO_MAS.TB_BUDGET_PLAN_NODE
        dao4.fields.HEAD_ID = head_id
        dao4.fields.CHILD_ID = head_id2
        Try
            dao4.fields.BUDGET_YEAR = Request.QueryString("myear")
        Catch ex As Exception

        End Try
        dao4.insert()
        'Dim id_det4 As Integer = 0
        'Try

        'Catch ex As Exception

        'End Try
        Try
            Dim dao_ad As New DAO_BUDGET.TB_BUDGET_ADJUST
            Dim dao_d As New DAO_BUDGET.TB_BUDGET_ADJUST_DETAIL
            dao_ad.fields.BUDGET_DEPARTMENT_MONEY = RadNumericTextBox1.Value
            dao_ad.fields.BUDGET_PLAN_ID = head_id2
            dao_ad.fields.DEPARTMENT_ID = dd_Department.SelectedValue
            dao_ad.insert()


            If txt_doc_date.Text <> "" Then
                dao_d.fields.ACTIVE_DATE = CDate(txt_doc_date.Text)
                dao_d.fields.EXPORT_DATE = CDate(txt_doc_date.Text)
            Else
                dao_d.fields.ACTIVE_DATE = Nothing
            End If
            dao_d.fields.DESCRIPTION = "งวด 1"
            If txt_doc_date.Text <> "" Then
                dao_d.fields.DOC_DATE = CDate(txt_doc_date.Text)
            Else
                dao_d.fields.DOC_DATE = Nothing
            End If
            dao_d.fields.DOC_NUMBER = txt_DOC_NUMBER.Text

            dao_d.fields.BUDGET_ADJUST_ID = dao_ad.fields.BUDGET_ADJUST_ID
            dao_d.insert()
        Catch ex As Exception

        End Try


        Dim dept As Integer = 0
        Dim dao_dept_f As New DAO_FOLLOW_BG.TBL_MAS_DEPARTMENT_F
        Dim dao_dept As New DAO_MAS.TB_MAS_DEPARTMENT
        Try
            dao_dept.Getdata_by_DEPARTMENT_ID(dd_Department.SelectedValue)
        Catch ex As Exception

        End Try

        Try
            dao_dept_f.Getdata_by_code(dao_dept.fields.DEPARTMENT_CODE)
            dept = dao_dept_f.fields.IDA
        Catch ex As Exception

        End Try

        Dim dao_proj As New DAO_FOLLOW_BG.TB_MAS_PROJECT
        dao_proj.fields.BUDGET_YEAR = Request.QueryString("myear")
        dao_proj.fields.FK_BG_IDA = dao.fields.BUDGET_PLAN_ID
        dao_proj.fields.FK_IDA_DEPT = dept
        dao_proj.fields.PROJECT_NAME = txt_proj_name.Text
        dao_proj.insert()


        Dim bao_node As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt_node As New DataTable
        dt_node.Columns.Add("seq")
        dt_node.Columns.Add("BUDGET_DESCRIPTION")
        dt_node.Columns.Add("BUDGET_AMOUNT")
        dt_node.Columns.Add("BUDGET_PLAN_ID")
        dt_node = bao_node.getNodeBack_v2(dt_node, ddl_act.SelectedValue) '
        Dim dv As DataView = dt_node.DefaultView
        dv.Sort = "seq asc"
        dt_node = dv.ToTable


        For Each dr As DataRow In dt_node.Rows
            Dim dao_chk As New DAO_FOLLOW_BG.TABLE_TBL_PROJECT_ACTIVITY
            dao_chk.Getdata_by_fk_IDA2(dr("BUDGET_PLAN_ID"), dao_proj.fields.IDA)
            If dao_chk.fields.IDA = 0 Then
                Dim dao_in As New DAO_FOLLOW_BG.TABLE_TBL_PROJECT_ACTIVITY
                dao_in.fields.ACTIVITY_NAME = dr("BUDGET_DESCRIPTION")
                dao_in.fields.FK_BG_IDA = CInt(dr("BUDGET_PLAN_ID"))
                dao_in.fields.FLOOR_SEQ = CInt(dr("seq"))
                dao_in.fields.LAST_FLOOR = 0
                dao_in.fields.SEQ = CInt(dr("seq"))
                dao_in.fields.FK_ID_PROJ = dao_proj.fields.IDA
                dao_in.insert()
            End If
        Next

        Dim dao_in2 As New DAO_FOLLOW_BG.TABLE_TBL_PROJECT_ACTIVITY
        dao_in2.fields.ACTIVITY_NAME = txt_proj_name.Text
        dao_in2.fields.FLOOR_SEQ = 5
        dao_in2.fields.LAST_FLOOR = 0
        dao_in2.fields.SEQ = 5
        dao_in2.fields.FK_BG_IDA = dao.fields.BUDGET_PLAN_ID
        dao_in2.fields.FK_ID_PROJ = dao_proj.fields.IDA
        dao_in2.insert()

        'Dim dao_in3 As New DAO_FOLLOW_BG.TABLE_TBL_PROJECT_ACTIVITY
        'dao_in3.Getdata_by_ida(dao_in2.fields.IDA)


        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
        RadGrid1.Rebind()
    End Sub
End Class