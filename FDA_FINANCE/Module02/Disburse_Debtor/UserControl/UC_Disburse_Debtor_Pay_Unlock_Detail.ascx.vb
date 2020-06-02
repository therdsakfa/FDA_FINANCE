Public Class UC_Disburse_Debtor_Pay_Unlock_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL)
        Try
            dao.fields.RETURN_APPROVE_DATE = CDate(txt_RETURN_APPROVE_DATE.Text)
        Catch ex As Exception
            dao.fields.RETURN_APPROVE_DATE = Nothing
        End Try

        dao.fields.RETURN_APPROVE_NUMBER = txt_RETURN_APPROVE_NUMBER.Text
    End Sub
    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL)
        Try
            txt_RETURN_APPROVE_DATE.Text = CDate(dao.fields.RETURN_APPROVE_DATE).ToShortDateString
        Catch ex As Exception
            txt_RETURN_APPROVE_DATE.Text = ""
        End Try

        txt_RETURN_APPROVE_NUMBER.Text = dao.fields.RETURN_APPROVE_NUMBER
    End Sub
    Public Sub insert_stat(ByVal bid As Integer, ByVal bt As Integer, ByVal iden As String, ByVal stat As Integer)
        Dim dao_app As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
        dao_app.fields.BILL_TYPE = bt
        dao_app.fields.DATE_ADD = Date.Now
        dao_app.fields.FK_IDA = bid
        dao_app.fields.IDENTITY_NUMBER = iden
        dao_app.fields.REASON_DATE = Date.Now
        dao_app.fields.STATUS_ID = stat
        dao_app.fields.GROUP_ID = Request.QueryString("g")

        dao_app.insert()
    End Sub
End Class