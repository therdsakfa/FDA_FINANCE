Imports Telerik.Web.UI
Public Class Frm_Maintain_Receive_Money_V2_Edit
    Inherits System.Web.UI.Page
    Dim ida As String = ""
    Sub runQuery()
        ida = Request.QueryString("ida")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            bind_income()
            bind_ddl_money_type()
            bind_dept()
            txt_MONEY_RECEIVE_DATE.Text = Date.Now.ToShortDateString()
            bind_bank()

            Try
                Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                dao.Getdata_by_RECEIVE_MONEY_ID(ida)
                getdata(dao)
            Catch ex As Exception

            End Try
        End If
    End Sub
    Public Sub bind_ddl_money_type()
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.MASS
        'dt = bao.get_money_type_list
        Try
            Dim dao As New DAO_MAS.TB_MAS_INCOME
            dao.GetDataby_IDA(ddl_Income.SelectedValue)
            dt = bao.get_money_type_list_by_id(dao.fields.HEAD_ID)
        Catch ex As Exception

        End Try

        ddl_money_type.DataSource = dt
        ddl_money_type.DataBind()
    End Sub
    Sub bind_income()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As New DataTable
        dt = bao.get_income_tb()

        ddl_Income.DataSource = dt
        ddl_Income.DataBind()
    End Sub
    Sub bind_dept()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.SP_MAS_RECEIPT_DEPARTMENT

        ddl_department.DataSource = dt
        ddl_department.DataBind()
    End Sub
    Sub bind_bank()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_bank()

        ddl_bank.DataSource = dt
        ddl_bank.DataBind()
    End Sub
    Public Sub update(ByRef dao As DAO_MAINTAIN.TB_RECEIVE_MONEY)
        dao.fields.RECEIVE_MONEY_DESCRIPTION = txt_description.Text
        dao.fields.FULLNAME = txt_FullNAME.Text
        Try
            dao.fields.MONEY_RECEIVE_DATE = CDate(txt_MONEY_RECEIVE_DATE.Text)
        Catch ex As Exception

        End Try
        dao.fields.RECEIVE_MONEY_TYPE = ddl_receive_type.SelectedValue
        dao.fields.MONEY_TYPE_ID = ddl_money_type.SelectedValue
        dao.fields.INCOME_IDA = ddl_Income.SelectedValue
        dao.fields.IS_SINBON = cb_sinbon.Checked
        dao.fields.IS_CHECK_OUT_PROVINCE = cb_IS_CHECK_OUT_PROVINCE.Checked
        dao.fields.IS_SEND_TO_BANK = cb_IS_SEND_TO_BANK.Checked
        Try
            dao.fields.SINBON_ID = DropDownList1.SelectedValue
        Catch ex As Exception
            dao.fields.SINBON_ID = 0
        End Try
        dao.fields.CHECK_NUMBER = txt_Checknumber.Text
        Try
            dao.fields.CHECK_DATE = CDate(txt_checkdate.Text)
        Catch ex As Exception

        End Try
        Try
            dao.fields.BANK_ID = ddl_bank.SelectedValue
        Catch ex As Exception

        End Try
    End Sub
    Public Sub getdata(ByRef dao As DAO_MAINTAIN.TB_RECEIVE_MONEY)
        txt_description.Text = dao.fields.RECEIVE_MONEY_DESCRIPTION
        txt_FullNAME.Text = dao.fields.FULLNAME
        Try
            txt_MONEY_RECEIVE_DATE.Text = CDate(dao.fields.MONEY_RECEIVE_DATE).ToShortDateString
        Catch ex As Exception

        End Try
        Try
            ddl_receive_type.DropDownSelectData(dao.fields.RECEIVE_MONEY_TYPE)
        Catch ex As Exception

        End Try
        Try
            ddl_money_type.DropDownSelectData(dao.fields.MONEY_TYPE_ID)
        Catch ex As Exception

        End Try
        Try
            ddl_Income.DropDownSelectData(dao.fields.INCOME_IDA)
        Catch ex As Exception

        End Try
        Try
            cb_sinbon.Checked = dao.fields.IS_SINBON
        Catch ex As Exception

        End Try
        Try
            cb_IS_CHECK_OUT_PROVINCE.Checked = dao.fields.IS_CHECK_OUT_PROVINCE
        Catch ex As Exception

        End Try
        Try
            cb_IS_SEND_TO_BANK.Checked = dao.fields.IS_SEND_TO_BANK
        Catch ex As Exception

        End Try

        Try
            DropDownList1.DropDownSelectData(dao.fields.SINBON_ID)
        Catch ex As Exception
        End Try
        Try
            txt_Checknumber.Text = dao.fields.CHECK_NUMBER
        Catch ex As Exception

        End Try

        Try
            txt_checkdate.Text = CDate(dao.fields.CHECK_DATE).ToShortDateString
        Catch ex As Exception

        End Try
        Try
            ddl_bank.DropDownSelectData(dao.fields.BANK_ID)
        Catch ex As Exception

        End Try
        'txt_Checknumber.Text = dao.fields.FULL_RECEIVE_NUMBER
        Try
            ddl_department.DropDownSelectData(dao.fields.DVCD)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Try
            Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao.Getdata_by_RECEIVE_MONEY_ID(ida)
            update(dao)
            dao.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขเรียบร้อยแล้ว'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ddl_Income_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Income.SelectedIndexChanged
        bind_ddl_money_type()
    End Sub
End Class