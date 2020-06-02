Public Partial Class UC_PayList_Inserts
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' เพิ่ม/แก้ไขค่าใช้จ่าย
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub insert(ByRef dao As DAO_MAS.TB_MAS_PAYLIST)
        dao.fields.PAYLIST_DESCRIPTION = txt_PAYLIST_DESCRIPTION.Text
    End Sub
    ''' <summary>
    ''' ดึงข้อมูลค่าใช้จ่าย
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub getdata(ByRef dao As DAO_MAS.TB_MAS_PAYLIST)
        txt_PAYLIST_DESCRIPTION.Text = dao.fields.PAYLIST_DESCRIPTION
    End Sub

End Class