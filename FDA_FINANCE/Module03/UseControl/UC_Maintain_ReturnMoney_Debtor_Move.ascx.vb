Imports Telerik.Web.UI
Public Class UC_Maintain_ReturnMoney_Debtor_Move
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgDebtor_move_Init(sender As Object, e As EventArgs) Handles rgDebtor_move.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgDebtor_move
        Rad_Utility.addColumnCheckbox_client("chkColumn", "chkColumn")
        Rad_Utility.addColumnBound("RETURN_MONEY_DEBTOR_ID", "RETURN_MONEY_DEBTOR_ID", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่หนังสือ")
        Rad_Utility.addColumnBound("BILL_NUMBER", "BILL_NUMBER", False)
        Rad_Utility.addColumnBound("RETURN_DESCRIPTION", "รายละเอียด", width:=250)
        Rad_Utility.addColumnBound("RETURN_AMOUNT", "จำนวนเงินคืน", is_money:=True)
        Rad_Utility.addColumnDate("MONEY_RETURN_DATE", "วันที่คืนเงิน")
        Rad_Utility.addColumnDate("MOVEDATE", "วันที่โอนชดใช้")
    End Sub

    Private Sub rgDebtor_move_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgDebtor_move.NeedDataSource
        Dim bao As New BAO_BUDGET.Maintain
        Dim dt As DataTable
        dt = bao.get_debtor_return_move()
        rgDebtor_move.DataSource = dt
    End Sub
    Public Sub update(ByVal strDate As String)
        If strDate <> "" Then
            For Each item As GridDataItem In rgDebtor_move.SelectedItems
                Dim dao As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
                Dim dao_decrease As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
                Dim debt_id As Integer = 0
                dao.Getdata_by_RETURN_MONEY_DEBTOR_ID(item("RETURN_MONEY_DEBTOR_ID").Text)
                dao_decrease.Getdata_by_Head_ID(item("RETURN_MONEY_DEBTOR_ID").Text)
                'dao.fields.MOVEDATE = CDate(strDate)
                'โค้ดหักล้างใบสำคัญ
                If dao_decrease.fields.RETURN_MONEY_DEBTOR_ID <> Nothing Then
                    For Each dao_decrease.fields In dao_decrease.datas
                        dao_decrease.fields.MOVEDATE = CDate(strDate)

                    Next
                    dao_decrease.update()
                End If

                If dao.fields.BUDGET_DISBURSE_DEBTOR_BILL_ID IsNot Nothing Then
                    debt_id = dao.fields.BUDGET_DISBURSE_DEBTOR_BILL_ID
                    Dim dao_set_movedate As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
                    dao_set_movedate.Getdata_by_DEBTOR_ID(debt_id)
                    For Each dao_set_movedate.fields In dao_set_movedate.datas
                        dao_set_movedate.fields.MOVEDATE = CDate(strDate)

                    Next
                    dao_set_movedate.update()
                End If
            Next
        End If

    End Sub

    Public Sub rg_rebind()
        rgDebtor_move.Rebind()
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgDebtor_move, str)
    End Sub
End Class