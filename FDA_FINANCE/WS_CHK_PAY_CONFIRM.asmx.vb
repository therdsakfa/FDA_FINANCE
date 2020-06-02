Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WS_CHK_PAY_CONFIRM
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function Chk_Confirm_by_Ref02(ByVal ref02 As String) As String
        Dim str_rt As String = ""
        Dim count_confirm As Integer = 0
        Dim dao_fee1 As New DAO_FEE.TB_fee
        dao_fee1.GetDataby_ref2(ref02)
        Dim bao_c As New BAO_BUDGET.MASS
        Try
            count_confirm = bao_c.SP_COUNT_CONFIRM_SCB(dao_fee1.fields.ref01, ref02)
        Catch ex As Exception

        End Try
        If count_confirm = 0 Then
            str_rt = "YES"
        ElseIf count_confirm > 0 Then
            str_rt = "NO"
        End If

        Return str_rt
    End Function
    <WebMethod()> _
    Public Function Chk_Confirm_by_Ref01(ByVal ref01 As String) As String
        Dim str_rt As String = ""
        Dim count_confirm As Integer = 0
        Dim dao_fee1 As New DAO_FEE.TB_fee
        dao_fee1.GetDataby_ref1(ref01)
        Dim bao_c As New BAO_BUDGET.MASS
        Try
            count_confirm = bao_c.SP_COUNT_CONFIRM_SCB(ref01, dao_fee1.fields.ref02)
        Catch ex As Exception

        End Try
        If count_confirm = 0 Then
            str_rt = "YES"
        ElseIf count_confirm > 0 Then
            str_rt = "NO"
        End If

        Return str_rt
    End Function
    <WebMethod()> _
    Public Function Get_Link_Receipt(ByVal ref01 As String, ByVal ref02 As String) As String
        Dim str_rt As String = ""
        Dim dao_rev As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        dao_rev.Getdata_by_ref01_ref02(ref01, ref02)
        Try
            If (dao_rev.fields.RECEIVE_MONEY_ID <> 0 And Len(dao_rev.fields.FULL_RECEIVE_NUMBER) >= 17 And dao_rev.fields.IS_CANCEL Is Nothing) Then
                str_rt = "https://buisead.fda.moph.go.th/fda_budget/Module09/Report/Frm_Report_R9_003.aspx?ref01=" & ref01 & "&ref02=" & ref02
            Else
                str_rt = "FAIL"
            End If
        Catch ex As Exception
            str_rt = "FAIL"
        End Try

        Return str_rt.ToString()
    End Function
    <WebMethod()> _
    Public Function Get_Link_Receipt_by_feeno_format(ByVal fee_format As String) As String
        Dim str_rt As String = ""
        Dim feeno As String = feeno_format(fee_format)
        Dim dao_rev As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        dao_rev.Getdata_by_feeno(feeno)
        Try
            If (dao_rev.fields.RECEIVE_MONEY_ID <> 0 And Len(dao_rev.fields.FULL_RECEIVE_NUMBER) >= 17 And dao_rev.fields.IS_CANCEL Is Nothing) Then
                str_rt = "https://buisead.fda.moph.go.th/fda_budget/Module09/Report/Frm_Report_R9_003.aspx?ref01=" & dao_rev.fields.REF01 & "&ref02=" & dao_rev.fields.REF02
            Else
                str_rt = "FAIL"
            End If
        Catch ex As Exception
            str_rt = "FAIL"
        End Try

        Return str_rt.ToString()
    End Function
    Private Function feeno_format(ByVal feeno As String)
        Dim fee_format As String = ""
        Dim arr_feeno As String() = Nothing
        Try
            arr_feeno = feeno.Split("/")
            If Len(arr_feeno(0)) < 5 Then
                Try
                    arr_feeno(0) = String.Format("{0:00000}", CInt(arr_feeno(0)))
                Catch ex As Exception

                End Try

            End If

            fee_format = arr_feeno(1) & arr_feeno(0)
        Catch ex As Exception

        End Try
        Return fee_format
    End Function
End Class