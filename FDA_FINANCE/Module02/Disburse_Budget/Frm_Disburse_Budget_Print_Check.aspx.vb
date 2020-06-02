Imports Telerik.Web.UI
Public Class Frm_Disburse_Budget_Print_Check
    Inherits System.Web.UI.Page
    Private str_id As String = ""
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        Page.Title = "พิมพ์เช็ค"
        'btn_report.Attributes.Add("OnClick", "window.open('../../Module09/Report/Frm_Report_R9_004_1.aspx?date=" & txt_date.Text & "&c=" & ddl_count.SelectedValue & "'); return false;")
        Dim dao_h_chk As New DAO_MAS.TB_PRINT_CHECK_HISTORY
        If Not IsPostBack Then
            txt_date.Text = System.DateTime.Now.ToShortDateString
            If Request.QueryString("btype") = "4" Or Request.QueryString("btype") = "5" Or Request.QueryString("btype") = "6" Then
                lb_chk_type.Style.Add("Display", "block")
                dd_check_type.Style.Add("Display", "block")
            End If
            set_max_count()
            RadGrid1.Rebind()

        Else
            SetBindGridCheckListTemp()
        End If

        SetBindGridCheckList()
        run_check()
        If txt_date.Text <> "" Then
            UC_Disburse_Budget_CheckList1.txt_date = CDate(txt_date.Text)
        End If



    End Sub

    Public Sub set_max_count()
       
        Try
            Dim bao As New BAO_BUDGET.MASS
            Dim maxCount As Integer = bao.get_max_count_print(txt_date.Text)
            ddl_count.DropDownSelectData(maxCount)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub SetBindGridCheckList()
        '   UC_Disburse_Budget_CheckList1.rg = RadGrid1
        UC_Disburse_Budget_CheckList1.select_type = rdl_search_type.SelectedValue
        UC_Disburse_Budget_CheckList1.bguse = 1
        UC_Disburse_Budget_CheckList1.p_count = ddl_count.SelectedValue
        UC_Disburse_Budget_CheckList1.chk_number = txt_search_chk.Text
    End Sub


    Public Sub SetBindGridCheckListTemp()
        '    UC_Disburse_Budget_CheckList_Temp1.rg = RadGrid1
        UC_Disburse_Budget_CheckList_Temp1.select_type = rdl_search_type.SelectedValue
        UC_Disburse_Budget_CheckList_Temp1.bguse = 1
        UC_Disburse_Budget_CheckList_Temp1.p_count = ddl_count.SelectedValue
        UC_Disburse_Budget_CheckList_Temp1.chk_number = txt_search_chk.Text
    End Sub


    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        SetBindGridCheckListTemp()
        UC_Disburse_Budget_CheckList_Temp1.chk_number = txt_search_chk.Text
        UC_Disburse_Budget_CheckList_Temp1.rg_rebind()
    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_MAS.TB_PRINT_CHECK_HISTORY
                dao.Getdata_by_chk_num(item("CHECK_NUMBER").Text)
                dao.delete()
                RadGrid1.Rebind()

            End If

        End If
    End Sub
    Public Sub BindData()
        Dim bao As New BAO_BUDGET.MASS
        If txt_date.Text <> "" Then
            RadGrid1.Rebind()
            run_check()
            UC_Disburse_Budget_CheckList1.rg_rebind()
        End If


    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        ' RadGrid1.DataSource = UC_Disburse_Budget_CheckList1.serialgrid(RadGrid1)
        Dim bao As New BAO_BUDGET.MASS
        If txt_date.Text <> "" Then
            'RadGrid1.DataSource = bao.get_check_history_bill(CDate(txt_date.Text), ddl_count.SelectedValue, 1)
            Dim strType As String = ""
            If Request.QueryString("btype") IsNot Nothing Then
                strType = Request.QueryString("btype")
            End If
            RadGrid1.DataSource = bao.get_check_history_all(CDate(txt_date.Text), ddl_count.SelectedValue, strType)
        End If
    End Sub

    Public Sub run_check()
        str_id = ""
        Dim date_time As DateTime = System.DateTime.Now()
        ' Dim str_id As String = ""
        Dim date_new As DateTime

        If txt_date.Text <> "" Then
            date_new = CType(txt_date.Text, DateTime) + New TimeSpan(0, date_time.Hour, date_time.Minute, date_time.Second)
        End If
        Dim dao As New DAO_MAS.TB_PRINT_CHECK_HISTORY
        For Each item As GridDataItem In RadGrid1.Items
            If item("CHECK_NUMBER").Text <> "" Or item("CHECK_NUMBER").Text <> "&nbsp;" Then
                If str_id = "" Then
                    str_id = "'" & item("CHECK_NUMBER").Text & "'"
                Else
                    str_id = str_id & "," & "'" & item("CHECK_NUMBER").Text & "'"
                End If

            End If
        Next


        If str_id <> "" Then

            Dim url As String = "../../Module09/Report/Frm_Report_R9_001.aspx?did=" & str_id & "&flag=mbill"
            'hpPrintCheck.NavigateUrl = url
            If Request.QueryString("btype") = "4" Or Request.QueryString("btype") = "5" Or Request.QueryString("btype") = "6" Then
                hpPrintCheck.NavigateUrl = url & "&t=" & dd_check_type.SelectedValue
            Else
                hpPrintCheck.NavigateUrl = url
            End If
        Else
            hpPrintCheck.NavigateUrl = ""
        End If
    End Sub
    Public Function getReportData_R9_001(ByVal bill_id As String) As DataTable
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.ConnectDatabase
        Dim command As String = " "
        command = " exec [BUDGETS].[get_Report_R9_001_debtor]  @bg_id='" & bill_id & "'" '29
        dt = bao.Queryds_Report(command)
        Return dt
    End Function

    Private Sub txt_date_TextChanged(sender As Object, e As EventArgs) Handles txt_date.TextChanged
        BindData()
    End Sub

    Private Sub ddl_count_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_count.SelectedIndexChanged
        BindData()
    End Sub


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim listcheck As String = ""
        listcheck = UC_Disburse_Budget_CheckList_Temp1.rg_Bind_ListCheck()

        UC_Disburse_Budget_CheckList1.Set_CheckList(listcheck)
        SetBindGridCheckList()
        UC_Disburse_Budget_CheckList1.rg_rebind()


        SetBindGridCheckListTemp()
        UC_Disburse_Budget_CheckList_Temp1.chk_number = "-"
        UC_Disburse_Budget_CheckList_Temp1.rg_rebind()
    End Sub


    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Budget_CheckList_Temp1.rg_rebind()
    End Sub
End Class