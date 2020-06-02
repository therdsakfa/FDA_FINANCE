Public Class FRM_PROJECT_SELECT_HRD
    Inherits System.Web.UI.Page
    Private _dept As String
    Private _bgyear As Integer
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _ProId As String = ""

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Sub runQuery()
        _dept = Request.QueryString("dept")
        _bgyear = Master.get_Year()
        _ProId = Request.QueryString("ProId")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        RunSession()

        Response.Redirect("../Module02/Disburse_Budget/Frm_Disburse_Relate_Overview_HRD.aspx?bgid=" & 0 & "&dept=" & _dept & "&myear=" & _bgyear & "&ProId=" & _ProId)

        'UC_Project_List1.bgyear = Master.get_Year()

        'UC_Project_List1.dept = _dept

    End Sub


    'Private Sub btn_next_Click(sender As Object, e As EventArgs) Handles btn_next.Click
    '    'Response.Redirect("../Frm_Main.aspx?bgid=" & 0 & "&dept=" & _dept & "&myear=" & _bgyear)
    '    Response.Redirect("../Module02/Disburse_Budget/Frm_Disburse_Relate_Overview.aspx?bgid=" & 0 & "&dept=" & _dept & "&myear=" & _bgyear)
    'End Sub
End Class