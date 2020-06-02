Imports Telerik.Web.UI
Public Class Uc_Report_Disburse_Relate_withdraw
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
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnBound("DETAIL_ID", "DETAIL_ID", False)
        Rad_Utility.addColumnBound("IDA", "IDA", False)
        Rad_Utility.addColumnBound("BillCode", "เลขรับ", width:=45)
        'Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร", width:=100)
        Rad_Utility.addColumnBound("Type_payName", "ประเภทการจ่าย", width:=100)
        Rad_Utility.addColumnBound("Type_payName_withdraw", "ประเภทการจ่าย", width:=100)
        Rad_Utility.addColumnBound("CUSTOMER_NAME", "เจ้าหนี้/ผู้รับเงิน", width:=100)

        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินขอเบิก", width:=80, is_money:=True)
        Rad_Utility.addColumnBound("nVat2", "ภาษี", width:=80, is_money:=True)
        Rad_Utility.addColumnBound("nMulct2", "ค่าปรับ", width:=80, is_money:=True)
        Rad_Utility.addColumnBound("nInsurance2", "เงินประกันผลงาน", width:=80, is_money:=True)
        Rad_Utility.addColumnBound("AMOUNT_MONEY2", "เงินสุทธิ", width:=80, is_money:=True)
        '    Rad_Utility.addColumnHyper("A", "รายงานหัก ณ ที่จ่าย", "A", 0, "")
        Rad_Utility.addColumnImg2("A", "รายงานหัก ณ ที่จ่าย", "A", 0, "", img:=True, type_img:="report1", width:=12, headertext:="รายงานหัก ณ ที่จ่าย")

        'Rad_Utility.addColumnButton("B", "บันทึกฏีกาเบิกเงินงบประมาณ", "B", 0, "")
        'Rad_Utility.addColumnButton("E", "ลบเลขขบ.", "E", 0, "คุณต้องการลบเลข GFMIS หรือไม่")
    End Sub

    Private Sub rg_list_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_list.NeedDataSource

        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL

        dt = bao.get_relate_det_by_year(_BudgetYear)
        dt.Columns.Add("AMOUNT_MONEY2", GetType(Double))
        dt.Columns.Add("nVat2", GetType(Double))
        dt.Columns.Add("nMulct2", GetType(Double))
        dt.Columns.Add("nInsurance2", GetType(Double))

        For Each dr As DataRow In dt.Rows
            If IsDBNull(dr("AMOUNT_MONEY")) = False Then
                If dr("AMOUNT_MONEY") <> 0 Then
                    dr("AMOUNT_MONEY2") = dr("AMOUNT_MONEY")
                Else
                    dr("AMOUNT_MONEY2") = 0
                End If
            Else
                dr("AMOUNT_MONEY2") = 0
            End If
            '--------------------------------------------------
            If IsDBNull(dr("nVat")) = False Then
                If dr("nVat") <> 0 Then
                    dr("nVat2") = dr("nVat")
                Else
                    dr("nVat2") = 0
                End If
            Else
                dr("nVat2") = 0
            End If
            '-------------------------------------------------
            If IsDBNull(dr("nMulct")) = False Then
                If dr("nMulct") <> 0 Then
                    dr("nMulct2") = dr("nMulct")
                Else
                    dr("nMulct2") = 0
                End If
            Else
                dr("nMulct2") = 0
            End If
            '------------------------------------------------
            If IsDBNull(dr("nInsurance")) = False Then
                If dr("nInsurance") <> 0 Then
                    dr("nInsurance2") = dr("nInsurance")
                Else
                    dr("nInsurance2") = 0
                End If
            Else
                dr("nInsurance2") = 0
            End If
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

    '        Dim h2 As ImageButton = DirectCast(item("A").Controls(0), ImageButton)
    '        Dim lnk_ist As String = ""
    '        lnk_ist = "../../../Module02/Report/Frm_Report_R2_029.aspx?id=" & item("IDA").Text & "&dept=" & Request.QueryString("dept") & "&bgyear=" & Request.QueryString("myear") & "&Citizen=" & _Citizen

    '        h2.PostBackUrl = lnk_ist
    '        h2.Target = "_blank"

    '    End If
    'End Sub

    Private Sub rg_ProjectList_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_list.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "A" Then
                Dim _Id As Integer = item("IDA").Text
                ' Response.Redirect("../../../Module02/Report/Frm_Report_R2_029.aspx?id=" & item("IDA").Text & "&dept=" & Request.QueryString("dept") & "&bgyear=" & Request.QueryString("myear") & "&Citizen=" & _Citizen)

                Dim url As String = "../../Module02/Report/Frm_Report_R2_029.aspx?id=" & item("IDA").Text & "&dept=" & Request.QueryString("dept") & "&bgyear=" & Request.QueryString("myear") & "&Citizen=" & _Citizen
                Response.Write("<script>")
                Response.Write("window.open('" & url & "','_blank')")
                Response.Write("</script>")

            End If
        End If
    End Sub
End Class