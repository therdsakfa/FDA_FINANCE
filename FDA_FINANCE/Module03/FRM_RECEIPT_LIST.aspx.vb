Imports Telerik.Web.UI
Public Class FRM_RECEIPT_LIST
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim bao As New BAO_BUDGET.FDA_FEE
            Dim dt As New DataTable
            dt = bao.SC_LCNSID_NM(Request.QueryString("lcnsid"))
            Try
                company_name.Text = dt(0)("fullname")
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub rg_receipt_Init(sender As Object, e As EventArgs) Handles rg_receipt.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_receipt
        Rad_Utility.addColumnBound("lcnsid", "lcnsid", False)
        Rad_Utility.addColumnBound("rcptst", "rcptst", False)
        Rad_Utility.addColumnBound("app", "app", False)
        Rad_Utility.addColumnBound("dvcd", "dvcd", False)
        Rad_Utility.addColumnDate("APPROVE_DATE", "APPROVE_DATE", False)
        Rad_Utility.addColumnBound("feeno", "เลขใบสั่งชำระ", False)
        Rad_Utility.addColumnBound("feeno_full", "เลขใบสั่งชำระ")
        Rad_Utility.addColumnBound("feeabbr", "feeabbr", False)
        Rad_Utility.addColumnBound("fullname", "ได้รับเงินจาก", width:=250)
        Rad_Utility.addColumnBound("feetpnm", "รายการ", width:=300)
        Rad_Utility.addColumnBound("amt", "จำนวนเงิน", is_money:=True, width:=70)
        Rad_Utility.addColumnBound("ref01", "ref.01")
        Rad_Utility.addColumnBound("ref02", "ref.02")
        Rad_Utility.addColumnBound("stat", "สถานะ", width:=150)
        Rad_Utility.addColumnButton("P", "พิมพ์ใบเสร็จ", "P", 0, "", width:=120)
    End Sub

    Private Sub rg_receipt_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_receipt.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            If e.CommandName = "P" Then
                Dim url_p As String = ""
                'If i = 0 Then
                url_p = "../Module09/Report/Frm_Report_R9_003.aspx?feeno=" & item("feeno").Text & "&feeabbr=" & _
                               item("feeabbr").Text & "&lcnsid=" & item("lcnsid").Text & "&dvcd=" & item("dvcd").Text
                'P.Attributes.Add("OnClick", "Popups('" & url_p & "'); return false;")

                '.Attributes.Add("OnClick", "Popups('" & url_p & "'); return false;")
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url_p & "', '_blank');", True)
            End If
        End If


    End Sub

    Private Sub rg_receipt_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rg_receipt.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim P As LinkButton = DirectCast(item("P").Controls(0), LinkButton)

            P.Style.Add("display", "none")

            If item("rcptst").Text = "1" Then
                If item("app").Text = "1" Then
                    P.Style.Add("display", "block")
                Else
                    P.Style.Add("display", "none")
                End If
            ElseIf item("rcptst").Text = "2" Then
                P.Style.Add("display", "none")
            ElseIf item("rcptst").Text = "0" Then
                P.Style.Add("display", "none")
            End If
            Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            Dim i As Integer = 0
            Try
                i = dao.count_receipt33(item("lcnsid").Text, item("feeno").Text, item("dvcd").Text)
            Catch ex As Exception

            End Try

            'Dim url_p As String = ""
            ''If i = 0 Then
            'url_p = "../Module09/Report/Frm_Report_R9_003.aspx?feeno=" & item("feeno").Text & "&feeabbr=" & _
            '               item("feeabbr").Text & "&lcnsid=" & item("lcnsid").Text & "&dvcd=" & item("dvcd").Text
            ''P.Attributes.Add("OnClick", "Popups('" & url_p & "'); return false;")

            ''.Attributes.Add("OnClick", "Popups('" & url_p & "'); return false;")
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url_p & "', '_blank');", True)





            'Else
            '    url_p = "../Module09/Report/Frm_Report_R9_003.aspx?feeno=" & item("feeno").Text & "&feeabbr=" & _
            '                   item("feeabbr").Text & "&lcnsid=" & item("lcnsid").Text & "&copy=1" & "&dvcd=" & item("dvcd").Text
            '    P.Attributes.Add("OnClick", "Popups('" & url_p & "'); return false;")
            'End If


        End If
    End Sub

    Private Sub rg_receipt_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_receipt.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.FDA_FEE 'Request.QueryString("lcnsid")
        dt = bao.SP_get_receipt_customer_by_lcnsid(Request.QueryString("lcnsid"))
        dt.Columns.Add("stat")
        For Each dr As DataRow In dt.Rows
            If dr("rcptst") = "1" Then
                If dr("app") = "1" Then
                    dr("stat") = "สามารถพิมพ์ใบเสร็จได้"
                Else
                    dr("stat") = "รออนุมัติใบเสร็จ"
                End If
            ElseIf dr("rcptst") = "2" Then
                dr("stat") = "ยกเลิก"
            ElseIf dr("rcptst") = "0" Then
                dr("stat") = "ยังไม่ได้ชำระเงิน"
            End If
        Next
        rg_receipt.DataSource = dt
    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Response.Redirect("http://164.115.28.127/FDA_FEE/MAIN/frmc_home.aspx")
    End Sub
End Class