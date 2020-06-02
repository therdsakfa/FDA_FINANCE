Public Partial Class UC_Disburse_Debtor_Bill_Detail
    Inherits System.Web.UI.UserControl
    Private _Debtor_type As Integer
    Public Property Debtor_type() As Integer
        Get
            Return _Debtor_type
        End Get
        Set(ByVal value As Integer)
            _Debtor_type = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Dim debt As Integer
        'If Request.QueryString("debt") IsNot Nothing Then
        '    debt = Request.QueryString("debt")

        'End If
        If Not IsPostBack Then
            txt_GFMIS_DATE.Text = Date.Now.ToShortDateString()
            '    Dim bao As New BAO_BUDGET.Budget
            '    ' Dim dt As DataTable = bao.get_k_type_all_with_express(debt)
            '    Dim dt As DataTable = bao.get_k_type_debtor()
            '    dd_KType.DataSource = dt
            '    dd_KType.DataBind()
            '    ddl_split()
        End If
    End Sub
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL)
        dao.fields.GFMIS_NUMBER = lb_K.Text & txt_GFMIS.Text
        Try
            dao.fields.GFMIS_DATE = CDate(txt_GFMIS_DATE.Text)
        Catch ex As Exception
            dao.fields.GFMIS_DATE = Nothing
        End Try

        dao.fields.K_TYPE_ID = dd_KType.SelectedValue
    End Sub
    Public Sub insert_det(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL)
        dao.fields.GFMIS_NUMBER = lb_K.Text & txt_GFMIS.Text
        Try
            dao.fields.GFMIS_DATE = CDate(txt_GFMIS_DATE.Text)
        Catch ex As Exception

        End Try

        dao.fields.K_TYPE_ID = dd_KType.SelectedValue
    End Sub
    Public Sub insert_GF_table(ByVal dao As DAO_DISBURSE.TB_MAS_GFMIS)
        dao.fields.BUDGET_DISBURSE_BILL_ID = Request.QueryString("bid")
        dao.fields.GFMIS = lb_K.Text & txt_GFMIS.Text
        dao.fields.GFMIS_DATE = CDate(txt_GFMIS_DATE.Text)
        dao.fields.GFMIS_TYPE_ID = 2
    End Sub
    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL)
        txt_GFMIS.Text = dao.fields.GFMIS_NUMBER
        Try
            txt_GFMIS_DATE.Text = CDate(dao.fields.GFMIS_DATE).ToShortDateString()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub ddl_split()
        'Dim strK As String = dd_KType.SelectedItem.Text
        'Dim spText As String() = strK.Split(" ")
        'If spText(0) <> "" Then
        '    lb_K.Text = spText(0)
        'End If
        lb_K.Text = dd_KType.SelectedItem.Text
    End Sub
    Public Sub sub_k()
        If txt_GFMIS.Text <> "" Then
            If IsNumeric(Left(txt_GFMIS.Text, 1)) = False Then
                txt_GFMIS.Text = Right(txt_GFMIS.Text, 10)
            End If
        End If
    End Sub
    Public Sub bind_ddl_k()
        If Request.QueryString("debt") IsNot Nothing Then
            Dim debt As Integer
            debt = Request.QueryString("debt")
            Dim bao As New BAO_BUDGET.Budget
            'Dim dt As DataTable = bao.get_k_type_all_with_pay_debt(debt)
            Dim dt As DataTable = bao.get_k_type_debtor()
            dd_KType.DataSource = dt
            dd_KType.DataBind()
            ddl_split()
        Else
            'rdp_GFMIS_DATE.Text = System.DateTime.Now.ToShortDateString()
            Dim bao As New BAO_BUDGET.Budget
            Dim dt As DataTable = bao.get_k_type_all_with_pay()
            'For Each dr As DataRow In dt.Rows
            '    dd_KType.Items.Add(New ListItem(dr("K_TYPE_NAME")))
            'Next
            dd_KType.DataSource = dt
            dd_KType.DataBind()

            ddl_split()
            'DropDownList1.DataSource = dt
            'DropDownList1.DataBind()
        End If
    End Sub
    Private Sub dd_KType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_KType.SelectedIndexChanged
        ddl_split()
    End Sub
    Public Function chk_len_k() As Boolean
        Dim bool As Boolean = False
        If txt_GFMIS.Text <> "" Then
            If Left(txt_GFMIS.Text, 1) <> "K" Then
                If Len(txt_GFMIS.Text) = 10 Then
                    bool = True
                ElseIf Len(txt_GFMIS.Text) > 10 Then
                    bool = False
                ElseIf Len(txt_GFMIS.Text) < 10 Then
                    bool = False
                End If
            Else
                bool = False
            End If
        End If
        Return bool
    End Function
End Class