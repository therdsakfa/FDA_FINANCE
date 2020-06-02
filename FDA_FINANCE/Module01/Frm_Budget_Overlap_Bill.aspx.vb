Public Class Frm_Budget_Overlap_Bill
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
    End Sub

    Protected Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        UC_Budget_Overlap_Bill1.insert()
    End Sub

End Class