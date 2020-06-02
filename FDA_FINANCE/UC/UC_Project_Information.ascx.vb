Public Class UC_Project_Information
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        set_lb()
    End Sub
    Sub set_lb()
        Dim dao1 As New DAO_MAS.TB_BUDGET_PLAN
        Dim dao2 As New DAO_MAS.TB_BUDGET_PLAN
        Try
            dao1.Getdata_by_BUDGET_PLAN_ID(Request.QueryString("bgid"))
        Catch ex As Exception

        End Try
        Try
            dao2.Getdata_by_BUDGET_PLAN_ID(dao1.fields.BUDGET_CHILD_ID)
        Catch ex As Exception

        End Try
        lb_proj_name.Text = dao2.fields.BUDGET_DESCRIPTION
        lb_year.Text = Request.QueryString("myear")
        Try
            lb_code.Text = dao2.fields.BUDGET_CODE
        Catch ex As Exception

        End Try
    End Sub
End Class