Public Class UC_Gov_Personel_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then

        'End If
    End Sub

    Public Sub bind_ddl_dept()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_Department()
        dd_Department.DataSource = dt
        dd_Department.DataBind()
        dd_Department.DropDownInsertDataFirstRow("---เลือก---", 0)
    End Sub

    Public Sub bind_dd_bank()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_BG_BOOKBANK_NAME()

        dd_BookBank.DataSource = dt
        dd_BookBank.DataBind()
        dd_BookBank.DropDownInsertDataFirstRow("---เลือก---", 0)
    End Sub

    Public Sub bind_ddl_prefix()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_prefix2()

        dd_prefix.DataSource = dt
        dd_prefix.DataBind()
    End Sub

    Public Sub bind_ddl_Position()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_Position()

        dd_Position.DataSource = dt
        dd_Position.DataBind()
        dd_Position.DropDownInsertDataFirstRow("---เลือก---", 0)
    End Sub

    Public Sub bind_ddl_level()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_level()

        dd_level.DataSource = dt
        dd_level.DataBind()
        dd_level.DropDownInsertDataFirstRow("---เลือก---", 0)
    End Sub
   
    Public Sub insert(ByRef dao As DAO_MAS.TB_Personal)
        'dao.fields.BANK_ID = txt_Bank_Account.Text
        '  dao.fields.BANK_ID = rmt_Bank_Account.Text 'save_bank_acc(rmt_Bank_Account.Text)
        dao.fields.BANK_ID = txt_Bank_Account.Text
        dao.fields.DEPARTMENT_ID = dd_Department.SelectedValue
        dao.fields.LEVEL_ID = dd_level.SelectedValue
        dao.fields.NAME = txt_Name.Text
        dao.fields.NATIONAL_ID = txt_Personal_ID.Text
        'dao.fields.PERSON_TYPE = 2
        dao.fields.POSITION_ID = dd_Position.SelectedValue
        dao.fields.PREFIX_ID = dd_prefix.SelectedValue
        dao.fields.SURNAME = txt_Surname.Text
        dao.fields.STATUS_PERSON = dd_Status.SelectedValue
        dao.fields.COOPERATE_NUMBER = txt_cooperate.Text
        dao.fields.FK_BANK = dd_BookBank.SelectedValue

    End Sub

    Public Sub getdata(ByRef dao As DAO_MAS.TB_Personal)

        ' rmt_Bank_Account.Text = dao.fields.BANK_ID 'split_bank_acc(dao.fields.BANK_ID)
        txt_Bank_Account.Text = dao.fields.BANK_ID

        If dao.fields.DEPARTMENT_ID IsNot Nothing Then
            dd_Department.DropDownSelectData(dao.fields.DEPARTMENT_ID)
        Else
            dd_Department.DropDownSelectData(0)
        End If

        If dao.fields.LEVEL_ID IsNot Nothing Then
            dd_level.DropDownSelectData(dao.fields.LEVEL_ID)
        Else
            dd_level.DropDownSelectData(0)
        End If

        txt_Name.Text = dao.fields.NAME
        txt_Personal_ID.Text = dao.fields.NATIONAL_ID

        If dao.fields.POSITION_ID IsNot Nothing Then
            dd_Position.DropDownSelectData(dao.fields.POSITION_ID)
        Else
            dd_Position.DropDownSelectData(0)
        End If

        dd_prefix.DropDownSelectData(dao.fields.PREFIX_ID)
        txt_Surname.Text = dao.fields.SURNAME
        dd_Status.DataBind()
        dd_Status.DropDownSelectData(dao.fields.STATUS_PERSON)
        txt_cooperate.Text = dao.fields.COOPERATE_NUMBER

        If dao.fields.FK_BANK IsNot Nothing Then
            '   dd_BookBank.SelectedValue = dao.fields.FK_BANK
            dd_BookBank.DropDownSelectData(dao.fields.FK_BANK)
        Else
            dd_BookBank.DropDownSelectData(0)
        End If

    End Sub

    'Public Function split_bank_acc(ByVal str As String) As String
    '    Dim a As String = ""
    '    'a = RadMaskedTextBox1.Text
    '    Dim set1 As String = ""
    '    Dim set2 As String = ""
    '    Dim set3 As String = ""
    '    Dim set4 As String = ""
    '    Dim all As String = ""

    '    If str.Length > 10 Then
    '        'set1 = Left(a, 3)
    '        'set2 = Right(Left(a, 4), 1)
    '        'set3 = Left(Right(a, 6), 5)
    '        'set4 = Right(a, 1)
    '        'all = set1 & "-" & set2 & "-" & set3 & "-" & set4

    '        Dim arr As String() = str.Split("-")
    '        If arr.Length > 0 Then
    '            all = arr(0) & arr(1) & arr(2) & arr(3)
    '        End If
    '    Else
    '        all = str
    '    End If

    '    Return all
    'End Function

    'Public Function save_bank_acc(ByVal str As String) As String
    '    Dim set1 As String = ""
    '    Dim set2 As String = ""
    '    Dim set3 As String = ""
    '    Dim set4 As String = ""
    '    Dim all As String = ""
    '    If str.Length > 0 Then
    '        Try
    '            set1 = Left(str, 3)
    '            set2 = Right(Left(str, 4), 1)
    '            set3 = Left(Right(str, 6), 5)
    '            set4 = Right(str, 1)
    '            all = set1 & "-" & set2 & "-" & set3 & "-" & set4
    '        Catch ex As Exception

    '        End Try

    '    End If

    '    Return all
    'End Function

End Class