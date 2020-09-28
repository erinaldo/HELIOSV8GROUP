Imports Helios.Cont.Business.Entity

Public Module TablasGenerales

    Public Property ListadoProductosSingleton As List(Of detalleitems)


    Public Function GetFormasDePago() As List(Of tabladetalle)
        GetFormasDePago = New List(Of tabladetalle) From
        {
        New tabladetalle With {.codigoDetalle = "109", .descripcion = "EFECTIVO"},
        New tabladetalle With {.codigoDetalle = "001", .descripcion = "DEPOSITO EN CUENTA"},
        New tabladetalle With {.codigoDetalle = "004", .descripcion = "ORDEN DE PAGO"},
        New tabladetalle With {.codigoDetalle = "005", .descripcion = "TARJETA DE DEBITO"},
        New tabladetalle With {.codigoDetalle = "006", .descripcion = "TARJETA DE CREDITO"},
        New tabladetalle With {.codigoDetalle = "007", .descripcion = "CHEQUES"}
        }
    End Function

    Public Function GetExistencias() As List(Of tabladetalle)
        GetExistencias = New List(Of tabladetalle) From
            {
                New tabladetalle With
                {
                .codigoDetalle = "01",
                .codigoDetalle2 = "ME",
                .descripcion = "MERCADERIA"
                },
                New tabladetalle With
                {
                .codigoDetalle = "02",
                .codigoDetalle2 = "PT",
                .descripcion = "PRODUCTO TERMINADO"
                },
                New tabladetalle With
                {
                .codigoDetalle = "03",
                .codigoDetalle2 = "MP",
                .descripcion = "MATERIA PRIMA"
                },
                New tabladetalle With
                {
                .codigoDetalle = "04",
                .codigoDetalle2 = "EVB",
                .descripcion = "ENVASES Y EMBALAJES"
                },
                New tabladetalle With
                {
                .codigoDetalle = "05",
                .codigoDetalle2 = "MASR",
                .descripcion = "MATERIALES AUXILIARES, SUMINISTROS Y RESPUESTOS"
                },
                New tabladetalle With
                {
                .codigoDetalle = "06",
                .codigoDetalle2 = "SPDD",
                .descripcion = "SUB-PRODUCTOS, DESECHOS Y DESPERDICIOS"
                },
                New tabladetalle With
                {
                .codigoDetalle = "07",
                .codigoDetalle2 = "PPR",
                .descripcion = "PRODUCTOS EN PROCESO"
                },
                New tabladetalle With
                {
                .codigoDetalle = "08",
                .codigoDetalle2 = "ACI",
                .descripcion = "ACTIVO INMOVILIZADO"
                },
                New tabladetalle With
                {
                .codigoDetalle = "09",
                .codigoDetalle2 = "KIT",
                .descripcion = "KIT"
                }
            }
    End Function

    Public Function GetComprobantesCompra() As List(Of tabladetalle)

        GetComprobantesCompra = New List(Of tabladetalle) From
            {
            New tabladetalle With
            {
            .codigoDetalle = "01",
            .codigoDetalle2 = "F",
            .descripcion = "FACTURA"
        },
        New tabladetalle With
            {
            .codigoDetalle = "03",
            .codigoDetalle2 = "F",
            .descripcion = "BOLETA"
            }
        }

    End Function

    Public Function GetMonedas() As List(Of tabladetalle)
        GetMonedas = New List(Of tabladetalle) From
            {
                New tabladetalle With {
                .codigoDetalle = "1",
                .codigoDetalle2 = "PEN",
                .descripcion = "NUEVO SOL"
                },
                New tabladetalle With {
                .codigoDetalle = "2",
                .codigoDetalle2 = "USD",
                .descripcion = "DOLAR AMERICANO"
                }
            }
    End Function


    Public Class EstructuraGuiaRemision
        Public Property TipoDoc As String
        Public Property Serie As String
        Public Property numero As String
        Public Property Matricula As String
        Public Property Chofer As String
        Public Property Codigousuario As String
        Public Property NameUsuario As String
        Public Property IdUsuario As Integer
    End Class

End Module
