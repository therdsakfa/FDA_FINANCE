Public Class UC_Disburse_Budget_Deeka_Number_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)
        dao.fields.DEEKA_NUMBER = txt_Deeka_number.Text
        Try
            dao.fields.DEEKA_DATE = CDate(txt_Deeka_DATE.Text)
        Catch ex As Exception
            dao.fields.DEEKA_DATE = Nothing
        End Try

    End Sub
    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)
        txt_Deeka_number.Text = dao.fields.DEEKA_NUMBER

        Try
            txt_Deeka_DATE.Text = CDate(dao.fields.DEEKA_DATE).ToShortDateString()
        Catch ex As Exception

        End Try
    End Sub
End Class