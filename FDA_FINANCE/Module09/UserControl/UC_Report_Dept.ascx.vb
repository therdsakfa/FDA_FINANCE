Public Class UC_Report_Dept
    Inherits System.Web.UI.UserControl
    Private _dept As Integer
    Public Property dept() As Integer
        Get
            Return _dept
        End Get
        Set(ByVal value As Integer)
            _dept = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        '    Dim bao As New BAO_BUDGET.MASS
        '    Dim dt As DataTable = bao.get_Department()
        '    dd_Department.DataSource = dt
        '    dd_Department.DataBind()


        'End If


        If Not IsPostBack Then
            Try
                'Dim dao As New DAO_USER.TB_tbl_USER
                Dim strUserName As String = Session("AD")
                'dao.Getdata_by_AD_NAME(strUserName)
                'dao.Get_dept_select_by_AD_NAME(strUserName)
                'Dim depid As Integer = dao.fields.DEPARTMENT_ID

                Dim dao_dep As New DAO_MAS.TB_MAS_DEPARTMENT
                'dao_dep.Getdata_by_DEPARTMENT_ID(depid)
                'If dao.fields.PERMISSION_ID = 2 Then
                '    Label1.Text = dao_dep.fields.DEPARTMENT_DESCRIPTION
                '    dd_Department.Style.Add("Display", "none")
                '    ' BindAdjust(depid)
                'Else
                '    Label1.Text = ""
                '    dd_Department.Style.Add("Display", "block")
                'End If
            Catch ex As Exception

            End Try
            bind_ddl_dept()

        End If
    End Sub
    Public Sub bind_ddl_dept()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_Department()
        dd_Department.DataSource = dt
        dd_Department.DataBind()
    End Sub

    Public Sub get_dept_select()

        'Dim dao As New DAO_USER.TB_tbl_USER
        'Dim strUserName As String = Session("AD")
        'dao.Getdata_by_AD_NAME(strUserName)
        Dim depid As Integer
        'If dao.fields.DEPARTMENT_ID IsNot Nothing Then
        '    depid = dao.fields.DEPARTMENT_ID
        'End If
        'If dao.fields.PERMISSION_ID = 2 Then
        '    dept = depid
        'Else
        dept = dd_Department.SelectedValue
        'End If
    End Sub

    Private Sub dd_Department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_Department.SelectedIndexChanged
        Try
            Dim p As Object = Me.Page
            p.BindData()
        Catch ex As Exception

        End Try
    End Sub
End Class