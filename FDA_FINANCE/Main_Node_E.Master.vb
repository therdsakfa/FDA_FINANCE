Imports Telerik.Web.UI
Public Class Main_Node_E
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
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")
            '_thanm_customer = Session("thanm_customer")
            '    _thanm = Session("thanm")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            Try
                Dim dao As New DAO_MAS.TB_MAS_DEPARTMENT
                Dim _dep As Integer = 0
                Try
                    _dep = Request.QueryString("dept")
                    dao.Getdata_by_DEPARTMENT_ID(_dep)
                    'lb_dept.Text = dao.fields.DEPARTMENT_DESCRIPTION
                Catch ex As Exception

                End Try

                Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

                Dim ws_taxno = ws2.getProfile_byidentify(_CLS.CITIZEN_ID)

                Dim CITIzen_id = ws_taxno.SYSLCNSIDs.identify
                Dim birthday = ws_taxno.SYSLCNSIDs.birthdate

                Dim fullname As String = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
                lb_name.Text = fullname
                Dim addr = ws_taxno.SYSLCTADDRs.Fulladdr
            Catch ex As Exception
                Response.Redirect("http://privus.fda.moph.go.th/")
            End Try
            

        End If
        hl_home.NavigateUrl = "~/HOME/FRM_PROJECT_SELECT.aspx?dept=" & Request.QueryString("dept") & "&myear=" & Request.QueryString("myear")
    End Sub

End Class