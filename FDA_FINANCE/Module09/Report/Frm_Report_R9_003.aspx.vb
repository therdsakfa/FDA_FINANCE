Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports Microsoft.Reporting.WinForms
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports Microsoft.Reporting.WebForms
Imports Microsoft.ReportingServices
Public Class Frm_Report_R9_003
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            If Request.QueryString("flag") IsNot Nothing Then
                Dim util As New Report_Utility
                util.report = ReportViewer1
                util.configWidthHeight()
                util.ShowReport(ReportViewer1, util.root & "Module09\Report_R9_003.rdlc", "Fields_Report_R9_003", getReportData_return_money())
            ElseIf Request.QueryString("feeno") <> "" And Request.QueryString("se") <> "" Then
                Dim util As New Report_Utility
                util.report = ReportViewer1
                util.configWidthHeight()
                'util.ShowReport(ReportViewer1, util.root & "Module09\Report_R9_003_V3.rdlc", "Fields_Report_R9_003", getReportData_reciept_fda())
                runpdf(getReportData_reciept_fda(), util.root & "Module09\Report_R9_003_V3_01.rdlc", "Fields_Report_R9_003")
            ElseIf Request.QueryString("feeno") <> "" And Request.QueryString("aa") <> "" Then
                Dim util As New Report_Utility
                util.report = ReportViewer1
                util.configWidthHeight()
                'util.ShowReport(ReportViewer1, util.root & "Module09\Report_R9_003_V3.rdlc", "Fields_Report_R9_003", getReportData_reciept_fda())

                runpdf(getReportData_reciept_fda(), util.root & "Module09\Report_R9_003_V3_01.rdlc", "Fields_Report_R9_003")
            ElseIf Request.QueryString("id_feeno") <> "" Then
                Dim dt As New DataTable
                Dim util As New Report_Utility
                util.report = ReportViewer1
                util.configWidthHeight()
                'util.ShowReport(ReportViewer1, util.root & "Module09\Report_R9_003_V2.rdlc", "Fields_Report_R9_003", getReportData_receipt_fda_in())
                Dim feeabbr As String = ""
                Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                Try
                    dao.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))
                    feeabbr = dao.fields.FEEABBR
                Catch ex As Exception

                End Try


                If Request.QueryString("copy") <> "" Then
                    dt = getReportData_receipt_fda_in()
                    runpdf_normal(dt, util.root & "Module09\Report_R9_003_V3_01.rdlc", "Fields_Report_R9_003")
                Else
                    If Request.QueryString("rt") <> "" Then
                        dt = getReportData_receipt_fda_in_rt3()
                        If Request.QueryString("law") = "" Then
                            runpdf_normal(dt, util.root & "Module09\Report_R9_003_V4_small2.rdlc", "Fields_Report_R9_003")
                        Else
                            runpdf_normal(dt, util.root & "Module09\Report_R9_003_V4_Big.rdlc", "Fields_Report_R9_003")
                        End If
                    Else

                        If Request.QueryString("law") = "" Then
                            'If feeabbr = "9005" Then
                            '    dt = getReportData_receipt_fda_in_law()
                            '    runpdf(dt, util.root & "Module09\Report_R9_003_V4_small.rdlc", "Fields_Report_R9_003")
                            'Else
                            dt = getReportData_receipt_fda_in()
                            runpdf_normal(dt, util.root & "Module09\Report_R9_003_V4_small.rdlc", "Fields_Report_R9_003")
                            'End If

                        Else
                            dt = getReportData_receipt_fda_in_law()
                            'runpdf(dt, util.root & "Module09\Report_R9_003_V4_small.rdlc", "Fields_Report_R9_003")
                            runpdf_normal(dt, util.root & "Module09\Report_R9_003_V4_Big.rdlc", "Fields_Report_R9_003")
                        End If

                    End If

                End If
                Session("dt") = dt
                'runpdf(getReportData_receipt_fda_in(), util.root & "Module09\Report_R9_003_V3.rdlc", "Fields_Report_R9_003")
            ElseIf Request.QueryString("id_rec") <> "" Then
                Dim util As New Report_Utility
                util.report = ReportViewer1
                util.configWidthHeight()
                'util.ShowReport(ReportViewer1, util.root & "Module09\Report_R9_003_V2.rdlc", "Fields_Report_R9_003", getReportData_receipt_fda_in())
                runpdf(getReportData_receipt_fda_in(), util.root & "Module09\Report_R9_003_V3.rdlc", "Fields_Report_R9_003")
            ElseIf Request.QueryString("feeno") <> "" Then
                Dim util As New Report_Utility
                util.report = ReportViewer1
                util.configWidthHeight()
                'util.ShowReport(ReportViewer1, util.root & "Module09\Report_R9_003_V3.rdlc", "Fields_Report_R9_003", getReportData_reciept_fda())
                Session("dt") = getReportData_reciept_fda_v2()
                'If Request.QueryString("copy") <> "" Then
                runpdf(getReportData_reciept_fda_v2(), util.root & "Module09\Report_R9_003_V3_01.rdlc", "Fields_Report_R9_003")
                'Else
                '    runpdf(getReportData_reciept_fda(), util.root & "Module09\Report_R9_003_V3.rdlc", "Fields_Report_R9_003")
                'End If
            ElseIf Request.QueryString("ref01") <> "" Then
                Dim dt_id As New DataTable
                Dim util As New Report_Utility
                util.report = ReportViewer1
                util.configWidthHeight()
                'util.ShowReport(ReportViewer1, util.root & "Module09\Report_R9_003_V3.rdlc", "Fields_Report_R9_003", getReportData_reciept_fda())
                dt_id = getReportData_reciept_fda_v2_1()
                If dt_id.Rows.Count > 0 Then
                    Dim dao_rev As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                    dao_rev.Getdata_by_ref01_ref02(Request.QueryString("ref01"), Request.QueryString("ref02"))
                    Dim r As String = ""
                    Try
                        r = Right(Left(dao_rev.fields.FULL_RECEIVE_NUMBER, 3), 1)
                    Catch ex As Exception

                    End Try
                    If r = "E" Then
                        Session("dt") = getReportData_reciept_fda_v2_1()

                        runpdf(getReportData_reciept_fda_v2_1(), util.root & "Module09\Report_R9_003_V3_01.rdlc", "Fields_Report_R9_003")
                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถแสดงใบเสร็จได้ เนื่องจากเป็นใบเสร็จที่ชำระผ่านหน้าเคาท์เตอร์ OSSC');", True)
                    End If
                Else
                    Dim dao_rev As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                    dao_rev.Getdata_by_ref01_ref02(Request.QueryString("ref01"), Request.QueryString("ref02"))
                    Dim r As Integer = 0
                    Try
                        r = Len(dao_rev.fields.FULL_RECEIVE_NUMBER)
                    Catch ex As Exception

                    End Try
                    If r < 17 And r > 0 Then
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถแสดงใบเสร็จได้ เนื่องจากเป็นใบเสร็จที่ชำระผ่านหน้าเคาท์เตอร์ OSSC');", True)
                    ElseIf r = 0 Then
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถแสดงใบเสร็จได้ เนื่องจากรอการตรวจสอบข้อมูล');", True)
                    End If

                End If
                
            ElseIf Request.QueryString("rn") <> "" Then
                Dim util As New Report_Utility
                util.report = ReportViewer1
                util.configWidthHeight()
                'util.ShowReport(ReportViewer1, util.root & "Module09\Report_R9_003_V3.rdlc", "Fields_Report_R9_003", getReportData_reciept_fda())
                Session("dt") = getReportData_reciept_fda_long()
                'If Request.QueryString("copy") <> "" Then
                runpdf(getReportData_reciept_fda_long(), util.root & "Module09\Report_R9_003_V3_03.rdlc", "Fields_Report_R9_003")
            Else
                Dim util As New Report_Utility
                util.report = ReportViewer1
                util.configWidthHeight()
                util.ShowReport(ReportViewer1, util.root & "Module09\Report_R9_003.rdlc", "Fields_Report_R9_003", getReportData())
            End If

        End If
    End Sub

    ''' <summary>
    ''' Function สร้างตารางข้อมูลรายงาน แยกตามรายงาน
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getReportData()
        Dim bao As New BAO_BUDGET.Report
        Dim dt As DataTable = bao.getReportData_R9_003(Request.QueryString("ID"))

        Return dt
    End Function
    Public Function getReportData_return_money()
        Dim bao As New BAO_BUDGET.Report
        Dim dt As DataTable = bao.getReportData_R9_003_Return_Money(Request.QueryString("ID"))

        Return dt
    End Function
    Private Function feeno_format() As String
        Dim fee_format As String = ""
        Dim arr_feeno As String() = Nothing

        'Dim query_str As String = Request.QueryString("feeno")
        'Dim decode_str As String = Request.QueryString("feeno").DecodeBase64
        'Dim arr_query As String() = decode_str.Split("|")

        'Dim raw_txt As String = arr_query(0)
        Dim raw_txt As String = Request.QueryString("feeno")
        'If IsNumeric(raw_txt) = False Then
        '    raw_txt = Server.UrlDecode(Request.QueryString("feeno")).DecodeBase64()
        'Else
        'raw_txt = Server.UrlDecode(Request.QueryString("feeno"))
        'End If
        Try
            arr_feeno = raw_txt.Split("/")
            fee_format = arr_feeno(1) & arr_feeno(0)
        Catch ex As Exception
            fee_format = raw_txt
        End Try
        Return fee_format
    End Function
    Public Function getReportData_reciept_fda()
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.FDA_FEE
        Dim receipt_num As String = ""
        Dim fee_format As String = feeno_format()
        'dt = bao.SP_get_receipt_by_feeabbr_and_feeno(Request.QueryString("feeno"), Request.QueryString("feeabbr"))
        'dt = bao.SP_get_receipt_by_feeabbr_and_feeno_receipt(Request.QueryString("feeno"))
        Dim dvcd As String = ""
        If IsNumeric(Server.UrlDecode(Request.QueryString("dvcd"))) = False Then
            dvcd = Server.UrlDecode(Request.QueryString("dvcd")).DecodeBase64
        Else
            dvcd = Server.UrlDecode(Request.QueryString("dvcd"))
        End If
        dt = bao.SP_get_receipt_by_dvcd_and_feeno_receipt(fee_format, dvcd)

        If dt.Rows.Count = 0 Then

        End If

        dt.Columns.Add("days", GetType(String))
        dt.Columns.Add("months", GetType(String))
        dt.Columns.Add("years", GetType(String))
        'dt.Columns.Add("receipt_number", GetType(String))
        'dt.Columns.Add("sign_name", GetType(String))
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

        Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        Dim i As Integer = 0
        i = dao.count_receipt3(dvcd, fee_format)
        If i = 0 Then
            Dim dao_i As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao_i.fields.RECEIVE_MONEY_TYPE = 1
            dao_i.fields.RECEIVE_MONEY_DESCRIPTION = dt(0)("feetpnm")
            dao_i.fields.FULLNAME = dt(0)("fullname")
            dao_i.fields.CUSTOMER_ID = dt(0)("lcnsid")
            dao_i.fields.RECEIVER_MONEY_ID = 0
            dao_i.fields.RECEIVE_AMOUNT = dt(0)("amt")
            dao_i.fields.DEPARTMENT_ID = 0
            dao_i.fields.ORDER_PAY1 = Request.QueryString("feeabbr")
            dao_i.fields.ORDER_PAY2 = fee_format
            dao_i.fields.MONEY_RECEIVE_DATE = Date.Now
            dao_i.fields.FEEABBR = Request.QueryString("feeabbr")
            dao_i.fields.FEENO = fee_format
            dao_i.fields.LCNSID = dt(0)("lcnsid")
            dao_i.fields.BUDGET_YEAR = years
            dao_i.fields.RECEIPT_TYPE = 1
            dao_i.fields.REF01 = dt(0)("ref01")
            dao_i.fields.REF02 = dt(0)("ref02")
            dao_i.fields.MONEY_TYPE_ID = 1
            dao_i.fields.DVCD = Request.QueryString("dvcd")

            If Request.QueryString("staff") <> "" Then
                dao_i.fields.STAFF_IDEN = _CLS.CITIZEN_ID
            End If

            Dim bao2 As New BAO_BUDGET.Maintain
            Dim max_id As Integer = 0
            Try
                max_id = bao2.get_max_receipt_normal(Request.QueryString("myear"), 2)
            Catch ex As Exception

            End Try
            dao_i.fields.E_RUNNING_RECEIPT = max_id + 1
            dao_i.fields.FULL_RECEIVE_NUMBER = Right(years, 2) & "/" & max_id + 1
            dao_i.insert()

            For Each dr As DataRow In dt.Rows
                Dim dao_det As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
                dao_det.fields.FK_IDA = dao_i.fields.RECEIVE_MONEY_ID
                Try
                    dao_det.fields.AMOUNT = dr("amt")
                Catch ex As Exception
                    dao_det.fields.AMOUNT = 0
                End Try
                dao_det.fields.FEEABBR = Request.QueryString("feeabbr")
                dao_det.fields.TABEAN_NUMBER = ""
                dao_det.insert()
            Next



            'receipt_num = Right(years,2) & "/" 
            For Each dr As DataRow In dt.Rows
                dr("days") = days
                dr("years") = years
                dr("months") = str_month
                dr("receipt_number") = "-"
            Next
        Else
            Dim dt2 As New DataTable
            Dim bao2 As New BAO_BUDGET.Maintain
            dt2 = bao2.SP_get_receipt_data_det_feeno(Request.QueryString("feeno"))


            'Dim dt As New DataTable
            'Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            'dao.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))
            'dt.Columns.Add("lcnsid")
            'dt.Columns.Add("feeno")
            'dt.Columns.Add("feetpnm")
            'dt.Columns.Add("ref01")
            'dt.Columns.Add("amt", GetType(Double))
            'dt.Columns.Add("value", GetType(Double))
            'dt.Columns.Add("feeabbr")
            'dt.Columns.Add("fee_no_5")
            'dt.Columns.Add("year_fee")
            'dt.Columns.Add("rcptst")
            'dt.Columns.Add("fullname")

            dt2.Columns.Add("days")
            dt2.Columns.Add("years")
            dt2.Columns.Add("months")
            'dt.Columns.Add("receipt_number")
            For Each dr As DataRow In dt2.Rows
                Try
                    dr("days") = Day(CDate(dr("MONEY_RECEIVE_DATE")))
                    dr("years") = IIf(Year(CDate(dr("MONEY_RECEIVE_DATE"))) < 2500, Year(DateAdd(DateInterval.Year, 543, CDate(dr("MONEY_RECEIVE_DATE")))), Year(CDate(dr("MONEY_RECEIVE_DATE"))))

                    Dim uti2 As New Report_Utility
                    Dim str_month2 As String = ""
                    str_month2 = uti2.get_Long_month_BY_Number(Month(CDate(dr("MONEY_RECEIVE_DATE"))))
                    dr("months") = str_month2
                Catch ex As Exception

                End Try
            Next
            'Dim dao_u As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            'dao_u.Getdata_by_receipt2(Request.QueryString("feeno"))
            'Dim dt2 As New DataTable
            'dt2 = dt.Clone

            'For Each dao_u.fields In dao_u.datas
            '    Dim dr As DataRow = dt2.NewRow()
            '    dr("lcnsid") = dao_u.fields.LCNSID
            '    dr("feeno") = dao_u.fields.FEENO
            '    dr("feetpnm") = dao_u.fields.RECEIVE_MONEY_DESCRIPTION
            '    dr("ref01") = ""
            '    dr("amt") = dao_u.fields.RECEIVE_AMOUNT
            '    'dr("value") = dao_u.fields.RECEIVE_AMOUNT
            '    dr("feeabbr") = dao_u.fields.FEEABBR
            '    dr("fee_no_5") = Right(dao_u.fields.FEENO, 5)
            '    dr("year_fee") = Left(dao_u.fields.FEENO, 2)
            '    dr("rcptst") = 1
            '    dr("fullname") = dao_u.fields.FULLNAME
            '    Try
            '        dr("days") = Day(CDate(dao_u.fields.MONEY_RECEIVE_DATE))
            '        dr("years") = IIf(Year(CDate(dao_u.fields.MONEY_RECEIVE_DATE)) < 2500, Year(DateAdd(DateInterval.Year, 543, CDate(dao_u.fields.MONEY_RECEIVE_DATE))), Year(CDate(dao_u.fields.MONEY_RECEIVE_DATE)))

            '        Dim uti2 As New Report_Utility
            '        Dim str_month2 As String = ""
            '        str_month2 = uti2.get_Long_month_BY_Number(Month(CDate(dao_u.fields.MONEY_RECEIVE_DATE)))
            '        dr("months") = str_month2
            '    Catch ex As Exception

            '    End Try
            '    dr("receipt_number") = "-"
            '    dt2.Rows.Add(dr)
            'Next

            dt = dt2
        End If
        Return dt
    End Function
    Public Function getReportData_receipt_fda_in()
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Maintain
        'dt = bao.SP_get_receipt_data_det(Request.QueryString("id_feeno"))
        Dim ii As Integer = 0
        Dim txt_amt As String = ""
        Dim dao_det_h As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
        dao_det_h.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))
        Dim From_old As Boolean = False
        Dim ref0111 As String = ""
        Dim ref0222 As String = ""
        Dim raw_feeno As String = ""
        For Each dao_det_h.fields In dao_det_h.datas
            ii += 1
            Dim amountt As Double = dao_det_h.fields.AMOUNT
            If txt_amt = "" Then

                txt_amt = amountt.ToString("N")
            Else
                txt_amt = txt_amt & "," & amountt.ToString("N")
            End If
        Next

        Dim dvcd As Integer = 0
        Dim dao_re2 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        dao_re2.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))
        Try
            ref0222 = dao_re2.fields.REF02
        Catch ex As Exception

        End Try
        Try
            raw_feeno = dao_re2.fields.FEENO
        Catch ex As Exception

        End Try
        Try
            dvcd = dao_re2.fields.DVCD
        Catch ex As Exception

        End Try
        Try
            ref0111 = dao_re2.fields.REF01
        Catch ex As Exception

        End Try

        Dim count_feeee As Integer = 0
        'Dim dao_feee As New DAO_FEE.TB_fee
        'count_feeee = dao_feee.Countby_ref1_ref2(ref0111, ref0222)
        Dim bao_f As New BAO_FEE.FEE
        Dim dt_f As New DataTable
        'dt_f = bao_f.SP_COUNT_FEE_OLD_BY_REF01_REF02(ref0111, ref0222)


        If dt_f.Rows.Count > 0 Then
            From_old = True
        End If
        If dao_re2.fields.FEEABBR = "9005" Or From_old = False Then
            dt = bao.SP_get_receipt_data_det_feeno_V2_9005(Request.QueryString("id_feeno"))
        Else
            dt = bao.SP_get_receipt_data_det_feeno_V2(Request.QueryString("id_feeno"))
        End If


        Dim fee_format As String = feeno_format()

        'Dim dt As New DataTable
        'Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        'dao.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))
        'dt.Columns.Add("lcnsid")
        'dt.Columns.Add("feeno")
        'dt.Columns.Add("feetpnm")
        'dt.Columns.Add("ref01")
        'dt.Columns.Add("amt", GetType(Double))
        'dt.Columns.Add("value", GetType(Double))
        'dt.Columns.Add("feeabbr")
        'dt.Columns.Add("fee_no_5")
        'dt.Columns.Add("year_fee")
        'dt.Columns.Add("rcptst")
        'dt.Columns.Add("fullname")

        dt.Columns.Add("days")
        dt.Columns.Add("years")
        dt.Columns.Add("months")
        'dt.Columns.Add("receipt_number")

        Dim is_l44 As Integer = 0
        Dim dao_re1 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        Dim dao_rd As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
        Dim rcvno_txt As String = ""
        Try
            dao_re1.Getdata_by_feeno(fee_format)
            is_l44 = dao_re1.fields.IS_L44

            dao_rd.Getdata_by_RECEIVE_MONEY_ID(dao_re1.fields.RECEIVE_MONEY_ID)
            rcvno_txt = dao_rd.fields.rcvno
            If Len(Trim(rcvno_txt)) = 0 Then
                rcvno_txt = dao_rd.fields.LCNNO
            End If
        Catch ex As Exception

        End Try


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

        Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY

        Dim i As Integer = 0
        '
        If Request.QueryString("id_feeno") <> "" Then
            Dim dao2 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao2.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))
            i = dao.count_receipt_by_ref_E(dao2.fields.REF01, dao2.fields.REF02)
        Else
            i = dao.count_receipt4(Request.QueryString("dvcd"), Request.QueryString("feeno"), Request.QueryString("feeabbr"))
        End If

        If i = 0 Then
            Dim dao_i As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao_i.fields.RECEIVE_MONEY_TYPE = 1
            dao_i.fields.RECEIVE_MONEY_DESCRIPTION = dt(0)("feetpnm")
            dao_i.fields.FULLNAME = dt(0)("fullname")
            Try
                dao_i.fields.CUSTOMER_ID = CStr(dt(0)("lcnsid"))
            Catch ex As Exception

            End Try
            dao_i.fields.RECEIVER_MONEY_ID = 0
            dao_i.fields.RECEIVE_AMOUNT = dt(0)("amt")
            dao_i.fields.DEPARTMENT_ID = 0
            dao_i.fields.ORDER_PAY1 = Request.QueryString("feeabbr")
            dao_i.fields.ORDER_PAY2 = fee_format
            dao_i.fields.MONEY_RECEIVE_DATE = Date.Now
            dao_i.fields.FEEABBR = Request.QueryString("feeabbr")
            dao_i.fields.FEENO = fee_format
            dao_i.fields.LCNSID = dt(0)("lcnsid")
            dao_i.fields.BUDGET_YEAR = years
            dao_i.fields.RECEIPT_TYPE = 1
            dao_i.fields.REF01 = dt(0)("ref01")
            dao_i.fields.REF02 = dt(0)("ref02")
            dao_i.fields.MONEY_TYPE_ID = 1
            dao_i.fields.DVCD = Request.QueryString("dvcd")

            If Request.QueryString("staff") <> "" Then
                dao_i.fields.STAFF_IDEN = _CLS.CITIZEN_ID
            End If

            Dim bao2 As New BAO_BUDGET.Maintain
            Dim max_id As Integer = 0
            Try
                max_id = bao2.get_max_receipt_normal(Request.QueryString("myear"), 2)
            Catch ex As Exception

            End Try
            dao_i.fields.E_RUNNING_RECEIPT = max_id + 1
            dao_i.fields.FULL_RECEIVE_NUMBER = Right(years, 2) & "/" & max_id + 1
            dao_i.insert()

            For Each dr As DataRow In dt.Rows
                Dim dao_det As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
                dao_det.fields.FK_IDA = dao_i.fields.RECEIVE_MONEY_ID
                Try
                    dao_det.fields.AMOUNT = dr("amt")
                Catch ex As Exception
                    dao_det.fields.AMOUNT = 0
                End Try
                dao_det.fields.FEEABBR = Request.QueryString("feeabbr")
                dao_det.fields.TABEAN_NUMBER = ""
                dao_det.insert()
            Next



            'receipt_num = Right(years,2) & "/" 
            For Each dr As DataRow In dt.Rows
                dr("days") = days
                dr("years") = years
                dr("months") = str_month
                dr("receipt_number") = "-"
            Next
        Else

            Dim dt2 As New DataTable
            Dim bao2 As New BAO_BUDGET.Maintain
            'dt2 = bao2.SP_get_receipt_data_det_feeno_V2(Request.QueryString("id_feeno"))

            If dao_re2.fields.FEEABBR = "9005" Or From_old = False Then
                dt2 = bao2.SP_get_receipt_data_det_feeno_V2_9005(Request.QueryString("id_feeno"))
                If dvcd = 7 Then
                    For Each dr1 As DataRow In dt2.Rows
                        Dim dao_fees As New DAO_FEE.TB_fee
                        dao_fees.GetDataby_feeno(raw_feeno)

                        Dim str_head As String = ""
                        Dim dao_feefine As New DAO_FEE.TB_FEE_FINE
                        Try
                            dao_feefine.Getdata_by_fk_fee(dao_fees.fields.IDA)
                            str_head = dao_feefine.fields.process_name & vbCrLf & "ข้อหาฐานความผิด"
                        Catch ex As Exception

                        End Try
                        dr1("feetpnm") = str_head & vbCrLf & dr1("feetpnm")
                    Next
                End If
            ElseIf From_old = True Then
                dt2 = bao2.SP_get_receipt_data_det_feeno_old(Request.QueryString("id_feeno"))
            Else
                dt2 = bao2.SP_get_receipt_data_det_feeno_V2(Request.QueryString("id_feeno"))
            End If

            dt2.Columns.Add("days")
            dt2.Columns.Add("years")
            dt2.Columns.Add("months")
            dt2.Columns.Add("item_c")
            dt2.Columns.Add("row2")
            dt2.Columns.Add("row3")

            Dim dao_det As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2

            Dim txt As String = ""
            Dim lcnno As String = ""
            Dim amt As Double = 0
            Dim dtl As String = ""
            dao_det.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))

            Dim row3_44 As String = ""
            For Each dao_det.fields In dao_det.datas
                'ii += 1
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
                    If IsNothing(dao_det.fields.LCNNO) Then
                        lcnno_det = ""
                    Else
                        lcnno_det = dao_det.fields.LCNNO
                    End If

                Catch ex As Exception
                    lcnno_det = ""
                End Try
                Try
                    appabbr = dao_det.fields.appabbr
                Catch ex As Exception

                End Try
                Try
                    rcvabbr = dao_det.fields.rcvabbr
                Catch ex As Exception

                End Try
                Dim dao_re As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                dao_re.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))
                Dim is_law44 As Integer = 0
                Try
                    is_law44 = dao_re.fields.IS_L44
                Catch ex As Exception

                End Try
                If is_law44 = 0 Then
                    If lcnno_det.Contains("ค่าปรับ") = False Then
                        Try
                            If lcnno_det <> "" And Len(lcnno_det) > 6 Then
                                If lcnno = "" Then
                                    If dao_re2.fields.FEEABBR = "9005" Or From_old = False Then
                                        lcnno = dao_det.fields.LCNNO
                                    Else
                                        lcnno = appabbr & " " & CInt(Right(dao_det.fields.LCNNO, 5)) & "/25" & Left(dao_det.fields.LCNNO, 2)
                                    End If

                                Else
                                    If dao_re2.fields.FEEABBR = "9005" Or From_old = False Then
                                        lcnno &= ", " & dao_det.fields.LCNNO
                                    Else
                                        lcnno &= ", " & appabbr & " " & CInt(Right(dao_det.fields.LCNNO, 5)) & "/25" & Left(dao_det.fields.LCNNO, 2)
                                    End If
                                End If
                            Else
                                If lcnno = "" Then
                                    If dao_re2.fields.FEEABBR = "9005" Or From_old = False Then
                                        lcnno = dao_det.fields.LCNNO
                                    Else
                                        lcnno = rcvabbr & " " & CInt(Right(dao_det.fields.rcvno, 5)) & "/25" & Left(dao_det.fields.rcvno, 2)
                                    End If

                                Else
                                    If dao_re2.fields.FEEABBR = "9005" Or From_old = False Then
                                        lcnno &= ", " & dao_det.fields.rcvno
                                    Else
                                        lcnno &= ", " & rcvabbr & " " & CInt(Right(dao_det.fields.rcvno, 5)) & "/25" & Left(dao_det.fields.rcvno, 2)
                                    End If

                                End If
                            End If
                        Catch ex As Exception

                        End Try
                    End If

                    Try
                        amt = dao_det.fields.AMOUNT
                    Catch ex As Exception

                    End Try
                    Try
                        dtl = dao_det.fields.TXT_LCNNO
                    Catch ex As Exception

                    End Try
                    If is_l44 = 1 Then
                        dtl = "เลขที่"
                        'If Right(rcvno_txt, 1) = "R" Then
                        '    dtl = "เลขรับคำร้องที่"
                        'ElseIf Right(rcvno_txt, 1) = "C" Then
                        '    dtl = "เลขตรวจคำขอที่"
                        'ElseIf Right(rcvno_txt, 1) = "A" Then
                        '    dtl = "เลขรับประเมินคำขอที่"
                        'Else
                        '    If Len(rcvno_txt) >= 9 Then
                        '        dtl = "เลขที่อ้างอิงชำระเงิน"
                        '    End If
                        'End If
                    End If
                    Dim feeabbr_h As String = ""
                    Dim dao_h As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                    Try
                        dao_h.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))
                        feeabbr_h = dao_h.fields.FEEABBR
                    Catch ex As Exception

                    End Try
                    For Each dr As DataRow In dt2.Rows
                        dr("item_c") = ii
                        If is_l44 <> 1 Then
                            '''''''dr("row2") = "(จำนวน " & ii & " ฉบับ ฉบับละ " & amt.ToString("N") & " บาท)"
                            If feeabbr_h = "9005" Or From_old = False Then
                                dr("row2") = "(จำนวน " & ii & " ฉบับ)" 'จำนวนเงิน " & txt_amt & " บาท)"
                            Else
                                dr("row2") = "(จำนวน " & ii & " ฉบับ ฉบับละ " & amt.ToString("N") & " บาท)"
                            End If

                        End If
                        'dr("row3") = dtl & " " & lcnno

                        If is_l44 = 1 Then
                            If rcvno_txt <> "" Then
                                dr("row3") = dtl & " " & rcvno_txt
                            Else
                                dr("row3") = ""
                            End If

                        Else
                            If dtl = "" Then
                                dtl = "เลขที่"
                            End If
                            If lcnno <> "" Then
                                dr("row3") = dtl & " " & lcnno
                            Else
                                dr("row3") = ""
                            End If

                        End If
                    Next
                Else
                    txt = dao_det.fields.TXT_LCNNO

                    Try
                        lcnno = dao_det.fields.LCNNO

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
                End If
                If is_l44 = 1 Then
                    dtl = "เลขที่"
                    'If Right(rcvno_txt, 1) = "R" Then
                    '    dtl = "เลขรับคำร้องที่"
                    'ElseIf Right(rcvno_txt, 1) = "C" Then
                    '    dtl = "เลขตรวจคำขอที่"
                    'ElseIf Right(rcvno_txt, 1) = "A" Then
                    '    dtl = "เลขรับประเมินคำขอที่"
                    'Else
                    '    If Len(rcvno_txt) >= 9 Then
                    '        dtl = "เลขที่อ้างอิงชำระเงิน"
                    '    End If
                    'End If
                End If


                If row3_44 = "" Then
                    row3_44 = dao_det.fields.LCNNO '"(" & dtl & " "
                Else
                    row3_44 &= "," & dao_det.fields.LCNNO
                End If
            Next

            row3_44 = "(" & row3_44 & ")" '"(" & dtl & " " & row3_44 & ")"
            For Each dr As DataRow In dt2.Rows
                'dr("item_c") = ii
                'dr("row2") = "(จำนวน " & ii & " ฉบับ ฉบับละ " & amt.ToString("N") & " บาท)"
                'dr("row3") = lcnno


                'If is_l44 = 1 Then
                '    dr("row3") = dtl & " " & rcvno_txt
                'Else
                '    dr("row3") = dtl & " " & lcnno
                'End If
                If is_l44 = 1 Then
                    'dr("feetpnm") = "เลขที่อ้างอิงชำระเงิน"
                    'dr("row2") = row3_44
                End If
            Next

            'If ii > 0 And ii <= 1 Then
            '    For Each dr As DataRow In dt2.Rows
            '        dr("feetpnm") &= " " & txt & " " & lcnno
            '        dr("item_c") = ii
            '    Next
            'Else



            ' End If

            dt = dt2
        End If


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
                Dim BANK_SHORT_NAME As String = ""
                If dao3.fields.RECEIVE_MONEY_TYPE = 2 Then
                    Dim dao_b As New DAO_MAS.TB_MAS_BANK
                    Try
                        dao_b.Getdata_by_BANK_ID(dao3.fields.BANK_ID)
                        BANK_SHORT_NAME = dao_b.fields.BANK_SHORT_NAME
                    Catch ex As Exception

                    End Try

                    Try
                        dr("row3") &= " (เช็คธนาคาร " & BANK_SHORT_NAME & " เลขที่ " & dao3.fields.CHECK_NUMBER & " )"
                    Catch ex As Exception

                    End Try
                End If

            Catch ex As Exception

            End Try
        Next
        Return dt
    End Function
    Public Function getReportData_receipt_fda_in_law()
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Maintain
        'dt = bao.SP_get_receipt_data_det(Request.QueryString("id_feeno"))
        dt = bao.SP_get_receipt_data_det_feeno_V2_law1(Request.QueryString("id_feeno"))
        Dim fee_format As String = feeno_format()

        'Dim dt As New DataTable
        'Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        'dao.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))
        'dt.Columns.Add("lcnsid")
        'dt.Columns.Add("feeno")
        'dt.Columns.Add("feetpnm")
        'dt.Columns.Add("ref01")
        'dt.Columns.Add("amt", GetType(Double))
        'dt.Columns.Add("value", GetType(Double))
        'dt.Columns.Add("feeabbr")
        'dt.Columns.Add("fee_no_5")
        'dt.Columns.Add("year_fee")
        'dt.Columns.Add("rcptst")
        'dt.Columns.Add("fullname")

        dt.Columns.Add("days")
        dt.Columns.Add("years")
        dt.Columns.Add("months")
        'dt.Columns.Add("receipt_number")

        Dim is_l44 As Integer = 0
        Dim dao_re1 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        Dim dao_rd As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
        Dim rcvno_txt As String = ""
        Try
            dao_re1.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))
            is_l44 = dao_re1.fields.IS_L44

            dao_rd.Getdata_by_RECEIVE_MONEY_ID(dao_re1.fields.RECEIVE_MONEY_ID)
            rcvno_txt = dao_rd.fields.rcvno
            If Len(Trim(rcvno_txt)) = 0 Then
                rcvno_txt = dao_rd.fields.LCNNO
            End If
        Catch ex As Exception

        End Try


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

        Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY

        Dim i As Integer = 0
        '
        If Request.QueryString("id_feeno") <> "" Then
            Dim dao2 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao2.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))
            i = dao.count_receipt_by_ref_E(dao2.fields.REF01, dao2.fields.REF02)
        Else
            i = dao.count_receipt4(Request.QueryString("dvcd"), Request.QueryString("feeno"), Request.QueryString("feeabbr"))
        End If

        ' If i = 0 Then
        'Dim dao_i As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        'dao_i.fields.RECEIVE_MONEY_TYPE = 1
        'dao_i.fields.RECEIVE_MONEY_DESCRIPTION = dt(0)("feetpnm")
        'dao_i.fields.FULLNAME = dt(0)("fullname")
        'Try
        '    dao_i.fields.CUSTOMER_ID = CStr(dt(0)("lcnsid"))
        'Catch ex As Exception

        'End Try
        'dao_i.fields.RECEIVER_MONEY_ID = 0
        'dao_i.fields.RECEIVE_AMOUNT = dt(0)("amt")
        'dao_i.fields.DEPARTMENT_ID = 0
        'dao_i.fields.ORDER_PAY1 = Request.QueryString("feeabbr")
        'dao_i.fields.ORDER_PAY2 = fee_format
        'dao_i.fields.MONEY_RECEIVE_DATE = Date.Now
        'dao_i.fields.FEEABBR = Request.QueryString("feeabbr")
        'dao_i.fields.FEENO = fee_format
        'Try
        '    dao_i.fields.LCNSID = dt(0)("lcnsid")
        'Catch ex As Exception

        'End Try

        'dao_i.fields.BUDGET_YEAR = years
        'dao_i.fields.RECEIPT_TYPE = 1
        'Try
        '    dao_i.fields.REF01 = dt(0)("ref01")
        'Catch ex As Exception

        'End Try
        'Try
        '    dao_i.fields.REF02 = dt(0)("ref02")
        'Catch ex As Exception

        'End Try

        'dao_i.fields.MONEY_TYPE_ID = 1
        'dao_i.fields.DVCD = Request.QueryString("dvcd")

        'If Request.QueryString("staff") <> "" Then
        '    dao_i.fields.STAFF_IDEN = _CLS.CITIZEN_ID
        'End If

        'Dim bao2 As New BAO_BUDGET.Maintain
        'Dim max_id As Integer = 0
        'Try
        '    max_id = bao2.get_max_receipt_normal(Request.QueryString("myear"), 2)
        'Catch ex As Exception

        'End Try
        'dao_i.fields.E_RUNNING_RECEIPT = max_id + 1
        'dao_i.fields.FULL_RECEIVE_NUMBER = Right(years, 2) & "/" & max_id + 1
        'dao_i.insert()

        'For Each dr As DataRow In dt.Rows
        '    Dim dao_det As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
        '    dao_det.fields.FK_IDA = dao_i.fields.RECEIVE_MONEY_ID
        '    Try
        '        dao_det.fields.AMOUNT = dr("amt")
        '    Catch ex As Exception
        '        dao_det.fields.AMOUNT = 0
        '    End Try
        '    dao_det.fields.FEEABBR = Request.QueryString("feeabbr")
        '    dao_det.fields.TABEAN_NUMBER = ""
        '    dao_det.insert()
        'Next



        ''receipt_num = Right(years,2) & "/" 
        'For Each dr As DataRow In dt.Rows
        '    dr("days") = days
        '    dr("years") = years
        '    dr("months") = str_month
        '    dr("receipt_number") = "-"
        'Next
        'Else

            Dim dt2 As New DataTable
            Dim bao2 As New BAO_BUDGET.Maintain
            dt2 = bao2.SP_get_receipt_data_det_feeno_V2_law1(Request.QueryString("id_feeno"))

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
            dao_det.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))
            Dim txt_amt As String = ""
            For Each dao_det.fields In dao_det.datas
                ii += 1
                Dim amountt As Double = dao_det.fields.AMOUNT
                If txt_amt = "" Then

                    txt_amt = amountt.ToString("N")
                Else
                    txt_amt = txt_amt & "," & amountt.ToString("N")
                End If
            Next
            Dim row3_44 As String = ""
            For Each dao_det.fields In dao_det.datas
                'ii += 1
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
                Dim dao_re As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                dao_re.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))
                Dim is_law44 As Integer = 0
                Try
                    is_law44 = dao_re.fields.IS_L44
                Catch ex As Exception

                End Try
                If is_law44 = 0 Then
                    Try
                        If lcnno_det <> "" And Len(lcnno_det) > 6 Then
                            If lcnno = "" Then
                                lcnno = appabbr & " " & CInt(Right(dao_det.fields.LCNNO, 5)) & "/25" & Left(dao_det.fields.LCNNO, 2)
                            Else
                                lcnno &= " ," & appabbr & " " & CInt(Right(dao_det.fields.LCNNO, 5)) & "/25" & Left(dao_det.fields.LCNNO, 2)
                            End If
                        Else
                            If lcnno = "" Then
                                lcnno = rcvabbr & " " & CInt(Right(dao_det.fields.rcvno, 5)) & "/25" & Left(dao_det.fields.rcvno, 2)
                            Else
                                lcnno &= " ," & rcvabbr & " " & CInt(Right(dao_det.fields.rcvno, 5)) & "/25" & Left(dao_det.fields.rcvno, 2)
                            End If
                        End If
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
                    'If is_l44 = 1 Then
                    '    If Right(rcvno_txt, 1) = "R" Then
                    '        dtl = "เลขรับคำร้องที่"
                    '    ElseIf Right(rcvno_txt, 1) = "C" Then
                    '        dtl = "เลขตรวจคำขอที่"
                    '    ElseIf Right(rcvno_txt, 1) = "A" Then
                    '        dtl = "เเลขรับประเมินคำขอที่"
                    '    Else
                    '        If Len(rcvno_txt) >= 9 Then
                    '            dtl = "เลขที่อ้างอิงชำระเงิน"
                    '        End If
                    '    End If
                    'End If
                    For Each dr As DataRow In dt2.Rows
                        dr("item_c") = ii
                        'If is_law44 <> 1 Then
                        'dr("row2") = "(จำนวน " & ii & " ฉบับ ฉบับละ " & amt.ToString("N") & " บาท)"
                        'Dim dao_h As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                        'dao_h.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))
                        'If dao_h.fields.
                        'If ii > 1 Then

                        dr("row2") = "(จำนวน " & ii & " ฉบับ จำนวนเงิน " & txt_amt & " บาท)"
                        'Else
                        '    dr("row2") = "(จำนวน " & ii & " ฉบับ ฉบับละ " & amt.ToString("N") & " บาท)"
                        'End If

                        'End If
                        'dr("row3") = dtl & " " & lcnno
                        If dtl = "" Then
                            dtl = "เลขที่"
                        End If
                        If is_law44 = 1 Then
                            If rcvno_txt <> "" Then
                                dr("row3") = dtl & " " & rcvno_txt
                            Else
                                dr("row3") = ""
                            End If

                        Else
                            If lcnno <> "" Then
                                dr("row3") = dtl & " " & lcnno
                            Else
                                dr("row3") = ""
                            End If

                        End If
                    Next
                Else
                    txt = dao_det.fields.TXT_LCNNO

                    Try
                        lcnno = dao_det.fields.LCNNO

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
                End If
                If is_l44 = 1 Then
                    dtl = "เลขที่"
                    'If Right(rcvno_txt, 1) = "R" Then
                    '    dtl = "เลขรับคำร้องที่"
                    'ElseIf Right(rcvno_txt, 1) = "C" Then
                    '    dtl = "เลขตรวจคำขอที่"
                    'ElseIf Right(rcvno_txt, 1) = "A" Then
                    '    dtl = "เลขรับประเมินคำขอที่"
                    'Else
                    '    If Len(rcvno_txt) >= 9 Then
                    '        dtl = "เลขที่อ้างอิงชำระเงิน"
                    '    End If
                    'End If
                End If


                If row3_44 = "" Then
                    row3_44 = dao_det.fields.LCNNO '"(" & dtl & " "
                Else
                    row3_44 &= "," & dao_det.fields.LCNNO
                End If
            Next

            row3_44 = "(" & row3_44 & ")" '"(" & dtl & " " & row3_44 & ")"
            'For Each dr As DataRow In dt2.Rows
            'dr("item_c") = ii
            'dr("row2") = "(จำนวน " & ii & " ฉบับ ฉบับละ " & amt.ToString("N") & " บาท)"
            'dr("row3") = lcnno


            'If is_l44 = 1 Then
            '    dr("row3") = dtl & " " & rcvno_txt
            'Else
            '    dr("row3") = dtl & " " & lcnno
            'End If
            'If is_l44 = 1 Then
            '    dr("feetpnm") = "เลขที่อ้างอิงชำระเงิน"
            '    dr("row2") = row3_44
            'End If
            'Next
            For Each dr As DataRow In dt2.Rows
                dr("item_c") = ii
                'If is_law44 <> 1 Then
                'dr("row2") = "(จำนวน " & ii & " ฉบับ ฉบับละ " & amt.ToString("N") & " บาท)"
                'Dim dao_h As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                'dao_h.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))
                'If dao_h.fields.
                'If ii > 1 Then

                dr("row2") = "(จำนวน " & ii & " ฉบับ จำนวนเงิน " & txt_amt & " บาท)"
                'Else
                '    dr("row2") = "(จำนวน " & ii & " ฉบับ ฉบับละ " & amt.ToString("N") & " บาท)"
                'End If

                'End If
                'dr("row3") = dtl & " " & lcnno
                If dtl = "" Then
                    dtl = "เลขที่"
                End If
                If is_l44 = 1 Then
                If row3_44 <> "" And row3_44 <> "()" Then
                    dr("row3") = dtl & " " & row3_44
                Else
                    dr("row3") = ""
                End If

                Else
                If row3_44 <> "" And row3_44 <> "()" Then
                    dr("row3") = dtl & " " & row3_44
                Else
                    dr("row3") = ""
                End If

                End If

            Next


            'If ii > 0 And ii <= 1 Then
            '    For Each dr As DataRow In dt2.Rows
            '        dr("feetpnm") &= " " & txt & " " & lcnno
            '        dr("item_c") = ii
            '    Next
            'Else



            ' End If

            dt = dt2
            'End If


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
            Dim BANK_SHORT_NAME As String = ""
                Try
                    dao3.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))

                    If dao3.fields.RECEIVE_MONEY_TYPE = 2 Then
                        Dim dao_b As New DAO_MAS.TB_MAS_BANK
                        Try
                            dao_b.Getdata_by_BANK_ID(dao3.fields.BANK_ID)
                        BANK_SHORT_NAME = dao_b.fields.BANK_SHORT_NAME
                        Catch ex As Exception

                        End Try

                    Try
                        dr("row3") &= " (เช็คธนาคาร " & BANK_SHORT_NAME & " เลขที่ " & dao3.fields.CHECK_NUMBER & " )"
                    Catch ex As Exception

                    End Try
                    End If

                Catch ex As Exception

                End Try
            Next
            Return dt
    End Function
    Public Function getReportData_receipt_fda_in_rt3() As DataTable
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Maintain
        'dt = bao.SP_get_receipt_data_det(Request.QueryString("id_feeno"))
        dt = bao.SP_get_receipt_data_det_feeno_V2(Request.QueryString("id_feeno"))
        Dim fee_format As String = feeno_format()
        dt.Columns.Add("days")
        dt.Columns.Add("years")
        dt.Columns.Add("months")
        Try
            dt.Columns.Add("item_c")
            dt.Columns.Add("row2")
            dt.Columns.Add("row3")
        Catch ex As Exception

        End Try
        'dt.Columns.Add("receipt_number")


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

        Dim dt2 As New DataTable
        Dim bao2 As New BAO_BUDGET.Maintain
        dt2 = bao2.SP_get_receipt_data_det_feeno_V2(Request.QueryString("id_feeno"))

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
        dao_det.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))

        Dim dao_re As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        dao_re.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))
        Dim is_law44 As Integer = 0
        Try
            is_law44 = dao_re.fields.IS_L44
        Catch ex As Exception

        End Try
        If is_law44 = 0 Then
            For Each dao_det.fields In dao_det.datas
                ii += 1
                txt = dao_det.fields.TXT_LCNNO

                Try
                    If lcnno = "" Then
                        lcnno = CInt(Right(dao_det.fields.LCNNO, 5)) & "/25" & Left(dao_det.fields.LCNNO, 2)
                    Else
                        lcnno &= " ," & CInt(Right(dao_det.fields.LCNNO, 5)) & "/25" & Left(dao_det.fields.LCNNO, 2)
                    End If

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
        Else
            txt = dao_det.fields.TXT_LCNNO

            Try
                lcnno = dao_det.fields.LCNNO

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
        End If
        
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


            Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            Try
                dao.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))

                If dao.fields.RECEIVE_MONEY_TYPE = 2 Then
                    Dim dao_b As New DAO_MAS.TB_MAS_BANK
                    Try
                        dao_b.Getdata_by_BANK_ID(dao.fields.BANK_ID)
                        dr("row2") = "(เช็คธนาคาร " & dao_b.fields.BANK_SHORT_NAME & " เลขที่ " & dao.fields.CHECK_NUMBER & " )"
                    Catch ex As Exception

                    End Try

                End If

            Catch ex As Exception

            End Try
            Dim dao_dd As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
            Try
                dao_dd.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))

                If dao_dd.fields.DEEKA_NUMBER IsNot Nothing Then
                    If Len(dao_dd.fields.DEEKA_NUMBER) <> 0 Then
                        dr("row2") = "ฎีกาเลขที่ " & dao_dd.fields.DEEKA_NUMBER
                    End If

                ElseIf dao_dd.fields.TABEAN_NUMBER IsNot Nothing Then
                    If Len(dao_dd.fields.TABEAN_NUMBER) <> 0 Then
                        dr("row2") = "ทะเบียนเลขที่ " & dao_dd.fields.TABEAN_NUMBER
                    End If

                End If
            Catch ex As Exception

            End Try
        Next
        Return dt
    End Function
    Private Sub runpdf_normal(ByVal dt1 As DataTable, ByVal path As String, ByVal report_datasource As String)
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
        Dim ref02 As String = ""
        Try
            ref02 = Request.QueryString("ref02")
        Catch ex As Exception

        End Try
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
        Response.AddHeader("content-disposition", "inline; filename=""" + ref02 + ".pdf" + """")
        Response.AddHeader("expires", "0")


        Response.BinaryWrite(renderedbytes)
        Response.Flush()
    End Sub
    Private Sub runpdf2(ByVal dt1 As DataTable, ByVal path As String, ByVal report_datasource As String)
        Dim WS_RUN_PDF_RECEIPTs As New WS_RUN_PDF_RECEIPTS.WS_RUN_PDF_RECEIPT
        WS_RUN_PDF_RECEIPTs.runpdf(dt1, path, report_datasource, Request.QueryString("ref02"))
        Response.Redirect("../PDF/" & Request.QueryString("ref02") & ".pdf")

    End Sub
    Private Sub runpdf(ByVal dt1 As DataTable, ByVal path As String, ByVal report_datasource As String)
        Dim rsw As New LocalReport
        rsw.ReportPath = path
        Dim reportdatasource As New ReportDataSource
        Dim ref02 As String = ""
        Try
            ref02 = Request.QueryString("ref02")

            If ref02 = "" Then
                Dim query_str As String = Request.QueryString("feeno")
                Dim decode_str As String = Request.QueryString("feeno").DecodeBase64
                Dim arr_query As String() = decode_str.Split("|")

                Dim fee_format As String = arr_query(0)
                Dim dvcd As String = ""
                Dim feeabbr As String = ""

                Dim is_l44 As Integer = 0
                Dim dao_re As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                Dim dao_rd As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
                Dim rcvno_txt As String = ""
                Try
                    dao_re.Getdata_by_feeno(fee_format)
                    is_l44 = dao_re.fields.IS_L44

                    dao_rd.Getdata_by_RECEIVE_MONEY_ID(dao_re.fields.RECEIVE_MONEY_ID)
                    rcvno_txt = dao_rd.fields.rcvno
                    ref02 = dao_re.fields.REF02
                Catch ex As Exception

                End Try
                Try
                    dvcd = arr_query(1)
                Catch ex As Exception

                End Try
                Try
                    feeabbr = arr_query(2)
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try


        reportdatasource.Value = dt1
        reportdatasource.Name = report_datasource
        rsw.DataSources.Add(reportdatasource)


        Dim ReportType As String = "PDF"
        Dim FileNameExtension As String = "pdf"

        Dim warnings As Warning() = Nothing
        Dim streams As String() = Nothing
        Dim renderedbytes As Byte() = Nothing
        renderedbytes = rsw.Render(ReportType, Nothing, Nothing, "UTF-8", FileNameExtension, streams, warnings)

        Dim ws_platten As New WS_FLATTEN.WS_FLATTEN
        renderedbytes = ws_platten.PDF_DIGITAL_SIGN(renderedbytes)

        Dim clsds As New ClassDataset
        If ref02 = "" Then
            ref02 = Request.QueryString("id_feeno")
        End If

        clsds.bynaryToobject(Server.MapPath("../PDF/") & ref02 & ".pdf", renderedbytes)

        Response.Redirect("../PDF/" & ref02 & ".pdf")

        ''ต้องให้ Content Type เป็น pdf และกำหนด filename ใน content-disposition ให้มีนามสกุลเป็น pdf เพื่อให้ IE เปิด Pdf Reader ได้ http://forums.asp.net/p/1036628/1436084.aspx
        'Response.AddHeader("Accept-Ranges", "bytes")
        'Response.AddHeader("Accept-Header", "2222")
        'Response.AddHeader("Cache-Control", "public")
        'Response.AddHeader("Cache-Control", "must-revalidate")
        'Response.AddHeader("Pragma", "public")
        ''Response.AddHeader()
        ''Response.AddHeader("Content-Encoding", "UTF-8")

        ''Response.ContentEncoding = System.Text.Encoding.Unicode   'GetEncoding(874)
        ''Response.Charset = "windows-874"
        'Response.ContentType = "application/pdf"
        'Response.AddHeader("content-disposition", "inline; filename=""" + "Test.pdf" + """")
        'Response.AddHeader("expires", "0")


        'Response.BinaryWrite(renderedbytes)
        'Response.Flush()
    End Sub
    Public Function getReportData_reciept_fda_v2()
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Maintain
        Dim receipt_num As String = ""

        Dim query_str As String = Request.QueryString("feeno")
        Dim decode_str As String = Request.QueryString("feeno").DecodeBase64
        Dim arr_query As String() = decode_str.Split("|")

        Dim fee_format As String = arr_query(0)
        'dt = bao.SP_get_receipt_by_feeabbr_and_feeno(Request.QueryString("feeno"), Request.QueryString("feeabbr"))
        'dt = bao.SP_get_receipt_by_feeabbr_and_feeno_receipt(Request.QueryString("feeno"))
        'dt = bao.SP_get_receipt_by_dvcd_and_feeno_receipt(fee_format, Request.QueryString("dvcd"))
        Dim dvcd As String = ""
        Dim feeabbr As String = ""
        'If IsNumeric(Server.UrlDecode(Request.QueryString("dvcd"))) = False Then
        '    dvcd = Server.UrlDecode(Request.QueryString("dvcd")).DecodeBase64
        'Else
        '    dvcd = Server.UrlDecode(Request.QueryString("dvcd"))
        'End If

        'If IsNumeric(Server.UrlDecode(Request.QueryString("feeabbr"))) = False Then
        '    feeabbr = Server.UrlDecode(Request.QueryString("feeabbr")).DecodeBase64
        'Else
        '    feeabbr = Server.UrlDecode(Request.QueryString("feeabbr"))
        'End If
        Dim is_l44 As Integer = 0
        Dim dao_re As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        Dim dao_rd As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
        Dim rcvno_txt As String = ""
        Try
            dao_re.Getdata_by_feeno(fee_format)
            is_l44 = dao_re.fields.IS_L44

            dao_rd.Getdata_by_RECEIVE_MONEY_ID(dao_re.fields.RECEIVE_MONEY_ID)
            rcvno_txt = dao_rd.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            dvcd = arr_query(1)
        Catch ex As Exception

        End Try
        Try
            feeabbr = arr_query(2)
        Catch ex As Exception

        End Try
        dt = bao.SP_GET_E_RECEIPT_IDV2(fee_format, dvcd, feeabbr)
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

        Dim dt2 As New DataTable
        Dim bao2 As New BAO_BUDGET.Maintain
        'dt2 = bao2.SP_get_receipt_data_det_feeno_V2(Request.QueryString("id_feeno"))
        dt2 = bao2.SP_get_receipt_data_det_feeno_dvcd_feeabbrV2(fee_format, dvcd, feeabbr)


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

                'If lcnno_det <> "" And Len(lcnno_det) > 6 Then
                '    If lcnno = "" Then
                '        lcnno = appabbr & " " & CInt(Right(dao_det.fields.LCNNO, 5)) & "/25" & Left(dao_det.fields.LCNNO, 2)
                '    Else
                '        lcnno &= " ," & appabbr & " " & CInt(Right(dao_det.fields.LCNNO, 5)) & "/25" & Left(dao_det.fields.LCNNO, 2)
                '    End If
                'Else
                '    If lcnno = "" Then
                '        lcnno = rcvabbr & " " & CInt(Right(dao_det.fields.rcvno, 5)) & "/25" & Left(dao_det.fields.rcvno, 2)
                '    Else
                '        lcnno &= " ," & rcvabbr & " " & CInt(Right(dao_det.fields.rcvno, 5)) & "/25" & Left(dao_det.fields.rcvno, 2)
                '    End If
                'End If
                'For Each dr As DataRow In dt2.Rows
                '    'dr("item_c") = ii
                '    'dr("row2") = "(จำนวน " & ii & " ฉบับ ฉบับละ " & amt.ToString("N") & " บาท)"
                '    dr("row3") = lcnno
                'Next
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
        If is_l44 = 1 Then
            If Right(rcvno_txt, 1) = "R" Then
                dtl = "เลขรับคำร้องที่"
            ElseIf Right(rcvno_txt, 1) = "C" Then
                dtl = "เลขตรวจคำขอที่"
            ElseIf Right(rcvno_txt, 1) = "A" Then
                dtl = "เลขรับประเมินคำขอที่"
            End If
        End If
        For Each dr As DataRow In dt2.Rows
            'dr("item_c") = ii
            'dr("row2") = "(จำนวน " & ii & " ฉบับ ฉบับละ " & amt.ToString("N") & " บาท)"
            If is_l44 = 1 Then
                dr("row3") = dtl & " " & rcvno_txt
            Else
                dr("row3") = dtl & " " & lcnno
            End If

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

            Dim dao22 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao22.Getdata_by_feeno(fee_format)

            Dim querystr As String = ""
            Dim feeno_re As String = ""
            feeno_re = dao22.fields.FEENO
            Dim dvcd_re As String = ""
            dvcd_re = CStr(dao22.fields.DVCD)
            Dim feebbr_re As String = ""
            feebbr_re = dao22.fields.FEEABBR
            Dim bgYear_re As String = ""
            bgYear_re = CStr(dao22.fields.BUDGET_YEAR)
            querystr = feeno_re & "|" & dvcd_re & "|" & feebbr_re & "|" & bgYear_re

            Dim url2 As String = "https://buisead.fda.moph.go.th/fda_budget/Module09/Report/Frm_Report_R9_003.aspx?feeno=" & querystr.EncodeBase64

            Dim Cls_qr As New QR_CODE.GEN_QR_CODE

            Dim ws_qrs As New WS_QR.WS_QR
            Dim img_byte As String = Cls_qr.QR_CODE_IMG(url2) 'ws_qrs.QR_CODE_B64(url2) ' 

            dr("QR_IMAGE_BYTE") = img_byte
        Next

        Return dt
    End Function
    Public Function getReportData_reciept_fda_v2_1()
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Maintain

        Dim fee_format As String = ""
        Dim dvcd As String = ""
        Dim feeabbr As String = ""

        'dt = bao.SP_GET_E_RECEIPT_IDV2(fee_format, dvcd, feeabbr)
        dt = bao.SP_GET_E_RECEIPT_BY_REF01_REF02(Request.QueryString("ref01"), Request.QueryString("ref02"))
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
            dao_re.Getdata_by_ref01_ref02(Request.QueryString("ref01"), Request.QueryString("ref02"))
            fee_format = dao_re.fields.FEENO
            dvcd = dao_re.fields.DVCD
            feeabbr = dao_re.fields.FEEABBR


            Dim dt2 As New DataTable
            Dim bao2 As New BAO_BUDGET.Maintain

            dt2 = bao2.SP_get_receipt_data_det_feeno_dvcd_feeabbrV3(Request.QueryString("ref01"), Request.QueryString("ref02"))


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

                Dim dao22 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                dao22.Getdata_by_feeno(fee_format)

                Dim querystr As String = ""
                Dim feeno_re As String = ""
                feeno_re = dao22.fields.FEENO
                Dim dvcd_re As String = ""
                dvcd_re = CStr(dao22.fields.DVCD)
                Dim feebbr_re As String = ""
                feebbr_re = dao22.fields.FEEABBR
                Dim bgYear_re As String = ""
                bgYear_re = CStr(dao22.fields.BUDGET_YEAR)
                querystr = feeno_re & "|" & dvcd_re & "|" & feebbr_re & "|" & bgYear_re

                Dim url2 As String = "https://buisead.fda.moph.go.th/fda_budget/Module09/Report/Frm_Report_R9_003.aspx?feeno=" & querystr.EncodeBase64

                Dim Cls_qr As New QR_CODE.GEN_QR_CODE

                Dim ws_qrs As New WS_QR.WS_QR
                Dim img_byte As String = Cls_qr.QR_CODE_IMG(url2) 'ws_qrs.QR_CODE_B64(url2) ' 

                dr("QR_IMAGE_BYTE") = img_byte

            Next

        End If
        Return dt
    End Function
    Public Function getReportData_reciept_fda_long()
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Maintain
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

        Dim dt2 As New DataTable
        Dim bao2 As New BAO_BUDGET.Maintain
        Dim ida As String = Request.QueryString("rn").DecodeBase64
        dt2 = bao2.Query_get_data_receipt_data_det_by_id(ida)

        dt2.Columns.Add("days")
        dt2.Columns.Add("years")
        dt2.Columns.Add("months")
        dt2.Columns.Add("item_c")
        dt2.Columns.Add("row2")
        dt2.Columns.Add("row3")

        

        For Each dr As DataRow In dt2.Rows
            Dim dao_det As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
            Dim ii As Integer = 0
            Dim txt As String = ""
            Dim lcnno As String = ""
            Dim amt As Double = 0
            Dim dtl As String = ""
            Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            Try
                dao.Getdata_by_feeno(dr("FEENO"))
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
            dr("row3") = dtl & " " & lcnno
        Next

        Return dt2
    End Function

    Private Sub btn_img_Click(sender As Object, e As ImageClickEventArgs) Handles btn_img.Click
        Dim util As New Report_Utility
        Dim url As String = "../Module09/Report/Frm_Report_Print_PDF.aspx"
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "', '_blank');", True)
        'runpdf(getReportData_receipt_fda_in(), Util.root & "Module09\Report_R9_003_V2.rdlc", "Fields_Report_R9_003")
    End Sub
End Class