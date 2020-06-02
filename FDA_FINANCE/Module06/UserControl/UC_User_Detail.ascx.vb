Public Partial Class UC_User_Insert
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' เพิ่ม/แก้ไขข้อมูลบุคลากร
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub insert(ByRef dao As DAO_MAS.TB_MAS_USER)
        dao.fields.DEPARTMENT_DESCRIPTION = txt_DEPARTMENT_DESCRIPTION.Text
        dao.fields.NAME = txt_NAME.Text
        dao.fields.PERSONAL_ID = txt_PERSONAL_ID.Text
        dao.fields.PREFIX_NAME = txt_PREFIX_NAME.Text
        dao.fields.SURNAME = txt_SURNAME.Text
        dao.fields.USER_TYPE = dd_USER_TYPE.SelectedValue
    End Sub
    ''' <summary>
    ''' ดึงข้อมูลบุคลากร
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub getdata(ByRef dao As DAO_MAS.TB_MAS_USER)
        txt_DEPARTMENT_DESCRIPTION.Text = dao.fields.DEPARTMENT_DESCRIPTION
        txt_NAME.Text = dao.fields.NAME
        txt_PERSONAL_ID.Text = dao.fields.PERSONAL_ID
        txt_PREFIX_NAME.Text = dao.fields.PREFIX_NAME
        txt_SURNAME.Text = dao.fields.SURNAME
        dd_USER_TYPE.SelectedValue = dao.fields.USER_TYPE
    End Sub
End Class