Public Class UC_Budget_Transfer_Share_Type_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub insert(ByRef dao As DAO_BUDGET.TB_BUDGET_TRANSFER_DETAIL)
        dao.fields.BUDGET_TRANSFER_ID = Request.QueryString("tid")
        Try
            dao.fields.AMOUNT = txt_amount.Text
        Catch ex As Exception

        End Try

        dao.fields.TYPE_TRANSFER = rd_type.SelectedValue
    End Sub
    Public Sub update(ByRef dao As DAO_BUDGET.TB_BUDGET_TRANSFER_DETAIL)
        'dao.fields.BUDGET_TRANSFER_ID = Request.QueryString("tid")
        Try
            dao.fields.AMOUNT = txt_amount.Text
        Catch ex As Exception

        End Try

        dao.fields.TYPE_TRANSFER = rd_type.SelectedValue
    End Sub
    Public Sub getdata(ByRef dao As DAO_BUDGET.TB_BUDGET_TRANSFER_DETAIL)
        'dao.fields.BUDGET_TRANSFER_ID = Request.QueryString("tid")
        If dao.fields.AMOUNT IsNot Nothing Then
            txt_amount.Text = dao.fields.AMOUNT
        Else
            txt_amount.Text = 0
        End If

        If dao.fields.TYPE_TRANSFER IsNot Nothing Then
            rd_type.SelectedValue = dao.fields.TYPE_TRANSFER
        End If

    End Sub
End Class