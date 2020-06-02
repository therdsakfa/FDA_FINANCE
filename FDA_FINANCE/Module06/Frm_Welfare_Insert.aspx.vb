Public Partial Class Frm_Welfare_Insert
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
    End Sub

    Private Sub btn_save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim dao_welfare_insert As New DAO_MAS.TB_MAS_WELFARE
        Dim txt_WELFARE_TYPE_CODE As TextBox = UC_Welfare_Details1.FindControl("txt_WELFARE_TYPE_CODE")
        Dim txt_WELFARE_TYPE_DESCRIPTION As TextBox = UC_Welfare_Details1.FindControl("txt_WELFARE_TYPE_DESCRIPTION")
        Dim txt_WELFARE_TYPE_SHORT_DESCRIPTION As TextBox = UC_Welfare_Details1.FindControl("txt_WELFARE_TYPE_SHORT_DESCRIPTION")

        dao_welfare_insert.fields.WELFARE_TYPE_CODE = txt_WELFARE_TYPE_CODE.Text
        dao_welfare_insert.fields.WELFARE_TYPE_DESCRIPTION = txt_WELFARE_TYPE_DESCRIPTION.Text
        dao_welfare_insert.fields.WELFARE_TYPE_SHORT_DESCRIPTION = txt_WELFARE_TYPE_SHORT_DESCRIPTION.Text
        dao_welfare_insert.insert()
        ' System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เพิ่มข้อมูลเรียบร้อยแล้ว');window.location.href = 'Frm_Welfare.aspx';", True)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
End Class