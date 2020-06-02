Imports Telerik.Web.UI

Public Class Frm_Disburse_Tracking_Checker
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'bind_ddl_checker()
        End If
    End Sub

    'Private Sub rg_checker_Init(sender As Object, e As EventArgs) Handles rg_checker.Init
    '    Dim Rad_Utility As New Radgrid_Utility
    '    Rad_Utility.Rad = rg_checker
    '    Rad_Utility.addColumnCheckbox_client("chkColumn", "")
    '    Rad_Utility.addColumnBound("IDA", "IDA", False)
    '    Rad_Utility.addColumnBound("type", "type", False)
    '    Rad_Utility.addColumnBound("DOC_NUMBER", "เลขหนังสือ")
    '    Rad_Utility.addColumnDate("DOC_DATE", "วันที่")
    '    Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", width:=120)
    '    Rad_Utility.addColumnBound("sum_amount", "จำนวนเงิน", width:=120, is_money:=True)
    '    Rad_Utility.addColumnBound("FULLNAME", "ชื่อผู้ตรวจสอบ", width:=300)

    'End Sub

    'Sub bind_ddl_checker()
    '    Try
    '        Dim dao As New DAO_MAS.TB_MAS_CHECKER
    '        dao.GetDataby_All()
    '        ddl_checker.DataSource = dao.datas
    '        ddl_checker.DataTextField = "FULLNAME"
    '        ddl_checker.DataValueField = "CTZID"
    '        ddl_checker.DataBind()
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub rg_checker_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_checker.ItemDataBound
     If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then

            Dim item As GridDataItem
            item = e.Item

            Dim ddl As RadComboBox = DirectCast(item("FULLNAME").FindControl("ddl_checker"), RadComboBox)
            Dim dao As New DAO_MAS.TB_MAS_CHECKER
            dao.GetDataby_All()

            ddl.DataSource = dao.datas
            ddl.DataTextField = "FULLNAME"
            ddl.DataValueField = "CTZID"
            ddl.DataBind()
            Dim r As New RadComboBoxItem
            r.Text = "--กรุณาเลือก--"
            r.Value = 0
            ddl.Items.Insert(0, r)

        End If

    End Sub

    Private Sub rg_checker_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_checker.NeedDataSource
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As New DataTable
        Try
            dt = bao.get_checker_update2(Request.QueryString("myear"), 1)
        Catch ex As Exception

        End Try
        rg_checker.DataSource = dt
    End Sub

    Public Sub updates()

        Dim i As String = ""

        For Each item As GridDataItem In rg_checker.Items
            Dim ddl As RadComboBox = DirectCast(item("FULLNAME").FindControl("ddl_checker"), RadComboBox)

            Try
                i = ddl.SelectedValue
            Catch ex As Exception

            End Try

            If i <> "" And i <> 0 Then
                If item("type").Text = "1" Then
                    Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
                    dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("IDA").Text)
                    Try
                        dao.fields.CHKR_CTZID = ddl.SelectedValue
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.CHKR_DATE = Date.Now
                    Catch ex As Exception

                    End Try
                    dao.update()

                Else

                    Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
                    dao.Getdata_by_DEBTOR_BILL_ID(item("IDA").Text)
                    Try
                        dao.fields.CHKR_CTZID = ddl.SelectedValue
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.CHKR_DATE = Date.Now
                    Catch ex As Exception

                    End Try
                    dao.update()
                End If
                'Else
                '    If i = "" Then
                '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกชื่อผู้ตรวจสอบ');", True)

                '    End If
            End If
        Next

        'If i <> "" Then
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
        '  End If

        rg_checker.Rebind()
        '------------------
        'Dim i As Integer = 0
        'Try
        '    i = rg_checker.SelectedItems.Count
        'Catch ex As Exception

        'End Try

        'For Each item As GridDataItem In rg_checker.SelectedItems

        '    If item("type").Text = "1" Then
        '        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
        '        dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("IDA").Text)
        '        Try
        '            '  dao.fields.CHKR_CTZID = ddl_checker.SelectedValue
        '        Catch ex As Exception

        '        End Try
        '        Try
        '            dao.fields.CHKR_DATE = Date.Now
        '        Catch ex As Exception

        '        End Try
        '        dao.update()
        '    Else
        '        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
        '        dao.Getdata_by_DEBTOR_BILL_ID(item("IDA").Text)
        '        Try
        '            ' dao.fields.CHKR_CTZID = ddl_checker.SelectedValue
        '        Catch ex As Exception

        '        End Try
        '        Try
        '            dao.fields.CHKR_DATE = Date.Now
        '        Catch ex As Exception

        '        End Try
        '        dao.update()
        '    End If
        'If i > 0 Then
        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)

        'End If
        'Next
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        updates()
    End Sub
End Class