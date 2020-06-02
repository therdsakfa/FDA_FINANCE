Public Class Frm_Department_Insert
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
        Dim dao As New DAO_MAS.TB_MAS_DEPARTMENT
        If Request.QueryString("typeid") = "1" Then
            Dim id As Integer = Request.QueryString("id")
            UC_Department_Detail1.insert_head(dao)
            dao.insert()
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลหน่วยงาน " & dao.fields.DEPARTMENT_DESCRIPTION, "MAS_DEPARTMENT", dao.fields.DEPARTMENT_ID)
            dao.fields.DEPARTMENT_CHILD_ID = dao.fields.DEPARTMENT_ID
            ' dao.update()
            Dim idinsert As Integer = dao.fields.DEPARTMENT_ID

            Dim dao2 As New DAO_MAS.TB_MAS_DEPARTMENT_NODE
            dao2.fields.HEAD_ID = id
            dao2.fields.CHILD_ID = idinsert
            dao2.insert()
        Else
            Dim id As Integer = Request.QueryString("id")
            UC_Department_Detail1.insert(dao)
            dao.insert()
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลหน่วยงาน " & dao.fields.DEPARTMENT_DESCRIPTION, "MAS_DEPARTMENT", dao.fields.DEPARTMENT_ID)
            Dim idinsert As Integer = dao.fields.DEPARTMENT_ID

            Dim dao2 As New DAO_MAS.TB_MAS_DEPARTMENT_NODE
            dao2.fields.HEAD_ID = id
            dao2.fields.CHILD_ID = idinsert
            dao2.insert()
        End If

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)


        'Response.Redirect("Frm_Department.aspx")
    End Sub
End Class