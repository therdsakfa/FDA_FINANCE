Public Class UC_Disburse_OutsideDebtor_Approve_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL)
        dao.fields.DEBTOR_TYPE_ID = 2
        Try
            dao.fields.EXPRESS_TYPE_ID = rd_express_type.SelectedValue
        Catch ex As Exception
            dao.fields.EXPRESS_TYPE_ID = 0
        End Try
    End Sub
    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL)
        If dao.fields.EXPRESS_TYPE_ID IsNot Nothing Then
            rd_express_type.SelectedValue = dao.fields.EXPRESS_TYPE_ID

        End If
    End Sub
End Class