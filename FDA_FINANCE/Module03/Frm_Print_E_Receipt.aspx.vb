Imports Telerik.Web.UI

Public Class Frm_Print_E_Receipt
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txt_date.Text = Date.Now.ToShortDateString()
        End If
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
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
                'url_p = "../Module09/Report/Frm_Report_R9_003.aspx?feeno=" & querystr.EncodeBase64
                url_p = "../Module09/Report/Frm_Report_R9_003.aspx?ref01=" & item("ref01").Text & "&ref02=" & item("ref02").Text
                'url_p = "../Module09/Report/Frm_Report_R9_003.aspx?feeno=" & feeno_re & "&feeabbr=" & _
                '               feebbr_re & "&lcnsid=" & lcnsid & "&dvcd=" & dvcd_re
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url_p & "', '_blank');", True)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url_p & "', '_blank');", True)


                'ElseIf e.CommandName = "_cancel" Then
                '    Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                '    dao.Getdata_by_ref01_ref02(item("ref01").Text, item("ref02").Text)

                '    Dim dao_ck As New DAO_MAS.TB_LOG_PAY_FROM_SCB
                '    dao_ck.GetDataby_IDA(item("IDA").Text)
                '    dao_ck.fields.CHECK_STATUS = 2
                '    Try
                '        dao_ck.fields.CHECK_DATE = CDate(txt_date.Text)
                '    Catch ex As Exception

                '    End Try
                '    dao_ck.update()

                '    dao.fields.IS_CANCEL = True
                '    Try
                '        dao.fields.CANCEL_DATE = CDate(txt_date.Text)
                '    Catch ex As Exception

                '    End Try
                '    dao.update()
                '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกเรียบร้อย');", True)
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
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Maintain
        If cb_type.Checked = False Then
            Try
                dt = bao.Get_LOG_PAY_FROM_SCB_NORMAL_BY_DATE(CDate(txt_date.Text))
            Catch ex As Exception
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาใส่วันที่ใหม่อีกครั้ง');", True)
            End Try
        Else
            '
            Try
                dt = bao.Get_LOG_PAY_FROM_SCB_L44_BY_DATE(CDate(txt_date.Text))
            Catch ex As Exception
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาใส่วันที่ใหม่อีกครั้ง');", True)
            End Try
        End If

        RadGrid1.DataSource = dt
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        RadGrid1.Rebind()
    End Sub
End Class