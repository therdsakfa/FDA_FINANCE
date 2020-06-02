Public Class Frm_Pre_Customer_Insert
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
    End Sub

    'Private Sub btn_save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_save.Click

    '    Dim dao_insert_customer As New DAO_MAS.TB_MAS_PRE_CUSTOMER

    '        'UC_CustomerDetails1.insert(dao_insert_customer)
    '        UC_Pre_CustomerDetails1.insert(dao_insert_customer)

    '        dao_insert_customer.insert()
    '        Dim log As New log_event.log
    '        log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
    '                       Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลเจ้าหนี้/ลูกหนี้ชื่อ " & dao_insert_customer.fields.CUSTOMER_NAME, "MAS_PRE_CUSTOMER", dao_insert_customer.fields.CUSTOMER_ID)
    '        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เพิ่มข้อมูลเรียบร้อยแล้ว');window.location.href = 'Frm_Customer.aspx';", True)
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)

    'End Sub
End Class