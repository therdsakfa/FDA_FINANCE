Imports Telerik.Web.UI
Imports Microsoft.Reporting.WebForms
Imports System.Web.HttpServerUtility

Public Class Radgrid_Utility


    Private _FieldName As String()
    Public Property FieldName() As String()
        Get
            Return _FieldName
        End Get
        Set(ByVal value As String())
            _FieldName = value
        End Set
    End Property



    Private _HeadText As String()
    Public Property HeadText() As String()
        Get
            Return _HeadText
        End Get
        Set(ByVal value As String())
            _HeadText = value
        End Set
    End Property




    Public Rad As New RadGrid


    ''' <summary>
    ''' ADD COLUMN  RADGRID
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Sub addColumnBound(ByVal Field_UniqueName As String, ByVal HeaderText As String, Optional ByVal Display As Boolean = True, _
                              Optional ByVal width As Integer = 100, Optional ByVal is_money As Boolean = False, Optional ByVal sort As String = "", Optional ByVal footer_txt As String = "")
        Dim tempcol As New GridBoundColumn

        If footer_txt <> "" Then
            'tempcol.FooterText = footer_txt
            tempcol.Aggregate = GridAggregateFunction.Sum
            tempcol.DataFormatString = "{0:###,0.00}"
            tempcol.FooterAggregateFormatString = footer_txt & " &nbsp; {0:###,0.00}"
            ' tempcol.FooterStyle.HorizontalAlign = HorizontalAlign.Center
        End If
        ' 
        tempcol.UniqueName = Field_UniqueName
        tempcol.DataField = Field_UniqueName
        tempcol.HeaderText = HeaderText
        tempcol.Display = Display
        tempcol.ItemStyle.Width = width
        'tempcol.ItemStyle.Font.Name = "TH SarabunPSK"
        'tempcol.ItemStyle.Font.Size = 16
        If sort <> "" Then
            tempcol.SortExpression = sort
        End If

        If is_money = True Then
            'tempcol.DataFormatString = "{0:###,###.##}"
            tempcol.DataFormatString = "{0:###,0.00}"
            tempcol.ItemStyle.HorizontalAlign = HorizontalAlign.Right
        End If
        Rad.Columns.Add(tempcol)

    End Sub
    Public Sub Rad_css_setting(ByRef rg As RadGrid)
        'rg.HeaderStyle.Font.Name = "TH SarabunPSK"
        'rg.HeaderStyle.Font.Size = 16
    End Sub
    Public Sub addColumnDate(ByVal Field_UniqueName As String, ByVal HeaderText As String, Optional ByVal Display As Boolean = True, Optional ByVal width As Integer = 40)
        Dim tempcol As New GridBoundColumn
        tempcol.UniqueName = Field_UniqueName
        tempcol.DataField = Field_UniqueName
        tempcol.HeaderText = HeaderText
        tempcol.ItemStyle.Width = width
        tempcol.Display = Display
        tempcol.DataFormatString = "{0:dd/MM/yyyy}"
        'tempcol.ItemStyle.Font.Name = "TH SarabunPSK"
        'tempcol.ItemStyle.Font.Size = 16
        'tempcol.ItemStyle.Width = width
        Rad.Columns.Add(tempcol)
    End Sub
    Public Sub addColumnCheckbox(ByVal Field_UniqueName As String, ByVal HeaderText As String, Optional ByVal width As Integer = 40, Optional display As Boolean = True)
        Dim tempcol As New GridCheckBoxColumn
        If display = False Then
            tempcol.Display = False
        End If
        tempcol.UniqueName = Field_UniqueName
        tempcol.DataField = Field_UniqueName
        tempcol.HeaderText = HeaderText
        tempcol.ItemStyle.Width = width
        Rad.Columns.Add(tempcol)
    End Sub
    Public Sub addColumnIMG(ByVal Field_UniqueName As String, ByVal HeaderText As String, Optional ByVal width As Integer = 40, Optional ByVal Display As Boolean = True, _
                             Optional ByVal isButton As Boolean = False)
        Dim tempcol As New GridImageColumn
        tempcol.HeaderText = HeaderText
        tempcol.ImageAlign = ImageAlign.Middle
        tempcol.ItemStyle.Width = width
        tempcol.UniqueName = Field_UniqueName
        tempcol.Display = Display
        Rad.Columns.Add(tempcol)
        '    rg.MasterTableView.Columns.Add(del_col)
    End Sub

    Public Sub addColumnCheckbox_client(ByVal Field_UniqueName As String, ByVal HeaderText As String, Optional ByVal width As Integer = 40)
        Dim tempcol As New GridClientSelectColumn
        tempcol.UniqueName = Field_UniqueName
        tempcol.HeaderText = HeaderText
        tempcol.ItemStyle.Width = width
        Rad.Columns.Add(tempcol)
    End Sub
    Public Sub Columnstyle(ByRef co As GridColumn)
        co.HeaderStyle.Width = 30

    End Sub
    Public Sub addColumnHyper(ByVal CommandName As String, ByVal Text As String, ByVal UniqueName As String, _
                               ByVal button_type As Integer, ByVal ConfirmMsg As String, Optional ByVal width As Integer = 60, Optional ByVal headertext As String = "", _
                               Optional ByVal img As Integer = 0, Optional _display As Boolean = True)

        Dim tempcol As New GridHyperLinkColumn

        'tempcol.h = GridHyperLinkColumn
        '  tempcol.CommandName = CommandName
        tempcol.HeaderText = headertext
        tempcol.Text = Text
        tempcol.Display = _display

        tempcol.ItemStyle.Width = width
        'If ConfirmMsg <> "" Then
        '    tempcol.ConfirmText = ConfirmMsg
        'End If
        tempcol.UniqueName = UniqueName
        Rad.MasterTableView.Columns.Add(tempcol)

        If img <> 0 Then
            tempcol.ImageUrl = "~/images/delete_ico.png"

        End If

        '    rg.MasterTableView.Columns.Add(del_col)
    End Sub
    'Public Sub add_edit_column(ByVal UniqueName As String, ByVal DataField As String, ByVal HeaderText As String)
    '    Dim edit_col As New GridButtonColumn
    '    edit_col.CommandName = "E"
    '    edit_col.Text = "แก้ไขข้อมูล"
    '    edit_col.ButtonType = GridButtonColumnType.LinkButton
    '    GC.Add(edit_col)
    'End Sub
    Public Sub addColumnButton1(ByVal CommandName As String, ByVal Text As String, ByVal UniqueName As String, _
                               ByVal button_type As Integer, ByVal ConfirmMsg As String, Optional ByVal width As Integer = 60, Optional ByVal headertext As String = "")
        Dim tempcol As New GridTemplateColumn
        Dim img As New Image()
        Dim btn As New ImageButton
        'img.ImageUrl = "~~/images/delete_ico.png"
        ' tempcol.InsertItemTemplate = tempcol.ItemTemplate(btn)
        'btn.Controls.Add(img)


        'tempcol.HeaderText = headertext
        'tempcol.HeaderText = Text
        ' btn.CommandName = CommandName
        'tempcol.ImageUrl = "~/images/delete_ico.png"
        'tempcol.ButtonType = GridButtonColumnType.LinkButton

        tempcol.ItemStyle.Width = width
        'If ConfirmMsg <> "" Then
        '    tempcol.co = ConfirmMsg
        'End If
        tempcol.UniqueName = UniqueName
        'Dim container As New System.Web.UI.Control
        tempcol.ItemTemplate = New DelImgButton()
        'tempcol.ItemTemplate = New DelImg()
        Rad.MasterTableView.Columns.Add(tempcol)

        '    rg.MasterTableView.Columns.Add(del_col)
    End Sub
    Public Sub addColumnBound2(ByVal Field_UniqueName As String, ByVal HeaderText As String, Optional ByVal Display As Boolean = True, _
                              Optional ByVal width As Integer = 100, Optional ByVal is_money As Boolean = False, Optional ByVal sort As String = "", Optional ByVal footer_txt As String = "", Optional ByVal is_center As Integer = 0)
        Dim tempcol As New GridBoundColumn

        tempcol.HeaderStyle.Font.Size = 16
        tempcol.HeaderStyle.Font.Bold = True
        tempcol.HeaderStyle.Font.Name = "TH SarabunPSK"
        tempcol.ItemStyle.Font.Size = 16
        tempcol.ItemStyle.Font.Name = "TH SarabunPSK"
        tempcol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center

        If is_center = 0 Then
            tempcol.ItemStyle.HorizontalAlign = HorizontalAlign.Left
        ElseIf is_center = 1 Then 'ซ้าย
            tempcol.ItemStyle.HorizontalAlign = HorizontalAlign.Left
        ElseIf is_center = 2 Then 'กลาง
            tempcol.ItemStyle.HorizontalAlign = HorizontalAlign.Center
        ElseIf is_center = 3 Then 'ขวา
            tempcol.ItemStyle.HorizontalAlign = HorizontalAlign.Right
        End If

        If footer_txt <> "" Then
            'tempcol.FooterText = footer_txt
            tempcol.Aggregate = GridAggregateFunction.Sum
            tempcol.DataFormatString = "{0:###,0.00}"
            tempcol.FooterAggregateFormatString = footer_txt & " &nbsp; {0:###,0.00}"
            ' tempcol.FooterStyle.HorizontalAlign = HorizontalAlign.Center
        End If
        ' 
        tempcol.UniqueName = Field_UniqueName
        tempcol.DataField = Field_UniqueName
        tempcol.HeaderText = HeaderText
        tempcol.Display = Display
        tempcol.ItemStyle.Width = width
        'tempcol.ItemStyle.Font.Name = "TH SarabunPSK"
        'tempcol.ItemStyle.Font.Size = 16
        If sort <> "" Then
            tempcol.SortExpression = sort
        End If

        If is_money = True Then
            'tempcol.DataFormatString = "{0:###,###.##}"
            tempcol.DataFormatString = "{0:###,0.00}"
            tempcol.ItemStyle.HorizontalAlign = HorizontalAlign.Right
        End If
        Rad.Columns.Add(tempcol)

    End Sub


    Public Sub addColumnDate2(ByVal Field_UniqueName As String, ByVal HeaderText As String, Optional ByVal Display As Boolean = True, Optional ByVal width As Integer = 40)
        Dim tempcol As New GridBoundColumn
        tempcol.UniqueName = Field_UniqueName
        tempcol.DataField = Field_UniqueName
        tempcol.HeaderText = HeaderText
        tempcol.ItemStyle.Width = width
        tempcol.HeaderStyle.Font.Size = 16
        tempcol.HeaderStyle.Font.Bold = True
        tempcol.ItemStyle.Font.Size = 16
        tempcol.HeaderStyle.Font.Name = "TH SarabunPSK"
        tempcol.ItemStyle.Font.Name = "TH SarabunPSK"
        tempcol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
        tempcol.ItemStyle.HorizontalAlign = HorizontalAlign.Center
        tempcol.Display = Display
        tempcol.DataFormatString = "{0:dd/MM/yyyy}"
        'tempcol.ItemStyle.Font.Name = "TH SarabunPSK"
        'tempcol.ItemStyle.Font.Size = 16
        'tempcol.ItemStyle.Width = width
        Rad.Columns.Add(tempcol)
    End Sub
    Public Sub addColumnImg2(ByVal CommandName As String, ByVal Text As String, ByVal UniqueName As String, _
                               ByVal button_type As Integer, ByVal ConfirmMsg As String, Optional ByVal width As Integer = 60, Optional ByVal headertext As String = "", Optional ByVal img As Boolean = False, Optional ByVal type_img As String = "")
        Dim tempcol As New GridButtonColumn
        tempcol.ButtonType = GridButtonColumnType.ImageButton
        tempcol.CommandName = CommandName
        tempcol.HeaderText = headertext

        Dim _h As Integer = 40
        tempcol.HeaderStyle.Height = _h
        tempcol.HeaderStyle.Font.Size = 16
        tempcol.HeaderStyle.Font.Bold = True
        tempcol.HeaderStyle.Font.Name = "TH SarabunPSK"
        tempcol.ItemStyle.Font.Name = "TH SarabunPSK"
        tempcol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
        tempcol.Text = Text
        'tempcol.ButtonType = GridButtonColumnType.LinkButton
        If img = True Then
            If type_img = "edit" Then
                tempcol.ImageUrl = "~/images/edit_icon.png"
            ElseIf type_img = "delete" Then
                tempcol.ImageUrl = "~/images/delete_icon.png"
            ElseIf type_img = "key" Then
                tempcol.ImageUrl = "~/images/key_icon.png"
            ElseIf type_img = "report1" Then
                tempcol.ImageUrl = "~/images/report1_icon.png"
            ElseIf type_img = "report2" Then
                tempcol.ImageUrl = "~/images/report2_icon.png"
            ElseIf type_img = "report3" Then
                tempcol.ImageUrl = "~/images/report3_icon.png"
            ElseIf type_img = "report4" Then
                tempcol.ImageUrl = "~/images/report4_icon.png"
            ElseIf type_img = "wrong" Then
                tempcol.ImageUrl = "~/images/wrong_icon.png"
            ElseIf type_img = "correct" Then
                tempcol.ImageUrl = "~/images/correct_icon.png"
            ElseIf type_img = "budget" Then
                tempcol.ImageUrl = "~/images/budget_icon.png"
            ElseIf type_img = "activity" Then
                tempcol.ImageUrl = "~/images/activity_icon.png"
            ElseIf type_img = "file" Then
                tempcol.ImageUrl = "~/images/file_icon.png"
            ElseIf type_img = "download" Then
                tempcol.ImageUrl = "~/images/download_icon.png"
            ElseIf type_img = "permission" Then
                tempcol.ImageUrl = "~/images/permission.png"
            End If
        End If
        tempcol.ItemStyle.Width = width
        tempcol.ItemStyle.HorizontalAlign = HorizontalAlign.Center

        If ConfirmMsg <> "" Then
            tempcol.ConfirmText = ConfirmMsg
        End If
        tempcol.UniqueName = UniqueName
        Rad.MasterTableView.Columns.Add(tempcol)

        '    rg.MasterTableView.Columns.Add(del_col)
    End Sub
    Public Class DelImgButton
        Implements ITemplate
        Protected btn As ImageButton
        Public Sub InstantiateIn(container As Control) Implements ITemplate.InstantiateIn
            btn = New ImageButton()
            btn.ID = "btn_del"
            btn.CommandName = "Delete"
            'btn.Text = "ลบข้อมูล"
            btn.ImageUrl = "~/images/delete_ico.png"

            container.Controls.Add(btn)
        End Sub
    End Class

    Public Class DelImg
        Implements ITemplate


        Protected imgFlag As Image

        Public Sub InstantiateIn(container As Control) Implements ITemplate.InstantiateIn
            imgFlag = New Image()
            imgFlag.ID = "imgFlag"
            imgFlag.ImageUrl = "~/images/delete_ico.png"
            container.Controls.Add(imgFlag)
        End Sub
    End Class
    Public Sub addColumnButton(ByVal CommandName As String, ByVal Text As String, ByVal UniqueName As String, _
                               ByVal button_type As Integer, ByVal ConfirmMsg As String, Optional ByVal width As Integer = 60, Optional ByVal headertext As String = "", _
                               Optional ByVal img As Integer = 0, Optional _display As Boolean = True)
        Dim tempcol As New GridButtonColumn
        tempcol.ButtonType = GridButtonColumnType.LinkButton
        tempcol.CommandName = CommandName
        tempcol.HeaderText = headertext
        tempcol.Text = Text
        tempcol.Display = _display

        tempcol.ItemStyle.Width = width
        If ConfirmMsg <> "" Then
            tempcol.ConfirmText = ConfirmMsg
        End If
        tempcol.UniqueName = UniqueName
        Rad.MasterTableView.Columns.Add(tempcol)

        If img <> 0 Then
            tempcol.ImageUrl = "~/images/delete_ico.png"

        End If

        '    rg.MasterTableView.Columns.Add(del_col)
    End Sub
    Public Sub add_linkbt(ByVal CommandName As String, ByVal Text As String, ByVal UniqueName As String, _
                               ByVal button_type As Integer, ByVal ConfirmMsg As String, Optional ByVal width As Integer = 60, Optional ByVal headertext As String = "")
        Dim tempcol As New GridButtonColumn
        tempcol.ButtonType = GridButtonColumnType.LinkButton
        tempcol.CommandName = CommandName
        tempcol.HeaderText = headertext
        tempcol.ItemStyle.CssClass = ""
        tempcol.Text = Text

        tempcol.ItemStyle.Width = width
        If ConfirmMsg <> "" Then
            tempcol.ConfirmText = ConfirmMsg
        End If
        tempcol.UniqueName = UniqueName
        Rad.MasterTableView.Columns.Add(tempcol)

        '    rg.MasterTableView.Columns.Add(del_col)
    End Sub
    Public Sub addColumnImg(ByVal CommandName As String, ByVal Text As String, ByVal UniqueName As String, _
                               ByVal button_type As Integer, ByVal ConfirmMsg As String, Optional ByVal width As Integer = 60, _
                               Optional ByVal headertext As String = "", Optional ByVal img As Boolean = False, Optional ByVal type_img As String = "" _
                                , Optional ByVal display As Boolean = True)
        Dim tempcol As New GridButtonColumn
        tempcol.ButtonType = GridButtonColumnType.ImageButton
        tempcol.CommandName = CommandName
        tempcol.HeaderText = headertext
        tempcol.Text = Text
        'tempcol.ButtonType = GridButtonColumnType.LinkButton
        If img = True Then
            If type_img = "edit" Then
                tempcol.ImageUrl = "~/images/edit_ico.png"
            ElseIf type_img = "delete" Then
                tempcol.ImageUrl = "~/images/delete_ico.png"
            ElseIf type_img = "pig" Then
                tempcol.ImageUrl = "~/images/piggy_bank.png"
            ElseIf type_img = "report" Then
                tempcol.ImageUrl = "~/images/report.png"
            ElseIf type_img = "insert" Then
                tempcol.ImageUrl = "~/images/insert_ico.png"
            ElseIf type_img = "import" Then
                tempcol.ImageUrl = "~/images/import.png"
            ElseIf type_img = "check" Then
                tempcol.ImageUrl = "~/images/Check-icon.png"
            ElseIf type_img = "cancel" Then
                tempcol.ImageUrl = "~/images/cancel2.png"
            ElseIf type_img = "review" Then
                tempcol.ImageUrl = "~/images/review.png"
            End If
            'insert_ico
        End If
        tempcol.Display = display
        tempcol.ItemStyle.Width = width

        If ConfirmMsg <> "" Then
            tempcol.ConfirmText = ConfirmMsg
        End If
        tempcol.HeaderText = headertext
        tempcol.UniqueName = UniqueName
        Rad.MasterTableView.Columns.Add(tempcol)

        '    rg.MasterTableView.Columns.Add(del_col)
    End Sub
    'Public Sub addColumnTemplate(ByVal CommandName As String, ByVal Text As String, ByVal UniqueName As String, _
    '                           ByVal button_type As Integer, ByVal ConfirmMsg As String, Optional ByVal width As Integer = 60)
    '    Dim tempcol As New GridTemplateColumn
    '    Dim h As New HyperLink

    '    h.ID = "HyperLink1"
    '    h.Text = "แก้ไขข้อมูล"
    '    tempcol.ItemTemplate.InstantiateIn(h)
    '    Rad.MasterTableView.Columns.Add(tempcol)

    '    'Rad.Columns.Add(h)
    '    '    rg.MasterTableView.Columns.Add(del_col)

    'End Sub

    Public Sub addSeqRG(ByRef rg As RadGrid, Optional ByVal seq_bool As Boolean = True)
        Dim i As Integer = 1
        For Each g As GridDataItem In rg.Items
            If g.Display <> False Then
                g("id").Text = i
                i = i + 1
            End If

        Next
    End Sub

