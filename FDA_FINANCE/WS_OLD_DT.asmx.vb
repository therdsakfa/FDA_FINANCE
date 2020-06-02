Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WS_OLD_DT
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function get_dvcd_auto(ByVal feeno As String, ByVal feeabbr As String) As String
        Dim str_dvcd As String = ""
        Dim bao_dvcd As New BAO_BUDGET.FDA_FEE
        Try
            str_dvcd = bao_dvcd.get_dvcd_auto(feeno, feeabbr)
        Catch ex As Exception

        End Try

        Return str_dvcd
    End Function
    <WebMethod()> _
    Public Function SP_get_receipt_by_feeabbr_and_feeno_group_sum_old2(ByVal feeno As String, ByVal dvcd As Integer, ByVal feeabbr As String) As DataTable
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.FDA_FEE
        dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum_old2(feeno, dvcd, feeabbr)
        Return dt
    End Function
    <WebMethod()> _
    Public Function get_lcn_name_type1(ByVal lcnsid As Integer, ByVal lcnscd As Integer) As String
        Dim dt As New DataTable
        Dim str_name As String = ""
        Dim bao_name As New BAO_BUDGET.FDA_FEE
        Try
            str_name = bao_name.get_lcn_name_type1(lcnsid, lcnscd)
        Catch ex As Exception

        End Try
        Return str_name
    End Function
    <WebMethod()> _
    Public Function get_lcn_name_type2(ByVal lcnsid As Integer, ByVal lcnscd As Integer) As String
        Dim dt As New DataTable
        Dim str_name As String = ""
        Dim bao_name As New BAO_BUDGET.FDA_FEE
        Try
            str_name = bao_name.get_lcn_name_type2(lcnsid, lcnscd)
        Catch ex As Exception

        End Try

        Return str_name
    End Function
    <WebMethod()> _
    Public Function SP_GET_FEEDTL_OLD(ByVal feeno As String, ByVal dvcd As Integer, ByVal pvncd As Integer, ByVal feeabbr As String) As DataTable
        Dim dt As New DataTable
        Dim bao_det As New BAO_BUDGET.FDA_FEE
        Try
            dt = bao_det.SP_GET_FEEDTL_OLD(feeno, dvcd, pvncd, feeabbr)
        Catch ex As Exception

        End Try

        Return dt
    End Function
End Class