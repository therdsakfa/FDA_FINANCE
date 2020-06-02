Imports Telerik.Web.UI

Partial Public Class UC_Welfare_Cure
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
    Private _Name As String = "" ' ชื่อที่จะ Search
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
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

    Private Sub rgCure_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgCure.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgCure
        Rad_Utility.addColumnBound("ALL_WELFARE_ID", "ALL_WELFARE_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายละเอียดการเบิก")
        Rad_Utility.addColumnBound("NAME", "ชื่อ-นามสกุล ผู้รับเงิน")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnButton("I", "เพิ่มผู้รับเงิน", "I", 0, "คุณต้องการเพิ่มข้อมูลใช่หรือไม่", _display:=False)
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "")
        Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
    End Sub

    Private Sub rgCure_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgCure.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "D" Then
                Dim dao_welfare_cure As New DAO_WELFARE.TB_ALL_WELFARE_BILL
                dao_welfare_cure.Getdata_by_BUDGET_WELFARE_ID(item("ALL_WELFARE_ID").Text)
                dao_welfare_cure.delete()
                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "ลบรายการค่ารักษา", _
                               "ALL_WELFARE_BILL", item("ALL_WELFARE_ID").Text)

                ' Response.Redirect("Frm_Welfare_Cure.aspx")
                rgCure.Rebind()
                'ElseIf e.CommandName = "E" Then
                '    Response.Redirect("Frm_Welfare_Cure_Edit.aspx?ALL_WELFARE_ID=" & item("ALL_WELFARE_ID").Text)
            ElseIf e.CommandName = "I" Then
                Response.Redirect("Frm_Welfare_Cure_Insert.aspx?ALL_WELFARE_ID=" & item("ALL_WELFARE_ID").Text)
            End If
        End If
    End Sub

    Private Sub rgCure_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgCure.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim id As Integer = item("ALL_WELFARE_ID").Text
            If item("NAME").Text = "" Or IsDBNull(item("NAME").Text) = True Then

            ElseIf item("NAME").Text <> "" Or IsDBNull(item("NAME").Text) = False Then

            End If
            Dim h2 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            Dim url As String = "Frm_Welfare_Cure_Edit.aspx?ALL_WELFARE_ID=" & id & "&bgYear=" & BudgetYear
            h2.Attributes.Add("OnClick", "Popups2('" & url & "'); return false;")
            'h2.Attributes.Add("OnClick", "return k(" & id & ");")
        End If
    End Sub

    Private Sub rgCure_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgCure.NeedDataSource
        Dim bao As New BAO_BUDGET.Welfare
        rgCure.DataSource = bao.get_WELFARE(1, BudgetYear, month_nm)
    End Sub

    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgCure)
    End Sub

    Public Sub rebindRg()
        rgCure.Rebind()
    End Sub

    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgCure, str)
    End Sub
End Class