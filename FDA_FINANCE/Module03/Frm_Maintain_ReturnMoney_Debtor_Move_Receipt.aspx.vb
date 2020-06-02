Public Class Frm_Maintain_ReturnMoney_Debtor_Move_Receipt
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
            txt_Movedate.Text = System.DateTime.Now.ToShortDateString()
        End If
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        UC_Maintain_ReturnMoney_Debtor_Move1.update(txt_Movedate.Text)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย') ; ", True)
        UC_Maintain_ReturnMoney_Debtor_Move1.rg_rebind()
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim str As String = ""
        str = UC_Filter_Movedate1.get_messege()
        UC_Maintain_ReturnMoney_Debtor_Move1.rgFilter(str)
    End Sub
End Class