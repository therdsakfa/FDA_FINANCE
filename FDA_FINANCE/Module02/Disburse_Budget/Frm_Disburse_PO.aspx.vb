Public Class Frm_Disburse_PO
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
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
        UC_Disburse_PO1.bgyear = bgYear
        UC_Disburse_PO1.ReId = _bgid

        If Not IsPostBack Then
            Dim bao As New BAO_BUDGET.MASS
            'Dim dt As DataTable = bao.get_Department()
            'dd_Department.DataSource = dt
            'dd_Department.DataBind()
            lastest_dept_selected()
            bind_dl_bg()
            lastest_bg_selected()
            set_uc()
        End If
        set_uc()

        UC_Project_Information1.set_lb()
    End Sub
    Public Sub lastest_dept_selected()

        Dim dept As String = ""
        If Request.QueryString("dept") IsNot Nothing Then
            dept = Request.QueryString("dept")
        End If

        'If dept <> "" Then
        '    dd_Department.DropDownSelectData(dept)

        'End If

    End Sub
    Public Sub lastest_bg_selected()
        Dim bgid As String = ""
        If Request.QueryString("bgid") IsNot Nothing Then
            bgid = Request.QueryString("bgid")
        End If
        'If bgid <> "" Then
        '    dd_BudgetAdjust.DropDownSelectData(bgid)
        'End If
    End Sub
    Public Sub bind_dl_department()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_Department()
        'dd_Department.DataSource = dt
        'dd_Department.DataBind()

        'bind_dl_bg()
        'UC_Disburse_PO1.rebind_grid()
    End Sub
    Public Sub set_uc()
        Try
            UC_Disburse_PO1.bg_id = _bgid
            UC_Disburse_PO1.bguse = 1
            UC_Budget_Amount_Detail1.BudgetplanId = _bgid
            UC_Budget_Amount_Detail1.dept = _dept
            UC_Budget_Amount_Detail1.Budgetyear = bgYear
            UC_Budget_Amount_Detail1.getData_detail(_bgid, _dept, bgYear)
        Catch ex As Exception
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามรถใช้งานได้ เนื่องจากไม่ได้จัดสรรงบประมาณไว้ในปีที่เลือก') ; window.location='../../Frm_Main.aspx';", True)
        End Try

        UC_Disburse_PO1.bt = 2
        UC_Disburse_PO1.g = 0
        UC_Disburse_PO1.stat = 3
        UC_Disburse_PO1.dept = _dept
    End Sub

    'Private Sub dd_Department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_Department.SelectedIndexChanged
    '    bind_dl_bg()
    '    set_uc()
    '    UC_Disburse_PO_With_Approve1.rebind_grid()
    'End Sub
    Public Sub bind_dl_bg()
        Dim bao_adjust As New BAO_BUDGET.Budget
        Dim dt As DataTable = bao_adjust.get_bg_adjust_by_dept_year(_bgid, bgYear)

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

            'dd_BudgetAdjust.DataSource = dt
            'dd_BudgetAdjust.DataBind()


        End If
        'UC_Disburse_PO1.rebind_grid()
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        set_uc()
        UC_Disburse_PO1.rebind_grid()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        set_uc()
        Dim str As String
        'str = UC_Search_Form1.getSearchMsg()
        str = UC_Search_Form_with_description1.getSearchMsg()
        UC_Disburse_PO1.rgFilter(str)
    End Sub
End Class