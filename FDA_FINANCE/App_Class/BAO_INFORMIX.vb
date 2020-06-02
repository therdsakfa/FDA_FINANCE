Imports System.Data.SqlClient

Namespace BAO_INFORMIX
    Public Class ConnectDatabass

        Public Function Queryds(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DTAMConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Sub Query_Insert(ByVal Commands As String)
            Dim dt As New DataTable
            Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DTAMConnectionString").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand
            cmd.CommandText = Commands
            cmd.Connection = conn
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
        End Sub
    End Class
    Public Class INFORMIX
        Inherits ConnectDatabass
        Public Sub TestInsert()
            Dim strSQL As String = String.Empty
            'strSQL = " insert into LGTCPN.fda.feehis(lcnsid,lcnscd,txcqty,fexpdate) "
            strSQL = "INSERT into openquery(LGTCPN, 'select * from fda.feehis') values ('124','1','5',GETDATE())"
            Query_Insert(strSQL)
        End Sub
        Public Function Count_fee(ByVal feeno As Integer, ByVal dvcd As Integer) As Boolean
            Dim dt As New DataTable
            Dim bool As Boolean = False
            Dim i As Integer = 0
            Dim command As String = " "
            command = " select * from openquery(LGTCPN,'select * from fee where feeno =" & feeno & " and dvcd =" & dvcd
            command &= " ;')"
            dt = Queryds(command)

            For Each dr As DataRow In dt.Rows
                i += 1
            Next
            If i > 0 Then
                bool = True
            End If

            Return bool
        End Function
        Public Sub insert_fee(ByVal pvncd As Integer, ByVal dvcd As Integer, ByVal feetpcd As Integer, ByVal feeno As String, ByVal feeabbr As String, Optional feedate As Object = Nothing, Optional ref1 As String = "", _
                              Optional lcnsid As Integer = 0, Optional prnfeest As Integer = 0, Optional rcptst As Integer = 0, Optional rcptyear As Integer = 0, Optional rcptno As Integer = 0, Optional rcptdate As Object = Nothing, _
                              Optional feestfcd As Integer = 0, Optional remark As String = "", Optional expdate As Object = Nothing, Optional enddate As Object = Nothing, Optional cncstfcd As Integer = 0, Optional cncdate As Object = Nothing, _
                              Optional pvnbookno As Integer = 0, Optional pvnrcptno As Integer = 0, Optional lstfcd As Integer = 0, Optional lmdfdate As Object = Nothing, Optional lctnmcd As Integer = 0, Optional lcnscd As Integer = 0, Optional lctcd As Integer = 0, Optional feest As String = "")
            Dim strSQL As String = String.Empty


            'Try
            strSQL = "INSERT into openquery(LGTCPN, 'select * from fda.fee') values "
            strSQL &= " ('" & pvncd & "','" & dvcd & "','" & feetpcd & "','" & feeno & "','" & feeabbr & "'"

            If feedate = Nothing Then
                strSQL &= " ,null"
            Else
                strSQL &= ",'" & feedate & "'"
            End If
            'strSQL &= " , '" & lctnmcd & "','" & lcnscd & "','" & lctcd & "','" & prnfeest & "'"
            strSQL &= " ,'" & ref1 & "','" & lcnsid & "','" & lctnmcd & "','" & lcnscd & "','" & lctcd & "','" & prnfeest & "','" & rcptst & "','" & rcptyear & "','" & rcptno & "'"
            If rcptdate = Nothing Then
                strSQL &= " ,null"
            Else
                strSQL &= " ,'" & rcptdate & "'"
            End If

            strSQL &= " ,'" & feestfcd & "','" & remark & "'"
            If expdate = Nothing Then
                strSQL &= " ,null"
            Else
                strSQL &= " ,'" & expdate & "'"
            End If
            If enddate = Nothing Then
                strSQL &= " ,null"
            Else
                strSQL &= " ,'" & enddate & "'"
            End If

            strSQL &= " ,'" & cncstfcd & "'"   ','" & cncdate & "'"
            If cncdate = Nothing Then
                strSQL &= " ,null"
            Else
                strSQL &= " ,'" & cncdate & "'"
            End If

            strSQL &= " ,'" & pvnbookno & "','" & pvnrcptno & "','" & feest & "','" & lstfcd & "'" ','" & lmdfdate & "'"
            If lmdfdate = Nothing Then
                strSQL &= " ,null"
            Else
                strSQL &= " ,'" & lmdfdate & "'"
            End If
            strSQL &= " )"

            Query_Insert(strSQL)
 
        End Sub
        Public Sub insert_feedtl(ByVal pvncd As Integer, ByVal dvcd As Integer, ByVal feetpcd As Integer, ByVal feeno As String, ByVal rid As Integer, ByVal rcvabbr As Integer, _
                                 ByVal rcvcd As Integer, ByVal rcvno As String, ByVal apppvncd As Integer, ByVal appabbr As String, ByVal appvcd As String, _
                                 ByVal appvno As String, ByVal timeno As String, ByVal amt As Double, ByVal finevalue As String)

            Dim strSQL As String = String.Empty
            'Try
            strSQL = "INSERT into openquery(LGTCPN, 'select * from fda.feedtl') values "
            strSQL &= " ('" & pvncd & "','" & dvcd & "','" & feetpcd & "','" & feeno & "','" & rid & "','" & rcvabbr & "','" & rcvcd & "','" & rcvno & "','" & apppvncd & "','" & appabbr & "','" & appvcd & "','" & appvno & "'"
            strSQL &= " ,'" & timeno & "','" & amt & "','" & finevalue & "'"
            strSQL &= " )"

            Query_Insert(strSQL)
            'Catch ex As Exception

            'End Try
        End Sub
        Public Sub insert_feebank(ByVal pvncd As Integer, ByVal dvcd As Integer, ByVal ref1 As String, ByVal ref2 As String, Optional enddate As Object = Nothing, _
                                  Optional lcnprnst As Integer = 0, Optional lstfcd As Integer = 0, Optional lmdfdate As Object = Nothing)
            Dim strSQL As String = String.Empty
            'Try
            strSQL = "INSERT into openquery(LGTCPN, 'select * from fda.feedtl') values "
            strSQL &= " ('" & pvncd & "','" & dvcd & "','" & ref1 & "','" & ref2 & "'"

            If enddate = Nothing Then
                strSQL &= " ,null"
            Else
                strSQL &= " ,'" & enddate & "'"
            End If
            strSQL &= ",'" & lcnprnst & "','" & lstfcd & "'"
            If lmdfdate = Nothing Then
                strSQL &= " ,null"
            Else
                strSQL &= " ,'" & lmdfdate & "'"
            End If

            strSQL &= " )"

            Query_Insert(strSQL)
            'Catch ex As Exception

            'End Try
        End Sub
        Public Function SP_GET_MAX_RCPTNO_BY_YEAR(ByVal _year As Integer) As Integer
            Dim dt As New DataTable
            Dim no As Integer = 0
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_MAX_RCPTNO_BY_YEAR] @year=" & _year
            dt = Queryds(command)

            Try
                no = dt(0)("max_no")
            Catch ex As Exception

            End Try
            Return no
        End Function
        Public Sub update_fee(ByVal lcnsid As String, ByVal feeabbr As String, ByVal dvcd As Integer, ByVal pvncd As Integer, ByVal ref1 As String)
            Dim strSQL As String = String.Empty
            Try
                strSQL = "update openquery(LGTCPN, 'select * from fda.fee') set rcptst = '1'"
                strSQL &= " where where lcnsid = ''" & lcnsid & "'' and feeabbr = ''" & feeabbr & "'' and dvcd = ''" & dvcd & "'' and pvncd = ''" & pvncd & "''"
                strSQL &= " and ref01 = ''" & ref1 & "''"
                strSQL &= " )"

                Query_Insert(strSQL)
            Catch ex As Exception

            End Try
        End Sub
        Public Function QUERY_GET_FEE_INFORMIX(ByVal feeno As String, ByVal feeabbr As String, ByVal dvcd As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command &= " SELECT * ,cast(rcptno as nvarchar(max)) + '/' + cast(rcptyear as nvarchar(max)) as receipt_number "
            command &= " , RIGHT(feeno , 5) as fee_no_5 , left(feeno , 2) as year_fee"
            command &= " ,FDA_BG.dbo.SC_LCNSID_NM(lcnsid) as fullname"
            command &= "  FROM OPENQUERY(LGTCPN,'SELECT f.lcnsid,ft.feetpnm , d.amt , ft.feeabbr,f.ref01 , case when f.rcptst = 1 then ''ชำระเงินแล้ว'' else ''ยังไม่ได้ชำระเงิน'' end as stat"
            command &= " , f.rcptno ,f.rcptyear,f.rcptst , f.feeno , f.pvncd,f.dvcd"
            command &= "  FROM fda.fee f "
            command &= "  join fda.feetype ft on f.feeabbr = ft.feeabbr"

            command &= "  join   (SELECT feeno,pvncd , dvcd,sum(amt) as amt "
            command &= " 		FROM fda.feedtl"
            command &= " 		where feeno = ''" & feeno & "'' "
            command &= " 		group by pvncd , dvcd , feeno ,feetpcd) d on f.pvncd = d.pvncd and f.dvcd = d.dvcd and f.feeno  =d.feeno"
            command &= " where f.feeabbr=''" & feeabbr & "'' and f.dvcd=''" & dvcd & "''"
            command &= " ;') "


            dt = Queryds(command)
            Return dt
        End Function
        Public Function QUERY_GET_DDL_LCNSNM(ByVal dvcd As Integer, ByVal lcnsid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command &= " select * from openquery(LGTCPN,'select s.lcnsid , s.lcnscd ,lctnmcd"
            command &= " ,l.thanm ,l.lctcd "
            command &= " from fda.syslcnsnm s "
            command &= " join fda.syslctnm l on s.lcnsid = l.lcnsid and s.lctcd = l.lctcd "
            command &= " where s.lcnsid = ''" & lcnsid & "'' and s.lcnsst=1 and dvcd = ''" & dvcd & "''"
            command &= " group by s.lcnsid , s.lcnscd,l.thanm  ,l.lctcd ,lctnmcd"
            command &= " ;') "

            dt = Queryds(command)
            Return dt
        End Function
        Public Function QUERY_GET_DDL_LCNSNM_BY_LCNSID(ByVal lcnsid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command &= " select * from openquery(LGTCPN,'select s.lcnsid , s.lcnscd ,lctnmcd"
            command &= " ,l.thanm ,l.lctcd "
            command &= " from fda.syslcnsnm s "
            command &= " join fda.syslctnm l on s.lcnsid = l.lcnsid and s.lctcd = l.lctcd "
            command &= " where s.lcnsid = ''" & lcnsid & "'' and s.lcnsst=1 "
            command &= " group by s.lcnsid , s.lcnscd,l.thanm  ,l.lctcd ,lctnmcd"
            command &= " ;') "

            dt = Queryds(command)
            Return dt
        End Function

        Public Function get_lcn_name_type(ByVal lcnsid As Integer, ByVal lcnscd As Integer) As DataTable
            Dim dt As New DataTable
            Dim str_name As String = ""
            Dim command As String = " "
            command &= " Select"
            command &= " isnull(pr.thanm,'') + ' ' + isnull(SLN.thanm,'') + ' ' + "
            command &= " case when sln.thalnm is null then isnull(sf.thanm,'') else isnull(sln.thalnm,'') end as thanm , l.lctnmcd"
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
            dt = Queryds(command)
            'For Each dr As DataRow In dt.Rows
            '    Try
            '        str_name = dr("fullname")
            '    Catch ex As Exception

            '    End Try

            'Next
            Return dt
        End Function
        Public Function Count_Repeat_Old(ByVal feeno As String, ByVal dvcd As Integer) As Boolean
            Dim dt As New DataTable
            Dim bool As Boolean = False
            Dim command As String = " "
            command &= " select * from openquery(LGTCPN,'select * from fda.fee "
            command &= " where feeno = ''" & feeno & "'' and dvcd =''" & dvcd & "'' "
            command &= " ;') "
            dt = Queryds(command)
            Try
                If dt.Rows.Count > 0 Then
                    bool = True
                End If
            Catch ex As Exception

            End Try

            Return bool
        End Function
    End Class

End Namespace

