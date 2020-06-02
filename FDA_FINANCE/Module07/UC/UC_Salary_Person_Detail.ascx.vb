Public Class UC_Salary_Person_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
    End Sub

    Public Sub setdata(ByRef dao As DAO_SALARY.TB_SALARY)

        dao.fields.BUDGET_YEAR = Request.QueryString("bgyear")
        dao.fields.Month_number = dd_month.SelectedValue
        dao.fields.PERSON_FK_ID = ddlName.SelectedValue

        Dim dao_per As New DAO_MAS.TB_Personal
        dao_per.Getdata_by_ID(ddlName.SelectedValue)

        Try

            dao.fields.PER_TYPE = dao_per.fields.PERSON_TYPE
        Catch ex As Exception

        End Try

    End Sub

    Public Sub updatedata(ByRef dao As DAO_SALARY.TB_SALARY)
        dao.fields.Month_number = dd_month.SelectedValue
        dao.fields.PERSON_FK_ID = ddlName.SelectedValue
        Dim dao_per As New DAO_MAS.TB_Personal
        dao_per.Getdata_by_ID(ddlName.SelectedValue)
        Try

            dao.fields.PER_TYPE = dao_per.fields.PERSON_TYPE
        Catch ex As Exception

        End Try

    End Sub

    Public Sub getdata(ByRef dao As DAO_SALARY.TB_SALARY)
        dd_month.DropDownSelectData(dao.fields.Month_number)
        ddlName.DropDownSelectData(dao.fields.PERSON_FK_ID)
    End Sub

    Public Sub bind_ddl_person(ByVal per As Integer)
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_Person_List_by_Type(per)

        ddlName.DataSource = dt
        ddlName.DataBind()
    End Sub

End Class