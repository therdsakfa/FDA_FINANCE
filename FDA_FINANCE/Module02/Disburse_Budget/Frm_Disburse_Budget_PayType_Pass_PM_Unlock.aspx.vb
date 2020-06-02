Public Class Frm_Disburse_Budget_PayType_Pass_PM_Unlock
    Inherits System.Web.UI.Page
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
        Page.Title = "บันทึกเลขปลดจ่าย"
        UC_Disburse_Budget_PayType_Pass_Pay_Unlock1.ispo = "False"
        UC_Disburse_Budget_PayType_Pass_Pay_Unlock1.bg_use = 1
        UC_Disburse_Budget_PayType_Pass_Pay_Unlock1.PAY_TYPE_ID = 2
        UC_Disburse_Budget_PayType_Pass_Pay_Unlock1.bgyear = Request.QueryString("myear")
        UC_Disburse_Budget_PayType_Pass_Pay_Unlock1.bt = 2
        UC_Disburse_Budget_PayType_Pass_Pay_Unlock1.stat = 5
        UC_Disburse_Budget_PayType_Pass_Pay_Unlock1.g = 2
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_Form1.getSearchMsg_2()
        UC_Disburse_Budget_PayType_Pass_Pay_Unlock1.rgFilter(str)
    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Budget_PayType_Pass_Pay_Unlock1.rgRebind()
    End Sub
End Class