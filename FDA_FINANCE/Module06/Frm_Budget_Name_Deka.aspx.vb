Public Class Frm_Budget_Name_Deka
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_ddl_Headbudget()
            RadGrid1.Rebind()
        End If
    End Sub

    Public Sub bind_ddl_Headbudget()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_HEAD_BUDGET_NAME()
        dd_Head.DataSource = dt
        dd_Head.DataBind()
    End Sub

    Private Sub RadGrid1_Init(sender As Object, e As EventArgs) Handles RadGrid1.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = RadGrid1
        Rad_Utility.Rad_css_setting(RadGrid1)
        Rad_Utility.addColumnBound("IDA", "IDA", False)
        Rad_Utility.addColumnBound("HEAD_ID", "HEAD_ID", False)
        Rad_Utility.addColumnBound("SUB_CODE", "รหัสค่าใช้จ่าย")
        Rad_Utility.addColumnBound("DETAIL_NAME", "ชื่อค่าใช้จ่าย", width:=600)
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        Dim BudgetBill As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As New DataTable

        Try
            dt = BudgetBill.get_DEKA_DETAIL_BUDGET_DEKA(dd_Head.SelectedValue)
        Catch ex As Exception

        End Try

        RadGrid1.DataSource = dt

    End Sub

    Private Sub ddl_Head_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_Head.SelectedIndexChanged
        RadGrid1.Rebind()
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click

        Dim dao As New DAO_MAS.TB_MAS_DEKA_DETAIL_BUDGET
        dao.fields.HEAD_ID = dd_Head.SelectedValue
        dao.fields.DETAIL_NAME = txt_Name.Text
        dao.fields.SUB_CODE = txt_CODE_NUMBER.Text

        dao.insert()
       
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
        RadGrid1.Rebind()

    End Sub
End Class