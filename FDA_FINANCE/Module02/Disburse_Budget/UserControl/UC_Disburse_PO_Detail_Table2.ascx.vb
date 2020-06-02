Imports Telerik.Web.UI

Public Class UC_Disburse_PO_Detail_Table2
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


    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        If Request.QueryString("bid") <> "" Then
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
            Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
            dt = bao.SC_get_relate_det_po_by_id(dao.fields.RELATE_ID)


        End If

        RadGrid1.DataSource = dt
    End Sub

    Public Sub rebind_grid()
        RadGrid1.Rebind()
    End Sub

    'Public Sub bind_ddl_period()
    '    Dim bao As New BAO_BUDGET.Budget
    '    Dim dt As New DataTable
    '    Try
    '        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
    '        dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
    '        dt = bao.get_period_ddl(dao.fields.RELATE_ID)
    '    Catch ex As Exception

    '    End Try

    '    ddl_period.DataSource = dt
    '    ddl_period.DataBind()
    'End Sub

    Public Sub update(ByVal head_id As Integer)
        'For Each item As GridDataItem In RadGrid1.Items
        For Each item As GridDataItem In RadGrid1.SelectedItems
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
        Try

            For Each item As GridDataItem In RadGrid1.SelectedItems

                Dim numberPERIOD As Integer = 0
                numberPERIOD = item("PERIOD_ID").Text

                Dim bg_id As String = ""
                bg_id = Request.QueryString("bid")

                Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
                dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(bg_id)


                If numberPERIOD <> 0 Then
                    Dim dao2 As New DAO_DISBURSE.TB_RELATE_DETAIL_PO
                    dao2.Getdata_by_Relate_id_and_period(dao.fields.RELATE_ID, numberPERIOD)


                    For Each dao2.fields In dao2.datas
                        Dim dao_det As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL

                        Dim daoChk As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                        daoChk.Getdata_by_Disburse_idandPer(dao2.fields.BUDGET_PLAN_ID, numberPERIOD)

                        dao_det.fields.BUDGET_PLAN_ID = dao2.fields.BUDGET_PLAN_ID
                        dao_det.fields.CUSTOMER_ID = dao2.fields.CUSTOMER_ID
                        dao_det.fields.GL_ID = dao2.fields.GL_ID
                        dao_det.fields.AMOUNT = dao2.fields.PERIOD_AMOUNT
                        dao_det.fields.BUDGET_DISBURSE_BILL_ID = head_id
                        dao_det.fields.PERIOD = dao2.fields.PERIOD_ID

                        If daoChk.fields.DETAIL_ID <> 0 Then
                            dao_det.update()
                        Else
                            dao_det.insert()
                        End If

                        dao2.fields.IS_BERG = True

                    Next

                    dao2.update()
                End If

            Next


            'If ddl_period.SelectedValue <> 0 Then
            '    Dim dao2 As New DAO_DISBURSE.TB_RELATE_DETAIL_PO
            '    dao2.Getdata_by_Relate_id_and_period(dao.fields.RELATE_ID, ddl_period.SelectedValue)


            '    For Each dao2.fields In dao2.datas
            '        Dim dao_det As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL

            '        dao_det.fields.BUDGET_PLAN_ID = dao2.fields.BUDGET_PLAN_ID
            '        dao_det.fields.CUSTOMER_ID = dao2.fields.CUSTOMER_ID
            '        dao_det.fields.GL_ID = dao2.fields.GL_ID
            '        dao_det.fields.AMOUNT = dao2.fields.PERIOD_AMOUNT
            '        dao_det.fields.BUDGET_DISBURSE_BILL_ID = head_id
            '        dao_det.fields.PERIOD = dao2.fields.PERIOD_ID
            '        dao_det.insert()
            '        dao2.fields.IS_BERG = True
            '    Next

            '    dao2.update()
            'End If

        Catch ex As Exception

        End Try

        'For Each item As GridDataItem In RadGrid1.Items
        '    Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        '    Try
        '        Dim rntAmount As New RadNumericTextBox
        '        rntAmount = item("amount_key").FindControl("rnt_AMOUNT") 'DirectCast(item("amount_key").Controls(0), RadNumericTextBox)
        '        dao.fields.AMOUNT = rntAmount.Value
        '    Catch ex As Exception

        '    End Try
        '    dao.fields.BUDGET_PLAN_ID = item("BUDGET_PLAN_ID").Text
        '    dao.fields.CUSTOMER_ID = item("CUSTOMER_ID").Text
        '    dao.fields.GL_ID = item("GL_ID").Text
        '    dao.fields.BUDGET_DISBURSE_BILL_ID = head_id
        '    dao.insert()
        'Next


    End Sub

    Private Sub Radgrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound

        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then

            Dim item As GridDataItem
            item = DirectCast(e.Item, GridDataItem)
            'item = e.Item

            Dim check As CheckBox = DirectCast(item("chkColumn").Controls(0), CheckBox)

            Dim PERIOD_ID As Boolean = False

            If item("IS_BERG").Text <> "&nbsp;" Then
                PERIOD_ID = item("IS_BERG").Text
            Else
                PERIOD_ID = False
            End If

            If PERIOD_ID <> False Then
                item.Selected = True
                check.Enabled = False
            Else
                item.Selected = False
            End If

        End If

    End Sub

End Class