Imports Telerik.Web.UI
Public Class UC_Disburse_Cure_Study_Receive_List
    Inherits System.Web.UI.UserControl
    Private _BillType As Integer
    Public Property BillType() As Integer
        Get
            Return _BillType
        End Get
        Set(ByVal value As Integer)
            _BillType = value
        End Set
    End Property
    Private _BudgetYear As Integer
    Public Property BudgetYear() As Integer
        Get
            Return _BudgetYear
        End Get
        Set(ByVal value As Integer)
            _BudgetYear = value
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

    Private Sub rg_Cure_Study_Receive_List_Init(sender As Object, e As EventArgs) Handles rg_Cure_Study_Receive_List.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_Cure_Study_Receive_List
        ' Rad_Utility.Rad_css_setting(rg_Cure_Study_Receive_List)
        Rad_Utility.addColumnBound("CURE_STUDY_ID", "CURE_STUDY_ID", False)
        'Rad_Utility.addColumnBound("id", "ลำดับที่")
        'Rad_Utility.addColumnDate("DOC_RECEIVE_DATE", "วันที่รับเอกสาร")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        'Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        'Rad_Utility.addColumnDate("BILL_DATE", "วันที่เบิก")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินที่เบิก", is_money:=True)
        'Rad_Utility.addColumnBound("status", "สถานะ")
        Rad_Utility.addColumnBound("reason", "เหตุผลที่ตรวจสอบไม่ผ่าน")
        'Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่")
        'Rad_Utility.addColumnIMG("E", "บันทึกรับเรื่อง", "E", 0, "", img:=True, type_img:="import")
    End Sub

    Private Sub rg_Cure_Study_Receive_List_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_Cure_Study_Receive_List.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim id As Integer = item("CURE_STUDY_ID").Text
            'Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim str As String = ""

            'Try
            '    str = "Frm_Disburse_Cure_Receive_List_Edit.aspx?bid=" & id & "&bgyear=" & BudgetYear & "&dept=" & Request.QueryString("dept")
            'Catch ex As Exception

            'End Try
            'h2.Attributes.Add("OnClick", "Popups2(" & id & "," & BudgetYear & "); return false;")
            'h2.Attributes.Add("OnClick", "return k(" & id & "," & BudgetYear & ");")

        End If
    End Sub

    Private Sub rg_Cure_Study_Receive_List_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_Cure_Study_Receive_List.NeedDataSource
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As DataTable = bao.get_cure_study_receive_list(BudgetYear, BillType)

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

        rg_Cure_Study_Receive_List.DataSource = dt
    End Sub
    Public Sub rebind_grid()
        rg_Cure_Study_Receive_List.Rebind()
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rg_Cure_Study_Receive_List)
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_Cure_Study_Receive_List, str)
    End Sub
    Public Sub set_color_rg()
        If rg_Cure_Study_Receive_List.Items.Count > 0 Then
            Dim i As Integer = 0
            For Each item As GridDataItem In rg_Cure_Study_Receive_List.Items
                If i = 0 Then
                    item.ForeColor = Drawing.Color.Crimson

                End If
                i = i + 1
            Next
        End If
    End Sub

    Public Sub insert_approve(ByVal date_input As Date, ByVal iden As String)
        For Each item As GridDataItem In rg_Cure_Study_Receive_List.SelectedItems
            Dim dao_app As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            '--------------------เบิก------------------------
            dao_app.fields.BILL_TYPE = bt
            '------------------------------------------------
            dao_app.fields.DATE_ADD = Date.Now
            dao_app.fields.FK_IDA = item("CURE_STUDY_ID").Text
            dao_app.fields.IDENTITY_NUMBER = iden
            dao_app.fields.REASON_DATE = date_input
            dao_app.fields.STATUS_ID = stat
            dao_app.fields.GROUP_ID = g
            dao_app.insert()

            Dim dao As New DAO_DISBURSE.TB_CURE_STUDY
            Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
            dao.Getdata_by_CURE_STUDY_ID(item("CURE_STUDY_ID").Text)
            dao.fields.BILL_NUMBER = bao.get_max_bill_cure_study(BudgetYear) + 1
            dao.fields.BILL_DATE = date_input
            dao.fields.GROUP_ID = g
            dao.fields.STATUS_ID = stat
            dao.update()
        Next
    End Sub
    Public Function chk_selected() As Boolean
        Dim bool As Boolean = False
        Dim item_c As Integer = 0
        For Each item As GridDataItem In rg_Cure_Study_Receive_List.SelectedItems
            item_c += 1
        Next
        If item_c > 0 Then
            bool = True
        End If
        Return bool
    End Function
    Public Function chk_selected_count() As Integer
        Dim item_c As Integer = 0
        For Each item As GridDataItem In rg_Cure_Study_Receive_List.SelectedItems
            item_c += 1
        Next
        Return item_c
    End Function
    Public Sub open_reject_note()
        Dim bill_id As Integer = 0
        For Each item As GridDataItem In rg_Cure_Study_Receive_List.SelectedItems
            bill_id = item("CURE_STUDY_ID").Text
            Dim dao As New DAO_DISBURSE.TB_CURE_STUDY
            dao.Getdata_by_CURE_STUDY_ID(bill_id)
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