Imports Telerik.Web.UI

Public Class Frm_Search_Receipt
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub rg_receive_Init(sender As Object, e As EventArgs) Handles rg_receive.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_receive
        'Rad_Utility.addColumnBound("RECEIVE_MONEY_ID", "RECEIVE_MONEY_ID", False)
        'Rad_Utility.addColumnBound("RECEIPT_TYPE", "RECEIPT_TYPE", False)

        'Rad_Utility.addColumnBound("receipt_no", "เลขที่ใบเสร็จ", width:=150)
        'Rad_Utility.addColumnDate("MONEY_RECEIVE_DATE", "วันที่ออกใบเสร็จ")
        'Rad_Utility.addColumnBound("FEENO", "เลขที่ชำระ", width:=250)
        'Rad_Utility.addColumnBound("RECEIVE_MONEY_DESCRIPTION", "รายการ", width:=350)
        'Rad_Utility.addColumnBound("RECEIVE_MONEY_TYPE", "ประเภทเงินที่รับ")
        'Rad_Utility.addColumnBound("RECEIVE_AMOUNT", "จำนวนเงิน", is_money:=True)

        Rad_Utility.addColumnBound("feeno_full", "เลขสั่งชำระ")
        Rad_Utility.addColumnDate("ref01", "เลขอ้างอิง Ref01")
        Rad_Utility.addColumnDate("ref02", "เลขอ้างอิง Ref02")

        'Rad_Utility.addColumnBound("stat", "สถานะ", width:=250)



        'Rad_Utility.addColumnButton("P", "พิมพ์ใบเสร็จ", "P", 0, "", width:=120)
        'Rad_Utility.addColumnButton("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", width:=100)
    End Sub

    Private Sub rg_receive_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rg_receive.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            'If item("RECEIVE_MONEY_TYPE").Text = "1" Then
            '    item("RECEIVE_MONEY_TYPE").Text = "เงินสด"
            'ElseIf item("RECEIVE_MONEY_TYPE").Text = "2" Then
            '    item("RECEIVE_MONEY_TYPE").Text = "เช็ค"
            'ElseIf item("RECEIVE_MONEY_TYPE").Text = "3" Then
            '    item("RECEIVE_MONEY_TYPE").Text = "ดราฟ"
            'ElseIf item("RECEIVE_MONEY_TYPE").Text = "4" Then
            '    item("RECEIVE_MONEY_TYPE").Text = "แคชเชียร์เช็ค"
            'ElseIf item("RECEIVE_MONEY_TYPE").Text = "5" Then
            '    item("RECEIVE_MONEY_TYPE").Text = "เงินฝากธนาคาร"
            'End If

            'Response.Redirect("../Module09/Report/Frm_Report_R9_003.aspx?ID=" & dao_maintain_receive_money.fields.RECEIVE_MONEY_ID)
            'Dim id As Integer = item("RECEIVE_MONEY_ID").Text
            'Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            'dao.Getdata_by_RECEIVE_MONEY_ID(id)
            'Dim P As LinkButton = DirectCast(item("P").Controls(0), LinkButton)
            'Dim url As String = ""
            'url = "Frm_Maintain_Receive_Money_V2_Edit.aspx?ida=" & id
            ' ''Dim url_p As String = "../Module09/Report/Frm_Report_R9_003.aspx?id_feeno=" & id & "&copy=1" & "&dvcd=" & dao.fields.DVCD & "&feeno=" & dao.fields.FEENO & "&feeabbr=" & dao.fields.FEEABBR & "&myear=" & dao.fields.BUDGET_YEAR
            'Dim url_p As String = ""
            'If item("RECEIPT_TYPE").Text <> "3" Then
            '    url_p = "../Module09/Report/Frm_Report_R9_003.aspx?ref01=" & dao.fields.REF01 & "&ref02=" & dao.fields.REF02
            'Else
            '    url_p = "../Module09/Report/Frm_Report_R9_003.aspx?ref01=" & dao.fields.REF01 & "&ref02=" & dao.fields.REF02 & "&rt=3"

            'End If
            'P.Attributes.Add("OnClick", "Popups('" & url_p & "'); return false;")
        End If
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim bao As New BAO_BUDGET.Maintain
        Dim dt As New DataTable
        Try
            dt = bao.get_RECEPT_by_ref01_and_ref02(txt_ref01.Text, txt_ref02.Text)
        Catch ex As Exception

        End Try
        dt.Columns.Add("stat")
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                dr("stat") = Get_Status(dr("ref01"), dr("ref02"))
            Next
            rg_receive.DataSource = dt
            rg_receive.Rebind()
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
        End If
        '
    End Sub
    Public Function Get_Status(ByVal ref01 As String, ByVal ref02 As String) As String
        Dim status_text As String = ""
        Try
            Dim dao_fee As New DAO_FEE.TB_fee
            dao_fee.GetDataby_ref1_ref2(ref01, ref02)
            If dao_fee.fields.rcptst = 0 Then
                status_text = "ยังไม่ได้ชำระเงิน"
            ElseIf dao_fee.fields.rcptst = 1 Then
                Dim dao_re As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                Dim bool As Boolean
                bool = dao_re.count_receipt_by_ref(ref01, ref02)

                If bool = True Then
                    status_text = "ออกใบเสร็จแล้ว"
                Else
                    status_text = "รอการอนุมัติออกใบเสร็จ"
                End If


            End If
        Catch ex As Exception

        End Try

        Return status_text
    End Function
End Class