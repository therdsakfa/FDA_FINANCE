Imports System.Data
Imports System.IO


Namespace DAO_WELFARE 'ระบบงบประมาณ
    ''' <summary>
    ''' คลาสหลักสำหรับเชื่อมต่อ LINQ_WELFARE
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class MainContext
        ''' <summary>
        ''' ตัวแปรสำหรับเรียกใช้ CONTEXT ของ LINQ
        ''' </summary>
        ''' <remarks></remarks>
        Public DB As New LINQ_WELFAREDataContext
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
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง ALL_WELFARE_BILL
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_ALL_WELFARE_BILL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง ALL_WELFARE_BILL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New ALL_WELFARE_BILL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.ALL_WELFARE_BILLs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_BUDGET_WELFARE_ID(ByVal ID As Integer)
            datas = From p In DB.ALL_WELFARE_BILLs Where p.ALL_WELFARE_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงค่ารักษาพยาบาล
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_Welfare_Cure(ByVal ID As Integer)
            datas = From p In DB.ALL_WELFARE_BILLs Where p.WELFARE_ID = 2 Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงค่าเล่าเรียน
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_Welfare_Study(ByVal ID As Integer)
            datas = From p In DB.ALL_WELFARE_BILLs Where p.WELFARE_ID = 3 Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Get_Welfare_Cure_Home()
            datas = From p In DB.ALL_WELFARE_BILLs Where p.WELFARE_ID = 1 And p.WELFARE_ID = 4 Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Get_Welfare_Cremetion()
            datas = From p In DB.ALL_WELFARE_BILLs Where p.WELFARE_ID = 3 Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_Welfare_Cure_by_Cure_ID(ByVal ida As Integer)
            datas = From p In DB.ALL_WELFARE_BILLs Where p.CURE_STUDY_ID = ida Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Function chk_exist_cure(ByVal id As Integer) As Boolean
            Dim bool As Boolean = False
            Dim count_exist As Integer = 0
            datas = From p In DB.ALL_WELFARE_BILLs Where p.CURE_STUDY_ID = id Select p
            For Each Me.fields In datas
                count_exist = count_exist + 1
            Next

            If count_exist > 0 Then
                bool = True
            End If
            Return bool
        End Function
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.ALL_WELFARE_BILLs.InsertOnSubmit(fields)
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
            DB.ALL_WELFARE_BILLs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
        ''' <summary>
        ''' Export To CSV
        ''' </summary>
        ''' <remarks></remarks>
        Public Function export()

            Return DB.ALL_WELFARE_BILLs.CreateCSVFromGenericList()
        End Function



    End Class

End Namespace