Public Class Frm_Person_In_Report_Insert
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        'Try
        '    _CLS = Session("CLS")
        'Catch ex As Exception
        '    Response.Redirect("http://privus.fda.moph.go.th/")
        'End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            UC_Person_In_Report_Detail1.bind_ddl()
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_MAS.TB_TBL_PERSON_IN_REPORT
        UC_Person_In_Report_Detail1.insert(dao)
        dao.insert()
        'Dim log As New log_event.log
        'log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
        '               Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลประเภทค่าใช้จ่าย " & dao_paylist_insert.fields.PAYLIST_DESCRIPTION, "MAS_PAYLIST", dao_paylist_insert.fields.PATLIST_ID)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
End Class