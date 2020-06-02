Public Class Frm_Disburse_Relate_Head_Approve
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
        RunSession()
        bgYear = Master.get_Year()
        runQuery()

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
    End Sub
    Public Sub set_uc()
        Try
            UC_RELATE_BILL_WITH_HEAD_APPROVE1.BudgetID = _bgid
            UC_RELATE_BILL_WITH_HEAD_APPROVE1.BudgetYear = Request.QueryString("myear") 'Master.get_Year()
            UC_RELATE_BILL_WITH_HEAD_APPROVE1.dept = _dept
            UC_RELATE_BILL_WITH_HEAD_APPROVE1.bg_use = 1
            UC_Budget_Amount_Detail1.Budgetyear = Request.QueryString("myear")
            UC_Budget_Amount_Detail1.dept = _dept
            UC_Budget_Amount_Detail1.BudgetplanId = _bgid
            UC_Budget_Amount_Detail1.getData_detail(_bgid, _dept, Request.QueryString("myear"))
        Catch ex As Exception
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามรถใช้งานได้ เนื่องจากไม่ได้จัดสรรงบประมาณไว้ในปีที่เลือก') ; window.location='../../Frm_Main.aspx';", True)
        End Try

    End Sub
    Public Sub bind_dl_department()
        'Dim bao As New BAO_BUDGET.MASS
        'Dim dt As DataTable = bao.get_Department()
        'dd_Department.DataSource = dt
        'dd_Department.DataBind()
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
        UC_RELATE_BILL_WITH_HEAD_APPROVE1.rebind_grid()
    End Sub
    'Private Sub dd_BudgetAdjust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_BudgetAdjust.SelectedIndexChanged
    '    'UC_Budget_Amount_Detail1.clear_label()
    '    set_uc()
    '    UC_RELATE_BILL1.rebind_grid()
    'End Sub


    Private Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
        If rd_APPROVE_DATE.IsEmpty = False Then
            If UC_RELATE_BILL_WITH_HEAD_APPROVE1.chk_selected = True Then
                'UC_RELATE_BILL_WITH_HEAD_APPROVE1.update_true(rd_APPROVE_DATE.SelectedDate)
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('อนุมัติเรียบร้อยแล้ว') ;", True)

                If ddl_approve.SelectedValue = "1" Then
                    UC_RELATE_BILL_WITH_HEAD_APPROVE1.insert_approve(rd_APPROVE_DATE.SelectedDate, _CLS.CITIZEN_ID_AUTHORIZE)
                Else
                    If UC_RELATE_BILL_WITH_HEAD_APPROVE1.chk_selected_count <= 1 Then
                        UC_RELATE_BILL_WITH_HEAD_APPROVE1.open_reject_note()
                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('การกรอกเหตุผลการไม่อนุมัติ สามารถทำได้เพียงครั้งละ 1 รายการ') ;", True)
                    End If
                End If

                set_uc()
                UC_RELATE_BILL_WITH_HEAD_APPROVE1.rebind_grid()
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการที่ต้องการ') ;", True)
            End If
        Else
            If ddl_approve.SelectedValue <> "2" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกวันที่') ;", True)
            Else
                If UC_RELATE_BILL_WITH_HEAD_APPROVE1.chk_selected_count <= 1 Then
                    UC_RELATE_BILL_WITH_HEAD_APPROVE1.open_reject_note()
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('การกรอกเหตุผลการไม่อนุมัติ สามารถทำได้เพียงครั้งละ 1 รายการ') ;", True)
                End If
            End If

        End If
    End Sub

    'Private Sub btn_no_approve_Click(sender As Object, e As EventArgs) Handles btn_no_approve.Click
    '    UC_RELATE_BILL_WITH_HEAD_APPROVE1.update_false()
    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกอนุมัติเรียบร้อยแล้ว') ;", True)
    '    set_uc()
    '    UC_RELATE_BILL_WITH_HEAD_APPROVE1.rebind_grid()
    'End Sub
End Class