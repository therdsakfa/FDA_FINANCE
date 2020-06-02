Namespace DAO_PROCURE
    Public MustInherit Class MainContext
        ''' <summary>
        ''' ตัวแปรสำหรับเรียกใช้ CONTEXT ของ LINQ
        ''' </summary>
        ''' <remarks></remarks>
        Public DB As New LINQ_PROCUREMENTDataContext
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
    Public Class TB_PROCUREMENT_GUARANTEE_HEAD

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง BUDGET_ADJUST
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New PROCUREMENT_GUARANTEE_HEAD

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.PROCUREMENT_GUARANTEE_HEADs Where p.G_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_G_NO(ByVal g As String)
            datas = From p In DB.PROCUREMENT_GUARANTEE_HEADs Where p.G_No = g Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.PROCUREMENT_GUARANTEE_HEADs.InsertOnSubmit(fields)
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
            DB.PROCUREMENT_GUARANTEE_HEADs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
End Namespace
