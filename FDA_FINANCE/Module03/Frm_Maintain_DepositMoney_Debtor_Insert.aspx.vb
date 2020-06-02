Public Class Frm_Maintain_DepositMoney_Debtor_Insert
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
            dao_maintain_deposit_money.Getdata_by_RETURN_MONEY_DEBTOR_ID(Request.QueryString("DEPOSIT_MONEY_ID"))
            UC_Maintain_DepositMoney_Debtor_Detail1.set_date()
            UC_Maintain_DepositMoney_Debtor_Detail1.getdata(dao_maintain_deposit_money)

        End If
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        If Request.QueryString("DEPOSIT_MONEY_ID") IsNot Nothing Then
            Dim dao_chk_repeat As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR_DEPOSIT
            Dim dg_count As Integer = 0
            dg_count = dao_chk_repeat.chk_repeat(Request.QueryString("DEPOSIT_MONEY_ID"))
            If dg_count = 0 Then
                Dim dao_maintain_deposit_money As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR_DEPOSIT
                UC_Maintain_DepositMoney_Debtor_Detail1.insert(dao_maintain_deposit_money)
                dao_maintain_deposit_money.insert()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อยแล้ว'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลซ้ำ');", True)
            End If

        End If
       
    End Sub
End Class