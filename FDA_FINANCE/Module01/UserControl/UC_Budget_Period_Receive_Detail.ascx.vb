Public Class UC_Budget_Period_Receive_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("ba_id") IsNot Nothing Then
                Dim dao_ad As New DAO_BUDGET.TB_BUDGET_ADJUST
                dao_ad.Getdata_by_BUDGET_ADJUST_ID(Request.QueryString("ba_id"))
                If dao_ad.fields.BUDGET_DEPARTMENT_MONEY IsNot Nothing Then
                    lb_Amount.Text = CDbl(dao_ad.fields.BUDGET_DEPARTMENT_MONEY).ToString("N")
                End If
            End If
        End If
    End Sub

    Public Sub set_date()
        Dim str_date As String = System.DateTime.Now.ToShortDateString()
        txt_DOC_DATE.Text = str_date
        txt_EXPORT_DATE.Text = str_date
    End Sub

    Public Sub insert(ByRef dao As DAO_BUDGET.TB_BUDGET_ADJUST_DETAIL)
        If txt_EXPORT_DATE.Text <> "" Then
            dao.fields.ACTIVE_DATE = CDate(txt_EXPORT_DATE.Text)
            dao.fields.EXPORT_DATE = CDate(txt_EXPORT_DATE.Text)
        Else
            dao.fields.ACTIVE_DATE = Nothing
        End If
        dao.fields.BUDGET_ADJUST_ID = Request.QueryString("ba_id")
        dao.fields.COUNT = txt_COUNT.Text
        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text
        If txt_DOC_DATE.Text <> "" Then
            dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text)
        Else
            dao.fields.DOC_DATE = Nothing
        End If
        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        dao.fields.PERIOD_COUNT = txt_PERIOD_COUNT.Text
        dao.fields.SUB_DEPARTMENT_NAME = txt_SUB_DEPARTMENT_NAME.Text
    End Sub

    Public Sub getdata(ByRef dao As DAO_BUDGET.TB_BUDGET_ADJUST_DETAIL)
        If dao.fields.ACTIVE_DATE IsNot Nothing Then
            txt_EXPORT_DATE.Text = CDate(dao.fields.ACTIVE_DATE).ToShortDateString()
        End If
        If dao.fields.COUNT IsNot Nothing Then
            txt_COUNT.Text = dao.fields.COUNT
        End If
        If dao.fields.DESCRIPTION IsNot Nothing Then
            txt_DESCRIPTION.Text = dao.fields.DESCRIPTION
        End If
        If dao.fields.DOC_DATE IsNot Nothing Then
            txt_DOC_DATE.Text = CDate(dao.fields.DOC_DATE).ToShortDateString()
        End If
        If dao.fields.DOC_NUMBER IsNot Nothing Then
            txt_DOC_NUMBER.Text = dao.fields.DOC_NUMBER
        End If
        If dao.fields.PERIOD_COUNT IsNot Nothing Then
            txt_PERIOD_COUNT.Text = dao.fields.PERIOD_COUNT
        End If
        If dao.fields.SUB_DEPARTMENT_NAME IsNot Nothing Then
            txt_SUB_DEPARTMENT_NAME.Text = dao.fields.SUB_DEPARTMENT_NAME
        End If
    End Sub
End Class