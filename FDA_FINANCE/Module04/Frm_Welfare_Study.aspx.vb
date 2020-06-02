Public Class Frm_Welfare_Study
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
    'Public Function getBgYear() As Integer
    '    Dim bgYear As Integer = 0
    '    Dim dd_BudgetYear As DropDownList
    '    dd_BudgetYear = CType(Master.FindControl("dd_BudgetYear"), DropDownList)
    '    bgYear = dd_BudgetYear.SelectedValue

    '    Return bgYear
    'End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()

        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
        UC_Welfare_Study.BudgetYear = Request.QueryString("myear")
        UC_Welfare_Study.month_nm = dd_month.SelectedValue
        'UC_Welfare_Study.rebindRg()
    End Sub

    Private Sub btn_Insert_Click(sender As Object, e As EventArgs) Handles btn_Insert.Click
        Response.Redirect("Frm_Welfare_Rebill.aspx?BUDGET_YEAR=" & Master.get_Year() & "&BillType=" & 2)
    End Sub

    Private Sub Frm_Welfare_Cure_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Welfare_Study.bindseq()
    End Sub

    Private Sub btn_Export_Click(sender As Object, e As EventArgs) Handles btn_Export.Click
        Dim dao_Welfare As New DAO_WELFARE.TB_ALL_WELFARE_BILL
        Dim Source As String = dao_Welfare.export()

        Response.Clear()
        Response.Buffer = True
        Response.ClearContent()
        Response.Charset = "windows-874"
        Response.ContentEncoding = System.Text.Encoding.GetEncoding(874)
        Response.AddHeader("content-disposition", "attachment;filename=FileName.csv")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.ms-excel"

        Response.Write(Source)
        Response.End()
    End Sub

    Private Sub dd_month_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_month.SelectedIndexChanged
        UC_Welfare_Study.rebindRg()
    End Sub
End Class