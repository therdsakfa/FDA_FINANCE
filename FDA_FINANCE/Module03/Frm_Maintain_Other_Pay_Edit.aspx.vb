Public Class Frm_Maintain_Other_Pay_Edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim dao As New DAO_MAINTAIN.TB_OTHER_PAY
            dao.Getdata_by_ID(Request.QueryString("id"))
            UC_Maintain_Other_Pay_Detail1.getdata(dao)
        End If
    End Sub

    Private Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        If Request.QueryString("id") IsNot Nothing Then
            Dim dao As New DAO_MAINTAIN.TB_OTHER_PAY
            dao.Getdata_by_ID(Request.QueryString("id"))
            UC_Maintain_Other_Pay_Detail1.update(dao)
            dao.update()
           
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขข้อมูลเรียบร้อย') ; parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If
    End Sub
End Class