Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Namespace BAO_FEE
    Public Class FEE
        Public Function Queryds(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_FEEConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Function Queryds_103(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_FEEConnectionString1").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Sub SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ByVal ref01 As String, ref02 As String, ByVal process As Integer, ByVal dvcd As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_FEE_UPDATE_STATUS_PAY_COMPLETE] @ref01='" & ref01 & "', @ref02='" & ref02 & "' ,@dvcd=" & dvcd & " ,@process=" & process
            dt = Queryds(command)

        End Sub
        '
        Public Sub SP_FEE_UPDATE_STATUS_PAY_CANCEL(ByVal ref01 As String, ref02 As String, ByVal process As Integer, ByVal dvcd As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_FEE_UPDATE_STATUS_PAY_CANCEL] @ref01='" & ref01 & "', @ref02='" & ref02 & "' ,@dvcd=" & dvcd & " ,@process=" & process
            dt = Queryds(command)

        End Sub
        Public Function SP_COUNT_FEE_OLD_BY_REF01(ByVal ref01 As String)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " select * from openquery(LGTCPN,'select f.*,b.ref02 ,b.feedate as feedate2,b.enddate as enddate2 "
            command &= " ,b.lcnprnst,b.lstfcd as lstfcd2,b.lmdfdate as lmdfdate2 "
            command &= " from fda.fee f "
            command &= " join fda.feebank b on f.ref01 = b.ref01 and f.dvcd = b.dvcd and f.pvncd = b.pvncd "
            command &= " where f.rcptst <> 2  and b.ref01=''" & ref01 & "'' "
            command &= " ;')"
            'command &= " where cast(ref02 as int) = '" & ref02 & "'"
            Try
                dt = Queryds_103(command)
            Catch ex As Exception

            End Try

            'and b.ref02= ''" & ref02 & "'' "
            ''and b.ref02= ''" & ref02 & "'' "
            Return dt
        End Function
        Public Function SP_COUNT_FEE_OLD_BY_REF01_REF02(ByVal ref01 As String, ByVal ref02 As String)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " select * from openquery(LGTCPN,'select f.*,b.ref02 ,b.feedate as feedate2,b.enddate as enddate2 "
            command &= " ,b.lcnprnst,b.lstfcd as lstfcd2,b.lmdfdate as lmdfdate2 "
            command &= " from fda.fee f "
            command &= " join fda.feebank b on f.ref01 = b.ref01 and f.dvcd = b.dvcd and f.pvncd = b.pvncd "
            command &= " where b.ref01=''" & ref01 & "'' and b.ref02 =''" & ref02 & "'' "
            command &= " ;')"
            'command &= " where cast(ref02 as int) = '" & ref02 & "'"
            Try
                dt = Queryds_103(command)
            Catch ex As Exception

            End Try

            'and b.ref02= ''" & ref02 & "'' "
            ''and b.ref02= ''" & ref02 & "'' "
            Return dt
        End Function

        Public Function SP_FEEDTL(ByVal feeno As String, pvncd As String, ByVal feetpcd As String, ByVal dvcd As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " select * from openquery(LGTCPN,'select * from fda.feedtl d "
            command &= " where d.feeno=''" & feeno & "'' and d.pvncd= ''" & pvncd & "'' and d.feetpcd = ''" & feetpcd & "'' and d.dvcd =''" & dvcd & "''"
            command &= " ;')"
            Try
                dt = Queryds_103(command)
            Catch ex As Exception

            End Try
            Return dt
        End Function

        Public Function SP_GET_FEEDTL_BY_FK_FEE(ByVal fk_fee As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_FEEDTL_BY_FK_FEE] @fk_fee=" & fk_fee
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_GET_FEEDTL_BY_FK_FEE_V2(ByVal fk_fee As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_FEEDTL_BY_FK_FEE_V2] @fk_fee=" & fk_fee
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_GET_FEEDTL_BY_FK_FEE_FINE(ByVal fk_fee As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_FEEDTL_BY_FK_FEE_FINE] @fk_fee=" & fk_fee
            dt = Queryds(command)
            Return dt
        End Function
        Public Sub SP_FEE_UPDATE_STATUS_PAY_COMPLETE_TXT_EXTEND_DATE(ByVal feeno As String)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_FEE_UPDATE_STATUS_PAY_COMPLETE_TXT_EXTEND_DATE] @feeno='" & feeno & "'"
            dt = Queryds(command)

        End Sub
        Public Function SP_get_receipt_by_feeabbr_and_feeno_group_sum3(ByVal feeno As String, ByVal dvcd As Integer, ByVal feeabbr As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec dbo.SP_get_receipt_by_feeabbr_and_feeno_group_sum3 @feeno='" & feeno & "' ,@dvcd=" & dvcd & ",@feeabbr='" & feeabbr & "'"
            dt = Queryds(command)
            Return dt
        End Function
        Public Function get_lcn_name_type1(ByVal lcnsid As Integer, ByVal lcnscd As Integer) As String
            Dim dt As New DataTable
            Dim str_name As String = ""
            Dim command As String = " "
            command &= " select top(1) isnull(l.thanm,'') as fullname"
            command &= " from openquery(LGTCPN,'select thanm, prefixcd, suffixcd,lcnsid,thalnm,lcnscd,lctcd from syslcnsnm "
            command &= "  where lcnsid =" & lcnsid & " And lcnscd = " & lcnscd & " "
            command &= " ;') SLN"
            command &= " left join LGTCPN.[dbo].[sysprefix] pr on SLN.prefixcd = pr.prefixcd"
            command &= " left join LGTCPN.[dbo].[syssuffix] sf on SLN.suffixcd = sf.suffixcd"
            command &= " left join (select lcnsid,lctnmcd,thanm,lctcd"
            command &= " from openquery(LGTCPN,'select * from syslctnm where lcnsid = " & lcnsid & " "
            command &= " ;') ) l on SLN.lcnsid = l.lcnsid"
            command &= " left join (select * from openquery(LGTCPN,'select * from syslctaddr where lcnsid = " & lcnsid & " "
            command &= " ;')) a on a.lcnsid = sln.lcnsid "
            dt = Queryds_103(command)
            For Each dr As DataRow In dt.Rows
                Try
                    str_name = dr("fullname")
                Catch ex As Exception

                End Try

            Next
            Return str_name
        End Function
        Public Function get_lcn_name_type2(ByVal lcnsid As Integer, ByVal lcnscd As Integer) As String
            Dim dt As New DataTable
            Dim str_name As String = ""
            Dim command As String = " "
            command &= " Select top(1)"
            command &= " isnull(pr.thanm,'') + ' ' + isnull(SLN.thanm,'') + ' ' + "
            command &= " case when sln.thalnm is null then isnull(sf.thanm,'') else isnull(sln.thalnm,'') end as fullname"
            command &= " from openquery(LGTCPN,'select thanm, prefixcd, suffixcd,lcnsid,thalnm,lcnscd,lctcd from syslcnsnm"
            command &= "  where lcnsid =" & lcnsid & " And lcnscd = " & lcnscd & " "
            command &= " ;') SLN"
            command &= " left join LGTCPN.[dbo].[sysprefix] pr on SLN.prefixcd = pr.prefixcd"
            command &= " left join LGTCPN.[dbo].[syssuffix] sf on SLN.suffixcd = sf.suffixcd"
            command &= " left join (select lcnsid,lctnmcd,thanm,lctcd"
            command &= " from openquery(LGTCPN,'select * from syslctnm where lcnsid = " & lcnsid & " "
            command &= " ;') ) l on SLN.lcnsid = l.lcnsid"
            command &= " left join (select * from openquery(LGTCPN,'select * from syslctaddr where lcnsid = " & lcnsid & " "
            command &= " ;')) a on a.lcnsid = sln.lcnsid "
            dt = Queryds_103(command)
            For Each dr As DataRow In dt.Rows
                Try
                    str_name = dr("fullname")
                Catch ex As Exception

                End Try

            Next
            Return str_name
        End Function
    End Class
    Public Class FDA_DRUG
        Public Function Queryds(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("LGT_DRUGConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Function SP_GET_IDA_DA_FROM_FEE(ByVal ref01 As String, ref02 As String) As Integer
            Dim dt As New DataTable
            Dim IDA As Integer = 0
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_IDA_DA_FROM_FEE] @ref01='" & ref01 & "', @ref02='" & ref02 & "' "
            dt = Queryds(command)
            For Each dr As DataRow In dt.Rows
                IDA = dr("IDA")
            Next

            Return IDA
        End Function
        '
        Public Function SP_GET_IDA_DA_FROM_FEE_MULTI_ROW(ByVal ref01 As String, ref02 As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec dbo.SP_GET_IDA_DA_FROM_FEE_MULTI_ROW @ref01='" & ref01 & "', @ref02='" & ref02 & "' "
            dt = Queryds(command)
            Return dt
        End Function
    End Class
End Namespace