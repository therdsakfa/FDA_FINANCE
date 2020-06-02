Public Partial Class UC_Welfare_Cremation_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bindDropDownGroup()
            bind_customer()
            dd_CUSTOMER.Items.Insert(0, New ListItem("--ชื่อ-นามสกุล--", ""))

            If Request.QueryString("ALL_WELFARE_ID") IsNot Nothing Then
                Dim dao_welfare As New DAO_WELFARE.TB_ALL_WELFARE_BILL
                dao_welfare.Getdata_by_BUDGET_WELFARE_ID(Request.QueryString("ALL_WELFARE_ID"))
                If dao_welfare.fields.MONTH_LIVE IsNot Nothing Then
                    dd_month.DropDownSelectData(dao_welfare.fields.MONTH_LIVE)
                End If
                If dao_welfare.fields.DEPARTMENT_ID IsNot Nothing Then
                    dl_Department.DropDownSelectData(dao_welfare.fields.DEPARTMENT_ID)
                End If
                If dao_welfare.fields.USER_ID IsNot Nothing Then
                    dd_CUSTOMER.DropDownSelectData(dao_welfare.fields.USER_ID)
                End If

            End If
            set_personal_id(dd_CUSTOMER.SelectedValue)
        End If

    End Sub
    Public Sub insert(ByRef dao As DAO_WELFARE.TB_ALL_WELFARE_BILL)
        dao.fields.AMOUNT = txt_AMOUNT.Text
        If dd_CUSTOMER.SelectedValue <> "" Then
            Dim dao_cus As New DAO_MAS.TB_MAS_CUSTOMER
            dao_cus.Getdata_by_CUSTOMER_ID(dd_CUSTOMER.SelectedValue)
            dao.fields.NAME = dao_cus.fields.CUSTOMER_NAME
            dao.fields.PERSONAL_ID = dao_cus.fields.PERSONAL_ID
            dao.fields.USER_ID = dd_CUSTOMER.SelectedValue
        End If


        'dao.fields.NAME = txt_NAME.Text
        'dao.fields.PERSONAL_ID = txt_PERSONAL_ID.Text
        dao.fields.WELFARE_CODE = "41101"
        If Request.QueryString("BUDGET_YEAR") IsNot Nothing Then
            dao.fields.BUDGET_YEAR = Request.QueryString("BUDGET_YEAR")
        End If

        dao.fields.DEPARTMENT_ID = dl_Department.SelectedItem.Value
        dao.fields.WELFARE_ID = 3 ' 3 = ฌกส
        dao.fields.MONTH_LIVE = dd_month.SelectedValue
        If txt_WELFARE_DATE.Text <> "" Then
            Try
                dao.fields.WELFARE_DATE = CDate(txt_WELFARE_DATE.Text)
            Catch ex As Exception

            End Try

        End If

    End Sub
    

    Public Sub getdata(ByRef dao As DAO_WELFARE.TB_ALL_WELFARE_BILL)
        txt_AMOUNT.Text = dao.fields.AMOUNT
        'txt_NAME.Text = dao.fields.NAME
        'txt_PERSONAL_ID.Text = dao.fields.PERSONAL_ID

        If dao.fields.DEPARTMENT_ID IsNot Nothing Then
            dl_Department.SelectedValue = dao.fields.DEPARTMENT_ID
        End If
        If dao.fields.WELFARE_DATE IsNot Nothing Then
            txt_WELFARE_DATE.Text = dao.fields.WELFARE_DATE
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
    Public Sub bindDropDownGroup()
        If Not IsPostBack Then
            Dim bao As New BAO_BUDGET.MASS
            Dim dt As New DataTable
            dt = bao.get_Department
            dl_Department.DataSource = dt
            dl_Department.DataTextField = "DEPARTMENT_DESCRIPTION"
            dl_Department.DataValueField = "DEPARTMENT_ID"
            dl_Department.DataSource = dt.DefaultView.ToTable(True, "DEPARTMENT_ID", "DEPARTMENT_DESCRIPTION")
            dl_Department.DataBind()
        End If
    End Sub

    Private Sub dd_CUSTOMER_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_CUSTOMER.SelectedIndexChanged
        If dd_CUSTOMER.SelectedValue <> "" Then
            set_personal_id(dd_CUSTOMER.SelectedValue)
        End If
    End Sub

    Public Sub set_personal_id(ByVal per_id As String)
        If per_id <> "" Then
            Dim dao As New DAO_MAS.TB_MAS_CUSTOMER
            dao.Getdata_by_CUSTOMER_ID(per_id)
            If dao.fields.PERSONAL_ID IsNot Nothing Then
                If dao.fields.PERSONAL_ID = "" Then
                    lb_Personal_id.Text = "-"
                Else
                    lb_Personal_id.Text = dao.fields.PERSONAL_ID
                End If
            End If
        Else
            lb_Personal_id.Text = "-"
        End If
    End Sub
End Class