Namespace DAO_MAINTAIN 'ระบบรับ/ฝากและเก็บรักษาเงิน
    ''' <summary>
    ''' คลาสหลักสำหรับเชื่อมต่อ LINQ_MAINTAIN
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class MainContext
        ''' <summary>
        ''' ตัวแปรสำหรับเรียกใช้ CONTEXT ของ LINQ
        ''' </summary>
        ''' <remarks></remarks>
        Public DB As New LINQ_MAINTAINDataContext
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
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง RETURN_MONEY_DEBTOR
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_RETURN_MONEY_DEBTOR

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง RECEIVABLE_OUTSTANDING
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New RETURN_MONEY_DEBTOR
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.RETURN_MONEY_DEBTORs Select p)
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_RETURN_MONEY_DEBTOR_ID(ByVal ID As Integer)
            datas = From p In DB.RETURN_MONEY_DEBTORs Where p.RETURN_MONEY_DEBTOR_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        'Public Function Getdata_by_return_type_1(ByVal ID As Integer) As Integer
        '    datas = From p In DB.RETURN_MONEY_DEBTORs Where p.BUDGET_DISBURSE_DEBTOR_BILL_ID = ID And p.PAY_TYPE = 1 Select p
        '    Dim digit As Integer = 0
        '    For Each Me.fields In datas
        '        digit = digit + 1
        '    Next
        '    Return digit
        'End Function
        Public Sub Getdata_by_return_type_1(ByVal ID As Integer)
            datas = From p In DB.RETURN_MONEY_DEBTORs Where p.BUDGET_DISBURSE_DEBTOR_BILL_ID = ID And p.PAY_TYPE = 1 Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_return_type_3(ByVal ID As Integer)
            datas = From p In DB.RETURN_MONEY_DEBTORs Where p.BUDGET_DISBURSE_DEBTOR_BILL_ID = ID And p.PAY_TYPE = 3 Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_return_type_4(ByVal ID As Integer)
            datas = From p In DB.RETURN_MONEY_DEBTORs Where p.BUDGET_DISBURSE_DEBTOR_BILL_ID = ID And p.PAY_TYPE = 4 Select p
            For Each Me.fields In datas

            Next

        End Sub
     
        ''' <summary>
        ''' แสดงข้อมูลโดยใช้ DEBTOR_ID
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_DEBTOR_ID(ByVal ID As Integer)
            datas = From p In DB.RETURN_MONEY_DEBTORs Where p.BUDGET_DISBURSE_DEBTOR_BILL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_Head_ID(ByVal ID As Integer)
            datas = From p In DB.RETURN_MONEY_DEBTORs Where p.HEAD_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.RETURN_MONEY_DEBTORs.InsertOnSubmit(fields)
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
            DB.RETURN_MONEY_DEBTORs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง RECEIVE_MONEY
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_RECEIVE_MONEY

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง RETURN_MONEY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New RECEIVE_MONEY
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.RECEIVE_MONEYs Select p).ToDataTable


        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_RECEIVE_MONEY_ID(ByVal IDA As Integer)
            datas = From p In DB.RECEIVE_MONEYs Where p.RECEIVE_MONEY_ID = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_dvcd_feeno_feeabbr(ByVal dvcd As String, ByVal feeno As String, ByVal feeabbr As String)
            datas = From p In DB.RECEIVE_MONEYs Where p.DVCD = dvcd And p.FEENO = feeno And p.IS_CANCEL Is Nothing And p.FEEABBR = feeabbr Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_feeno_feeabbr(ByVal feeno As String, ByVal feeabbr As String)
            datas = From p In DB.RECEIVE_MONEYs Where p.FEENO = feeno And p.FEEABBR = feeabbr Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Get_NUMBER_MAX(ByVal YEARS As Integer)
            datas = (From p In DB.RECEIVE_MONEYs Where p.BUDGET_YEAR = YEARS And p.IS_PREVIOUS Is Nothing And (p.IS_L44 Is Nothing Or p.IS_L44 = False) Order By CInt(p.RECEIVE_MONEY_ID) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub Get_NUMBER_L44_MAX(ByVal YEARS As Integer)
            datas = (From p In DB.RECEIVE_MONEYs Where p.BUDGET_YEAR = YEARS And p.IS_PREVIOUS Is Nothing And p.IS_L44 = True Order By CInt(p.RECEIVE_MONEY_ID) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub Getdata_by_receipt(ByVal lcnsid As String, ByVal feeno As String, ByVal feeabbr As String)
            datas = From p In DB.RECEIVE_MONEYs Where p.LCNSID = lcnsid And p.FEENO = feeno And p.FEEABBR = feeabbr Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdata_by_receipt2(ByVal feeno As String)
            datas = From p In DB.RECEIVE_MONEYs Where p.FEENO = feeno Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdata_by_receipt3(ByVal feeno As String, ByVal dvcd As String)
            datas = From p In DB.RECEIVE_MONEYs Where p.FEENO = feeno And p.DVCD = dvcd Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdata_by_ref01_ref02(ByVal ref01 As String, ByVal ref02 As String)
            datas = From p In DB.RECEIVE_MONEYs Where p.REF01 = ref01 And p.REF02 = ref02 Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataPrevious_L44_MAX(ByVal YEARS As Integer)
            datas = (From p In DB.RECEIVE_MONEYs Where p.BUDGET_YEAR = YEARS And p.IS_PREVIOUS = True And p.RECEIPT_TYPE = 6 Order By CInt(p.RECEIVE_MONEY_ID) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataPrevious_MAX(ByVal YEARS As Integer, ByVal RECEIPT_TYPE As Integer)
            datas = (From p In DB.RECEIVE_MONEYs Where p.BUDGET_YEAR = YEARS And p.IS_PREVIOUS = True And p.RECEIPT_TYPE = RECEIPT_TYPE Order By CInt(p.RECEIVE_MONEY_ID) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub get_dat_receive(ByVal dvcd As String, ByVal feeno As String, ByVal feeabbr As String)

            datas = From p In DB.RECEIVE_MONEYs Where p.DVCD = dvcd And p.FEENO = feeno And p.IS_CANCEL Is Nothing And p.FEEABBR = feeabbr Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Function count_receipt(ByVal lcnsid As String, ByVal feeno As String, ByVal feeabbr As String) As Integer
            Dim i As Integer = 0
            datas = From p In DB.RECEIVE_MONEYs Where p.LCNSID = lcnsid And p.FEENO = feeno And p.FEEABBR = feeabbr Select p
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Function count_receipt_by_ref(ByVal ref01 As String, ByVal ref02 As String) As Boolean
            Dim i As Integer = 0
            Dim bool As Boolean = False
            datas = From p In DB.RECEIVE_MONEYs Where p.REF01 = ref01 And p.REF02 = ref02 Select p
            For Each Me.fields In datas
                i += 1
            Next
            If i > 0 Then
                bool = True
            End If
            Return bool
        End Function
        Public Function count_receipt_by_ref_E(ByVal ref01 As String, ByVal ref02 As String) As Integer
            Dim i As Integer = 0
            datas = From p In DB.RECEIVE_MONEYs Where p.REF01 = ref01 And p.REF02 = ref02 And p.IS_CANCEL Is Nothing Select p
            For Each Me.fields In datas
                i += 1
            Next

            Return i
        End Function
        Public Function count_receipt2(ByVal lcnsid As String, ByVal feeno As String) As Integer
            Dim i As Integer = 0
            datas = From p In DB.RECEIVE_MONEYs Where p.LCNSID = lcnsid And p.FEENO = feeno Select p
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Function count_receipt3(ByVal dvcd As String, ByVal feeno As String) As Integer
            Dim i As Integer = 0
            datas = From p In DB.RECEIVE_MONEYs Where p.DVCD = dvcd And p.FEENO = feeno And p.IS_CANCEL Is Nothing Select p
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Function count_receipt4(ByVal dvcd As String, ByVal feeno As String, ByVal feeabbr As String) As Integer
            Dim i As Integer = 0
            datas = From p In DB.RECEIVE_MONEYs Where p.DVCD = dvcd And p.FEENO = feeno And p.IS_CANCEL Is Nothing And p.FEEABBR = feeabbr And p.RECEIPT_TYPE <> 1 Select p
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Function count_receipt5(ByVal dvcd As String, ByVal feeno As String, ByVal feeabbr As String) As Integer
            Dim i As Integer = 0
            datas = From p In DB.RECEIVE_MONEYs Where p.DVCD = dvcd And p.FEENO = feeno And p.IS_CANCEL Is Nothing And p.FEEABBR = feeabbr Select p
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Function count_receipt33(ByVal lcnsid As String, ByVal feeno As String, ByVal dvcd As Integer) As Integer
            Dim i As Integer = 0
            datas = From p In DB.RECEIVE_MONEYs Where p.LCNSID = lcnsid And p.FEENO = feeno And p.DVCD = dvcd Select p
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Function count_receipt_M44_E(ByVal dvcd As String, ByVal feeno As String, ByVal feeabbr As String) As Integer
            Dim i As Integer = 0
            datas = From p In DB.RECEIVE_MONEYs Where p.DVCD = dvcd And p.FEENO = feeno And p.IS_CANCEL Is Nothing And p.FEEABBR = feeabbr And p.RECEIPT_TYPE = 5 And p.IS_L44 = 1 Select p
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Function count_receipt_M44_E_by_REF(ByVal ref01 As String, ByVal ref02 As String) As Integer
            Dim i As Integer = 0
            datas = From p In DB.RECEIVE_MONEYs Where p.REF01 = ref01 And p.REF02 = ref02 And p.IS_CANCEL Is Nothing Select p
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Function Getdata_by_id_bgyear(ByVal rid As Integer, ByVal bgyear As Integer) As Double
            datas = From p In DB.RECEIVE_MONEYs Where p.MONEY_TYPE_ID = rid And p.BUDGET_YEAR = bgyear Select p
            Dim amount As Double = 0
            For Each Me.fields In datas
                amount = amount + Me.fields.RECEIVE_AMOUNT
            Next
            Return amount
        End Function
        Public Function Getdata_by_feeno(ByVal feeno As Integer) As Boolean
            Dim bool As Boolean = False
            Dim i As Integer = 0
            datas = From p In DB.RECEIVE_MONEYs Where p.FEENO = feeno And p.IS_CANCEL Is Nothing Select p
            For Each Me.fields In datas
                i += 1
            Next

            If i > 0 Then
                bool = True
            End If
            Return i
        End Function
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.RECEIVE_MONEYs.InsertOnSubmit(fields)
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
            DB.RECEIVE_MONEYs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง RECEIVE_MONEY_DETAIL
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_RECEIVE_MONEY_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง RECEIVE_MONEY_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New RECEIVE_MONEY_DETAIL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.RECEIVE_MONEY_DETAILs Select p).ToDataTable


        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_RECEIVE_MONEY_DETAIL_ID(ByVal ID As Integer)
            datas = From p In DB.RECEIVE_MONEY_DETAILs Where p.RECEIVE_MONEY_DETAIL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_RECEIVE_MONEY_ID(ByVal ID As Integer)
            datas = From p In DB.RECEIVE_MONEY_DETAILs Where p.RECEIVE_MONEY_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.RECEIVE_MONEY_DETAILs.InsertOnSubmit(fields)
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
            DB.RECEIVE_MONEY_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_RECEIVE_MONEY_DETAIL2

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง RECEIVE_MONEY_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New RECEIVE_MONEY_DETAIL2
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.RECEIVE_MONEY_DETAIL2s Select p).ToDataTable


        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_RECEIVE_MONEY_DETAIL_ID(ByVal IDA As Integer)
            datas = From p In DB.RECEIVE_MONEY_DETAIL2s Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_IDA(ByVal IDA As Integer)
            datas = From p In DB.RECEIVE_MONEY_DETAIL2s Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_RECEIVE_MONEY_ID(ByVal FK_IDA As Integer)
            datas = From p In DB.RECEIVE_MONEY_DETAIL2s Where p.FK_IDA = FK_IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.RECEIVE_MONEY_DETAIL2s.InsertOnSubmit(fields)
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
            DB.RECEIVE_MONEY_DETAIL2s.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_REPORT_R3_009_1

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง RECEIVE_MONEY_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New REPORT_R3_009_1
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.REPORT_R3_009_1s Select p).ToDataTable


        End Sub
   
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.REPORT_R3_009_1s Where p.ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_DATE(ByVal REPORT_DATE As Date)
            datas = From p In DB.REPORT_R3_009_1s Where p.REPORT_DATE = REPORT_DATE Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.REPORT_R3_009_1s.InsertOnSubmit(fields)
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
            DB.REPORT_R3_009_1s.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    'RETURN_MONEY_DEBTOR_DEPOSIT

    Public Class TB_RETURN_MONEY_DEBTOR_DEPOSIT

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง RECEIVE_MONEY_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New RETURN_MONEY_DEBTOR_DEPOSIT
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.RETURN_MONEY_DEBTOR_DEPOSITs Select p).ToDataTable


        End Sub

        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.RETURN_MONEY_DEBTOR_DEPOSITs Where p.RECEIVE_MONEY_DETAIL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_RETURN_MONEY_DEBTOR_ID(ByVal ID As Integer)
            datas = From p In DB.RETURN_MONEY_DEBTOR_DEPOSITs Where p.RETURN_MONEY_DEBTOR_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Function chk_repeat(ByVal dept_id As Integer) As Integer
            datas = From p In DB.RETURN_MONEY_DEBTOR_DEPOSITs Where p.RETURN_MONEY_DEBTOR_ID = dept_id Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next

            Return digit
        End Function
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.RETURN_MONEY_DEBTOR_DEPOSITs.InsertOnSubmit(fields)
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
            DB.RETURN_MONEY_DEBTOR_DEPOSITs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    Public Class TB_DEPOSIT_BALANCE

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง RECEIVE_MONEY_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New DEPOSIT_BALANCE
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
      

        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.DEPOSIT_BALANCEs Where p.DEPOSIT_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.DEPOSIT_BALANCEs.InsertOnSubmit(fields)
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
            DB.DEPOSIT_BALANCEs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_OTHER_PAY

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง RECEIVE_MONEY_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New TBL_OTHER_PAY
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>


        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.TBL_OTHER_PAYs Where p.ID_RUN = ID Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.TBL_OTHER_PAYs.InsertOnSubmit(fields)
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
            DB.TBL_OTHER_PAYs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub

    End Class
    Public Class TB_SEND_MONEY

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง RECEIVE_MONEY_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New SEND_MONEY
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>


        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In DB.SEND_MONEYs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.SEND_MONEYs.InsertOnSubmit(fields)
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
            DB.SEND_MONEYs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_SEND_MONEY_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง RECEIVE_MONEY_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New SEND_MONEY_DETAIL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>


        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In DB.SEND_MONEY_DETAILs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_FK_ID(ByVal IDA As Integer, ByVal incom As Integer, ByVal RECEIVE_MONEY_TYPE As Integer)
            datas = From p In DB.SEND_MONEY_DETAILs Where p.FK_IDA = IDA And p.INCOME_ID = incom And p.RECEIVE_MONEY_TYPE = RECEIVE_MONEY_TYPE Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.SEND_MONEY_DETAILs.InsertOnSubmit(fields)
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
            DB.SEND_MONEY_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_SEND_MONEY_SUM_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง RECEIVE_MONEY_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New SEND_MONEY_SUM_DETAIL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>


        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In DB.SEND_MONEY_SUM_DETAILs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_FK_IDA(ByVal IDA As Integer)
            datas = From p In DB.SEND_MONEY_SUM_DETAILs Where p.FK_IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.SEND_MONEY_SUM_DETAILs.InsertOnSubmit(fields)
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
            DB.SEND_MONEY_SUM_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
End Namespace