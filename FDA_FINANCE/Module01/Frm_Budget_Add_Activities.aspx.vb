Public Class Frm_Budget_Add_Activities
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txt_end_date.Text = Date.Now.ToShortDateString()
            txt_startdate.Text = Date.Now.ToShortDateString()
            If Request.QueryString("IDA") <> "" Then
                Try
                    Dim dao As New DAO_MAS.TB_BUDGET_PLAN
                    dao.Getdata_by_BUDGET_PLAN_ID(Request.QueryString("IDA"))
                    lbl_proj_name.Text = dao.fields.BUDGET_DESCRIPTION
                Catch ex As Exception

                End Try


            End If
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao_f As New DAO_FOLLOW_BG.TABLE_TBL_PROJECT_ACTIVITY
        Dim dao_bg As New DAO_MAS.TB_BUDGET_PLAN_ACTIVITY
        dao_bg.fields.BUDGET_CHILD_ID = Request.QueryString("IDA")
        dao_bg.fields.BUDGET_YEAR = Request.QueryString("myear")
        Try
            dao_bg.fields.START_DATE = CDate(txt_startdate.Text)
        Catch ex As Exception

        End Try
        Try
            dao_bg.fields.END_DATE = CDate(txt_end_date.Text)
        Catch ex As Exception

        End Try

        dao_bg.fields.BUDGET_DESCRIPTION = txt_activity_name.Text
        dao_bg.insert()



        Dim dao_proj_f As New DAO_FOLLOW_BG.TB_MAS_PROJECT
        dao_proj_f.Getdata_by_fk_ida(Request.QueryString("IDA"))



        dao_f.fields.FK_BG_IDA = dao_bg.fields.BUDGET_PLAN_ID
        dao_f.fields.ACTIVITY_NAME = txt_activity_name.Text
        Try
            dao_f.fields.START_DATE = CDate(txt_startdate.Text)
        Catch ex As Exception

        End Try
        Try
            dao_f.fields.END_DATE = CDate(txt_end_date.Text)
        Catch ex As Exception

        End Try
        dao_f.fields.FLOOR_SEQ = 5
        dao_f.fields.LAST_FLOOR = 1
        dao_f.fields.SEQ = 6
        dao_f.fields.FK_ID_PROJ = dao_proj_f.fields.IDA
        dao_f.insert()


        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
        RadGrid1.Rebind()
    End Sub
    Private Sub RadGrid1_Init(sender As Object, e As EventArgs) Handles RadGrid1.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = RadGrid1
        Rad_Utility.Rad_css_setting(RadGrid1)
        Rad_Utility.addColumnBound("BUDGET_PLAN_ID", "BUDGET_PLAN_ID", False)
        ' Rad_Utility.addColumnBound("BUDGET_CODE", "รหัสโครงการ/กิจกรรม", width:=600)
        Rad_Utility.addColumnBound("BUDGET_DESCRIPTION", "ชื่อกิจกรรมย่อย")
        'Rad_Utility.addColumnButton("act", "เพิ่มกิจกรรมย่อย", "act", 0, "", width:=150)
    End Sub
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As New DataTable
        Try
            dt = bao.GET_BUDGET_PLAN_ACTIVITY_BY_FK(Request.QueryString("IDA"))
        Catch ex As Exception

        End Try

        RadGrid1.DataSource = dt
    End Sub
End Class