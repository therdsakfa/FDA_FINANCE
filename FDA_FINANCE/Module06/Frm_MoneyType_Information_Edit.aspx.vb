Public Class Frm_MoneyType_Information_Edit
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
            Dim id As String = Request.QueryString("id")
            Dim dao As New DAO_MAS.TB_MAS_MONEY_TYPE
            dao.Getdata_by_MONEY_TYPE_ID(id)
            UC_MoneyType_Information_Detail1.getdata(dao)

        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_MAS.TB_MAS_MONEY_TYPE
        Dim id As String = Request.QueryString("id")
        dao.Getdata_by_MONEY_TYPE_ID(id)
        UC_MoneyType_Information_Detail1.insert(dao)
        dao.update()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
End Class