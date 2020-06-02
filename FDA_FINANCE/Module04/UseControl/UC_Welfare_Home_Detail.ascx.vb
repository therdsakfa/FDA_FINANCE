Public Partial Class UC_Welfare_Home_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_customer()
            If Request.QueryString("ALL_WELFARE_ID") IsNot Nothing Then
                Dim dao_welfare_home As New DAO_WELFARE.TB_ALL_WELFARE_BILL
                dao_welfare_home.Getdata_by_BUDGET_WELFARE_ID(Request.QueryString("ALL_WELFARE_ID"))
                If dao_welfare_home.fields.USER_ID IsNot Nothing Then
                    dd_CUSTOMER.DropDownSelectData(dao_welfare_home.fields.USER_ID)
                End If
                If dao_welfare_home.fields.MONTH_DIS IsNot Nothing Then
                    dd_month_dis.DropDownSelectText(dao_welfare_home.fields.MONTH_DIS)
                End If
                If dao_welfare_home.fields.MONTH_LIVE IsNot Nothing Then
                    dd_month_live.DropDownSelectText(dao_welfare_home.fields.MONTH_LIVE)
                End If
            End If
        End If
    End Sub
    Public Sub bind_customer()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_customer_gov()

        dd_CUSTOMER.DataSource = dt
        dd_CUSTOMER.DataBind()
        If Request.QueryString("bid") IsNot Nothing Then
            Dim dao_cure As New DAO_DISBURSE.TB_CURE_STUDY
            dao_cure.Getdata_by_CURE_STUDY_ID(Request.QueryString("bid"))
            If dao_cure.fields.USER_ID IsNot Nothing Then
                dd_CUSTOMER.DropDownSelectData(dao_cure.fields.USER_ID)

            End If

        End If

    End Sub
    Public Sub insert(ByRef dao As DAO_WELFARE.TB_ALL_WELFARE_BILL)
        dao.fields.AMOUNT = txt_AMOUNT.Text
        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text
        dao.fields.MONTH_LIVE = dd_month_live.SelectedItem.Text
        dao.fields.MONTH_DIS = dd_month_dis.SelectedItem.Text
        dao.fields.NAME = dd_CUSTOMER.SelectedItem.Text
        dao.fields.USER_ID = dd_CUSTOMER.SelectedValue
        dao.fields.IS_PAY_HOME = cb_IS_PAY_HOME.Checked
        dao.fields.WELFARE_ID = 4
        dao.fields.WELFARE_CODE = "20001"
        If txt_WELFARE_DATE.Text <> "" Then
            dao.fields.WELFARE_DATE = txt_WELFARE_DATE.Text
        End If
        If Request.QueryString("BUDGET_YEAR") IsNot Nothing Then
            dao.fields.BUDGET_YEAR = Request.QueryString("BUDGET_YEAR").ToString()
        End If

    End Sub
    Public Sub getdata(ByRef dao As DAO_WELFARE.TB_ALL_WELFARE_BILL)
        txt_AMOUNT.Text = dao.fields.AMOUNT
        txt_DESCRIPTION.Text = dao.fields.DESCRIPTION
        'txt_MONTH_LIVE.Text = dao.fields.MONTH_LIVE
        'txt_NAME.Text = dao.fields.NAME
        If dao.fields.IS_PAY_HOME IsNot Nothing Then
            If dao.fields.IS_PAY_HOME = True Then
                cb_IS_PAY_HOME.Checked = True
            Else
                cb_IS_PAY_HOME.Checked = False
            End If
        Else
            cb_IS_PAY_HOME.Checked = False
        End If

        If dao.fields.WELFARE_DATE IsNot Nothing Then
            txt_WELFARE_DATE.Text = dao.fields.WELFARE_DATE
        End If

        dd_month_dis.DataBind()
        dd_month_live.DataBind()
        Try
            dd_month_live.DropDownSelectText(dao.fields.MONTH_LIVE)
        Catch ex As Exception

        End Try
        Try
            dd_month_dis.DropDownSelectText(dao.fields.MONTH_DIS)
        Catch ex As Exception

        End Try

    End Sub

End Class