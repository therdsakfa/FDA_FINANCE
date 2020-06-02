Imports System.IO
Imports System.Xml.Serialization
Imports System.Xml
Public Class Frm_Disburse_Debtor_Upload
    Inherits System.Web.UI.Page
    Private _type_id As String = ""
    Private _ProcessID As Integer
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Sub runQuery()
        _type_id = Request.QueryString("type_id")
        _ProcessID = Request.QueryString("process")


        bao.RunAppSettings()

    End Sub
    Dim bao As New BAO.AppSettings
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        RunSession()
    End Sub

    Private Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click
        'If FileUpload1.HasFile Then
        '    Dim bao As New BAO.AppSettings
        '    bao.RunAppSettings()


        '    Dim TR_ID As String = ""
        '    Dim bao_tran As New BAO_TRANSECTION
        '    bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
        '    bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        '    TR_ID = bao_tran.insert_transection(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION


        '    Dim PDF_TRADER As String = bao._PATH_PDF_TRADER & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, TR_ID)
        '    'PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
        '    FileUpload1.SaveAs(PDF_TRADER) '"C:\path\PDF_TRADER\"

        '    'PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
        '    Dim XML_TRADER As String = bao._PATH_XML_TRADER & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)
        '    'ทำการแปลงส่ง PDF เข้าไปแล้วแปลงออกเป็น XML
        '    convert_PDF_To_XML(PDF_TRADER, XML_TRADER)


        '    '    convert_PDF_To_XML(bao._PATH_PDF_TRADER & "FA-5-2558-" & TR_ID & ".pdf", TR_ID) '"C:\path\PDF_TRADER\"
        '    Dim check As Boolean = True
        '    Try
        '        check = insrt_to_database(XML_TRADER, TR_ID)
        '        If check = True Then
        '            Alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
        '        Else

        '        End If
        '    Catch ex As Exception

        '        Alert("เกิดข้อผิดพลาดรหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
        '    End Try


        'End If
    End Sub

    ''' <summary>
    '''  ดึงค่า XML เข้าไปที่ DB
    ''' </summary>
    ''' <remarks></remarks>
    Private Function insrt_to_database(ByVal FileName As String, ByVal TR_ID As String) As Boolean
        'Dim check As Boolean = True

        'Try
        '    Dim objStreamReader As New StreamReader(FileName)
        '    Dim p2 As New CLASS_DALCN
        '    Dim x As New XmlSerializer(p2.GetType)
        '    p2 = x.Deserialize(objStreamReader)
        '    objStreamReader.Close()


        '    Dim cernumber As String = ""

        '    Dim dao As New DAO_DRUG.ClsDBdalcn
        '    dao.fields = p2.dalcns


        '    dao.fields.lcnsid = dao.fields.lcnsid


        '    dao.fields.rcvdate = Date.Now
        '    dao.fields.lmdfdate = Date.Now
        '    dao.fields.STATUS_ID = 1
        '    dao.fields.TR_ID = TR_ID
        '    ' dao.fields.FK_IDA = _IDA
        '    dao.fields.CTZNO = _CLS.CITIZEN_ID
        '    dao.fields.lcntpcd = set_lcntpcd() 'test
        '    dao.insert()

        'Catch ex As Exception
        '    check = False
        'End Try

        'Return check
    End Function




    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class