End Class
Public Class Utility_other
    Enum Statuslibraly
        All = 0
        returnApprove = 1
        invoice = 2
        tax = 3
    End Enum

    Public Function getBillstatusPay(ByVal bill_id As Integer) As Integer
        Dim digit As Integer = 0
        Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        dao_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(bill_id)
        If dao_bill.fields.IS_RECEIVE_TAX = True Then ' กรอกทั้งหมด
            digit = 5
            TextStatus = "บันทึกข้อมูลครบถ้วน"
        ElseIf dao_bill.fields.RECEIPT_NUMBER <> "" Then ' กรอกทั้งหมด
            digit = 4
            TextStatus = "รอบันทึกการรับใบหักภาษี"
        ElseIf dao_bill.fields.TAX_NUMBER <> "" Then ' กรอกทั้งหมด
            digit = 3
            TextStatus = "รอบันทึกเลขที่ใบเสร็จ"
        ElseIf dao_bill.fields.INVOICES_NUMBER <> "" Then ' รอกรอก tax
            digit = 2
            TextStatus = "รอบันทึกใบกำกับภาษี"
        ElseIf dao_bill.fields.RETURN_APPROVE_NUMBER <> "" Then 'รอกรอกใบแจ้งหนี้
            digit = 1
            TextStatus = "รอบันทึกใบแจ้งหนี้"
        ElseIf dao_bill.fields.RETURN_APPROVE_NUMBER = "" Then 'รอกรอกบก.
            digit = 0
            TextStatus = "รอบันทึกบก. อนุมัติ"
            'Else
            '    digit = 0
        End If
        '    Case "1"
        '        dt(i).Item("digit") = "รอบันทึกใบแจ้งหนี้"
        '    Case "2"
        '        dt(i).Item("digit") = "รอบันทึกใบกำกับภาษี"
        '    Case "3"
        '        dt(i).Item("digit") = "บันทึกข้อมูลครบถ้วน"
        'End Select
        Return digit
    End Function

    Private _TextStatus As String
    Public Property TextStatus() As String
        Get
            Return _TextStatus
        End Get
        Set(ByVal value As String)
            _TextStatus = value
        End Set
    End Property



    Public Function getBillstatusPay_to_margin(ByVal bill_id As Integer) As Integer
        Dim digit As Integer = 0
        Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        dao_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(bill_id)
        If dao_bill.fields.TAX_NUMBER <> "" Then ' กรอกทั้งหมด
            digit = 4

        ElseIf dao_bill.fields.INVOICES_NUMBER <> "" Then ' รอกรอก tax
            digit = 3
        ElseIf dao_bill.fields.RETURN_APPROVE_NUMBER <> "" Then 'รอกรอกใบแจ้งหนี้
            digit = 2
        ElseIf dao_bill.fields.GFMIS_NUMBER <> "" Then 'รอกรอกบก.
            digit = 1
        ElseIf dao_bill.fields.GFMIS_NUMBER = "" Then 'รอกรอกบก.
            digit = 0
            'Else
            '    digit = 0
        End If
        Return digit
    End Function
    Public Function getBillstatusPay_Pass(ByVal bill_id As Integer) As Integer
        Dim digit As Integer = 0
        Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        dao_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(bill_id)

        If dao_bill.fields.IS_CHECK_RECEIVE = True Then
            digit = 5
            TextStatus = "บันทึกข้อมูลครบถ้วน"
        ElseIf dao_bill.fields.IS_CHECK_READY = True Then 'รอกรอกใบแจ้งหนี้
            digit = 4
            TextStatus = "รอบันทึกการจ่าย"
        ElseIf dao_bill.fields.RETURN_APPROVE_NUMBER <> "" Then
            digit = 3
            TextStatus = "รอการอนุมัติเช็ค"
        ElseIf dao_bill.fields.CHECK_APPROVE = True Then
            digit = 2
            TextStatus = "รอบันทึกบก. อนุมัติ"
        ElseIf dao_bill.fields.CHECK_NUMBER <> "" Then
            digit = 1
            TextStatus = "รอการรับเช็ค"
        ElseIf dao_bill.fields.CHECK_NUMBER = "" Then
            digit = 0
            TextStatus = "รอบันทึกเลขที่เช็ค"
        End If
        Return digit
        'dao_bill.fields.RETURN_APPROVE_NUMBER
    End Function
    Public Function getBillstatusPay_Pass_No_Rebill(ByVal bill_id As Integer, ByVal is_no_rebill As Boolean) As Integer
        Dim digit As Integer = 0
        Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        dao_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(bill_id)
        Dim dao_return As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
        Dim dao_debt As New DAO_DISBURSE.TB_DEBTOR_BILL
        If is_no_rebill = True Then
            If dao_bill.fields.RETURN_MONEY_ID IsNot Nothing Then
                dao_return.Getdata_by_RETURN_MONEY_DEBTOR_ID(dao_bill.fields.RETURN_MONEY_ID)
                If dao_return.fields.MOVEDATE IsNot Nothing Then
                    digit = 4
                    TextStatus = "บันทึกข้อมูลครบถ้วน"
                ElseIf dao_bill.fields.RETURN_APPROVE_NUMBER <> "" Then
                    digit = 3
                    TextStatus = "รอบันทึกวันโอน"
                ElseIf dao_bill.fields.CHECK_APPROVE = True Then
                    digit = 2
                    TextStatus = "รอบันทึกบก. อนุมัติ"
                ElseIf dao_bill.fields.CHECK_NUMBER <> "" Then
                    digit = 1
                    TextStatus = "รอการรับเช็ค"
                ElseIf dao_bill.fields.CHECK_NUMBER = "" Then
                    digit = 0
                    TextStatus = "รอบันทึกเลขที่เช็ค"
                End If
            End If
        Else
            If dao_bill.fields.DEBTOR_ID IsNot Nothing Then
                dao_debt.Getdata_by_DEBTOR_BILL_ID(dao_bill.fields.DEBTOR_ID)
                If dao_debt.fields.MOVEDATE IsNot Nothing Then
                    digit = 4
                    TextStatus = "บันทึกข้อมูลครบถ้วน"
                ElseIf dao_bill.fields.RETURN_APPROVE_NUMBER <> "" Then
                    digit = 3
                    TextStatus = "รอบันทึกวันโอน"
                ElseIf dao_bill.fields.CHECK_APPROVE = True Then
                    digit = 2
                    TextStatus = "รอบันทึกบก. อนุมัติ"
                ElseIf dao_bill.fields.CHECK_NUMBER <> "" Then
                    digit = 1
                    TextStatus = "รออนุมัติเช็ค"
                ElseIf dao_bill.fields.CHECK_NUMBER = "" Then
                    digit = 0
                    TextStatus = "รอบันทึกเลขที่เช็ค"
                End If
            End If
        End If

        Return digit
        'dao_bill.fields.RETURN_APPROVE_NUMBER
    End Function
    Public Function getBillstatusPay_Pass_Margin_Move(ByVal bill_id As Integer) As Integer
        Dim digit As Integer = 0
        Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        Dim dao_bill2 As New DAO_DISBURSE.TB_BUDGET_BILL
        dao_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(bill_id)

        If dao_bill.fields.RETURN_MONEY_ID IsNot Nothing Then
            'dao_bill2.Getdata_by_BUDGET_DISBURSE_BILL_ID(dao_bill.fields.BILL_ID_MOVE)
            If dao_bill.fields.MOVEDATE IsNot Nothing Then
                digit = 4
                TextStatus = "บันทึกข้อมูลครบถ้วน"
            ElseIf dao_bill.fields.RETURN_APPROVE_NUMBER <> "" Then
                digit = 3
                TextStatus = "รอบันทึกวันโอน"
            ElseIf dao_bill.fields.CHECK_APPROVE = True Then
                digit = 2
                TextStatus = "รอบันทึกบก. อนุมัติ"
            ElseIf dao_bill.fields.CHECK_NUMBER <> "" Then
                digit = 1
                TextStatus = "รอการรับเช็ค"
            ElseIf dao_bill.fields.CHECK_NUMBER = "" Then
                digit = 0
                TextStatus = "รอบันทึกเลขที่เช็ค"
            End If
        End If

        Return digit
        'dao_bill.fields.RETURN_APPROVE_NUMBER
    End Function

    Public Function getdebtorstatus_cancel(ByVal bill_id As Integer) As Integer
        Dim digit As Integer = 0
        Dim dao_bill As New DAO_DISBURSE.TB_DEBTOR_BILL
        dao_bill.Getdata_by_DEBTOR_BILL_ID(bill_id)

        If dao_bill.fields.CANCEL_MOVEDATE IsNot Nothing Then
            digit = 2
            TextStatus = "บันทึกข้อมูลครบถ้วน"
        ElseIf dao_bill.fields.CANCEL_TRANSFER_NAME <> "" Then
            digit = 1
            TextStatus = "รอบันทึกวันโอน"
        ElseIf dao_bill.fields.CANCEL_TRANSFER_NAME = "" Then
            digit = 0
            TextStatus = "รอบันทึกเลขที่เช็ค"
        End If
        Return digit
    End Function

    Public Function getBillstatusMargin(ByVal bill_id As Integer) As Integer
        Dim digit As Integer = 0
        Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL_MARGIN_DETAIL
        dao_bill.Getdata_by_Disburse_id(bill_id)
        If dao_bill.fields.IS_CHECK_RECEIVE = True Then 'รอกรอกใบแจ้งหนี้
            digit = 3
        ElseIf dao_bill.fields.CHECK_APPROVE = True Then 'รอกรอกใบแจ้งหนี้
            digit = 2
        ElseIf dao_bill.fields.CHECK_NUMBER <> "" Then 'รอกรอกใบแจ้งหนี้
            digit = 1
        ElseIf dao_bill.fields.CHECK_NUMBER = "" Then 'รอกรอกบก.
            digit = 0
        End If
        Return digit
    End Function
    Public Function getBillstatusDebtor_Express(ByVal bill_id As Integer) As Integer
        Dim digit As Integer = 0
        Dim dao_bill As New DAO_DISBURSE.TB_DEBTOR_BILL
        dao_bill.Getdata_by_DEBTOR_BILL_ID(bill_id)
        If dao_bill.fields.IS_CHECK_RECEIVE = True Then 'รอกรอกใบแจ้งหนี้
            digit = 5
        ElseIf dao_bill.fields.IS_CHECK_READY = True Then 'รอกรอกใบแจ้งหนี้
            digit = 4
        ElseIf dao_bill.fields.RETURN_APPROVE_NUMBER <> "" Then 'รอกรอกใบแจ้งหนี้
            digit = 3
        ElseIf dao_bill.fields.CHECK_APPROVE = True Then 'รอกรอกใบแจ้งหนี้
            digit = 2
        ElseIf dao_bill.fields.CHECK_NUMBER <> "" Then 'รอกรอกบก.
            digit = 1
        ElseIf dao_bill.fields.CHECK_NUMBER = "" Then 'รอกรอกบก.
            digit = 0
        End If
        Return digit
    End Function
    Public Function getBillstatusOutsideDebtor_Express(ByVal bill_id As Integer) As Integer
        Dim digit As Integer = 0
        Dim dao_bill As New DAO_DISBURSE.TB_DEBTOR_BILL
        dao_bill.Getdata_by_DEBTOR_BILL_ID(bill_id)
        If dao_bill.fields.IS_CHECK_RECEIVE = True Then
            digit = 4
        ElseIf dao_bill.fields.IS_CHECK_READY = True Then
            digit = 3
        ElseIf dao_bill.fields.CHECK_APPROVE = True Then
            digit = 2
        ElseIf dao_bill.fields.CHECK_NUMBER <> "" Then 'รอกรอกบก.
            digit = 1
        ElseIf dao_bill.fields.CHECK_NUMBER = "" Then 'รอกรอกบก.
            digit = 0
        End If
        Return digit

        'Dim digit As Integer = 0
        'Dim dao_bill As New DAO_DISBURSE.TB_DEBTOR_BILL
        'dao_bill.Getdata_by_DEBTOR_BILL_ID(bill_id)
        'If dao_bill.fields.IS_CHECK_RECEIVE = True Then 'รอกรอกใบแจ้งหนี้
        '    digit = 5
        'ElseIf dao_bill.fields.IS_CHECK_READY = True Then 'รอกรอกใบแจ้งหนี้
        '    digit = 4
        'ElseIf dao_bill.fields.RETURN_APPROVE_NUMBER <> "" Then 'รอกรอกใบแจ้งหนี้
        '    digit = 3
        'ElseIf dao_bill.fields.CHECK_APPROVE = True Then 'รอกรอกใบแจ้งหนี้
        '    digit = 2
        'ElseIf dao_bill.fields.CHECK_NUMBER <> "" Then 'รอกรอกบก.
        '    digit = 1
        'ElseIf dao_bill.fields.CHECK_NUMBER = "" Then 'รอกรอกบก.
        '    digit = 0
        'End If
        'Return digit
    End Function
    Public Function getDebtorstatusMargin(ByVal bill_id As Integer) As Integer
        Dim digit As Integer = 0
        Dim dao_bill As New DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL
        dao_bill.Getdata_by_DEBTOR_BILL_ID(bill_id)
        If dao_bill.fields.IS_CHECK_RECEIVE = True Then 'รอกรอกใบแจ้งหนี้
            digit = 4
        ElseIf dao_bill.fields.IS_CHECK_READY = True Then 'รอกรอกใบแจ้งหนี้
            digit = 3
        ElseIf dao_bill.fields.CHECK_APPROVE = True Then 'รอกรอกใบแจ้งหนี้
            digit = 2
        ElseIf dao_bill.fields.CHECK_NUMBER <> "" Then 'รอกรอกใบแจ้งหนี้
            digit = 1
        ElseIf dao_bill.fields.CHECK_NUMBER = "" And dao_bill.fields.CHECK_NUMBER Is Nothing Then 'รอกรอกบก.
            digit = 0
        End If
        Return digit
    End Function

    Public Function getBillstatusMargin_NEW(ByVal bill_id As Integer) As Integer
        Dim digit As Integer = 0
        Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL_MARGIN_DETAIL
        dao_bill.Getdata_by_Disburse_id(bill_id)
        If dao_bill.fields.IS_CHECK_RECEIVE = True Then 'รอกรอกใบแจ้งหนี้
            digit = 4
        ElseIf dao_bill.fields.IS_CHECK_READY = True Then 'รอกรอกใบแจ้งหนี้
            digit = 3
        ElseIf dao_bill.fields.CHECK_APPROVE = True Then 'รอกรอกใบแจ้งหนี้
            digit = 2
        ElseIf dao_bill.fields.CHECK_NUMBER <> "" Then 'รอกรอกใบแจ้งหนี้
            digit = 1
        ElseIf dao_bill.fields.CHECK_NUMBER = "" And dao_bill.fields.CHECK_NUMBER Is Nothing Then 'รอกรอกบก.
            digit = 0
        End If
        Return digit
    End Function
    Public Function getDisbursetatusMargin_withdraw(ByVal bill_id As Integer) As Integer
        Dim digit As Integer = 0
        Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL_MARGIN_DETAIL
        dao_bill.Getdata_by_Disburse_id(bill_id)
        If dao_bill.fields.IS_CHECK_RECEIVE = True Then 'รอกรอกใบแจ้งหนี้
            digit = 4
        ElseIf dao_bill.fields.IS_CHECK_READY = True Then 'รอกรอกใบแจ้งหนี้
            digit = 3
        ElseIf dao_bill.fields.CHECK_APPROVE = True Then 'รอกรอกใบแจ้งหนี้
            digit = 2
        ElseIf dao_bill.fields.CHECK_NUMBER <> "" Then 'รอกรอกใบแจ้งหนี้
            digit = 1
        ElseIf dao_bill.fields.CHECK_NUMBER = "" And dao_bill.fields.CHECK_NUMBER Is Nothing Then 'รอกรอกบก.
            digit = 0
        End If
        Return digit
    End Function

    Public Function getDebtorstatusMargin_cash(ByVal bill_id As Integer) As Integer
        Dim digit As Integer = 0
        Dim dao_bill As New DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL
        dao_bill.Getdata_by_DEBTOR_BILL_ID(bill_id)
        If dao_bill.fields.IS_PAY = True Then 'รอกรอกใบแจ้งหนี้
            digit = 2
            TextStatus = "เสร็จสิ้น"
        ElseIf dao_bill.fields.IS_CHECK_READY = True Then 'รอกรอกใบแจ้งหนี้
            digit = 1
            TextStatus = "รอบันทึกการจ่าย"
        ElseIf dao_bill.fields.IS_CHECK_READY <> True Then 'รอกรอกใบแจ้งหนี้
            digit = 0
            TextStatus = "รออนุมัติพร้อมจ่าย"
        End If
        Return digit
    End Function
    Public Function getBillstatusMargin_cash(ByVal bill_id As Integer) As Integer
        Dim digit As Integer = 0
        Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL_MARGIN_DETAIL
        dao_bill.Getdata_by_Disburse_id(bill_id)
        If dao_bill.fields.IS_PAY = True Then 'รอกรอกใบแจ้งหนี้
            digit = 2
            TextStatus = "เสร็จสิ้น"
        ElseIf dao_bill.fields.IS_CHECK_READY = True Then 'รอกรอกใบแจ้งหนี้
            digit = 1
            TextStatus = "รอบันทึกการจ่าย"
        ElseIf dao_bill.fields.IS_CHECK_READY <> True Then 'รอกรอกใบแจ้งหนี้
            digit = 0
            TextStatus = "รออนุมัติพร้อมจ่าย"
        End If
        Return digit
    End Function
    Public Function getDisbursestatusMargin_cash(ByVal bill_id As Integer) As Integer
        Dim digit As Integer = 0
        Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL_MARGIN_DETAIL
        dao_bill.Getdata_by_Disburse_id(bill_id)
        If dao_bill.fields.IS_PAY = True Then
            digit = 1
            TextStatus = "เสร็จสิ้น"
        ElseIf dao_bill.fields.IS_PAY <> True Then
            digit = 0
            TextStatus = "รอบันทึกการจ่าย"
        End If
        Return digit
    End Function

    Public Function getCure_Study_Status(ByVal bill_id As Integer) As Integer
        Dim digit As Integer = 0
        Dim dao_bill As New DAO_DISBURSE.TB_CURE_STUDY
        dao_bill.Getdata_by_CURE_STUDY_ID(bill_id)
        'If dao_bill.fields.IS_CHECK_RECEIVE = True Then
        '    digit = 5
        'ElseIf dao_bill.fields.IS_CHECK_READY = True Then
        '    digit = 4
        'ElseIf dao_bill.fields.CHECK_APPROVE = True Then 'รอกรอกใบแจ้งหนี้
        '    digit = 3
        'ElseIf dao_bill.fields.CHECK_NUMBER <> "" Then
        '    digit = 2
        'ElseIf dao_bill.fields.RETURN_APPROVE_NUMBER <> "" Then
        '    digit = 1
        'ElseIf dao_bill.fields.RETURN_APPROVE_NUMBER = "" Then
        '    digit = 0
        'End If
        'Return digit
        If dao_bill.fields.IS_CHECK_RECEIVE = True Then 'รอกรอกใบแจ้งหนี้
            digit = 5
        ElseIf dao_bill.fields.IS_CHECK_READY = True Then 'รอกรอกใบแจ้งหนี้
            digit = 4
        ElseIf dao_bill.fields.RETURN_APPROVE_NUMBER <> "" Then 'รอกรอกใบแจ้งหนี้
            digit = 3
        ElseIf dao_bill.fields.CHECK_APPROVE = True Then 'รอกรอกใบแจ้งหนี้
            digit = 2
        ElseIf dao_bill.fields.CHECK_NUMBER <> "" Then 'รอกรอกบก.
            digit = 1
        ElseIf dao_bill.fields.CHECK_NUMBER = "" Then 'รอกรอกบก.
            digit = 0
        End If
        Return digit
    End Function

    Public Sub filter_rg(ByRef rg As RadGrid, ByVal strMsg As String)
        rg.EnableLinqExpressions = False
        rg.MasterTableView.FilterExpression = strMsg
        rg.MasterTableView.Rebind()
    End Sub

    Public Function getAdjust_Amount(ByVal bg_id As Integer, ByVal bgyear As Integer) As Double
        Dim value As Double = 0
        Dim bao As New BAO_BUDGET.Budget
        value = bao.get_bg_adjust_detail_amount(bgyear, bg_id)
        Return value
    End Function

    Public Function getAdjust_Appr_Amount(ByVal bg_id As Integer, ByVal dept_id As Integer, ByVal bgyear As Integer, ByVal appr As String) As Double
        Dim value As Double = 0
        Dim bao As New BAO_BUDGET.Budget
        value = bao.get_Adjust_App_Amount(bg_id, bgyear, appr, dept_id)
        Return value
    End Function
    'get_Adjust_debt_App_Amount
    Public Function get_Adjust_debt_App_Amount(ByVal bg_id As Integer, ByVal dept_id As Integer, ByVal bgyear As Integer, ByVal appr As String) As Double
        Dim value As Double = 0
        Dim bao As New BAO_BUDGET.Budget
        value = bao.get_Adjust_App_Amount(bg_id, bgyear, appr, dept_id)
        Return value
    End Function
    Public Function chk_dbnull_date(strDate As String) As String
        Dim date_return As String = "-"
        If strDate = "" Then
            date_return = CDate(strDate).ToString()
        End If

        Return date_return
    End Function

    Public Function return_status_bill(ByVal bill_id As Integer) As Integer
        Dim id_stat As Integer = 0
        Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        Dim dao_deatail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        dao_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(bill_id)
        dao_deatail.Getdata_by_Disburse_id(bill_id)
        If dao_bill.fields.BUDGET_DISBURSE_BILL_ID <> Nothing Then
            If dao_bill.fields.BILL_NUMBER = "" Then
                TextStatus = "รอบันทึกรับเรื่อง"
                id_stat = 1
            End If
            If dao_bill.fields.BILL_NUMBER <> "" Then
                TextStatus = "รออนุมัติเบิกจ่าย"
                id_stat = 2
            End If
            If dao_bill.fields.IS_APPROVE = True Then
                TextStatus = "รอบันทึกขบ."
                id_stat = 3
            End If

            If dao_bill.fields.PAY_TYPE_ID IsNot Nothing Then
                If dao_bill.fields.PAY_TYPE_ID = 1 Then
                    If dao_bill.fields.GFMIS_NUMBER <> "" Then
                        TextStatus = "รอบันทึกบก.อนุมัติ"
                        id_stat = 4
                    End If
                    If dao_bill.fields.RETURN_APPROVE_NUMBER <> "" Then
                        TextStatus = "รอบันทึกใบแจ้งหนี้"
                        id_stat = 5
                    End If
                    If dao_bill.fields.INVOICES_NUMBER <> "" Then
                        TextStatus = "รอบันทึกใบกำกับภาษี"
                        id_stat = 6
                    End If
                    If dao_bill.fields.TAX_NUMBER <> "" Then
                        TextStatus = "รอบันทึกเลขที่ใบเสร็จ"
                        id_stat = 7
                        If dao_bill.fields.RECEIPT_NUMBER <> "" Then
                            TextStatus = "เสร็จสิ้น(จ่ายตรง)"
                            id_stat = 8
                        End If
                    End If
                Else

                    If dao_bill.fields.GFMIS_NUMBER <> "" Then
                        TextStatus = "รอบันทึกเลขเช็ค"
                        id_stat = 9
                    End If
                    If dao_bill.fields.CHECK_NUMBER <> "" Then
                        TextStatus = "รอการรับเช็ค"
                        id_stat = 10
                    End If
                    If dao_bill.fields.CHECK_APPROVE = True Then
                        TextStatus = "รอบันทึกบก.อนุมัติ"
                        id_stat = 11
                    End If
                    If dao_bill.fields.RETURN_APPROVE_NUMBER <> "" Then
                        TextStatus = "รอการอนุมัติเช็ค"
                        id_stat = 12
                    End If
                    If dao_bill.fields.IS_CHECK_READY <> True Then
                        TextStatus = "รอบันทึกการจ่าย"
                        id_stat = 13
                    End If
                    If dao_bill.fields.IS_CHECK_RECEIVE = True Then
                        TextStatus = "เสร็จสิ้น(จ่ายผ่าน)"
                        id_stat = 14
                    End If
                End If

            End If

        End If

        Return id_stat
    End Function

    Public Function return_status_PO_bill(ByVal bill_id As Integer) As Integer
        Dim id_stat As Integer = 0
        Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        Dim dao_deatail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        dao_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(bill_id)
        dao_deatail.Getdata_by_Disburse_id(bill_id)
        If dao_bill.fields.PO_HEAD_ID Is Nothing Then
            If dao_bill.fields.IS_APPROVE <> True Then
                TextStatus = "รออนุมัติใบ PO"
                id_stat = 1
            End If
            If dao_bill.fields.IS_APPROVE = True Then
                TextStatus = "ใบ PO พร้อมเบิก"
                id_stat = 2
            End If
        Else
            If dao_bill.fields.BILL_NUMBER = "" Then
                TextStatus = "รอบันทึกรับเรื่อง"
                id_stat = 3
            End If
            If dao_bill.fields.BILL_NUMBER <> "" Then
                TextStatus = "รออนุมัติเบิกใบ PO"
                id_stat = 4
            End If
            If dao_bill.fields.IS_APPROVE = True Then
                TextStatus = "รอบันทึกขบ."
                id_stat = 5
            End If
            If dao_bill.fields.PAY_TYPE_ID IsNot Nothing Then
                If dao_bill.fields.PAY_TYPE_ID = 1 Then
                    If dao_bill.fields.GFMIS_NUMBER <> "" Then
                        TextStatus = "รอบันทึกบก.อนุมัติ"
                        id_stat = 6
                    End If
                    If dao_bill.fields.RETURN_APPROVE_NUMBER <> "" Then
                        TextStatus = "รอบันทึกใบแจ้งหนี้"
                        id_stat = 7
                    End If
                    If dao_bill.fields.INVOICES_NUMBER <> "" Then
                        TextStatus = "รอบันทึกใบกำกับภาษี"
                        id_stat = 8
                    End If
                    If dao_bill.fields.TAX_NUMBER <> "" Then
                        TextStatus = "รอบันทึกเลขที่ใบเสร็จ"
                        id_stat = 9
                        If dao_bill.fields.RECEIPT_NUMBER <> "" Then
                            TextStatus = "เสร็จสิ้น(จ่ายตรง)"
                            id_stat = 10
                        End If
                    End If
                End If
            End If
        End If

        Return id_stat
    End Function
    Public Function return_status_debtor(ByVal debtor_id As Integer) As Integer
        Dim id_stat As Integer = 0
        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
        Dim dao_margin_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL
        Dim dao_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
        dao.Getdata_by_DEBTOR_BILL_ID(debtor_id)
        dao_margin_detail.Getdata_by_DEBTOR_BILL_ID(debtor_id)
        dao_detail.Getdata_by_DEBTOR_BILL_ID(debtor_id)

        If dao.fields.DEBTOR_BILL_ID <> Nothing Then
            If dao.fields.BILL_NUMBER = "" Then
                TextStatus = "รอบันทึกรับเรื่อง"
                id_stat = 1
            End If
            If dao.fields.BILL_NUMBER <> "" Then
                If dao.fields.IS_APPROVE <> True Or dao.fields.IS_APPROVE Is Nothing Then
                    TextStatus = "รออนุมัติเงินยืม"
                    id_stat = 2
                End If
            End If
            If dao.fields.IS_APPROVE = True Then
                TextStatus = "รอบันทึกขบ."
                id_stat = 3
            End If
            If dao.fields.DEBTOR_TYPE_ID IsNot Nothing Or dao.fields.DEBTOR_TYPE_ID <> 0 Then
                Dim debt_type As Integer = dao.fields.DEBTOR_TYPE_ID
                Select Case debt_type
                    Case 2
                        If dao.fields.GFMIS_NUMBER <> "" Then
                            TextStatus = "รอบันทึกเลขที่เช็ค"
                            id_stat = 4
                            If dao.fields.CHECK_NUMBER <> "" Then
                                TextStatus = "รอการรับเช็ค"
                                id_stat = 5
                            End If
                            If dao.fields.CHECK_APPROVE = True Then
                                TextStatus = "รอบันทึกบก.อนุมัติ"
                                id_stat = 6
                            End If
                            If dao.fields.RETURN_APPROVE_NUMBER <> "" Then
                                TextStatus = "รออนุมัติพร้อมจ่าย"
                                id_stat = 7
                            End If
                            If dao.fields.IS_CHECK_READY = True Then
                                TextStatus = "รอบันทึกการจ่าย"
                                id_stat = 8
                            End If
                            If dao.fields.IS_CHECK_RECEIVE = True Then
                                TextStatus = "เสร็จสิ้น"
                                id_stat = 9
                            End If
                        End If
                    Case 1
                        If dao.fields.EXPRESS_TYPE_ID <> 0 Or dao.fields.EXPRESS_TYPE_ID IsNot Nothing Then
                            Dim ex_type As Integer = dao.fields.EXPRESS_TYPE_ID
                            If ex_type = 1 Then
                                If dao.fields.IS_APPROVE = True Then
                                    TextStatus = "รอบันทึกการจ่ายเงิน"
                                    id_stat = 10
                                End If
                                If dao_margin_detail.fields.IS_PAY = True Then
                                    TextStatus = "เสร็จสิ้น"
                                    id_stat = 11
                                End If
                            Else

                                If dao.fields.IS_APPROVE = True Then
                                    TextStatus = "รอบันทึกเลขที่เช็ค"
                                    id_stat = 12
                                    If dao_margin_detail.fields.CHECK_NUMBER <> "" Then
                                        TextStatus = "รอการรับเช็ค"
                                        id_stat = 13
                                    End If
                                    If dao_margin_detail.fields.CHECK_APPROVE = True Then
                                        TextStatus = "รออนุมัติพร้อมจ่าย"
                                        id_stat = 14
                                    End If
                                    If dao_margin_detail.fields.IS_CHECK_READY = True Then
                                        TextStatus = "รอบันทึกการจ่าย"
                                        id_stat = 15
                                    End If
                                    If dao_margin_detail.fields.IS_CHECK_RECEIVE = True Then
                                        TextStatus = "เสร็จสิ้น"
                                        id_stat = 16
                                    End If
                                End If

                            End If

                        End If
                End Select

            End If



        End If

        Return id_stat
    End Function

    Public Function return_status_return_money(ByVal debtor_id As Integer) As Integer
        Dim id_stat As Integer = 0
        Dim bao_return_Amount As New BAO_BUDGET.MASS
        Dim return_Amount As Double = bao_return_Amount.get_debtor_return_amount(debtor_id)

        Dim dao_return As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
        Dim dao_margin_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL
        Dim dao_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
        Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        dao.Getdata_by_DEBTOR_BILL_ID(debtor_id)
        dao_margin_detail.Getdata_by_DEBTOR_BILL_ID(debtor_id)
        dao_detail.Getdata_by_DEBTOR_BILL_ID(debtor_id)
        dao_return.Getdata_by_return_type_1(debtor_id)
        Dim digit As Integer = 0
        If dao.fields.DEBTOR_BILL_ID <> Nothing Then
            If dao.fields.DEBTOR_TYPE_ID IsNot Nothing Or dao.fields.DEBTOR_TYPE_ID <> 0 Then
                If dao.fields.DEBTOR_TYPE_ID = 2 Then
                    If return_Amount = 0 Or return_Amount < dao_detail.fields.AMOUNT Then
                        id_stat = 1
                        TextStatus = "ยังไม่ได้คินเงิน"
                    ElseIf return_Amount = dao_detail.fields.AMOUNT Then
                        id_stat = 2
                        TextStatus = "คืนเงินครบแล้ว"
                    End If
                End If

                If dao.fields.DEBTOR_TYPE_ID = 1 Then
                    If return_Amount = 0 Or return_Amount < dao_margin_detail.fields.AMOUNT Then
                        id_stat = 1
                        TextStatus = "ยังไม่ได้คินเงิน"
                    ElseIf return_Amount = dao_margin_detail.fields.AMOUNT Then
                        If dao.fields.REBILL_ID = 2 Then
                            dao_return.Getdata_by_return_type_1(debtor_id)
                            digit = dao_bill.chk_no_rebill(dao_return.fields.RETURN_MONEY_DEBTOR_ID)

                            If digit = 0 Then
                                id_stat = 3
                                TextStatus = "รอโอนคืนใบสำคัญไม่วางเบิก"
                            Else

                                If dao_bill.fields.BILL_NUMBER = "" Then
                                    id_stat = 4
                                    TextStatus = "รอรับเรื่องโอนคืนใบสำคัญไม่วางเบิก"
                                End If
                                If dao_bill.fields.BILL_NUMBER <> "" Then
                                    TextStatus = "รออนุมัติโอนคืนใบสำคัญไม่วางเบิก"
                                    id_stat = 5
                                End If
                                If dao_bill.fields.IS_APPROVE = True Then
                                    TextStatus = "รอบันทึกขบ. โอนคืนใบสำคัญไม่วางเบิก"
                                    id_stat = 6
                                End If
                                If dao_bill.fields.GFMIS_NUMBER <> "" Then
                                    TextStatus = "รอบันทึกเลขเช็ค โอนคืนใบสำคัญไม่วางเบิก"
                                    id_stat = 7
                                End If
                                If dao_bill.fields.CHECK_NUMBER <> "" Then
                                    TextStatus = "รอการรับเช็ค โอนคืนใบสำคัญไม่วางเบิก"
                                    id_stat = 8
                                End If
                                If dao_bill.fields.CHECK_APPROVE = True Then
                                    TextStatus = "รอบันทึกบก.อนุมัติ โอนคืนใบสำคัญไม่วางเบิก"
                                    id_stat = 9
                                End If
                                If dao_bill.fields.RETURN_APPROVE_NUMBER <> "" Then
                                    TextStatus = "รอบันทึกวันโอน โอนคืนใบสำคัญไม่วางเบิก"
                                    id_stat = 10
                                End If

                                If dao_return.fields.MOVEDATE IsNot Nothing Then
                                    TextStatus = "โอนคืนใบสำคัญไม่วางเบิกเสร็จสิ้น(จ่ายผ่าน)"
                                    id_stat = 11
                                End If
                            End If

                        ElseIf dao.fields.REBILL_ID = 1 Then
                            'dao_return.Getdata_by_return_type_1(debtor_id)
                            digit = dao_bill.chk_rebill(debtor_id)
                            If digit = 0 Then

                                id_stat = 12
                                TextStatus = "รอโอนคืนใบสำคัญวางเบิก"
                            Else
                                If dao_bill.fields.BILL_NUMBER <> "" Then
                                    TextStatus = "รออนุมัติโอนคืนใบสำคัญวางเบิก"
                                    id_stat = 13
                                End If
                                If dao_bill.fields.IS_APPROVE = True Then
                                    TextStatus = "รอบันทึกขบ. โอนคืนใบสำคัญวางเบิก"
                                    id_stat = 14
                                End If
                                If dao_bill.fields.GFMIS_NUMBER <> "" Then
                                    TextStatus = "รอบันทึกเลขเช็ค โอนคืนใบสำคัญวางเบิก"
                                    id_stat = 15
                                End If
                                If dao_bill.fields.CHECK_NUMBER <> "" Then
                                    TextStatus = "รอการรับเช็ค โอนคืนใบสำคัญวางเบิก"
                                    id_stat = 16
                                End If
                                If dao_bill.fields.CHECK_APPROVE = True Then
                                    TextStatus = "รอบันทึกบก.อนุมัติ โอนคืนใบสำคัญวางเบิก"
                                    id_stat = 17
                                End If
                                If dao_bill.fields.RETURN_APPROVE_NUMBER <> "" Then
                                    TextStatus = "รอบันทึกวันโอน โอนคืนใบสำคัญวางเบิก"
                                    id_stat = 18
                                End If

                                If dao.fields.MOVEDATE IsNot Nothing Then
                                    TextStatus = "โอนคืนใบสำคัญวางเบิกเสร็จสิ้น(จ่ายผ่าน)"
                                    id_stat = 19
                                End If
                            End If

                        End If

                    End If
                End If
            End If
        End If
        Return id_stat
    End Function
    Public Function get_url_return(ByVal stat_id As Integer, ByVal debt_id As Integer, ByVal bgYear As Integer) As String

        Dim BAO As New Get_All_ID_DEBTOR
        BAO.GetAllID(debt_id)

        Dim dao_deb_bill As New DAO_DISBURSE.TB_DEBTOR_BILL
        Dim url As String = ""
        dao_deb_bill.Getdata_by_DEBTOR_BILL_ID(debt_id)
        Dim dao_return As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
        dao_return.Getdata_by_return_type_1(debt_id)

        Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        Dim bill_id As Integer = 0
        If dao_return.fields.RETURN_MONEY_DEBTOR_ID <> 0 Then
            If dao_deb_bill.fields.REBILL_ID = 2 Then
                dao_bill.Getdata_no_rebill(dao_return.fields.RETURN_MONEY_DEBTOR_ID)
                bill_id = dao_bill.fields.BUDGET_DISBURSE_BILL_ID
            ElseIf dao_deb_bill.fields.REBILL_ID = 1 Then
                dao_bill.Getdata_rebill(debt_id)
                bill_id = dao_bill.fields.BUDGET_DISBURSE_BILL_ID
            End If

        End If

        Dim bao_return_Amount As New BAO_BUDGET.MASS
        Dim return_Amount As Double = bao_return_Amount.get_debtor_return_amount(debt_id)
        Select Case stat_id
            Case 1

                url = "Module03/Frm_Maintain_ReturnMoney_Debtor_Insert.aspx?DEBTOR_BILL_ID=" & BAO.ID_BILL
            Case 2
                url = "Module03/Frm_Maintain_ReturnMoney_Debtor_Insert.aspx?DEBTOR_BILL_ID=" & BAO.ID_BILL
            Case 3
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_No_Rebill_Add.aspx?bgyear=" & bgYear
            Case 4
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_Receive_Edit.aspx?bid=" & bill_id & "&bgid=" & dao_deb_bill.fields.BUDGET_PLAN_ID & "&bgYear=" & dao_deb_bill.fields.BUDGET_YEAR
            Case 5
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_Approve_Status.aspx?bid=" & bill_id
            Case 6
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_Bill_Insert_Detail.aspx?bid=" & bill_id & "&debt=1"
            Case 7
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Rebill_PayType_Pass_Edit.aspx?bid=" & bill_id & "&norebill=1"
            Case 8
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Rebill_PayType_Pass_Edit.aspx?bid=" & bill_id & "&norebill=1"
            Case 9
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Rebill_PayType_Pass_Edit.aspx?bid=" & bill_id & "&norebill=1"
            Case 10
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Rebill_PayType_Pass_Edit.aspx?bid=" & bill_id & "&norebill=1"
            Case 11
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Rebill_PayType_Pass_Edit.aspx?bid=" & bill_id & "&norebill=1"
            Case 12
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Rebill_Add.aspx?bgyear=" & bgYear
            Case 13
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_Approve_Status.aspx?bid=" & bill_id
            Case 14
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_Bill_Insert_Detail.aspx?bid=" & bill_id & "&debt=1"
            Case 15
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Rebill_PayType_Pass_Edit.aspx?bid=" & bill_id
            Case 16
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Rebill_PayType_Pass_Edit.aspx?bid=" & bill_id
            Case 17
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Rebill_PayType_Pass_Edit.aspx?bid=" & bill_id
            Case 18
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Rebill_PayType_Pass_Edit.aspx?bid=" & bill_id
            Case 19
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Rebill_PayType_Pass_Edit.aspx?bid=" & bill_id
        End Select

        Return url
    End Function

    Public Function get_url_debtor(ByVal stat_id As Integer, ByVal debt_id As Integer) As String

        Dim BAO As New Get_All_ID_DEBTOR
        BAO.GetAllID(debt_id)

        Dim dao_deb_bill As New DAO_DISBURSE.TB_DEBTOR_BILL
        Dim url As String = ""
        Select Case stat_id
            Case 1
                dao_deb_bill.Getdata_by_DEBTOR_BILL_ID(debt_id)
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Receive_Edit.aspx?bid=" & _
                    BAO.ID_BILL & "&bgid=" & dao_deb_bill.fields.BUDGET_PLAN_ID & "&bgYear=" & dao_deb_bill.fields.BUDGET_YEAR
            Case 2
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Approve_Detail.aspx?bid=" & BAO.ID_BILL
            Case 3
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Bill_Insert_Detail.aspx?bid=" & BAO.ID_BILL '& "&debt=" & dao_deb_bill.fields.DEPARTMENT_ID
            Case 4
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Add_Status_Detail.aspx?bid=" & BAO.ID_BILL
            Case 5
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Add_Status_Detail.aspx?bid=" & BAO.ID_BILL
            Case 6
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Add_Status_Detail.aspx?bid=" & BAO.ID_BILL
            Case 7
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Add_Status_Detail.aspx?bid=" & BAO.ID_BILL
            Case 8
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Add_Status_Detail.aspx?bid=" & BAO.ID_BILL
            Case 9
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Add_Status_Detail.aspx?bid=" & BAO.ID_BILL

            Case 10
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Margin_Cash_Status_Add.aspx?bid=" & BAO.ID_BILL
            Case 11
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Margin_Cash_Status_Add.aspx?bid=" & BAO.ID_BILL

            Case 12
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Status_Add.aspx?bid=" & BAO.ID_BILL
            Case 13
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Status_Add.aspx?bid=" & BAO.ID_BILL
            Case 14
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Status_Add.aspx?bid=" & BAO.ID_BILL
            Case 15
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Status_Add.aspx?bid=" & BAO.ID_BILL
            Case 16
                url = "Module02/Disburse_Debtor/Frm_Disburse_Debtor_Status_Add.aspx?bid=" & BAO.ID_BILL
        End Select

        Return url
    End Function

    Public Function get_url_bill(ByVal stat_id As Integer, ByVal bill_id As Integer) As String
        Dim url As String = ""
        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
        dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(bill_id)
        Select Case stat_id
            Case 1
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_Receive_Edit.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID _
                    & "&bgid=" & dao.fields.BUDGET_PLAN_ID & "&bgYear=" & dao.fields.BUDGET_YEAR
            Case 2
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_Approve_Status.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID 'อนุมัติ
            Case 3
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_Bill_Insert_Detail.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID
            Case 4
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Direct_Edit.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID
            Case 5
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Direct_Edit.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID
            Case 6
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Direct_Edit.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID
            Case 7
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Direct_Edit.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID
            Case 8
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Direct_Edit.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID
            Case 9
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Pass_Edit.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID
            Case 10
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Pass_Edit.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID
            Case 11
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Pass_Edit.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID
            Case 12
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Pass_Edit.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID
            Case 13
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Pass_Edit.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID
            Case 14
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Pass_Edit.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID
        End Select
        Return url
    End Function

    Public Function get_url_PO_bill(ByVal stat_id As Integer, ByVal bill_id As Integer) As String
        Dim url As String = ""
        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
        dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(bill_id)
        Select Case stat_id
            Case 1
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_Approve_Status.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID 'อนุมัติ

            Case 2
                url = "Module02/Disburse_Budget/Frm_Disburse_PO_List.aspx?id=" & dao.fields.BUDGET_DISBURSE_BILL_ID
            Case 3
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_Receive_Edit.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID _
                    & "&bgid=" & dao.fields.BUDGET_PLAN_ID & "&bgYear=" & dao.fields.BUDGET_YEAR
            Case 4
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_Approve_Status.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID & "&ispo=1" 'อนุมัติ
            Case 5
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_Bill_Insert_Detail.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID
            Case 6
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Direct_Edit.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID
            Case 7
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Direct_Edit.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID
            Case 8
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Direct_Edit.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID
            Case 9
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Direct_Edit.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID
            Case 10
                url = "Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Direct_Edit.aspx?bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID

        End Select
        Return url
    End Function
    Public Function get_title_name(ByVal aspx As String) As String
        Dim strTitle As String = ""
        'Dim d As String() = Request.Url.Segments
        'Dim b As String = d(Request.Url.Segments.Length - 1)
        Dim dao As New DAO_MAS.TB_MAS_MENU
        dao.getData_menu_name_by_page_name(aspx)

        If dao.fields.MENU_NAME IsNot Nothing Then
            strTitle = dao.fields.MENU_NAME
        End If
        Return strTitle
    End Function

    'If dao.fields.DEBTOR_TYPE_ID IsNot Nothing Then
    '        If dao.fields.DEBTOR_TYPE_ID = 2 Then
    '            If (dao.fields.RETURN_APPROVE_NUMBER <> "" Or dao.fields.RETURN_APPROVE_NUMBER IsNot Nothing) _
    '                And (dao.fields.IS_CHECK_RECEIVE = False Or dao.fields.IS_CHECK_RECEIVE Is Nothing) Then
    '                str_stat = "เช็คพร้อมจ่าย"
    '            ElseIf (dao.fields.RETURN_APPROVE_NUMBER <> "" Or dao.fields.RETURN_APPROVE_NUMBER IsNot Nothing) _
    '            And (dao.fields.IS_CHECK_RECEIVE = True) Then
    '                str_stat = "รับเช็คแล้ว"
    '            End If
    '        ElseIf dao.fields.DEBTOR_TYPE_ID = 1 Then
    '            If dao.fields.EXPRESS_TYPE_ID = 1 Then
    '                If dao.fields.IS_APPROVE = True And (dao_margin_detail.fields.IS_PAY = False Or dao_margin_detail.fields.IS_PAY Is Nothing) Then
    '                    str_stat = "เงินสดพร้อมจ่าย"
    '                ElseIf dao.fields.IS_APPROVE = True And dao_margin_detail.fields.IS_PAY = True Then
    '                    str_stat = "รับเงินสดแล้ว"
    '                End If
    '            ElseIf dao.fields.EXPRESS_TYPE_ID = 2 Then
    '                If dao_margin_detail.fields.CHECK_APPROVE = True And (dao_margin_detail.fields.IS_CHECK_RECEIVE = False Or dao_margin_detail.fields.IS_CHECK_RECEIVE Is Nothing) Then
    '                    str_stat = "เช็คพร้อมจ่าย"
    '                ElseIf dao_margin_detail.fields.CHECK_APPROVE = True And dao_margin_detail.fields.IS_CHECK_RECEIVE = True Then
    '                    str_stat = "รับเช็คแล้ว"
    '                End If
    '            End If
    '        End If
    '    End If

    ' End If

