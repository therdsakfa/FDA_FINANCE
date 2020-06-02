Namespace DAO_BUDGET 'ระบบงบประมาณ
    ''' <summary>
    ''' คลาสหลักสำหรับเชื่อมต่อ LINQ_BUDGET
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class MainContext
        ''' <summary>
        ''' ตัวแปรสำหรับเรียกใช้ CONTEXT ของ LINQ
        ''' </summary>
        ''' <remarks></remarks>
        Public DB As New LINQ_BUDGETDataContext
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
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง BUDGET_ADJUST
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_BUDGET_ADJUST

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง BUDGET_ADJUST
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BUDGET_ADJUST
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.BUDGET_ADJUSTs Select p).ToDataTable
            ''For Each Me.fields In datas

            ''Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_BUDGET_ADJUST_ID(ByVal ID As Integer)
            datas = From p In DB.BUDGET_ADJUSTs Where p.BUDGET_ADJUST_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_BUDGET_PLAN_ID(ByVal ID As Integer)
            datas = From p In DB.BUDGET_ADJUSTs Where p.BUDGET_PLAN_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_Dept_id(ByVal dept_id As Integer)
            dt = (From p In DB.BUDGET_ADJUSTs Where p.DEPARTMENT_ID = dept_id Select p).ToDataTable
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_Dept_id_bg_id(ByVal dept_id As Integer, ByVal bg_id As Integer)
            datas = From p In DB.BUDGET_ADJUSTs Where p.DEPARTMENT_ID = dept_id And p.BUDGET_PLAN_ID = bg_id Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.BUDGET_ADJUSTs.InsertOnSubmit(fields)
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
            DB.BUDGET_ADJUSTs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง BUDGET_TRANSFER
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_BUDGET_TRANSFER

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง BUDGET_TRANSFER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BUDGET_TRANSFER
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.BUDGET_TRANSFERs Select p).ToDataTable

        End Sub
        ''' <summary>
        ''' ดึงข้อมูลตามประเภทการโอน
        ''' </summary>
        ''' <param name="type_id"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_transfer_type(ByVal type_id As Integer, bg_id As Integer, bgyear As Integer)
            datas = From p In DB.BUDGET_TRANSFERs Select p Where p.TRANSFER_TYPE_ID = type_id And p.FROM_BUDGET_PLAN_ID = bg_id And p.BUDGET_TRANSFER_BUDGET_YEAR = bgyear
            For Each Me.fields In datas

            Next
        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_BUDGET_TRANSFER_ID(ByVal ID As Integer)
            datas = From p In DB.BUDGET_TRANSFERs Where p.BUDGET_TRANSFER_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.BUDGET_TRANSFERs.InsertOnSubmit(fields)
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
            DB.BUDGET_TRANSFERs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_BUDGET_TYPE
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_BUDGET_TYPE

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_BUDGET_TYPE
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_BUDGET_TYPE
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata(ByRef ID As Integer)
            datas = From p In DB.MAS_BUDGET_TYPEs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_BUDGET_TYPE_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_BUDGET_TYPEs Where p.BUDGET_TYPE_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_budget_year(ByVal bgyear As Integer)
            dt = (From p In DB.MAS_BUDGET_TYPEs Where p.BUDGET_YEAR = ID Select p).ToDataTable
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_BUDGET_TYPEs.InsertOnSubmit(fields)
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
            DB.MAS_BUDGET_TYPEs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class


    Public Class TB_BUDGET_ADJUST_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_BUDGET_TYPE
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BUDGET_ADJUST_DETAIL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata(ByRef ID As Integer)
            datas = From p In DB.BUDGET_ADJUST_DETAILs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.BUDGET_ADJUST_DETAILs Where p.ADJUST_DETAIL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_BG_Adjust_ID(ByVal ID As Integer)
            datas = From p In DB.BUDGET_ADJUST_DETAILs Where p.BUDGET_ADJUST_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.BUDGET_ADJUST_DETAILs.InsertOnSubmit(fields)
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
            DB.BUDGET_ADJUST_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_BUDGET_TRANSFER_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_BUDGET_TYPE
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BUDGET_TRANSFER_DETAIL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata(ByRef ID As Integer)
            datas = From p In DB.BUDGET_TRANSFER_DETAILs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal DID As Integer)
            datas = From p In DB.BUDGET_TRANSFER_DETAILs Where p.TRANSFER_OUT_DETAIL_ID = DID Select p
            For Each Me.fields In datas

            Next

        End Sub
      
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.BUDGET_TRANSFER_DETAILs.InsertOnSubmit(fields)
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
            DB.BUDGET_TRANSFER_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class


    Public Class TB_BUDGET_PO_OVERLAP

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_BUDGET_TYPE
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BUDGET_PO_OVERLAP
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata(ByRef ID As Integer)
            datas = From p In DB.BUDGET_PO_OVERLAPs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal DID As Integer)
            datas = From p In DB.BUDGET_PO_OVERLAPs Where p.OVERLAP_ID = DID Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.BUDGET_PO_OVERLAPs.InsertOnSubmit(fields)
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
            DB.BUDGET_PO_OVERLAPs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
End Namespace
