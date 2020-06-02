Public Class UC_User_Debtor_Add
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub bind_ddl_dept()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_Department()
        dd_Department.DataSource = dt
        dd_Department.DataBind()
    End Sub
    'Public Sub insert(ByRef dao As DAO_USER.TB_tbl_USER)
    '    dao.fields.DEPARTMENT_ID = dd_Department.SelectedValue
    '    dao.fields.GENDER = dd_Gender.SelectedValue
    '    dao.fields.IDENTITY_NUMBER = txt_Personal_ID.Text
    '    dao.fields.NAME = txt_Name.Text
    '    dao.fields.POSITION = txt_Position.Text
    '    dao.fields.PREFIX = txt_Prefix.Text
    '    dao.fields.SURNAME = txt_Surname.Text
    'End Sub
    'Public Sub getdata(ByRef dao As DAO_USER.TB_tbl_USER)
    '    dd_Department.DropDownSelectData(dao.fields.DEPARTMENT_ID)
    '    dd_Gender.DropDownSelectData(dao.fields.GENDER)
    '    txt_Personal_ID.Text = dao.fields.IDENTITY_NUMBER
    '    txt_Name.Text = dao.fields.NAME
    '    txt_Position.Text = dao.fields.POSITION
    '    txt_Prefix.Text = dao.fields.PREFIX
    '    txt_Surname.Text = dao.fields.SURNAME
    'End Sub
End Class