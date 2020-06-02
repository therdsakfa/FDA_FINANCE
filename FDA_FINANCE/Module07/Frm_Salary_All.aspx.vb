Public Class Frm_Salary_All
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
       
        If Not IsPostBack Then
            'UC_Search_Salary1.bind_ddl_person()
            UC_Search_Salary1.bind_ddl_dept()
            If Request.QueryString("m") <> "" Then
                dd_month.DropDownSelectData(Request.QueryString("m"))
            End If
        End If
        UC_Salary_ALL1.BudgetYear = Request.QueryString("myear")
        UC_Salary_ALL1.month_num = dd_month.SelectedValue()
        UC_Salary_ALL1.per_type = 2

    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Salary_ALL1.rg_rebind()
    End Sub

    Private Sub dd_month_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_month.SelectedIndexChanged
        'Request.Url.AbsoluteUri.Replace(Request.Url.Query, String.Empty)
        UC_Salary_ALL1.rg_rebind()
    End Sub

   
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_Salary1.getSearchMsg()
        UC_Salary_ALL1.rgFilter(str)
    End Sub

    Private Sub btn_export_Click(sender As Object, e As EventArgs) Handles btn_export.Click
        UC_Salary_ALL1.export()
            
    End Sub
End Class