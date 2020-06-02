Public Class Frm_Maintain_Deposit_Balance
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
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
        If Not IsPostBack Then
            txt_date_save.Text = System.DateTime.Now.ToShortDateString()
            txt_ACCOUNT_NUMBER.Text = "142-1-11084-9"
        End If
        If txt_date_save.Text <> "" Then
            UC_Maintain_Deposit_Balance1.date_select = CDate(txt_date_save.Text)

            btn_report.Attributes.Add("onclick", "window.open('../Module03/Report/Frm_Report_R3_011.aspx?date=" & txt_date_save.Text & "','_blank');")
        End If

    End Sub
    Public Sub insert(ByRef dao As DAO_MAINTAIN.TB_DEPOSIT_BALANCE)
        dao.fields.ACCOUNT_BALANCE_AMOUNT = rnt_ACCOUNT_BALANCE_AMOUNT.Value
        dao.fields.ACCOUNT_NUMBER = txt_ACCOUNT_NUMBER.Text
        dao.fields.CHECK_AMOUNT = rnt_CHECK_AMOUNT.Value
        dao.fields.CHECK_NUMBER = txt_CHECK_NUMBER.Text
        dao.fields.INTEREST_AMOUNT = rnt_INTEREST_AMOUNT.Value
        If txt_date_save.Text <> "" Then
            dao.fields.SAVE_DATE = CDate(txt_date_save.Text)
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_MAINTAIN.TB_DEPOSIT_BALANCE
        insert(dao)
        dao.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
        UC_Maintain_Deposit_Balance1.rebind_grid()

    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Maintain_Deposit_Balance1.rebind_grid()
    End Sub

    Private Sub txt_date_save_TextChanged(sender As Object, e As EventArgs) Handles txt_date_save.TextChanged
        If txt_date_save.Text <> "" Then
            UC_Maintain_Deposit_Balance1.date_select = CDate(txt_date_save.Text)
            UC_Maintain_Deposit_Balance1.rebind_grid()
        End If
    End Sub

    Private Sub Frm_Maintain_Deposit_Balance_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Maintain_Deposit_Balance1.bindseq()
    End Sub
End Class