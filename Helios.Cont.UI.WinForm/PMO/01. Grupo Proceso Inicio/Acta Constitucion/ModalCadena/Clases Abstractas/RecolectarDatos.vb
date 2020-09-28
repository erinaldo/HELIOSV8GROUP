Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Public Class RecolectarDatos
    Private Shared datos As List(Of RecolectarDatos)

    Enum Venta
        Menor = 1
        Mayor = 2
        GranMayor = 3
    End Enum

    Public Shared Function Instance() As List(Of RecolectarDatos)

        If datos Is Nothing Then
            datos = New List(Of RecolectarDatos)
        End If

        Return datos

    End Function

    Private m_Secuencia As Integer
    Public Property Secuencia() As Integer
        Get
            Return m_Secuencia
        End Get
        Set(ByVal value As Integer)
            m_Secuencia = value
        End Set
    End Property


    Private m_Gravado As String
    Public Property Gravado() As String
        Get
            Return m_Gravado
        End Get
        Set(ByVal value As String)
            m_Gravado = value
        End Set
    End Property

    Private m_IdArticulo As String
    Public Property IdArticulo() As String
        Get
            Return m_IdArticulo
        End Get
        Set(ByVal value As String)
            m_IdArticulo = value
        End Set
    End Property

    Private m_NameArticulo As String
    Public Property NameArticulo() As String
        Get
            Return m_NameArticulo
        End Get
        Set(ByVal value As String)
            m_NameArticulo = value
        End Set
    End Property

    Private m_UM As String
    Public Property UM() As String
        Get
            Return m_UM
        End Get
        Set(ByVal value As String)
            m_UM = value
        End Set
    End Property

    Private m_Cantidad As Decimal
    Public Property Cantidad() As Decimal
        Get
            Return m_Cantidad
        End Get
        Set(ByVal value As Decimal)
            m_Cantidad = value
        End Set
    End Property

    Private m_PrecUnitKardexMN As Decimal
    Public Property PrecUnitKardexMN() As Decimal
        Get
            Return m_PrecUnitKardexMN
        End Get
        Set(ByVal value As Decimal)
            m_PrecUnitKardexMN = value
        End Set
    End Property

    Private m_CantDisponible As Decimal
    Public Property CantDisponible() As Decimal
        Get
            Return m_CantDisponible
        End Get
        Set(ByVal value As Decimal)
            m_CantDisponible = value
        End Set
    End Property

    Private m_PUmn As Decimal
    Public Property PUmn() As Decimal
        Get
            Return m_PUmn
        End Get
        Set(ByVal value As Decimal)
            m_PUmn = value
        End Set
    End Property

    Private m_PUme As Decimal
    Public Property PUme() As Decimal
        Get
            Return m_PUme
        End Get
        Set(ByVal value As Decimal)
            m_PUme = value
        End Set
    End Property

    Private m_ImporteMN As Decimal
    Public Property ImporteMN() As Decimal
        Get
            Return m_ImporteMN
        End Get
        Set(ByVal value As Decimal)
            m_ImporteMN = value
        End Set
    End Property

    Private m_ImporteME As Decimal
    Public Property ImporteME() As Decimal
        Get
            Return m_ImporteME
        End Get
        Set(ByVal value As Decimal)
            m_ImporteME = value
        End Set
    End Property

    Private m_DsctoMN As Decimal
    Public Property DsctoMN() As Decimal
        Get
            Return m_DsctoMN
        End Get
        Set(ByVal value As Decimal)
            m_DsctoMN = value
        End Set
    End Property

    Private m_DsctoME As Decimal
    Public Property DsctoME() As Decimal
        Get
            Return m_DsctoME
        End Get
        Set(ByVal value As Decimal)
            m_DsctoME = value
        End Set
    End Property

    Private m_KardexMN As Decimal
    Public Property KardexMN() As Decimal
        Get
            Return m_KardexMN
        End Get
        Set(ByVal value As Decimal)
            m_KardexMN = value
        End Set
    End Property

    Private m_IscMN As Decimal
    Public Property IscMN() As Decimal
        Get
            Return m_IscMN
        End Get
        Set(ByVal value As Decimal)
            m_IscMN = value
        End Set
    End Property

    Private m_IgvMN As Decimal
    Public Property IgvMN() As Decimal
        Get
            Return m_IgvMN
        End Get
        Set(ByVal value As Decimal)
            m_IgvMN = value
        End Set
    End Property

    Private m_OtcMN As Decimal
    Public Property OtcMN() As Decimal
        Get
            Return m_OtcMN
        End Get
        Set(ByVal value As Decimal)
            m_OtcMN = value
        End Set
    End Property

    Private m_KardexME As Decimal
    Public Property KardexME() As Decimal
        Get
            Return m_KardexME
        End Get
        Set(ByVal value As Decimal)
            m_KardexME = value
        End Set
    End Property

    Private m_IscME As Decimal
    Public Property IscME() As Decimal
        Get
            Return m_IscME
        End Get
        Set(ByVal value As Decimal)
            m_IscME = value
        End Set
    End Property

    Private m_IgvME As Decimal
    Public Property IgvME() As Decimal
        Get
            Return m_IgvME
        End Get
        Set(ByVal value As Decimal)
            m_IgvME = value
        End Set
    End Property

    Private m_OtcME As Decimal
    Public Property OtcME() As Decimal
        Get
            Return m_OtcME
        End Get
        Set(ByVal value As Decimal)
            m_OtcME = value
        End Set
    End Property

    Private m_Estado As String
    Public Property Estado() As String
        Get
            Return m_Estado
        End Get
        Set(ByVal value As String)
            m_Estado = value
        End Set
    End Property

    Private m_TipoExistencia As String
    Public Property TipoExistencia() As String
        Get
            Return m_TipoExistencia
        End Get
        Set(ByVal value As String)
            m_TipoExistencia = value
        End Set
    End Property

    Private m_IdAlmacen As String
    Public Property IdAlmacen() As String
        Get
            Return m_IdAlmacen
        End Get
        Set(ByVal value As String)
            m_IdAlmacen = value
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

    Private m_Establecimiento As String
    Public Property Establecimiento() As String
        Get
            Return m_Establecimiento
        End Get
        Set(ByVal value As String)
            m_Establecimiento = value
        End Set
    End Property

    Private m_PreEvento As String
    Public Property PreEvento() As String
        Get
            Return m_PreEvento
        End Get
        Set(ByVal value As String)
            m_PreEvento = value
        End Set
    End Property

    Private m_PrecUnitKardexME As Decimal
    Public Property PrecUnitKardexME() As Decimal
        Get
            Return m_PrecUnitKardexME
        End Get
        Set(ByVal value As Decimal)
            m_PrecUnitKardexME = value
        End Set
    End Property

    Private m_Presentacion As String
    Public Property Presentacion() As String
        Get
            Return m_Presentacion
        End Get
        Set(ByVal value As String)
            m_Presentacion = value
        End Set
    End Property

    Private m_FechaVcto As Nullable(Of DateTime) = Nothing
    Public Property FechaVcto() As Nullable(Of DateTime)
        Get
            Return m_FechaVcto
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            m_FechaVcto = value
        End Set
    End Property

    Private m_NamePresentacion As String
    Public Property NamePresentacion() As String
        Get
            Return m_NamePresentacion
        End Get
        Set(ByVal value As String)
            m_NamePresentacion = value
        End Set
    End Property

    Private m_TipoVenta As String
    Public Property TipoVenta() As String
        Get
            Return m_TipoVenta
        End Get
        Set(ByVal value As String)
            m_TipoVenta = value
        End Set
    End Property

End Class
