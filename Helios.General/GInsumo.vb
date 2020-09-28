Public Class GInsumo

#Region "Atributos"
    Public Property Secuencia() As Integer
    Public Property IdActividadRecurso() As Integer?
    Public Property IdInsumo() As Integer?
    Public Property idClasificacion() As Integer?
    Public Property NomClasificacion() As String
    Public Property idEmpresa() As String
    Public Property idEstablecimiento() As Integer?
    Public Property cuenta() As String
    Public Property descripcionItem() As String
    Public Property presentacion() As String
    Public Property Nombrepresentacion() As String
    Public Property unidad1() As String
    Public Property unidadNombre() As String
    Public Property unidad2() As String
    Public Property tipoExistencia() As String
    Public Property origenProducto() As String
    Public Property tipoProducto() As String
    Public Property IdAlmacen() As String

    Public Property nroOrden() As String
    Public Property codigo() As String
    Public Property capacidad() As String
    Public Property presion() As String
    Public Property electricidad() As String
    Public Property transmision() As String
    Public Property rpm() As String
    Public Property marcaRef() As String
    Public Property nivelRuido() As String
    Public Property Peso() As String
    Public Property Filtros() As String
    Public Property estado() As String
    Public Property usuarioActualizacion() As String
    Public Property fechaActualizacion() As DateTime?

    Public Property Cantidad() As Decimal?
    Public Property PU() As Decimal?
    Public Property Total() As Decimal?
    Public Property TotalUS() As Decimal?
    Public Property IgvMN() As Decimal?
    Public Property IgvME() As Decimal?
    Public Property saldoMN() As Decimal?
    Public Property saldoME() As Decimal?

    Private Shared datos As List(Of GInsumo)
    Private Shared objItem As GInsumo

#End Region

    Public Shared Function Instance() As List(Of GInsumo)

        If datos Is Nothing Then
            datos = New List(Of GInsumo)
        End If

        Return datos
    End Function

    Public Shared Function InstanceSingle() As GInsumo

        If objItem Is Nothing Then
            objItem = New GInsumo
        End If

        Return objItem
    End Function

    Public Sub Clear()
        IdActividadRecurso = Nothing
        IdInsumo = Nothing
        idClasificacion = Nothing
        idEmpresa = Nothing
        idEstablecimiento = Nothing
        cuenta = Nothing
        descripcionItem = Nothing
        presentacion = Nothing
        unidad1 = Nothing
        unidad2 = Nothing
        tipoExistencia = Nothing
        origenProducto = Nothing
        tipoProducto = Nothing
        IdAlmacen = Nothing

        nroOrden = Nothing
        codigo = Nothing
        capacidad = Nothing
        presion = Nothing
        electricidad = Nothing
        transmision = Nothing
        rpm = Nothing
        marcaRef = Nothing
        nivelRuido = Nothing
        Peso = Nothing
        Filtros = Nothing
        estado = Nothing
        usuarioActualizacion = Nothing
        fechaActualizacion = Nothing

        Cantidad = Nothing
        PU = Nothing
        Total = Nothing
        TotalUS = Nothing

        saldoMN = Nothing
        saldoME = Nothing
        IgvMN = Nothing
        IgvME = Nothing
    End Sub


End Class
