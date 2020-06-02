Public Partial Class Frm_CustomerType_Edit
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
            Dim dao_customer_type_edit As New DAO_MAS.TB_MAS_CUSTOMER_TYPE
            dao_customer_type_edit.Getdata_by_CUSTOMER_TYPE_ID(Request.QueryString("cusid"))
            UC_CustomerType_Insert1.getdata(dao_customer_type_edit)
            UC_CustomerType_Insert1.set_dd_selected()
        End If
    End Sub

    Private Sub btn_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        Dim qstr_cus_ID As Integer
        Dim dao_customer_type As New DAO_MAS.TB_MAS_CUSTOMER_TYPE
        If Request.QueryString("cusid") IsNot Nothing Then
            qstr_cus_ID = Request.QueryString("cusid").ToString()
            dao_customer_type.Getdata_by_CUSTOMER_TYPE_ID(qstr_cus_ID)
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "แก้ไขข้อมูลประเภทเจ้าหนี้ " & dao_customer_type.fields.CUSTOMER_TYPE, "MAS_CUSTOMER_TYPE", qstr_cus_ID)
            UC_CustomerType_Insert1.insert(dao_customer_type)
            dao_customer_type.update()
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('แก้ไขข้อมูลเรียบร้อยแล้ว');window.location.href = 'Frm_CustomerType.aspx';", True)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If

    End Sub
End Class