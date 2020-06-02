﻿Imports Telerik.Web.UI
Public Class Main_Empty
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
    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        RunSession()
       
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
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

        '        ''If Not IsPostBack Then
        '        'lbHiddenDept.Style.Add("display", "none")
        '        'lbl_FullName.Text = strFullName
        '        '' lbDept.Text = strDepartmentName
        '        'lbHiddenDept.Text = intDepartmentID
        '        'lbl_Position.Text = strPosition
        '        ''End If
        '        ''bind_ddl_dept()
        '        ''bind_ddl_selected()



        '        'Dim str_ad As String = ""
        '        'str_ad = NameUserAD()
        '        'Dim dao As New DAO_USER.TB_tbl_USER
        '        'dao.Getdata_by_AD_NAME(str_ad)
        '        'Try
        '        '    hl_name.Text = "ชื่อผู้ใช้" & " " & dao.fields.NAME & " " & dao.fields.SURNAME  '_CLS.THANM
        '        '    'hl_organization.Text = "ชื่อผู้ได้รับอนุญาต" & " " & "" '_CLS.THANM_CUSTOMER
        '        'Catch ex As Exception

        '        'End Try


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
        If Not IsPostBack Then
            Dim dao As New DAO_MAS.TB_MAS_DEPARTMENT
            Dim _dep As Integer = 0
            Try
                _dep = Request.QueryString("dept")
                dao.Getdata_by_DEPARTMENT_ID(_dep)
                'lb_dept.Text = dao.fields.DEPARTMENT_DESCRIPTION
            Catch ex As Exception

            End Try

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(_CLS.CITIZEN_ID)

            Dim CITIzen_id = ws_taxno.SYSLCNSIDs.identify
            Dim birthday = ws_taxno.SYSLCNSIDs.birthdate

            Dim fullname As String = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
            lb_name.Text = fullname
            Dim addr = ws_taxno.SYSLCTADDRs.Fulladdr

            'bind_ddl_selected()
            'Try
            '    For Each lt As ListItem In dd_BudgetYear.Items
            '        If lt.Value = Request.QueryString("myear") Then
            '            lt.Selected = True
            '            Exit For 'เพิ่มใหม่
            '        Else
            '            lt.Selected = False
            '        End If
            '    Next
            'Catch ex As Exception

            'End Try

        End If
        'If Request.QueryString("dept") <> "" AndAlso Request.QueryString("myear") <> "" Then
        hl_home.NavigateUrl = "http://privus.fda.moph.go.th/" '"~/HOME/FRM_PROJECT_SELECT.aspx?dept=" & Request.QueryString("dept") & "&myear=" & Request.QueryString("myear")

        'Else
        '    hl_home.NavigateUrl = "~/HOME/FRM_PROJECT_SELECT.aspx?dept=" & ddl_Department.SelectedValue & "&myear=" & dd_BudgetYear.SelectedValue
        'End If
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

    End Function

End Class