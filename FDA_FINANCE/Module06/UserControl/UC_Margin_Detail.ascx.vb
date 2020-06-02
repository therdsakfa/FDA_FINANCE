Public Class UC_Margin_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub insert(ByRef dao As DAO_MAS.TB_MAS_MARGIN_RECEIVE)
        dao.fields.AMOUNT = rnt_BUDGET_TYPE_AMOUNT.Value
        dao.fields.DESCRIPITON = txt_DESCRIPITON.Text
        Try
            dao.fields.DO_DATE = CDate(txt_DO_DATE.Text)
        Catch ex As Exception
            dao.fields.DO_DATE = Nothing
        End Try
        dao.fields.DO_TYPE = ddl_DO_TYPE.SelectedValue
    End Sub
    Public Sub getdata(ByRef dao As DAO_MAS.TB_MAS_MARGIN_RECEIVE)
        rnt_BUDGET_TYPE_AMOUNT.Value = dao.fields.AMOUNT
        txt_DESCRIPITON.Text = dao.fields.DESCRIPITON
        Try
            txt_DO_DATE.Text = CDate(dao.fields.DO_DATE)
        Catch ex As Exception
        End Try
        ddl_DO_TYPE.DataBind()
        ddl_DO_TYPE.DropDownSelectData(dao.fields.DO_TYPE)
    End Sub
End Class