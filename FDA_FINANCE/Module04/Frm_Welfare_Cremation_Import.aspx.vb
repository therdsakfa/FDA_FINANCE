Public Class Frm_Welfare_Cremation_Import
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
        UC_Welfare_Cremation_Import1.month_nm = dd_month.SelectedValue
        If Not IsPostBack Then
            set_dd_bgyear()
        End If
        ' UC_Welfare_Cremation_Import1.BudgetYear = Request.QueryString("bgYear")
        UC_Welfare_Cremation_Import1.BudgetYear = dd_BudgetYear.SelectedValue
        UC_Welfare_Cremation_Import1.byear_query = Request.QueryString("bgYear")
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        If dd_month_dis.SelectedValue <> "" Then
            UC_Welfare_Cremation_Import1.insert_welfare(dd_month_dis.SelectedValue)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย') ; parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกเดือนที่เบิก') ; ", True)
        End If
        
    End Sub

    Private Sub dd_month_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_month.SelectedIndexChanged
        UC_Welfare_Cremation_Import1.rebindRg()
    End Sub

    Public Sub set_dd_bgyear()
        Dim dt As New DataTable
        dt.Columns.Add("byear")
        Dim byearMax As Integer = Year(System.DateTime.Now)
        Dim aa As Date = CDate("1/10/" & Year(System.DateTime.Now))
        If CDate(System.DateTime.Now) >= CDate("1/10/" & Year(System.DateTime.Now)) Then
            byearMax = byearMax + 1
        End If

        For i As Integer = 2555 To byearMax
            Dim drNew As DataRow = dt.NewRow()
            drNew("byear") = i

            dt.Rows.Add(drNew)
        Next

        Dim dv As DataView = dt.DefaultView
        dv.Sort = "byear desc"
        dt = dv.ToTable()

        dd_BudgetYear.DataSource = dt
        dd_BudgetYear.DataBind()
    End Sub
End Class