Public Class Frm_Pre_Customer_Edit
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
            Dim dao_customer_edit As New DAO_MAS.TB_MAS_CUSTOMER
            dao_customer_edit.Getdata_by_CUSTOMER_ID(Request.QueryString("cusid"))
            UC_CustomerDetails1.getdata(dao_customer_edit)

        End If
    End Sub

    Private Sub btn_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        Dim qstr_cus_ID As Integer
        Dim dao_customer_edit As New DAO_MAS.TB_MAS_CUSTOMER
        If Request.QueryString("cusid") IsNot Nothing Then
            qstr_cus_ID = Request.QueryString("cusid").ToString()

            dao_customer_edit.Getdata_by_CUSTOMER_ID(qstr_cus_ID)
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลลูกหนี้ " & dao_customer_edit.fields.CUSTOMER_NAME, "MAS_CUSTOMER", qstr_cus_ID)

            UC_CustomerDetails1.Update(dao_customer_edit)


            dao_customer_edit.update()

            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('แก้ไขข้อมูลเรียบร้อยแล้ว');window.location.href = 'Frm_Customer.aspx';", True)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If
    End Sub
End Class