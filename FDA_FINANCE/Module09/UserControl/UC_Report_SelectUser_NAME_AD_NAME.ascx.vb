Public Class UC_Report_SelectUser_NAME_AD_NAME
    Inherits System.Web.UI.UserControl

    Private _adName As String
    Public Property adName() As String
        Get
            Return _adName
        End Get
        Set(ByVal value As String)
            _adName = value
        End Set
    End Property

    Private _id As String
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_dl_User()
    End Sub

    Public Sub bind_dl_User()
        If Not IsPostBack Then
            Dim bao As New BAO_BUDGET.USER
            Dim dt As DataTable = bao.get_NAME_AD_NAME()
            dl_User.DataSource = dt
            dl_User.DataTextField = "NAME"
            dl_User.DataValueField = "ID"
            dl_User.DataBind()
        End If
    End Sub

    Public Sub getAD_Name()
        adName = dl_User.SelectedItem.Value
        ID = dl_User.SelectedItem.Value
    End Sub

End Class