Namespace DAO_MDC
    Public MustInherit Class MainContext
        ''' <summary>
        ''' ตัวแปรสำหรับเรียกใช้ CONTEXT ของ LINQ
        ''' </summary>
        ''' <remarks></remarks>
        Public DB As New LINQ_FDA_MDCDataContext
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
    Public Class TB_irgt

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New irgt
        
        Public Sub GETDATA_BY_IDA(ByVal IDA As Integer)
            datas = From p In DB.irgts Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.irgts.InsertOnSubmit(fields)
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
            DB.irgts.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_ONESTOP_REQUEST

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New ONESTOP_REQUEST

        Public Sub GETDATA_BY_IDA(ByVal IDA As Integer)
            datas = From p In DB.ONESTOP_REQUESTs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.ONESTOP_REQUESTs.InsertOnSubmit(fields)
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
            DB.ONESTOP_REQUESTs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_MDC_EXPORT

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MDC_EXPORT

        Public Sub GETDATA_BY_IDA(ByVal IDA As Integer)
            datas = From p In DB.MDC_EXPORTs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MDC_EXPORTs.InsertOnSubmit(fields)
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
            DB.MDC_EXPORTs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_MDC_MC

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MDC_MC

        Public Sub GETDATA_BY_IDA(ByVal IDA As Integer)
            datas = From p In DB.MDC_MCs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MDC_MCs.InsertOnSubmit(fields)
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
            DB.MDC_MCs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_MDC_MN

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MDC_MN

        Public Sub GETDATA_BY_IDA(ByVal IDA As Integer)
            datas = From p In DB.MDC_MNs Where p.IDA = IDA Select p
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MDC_MNs.InsertOnSubmit(fields)
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
            DB.MDC_MNs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_MDC_MR

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MDC_MR

        Public Sub GETDATA_BY_IDA(ByVal IDA As Integer)
            datas = From p In DB.MDC_MRs Where p.IDA = IDA Select p
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MDC_MRs.InsertOnSubmit(fields)
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
            DB.MDC_MRs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_MDC_DIAGNOSED

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MDC_DIAGNOSED

        Public Sub GETDATA_BY_IDA(ByVal IDA As Integer)
            datas = From p In DB.MDC_DIAGNOSEDs Where p.IDA = IDA Select p
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MDC_DIAGNOSEDs.InsertOnSubmit(fields)
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
            DB.MDC_DIAGNOSEDs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_MDC_EDIT

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MDC_EDIT

        Public Sub GETDATA_BY_IDA(ByVal IDA As Integer)
            datas = From p In DB.MDC_EDITs Where p.IDA = IDA Select p
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MDC_EDITs.InsertOnSubmit(fields)
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
            DB.MDC_EDITs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_MDC_CER

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MDC_CER

        Public Sub GETDATA_BY_IDA(ByVal IDA As Integer)
            datas = From p In DB.MDC_CERs Where p.IDA = IDA Select p
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MDC_CERs.InsertOnSubmit(fields)
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
            DB.MDC_CERs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_MDC_SUBSTITUTE

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MDC_SUBSTITUTE

        Public Sub GETDATA_BY_IDA(ByVal IDA As Integer)
            datas = From p In DB.MDC_SUBSTITUTEs Where p.IDA = IDA Select p
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MDC_SUBSTITUTEs.InsertOnSubmit(fields)
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
            DB.MDC_SUBSTITUTEs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_IMPORT_OT

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New IMPORT_OT

        Public Sub GETDATA_BY_IDA(ByVal IDA As Integer)
            datas = From p In DB.IMPORT_OTs Where p.IDA = IDA Select p
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.IMPORT_OTs.InsertOnSubmit(fields)
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
            DB.IMPORT_OTs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
End Namespace
