Partial Public Class detalleitems
    Inherits BaseBE

    'Public Sub New(be As detalleitemequivalencia_catalogos)

    'End Sub
    Public Property typeConsult As String
    Public Property Assign As Boolean
    Public Property unidadMaxima As Decimal?
    Public Property IdProducto As String
    Public Property FlagArticuloNuevo() As Boolean
    Public Property customLote As recursoCostoLote

    Public Property customdetalleitem_equivalencias As detalleitem_equivalencias

    Public Property customdetalleitemequivalencia_catalogos As detalleitemequivalencia_catalogos

    Public Property customMarca As item
    Public Property customCategoria As item

    Public Property customClasificacion As item

    Public Property customPresentacion As item
    Public Property Utilidad() As Decimal
    Public Property UtilidadMayor() As Decimal
    Public Property UtilidadGranMayor() As Decimal
    Public Property idAlmacen() As Integer

    Public Property CustomTotalAlmacen() As totalesAlmacen
    Public Property CustomDetalleCompra() As documentocompradetalle
    Public Property InventarioInicio() As documentoLibroDiarioDetalle
    Public Property CustomCierreInventario() As cierreinventario
    Public Property CustomPrecios As List(Of configuracionPrecioProducto)

    Public Property cantMax() As Decimal
    Public Property cantMinima() As Decimal

    Public Property NomClasificacion() As String
    Public Property NomMarca() As String

    Public Property CantidadKardex() As Decimal
    Public Property ImporteKardex() As Decimal
    Public Property precioMenor() As Decimal?
    Public Property precioMayor() As Decimal?
    Public Property precioGranMayor() As Decimal?

    Public Property precioMenorME() As Decimal?
    Public Property precioMayorME() As Decimal?
    Public Property precioGranMayorME() As Decimal?

    Public Property tipoCategoria() As String

    Public Property MarcaTemporal() As String

    Public Property ClasificacionTemporal() As String
    Public Property CategoriaTemporal() As String
    Public Property SubCategoriaTemporal() As String
    Public Property PresentacionTemporal() As String
    Public Property CustomSubCategoria As item

    Public Property ListaTipoExistencia As List(Of String)


End Class
