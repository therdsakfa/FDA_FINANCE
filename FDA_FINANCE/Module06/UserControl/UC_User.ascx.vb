Public Partial Class UC_User
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' กำหนดคอลัมน์ radgrid ข้อมูลบุคลากร
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rgUser_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgUser.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgUser
        Rad_Utility.addColumnBound("USER_ID", "USER_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnCheckbox("IS_RECEIVER", "เลขประจำตัวประชาชน")
        Rad_Utility.addColumnBound("RECEIVER_NAME", "คำนำหน้าชื่อ")
        Rad_Utility.addColumnBound("POSITION_NAME", "ชื่อ")
        Rad_Utility.addColumnBound("POSITION_NAME", "นามสกุล")
        Rad_Utility.addColumnBound("POSITION_NAME", "ประเภทเจ้าหน้าที่")
        Rad_Utility.addColumnBound("POSITION_NAME", "หน่วยงาน")
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่")
        Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
    End Sub
    ''' <summary>
    ''' ดีงข้อมูลบุคลากรใส่ radgrid
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rgUser_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgUser.NeedDataSource
        Dim dao As New DAO_MAS.TB_MAS_USER
        dao.getdata()
        rgUser.DataSource = dao.dt
    End Sub
End Class