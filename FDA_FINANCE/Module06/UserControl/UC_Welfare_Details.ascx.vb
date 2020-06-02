Public Partial Class UC_Welfare_Details
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' เพิ่ม/แก้ไขข้อมูลประเภทสวัสดิการ
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub insert(ByRef dao As DAO_MAS.TB_MAS_WELFARE)
        dao.fields.WELFARE_TYPE_CODE = txt_WELFARE_TYPE_CODE.Text
        dao.fields.WELFARE_TYPE_DESCRIPTION = txt_WELFARE_TYPE_DESCRIPTION.Text
        dao.fields.WELFARE_TYPE_SHORT_DESCRIPTION = txt_WELFARE_TYPE_SHORT_DESCRIPTION.Text
    End Sub
    ''' <summary>
    ''' ดึงข้อมูลประเภทสวัสดิการ
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub getdata(ByRef dao As DAO_MAS.TB_MAS_WELFARE)
        txt_WELFARE_TYPE_CODE.Text = dao.fields.WELFARE_TYPE_CODE
        txt_WELFARE_TYPE_DESCRIPTION.Text = dao.fields.WELFARE_TYPE_DESCRIPTION
        txt_WELFARE_TYPE_SHORT_DESCRIPTION.Text = dao.fields.WELFARE_TYPE_SHORT_DESCRIPTION
    End Sub
End Class