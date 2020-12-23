Imports System.Data.SqlClient

Namespace BAO_BUDGET
    Public Class ConnectDatabass
        Public Function Queryds(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DTAMConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
    End Class
    Public Class ConnectDatabass_CPN
        Public Function Queryds(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("LGTCPNConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
    End Class
    Public Class ConnectDatabass_FDA_FEE
        Public Function Queryds(ByVal Commands As String) As DataTable
            'Dim sqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_FEEConnectionString").ConnectionString)
            'sqlConnection.Open()
            'Dim command = New SqlCommand(Sql, sqlConnection)
            'command.CommandTimeout = 100000
            'Return New SqlServerDataReader(command.ExecuteReader())

            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_FEEConnectionString").ConnectionString)
            Dim sqlCOmmand = New SqlCommand(Commands, MyConnection)
            MyConnection.Open()
            sqlCOmmand.CommandTimeout = 10000
            Dim reader As SqlDataReader = sqlCOmmand.ExecuteReader()
            dt.Load(reader)
            'dt = reader.Rea
            'Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            'mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Function Queryds_103(ByVal Commands As String) As DataTable
            'Dim sqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_FEEConnectionString").ConnectionString)
            'sqlConnection.Open()
            'Dim command = New SqlCommand(Sql, sqlConnection)
            'command.CommandTimeout = 100000
            'Return New SqlServerDataReader(command.ExecuteReader())

            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_FEEConnectionString1").ConnectionString)
            Dim sqlCOmmand = New SqlCommand(Commands, MyConnection)
            MyConnection.Open()
            sqlCOmmand.CommandTimeout = 10000
            Dim reader As SqlDataReader = sqlCOmmand.ExecuteReader()
            dt.Load(reader)
            'dt = reader.Rea
            'Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            'mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
    End Class

    '

    Public Class DISBURSE_BUDGET
        Public Function ERROR_BAISANG() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "select  a.REF01 , a.REF02 from [dbo].[LOG_H2H_ERROR] a left join [MAINTAINS].[RECEIVE_MONEY] b on a.ref01 = b.ref01 and a.ref02 = b.ref02 where cast([CREATE_DATE] as date) = '2020-06-23' and b.REF01 is null and a.ref01 is not null"

            dt = Queryds(command)
            Return dt
        End Function
        Public Function ERROR_RECEIPT() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " select er.* from 	 ("
            command &= " select ref01 , ref02 , cast([create_date] as date) as [create_date] from [dbo].[LOG_H2H_ERROR]"
            command &= " where cast([create_date] as date) = cast(getdate() as date) and "
            command &= " [error_msg] like '%error%' "
            command &= " group by ref01 , ref02 , cast([create_date] as date) "
            command &= " ) er "
            command &= " left join [MAINTAINS].[RECEIVE_MONEY]	re on re.ref01 = er.ref01"
            command &= " where re.ref01 Is null"
            command &= " order by [create_date]"
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_deka_detail_budget_group(ByVal FK As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_deka_detail_budget_group] @DEKA_ID=" & FK
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_DEKA_DETAIL_BUDGET_DEKA(ByVal fkid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_DEKA_DETAIL_BUDGET_DEKA] @FK=" & fkid
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_sum_deka_detail_budget_group_detail(ByVal FK_DEKA As Integer, ByVal FK_BUD As Integer) As Double
            Dim dt As New DataTable
            Dim command As String = " "
            Dim value As Double = 0

            command = " exec [BUDGETS].[get_sum_deka_detail_budget_group_detail] @DEKA_ID=" & FK_DEKA & ",@BUDGET_ID=" & FK_BUD
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("AMOUNT_MONEY")) Then
                    value = 0
                Else
                    value = CInt(dt(0)("AMOUNT_MONEY"))
                End If
            End If

            Return value
        End Function
        Public Function get_budget_deka_detail(ByVal bgyear As Integer, fk_deka As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_budget_deka_detail] @BUDGET_YEAR = " & bgyear & ", @FK_DEKA=" & fk_deka
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_budget_deka_detail2_v2(ByVal bgyear As Integer, ByVal Plan_Id As Integer, ByVal Pro_Id As Integer, ByVal Act_Id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_budget_deka_detail2_v2] @BUDGET_YEAR = " & bgyear & ",@Plan_Id=" & Plan_Id & ",@Product_Id=" & Pro_Id & ",@Activity_Id=" & Act_Id
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_deka_detail_budget_group_detail(ByVal FK As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_deka_detail_budget_group_detail] @DEKA_ID=" & FK
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_deka_detail_budget_group2(ByVal FK As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_deka_detail_budget_group2] @DEKA_ID=" & FK
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_budget_count_deka_detail(ByVal bgyear As Integer, fk_deka As Integer) As Integer
            Dim dt As New DataTable
            Dim command As String = " "
            Dim value As Integer = 0

            command = " exec [BUDGETS].[get_budget_count_deka_detail] @BUDGET_YEAR = " & bgyear & ", @FK_DEKA=" & fk_deka
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("CIDA")) Then
                    value = 0
                Else
                    value = CInt(dt(0)("CIDA"))
                End If
            End If

            Return value
        End Function
        Public Function get_data_deka_head_shortName(ByVal fk As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_data_deka_head_shortName] @FK_DEKA=" & fk
            dt = Queryds(command)
            dt.Columns.Add("DeptCode", GetType(String))
            dt.Columns.Add("DeptName", GetType(String))

            Dim i As Integer = 0
            Dim str As String = ""
            Dim DeptCode As String = ""
            Dim DeptName As String = ""

            For Each dr As DataRow In dt.Rows

                If dt.Rows.Count > 0 Then
                    If dt.Rows.Count = 1 Then
                        DeptCode = dr("DEPARTMENT_CODE")
                        DeptName = dr("DEPARTMENT_SHORT_DESCRIPTION")
                    Else
                        If i = 0 Then
                            DeptCode = dr("DEPARTMENT_CODE")
                            DeptName = dr("DEPARTMENT_SHORT_DESCRIPTION")
                        Else
                            DeptCode = DeptCode & ", " & dr("DEPARTMENT_CODE")
                            DeptName = DeptName & ", " & dr("DEPARTMENT_SHORT_DESCRIPTION")
                        End If

                        i += 1

                    End If
                End If

                dr("DeptCode") = DeptCode
                dr("DeptName") = DeptName

            Next

            Return dt

        End Function
        Public Function get_sum_deka_AMOUNT(ByVal fk As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_sum_deka_AMOUNT] @FK_DEKA=" & fk
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("AMOUNT")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("AMOUNT"))
                End If
            End If

            Return value
        End Function

        Public Function get_sum_deka_AMOUNT_MONEY(ByVal fk As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_sum_deka_AMOUNT_MONEY] @FK_DEKA=" & fk
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("AMOUNT")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("AMOUNT"))
                End If
            End If

            Return value
        End Function
        Public Function get_sum_deka_nMulct(ByVal fk As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_sum_deka_nMulct] @FK_DEKA=" & fk
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("AMOUNT")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("AMOUNT"))
                End If
            End If

            Return value
        End Function
        Public Function get_sum_deka_nInsurance(ByVal fk As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_sum_deka_nInsurance] @FK_DEKA=" & fk
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("AMOUNT")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("AMOUNT"))
                End If
            End If

            Return value
        End Function
        Public Function get_sum_deka_nVat(ByVal fk As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_sum_deka_nVat] @FK_DEKA=" & fk
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("AMOUNT")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("AMOUNT"))
                End If
            End If

            Return value
        End Function

        Public Function get_sum_deka_nTax_Type(ByVal fk As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_sum_deka_nTax_Type] @FK_DEKA=" & fk
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("AMOUNT")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("AMOUNT"))
                End If
            End If

            Return value
        End Function
        Public Function get_deka_budget_type_name_detail() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_deka_budget_type_name_detail]"
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_deka_budget_type_name_detail_by_headId(ByVal headId As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_deka_budget_type_name_detail_by_headId] @HeadId=" & headId
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_deka_bill_by_year(ByVal bg_year As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_deka_bill_by_year] @BUDGET_YEAR=" & bg_year
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_relate_det_by_year(ByVal bg_year As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_relate_det_by_year] @BUDGET_YEAR=" & bg_year
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_all_deka_bill_by_year(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec [BUDGETS].[get_all_deka_bill_by_year] @BUDGET_YEAR = " & bgyear
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_budget_receive_list_bt_group_V2_deka(ByVal bgyear As Integer, bguse As Integer, po As String, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_budget_receive_list_bt_group_V2_deka] @BUDGET_YEAR = " & bgyear & ", @bguse=" & bguse & ",@po='" & po & "' " &
                ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_data_deka_bill_group_bg(ByVal fk As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_data_deka_bill_group_bg] @FK_DEKA=" & fk
            dt = Queryds(command)
            dt.Columns.Add("Code", GetType(String))
            dt.Columns.Add("Name", GetType(String))

            Dim i As Integer = 0
            Dim str As String = ""
            Dim code As String = ""
            Dim name As String = ""

            For Each dr As DataRow In dt.Rows

                If dt.Rows.Count > 0 Then
                    If dt.Rows.Count = 1 Then
                        code = dr("TYPE_CODE")
                        name = dr("BUDGET_NAME")
                    Else
                        If i = 0 Then
                            code = dr("TYPE_CODE")
                            name = dr("BUDGET_NAME")
                        Else
                            code = code & ", " & dr("TYPE_CODE")
                            name = name & ", " & dr("BUDGET_NAME")
                        End If

                        i += 1

                    End If
                End If

                dr("Code") = code
                dr("Name") = name

            Next

            Return dt

        End Function
        Public Function get_data_deka_bill(ByVal fk As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_data_deka_bill] @FK_DEKA=" & fk
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_data_deka_bill_list(ByVal fk As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_data_deka_bill_list] @FK_DEKA=" & fk
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_max_billcode_budget_withdraw() As Integer
            Dim value As Integer = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_max_billcode_budget_withdraw]"
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("MaxCode")) Then
                    value = 0
                Else
                    value = CInt(dt(0)("MaxCode"))
                End If
            End If

            Return value
        End Function
        Public Function get_relate_det_by_fkid(ByVal bg_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_relate_det_by_fkid] @BUDGET_ID=" & bg_id
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_relate_det_by_year_id(ByVal id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_relate_det_by_year_id] @IDA=" & id
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_MaxDeka_Number_ByType(ByVal budgetyear As Integer, deka_type As Integer) As Integer
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_MaxDeka_Number_ByType] @BgYear= " & budgetyear & ", @DekaType= " & deka_type
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                value = CDbl(dt(0)("maxValue"))
            Else
                value = 0
            End If

            Return value
        End Function
        Public Function get_All_Transfer_Money(ByVal bgyear As Integer, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim Value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_All_Transfer_Money] @BUDGET_YEAR=" & bgyear & ",@BUDGET_USE_ID=" & bg_id
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("SUM_AMOUNT")) Then
                    Value = 0
                Else
                    Value = CDbl(dt(0)("SUM_AMOUNT"))
                End If
            End If

            Return Value
        End Function
        Public Function get_budget_receive_list_bt_group_V3_2(ByVal bgyear As Integer, bguse As Integer, po As String, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_budget_receive_list_bt_group_V3_2] @BUDGET_YEAR = " & bgyear & ", @bguse=" & bguse & ",@po='" & po & "' " &
                ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_checker_update2(ByVal bgyear As Integer, ByVal bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_checker_update2] @BUDGET_YEAR=" & bgyear & ",@BUDGET_USE_ID=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_cure_study_bill_v2_by_Gl(budget_year As Integer, billtypeid As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_cure_study_bill_v2_by_Gl]  @budgetyear = " & budget_year & ", @BILL_TYPE_ID = " & billtypeid & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_budgetWithdraw_deka_detail(ByVal fk As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_budgetWithdraw_deka_detail] @fk=" & fk
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_budgetWithdraw_detail(ByVal fk As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_budgetWithdraw_detail] @fk=" & fk
            dt = Queryds(command)
            Return dt

        End Function

        Public Function get_budget_receive_list_bt_group_V3_Report(ByVal bgyear As Integer, bguse As Integer, po As String, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer, ByVal ctzid As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_budget_receive_list_bt_group_V3_Report] @BUDGET_YEAR = " & bgyear & ", @bguse=" & bguse & ",@po='" & po & "' " &
                ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g & " ,@ctzid='" & ctzid & "'"
            dt = Queryds(command)

            Return dt
        End Function

        Public Function getCount_count_approve(ByVal fkId As Integer, ByVal stat As Integer, ByVal type As Integer, ByVal year As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double
            Dim command As String = " "
            command = " exec [dbo].[getCount_count_approve] @FK_ID=" & fkId & ",@Status=" & stat & ",@Type=" & type & ",@year=" & year
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("approveCount")) Then
                    value = 0
                Else
                    value = CInt(dt(0)("approveCount"))
                End If
            End If

            Return value
        End Function

        Public Function getGF_bg_bill_sub_PO_bt_group_v2_report2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_bg_bill_sub_PO_bt_group_v2_report] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear _
                 & ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function getGF_bg_bill_sub_PO_bt_group_v2_Report(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_bg_bill_sub_PO_bt_group_v2_Report] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear _
                 & ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function getGF_bg_bill_bt_group_no_rebill_report(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_bg_bill_bt_group_no_rebill_report] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear _
                 & ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function getGF_bg_bill_bt_group_V2_report(ByVal budgetuse As Integer, ByVal budgetyear As Integer, po As String, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_bg_bill_bt_group_V2_report] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ", @IS_PO=" & po _
                 & ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_BudgetYear() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BudgetYear_v1] "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_food() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_food] "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_relate_bill_HRD(ByVal bgyear As Integer, ByVal dept As Integer, ByVal bg_use As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_relate_bill_HRD]  @BUDGET_YEAR=" & bgyear & " ,@department_id=" & dept & ",@bg_use=" & bg_use
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_email_all(ByVal ida As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_email_all] @ida=" & ida
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_tb_deeka_withdraw() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_tb_deeka_withdraw] "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function aaaaa() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[aaaaa] "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function getSupportdet_bg() As Double
            Dim value As Double = 0
            value = 1000000.0
            Return value
        End Function
        Public Function get_BUDGET_BILL_by_bg_year_bg_bill(ByVal bgyear As Integer, ByVal gfmisbill As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_by_bill_id] @GFMIS_Number = '" & gfmisbill & "' , @Budget_Year=" & bgyear
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_debtor_margin_return_all(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_margin_return_all] @budgetyear = " & bgyear
            dt = Queryds(command)

            Return dt
        End Function
        Public Function getOverlap(ByVal bgyear As Integer, ByVal deptid As Integer, bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getOverlap] @BUDGET_YEAR = " & bgyear & " , @DEPARTMENT_ID=" & deptid & ", @BUDGET_PLAN_ID=" & bgid
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_relate_bill(ByVal bgyear As Integer, ByVal bg_id As Integer, ByVal dept As Integer, ByVal bg_use As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_relate_bill]  @BUDGET_YEAR=" & bgyear & " , @BUDGET_PLAN_ID=" & bg_id & ",@department_id=" & dept & ",@bg_use=" & bg_use
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_relate_bill_V2(ByVal bgyear As Integer, ByVal dept As Integer, ByVal bg_use As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_relate_bill_V2]  @BUDGET_YEAR=" & bgyear & " ,@department_id=" & dept & ",@bg_use=" & bg_use
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_relate_bill_V3(ByVal bgyear As Integer, ByVal bg_use As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_relate_bill_V3]  @BUDGET_YEAR=" & bgyear & " ,@bg_use=" & bg_use
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_relate_receive_number_max(ByVal bgyear As Integer) As Integer
            Dim value As Integer = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_relate_receive_number_max] @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bill_max")) Then
                    value = 0
                Else
                    value = CInt(dt(0)("bill_max"))
                End If
            End If

            Return value
        End Function
        Public Function get_bg_adjust_detail_amount2(ByVal budgetyear As Integer, ByVal bg_id As Integer, ByVal dept As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bg_adjust_detail_amount2] @budgetYear= " & budgetyear & " , @bg_id= " & bg_id & " ,@dept=" & dept
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                value = CDbl(dt(0)("BUDGET_DEPARTMENT_MONEY"))
            End If


            Return value
        End Function
        Public Function get_Amount_Disburse_App2(ByVal budget_id As Integer, ByVal budgetYear As Integer, ByVal dept As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Amount_Disburse_App2] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear & ",@DEPARTMENT_ID=" & dept
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        Public Function get_amount_berg_cer(ByVal relate_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_amount_berg_cer] @RELATE_ID = " & relate_id
            dt = Queryds(command)
            Try
                value = CDbl(dt(0)("amount"))
            Catch ex As Exception

            End Try

            Return value
        End Function
        'get_po_prepare_overlap
        'Public Function get_po_prepare_overlap(ByVal bgyear As Integer, ByVal deptid As Integer, bgid As Integer) As DataTable
        '    Dim dt As New DataTable
        '    Dim command As String = " "
        '    command = " exec [BUDGETS].[get_po_prepare_overlap] @BUDGET_YEAR = " & bgyear & " , @DEPARTMENT_ID=" & deptid & ", @BUDGET_PLAN_ID=" & bgid
        '    dt = Queryds(command)

        '    Return dt
        'End Function
        'get_budget_receive_list
        Public Function get_budget_margin_withdraw_add_receive_list(ByVal bgyear As Integer, bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_budget_margin_withdraw_add_receive_list] @BUDGET_YEAR = " & bgyear & ", @bguse=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        'get_budget_margin_withdraw_add_receive_list
        Public Function get_budget_receive_list(ByVal bgyear As Integer, bguse As Integer, po As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_budget_receive_list] @BUDGET_YEAR = " & bgyear & ", @bguse=" & bguse & ",@po=" & po
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_budget_receive_list_bt_group(ByVal bgyear As Integer, bguse As Integer, po As String, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_budget_receive_list_bt_group] @BUDGET_YEAR = " & bgyear & ", @bguse=" & bguse & ",@po=" & po &
                ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_budget_receive_list_bt_group_V2(ByVal bgyear As Integer, bguse As Integer, po As String, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_budget_receive_list_bt_group_V2] @BUDGET_YEAR = " & bgyear & ", @bguse=" & bguse & ",@po='" & po & "' " &
                ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_budget_receive_list_bt_group_V3(ByVal bgyear As Integer, bguse As Integer, po As String, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer, ByVal ctzid As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_budget_receive_list_bt_group_V3] @BUDGET_YEAR = " & bgyear & ", @bguse=" & bguse & ",@po='" & po & "' " &
                ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g & " ,@ctzid='" & ctzid & "'"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_budget_receive_list_PO(ByVal bgyear As Integer, bguse As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_budget_receive_list_PO] @BUDGET_YEAR = " & bgyear & ", @bguse=" & bguse &
                ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_budget_receive_list_PO_V2(ByVal bgyear As Integer, bguse As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer, ByVal ctzid As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_budget_receive_list_PO_V2] @BUDGET_YEAR = " & bgyear & ", @bguse=" & bguse &
                ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g & ", @ctzid='" & ctzid & "'"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_budget_receive_list_sub_po_bt_group(ByVal bgyear As Integer, bguse As Integer, po As String, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_budget_receive_list_sub_po_bt_group] @BUDGET_YEAR = " & bgyear & ", @bguse=" & bguse & ",@po=" & po &
                ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_budget_receive_rebill_list(ByVal bgyear As Integer, bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_budget_receive_rebill_list] @BUDGET_YEAR = " & bgyear & ", @bguse=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        'get_budget_receive_no_rebill_list
        Public Function get_budget_receive_no_rebill_list(ByVal bgyear As Integer, bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_budget_receive_no_rebill_list] @BUDGET_YEAR = " & bgyear & ", @bguse=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_cure_study_receive_list(ByVal bgyear As Integer, billtype As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_cure_study_receive_list] @budgetyear = " & bgyear & ", @BILL_TYPE_ID=" & billtype
            dt = Queryds(command)

            Return dt
        End Function
        'get_other_receive_list
        Public Function get_other_receive_list(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_other_receive_list] @budgetyear = " & bgyear
            dt = Queryds(command)

            Return dt
        End Function
        'get_budget_receive_list_sub_po
        Public Function get_budget_receive_list_sub_po(ByVal bgyear As Integer, bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_budget_receive_list_sub_po] @BUDGET_YEAR = " & bgyear & ", @bguse=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        'get_budget_margin_move_receive_list
        Public Function get_budget_margin_move_receive_list(ByVal bgyear As Integer, bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_budget_margin_move_receive_list] @BUDGET_YEAR = " & bgyear & ", @bguse=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        'get_debtor_receive_list
        Public Function get_debtor_receive_list(ByVal bgyear As Integer, bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_receive_list] @BUDGET_YEAR = " & bgyear & ", @bguse=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_debtor_receive_list_bt_group(ByVal bgyear As Integer, bguse As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_receive_list_bt_group] @BUDGET_YEAR = " & bgyear & ", @bguse=" & bguse & ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_debtor_receive_list_bt_groupv2(ByVal bgyear As Integer, bguse As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_receive_list_bt_groupv2] @BUDGET_YEAR = " & bgyear & ", @bguse=" & bguse & ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_debtor_receive_list_bt_groupv3(ByVal bgyear As Integer, bguse As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer, ByVal ctzid As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_receive_list_bt_groupv3] @BUDGET_YEAR = " & bgyear & ", @bguse=" & bguse & ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g & ", @ctzid='" & ctzid & "'"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_Overlap_bill() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Overlap_bill] "
            dt = Queryds(command)

            Return dt
        End Function
        'get_po_prepare_overlap
        Public Function get_po_prepare_overlap(ByVal bgyear As Integer, bgid As Integer, ByVal dept As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_po_prepare_overlap] @BUDGET_YEAR = " & bgyear & " , @BUDGET_PLAN_ID=" & bgid & ",@DEPARTMENT_ID=" & dept
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_Overlap_approve_OK(ByVal bgyear As Integer, bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Overlap_approve_OK] @BUDGET_YEAR = " & bgyear & " , @BUDGET_PLAN_ID=" & bgid
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_Overlap_approve_Cancel(ByVal bgyear As Integer, bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Overlap_approve_Cancel] @BUDGET_YEAR = " & bgyear & " , @BUDGET_PLAN_ID=" & bgid
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_Overlap_debtor() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Overlap_debtor] "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function getNodeBack(ByRef dt As DataTable, ByVal bgChild_id As Integer, Optional ByVal i As Integer = 1) As DataTable
            ' Dim dt As New DataTable

            Dim dao As New DAO_MAS.TB_BUDGET_PLAN
            dao.getdata_by_Child_id_joinV2(bgChild_id)
            'Dim i As Integer = 1

            For Each dao.fields In dao.datas
                Dim dr As DataRow
                dr = dt.NewRow()
                dr("seq") = i
                If dao.fields.BUDGET_TYPE_ID = 5 Then
                    If dao.fields.BUDGET_CODE IsNot Nothing Then
                        dr("BUDGET_DESCRIPTION") = dao.fields.BUDGET_CODE & " - " & dao.fields.BUDGET_DESCRIPTION
                    Else
                        dr("BUDGET_DESCRIPTION") = dao.fields.BUDGET_DESCRIPTION
                    End If


                Else
                    dr("BUDGET_DESCRIPTION") = dao.fields.BUDGET_DESCRIPTION
                End If
                dr("BUDGET_AMOUNT") = dao.fields.BUDGET_AMOUNT

                i = i + 1
                dt.Rows.Add(dr)
                getNodeBack(dt, dao.fields.BUDGET_CHILD_ID, i)
                If dao.fields.BUDGET_CHILD_ID = 0 Then
                    Exit For
                End If

            Next
            Return dt
        End Function
        Public Function getNodeBack_v2(ByRef dt As DataTable, ByVal bgChild_id As Integer, Optional ByVal i As Integer = 1) As DataTable
            ' Dim dt As New DataTable

            Dim dao As New DAO_MAS.TB_BUDGET_PLAN
            dao.getdata_by_Child_id_joinV2(bgChild_id)
            'Dim i As Integer = 1

            For Each dao.fields In dao.datas
                If dao.fields.BUDGET_TYPE_ID <> 1 Then
                    Dim dr As DataRow
                    dr = dt.NewRow()
                    dr("seq") = dao.fields.BUDGET_TYPE_ID
                    If dao.fields.BUDGET_TYPE_ID = 5 Then
                        If dao.fields.BUDGET_CODE IsNot Nothing Then
                            dr("BUDGET_DESCRIPTION") = dao.fields.BUDGET_CODE & " - " & dao.fields.BUDGET_DESCRIPTION
                        Else
                            dr("BUDGET_DESCRIPTION") = dao.fields.BUDGET_DESCRIPTION
                        End If


                    Else
                        dr("BUDGET_DESCRIPTION") = dao.fields.BUDGET_DESCRIPTION
                    End If
                    dr("BUDGET_AMOUNT") = dao.fields.BUDGET_AMOUNT
                    dr("BUDGET_PLAN_ID") = dao.fields.BUDGET_PLAN_ID
                    'i = i + 1
                    dt.Rows.Add(dr)
                    getNodeBack_v2(dt, dao.fields.BUDGET_CHILD_ID, i)
                    If dao.fields.BUDGET_CHILD_ID = 0 Then
                        Exit For
                    End If
                End If


            Next
            Return dt
        End Function
        Public Function getNodeBack_report(ByRef dt As DataTable, ByVal bgChild_id As Integer, Optional ByVal i As Integer = 1) As DataTable
            ' Dim dt As New DataTable

            Dim dao As New DAO_MAS.TB_BUDGET_PLAN
            dao.getdata_by_Child_id_join(bgChild_id)
            'Dim i As Integer = 1

            For Each dao.fields In dao.datas
                Dim dr As DataRow
                dr = dt.NewRow()
                dr("seq") = i
                If IsDBNull(dao.fields.BUDGET_CODE) = False Then
                    dr("BUDGET_DESCRIPTION") = dao.fields.BUDGET_CODE & " " & dao.fields.BUDGET_DESCRIPTION
                Else
                    dr("BUDGET_DESCRIPTION") = dao.fields.BUDGET_DESCRIPTION
                End If
                dr("BUDGET_AMOUNT") = dao.fields.BUDGET_AMOUNT
                dr("BUDGET_MAIN_TYPE") = dao.fields.BUDGET_MAIN_TYPE
                dr("BUDGET_TYPE_ID") = dao.fields.BUDGET_TYPE_ID

                i = i + 1
                dt.Rows.Add(dr)
                getNodeBack_report(dt, dao.fields.BUDGET_CHILD_ID, i)
                If dao.fields.BUDGET_CHILD_ID = 0 Then
                    Exit For
                End If

            Next
            Return dt
        End Function
        Public Function getMoneyTypeNodeBack(ByRef dt As DataTable, ByVal bgChild_id As Integer, Optional ByVal i As Integer = 1) As DataTable
            ' Dim dt As New DataTable

            Dim dao As New DAO_MAS.TB_MAS_MONEY_TYPE
            dao.getdata_by_Child_id_join(bgChild_id)
            'Dim i As Integer = 1

            For Each dao.fields In dao.datas
                Dim dr As DataRow
                dr = dt.NewRow()
                dr("seq") = i
                dr("MONEY_TYPE_DESCRIPTION") = dao.fields.MONEY_TYPE_DESCRIPTION
                dr("MONEY_AMOUNT") = dao.fields.MONEY_AMOUNT
                dr("TYPE_ID") = dao.fields.TYPE_ID
                i = i + 1
                dt.Rows.Add(dr)
                getMoneyTypeNodeBack(dt, dao.fields.HEAD_MONEY_TYPE_ID, i)
                If dao.fields.HEAD_MONEY_TYPE_ID = 0 Then
                    Exit For
                End If

            Next
            Return dt
        End Function
        Public Function getMoneyTypeNodeBackReport(ByRef dt As DataTable, ByVal bgChild_id As Integer, Optional ByVal i As Integer = 1) As DataTable
            ' Dim dt As New DataTable

            'Dim dao As New DAO_MAS.TB_MAS_MONEY_TYPE
            'dao.getdata_by_Child_id_join(bgChild_id)
            ''Dim i As Integer = 1
            Dim dao_node As New DAO_MAS.TB_MAS_MONEY_TYPE
            dao_node.Getdata_Head_no_Year(bgChild_id)


            For Each dao_node.fields In dao_node.datas
                Dim dr As DataRow
                dr = dt.NewRow()
                dr("seq") = i
                dr("MONEY_TYPE_DESCRIPTION") = dao_node.fields.MONEY_TYPE_DESCRIPTION
                dr("MONEY_AMOUNT") = dao_node.fields.MONEY_AMOUNT
                dr("TYPE_ID") = dao_node.fields.TYPE_ID
                dr("MONEY_TYPE_ID") = dao_node.fields.MONEY_TYPE_ID
                i = i + 1
                dt.Rows.Add(dr)
                getMoneyTypeNodeBackReport(dt, dao_node.fields.MONEY_TYPE_ID, i)
                If dao_node.fields.HEAD_MONEY_TYPE_ID = 0 Then
                    Exit For
                End If

            Next
            Return dt
        End Function

        Public Function Queryds(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DTAMConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Sub Queryds2(ByVal Commands As String)
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DTAMConnectionString").ConnectionString)
            Dim cmd As New SqlCommand
            MyConnection.Open()
            cmd.Connection = MyConnection
            cmd.CommandText = Commands
            cmd.ExecuteNonQuery()
            MyConnection.Close()
        End Sub
        '
        Public Function Queryds_CPN(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("LGTCPNConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Function get_bill_all(ByVal PAY_TYPE_ID As Integer, ByVal budgetyear As Integer, bg_use_id As Integer, po As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_all] @PAY_TYPE_ID =" & PAY_TYPE_ID & " , @budgetyear= " & budgetyear & ",@BUDGET_USE_ID= " & bg_use_id & " , @IS_PO=" & po
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_all_sub_po(ByVal PAY_TYPE_ID As Integer, ByVal budgetyear As Integer, bg_use_id As Integer, po As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_all_sub_po] @PAY_TYPE_ID =" & PAY_TYPE_ID & " , @budgetyear= " & budgetyear & ",@BUDGET_USE_ID= " & bg_use_id & " , @IS_PO=" & po
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bg_adjust_before_transfer(ByVal budgetyear As Integer, bg_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bg_adjust_before_transfer] @BUDGET_YEAR= " & budgetyear & ", @BUDGET_PLAN_ID= " & bg_id
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_transfer_from_dept(ByVal budgetyear As Integer, bg_id As Integer, deptid As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_transfer_from_dept] @BUDGET_YEAR= " & budgetyear & ", @BUDGET_PLAN_ID= " & bg_id & ", @FROM_DEPARTMENT_ID=" & deptid
            dt = Queryds(command)
            value = CDbl(dt(0)("Amount"))
            Return value
        End Function
        Public Function get_transfer_to_dept(ByVal budgetyear As Integer, bg_id As Integer, deptid As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_transfer_to_dept] @BUDGET_YEAR= " & budgetyear & ", @BUDGET_PLAN_ID= " & bg_id & ", @TO_DEPARTMENT_ID=" & deptid
            dt = Queryds(command)
            value = CDbl(dt(0)("Amount"))
            Return value
        End Function
        Public Function get_k_type(ByVal ktype_code As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " select * from MAS_K_TYPE where K_TYPE_CODE= '" & ktype_code & "'"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_k_type_all_with_pay() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " select k.K_TYPE_ID, k.K_TYPE_CODE , k.K_TYPE_NAME + ' - ' + k.K_TYPE_EX1 as K_TYPE_NAME from MAS_K_TYPE k  "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_k_type_all_with_pay_debt(debt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " select k.K_TYPE_ID , k.K_TYPE_CODE , k.K_TYPE_NAME + ' - ' + k.K_TYPE_EX1 as K_TYPE_NAME from MAS_K_TYPE k  where DEBTOR_TYPE_ID=" & debt
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_k_type_all_with_express(debt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " select k.K_TYPE_ID, k.K_TYPE_CODE , k.K_TYPE_NAME + ' - ' + k.K_TYPE_EX2 as K_TYPE_NAME from MAS_K_TYPE k  where DEBTOR_TYPE_ID=" & debt
            dt = Queryds(command)

            Return dt
        End Function

        'select k.K_TYPE_ID, k.K_TYPE_CODE , k.K_TYPE_NAME from MAS_K_TYPE k where k.K_TYPE_NAME in ('KL','K1')
        Public Function get_k_type_debtor() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " select k.K_TYPE_ID, k.K_TYPE_CODE , k.K_TYPE_NAME from MAS_K_TYPE k where k.K_TYPE_NAME in ('KL','K1')"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_money_type_name(bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " select m.MONEY_TYPE_ID , m.MONEY_TYPE_DESCRIPTION from dbo.MAS_MONEY_TYPE m join dbo.MAS_MONEY_TYPE_NODE mn on m.MONEY_TYPE_ID = mn.CHILD_ID where m.BUDGET_YEAR =" & bgyear

            dt = Queryds(command)

            Return dt
        End Function

        Public Function getBudgetTypeData(ByVal budgetyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getBudgetTypeData] @BUDGET_YEAR= " & budgetyear
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_rebill_pay_pass(ByVal PAY_TYPE_ID As Integer, ByVal budgetyear As Integer, bg_use_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_rebill_pay_pass] @PAY_TYPE_ID =" & PAY_TYPE_ID & " , @budgetyear= " & budgetyear & ", @BUDGET_USE_ID= " & bg_use_id
            dt = Queryds(command)

            Return dt
        End Function
        'get_margin_move_pay_pass
        Public Function get_margin_move_pay_pass(ByVal PAY_TYPE_ID As Integer, ByVal budgetyear As Integer, bg_use_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_margin_move_pay_pass] @PAY_TYPE_ID =" & PAY_TYPE_ID & " , @budgetyear= " & budgetyear & ", @BUDGET_USE_ID= " & bg_use_id
            dt = Queryds(command)

            Return dt
        End Function
        'get_no_rebill_pay_pass
        Public Function get_no_rebill_pay_pass(ByVal PAY_TYPE_ID As Integer, ByVal budgetyear As Integer, bg_use_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_no_rebill_pay_pass] @PAY_TYPE_ID =" & PAY_TYPE_ID & " , @budgetyear= " & budgetyear & ", @BUDGET_USE_ID= " & bg_use_id
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_debtor_all(ByVal budgetyear As Integer, bguse As Integer, DEBTOR_TYPE_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_debtor_all] @budgetyear= " & budgetyear & " , @BUDGET_USE_ID=" & bguse & ", @DEBTOR_TYPE_ID= " & DEBTOR_TYPE_ID
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bg_plan() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " select * from dbo.BUDGET_PLAN "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_dept() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " select * FROM dbo.MAS_DEPARTMENT "
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_Adjust_App_Amount(ByVal budget_id As Integer, ByVal budgetYear As Integer, ByVal isApp As String, ByVal detp_id As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Adjust_App_Amount] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear & ", @IS_APPROVE ='" & isApp & "' , @DEPARTMENT_ID= " & detp_id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        Public Function get_Adjust_App_Amount_All(ByVal budgetYear As Integer, ByVal isApp As String) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Adjust_App_Amount_All]  @BUDGET_YEAR = " & budgetYear & ", @IS_APPROVE ='" & isApp & "'"
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        'get_Adjust_App_Amount_All
        Public Function get_Adjust_debt_App_Amount(ByVal budget_id As Integer, ByVal budgetYear As Integer, ByVal detp_id As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Adjust_debt_App_Amount] @IS_APPROVE = 'True' , @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear & " , @DEPARTMENT_ID= " & detp_id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        Public Function get_Adjust_debt_before_App_Amount(ByVal budget_id As Integer, ByVal budgetYear As Integer, ByVal detp_id As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Adjust_debt_before_App_Amount] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear & " , @DEPARTMENT_ID= " & detp_id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        'get_Adjust_debt_App_Amount_sup
        Public Function get_Adjust_debt_App_Amount_sup(ByVal budget_id As Integer, ByVal budgetYear As Integer, ByVal detp_id As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Adjust_debt_App_Amount_sup] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear & " , @DEPARTMENT_ID= " & detp_id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        'get_Adjust_debt_before_App_Amount_sup
        Public Function get_Adjust_debt_before_App_Amount_sup(ByVal budget_id As Integer, ByVal budgetYear As Integer, ByVal detp_id As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Adjust_debt_before_App_Amount_sup] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear & " , @DEPARTMENT_ID= " & detp_id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        Public Function get_PO_App_Amount(ByVal budget_id As Integer, ByVal budgetYear As Integer, ByVal detp_id As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_PO_App_Amount] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear & ", @DEPARTMENT_ID= " & detp_id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        'get_PO_App_Amount_sup
        Public Function get_PO_App_Amount_sup(ByVal budget_id As Integer, ByVal budgetYear As Integer, ByVal detp_id As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_PO_App_Amount_sup] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear & ", @DEPARTMENT_ID= " & detp_id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        'get_PO_before_App_Amount
        Public Function get_PO_before_App_Amount(ByVal budget_id As Integer, ByVal budgetYear As Integer, ByVal detp_id As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_PO_before_App_Amount] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear & ", @DEPARTMENT_ID= " & detp_id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        'get_PO_before_App_Amount_sup
        Public Function get_PO_before_App_Amount_sup(ByVal budget_id As Integer, ByVal budgetYear As Integer, ByVal detp_id As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_PO_before_App_Amount_sup] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear & ", @DEPARTMENT_ID= " & detp_id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function

        'get_disburse_PO_App_Amount
        Public Function get_disburse_PO_App_Amount(ByVal budget_id As Integer, ByVal budgetYear As Integer, ByVal detp_id As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_disburse_PO_App_Amount] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear & ", @DEPARTMENT_ID= " & detp_id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        'get_disburse_PO_App_Amount_sup
        Public Function get_disburse_PO_App_Amount_sup(ByVal budget_id As Integer, ByVal budgetYear As Integer, ByVal detp_id As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_disburse_PO_App_Amount_sup] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear & ", @DEPARTMENT_ID= " & detp_id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function

        'get_disburse_PO_before_App_Amount
        Public Function get_disburse_PO_before_App_Amount(ByVal budget_id As Integer, ByVal budgetYear As Integer, ByVal detp_id As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_disburse_PO_before_App_Amount] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear & ", @DEPARTMENT_ID= " & detp_id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function

        'get_disburse_PO_before_App_Amount_sup
        Public Function get_disburse_PO_before_App_Amount_sup(ByVal budget_id As Integer, ByVal budgetYear As Integer, ByVal detp_id As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_disburse_PO_before_App_Amount_sup] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear & ", @DEPARTMENT_ID= " & detp_id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function

        'get_debt_return_money_receipt_app
        Public Function get_debt_return_money_receipt_app(ByVal budget_id As Integer, ByVal budgetYear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debt_return_money_receipt_app] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        'get_debt_return_money_receipt_app_sup
        Public Function get_debt_return_money_receipt_app_sup(ByVal budget_id As Integer, ByVal budgetYear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debt_return_money_receipt_app_sup] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        'get_debt_return_money_cash
        Public Function get_debt_return_money_cash(ByVal budget_id As Integer, ByVal budgetYear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debt_return_money_cash] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        'get_debt_return_money_cash_sup
        Public Function get_debt_return_money_cash_sup(ByVal budget_id As Integer, ByVal budgetYear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debt_return_money_cash_sup] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function

        'get_Adjust_debt_App_Amount_All
        Public Function get_Adjust_debt_App_Amount_All(ByVal budgetYear As Integer, ByVal isApp As String) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Adjust_debt_App_Amount_All] @BUDGET_YEAR = " & budgetYear & ", @IS_APPROVE ='" & isApp & "'"
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        Public Function getApproveOutsideAmount(ByVal budget_id As Integer, ByVal budgetYear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApproveOutsideAmount] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        'getBeforeApproveOutsideAmount
        Public Function getBeforeApproveOutsideAmount(ByVal budget_id As Integer, ByVal budgetYear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getBeforeApproveOutsideAmount] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        'get_outdebt_before_app
        Public Function get_outdebt_before_app(ByVal budget_id As Integer, ByVal budgetYear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_outdebt_before_app] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        'get_outdebt_app
        Public Function get_outdebt_app(ByVal budget_id As Integer, ByVal budgetYear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_outdebt_app] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        Public Function get_Amount_before_App(ByVal budget_id As Integer, ByVal budgetYear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Amount_before_App] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        Public Function get_disburse_no_approve_amount(ByVal budget_id As Integer, ByVal budgetYear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_disburse_no_approve_amount] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("amount"))
                End If
            End If

            Return value
        End Function
        'get_disburse_support_no_approve_amount
        Public Function get_disburse_support_no_approve_amount(ByVal budget_id As Integer, ByVal budgetYear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_disburse_support_no_approve_amount] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("amount"))
                End If
            End If

            Return value
        End Function
        Public Function get_disburse_approve_amount(ByVal budget_id As Integer, ByVal budgetYear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_disburse_approve_amount] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("amount"))
                End If
            End If

            Return value
        End Function
        'get_disburse_support_approve_amount
        Public Function get_disburse_support_approve_amount(ByVal budget_id As Integer, ByVal budgetYear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_disburse_support_approve_amount] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("amount"))
                End If
            End If

            Return value
        End Function

        'get_Outdebt_return_money_receipt
        Public Function get_Outdebt_return_money_receipt(ByVal budget_id As Integer, ByVal budgetYear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Outdebt_return_money_receipt] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("amount"))
                End If
            End If

            Return value
        End Function
        'get_Outdebt_return_money_cash
        Public Function get_Outdebt_return_money_cash(ByVal budget_id As Integer, ByVal budgetYear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Outdebt_return_money_cash] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("amount"))
                End If
            End If

            Return value
        End Function
        'get_Amount_before_App_sup
        Public Function get_Amount_before_App_sup(ByVal budget_id As Integer, ByVal budgetYear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Amount_before_App_sup] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        '
        'get_Amount_Disburse_App
        Public Function get_Amount_Disburse_App(ByVal budget_id As Integer, ByVal budgetYear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Amount_Disburse_App] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function
        '
        Public Function get_Amount_Relate_App(ByVal budget_id As Integer, ByVal budgetYear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Amount_Relate_App]@BUDGET_PLAN_ID=" & budget_id & ",@BUDGET_YEAR=" & budgetYear
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function

        'get_Amount_Disburse_App_sup
        Public Function get_Amount_Disburse_App_sup(ByVal budget_id As Integer, ByVal budgetYear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Amount_Disburse_App_sup] @BUDGET_PLAN_ID= " & budget_id & " , @BUDGET_YEAR = " & budgetYear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("Amount"))
                End If
            End If

            Return value
        End Function

        Public Function get_paylist() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " select * from dbo.MAS_PAYLIST "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_BUDGET_BILL_by_id(ByVal BUDGET_USE_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BUDGET_BILL_by_id] @BUDGET_USE_ID = " & BUDGET_USE_ID
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_BUDGET_BILL_by_bg_year_bg_id(ByVal BUDGET_USE_ID As Integer, ByVal bgyear As Integer, ByVal bg_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BUDGET_BILL_by_bg_year_bg_id] @BUDGET_USE_ID = " & BUDGET_USE_ID & " , @BUDGET_YEAR=" & bgyear & " , @BUDGET_PLAN_ID=" & bg_id
            dt = Queryds(command)

            Return dt
        End Function
        'get_BUDGET_BILL_by_year_bg_id
        Public Function get_BUDGET_BILL_by_year_bg_id(ByVal BUDGET_USE_ID As Integer, ByVal bgyear As Integer, ByVal bg_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BUDGET_BILL_by_year_bg_id] @BUDGET_USE_ID = " & BUDGET_USE_ID & " , @BUDGET_YEAR=" & bgyear & " , @BUDGET_PLAN_ID=" & bg_id
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SC_get_Child_BG(ByVal bg_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[SC_get_Child_BG] @id=" & bg_id
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_BUDGET_BILL_by_year_bg_id_bt_group(ByVal BUDGET_USE_ID As Integer, ByVal bgyear As Integer, ByVal bg_id As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BUDGET_BILL_by_year_bg_id_bt_group] @BUDGET_USE_ID = " & BUDGET_USE_ID & " , @BUDGET_YEAR=" & bgyear & " , @BUDGET_PLAN_ID=" & bg_id _
                & ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_BUDGET_BILL_by_year_bg_id_bt_group_V2(ByVal BUDGET_USE_ID As Integer, ByVal bgyear As Integer, ByVal dept As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BUDGET_BILL_by_year_bg_id_bt_group_V2] @BUDGET_USE_ID = " & BUDGET_USE_ID & " , @BUDGET_YEAR=" & bgyear & " , @dept=" & dept _
                & ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_checker_update(ByVal bgyear As Integer, ByVal bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_checker_update] @BUDGET_YEAR=" & bgyear & ",@BUDGET_USE_ID=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_BUDGET_BILL_by_year_bg_id_bt_group_out(ByVal bgyear As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BUDGET_BILL_by_year_bg_id_bt_group_out] @BUDGET_YEAR=" & bgyear & ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_BUDGET_BILL_Deeka(ByVal BUDGET_USE_ID As Integer, ByVal bgyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BUDGET_BILL_Deeka] @BUDGET_USE_ID = " & BUDGET_USE_ID & " , @BUDGET_YEAR=" & bgyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_BUDGET_BILL_Deeka_V2(ByVal BUDGET_USE_ID As Integer, ByVal bgyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BUDGET_BILL_Deeka_V2] @BUDGET_USE_ID = " & BUDGET_USE_ID & " , @BUDGET_YEAR=" & bgyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_cure_study_Deeka_V2(ByVal bgyear As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bill_type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_cure_study_Deeka_V2] @BUDGET_YEAR=" & bgyear & ",@stat=" & stat & ",@g=" & g & " ,@BILL_TYPE_ID=" & bill_type
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_BUDGET_BILL_Deeka_rebill(ByVal BUDGET_USE_ID As Integer, ByVal bgyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BUDGET_BILL_Deeka_rebill] @BUDGET_USE_ID = " & BUDGET_USE_ID & " , @BUDGET_YEAR=" & bgyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_BUDGET_BILL_Deeka_rebill_V2(ByVal BUDGET_USE_ID As Integer, ByVal bgyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BUDGET_BILL_Deeka_rebill_V2] @BUDGET_USE_ID = " & BUDGET_USE_ID & " , @BUDGET_YEAR=" & bgyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_BUDGET_BILL_Deeka_no_rebill(ByVal BUDGET_USE_ID As Integer, ByVal bgyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BUDGET_BILL_Deeka_no_rebill] @BUDGET_USE_ID = " & BUDGET_USE_ID & " , @BUDGET_YEAR=" & bgyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_BUDGET_BILL_Deeka_PO(ByVal BUDGET_USE_ID As Integer, ByVal bgyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BUDGET_BILL_Deeka_PO] @BUDGET_USE_ID = " & BUDGET_USE_ID & " , @BUDGET_YEAR=" & bgyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_BUDGET_BILL_Deeka_PO_V2(ByVal BUDGET_USE_ID As Integer, ByVal bgyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BUDGET_BILL_Deeka_PO_V2] @BUDGET_USE_ID = " & BUDGET_USE_ID & " , @BUDGET_YEAR=" & bgyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        'get_data_berg_month
        Public Function get_data_berg_month(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_data_berg_month] @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)

            Return dt
        End Function
        'get_BUDGET_BILL_Prepare_Margin
        Public Function get_BUDGET_BILL_Prepare_Margin(ByVal bgyear As Integer, ByVal bg_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BUDGET_BILL_Prepare_Margin]  @BUDGET_YEAR=" & bgyear & " , @BUDGET_PLAN_ID=" & bg_id
            dt = Queryds(command)

            Return dt
        End Function
        'get_BUDGET_BILL_Margin_List
        Public Function get_BUDGET_BILL_Margin_List(ByVal bgyear As Integer, ByVal bg_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BUDGET_BILL_Margin_List]  @BUDGET_YEAR=" & bgyear & " , @BUDGET_PLAN_ID=" & bg_id
            dt = Queryds(command)

            Return dt
        End Function
        'get_withdraw_bill
        Public Function get_withdraw_bill(ByVal BUDGET_USE_ID As Integer, ByVal bgyear As Integer, ByVal bg_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_withdraw_bill] @BUDGET_USE_ID = " & BUDGET_USE_ID & " , @BUDGET_YEAR=" & bgyear & " , @BUDGET_PLAN_ID=" & bg_id
            dt = Queryds(command)

            Return dt
        End Function
        'get_return_money_withdraw_add
        Public Function get_return_money_withdraw_add() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_return_money_withdraw_add] "
            dt = Queryds(command)

            Return dt
        End Function

        'get_bg_support_by_bg_year_bg_id
        Public Function get_bg_support_by_bg_year_bg_id(ByVal BUDGET_USE_ID As Integer, ByVal bgyear As Integer, ByVal bg_id As Integer, ByVal sub_bg As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bg_support_by_bg_year_bg_id] @BUDGET_USE_ID = " & BUDGET_USE_ID &
                " , @BUDGET_YEAR=" & bgyear & " , @BUDGET_PLAN_ID=" & bg_id & " ,@PATLIST_ID=" & sub_bg
            dt = Queryds(command)

            Return dt
        End Function
        'get_bg_support_by_year_bg_id
        Public Function get_bg_support_by_year_bg_id(ByVal BUDGET_USE_ID As Integer, ByVal bgyear As Integer, ByVal bg_id As Integer, ByVal sub_bg As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bg_support_by_year_bg_id] @BUDGET_USE_ID = " & BUDGET_USE_ID &
                " , @BUDGET_YEAR=" & bgyear & " , @BUDGET_PLAN_ID=" & bg_id & " ,@PATLIST_ID=" & sub_bg
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bg_bill_rebill_debtor(ByVal BUDGET_USE_ID As Integer, ByVal bgyear As Integer, ByVal bg_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bg_bill_rebill_debtor] @BUDGET_USE_ID = " & BUDGET_USE_ID & " , @BUDGET_YEAR=" & bgyear & " , @BUDGET_PLAN_ID=" & bg_id
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bg_bill_rebill_debtor_bt_group(ByVal BUDGET_USE_ID As Integer, ByVal bgyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bg_bill_rebill_debtor_bt_group] @BUDGET_USE_ID = " & BUDGET_USE_ID & " , @BUDGET_YEAR=" & bgyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        'get_no_rebill
        Public Function get_no_rebill(ByVal BUDGET_USE_ID As Integer, ByVal bgyear As Integer, ByVal bg_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_no_rebill] @BUDGET_USE_ID = " & BUDGET_USE_ID & " , @BUDGET_YEAR=" & bgyear & " , @BUDGET_PLAN_ID=" & bg_id
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_no_rebillV2(ByVal BUDGET_USE_ID As Integer, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_no_rebillV2] @BUDGET_USE_ID = " & BUDGET_USE_ID & " , @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_margin_move(ByVal BUDGET_USE_ID As Integer, ByVal bgyear As Integer, ByVal bg_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_margin_move] @BUDGET_USE_ID = " & BUDGET_USE_ID & " , @BUDGET_YEAR=" & bgyear & " , @BUDGET_PLAN_ID=" & bg_id
            dt = Queryds(command)

            Return dt
        End Function
        'get_debtor_no_rebill_add
        Public Function get_debtor_no_rebill_add() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_no_rebill_add] "
            dt = Queryds(command)

            Return dt
        End Function
        'get_bill_margin_for_move
        Public Function get_bill_margin_for_move(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_margin_for_move] @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_debtor_out_no_rebill_add() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_out_no_rebill_add] "
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_BUDGET_BILL_Magin(ByVal BUDGET_USE_ID As Integer, ByVal bgyear As Integer, ByVal pay_type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BUDGET_BILL_Magin] @BUDGET_USE_ID = " & BUDGET_USE_ID & " , @BUDGET_YEAR=" & bgyear & " , @PAY_TYPE_ID=" & pay_type
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_DEBTOR_BILL(budget_year As Integer, bg_use As Integer, ByVal bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_DEBTOR_BILL]  @BUDGET_YEAR = " & budget_year & ", @BUDGET_USE_ID=" & bg_use & ", @BUDGET_PLAN_ID= " & bgid
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_DEBTOR_BILL_NEW_dept(budget_year As Integer, bg_use As Integer, ByVal dept As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_DEBTOR_BILL_NEW_dept]  @BUDGET_YEAR = " & budget_year & ", @BUDGET_USE_ID=" & bg_use & ", @dept= " & dept
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_DEBTOR_BILL_NEW(budget_year As Integer, bg_use As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_DEBTOR_BILL_NEW]  @BUDGET_YEAR = " & budget_year & ", @BUDGET_USE_ID=" & bg_use
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_DEBTOR_BILL_outside(ByVal budget_year As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_DEBTOR_BILL_outside]  @BUDGET_YEAR = " & budget_year
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_debtor_unlock_deeka(budget_year As Integer, bg_use As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_unlock_deeka]  @BUDGET_YEAR = " & budget_year & ", @BUDGET_USE_ID=" & bg_use
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_debtor_unlock_deeka_bt_group(budget_year As Integer, bg_use As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_unlock_deeka_bt_group]  @BUDGET_YEAR = " & budget_year & ", @BUDGET_USE_ID=" & bg_use & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_debtor_unlock_deeka_bt_group_v2(budget_year As Integer, bg_use As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_unlock_deeka_bt_group_v2]  @BUDGET_YEAR = " & budget_year & ", @BUDGET_USE_ID=" & bg_use & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        'get_DEBTOR_BILL_support_dept
        Public Function get_DEBTOR_BILL_support_dept(budget_year As Integer, sub_bg As Integer, ByVal bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_DEBTOR_BILL_support_dept]  @BUDGET_YEAR = " & budget_year & ", @PAYLIST_ID=" & sub_bg & ", @BUDGET_PLAN_ID= " & bgid
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_cure_study_bill(budget_year As Integer, billtypeid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_cure_study_bill]  @budgetyear = " & budget_year & ", @BILL_TYPE_ID = " & billtypeid
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_cure_study_bill_v2(budget_year As Integer, billtypeid As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_cure_study_bill_v2]  @budgetyear = " & budget_year & ", @BILL_TYPE_ID = " & billtypeid & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        'get_dis_home
        Public Function get_dis_home(budget_year As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_dis_home]  @BUDGET_YEAR = " & budget_year
            dt = Queryds(command)

            Return dt
        End Function
        'get_dis_other
        Public Function get_dis_other(budget_year As Integer, ByVal billtype As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_dis_other]  @BUDGET_YEAR = " & budget_year & " ,@BILL_TYPE_ID=" & billtype
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_cure_study_bill_status(budget_year As Integer, billtypeid As Integer, salary_digit As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_cure_study_bill_status]  @budgetyear = " & budget_year & ", @BILL_TYPE_ID = " & billtypeid & ", @INCLUDE_SALARY_DIGIT=" & salary_digit
            dt = Queryds(command)

            Return dt
        End Function
        'get_other_bill_status
        Public Function get_other_bill_status(budget_year As Integer, salary_digit As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_other_bill_status]  @budgetyear = " & budget_year & " , @INCLUDE_SALARY_DIGIT=" & salary_digit
            dt = Queryds(command)

            Return dt
        End Function
        Public Function getGF_study(budget_year As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_study]  @BUDGET_YEAR = " & budget_year
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_margin_all() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_margin_all] "
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_debtor_margin_all(bgyear As Integer, bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_margin_all] @budgetyear= " & bgyear & ", @BUDGET_USE_ID=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        'get_BUDGET_BILL_Margin_Status
        Public Function get_BUDGET_BILL_Margin_Status(bgyear As Integer, ByVal m_type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BUDGET_BILL_Margin_Status] @BUDGET_YEAR= " & bgyear & ",@margin=" & m_type
            dt = Queryds(command)

            Return dt
        End Function
        'get_debtor_margin_all_for_Change
        Public Function get_debtor_margin_all_for_Change(bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_margin_all_for_Change] @budgetyear= " & bgyear
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_debtor_margin_Cash_all(bgyear As Integer, bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_margin_Cash_all] @budgetyear= " & bgyear & ", @BUDGET_USE_ID=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        'get_margin_withdraw_cash
        Public Function get_margin_withdraw_cash(bgyear As Integer, bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_margin_withdraw_cash] @BUDGET_YEAR= " & bgyear & ", @bguse=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        'get_margin_withdraw_check
        Public Function get_margin_withdraw_check(bgyear As Integer, bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_margin_withdraw_check] @BUDGET_YEAR= " & bgyear & ", @bguse=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        Public Function getGF_cure_study(bgyear As Integer, btype As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_cure_study] @BILL_TYPE_ID= " & btype & ", @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function getGF_cure_study_v2(bgyear As Integer, btype As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_cure_study_v2] @BILL_TYPE_ID= " & btype & ", @BUDGET_YEAR=" & bgyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        'getGF_home
        Public Function getGF_home(bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_home]  @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)

            Return dt
        End Function
        'getGF_Other
        Public Function getGF_Other(bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_Other]  @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)

            Return dt
        End Function
        Public Function getMaxBillID() As Integer
            Dim dt As New DataTable
            Dim value As Integer = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[getMaxBillID] "
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                value = CInt(dt(0)("maxid"))
            End If

            Return value
        End Function

        Public Function getApprove_BUDGET_BILL_by_bg_use(ByVal budgetuse As Integer, bgyear As Integer, po As String, ByVal bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_BUDGET_BILL_by_bg_use] @BUDGET_USE_ID = " & budgetuse & ", @BudgetYear=" & bgyear & ", @IS_PO='" & po & "' ,@BUDGET_PLAN_ID =" & bgid
            dt = Queryds(command)

            Return dt
        End Function
        'getApprove_BILL_Supportdept
        Public Function getApprove_BILL_Supportdept(ByVal budgetuse As Integer, bgyear As Integer, ByVal bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_BILL_Supportdept] @BUDGET_USE_ID = " & budgetuse & ", @BudgetYear=" & bgyear & " ,@BUDGET_PLAN_ID =" & bgid
            dt = Queryds(command)

            Return dt
        End Function

        Public Function getApprove_BUDGET_BILL_PO_HEAD(ByVal budgetuse As Integer, bgyear As Integer, ByVal bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_BUDGET_BILL_PO_HEAD] @BUDGET_USE_ID = " & budgetuse & ", @BudgetYear=" & bgyear & ", @BUDGET_PLAN_ID=" & bgid
            dt = Queryds(command)

            Return dt
        End Function
        'getApprove_BUDGET_BILL_Dept_PO_HEAD
        Public Function getApprove_BUDGET_BILL_Dept_PO_HEAD(ByVal budgetuse As Integer, bgyear As Integer, ByVal bgid As Integer, paylist As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_BUDGET_BILL_Dept_PO_HEAD] @BUDGET_USE_ID = " & budgetuse & ", @BudgetYear=" & bgyear & ", @BUDGET_PLAN_ID=" & bgid & ", @PATLIST_ID=" & paylist
            dt = Queryds(command)

            Return dt
        End Function
        'getApprove_Status_Bill
        Public Function getApprove_Status_Bill(ByVal bill_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_Status_Bill] @bill_id = " & bill_id
            dt = Queryds(command)

            Return dt
        End Function
        'getApprove_BUDGET_BILL_sub_PO
        Public Function getApprove_BUDGET_BILL_sub_PO(ByVal budgetuse As Integer, bgyear As Integer, ByVal bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_BUDGET_BILL_sub_PO] @BUDGET_USE_ID = " & budgetuse & ", @BudgetYear=" & bgyear & ", @BUDGET_PLAN_ID=" & bgid
            dt = Queryds(command)

            Return dt
        End Function
        'getApprove_BUDGET_BILL_Dept_sub_PO
        Public Function getApprove_BUDGET_BILL_Dept_sub_PO(ByVal budgetuse As Integer, bgyear As Integer, ByVal bgid As Integer, paylist As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_BUDGET_BILL_Dept_sub_PO] @BUDGET_USE_ID = " & budgetuse & ", @BudgetYear=" & bgyear & ", @BUDGET_PLAN_ID=" & bgid & ", @PATLIST_ID=" & paylist
            dt = Queryds(command)

            Return dt
        End Function


        Public Function getApprove_cure_study_bill_cancel(ByVal billtype As Integer, bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_cure_study_bill_cancel] @BILL_TYPE_ID = " & billtype & ", @BudgetYear=" & bgyear
            dt = Queryds(command)

            Return dt
        End Function

        Public Function getApprove_cure_study_bill_ok(ByVal billtype As Integer, bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_cure_study_bill_ok] @BILL_TYPE_ID = " & billtype & ", @BudgetYear=" & bgyear
            dt = Queryds(command)

            Return dt
        End Function
        'getApprove_other_bill_ok
        Public Function getApprove_other_bill_ok(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_other_bill_ok]  @BudgetYear=" & bgyear
            dt = Queryds(command)

            Return dt
        End Function
        'get_dis_home_App_OK
        Public Function get_dis_home_App_OK(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_dis_home_App_OK]  @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)

            Return dt
        End Function

        Public Function getApprove_rebill(ByVal budgetuse As Integer, bgyear As Integer, bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_rebill] @BUDGET_USE_ID = " & budgetuse & ", @BudgetYear=" & bgyear & ",  @BUDGET_PLAN_ID=" & bgid
            dt = Queryds(command)

            Return dt
        End Function
        'getApprove_no_rebill
        Public Function getApprove_no_rebill(ByVal budgetuse As Integer, bgyear As Integer, bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_no_rebill] @BUDGET_USE_ID = " & budgetuse & ", @BudgetYear=" & bgyear & ",  @BUDGET_PLAN_ID=" & bgid
            dt = Queryds(command)

            Return dt
        End Function
        'getApprove_margin_move
        Public Function getApprove_margin_move(ByVal budgetuse As Integer, bgyear As Integer, bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_margin_move] @BUDGET_USE_ID = " & budgetuse & ", @BudgetYear=" & bgyear & ",  @BUDGET_PLAN_ID=" & bgid
            dt = Queryds(command)

            Return dt
        End Function
        Public Function getApprove_rebill_Cancel(ByVal budgetuse As Integer, bgyear As Integer, bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_rebill_Cancel] @BUDGET_USE_ID = " & budgetuse & ", @BudgetYear=" & bgyear & ",  @BUDGET_PLAN_ID=" & bgid
            dt = Queryds(command)

            Return dt
        End Function
        Public Function getApprove_budget_margin(ByVal budgetuse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_budget_margin] @BUDGET_USE_ID = " & budgetuse
            dt = Queryds(command)

            Return dt
        End Function
        Public Function getApp_cancel_BUDGET_Margin_by_bg_use(ByVal budgetuse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApp_cancel_BUDGET_Margin_by_bg_use] @BUDGET_USE_ID = " & budgetuse
            dt = Queryds(command)

            Return dt
        End Function
        Public Function getApp_cancel_BUDGET_BILL_by_bg_use(ByVal budgetuse As Integer, bgyear As Integer, bgid As Integer, po As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApp_cancel_BUDGET_BILL_by_bg_use] @BUDGET_USE_ID = " & budgetuse & " , @BUDGET_YEAR = " & bgyear & ", @BUDGET_PLAN_ID=" & bgid & ",@IS_PO =" & po
            dt = Queryds(command)

            Return dt
        End Function

        Public Function getGF_bg_bill(ByVal budgetuse As Integer, ByVal budgetyear As Integer, po As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_bg_bill] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ", @IS_PO=" & po
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function getGF_bg_bill_bt_group(ByVal budgetuse As Integer, ByVal budgetyear As Integer, po As String, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_bg_bill_bt_group] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ", @IS_PO=" & po _
                 & ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function getGF_bg_bill_bt_group_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, po As String, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_bg_bill_bt_group_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ", @IS_PO=" & po _
                 & ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function getGF_bg_bill_bt_group_rebill(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_bg_bill_bt_group_rebill] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear _
                 & ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function getGF_bg_bill_bt_group_rebill_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_bg_bill_bt_group_rebill_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear _
                 & ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function getGF_bg_bill_bt_group_no_rebill(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_bg_bill_bt_group_no_rebill] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear _
                 & ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        'getGF_bg_bill_sub_PO
        Public Function getGF_bg_bill_sub_PO(ByVal budgetuse As Integer, ByVal budgetyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_bg_bill_sub_PO] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function getGF_bg_bill_sub_PO_bt_group(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_bg_bill_sub_PO_bt_group] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear _
                 & ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function getGF_bg_bill_sub_PO_bt_group_v2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_bg_bill_sub_PO_bt_group_v2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear _
                 & ",@stat=" & stat & ",@bt=" & bt & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_add_deeka_number_po(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_add_deeka_number_po] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_add_deeka_number_po_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_add_deeka_number_po_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_paydirect_transfer(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_paydirect_transfer] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_paydirect_transfer_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_paydirect_transfer_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_cure_study_transfer(ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bill_type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_cure_study_transfer] @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g & ",@bill_type=" & bill_type
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_paydirect_transfer_rebill(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_paydirect_transfer_rebill] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_paydirect_transfer_rebill_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_paydirect_transfer_rebill_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_paydirect_transfer_no_rebill(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_paydirect_transfer_no_rebill] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_paydirect_transfer_po(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_paydirect_transfer_po] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_paydirect_transfer_po_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_paydirect_transfer_po_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_debtor_bill_by_stat_group(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal debtor As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_bill_by_stat_group] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g & " ,@debtor_type=" & debtor
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_add_deeka_number(ByVal budgetuse As Integer, ByVal budgetyear As Integer, po As String, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_add_deeka_number] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ", @IS_PO='" & po & "'" & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_add_deeka_number_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, po As String, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_add_deeka_number_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ", @IS_PO='" & po & "'" & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_cure_study_add_deeka_number_V2(ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bill_type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_cure_study_add_deeka_number_V2] @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g & ",@BILL_TYPE_ID=" & bill_type
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_add_deeka_number_rebill(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_add_deeka_number_rebill] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_add_deeka_number_rebill_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_add_deeka_number_rebill_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_add_deeka_number_no_rebill(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_add_deeka_number_no_rebill] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_paydirect_receipt(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_paydirect_receipt] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_paydirect_receipt_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_paydirect_receipt_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_paydirect_receipt_po(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_paydirect_receipt_po] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_paydirect_receipt_po_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_paydirect_receipt_po_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_paydirect_invoice_po(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_paydirect_invoice_po] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_paydirect_invoice_po_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_paydirect_invoice_po_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_paydirect_invoice(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_paydirect_invoice] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_paydirect_invoice_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_paydirect_invoice_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_paydipass_check_number(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_paydipass_check_number] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_paydipass_check_number_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_paydipass_check_number_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_paydipass_check_number_V3(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_paydipass_check_number_V3] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_cure_study_check_number(ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bill_type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_cure_study_check_number] @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g & ",@bill_type=" & bill_type
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_rebill_check_number(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_rebill_check_number] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_rebill_check_number_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_rebill_check_number_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_norebill_check_number(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_norebill_check_number] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_check_sign(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_check_sign] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_check_sign_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_check_sign_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_check_sign_V3(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_check_sign_V3] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_check_sign_rebill(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_check_sign_rebill] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_check_sign_rebill_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_check_sign_rebill_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_check_sign_norebill(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_check_sign_norebill] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_check_ready(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_check_ready] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_check_ready_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_check_ready_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_check_ready_V3(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_check_ready_V3] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_check_ready_rebill(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_check_ready_rebill] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_check_ready_rebill_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_check_ready_rebill_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_check_ready_no_rebill(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_check_ready_no_rebill] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_check_pay(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_check_pay] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_check_pay_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_check_pay_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_check_pay_V3(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_check_pay_V3] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_check_pay_rebill(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_check_pay_rebill] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_check_pay_rebill_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_check_pay_rebill_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_check_pay_no_rebill(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_check_pay_no_rebill] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_PM_Unlock(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_PM_Unlock] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_bill_PM_Unlock_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_PM_Unlock_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_rebill_PM_Unlock(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_rebill_PM_Unlock] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_rebill_PM_Unlock_V2(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_rebill_PM_Unlock_V2] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_no_rebill_PM_Unlock(ByVal budgetuse As Integer, ByVal budgetyear As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_no_rebill_PM_Unlock] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function getGF_rebill_K(ByVal budgetuse As Integer, ByVal budgetyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_rebill_K] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear
            dt = Queryds(command)

            Return dt
        End Function
        'getGF_no_rebill_K
        Public Function getGF_no_rebill_K(ByVal budgetuse As Integer, ByVal budgetyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_no_rebill_K] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear
            dt = Queryds(command)

            Return dt
        End Function
        'getGF_margin_move_K
        Public Function getGF_margin_move_K(ByVal budgetuse As Integer, ByVal budgetyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_margin_move_K] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear
            dt = Queryds(command)

            Return dt
        End Function
        Public Function getGF_bg_bill_debtor(ByVal budgetyear As Integer, ByVal bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_bg_bill_debtor]  @BUDGET_YEAR = " & budgetyear & " ,@BUDGET_USE_ID=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function getGF_bg_bill_debtor_bt_group(ByVal budgetyear As Integer, ByVal bguse As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_bg_bill_debtor_bt_group]  @BUDGET_YEAR = " & budgetyear & " ,@BUDGET_USE_ID=" & bguse & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function

        Public Function getGF_bg_bill_debtor_bt_group_v2(ByVal budgetyear As Integer, ByVal bguse As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_bg_bill_debtor_bt_group_v2]  @BUDGET_YEAR = " & budgetyear & " ,@BUDGET_USE_ID=" & bguse & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_Debtor_Deeka_Number(ByVal budgetyear As Integer, ByVal bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Debtor_Deeka_Number]  @BUDGET_YEAR = " & budgetyear & " ,@BUDGET_USE_ID=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_Debtor_Deeka_Number_bt_group(ByVal budgetyear As Integer, ByVal bguse As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Debtor_Deeka_Number_bt_group]  @BUDGET_YEAR = " & budgetyear & " ,@BUDGET_USE_ID=" & bguse & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function getGF_bg_bill_Margin(ByVal budgetuse As Integer, ByVal budgetyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getGF_bg_bill_Margin] @BUDGET_USE_ID = " & budgetuse & ", @BUDGET_YEAR = " & budgetyear
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_bill_to_margin() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_to_margin] "
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_debtor_to_margin(bguse As Integer, express_type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_to_margin] @BUDGET_USE_ID=" & bguse & " , @EXPRESS_TYPE_ID=" & express_type
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_debtor_rebill(bgyear As Integer, bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_rebill] @BUDGET_YEAR= " & bgyear & ",@budgetuse=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_Invoice(ByVal budgetuse As Integer, ByVal pay_type_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Invoice] @BUDGET_USE_ID = " & budgetuse & " , @PAY_TYPE_ID= " & pay_type_id
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_Tax(ByVal budgetuse As Integer, ByVal pay_type_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Tax] @BUDGET_USE_ID = " & budgetuse & " , @PAY_TYPE_ID= " & pay_type_id
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_REFERENCE(ByVal budgetuse As Integer, ByVal pay_type_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_REFERENCE] @BUDGET_USE_ID = " & budgetuse & " , @PAY_TYPE_ID= " & pay_type_id
            dt = Queryds(command)

            Return dt
        End Function

        Public Function getApprove_Debtor_bill(bgyear As Integer, bgUse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_Debtor_bill] @BUDGET_YEAR= " & bgyear & ", @BUDGET_USE_ID=" & bgUse
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function getApprove_Debtor_bill_bt_group(bgyear As Integer, bgUse As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_Debtor_bill_bt_group] @BUDGET_YEAR= " & bgyear & ", @BUDGET_USE_ID=" & bgUse & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function getApprove_Debtor_bill_bt_group_v2(bgyear As Integer, bgUse As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_Debtor_bill_bt_group_v2] @BUDGET_YEAR= " & bgyear & ", @BUDGET_USE_ID=" & bgUse & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        Public Function getApprove_Debtor_bill_out(bgyear As Integer, bgUse As Integer, ByVal bgid As Integer, ByVal dept As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_Debtor_bill_out] @BUDGET_YEAR= " & bgyear & ", @BUDGET_USE_ID=" & bgUse & ",@BUDGET_PLAN_ID=" & bgid & ",@DEPARTMENT_ID=" & dept
            dt = Queryds(command)

            Return dt
        End Function
        Public Function getApprove_Debtor_bill_out2(bgyear As Integer, bgUse As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_Debtor_bill_out2] @BUDGET_YEAR= " & bgyear & ", @BUDGET_USE_ID=" & bgUse & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)

            Return dt
        End Function
        'getApprove_Debtor_bill_sup_det
        Public Function getApprove_Debtor_bill_sup_det(bgyear As Integer, sub_bg As Integer, ByVal bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_Debtor_bill_sup_det] @BUDGET_YEAR= " & bgyear & ", @PAYLIST_ID=" & sub_bg & ",@BUDGET_PLAN_ID=" & bgid
            dt = Queryds(command)

            Return dt
        End Function
        Public Function getApprove_Cancel_Debtor_bill(bgyear As Integer, bgUse As Integer, ByVal bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_Cancel_Debtor_bill] @BUDGET_YEAR= " & bgyear & ", @BUDGET_USE_ID=" & bgUse & ", @BUDGET_PLAN_ID=" & bgid
            dt = Queryds(command)

            Return dt
        End Function
        'getApprove_Cancel_Debtor_bill_out
        Public Function getApprove_Cancel_Debtor_bill_out(bgyear As Integer, bgUse As Integer, ByVal bgid As Integer, ByVal dept As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_Cancel_Debtor_bill_out] @BUDGET_YEAR= " & bgyear & ", @BUDGET_USE_ID=" & bgUse & ", @BUDGET_PLAN_ID=" & bgid & ", @DEPARTMENT_ID=" & dept
            dt = Queryds(command)

            Return dt
        End Function
        'getApprove_Cancel_Debtor_bill_out2
        Public Function getApprove_Cancel_Debtor_bill_out2(bgyear As Integer, bgUse As Integer, ByVal bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_Cancel_Debtor_bill_out2] @BUDGET_YEAR= " & bgyear & ", @BUDGET_USE_ID=" & bgUse & ", @BUDGET_PLAN_ID=" & bgid
            dt = Queryds(command)

            Return dt
        End Function
        'getApprove_Cancel_Debtor_bill_sup_dept
        Public Function getApprove_Cancel_Debtor_bill_sup_dept(bgyear As Integer, sub_bg As Integer, ByVal bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[getApprove_Cancel_Debtor_bill_sup_dept] @BUDGET_YEAR= " & bgyear & ", @PAYLIST_ID=" & sub_bg & ", @BUDGET_PLAN_ID=" & bgid
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_PO_from_bg_bill(bgyear As Integer, bgid As Integer, bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_PO_from_bg_bill] @BUDGET_YEAR= " & bgyear & ",@BUDGET_PLAN_ID=" & bgid & ",@BUDGET_USE_ID=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        'get_PO_Prepare_add_number
        Public Function get_PO_Prepare_add_number(bgyear As Integer, dept As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_PO_Prepare_add_number] @BUDGET_YEAR= " & bgyear & ",@DEPARTMENT_ID=" & dept
            dt = Queryds(command)

            Return dt
        End Function
        'get_PO_Number
        Public Function get_PO_Number(ByVal bid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_PO_Number] @BUDGET_DISBURSE_BILL_ID= " & bid
            dt = Queryds(command)

            Return dt
        End Function
        'get_Support_PO_from_bg_bill
        Public Function get_Support_PO_from_bg_bill(bgyear As Integer, bgid As Integer, bguse As Integer, ByVal paylist As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Support_PO_from_bg_bill] @BUDGET_YEAR= " & bgyear & ",@BUDGET_PLAN_ID=" & bgid & ",@BUDGET_USE_ID=" & bguse & ", @PATLIST_ID=" & paylist
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_Support_PO_from_bg_bill_V2(bgyear As Integer, bgUse As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer, ByVal dept As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Support_PO_from_bg_bill_V2] @BUDGET_YEAR= " & bgyear & ", @BUDGET_USE_ID=" & bgUse & ",@stat=" & stat & ",@g=" & g & ", @bt=" & bt & ",@dept=" & dept
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_Support_PO_from_bg_bill_V2_byRelateId(bgyear As Integer, bgUse As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bt As Integer, ByVal dept As Integer, ByVal relateId As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Support_PO_from_bg_bill_V2_byRelateId] @BUDGET_YEAR= " & bgyear & ", @BUDGET_USE_ID=" & bgUse & ",@stat=" & stat & ",@g=" & g & ", @bt=" & bt & ",@dept=" & dept & ",@Relate_id=" & relateId
            dt = Queryds(command)

            Return dt
        End Function


        Public Function get_node_7(child As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_node_7] @BUDGET_CHILD_ID= " & child
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_PO_Procure(bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_PO_Procure] @BUDGET_YEAR= " & bgyear
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_Intranet() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Intranet] "
            dt = Queryds(command)

            Return dt
        End Function
        'get_Intranet_debtor_over_deadline

        Public Function get_Intranet_debtor_over_deadline() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Intranet_debtor_over_deadline] "
            dt = Queryds(command)

            Return dt
        End Function
        'get_DEBTOR_BILL_add_k_List
        Public Function get_DEBTOR_BILL_add_k_List(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_DEBTOR_BILL_add_k_List] @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_debtor_No_app_list(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_No_app_list] @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_debtor_app_list(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_app_list] @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_debtor_all_list(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_all_list] @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)

            Return dt
        End Function
        'get_bill_all_mainpage
        Public Function get_bill_all_mainpage(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_all_mainpage] @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_app_mainpage(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_app_mainpage] @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bill_no_app_mainpage(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_no_app_mainpage] @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_debtor_all_count(ByVal bgyear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_all_count] @BUDGET_YEAR= " & bgyear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("c_num")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("c_num"))
                End If
            End If

            Return value
        End Function
        Public Function get_bill_app_count_mainpage(ByVal bgyear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_app_count_mainpage] @BUDGET_YEAR= " & bgyear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("c_num")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("c_num"))
                End If
            End If

            Return value
        End Function
        Public Function get_bill_no_app_count_mainpage(ByVal bgyear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_no_app_count_mainpage] @BUDGET_YEAR= " & bgyear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("c_num")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("c_num"))
                End If
            End If

            Return value
        End Function
        'get_bill_all_count_mainpage
        Public Function get_bill_all_count_mainpage(ByVal bgyear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_all_count_mainpage] @BUDGET_YEAR= " & bgyear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("c_num")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("c_num"))
                End If
            End If

            Return value
        End Function
        'get_debtor_No_app_count
        Public Function get_debtor_No_app_count(ByVal bgyear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_No_app_count] @BUDGET_YEAR= " & bgyear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("c_num")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("c_num"))
                End If
            End If

            Return value
        End Function
        'get_debtor_app_count
        Public Function get_debtor_app_count(ByVal bgyear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_app_count] @BUDGET_YEAR= " & bgyear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("c_num")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("c_num"))
                End If
            End If

            Return value
        End Function
        'get_Intranet_debtor_check_ready_pay

        Public Function get_Intranet_debtor_check_ready_pay() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Intranet_debtor_check_ready_pay] "
            dt = Queryds(command)

            Return dt
        End Function
        'get_Intranet_debtor_cash_ready_pay
        Public Function get_Intranet_debtor_cash_ready_pay() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Intranet_debtor_cash_ready_pay] "
            dt = Queryds(command)

            Return dt
        End Function
        'get_Intranet_bill_check_ready
        Public Function get_Intranet_bill_check_ready() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Intranet_bill_check_ready] "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_PO_Detail(id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_PO_Detail] @BUDGET_DISBURSE_BILL_ID= " & id
            dt = Queryds(command)

            Return dt
        End Function
        'get_Sub_PO
        Public Function get_Sub_PO(ByVal bgid As Integer, ByVal bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Sub_PO] @BUDGET_PLAN_ID= " & bgid & ", @BUDGET_USE_ID=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        'get_Sub_PO_dept
        Public Function get_Sub_PO_dept(ByVal bgid As Integer, ByVal bguse As Integer, ByVal sub_bg As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Sub_PO_dept] @BUDGET_PLAN_ID= " & bgid & ", @BUDGET_USE_ID=" & bguse & ", @PATLIST_ID=" & sub_bg
            dt = Queryds(command)

            Return dt
        End Function

        'get_po_procure_list
        Public Function get_po_procure_list() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_po_procure_list]"
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_money_debtor_in(ByVal debtor_id As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_money_debtor_in] @DEBTOR_BILL_ID= " & debtor_id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("AMOUNT")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("AMOUNT"))
                End If
            End If

            Return value
        End Function
        Public Function get_money_debtor_in_margin(ByVal debtor_id As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_money_debtor_in_margin] @DEBTOR_BILL_ID= " & debtor_id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("AMOUNT")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("AMOUNT"))
                End If
            End If

            Return value
        End Function
        Public Function get_money_debtor_out(ByVal debtor_id As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_money_debtor_out] @DEBTOR_BILL_ID= " & debtor_id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("AMOUNT")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("AMOUNT"))
                End If
            End If

            Return value
        End Function
        'get_sub_po_amount
        Public Function get_sub_po_amount(ByVal po_head_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_sub_po_amount] @PO_HEAD_ID= " & po_head_id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("AMOUNT")) = False Then
                    value = CDbl(dt(0)("AMOUNT"))
                End If
            End If

            Return value
        End Function
        Public Function get_debtor_move() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_move]"
            dt = Queryds(command)

            Return dt
        End Function
        'get_Approve_debtor_return_money
        Public Function get_Approve_debtor_return_money(ByVal bgyear As Integer, ByVal bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Approve_debtor_return_money] @BUDGET_YEAR= " & bgyear & " , @BUDGET_PLAN_ID =" & bgid
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_Approve_debtor_return_money_support(ByVal bgyear As Integer, ByVal bgid As Integer, ByVal paylist As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Approve_debtor_return_money_support] @BUDGET_YEAR= " & bgyear & " , @BUDGET_PLAN_ID =" & bgid & ",@PATLIST_ID=" & paylist
            dt = Queryds(command)

            Return dt
        End Function
        'get_Approve_outdebtor_return_money
        Public Function get_Approve_outdebtor_return_money(ByVal bgyear As Integer, ByVal bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Approve_outdebtor_return_money] @BUDGET_YEAR= " & bgyear & " , @BUDGET_PLAN_ID =" & bgid
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_margin_pay_withdraw(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_margin_pay_withdraw] @BUDGET_YEAR= " & bgyear
            dt = Queryds(command)
            Return dt
        End Function

        Public Function get_debtor_by_doc_number(ByVal doc_num As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_by_doc_number] @DOC_NUMBER = '" & doc_num & "' ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_debtor_Return_doc_number(ByVal doc_num As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_Return_doc_number] @DOC_NUMBER = '" & doc_num & "' , @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        'get_debtor_by_cus_name
        Public Function get_debtor_by_cus_name(ByVal cus_name As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_by_cus_name] @cus_name = '" & cus_name & "',@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        'get_debtor_by_k_number
        Public Function get_debtor_by_k_number(ByVal k_number As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_by_k_number] @GFMIS_NUMBER = '" & k_number & "',@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_debtor_by_c_num(ByVal k_number As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_by_c_num] @CHECK_NUMBER = '" & k_number & "',@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        'get_return_by_cus_name
        Public Function get_return_by_cus_name(ByVal cus_name As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_return_by_cus_name] @cus_name = '" & cus_name & "' , @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        ' get_debtor_by_Amount_Equal
        Public Function get_debtor_by_Amount_Equal(ByVal amount As Double, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_by_Amount_Equal] @Amount =" & amount & " ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_return_by_Amount_Equal(ByVal amount As Double, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_return_by_Amount_Equal] @Amount =" & amount & " , @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        'get_debtor_by_Amount_Less_than
        Public Function get_debtor_by_Amount_Less_than(ByVal amount As Double, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_by_Amount_Less_than] @Amount =" & amount & " ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_return_by_Amount_Less_than(ByVal amount As Double, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_return_by_Amount_Less_than] @Amount =" & amount & " , @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        'get_debtor_by_Amount_More_than
        Public Function get_debtor_by_Amount_More_than(ByVal amount As Double, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_by_Amount_More_than] @Amount =" & amount & " ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_return_by_Amount_More_than(ByVal amount As Double, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_return_by_Amount_More_than] @Amount =" & amount & " , @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_debtor_by_bill_number(ByVal bill_num As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_by_bill_number] @BILL_NUMBER = '" & bill_num & "' ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_debtor_Return_bill_number(ByVal bill_num As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_Return_bill_number] @BILL_NUMBER = '" & bill_num & "' , @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_bill_by_bill_number(ByVal bill_num As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_by_bill_number] @BILL_NUMBER = '" & bill_num & "' ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_bill_by_doc_number(ByVal doc_num As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_by_doc_number] @DOC_NUMBER = '" & doc_num & "' ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        'get_bill_by_cus_name
        Public Function get_bill_by_cus_name(ByVal cus_name As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_by_cus_name] @cus_name = '" & cus_name & "' ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        'get_bill_by_k_number
        Public Function get_bill_by_k_number(ByVal k_number As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_by_k_number] @GFMIS_NUMBER = '" & k_number & "' ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        'get_bill_by_c_number
        Public Function get_bill_by_c_number(ByVal k_number As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_by_c_number] @CHECK_NUMBER = '" & k_number & "' ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        'get_bill_by_Amount_Equal
        Public Function get_bill_by_Amount_Equal(ByVal amount As Double, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_by_Amount_Equal] @Amount = " & amount & " ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        ' get_bill_by_Amount_More_Than
        Public Function get_bill_by_Amount_More_Than(ByVal amount As Double, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_by_Amount_More_Than] @Amount = " & amount & " ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        'get_bill_by_Amount_Less_Than
        Public Function get_bill_by_Amount_Less_Than(ByVal amount As Double, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_by_Amount_Less_Than] @Amount = " & amount & " ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_bill_po_by_bill_number(ByVal bill_num As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_po_by_bill_number] @BILL_NUMBER = '" & bill_num & "' ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function

        Public Function get_bill_po_by_doc_number(ByVal doc_num As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_po_by_doc_number] @DOC_NUMBER = '" & doc_num & "' ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        'get_bill_po_by_cus_name
        Public Function get_bill_po_by_cus_name(ByVal cus_name As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_po_by_cus_name] @cus_name = '" & cus_name & "' ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        'get_bill_po_by_k_number
        Public Function get_bill_po_by_k_number(ByVal k_number As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_po_by_k_number] @GFMIS_NUMBER = '" & k_number & "' ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        'get_bill_po_by_c_number
        Public Function get_bill_po_by_c_number(ByVal k_number As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_po_by_c_number] @CHECK_NUMBER = '" & k_number & "' ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        'get_bill_po_by_Amount_Equal
        Public Function get_bill_po_by_Amount_Equal(ByVal amount As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_po_by_Amount_Equal] @Amount =" & amount & " ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        'get_bill_po_by_Amount_More_Than
        Public Function get_bill_po_by_Amount_More_Than(ByVal amount As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_po_by_Amount_More_Than] @Amount =" & amount & " ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        'get_bill_po_by_Amount_Less_Than
        Public Function get_bill_po_by_Amount_Less_Than(ByVal amount As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_po_by_Amount_Less_Than] @Amount =" & amount & " ,@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_transfer_outside_amount(ByVal bgid As Integer, bgyear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_transfer_outside_amount] @BUDGET_PLAN_ID = " & bgid & " , @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("t_amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("t_amount"))
                End If
            End If

            Return value
        End Function
        'get_transfer_diff
        Public Function get_transfer_diff(ByVal bgid As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_transfer_diff] @BUDGET_PLAN_ID = " & bgid
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("diff")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("diff"))
                End If
            End If

            Return value
        End Function
        'get_debtor_Cancel
        Public Function get_debtor_Cancel(ByVal bgYear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_Cancel] @BUDGET_YEAR = " & bgYear
            dt = Queryds(command)
            Return dt

        End Function
        'get_debtor_cancel_stat
        Public Function get_debtor_cancel_stat(ByVal bgYear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_cancel_stat] @BUDGET_YEAR = " & bgYear
            dt = Queryds(command)
            Return dt

        End Function
        ''get_debtor_amount
        Public Function get_debtor_amount(ByVal debtor_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_amount] @DEBTOR_BILL_ID = " & debtor_id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("AMOUNT")) = False Then
                    value = dt(0)("AMOUNT")
                End If
            End If

            Return value

        End Function
        'get_multi_bill_add
        Public Function get_multi_bill_add(ByVal main_bill As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_multi_bill_add] @MAIN_BILL= " & main_bill
            dt = Queryds(command)
            Return dt

        End Function
        'get_dis_amount_all_multi_bill
        Public Function get_dis_amount_all_multi_bill(ByVal bid As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_dis_amount_all_multi_bill] @MAIN_BILL = " & bid
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("AMOUNT")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("AMOUNT"))
                End If
            End If

            Return value
        End Function

        'get_bill_history
        Public Function get_bill_history(ByVal bgyear As Integer, ByVal cus_id As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bill_history] @BUDGET_YEAR= " & bgyear & ", @CUSTOMER_ID= '" & cus_id & "'"
            dt = Queryds(command)
            Return dt

        End Function
        'get_debtor_history
        Public Function get_debtor_history(ByVal bgyear As Integer, ByVal user_id As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_history] @BUDGET_YEAR= " & bgyear & ", @USER_ID= '" & user_id & "'"
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_debt_deadline(ByVal bgYear As Integer) As Integer
            Dim dt As New DataTable
            Dim key As Integer = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debt_deadline] @BUDGET_YEAR=" & bgYear
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("debt_deadline")) = False Then
                    key = dt(0)("debt_deadline")
                End If
            End If

            Return key
        End Function
        'get_debt_deadline_margin
        Public Function get_debt_deadline_margin(ByVal bgYear As Integer) As Integer
            Dim dt As New DataTable
            Dim key As Integer = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debt_deadline_margin] @BUDGET_YEAR=" & bgYear
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("debt_deadline")) = False Then
                    key = dt(0)("debt_deadline")
                End If
            End If

            Return key
        End Function
        'get_old_balance_no_app
        Public Function get_old_balance_no_app(ByVal bgid As Integer, ByVal bgyear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_old_balance_no_app] @BUDGET_PLAN_ID = " & bgid & ",@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("amount"))
                End If
            End If

            Return value
        End Function
        'get_old_balance_no_app_year
        Public Function get_old_balance_no_app_year(ByVal bgid As Integer, ByVal bgyear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_old_balance_no_app_year] @BUDGET_PLAN_ID = " & bgid & ",@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("amount"))
                End If
            End If

            Return value
        End Function
        Public Function get_dis_outbudget_no_app(ByVal bgid As Integer, ByVal bgyear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_dis_outbudget_no_app] @BUDGET_PLAN_ID = " & bgid & ",@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("amount"))
                End If
            End If

            Return value
        End Function
        'get_dis_outbudget_no_app_year
        Public Function get_dis_outbudget_no_app_year(ByVal bgid As Integer, ByVal bgyear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_dis_outbudget_no_app_year] @BUDGET_PLAN_ID = " & bgid & ",@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("amount"))
                End If
            End If

            Return value
        End Function
        Public Function get_dis_outbudget_app(ByVal bgid As Integer, ByVal bgyear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_dis_outbudget_app] @BUDGET_PLAN_ID = " & bgid & ",@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("amount"))
                End If
            End If

            Return value
        End Function
        'get_dis_outbudget_app_year
        Public Function get_dis_outbudget_app_year(ByVal bgid As Integer, ByVal bgyear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_dis_outbudget_app_year] @BUDGET_PLAN_ID = " & bgid & ",@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("amount"))
                End If
            End If

            Return value
        End Function
        'get_receive_all
        Public Function get_receive_all(ByVal bgid As Integer, ByVal bgyear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_receive_all] @BUDGET_PLAN_ID = " & bgid & ",@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("amount"))
                End If
            End If

            Return value
        End Function
        'get_receive_all_year
        Public Function get_receive_all_year(ByVal bgid As Integer, ByVal bgyear As Integer) As Double
            Dim value As Double = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_receive_all_year] @BUDGET_PLAN_ID = " & bgid & ",@BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("amount")) Then
                    value = 0
                Else
                    value = CDbl(dt(0)("amount"))
                End If
            End If

            Return value
        End Function
        Public Function get_max_bill(ByVal bgyear As Integer, ByVal bguse As Integer) As Integer
            Dim value As Integer = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_max_bill] @BUDGET_YEAR=" & bgyear & " ,@BUDGET_USE_ID=" & bguse
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bill_max")) Then
                    value = 0
                Else
                    value = CInt(dt(0)("bill_max"))
                End If
            End If

            Return value
        End Function
        'get_max_debtor
        Public Function get_max_debtor(ByVal bgyear As Integer, ByVal bguse As Integer) As Integer
            Dim value As Integer = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_max_debtor] @BUDGET_YEAR=" & bgyear & " ,@BUDGET_USE_ID=" & bguse
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bill_max")) Then
                    value = 0
                Else
                    value = CInt(dt(0)("bill_max"))
                End If
            End If

            Return value
        End Function
        Public Function get_max_bill_cure_study(ByVal bgyear As Integer) As Integer
            Dim value As Integer = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_max_bill_cure_study] @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bill_max")) Then
                    value = 0
                Else
                    value = CInt(dt(0)("bill_max"))
                End If
            End If

            Return value
        End Function
        Public Function get_debtor_max_bill(ByVal bgyear As Integer) As Integer
            Dim value As Integer = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_max_bill] @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bill_max")) Then
                    value = 0
                Else
                    value = CInt(dt(0)("bill_max"))
                End If
            End If

            Return value
        End Function
        Public Function get_checker_list(ByVal bgyear As Integer, ByVal bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_checker_list] @BUDGET_YEAR= " & bgyear & ",@BUDGET_USE_ID=" & bguse
            dt = Queryds(command)
            Return dt

        End Function

        Public Function get_boss_approve(ByVal bgyear As Integer, ByVal bguse As Integer, ByVal ispo As String, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_boss_approve] @BUDGET_YEAR= " & bgyear & ",@BUDGET_USE_ID=" & bguse & ",@IS_PO='" & ispo & "' ,@stat=" & stat & ",@g=" & g
            dt = Queryds(command)
            Return dt

        End Function
        '
        Public Function get_boss_approve_V2(ByVal bgyear As Integer, ByVal bguse As Integer, ByVal ispo As String, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_boss_approve_V2] @BUDGET_YEAR= " & bgyear & ",@BUDGET_USE_ID=" & bguse & ",@IS_PO='" & ispo & "' ,@stat=" & stat & ",@g=" & g
            dt = Queryds(command)
            Return dt

        End Function
        '
        Public Function get_cure_study_boss_approve_V2(ByVal bgyear As Integer, ByVal stat As Integer, ByVal g As Integer, ByVal bill_type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_cure_study_boss_approve_V2] @BUDGET_YEAR= " & bgyear & " ,@stat=" & stat & ",@g=" & g & ",@BILL_TYPE_ID=" & bill_type
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_boss_approve_rebill(ByVal bgyear As Integer, ByVal bguse As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_boss_approve_rebill] @BUDGET_YEAR= " & bgyear & ",@BUDGET_USE_ID=" & bguse & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)
            Return dt

        End Function
        '
        Public Function get_boss_approve_rebill_V2(ByVal bgyear As Integer, ByVal bguse As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_boss_approve_rebill_V2] @BUDGET_YEAR= " & bgyear & ",@BUDGET_USE_ID=" & bguse & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)
            Return dt

        End Function
        '
        Public Function get_boss_approve_no_rebill_V2(ByVal bgyear As Integer, ByVal bguse As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_boss_approve_no_rebill_V2] @BUDGET_YEAR= " & bgyear & ",@BUDGET_USE_ID=" & bguse & ",@stat=" & stat & ",@g=" & g
            dt = Queryds(command)
            Return dt

        End Function
        Public Function get_boss_approve_debtor(ByVal bgyear As Integer, ByVal bguse As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_boss_approve_debtor] @BUDGET_YEAR= " & bgyear & ",@BUDGET_USE_ID=" & bguse & " ,@stat=" & stat & ",@g=" & g
            dt = Queryds(command)
            Return dt

        End Function
        '
        Public Function get_boss_approve_debtorv2(ByVal bgyear As Integer, ByVal bguse As Integer, ByVal stat As Integer, ByVal g As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_boss_approve_debtorv2] @BUDGET_YEAR= " & bgyear & ",@BUDGET_USE_ID=" & bguse & " ,@stat=" & stat & ",@g=" & g
            dt = Queryds(command)
            Return dt

        End Function
        '
        Public Function SC_get_relate_det_by_id(ByVal relate_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[SC_get_relate_det_by_id] @RELATE_ID=" & relate_id
            dt = Queryds(command)
            Return dt

        End Function
        '
        Public Function SC_get_relate_det_po_by_id(ByVal relate_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[SC_get_relate_det_po_by_id] @RELATE_ID=" & relate_id
            dt = Queryds(command)
            Return dt

        End Function
        '
        Public Function get_period_ddl(ByVal relate_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_period_ddl] @RELATE_ID=" & relate_id
            dt = Queryds(command)
            Return dt

        End Function
        Public Function SC_get_bill_det_by_id(ByVal bill_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[SC_get_bill_det_by_id] @bill_id=" & bill_id
            dt = Queryds(command)
            Return dt

        End Function
        '
        Public Function SC_get_bill_out_det_by_id(ByVal bill_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[SC_get_bill_out_det_by_id] @bill_id=" & bill_id
            dt = Queryds(command)
            Return dt

        End Function
        '
        Public Function SC_get_debtor_out_det_by_id(ByVal debtor As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[SC_get_debtor_out_det_by_id] @debtor_id=" & debtor
            dt = Queryds(command)
            Return dt

        End Function
        Public Function SP_get_debtor_det_by_id(ByVal debtor_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[SP_get_debtor_det_by_id] @debtor_id=" & debtor_id
            dt = Queryds(command)
            Return dt

        End Function
    End Class
    '
    Public Class Budget
        Inherits DISBURSE_BUDGET

        Public Function get_BUDGET_ADJUST(bg_id As Integer) As DataTable
            Dim dt As New DataTable

            Dim command As String = " "
            command = " exec [BUDGETS].[get_BUDGET_ADJUST] @BUDGET_PLAN_ID =" & bg_id
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_data_ref01() As DataTable
            Dim dt As New DataTable

            Dim command As String = " "
            command = "SELECT h.[ref01] "
            command &= " ,h.[ref02] "
            command &= " FROM [FDA_BG].[dbo].[LOG_PAY_HOST_TO_HOST] h "
            command &= " join [FDA_FEE].[dbo].[fee] f on h.ref01=f.ref01 and h.ref02 = f.ref02 "
            command &= " where [pay_date] >= '2017-11-29 12:26:00:000' and [pay_date] <= '2017-11-29 16:46:00:000'  and dvcd in (3) "
            command &= " group by h.[ref01] "
            command &= " ,h.[ref02] "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_relate_summoney_byFKId(ByVal bg As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_relate_summoney_byFKId] @BUDGET_ID=" & bg
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("SumAmount")) = False Then
                    value = CDbl(dt(0)("SumAmount"))
                Else
                    value = 0.0
                End If
            End If

            Return value
        End Function



        Public Function get_OVERLAP() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_OVERLAP] "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_OVERLAP_APPROVE() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_OVERLAP_APPROVE] "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_Budgetplan() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Budgetplan] "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_dept_name() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " select * from [dbo].[MAS_DEPARTMENT] "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_sum_adjust(bg As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_sum_adjust] @BUDGET_PLAN_ID=" & bg
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("adjust_amount")) = False Then
                    value = CDbl(dt(0)("adjust_amount"))
                Else
                    value = 0.0
                End If
            End If

            Return value
        End Function
        Public Function get_return_approve(ByVal BUDGET_USE_ID As Integer, ByVal PAY_TYPE_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_return_approve] @BUDGET_USE_ID=" & BUDGET_USE_ID & " , @PAY_TYPE_ID= " & PAY_TYPE_ID
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_All_bill_status(ByVal BUDGET_USE_ID As Integer, ByVal PAY_TYPE_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_All_bill_status] @BUDGET_USE_ID=" & BUDGET_USE_ID & " , @PAY_TYPE_ID= " & PAY_TYPE_ID
            dt = Queryds(command)

            Return dt
        End Function
        ''' <summary>
        ''' ดึงข้อมูลผูกพันเงินยืม
        ''' </summary>
        ''' <param name="BUDGET_USE_ID"></param>
        ''' <param name="GFMIS_TYPE_ID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function get_BorrowMoneyBinding(ByVal BUDGET_USE_ID As Integer, ByVal GFMIS_TYPE_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BorrowMoneyBinding] @BUDGET_USE_ID = " & BUDGET_USE_ID & " , @GFMIS_TYPE_ID = " & GFMIS_TYPE_ID
            dt = Queryds(command)

            Return dt
        End Function
        ''' <summary>
        ''' ดึงข้อมูลเบิกจ่ายงบประมาณ
        ''' </summary>
        ''' <param name="BUDGET_USE_ID"></param>
        ''' <param name="GFMIS_TYPE_ID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function get_Disburse_dept(ByVal BUDGET_USE_ID As Integer, ByVal GFMIS_TYPE_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Disburse_dept] @BUDGET_USE_ID = " & BUDGET_USE_ID & " , @GFMIS_TYPE_ID = " & GFMIS_TYPE_ID
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bg_adjust_by_dept(ByVal dept_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bg_adjust_by_dept] @DEPARTMENT_ID = " & dept_id
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bg_adjust_by_dept_year(ByVal dept_id As Integer, ByVal budgetyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bg_adjust_by_dept_year] @DEPARTMENT_ID = " & dept_id & ", @budgetYear= " & budgetyear
            dt = Queryds(command)

            Return dt
        End Function


        Public Function get_bg_adjust_by_dept_year_ProId(ByVal dept_id As Integer, ByVal budgetyear As Integer, ByVal ProCode As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bg_adjust_by_dept_year_ProId] @DEPARTMENT_ID = " & dept_id & ", @budgetYear= " & budgetyear & ",@ProCode='" & ProCode & "'"
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_Transfer_Balance_Net(ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim amount As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Transfer_Balance_Net] @BUDGET_PLAN_ID=" & bg_id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) = False Then
                    amount = CDbl(dt(0)("Amount"))
                End If
            End If

            Return amount
        End Function
        Public Function get_po_head_by_bg(ByVal bgid As Integer, ByVal bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_po_head_by_bg] @BUDGET_PLAN_ID = " & bgid & ", @BUDGET_USE_ID= " & bguse
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bg_adjust_by_year(ByVal budgetyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bg_adjust_by_year] @BUDGET_YEAR = " & budgetyear
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bg_by_year(ByVal budgetyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bg_by_year] @budgetYear= " & budgetyear
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bg_adjust_detail_amount(ByVal budgetyear As Integer, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bg_adjust_detail_amount] @budgetYear= " & budgetyear & " , @bg_id= " & bg_id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                Try
                    value = CDbl(dt(0)("BUDGET_DEPARTMENT_MONEY"))
                Catch ex As Exception

                End Try

            End If


            Return value
        End Function
        Public Function get_outside_dept() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_outside_dept] "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_period_receive(ByVal budgetyear As Integer, ByVal bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_period_receive] @BUDGET_YEAR= " & budgetyear & ", @BUDGET_PLAN_ID=" & bgid
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bg_adjust_receive_period(ByVal budgetyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bg_adjust_receive_period] @BUDGET_YEAR= " & budgetyear
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_project_list(ByVal dept_id As Integer, ByVal budgetyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_project_list] @DEPARTMENT_ID = " & dept_id & ", @budgetYear= " & budgetyear
            dt = Queryds(command)

            Return dt
        End Function
    End Class
    Public Class Maintain
        Inherits DISBURSE_BUDGET
        ''' <summary>
        ''' ตารางการรับเงิน แยกตามปีงบประมาณ
        ''' </summary>
        ''' <param name="bgYear">ปีงบประมาณ</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function get_RECEIVE_MONEY_by_BUDGET_YEAR(ByVal bgYear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_RECEIVE_MONEY_by_BUDGET_YEAR] @BudgetYear = " & bgYear
            dt = Queryds(command)
            Return dt
        End Function
        Public Function GET_send_money_law_normal_all_by_type(ByVal daySelect As Date, ByVal INCOME_IDA As Integer, ByVal RECEIVE_MONEY_TYPE As Integer) As DataTable
            Dim dt As New DataTable
            Dim dayBegin As Integer = convertDateToInteger(daySelect)
            Dim command As String = " "
            command = " exec [BUDGETS].[GET_send_money_law_normal_all_by_type] @daySelect=" & dayBegin & ", @INCOME_IDA=" & INCOME_IDA & ", @RECEIVE_MONEY_TYPE =" & RECEIVE_MONEY_TYPE
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_Data_Send_money_by_Budget_Year_L44(ByVal bgYear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Data_Send_money_by_Budget_Year_L44] @BUDGET_YEAR = " & bgYear
            dt = Queryds(command)
            Return dt
        End Function

        Public Function get_Max_Runno_Send_money_Law_Normal_by_Budget_Year(ByVal bgYear As Integer) As Integer
            Dim dt As New DataTable
            Dim count_no As Integer = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Max_Runno_Send_money_Law_Normal_by_Budget_Year] @BUDGET_YEAR = " & bgYear
            dt = Queryds(command)

            Try
                count_no = dt(0)("runno")
            Catch ex As Exception

            End Try
            Return count_no
        End Function

        Public Function Get_FEE_BY_REF01_AND_REF02(ByVal ref01 As String, ByVal ref02 As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[Get_FEE_BY_REF01_AND_REF02] @ref01='" & ref01 & "' ,@ref02='" & ref02 & "'"
            dt = Queryds(command)
            Return dt
        End Function
        Public Function SP_get_receipt_data_det_feeno_V2_law1(ByVal RECEIVE_MONEY_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[SP_get_receipt_data_det_feeno_V2_law1] @RECEIVE_MONEY_ID=" & RECEIVE_MONEY_ID
            dt = Queryds(command)
            Return dt
        End Function
        Public Function SP_GET_E_RECEIPT_ID(ByVal feeno As Integer, ByVal dvcd As Integer, ByVal feeabbr As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[SP_GET_E_RECEIPT_ID] @feeno=" & feeno & ",@dvcd=" & dvcd & ",@feeabbr='" & feeabbr & "'"
            dt = Queryds(command)
            Return dt
        End Function
        Public Function SP_GET_E_RECEIPT_IDV2(ByVal feeno As Integer, ByVal dvcd As Integer, ByVal feeabbr As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[SP_GET_E_RECEIPT_IDV2] @feeno=" & feeno & ",@dvcd=" & dvcd & ",@feeabbr='" & feeabbr & "'"
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_GET_E_RECEIPT_BY_REF01_REF02(ByVal ref01 As String, ByVal ref02 As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[SP_GET_E_RECEIPT_BY_REF01_REF02] @ref01='" & ref01 & "', @ref02='" & ref02 & "'"
            dt = Queryds(command)
            Return dt
        End Function
        Public Function SP_get_receipt_data_det_feeno_dvcd_feeabbr(ByVal feeno As Integer, ByVal dvcd As Integer, ByVal feeabbr As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[SP_get_receipt_data_det_feeno_dvcd_feeabbr] @feeno=" & feeno & ",@dvcd=" & dvcd & ",@feeabbr='" & feeabbr & "'"
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_get_receipt_data_det_feeno_dvcd_feeabbrV2(ByVal feeno As Integer, ByVal dvcd As Integer, ByVal feeabbr As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[SP_get_receipt_data_det_feeno_dvcd_feeabbrV2] @feeno=" & feeno & ",@dvcd=" & dvcd & ",@feeabbr='" & feeabbr & "'"
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_get_receipt_data_det_feeno_dvcd_feeabbrV3(ByVal ref01 As String, ByVal ref02 As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[SP_get_receipt_data_det_feeno_dvcd_feeabbrV3] @ref01='" & ref01 & "', @ref02='" & ref02 & "'"
            dt = Queryds(command)
            Return dt
        End Function
        Public Function Query_get_data_receipt_data_det_by_id(ByVal ida As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "select r.RECEIVE_MONEY_ID,r.FEENO,r.LCNSID as lcnsid , replace(d.Descriptions,'<br/>',' ') as feetpnm "
            command &= " ,d.AMOUNT as amt ,d.FEEABBR as feeabbr , cast (RIGHT(r.FEENO , 5) as int) as fee_no_5 , left(r.FEENO , 2) as year_fee "
            command &= " ,1 as rcptst ,r.FULLNAME as fullname , r.MONEY_RECEIVE_DATE , FULL_RECEIVE_NUMBER as receipt_number"
            command &= " ,isnull([RECEIVER_NAME],'') as sign_name , isnull([POSITION_NAME],'') as position"
            command &= " ,r.REF01+'-'+r.REF02  as bottom_number,QR_IMAGE_BYTE , r.[MONEY_RECEIVE_DATE]"
            command &= " from [MAINTAINS].[RECEIVE_MONEY] r"
            command &= " left join [MAINTAINS].[RECEIVE_MONEY_DETAIL2] d on r.RECEIVE_MONEY_ID = d.FK_IDA"
            command &= " left join [dbo].[MAS_MONEY_RECEIVER] rc on r.RECEIVER_MONEY_ID = rc.RECEIVER_MONEY_ID"
            command &= " where r.RECEIVE_MONEY_ID in (" & ida & ")"
            dt = Queryds(command)
            Return dt
        End Function
        Public Function get_RECEPT_by_BUDGET_YEAR(ByVal bgYear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_RECEPT_by_BUDGET_YEAR] @BudgetYear = " & bgYear
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function get_RECEPT_by_BUDGET_YEAR_AND_DATE(ByVal bgYear As Integer, ByVal _date As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(_date)
            command = " exec [BUDGETS].[get_RECEPT_by_BUDGET_YEAR_AND_DATE] @BudgetYear = " & bgYear & " ,@dateBegin=" & daySelect
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function get_RECEPT_by_BUDGET_YEAR_AND_DATE_ALL(ByVal bgYear As Integer, ByVal _date As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(_date)
            command = " exec [BUDGETS].[get_RECEPT_by_BUDGET_YEAR_AND_DATE_ALL] @BudgetYear = " & bgYear & " ,@dateBegin=" & daySelect
            dt = Queryds(command)
            Return dt
        End Function
        Public Function get_RECEPT_by_ref01_and_ref02(ByVal ref01 As String, ByVal ref02 As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_RECEPT_by_ref01_and_ref02] @ref01 = '" & ref01 & "' ,@ref02='" & ref02 & "'"
            dt = Queryds(command)
            Return dt
        End Function
        Public Function get_RECEPT_by_BUDGET_YEAR_AND_DATE_L44(ByVal bgYear As Integer, ByVal _date As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(_date)
            command = " exec [BUDGETS].[get_RECEPT_by_BUDGET_YEAR_AND_DATE_L44] @BudgetYear = " & bgYear & " ,@dateBegin=" & daySelect
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function get_max_receipt_all_by_type(ByVal bgYear As Integer, ByVal _type_receipt As Integer) As Integer
            Dim dt As New DataTable
            Dim count_no As Integer = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_max_receipt_all_by_type] @BUDGET_YEAR = " & bgYear & " ,@running_type=" & _type_receipt
            dt = Queryds(command)

            Try
                count_no = dt(0)("RUNNING_RECEIPT")
            Catch ex As Exception

            End Try
            Return count_no
        End Function

        Public Function get_RECEPT_by_BUDGET_YEAR_AND_DATE_L44_ALL(ByVal bgYear As Integer, ByVal _date As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(_date)
            command = " exec [BUDGETS].[get_RECEPT_by_BUDGET_YEAR_AND_DATE_L44_ALL] @BudgetYear = " & bgYear & " ,@dateBegin=" & daySelect
            dt = Queryds(command)
            Return dt
        End Function
        Public Function get_Data_Send_money_by_Budget_Year(ByVal bgYear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Data_Send_money_by_Budget_Year] @BUDGET_YEAR = " & bgYear
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function get_Data_Send_money_e_receipt_by_Budget_Year(ByVal bgYear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Data_Send_money_e_receipt_by_Budget_Year] @BUDGET_YEAR = " & bgYear
            dt = Queryds(command)
            Return dt
        End Function
        Public Function get_Max_Runno_Send_money_by_Budget_Year(ByVal bgYear As Integer) As Integer
            Dim dt As New DataTable
            Dim count_no As Integer = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Max_Runno_Send_money_by_Budget_Year] @BUDGET_YEAR = " & bgYear
            dt = Queryds(command)

            Try
                count_no = dt(0)("runno")
            Catch ex As Exception

            End Try
            Return count_no
        End Function
        Public Function get_Max_Runno_Send_money_e_receipt_by_Budget_Year(ByVal bgYear As Integer) As Integer
            Dim dt As New DataTable
            Dim count_no As Integer = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Max_Runno_Send_money_e_receipt_by_Budget_Year] @BUDGET_YEAR = " & bgYear
            dt = Queryds(command)

            Try
                count_no = dt(0)("runno")
            Catch ex As Exception

            End Try
            Return count_no
        End Function
        '
        'Public Function GET_send_money_selected(ByVal IDA As Integer, ByVal INCOME_ID As Integer, ByVal RECEIVE_MONEY_TYPE As Integer) As DataTable
        '    Dim dt As New DataTable
        '    Dim command As String = " "
        '    command = " exec [BUDGETS].[GET_send_money_selected] @IDA =" & IDA & " ,@INCOME_ID= " & INCOME_ID & ", @RECEIVE_MONEY_TYPE=" & RECEIVE_MONEY_TYPE
        '    dt = Queryds(command)

        '    Return dt
        'End Function
        Public Function GET_send_money_selected(ByVal IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[GET_send_money_selected] @IDA =" & IDA
            dt = Queryds(command)

            Return dt
        End Function
        'GET_send_money_all_by_type
        Public Function GET_send_money_all_by_type(ByVal daySelect As Date, ByVal INCOME_IDA As Integer, ByVal RECEIVE_MONEY_TYPE As Integer) As DataTable
            Dim dt As New DataTable
            Dim dayBegin As Integer = convertDateToInteger(daySelect)
            Dim command As String = " "
            command = " exec [BUDGETS].[GET_send_money_all_by_type] @daySelect=" & dayBegin & ", @INCOME_IDA=" & INCOME_IDA & ", @RECEIVE_MONEY_TYPE =" & RECEIVE_MONEY_TYPE
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function GET_send_money_e_receipt_all_by_type(ByVal daySelect As Date, ByVal INCOME_IDA As Integer, ByVal RECEIVE_MONEY_TYPE As Integer) As DataTable
            Dim dt As New DataTable
            Dim dayBegin As Integer = convertDateToInteger(daySelect)
            Dim command As String = " "
            command = " exec [BUDGETS].[GET_send_money_e_receipt_all_by_type] @daySelect=" & dayBegin & ", @INCOME_IDA=" & INCOME_IDA & ", @RECEIVE_MONEY_TYPE =" & RECEIVE_MONEY_TYPE
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_send_money_sum_det(ByVal IDA As Integer, ByVal INCOME_IDA As Integer, ByVal RECEIVE_MONEY_TYPE As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_send_money_sum_det] @INCOME_IDA=" & INCOME_IDA & ", @RECEIVE_MONEY_TYPE =" & RECEIVE_MONEY_TYPE & " ,@IDA=" & IDA
            dt = Queryds(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางการฝากเงิน(ยังไม่ฝาก) แยกตามปีงบประมาณ
        ''' </summary>
        ''' <param name="budgetYear">ปีงบประมาณ</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function get_DEPOSIT(ByVal budgetYear As Integer, moneytype As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_DEPOSIT] @BudgetYear = " & budgetYear & " ,@MONEY_TYPE_ID ='" & moneytype & "'"
            dt = Queryds(command)
            Return dt
        End Function
        ''' <summary>
        ''' ตารางการฝากเงิน(ฝากเงินแล้ว) แยกตามปีงบประมาณ
        ''' </summary>
        ''' <param name="budgetYear">ปีงบประมาณ</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function get_DEPOSIT_SelectDeposit(ByVal budgetYear As Integer, moneytype As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_DEPOSIT_SelectDeposit] @BudgetYear = " & budgetYear & " ,@MONEY_TYPE_ID ='" & moneytype & "'"
            dt = Queryds(command)
            Return dt
        End Function
        Public Function get_RECEIVABLE_OUTSTANDING() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_RECEIVABLE_OUTSTANDING] "
            dt = Queryds(command)
            Return dt
        End Function
        Public Function get_RECEIVABLE_OUTSTANDING_OUTSIDE() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_RECEIVABLE_OUTSTANDING_OUTSIDE] "
            dt = Queryds(command)
            Return dt
        End Function
        ''' <summary>
        ''' ตารางการคืนเงิน ลูกหนี้เงินยืม ในงบประมาณ แแยกตามลูกหนี้แต่ละคน
        ''' </summary>
        ''' <param name="debtorID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function get_DEBTOR_BILL_in_BUDGET_by_DEBTOR_BILL_ID(ByVal debtorID As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_DEBTOR_BILL_in_BUDGET_by_DEBTOR_BILL_ID] @DEBTOR_BILL_ID = " & debtorID
            dt = Queryds(command)
            Return dt
        End Function
        ''' <summary>
        ''' ตารางการคืนเงิน ลูกหนี้เวินยืม นอกงบประมาณ แแยกตามลูกหนี้แต่ละคน
        ''' </summary>
        ''' <param name="debtorID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function get_DEBTOR_BILL_out_BUDGET_by_DEBTOR_BILL_ID(ByVal debtorID As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_DEBTOR_BILL_out_BUDGET_by_DEBTOR_BILL_ID] @DEBTOR_BILL_ID = " & debtorID
            dt = Queryds(command)
            Return dt
        End Function
        ' ''' <summary>
        ' ''' ตารางการรับเงิน
        ' ''' </summary>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public Function get_RECEIVE_MONEY() As DataTable
        '    Dim dt As New DataTable
        '    Dim command As String = " "
        '    command = " exec [BUDGETS].[get_RECEIVE_MONEY]"
        '    dt = Queryds(command)
        '    Return dt
        'End Function
        ''' <summary>
        ''' เรียกตารางชื่อธนาคาร
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function get_BANK_NAME() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BANK_NAME] "
            dt = Queryds(command)
            Return dt
        End Function
        ''' <summary>
        ''' ตารางการคืนเงิน ลูกหนี้เงินยืม ในงบประมาณ โดย DEBTOR_BILL_ID
        ''' </summary>
        ''' <param name="debtorbillID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function get_RETURN_MONEY_DEBTOR(debtorbillID As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_RETURN_MONEY_DEBTOR] @DEBTOR_BILL_ID = " & debtorbillID
            dt = Queryds(command)
            Return dt
        End Function
        ''' <summary>
        ''' ตารางลูกหนี้เงินยืม งบประมาณ
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function get_DEBTOR_BILL_in_BUDGET(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_DEBTOR_BILL_in_BUDGET] @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function get_DEBTOR_BILL_in_BUDGET_V2(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_DEBTOR_BILL_in_BUDGET_V2] @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt
        End Function
        Public Function get_DEBTOR_BILL_in_BUDGET_by_id(ByVal id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_DEBTOR_BILL_in_BUDGET_by_id] @DEBTOR_BILL_ID=" & id
            dt = Queryds(command)
            Return dt
        End Function

        Public Function get_DEBTOR_BILL_out_BUDGET_by_id(ByVal id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_DEBTOR_BILL_out_BUDGET_by_id] @DEBTOR_BILL_ID=" & id
            dt = Queryds(command)
            Return dt
        End Function
        ''' <summary>
        ''' ตารางการคืนเงิน ลูกหนี้เงินยืม นอกงบประมาณ โดย DEBTOR_BILL_ID
        ''' </summary>
        ''' <param name="debtorbillID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function get_RETURN_MONEY_DEBTOR_OUTSIDEBUDGET(debtorbillID As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_RETURN_MONEY_DEBTOR_OUTSIDEBUDGET] @DEBTOR_BILL_ID = " & debtorbillID
            dt = Queryds(command)
            Return dt
        End Function
        ''' <summary>
        ''' ตารางลูกหนี้เงินยืม นอกงบประมาณ
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function get_DEBTOR_BILL_out_BUDGET(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_DEBTOR_BILL_out_BUDGET] @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt
        End Function
        Public Function get_DEBTOR_BILL_history(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_DEBTOR_BILL_history] @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt
        End Function
        Public Function get_transfer_BG() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_transfer_BG] "
            dt = Queryds(command)
            Return dt
        End Function

        Public Function get_transfer_margin() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_transfer_margin] "
            dt = Queryds(command)
            Return dt
        End Function
        Public Function get_transfer_out_BG() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_transfer_out_BG] "
            dt = Queryds(command)
            Return dt
        End Function

        'get_return_amount
        Public Function get_return_amount(id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_return_amount] @BILL_ID=" & id
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                value = dt(0)("RETURN_AMOUNT")
            End If


            Return value
        End Function

        'bk_list
        Public Function bk_list() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[bk_list] "
            dt = Queryds(command)
            Return dt
        End Function

        'get_debtor_return_money_by_bill_id
        Public Function get_debtor_return_money_by_bill_id(id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_return_money_by_bill_id] @DEBTOR_BILL_ID=" & id
            dt = Queryds(command)
            Return dt
        End Function

        Public Function get_debtor_return_move() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_return_move] "
            dt = Queryds(command)
            Return dt
        End Function
        Public Function get_debtor_return_deposit_cash(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_return_deposit_cash] @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt
        End Function
        Public Function get_debtor_return_deposit() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_return_deposit] "
            dt = Queryds(command)
            Return dt
        End Function

        'get_return_money_withdraw
        Public Function get_return_money_withdraw(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_return_money_withdraw] @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt
        End Function
        Public Function get_DEPOSIT_debtor(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_DEPOSIT_debtor] @BudgetYear=" & bgyear
            dt = Queryds(command)
            Return dt
        End Function
        Public Function get_DEPOSIT_debtor_select(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_DEPOSIT_debtor_select] @BudgetYear=" & bgyear
            dt = Queryds(command)
            Return dt
        End Function
        'get_deposit_balance
        Public Function get_deposit_balance(ByVal date_select As Date) As DataTable
            Dim dt As New DataTable
            Dim dayBegin As Integer = convertDateToInteger(date_select)
            Dim command As String = " "
            command = " exec [BUDGETS].[get_deposit_balance] @date=" & dayBegin
            dt = Queryds(command)
            Return dt
        End Function
        Public Function convertDateToInteger(ByVal dateSelect As Date)
            Dim dayfirst As Date = Date.Now
            dayfirst = CDate(dayfirst.ToShortDateString())
            Dim dateResult As Integer = DateDiff(DateInterval.Day, dayfirst, dateSelect)

            Return dateResult
        End Function
        'get_pay_other
        Public Function get_pay_other(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_pay_other] @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_get_receipt_data_det(ByVal receive_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[SP_get_receipt_data_det] @re_id=" & receive_id
            dt = Queryds(command)
            Return dt
        End Function
        Public Function SP_get_receipt_data_det_feeno(ByVal feeno As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[SP_get_receipt_data_det_feeno] @feeno='" & feeno & "'"
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_get_receipt_data_det_feeno_V2(ByVal RECEIVE_MONEY_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[SP_get_receipt_data_det_feeno_V2] @RECEIVE_MONEY_ID=" & RECEIVE_MONEY_ID
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_get_receipt_data_det_feeno_V2_9005(ByVal RECEIVE_MONEY_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[SP_get_receipt_data_det_feeno_V2_9005] @RECEIVE_MONEY_ID=" & RECEIVE_MONEY_ID
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_get_receipt_data_det_feeno_old(ByVal RECEIVE_MONEY_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[SP_get_receipt_data_det_feeno_old] @RECEIVE_MONEY_ID=" & RECEIVE_MONEY_ID
            dt = Queryds(command)
            Return dt
        End Function
        Public Function get_max_receipt_normal(ByVal bgyear As Integer, ByVal r_type As Integer) As Integer
            Dim value As Integer = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_max_receipt_normal] @BUDGET_YEAR=" & bgyear & " ,@running_type=" & r_type
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bill_max")) Then
                    value = 0
                Else
                    value = CInt(dt(0)("bill_max"))
                End If
            End If

            Return value
        End Function
        '
        Public Function get_max_receipt_normal_M44(ByVal bgyear As Integer, ByVal r_type As Integer) As Integer
            Dim value As Integer = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_max_receipt_normal_M44] @BUDGET_YEAR=" & bgyear & " ,@running_type=" & r_type
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bill_max")) Then
                    value = 0
                Else
                    value = CInt(dt(0)("bill_max"))
                End If
            End If

            Return value
        End Function
        Public Function get_max_receipt_e_billing(ByVal bgyear As Integer) As Integer
            Dim value As Integer = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_max_receipt_e_billing] @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bill_max")) Then
                    value = 0
                Else
                    value = CInt(dt(0)("bill_max"))
                End If
            End If

            Return value
        End Function
        '
        Public Function SP_RECEIVE_MONEY_DETAIL2_BY_FK_IDA(ByVal FK_IDA As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[SP_RECEIVE_MONEY_DETAIL2_BY_FK_IDA] @FK_IDA=" & FK_IDA
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function Get_LOG_PAY_FROM_SCB() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[Get_LOG_PAY_FROM_SCB] "
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function Get_LOG_PAY_FROM_SCB_L44() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[Get_LOG_PAY_FROM_SCB_L44] "
            dt = Queryds(command)
            Return dt
        End Function
        Public Function Get_LOG_PAY_FROM_SCB_NORMAL() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[Get_LOG_PAY_FROM_SCB_NORMAL] "
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function Get_LOG_PAY_FROM_SCB_NORMAL_TEST() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[Get_LOG_PAY_FROM_SCB_NORMAL_TEST] "
            dt = Queryds(command)
            Return dt
        End Function
        Public Function Get_LOG_PAY_FROM_SCB_NORMAL_BY_DATE(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim aa As New Report
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = aa.convertDateToString(dateSelect)
            command = " exec [BUDGETS].[Get_LOG_PAY_FROM_SCB_NORMAL_BY_DATE] @datebegin = " & daySelect
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function Get_LOG_PAY_FROM_SCB_L44_BY_DATE(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim aa As New Report
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = aa.convertDateToString(dateSelect)
            command = " exec [BUDGETS].[Get_LOG_PAY_FROM_SCB_L44_BY_DATE] @datebegin = " & daySelect
            dt = Queryds(command)

            Return dt
        End Function
        Public Function Get_E_RECEIPT_BY_REF01_AND_REF02(ByVal ref01 As String, ByVal ref02 As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[Get_E_RECEIPT_BY_REF01_AND_REF02] @ref01='" & ref01 & "' ,@ref02='" & ref02 & "'"
            dt = Queryds(command)
            Return dt
        End Function
        Public Function Get_Report_Receipt_Scb_By_Date(ByVal _date_select As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(_date_select)
            command = " exec [BUDGETS].[Get_Report_Receipt_Scb_By_Date] @dateselect=" & daySelect
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Sub Fix_Insert_RECEIVE_MONEY_DETAIL2(ByVal ref01 As String, ByVal ref02 As String)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[Fix_Insert_RECEIVE_MONEY_DETAIL2] @ref01='" & ref01 & "' ,@ref02='" & ref02 & "'"
            Queryds2(command)
        End Sub
    End Class
    '
    Public Class Welfare
        Inherits ConnectDatabase
        Public Function get_WELFARE(ByVal WelfareID As Integer, ByVal BudgetYear As Integer, ByVal month_th As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_WELFARE] @WELFARE_ID = " & WelfareID & ", @BudgetYear = " & BudgetYear & ", @MONTH_LIVE= '" & month_th & "'"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_WELFARE_Home(ByVal WelfareID As Integer, ByVal BudgetYear As Integer, ByVal month_th As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_WELFARE_Home] @WELFARE_ID = " & WelfareID & ", @BudgetYear = " & BudgetYear & ", @MONTH_DIS= '" & month_th & "'"
            dt = Queryds(command)

            Return dt
        End Function
        '
        ''' <summary>
        ''' Function แสดงใบเบิกที่เป็นค่ารักษาพยาบาล ค่าเล่าเรียนบุตร
        ''' </summary>
        ''' <param name="BudgetYear">ปีงบประมาณ</param>
        ''' <param name="BillType">1 = ค่ารักษาพยาบาล, 2 = ค่าเล่าเรียนบุตร</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function get_DISBURSES_CURE_STUDY(ByVal BudgetYear As Integer, ByVal BillType As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_DISBURSES_CURE_STUDY] @BillType = " & BillType & ", @BudgetYear = " & BudgetYear
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_WELFARE_Cremation(ByVal WelfareID As Integer, ByVal BudgetYear As Integer) As DataTable
            Dim dt As New DataTable ' ย้ายไปใช้รวม get_WELFARE
            Dim command As String = " "
            command = " exec [BUDGETS].[get_WELFARE_Cremation] @WELFARE_ID = " & WelfareID & ", @BudgetYear = " & BudgetYear
            dt = Queryds(command)

            Return dt
        End Function
        'get_welfares_cure_home
        Public Function get_welfares_cure_home(ByVal month As String, ByVal BudgetYear As Integer) As DataTable
            Dim dt As New DataTable ' ย้ายไปใช้รวม get_WELFARE
            Dim command As String = " "
            command = " exec [BUDGETS].[get_welfares_cure_home] @MONTH_LIVE = '" & month & "', @BUDGET_YEAR = " & BudgetYear
            dt = Queryds(command)

            Return dt
        End Function
        'get_welfares_cremetion
        Public Function get_welfares_cremetion(ByVal month As String, ByVal BudgetYear As Integer) As DataTable
            Dim dt As New DataTable ' ย้ายไปใช้รวม get_WELFARE
            Dim command As String = " "
            command = " exec [BUDGETS].[get_welfares_cremetion] @MONTH_LIVE = '" & month & "', @BUDGET_YEAR = " & BudgetYear
            dt = Queryds(command)

            Return dt
        End Function
    End Class
    Public Class MASS
        Inherits ConnectDatabass

        '
        Public Sub INSERT_WAIT_QUEUE_LIST(ByVal ref01 As String, ByVal ref02 As String)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[INSERT_WAIT_QUEUE_LIST] @ref01='" & ref01 & "' , @ref02='" & ref02 & "'"
            dt = Queryds(command)
        End Sub
        Public Function GET_DETAIL_RECEIPT(ByVal ref01 As String, ByVal ref02 As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[GET_DETAIL_RECEIPT] @ref01='" & ref01 & "' , @ref02='" & ref02 & "'"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function Get_LOG_WAIT_RECEIPT() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[Get_LOG_WAIT_RECEIPT]"
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function Get_Queue_Error() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[Get_Queue_Error]"
            dt = Queryds(command)

            Return dt
        End Function

        Public Function Get_LOG_QUEUE_LIST() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[Get_LOG_QUEUE_LIST]"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_HEAD_BUDGET_NAME() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_HEAD_BUDGET_NAME]"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_prefix2() As DataTable
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_prefix2] "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_BG_BOOKBANK_NAME() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec [BUDGETS].[get_BG_BOOKBANK_NAME]"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_All_month() As DataTable
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_All_month] "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_AccoutBank_ByBankId(ByVal BankId As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_AccoutBank_ByBankId] @BankId=" & BankId
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_NameDisburse_ByYear(ByVal BgYear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_NameDisburse_ByYear] @BgYear=" & BgYear
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_Deka_Number_ByType(ByVal DekaId As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Deka_Number_ByType] @DekaId=" & DekaId
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_Department_Select() As DataTable
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Department] "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_GL_Study() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec BUDGETS.get_GL_Study "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_BG_TYPE_MONEY() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BG_TYPE_MONEY]"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_BG_TYPE_CUS() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BG_TYPE_CUS]"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_BG_TYPE_MONEY_W() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BG_TYPE_MONEY_W]"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_BG_PAYTYPE() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BG_PAYTYPE]"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_BG_PAYTYPE_DEKA() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BG_PAYTYPE_DEKA]"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_BG_BANK_DEKA() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BG_BANK_DEKA]"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_pre_customer_store() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_pre_customer]"
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_customer_AddCer(ByVal IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_customer_AddCer] @ID=" & IDA
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_dept_not_in(ByVal dept As Integer, ByVal str_is_outside As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_dept_not_in] @DEPARTMENT_ID =" & dept & ", @DEPARTMENT_IS_OUTSIDE='" & str_is_outside & "'"
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_outside_dept() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_outside_dept] "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_Budget_use_Amount(bg As Integer) As Double
            Dim dt As New DataTable
            Dim val As Double = 0.0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Budget_use_Amount] @BUDGET_PLAN_ID=" & bg
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("use_amount")) = False Then
                    val = dt(0)("use_amount")
                End If

            End If
            Return val
        End Function
        Public Function get_Moneytype_child(ByVal headid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Moneytype_child] @HEAD_ID = " & headid
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_RETURN_DESCRIPTION() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_RETURN_DESCRIPTION] "
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_MAS_RETURN_TYPE() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_MAS_RETURN_TYPE] "
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_max_num_return_debtor(bgyear As Integer) As Integer
            Dim dt As New DataTable
            Dim value As Integer = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_max_num_return_debtor] @bgyear=" & bgyear
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("maxnum")) = False Then
                    value = CInt(dt(0)("maxnum"))
                End If
            End If
            Return value
        End Function

        Public Function get_debtor_return_money_by_bill() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_return_money_by_bill] "
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_debtor_return_amount(ByVal deb_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_debtor_return_amount] @DEBTOR_BILL_ID=" & deb_id
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) = False Then
                    value = CDbl(dt(0)("Amount"))
                End If
            End If
            Return value
        End Function

        Public Function get_Department() As DataTable
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Department] "
            dt = Queryds(command)

            dt.TableName = "Department"
            Return dt
        End Function
        'get_adjust_by_dept
        Public Function get_adjust_by_dept(dept As Integer, bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_adjust_by_dept] @DEPARTMENT_ID=" & dept & " , @BUDGET_YEAR=" & bgyear
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_sub_budget(ByVal type_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_sub_budget] @SUB_BUDGET_TYPE=" & type_id
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_customer() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " select c.CUSTOMER_ID ,c.CUSTOMER_NAME from dbo.MAS_CUSTOMER c"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_bank() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " select * from dbo.MAS_BANK "
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_GET_MONEY_TYPE() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec BUDGETS.SP_GET_MONEY_TYPE "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_GL() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec BUDGETS.get_GL "
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_GL_debtor() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec BUDGETS.get_GL_debtor "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_user() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec [BUDGETS].[get_user] "
            dt = Queryds(command)

            Return dt
        End Function
        '[BUDGETS].[get_Important_user]
        Public Function get_Important_user() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec [BUDGETS].[get_Important_user] "
            dt = Queryds(command)

            Return dt
        End Function
        ' get_bg_adjust_amount_all
        Public Function get_bg_adjust_amount_all(ByVal bgyear As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bg_adjust_amount_all] @budgetYear=" & bgyear
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("Amount")) = False Then
                    value = CDbl(dt(0)("Amount"))
                End If
            End If
            Return value
        End Function
        'get_multi_dept
        Public Function get_multi_dept(ByVal ad_name As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_multi_dept] @AD_NAME='" & ad_name & "'"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_transfer_out(ByVal bgyear As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_transfer_out] @BudgetYear='" & bgyear & "'"
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_transfer_out_user(ByVal bgyear As String, ByVal dept As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_transfer_out_user] @BudgetYear='" & bgyear & "'" & ",@dept=" & dept
            dt = Queryds(command)

            Return dt
        End Function
        'get_Transfer_detail
        Public Function get_Transfer_detail(ByVal tid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Transfer_detail] @TID=" & tid
            dt = Queryds(command)

            Return dt
        End Function
        'get_transfer_inside
        Public Function get_transfer_inside(ByVal bgyear As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_transfer_inside] @BudgetYear='" & bgyear & "'"
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_transfer_inside_user(ByVal bgyear As String, ByVal dept As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_transfer_inside_user] @BudgetYear='" & bgyear & "'" & " , @dept=" & dept
            dt = Queryds(command)

            Return dt
        End Function
        'get_transfer_for_approve
        Public Function get_transfer_for_approve(ByVal bgyear As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_transfer_for_approve] @BudgetYear='" & bgyear & "'"
            dt = Queryds(command)

            Return dt
        End Function
        'get_transfer_receive
        Public Function get_transfer_receive(ByVal bgyear As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_transfer_receive] @BudgetYear='" & bgyear & "'"
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_transfer_receive_user(ByVal bgyear As String, ByVal dept As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_transfer_receive_user] @BudgetYear='" & bgyear & "'" & " ,@dept=" & dept
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_check_number(ByVal chk_number As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_check_number] @CHECK_NUMBER='" & chk_number & "'"
            dt = Queryds(command)

            Return dt
        End Function
        'get_check_number_bill
        Public Function get_check_number_bill(ByVal chk_number As String, bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_check_number_bill] @CHECK_NUMBER='" & chk_number & "' , @budgetuse=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        'get_check_number_All
        Public Function get_check_number_All(ByVal chk_number As String, ByVal billtype As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_check_number_All] @CHECK_NUMBER='" & chk_number & "' ,@b_type=" & billtype
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_check_number_by_name_bill_ALL(ByVal name As String, ByVal billtype As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_check_number_by_name_bill_ALL] @NAME='" & name & "' ,@b_type=" & billtype
            dt = Queryds(command)

            Return dt
        End Function
        'get_max_count_print
        Public Function get_max_count_print(ByVal dateselect As Date) As Integer
            Dim dt As New DataTable
            Dim maxVal As Integer = 0
            Dim dateint As Integer = convertDateToInteger(dateselect)
            Dim command As String = " "
            command = " exec [BUDGETS].[get_max_count_print] @dateselect=" & dateint
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("PRINT_COUNT")) = False Then
                    maxVal = dt(0)("PRINT_COUNT")
                Else
                    maxVal = 1
                End If
            Else
                maxVal = 1
            End If
            Return maxVal
        End Function
        'get_check_number_rebill
        Public Function get_check_number_rebill(ByVal chk_number As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_check_number_rebill] @CHECK_NUMBER='" & chk_number & "'"
            dt = Queryds(command)

            Return dt
        End Function
        'get_check_number_Other
        Public Function get_check_number_Other(ByVal chk_number As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_check_number_Other] @CHECK_NUMBER='" & chk_number & "'"
            dt = Queryds(command)

            Return dt
        End Function
        'get_check_number_by_money
        Public Function get_check_number_by_money(ByVal money As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_check_number_by_money] @AMOUNT='" & money & "'"
            dt = Queryds(command)

            Return dt
        End Function
        'get_check_number_by_money_bill
        Public Function get_check_number_by_money_bill(ByVal money As String, bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_check_number_by_money_bill] @AMOUNT='" & money & "' , @budgetuse=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_check_number_by_money_bill_ALL(ByVal money As String, billtype As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_check_number_by_money_bill_ALL] @AMOUNT='" & money & "' , @b_type=" & billtype
            dt = Queryds(command)

            Return dt
        End Function
        'get_check_number_by_money_rebill
        Public Function get_check_number_by_money_rebill(ByVal money As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_check_number_by_money_rebill] @AMOUNT='" & money & "'"
            dt = Queryds(command)

            Return dt
        End Function
        'get_check_number_by_money_Other
        Public Function get_check_number_by_money_Other(ByVal money As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_check_number_by_money_Other] @AMOUNT='" & money & "'"
            dt = Queryds(command)

            Return dt
        End Function
        'get_check_number_by_bill_num
        Public Function get_check_number_by_bill_num(ByVal bill As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_check_number_by_bill_num] @BILL_NUMBER='" & bill & "'"
            dt = Queryds(command)

            Return dt
        End Function
        'get_check_number_by_bill_num_bill
        Public Function get_check_number_by_bill_num_bill(ByVal bill As String, bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_check_number_by_bill_num_bill] @BILL_NUMBER='" & bill & "' , @budgetuse=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_check_number_by_bill_num_bill_ALL(ByVal bill As String, billtype As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_check_number_by_bill_num_bill_ALL] @BILL_NUMBER='" & bill & "' , @b_type=" & billtype
            dt = Queryds(command)

            Return dt
        End Function
        'get_check_number_by_bill_num_rebill
        Public Function get_check_number_by_bill_num_rebill(ByVal bill As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_check_number_by_bill_num_rebill] @BILL_NUMBER='" & bill & "'"
            dt = Queryds(command)

            Return dt
        End Function
        'get_check_number_by_bill_num_Other
        Public Function get_check_number_by_bill_num_Other(ByVal bill As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_check_number_by_bill_num_Other] @BILL_NUMBER='" & bill & "'"
            dt = Queryds(command)

            Return dt
        End Function
        'get_check_number_by_name
        Public Function get_check_number_by_name(ByVal name As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_check_number_by_name] @NAME='" & name & "'"
            dt = Queryds(command)

            Return dt
        End Function
        'get_check_number_by_name_bill
        Public Function get_check_number_by_name_bill(ByVal name As String, bguse As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_check_number_by_name_bill] @NAME='" & name & "', @budgetuse=" & bguse
            dt = Queryds(command)

            Return dt
        End Function
        'get_check_number_by_name_rebill
        Public Function get_check_number_by_name_rebill(ByVal name As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_check_number_by_name_rebill] @NAME='" & name & "'"
            dt = Queryds(command)

            Return dt
        End Function
        'get_check_number_by_name_Other
        Public Function get_check_number_by_name_Other(ByVal name As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_check_number_by_name_Other] @NAME='" & name & "'"
            dt = Queryds(command)

            Return dt
        End Function
        'get_customer_gov
        Public Function get_customer_gov() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_customer_gov]"
            dt = Queryds(command)

            dt.TableName = "customer"
            Return dt
        End Function
        '
        Public Function get_customer_gov_xml() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_customer_gov_xml]"
            dt = Queryds(command)

            dt.TableName = "customer"
            Return dt
        End Function

        Public Function get_family_customer() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_family_customer]"
            dt = Queryds(command)

            dt.TableName = "family"
            Return dt
        End Function
        ''get_sub_bg
        Public Function get_sub_bg(ByVal bg_child As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_sub_bg] @BUDGET_CHILD_ID=" & bg_child
            dt = Queryds(command)

            Return dt
        End Function
        'get_print_group
        Public Function get_print_group(ByVal dateselect As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_print_group] @dateBegin=" & dateselect
            dt = Queryds(command)

            Return dt
        End Function
        'get_print_group_debtor
        Public Function get_print_group_debtor(ByVal dateselect As Integer, ByVal debtor_type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_print_group_debtor] @dateBegin=" & dateselect & " , @DEBTOR_TYPE_ID=" & debtor_type
            dt = Queryds(command)

            Return dt
        End Function

        'get_customer_type
        Public Function get_customer_type() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_customer_type]"
            dt = Queryds(command)

            Return dt
        End Function
        'get_customer
        Public Function get_customer_store() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_customer]"
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function GET_MAS_CHECKER() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[GET_MAS_CHECKER]"
            dt = Queryds(command)

            Return dt
        End Function
        'get_home_key
        Public Function get_home_key(ByVal bgYear As Integer) As Integer
            Dim dt As New DataTable
            Dim key As Integer = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_home_key] @BUDGET_YEAR=" & bgYear
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("BUDGET_PLAN_ID")) = False Then
                    key = dt(0)("BUDGET_PLAN_ID")
                End If
            End If

            Return key
        End Function
        'get_pts_key
        Public Function get_pts_key(ByVal bgYear As Integer) As Integer
            Dim dt As New DataTable
            Dim key As Integer = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_pts_key] @BUDGET_YEAR=" & bgYear
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("BUDGET_PLAN_ID")) = False Then
                    key = dt(0)("BUDGET_PLAN_ID")
                End If
            End If

            Return key
        End Function
        'get_wech_key
        Public Function get_wech_key(ByVal bgYear As Integer) As Integer
            Dim dt As New DataTable
            Dim key As Integer = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_wech_key] @BUDGET_YEAR=" & bgYear
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("BUDGET_PLAN_ID")) = False Then
                    key = dt(0)("BUDGET_PLAN_ID")
                End If
            End If

            Return key
        End Function
        'get_paylist
        Public Function get_paylist() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_paylist]"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function convertDateToInteger(ByVal dateSelect As Date)
            Dim dayfirst As Date = Date.Now
            dayfirst = CDate(dayfirst.ToShortDateString())
            Dim dateResult As Integer = DateDiff(DateInterval.Day, dayfirst, dateSelect)

            Return dateResult
        End Function
        'get_check_history_debtor
        Public Function get_check_history_debtor(ByVal dateSelect As Date, ByVal print_c As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            command = " exec [BUDGETS].[get_check_history_debtor] @date = " & daySelect & ", @PRINT_COUNT= " & print_c
            dt = Queryds(command)

            Return dt
        End Function
        'get_check_history_bill
        Public Function get_check_history_bill(ByVal dateSelect As Date, ByVal print_c As Integer, ByVal billty As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            command = " exec [BUDGETS].[get_check_history_bill] @date = " & daySelect & ", @PRINT_COUNT= " & print_c & ", @BILL_TYPE=" & billty
            dt = Queryds(command)

            Return dt
        End Function
        'get_check_history_all
        Public Function get_check_history_all(ByVal dateSelect As Date, ByVal print_c As Integer, ByVal b_type As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            command = " exec [BUDGETS].[get_check_history_all] @date = " & daySelect & ", @PRINT_COUNT= " & print_c & " ,@b_type= '" & b_type & "'"
            dt = Queryds(command)

            Return dt
        End Function
        'get_support_dept_plan
        Public Function get_support_dept_plan(ByVal bgYear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_support_dept_plan] @BUDGET_YEAR = " & bgYear
            dt = Queryds(command)
            Return dt
        End Function
        'get_support_dept_type
        Public Function get_support_dept_type(ByVal bg_id As String) As Boolean
            Dim dt As New DataTable
            Dim bool As Boolean = False
            Dim command As String = " "
            command = " exec [BUDGETS].[get_support_dept_type] @BUDGET_PLAN_ID=" & bg_id
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("is_suppot")) = False Then
                    bool = dt(0)("is_suppot")
                End If
            End If

            Return bool
        End Function
        'get_bg_head_id
        Public Function get_bg_head_id(ByVal bg_id As Integer) As Integer
            Dim dt As New DataTable
            Dim key As Integer = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bg_head_id] @BUDGET_PLAN_ID=" & bg_id
            dt = Queryds(command)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("head_id")) = False Then
                    key = dt(0)("head_id")
                End If
            End If

            Return key
        End Function
        'get_head_moneytype
        Public Function get_head_moneytype() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_head_moneytype] "
            dt = Queryds(command)
            Return dt
        End Function
        'get_person_in_report
        Public Function get_person_in_report() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_person_in_report] "
            dt = Queryds(command)
            Return dt
        End Function

        Public Function get_type_person_in_report() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_type_person_in_report] "
            dt = Queryds(command)
            Return dt
        End Function

        Public Function get_BG_Type7() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_BG_Type7] "
            dt = Queryds(command)
            Return dt
        End Function

        Public Function get_person_in_report_set(ByVal r_type As Integer, ByVal is_foundation As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_person_in_report_set] @R_TYPE=" & r_type & ", @IS_FOUNDATION='" & is_foundation & "'"
            dt = Queryds(command)
            Return dt
        End Function

        Public Function get_person_in_report_set_normal(ByVal r_type As Integer, ByVal is_foundation As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_person_in_report_set_normal] @R_TYPE=" & r_type & ", @IS_FOUNDATION='" & is_foundation & "'"
            dt = Queryds(command)
            Return dt
        End Function

        Public Function get_person_in_report_set_spsc(ByVal r_type As Integer, ByVal is_foundation As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_person_in_report_set_spsc] @R_TYPE=" & r_type & ", @IS_FOUNDATION='" & is_foundation & "'"
            dt = Queryds(command)
            Return dt
        End Function

        Public Function get_person_in_report_set_sss(ByVal r_type As Integer, ByVal is_foundation As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_person_in_report_set_sss] @R_TYPE=" & r_type & ", @IS_FOUNDATION='" & is_foundation & "'"
            dt = Queryds(command)
            Return dt
        End Function

        Public Function get_person_in_report_set_benefit(ByVal r_type As Integer, ByVal is_foundation As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_person_in_report_set_benefit] @R_TYPE=" & r_type & ", @IS_FOUNDATION='" & is_foundation & "'"
            dt = Queryds(command)
            Return dt
        End Function

        Public Function get_moneytype_head_text(ByVal m_type As Integer) As String
            Dim dt As New DataTable
            Dim txt As String = ""
            Dim command As String = " "
            command = " exec [BUDGETS].[get_moneytype_head_text] @MONEY_TYPE_ID=" & m_type
            dt = Queryds(command)
            If dt.Rows.Count > 0 Then
                txt = dt(0)("MONEY_TYPE_DESCRIPTION")
            End If
            Return txt
        End Function

        Public Function get_bg_child(ByVal bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bg_child] @BUDGET_CHILD_ID=" & bgid
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function get_bg_code(ByVal bgid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_bg_code] @BUDGET_PLAN_ID=" & bgid
            dt = Queryds(command)
            dt.TableName = "Activity_Code"
            Return dt
        End Function

        Public Function get_margin_receive() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_margin_receive]"
            dt = Queryds(command)
            Return dt
        End Function

        Public Function get_max_id_budget_plan() As Integer
            Dim dt As New DataTable
            Dim value As Integer = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_max_id_budget_plan]"
            dt = Queryds(command)
            Try
                value = dt(0)("bg_id")
            Catch ex As Exception

            End Try

            Return value
        End Function
        Public Function get_prefix() As DataTable
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_prefix] "
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_Position() As DataTable
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Position] "
            dt = Queryds(command)

            dt.TableName = "Position"
            Return dt
        End Function

        Public Function get_level() As DataTable
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_level] "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_Person_List_by_Type(ByVal per As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Person_List_by_Type] @p_type=" & per
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_SALARY_PAYLIST(ByVal use_type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_SALARY_PAYLIST] @use_type=" & use_type
            dt = Queryds(command)

            Return dt
        End Function
        Public Function get_user_personel(ByVal per_type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec BUDGETS.get_user_personel @per_type=" & per_type
            dt = Queryds(command)
            Return dt
        End Function

        Public Function get_income_tb() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec BUDGETS.get_income_tb "
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_MAS_RECEIPT_DEPARTMENT() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec BUDGETS.SP_MAS_RECEIPT_DEPARTMENT "
            dt = Queryds(command)
            Return dt
        End Function
        Public Function get_reason_by_fk_ida_bill_type_and_stat(ByVal fk_ida As Integer, ByVal bt As Integer, ByVal stat As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_reason_by_fk_ida_bill_type_and_stat] @fk_ida=" & fk_ida & ",@bt=" & bt & ",@stat=" & stat
            dt = Queryds(command)

            Return dt
        End Function

        Public Function get_money_type_list() As DataTable
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_money_type_list] "
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function get_money_type_list_by_id(ByVal ida As Integer) As DataTable
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_money_type_list_by_id] @MONEY_TYPE_ID=" & ida
            dt = Queryds(command)

            Return dt
        End Function

        '
        Public Function GET_BUDGET_PLAN_ACTIVITY_BY_FK(ByVal fk_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[GET_BUDGET_PLAN_ACTIVITY_BY_FK] @fk_id=" & fk_id
            dt = Queryds(command)

            Return dt
        End Function

        Public Function gen_xml_project() As DataTable
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[gen_xml_project]"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function GET_TIMESTAMP() As String
            Dim dt As New DataTable
            Dim str_time As String = ""
            Dim command As String = " "
            command = " exec [BUDGETS].[GET_TIMESTAMP]"
            dt = Queryds(command)
            For Each dr As DataRow In dt.Rows
                str_time = dr("no_time")
            Next
            Return str_time
        End Function
        Public Function SP_COUNT_CONFIRM_SCB(ByVal ref01 As String, ref02 As String) As Integer
            Dim i As Integer = 0
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec dbo.SP_COUNT_CONFIRM_SCB @ref01='" & ref01 & "', @ref02='" & ref02 & "' "
            dt = Queryds(command)
            For Each dr As DataRow In dt.Rows
                i = dr("c_confirm")
            Next
            Return i
        End Function
    End Class
    Public Class USER
        Inherits ConnectDatabase
        Public Function get_NAME_AD_NAME() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [get_USER_NAME_AD_NAME] "
            dt = Queryds_User(command)
            Return dt
        End Function

        Public Function get_NAME_SURNAME() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [get_NAME_SURNAME] "
            dt = Queryds_User(command)
            Return dt
        End Function
    End Class
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
        Public Function Queryds_User(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DTAM_USERConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
    End Class
    Public Class Report
        Inherits ConnectDatabase
        Public Function get_Report_All_Plan(ByVal BUDGET_YEAR As Integer, ByVal DEPT As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec [BUDGETS].[get_Report_All_Plan] @BUDGET_YEAR= " & BUDGET_YEAR & ",@DEPARTMENT_ID=" & DEPT
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R7_Slip_list() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Report_R7_Slip_list]"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' Function เรียงปี เดือน วัน
        ''' </summary>
        ''' <param name="dateSelect"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function splitDate(ByVal dateSelect As String)
            Dim arr As String() = dateSelect.Split("/") 'ตัวแปรเก็บวันที่รับเข้ามา
            Dim yearNow As Integer = Year(System.DateTime.Now) 'ตัวแปรเก็บปีปัจจุบัน
            'Check ตัวแปรเก็บปีปัจจุบัน เป็นปีไทย หรือ ปีอังกฤษ ผลที่ได้จะเป็นปีอังกฤษเสมอ
            If yearNow > 2500 Then
                yearNow = yearNow - 543
            Else
                yearNow = yearNow
            End If
            'Check ตัวแปรเก็บปีที่รับเข้ามา เทียบกับ yearNow(ปีอังกฤษ) ผลที่ได้จะได้ปีเป็นปีอังกฤษเสมอ
            If arr(2) > yearNow Then
                arr(2) = CInt(arr(2)) - 543
            Else
                arr(2) = arr(20)
            End If
            Dim dateNew As String = arr(2) + "/" + arr(1) + "/" + arr(0) 'วันที่หลังจากเปลี่ยนรูปแบบแล้ว

            Return dateNew
        End Function
        ''' <summary>
        ''' Function เปลี่ยนวันที่เป็นตัวเลข
        ''' </summary>
        ''' <param name="dateSelect"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function convertDateToInteger(ByVal dateSelect As Date)
            Dim dayfirst As Date = Date.Now
            dayfirst = CDate(dayfirst.ToShortDateString())
            Dim dateResult As Integer = DateDiff(DateInterval.Day, dayfirst, dateSelect)

            Return dateResult
        End Function
        ''' <summary>
        ''' Function เปลี่ยนวันที่เป็นตัวอักษร
        ''' </summary>
        ''' <param name="DateSelect"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function convertDateToString(ByVal DateSelect As Date)
            Dim day As Integer = DateSelect.Day
            Dim monthNumber As Integer = DateSelect.Month
            Dim year As Integer = DateSelect.Year

            If year < 2500 Then
                year = year + 543
            End If

            Dim monthName As String = ""
            Dim fullDate As String = ""

            Select Case monthNumber
                Case 1 : monthName = "มกราคม"
                Case 2 : monthName = "กุมภาพันธ์"
                Case 3 : monthName = "มีนาคม"
                Case 4 : monthName = "เมษายน"
                Case 5 : monthName = "พฤษภาคม"
                Case 6 : monthName = "มิถุนายน"
                Case 7 : monthName = "กรกฎาคม"
                Case 8 : monthName = "สิงหาคม"
                Case 9 : monthName = "กันยายน"
                Case 10 : monthName = "ตุลาคม"
                Case 11 : monthName = "พฤศจิกายน"
                Case 12 : monthName = "ธันวาคม"
                Case Else
                    monthName = ""
            End Select

            fullDate = day & " " & monthName & " " & year

            Return fullDate
        End Function
        '-------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_001 เงินงบประมาณ
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_001(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_001] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_001_2 เงินทดรอง
        ''' </summary>
        ''' <param name="dateSelect"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_001_2(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_001_2] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_002
        ''' </summary>
        ''' <param name="dateBegin">Parameter วันเริ่มต้น</param>
        ''' <param name="dateEnd">Parameter วันสิ้นสุด</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_002(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R2_002] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_003
        ''' </summary>
        ''' <param name="dateBegin">Parameter วันเริ่มต้น</param>
        ''' <param name="dateEnd">Parameter วันสิ้นสุด</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_003(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R2_003] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_004
        ''' </summary>
        ''' <param name="dateBegin">Parameter วันเริ่มต้น</param>
        ''' <param name="dateEnd">Parameter วันสิ้นสุด</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_004(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R2_004] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_005 งบประมาณ
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_005(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_005] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function

        ''' <summary>
        ''' ตารางแสดงรายงาน R2_005_2 ทดรอง
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_005_2(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_005_2] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_006
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_006(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_006] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R2_006_2
        Public Function get_Report_R2_006_2(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_006_2] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R2_006_3
        Public Function get_Report_R2_006_3(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_006_3] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R2_006_4
        Public Function get_Report_R2_006_4(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_006_4] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_007
        ''' </summary>
        ''' <param name="adName">ชื่อลูกหนี้ที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_007(ByVal adName As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Report_R2_007] @adName = '" & adName & "' ,@BUDGET_YEAR=" & bgyear
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_008
        ''' </summary>
        ''' <param name="adName">ชื่อลูกหนี้ที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_008(ByVal adName As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Report_R2_008] @adName = '" & adName & "' ,@BUDGET_YEAR=" & bgyear
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_009
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_009(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_009] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_010
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_010(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_010] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_011
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_011(ByVal dateSelect As Date, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_011] @dateSelect = " & daySelect & ",@BUDGET_YEAR=" & bgyear
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_012
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_012(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_012] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_013
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_013(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_013] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_014
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_014(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_014] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_015
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_015(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_015] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_016
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_016(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_016] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_017
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_017(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_017] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_018
        ''' </summary>
        ''' <param name="dateBegin">Parameter วันเริ่มต้น</param>
        ''' <param name="dateEnd">Parameter วันสิ้นสุด</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function get_Report_R2_018(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R2_018] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R2_018_8(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R2_018_8] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R2_018_2(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R2_018_2] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R2_018_7(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R2_018_7] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R2_018_3(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R2_018_3] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R2_018_4(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R2_018_4] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R2_018_5(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R2_018_5] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R2_018_V2(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bgyear As Integer, ByVal dept As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R2_018_V2] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & ",@BUDGET_YEAR=" & bgyear & " ,@DEPARTMENT_ID=" & dept
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_019
        ''' </summary>
        ''' <param name="dateBegin">Parameter วันเริ่มต้น</param>
        ''' <param name="dateEnd">Parameter วันสิ้นสุด</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_019(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R2_019] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_020
        ''' </summary>
        ''' <param name="dateBegin">Parameter วันเริ่มต้น</param>
        ''' <param name="dateEnd">Parameter วันสิ้นสุด</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_020(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R2_020] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_021
        ''' </summary>
        ''' <param name="dateBegin">Parameter วันเริ่มต้น</param>
        ''' <param name="dateEnd">Parameter วันสิ้นสุด</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_021(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R2_021] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_022
        ''' </summary>
        ''' <param name="dateBegin">Parameter วันเริ่มต้น</param>
        ''' <param name="dateEnd">Parameter วันสิ้นสุด</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_022(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R2_022] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_023
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_023(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_023] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_024
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_024(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_024] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R2_025
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R2_025(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_025] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R2_Home_Approve
        Public Function get_Report_R2_Home_Approve(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            'Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R2_Home_Approve] @dateselect = " & daySelect
            'command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function

        '-------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ตารางแสดงรายงาน R3_001
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R3_001(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R3_001] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_Report_R3_015(ByVal dateSelect As Date, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            command = " exec [BUDGETS].[get_Report_R3_015] @dateSelect = " & daySelect & ",@BUDGET_YEAR=" & bgyear
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_Report_R3_015_2(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            command = " exec [BUDGETS].[get_Report_R3_015_2] @dateSelect = " & daySelect
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function get_Report_R3_015_3(ByVal dateSelect As Date, ByVal dvcd As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            command = " exec [BUDGETS].[get_Report_R3_015_3] @dateSelect = " & daySelect & ",@dvcd=" & dvcd
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_Report_R3_015_4(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            command = " exec [BUDGETS].[get_Report_R3_015_4] @dateSelect = " & daySelect
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_Report_R3_015_4_law(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            command = " exec [BUDGETS].[get_Report_R3_015_4_law] @dateSelect = " & daySelect
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R3_016(ByVal dateSelect As Date, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R3_016] @dateSelect = " & daySelect & ",@BUDGET_YEAR=" & bgyear
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_Report_R3_016_2(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_016_2] @dateBegin = " & dayBegin & ",@dateEnd=" & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_Report_R3_016_3(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_016_3] @dateBegin = " & dayBegin & ",@dateEnd=" & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R3_017
        Public Function get_Report_R3_017(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_017] @dateBegin = " & dayBegin & ",@dateEnd=" & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_Report_R3_017_old(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_017_old] @dateBegin = " & dayBegin & ",@dateEnd=" & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function GET_Check_Pay_From_SCB(ByVal dateBegin As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[GET_Check_Pay_From_SCB] @dateBegin = " & dayBegin
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function GET_Check_Pay_From_SCB_L44(ByVal dateBegin As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[GET_Check_Pay_From_SCB_L44] @dateBegin = " & dayBegin
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_Report_R3_017_V2(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal recieve As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_017_V2] @dateBegin = " & dayBegin & ",@dateEnd=" & dayEnd & " ,@RECEIVER_MONEY_ID='" & recieve & "'"
            command += ", @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R3_017_V2_old
        Public Function get_Report_R3_017_V2_old(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal recieve As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_017_V2_old] @dateBegin = " & dayBegin & ",@dateEnd=" & dayEnd & " ,@RECEIVER_MONEY_ID='" & recieve & "'"
            command += ", @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R3_017_normal_law(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_017_normal_law] @dateBegin = " & dayBegin & ",@dateEnd=" & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_Report_R3_017_normal_law_old(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_017_normal_law_old] @dateBegin = " & dayBegin & ",@dateEnd=" & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R3_017_normal_law_V2(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal recieve As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_017_normal_law_V2] @dateBegin = " & dayBegin & ",@dateEnd=" & dayEnd & " ,@RECEIVER_MONEY_ID='" & recieve & "'"
            command += ", @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_Report_R3_017_normal_law_V2_old(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal recieve As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_017_normal_law_V2_old] @dateBegin = " & dayBegin & ",@dateEnd=" & dayEnd & " ,@RECEIVER_MONEY_ID='" & recieve & "'"
            command += ", @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R3_018(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_018] @dateBegin = " & dayBegin & ",@dateEnd=" & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_Report_R3_018_V2(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal recieve As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_018_V2] @dateBegin = " & dayBegin & ",@dateEnd=" & dayEnd & " ,@RECEIVER_MONEY_ID='" & recieve & "'"
            command += ", @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_Report_R3_018_e(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_018_e] @dateBegin = " & dayBegin & ",@dateEnd=" & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function Get_get_receive_cancel_count_e(ByVal dateBegin As Date, ByVal dateEnd As Date)
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " select dbo.get_receive_cancel_count_e(" & dayBegin & "," & dayEnd & ") as count_cancel"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_receive_cancel_count_e_new(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal receiver_id As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " select dbo.get_receive_cancel_count_e_new(" & dayBegin & "," & dayEnd & "," & receiver_id & ") as count_cancel"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function Get_get_receive_cancel_money_e(ByVal dateBegin As Date, ByVal dateEnd As Date)
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " select dbo.get_receive_cancel_money_e(" & dayBegin & "," & dayEnd & ") as money_cancel"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_receive_cancel_money_e_new(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal receiver_id As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " select dbo.get_receive_cancel_money_e_new(" & dayBegin & "," & dayEnd & "," & receiver_id & ") as money_cancel"
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function get_receive_cancel_count_e_law(ByVal dateBegin As Date, ByVal dateEnd As Date)
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " select dbo.get_receive_cancel_count_e_law(" & dayBegin & "," & dayEnd & ") as count_cancel"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_receive_cancel_count_e_law_new(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal receiver_id As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " select dbo.get_receive_cancel_count_e_law_new(" & dayBegin & "," & dayEnd & "," & receiver_id & ") as count_cancel"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_receive_cancel_money_e_law(ByVal dateBegin As Date, ByVal dateEnd As Date)
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " select dbo.get_receive_cancel_money_e_law(" & dayBegin & "," & dayEnd & ") as money_cancel"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_receive_cancel_money_e_law_new(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal receiver_id As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " select dbo.get_receive_cancel_money_e_law_new(" & dayBegin & "," & dayEnd & "," & receiver_id & ") as money_cancel"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_receive_cancel_count_n_law(ByVal dateBegin As Date, ByVal dateEnd As Date)
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " select dbo.get_receive_cancel_count_n_law(" & dayBegin & "," & dayEnd & ") as count_cancel"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_receive_cancel_count_n_law_new(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal receiver_id As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " select dbo.get_receive_cancel_count_n_law_new(" & dayBegin & "," & dayEnd & "," & receiver_id & ") as count_cancel"
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function get_receive_cancel_money_n_law(ByVal dateBegin As Date, ByVal dateEnd As Date)
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " select dbo.get_receive_cancel_money_n_law(" & dayBegin & "," & dayEnd & ") as money_cancel"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_receive_cancel_money_n_law_new(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal receiver_id As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " select dbo.get_receive_cancel_money_n_law_new(" & dayBegin & "," & dayEnd & "," & receiver_id & ") as money_cancel"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R3_018_e_law(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_018_e_law] @dateBegin = " & dayBegin & ",@dateEnd=" & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_Report_R3_018_e_law_new(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal receicer As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_018_e_law] @dateBegin = " & dayBegin & ",@dateEnd=" & dayEnd & " ,@RECEIVER_MONEY_ID='" & receicer & "' "
            command += ", @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_Report_R3_018_e_new(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal receicer As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_018_e_new] @dateBegin = " & dayBegin & ",@dateEnd=" & dayEnd & " ,@RECEIVER_MONEY_ID='" & receicer & "' "
            command += ", @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R3_018_1_Test(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_018_1_Test] @dateBegin = " & dayBegin & ",@dateEnd=" & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_Report_R3_018_1_by_TYPE(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal receipt_type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_018_1_by_TYPE] @dateBegin = " & dayBegin & ",@dateEnd=" & dayEnd & " ,@RECEIPT_TYPE=" & receipt_type
            command += " , @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_receive_cancel_count_e_law_by_type(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal receipt_type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " select [dbo].[get_receive_cancel_count_e_law_by_type](" & dayBegin & "," & dayEnd & "," & receipt_type & ") as cancel_count"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_receive_cancel_money_e_law_by_type(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal receipt_type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " select isnull([dbo].[get_receive_cancel_money_e_law_by_type](" & dayBegin & "," & dayEnd & "," & receipt_type & "),0) as cancel_amount"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R3_018_n_law(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_018_n_law] @dateBegin = " & dayBegin & ",@dateEnd=" & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '
        Public Function get_Report_R3_018_n_law_new(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal receiver_id As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_018_n_law_new] @dateBegin = " & dayBegin & ",@dateEnd=" & dayEnd & " ,@RECEIVER_MONEY_ID='" & receiver_id & "'"
            command += " , @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R3_019(ByVal ida As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Report_R3_019] @IDA = " & ida
            'command += ", @dateBeginName= '" & strDateBegin & "', @dateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'select [dbo].[get_amount_receive_by_type_and_date_V2](1,0,0) as amount
        Public Function get_Report_R3_017_Amount(ByVal r_type As Integer, ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal income As Integer) As Double
            Dim dt As New DataTable
            Dim amount As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " select [dbo].[get_amount_receive_by_type_and_date_V2](" & r_type & "," & dayBegin & "," & dayEnd & "," & income & ") as amount"
            dt = Queryds_Report(command)
            Try
                amount = dt(0)("amount")
            Catch ex As Exception

            End Try

            Return amount
        End Function
        '
        Public Function get_Report_R3_017_Amount_NEW(ByVal r_type As Integer, ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal income As Integer, ByVal receiver_id As Integer) As Double
            Dim dt As New DataTable
            Dim amount As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " select [dbo].[get_amount_receive_by_type_and_date_NEW](" & r_type & "," & dayBegin & "," & dayEnd & "," & income & "," & receiver_id & ") as amount"
            dt = Queryds_Report(command)
            Try
                amount = dt(0)("amount")
            Catch ex As Exception

            End Try

            Return amount
        End Function
        Public Function get_Report_R3_017_Amount_n_law(ByVal r_type As Integer, ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal income As Integer) As Double
            Dim dt As New DataTable
            Dim amount As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " select [dbo].[get_amount_receive_by_type_and_date_normal_law](" & r_type & "," & dayBegin & "," & dayEnd & "," & income & ") as amount"
            dt = Queryds_Report(command)
            Try
                amount = dt(0)("amount")
            Catch ex As Exception

            End Try

            Return amount
        End Function
        Public Function get_Report_R3_017_Amount_n_law_new(ByVal r_type As Integer, ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal income As Integer, ByVal receiver_id As Integer) As Double
            Dim dt As New DataTable
            Dim amount As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " select [dbo].[get_amount_receive_by_type_and_date_normal_law_new](" & r_type & "," & dayBegin & "," & dayEnd & "," & income & "," & receiver_id & ") as amount"
            dt = Queryds_Report(command)
            Try
                amount = dt(0)("amount")
            Catch ex As Exception

            End Try

            Return amount
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R3_002
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R3_002(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R3_002] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R3_003
        ''' </summary>
        ''' <param name="dateBegin">Parameter วันเริ่มต้น</param>
        ''' <param name="dateEnd">Parameter วันสิ้นสุด</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R3_003(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_003] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R3_004
        ''' </summary>
        ''' <param name="dateBegin">Parameter วันเริ่มต้น</param>
        ''' <param name="dateEnd">Parameter วันสิ้นสุด</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R3_004(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R3_004] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            'command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R3_005
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R3_005(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R3_005] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R3_006
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R3_006(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R3_006] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R3_012
        Public Function get_Report_R3_012(ByVal dateSelect As Date, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R3_012] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            command += ", @BUDGET_YEAR=" & bgyear
            dt = Queryds_Report(command)

            Return dt
        End Function

        ''' <summary>
        ''' ตารางแสดงรายงาน R3_007
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R3_007(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R3_007] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R3_008
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R3_008(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R3_008] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R3_009
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R3_009(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R3_009_1] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R3_010
        Public Function get_Report_R3_010(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R3_010] @dateSelect = " & daySelect
            'command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R3_011
        Public Function get_Report_R3_011(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R3_011] @dateSelect = " & daySelect
            'command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '-------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ตารางแสดงรายงาน R4_001
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R4_001(ByVal month_name As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            'Dim daySelect As Integer = convertDateToInteger(dateSelect)
            'Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R4_001] @MonthName = '" & month_name & "'" & " ,@bgYear=" & bgyear
            ' command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R9_004_cash
        Public Function get_Report_R9_004_cash(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R9_004_cash] @dateSelect = " & daySelect
            command += " , @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R9_004_withdraw_margin
        Public Function get_Report_R9_004_withdraw_margin(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R9_004_withdraw_margin] @dateSelect = " & daySelect
            command += " , @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R9_004_margin_cash_type3
        Public Function get_Report_R9_004_margin_cash_type3(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R9_004_margin_cash_type3] @dateSelect = " & daySelect
            command += " , @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R4_001_all_month
        Public Function get_Report_R4_001_all_month(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            'Dim daySelect As Integer = convertDateToInteger(dateSelect)
            'Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R4_001_all_month] @bgYear=" & bgyear
            ' command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R4_002
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R4_002(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R4_002] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R4_003
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R4_003(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R4_003] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R4_003_1
        Public Function get_Report_R4_003_1(ByVal bgyear As Integer, ByVal month As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            'Dim daySelect As Integer = convertDateToInteger(dateSelect)
            'Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R4_003_1] @BUDGET_YEAR = " & bgyear & " ,@month='" & month & "'"
            'command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R4_003_1_all_bgyear
        Public Function get_Report_R4_003_1_all_bgyear(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Report_R4_003_1_all_bgyear] @BUDGET_YEAR = " & bgyear
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R4_004
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R4_004(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R4_004] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R4_005
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R4_005(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R4_005] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R4_005_1
        Public Function get_Report_R4_005_1(ByVal bgyear As Integer, ByVal month As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Report_R4_005_1] @BUDGET_YEAR = " & bgyear & ",@MONTH_DIS='" & month & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R4_005_1_all
        Public Function get_Report_R4_005_1_all(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Report_R4_005_1_all] @BUDGET_YEAR =" & bgyear
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R4_006
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R4_006(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R4_006] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R4_006_1
        Public Function get_Report_R4_006_1(ByVal monthlive As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            'Dim daySelect As Integer = convertDateToInteger(dateSelect)
            'Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R4_006_1] @MONTH_LIVE = '" & monthlive & "' , @BUDGET_YEAR=" & bgyear
            'command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R4_007
        ''' </summary>
        ''' <param name="dateBegin">Parameter วันเริ่มต้น</param>
        ''' <param name="dateEnd">Parameter วันสิ้นสุด</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R4_007(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R4_007] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R4_008
        ''' </summary>
        ''' <param name="dateSelect">Parameter วันที่เลือก</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R4_008(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R4_008] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '-------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ตารางแสดงรายงาน R5_001
        ''' </summary>
        ''' <param name="dateBegin"></param>
        ''' <param name="dateEnd"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R5_001(ByVal dateBegin As Date, ByVal dateEnd As Date, money_type As Integer, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R5_001] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & ", @MONEY_TYPE_ID=" & money_type & ",@BUDGET_YEAR=" & bgyear
            command &= " ,@dateBeginName='" & strDateBegin & "' ,@dateEndName='" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R5_001_year
        Public Function get_Report_R5_001_year(ByVal money_type As Integer, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "

            Dim strDateBegin As String = ""
            Dim strDateEnd As String = ""
            command = " exec [BUDGETS].[get_Report_R5_001_year] @MONEY_TYPE_ID=" & money_type & ",@BUDGET_YEAR=" & bgyear
            command &= " ,@dateBeginName='" & strDateBegin & "' ,@dateEndName='" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R5_002
        ''' </summary>
        ''' <param name="dateBegin"></param>
        ''' <param name="dateEnd"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R5_002(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            'Dim strDateBegin As String = convertDateToString(dateBegin)
            'Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R5_002] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R5_012
        Public Function get_Report_R5_012(ByVal dateBegin As Date, ByVal dateEnd As Date, money_type As Integer, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R5_012] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & ", @MONEY_TYPE_ID=" & money_type & ",@BUDGET_YEAR=" & bgyear
            command &= " ,@dateBeginName='" & strDateBegin & "' ,@dateEndName='" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R5_012_benefit
        Public Function get_Report_R5_012_benefit(ByVal money_type As Integer, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            
            Dim strDateBegin As String = ""
            Dim strDateEnd As String = ""
            command = " exec [BUDGETS].[get_Report_R5_012_benefit]  @MONEY_TYPE_ID=" & money_type & ",@BUDGET_YEAR=" & bgyear
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_money_type_2_by_head_id(ByVal money_type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_money_type_2_by_head_id] @HEAD_ID=" & money_type
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R5_003
        ''' </summary>
        ''' <param name="dateBegin"></param>
        ''' <param name="dateEnd"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R5_003(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            'Dim strDateBegin As String = convertDateToString(dateBegin)
            'Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R5_003] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R5_004
        ''' </summary>
        ''' <param name="dateBegin"></param>
        ''' <param name="dateEnd"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R5_004() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            'Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            'Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            'Dim strDateBegin As String = convertDateToString(dateBegin)
            'Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R5_004] "
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R5_005
        ''' </summary>
        ''' <param name="dateBegin"></param>
        ''' <param name="dateEnd"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R5_005(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal MONEY_TYPE_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            'Dim strDateBegin As String = convertDateToString(dateBegin)
            'Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R5_005] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            command += ", @MONEY_TYPE_ID = " & MONEY_TYPE_ID
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R5_006
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R5_006(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R5_006] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R5_007
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R5_007() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            'Dim daySelect As Integer = convertDateToInteger(dateSelect)
            'Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R5_007]" ' @dateSelect = " & daySelect
            'command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R5_008
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R5_008(ByVal dateSelect As Date) As DataTable

            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R5_008] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R5_009
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R5_009(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R5_009] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R5_010
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R5_010(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R5_010] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R5_011
        Public Function getReportData_R5_011(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R5_011] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R5_013
        Public Function get_Report_R5_013(ByVal dateSelect As Date, ByVal m_type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R5_013] @dateSelect = " & daySelect & ",@m_type=" & m_type
            command += ", @dateSelectName= '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        '-------------------------------------------------------------------------------------------
        Public Function getReportData_R9_001(bill_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Report_R9_001]  @bg_id=" & bill_id '29
            dt = Queryds_Report(command)
            Return dt
        End Function

        Public Function get_Report_R9_001_debtor(bill_id As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Report_R9_001_debtor]  @bg_id='" & bill_id & "'" '29
            dt = Queryds_Report(command)
            Return dt
        End Function
        Public Function getReportData_R9_002(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R9_002] @dateSelect = " & daySelect
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R9_002_bill
        Public Function get_Report_R9_002_bill(ByVal bill As String, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Report_R9_002_bill] @billnumber = '" & bill & "' ,@BUDGET_YEAR=" & bgyear
            dt = Queryds_Report(command)

            Return dt
        End Function
        ''' <summary>
        ''' ตารางแสดงรายงาน R9_003 (ใบเสร็จรับเงิน)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R9_003(ByVal RECEIVE_MONEY_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Report_R9_003] @ReceiveMoneyID = " & RECEIVE_MONEY_ID
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R9_003_Return_Money(ByVal RETURN_MONEY_DEBTOR_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Report_R9_003_Return_Money] @RETURN_MONEY_DEBTOR_ID = " & RETURN_MONEY_DEBTOR_ID
            dt = Queryds_Report(command)

            Return dt
        End Function


        ''' <summary>
        ''' ตารางแสดงรายงาน R9_004 (ทะเบียนคุมเช็ค)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getReportData_R9_004(ByVal dateSelect As Date, ByVal chk_type As String, ByVal gr As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R9_004] @dateSelect = " & daySelect
            command += ", @dateSelectName= '" & strDateSelect & "'"
            command += " ,  @checkgroup='" & gr & "'"
            command += " , @type ='" & chk_type & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R1_002(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            'Dim strDateBegin As String = convertDateToString(dateBegin)
            'Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_002] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function getReportData_R1_001(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_001] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id & ",@BUDGET_YEAR=" & bgyear
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R1_001_TEST
        Public Function get_Report_R1_001_TEST(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_001_TEST] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id & ",@BUDGET_YEAR=" & bgyear
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R1_001_FDA(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_001_FDA] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id & ",@BUDGET_YEAR=" & bgyear
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'Public Function getReportData_R1_001(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer, ByVal bgyear As Integer) As DataTable
        '    Dim dt As New DataTable
        '    Dim command As String = " "
        '    Dim dayBegin As Integer = convertDateToInteger(dateBegin)
        '    Dim dayEnd As Integer = convertDateToInteger(dateEnd)
        '    Dim strDateBegin As String = convertDateToString(dateBegin)
        '    Dim strDateEnd As String = convertDateToString(dateEnd)
        '    command = " exec [BUDGETS].[get_Report_R1_001] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id & ",@BUDGET_YEAR=" & bgyear
        '    command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
        '    dt = Queryds_Report(command)

        '    Return dt
        'End Function
        'get_Report_R1_002_1
        Public Function get_Report_R1_002_1(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_002_1] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id & ",@BUDGET_YEAR=" & bgyear
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R1_003_1
        Public Function get_Report_R1_003_1(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_003_1] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id & ",@BUDGET_YEAR=" & bgyear
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R1_001_support
        Public Function get_Report_R1_001_support(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_001_support] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R1_003(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            'Dim strDateBegin As String = convertDateToString(dateBegin)
            'Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_003] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R1_004_1
        Public Function get_Report_R1_004_1(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal dept As Integer, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_004_1] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @DEPARTMENT_ID = " & dept & ",@BUDGET_YEAR=" & bgyear
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function get_Report_R1_029(ByVal dateBegin As Date, ByVal dept As Integer, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            ' Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            'Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_029] @dateBegin = " & dayBegin & ", @DEPARTMENT_ID = " & dept & ",@BUDGET_YEAR=" & bgyear
            command += ", @dateBeginName= '" & strDateBegin & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R1_005_1
        Public Function get_Report_R1_005_1(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal dept As Integer, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_005_1] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @DEPARTMENT_ID = " & dept & ",@BUDGET_YEAR=" & bgyear
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function getReportData_R1_004(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal dept As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_004] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @DEPARTMENT_ID = " & dept
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R1_004_transfer(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_004_transfer] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("transfer")) = False Then
                    value = dt(0)("transfer")
                End If
            End If

            Return value
        End Function
        Public Function get_sub_plan_7(ByVal bg_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_sub_plan_7] @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R1_004_diff(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_004_diff] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("diff")) = False Then
                    value = dt(0)("diff")
                End If
            End If

            Return value
        End Function

        Public Function getReportData_R1_004_po(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_004_po_no_po] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("po")) = False Then
                    value = dt(0)("po")
                End If
            End If

            Return value
        End Function

        Public Function getReportData_R1_005_po(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_005_po_no_po] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("po")) = False Then
                    value = dt(0)("po")
                End If
            End If

            Return value
        End Function

        Public Function getReportData_R1_006_po(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_006_po] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("po")) = False Then
                    value = dt(0)("po")
                End If
            End If

            Return value
        End Function

        Public Function getReportData_R1_007_po(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_007_po] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("po")) = False Then
                    value = dt(0)("po")
                End If
            End If

            Return value
        End Function

        Public Function getReportData_R1_009_po(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_009_po] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("po")) = False Then
                    value = dt(0)("po")
                End If
            End If

            Return value
        End Function

        Public Function get_Report_R1_004_no_po(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_004_no_po] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("po")) = False Then
                    value = dt(0)("po")
                End If
            End If

            Return value
        End Function

        Public Function get_Report_R1_005_no_po(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_005_no_po] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("po")) = False Then
                    value = dt(0)("po")
                End If
            End If

            Return value
        End Function

        Public Function getReportData_R1_004_moneyborrow(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_004_moneyborrow] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("moneyborrow")) = False Then
                    value = dt(0)("moneyborrow")
                End If
            End If

            Return value
        End Function

        Public Function getReportData_R1_005_moneyborrow(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_005_moneyborrow] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("moneyborrow")) = False Then
                    value = dt(0)("moneyborrow")
                End If
            End If

            Return value
        End Function

        Public Function getReportData_R1_006_moneyborrow(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_006_moneyborrow] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("moneyborrow")) = False Then
                    value = dt(0)("moneyborrow")
                End If
            End If

            Return value
        End Function

        Public Function getReportData_R1_007_moneyborrow(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_007_moneyborrow] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("moneyborrow")) = False Then
                    value = dt(0)("moneyborrow")
                End If
            End If

            Return value
        End Function

        Public Function getReportData_R1_009_moneyborrow(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_009_moneyborrow] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("moneyborrow")) = False Then
                    value = dt(0)("moneyborrow")
                End If
            End If

            Return value
        End Function

        Public Function getReportData_R1_004_burse(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_004_burse] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("burse")) = False Then
                    value = dt(0)("burse")
                End If
            End If

            Return value
        End Function

        Public Function getReportData_R1_005_burse(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_005_burse] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("burse")) = False Then
                    value = dt(0)("burse")
                End If
            End If

            Return value
        End Function

        Public Function getReportData_R1_006_burse(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_006_burse] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("burse")) = False Then
                    value = dt(0)("burse")
                End If
            End If

            Return value
        End Function

        Public Function getReportData_R1_007_burse(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_007_burse] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("burse")) = False Then
                    value = dt(0)("burse")
                End If
            End If

            Return value
        End Function

        Public Function getReportData_R1_009_burse(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_009_burse] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("burse")) = False Then
                    value = dt(0)("burse")
                End If
            End If

            Return value
        End Function

        Public Function getReportData_R1_005(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal dept As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            'Dim strDateBegin As String = convertDateToString(dateBegin)
            'Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_005] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @DEPARTMENT_ID = " & dept
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R1_006(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal dept As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_006] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @DEPARTMENT_ID = " & dept
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R1_006_1(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal dept As Integer, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_006_1] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @DEPARTMENT_ID = " & dept & ",@BUDGET_YEAR=" & bgyear
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R1_007_1
        Public Function get_Report_R1_007_1(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal dept As Integer, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_007_1] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @DEPARTMENT_ID = " & dept & ",@BUDGET_YEAR=" & bgyear
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function getReportData_R1_007(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal dept As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_007] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @DEPARTMENT_ID = " & dept
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R1_008(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal dept As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_008] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @DEPARTMENT_ID = " & dept
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R1_009(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_009] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R1_009_1
        Public Function get_Report_R1_009_1(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_009_1] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & ",@BUDGET_YEAR=" & bgyear
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R1_009_1_no_app(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_009_1_no_app] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & ",@BUDGET_YEAR=" & bgyear
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function getReportData_R1_010(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_010] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R1_010_1
        Public Function get_Report_R1_010_1(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_010_1] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function getReportData_R1_011(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_011] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R1_012(ByVal dateBegin As Date, ByVal dateEnd As Date, dept As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_012] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & ", @DEPARTMENT_ID=" & dept
            dt = Queryds_Report(command)
            Return dt
        End Function

        Public Function getReportData_R1_013(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_013] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            dt = Queryds_Report(command)
            Return dt
        End Function

        Public Function getReportData_R1_014(ByVal dateBegin As Date, ByVal dateEnd As Date, dept As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_014] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & ", @DEPARTMENT_ID=" & dept
            dt = Queryds_Report(command)
            Return dt
        End Function

        Public Function getReportData_R1_015(ByVal dateBegin As Date, ByVal dateEnd As Date, dept As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_015] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & ", @DEPARTMENT_ID=" & dept
            dt = Queryds_Report(command)
            Return dt
        End Function

        Public Function getReportData_R1_016(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As DataTable 'R1_001
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            'Dim strDateBegin As String = convertDateToString(dateBegin)
            'Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_016] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R1_017(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As DataTable ' R1_002
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            'Dim strDateBegin As String = convertDateToString(dateBegin)
            'Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_017] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R1_018(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal dept As Integer) As DataTable ' R1_004
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            'Dim strDateBegin As String = convertDateToString(dateBegin)
            'Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_018] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @DEPARTMENT_ID = " & dept
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R1_019(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal dept As Integer) As DataTable ' R1_005
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            'Dim strDateBegin As String = convertDateToString(dateBegin)
            'Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_019] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @DEPARTMENT_ID = " & dept
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R1_020(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal dept As Integer) As DataTable ' R1_006
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_020] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @DEPARTMENT_ID = " & dept
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R1_021(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal dept As Integer) As DataTable ' R1_007
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_021] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @DEPARTMENT_ID = " & dept
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R1_022(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal dept As Integer) As DataTable ' R1_008
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_022] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @DEPARTMENT_ID = " & dept
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R1_023(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer) As DataTable ' R1_002
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            'Dim strDateBegin As String = convertDateToString(dateBegin)
            'Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_023] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R1_024(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal dept As Integer) As DataTable ' R1_005
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            'Dim strDateBegin As String = convertDateToString(dateBegin)
            'Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_024] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @DEPARTMENT_ID = " & dept
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R1_025(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal dept As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_025] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @DEPARTMENT_ID = " & dept
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R1_026(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable ' R1_010
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_026] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            dt = Queryds_Report(command)

            Return dt
        End Function

        'get_Report_burse_App
        Public Function getReportData_burse(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer, app As String) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_burse_App] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id & ", @is_approve='" & app & "'"
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("burse")) = False Then
                    value = dt(0)("burse")
                End If
            End If

            Return value
        End Function

        Public Function get_Report_po(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer, app As String) As Double
            Dim dt As New DataTable
            Dim value As Double = 0.0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_po] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id & ", @is_approve='" & app & "'"
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("po")) = False Then
                    value = dt(0)("po")
                End If
            End If

            Return value
        End Function

        Public Function get_Report_R1_Period(ByVal dateBegin As Date, ByVal dateEnd As Date, bg_id As Integer, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_Period] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & ", @BUDGET_PLAN_ID=" & bg_id & ",@BUDGET_YEAR=" & bgyear
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R1_Period_support
        Public Function get_Report_R1_Period_support(ByVal dateBegin As Date, ByVal dateEnd As Date, bg_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_Period_support] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & ", @BUDGET_PLAN_ID=" & bg_id
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R1_001_support_1
        Public Function get_Report_R1_001_support_1(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_001_support_1] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id & ",@BUDGET_YEAR=" & bgyear
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R1_002_support
        Public Function get_Report_R1_002_support(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_002_support] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id & ",@BUDGET_YEAR=" & bgyear
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R1_003_support
        Public Function get_Report_R1_003_support(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bg_id As Integer, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_003_support] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @BUDGET_PLAN_ID = " & bg_id & ",@BUDGET_YEAR=" & bgyear
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_Report_R1_027
        Public Function get_Report_R1_027(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_027] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & ",@BUDGET_YEAR=" & bgyear
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R1_027_2(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_027_2] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & ",@BUDGET_YEAR=" & bgyear
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R1_028(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R1_028] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & ",@BUDGET_YEAR=" & bgyear
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_support_bg_key
        Public Function get_support_bg_key(ByVal bg_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_support_bg_key] @BUDGET_PLAN_ID=" & bg_id
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R3_transfer_cash(ByVal dateBegin As Date, moneytype As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_transfer_cash] @dateBegin = " & dayBegin & ", @MONEY_TYPE_ID=" & moneytype
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function get_Report_R3_transfer_cash_sum(ByVal dateBegin As Date, moneytype As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_transfer_cash_sum] @dateBegin = " & dayBegin & ", @MONEY_TYPE_ID=" & moneytype
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function get_Report_R3_transfer_check(ByVal dateBegin As Date, moneytype As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_transfer_check] @dateBegin = " & dayBegin & ", @MONEY_TYPE_ID=" & moneytype
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R3_transfer_check_sum(ByVal dateBegin As Date, moneytype As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_transfer_check_sum] @dateBegin = " & dayBegin & ", @MONEY_TYPE_ID=" & moneytype
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_R3_receive_cash 
        Public Function get_Report_R3_receive_cash(ByVal dateBegin As Date, moneytype As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_receive_cash] @dateBegin = " & dayBegin & ", @MONEY_TYPE_ID=" & moneytype
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R3_receive_cash_sum(ByVal dateBegin As Date, moneytype As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_receive_cash_sum] @dateBegin = " & dayBegin & ", @MONEY_TYPE_ID=" & moneytype
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R3_receive_check(ByVal dateBegin As Date, moneytype As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_receive_check] @dateBegin = " & dayBegin & ", @MONEY_TYPE_ID=" & moneytype
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R3_receive_check_sum(ByVal dateBegin As Date, moneytype As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_receive_check_sum] @dateBegin = " & dayBegin & ", @MONEY_TYPE_ID=" & moneytype
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R3_maintain_cash(ByVal dateBegin As Date, moneytype As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_maintain_cash] @dateBegin = " & dayBegin & ", @MONEY_TYPE_ID=" & moneytype
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R3_maintain_cash_sum(ByVal dateBegin As Date, moneytype As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_maintain_cash_sum] @dateBegin = " & dayBegin & ", @MONEY_TYPE_ID=" & moneytype
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R3_maintain_check(ByVal dateBegin As Date, moneytype As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_maintain_check] @dateBegin = " & dayBegin & ", @MONEY_TYPE_ID=" & moneytype
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R3_maintain_check_sum(ByVal dateBegin As Date, moneytype As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_maintain_check_sum] @dateBegin = " & dayBegin & ", @MONEY_TYPE_ID=" & moneytype
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R3_removecash(ByVal dateBegin As Date, moneytype As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_removecash] @dateBegin = " & dayBegin & ", @MONEY_TYPE_ID=" & moneytype
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_R3_2_bg_amount(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_2_bg_amount] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        'get_R3_3_bg_amount_sum
        Public Function get_R3_3_bg_amount_sum(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_3_bg_amount_sum] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        ' get_R3_2_bg_amount_sum
        Public Function get_R3_2_bg_amount_sum(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_2_bg_amount_sum] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        'get_R3_5_bg_amount_sum
        Public Function get_R3_5_bg_amount_sum(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_5_bg_amount_sum] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        'get_R3_2_Out_bg_amount_sum
        Public Function get_R3_2_Out_bg_amount_sum(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_2_Out_bg_amount_sum] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        'get_R3_3_out_bg_amount_sum
        Public Function get_R3_3_out_bg_amount_sum(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_3_out_bg_amount_sum] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        'get_R3_5_out_bg_amount_sum
        Public Function get_R3_5_out_bg_amount_sum(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_5_out_bg_amount_sum] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        'get_R3_2_Out_bg_bank_amount_sum
        Public Function get_R3_2_Out_bg_bank_amount_sum(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_2_Out_bg_bank_amount_sum] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        'get_R3_3_out_bg_bank_amount_sum
        Public Function get_R3_3_out_bg_bank_amount_sum(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_3_out_bg_bank_amount_sum] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        'get_R3_5_out_bg_bank_amount_sum
        Public Function get_R3_5_out_bg_bank_amount_sum(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_5_out_bg_bank_amount_sum] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        'get_R3_2_nation_amount_sum
        Public Function get_R3_2_nation_amount_sum(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_2_nation_amount_sum] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        'get_R3_3_nation_amount_sum

        Public Function get_R3_3_nation_amount_sum(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_3_nation_amount_sum] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        'get_R3_5_nation_amount_sum

        Public Function get_R3_5_nation_amount_sum(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_5_nation_amount_sum] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function

        'get_R3_3_bg_amount
        Public Function get_R3_3_bg_amount(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_3_bg_amount] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        'get_R3_3_out_bg_amount
        Public Function get_R3_3_out_bg_amount(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_3_out_bg_amount] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        ' get_R3_3_out_bg_bank_amount
        Public Function get_R3_3_out_bg_bank_amount(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_3_out_bg_bank_amount] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        'get_R3_3_nation_amount
        Public Function get_R3_3_nation_amount(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_3_nation_amount] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        ' get_R3_2_Out_bg_amount
        Public Function get_R3_2_Out_bg_amount(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_2_Out_bg_amount] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        'get_R3_2_Out_bg_bank_amount
        Public Function get_R3_2_Out_bg_bank_amount(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_2_Out_bg_bank_amount] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        Public Function get_R3_2_nation_amount(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_2_nation_amount] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("nation_amount")) = False Then
                    value = dt(0)("nation_amount")
                End If

            End If

            Return value
        End Function
        ' get_R3_4_margin_bank
        Public Function get_R3_4_margin_bank(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_4_margin_bank] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("amount")) = False Then
                    value = dt(0)("amount")
                End If

            End If

            Return value
        End Function
        ' get_R3_4_margin_cash
        Public Function get_R3_4_margin_cash(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_4_margin_cash] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("amount")) = False Then
                    value = dt(0)("amount")
                End If

            End If

            Return value
        End Function

        'get_R3_4_margin_cash_sum
        Public Function get_R3_4_margin_cash_sum(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_4_margin_cash_sum] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("amount")) = False Then
                    value = dt(0)("amount")
                End If

            End If

            Return value
        End Function

        Public Function get_R3_2_margin_cash(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_2_margin_cash] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("margin_cash")) = False Then
                    value = dt(0)("margin_cash")
                End If

            End If

            Return value
        End Function

        Public Function get_R3_2_margin_cash_sum(ByVal dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_2_margin_cash] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("margin_cash")) = False Then
                    value = dt(0)("margin_cash")
                End If

            End If

            Return value
        End Function

        Public Function get_R3_2_margin_bank(dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_2_margin_bank] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("margin_bank")) = False Then
                    value = dt(0)("margin_bank")
                End If

            End If

            Return value
        End Function
        'get_R3_2_margin_bank_sum
        Public Function get_R3_2_margin_bank_sum(dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_2_margin_bank_sum] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("margin_bank")) = False Then
                    value = dt(0)("margin_bank")
                End If

            End If

            Return value
        End Function
        'get_R3_4_margin_bank_sum
        Public Function get_R3_4_margin_bank_sum(dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_4_margin_bank_sum] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("amount")) = False Then
                    value = dt(0)("amount")
                End If

            End If

            Return value
        End Function

        Public Function get_R3_5_bg_amount(dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_5_bg_amount] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        'get_R3_5_out_bg_amount
        Public Function get_R3_5_out_bg_amount(dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_5_out_bg_amount] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        'get_R3_5_out_bg_bank_amount
        Public Function get_R3_5_out_bg_bank_amount(dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_5_out_bg_bank_amount] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        Public Function get_R3_5_nation_amount(dateBegin As Date) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[get_R3_5_nation_amount] @dateBegin=" & dayBegin
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("bg_amount")) = False Then
                    value = dt(0)("bg_amount")
                End If

            End If

            Return value
        End Function
        Public Function get_Report_R5_004_receive_amount(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal moneytype As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R5_004_receive_amount] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @MONEY_TYPE_ID = " & moneytype
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("r_amount")) = False Then
                    value = CDbl(dt(0)("r_amount"))
                End If
            End If
            Return value
        End Function
        Public Function get_Report_R5_004_deposit_amount(ByVal dateBegin As Date, ByVal dateEnd As Date, ByVal moneytype As Integer) As Double
            Dim dt As New DataTable
            Dim value As Double = 0
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            command = " exec [BUDGETS].[get_Report_R5_004_deposit_amount] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd & " , @MONEY_TYPE_ID = " & moneytype
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("r_amount")) = False Then
                    value = CDbl(dt(0)("r_amount"))
                End If
            End If
            Return value
        End Function
        Public Function chk_rebill(ByVal dateBegin As Date, ByVal id As Integer) As Boolean
            Dim dt As New DataTable
            Dim bool As Boolean = False
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            command = " exec [BUDGETS].[chk_rebill] @dateint = " & dayBegin & " , @DEBTOR_ID = " & id
            dt = Queryds_Report(command)
            If dt.Rows.Count > 0 Then
                bool = True
            Else
                bool = False
            End If
            Return bool
        End Function
        'chk_rebill

        Public Function getReportData_R3_009_Amount(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            'Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R3_009] @dateSelect = " & daySelect
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R3_009_Amount_Margin(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            'Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R3_009_Margin] @dateSelect = " & daySelect
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R3_009_TEMP(ByVal dateSelect As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim daySelect As Integer = convertDateToInteger(dateSelect)
            Dim strDateSelect As String = convertDateToString(dateSelect)
            command = " exec [BUDGETS].[get_Report_R3_009_TEMP] @dateSelect = " & daySelect
            command += " ,@dateSelectName = '" & strDateSelect & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function getReportData_R2_026(ByVal dateBegin As Date, ByVal dateEnd As Date) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            Dim dayBegin As Integer = convertDateToInteger(dateBegin)
            Dim dayEnd As Integer = convertDateToInteger(dateEnd)
            Dim strDateBegin As String = convertDateToString(dateBegin)
            Dim strDateEnd As String = convertDateToString(dateEnd)
            command = " exec [BUDGETS].[get_Report_R2_026] @dateBegin = " & dayBegin & ", @dateEnd = " & dayEnd
            command += ", @dateBeginName= '" & strDateBegin & "', @DateEndName= '" & strDateEnd & "'"
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R7_Slip(ByVal idrun As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Report_R7_Slip] @idrun=" & idrun
            dt = Queryds_Report(command)

            Return dt
        End Function
        Public Function get_Report_R7_Slip_AddPayDate() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_Report_R7_Slip_AddPayDate] "
            dt = Queryds_Report(command)

            Return dt
        End Function
    End Class
    Public Class MoneyExt
        Public Function NumberToThaiWord(ByVal InputNumber As Double) As String
            If InputNumber = 0 Then
                NumberToThaiWord = "ศูนย์บาทถ้วน"
                Return NumberToThaiWord
            End If

            Dim NewInputNumber As String
            NewInputNumber = InputNumber.ToString("###0.00")

            If CDbl(NewInputNumber) >= 10000000000000 Then
                NumberToThaiWord = ""
                Return NumberToThaiWord
            End If

            Dim tmpNumber(2) As String
            Dim FirstNumber As String
            Dim LastNumber As String

            tmpNumber = NewInputNumber.Split(CChar("."))
            FirstNumber = tmpNumber(0)
            LastNumber = tmpNumber(1)

            Dim nLength As Integer = 0
            nLength = CInt(FirstNumber.Length)

            Dim i As Integer
            Dim CNumber As Integer = 0
            Dim CNumberBak As Integer = 0
            Dim strNumber As String = ""
            Dim strPosition As String = ""
            Dim FinalWord As String = ""
            Dim CountPos As Integer = 0

            For i = nLength To 1 Step -1
                CNumberBak = CNumber
                CNumber = CInt(FirstNumber.Substring(CountPos, 1))

                If CNumber = 0 AndAlso i = 7 Then
                    strPosition = "ล้าน"
                ElseIf CNumber = 0 Then
                    strPosition = ""
                Else
                    strPosition = PositionToText(i)
                End If

                If CNumber = 2 AndAlso strPosition = "สิบ" Then
                    strNumber = "ยี่"
                ElseIf CNumber = 1 AndAlso strPosition = "สิบ" Then
                    strNumber = ""
                ElseIf CNumber = 1 AndAlso strPosition = "ล้าน" AndAlso nLength >= 8 Then
                    If CNumberBak = 0 Then
                        strNumber = "หนึ่ง"
                    Else
                        strNumber = "เอ็ด"
                    End If
                ElseIf CNumber = 1 AndAlso strPosition = "" AndAlso nLength > 1 Then
                    strNumber = "เอ็ด"
                Else
                    strNumber = NumberToText(CNumber)
                End If

                CountPos = CountPos + 1

                FinalWord = FinalWord & strNumber & strPosition
            Next

            CountPos = 0
            CNumberBak = 0
            nLength = CInt(LastNumber.Length)

            Dim Stang As String = ""
            Dim FinalStang As String = ""

            If CDbl(LastNumber) > 0.0 Then
                For i = nLength To 1 Step -1
                    CNumberBak = CNumber
                    CNumber = CInt(LastNumber.Substring(CountPos, 1))

                    If CNumber = 1 AndAlso i = 2 Then
                        strPosition = "สิบ"
                    ElseIf CNumber = 0 Then
                        strPosition = ""
                    Else
                        strPosition = PositionToText(i)
                    End If

                    If CNumber = 2 AndAlso strPosition = "สิบ" Then
                        Stang = "ยี่"
                    ElseIf CNumber = 1 AndAlso i = 2 Then
                        Stang = ""
                    ElseIf CNumber = 1 AndAlso strPosition = "" AndAlso nLength > 1 Then
                        If CNumberBak = 0 Then
                            Stang = "หนึ่ง"
                        Else
                            Stang = "เอ็ด"
                        End If
                    Else
                        Stang = NumberToText(CNumber)
                    End If

                    CountPos = CountPos + 1

                    FinalStang = FinalStang & Stang & strPosition
                Next

                FinalStang = FinalStang & "สตางค์"
            Else
                FinalStang = ""
            End If

            Dim SubUnit As String
            If FinalStang = "" Then
                SubUnit = "บาทถ้วน"
            Else
                If CDbl(FirstNumber) <> 0 Then
                    SubUnit = "บาท"
                Else
                    SubUnit = ""
                End If
            End If

            NumberToThaiWord = FinalWord & SubUnit & FinalStang
        End Function
        Private Function NumberToText(ByVal CurrentNum As Integer) As String
            Dim _nText As String = ""

            Select Case CurrentNum
                Case 0
                    _nText = ""
                Case 1
                    _nText = "หนึ่ง"
                Case 2
                    _nText = "สอง"
                Case 3
                    _nText = "สาม"
                Case 4
                    _nText = "สี่"
                Case 5
                    _nText = "ห้า"
                Case 6
                    _nText = "หก"
                Case 7
                    _nText = "เจ็ด"
                Case 8
                    _nText = "แปด"
                Case 9
                    _nText = "เก้า"
            End Select

            NumberToText = _nText
        End Function
        Private Function PositionToText(ByVal CurrentPos As Integer) As String
            Dim _nPos As String = ""

            Select Case CurrentPos
                Case 0
                    _nPos = ""
                Case 1
                    _nPos = ""
                Case 2
                    _nPos = "สิบ"
                Case 3
                    _nPos = "ร้อย"
                Case 4
                    _nPos = "พัน"
                Case 5
                    _nPos = "หมื่น"
                Case 6
                    _nPos = "แสน"
                Case 7
                    _nPos = "ล้าน"
                Case 8
                    _nPos = "สิบ"
                Case 9
                    _nPos = "ร้อย"
                Case 10
                    _nPos = "พัน"
                Case 11
                    _nPos = "หมื่น"
                Case 12
                    _nPos = "แสน"
                Case 13
                    _nPos = "ล้าน"
            End Select

            PositionToText = _nPos
        End Function
    End Class
    Public Class Salary
        Inherits ConnectDatabase
        Public Function get_salary(ByVal bgyear As Integer, ByVal monthnum As Integer, ByVal per As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_salary] @BUDGET_YEAR = " & bgyear & ",@Month_number=" & monthnum & ",@per_type=" & per
            dt = Queryds_Report(command)

            Return dt
        End Function

        Public Function get_salary_list(ByVal salary_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_salary_list] @SALARY_ID = " & salary_id
            dt = Queryds_Report(command)

            Return dt
        End Function
        'get_salary_paylist_amount
        Public Function get_salary_paylist_amount(ByVal salary_id As Integer, ByVal sp As Integer) As Double
            Dim dt As New DataTable
            Dim amount As Double = 0
            Dim command As String = " "
            command = " exec [BUDGETS].[get_salary_paylist_amount] @SALARY_ID = " & salary_id & ",@sp=" & sp
            dt = Queryds_Report(command)

            If dt.Rows.Count > 0 Then
                Try
                    amount = CDbl(dt(0)("AMOUNT"))
                Catch ex As Exception
                    amount = 0
                End Try

            End If

            Return amount
        End Function
        '
        Public Function get_salary_paylist_input() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [BUDGETS].[get_salary_paylist_input] "
            dt = Queryds_Report(command)

            Return dt
        End Function
    End Class
    Public Class LGTCPN
        Inherits ConnectDatabass_CPN
        Public Function SP_LCNSID_NM_ALL() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_LCNSID_NM_ALL] "
            dt = Queryds(command)
            Return dt
        End Function
        Public Function SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(ByVal lcnsid As Integer, ByVal identify As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec dbo.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY @lcnsid=" & lcnsid & " ,@identify='" & identify & "'"
            dt = Queryds(command)
            Return dt
        End Function
    End Class
    Public Class FDA_FEE
        Inherits ConnectDatabass_FDA_FEE
        Public Function SC_LCNSID_NM(ByVal lcnsid As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " select dbo.SC_LCNSID_NM('" & lcnsid & "') as fullname"
            dt = Queryds(command)
            Return dt
        End Function
        Public Function SP_get_receipt_by_feeabbr_and_feeno(ByVal feeno As String, ByVal feeabbr As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec dbo.SP_get_receipt_by_feeabbr_and_feeno @feeno='" & feeno & "', @feeabbr='" & feeabbr & "'"
            dt = Queryds(command)
            Return dt
        End Function

        Public Function SP_get_receipt_by_feeabbr_and_feeno_group_sum(ByVal feeno As String, ByVal dvcd As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec dbo.SP_get_receipt_by_feeabbr_and_feeno_group_sum @feeno='" & feeno & "' ,@dvcd=" & dvcd
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_get_receipt_by_feeabbr_and_feeno_group_sum2(ByVal feeno As String, ByVal dvcd As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec dbo.SP_get_receipt_by_feeabbr_and_feeno_group_sum2 @feeno='" & feeno & "' ,@dvcd=" & dvcd
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_get_receipt_by_feeabbr_and_feeno_group_sum2_L44(ByVal feeno As String, ByVal dvcd As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec dbo.SP_get_receipt_by_feeabbr_and_feeno_group_sum2_L44 @feeno='" & feeno & "' ,@dvcd=" & dvcd
            dt = Queryds(command)
            Return dt
        End Function
        Public Function SP_GET_FEEDTL(ByVal feeno As String, ByVal dvcd As Integer, ByVal pvncd As Integer, ByVal feetpcd As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec dbo.SP_GET_FEEDTL @feeno='" & feeno & "' ,@dvcd=" & dvcd & ",@pvncd=" & pvncd & ",@feetpcd=" & feetpcd
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_GET_FEEDTL_V2(ByVal feeno As String, ByVal dvcd As Integer, ByVal pvncd As Integer, ByVal feeabbr As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec dbo.SP_GET_FEEDTL_V2 @feeno='" & feeno & "' ,@dvcd=" & dvcd & ",@pvncd=" & pvncd & ",@feeabbr='" & feeabbr & "'"
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_GET_FEEDTL_V3(ByVal ida As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec dbo.SP_GET_FEEDTL_V3 @ida=" & ida
            dt = Queryds(command)
            Return dt
        End Function
        Public Function SP_get_receipt_by_feeabbr_and_feeno_receipt(ByVal feeno As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec dbo.SP_get_receipt_by_feeabbr_and_feeno_receipt @feeno='" & feeno & "'"
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_get_receipt_by_dvcd_and_feeno_receipt(ByVal feeno As String, ByVal dvcd As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec dbo.SP_get_receipt_by_dvcd_and_feeno_receipt @feeno='" & feeno & "' ,@dvcd=" & dvcd
            dt = Queryds(command)
            Return dt
        End Function
        Public Function SP_GET_RECEIPT_TYPE() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec dbo.SP_GET_RECEIPT_TYPE "
            dt = Queryds(command)
            Return dt
        End Function

        Public Function SP_get_receipt_by_bgyear(ByVal bgyear As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec dbo.SP_get_receipt_by_bgyear @bgyear=" & bgyear
            dt = Queryds(command)
            Return dt
        End Function
        Public Function SP_get_receipt_by_feeabbr_and_feeno_group_sum_old(ByVal feeno As String, ByVal dvcd As Integer, ByVal feeabbr As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command &= " select f.feeno , f.feetpnm " ' --+' '+ f.feedtl + ' เลขที่ ' + cast(cast(right(f.appvno,5) as int) as nvarchar(max)) + '/' + left(f.appvno,2) as feetpnm"
            command &= " , f.ref01, f.ref02 , f.lcnsid ,sum(f.amt) as amt ,f.feeabbr "
            command &= " , right(f.feeno,5) as fee_no_5 , left(f.feeno,2) as year_fee ,f.rcptst,de.DEPARTMENT_NAME"
            command &= " ,[dbo].SC_LCNSID_NM_V3(f.lcnsid,f.lctnmcd,f.lcnscd,f.lctcd,f.prnfeest) as fullname"
            command &= " ,f.dvcd, f.pvncd,f.feetpcd "
            command &= " from openquery(lgtcpn,'select f.feeno , t.feetpnm ,d.appvno , f.ref01 ,b.ref02, f.lcnsid ,d.amt ,t.feeabbr ,t.feedtl"
            command &= " ,f.rcptst ,f.lctnmcd,f.lcnscd,f.lctcd"
            command &= " ,f.dvcd, f.pvncd,f.feetpcd,f.prnfeest"
            command &= " from fda.fee f"
            command &= " join feedtl d on d.dvcd = f.dvcd and f.pvncd = d.pvncd and f.feeno = d.feeno"
            command &= " join feetype t on f.feeabbr = t.feeabbr"
            command &= " join feebank b on f.ref01 = b.ref01"
            command &= "            where f.feeno =''" & feeno & "'' and f.dvcd=" & dvcd & " and f.feeabbr=''" & feeabbr & "''"
            command &= " ;') f"
            command &= " left join [FDA_BG].[dbo].[MAS_RECEIPT_DEPARTMENT] de on f.dvcd = de.DVCD"
            command &= " group by f.feeno , f.feetpnm , f.ref01 , f.lcnsid "
            command &= "  ,f.feeabbr,f.rcptst, f.ref02,de.DEPARTMENT_NAME,f.dvcd, f.pvncd,f.feetpcd,f.lctnmcd,f.lcnscd,f.lctcd,f.prnfeest --,f.appvno,f.feedtl"
            command &= " order by f.feeno,f.lcnsid"

            dt = Queryds(command)
            Return dt
        End Function
        Public Function SP_get_receipt_by_feeabbr_and_feeno_group_sum_old2(ByVal feeno As String, ByVal dvcd As Integer, ByVal feeabbr As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command &= " select f.feeno , f.feetpnm " ' --+' '+ f.feedtl + ' เลขที่ ' + cast(cast(right(f.appvno,5) as int) as nvarchar(max)) + '/' + left(f.appvno,2) as feetpnm"
            command &= " , f.ref01, f.ref02 , f.lcnsid ,sum(f.amt) as amt ,f.feeabbr "
            command &= " , right(f.feeno,5) as fee_no_5 , left(f.feeno,2) as year_fee ,f.rcptst,de.DEPARTMENT_NAME"
            command &= " ,'' as fullname ,f.prnfeest,f.lcnscd"
            command &= " ,f.dvcd, f.pvncd,f.feetpcd, 0 as acc_type "
            command &= " from openquery(lgtcpn,'select f.feeno , t.feetpnm ,d.appvno , f.ref01 ,b.ref02, f.lcnsid ,d.amt ,t.feeabbr ,t.feedtl"
            command &= " ,f.rcptst ,f.lctnmcd,f.lcnscd,f.lctcd"
            command &= " ,f.dvcd, f.pvncd,f.feetpcd,f.prnfeest "
            command &= " from fda.fee f"
            command &= " join feedtl d on d.dvcd = f.dvcd and f.pvncd = d.pvncd and f.feeno = d.feeno"
            command &= " join feetype t on f.feeabbr = t.feeabbr and t.pvncd = 10"
            command &= " join feebank b on f.ref01 = b.ref01"
            command &= "            where f.feeno =''" & feeno & "'' and f.dvcd=" & dvcd & " and f.feeabbr=''" & feeabbr & "''"
            command &= " ;') f"
            command &= " left join [LINK160].[FDA_BG].[dbo].[MAS_RECEIPT_DEPARTMENT] de on f.dvcd = de.DVCD"
            command &= " group by f.feeno , f.feetpnm , f.ref01 , f.lcnsid "
            command &= "  ,f.feeabbr,f.rcptst, f.ref02,de.DEPARTMENT_NAME,f.dvcd, f.pvncd,f.feetpcd,f.lctnmcd,f.lcnscd,f.lctcd,f.prnfeest --,f.appvno,f.feedtl"
            command &= " order by f.feeno,f.lcnsid"

            dt = Queryds_103(command)
            Return dt
        End Function
        Public Function SP_get_receipt_by_ref01_ref02(ByVal ref01 As String, ByVal ref02 As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command &= " select f.feeno , f.feetpnm " ' --+' '+ f.feedtl + ' เลขที่ ' + cast(cast(right(f.appvno,5) as int) as nvarchar(max)) + '/' + left(f.appvno,2) as feetpnm"
            command &= " , f.ref01, f.ref02 , f.lcnsid ,sum(f.amt) as amt ,f.feeabbr "
            command &= " , right(f.feeno,5) as fee_no_5 , left(f.feeno,2) as year_fee ,f.rcptst,de.DEPARTMENT_NAME"
            command &= " ,'' as fullname ,f.prnfeest,f.lcnscd"
            command &= " ,f.dvcd, f.pvncd,f.feetpcd "
            command &= " from openquery(lgtcpn,'select f.feeno , t.feetpnm ,d.appvno , f.ref01 ,b.ref02, f.lcnsid ,d.amt ,t.feeabbr ,t.feedtl"
            command &= " ,f.rcptst ,f.lctnmcd,f.lcnscd,f.lctcd"
            command &= " ,f.dvcd, f.pvncd,f.feetpcd,f.prnfeest"
            command &= " from fda.fee f"
            command &= " join feedtl d on d.dvcd = f.dvcd and f.pvncd = d.pvncd and f.feeno = d.feeno"
            command &= " join feetype t on f.feeabbr = t.feeabbr and t.pvncd = 10"
            command &= " join feebank b on f.ref01 = b.ref01"
            command &= "            where b.ref01 =''" & ref01 & "'' and b.ref02=''" & ref02 & "''"
            command &= " ;') f"
            command &= " left join [LINK160].[FDA_BG].[dbo].[MAS_RECEIPT_DEPARTMENT] de on f.dvcd = de.DVCD"
            command &= " group by f.feeno , f.feetpnm , f.ref01 , f.lcnsid "
            command &= "  ,f.feeabbr,f.rcptst, f.ref02,de.DEPARTMENT_NAME,f.dvcd, f.pvncd,f.feetpcd,f.lctnmcd,f.lcnscd,f.lctcd,f.prnfeest --,f.appvno,f.feedtl"
            command &= " order by f.feeno,f.lcnsid"

            dt = Queryds_103(command)
            Return dt
        End Function
        Public Function Q_get_old_fee(ByVal ref01 As String, ByVal ref02 As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "  select feeabbr + ' ' + cast(cast(cast(right(feeno,5) as nvarchar(max)) as int) as nvarchar(max))  +'/' + cast(left(feeno,2) as nvarchar(max)) as feeno_format "
            command &= " ,*"
            command &= " from openquery(LGTCPN,'select f.*,b.ref02 from fee f "
            command &= " join feebank b on f.ref01 = b.ref01 "
            command &= " where f.rcptst =0 and f.ref01=''" & ref01 & "'' and b.ref02=''" & ref02 & "''"
            command &= " ;')"

            dt = Queryds_103(command)
            Return dt
        End Function
        Public Function get_lcn_name_type1(ByVal lcnsid As Integer, ByVal lcnscd As Integer) As String
            Dim dt As New DataTable
            Dim str_name As String = ""
            Dim command As String = " "
            command &= " select top(1) isnull(l.thanm,'') as fullname"
            command &= " from openquery(LGTCPN,'select thanm, prefixcd, suffixcd,lcnsid,thalnm,lcnscd,lctcd from syslcnsnm "
            command &= "  where lcnsid =" & lcnsid & " And lcnscd = " & lcnscd & " "
            command &= " ;') SLN"
            command &= " left join LGTCPN.[dbo].[sysprefix] pr on SLN.prefixcd = pr.prefixcd"
            command &= " left join LGTCPN.[dbo].[syssuffix] sf on SLN.suffixcd = sf.suffixcd"
            command &= " left join (select lcnsid,lctnmcd,thanm,lctcd"
            command &= " from openquery(LGTCPN,'select * from syslctnm where lcnsid = " & lcnsid & " "
            command &= " ;') ) l on SLN.lcnsid = l.lcnsid"
            command &= " left join (select * from openquery(LGTCPN,'select * from syslctaddr where lcnsid = " & lcnsid & " "
            command &= " ;')) a on a.lcnsid = sln.lcnsid "
            dt = Queryds_103(command)
            For Each dr As DataRow In dt.Rows
                Try
                    str_name = dr("fullname")
                Catch ex As Exception

                End Try

            Next
            Return str_name
        End Function
        Public Function get_lcn_name_type2(ByVal lcnsid As Integer, ByVal lcnscd As Integer) As String
            Dim dt As New DataTable
            Dim str_name As String = ""
            Dim command As String = " "
            command &= " Select top(1)"
            command &= " isnull(pr.thanm,'') + ' ' + isnull(SLN.thanm,'') + ' ' + "
            command &= " case when sln.thalnm is null then isnull(sf.thanm,'') else isnull(sln.thalnm,'') end as fullname"
            command &= " from openquery(LGTCPN,'select thanm, prefixcd, suffixcd,lcnsid,thalnm,lcnscd,lctcd from syslcnsnm"
            command &= "  where lcnsid =" & lcnsid & " And lcnscd = " & lcnscd & " "
            command &= " ;') SLN"
            command &= " left join LGTCPN.[dbo].[sysprefix] pr on SLN.prefixcd = pr.prefixcd"
            command &= " left join LGTCPN.[dbo].[syssuffix] sf on SLN.suffixcd = sf.suffixcd"
            command &= " left join (select lcnsid,lctnmcd,thanm,lctcd"
            command &= " from openquery(LGTCPN,'select * from syslctnm where lcnsid = " & lcnsid & " "
            command &= " ;') ) l on SLN.lcnsid = l.lcnsid"
            command &= " left join (select * from openquery(LGTCPN,'select * from syslctaddr where lcnsid = " & lcnsid & " "
            command &= " ;')) a on a.lcnsid = sln.lcnsid "
            dt = Queryds_103(command)
            For Each dr As DataRow In dt.Rows
                Try
                    str_name = dr("fullname")
                Catch ex As Exception

                End Try

            Next
            Return str_name
        End Function
        Public Function get_dvcd_auto(ByVal feeno As String, ByVal feeabbr As String) As String
            Dim str_dvcd As String = ""
            Dim dt As New DataTable
            Dim command As String = " "
            command &= " select top(1) * "
            command &= " from openquery(LGTCPN,'select t.dvcd"
            command &= " from fee f"
            command &= " join feetype t on f.feeabbr = t.feeabbr"
            command &= " where f.feeno =''" & feeno & "'' and t.feeabbr=''" & feeabbr & "''"
            command &= " ;') f"

            dt = Queryds_103(command)
            For Each dr As DataRow In dt.Rows
                Try
                    str_dvcd = dr("dvcd")
                Catch ex As Exception

                End Try

            Next

            Return str_dvcd
        End Function

        'SP_GET_FEEDTL
        Public Function SP_GET_FEEDTL_OLD(ByVal feeno As String, ByVal dvcd As Integer, ByVal pvncd As Integer, ByVal feeabbr As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "

            command &= " select ROW_NUMBER() OVER(ORDER BY appvno ASC) AS IDA,amt"
            command &= " ,case when appvno is not null then isnull(feetpnm,'') +' '+ isnull(feedtl,'') + ' ' +  case when appvno is not null then cast(cast(right(appvno,5) as int) as nvarchar(max)) + '/' + left(appvno,2) else '' end  else isnull(feetpnm,'') end as feetpnm ,appvno,feedtl,feeabbr,rcvcd ,rcvabbr,rcvno,appabbr,appvcd"
            command &= " from openquery(lgtcpn,'select t.feetpnm ,appvno,feedtl,d.amt,t.feeabbr ,rcvcd ,rcvabbr,rcvno,appabbr,appvcd"
            command &= " from feedtl d"
            command &= " join feetype t on d.feetpcd = t.feetpcd"
            command &= "           where d.feeno =" & feeno & " and d.dvcd=" & dvcd & " and t.feeabbr =''" & feeabbr & "'' and t.pvncd =10"
            command &= " order by d.rid"
            command &= " ;') f"

            'command &= "           where d.feeno =" & feeno & " and d.dvcd=" & dvcd & " and d.pvncd =" & pvncd & " and t.feeabbr =''" & feeabbr & "'' and t.pvncd =" & pvncd
            dt = Queryds_103(command)
            Return dt
        End Function
        Public Function SP_get_receipt_customer_by_lcnsid(ByVal lcnsid As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec dbo.SP_get_receipt_customer_by_lcnsid @lcnsid='" & lcnsid & "'"
            dt = Queryds(command)
            Return dt
        End Function
    End Class
End Namespace
