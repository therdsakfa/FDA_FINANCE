Namespace DAO_USER
    ''' <summary>
    ''' คลาสหลักสำหรับเชื่อมต่อ LINQ_USER
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class MainContext
        ''' <summary>
        ''' ตัวแปรสำหรับเรียกใช้ CONTEXT ของ LINQ
        ''' </summary>
        ''' <remarks></remarks>
        Public DB As New LINQ_USERDataContext
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

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง tbl_USER
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_tbl_USER

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง tbl_USER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New tbl_USER
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.tbl_USERs Select p).ToDataTable

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลโดย ID
        ''' </summary>
        ''' <param name="ID">ID</param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal UID As Integer)
            datas = From p In DB.tbl_USERs Where p.ID = UID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลโดยชื่อ AD
        ''' </summary>
        ''' <param name="ID">ชื่อ AD</param>
        ''' <remarks></remarks>
        'Public Sub Getdata_by_AD_NAME(ByVal AD_NAME As String)
        '    datas = From p In DB.tbl_USERs Where p.AD_NAME = AD_NAME And p.SELECT_DEPT = True Select p
        '    For Each Me.fields In datas

        '    Next

        'End Sub

        Public Sub Get_dept_select_by_AD_NAME(ByVal AD_NAME As String)
            datas = From p In DB.tbl_USERs Where p.AD_NAME = AD_NAME And p.SELECT_DEPT = True Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_ad_dept(ByVal AD_NAME As String, ByVal dept As Integer)
            datas = From p In DB.tbl_USERs Where p.AD_NAME = AD_NAME And p.DEPARTMENT_ID = dept Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.tbl_USERs.InsertOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
        ''' <summary>
        ''' แก้ไขข้อมูล
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
            DB.tbl_USERs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง tbl_USER_GROUP
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_tbl_USER_GROUP

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง tbl_USER_GROUP
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New tbl_USER_GROUP
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.tbl_USER_GROUPs Select p).ToDataTable
        End Sub
        ''' <summary>
        ''' แสดงข้อมูลโดย ID
        ''' </summary>
        ''' <param name="ID">ID</param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.tbl_USER_GROUPs Where p.GROUP_ID = ID Select p
            For Each Me.fields In datas
            Next
        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.tbl_USER_GROUPs.InsertOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
        ''' <summary>
        ''' แก้ไขข้อมูล
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
            DB.tbl_USER_GROUPs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง tbl_USER_MANGE
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_tbl_USER_MANAGE

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง tbl_USER_MANAGE
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New tbl_USER_MANAGE
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.tbl_USER_MANAGEs Select p).ToDataTable
        End Sub
        ''' <summary>
        ''' แสดงข้อมูลโดย ID
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.tbl_USER_MANAGEs Where p.USER_ID = ID Select p
            For Each Me.fields In datas
            Next
        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.tbl_USER_MANAGEs.InsertOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
        ''' <summary>
        ''' แก้ไขข้อมูล
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
            DB.tbl_USER_MANAGEs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

End Namespace