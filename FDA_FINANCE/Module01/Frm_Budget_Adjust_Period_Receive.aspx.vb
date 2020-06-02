Public Class Frm_Budget_Adjust_Period_Receive
    Inherits System.Web.UI.Page
    Public bgYear As Integer
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
        bgYear = Master.get_Year()
        'If Not IsPostBack Then
        '    'bind_dl_department()
        '    'bind_dl_bg()
        '    set_uc()
        'End If
        UC_Budget_Period_Receive1.BudgetYear = bgYear
    End Sub
    Public Sub set_uc()
        'UC_Budget_Period_Receive1.BudgetID = dd_BudgetAdjust.SelectedValue

    End Sub
    'Public Sub bind_dl_department()
    '    Dim bao As New BAO_BUDGET.MASS
    '    Dim dt As DataTable = bao.get_Department()
    '    dd_Department.DataSource = dt
    '    dd_Department.DataBind()
    'End Sub
    'Public Sub bind_dl_bg()
    '    Dim bao_adjust As New BAO_BUDGET.Budget
    '    Dim dt As DataTable = bao_adjust.get_bg_adjust_by_dept_year(dd_Department.SelectedValue, Master.get_Year())

    '    If dt.Rows.Count > 0 Then
    '        For Each dr As DataRow In dt.Rows
    '            Dim dao_head As New DAO_MAS.TB_BUDGET_PLAN
    '            dao_head.Getdata_by_BUDGET_PLAN_ID(dr("BUDGET_CHILD_ID"))
    '            If dao_head.fields.BUDGET_CODE <> "" Then
    '                dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_CODE & "-" & dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
    '            Else
    '                dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
    '            End If

    '        Next

    '        dd_BudgetAdjust.DataSource = dt
    '        dd_BudgetAdjust.DataBind()


    '    End If
    '    ' UC_Disburse_Budget1.rebind_grid()
    'End Sub
    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        'bind_dl_bg()
        set_uc()
        UC_Budget_Period_Receive1.rebind_grid()
    End Sub
    'Private Sub dd_Department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_Department.SelectedIndexChanged
    '    ' bind_dl_bg()
    '    set_uc()
    '    UC_Budget_Period_Receive1.rebind_grid()
    'End Sub
    'Private Sub dd_BudgetAdjust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_BudgetAdjust.SelectedIndexChanged
    '    set_uc()
    '    UC_Budget_Period_Receive1.rebind_grid()
    'End Sub
End Class