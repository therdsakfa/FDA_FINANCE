Imports Microsoft.Reporting.WebForms

Public Class FRM_DOWNLOAD_RECEIPT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub CreatePDF(ByVal FileName As String)
        ' Setup DataSet
        ' Dim ds As New MyDataSetTableAdapters.DataTable1TableAdapter()
        Dim dt As New DataTable
        dt = getReportData_reciept_fda_v2_1()
        ' Create Report DataSource
        If dt.Rows.Count > 0 Then
            Dim rds As New ReportDataSource("Fields_Report_R9_003", dt)


            ' Variables
            Dim warnings As Warning() = Nothing
            Dim streamids As String() = Nothing
            Dim mimeType As String = Nothing
            Dim encoding As String = Nothing
            Dim extension As String = Nothing

            Dim util As New Report_Utility
            'util.configWidthHeight()


            ' Setup the report viewer object and get the array of bytes
            Dim viewer As New ReportViewer()
            viewer.ProcessingMode = ProcessingMode.Local
            viewer.LocalReport.ReportPath = util.root & "Module09\Report_R9_003_V3_01.rdlc"
            viewer.LocalReport.DataSources.Add(rds)
            Dim bytes As Byte() = viewer.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamids, _
            warnings)






            ' Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
            Response.Buffer = True
            Response.Clear()
            Response.ContentType = mimeType
            Response.AddHeader("content-disposition", ("attachment; filename=" & FileName & ".") + extension)
            Response.BinaryWrite(bytes)
            ' create the file
            ' send it to the client to download
            Response.Flush()
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
        End If


    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        CreatePDF(txt_ref01.Text & "-" & txt_ref02.Text)
    End Sub

    Public Function getReportData_reciept_fda_v2_1()
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Maintain

        Dim fee_format As String = ""
        Dim dvcd As String = ""
        Dim feeabbr As String = ""

        'dt = bao.SP_GET_E_RECEIPT_IDV2(fee_format, dvcd, feeabbr)
        dt = bao.SP_GET_E_RECEIPT_BY_REF01_REF02(txt_ref01.Text, txt_ref02.Text)
        If dt.Rows.Count > 0 Then

            dt.Columns.Add("days", GetType(String))
            dt.Columns.Add("months", GetType(String))
            dt.Columns.Add("years", GetType(String))
            Dim days As String = Day(Date.Now)
            Dim years As Integer = 0
            years = Year(Date.Now)
            If years < 2500 Then
                years += 543
            End If
            Dim months As Integer = Month(Date.Now)
            Dim uti As New Report_Utility
            Dim str_month As String = ""
            str_month = uti.get_Long_month_BY_Number(months)

            Dim dao_re As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao_re.Getdata_by_ref01_ref02(txt_ref01.Text, txt_ref02.Text)
            fee_format = dao_re.fields.FEENO
            dvcd = dao_re.fields.DVCD
            feeabbr = dao_re.fields.FEEABBR


            Dim dt2 As New DataTable
            Dim bao2 As New BAO_BUDGET.Maintain

            dt2 = bao2.SP_get_receipt_data_det_feeno_dvcd_feeabbrV3(txt_ref01.Text, txt_ref02.Text)


            dt2.Columns.Add("days")
            dt2.Columns.Add("years")
            dt2.Columns.Add("months")
            dt2.Columns.Add("item_c")
            dt2.Columns.Add("row2")
            dt2.Columns.Add("row3")

            Dim dao_det As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
            Dim ii As Integer = 0
            Dim txt As String = ""
            Dim lcnno As String = ""
            Dim amt As Double = 0
            Dim dtl As String = ""
            Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            Try
                dao.Getdata_by_feeno(fee_format)
            Catch ex As Exception

            End Try

            dao_det.Getdata_by_RECEIVE_MONEY_ID(dao.fields.RECEIVE_MONEY_ID)

            For Each dao_det.fields In dao_det.datas
                ii += 1
                txt = dao_det.fields.TXT_LCNNO
                Dim code_txt As String = ""
                Dim rcvno As String = ""
                Dim rcvabbr As String = ""
                Dim appabbr As String = ""
                Dim lcnno_det As String = ""
                Try
                    code_txt = dao_det.fields.CODE_TXT
                Catch ex As Exception

                End Try
                Try
                    rcvno = dao_det.fields.rcvno
                Catch ex As Exception

                End Try
                Try
                    lcnno_det = dao_det.fields.LCNNO
                Catch ex As Exception

                End Try
                Try
                    appabbr = dao_det.fields.appabbr
                Catch ex As Exception

                End Try
                Try
                    rcvabbr = dao_det.fields.rcvabbr
                Catch ex As Exception

                End Try


                Try
                    amt = dao_det.fields.AMOUNT
                Catch ex As Exception

                End Try
                Try
                    dtl = dao_det.fields.TXT_LCNNO
                Catch ex As Exception

                End Try


            Next
            'If ii > 0 And ii <= 1 Then
            '    For Each dr As DataRow In dt2.Rows
            '        dr("feetpnm") &= " " & txt & " " & lcnno
            '        dr("item_c") = ii
            '    Next
            'Else
            For Each dr As DataRow In dt2.Rows
                'dr("item_c") = ii
                'dr("row2") = "(จำนวน " & ii & " ฉบับ ฉบับละ " & amt.ToString("N") & " บาท)"
                dr("row3") = dtl & " " & lcnno
            Next
            ' End If

            dt = dt2

            For Each dr As DataRow In dt.Rows
                Try
                    dr("days") = Day(CDate(dr("MONEY_RECEIVE_DATE")))
                    dr("years") = IIf(Year(CDate(dr("MONEY_RECEIVE_DATE"))) < 2500, Year(DateAdd(DateInterval.Year, 543, CDate(dr("MONEY_RECEIVE_DATE")))), Year(CDate(dr("MONEY_RECEIVE_DATE"))))

                    Dim uti2 As New Report_Utility
                    Dim str_month2 As String = ""
                    str_month2 = uti2.get_Long_month_BY_Number(Month(CDate(dr("MONEY_RECEIVE_DATE"))))
                    dr("months") = str_month2
                Catch ex As Exception

                End Try

                Dim dao3 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                Try
                    dao3.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))

                    If dao3.fields.RECEIVE_MONEY_TYPE = 2 Then
                        Dim dao_b As New DAO_MAS.TB_MAS_BANK
                        Try
                            dao_b.Getdata_by_BANK_ID(dao3.fields.BANK_ID)
                            dr("row3") &= " (เช็คธนาคาร " & dao_b.fields.BANK_SHORT_NAME & " เลขที่ " & dao3.fields.CHECK_NUMBER & " )"
                        Catch ex As Exception

                        End Try

                    End If

                Catch ex As Exception

                End Try
            Next

        End If
        Return dt
    End Function
End Class