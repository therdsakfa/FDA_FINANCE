Public Class Frm_Checker_Edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("IDA") <> "" Then
            Dim dao As New DAO_MAS.TB_MAS_CHECKER
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            UC_CHECKER_DETAIL1.get_data(dao)
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If Request.QueryString("IDA") <> "" Then
            Dim dao As New DAO_MAS.TB_MAS_CHECKER
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            UC_CHECKER_DETAIL1.set_data(dao)
            dao.fields.UPDATE_DATE = Date.Now
            dao.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขเรียบร้อยกรุณารอสักครู่'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)

        End If
    End Sub
End Class