Public Class Frm_Disburse_OutsideDebtor_Boss_Approve
    Inherits System.Web.UI.Page
    Public bgYear As Integer
    Private _dept As Integer
    Private _bgid As Integer
    Private _CLS As New CLS_SESSION
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
        UC_Disburse_Debtor_Boss_Approve1.BudgetUseID = 3
        UC_Disburse_Debtor_Boss_Approve1.bgyear = bgYear
        UC_Disburse_Debtor_Boss_Approve1.g = 7
        UC_Disburse_Debtor_Boss_Approve1.bt = 3
        UC_Disburse_Debtor_Boss_Approve1.stat = 2
        UC_Disburse_Debtor_Boss_Approve1.g2 = 0
        UC_Disburse_Debtor_Boss_Approve1.stat2 = 7
    End Sub
    Private Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
        If rd_APPROVE_DATE.IsEmpty = False Then
            UC_Disburse_Debtor_Boss_Approve1.update_true(rd_APPROVE_DATE.SelectedDate, _CLS.CITIZEN_ID_AUTHORIZE)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย') ;", True)
            UC_Disburse_Debtor_Boss_Approve1.rg_rebind()
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกวันที่') ;", True)
        End If
    End Sub
End Class