Public Partial Class UC_Budget_CarryMoney_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub insert(ByRef dao As DAO_MAS.TB_OVERLAP_HEAD)
        dao.fields.OVERLAP_AMOUNT = txt_OVERLAP_AMOUNT.Text
        dao.fields.OVERLAP_HEAD_DOC_DATE = rdp_OVERLAP_HEAD_DOC_DATE.SelectedDate
        'dao.fields.BUDGET_PLAN_ID = 
        'dao.fields.DEPARTMENT_ID = 
    End Sub
    Public Sub getdata(ByRef dao As DAO_MAS.TB_OVERLAP_HEAD)
        txt_OVERLAP_AMOUNT.Text = dao.fields.OVERLAP_AMOUNT
        rdp_OVERLAP_HEAD_DOC_DATE.SelectedDate = dao.fields.OVERLAP_HEAD_DOC_DATE
        'dao.fields.BUDGET_PLAN_ID = 
        'dao.fields.DEPARTMENT_ID = 
    End Sub
End Class