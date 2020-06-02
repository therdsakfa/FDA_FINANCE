Public Class UC_Maintain_ReturnMoney_OutsideBudget_Debtor_Information
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
  
    End Sub

    Public Sub getdata(ByRef dt As DataTable)
        If dt.Rows.Count > 0 Then
            lbl_Name.Text = dt(0)("Fullname").ToString()
            If IsDBNull(dt(0)("AMOUNT")) = False Then
                lbl_Amount.Text = CDbl(dt(0)("AMOUNT")).ToString("N")
            End If

            lbl_ContractNumber.Text = dt(0)("BILL_NUMBER").ToString()

            lbl_DebtorDescription.Text = dt(0)("DESCRIPTION").ToString()
            Try
                If IsDBNull(dt(0)("DEADLINE_DATE").ToString()) = False Then
                    lbl_DeathlineDate.Text = CDate(dt(0)("DEADLINE_DATE")).ToShortDateString()
                End If
            Catch ex As Exception

            End Try
            

            'lbl_DocNumber.Text = dt(0)("DOC_NUMBER").ToString()
            'lbl_DocDate.Text = dt(0)("DOC_DATE").ToString()
            'Dim debtorType As Integer = dt(0)("").ToString() 'ประเถทลูกหนี้ (เงินงบประมาณ, เงินทดรอง)
            'Dim payType As Integer = 2 ' ประเภทเงิน (เช็ค)
            ' BUDGET_PLAN_ID
            If IsDBNull(dt(0)("BUDGET_PLAN_ID")) = False Then
                bindTxtbox(dt(0)("BUDGET_PLAN_ID"))
            End If
        End If
    End Sub
    Public Sub bindTxtbox(nodeID As Integer)
        Dim baobudget As New BAO_BUDGET.Budget
        Dim dt As New DataTable

        dt.Columns.Add("seq")
        dt.Columns.Add("MONEY_TYPE_DESCRIPTION")
        dt.Columns.Add("MONEY_AMOUNT")
        dt.Columns.Add("TYPE_ID")
        dt = baobudget.getMoneyTypeNodeBack(dt, nodeID)

        Dim dv As DataView = dt.DefaultView
        dv.Sort = "seq desc"
        dt = dv.ToTable


        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1

                If IsDBNull(dt(i)("MONEY_TYPE_DESCRIPTION")) = False And IsDBNull(dt(i)("TYPE_ID")) = False Then
                    Select Case dt(i)("TYPE_ID")
                        Case "1"
                            lb_level1.Text = dt(i)("MONEY_TYPE_DESCRIPTION")
                        Case "2"
                            lb_level2.Text = dt(i)("MONEY_TYPE_DESCRIPTION")
                        Case "3"
                            lb_level3.Text = dt(i)("MONEY_TYPE_DESCRIPTION")
                        Case "4"
                            lb_level4.Text = dt(i)("MONEY_TYPE_DESCRIPTION")
                    End Select

                End If

            Next
        End If
    End Sub
End Class