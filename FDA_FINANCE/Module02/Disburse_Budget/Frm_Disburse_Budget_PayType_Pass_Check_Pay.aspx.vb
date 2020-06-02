Public Class Frm_Disburse_Budget_PayType_Pass_Check_Pay
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
        UC_Disburse_Budget_PayType_Pass_Check_Pay1.ispo = False
        UC_Disburse_Budget_PayType_Pass_Check_Pay1.PAY_TYPE_ID = 2
        UC_Disburse_Budget_PayType_Pass_Check_Pay1.bg_use = 1
        UC_Disburse_Budget_PayType_Pass_Check_Pay1.bgyear = Request.QueryString("myear")
        UC_Disburse_Budget_PayType_Pass_Check_Pay1.bt = 2
        UC_Disburse_Budget_PayType_Pass_Check_Pay1.stat = 4
        UC_Disburse_Budget_PayType_Pass_Check_Pay1.g = 2
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_Form1.getSearchMsg_2()
        UC_Disburse_Budget_PayType_Pass_Check_Pay1.rgFilter(str)
    End Sub
    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Budget_PayType_Pass_Check_Pay1.rebind_grid()
    End Sub
    Private Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
        If rd_APPROVE_DATE.IsEmpty = False Then
            UC_Disburse_Budget_PayType_Pass_Check_Pay1.update_true(rd_APPROVE_DATE.SelectedDate, _CLS.CITIZEN_ID_AUTHORIZE)
            UC_Disburse_Budget_PayType_Pass_Check_Pay1.rebind_grid()
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกวันที่') ;", True)
        End If
    End Sub
End Class