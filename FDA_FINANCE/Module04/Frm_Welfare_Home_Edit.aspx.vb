Public Class Frm_Welfare_Home_Edit
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
        If Not IsPostBack Then
            Dim dao_welfare_home As New DAO_WELFARE.TB_ALL_WELFARE_BILL
            dao_welfare_home.Getdata_by_BUDGET_WELFARE_ID(Request.QueryString("ALL_WELFARE_ID"))
            UC_Welfare_Home_Detail.getdata(dao_welfare_home)
        End If
    End Sub

    Private Sub btn_Edit_Click(sender As Object, e As EventArgs) Handles btn_Edit.Click
        Dim qstr_ALL_WELFARE_ID As Integer
        Dim dao_welfare_home As New DAO_WELFARE.TB_ALL_WELFARE_BILL
        If Request.QueryString("ALL_WELFARE_ID") IsNot Nothing Then
            qstr_ALL_WELFARE_ID = Request.QueryString("ALL_WELFARE_ID").ToString()
            dao_welfare_home.Getdata_by_BUDGET_WELFARE_ID(qstr_ALL_WELFARE_ID)
            UC_Welfare_Home_Detail.insert(dao_welfare_home)
            dao_welfare_home.update()
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "แก้ไขรายการค่าเช่าบ้าน", _
                           "ALL_WELFARE_BILL", Request.QueryString("ALL_WELFARE_ID"))
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('แก้ไขข้อมูลเรียบร้อยแล้ว');window.location.href = 'Frm_Welfare_Home.aspx';", True)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If
    End Sub

    'Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
    '    Response.Redirect("Frm_Welfare_Home.aspx")
    'End Sub
End Class