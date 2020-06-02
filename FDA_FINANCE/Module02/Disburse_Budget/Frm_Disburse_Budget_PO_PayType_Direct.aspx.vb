Public Class Frm_Disburse_Budget_PO_PayType_Direct
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
        UC_Disburse_Budget_PayType_Direct1.ispo = "True"
        UC_Disburse_Budget_PayType_Direct1.PAY_TYPE_ID = 1
        UC_Disburse_Budget_PayType_Direct1.bg_use = 1
        UC_Disburse_Budget_PayType_Direct1.bgyear = Master.get_Year
    End Sub
    Private Sub dd_status_TextChanged(sender As Object, e As EventArgs) Handles dd_status.TextChanged
        Dim str As String = ""
        str = " ([digit] like '%" & dd_status.SelectedValue.ToString & "%')"
        UC_Disburse_Budget_PayType_Direct1.rgFilter(str)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'UC_Disburse_Budget_PayType_Direct1.rg_rebind()
        ' If Not IsPostBack Then
        Dim str As String
        str = UC_Search_Form1.getSearchMsg_2()
        'str = " ([DOC_DATE] ='13/12/2556')"

        'str = str & "and ([digit] = '" & dd_status.SelectedValue.ToString & "')"
        UC_Disburse_Budget_PayType_Direct1.rgFilter(str)
        ' End If

    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Disburse_Budget_PayType_Direct1.bindseq()
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Budget_PayType_Direct1.rg_rebind()
    End Sub
    Private Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        UC_Disburse_Budget_PayType_Direct1.rgFilter("([digit] like '%รอบันทึกเลขปลดจ่าย%')")
    End Sub

    Private Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click
        UC_Disburse_Budget_PayType_Direct1.rgFilter("([digit] like '%รอบันทึกใบแจ้งหนี้%')")
    End Sub

    Private Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
        UC_Disburse_Budget_PayType_Direct1.rgFilter("([digit] like '%รอบันทึกใบกำกับภาษี%')")
    End Sub

    Private Sub ImageButton4_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton4.Click
        UC_Disburse_Budget_PayType_Direct1.rgFilter("([digit] like '%รอบันทึกเลขที่ใบเสร็จ%')")
    End Sub

    Private Sub ImageButton5_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton5.Click
        UC_Disburse_Budget_PayType_Direct1.rgFilter("([digit] like '%บันทึกข้อมูลครบถ้วน%')")
    End Sub
End Class