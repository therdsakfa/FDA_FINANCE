Public Class UC_Maintain_ReturnMoney_Search
    Inherits System.Web.UI.UserControl

    Private _Debtor_Name As String
    Public Property Debtor_Name() As String
        Get
            Return _Debtor_Name
        End Get
        Set(ByVal value As String)
            _Debtor_Name = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' Function รับค่า Where ชื่อลูกหนี้
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getSearchMsg() As String
        Dim strMsg As String = ""

        strMsg = "([Fullname] LIKE '%" & txt_Debtor_Name.Text & "%') AND [BILL_NUMBER] LIKE '%" & txt_Bill_Number.Text & "%'"

        Return strMsg
    End Function
End Class