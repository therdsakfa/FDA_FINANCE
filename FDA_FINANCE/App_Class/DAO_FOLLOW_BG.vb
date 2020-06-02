Namespace DAO_FOLLOW_BG
    Public MustInherit Class MainContext
        ''' <summary>
        ''' ตัวแปรสำหรับเรียกใช้ CONTEXT ของ LINQ
        ''' </summary>
        ''' <remarks></remarks>
        Public DB As New LINQ_FOLLOW_BGDataContext
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
    Public Class TB_MAS_PROJECT
        Inherits MainContext

        Public fields As New MAS_PROJECT

        Public Sub insert()
            DB.MAS_PROJECTs.InsertOnSubmit(fields)
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
            DB.MAS_PROJECTs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
        Public Sub Getdata_by_ida(ByVal IDA As Integer)
            datas = From p In DB.MAS_PROJECTs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdata_by_fk_ida(ByVal IDA As Integer)
            datas = From p In DB.MAS_PROJECTs Where p.FK_BG_IDA = IDA Select p
            For Each Me.fields In datas

            Next
        End Sub
    End Class

    Public Class TABLE_TBL_PROJECT_ACTIVITY
        Inherits MainContext

        Public fields As New TBL_PROJECT_ACTIVITY

        Public Sub insert()
            DB.TBL_PROJECT_ACTIVITies.InsertOnSubmit(fields)
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
            DB.TBL_PROJECT_ACTIVITies.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
        Public Sub Getdata_by_ida(ByVal IDA As Integer)
            datas = From p In DB.TBL_PROJECT_ACTIVITies Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdata_by_fk_IDA(ByVal IDA As Integer)
            datas = From p In DB.TBL_PROJECT_ACTIVITies Where p.FK_BG_IDA = IDA Select p
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub Getdata_by_fk_IDA2(ByVal IDA As Integer, ByVal fk_proj As Integer)
            datas = From p In DB.TBL_PROJECT_ACTIVITies Where p.FK_BG_IDA = IDA And p.FK_ID_PROJ = fk_proj Select p
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    '
    Public Class TBL_MAS_DEPARTMENT_F
        Inherits MainContext

        Public fields As New MAS_DEPARTMENT_F

        Public Sub insert()
            DB.MAS_DEPARTMENT_Fs.InsertOnSubmit(fields)
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
            DB.MAS_DEPARTMENT_Fs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
        Public Sub Getdata_by_ida(ByVal IDA As Integer)
            datas = From p In DB.MAS_DEPARTMENT_Fs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdata_by_code(ByVal code As String)
            datas = From p In DB.MAS_DEPARTMENT_Fs Where p.CODE_DEPT = code Select p
            For Each Me.fields In datas

            Next
        End Sub
    End Class
End Namespace
