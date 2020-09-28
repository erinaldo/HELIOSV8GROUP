Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class documentoconsumodirectoBL
    Inherits BaseBL

    Public Function GetConsumoByidDocumento(be As documentoconsumodirecto) As List(Of documentoconsumodirecto)
        Return HeliosData.documentoconsumodirecto.Where(Function(o) o.idDocumento = be.idDocumento).ToList
    End Function

    Public Function GetSumaBySecuencia(be As documentoconsumodirecto) As Decimal
        Dim suma = Aggregate n In HeliosData.documentoconsumodirecto _
               Where n.idProductoPadre = be.secuencia _
               Into sumaMN = Sum(n.costo)

        Return suma.GetValueOrDefault
    End Function

    Public Sub InsertConsumo()

    End Sub

    Public Sub GetSaveConsumo(doc As documento, lista As List(Of documentoconsumodirecto))
        Dim obj As New documentoconsumodirecto
        Dim t As New totalesAlmacen
        Dim ventaBL As New documentoventaAbarrotesBL
        Dim totalesBL As New totalesAlmacenBL
        Dim AsientoBL As New AsientoBL
        Dim venta As New documentoventaAbarrotes
        Using ts As New TransactionScope

            venta = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = doc.idDocumento).FirstOrDefault
            venta.notaCredito = StatusVentaMatizados.TerminadaYentregada
            For Each i In lista
                obj = New documentoconsumodirecto
                obj.idDocumento = i.idDocumento
                obj.idProductoPadre = i.idProductoPadre
                obj.almacen = i.almacen
                obj.idMateriaPrima = i.idMateriaPrima
                obj.descripcion = i.descripcion
                obj.tipoexistencia = i.tipoexistencia
                obj.unidad = i.unidad
                obj.cant = i.cant
                obj.costo = i.costo
                HeliosData.documentoconsumodirecto.Add(obj)
            Next

            ventaBL.GetProductoTerminadoPinturas(venta, lista)
            Dim ventaDetalle = HeliosData.documentoventaAbarrotesDet.Where(Function(o) o.idDocumento = doc.idDocumento And o.tipoExistencia = TipoExistencia.ProductoTerminado).ToList

            ventaBL.ConsumoInmediatoProductoTerminado(venta, ventaDetalle)

            For Each i In ventaDetalle
                t = New totalesAlmacen
                t.idEmpresa = venta.idEmpresa
                t.idEstablecimiento = venta.idEstablecimiento
                t.tipoExistencia = i.tipoExistencia
                t.descripcion = i.nombreItem
                ' t.descripcion = i.DetalleItem
                t.idUnidad = i.unidad1
                t.idAlmacen = i.idAlmacenOrigen
                t.origenRecaudo = i.destino
                t.idItem = i.idItem
                t.cantidad = i.monto1
                t.precioUnitarioCompra = 0
                t.importeSoles = i.salidaCostoMN
                t.importeDolares = 0
                t.usuarioActualizacion = venta.usuarioActualizacion
                t.fechaActualizacion = venta.fechaActualizacion
                totalesBL.UpdateStockOtrasEntradas(t)


                t = New totalesAlmacen
                t.idEmpresa = venta.idEmpresa
                t.idEstablecimiento = venta.idEstablecimiento
                t.idAlmacen = i.idAlmacenOrigen
                t.origenRecaudo = i.destino
                t.idItem = i.idItem
                t.cantidad = i.monto1 * -1
                t.precioUnitarioCompra = 0
                t.importeSoles = i.salidaCostoMN * -1
                t.importeDolares = 0
                Dim objRecuperado = totalesBL.UpdateCostoVentaKardex(t)
            Next
            AsientoBL.SavebyGroupDoc(doc)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


End Class
