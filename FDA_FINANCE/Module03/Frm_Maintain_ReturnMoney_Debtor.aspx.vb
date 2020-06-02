Public Class Frm_Maintain_ReturnMoney_Debtor
    Inherits System.Web.UI.Page
    Dim strMoneyType As String
    Dim strReturnStatus As String
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
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
        UC_Maintain_ReturnMoney_Debtor1.bgyear = bgYear
        If rbl_MoneyType.SelectedItem.Value = 0 Then
            strMoneyType = "([DEBTOR_TYPE_ID] like '%%' )"
        Else
            strMoneyType = "([DEBTOR_TYPE_ID] = " & rbl_MoneyType.SelectedItem.Value & " )"
        End If

    End Sub

    Private Sub Frm_Maintain_ReturnMoney_Debtor_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        'UC_Maintain_ReturnMoney_Debtor1.sort_grid()
        'UC_Maintain_ReturnMoney_Debtor1.bindseq()
        ' UC_Maintain_ReturnMoney_Debtor1.rebind_rg()
    End Sub

    Private Sub rbl_MoneyType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbl_MoneyType.SelectedIndexChanged
        If IsPostBack Then
            'Dim str As String
            'If rbl_MoneyType.SelectedItem.Value = 0 Then
            '    str = "([DEBTOR_TYPE_ID] = " & "" & " )"
            'Else
            '    str = "([DEBTOR_TYPE_ID] = " & rbl_MoneyType.SelectedItem.Value & " )"
            'End If
            Dim str As String = strMoneyType
            UC_Maintain_ReturnMoney_Debtor1.rgFilter(str)
            UC_Maintain_ReturnMoney_Debtor1.rebind_rg()
        End If
    End Sub

    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_Search.Click
        Dim str_uc As String = UC_Maintain_ReturnMoney_Search1.getSearchMsg()
        'If rbl_MoneyType.SelectedItem.Value = "0" And str_uc = "" Then
        '    Dim str As String = strMoneyType
        '    UC_Maintain_ReturnMoney_Debtor1.rgFilter(str)
        'ElseIf rbl_MoneyType.SelectedItem.Value = "0" And str_uc <> "" Then
        '    ' Dim str As String = strMoneyType
        '    UC_Maintain_ReturnMoney_Debtor1.rgFilter(str_uc)
        'ElseIf rbl_MoneyType.SelectedItem.Value <> "0" And str_uc = "" Then
        '    Dim str As String
        '    str = "([DEBTOR_TYPE_ID] = " & rbl_MoneyType.SelectedItem.Value & " )"
        '    UC_Maintain_ReturnMoney_Debtor1.rgFilter(str)
        'ElseIf rbl_MoneyType.SelectedItem.Value <> "0" And str_uc <> "" Then
        '    Dim str As String
        '    str = "([DEBTOR_TYPE_ID] = " & rbl_MoneyType.SelectedItem.Value & " ) and " & str_uc
        '    UC_Maintain_ReturnMoney_Debtor1.rgFilter(str)
        'End If
        UC_Maintain_ReturnMoney_Debtor1.rgFilter(str_uc)
    End Sub

    Private Sub dl_MoneyReturnStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dl_MoneyReturnStatus.SelectedIndexChanged

        Dim str As String = "([return_status] like '%" & dl_MoneyReturnStatus.SelectedValue & "%')"
        UC_Maintain_ReturnMoney_Debtor1.rgFilter(str)

        'If dl_MoneyReturnStatus.SelectedValue = 0 Then
        '    strReturnStatus = "([return_status] like '' )"
        'Else
        '    strReturnStatus = "([return_status] like '%" & dl_MoneyReturnStatus.SelectedItem.Text & "%' )"
        'End If

        'strMoneyType += " and " & strReturnStatus


        'If rbl_MoneyType.SelectedItem.Value = "0" And dl_MoneyReturnStatus.SelectedValue = 0 Then
        '    strReturnStatus = "([return_status] like '%%' )"
        'ElseIf rbl_MoneyType.SelectedItem.Value = "0" And dl_MoneyReturnStatus.SelectedValue <> 0 Then
        '    strReturnStatus = "([return_status] like '%" & dl_MoneyReturnStatus.SelectedItem.Text & "%' )"
        'ElseIf rbl_MoneyType.SelectedItem.Value <> "0" And dl_MoneyReturnStatus.SelectedValue <> 0 Then
        '    strReturnStatus = strMoneyType & " and ([return_status] like '%" & dl_MoneyReturnStatus.SelectedItem.Text & "%' )"
        'End If
        'UC_Maintain_ReturnMoney_Debtor1.rgFilter(strReturnStatus)


    End Sub


    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Maintain_ReturnMoney_Debtor1.rebind_rg()
    End Sub
End Class