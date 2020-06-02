Imports Telerik.Web.UI

Public Class Frm_Maintain_ReceiveMoney_Receipt_Search_Informix
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_dept()
        End If
    End Sub
    Private Function feeno_format() As String
        Dim fee_format As String = ""
        Dim arr_feeno As String() = Nothing
        Try
            arr_feeno = txt_ORDER_PAY2.Text.Split("/")
            Dim _year As String = ""
            _year = arr_feeno(1)
            If _year.Length > 2 Then
                _year = Right(_year, 2)
            End If

            fee_format = _year & arr_feeno(0)
        Catch ex As Exception

        End Try
        Return fee_format
    End Function
    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_Search.Click
        'Dim dt As New DataTable

        'Dim bao As New BAO_BUDGET.FDA_FEE
        ''dt = bao.SP_get_receipt_by_feeabbr_and_feeno(txt_ORDER_PAY2.Text, txt_ORDER_PAY1.Text)
        'Dim feeno As String = feeno_format()
        'Dim dept As Integer = 0
        'Try
        '    dept = ddl_department.SelectedValue
        'Catch ex As Exception

        'End Try
        'If dept = 2 Then
        '    Dim bao2 As New BAO_NCT2.LGT_NCT2
        '    dt = bao2.SP_get_receipt_by_feeabbr_and_feeno_group_sum(feeno, ddl_department.SelectedValue)
        'Else
        '    dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum(feeno, ddl_department.SelectedValue)
        'End If

        'Try
        '    If dt(0)("rcptst") = "0" Then
        '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยังไม่ได้ชำระเงิน');", True)
        '    ElseIf dt(0)("rcptst") = "2" Then
        '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิก');", True)
        '    ElseIf dt(0)("rcptst") = "1" Then
        '        rg_receive.DataSource = dt
        '    End If
        'Catch ex As Exception

        'End Try

        rg_receive.Rebind()
    End Sub

    Private Sub rg_receive_Init(sender As Object, e As EventArgs) Handles rg_receive.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_receive
        Rad_Utility.addColumnBound("lcnsid", "lcnsid", False)
        Rad_Utility.addColumnBound("feeno", "feeno", False)
        Rad_Utility.addColumnBound("feeabbr", "feeabbr", False)
        Rad_Utility.addColumnBound("dvcd", "dvcd", False)
        Rad_Utility.addColumnBound("pvncd", "pvncd", False)
        Rad_Utility.addColumnBound("rcptst", "rcptst", False)
        Rad_Utility.addColumnBound("fullname", "ได้รับเงินจาก", width:=250)
        Rad_Utility.addColumnBound("feetpnm", "รายการ", width:=300)
        Rad_Utility.addColumnBound("amt", "จำนวนเงิน", is_money:=True, width:=70)
        Rad_Utility.addColumnBound("ref01", "ref.01")
        Rad_Utility.addColumnBound("stat", "สถานะ")
        Rad_Utility.addColumnButton("A", "ชำระเงิน", "A", 0, "ต้องการชำระเงินใช่หรือไม่", width:=120)
        Rad_Utility.addColumnButton("P", "พิมพ์ใบเสร็จ", "P", 0, "", width:=120, _display:=False)
    End Sub

    Private Sub rg_receive_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_receive.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "A" Then
                Dim bao As New BAO_INFORMIX.INFORMIX
                bao.update_fee(item("lcnsid").Text, item("feeabbr").Text, item("dvcd").Text, item("pvncd").Text, item("ref01").Text)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ชำระเงินเรียบร้อยแล้ว');", True)
                rg_receive.Rebind()
            End If
        End If
    End Sub

    Private Sub rg_receive_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rg_receive.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim P As LinkButton = DirectCast(item("P").Controls(0), LinkButton)
            Dim A As LinkButton = DirectCast(item("A").Controls(0), LinkButton)
            Dim url_p As String = "../Module09/Report/Frm_Report_R9_003.aspx?se=1&feeno=" & item("feeno").Text & "&feeabbr=" & item("feeabbr").Text & "&lcnsid=" & item("lcnsid").Text & "&dvcd=" & item("dvcd").Text & "&staff=1&myear=" & Request.QueryString("myear")
            P.Attributes.Add("OnClick", "Popups('" & url_p & "'); return false;")

            If item("rcptst").Text = "1" Then
                A.Style.Add("display", "none")
            End If
        End If
    End Sub
    Sub bind_dept()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.SP_MAS_RECEIPT_DEPARTMENT

        ddl_department.DataSource = dt
        ddl_department.DataBind()
    End Sub
    Private Sub rg_receive_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_receive.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_INFORMIX.INFORMIX
        Dim dept As Integer = 0
        Try
            dept = ddl_department.SelectedValue
        Catch ex As Exception

        End Try
        Dim _year As Integer = 0
        _year = Year(Date.Now)
        If _year < 2500 Then
            _year += 543
        End If
        Try
            dt = bao.QUERY_GET_FEE_INFORMIX(feeno_format, txt_ORDER_PAY1.Text, ddl_department.SelectedValue)
        Catch ex As Exception

        End Try

        rg_receive.DataSource = dt
    End Sub
End Class