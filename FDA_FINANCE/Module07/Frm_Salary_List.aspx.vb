Public Class Frm_Salary_List
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
            bind_ddl_paylist()
            set_name()
        End If
    End Sub
    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Salary_Paylist1.rg_rebind()
    End Sub

    Protected Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Response.Redirect("Frm_Salary_All.aspx?m=" & Request.QueryString("m"))
    End Sub

    Private Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click
        Dim dao As New DAO_SALARY.TB_SALARY_DETAIL
        setdata(dao)
        dao.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อยแล้ว');", True)
        UC_Salary_Paylist1.rg_rebind()
    End Sub

    Public Sub setdata(ByRef dao As DAO_SALARY.TB_SALARY_DETAIL)
        dao.fields.SALARY_ID = Request.QueryString("id")
        dao.fields.SALARY_PAYLIST_ID = ddlSALARY_PAYLIST.SelectedValue
        dao.fields.AMOUNT = rntAmount.Value
    End Sub
    Public Sub editdata(ByRef dao As DAO_SALARY.TB_SALARY_DETAIL)
        dao.fields.SALARY_PAYLIST_ID = ddlSALARY_PAYLIST.SelectedValue
        dao.fields.AMOUNT = rntAmount.Value
    End Sub
    Public Sub getdata(ByRef dao As DAO_SALARY.TB_SALARY_DETAIL)
        ddlSALARY_PAYLIST.DropDownSelectData(dao.fields.SALARY_PAYLIST_ID)
        rntAmount.Value = dao.fields.AMOUNT
    End Sub
    Public Sub bind_ddl_paylist()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_SALARY_PAYLIST(1)

        ddlSALARY_PAYLIST.DataSource = dt
        ddlSALARY_PAYLIST.DataBind()
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
    Public Sub set_name()
        Dim dao As New DAO_SALARY.TB_SALARY()
        dao.Getdata_by_ID(Request.QueryString("id"))
        Dim dao_p As New DAO_MAS.TB_Personal
        dao_p.Getdata_by_ID(dao.fields.PERSON_FK_ID)
        Dim dao_d As New DAO_MAS.TB_MAS_DEPARTMENT
        dao_d.Getdata_by_DEPARTMENT_ID(dao_p.fields.DEPARTMENT_ID)
        'Dim dao_pre As New DAO_MAS.

        Try
            lbinformation.Text = "ชื่อ " & dao_p.fields.NAME & " " & dao_p.fields.SURNAME & " สังกัด " & dao_d.fields.DEPARTMENT_SHORT_DESCRIPTION
        Catch ex As Exception

        End Try
    End Sub
End Class