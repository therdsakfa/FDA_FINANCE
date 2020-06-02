Public Class Frm_Disburse_Relate_Overview_withdraw_v2
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
        Page.Title = "รับเรื่องเบิกเงินงบประมาณ"
        UC_Disburse_Budget_Bill_withdraw1.ispo = "False"
        UC_Disburse_Budget_Bill_withdraw1.BudgetUseID = 1
        UC_Disburse_Budget_Bill_withdraw1.PAY_TYPE_ID = 1
        UC_Disburse_Budget_Bill_withdraw1.Budgetyear = Request.QueryString("myear")
        UC_Disburse_Budget_Bill_withdraw1.bt = 2
        'UC_Disburse_Budget_Bill_withdraw1.stat = 6
        UC_Disburse_Budget_Bill_withdraw1.stat = 5
        UC_Disburse_Budget_Bill_withdraw1.g = 0
        UC_Disburse_Budget_Bill_withdraw1.is_rebill = False
        UC_Disburse_Budget_Bill_withdraw1.type = 1
        UC_Disburse_Budget_Bill_withdraw1.bguse = 1
        UC_Disburse_Budget_Bill_withdraw1.Citizen = _CLS.CITIZEN_ID

        '' UC_Disburse_Budget_Receive_List1.ispo = "False"
        'UC_Disburse_Budget_Bill_withdraw1.stat = 5
        'UC_Disburse_Budget_Bill_withdraw1.bt = 2
        'UC_Disburse_Budget_Bill_withdraw1.g = 0
        'UC_Disburse_Budget_Receive_List1.type = 1

    End Sub


    

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'UC_Disburse_Budget_Bill1.bindseq()
    End Sub
    'Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
    '    Dim str As String
    '    str = UC_Search_Form1.getSearchMsg_2()
    '    UC_Disburse_Budget_Bill_withdraw1.rgFilter(str)
    'End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Budget_Bill_withdraw1.rgRebind()
    End Sub

End Class