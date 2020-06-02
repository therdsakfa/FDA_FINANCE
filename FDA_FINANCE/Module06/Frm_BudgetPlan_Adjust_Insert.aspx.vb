Public Partial Class Frm_BudgetPlan_Adjust_Insert
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
        If Not IsPostBack Then
            UC_BudgetPlan_Adjust_Detail1.bind_ddl_dept()
            If Request.QueryString("bgid") IsNot Nothing Then
                Dim dao As New DAO_MAS.TB_BUDGET_PLAN
                dao.Getdata_by_BUDGET_PLAN_ID(Request.QueryString("bgid"))
                If dao.fields.BUDGET_TYPE_ID < 6 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เลือกงบไม่ถูกต้อง');", True)
                End If
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("Frm_BudgetPlan_Adjust.aspx")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim dao As New DAO_BUDGET.TB_BUDGET_ADJUST
        Dim dao_d As New DAO_BUDGET.TB_BUDGET_ADJUST_DETAIL
        UC_BudgetPlan_Adjust_Detail1.insert(dao)
        UC_BudgetPlan_Adjust_Detail1.insert_period(dao_d)
        dao.insert()

        dao_d.fields.BUDGET_ADJUST_ID = dao.fields.BUDGET_ADJUST_ID
        dao_d.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)

    End Sub
End Class