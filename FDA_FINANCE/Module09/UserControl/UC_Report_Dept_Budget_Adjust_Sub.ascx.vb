Public Class UC_Report_Dept_Budget_Adjust_Sub
    Inherits System.Web.UI.UserControl
    Private _bg_id As Integer
    Public Property bg_id() As Integer
        Get
            Return _bg_id
        End Get
        Set(ByVal value As Integer)
            _bg_id = value
        End Set
    End Property
    Private _sub_bg As Integer
    Public Property sub_bg() As Integer
        Get
            Return _sub_bg
        End Get
        Set(ByVal value As Integer)
            _sub_bg = value
        End Set
    End Property
    Private _dept As Integer
    Public Property dept() As Integer
        Get
            Return _dept
        End Get
        Set(ByVal value As Integer)
            _dept = value
        End Set
    End Property
    Private _bgyear As Integer
    Public Property bgyear() As String
        Get
            Return _bgyear
        End Get
        Set(ByVal value As String)
            _bgyear = value
        End Set
    End Property

    Public depid As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            set_dd_bgyear()
            Try
                'Dim dao As New DAO_USER.TB_tbl_USER
                'Dim strUserName As String = Session("AD")
                'dao.Get_dept_select_by_AD_NAME(strUserName)
                depid = Request.QueryString("dept")

                Dim dao_dep As New DAO_MAS.TB_MAS_DEPARTMENT
                dao_dep.Getdata_by_DEPARTMENT_ID(depid)
                If dao_dep.fields.DEPARTMENT_ID <> 2 Then
                    Label2.Text = dao_dep.fields.DEPARTMENT_DESCRIPTION
                    dd_Department.Style.Add("Display", "none")
                Else
                    Label2.Text = ""
                    dd_Department.Style.Add("Display", "block")
                    bind_ddl_dept()
                End If
            Catch ex As Exception

            End Try

        End If
    End Sub
    Public Sub set_dd_bgyear()
        Dim dt As New DataTable
        dt.Columns.Add("byear")
        Dim byearMax As Integer = Year(System.DateTime.Now)
        If CDate(System.DateTime.Now) >= CDate("1/10/" & Year(System.DateTime.Now)) Then
            byearMax = byearMax + 1
        End If

        For i As Integer = 2558 To byearMax
            Dim drNew As DataRow = dt.NewRow()
            drNew("byear") = i

            dt.Rows.Add(drNew)
        Next

        Dim dv As DataView = dt.DefaultView
        dv.Sort = "byear desc"
        dt = dv.ToTable()

        dd_BudgetYear.DataSource = dt
        dd_BudgetYear.DataBind()
    End Sub
    Public Sub bind_ddl_dept()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_Department()
        dd_Department.DataSource = dt
        dd_Department.DataBind()
    End Sub
    'Public Sub bind_dl_bg(ByVal dept As Integer)
    '    dd_BudgetAdjust.Items.Clear()
    '    Dim bao_adjust As New BAO_BUDGET.Budget
    '    Dim dt As DataTable = bao_adjust.get_bg_adjust_by_dept_year(dept, dd_BudgetYear.SelectedValue)

    '    If dt.Rows.Count > 0 Then
    '        For Each dr As DataRow In dt.Rows
    '            Dim dao_head As New DAO_MAS.TB_BUDGET_PLAN
    '            dao_head.Getdata_by_BUDGET_PLAN_ID(dr("BUDGET_CHILD_ID"))
    '            If dao_head.fields.BUDGET_CODE <> "" Then
    '                dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_CODE & "-" & dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
    '            Else
    '                dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
    '            End If

    '        Next

    '        dd_BudgetAdjust.DataSource = dt
    '        dd_BudgetAdjust.DataBind()


    '    End If
    '    ' UC_Disburse_Budget1.rebind_grid()
    'End Sub
    Public Sub bind_dl_bg(ByVal dept As Integer)
        Dim bao_adjust As New BAO_BUDGET.Budget
        Dim dt As DataTable = bao_adjust.get_bg_adjust_by_dept_year(dept, dd_BudgetYear.SelectedValue)

        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                Dim dao_head As New DAO_MAS.TB_BUDGET_PLAN
                dao_head.Getdata_by_BUDGET_PLAN_ID(dr("BUDGET_CHILD_ID"))
                Dim dao_head2 As New DAO_MAS.TB_BUDGET_PLAN
                dao_head2.Getdata_by_BUDGET_PLAN_ID(dao_head.fields.BUDGET_CHILD_ID)
                If dao_head2.fields.BUDGET_CODE <> "" Then
                    If dao_head.fields.BUDGET_CODE <> "" Then
                        dr("BUDGET_DESCRIPTION") = dao_head2.fields.BUDGET_CODE & " -> " & dao_head.fields.BUDGET_CODE & "-" & dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
                    Else
                        dr("BUDGET_DESCRIPTION") = dao_head2.fields.BUDGET_CODE & " -> " & dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
                    End If
                Else
                    If dao_head.fields.BUDGET_CODE <> "" Then
                        dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_CODE & "-" & dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
                    Else
                        dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
                    End If
                End If


            Next

            dd_BudgetAdjust.DataSource = dt
            dd_BudgetAdjust.DataBind()


        End If
        ' UC_Disburse_Budget1.rebind_grid()
    End Sub
    Public Sub bind_dl_bg_auto()
        Try
            'get_dataselect()
            bind_dl_bg(dept)
            run_on_not_postback()
            bind_sub_bg(dd_BudgetAdjust.SelectedValue)
        Catch ex As Exception

        End Try
        

    End Sub
    Private Sub dd_Department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_Department.SelectedIndexChanged
        bind_dl_bg(dd_Department.SelectedValue)
        run_on_not_postback()
        Try
            Dim p As Object = Me.Page
            p.BindData()
        Catch ex As Exception

        End Try

    End Sub
    Public Sub bind_sub_bg(ByVal child_id As Integer)

        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_sub_bg(child_id)
        Dim dtall As New DataTable
        dtall.Columns.Add("BUDGET_PLAN_ID")
        dtall.Columns.Add("BUDGET_DESCRIPTION")

        Dim dr As DataRow = dtall.NewRow()
        dr("BUDGET_PLAN_ID") = "0"
        dr("BUDGET_DESCRIPTION") = "----ทั้งหมด----"
        dtall.Rows.Add(dr)
        dtall.Merge(dt, False, MissingSchemaAction.Ignore)

        dd_sub_bg.DataSource = dtall
        dd_sub_bg.DataBind()

    End Sub
    Public Sub get_dataselect()

        'Dim dao As New DAO_USER.TB_tbl_USER
        'Dim strUserName As String = Session("AD")
        'dao.Getdata_by_AD_NAME(strUserName)
        'depid = dao.fields.DEPARTMENT_ID
        'Dim dao_dep As New DAO_MAS.TB_MAS_DEPARTMENT
        'dao_dep.Getdata_by_DEPARTMENT_ID(depid)
        'If dao.fields.PERMISSION_ID = 2 Then
        '    dept = dao.fields.DEPARTMENT_ID
        'Else
        dept = dd_Department.SelectedValue
        ' End If

        bgyear = dd_BudgetYear.SelectedValue

    End Sub

    Public Sub set_bg()
        Dim bao As New BAO_BUDGET.MASS
        Dim bool As Boolean = bao.get_support_dept_type(dd_BudgetAdjust.SelectedValue)
        If bool = False Then
            bg_id = dd_BudgetAdjust.SelectedValue
        Else
            bg_id = dd_BudgetAdjust.SelectedValue
            sub_bg = dd_sub_bg.SelectedValue
        End If
    End Sub
    Public Function get_dept_value() As Integer
        Dim dept_ids As Integer = 0
        Try
            dept_ids = dd_Department.SelectedValue
        Catch ex As Exception

        End Try
        Return dept_ids
    End Function

    Private Sub dd_BudgetAdjust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_BudgetAdjust.SelectedIndexChanged
        Try
            Dim bao As New BAO_BUDGET.MASS
            Dim bool As Boolean = bao.get_support_dept_type(dd_BudgetAdjust.SelectedValue)
            If bool = False Then
                lb_sub_bg.Style.Add("display", "none")
                dd_sub_bg.Style.Add("display", "none")
            Else
                bind_sub_bg(dd_BudgetAdjust.SelectedValue)
                lb_sub_bg.Style.Add("display", "block")
                dd_sub_bg.Style.Add("display", "block")

            End If
            Dim p As Object = Me.Page
            p.BindData()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dd_sub_bg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_sub_bg.SelectedIndexChanged
        Try
            Dim p As Object = Me.Page
            p.BindData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dd_BudgetYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_BudgetYear.SelectedIndexChanged
        Try
            'Dim dao As New DAO_USER.TB_tbl_USER
            'Dim strUserName As String = Session("AD")
            'dao.Get_dept_select_by_AD_NAME(strUserName)
            'depid = dao.fields.DEPARTMENT_ID

            'If dao.fields.PERMISSION_ID = 2 Then

            '    bind_dl_bg(depid)
            '    bind_sub_bg(dd_BudgetAdjust.SelectedValue)
            'Else
            bind_dl_bg(dd_Department.SelectedValue)
            bind_sub_bg(dd_BudgetAdjust.SelectedValue)
            'End If


            Dim p As Object = Me.Page
            p.BindData()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub run_on_not_postback()
        Dim bao As New BAO_BUDGET.MASS
        Dim bool As Boolean = False
        Try
            bool = bao.get_support_dept_type(dd_BudgetAdjust.SelectedValue)
        Catch ex As Exception

        End Try

        If bool = False Then
            lb_sub_bg.Style.Add("display", "none")
            dd_sub_bg.Style.Add("display", "none")
        Else
            bind_sub_bg(dd_BudgetAdjust.SelectedValue)
            lb_sub_bg.Style.Add("display", "block")
            dd_sub_bg.Style.Add("display", "block")

        End If
        'Dim p As Object = Me.Page
        'p.BindData()
    End Sub
    Public Function get_dateset() As String
        Dim strDate As String = ""
        If dd_BudgetYear.SelectedValue <> "" Then
            strDate = "01/10/" & CInt(dd_BudgetYear.SelectedValue) - 1
        End If
        Return strDate
    End Function
End Class