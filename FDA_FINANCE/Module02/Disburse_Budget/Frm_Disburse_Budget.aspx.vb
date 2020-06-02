Imports Telerik.Web.UI
Imports System.Web.Services
Partial Public Class Frm_Disburse_Budget2
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
        Page.Title = "รายการเบิกจ่ายงบประมาณ"

        ' Dim dept_id As Integer = bao_user.get_dept(NameUserAD())
        'Dim dept_id As Integer = bao_user.get_dept(NameUserAD())
        If Not IsPostBack Then
            'Dim bao_adjust As New BAO_BUDGET.Budget
            'Dim dt As DataTable = bao_adjust.get_bg_adjust_by_dept_year(dept_id, bgYear)

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
        End If
        'btn_Add.Attributes.Add("OnClick", "return k('0'," & dd_BudgetAdjust.SelectedValue & ");")
        set_uc()
        UC_Disburse_Budget1.BudgetUseID = 1

        Try
            UC_Disburse_Budget1.bt = 2
            UC_Disburse_Budget1.g = 0
            UC_Disburse_Budget1.stat = 3
        Catch ex As Exception

        End Try
    End Sub
    Public Sub set_uc()
        Try
            UC_Disburse_Budget1.dept = _dept
            UC_Budget_Amount_Detail1.dept = _dept
        Catch ex As Exception

        End Try
        Try
            UC_Disburse_Budget1.BudgetYear = bgYear
            UC_Budget_Amount_Detail1.Budgetyear = bgYear
        Catch ex As Exception

        End Try
        Try
            UC_Disburse_Budget1.BudgetID = _bgid

            UC_Budget_Amount_Detail1.BudgetplanId = _bgid


            UC_Budget_Amount_Detail1.getData_detail(_bgid, _dept, bgYear)
            
        Catch ex As Exception
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามรถใช้งานได้ เนื่องจากไม่ได้จัดสรรงบประมาณไว้ในปีที่เลือก') ; window.location='../../Frm_Main.aspx';", True)
        End Try
    End Sub
    Private Sub btn_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Add.Click
        ' Response.Redirect("Frm_Disburse_Budget_Bill_Insert.aspx")



    End Sub

    'Public Function getbgYear() As Integer
    '    Dim bgYear As Integer = 0
    '    Dim dd_BudgetYear As DropDownList
    '    dd_BudgetYear = CType(Master.FindControl("dd_BudgetYear"), DropDownList)
    '    bgYear = dd_BudgetYear.SelectedValue
    '    Return bgYear
    'End Function

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        'UC_Disburse_Budget1.set_color_rg()
        'UC_Disburse_Budget1.bindseq()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_Form1.getSearchMsg()
        'str = UC_Search_Form1.getSearchMsg_2()
        UC_Disburse_Budget1.rgFilter(str)
    End Sub

    Public Sub del_item(ByVal id As Integer)
        Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
        Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        dao_head.Getdata_by_BUDGET_DISBURSE_BILL_ID(id)
        dao_detail.Getdata_by_Disburse_id(id)
        dao_head.delete()
        dao_detail.delete()

        'UC_Disburse_Budget1.rebind_grid()
        'Response.Redirect("../../Module02/Disburse_Budget/Frm_Disburse_Budget.aspx")
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        set_uc()
        UC_Disburse_Budget1.rebind_grid()
    End Sub

    'Private Sub rdl_approve_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdl_approve.SelectedIndexChanged
    '    Dim str As String = ""
    '    str = "([app] like '%" & rdl_approve.SelectedValue & "%')"
    '    UC_Disburse_Budget1.rgFilter(str)
    'End Sub
End Class