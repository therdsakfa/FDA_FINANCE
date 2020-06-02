Public Partial Class UC_Welfare_Cure_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bindDropDownGroup()
    End Sub
    Public Sub insert(ByRef dao As DAO_WELFARE.TB_ALL_WELFARE_BILL)
        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text
        'dao.fields.NAME = txt_NAME.Text
        dao.fields.NAME = dl_NameSurname.SelectedItem.Text
        dao.fields.AMOUNT = txt_AMOUNT.Text
        dao.fields.WELFARE_ID = 1
        dao.fields.WELFARE_CODE = "30001"
        dao.fields.MONTH_LIVE = dd_month.SelectedValue
        If txt_WELFARE_DATE.Text <> "" Then
            dao.fields.WELFARE_DATE = CDate(txt_WELFARE_DATE.Text)
        End If
        If Request.QueryString("bgYear") IsNot Nothing Then
            dao.fields.BUDGET_YEAR = Request.QueryString("bgYear").ToString()
        End If
    End Sub
    Public Sub getdata(ByRef dao As DAO_WELFARE.TB_ALL_WELFARE_BILL)
        txt_DESCRIPTION.Text = dao.fields.DESCRIPTION
        'txt_NAME.Text = dao.fields.NAME
        dd_month.DataBind()
        If dao.fields.NAME IsNot Nothing Or dao.fields.NAME <> "" Then
            Try
                dl_NameSurname.DropDownSelectText(dao.fields.NAME)

            Catch ex As Exception

            End Try
        End If
        Try
            txt_AMOUNT.Text = dao.fields.AMOUNT
        Catch ex As Exception

        End Try

        If dao.fields.WELFARE_DATE IsNot Nothing Then
            txt_WELFARE_DATE.Text = dao.fields.WELFARE_DATE
        End If
        Try
            dd_month.DropDownSelectText(dao.fields.MONTH_LIVE)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub bindDropDownGroup()
        If Not IsPostBack Then
            Dim bao As New BAO_BUDGET.USER
            Dim dt As New DataTable
            dt = bao.get_NAME_SURNAME
            dl_NameSurname.DataSource = dt
            dl_NameSurname.DataTextField = "NAME"
            dl_NameSurname.DataValueField = "ID"
            dl_NameSurname.DataSource = dt.DefaultView.ToTable(True, "ID", "NAME")
            dl_NameSurname.DataBind()
        End If
    End Sub
End Class