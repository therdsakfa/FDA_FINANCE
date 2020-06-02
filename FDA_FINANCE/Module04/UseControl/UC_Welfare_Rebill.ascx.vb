Imports Telerik.Web.UI

Public Class UC_Welfare_Rebill
    Inherits System.Web.UI.UserControl

    Private _BudgetYear As Integer ' ปีงบประมาณ
    Public Property BudgetYear() As Integer
        Get
            Return _BudgetYear
        End Get
        Set(ByVal value As Integer)
            _BudgetYear = value
        End Set
    End Property
    Private _BillType As Integer ' ประเภทสวัสดิการ 1 = ค่ารักษาพยาบาล, 2 = ค่าเล่าเรียนบุตร
    Public Property BillType() As Integer
        Get
            Return _BillType
        End Get
        Set(ByVal value As Integer)
            _BillType = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_Disburse_Debtor_Rebill_Init(sender As Object, e As EventArgs) Handles rg_Disburse_Wellfare.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_Disburse_Wellfare
        Rad_Utility.addColumnBound("CURE_STUDY_ID", "CURE_STUDY_ID", False)
        Rad_Utility.addColumnCheckbox_client("chkColumn", "")
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายละเอียด")
        'Rad_Utility.addColumnBound("USER_AD", "ชื่อผู้เบิก")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
    End Sub

    Private Sub rg_Disburse_Debtor_Rebill_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_Disburse_Wellfare.NeedDataSource
        Dim BudgetBill As New BAO_BUDGET.Welfare
        rg_Disburse_Wellfare.DataSource = BudgetBill.get_DISBURSES_CURE_STUDY(BudgetYear, BillType) '
    End Sub

    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rg_Disburse_Wellfare)
    End Sub

    Public Sub insert()
        For Each item As GridDataItem In rg_Disburse_Wellfare.SelectedItems

            Dim dao_Disburse_Welfare_Bill As New DAO_DISBURSE.TB_CURE_STUDY
            Dim dao_Welfare As New DAO_WELFARE.TB_ALL_WELFARE_BILL

            dao_Disburse_Welfare_Bill.Getdata_by_CURE_STUDY_ID(CInt(item("CURE_STUDY_ID").Text))
            dao_Welfare.fields.CURE_STUDY_ID = dao_Disburse_Welfare_Bill.fields.CURE_STUDY_ID
            dao_Welfare.fields.BUDGET_YEAR = dao_Disburse_Welfare_Bill.fields.BUDGET_YEAR
            dao_Welfare.fields.DESCRIPTION = dao_Disburse_Welfare_Bill.fields.DESCRIPTION
            dao_Welfare.fields.AMOUNT = dao_Disburse_Welfare_Bill.fields.AMOUNT
            dao_Welfare.fields.WELFARE_ID = BillType '

            dao_Welfare.insert()
        Next

        'If BillType = 1 Then
        '    Response.Redirect("Frm_Welfare_Cure.aspx")
        'ElseIf BillType = 2 Then
        '    Response.Redirect("Frm_Welfare_Study.aspx")
        'End If

    End Sub

    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_Disburse_Wellfare, str)
    End Sub

End Class