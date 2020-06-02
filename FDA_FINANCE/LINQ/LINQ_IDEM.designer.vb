﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="FDA_IDEM")>  _
Partial Public Class LINQ_IDEMDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertPerson_Detail(instance As Person_Detail)
    End Sub
  Partial Private Sub UpdatePerson_Detail(instance As Person_Detail)
    End Sub
  Partial Private Sub DeletePerson_Detail(instance As Person_Detail)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.System.Configuration.ConfigurationManager.ConnectionStrings("FDA_IDEMConnectionString").ConnectionString, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public ReadOnly Property Person_Details() As System.Data.Linq.Table(Of Person_Detail)
		Get
			Return Me.GetTable(Of Person_Detail)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.Person_Detail")>  _
Partial Public Class Person_Detail
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _CitizenID As String
	
	Private _OrgID As System.Nullable(Of Integer)
	
	Private _PersonType As System.Nullable(Of Integer)
	
	Private _PositionID As System.Nullable(Of Integer)
	
	Private _Telephone As String
	
	Private _Mobile As String
	
	Private _Email As String
	
	Private _Remark As String
	
	Private _PrefixID As System.Nullable(Of Integer)
	
	Private _FirstName As String
	
	Private _LastName As String
	
	Private _PersonStatusID As System.Nullable(Of Integer)
	
	Private _LastUpdate As System.Nullable(Of Date)
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnCitizenIDChanging(value As String)
    End Sub
    Partial Private Sub OnCitizenIDChanged()
    End Sub
    Partial Private Sub OnOrgIDChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnOrgIDChanged()
    End Sub
    Partial Private Sub OnPersonTypeChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnPersonTypeChanged()
    End Sub
    Partial Private Sub OnPositionIDChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnPositionIDChanged()
    End Sub
    Partial Private Sub OnTelephoneChanging(value As String)
    End Sub
    Partial Private Sub OnTelephoneChanged()
    End Sub
    Partial Private Sub OnMobileChanging(value As String)
    End Sub
    Partial Private Sub OnMobileChanged()
    End Sub
    Partial Private Sub OnEmailChanging(value As String)
    End Sub
    Partial Private Sub OnEmailChanged()
    End Sub
    Partial Private Sub OnRemarkChanging(value As String)
    End Sub
    Partial Private Sub OnRemarkChanged()
    End Sub
    Partial Private Sub OnPrefixIDChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnPrefixIDChanged()
    End Sub
    Partial Private Sub OnFirstNameChanging(value As String)
    End Sub
    Partial Private Sub OnFirstNameChanged()
    End Sub
    Partial Private Sub OnLastNameChanging(value As String)
    End Sub
    Partial Private Sub OnLastNameChanged()
    End Sub
    Partial Private Sub OnPersonStatusIDChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnPersonStatusIDChanged()
    End Sub
    Partial Private Sub OnLastUpdateChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnLastUpdateChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CitizenID", DbType:="NVarChar(13) NOT NULL", CanBeNull:=false, IsPrimaryKey:=true)>  _
	Public Property CitizenID() As String
		Get
			Return Me._CitizenID
		End Get
		Set
			If (String.Equals(Me._CitizenID, value) = false) Then
				Me.OnCitizenIDChanging(value)
				Me.SendPropertyChanging
				Me._CitizenID = value
				Me.SendPropertyChanged("CitizenID")
				Me.OnCitizenIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_OrgID", DbType:="Int")>  _
	Public Property OrgID() As System.Nullable(Of Integer)
		Get
			Return Me._OrgID
		End Get
		Set
			If (Me._OrgID.Equals(value) = false) Then
				Me.OnOrgIDChanging(value)
				Me.SendPropertyChanging
				Me._OrgID = value
				Me.SendPropertyChanged("OrgID")
				Me.OnOrgIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PersonType", DbType:="Int")>  _
	Public Property PersonType() As System.Nullable(Of Integer)
		Get
			Return Me._PersonType
		End Get
		Set
			If (Me._PersonType.Equals(value) = false) Then
				Me.OnPersonTypeChanging(value)
				Me.SendPropertyChanging
				Me._PersonType = value
				Me.SendPropertyChanged("PersonType")
				Me.OnPersonTypeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PositionID", DbType:="Int")>  _
	Public Property PositionID() As System.Nullable(Of Integer)
		Get
			Return Me._PositionID
		End Get
		Set
			If (Me._PositionID.Equals(value) = false) Then
				Me.OnPositionIDChanging(value)
				Me.SendPropertyChanging
				Me._PositionID = value
				Me.SendPropertyChanged("PositionID")
				Me.OnPositionIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Telephone", DbType:="NVarChar(MAX)")>  _
	Public Property Telephone() As String
		Get
			Return Me._Telephone
		End Get
		Set
			If (String.Equals(Me._Telephone, value) = false) Then
				Me.OnTelephoneChanging(value)
				Me.SendPropertyChanging
				Me._Telephone = value
				Me.SendPropertyChanged("Telephone")
				Me.OnTelephoneChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Mobile", DbType:="NVarChar(MAX)")>  _
	Public Property Mobile() As String
		Get
			Return Me._Mobile
		End Get
		Set
			If (String.Equals(Me._Mobile, value) = false) Then
				Me.OnMobileChanging(value)
				Me.SendPropertyChanging
				Me._Mobile = value
				Me.SendPropertyChanged("Mobile")
				Me.OnMobileChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Email", DbType:="NVarChar(MAX)")>  _
	Public Property Email() As String
		Get
			Return Me._Email
		End Get
		Set
			If (String.Equals(Me._Email, value) = false) Then
				Me.OnEmailChanging(value)
				Me.SendPropertyChanging
				Me._Email = value
				Me.SendPropertyChanged("Email")
				Me.OnEmailChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Remark", DbType:="NVarChar(MAX)")>  _
	Public Property Remark() As String
		Get
			Return Me._Remark
		End Get
		Set
			If (String.Equals(Me._Remark, value) = false) Then
				Me.OnRemarkChanging(value)
				Me.SendPropertyChanging
				Me._Remark = value
				Me.SendPropertyChanged("Remark")
				Me.OnRemarkChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PrefixID", DbType:="Int")>  _
	Public Property PrefixID() As System.Nullable(Of Integer)
		Get
			Return Me._PrefixID
		End Get
		Set
			If (Me._PrefixID.Equals(value) = false) Then
				Me.OnPrefixIDChanging(value)
				Me.SendPropertyChanging
				Me._PrefixID = value
				Me.SendPropertyChanged("PrefixID")
				Me.OnPrefixIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_FirstName", DbType:="NVarChar(MAX)")>  _
	Public Property FirstName() As String
		Get
			Return Me._FirstName
		End Get
		Set
			If (String.Equals(Me._FirstName, value) = false) Then
				Me.OnFirstNameChanging(value)
				Me.SendPropertyChanging
				Me._FirstName = value
				Me.SendPropertyChanged("FirstName")
				Me.OnFirstNameChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_LastName", DbType:="NVarChar(MAX)")>  _
	Public Property LastName() As String
		Get
			Return Me._LastName
		End Get
		Set
			If (String.Equals(Me._LastName, value) = false) Then
				Me.OnLastNameChanging(value)
				Me.SendPropertyChanging
				Me._LastName = value
				Me.SendPropertyChanged("LastName")
				Me.OnLastNameChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PersonStatusID", DbType:="Int")>  _
	Public Property PersonStatusID() As System.Nullable(Of Integer)
		Get
			Return Me._PersonStatusID
		End Get
		Set
			If (Me._PersonStatusID.Equals(value) = false) Then
				Me.OnPersonStatusIDChanging(value)
				Me.SendPropertyChanging
				Me._PersonStatusID = value
				Me.SendPropertyChanged("PersonStatusID")
				Me.OnPersonStatusIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_LastUpdate", DbType:="DateTime")>  _
	Public Property LastUpdate() As System.Nullable(Of Date)
		Get
			Return Me._LastUpdate
		End Get
		Set
			If (Me._LastUpdate.Equals(value) = false) Then
				Me.OnLastUpdateChanging(value)
				Me.SendPropertyChanging
				Me._LastUpdate = value
				Me.SendPropertyChanged("LastUpdate")
				Me.OnLastUpdateChanged
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class
