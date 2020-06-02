Imports Telerik.Web.UI
Public Class Frm_Setting_Report19_E_RECEIPT
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            set_dd_bgyear()
        End If
    End Sub
    Public Sub set_dd_bgyear()
        Dim dt As New DataTable
        dt.Columns.Add("byear")
        Dim byearMax As Integer = Year(System.DateTime.Now)
        If byearMax < 2500 Then
            byearMax = byearMax + 543
        End If
        Dim aa As Date = CDate("1/10/" & Year(System.DateTime.Now))
        If CDate(System.DateTime.Now) >= CDate("1/10/" & Year(System.DateTime.Now)) Then
            byearMax = byearMax + 1
        End If
        Dim curent_year As Integer = byearMax


        For i As Integer = 2558 To curent_year '+ 1 '+ 3
            Dim drNew As DataRow = dt.NewRow()
            drNew("byear") = i

            dt.Rows.Add(drNew)
        Next

        Dim dv As DataView = dt.DefaultView
        dv.Sort = "byear desc"
        dt = dv.ToTable()

        dd_BudgetYear.DataSource = dt
        dd_BudgetYear.DataBind()
        'dd_BudgetYear.DropDownSelectData(curent_year)
        'dd_BudgetYear.Items.Insert(0, New ListItem(2558, 2558)) 'เพิ่มใหม่

        'dd_BudgetYear.SelectedValue = 2557
        'dd_BudgetYear.DropDownSelectData(2557)
    End Sub
    Private Sub rg_receive_Init(sender As Object, e As EventArgs) Handles rg_sending.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_sending
        Rad_Utility.addColumnBound("IDA", "IDA", False)
        Rad_Utility.addColumnBound("FULL_RUNNING", "เลขที่นำส่ง", width:=250)
        Rad_Utility.addColumnDate("SEND_DATE", "วันที่นำส่ง")
        'Rad_Utility.addColumnBound("RECEIVE_AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnButton("P", "พิมพ์ใบนำส่ง", "P", 0, "", width:=120)
        Rad_Utility.addColumnButton("edt", "แก้ไข", "edt", 0, "", width:=100)
        'Rad_Utility.addColumnButton("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", width:=100)


    End Sub

    Private Sub rg_sending_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rg_sending.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim edt As LinkButton = DirectCast(item("edt").Controls(0), LinkButton)
            Dim P As LinkButton = DirectCast(item("P").Controls(0), LinkButton)
            Dim id As Integer = item("IDA").Text
            Dim dao As New DAO_MAINTAIN.TB_SEND_MONEY
            dao.Getdata_by_ID(id)
            edt.Attributes.Add("OnClick", "Popups('Frm_Setting_Report19_Insert.aspx?ida=" & id & "&myear=" & dao.fields.BUDGET_YEAR & "&e=1" & "'); return false;")

            Dim url As String = "../Module03/Report/Frm_Report_R3_019.aspx?ida=" & id & "&e=1"
            P.Attributes.Add("OnClick", "window.open('" & url & "', '_blank');")
        End If
    End Sub

    Private Sub rg_sending_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_sending.NeedDataSource
        '
        Dim bao As New BAO_BUDGET.Maintain
        Dim dt As New DataTable
        Try
            If Request.QueryString("law") = "" Then
                dt = bao.get_Data_Send_money_e_receipt_by_Budget_Year(dd_BudgetYear.SelectedValue)
            Else

            End If

        Catch ex As Exception

        End Try

        rg_sending.DataSource = dt
    End Sub

    Private Sub dd_BudgetYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_BudgetYear.SelectedIndexChanged
        rg_sending.Rebind()
    End Sub
End Class