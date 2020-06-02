Public Partial Class Frm_BudgetPlan_Adjust
    Inherits System.Web.UI.Page
    Dim bg_id As Integer
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
        If Not IsPostBack Then
            'bind_ddl_dept()

        End If

        Dim bao As New BAO_BUDGET.MASS

        'Dim bgYear As String = Master.get_Year()

        'lbHide.Text = UC_BudgetPlan1.getbg_id()

        'UC_BudgetPlan_Adjust1.dept_id = dd_Department.SelectedValue
        Try
            UC_BudgetPlan_For_Adjust1.bgyear = Request.QueryString("myear")
            UC_BudgetPlan_For_Adjust1.is_Adjust = True
        Catch ex As Exception

        End Try


    End Sub


    Public Sub BindData()
        UC_BudgetPlan_Adjust_Information1.BindData(UC_BudgetPlan_For_Adjust1.getbg_id())
        UC_BudgetPlan_Adjust1.budget_id = UC_BudgetPlan_For_Adjust1.getbg_id()
        ' lbHide.Text = UC_BudgetPlan1.getbg_id()
        txt_hide.Text = UC_BudgetPlan_For_Adjust1.getbg_id()
        ' System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_Button1').click();", True)
        UC_BudgetPlan_Adjust1.BindData()



    End Sub
    'Public Sub bind_ddl_dept()
    '    Dim bao As New BAO_BUDGET.MASS
    '    Dim dt As DataTable = bao.get_Department()
    '    dd_Department.DataSource = dt
    '    dd_Department.DataBind()
    'End Sub
    ' Private Sub DD_Bind()

    'Dim bao As New BAO_BUDGET.Budget

    'Dim dt As DataTable = bao.get_dept_name()
    'dd_Department.DataSource = dt
    'dd_Department.DataBind()
    'End Sub

    'Private Sub dd_Department_TextChanged(sender As Object, e As EventArgs) Handles dd_Department.TextChanged

    '    UC_BudgetPlan_Adjust1.budget_id = UC_BudgetPlan1.getbg_id()
    '    bg_id = UC_BudgetPlan1.getbg_id()
    '    'UC_BudgetPlan_Adjust1.budget_id = lbHide.Text
    '    txt_hide.Text = UC_BudgetPlan1.return_nodeid()
    '    UC_BudgetPlan_Adjust1.budget_id = txt_hide.Text

    '    UC_BudgetPlan_Adjust1.BindData()
    '    UC_BudgetPlan_Adjust1.rg_rebind()
    'End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Response.Redirect("Frm_BudgetPlan_Adjust_Insert.aspx?bgid=" & lbHide.Text & "&dept=" & dd_Department.SelectedValue)
    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_BudgetPlan_Adjust1.bindseq()
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_BudgetPlan_Adjust1.budget_id = UC_BudgetPlan_For_Adjust1.return_nodeid()
        UC_BudgetPlan_Adjust1.rg_rebind()
    End Sub
    'Public Sub bind_rg(ByVal bgid As Integer)
    '    UC_BudgetPlan_Adjust1.budget_id = UC_BudgetPlan_For_Adjust1.getbg_id()
    '    UC_BudgetPlan_Adjust1.BindData()
    'End Sub
    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    'End Sub

 
End Class