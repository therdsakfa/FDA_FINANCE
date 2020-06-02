Public Class UC_Disburse_PO_Information
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)
        If dao.fields.DOC_NUMBER IsNot Nothing Then
            lb_DOC_NUMBER.Text = dao.fields.DOC_NUMBER
        End If
        If dao.fields.DOC_DATE IsNot Nothing Then
            lb_DOC_DATE.Text = dao.fields.DOC_DATE
        End If
        'If dao.fields.BILL_NUMBER IsNot Nothing Then
        '    lb_BILL_NUMBER.Text = dao.fields.BILL_NUMBER
        'End If
        If dao.fields.DESCRIPTION IsNot Nothing Then
            lb_DESCRIPTION.Text = dao.fields.DESCRIPTION
        End If
        'If dao.fields.BILL_DATE IsNot Nothing Then
        '    lb_BILL_DATE.Text = dao.fields.BILL_DATE
        'End If

    End Sub
    Public Sub getdata_detail(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL_DETAIL)
        Dim amounts As Double = 0
        Try
            For Each dao.fields In dao.datas
                amounts += dao.fields.AMOUNT
            Next
        Catch ex As Exception

        End Try
        lb_AMOUNT.Text = CDbl(amounts).ToString("N")
    End Sub
    Public Sub get_pobalance(ByVal po_id As Integer)
        Dim dao_po As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim po_head_amount As Double = 0
        Dim disburse_amount As Double = 0
        dao_po.Getdata_by_Disburse_id(po_id)
        Dim head_amount As Double = 0
        For Each dao_po.fields In dao_po.datas
            head_amount += dao_po.fields.AMOUNT
        Next
        po_head_amount = head_amount
        disburse_amount = bao.get_sub_po_amount(po_id)

        lb_balance_amount.Text = (po_head_amount - disburse_amount).ToString("N")

    End Sub
    Public Sub bindBG()
        Dim strQr As String = ""
        If Request.QueryString("ispo") IsNot Nothing Then

            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            If Request.QueryString("bid") IsNot Nothing Then
                dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
                If dao.fields.PO_HEAD_ID IsNot Nothing Then
                    strQr = dao.fields.PO_HEAD_ID
                End If
            End If


        Else
            strQr = Request.QueryString("id")
        End If
        'strQr = Request.QueryString("id")
        If strQr <> "" Then
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(strQr)
            Dim bg_id As Integer = 0
            If dao.fields.BUDGET_PLAN_ID IsNot Nothing Then
                bg_id = dao.fields.BUDGET_PLAN_ID
            End If
            Dim dao_project As New DAO_MAS.TB_BUDGET_PLAN
            Dim dao_bg As New DAO_MAS.TB_BUDGET_PLAN
            Dim dao_mt As New DAO_MAS.TB_MAS_MONEY_TYPE
            Dim dao_head_mt As New DAO_MAS.TB_MAS_MONEY_TYPE
            'If bg_id <> 0 Then
            '    If Request.QueryString("bguse") IsNot Nothing Then
            '        If Request.QueryString("bguse") = "3" Then
            '            dao_mt.Getdata_by_MONEY_TYPE_ID(bg_id)
            '            lb_BUDGET_PLAN_DESCRIPTION.Text = dao_mt.fields.MONEY_TYPE_DESCRIPTION

            '            If dao_mt.fields.HEAD_MONEY_TYPE_ID IsNot Nothing Then
            '                dao_head_mt.Getdata_by_MONEY_TYPE_ID(dao_mt.fields.HEAD_MONEY_TYPE_ID)
            '                lb_Project.Text = dao_head_mt.fields.MONEY_TYPE_DESCRIPTION
            '            End If
            '        Else
            '            dao_bg.Getdata_by_BUDGET_PLAN_ID(bg_id)
            '            lb_BUDGET_PLAN_DESCRIPTION.Text = dao_bg.fields.BUDGET_DESCRIPTION
            '            dao_project.Getdata_by_BUDGET_PLAN_ID(dao_bg.fields.BUDGET_CHILD_ID)
            '            If dao_project.fields.BUDGET_CODE IsNot Nothing And Trim(dao_project.fields.BUDGET_CODE) <> "" Then
            '                lb_Project.Text = dao_project.fields.BUDGET_CODE & " - " & dao_project.fields.BUDGET_DESCRIPTION
            '            End If
            '        End If

            '    Else
            '        dao_bg.Getdata_by_BUDGET_PLAN_ID(bg_id)
            '        lb_BUDGET_PLAN_DESCRIPTION.Text = dao_bg.fields.BUDGET_DESCRIPTION
            '        dao_project.Getdata_by_BUDGET_PLAN_ID(dao_bg.fields.BUDGET_CHILD_ID)
            '        If dao_project.fields.BUDGET_CODE IsNot Nothing And Trim(dao_project.fields.BUDGET_CODE) <> "" Then
            '            lb_Project.Text = dao_project.fields.BUDGET_CODE & " - " & dao_project.fields.BUDGET_DESCRIPTION
            '        End If
            '    End If


            'End If
        End If
    End Sub
End Class