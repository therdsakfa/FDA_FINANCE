Public Partial Class UC_CustomerDetails
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
                Dim dao_customer_edit As New DAO_MAS.TB_MAS_CUSTOMER
                dao_customer_edit.Getdata_by_CUSTOMER_ID(Request.QueryString("cusid"))
                If dao_customer_edit.fields.PERSONAL_TYPE IsNot Nothing Then
                    dd_personal_type.DropDownSelectData(dao_customer_edit.fields.PERSONAL_TYPE)
                    ddCustomerType.DropDownSelectData(dao_customer_edit.fields.CUSTOMER_TYPE_ID)
                End If
            End If


            'txt_personal_edit.Visible = False
        End If
    End Sub
   
    Public Validataion As Boolean = True
    ''' <summary>
    ''' เพิ่ม/แก้ไขข้อมูลรายละเอียดเจ้าหนี้
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub insert(ByRef dao As DAO_MAS.TB_MAS_CUSTOMER)
        'dao.fields.TAX_NUMBER = txt_TAX_NUMBER.Text

        'dao.fields.PERSONAL_ID = txt_PERSONAL_ID.Text
        'dao.fields.TAX_NUMBER = dd_Tax_Number.SelectedValue
        'If dd_Personal_ID.SelectedValue <> "" Then
        '    dao.fields.PERSONAL_ID = dd_Personal_ID.SelectedValue
        'Else

        dao.fields.PERSONAL_ID = txt_personal_edit.Text



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

        'dao.fields.Cer_Number = txt_NumCer.Text


        'dao.fields.DEPARTMENT_ID = dd_dept.SelectedValue
        'เพิ่มที่อยู่เต็ม

        dao.fields.Full_Address = txt_FullAddress.Text
    End Sub

    Public Sub Update(ByRef dao As DAO_MAS.TB_MAS_CUSTOMER)


        'dao.fields.TAX_NUMBER = txt_TAX_NUMBER.Text

        'dao.fields.PERSONAL_ID = txt_PERSONAL_ID.Text
        'dao.fields.TAX_NUMBER = dd_Tax_Number.SelectedValue
        'If dd_Personal_ID.SelectedValue <> "" Then
        '    dao.fields.PERSONAL_ID = dd_Personal_ID.SelectedValue
        'Else

        dao.fields.PERSONAL_ID = txt_personal_edit.Text


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

        'dao.fields.Cer_Number = txt_NumCer.Text


        'dao.fields.DEPARTMENT_ID = dd_dept.SelectedValue
        'เพิ่มที่อยู่เต็ม

        dao.fields.Full_Address = txt_FullAddress.Text



    End Sub
    ''' <summary>
    ''' ดึงข้อมูลรายละเอียดเจ้าหนี้
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub getdata(ByRef dao As DAO_MAS.TB_MAS_CUSTOMER)
        'txt_TAX_NUMBER.Text = dao.fields.TAX_NUMBER

        'txt_PERSONAL_ID.Text = dao.fields.PERSONAL_ID
        'dd_Tax_Number.SelectedValue = dao.fields.TAX_NUMBER

        txt_personal_edit.Text = dao.fields.PERSONAL_ID

        ddCustomerType.SelectedValue = dao.fields.CUSTOMER_TYPE_ID
        dd_personal_type.SelectedValue = dao.fields.PERSONAL_TYPE
        'dd_Personal_ID.SelectedValue = dao.fields.PERSONAL_ID
        txt_CUSTOMER_NAME.Text = dao.fields.CUSTOMER_NAME
        txt_PAYABLE_NAME.Text = dao.fields.PAYABLE_NAME

        'txt_NumCer.Text = dao.fields.Cer_Number
        'dd_dept.SelectedValue = dao.fields.DEPARTMENT_ID
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




    Protected Sub get_detail_Click(sender As Object, e As EventArgs) Handles get_detail.Click
        Dim dao As New DAO_MAS.TB_MAS_PRE_CUSTOMER
        dao.Getdata_by_personID(txt_personal_edit.Text)
        If dao.fields.CUSTOMER_ID <> 0 Then
            Try
                ddCustomerType.SelectedValue = dao.fields.CUSTOMER_TYPE_ID
            Catch ex As Exception

            End Try

            txt_PAYABLE_NAME.Text = dao.fields.PAYABLE_NAME
            txt_CUSTOMER_NAME.Text = dao.fields.CUSTOMER_NAME
            Try
                dd_personal_type.SelectedValue = dao.fields.PERSONAL_TYPE
            Catch ex As Exception

            End Try

            'txt_NumCer.Text = dao.fields.Cer_Number
            'dd_dept.SelectedValue = dao.fields.DEPARTMENT_ID
            txt_FullAddress.Text = dao.fields.Full_Address
            txt_TEL_NUMBER.Text = dao.fields.TEL_NUMBER
            txt_EMAIL.Text = dao.fields.EMAIL
            txt_FAX.Text = dao.fields.FAX
        End If
       

    End Sub


End Class