Public Class UC_CHECKER_DETAIL
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Sub set_data(ByRef dao As DAO_MAS.TB_MAS_CHECKER)
        dao.fields.CTZID = txt_CTZID.Text
        dao.fields.FULLNAME = txt_FULLNAME.Text
    End Sub
    Sub get_data(ByRef dao As DAO_MAS.TB_MAS_CHECKER)
        txt_CTZID.Text = dao.fields.CTZID
        txt_FULLNAME.Text = dao.fields.FULLNAME
    End Sub
End Class