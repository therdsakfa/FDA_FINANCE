Public Class Frm_Checker_Insert
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_MAS.TB_MAS_CHECKER
        UC_CHECKER_DETAIL1.set_data(dao)
        dao.fields.CREATE_DATE = Date.Now
        dao.fields.IS_ENABLE = True
        dao.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อยกรุณารอสักครู่'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)

    End Sub
End Class