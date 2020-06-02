Imports System.Data.Odbc

Public Class WebForm5
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub CheckBoxList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckBoxList1.SelectedIndexChanged
        If CheckBoxList1.SelectedValue = "0" Then
            For Each li As ListItem In CheckBoxList1.Items
                If li.Text <> "0" Then
                    li.Enabled = False
                End If
            Next
        Else
            For Each li As ListItem In CheckBoxList1.Items
                li.Enabled = True
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim bao As New BAO_INFORMIX.INFORMIX
        'bao.TestInsert()
        'Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        'Dim connection As New OdbcConnection(connectionString)
        'Dim queryString As String = "INSERT INTO fda.feehis (lcnsid, lcnscd, txcqty, fexpdate) Values ('124','1','50',NULL)"
        'Dim command As New OdbcCommand
        'command.CommandText = queryString
        'command.Connection = connection
        'connection.Open()
        'command.ExecuteNonQuery()
        'connection.Close()

        Dim ds_bank As New DS_FEETableAdapters.feebankTableAdapter
        ds_bank.InsertQuery(10, 5, "59000000000000000", "59", Date.Now, Nothing, Nothing, 13163, Date.Now)

        Dim ds As New DS_FEETableAdapters.feeTableAdapter

        ds.InsertQuery(10, 5, 44, 0, "0244", Date.Now, "59000000000000000", 27663, 1, 1, 2, 2, 1, 2559, 0, Date.Now, 80, "", Nothing, Nothing, 0, Nothing, Nothing, Nothing, 0, 0, Date.Now)


        'insert_fee(10, 1, 44, "000000", "0219", Date.Now, "59000000000000000", "3474", 1, 1, 2, 2, 1, 2559, 0, Date.Now, 80, 0, Date.Now, Date.Now, 0, Date.Now, 0, 0, 0, 80, Date.Now)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim connection As New OdbcConnection(connectionString)
        Dim queryString As String = "select * from fda.feehis "
        Dim Adapter As New OdbcDataAdapter(queryString, connection)
        Dim dt As New DataTable

        Try
            connection.Open()
            Adapter.Fill(dt)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub Query_Insert_Informix(ByVal Commands As String)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim connection As New OdbcConnection(connectionString)
        'Dim queryString As String = "INSERT INTO fda.feehis (lcnsid, lcnscd, txcqty, fexpdate) Values ('124','1','50',NULL)"
        Dim command As New OdbcCommand
        command.CommandText = Commands
        command.Connection = connection
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub
    Public Sub insert_fee(ByVal pvncd As Integer, ByVal dvcd As Integer, ByVal feetpcd As Integer, ByVal feeno As String, ByVal feeabbr As String, Optional feedate As Object = Nothing, Optional ref1 As String = "", _
                              Optional lcnsid As Integer = 0, Optional lctnmcd As Integer = 0, Optional lcnscd As Integer = 0, Optional lctcd As Integer = 0, Optional prnfeest As Integer = 0, Optional rcptst As Integer = 0, Optional rcptyear As Integer = 0, Optional rcptno As Integer = 0, Optional rcptdate As Object = Nothing, _
                              Optional feestfcd As Integer = 0, Optional remark As String = "", Optional expdate As Object = Nothing, Optional enddate As Object = Nothing, Optional cncstfcd As Integer = 0, Optional cncdate As Object = Nothing, _
                              Optional pvnbookno As Integer = 0, Optional pvnrcptno As Integer = 0, Optional feest As Integer = 0, Optional lstfcd As Integer = 0, Optional lmdfdate As Object = Nothing)
        Dim strSQL As String = String.Empty


        'Try
        strSQL = "INSERT into (pvncd, dvcd, feetpcd, feeno, feeabbr, feedate, ref01, lcnsid, lctnmcd, lcnscd, lctcd, prnfeest, rcptst, rcptyear, rcptno "
        strSQL &= ", rcptdate, feestfcd, remark, expdate, enddate, cncstfcd, cncdate, pvnbookno, pvnrcptno, feest, lstfcd, lmdfdate) values "
        strSQL &= " ('" & pvncd & "','" & dvcd & "','" & feetpcd & "','" & feeno & "','" & feeabbr & "'"

        If feedate = Nothing Then
            strSQL &= " ,null"
        Else
            strSQL &= ",'" & CDate(feedate).ToShortDateString() & "'"
        End If
        'strSQL &= " , '" & lctnmcd & "','" & lcnscd & "','" & lctcd & "','" & prnfeest & "'"
        strSQL &= " ,'" & ref1 & "','" & lcnsid & "','" & lctnmcd & "','" & lcnscd & "','" & lctcd & "','" & prnfeest & "','" & rcptst & "','" & rcptyear & "','" & rcptno & "'"
        If rcptdate = Nothing Then
            strSQL &= " ,null"
        Else
            strSQL &= " ,'" & CDate(rcptdate).ToShortDateString & "'"
        End If

        strSQL &= " ,'" & feestfcd & "','" & remark & "'"
        If expdate = Nothing Then
            strSQL &= " ,null"
        Else
            strSQL &= " ,'" & CDate(expdate).ToShortDateString & "'"
        End If
        If enddate = Nothing Then
            strSQL &= " ,null"
        Else
            strSQL &= " ,'" & CDate(enddate).ToShortDateString & "'"
        End If

        strSQL &= " ,'" & cncstfcd & "'"   ','" & cncdate & "'"
        If cncdate = Nothing Then
            strSQL &= " ,null"
        Else
            strSQL &= " ,'" & CDate(cncdate).ToShortDateString & "'"
        End If

        strSQL &= " ,'" & pvnbookno & "','" & pvnrcptno & "','" & feest & "','" & lstfcd & "'" ','" & lmdfdate & "'"
        If lmdfdate = Nothing Then
            strSQL &= " ,null"
        Else
            strSQL &= " ,'" & CDate(lmdfdate).ToShortDateString() & "'"
        End If
        strSQL &= " )"

        Query_Insert_Informix(strSQL)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dt As New DataTable
        Dim ds As New DS_FEETableAdapters.feetypeTableAdapter
        dt = ds.GetData()

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('มีแถว " & dt.Rows.Count & " แถว');", True)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Text &= "666"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('555555');", True)
    End Sub
End Class