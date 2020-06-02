Public Partial Class UC_Department_Detail1
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub insert_head(ByRef dao As DAO_MAS.TB_MAS_DEPARTMENT)
        Dim type_id As Integer
        If Request.QueryString("typeid") IsNot Nothing Then
            type_id = Request.QueryString("typeid")
        End If
        dao.fields.DEPARTMENT_DESCRIPTION = txt_dept_description.Text
        dao.fields.DEPARTMENT_CODE = txt_dept_code.Text
        dao.fields.DEPARTMENT_HEAD_ID = 0
        dao.fields.DEPARTMENT_TYPE_ID = type_id

    End Sub
    Public Sub insert(ByRef dao As DAO_MAS.TB_MAS_DEPARTMENT)
        Dim type_id As Integer
        If Request.QueryString("typeid") IsNot Nothing Then
            type_id = Request.QueryString("typeid")
        End If

        dao.fields.DEPARTMENT_DESCRIPTION = txt_dept_description.Text
        dao.fields.DEPARTMENT_HEAD_ID = Request.QueryString("id")
        dao.fields.DEPARTMENT_TYPE_ID = type_id
        dao.fields.DEPARTMENT_CODE = txt_dept_code.Text

    End Sub
    Public Sub update(ByRef dao As DAO_MAS.TB_MAS_DEPARTMENT)
        Dim type_id As Integer
        If Request.QueryString("typeid") IsNot Nothing Then
            type_id = Request.QueryString("typeid")
        End If

        dao.fields.DEPARTMENT_DESCRIPTION = txt_dept_description.Text
        'dao.fields.DEPARTMENT_HEAD_ID = Request.QueryString("id")
        'dao.fields.DEPARTMENT_TYPE_ID = type_id
        dao.fields.DEPARTMENT_CODE = txt_dept_code.Text

    End Sub
    Public Sub getdata(ByRef dao As DAO_MAS.TB_MAS_DEPARTMENT)
        txt_dept_description.Text = dao.fields.DEPARTMENT_DESCRIPTION
        txt_dept_code.Text = dao.fields.DEPARTMENT_CODE

    End Sub
End Class