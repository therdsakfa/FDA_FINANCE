Public Partial Class Frm_Bank_Insert1
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
        Dim dao_insert_bank As New DAO_MAS.TB_MAS_BANK
        UC_Bank_Insert1.insert(dao_insert_bank)


        If UC_Bank_Insert1.Validataion = True Then
            dao_insert_bank.insert()
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลธนาคารชื่อ " & dao_insert_bank.fields.BANK_NAME, "MAS_BANK", dao_insert_bank.fields.BANK_ID)
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เพิ่มข้อมูลเรียบร้อยแล้ว');window.location.href = 'Frm_Bank.aspx';", True)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อยกรุณารอสักครู่'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        Else

        End If
       
    End Sub
End Class