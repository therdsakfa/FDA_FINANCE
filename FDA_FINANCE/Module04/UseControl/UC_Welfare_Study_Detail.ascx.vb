Public Class UC_Welfare_Study_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bindDropDownGroup()
    End Sub

    Public Sub insert(ByRef dao As DAO_WELFARE.TB_ALL_WELFARE_BILL)
        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text
        dao.fields.NAME = dl_NameSurname.SelectedItem.Text
        dao.fields.AMOUNT = txt_AMOUNT.Text
        dao.fields.WELFARE_ID = 2
        dao.fields.WELFARE_CODE = ""
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
        If dao.fields.NAME IsNot Nothing Or dao.fields.NAME <> "" Then
            'dl_NameSurname.SelectedItem.Text = dao.fields.NAME
        End If
        txt_AMOUNT.Text = dao.fields.AMOUNT
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