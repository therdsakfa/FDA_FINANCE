Imports Telerik.Web.UI
Imports Telerik.Web.UI.Barcode
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Web
Imports ZXing
Imports ZXing.Common

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

    'Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click


    '    Dim ws_receipt As New WS_RECEIPT.WS_RECEIPT_AUTO
    '    ws_receipt.Gen_Receipt(ref1, ref2)
    'End Sub
End Class