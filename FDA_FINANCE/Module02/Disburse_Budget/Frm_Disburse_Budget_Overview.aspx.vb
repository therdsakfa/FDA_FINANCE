Public Class Frm_Disburse_Budget_Overview
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
        'Dim b = Request.Url
        runQuery()

        'Page.Title = "รายการเบิกจ่ายงบประมาณ"

        'Dim dept_id As Integer = bao_user.get_dept(NameUserAD())


        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)

        If Not IsPostBack Then
            bind_dl_department()
            bind_dl_bg()
        End If
        set_uc()
    End Sub
  
    Public Sub set_uc()
        Try
            UC_Disburse_Budget_With_Approve1.BudgetID = _bgid
            UC_Disburse_Budget_With_Approve1.BudgetUseID = 1
            UC_Disburse_Budget_With_Approve1.dept = dd_Department.SelectedValue '_dept
            UC_Budget_Amount_Detail1.BudgetplanId = _bgid
            UC_Budget_Amount_Detail1.dept = dd_Department.SelectedValue '_dept
            UC_Budget_Amount_Detail1.Budgetyear = Request.QueryString("myear")

            UC_Disburse_Budget_With_Approve1.BudgetYear = Request.QueryString("myear")
            UC_Disburse_Budget_With_Approve1.bt = 2
            UC_Disburse_Budget_With_Approve1.g = 0
            UC_Disburse_Budget_With_Approve1.stat = 3

        Catch ex As Exception
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามรถใช้งานได้ เนื่องจากไม่ได้จัดสรรงบประมาณไว้ในปีที่เลือก') ; window.location='../../Frm_Main.aspx';", True)
        End Try

        Try
            UC_Budget_Amount_Detail1.getData_detail(_bgid, _dept, Request.QueryString("myear"))
        Catch ex As Exception

        End Try
        'window.location= "index.php"

    End Sub

    Public Sub bind_dl_department()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_Department()
        dd_Department.DataSource = dt
        dd_Department.DataBind()
    End Sub

    'Private Sub dd_Department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_Department.SelectedIndexChanged
    '    bind_dl_bg()
    '    set_uc()
    '    UC_Disburse_Budget_With_Approve1.rebind_grid()
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
    Private Sub Frm_Disburse_Budget_Overview_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'UC_Disburse_Budget_With_Approve1.set_color_rg()
        'UC_Disburse_Budget_With_Approve1.bindseq()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'Dim str As String
        'set_uc()
        'str = UC_Search_Form1.getSearchMsg()
        'UC_Disburse_Budget_With_Approve1.rgFilter(str)
        Dim str As String
        str = getSearchMsg()
        UC_Disburse_Budget_With_Approve1.rgFilter(str)
    End Sub
    Public Function getSearchMsg() As String
        Dim strMsg As String = ""
        Dim docdate As String = ""
        Try
            docdate = CDate(txtSearch_DateBill.SelectedDate).ToShortDateString()
        Catch ex As Exception

        End Try
        If strMsg = "" Then
            If docdate <> "" Then
                strMsg = "([DOC_DATE] ='" & docdate & "') "

            ElseIf txtSearch_numbill.Text <> "" Then
                strMsg = "([DOC_NUMBER] LIKE '%" & txtSearch_numbill.Text & "%') "
            ElseIf txtSearch_GF.Text <> "" Then
                strMsg = "([GFMIS_NUMBER] LIKE '%" & txtSearch_GF.Text & "%') "
                'ElseIf txtSearch_DateBill.SelectedDate <> "" Then

            End If

        End If

        Return strMsg
    End Function

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        'bind_dl_bg()
        set_uc()
        UC_Disburse_Budget_With_Approve1.rebind_grid()
    End Sub

    Private Sub rdl_approve_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdl_approve.SelectedIndexChanged
        Dim str As String = ""
        str = "([app] like '%" & rdl_approve.SelectedValue & "%')"
        UC_Disburse_Budget_With_Approve1.rgFilter(str)
    End Sub

    'Private Sub dd_BudgetAdjust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_BudgetAdjust.SelectedIndexChanged
    '    set_uc()
    '    UC_Disburse_Budget_With_Approve1.rebind_grid()
    'End Sub
    Protected Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
        If rd_APPROVE_DATE.IsEmpty = False Then
            If UC_Disburse_Budget_With_Approve1.chk_selected = True Then
                If ddl_approve.SelectedValue = "1" Then
                    UC_Disburse_Budget_With_Approve1.insert_approve(rd_APPROVE_DATE.SelectedDate, _CLS.CITIZEN_ID_AUTHORIZE)
                Else
                    If UC_Disburse_Budget_With_Approve1.chk_selected_count <= 1 Then
                        UC_Disburse_Budget_With_Approve1.open_reject_note()
                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('การกรอกเหตุผลการไม่อนุมัติ สามารถทำได้เพียงครั้งละ 1 รายการ') ;", True)
                    End If
                End If
                set_uc()
                UC_Disburse_Budget_With_Approve1.rebind_grid()
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการที่ต้องการ') ;", True)
            End If
        Else
            If ddl_approve.SelectedValue <> "2" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกวันที่') ;", True)
            Else
                If UC_Disburse_Budget_With_Approve1.chk_selected_count <= 1 Then
                    UC_Disburse_Budget_With_Approve1.open_reject_note()
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('การกรอกเหตุผลการไม่อนุมัติ สามารถทำได้เพียงครั้งละ 1 รายการ') ;", True)
                End If
            End If

        End If
    End Sub

    'Private Sub btn_no_approve_Click(sender As Object, e As EventArgs) Handles btn_no_approve.Click
    '    UC_Disburse_Budget_With_Approve1.update_false()
    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกอนุมัติเรียบร้อยแล้ว') ;", True)
    '    set_uc()
    '    UC_Disburse_Budget_With_Approve1.rebind_grid()
    'End Sub

    Private Sub dd_Department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_Department.SelectedIndexChanged
        UC_Disburse_Budget_With_Approve1.rebind_grid()
    End Sub
End Class