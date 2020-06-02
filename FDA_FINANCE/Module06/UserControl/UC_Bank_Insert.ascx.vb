Public Partial Class UC_Bank_Insert
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Public msg As String = ""
    Public Validataion As Boolean = True


    ''' <summary>
    ''' เพิ่มข้อมูลธนาคาร
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub insert(ByRef dao As DAO_MAS.TB_MAS_BANK)
        If txtBank_Name.Text = "" Then
            msg = "กรุณากรอกข้อมูลธนาคาร"
            Validataion = False
            Exit Sub
        Else
            Validataion = True
            dao.fields.BANK_NAME = txtBank_Name.Text
        End If

    End Sub



    ''' <summary>
    ''' ดึงข้อมูลธนาคาร
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub getdata(ByRef dao As DAO_MAS.TB_MAS_BANK)
        txtBank_Name.Text = dao.fields.BANK_NAME
    End Sub
End Class