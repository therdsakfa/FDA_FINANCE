Public Class UC_Maintain_ReceiveMoney_Detail_Money
    Inherits System.Web.UI.UserControl
    Public rc_id As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'RadNumericTextBox1.AutoPostBack = True
        'If Not IsPostBack Then
        Dim dao_rec As New DAO_MAS.TB_MAS_MONEY_RECEIVER
        dao_rec.get_receiver()
        lb_receiver.Text = dao_rec.fields.RECEIVER_NAME
        rc_id = dao_rec.fields.RECEIVER_MONEY_ID
        'End If
        If Not IsPostBack Then
            Dim bao_cus As New BAO_BUDGET.MASS
            Dim dt_cus As DataTable = bao_cus.get_customer()
            'bind_dl_department()
            'Dim dr_cus As DataRow = dt_cus.NewRow()
            'dr_cus("CUSTOMER_ID") = "0"
            'dr_cus("CUSTOMER_NAME") = "ไม่ทราบเจ้าหนี้"
            'dt_cus.Rows.Add(dr_cus)

            dd_CUSTOMER.DataSource = dt_cus
            dd_CUSTOMER.DataBind()

            If Request.QueryString("RECEIVE_MONEY_ID") IsNot Nothing Then
                Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                dao.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("RECEIVE_MONEY_ID"))
                If dao.fields.CUSTOMER_ID IsNot Nothing Then
                    dd_CUSTOMER.DropDownSelectData(dao.fields.CUSTOMER_ID)
                End If
            End If
        End If
    End Sub
    Public Sub bind_dl_department()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_Department()
        dd_Department.DataSource = dt
        dd_Department.DataBind()
    End Sub
    Public Sub insert(ByRef dao As DAO_MAINTAIN.TB_RECEIVE_MONEY)
        Dim dao_rec As New DAO_MAS.TB_MAS_MONEY_RECEIVER
        dao_rec.get_receiver()
        Dim a As Integer = dao_rec.fields.RECEIVER_MONEY_ID
        dao.fields.RECEIVE_MONEY_TYPE = rbl_RECEIVE_MONEY_TYPE.SelectedItem.Value
        dao.fields.RECEIVE_MONEY_DESCRIPTION = txt_RECEIVE_MONEY_DESCRIPTION.Text
        'dao.fields.FULLNAME = txt_FULLNAME.Text
        dao.fields.FULLNAME = dd_CUSTOMER.SelectedItem.Text
        dao.fields.CUSTOMER_ID = dd_CUSTOMER.SelectedValue
        dao.fields.RECEIVER_MONEY_ID = a
        dao.fields.RECEIVE_AMOUNT = txt_RECEIVE_AMOUNT.Text
        dao.fields.DEPARTMENT_ID = dd_Department.SelectedValue
    End Sub

    Public Sub getdata(ByRef dao As DAO_MAINTAIN.TB_RECEIVE_MONEY)
        rbl_RECEIVE_MONEY_TYPE.SelectedValue = dao.fields.RECEIVE_MONEY_TYPE
        txt_RECEIVE_MONEY_DESCRIPTION.Text = dao.fields.RECEIVE_MONEY_DESCRIPTION
        ' txt_FULLNAME.Text = dao.fields.FULLNAME
        Dim dao_rec As New DAO_MAS.TB_MAS_MONEY_RECEIVER
        dao_rec.Getdata_by_RECEIVER_MONEY_ID(dao.fields.RECEIVER_MONEY_ID)
        lb_receiver.Text = dao_rec.fields.RECEIVER_NAME
        txt_RECEIVE_AMOUNT.Text = dao.fields.RECEIVE_AMOUNT
        Try
            dd_Department.DropDownSelectData(dao.fields.DEPARTMENT_ID)
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub RadNumericTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RadNumericTextBox1.TextChanged

    '    RadNumericTextBox2.Value = CDbl(RadNumericTextBox1.Value) - CDbl(txt_RECEIVE_AMOUNT.Text)
    'End Sub
End Class