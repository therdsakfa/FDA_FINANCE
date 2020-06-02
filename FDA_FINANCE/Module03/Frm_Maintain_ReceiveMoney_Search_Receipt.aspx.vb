Imports Telerik.Web.UI

Public Class Frm_Maintain_ReceiveMoney_Search_Receipt
    Inherits System.Web.UI.Page
    Public bgYear As Integer
    Private _dept As Integer
    Private _bgid As Integer
    Sub runQuery()
        _dept = Request.QueryString("dept")
        _bgid = Request.QueryString("bgid")
        bgYear = Request.QueryString("myear")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            If Request.QueryString("law") <> "" Then
                lbl_type.Text = "ม.44"
            Else
                lbl_type.Text = ""
            End If
            txt_check_date.Text = Date.Now.ToShortDateString()
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


        For i As Integer = 2555 To curent_year '+ 3
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
    Private Sub rg_receive_Init(sender As Object, e As EventArgs) Handles rg_receive.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_receive
        Rad_Utility.addColumnBound("RECEIVE_MONEY_ID", "RECEIVE_MONEY_ID", False)
        Rad_Utility.addColumnBound("RECEIPT_TYPE", "RECEIPT_TYPE", False)

        Rad_Utility.addColumnBound("receipt_no", "เลขที่ใบเสร็จ", width:=150)
        Rad_Utility.addColumnDate("MONEY_RECEIVE_DATE", "วันที่ออกใบเสร็จ")
        Rad_Utility.addColumnBound("FEENO", "เลขที่ชำระ", width:=250)
        Rad_Utility.addColumnBound("RECEIVE_MONEY_DESCRIPTION", "รายการ", width:=350)
        Rad_Utility.addColumnBound("RECEIVE_MONEY_TYPE", "ประเภทเงินที่รับ")
        Rad_Utility.addColumnBound("RECEIVE_AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnButton("P", "พิมพ์ใบเสร็จ", "P", 0, "", width:=120)
        Rad_Utility.addColumnButton("EDT", "แก้ไข", "EDT", 0, "", width:=120)
        Rad_Utility.addColumnButton("cancel", "ยกเลิก", "cancel", 0, "คุณต้องการยกเลิกหรือไม่", width:=100)
        'Rad_Utility.addColumnButton("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", width:=100)


    End Sub
    Private Sub rg_receive_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_receive.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            If e.CommandName = "Delete" Then
                Dim dao_return_money As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                dao_return_money.Getdata_by_RECEIVE_MONEY_ID(item("RECEIVE_MONEY_ID").Text)
                dao_return_money.delete()
                rg_receive.Rebind()
            ElseIf e.CommandName = "cancel" Then
                Dim dao_return_money As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                dao_return_money.Getdata_by_RECEIVE_MONEY_ID(item("RECEIVE_MONEY_ID").Text)
                dao_return_money.fields.IS_CANCEL = True
                dao_return_money.fields.CANCEL_DATE = Date.Now
                Try
                    Dim dao_fee As New DAO_FEE.TB_fee
                    dao_fee.GetDataby_ref1_ref2(dao_return_money.fields.REF01, dao_fee.fields.ref02)
                    dao_fee.fields.rcptst = 0
                    dao_fee.update()
                Catch ex As Exception

                End Try
                dao_return_money.update()
                rg_receive.Rebind()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกเรียบร้อยแล้ว');", True)
            End If
        End If
    End Sub

    Private Sub rg_receive_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_receive.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            If item("RECEIVE_MONEY_TYPE").Text = "1" Then
                item("RECEIVE_MONEY_TYPE").Text = "เงินสด"
            ElseIf item("RECEIVE_MONEY_TYPE").Text = "2" Then
                item("RECEIVE_MONEY_TYPE").Text = "เช็ค"
            ElseIf item("RECEIVE_MONEY_TYPE").Text = "3" Then
                item("RECEIVE_MONEY_TYPE").Text = "ดราฟ"
            ElseIf item("RECEIVE_MONEY_TYPE").Text = "4" Then
                item("RECEIVE_MONEY_TYPE").Text = "แคชเชียร์เช็ค"
            ElseIf item("RECEIVE_MONEY_TYPE").Text = "5" Then
                item("RECEIVE_MONEY_TYPE").Text = "เงินฝากธนาคาร"
            End If

            'Response.Redirect("../Module09/Report/Frm_Report_R9_003.aspx?ID=" & dao_maintain_receive_money.fields.RECEIVE_MONEY_ID)
            Dim id As Integer = item("RECEIVE_MONEY_ID").Text
            Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao.Getdata_by_RECEIVE_MONEY_ID(id)
            Dim P As LinkButton = DirectCast(item("P").Controls(0), LinkButton)
            Dim EDT As LinkButton = DirectCast(item("EDT").Controls(0), LinkButton)
            Dim url As String = ""
            url = "Frm_Maintain_Receive_Money_V2_Edit.aspx?ida=" & id
            'Dim url_p As String = "../Module09/Report/Frm_Report_R9_003.aspx?id_feeno=" & id & "&copy=1" & "&dvcd=" & dao.fields.DVCD & "&feeno=" & dao.fields.FEENO & "&feeabbr=" & dao.fields.FEEABBR & "&myear=" & dao.fields.BUDGET_YEAR
            Dim url_p As String = ""
            If Request.QueryString("law") = "" Then
                If item("RECEIPT_TYPE").Text <> "3" Then
                    url_p = "../Module09/Report/Frm_Report_R9_003.aspx?id_feeno=" & id & "&dvcd=" & dao.fields.DVCD & "&feeno=" & dao.fields.FEENO & "&feeabbr=" & dao.fields.FEEABBR & "&myear=" & dao.fields.BUDGET_YEAR

                Else
                    url_p = "../Module09/Report/Frm_Report_R9_003.aspx?id_feeno=" & id & "&dvcd=" & dao.fields.DVCD & "&feeno=" & dao.fields.FEENO & "&feeabbr=" & dao.fields.FEEABBR & "&myear=" & dao.fields.BUDGET_YEAR & "&rt=3"

                End If
            Else
                url_p = "../Module09/Report/Frm_Report_R9_003.aspx?id_feeno=" & id & "&dvcd=" & dao.fields.DVCD & "&feeno=" & dao.fields.FEENO & "&feeabbr=" & dao.fields.FEEABBR & "&myear=" & dao.fields.BUDGET_YEAR & "&law=1"
            End If


            P.Attributes.Add("OnClick", "Popups('" & url_p & "'); return false;")
            EDT.Attributes.Add("OnClick", "Popups4('" & url & "'); return false;")
        End If
    End Sub

    Private Sub rg_receive_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_receive.NeedDataSource
        Dim bao As New BAO_BUDGET.Maintain
        Dim dt As New DataTable
        If Request.QueryString("law") = "" Then
            Try
                dt = bao.get_RECEPT_by_BUDGET_YEAR_AND_DATE_ALL(dd_BudgetYear.SelectedValue, CDate(txt_check_date.Text))
            Catch ex As Exception

            End Try
        Else
            Try
                dt = bao.get_RECEPT_by_BUDGET_YEAR_AND_DATE_L44_ALL(dd_BudgetYear.SelectedValue, CDate(txt_check_date.Text))
            Catch ex As Exception

            End Try
        End If

        rg_receive.DataSource = dt
    End Sub

    Private Sub txt_check_date_TextChanged(sender As Object, e As EventArgs) Handles txt_check_date.TextChanged
        rg_receive.Rebind()
    End Sub
End Class