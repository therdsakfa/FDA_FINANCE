Imports Telerik.Web.UI
Public Class UC_Disburse_Budget_Receive_List
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
    Private _ispo As String
    Public Property ispo() As String
        Get
            Return _ispo
        End Get
        Set(ByVal value As String)
            _ispo = value
        End Set
    End Property
    Private _rebill As Boolean
    Public Property rebill() As Boolean
        Get
            Return _rebill
        End Get
        Set(ByVal value As Boolean)
            _rebill = value
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
    Private _g As Integer
    Public Property g() As Integer
        Get
            Return _g
        End Get
        Set(ByVal value As Integer)
            _g = value
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
    Private _g2 As Integer
    Public Property g2() As Integer
        Get
            Return _g2
        End Get
        Set(ByVal value As Integer)
            _g2 = value
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

    Private Sub rg_Budget_Receive_List_Init(sender As Object, e As EventArgs) Handles rg_Budget_Receive_List.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_Budget_Receive_List
        Rad_Utility.Rad_css_setting(rg_Budget_Receive_List)
        Rad_Utility.addColumnCheckbox_client("chkColumn", "")
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnBound("DEPARTMENT_ID", "DEPARTMENT_ID", False)
        Rad_Utility.addColumnBound("PATLIST_ID", "PATLIST_ID", False)
        'Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร", True, width:=50)
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร", True, width:=50)
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", True, width:=150)
        Rad_Utility.addColumnBound("CUSTOMER_NAME", "ผู้รับเงิน/เจ้าหนี้", True, width:=100)
        Rad_Utility.addColumnBound("sum_amount", "จำนวนเงิน", True, width:=50, is_money:=True)
        'Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        'Rad_Utility.addColumnDate("Bill_RECIEVE_DATE", "วันที่เบิก")
        'Rad_Utility.addColumnDate("DEPARTMENT_DESCRIPTION", "หน่วยงาน")
        'Rad_Utility.addColumnBound("status", "สถานะ")
        Rad_Utility.addColumnBound("reason", "เหตุผลที่ตรวจสอบไม่ผ่าน")
        'Rad_Utility.addColumnCheckbox("mark", "Head")
        'Rad_Utility.addColumnButton("E", "บันทึกรับเรื่อง", "E", 0, "")
        Rad_Utility.addColumnButton("r", "ดูข้อมูล", "r", 0, "")
        'Rad_Utility.addColumnButton("E", "บันทึกรับเรื่อง", "E", 0, "", img:=True, type_img:="import")
        'Rad_Utility.addColumnButton("r", "แก้ไข", "r", 0, "", img:=True, type_img:="edit")
    End Sub
    '
    Private Sub rg_Budget_Receive_List_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rg_Budget_Receive_List.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim id As Integer = item("BUDGET_DISBURSE_BILL_ID").Text
            Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
            dao_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(id)
            Dim BudgetID As Integer = 0
            Try
                BudgetID = dao_bill.fields.BUDGET_PLAN_ID
            Catch ex As Exception

            End Try

            'Dim h2 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            Dim btn_review As LinkButton = DirectCast(item("r").Controls(0), LinkButton)
            Dim url As String = "../../Module02/Disburse_Budget/Frm_Disburse_Budget_Receive_Edit.aspx?bid=" & id & "&bgid=" & BudgetID & "&bgYear=" & dao_bill.fields.BUDGET_YEAR & "&dept=" & dao_bill.fields.DEPARTMENT_ID
            Dim url2 As String = "../../Module02/Disburse_Budget/Frm_Disburse_Budget_Receive_Edit_Bill.aspx?bid=" & id & "&bgid=" & BudgetID & "&bgYear=" & bgyear & "&dept=" & dao_bill.fields.DEPARTMENT_ID
            Dim url3 As String = "../../Module02/Disburse_Budget/Frm_Disburse_Budget_Receive_Review.aspx?bid=" & id & "&bgid=" & BudgetID & "&bgYear=" & bgyear & "&dept=" & dao_bill.fields.DEPARTMENT_ID & "&bit=1" & "&type=1"
            'h2.Attributes.Add("OnClick", "return k(" & id & "," & BudgetID & "," & bgyear & ");")
            'btn_review.Attributes.Add("OnClick", "return k_edit(" & id & "," & BudgetID & "," & bgyear & ");")
            btn_review.Attributes.Add("OnClick", "Popups('" & url3 & "'); return false;")
            'h2.Attributes.Add("OnClick", "Popups('" & url & "'); return false;")
            'btn_edit.Attributes.Add("OnClick", "Popups2('" & url2 & "'); return false;")



        End If
    End Sub

    Private Sub rg_Budget_Receive_List_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_Budget_Receive_List.NeedDataSource
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET()
        Dim dt As New DataTable

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
        If bguse = 1 Then
            Try
                If ispo = "True" Then
                    dt = bao.get_budget_receive_list_PO_V2(bgyear, bguse, stat - 1, g, bt, _CLS.CITIZEN_ID)
                Else
                    If type = 1 Then
                        dt = bao.get_budget_receive_list_bt_group_V3(bgyear, bguse, ispo, stat - 2, g, bt, _CLS.CITIZEN_ID)
                    ElseIf type = 2 Then
                        dt = bao.get_budget_receive_list_bt_group_V3_2(bgyear, bguse, ispo, stat - 1, g, bt)
                    Else
                        dt = bao.get_budget_receive_list_bt_group_V3(bgyear, bguse, ispo, stat - 2, g, bt, _CLS.CITIZEN_ID)
                    End If

                End If
            Catch ex As Exception

            End Try
        Else
            dt = bao.get_budget_receive_list_bt_group_V2(bgyear, bguse, ispo, stat2, g, bt)
        End If

        'dt.Columns.Add("reason")




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
        '    End If

        'End If
        For Each dr As DataRow In dt.Rows
            If type = 2 Then
                If dr("STATUS_ID") >= 5 Then
                    dr("reason") = "ตรวจสอบขั้นต้นผ่านแล้ว"
                ElseIf dr("STATUS_ID") < 5 Then
                    dr("reason") = "ยังไม่ได้ตรวจสอบ"
                ElseIf dr("STATUS_ID") = 4 Then
                    dr("reason") = "ไม่ผ่านการตรวจสอบ"
                ElseIf dr("STATUS_ID") = 0 Then
                    dr("reason") = "ยกเลิก"
                Else
                    dr("reason") = "-"
                End If
            Else
                If dr("STATUS_ID") >= 5 Then
                    dr("reason") = "ตรวจสอบผ่านแล้ว"
                ElseIf dr("STATUS_ID") < 5 Then
                    dr("reason") = "ยังไม่ได้ตรวจสอบ"
                ElseIf dr("STATUS_ID") = 4 Then
                    dr("reason") = "ไม่ผ่านการตรวจสอบ"
                ElseIf dr("STATUS_ID") = 0 Then
                    dr("reason") = "ยกเลิก"
                Else
                    dr("reason") = "-"
                End If
            End If
          
        Next
        rg_Budget_Receive_List.DataSource = dt
    End Sub

    Public Sub rebind_grid()
        rg_Budget_Receive_List.Rebind()
    End Sub

    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rg_Budget_Receive_List)
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_Budget_Receive_List, str)
    End Sub
    Public Sub set_color_rg()
        If rg_Budget_Receive_List.Items.Count > 0 Then
            Dim i As Integer = 0
            For Each item As GridDataItem In rg_Budget_Receive_List.Items
                If i = 0 Then
                    item.ForeColor = Drawing.Color.Crimson

                End If
                i = i & 1
            Next
        End If
    End Sub
    Public Sub update_billdate(ByVal date_input As Date)
        For Each item As GridDataItem In rg_Budget_Receive_List.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
            dao.fields.Bill_RECIEVE_DATE = date_input

            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "แก้ไขวันที่เบิก " & dao.fields.DOC_NUMBER, "BUDGET_BILL", item("BUDGET_DISBURSE_BILL_ID").Text)

            dao.update()
        Next
    End Sub

    Public Sub insert_approve(ByVal date_input As Date, ByVal iden As String)
        For Each item As GridDataItem In rg_Budget_Receive_List.SelectedItems
            Dim dao_app As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            '--------------------เบิก------------------------
            dao_app.fields.BILL_TYPE = bt
            '------------------------------------------------
            dao_app.fields.DATE_ADD = Date.Now
            dao_app.fields.FK_IDA = item("BUDGET_DISBURSE_BILL_ID").Text
            dao_app.fields.IDENTITY_NUMBER = iden
            dao_app.fields.REASON_DATE = date_input
            dao_app.fields.STATUS_ID = stat
            dao_app.fields.GROUP_ID = g
            dao_app.insert()

            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
            dao.fields.BILL_NUMBER = bao.get_max_bill(bgyear, bguse) + 1
            dao.fields.BILL_DATE = date_input
            dao.fields.Bill_RECIEVE_DATE = date_input
            dao.fields.GROUP_ID = g
            dao.fields.STATUS_ID = stat
            Try
                dao.fields.RECEIVE_DATE = date_input
            Catch ex As Exception

            End Try
            dao.fields.IS_RECEIVE = True
            dao.update()
        Next
    End Sub
    Public Function chk_selected() As Boolean
        Dim bool As Boolean = False
        Dim item_c As Integer = 0
        For Each item As GridDataItem In rg_Budget_Receive_List.SelectedItems
            item_c += 1
        Next
        If item_c > 0 Then
            bool = True
        End If
        Return bool
    End Function
    Public Function chk_selected_count() As Integer
        Dim item_c As Integer = 0
        For Each item As GridDataItem In rg_Budget_Receive_List.SelectedItems
            item_c += 1
        Next
        Return item_c
    End Function

    Public Sub open_reject_note(ByVal rg As Integer)

        If rg <> 0 Then
            If rg = 2 Then 'ไม่ผ่าน
                Dim bill_id As Integer = 0
                For Each item As GridDataItem In rg_Budget_Receive_List.SelectedItems
                    bill_id = item("BUDGET_DISBURSE_BILL_ID").Text
                    Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
                    dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(bill_id)
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

            ElseIf rg = 3 Then 'ยกเลิก
                Dim bill_id As Integer = 0
                For Each item As GridDataItem In rg_Budget_Receive_List.SelectedItems
                    bill_id = item("BUDGET_DISBURSE_BILL_ID").Text
                    Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
                    dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(bill_id)
                    dao.fields.GROUP_ID = g
                    dao.fields.STATUS_ID = 0 'stat - 1
                    dao.fields.IS_RECEIVE = False
                    dao.update()

                    Dim dao2 As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
                    dao2.fields.STATUS_ID = 0 'stat
                    dao2.fields.GROUP_ID = g
                    dao2.fields.REASON_DATE = Date.Now
                    dao2.fields.IDENTITY_NUMBER = _CLS.CITIZEN_ID_AUTHORIZE
                    dao2.fields.DATE_ADD = Date.Now
                    dao2.fields.FK_IDA = bill_id
                    dao2.insert()
                Next
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('Frm_Reason.aspx?fk_ida=" & bill_id & "&bt=" & bt & "&stat=0" & "&g=" & g & "');", True)
            End If
        End If


    End Sub
End Class