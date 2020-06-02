Public Class Frm_Maintain_ReturnMoney_Debtor_OutsideBudget_Insert_Detail
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
        UC_Maintain_ReturnMoney_Detail.is_outside = True
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        Dim maintype As Integer = Request.QueryString("maintype")
        Dim dao_maintain_return_money_deptor As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
        Dim id As Integer = 0
        UC_Maintain_ReturnMoney_Detail.insert(dao_maintain_return_money_deptor)
        dao_maintain_return_money_deptor.fields.PAY_TYPE = maintype

        dao_maintain_return_money_deptor.insert()
        id = dao_maintain_return_money_deptor.fields.RETURN_MONEY_DEBTOR_ID
        UC_Maintain_ReturnMoney_Detail.insert_bill(id)
        Dim log As New log_event.log
        log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                       Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลการคืนเงินลูกหนี้เงินยืม(เงินนอก)", _
                       "RETURN_MONEY_DEBTOR", id)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
End Class