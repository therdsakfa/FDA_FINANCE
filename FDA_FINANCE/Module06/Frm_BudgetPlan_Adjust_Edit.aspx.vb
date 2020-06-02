Public Partial Class Frm_BudgetPlan_Adjust_Edit
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
            If Request.QueryString("ad") <> "" Then
                Dim dao As New DAO_BUDGET.TB_BUDGET_ADJUST
                Dim dao_d As New DAO_BUDGET.TB_BUDGET_ADJUST_DETAIL
                dao_d.Getdata_by_BG_Adjust_ID(Request.QueryString("ad"))
                dao.Getdata_by_BUDGET_ADJUST_ID(Request.QueryString("ad"))
                UC_BudgetPlan_Adjust_Detail1.getdata(dao)
                UC_BudgetPlan_Adjust_Detail1.getdata_period(dao_d)

            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Request.QueryString("ad") <> "" Then
            Dim dao As New DAO_BUDGET.TB_BUDGET_ADJUST
            Dim dao_d As New DAO_BUDGET.TB_BUDGET_ADJUST_DETAIL
            dao.Getdata_by_BUDGET_ADJUST_ID(Request.QueryString("ad"))
            dao_d.Getdata_by_BG_Adjust_ID(Request.QueryString("ad"))
            UC_BudgetPlan_Adjust_Detail1.insert(dao)
            If dao_d.fields.ADJUST_DETAIL_ID = 0 Then
                UC_BudgetPlan_Adjust_Detail1.insert_period(dao_d)
                dao_d.fields.BUDGET_ADJUST_ID = Request.QueryString("ad")
                dao_d.insert()
            Else
                UC_BudgetPlan_Adjust_Detail1.insert_period(dao_d)
                dao_d.update()
            End If

            dao.update()


            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If
    End Sub
End Class