Public Class Frm_Budget_Type_Edit
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
        UC_Budget_Type_Detail1.BudgetYear = Request.QueryString("bgyear")
        If Not IsPostBack Then
            If Request.QueryString("id") <> "" Then
                Dim dao As New DAO_BUDGET.TB_MAS_BUDGET_TYPE
                dao.Getdata_by_BUDGET_TYPE_ID(Request.QueryString("id"))
                UC_Budget_Type_Detail1.getdata(dao)
            End If
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If Request.QueryString("id") <> "" Then
            Dim dao As New DAO_BUDGET.TB_MAS_BUDGET_TYPE
            Dim id As Integer = Request.QueryString("id")
            dao.Getdata_by_BUDGET_TYPE_ID(id)
            UC_Budget_Type_Detail1.update(dao)
            dao.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If
    End Sub
End Class