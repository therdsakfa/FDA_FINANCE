Public Class Frm_MoneyType_Edit
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
        If Not IsPostBack Then
            If Request.QueryString("id") <> "" Then
                Dim dao As New DAO_MAS.TB_MAS_MONEY_TYPE
                dao.Getdata_by_MONEY_TYPE_ID(Request.QueryString("id"))
                UC_MoneyType_Detail1.getdata(dao)
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Request.QueryString("id") <> "" And Request.QueryString("typeid") <> "" Then
            Dim dao As New DAO_MAS.TB_MAS_MONEY_TYPE
            dao.Getdata_by_MONEY_TYPE_ID(Request.QueryString("id"))
            Dim old_data As String = dao.fields.MONEY_TYPE_DESCRIPTION
            Dim new_data As String = ""
            UC_MoneyType_Detail1.update(dao)

            dao.update()
            new_data = dao.fields.MONEY_TYPE_DESCRIPTION
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "แก้ไขข้อมูลประเภทเงินจาก " & old_data & " เป็น " & new_data, "MAS_MONEY_TYPE", Request.QueryString("id"))
            ' Response.Redirect("Frm_MoneyType.aspx")
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If
    End Sub
End Class