Imports Telerik.Web.UI
Public Class UC_Disburse_Cure_Study
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
    Private _dept As Integer
    Public Property dept() As Integer
        Get
            Return _dept
        End Get
        Set(ByVal value As Integer)
            _dept = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_Disburse_Cure_Study_Init(sender As Object, e As EventArgs) Handles rg_Disburse_Cure_Study.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_Disburse_Cure_Study
        Rad_Utility.addColumnBound("CURE_STUDY_ID", "CURE_STUDY_ID", False)
        Rad_Utility.addColumnBound("id", "id", False)
        Rad_Utility.addColumnCheckbox("IS_APPROVE", "การอนุมัติ", display:=False)
        'Rad_Utility.addColumnBound("CUSTOMER_NAME", "CUSTOMER_NAME", Display:=False)
        Rad_Utility.addColumnIMG("img", "การอนุมัติ")
        'Rad_Utility.addColumnDate("DOC_RECEIVE_DATE", "วันที่รับเอกสาร")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        'Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข ขบ.")
        'Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        'Rad_Utility.addColumnDate("BILL_DATE", "วันที่เบิก")
        Rad_Utility.addColumnBound("GL_NAME", "รายการ", width:=300)
        Rad_Utility.addColumnBound("SEMESTER", "ภาคเรียนที่", width:=70)
        Rad_Utility.addColumnBound("YEAR_STUDY", "ปีการศึกษา", width:=70)
        Rad_Utility.addColumnBound("CUSTOMER_NAME", "ชื่อ-สกุล", width:=200)
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินที่เบิก", is_money:=True)
        'Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่")
        Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        Rad_Utility.addColumnIMG("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
    End Sub

    Private Sub rg_Disburse_Cure_Study_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_Disburse_Cure_Study.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            If e.CommandName = "E" Then
                'Response.Redirect("../Disburse_Budget/Frm_Disburse_Cure_Edit.aspx?bid=" & item("CURE_STUDY_ID").Text)
            ElseIf e.CommandName = "D" Then
                Dim ID As Integer = item("CURE_STUDY_ID").Text
                Dim dao_head As New DAO_DISBURSE.TB_CURE_STUDY
                dao_head.Getdata_by_CURE_STUDY_ID(ID)
                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "ลบใบเบิกค่ารักษาและค่าพยาบาลเลขที่หนังสือ " _
                               & dao_head.fields.DOC_NUMBER, "CURE_STUDY", item("CURE_STUDY_ID").Text)

                dao_head.delete()
                rg_Disburse_Cure_Study.Rebind()
                '   Response.Redirect("/Module02/Disburse_Budget/Frm_Disburse_Cure.aspx")
            End If
        End If
    End Sub

    Private Sub rg_Disburse_Cure_Study_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_Disburse_Cure_Study.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim h1 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim img As Image = DirectCast(item("img").Controls(0), Image)
            Dim url As String = "Frm_Disburse_Cure_Edit.aspx?bid=" & item("CURE_STUDY_ID").Text & "&bgyear=" & BudgetYear & "&dept=" & Request.QueryString("dept")
            'h1.Attributes.Add("OnClick", "return k('" & url & "');")
            h1.Attributes.Add("OnClick", "Popups2('" & url & "'); return false;")
            Dim dao As New DAO_DISBURSE.TB_CURE_STUDY
            dao.Getdata_by_CURE_STUDY_ID(item("CURE_STUDY_ID").Text)
            If dao.fields.IS_APPROVE IsNot Nothing Then
                If dao.fields.IS_APPROVE = True Then
                    img.ImageUrl = "~/images/cb.png"
                Else
                    img.ImageUrl = "~/images/emp_cb.png"
                End If
            Else
                img.ImageUrl = "~/images/emp_cb.png"
            End If
        End If
    End Sub

    Private Sub rg_Disburse_Cure_Study_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_Disburse_Cure_Study.NeedDataSource
        Dim cure_study_bill As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As DataTable = cure_study_bill.get_cure_study_bill_v2_by_Gl(BudgetYear, BillType, stat, g)
        rg_Disburse_Cure_Study.DataSource = dt
    End Sub

    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_Disburse_Cure_Study, str)
    End Sub

    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rg_Disburse_Cure_Study)
        'rg_Disburse_Budget.Rebind()
    End Sub

    Public Sub rg_rebind()
        rg_Disburse_Cure_Study.Rebind()
    End Sub

    Public Sub insert_approve(ByVal date_input As Date, ByVal iden As String)
        For Each item As GridDataItem In rg_Disburse_Cure_Study.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_CURE_STUDY
            Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
            dao.Getdata_by_CURE_STUDY_ID(item("CURE_STUDY_ID").Text)
            dao.fields.GROUP_ID = g
            dao.fields.STATUS_ID = stat
            dao.update()

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
        Next
    End Sub

    Public Function chk_selected() As Boolean
        Dim bool As Boolean = False
        Dim item_c As Integer = 0
        For Each item As GridDataItem In rg_Disburse_Cure_Study.SelectedItems
            item_c += 1
        Next
        If item_c > 0 Then
            bool = True
        End If
        Return bool
    End Function
    Public Function chk_selected_count() As Integer
        Dim item_c As Integer = 0
        For Each item As GridDataItem In rg_Disburse_Cure_Study.SelectedItems
            item_c += 1
        Next
        Return item_c
    End Function
    Public Sub open_reject_note()
        Dim bill_id As Integer = 0
        For Each item As GridDataItem In rg_Disburse_Cure_Study.SelectedItems
            bill_id = item("CURE_STUDY_ID").Text
        Next
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('Frm_Reason.aspx?fk_ida=" & bill_id & "&bt=" & bt & "&stat=" & stat - 1 & "&g=" & g & "');", True)
    End Sub
End Class