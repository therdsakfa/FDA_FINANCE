Imports Telerik.Web.UI
Public Class UC_Disburse_Debtor_Receive_List
    Inherits System.Web.UI.UserControl
    Private _bgyear As Integer
    Public Property bgyear() As Integer
        Get
            Return _bgyear
        End Get
        Set(ByVal value As Integer)
            _bgyear = value
        End Set
    End Property
    Private _bguse As Integer
    Public Property bguse() As Integer
        Get
            Return _bguse
        End Get
        Set(ByVal value As Integer)
            _bguse = value
        End Set
    End Property
    Private _bt As Integer
    Public Property bt() As Integer
        Get
            Return _bt
        End Get
        Set(ByVal value As Integer)
            _bt = value
        End Set
    End Property
    Private _stat As Integer
    Public Property stat() As Integer
        Get
            Return _stat
        End Get
        Set(ByVal value As Integer)
            _stat = value
        End Set
    End Property
    Private _stat2 As Integer
    Public Property stat2() As Integer
        Get
            Return _stat2
        End Get
        Set(ByVal value As Integer)
            _stat2 = value
        End Set
    End Property
    Private _g As Integer
    Public Property g() As Integer
        Get
            Return _g
        End Get
        Set(ByVal value As Integer)
            _g = value
        End Set
    End Property
    Private _CLS As New CLS_SESSION
    Private _process As String
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    Private Sub rg_Debtor_Receive_List_Init(sender As Object, e As EventArgs) Handles rg_Debtor_Receive_List.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_Debtor_Receive_List
        Rad_Utility.Rad_css_setting(rg_Debtor_Receive_List)
        Rad_Utility.addColumnCheckbox_client("chkColumn", "")
        Rad_Utility.addColumnBound("DEBTOR_BILL_ID", "DEBTOR_BILL_ID", False)
        Rad_Utility.addColumnBound("RowNumber", "ลำดับที่")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("FullName", "ชื่อ-นามสกุลผู้ยืม", width:=200)
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", width:=250)
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน ง.ป.ม.", is_money:=True)
        'Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        'Rad_Utility.addColumnDate("BILL_DATE", "วันที่เบิก")
        Rad_Utility.addColumnBound("USER_ID", "USER_ID", False)
        'Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "หน่วยงาน")
        'Rad_Utility.addColumnBound("status", "สถานะ")
        Rad_Utility.addColumnBound("reason", "เหตุผลที่ตรวจสอบไม่ผ่าน")
        'Rad_Utility.addColumnButton("E", "บันทึกรับเรื่อง", "E", 0, "")
    End Sub

    Private Sub rg_Debtor_Receive_List_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rg_Debtor_Receive_List.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim id As Integer = item("DEBTOR_BILL_ID").Text
            'Dim dao_bill As New DAO_DISBURSE.TB_DEBTOR_BILL
            'dao_bill.Getdata_by_DEBTOR_BILL_ID(id)
            'Dim BudgetID As Integer = dao_bill.fields.BUDGET_PLAN_ID
            'Dim h2 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            'Dim url As String = "../../Module02/Disburse_Debtor/Frm_Disburse_Debtor_Receive_Edit.aspx?bid=" & id & "&bgid=" & dao_bill.fields.BUDGET_PLAN_ID & "&bgyear=" & dao_bill.fields.BUDGET_YEAR
            'h2.Attributes.Add("OnClick", " Popups2('" & url & "'); return false;")

        End If
    End Sub

    Private Sub rg_Debtor_Receive_List_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_Debtor_Receive_List.NeedDataSource
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        'Dim dt As DataTable = bao.get_debtor_receive_list(bgyear, bguse)
        Dim dt As New DataTable
        Try
            dt = bao.get_debtor_receive_list_bt_groupv3(bgyear, bguse, stat2, g, bt, _CLS.CITIZEN_ID)
        Catch ex As Exception

        End Try

        'dt.Columns.Add("status")
        'For Each dr As DataRow In dt.Rows
        '    If IsDBNull(dr("BILL_NUMBER")) = False Then
        '        If dr("BILL_NUMBER") = "" Then
        '            dr("status") = "ยังไม่ได้รับเรื่อง"
        '        Else
        '            dr("status") = "รับเรื่องแล้ว"
        '        End If
        '    Else
        '        dr("status") = "ยังไม่ได้รับเรื่อง"
        '    End If

        'Next

        For Each dr As DataRow In dt.Rows
            If dr("STATUS_ID") >= 5 Then
                dr("reason") = "ตรวจสอบผ่านแล้ว"
            ElseIf dr("STATUS_ID") < 5 Then
                dr("reason") = "ยังไม่ได้ตรวจสอบ"
            ElseIf dr("STATUS_ID") = 4 Then
                dr("reason") = "ไม่ผ่านการตรวจสอบ"
            Else
                dr("reason") = "-"
            End If
        Next
        rg_Debtor_Receive_List.DataSource = dt
    End Sub
    Public Sub rebind_grid()
        rg_Debtor_Receive_List.Rebind()
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rg_Debtor_Receive_List)
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_Debtor_Receive_List, str)
    End Sub
    Public Sub set_color_rg()
        If rg_Debtor_Receive_List.Items.Count > 0 Then
            Dim i As Integer = 0
            For Each item As GridDataItem In rg_Debtor_Receive_List.Items
                If i = 0 Then
                    item.ForeColor = Drawing.Color.Crimson

                End If
                i = i + 1
            Next
        End If
    End Sub
    Public Sub insert_approve(ByVal date_input As Date, ByVal iden As String)
        For Each item As GridDataItem In rg_Debtor_Receive_List.SelectedItems
            Dim dao_app As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            '--------------------เบิก------------------------
            dao_app.fields.BILL_TYPE = bt
            '------------------------------------------------
            dao_app.fields.DATE_ADD = Date.Now
            dao_app.fields.FK_IDA = item("DEBTOR_BILL_ID").Text
            dao_app.fields.IDENTITY_NUMBER = iden
            dao_app.fields.REASON_DATE = date_input
            dao_app.fields.STATUS_ID = stat
            dao_app.fields.GROUP_ID = g
            dao_app.insert()

            Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
            Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
            dao.Getdata_by_DEBTOR_BILL_ID(item("DEBTOR_BILL_ID").Text)
            dao.fields.BILL_NUMBER = bao.get_debtor_max_bill(bgyear) + 1
            dao.fields.BILL_DATE = date_input
            dao.fields.GROUP_ID = g
            dao.fields.STATUS_ID = stat
            dao.fields.IS_RECEIVE = True
            Try
                dao.fields.RECEIVE_DATE = date_input
            Catch ex As Exception

            End Try

            dao.update()
        Next
    End Sub
    Public Function chk_selected() As Boolean
        Dim bool As Boolean = False
        Dim item_c As Integer = 0
        For Each item As GridDataItem In rg_Debtor_Receive_List.SelectedItems
            item_c += 1
        Next
        If item_c > 0 Then
            bool = True
        End If
        Return bool
    End Function
    Public Function chk_selected_count() As Integer
        Dim item_c As Integer = 0
        For Each item As GridDataItem In rg_Debtor_Receive_List.SelectedItems
            item_c += 1
        Next
        Return item_c
    End Function
    Public Sub open_reject_note()
        Dim bill_id As Integer = 0
        For Each item As GridDataItem In rg_Debtor_Receive_List.SelectedItems
            bill_id = item("DEBTOR_BILL_ID").Text
            Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
            dao.Getdata_by_DEBTOR_BILL_ID(bill_id)
            dao.fields.GROUP_ID = g
            dao.fields.STATUS_ID = stat - 1

            dao.update()

            Dim dao2 As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            dao2.fields.STATUS_ID = stat
            dao2.fields.GROUP_ID = g
            dao2.fields.REASON_DATE = Date.Now
            dao2.fields.IDENTITY_NUMBER = _CLS.CITIZEN_ID_AUTHORIZE
            dao2.fields.DATE_ADD = Date.Now
            dao2.fields.FK_IDA = bill_id
            dao2.insert()
        Next
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('Frm_Reason.aspx?fk_ida=" & bill_id & "&bt=" & bt & "&stat=" & stat - 1 & "&g=" & g & "');", True)
    End Sub
End Class