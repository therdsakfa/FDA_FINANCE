﻿Imports Telerik.Web.UI
Public Class UC_Disburse_Cure_Study_Boss_Approve
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
    Private _BudgetID As Integer
    Public Property BudgetID() As Integer
        Get
            Return _BudgetID
        End Get
        Set(ByVal value As Integer)
            _BudgetID = value
        End Set
    End Property
    Private _sub_BudgetID As Integer
    Public Property sub_BudgetID() As Integer
        Get
            Return _sub_BudgetID
        End Get
        Set(ByVal value As Integer)
            _sub_BudgetID = value
        End Set
    End Property
    Private _BudgetYear As Integer
    Public Property BudgetYear() As Integer
        Get
            Return _BudgetYear
        End Get
        Set(ByVal value As Integer)
            _BudgetYear = value
        End Set
    End Property
    Private _is_po As String
    Public Property is_po() As String
        Get
            Return _is_po
        End Get
        Set(ByVal value As String)
            _is_po = value
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
    Private _bill_type As Integer
    Public Property bill_type() As Integer
        Get
            Return _bill_type
        End Get
        Set(ByVal value As Integer)
            _bill_type = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub rgApprove_Init(sender As Object, e As EventArgs) Handles rgApprove.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgApprove
        Rad_Utility.addColumnBound("CURE_STUDY_ID", "CURE_STUDY_ID", False)
        Rad_Utility.addColumnBound("app", "app", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", width:=300)
        'Rad_Utility.addColumnBound("CUSTOMER_NAME", "ผู้รับเงิน/เจ้าหนี้")
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข GFMIS")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True, footer_txt:="รวม", width:=120)
        Rad_Utility.addColumnBound("reason", "การอนุมัติและตรวจสอบ")
    End Sub

    Private Sub rgApprove_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgApprove.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET

        dt = bao.get_cure_study_boss_approve_V2(BudgetYear, stat - 1, g, bill_type)
        dt.Columns.Add("reason")
        For Each dr As DataRow In dt.Rows
            If dr("STATUS_ID") >= stat Then
                dr("reason") = "หัวหน้าฝ่ายการคลังอนุมัติแล้ว"
            End If
        Next
        rgApprove.DataSource = dt
    End Sub

    Public Sub update_true(ByVal date_input As Date, ByVal iden As String)
        For Each item As GridDataItem In rgApprove.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_CURE_STUDY
            dao.Getdata_by_CURE_STUDY_ID(item("CURE_STUDY_ID").Text)
            dao.fields.STATUS_ID = stat
            dao.fields.GROUP_ID = g
            dao.update()

            Dim dao2 As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            dao2.fields.STATUS_ID = stat
            dao2.fields.GROUP_ID = g
            dao2.fields.BILL_TYPE = bt
            dao2.fields.REASON_DATE = date_input
            dao2.fields.IDENTITY_NUMBER = iden
            dao2.fields.DATE_ADD = Date.Now
            dao2.fields.FK_IDA = item("CURE_STUDY_ID").Text
            dao2.insert()
        Next
    End Sub
    Public Sub rg_rebind()
        rgApprove.Rebind()
    End Sub
End Class