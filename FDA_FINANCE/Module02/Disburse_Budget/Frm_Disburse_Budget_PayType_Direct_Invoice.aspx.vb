Public Class Frm_Disburse_Budget_PayType_Direct_Invoice
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
        Page.Title = "เพิ่ม/แก้ไขใบหักภาษี"
        set_uc()
    End Sub
    Public Sub set_uc()
        UC_Disburse_Budget_PayType_Direct_Invoice1.g = 1
        UC_Disburse_Budget_PayType_Direct_Invoice1.bt = 2
        UC_Disburse_Budget_PayType_Direct_Invoice1.stat = 2
        UC_Disburse_Budget_PayType_Direct_Invoice1.ispo = False
        UC_Disburse_Budget_PayType_Direct_Invoice1.PAY_TYPE_ID = 1
        UC_Disburse_Budget_PayType_Direct_Invoice1.bg_use = 1
        UC_Disburse_Budget_PayType_Direct_Invoice1.bgyear = Request.QueryString("myear")

    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_Form1.getSearchMsg_2()
        UC_Disburse_Budget_PayType_Direct_Invoice1.rgFilter(str)
    End Sub
    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Budget_PayType_Direct_Invoice1.rg_rebind()
    End Sub
End Class