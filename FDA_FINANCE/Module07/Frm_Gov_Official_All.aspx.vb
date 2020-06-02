Public Class Frm_Gov_Official_All
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
        UC_User_Debtor1.is_salary = True
        UC_User_Debtor1.per_type = 1
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim str As String
        str = UC_Search_User_Debtor1.getSearchMsg()
        UC_User_Debtor1.rgFilter(str)
        '  UC_User_Debtor1.str = str
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_User_Debtor1.rg_rebind()
    End Sub

    Private Sub btn_export_Click(sender As Object, e As EventArgs) Handles btn_export.Click
        UC_User_Debtor1.export()
    End Sub
End Class