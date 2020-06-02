Imports Telerik.Web.UI
Public Class UC_Disburse_Cure_Study_Transfer_to_Bank
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
    Private _Bill_type As Integer
    Public Property Bill_type() As Integer
        Get
            Return _Bill_type
        End Get
        Set(ByVal value As Integer)
            _Bill_type = value
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub rg_transfer_cus_Init(sender As Object, e As EventArgs) Handles rg_transfer_cus.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_transfer_cus
        Rad_Utility.Rad_css_setting(rg_transfer_cus)
        Rad_Utility.addColumnBound("CURE_STUDY_ID", "CURE_STUDY_ID", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", width:=300)
        'Rad_Utility.addColumnBound("CUSTOMER_NAME", "ผู้รับเงิน/เจ้าหนี้")
        Rad_Utility.addColumnBound("stat", "สถานะ")
        Rad_Utility.addColumnBound("sum_amount", "จำนวนเงิน", is_money:=True, footer_txt:="รวม", width:=120)
    End Sub

    Private Sub rg_transfer_cus_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_transfer_cus.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        
        dt = bao.get_cure_study_transfer(BudgetYear, stat - 1, g, Bill_type)
                dt.Columns.Add("stat")
                For Each dr As DataRow In dt.Rows
                    If dr("STATUS_ID") < stat Then
                        dr("stat") = "ยังไม่โอน"
                    ElseIf dr("STATUS_ID") >= stat Then
                        dr("stat") = "โอนแล้ว"
                    Else
                        dr("stat") = "-"
                    End If
                Next

        rg_transfer_cus.DataSource = dt
    End Sub

    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_transfer_cus, str)
    End Sub
    Public Sub rebind_grid()
        rg_transfer_cus.Rebind()
    End Sub

    Public Sub update_true(ByVal date_input As Date, ByVal iden As String)
        For Each item As GridDataItem In rg_transfer_cus.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_CURE_STUDY
            dao.Getdata_by_CURE_STUDY_ID(item("CURE_STUDY_ID").Text)
            dao.fields.IS_TRANSFER_TO_BANK = True
            dao.fields.TRANSFER_TO_BANK_DATE = date_input
            dao.fields.STATUS_ID = stat
            dao.fields.GROUP_ID = g
            dao.update()

            Dim dao2 As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            dao2.fields.FK_IDA = item("CURE_STUDY_ID").Text
            dao2.fields.BILL_TYPE = bt
            dao2.fields.DATE_ADD = Date.Now
            dao2.fields.IDENTITY_NUMBER = iden
            dao2.fields.REASON_DATE = Date.Now
            dao2.fields.STATUS_ID = stat
            dao2.fields.GROUP_ID = g
            dao2.insert()

            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "บันทึกการโอนจ่ายตรงเลขที่หนังสือ " & dao.fields.DOC_NUMBER, "CURE_STUDY", item("CURE_STUDY_ID").Text)


        Next
    End Sub
    Public Sub update_false(ByVal stat As Integer)
        For Each item As GridDataItem In rg_transfer_cus.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_CURE_STUDY
            dao.Getdata_by_CURE_STUDY_ID(item("CURE_STUDY_ID").Text)
            dao.fields.IS_TRANSFER_TO_BANK = False
            dao.fields.TRANSFER_TO_BANK_DATE = Nothing
            'dao.fields.STATUS_ID = stat - 1
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "ยกเลิกบันทึกการโอนจ่ายตรงเลขที่หนังสือ " & dao.fields.DOC_NUMBER, "CURE_STUDY", item("CURE_STUDY_ID").Text)

            dao.update()

            Dim dao2 As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            dao2.get_deeka_stat_del(item("CURE_STUDY_ID").Text, bt, stat)

            For Each dao2.fields In dao2.datas
                Dim dao3 As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
                Try
                    dao3.GetDataby_IDA(dao2.fields.IDA)
                    dao3.delete()
                Catch ex As Exception

                End Try
            Next
        Next
    End Sub
End Class