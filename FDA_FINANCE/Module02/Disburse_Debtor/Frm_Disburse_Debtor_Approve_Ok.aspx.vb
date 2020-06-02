Public Class Frm_Disburse_Debtor_Approve_Ok
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
        bgYear = Request.QueryString("myear")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()
        'Page.Title = "อนุมัติรายการลูกหนี้เงินยืม"
        UC_Disburse_Debtor_Approve_Ok1.BudgetUseID = 1
  
        If Not IsPostBack Then
            ' bind_dl_department()
            bind_dl_bg()

        End If
        set_uc()
    End Sub
    Public Sub set_uc()
        Try
            UC_Disburse_Debtor_Approve_Ok1.BudgetID = _bgid
            UC_Disburse_Debtor_Approve_Ok1.bgyear = bgYear
            UC_Disburse_Debtor_Approve_Ok1.bt = 3
            UC_Disburse_Debtor_Approve_Ok1.g = 0
            UC_Disburse_Debtor_Approve_Ok1.stat = 7
            UC_Budget_Amount_Detail1.BudgetplanId = _bgid
            UC_Budget_Amount_Detail1.dept = _dept
            UC_Budget_Amount_Detail1.Budgetyear = bgYear
            UC_Budget_Amount_Detail1.getData_detail(_bgid, _dept, bgYear)
            'UC_Budget_Amount_Detail1.get_all_bg_amount(bgYear)
        Catch ex As Exception
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามรถใช้งานได้ เนื่องจากไม่ได้จัดสรรงบประมาณไว้ในปีที่เลือก') ; window.location='../../Frm_Main.aspx';", True)
        End Try
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        set_uc()
        Dim str As String
        'str = UC_Search_Form1.getSearchMsg()
        str = UC_Search_Form_Approve1.getSearchMsg()
        UC_Disburse_Debtor_Approve_Ok1.rgFilter(str)
    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'UC_Disburse_Debtor_Approve_Ok1.bindseq()
        'If Not IsPostBack Then
        '    Dim str As String = UC_Search_Form_Approve1.getSearchMsg()
        '    UC_Disburse_Debtor_Approve_Ok1.rgFilter(str)
        'End If
        'UC_Disburse_Debtor_Approve_Ok1.set_color_rg()
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Debtor_Approve_Ok1.rg_rebind()
    End Sub

    'Private Sub dd_BudgetAdjust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_BudgetAdjust.SelectedIndexChanged
    '    set_uc()
    '    UC_Disburse_Debtor_Approve_Ok1.rg_rebind()
    'End Sub

    'Private Sub dd_Department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_Department.SelectedIndexChanged
    '    bind_dl_bg()
    '    set_uc()
    '    UC_Disburse_Debtor_Approve_Ok1.rg_rebind()
    'End Sub
    'Public Sub bind_dl_department()
    '    Dim bao As New BAO_BUDGET.MASS
    '    Dim dt As DataTable = bao.get_Department()
    '    dd_Department.DataSource = dt
    '    dd_Department.DataBind()
    'End Sub
    Public Sub bind_dl_bg()
        'Dim bao_adjust As New BAO_BUDGET.Budget
        'Dim dt As DataTable = bao_adjust.get_bg_adjust_by_dept_year(dd_Department.SelectedValue, Master.get_Year())

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
        ' UC_Disburse_Budget1.rebind_grid()
    End Sub

End Class