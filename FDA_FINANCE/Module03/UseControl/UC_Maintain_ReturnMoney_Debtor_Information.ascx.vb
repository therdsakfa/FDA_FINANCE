Public Class UC_Maintain_ReturnMoney_Debtor_Information
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then

        'End If
    End Sub

    Public Sub getdata(ByRef dt As DataTable)
        If dt.Rows.Count > 0 Then
            Dim deadline_date As String
            Dim doc_date As String
            If IsDBNull(dt(0)("DEADLINE_DATE")) Then
                deadline_date = "-"
            Else
                deadline_date = CDate(dt(0)("DEADLINE_DATE")).ToShortDateString()
            End If

            If IsDBNull(dt(0)("DOC_DATE")) Then
                doc_date = "-"
            Else
                doc_date = CDate(dt(0)("DOC_DATE")).ToShortDateString()
            End If

            If IsDBNull(dt(0)("DEBTOR_BILL_ID")) = False Then
                Dim dao_debtor As New DAO_DISBURSE.TB_DEBTOR_BILL()
                dao_debtor.Getdata_by_DEBTOR_BILL_ID(dt(0)("DEBTOR_BILL_ID"))
                If dao_debtor.fields.DEBTOR_BILL_ID <> 0 Then
                    If dao_debtor.fields.REBILL_ID = 1 Then
                        If dao_debtor.fields.MOVEDATE IsNot Nothing Then
                            lbl_MoneyType.Text = "เงินงบประมาณ"
                        Else
                            lbl_MoneyType.Text = dt(0)("MONEYTYPE").ToString()
                        End If
                    Else
                        lbl_MoneyType.Text = dt(0)("MONEYTYPE").ToString()
                    End If
                End If
            End If

            lbl_Name.Text = dt(0)("Fullname").ToString()
            lbl_Amount.Text = CDbl(dt(0)("AMOUNT")).ToString("N")
            lbl_ContractNumber.Text = dt(0)("BILL_NUMBER").ToString()

            lbl_DebtorDescription.Text = dt(0)("DESCRIPTION").ToString()
            lbl_DeathlineDate.Text = deadline_date
            'lbl_DocNumber.Text = dt(0)("DOC_NUMBER").ToString()
            'lbl_DocDate.Text = doc_date
            'Dim debtorType As Integer = dt(0)("").ToString() 'ประเถทลูกหนี้ (เงินงบประมาณ, เงินทดรอง)
            'Dim payType As Integer = 2 ' ประเภทเงิน (เช็ค)

        End If
    End Sub

End Class