Imports System.Data.Entity.Migrations
Imports System.Transactions
Imports Helios.Cont.Business.Entity
Imports System.Data.Entity
Public Class registrocomision_usuarios_detalleBL
    Inherits BaseBL

    Public Sub ChangeStatusComisionRegistro(be As registrocomision_usuarios_detalle)
        Using ts As New TransactionScope

            Dim com = HeliosData.registrocomision_usuarios_detalle.Where(Function(o) o.idseguimiento = be.idseguimiento And o.idseguimientoDetalle = be.idseguimientoDetalle).SingleOrDefault
            com.estadoComision = be.estadoComision ' General.StatusComisionRegistro.PagoAutorizado
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function registrocomision_usuarios_detalleJoinList(be As registrocomision_usuarios) As List(Of registrocomision_usuarios_detalle)


        Dim con = HeliosData.registrocomision_usuarios_detalle _
            .Include(Function(det) det.registrocomision_usuarios) _
            .Join(HeliosData.detalleitems, Function(comi) comi.idProducto, Function(prod) prod.codigodetalle, Function(comi, prod) New With
                                                                                                                     {
                                                                                                                     .producto = prod,
                                                                                                                     .registrocomision_usuarios_detalle = comi,
                                                                                                                     .registrocomision_usuarios = comi.registrocomision_usuarios
                                                                                                                     }) _
            .Join(HeliosData.detalleitem_equivalencias, Function(comi2) comi2.registrocomision_usuarios_detalle.unidadComercial, Function(prod2) prod2.equivalencia_id, Function(comi2, prod2) New With
                                                                                                                     {
                                                                                                                     .producto = comi2.producto,
                                                                                                                     .registrocomision_usuarios_detalle = comi2.registrocomision_usuarios_detalle,
                                                                                                                     .registrocomision_usuarios = comi2.registrocomision_usuarios,
                                                                                                                     .unidadComercial = prod2
                                                                                                                     }) _
            .Join(HeliosData.detalleitemequivalencia_catalogos, Function(comi3) comi3.registrocomision_usuarios_detalle.catalogo, Function(prod3) prod3.idCatalogo, Function(comi3, prod3) New With
                                                                                                                     {
                                                                                                                     .producto = comi3.producto,
                                                                                                                     .registrocomision_usuarios_detalle = comi3.registrocomision_usuarios_detalle,
                                                                                                                     .registrocomision_usuarios = comi3.registrocomision_usuarios,
                                                                                                                     .unidadComercial = comi3.unidadComercial,
                                                                                                                     .catalogoprecio = prod3
                                                                                                                     }) _
            .Join(HeliosData.documentoventaAbarrotes, Function(comi4) comi4.registrocomision_usuarios_detalle.idDocumentoRef, Function(prod4) prod4.idDocumento, Function(comi4, prod4) New With
                                                                                                                     {
                                                                                                                     .producto = comi4.producto,
                                                                                                                     .registrocomision_usuarios_detalle = comi4.registrocomision_usuarios_detalle,
                                                                                                                     .registrocomision_usuarios = comi4.registrocomision_usuarios,
                                                                                                                     .unidadComercial = comi4.unidadComercial,
                                                                                                                     .catalogoprecio = comi4.catalogoprecio,
                                                                                                                     .documentoventa = prod4
                                                                                                                     }) _
                                                                                                                     .Where(Function(o) o.registrocomision_usuarios.unidadNegocio = be.unidadNegocio And
                                                                                                                     o.registrocomision_usuarios.fechaRegistro.Value.Year = be.fechaRegistro.Value.Year And
                                                                                                                     o.registrocomision_usuarios.fechaRegistro.Value.Month = be.fechaRegistro.Value.Month).ToList()

        registrocomision_usuarios_detalleJoinList = New List(Of registrocomision_usuarios_detalle)
        Dim obj As registrocomision_usuarios_detalle
        'Dim listaDetalle As List(Of registrocomision_usuarios_detalle)
        For Each i In con
            obj = New registrocomision_usuarios_detalle
            obj.customProducto = New detalleitems With
            {
            .codigodetalle = i.producto.codigodetalle,
            .descripcionItem = i.producto.descripcionItem,
            .unidad1 = i.producto.unidad1,
            .tipoExistencia = i.producto.tipoExistencia,
            .origenProducto = i.producto.origenProducto
            }
            obj.customUnidadComercial = New detalleitem_equivalencias With
            {
            .equivalencia_id = i.unidadComercial.equivalencia_id,
            .detalle = i.unidadComercial.detalle,
            .unidadComercial = i.unidadComercial.unidadComercial
            }
            obj.customCatalogoPrecio = New detalleitemequivalencia_catalogos With
            {
            .idCatalogo = i.catalogoprecio.idCatalogo,
            .nombre_corto = i.catalogoprecio.nombre_corto,
            .nombre_largo = i.catalogoprecio.nombre_largo
            }

            obj.customRegistrocomision_usuarios = New registrocomision_usuarios With
            {
            .idseguimiento = i.registrocomision_usuarios.idseguimiento,
            .idDocumentoRef = i.registrocomision_usuarios.idDocumentoRef,
            .idEmpresa = i.registrocomision_usuarios.idEmpresa,
            .unidadNegocio = i.registrocomision_usuarios.unidadNegocio,
            .fechaRegistro = i.registrocomision_usuarios.fechaRegistro,
            .moneda = i.registrocomision_usuarios.moneda,
            .importeTotalVenta = i.registrocomision_usuarios.importeTotalVenta,
            .importeTotalGanadoMN = i.registrocomision_usuarios.importeTotalGanadoMN,
            .importeTotalGanadoME = i.registrocomision_usuarios.importeTotalGanadoME,
            .estadoVenta = i.registrocomision_usuarios.estadoVenta,
            .estadoComision = i.registrocomision_usuarios.estadoComision,
            .fechaVence = i.registrocomision_usuarios.fechaVence,
            .fechaprogramadaPago = i.registrocomision_usuarios.fechaprogramadaPago,
            .otrosConceptos = i.registrocomision_usuarios.otrosConceptos
            }

            obj.customDocumentoVenta = New documentoventaAbarrotes With
            {
            .idDocumento = i.documentoventa.idDocumento,
            .tipoOperacion = i.documentoventa.tipoOperacion,
            .tipoDocumento = i.documentoventa.tipoDocumento,
            .serieVenta = i.documentoventa.serieVenta,
            .numeroVenta = i.documentoventa.numeroVenta,
            .fechaDoc = i.documentoventa.fechaDoc,
            .idCliente = i.documentoventa.idCliente,
            .moneda = i.documentoventa.moneda,
            .ImporteNacional = i.documentoventa.ImporteNacional,
            .ImporteExtranjero = i.documentoventa.ImporteExtranjero,
            .tipoVenta = i.documentoventa.tipoVenta,
            .estadoCobro = i.documentoventa.estadoCobro
            }

            obj.idseguimiento = i.registrocomision_usuarios_detalle.idseguimiento
            obj.idseguimientoDetalle = i.registrocomision_usuarios_detalle.idseguimientoDetalle
            obj.idDocumentoRef = i.registrocomision_usuarios_detalle.idDocumentoRef
            obj.IdUsuario = i.registrocomision_usuarios_detalle.IdUsuario
            obj.tipoComision = i.registrocomision_usuarios_detalle.tipoComision
            obj.valorComision = i.registrocomision_usuarios_detalle.valorComision
            obj.idProducto = i.registrocomision_usuarios_detalle.idProducto
            obj.unidadComercial = i.registrocomision_usuarios_detalle.unidadComercial
            obj.unidadprincipal = i.registrocomision_usuarios_detalle.unidadprincipal
            obj.catalogo = i.registrocomision_usuarios_detalle.catalogo
            obj.precioTotalVenta = i.registrocomision_usuarios_detalle.precioTotalVenta
            obj.precioComision = i.registrocomision_usuarios_detalle.precioComision
            obj.estadoVenta = i.registrocomision_usuarios_detalle.estadoVenta
            obj.estadoComision = i.registrocomision_usuarios_detalle.estadoComision


            registrocomision_usuarios_detalleJoinList.Add(obj)
        Next
    End Function

    'Public Function GetComisionSelProducto(be As registrocomision_usuarios_detalle) As List(Of registrocomision_usuarios_detalle)
    '    Dim con = HeliosData.registrocomision_usuarios_detalle.Where(Function(o) o.idProducto = be.idProducto And o.unidadComercial = )
    'End Function


End Class
