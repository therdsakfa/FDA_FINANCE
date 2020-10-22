Namespace DAO_MAS 'ข้อพื้นฐาน
    ''' <summary>
    ''' คลาสหลักสำหรับเชื่อมต่อ LINQ_MAS
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Class TBL_MAS_GL_1

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_DEPARTMENT
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_GL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        ''' 
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_GLs Where p.IDA = ID Select p
            For Each Me.fields In datas

            Next

        End Sub


        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>


        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_GLs.InsertOnSubmit(fields)
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
            DB.MAS_GLs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public MustInherit Class MainContext
        ''' <summary>
        ''' ตัวแปรสำหรับเรียกใช้ CONTEXT ของ LINQ
        ''' </summary>
        ''' <remarks></remarks>
        Public DB As New LINQ_MASDataContext
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
    Public Class TB_MAS_CUSTOMER_ADD_CER

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_CUSTOMER_ADD_CER
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.MAS_CUSTOMER_ADD_CERs Select p).ToDataTable
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_CUSTOMER_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_CUSTOMER_ADD_CERs Where p.CUS_FK = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_CUSTOMER_ADD_CERs.InsertOnSubmit(fields)
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
            DB.MAS_CUSTOMER_ADD_CERs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง BUDGET_PLAN
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_BUDGET_PLAN

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง BUDGET_PLAN
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BUDGET_PLAN
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata()
            dt = (From p In DB.BUDGET_PLANs Select p).ToDataTable
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub getdata_by_Child_id(ByVal bg_code As Integer)
            datas = From p In DB.BUDGET_PLANs Where p.BUDGET_CODE = bg_code Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub getdata_by_Child_id_join(ByVal bg_id As Integer)
            datas = From p In DB.BUDGET_PLANs Join pl In DB.BUDGET_PLAN_NODEs On p.BUDGET_PLAN_ID Equals pl.CHILD_ID _
                    Where pl.CHILD_ID = bg_id Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub getdata_by_Child_id_joinV2(ByVal bg_id As Integer)
            datas = From p In DB.BUDGET_PLANs Where p.BUDGET_PLAN_ID = bg_id Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_BUDGET_PLAN_ID(ByVal ID As Integer)
            datas = From p In DB.BUDGET_PLANs Where p.BUDGET_PLAN_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_BUDGET_CHILD_ID(ByVal ID As Integer)
            datas = From p In DB.BUDGET_PLANs Where p.BUDGET_CHILD_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_BG_YEAR(ByVal bgyear As Integer)
            datas = From p In DB.BUDGET_PLANs Where p.BUDGET_YEAR = bgyear And p.BUDGET_CHILD_ID = 0 Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_BG_YEAR_BUDGETCODE(ByVal bgyear As Integer, ByVal BUDGETCODE As String)
            datas = From p In DB.BUDGET_PLANs Where p.BUDGET_YEAR = bgyear And p.BUDGET_CODE = BUDGETCODE Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_head(ByVal bgid As Integer)
            datas = From p In DB.BUDGET_PLANs Where p.BUDGET_CHILD_ID = bgid Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_Dept_id_bg_id(ByVal bg_id As Integer)
            datas = From p In DB.BUDGET_PLANs Where p.BUDGET_PLAN_ID = bg_id Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_Head_ID(ByVal IDA As Integer, ByVal bgyear As Integer)
            datas = From p In DB.BUDGET_PLANs Where p.BUDGET_CHILD_ID = IDA And p.BUDGET_YEAR = bgyear Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Function insert() As Integer
            DB.BUDGET_PLANs.InsertOnSubmit(fields)
            DB.SubmitChanges()
            Return fields.BUDGET_PLAN_ID
        End Function
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
            DB.BUDGET_PLANs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_BANK
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_BANK

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_BANK
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_BANK
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.MAS_BANKs Select p).ToDataTable
            'For Each Me.fields In datas

            'Next
            'dt = datas.ToDataTable
        End Sub
        Public Sub Getdataall()
            datas = (From p In DB.MAS_BANKs Select p)
            For Each Me.fields In datas

            Next
        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_BANK_ID(ByVal ID As Integer)
            datas = (From p In DB.MAS_BANKs Where p.BANK_ID = ID Select p)
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_BANKs.InsertOnSubmit(fields)
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
            DB.MAS_BANKs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_CUSTOMER
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_CUSTOMER

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_CUSTOMER
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.MAS_CUSTOMERs Select p).ToDataTable
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_CUSTOMER_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_CUSTOMERs Where p.CUSTOMER_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_CUSTOMERs.InsertOnSubmit(fields)
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
            DB.MAS_CUSTOMERs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
        Public Sub Getdata_by_personalID(ByVal per As String)
            datas = From p In DB.MAS_CUSTOMERs Where p.PERSONAL_ID = per Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_CusName(ByVal per As String)
            datas = From p In DB.MAS_CUSTOMERs Where p.CUSTOMER_NAME = per Select p
            For Each Me.fields In datas

            Next

        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_CUSTOMER_TYPE
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_CUSTOMER_TYPE

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER_TYPE
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_CUSTOMER_TYPE
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.MAS_CUSTOMER_TYPEs Select p).ToDataTable
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_CUSTOMER_TYPE_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_CUSTOMER_TYPEs Where p.CUSTOMER_TYPE_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_CUSTOMER_TYPEs.InsertOnSubmit(fields)
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
            DB.MAS_CUSTOMER_TYPEs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_DEPARTMENT
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_DEPARTMENT

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_DEPARTMENT
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_DEPARTMENT
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata()
            dt = (From p In DB.MAS_DEPARTMENTs Where p.DEPARTMENT_HEAD_ID <> 0 Select p).ToDataTable
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_DEPARTMENT_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_DEPARTMENTs Where p.DEPARTMENT_ID = ID And p.DEPARTMENT_TYPE_ID IsNot Nothing Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_Dept_Code(ByVal dept_code As String)
            datas = From p In DB.MAS_DEPARTMENTs Where p.DEPARTMENT_CODE = dept_code Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_DEPARTMENTs.InsertOnSubmit(fields)
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
            DB.MAS_DEPARTMENTs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_MENU
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_MENU

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_MENU
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_MENU
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata(ByRef ID As Integer)
            datas = From p In DB.MAS_MENUs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_MENU_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_MENUs Where p.MENU_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub getData_by_parent_id(ByVal parent_id As Integer, ByVal permission_id As Integer)
            datas = From p In DB.MAS_MENUs Where p.MENU_PARENT_ID = parent_id And p.MENU_PERMISSION_ID = permission_id Select p Order By p.MENU_SEQ
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub getData_by_group(ByVal parent_id As Integer, ByVal permission_id As Integer, ByVal group_id As Integer)
            datas = From p In DB.MAS_MENUs Where p.MENU_PARENT_ID = parent_id _
                    And p.MENU_PERMISSION_ID = permission_id And p.MENU_GROUP = group_id Select p Order By p.MENU_SEQ
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub getData_menu_name_by_page_name(ByVal aspx As String)
            datas = From p In DB.MAS_MENUs Where p.MENU_URL.Contains(aspx) Select p
            For Each Me.fields In datas

            Next
        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_MENUs.InsertOnSubmit(fields)
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
            DB.MAS_MENUs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_MONEY_RECEIVER
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_MONEY_RECEIVER

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_MONEY_RECEIVER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_MONEY_RECEIVER
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.MAS_MONEY_RECEIVERs Select p).ToDataTable
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_RECEIVER_MONEY_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_MONEY_RECEIVERs Where p.RECEIVER_MONEY_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_iden(ByVal iden As String)
            datas = From p In DB.MAS_MONEY_RECEIVERs Where p.IDEN = iden Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Get_All_RECEIVER()
            datas = From p In DB.MAS_MONEY_RECEIVERs Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Get_ONLY_USE_RECEIVER()
            datas = From p In DB.MAS_MONEY_RECEIVERs Where p.IS_SHOW = True Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub get_receiver()
            datas = From p In DB.MAS_MONEY_RECEIVERs Where p.IS_RECEIVER = True Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_MONEY_RECEIVERs.InsertOnSubmit(fields)
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
            DB.MAS_MONEY_RECEIVERs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_MONEY_TYPE
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_MONEY_TYPE

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_MONEY_TYPE
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_MONEY_TYPE
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata(ByRef ID As Integer)
            datas = From p In DB.MAS_MONEY_TYPEs Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub getdata_all()
            datas = From p In DB.MAS_MONEY_TYPEs Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub getdata_by_Child_id_join(ByVal bg_id As Integer)
            datas = From p In DB.MAS_MONEY_TYPEs Join pl In DB.MAS_MONEY_TYPE_NODEs On p.MONEY_TYPE_ID Equals pl.CHILD_ID _
                    Where pl.CHILD_ID = bg_id Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_MONEY_TYPE_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_MONEY_TYPEs Where p.MONEY_TYPE_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_Head(ByVal ID As Integer, bgyear As Integer)
            datas = From p In DB.MAS_MONEY_TYPEs Where p.HEAD_MONEY_TYPE_ID = ID And p.BUDGET_YEAR = bgyear Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_Head_no_Year(ByVal money_id As Integer)
            datas = From p In DB.MAS_MONEY_TYPEs Where p.HEAD_MONEY_TYPE_ID = money_id Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_Head_non_year(ByVal ID As Integer)
            datas = From p In DB.MAS_MONEY_TYPEs Where p.HEAD_MONEY_TYPE_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_bgyear(ByVal ID As Integer, bgYear As Integer)
            datas = From p In DB.MAS_MONEY_TYPEs Where p.MONEY_TYPE_ID = ID And p.BUDGET_YEAR = bgYear Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_MONEY_TYPEs.InsertOnSubmit(fields)
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
            DB.MAS_MONEY_TYPEs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_OPERATION_TYPE
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_OPERATION_TYPE

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_OPERATION_TYPE
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_OPERATION_TYPE
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata(ByRef ID As Integer)
            datas = From p In DB.MAS_OPERATION_TYPEs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_RECEIVER_OPERATION_TYPE_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_OPERATION_TYPEs Where p.OPERATION_TYPE_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_OPERATION_TYPEs.InsertOnSubmit(fields)
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
            DB.MAS_OPERATION_TYPEs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_PAYLIST
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_PAYLIST

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_PAYLIST
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_PAYLIST
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.MAS_PAYLISTs Select p).ToDataTable
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_PAYLIST_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_PAYLISTs Where p.PATLIST_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_PAYLISTs.InsertOnSubmit(fields)
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
            DB.MAS_PAYLISTs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_MAS_MARGIN_RECEIVE

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_PAYLIST
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_MARGIN_RECEIVE
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID_RUN(ByVal ID As Integer)
            datas = From p In DB.MAS_MARGIN_RECEIVEs Where p.ID_RUN = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_MARGIN_RECEIVEs.InsertOnSubmit(fields)
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
            DB.MAS_MARGIN_RECEIVEs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_SEND_MONEY_DEPARTMENT
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_SEND_MONEY_DEPARTMENT

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_SEND_MONEY_DEPARTMENT
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_SEND_MONEY_DEPARTMENT
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.MAS_SEND_MONEY_DEPARTMENTs Select p).ToDataTable
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_SEND_MONEY_DEPARTMENT_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_SEND_MONEY_DEPARTMENTs Where p.SEND_MONEY_DEPARTMENT_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_SEND_MONEY_DEPARTMENTs.InsertOnSubmit(fields)
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
            DB.MAS_SEND_MONEY_DEPARTMENTs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_USER
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_USER

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_USER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_USER
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata()
            dt = (From p In DB.MAS_USERs Select p).ToDataTable

        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_USER_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_USERs Where p.USER_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_AD(ByVal AD As String)
            datas = From p In DB.MAS_USERs Where p.USER_AD = AD Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_USERs.InsertOnSubmit(fields)
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
            DB.MAS_USERs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_USER_PERMISSION_DETAIL
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_USER_PERMISSION_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_USER_PERMISSION_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_USER_PERMISSION_DETAIL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata(ByRef ID As Integer)
            datas = From p In DB.MAS_USER_PERMISSION_DETAILs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_USER_PERMISSION_DETAILs Where p.ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_USER_PERMISSION_DETAILs.InsertOnSubmit(fields)
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
            DB.MAS_USER_PERMISSION_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_WELFARE
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_WELFARE

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_WELFARE
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_WELFARE
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.MAS_WELFAREs Select p).ToDataTable
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_WELFARE_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_WELFAREs Where p.WELFARE_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_WELFAREs.InsertOnSubmit(fields)
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
            DB.MAS_WELFAREs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง OVERLAP_DETAIL
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_OVERLAP_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง OVERLAP_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New OVERLAP_DETAIL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata(ByRef ID As Integer)
            datas = From p In DB.OVERLAP_DETAILs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_OVERLAP_DETAIL_ID(ByVal ID As Integer)
            datas = From p In DB.OVERLAP_DETAILs Where p.OVERLAP_DETAIL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.OVERLAP_DETAILs.InsertOnSubmit(fields)
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
            DB.OVERLAP_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง OVERLAP_HEAD
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_OVERLAP_HEAD

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง OVERLAP_HEAD
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New OVERLAP_HEAD
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata()
            dt = (From p In DB.OVERLAP_HEADs Select p).ToDataTable

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_OVERLAP_HEAD_ID(ByVal ID As Integer)
            datas = From p In DB.OVERLAP_HEADs Where p.OVERLAP_HEAD_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.OVERLAP_HEADs.InsertOnSubmit(fields)
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
            DB.OVERLAP_HEADs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง BUDGET_PLAN
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_BUDGET_PLAN_NODE

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง BUDGET_PLAN
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BUDGET_PLAN_NODE
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata(ByRef ID As Integer)
            datas = From p In DB.BUDGET_PLAN_NODEs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.BUDGET_PLAN_NODEs Where p.BUDGET_PLAN_Detail_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_Head_ID(ByVal ID As Integer, ByVal bgyear As Integer)
            datas = From p In DB.BUDGET_PLAN_NODEs Join pl In DB.BUDGET_PLANs On p.CHILD_ID Equals pl.BUDGET_PLAN_ID _
                    Where p.HEAD_ID = ID And pl.BUDGET_YEAR = bgyear Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub getdata_by_Child_id(ByVal bg As Integer)
            datas = From p In DB.BUDGET_PLAN_NODEs Where p.CHILD_ID = bg Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.BUDGET_PLAN_NODEs.InsertOnSubmit(fields)
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
            DB.BUDGET_PLAN_NODEs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    Public Class TB_MONEY_TYPE_NODE

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง BUDGET_PLAN
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_MONEY_TYPE_NODE
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata(ByRef ID As Integer)
            datas = From p In DB.MAS_MONEY_TYPE_NODEs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_MONEY_TYPE_NODEs Where p.MONEY_TYPE_NODE_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_Head_ID(ByVal ID As Integer, ByVal bgyear As Integer)
            datas = From p In DB.MAS_MONEY_TYPE_NODEs Join mt In DB.MAS_MONEY_TYPEs On p.CHILD_ID Equals mt.MONEY_TYPE_ID _
                    Where p.HEAD_ID = ID And mt.BUDGET_YEAR = bgyear Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_Head_ID_no_year(ByVal BID As Integer)
            datas = From p In DB.MAS_MONEY_TYPE_NODEs Join mt In DB.MAS_MONEY_TYPEs On p.CHILD_ID Equals mt.MONEY_TYPE_ID _
                    Where p.HEAD_ID = BID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub getdata_by_Child_id(ByVal bg_code As Integer)
            datas = From p In DB.MAS_MONEY_TYPE_NODEs Where p.CHILD_ID = bg_code Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_MONEY_TYPE_NODEs.InsertOnSubmit(fields)
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
            DB.MAS_MONEY_TYPE_NODEs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_MAS_K_TYPE

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง BUDGET_PLAN
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_K_TYPE
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata(ByRef ID As Integer)
            datas = From p In DB.MAS_K_TYPEs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_K_TYPEs Where p.K_TYPE_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
       

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_K_TYPEs.InsertOnSubmit(fields)
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
            DB.MAS_K_TYPEs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    Public Class TB_MAS_DEPARTMENT_NODE

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_DEPARTMENT_NODE
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_DEPARTMENT_NODE
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata(ByRef ID As Integer)
            datas = From p In DB.MAS_DEPARTMENT_NODEs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_DEPARTMENT_NODEs Where p.DEPARTMENT_NODE_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_Head_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_DEPARTMENT_NODEs Join mt In DB.MAS_DEPARTMENTs On p.CHILD_ID Equals mt.DEPARTMENT_ID _
                    Where p.HEAD_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_Child_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_DEPARTMENT_NODEs Where p.CHILD_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_DEPARTMENT_NODEs.InsertOnSubmit(fields)
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
            DB.MAS_DEPARTMENT_NODEs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    Public Class TB_MAS_RETURN_DESCRIPTION

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_DEPARTMENT_NODE
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_RETURN_DESCRIPTION
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata(ByRef ID As Integer)
            datas = From p In DB.MAS_RETURN_DESCRIPTIONs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_RETURN_DESCRIPTIONs Where p.RETURN_DESCRIPTION_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
       
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_RETURN_DESCRIPTIONs.InsertOnSubmit(fields)
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
            DB.MAS_RETURN_DESCRIPTIONs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    Public Class TB_MAS_SUB_BUDGET

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_DEPARTMENT_NODE
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_SUB_BUDGET
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata(ByRef ID As Integer)
            datas = From p In DB.MAS_SUB_BUDGETs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_SUB_BUDGETs Where p.SUB_BUDGET_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_SUB_BUDGETs.InsertOnSubmit(fields)
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
            DB.MAS_SUB_BUDGETs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    Public Class TB_MAS_IMPORTANT_USER

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_DEPARTMENT_NODE
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_IMPORTANT_USER
       
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_IMPORTANT_USERs Where p.ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_IMPORTANT_USERs.InsertOnSubmit(fields)
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
            DB.MAS_IMPORTANT_USERs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_PRINT_CHECK_HISTORY

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_DEPARTMENT_NODE
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New TBL_PRINT_CHECK_HISTORY

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.TBL_PRINT_CHECK_HISTORies Where p.ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_chk_num(ByVal chk_num As String)
            datas = From p In DB.TBL_PRINT_CHECK_HISTORies Where p.CHECK_NUMBER = chk_num Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_Bill_ID(ByVal Bill_ID As Integer, ByVal bill_type As Integer)
            datas = From p In DB.TBL_PRINT_CHECK_HISTORies Where p.BILL_ID = Bill_ID And p.BILL_TYPE = bill_type Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.TBL_PRINT_CHECK_HISTORies.InsertOnSubmit(fields)
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
            DB.TBL_PRINT_CHECK_HISTORies.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    Public Class TB_LOG

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_DEPARTMENT_NODE
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New TBL_LOG

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal LID As Integer)
            datas = From p In DB.TBL_LOGs Where p.Log_ID = LID Select p
            For Each Me.fields In datas

            Next

        End Sub
     
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.TBL_LOGs.InsertOnSubmit(fields)
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
            DB.TBL_LOGs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    Public Class TB_TBL_PERSON_IN_REPORT

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_DEPARTMENT_NODE
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New TBL_PERSON_IN_REPORT

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal RID As Integer)
            datas = From p In DB.TBL_PERSON_IN_REPORTs Where p.R_ID = RID Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.TBL_PERSON_IN_REPORTs.InsertOnSubmit(fields)
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
            DB.TBL_PERSON_IN_REPORTs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_TEMP_BG

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_DEPARTMENT_NODE
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New TBL_TEMP_BG

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal LID As Integer)
            datas = From p In DB.TBL_TEMP_BGs Where p.BG_ID = LID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_type(ByVal LID As Integer, ByVal bgid As Integer)
            datas = From p In DB.TBL_TEMP_BGs Where p.TYPE_SELECT = LID And p.Head_ID = bgid Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.TBL_TEMP_BGs.InsertOnSubmit(fields)
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
            DB.TBL_TEMP_BGs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_Personal

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_DEPARTMENT_NODE
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_PERSONAL

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal LID As Integer)
            datas = From p In DB.MAS_PERSONALs Where p.IDRUN = LID Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_PERSONALs.InsertOnSubmit(fields)
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
            DB.MAS_PERSONALs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_MAS_POSITION

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_DEPARTMENT_NODE
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_POSITION

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal LID As Integer)
            datas = From p In DB.MAS_POSITIONs Where p.POSITION_ID = LID Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_POSITIONs.InsertOnSubmit(fields)
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
            DB.MAS_POSITIONs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class ClsDBTRANSACTION_DOWNLOAD
        Inherits MAINCONTEXT

        Public fields As New TRANSACTION_DOWNLOAD

        Public Sub insert()
            db.TRANSACTION_DOWNLOADs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TRANSACTION_DOWNLOADs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TRANSACTION_DOWNLOADs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class ClsDBTRANSACTION_UPLOAD
        Inherits MAINCONTEXT

        Public fields As New TRANSACTION_UPLOAD

        Public Sub insert()
            db.TRANSACTION_UPLOADs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TRANSACTION_UPLOADs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TRANSACTION_UPLOADs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.TRANSACTION_UPLOADs Where p.ID = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_MENU
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_MENU_AUTO

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_MENU
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_MENU_AUTO
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub getdata(ByRef ID As Integer)
            datas = From p In DB.MAS_MENU_AUTOs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_MENU_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_MENU_AUTOs Where p.MENU_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub getData_by_parent_id(ByVal parent_id As Integer, ByVal permission_id As Integer)
            datas = From p In DB.MAS_MENU_AUTOs Where p.MENU_PARENT_ID = parent_id And p.MENU_PERMISSION_ID = permission_id Select p Order By p.MENU_SEQ
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub getData_by_parent_id2(ByVal parent_id As Integer)
            datas = From p In DB.MAS_MENU_AUTOs Where p.MENU_PARENT_ID = parent_id Select p Order By p.MENU_SEQ
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub getData_by_parent_id_group2(ByVal parent_id As Integer)
            datas = From p In DB.MAS_MENU_AUTOs Where p.MENU_PARENT_ID = parent_id And p.MENU_GROUP = 2 Select p Order By p.MENU_SEQ
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub getData_by_group(ByVal parent_id As Integer, ByVal permission_id As Integer, ByVal group_id As Integer)
            datas = From p In DB.MAS_MENU_AUTOs Where p.MENU_PARENT_ID = parent_id _
                    And p.MENU_PERMISSION_ID = permission_id And p.MENU_GROUP = group_id Select p Order By p.MENU_SEQ
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub getData_menu_name_by_page_name(ByVal aspx As String)
            datas = From p In DB.MAS_MENU_AUTOs Where p.MENU_URL.Contains(aspx) Select p
            For Each Me.fields In datas

            Next
        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_MENU_AUTOs.InsertOnSubmit(fields)
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
            DB.MAS_MENU_AUTOs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    Public Class TB_MAS_STATUS_BILL_DETAIL
        Inherits MAINCONTEXT

        Public fields As New MAS_STATUS_BILL_DETAIL

        Public Sub insert()
            DB.MAS_STATUS_BILL_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            DB.MAS_STATUS_BILL_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TRANSACTION_UPLOADs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In DB.MAS_STATUS_BILL_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_MAS_REASON_REJECT_BILL
        Inherits MAINCONTEXT

        Public fields As New MAS_REASON_REJECT_BILL

        Public Sub insert()
            DB.MAS_REASON_REJECT_BILLs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            DB.MAS_REASON_REJECT_BILLs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In DB.MAS_REASON_REJECT_BILLs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In DB.MAS_REASON_REJECT_BILLs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Function count_approve(ByVal FK_IDA As Integer, ByVal bill_type As Integer, ByVal stat As Integer) As Integer

            datas = (From p In DB.MAS_REASON_REJECT_BILLs Where p.FK_IDA = FK_IDA And p.STATUS_ID = stat And p.BILL_TYPE = bill_type Select p)
            Dim counts As Integer = 0
            For Each Me.fields In datas
                counts += 1
            Next
            Return counts
        End Function

        Public Sub get_deeka_stat_del(ByVal FK_IDA As Integer, ByVal bill_type As Integer, ByVal stat As Integer)
            datas = (From p In DB.MAS_REASON_REJECT_BILLs Where p.FK_IDA = FK_IDA And p.STATUS_ID = stat And p.BILL_TYPE = bill_type Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub get_deeka_stat_g_del(ByVal FK_IDA As Integer, ByVal bill_type As Integer, ByVal stat As Integer, ByVal g As Integer)
            datas = (From p In DB.MAS_REASON_REJECT_BILLs Where p.FK_IDA = FK_IDA And p.STATUS_ID = stat And p.BILL_TYPE = bill_type And p.GROUP_ID = g Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class

    Public Class TB_TRANSFER_PAYMENT_LOG
        Inherits MAINCONTEXT

        Public fields As New TRANSFER_PAYMENT_LOG

        Public Sub insert()
            DB.TRANSFER_PAYMENT_LOGs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            DB.TRANSFER_PAYMENT_LOGs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In DB.TRANSFER_PAYMENT_LOGs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_MAS_INCOME
        Inherits MAINCONTEXT

        Public fields As New MAS_INCOME

        Public Sub insert()
            DB.MAS_INCOMEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            DB.MAS_INCOMEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In DB.MAS_INCOMEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_CHECKER
        Inherits MAINCONTEXT

        Public fields As New MAS_CHECKER

        Public Sub insert()
            DB.MAS_CHECKERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            DB.MAS_CHECKERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataby_All()

            datas = (From p In DB.MAS_CHECKERs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In DB.MAS_CHECKERs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_LOG_PAY_FROM_SCB
        Inherits MAINCONTEXT

        Public fields As New LOG_PAY_FROM_SCB

        Public Sub insert()
            DB.LOG_PAY_FROM_SCBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            DB.LOG_PAY_FROM_SCBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataby_All()

            datas = (From p In DB.LOG_PAY_FROM_SCBs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In DB.LOG_PAY_FROM_SCBs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function Count_data_by_ref01_ref02(ByVal ref01 As String, ByVal ref02 As String) As Boolean
            Dim bool As Boolean = False
            datas = (From p In DB.LOG_PAY_FROM_SCBs Where p.COL2 = ref01 And p.COL3 = ref02 Select p)
            Dim i As Integer = 0
            For Each Me.fields In datas
                i += 1
            Next
            If i > 0 Then
                bool = True
            End If
            Return bool
        End Function
        Public Sub Get_data_by_ref01_ref02(ByVal ref01 As String, ByVal ref02 As String)
            datas = (From p In DB.LOG_PAY_FROM_SCBs Where p.COL2 = ref01 And p.COL3 = ref02 Select p)
            For Each Me.fields In datas
            Next

        End Sub
    End Class
    Public Class TB_MAS_PRE_CUSTOMER

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_PRE_CUSTOMER
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.MAS_PRE_CUSTOMERs Select p).ToDataTable
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_CUSTOMER_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_PRE_CUSTOMERs Where p.CUSTOMER_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        'เรียกจากเลขบัตร ปปช
        Public Sub Getdata_by_personID(ByVal ID As String)
            datas = From p In DB.MAS_PRE_CUSTOMERs Where p.PERSONAL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub insert()
            DB.MAS_PRE_CUSTOMERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            DB.MAS_PRE_CUSTOMERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_MAS_PREFIX_v2

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_PAYLIST
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_PREFIX_v2
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.MAS_PREFIX_v2s Select p).ToDataTable
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID_PREFIX(ByVal ID As Integer)
            datas = From p In DB.MAS_PREFIX_v2s Where p.PREFIX_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_PREFIX_v2s.InsertOnSubmit(fields)
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
            DB.MAS_PREFIX_v2s.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    '
    Public Class TB_BUDGET_PLAN_ACTIVITY

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BUDGET_PLAN_ACTIVITY
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.BUDGET_PLAN_ACTIVITies Select p).ToDataTable
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_IDA(ByVal IDA As Integer)
            datas = From p In DB.BUDGET_PLAN_ACTIVITies Where p.BUDGET_PLAN_ID = IDA Select p
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            DB.BUDGET_PLAN_ACTIVITies.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            DB.BUDGET_PLAN_ACTIVITies.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_LOG_RE_UPDATE

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New LOG_RE_UPDATE
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.LOG_RE_UPDATEs Select p).ToDataTable
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_IDA(ByVal IDA As Integer)
            datas = From p In DB.LOG_RE_UPDATEs Where p.IDA = IDA Select p
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            DB.LOG_RE_UPDATEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            DB.LOG_RE_UPDATEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_MAS_RE_UPDATE_USER

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_RE_UPDATE_USER
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.MAS_RE_UPDATE_USERs Select p).ToDataTable
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_IDA(ByVal IDA As Integer)
            datas = From p In DB.MAS_RE_UPDATE_USERs Where p.IDA = IDA Select p
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub Getdata_by_citizen(ByVal citizen As String)
            datas = From p In DB.MAS_RE_UPDATE_USERs Where p.CITIZEN_ID = citizen And p.ACTIVE = 1 Select p
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            DB.MAS_RE_UPDATE_USERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            DB.MAS_RE_UPDATE_USERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_LOG_PAY_HOST_TO_HOST

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง RECEIVE_MONEY_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New LOG_PAY_HOST_TO_HOST

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_IDA(ByVal IDA As Integer)
            datas = From p In DB.LOG_PAY_HOST_TO_HOSTs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.LOG_PAY_HOST_TO_HOSTs.InsertOnSubmit(fields)
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
            DB.LOG_PAY_HOST_TO_HOSTs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_LOG_RECEIPT_ERROR

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง RECEIVE_MONEY_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New LOG_RECEIPT_ERROR

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_IDA(ByVal IDA As Integer)
            datas = From p In DB.LOG_RECEIPT_ERRORs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.LOG_RECEIPT_ERRORs.InsertOnSubmit(fields)
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
            DB.LOG_RECEIPT_ERRORs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
        
    End Class
    Public Class TB_MAS_ACCOUNT_BANK

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_BANK
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_ACCOUNT_BANK
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.MAS_ACCOUNT_BANKs Select p).ToDataTable
            'For Each Me.fields In datas

            'Next
            'dt = datas.ToDataTable
        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_BANK_ID(ByVal ID As Integer)
            datas = (From p In DB.MAS_ACCOUNT_BANKs Where p.IDA = ID Select p)
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_ACCOUNT_BANKs.InsertOnSubmit(fields)
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
            DB.MAS_ACCOUNT_BANKs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_LOG_H2H_ERROR

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง RECEIVE_MONEY_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New LOG_H2H_ERROR

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_IDA(ByVal IDA As Integer)
            datas = From p In DB.LOG_H2H_ERRORs Where p.IDA = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.LOG_H2H_ERRORs.InsertOnSubmit(fields)
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
            DB.LOG_H2H_ERRORs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_LOG_CONFIRM

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง RECEIVE_MONEY_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New LOG_CONFIRM

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_IDA(ByVal IDA As Integer)
            datas = From p In DB.LOG_CONFIRMs Where p.IDA = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Function COUNT_by_REF01_REF02(ByVal ref01 As String, ByVal ref02 As String) As Integer
            Dim i As Integer = 0
            datas = From p In DB.LOG_CONFIRMs Where p.IDA = ID Select p
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.LOG_CONFIRMs.InsertOnSubmit(fields)
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
            DB.LOG_CONFIRMs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_LOG_CONFIRM_SCB

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง RECEIVE_MONEY_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New LOG_CONFIRM_SCB

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_IDA(ByVal IDA As Integer)
            datas = From p In DB.LOG_CONFIRM_SCBs Where p.IDA = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Function COUNT_by_REF01_REF02(ByVal ref01 As String, ByVal ref02 As String) As Integer
            Dim i As Integer = 0
            datas = From p In DB.LOG_CONFIRM_SCBs Where p.IDA = ID Select p
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.LOG_CONFIRM_SCBs.InsertOnSubmit(fields)
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
            DB.LOG_CONFIRM_SCBs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_MAS_PURCHASE
        Inherits MAINCONTEXT

        Public fields As New MAS_PURCHASE

        Public Sub insert()
            DB.MAS_PURCHASEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            DB.MAS_PURCHASEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataby_All()

            datas = (From p In DB.MAS_PURCHASEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In DB.MAS_PURCHASEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_DEKA_DETAIL_BUDGET

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_DEKA_DETAIL_BUDGET
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.MAS_DEKA_DETAIL_BUDGETs Select p).ToDataTable
            'For Each Me.fields In datas

            'Next

        End Sub

        Public Sub GetDataby_All()

            datas = (From p In DB.MAS_DEKA_DETAIL_BUDGETs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_DEKA_DETAIL_BUDGETs Where p.IDA = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_DEKA_DETAIL_BUDGETs.InsertOnSubmit(fields)
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
            DB.MAS_DEKA_DETAIL_BUDGETs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_genno_temp

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New genno_temp


        Public Sub GetDataby_All()

            datas = (From p In DB.genno_temps Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In DB.genno_temps Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.genno_temps.InsertOnSubmit(fields)
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
            DB.genno_temps.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    Public Class TB_LOG_11PM

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New LOG_11PM


        Public Sub GetDataby_All()

            datas = (From p In DB.LOG_11PMs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In DB.LOG_11PMs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.LOG_11PMs.InsertOnSubmit(fields)
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
            DB.LOG_11PMs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_TEMP_UPDATE_QR

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New TEMP_UPDATE_QR


        Public Sub GetDataby_All()

            datas = (From p In DB.TEMP_UPDATE_QRs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_All_STAT()

            datas = (From p In DB.TEMP_UPDATE_QRs Where p.STATUS_ID Is Nothing Select p)
            For Each Me.fields In datas
            Next
        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In DB.TEMP_UPDATE_QRs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_RID(ByVal IDA As Integer)
            datas = From p In DB.TEMP_UPDATE_QRs Where p.R_IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.TEMP_UPDATE_QRs.InsertOnSubmit(fields)
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
            DB.TEMP_UPDATE_QRs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    Public Class TB_LOG_WAIT_RECEIPT

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New LOG_WAIT_RECEIPT


        Public Sub GetDataby_All()

            datas = (From p In DB.LOG_WAIT_RECEIPTs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_All_NO()

            datas = (From p In DB.LOG_WAIT_RECEIPTs Where p.STATUS_RECEIPT Is Nothing Select p)
            For Each Me.fields In datas
            Next
        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In DB.LOG_WAIT_RECEIPTs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_ref01_ref02(ByVal ref01 As String, ByVal ref02 As String)
            datas = From p In DB.LOG_WAIT_RECEIPTs Where p.REF01 = ref01 And p.REF02 = ref02 Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.LOG_WAIT_RECEIPTs.InsertOnSubmit(fields)
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
            DB.LOG_WAIT_RECEIPTs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
End Namespace
