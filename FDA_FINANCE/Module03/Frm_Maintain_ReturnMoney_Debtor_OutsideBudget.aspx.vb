Public Class Frm_Maintain_ReturnMoney_Debtor_OutsideBudget
    Inherits System.Web.UI.Page
    Dim strMoneyType As String
    Dim strReturnStatus As String
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
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
        UC_Maintain_ReturnMoney_OutsideBudget_Debtor1.bgyear = Request.QueryString("myear")
    End Sub

    Private Sub Frm_Maintain_ReturnMoney_Debtor_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        ' UC_Maintain_ReturnMoney_OutsideBudget_Debtor1.bindseq()
    End Sub

    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_Search.Click
        Dim str As String = UC_Maintain_ReturnMoney_Search1.getSearchMsg()
        UC_Maintain_ReturnMoney_OutsideBudget_Debtor1.rgFilter(str)
    End Sub

    Private Sub dl_MoneyReturnStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dl_MoneyReturnStatus.SelectedIndexChanged
        If IsPostBack Then
            Dim str As String

            If dl_MoneyReturnStatus.SelectedValue = 0 Then
                strReturnStatus = "([return_status] like '' )"
            Else
                strReturnStatus = "([return_status] like '%" & dl_MoneyReturnStatus.SelectedItem.Text & "%' )"
            End If

            str = strReturnStatus
            UC_Maintain_ReturnMoney_OutsideBudget_Debtor1.rgFilter(str)
        End If
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Maintain_ReturnMoney_OutsideBudget_Debtor1.rg_rebind()
    End Sub
End Class