Public Partial Class Frm_Bank_Edit
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
            Dim dao_bank_get_edit As New DAO_MAS.TB_MAS_BANK
            'Dim txt As TextBox = UC_Bank_Insert1.FindControl("txtBank_Name")
            dao_bank_get_edit.Getdata_by_BANK_ID(Request.QueryString("bank_id"))
            UC_Bank_Insert1.getdata(dao_bank_get_edit)
        End If

    End Sub

    Private Sub btn_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        Dim qstr_BANK_ID As Integer
        Dim dao_bank As New DAO_MAS.TB_MAS_BANK
        'Dim txt_Bank_Name As TextBox = UC_Bank_Insert1.FindControl("txtBank_Name")
        If Request.QueryString("bank_id") IsNot Nothing Then
            qstr_BANK_ID = Request.QueryString("bank_id").ToString()
            dao_bank.Getdata_by_BANK_ID(qstr_BANK_ID)
            Dim old_data As String = dao_bank.fields.BANK_NAME
            Dim new_data As String = ""
            If UC_Bank_Insert1.Validataion = True Then
                UC_Bank_Insert1.insert(dao_bank)
                dao_bank.update()
                new_data = dao_bank.fields.BANK_NAME
                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), Request.Url.AbsoluteUri.ToString(), "แก้ไขข้อมูลธนาคารจากชื่อ " & old_data & " เป็น " & new_data, "MAS_BANK", qstr_BANK_ID)
                ' System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('แก้ไขข้อมูลเรียบร้อยแล้ว');window.location.href = 'Frm_Bank.aspx';", True)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขเรียบร้อยกรุณารอสักครู่'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
            End If

        End If

    End Sub
End Class