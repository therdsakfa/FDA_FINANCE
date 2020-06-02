Public Class Frm_Maintain_DepositMoney_Edit
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
            Dim dao_maintain_deposit_money_detail As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL
            dao_maintain_deposit_money.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("DEPOSIT_MONEY_ID"))
            dao_maintain_deposit_money_detail.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("DEPOSIT_MONEY_ID"))
            UC_Maintain_DepositMoney_Detail.getdata(dao_maintain_deposit_money)
            UC_Maintain_DepositMoney_Detail.getdataDetail(dao_maintain_deposit_money_detail)
        End If
    End Sub

    Protected Sub btn_Edit_Click(sender As Object, e As EventArgs) Handles btn_Edit.Click
        Dim qstr_DEPOSIT_MONEY_ID As Integer
        Dim dao_deposit_money As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL
        If Request.QueryString("DEPOSIT_MONEY_ID") IsNot Nothing Then
            qstr_DEPOSIT_MONEY_ID = Request.QueryString("DEPOSIT_MONEY_ID").ToString()
            dao_deposit_money.Getdata_by_RECEIVE_MONEY_ID(qstr_DEPOSIT_MONEY_ID)
            UC_Maintain_DepositMoney_Detail.insert(dao_deposit_money)
            dao_deposit_money.update()
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "แก้ไขข้อมูลการฝากเงิน/ส่งคลัง", _
                           "RECEIVE_MONEY_DETAIL", dao_deposit_money.fields.RECEIVE_MONEY_DETAIL_ID)
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('แก้ไขข้อมูลเรียบร้อยแล้ว');window.location.href = 'Frm_Maintain_Receive_Money.aspx';", True)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If
        ' Response.Redirect("Frm_Maintain_DepositMoney.aspx")
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Response.Redirect("Frm_Maintain_DepositMoney.aspx")
    End Sub
End Class