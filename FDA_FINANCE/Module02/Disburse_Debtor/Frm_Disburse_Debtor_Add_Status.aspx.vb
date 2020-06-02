Public Class Frm_Disburse_Debtor_Add_Status
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
        Page.Title = "บันทึกสถานะลูกหนี้เงินยืม(เงินงบประมาณ)"
        UC_Disburse_Debtor_Add_Status1.bg_use = 1
        UC_Disburse_Debtor_Add_Status1.debtor_type = 2
        UC_Disburse_Debtor_Add_Status1.bgyear = Request.QueryString("myear")

    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'UC_Disburse_Debtor_Add_Status1.bindseq()
    End Sub

    Private Sub dd_status_TextChanged(sender As Object, e As EventArgs) Handles dd_status.TextChanged
        UC_Disburse_Debtor_Add_Status1.rg_rebind()
        Dim str As String '= UC_Search_Form1.getSearchMsg()
        str = " [digit] like '%" & dd_status.SelectedValue & "%'"
        UC_Disburse_Debtor_Add_Status1.rgFilter(str)
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Debtor_Add_Status1.rg_rebind()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_Form1.getSearchMsg()
        UC_Disburse_Debtor_Add_Status1.rgFilter(str)
    End Sub
End Class