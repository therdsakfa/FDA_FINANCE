Public Partial Class UC_Reciver_Details
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' เพิ่ม/แก้ไขข้อมูลผู้รับเงิน
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub insert(ByRef dao As DAO_MAS.TB_MAS_MONEY_RECEIVER)
        dao.fields.IS_RECEIVER = cb_IS_RECEIVER.Checked
        dao.fields.POSITION_NAME = txt_POSITION_NAME.Text
        dao.fields.RECEIVER_NAME = txt_RECEIVER_NAME.Text
    End Sub
    ''' <summary>
    ''' ดึงข้อมูลผู้รับเงิน
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub getdata(ByRef dao As DAO_MAS.TB_MAS_MONEY_RECEIVER)
        cb_IS_RECEIVER.Checked = dao.fields.IS_RECEIVER
        txt_POSITION_NAME.Text = dao.fields.POSITION_NAME
        txt_RECEIVER_NAME.Text = dao.fields.RECEIVER_NAME
    End Sub
End Class