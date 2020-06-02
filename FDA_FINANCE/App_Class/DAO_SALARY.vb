Namespace DAO_SALARY
    Public MustInherit Class MainContext
        ''' <summary>
        ''' ตัวแปรสำหรับเรียกใช้ CONTEXT ของ LINQ
        ''' </summary>
        ''' <remarks></remarks>
        Public DB As New LINQ_SALARYDataContext
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
    Public Class TB_SALARY

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง BUDGET_ADJUST
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New SALARY

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.SALARies Where p.IDRUN = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_ID_month(ByVal ID As Integer, ByVal month_nm As Integer)
            datas = From p In DB.SALARies Where p.IDRUN = ID And p.Month_number = month_nm Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.SALARies.InsertOnSubmit(fields)
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
            DB.SALARies.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_SALARY_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง BUDGET_ADJUST
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New SALARY_DETAIL_ID

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.SALARY_DETAIL_IDs Where p.SALARY_DETAIL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_salary_id(ByVal sal_id As Integer)
            datas = From p In DB.SALARY_DETAIL_IDs Where p.SALARY_ID = sal_id Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_salary_id_salary_list(ByVal sal_id As Integer, ByVal sl_id As Integer)
            datas = From p In DB.SALARY_DETAIL_IDs Where p.SALARY_ID = sal_id And p.SALARY_PAYLIST_ID = sl_id Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Function count_by_salary_id_salary_list(ByVal sal_id As Integer, ByVal sl_id As Integer) As Integer
            datas = From p In DB.SALARY_DETAIL_IDs Where p.SALARY_ID = sal_id And p.SALARY_PAYLIST_ID = sl_id Select p
            Dim i As Integer = 0
            For Each Me.fields In datas
                i += 1
            Next

            Return i
        End Function
        Public Sub Getdata_by_sp_idrun(ByVal sid As Integer, ByVal sp As Integer)
            datas = From p In DB.SALARY_DETAIL_IDs Where p.SALARY_ID = sid And p.SALARY_PAYLIST_ID = sp Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.SALARY_DETAIL_IDs.InsertOnSubmit(fields)
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
            DB.SALARY_DETAIL_IDs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
End Namespace
