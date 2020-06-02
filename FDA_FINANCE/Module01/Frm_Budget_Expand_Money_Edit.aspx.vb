Public Class Frm_Budget_Expand_Money_Edit
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
            If Request.QueryString("oid") <> "" Then
                Dim dao As New DAO_MAS.TB_OVERLAP_HEAD
                dao.Getdata_by_OVERLAP_HEAD_ID(Request.QueryString("oid"))
                UC_Budget_Expand_Money_Detail1.getdata(dao)
            End If
        End If

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Request.QueryString("oid") <> "" Then
            Dim dao As New DAO_MAS.TB_OVERLAP_HEAD
            dao.Getdata_by_OVERLAP_HEAD_ID(Request.QueryString("oid"))
            UC_Budget_Expand_Money_Detail1.insert(dao)
            dao.update()
        End If
    End Sub
End Class