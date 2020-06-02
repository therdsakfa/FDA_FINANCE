Public Class Frm_Disburse_PO_Sub_List
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
        'Page.Title = "รายการบันทึกเลข GFMIS"
        UC_PO_Sub_List1.ispo = "True"
        UC_PO_Sub_List1.bg_use = 1

        UC_PO_Sub_List1.Budgetyear = Request.QueryString("myear")
        UC_PO_Sub_List1.bt = 2
        UC_PO_Sub_List1.stat = 2
        UC_PO_Sub_List1.g = 0
        UC_PO_Sub_List1.is_rebill = False
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_Form1.getSearchMsg_2()
        UC_PO_Sub_List1.rgFilter(str)
    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'UC_Disburse_Budget_Bill1.bindseq()
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_PO_Sub_List1.rebind_grid()
    End Sub

    Private Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
        UC_PO_Sub_List1.insert_approve(rd_APPROVE_DATE.SelectedDate, _CLS.CITIZEN_ID)
    End Sub
End Class