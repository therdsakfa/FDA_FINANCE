
Imports Telerik.Web.UI
Public Class UC_Disburse_Budget_withdraw_deka_add4
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

    Public Sub bind_dd_Budget()

        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As New DataTable


        Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA_BUDGET_GROUP
        dao.Getdata_by_fkida(_id_deka)

        If dao.fields.IDA <> 0 Then
            dt = bao.get_deka_detail_budget_group2(_id_deka)
        End If

        dd_budget.DataSource = dt
        dd_budget.DataBind()
        dd_budget.DropDownInsertDataFirstRow("---เลือก---", 0)

    End Sub

    Private Sub rg_list_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_list.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then

            Dim item As GridDataItem
            item = e.Item

            '   Dim ddl_budget As RadComboBox = DirectCast(item("BUDGET_NAME").FindControl("ddl_budget_name"), RadComboBox)
            Dim Amount As RadNumericTextBox = DirectCast(item("AMOUNT").FindControl("AMOUNT"), RadNumericTextBox)

            Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA_BUDGET_GROUP_DETAIL
            dao.Getdata_by_ida(item("gd_IDA").Text)

            If dao.fields.AMOUNT IsNot Nothing Then
                Amount.Text = dao.fields.AMOUNT
                '  Amount.Enabled = False
            Else
                Amount.Text = "0.00"
            End If


            '-----------------------------------------
            Dim LIST_NAME As RadTextBox = DirectCast(item("LIST_NAME").FindControl("LIST_NAME"), RadTextBox)

            If dao.fields.LIST_NAME IsNot Nothing Then
                LIST_NAME.Text = dao.fields.LIST_NAME
                'LIST_NAME.Enabled = False
            Else
                LIST_NAME.Text = ""
            End If

            '-------------------------------------------
            Dim ddl As RadComboBox = DirectCast(item("PURCHASE").FindControl("ddl_how_buy"), RadComboBox)

            Dim dao2 As New DAO_MAS.TB_MAS_PURCHASE
            dao2.GetDataby_All()

            ddl.DataSource = dao2.datas
            ddl.DataTextField = "PURCHASE_NAME"
            ddl.DataValueField = "IDA"
            ddl.DataBind()

            If dao.fields.PURCHASE_ID IsNot Nothing Then
                ddl.SelectedValue = dao.fields.PURCHASE_ID
            End If
        End If
    End Sub

    Public Sub Bind_Data()

        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As New DataTable

        Dim bao2 As New BAO_BUDGET.MASS
        Dim dt2 As New DataTable

        Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA_BUDGET_GROUP_DETAIL
        dao.Getdata_by_FK_DEKA(_id_deka)

        If dao.fields.IDA <> 0 Then
            dt = bao.get_deka_detail_budget_group_detail(_id_deka)
        End If

        rg_list.DataSource = dt
        rg_list.DataBind()

    End Sub

    Public Sub updates()

        Dim i As String = ""

        For Each item As GridDataItem In rg_list.Items

            Dim ddl As RadComboBox = DirectCast(item("PURCHASE").FindControl("ddl_how_buy"), RadComboBox)
            Dim Amount As RadNumericTextBox = DirectCast(item("Amount").FindControl("Amount"), RadNumericTextBox)
            Dim LIST_NAME As RadTextBox = DirectCast(item("LIST_NAME").FindControl("LIST_NAME"), RadTextBox)

            Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA_BUDGET_GROUP_DETAIL
            dao.Getdata_by_ida(item("gd_IDA").Text)

            '  dao.fields.FK_DEKA = _id_deka
            '   dao.fields.FK_BUDGET_GRUOP = item("h_IDA").Text
            dao.fields.AMOUNT = Amount.Text
            dao.fields.PURCHASE_ID = ddl.SelectedValue
            dao.fields.LIST_NAME = LIST_NAME.Text

            dao.update()

        Next

    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click

        Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA_BUDGET_GROUP_DETAIL

        dao.fields.FK_DEKA = _id_deka
        dao.fields.FK_BUDGET_GRUOP = dd_budget.SelectedValue

        dao.insert()

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เพิ่มหมวดงบเรียบร้อย');", True)
        Bind_Data()
        dd_budget.SelectedValue = 0
    End Sub

End Class