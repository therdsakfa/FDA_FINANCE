Public Partial Class UC_CustomerType_Insert
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' เพิ่ม/แก้ไขตารางประเภทเจ้าหนี้
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub insert(ByRef dao As DAO_MAS.TB_MAS_CUSTOMER_TYPE)
        dao.fields.CUSTOMER_TYPE = txtCustomerType.Text
        If dd_Tax_Type.SelectedValue <> "" Then
            dao.fields.TAX_TYPE = dd_Tax_Type.SelectedValue
        End If
        dao.fields.TAX = txt_Tax.Text
        dao.fields.VAT = txt_Vat.Text
    End Sub
    Public Sub set_dd_selected()
        If Request.QueryString("cusid") IsNot Nothing Then
            Dim dao As New DAO_MAS.TB_MAS_CUSTOMER_TYPE
            dao.Getdata_by_CUSTOMER_TYPE_ID(Request.QueryString("cusid"))
            If dao.fields.TAX_TYPE IsNot Nothing Then
                dd_Tax_Type.DropDownSelectData(dao.fields.TAX_TYPE)
            End If
        End If
    End Sub
    ''' <summary>
    ''' ดึงข้อมูลประเภทเจ้าหนี้
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub getdata(ByRef dao As DAO_MAS.TB_MAS_CUSTOMER_TYPE)
        txtCustomerType.Text = dao.fields.CUSTOMER_TYPE
        txt_Tax.Text = dao.fields.TAX
        txt_Vat.Text = dao.fields.VAT
    End Sub
End Class