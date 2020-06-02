Public Class Frm_Maintain_ReturnMoney_Debtor_Deposit_Cash
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UC_Maintain_ReturnMoney_Debtor_Deposit_Cash1.bgyear = Master.get_Year()
        If Not IsPostBack Then
            txt_Movedate.Text = System.DateTime.Now.ToShortDateString()
        End If
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        UC_Maintain_ReturnMoney_Debtor_Deposit_Cash1.update(txt_Movedate.Text)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย') ; ", True)
        UC_Maintain_ReturnMoney_Debtor_Deposit_Cash1.rg_rebind()
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim str As String = ""
        str = UC_Filter_Movedate1.get_messege()
        UC_Maintain_ReturnMoney_Debtor_Deposit_Cash1.rgFilter(str)
    End Sub
End Class