Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Linq
Imports System.Data.Entity
Public Class documentoGuiaBL
    Inherits BaseBL




    Public Sub UpdateGuiaXEstado(objDocumento As Integer, estado As String)

        Try
            Using ts As New TransactionScope()
                Dim documento As documentoGuia = HeliosData.documentoGuia.Where(Function(o) _
                                            o.idDocumento = objDocumento).Single()

                documento.EnvioSunat = estado


                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Public Sub EliminatGuia(be As documento)
        Dim documentoBL As New documentoBL
        Dim guiaBL As New documentoGuiaBL
        Using ts As New TransactionScope
            Dim Guia = HeliosData.documentoGuia.Include(Function(o) o.documentoguiaDetalle).Where(Function(o) o.idDocumento = be.idDocumento).SingleOrDefault

            'documentoBL.DeleteSingleVariable(be.idDocumento)



            Guia.estado = "AN"
            'If Guia.tipoVenta = "VELC" Then
            If Guia.EnvioSunat = "SI" Then  ' SI HA SIDO ENVIADO Y ELIMANDO
                Guia.EnvioSunat = "PE"
            Else Guia.EnvioSunat = Nothing
                Guia.EnvioSunat = "NE"       ' NO ENVIADO Y ELIMINADO
            End If
            ' End If

            guiaBL.ActualizarEstadoItemsVentaTraslado(Guia.documentoguiaDetalle.ToList())
            guiaBL.ActualizarVentaTrasaldo(Guia.idDocumentoPadre)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetGuiaRemisionListSelDate(be As documentoGuia) As List(Of documentoGuia)
        Dim Guia As documentoGuia
        Dim guiaBL As New documentoguiaDetalleBL

        GetGuiaRemisionListSelDate = New List(Of documentoGuia)
        Select Case be.documento.TipoEnvio
            Case "DIA"
                Dim con = HeliosData.documentoGuia.Join(HeliosData.entidad, Function(post) post.idEntidad, Function(prod) prod.idEntidad, Function(post, prod) New With
                                       {
                                       .Guia = post,
                                       .entidad = prod
                                       }) _
                                       .Include(Function(o) o.Guia.documentoguiaDetalle) _
                                       .Include(Function(o) o.Guia.documentoGuiaProperties) _
                                       .Where(Function(o) _
                       o.Guia.fechaDoc.Value.Year = be.fechaDoc.Value.Year And
                       o.Guia.fechaDoc.Value.Month = be.fechaDoc.Value.Month And
                       o.Guia.fechaDoc.Value.Day = be.fechaDoc.Value.Day).Select(Function(o) New With
                                                                                         {
                                                                                         .GuiaDoc = o.Guia,
                                                                                         .Cliente = o.entidad,
                                                                                         .GuiaDetalle = o.Guia.documentoguiaDetalle,
                                                                                         .GuiaProperties = o.Guia.documentoGuiaProperties
                                                                                         }).ToList

                For Each i In con
                    Dim listaDetalleGuia As New List(Of documentoguiaDetalle)
                    For Each det In i.GuiaDetalle.ToList
                        Dim obj = guiaBL.MappingProperties(det)
                        listaDetalleGuia.Add(obj)
                    Next

                    Dim listaDetalleGuiaProperties As New List(Of documentoGuiaProperties)
                    For Each det In i.GuiaProperties
                        Dim obj = New documentoGuiaProperties With {
                            .idproperty = det.idproperty,
                            .idDocumento = det.idDocumento,
                            .tipo = det.tipo,
                            .nameproperty = det.nameproperty,
                            .property_value = det.property_value,
                            .property_value2 = det.property_value2,
                            .usuarioModificacion = det.usuarioModificacion
                            }
                        listaDetalleGuiaProperties.Add(obj)
                    Next

                    Guia = MappingGuia(i.GuiaDoc)
                    Guia.CustomEntidad = New entidad() With {
                        .idEntidad = i.Cliente.idEntidad,
                        .nombreCompleto = i.Cliente.nombreCompleto,
                        .nrodoc = i.Cliente.nrodoc
                        }
                    Guia.documentoguiaDetalle = listaDetalleGuia
                    Guia.documentoGuiaProperties = listaDetalleGuiaProperties
                    GetGuiaRemisionListSelDate.Add(Guia)
                Next

            Case "MES"

                Dim con = HeliosData.documentoGuia.Join(HeliosData.entidad, Function(post) post.idEntidad, Function(prod) prod.idEntidad, Function(post, prod) New With
                                       {
                                       .Guia = post,
                                       .entidad = prod
                                       }) _
                                       .Include(Function(o) o.Guia.documentoguiaDetalle) _
                                       .Include(Function(o) o.Guia.documentoGuiaProperties) _
                                       .Where(Function(o) _
                       o.Guia.fechaDoc.Value.Year = be.fechaDoc.Value.Year And
                       o.Guia.fechaDoc.Value.Month = be.fechaDoc.Value.Month).Select(Function(o) New With
                                                                                         {
                                                                                         .GuiaDoc = o.Guia,
                                                                                         .Cliente = o.entidad,
                                                                                         .GuiaDetalle = o.Guia.documentoguiaDetalle,
                                                                                         .GuiaProperties = o.Guia.documentoGuiaProperties
                                                                                         }).ToList

                For Each i In con
                    Dim listaDetalleGuia As New List(Of documentoguiaDetalle)
                    For Each det In i.GuiaDetalle
                        Dim obj = guiaBL.MappingProperties(det)
                        listaDetalleGuia.Add(obj)
                    Next

                    Dim listaDetalleGuiaProperties As New List(Of documentoGuiaProperties)
                    For Each det In i.GuiaProperties
                        Dim obj = New documentoGuiaProperties With {
                            .idproperty = det.idproperty,
                            .idDocumento = det.idDocumento,
                            .tipo = det.tipo,
                            .nameproperty = det.nameproperty,
                            .property_value = det.property_value,
                            .property_value2 = det.property_value2,
                            .usuarioModificacion = det.usuarioModificacion
                            }
                        listaDetalleGuiaProperties.Add(obj)
                    Next

                    Guia = MappingGuia(i.GuiaDoc)
                    Guia.CustomEntidad = New entidad() With {
                        .idEntidad = i.Cliente.idEntidad,
                        .nombreCompleto = i.Cliente.nombreCompleto,
                        .nrodoc = i.Cliente.nrodoc
                        }
                    Guia.documentoguiaDetalle = listaDetalleGuia
                    Guia.documentoGuiaProperties = listaDetalleGuiaProperties
                    GetGuiaRemisionListSelDate.Add(Guia)
                Next


        End Select
    End Function

    Private Function MappingGuia(i As documentoGuia) As documentoGuia

        Dim Guia = New documentoGuia
        Guia.idDocumento = i.idDocumento
        Guia.idDocumentoPadre = i.idDocumentoPadre
        Guia.codigoLibro = i.codigoLibro
        Guia.idEmpresa = i.idEmpresa
        Guia.idCentroCosto = i.idCentroCosto
        Guia.fechaDoc = i.fechaDoc
        Guia.fechaTraslado = i.fechaTraslado
        Guia.periodo = i.periodo
        Guia.tipoDoc = i.tipoDoc
        Guia.serie = i.serie
        Guia.numeroDoc = i.numeroDoc
        Guia.idEntidad = i.idEntidad
        Guia.monedaDoc = i.monedaDoc
        Guia.tasaIgv = i.tasaIgv
        Guia.tipoCambio = i.tipoCambio
        Guia.importeMN = i.importeMN
        Guia.importeME = i.importeME
        Guia.direccionPartida = i.direccionPartida
        Guia.glosa = i.glosa
        Guia.idUnidad = i.idUnidad
        Guia.estado = i.estado
        Guia.ubigeo = i.ubigeo
        Guia.puntoPartida = i.puntoPartida
        Guia.puntoLlegada = i.puntoLlegada
        Guia.tipoMovimiento = i.tipoMovimiento
        Guia.motivoTraslado = i.motivoTraslado
        Guia.tipoVehiculo = i.tipoVehiculo
        Guia.marcaVehiculo = i.marcaVehiculo
        Guia.placaVehiculo = i.placaVehiculo
        Guia.placaRemolque = i.placaRemolque
        Guia.idEntidadTransporte = i.idEntidadTransporte
        Guia.nroBrevete = i.nroBrevete
        Guia.certificado = i.certificado
        Guia.estadoGuia = i.estadoGuia
        Guia.OtroTipoOperacion = i.OtroTipoOperacion
        Guia.OtroCantidad = i.OtroCantidad
        Guia.DescripcionMotivo = i.DescripcionMotivo
        Guia.DAM = i.DAM
        Guia.DireccionLlegada = i.DireccionLlegada
        Guia.Trasbordo = i.Trasbordo
        Guia.AsignarOtraGuia = i.AsignarOtraGuia
        Guia.RucTrasporte = i.RucTrasporte
        Guia.datosTrasporte = i.datosTrasporte
        Guia.fechaEntrega = i.fechaEntrega
        Guia.nroDocTrasportista = i.nroDocTrasportista
        Guia.razonSocialTrasportista = i.razonSocialTrasportista
        Guia.TipoDocDestinatario = i.TipoDocDestinatario
        Guia.DocDestinatario = i.DocDestinatario
        Guia.nombreDestinatario = i.nombreDestinatario
        Guia.TipoDocProveedor = i.TipoDocProveedor
        Guia.docProveedor = i.docProveedor
        Guia.DatosProveedor = i.DatosProveedor
        Guia.ObserTrasPublico = i.ObserTrasPublico
        Guia.PesoBruTotal = i.PesoBruTotal
        Guia.usuarioActualizacion = i.usuarioActualizacion
        Guia.fechaActualizacion = i.fechaActualizacion
        Guia.EnvioSunat = i.EnvioSunat

        Return Guia
    End Function

    Public Sub InsertGuiaVenta(documenoGuiaBE As documentoGuia, intIdDocumento As Integer)
        Dim documentoGuiaDetalleBL As New documentoguiaDetalleBL
        Using ts As New TransactionScope
            InsertarGuiaCabecera(documenoGuiaBE, intIdDocumento)
            documentoGuiaDetalleBL.InsertarGuiaDetalleVenta(documenoGuiaBE, intIdDocumento)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Function GetVentaIDGuia(be As documento) As documentoGuia

        'Dim venta = (From v In HeliosData.documentoventaAbarrotes
        '            Join det In HeliosData.documentoventaAbarrotesDet On det.idDocumento Equals v.idDocumento
        '            Join ent In HeliosData.entidad On ent.idEntidad Equals v.idCliente
        '            Join prod In HeliosData.detalleitems.Include("detalleitem_equivalencias") On prod.codigodetalle Equals det.idItem
        '            Where v.idDocumento = be.idDocumento).SIN

        Dim i = HeliosData.documentoGuia.Join(HeliosData.entidad.Include(Function(u) u.entidadAtributos), Function(venta) venta.idEntidad, Function(cli) cli.idEntidad, Function(venta, cli) New With {
                                                                                                                                    .vent = venta,
                                                                                                                                    .cliente = cli,
                                                                                                                                    .Atributos = cli.entidadAtributos
                                                                                                                                          }) _
            .Include(Function(det) det.vent.documentoguiaDetalle) _
                       .Where(Function(o) o.vent.idDocumento = be.idDocumento).Select(Function(x) New With
                                                          {
                                                          .cliente = x.cliente,
                                                          .ClienteAtributos = x.Atributos,
                                                          .documentoventa = x,
                                                          .documentoventaAbarrotesDetalle = x.vent.documentoguiaDetalle.GroupJoin _
                                                            (HeliosData.detalleitems, Function(g) CInt(g.idItem), Function(gg) gg.codigodetalle, Function(g, gg) New With
                                                              {
                                                              .cliente = x.cliente,
                                                              .ClienteAtributos = x.Atributos,
                                                              .documentoventa = x,
                                                              .ventaDetail = g,
                                                              .Producto = gg.FirstOrDefault
                                                              })
                                                              }).SingleOrDefault




        GetVentaIDGuia = New documentoGuia
        Dim ListVenta As New List(Of documentoguiaDetalle)


        Dim producto_table As detalleitems

        Dim listadoAtributos As List(Of entidadAtributos)

        For Each o In i.documentoventaAbarrotesDetalle.ToList
            'If o.equivalencia IsNot Nothing Then
            '    equivalencia_table = New detalleitem_equivalencias With
            '                {
            '                .codigodetalle = o.equivalencia.codigodetalle,
            '                .equivalencia_id = o.equivalencia.equivalencia_id,
            '                .detalle = o.equivalencia.detalle,
            '                .unidadComercial = o.equivalencia.unidadComercial,
            '                .contenido = o.equivalencia.contenido,
            '                .fraccionUnidad = o.equivalencia.fraccionUnidad,
            '                .contenido_neto = o.equivalencia.contenido_neto,
            '                .estado = o.equivalencia.estado
            '                }
            'Else
            '    equivalencia_table = Nothing
            'End If

            If o.Producto IsNot Nothing Then
                producto_table = New detalleitems With
                            {
                            .codigodetalle = o.Producto.codigodetalle,
                            .fotoUrl = o.Producto.fotoUrl,
                            .AfectoStock = o.Producto.AfectoStock,
                            .codigo = o.Producto.codigo,
                            .idItem = o.Producto.idItem,
                            .idEmpresa = o.Producto.idEmpresa,
                            .idEstablecimiento = o.Producto.idEstablecimiento,
                            .descripcionItem = o.Producto.descripcionItem,
                            .presentacion = o.Producto.presentacion,
                            .unidad1 = o.Producto.unidad1,
                            .unidad2 = o.Producto.unidad2,
                            .tipoExistencia = o.Producto.tipoExistencia,
                            .origenProducto = o.Producto.origenProducto,
                            .tipoProducto = o.Producto.tipoProducto,
                            .composicion = o.Producto.composicion,
                            .productoRestringido = o.Producto.productoRestringido,
                            .estado = o.Producto.estado
                            }
            Else
                producto_table = Nothing
            End If


            'If o.catalogo IsNot Nothing Then
            '    catalogo_table = New detalleitemequivalencia_catalogos With
            '              {
            '              .idCatalogo = o.catalogo.idCatalogo,
            '              .codigodetalle = o.catalogo.codigodetalle,
            '              .equivalencia_id = o.catalogo.equivalencia_id,
            '              .nombre_corto = o.catalogo.nombre_corto,
            '              .nombre_largo = o.catalogo.nombre_largo,
            '              .predeterminado = o.catalogo.predeterminado,
            '              .estado = o.catalogo.estado
            '              }
            'Else
            '    catalogo_table = Nothing
            'End If

            Dim afectoInv As Boolean
            If o.ventaDetail.tipoExistencia = "GS" Then
                afectoInv = False
            Else
                If producto_table.AfectoStock.HasValue Then
                    afectoInv = producto_table.AfectoStock
                Else
                    afectoInv = False
                End If
            End If

            'Dim cosunta = HeliosData.documentoventaAbarrotesDet.Join(HeliosData.detalleitem_equivalencias, Function(post) post.equivalencia_id, Function(prod) prod.equivalencia_id, Function(post, prod) New With
            '                           {
            '                           .Guia = post,
            '                           .entidad = prod
            '                           }).Where(Function(x) x.entidad.codigodetalle = o.ventaDetail.idItem).FirstOrDefault.entidad.unidadComercial

            ListVenta.Add(New documentoguiaDetalle With
                          {
                          .descripcionItem = o.ventaDetail.descripcionItem,'producto_table.AfectoStock,' True,
                            .idItem = o.ventaDetail.idItem,
                            .cantidad = o.ventaDetail.cantidad,
                            .nombreComercial = o.ventaDetail.nombreComercial})
        Next



        listadoAtributos = New List(Of entidadAtributos)
        For Each at In i.ClienteAtributos.ToList
            Dim atributo As New entidadAtributos With
            {
            .idEntidad = at.idEntidad,
            .idAtributo = at.idAtributo,
            .tipo = at.tipo,
            .valorAtributo = at.valorAtributo
            }
            listadoAtributos.Add(atributo)
        Next

        GetVentaIDGuia = New documentoGuia With
                           {
                           .CustomEntidad = New entidad With
                                {
                                .idEntidad = i.cliente.idEntidad,
                                .email = i.cliente.email,
                                .nombreCompleto = i.cliente.nombreCompleto,
                                .nrodoc = i.cliente.nrodoc,
                                .tipoEntidad = i.cliente.tipoEntidad,
                                .tipoDoc = i.cliente.tipoDoc,
                                .direccion = i.cliente.direccion,
                                .entidadAtributos = listadoAtributos
                            },
                           .idDocumento = i.documentoventa.vent.idDocumento,
                           .DocDestinatario = i.documentoventa.vent.DocDestinatario,
                           .nombreDestinatario = i.documentoventa.vent.nombreDestinatario,
                           .TipoDocDestinatario = i.documentoventa.vent.TipoDocDestinatario,
                           .razonSocialTrasportista = i.documentoventa.vent.razonSocialTrasportista,
                           .tipoDoc = i.documentoventa.vent.tipoDoc,
                           .numeroDoc = i.documentoventa.vent.numeroDoc,
                           .serie = i.documentoventa.vent.serie,
                           .fechaDoc = i.documentoventa.vent.fechaDoc,
                           .fechaTraslado = i.documentoventa.vent.fechaTraslado,
                           .DescripcionMotivo = i.documentoventa.vent.DescripcionMotivo,
                           .motivoTraslado = i.documentoventa.vent.motivoTraslado,
                           .tipoVehiculo = i.documentoventa.vent.tipoVehiculo,
                           .glosa = i.documentoventa.vent.glosa,
                           .tipoTransporte = i.documentoventa.vent.tipoTransporte,
                           .PesoBruTotal = i.documentoventa.vent.PesoBruTotal,
                           .RucTrasporte = i.documentoventa.vent.RucTrasporte,
                           .placaVehiculo = i.documentoventa.vent.placaVehiculo,
                           .NroDocumentoConductor = i.documentoventa.vent.NroDocumentoConductor,
                           .puntoPartida = i.documentoventa.vent.puntoPartida,
                           .direccionPartida = i.documentoventa.vent.direccionPartida,
                           .puntoLlegada = i.documentoventa.vent.puntoLlegada,
                           .DireccionLlegada = i.documentoventa.vent.DireccionLlegada,
                           .documentoguiaDetalle = ListVenta
                           }



        '  Dim result = warmCountries.Join(europeanCountries, Function(warm) warm, Function(european) european, Function(warm, european) warm)

    End Function

    Public Function GetREcuperarImpresion(be As documento) As documentoGuia

        'Dim venta = (From v In HeliosData.documentoventaAbarrotes
        '            Join det In HeliosData.documentoventaAbarrotesDet On det.idDocumento Equals v.idDocumento
        '            Join ent In HeliosData.entidad On ent.idEntidad Equals v.idCliente
        '            Join prod In HeliosData.detalleitems.Include("detalleitem_equivalencias") On prod.codigodetalle Equals det.idItem
        '            Where v.idDocumento = be.idDocumento).SIN

        Dim i = HeliosData.documentoGuia.Join(HeliosData.entidad.Include(Function(u) u.entidadAtributos), Function(venta) venta.idEntidad, Function(cli) cli.idEntidad, Function(venta, cli) New With {
                                                                                                                                    .vent = venta,
                                                                                                                                    .cliente = cli,
                                                                                                                                    .Atributos = cli.entidadAtributos
                                                                                                                                          }) _
            .Include(Function(det) det.vent.documentoguiaDetalle) _
             .Include(Function(opro) opro.vent.documentoGuiaProperties) _
            .Where(Function(o) o.vent.idDocumento = be.idDocumento).Select(Function(x) New With
                                                          {
                                                          .cliente = x.cliente,
                                                          .ClienteAtributos = x.Atributos,
                                                          .documentoventa = x,
                                                          .documentoGuiaProperties = x.vent.documentoGuiaProperties,
                                                          .documentoventaAbarrotesDetalle = x.vent.documentoguiaDetalle.GroupJoin _
                                                            (HeliosData.detalleitems, Function(g) CInt(g.idItem), Function(gg) gg.codigodetalle, Function(g, gg) New With
                                                              {
                                                              .cliente = x.cliente,
                                                              .ClienteAtributos = x.Atributos,
                                                              .documentoventa = x,
                                                              .ventaDetail = g,
                                                              .Producto = gg.FirstOrDefault,
                                                              .GuiaProperties = x.vent.documentoGuiaProperties
                                                              })
                                                              }).SingleOrDefault




        GetREcuperarImpresion = New documentoGuia
        Dim ListVenta As New List(Of documentoguiaDetalle)


        Dim producto_table As detalleitems

        Dim listadoAtributos As List(Of entidadAtributos)

        For Each o In i.documentoventaAbarrotesDetalle.ToList
            'If o.equivalencia IsNot Nothing Then
            '    equivalencia_table = New detalleitem_equivalencias With
            '                {
            '                .codigodetalle = o.equivalencia.codigodetalle,
            '                .equivalencia_id = o.equivalencia.equivalencia_id,
            '                .detalle = o.equivalencia.detalle,
            '                .unidadComercial = o.equivalencia.unidadComercial,
            '                .contenido = o.equivalencia.contenido,
            '                .fraccionUnidad = o.equivalencia.fraccionUnidad,
            '                .contenido_neto = o.equivalencia.contenido_neto,
            '                .estado = o.equivalencia.estado
            '                }
            'Else
            '    equivalencia_table = Nothing
            'End If

            If o.Producto IsNot Nothing Then
                producto_table = New detalleitems With
                            {
                            .codigodetalle = o.Producto.codigodetalle,
                            .fotoUrl = o.Producto.fotoUrl,
                            .AfectoStock = o.Producto.AfectoStock,
                            .codigo = o.Producto.codigo,
                            .idItem = o.Producto.idItem,
                            .idEmpresa = o.Producto.idEmpresa,
                            .idEstablecimiento = o.Producto.idEstablecimiento,
                            .descripcionItem = o.Producto.descripcionItem,
                            .presentacion = o.Producto.presentacion,
                            .unidad1 = o.Producto.unidad1,
                            .unidad2 = o.Producto.unidad2,
                            .tipoExistencia = o.Producto.tipoExistencia,
                            .origenProducto = o.Producto.origenProducto,
                            .tipoProducto = o.Producto.tipoProducto,
                            .composicion = o.Producto.composicion,
                            .productoRestringido = o.Producto.productoRestringido,
                            .estado = o.Producto.estado
                            }
            Else
                producto_table = Nothing
            End If


            'If o.catalogo IsNot Nothing Then
            '    catalogo_table = New detalleitemequivalencia_catalogos With
            '              {
            '              .idCatalogo = o.catalogo.idCatalogo,
            '              .codigodetalle = o.catalogo.codigodetalle,
            '              .equivalencia_id = o.catalogo.equivalencia_id,
            '              .nombre_corto = o.catalogo.nombre_corto,
            '              .nombre_largo = o.catalogo.nombre_largo,
            '              .predeterminado = o.catalogo.predeterminado,
            '              .estado = o.catalogo.estado
            '              }
            'Else
            '    catalogo_table = Nothing
            'End If

            Dim afectoInv As Boolean
            If o.ventaDetail.tipoExistencia = "GS" Then
                afectoInv = False
            Else
                If producto_table.AfectoStock.HasValue Then
                    afectoInv = producto_table.AfectoStock
                Else
                    afectoInv = False
                End If
            End If

            ListVenta.Add(New documentoguiaDetalle With
                          {
                          .descripcionItem = o.ventaDetail.descripcionItem,'producto_table.AfectoStock,' True,
                            .idItem = o.ventaDetail.idItem,
                            .unidadMedida = o.ventaDetail.unidadMedida,
                            .cantidad = o.ventaDetail.cantidad})
        Next


        listadoAtributos = New List(Of entidadAtributos)
        For Each at In i.ClienteAtributos.ToList
            Dim atributo As New entidadAtributos With
            {
            .idEntidad = at.idEntidad,
            .idAtributo = at.idAtributo,
            .tipo = at.tipo,
            .valorAtributo = at.valorAtributo
            }
            listadoAtributos.Add(atributo)
        Next

        Dim listaDetalleGuiaProperties As New List(Of documentoGuiaProperties)
        For Each det In i.documentoGuiaProperties.ToList
            Dim obj = New documentoGuiaProperties With {
                            .idproperty = det.idproperty,
                            .idDocumento = det.idDocumento,
                            .tipo = det.tipo,
                            .nameproperty = det.nameproperty,
                            .property_value = det.property_value,
                            .property_value2 = det.property_value2,
                            .usuarioModificacion = det.usuarioModificacion
                            }
            listaDetalleGuiaProperties.Add(obj)
        Next


        GetREcuperarImpresion = New documentoGuia With
                           {
                           .CustomEntidad = New entidad With
                                {
                                .idEntidad = i.cliente.idEntidad,
                                .email = i.cliente.email,
                                .nombreCompleto = i.cliente.nombreCompleto,
                                .nrodoc = i.cliente.nrodoc,
                                .tipoEntidad = i.cliente.tipoEntidad,
                                .tipoDoc = i.cliente.tipoDoc,
                                .direccion = i.cliente.direccion,
                                .entidadAtributos = listadoAtributos
                            },
                           .idDocumento = i.documentoventa.vent.idDocumento,
                           .DocDestinatario = i.documentoventa.vent.DocDestinatario,
                           .nombreDestinatario = i.documentoventa.vent.nombreDestinatario,
                           .TipoDocDestinatario = i.documentoventa.vent.TipoDocDestinatario,
                           .razonSocialTrasportista = i.documentoventa.vent.razonSocialTrasportista,
                           .tipoDoc = i.documentoventa.vent.tipoDoc,
                           .numeroDoc = i.documentoventa.vent.numeroDoc,
                           .serie = i.documentoventa.vent.serie,
                           .fechaDoc = i.documentoventa.vent.fechaDoc,
                           .fechaTraslado = i.documentoventa.vent.fechaTraslado,
                           .DescripcionMotivo = i.documentoventa.vent.DescripcionMotivo,
                           .motivoTraslado = i.documentoventa.vent.motivoTraslado,
                           .tipoVehiculo = i.documentoventa.vent.tipoVehiculo,
                           .glosa = i.documentoventa.vent.glosa,
                           .tipoTransporte = i.documentoventa.vent.tipoTransporte,
                           .PesoBruTotal = i.documentoventa.vent.PesoBruTotal,
                           .RucTrasporte = i.documentoventa.vent.RucTrasporte,
                           .placaVehiculo = i.documentoventa.vent.placaVehiculo,
                           .NroDocumentoConductor = i.documentoventa.vent.NroDocumentoConductor,
                           .puntoPartida = i.documentoventa.vent.puntoPartida,
                           .direccionPartida = i.documentoventa.vent.direccionPartida,
                           .puntoLlegada = i.documentoventa.vent.puntoLlegada,
                           .DireccionLlegada = i.documentoventa.vent.DireccionLlegada,
                           .documentoguiaDetalle = ListVenta,
                           .documentoGuiaProperties = listaDetalleGuiaProperties
                           }



        '  Dim result = warmCountries.Join(europeanCountries, Function(warm) warm, Function(european) european, Function(warm, european) warm)

    End Function

    Public Function UbicarGuiaPorIdDocumento(intIdDocumento As Integer) As documentoGuia
        Return (From n In HeliosData.documentoGuia Where n.idDocumento = intIdDocumento Select n).FirstOrDefault
    End Function

    Public Function ListaGuiasPorCompra(intIdDocumentoCompra As Integer) As List(Of documentoGuia)
        'Join enti In HeliosData.entidad
        '                On doc.idEntidad Equals enti.idEntidad
        Dim guiaBL As New documentoguiaDetalleBL
        Dim Guia As New documentoGuia
        Dim listaGuia As New List(Of documentoGuia)
        Dim connsulta = (From doc In HeliosData.documentoGuia _
                             .Include(Function(o) o.documentoguiaDetalle) _
                             .Include(Function(o) o.documentoGuiaProperties)
                         Where doc.idDocumentoPadre = intIdDocumentoCompra And doc.estado = "VG"
                         Select New With
                             {
                             .guia = doc,
                             .detalleGuia = doc.documentoguiaDetalle,
                             .detalleProperties = doc.documentoGuiaProperties
                             }).ToList




        For Each i In connsulta

            Dim listaDetalleGuia As New List(Of documentoguiaDetalle)
            For Each det In i.detalleGuia.ToList
                Dim obj = guiaBL.MappingProperties(det)
                listaDetalleGuia.Add(obj)
            Next

            Dim listaDetalleGuiaProperties As New List(Of documentoGuiaProperties)
            For Each det In i.detalleProperties
                Dim obj = New documentoGuiaProperties With {
                    .idproperty = det.idproperty,
                    .idDocumento = det.idDocumento,
                    .tipo = det.tipo,
                    .nameproperty = det.nameproperty,
                    .property_value = det.property_value,
                    .property_value2 = det.property_value2,
                    .usuarioModificacion = det.usuarioModificacion
                    }
                listaDetalleGuiaProperties.Add(obj)
            Next

            Guia = New documentoGuia
            Guia = MappingGuia(i.guia)
            Guia.documentoGuiaProperties = listaDetalleGuiaProperties
            Guia.documentoguiaDetalle = listaDetalleGuia
            listaGuia.Add(Guia)
        Next

        Return listaGuia

    End Function

    Public Function ListaGuiasTransferenciasXEntidadV2(be As documentocompra, tipoPerson As String) As List(Of documentoGuia)
        Dim Guia As New documentoGuia
        Dim listaGuia As New List(Of documentoGuia)

        Select Case tipoPerson
            Case "CL", "PR"
                Dim consulta = (From doc In HeliosData.documentocompra
                                Where doc.idProveedor = be.entidad.idEntidad _
                                    And doc.estadoEntrega = EstadoTransferenciaAlmacen.Pedido
                                Select New With
                                             {
                                    .idDocumento = doc.idDocumento,
                                    .idproveedor = doc.idProveedor,
                                    .tipoDoc = doc.tipoDoc,
                                    .serie = doc.serie,
                                    .numero = doc.numeroDoc,
                                    .fecha = doc.fechaDoc,
                                    .moneda = doc.monedaDoc,
                                    .emtrega = doc.usuarioActualizacion,
                                    .glosa = doc.glosa
                                    }).Distinct.ToList

                For Each i In consulta
                    Guia = New documentoGuia
                    Guia.idDocumento = i.idDocumento
                    Guia.fechaDoc = i.fecha
                    Guia.tipoDoc = i.tipoDoc
                    Guia.serie = i.serie
                    Guia.numeroDoc = i.numero
                    Guia.monedaDoc = i.moneda
                    Guia.idEntidad = i.idproveedor
                    Guia.glosa = i.glosa
                    listaGuia.Add(Guia)
                Next
            Case Else

                Dim consulta = (From doc In HeliosData.documentocompra
                                Where doc.idPersona = be.entidad.idEntidad _
                                    And doc.estadoEntrega = EstadoTransferenciaAlmacen.Pedido
                                Select New With
                                             {
                                    .idDocumento = doc.idDocumento,
                                    .idproveedor = doc.idProveedor,
                                    .tipoDoc = doc.tipoDoc,
                                    .serie = doc.serie,
                                    .numero = doc.numeroDoc,
                                    .fecha = doc.fechaDoc,
                                    .moneda = doc.monedaDoc,
                                    .emtrega = doc.usuarioActualizacion,
                                    .glosa = doc.glosa
                                    }).Distinct.ToList

                For Each i In consulta
                    Guia = New documentoGuia
                    Guia.idDocumento = i.idDocumento
                    Guia.fechaDoc = i.fecha
                    Guia.tipoDoc = i.tipoDoc
                    Guia.serie = i.serie
                    Guia.numeroDoc = i.numero
                    Guia.monedaDoc = i.moneda
                    Guia.idEntidad = i.idproveedor
                    Guia.glosa = i.glosa
                    listaGuia.Add(Guia)
                Next
        End Select

        Return listaGuia

    End Function

    Public Function ListaGuiasTransferenciasXEntidad(be As documentocompra) As List(Of documentoGuia)
        Dim Guia As New documentoGuia
        Dim listaGuia As New List(Of documentoGuia)
        Dim consulta = (From n In HeliosData.documentoguiaDetalle
                        Join doc In HeliosData.documentoGuia
                                     On n.idDocumento Equals doc.idDocumento
                        Where doc.idEntidad = be.entidad.idEntidad
                        Select New With
                                     {
                            .idDocumento = doc.idDocumento,
                            .tipoDoc = doc.tipoDoc,
                            .serie = doc.serie,
                            .numero = doc.numeroDoc,
                            .fecha = doc.fechaDoc,
                            .fechaTranslado = doc.fechaTraslado,
                            .direcion = doc.direccionPartida,
                            .moneda = doc.monedaDoc,
                            .emtrega = doc.usuarioActualizacion,
                            .idProveedor = doc.idEntidad,
                            .idTransporte = doc.idEntidadTransporte,
                            .importe = doc.importeMN,
                            .estado = doc.estado,
                            .glosa = doc.glosa
                            }).Distinct.ToList


        For Each i In consulta
            Guia = New documentoGuia
            Guia.idDocumento = i.idDocumento
            Guia.fechaDoc = i.fecha
            Guia.tipoDoc = i.tipoDoc
            Guia.serie = i.serie
            Guia.numeroDoc = i.numero
            Guia.fechaTraslado = i.fechaTranslado
            Guia.monedaDoc = i.moneda
            Guia.idEntidadTransporte = i.idTransporte
            Guia.direccionPartida = i.direcion
            Guia.idEntidad = i.idProveedor
            Guia.importeMN = i.importe
            Guia.estado = i.estado
            Guia.glosa = i.glosa
            Guia.usuarioActualizacion = ""
            listaGuia.Add(Guia)
        Next

        Return listaGuia

    End Function

    Public Function ListaGuiasPorCompraConEntidad(intIdDocumentoCompra As Integer) As List(Of documentoGuia)
        Dim Guia As New documentoGuia
        Dim listaGuia As New List(Of documentoGuia)
        Dim connsulta = (From n In HeliosData.documentoguiaDetalle
                         Join doc In HeliosData.documentoGuia
                        On n.idDocumento Equals doc.idDocumento
                         Join enti In HeliosData.entidad
                        On doc.idEntidad Equals enti.idEntidad
                         Where n.idDocumentoPadre = intIdDocumentoCompra
                         Select New With {.idDocumento = doc.idDocumento,
                                         .tipoDoc = doc.tipoDoc,
                                         .serie = doc.serie,
                                         .numero = doc.numeroDoc,
                                         .fecha = doc.fechaDoc,
                                         .fechaTranslado = doc.fechaTraslado,
                                         .direcion = doc.direccionPartida,
                                         .moneda = doc.monedaDoc,
                                         .emtrega = doc.usuarioActualizacion,
                                         .idProveedor = doc.idEntidad,
                                         .idTransporte = doc.idEntidadTransporte,
                                         .estado = doc.estado,
                                         .usuario = enti.nombreCompleto}).Distinct

        For Each i In connsulta
            Guia = New documentoGuia
            Guia.idDocumento = i.idDocumento
            Guia.fechaDoc = i.fecha
            Guia.tipoDoc = i.tipoDoc
            Guia.serie = i.serie
            Guia.numeroDoc = i.numero
            Guia.idEntidad = i.idProveedor
            Guia.fechaTraslado = i.fechaTranslado
            Guia.monedaDoc = i.moneda
            Guia.idEntidadTransporte = i.idTransporte
            Guia.direccionPartida = i.direcion
            Guia.idEntidad = i.idProveedor
            Guia.estado = i.estado
            Guia.usuarioActualizacion = i.usuario
            listaGuia.Add(Guia)
        Next

        Return listaGuia

    End Function

    Public Function ListaGuiasPorCompraSinEntidad(intIdDocumentoCompra As Integer) As List(Of documentoGuia)
        Dim Guia As New documentoGuia
        Dim listaGuia As New List(Of documentoGuia)
        Dim connsulta = (From n In HeliosData.documentoguiaDetalle
                         Join doc In HeliosData.documentoGuia
                        On n.idDocumento Equals doc.idDocumento
                         Where n.idDocumentoPadre = intIdDocumentoCompra
                         Select New With {.idDocumento = doc.idDocumento,
                                         .tipoDoc = doc.tipoDoc,
                                         .serie = doc.serie,
                                         .numero = doc.numeroDoc,
                                         .fecha = doc.fechaDoc,
                                         .fechaTranslado = doc.fechaTraslado,
                                         .direcion = doc.direccionPartida,
                                         .moneda = doc.monedaDoc,
                                         .emtrega = doc.usuarioActualizacion,
                                         .idProveedor = doc.idEntidad,
                                         .estado = doc.estado
                                       }).Distinct

        For Each i In connsulta
            Guia = New documentoGuia
            Guia.idDocumento = i.idDocumento
            Guia.fechaDoc = i.fecha
            Guia.tipoDoc = i.tipoDoc
            Guia.serie = i.serie
            Guia.numeroDoc = i.numero
            Guia.idEntidad = i.idProveedor
            Guia.fechaTraslado = i.fechaTranslado
            Guia.monedaDoc = i.moneda
            Guia.direccionPartida = i.direcion
            Guia.idEntidad = i.idProveedor
            Guia.estado = i.estado

            listaGuia.Add(Guia)
        Next

        Return listaGuia

    End Function

    Public Sub EliminarDocGuia(intIdDocumento As Integer)
        Using ts As New TransactionScope
            Dim documentoGuia As documentoGuia = HeliosData.documentoGuia.Where(Function(o) o.idDocumento = intIdDocumento).FirstOrDefault
            If Not IsNothing(documentoGuia) Then
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoGuia)
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertGuia(documenoGuiaBE As documentoGuia, intIdDocumento As Integer)
        Dim documentoGuiaDetalleBL As New documentoguiaDetalleBL
        Using ts As New TransactionScope
            InsertarGuiaCabecera(documenoGuiaBE, intIdDocumento)
            documentoGuiaDetalleBL.InsertarGuiaDetalle(documenoGuiaBE, intIdDocumento)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertGuiaPagado(documenoGuiaBE As documentoGuia, intIdDocumento As Integer)
        Dim documentoGuiaDetalleBL As New documentoguiaDetalleBL
        Using ts As New TransactionScope
            InsertarGuiaCabecera(documenoGuiaBE, intIdDocumento)
            documentoGuiaDetalleBL.InsertarGuiaDetallePagado(documenoGuiaBE, intIdDocumento)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertGuiaNuevo(documenoGuiaBE As documento, intIdDocumento As Integer)
        Dim documentoGuiaDetalleBL As New documentoguiaDetalleBL
        Dim DocumentoBL As New documentoBL
        Using ts As New TransactionScope
            documenoGuiaBE.tipoDoc = "99"
            DocumentoBL.Insert(documenoGuiaBE)
            InsertarGuiaCabecera(documenoGuiaBE.documentoGuia, documenoGuiaBE.idDocumento)
            documentoGuiaDetalleBL.InsertarGuiaDetalleNuevoEntregado(documenoGuiaBE.documentoGuia, documenoGuiaBE.idDocumento, intIdDocumento)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertGuiaDistribucion(documenoGuiaBE As documento)
        Dim documentoGuiaDetalleBL As New documentoguiaDetalleBL
        Dim documentoBL As New documentoBL
        Using ts As New TransactionScope
            documentoBL.Insert(documenoGuiaBE)
            InsertarGuiaCabecera(documenoGuiaBE.documentoGuia, documenoGuiaBE.idDocumento)
            documentoGuiaDetalleBL.InsertarGuiaDetalle(documenoGuiaBE.documentoGuia, documenoGuiaBE.idDocumento)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertGuiaDistribucionSL(documenoGuiaBE As documento)
        Dim documentoGuiaDetalleBL As New documentoguiaDetalleBL
        Dim documentoBL As New documentoBL
        Using ts As New TransactionScope
            documentoBL.Insert(documenoGuiaBE)
            InsertarGuiaCabecera(documenoGuiaBE.documentoGuia, documenoGuiaBE.idDocumento)
            documentoGuiaDetalleBL.InsertarGuiaDetalleSL(documenoGuiaBE.documentoGuia, documenoGuiaBE.idDocumento)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertGuiaRemisionCompraAlCredito(documenoGuiaBE As documento, intIdDocumentoPadre As Integer)
        Dim documentoGuiaDetalleBL As New documentoguiaDetalleBL
        Dim documentoBL As New documentoBL
        Using ts As New TransactionScope
            documentoBL.Insert(documenoGuiaBE)
            InsertarGuiaCabecera(documenoGuiaBE.documentoGuia, documenoGuiaBE.idDocumento)
            documentoGuiaDetalleBL.InsertarGuiaDetalleAlCredito(documenoGuiaBE.documentoGuia, documenoGuiaBE.idDocumento, intIdDocumentoPadre)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub InsertarGuiaCabecera(documenoGuiaBE As documentoGuia, intIdDocumento As Integer)
        Dim documentoGuia As New documentoGuia
        Using ts As New TransactionScope
            With documentoGuia
                .idDocumento = intIdDocumento
                .codigoLibro = documenoGuiaBE.codigoLibro
                .idEmpresa = documenoGuiaBE.idEmpresa
                .idCentroCosto = documenoGuiaBE.idCentroCosto
                .fechaDoc = documenoGuiaBE.fechaDoc
                .periodo = documenoGuiaBE.periodo
                .tipoDoc = documenoGuiaBE.tipoDoc
                .serie = documenoGuiaBE.serie
                .numeroDoc = documenoGuiaBE.numeroDoc
                .idEntidad = documenoGuiaBE.idEntidad
                .monedaDoc = documenoGuiaBE.monedaDoc
                .tasaIgv = documenoGuiaBE.tasaIgv
                .tipoCambio = documenoGuiaBE.tipoCambio
                .importeMN = documenoGuiaBE.importeMN
                .importeME = documenoGuiaBE.importeME
                .glosa = documenoGuiaBE.glosa
                .fechaTraslado = documenoGuiaBE.fechaTraslado
                .direccionPartida = documenoGuiaBE.direccionPartida
                .idEntidadTransporte = documenoGuiaBE.idEntidadTransporte
                .tipoVehiculo = documenoGuiaBE.tipoVehiculo
                .marcaVehiculo = documenoGuiaBE.marcaVehiculo
                .placaVehiculo = documenoGuiaBE.placaVehiculo
                .fechaTraslado = documenoGuiaBE.fechaTraslado
                .placaRemolque = documenoGuiaBE.placaRemolque
                .nroBrevete = documenoGuiaBE.nroBrevete
                .estado = documenoGuiaBE.estado
                .estadoGuia = documenoGuiaBE.estadoGuia
                .ubigeo = documenoGuiaBE.ubigeo
                .certificado = documenoGuiaBE.certificado
                .usuarioActualizacion = documenoGuiaBE.usuarioActualizacion
                .fechaActualizacion = documenoGuiaBE.fechaActualizacion
            End With
            HeliosData.documentoGuia.Add(documentoGuia)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Sub EliminarSingle(documentoBE As documentoguiaDetalle)
        Using ts As New TransactionScope
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoBE)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Sub EliminarGuiasCACSingle(documentoBE As documentoguiaDetalle)
        Using ts As New TransactionScope
            Dim consulta As documento = HeliosData.documento.Where(Function(o) o.idDocumento = documentoBE.idDocumento).FirstOrDefault
            If Not IsNothing(consulta) Then
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub
    Public Sub EliminarGuiasRemisionCAC(intIdDocCompra As Integer)
        Using ts As New TransactionScope
            Dim Listacompra As List(Of documentoguiaDetalle) = HeliosData.documentoguiaDetalle.Where(Function(o) o.idDocumentoPadre = intIdDocCompra).ToList
            For Each i As documentoguiaDetalle In Listacompra
                EliminarGuiasCACSingle(i)
            Next
            ts.Complete()
            HeliosData.SaveChanges()
        End Using
    End Sub
    Public Sub EliminarGuiaGeneral(intidDocumento As Integer)
        Dim documentoBL As New documentoBL
        Dim documentoGuiaBL As New documentoGuiaBL

        Try
            Using ts As New TransactionScope
                Dim consulta = (From n In HeliosData.documentoguiaDetalle _
                   Where n.idDocumentoPadre = intidDocumento
                   Select n.idDocumento).Distinct.ToList

                For Each i In consulta
                    documentoBL.DeleteSingle2Free(New documento With {.idDocumento = CInt(i)})
                Next
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarGuiaPorDocPadre(intIdDocumentoCompra As Integer)
        Dim colIdDoc As Integer
        Dim documentoBL As New documentoBL
        Using ts As New TransactionScope
            Dim Listacompra As List(Of documentoguiaDetalle) = HeliosData.documentoguiaDetalle.Where(Function(o) o.idDocumentoPadre = intIdDocumentoCompra).ToList
            For Each i As documentoguiaDetalle In Listacompra
                '  Ctype(HeliosData,System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(i)
                EliminarSingle(i)
                colIdDoc = i.idDocumento
            Next
            Dim ListaConteo As Integer = HeliosData.documentoguiaDetalle.Where(Function(o) o.idDocumento = colIdDoc).Count
            If ListaConteo <= 1 Then 'o.idDocumentoPadre = intIdDocumentoCompra And
                Dim Listacompra2 As documentoguiaDetalle = HeliosData.documentoguiaDetalle.Where(Function(o) o.idDocumento = colIdDoc).FirstOrDefault
                If Not IsNothing(Listacompra2) Then
                    documentoBL.DeleteSingleVariable(colIdDoc)
                End If
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub



    Public Function SaveGuiaRemisionEntregado(objDocumento As documento) As Integer
        Dim DocumentoBL As New documentoBL
        Dim listaTortalesAlmacen As New List(Of totalesAlmacen)

        Dim documentoGuiaDetalleBL As New documentoguiaDetalleBL
        Try
            Using ts As New TransactionScope()

                DocumentoBL.Insert(objDocumento)
                InsertarGuiaCabecera(objDocumento.documentoGuia, objDocumento.idDocumento)
                documentoGuiaDetalleBL.InsertarGuiaDetalleEntrega(objDocumento.documentoGuia, objDocumento.idDocumento)

                HeliosData.SaveChanges()
                ts.Complete()

                Return objDocumento.idDocumento
            End Using
        Catch ex As Exception

            Throw ex
        End Try
    End Function
    Public Sub UpdateSingleDoc(ByVal intIdDocumento As Integer, tipoEntrega As String)
        Using ts As New TransactionScope
            Dim consulta = (From c In HeliosData.documentoGuia
                            Where c.idDocumento = intIdDocumento
                            Select c).FirstOrDefault

            If Not IsNothing(consulta) Then

                consulta.estado = tipoEntrega

                'HeliosData.ObjectStateManager.GetObjectStateEntry(items).State.ToString()
                HeliosData.SaveChanges()

            Else

            End If

            ts.Complete()
        End Using

    End Sub

    Public Function UbicarGuiaPendiente() As List(Of documentoGuia)
        Return (From n In HeliosData.documentoGuia
                Where n.estado = "ET" Select n).ToList
    End Function

    Public Sub updateDocumentoTransferencia(ByVal documentoBE As documentoGuia)
        Dim documento As New documentoBL


        Using ts As New TransactionScope

            documento.updateDocumentoTransferencia(documentoBE)

            Dim documentoGuia As documentoGuia = HeliosData.documentoGuia.Where(Function(o) _
                                            o.idDocumento = documentoBE.idDocumento).First()

            documentoGuia.numeroDoc = documentoBE.numeroDoc
            documentoGuia.serie = documentoBE.serie
            documentoGuia.estadoGuia = documentoBE.estadoGuia

            'HeliosData.ObjectStateManager.GetObjectStateEntry(documento).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub



    Public Function ListaGuiasPorCompraSinNumeracion(intIdEstablecimiento As Integer, srtPeriodo As String, strIdEmpresarial As String) As List(Of documentoGuia)
        Dim Guia As New documentoGuia
        Dim listaGuia As New List(Of documentoGuia)

        'Dim connsulta = (From doc In HeliosData.documentoGuia
        '                 Join n In HeliosData.documentoguiaDetalle
        '                 On doc.idDocumento Equals n.idDocumento
        '                 Where doc.idCentroCosto = intIdEstablecimiento _
        '                     And doc.idEmpresa = strIdEmpresarial _
        '                     And doc.estadoGuia = "PN"
        '                 Select New With {.idDocumento = doc.idDocumento,
        '                                  .idEmpresa = doc.idEmpresa,
        '                                  .idCentroCosto = doc.idCentroCosto,
        '                                  .fechaDoc = doc.fechaDoc,
        '                                  .tipoDoc = doc.tipoDoc,
        '                                  .estadoGuia = doc.estadoGuia,
        '                                  .importeMN = doc.importeMN,
        '                                  .importeME = doc.importeME,
        '                                  .idPadre = n.idDocumentoPadre
        '                                }).ToList

        Dim consulta = (From b In HeliosData.documentoguiaDetalle
                        Where
                            b.documentoGuia.estadoGuia = "PN" And
                            b.documentoGuia.idCentroCosto = intIdEstablecimiento And
                            b.documentoGuia.idEmpresa = strIdEmpresarial
                        Group New With {b.documentoGuia, b} By
                            IdDocumento = CType(b.documentoGuia.idDocumento, Int32?),
                            b.idDocumentoPadre,
                            b.documentoGuia.idEmpresa,
                            IdCentroCosto = CType(b.documentoGuia.idCentroCosto, Int32?),
                            FechaDoc = CType(b.documentoGuia.fechaDoc, DateTime?),
                            b.documentoGuia.tipoDoc,
                            b.documentoGuia.estadoGuia,
                            ImporteMN = CType(b.documentoGuia.importeMN, Decimal?),
                            ImporteME = CType(b.documentoGuia.importeME, Decimal?)
                            Into g = Group
                        Select
                            IdDocumento = CType(IdDocumento, Int32?),
                            idDocumentoPadre,
                            idEmpresa,
                            IdCentroCosto = CType(IdCentroCosto, Int32?),
                            FechaDoc = CType(FechaDoc, DateTime?),
                            tipoDoc,
                            estadoGuia,
                            ImporteMN = CType(ImporteMN, Decimal?),
                            ImporteME = CType(ImporteME, Decimal?)).ToList


        For Each i In consulta
            Guia = New documentoGuia
            Guia.idDocumento = i.IdDocumento
            Guia.idEmpresa = i.idEmpresa
            Guia.idCentroCosto = i.IdCentroCosto
            Guia.fechaDoc = i.FechaDoc
            Guia.tipoDoc = i.tipoDoc
            Guia.estadoGuia = i.estadoGuia
            Guia.importeMN = i.ImporteMN
            Guia.importeME = i.ImporteME
            Guia.idEntidadTransporte = i.idDocumentoPadre

            listaGuia.Add(Guia)
        Next

        Return listaGuia

    End Function

    Public Sub RecepcionInventario(doc As documento)
        Dim inventario As New InventarioMovimientoBL
        Dim totalesBL As New totalesAlmacenBL

        Using ts As New TransactionScope
            AddGuiaDoc(doc)
            For Each i In doc.documentoGuia.documentoguiaDetalle
                Dim objInv = HeliosData.inventarioTransito.Where(Function(o) o.idInventario = i.CustomInventarioTransito.idInventario).SingleOrDefault

                objInv.status = i.CustomInventarioTransito.status
                ActualizarInventarioMovimiento(i.CustomInventarioTransito)
                ActualizarTotalesAlmacen(i.CustomInventarioTransito)


                'Dim listaArticulos = (From n In i.CustomInventarioTransito
                '                      Select
                '                                     n., n.tipoProducto, n.idAlmacen, n.nrolote).Distinct.ToList()

                '  For Each a In listaArticulos
                Dim lista = inventario.GetCuracionEntradasAlmacenByArticuloLote(
                                    New InventarioMovimiento With {
                                    .idAlmacen = i.CustomInventarioTransito.almacen,
                                    .fecha = Date.Now,
                                    .tipoProducto = i.CustomInventarioTransito.CustomProducto.tipoExistencia,
                                    .idItem = i.CustomInventarioTransito.CustomProducto.codigodetalle,
                                    .nrolote = i.CustomInventarioTransito.CustomDetalleCompra.codigoLote
                                    }, Nothing)
                totalesBL.GetCurarKardexCaberasLOTE(lista)
                ' Next
            Next

            '  LimpiarEntidades(doc)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Private Sub ActualizarTotalesAlmacen(c As inventarioTransito)
        Using ts As New TransactionScope

            Dim totales = HeliosData.totalesAlmacen.Where(Function(o) _
                                                              o.idAlmacen = c.almacen And
                                     o.codigoLote = c.CustomDetalleCompra.codigoLote And
                                     o.idItem = c.CustomProducto.codigodetalle And o.status = 0).SingleOrDefault
            If totales IsNot Nothing Then
                totales.status = StatusArticulo.Activo
            End If
            'Dim inv = o.idorigenDetalle = customInventarioTransito.secuencia AndAlso
            '    o.idDocumento = customInventarioTransito.idDocumentoCompra AndAlso
            '    o.nrolote = customInventarioTransito.CustomDetalleCompra.codigoLote And
            '    o.entragado = "2"

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Private Sub ActualizarInventarioMovimiento(customInventarioTransito As inventarioTransito)
        Using ts As New TransactionScope
            Dim inv = HeliosData.InventarioMovimiento.Where(
                Function(o) _
                    o.idorigenDetalle = customInventarioTransito.secuencia AndAlso
                    o.idDocumento = customInventarioTransito.idDocumentoCompra AndAlso
                    o.nrolote = customInventarioTransito.CustomDetalleCompra.codigoLote And
                    o.entragado = "2").SingleOrDefault

            If inv IsNot Nothing Then
                inv.entragado = "S"
            End If

            Dim lote = HeliosData.recursoCostoLote.Where(Function(t) t.codigoLote = customInventarioTransito.CustomDetalleCompra.codigoLote).SingleOrDefault

            lote.fechaentrada = Date.Now
            lote.fechaProduccion = Date.Now

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Private Sub AddGuiaDoc(doc As documento)
        Dim documentoBL As New documentoBL
        Dim guiaBL As New documentoGuiaBL

        Using ts As New TransactionScope
            documentoBL.Insert(doc)
            guiaBL.InsertGuiaPagado(doc.documentoGuia, doc.idDocumento)
            'HeliosData.documento.Add(doc)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Private Sub LimpiarEntidades(be As documento)
        be.documentocompra = Nothing
        For Each i In be.documentoGuia.documentoguiaDetalle
            i.documentoGuia = Nothing
            i.CustomInventarioTransito.CustomDetalleCompra = Nothing
            i.CustomInventarioTransito.CustomProducto = Nothing
            i.CustomInventarioTransito.documentocompradetalle = Nothing
            i.CustomInventarioTransito.CustomListaInventario = New List(Of InventarioMovimiento)
            i.CustomInventarioTransito = Nothing
            i.documentoguiaDetalleCondicion = New List(Of documentoguiaDetalleCondicion)
            i = Nothing
        Next
        be.documentoGuia = Nothing
    End Sub


