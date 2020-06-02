Imports Telerik.Web.UI
Public Class UC_RELATE_BILL_WITH_HEAD_APPROVE
    Inherits System.Web.UI.UserControl
    Private _BudgetID As Integer
    Public Property BudgetID() As Integer
        Get
            Return _BudgetID
        End Get
        Set(ByVal value As Integer)
            _BudgetID = value
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
    Private _dept As Integer
    Public Property dept() As Integer
        Get
            Return _dept
        End Get
        Set(ByVal value As Integer)
            _dept = value
        End Set
    End Property
    Private _bg_use As Integer
    Public Property bg_use() As Integer
        Get
            Return _bg_use
        End Get
        Set(ByVal value As Integer)
            _bg_use = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub rg_relate_Init(sender As Object, e As EventArgs) Handles rg_relate.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_relate
        Rad_Utility.addColumnBound("RELATE_ID", "RELATE_ID", False)
        Rad_Utility.addColumnIMG("img", "การอนุมัติ")
        Rad_Utility.addColumnBound("RowNumber", "ลำดับ", width:=70)
        Rad_Utility.addColumnBound("app", "app", False)
        'Rad_Utility.addColumnDate("DO_DATE", "วันที่ทำรายการ")
        'Rad_Utility.addColumnBound("RECEIVE_FULL_NUMBER", "เลขที่รับเรื่อง")
        'Rad_Utility.addColumnDate("RECEIVE_DATE", "วันที่รับเรื่อง")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("DESCRIPTION", "เรื่อง", width:=400)
        Rad_Utility.addColumnBound("CUSTOMER_NAME", "ผู้รับเงิน/เจ้าหนี้")
        Rad_Utility.addColumnBound("sum_amount", "จำนวนเงินผูกพัน", is_money:=True, footer_txt:="รวม ", width:=200)
        'Rad_Utility.addColumnBound("balance", "จำนวนเงินคงเหลือ", is_money:=True)
        'Rad_Utility.addColumnIMG("doo", "ดูข้อมูล", "doo", 0, "", img:=True, type_img:="review")
        'Rad_Utility.addColumnIMG("sel", "เลือกข้อมูล", "sel", 0, "", img:=True, type_img:="import")
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "", width:=120)
        Rad_Utility.addColumnButton("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", width:=120)
        'Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        'Rad_Utility.addColumnIMG("Delete", "ลบ", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
    End Sub

    Private Sub rg_relate_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_relate.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                If Not item("RELATE_ID").Text.Contains("&nbsp") Then
                    Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
                    dao.Getdata_by_ID(item("RELATE_ID").Text)
                    dao.delete()
                    rg_relate.Rebind()
                End If
            End If
        End If
    End Sub

    Private Sub rg_relate_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_relate.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim id As Integer = item("RELATE_ID").Text
            ' Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim _Edit As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            ' Dim h3 As ImageButton = DirectCast(item("DeleteColumn").Controls(0), ImageButton)
            'h2.Attributes.Add("OnClick", "return k(" & id & "," & BudgetID & "," & BudgetYear & ");")
            'h2.Attributes.Add("OnClick", "Popups2('Frm_Disburse_Relate_Edit2.aspx?bid=" & id & "&bgid=" & BudgetID & "&bgYear=" & BudgetYear & "'); return false;")



            Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
            dao.Getdata_by_ID(id)

            Try
                _Edit.Attributes.Add("OnClick", "Popups2('Frm_Disburse_Relate_InsertV2.aspx?bid=" & id & "&bgYear=" & BudgetYear & "&dept=" & dao.fields.DEPARTMENT_ID & "'); return false;")

            Catch ex As Exception

            End Try



            Dim dao_a As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            Dim co As Integer = 0
            Dim bao_a As New BAO_BUDGET.DISBURSE_BUDGET

            Dim yy As Integer = 0

            If _BudgetYear > 2500 Then
                yy = (_BudgetYear - 1) - 543
            Else
                yy = _BudgetYear
            End If

            Try
                ' co = dao_a.count_approve(item("RELATE_ID").Text, 1, 3)
                co = bao_a.getCount_count_approve(item("RELATE_ID").Text, 3, 1, yy)

            Catch ex As Exception

            End Try


            Dim img As Image = DirectCast(item("img").Controls(0), Image)

            If co > 0 Then
                img.ImageUrl = "~/images/cb.png"
            Else
                img.ImageUrl = "~/images/emp_cb.png"
            End If
            'If dao.fields.IS_APPROVE IsNot Nothing Then
            '    If dao.fields.IS_APPROVE = True Then
            '        img.ImageUrl = "~/images/cb.png"
            '    Else
            '        img.ImageUrl = "~/images/emp_cb.png"
            '    End If
            'Else
            '    img.ImageUrl = "~/images/emp_cb.png"
            'End If

        End If
    End Sub

    Private Sub rg_relate_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_relate.NeedDataSource
        Dim BudgetBill As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As New DataTable
        dt = BudgetBill.get_relate_bill_V3(BudgetYear, bg_use)
        dt.Columns.Add("balance", GetType(Double))
        For Each dr As DataRow In dt.Rows
            Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
            dao.Getdata_by_ID(dr("RELATE_ID"))
            Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
            Dim amount_all As Double = 0
            Dim berg As Double = 0
            Dim balance As Double = 0
            Try
                If dao.fields.RELATE_TYPE = 2 And dao.fields.IS_PO_APPROVE = True Then
                    amount_all = dao.fields.APPROVE_AMOUNT
                Else
                    amount_all = dao.fields.AMOUNT
                End If
            Catch ex As Exception

            End Try

            berg = bao.get_amount_berg_cer(dr("RELATE_ID"))
            balance = amount_all - berg
            dr("balance") = balance
        Next
        rg_relate.DataSource = dt
    End Sub
    Public Sub rebind_grid()
        rg_relate.Rebind()
    End Sub
    Public Sub update_true(ByVal date_input As Date)
        For Each item As GridDataItem In rg_relate.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
            dao.Getdata_by_ID(item("RELATE_ID").Text)
            dao.fields.IS_APPROVE = True
            dao.fields.APPROVE_DATE = date_input

            'Dim log As New log_event.log
            'log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
            '               Request.Url.AbsoluteUri.ToString(), "อนุมัติใบเบิกจ่ายเลขที่หนังสือ " & dao.fields.DOC_NUMBER, "BUDGET_BILL", item("BUDGET_DISBURSE_BILL_ID").Text)

            dao.update()
        Next
    End Sub
    Public Function chk_selected() As Boolean
        Dim bool As Boolean = False
        Dim item_c As Integer = 0
        For Each item As GridDataItem In rg_relate.SelectedItems
            item_c += 1
        Next
        If item_c > 0 Then
            bool = True
        End If
        Return bool
    End Function
    Public Function chk_selected_count() As Integer
        Dim item_c As Integer = 0
        For Each item As GridDataItem In rg_relate.SelectedItems
            item_c += 1
        Next
        Return item_c
    End Function
    Public Sub open_reject_note()
        Dim RELATE_ID As Integer = 0
        For Each item As GridDataItem In rg_relate.SelectedItems
            RELATE_ID = item("RELATE_ID").Text
        Next
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('Frm_Reason.aspx?fk_ida=" & RELATE_ID & "&bt=1&stat=2&g=0');", True)
    End Sub
    Public Sub insert_approve(ByVal date_input As Date, ByVal iden As String)
        For Each item As GridDataItem In rg_relate.SelectedItems
            Dim dao_app As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            '--------------------ผูกพัน------------------------
            dao_app.fields.BILL_TYPE = 1
            '------------------------------------------------
            dao_app.fields.DATE_ADD = Date.Now
            dao_app.fields.FK_IDA = item("RELATE_ID").Text
            dao_app.fields.IDENTITY_NUMBER = iden
            dao_app.fields.REASON_DATE = date_input
            dao_app.fields.STATUS_ID = 3
            dao_app.fields.GROUP_ID = 0

            dao_app.insert()

            Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
            dao.Getdata_by_ID(item("RELATE_ID").Text)
            dao.fields.STATUS_ID = 3
            dao.update()
            'Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
            'dao.Getdata_by_ID(item("RELATE_ID").Text)
            'dao.fields.IS_APPROVE = False
            'dao.fields.APPROVE_DATE = Nothing

            'dao.update()
        Next
    End Sub
    Public Sub update_false()
        For Each item As GridDataItem In rg_relate.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
            dao.Getdata_by_ID(item("RELATE_ID").Text)
            dao.fields.IS_APPROVE = False
            dao.fields.APPROVE_DATE = Nothing
            dao.fields.STATUS_ID = 2
            dao.update()


        Next
    End Sub
End Class