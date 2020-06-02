Public Class Frm_Maintain_ReturnMoney_Debtor_Edit_Detail
    Inherits System.Web.UI.Page
    Public id As String
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
            If Request.QueryString("id") <> "" Then
                id = Request.QueryString("id")
                UC_Maintain_ReturnMoney_Detail.bind_r_type()
                UC_Maintain_ReturnMoney_Detail.set_dropdown_edit(id)
                UC_Maintain_ReturnMoney_Detail.bindcontrol()
                Dim dao As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
                dao.Getdata_by_RETURN_MONEY_DEBTOR_ID(id)
                UC_Maintain_ReturnMoney_Detail.getdata_debtor(dao)

            End If
        End If
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        id = Request.QueryString("id")
        Dim maintype As Integer = Request.QueryString("maintype")
        Dim dao_maintain_return_money_deptor As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
        dao_maintain_return_money_deptor.Getdata_by_RETURN_MONEY_DEBTOR_ID(id)
        UC_Maintain_ReturnMoney_Detail.update(dao_maintain_return_money_deptor)
        'dao_maintain_return_money_deptor.fields.PAY_TYPE = maintype

        dao_maintain_return_money_deptor.update()
        Dim log As New log_event.log
        log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                       Request.Url.AbsoluteUri.ToString(), "แก้ไขข้อมูลการคืนเงินลูกหนี้เงินยืม", _
                       "RETURN_MONEY_DEBTOR", Request.QueryString("maintype"))
        'UC_Maintain_ReturnMoney_Detail.insert_bill()

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
End Class