Imports Telerik.Web.UI

Public Class Frm_Maintain_ReceiveMoney_Receipt_Search
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
            fee_format = arr_feeno(1) & arr_feeno(0)
        Catch ex As Exception

        End Try
        Return fee_format
    End Function
    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_Search.Click
        Dim dt As New DataTable

        Dim bao As New BAO_BUDGET.FDA_FEE
        'dt = bao.SP_get_receipt_by_feeabbr_and_feeno(txt_ORDER_PAY2.Text, txt_ORDER_PAY1.Text)
        Dim feeno As String = feeno_format()
        Dim dept As Integer = 0
        Try
            dept = ddl_department.SelectedValue
        Catch ex As Exception

        End Try
        If dept = 2 Then
            Dim bao2 As New BAO_NCT2.LGT_NCT2
            dt = bao2.SP_get_receipt_by_feeabbr_and_feeno_group_sum(feeno, ddl_department.SelectedValue)
        Else
            dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum(feeno, ddl_department.SelectedValue)
        End If

        Try
            If dt(0)("rcptst") = "0" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยังไม่ได้ชำระเงิน');", True)
            ElseIf dt(0)("rcptst") = "2" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิก');", True)
            ElseIf dt(0)("rcptst") = "1" Then
                rg_receive.DataSource = dt
            End If
        Catch ex As Exception

        End Try
        'Dim count_row As Integer = 0
        'Dim dt_count As Integer = 0
        'Try
        '    count_row = dt.Rows.Count
        'Catch ex As Exception

        'End Try

        'For i As Integer = 0 To dt.Rows.Count - 1
        '    dt_count += 1
        'Next
        'If count_row = dt_count Then
        '    rg_receive.DataSource = dt
        'End If

        'If dt.Rows.Count > 0 Then

        '    If dt_count + count_row = 0 Then
        '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยังไม่ได้ชำระเงิน');", True)
        '        'Else
        '        '    If dt_count = dt_count Then

        '        '    End If
        '    End If
        'Else
        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
        'End If

        rg_receive.Rebind()
    End Sub

    Private Sub rg_receive_Init(sender As Object, e As EventArgs) Handles rg_receive.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_receive
        Rad_Utility.addColumnBound("lcnsid", "lcnsid", False)
        Rad_Utility.addColumnBound("feeno", "feeno", False)
        Rad_Utility.addColumnBound("feeabbr", "feeabbr", False)
        Rad_Utility.addColumnBound("dvcd", "dvcd", False)
        Rad_Utility.addColumnBound("fullname", "ได้รับเงินจาก", width:=250)
        Rad_Utility.addColumnBound("feetpnm", "รายการ", width:=300)
        Rad_Utility.addColumnBound("amt", "จำนวนเงิน", is_money:=True, width:=70)
        Rad_Utility.addColumnBound("ref01", "ref.01")
        Rad_Utility.addColumnBound("ref02", "ref.02")
        Rad_Utility.addColumnButton("P", "พิมพ์ใบเสร็จ", "P", 0, "", width:=120)
    End Sub

    Private Sub rg_receive_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rg_receive.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim P As LinkButton = DirectCast(item("P").Controls(0), LinkButton)
            'Dim url_p As String = "../Module09/Report/Frm_Report_R9_003.aspx?se=1&feeno=" & item("feeno").Text & "&feeabbr=" & item("feeabbr").Text & "&lcnsid=" & item("lcnsid").Text & "&dvcd=" & item("dvcd").Text & "&staff=1&myear=" & Request.QueryString("myear")
            Dim uri As String = ""
            Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao.Getdata_by_ref01_ref02(item("ref01").Text, item("ref02").Text)
            uri = Request.Url.AbsoluteUri & "&ida=" & dao.fields.RECEIVE_MONEY_ID


            Dim dao22 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao22.Getdata_by_RECEIVE_MONEY_ID(dao.fields.RECEIVE_MONEY_ID)

            Dim querystr As String = ""
            Dim is_l44 As String = ""
            Try
                is_l44 = dao22.fields.IS_L44
            Catch ex As Exception
                is_l44 = ""
            End Try
            Dim feeno_re As String = ""
            feeno_re = dao22.fields.FEENO
            Dim dvcd_re As String = ""
            dvcd_re = CStr(dao22.fields.DVCD)
            Dim feebbr_re As String = ""
            feebbr_re = dao22.fields.FEEABBR
            Dim bgYear_re As String = ""
            bgYear_re = CStr(dao22.fields.BUDGET_YEAR)
            querystr = feeno_re & "|" & dvcd_re & "|" & feebbr_re & "|" & bgYear_re

            Dim url As String = "../Module09/Report/Frm_Report_R9_003.aspx?id_feeno=" & dao.fields.RECEIVE_MONEY_ID & "&dvcd=" & dao22.fields.DVCD & "&feeno=" & dao22.fields.FEENO & "&feeabbr=" & dao22.fields.FEEABBR & "&myear=" & dao22.fields.BUDGET_YEAR
            Dim url2 As String = "../Module09/Report/Frm_Report_R9_003.aspx?feeno=" & querystr.EncodeBase64 'dao22.fields.FEENO & "&dvcd=" & dao22.fields.DVCD & "&feeabbr=" & dao22.fields.FEEABBR & "&myear=" & dao22.fields.BUDGET_YEAR
            'If Request.QueryString("law") <> "" Then
            '    insert_e_bill(dvcd_re, feeno_re, feebbr_re)
            'End If

            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "', '_blank');", True)

            If Request.QueryString("law") = "" Then
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "', '_blank'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
                P.Attributes.Add("OnClick", "Popups('" & url & "'); return false;")
            Else
                url &= "&law=1"
                P.Attributes.Add("OnClick", "Popups('" & url & "'); return false;")
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "', '_blank'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)

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
        Dim bao As New BAO_BUDGET.FDA_FEE
        'dt = bao.SP_get_receipt_by_feeabbr_and_feeno(txt_ORDER_PAY2.Text, txt_ORDER_PAY1.Text)
        'dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum(feeno_format, ddl_department.SelectedValue)

        Dim dept As Integer = 0
        Try
            dept = ddl_department.SelectedValue
        Catch ex As Exception

        End Try
        If dept = 2 Then
            Dim bao2 As New BAO_NCT2.LGT_NCT2
            dt = bao2.SP_get_receipt_by_feeabbr_and_feeno_group_sum(feeno_format(), dept)
        Else
            dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum(feeno_format(), dept)
        End If

        Dim count_row As Integer = 0
        Dim dt_count As Integer = 0
        Try
            count_row = dt.Rows.Count
        Catch ex As Exception

        End Try
        'If dt.Rows.Count > 0 Then
        Try
            If dt(0)("rcptst") = "1" Then
                rg_receive.DataSource = dt
            End If
        Catch ex As Exception

        End Try

        'For i As Integer = 0 To dt.Rows.Count - 1
        '    dt_count += 1
        'Next
        'If count_row = dt_count Then
        '    rg_receive.DataSource = dt
        'End If
        'Else
        'End If

    End Sub
End Class