Imports Telerik.Web.UI
Imports Telerik.Web.UI.Barcode
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Web
Imports ZXing
Imports ZXing.Common
Imports Microsoft.Reporting.WebForms

Public Class WebForm9
    Inherits System.Web.UI.Page
    Implements IHttpHandler
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim _url_qr As String = ""
            TextBox1.Text = "http://164.115.28.103/fda_budget_test/Module03/Frm_Maintain_Receive_Money_L44.aspx?id_feeno=" & 5555555555 & "&test=1"

            Const StringToEncode As String = "dsdfdfd"
            Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(StringToEncode)
            Dim strModified As String = ""
            strModified = Convert.ToBase64String(byt)

            Dim ede_byte As Byte() = System.Convert.FromBase64String(strModified)
            Dim txt As String = ""
            txt = System.Text.Encoding.UTF8.GetString(ede_byte)


            Dim str_Encode As String = StringToEncode.EncodeBase64()
            Dim str_decode As String = str_Encode.DecodeBase64()


        End If
    End Sub
    Sub insert_e_bill(ByVal dvcd As Integer, ByVal feeno As String, ByVal feeabbr As String)
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.FDA_FEE
        Dim receipt_num As String = ""
        ' Dim fee_format As String = feeno_format(feeno)
        Dim fk_fee As Integer = 0
        dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum2(feeno, dvcd)

        Dim str_fullname As String = ""
        Try
            str_fullname = dt(0)("fullname")
        Catch ex As Exception

        End Try
        If str_fullname = "" Then

            Try
                Dim dao_fee_nm As New DAO_FEE.TB_fee
                dao_fee_nm.Getdata_by_feeno_dvcd_feeabbr_and_pvncd(feeno, dvcd, feeabbr, dt(0)("pvncd"))
                Try
                    str_fullname = dao_fee_nm.fields.company_name
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try

        End If

        Dim count_bg As Integer = 0
        Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        count_bg = dao.count_receipt4(dvcd, feeno, feeabbr)
        If count_bg = 0 Then
            Dim dao_i As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao_i.fields.RECEIVE_MONEY_TYPE = 1
            dao_i.fields.RECEIVE_MONEY_DESCRIPTION = dt(0)("feetpnm")
            dao_i.fields.FULLNAME = str_fullname
            dao_i.fields.CUSTOMER_ID = dt(0)("lcnsid")
            dao_i.fields.RECEIVER_MONEY_ID = 0
            dao_i.fields.RECEIVE_AMOUNT = dt(0)("amt")
            dao_i.fields.DEPARTMENT_ID = 0
            dao_i.fields.ORDER_PAY1 = feeabbr
            dao_i.fields.ORDER_PAY2 = feeno
            dao_i.fields.MONEY_RECEIVE_DATE = Date.Now
            dao_i.fields.FEEABBR = feeabbr
            dao_i.fields.FEENO = feeno
            dao_i.fields.LCNSID = dt(0)("lcnsid")
            dao_i.fields.BUDGET_YEAR = Get_BUDGET_YEAR()
            dao_i.fields.RECEIPT_TYPE = 1
            dao_i.fields.REF01 = dt(0)("ref01")
            dao_i.fields.REF02 = dt(0)("ref02")
            dao_i.fields.MONEY_TYPE_ID = 1
            dao_i.fields.DVCD = dvcd

            Dim bao2 As New BAO_BUDGET.Maintain
            Dim max_id As Integer = 0
            Dim str_num As String = ""
            Try
                max_id = bao2.get_max_receipt_normal(Get_BUDGET_YEAR(), 2)
                max_id += 1
                str_num = String.Format("{0:0000000000}", max_id.ToString("0000000000"))
            Catch ex As Exception

            End Try
            dao_i.fields.E_RUNNING_RECEIPT = max_id
            dao_i.fields.FULL_RECEIVE_NUMBER = "E-" & Right(Get_BUDGET_YEAR(), 2) & "-" & str_num
            dao_i.insert()

            Dim re_id As Integer = 0
            Try
                re_id = dao_i.fields.RECEIVE_MONEY_ID
            Catch ex As Exception

            End Try

            Dim dt_det As New DataTable
            Dim bao_dett As New BAO_FEE.FEE
            Dim dao_fee3 As New DAO_FEE.TB_fee
            dao_fee3.Getdata_by_feeno_and_dvcd(feeno, dvcd)
            Try
                fk_fee = dao_fee3.fields.IDA
            Catch ex As Exception

            End Try
            Try
                dt_det = bao_dett.SP_GET_FEEDTL_BY_FK_FEE(fk_fee)
            Catch ex As Exception

            End Try
            For Each dr As DataRow In dt_det.Rows
                Dim dao_det As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
                dao_det.fields.FK_IDA = re_id
                Try
                    dao_det.fields.AMOUNT = dr("amt")
                Catch ex As Exception
                    dao_det.fields.AMOUNT = 0
                End Try
                Try
                    dao_det.fields.FEEABBR = dr("feeabbr") 'ddl_abbr_type.SelectedValue
                Catch ex As Exception

                End Try
                Try
                    dao_det.fields.LCNNO = dr("appvno")
                Catch ex As Exception

                End Try
                dao_det.fields.TABEAN_NUMBER = ""
                Try
                    dao_det.fields.TXT_LCNNO = dr("feedtl")
                Catch ex As Exception

                End Try

                Try
                    dao_det.fields.rcvabbr = dr("rcvabbr")
                Catch ex As Exception

                End Try
                Try
                    dao_det.fields.rcvcd = dr("rcvcd")
                Catch ex As Exception

                End Try
                Try
                    dao_det.fields.rcvno = dr("rcvno")
                Catch ex As Exception

                End Try
                Try
                    dao_det.fields.appabbr = dr("appabbr")
                Catch ex As Exception

                End Try
                Try
                    dao_det.fields.appvcd = dr("appvcd")
                Catch ex As Exception

                End Try

                dao_det.insert()
            Next
        End If
    End Sub

    Public Function Get_BUDGET_YEAR() As Integer
        Dim dt As New DataTable
        dt.Columns.Add("byear")
        Dim byearMax As Integer = Year(System.DateTime.Now)
        If byearMax < 2500 Then
            byearMax = byearMax + 543
        End If
        Dim aa As Date = CDate("1/10/" & Year(System.DateTime.Now))
        If CDate(System.DateTime.Now) >= CDate("1/10/" & Year(System.DateTime.Now)) Then
            byearMax = byearMax + 1
        End If

        Return byearMax
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'insert_e_bill(4, 5910076, "9911")
        Dim ref1 As String = "59003118425591230"
        Dim ref2 As String = "54"
        Dim dao_fee2 As New DAO_FEE.TB_fee
        Dim end_date As Date
        dao_fee2.GetDataby_ref1_ref2(ref1, ref2)
        end_date = dao_fee2.fields.enddate

        If end_date < Date.Now() Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('วันเกิน');", True)

        End If
    End Sub

    Private Sub btn_read_Click(sender As Object, e As EventArgs) Handles btn_read.Click
        populateListBox()
    End Sub

    Private Sub populateListBox()
        Dim fu As FileUpload = FileUpload1
        Dim textLine As String
        Dim dt As New DataTable
        dt.Columns.Add("col1")
        dt.Columns.Add("col2")
        dt.Columns.Add("col3")
        dt.Columns.Add("col4")
        dt.Columns.Add("col5")

        If fu.HasFile Then
            Dim reader As New StreamReader(fu.FileContent)
            Do

                ' do your coding 
                'Loop trough txt file and add lines to ListBox1  

                textLine = reader.ReadLine()
                Dim dr As DataRow = dt.NewRow()
                Dim aaa As String() = Nothing
                Dim bba As String = ""
                Dim cleanedString As String = ""
                Try
                    bba = System.Text.RegularExpressions.Regex.Replace(textLine, "\s+", "|")
                    aaa = bba.Split("|")
                    'bba = strFixTab(textLine)
                Catch ex As Exception

                End Try
                Dim left_text As String = ""
                Try
                    left_text = Left(aaa(0), 1)
                Catch ex As Exception

                End Try
                If left_text = "D" Then

                    Try
                        dr("col1") = aaa(0)
                    Catch ex As Exception

                    End Try
                    Try
                        dr("col2") = aaa(1)

                    Catch ex As Exception

                    End Try
                    Try
                        dr("col3") = aaa(2)

                    Catch ex As Exception

                    End Try
                    Try
                        dr("col4") = aaa(3)

                    Catch ex As Exception

                    End Try
                    Try
                        dr("col5") = aaa(4)
                    Catch ex As Exception

                    End Try

                    dt.Rows.Add(dr)

                End If
            Loop While reader.Peek() <> -1
            reader.Close()

            Label1.Text = textLine
        End If
    End Sub
    Function strFixTab(ByVal TheStr As String) As String
        Dim c As Integer
        Dim i As Integer
        Dim T As Integer
        Dim RetStr As String = ""
        Dim ch As String
        Dim TabWidth As Integer = 8    ' Set the desired tab width

        c = 1
        For i = 1 To TheStr.Length
            ch = Mid(TheStr, i, 1)
            If ch = vbTab Then
                T = (TabWidth + 1) - (c Mod TabWidth)
                If T = TabWidth + 1 Then T = 1
                RetStr &= Space(T)
                c += T - 1
            Else
                RetStr &= ch
            End If
            If ch = vbCr Or ch = vbLf Then
                c = 1
            Else
                c += 1
            End If
        Next
        Return RetStr
    End Function

    Private Sub btn_qr_Click(sender As Object, e As EventArgs) Handles btn_qr.Click
        Dim QR As New QR_CODE.GEN_QR_CODE
        Dim query As String = "62206309|4|9910|2562"
        Dim aa As String = "http://helpb.fda.moph.go.th/fda_budget/Module09/Report/Frm_Report_R9_003.aspx?feeno=" & query.EncodeBase64
        Dim Cls_qr As New QR_CODE.GEN_QR_CODE
        Dim img_byte As String = "" ' Cls_qr.QR_CODE(aa)
        Dim ws_qrs As New WS_QR.WS_QR

        'RadBinaryImage1.DataValue = ConvertBase64ToByteArray(ws_qrs.QR_CODE_B64(aa))
        RadBinaryImage1.DataValue = ConvertBase64ToByteArray(Cls_qr.QR_CODE_IMG(aa))
    End Sub
    Public Function ConvertBase64ToByteArray(base64 As String) As Byte()
        Return Convert.FromBase64String(base64) 'Convert the base64 back to byte array.
    End Function
    Public Function ImageToByteArray(imageIn As System.Drawing.Image) As Byte()
        Using ms = New MemoryStream()
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            Return ms.ToArray()
        End Using
    End Function
    Public Sub ProcessRequest_QR(context As HttpContext)
        'begin the 8 lines o' magic
        'context.Request.QueryString("u")
        Dim _url_qr As String = ""
        _url_qr = "http://164.115.28.103/fda_budget_test/Module03/Frm_Maintain_Receive_Money_L44.aspx?id_feeno=" & 5555555555 & "&test=1"
        Dim urlToQRify As String = context.Server.UrlDecode(_url_qr)
        Dim qrWriter = New BarcodeWriter()
        qrWriter.Format = BarcodeFormat.QR_CODE
        qrWriter.Options = New EncodingOptions()
        'With { _
        '        Key.Height = 500, _
        '        Key.Width = 500, _
        '        Key.Margin = 0 _
        '    }
        'I like to make them large. You can resize them with CSS later
        Using bitmap = qrWriter.Write(urlToQRify)
            Using stream = New MemoryStream()
                context.Response.ContentType = "image/png"
                bitmap.Save(context.Response.OutputStream, ImageFormat.Png)
            End Using
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim str As String = "1234567890"
        'Dim aa As String = str.Substring(5)
        Dim ws As New WS_FDA_BG_DOC.WS_FDA_BG
        Dim dt As New DataTable
        'dt.TableName = "test"
        dt = ws.WS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEAR(2560, 4)

    End Sub

    Private Sub btn_test_ps_Click(sender As Object, e As EventArgs) Handles btn_test_ps.Click
        Dim sr As New WS_IDEM.IDEMService
        Dim a As New WS_IDEM.Profile
        'Dim p As New WS_IDEM.Prefix
        Dim b As String = ""
        a = sr.GetProfile("3250690000050")
        b = a.FullAddress
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ws_updates As New WS_UPDATE_PAY.WS_UPDATE_STATUS_PAY
        'ws_updates.Timeout = 120000
        Dim bao As New BAO_BUDGET.Budget
        Dim dt As New DataTable
        dt = bao.ERROR_BAISANG()
        For Each dr As DataRow In dt.Rows
            ws_updates.Update_Status_Pay(dr("REF01"), dr("REF02"))
        Next

    End Sub

    Protected Sub btn_update_qr_Click(sender As Object, e As EventArgs) Handles btn_update_qr.Click
        Dim dao_aa As New DAO_MAS.TB_TEMP_UPDATE_QR
        dao_aa.GetDataby_All_STAT()
        For Each dao_aa.fields In dao_aa.datas
            Dim dao22 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao22.Getdata_by_RECEIVE_MONEY_ID(dao_aa.fields.R_IDA)
            '_url_qr = "http://164.115.28.103/fda_budget/Module03/Frm_Maintain_Receive_Money_L44.aspx?id_feeno=" & re_id

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

            Dim url2 As String = "http://buisead.fda.moph.go.th/fda_budget/Module09/Report/Frm_Report_R9_003.aspx?feeno=" & querystr.EncodeBase64 'feeno=" & feeno_re & "&dvcd=" & dvcd_re & "&feeabbr=" & feebbr_re & "&myear=" & bgYear_re


            Dim Cls_qr As New QR_CODE.GEN_QR_CODE
            Dim img_byte As String = Cls_qr.QR_CODE(url2) 'Cls_qr.GenerateQR_TO_BASE64(200, 200, url2)

            Dim dao_i2 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao_i2.Getdata_by_RECEIVE_MONEY_ID(dao_aa.fields.R_IDA)
            dao_i2.fields.QR_IMAGE_BYTE = img_byte
            dao_i2.update()

            dao_aa.fields.STATUS_ID = 1
            dao_aa.update()
        Next

    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim ws_chk As New WS_CHK_PAY_CONFIRM
        Dim a As String = ws_chk.Get_Link_Receipt("630014906725630615", "630203100515000167")

        Dim b As String = ws_chk.Get_Link_Receipt_by_feeno_format("159191/63")
    End Sub

    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim chk_permiss As Boolean = False

        Try
            'chk_permiss = CHK_PERMISSION("1710500118665")
        Catch ex As Exception

        End Try
        'If chk_permiss = True Then
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As New DataTable
        dt = bao.GET_NO_NAME()
        For Each dr As DataRow In dt.Rows
            Dim dao_chk_fee As New DAO_FEE.TB_fee
            Dim dao_fee_m44 As New DAO_FEE.TB_fee
            dao_fee_m44.GetDataby_ref1_ref2(dr("ref01"), dr("ref02"))

            Dim lcnname As String = ""
            Dim e_receipt As String = ""
            Try
                lcnname = set_name_company(dao_fee_m44.fields.identify)

                Dim dao_re As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                dao_re.Getdata_by_ref01_ref02(dr("ref01"), dr("ref02"))
                dao_re.fields.FULLNAME = lcnname
                e_receipt = dao_re.fields.FULL_RECEIVE_NUMBER
                dao_re.update()

                Dim util As New Report_Utility
                'If e_receipt.Contains("E") Then
                '    runpdf(getReportData_reciept_fda_v2(), util.root & "Module09\Report_R9_003_V3_01.rdlc", "Fields_Report_R9_003", txt_ref01.Text, txt_ref02.Text)
                'End If

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ส่งข้อมูลเรียบร้อย');", True)
            Catch ex As Exception

            End Try
        Next


        'Else

        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่มีสิทธิใช้งานระบบ');", True)
        'End If
    End Sub
    Function CHK_PERMISSION(ByVal citien As String) As Boolean
        Dim bool As Boolean = False
        Dim dao As New DAO_MAS.TB_MAS_RE_UPDATE_USER
        Try
            dao.Getdata_by_citizen(citien)
            If dao.fields.IDA <> 0 Then
                bool = True
            End If
        Catch ex As Exception

        End Try
        Return bool
    End Function
    Private Function set_name_company(ByVal identify As String) As String
        Dim fullname As String = String.Empty
        Try
            'Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            'dao_syslcnsid.GetDataby_identify(identify)

            'Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            'dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(identify)

            fullname = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm


        Catch ex As Exception
            fullname = ""
        End Try

        Return fullname
    End Function
    Protected Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim chk_permiss As Boolean = False

        Try
            chk_permiss = CHK_PERMISSION("1710500118665")
        Catch ex As Exception

        End Try
        If chk_permiss = True Then
            Dim feeno_aray As String() = txt_ref01.Text.Split("/")
            Dim feeno As String = ""
            Try
                feeno = feeno_aray(1) & feeno_aray(0)
            Catch ex As Exception

            End Try
            Dim dao As New DAO_FEE.TB_fee
            dao.GetDataby_feeno(feeno)
            Dim lcnname As String = ""
            Dim e_receipt As String = ""
            Try
                lcnname = set_name_company(dao.fields.identify)

                Dim dao_re As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                dao_re.Getdata_by_ref01_ref02(txt_ref01.Text, txt_ref02.Text)
                dao_re.fields.FULLNAME = lcnname
                e_receipt = dao_re.fields.FULL_RECEIVE_NUMBER

                dao_re.update()
                Dim util As New Report_Utility
                If e_receipt.Contains("E") Then
                    runpdf(getReportData_reciept_fda_v2(), util.root & "Module09\Report_R9_003_V3_01.rdlc", "Fields_Report_R9_003", txt_ref01.Text, txt_ref02.Text)
                End If
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ส่งข้อมูลเรียบร้อย');", True)
            Catch ex As Exception

            End Try

        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่มีสิทธิใช้งานระบบ');", True)
        End If
    End Sub

    'Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click


    '    Dim ws_receipt As New WS_RECEIPT.WS_RECEIPT_AUTO
    '    ws_receipt.Gen_Receipt(ref1, ref2)
    'End Sub

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
    Private Sub runpdf(ByVal dt1 As DataTable, ByVal path As String, ByVal report_datasource As String, ByVal ref01 As String, ByVal ref02 As String)
        Dim rsw As New LocalReport
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

        Dim ws_platten As New WS_FLATTEN.WS_FLATTEN
        renderedbytes = ws_platten.PDF_DIGITAL_SIGN(renderedbytes)

        Dim clsds As New ClassDataset


        clsds.bynaryToobject(Server.MapPath("../PDF/") & ref02 & ".pdf", renderedbytes)

        ' Response.Redirect("../PDF/" & ref02 & ".pdf")

    End Sub

    Protected Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Gen_Receipt()
    End Sub
    Sub Gen_Receipt()
        'Dim dao As New DAO_MAS.TB_LOG_WAIT_RECEIPT
        'dao.GetDataby_All_NO()
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.MASS
        dt = bao.Get_LOG_WAIT_RECEIPT()

        For Each dr As DataRow In dt.Rows
            Dim str As String = ""
            Dim ws_rc As New WS_RECEIPT_AUTO
            str = ws_rc.Gen_Receipt_Wait(dr("REF01"), dr("REF02"))
            If str = "success" Then
                Dim dao_w As New DAO_MAS.TB_LOG_WAIT_RECEIPT
                dao_w.Getdata_by_ref01_ref02(dr("REF01"), dr("REF02"))
                dao_w.fields.STATUS_RECEIPT = 1
                dao_w.update()
            End If
        Next

    End Sub
End Class