#Region "GUIAFABIO"

    Public Function RegistrarGuiaRemision(be As documento) As documento
        Dim ventaBL As New documentoventaAbarrotesBL
        Using ts As New TransactionScope
            Dim listaItems = be.documentoGuia.documentoguiaDetalle.ToList
            Dim IDventaDoc = be.documentoGuia.idDocumentoPadre
            RegistrarGuia(be)
            ventaBL.ConfirmarTraslado(New documento() With {.idDocumento = be.documentoGuia.idDocumentoPadre, .documentoGuia = be.documentoGuia}, listaItems)
            ActualizarEstadoItemsVentaTraslado(listaItems)
            ActualizarVentaTrasaldo(IDventaDoc)
            HeliosData.SaveChanges()
            ts.Complete()
            be.documentoGuia = New documentoGuia
            be.documentoGuia.documentoguiaDetalle = New List(Of documentoguiaDetalle)
            Return be
        End Using
    End Function

    Private Sub ActualizarVentaTrasaldo(idVenta As Integer?)
        Using ts As New TransactionScope
            Dim venta = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = idVenta).SingleOrDefault()
            Dim estadosActivos As New List(Of String)
            estadosActivos.Add(EstadoTrasladoVenta.Pedido)
            estadosActivos.Add(EstadoTrasladoVenta.TrasladoParcial)
            If venta IsNot Nothing Then
                Dim existePendientesDeTraslados = HeliosData.documentoventaAbarrotesDet.Any(Function(o) o.idDocumento = idVenta And estadosActivos.Contains(o.estadoEntrega))
                If existePendientesDeTraslados Then
                    venta.estadoEntrega = EstadoTrasladoVenta.Pedido
                Else
                    venta.estadoEntrega = EstadoTrasladoVenta.EntregaConExito
                End If
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Private Sub ActualizarEstadoItemsVentaTraslado(listaItems As List(Of documentoguiaDetalle))
        Using ts As New TransactionScope

            For Each i In listaItems
                Dim itemventa = HeliosData.documentoventaAbarrotesDet.Where(Function(o) o.secuencia = i.secuenciaRef).SingleOrDefault()
                If itemventa IsNot Nothing Then
                    Dim TotalDistribucionItem As Decimal = HeliosData.documentoguiaDetalle.Where(Function(o) o.secuenciaRef = i.secuenciaRef).Sum(Function(o) o.cantidad).GetValueOrDefault()
                    Dim saldoItem As Decimal = Decimal.Subtract(itemventa.monto1, TotalDistribucionItem)

                    If saldoItem <= 0 Then
                        itemventa.estadoEntrega = EstadoTrasladoVenta.EntregaConExito
                    ElseIf saldoItem = itemventa.monto1 Then
                        itemventa.estadoEntrega = EstadoTrasladoVenta.Pedido
                    Else
                        itemventa.estadoEntrega = EstadoTrasladoVenta.TrasladoParcial
                    End If
                End If
            Next

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function RegistrarGuia(be As documento) As documento
        Dim cval As Integer = 0
        Dim numeracionBL As New numeracionBoletasBL
        Dim nuevoNumero As Object = Nothing
        Dim serie As String = String.Empty
        Using ts As New TransactionScope
            Dim codigoSeguridad As String = Nothing

            Select Case be.tipoDoc
                Case "09"
                    '      serieConfigurada = "B001"
                    codigoSeguridad = "GUIR"
                    nuevoNumero = numeracionBL.NumeracionBoletasSel(be.idCentroCosto, codigoSeguridad, be.tipoDoc)
                    serie = nuevoNumero.serie
                    cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(nuevoNumero.IdEnumeracion))
            End Select

            cval = cval
            be.nroDoc = serie & "-" & cval 'serieConfigurada
            be.documentoGuia.serie = serie 'serieConfigurada
            be.documentoGuia.numeroDoc = cval



            HeliosData.documento.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()

            'be.documentoGuia = New documentoGuia
            'be.documentoGuia.documentoguiaDetalle = New List(Of documentoguiaDetalle)

            Return be
        End Using
    End Function

    Public Function SAVEGUIA(ByVal DOCUMENTOGUIA As documentoGuia) As documentoGuia
        Dim documentoBL As New documentoBL
        Using TS As New TransactionScope
            'Dim doc = documentoBL.Insert


            Dim save = HeliosData.documentoGuia.Add(DOCUMENTOGUIA)
            HeliosData.SaveChanges()
            TS.Complete()

            Return save
        End Using

    End Function


#End Region
End Class
