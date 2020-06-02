Public Class Frm_Import_Salary_Office
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
        If dd_month.Items.Count = 0 Then
            dd_month.DataBind()
        End If
        UC_Import_Salary_Office1.month_nm = dd_month.SelectedValue
        If Not IsPostBack Then
            set_dd_bgyear(dd_BudgetYear)
        End If
        ' UC_Welfare_Cremation_Import1.BudgetYear = Request.QueryString("bgYear")
        UC_Import_Salary_Office1.BudgetYear = dd_BudgetYear.SelectedValue
        UC_Import_Salary_Office1.byear_query = Request.QueryString("bgYear")
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        If dd_month_dis.SelectedValue <> "" Then
            UC_Import_Salary_Office1.insert(dd_month_dis.SelectedValue)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย') ; parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกเดือนที่เบิก') ; ", True)
        End If

    End Sub

    Private Sub dd_month_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_month.SelectedIndexChanged
        UC_Import_Salary_Office1.rebindRg()
    End Sub


End Class