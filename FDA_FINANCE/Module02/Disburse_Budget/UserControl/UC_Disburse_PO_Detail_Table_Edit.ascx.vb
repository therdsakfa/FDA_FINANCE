Imports Telerik.Web.UI

Public Class UC_Disburse_PO_Detail_Table_Edit
    Inherits System.Web.UI.UserControl
    Private _is_update As Boolean
    Public Property is_update() As Boolean
        Get
            Return _is_update
        End Get
        Set(ByVal value As Boolean)
            _is_update = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        If Request.QueryString("bid") <> "" Then
            Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
            dt = bao.SC_get_bill_det_by_id(Request.QueryString("bid"))
        End If

        RadGrid1.DataSource = dt
    End Sub
    Public Sub rebind_grid()
        RadGrid1.Rebind()
    End Sub
    Public Sub update(ByVal head_id As Integer)
        For Each item As GridDataItem In RadGrid1.Items
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
            dao.Getdata_by_DETAIL_ID(item("DETAIL_ID").Text)
            Try
                Dim rntAmount As New RadNumericTextBox
                rntAmount = item("amount_key").FindControl("rnt_AMOUNT")
                dao.fields.AMOUNT = rntAmount.Value
            Catch ex As Exception

            End Try
            'dao.fields.BUDGET_PLAN_ID = item("BUDGET_PLAN_ID").Text
            'dao.fields.CUSTOMER_ID = item("CUSTOMER_ID").Text
            'dao.fields.GL_ID = item("GL_ID").Text
            dao.update()
        Next
    End Sub
    Public Sub insert(ByVal head_id As Integer)
        For Each item As GridDataItem In RadGrid1.Items
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
            Try
                Dim rntAmount As New RadNumericTextBox
                rntAmount = item("amount_key").FindControl("rnt_AMOUNT") 'DirectCast(item("amount_key").Controls(0), RadNumericTextBox)
                dao.fields.AMOUNT = rntAmount.Value
            Catch ex As Exception

            End Try
            dao.fields.BUDGET_PLAN_ID = item("BUDGET_PLAN_ID").Text
            dao.fields.CUSTOMER_ID = item("CUSTOMER_ID").Text
            dao.fields.GL_ID = item("GL_ID").Text
            dao.fields.BUDGET_DISBURSE_BILL_ID = head_id
            dao.insert()
        Next
        'Try
        '    dao.fields.AMOUNT = rnt_AMOUNT.Value
        'Catch ex As Exception
        '    dao.fields.AMOUNT = 0
        'End Try
        'Try
        '    dao.fields.BUDGET_PLAN_ID = dd_BudgetAdjust.SelectedValue
        'Catch ex As Exception
        '    dao.fields.BUDGET_PLAN_ID = 0
        'End Try
        'dao.fields.CUSTOMER_ID = dd_CUSTOMER.SelectedValue
        'dao.fields.GL_ID = ddl_GL.SelectedValue

    End Sub
End Class