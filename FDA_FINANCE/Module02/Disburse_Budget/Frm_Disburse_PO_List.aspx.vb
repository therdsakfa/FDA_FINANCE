Public Class Frm_Disburse_PO_List
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _dept As Integer
    Private _bgid As Integer
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Sub runQuery()
        _dept = Request.QueryString("dept")
        _bgid = Request.QueryString("id")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        RunSession()

        Dim strQr As String = ""
        strQr = Request.QueryString("id")
        If Not IsPostBack Then

            If strQr <> "" Then
                Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
                dao_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(strQr)
                Dim dao_bill_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                dao_bill_detail.Getdata_by_Disburse_id(strQr)
                UC_Disburse_PO_Information1.getdata(dao_bill)
                UC_Disburse_PO_Information1.getdata_detail(dao_bill_detail)
                UC_Disburse_PO_Information1.bindBG()
                UC_Disburse_PO_Information1.get_pobalance(strQr)
            End If
        End If
        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
        Dim id As String = ""
        If Request.QueryString("id") IsNot Nothing Then
            id = Request.QueryString("id")
            Dim dao_po As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
            Dim bao_sub As New BAO_BUDGET.DISBURSE_BUDGET
            Dim po_head_amount As Double = 0
            Dim disburse_amount As Double = 0
            Dim balance As Double = 0
            dao_po.Getdata_by_Disburse_id(id)
            For Each dao_po.fields In dao_po.datas
                po_head_amount += dao_po.fields.AMOUNT
            Next
            'If dao_po.fields.AMOUNT IsNot Nothing Then
            '    po_head_amount = dao_po.fields.AMOUNT
            'End If
            disburse_amount = bao_sub.get_sub_po_amount(id)
            balance = (po_head_amount - disburse_amount).ToString("N")
            If balance <> 0 Or balance > 0 Then
                dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(id)
                If Request.QueryString("bguse") IsNot Nothing Then
                    If Request.QueryString("bguse") = "3" Then
                        btn_Add.Attributes.Add("onclick", "Popups('Frm_Disburse_PO_Detail_List_Insert2.aspx?bid=" & id & "&bgid=" & dao.fields.BUDGET_PLAN_ID & "&bgYear=" & dao.fields.BUDGET_YEAR & "&dept=" & dao.fields.DEPARTMENT_ID & "&po=1&bguse=3'); return false;")
                    Else
                        btn_Add.Attributes.Add("onclick", "Popups('Frm_Disburse_PO_Detail_List_Insert2.aspx?bid=" & id & "&bgid=" & dao.fields.BUDGET_PLAN_ID & "&bgYear=" & dao.fields.BUDGET_YEAR & "&dept=" & dao.fields.DEPARTMENT_ID & "&po=1'); return false;")

                    End If
                Else
                    btn_Add.Attributes.Add("onclick", "Popups('Frm_Disburse_PO_Detail_List_Insert2.aspx?bid=" & id & "&bgid=" & dao.fields.BUDGET_PLAN_ID & "&bgYear=" & dao.fields.BUDGET_YEAR & "&dept=" & dao.fields.DEPARTMENT_ID & "&po=1'); return false;")
                End If

            Else
                btn_Add.Attributes.Add("onclick", "alert('ไม่สามารถเบิกได้เนื่องจากจำนวนเงินไม่พอ'); return false;")
            End If

        End If
        UC_Disburse_PO_Information1.get_pobalance(strQr)


    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_PO_Detail_List1.rebind_grid()
    End Sub

    Private Sub Frm_Disburse_PO_List_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_PO_Detail_List1.bindseq()
    End Sub

    Protected Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Dim dept As Integer = 0
        Dim bgid As Integer = 0
        Dim pl As Integer = 0
        ' Dim dao_user As New DAO_USER.TB_tbl_USER
        'dao_user.Get_dept_select_by_AD_NAME(NameUserAD())
        If Request.QueryString("id") IsNot Nothing Then
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("id"))
            If dao.fields.BUDGET_DISBURSE_BILL_ID <> 0 Then
                dept = dao.fields.DEPARTMENT_ID
                bgid = dao.fields.BUDGET_PLAN_ID
                pl = dao.fields.PATLIST_ID

                If dao.fields.BUDGET_USE_ID IsNot Nothing Then
                    'If dao_user.fields.PERMISSION_ID = 1 Then
                    If dao.fields.BUDGET_USE_ID = 2 Then
                        Response.Redirect("Frm_Disburse_Support_Dept_PO_Overview.aspx?dept=" & dept & "&bgid=" & bgid & "&pl=" & pl & "&myear=" & dao.fields.BUDGET_YEAR)
                    ElseIf dao.fields.BUDGET_USE_ID = 1 Then
                        Response.Redirect("Frm_Disburse_PO_Overview.aspx?dept=" & dept & "&bgid=" & bgid & "&myear=" & dao.fields.BUDGET_YEAR)
                    ElseIf dao.fields.BUDGET_USE_ID = 3 Then
                        Response.Redirect("../../Module05/Disburse_OutsideBudget/Frm_Disburse_Outside_Budget_PO_Overview.aspx?dept=" & dept & "&bgid=" & bgid & "&myear=" & dao.fields.BUDGET_YEAR)
                    End If

                    'Else
                    '    If dao.fields.BUDGET_USE_ID = 2 Then
                    '        Response.Redirect("Frm_Disburse_Support_Dept_PO.aspx?dept=" & dept & "&bgid=" & bgid & "&pl=" & pl & "&myear=" & dao.fields.BUDGET_YEAR)
                    '    ElseIf dao.fields.BUDGET_USE_ID = 1 Then
                    '        Response.Redirect("Frm_Disburse_PO.aspx?dept=" & dept & "&bgid=" & bgid & "&myear=" & dao.fields.BUDGET_YEAR)
                    '    End If
                    'End If
                   
                End If


            End If

        End If
    End Sub

End Class