Public Class Frm_Disburse_Study_KNumber_Add
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

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Request.QueryString("bid") IsNot Nothing Then
            Dim id As String = "0"
            id = Request.QueryString("bid")
            Dim dao As New DAO_DISBURSE.TB_CURE_STUDY
            dao.Getdata_by_CURE_STUDY_ID(id)
            UC_Disburse_Study_GF_Detail1.insert(dao)
            dao.fields.STATUS_ID = Request.QueryString("stat")
            dao.fields.GROUP_ID = Request.QueryString("g")
            dao.update()


            Dim dao2 As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            dao2.fields.STATUS_ID = Request.QueryString("stat")
            dao2.fields.REASON_DATE = Date.Now
            dao2.fields.IDENTITY_NUMBER = _CLS.CITIZEN_ID_AUTHORIZE
            dao2.fields.DATE_ADD = Date.Now
            dao2.fields.FK_IDA = Request.QueryString("bid")
            dao2.fields.GROUP_ID = Request.QueryString("g")
            dao2.fields.BILL_TYPE = Request.QueryString("bt")
            dao2.insert()
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "บันทึกขบ.ใบเบิกจ่ายค่าเล่าเรียนบุตรเลขที่หนังสือ " & _
                           dao.fields.DOC_NUMBER, "CURE_STUDY", id)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If
    End Sub
End Class