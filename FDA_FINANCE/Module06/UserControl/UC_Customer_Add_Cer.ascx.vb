Imports Telerik.Web.UI
Public Class UC_Customer_Add_Cer
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lb_cus_id.Visible = False
            lb_cus_id.Text = Request.QueryString("bid")

            Dim dao As New DAO_MAS.TB_MAS_CUSTOMER
            dao.Getdata_by_CUSTOMER_ID(Request.QueryString("bid"))
            RadGrid1.Rebind()
            'ซ่อน uc ยกเลิกสัญญา
            lb_Cer_cancel.Visible = False
            txt_Cercancel.Visible = False
            bt_saveCancel.Visible = False
            'RadGrid1.Rebind()
        End If
    End Sub
    Public Sub insert(ByRef dao As DAO_MAS.TB_MAS_CUSTOMER_ADD_CER)

        dao.fields.CUS_FK = lb_cus_id.Text
        dao.fields.Cer_Number = txt_NumCer.Text

        'Dim docdate As String = ""
        'Dim docdateEnd As String = ""
        Try
            'docdate = CDate(txt_dateCer.SelectedDate).ToShortDateString()
            dao.fields.Cer_Date = CDate(txt_dateCer.Text)
            dao.fields.Cer_Date_Num = clsDate.getDateKey(CDate(dao.fields.Cer_Date), clsDate.order.ddmmyy)
        Catch ex As Exception

        End Try
        Try
            'docdateEnd = CDate(txt_dateCerEnd.SelectedDate).ToShortDateString()
            dao.fields.Cer_DateEnd = CDate(txt_dateCerEnd.Text)
            dao.fields.Cer_DateEnd_Num = clsDate.getDateKey(CDate(dao.fields.Cer_DateEnd), clsDate.order.ddmmyy)
        Catch ex As Exception

        End Try

        dao.fields.DEPARTMENT_ID = dd_dept.SelectedValue

        dao.fields.isEnabled = True

        dao.fields.Cer_Install = txt_install.Text

        txt_NumCer.Text = ""
        txt_dateCer.Text = ""
        txt_dateCerEnd.Text = ""
        txt_install.Text = ""
    End Sub



    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_MAS.TB_MAS_CUSTOMER_ADD_CER
        insert(dao)
        dao.insert()
        txt_NumCer.Text = ""
        txt_dateCer.Text = ""
        txt_dateCerEnd.Text = ""
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.$('#ctl00_ContentPlaceHolder1_btn_Redirect').click();" & "parent.$('#dialog_insert').dialog('close'); ", True)

        RadGrid1.Rebind()



    End Sub

    Private Sub rgCustomer_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        Dim dt_Customer As DataTable

        Dim bao As New BAO_BUDGET.MASS
        dt_Customer = bao.get_customer_AddCer(Request.QueryString("bid"))
        RadGrid1.DataSource = dt_Customer

    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            'If e.CommandName = "del" Then
            '    Dim dao As New DAO_MAS.TB_MAS_CUSTOMER_ADD_CER
            '    dao.Getdata_by_CUSTOMER_ID(Request.QueryString("bid"))
            '    dao.fields.isEnabled = False

            '    dao.update()
            '    RadGrid1.Rebind()
            'End If
            If e.CommandName = "cancel" Then
                Dim dao As New DAO_MAS.TB_MAS_CUSTOMER_ADD_CER
                Dim url_c As String = ""
                Try
                    dao.Getdata_by_CUSTOMER_ID(Request.QueryString("bid"))
                    lb_Cer_cancel.Visible = True
                    txt_Cercancel.Visible = True
                    bt_saveCancel.Visible = True
                Catch ex As Exception

                End Try
                'ElseIf e.CommandName = "del" Then
                '    Dim dao As New DAO_MAS.TB_MAS_CUSTOMER_ADD_CER

                '    Try
                '        dao.Getdata_by_CUSTOMER_ID(Request.QueryString("bid"))
                '        dao.delete()
                '        RadGrid1.Rebind()
                '    Catch ex As Exception

                '    End Try

            End If


        End If
    End Sub




    Public Sub update_Cancel(ByRef dao As DAO_MAS.TB_MAS_CUSTOMER_ADD_CER)
        dao.Getdata_by_CUSTOMER_ID(Request.QueryString("bid"))
        dao.fields.Cer_Cancel = txt_Cercancel.Text


    End Sub
    Protected Sub bt_saveCancel_Click(sender As Object, e As EventArgs) Handles bt_saveCancel.Click
        Dim dao As New DAO_MAS.TB_MAS_CUSTOMER_ADD_CER
        dao.Getdata_by_CUSTOMER_ID(Request.QueryString("bid"))
        update_Cancel(dao)
        dao.update()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเหตุผลเรียบร้อย');parent.$('#ctl00_ContentPlaceHolder1_btn_Redirect').click();" & "parent.$('#dialog_insert').dialog('close'); ", True)

        RadGrid1.Rebind()
        lb_Cer_cancel.Visible = False
        txt_Cercancel.Visible = False
        bt_saveCancel.Visible = False
    End Sub
End Class