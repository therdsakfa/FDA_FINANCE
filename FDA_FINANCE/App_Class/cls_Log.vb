Imports System.Configuration
Namespace log_event
    Public Class log
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="AD">ชื่อผู้ใช้</param>
        ''' <param name="page_name">ชื่อหน้า</param>
        ''' <param name="page_url">url</param>
        ''' <param name="detail">รายละเอียดที่กระทำ</param>
        ''' <remarks></remarks>
        Public Sub insert_log(ByVal AD As String, ByVal page_name As String, ByVal page_url As String, _
                              ByVal detail As String, ByVal tbl_name As String, ByVal key_item As Integer)
            Dim cls_l As New DAO_MAS.TB_LOG

            cls_l.fields.CREATE_DATE = Date.Now()
            cls_l.fields.LOG_DETAIL = detail
            cls_l.fields.PAGE_NAME = page_name
            cls_l.fields.PAGE_URL = page_url
            cls_l.fields.USER_AD = AD
            cls_l.fields.TABLE_NAME = tbl_name
            cls_l.fields.TABLE_KEY_REF = key_item
            cls_l.insert()
        End Sub
    End Class
End Namespace