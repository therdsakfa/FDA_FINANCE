Imports Telerik.Web.UI
Public Class Main_Node2
    Inherits System.Web.UI.MasterPage
    Dim mmr As New RadMenuItem
    Private _budget_year As Integer
    Public Property budget_year() As Integer
        Get
            Return _budget_year
        End Get
        Set(ByVal value As Integer)
            _budget_year = value
        End Set
    End Property
    Private _dept_id As Integer
    Public Property dept_id() As Integer
        Get
            Return _dept_id
        End Get
        Set(ByVal value As Integer)
            _dept_id = value
        End Set
    End Property
    Public strDomainName As String = ""
    Public strUserName As String = ""
    Public strFullName As String = ""
    Public strPosition As String = ""
    Public strDepartmentName As String = ""
    Public intDepartmentID As Integer
    Public intPermission As Integer
    Public intGroupUser As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Request.QueryString("law") <> "" Then
                'NavigateUrl="~/Module03/Frm_Setting_Report19.aspx"
                HyperLink3.NavigateUrl &= "?law=1&n=1"
                HyperLink1.NavigateUrl &= "?law=1&n=1"
                HyperLink2.NavigateUrl &= "?law=1&n=1"
            End If

        End If
        hl_home.NavigateUrl = "~/HOME/FRM_PROJECT_SELECT.aspx?dept=" & Request.QueryString("dept") & "&myear=" & Request.QueryString("myear")
    End Sub
   
End Class