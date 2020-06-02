Public Class Frm_Salary_Personal_Insert
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
            UC_Salary_Person_Detail1.bind_ddl_person(Request.QueryString("t"))
        End If
    End Sub

    Private Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        Dim dao As New DAO_SALARY.TB_SALARY
        UC_Salary_Person_Detail1.setdata(dao)
        dao.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อยแล้ว');parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub

End Class