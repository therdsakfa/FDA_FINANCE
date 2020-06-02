Public Class Frm_Disburse_OutsideDebtor_Add_Status_Pass
    Inherits System.Web.UI.Page
    Public bgYear As Integer
    Private _dept As Integer
    Private _bgid As Integer
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Sub runQuery()
        _dept = Request.QueryString("dept")
        _bgid = Request.QueryString("bgid")
        bgYear = Request.QueryString("myear")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()
        UC_Disburse_OutsideDebtor_Add_Status1.bg_use = 3
        UC_Disburse_OutsideDebtor_Add_Status1.debtor_type = 2
        UC_Disburse_OutsideDebtor_Add_Status1.bgyear = bgYear
    End Sub


    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_OutsideDebtor_Add_Status1.rg_rebind()
    End Sub
End Class