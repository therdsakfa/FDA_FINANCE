Public Class UC_Search_Salary
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
           
        End If
    End Sub
    'Public Sub bind_ddl_person()
    '    Dim bao As New BAO_BUDGET.MASS
    '    Dim dt As DataTable = bao.get_Person_List()
    '    Dim drnew As DataRow = dt.NewRow()
    '    drnew("IDRUN") = "0"
    '    drnew("fullname") = "--ทั้งหมด--"
    '    dt.Rows.Add(drnew)
    '    Dim dv As DataView = dt.DefaultView
    '    dv.Sort = "IDRUN ASC"

    '    dt = dv.ToTable()


    '    ddlName.DataSource = dt
    '    ddlName.DataBind()
    'End Sub
    Public Sub bind_ddl_dept()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_Department()
        Dim drnew As DataRow = dt.NewRow()
        drnew("DEPARTMENT_ID") = "0"
        drnew("DEPARTMENT_DESCRIPTION") = "--ทั้งหมด--"
        dt.Rows.Add(drnew)

        Dim dv As DataView = dt.DefaultView
        dv.Sort = "DEPARTMENT_ID ASC"

        dt = dv.ToTable()
        ddl_department.DataSource = dt
        ddl_department.DataBind()
    End Sub
    Public Function getSearchMsg() As String
        Dim strMsg As String = " "
        Dim str_dept As String = ""
        Dim str_name As String = ""
        str_dept = ddl_department.SelectedValue
        str_name = txt_NAME.Text
        If str_dept = "0" AndAlso str_name = "" Then
            strMsg = " "
        End If
        If str_name <> "" Then
            strMsg = " ([fullname] LIKE '%" & str_name & "%')"
        End If
        If strMsg <> " " Then
            If str_dept <> "0" Then
                strMsg = strMsg & " AND " & " ([DEPARTMENT_ID] = '" & ddl_department.SelectedValue & "')"
            Else
                strMsg = strMsg & " AND " & " ([dept_long] LIKE '%%')"
            End If

            'If str_stat <> "" Then
            '    strMsg = strMsg & " AND " & "([STATUS_PERSON] like '%" & dd_Status.SelectedValue & "%')"
            'End If

        Else
            If str_dept <> "0" Then
                strMsg = " ([DEPARTMENT_ID] = '" & ddl_department.SelectedValue & "') "
            Else
                strMsg = " ([dept_long] LIKE '%%')"
            End If
        End If

            Return strMsg
    End Function
End Class