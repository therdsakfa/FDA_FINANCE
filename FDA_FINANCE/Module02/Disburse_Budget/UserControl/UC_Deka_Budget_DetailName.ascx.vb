Public Class UC_Deka_Budget_DetailName
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            bind_ddBudgetType()
        End If
    End Sub

    Public Sub bind_ddBudgetType()
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.MASS

        dt = bao.get_deka_budget_type_name()

        '  dd_Budgetype.SelectedValue = 1
        dd_Budgetype.DataSource = dt
        dd_Budgetype.DataBind()

    End Sub

    Public Sub insert(ByRef dao As DAO_MAS.TB_MAS_DEKA_DETAIL_BUDGET)

        dao.fields.HEAD_ID = dd_Budgetype.SelectedValue
        dao.fields.DETAIL_NAME = txt_NameList.Text

    End Sub

    Public Sub clear_data()
        dd_Budgetype.SelectedValue = 1
        txt_NameList.Text = ""
    End Sub

    Public Sub getdata(ByRef dao As DAO_MAS.TB_MAS_DEKA_DETAIL_BUDGET)

        dd_Budgetype.SelectedValue = dao.fields.HEAD_ID
        txt_NameList.Text = dao.fields.DETAIL_NAME

    End Sub

    Public Function sendValue() As Integer
        Dim dd_Value As Integer = 0
        dd_Value = dd_Budgetype.SelectedValue

        Return dd_Value
    End Function

    Private Sub dd_Budgetype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_Budgetype.SelectedIndexChanged
        sendValue()
    End Sub
End Class