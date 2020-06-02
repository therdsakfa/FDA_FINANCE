Public Class Frm_Disburse_Debtor_Margin_Check_Ready
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
        Page.Title = "เช็คพร้อมจ่าย"
        set_uc()
        If Not IsPostBack Then
            rd_APPROVE_DATE.SelectedDate = Date.Now
        End If
    End Sub
    Public Sub set_uc()
        UC_Disburse_Debtor_Check_Ready1.debtor_type = 1
        UC_Disburse_Debtor_Check_Ready1.bg_use = 1
        UC_Disburse_Debtor_Check_Ready1.bgyear = Request.QueryString("myear")
        UC_Disburse_Debtor_Check_Ready1.bt = 3
        UC_Disburse_Debtor_Check_Ready1.stat = 3
        UC_Disburse_Debtor_Check_Ready1.g = 2
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_Form1.getSearchMsg_2()
        UC_Disburse_Debtor_Check_Ready1.rgFilter(str)
    End Sub
    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Debtor_Check_Ready1.rebind_grid()
    End Sub
    Private Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
        If rd_APPROVE_DATE.IsEmpty = False Then
            UC_Disburse_Debtor_Check_Ready1.update_true(rd_APPROVE_DATE.SelectedDate, _CLS.CITIZEN_ID_AUTHORIZE)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย') ;", True)
            UC_Disburse_Debtor_Check_Ready1.rebind_grid()
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกวันที่') ;", True)
        End If
    End Sub
End Class