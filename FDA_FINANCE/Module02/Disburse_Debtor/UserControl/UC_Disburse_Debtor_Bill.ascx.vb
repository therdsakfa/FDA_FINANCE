Imports Telerik.Web.UI
Partial Public Class UC_Disburse_Debtor_Bill
    Inherits System.Web.UI.UserControl
    Private _BudgetUseID As Integer
    Public Property BudgetUseID() As Integer
        Get
            Return _BudgetUseID
        End Get
        Set(ByVal value As Integer)
            _BudgetUseID = value
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
    Private _Budgetyear As Integer
    Public Property Budgetyear() As Integer
        Get
            Return _Budgetyear
        End Get
        Set(ByVal value As Integer)
            _Budgetyear = value
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
    Private _g As Integer
    Public Property g() As Integer
        Get
            Return _g
        End Get
        Set(ByVal value As Integer)
            _g = value
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
    Private _g2 As Integer
    Public Property g2() As Integer
        Get
            Return _g2
        End Get
        Set(ByVal value As Integer)
            _g2 = value
        End Set
    End Property
    Private _stat2 As Integer
    Public Property stat2() As Integer
        Get
            Return _stat2
        End Get
        Set(ByVal value As Integer)
            _stat2 = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgAddKNumber_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgAddKNumber.Init

        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgAddKNumber
        Rad_Utility.addColumnBound("DEBTOR_BILL_ID", "DEBTOR_BILL_ID", False)
        'Rad_Utility.addColumnBound("id", "ลำดับที่")

        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("FullName", "ชื่อ-นามสกุลผู้ยืม")
        'Rad_Utility.addColumnBound("BILL_NUMBER", "เลขบย.")
        'Rad_Utility.addColumnDate("Bill_RECIEVE_DATE", "วันที่รับเอกสาร")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข GFMIS")
        Rad_Utility.addColumnDate("GFMIS_DATE", "วันที่ GFMIS")
        'Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "หน่วยงาน")
        Rad_Utility.addColumnButton("E", "เพิ่มเลข GFMIS", "E", 0, "")
        Rad_Utility.addColumnButton("D", "ลบเลข GFMIS", "D", 0, "คุณต้องการลบเลข GFMIS หรือไม่")
    End Sub

    Private Sub rgAddKNumber_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rgAddKNumber.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            If e.CommandName = "D" Then
                If Not item("DEBTOR_BILL_ID").Text.Contains("&nbsp") Then
                    Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
                    dao.Getdata_by_DEBTOR_BILL_ID(item("DEBTOR_BILL_ID").Text)
                    dao.fields.GFMIS_NUMBER = ""
                    dao.fields.GFMIS_DATE = Nothing

                    Dim log As New log_event.log
                    log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                                   Request.Url.AbsoluteUri.ToString(), "ลบขบ.ใบลูกหนี้เลขที่หนังสือ " & dao.fields.DOC_NUMBER, "DEBTOR_BILL", item("DEBTOR_BILL_ID").Text)
                    dao.update()
                    rgAddKNumber.Rebind()
                End If
            End If

        End If
    End Sub

    Private Sub rgAddKNumber_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgAddKNumber.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim id As String = ""
            Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
            Dim debt As Integer = Nothing
            dao.Getdata_by_DEBTOR_BILL_ID(item("DEBTOR_BILL_ID").Text)
            'If dao.fields.DEBTOR_TYPE_ID IsNot Nothing Then
            Try
                debt = dao.fields.DEBTOR_TYPE_ID
            Catch ex As Exception
                debt = 0
            End Try

            id = "../../Module02/Disburse_Debtor/Frm_Disburse_Debtor_Bill_Insert_Detail.aspx?bid=" & item("DEBTOR_BILL_ID").Text & "&debt=" & debt & "&bt" & bt & "&g=" & g2 & "&stat=" & stat2
            'End If


            Dim h2 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            'h2.Attributes.Add("OnClick", "return k('" & id & "');")
            h2.Attributes.Add("OnClick", "Popups('" & id & "'); return false;")
        End If
    End Sub

    Private Sub rgAddKNumber_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgAddKNumber.NeedDataSource
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        'Dim dt As DataTable = bao.getGF_bg_bill_debtor(Budgetyear, BudgetUseID)
        Dim dt As DataTable = bao.getGF_bg_bill_debtor_bt_group_v2(Budgetyear, BudgetUseID, stat, g)
        rgAddKNumber.DataSource = dt
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgAddKNumber, str)
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgAddKNumber)
        'rg_Disburse_Budget.Rebind()
    End Sub
    Public Sub rg_rebind()
        rgAddKNumber.Rebind()
    End Sub
End Class