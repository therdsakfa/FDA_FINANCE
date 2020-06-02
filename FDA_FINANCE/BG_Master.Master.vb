Imports Telerik.Web.UI
Partial Public Class BG_Master
    Inherits System.Web.UI.MasterPage

    Dim mmr As New RadMenuItem
    Private _budget_year As Integer
    Public Property budget_year() As Integer
        Get
            Return _budget_year
        End Get
        Set(ByVal value As Integer)
            _budget_year = value
        End Set
    End Property
    Private _dept_id As Integer
    Public Property dept_id() As Integer
        Get
            Return _dept_id
        End Get
        Set(ByVal value As Integer)
            _dept_id = value
        End Set
    End Property
    Public strDomainName As String = ""
    Public strUserName As String = ""
    Public strFullName As String = ""
    Public strPosition As String = ""
    Public strDepartmentName As String = ""
    Public intDepartmentID As Integer
    Public intPermission As Integer
    Public intGroupUser As Integer

    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        set_dd_bgyear()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If checkAD() = True Then
        '    'If Not IsPostBack Then
        '    '    set_dd_bgyear()

        '    'End If
        '    strUserName = NameUserAD()
        '    Session("AD") = strUserName
        '    BindAD()
        '    'bind_ddl_dept()
        '    'bind_ddl_selected()
        '    If Not IsPostBack Then
        '        set_dd_bgyear()

        '        'If Not IsPostBack Then
        '        lbHiddenDept.Style.Add("display", "none")
        '        lbl_FullName.Text = strFullName
        '        ' lbDept.Text = strDepartmentName
        '        lbHiddenDept.Text = intDepartmentID
        '        lbl_Position.Text = strPosition
        '        'End If
        '        'bind_ddl_dept()
        '        'bind_ddl_selected()

        '        Dim dao_menu As New DAO_MAS.TB_MAS_MENU
        '        ' dao_menu.getData_by_parent_id(0, intPermission)
        '        dao_menu.getData_by_group(0, intPermission, intGroupUser)
        '        For Each dao_menu.fields In dao_menu.datas
        '            Dim mm As New RadMenuItem
        '            mm.NavigateUrl = dao_menu.fields.MENU_URL
        '            mm.Target = dao_menu.fields.MENU_TARGET
        '            mm.Text = dao_menu.fields.MENU_NAME
        '            mm.Font.Name = "TH SarabunPSK"
        '            mm.Font.Size = "16"
        '            RadMenu1.Items.Add(mm)
        '            bindmenu(mm.Items, dao_menu.fields.MENU_CHILD_ID)
        '        Next
        '    End If
        'Else
        '    'Response.Redirect("Frm_No_Permission.aspx")
        'End If
        'If Not IsPostBack Then
        '    bind_ddl_selected()
        '    Try
        '        For Each lt As ListItem In dd_BudgetYear.Items
        '            If lt.Value = Request.QueryString("myear") Then
        '                lt.Selected = True
        '                Exit For 'เพิ่มใหม่
        '            Else
        '                lt.Selected = False
        '            End If
        '        Next
        '    Catch ex As Exception

        '    End Try

        'End If

    End Sub
    Public Sub set_dd_bgyear()
        Dim dt As New DataTable
        dt.Columns.Add("byear")
        Dim byearMax As Integer = Year(System.DateTime.Now)
        Dim aa As Date = CDate("1/10/" & Year(System.DateTime.Now))
        If CDate(System.DateTime.Now) >= CDate("1/10/" & Year(System.DateTime.Now)) Then
            byearMax = byearMax + 1
        End If

        For i As Integer = 2555 To byearMax
            Dim drNew As DataRow = dt.NewRow()
            drNew("byear") = i

            dt.Rows.Add(drNew)
        Next

        Dim dv As DataView = dt.DefaultView
        dv.Sort = "byear desc"
        dt = dv.ToTable()

        dd_BudgetYear.DataSource = dt
        dd_BudgetYear.DataBind()
        'dd_BudgetYear.Items.Insert(0, New ListItem(2558, 2558)) 'เพิ่มใหม่

        'dd_BudgetYear.SelectedValue = 2557
        'dd_BudgetYear.DropDownSelectData(2557)
    End Sub
    'Public Function bindmenu(Optional ByVal ParentID As Integer = 0) As String
    '    Dim dao_menu As New DAO_MAS.TB_MAS_MENU
    '    dao_menu.getData_by_parent_id(ParentID, 2)
    '    Dim menu As String = ""
    '    For Each dao_menu.fields In dao_menu.datas
    '        menu = menu & "<li>" & "<a href='" & dao_menu.fields.MENU_URL & "' target='" & dao_menu.fields.MENU_TARGET & "'><span></span><span></span><span><span>" & dao_menu.fields.MENU_NAME & "</span></span></a>" & bindmenu(dao_menu.fields.MENU_CHILD_ID) & "</li>"
    '    Next
    '    If menu = "" Then
    '        Return ""
    '    End If
    '    lbMenu.Text = menu
    '    Return "<UL>" & menu & "</UL>"

    'End Function
    Public Function bindmenu(ByVal radm As RadMenuItemCollection, Optional ByVal ParentID As Integer = 0) As RadMenuItem
        Dim dao_menu As New DAO_MAS.TB_MAS_MENU
        'dao_menu.getData_by_parent_id(ParentID, intPermission)
        dao_menu.getData_by_group(ParentID, intPermission, intGroupUser)
        '     Dim menu As String = ""

        For Each dao_menu.fields In dao_menu.datas
            '    menu = menu & "<li>" & "<a href='" & dao_menu.fields.MENU_URL & "' target='" & dao_menu.fields.MENU_TARGET & "'><span>
            '</span><span></span><span><span>" & dao_menu.fields.MENU_NAME & 
            '"</span></span></a>" & bindmenu(dao_menu.fields.MENU_CHILD_ID) & "</li>"
            Dim mm As New RadMenuItem
            mm.NavigateUrl = dao_menu.fields.MENU_URL
            mm.Target = dao_menu.fields.MENU_TARGET
            mm.Text = dao_menu.fields.MENU_NAME
            mm.Font.Name = "TH SarabunPSK"
            mm.Font.Size = "16"
            mm.Value = 0
            radm.Add(mm)



            bindmenu(mm.Items, dao_menu.fields.MENU_CHILD_ID)
        Next
        'If menu = "" Then
        '    Return ""
        'End If
        'lbMenu.Text = menu
        ' Return radm

    End Function


    'Public Sub BindAD()
    '    Dim dao As New DAO_USER.TB_tbl_USER

    '    'dao.Getdata_by_AD_NAME(strUserName)
    '    If dao.fields.ID <> Nothing Or dao.fields.ID <> 0 Then
    '        strFullName = dao.fields.PREFIX & " " & dao.fields.NAME & " " & dao.fields.SURNAME
    '        strPosition = dao.fields.POSITION
    '        intDepartmentID = dao.fields.DEPARTMENT_ID
    '        intPermission = dao.fields.PERMISSION_ID
    '        'intDepartmentID = dao.fields.DEPARTMENT_ID
    '        If dao.fields.GROUP_ID IsNot Nothing Then
    '            intGroupUser = dao.fields.GROUP_ID
    '        Else
    '            intGroupUser = 0
    '        End If

    '        Me.dept_id = intDepartmentID
    '        Me.budget_year = dd_BudgetYear.SelectedValue

    '        Dim bao As New BAO_USER.USER
    '        Dim dt As DataTable = bao.GetUserDetail(strUserName)
    '        If dt.Rows.Count = 1 Then
    '            strDepartmentName = dt(0)("DEPARTMENT_DESCRIPTION").ToString() '& " (" & dt(0)("DEPARTMENT_SHORT_DESCRIPTION").ToString() & ")"
    '        End If

    '    End If
    'End Sub

    'Private Sub ddl_Department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Department.SelectedIndexChanged
    '    If ddl_Department.SelectedValue <> "" Then
    '        set_dept_false()
    '        Dim dao_ad As New DAO_USER.TB_tbl_USER()
    '        dao_ad.Getdata_by_ad_dept(strUserName, ddl_Department.SelectedValue)
    '        If dao_ad.fields.ID <> Nothing Then
    '            '  For Each dao_ad.fields In dao_ad.datas
    '            Dim dao_user_up As New DAO_USER.TB_tbl_USER()
    '            dao_user_up.Getdata_by_ID(dao_ad.fields.ID)
    '            dao_user_up.fields.SELECT_DEPT = True
    '            dao_user_up.update()
    '            '   Next
    '        End If
    '    End If
    '    Response.Redirect(Request.Url.AbsoluteUri)
    'End Sub

    'Private Sub set_dept_false()
    '    Dim dao_user As New DAO_USER.TB_tbl_USER()
    '    'dao_user.Getdata_by_AD_NAME(strUserName)
    '    For Each dao_user.fields In dao_user.datas
    '        dao_user.fields.SELECT_DEPT = False
    '    Next
    '    dao_user.update()
    'End Sub
    Private Sub bind_ddl_dept()
        Dim bao_dept As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao_dept.get_multi_dept(strUserName)

        If dt.Rows.Count > 0 Then
            ddl_Department.DataSource = dt
            ddl_Department.DataBind()

        End If
    End Sub

    'Private Sub bind_ddl_selected()
    '    bind_ddl_dept()
    '    Dim dao_user As New DAO_USER.TB_tbl_USER
    '    dao_user.Get_dept_select_by_AD_NAME(strUserName)
    '    If dao_user.fields.DEPARTMENT_ID IsNot Nothing Then
    '        Dim depid As Integer = dao_user.fields.DEPARTMENT_ID
    '        ddl_Department.DropDownSelectData(depid)
    '    End If

    'End Sub

    Private Sub dd_BudgetYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_BudgetYear.SelectedIndexChanged
        Dim bg_year As Integer = dd_BudgetYear.SelectedValue
        Response.Redirect(Request.Url.AbsolutePath & "?myear=" & bg_year)
        ' Response.Redirect(Request.Url.AbsoluteUri)
    End Sub
End Class