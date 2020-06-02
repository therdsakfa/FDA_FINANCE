Public Class Frm_Department_Edit
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
            If Request.QueryString("id") <> "" Then
                Dim dao As New DAO_MAS.TB_MAS_DEPARTMENT
                dao.Getdata_by_DEPARTMENT_ID(Request.QueryString("id"))
                UC_Department_Detail1.getdata(dao)
            End If
        End If

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Request.QueryString("id") <> "" And Request.QueryString("typeid") <> "" Then
            Dim dao As New DAO_MAS.TB_MAS_DEPARTMENT
            dao.Getdata_by_DEPARTMENT_ID(Request.QueryString("id"))
            UC_Department_Detail1.update(dao)
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "แก้ไขข้อมูลหน่วยงาน " & dao.fields.DEPARTMENT_DESCRIPTION, "MAS_DEPARTMENT", Request.QueryString("id"))
            dao.update()
            'Response.Redirect("Frm_Department.aspx")
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If
    End Sub
End Class