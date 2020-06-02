﻿Public Partial Class UC_Budget_Transfer_In_Detail
    Inherits System.Web.UI.UserControl
    Private _transfer_type As Integer
    Public Property transfer_type() As Integer
        Get
            Return _transfer_type
        End Get
        Set(ByVal value As Integer)
            _transfer_type = value
        End Set
    End Property
    Private _is_dept_outside As String
    Public Property is_dept_outside() As String
        Get
            Return _is_dept_outside
        End Get
        Set(ByVal value As String)
            _is_dept_outside = value
        End Set
    End Property
    Private _dept As String
    Public Property dept() As String
        Get
            Return _dept
        End Get
        Set(ByVal value As String)
            _dept = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        '    Dim bao As New BAO_BUDGET.MASS
        '    Dim dt As DataTable = bao.get_dept_not_in(Request.QueryString("dept"), is_dept_outside)
        '    dd_dept.DataSource = dt
        '    dd_dept.DataBind()

        '    Dim dao_bg As New DAO_MAS.TB_BUDGET_PLAN
        '    dao_bg.Getdata_by_BUDGET_PLAN_ID(Request.QueryString("bgid"))
        '    lb_BG.Text = dao_bg.fields.BUDGET_DESCRIPTION

        '    Dim dao_dept As New DAO_MAS.TB_MAS_DEPARTMENT
        '    dao_dept.Getdata_by_DEPARTMENT_ID(Request.QueryString("dept"))
        '    lb_dept_from.Text = dao_dept.fields.DEPARTMENT_DESCRIPTION
        'End If

        'Dim bao_adjust As New BAO_BUDGET.Budget
        'Dim dt_adjust As DataTable = bao_adjust.get_bg_adjust_by_dept_year(dd_dept.SelectedValue, 2557)
        'If dt_adjust.Rows.Count > 0 Then
        '    dd_bg_adjust.DataSource = dt_adjust
        '    dd_bg_adjust.DataBind()

        'End If
      

        If Not IsPostBack Then
            'bind_dl_department()
            'bind_dl_bg()
            'bind_dl_department_re()
            'bind_dl_bg_re()

            'set_edit()

            'cal_balance(dd_BudgetAdjust.SelectedValue)
        End If
        'set_selected_dd()
    End Sub
    Public Sub set_date()
        txt_BUDGET_TRANSFER_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_BUDGET_TRANSFER_DOC_DATE.Text = System.DateTime.Now.ToShortDateString()
    End Sub
    'Public Sub set_selected_dd()
    '    If Request.QueryString("id") IsNot Nothing Then
    '        Dim dao As New DAO_BUDGET.TB_BUDGET_TRANSFER
    '        dao.Getdata_by_BUDGET_TRANSFER_ID(Request.QueryString("id"))
    '        If dao.fields.FROM_DEPARTMENT_ID IsNot Nothing Then
    '            dd_Department.DropDownSelectData(dao.fields.FROM_DEPARTMENT_ID)
    '        End If
    '        If dao.fields.TO_DEPARTMENT_ID IsNot Nothing Then
    '            dd_dept_receive.DropDownSelectData(dao.fields.TO_DEPARTMENT_ID)
    '        End If
    '        If dao.fields.FROM_BUDGET_PLAN_ID IsNot Nothing Then
    '            dd_BudgetAdjust.DropDownSelectData(dao.fields.FROM_BUDGET_PLAN_ID)
    '        End If
    '        If dao.fields.TO_BUDGET_PLAN_ID IsNot Nothing Then
    '            dd_bg_adjust_receive.DropDownSelectData(dao.fields.TO_BUDGET_PLAN_ID)
    '        End If
    '    End If
    'End Sub
    Public Sub set_edit()
        If Request.QueryString("id") IsNot Nothing Then
            Dim dao As New DAO_BUDGET.TB_BUDGET_TRANSFER
            dao.Getdata_by_BUDGET_TRANSFER_ID(Request.QueryString("id"))
            ' bind_dl_department()
            If dao.fields.FROM_DEPARTMENT_ID IsNot Nothing Then
                dd_Department.DropDownSelectData(dao.fields.FROM_DEPARTMENT_ID)
            End If
            'bind_dl_department_re()

            bind_dl_bg()
            If dao.fields.FROM_BUDGET_PLAN_ID IsNot Nothing Then
                Dim bao As New BAO_BUDGET.MASS
                Dim bool As Boolean = bao.get_support_dept_type(dao.fields.FROM_BUDGET_PLAN_ID)
                If bool = False Then
                    'bind_dl_bg()
                    dd_BudgetAdjust.DropDownSelectData(dao.fields.FROM_BUDGET_PLAN_ID)
                    cal_balance(dd_BudgetAdjust.SelectedValue)
                    lb_sub_bg1.Style.Add("display", "none")
                    dd_sub_bg1.Style.Add("display", "none")
                Else
                    Dim bao_ad As New BAO_BUDGET.MASS
                    dd_BudgetAdjust.DropDownSelectData(bao_ad.get_bg_head_id(dao.fields.FROM_BUDGET_PLAN_ID))
                    bind_sub_bg1(dd_BudgetAdjust.SelectedValue)
                    lb_sub_bg1.Style.Add("display", "block")
                    dd_sub_bg1.Style.Add("display", "block")
                    dd_sub_bg1.DropDownSelectData(dao.fields.FROM_BUDGET_PLAN_ID)
                    cal_balance(dd_sub_bg1.SelectedValue)
                End If
                ' dd_BudgetAdjust.DropDownSelectData(dao.fields.FROM_BUDGET_PLAN_ID)
            End If
            If dao.fields.TO_DEPARTMENT_ID IsNot Nothing Then
                dd_dept_receive.DropDownSelectData(dao.fields.TO_DEPARTMENT_ID)
            End If
            bind_dl_bg_re()
            If dao.fields.TO_BUDGET_PLAN_ID IsNot Nothing Then
                'bind_dl_department_re()
                Dim bao2 As New BAO_BUDGET.MASS
                Dim bool2 As Boolean = bao2.get_support_dept_type(dao.fields.TO_BUDGET_PLAN_ID)
                If bool2 = False Then
                    'bind_dl_bg_re()
                    'If dao.fields.TO_BUDGET_PLAN_ID IsNot Nothing Then
                    dd_bg_adjust_receive.DropDownSelectData(dao.fields.TO_BUDGET_PLAN_ID)
                    'End If
                    lb_sub_bg2.Style.Add("display", "none")
                    dd_sub_bg2.Style.Add("display", "none")
                Else
                    Dim bao_ad As New BAO_BUDGET.MASS
                    dd_bg_adjust_receive.DropDownSelectData(bao_ad.get_bg_head_id(dao.fields.TO_BUDGET_PLAN_ID))
                    bind_sub_bg2(dd_bg_adjust_receive.SelectedValue)

                    lb_sub_bg2.Style.Add("display", "block")
                    dd_sub_bg2.Style.Add("display", "block")
                    dd_sub_bg2.DropDownSelectData(dao.fields.TO_BUDGET_PLAN_ID)
                End If
            End If

            'Dim bao As New BAO_BUDGET.MASS
            'Dim bool As Boolean = bao.get_support_dept_type(dd_BudgetAdjust.SelectedValue)
            'If bool = False Then
            '    bind_dl_bg()
            '    If dao.fields.FROM_BUDGET_PLAN_ID IsNot Nothing Then
            '        dd_BudgetAdjust.DropDownSelectData(dao.fields.FROM_BUDGET_PLAN_ID)
            '    End If
            '    cal_balance(dd_BudgetAdjust.SelectedValue)
            '    lb_sub_bg1.Style.Add("display", "none")
            '    dd_sub_bg1.Style.Add("display", "none")
            'Else
            '    bind_sub_bg1(dd_BudgetAdjust.SelectedValue)
            '    lb_sub_bg1.Style.Add("display", "block")
            '    dd_sub_bg1.Style.Add("display", "block")
            '    dd_sub_bg1.DropDownSelectData(dao.fields.FROM_BUDGET_PLAN_ID)
            '    cal_balance(dd_sub_bg1.SelectedValue)
            'End If

            'Dim bao2 As New BAO_BUDGET.MASS
            'Dim bool2 As Boolean = bao2.get_support_dept_type(dd_bg_adjust_receive.SelectedValue)
            'If bool2 = False Then
            '    bind_dl_bg_re()
            '    If dao.fields.TO_BUDGET_PLAN_ID IsNot Nothing Then
            '        dd_bg_adjust_receive.DropDownSelectData(dao.fields.TO_BUDGET_PLAN_ID)
            '    End If
            '    lb_sub_bg2.Style.Add("display", "none")
            '    dd_sub_bg2.Style.Add("display", "none")
            'Else
            '    bind_sub_bg2(dd_bg_adjust_receive.SelectedValue)
            '    lb_sub_bg2.Style.Add("display", "block")
            '    dd_sub_bg2.Style.Add("display", "block")
            '    dd_sub_bg2.DropDownSelectData(dao.fields.TO_BUDGET_PLAN_ID)
            'End If

        End If
    End Sub

    Public Sub bind_dl_department()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_Department()
        dd_Department.DataSource = dt
        dd_Department.DataBind()
    End Sub
    Public Sub bind_dl_department_re()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_Department()
        dd_dept_receive.DataSource = dt
        dd_dept_receive.DataBind()
    End Sub
    Public Sub bind_sub_bg1(ByVal child_id As Integer)
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_sub_bg(child_id)
        dd_sub_bg1.DataSource = dt
        dd_sub_bg1.DataBind()

    End Sub
    Public Sub bind_sub_bg1_insert()
        Try
            Dim bao As New BAO_BUDGET.MASS
            Dim dt As DataTable = bao.get_sub_bg(dd_BudgetAdjust.SelectedValue)
            dd_sub_bg1.DataSource = dt
            dd_sub_bg1.DataBind()
        Catch ex As Exception

        End Try
        

    End Sub
    Public Sub bind_sub_bg2(ByVal child_id As Integer)
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_sub_bg(child_id)
        dd_sub_bg2.DataSource = dt
        dd_sub_bg2.DataBind()

    End Sub
    Public Sub bind_sub_bg2_insert()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As New DataTable
        Try
            dt = bao.get_sub_bg(dd_bg_adjust_receive.SelectedValue)
        Catch ex As Exception

        End Try

        dd_sub_bg2.DataSource = dt
        dd_sub_bg2.DataBind()

    End Sub
    Public Sub bind_dl_bg()
        Dim bao_adjust As New BAO_BUDGET.Budget
        Dim dt As DataTable = bao_adjust.get_bg_adjust_by_dept_year(dd_Department.SelectedValue, Request.QueryString("bgYear"))

        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                Dim dao_head As New DAO_MAS.TB_BUDGET_PLAN
                dao_head.Getdata_by_BUDGET_PLAN_ID(dr("BUDGET_CHILD_ID"))
                 If dao_head.fields.BUDGET_CODE <> "" Then
                    dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_CODE & "-" & dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
                Else
                    dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
                End If

            Next

            dd_BudgetAdjust.DataSource = dt
            dd_BudgetAdjust.DataBind()


        End If
        ' UC_Disburse_Budget1.rebind_grid()
    End Sub
    Public Sub bind_dl_bg_re()
        Dim bao_adjust As New BAO_BUDGET.Budget
        Dim dt As DataTable = bao_adjust.get_bg_adjust_by_dept_year(dd_dept_receive.SelectedValue, Request.QueryString("bgYear"))

        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                Dim dao_head As New DAO_MAS.TB_BUDGET_PLAN
                dao_head.Getdata_by_BUDGET_PLAN_ID(dr("BUDGET_CHILD_ID"))
                If dao_head.fields.BUDGET_CODE <> "" Then
                    dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_CODE & "-" & dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
                Else
                    dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
                End If

            Next

            dd_bg_adjust_receive.DataSource = dt
            dd_bg_adjust_receive.DataBind()


        End If
        ' UC_Disburse_Budget1.rebind_grid()
    End Sub
    Private Sub dd_Department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_Department.SelectedIndexChanged
        bind_dl_bg()
        set_hide_unhide1()
    End Sub

    Private Sub dd_dept_receive_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_dept_receive.SelectedIndexChanged
        bind_dl_bg_re()
        set_hide_unhide2()
    End Sub
    'Public Sub insert(ByRef dao As DAO_BUDGET.TB_BUDGET_TRANSFER)
    '    dao.fields.BUDGET_FROM_TRANSFER_DESCRIPTION = txt_BUDGET_FROM_TRANSFER_DESCRIPTION.Text
    '    dao.fields.BUDGET_TO_TRANSFER_DESCRIPTION = txt_BUDGET_TO_TRANSFER_DESCRIPTION.Text
    '    dao.fields.BUDGET_TRANSFER_AMOUNT = rnt_BUDGET_TRANSFER_AMOUNT.Value
    '    dao.fields.BUDGET_TRANSFER_BUDGET_YEAR = 2557
    '    dao.fields.BUDGET_TRANSFER_COUNT = txt_BUDGET_TRANSFER_COUNT.Text
    '    dao.fields.BUDGET_TRANSFER_DATE = rdp_BUDGET_TRANSFER_DATE.SelectedDate
    '    dao.fields.BUDGET_TRANSFER_DOC_DATE = rdp_BUDGET_TRANSFER_DOC_DATE.SelectedDate
    '    dao.fields.BUDGET_TRANSFER_DOC_NUMBER = txt_BUDGET_TRANSFER_DOC_NUMBER.Text
    '    dao.fields.FROM_BUDGET_PLAN_ID = Request.QueryString("bgid")
    '    dao.fields.FROM_DEPARTMENT_ID = Request.QueryString("dept")
    '    If is_dept_outside = "False" Then
    '        dao.fields.TO_BUDGET_PLAN_ID = dd_bg_adjust.SelectedValue
    '    Else
    '        dao.fields.TO_BUDGET_PLAN_ID = 0
    '    End If

    '    dao.fields.TO_DEPARTMENT_ID = dd_dept.SelectedValue
    '    dao.fields.TRANSFER_TYPE_ID = transfer_type
    'End Sub
    'Public Sub getdata(ByRef dao As DAO_BUDGET.TB_BUDGET_TRANSFER)
    '    txt_BUDGET_FROM_TRANSFER_DESCRIPTION.Text = dao.fields.BUDGET_FROM_TRANSFER_DESCRIPTION
    '    txt_BUDGET_TO_TRANSFER_DESCRIPTION.Text = dao.fields.BUDGET_TO_TRANSFER_DESCRIPTION
    '    txt_BUDGET_TRANSFER_COUNT.Text = dao.fields.BUDGET_TRANSFER_COUNT
    '    rdp_BUDGET_TRANSFER_DATE.SelectedDate = dao.fields.BUDGET_TRANSFER_DATE
    '    rdp_BUDGET_TRANSFER_DOC_DATE.SelectedDate = dao.fields.BUDGET_TRANSFER_DOC_DATE
    '    txt_BUDGET_TRANSFER_DOC_NUMBER.Text = dao.fields.BUDGET_TRANSFER_DOC_NUMBER
    'End Sub

    Public Sub insert(ByRef dao As DAO_BUDGET.TB_BUDGET_TRANSFER)
        Try
            Dim bao As New BAO_BUDGET.MASS
            Dim bool As Boolean = bao.get_support_dept_type(dd_BudgetAdjust.SelectedValue)
            If bool = False Then
                dao.fields.FROM_BUDGET_PLAN_ID = dd_BudgetAdjust.SelectedValue
            Else
                dao.fields.FROM_BUDGET_PLAN_ID = dd_sub_bg1.SelectedValue
            End If

            Dim bao2 As New BAO_BUDGET.MASS
            Dim bool2 As Boolean = bao.get_support_dept_type(dd_bg_adjust_receive.SelectedValue)
            If bool2 = False Then
                dao.fields.TO_BUDGET_PLAN_ID = dd_bg_adjust_receive.SelectedValue
            Else
                dao.fields.TO_BUDGET_PLAN_ID = dd_sub_bg2.SelectedValue
            End If

            dao.fields.BUDGET_FROM_TRANSFER_DESCRIPTION = txt_BUDGET_FROM_TRANSFER_DESCRIPTION.Text
            dao.fields.BUDGET_TO_TRANSFER_DESCRIPTION = txt_BUDGET_TO_TRANSFER_DESCRIPTION.Text
            dao.fields.BUDGET_TRANSFER_AMOUNT = rnt_BUDGET_TRANSFER_AMOUNT.Value
            dao.fields.BUDGET_TRANSFER_BUDGET_YEAR = Request.QueryString("bgYear")
            dao.fields.BUDGET_TRANSFER_COUNT = txt_BUDGET_TRANSFER_COUNT.Text
            If txt_BUDGET_TRANSFER_DATE.Text <> "" Then
                dao.fields.BUDGET_TRANSFER_DATE = CDate(txt_BUDGET_TRANSFER_DATE.Text)
            End If
            If txt_BUDGET_TRANSFER_DOC_DATE.Text <> "" Then
                dao.fields.BUDGET_TRANSFER_DOC_DATE = CDate(txt_BUDGET_TRANSFER_DOC_DATE.Text)
            End If
            dao.fields.BUDGET_TRANSFER_DOC_NUMBER = txt_BUDGET_TRANSFER_DOC_NUMBER.Text



            dao.fields.FROM_DEPARTMENT_ID = dd_Department.SelectedValue
            dao.fields.TO_DEPARTMENT_ID = dd_dept_receive.SelectedValue
            dao.fields.TRANSFER_TYPE_ID = 1

        Catch ex As Exception

        End Try
    End Sub
    Public Sub update(ByRef dao As DAO_BUDGET.TB_BUDGET_TRANSFER)
        dao.fields.BUDGET_FROM_TRANSFER_DESCRIPTION = txt_BUDGET_FROM_TRANSFER_DESCRIPTION.Text
        dao.fields.BUDGET_TO_TRANSFER_DESCRIPTION = txt_BUDGET_TO_TRANSFER_DESCRIPTION.Text
        dao.fields.BUDGET_TRANSFER_AMOUNT = rnt_BUDGET_TRANSFER_AMOUNT.Value
        dao.fields.BUDGET_TRANSFER_COUNT = txt_BUDGET_TRANSFER_COUNT.Text
        If txt_BUDGET_TRANSFER_DATE.Text <> "" Then
            dao.fields.BUDGET_TRANSFER_DATE = CDate(txt_BUDGET_TRANSFER_DATE.Text)
        End If
        If txt_BUDGET_TRANSFER_DOC_DATE.Text <> "" Then
            dao.fields.BUDGET_TRANSFER_DOC_DATE = CDate(txt_BUDGET_TRANSFER_DOC_DATE.Text)
        End If

        Dim bao As New BAO_BUDGET.MASS
        Dim bool As Boolean = bao.get_support_dept_type(dd_BudgetAdjust.SelectedValue)
        If bool = False Then
            dao.fields.FROM_BUDGET_PLAN_ID = dd_BudgetAdjust.SelectedValue
        Else
            dao.fields.FROM_BUDGET_PLAN_ID = dd_sub_bg1.SelectedValue
        End If

        Dim bao2 As New BAO_BUDGET.MASS
        Dim bool2 As Boolean = bao.get_support_dept_type(dd_bg_adjust_receive.SelectedValue)
        If bool2 = False Then
            dao.fields.TO_BUDGET_PLAN_ID = dd_bg_adjust_receive.SelectedValue
        Else
            dao.fields.TO_BUDGET_PLAN_ID = dd_sub_bg2.SelectedValue
        End If


        dao.fields.BUDGET_TRANSFER_DOC_NUMBER = txt_BUDGET_TRANSFER_DOC_NUMBER.Text
        ' dao.fields.FROM_BUDGET_PLAN_ID = dd_BudgetAdjust.SelectedValue
        dao.fields.FROM_DEPARTMENT_ID = dd_Department.SelectedValue
        'dao.fields.TO_BUDGET_PLAN_ID = dd_bg_adjust_receive.SelectedValue
        dao.fields.TO_DEPARTMENT_ID = dd_dept_receive.SelectedValue
        dao.fields.TRANSFER_TYPE_ID = 1
    End Sub
    Public Sub getdata(ByRef dao As DAO_BUDGET.TB_BUDGET_TRANSFER)
        'set_edit()
        txt_BUDGET_FROM_TRANSFER_DESCRIPTION.Text = dao.fields.BUDGET_FROM_TRANSFER_DESCRIPTION
        txt_BUDGET_TO_TRANSFER_DESCRIPTION.Text = dao.fields.BUDGET_TO_TRANSFER_DESCRIPTION
        rnt_BUDGET_TRANSFER_AMOUNT.Value = dao.fields.BUDGET_TRANSFER_AMOUNT
        txt_BUDGET_TRANSFER_COUNT.Text = dao.fields.BUDGET_TRANSFER_COUNT

        If dao.fields.BUDGET_TRANSFER_DATE IsNot Nothing Then
            txt_BUDGET_TRANSFER_DATE.Text = CDate(dao.fields.BUDGET_TRANSFER_DATE).ToShortDateString()
        End If
        If dao.fields.BUDGET_TRANSFER_DOC_DATE IsNot Nothing Then
            txt_BUDGET_TRANSFER_DOC_DATE.Text = CDate(dao.fields.BUDGET_TRANSFER_DOC_DATE).ToShortDateString()
        End If
        txt_BUDGET_TRANSFER_DOC_NUMBER.Text = dao.fields.BUDGET_TRANSFER_DOC_NUMBER

    End Sub

    Private Sub dd_BudgetAdjust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_BudgetAdjust.SelectedIndexChanged
        set_hide_unhide1()

    End Sub

    Public Sub cal_balance(ByVal bg_id As Integer)
        'Dim bao As New BAO_BUDGET.Budget
        'Dim amount As Double = 0
        'amount = bao.get_Transfer_Balance_Net(bg_id)
        Dim bgYear As Integer = Request.QueryString("bgYear")
        Dim uti_adjust As New Utility_other()
        Dim bao_transfer_out As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_transfer_diff As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_no_app As New BAO_BUDGET.DISBURSE_BUDGET
        Dim adjust_amount As Double = uti_adjust.getAdjust_Amount(bg_id, bgYear)
        Dim transfer_out_amount As Double = bao_transfer_out.get_transfer_outside_amount(bg_id, bgyear)
        Dim transfer_diff As Double = bao_transfer_diff.get_transfer_diff(bg_id)
        Dim bao As New BAO_BUDGET.MASS
        Dim bool As Boolean = bao.get_support_dept_type(bg_id)
        If bool = False Then
            lb_money.Text = ((adjust_amount + transfer_out_amount + transfer_diff) - bao_no_app.get_disburse_no_approve_amount(bg_id, bgYear)).ToString("N")
        Else
            lb_money.Text = ((adjust_amount + transfer_out_amount + transfer_diff) - bao_no_app.get_disburse_support_no_approve_amount(bg_id, bgYear)).ToString("N")
        End If

    End Sub

    Private Sub dd_sub_bg1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_sub_bg1.SelectedIndexChanged
        cal_balance(dd_sub_bg1.SelectedValue)
    End Sub

    Private Sub dd_bg_adjust_receive_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_bg_adjust_receive.SelectedIndexChanged
        set_hide_unhide2()
    End Sub

    Public Sub set_hide_unhide1()
        Dim bao As New BAO_BUDGET.MASS
        Dim bool As Boolean = False
        Try
            bool = bao.get_support_dept_type(dd_BudgetAdjust.SelectedValue)
        Catch ex As Exception

        End Try

        If bool = False Then
            Try
                cal_balance(dd_BudgetAdjust.SelectedValue)
            Catch ex As Exception

            End Try

            lb_sub_bg1.Style.Add("display", "none")
            dd_sub_bg1.Style.Add("display", "none")
        Else
            Try
                bind_sub_bg1(dd_BudgetAdjust.SelectedValue)
            Catch ex As Exception

            End Try

            lb_sub_bg1.Style.Add("display", "block")
            dd_sub_bg1.Style.Add("display", "block")
            cal_balance(dd_sub_bg1.SelectedValue)
        End If
    End Sub
    Public Sub set_hide_unhide2()
        Dim bao As New BAO_BUDGET.MASS
        Dim bool As Boolean = False
        Try
            bool = bao.get_support_dept_type(dd_bg_adjust_receive.SelectedValue)
        Catch ex As Exception

        End Try

        If bool = False Then
            lb_sub_bg2.Style.Add("display", "none")
            dd_sub_bg2.Style.Add("display", "none")
        Else
            Try
                bind_sub_bg2(dd_bg_adjust_receive.SelectedValue)
            Catch ex As Exception

            End Try

            lb_sub_bg2.Style.Add("display", "block")
            dd_sub_bg2.Style.Add("display", "block")
        End If
    End Sub
End Class