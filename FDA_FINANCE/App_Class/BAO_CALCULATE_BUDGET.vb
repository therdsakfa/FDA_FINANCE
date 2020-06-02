Imports System.Data.SqlClient
Namespace BAO_CALCULATE_BUDGET
    Public Class ConnectDatabase
        Public Function Queryds(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DTAMConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Function Queryds_Report(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DTAMConnectionStringReport").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
    End Class
    ''' <summary>
    ''' Class คำนวน BUDGET แบบเชื่อมต่อกับ SQL
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CALCULATE_BUDGET_SQL
        '-----จัดสรรงบประมาณ----------
        Private budgetMain As Double = 0 'จำนวนเงินงบประมาณหลัก
        Public Property _budgetMain() As Double
            Get
                Return budgetMain
            End Get
            Set(ByVal value As Double)
                budgetMain = value
            End Set
        End Property
        Private budgetMainUse As Double = 0 'จำนวนเงินงบประมาณหลักใช้ไป
        Public Property _budgetMainUse() As Double
            Get
                Return budgetMainUse
            End Get
            Set(ByVal value As Double)
                budgetMainUse = value
            End Set
        End Property
        ''' <summary>
        ''' คำนวน ยอดเงินงบประมาณ
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CalBudgetMain() As Double
            Return budgetMain
        End Function
        ''' <summary>
        ''' คำนวน เงินงบประมาณใช้ไป
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CalMainBudgeMaintUse() As Double
            Return budgetMainUse
        End Function
        '-----เงินทดรอง----------
        Private marginBank As Double = 0 'เงินในธนาคารที่มี
        Public Property _marginBank() As Double
            Get
                Return marginBank
            End Get
            Set(ByVal value As Double)
                marginBank = value
            End Set
        End Property
        Private marginBankNonReturn As Double = 0 'เงินในธนาคารที่ยังไม่คืน
        Public Property _marginBankNonReturn() As Double
            Get
                Return marginBankNonReturn
            End Get
            Set(ByVal value As Double)
                marginBankNonReturn = value
            End Set
        End Property
        Private marginBankReturn As Double = 0 'เงินในธนาคารที่คืนแล้ว
        Public Property _marginBankReturn() As Double
            Get
                Return marginBankReturn
            End Get
            Set(ByVal value As Double)
                marginBankReturn = value
            End Set
        End Property
        ''' <summary>
        ''' คำนวน เงินในธนาคารที่มี
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CalMarginBank() As Double
            Return marginBank
        End Function
        ''' <summary>
        ''' คำนวน เงินในธนาคารที่ยังไม่คืน
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CalMarginBankNonReturn() As Double
            Return marginBankNonReturn
        End Function
        ''' <summary>
        ''' คำนวน เงินในธนาคารที่คืนแล้ว
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CalMarginBankReturn() As Double
            Return marginBankReturn
        End Function
        Private marginCash As Double = 0 'เงินสดที่มี
        Public Property _marginBankCash() As Double
            Get
                Return marginCash
            End Get
            Set(ByVal value As Double)
                marginCash = value
            End Set
        End Property
        Private marginCashNonReturn As Double = 0 'เงินสดที่ยังไม่คืน
        Public Property _marginCashNonReturn() As Double
            Get
                Return marginCashNonReturn
            End Get
            Set(ByVal value As Double)
                marginCashNonReturn = value
            End Set
        End Property
        Private marginCashReturn As Double = 0 'เงินสดที่คืนแล้ว
        Public Property _marginCashReturn() As Double
            Get
                Return marginCashReturn
            End Get
            Set(ByVal value As Double)
                marginCashReturn = value
            End Set
        End Property
        ''' <summary>
        ''' คำนวน เงินสดที่มี
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CalMarginCash() As Double
            Return marginBank
        End Function
        ''' <summary>
        ''' คำนวน เงินสดที่ยังไม่คืน
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CalMarginCashNonReturn() As Double
            Return marginBankNonReturn
        End Function
        ''' <summary>
        ''' คำนวน เงินสดที่คืนแล้ว
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CalMarginCashReturn() As Double
            Return marginBankReturn
        End Function
        '-----เบิกจ่าย ลูกหนี้----------
        Private budget As Double = 0 'จำนวนเงินงบประมาณ
        Public Property _budget() As Double
            Get
                Return budget
            End Get
            Set(ByVal value As Double)
                budget = value
            End Set
        End Property
        Private budgetUse As Double = 0 'จำนวนเงินงบประมาณใช้ไป
        Public Property _budgetUse() As Double
            Get
                Return budgetUse
            End Get
            Set(ByVal value As Double)
                budgetUse = value
            End Set
        End Property
        Private budgetApprove As Double = 0 'ยอดเงินอนุมัติแล้ว
        Public Property _budgetApprove() As Double
            Get
                Return budgetApprove
            End Get
            Set(ByVal value As Double)
                budgetApprove = value
            End Set
        End Property
        Private budgetNotApprove As Double = 0 'ยอดเงินที่ยังไม่อนุมัติ
        Public Property _budgetNotApprove() As Double
            Get
                Return budgetNotApprove
            End Get
            Set(ByVal value As Double)
                budgetNotApprove = value
            End Set
        End Property
        ''' <summary>
        ''' คำนวน ยอดเงินงบประมาณ
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CalBudget() As Double
            Return budget
        End Function
        ''' <summary>
        ''' คำนวน เงินงบประมาณใช้ไป
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CalBudgetUse() As Double
            Return budgetUse
        End Function
        ''' <summary>
        ''' คำนวน ยอดเงินอนุมัติแล้ว
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CalBudgetApprove() As Double
            Return budgetApprove
        End Function
        ''' <summary>
        ''' คำนวน ยอดเงินที่ยังไม่อนุมัติ
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CalBudgetNotApprove() As Double
            Return budgetNotApprove
        End Function
        '-----เบิกจ่าย งบประมาณ
        Private budgetInsressDescress As Double 'งบประมาณ เพิ่ม/ลด
        Public Property _budgetIncressDescress() As Double
            Get
                Return budgetInsressDescress
            End Get
            Set(ByVal value As Double)
                budgetInsressDescress = value
            End Set
        End Property
        Private budgetTransfer As Double 'งบประมาณ โอนเบิกแทน
        Public Property _budgetTransfer() As Double
            Get
                Return budgetTransfer
            End Get
            Set(ByVal value As Double)
                budgetTransfer = value
            End Set
        End Property
        'CalBudget() 'ใช้ตัวเดียวกับลูกหนี้
        ' ''' <summary>
        ' ''' คำนวน งบประมาณ เพิ่ม/ลด
        ' ''' </summary>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Function CalBudgetIncressDecress() As Double
        '    Return budgetInsressDescress
        'End Function
        ' ''' <summary>
        ' ''' คำนวน งบประมาณ โอนเบิกแทน
        ' ''' </summary>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Function CalBudgetTransfer() As Double
        '    Return budgetTransfer
        'End Function
        'CalBudgetApprove()
    End Class
    ''' <summary>
    ''' Class คำนวน BUDGET แบบไม่เชื่อมต่อกับ SQL
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CALCULATE_BUDGET_NONSQL
        Inherits CALCULATE_BUDGET_SQL
        '-----จัดสรร งบประมาณ----------
        ''' <summary>
        ''' คำนวน ยอดเงินคงเหลือ
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CalBudgetTotal(budget As Double, budgetUse As Double) As Double
            Dim amount As Double = budget - budgetUse
            Return amount
        End Function
        '-----เบิกจ่าย เงินทดรอง----------
        ''' <summary>
        ''' คำนวน เงินในธนาคารคงเหลือที่ยังไม่คืน (ตามทวง)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CalMarginBankNonReturnResult(marginBankNonReturn As Double, marginBankNonReturnResult As Double) As Double
            Dim amount As Double = marginBankNonReturn - marginBankNonReturnResult
            Return amount
        End Function
        ''' <summary>
        ''' คำนวน เงินในธนาคารที่เอาไปใช้ได้
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CalMarginBankResult(marginBank As Double, marginBankNonReturnResult As Double) As Double
            Dim amount As Double = marginBank - marginBankNonReturnResult
            Return amount
        End Function
        ''' <summary>
        ''' คำนวน เงินสดคงเหลือที่ยังไม่คืน (ตามทวง)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CalMarginCashNonReturnResult(marginCashNonReturn As Double, marginCashNonReturnResult As Double) As Double
            Dim amount As Double = marginCashNonReturn - marginCashNonReturnResult
            Return amount
        End Function
        ''' <summary>
        ''' คำนวน เงินสดที่เอาไปใช้ได้
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CalMarginCashResult(marginCash As Double, marginCashNonReturnResult As Double) As Double
            Dim amount As Double = marginCash - marginCashNonReturnResult
            Return amount
        End Function
        '-----เบิกจ่าย ลูกหนี้
        ''' <summary>
        ''' คำนวน ยอดเงินคงเหลือที่ใช้ได้(อนุมัติ)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CalBudgetApproveResult(calBudget As Double, budgetApprove As Double) As Double
            Dim amount As Double = calBudget - budgetApprove
            Return amount
        End Function
        ''' <summary>
        ''' คำนวน ยอดเงินคงเหลือที่ใช้ได้(ยังไม่อนุมัติ)
        ''' </summary>
        ''' <param name="calBudget"></param>
        ''' <param name="budgetNotApprove"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CalBudgetNotApproveResult(calBudget As Double, budgetNotApprove As Double) As Double
            Dim amount As Double = calBudget - budgetNotApprove
            Return amount
        End Function
        '-----เบิกจ่าย งบประมาณ
        'CalBudgetResult() 'เงินงบประมาณ, เพิ่มลด, โอนเบิกแทน
        'CalBudgetApproveResult()
        'CalBudgetNotApprove()
        'CalBudgetNotApproveResult()
    End Class
    ''' <summary>
    ''' Class คำนวน ระบบนำฝากเงิน แบบเชื่อมต่อกับ SQL
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CALCULATE_MAINTAIN_SQL
        Inherits ConnectDatabase
        ''' <summary>
        ''' Function คำนวนจำนวนเงินที่รับทั้ังหมด แยกตามปีงบประมาณ
        ''' </summary>
        ''' <param name="bgYear">ปีงบประมาณ</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function cal_RECEIVE_AMOUNT_by_BUDGET_YEAR(ByVal bgYear As Integer) As Double
            Dim dt As New DataTable
            Dim amount As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[cal_RECEIVE_AMOUNT_by_BUDGET_YEAR] @BudgetYear = " & bgYear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("RECEIVE_AMOUNT")) = False Then
                    amount = dt(0)("RECEIVE_AMOUNT")
                End If
            End If
            Return amount
        End Function
        ''' <summary>
        ''' Function คำนวนจำนวนเงินที่รับ แยกตามปีงบประมาณ และประเภทเงิน
        ''' </summary>
        ''' <param name="bgYear">ปีงบประมาณ</param>
        ''' <param name="moneyType">ประเภทเงิน 1 = เงินสด, 2 = เช็ค, 3 = โอน, 4 = ยกเลิก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function cal_RECEIVE_AMOUNT_by_BUDGET_YEAR_and_RECEIVE_MONEY_TYPE(ByVal bgYear As Integer, ByVal moneyType As Integer) As Double
            Dim dt As New DataTable
            Dim amount As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[cal_RECEIVE_AMOUNT_by_BUDGET_YEAR_and_RECEIVE_MONEY_TYPE] @BudgetYear = " & bgYear & ", @ReceiveMoneyType = " & moneyType
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("RECEIVE_AMOUNT")) = False Then
                    amount = dt(0)("RECEIVE_AMOUNT")
                End If
            End If
            Return amount
        End Function
        ''' <summary>
        ''' Function คำนวนจำนวนเงินที่ฝาก แยกตามปีงบประมาณ และประเภทเงิน
        ''' </summary>
        ''' <param name="bgYear">ปีงบประมาณ</param>
        ''' <param name="moneyType">ประเภทเงิน 1 = เงินสด, 2 = เช็ค</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function cal_DEPOSIT_AMOUNT_by_BUDGET_YEAR_and_RECEIVE_MONEY_TYPE(ByVal bgYear As Integer, ByVal moneyType As Integer) As Double
            Dim dt As New DataTable
            Dim amount As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[cal_DEPOSIT_AMOUNT_by_BUDGET_YEAR_and_RECEIVE_MONEY_TYPE] @BudgetYear = " & bgYear & ", @ReceiveMoneyType = " & moneyType
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("RECEIVE_AMOUNT")) = False Then
                    amount = dt(0)("RECEIVE_AMOUNT")
                End If
            End If
            Return amount
        End Function
    End Class
    ''' <summary>
    ''' Class คำนวน ระบบนำฝากเงิน แบบไม่เชื่อมต่อกับ SQL
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CALCULATE_MAINTAIN_NonSQL
        Inherits CALCULATE_MAINTAIN_SQL

    End Class
End Namespace