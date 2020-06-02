Public Class Frm_Welfare_Cremation_Insert
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
    Public Function getBgYear() As Integer
        Dim bgYear As Integer = 0
        Dim dd_BudgetYear As DropDownList
        dd_BudgetYear = CType(Master.FindControl("dd_BudgetYear"), DropDownList)
        bgYear = dd_BudgetYear.SelectedValue
        Return bgYear
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        Dim dao_welfare_cremation_insert As New DAO_WELFARE.TB_ALL_WELFARE_BILL
        UC_Welfare_Cremation_Detail.insert(dao_welfare_cremation_insert)
        dao_welfare_cremation_insert.fields.DESCRIPTION = "เงิน ฌกส."
        dao_welfare_cremation_insert.insert()
        Dim log As New log_event.log
        log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                       Request.Url.AbsoluteUri.ToString(), "บันทึกรายการเงินฌกส.", _
                       "ALL_WELFARE_BILL", dao_welfare_cremation_insert.fields.ALL_WELFARE_ID)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub

End Class