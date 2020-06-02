Public Class UC_Disburse_Debtor_Check_Number_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL)
        dao.fields.CHECK_NUMBER = txt_CHECK_NUMBER.Text
        If txt_CHECK_DATE.Text <> "" Then
            dao.fields.CHECK_DATE = CDate(txt_CHECK_DATE.Text)
        End If

    End Sub
    Public Sub insert_det(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL)
        dao.fields.CHECK_NUMBER = txt_CHECK_NUMBER.Text
        If txt_CHECK_DATE.Text <> "" Then
            dao.fields.CHECK_DATE = CDate(txt_CHECK_DATE.Text)
        End If

    End Sub
    Public Sub insert_margin(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL)
        dao.fields.CHECK_NUMBER = txt_CHECK_NUMBER.Text
        If txt_CHECK_DATE.Text <> "" Then
            dao.fields.CHECK_DATE = CDate(txt_CHECK_DATE.Text)
        End If

    End Sub
    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL)
        txt_CHECK_NUMBER.Text = dao.fields.CHECK_NUMBER
        If dao.fields.CHECK_DATE IsNot Nothing Then
            txt_CHECK_DATE.Text = CDate(dao.fields.CHECK_DATE).ToShortDateString()
        End If
    End Sub
    Public Sub getdata_margin(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL)
        txt_CHECK_NUMBER.Text = dao.fields.CHECK_NUMBER
        If dao.fields.CHECK_DATE IsNot Nothing Then
            txt_CHECK_DATE.Text = CDate(dao.fields.CHECK_DATE).ToShortDateString()
        End If
    End Sub

End Class