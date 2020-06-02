Public Class Frm_Return_Description_Edit
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
        RunSession()
        If Not IsPostBack Then
            If Request.QueryString("id") IsNot Nothing Then
                Dim id As Integer = Request.QueryString("id")
                Dim dao As New DAO_MAS.TB_MAS_RETURN_DESCRIPTION
                dao.Getdata_by_ID(id)
                UC_Return_Description_Detail1.getdata(dao)

            End If
        End If
    End Sub

    Protected Sub btn_Edit_Click(sender As Object, e As EventArgs) Handles btn_Edit.Click
        If Request.QueryString("id") IsNot Nothing Then
            Dim id As Integer = Request.QueryString("id")
            Dim dao As New DAO_MAS.TB_MAS_RETURN_DESCRIPTION
            dao.Getdata_by_ID(id)
            UC_Return_Description_Detail1.insert(dao)
            dao.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If
    End Sub
End Class