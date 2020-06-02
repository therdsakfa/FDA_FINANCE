Public Partial Class Frm_PayList_Edit
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
        If Not IsPostBack Then
            Dim dao_Paylist_edit As New DAO_MAS.TB_MAS_PAYLIST
            dao_Paylist_edit.Getdata_by_PAYLIST_ID(Request.QueryString("pid"))
            UC_PayList_Inserts1.getdata(dao_Paylist_edit)
        End If
    End Sub

    Private Sub btn_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        Dim qstr_p_id As Integer
        Dim dao_paylist_edit As New DAO_MAS.TB_MAS_PAYLIST
        If Request.QueryString("pid") IsNot Nothing Then
            qstr_p_id = Request.QueryString("pid").ToString()
            dao_paylist_edit.Getdata_by_PAYLIST_ID(qstr_p_id)
            Dim old_data As String = dao_paylist_edit.fields.PAYLIST_DESCRIPTION
            Dim new_data As String = ""
           
            UC_PayList_Inserts1.insert(dao_paylist_edit)
            dao_paylist_edit.update()
            new_data = dao_paylist_edit.fields.PAYLIST_DESCRIPTION
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "แก้ไขข้อมูลประเภทค่าใช้จ่ายจาก " & old_data & " เป็น " & new_data, "MAS_PAYLIST", Request.QueryString("pid"))
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('แก้ไขข้อมูลเรียบร้อยแล้ว');window.location.href = 'Frm_PayList.aspx';", True)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If
    End Sub
End Class