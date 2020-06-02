Imports Telerik.Web.UI
Public Class UC_Disburse_Budget_withdraw_add_Part2
    Inherits System.Web.UI.UserControl

    Private _BudgetYear As Integer
    Public Property BudgetYear() As Integer
        Get
            Return _BudgetYear
        End Get
        Set(ByVal value As Integer)
            _BudgetYear = value
        End Set
    End Property

    Private _BID As Integer = 0
    Public Property BID() As Integer
        Get
            Return _BID
        End Get
        Set(ByVal value As Integer)
            _BID = value
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
    Private _dept_id As Integer
    Public Property dept_id() As Integer
        Get
            Return _dept_id
        End Get
        Set(ByVal value As Integer)
            _dept_id = value
        End Set
    End Property
    Private _Budget_Use_id As Integer
    Public Property Budget_Use_id() As Integer
        Get
            Return _Budget_Use_id
        End Get
        Set(ByVal value As Integer)
            _Budget_Use_id = value
        End Set
    End Property
    Private _is_insert As Boolean
    Public Property is_insert() As Boolean
        Get
            Return _is_insert
        End Get
        Set(ByVal value As Boolean)
            _is_insert = value
        End Set
    End Property
    Private _egp As Boolean
    Public Property egp() As Boolean
        Get
            Return _egp
        End Get
        Set(ByVal value As Boolean)
            _egp = value
        End Set
    End Property
    Private _stat_egp As Integer
    Public Property stat_egp() As Integer
        Get
            Return _stat_egp
        End Get
        Set(ByVal value As Integer)
            _stat_egp = value
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

    Private _Citizen As String
    Public Property Citizen() As String
        Get
            Return _Citizen
        End Get
        Set(ByVal value As String)
            _Citizen = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim get_id As Integer = 0
            get_id = _BID

            'Bind_Data()
        End If
    End Sub

    Private Sub rg_list_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_list.ItemDataBound

        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then

            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("DETAIL_ID").Text

            Dim ddl As RadComboBox = DirectCast(item("PurchaseItems").FindControl("ddl_PurchaseItems"), RadComboBox)

            Dim dt As New DataTable
            Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
            dt = bao.get_deka_budget_type_name_detail()

            'Dim dao As New DAO_MAS.TB_MAS_DEKA_DETAIL_BUDGET
            'dao.get_deka_budget_type_name_detail()

            ddl.DataSource = dt ' dao.datas
            ddl.DataTextField = "DETAIL_NAME"
            ddl.DataValueField = "IDA"
            ddl.DataBind()
            Dim r As New RadComboBoxItem
            r.Text = "--กรุณาเลือก--"
            r.Value = 0
            ddl.Items.Insert(0, r)


            Dim valueVat As Double = 0
            Dim valueMulct As Double = 0
            Dim valueInsurance As Double = 0

            'Dim txtVat As RadTextBox = DirectCast(item("nVat").FindControl("txtVat"), RadTextBox)
            'Dim txtMulct As RadTextBox = DirectCast(item("nMulct").FindControl("txtMulct"), RadTextBox)
            'Dim txtInsurance As RadTextBox = DirectCast(item("nInsurance").FindControl("txtInsurance"), RadTextBox)

            Dim nVat As RadNumericTextBox = item.FindControl("nVat")
            Dim nMulct As RadNumericTextBox = item.FindControl("nMulct")
            Dim nInsurance As RadNumericTextBox = item.FindControl("nInsurance")
            Dim nddl As RadComboBox = item.FindControl("ddl_PurchaseItems")

            Dim Amount As Double = 0
            Dim Before_Vat As Double = 0
            Dim After_Vat As Double = 0
            Dim PurchaseItems As Integer = 0

            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
            dao.Getdata_by_fk_and_DETAIL_ID(_BID, id)

            If item("PurchaseItemsId").Text <> 0 Then
                PurchaseItems = item("PurchaseItemsId").Text
            Else
                PurchaseItems = 0
            End If

            nddl.SelectedValue = PurchaseItems

            If item("TAX_TYPE").Text <> 0 Then

                '-----เพิ่มเงื่อนไขภาษี-------
                'บุคคลธรรมดา เบิกไม่เกิน 10,000 ไม่เก็บ 1% ถ้าเกินเก็บ 1%
                'นิติบุคคล เงินรับสุทธิ มากกว่าเท่ากับ 500 คิด 1%
                'สูตร xx * 1/107

                If item("TAX_TYPE").Text = 1 Or item("TAX_TYPE").Text = 5 Then 'นิติ vat 7%

                    If item("AMOUNT").Text <> 0 Then

                        'คิด 1% ยังไม่คิด 7%
                        Amount = item("AMOUNT").Text
                        Before_Vat = (Amount * 7) / 107

                        After_Vat = Amount - Before_Vat 'เงินสุทธิ

                        If After_Vat >= 500 Then
                            valueVat = Before_Vat
                        Else
                            valueVat = 0
                        End If
                    Else
                        valueVat = 0
                    End If

                ElseIf item("TAX_TYPE").Text = 2 Or item("TAX_TYPE").Text = 3 Then 'บุคคล

                    'If item("AMOUNT").Text <> 0 Then
                    '    valueVat = (item("AMOUNT").Text * 7) / 107
                    'Else
                    '    valueVat = 0
                    'End If
                    If item("AMOUNT").Text <> 0 Then
                        'คิด 1% 
                        Amount = item("AMOUNT").Text
                        Before_Vat = (Amount * 1) / 100
                        After_Vat = Amount - Before_Vat

                        If Amount >= 10000 Then
                            valueVat = Before_Vat
                        Else
                            valueVat = 0
                        End If
                    Else
                        valueVat = 0
                    End If

                ElseIf item("TAX_TYPE").Text = 6 Then 'นิติ ไม่ vat 7%

                    If item("AMOUNT").Text <> 0 Then
                        'คิด 1% 
                        Amount = item("AMOUNT").Text
                        Before_Vat = (Amount * 1) / 100

                        After_Vat = Amount - Before_Vat

                        If After_Vat >= 500 Then
                            valueVat = Before_Vat
                        Else
                            valueVat = 0
                        End If
                    Else
                        valueVat = 0
                    End If

                ElseIf item("TAX_TYPE").Text = 4 Then 'รัฐ
                    valueVat = 0
                Else
                    valueVat = 0
                End If

            Else
                valueVat = 0
            End If

            '------------ค่าปรับ----------------
            If IsDBNull(item("nMulct").Text) = False Then
                If item("nMulct").Text <> "" Then
                    valueMulct = item("nMulct").Text
                Else
                    valueMulct = 0
                End If
            Else
                valueMulct = 0
            End If

            If valueMulct <> 0 Then
                nMulct.Text = String.Format("{0:###,###.00}", valueMulct)
            Else
                nMulct.Text = 0
            End If

            '--------------ประกันผลงาน--------------
            If IsDBNull(item("nInsurance").Text) = False Then
                If item("nInsurance").Text <> "" Then
                    valueInsurance = item("nInsurance").Text
                Else
                    valueInsurance = 0
                End If
            Else
                valueInsurance = 0
            End If

            If valueInsurance <> 0 Then
                nInsurance.Text = String.Format("{0:###,###.00}", valueInsurance)
            Else
                nInsurance.Text = 0
            End If

            '------------ภาษี----------------
            If valueVat <> 0 Then
                nVat.Text = String.Format("{0:###,###.00}", valueVat)
            Else
                nVat.Text = 0
            End If


        End If
    End Sub



    '------------เจ้าหนี้-------------
    Protected Sub btn_CusSave_Click(sender As Object, e As EventArgs) Handles btn_CusSave.Click

        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As New DataTable

        dt = bao.get_relate_det_by_fkid(_BID)

        If dt.Rows.Count > 0 Then

            'Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DETAIL

            insert_detail()

            ' System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเจ้าหนี้เรียบร้อย');parent.$('#ctl00_ContentPlaceHolder1_btn_Redirect').click();" & "parent.$('#dialog_insert').dialog('close'); ", True)
            '   rg_list.Rebind()
            Bind_Data()
        End If

    End Sub

    'Private Sub rg_list_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_list.NeedDataSource

    '    Dim dt As New DataTable
    '    Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
    '    Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL

    '    ' dt = bao.get_budgetWithdraw_detail(withdraw_bill.Value)
    '    dt = bao.get_relate_det_by_fkid(_BID)
    '    'dt.Columns.Add("nVat", GetType(Double))
    '    'dt.Columns.Add("nMulct", GetType(Double))
    '    'dt.Columns.Add("nInsurance", GetType(Double))
    '    dt.Columns.Add("nAmountMoney", GetType(Double))

    '    'Dim vat As Double = 0
    '    Dim Amount As Double = 0
    '    Dim Before_Vat As Double = 0
    '    Dim After_Vat As Double = 0

    '    For Each dr As DataRow In dt.Rows

    '        '------------ภาษี------------
    '        If IsDBNull(dr("TAX_TYPE")) = False Then
    '            If dr("TAX_TYPE") <> 0 Then
    '                If dr("TAX_TYPE") = 1 Or dr("TAX_TYPE") = 5 Then 'นิติบุคคล

    '                    'คิด 1% ยังไม่คิด 7%
    '                    If IsDBNull(dr("AMOUNT")) = False Then
    '                        If dr("AMOUNT") <> 0 Then

    '                            Amount = dr("AMOUNT")
    '                            Before_Vat = (Amount * 7) / 107
    '                            After_Vat = Amount - Before_Vat

    '                            If After_Vat >= 500 Then
    '                                dr("nVat") = Before_Vat
    '                            Else
    '                                dr("nVat") = 0
    '                            End If
    '                        Else
    '                            dr("nVat") = 0
    '                        End If
    '                    Else
    '                        dr("nVat") = 0
    '                    End If

    '                ElseIf dr("TAX_TYPE") = 2 Or dr("TAX_TYPE") = 3 Then 'บุคคล

    '                    'If IsDBNull(dr("AMOUNT")) = False Then
    '                    '    If dr("AMOUNT") <> 0 Then
    '                    '        dr("VAT") = (dr("AMOUNT") * 7) / 107
    '                    '    Else
    '                    '        dr("VAT") = 0
    '                    '    End If
    '                    'Else
    '                    '    dr("VAT") = 0
    '                    'End If
    '                    If IsDBNull(dr("AMOUNT")) = False Then '1%
    '                        If dr("AMOUNT") <> 0 Then

    '                            Amount = dr("AMOUNT")
    '                            Before_Vat = (Amount * 1) / 107
    '                            After_Vat = Amount - Before_Vat

    '                            If After_Vat >= 10000 Then
    '                                dr("nVat") = Before_Vat
    '                            Else
    '                                dr("nVat") = 0
    '                            End If

    '                        Else
    '                            dr("nVat") = 0
    '                        End If

    '                    Else
    '                        dr("nVat") = 0
    '                    End If

    '                ElseIf dr("TAX_TYPE") = 6 Then 'นิติ ไม่ vat 7%
    '                    'คิด 1% ยังไม่คิด 7%
    '                    If IsDBNull(dr("AMOUNT")) = False Then
    '                        If dr("AMOUNT") <> 0 Then

    '                            Amount = dr("AMOUNT")
    '                            Before_Vat = (Amount * 1) / 107
    '                            After_Vat = Amount - Before_Vat

    '                            If After_Vat >= 500 Then
    '                                dr("nVat") = Before_Vat
    '                            Else
    '                                dr("nVat") = 0
    '                            End If
    '                        Else
    '                            dr("nVat") = 0
    '                        End If
    '                    Else
    '                        dr("nVat") = 0
    '                    End If

    '                ElseIf dr("TAX_TYPE") = 4 Then
    '                    dr("nVat") = 0
    '                End If
    '            Else
    '                dr("nVat") = 0
    '            End If
    '        Else
    '            dr("nVat") = 0
    '        End If

    '        '----------------------------------
    '        'If IsDBNull(dr("nVat")) = False Then
    '        '    dr("nVat") = dr("nVat")
    '        'Else
    '        '    dr("nVat") = 0
    '        'End If

    '        If IsDBNull(dr("nInsurance")) = False Then
    '            dr("nInsurance") = dr("nInsurance")
    '        Else
    '            dr("nInsurance") = 0
    '        End If

    '        If IsDBNull(dr("nMulct")) = False Then
    '            dr("nMulct") = dr("nMulct")
    '        Else
    '            dr("nMulct") = 0
    '        End If

    '        '--------------------------------
    '        If IsDBNull(dr("AMOUNT")) = False Then
    '            If dr("AMOUNT") <> 0 Then
    '                If IsDBNull(dr("AMOUNT_MONEY")) = True Then
    '                    dr("AMOUNT_MONEY") = CDbl(dr("AMOUNT") - (dr("nVat") + dr("nMulct") + dr("nInsurance")))
    '                End If

    '            End If
    '        End If

    '        If IsDBNull(dr("AMOUNT_MONEY")) = False Then
    '            dr("nAmountMoney") = dr("AMOUNT_MONEY")
    '        Else
    '            dr("nAmountMoney") = 0
    '        End If

    '    Next

    '    rg_list.DataSource = dt

    'End Sub

    Public Sub Bind_Data()
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL

        ' dt = bao.get_budgetWithdraw_detail(withdraw_bill.Value)
        dt = bao.get_relate_det_by_fkid(_BID)
        'dt.Columns.Add("nVat", GetType(Double))
        'dt.Columns.Add("nMulct", GetType(Double))
        'dt.Columns.Add("nInsurance", GetType(Double))
        dt.Columns.Add("nAmountMoney", GetType(Double))
        '   dt.Columns.Add("PurchaseItemsId", GetType(Integer))

        'Dim vat As Double = 0
        Dim Amount As Double = 0
        Dim Before_Vat As Double = 0
        Dim After_Vat As Double = 0

        For Each dr As DataRow In dt.Rows

            '------------ภาษี------------
            If IsDBNull(dr("TAX_TYPE")) = False Then
                If dr("TAX_TYPE") <> 0 Then
                    If dr("TAX_TYPE") = 1 Or dr("TAX_TYPE") = 5 Then 'นิติบุคคล

                        'คิด 1% ยังไม่คิด 7%
                        If IsDBNull(dr("AMOUNT")) = False Then
                            If dr("AMOUNT") <> 0 Then

                                Amount = dr("AMOUNT")
                                Before_Vat = (Amount * 7) / 107
                                After_Vat = Amount - Before_Vat

                                If After_Vat >= 500 Then
                                    dr("nVat") = Before_Vat
                                Else
                                    dr("nVat") = 0
                                End If
                            Else
                                dr("nVat") = 0
                            End If
                        Else
                            dr("nVat") = 0
                        End If

                    ElseIf dr("TAX_TYPE") = 2 Or dr("TAX_TYPE") = 3 Then 'บุคคล

                        'If IsDBNull(dr("AMOUNT")) = False Then
                        '    If dr("AMOUNT") <> 0 Then
                        '        dr("VAT") = (dr("AMOUNT") * 7) / 107
                        '    Else
                        '        dr("VAT") = 0
                        '    End If
                        'Else
                        '    dr("VAT") = 0
                        'End If
                        If IsDBNull(dr("AMOUNT")) = False Then '1%
                            If dr("AMOUNT") <> 0 Then

                                Amount = dr("AMOUNT")
                                Before_Vat = (Amount * 1) / 100
                                After_Vat = Amount - Before_Vat

                                If After_Vat >= 10000 Then
                                    dr("nVat") = Before_Vat
                                Else
                                    dr("nVat") = 0
                                End If

                            Else
                                dr("nVat") = 0
                            End If

                        Else
                            dr("nVat") = 0
                        End If

                    ElseIf dr("TAX_TYPE") = 6 Then 'นิติ ไม่ vat 7%
                        'คิด 1% ยังไม่คิด 7%
                        If IsDBNull(dr("AMOUNT")) = False Then
                            If dr("AMOUNT") <> 0 Then

                                Amount = dr("AMOUNT")
                                Before_Vat = (Amount * 1) / 100
                                After_Vat = Amount - Before_Vat

                                If After_Vat >= 500 Then
                                    dr("nVat") = Before_Vat
                                Else
                                    dr("nVat") = 0
                                End If
                            Else
                                dr("nVat") = 0
                            End If
                        Else
                            dr("nVat") = 0
                        End If

                    ElseIf dr("TAX_TYPE") = 4 Then
                        dr("nVat") = 0
                    End If
                Else
                    dr("nVat") = 0
                End If
            Else
                dr("nVat") = 0
            End If

            '----------------------------------
            'If IsDBNull(dr("nVat")) = False Then
            '    dr("nVat") = dr("nVat")
            'Else
            '    dr("nVat") = 0
            'End If

            If IsDBNull(dr("nInsurance")) = False Then
                dr("nInsurance") = dr("nInsurance")
            Else
                dr("nInsurance") = 0
            End If

            If IsDBNull(dr("nMulct")) = False Then
                dr("nMulct") = dr("nMulct")
            Else
                dr("nMulct") = 0
            End If

            '--------------------------------
            If IsDBNull(dr("AMOUNT")) = False Then
                If dr("AMOUNT") <> 0 Then
                    If IsDBNull(dr("AMOUNT_MONEY")) = True Then
                        dr("AMOUNT_MONEY") = CDbl(dr("AMOUNT") - (dr("nVat") + dr("nMulct") + dr("nInsurance")))
                    End If

                End If
            End If

            If IsDBNull(dr("AMOUNT_MONEY")) = False Then
                dr("nAmountMoney") = dr("AMOUNT_MONEY")
            Else
                dr("nAmountMoney") = 0
            End If

            If IsDBNull(dr("PurchaseItemsId")) = False Then
                dr("PurchaseItemsId") = dr("PurchaseItemsId")
            Else
                dr("PurchaseItemsId") = 0
            End If

        Next

        rg_list.DataSource = dt
        rg_list.DataBind()
    End Sub

    Public Sub rebind_grid()
        rg_list.Rebind()
    End Sub

    Public Sub insert_detail()

        Dim date_time As New DateTime
        date_time = DateTime.Now

        Dim valueVat As Double = 0
        Dim valueMulct As Double = 0
        Dim valueInsurance As Double = 0
        Dim PurchaseItems As Integer = 0

        For Each item As GridDataItem In rg_list.Items

            Dim dao_c As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DETAIL
            Dim i As Integer = 0

            i = dao_c.count_by_id(item("DETAIL_ID").Text)

            Dim id_detail As Integer = item("DETAIL_ID").Text

            Dim nVat As RadNumericTextBox = item.FindControl("nVat")
            Dim nMulct As RadNumericTextBox = item.FindControl("nMulct")
            Dim nInsurance As RadNumericTextBox = item.FindControl("nInsurance")
            Dim ddl As RadComboBox = item.FindControl("ddl_PurchaseItems")

            valueVat = nVat.Value
            valueMulct = nMulct.Value
            valueInsurance = nInsurance.Value
            PurchaseItems = ddl.SelectedValue

            If i = 0 Then

                Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DETAIL

                'Dim txtVat As RadTextBox = DirectCast(item("nVat").FindControl("txtVat"), RadTextBox)
                'Dim txtMulct As RadTextBox = DirectCast(item("nMulct").FindControl("txtMulct"), RadTextBox)
                'valueVat = txtVat.Text
                'valueMulct = txtMulct.Text
                Dim dao_with As New DAO_DISBURSE.TB_BUDGET_WITHDRAW
                dao_with.Getdata_by_Fk_id(_BID)

                dao.fields.FK_WITH_ID = dao_with.fields.ID
                dao.fields.CITIZEN_ADD = _Citizen
                dao.fields.DATE_ADD = date_time
                dao.fields.FK_DETAIL_ID = id_detail

                Dim bg_child1 As Integer = 0
                Dim bg_child2 As Integer = 0
                Dim bg_child3 As Integer = 0
                Dim bg_child4 As Integer = 0

                Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                Dim dao_cus As New DAO_MAS.TB_MAS_CUSTOMER
                Dim dao_cus_type As New DAO_MAS.TB_MAS_CUSTOMER_TYPE

                dao_detail.Getdata_by_Disburse_id(_BID)
                dao_cus.Getdata_by_CUSTOMER_ID(dao_detail.fields.CUSTOMER_ID)
                dao_cus_type.Getdata_by_CUSTOMER_TYPE_ID(dao_cus.fields.CUSTOMER_TYPE_ID)

                dao.fields.CUS_ID = dao_cus.fields.CUSTOMER_ID
                dao.fields.CUS_NAME = dao_cus.fields.CUSTOMER_NAME

                dao.fields.CUS_TYPE = dao_cus_type.fields.CUSTOMER_TYPE
                dao.fields.CUS_TYPE_ID = dao_cus_type.fields.CUSTOMER_TYPE_ID

                dao.fields.AMOUNT = item("AMOUNT").Text
                dao.fields.nVat = valueVat
                dao.fields.nMulct = valueMulct
                dao.fields.nInsurance = valueInsurance
                dao.fields.AMOUNT_MONEY = ((item("AMOUNT").Text) - (valueVat + valueMulct + valueInsurance))
                dao.fields.PurchaseItemsId = PurchaseItems
                dao.insert()

            Else

                Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DETAIL
                dao.Getdata_by_FK_DETAIL_ID(id_detail)

                Dim dao2 As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DETAIL
                dao2.Getdata_by_ida(dao.fields.IDA)

                dao2.fields.AMOUNT = item("AMOUNT").Text
                dao2.fields.nVat = valueVat
                dao2.fields.nMulct = valueMulct
                dao2.fields.nInsurance = valueInsurance
                dao2.fields.AMOUNT_MONEY = ((item("AMOUNT").Text) - (valueVat + valueMulct + valueInsurance))
                dao2.fields.PurchaseItemsId = PurchaseItems
                dao2.update()

            End If

        Next

        'Bind_Data()

    End Sub

End Class