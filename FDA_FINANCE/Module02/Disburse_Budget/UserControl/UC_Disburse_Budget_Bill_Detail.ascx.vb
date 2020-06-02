Public Partial Class UC_Disburse_Budget_Bill_Detail
    Inherits System.Web.UI.UserControl
    Private _TypeId As Integer
    Public Property TypeId() As Integer
        Get
            Return _TypeId
        End Get
        Set(ByVal value As Integer)
            _TypeId = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            rdp_GFMIS_DATE.Text = System.DateTime.Now.ToShortDateString()
            

        End If
    End Sub
    Public Sub bind_ddl_k()
        If Request.QueryString("debt") IsNot Nothing Then
            Dim debt As Integer
            debt = Request.QueryString("debt")
            Dim bao As New BAO_BUDGET.Budget
            Dim dt As DataTable = bao.get_k_type_all_with_pay_debt(debt)
            dd_KType.DataSource = dt
            dd_KType.DataBind()
            ddl_split()
        ElseIf Request.QueryString("pass") <> "" Then
            Dim bao As New BAO_BUDGET.Budget
            Dim dt As DataTable = bao.get_k_type(Request.QueryString("pass"))
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
    ''' <summary>
    ''' เพิ่ม/แก้ไขข้อมูลเลขขบ. (เลข K) ในตารางเบิกจ่ายงบ
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)
        Dim pay_type As Integer
        Dim dao_type As New DAO_MAS.TB_MAS_K_TYPE
        dao_type.Getdata_by_ID(dd_KType.SelectedValue)
        pay_type = dao_type.fields.K_TYPE_CODE

        dao.fields.GFMIS_NUMBER = lb_K.Text & txt_GFMIS.Text
        dao.fields.GFMIS_DATE = CDate(rdp_GFMIS_DATE.Text)
        dao.fields.PAY_TYPE_ID = pay_type
        dao.fields.K_TYPE_ID = dd_KType.SelectedValue
    End Sub
    Public Sub update_det(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL_DETAIL)
        dao.fields.GFMIS_DATE = CDate(rdp_GFMIS_DATE.Text)
        dao.fields.GFMIS_NUMBER = lb_K.Text & txt_GFMIS.Text
        dao.fields.K_TYPE_ID = dd_KType.SelectedValue
    End Sub
    ''' <summary>
    ''' เพิ่ม/แก้ไขข้อมูลเลขขบ. (เลข K)
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub insert_GF_table(ByVal dao As DAO_DISBURSE.TB_MAS_GFMIS, ByVal gf_type As Integer, ByVal bill_id As Integer)
        dao.fields.BUDGET_DISBURSE_BILL_ID = bill_id
        dao.fields.GFMIS = lb_K.Text & txt_GFMIS.Text
        dao.fields.GFMIS_DATE = CDate(rdp_GFMIS_DATE.Text)
        dao.fields.GFMIS_TYPE_ID = gf_type
    End Sub
    ''' <summary>
    ''' ดึงข้อมูลเลขขบ. (เลข K)
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)
        txt_GFMIS.Text = dao.fields.GFMIS_NUMBER
        If dao.fields.GFMIS_DATE IsNot Nothing Then
            rdp_GFMIS_DATE.Text = CDate(dao.fields.GFMIS_DATE).ToShortDateString()
        End If
        Try
            dd_KType.DropDownSelectData(dao.fields.K_TYPE_ID)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub getdata_det(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL_DETAIL)
        txt_GFMIS.Text = dao.fields.GFMIS_NUMBER
        If dao.fields.GFMIS_DATE IsNot Nothing Then
            rdp_GFMIS_DATE.Text = CDate(dao.fields.GFMIS_DATE).ToShortDateString()
        End If
        Try
            dd_KType.DropDownSelectData(dao.fields.K_TYPE_ID)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub insert_pay_directt(ByVal dao As DAO_DISBURSE.TB_PAY_DIRECT, ByVal bill_id As Integer)
        dao.fields.BUDGET_DISBURSE_BILL_ID = bill_id
    End Sub
    Public Sub insert_pay_Pass(ByVal dao As DAO_DISBURSE.TB_PAY_PASS, ByVal bill_id As Integer)
        dao.fields.BUDGET_DISBURSE_BILL_ID = bill_id
    End Sub

    Protected Sub dd_KType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_KType.SelectedIndexChanged
        ddl_split()
    End Sub
    Public Sub ddl_split()
        Dim strK As String = dd_KType.SelectedItem.Text
        'Dim spText As String() = strK.Split(" ")
        'If spText(0) <> "" Then
        '    lb_K.Text = spText(0)
        Try
            lb_K.Text = Left(strK, 2)
        Catch ex As Exception
            lb_K.Text = ""
        End Try

        'End If
    End Sub

    'Public Sub Get_Detail(ByVal dao As DAO_DISBURSE.TB_BUDGET_BILL_DETAIL)

    '    RadNumericTextBox1.Value = dao.fields.AMOUNT

    'End Sub


    'Public Sub Set_Detail(ByVal dao As DAO_DISBURSE.TB_BUDGET_BILL_DETAIL)

    '     dao.fields.AMOUNT = RadNumericTextBox1.Value 
    'End Sub

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
    Public Sub sub_k()
        If txt_GFMIS.Text <> "" Then
            If IsNumeric(Left(txt_GFMIS.Text, 1)) = False Then
                txt_GFMIS.Text = Right(txt_GFMIS.Text, 10)
            End If
        End If
    End Sub
End Class