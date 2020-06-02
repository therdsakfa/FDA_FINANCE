Namespace DAO_FDA_SPECIAL_PAYMENT

    Public MustInherit Class MainContext
        ''' <summary>
        ''' ตัวแปรสำหรับเรียกใช้ CONTEXT ของ LINQ
        ''' </summary>
        ''' <remarks></remarks>
        Public DB As New LINQ_FDA_SPECIAL_PAYMENTDataContext
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
    Public Class TB_PAYMENT_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New PAYMENT_DETAIL
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In DB.PAYMENT_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.PAYMENT_DETAILs.InsertOnSubmit(fields)
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
            DB.PAYMENT_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_SYSTEMS_PAYMENT_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New SYSTEMS_PAYMENT_DETAIL
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In DB.SYSTEMS_PAYMENT_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.SYSTEMS_PAYMENT_DETAILs.InsertOnSubmit(fields)
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
            DB.SYSTEMS_PAYMENT_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    '
    Public Class TB_SPD_LOG

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New SPD_LOG
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In DB.SPD_LOGs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.SPD_LOGs.InsertOnSubmit(fields)
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
            DB.SPD_LOGs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
End Namespace
