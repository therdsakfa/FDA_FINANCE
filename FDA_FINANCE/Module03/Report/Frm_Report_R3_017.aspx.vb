Imports Microsoft.Reporting.WebForms

Public Class Frm_Report_R3_017
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_ddl_receiver()
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
    Public Function getReportData()
        Dim bao As New BAO_BUDGET.Report
        'Dim bao2 As New BAO_BUDGET.Report
        UC_Report_SelectDate_Between1.getDateSelect()
        Dim dt As New DataTable
        Dim dt_sb As DataTable = get_sb_dt()
        'get_Report_R3_017_Amount
        If Request.QueryString("n") = "" Then
            If ddl_receiver.SelectedValue = "0" Then
                If CDate(UC_Report_SelectDate_Between1.dateBegin) >= CDate("2563-09-01") Then
                    dt = bao.get_Report_R3_017(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                Else
                    dt = bao.get_Report_R3_017_old(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                End If

            Else
                If CDate(UC_Report_SelectDate_Between1.dateBegin) >= CDate("2563-09-01") Then
                    dt = bao.get_Report_R3_017_V2(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, ddl_receiver.SelectedValue)
                Else
                    dt = bao.get_Report_R3_017_V2_old(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, ddl_receiver.SelectedValue)
                End If

            End If

        Else
            If ddl_receiver.SelectedValue = "0" Then
                If CDate(UC_Report_SelectDate_Between1.dateBegin) >= CDate("2563-09-01") Then
                    dt = bao.get_Report_R3_017_normal_law(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                Else
                    dt = bao.get_Report_R3_017_normal_law_old(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
                End If


            Else
                If CDate(UC_Report_SelectDate_Between1.dateBegin) >= CDate("2563-09-01") Then
                    dt = bao.get_Report_R3_017_normal_law_V2(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, ddl_receiver.SelectedValue)
                Else
                    dt = bao.get_Report_R3_017_normal_law_V2_old(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, ddl_receiver.SelectedValue)
                End If


            End If
        End If


        For Each dr As DataRow In dt.Rows
            If Request.QueryString("n") = "" Then
                Dim bao2 As New BAO_BUDGET.Report
                If ddl_receiver.SelectedValue = "0" Then
                    dr("bank_deposit") = bao2.get_Report_R3_017_Amount(5, UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("IDA"))

                    bao2 = New BAO_BUDGET.Report
                    dr("check_amt") = bao2.get_Report_R3_017_Amount(2, UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("IDA"))

                    bao2 = New BAO_BUDGET.Report
                    dr("cash_amt") = bao2.get_Report_R3_017_Amount(1, UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("IDA"))

                    bao2 = New BAO_BUDGET.Report
                    dr("credit_amt") = bao2.get_Report_R3_017_Amount(6, UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("IDA"))
                Else
                    dr("bank_deposit") = bao2.get_Report_R3_017_Amount_NEW(5, UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("IDA"), ddl_receiver.SelectedValue)

                    bao2 = New BAO_BUDGET.Report
                    dr("check_amt") = bao2.get_Report_R3_017_Amount_NEW(2, UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("IDA"), ddl_receiver.SelectedValue)

                    bao2 = New BAO_BUDGET.Report
                    dr("cash_amt") = bao2.get_Report_R3_017_Amount_NEW(1, UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("IDA"), ddl_receiver.SelectedValue)

                    bao2 = New BAO_BUDGET.Report
                    dr("credit_amt") = bao2.get_Report_R3_017_Amount_NEW(6, UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("IDA"), ddl_receiver.SelectedValue)
                End If
            Else
                '
                If ddl_receiver.SelectedValue = "0" Then
                    Dim bao2 As New BAO_BUDGET.Report
                    dr("bank_deposit") = bao2.get_Report_R3_017_Amount_n_law(5, UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("IDA"))

                    bao2 = New BAO_BUDGET.Report
                    dr("check_amt") = bao2.get_Report_R3_017_Amount_n_law(2, UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("IDA"))

                    bao2 = New BAO_BUDGET.Report
                    dr("cash_amt") = bao2.get_Report_R3_017_Amount_n_law(1, UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("IDA"))

                    bao2 = New BAO_BUDGET.Report
                    dr("credit_amt") = bao2.get_Report_R3_017_Amount_n_law(6, UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("IDA"))
                Else
                    Dim bao2 As New BAO_BUDGET.Report
                    dr("bank_deposit") = bao2.get_Report_R3_017_Amount_n_law_new(5, UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("IDA"), ddl_receiver.SelectedValue)

                    bao2 = New BAO_BUDGET.Report
                    dr("check_amt") = bao2.get_Report_R3_017_Amount_n_law_new(2, UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("IDA"), ddl_receiver.SelectedValue)

                    bao2 = New BAO_BUDGET.Report
                    dr("cash_amt") = bao2.get_Report_R3_017_Amount_n_law_new(1, UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("IDA"), ddl_receiver.SelectedValue)

                    bao2 = New BAO_BUDGET.Report
                    dr("credit_amt") = bao2.get_Report_R3_017_Amount_n_law_new(6, UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("IDA"), ddl_receiver.SelectedValue)
                End If
               
            End If
            
        Next
        Dim sinbon_amount As Double = 0
        Try
            For Each dr As DataRow In dt.Select("IDA=4")
                sinbon_amount = dr("sum_sinbon_amount")
            Next
        Catch ex As Exception

        End Try
        For Each dr As DataRow In dt_sb.Rows
            If dr("IDA") = 17 Then
                dr("sum_amount") = sinbon_amount * 0.75
            ElseIf dr("IDA") = 18 Then
                dr("sum_amount") = sinbon_amount * 0.25
            End If
        Next


        Dim dt_all As New DataTable
        dt_all.Columns.Add("IDA")
        dt_all.Columns.Add("INCOME_NAME")
        dt_all.Columns.Add("INCOME_CODE")
        dt_all.Columns.Add("sum_amount", GetType(Double))
        dt_all.Columns.Add("sum_sinbon_amount", GetType(Double))
        dt_all.Columns.Add("bank_deposit", GetType(Double))
        dt_all.Columns.Add("check_amt", GetType(Double))
        dt_all.Columns.Add("cash_amt", GetType(Double))
        dt_all.Columns.Add("credit_amt", GetType(Double))
        dt_all.Columns.Add("dateBeginName")
        dt_all.Columns.Add("dateEndName")

        For Each dr As DataRow In dt.Rows
            Dim dr1 As DataRow = dt_all.NewRow

            dr1("IDA") = dr("IDA")
            dr1("INCOME_NAME") = dr("INCOME_NAME")
            dr1("INCOME_CODE") = dr("INCOME_CODE")
            dr1("sum_amount") = dr("sum_amount")
            dr1("sum_sinbon_amount") = dr("sum_sinbon_amount")
            dr1("bank_deposit") = dr("bank_deposit")
            dr1("check_amt") = dr("check_amt")
            dr1("cash_amt") = dr("cash_amt")
            dr1("credit_amt") = dr("credit_amt")
            dr1("dateBeginName") = dr("dateBeginName")
            dr1("dateEndName") = dr("dateEndName")
            dt_all.Rows.Add(dr1)
            If dr("IDA") = 4 Then
                dt_all.Merge(dt_sb)
            End If
        Next

        Return dt_all
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
        dt_sb.Columns.Add("credit_amt", GetType(Double))
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
        dr2("credit_amt") = 0
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
        util.ShowReport(ReportViewer1, util.root & "Module03\Report_R3_017.rdlc", "Fields_Report_R3_017", getReportData())
    End Sub

    Private Sub btn_Print_Click(sender As Object, e As EventArgs) Handles btn_Print.Click
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        runpdf(getReportData(), util.root & "Module03\Report_R3_017.rdlc", "Fields_Report_R3_017")
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
End Class