Imports Telerik.Web.UI

Public Class Frm_Check_E_Receipt
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Maintain
        dt = bao.Get_E_RECEIPT_BY_REF01_AND_REF02(txt_ref01.Text, txt_ref02.Text)
        If txt_lcnsid.Text <> "" Then

            RadGrid1.DataSource = dt.Select("LCNSID = '" & txt_lcnsid.Text & "'")
            RadGrid1.Rebind()
        Else
            RadGrid1.DataSource = dt
            RadGrid1.Rebind()
        End If
        'For Each dr As DataRow In dt.Rows
        '    If Len(dr("feeno_format").ToString()) = 0 Then
        '        Dim bao_2 As New BAO_BUDGET.FDA_FEE
        '        Dim dt2 As New DataTable
        '        dt2 = bao_2.Q_get_old_fee(dr("ref01"), dr("ref02"))
        '        dr("feeno_format") = dt2(0)("feeno_format")
        '    End If
        'Next


    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            If e.CommandName = "_receipt" Then
                Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                dao.Getdata_by_ref01_ref02(item("ref01").Text, item("ref02").Text)

                'Dim feeno_re As String = ""
                'feeno_re = dao.fields.FEENO.EncodeBase64()
                'Dim dvcd_re As String = ""
                'dvcd_re = CStr(dao.fields.DVCD).EncodeBase64()
                'Dim feebbr_re As String = ""
                'feebbr_re = dao.fields.FEEABBR.EncodeBase64()
                'Dim bgYear_re As String = ""
                'bgYear_re = CStr(dao.fields.BUDGET_YEAR).EncodeBase64()
                'Dim lcnsid As String = ""
                'lcnsid = CStr(dao.fields.LCNSID).EncodeBase64()
                Dim querystr As String = ""
                Dim feeno_re As String = ""
                feeno_re = dao.fields.FEENO
                Dim dvcd_re As String = ""
                dvcd_re = CStr(dao.fields.DVCD)
                Dim feebbr_re As String = ""
                feebbr_re = dao.fields.FEEABBR
                Dim bgYear_re As String = ""
                bgYear_re = CStr(dao.fields.BUDGET_YEAR)
                querystr = feeno_re & "|" & dvcd_re & "|" & feebbr_re & "|" & bgYear_re



                Dim url_p As String = ""
                url_p = "../Module09/Report/Frm_Report_R9_003.aspx?feeno=" & querystr.EncodeBase64
                'url_p = "../Module09/Report/Frm_Report_R9_003.aspx?feeno=" & feeno_re & "&feeabbr=" & _
                '               feebbr_re & "&lcnsid=" & lcnsid & "&dvcd=" & dvcd_re
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url_p & "', '_blank');", True)
            End If
        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            'Dim item As GridDataItem
            'item = e.Item
            'Dim btn_review As LinkButton = DirectCast(item("btn_receipt").Controls(0), LinkButton)
            'Dim IDA As String = item("IDA").Text
            'Dim dao As New DAO_MAS.TB_LOG_PAY_FROM_SCB
            'dao.GetDataby_IDA(IDA)
            'btn_review.Style.Add("display", "none")
            'Dim check_stat As String = ""
            'Try
            '    check_stat = dao.fields.CHECK_STATUS
            'Catch ex As Exception

            'End Try
            'If check_stat = "1" Then
            '    btn_review.Style.Add("display", "block")
            'End If
        End If
    End Sub
End Class