Public Partial Class UC_Budget_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub getdata(ByVal depkey As Integer)
        'Dim get_adjust As New BAO_BUDGET.Budget
        'Dim dt As DataTable = get_adjust.get_BUDGET_ADJUST(depkey)
        'If dt.Rows.Count > 0 Then
        '    txt_BUDGET_DEPARTMENT_MONEY.Text = CDbl(dt(0)("BUDGET_DEPARTMENT_MONEY"))
        '    txt_DEPARTMENT_DESCRIPTION.Text = dt(0)("DEPARTMENT_DESCRIPTION")
        'End If
        
    End Sub
End Class