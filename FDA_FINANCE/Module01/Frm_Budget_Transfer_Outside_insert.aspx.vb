Public Class Frm_Budget_Transfer_Outside_insert
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
            UC_Budget_Transfer_Out_Detail1.set_date()
            UC_Budget_Transfer_Out_Detail1.bind_dl_department()
            UC_Budget_Transfer_Out_Detail1.bind_dl_bg()
            UC_Budget_Transfer_Out_Detail1.set_hide_unhide1()
            UC_Budget_Transfer_Out_Detail1.bind_sub_bg1_insert()
            UC_Budget_Transfer_Out_Detail1.bind_dl_out_dept()
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_BUDGET.TB_BUDGET_TRANSFER
        UC_Budget_Transfer_Out_Detail1.insert(dao)
        dao.insert()
        Dim log As New log_event.log
        log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                       Request.Url.AbsoluteUri.ToString(), "บันทึกโอนภายให้หน่วยงานภายนอกเลขหนังสือ " & _
                       dao.fields.BUDGET_TRANSFER_DOC_NUMBER, "BUDGET_TRANSFER", dao.fields.BUDGET_TRANSFER_ID)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อยแล้ว') ;parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
End Class