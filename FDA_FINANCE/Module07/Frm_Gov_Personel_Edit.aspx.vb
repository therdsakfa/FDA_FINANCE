Public Class Frm_Gov_Personel_Edit
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
            If Request.QueryString("uid") IsNot Nothing Then
                Dim dao As New DAO_MAS.TB_Personal
                dao.Getdata_by_ID(Request.QueryString("uid"))
                UC_Gov_Personel_Detail1.bind_ddl_dept()
                UC_Gov_Personel_Detail1.bind_ddl_level()
                UC_Gov_Personel_Detail1.bind_ddl_Position()
                UC_Gov_Personel_Detail1.bind_ddl_prefix()
                UC_Gov_Personel_Detail1.bind_dd_bank()
                UC_Gov_Personel_Detail1.getdata(dao)
            End If
        End If
    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If Request.QueryString("uid") IsNot Nothing Then
            Dim dao As New DAO_MAS.TB_Personal
            dao.Getdata_by_ID(Request.QueryString("uid"))
            UC_Gov_Personel_Detail1.insert(dao)
            dao.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขข้อมูลเรียบร้อย'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If
    End Sub
End Class