End Class
Public Class Report_Utility

    Private _root As String
    Public Property root() As String
        Get
            Return _root
        End Get
        Set(ByVal value As String)
            _root = value
        End Set
    End Property
    ''' <summary>
    ''' Get Path Report
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        _root = Global.System.Configuration.ConfigurationManager.AppSettings("paths")
    End Sub
    ''' <summary>
    ''' Function สร้างรายงาน
    ''' </summary>
    ''' <param name="report">ชื่อ ReportViewer</param>
    ''' <param name="reportPath">ที่วางไฟล์ Report.rdlc</param>
    ''' <param name="reportDataSource">ชื่อ DataSource ใน Report</param>
    ''' <param name="dt">ตารางข้อมูลรายงาน</param>
    ''' <remarks></remarks>
    Public Sub ShowReport(ByVal report As ReportViewer, ByVal reportPath As String, ByVal reportDataSource As String, ByVal dt As DataTable)
        report.LocalReport.ReportPath = reportPath
        report.LocalReport.EnableExternalImages = True
        report.LocalReport.DataSources.Clear()
        'report.LocalReport.DataSources.Add(New Microsoft.Reporting.WebForms.ReportDataSource("Fields_Report_R2_001", getReportData()))
        Dim rds As New ReportDataSource(reportDataSource, dt)
        report.LocalReport.DataSources.Add(rds)
        report.LocalReport.Refresh()
        report.DataBind()
    End Sub
    ''' <summary>
    ''' ตัวแปรรับ ReportViewer ที่ส่งมา
    ''' </summary>
    ''' <remarks></remarks>
    Public report As ReportViewer
    ''' <summary>
    ''' Function กำหนดขนาดของ ReportViewer
    ''' </summary>
    ''' <param name="width">ความกว้าง</param>
    ''' <param name="height">ความสูง</param>
    ''' <remarks></remarks>
    Public Sub configWidthHeight(Optional ByVal width As Integer = 1600, Optional ByVal height As Integer = 600)
        report.Width = width 'กำหนดความกว้าง
        report.Height = height 'กำหนดความสูง
    End Sub

    Public Function get_short_month(date_ex As Date) As String
        Dim str_date As String = ""
        Dim str_month As String = ""
        Dim month_num As Integer = Month(date_ex)
        Dim get_day As Integer = date_ex.Day
        Dim get_year As Integer
        If date_ex.Year < 2500 Then
            get_year = date_ex.Year + 543
        End If

        Select Case month_num
            Case 1
                str_month = "ม.ค."
            Case 2
                str_month = "ก.พ."
            Case 3
                str_month = "มี.ค."
            Case 4
                str_month = "เม.ย."
            Case 5
                str_month = "พ.ค."
            Case 6
                str_month = "มิ.ย."
            Case 7
                str_month = "ก.ค."
            Case 8
                str_month = "ส.ค."
            Case 9
                str_month = "ก.ย."
            Case 10
                str_month = "ต.ค."
            Case 11
                str_month = "พ.ย."
            Case 12
                str_month = "ธ.ค."
        End Select
        str_date = get_day & " " & str_month & " " & get_year

        Return str_date
    End Function
    Public Function get_Long_month(date_ex As Date) As String
        Dim str_date As String = ""
        Dim str_month As String = ""
        Dim month_num As Integer = Month(date_ex)
        Dim get_day As Integer = date_ex.Day
        Dim get_year As Integer
        If date_ex.Year < 2500 Then
            get_year = date_ex.Year + 543
        End If

        Select Case month_num
            Case 1
                str_month = "มกราคม"
            Case 2
                str_month = "กุมภาพันธ์"
            Case 3
                str_month = "มีนาคม"
            Case 4
                str_month = "เมษายน"
            Case 5
                str_month = "พฤษภาคม"
            Case 6
                str_month = "มิถุนายน"
            Case 7
                str_month = "กรกฎาคม"
            Case 8
                str_month = "สิงหาคม"
            Case 9
                str_month = "กันยายน"
            Case 10
                str_month = "ตุลาคม"
            Case 11
                str_month = "พฤศจิกายน"
            Case 12
                str_month = "ธันวาคม"
        End Select
        str_date = get_day & " " & str_month & " " & get_year

        Return str_date
    End Function
    Public Function get_budget_month(month_ori As Integer) As Integer
        Dim month_digit As Integer = 0

        Select Case month_ori
            Case 10
                month_digit = 1
            Case 11
                month_digit = 2
            Case 12
                month_digit = 3
            Case 1
                month_digit = 4
            Case 2
                month_digit = 5
            Case 3
                month_digit = 6
            Case 4
                month_digit = 7
            Case 5
                month_digit = 8
            Case 6
                month_digit = 9
            Case 7
                month_digit = 10
            Case 8
                month_digit = 11
            Case 9
                month_digit = 12
        End Select

    End Function
    Public Function get_Long_month_BY_Number(ByVal month_num As Integer) As String
        Dim str_month As String = ""

        Select Case month_num
            Case 1
                str_month = "มกราคม"
            Case 2
                str_month = "กุมภาพันธ์"
            Case 3
                str_month = "มีนาคม"
            Case 4
                str_month = "เมษายน"
            Case 5
                str_month = "พฤษภาคม"
            Case 6
                str_month = "มิถุนายน"
            Case 7
                str_month = "กรกฎาคม"
            Case 8
                str_month = "สิงหาคม"
            Case 9
                str_month = "กันยายน"
            Case 10
                str_month = "ตุลาคม"
            Case 11
                str_month = "พฤศจิกายน"
            Case 12
                str_month = "ธันวาคม"
        End Select


        Return str_month
    End Function
End Class


Public Class Get_All_ID_DEBTOR
    Private _ID_BILL As Integer
    Public Property ID_BILL() As String
        Get
            Return _ID_BILL
        End Get
        Set(ByVal value As String)
            _ID_BILL = value
        End Set
    End Property


    Private _ID_BILL_DETAIL As Integer
    Public Property ID_BILL_DETAIL() As String
        Get
            Return _ID_BILL_DETAIL
        End Get
        Set(ByVal value As String)
            _ID_BILL_DETAIL = value
        End Set
    End Property


    Public Sub GetAllID(ByVal BillID As Integer)
        Set_BillID(BillID)

        Set_BillDetailID(_ID_BILL)
    End Sub

    Private Sub Set_BillID(ByVal BillID As Integer)
        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
        dao.Getdata_by_DEBTOR_BILL_ID(BillID)

        _ID_BILL = dao.fields.DEBTOR_BILL_ID

    End Sub


    Private Sub Set_BillDetailID(ByVal BillID As Integer)
        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
        dao.Getdata_by_DEBTOR_BILL_ID(BillID)

        _ID_BILL_DETAIL = dao.fields.DEBTOR_BILL_DETAIL_ID
    End Sub

End Class
