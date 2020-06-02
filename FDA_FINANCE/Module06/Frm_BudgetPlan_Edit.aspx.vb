Public Partial Class Frm_BudgetPlan_Edit
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        Dim bgyear As Integer = Request.QueryString("bgyear")
        If Not IsPostBack Then
            If Request.QueryString("id") <> "" Then
                Dim dao As New DAO_MAS.TB_BUDGET_PLAN
                dao.Getdata_by_BUDGET_PLAN_ID(Request.QueryString("id"))
                UC_Budgetplan_Detail1.getdata(dao)
                UC_Budgetplan_Detail1.bgyear = bgyear
            End If
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'Response.Redirect("Frm_BudgetPlan.aspx")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim dao As New DAO_MAS.TB_BUDGET_PLAN
        Dim id As Integer = Request.QueryString("id")
        dao.Getdata_by_BUDGET_PLAN_ID(id)
        Dim old_data As String = dao.fields.BUDGET_DESCRIPTION
        Dim new_data As String = ""
        UC_Budgetplan_Detail1.update(dao)
        
        dao.update()
        new_data = dao.fields.BUDGET_DESCRIPTION
        Dim log As New log_event.log
        log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลขางบจาก " & old_data & " เป็น " & new_data, "BUDGET_PLAN", Request.QueryString("id"))
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        'Response.Redirect("Frm_BudgetPlan.aspx")
    End Sub
End Class