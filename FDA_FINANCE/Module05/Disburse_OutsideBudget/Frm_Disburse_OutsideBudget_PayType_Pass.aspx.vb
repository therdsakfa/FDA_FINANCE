Public Class Frm_Disburse_OutsideBudget_PayType_Pass
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
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
        UC_Disburse_Budget_PayType_Pass1.PAY_TYPE_ID = 2
        UC_Disburse_Budget_PayType_Pass1.bg_use = 3
        UC_Disburse_Budget_PayType_Pass1.bgyear = Request.QueryString("myear")
        UC_Disburse_Budget_PayType_Pass1.rg_remove_column()
        UC_Disburse_Budget_PayType_Pass1.ispo = "False"
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_Form_Check1.getSearchMsg_2()
        UC_Disburse_Budget_PayType_Pass1.rgFilter(str)

    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Disburse_Budget_PayType_Pass1.bindseq()
    End Sub

    Private Sub dd_status_TextChanged(sender As Object, e As EventArgs) Handles dd_status.TextChanged
        'UC_Disburse_Budget_PayType_Pass1.rg_rebind()
        'Dim str As String = UC_Search_Form1.getSearchMsg()
        'str = str & " and [digit] like '%" & dd_status.SelectedValue & "%'"
        'UC_Disburse_Budget_PayType_Pass1.rgFilter(str)

        Dim str As String = UC_Search_Form_Check1.getSearchMsg()
        If str <> "" Then
            str = str & " and ([digit] like '%" & dd_status.SelectedValue.ToString & "%')"
            UC_Disburse_Budget_PayType_Pass1.rgFilter(str)
        Else
            str = " ([digit] like '%" & dd_status.SelectedValue.ToString & "%')"
            UC_Disburse_Budget_PayType_Pass1.rgFilter(str)
        End If
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Budget_PayType_Pass1.rg_rebind()
    End Sub
    Private Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        UC_Disburse_Budget_PayType_Pass1.rgFilter("([digit] like '%รอบันทึกเลขที่เช็ค%')")
    End Sub

    Private Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click
        UC_Disburse_Budget_PayType_Pass1.rgFilter("([digit] like '%รอการรับเช็ค%')")
    End Sub

    Private Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
        UC_Disburse_Budget_PayType_Pass1.rgFilter("([digit] like '%รอบันทึกบก. อนุมัติ%')")
    End Sub

    Private Sub ImageButton4_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton4.Click
        UC_Disburse_Budget_PayType_Pass1.rgFilter("([digit] like '%รออนุมัติพร้อมจ่าย%')")
    End Sub

    Private Sub ImageButton5_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton5.Click
        UC_Disburse_Budget_PayType_Pass1.rgFilter("([digit] like '%รอบันทึกการจ่าย%')")
    End Sub

    Private Sub ImageButton6_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton6.Click
        UC_Disburse_Budget_PayType_Pass1.rgFilter("([digit] like '%บันทึกข้อมูลครบถ้วน%')")
    End Sub
End Class