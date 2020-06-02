Public Class UC_Salary_List_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
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

End Class