Public Class Frm_Welfare_Rebill
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
    Dim qstr_BillType As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        qstr_BillType = Request.QueryString("BillType")

        UC_Welfare_Rebill.BudgetYear = Request.QueryString("bgYear")
        UC_Welfare_Rebill.BillType = qstr_BillType
    End Sub

    Private Sub Frm_Welfare_Rebill_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Welfare_Rebill.bindseq()
    End Sub

    Private Sub btn_Insert_Click(sender As Object, e As EventArgs) Handles btn_Insert.Click
        UC_Welfare_Rebill.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub

   

    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_Search.Click
        Dim searchDocNumber As String = UC_Welfare_Rebill_Search.getSearchMsg_DocNumber()
        Dim searchName As String = UC_Welfare_Rebill_Search.getSearchMsg_Name()
        Dim searchAmount As String = UC_Welfare_Rebill_Search.getSearchMsg_Amount()

        If searchDocNumber <> "" Then
            UC_Welfare_Rebill.rgFilter(searchDocNumber)
        ElseIf searchName <> "" Then
            UC_Welfare_Rebill.rgFilter(searchName)
        ElseIf searchAmount <> "" Then
            UC_Welfare_Rebill.rgFilter(searchAmount)
        ElseIf searchDocNumber = "" And searchName = "" And searchAmount = "" Then
            UC_Welfare_Rebill.rgFilter("")
        End If

    End Sub
End Class