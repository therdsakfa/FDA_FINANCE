Public Class Frm_Welfare_Cremation
    Inherits System.Web.UI.Page

    'Public Function getBgYear() As Integer
    '    Dim bgYear As Integer = 0
    '    Dim dd_BudgetYear As DropDownList
    '    dd_BudgetYear = CType(Master.FindControl("dd_BudgetYear"), DropDownList)
    '    bgYear = dd_BudgetYear.SelectedValue
    '    Return bgYear
    'End Function
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
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
        UC_Welfare_Cremation.BudgetYear = Request.QueryString("myear")
        UC_Welfare_Cremation.month_nm = dd_month.SelectedValue
        'UC_Welfare_Cremation.rebindRg()
    End Sub

    Private Sub btn_Insert_Click(sender As Object, e As EventArgs) Handles btn_Insert.Click
        '' Response.Redirect("Frm_Welfare_Cremation_Insert.aspx?BUDGET_YEAR=" & Master.get_Year())
    End Sub

    Private Sub Frm_Welfare_Cremation_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Welfare_Cremation.bindseq()
    End Sub

    Protected Sub btn_Export_Click(sender As Object, e As EventArgs) Handles btn_Export.Click
        If dd_month.SelectedValue <> "" Then
            Dim dt As New DataTable
            Dim bao As New BAO_BUDGET.Welfare
            dt = bao.get_welfares_cremetion(dd_month.SelectedValue, Master.get_Year())
            Dim Source As String = dt.ObjecttoCSV

            Response.Clear()
            Response.Buffer = True
            Response.ClearContent()
            Response.Charset = "windows-874"
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(874)
            Response.AddHeader("content-disposition", "attachment;filename=Loan.csv")
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.ContentType = "application/vnd.ms-excel"

            Response.Write(Source)
            Response.End()
        End If


        
    End Sub

    Private Sub dd_month_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_month.SelectedIndexChanged
        UC_Welfare_Cremation.rebindRg()
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Welfare_Cremation.rebindRg()
    End Sub
End Class