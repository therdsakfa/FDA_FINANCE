Imports Telerik.Web.UI
Public Class Uc_Report_Disburse_Relate_withdraw2
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
    Private _Citizen As String
    Public Property Citizen() As String
        Get
            Return _Citizen
        End Get
        Set(ByVal value As String)
            _Citizen = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgAddKNumber_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rg_list.Init
        Dim rg_Approve As RadGrid = rg_list
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_list

        Rad_Utility.addColumnBound("ID", "ID", False)

        Rad_Utility.addColumnBound("DakaTypeName", "ประเภทฏีกา", width:=150)
        Rad_Utility.addColumnBound("DekaBillNumber", "เลขที่ฏีกา", width:=45)

        Rad_Utility.addColumnBound("Date_Deka", "วันที่ทำฏีกา", width:=100)
        Rad_Utility.addColumnBound("Name_Disburse", "ชื่อผู้เบิก", width:=150)

        'Rad_Utility.addColumnBound("AMOUNT", "ประจำเดือน", width:=80, is_money:=True)
        'Rad_Utility.addColumnBound("nVat", "ภาษี", width:=80, is_money:=True)
        'Rad_Utility.addColumnBound("nMulct", "ค่าปรับ", width:=80, is_money:=True)
        'Rad_Utility.addColumnBound("nInsurance", "เงินประกันผลงาน", width:=80, is_money:=True)
        'Rad_Utility.addColumnBound("AMOUNT_MONEY", "เงินสุทธิ", width:=80, is_money:=True)
        ' Rad_Utility.addColumnHyper("A", "รายงานใบฎีกา", "A", 0, "")
        Rad_Utility.addColumnImg2("A", "รายงานใบฎีกา", "A", 0, "", img:=True, type_img:="report1", width:=12, headertext:="รายงานใบฎีกา")

    End Sub

    Private Sub rg_list_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_list.NeedDataSource

        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL

        dt = bao.get_deka_bill_by_year(_BudgetYear)
        dt.Columns.Add("Date_Deka", GetType(String))

        For Each dr As DataRow In dt.Rows

            Dim _DateTime As String = (dr("DateDeka")).ToString.ToShortThaiDate
            dr("Date_Deka") = _DateTime

        Next

        rg_list.DataSource = dt

    End Sub

    Public Sub rebind_grid()
        rg_list.Rebind()
    End Sub

    'Private Sub rgAddKNumber_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles rg_list.ItemDataBound

    '    If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
    '        Dim item As GridDataItem
    '        item = e.Item

    '        Dim h2 As HyperLink = DirectCast(item("A").Controls(0), HyperLink)
    '        Dim lnk_ist As String = ""
    '        lnk_ist = "../../../Module02/Report/Frm_Report_R2_028.aspx?id=" & item("ID").Text & "&dept=" & Request.QueryString("dept") & "&bgyear=" & Request.QueryString("myear") & "&Citizen=" & _Citizen

    '        h2.NavigateUrl = lnk_ist
    '        h2.Target = "_blank"

    '    End If
    '  End Sub

    Private Sub rg_ProjectList_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_list.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "A" Then
                Dim _Id As Integer = item("ID").Text
                ' Response.Redirect("../../../Module02/Report/Frm_Report_R2_029.aspx?id=" & item("IDA").Text & "&dept=" & Request.QueryString("dept") & "&bgyear=" & Request.QueryString("myear") & "&Citizen=" & _Citizen)

                Dim url As String = "../../Module02/Report/Frm_Report_R2_028.aspx?id=" & item("ID").Text & "&dept=" & Request.QueryString("dept") & "&bgyear=" & Request.QueryString("myear") & "&Citizen=" & _Citizen
                Response.Write("<script>")
                Response.Write("window.open('" & url & "','_blank')")
                Response.Write("</script>")

            End If
        End If
    End Sub
End Class