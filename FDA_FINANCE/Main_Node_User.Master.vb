﻿Imports Telerik.Web.UI
Public Class Main_Node_User
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
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")
            '_thanm_customer = Session("thanm_customer")
            '    _thanm = Session("thanm")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()

        If Not IsPostBack Then
            Dim dao As New DAO_MAS.TB_MAS_DEPARTMENT
            Dim _dep As Integer = 0
            Try
                _dep = Request.QueryString("dept")
                dao.Getdata_by_DEPARTMENT_ID(_dep)
                lb_dept.Text = dao.fields.DEPARTMENT_DESCRIPTION
            Catch ex As Exception

            End Try

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(_CLS.CITIZEN_ID)

            Dim CITIzen_id = ws_taxno.SYSLCNSIDs.identify
            Dim birthday = ws_taxno.SYSLCNSIDs.birthdate

            Dim fullname As String = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
            lb_name.Text = fullname
            Dim addr = ws_taxno.SYSLCTADDRs.Fulladdr

        End If
        'If Request.QueryString("dept") <> "" AndAlso Request.QueryString("myear") <> "" Then
        hl_home.NavigateUrl = "~/HOME/FRM_PROJECT_SELECT.aspx?dept=" & Request.QueryString("dept") & "&myear=" & Request.QueryString("myear")
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
        '        ' set_dd_bgyear()

        '        ''If Not IsPostBack Then
        '        'lbHiddenDept.Style.Add("display", "none")
        '        'lbl_FullName.Text = strFullName
        '        '' lbDept.Text = strDepartmentName
        '        'lbHiddenDept.Text = intDepartmentID
        '        'lbl_Position.Text = strPosition
        '        ''End If
        '        ''bind_ddl_dept()
        '        ''bind_ddl_selected()

        '        Dim str_ad As String = ""
        '        str_ad = NameUserAD()
        '        Dim dao As New DAO_USER.TB_tbl_USER
        '        dao.Getdata_by_AD_NAME(str_ad)
        '        Try
        '            hl_name.Text = "ชื่อผู้ใช้" & " " & dao.fields.NAME & " " & dao.fields.SURNAME  '_CLS.THANM
        '            'hl_organization.Text = "ชื่อผู้ได้รับอนุญาต" & " " & "" '_CLS.THANM_CUSTOMER
        '        Catch ex As Exception

        '        End Try


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
        '            'RadMenu1.Items.Add(mm)
        '            bindmenu(mm.Items, dao_menu.fields.MENU_CHILD_ID)
        '        Next
        '    End If
        'Else
        '    'Response.Redirect("Frm_No_Permission.aspx")
        'End If
        'If Not IsPostBack Then
        '    'bind_ddl_selected()
        '    'Try
        '    '    For Each lt As ListItem In dd_BudgetYear.Items
        '    '        If lt.Value = Request.QueryString("myear") Then
        '    '            lt.Selected = True
        '    '            Exit For 'เพิ่มใหม่
        '    '        Else
        '    '            lt.Selected = False
        '    '        End If
        '    '    Next
        '    'Catch ex As Exception

        '    'End Try

        'End If
        ''If Request.QueryString("dept") <> "" AndAlso Request.QueryString("myear") <> "" Then
        'hl_home.NavigateUrl = "~/HOME/FRM_PROJECT_SELECT.aspx?dept=" & Request.QueryString("dept") & "&myear=" & Request.QueryString("myear")

        ''Else
        ''    hl_home.NavigateUrl = "~/HOME/FRM_PROJECT_SELECT.aspx?dept=" & ddl_Department.SelectedValue & "&myear=" & dd_BudgetYear.SelectedValue
        ''End If
    End Sub
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
    '        Me.budget_year = Request.QueryString("myear") 'dd_BudgetYear.SelectedValue

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
    '    If Request.QueryString("bgid") <> "" Then
    '        Response.Redirect(Request.Url.AbsolutePath & "?dept=" & ddl_Department.SelectedValue & "&myear=" & dd_BudgetYear.SelectedValue & "&bgid=" & Request.QueryString("bgid"))
    '    Else
    '        Response.Redirect(Request.Url.AbsolutePath & "?dept=" & ddl_Department.SelectedValue & "&myear=" & dd_BudgetYear.SelectedValue)

    '    End If
    'End Sub

    'Private Sub set_dept_false()
    '    Dim dao_user As New DAO_USER.TB_tbl_USER()
    '    'dao_user.Getdata_by_AD_NAME(strUserName)
    '    For Each dao_user.fields In dao_user.datas
    '        dao_user.fields.SELECT_DEPT = False
    '    Next
    '    dao_user.update()
    'End Sub
End Class