Public Class UC_Return_Description_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub insert(ByRef dao As DAO_MAS.TB_MAS_RETURN_DESCRIPTION)
        dao.fields.RETURN_DESCRIPTION = txt_RETURN_DESCRIPTION.Text
    End Sub
    Public Sub getdata(ByRef dao As DAO_MAS.TB_MAS_RETURN_DESCRIPTION)
        txt_RETURN_DESCRIPTION.Text = dao.fields.RETURN_DESCRIPTION
    End Sub
End Class