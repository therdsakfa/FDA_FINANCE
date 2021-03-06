﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.34209
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


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="DTAM")>  _
Partial Public Class LINQ_WELFAREDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertALL_WELFARE_BILL(instance As ALL_WELFARE_BILL)
    End Sub
  Partial Private Sub UpdateALL_WELFARE_BILL(instance As ALL_WELFARE_BILL)
    End Sub
  Partial Private Sub DeleteALL_WELFARE_BILL(instance As ALL_WELFARE_BILL)
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
	
	Public ReadOnly Property ALL_WELFARE_BILLs() As System.Data.Linq.Table(Of ALL_WELFARE_BILL)
		Get
			Return Me.GetTable(Of ALL_WELFARE_BILL)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="WELFARES.ALL_WELFARE_BILL")>  _
Partial Public Class ALL_WELFARE_BILL
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _ALL_WELFARE_ID As Integer
	
	Private _CURE_STUDY_ID As System.Nullable(Of Integer)
	
	Private _WELFARE_ID As System.Nullable(Of Integer)
	
	Private _WELFARE_CODE As String
	
	Private _BUDGET_YEAR As System.Nullable(Of Integer)
	
	Private _NAME As String
	
	Private _PERSONAL_ID As String
	
	Private _AMOUNT As System.Nullable(Of Decimal)
	
	Private _DEPARTMENT_ID As System.Nullable(Of Integer)
	
	Private _DESCRIPTION As String
	
	Private _WELFARE_DATE As System.Nullable(Of Date)
	
	Private _MONTH_LIVE As String
	
	Private _MONTH_DIS As String
	
	Private _IS_PAY_HOME As System.Nullable(Of Boolean)
	
	Private _IS_ENABLE As System.Nullable(Of Boolean)
	
	Private _USER_ID As System.Nullable(Of Integer)
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnALL_WELFARE_IDChanging(value As Integer)
    End Sub
    Partial Private Sub OnALL_WELFARE_IDChanged()
    End Sub
    Partial Private Sub OnCURE_STUDY_IDChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnCURE_STUDY_IDChanged()
    End Sub
    Partial Private Sub OnWELFARE_IDChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnWELFARE_IDChanged()
    End Sub
    Partial Private Sub OnWELFARE_CODEChanging(value As String)
    End Sub
    Partial Private Sub OnWELFARE_CODEChanged()
    End Sub
    Partial Private Sub OnBUDGET_YEARChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnBUDGET_YEARChanged()
    End Sub
    Partial Private Sub OnNAMEChanging(value As String)
    End Sub
    Partial Private Sub OnNAMEChanged()
    End Sub
    Partial Private Sub OnPERSONAL_IDChanging(value As String)
    End Sub
    Partial Private Sub OnPERSONAL_IDChanged()
    End Sub
    Partial Private Sub OnAMOUNTChanging(value As System.Nullable(Of Decimal))
    End Sub
    Partial Private Sub OnAMOUNTChanged()
    End Sub
    Partial Private Sub OnDEPARTMENT_IDChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnDEPARTMENT_IDChanged()
    End Sub
    Partial Private Sub OnDESCRIPTIONChanging(value As String)
    End Sub
    Partial Private Sub OnDESCRIPTIONChanged()
    End Sub
    Partial Private Sub OnWELFARE_DATEChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnWELFARE_DATEChanged()
    End Sub
    Partial Private Sub OnMONTH_LIVEChanging(value As String)
    End Sub
    Partial Private Sub OnMONTH_LIVEChanged()
    End Sub
    Partial Private Sub OnMONTH_DISChanging(value As String)
    End Sub
    Partial Private Sub OnMONTH_DISChanged()
    End Sub
    Partial Private Sub OnIS_PAY_HOMEChanging(value As System.Nullable(Of Boolean))
    End Sub
    Partial Private Sub OnIS_PAY_HOMEChanged()
    End Sub
    Partial Private Sub OnIS_ENABLEChanging(value As System.Nullable(Of Boolean))
    End Sub
    Partial Private Sub OnIS_ENABLEChanged()
    End Sub
    Partial Private Sub OnUSER_IDChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnUSER_IDChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_ALL_WELFARE_ID", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property ALL_WELFARE_ID() As Integer
		Get
			Return Me._ALL_WELFARE_ID
		End Get
		Set
			If ((Me._ALL_WELFARE_ID = value)  _
						= false) Then
				Me.OnALL_WELFARE_IDChanging(value)
				Me.SendPropertyChanging
				Me._ALL_WELFARE_ID = value
				Me.SendPropertyChanged("ALL_WELFARE_ID")
				Me.OnALL_WELFARE_IDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CURE_STUDY_ID", DbType:="Int")>  _
	Public Property CURE_STUDY_ID() As System.Nullable(Of Integer)
		Get
			Return Me._CURE_STUDY_ID
		End Get
		Set
			If (Me._CURE_STUDY_ID.Equals(value) = false) Then
				Me.OnCURE_STUDY_IDChanging(value)
				Me.SendPropertyChanging
				Me._CURE_STUDY_ID = value
				Me.SendPropertyChanged("CURE_STUDY_ID")
				Me.OnCURE_STUDY_IDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_WELFARE_ID", DbType:="Int")>  _
	Public Property WELFARE_ID() As System.Nullable(Of Integer)
		Get
			Return Me._WELFARE_ID
		End Get
		Set
			If (Me._WELFARE_ID.Equals(value) = false) Then
				Me.OnWELFARE_IDChanging(value)
				Me.SendPropertyChanging
				Me._WELFARE_ID = value
				Me.SendPropertyChanged("WELFARE_ID")
				Me.OnWELFARE_IDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_WELFARE_CODE", DbType:="NVarChar(50)")>  _
	Public Property WELFARE_CODE() As String
		Get
			Return Me._WELFARE_CODE
		End Get
		Set
			If (String.Equals(Me._WELFARE_CODE, value) = false) Then
				Me.OnWELFARE_CODEChanging(value)
				Me.SendPropertyChanging
				Me._WELFARE_CODE = value
				Me.SendPropertyChanged("WELFARE_CODE")
				Me.OnWELFARE_CODEChanged
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
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_NAME", DbType:="NVarChar(255)")>  _
	Public Property NAME() As String
		Get
			Return Me._NAME
		End Get
		Set
			If (String.Equals(Me._NAME, value) = false) Then
				Me.OnNAMEChanging(value)
				Me.SendPropertyChanging
				Me._NAME = value
				Me.SendPropertyChanged("NAME")
				Me.OnNAMEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PERSONAL_ID", DbType:="NVarChar(50)")>  _
	Public Property PERSONAL_ID() As String
		Get
			Return Me._PERSONAL_ID
		End Get
		Set
			If (String.Equals(Me._PERSONAL_ID, value) = false) Then
				Me.OnPERSONAL_IDChanging(value)
				Me.SendPropertyChanging
				Me._PERSONAL_ID = value
				Me.SendPropertyChanged("PERSONAL_ID")
				Me.OnPERSONAL_IDChanged
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
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DEPARTMENT_ID", DbType:="Int")>  _
	Public Property DEPARTMENT_ID() As System.Nullable(Of Integer)
		Get
			Return Me._DEPARTMENT_ID
		End Get
		Set
			If (Me._DEPARTMENT_ID.Equals(value) = false) Then
				Me.OnDEPARTMENT_IDChanging(value)
				Me.SendPropertyChanging
				Me._DEPARTMENT_ID = value
				Me.SendPropertyChanged("DEPARTMENT_ID")
				Me.OnDEPARTMENT_IDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DESCRIPTION", DbType:="NVarChar(255)")>  _
	Public Property DESCRIPTION() As String
		Get
			Return Me._DESCRIPTION
		End Get
		Set
			If (String.Equals(Me._DESCRIPTION, value) = false) Then
				Me.OnDESCRIPTIONChanging(value)
				Me.SendPropertyChanging
				Me._DESCRIPTION = value
				Me.SendPropertyChanged("DESCRIPTION")
				Me.OnDESCRIPTIONChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_WELFARE_DATE", DbType:="DateTime")>  _
	Public Property WELFARE_DATE() As System.Nullable(Of Date)
		Get
			Return Me._WELFARE_DATE
		End Get
		Set
			If (Me._WELFARE_DATE.Equals(value) = false) Then
				Me.OnWELFARE_DATEChanging(value)
				Me.SendPropertyChanging
				Me._WELFARE_DATE = value
				Me.SendPropertyChanged("WELFARE_DATE")
				Me.OnWELFARE_DATEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_MONTH_LIVE", DbType:="NVarChar(50)")>  _
	Public Property MONTH_LIVE() As String
		Get
			Return Me._MONTH_LIVE
		End Get
		Set
			If (String.Equals(Me._MONTH_LIVE, value) = false) Then
				Me.OnMONTH_LIVEChanging(value)
				Me.SendPropertyChanging
				Me._MONTH_LIVE = value
				Me.SendPropertyChanged("MONTH_LIVE")
				Me.OnMONTH_LIVEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_MONTH_DIS", DbType:="NVarChar(50)")>  _
	Public Property MONTH_DIS() As String
		Get
			Return Me._MONTH_DIS
		End Get
		Set
			If (String.Equals(Me._MONTH_DIS, value) = false) Then
				Me.OnMONTH_DISChanging(value)
				Me.SendPropertyChanging
				Me._MONTH_DIS = value
				Me.SendPropertyChanged("MONTH_DIS")
				Me.OnMONTH_DISChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IS_PAY_HOME", DbType:="Bit")>  _
	Public Property IS_PAY_HOME() As System.Nullable(Of Boolean)
		Get
			Return Me._IS_PAY_HOME
		End Get
		Set
			If (Me._IS_PAY_HOME.Equals(value) = false) Then
				Me.OnIS_PAY_HOMEChanging(value)
				Me.SendPropertyChanging
				Me._IS_PAY_HOME = value
				Me.SendPropertyChanged("IS_PAY_HOME")
				Me.OnIS_PAY_HOMEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IS_ENABLE", DbType:="Bit")>  _
	Public Property IS_ENABLE() As System.Nullable(Of Boolean)
		Get
			Return Me._IS_ENABLE
		End Get
		Set
			If (Me._IS_ENABLE.Equals(value) = false) Then
				Me.OnIS_ENABLEChanging(value)
				Me.SendPropertyChanging
				Me._IS_ENABLE = value
				Me.SendPropertyChanged("IS_ENABLE")
				Me.OnIS_ENABLEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_USER_ID", DbType:="Int")>  _
	Public Property USER_ID() As System.Nullable(Of Integer)
		Get
			Return Me._USER_ID
		End Get
		Set
			If (Me._USER_ID.Equals(value) = false) Then
				Me.OnUSER_IDChanging(value)
				Me.SendPropertyChanging
				Me._USER_ID = value
				Me.SendPropertyChanged("USER_ID")
				Me.OnUSER_IDChanged
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
