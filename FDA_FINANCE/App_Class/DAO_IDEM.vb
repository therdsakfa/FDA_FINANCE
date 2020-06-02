Namespace DAO_IDEM
    Public MustInherit Class MainContext
        ''' <summary>
        ''' ตัวแปรสำหรับเรียกใช้ CONTEXT ของ LINQ
        ''' </summary>
        ''' <remarks></remarks>
        Public DB As New LINQ_IDEMDataContext
        ''' <summary>
        ''' OBJECT เก็บค่าจาก LINQ
        ''' </summary>
        ''' <remarks></remarks>
        Public datas

        Private _ID As Integer
        ''' <summary>
        ''' ID สำหรับเรียกใช้ PK ของตาราง
        ''' </summary>
        Public Property ID() As Integer
            Get
                Return _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property

        Public dt As DataTable

        
    End Class
    Public Class TB_Person_Detail

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง BUDGET_PLAN
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New Person_Detail
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata(ByRef ID As Integer)
            datas = From p In DB.Person_Details Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_citizen_id(ByVal citizen_id As String)
            datas = From p In DB.Person_Details Where p.CitizenID = citizen_id Select p
            For Each Me.fields In datas

            Next

        End Sub


        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.Person_Details.InsertOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
        ''' <summary>
        ''' แก้ไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub update()
            DB.SubmitChanges()
        End Sub
        ''' <summary>
        ''' ลบข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub delete()
            DB.Person_Details.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
End Namespace
