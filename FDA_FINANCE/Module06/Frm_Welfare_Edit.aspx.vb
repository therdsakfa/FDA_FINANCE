Public Partial Class Frm_Welfare_Edit
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
            Dim dao_welfare_edit As New DAO_MAS.TB_MAS_WELFARE
            Dim txt_WELFARE_TYPE_CODE As TextBox = UC_Welfare_Details1.FindControl("txt_WELFARE_TYPE_CODE")
            Dim txt_WELFARE_TYPE_DESCRIPTION As TextBox = UC_Welfare_Details1.FindControl("txt_WELFARE_TYPE_DESCRIPTION")
            Dim txt_WELFARE_TYPE_SHORT_DESCRIPTION As TextBox = UC_Welfare_Details1.FindControl("txt_WELFARE_TYPE_SHORT_DESCRIPTION")
            dao_welfare_edit.Getdata_by_WELFARE_ID(Request.QueryString("wid"))
            txt_WELFARE_TYPE_CODE.Text = dao_welfare_edit.fields.WELFARE_TYPE_CODE
            txt_WELFARE_TYPE_DESCRIPTION.Text = dao_welfare_edit.fields.WELFARE_TYPE_DESCRIPTION
            txt_WELFARE_TYPE_SHORT_DESCRIPTION.Text = dao_welfare_edit.fields.WELFARE_TYPE_SHORT_DESCRIPTION
        End If
    End Sub

    Private Sub btn_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        Dim qstr_wid As Integer
        Dim dao_welfare_edit As New DAO_MAS.TB_MAS_WELFARE
        Dim txt_WELFARE_TYPE_CODE As TextBox = UC_Welfare_Details1.FindControl("txt_WELFARE_TYPE_CODE")
        Dim txt_WELFARE_TYPE_DESCRIPTION As TextBox = UC_Welfare_Details1.FindControl("txt_WELFARE_TYPE_DESCRIPTION")
        Dim txt_WELFARE_TYPE_SHORT_DESCRIPTION As TextBox = UC_Welfare_Details1.FindControl("txt_WELFARE_TYPE_SHORT_DESCRIPTION")

        If Request.QueryString("wid") IsNot Nothing Then
            qstr_wid = Request.QueryString("wid").ToString()
            dao_welfare_edit.Getdata_by_WELFARE_ID(qstr_wid)
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "แก้ไขมูลประเภทสวัสดิการ " & dao_welfare_edit.fields.WELFARE_TYPE_DESCRIPTION, "MAS_WELFARE", Request.QueryString("wid"))
            dao_welfare_edit.fields.WELFARE_TYPE_CODE = txt_WELFARE_TYPE_CODE.Text
            dao_welfare_edit.fields.WELFARE_TYPE_DESCRIPTION = txt_WELFARE_TYPE_DESCRIPTION.Text
            dao_welfare_edit.fields.WELFARE_TYPE_SHORT_DESCRIPTION = txt_WELFARE_TYPE_SHORT_DESCRIPTION.Text
            dao_welfare_edit.update()
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('แก้ไขข้อมูลเรียบร้อยแล้ว');window.location.href = 'Frm_Welfare.aspx';", True)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)

        End If
    End Sub
End Class