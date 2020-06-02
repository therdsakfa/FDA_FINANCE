Imports Telerik.Web.UI

Partial Class UC_Disburse_Budget_Bill_withdraw
    Inherits System.Web.UI.UserControl
    Private _BudgetUseID As Integer
    Public Property BudgetUseID() As Integer
        Get
            Return _BudgetUseID
        End Get
        Set(ByVal value As Integer)
            _BudgetUseID = value
        End Set
    End Property
    Private _Citizen As String
    Public Property Citizen() As String
        Get
            Return _Citizen
        End Get
        Set(ByVal value As String)
            _Citizen = value
        End Set
    End Property

    Private _PAY_TYPE_ID As Integer
    Public Property PAY_TYPE_ID() As Integer
        Get
            Return _PAY_TYPE_ID
        End Get
        Set(ByVal value As Integer)
            _PAY_TYPE_ID = value
        End Set
    End Property
    Private _Budgetyear As Integer
    Public Property Budgetyear() As Integer
        Get
            Return _Budgetyear
        End Get
        Set(ByVal value As Integer)
            _Budgetyear = value
        End Set
    End Property
    Private _ispo As String
    Public Property ispo() As String
        Get
            Return _ispo
        End Get
        Set(ByVal value As String)
            _ispo = value
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
    Private _g As Integer
    Public Property g() As Integer
        Get
            Return _g
        End Get
        Set(ByVal value As Integer)
            _g = value
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
    Private _type As Integer
    Public Property type() As Integer
        Get
            Return _type
        End Get
        Set(ByVal value As Integer)
            _type = value
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
    Private _is_rebill As Boolean
    Public Property is_rebill() As Boolean
        Get
            Return _is_rebill
        End Get
        Set(ByVal value As Boolean)
            _is_rebill = value
        End Set
    End Property

    Private _is_no_rebill As Boolean
    Public Property is_no_rebill() As Boolean
        Get
            Return _is_no_rebill
        End Get
        Set(ByVal value As Boolean)
            _is_no_rebill = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' กำหนดคอลัมน์ข้อมูลการเบิกจ่าย
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rgAddKNumber_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgAddKNumber.Init
        Dim rg_Approve As RadGrid = rgAddKNumber
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgAddKNumber
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnBound("DETAIL_ID", "DETAIL_ID", False)
        'Rad_Utility.addColumnBound("id", "ลำดับที่", width:=45)
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร", width:=100)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร", width:=100)

        'Rad_Utility.addColumnBound("CUSTOMER_NAME", "เจ้าหนี้/ผู้รับเงิน")
        'Rad_Utility.addColumnDate("Bill_RECIEVE_DATE", "วันที่รับเอกสาร")
        'Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข GFMIS")
        'Rad_Utility.addColumnDate("GFMIS_DATE", "วันที่ GFMIS")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", width:=250)
        ' Rad_Utility.addColumnBound("GL_NAME", "หมวดค่าใช้จ่าย", width:=150)
        Rad_Utility.addColumnBound("sum_amount", "จำนวนเงิน", width:=80, is_money:=True)
        Rad_Utility.addColumnButton("A", "รับเรื่องเบิก", "A", 0, "")
        'Rad_Utility.addColumnButton("B", "บันทึกฏีกาเบิกเงินงบประมาณ", "B", 0, "")
        'Rad_Utility.addColumnButton("E", "ลบเลขขบ.", "E", 0, "คุณต้องการลบเลข GFMIS หรือไม่")
    End Sub

    Private Sub rgAddKNumber_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgAddKNumber.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            'If e.CommandName = "E" Then
            '    If Not item("BUDGET_DISBURSE_BILL_ID").Text.Contains("&nbsp") Then
            '        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            '        dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
            '        dao.fields.GFMIS_NUMBER = ""
            '        dao.fields.GFMIS_DATE = Nothing
            '        dao.fields.PAY_TYPE_ID = 0
            '        dao.fields.STATUS_ID = stat - 1

            '        Dim log As New log_event.log
            '        log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
            '                       Request.Url.AbsoluteUri.ToString(), "ลบขบ.ใบเบิกจ่ายเลขที่หนังสือ " & dao.fields.DOC_NUMBER, "BUDGET_BILL", item("BUDGET_DISBURSE_BILL_ID").Text)

            '        dao.update()

            '        rgAddKNumber.Rebind()
            '    End If
            'End If

        End If
    End Sub

    ''' <summary>
    ''' ดึงข้อมูลเลข K ใส่ radgrid
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub rgAddKNumber_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgAddKNumber.NeedDataSource
        'Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
        'dao.getdata_KNumber()
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET()

        'If ispo = "True" Then
        '    'dt = bao.getGF_bg_bill_sub_PO(BudgetUseID, Budgetyear)
        '    dt = bao.getGF_bg_bill_sub_PO_bt_group_v2(BudgetUseID, Budgetyear, stat - 1, g, bt)
        'Else
        '    If is_rebill = True Then
        '        dt = bao.getGF_bg_bill_bt_group_rebill_V2(BudgetUseID, Budgetyear, stat - 1, g, bt)
        '    ElseIf is_no_rebill = True Then
        '        dt = bao.getGF_bg_bill_bt_group_no_rebill(BudgetUseID, Budgetyear, stat - 1, g, bt)
        '    Else
        '        dt = bao.getGF_bg_bill_bt_group_V2(BudgetUseID, Budgetyear, ispo, stat - 1, g, bt)
        '    End If

        'End If

        'If ispo = "True" Then
        'dt = bao.get_budget_receive_list_sub_po(bgyear, bguse)
        '    dt.Columns.Add("status")
        '    For Each dr As DataRow In dt.Rows
        '        If IsDBNull(dr("BILL_NUMBER")) = False Then
        '            If dr("BILL_NUMBER") = "" Then
        '                dr("status") = "ยังไม่ได้รับเรื่อง"
        '            Else
        '                dr("status") = "รับเรื่องแล้ว"
        '            End If
        '        Else
        '            dr("status") = "ยังไม่ได้รับเรื่อง"
        '        End If

        '    Next
        'Else
        '    If rebill = True Then
        '        dt = bao.get_budget_receive_no_rebill_list(bgyear, bguse)
        '        dt.Columns.Add("status")
        '        For Each dr As DataRow In dt.Rows
        '            If IsDBNull(dr("BILL_NUMBER")) = False Then
        '                If dr("BILL_NUMBER") = "" Then
        '                    dr("status") = "ยังไม่ได้รับเรื่อง"
        '                Else
        '                    dr("status") = "รับเรื่องแล้ว"
        '                End If
        '            Else
        '                dr("status") = "ยังไม่ได้รับเรื่อง"
        '            End If

        '        Next
        '    Else
        'dt = bao.get_budget_receive_list(bgyear, bguse, ispo)



        '  ------------------ใหม่-------------------
        'If bguse = 1 Then
        '    Try
        '        If ispo = "True" Then
        '            dt = bao.get_budget_receive_list_PO_V2(bgyear, bguse, stat - 1, g, bt, _CLS.CITIZEN_ID)
        '        Else
        '            If Type = 1 Then
        '                dt = bao.get_budget_receive_list_bt_group_V3(bgyear, bguse, ispo, stat - 2, g, bt, _CLS.CITIZEN_ID)
        '            ElseIf Type = 2 Then
        '                dt = bao.get_budget_receive_list_bt_group_V3_2(bgyear, bguse, ispo, stat - 1, g, bt)
        '            Else
        '                dt = bao.get_budget_receive_list_bt_group_V3(bgyear, bguse, ispo, stat - 2, g, bt, _CLS.CITIZEN_ID)
        '            End If

        '        End If
        '    Catch ex As Exception

        '    End Try
        'Else
        dt = bao.get_budget_receive_list_bt_group_V2_deka(Budgetyear, bguse, ispo, stat, g, bt)
        ' End If




        rgAddKNumber.DataSource = dt
    End Sub


    Private Sub rgAddKNumber_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles rgAddKNumber.ItemDataBound
        'TestPopup.aspx
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim lnk_ist As String = ""
            lnk_ist = "../../Module02/Disburse_Budget/Frm_Disburse_Budget_add_withdraw.aspx?bid=" & item("BUDGET_DISBURSE_BILL_ID").Text & "&stat=" & _stat & "&g=" & _g & "&bt=" & _bt & "&det=" & item("DETAIL_ID").Text & "&dept=" & Request.QueryString("dept") & "&bgyear=" & Request.QueryString("myear") & "&Citizen=" & _Citizen
            'Dim link_deka As String = ""
            'link_deka = "../../Module02/Disburse_Budget/Frm_Disburse_Budget_add_withdraw_deka.aspx?bid=" & item("BUDGET_DISBURSE_BILL_ID").Text & "&stat=" & _stat & "&g=" & _g & "&bt=" & _bt & "&det=" & item("DETAIL_ID").Text & "&dept=" & Request.QueryString("dept") & "&bgyear=" & Request.QueryString("myear")

            If BudgetUseID = 3 Then
                lnk_ist = lnk_ist & "&debt=1"
                'ElseIf BudgetUseID = 3 Then
                '    link_deka = link_deka & "&debt=1"
            End If

            If is_rebill = True Then
                lnk_ist = lnk_ist & "&pass=2"
                'ElseIf is_rebill = True Then
                '    link_deka = link_deka & "&pass=2"
            End If

            Dim h2 As LinkButton = DirectCast(item("A").Controls(0), LinkButton)
            h2.Attributes.Add("OnClick", "Popups('" & lnk_ist & "'); return false;")
            'Dim h3 As LinkButton = DirectCast(item("B").Controls(0), LinkButton)
            'h3.Attributes.Add("OnClick", "Popups2('" & link_deka & "'); return false;")

        End If
    End Sub

    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgAddKNumber, str)
    End Sub

    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgAddKNumber)
        'rg_Disburse_Budget.Rebind()
    End Sub

    Public Sub rgRebind()
        rgAddKNumber.Rebind()
    End Sub

End Class