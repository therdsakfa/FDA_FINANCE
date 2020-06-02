﻿Namespace DAO_FEE
    Public MustInherit Class MainContext
        ''' <summary>
        ''' ตัวแปรสำหรับเรียกใช้ CONTEXT ของ LINQ
        ''' </summary>
        ''' <remarks></remarks>
        Public DB As New LINQ_FEEDataContext
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
    Public Class TB_fee

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New fee
        Public Sub GetDataby_ref1_ref2(ByVal ref1 As String, ByVal ref2 As String)
            datas = (From p In db.fees Where p.ref01 = ref1 And p.ref02 = ref2 Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_feeno(ByVal feeno As String)
            datas = (From p In DB.fees Where p.feeno = feeno Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_ref2(ByVal ref2 As String)
            datas = (From p In db.fees Where p.ref02 = ref2 Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_ref1(ByVal ref1 As String)
            datas = (From p In DB.fees Where p.ref01 = ref1 Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function Countby_ref1_ref2(ByVal ref1 As String, ByVal ref2 As String) As Integer
            Dim i As Integer = 0
            datas = (From p In DB.fees Where p.ref01 = ref1 And p.ref02 = ref2 Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Sub Getdata_by_feeno_and_dvcd(ByVal feeno As String, ByVal dvcd As Integer)
            datas = From p In DB.fees Where p.feeno = feeno And p.dvcd = dvcd Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_feeno_and_feeabbr(ByVal feeno As String, ByVal feeabbr As String)
            datas = From p In DB.fees Where p.feeno = feeno And p.feeabbr = feeabbr Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_feeno_dvcd_feeabbr_and_pvncd(ByVal feeno As String, ByVal dvcd As Integer, ByVal feeabbr As String, ByVal pvncd As Integer)
            datas = From p In DB.fees Where p.feeno = feeno And p.dvcd = dvcd And p.feeabbr = feeabbr And p.pvncd = pvncd Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Function count_row_fee(ByVal feeno As String, ByVal dvcd As Integer) As Integer
            datas = From p In DB.fees Where p.feeno = feeno And p.dvcd = dvcd Select p
            Dim count_id As Integer = 0
            For Each Me.fields In datas
                count_id += 1
            Next
            Return count_id
        End Function
      
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.fees.InsertOnSubmit(fields)
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
            DB.fees.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_fee_log

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New fee_log

        Public Sub Getdata_by_ida(ByVal IDA As Integer)
            datas = From p In DB.fee_logs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Function CountPay_by_ref1_and_ref2(ByVal ref01 As String, ByVal ref02 As String) As Boolean
            Dim bool As Boolean = False
            datas = From p In DB.fee_logs Where p.ref1 = ref01 And p.ref2 = ref02 And p.RESULT = "Success" Select p

            Dim i As Integer = 0
            For Each Me.fields In datas
                i += 1
            Next
            If i > 0 Then
                bool = True
            End If
            Return bool
        End Function
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.fee_logs.InsertOnSubmit(fields)
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
            DB.fee_logs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_fee_bank
        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New feebank
        Public Sub GetDataby_ref1_ref2(ByVal ref1 As String, ByVal ref2 As String)
            datas = (From p In db.feebanks Where p.ref01 = ref1 And p.ref02 = ref2 Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdata_by_ida(ByVal IDA As Integer)
            datas = From p In DB.feebanks Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdata_by_ref01_and_ref02(ByVal ref01 As String, ByVal ref02 As String)
            datas = From p In DB.feebanks Where p.ref01 = ref01 And p.ref02 = ref02 Select p
            For Each Me.fields In datas

            Next
        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.feebanks.InsertOnSubmit(fields)
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
            DB.feebanks.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_feedtl
        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New feedtl
        Public Function GetDataby_fk_fee(ByVal fk_fee As Integer) As Double
            Dim ant As Double = 0
            datas = (From p In db.feedtls Where p.fk_fee = fk_fee Select p)
            For Each Me.fields In datas
                ant += Me.fields.amt
            Next
            Return ant
        End Function
        Public Sub Getdata_by_ida(ByVal IDA As Integer)
            datas = From p In DB.feedtls Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdata_by_fee_id(ByVal IDA As Integer)
            datas = From p In DB.feedtls Where p.fk_fee = IDA Select p
            For Each Me.fields In datas

            Next
        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.feedtls.InsertOnSubmit(fields)
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
            DB.feedtls.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_feetype
        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New feetype
        Public Sub GetDataby_feeabbr(ByVal feeabbr As String)
            datas = (From p In DB.feetypes Where p.feeabbr = feeabbr Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_feeabbr_dvcd(ByVal feeabbr As String, ByVal dvcd As String)
            datas = (From p In DB.feetypes Where p.feeabbr = feeabbr And p.dvcd = dvcd Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdata_by_ida(ByVal IDA As Integer)
            datas = From p In DB.feetypes Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdata_by_feeabbr(ByVal feeabbr As String)
            datas = From p In DB.feetypes Where p.feeabbr = feeabbr Select p
            For Each Me.fields In datas

            Next
        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.feetypes.InsertOnSubmit(fields)
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
            DB.feetypes.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_FEE_LOGS
        Inherits MainContext

        Public fields As New fee_log

        Public Sub insert()
            db.fee_logs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Function Count_Verify_by_ref1_ref2(ByVal ref1 As String, ByVal ref2 As String) As Integer
            Dim i As Integer = 0
            datas = (From p In db.fee_logs Where p.ref1 = ref1 And p.ref2 = ref2 And p.RESULT.Contains("verify") Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_FEE_FINE
        Inherits MainContext

        Public fields As New feedtl_fine

        Public Sub insert()
            DB.feedtl_fines.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Getdata_by_ida(ByVal IDA As Integer)
            datas = From p In DB.feedtl_fines Where p.ida = IDA Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdata_by_fk_fee(ByVal fk_fee As Integer)
            datas = From p In DB.feedtl_fines Where p.fk_fee = fk_fee Select p
            For Each Me.fields In datas

            Next
        End Sub
    End Class
End Namespace
