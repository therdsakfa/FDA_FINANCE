﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
'
Namespace WS_PERSONAL_DEPARTMENT
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="BasicHttpBinding_IDOCService", [Namespace]:="http://tempuri.org/")>  _
    Partial Public Class DOCService
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private getORGOperationCompleted As System.Threading.SendOrPostCallback
        
        Private getMemberOperationCompleted As System.Threading.SendOrPostCallback
        
        Private getMemberProfileOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.FDA_FINANCE.My.MySettings.Default.FDA_FINANCE_WS_PERSONAL_DEPARTMENT_DOCService
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event getORGCompleted As getORGCompletedEventHandler
        
        '''<remarks/>
        Public Event getMemberCompleted As getMemberCompletedEventHandler
        
        '''<remarks/>
        Public Event getMemberProfileCompleted As getMemberProfileCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IDOCService/getORG", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function getORG() As <System.Xml.Serialization.XmlArrayAttribute(IsNullable:=true), System.Xml.Serialization.XmlArrayItemAttribute([Namespace]:="http://schemas.datacontract.org/2004/07/DocService.Class")> ORGDetailClass()
            Dim results() As Object = Me.Invoke("getORG", New Object(-1) {})
            Return CType(results(0),ORGDetailClass())
        End Function
        
        '''<remarks/>
        Public Overloads Sub getORGAsync()
            Me.getORGAsync(Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub getORGAsync(ByVal userState As Object)
            If (Me.getORGOperationCompleted Is Nothing) Then
                Me.getORGOperationCompleted = AddressOf Me.OngetORGOperationCompleted
            End If
            Me.InvokeAsync("getORG", New Object(-1) {}, Me.getORGOperationCompleted, userState)
        End Sub
        
        Private Sub OngetORGOperationCompleted(ByVal arg As Object)
            If (Not (Me.getORGCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent getORGCompleted(Me, New getORGCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IDOCService/getMember", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function getMember(<System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)> ByVal SearchName As String, ByVal OrgID As Integer, <System.Xml.Serialization.XmlIgnoreAttribute()> ByVal OrgIDSpecified As Boolean) As <System.Xml.Serialization.XmlArrayAttribute(IsNullable:=true), System.Xml.Serialization.XmlArrayItemAttribute([Namespace]:="http://schemas.datacontract.org/2004/07/DocService.Class")> MemberDetailClass()
            Dim results() As Object = Me.Invoke("getMember", New Object() {SearchName, OrgID, OrgIDSpecified})
            Return CType(results(0),MemberDetailClass())
        End Function
        
        '''<remarks/>
        Public Overloads Sub getMemberAsync(ByVal SearchName As String, ByVal OrgID As Integer, ByVal OrgIDSpecified As Boolean)
            Me.getMemberAsync(SearchName, OrgID, OrgIDSpecified, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub getMemberAsync(ByVal SearchName As String, ByVal OrgID As Integer, ByVal OrgIDSpecified As Boolean, ByVal userState As Object)
            If (Me.getMemberOperationCompleted Is Nothing) Then
                Me.getMemberOperationCompleted = AddressOf Me.OngetMemberOperationCompleted
            End If
            Me.InvokeAsync("getMember", New Object() {SearchName, OrgID, OrgIDSpecified}, Me.getMemberOperationCompleted, userState)
        End Sub
        
        Private Sub OngetMemberOperationCompleted(ByVal arg As Object)
            If (Not (Me.getMemberCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent getMemberCompleted(Me, New getMemberCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IDOCService/getMemberProfile", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function getMemberProfile(<System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)> ByVal CitizenID As String) As <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)> MemberDetailClass
            Dim results() As Object = Me.Invoke("getMemberProfile", New Object() {CitizenID})
            Return CType(results(0),MemberDetailClass)
        End Function
        
        '''<remarks/>
        Public Overloads Sub getMemberProfileAsync(ByVal CitizenID As String)
            Me.getMemberProfileAsync(CitizenID, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub getMemberProfileAsync(ByVal CitizenID As String, ByVal userState As Object)
            If (Me.getMemberProfileOperationCompleted Is Nothing) Then
                Me.getMemberProfileOperationCompleted = AddressOf Me.OngetMemberProfileOperationCompleted
            End If
            Me.InvokeAsync("getMemberProfile", New Object() {CitizenID}, Me.getMemberProfileOperationCompleted, userState)
        End Sub
        
        Private Sub OngetMemberProfileOperationCompleted(ByVal arg As Object)
            If (Not (Me.getMemberProfileCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent getMemberProfileCompleted(Me, New getMemberProfileCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://schemas.datacontract.org/2004/07/DocService.Class")>  _
    Partial Public Class ORGDetailClass
        
        Private orgIDField As Integer
        
        Private orgIDFieldSpecified As Boolean
        
        Private orgNameField As String
        
        '''<remarks/>
        Public Property OrgID() As Integer
            Get
                Return Me.orgIDField
            End Get
            Set
                Me.orgIDField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property OrgIDSpecified() As Boolean
            Get
                Return Me.orgIDFieldSpecified
            End Get
            Set
                Me.orgIDFieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property OrgName() As String
            Get
                Return Me.orgNameField
            End Get
            Set
                Me.orgNameField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://schemas.datacontract.org/2004/07/DocService.Class")>  _
    Partial Public Class MemberDetailClass
        
        Private citizenIDField As String
        
        Private emailField As String
        
        Private firstNameField As String
        
        Private fullAddressField As String
        
        Private fullNameField As String
        
        Private gmailField As String
        
        Private lastNameField As String
        
        Private mobilePhoneField As String
        
        Private orgIDField As Integer
        
        Private orgIDFieldSpecified As Boolean
        
        Private orgNameField As String
        
        Private positionField As String
        
        Private positionIDField As Integer
        
        Private positionIDFieldSpecified As Boolean
        
        Private prefixField As String
        
        Private prefixIDField As Integer
        
        Private prefixIDFieldSpecified As Boolean
        
        Private telephoneField As String
        
        Private userTypeField As Integer
        
        Private userTypeFieldSpecified As Boolean
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property CitizenID() As String
            Get
                Return Me.citizenIDField
            End Get
            Set
                Me.citizenIDField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property Email() As String
            Get
                Return Me.emailField
            End Get
            Set
                Me.emailField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property FirstName() As String
            Get
                Return Me.firstNameField
            End Get
            Set
                Me.firstNameField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property FullAddress() As String
            Get
                Return Me.fullAddressField
            End Get
            Set
                Me.fullAddressField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property FullName() As String
            Get
                Return Me.fullNameField
            End Get
            Set
                Me.fullNameField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property Gmail() As String
            Get
                Return Me.gmailField
            End Get
            Set
                Me.gmailField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property LastName() As String
            Get
                Return Me.lastNameField
            End Get
            Set
                Me.lastNameField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property MobilePhone() As String
            Get
                Return Me.mobilePhoneField
            End Get
            Set
                Me.mobilePhoneField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property OrgID() As Integer
            Get
                Return Me.orgIDField
            End Get
            Set
                Me.orgIDField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property OrgIDSpecified() As Boolean
            Get
                Return Me.orgIDFieldSpecified
            End Get
            Set
                Me.orgIDFieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property OrgName() As String
            Get
                Return Me.orgNameField
            End Get
            Set
                Me.orgNameField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property Position() As String
            Get
                Return Me.positionField
            End Get
            Set
                Me.positionField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property PositionID() As Integer
            Get
                Return Me.positionIDField
            End Get
            Set
                Me.positionIDField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property PositionIDSpecified() As Boolean
            Get
                Return Me.positionIDFieldSpecified
            End Get
            Set
                Me.positionIDFieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property Prefix() As String
            Get
                Return Me.prefixField
            End Get
            Set
                Me.prefixField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property PrefixID() As Integer
            Get
                Return Me.prefixIDField
            End Get
            Set
                Me.prefixIDField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property PrefixIDSpecified() As Boolean
            Get
                Return Me.prefixIDFieldSpecified
            End Get
            Set
                Me.prefixIDFieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
        Public Property Telephone() As String
            Get
                Return Me.telephoneField
            End Get
            Set
                Me.telephoneField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property UserType() As Integer
            Get
                Return Me.userTypeField
            End Get
            Set
                Me.userTypeField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property UserTypeSpecified() As Boolean
            Get
                Return Me.userTypeFieldSpecified
            End Get
            Set
                Me.userTypeFieldSpecified = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")>  _
    Public Delegate Sub getORGCompletedEventHandler(ByVal sender As Object, ByVal e As getORGCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class getORGCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As ORGDetailClass()
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),ORGDetailClass())
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")>  _
    Public Delegate Sub getMemberCompletedEventHandler(ByVal sender As Object, ByVal e As getMemberCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class getMemberCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As MemberDetailClass()
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),MemberDetailClass())
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")>  _
    Public Delegate Sub getMemberProfileCompletedEventHandler(ByVal sender As Object, ByVal e As getMemberProfileCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class getMemberProfileCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As MemberDetailClass
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),MemberDetailClass)
            End Get
        End Property
    End Class
End Namespace
