Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Public Class RecuperarCarteras
    Private Shared datos As List(Of RecuperarCarteras)

    Public Shared Function Instance() As List(Of RecuperarCarteras)

        If datos Is Nothing Then
            datos = New List(Of RecuperarCarteras)
        End If

        Return datos
    End Function

    Public Property IdProceso() As Integer
    Public Property NomProceso() As String
    Public Property IdEvento() As Integer
    Public Property NomEvento() As String
    Public Property TasaIva() As Decimal?
    Public Property Precio() As Helios.Cont.Business.Entity.configuracionPrecioProducto

    Private m_ID As String
    Public Property ID() As String
        Get
            Return m_ID
        End Get
        Set(ByVal value As String)
            m_ID = value
        End Set
    End Property

    Private m_NombreEntidad As String
    Public Property NombreEntidad() As String
        Get
            Return m_NombreEntidad
        End Get
        Set(ByVal value As String)
            m_NombreEntidad = value
        End Set
    End Property

    Private m_IdResponsable As String
    Public Property IdResponsable() As String
        Get
            Return m_IdResponsable
        End Get
        Set(ByVal value As String)
            m_IdResponsable = value
        End Set

    End Property

    Private m_Cuenta As String
    Public Property Cuenta() As String
        Get
            Return m_Cuenta
        End Get
        Set(ByVal value As String)
            m_Cuenta = value
        End Set
    End Property

    Private m_CuentaH As String
    Public Property CuentaH() As String
        Get
            Return m_CuentaH
        End Get
        Set(ByVal value As String)
            m_CuentaH = value
        End Set
    End Property
    Private m_Devengado As String
    Public Property Devengado() As String
        Get
            Return m_Devengado
        End Get
        Set(ByVal value As String)
            m_Devengado = value
        End Set
    End Property
    Private m_DevengadoH As String
    Public Property DevengadoH() As String
        Get
            Return m_DevengadoH
        End Get
        Set(ByVal value As String)
            m_DevengadoH = value
        End Set
    End Property

    Private m_NroDoc As String
    Public Property NroDoc() As String
        Get
            Return m_NroDoc
        End Get
        Set(ByVal value As String)
            m_NroDoc = value
        End Set
    End Property

    Private m_Appat As String
    Public Property Appat() As String
        Get
            Return m_Appat
        End Get
        Set(ByVal value As String)
            m_Appat = value
        End Set
    End Property

    Private m_Apmat As String
    Public Property Apmat() As String
        Get
            Return m_Apmat
        End Get
        Set(ByVal value As String)
            m_Apmat = value
        End Set
    End Property

    Private m_IDEstable As String
    Public Property IDEstable() As String
        Get
            Return m_IDEstable
        End Get
        Set(ByVal value As String)
            m_IDEstable = value
        End Set
    End Property

    Private m_Estable As String
    Public Property Estable() As String
        Get
            Return m_Estable
        End Get
        Set(ByVal value As String)
            m_Estable = value
        End Set
    End Property

    Private m_PMmn As Decimal
    Public Property PMmn() As Decimal
        Get
            Return m_PMmn
        End Get
        Set(ByVal value As Decimal)
            m_PMmn = value
        End Set
    End Property

    Private m_PMme As Decimal
    Public Property PMme() As Decimal
        Get
            Return m_PMme
        End Get
        Set(ByVal value As Decimal)
            m_PMme = value
        End Set
    End Property

    Private m_Montomn As Decimal
    Public Property Montomn() As Decimal
        Get
            Return m_Montomn
        End Get
        Set(ByVal value As Decimal)
            m_Montomn = value
        End Set
    End Property

    Private m_Montome As Decimal
    Public Property Montome() As Decimal
        Get
            Return m_Montome
        End Get
        Set(ByVal value As Decimal)
            m_Montome = value
        End Set
    End Property

    Private m_ValCompraMN As Decimal
    Public Property ValCompraMN() As Decimal
        Get
            Return m_ValCompraMN
        End Get
        Set(ByVal value As Decimal)
            m_ValCompraMN = value
        End Set
    End Property

    Private m_ValCompraME As Decimal
    Public Property ValCompraME() As Decimal
        Get
            Return m_ValCompraME
        End Get
        Set(ByVal value As Decimal)
            m_ValCompraME = value
        End Set
    End Property

End Class
