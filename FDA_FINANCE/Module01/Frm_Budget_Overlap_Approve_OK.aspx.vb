Public Class Frm_Budget_Overlap_Approve_OK
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        'Try
        '    _CLS = Session("CLS")
        'Catch ex As Exception
        '    Response.Redirect("http://privus.fda.moph.go.th/")
        'End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        Session("dept") = 1
        Dim bgYear As Integer = getbgYear()
        If Not IsPostBack Then
            Dim bao_adjust As New BAO_BUDGET.Budget
            Dim dt As DataTable = bao_adjust.get_bg_adjust_by_dept_year(CInt(Session("dept")), bgYear)
            If dt.Rows.Count > 0 Then
                dd_BudgetAdjust.DataSource = dt
                dd_BudgetAdjust.DataBind()

            End If
        End If
        UC_Budget_Overlap_Approve_OK1.BudgetID = dd_BudgetAdjust.SelectedValue
        UC_Budget_Overlap_Approve_OK1.Budgetyear = bgYear
        UC_Budget_Amount_Detail1.BudgetplanId = dd_BudgetAdjust.SelectedValue
        UC_Budget_Amount_Detail1.dept = CInt(Session("dept"))
        UC_Budget_Amount_Detail1.Budgetyear = bgYear
        UC_Budget_Amount_Detail1.getData_detail(dd_BudgetAdjust.SelectedValue, CInt(Session("dept")), bgYear)
    End Sub
    Public Function getbgYear() As Integer
        Dim bgYear As Integer = 0
        Dim dd_BudgetYear As DropDownList
        dd_BudgetYear = CType(Master.FindControl("dd_BudgetYear"), DropDownList)
        bgYear = dd_BudgetYear.SelectedValue
        Return bgYear
    End Function
    'Private Sub dd_BudgetAdjust_TextChanged(sender As Object, e As EventArgs) Handles dd_BudgetAdjust.TextChanged
    '    UC_Budget_Overlap_Approve_OK1.rebind_grid()
    'End Sub
End Class