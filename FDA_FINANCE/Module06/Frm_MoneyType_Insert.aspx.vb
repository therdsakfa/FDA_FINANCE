Public Class Frm_MoneyType_Insert
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
        Dim bgyear As Integer = Request.QueryString("bgyear")
        UC_MoneyType_Detail1.bgyear = bgyear
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim dao As New DAO_MAS.TB_MAS_MONEY_TYPE
        If Request.QueryString("typeid") = "1" Then
            Dim id As Integer = Request.QueryString("id")
            UC_MoneyType_Detail1.insert_headMoney(dao)
            dao.insert()
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลประเภทเงิน " & dao.fields.MONEY_TYPE_DESCRIPTION, "MAS_MONEY_TYPE", dao.fields.MONEY_TYPE_ID)
            Dim idinsert As Integer = dao.fields.MONEY_TYPE_ID

            Dim dao2 As New DAO_MAS.TB_MONEY_TYPE_NODE
            dao2.fields.HEAD_ID = id
            dao2.fields.CHILD_ID = idinsert
            dao2.insert()

        Else
            Dim id As Integer = Request.QueryString("id")
            UC_MoneyType_Detail1.insert(dao)
            dao.insert()
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลประเภทเงิน " & dao.fields.MONEY_TYPE_DESCRIPTION, "MAS_MONEY_TYPE", dao.fields.MONEY_TYPE_ID)
            Dim idinsert As Integer = dao.fields.MONEY_TYPE_ID

            Dim dao2 As New DAO_MAS.TB_MONEY_TYPE_NODE
            dao2.fields.HEAD_ID = id
            dao2.fields.CHILD_ID = idinsert
            dao2.insert()
        End If


        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        'Response.Redirect("Frm_MoneyType.aspx")
    End Sub
    'Public Function getbgYear() As Integer
    '    Dim bgYear As Integer = 0
    '    Dim dd_BudgetYear As DropDownList
    '    dd_BudgetYear = CType(Master.FindControl("dd_BudgetYear"), DropDownList)
    '    bgYear = dd_BudgetYear.SelectedValue
    '    Return bgYear
    'End Function
End Class