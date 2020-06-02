Public Class Frm_Disburse_Debtor_Margin
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
        Page.Title = "ลูกหนี้เงินยืมเงินด่วน (เช็ค)"
        Dim bgyear As Integer = Request.QueryString("myear")
        UC_Disburse_Debtor_Margin1.BudgetYear = bgyear
        UC_Disburse_Debtor_Margin1.bguse = 1
    End Sub
    

    Private Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click
        'Response.Redirect("Frm_Disburse_Debtor_Bill_Margin_Insert.aspx")
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_Form1.getSearchMsg()
        UC_Disburse_Debtor_Margin1.rgFilter(str)
    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'UC_Disburse_Debtor_Margin1.bindseq()
    End Sub

    Private Sub dd_status_TextChanged(sender As Object, e As EventArgs) Handles dd_status.TextChanged
        Dim str As String = UC_Search_Form1.getSearchMsg()
        If str <> "" Then
            str = str & " and ([digit] like '%" & dd_status.SelectedValue.ToString & "%')"
            UC_Disburse_Debtor_Margin1.rgFilter(str)
        Else
            str = " ([digit] like '%" & dd_status.SelectedValue.ToString & "%')"
            UC_Disburse_Debtor_Margin1.rgFilter(str)
        End If
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Debtor_Margin1.rg_rebind()
    End Sub
End Class