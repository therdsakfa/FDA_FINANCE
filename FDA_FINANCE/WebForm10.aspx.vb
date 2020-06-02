Imports System.IO
Imports QRCoder
Imports System.Drawing
Imports System.DateTime
Imports System.Xml.Serialization

Public Class WebForm10
    Inherits System.Web.UI.Page
    Public bgYear As Integer = 2562
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim aa As String = ""
        'Dim response = MyBase.Response
        'Dim context = MyBase.Context
        'aa = context.Timestamp

        ' aa = TimeStampNow() 'CInt(Date.Now.ToShortDateString)

        Dim bb As Date
        bb = DateAdd(DateInterval.Year, -543, Date.Now)
        Dim max_no As Integer = 0
        Dim max_no2 As Integer = 0
        Dim bao As New BAO_BUDGET.Maintain
        max_no = bao.get_max_receipt_all_by_type(2562, 1)
        max_no2 = bao.get_max_receipt_all_by_type(2562, 2)
        'Dim dao_max As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        'dao_max.Get_NUMBER_L44_MAX(2562)
        'Try
        '    max_no = dao_max.fields.RUNNING_RECEIPT
        'Catch ex As Exception

        'End Try

        'Dim dao_max2 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        'dao_max2.Get_NUMBER_MAX(2562)
        'Try
        '    max_no = dao_max2.fields.RUNNING_RECEIPT
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim dt As New DataTable
        'Dim bao As New BAO_BUDGET.DISBURSE_BUDGET

        'dt = bao.get_food()
        'For Each dr As DataRow In dt.Rows
        '    Dim dao_fees As New DAO_FEE.TB_fee
        '    dao_fees.GetDataby_ref1_ref2(dr("ref01"), dr("ref02"))
        '    Dim dao_dets As New DAO_FEE.TB_feedtl

        '    Try
        '        dao_dets.Getdata_by_fee_id(dao_fees.fields.IDA)
        '        For Each dao_dets.fields In dao_dets.datas
        '            Dim ws_foods As New WS_FOOD.WS_FOOD_JOB
        '            Try
        '                ws_foods.FOOD_SERVICE(dao_dets.fields.process_id, dao_dets.fields.fk_id)
        '            Catch ex As Exception

        '            End Try
        '        Next
        '    Catch ex As Exception

        '    End Try

        'Next



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim code As String = "fhsdjfksdfsdlfklsdjfdlsfjsdf"
        Dim qrGenerator As New QRCoder.QRCodeGenerator()

        '  qrGenerator.CreateQrCode("", QRCodeGenerator.ECCLevel.L)
        Dim qrCode As QRCoder.QRCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.L)
        Dim qrc As New QRCoder.QRCode(qrCode)
        Dim b64 As String = ""
        Dim bit As New System.Drawing.Bitmap("D:\FDA\FDA.png")
        'Using bitMap As Bitmap = qrc.GetGraphic(20)
        Using bitMap As Bitmap = qrc.GetGraphic(20, System.Drawing.Color.Black, System.Drawing.Color.White, bit, drawQuietZones:=False)
            Using ms As New MemoryStream()
                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                Dim byteImage As Byte() = ms.ToArray()
                b64 = Convert.ToBase64String(byteImage)
                RadBinaryImage1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage)
            End Using
        End Using

    End Sub
    Public Function ImageToByteArray(imageIn As System.Drawing.Image) As Byte()
        Using ms = New MemoryStream()
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            Return ms.ToArray()
        End Using
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ref01 As String = "60003017000000000"
        Dim ref02 As String = "00010552702302107"
        If chk_expdate(ref01, ref02) = True Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ใช้ได้');", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ใบสั่งหมดอายุ');", True)
        End If
    End Sub
    Private Function chk_expdate(ByVal ref01 As String, ByVal ref02 As String) As Boolean
        Dim bool As Boolean = False
        Dim count_fee As Integer = 0
        Dim dao_fee As New DAO_FEE.TB_fee
        count_fee = dao_fee.Countby_ref1_ref2(ref01, ref02)
        If count_fee = 0 Then
            'Dim bao_f As New BAO_FEE.FEE
            'Dim dt_f As New DataTable
            'dt_f = bao_f.SP_COUNT_FEE_OLD_BY_REF01(ref01)
            'Dim enddate As Date
            'For Each dr As DataRow In dt_f.Rows
            '    Dim bao_extend As New BAO_FEE.FEE
            '    Try
            '        enddate = CDate(dr("enddate"))
            '        If CDate(Date.Now) < enddate Then
            '            bool = True
            '        Else
            '            bool = False
            '        End If
            '    Catch ex As Exception
            '        bool = False
            '    End Try

            'Next
            bool = True
        Else
            Dim dao_fee2 As New DAO_FEE.TB_fee
            dao_fee2.GetDataby_ref1_ref2(ref01, ref02)
            'Dim bao_extend As New BAO_FEE.FEE
            'Dim bool_ex As Boolean = False
            Dim enddate As Date
            'bool_ex = bao_extend.Q_feetype_by_feeabbr(dao_fee2.fields.feeabbr)
            'If bool_ex = True Then
            Try
                enddate = CDate(dao_fee2.fields.enddate)
                If CDate(Date.Now) <= enddate Then
                    bool = True
                Else
                    bool = False
                End If
            Catch ex As Exception
                bool = False
            End Try
            'End If

        End If
        Return bool
    End Function

    Private Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        Upload_and_insert()
    End Sub
    Private Sub Upload_and_insert()
        Dim fu As FileUpload = FileUpload1
        Dim textLine As String
        Dim dt As New DataTable
        dt.Columns.Add("col1")
        dt.Columns.Add("col2")
        dt.Columns.Add("col3")
        dt.Columns.Add("col4")
        dt.Columns.Add("col5")

        If fu.HasFile Then
            Dim reader As New StreamReader(fu.FileContent, System.Text.Encoding.ASCII)

            Do

                ' do your coding 
                'Loop trough txt file and add lines to ListBox1  
                Dim ref01 As String = ""
                Dim ref02 As String = ""
                textLine = reader.ReadLine()
                Dim dr As DataRow = dt.NewRow()
                Dim aaa As String() = Nothing
                Dim bba As String = ""
                Dim cleanedString As String = ""
                Dim col4 As String = ""
                Dim col5 As String = ""
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
                ref01 = Trim(Right(Left(textLine, 104), 20))
                ref02 = Trim(Right(Left(textLine, 124), 20))

                'Dim initialString As String = textLine
                'Dim nonNumericCharacters As New System.Text.RegularExpressions.Regex("\D")
                'Dim numericOnlyString As String = nonNumericCharacters.Replace(initialString, String.Empty)
                col4 = Trim(Right(Left(textLine, 202), 58))
                col5 = Trim(Right(textLine, 13))
                If left_text = "D" Then
                    Dim col1 As String = "" 'aaa(0)
                    'Dim len_col1 As Integer = Len(col1)
                    col1 = Trim(textLine.Substring(0, 84))

                    Try
                        dr("col1") = col1
                    Catch ex As Exception

                    End Try

                    If col5.Contains("1810CNET") Then
                        Try
                            'ref01
                            dr("col2") = ref02

                        Catch ex As Exception

                        End Try
                        Try
                            'ref02
                            dr("col3") = ref01

                        Catch ex As Exception

                        End Try
                    Else
                        Try
                            'ref01
                            dr("col2") = ref01

                        Catch ex As Exception

                        End Try
                        Try
                            'ref02
                            dr("col3") = ref02

                        Catch ex As Exception

                        End Try
                    End If

                    Try
                        dr("col4") = col4

                    Catch ex As Exception

                    End Try
                    Try
                        dr("col5") = col5
                    Catch ex As Exception

                    End Try

                    Dim dao As New DAO_MAS.TB_LOG_PAY_FROM_SCB
                    Dim bool As Boolean = False

                    bool = dao.Count_data_by_ref01_ref02(ref01, ref02)
                    dt.Rows.Add(dr)

                End If

            Loop While reader.Peek() <> -1
            reader.Close()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('อัพโหลดข้อมูลเรียบร้อย');", True)
        End If
    End Sub
    Function SerializeObject(ByVal dt As DataTable, ByVal dt_name As String) As String
        Dim ds As New DataSet
        ds.Tables.Add(dt)
        ds.Tables(0).TableName = dt_name
        Dim xmlSerializer As New XmlSerializer(ds.GetType)
        Dim str_xml As String = ""
        Using textWriter As New StringWriter()
            xmlSerializer.Serialize(textWriter, ds)
            str_xml = textWriter.ToString()
            Return str_xml
        End Using
    End Function

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim dao As New DAO_MAS.TB_MAS_BANK
        dao.Getdata()
        Dim dt As New DataTable
        dt = dao.dt
        Dim txt As String = ""
        txt = SerializeObject(dt, "MAS_BANK")
    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim dao As New DAO_FDA_SPECIAL_PAYMENT.TB_SYSTEMS_PAYMENT_DETAIL
        dao.GetDataby_IDA(155310)
        Dim aa As String = ""
        aa = dao.fields.REF_NO
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim max_id As Integer = 0
        Dim FULL_RECEIVE_NUMBER As String = ""
        Dim bao_max As New BAO_BUDGET.Maintain
        If Request.QueryString("law") = "" Then
            max_id = bao_max.get_max_receipt_normal(bgYear, 1)
        Else
            max_id = bao_max.get_max_receipt_normal_M44(bgYear, 1)
        End If
        Dim max_id_new As Integer = 0
        If Request.QueryString("pre") = "" Then
            max_id_new = Get_Max_NO()
            If max_id = max_id_new Then
                max_id_new = max_id_new + 1
            Else
                max_id_new = Get_Max_NO()
                max_id_new = max_id_new + 1
            End If
            FULL_RECEIVE_NUMBER = Right(bgYear, 2) & "/" & max_id_new
            If Request.QueryString("law") <> "" Then
                FULL_RECEIVE_NUMBER = "2-" & FULL_RECEIVE_NUMBER
            End If

        End If
    End Sub
    Public Function Get_Max_NO() As Integer
        Dim max_id As Integer = 0
        For i As Integer = 0 To 4
            Dim bao_max As New BAO_BUDGET.Maintain
            If Request.QueryString("law") = "" Then
                max_id = bao_max.get_max_receipt_normal(bgYear, 1)
            Else
                max_id = bao_max.get_max_receipt_normal_M44(bgYear, 1)
            End If
        Next

        Return max_id
    End Function
End Class