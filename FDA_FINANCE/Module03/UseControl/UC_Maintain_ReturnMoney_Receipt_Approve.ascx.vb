Imports Telerik.Web.UI

Public Class UC_Maintain_ReturnMoney_Receipt_Approve
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgApprove_Init(sender As Object, e As EventArgs) Handles rgApprove.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgApprove
        Rad_Utility.addColumnCheckbox_client("chkColumn", "")
        Rad_Utility.addColumnBound("lcnsid", "lcnsid", False)
        Rad_Utility.addColumnBound("rcptst", "rcptst", False)
        Rad_Utility.addColumnBound("dvcd", "dvcd", False)
        Rad_Utility.addColumnBound("pvncd", "pvncd", False)
        Rad_Utility.addColumnBound("app", "app", False)
        Rad_Utility.addColumnDate("APPROVE_DATE", "APPROVE_DATE", False)
        Rad_Utility.addColumnBound("feeno", "เลขใบสั่งชำระ")
        Rad_Utility.addColumnBound("feeabbr", "feeabbr", False)
        Rad_Utility.addColumnBound("fullname", "ได้รับเงินจาก", width:=250)
        Rad_Utility.addColumnBound("feetpnm", "รายการ", width:=300)
        Rad_Utility.addColumnBound("amt", "จำนวนเงิน", is_money:=True, width:=70)
        Rad_Utility.addColumnBound("ref01", "ref.01")
        Rad_Utility.addColumnBound("ref02", "ref.02")
        Rad_Utility.addColumnBound("stat", "สถานะ")
    End Sub
    Private Sub rg_receive_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rgApprove.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            'Dim P As LinkButton = DirectCast(item("P").Controls(0), LinkButton)
            'Dim url_p As String = "../Module09/Report/Frm_Report_R9_003.aspx?feeno=" & item("feeno").Text & "&feeabbr=" & item("feeabbr").Text & "&lcnsid=" & item("lcnsid").Text
            'P.Attributes.Add("OnClick", "Popups('" & url_p & "'); return false;")
        End If
    End Sub

    Private Sub rg_receive_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgApprove.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.FDA_FEE
        dt = bao.SP_get_receipt_by_bgyear(Request.QueryString("myear"))
        dt.Columns.Add("stat")
        For Each dr As DataRow In dt.Rows
            If IsDBNull(dr("IS_APPROVE")) Then
                dr("stat") = "ยังไม่ได้อนุมัติ"
            Else
                Try
                    If CBool(dr("IS_APPROVE")) = True Then
                        dr("stat") = "อนุมัติแล้ว"
                    Else
                        dr("stat") = "ยังไม่ได้อนุมัติ"
                    End If

                Catch ex As Exception

                End Try

            End If

        Next
        rgApprove.DataSource = dt
    End Sub

    Public Sub insert_approve(ByVal date_input As Date, ByVal iden As String)
        For Each item As GridDataItem In rgApprove.SelectedItems
            Dim dao2 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao2.Getdata_by_receipt2(item("feeno").Text)
            dao2.fields.IS_APPROVE = True
            dao2.fields.APPROVE_DATE = date_input
            dao2.fields.STAFF_IDEN = iden
            dao2.update()

            'Dim dt As New DataTable
            'Dim bao As New BAO_BUDGET.FDA_FEE
            'Dim receipt_num As String = ""
            'dt = bao.SP_get_receipt_by_feeabbr_and_feeno_receipt(item("feeno").Text)
            'Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            'Dim i As Integer = 0
            'i = dao.count_receipt2(item("lcnsid").Text, item("feeno").Text)
            'If i = 0 Then
            '    Dim dao_i As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            '    dao_i.fields.RECEIVE_MONEY_TYPE = 1
            '    dao_i.fields.RECEIVE_MONEY_DESCRIPTION = item("feetpnm").Text
            '    dao_i.fields.FULLNAME = item("fullname").Text
            '    dao_i.fields.CUSTOMER_ID = item("lcnsid").Text
            '    dao_i.fields.RECEIVER_MONEY_ID = 0
            '    dao_i.fields.RECEIVE_AMOUNT = item("amt").Text
            '    dao_i.fields.DEPARTMENT_ID = 0
            '    dao_i.fields.ORDER_PAY1 = item("feeabbr").Text
            '    dao_i.fields.ORDER_PAY2 = item("feeno").Text
            '    dao_i.fields.MONEY_RECEIVE_DATE = Date.Now
            '    dao_i.fields.FEEABBR = item("feeabbr").Text
            '    dao_i.fields.FEENO = item("feeno").Text
            '    dao_i.fields.LCNSID = item("lcnsid").Text
            '    dao_i.fields.BUDGET_YEAR = Request.QueryString("myear")
            '    dao_i.fields.RECEIPT_TYPE = 1
            '    dao_i.fields.REF01 = item("ref01").Text
            '    dao_i.fields.REF02 = item("ref02").Text
            '    dao_i.fields.MONEY_TYPE_ID = 1
            '    dao_i.fields.PVNCD = item("pvncd").Text
            '    dao_i.fields.DVCD = item("dvcd").Text
            '    dao_i.fields.STAFF_IDEN = iden

            '    '----app
            '    dao_i.fields.IS_APPROVE = True
            '    dao_i.fields.APPROVE_DATE = date_input

            '    Dim bao2 As New BAO_BUDGET.Maintain
            '    Dim max_id As Integer = 0
            '    Try
            '        max_id = bao2.get_max_receipt_normal(Request.QueryString("myear"), 2)
            '    Catch ex As Exception

            '    End Try
            '    dao_i.fields.E_RUNNING_RECEIPT = max_id + 1
            '    dao_i.insert()



            '    For Each dr As DataRow In dt.Rows
            '        Dim dao_det As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
            '        dao_det.fields.FK_IDA = dao_i.fields.RECEIVE_MONEY_ID
            '        Try
            '            dao_det.fields.AMOUNT = dr("amt")
            '        Catch ex As Exception
            '            dao_det.fields.AMOUNT = 0
            '        End Try
            '        dao_det.fields.TABEAN_NUMBER = ""
            '        dao_det.fields.FEEABBR = dr("feeabbr")
            '        dao_det.insert()
            '    Next
            'Else
            '    Dim dao2 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            '    dao2.Getdata_by_receipt2(item("feeno").Text)
            '    dao2.fields.IS_APPROVE = True
            '    dao2.fields.APPROVE_DATE = date_input

            '    dao2.update()
            'End If
        Next
    End Sub
    Public Sub no_app()
        For Each item As GridDataItem In rgApprove.SelectedItems
            Dim dao2 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao2.Getdata_by_receipt2(item("feeno").Text)
            dao2.fields.IS_APPROVE = False
            dao2.fields.APPROVE_DATE = Nothing

            dao2.update()
        Next
    End Sub
    Public Function chk_selected() As Boolean
        Dim bool As Boolean = False
        Dim item_c As Integer = 0
        For Each item As GridDataItem In rgApprove.SelectedItems
            item_c += 1
        Next
        If item_c > 0 Then
            bool = True
        End If
        Return bool
    End Function
    Public Function chk_selected_count() As Integer
        Dim item_c As Integer = 0
        For Each item As GridDataItem In rgApprove.SelectedItems
            item_c += 1
        Next
        Return item_c
    End Function
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgApprove, str)
    End Sub
    Public Sub rebind_grid()
        rgApprove.Rebind()
    End Sub
End Class