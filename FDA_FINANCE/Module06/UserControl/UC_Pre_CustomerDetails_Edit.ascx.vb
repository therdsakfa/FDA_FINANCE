Public Class UC_Pre_CustomerDetails_Edit
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Dim bao As New BAO_BUDGET.MASS
            '' Dim dt As DataTable = bao.
            'Dim dao_customer As New DAO_MAS.TB_MAS_CUSTOMER_TYPE
            'dao_customer.Getdata()
            'Dim dt_cus As DataTable = dao_customer.dt
            'ddCustomerType.DataSource = dt_cus
            'ddCustomerType.DataBind()

            Dim bao_mass As New BAO_BUDGET.MASS
            Dim dt_mass As DataTable = bao_mass.get_customer_type()
            'Dim dt_cus_type As DataTable = dao_customer.dt

            ddCustomerType.DataSource = dt_mass
            ddCustomerType.DataBind()

            If Request.QueryString("cusid") IsNot Nothing Then
                Dim dao_customer_edit As New DAO_MAS.TB_MAS_PRE_CUSTOMER
                dao_customer_edit.Getdata_by_CUSTOMER_ID(Request.QueryString("cusid"))
                If dao_customer_edit.fields.PERSONAL_TYPE IsNot Nothing Then
                    dd_personal_type.DropDownSelectData(dao_customer_edit.fields.PERSONAL_TYPE)
                    ddCustomerType.DropDownSelectData(dao_customer_edit.fields.CUSTOMER_TYPE_ID)
                End If
            End If
            txt_personal_edit_v2.Visible = False
            getSW_2.Visible = False

            If ddCustomerType.SelectedValue = 1 Then
                txt_personal_edit.Visible = True
                txt_personal_edit_v2.Text = "t2"
            ElseIf ddCustomerType.SelectedValue = 2 Then
                txt_personal_edit.Visible = False
                txt_personal_edit_v2.Visible = True
                getSW.Visible = False
                getSW_2.Visible = True
            Else
                txt_personal_edit.Visible = False
                txt_personal_edit_v2.Visible = True
                getSW.Visible = False
                getSW_2.Visible = True
            End If



        End If

    End Sub



    Public Validataion As Boolean = True
    ''' <summary>
    ''' เพิ่ม/แก้ไขข้อมูลรายละเอียดเจ้าหนี้
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub insert(ByRef dao As DAO_MAS.TB_MAS_PRE_CUSTOMER)


        'dao.fields.TAX_NUMBER = txt_TAX_NUMBER.Text

        'dao.fields.PERSONAL_ID = txt_PERSONAL_ID.Text
        'dao.fields.TAX_NUMBER = dd_Tax_Number.SelectedValue
        'If dd_Personal_ID.SelectedValue <> "" Then
        '    dao.fields.PERSONAL_ID = dd_Personal_ID.SelectedValue
        'Else
        If txt_personal_edit.Text <> "t1" Then
            dao.fields.PERSONAL_ID = txt_personal_edit.Text
        Else
            dao.fields.PERSONAL_ID = txt_personal_edit_v2.Text
        End If


        dao.fields.CUSTOMER_TYPE_ID = ddCustomerType.SelectedValue
        ' dao.fields.CUSTOMER_TYPE_ID = 1
        dao.fields.CUSTOMER_NAME = txt_CUSTOMER_NAME.Text

        dao.fields.PAYABLE_NAME = txt_PAYABLE_NAME.Text


        'dao.fields.H_NUMBER = txt_H_NUMBER.Text
        'dao.fields.MOO = txt_MOO.Text
        'dao.fields.SOI = txt_SOI.Text
        'dao.fields.ROAD_NAME = txt_ROAD_NAME.Text

        'dao.fields.DISTICT = dd_DISTICT.SelectedValue
        'dao.fields.PREFECTURE = dd_PREFECTURE.SelectedValue
        'dao.fields.PROVINCE = dd_PROVINCE.SelectedValue

        'dao.fields.DISTICT = txt_DISTICT.Text
        'dao.fields.PREFECTURE = txt_PREFECTURE.Text
        'dao.fields.PROVINCE = txt_PROVINCE.Text
        'dao.fields.ZIP_CODE = txt_ZIP_CODE.Text

        dao.fields.TEL_NUMBER = txt_TEL_NUMBER.Text


        dao.fields.EMAIL = txt_EMAIL.Text

        dao.fields.FAX = txt_FAX.Text
        If dd_personal_type.SelectedValue <> "" Then
            dao.fields.PERSONAL_TYPE = dd_personal_type.SelectedValue
        Else
            dao.fields.PERSONAL_TYPE = Nothing
        End If

        'เพิ่มเลขที่สัญญาจ้าง/หน่วยงาน

        dao.fields.Cer_Number = txt_NumCer.Text


        dao.fields.DEPARTMENT_ID = dd_dept.SelectedValue
        'เพิ่มที่อยู่เต็ม

        dao.fields.Full_Address = txt_FullAddress.Text

        '---------------------------------------------------------------------------------------'
        '---------------------------------------------------------------------------------------'

        ''dao.fields.TAX_NUMBER = txt_TAX_NUMBER.Text

        ''dao.fields.PERSONAL_ID = txt_PERSONAL_ID.Text
        ''dao.fields.TAX_NUMBER = dd_Tax_Number.SelectedValue
        ''If dd_Personal_ID.SelectedValue <> "" Then
        ''    dao.fields.PERSONAL_ID = dd_Personal_ID.SelectedValue
        ''Else
        'If txt_personal_edit.Text <> "" Then
        '    dao.fields.PERSONAL_ID = txt_personal_edit.Text
        'ElseIf txt_personal_edit.Text = "" Then
        '    Response.Alert("กรุณาใส่เลขบัตรประชาชน")
        'ElseIf txt_personal_edit_v2.Text = "" Then
        '    Response.Alert("กรุณาใส่เลขบัตรประชาชน")
        'Else
        '    dao.fields.PERSONAL_ID = txt_personal_edit_v2.Text
        'End If


        'dao.fields.CUSTOMER_TYPE_ID = ddCustomerType.SelectedValue
        '' dao.fields.CUSTOMER_TYPE_ID = 1
        'If txt_CUSTOMER_NAME.Text <> "" Then
        '    dao.fields.CUSTOMER_NAME = txt_CUSTOMER_NAME.Text
        'Else
        '    Response.Alert("กรุณาใส่ชื่อเจ้าหนี้")
        'End If
        'If txt_PAYABLE_NAME.Text <> "" Then
        '    dao.fields.PAYABLE_NAME = txt_PAYABLE_NAME.Text
        'Else
        '    Response.Alert("กรุณาใส่ชื่อการสั่งจ่าย")
        'End If

        ''dao.fields.H_NUMBER = txt_H_NUMBER.Text
        ''dao.fields.MOO = txt_MOO.Text
        ''dao.fields.SOI = txt_SOI.Text
        ''dao.fields.ROAD_NAME = txt_ROAD_NAME.Text

        ''dao.fields.DISTICT = dd_DISTICT.SelectedValue
        ''dao.fields.PREFECTURE = dd_PREFECTURE.SelectedValue
        ''dao.fields.PROVINCE = dd_PROVINCE.SelectedValue

        ''dao.fields.DISTICT = txt_DISTICT.Text
        ''dao.fields.PREFECTURE = txt_PREFECTURE.Text
        ''dao.fields.PROVINCE = txt_PROVINCE.Text
        ''dao.fields.ZIP_CODE = txt_ZIP_CODE.Text
        'If txt_TEL_NUMBER.Text <> "" Then
        '    dao.fields.TEL_NUMBER = txt_TEL_NUMBER.Text
        'Else
        '    Response.Alert("กรุณาใส่เบอร์โทรศัพท์")
        'End If
        'If txt_EMAIL.Text <> "" Then
        '    dao.fields.EMAIL = txt_EMAIL.Text
        'Else
        '    Response.Alert("กรุณาใส่อีเมล์")
        'End If
        'dao.fields.FAX = txt_FAX.Text
        'If dd_personal_type.SelectedValue <> "" Then
        '    dao.fields.PERSONAL_TYPE = dd_personal_type.SelectedValue
        'Else
        '    dao.fields.PERSONAL_TYPE = Nothing
        'End If

        ''เพิ่มเลขที่สัญญาจ้าง/หน่วยงาน
        'If txt_NumCer.Text <> "" Then
        '    dao.fields.Cer_Number = txt_NumCer.Text
        'Else
        '    Response.Alert("กรุณาใส่เลขที่สัญญาจ้าง")
        'End If

        'dao.fields.DEPARTMENT_ID = dd_dept.SelectedValue
        ''เพิ่มที่อยู่เต็ม
        'If txt_FullAddress.Text <> "" Then
        '    dao.fields.Full_Address = txt_FullAddress.Text
        'Else
        '    Response.Alert("กรุณาใส่ที่อยู่")
        'End If


    End Sub

    Public Sub Update(ByRef dao As DAO_MAS.TB_MAS_PRE_CUSTOMER)


        'dao.fields.TAX_NUMBER = txt_TAX_NUMBER.Text

        'dao.fields.PERSONAL_ID = txt_PERSONAL_ID.Text
        'dao.fields.TAX_NUMBER = dd_Tax_Number.SelectedValue
        'If dd_Personal_ID.SelectedValue <> "" Then
        '    dao.fields.PERSONAL_ID = dd_Personal_ID.SelectedValue
        'Else
        If txt_personal_edit.Text = "" Then
            dao.fields.PERSONAL_ID = txt_personal_edit_v2.Text
        ElseIf txt_personal_edit_v2.Text = "" Then
            dao.fields.PERSONAL_ID = txt_personal_edit.Text
        End If

        dao.fields.CUSTOMER_TYPE_ID = ddCustomerType.SelectedValue
        ' dao.fields.CUSTOMER_TYPE_ID = 1
        dao.fields.CUSTOMER_NAME = txt_CUSTOMER_NAME.Text

        dao.fields.PAYABLE_NAME = txt_PAYABLE_NAME.Text


        'dao.fields.H_NUMBER = txt_H_NUMBER.Text
        'dao.fields.MOO = txt_MOO.Text
        'dao.fields.SOI = txt_SOI.Text
        'dao.fields.ROAD_NAME = txt_ROAD_NAME.Text

        'dao.fields.DISTICT = dd_DISTICT.SelectedValue
        'dao.fields.PREFECTURE = dd_PREFECTURE.SelectedValue
        'dao.fields.PROVINCE = dd_PROVINCE.SelectedValue

        'dao.fields.DISTICT = txt_DISTICT.Text
        'dao.fields.PREFECTURE = txt_PREFECTURE.Text
        'dao.fields.PROVINCE = txt_PROVINCE.Text
        'dao.fields.ZIP_CODE = txt_ZIP_CODE.Text

        dao.fields.TEL_NUMBER = txt_TEL_NUMBER.Text


        dao.fields.EMAIL = txt_EMAIL.Text

        dao.fields.FAX = txt_FAX.Text
        If dd_personal_type.SelectedValue <> "" Then
            dao.fields.PERSONAL_TYPE = dd_personal_type.SelectedValue
        Else
            dao.fields.PERSONAL_TYPE = Nothing
        End If

        'เพิ่มเลขที่สัญญาจ้าง/หน่วยงาน

        dao.fields.Cer_Number = txt_NumCer.Text


        dao.fields.DEPARTMENT_ID = dd_dept.SelectedValue
        'เพิ่มที่อยู่เต็ม

        dao.fields.Full_Address = txt_FullAddress.Text



    End Sub

    ''' <summary>
    ''' ดึงข้อมูลรายละเอียดเจ้าหนี้
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub getdata(ByRef dao As DAO_MAS.TB_MAS_PRE_CUSTOMER)
        'txt_TAX_NUMBER.Text = dao.fields.TAX_NUMBER

        'txt_PERSONAL_ID.Text = dao.fields.PERSONAL_ID
        'dd_Tax_Number.SelectedValue = dao.fields.TAX_NUMBER

        'If txt_personal_edit.Text <> "" Then
        '    txt_personal_edit.Text = dao.fields.PERSONAL_ID
        'ElseIf txt_personal_edit_v2.Text <> "" Then
        '    txt_personal_edit_v2.Text = dao.fields.PERSONAL_ID
        'End If
        If dao.fields.CUSTOMER_TYPE_ID = 1 Then
            txt_personal_edit.Text = dao.fields.PERSONAL_ID
        ElseIf dao.fields.CUSTOMER_TYPE_ID = 2 Then
            txt_personal_edit_v2.Text = dao.fields.PERSONAL_ID
        Else
            txt_personal_edit_v2.Text = dao.fields.PERSONAL_ID
        End If

        ddCustomerType.SelectedValue = dao.fields.CUSTOMER_TYPE_ID
        dd_personal_type.SelectedValue = dao.fields.PERSONAL_TYPE
        'dd_Personal_ID.SelectedValue = dao.fields.PERSONAL_ID
        txt_CUSTOMER_NAME.Text = dao.fields.CUSTOMER_NAME
        txt_PAYABLE_NAME.Text = dao.fields.PAYABLE_NAME

        txt_NumCer.Text = dao.fields.Cer_Number
        dd_dept.SelectedValue = dao.fields.DEPARTMENT_ID
        'txt_H_NUMBER.Text = dao.fields.H_NUMBER
        'txt_MOO.Text = dao.fields.MOO
        'txt_SOI.Text = dao.fields.SOI
        'txt_ROAD_NAME.Text = dao.fields.ROAD_NAME

        'dd_DISTICT.SelectedValue = dao.fields.DISTICT
        'dd_PREFECTURE.SelectedValue = dao.fields.PREFECTURE
        'dd_PROVINCE.SelectedValue = dao.fields.PROVINCE

        'txt_DISTICT.Text = dao.fields.DISTICT
        'txt_PREFECTURE.Text = dao.fields.PREFECTURE
        'txt_PROVINCE.Text = dao.fields.PROVINCE
        'txt_ZIP_CODE.Text = dao.fields.ZIP_CODE
        txt_TEL_NUMBER.Text = dao.fields.TEL_NUMBER
        txt_EMAIL.Text = dao.fields.EMAIL
        txt_FAX.Text = dao.fields.FAX
        txt_FullAddress.Text = dao.fields.Full_Address
    End Sub


    Protected Sub getSW_Click(sender As Object, e As EventArgs) Handles getSW.Click
        Dim sr As New WS_IDEM.IDEMService
        Dim a As New WS_IDEM.Profile
        'Dim p As New WS_IDEM.Prefix
        Dim b As String = ""


        'a = sr.GetProfile(dd_Personal_ID.SelectedItem.Text)
        'a = sr.GetProfile(txt_personal_edit.Text)

        Dim name As String = ""
        Dim dao_idem As New DAO_IDEM.TB_Person_Detail
        dao_idem.Getdata_by_citizen_id(txt_personal_edit.Text)
        Try
            name = dao_idem.fields.FirstName
        Catch ex As Exception

        End Try
        If name = "" Then
            Response.Alert("ไม่มีข้อมูลในระบบ")
            'txt_personal_edit.Visible = True
        Else
            'txt_CUSTOMER_NAME.Text = a.FullName
            'txt_FullAddress.Text = a.FullAddress
            'txt_TEL_NUMBER.Text = a.Telephone
            'txt_EMAIL.Text = a.Email

            txt_CUSTOMER_NAME.Text = dao_idem.fields.FirstName & " " & dao_idem.fields.LastName
            'txt_FullAddress.Text = a.FullAddress
            Try
                txt_TEL_NUMBER.Text = dao_idem.fields.Telephone
            Catch ex As Exception

            End Try

            txt_EMAIL.Text = dao_idem.fields.Email


            'dd_personal_type.DropDownSelectData(1)
        End If

        'If a Is Nothing Then
        '    Response.Alert("ไม่มีข้อมูลในระบบ")
        '    txt_personal_edit.Visible = True

        '    If txt_personal_edit.Visible = True Then
        '        dd_Personal_ID.Visible = False
        '    End If
        'Else
        '    txt_CUSTOMER_NAME.Text = a.FullName
        '    txt_FullAddress.Text = a.FullAddress
        '    txt_TEL_NUMBER.Text = a.Telephone
        '    txt_EMAIL.Text = a.Email
        'End If 


    End Sub



    Protected Sub getSW_2_Click(sender As Object, e As EventArgs) Handles getSW_2.Click

        Dim sr As New WS_Taxno_TaxnoAuthorize.WebService1
        Dim a As New WS_Taxno_TaxnoAuthorize.Get_Profile
        Dim b As String = ""


        a = sr.getProfile_byidentify(txt_personal_edit_v2.Text)

        Dim name As String = ""
        Try
            name = a.SYSLCNSNMs.thanm
        Catch ex As Exception

        End Try

        If name = "" Then
            Response.Alert("ไม่มีข้อมูลในระบบ")
        Else
            txt_CUSTOMER_NAME.Text = a.SYSLCNSNMs.thanm & " " & a.SYSLCNSNMs.thalnm
            txt_FullAddress.Text = a.SYSLCTADDRs.Fulladdr
            txt_TEL_NUMBER.Text = a.SYSLCTADDRs.tel
            txt_EMAIL.Text = a.SYSLCNSIDs.email
        End If



        'txt_EMAIL.Text = a.Email

    End Sub


    'เปลี่ยนSW เมื่อเลือก

    Protected Sub ddCustomerType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddCustomerType.SelectedIndexChanged
        If ddCustomerType.SelectedItem.Value = "1" Then
            If txt_personal_edit_v2.Visible = True Then
                txt_personal_edit_v2.Text = "t2"
                txt_personal_edit_v2.Visible = False
                getSW_2.Visible = False
            End If
            txt_personal_edit.Visible = True
            getSW.Visible = True

            '''''''''''''''เคลียช่อง''''''''''''''''
            txt_personal_edit.Text = ""
            txt_CUSTOMER_NAME.Text = ""
            txt_PAYABLE_NAME.Text = ""
            txt_NumCer.Text = ""
            txt_FullAddress.Text = ""
            txt_TEL_NUMBER.Text = ""
            txt_EMAIL.Text = ""
            txt_FAX.Text = ""
            ''''''''''''''''''''''''''''''''''''''
        ElseIf ddCustomerType.SelectedItem.Value = "2" Then
            If txt_personal_edit.Visible = True Then
                txt_personal_edit.Text = "t1"
                txt_personal_edit.Visible = False
                getSW.Visible = False
            End If
            txt_personal_edit_v2.Visible = True
            getSW_2.Visible = True

            '''''''''''''''เคลียช่อง''''''''''''''''
            txt_personal_edit_v2.Text = ""
            txt_CUSTOMER_NAME.Text = ""
            txt_PAYABLE_NAME.Text = ""
            txt_NumCer.Text = ""
            txt_FullAddress.Text = ""
            txt_TEL_NUMBER.Text = ""
            txt_EMAIL.Text = ""
            txt_FAX.Text = ""
            ''''''''''''''''''''''''''''''''''''''
        Else
            If txt_personal_edit.Visible = True Then
                txt_personal_edit.Text = "t1"
                getSW.Visible = False
                txt_personal_edit.Visible = False
                txt_personal_edit_v2.Visible = True
                getSW_2.Visible = True
            End If
            '''''''''''''''เคลียช่อง''''''''''''''''
            txt_personal_edit_v2.Text = ""
            txt_CUSTOMER_NAME.Text = ""
            txt_PAYABLE_NAME.Text = ""
            txt_NumCer.Text = ""
            txt_FullAddress.Text = ""
            txt_TEL_NUMBER.Text = ""
            txt_EMAIL.Text = ""
            txt_FAX.Text = ""
            ''''''''''''''''''''''''''''''''''''''
        End If
    End Sub

    'Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
    '    Dim dao As New DAO_MAS.TB_MAS_PRE_CUSTOMER

    '    If txt_personal_edit.Text = "" Then
    '        Response.Alert("กรุณาใส่เลขบัตรประชาชน")
    '    ElseIf txt_personal_edit_v2.Text = "" Then
    '        Response.Alert("กรุณาใส่เลขบัตรประชาชน")
    '    ElseIf txt_CUSTOMER_NAME.Text = "" Then
    '        Response.Alert("กรุณาใส่ชื่อเจ้าหนี้")
    '    ElseIf txt_PAYABLE_NAME.Text = "" Then
    '        Response.Alert("กรุณาใส่ชื่อการสั่งจ่าย")
    '    ElseIf txt_TEL_NUMBER.Text = "" Then
    '        Response.Alert("กรุณาใส่เบอร์โทรศัพท์")
    '    ElseIf txt_EMAIL.Text = "" Then
    '        Response.Alert("กรุณาใส่อีเมล์")
    '    ElseIf txt_NumCer.Text = "" Then
    '        Response.Alert("กรุณาใส่เลขที่สัญญาจ้าง")
    '    ElseIf txt_FullAddress.Text = "" Then
    '        Response.Alert("กรุณาใส่ที่อยู่")
    '    Else
    '        insert(dao)

    '        dao.insert()
    '        Dim log As New log_event.log
    '        log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
    '                       Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลเจ้าหนี้/ลูกหนี้ชื่อ " & dao.fields.CUSTOMER_NAME, "MAS_PRE_CUSTOMER", dao.fields.CUSTOMER_ID)
    '        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เพิ่มข้อมูลเรียบร้อยแล้ว');window.location.href = 'Frm_Customer.aspx';", True)
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    '    End If


    'End Sub
End Class

