Public Class Frm_Welfare_Home
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
    'Public Function getBgYear() As Integer
    '    Dim bgYear As Integer = 0
    '    Dim dd_BudgetYear As DropDownList
    '    dd_BudgetYear = CType(Master.FindControl("dd_BudgetYear"), DropDownList)
    '    bgYear = dd_BudgetYear.SelectedValue
    '    Return bgYear
    'End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
        UC_Welfare_Home.BudgetYear = Request.QueryString("myear")
        UC_Welfare_Home.month_nm = dd_month.SelectedValue
        ' UC_Welfare_Home.rebindRg()
    End Sub

    Private Sub btn_Insert_Click(sender As Object, e As EventArgs) Handles btn_Insert.Click
        Response.Redirect("Frm_Welfare_Home_Insert.aspx?BUDGET_YEAR=" & Master.get_Year())
    End Sub

    Private Sub Frm_Welfare_Home_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Welfare_Home.bindseq()
    End Sub
    Private Sub dd_month_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_month.SelectedIndexChanged
        UC_Welfare_Home.rebindRg()
    End Sub
End Class