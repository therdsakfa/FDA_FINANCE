Public Class Frm_Disburse_Relate_Overview
    Inherits System.Web.UI.Page
    Public bgYear As Integer
    Private _dept As Integer
    Private _bgid As Integer
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Sub runQuery()
        _dept = Request.QueryString("dept")
        _bgid = Request.QueryString("bgid")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bgYear = Request.QueryString("myear")
        runQuery()
        RunSession()
        If Not IsPostBack Then
            bind_dl_department()
            bind_dl_bg()
            set_uc()
        End If
        Try
            'Dim dept_id As Integer = dd_Department.SelectedValue
        Catch ex As Exception

        End Try

        set_uc()
        'If _dept = 14 Then
        '    dd_Department.SelectedValue = 14
        'Else
        '    'dd_Department.SelectedValue = True
        'End If

        If _dept <> 0 Then
            dd_Department.SelectedValue = _dept
        Else
            _dept = 0
        End If

    End Sub
    Public Sub set_uc()
        UC_RELATE_BILL1.bg_use = 1
        Try
            UC_RELATE_BILL1.BudgetYear = Request.QueryString("myear") 'Master.get_Year()
            UC_Budget_Amount_Detail1.Budgetyear = Request.QueryString("myear")
        Catch ex As Exception

        End Try
        Try
            UC_RELATE_BILL1.dept = dd_Department.SelectedValue
            UC_Budget_Amount_Detail1.dept = dd_Department.SelectedValue
        Catch ex As Exception

        End Try
        Try
            UC_RELATE_BILL1.BudgetID = _bgid
            UC_Budget_Amount_Detail1.BudgetplanId = _bgid
            UC_Budget_Amount_Detail1.getData_detail(_bgid, _dept, Request.QueryString("myear"))
        Catch ex As Exception
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามรถใช้งานได้ เนื่องจากไม่ได้จัดสรรงบประมาณไว้ในปีที่เลือก') ; window.location='../../Frm_Main.aspx';", True)
        End Try

    End Sub
    Public Sub bind_dl_department()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_Department()
        dd_Department.DataSource = dt
        dd_Department.DataBind()
    End Sub

    'Private Sub dd_Department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_Department.SelectedIndexChanged
    '    bind_dl_bg()
    '    'UC_Budget_Amount_Detail1.clear_label()
    '    set_uc()
    '    UC_RELATE_BILL1.rebind_grid()
    'End Sub
    Public Sub bind_dl_bg()
        'dd_BudgetAdjust.Items.Clear()
        'Dim bao_adjust As New BAO_BUDGET.Budget
        'Dim dt As New DataTable
        'Try
        '    dt = bao_adjust.get_bg_adjust_by_dept_year(dd_Department.SelectedValue, Master.get_Year())
        'Catch ex As Exception

        'End Try

        'If dt.Rows.Count > 0 Then
        '    For Each dr As DataRow In dt.Rows
        '        Dim dao_head As New DAO_MAS.TB_BUDGET_PLAN
        '        dao_head.Getdata_by_BUDGET_PLAN_ID(dr("BUDGET_CHILD_ID"))
        '        Dim dao_head2 As New DAO_MAS.TB_BUDGET_PLAN
        '        dao_head2.Getdata_by_BUDGET_PLAN_ID(dao_head.fields.BUDGET_CHILD_ID)
        '        If dao_head2.fields.BUDGET_CODE <> "" Then
        '            If dao_head.fields.BUDGET_CODE <> "" Then
        '                dr("BUDGET_DESCRIPTION") = dao_head2.fields.BUDGET_CODE & " -> " & dao_head.fields.BUDGET_CODE & "-" & dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
        '            Else
        '                dr("BUDGET_DESCRIPTION") = dao_head2.fields.BUDGET_CODE & " -> " & dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
        '            End If
        '        Else
        '            If dao_head.fields.BUDGET_CODE <> "" Then
        '                dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_CODE & "-" & dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
        '            Else
        '                dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
        '            End If
        '        End If


        '    Next

        '    dd_BudgetAdjust.DataSource = dt
        '    dd_BudgetAdjust.DataBind()


        'End If

    End Sub
    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        'bind_dl_bg()
        set_uc()
        UC_RELATE_BILL1.rebind_grid()
    End Sub
    'Private Sub dd_BudgetAdjust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_BudgetAdjust.SelectedIndexChanged
    '    'UC_Budget_Amount_Detail1.clear_label()
    '    set_uc()
    '    UC_RELATE_BILL1.rebind_grid()
    'End Sub

    Private Sub dd_Department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_Department.SelectedIndexChanged
        UC_RELATE_BILL1.rebind_grid()
    End Sub
End Class