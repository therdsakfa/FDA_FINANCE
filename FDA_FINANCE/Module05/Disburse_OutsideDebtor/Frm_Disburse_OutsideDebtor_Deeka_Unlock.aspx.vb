Public Class Frm_Disburse_OutsideDebtor_Deeka_Unlock
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
        set_uc()

    End Sub
    Public Sub set_uc()
        Try

            UC_Disburse_Debtor_Unlock_Deeka1.BudgetID = _bgid
            UC_Disburse_Debtor_Unlock_Deeka1.dept_id = _dept
            UC_Disburse_Debtor_Unlock_Deeka1.BudgetUseID = 3
            UC_Disburse_Debtor_Unlock_Deeka1.g = 7
            UC_Disburse_Debtor_Unlock_Deeka1.stat = 3
            UC_Disburse_Debtor_Unlock_Deeka1.bt = 3

            UC_Disburse_Debtor_Unlock_Deeka1.BudgetYear = bgYear
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_Form1.getSearchMsg()
        UC_Disburse_Debtor_Unlock_Deeka1.rgFilter(str)
    End Sub


    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Debtor_Unlock_Deeka1.rebind_grid()
    End Sub

    Protected Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
        If rd_APPROVE_DATE.IsEmpty = False Then
            UC_Disburse_Debtor_Unlock_Deeka1.update_true(rd_APPROVE_DATE.SelectedDate, _CLS.CITIZEN_ID_AUTHORIZE)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ปลดเรียบร้อยแล้ว') ;", True)
            set_uc()
            UC_Disburse_Debtor_Unlock_Deeka1.rebind_grid()
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกวันที่') ;", True)
        End If

    End Sub

    Private Sub btn_no_approve_Click(sender As Object, e As EventArgs) Handles btn_no_approve.Click
        UC_Disburse_Debtor_Unlock_Deeka1.update_false(2)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกอนุมัติเรียบร้อยแล้ว') ;", True)
        set_uc()
        UC_Disburse_Debtor_Unlock_Deeka1.rebind_grid()
    End Sub
End Class