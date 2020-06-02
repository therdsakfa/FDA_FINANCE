Public Class Frm_Disburse_Cure_Study_Status_Add
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
            If Request.QueryString("bid") IsNot Nothing Then
                Dim dao As New DAO_DISBURSE.TB_CURE_STUDY
                dao.Getdata_by_CURE_STUDY_ID(Request.QueryString("bid"))
                UC_Disburse_Cure_Study_Status_Add1.getdata(dao)

            End If
        End If
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DISBURSE.TB_CURE_STUDY()
        dao.Getdata_by_CURE_STUDY_ID(Request.QueryString("bid"))
        UC_Disburse_Cure_Study_Status_Add1.insert(dao)
        dao.update()
        Dim log As New log_event.log
        log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                       Request.Url.AbsoluteUri.ToString(), "บันทึกสถานะใบเบิกจ่ายค่ารักษา/ค่าเล่าเรียนเลขที่หนังสือ " & dao.fields.DOC_NUMBER, "CURE_STUDY", Request.QueryString("bid"))
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
End Class