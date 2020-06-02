Namespace DAO_DISBURSE 'เบิกจ่าย
    ''' <summary>
    ''' คลาสหลักสำหรับเชื่อมต่อ LINQ_DISBURSE
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class MainContext
        ''' <summary>
        ''' ตัวแปรสำหรับเรียกใช้ CONTEXT ของ LINQ
        ''' </summary>
        ''' <remarks></remarks>
        Public DB As New LINQ_DISBURSEDataContext
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
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง BUDGET_BILL
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_BUDGET_BILL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง BUDGET_BILL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BUDGET_BILL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.BUDGET_BILLs Join bd In DB.BUDGET_BILL_DETAILs On p.BUDGET_DISBURSE_BILL_ID Equals bd.BUDGET_DISBURSE_BILL_ID Select p, bd _
                  ).ToDataTable
        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_BUDGET_DISBURSE_BILL_ID(ByVal billid As Integer)
            datas = From p In DB.BUDGET_BILLs Where p.BUDGET_DISBURSE_BILL_ID = billid Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_check_number(ByVal ch As String)
            datas = From p In DB.BUDGET_BILLs Where p.CHECK_NUMBER = ch Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Function chk_no_rebill(ByVal return_id As Integer) As Integer
            datas = From p In DB.BUDGET_BILLs Where p.RETURN_MONEY_ID = return_id Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Function chk_rebill(ByVal debt_id As Integer) As Integer
            datas = From p In DB.BUDGET_BILLs Where p.DEBTOR_ID = debt_id Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Sub Getdata_no_rebill(ByVal return_id As Integer)
            datas = From p In DB.BUDGET_BILLs Where p.RETURN_MONEY_ID = return_id Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_rebill(ByVal debt_id As Integer)
            datas = From p In DB.BUDGET_BILLs Where p.DEBTOR_ID = debt_id Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_main_bill(ByVal billid As Integer)
            datas = From p In DB.BUDGET_BILLs Where p.MAIN_BILL = billid Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_mainbill(ByVal billid As Integer)
            datas = From p In DB.BUDGET_BILLs Where p.MAIN_BILL = billid Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Function Getdata_by_doc(ByVal doc As String) As Integer
            datas = From p In DB.BUDGET_BILLs Where p.DOC_NUMBER = doc Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Function chk_multi_check(ByVal bill As String) As Integer
            datas = From p In DB.BUDGET_BILLs Where p.MAIN_BILL = bill Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Function get_bill_count(ByVal byear As Integer) As Integer
            datas = From p In DB.BUDGET_BILLs Where p.BUDGET_YEAR = byear Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Function get_customer_count(ByVal cus_id As Integer, ByVal bdate As Date, ByVal amount As Double) As Integer
            datas = From p In DB.BUDGET_BILLs Where p.BUDGET_USE_ID = 3 And p.CUSTOMER_ID = cus_id And p.BILL_DATE <= bdate _
                   And p.MAX_PRIZE = amount Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Function get_customer_count2(ByVal cus_id As Integer, ByVal bdate As Date, ByVal amount As Double, ByVal bgyear As Integer) As Integer
            datas = From p In DB.BUDGET_BILLs Where p.BUDGET_USE_ID = 3 And p.CUSTOMER_ID = cus_id And p.BILL_DATE <= bdate _
                   And p.MAX_PRIZE = amount And p.BUDGET_YEAR >= bgyear Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Function get_customer_count3(ByVal cus_id As Integer, ByVal bdate As Date, ByVal r_vol As Integer, ByVal r_num As Integer) As Integer
            datas = From p In DB.BUDGET_BILLs Where p.BUDGET_USE_ID = 3 And p.CUSTOMER_ID = cus_id And p.BILL_DATE <= bdate _
                   And CDbl(p.OUT_RECEIPT_NUMBER) = r_num And CDbl(p.OUT_RECEIPT_VOLLUME) = r_vol And p.BUDGET_PLAN_ID = 103 Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Function get_customer_count4(ByVal cus_id As Integer, ByVal bdate As Date, ByVal r_vol As Integer, ByVal r_num As Integer, ByVal m_type As Integer) As Integer
            datas = From p In DB.BUDGET_BILLs Where p.BUDGET_USE_ID = 3 And p.CUSTOMER_ID = cus_id And p.BILL_DATE <= bdate _
                   And CDbl(p.OUT_RECEIPT_NUMBER) = r_num And CDbl(p.OUT_RECEIPT_VOLLUME) = r_vol And p.BUDGET_PLAN_ID = m_type Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public c_count As Integer = 0

        Public Sub get_bill_by_MasinKey(ByVal billid As Integer)
            datas = (From p In DB.BUDGET_BILLs Where p.MAIN_KEY = billid Select p)
            For Each Me.fields In datas
                c_count += 1
            Next
        End Sub

        Public Function get_bill_count_by_dept(dept As Integer, ByVal byear As Integer) As Integer
            datas = From p In DB.BUDGET_BILLs Where p.BUDGET_YEAR = byear And p.DEPARTMENT_ID = dept Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Function get_bill_app(ByVal byear As Integer) As Integer
            datas = From p In DB.BUDGET_BILLs Where p.BUDGET_YEAR = byear And p.IS_APPROVE = True Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Function get_bill_app_by_dept(dept As Integer, ByVal byear As Integer) As Integer
            datas = From p In DB.BUDGET_BILLs Where p.BUDGET_YEAR = byear And p.DEPARTMENT_ID = dept And p.IS_APPROVE = True Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Function get_bill_No_app(ByVal byear As Integer) As Integer
            datas = From p In DB.BUDGET_BILLs Where p.BUDGET_YEAR = byear And (p.IS_APPROVE = False Or p.IS_APPROVE Is Nothing) Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        'Public Function get_bill_No_app_by_dept(dept) As Integer
        '    datas = From p In DB.BUDGET_BILLs Where p.DEPARTMENT_ID = dept And p.IS_APPROVE = False Select p
        '    Dim digit As Integer = 0
        '    For Each Me.fields In datas
        '        digit = digit + 1
        '    Next
        '    Return digit
        'End Function
        Public Function get_bill_K(ByVal byear As Integer) As Integer
            datas = From p In DB.BUDGET_BILLs Where p.BUDGET_YEAR = byear And (p.GFMIS_NUMBER <> "" Or p.GFMIS_NUMBER IsNot Nothing) Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Function get_bill_K_by_dept(dept As Integer, ByVal byear As Integer) As Integer
            datas = From p In DB.BUDGET_BILLs Where p.BUDGET_YEAR = byear And p.DEPARTMENT_ID = dept _
                    And (p.GFMIS_NUMBER <> "" Or p.GFMIS_NUMBER IsNot Nothing) _
                    Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Sub getdata_by_DISBURSE_BILL_ID_join(ByVal ID As Integer)
            dt = (From p In DB.BUDGET_BILLs Join bd In DB.BUDGET_BILL_DETAILs On p.BUDGET_DISBURSE_BILL_ID Equals bd.BUDGET_DISBURSE_BILL_ID Select p, bd _
                  Where p.BUDGET_DISBURSE_BILL_ID = ID).ToDataTable

        End Sub
        Public Sub getdata_by_DISBURSE_BILL_ID_join_margin(ByVal ID As Integer)
            datas = (From p In DB.BUDGET_BILLs Join bd In DB.BUDGET_BILL_DETAILs On p.BUDGET_DISBURSE_BILL_ID Equals bd.BUDGET_DISBURSE_BILL_ID Select p, bd _
                  Where p.BUDGET_DISBURSE_BILL_ID = ID)

        End Sub
        Public Sub getdata_Approve(ByVal budgettype As Integer)
            dt = (From p In DB.BUDGET_BILLs Join bd In DB.BUDGET_BILL_DETAILs On p.BUDGET_DISBURSE_BILL_ID Equals bd.BUDGET_DISBURSE_BILL_ID Select p, bd _
                  , p.BILL_DATE, p.BILL_NUMBER, p.Bill_RECIEVE_DATE, p.BUDGET_YEAR, _
                  p.DESCRIPTION, p.DOC_DATE, p.DOC_NUMBER, bd.AMOUNT, p.GFMIS_NUMBER _
                  Where p.IS_APPROVE = False And p.BUDGET_USE_ID = budgettype).ToDataTable

        End Sub
        Public Sub getdata_cancelApprove(ByVal budgettype As Integer)
            dt = (From p In DB.BUDGET_BILLs Join bd In DB.BUDGET_BILL_DETAILs On p.BUDGET_DISBURSE_BILL_ID Equals bd.BUDGET_DISBURSE_BILL_ID Select p, bd _
                  Where p.IS_APPROVE = True And p.BUDGET_USE_ID = budgettype).ToDataTable

        End Sub
        Public Sub getdata_KNumber()
            dt = (From p In DB.BUDGET_BILLs Join bd In DB.BUDGET_BILL_DETAILs On p.BUDGET_DISBURSE_BILL_ID Equals bd.BUDGET_DISBURSE_BILL_ID _
                  Join k In DB.MAS_GFMIs On k.BUDGET_DISBURSE_BILL_ID Equals p.BUDGET_DISBURSE_BILL_ID _
                  Select p, bd, k Where p.GFMIS_NUMBER Is Nothing).ToDataTable

        End Sub
        Public Sub getdata_RETURN_APPROVE()
            dt = (From p In DB.BUDGET_BILLs Join bd In DB.BUDGET_BILL_DETAILs On p.BUDGET_DISBURSE_BILL_ID Equals bd.BUDGET_DISBURSE_BILL_ID _
                  Join R In DB.RETURN_APPROVEs On R.BUDGET_DISBURSE_BILL_ID Equals p.BUDGET_DISBURSE_BILL_ID _
                  Select p, bd, R).ToDataTable

        End Sub
        Public Sub getdata_Reference_number()
            dt = (From p In DB.BUDGET_BILLs Join bd In DB.BUDGET_BILL_DETAILs On p.BUDGET_DISBURSE_BILL_ID Equals bd.BUDGET_DISBURSE_BILL_ID _
                  Join R In DB.MAS_REFERENCEs On R.BUDGET_DISBURSE_BILL_ID Equals p.BUDGET_DISBURSE_BILL_ID _
                  Select p, bd, R).ToDataTable

        End Sub
        Public Sub getdata_Invoice_number()
            dt = (From p In DB.BUDGET_BILLs Join bd In DB.BUDGET_BILL_DETAILs On p.BUDGET_DISBURSE_BILL_ID Equals bd.BUDGET_DISBURSE_BILL_ID _
                  Join R In DB.MAS_INVOICEs On R.BUDGET_DISBURSE_BILL_ID Equals p.BUDGET_DISBURSE_BILL_ID _
                  Select p, bd, R).ToDataTable

        End Sub
        Public Sub getdata_Tax()
            dt = (From p In DB.BUDGET_BILLs Join bd In DB.BUDGET_BILL_DETAILs On p.BUDGET_DISBURSE_BILL_ID Equals bd.BUDGET_DISBURSE_BILL_ID _
                  Join R In DB.MAS_TAXes On R.BUDGET_DISBURSE_BILL_ID Equals p.BUDGET_DISBURSE_BILL_ID _
                  Select p, bd, R).ToDataTable

        End Sub

        Public Function count_relate_id(ByVal relate_id As Integer) As Integer
            Dim i As Integer = 0
            datas = From p In DB.BUDGET_BILLs Where p.RELATE_ID = relate_id Select p
            For Each Me.fields In datas
                i += 1
            Next

            Return i
        End Function
        Public Sub Getdata_by_RELATE_ID(ByVal RELATE_ID As Integer)
            datas = From p In DB.BUDGET_BILLs Where p.RELATE_ID = RELATE_ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            'Dim key As Integer = 0
            DB.BUDGET_BILLs.InsertOnSubmit(fields)
            DB.SubmitChanges()
            'Return fields.BUDGET_DISBURSE_BILL_ID
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
            DB.BUDGET_BILLs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub

        Public Sub Getdata_BUDGET_BILL()
            datas = From p In DB.BUDGET_BILLs Where p.BUDGET_USE_ID = 1 Select p
            For Each Me.fields In datas

            Next


        End Sub
        Public Sub Getdata_by_BillId(ByVal bill_id As Integer)
            datas = From p In DB.BUDGET_BILLs Where p.BUDGET_DISBURSE_BILL_ID = bill_id Select p
            For Each Me.fields In datas

            Next

        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง BUDGET_BILL_DETAIL
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_BUDGET_BILL_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง BUDGET_BILL_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BUDGET_BILL_DETAIL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.BUDGET_BILL_DETAILs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_DETAIL_ID(ByVal ID As Integer)
            datas = From p In DB.BUDGET_BILL_DETAILs Where p.DETAIL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_fk_and_DETAIL_ID(ByVal FK_ID As Integer, ByVal ID As Integer)
            datas = From p In DB.BUDGET_BILL_DETAILs Where p.BUDGET_DISBURSE_BILL_ID = FK_ID And p.DETAIL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_Disburse_id(ByVal DID As Integer)
            datas = From p In DB.BUDGET_BILL_DETAILs Where p.BUDGET_DISBURSE_BILL_ID = DID Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_Disburse_idandPer(ByVal DID As Integer, ByVal PID As Integer)
            datas = From p In DB.BUDGET_BILL_DETAILs Where p.BUDGET_PLAN_ID = DID And p.PERIOD = PID Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_Disburse_id_gl(ByVal DID As Integer, ByVal gl As Integer)
            datas = From p In DB.BUDGET_BILL_DETAILs Where p.BUDGET_DISBURSE_BILL_ID = DID And p.GL_ID = gl Select p
            For Each Me.fields In datas

            Next

        End Sub
       
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.BUDGET_BILL_DETAILs.InsertOnSubmit(fields)
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
            DB.BUDGET_BILL_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง BUDGET_BILL_MARGIN_DETAIL
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_BUDGET_BILL_MARGIN_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง BUDGET_BILL_MARGIN_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BUDGET_BILL_MARGIN_DETAIL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.BUDGET_BILL_MARGIN_DETAILs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_DETAIL_ID(ByVal ID As Integer)
            datas = From p In DB.BUDGET_BILL_MARGIN_DETAILs Where p.DETAIL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_Disburse_id(ByVal ID As Integer)
            datas = From p In DB.BUDGET_BILL_MARGIN_DETAILs Where p.BUDGET_DISBURSE_BILL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Function count_exist(ByVal ID As Integer) As Integer
            Dim digit As Integer = 0

            datas = From p In DB.BUDGET_BILL_MARGIN_DETAILs Where p.BUDGET_DISBURSE_BILL_ID = ID Select p
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
            DB.BUDGET_BILL_MARGIN_DETAILs.InsertOnSubmit(fields)
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
            DB.BUDGET_BILL_MARGIN_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง CURE_STUDY
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_CURE_STUDY

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New CURE_STUDY
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.CURE_STUDies Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_bill_id(ByVal bill_ID As Integer)
            datas = From p In DB.CURE_STUDies Where p.BUDGET_BILL_ID = bill_ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_checknumber(ByVal ch As String)
            datas = From p In DB.CURE_STUDies Where p.CHECK_NUMBER = ch Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_CURE_STUDY_ID(ByVal ID As Integer)
            datas = From p In DB.CURE_STUDies Where p.CURE_STUDY_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.CURE_STUDies.InsertOnSubmit(fields)
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
            DB.CURE_STUDies.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง DEBTOR_BILL
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_DEBTOR_BILL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง DEBTOR_BILL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New DEBTOR_BILL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.DEBTOR_BILLs Join bd In DB.DEBTOR_BILL_DETAILs On p.DEBTOR_BILL_ID Equals bd.DEBTOR_BILL_ID Select p, bd _
                  ).ToDataTable

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_DEBTOR_BILL_ID(ByVal ID As Integer)
            datas = From p In DB.DEBTOR_BILLs Where p.DEBTOR_BILL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_RELATE_ID(ByVal DID As Integer)
            datas = From p In DB.DEBTOR_BILLs Where p.RELATE_ID = DID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Function count_relate_id(ByVal relate_id As Integer) As Integer
            Dim i As Integer = 0
            datas = From p In DB.DEBTOR_BILLs Where p.RELATE_ID = relate_id Select p
            For Each Me.fields In datas
                i += 1
            Next

            Return i
        End Function
        Public Sub Getdata_by_checknumber(ByVal ch As String)
            datas = From p In DB.DEBTOR_BILLs Where p.CHECK_NUMBER = ch Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_checknumber_join(ByVal ch As String)
            datas = From p In DB.DEBTOR_BILLs Join p2 In DB.DEBTOR_BILL_MARGIN_DETAILs On p.DEBTOR_BILL_ID Equals p2.DEBTOR_BILL_ID _
                    Where p2.CHECK_NUMBER = ch Select New With {p.DEBTOR_BILL_ID, p.USER_ID, p2.CHECK_NUMBER, p.RECEIVE_PAYLIST}

            For Each S In datas
                'Me.fields.CHECK_NUMBER = S.CHECK_NUMBER
                Me.fields.DEBTOR_BILL_ID = S.DEBTOR_BILL_ID
                Me.fields.USER_ID = S.USER_ID
                Me.fields.RECEIVE_PAYLIST = S.RECEIVE_PAYLIST
            Next

        End Sub
        Public Function get_data_by_invoice(ByVal str As String)
            datas = From p In DB.DEBTOR_BILLs Where p.INVOICES_NUMBER = str Select p
            Dim count_field As Integer = 0
            For Each Me.fields In datas
                count_field = count_field + 1
            Next

            Return count_field
        End Function

        Public Function get_bill_count(ByVal byear As Integer) As Integer
            datas = From p In DB.DEBTOR_BILLs Where p.BUDGET_YEAR = byear Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Function get_bill_count_by_dept(dept As Integer, ByVal byear As Integer) As Integer
            datas = From p In DB.DEBTOR_BILLs Where p.BUDGET_YEAR = byear And p.DEPARTMENT_ID = dept Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Function get_bill_app(ByVal byear As Integer) As Integer
            datas = From p In DB.DEBTOR_BILLs Where p.BUDGET_YEAR = byear And p.IS_APPROVE = True Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Function get_bill_app_by_dept(dept As Integer, ByVal byear As Integer) As Integer
            datas = From p In DB.DEBTOR_BILLs Where p.BUDGET_YEAR = byear And p.DEPARTMENT_ID = dept And p.IS_APPROVE = True Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Function get_bill_No_app(ByVal byear As Integer) As Integer
            datas = From p In DB.DEBTOR_BILLs Where p.BUDGET_YEAR = byear And p.IS_APPROVE = False Or p.IS_APPROVE Is Nothing Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Function get_bill_No_app_by_dept(dept As Integer, ByVal byear As Integer) As Integer
            datas = From p In DB.DEBTOR_BILLs Where p.BUDGET_YEAR = byear And (p.IS_APPROVE = False Or p.IS_APPROVE Is Nothing) And p.DEPARTMENT_ID = dept Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Function get_bill_K(ByVal byear As Integer) As Integer
            datas = From p In DB.DEBTOR_BILLs Where p.BUDGET_YEAR = byear _
                    And (p.GFMIS_NUMBER <> "" Or p.GFMIS_NUMBER IsNot Nothing) _
                    And p.DEBTOR_TYPE_ID = 2 Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Function get_bill_K_by_dept(dept As Integer, ByVal byear As Integer) As Integer
            datas = From p In DB.DEBTOR_BILLs Where p.BUDGET_YEAR = byear And (p.GFMIS_NUMBER <> "" Or p.GFMIS_NUMBER IsNot Nothing) And p.DEPARTMENT_ID = dept Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Function get_debt_deadline(ByVal byear As Integer) As Integer
            datas = From p In DB.DEBTOR_BILLs Where p.BUDGET_YEAR = byear And p.DEADLINE_DATE < System.DateTime.Now Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
       

        Public Function get_debt_deadline_by_dept(dept As Integer, ByVal byear As Integer) As Integer
            datas = From p In DB.DEBTOR_BILLs Where p.BUDGET_YEAR = byear And p.DEPARTMENT_ID = dept And p.DEADLINE_DATE < System.DateTime.Now Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Function get_debt_margin_deadline_by_dept(dept As Integer, ByVal byear As Integer) As Integer
            datas = From p In DB.DEBTOR_BILLs Join m In DB.DEBTOR_BILL_MARGIN_DETAILs On p.DEBTOR_BILL_ID Equals m.DEBTOR_BILL_ID _
                    Where p.BUDGET_YEAR = byear And p.DEPARTMENT_ID = dept And p.DEADLINE_DATE < System.DateTime.Now Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function

        Public Function Getdata_by_doc(ByVal doc As String) As Integer
            datas = From p In DB.DEBTOR_BILLs Where p.DOC_NUMBER = doc Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function

        Public Sub getdata_Approve(ByVal budgettype As Integer)
            dt = (From p In DB.DEBTOR_BILLs Join bd In DB.DEBTOR_BILL_DETAILs On p.DEBTOR_BILL_ID Equals bd.DEBTOR_BILL_ID Select p, bd _
                  Where p.IS_APPROVE = False And p.BUDGET_USE_ID = budgettype).ToDataTable

        End Sub
        Public Sub getdata_cancelApprove(ByVal budgettype As Integer)
            dt = (From p In DB.DEBTOR_BILLs Join bd In DB.DEBTOR_BILL_DETAILs On p.DEBTOR_BILL_ID Equals bd.DEBTOR_BILL_ID Select p, bd _
                  Where p.IS_APPROVE = True And p.BUDGET_USE_ID = budgettype).ToDataTable

        End Sub
        Public Sub getdata_KNumber()
            dt = (From p In DB.DEBTOR_BILLs Join bd In DB.DEBTOR_BILL_DETAILs On p.DEBTOR_BILL_ID Equals bd.DEBTOR_BILL_ID _
                  Join k In DB.MAS_GFMIs On k.BUDGET_DISBURSE_BILL_ID Equals p.DEBTOR_BILL_ID _
                  Select p, bd, k Where p.GFMIS_NUMBER Is Nothing).ToDataTable

        End Sub
        Public Sub getdata_RETURN_APPROVE()
            dt = (From p In DB.DEBTOR_BILLs Join bd In DB.DEBTOR_BILL_DETAILs On p.DEBTOR_BILL_ID Equals bd.DEBTOR_BILL_ID _
                  Join R In DB.RETURN_APPROVEs On R.BUDGET_DISBURSE_BILL_ID Equals p.DEBTOR_BILL_ID _
                  Select p, bd, R).ToDataTable

        End Sub
        Public Sub getdata_Reference_number()
            dt = (From p In DB.DEBTOR_BILLs Join bd In DB.DEBTOR_BILL_DETAILs On p.DEBTOR_BILL_ID Equals bd.DEBTOR_BILL_ID _
                  Join R In DB.MAS_REFERENCEs On R.BUDGET_DISBURSE_BILL_ID Equals p.DEBTOR_BILL_ID _
                  Select p, bd, R).ToDataTable

        End Sub
        Public Sub getdata_Invoice_number()
            dt = (From p In DB.DEBTOR_BILLs Join bd In DB.DEBTOR_BILL_DETAILs On p.DEBTOR_BILL_ID Equals bd.DEBTOR_BILL_ID _
                  Join R In DB.MAS_INVOICEs On R.BUDGET_DISBURSE_BILL_ID Equals p.DEBTOR_BILL_ID _
                  Select p, bd, R).ToDataTable

        End Sub
        Public Sub getdata_Tax()
            dt = (From p In DB.DEBTOR_BILLs Join bd In DB.DEBTOR_BILL_DETAILs On p.DEBTOR_BILL_ID Equals bd.DEBTOR_BILL_ID _
                  Join R In DB.MAS_TAXes On R.BUDGET_DISBURSE_BILL_ID Equals p.DEBTOR_BILL_ID _
                  Select p, bd, R).ToDataTable

        End Sub

       
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.DEBTOR_BILLs.InsertOnSubmit(fields)
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
            DB.DEBTOR_BILLs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง DEBTOR_BILL_DETAIL
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_DEBTOR_BILL_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง DEBTOR_BILL_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New DEBTOR_BILL_DETAIL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.DEBTOR_BILL_DETAILs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_DEBTOR_BILL_DETAIL_ID(ByVal ID As Integer)
            datas = From p In DB.DEBTOR_BILL_DETAILs Where p.DEBTOR_BILL_DETAIL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_DEBTOR_BILL_ID(ByVal ID As Integer)
            datas = From p In DB.DEBTOR_BILL_DETAILs Where p.DEBTOR_BILL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.DEBTOR_BILL_DETAILs.InsertOnSubmit(fields)
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
            DB.DEBTOR_BILL_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง DEBTOR_PAY_MARGIN
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_DEBTOR_PAY_MARGIN

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง DEBTOR_PAY_MARGIN
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New DEBTOR_PAY_MARGIN
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.DEBTOR_PAY_MARGINs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_DEBTOR_PAY_MARGIN_ID(ByVal ID As Integer)
            datas = From p In DB.DEBTOR_PAY_MARGINs Where p.DEBTOR_PAY_MARGIN_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.DEBTOR_PAY_MARGINs.InsertOnSubmit(fields)
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
            DB.DEBTOR_PAY_MARGINs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_DEBTOR_BILL_MARGIN_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง DEBTOR_PAY_MARGIN
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New DEBTOR_BILL_MARGIN_DETAIL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.DEBTOR_BILL_MARGIN_DETAILs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.DEBTOR_BILL_MARGIN_DETAILs Where p.DETAIL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_DEBTOR_BILL_ID(ByVal ID As Integer)
            datas = From p In DB.DEBTOR_BILL_MARGIN_DETAILs Where p.DEBTOR_BILL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Function get_debt_margin_deadline() As Integer
            datas = From p In DB.DEBTOR_BILL_MARGIN_DETAILs Where p.DEADLINE_DATE < System.DateTime.Now Select p
            Dim digit As Integer = 0
            For Each Me.fields In datas
                digit = digit + 1
            Next
            Return digit
        End Function
        Public Sub Getdata_by_checknumber_join(ByVal ch As String)
            datas = From p In DB.DEBTOR_BILL_MARGIN_DETAILs Where p.CHECK_NUMBER = ch Select p
            For Each Me.fields In datas

            Next
            'datas = From p In DB.DEBTOR_BILLs Join p2 In DB.DEBTOR_BILL_MARGIN_DETAILs On p.DEBTOR_BILL_ID Equals p2.DEBTOR_BILL_ID _
            '       Where p2.CHECK_NUMBER = ch Select New With {p2.DEBTOR_BILL_ID, p.USER_ID, p2.CHECK_NUMBER, p.RECEIVE_PAYLIST}

            'For Each S In datas
            '    Me.fields.DEBTOR_BILL_ID = S.DEBTOR_BILL_ID
            '    Me.fields.CHECK_NUMBER = S.CHECK_NUMBER
            'Next
        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.DEBTOR_BILL_MARGIN_DETAILs.InsertOnSubmit(fields)
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
            DB.DEBTOR_BILL_MARGIN_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_GFMIS
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_GFMIS

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_GFMIS
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_GFMI
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.MAS_GFMIs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_GFMIS_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_GFMIs Where p.GFMIS_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_BILL_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_GFMIs Where p.BUDGET_DISBURSE_BILL_ID = ID Select p
            ID = 0
            For Each Me.fields In datas
                ID = Me.fields.BUDGET_DISBURSE_BILL_ID
            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_GFMIs.InsertOnSubmit(fields)
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
            DB.MAS_GFMIs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_INVOICES
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_INVOICES

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_INVOICES
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_INVOICE
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.MAS_INVOICEs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_INVOICES_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_INVOICEs Where p.INVOICES_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_bill_id(ByVal ID As Integer)
            datas = From p In DB.MAS_INVOICEs Where p.BUDGET_DISBURSE_BILL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_INVOICEs.InsertOnSubmit(fields)
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
            DB.MAS_INVOICEs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_MARGIN
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_MARGIN

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_MARGIN
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_MARGIN
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.MAS_MARGINs Select p).ToDataTable
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_MARGIN_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_MARGINs Where p.MARGIN_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_year(ByVal year_num As Integer)
            datas = From p In DB.MAS_MARGINs Where p.MARGIN_BUDGET_YEAR = year_num Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_MARGINs.InsertOnSubmit(fields)
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
            DB.MAS_MARGINs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_RECEIPT
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_RECEIPT

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_RECEIPT
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_RECEIPT
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.MAS_RECEIPTs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_RECEIPT_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_RECEIPTs Where p.RECEIPT_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_RECEIPTs.InsertOnSubmit(fields)
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
            DB.MAS_RECEIPTs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_REFERENCE
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_REFERENCE

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_REFERENCE
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_REFERENCE
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.MAS_REFERENCEs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_REFERENCE_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_REFERENCEs Where p.REFERENCE_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_REFERENCE_Bill_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_REFERENCEs Where p.BUDGET_DISBURSE_BILL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_REFERENCEs.InsertOnSubmit(fields)
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
            DB.MAS_REFERENCEs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง MAS_TAX
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_MAS_TAX

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_TAX
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_TAX
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.MAS_TAXes Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_TAXes Where p.ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_bill_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_TAXes Where p.BUDGET_DISBURSE_BILL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_TAXes.InsertOnSubmit(fields)
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
            DB.MAS_TAXes.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง PAY_CHECK_DETAIL
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_PAY_CHECK_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง PAY_CHECK_DETAIL
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New PAY_CHECK_DETAIL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.PAY_CHECK_DETAILs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_PAY_CHECK_DETAIL_ID(ByVal ID As Integer)
            datas = From p In DB.PAY_CHECK_DETAILs Where p.PAY_CHECK_DETAIL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.PAY_CHECK_DETAILs.InsertOnSubmit(fields)
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
            DB.PAY_CHECK_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง PAY_DIRECT
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_PAY_DIRECT

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง PAY_DIRECT
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New PAY_DIRECT
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.PAY_DIRECTs Select p).ToDataTable
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_PAY_DIRECT_ID(ByVal ID As Integer)
            datas = From p In DB.PAY_DIRECTs Where p.DISBURSE_PAY_DIRECT_ID = ID Select p

            ID = 0
            For Each Me.fields In datas
                ID = Me.fields.BUDGET_DISBURSE_BILL_ID
            Next

        End Sub
        Public Sub Getdata_by_bill_id(ByVal ID As Integer)
            datas = From p In DB.PAY_DIRECTs Where p.BUDGET_DISBURSE_BILL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.PAY_DIRECTs.InsertOnSubmit(fields)
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
            DB.PAY_DIRECTs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง PAY_MARGIN
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_PAY_MARGIN

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง PAY_MARGIN
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New PAY_MARGIN
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.PAY_MARGINs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_PAY_MARGIN_ID(ByVal ID As Integer)
            datas = From p In DB.PAY_MARGINs Where p.PAY_MARGIN_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.PAY_MARGINs.InsertOnSubmit(fields)
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
            DB.PAY_MARGINs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง PAY_PASS
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_PAY_PASS

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง PAY_PASS
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New PAY_PASS
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.PAY_PASSes Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_PAY_PASS_ID(ByVal ID As Integer)
            datas = From p In DB.PAY_PASSes Where p.DISBURSE_PAY_PASS_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_bill_id(ByVal ID As Integer)
            datas = From p In DB.PAY_PASSes Where p.BUDGET_DISBURSE_BILL_ID = ID Select p

            ID = 0
            For Each Me.fields In datas
                ID = Me.fields.BUDGET_DISBURSE_BILL_ID
            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.PAY_PASSes.InsertOnSubmit(fields)
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
            DB.PAY_PASSes.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง STATUS
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_STATUS

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง STATUS
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New STATUS
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.STATUS Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_STATUS_ID(ByVal ID As Integer)
            datas = From p In DB.STATUS Where p.STATUS_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.STATUS.InsertOnSubmit(fields)
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
            DB.STATUS.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง STATUS_FLOW
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_STATUS_FLOW

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง STATUS_FLOW
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New STATUS_FLOW
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.STATUS_FLOWs Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_DISBURSE_STATUS_FLOW_ID(ByVal ID As Integer)
            datas = From p In DB.STATUS_FLOWs Where p.DISBURSE_STATUS_FLOW_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.STATUS_FLOWs.InsertOnSubmit(fields)
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
            DB.STATUS_FLOWs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class


    ''' <summary>
    ''' บันทึก แก้ไข ลบ ข้อมูลตาราง RETURN_APPROVE
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_RETURN_APPROVE

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง STATUS_FLOW
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New RETURN_APPROVE
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.RETURN_APPROVEs Select p)
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.RETURN_APPROVEs Where p.RETURN_APPROVE_GF_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_BUDGET_DISBURSE_BILL_ID(ByVal ID As Integer)
            dt = (From p In DB.RETURN_APPROVEs Where p.BUDGET_DISBURSE_BILL_ID = ID Select p).ToDataTable
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.RETURN_APPROVEs.InsertOnSubmit(fields)
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
            DB.RETURN_APPROVEs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    Public Class TB_BUDGET_PO_BILL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง STATUS_FLOW
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BUDGET_PO_BILL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.BUDGET_PO_BILLs Select p)
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.BUDGET_PO_BILLs Where p.PO_BILL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.BUDGET_PO_BILLs.InsertOnSubmit(fields)
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
            DB.BUDGET_PO_BILLs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    Public Class TB_BUDGET_PO_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง STATUS_FLOW
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New PO_DETAIL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.PO_DETAILs Select p)
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.PO_DETAILs Where p.PO_DETAIL_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub
      
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.PO_DETAILs.InsertOnSubmit(fields)
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
            DB.PO_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_MARGIN_PAY_WITHDRAW

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง STATUS_FLOW
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MARGIN_PAY_WITHDRAW
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.MARGIN_PAY_WITHDRAWs Select p)
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.MARGIN_PAY_WITHDRAWs Where p.PAY_ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MARGIN_PAY_WITHDRAWs.InsertOnSubmit(fields)
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
            DB.MARGIN_PAY_WITHDRAWs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    Public Class TB_MAS_PO_IMPORT

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง STATUS_FLOW
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_PO_IMPORT
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.MAS_PO_IMPORTs Select p)
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.MAS_PO_IMPORTs Where p.ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.MAS_PO_IMPORTs.InsertOnSubmit(fields)
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
            DB.MAS_PO_IMPORTs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    Public Class TB_BUDGET_MASTER_BILL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง STATUS_FLOW
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BUDGET_MASTER_BILL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.BUDGET_MASTER_BILLs Select p)
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal ID As Integer)
            datas = From p In DB.BUDGET_MASTER_BILLs Where p.ID = ID Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.BUDGET_MASTER_BILLs.InsertOnSubmit(fields)
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
            DB.BUDGET_MASTER_BILLs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    Public Class TB_BUDGET_PO_NUMBER

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง STATUS_FLOW
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BUDGET_PO_NUMBER
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.BUDGET_PO_NUMBERs Select p)
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal BID As Integer)
            datas = From p In DB.BUDGET_PO_NUMBERs Where p.PO_NUMBER_ID = BID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_number_by_dis_id(ByVal BID As Integer)
            datas = From p In DB.BUDGET_PO_NUMBERs Where p.BUDGET_DISBURSE_BILL_ID = BID And p.IS_USE = True Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.BUDGET_PO_NUMBERs.InsertOnSubmit(fields)
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
            DB.BUDGET_PO_NUMBERs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_RELATE_BG_ALL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง STATUS_FLOW
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New RELATE_BG_ALL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.RELATE_BG_ALLs Select p)
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal BID As Integer)
            datas = From p In DB.RELATE_BG_ALLs Where p.RELATE_ID = BID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_Receive_number(ByVal num As String)
            datas = From p In DB.RELATE_BG_ALLs Where p.RECEIVE_FULL_NUMBER = num Select p
            For Each Me.fields In datas

            Next

        End Sub
        'Public Function count_repeat(ByVal cerid As Integer, ByVal gl_id As Integer) As Integer
        '    Dim i As Integer = 0
        '    datas = From p In DB.CERTIFICATE_DETAILs Where p.FK_CER_ID = cerid And p.GL_ID = gl_id Select p
        '    For Each Me.fields In datas
        '        i += 1
        '    Next
        '    Return i
        'End Function
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.RELATE_BG_ALLs.InsertOnSubmit(fields)
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
            DB.RELATE_BG_ALLs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_RELATE_BG_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง STATUS_FLOW
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New RELATE_BG_DETAIL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.RELATE_BG_DETAILs Select p)
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal BID As Integer)
            datas = From p In DB.RELATE_BG_DETAILs Where p.RELATE_DETAIL_ID = BID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_Relate_id(ByVal BID As Integer)
            datas = From p In DB.RELATE_BG_DETAILs Where p.RELATE_ID = BID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_Relate_id_gl(ByVal BID As Integer, ByVal gl As Integer)
            datas = From p In DB.RELATE_BG_DETAILs Where p.RELATE_ID = BID And p.GL_ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.RELATE_BG_DETAILs.InsertOnSubmit(fields)
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
            DB.RELATE_BG_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_RELATE_DETAIL_PO

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง STATUS_FLOW
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New RELATE_DETAIL_PO
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.RELATE_DETAIL_POs Select p)
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal BID As Integer)
            datas = From p In DB.RELATE_DETAIL_POs Where p.IDA = BID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Function count_po(ByVal BID As Integer) As Integer
            Dim i As Integer = 0
            datas = From p In DB.RELATE_DETAIL_POs Where p.RELATE_ID = BID Select p
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Sub Getdata_by_Relate_id(ByVal BID As Integer)
            datas = From p In DB.RELATE_DETAIL_POs Where p.RELATE_ID = BID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_Relate_id_and_period(ByVal BID As Integer, ByVal period As Integer)
            datas = From p In DB.RELATE_DETAIL_POs Where p.RELATE_ID = BID And p.PERIOD_ID = period Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_Relate_id_gl(ByVal BID As Integer, ByVal gl As Integer)
            datas = From p In DB.RELATE_DETAIL_POs Where p.RELATE_ID = BID And p.GL_ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.RELATE_DETAIL_POs.InsertOnSubmit(fields)
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
            DB.RELATE_DETAIL_POs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    Public Class TB_BILL_CHECKER

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง STATUS_FLOW
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BILL_CHECKER
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            dt = (From p In DB.BILL_CHECKERs Select p)
            'For Each Me.fields In datas

            'Next

        End Sub
        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal BID As Integer)
            datas = From p In DB.BILL_CHECKERs Where p.IDA = BID Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_ID_type(ByVal BID As Integer, ByVal _type As Integer)
            datas = From p In DB.BILL_CHECKERs Where p.IDA = BID And p.REJECT_TYPE = _type Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Function count_repeat(ByVal billid As Integer) As Integer
            Dim i As Integer = 0
            datas = From p In DB.BILL_CHECKERs Where p.BUDGET_DISBURSE_BILL_ID = billid Select p
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
            DB.BILL_CHECKERs.InsertOnSubmit(fields)
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
            DB.BILL_CHECKERs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_STUDY_CHILD_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New STUDY_CHILD_DETAIL
        ''' <summary>
        ''' แสดงข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata()
            datas = From p In DB.STUDY_CHILD_DETAILs Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_ida(ByVal IDA As Integer)
            datas = From p In DB.STUDY_CHILD_DETAILs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_fk_ida(ByVal IDA As Integer)
            datas = From p In DB.STUDY_CHILD_DETAILs Where p.FK_IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.STUDY_CHILD_DETAILs.InsertOnSubmit(fields)
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
            DB.STUDY_CHILD_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_CURE_CONDITION

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New CURE_CONDITION
        
        Public Sub Getdata_by_ida(ByVal IDA As Integer)
            datas = From p In DB.CURE_CONDITIONs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_fk_ida(ByVal IDA As Integer)
            datas = From p In DB.CURE_CONDITIONs Where p.FK_IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.CURE_CONDITIONs.InsertOnSubmit(fields)
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
            DB.CURE_CONDITIONs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    Public Class TB_TEMP_INSERT

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New TEMP_INSERT

        Public Sub Getdata_by_ida(ByVal IDA As Integer)
            datas = From p In DB.TEMP_INSERTs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
      
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.TEMP_INSERTs.InsertOnSubmit(fields)
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
            DB.TEMP_INSERTs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_Deeka_Withdraw

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New TBL_Deeka_Withdraw

        Public Sub Getdata_by_ida(ByVal IDA As Integer)
            datas = From p In DB.TBL_Deeka_Withdraws Where p.ID = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.TBL_Deeka_Withdraws.InsertOnSubmit(fields)
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
            DB.TBL_Deeka_Withdraws.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_BUDGET_WITHDRAW

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BUDGET_WITHDRAW
        Public Sub Getdata_by_Fk_id(ByVal IDA As Integer)
            datas = From p In DB.BUDGET_WITHDRAWs Where p.FK_ID = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_ida(ByVal IDA As Integer)
            datas = From p In DB.BUDGET_WITHDRAWs Where p.ID = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.BUDGET_WITHDRAWs.InsertOnSubmit(fields)
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
            DB.BUDGET_WITHDRAWs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_BUDGET_WITHDRAW_DEKA

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BUDGET_WITHDRAW_DEKA

        Public Sub Getdata_by_ida(ByVal IDA As Integer)
            datas = From p In DB.BUDGET_WITHDRAW_DEKAs Where p.ID = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.BUDGET_WITHDRAW_DEKAs.InsertOnSubmit(fields)
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
            DB.BUDGET_WITHDRAW_DEKAs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_BUDGET_WITHDRAW_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BUDGET_WITHDRAW_DETAIL

        Public Sub Getdata_by_FK_DETAIL_ID(ByVal FK_DETAIL_ID As Integer)
            datas = From p In DB.BUDGET_WITHDRAW_DETAILs Where p.FK_DETAIL_ID = FK_DETAIL_ID Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Function count_by_id(ByVal d_id As Integer) As Integer
            datas = From p In DB.BUDGET_WITHDRAW_DETAILs Where p.FK_DETAIL_ID = d_id Select p
            Dim i As Integer = 0
            For Each Me.fields In datas
                i += 1
            Next

            Return i
        End Function

        Public Sub Getdata_by_FK_WITH_ID(ByVal FK_WITH_ID As Integer)
            datas = From p In DB.BUDGET_WITHDRAW_DETAILs Where p.FK_WITH_ID = FK_WITH_ID Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_ida(ByVal IDA As Integer)
            datas = From p In DB.BUDGET_WITHDRAW_DETAILs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.BUDGET_WITHDRAW_DETAILs.InsertOnSubmit(fields)
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
            DB.BUDGET_WITHDRAW_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_BUDGET_WITHDRAW_DEKA_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BUDGET_WITHDRAW_DEKA_DETAIL

        Public Sub Getdata_by_ida(ByVal IDA As Integer)
            datas = From p In DB.BUDGET_WITHDRAW_DEKA_DETAILs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_fk_deka(ByVal fk_deka As Integer)
            datas = From p In DB.BUDGET_WITHDRAW_DEKA_DETAILs Where p.FK_DEKA = fk_deka Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_fk_deka_billId(ByVal fk_deka As Integer, ByVal fk_bill As Integer)
            datas = From p In DB.BUDGET_WITHDRAW_DEKA_DETAILs Where p.FK_DEKA = fk_deka And p.FK_BILL_ID = fk_bill Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.BUDGET_WITHDRAW_DEKA_DETAILs.InsertOnSubmit(fields)
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
            DB.BUDGET_WITHDRAW_DEKA_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_BUDGET_WITHDRAW_DEKA_BUDGET_GROUP

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BUDGET_WITHDRAW_DEKA_BUDGET_GROUP

        Public Sub Getdata_by_ida(ByVal IDA As Integer)
            datas = From p In DB.BUDGET_WITHDRAW_DEKA_BUDGET_GROUPs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_fkida(ByVal IDA As Integer)
            datas = From p In DB.BUDGET_WITHDRAW_DEKA_BUDGET_GROUPs Where p.FK_DEKA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_FK_DEKA_BUDGET(ByVal FK_Deka As Integer, ByVal FK_Budget As Integer)
            datas = From p In DB.BUDGET_WITHDRAW_DEKA_BUDGET_GROUPs Where p.FK_DEKA = FK_Deka And p.BUDGET_ID = FK_Budget Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_FK_DEKA_Id(ByVal FK_Deka As Integer, ByVal ID As Integer)
            datas = From p In DB.BUDGET_WITHDRAW_DEKA_BUDGET_GROUPs Where p.FK_DEKA = FK_Deka And p.IDA = ID Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_FK_DEKA(ByVal FK As Integer)
            datas = From p In DB.BUDGET_WITHDRAW_DEKA_BUDGET_GROUPs Where p.FK_DEKA = FK Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.BUDGET_WITHDRAW_DEKA_BUDGET_GROUPs.InsertOnSubmit(fields)
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
            DB.BUDGET_WITHDRAW_DEKA_BUDGET_GROUPs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_BUDGET_WITHDRAW_DEKA_BUDGET_GROUP_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New BUDGET_WITHDRAW_DEKA_BUDGET_GROUP_DETAIL

        Public Sub Getdata_by_ida(ByVal IDA As Integer)
            datas = From p In DB.BUDGET_WITHDRAW_DEKA_BUDGET_GROUP_DETAILs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_FK_DEKA(ByVal FK As Integer)
            datas = From p In DB.BUDGET_WITHDRAW_DEKA_BUDGET_GROUP_DETAILs Where p.FK_DEKA = FK Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_FK_BUDGET(ByVal FK_BUDGET As Integer)
            datas = From p In DB.BUDGET_WITHDRAW_DEKA_BUDGET_GROUP_DETAILs Where p.FK_BUDGET_GRUOP = FK_BUDGET Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.BUDGET_WITHDRAW_DEKA_BUDGET_GROUP_DETAILs.InsertOnSubmit(fields)
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
            DB.BUDGET_WITHDRAW_DEKA_BUDGET_GROUP_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
End Namespace