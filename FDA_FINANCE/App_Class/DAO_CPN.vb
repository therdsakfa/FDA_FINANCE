Namespace DAO_CPN 'เบิกจ่าย
    ''' <summary>
    ''' คลาสหลักสำหรับเชื่อมต่อ LINQ_DISBURSE
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class MainContext
        ''' <summary>
        ''' ตัวแปรสำหรับเรียกใช้ CONTEXT ของ LINQ
        ''' </summary>
        ''' <remarks></remarks>
        Public DB As New LINQ_CPNDataContext
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

    Public Class TB_syslcnsid

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง BUDGET_BILL_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New syslcnsid
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.syslcnsids Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_DETAIL_ID(ByVal IDA As Integer)
            datas = From p In DB.syslcnsids Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub GetDataby_identify(ByVal identify As String)
            datas = (From p In DB.syslcnsids Where p.identify = identify Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub Getdata_by_Disburse_lcnsid(ByVal lcnsid As Integer)
            datas = From p In DB.syslcnsids Where p.lcnsid = lcnsid Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.syslcnsids.InsertOnSubmit(fields)
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
            DB.syslcnsids.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_syslcnsnm

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง BUDGET_BILL_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New syslcnsnm
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.syslcnsnms Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In DB.syslcnsnms Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In DB.syslcnsnms Where p.ID = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub GetDataby_identify(ByVal identify As String)
            datas = (From p In DB.syslcnsnms Where p.identify = identify Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub Getdata_by_Disburse_identify(ByVal identify As String)
            datas = From p In DB.syslcnsnms Where p.identify = identify Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.syslcnsnms.InsertOnSubmit(fields)
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
            DB.syslcnsnms.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_sysemail

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง BUDGET_BILL_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New sysemail
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.sysemails Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In DB.sysemails Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub GetDataby_identify(ByVal identify As String)
            datas = (From p In DB.sysemails Where p.CITIZEN_ID = identify Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.sysemails.InsertOnSubmit(fields)
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
            DB.sysemails.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
End Namespace
