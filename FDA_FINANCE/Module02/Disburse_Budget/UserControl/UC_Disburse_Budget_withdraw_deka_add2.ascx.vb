
Imports Telerik.Web.UI
Public Class UC_Disburse_Budget_withdraw_deka_add2
    Inherits System.Web.UI.UserControl

    Private _Citizen As String
    Public Property Citizen() As String
        Get
            Return _Citizen
        End Get
        Set(ByVal value As String)
            _Citizen = value
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

    Private _id_deka As Integer
    Public Property id_deka() As Integer
        Get
            Return _id_deka
        End Get
        Set(ByVal value As Integer)
            _id_deka = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        '    Bind_Data()
        'End If

    End Sub

    Public Sub set_data()
        rg_list.Rebind()
    End Sub

    Public Sub rebind_grid()
        rg_list.Rebind()
    End Sub

    Public Function chk_selected() As Boolean
        Dim bool As Boolean = False
        Dim item_c As Integer = 0
        For Each item As GridDataItem In rg_list.SelectedItems
            item_c += 1
        Next
        If item_c > 0 Then
            bool = True
        End If
        Return bool
    End Function

    Public Function chk_selected_count() As Integer
        Dim item_c As Integer = 0
        For Each item As GridDataItem In rg_list.SelectedItems
            item_c += 1
        Next
        Return item_c
    End Function

    Public Sub updates()

        Dim i As Integer = 0
        Try
            i = rg_list.SelectedItems.Count
        Catch ex As Exception

        End Try


        For Each item As GridDataItem In rg_list.SelectedItems

            Dim dao3 As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA_DETAIL
            dao3.Getdata_by_fk_deka_billId(_id_deka, item("BUDGET_DISBURSE_BILL_ID").Text)

            If dao3.fields.IDA = 0 Then
                Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA_DETAIL
                'dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("IDA").Text)
                dao.fields.FK_BILL_ID = item("BUDGET_DISBURSE_BILL_ID").Text
                dao.fields.FK_DEKA = _id_deka

                Dim dao2 As New DAO_DISBURSE.TB_BUDGET_WITHDRAW
                dao2.Getdata_by_Fk_id(item("BUDGET_DISBURSE_BILL_ID").Text)

                If dao2.fields.BillCode IsNot Nothing Then
                    dao.fields.ORDER_LIST = dao2.fields.BillCode
                Else
                    dao.fields.ORDER_LIST = 0
                End If

                Dim chkbx As CheckBox = DirectCast(item("chkColumn").Controls(0), CheckBox)

                If chkbx.Checked = True Then
                    dao.fields.CHK_LIST = 1
                Else
                    dao.fields.CHK_LIST = 0
                End If

                Dim GFMIS_NUMBER As RadTextBox = DirectCast(item("GFMIS_NUMBER").FindControl("GFMIS_NUMBER"), RadTextBox)
                dao.fields.GFMIS_NUMBER = GFMIS_NUMBER.Text

                Dim GFMIS_DATE As RadDatePicker = DirectCast(item("GFMIS_DATE").FindControl("GFMIS_DATE"), RadDatePicker)

                Dim _date As String = ""

                If GFMIS_DATE.SelectedDate Is Nothing Then
                    _date = Nothing
                Else
                    _date = GFMIS_DATE.SelectedDate
                End If

                If _date <> "" Then
                    dao.fields.GFMIS_DATE = _date
                Else
                    dao.fields.GFMIS_DATE = Nothing
                End If

                dao.insert()

            Else

                Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA_DETAIL
                Dim dao4 As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA_DETAIL
                dao4.Getdata_by_fk_deka_billId(_id_deka, item("BUDGET_DISBURSE_BILL_ID").Text)

                Dim dao2 As New DAO_DISBURSE.TB_BUDGET_WITHDRAW
                dao2.Getdata_by_Fk_id(item("BUDGET_DISBURSE_BILL_ID").Text)

                Dim chkbx As CheckBox = DirectCast(item("chkColumn").Controls(0), CheckBox)

                dao.Getdata_by_ida(dao4.fields.IDA)

                If chkbx.Checked = True Then
                    dao.fields.CHK_LIST = 1
                Else
                    dao.fields.CHK_LIST = 0
                End If

                Dim GFMIS_NUMBER As RadTextBox = DirectCast(item("GFMIS_NUMBER").FindControl("GFMIS_NUMBER"), RadTextBox)
                dao.fields.GFMIS_NUMBER = GFMIS_NUMBER.Text

                Dim GFMIS_DATE As RadDatePicker = DirectCast(item("GFMIS_DATE").FindControl("GFMIS_DATE"), RadDatePicker)

                Dim _date As String = ""

                If GFMIS_DATE.SelectedDate Is Nothing Then
                    _date = Nothing
                Else
                    _date = GFMIS_DATE.SelectedDate
                End If

                If _date <> "" Then
                    dao.fields.GFMIS_DATE = _date
                Else
                    dao.fields.GFMIS_DATE = Nothing
                End If


                dao.update()

            End If


            'Else
            '    Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
            '    dao.Getdata_by_DEBTOR_BILL_ID(item("IDA").Text)
            '    Try
            '        ' dao.fields.CHKR_CTZID = ddl_checker.SelectedValue
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao.fields.CHKR_DATE = Date.Now
            '    Catch ex As Exception

            '    End Try
            '    dao.update()
            'End If

        Next

        'If i > 0 Then
        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
        '    rg_list.Rebind()
        '    dekaId = _deka
        'End If

    End Sub

    Private Sub rg_list_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_list.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then

            Dim item As GridDataItem
            item = e.Item

            '   Dim ddl_budget As RadComboBox = DirectCast(item("BUDGET_NAME").FindControl("ddl_budget_name"), RadComboBox)
            Dim chkbx As CheckBox = DirectCast(item("chkColumn").Controls(0), CheckBox)

            Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA_DETAIL
            dao.Getdata_by_ida(item("IDA").Text)

            Dim chk As Integer = 0

            If dao.fields.CHK_LIST IsNot Nothing Then
                chk = 1
            Else
                chk = 0
            End If

            If chk <> 0 Then
                item.Selected = True
                ' chkbx.Enabled = False
            Else
                item.Selected = False
            End If

            Dim GFMIS_NUMBER As RadTextBox = DirectCast(item("GFMIS_NUMBER").FindControl("GFMIS_NUMBER"), RadTextBox)
            Dim GFMIS_DATE As RadDatePicker = DirectCast(item("GFMIS_DATE").FindControl("GFMIS_DATE"), RadDatePicker)

            If dao.fields.GFMIS_NUMBER IsNot Nothing Then
                GFMIS_NUMBER.Text = dao.fields.GFMIS_NUMBER
            Else
                GFMIS_NUMBER.Text = ""
            End If

            If dao.fields.GFMIS_DATE IsNot Nothing Then
                GFMIS_DATE.SelectedDate = dao.fields.GFMIS_DATE
            Else
                GFMIS_DATE.SelectedDate = Nothing
            End If



        End If
    End Sub

    Public Sub Bind_Data()

        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET

        Dim bao2 As New BAO_BUDGET.MASS
        Dim dt2 As New DataTable

        Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA_DETAIL
        dao.Getdata_by_fk_deka(_id_deka)

        If dao.fields.IDA <> 0 Then
            dt = bao.get_budget_deka_detail(Budgetyear, _id_deka) ' ต้องเอาเลขฏีกาไปดึงเฉพาะแผนงาน ผลผลิต กิจกรรม 
        Else

            Dim Cida As Integer = 0
            Dim baoCount As New BAO_BUDGET.DISBURSE_BUDGET

            Cida = baoCount.get_budget_count_deka_detail(Budgetyear, _id_deka)

            If Cida = 0 Then

                Dim dao2 As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA
                dao2.Getdata_by_ida(_id_deka)

                Dim plan As Integer = 0
                Dim product As Integer = 0
                Dim act As Integer = 0

                If dao2.fields.PlanId IsNot Nothing Then
                    plan = dao2.fields.PlanId
                Else
                    plan = 0
                End If

                If dao2.fields.ProductId IsNot Nothing Then
                    product = dao2.fields.ProductId
                Else
                    product = 0
                End If

                If dao2.fields.ActivityId IsNot Nothing Then
                    act = dao2.fields.ActivityId
                Else
                    act = 0
                End If

                dt = bao.get_budget_deka_detail2_v2(Budgetyear, plan, product, act)  ' ต้องเอาเลขฏีกาไปดึงเฉพาะแผนงาน ผลผลิต กิจกรรม 
                'เอาตรงนี้ไปเทียบกับตารางที่ติกไปแล้ว

            Else

                dt.Columns.Add("BUDGET_DISBURSE_BILL_ID")
                dt.Columns.Add("IDA")
                dt.Columns.Add("GFMIS_NUMBER")
                dt.Columns.Add("GFMIS_DATE")
                dt.Columns.Add("BILL_NUMBER")
                dt.Columns.Add("BILL_DATE")
                dt.Columns.Add("DOC_NUMBER")
                dt.Columns.Add("DOC_DATE")
                dt.Columns.Add("DEPARTMENT_DESCRIPTION")
                dt.Columns.Add("BillRec")
                dt.Columns.Add("RowNumber")
                dt.Columns.Add("sum_amount")
            End If

        End If

        rg_list.DataSource = dt
        rg_list.DataBind()

    End Sub

End Class