Public Class Frm_Disburse_Relate_Insert
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
        If Not IsPostBack Then
            UC_RELATE_BILL_DETAIL1.bind_dd_cus()
        End If
    End Sub
    Private Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        Dim dao_head As New DAO_DISBURSE.TB_RELATE_BG_ALL
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim re_number As String = ""
        re_number = bao.get_relate_receive_number_max(Request.QueryString("bgYear"))
        UC_RELATE_BILL_DETAIL1.set_data(dao_head)
        dao_head.fields.BUDGET_YEAR = Request.QueryString("bgYear")
        dao_head.fields.BUDGET_USE_ID = 1
        dao_head.fields.RECEIVE_NUMBER = CDbl(re_number) + 1
        dao_head.fields.IS_RECEIVE = True
        dao_head.fields.DEPARTMENT_ID = Request.QueryString("dept")
        Try
            dao_head.fields.RECEIVE_DATE = Date.Now()
        Catch ex As Exception

        End Try
        Try
            dao_head.fields.AD_SAVE = NameUserAD()
        Catch ex As Exception

        End Try
        dao_head.fields.SAVE_DATE = Date.Now
        dao_head.fields.RECEIVE_FULL_NUMBER = CDbl(re_number) + 1 & "/" & Request.QueryString("bgYear")
        dao_head.insert()
        'get_relate_receive_number_max
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อยแล้ว คุณได้เลขรับหมายเลข " & CDbl(re_number) + 1 & "/" & Request.QueryString("bgYear") & "'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub

    Private Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        UC_RELATE_BILL_DETAIL1.set_panel_confirm()
        btn_cancel.Style.Add("display", "block")
        btn_confirm.Style.Add("display", "none")
        btn_bill_save.Style.Add("display", "block")
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        UC_RELATE_BILL_DETAIL1.set_panel_cancel()
        btn_cancel.Style.Add("display", "none")
        btn_confirm.Style.Add("display", "block")
        btn_bill_save.Style.Add("display", "none")
    End Sub
End Class