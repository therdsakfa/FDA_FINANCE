Public Class BAO_SHOW

    Public conn As String = System.Configuration.ConfigurationManager.ConnectionStrings("LGTCPNConnectionString").ConnectionString

    ''' <summary>
    ''' ใส่ค่าว่างใน DT
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function AddDatatable(ByVal dt As DataTable) As DataTable
        Dim dr As DataRow = dt.NewRow
        For Each c As DataColumn In dt.Columns
            If c.DataType.Name.ToString() = "String" Then
                dr(c.ColumnName) = ""
            ElseIf c.DataType.Name.ToString() = "Int32" Then
                dr(c.ColumnName) = 0
            ElseIf c.DataType.Name.ToString() = "DateTime" Then
                dr(c.ColumnName) = Nothing 'Date.Now
            Else
                Try
                    dr(c.ColumnName) = Nothing
                Catch ex As Exception
                    dr(c.ColumnName) = 0
                End Try


            End If

        Next

        dt.Rows.Add(dr)
        Return dt
    End Function



    ''' <summary>
    ''' ดึงข้อมูล จังหวัด
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_SP_SYSCHNGWT() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSCHNGWT"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_SYSCHNGWT"
        Return dt
    End Function


    ''' <summary>
    ''' ดึงข้อมูล อำเภอ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_SP_SYSAMPHR() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSAMPHR"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_SYSAMPHR"
        Return dt
    End Function

    ''' <summary>
    ''' ดึงข้อมูล ตำบล
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_SP_SYSTHMBL() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSTHMBL"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_SYSTHMBL"
        Return dt
    End Function

    ''' <summary>
    ''' ดึงข้อมูลจากเลขบัตรประชาชน
    ''' </summary>
    ''' <param name="CTZNO"></param>
    ''' <returns></returns>]\
    ''' <remarks></remarks>
    Public Function SP_MAINPERSON_CTZNO(ByVal CTZNO As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MAINPERSON_CTZNO @ctzno = '" & CTZNO & "'"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MAINPERSON_CTZNO"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function


    ''' <summary>
    ''' ดึงข้อมูลบริษัท
    ''' </summary>
    ''' <param name="FK_IDA"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_MAINCOMPANY_LCNSID(ByVal FK_IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MAINCOMPANY_LCNSID @LCNSID = " & FK_IDA & ",@lctcd = 1"
        Dim dt As New DataTable
        dt.TableName = "SP_MAINCOMPANY"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function



    ''' <summary>
    ''' ดึงข้อมูลประเทศ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_SYSISOCNT() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSISOCNT"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_SYSISOCNT"
        Return dt
    End Function

End Class
