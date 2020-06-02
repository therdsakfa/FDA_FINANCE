Imports Telerik.Web.UI
Public Class UC_Disburse_Budget_withdraw_deka_add3
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

    End Sub

    Public Sub set_data()
        rg_list.Rebind()
    End Sub

    Public Sub rebind_grid()
        rg_list.Rebind()
    End Sub

    Private Sub rg_list_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_list.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then

            Dim item As GridDataItem
            item = e.Item

            '   Dim ddl_budget As RadComboBox = DirectCast(item("BUDGET_NAME").FindControl("ddl_budget_name"), RadComboBox)
            '  Dim Amount As RadTextBox = DirectCast(item("AMOUNT").FindControl("AMOUNT"), RadTextBox)
            Dim chkbx As CheckBox = DirectCast(item("chkColumn").Controls(0), CheckBox)

            Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA_BUDGET_GROUP
            dao.Getdata_by_FK_DEKA_Id(_id_deka, item("IDA").Text)

            'If dao.fields.AMOUNT IsNot Nothing Then
            '    Amount.Text = dao.fields.AMOUNT
            '    Amount.Enabled = False
            'Else
            '    Amount.Text = "0.00"
            'End If

            Dim chk As Integer = 0

            If dao.fields.CHK_LIST IsNot Nothing Then
                If dao.fields.CHK_LIST <> 0 Then
                    chk = 1
                Else
                    chk = 0
                End If
            Else
                chk = 0
            End If

            If chk <> 0 Then
                item.Selected = True
                ' chkbx.Enabled = False
            Else
                item.Selected = False
            End If

            ' dt = bao.get_HEAD_BUDGET_NAME()

            'Dim dao As New DAO_MAS.TB_MAS_CHECKER
            'dao.GetDataby_All()

            'ddl_budget.DataSource = dt.Rows
            'ddl_budget.DataTextField = "NameOfBudget"
            'ddl_budget.DataValueField = "IDA"
            'ddl_budget.DataBind()

            'Dim r As New RadComboBoxItem
            'r.Text = "--กรุณาเลือก--"
            'r.Value = 0
            'ddl_budget.Items.Insert(0, r)

        End If
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

    Public Sub Bind_Data()
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As New DataTable


        Dim bao2 As New BAO_BUDGET.MASS
        Dim dt2 As New DataTable

        Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA_BUDGET_GROUP
        dao.Getdata_by_fkida(_id_deka)

        If dao.fields.IDA <> 0 Then

            Dim baoSum As New BAO_BUDGET.DISBURSE_BUDGET
            Dim Sum As Double = 0

            dt = bao.get_deka_detail_budget_group(_id_deka)
            dt.Columns.Add("sum_amount", GetType(Double))

            For Each dr As DataRow In dt.Rows

                Sum = baoSum.get_sum_deka_detail_budget_group_detail(_id_deka, dr("BUDGET_ID"))

                If Sum <> 0 Then
                    dr("sum_amount") = Sum
                Else
                    dr("sum_amount") = 0
                End If

            Next

        Else

            dt = bao2.get_HEAD_BUDGET_NAME()
            dt.Columns.Add("FK_DEKA")
            dt.Columns.Add("BUDGET_ID")
            dt.Columns.Add("sum_amount", GetType(Double))
            dt.Columns.Add("CHK_LIST")

        End If

        rg_list.DataSource = dt
        rg_list.DataBind()

    End Sub

    Public Sub updates()

        Dim i As String = ""

        For Each item As GridDataItem In rg_list.Items

            ' Dim ddl_budget As RadComboBox = DirectCast(item("BUDGET_NAME").FindControl("ddl_budget_name"), RadComboBox)
            ' Dim Amount As RadTextBox = DirectCast(item("Amount").FindControl("Amount"), RadTextBox)
            Dim chkbx As CheckBox = DirectCast(item("chkColumn").Controls(0), CheckBox)

            Dim dao2 As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA_BUDGET_GROUP
            dao2.Getdata_by_FK_DEKA_BUDGET(_id_deka, item("IDA").Text)

            If dao2.fields.IDA = 0 Then
                Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA_BUDGET_GROUP
                dao.fields.FK_DEKA = _id_deka
                dao.fields.BUDGET_ID = item("IDA").Text
                '  dao.fields.AMOUNT = Amount.Text

                If chkbx.Checked = True Then
                    dao.fields.CHK_LIST = 1
                Else
                    dao.fields.CHK_LIST = 0
                End If

                dao.insert()
            Else

                Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA_BUDGET_GROUP
                Dim dao3 As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA_BUDGET_GROUP
                ' Dim dao4 As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA_BUDGET_GROUP
                dao3.Getdata_by_FK_DEKA_BUDGET(_id_deka, item("IDA").Text)

                dao.Getdata_by_ida(dao3.fields.IDA)

                If chkbx.Checked = True Then
                    dao.fields.CHK_LIST = 1
                Else
                    dao.fields.CHK_LIST = 0
                End If

                dao.update()
            End If

        Next

    End Sub

End Class