Public Class Frm_Disburse_Debtor_Overview
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
        Page.Title = "รายการลูกหนี้เงินยืม"

        runQuery()

        If Not IsPostBack Then
            bind_dl_department()
        End If
        set_uc()
    End Sub
    Public Sub set_uc()
        UC_Disburse_Debtor_With_Approve1.BudgetUseID = 1
        UC_Disburse_Debtor_With_Approve1.dept_id = dd_Department.SelectedValue
        Try
            UC_Budget_Amount_Detail1.BudgetplanId = _bgid
            UC_Disburse_Debtor_With_Approve1.BudgetID = _bgid




            UC_Budget_Amount_Detail1.dept = dd_Department.SelectedValue
            UC_Budget_Amount_Detail1.Budgetyear = bgYear

            UC_Disburse_Debtor_With_Approve1.BudgetYear = bgYear
            UC_Disburse_Debtor_With_Approve1.g = 0
            UC_Disburse_Debtor_With_Approve1.bt = 3
            UC_Disburse_Debtor_With_Approve1.stat = 3
        Catch ex As Exception

        End Try
        Try
            UC_Budget_Amount_Detail1.getData_detail(_bgid, dd_Department.SelectedValue, bgYear)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_Form1.getSearchMsg()
        UC_Disburse_Debtor_With_Approve1.rgFilter(str)
    End Sub


    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'UC_Disburse_Debtor1.set_color_rg()
        'UC_Disburse_Debtor1.bindseq()
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        set_uc()
        UC_Disburse_Debtor_With_Approve1.rebind_grid()
    End Sub

    Public Sub bind_dl_department()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_Department()
        dd_Department.DataSource = dt
        dd_Department.DataBind()
    End Sub
    Private Sub rdl_approve_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdl_approve.SelectedIndexChanged
        Dim str As String = ""
        str = "([app] like '%" & rdl_approve.SelectedValue & "%')"
        UC_Disburse_Debtor_With_Approve1.rgFilter(str)
    End Sub
    'Protected Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
    '    If rd_APPROVE_DATE.IsEmpty = False Then
    '        UC_Disburse_Debtor_With_Approve1.update_true(rd_APPROVE_DATE.SelectedDate)
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('อนุมัติเรียบร้อยแล้ว') ;", True)
    '        set_uc()
    '        UC_Disburse_Debtor_With_Approve1.rebind_grid()
    '    Else
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกวันที่') ;", True)
    '    End If

    'End Sub

    'Private Sub btn_no_approve_Click(sender As Object, e As EventArgs) Handles btn_no_approve.Click
    '    UC_Disburse_Debtor_With_Approve1.update_false()
    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกอนุมัติเรียบร้อยแล้ว') ;", True)
    '    set_uc()
    '    UC_Disburse_Debtor_With_Approve1.rebind_grid()
    'End Sub
    Protected Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
        If rd_APPROVE_DATE.IsEmpty = False Then
            If UC_Disburse_Debtor_With_Approve1.chk_selected = True Then
                If ddl_approve.SelectedValue = "1" Then
                    UC_Disburse_Debtor_With_Approve1.insert_approve(rd_APPROVE_DATE.SelectedDate, _CLS.CITIZEN_ID_AUTHORIZE)
                Else
                    If UC_Disburse_Debtor_With_Approve1.chk_selected_count <= 1 Then
                        UC_Disburse_Debtor_With_Approve1.open_reject_note()
                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('การกรอกเหตุผลการไม่อนุมัติ สามารถทำได้เพียงครั้งละ 1 รายการ') ;", True)
                    End If
                End If
                set_uc()
                UC_Disburse_Debtor_With_Approve1.rebind_grid()
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการที่ต้องการ') ;", True)
            End If
        Else
            If ddl_approve.SelectedValue <> "2" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกวันที่') ;", True)
            Else
                If UC_Disburse_Debtor_With_Approve1.chk_selected_count <= 1 Then
                    UC_Disburse_Debtor_With_Approve1.open_reject_note()
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('การกรอกเหตุผลการไม่อนุมัติ สามารถทำได้เพียงครั้งละ 1 รายการ') ;", True)
                End If
            End If

        End If
    End Sub

    Private Sub dd_Department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_Department.SelectedIndexChanged
        UC_Disburse_Debtor_With_Approve1.rebind_grid()
    End Sub
End Class