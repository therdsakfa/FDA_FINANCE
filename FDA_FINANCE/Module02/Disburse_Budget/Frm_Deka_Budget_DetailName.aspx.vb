Imports Telerik.Web.UI

Public Class Frm_Deka_Budget_DetailName
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_ProjectList_Init(sender As Object, e As EventArgs) Handles rg_list.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_list
        Rad_Utility.Rad_css_setting(rg_list)

        Rad_Utility.addColumnBound("IDA", "IDA", False)
        Rad_Utility.addColumnBound("HEAD_ID", "HEAD_ID", False)
        Rad_Utility.addColumnBound("RowNumber", "ลำดับ", width:=10)
        Rad_Utility.addColumnBound("BUDGET_NAMELIST", "หมวดค่าใช้จ่าย", width:=150)
        Rad_Utility.addColumnBound("DETAIL_NAME", "รายการซื้อ/จ้าง", width:=150)

        Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "", img:=True, type_img:="edit", width:=12, headertext:="แก้ไขข้อมูล")
        Rad_Utility.addColumnIMG("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete", width:=12, headertext:="ลบข้อมูล")

    End Sub

    Private Sub rg_ProjectList_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_list.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim _Id As Integer = item("IDA").Text
                Dim dao_delete As New DAO_MAS.TB_MAS_DEKA_DETAIL_BUDGET
                dao_delete.Getdata_by_ID(_Id)
                dao_delete.delete()
                rg_list.Rebind()

            ElseIf e.CommandName = "E" Then
                Dim _Id As Integer = item("IDA").Text
                hf_Id.Value = _Id
                Dim dao_edit As New DAO_MAS.TB_MAS_DEKA_DETAIL_BUDGET
                dao_edit.Getdata_by_ID(_Id)
                UC_Deka_Budget_DetailName.getdata(dao_edit)
            End If
        End If
    End Sub

    Private Sub rg_ProjectList_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_list.NeedDataSource

        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET

        Dim dd_year As Integer = 0
        dd_year = UC_Deka_Budget_DetailName.sendValue
        '  dt = bao.get_deka_budget_type_name_detail_by_headId(dd_year)
        dt = bao.get_deka_budget_type_name_detail()

        rg_list.DataSource = dt

    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_Add.Click

        Dim chk_id As String = ""
        chk_id = hf_Id.Value

        Dim ddl_list As Integer = 0
        Dim budget As String = ""
        Dim explan As String = ""

        If chk_id = "" Then

            Dim dao_insert As New DAO_MAS.TB_MAS_DEKA_DETAIL_BUDGET
            UC_Deka_Budget_DetailName.insert(dao_insert)

            dao_insert.insert()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อยแล้ว');parent.$('ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
            UC_Deka_Budget_DetailName.clear_data()
            hf_Id.Value = ""
            rg_list.Rebind()
      
        Else

            Dim dao_edit As New DAO_MAS.TB_MAS_DEKA_DETAIL_BUDGET
            dao_edit.Getdata_by_ID(chk_id)
            UC_Deka_Budget_DetailName.insert(dao_edit)

            dao_edit.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขข้อมูลเรียบร้อยแล้ว');parent.$('ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
            UC_Deka_Budget_DetailName.clear_data()
            hf_Id.Value = ""
            rg_list.Rebind()
           
        End If

    End Sub

    Private Sub btn_redirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        rg_list.DataBind()
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        UC_Deka_Budget_DetailName.clear_data()
        hf_Id.Value = ""
    End Sub


End Class