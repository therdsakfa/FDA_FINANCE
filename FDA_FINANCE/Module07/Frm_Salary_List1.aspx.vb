Imports Telerik.Web.UI

Public Class Frm_Salary_List1
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
            'bind_ddl_paylist()
            set_name()
        End If
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        rg_salary_list.Rebind()
    End Sub

    Protected Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Response.Redirect("Frm_Salary_Office.aspx?m=" & Request.QueryString("m"))
    End Sub

    Private Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click
        insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อยแล้ว');", True)
        rg_salary_list.Rebind()
    End Sub

    Public Sub insert()

        For Each item As GridDataItem In rg_salary_list.Items
            Dim dao_c As New DAO_SALARY.TB_SALARY_DETAIL
            Dim i As Integer = 0
            i = dao_c.count_by_salary_id_salary_list(Request.QueryString("id"), item("SALARY_PAYLIST_ID").Text)
            'Dim rnt_money As RadNumericTextBox = DirectCast(item("rnt_money").Controls(0), RadNumericTextBox)
            Dim rnt_money As RadNumericTextBox = item.FindControl("rnt_money")

            If i = 0 Then
                Dim dao_l As New DAO_SALARY.TB_SALARY_DETAIL
                dao_l.fields.SALARY_ID = Request.QueryString("id")
                dao_l.fields.SALARY_PAYLIST_ID = item("SALARY_PAYLIST_ID").Text
                Try
                    dao_l.fields.AMOUNT = rnt_money.Value
                Catch ex As Exception
                    dao_l.fields.AMOUNT = 0
                End Try
                dao_l.insert()
            Else
                Dim dao_l As New DAO_SALARY.TB_SALARY_DETAIL
                dao_l.Getdata_by_salary_id_salary_list(Request.QueryString("id"), item("SALARY_PAYLIST_ID").Text)
                dao_l.fields.SALARY_ID = Request.QueryString("id")
                dao_l.fields.SALARY_PAYLIST_ID = item("SALARY_PAYLIST_ID").Text
                Try
                    dao_l.fields.AMOUNT = rnt_money.Value
                Catch ex As Exception
                    dao_l.fields.AMOUNT = 0
                End Try
                dao_l.update()
            End If
        Next
    End Sub

    'Public Sub setdata(ByRef dao As DAO_SALARY.TB_SALARY_DETAIL)
    '    dao.fields.SALARY_ID = Request.QueryString("id")
    '    dao.fields.SALARY_PAYLIST_ID = ddlSALARY_PAYLIST.SelectedValue
    '    dao.fields.AMOUNT = rntAmount.Value
    'End Sub
    'Public Sub editdata(ByRef dao As DAO_SALARY.TB_SALARY_DETAIL)
    '    dao.fields.SALARY_PAYLIST_ID = ddlSALARY_PAYLIST.SelectedValue
    '    dao.fields.AMOUNT = rntAmount.Value
    'End Sub
    'Public Sub getdata(ByRef dao As DAO_SALARY.TB_SALARY_DETAIL)
    '    ddlSALARY_PAYLIST.DropDownSelectData(dao.fields.SALARY_PAYLIST_ID)
    '    rntAmount.Value = dao.fields.AMOUNT
    'End Sub

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

        Try
            lbinformation.Text = "ชื่อ " & dao_p.fields.NAME & " " & dao_p.fields.SURNAME & " สังกัด " & dao_d.fields.DEPARTMENT_DESCRIPTION
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rg_salary_list_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_salary_list.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("SALARY_PAYLIST_ID").Text
            Dim rnt_money As RadNumericTextBox = item.FindControl("rnt_money") 'DirectCast(item("rnt_money").Controls(0), RadNumericTextBox)
            Dim dao As New DAO_SALARY.TB_SALARY_DETAIL
            dao.Getdata_by_salary_id_salary_list(Request.QueryString("id"), id)
            Try
                If dao.fields.AMOUNT Is Nothing Then
                    rnt_money.Value = 0
                Else
                    rnt_money.Value = dao.fields.AMOUNT
                End If

            Catch ex As Exception
                rnt_money.Value = 0
            End Try
            If dao.fields.SALARY_DETAIL_ID = 0 Then
                rnt_money.Value = 0
            End If

        End If
    End Sub

    Private Sub rg_salary_list_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_salary_list.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Salary
        dt = bao.get_salary_paylist_input()

        For Each dr As DataRow In dt.Rows
            Dim dao As New DAO_SALARY.TB_SALARY_DETAIL
            dao.Getdata_by_salary_id_salary_list(Request.QueryString("id"), dr("SALARY_PAYLIST_ID"))
            Try
                dr("amount") = dao.fields.AMOUNT
            Catch ex As Exception
                dr("amount") = 0.0
            End Try
        Next

        rg_salary_list.DataSource = dt
    End Sub
End Class