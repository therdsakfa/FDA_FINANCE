Public Class Frm_Salary_List_Edit
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
            Try
                UC_Salary_List_Detail1.bind_ddl_paylist()
                Dim dao As New DAO_SALARY.TB_SALARY_DETAIL
                dao.Getdata_by_ID(Request.QueryString("id"))
                UC_Salary_List_Detail1.getdata(dao)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        Dim dao As New DAO_SALARY.TB_SALARY_DETAIL
        dao.Getdata_by_ID(Request.QueryString("id"))
        UC_Salary_List_Detail1.editdata(dao)
        dao.update()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขเรียบร้อยแล้ว');parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)

    End Sub
End Class