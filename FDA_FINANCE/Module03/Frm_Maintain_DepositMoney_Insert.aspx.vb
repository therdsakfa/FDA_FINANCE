Public Class Frm_Maintain_DepositMoney_Insert
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
            Dim dao_maintain_deposit_money As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao_maintain_deposit_money.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("DEPOSIT_MONEY_ID"))
            UC_Maintain_DepositMoney_Detail.getdata(dao_maintain_deposit_money)
        End If
    End Sub

    Protected Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        Dim dao_maintain_deposit_money As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL
        UC_Maintain_DepositMoney_Detail.insert(dao_maintain_deposit_money)
        dao_maintain_deposit_money.insert()
        Dim log As New log_event.log
        log.insert_log("", System.IO.Path.GetFileName(Request.Path), _
                       Request.Url.AbsoluteUri.ToString(), "แก้ไขข้อมูลการฝากเงิน/ส่งคลัง", _
                       "RECEIVE_MONEY_DETAIL", dao_maintain_deposit_money.fields.RECEIVE_MONEY_DETAIL_ID)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        'Response.Redirect("Frm_Maintain_DepositMoney.aspx")
    End Sub

    'Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    '    ' Response.Redirect("Frm_Maintain_DepositMoney.aspx")
    'End Sub
End Class