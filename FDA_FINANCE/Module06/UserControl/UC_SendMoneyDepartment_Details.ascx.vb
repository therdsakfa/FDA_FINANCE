Public Partial Class UC_SendMoneyDepartment_Details
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' เพิ่ม/แก้ไขข้อมูลหน่วยงานที่นำส่งเงิน
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub insert(ByRef dao As DAO_MAS.TB_MAS_SEND_MONEY_DEPARTMENT)
        dao.fields.BANK_ACCOUNT = txt_BANK_ACCOUNT.Text
        dao.fields.BRANCH_NAME = txt_BRANCH_NAME.Text
        dao.fields.DEPARTMENT_OR_BANK_NAME = txt_DEPARTMENT_OR_BANK_NAME.Text
        dao.fields.SHORT_DEPARTMENT_NAME = txt_SHORT_DEPARTMENT_NAME.Text
    End Sub
    ''' <summary>
    ''' ดึงข้อมูลหน่วยงานที่นำส่งเงิน
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub getdata(ByRef dao As DAO_MAS.TB_MAS_SEND_MONEY_DEPARTMENT)
        txt_BANK_ACCOUNT.Text = dao.fields.BANK_ACCOUNT
        txt_BRANCH_NAME.Text = dao.fields.BRANCH_NAME
        txt_DEPARTMENT_OR_BANK_NAME.Text = dao.fields.DEPARTMENT_OR_BANK_NAME
        txt_SHORT_DEPARTMENT_NAME.Text = dao.fields.SHORT_DEPARTMENT_NAME
    End Sub
End Class