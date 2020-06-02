Imports Telerik.Web.UI
Public Class uc_disburse_budget_bill_withdraw_v3
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
    Private _Citizen As String
    Public Property Citizen() As String
        Get
            Return _Citizen
        End Get
        Set(ByVal value As String)
            _Citizen = value
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
    Private _ispo As String
    Public Property ispo() As String
        Get
            Return _ispo
        End Get
        Set(ByVal value As String)
            _ispo = value
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
    Private _bguse As Integer
    Public Property bguse() As Integer
        Get
            Return _bguse
        End Get
        Set(ByVal value As Integer)
            _bguse = value
        End Set
    End Property
    Private _type As Integer
    Public Property type() As Integer
        Get
            Return _type
        End Get
        Set(ByVal value As Integer)
            _type = value
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
    Private _is_rebill As Boolean
    Public Property is_rebill() As Boolean
        Get
            Return _is_rebill
        End Get
        Set(ByVal value As Boolean)
            _is_rebill = value
        End Set
    End Property

    Private _is_no_rebill As Boolean
    Public Property is_no_rebill() As Boolean
        Get
            Return _is_no_rebill
        End Get
        Set(ByVal value As Boolean)
            _is_no_rebill = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_list_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rg_list.Init

        Dim rg_Approve As RadGrid = rg_list
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_list
        Rad_Utility.addColumnBound2("ID", "ID", False)
        Rad_Utility.addColumnDate2("DateDeka", "วันที่ฏีกา", width:=100)
        Rad_Utility.addColumnBound2("DakaTypeName", "ประเภทฏีกา", width:=100, is_center:=2)
        Rad_Utility.addColumnBound2("DekaBillNumber", "เลขที่ฎึกา", width:=50, is_center:=2)
        Rad_Utility.addColumnBound2("Name_Disburse", "ชื่อผู้เบิก", width:=150, is_center:=2)
        Rad_Utility.addColumnImg2("A", "เพิ่มรายละเอียดใบฏีกา", "A", 0, "", img:=True, type_img:="activity", width:=12, headertext:="เพิ่มรายละเอียดใบฏีกา")
        Rad_Utility.addColumnImg2("E", "แก้ไขใบฏีกา", "E", 0, "", img:=True, type_img:="edit", width:=12, headertext:="แก้ไขใบฏีกา")
        Rad_Utility.addColumnImg2("R", "รายงานใบฎีกา", "R", 0, "", img:=True, type_img:="report1", width:=12, headertext:="รายงานใบฎีกา")

        'Rad_Utility.addColumnButton("A", "รับเรื่องเบิก", "A", 0, "")
        'Rad_Utility.addColumnButton("A", "รับเรื่องเบิก", "A", 0, "")

    End Sub

    Private Sub rg_list_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_list.NeedDataSource

        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET()

        dt = bao.get_all_deka_bill_by_year(Budgetyear)

        rg_list.DataSource = dt

    End Sub

    Public Sub search(ByVal year As String, ByVal bill As String)

        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET()

        dt = bao.get_all_deka_bill_by_year(Budgetyear)


        Dim bao_search As New ClassDataset
        Dim dt_ As New DataTable

        Dim strwhere As String = ""

        strwhere = "[BudgetYear] like '" & year & "' and [DekaBillNumber] like '" & bill & "'"

        dt_ = bao_search.DatatableWhere(dt, strwhere)

        rg_list.DataSource = dt_
        ' rg_list.DataBind()


    End Sub

    Private Sub rg_ProjectList_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_list.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "R" Then
                Dim _Id As Integer = item("ID").Text
                ' Response.Redirect("../../../Module02/Report/Frm_Report_R2_029.aspx?id=" & item("IDA").Text & "&dept=" & Request.QueryString("dept") & "&bgyear=" & Request.QueryString("myear") & "&Citizen=" & _Citizen)

                Dim url As String = "../../Module02/Report/Frm_Report_R2_028.aspx?id=" & item("ID").Text & "&dept=" & Request.QueryString("dept") & "&bgyear=" & Request.QueryString("myear") & "&Citizen=" & _Citizen
                Response.Write("<script>")
                Response.Write("window.open('" & url & "','_blank')")
                Response.Write("</script>")

            End If
        End If
    End Sub

    Private Sub rg_list_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles rg_list.ItemDataBound

        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim lnk_ist As String = ""
            lnk_ist = "../../Module02/Disburse_Budget/Frm_Disburse_Budget_add_withdraw_deka1.aspx?id_deka=" & item("ID").Text & "&bgYear=" & Request.QueryString("myear") & "&Citizen=" & _Citizen

            Dim h2 As ImageButton = DirectCast(item("A").Controls(0), ImageButton)
            h2.Attributes.Add("OnClick", "Popups3('" & lnk_ist & "'); return false;")

            Dim lnk_edit As String = ""
            lnk_edit = "../../Module02/Disburse_Budget/Frm_Disburse_Budget_add_withdraw_deka.aspx?id_deka=" & item("ID").Text & "&bgYear=" & Request.QueryString("myear") & "&Citizen=" & _Citizen

            Dim h3 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            h3.Attributes.Add("OnClick", "Popups2('" & lnk_edit & "'); return false;")


        End If
    End Sub

    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_list, str)
    End Sub

    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rg_list)
        'rg_Disburse_Budget.Rebind()
    End Sub

    Public Sub rgRebind()
        rg_list.Rebind()
    End Sub

End Class