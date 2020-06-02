Imports Telerik.Web.UI
Public Class Frm_Maintain_Receive_Money_V3_2_Insert
    Inherits System.Web.UI.Page
    Public bgYear As Integer
    Private _dept As Integer
    Private _bgid As Integer
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private dt_rg As DataTable
    Dim date_str As Date
    Private _receiver_id As Integer = 0
    Sub runQuery()
        bgYear = Request.QueryString("myear")
        '_receiver_id = Request.QueryString("r")

        Try
            _CLS = Session("CLS")
            _receiver_id = Get_Checker_ID(_CLS.CITIZEN_ID) 'Request.QueryString("r")
            'If _receiver_id = 0 Then
            '    Response.Redirect("http://privus.fda.moph.go.th/")
            'End If
        Catch ex As Exception

        End Try
        If _receiver_id = 0 Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        End If
    End Sub
    Private Function Get_Checker_ID(ByVal citizen As String) As Integer
        Dim id As Integer = 0
        Dim dao_re As New DAO_MAS.TB_MAS_MONEY_RECEIVER
        Try
            dao_re.Getdata_by_iden(citizen)
            id = dao_re.fields.RECEIVER_MONEY_ID
        Catch ex As Exception
            id = 0
        End Try
        Return id
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            Try
                Dim dao_re As New DAO_MAS.TB_MAS_MONEY_RECEIVER
                dao_re.Getdata_by_RECEIVER_MONEY_ID(_receiver_id)
              
                lbl_receiver.Text = "ผู้รับเงิน : " & dao_re.fields.RECEIVER_NAME
            Catch ex As Exception

            End Try
            If Request.QueryString("pre") <> "" Then
                txt_FULL_RECEIVE_NUMBER.Enabled = True
                If Request.QueryString("law") <> "" Then
                    Dim dao_re As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                    'dao_re.GetDataPrevious_L44_MAX(bgYear)
                    dao_re.GetDataPrevious_MAX(bgYear, 3)
                    txt_FULL_RECEIVE_NUMBER.Text = "2-" & Right(bgYear, 2) & "/" & dao_re.fields.RUNNING_RECEIPT + 1
                Else
                    Dim dao_re As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                    dao_re.GetDataPrevious_MAX(bgYear, 3)
                    txt_FULL_RECEIVE_NUMBER.Text = Right(bgYear, 2) & "/" & dao_re.fields.RUNNING_RECEIPT + 1
                End If

            Else

            End If
            date_str = CDate(Request.QueryString("date"))
            txt_MONEY_RECEIVE_DATE.Text = Date.Now.ToShortDateString()
            Try
                txt_MONEY_RECEIVE_DATE.Text = date_str.ToShortDateString()
            Catch ex As Exception

            End Try
            bind_income()
            bind_ddl_money_type()

            bind_dept()
            bind_bank()
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
    Sub bind_bank()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_bank()

        ddl_bank.DataSource = dt
        ddl_bank.DataBind()
    End Sub
    Private Function feeno_format()
        Dim fee_format As String = ""
        Dim arr_feeno As String() = Nothing
        Try
            arr_feeno = txt_ORDER_PAY2.Text.Split("/")
            If Len(arr_feeno(0)) < 5 Then
                Try
                    arr_feeno(0) = String.Format("{0:00000}", CInt(arr_feeno(0)))
                Catch ex As Exception

                End Try
            End If

            fee_format = arr_feeno(1) & arr_feeno(0)
        Catch ex As Exception

        End Try
        Return fee_format
    End Function
    Private Sub ddl_Income_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Income.SelectedIndexChanged
        bind_ddl_money_type()
    End Sub
    Public Sub insert(ByRef dao As DAO_MAINTAIN.TB_RECEIVE_MONEY)
        'Dim dao_rec As New DAO_MAS.TB_MAS_MONEY_RECEIVER
        'dao_rec.get_receiver()
        'Dim a As Integer = dao_rec.fields.RECEIVER_MONEY_ID
        dao.fields.RECEIVE_MONEY_DESCRIPTION = txt_description.Text
        dao.fields.FULLNAME = txt_customer.Text
        dao.fields.CUSTOMER_ID = 0
        Try
            If _receiver_id = 0 Then
                dao.fields.RECEIVER_MONEY_ID = Get_Checker_ID(_CLS.CITIZEN_ID)
            Else
                dao.fields.RECEIVER_MONEY_ID = _receiver_id
            End If
        Catch ex As Exception

        End Try


        dao.fields.RECEIVE_AMOUNT = 0
        dao.fields.BUDGET_YEAR = bgYear
        Try
            dao.fields.MONEY_RECEIVE_DATE = CDate(txt_MONEY_RECEIVE_DATE.Text)
        Catch ex As Exception

        End Try
        dao.fields.RECEIVE_MONEY_TYPE = ddl_receive_type.SelectedValue
        dao.fields.MONEY_TYPE_ID = ddl_money_type.SelectedValue
        dao.fields.ORDER_PAY1 = txt_ORDER_PAY1.Text
        dao.fields.INCOME_IDA = ddl_Income.SelectedValue
        dao.fields.IS_SINBON = cb_sinbon.Checked
        dao.fields.IS_CHECK_OUT_PROVINCE = cb_IS_CHECK_OUT_PROVINCE.Checked
        dao.fields.IS_SEND_TO_BANK = cb_IS_SEND_TO_BANK.Checked
        Try
            dao.fields.SINBON_ID = DropDownList1.SelectedValue
        Catch ex As Exception
            dao.fields.SINBON_ID = 0
        End Try

        dao.fields.RECEIPT_TYPE = 3 'กรอกเอง
        
        Try
            If ddl_receive_type.SelectedValue = 2 Then
                dao.fields.BANK_ID = ddl_bank.SelectedValue
                dao.fields.CHECK_NUMBER = txt_Checknumber.Text
            End If
        Catch ex As Exception

        End Try
        Try
            dao.fields.CHECK_DATE = txt_checkdate.Text
        Catch ex As Exception

        End Try
    End Sub
    Sub bind_dept()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.SP_MAS_RECEIPT_DEPARTMENT

        ddl_department.DataSource = dt
        ddl_department.DataBind()
    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim amount As Double = 0
        Try
            amount = RadNumericTextBox1.Value
        Catch ex As Exception

        End Try
        If amount <> 0 Then
            Dim dept As Integer = 0

            Try
                dept = ddl_department.SelectedValue
            Catch ex As Exception

            End Try

            Dim dao_fee As New DAO_FEE.TB_fee

            Dim fee_format As String = feeno_format()


            Dim bao_d As New BAO_BUDGET.FDA_FEE
            Dim dt_d As New DataTable

            Dim bao_max As New BAO_BUDGET.Maintain
            Dim max_id As Integer = 0

            'Dim FULL_RECEIVE_NUMBER As String = ""
            'Try
            '    max_id = bao_max.get_max_receipt_normal(bgYear, 1)
            '    FULL_RECEIVE_NUMBER = Right(bgYear, 2) & "/" & max_id + 1
            'Catch ex As Exception

            'End Try


            Dim FULL_RECEIVE_NUMBER As String = ""
            Dim RECEIVE_NUMBER As String = ""

            If Request.QueryString("pre") = "" Then
                If Request.QueryString("law") = "" Then
                    max_id = bao_max.get_max_receipt_normal(bgYear, 1)
                Else
                    max_id = bao_max.get_max_receipt_normal_M44(bgYear, 1)
                End If
                FULL_RECEIVE_NUMBER = Right(bgYear, 2) & "/" & max_id + 1
            Else
                FULL_RECEIVE_NUMBER = txt_FULL_RECEIVE_NUMBER.Text
                Dim num As String() = Nothing
                Try
                    num = txt_FULL_RECEIVE_NUMBER.Text.Split("/")
                    RECEIVE_NUMBER = num(1)
                Catch ex As Exception

                End Try

            End If

            'If count_row > 0 Then
            'Dim count_bg As Integer = 0
            Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            'count_bg = dao.count_receipt4(ddl_department.SelectedValue, fee_format, txt_ORDER_PAY1.Text)
            'If count_bg = 0 Then
            dao = New DAO_MAINTAIN.TB_RECEIVE_MONEY

            insert(dao)
            dao.fields.FEENO = fee_format
            dao.fields.ORDER_PAY2 = fee_format
            If Request.QueryString("pre") = "" Then
                dao.fields.RUNNING_RECEIPT = max_id + 1
            Else
                dao.fields.RUNNING_RECEIPT = RECEIVE_NUMBER
            End If
            If Request.QueryString("law") <> "" Then
                If Request.QueryString("pre") = "" Then
                    FULL_RECEIVE_NUMBER = "2-" & FULL_RECEIVE_NUMBER
                End If

            End If

            dao.fields.FULL_RECEIVE_NUMBER = FULL_RECEIVE_NUMBER
            dao.fields.STAFF_IDEN = ""

            Try
                dao.fields.FULLNAME = txt_customer.Text
            Catch ex As Exception

            End Try
            dao.fields.FEEABBR = txt_ORDER_PAY1.Text
            dao.fields.DVCD = ddl_department.SelectedValue
            If Request.QueryString("pre") <> "" Then
                dao.fields.IS_PREVIOUS = True
                If Request.QueryString("law") <> "" Then
                    dao.fields.RECEIPT_TYPE = 6
                End If
            End If
            If Request.QueryString("law") = "" Then
                dao.fields.IS_L44 = 0
            Else
                dao.fields.IS_L44 = 1
            End If
            dao.insert()


            Dim dao_det As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
            dao_det.fields.FK_IDA = dao.fields.RECEIVE_MONEY_ID
            Try
                dao_det.fields.AMOUNT = RadNumericTextBox1.Value
            Catch ex As Exception
                dao_det.fields.AMOUNT = 0
            End Try
            dao_det.fields.FEEABBR = txt_ORDER_PAY1.Text
            dao_det.fields.TABEAN_NUMBER = txt_TABEAN_NUMBER.Text
            dao_det.fields.LCNNO = ""
            dao_det.fields.TXT_LCNNO = ""
            dao_det.fields.DEEKA_NUMBER = txt_DEEKA_NUMBER.Text
            dao_det.fields.SUB_PAY_TYPE = txt_Sub_Pay_Type.Text
            If Request.QueryString("pre") <> "" Then
                dao_det.fields.DESCRIPTIONS = txt_description.Text
            End If
            dao_det.insert()
            'End If
            Dim dao22 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao22.Getdata_by_RECEIVE_MONEY_ID(dao.fields.RECEIVE_MONEY_ID)
            Dim url As String = "../Module09/Report/Frm_Report_R9_003.aspx?id_feeno=" & dao.fields.RECEIVE_MONEY_ID & "&dvcd=" & dao22.fields.DVCD & "&myear=" & dao22.fields.BUDGET_YEAR & "&rt=3"

            If Request.QueryString("pre") = "" Then
                If Request.QueryString("law") <> "" Then
                    url &= "&law=1"
                End If
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "', '_blank'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
            Else
                url = "../Module09/Report/Frm_Report_R9_003.aspx?id_feeno=" & dao.fields.RECEIVE_MONEY_ID & "&dvcd=" & dao22.fields.DVCD & "&feeno=" & dao22.fields.FEENO & "&feeabbr=" & dao22.fields.FEEABBR & "&myear=" & dao22.fields.BUDGET_YEAR & "&law=1"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย'); window.open('" & url & "', '_blank'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
            End If
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรอกจำนวนเงินไม่ถูกต้อง');", True)
        End If
        


            'End If
    End Sub
    Private Sub btn_reset_Click(sender As Object, e As EventArgs) Handles btn_reset.Click
        txt_Checknumber.Text = ""
        txt_customer.Text = ""
        txt_description.Text = ""
        txt_FULL_RECEIVE_NUMBER.Text = ""
        txt_ORDER_PAY1.Text = ""
        txt_ORDER_PAY2.Text = ""
        txt_Sub_Pay_Type.Text = ""
        txt_TABEAN_NUMBER.Text = ""
        txt_DEEKA_NUMBER.Text = ""
        RadNumericTextBox1.Value = 0
    End Sub
End Class