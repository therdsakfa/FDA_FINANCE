Imports Microsoft.Reporting.WebForms
Public Class Frm_Report_R3_018
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_ddl_receiver()
            run_hide_show()
        End If
    End Sub
    Sub bind_ddl_receiver()
        Dim dao As New DAO_MAS.TB_MAS_MONEY_RECEIVER
        dao.Get_All_RECEIVER()

        ddl_receiver.DataSource = dao.datas
        ddl_receiver.DataTextField = "RECEIVER_NAME"
        ddl_receiver.DataValueField = "RECEIVER_MONEY_ID"
        ddl_receiver.DataBind()


        Dim item As New ListItem
        item.Text = "ทั้งหมด"
        item.Value = "0"
        ddl_receiver.Items.Insert(0, item)
    End Sub
    Sub bind_ddl_printer()
        Dim dao As New DAO_MAS.TB_MAS_MONEY_RECEIVER
        dao.Get_All_RECEIVER()

        ddl_print.DataSource = dao.datas
        ddl_print.DataTextField = "RECEIVER_NAME"
        ddl_print.DataValueField = "RECEIVER_MONEY_ID"
        ddl_print.DataBind()

    End Sub
    Sub run_hide_show()
        If ddl_receiver.SelectedValue = "0" Then
            ddl_print.Style.Add("display", "block")
            Label1.Style.Add("display", "block")
            bind_ddl_printer()
        Else
            ddl_print.Style.Add("display", "none")
            Label1.Style.Add("display", "none")
            bind_ddl_printer()
        End If
    End Sub
    Public Function getReportData()
        Dim bao As New BAO_BUDGET.Report
        'Dim bao2 As New BAO_BUDGET.Report
        UC_Report_SelectDate_Between1.getDateSelect()
        Dim dt As New DataTable
        If Request.QueryString("e") = "" Then
                If Request.QueryString("law") <> "" Then
                If Request.QueryString("n") <> "" Then
                    If ddl_receiver.SelectedValue = "0" Then
                        dt = bao.get_Report_R3_018_n_law(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                    Else
                        dt = bao.get_Report_R3_018_n_law_new(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, ddl_receiver.SelectedValue)
                    End If

                    Dim dt_c_count As New DataTable
                    Dim dt_c_money As New DataTable
                    If ddl_receiver.SelectedValue = "0" Then
                        dt_c_count = bao.get_receive_cancel_count_n_law(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                        dt_c_money = bao.get_receive_cancel_money_n_law(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                    Else
                        dt_c_count = bao.get_receive_cancel_count_n_law_new(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, ddl_receiver.SelectedValue)
                        dt_c_money = bao.get_receive_cancel_money_n_law_new(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, ddl_receiver.SelectedValue)
                    End If
                    

                    If dt.Rows.Count > 0 Then
                        Try
                            dt(0)("count_cancel") = dt_c_count(0)("count_cancel")
                        Catch ex As Exception
                            dt(0)("count_cancel") = 0
                        End Try

                        Try
                            dt(0)("cancel_Amount") = dt_c_money(0)("money_cancel")
                        Catch ex As Exception
                            dt(0)("cancel_Amount") = dt_c_money(0)("money_cancel")
                        End Try
                    End If
                Else
                    If ddl_receiver.SelectedValue = "0" Then
                        dt = bao.get_Report_R3_018_e_law(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                    Else
                        dt = bao.get_Report_R3_018_e_law_new(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, ddl_receiver.SelectedValue)
                    End If

                    Dim dt_c_count As New DataTable
                    Dim dt_c_money As New DataTable
                    If ddl_receiver.SelectedValue = "0" Then
                        dt_c_count = bao.get_receive_cancel_count_e_law(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                        dt_c_money = bao.get_receive_cancel_money_e_law(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                    Else
                        dt = dt_c_count = bao.get_receive_cancel_count_e_law_new(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, ddl_receiver.SelectedValue)
                        dt_c_money = bao.get_receive_cancel_money_e_law_new(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, ddl_receiver.SelectedValue)
                    End If

                    If dt.Rows.Count > 0 Then
                        Try
                            dt(0)("count_cancel") = dt_c_count(0)("count_cancel")
                        Catch ex As Exception
                            dt(0)("count_cancel") = 0
                        End Try

                        Try
                            dt(0)("cancel_Amount") = dt_c_money(0)("money_cancel")
                        Catch ex As Exception
                            dt(0)("cancel_Amount") = dt_c_money(0)("money_cancel")
                        End Try
                    End If
                End If
            Else
                If ddl_receiver.SelectedValue = "0" Then
                    dt = bao.get_Report_R3_018(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                Else
                    dt = bao.get_Report_R3_018_V2(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, ddl_receiver.SelectedValue)
                End If

            End If

            Else
                If Request.QueryString("law") <> "" Then
                    If Request.QueryString("n") <> "" Then
                    'dt = bao.get_Report_R3_018_n_law(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                    If ddl_receiver.SelectedValue = "0" Then
                        dt = bao.get_Report_R3_018_n_law(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                    Else
                        dt = bao.get_Report_R3_018_n_law_new(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, ddl_receiver.SelectedValue)
                    End If

                    Dim dt_c_count As New DataTable
                    Dim dt_c_money As New DataTable
                    dt_c_count = bao.get_receive_cancel_count_n_law(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                    dt_c_money = bao.get_receive_cancel_money_n_law(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                    If dt.Rows.Count > 0 Then
                        Try
                            dt(0)("count_cancel") = dt_c_count(0)("count_cancel")
                        Catch ex As Exception
                            dt(0)("count_cancel") = 0
                        End Try

                        Try
                            dt(0)("cancel_Amount") = dt_c_money(0)("money_cancel")
                        Catch ex As Exception
                            dt(0)("cancel_Amount") = dt_c_money(0)("money_cancel")
                        End Try
                    End If
                Else

                    'dt = bao.get_Report_R3_018_e_law(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                    If ddl_receiver.SelectedValue = "0" Then
                        dt = bao.get_Report_R3_018_e_law(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                    Else
                        dt = bao.get_Report_R3_018_e_law_new(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, ddl_receiver.SelectedValue)
                    End If

                    Dim dt_c_count As New DataTable
                    Dim dt_c_money As New DataTable
                    If ddl_receiver.SelectedValue = "0" Then
                        dt_c_count = bao.get_receive_cancel_count_e_law(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                        dt_c_money = bao.get_receive_cancel_money_e_law(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                    Else
                        dt = dt_c_count = bao.get_receive_cancel_count_e_law_new(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, ddl_receiver.SelectedValue)
                        dt_c_money = bao.get_receive_cancel_money_e_law_new(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, ddl_receiver.SelectedValue)
                    End If
                    If dt.Rows.Count > 0 Then
                        Try
                            dt(0)("count_cancel") = dt_c_count(0)("count_cancel")
                        Catch ex As Exception
                            dt(0)("count_cancel") = 0
                        End Try

                        Try
                            dt(0)("cancel_Amount") = dt_c_money(0)("money_cancel")
                        Catch ex As Exception
                            dt(0)("cancel_Amount") = dt_c_money(0)("money_cancel")
                        End Try
                    End If
                    End If
            Else
                If ddl_receiver.SelectedValue = "0" Then
                    dt = bao.get_Report_R3_018_e(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                Else
                    dt = bao.get_Report_R3_018_e_new(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, ddl_receiver.SelectedValue)
                End If

                Dim dt_c_count As New DataTable
                Dim dt_c_money As New DataTable
                If ddl_receiver.SelectedValue = "0" Then
                    dt_c_count = bao.Get_get_receive_cancel_count_e(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                    dt_c_money = bao.Get_get_receive_cancel_money_e(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                Else
                    dt_c_count = bao.get_receive_cancel_count_e_new(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, ddl_receiver.SelectedValue)
                    dt_c_money = bao.get_receive_cancel_money_e_new(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, ddl_receiver.SelectedValue)
                End If

                If dt.Rows.Count > 0 Then
                    Try
                        dt(0)("count_cancel") = dt_c_count(0)("count_cancel")
                    Catch ex As Exception
                        dt(0)("count_cancel") = 0
                    End Try

                    Try
                        dt(0)("cancel_Amount") = dt_c_money(0)("money_cancel")
                    Catch ex As Exception
                        dt(0)("cancel_Amount") = dt_c_money(0)("money_cancel")
                    End Try
                End If

                End If

        End If
        dt.Columns.Add("print_name")
        If ddl_receiver.SelectedValue = "0" Then
            For Each dr As DataRow In dt.Rows
                dr("print_name") = ddl_print.SelectedItem.Text
            Next
        End If
            Return dt
    End Function
    
    Function get_sb_dt() As DataTable
        UC_Report_SelectDate_Between1.getDateSelect()
        Dim bao_r As New BAO_BUDGET.Report

        Dim dt_sb As New DataTable
        dt_sb.Columns.Add("IDA")
        dt_sb.Columns.Add("INCOME_NAME")
        dt_sb.Columns.Add("INCOME_CODE")
        dt_sb.Columns.Add("sum_amount", GetType(Double))
        dt_sb.Columns.Add("sum_sinbon_amount", GetType(Double))
        dt_sb.Columns.Add("bank_deposit", GetType(Double))
        dt_sb.Columns.Add("check_amt", GetType(Double))
        dt_sb.Columns.Add("cash_amt", GetType(Double))
        dt_sb.Columns.Add("dateBeginName")
        dt_sb.Columns.Add("dateEndName")
        Dim dr1 As DataRow = dt_sb.NewRow()
        Dim dr2 As DataRow = dt_sb.NewRow()
        dr1("IDA") = 17
        dr1("INCOME_NAME") = "สินบนรางวัล"
        dr1("INCOME_CODE") = "658"
        dr1("sum_amount") = 0
        dr1("sum_sinbon_amount") = 0
        dr1("bank_deposit") = 0
        dr1("check_amt") = 0
        dr1("cash_amt") = 0
        dr1("dateBeginName") = bao_r.convertDateToString(UC_Report_SelectDate_Between1.dateBegin)
        dr1("dateEndName") = bao_r.convertDateToString(UC_Report_SelectDate_Between1.dateEnd)

        bao_r = New BAO_BUDGET.Report
        UC_Report_SelectDate_Between1.getDateSelect()
        dr2("IDA") = 18
        dr2("INCOME_NAME") = "เงินฝากกองทุนค่าใช้จ่ายในการดำเนินงานของ อย."
        dr2("INCOME_CODE") = "696"
        dr2("sum_amount") = 0
        dr2("sum_sinbon_amount") = 0
        dr2("bank_deposit") = 0
        dr2("check_amt") = 0
        dr2("cash_amt") = 0
        dr2("dateBeginName") = bao_r.convertDateToString(UC_Report_SelectDate_Between1.dateBegin)
        dr2("dateEndName") = bao_r.convertDateToString(UC_Report_SelectDate_Between1.dateEnd)

        dt_sb.Rows.Add(dr1)
        dt_sb.Rows.Add(dr2)
        Return dt_sb
    End Function

    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        'If Request.QueryString("law") <> "" Then
        '    util.ShowReport(ReportViewer1, util.root & "Module03\Report_R3_018_1.rdlc", "Fields_Report_R3_017", getReportData())
        'Else
        If Request.QueryString("e") = "" Then
            util.ShowReport(ReportViewer1, util.root & "Module03\Report_R3_018.rdlc", "Fields_Report_R3_017", getReportData())
        Else
            util.ShowReport(ReportViewer1, util.root & "Module03\Report_R3_018_e.rdlc", "Fields_Report_R3_017", getReportData())
        End If

        'End If

    End Sub

    Private Sub btn_Print_Click(sender As Object, e As EventArgs) Handles btn_Print.Click
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        'If Request.QueryString("law") <> "" Then
        '    runpdf(getReportData(), util.root & "Module03\Report_R3_018_1.rdlc", "Fields_Report_R3_017")
        'Else
        If Request.QueryString("e") = "" Then
            runpdf(getReportData(), util.root & "Module03\Report_R3_018.rdlc", "Fields_Report_R3_017")
        Else
            runpdf(getReportData(), util.root & "Module03\Report_R3_018_e.rdlc", "Fields_Report_R3_017")
        End If

        'End If

    End Sub
    Private Sub runpdf(ByVal dt1 As DataTable, ByVal path As String, ByVal report_datasource As String)
        Dim rsw As New LocalReport
        rsw.Refresh()
        rsw.ReportPath = path
        Dim reportdatasource As New ReportDataSource

        reportdatasource.Value = dt1
        reportdatasource.Name = report_datasource
        rsw.DataSources.Add(reportdatasource)


        Dim ReportType As String = "PDF"
        Dim FileNameExtension As String = "pdf"

        Dim warnings As Warning() = Nothing
        Dim streams As String() = Nothing
        Dim renderedbytes As Byte() = Nothing
        renderedbytes = rsw.Render(ReportType, Nothing, Nothing, "UTF-8", FileNameExtension, streams, warnings)

        'ต้องให้ Content Type เป็น pdf และกำหนด filename ใน content-disposition ให้มีนามสกุลเป็น pdf เพื่อให้ IE เปิด Pdf Reader ได้ http://forums.asp.net/p/1036628/1436084.aspx
        Response.AddHeader("Accept-Ranges", "bytes")
        Response.AddHeader("Accept-Header", "2222")
        Response.AddHeader("Cache-Control", "public")
        Response.AddHeader("Cache-Control", "must-revalidate")
        Response.AddHeader("Pragma", "public")
        'Response.AddHeader()
        'Response.AddHeader("Content-Encoding", "UTF-8")

        'Response.ContentEncoding = System.Text.Encoding.Unicode   'GetEncoding(874)
        'Response.Charset = "windows-874"
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "inline; filename=""" + "Test.pdf" + """")
        Response.AddHeader("expires", "0")


        Response.BinaryWrite(renderedbytes)
        Response.Flush()
    End Sub

    Private Sub ddl_receiver_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_receiver.SelectedIndexChanged
        run_hide_show()
    End Sub
End Class