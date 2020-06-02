Public Class Frm_Maintain_DepositMoney_Debtor_Edit
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
            Dim dao_maintain_deposit_money As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
            Dim dao_maintain_deposit_money_detail As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR_DEPOSIT
            dao_maintain_deposit_money.Getdata_by_RETURN_MONEY_DEBTOR_ID(Request.QueryString("DEPOSIT_MONEY_ID"))
            dao_maintain_deposit_money_detail.Getdata_by_RETURN_MONEY_DEBTOR_ID(Request.QueryString("DEPOSIT_MONEY_ID"))
            UC_Maintain_DepositMoney_Debtor_Detail1.getdata(dao_maintain_deposit_money)
            UC_Maintain_DepositMoney_Debtor_Detail1.getdataDetail(dao_maintain_deposit_money_detail)
        End If
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        Dim qstr_DEPOSIT_MONEY_ID As Integer
        Dim dao_deposit_money As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR_DEPOSIT
        If Request.QueryString("DEPOSIT_MONEY_ID") IsNot Nothing Then
            qstr_DEPOSIT_MONEY_ID = Request.QueryString("DEPOSIT_MONEY_ID").ToString()
            dao_deposit_money.Getdata_by_RETURN_MONEY_DEBTOR_ID(qstr_DEPOSIT_MONEY_ID)
            UC_Maintain_DepositMoney_Debtor_Detail1.insert(dao_deposit_money)
            dao_deposit_money.update()
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('แก้ไขข้อมูลเรียบร้อยแล้ว');window.location.href = 'Frm_Maintain_Receive_Money.aspx';", True)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If
    End Sub
End Class