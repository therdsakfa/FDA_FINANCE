Imports Telerik.Web.UI
Public Class UC_Welfare_Cremation_Import
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
    Private _byear_query As Integer
    Public Property byear_query() As Integer
        Get
            Return _byear_query
        End Get
        Set(ByVal value As Integer)
            _byear_query = value
        End Set
    End Property
    Private _month_nm As String
    Public Property month_nm() As String
        Get
            Return _month_nm
        End Get
        Set(ByVal value As String)
            _month_nm = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgCremation_Init(sender As Object, e As EventArgs) Handles rgCremation.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgCremation
        Rad_Utility.addColumnCheckbox_client("chkColumn", "")
        Rad_Utility.addColumnBound("ALL_WELFARE_ID", "ALL_WELFARE_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("PERSONAL_ID", "เลขบัตรประชาชน")
        Rad_Utility.addColumnBound("NAME", "ชื่อ-นามสกุล")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True, footer_txt:="จำนวนเงิน : ")
        Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "หน่วยงาน")
        Rad_Utility.addColumnBound("MONTH_LIVE", "เดือนที่เบิก")
    End Sub
    Public Sub insert_welfare(ByVal month_nm As String)
        For Each item As GridDataItem In rgCremation.SelectedItems
            Dim dao As New DAO_WELFARE.TB_ALL_WELFARE_BILL
            Dim dao_insert As New DAO_WELFARE.TB_ALL_WELFARE_BILL
            dao.Getdata_by_BUDGET_WELFARE_ID(item("ALL_WELFARE_ID").Text)
            dao_insert.fields.AMOUNT = dao.fields.AMOUNT
            dao_insert.fields.BUDGET_YEAR = BudgetYear

            dao_insert.fields.NAME = dao.fields.NAME
            dao_insert.fields.PERSONAL_ID = dao.fields.PERSONAL_ID
            dao_insert.fields.WELFARE_CODE = dao.fields.WELFARE_CODE
            dao_insert.fields.DESCRIPTION = dao.fields.DESCRIPTION
            dao_insert.fields.DEPARTMENT_ID = dao.fields.DEPARTMENT_ID
            dao_insert.fields.WELFARE_ID = dao.fields.WELFARE_ID
            dao_insert.fields.MONTH_LIVE = month_nm
            dao_insert.fields.WELFARE_DATE = dao.fields.WELFARE_DATE

            dao_insert.insert()
        Next

    End Sub


    Private Sub rgCremation_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgCremation.NeedDataSource
        Dim bao As New BAO_BUDGET.Welfare
        rgCremation.DataSource = bao.get_WELFARE(3, byear_query, month_nm)
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgCremation)
    End Sub

    Public Sub rebindRg()
        rgCremation.Rebind()
    End Sub
End Class