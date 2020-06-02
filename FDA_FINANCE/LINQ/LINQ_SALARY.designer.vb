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


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="FDA_BG")>  _
Partial Public Class LINQ_SALARYDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertSALARY(instance As SALARY)
    End Sub
  Partial Private Sub UpdateSALARY(instance As SALARY)
    End Sub
  Partial Private Sub DeleteSALARY(instance As SALARY)
    End Sub
  Partial Private Sub InsertSALARY_DETAIL_ID(instance As SALARY_DETAIL_ID)
    End Sub
  Partial Private Sub UpdateSALARY_DETAIL_ID(instance As SALARY_DETAIL_ID)
    End Sub
  Partial Private Sub DeleteSALARY_DETAIL_ID(instance As SALARY_DETAIL_ID)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.System.Configuration.ConfigurationManager.ConnectionStrings("DTAMConnectionString").ConnectionString, mappingSource)
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
	
	Public ReadOnly Property SALARies() As System.Data.Linq.Table(Of SALARY)
		Get
			Return Me.GetTable(Of SALARY)
		End Get
	End Property
	
	Public ReadOnly Property SALARY_DETAIL_IDs() As System.Data.Linq.Table(Of SALARY_DETAIL_ID)
		Get
			Return Me.GetTable(Of SALARY_DETAIL_ID)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.SALARY")>  _
Partial Public Class SALARY
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _IDRUN As Integer
	
	Private _PERSON_FK_ID As System.Nullable(Of Integer)
	
	Private _Month_number As System.Nullable(Of Integer)
	
	Private _BUDGET_YEAR As System.Nullable(Of Integer)
	
	Private _PER_TYPE As System.Nullable(Of Integer)
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnIDRUNChanging(value As Integer)
    End Sub
    Partial Private Sub OnIDRUNChanged()
    End Sub
    Partial Private Sub OnPERSON_FK_IDChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnPERSON_FK_IDChanged()
    End Sub
    Partial Private Sub OnMonth_numberChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnMonth_numberChanged()
    End Sub
    Partial Private Sub OnBUDGET_YEARChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnBUDGET_YEARChanged()
    End Sub
    Partial Private Sub OnPER_TYPEChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnPER_TYPEChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IDRUN", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property IDRUN() As Integer
		Get
			Return Me._IDRUN
		End Get
		Set
			If ((Me._IDRUN = value)  _
						= false) Then
				Me.OnIDRUNChanging(value)
				Me.SendPropertyChanging
				Me._IDRUN = value
				Me.SendPropertyChanged("IDRUN")
				Me.OnIDRUNChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PERSON_FK_ID", DbType:="Int")>  _
	Public Property PERSON_FK_ID() As System.Nullable(Of Integer)
		Get
			Return Me._PERSON_FK_ID
		End Get
		Set
			If (Me._PERSON_FK_ID.Equals(value) = false) Then
				Me.OnPERSON_FK_IDChanging(value)
				Me.SendPropertyChanging
				Me._PERSON_FK_ID = value
				Me.SendPropertyChanged("PERSON_FK_ID")
				Me.OnPERSON_FK_IDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Month_number", DbType:="Int")>  _
	Public Property Month_number() As System.Nullable(Of Integer)
		Get
			Return Me._Month_number
		End Get
		Set
			If (Me._Month_number.Equals(value) = false) Then
				Me.OnMonth_numberChanging(value)
				Me.SendPropertyChanging
				Me._Month_number = value
				Me.SendPropertyChanged("Month_number")
				Me.OnMonth_numberChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_BUDGET_YEAR", DbType:="Int")>  _
	Public Property BUDGET_YEAR() As System.Nullable(Of Integer)
		Get
			Return Me._BUDGET_YEAR
		End Get
		Set
			If (Me._BUDGET_YEAR.Equals(value) = false) Then
				Me.OnBUDGET_YEARChanging(value)
				Me.SendPropertyChanging
				Me._BUDGET_YEAR = value
				Me.SendPropertyChanged("BUDGET_YEAR")
				Me.OnBUDGET_YEARChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PER_TYPE", DbType:="Int")>  _
	Public Property PER_TYPE() As System.Nullable(Of Integer)
		Get
			Return Me._PER_TYPE
		End Get
		Set
			If (Me._PER_TYPE.Equals(value) = false) Then
				Me.OnPER_TYPEChanging(value)
				Me.SendPropertyChanging
				Me._PER_TYPE = value
				Me.SendPropertyChanged("PER_TYPE")
				Me.OnPER_TYPEChanged
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

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.SALARY_DETAIL_ID")>  _
Partial Public Class SALARY_DETAIL_ID
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _SALARY_DETAIL_ID As Integer
	
	Private _SALARY_ID As System.Nullable(Of Integer)
	
	Private _SALARY_PAYLIST_ID As System.Nullable(Of Integer)
	
	Private _AMOUNT As System.Nullable(Of Decimal)
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnSALARY_DETAIL_IDChanging(value As Integer)
    End Sub
    Partial Private Sub OnSALARY_DETAIL_IDChanged()
    End Sub
    Partial Private Sub OnSALARY_IDChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnSALARY_IDChanged()
    End Sub
    Partial Private Sub OnSALARY_PAYLIST_IDChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnSALARY_PAYLIST_IDChanged()
    End Sub
    Partial Private Sub OnAMOUNTChanging(value As System.Nullable(Of Decimal))
    End Sub
    Partial Private Sub OnAMOUNTChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_SALARY_DETAIL_ID", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property SALARY_DETAIL_ID() As Integer
		Get
			Return Me._SALARY_DETAIL_ID
		End Get
		Set
			If ((Me._SALARY_DETAIL_ID = value)  _
						= false) Then
				Me.OnSALARY_DETAIL_IDChanging(value)
				Me.SendPropertyChanging
				Me._SALARY_DETAIL_ID = value
				Me.SendPropertyChanged("SALARY_DETAIL_ID")
				Me.OnSALARY_DETAIL_IDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_SALARY_ID", DbType:="Int")>  _
	Public Property SALARY_ID() As System.Nullable(Of Integer)
		Get
			Return Me._SALARY_ID
		End Get
		Set
			If (Me._SALARY_ID.Equals(value) = false) Then
				Me.OnSALARY_IDChanging(value)
				Me.SendPropertyChanging
				Me._SALARY_ID = value
				Me.SendPropertyChanged("SALARY_ID")
				Me.OnSALARY_IDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_SALARY_PAYLIST_ID", DbType:="Int")>  _
	Public Property SALARY_PAYLIST_ID() As System.Nullable(Of Integer)
		Get
			Return Me._SALARY_PAYLIST_ID
		End Get
		Set
			If (Me._SALARY_PAYLIST_ID.Equals(value) = false) Then
				Me.OnSALARY_PAYLIST_IDChanging(value)
				Me.SendPropertyChanging
				Me._SALARY_PAYLIST_ID = value
				Me.SendPropertyChanged("SALARY_PAYLIST_ID")
				Me.OnSALARY_PAYLIST_IDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_AMOUNT", DbType:="Money")>  _
	Public Property AMOUNT() As System.Nullable(Of Decimal)
		Get
			Return Me._AMOUNT
		End Get
		Set
			If (Me._AMOUNT.Equals(value) = false) Then
				Me.OnAMOUNTChanging(value)
				Me.SendPropertyChanging
				Me._AMOUNT = value
				Me.SendPropertyChanged("AMOUNT")
				Me.OnAMOUNTChanged
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