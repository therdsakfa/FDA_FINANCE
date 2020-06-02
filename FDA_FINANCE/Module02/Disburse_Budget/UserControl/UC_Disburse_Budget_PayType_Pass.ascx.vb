Imports Telerik.Web.UI
Partial Public Class UC_Disburse_Budget_PayType_Pass
    Inherits System.Web.UI.UserControl
    Private _PAY_TYPE_ID As Integer
    Public Property PAY_TYPE_ID() As Integer
        Get
            Return _PAY_TYPE_ID
        End Get
        Set(ByVal value As Integer)
            _PAY_TYPE_ID = value
        End Set
    End Property
    Private _digit As Integer
    Public Property digit() As Integer
        Get
            Return _digit
        End Get
        Set(ByVal value As Integer)
            _digit = value
        End Set
    End Property
    Private _bg_use As String
    Public Property bg_use() As String
        Get
            Return _bg_use
        End Get
        Set(ByVal value As String)
            _bg_use = value
        End Set
    End Property

    Private _bgyear As Integer
    Public Property bgyear() As Integer
        Get
            Return _bgyear
        End Get
        Set(ByVal value As Integer)
            _bgyear = value
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgPayPass_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgPayPass.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgPayPass
        Rad_Utility.addColumnIMG("img", "")
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "DOC_NUMBER", False)
        Rad_Utility.addColumnDate("Bill_RECIEVE_DATE", "Bill_RECIEVE_DATE", False)
        Rad_Utility.addColumnDate("DOC_DATE", "DOC_DATE", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข ขบ.")
        Rad_Utility.addColumnBound("CHECK_NUMBER", "เลขที่เช็ค")
        Rad_Utility.addColumnDate("CHECK_DATE", "วันที่เช็ค")
        Rad_Utility.addColumnCheckbox("CHECK_APPROVE", "สถานะเช็คลงนาม")
        Rad_Utility.addColumnDate("CHECK_APPROVE_DATE", "วันที่ลงนามเช็ค")
        Rad_Utility.addColumnBound("RETURN_APPROVE_NUMBER", "เลขปลดจ่าย")
        Rad_Utility.addColumnDate("RETURN_APPROVE_DATE", "วันที่บันทึกเลขปลดจ่าย")
        Rad_Utility.addColumnCheckbox("IS_CHECK_READY", "เช็คพร้อมจ่าย")
        Rad_Utility.addColumnDate("CHECK_READY_DATE", "วันที่พร้อมจ่ายเช็ค")
        Rad_Utility.addColumnCheckbox("IS_CHECK_RECEIVE", "สถานะการจ่าย")
        Rad_Utility.addColumnDate("CHECK_RECEIVE_DATE", "วันที่จ่าย")
        Rad_Utility.addColumnBound("digit", "สถานะ", False)
        Rad_Utility.addColumnButton("S", "เพิ่ม/แก้ไขข้อมูล", "S", 0, "", headertext:="สถานะ")

    End Sub

    Private Sub rgPayPass_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgPayPass.ItemCommand
        'If TypeOf e.Item Is GridDataItem Then
        '    Dim item As GridDataItem = e.Item
        '    Select Case PAY_TYPE_ID
        '        Case 1
        '            If e.CommandName = "S" Then
        '                Response.Redirect("/Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Direct_Edit.aspx?bid=" & item("BUDGET_DISBURSE_BILL_ID").Text)
        '            End If
        '        Case 2
        '            If e.CommandName = "S" Then
        '                Response.Redirect("/Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Pass_Edit.aspx?bid=" & item("BUDGET_DISBURSE_BILL_ID").Text)
        '            End If
        '    End Select
        'End If
    End Sub

    Private Sub rgPayPass_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles rgPayPass.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim h2 As LinkButton = DirectCast(item("S").Controls(0), LinkButton)
           
            Dim id As Integer = item("BUDGET_DISBURSE_BILL_ID").Text
            Dim url As String = "../../Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Pass_Edit.aspx?bid=" & id
            Dim url_chk As String = "../../Module09/Report/Frm_Report_R9_001.aspx?id=" & id & "&flag=bill"

            'btn_chk.Attributes.Add("OnClick", "window.open('" & url_chk & "');")
            'OnClientClick = "window.open('../Train/01_train.aspx')"
            'btn_chk.PostBackUrl = url_chk
            h2.Attributes.Add("OnClick", "Popups('" & url & "'); return false;")
            Dim img As Image = DirectCast(item("img").Controls(0), Image)
            Dim uti_digit As New Utility_other
            Dim digit As Integer = uti_digit.getBillstatusPay_Pass(id)
            ' Dim linktype1 As String
            ' Dim linktype2 As String
            ' linktype1 = "/Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Direct_Edit.aspx?bid=" & id
            'linktype2 = "/Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Pass_Edit.aspx?bid=" & id
            If PAY_TYPE_ID = 1 Then
                'h2.PostBackUrl = linktype1
                Select Case digit
                    Case 4
                        h2.Text = "เสร็จสิ้น"
                    Case 3
                        h2.Text = "รอการพิจารณาวางเบิก"

                    Case 2
                        h2.Text = "รอรับเช็ค"

                    Case 1
                        h2.Text = "รออนุมัติเช็ค"

                    Case 0
                        h2.Text = "รอบันทึกเลขที่เช็ค"

                End Select
            ElseIf PAY_TYPE_ID = 2 Then
                'h2.PostBackUrl = linktype2
                Select Case digit
                    Case 5
                        h2.Text = "บันทึกข้อมูลครบถ้วน"
                    Case 4
                        h2.Text = "รอบันทึกการจ่าย"
                    Case 3
                        h2.Text = "รออนุมัติพร้อมจ่าย"

                    Case 2
                        h2.Text = "รอบันทึกเลขปลดจ่าย"

                    Case 1
                        h2.Text = "รอการรับเช็ค"

                    Case 0
                        h2.Text = "รอบันทึกเลขที่เช็ค"

                End Select

            End If



            If item("digit").Text = "บันทึกข้อมูลครบถ้วน" Then
                img.ImageUrl = "~/images/f6.png"
            ElseIf item("digit").Text = "รอบันทึกการจ่าย" Then
                img.ImageUrl = "~/images/f5.png"
            ElseIf item("digit").Text = "รออนุมัติพร้อมจ่าย" Then
                img.ImageUrl = "~/images/f4.png"
            ElseIf item("digit").Text = "รอบันทึกเลขปลดจ่าย" Then
                img.ImageUrl = "~/images/f3.png"
            ElseIf item("digit").Text = "รอการรับเช็ค" Then
                img.ImageUrl = "~/images/f2.png"
            ElseIf item("digit").Text = "รอบันทึกเลขที่เช็ค" Then
                img.ImageUrl = "~/images/f1.png"
                '
            End If
        End If
    End Sub

    Private Sub rgPayPass_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgPayPass.NeedDataSource
        Dim bao As New BAO_BUDGET.Budget
        Dim dt As DataTable '= bao.get_bill_all(PAY_TYPE_ID, bgyear, bg_use, ispo)

        If ispo <> "True" Then
            dt = bao.get_bill_all(PAY_TYPE_ID, bgyear, bg_use, ispo)
        Else
            dt = bao.get_bill_all_sub_po(PAY_TYPE_ID, bgyear, bg_use, ispo)
        End If

        Dim uti_digit As New Utility_other
        dt.Columns.Add("digit")
        For i As Integer = 0 To dt.Rows.Count - 1
            dt(i).Item("digit") = uti_digit.getBillstatusPay_Pass(dt(i).Item("BUDGET_DISBURSE_BILL_ID"))
        Next
        ' select_digit = "0"
        dt.Select("digit='" & digit & "'")

        Dim dv As New DataView(dt)
        dv.Sort = "digit ASC"
        dt = dv.ToTable
        For j As Integer = 0 To dt.Rows.Count - 1

            'If item("digit").Text = "บันทึกข้อมูลครบถ้วน" Then
            '    img.ImageUrl = "~/images/f6.png"
            'ElseIf item("digit").Text = "รอบันทึกการจ่าย" Then
            '    img.ImageUrl = "~/images/f5.png"
            'ElseIf item("digit").Text = "รอการอนุมัติเช็ค" Then
            '    img.ImageUrl = "~/images/f4.png"
            'ElseIf item("digit").Text = "รอบันทึกบก. อนุมัติ" Then
            '    img.ImageUrl = "~/images/f3.png"
            'ElseIf item("digit").Text = "รอการรับเช็ค" Then
            '    img.ImageUrl = "~/images/f2.png"
            'ElseIf item("digit").Text = "รอบันทึกเลขที่เช็ค" Then
            '    img.ImageUrl = "~/images/f1.png"
            Select Case dt(j).Item("digit")

                Case "0"  '
                    dt(j).Item("digit") = "รอบันทึกเลขที่เช็ค"

                    dt(j).Item("CHECK_DATE") = DBNull.Value
                    dt(j).Item("CHECK_APPROVE_DATE") = DBNull.Value
                    dt(j).Item("RETURN_APPROVE_DATE") = DBNull.Value
                    dt(j).Item("CHECK_READY_DATE") = DBNull.Value
                    dt(j).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                Case "1"
                    dt(j).Item("digit") = "รอการรับเช็ค"
                    dt(j).Item("CHECK_APPROVE_DATE") = DBNull.Value
                    dt(j).Item("RETURN_APPROVE_DATE") = DBNull.Value
                    dt(j).Item("CHECK_READY_DATE") = DBNull.Value
                    dt(j).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                Case "2"
                    dt(j).Item("digit") = "รอบันทึกเลขปลดจ่าย"
                    dt(j).Item("RETURN_APPROVE_DATE") = DBNull.Value
                    dt(j).Item("CHECK_READY_DATE") = DBNull.Value
                    dt(j).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                Case "3"
                    dt(j).Item("digit") = "รออนุมัติพร้อมจ่าย"
                    dt(j).Item("CHECK_READY_DATE") = DBNull.Value
                    dt(j).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                Case "4"
                    dt(j).Item("digit") = "รอบันทึกการจ่าย"
                    dt(j).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                Case "5"
                    dt(j).Item("digit") = "บันทึกข้อมูลครบถ้วน"
            End Select
        Next


        rgPayPass.DataSource = dt
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgPayPass, str)
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgPayPass)
        'rg_Disburse_Budget.Rebind()
    End Sub
    Public Sub rg_rebind()
        rgPayPass.Rebind()
    End Sub
    Public Sub rg_remove_column()
        For Each col As GridColumn In rgPayPass.Columns
            'col("GFMIS_NUMBER").Style.Add("display", "none")
            If col.UniqueName = "GFMIS_NUMBER" Then
                col.Display = False
            End If

        Next
    End Sub
End Class