Imports System.Data.Entity.Migrations
Imports System.Transactions
Imports Helios.Cont.Business.Entity
Imports System.Data.Entity
Public Class registrocomision_autorizacionBL
    Inherits BaseBL
    Public Sub RegistrarPagosComnision(be As documento)
        Dim documentoBL As New documentoBL
        Dim documentocajaBL As New documentoCajaBL
        Dim documentocajadetalleBL As New documentoCajaDetalleBL
        Using ts As New TransactionScope

            If be.ListaCustomDocumento IsNot Nothing Then
                If be.ListaCustomDocumento.Count > 0 Then
                    For Each i In be.ListaCustomDocumento.ToList
                        Dim nroDocVoucher = HeliosData.documentoCaja.Where(Function(o) o.tipoDocPago = "9903").Count
                        nroDocVoucher = nroDocVoucher + 1
                        i.nroDoc = nroDocVoucher
                        i.documentoCaja.numeroDoc = nroDocVoucher
                        documentoBL.Insert(i)
                        documentocajaBL.Insert(i.documentoCaja, i.idDocumento)

                        For Each det In i.documentoCaja.documentoCajaDetalle.ToList
                            det.idDocumento = i.idDocumento
                            HeliosData.documentoCajaDetalle.Add(det)
                        Next
                    Next
                    'HeliosData.documento.AddRange(be.ListaCustomDocumento)
                End If
            End If

            If be.CustomComisionAutorizacion IsNot Nothing Then
                If be.CustomComisionAutorizacion.Count > 0 Then
                    For Each x In be.CustomComisionAutorizacion
                        Dim comision = HeliosData.registrocomision_autorizacion.Where(Function(o) o.idAutorizacion = x.idAutorizacion).SingleOrDefault
                        comision.fechaAprobacion = x.fechaAprobacion
                        comision.desembolsoAutorizado = x.desembolsoAutorizado
                        comision.usuarioDesembolsoAutorizado = x.usuarioDesembolsoAutorizado


                        Dim pagocomision As New registroautorizacion_desembolso
                        pagocomision.idAutorizacion = x.idAutorizacion
                        pagocomision.idseguimiento = x.idseguimiento
                        pagocomision.idseguimientoDetalle = x.idseguimientoDetalle
                        pagocomision.idDocumentoRef = x.idDocumentoRef
                        pagocomision.IdDocumentoPago = 0
                        pagocomision.fechaRegistroPago = DateTime.Now
                        HeliosData.registroautorizacion_desembolso.Add(pagocomision)
                    Next
                End If
            End If



            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function registrocomision_autorizacionSelUsuario(be As registrocomision_usuarios_detalle) As List(Of registrocomision_autorizacion)
        Dim con = HeliosData.registrocomision_usuarios_detalle _
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
            .Join(HeliosData.registrocomision_autorizacion, Function(comi5) comi5.registrocomision_usuarios_detalle.idseguimientoDetalle, Function(prod5) prod5.idseguimientoDetalle, Function(comi5, prod5) New With
                                                                                                                     {
                                                                                                                     .producto = comi5.producto,
                                                                                                                     .registrocomision_usuarios_detalle = comi5.registrocomision_usuarios_detalle,
                                                                                                                     .registrocomision_usuarios = comi5.registrocomision_usuarios,
                                                                                                                     .unidadComercial = comi5.unidadComercial,
                                                                                                                     .catalogoprecio = comi5.catalogoprecio,
                                                                                                                     .documentoventa = comi5.documentoventa,
                                                                                                                     .registrocomision_autorizacion = prod5
                                                                                                                     }) _
                                                                                                                     .Where(Function(o) o.registrocomision_usuarios_detalle.IdUsuario = be.IdUsuario And
                                                                                                                     o.registrocomision_usuarios_detalle.estadoComision = "AUTH").ToList()

        registrocomision_autorizacionSelUsuario = New List(Of registrocomision_autorizacion)
        Dim obj As registrocomision_autorizacion
        'Dim listaDetalle As List(Of registrocomision_usuarios_detalle)
        For Each i In con
            obj = New registrocomision_autorizacion
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

            obj.customRegistrocomision_usuarios_detalle = New registrocomision_usuarios_detalle With
            {
            .IdUsuario = i.registrocomision_usuarios_detalle.IdUsuario,
            .tipoComision = i.registrocomision_usuarios_detalle.tipoComision,
            .valorComision = i.registrocomision_usuarios_detalle.valorComision,
            .idProducto = i.registrocomision_usuarios_detalle.idProducto,
            .unidadComercial = i.registrocomision_usuarios_detalle.unidadComercial,
            .unidadprincipal = i.registrocomision_usuarios_detalle.unidadprincipal,
            .catalogo = i.registrocomision_usuarios_detalle.catalogo,
            .precioTotalVenta = i.registrocomision_usuarios_detalle.precioTotalVenta,
            .precioComision = i.registrocomision_usuarios_detalle.precioComision,
            .estadoVenta = i.registrocomision_usuarios_detalle.estadoVenta,
            .estadoComision = i.registrocomision_usuarios_detalle.estadoComision
            }

            obj.idseguimiento = i.registrocomision_usuarios_detalle.idseguimiento
            obj.idseguimientoDetalle = i.registrocomision_usuarios_detalle.idseguimientoDetalle
            obj.idDocumentoRef = i.registrocomision_usuarios_detalle.idDocumentoRef
            obj.idAutorizacion = i.registrocomision_autorizacion.idAutorizacion
            obj.fechaPedido = i.registrocomision_autorizacion.fechaPedido
            obj.bloqueado = i.registrocomision_autorizacion.bloqueado
            obj.idProducto = i.registrocomision_autorizacion.idProducto
            obj.item = i.registrocomision_autorizacion.item
            obj.tipoProducto = i.registrocomision_autorizacion.tipoProducto
            obj.importeAutorizado = i.registrocomision_autorizacion.importeAutorizado
            obj.importeAutorizadoME = i.registrocomision_autorizacion.importeAutorizadoME
            obj.desembolsoAutorizado = i.registrocomision_autorizacion.desembolsoAutorizado
            obj.estado = i.registrocomision_autorizacion.estado

            registrocomision_autorizacionSelUsuario.Add(obj)
        Next
    End Function

    Public Sub registrocomision_autorizacionSaveList(Listado As List(Of registrocomision_autorizacion))
        Dim comisionBL As New registrocomision_usuarios_detalleBL
        Using ts As New TransactionScope
            For Each i In Listado
                registrocomision_autorizacionSave(i)
                comisionBL.ChangeStatusComisionRegistro(New registrocomision_usuarios_detalle With
                                                        {
                                                        .idseguimiento = i.idseguimiento,
                                                        .idseguimientoDetalle = i.idseguimientoDetalle,
                                                        .estadoComision = General.StatusComisionRegistro.PagoAutorizado
                                                        })
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub registrocomision_autorizacionSave(be As registrocomision_autorizacion)
        Using ts As New TransactionScope

            Select Case be.Action
                Case BaseBE.EntityAction.INSERT
                    HeliosData.registrocomision_autorizacion.Add(be)
                Case BaseBE.EntityAction.UPDATE

                Case BaseBE.EntityAction.DELETE

            End Select

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

End Class
