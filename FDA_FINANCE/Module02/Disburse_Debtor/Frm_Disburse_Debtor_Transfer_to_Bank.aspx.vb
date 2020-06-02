Public Class Frm_Disburse_Debtor_Transfer_to_Bank
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
        set_uc()
    End Sub
    Public Sub set_uc()
        UC_Disburse_Debtor_Transfer_to_Bank1.debtor_type = 2
        UC_Disburse_Debtor_Transfer_to_Bank1.BudgetUseID = 1
        UC_Disburse_Debtor_Transfer_to_Bank1.BudgetYear = bgYear
        UC_Disburse_Debtor_Transfer_to_Bank1.bt = 3
        UC_Disburse_Debtor_Transfer_to_Bank1.stat = 5
        UC_Disburse_Debtor_Transfer_to_Bank1.g = 1
    End Sub
    Private Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
        If rd_APPROVE_DATE.IsEmpty = False Then
            UC_Disburse_Debtor_Transfer_to_Bank1.update_true(rd_APPROVE_DATE.SelectedDate, _CLS.CITIZEN_ID_AUTHORIZE)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อยแล้ว') ;", True)
            set_uc()
            UC_Disburse_Debtor_Transfer_to_Bank1.rebind_grid()
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกวันที่') ;", True)
        End If
    End Sub
    Private Sub btn_no_approve_Click(sender As Object, e As EventArgs) Handles btn_no_approve.Click
        UC_Disburse_Debtor_Transfer_to_Bank1.update_false(13)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกเรียบร้อยแล้ว') ;", True)
        set_uc()
        UC_Disburse_Debtor_Transfer_to_Bank1.rebind_grid()
    End Sub
End Class