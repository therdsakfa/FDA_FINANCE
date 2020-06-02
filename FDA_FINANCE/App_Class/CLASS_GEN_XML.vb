Imports System.IO
Imports System.Xml.Serialization

Namespace CLASS_GEN_XML

    Public Class Center
        Protected Friend _CITIEZEN_ID As String
        Protected Friend _IDA As Integer
        Protected Friend _LCN_IDA As Integer
        Protected Friend _AUTO_ID As String
        Protected Friend _BUDGET_PLAN_ID As Integer
        Protected Friend _Activity_code As String
        Protected Friend _Welfare_type As Integer
#Region "WS"
        Protected Friend WS_CENTER_CLC_NAMES As New WS_CENTER.CLC_NAMES
        Protected Friend WS_CENTER As New WS_CENTER.WS_CENTER
        Protected Friend WS_CENTER_systhmbl As New WS_CENTER.CLC_THMBLCD
        Protected Friend WS_CENTER_sysamphr As New WS_CENTER.CLC_AMPHRCD
        Protected Friend WS_CENTER_syschngwt As New WS_CENTER.CLC_CHAWTCD
#End Region

        Public Function AddValue(ByVal ob As Object) As Object
            Dim props As System.Reflection.PropertyInfo
            For Each props In ob.GetType.GetProperties()

                '     MsgBox(prop.Name & " " & prop.PropertyType.ToString())
                Dim p_type As String = props.PropertyType.ToString()
                If props.CanWrite = True Then
                    If p_type.ToUpper = "System.String".ToUpper Then
                        props.SetValue(ob, " ", Nothing)
                    ElseIf p_type.ToUpper = "System.Int32".ToUpper Then
                        props.SetValue(ob, 0, Nothing)
                    ElseIf p_type.ToUpper = "System.DateTime".ToUpper Then
                        props.SetValue(ob, Date.Now, Nothing)
                    Else
                        props.SetValue(ob, Nothing, Nothing)
                    End If
                End If

                'prop.SetValue(cls1, "")
                'Xml = Xml.Replace("_" & prop.Name, prop.GetValue(ecms, Nothing))
            Next props

            Return ob
        End Function
        Protected Friend Function AddValue2(ByVal ob As Object) As Object
            Dim props As System.Reflection.PropertyInfo
            For Each props In ob.GetType.GetProperties()

                '     MsgBox(prop.Name & " " & prop.PropertyType.ToString())
                Dim p_type As String = props.PropertyType.ToString()
                If props.CanWrite = True Then
                    If p_type.ToUpper = "System.String".ToUpper Then
                        props.SetValue(ob, " ", Nothing)
                    ElseIf p_type.ToUpper = "System.Int32".ToUpper Then

                        props.SetValue(ob, 0, Nothing)
                    ElseIf p_type.ToUpper = "System.DateTime".ToUpper Then
                        props.SetValue(ob, Date.Now, Nothing)
                    Else

                        props.SetValue(ob, Nothing, Nothing)


                    End If
                End If

                'prop.SetValue(cls1, "")
                'Xml = Xml.Replace("_" & prop.Name, prop.GetValue(ecms, Nothing))
            Next props

            Return ob
        End Function

        Public Sub GEN_XML_DEBTOR(ByVal PATH As String, ByVal p2 As CLASS_DEBTOR)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub


    End Class


    Public Class DEBTOR
        Inherits Center

        'Public Sub New()
        '    '_CITIEZEN_ID = ""
        '    '_lcnsid_customer = 0
        '    '_lcnno = ""
        '    '_fdtypecd = ""
        '    '_fdtypenm = ""
        '    '_PVNCD = "10"
        '    '_lctcd = ""
        '    '_lcntpcd = ""
        '    _BUDGET_PLAN_ID = 0
        'End Sub

        'Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "", _
        '               Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0)
        '    _CITIEZEN_ID = citizen_id
        '    _lcnsid_customer = lcnsid
        '    _lcnno = lcnno
        '    _PVNCD = pvncd
        '    _lcntpcd = lcntpcd
        '    _LCN_IDA = LCN_IDA
        'End Sub
        Public Sub New(Optional bg_id As Integer = 0)
            _BUDGET_PLAN_ID = bg_id
            '_Activity_code = act_code
        End Sub
        ''' <summary>
        ''' ลูกหนี้
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DEBTOR

            Dim class_xml As New CLASS_DEBTOR


            Dim dao_bg As New DAO_MAS.TB_BUDGET_PLAN
            dao_bg.Getdata_by_BUDGET_PLAN_ID(_BUDGET_PLAN_ID)
            Dim head_id As Integer = 0
            Dim dao_head As New DAO_MAS.TB_BUDGET_PLAN
            Dim bg_code As String = ""
            Try
                dao_head.Getdata_by_BUDGET_PLAN_ID(dao_bg.fields.BUDGET_CHILD_ID)
                bg_code = dao_head.fields.BUDGET_CODE
                head_id = dao_bg.fields.BUDGET_CHILD_ID
            Catch ex As Exception

            End Try


            'Intial Default Value
            class_xml.DEBTOR_BILLs = AddValue(class_xml.DEBTOR_BILLs)
            class_xml.DEBTOR_BILLs.BUDGET_PLAN_ID = _BUDGET_PLAN_ID

            For i As Integer = 0 To rows
                Dim dao_det As New DEBTOR_BILL_DETAIL
                dao_det = AddValue(dao_det)
                class_xml.DEBTOR_BILL_DETAILs.Add(dao_det)
            Next

           

            ''_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT()

            ''_______________MASTER_________________
            Dim bao_master As New BAO_BUDGET.MASS()

            'ชื่อคน
            class_xml.DT_MASTER.DT2 = bao_master.get_customer_gov_xml()

            ''ตำแหน่ง
            'class_xml.DT_MASTER.DT3 = bao_master.get_Position()

            '' สังกัด
            'class_xml.DT_MASTER.DT4 = bao_master.get_Department()

            'รหัสงบประมาณ
            class_xml.DT_MASTER.DT5 = bao_master.get_bg_code(head_id)
            Return class_xml


        End Function
    End Class
    Public Class STUDY
        Inherits Center

        Public Sub New(Optional bg_id As Integer = 0, Optional welfare_type As Integer = 0)
            _BUDGET_PLAN_ID = bg_id
            _Welfare_type = welfare_type
        End Sub
        ''' <summary>
        ''' ค่าเล่าเรียนบุตร
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_CURE_STUDY

            Dim class_xml As New CLASS_CURE_STUDY
            class_xml.CURE_STUDIEs = AddValue(class_xml.CURE_STUDIEs)
            class_xml.CURE_STUDIEs.BILL_TYPE_ID = _Welfare_type
            For i As Integer = 0 To rows
                Dim dao_det As New STUDY_CHILD_DETAIL
                dao_det = AddValue(dao_det)
                dao_det.IDA = i
                class_xml.STUDY_CHILD_DETAILs.Add(dao_det)
            Next

            ''_______________SHOW___________________
            'Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT()

            ''_______________MASTER_________________
            Dim bao_master As New BAO_BUDGET.MASS()

            'ชื่อคน
            class_xml.DT_MASTER.DT2 = bao_master.get_customer_gov()

            'ตำแหน่ง
            class_xml.DT_MASTER.DT3 = bao_master.get_Position()

            ' สังกัด
            class_xml.DT_MASTER.DT4 = bao_master.get_Department()

            'ครอบครัว
            class_xml.DT_MASTER.DT5 = bao_master.get_family_customer()

            Return class_xml
        End Function
    End Class

    Public Class CURE
        Inherits Center

        Public Sub New(Optional bg_id As Integer = 0, Optional welfare_type As Integer = 0)
            _BUDGET_PLAN_ID = bg_id
            _Welfare_type = welfare_type
        End Sub
        ''' <summary>
        ''' ค่ารักษาพยาบาล
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_CURE_STUDY

            Dim class_xml As New CLASS_CURE_STUDY
            class_xml.CURE_STUDIEs = AddValue(class_xml.CURE_STUDIEs)
            class_xml.CURE_STUDIEs.BILL_TYPE_ID = _Welfare_type
            For i As Integer = 0 To rows
                Dim dao_det As New CURE_BERG_DETAIL
                dao_det = AddValue(dao_det)
                dao_det.IDA = i
                class_xml.CURE_BERG_DETAIL.Add(dao_det)
            Next

            For i As Integer = 0 To rows
                Dim dao_con As New CURE_CONDITION
                dao_con = AddValue(dao_con)
                dao_con.IDA = i
                class_xml.CURE_CONDITION.Add(dao_con)
            Next
            ''_______________SHOW___________________
            'Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT()

            ''_______________MASTER_________________
            Dim bao_master As New BAO_BUDGET.MASS()

            'ชื่อคน
            class_xml.DT_MASTER.DT2 = bao_master.get_customer_gov()

            'ตำแหน่ง
            class_xml.DT_MASTER.DT3 = bao_master.get_Position()

            ' สังกัด
            class_xml.DT_MASTER.DT4 = bao_master.get_Department()

            'ครอบครัว
            class_xml.DT_MASTER.DT5 = bao_master.get_family_customer()

            Return class_xml
        End Function
    End Class
End Namespace
