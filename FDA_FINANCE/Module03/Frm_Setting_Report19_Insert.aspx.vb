Imports Telerik.Web.UI

Public Class Frm_Setting_Report19_Insert
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_income()
            bind_ddl_receiver()
            txt_SEND_DATE.Text = Date.Now.ToShortDateString()
            txt_find_date.Text = Date.Now.ToShortDateString()
            Dim dao As New DAO_MAINTAIN.TB_SEND_MONEY
            Try
                dao.Getdata_by_ID(Request.QueryString("ida"))
            Catch ex As Exception

            End Try

            Try
                txt_SEND_DATE.Text = CDate(dao.fields.SEND_DATE).ToShortDateString()
            Catch ex As Exception

            End Try
            Try
                lb_runno.Text = dao.fields.FULL_RUNNING
            Catch ex As Exception

            End Try
            Try
                ddl_type.DropDownSelectData(dao.fields.SEND_TYPE)
            Catch ex As Exception

            End Try
            Try
                ddl_receiver.DropDownSelectData(dao.fields.RECEIVER_MONEY_ID)
            Catch ex As Exception

            End Try

            If Request.QueryString("ida") <> "" Then
                btn_save.Style.Add("display", "none")
                btn_edit.Style.Add("display", "block")
                Panel1.Style.Add("display", "block")
            Else
                btn_save.Style.Add("display", "block")
                btn_edit.Style.Add("display", "none")
                Panel1.Style.Add("display", "none")
            End If
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_MAINTAIN.TB_SEND_MONEY
        Dim bao As New BAO_BUDGET.Maintain
        Dim runno As Integer = 0
        Try
            If Request.QueryString("e") = "" Then
                runno = bao.get_Max_Runno_Send_money_by_Budget_Year(Request.QueryString("myear"))
            ElseIf Request.QueryString("e") <> "" Then
                runno = bao.get_Max_Runno_Send_money_e_receipt_by_Budget_Year(Request.QueryString("myear"))
            ElseIf Request.QueryString("law") <> "" Then
                runno = bao.get_Max_Runno_Send_money_Law_Normal_by_Budget_Year(Request.QueryString("myear"))
            End If

        Catch ex As Exception

        End Try

        dao.fields.RUNNING_NO = runno + 1
        Try
            dao.fields.FULL_RUNNING = Right(Request.QueryString("myear"), 2) & "/" & runno + 1
        Catch ex As Exception

        End Try
        Try
            dao.fields.SEND_DATE = CDate(txt_SEND_DATE.Text)
        Catch ex As Exception

        End Try
        Try
            dao.fields.BUDGET_YEAR = Request.QueryString("myear")
        Catch ex As Exception

        End Try
        Try
            dao.fields.SEND_TYPE = ddl_type.SelectedValue
        Catch ex As Exception

        End Try
        Try
            If Request.QueryString("e") <> "" Then
                dao.fields.RECEIPT_TYPE = 1
            End If
        Catch ex As Exception

        End Try
        Try
            If Request.QueryString("law") <> "" Then
                dao.fields.RECEIPT_TYPE = 4
            End If
        Catch ex As Exception

        End Try
        Try
            dao.fields.RECEIVER_MONEY_ID = ddl_receiver.SelectedValue
        Catch ex As Exception

        End Try
        dao.insert()

        Dim uri As String = ""
        uri = Request.Url.AbsoluteUri & "&ida=" & dao.fields.IDA
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย'); window.location='" & uri & "';", True)


    End Sub
    Public Sub gen_no()
        Dim bao As New BAO_BUDGET.Maintain
        Dim runno As Integer = 0
        Try
            runno = bao.get_Max_Runno_Send_money_by_Budget_Year(Request.QueryString("myear"))
        Catch ex As Exception

        End Try
        lb_runno.Text = runno + 1
    End Sub
    Sub bind_income()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As New DataTable
        dt = bao.get_income_tb()

        ddl_Income.DataSource = dt
        ddl_Income.DataBind()
    End Sub
    Sub bind_ddl_receiver()
        Dim dao As New DAO_MAS.TB_MAS_MONEY_RECEIVER
        dao.Get_All_RECEIVER()

        ddl_receiver.DataSource = dao.datas
        ddl_receiver.DataTextField = "RECEIVER_NAME"
        ddl_receiver.DataValueField = "RECEIVER_MONEY_ID"
        ddl_receiver.DataBind()
    End Sub
    Private Sub RadGrid1_Init(sender As Object, e As EventArgs) Handles RadGrid1.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = RadGrid1
        Rad_Utility.addColumnCheckbox_client("chk", "")
        Rad_Utility.addColumnBound("IDA", "IDA", False)
        Rad_Utility.addColumnBound("INCOME_NAME", "ประเภทรายได้", width:=350)
        Rad_Utility.addColumnBound("INCOME_CODE", "รหัสรายได้")
        Rad_Utility.addColumnBound("RECEIVE_TYPE", "ประเภทรับ")
        Rad_Utility.addColumnBound("sum_amount", "จำนวนเงิน", is_money:=True, footer_txt:="รวม ")
        Rad_Utility.addColumnBound("DECREASE_AMOUNT", "จำนวนเงินหัก", is_money:=True, footer_txt:="รวม ")
        Rad_Utility.addColumnButton("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", width:=120)
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            If e.CommandName = "Delete" Then
                Dim dao As New DAO_MAINTAIN.TB_SEND_MONEY_SUM_DETAIL
                dao.Getdata_by_ID(item("IDA").Text)
                dao.delete()

                Dim dao_del As New DAO_MAINTAIN.TB_SEND_MONEY_DETAIL
                dao_del.Getdata_by_FK_ID(dao.fields.FK_IDA, dao.fields.INCOME_IDA, dao.fields.RECEIVE_TYPE_ID)
                For Each dao_del.fields In dao_del.datas
                    dao_del.delete()
                Next

                RadGrid1.Rebind()
            End If
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO_BUDGET.Maintain
        Dim dt As New DataTable
        Try
            'dt = bao.GET_send_money_selected(Request.QueryString("ida"))
            dt = bao.GET_send_money_selected(Request.QueryString("ida"))
        Catch ex As Exception

        End Try
        RadGrid1.DataSource = dt
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Maintain
        Try
            If Request.QueryString("e") = "" Then
                dt = bao.GET_send_money_all_by_type(CDate(txt_find_date.Text), ddl_Income.SelectedValue, ddl_receive_type.SelectedValue)
            ElseIf Request.QueryString("e") <> "" Then
                dt = bao.GET_send_money_e_receipt_all_by_type(CDate(txt_find_date.Text), ddl_Income.SelectedValue, ddl_receive_type.SelectedValue)
            ElseIf Request.QueryString("law") <> "" Then
                dt = bao.GET_send_money_law_normal_all_by_type(CDate(txt_find_date.Text), ddl_Income.SelectedValue, ddl_receive_type.SelectedValue)
            End If

        Catch ex As Exception

        End Try
        RadGrid2.Rebind()
    End Sub

    Private Sub RadGrid2_Init(sender As Object, e As EventArgs) Handles RadGrid2.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = RadGrid2
        'Rad_Utility.addColumnCheckbox_client("chk", "")
        Rad_Utility.addColumnBound("IDA", "IDA", False)
        Rad_Utility.addColumnBound("RECEIVE_MONEY_TYPE", "RECEIVE_MONEY_TYPE", False)
        Rad_Utility.addColumnBound("RECEIVE_MONEY_ID", "RECEIVE_MONEY_ID", False)
        Rad_Utility.addColumnBound("INCOME_IDA", "INCOME_IDA", False)
        Rad_Utility.addColumnBound("FULL_RECEIVE_NUMBER", "เลขที่ใบเสร็จ", width:=350)
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True, footer_txt:="รวม ")

    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Maintain
        Try
            'dt = bao.GET_send_money_all_by_type(CDate(txt_find_date.Text), ddl_Income.SelectedValue, ddl_receive_type.SelectedValue)
            If Request.QueryString("e") = "" Then
                dt = bao.GET_send_money_all_by_type(CDate(txt_find_date.Text), ddl_Income.SelectedValue, ddl_receive_type.SelectedValue)
            Else
                'If ddl_Income.SelectedValue = 48 Then

                'Else
                dt = bao.GET_send_money_e_receipt_all_by_type(CDate(txt_find_date.Text), ddl_Income.SelectedValue, ddl_receive_type.SelectedValue)

                'End If
            End If
        Catch ex As Exception

        End Try
        RadGrid2.DataSource = dt
    End Sub

    Protected Sub btn_insert_Click(sender As Object, e As EventArgs) Handles btn_insert.Click
        If CheckBox1.Checked Then
            Dim dt As New DataTable
            Dim bao As New BAO_BUDGET.Maintain
            Try
                If Request.QueryString("e") = "" Then
                    dt = bao.GET_send_money_all_by_type(CDate(txt_find_date.Text), ddl_Income.SelectedValue, ddl_receive_type.SelectedValue)
                Else
                    dt = bao.GET_send_money_e_receipt_all_by_type(CDate(txt_find_date.Text), ddl_Income.SelectedValue, ddl_receive_type.SelectedValue)
                End If
            Catch ex As Exception

            End Try
            For Each dr As DataRow In dt.Rows
                Dim dao As New DAO_MAINTAIN.TB_SEND_MONEY_DETAIL
                dao.fields.AMOUNT = CDbl(dr("AMOUNT"))
                dao.fields.FK_IDA = Request.QueryString("ida")
                dao.fields.FK_RECEIVE_MONEY_ID = dr("RECEIVE_MONEY_ID")
                dao.fields.INCOME_ID = dr("INCOME_IDA")
                dao.fields.RECEIVE_MONEY_TYPE = dr("RECEIVE_MONEY_TYPE")
                dao.insert()
            Next

            Dim bao_sum As New BAO_BUDGET.Maintain
            Dim dt_sum As DataTable = bao_sum.get_send_money_sum_det(Request.QueryString("ida"), ddl_Income.SelectedValue, ddl_receive_type.SelectedValue)
            For Each dr As DataRow In dt_sum.Rows
                Dim dao As New DAO_MAINTAIN.TB_SEND_MONEY_SUM_DETAIL
                With dao.fields
                    .DECREASE_AMOUNT = 0
                    .FK_IDA = Request.QueryString("ida")
                    .FULL_RUNNING = dr("FULL_RUNNING")
                    .INCOME_CODE = dr("INCOME_CODE")
                    .INCOME_IDA = dr("INCOME_IDA")
                    .INCOME_NAME = dr("INCOME_NAME")
                    .RECEIVE_TYPE = dr("RECEIVE_TYPE")
                    .RECEIVE_TYPE_ID = dr("RECEIVE_TYPE_ID")
                    Try
                        .SEND_DATE = CDate(dr("SEND_DATE"))
                    Catch ex As Exception

                    End Try
                    .SUM_AMOUNT = dr("sum_amount")
                End With
                dao.insert()
            Next

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
            RadGrid1.Rebind()
            RadGrid2.Rebind()

        Else
            For Each item As GridDataItem In RadGrid2.SelectedItems
                Dim dao As New DAO_MAINTAIN.TB_SEND_MONEY_DETAIL
                dao.fields.AMOUNT = item("AMOUNT").Text
                dao.fields.FK_IDA = Request.QueryString("ida")
                dao.fields.FK_RECEIVE_MONEY_ID = item("RECEIVE_MONEY_ID").Text
                dao.fields.INCOME_ID = item("INCOME_IDA").Text
                dao.fields.RECEIVE_MONEY_TYPE = item("RECEIVE_MONEY_TYPE").Text
                dao.insert()
            Next

            Dim bao_sum As New BAO_BUDGET.Maintain
            Dim dt_sum As DataTable = bao_sum.get_send_money_sum_det(Request.QueryString("ida"), ddl_Income.SelectedValue, ddl_receive_type.SelectedValue)
            For Each dr As DataRow In dt_sum.Rows
                Dim dao As New DAO_MAINTAIN.TB_SEND_MONEY_SUM_DETAIL
                With dao.fields
                    .DECREASE_AMOUNT = 0
                    .FK_IDA = Request.QueryString("ida")
                    .FULL_RUNNING = dr("FULL_RUNNING")
                    .INCOME_CODE = dr("INCOME_CODE")
                    .INCOME_IDA = dr("INCOME_IDA")
                    .INCOME_NAME = dr("INCOME_NAME")
                    .RECEIVE_TYPE = dr("RECEIVE_TYPE")
                    .RECEIVE_TYPE_ID = dr("RECEIVE_TYPE_ID")
                    Try
                        .SEND_DATE = CDate(dr("SEND_DATE"))
                    Catch ex As Exception

                    End Try
                    .SUM_AMOUNT = dr("sum_amount")
                End With
                dao.insert()
            Next
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
            RadGrid1.Rebind()
            RadGrid2.Rebind()
        End If
    End Sub

    Private Sub btn_print_Click(sender As Object, e As EventArgs) Handles btn_print.Click
        Dim url As String = "../Module03/Report/Frm_Report_R3_019.aspx?ida=" & Request.QueryString("ida")
        If Request.QueryString("e") <> "" Then
            url = url & "&e=1"
        End If
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "', '_blank');", True)
    End Sub

    Private Sub btn_decrease_Click(sender As Object, e As EventArgs) Handles btn_decrease.Click
        For Each item As GridDataItem In RadGrid1.SelectedItems
            Dim dao As New DAO_MAINTAIN.TB_SEND_MONEY_SUM_DETAIL
            dao.Getdata_by_ID(item("IDA").Text)
            dao.fields.DECREASE_AMOUNT = RadNumericTextBox1.Value
            dao.update()
        Next
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
        RadGrid1.Rebind()
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        If Request.QueryString("ida") <> "" Then
            Dim dao As New DAO_MAINTAIN.TB_SEND_MONEY
            dao.Getdata_by_ID(Request.QueryString("ida"))
            Try
                dao.fields.SEND_DATE = CDate(txt_SEND_DATE.Text)
            Catch ex As Exception

            End Try
            Try
                dao.fields.SEND_TYPE = ddl_type.SelectedValue
            Catch ex As Exception

            End Try
            Try
                dao.fields.RECEIVER_MONEY_ID = ddl_receiver.SelectedValue
            Catch ex As Exception

            End Try
            dao.update()

            Dim dao_sum As New DAO_MAINTAIN.TB_SEND_MONEY_SUM_DETAIL
            dao_sum.Getdata_by_FK_IDA(Request.QueryString("ida"))
            For Each dao_sum.fields In dao_sum.datas

                Try
                    dao_sum.fields.SEND_DATE = CDate(txt_SEND_DATE.Text)
                Catch ex As Exception

                End Try
            Next
            dao_sum.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขเรียบร้อย');", True)
        End If
    End Sub
End Class