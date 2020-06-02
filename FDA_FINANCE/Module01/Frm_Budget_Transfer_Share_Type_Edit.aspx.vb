Public Class Frm_Budget_Transfer_Share_Type_Edit
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
            If Request.QueryString("id") IsNot Nothing Then
                Dim dao As New DAO_BUDGET.TB_BUDGET_TRANSFER_DETAIL
                dao.Getdata_by_ID(Request.QueryString("id"))
                UC_Budget_Transfer_Share_Type_Detail1.getdata(dao)

            End If
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If Request.QueryString("id") IsNot Nothing Then
            Dim dao As New DAO_BUDGET.TB_BUDGET_TRANSFER_DETAIL
            dao.Getdata_by_ID(Request.QueryString("id"))
            UC_Budget_Transfer_Share_Type_Detail1.update(dao)
            dao.update()
            Dim log As New log_event.log
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขข้อมูลเรียบร้อยแล้ว') ;parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If
        
    End Sub
End Class