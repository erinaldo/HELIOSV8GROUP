Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity
Public Class detalleitemsBL
    Inherits BaseBL

    Public Function GetProductsCodeUnidadComercial(be As detalleitems) As List(Of detalleitems)

        'Dim c = HeliosData.totalesAlmacen.Join(HeliosData.detalleitems, Function(post) post.idItem, Function(prod) prod.codigodetalle, Function(post, prod) _
        '                                                                                                                                   '                                       New With
        '                                                                                                                                   '                                       {
        '                                                                                                                                   '                                       .post = post,
        '                                                                                                                                   '                                       .prod = prod
        '                                       }).ToList


        Dim i = HeliosData.detalleitem_equivalencias.
            Join(HeliosData.detalleitems, Function(post) post.codigodetalle, Function(prod) prod.codigodetalle, Function(post, prod) _
                 New With {
                 .detalleitem_equivalencias = post,
                 .detalleitems = prod
                 }).
                 Include(Function(o) o.detalleitem_equivalencias.detalleitemequivalencia_catalogos _
                 .Select(Function(q) q.detalleitemequivalencia_precios)) _
                 .Select(Function(data) New With
                        {
                        .producReturn = data.detalleitems,
                        .detalleitemequivalencia_beneficio = data.detalleitem_equivalencias.detalleitemequivalencia_beneficio,
                        .Equivale = data.detalleitem_equivalencias,
                        .detalleitemequivalencia_catalogos = data.detalleitem_equivalencias.detalleitemequivalencia_catalogos _
                        .Select(Function(p) New With
                        {
                        .Cat = p,
                        .Precios = p.detalleitemequivalencia_precios
                        })
            }) _
            .Where(Function(w) w.Equivale.codigo = be.codigo).SingleOrDefault()



        'Dim consulta = HeliosData.detalleitems _
        '   .Include(Function(lot) lot.recursoCostoLote) _
        '   .Include(Function(i) i.totalesAlmacen) _
        '   .Include(Function(ax) ax.detalleitems_conexo) _
        '   .Include(Function(o) o.detalleitem_equivalencias _
        '   .Select(
        '   Function(c) c.detalleitemequivalencia_catalogos _
        '   .Select(Function(p) p.detalleitemequivalencia_precios))) _
        '                        .Select(Function(o) New With
        '                        {
        '                        .detalleitems = o,
        '                        .detalleitems_conexo = o.detalleitems_conexo,
        '                        .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
        '                        .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
        '                                   {
        '                                   .Equivale = e,
        '                                   .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
        '                                   .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
        '                                                                                                                       {
        '                                                                                                                       .Cat = p,
        '                                                                                                                       .Precios = p.detalleitemequivalencia_precios
        '                                                                                                                       })
        '                                   }).Where(Function(q) q.Equivale.codigo.Equals(be.codigo)),
        '                       .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
        '                                      New With {
        '                                      .almacen = al,
        '                                      .TotalesInv = tot
        '                                      }).Where(Function(i) i.almacen.tipo = "AF" And
        '                                                           i.TotalesInv.cantidad > 0 And
        '                                                           i.TotalesInv.idEmpresa = be.idEmpresa And
        '                                                           i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
        '                                                           i.TotalesInv.status = 1)}).Where(Function(o) o.detalleitem_equivalencias(0).Equivale.codigo = be.codigo).ToList





        Dim obj As detalleitems
        Dim obEquivalencia As detalleitem_equivalencias
        Dim ListEquivalencia As List(Of detalleitem_equivalencias)

        Dim ListTotalesAlmacen As List(Of totalesAlmacen)

        Dim Listdetalleitems_conexo As List(Of detalleitems_conexo)

        Dim ListLotes As List(Of recursoCostoLote)
        Dim ListEquivalenciaPrecios As List(Of detalleitemequivalencia_precios)
        Dim ListaCatalogoPrecios As List(Of detalleitemequivalencia_catalogos)
        Dim ListaBeneficios As List(Of detalleitemequivalencia_beneficio)
        GetProductsCodeUnidadComercial = New List(Of detalleitems)

        If i IsNot Nothing Then

            ListEquivalencia = New List(Of detalleitem_equivalencias)
            ListTotalesAlmacen = New List(Of totalesAlmacen)
            ListLotes = New List(Of recursoCostoLote)
            Listdetalleitems_conexo = New List(Of detalleitems_conexo)


            'For Each ax In i.detalleitems_conexo
            '    Listdetalleitems_conexo.Add(New detalleitems_conexo With {
            '        .conexo_id = ax.conexo_id,
            '        .codigodetalle = ax.codigodetalle,
            '        .idProducto = ax.idProducto,
            '        .detalle = ax.detalle,
            '        .cantidad = ax.cantidad,
            '        .equivalencia_id = ax.equivalencia_id,
            '        .unidadComercial = ax.unidadComercial,
            '        .fraccion = ax.fraccion,
            '        .estado = ax.estado,
            '        .vigencia = ax.vigencia,
            '        .usuarioActualizacion = ax.usuarioActualizacion,
            '        .fechaActualizacion = ax.fechaActualizacion
            '                                })
            'Next

            'For Each lt In i.Lotes
            '    ListLotes.Add(New recursoCostoLote With
            '              {
            '              .codigoLote = lt.codigoLote,
            '              .nroLote = lt.nroLote,
            '              .idDocumento = lt.idDocumento,
            '              .idproyecto = lt.idproyecto,
            '              .codigoProducto = lt.codigoProducto,
            '              .moneda = lt.moneda,
            '              .detalle = lt.detalle,
            '              .cantidad = lt.cantidad,
            '              .precioUnitarioIva = lt.precioUnitarioIva,
            '              .fechaentrada = lt.fechaentrada,
            '              .fechaProduccion = lt.fechaProduccion,
            '              .fechaVcto = lt.fechaVcto,
            '              .serie = lt.serie,
            '              .sku = lt.sku,
            '              .composicion = lt.composicion,
            '              .productoSustentado = lt.productoSustentado
            '              })
            'Next



            'For Each inv In i.totalesAlmacen

            '    ListTotalesAlmacen.Add(New totalesAlmacen With {
            '                       .idMovimiento = inv.TotalesInv.idMovimiento,
            '                       .idEmpresa = inv.TotalesInv.idEmpresa,
            '                       .idEstablecimiento = inv.TotalesInv.idEstablecimiento,
            '                       .idAlmacen = inv.TotalesInv.idAlmacen,
            '                       .codigoLote = inv.TotalesInv.codigoLote,
            '                       .descripcion = inv.TotalesInv.descripcion,
            '                       .idUnidad = inv.TotalesInv.idUnidad,
            '                       .unidadMedida = inv.TotalesInv.unidadMedida,
            '                       .cantidad = inv.TotalesInv.cantidad,
            '                       .cantidad2 = inv.TotalesInv.cantidad2,
            '                       .importeSoles = inv.TotalesInv.importeSoles,
            '                       .importeDolares = inv.TotalesInv.importeDolares,
            '                       .status = inv.TotalesInv.status
            '                       })
            'Next

            Dim eq = i.Equivale
            obEquivalencia = New detalleitem_equivalencias
            obEquivalencia.equivalencia_id = eq.equivalencia_id
            obEquivalencia.flag = eq.flag
            obEquivalencia.codigodetalle = eq.codigodetalle
            obEquivalencia.detalle = eq.detalle
            obEquivalencia.contenido = eq.contenido
            obEquivalencia.contenido_neto = eq.contenido_neto
            obEquivalencia.unidadComercial = eq.unidadComercial
            obEquivalencia.fraccionUnidad = eq.fraccionUnidad
            obEquivalencia.codigo = eq.codigo
            obEquivalencia.estado = eq.estado


            ListaBeneficios = New List(Of detalleitemequivalencia_beneficio)
            For Each ben In eq.detalleitemequivalencia_beneficio
                ListaBeneficios.Add(New detalleitemequivalencia_beneficio With
                                        {
                                        .beneficio_id = ben.beneficio_id,
                                        .codigodetalle = ben.codigodetalle,
                                        .modalidadVenta = ben.modalidadVenta,
                                        .aplica = ben.aplica,
                                        .equivalencia_id = ben.equivalencia_id,
                                        .beneficio_detalle = ben.beneficio_detalle,
                                        .tipobeneficio = ben.tipobeneficio,
                                        .tipoafectacion = ben.tipoafectacion,
                                        .valor_evaluado = ben.valor_evaluado,
                                        .valor_conversion = ben.valor_conversion,
                                        .valor_beneficio = ben.valor_beneficio,
                                        .lote_id = ben.lote_id,
                                        .estado = ben.estado,
                                        .usuarioActualizacion = ben.usuarioActualizacion,
                                        .fechaActualizacion = ben.fechaActualizacion
                                        })
            Next


            ListaCatalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
            For Each cat In eq.detalleitemequivalencia_catalogos
                ListEquivalenciaPrecios = New List(Of detalleitemequivalencia_precios)
                For Each prec In cat.detalleitemequivalencia_precios
                    ListEquivalenciaPrecios.Add(New detalleitemequivalencia_precios With
                                                {
                                                .precio_id = prec.precio_id,
                                                .codigodetalle = prec.codigodetalle,
                                                .equivalencia_id = prec.equivalencia_id,
                                                .idCatalogo = prec.idCatalogo,
                                                .rango_inicio = prec.rango_inicio,
                                                .rango_final = prec.rango_final,
                                                .precioCredito = prec.precioCredito,
                                                .precioCreditoUSD = prec.precioCreditoUSD,
                                                .precio = prec.precio,
                                                .precioUSD = prec.precioUSD,
                                                .precioCode = prec.precioCode,
                                                .estado = prec.estado
                                                })
                Next

                ListaCatalogoPrecios.Add(New detalleitemequivalencia_catalogos With {
                                             .idCatalogo = cat.idCatalogo,
                                             .codigodetalle = cat.codigodetalle,
                                             .equivalencia_id = cat.equivalencia_id,
                                             .nombre_corto = cat.nombre_corto,
                                             .nombre_largo = cat.nombre_largo,
                                             .estado = cat.estado,
                                             .predeterminado = cat.predeterminado,
                                             .detalleitemequivalencia_precios = ListEquivalenciaPrecios
                                         })


            Next
            obEquivalencia.detalleitemequivalencia_catalogos = ListaCatalogoPrecios
            obEquivalencia.detalleitemequivalencia_beneficio = ListaBeneficios
            ListEquivalencia.Add(obEquivalencia)


            obj = New detalleitems With
                {
                .codigodetalle = i.producReturn.codigodetalle,
                .idItem = i.producReturn.idItem,
                .descripcionItem = i.producReturn.descripcionItem,
                .unidad1 = i.producReturn.unidad1,
                .tipoExistencia = i.producReturn.tipoExistencia,
                .unidad2 = i.producReturn.unidad2,
                .codigo = i.producReturn.codigo,
                .origenProducto = i.producReturn.origenProducto,
                .composicion = i.producReturn.composicion,
                .AfectoStock = i.producReturn.AfectoStock,
                .detalleitem_equivalencias = ListEquivalencia,
                .detalleitems_conexo = Listdetalleitems_conexo,
                .totalesAlmacen = ListTotalesAlmacen,
                .recursoCostoLote = ListLotes,
                .otroImpuesto = i.producReturn.otroImpuesto,
                .tipoOtroImpuesto = i.producReturn.tipoOtroImpuesto,
                .igv = i.producReturn.igv
            }
            GetProductsCodeUnidadComercial.Add(obj)

        End If

    End Function

    Public Function GetProductsCodeUnidadComercialAlmacen(be As detalleitems) As List(Of detalleitems)

        'Dim c = HeliosData.totalesAlmacen.Join(HeliosData.detalleitems, Function(post) post.idItem, Function(prod) prod.codigodetalle, Function(post, prod) _
        '                                                                                                                                   '                                       New With
        '                                                                                                                                   '                                       {
        '                                                                                                                                   '                                       .post = post,
        '                                                                                                                                   '                                       .prod = prod
        '                                       }).ToList


        Dim i = HeliosData.detalleitem_equivalencias.
            Join(HeliosData.detalleitems, Function(post) post.codigodetalle, Function(prod) prod.codigodetalle, Function(post, prod) _
                 New With {
                 .detalleitem_equivalencias = post,
                 .detalleitems = prod
                 }).
                 Include(Function(o) o.detalleitem_equivalencias.detalleitemequivalencia_catalogos _
                 .Select(Function(q) q.detalleitemequivalencia_precios)) _
                 .Select(Function(data) New With
                        {
                        .producReturn = data.detalleitems,
                        .detalleitemequivalencia_beneficio = data.detalleitem_equivalencias.detalleitemequivalencia_beneficio,
                        .Equivale = data.detalleitem_equivalencias,
                        .detalleitemequivalencia_catalogos = data.detalleitem_equivalencias.detalleitemequivalencia_catalogos _
                        .Select(Function(p) New With
                        {
                        .Cat = p,
                        .Precios = p.detalleitemequivalencia_precios
                        })
            }) _
            .Where(Function(w) w.Equivale.codigo = be.codigo).SingleOrDefault()



        'Dim consulta = HeliosData.detalleitems _
        '   .Include(Function(lot) lot.recursoCostoLote) _
        '   .Include(Function(i) i.totalesAlmacen) _
        '   .Include(Function(ax) ax.detalleitems_conexo) _
        '   .Include(Function(o) o.detalleitem_equivalencias _
        '   .Select(
        '   Function(c) c.detalleitemequivalencia_catalogos _
        '   .Select(Function(p) p.detalleitemequivalencia_precios))) _
        '                        .Select(Function(o) New With
        '                        {
        '                        .detalleitems = o,
        '                        .detalleitems_conexo = o.detalleitems_conexo,
        '                        .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
        '                        .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
        '                                   {
        '                                   .Equivale = e,
        '                                   .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
        '                                   .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
        '                                                                                                                       {
        '                                                                                                                       .Cat = p,
        '                                                                                                                       .Precios = p.detalleitemequivalencia_precios
        '                                                                                                                       })
        '                                   }).Where(Function(q) q.Equivale.codigo.Equals(be.codigo)),
        '                       .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
        '                                      New With {
        '                                      .almacen = al,
        '                                      .TotalesInv = tot
        '                                      }).Where(Function(i) i.almacen.tipo = "AF" And
        '                                                           i.TotalesInv.cantidad > 0 And
        '                                                           i.TotalesInv.idEmpresa = be.idEmpresa And
        '                                                           i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
        '                                                           i.TotalesInv.status = 1)}).Where(Function(o) o.detalleitem_equivalencias(0).Equivale.codigo = be.codigo).ToList





        Dim obj As detalleitems
        Dim obEquivalencia As detalleitem_equivalencias
        Dim ListEquivalencia As List(Of detalleitem_equivalencias)

        Dim ListTotalesAlmacen As List(Of totalesAlmacen)

        Dim Listdetalleitems_conexo As List(Of detalleitems_conexo)

        Dim ListLotes As List(Of recursoCostoLote)
        Dim ListEquivalenciaPrecios As List(Of detalleitemequivalencia_precios)
        Dim ListaCatalogoPrecios As List(Of detalleitemequivalencia_catalogos)
        Dim ListaBeneficios As List(Of detalleitemequivalencia_beneficio)
        GetProductsCodeUnidadComercialAlmacen = New List(Of detalleitems)

        If i IsNot Nothing Then

            ListEquivalencia = New List(Of detalleitem_equivalencias)
            ListTotalesAlmacen = New List(Of totalesAlmacen)
            ListLotes = New List(Of recursoCostoLote)
            Listdetalleitems_conexo = New List(Of detalleitems_conexo)


            'For Each ax In i.detalleitems_conexo
            '    Listdetalleitems_conexo.Add(New detalleitems_conexo With {
            '        .conexo_id = ax.conexo_id,
            '        .codigodetalle = ax.codigodetalle,
            '        .idProducto = ax.idProducto,
            '        .detalle = ax.detalle,
            '        .cantidad = ax.cantidad,
            '        .equivalencia_id = ax.equivalencia_id,
            '        .unidadComercial = ax.unidadComercial,
            '        .fraccion = ax.fraccion,
            '        .estado = ax.estado,
            '        .vigencia = ax.vigencia,
            '        .usuarioActualizacion = ax.usuarioActualizacion,
            '        .fechaActualizacion = ax.fechaActualizacion
            '                                })
            'Next

            'For Each lt In i.Lotes
            '    ListLotes.Add(New recursoCostoLote With
            '              {
            '              .codigoLote = lt.codigoLote,
            '              .nroLote = lt.nroLote,
            '              .idDocumento = lt.idDocumento,
            '              .idproyecto = lt.idproyecto,
            '              .codigoProducto = lt.codigoProducto,
            '              .moneda = lt.moneda,
            '              .detalle = lt.detalle,
            '              .cantidad = lt.cantidad,
            '              .precioUnitarioIva = lt.precioUnitarioIva,
            '              .fechaentrada = lt.fechaentrada,
            '              .fechaProduccion = lt.fechaProduccion,
            '              .fechaVcto = lt.fechaVcto,
            '              .serie = lt.serie,
            '              .sku = lt.sku,
            '              .composicion = lt.composicion,
            '              .productoSustentado = lt.productoSustentado
            '              })
            'Next


            Dim listaTotales = HeliosData.totalesAlmacen.Where(Function(a) a.cantidad > 0 And a.idEmpresa = be.idEmpresa And
                                                                   a.idEstablecimiento = be.idEstablecimiento And
                                                                   a.status = 1 And a.idAlmacen = be.idAlmacen).ToList


            For Each inv In listaTotales

                ListTotalesAlmacen.Add(New totalesAlmacen With {
                                   .idMovimiento = inv.idMovimiento,
                                   .idEmpresa = inv.idEmpresa,
                                   .idEstablecimiento = inv.idEstablecimiento,
                                   .idAlmacen = inv.idAlmacen,
                                   .codigoLote = inv.codigoLote,
                                   .descripcion = inv.descripcion,
                                   .idUnidad = inv.idUnidad,
                                   .unidadMedida = inv.unidadMedida,
                                   .cantidad = inv.cantidad,
                                   .cantidad2 = inv.cantidad2,
                                   .importeSoles = inv.importeSoles,
                                   .importeDolares = inv.importeDolares,
                                   .status = inv.status
                                   })
            Next

            Dim eq = i.Equivale
            obEquivalencia = New detalleitem_equivalencias
            obEquivalencia.equivalencia_id = eq.equivalencia_id
            obEquivalencia.flag = eq.flag
            obEquivalencia.codigodetalle = eq.codigodetalle
            obEquivalencia.detalle = eq.detalle
            obEquivalencia.contenido = eq.contenido
            obEquivalencia.contenido_neto = eq.contenido_neto
            obEquivalencia.unidadComercial = eq.unidadComercial
            obEquivalencia.fraccionUnidad = eq.fraccionUnidad
            obEquivalencia.codigo = eq.codigo
            obEquivalencia.estado = eq.estado


            ListaBeneficios = New List(Of detalleitemequivalencia_beneficio)
            For Each ben In eq.detalleitemequivalencia_beneficio
                ListaBeneficios.Add(New detalleitemequivalencia_beneficio With
                                        {
                                        .beneficio_id = ben.beneficio_id,
                                        .codigodetalle = ben.codigodetalle,
                                        .modalidadVenta = ben.modalidadVenta,
                                        .aplica = ben.aplica,
                                        .equivalencia_id = ben.equivalencia_id,
                                        .beneficio_detalle = ben.beneficio_detalle,
                                        .tipobeneficio = ben.tipobeneficio,
                                        .tipoafectacion = ben.tipoafectacion,
                                        .valor_evaluado = ben.valor_evaluado,
                                        .valor_conversion = ben.valor_conversion,
                                        .valor_beneficio = ben.valor_beneficio,
                                        .lote_id = ben.lote_id,
                                        .estado = ben.estado,
                                        .usuarioActualizacion = ben.usuarioActualizacion,
                                        .fechaActualizacion = ben.fechaActualizacion
                                        })
            Next


            ListaCatalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
            For Each cat In eq.detalleitemequivalencia_catalogos
                ListEquivalenciaPrecios = New List(Of detalleitemequivalencia_precios)
                For Each prec In cat.detalleitemequivalencia_precios
                    ListEquivalenciaPrecios.Add(New detalleitemequivalencia_precios With
                                                {
                                                .precio_id = prec.precio_id,
                                                .codigodetalle = prec.codigodetalle,
                                                .equivalencia_id = prec.equivalencia_id,
                                                .idCatalogo = prec.idCatalogo,
                                                .rango_inicio = prec.rango_inicio,
                                                .rango_final = prec.rango_final,
                                                .precioCredito = prec.precioCredito,
                                                .precioCreditoUSD = prec.precioCreditoUSD,
                                                .precio = prec.precio,
                                                .precioUSD = prec.precioUSD,
                                                .precioCode = prec.precioCode,
                                                .estado = prec.estado
                                                })
                Next

                ListaCatalogoPrecios.Add(New detalleitemequivalencia_catalogos With {
                                             .idCatalogo = cat.idCatalogo,
                                             .codigodetalle = cat.codigodetalle,
                                             .equivalencia_id = cat.equivalencia_id,
                                             .nombre_corto = cat.nombre_corto,
                                             .nombre_largo = cat.nombre_largo,
                                             .estado = cat.estado,
                                             .predeterminado = cat.predeterminado,
                                             .detalleitemequivalencia_precios = ListEquivalenciaPrecios
                                         })


            Next
            obEquivalencia.detalleitemequivalencia_catalogos = ListaCatalogoPrecios
            obEquivalencia.detalleitemequivalencia_beneficio = ListaBeneficios
            ListEquivalencia.Add(obEquivalencia)


            obj = New detalleitems With
                {
                .codigodetalle = i.producReturn.codigodetalle,
                .idItem = i.producReturn.idItem,
                .descripcionItem = i.producReturn.descripcionItem,
                .unidad1 = i.producReturn.unidad1,
                .tipoExistencia = i.producReturn.tipoExistencia,
                .unidad2 = i.producReturn.unidad2,
                .codigo = i.producReturn.codigo,
                .origenProducto = i.producReturn.origenProducto,
                .composicion = i.producReturn.composicion,
                .AfectoStock = i.producReturn.AfectoStock,
                .detalleitem_equivalencias = ListEquivalencia,
                .detalleitems_conexo = Listdetalleitems_conexo,
                .totalesAlmacen = ListTotalesAlmacen,
                .recursoCostoLote = ListLotes,
                .otroImpuesto = i.producReturn.otroImpuesto,
                .tipoOtroImpuesto = i.producReturn.tipoOtroImpuesto,
                .igv = i.producReturn.igv
            }
            GetProductsCodeUnidadComercialAlmacen.Add(obj)

        End If

    End Function

    Public Sub EditarImageUrlProducto(item As detalleitems)
        Using ts As New TransactionScope

            Dim prod = HeliosData.detalleitems.Where(Function(o) o.codigodetalle = item.codigodetalle).SingleOrDefault

            prod.fotoUrl = item.fotoUrl
            'prod.preciocompratipo = item.preciocompratipo
            'prod.firstpercent = item.firstpercent
            'prod.beforepercent = item.beforepercent
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetProductosLoteDetalle(be As detalleitems) As List(Of detalleitems)


        'Dim consulta3 = (From i In HeliosData.totalesAlmacen
        '                 Join h In HeliosData.almacen On h.idAlmacen Equals i.idAlmacen
        '                 Join x In HeliosData.detalleitems On x.codigodetalle Equals i.idItem
        '                 Where h.tipo = "AF" And
        '                 i.cantidad > 0 And
        '                i.idEmpresa = be.idEmpresa And
        '               i.idEstablecimiento = be.idEstablecimiento And
        '               i.status = 1 And i.descripcion.Contains(be.descripcionItem)).ToList



        'Dim consulta = HeliosData.detalleitems _
        '    .Include(Function(cat) cat.item) _
        '    .Include(Function(lot) lot.recursoCostoLote) _
        '    .Include(Function(i) i.totalesAlmacen) _
        '    .Include(Function(ax) ax.detalleitems_conexo) _
        '    .Include(Function(o) o.detalleitem_equivalencias.Select(
        '    Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
        '                         .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" And Not d.tipoItem = "DET") _
        '                         .Select(Function(o) New With
        '                         {
        '                         .detalleitems = o,
        '                         .category = o.item,
        '                         .detalleitems_conexo = o.detalleitems_conexo,
        '                         .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
        '                         .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
        '                                    {
        '                                    .Equivale = e,
        '                                    .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
        '                                    .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
        '                                                                                                                        {
        '                                                                                                                        .Cat = p,
        '                                                                                                                        .Precios = p.detalleitemequivalencia_precios
        '                                                                                                                        })
        '                                    }),
        '                        .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
        '                                       New With {
        '                                       .almacen = al,
        '                                       .TotalesInv = tot
        '                                       }).Where(Function(i) i.almacen.tipo = "AF" And
        '                                                            i.TotalesInv.cantidad > 0 And
        '                                                            i.TotalesInv.idEmpresa = be.idEmpresa And
        '                                                            i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
        '                                                            i.TotalesInv.status = 1)}).ToList


        Dim consulta = HeliosData.detalleitems _
            .Include(Function(lot) lot.recursoCostoLote) _
            .Include(Function(cat) cat.item) _
            .Include(Function(i) i.totalesAlmacen) _
            .Include(Function(ax) ax.detalleitems_conexo) _
            .Include(Function(o) o.detalleitem_equivalencias.Select(
            Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                 .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" And d.tipoItem = "DET") _
                                 .Select(Function(o) New With
                                 {
                                 .detalleitems = o,
                                 .category = o.item,
                                 .detalleitems_conexo = o.detalleitems_conexo,
                                 .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).ToList,
                                 .documentos = (From d In HeliosData.documentocompra
                                                Join h In o.recursoCostoLote On d.idDocumento Equals h.idDocumento Select d).ToList,
                                 .lotesDetalle = o.recursoCostoLote.Select(Function(e) New With
                                            {
                                            .DetalleLote = e.LoteDetalle.Where(Function(j) j.estado = "PN")
                                            }),
                                 .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                            {
                                            .Equivale = e,
                                            .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                            .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                {
                                                                                                                                .Cat = p,
                                                                                                                                .Precios = p.detalleitemequivalencia_precios
                                                                                                                                })
                                            }),
                                .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                               New With {
                                               .almacen = al,
                                               .TotalesInv = tot
                                               }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                    i.TotalesInv.cantidad > 0 And
                                                                    i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                    i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                    i.TotalesInv.status = 1)}).ToList
        'StatusArticulo.Activo

        '      Dim c = HeliosData.totalesAlmacen.Join(HeliosData.detalleitems, Function(post) post.idItem, Function(prod) prod.codigodetalle, Function(post, prod) _
        '                                       New With
        '                                       {
        '                                       .post = post,
        '                                       .prod = prod
        '                                       }).ToList



        '.Where(Function(d) d.descripcionItem.Contains(be.descripcionItem)).ToList


        'Dim consulta = HeliosData.detalleitems.Include(Function(o) o.detalleitem_equivalencias.Select(Function(y) y.detalleitemequivalencia_precios)).Where(Function(d) d.descripcionItem.StartsWith(be.descripcionItem)).ToList


        Dim obj As detalleitems
        Dim obEquivalencia As detalleitem_equivalencias
        Dim ListEquivalencia As List(Of detalleitem_equivalencias)
        Dim ListTotalesAlmacen As List(Of totalesAlmacen)

        Dim Listdetalleitems_conexo As List(Of detalleitems_conexo)

        Dim ListLotes As List(Of recursoCostoLote)
        Dim ListEquivalenciaPrecios As List(Of detalleitemequivalencia_precios)
        Dim ListaCatalogoPrecios As List(Of detalleitemequivalencia_catalogos)
        Dim ListaBeneficios As List(Of detalleitemequivalencia_beneficio)
        GetProductosLoteDetalle = New List(Of detalleitems)

        Dim ListaDoc As List(Of documentocompra)





        Dim ListaDetLotes As List(Of LoteDetalle) = New List(Of LoteDetalle)






        For Each i In consulta

            ListaDoc = i.documentos

            ListEquivalencia = New List(Of detalleitem_equivalencias)
            ListTotalesAlmacen = New List(Of totalesAlmacen)
            ListLotes = New List(Of recursoCostoLote)
            Listdetalleitems_conexo = New List(Of detalleitems_conexo)


            For Each ax In i.detalleitems_conexo
                Listdetalleitems_conexo.Add(New detalleitems_conexo With {
                    .conexo_id = ax.conexo_id,
                    .codigodetalle = ax.codigodetalle,
                    .idProducto = ax.idProducto,
                    .detalle = ax.detalle,
                    .cantidad = ax.cantidad,
                    .equivalencia_id = ax.equivalencia_id,
                    .unidadComercial = ax.unidadComercial,
                    .fraccion = ax.fraccion,
                    .estado = ax.estado,
                    .vigencia = ax.vigencia,
                    .usuarioActualizacion = ax.usuarioActualizacion,
                    .fechaActualizacion = ax.fechaActualizacion
                                            })
            Next


            For Each det In i.lotesDetalle
                For Each dl In det.DetalleLote
                    ListaDetLotes.Add(New LoteDetalle With {
                                   .idDetalleLote = dl.idDetalleLote,
                                   .codigoLote = dl.codigoLote,
                                   .campo = dl.campo,
                                   .descripcion = dl.descripcion,
                                   .numeracion = dl.numeracion
                                   })
                Next
            Next


            For Each lt In i.Lotes


                Dim origen = (From d In ListaDoc
                              Where d.idDocumento = lt.idDocumento).FirstOrDefault

                Dim TipoDoc = origen.tipoDoc
                Dim serie = origen.serie
                Dim numero = origen.numeroDoc

                Dim lst = (From g In ListaDetLotes
                           Where g.codigoLote = lt.codigoLote).ToList







                ListLotes.Add(New recursoCostoLote With
                          {
                          .codigoLote = lt.codigoLote,
                          .nroLote = lt.nroLote,
                          .idDocumento = lt.idDocumento,
                          .idproyecto = lt.idproyecto,
                          .codigoProducto = lt.codigoProducto,
                          .moneda = lt.moneda,
                          .detalle = lt.detalle,
                          .cantidad = lt.cantidad,
                          .precioUnitarioIva = lt.precioUnitarioIva,
                          .fechaentrada = lt.fechaentrada,
                          .fechaProduccion = lt.fechaProduccion,
                          .fechaVcto = lt.fechaVcto,
                          .serie = lt.serie,
                          .sku = lt.sku,
                          .composicion = lt.composicion,
                          .productoSustentado = lt.productoSustentado,
                          .LoteDetalle = lst,
                          .idCaracteristica = lt.idCaracteristica.GetValueOrDefault,
                          .TipoDoc = TipoDoc,
                              .serieDoc = serie,
                              .numerodoc = numero
                          })
            Next



            For Each inv In i.totalesAlmacen

                ListTotalesAlmacen.Add(New totalesAlmacen With {
                                   .idMovimiento = inv.TotalesInv.idMovimiento,
                                   .idEmpresa = inv.TotalesInv.idEmpresa,
                                   .idEstablecimiento = inv.TotalesInv.idEstablecimiento,
                                   .idAlmacen = inv.TotalesInv.idAlmacen,
                                   .codigoLote = inv.TotalesInv.codigoLote,
                                   .descripcion = inv.TotalesInv.descripcion,
                                   .idUnidad = inv.TotalesInv.idUnidad,
                                   .unidadMedida = inv.TotalesInv.unidadMedida,
                                   .cantidad = inv.TotalesInv.cantidad,
                                   .cantidad2 = inv.TotalesInv.cantidad2,
                                   .importeSoles = inv.TotalesInv.importeSoles,
                                   .importeDolares = inv.TotalesInv.importeDolares,
                                   .status = inv.TotalesInv.status
                                   })
            Next





            For Each eq In i.detalleitem_equivalencias
                obEquivalencia = New detalleitem_equivalencias
                obEquivalencia.equivalencia_id = eq.Equivale.equivalencia_id
                obEquivalencia.flag = eq.Equivale.flag
                obEquivalencia.codigodetalle = eq.Equivale.codigodetalle
                obEquivalencia.detalle = eq.Equivale.detalle
                obEquivalencia.contenido = eq.Equivale.contenido
                obEquivalencia.contenido_neto = eq.Equivale.contenido_neto
                obEquivalencia.unidadComercial = eq.Equivale.unidadComercial
                obEquivalencia.fraccionUnidad = eq.Equivale.fraccionUnidad
                obEquivalencia.estado = eq.Equivale.estado


                ListaBeneficios = New List(Of detalleitemequivalencia_beneficio)
                For Each ben In eq.detalleitemequivalencia_beneficio
                    ListaBeneficios.Add(New detalleitemequivalencia_beneficio With
                                        {
                                        .beneficio_id = ben.beneficio_id,
                                        .codigodetalle = ben.codigodetalle,
                                        .modalidadVenta = ben.modalidadVenta,
                                        .aplica = ben.aplica,
                                        .equivalencia_id = ben.equivalencia_id,
                                        .beneficio_detalle = ben.beneficio_detalle,
                                        .tipobeneficio = ben.tipobeneficio,
                                        .tipoafectacion = ben.tipoafectacion,
                                        .valor_evaluado = ben.valor_evaluado,
                                        .valor_conversion = ben.valor_conversion,
                                        .valor_beneficio = ben.valor_beneficio,
                                        .lote_id = ben.lote_id,
                                        .estado = ben.estado,
                                        .usuarioActualizacion = ben.usuarioActualizacion,
                                        .fechaActualizacion = ben.fechaActualizacion
                                        })
                Next


                ListaCatalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
                For Each cat In eq.detalleitemequivalencia_catalogos
                    ListEquivalenciaPrecios = New List(Of detalleitemequivalencia_precios)
                    For Each prec In cat.Precios
                        ListEquivalenciaPrecios.Add(New detalleitemequivalencia_precios With
                                                {
                                                .precio_id = prec.precio_id,
                                                .codigodetalle = prec.codigodetalle,
                                                .equivalencia_id = prec.equivalencia_id,
                                                .idCatalogo = prec.idCatalogo,
                                                .rango_inicio = prec.rango_inicio,
                                                .rango_final = prec.rango_final,
                                                .precioCredito = prec.precioCredito,
                                                .precioCreditoUSD = prec.precioCreditoUSD,
                                                .precio = prec.precio,
                                                .precioUSD = prec.precioUSD,
                                                .precioCode = prec.precioCode,
                                                .estado = prec.estado
                                                })
                    Next

                    ListaCatalogoPrecios.Add(New detalleitemequivalencia_catalogos With {
                                             .idCatalogo = cat.Cat.idCatalogo,
                                             .codigodetalle = cat.Cat.codigodetalle,
                                             .equivalencia_id = cat.Cat.equivalencia_id,
                                             .nombre_corto = cat.Cat.nombre_corto,
                                             .nombre_largo = cat.Cat.nombre_largo,
                                             .estado = cat.Cat.estado,
                                             .predeterminado = cat.Cat.predeterminado,
                                             .detalleitemequivalencia_precios = ListEquivalenciaPrecios
                                         })


                Next
                obEquivalencia.detalleitemequivalencia_catalogos = ListaCatalogoPrecios
                obEquivalencia.detalleitemequivalencia_beneficio = ListaBeneficios
                ListEquivalencia.Add(obEquivalencia)
            Next



            Dim category As item = Nothing
            If i.category IsNot Nothing Then
                category = New item With
                           {
                           .idItem = i.category.idItem,
                           .idPadre = i.category.idPadre,
                           .descripcion = i.category.descripcion,
                           .tipo = i.category.tipo,
                           .preciocompratipo = i.category.preciocompratipo,
                           .precioCompra = i.category.precioCompra,
                           .firstpercent = i.category.firstpercent,
                           .beforepercent = i.category.beforepercent
                           }
            End If



            obj = New detalleitems With
                {
                .item = If(i.category IsNot Nothing, category, Nothing),
                .codigodetalle = i.detalleitems.codigodetalle,
                .idItem = i.detalleitems.idItem,
                .descripcionItem = i.detalleitems.descripcionItem,
                .unidad1 = i.detalleitems.unidad1,
                .tipoExistencia = i.detalleitems.tipoExistencia,
                .unidad2 = i.detalleitems.unidad2,
                .codigo = i.detalleitems.codigo,
                .origenProducto = i.detalleitems.origenProducto,
                .composicion = i.detalleitems.composicion,
                .AfectoStock = i.detalleitems.AfectoStock,
                .detalleitem_equivalencias = ListEquivalencia,
                .detalleitems_conexo = Listdetalleitems_conexo,
                .totalesAlmacen = ListTotalesAlmacen,
                .recursoCostoLote = ListLotes,
                .otroImpuesto = i.detalleitems.otroImpuesto,
                .tipoOtroImpuesto = i.detalleitems.tipoOtroImpuesto,
                .igv = i.detalleitems.igv,
                .idCaracteristica = i.detalleitems.idCaracteristica
            }
            GetProductosLoteDetalle.Add(obj)
        Next

        Return GetProductosLoteDetalle

    End Function
    Public Function GetProductosWithEquivalenciasParam(be As detalleitems, opcion As String) As List(Of detalleitems)


        Dim consulta As Object

        Select Case opcion
            Case "POR CLASIFICACION"

                consulta = HeliosData.detalleitems _
            .Include(Function(cat) cat.item) _
            .Include(Function(lot) lot.recursoCostoLote) _
            .Include(Function(ax) ax.detalleitems_conexo) _
            .Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
            .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" And d.idClasificacion = be.idClasificacion And d.idItem = be.idItem _
            And d.marcaRef = be.marcaRef And d.modelo = be.modelo) _
                                 .Select(Function(o) New With
                                 {
                                 .detalleitems = o,
                                 .category = o.item,
                                 .detalleitems_conexo = o.detalleitems_conexo,
                                 .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                 .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                            {
                                            .Equivale = e,
                                            .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                            .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                {
                                                                                                                                .Cat = p,
                                                                                                                                .Precios = p.detalleitemequivalencia_precios
                                                                                                                                })
                                            })}).ToList

            Case "POR MARCA MODELO"

                consulta = HeliosData.detalleitems _
            .Include(Function(cat) cat.item) _
            .Include(Function(lot) lot.recursoCostoLote) _
            .Include(Function(ax) ax.detalleitems_conexo) _
            .Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
            .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" _
            And d.marcaRef = be.marcaRef And d.modelo = be.modelo) _
                                 .Select(Function(o) New With
                                 {
                                 .detalleitems = o,
                                 .category = o.item,
                                 .detalleitems_conexo = o.detalleitems_conexo,
                                 .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                 .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                            {
                                            .Equivale = e,
                                            .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                            .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                {
                                                                                                                                .Cat = p,
                                                                                                                                .Precios = p.detalleitemequivalencia_precios
                                                                                                                                })
                                            })}).ToList

            Case "POR MARCA"

                consulta = HeliosData.detalleitems _
            .Include(Function(cat) cat.item) _
            .Include(Function(lot) lot.recursoCostoLote) _
            .Include(Function(ax) ax.detalleitems_conexo) _
            .Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
            .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" _
            And d.marcaRef = be.marcaRef) _
                                 .Select(Function(o) New With
                                 {
                                 .detalleitems = o,
                                 .category = o.item,
                                 .detalleitems_conexo = o.detalleitems_conexo,
                                 .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                 .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                            {
                                            .Equivale = e,
                                            .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                            .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                {
                                                                                                                                .Cat = p,
                                                                                                                                .Precios = p.detalleitemequivalencia_precios
                                                                                                                                })
                                            })}).ToList

            Case "POR SUBCLASIFICACION"

                consulta = HeliosData.detalleitems _
            .Include(Function(cat) cat.item) _
            .Include(Function(lot) lot.recursoCostoLote) _
            .Include(Function(ax) ax.detalleitems_conexo) _
            .Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
            .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" And d.idItem = be.idItem _
            And d.marcaRef = be.marcaRef And d.modelo = be.modelo) _
                                 .Select(Function(o) New With
                                 {
                                 .detalleitems = o,
                                 .category = o.item,
                                 .detalleitems_conexo = o.detalleitems_conexo,
                                 .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                 .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                            {
                                            .Equivale = e,
                                            .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                            .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                {
                                                                                                                                .Cat = p,
                                                                                                                                .Precios = p.detalleitemequivalencia_precios
                                                                                                                                })
                                            })}).ToList

        End Select



        Dim obj As detalleitems
        Dim obEquivalencia As detalleitem_equivalencias
        Dim ListEquivalencia As List(Of detalleitem_equivalencias)
        Dim Listdetalleitems_conexo As List(Of detalleitems_conexo)
        Dim ListEquivalenciaPrecios As List(Of detalleitemequivalencia_precios)
        Dim ListaCatalogoPrecios As List(Of detalleitemequivalencia_catalogos)
        Dim ListaBeneficios As List(Of detalleitemequivalencia_beneficio)
        Dim ListaLotes As List(Of recursoCostoLote) = Nothing

        GetProductosWithEquivalenciasParam = New List(Of detalleitems)

        For Each i In consulta
            Listdetalleitems_conexo = New List(Of detalleitems_conexo)
            For Each ax In i.detalleitems_conexo
                Listdetalleitems_conexo.Add(New detalleitems_conexo With {
                    .conexo_id = ax.conexo_id,
                    .codigodetalle = ax.codigodetalle,
                    .idProducto = ax.idProducto,
                    .detalle = ax.detalle,
                    .cantidad = ax.cantidad,
                    .equivalencia_id = ax.equivalencia_id,
                    .unidadComercial = ax.unidadComercial,
                    .fraccion = ax.fraccion,
                    .estado = ax.estado,
                    .vigencia = ax.vigencia,
                    .usuarioActualizacion = ax.usuarioActualizacion,
                    .fechaActualizacion = ax.fechaActualizacion
                                            })
            Next


            ListEquivalencia = New List(Of detalleitem_equivalencias)
            For Each eq In i.detalleitem_equivalencias
                obEquivalencia = New detalleitem_equivalencias
                obEquivalencia.codigodetalle = i.detalleitems.codigodetalle
                obEquivalencia.detalle = eq.Equivale.detalle
                obEquivalencia.unidadComercial = eq.Equivale.unidadComercial
                obEquivalencia.contenido = eq.Equivale.contenido
                obEquivalencia.equivalencia_id = eq.Equivale.equivalencia_id
                obEquivalencia.fraccionUnidad = eq.Equivale.fraccionUnidad
                obEquivalencia.estado = eq.Equivale.estado
                obEquivalencia.flag = eq.Equivale.flag
                obEquivalencia.contenido_neto = eq.Equivale.contenido_neto
                obEquivalencia.codigo = eq.Equivale.codigo

                ListaLotes = New List(Of recursoCostoLote)
                For Each lot In i.Lotes
                    Dim l As New recursoCostoLote With
                    {
                    .codigoLote = lot.codigoLote,
                    .nroLote = lot.nroLote,
                    .idDocumento = lot.idDocumento,
                    .idproyecto = lot.idproyecto,
                    .codigoProducto = lot.codigoProducto,
                    .moneda = lot.moneda,
                    .detalle = lot.detalle,
                    .cantidad = lot.cantidad,
                    .precioUnitarioIva = lot.precioUnitarioIva,
                    .fechaentrada = lot.fechaentrada,
                    .fechaProduccion = lot.fechaProduccion,
                    .fechaVcto = lot.fechaVcto,
                    .serie = lot.serie,
                    .sku = lot.sku,
                    .composicion = lot.composicion,
                    .productoSustentado = lot.productoSustentado
                    }
                    ListaLotes.Add(l)
                Next

                ListaBeneficios = New List(Of detalleitemequivalencia_beneficio)
                For Each ben In eq.detalleitemequivalencia_beneficio
                    ListaBeneficios.Add(New detalleitemequivalencia_beneficio With
                                        {
                                        .beneficio_id = ben.beneficio_id,
                                        .codigodetalle = ben.codigodetalle,
                                        .equivalencia_id = ben.equivalencia_id,
                                        .beneficio_detalle = ben.beneficio_detalle,
                                        .tipobeneficio = ben.tipobeneficio,
                                        .tipoafectacion = ben.tipoafectacion,
                                        .valor_evaluado = ben.valor_evaluado,
                                        .valor_conversion = ben.valor_conversion,
                                        .valor_beneficio = ben.valor_beneficio,
                                        .lote_id = ben.lote_id,
                                        .estado = ben.estado,
                                        .usuarioActualizacion = ben.usuarioActualizacion,
                                        .fechaActualizacion = ben.fechaActualizacion
                                        })
                Next


                ListaCatalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
                For Each cat In eq.detalleitemequivalencia_catalogos
                    ListEquivalenciaPrecios = New List(Of detalleitemequivalencia_precios)
                    For Each prec In cat.Precios
                        ListEquivalenciaPrecios.Add(New detalleitemequivalencia_precios With
                                                    {
                                                    .idCatalogo = cat.Cat.idCatalogo,
                                                    .rango_inicio = prec.rango_inicio,
                                                    .rango_final = prec.rango_final,
                                                    .precioCredito = prec.precioCredito,
                                                    .precioCreditoUSD = prec.precioCreditoUSD,
                                                    .precio = prec.precio,
                                                    .precioUSD = prec.precioUSD,
                                                    .precio_id = prec.precio_id,
                                                    .precioCode = prec.precioCode,
                                                    .estado = prec.estado
                                                    })
                    Next


                    ListaCatalogoPrecios.Add(New detalleitemequivalencia_catalogos With {
                                             .idCatalogo = cat.Cat.idCatalogo,
                                             .codigodetalle = cat.Cat.codigodetalle,
                                             .equivalencia_id = cat.Cat.equivalencia_id,
                                             .nombre_corto = cat.Cat.nombre_corto,
                                             .nombre_largo = cat.Cat.nombre_largo,
                                             .estado = cat.Cat.estado,
                                             .predeterminado = cat.Cat.predeterminado,
                                             .detalleitemequivalencia_precios = ListEquivalenciaPrecios
                                             })
                Next
                obEquivalencia.detalleitemequivalencia_catalogos = ListaCatalogoPrecios
                obEquivalencia.detalleitemequivalencia_beneficio = ListaBeneficios
                ListEquivalencia.Add(obEquivalencia)
            Next
            Dim category As item = Nothing
            If i.category IsNot Nothing Then
                category = New item With
                {
                .idItem = i.category.idItem,
                .idPadre = i.category.idPadre,
                .idEmpresa = i.category.idEmpresa,
                .idEstablecimiento = i.category.idEstablecimiento,
                .fechaIngreso = i.category.fechaIngreso,
                .descripcion = i.category.descripcion,
                .tipo = i.category.tipo,
                .preciocompratipo = i.category.preciocompratipo,
                .precioCompra = i.category.precioCompra,
                .firstpercent = i.category.firstpercent,
                .beforepercent = i.category.beforepercent
                }
            End If

            obj = New detalleitems With
            {
            .item = category,
            .codigodetalle = i.detalleitems.codigodetalle,
            .estado = i.detalleitems.estado,
            .idItem = i.detalleitems.idItem,
            .descripcionItem = i.detalleitems.descripcionItem,
            .unidad1 = i.detalleitems.unidad1,
            .tipoExistencia = i.detalleitems.tipoExistencia,
            .unidad2 = i.detalleitems.unidad2,
            .codigo = i.detalleitems.codigo,
            .origenProducto = i.detalleitems.origenProducto,
            .composicion = i.detalleitems.composicion,
            .detalleitem_equivalencias = ListEquivalencia,
            .recursoCostoLote = ListaLotes,
            .tipoOtroImpuesto = i.detalleitems.tipoOtroImpuesto,
            .otroImpuesto = i.detalleitems.otroImpuesto,
            .precioCompra = i.detalleitems.precioCompra,
            .preciocompratipo = i.detalleitems.preciocompratipo,
            .firstpercent = i.detalleitems.firstpercent,
            .beforepercent = i.detalleitems.beforepercent,
            .detalleitems_conexo = Listdetalleitems_conexo
            }
            GetProductosWithEquivalenciasParam.Add(obj)
        Next
        Return GetProductosWithEquivalenciasParam
    End Function




    Public Function GetProductosWithInventarioCodigos(be As detalleitems, opcion As String) As List(Of detalleitems)

        Try



            Dim coditoClasi = (From i In HeliosData.item
                               Where i.codigo = be.codigoInterno And i.tipo = opcion).FirstOrDefault


            If coditoClasi IsNot Nothing Then



                Dim consulta As Object

                Select Case opcion
                    Case "H"

                    Case "G"

                        consulta = HeliosData.detalleitems _
                 .Include(Function(cat) cat.item) _
                 .Include(Function(lot) lot.recursoCostoLote) _
                 .Include(Function(i) i.totalesAlmacen) _
                 .Include(Function(ax) ax.detalleitems_conexo) _
                 .Include(Function(o) o.detalleitem_equivalencias.Select(
                 Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                      .Where(Function(d) d.estado = "A" _
                                        And d.idClasificacion = coditoClasi.idItem) _
                                      .Select(Function(o) New With
                                      {
                                      .detalleitems = o,
                                      .category = o.item,
                                      .detalleitems_conexo = o.detalleitems_conexo,
                                      .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                      .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                                 {
                                                 .Equivale = e,
                                                 .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                                 .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                     {
                                                                                                                                     .Cat = p,
                                                                                                                                     .Precios = p.detalleitemequivalencia_precios
                                                                                                                                     })
                                                 }),
                                     .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                                    New With {
                                                    .almacen = al,
                                                    .TotalesInv = tot
                                                    }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                         i.TotalesInv.cantidad > 0 And
                                                                         i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                         i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                         i.TotalesInv.status = 1)}).ToList

                    Case "C"

                        consulta = HeliosData.detalleitems _
                  .Include(Function(cat) cat.item) _
                  .Include(Function(lot) lot.recursoCostoLote) _
                  .Include(Function(i) i.totalesAlmacen) _
                  .Include(Function(ax) ax.detalleitems_conexo) _
                  .Include(Function(o) o.detalleitem_equivalencias.Select(
                  Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                       .Where(Function(d) d.estado = "A" _
                                         And d.idItem = coditoClasi.idItem) _
                                       .Select(Function(o) New With
                                       {
                                       .detalleitems = o,
                                       .category = o.item,
                                       .detalleitems_conexo = o.detalleitems_conexo,
                                       .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                       .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                                  {
                                                  .Equivale = e,
                                                  .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                                  .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                      {
                                                                                                                                      .Cat = p,
                                                                                                                                      .Precios = p.detalleitemequivalencia_precios
                                                                                                                                      })
                                                  }),
                                      .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                                     New With {
                                                     .almacen = al,
                                                     .TotalesInv = tot
                                                     }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                          i.TotalesInv.cantidad > 0 And
                                                                          i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                          i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                          i.TotalesInv.status = 1)}).ToList


                    Case "M"

                        consulta = HeliosData.detalleitems _
                 .Include(Function(cat) cat.item) _
                 .Include(Function(lot) lot.recursoCostoLote) _
                 .Include(Function(i) i.totalesAlmacen) _
                 .Include(Function(ax) ax.detalleitems_conexo) _
                 .Include(Function(o) o.detalleitem_equivalencias.Select(
                 Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                      .Where(Function(d) d.estado = "A" _
                                        And d.marcaRef = coditoClasi.idItem) _
                                      .Select(Function(o) New With
                                      {
                                      .detalleitems = o,
                                      .category = o.item,
                                      .detalleitems_conexo = o.detalleitems_conexo,
                                      .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                      .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                                 {
                                                 .Equivale = e,
                                                 .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                                 .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                     {
                                                                                                                                     .Cat = p,
                                                                                                                                     .Precios = p.detalleitemequivalencia_precios
                                                                                                                                     })
                                                 }),
                                     .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                                    New With {
                                                    .almacen = al,
                                                    .TotalesInv = tot
                                                    }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                         i.TotalesInv.cantidad > 0 And
                                                                         i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                         i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                         i.TotalesInv.status = 1)}).ToList

                    Case "P"



                        consulta = HeliosData.detalleitems _
                .Include(Function(cat) cat.item) _
                .Include(Function(lot) lot.recursoCostoLote) _
                .Include(Function(i) i.totalesAlmacen) _
                .Include(Function(ax) ax.detalleitems_conexo) _
                .Include(Function(o) o.detalleitem_equivalencias.Select(
                Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                     .Where(Function(d) d.estado = "A" _
                                       And d.idCaracteristica = coditoClasi.idItem) _
                                     .Select(Function(o) New With
                                     {
                                     .detalleitems = o,
                                     .category = o.item,
                                     .detalleitems_conexo = o.detalleitems_conexo,
                                     .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                     .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                                {
                                                .Equivale = e,
                                                .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                                .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                    {
                                                                                                                                    .Cat = p,
                                                                                                                                    .Precios = p.detalleitemequivalencia_precios
                                                                                                                                    })
                                                }),
                                    .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                                   New With {
                                                   .almacen = al,
                                                   .TotalesInv = tot
                                                   }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                        i.TotalesInv.cantidad > 0 And
                                                                        i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                        i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                        i.TotalesInv.status = 1)}).ToList

                End Select

                Dim obj As detalleitems
                Dim obEquivalencia As detalleitem_equivalencias
                Dim ListEquivalencia As List(Of detalleitem_equivalencias)
                Dim ListTotalesAlmacen As List(Of totalesAlmacen)

                Dim Listdetalleitems_conexo As List(Of detalleitems_conexo)

                Dim ListLotes As List(Of recursoCostoLote)
                Dim ListEquivalenciaPrecios As List(Of detalleitemequivalencia_precios)
                Dim ListaCatalogoPrecios As List(Of detalleitemequivalencia_catalogos)
                Dim ListaBeneficios As List(Of detalleitemequivalencia_beneficio)
                GetProductosWithInventarioCodigos = New List(Of detalleitems)

                For Each i In consulta

                    ListEquivalencia = New List(Of detalleitem_equivalencias)
                    ListTotalesAlmacen = New List(Of totalesAlmacen)
                    ListLotes = New List(Of recursoCostoLote)
                    Listdetalleitems_conexo = New List(Of detalleitems_conexo)


                    For Each ax In i.detalleitems_conexo
                        Listdetalleitems_conexo.Add(New detalleitems_conexo With {
                            .conexo_id = ax.conexo_id,
                            .codigodetalle = ax.codigodetalle,
                            .idProducto = ax.idProducto,
                            .detalle = ax.detalle,
                            .cantidad = ax.cantidad,
                            .equivalencia_id = ax.equivalencia_id,
                            .unidadComercial = ax.unidadComercial,
                            .fraccion = ax.fraccion,
                            .estado = ax.estado,
                            .vigencia = ax.vigencia,
                            .usuarioActualizacion = ax.usuarioActualizacion,
                            .fechaActualizacion = ax.fechaActualizacion
                                                    })
                    Next

                    For Each lt In i.Lotes
                        ListLotes.Add(New recursoCostoLote With
                                      {
                                      .codigoLote = lt.codigoLote,
                                      .nroLote = lt.nroLote,
                                      .idDocumento = lt.idDocumento,
                                      .idproyecto = lt.idproyecto,
                                      .codigoProducto = lt.codigoProducto,
                                      .moneda = lt.moneda,
                                      .detalle = lt.detalle,
                                      .cantidad = lt.cantidad,
                                      .precioUnitarioIva = lt.precioUnitarioIva,
                                      .fechaentrada = lt.fechaentrada,
                                      .fechaProduccion = lt.fechaProduccion,
                                      .fechaVcto = lt.fechaVcto,
                                      .serie = lt.serie,
                                      .sku = lt.sku,
                                      .composicion = lt.composicion,
                                      .productoSustentado = lt.productoSustentado
                                      })
                    Next



                    For Each inv In i.totalesAlmacen

                        ListTotalesAlmacen.Add(New totalesAlmacen With {
                                               .idMovimiento = inv.TotalesInv.idMovimiento,
                                               .idEmpresa = inv.TotalesInv.idEmpresa,
                                               .idEstablecimiento = inv.TotalesInv.idEstablecimiento,
                                               .idAlmacen = inv.TotalesInv.idAlmacen,
                                               .codigoLote = inv.TotalesInv.codigoLote,
                                               .descripcion = inv.TotalesInv.descripcion,
                                               .idUnidad = inv.TotalesInv.idUnidad,
                                               .unidadMedida = inv.TotalesInv.unidadMedida,
                                               .cantidad = inv.TotalesInv.cantidad,
                                               .cantidad2 = inv.TotalesInv.cantidad2,
                                               .importeSoles = inv.TotalesInv.importeSoles,
                                               .importeDolares = inv.TotalesInv.importeDolares,
                                               .status = inv.TotalesInv.status
                                               })
                    Next

                    For Each eq In i.detalleitem_equivalencias
                        obEquivalencia = New detalleitem_equivalencias
                        obEquivalencia.equivalencia_id = eq.Equivale.equivalencia_id
                        obEquivalencia.flag = eq.Equivale.flag
                        obEquivalencia.codigodetalle = eq.Equivale.codigodetalle
                        obEquivalencia.detalle = eq.Equivale.detalle
                        obEquivalencia.contenido = eq.Equivale.contenido
                        obEquivalencia.contenido_neto = eq.Equivale.contenido_neto
                        obEquivalencia.unidadComercial = eq.Equivale.unidadComercial
                        obEquivalencia.fraccionUnidad = eq.Equivale.fraccionUnidad
                        obEquivalencia.estado = eq.Equivale.estado


                        ListaBeneficios = New List(Of detalleitemequivalencia_beneficio)
                        For Each ben In eq.detalleitemequivalencia_beneficio
                            ListaBeneficios.Add(New detalleitemequivalencia_beneficio With
                                                {
                                                .beneficio_id = ben.beneficio_id,
                                                .codigodetalle = ben.codigodetalle,
                                                .modalidadVenta = ben.modalidadVenta,
                                                .aplica = ben.aplica,
                                                .equivalencia_id = ben.equivalencia_id,
                                                .beneficio_detalle = ben.beneficio_detalle,
                                                .tipobeneficio = ben.tipobeneficio,
                                                .tipoafectacion = ben.tipoafectacion,
                                                .valor_evaluado = ben.valor_evaluado,
                                                .valor_conversion = ben.valor_conversion,
                                                .valor_beneficio = ben.valor_beneficio,
                                                .lote_id = ben.lote_id,
                                                .estado = ben.estado,
                                                .usuarioActualizacion = ben.usuarioActualizacion,
                                                .fechaActualizacion = ben.fechaActualizacion
                                                })
                        Next


                        ListaCatalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
                        For Each cat In eq.detalleitemequivalencia_catalogos
                            ListEquivalenciaPrecios = New List(Of detalleitemequivalencia_precios)
                            For Each prec In cat.Precios
                                ListEquivalenciaPrecios.Add(New detalleitemequivalencia_precios With
                                                            {
                                                            .precio_id = prec.precio_id,
                                                            .codigodetalle = prec.codigodetalle,
                                                            .equivalencia_id = prec.equivalencia_id,
                                                            .idCatalogo = prec.idCatalogo,
                                                            .rango_inicio = prec.rango_inicio,
                                                            .rango_final = prec.rango_final,
                                                            .precioCredito = prec.precioCredito,
                                                            .precioCreditoUSD = prec.precioCreditoUSD,
                                                            .precio = prec.precio,
                                                            .precioUSD = prec.precioUSD,
                                                            .precioCode = prec.precioCode,
                                                            .estado = prec.estado
                                                            })
                            Next

                            ListaCatalogoPrecios.Add(New detalleitemequivalencia_catalogos With {
                                                         .idCatalogo = cat.Cat.idCatalogo,
                                                         .codigodetalle = cat.Cat.codigodetalle,
                                                         .equivalencia_id = cat.Cat.equivalencia_id,
                                                         .nombre_corto = cat.Cat.nombre_corto,
                                                         .nombre_largo = cat.Cat.nombre_largo,
                                                         .estado = cat.Cat.estado,
                                                         .predeterminado = cat.Cat.predeterminado,
                                                         .detalleitemequivalencia_precios = ListEquivalenciaPrecios
                                                     })


                        Next
                        obEquivalencia.detalleitemequivalencia_catalogos = ListaCatalogoPrecios
                        obEquivalencia.detalleitemequivalencia_beneficio = ListaBeneficios
                        ListEquivalencia.Add(obEquivalencia)
                    Next
                    Dim category As item = Nothing
                    If i.category IsNot Nothing Then
                        category = New item With
                                   {
                                   .idItem = i.category.idItem,
                                   .idPadre = i.category.idPadre,
                                   .descripcion = i.category.descripcion,
                                   .tipo = i.category.tipo,
                                   .preciocompratipo = i.category.preciocompratipo,
                                   .precioCompra = i.category.precioCompra,
                                   .firstpercent = i.category.firstpercent,
                                   .beforepercent = i.category.beforepercent
                                   }
                    End If
                    obj = New detalleitems With
                        {
                        .item = If(i.category IsNot Nothing, category, Nothing),
                        .codigodetalle = i.detalleitems.codigodetalle,
                        .idItem = i.detalleitems.idItem,
                        .descripcionItem = i.detalleitems.descripcionItem,
                        .unidad1 = i.detalleitems.unidad1,
                        .tipoExistencia = i.detalleitems.tipoExistencia,
                        .unidad2 = i.detalleitems.unidad2,
                        .codigo = i.detalleitems.codigo,
                        .origenProducto = i.detalleitems.origenProducto,
                        .composicion = i.detalleitems.composicion,
                        .AfectoStock = i.detalleitems.AfectoStock,
                        .detalleitem_equivalencias = ListEquivalencia,
                        .detalleitems_conexo = Listdetalleitems_conexo,
                        .totalesAlmacen = ListTotalesAlmacen,
                        .recursoCostoLote = ListLotes,
                        .otroImpuesto = i.detalleitems.otroImpuesto,
                        .tipoOtroImpuesto = i.detalleitems.tipoOtroImpuesto,
                        .igv = i.detalleitems.igv,
                        .precioCompra = i.detalleitems.precioCompra,
                        .preciocompratipo = i.detalleitems.preciocompratipo,
                        .firstpercent = i.detalleitems.firstpercent,
                        .beforepercent = i.detalleitems.beforepercent
                    }
                    GetProductosWithInventarioCodigos.Add(obj)
                Next

                Return GetProductosWithInventarioCodigos
            Else
                Return GetProductosWithInventarioCodigos
            End If
        Catch ex As Exception

        End Try

    End Function



    Public Function GetProductosWithInventarioParam(be As detalleitems, opcion As String) As List(Of detalleitems)

        Try




            Dim consulta As Object

            Select Case opcion
                Case "1"

                    consulta = HeliosData.detalleitems _
              .Include(Function(cat) cat.item) _
              .Include(Function(lot) lot.recursoCostoLote) _
              .Include(Function(i) i.totalesAlmacen) _
              .Include(Function(ax) ax.detalleitems_conexo) _
              .Include(Function(o) o.detalleitem_equivalencias.Select(
              Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                   .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" And d.idClasificacion = be.idClasificacion _
                                    And d.idItem = be.idItem And d.marcaRef = be.marcaRef And d.modelo = be.modelo) _
                                   .Select(Function(o) New With
                                   {
                                   .detalleitems = o,
                                   .category = o.item,
                                   .detalleitems_conexo = o.detalleitems_conexo,
                                   .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                   .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                              {
                                              .Equivale = e,
                                              .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                              .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                  {
                                                                                                                                  .Cat = p,
                                                                                                                                  .Precios = p.detalleitemequivalencia_precios
                                                                                                                                  })
                                              }),
                                  .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                                 New With {
                                                 .almacen = al,
                                                 .TotalesInv = tot
                                                 }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                      i.TotalesInv.cantidad > 0 And
                                                                      i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                      i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                      i.TotalesInv.status = 1)}).ToList

                Case "2"

                    consulta = HeliosData.detalleitems _
             .Include(Function(cat) cat.item) _
             .Include(Function(lot) lot.recursoCostoLote) _
             .Include(Function(i) i.totalesAlmacen) _
             .Include(Function(ax) ax.detalleitems_conexo) _
             .Include(Function(o) o.detalleitem_equivalencias.Select(
             Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                  .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" _
                                   And d.idItem = be.idItem And d.marcaRef = be.marcaRef And d.modelo = be.modelo) _
                                  .Select(Function(o) New With
                                  {
                                  .detalleitems = o,
                                  .category = o.item,
                                  .detalleitems_conexo = o.detalleitems_conexo,
                                  .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                  .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                             {
                                             .Equivale = e,
                                             .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                             .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                 {
                                                                                                                                 .Cat = p,
                                                                                                                                 .Precios = p.detalleitemequivalencia_precios
                                                                                                                                 })
                                             }),
                                 .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                                New With {
                                                .almacen = al,
                                                .TotalesInv = tot
                                                }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                     i.TotalesInv.cantidad > 0 And
                                                                     i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                     i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                     i.TotalesInv.status = 1)}).ToList

                Case "3"

                    consulta = HeliosData.detalleitems _
              .Include(Function(cat) cat.item) _
              .Include(Function(lot) lot.recursoCostoLote) _
              .Include(Function(i) i.totalesAlmacen) _
              .Include(Function(ax) ax.detalleitems_conexo) _
              .Include(Function(o) o.detalleitem_equivalencias.Select(
              Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                   .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" _
                                    And d.marcaRef = be.marcaRef And d.modelo = be.modelo) _
                                   .Select(Function(o) New With
                                   {
                                   .detalleitems = o,
                                   .category = o.item,
                                   .detalleitems_conexo = o.detalleitems_conexo,
                                   .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                   .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                              {
                                              .Equivale = e,
                                              .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                              .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                  {
                                                                                                                                  .Cat = p,
                                                                                                                                  .Precios = p.detalleitemequivalencia_precios
                                                                                                                                  })
                                              }),
                                  .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                                 New With {
                                                 .almacen = al,
                                                 .TotalesInv = tot
                                                 }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                      i.TotalesInv.cantidad > 0 And
                                                                      i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                      i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                      i.TotalesInv.status = 1)}).ToList

                Case "4"

                    consulta = HeliosData.detalleitems _
              .Include(Function(cat) cat.item) _
              .Include(Function(lot) lot.recursoCostoLote) _
              .Include(Function(i) i.totalesAlmacen) _
              .Include(Function(ax) ax.detalleitems_conexo) _
              .Include(Function(o) o.detalleitem_equivalencias.Select(
              Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                   .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" _
                                    And d.modelo = be.modelo) _
                                   .Select(Function(o) New With
                                   {
                                   .detalleitems = o,
                                   .category = o.item,
                                   .detalleitems_conexo = o.detalleitems_conexo,
                                   .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                   .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                              {
                                              .Equivale = e,
                                              .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                              .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                  {
                                                                                                                                  .Cat = p,
                                                                                                                                  .Precios = p.detalleitemequivalencia_precios
                                                                                                                                  })
                                              }),
                                  .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                                 New With {
                                                 .almacen = al,
                                                 .TotalesInv = tot
                                                 }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                      i.TotalesInv.cantidad > 0 And
                                                                      i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                      i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                      i.TotalesInv.status = 1)}).ToList

                Case "5"

                    consulta = HeliosData.detalleitems _
           .Include(Function(cat) cat.item) _
           .Include(Function(lot) lot.recursoCostoLote) _
           .Include(Function(i) i.totalesAlmacen) _
           .Include(Function(ax) ax.detalleitems_conexo) _
           .Include(Function(o) o.detalleitem_equivalencias.Select(
           Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" And d.idClasificacion = be.idClasificacion) _
                                .Select(Function(o) New With
                                {
                                .detalleitems = o,
                                .category = o.item,
                                .detalleitems_conexo = o.detalleitems_conexo,
                                .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                           {
                                           .Equivale = e,
                                           .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                           .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                               {
                                                                                                                               .Cat = p,
                                                                                                                               .Precios = p.detalleitemequivalencia_precios
                                                                                                                               })
                                           }),
                               .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                              New With {
                                              .almacen = al,
                                              .TotalesInv = tot
                                              }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                   i.TotalesInv.cantidad > 0 And
                                                                   i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                   i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                   i.TotalesInv.status = 1)}).ToList

                Case "6"

                    consulta = HeliosData.detalleitems _
              .Include(Function(cat) cat.item) _
              .Include(Function(lot) lot.recursoCostoLote) _
              .Include(Function(i) i.totalesAlmacen) _
              .Include(Function(ax) ax.detalleitems_conexo) _
              .Include(Function(o) o.detalleitem_equivalencias.Select(
              Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                   .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" And d.idClasificacion = be.idClasificacion _
                                    And d.idItem = be.idItem) _
                                   .Select(Function(o) New With
                                   {
                                   .detalleitems = o,
                                   .category = o.item,
                                   .detalleitems_conexo = o.detalleitems_conexo,
                                   .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                   .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                              {
                                              .Equivale = e,
                                              .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                              .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                  {
                                                                                                                                  .Cat = p,
                                                                                                                                  .Precios = p.detalleitemequivalencia_precios
                                                                                                                                  })
                                              }),
                                  .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                                 New With {
                                                 .almacen = al,
                                                 .TotalesInv = tot
                                                 }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                      i.TotalesInv.cantidad > 0 And
                                                                      i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                      i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                      i.TotalesInv.status = 1)}).ToList

                Case "7"

                    consulta = HeliosData.detalleitems _
              .Include(Function(cat) cat.item) _
              .Include(Function(lot) lot.recursoCostoLote) _
              .Include(Function(i) i.totalesAlmacen) _
              .Include(Function(ax) ax.detalleitems_conexo) _
              .Include(Function(o) o.detalleitem_equivalencias.Select(
              Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                   .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" And d.idClasificacion = be.idClasificacion _
                                    And d.idItem = be.idItem And d.marcaRef = be.marcaRef) _
                                   .Select(Function(o) New With
                                   {
                                   .detalleitems = o,
                                   .category = o.item,
                                   .detalleitems_conexo = o.detalleitems_conexo,
                                   .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                   .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                              {
                                              .Equivale = e,
                                              .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                              .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                  {
                                                                                                                                  .Cat = p,
                                                                                                                                  .Precios = p.detalleitemequivalencia_precios
                                                                                                                                  })
                                              }),
                                  .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                                 New With {
                                                 .almacen = al,
                                                 .TotalesInv = tot
                                                 }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                      i.TotalesInv.cantidad > 0 And
                                                                      i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                      i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                      i.TotalesInv.status = 1)}).ToList

                Case "9"

                    consulta = HeliosData.detalleitems _
              .Include(Function(cat) cat.item) _
              .Include(Function(lot) lot.recursoCostoLote) _
              .Include(Function(i) i.totalesAlmacen) _
              .Include(Function(ax) ax.detalleitems_conexo) _
              .Include(Function(o) o.detalleitem_equivalencias.Select(
              Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                   .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" And d.idClasificacion = be.idClasificacion _
                                    And d.marcaRef = be.marcaRef) _
                                   .Select(Function(o) New With
                                   {
                                   .detalleitems = o,
                                   .category = o.item,
                                   .detalleitems_conexo = o.detalleitems_conexo,
                                   .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                   .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                              {
                                              .Equivale = e,
                                              .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                              .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                  {
                                                                                                                                  .Cat = p,
                                                                                                                                  .Precios = p.detalleitemequivalencia_precios
                                                                                                                                  })
                                              }),
                                  .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                                 New With {
                                                 .almacen = al,
                                                 .TotalesInv = tot
                                                 }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                      i.TotalesInv.cantidad > 0 And
                                                                      i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                      i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                      i.TotalesInv.status = 1)}).ToList

                Case "10"

                    consulta = HeliosData.detalleitems _
              .Include(Function(cat) cat.item) _
              .Include(Function(lot) lot.recursoCostoLote) _
              .Include(Function(i) i.totalesAlmacen) _
              .Include(Function(ax) ax.detalleitems_conexo) _
              .Include(Function(o) o.detalleitem_equivalencias.Select(
              Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                   .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" And d.idClasificacion = be.idClasificacion _
                                     And d.marcaRef = be.marcaRef And d.modelo = be.modelo) _
                                   .Select(Function(o) New With
                                   {
                                   .detalleitems = o,
                                   .category = o.item,
                                   .detalleitems_conexo = o.detalleitems_conexo,
                                   .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                   .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                              {
                                              .Equivale = e,
                                              .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                              .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                  {
                                                                                                                                  .Cat = p,
                                                                                                                                  .Precios = p.detalleitemequivalencia_precios
                                                                                                                                  })
                                              }),
                                  .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                                 New With {
                                                 .almacen = al,
                                                 .TotalesInv = tot
                                                 }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                      i.TotalesInv.cantidad > 0 And
                                                                      i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                      i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                      i.TotalesInv.status = 1)}).ToList

                Case "12"

                    consulta = HeliosData.detalleitems _
              .Include(Function(cat) cat.item) _
              .Include(Function(lot) lot.recursoCostoLote) _
              .Include(Function(i) i.totalesAlmacen) _
              .Include(Function(ax) ax.detalleitems_conexo) _
              .Include(Function(o) o.detalleitem_equivalencias.Select(
              Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                   .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" _
                                    And d.idItem = be.idItem And d.modelo = be.modelo) _
                                   .Select(Function(o) New With
                                   {
                                   .detalleitems = o,
                                   .category = o.item,
                                   .detalleitems_conexo = o.detalleitems_conexo,
                                   .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                   .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                              {
                                              .Equivale = e,
                                              .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                              .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                  {
                                                                                                                                  .Cat = p,
                                                                                                                                  .Precios = p.detalleitemequivalencia_precios
                                                                                                                                  })
                                              }),
                                  .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                                 New With {
                                                 .almacen = al,
                                                 .TotalesInv = tot
                                                 }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                      i.TotalesInv.cantidad > 0 And
                                                                      i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                      i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                      i.TotalesInv.status = 1)}).ToList


                Case "13"

                    consulta = HeliosData.detalleitems _
              .Include(Function(cat) cat.item) _
              .Include(Function(lot) lot.recursoCostoLote) _
              .Include(Function(i) i.totalesAlmacen) _
              .Include(Function(ax) ax.detalleitems_conexo) _
              .Include(Function(o) o.detalleitem_equivalencias.Select(
              Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                   .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" _
                                    And d.idItem = be.idItem) _
                                   .Select(Function(o) New With
                                   {
                                   .detalleitems = o,
                                   .category = o.item,
                                   .detalleitems_conexo = o.detalleitems_conexo,
                                   .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                   .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                              {
                                              .Equivale = e,
                                              .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                              .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                  {
                                                                                                                                  .Cat = p,
                                                                                                                                  .Precios = p.detalleitemequivalencia_precios
                                                                                                                                  })
                                              }),
                                  .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                                 New With {
                                                 .almacen = al,
                                                 .TotalesInv = tot
                                                 }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                      i.TotalesInv.cantidad > 0 And
                                                                      i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                      i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                      i.TotalesInv.status = 1)}).ToList

                Case "14"

                    consulta = HeliosData.detalleitems _
             .Include(Function(cat) cat.item) _
             .Include(Function(lot) lot.recursoCostoLote) _
             .Include(Function(i) i.totalesAlmacen) _
             .Include(Function(ax) ax.detalleitems_conexo) _
             .Include(Function(o) o.detalleitem_equivalencias.Select(
             Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                  .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" _
                                   And d.marcaRef = be.marcaRef) _
                                  .Select(Function(o) New With
                                  {
                                  .detalleitems = o,
                                  .category = o.item,
                                  .detalleitems_conexo = o.detalleitems_conexo,
                                  .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                  .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                             {
                                             .Equivale = e,
                                             .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                             .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                 {
                                                                                                                                 .Cat = p,
                                                                                                                                 .Precios = p.detalleitemequivalencia_precios
                                                                                                                                 })
                                             }),
                                 .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                                New With {
                                                .almacen = al,
                                                .TotalesInv = tot
                                                }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                     i.TotalesInv.cantidad > 0 And
                                                                     i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                     i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                     i.TotalesInv.status = 1)}).ToList

                Case "15"

                    consulta = HeliosData.detalleitems _
              .Include(Function(cat) cat.item) _
              .Include(Function(lot) lot.recursoCostoLote) _
              .Include(Function(i) i.totalesAlmacen) _
              .Include(Function(ax) ax.detalleitems_conexo) _
              .Include(Function(o) o.detalleitem_equivalencias.Select(
              Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                   .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" And d.idClasificacion = be.idClasificacion _
                                    And d.idItem = be.idItem And d.modelo = be.modelo) _
                                   .Select(Function(o) New With
                                   {
                                   .detalleitems = o,
                                   .category = o.item,
                                   .detalleitems_conexo = o.detalleitems_conexo,
                                   .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                   .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                              {
                                              .Equivale = e,
                                              .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                              .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                  {
                                                                                                                                  .Cat = p,
                                                                                                                                  .Precios = p.detalleitemequivalencia_precios
                                                                                                                                  })
                                              }),
                                  .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                                 New With {
                                                 .almacen = al,
                                                 .TotalesInv = tot
                                                 }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                      i.TotalesInv.cantidad > 0 And
                                                                      i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                      i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                      i.TotalesInv.status = 1)}).ToList

                Case "16"

                    consulta = HeliosData.detalleitems _
              .Include(Function(cat) cat.item) _
              .Include(Function(lot) lot.recursoCostoLote) _
              .Include(Function(i) i.totalesAlmacen) _
              .Include(Function(ax) ax.detalleitems_conexo) _
              .Include(Function(o) o.detalleitem_equivalencias.Select(
              Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                   .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" _
                                    And d.idItem = be.idItem And d.marcaRef = be.marcaRef) _
                                   .Select(Function(o) New With
                                   {
                                   .detalleitems = o,
                                   .category = o.item,
                                   .detalleitems_conexo = o.detalleitems_conexo,
                                   .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                   .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                              {
                                              .Equivale = e,
                                              .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                              .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                  {
                                                                                                                                  .Cat = p,
                                                                                                                                  .Precios = p.detalleitemequivalencia_precios
                                                                                                                                  })
                                              }),
                                  .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                                 New With {
                                                 .almacen = al,
                                                 .TotalesInv = tot
                                                 }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                      i.TotalesInv.cantidad > 0 And
                                                                      i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                      i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                      i.TotalesInv.status = 1)}).ToList

            End Select





            Dim obj As detalleitems
            Dim obEquivalencia As detalleitem_equivalencias
            Dim ListEquivalencia As List(Of detalleitem_equivalencias)
            Dim ListTotalesAlmacen As List(Of totalesAlmacen)

            Dim Listdetalleitems_conexo As List(Of detalleitems_conexo)

            Dim ListLotes As List(Of recursoCostoLote)
            Dim ListEquivalenciaPrecios As List(Of detalleitemequivalencia_precios)
            Dim ListaCatalogoPrecios As List(Of detalleitemequivalencia_catalogos)
            Dim ListaBeneficios As List(Of detalleitemequivalencia_beneficio)
            GetProductosWithInventarioParam = New List(Of detalleitems)

            For Each i In consulta

                ListEquivalencia = New List(Of detalleitem_equivalencias)
                ListTotalesAlmacen = New List(Of totalesAlmacen)
                ListLotes = New List(Of recursoCostoLote)
                Listdetalleitems_conexo = New List(Of detalleitems_conexo)


                For Each ax In i.detalleitems_conexo
                    Listdetalleitems_conexo.Add(New detalleitems_conexo With {
                        .conexo_id = ax.conexo_id,
                        .codigodetalle = ax.codigodetalle,
                        .idProducto = ax.idProducto,
                        .detalle = ax.detalle,
                        .cantidad = ax.cantidad,
                        .equivalencia_id = ax.equivalencia_id,
                        .unidadComercial = ax.unidadComercial,
                        .fraccion = ax.fraccion,
                        .estado = ax.estado,
                        .vigencia = ax.vigencia,
                        .usuarioActualizacion = ax.usuarioActualizacion,
                        .fechaActualizacion = ax.fechaActualizacion
                                                })
                Next

                For Each lt In i.Lotes
                    ListLotes.Add(New recursoCostoLote With
                                  {
                                  .codigoLote = lt.codigoLote,
                                  .nroLote = lt.nroLote,
                                  .idDocumento = lt.idDocumento,
                                  .idproyecto = lt.idproyecto,
                                  .codigoProducto = lt.codigoProducto,
                                  .moneda = lt.moneda,
                                  .detalle = lt.detalle,
                                  .cantidad = lt.cantidad,
                                  .precioUnitarioIva = lt.precioUnitarioIva,
                                  .fechaentrada = lt.fechaentrada,
                                  .fechaProduccion = lt.fechaProduccion,
                                  .fechaVcto = lt.fechaVcto,
                                  .serie = lt.serie,
                                  .sku = lt.sku,
                                  .composicion = lt.composicion,
                                  .productoSustentado = lt.productoSustentado
                                  })
                Next



                For Each inv In i.totalesAlmacen

                    ListTotalesAlmacen.Add(New totalesAlmacen With {
                                           .idMovimiento = inv.TotalesInv.idMovimiento,
                                           .idEmpresa = inv.TotalesInv.idEmpresa,
                                           .idEstablecimiento = inv.TotalesInv.idEstablecimiento,
                                           .idAlmacen = inv.TotalesInv.idAlmacen,
                                           .codigoLote = inv.TotalesInv.codigoLote,
                                           .descripcion = inv.TotalesInv.descripcion,
                                           .idUnidad = inv.TotalesInv.idUnidad,
                                           .unidadMedida = inv.TotalesInv.unidadMedida,
                                           .cantidad = inv.TotalesInv.cantidad,
                                           .cantidad2 = inv.TotalesInv.cantidad2,
                                           .importeSoles = inv.TotalesInv.importeSoles,
                                           .importeDolares = inv.TotalesInv.importeDolares,
                                           .status = inv.TotalesInv.status
                                           })
                Next

                For Each eq In i.detalleitem_equivalencias
                    obEquivalencia = New detalleitem_equivalencias
                    obEquivalencia.equivalencia_id = eq.Equivale.equivalencia_id
                    obEquivalencia.flag = eq.Equivale.flag
                    obEquivalencia.codigodetalle = eq.Equivale.codigodetalle
                    obEquivalencia.detalle = eq.Equivale.detalle
                    obEquivalencia.contenido = eq.Equivale.contenido
                    obEquivalencia.contenido_neto = eq.Equivale.contenido_neto
                    obEquivalencia.unidadComercial = eq.Equivale.unidadComercial
                    obEquivalencia.fraccionUnidad = eq.Equivale.fraccionUnidad
                    obEquivalencia.estado = eq.Equivale.estado


                    ListaBeneficios = New List(Of detalleitemequivalencia_beneficio)
                    For Each ben In eq.detalleitemequivalencia_beneficio
                        ListaBeneficios.Add(New detalleitemequivalencia_beneficio With
                                            {
                                            .beneficio_id = ben.beneficio_id,
                                            .codigodetalle = ben.codigodetalle,
                                            .modalidadVenta = ben.modalidadVenta,
                                            .aplica = ben.aplica,
                                            .equivalencia_id = ben.equivalencia_id,
                                            .beneficio_detalle = ben.beneficio_detalle,
                                            .tipobeneficio = ben.tipobeneficio,
                                            .tipoafectacion = ben.tipoafectacion,
                                            .valor_evaluado = ben.valor_evaluado,
                                            .valor_conversion = ben.valor_conversion,
                                            .valor_beneficio = ben.valor_beneficio,
                                            .lote_id = ben.lote_id,
                                            .estado = ben.estado,
                                            .usuarioActualizacion = ben.usuarioActualizacion,
                                            .fechaActualizacion = ben.fechaActualizacion
                                            })
                    Next


                    ListaCatalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
                    For Each cat In eq.detalleitemequivalencia_catalogos
                        ListEquivalenciaPrecios = New List(Of detalleitemequivalencia_precios)
                        For Each prec In cat.Precios
                            ListEquivalenciaPrecios.Add(New detalleitemequivalencia_precios With
                                                        {
                                                        .precio_id = prec.precio_id,
                                                        .codigodetalle = prec.codigodetalle,
                                                        .equivalencia_id = prec.equivalencia_id,
                                                        .idCatalogo = prec.idCatalogo,
                                                        .rango_inicio = prec.rango_inicio,
                                                        .rango_final = prec.rango_final,
                                                        .precioCredito = prec.precioCredito,
                                                        .precioCreditoUSD = prec.precioCreditoUSD,
                                                        .precio = prec.precio,
                                                        .precioUSD = prec.precioUSD,
                                                        .precioCode = prec.precioCode,
                                                        .estado = prec.estado
                                                        })
                        Next

                        ListaCatalogoPrecios.Add(New detalleitemequivalencia_catalogos With {
                                                     .idCatalogo = cat.Cat.idCatalogo,
                                                     .codigodetalle = cat.Cat.codigodetalle,
                                                     .equivalencia_id = cat.Cat.equivalencia_id,
                                                     .nombre_corto = cat.Cat.nombre_corto,
                                                     .nombre_largo = cat.Cat.nombre_largo,
                                                     .estado = cat.Cat.estado,
                                                     .predeterminado = cat.Cat.predeterminado,
                                                     .detalleitemequivalencia_precios = ListEquivalenciaPrecios
                                                 })


                    Next
                    obEquivalencia.detalleitemequivalencia_catalogos = ListaCatalogoPrecios
                    obEquivalencia.detalleitemequivalencia_beneficio = ListaBeneficios
                    ListEquivalencia.Add(obEquivalencia)
                Next
                Dim category As item = Nothing
                If i.category IsNot Nothing Then
                    category = New item With
                               {
                               .idItem = i.category.idItem,
                               .idPadre = i.category.idPadre,
                               .descripcion = i.category.descripcion,
                               .tipo = i.category.tipo,
                               .preciocompratipo = i.category.preciocompratipo,
                               .precioCompra = i.category.precioCompra,
                               .firstpercent = i.category.firstpercent,
                               .beforepercent = i.category.beforepercent
                               }
                End If
                obj = New detalleitems With
                    {
                    .item = If(i.category IsNot Nothing, category, Nothing),
                    .codigodetalle = i.detalleitems.codigodetalle,
                    .idItem = i.detalleitems.idItem,
                    .descripcionItem = i.detalleitems.descripcionItem,
                    .unidad1 = i.detalleitems.unidad1,
                    .tipoExistencia = i.detalleitems.tipoExistencia,
                    .unidad2 = i.detalleitems.unidad2,
                    .codigo = i.detalleitems.codigo,
                    .origenProducto = i.detalleitems.origenProducto,
                    .composicion = i.detalleitems.composicion,
                    .AfectoStock = i.detalleitems.AfectoStock,
                    .detalleitem_equivalencias = ListEquivalencia,
                    .detalleitems_conexo = Listdetalleitems_conexo,
                    .totalesAlmacen = ListTotalesAlmacen,
                    .recursoCostoLote = ListLotes,
                    .otroImpuesto = i.detalleitems.otroImpuesto,
                    .tipoOtroImpuesto = i.detalleitems.tipoOtroImpuesto,
                    .igv = i.detalleitems.igv,
                    .precioCompra = i.detalleitems.precioCompra,
                    .preciocompratipo = i.detalleitems.preciocompratipo,
                    .firstpercent = i.detalleitems.firstpercent,
                    .beforepercent = i.detalleitems.beforepercent
                }
                GetProductosWithInventarioParam.Add(obj)
            Next

            Return GetProductosWithInventarioParam

        Catch ex As Exception

        End Try

    End Function
    Public Sub EditarValoresRentabilidadCompra(item As detalleitems)
        Using ts As New TransactionScope

            Dim prod = HeliosData.detalleitems.Where(Function(o) o.codigodetalle = item.codigodetalle).SingleOrDefault

            prod.precioCompra = item.precioCompra
            prod.preciocompratipo = item.preciocompratipo
            prod.firstpercent = item.firstpercent
            prod.beforepercent = item.beforepercent
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetProductosWithEquivalenciasEstablecimiento(be As detalleitems) As List(Of detalleitems)
        Dim consulta = HeliosData.detalleitems.Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))).Where(Function(d) d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento).ToList

        'Dim consulta = HeliosData.detalleitems.Include(Function(o) o.detalleitem_equivalencias.Select(Function(y) y.detalleitemequivalencia_precios)).Where(Function(d) d.descripcionItem.StartsWith(be.descripcionItem)).ToList


        Dim obj As detalleitems
        Dim obEquivalencia As detalleitem_equivalencias
        Dim ListEquivalencia As List(Of detalleitem_equivalencias)
        Dim ListEquivalenciaPrecios As List(Of detalleitemequivalencia_precios)
        Dim ListaCatalogoPrecios As List(Of detalleitemequivalencia_catalogos)


        GetProductosWithEquivalenciasEstablecimiento = New List(Of detalleitems)

        For Each i In consulta

            ListEquivalencia = New List(Of detalleitem_equivalencias)
            For Each eq In i.detalleitem_equivalencias
                obEquivalencia = New detalleitem_equivalencias
                obEquivalencia.detalle = eq.detalle
                obEquivalencia.unidadComercial = eq.unidadComercial
                obEquivalencia.contenido = eq.contenido
                obEquivalencia.equivalencia_id = eq.equivalencia_id
                obEquivalencia.fraccionUnidad = eq.fraccionUnidad
                obEquivalencia.contenido_neto = eq.contenido_neto
                obEquivalencia.estado = eq.estado
                obEquivalencia.codigo = eq.codigo


                ListaCatalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
                For Each cat In eq.detalleitemequivalencia_catalogos
                    ListEquivalenciaPrecios = New List(Of detalleitemequivalencia_precios)
                    For Each prec In cat.detalleitemequivalencia_precios
                        ListEquivalenciaPrecios.Add(New detalleitemequivalencia_precios With
                                                    {
                                                    .rango_inicio = prec.rango_inicio,
                                                    .rango_final = prec.rango_final,
                                                    .precioCredito = prec.precioCredito,
                                                    .precio = prec.precio,
                                                    .precio_id = prec.precio_id,
                                                    .precioCode = prec.precioCode,
                                                    .estado = prec.estado
                                                    })
                    Next


                    ListaCatalogoPrecios.Add(New detalleitemequivalencia_catalogos With {
                                             .idCatalogo = cat.idCatalogo,
                                             .codigodetalle = cat.codigodetalle,
                                             .equivalencia_id = cat.equivalencia_id,
                                             .nombre_corto = cat.nombre_corto,
                                             .nombre_largo = cat.nombre_largo,
                                             .estado = cat.estado,
                                             .predeterminado = cat.predeterminado,
                                             .detalleitemequivalencia_precios = ListEquivalenciaPrecios
                                             })


                Next
                obEquivalencia.detalleitemequivalencia_catalogos = ListaCatalogoPrecios
                ListEquivalencia.Add(obEquivalencia)
            Next

            obj = New detalleitems With
            {
            .codigodetalle = i.codigodetalle,
            .idItem = i.idItem,
            .descripcionItem = i.descripcionItem,
            .unidad1 = i.unidad1,
            .tipoExistencia = i.tipoExistencia,
            .unidad2 = i.unidad2,
            .codigo = i.codigo,
            .origenProducto = i.origenProducto,
            .composicion = i.composicion,
            .Filtros = i.Filtros,
            .detalleitem_equivalencias = ListEquivalencia
            }
            GetProductosWithEquivalenciasEstablecimiento.Add(obj)
        Next
    End Function


    Public Function GetProductosWithInventarioTipoAlmacen(be As detalleitems) As List(Of detalleitems)

        Dim consulta As Object

        Select Case be.typeConsult
            Case "NOMBRE" 'ESTE ES EL QUE HABIA POR DEFAULT
                consulta = HeliosData.detalleitems _
            .Include(Function(cat) cat.item) _
            .Include(Function(lot) lot.recursoCostoLote) _
            .Include(Function(i) i.totalesAlmacen) _
            .Include(Function(ax) ax.detalleitems_conexo) _
            .Include(Function(o) o.detalleitem_equivalencias.Select(
            Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                 .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" And Not d.tipoItem = "DET" And
                                 d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                 .Select(Function(o) New With
                                 {
                                 .detalleitems = o,
                                 .category = o.item,
                                 .detalleitems_conexo = o.detalleitems_conexo,
                                 .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                 .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                            {
                                            .Equivale = e,
                                            .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                            .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                {
                                                                                                                                .Cat = p,
                                                                                                                                .Precios = p.detalleitemequivalencia_precios
                                                                                                                                })
                                            }),
                                .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                               New With {
                                               .almacen = al,
                                               .TotalesInv = tot
                                               }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                    i.TotalesInv.idAlmacen = be.idAlmacen And
                                                                    i.TotalesInv.cantidad > 0 And
                                                                    i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                    i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                    i.TotalesInv.status = 1)}).ToList
            Case "COLOR"

                consulta = HeliosData.detalleitems _
            .Include(Function(cat) cat.item) _
            .Include(Function(lot) lot.recursoCostoLote) _
            .Include(Function(i) i.totalesAlmacen) _
            .Include(Function(ax) ax.detalleitems_conexo) _
            .Include(Function(o) o.detalleitem_equivalencias.Select(
            Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                 .Where(Function(d) d.color.Contains(be.color) And d.estado = "A" And Not d.tipoItem = "DET" And
                                 d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                 .Select(Function(o) New With
                                 {
                                 .detalleitems = o,
                                 .category = o.item,
                                 .detalleitems_conexo = o.detalleitems_conexo,
                                 .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                 .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                            {
                                            .Equivale = e,
                                            .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                            .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                {
                                                                                                                                .Cat = p,
                                                                                                                                .Precios = p.detalleitemequivalencia_precios
                                                                                                                                })
                                            }),
                                .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                               New With {
                                               .almacen = al,
                                               .TotalesInv = tot
                                               }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                    i.TotalesInv.idAlmacen = be.idAlmacen And
                                                                    i.TotalesInv.cantidad > 0 And
                                                                    i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                    i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                    i.TotalesInv.status = 1)}).ToList

            Case "TALLA"

                consulta = HeliosData.detalleitems _
           .Include(Function(cat) cat.item) _
           .Include(Function(lot) lot.recursoCostoLote) _
           .Include(Function(i) i.totalesAlmacen) _
           .Include(Function(ax) ax.detalleitems_conexo) _
           .Include(Function(o) o.detalleitem_equivalencias.Select(
           Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                .Where(Function(d) d.talla.Contains(be.talla) And d.estado = "A" And Not d.tipoItem = "DET" And
                                 d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                .Select(Function(o) New With
                                {
                                .detalleitems = o,
                                .category = o.item,
                                .detalleitems_conexo = o.detalleitems_conexo,
                                .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                           {
                                           .Equivale = e,
                                           .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                           .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                               {
                                                                                                                               .Cat = p,
                                                                                                                               .Precios = p.detalleitemequivalencia_precios
                                                                                                                               })
                                           }),
                               .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                              New With {
                                              .almacen = al,
                                              .TotalesInv = tot
                                              }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                    i.TotalesInv.idAlmacen = be.idAlmacen And
                                                                    i.TotalesInv.cantidad > 0 And
                                                                    i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                    i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                    i.TotalesInv.status = 1)}).ToList

            Case "ADICIONAL1"

                consulta = HeliosData.detalleitems _
           .Include(Function(cat) cat.item) _
           .Include(Function(lot) lot.recursoCostoLote) _
           .Include(Function(i) i.totalesAlmacen) _
           .Include(Function(ax) ax.detalleitems_conexo) _
           .Include(Function(o) o.detalleitem_equivalencias.Select(
           Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                .Where(Function(d) d.electricidad.Contains(be.electricidad) And d.estado = "A" And Not d.tipoItem = "DET" And
                                 d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                .Select(Function(o) New With
                                {
                                .detalleitems = o,
                                .category = o.item,
                                .detalleitems_conexo = o.detalleitems_conexo,
                                .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                           {
                                           .Equivale = e,
                                           .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                           .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                               {
                                                                                                                               .Cat = p,
                                                                                                                               .Precios = p.detalleitemequivalencia_precios
                                                                                                                               })
                                           }),
                               .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                              New With {
                                              .almacen = al,
                                              .TotalesInv = tot
                                              }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                    i.TotalesInv.idAlmacen = be.idAlmacen And
                                                                    i.TotalesInv.cantidad > 0 And
                                                                    i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                    i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                    i.TotalesInv.status = 1)}).ToList

            Case "ADICIONAL2"

                consulta = HeliosData.detalleitems _
           .Include(Function(cat) cat.item) _
           .Include(Function(lot) lot.recursoCostoLote) _
           .Include(Function(i) i.totalesAlmacen) _
           .Include(Function(ax) ax.detalleitems_conexo) _
           .Include(Function(o) o.detalleitem_equivalencias.Select(
           Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                .Where(Function(d) d.transmision.Contains(be.transmision) And d.estado = "A" And Not d.tipoItem = "DET" And
                                 d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                .Select(Function(o) New With
                                {
                                .detalleitems = o,
                                .category = o.item,
                                .detalleitems_conexo = o.detalleitems_conexo,
                                .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                           {
                                           .Equivale = e,
                                           .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                           .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                               {
                                                                                                                               .Cat = p,
                                                                                                                               .Precios = p.detalleitemequivalencia_precios
                                                                                                                               })
                                           }),
                               .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                              New With {
                                              .almacen = al,
                                              .TotalesInv = tot
                                              }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                    i.TotalesInv.idAlmacen = be.idAlmacen And
                                                                    i.TotalesInv.cantidad > 0 And
                                                                    i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                    i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                    i.TotalesInv.status = 1)}).ToList

            Case "PRESENTACION/MODELO"

                consulta = HeliosData.detalleitems _
           .Include(Function(cat) cat.item) _
           .Include(Function(lot) lot.recursoCostoLote) _
           .Include(Function(i) i.totalesAlmacen) _
           .Include(Function(ax) ax.detalleitems_conexo) _
           .Include(Function(o) o.detalleitem_equivalencias.Select(
           Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                .Where(Function(d) d.presentacion.Contains(be.presentacion) And d.estado = "A" And Not d.tipoItem = "DET" And
                                 d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                .Select(Function(o) New With
                                {
                                .detalleitems = o,
                                .category = o.item,
                                .detalleitems_conexo = o.detalleitems_conexo,
                                .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                           {
                                           .Equivale = e,
                                           .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                           .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                               {
                                                                                                                               .Cat = p,
                                                                                                                               .Precios = p.detalleitemequivalencia_precios
                                                                                                                               })
                                           }),
                               .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                              New With {
                                              .almacen = al,
                                              .TotalesInv = tot
                                              }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                    i.TotalesInv.idAlmacen = be.idAlmacen And
                                                                    i.TotalesInv.cantidad > 0 And
                                                                    i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                    i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                    i.TotalesInv.status = 1)}).ToList


            Case "CATEGORIA"

                consulta = HeliosData.detalleitems _
           .Include(Function(cat) cat.item) _
           .Include(Function(lot) lot.recursoCostoLote) _
           .Include(Function(i) i.totalesAlmacen) _
           .Include(Function(ax) ax.detalleitems_conexo) _
           .Include(Function(o) o.detalleitem_equivalencias.Select(
           Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                .Where(Function(d) d.idItem = be.idItem And d.estado = "A" And Not d.tipoItem = "DET" And
                                 d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                .Select(Function(o) New With
                                {
                                .detalleitems = o,
                                .category = o.item,
                                .detalleitems_conexo = o.detalleitems_conexo,
                                .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                           {
                                           .Equivale = e,
                                           .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                           .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                               {
                                                                                                                               .Cat = p,
                                                                                                                               .Precios = p.detalleitemequivalencia_precios
                                                                                                                               })
                                           }),
                               .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                              New With {
                                              .almacen = al,
                                              .TotalesInv = tot
                                              }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                    i.TotalesInv.idAlmacen = be.idAlmacen And
                                                                    i.TotalesInv.cantidad > 0 And
                                                                    i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                    i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                    i.TotalesInv.status = 1)}).ToList

            Case "SUBCATEGORIA"


                consulta = HeliosData.detalleitems _
          .Include(Function(cat) cat.item) _
          .Include(Function(lot) lot.recursoCostoLote) _
          .Include(Function(i) i.totalesAlmacen) _
          .Include(Function(ax) ax.detalleitems_conexo) _
          .Include(Function(o) o.detalleitem_equivalencias.Select(
          Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                               .Where(Function(d) d.unidad2 = be.unidad2 And d.estado = "A" And Not d.tipoItem = "DET" And
                                 d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                               .Select(Function(o) New With
                               {
                               .detalleitems = o,
                               .category = o.item,
                               .detalleitems_conexo = o.detalleitems_conexo,
                               .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                               .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                          {
                                          .Equivale = e,
                                          .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                          .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                              {
                                                                                                                              .Cat = p,
                                                                                                                              .Precios = p.detalleitemequivalencia_precios
                                                                                                                              })
                                          }),
                              .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                             New With {
                                             .almacen = al,
                                             .TotalesInv = tot
                                             }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                    i.TotalesInv.idAlmacen = be.idAlmacen And
                                                                    i.TotalesInv.cantidad > 0 And
                                                                    i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                    i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                    i.TotalesInv.status = 1)}).ToList

            Case "MARCA"


                consulta = HeliosData.detalleitems _
          .Include(Function(cat) cat.item) _
          .Include(Function(lot) lot.recursoCostoLote) _
          .Include(Function(i) i.totalesAlmacen) _
          .Include(Function(ax) ax.detalleitems_conexo) _
          .Include(Function(o) o.detalleitem_equivalencias.Select(
          Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                               .Where(Function(d) d.marcaRef = be.marcaRef And d.estado = "A" And Not d.tipoItem = "DET" And
                                 d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                               .Select(Function(o) New With
                               {
                               .detalleitems = o,
                               .category = o.item,
                               .detalleitems_conexo = o.detalleitems_conexo,
                               .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                               .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                          {
                                          .Equivale = e,
                                          .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                          .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                              {
                                                                                                                              .Cat = p,
                                                                                                                              .Precios = p.detalleitemequivalencia_precios
                                                                                                                              })
                                          }),
                              .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                             New With {
                                             .almacen = al,
                                             .TotalesInv = tot
                                             }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                    i.TotalesInv.idAlmacen = be.idAlmacen And
                                                                    i.TotalesInv.cantidad > 0 And
                                                                    i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                    i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                    i.TotalesInv.status = 1)}).ToList

            Case Else

                consulta = HeliosData.detalleitems _
            .Include(Function(cat) cat.item) _
            .Include(Function(lot) lot.recursoCostoLote) _
            .Include(Function(i) i.totalesAlmacen) _
            .Include(Function(ax) ax.detalleitems_conexo) _
            .Include(Function(o) o.detalleitem_equivalencias.Select(
            Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                 .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" And Not d.tipoItem = "DET" And
                                 d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                 .Select(Function(o) New With
                                 {
                                 .detalleitems = o,
                                 .category = o.item,
                                 .detalleitems_conexo = o.detalleitems_conexo,
                                 .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                 .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                            {
                                            .Equivale = e,
                                            .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                            .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                {
                                                                                                                                .Cat = p,
                                                                                                                                .Precios = p.detalleitemequivalencia_precios
                                                                                                                                })
                                            }),
                                .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                               New With {
                                               .almacen = al,
                                               .TotalesInv = tot
                                               }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                    i.TotalesInv.idAlmacen = be.idAlmacen And
                                                                    i.TotalesInv.cantidad > 0 And
                                                                    i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                    i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                    i.TotalesInv.status = 1)}).ToList


        End Select



        'StatusArticulo.Activo

        '      Dim c = HeliosData.totalesAlmacen.Join(HeliosData.detalleitems, Function(post) post.idItem, Function(prod) prod.codigodetalle, Function(post, prod) _
        '                                       New With
        '                                       {
        '                                       .post = post,
        '                                       .prod = prod
        '                                       }).ToList



        '.Where(Function(d) d.descripcionItem.Contains(be.descripcionItem)).ToList


        'Dim consulta = HeliosData.detalleitems.Include(Function(o) o.detalleitem_equivalencias.Select(Function(y) y.detalleitemequivalencia_precios)).Where(Function(d) d.descripcionItem.StartsWith(be.descripcionItem)).ToList


        Dim obj As detalleitems
        Dim obEquivalencia As detalleitem_equivalencias
        Dim ListEquivalencia As List(Of detalleitem_equivalencias)
        Dim ListTotalesAlmacen As List(Of totalesAlmacen)

        Dim Listdetalleitems_conexo As List(Of detalleitems_conexo)

        Dim ListLotes As List(Of recursoCostoLote)
        Dim ListEquivalenciaPrecios As List(Of detalleitemequivalencia_precios)
        Dim ListaCatalogoPrecios As List(Of detalleitemequivalencia_catalogos)
        Dim ListaBeneficios As List(Of detalleitemequivalencia_beneficio)
        GetProductosWithInventarioTipoAlmacen = New List(Of detalleitems)

        For Each i In consulta

            ListEquivalencia = New List(Of detalleitem_equivalencias)
            ListTotalesAlmacen = New List(Of totalesAlmacen)
            ListLotes = New List(Of recursoCostoLote)
            Listdetalleitems_conexo = New List(Of detalleitems_conexo)


            For Each ax In i.detalleitems_conexo
                Listdetalleitems_conexo.Add(New detalleitems_conexo With {
                    .conexo_id = ax.conexo_id,
                    .codigodetalle = ax.codigodetalle,
                    .idProducto = ax.idProducto,
                    .detalle = ax.detalle,
                    .cantidad = ax.cantidad,
                    .equivalencia_id = ax.equivalencia_id,
                    .unidadComercial = ax.unidadComercial,
                    .fraccion = ax.fraccion,
                    .estado = ax.estado,
                    .vigencia = ax.vigencia,
                    .usuarioActualizacion = ax.usuarioActualizacion,
                    .fechaActualizacion = ax.fechaActualizacion
                                            })
            Next

            For Each lt In i.Lotes
                ListLotes.Add(New recursoCostoLote With
                              {
                              .codigoLote = lt.codigoLote,
                              .nroLote = lt.nroLote,
                              .idDocumento = lt.idDocumento,
                              .idproyecto = lt.idproyecto,
                              .codigoProducto = lt.codigoProducto,
                              .moneda = lt.moneda,
                              .detalle = lt.detalle,
                              .cantidad = lt.cantidad,
                              .precioUnitarioIva = lt.precioUnitarioIva,
                              .fechaentrada = lt.fechaentrada,
                              .fechaProduccion = lt.fechaProduccion,
                              .fechaVcto = lt.fechaVcto,
                              .serie = lt.serie,
                              .sku = lt.sku,
                              .composicion = lt.composicion,
                              .productoSustentado = lt.productoSustentado
                              })
            Next



            For Each inv In i.totalesAlmacen

                ListTotalesAlmacen.Add(New totalesAlmacen With {
                                       .idMovimiento = inv.TotalesInv.idMovimiento,
                                       .idEmpresa = inv.TotalesInv.idEmpresa,
                                       .idEstablecimiento = inv.TotalesInv.idEstablecimiento,
                                       .idAlmacen = inv.TotalesInv.idAlmacen,
                                       .codigoLote = inv.TotalesInv.codigoLote,
                                       .descripcion = inv.TotalesInv.descripcion,
                                       .idUnidad = inv.TotalesInv.idUnidad,
                                       .unidadMedida = inv.TotalesInv.unidadMedida,
                                       .cantidad = inv.TotalesInv.cantidad,
                                       .cantidad2 = inv.TotalesInv.cantidad2,
                                       .importeSoles = inv.TotalesInv.importeSoles,
                                       .importeDolares = inv.TotalesInv.importeDolares,
                                       .status = inv.TotalesInv.status
                                       })
            Next

            For Each eq In i.detalleitem_equivalencias
                obEquivalencia = New detalleitem_equivalencias
                obEquivalencia.equivalencia_id = eq.Equivale.equivalencia_id
                obEquivalencia.flag = eq.Equivale.flag
                obEquivalencia.codigodetalle = eq.Equivale.codigodetalle
                obEquivalencia.detalle = eq.Equivale.detalle
                obEquivalencia.contenido = eq.Equivale.contenido
                obEquivalencia.contenido_neto = eq.Equivale.contenido_neto
                obEquivalencia.unidadComercial = eq.Equivale.unidadComercial
                obEquivalencia.fraccionUnidad = eq.Equivale.fraccionUnidad
                obEquivalencia.estado = eq.Equivale.estado


                ListaBeneficios = New List(Of detalleitemequivalencia_beneficio)
                For Each ben In eq.detalleitemequivalencia_beneficio
                    ListaBeneficios.Add(New detalleitemequivalencia_beneficio With
                                        {
                                        .beneficio_id = ben.beneficio_id,
                                        .codigodetalle = ben.codigodetalle,
                                        .modalidadVenta = ben.modalidadVenta,
                                        .aplica = ben.aplica,
                                        .equivalencia_id = ben.equivalencia_id,
                                        .beneficio_detalle = ben.beneficio_detalle,
                                        .tipobeneficio = ben.tipobeneficio,
                                        .tipoafectacion = ben.tipoafectacion,
                                        .valor_evaluado = ben.valor_evaluado,
                                        .valor_conversion = ben.valor_conversion,
                                        .valor_beneficio = ben.valor_beneficio,
                                        .lote_id = ben.lote_id,
                                        .estado = ben.estado,
                                        .usuarioActualizacion = ben.usuarioActualizacion,
                                        .fechaActualizacion = ben.fechaActualizacion
                                        })
                Next


                ListaCatalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
                For Each cat In eq.detalleitemequivalencia_catalogos
                    ListEquivalenciaPrecios = New List(Of detalleitemequivalencia_precios)
                    For Each prec In cat.Precios
                        ListEquivalenciaPrecios.Add(New detalleitemequivalencia_precios With
                                                    {
                                                    .precio_id = prec.precio_id,
                                                    .codigodetalle = prec.codigodetalle,
                                                    .equivalencia_id = prec.equivalencia_id,
                                                    .idCatalogo = prec.idCatalogo,
                                                    .rango_inicio = prec.rango_inicio,
                                                    .rango_final = prec.rango_final,
                                                    .precioCredito = prec.precioCredito,
                                                    .precioCreditoUSD = prec.precioCreditoUSD,
                                                    .precio = prec.precio,
                                                    .precioUSD = prec.precioUSD,
                                                    .precioCode = prec.precioCode,
                                                    .estado = prec.estado
                                                    })
                    Next

                    ListaCatalogoPrecios.Add(New detalleitemequivalencia_catalogos With {
                                                 .idCatalogo = cat.Cat.idCatalogo,
                                                 .codigodetalle = cat.Cat.codigodetalle,
                                                 .equivalencia_id = cat.Cat.equivalencia_id,
                                                 .nombre_corto = cat.Cat.nombre_corto,
                                                 .nombre_largo = cat.Cat.nombre_largo,
                                                 .estado = cat.Cat.estado,
                                                 .predeterminado = cat.Cat.predeterminado,
                                                 .detalleitemequivalencia_precios = ListEquivalenciaPrecios
                                             })


                Next
                obEquivalencia.detalleitemequivalencia_catalogos = ListaCatalogoPrecios
                obEquivalencia.detalleitemequivalencia_beneficio = ListaBeneficios
                ListEquivalencia.Add(obEquivalencia)
            Next
            Dim category As item = Nothing
            If i.category IsNot Nothing Then
                category = New item With
                           {
                           .idItem = i.category.idItem,
                           .idPadre = i.category.idPadre,
                           .descripcion = i.category.descripcion,
                           .tipo = i.category.tipo,
                           .preciocompratipo = i.category.preciocompratipo,
                           .precioCompra = i.category.precioCompra,
                           .firstpercent = i.category.firstpercent,
                           .beforepercent = i.category.beforepercent
                           }
            End If
            obj = New detalleitems With
                {
                .item = If(i.category IsNot Nothing, category, Nothing),
                .codigodetalle = i.detalleitems.codigodetalle,
                .idItem = i.detalleitems.idItem,
                .descripcionItem = i.detalleitems.descripcionItem,
                .unidad1 = i.detalleitems.unidad1,
                .tipoExistencia = i.detalleitems.tipoExistencia,
                .unidad2 = i.detalleitems.unidad2,
                .codigo = i.detalleitems.codigo,
                .origenProducto = i.detalleitems.origenProducto,
                .composicion = i.detalleitems.composicion,
                .AfectoStock = i.detalleitems.AfectoStock,
                .detalleitem_equivalencias = ListEquivalencia,
                .detalleitems_conexo = Listdetalleitems_conexo,
                .totalesAlmacen = ListTotalesAlmacen,
                .recursoCostoLote = ListLotes,
                .otroImpuesto = i.detalleitems.otroImpuesto,
                .tipoOtroImpuesto = i.detalleitems.tipoOtroImpuesto,
                .igv = i.detalleitems.igv,
                .precioCompra = i.detalleitems.precioCompra,
                .preciocompratipo = i.detalleitems.preciocompratipo,
                .firstpercent = i.detalleitems.firstpercent,
                .beforepercent = i.detalleitems.beforepercent,
                .idAlmacen = be.idAlmacen
            }
            GetProductosWithInventarioTipoAlmacen.Add(obj)
        Next

        Return GetProductosWithInventarioTipoAlmacen

    End Function

    Public Function GetProductosWithInventario(be As detalleitems) As List(Of detalleitems)
        'Include("detalleitem_equivalencias").Include("detalleitemequivalencia_precios")

        'Dim results = warmCountries.Join(europeanCountries, Function(warm) warm, Function(european) european, Function(warm, european) warm)


        'INNER JOIN
        'Dim c = HeliosData.totalesAlmacen.Join(HeliosData.detalleitems, Function(post) post.idItem, Function(prod) prod.codigodetalle, Function(post, prod) _
        '                                       New With
        '                                       {
        '                                       .post = post,
        '                                       .prod = prod
        '                                       }).ToList

        'LAMBDA MULTIPLE INLCUIDE
        'Dim result = HeliosData.detalleitems _
        '    .Include(Function(o) o.detalleitem_equivalencias _
        '    .Select(Function(y) y.detalleitemequivalencia_precios)) _
        '    .GroupJoin(HeliosData.totalesAlmacen, Function(lang) lang.codigodetalle, Function(pers) pers.idItem,
        '         Function(lang, ps) New With
        '         {
        '         .CodigoDetalle = lang.codigodetalle,
        '         .DescripcionProducto = lang.descripcionItem,
        '         .Codigo = lang.codigo,
        '         .unidad = lang.unidad1,
        '         .item = lang.item,
        '         .Stock = CType(ps.Sum(Function(p) p.cantidad), Decimal?),
        '         .Persons = ps
        '             }
        '         ).ToList
        Dim consulta As Object

        Select Case be.typeConsult
            Case "NOMBRE" 'ESTE ES EL QUE HABIA POR DEFAULT
                consulta = HeliosData.detalleitems _
            .Include(Function(cat) cat.item) _
            .Include(Function(lot) lot.recursoCostoLote) _
            .Include(Function(i) i.totalesAlmacen) _
            .Include(Function(ax) ax.detalleitems_conexo) _
            .Include(Function(o) o.detalleitem_equivalencias.Select(
            Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                 .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" And Not d.tipoItem = "DET" And
                                 d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                 .Select(Function(o) New With
                                 {
                                 .detalleitems = o,
                                 .category = o.item,
                                 .detalleitems_conexo = o.detalleitems_conexo,
                                 .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                 .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                            {
                                            .Equivale = e,
                                            .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                            .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                {
                                                                                                                                .Cat = p,
                                                                                                                                .Precios = p.detalleitemequivalencia_precios
                                                                                                                                })
                                            }),
                                .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                               New With {
                                               .almacen = al,
                                               .TotalesInv = tot
                                               }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                    i.TotalesInv.cantidad > 0 And
                                                                    i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                    i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                    i.TotalesInv.status = 1)}).ToList
            Case "COLOR"

                consulta = HeliosData.detalleitems _
            .Include(Function(cat) cat.item) _
            .Include(Function(lot) lot.recursoCostoLote) _
            .Include(Function(i) i.totalesAlmacen) _
            .Include(Function(ax) ax.detalleitems_conexo) _
            .Include(Function(o) o.detalleitem_equivalencias.Select(
            Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                 .Where(Function(d) d.color.Contains(be.color) And d.estado = "A" And Not d.tipoItem = "DET" And
                                 d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                 .Select(Function(o) New With
                                 {
                                 .detalleitems = o,
                                 .category = o.item,
                                 .detalleitems_conexo = o.detalleitems_conexo,
                                 .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                 .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                            {
                                            .Equivale = e,
                                            .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                            .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                {
                                                                                                                                .Cat = p,
                                                                                                                                .Precios = p.detalleitemequivalencia_precios
                                                                                                                                })
                                            }),
                                .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                               New With {
                                               .almacen = al,
                                               .TotalesInv = tot
                                               }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                    i.TotalesInv.cantidad > 0 And
                                                                    i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                    i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                    i.TotalesInv.status = 1)}).ToList

            Case "TALLA"

                consulta = HeliosData.detalleitems _
           .Include(Function(cat) cat.item) _
           .Include(Function(lot) lot.recursoCostoLote) _
           .Include(Function(i) i.totalesAlmacen) _
           .Include(Function(ax) ax.detalleitems_conexo) _
           .Include(Function(o) o.detalleitem_equivalencias.Select(
           Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                .Where(Function(d) d.talla.Contains(be.talla) And d.estado = "A" And Not d.tipoItem = "DET" And
                                 d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                .Select(Function(o) New With
                                {
                                .detalleitems = o,
                                .category = o.item,
                                .detalleitems_conexo = o.detalleitems_conexo,
                                .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                           {
                                           .Equivale = e,
                                           .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                           .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                               {
                                                                                                                               .Cat = p,
                                                                                                                               .Precios = p.detalleitemequivalencia_precios
                                                                                                                               })
                                           }),
                               .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                              New With {
                                              .almacen = al,
                                              .TotalesInv = tot
                                              }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                   i.TotalesInv.cantidad > 0 And
                                                                   i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                   i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                   i.TotalesInv.status = 1)}).ToList

            Case "ADICIONAL1"

                consulta = HeliosData.detalleitems _
           .Include(Function(cat) cat.item) _
           .Include(Function(lot) lot.recursoCostoLote) _
           .Include(Function(i) i.totalesAlmacen) _
           .Include(Function(ax) ax.detalleitems_conexo) _
           .Include(Function(o) o.detalleitem_equivalencias.Select(
           Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                .Where(Function(d) d.electricidad.Contains(be.electricidad) And d.estado = "A" And Not d.tipoItem = "DET" And
                                 d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                .Select(Function(o) New With
                                {
                                .detalleitems = o,
                                .category = o.item,
                                .detalleitems_conexo = o.detalleitems_conexo,
                                .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                           {
                                           .Equivale = e,
                                           .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                           .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                               {
                                                                                                                               .Cat = p,
                                                                                                                               .Precios = p.detalleitemequivalencia_precios
                                                                                                                               })
                                           }),
                               .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                              New With {
                                              .almacen = al,
                                              .TotalesInv = tot
                                              }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                   i.TotalesInv.cantidad > 0 And
                                                                   i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                   i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                   i.TotalesInv.status = 1)}).ToList

            Case "ADICIONAL2"

                consulta = HeliosData.detalleitems _
           .Include(Function(cat) cat.item) _
           .Include(Function(lot) lot.recursoCostoLote) _
           .Include(Function(i) i.totalesAlmacen) _
           .Include(Function(ax) ax.detalleitems_conexo) _
           .Include(Function(o) o.detalleitem_equivalencias.Select(
           Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                .Where(Function(d) d.transmision.Contains(be.transmision) And d.estado = "A" And Not d.tipoItem = "DET" And
                                 d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                .Select(Function(o) New With
                                {
                                .detalleitems = o,
                                .category = o.item,
                                .detalleitems_conexo = o.detalleitems_conexo,
                                .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                           {
                                           .Equivale = e,
                                           .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                           .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                               {
                                                                                                                               .Cat = p,
                                                                                                                               .Precios = p.detalleitemequivalencia_precios
                                                                                                                               })
                                           }),
                               .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                              New With {
                                              .almacen = al,
                                              .TotalesInv = tot
                                              }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                   i.TotalesInv.cantidad > 0 And
                                                                   i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                   i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                   i.TotalesInv.status = 1)}).ToList

            Case "PRESENTACION/MODELO"

                consulta = HeliosData.detalleitems _
           .Include(Function(cat) cat.item) _
           .Include(Function(lot) lot.recursoCostoLote) _
           .Include(Function(i) i.totalesAlmacen) _
           .Include(Function(ax) ax.detalleitems_conexo) _
           .Include(Function(o) o.detalleitem_equivalencias.Select(
           Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                .Where(Function(d) d.presentacion.Contains(be.presentacion) And d.estado = "A" And Not d.tipoItem = "DET" And
                                 d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                .Select(Function(o) New With
                                {
                                .detalleitems = o,
                                .category = o.item,
                                .detalleitems_conexo = o.detalleitems_conexo,
                                .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                           {
                                           .Equivale = e,
                                           .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                           .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                               {
                                                                                                                               .Cat = p,
                                                                                                                               .Precios = p.detalleitemequivalencia_precios
                                                                                                                               })
                                           }),
                               .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                              New With {
                                              .almacen = al,
                                              .TotalesInv = tot
                                              }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                   i.TotalesInv.cantidad > 0 And
                                                                   i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                   i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                   i.TotalesInv.status = 1)}).ToList


            Case "CATEGORIA"

                consulta = HeliosData.detalleitems _
           .Include(Function(cat) cat.item) _
           .Include(Function(lot) lot.recursoCostoLote) _
           .Include(Function(i) i.totalesAlmacen) _
           .Include(Function(ax) ax.detalleitems_conexo) _
           .Include(Function(o) o.detalleitem_equivalencias.Select(
           Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                .Where(Function(d) d.idItem = be.idItem And d.estado = "A" And Not d.tipoItem = "DET" And
                                 d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                .Select(Function(o) New With
                                {
                                .detalleitems = o,
                                .category = o.item,
                                .detalleitems_conexo = o.detalleitems_conexo,
                                .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                           {
                                           .Equivale = e,
                                           .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                           .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                               {
                                                                                                                               .Cat = p,
                                                                                                                               .Precios = p.detalleitemequivalencia_precios
                                                                                                                               })
                                           }),
                               .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                              New With {
                                              .almacen = al,
                                              .TotalesInv = tot
                                              }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                   i.TotalesInv.cantidad > 0 And
                                                                   i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                   i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                   i.TotalesInv.status = 1)}).ToList

            Case "SUBCATEGORIA"


                consulta = HeliosData.detalleitems _
          .Include(Function(cat) cat.item) _
          .Include(Function(lot) lot.recursoCostoLote) _
          .Include(Function(i) i.totalesAlmacen) _
          .Include(Function(ax) ax.detalleitems_conexo) _
          .Include(Function(o) o.detalleitem_equivalencias.Select(
          Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                               .Where(Function(d) d.unidad2 = be.unidad2 And d.estado = "A" And Not d.tipoItem = "DET" And
                                 d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                               .Select(Function(o) New With
                               {
                               .detalleitems = o,
                               .category = o.item,
                               .detalleitems_conexo = o.detalleitems_conexo,
                               .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                               .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                          {
                                          .Equivale = e,
                                          .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                          .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                              {
                                                                                                                              .Cat = p,
                                                                                                                              .Precios = p.detalleitemequivalencia_precios
                                                                                                                              })
                                          }),
                              .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                             New With {
                                             .almacen = al,
                                             .TotalesInv = tot
                                             }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                  i.TotalesInv.cantidad > 0 And
                                                                  i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                  i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                  i.TotalesInv.status = 1)}).ToList

            Case "MARCA"


                consulta = HeliosData.detalleitems _
          .Include(Function(cat) cat.item) _
          .Include(Function(lot) lot.recursoCostoLote) _
          .Include(Function(i) i.totalesAlmacen) _
          .Include(Function(ax) ax.detalleitems_conexo) _
          .Include(Function(o) o.detalleitem_equivalencias.Select(
          Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                               .Where(Function(d) d.marcaRef = be.marcaRef And d.estado = "A" And Not d.tipoItem = "DET" And
                                 d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                               .Select(Function(o) New With
                               {
                               .detalleitems = o,
                               .category = o.item,
                               .detalleitems_conexo = o.detalleitems_conexo,
                               .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                               .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                          {
                                          .Equivale = e,
                                          .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                          .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                              {
                                                                                                                              .Cat = p,
                                                                                                                              .Precios = p.detalleitemequivalencia_precios
                                                                                                                              })
                                          }),
                              .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                             New With {
                                             .almacen = al,
                                             .TotalesInv = tot
                                             }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                  i.TotalesInv.cantidad > 0 And
                                                                  i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                  i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                  i.TotalesInv.status = 1)}).ToList

            Case Else

                consulta = HeliosData.detalleitems _
            .Include(Function(cat) cat.item) _
            .Include(Function(lot) lot.recursoCostoLote) _
            .Include(Function(i) i.totalesAlmacen) _
            .Include(Function(ax) ax.detalleitems_conexo) _
            .Include(Function(o) o.detalleitem_equivalencias.Select(
            Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                 .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" And Not d.tipoItem = "DET" And
                                 d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                 .Select(Function(o) New With
                                 {
                                 .detalleitems = o,
                                 .category = o.item,
                                 .detalleitems_conexo = o.detalleitems_conexo,
                                 .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                 .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                            {
                                            .Equivale = e,
                                            .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                            .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                {
                                                                                                                                .Cat = p,
                                                                                                                                .Precios = p.detalleitemequivalencia_precios
                                                                                                                                })
                                            }),
                                .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                               New With {
                                               .almacen = al,
                                               .TotalesInv = tot
                                               }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                    i.TotalesInv.cantidad > 0 And
                                                                    i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                    i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                    i.TotalesInv.status = 1)}).ToList


        End Select











        'StatusArticulo.Activo

        '      Dim c = HeliosData.totalesAlmacen.Join(HeliosData.detalleitems, Function(post) post.idItem, Function(prod) prod.codigodetalle, Function(post, prod) _
        '                                       New With
        '                                       {
        '                                       .post = post,
        '                                       .prod = prod
        '                                       }).ToList



        '.Where(Function(d) d.descripcionItem.Contains(be.descripcionItem)).ToList


        'Dim consulta = HeliosData.detalleitems.Include(Function(o) o.detalleitem_equivalencias.Select(Function(y) y.detalleitemequivalencia_precios)).Where(Function(d) d.descripcionItem.StartsWith(be.descripcionItem)).ToList


        Dim obj As detalleitems
        Dim obEquivalencia As detalleitem_equivalencias
        Dim ListEquivalencia As List(Of detalleitem_equivalencias)
        Dim ListTotalesAlmacen As List(Of totalesAlmacen)

        Dim Listdetalleitems_conexo As List(Of detalleitems_conexo)

        Dim ListLotes As List(Of recursoCostoLote)
        Dim ListEquivalenciaPrecios As List(Of detalleitemequivalencia_precios)
        Dim ListaCatalogoPrecios As List(Of detalleitemequivalencia_catalogos)
        Dim ListaBeneficios As List(Of detalleitemequivalencia_beneficio)
        GetProductosWithInventario = New List(Of detalleitems)

        For Each i In consulta

            ListEquivalencia = New List(Of detalleitem_equivalencias)
            ListTotalesAlmacen = New List(Of totalesAlmacen)
            ListLotes = New List(Of recursoCostoLote)
            Listdetalleitems_conexo = New List(Of detalleitems_conexo)


            For Each ax In i.detalleitems_conexo
                Listdetalleitems_conexo.Add(New detalleitems_conexo With {
                    .conexo_id = ax.conexo_id,
                    .codigodetalle = ax.codigodetalle,
                    .idProducto = ax.idProducto,
                    .detalle = ax.detalle,
                    .cantidad = ax.cantidad,
                    .equivalencia_id = ax.equivalencia_id,
                    .unidadComercial = ax.unidadComercial,
                    .fraccion = ax.fraccion,
                    .estado = ax.estado,
                    .vigencia = ax.vigencia,
                    .usuarioActualizacion = ax.usuarioActualizacion,
                    .fechaActualizacion = ax.fechaActualizacion
                                            })
            Next

            For Each lt In i.Lotes
                ListLotes.Add(New recursoCostoLote With
                              {
                              .codigoLote = lt.codigoLote,
                              .nroLote = lt.nroLote,
                              .idDocumento = lt.idDocumento,
                              .idproyecto = lt.idproyecto,
                              .codigoProducto = lt.codigoProducto,
                              .moneda = lt.moneda,
                              .detalle = lt.detalle,
                              .cantidad = lt.cantidad,
                              .precioUnitarioIva = lt.precioUnitarioIva,
                              .fechaentrada = lt.fechaentrada,
                              .fechaProduccion = lt.fechaProduccion,
                              .fechaVcto = lt.fechaVcto,
                              .serie = lt.serie,
                              .sku = lt.sku,
                              .composicion = lt.composicion,
                              .productoSustentado = lt.productoSustentado
                              })
            Next



            For Each inv In i.totalesAlmacen

                ListTotalesAlmacen.Add(New totalesAlmacen With {
                                       .idMovimiento = inv.TotalesInv.idMovimiento,
                                       .idEmpresa = inv.TotalesInv.idEmpresa,
                                       .idEstablecimiento = inv.TotalesInv.idEstablecimiento,
                                       .idAlmacen = inv.TotalesInv.idAlmacen,
                                       .codigoLote = inv.TotalesInv.codigoLote,
                                       .descripcion = inv.TotalesInv.descripcion,
                                       .idUnidad = inv.TotalesInv.idUnidad,
                                       .unidadMedida = inv.TotalesInv.unidadMedida,
                                       .cantidad = inv.TotalesInv.cantidad,
                                       .cantidad2 = inv.TotalesInv.cantidad2,
                                       .importeSoles = inv.TotalesInv.importeSoles,
                                       .importeDolares = inv.TotalesInv.importeDolares,
                                       .status = inv.TotalesInv.status
                                       })
            Next

            For Each eq In i.detalleitem_equivalencias
                obEquivalencia = New detalleitem_equivalencias
                obEquivalencia.equivalencia_id = eq.Equivale.equivalencia_id
                obEquivalencia.flag = eq.Equivale.flag
                obEquivalencia.codigodetalle = eq.Equivale.codigodetalle
                obEquivalencia.detalle = eq.Equivale.detalle
                obEquivalencia.contenido = eq.Equivale.contenido
                obEquivalencia.contenido_neto = eq.Equivale.contenido_neto
                obEquivalencia.unidadComercial = eq.Equivale.unidadComercial
                obEquivalencia.fraccionUnidad = eq.Equivale.fraccionUnidad
                obEquivalencia.estado = eq.Equivale.estado


                ListaBeneficios = New List(Of detalleitemequivalencia_beneficio)
                For Each ben In eq.detalleitemequivalencia_beneficio
                    ListaBeneficios.Add(New detalleitemequivalencia_beneficio With
                                        {
                                        .beneficio_id = ben.beneficio_id,
                                        .codigodetalle = ben.codigodetalle,
                                        .modalidadVenta = ben.modalidadVenta,
                                        .aplica = ben.aplica,
                                        .equivalencia_id = ben.equivalencia_id,
                                        .beneficio_detalle = ben.beneficio_detalle,
                                        .tipobeneficio = ben.tipobeneficio,
                                        .tipoafectacion = ben.tipoafectacion,
                                        .valor_evaluado = ben.valor_evaluado,
                                        .valor_conversion = ben.valor_conversion,
                                        .valor_beneficio = ben.valor_beneficio,
                                        .lote_id = ben.lote_id,
                                        .estado = ben.estado,
                                        .usuarioActualizacion = ben.usuarioActualizacion,
                                        .fechaActualizacion = ben.fechaActualizacion
                                        })
                Next


                ListaCatalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
                For Each cat In eq.detalleitemequivalencia_catalogos
                    ListEquivalenciaPrecios = New List(Of detalleitemequivalencia_precios)
                    For Each prec In cat.Precios
                        ListEquivalenciaPrecios.Add(New detalleitemequivalencia_precios With
                                                    {
                                                    .precio_id = prec.precio_id,
                                                    .codigodetalle = prec.codigodetalle,
                                                    .equivalencia_id = prec.equivalencia_id,
                                                    .idCatalogo = prec.idCatalogo,
                                                    .rango_inicio = prec.rango_inicio,
                                                    .rango_final = prec.rango_final,
                                                    .precioCredito = prec.precioCredito,
                                                    .precioCreditoUSD = prec.precioCreditoUSD,
                                                    .precio = prec.precio,
                                                    .precioUSD = prec.precioUSD,
                                                    .precioCode = prec.precioCode,
                                                    .estado = prec.estado
                                                    })
                    Next

                    ListaCatalogoPrecios.Add(New detalleitemequivalencia_catalogos With {
                                                 .idCatalogo = cat.Cat.idCatalogo,
                                                 .codigodetalle = cat.Cat.codigodetalle,
                                                 .equivalencia_id = cat.Cat.equivalencia_id,
                                                 .nombre_corto = cat.Cat.nombre_corto,
                                                 .nombre_largo = cat.Cat.nombre_largo,
                                                 .estado = cat.Cat.estado,
                                                 .predeterminado = cat.Cat.predeterminado,
                                                 .detalleitemequivalencia_precios = ListEquivalenciaPrecios
                                             })


                Next
                obEquivalencia.detalleitemequivalencia_catalogos = ListaCatalogoPrecios
                obEquivalencia.detalleitemequivalencia_beneficio = ListaBeneficios
                ListEquivalencia.Add(obEquivalencia)
            Next
            Dim category As item = Nothing
            If i.category IsNot Nothing Then
                category = New item With
                           {
                           .idItem = i.category.idItem,
                           .idPadre = i.category.idPadre,
                           .descripcion = i.category.descripcion,
                           .tipo = i.category.tipo,
                           .preciocompratipo = i.category.preciocompratipo,
                           .precioCompra = i.category.precioCompra,
                           .firstpercent = i.category.firstpercent,
                           .beforepercent = i.category.beforepercent
                           }
            End If
            obj = New detalleitems With
                {
                .item = If(i.category IsNot Nothing, category, Nothing),
                .codigodetalle = i.detalleitems.codigodetalle,
                .idItem = i.detalleitems.idItem,
                .descripcionItem = i.detalleitems.descripcionItem,
                .unidad1 = i.detalleitems.unidad1,
                .tipoExistencia = i.detalleitems.tipoExistencia,
                .unidad2 = i.detalleitems.unidad2,
                .codigo = i.detalleitems.codigo,
                .origenProducto = i.detalleitems.origenProducto,
                .composicion = i.detalleitems.composicion,
                .presentacion = i.detalleitems.presentacion,
                .AfectoStock = i.detalleitems.AfectoStock,
                .detalleitem_equivalencias = ListEquivalencia,
                .detalleitems_conexo = Listdetalleitems_conexo,
                .totalesAlmacen = ListTotalesAlmacen,
                .recursoCostoLote = ListLotes,
                .otroImpuesto = i.detalleitems.otroImpuesto,
                .tipoOtroImpuesto = i.detalleitems.tipoOtroImpuesto,
                .igv = i.detalleitems.igv,
                .precioCompra = i.detalleitems.precioCompra,
                .preciocompratipo = i.detalleitems.preciocompratipo,
                .firstpercent = i.detalleitems.firstpercent,
                .beforepercent = i.detalleitems.beforepercent
            }
            GetProductosWithInventario.Add(obj)
        Next

        Return GetProductosWithInventario

    End Function

    Public Function GetProductosWithInventarioAlmacen(be As detalleitems) As List(Of detalleitems)
        'Include("detalleitem_equivalencias").Include("detalleitemequivalencia_precios")

        'Dim results = warmCountries.Join(europeanCountries, Function(warm) warm, Function(european) european, Function(warm, european) warm)


        'INNER JOIN
        'Dim c = HeliosData.totalesAlmacen.Join(HeliosData.detalleitems, Function(post) post.idItem, Function(prod) prod.codigodetalle, Function(post, prod) _
        '                                       New With
        '                                       {
        '                                       .post = post,
        '                                       .prod = prod
        '                                       }).ToList

        'LAMBDA MULTIPLE INLCUIDE
        'Dim result = HeliosData.detalleitems _
        '    .Include(Function(o) o.detalleitem_equivalencias _
        '    .Select(Function(y) y.detalleitemequivalencia_precios)) _
        '    .GroupJoin(HeliosData.totalesAlmacen, Function(lang) lang.codigodetalle, Function(pers) pers.idItem,
        '         Function(lang, ps) New With
        '         {
        '         .CodigoDetalle = lang.codigodetalle,
        '         .DescripcionProducto = lang.descripcionItem,
        '         .Codigo = lang.codigo,
        '         .unidad = lang.unidad1,
        '         .item = lang.item,
        '         .Stock = CType(ps.Sum(Function(p) p.cantidad), Decimal?),
        '         .Persons = ps
        '             }
        '         ).ToList

        Dim consulta = HeliosData.detalleitems _
            .Include(Function(cat) cat.item) _
            .Include(Function(lot) lot.recursoCostoLote) _
            .Include(Function(i) i.totalesAlmacen) _
            .Include(Function(ax) ax.detalleitems_conexo) _
            .Include(Function(o) o.detalleitem_equivalencias.Select(
            Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                 .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A" And d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                 .Select(Function(o) New With
                                 {
                                 .detalleitems = o,
                                 .detalleitems_conexo = o.detalleitems_conexo,
                                 .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                 .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                            {
                                            .Equivale = e,
                                            .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                            .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                {
                                                                                                                                .Cat = p,
                                                                                                                                .Precios = p.detalleitemequivalencia_precios
                                                                                                                                })
                                            }),
                                .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                               New With {
                                               .almacen = al,
                                               .TotalesInv = tot
                                               }).Join(HeliosData.recursoCostoLote, Function(tot) tot.TotalesInv.codigoLote, Function(lote) lote.codigoLote, Function(tot, lote) _
                                                New With {
                                                .almacen = tot.almacen,
                                                .TotalesInv = tot.TotalesInv,
                                                .lote = lote
                                                }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                    i.TotalesInv.idAlmacen = be.idAlmacen And
                                                                    i.TotalesInv.cantidad > 0 And
                                                                    i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                    i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                    i.TotalesInv.status = 1)}).ToList
        'StatusArticulo.Activo

        '      Dim c = HeliosData.totalesAlmacen.Join(HeliosData.detalleitems, Function(post) post.idItem, Function(prod) prod.codigodetalle, Function(post, prod) _
        '                                       New With
        '                                       {
        '                                       .post = post,
        '                                       .prod = prod
        '                                       }).ToList



        '.Where(Function(d) d.descripcionItem.Contains(be.descripcionItem)).ToList


        'Dim consulta = HeliosData.detalleitems.Include(Function(o) o.detalleitem_equivalencias.Select(Function(y) y.detalleitemequivalencia_precios)).Where(Function(d) d.descripcionItem.StartsWith(be.descripcionItem)).ToList


        Dim obj As detalleitems
        Dim obEquivalencia As detalleitem_equivalencias
        Dim ListEquivalencia As List(Of detalleitem_equivalencias)
        Dim ListTotalesAlmacen As List(Of totalesAlmacen)

        Dim Listdetalleitems_conexo As List(Of detalleitems_conexo)

        Dim ListLotes As List(Of recursoCostoLote)
        Dim ListEquivalenciaPrecios As List(Of detalleitemequivalencia_precios)
        Dim ListaCatalogoPrecios As List(Of detalleitemequivalencia_catalogos)
        Dim ListaBeneficios As List(Of detalleitemequivalencia_beneficio)
        GetProductosWithInventarioAlmacen = New List(Of detalleitems)

        For Each i In consulta

            ListEquivalencia = New List(Of detalleitem_equivalencias)
            ListTotalesAlmacen = New List(Of totalesAlmacen)
            ListLotes = New List(Of recursoCostoLote)
            Listdetalleitems_conexo = New List(Of detalleitems_conexo)


            For Each ax In i.detalleitems_conexo
                Listdetalleitems_conexo.Add(New detalleitems_conexo With {
                    .conexo_id = ax.conexo_id,
                    .codigodetalle = ax.codigodetalle,
                    .idProducto = ax.idProducto,
                    .detalle = ax.detalle,
                    .cantidad = ax.cantidad,
                    .equivalencia_id = ax.equivalencia_id,
                    .unidadComercial = ax.unidadComercial,
                    .fraccion = ax.fraccion,
                    .estado = ax.estado,
                    .vigencia = ax.vigencia,
                    .usuarioActualizacion = ax.usuarioActualizacion,
                    .fechaActualizacion = ax.fechaActualizacion
                                            })
            Next

            For Each lt In i.Lotes
                ListLotes.Add(New recursoCostoLote With
                              {
                              .codigoLote = lt.codigoLote,
                              .nroLote = lt.nroLote,
                              .idDocumento = lt.idDocumento,
                              .idproyecto = lt.idproyecto,
                              .codigoProducto = lt.codigoProducto,
                              .moneda = lt.moneda,
                              .detalle = lt.detalle,
                              .cantidad = lt.cantidad,
                              .precioUnitarioIva = lt.precioUnitarioIva,
                              .fechaentrada = lt.fechaentrada,
                              .fechaProduccion = lt.fechaProduccion,
                              .fechaVcto = lt.fechaVcto,
                              .serie = lt.serie,
                              .sku = lt.sku,
                              .composicion = lt.composicion,
                              .productoSustentado = lt.productoSustentado
                              })
            Next



            For Each inv In i.totalesAlmacen

                ListTotalesAlmacen.Add(New totalesAlmacen With {
                    .CustomLote = New recursoCostoLote With
                                       {
                                       .codigoLote = inv.lote.codigoLote,
                                       .nroLote = inv.lote.nroLote,
                                       .idDocumento = inv.lote.idDocumento,
                                       .idproyecto = inv.lote.idproyecto,
                                       .codigoProducto = inv.lote.codigoProducto,
                                       .moneda = inv.lote.moneda,
                                       .detalle = inv.lote.detalle,
                                       .cantidad = inv.lote.cantidad,
                                       .precioUnitarioIva = inv.lote.precioUnitarioIva,
                                       .fechaentrada = inv.lote.fechaentrada,
                                       .fechaProduccion = inv.lote.fechaProduccion,
                                       .fechaVcto = inv.lote.fechaVcto,
                                       .serie = inv.lote.serie,
                                       .sku = inv.lote.sku,
                                       .composicion = inv.lote.composicion,
                                       .productoSustentado = inv.lote.productoSustentado
                                       },
                                       .idMovimiento = inv.TotalesInv.idMovimiento,
                                       .idEmpresa = inv.TotalesInv.idEmpresa,
                                       .idEstablecimiento = inv.TotalesInv.idEstablecimiento,
                                       .idAlmacen = inv.TotalesInv.idAlmacen,
                                       .codigoLote = inv.TotalesInv.codigoLote,
                                       .descripcion = inv.TotalesInv.descripcion,
                                       .idUnidad = inv.TotalesInv.idUnidad,
                                       .unidadMedida = inv.TotalesInv.unidadMedida,
                                       .cantidad = inv.TotalesInv.cantidad,
                                       .cantidad2 = inv.TotalesInv.cantidad2,
                                       .importeSoles = inv.TotalesInv.importeSoles,
                                       .importeDolares = inv.TotalesInv.importeDolares,
                                       .status = inv.TotalesInv.status
                                       })
            Next

            For Each eq In i.detalleitem_equivalencias
                obEquivalencia = New detalleitem_equivalencias
                obEquivalencia.equivalencia_id = eq.Equivale.equivalencia_id
                obEquivalencia.flag = eq.Equivale.flag
                obEquivalencia.codigodetalle = eq.Equivale.codigodetalle
                obEquivalencia.detalle = eq.Equivale.detalle
                obEquivalencia.contenido = eq.Equivale.contenido
                obEquivalencia.contenido_neto = eq.Equivale.contenido_neto
                obEquivalencia.unidadComercial = eq.Equivale.unidadComercial
                obEquivalencia.fraccionUnidad = eq.Equivale.fraccionUnidad
                obEquivalencia.estado = eq.Equivale.estado


                ListaBeneficios = New List(Of detalleitemequivalencia_beneficio)
                For Each ben In eq.detalleitemequivalencia_beneficio
                    ListaBeneficios.Add(New detalleitemequivalencia_beneficio With
                                        {
                                        .beneficio_id = ben.beneficio_id,
                                        .codigodetalle = ben.codigodetalle,
                                        .modalidadVenta = ben.modalidadVenta,
                                        .aplica = ben.aplica,
                                        .equivalencia_id = ben.equivalencia_id,
                                        .beneficio_detalle = ben.beneficio_detalle,
                                        .tipobeneficio = ben.tipobeneficio,
                                        .tipoafectacion = ben.tipoafectacion,
                                        .valor_evaluado = ben.valor_evaluado,
                                        .valor_conversion = ben.valor_conversion,
                                        .valor_beneficio = ben.valor_beneficio,
                                        .lote_id = ben.lote_id,
                                        .estado = ben.estado,
                                        .usuarioActualizacion = ben.usuarioActualizacion,
                                        .fechaActualizacion = ben.fechaActualizacion
                                        })
                Next


                ListaCatalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
                For Each cat In eq.detalleitemequivalencia_catalogos
                    ListEquivalenciaPrecios = New List(Of detalleitemequivalencia_precios)
                    For Each prec In cat.Precios
                        ListEquivalenciaPrecios.Add(New detalleitemequivalencia_precios With
                                                    {
                                                    .precio_id = prec.precio_id,
                                                    .codigodetalle = prec.codigodetalle,
                                                    .equivalencia_id = prec.equivalencia_id,
                                                    .idCatalogo = prec.idCatalogo,
                                                    .rango_inicio = prec.rango_inicio,
                                                    .rango_final = prec.rango_final,
                                                    .precioCredito = prec.precioCredito,
                                                    .precioCreditoUSD = prec.precioCreditoUSD,
                                                    .precio = prec.precio,
                                                    .precioUSD = prec.precioUSD,
                                                    .precioCode = prec.precioCode,
                                                    .estado = prec.estado
                                                    })
                    Next

                    ListaCatalogoPrecios.Add(New detalleitemequivalencia_catalogos With {
                                                 .idCatalogo = cat.Cat.idCatalogo,
                                                 .codigodetalle = cat.Cat.codigodetalle,
                                                 .equivalencia_id = cat.Cat.equivalencia_id,
                                                 .nombre_corto = cat.Cat.nombre_corto,
                                                 .nombre_largo = cat.Cat.nombre_largo,
                                                 .estado = cat.Cat.estado,
                                                 .predeterminado = cat.Cat.predeterminado,
                                                 .detalleitemequivalencia_precios = ListEquivalenciaPrecios
                                             })


                Next
                obEquivalencia.detalleitemequivalencia_catalogos = ListaCatalogoPrecios
                obEquivalencia.detalleitemequivalencia_beneficio = ListaBeneficios
                ListEquivalencia.Add(obEquivalencia)
            Next

            obj = New detalleitems With
                {
                .codigodetalle = i.detalleitems.codigodetalle,
                .idItem = i.detalleitems.idItem,
                .descripcionItem = i.detalleitems.descripcionItem,
                .unidad1 = i.detalleitems.unidad1,
                .tipoExistencia = i.detalleitems.tipoExistencia,
                .unidad2 = i.detalleitems.unidad2,
                .codigo = i.detalleitems.codigo,
                .origenProducto = i.detalleitems.origenProducto,
                .composicion = i.detalleitems.composicion,
                .AfectoStock = i.detalleitems.AfectoStock,
                .detalleitem_equivalencias = ListEquivalencia,
                .detalleitems_conexo = Listdetalleitems_conexo,
                .totalesAlmacen = ListTotalesAlmacen,
                .recursoCostoLote = ListLotes,
                .otroImpuesto = i.detalleitems.otroImpuesto,
                .tipoOtroImpuesto = i.detalleitems.tipoOtroImpuesto,
                .igv = i.detalleitems.igv
            }
            GetProductosWithInventarioAlmacen.Add(obj)
        Next

    End Function

    Public Function GetProductsCodigoInternoAlmacen(be As detalleitems) As List(Of detalleitems)

        Dim consulta = HeliosData.detalleitems _
            .Include(Function(lot) lot.recursoCostoLote) _
            .Include(Function(i) i.totalesAlmacen) _
            .Include(Function(o) o.detalleitem_equivalencias.Select(
            Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                 .Where(Function(d) d.codigoInterno = (be.codigoInterno) And d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                 .Select(Function(o) New With
                                 {
                                 .detalleitems = o,
                                 .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                 .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                            {
                                            .Equivale = e,
                                            .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                {
                                                                                                                                .Cat = p,
                                                                                                                                .Precios = p.detalleitemequivalencia_precios
                                                                                                                                })
                                            }),
                                .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                               New With {
                                               .almacen = al,
                                               .TotalesInv = tot
                                               }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                    i.almacen.idAlmacen = be.idAlmacen And
                                                                    i.TotalesInv.cantidad > 0 And
                                                                    i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                    i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                    i.TotalesInv.status = 1)}).ToList
        'StatusArticulo.Activo

        '      Dim c = HeliosData.totalesAlmacen.Join(HeliosData.detalleitems, Function(post) post.idItem, Function(prod) prod.codigodetalle, Function(post, prod) _
        '                                       New With
        '                                       {
        '                                       .post = post,
        '                                       .prod = prod
        '                                       }).ToList



        '.Where(Function(d) d.descripcionItem.Contains(be.descripcionItem)).ToList


        'Dim consulta = HeliosData.detalleitems.Include(Function(o) o.detalleitem_equivalencias.Select(Function(y) y.detalleitemequivalencia_precios)).Where(Function(d) d.descripcionItem.StartsWith(be.descripcionItem)).ToList


        Dim obj As detalleitems
        Dim obEquivalencia As detalleitem_equivalencias
        Dim ListEquivalencia As List(Of detalleitem_equivalencias)
        Dim ListTotalesAlmacen As List(Of totalesAlmacen)
        Dim ListLotes As List(Of recursoCostoLote)
        Dim ListEquivalenciaPrecios As List(Of detalleitemequivalencia_precios)
        Dim ListaCatalogoPrecios As List(Of detalleitemequivalencia_catalogos)
        GetProductsCodigoInternoAlmacen = New List(Of detalleitems)

        For Each i In consulta

            ListEquivalencia = New List(Of detalleitem_equivalencias)
            ListTotalesAlmacen = New List(Of totalesAlmacen)
            ListLotes = New List(Of recursoCostoLote)

            For Each lt In i.Lotes
                ListLotes.Add(New recursoCostoLote With
                              {
                              .codigoLote = lt.codigoLote,
                              .nroLote = lt.nroLote,
                              .idDocumento = lt.idDocumento,
                              .idproyecto = lt.idproyecto,
                              .codigoProducto = lt.codigoProducto,
                              .moneda = lt.moneda,
                              .detalle = lt.detalle,
                              .cantidad = lt.cantidad,
                              .precioUnitarioIva = lt.precioUnitarioIva,
                              .fechaentrada = lt.fechaentrada,
                              .fechaProduccion = lt.fechaProduccion,
                              .fechaVcto = lt.fechaVcto,
                              .serie = lt.serie,
                              .sku = lt.sku,
                              .composicion = lt.composicion,
                              .productoSustentado = lt.productoSustentado
                              })
            Next

            For Each inv In i.totalesAlmacen

                ListTotalesAlmacen.Add(New totalesAlmacen With {
                                       .idMovimiento = inv.TotalesInv.idMovimiento,
                                       .idEmpresa = inv.TotalesInv.idEmpresa,
                                       .idEstablecimiento = inv.TotalesInv.idEstablecimiento,
                                       .idAlmacen = inv.TotalesInv.idAlmacen,
                                       .codigoLote = inv.TotalesInv.codigoLote,
                                       .descripcion = inv.TotalesInv.descripcion,
                                       .idUnidad = inv.TotalesInv.idUnidad,
                                       .unidadMedida = inv.TotalesInv.unidadMedida,
                                       .cantidad = inv.TotalesInv.cantidad,
                                       .cantidad2 = inv.TotalesInv.cantidad2,
                                       .importeSoles = inv.TotalesInv.importeSoles,
                                       .importeDolares = inv.TotalesInv.importeDolares,
                                       .status = inv.TotalesInv.status
                                       })
            Next

            For Each eq In i.detalleitem_equivalencias
                obEquivalencia = New detalleitem_equivalencias
                obEquivalencia.detalle = eq.Equivale.detalle
                obEquivalencia.contenido = eq.Equivale.contenido
                obEquivalencia.unidadComercial = eq.Equivale.unidadComercial
                obEquivalencia.equivalencia_id = eq.Equivale.equivalencia_id
                obEquivalencia.fraccionUnidad = eq.Equivale.fraccionUnidad
                obEquivalencia.estado = eq.Equivale.estado

                ListaCatalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
                For Each cat In eq.detalleitemequivalencia_catalogos
                    ListEquivalenciaPrecios = New List(Of detalleitemequivalencia_precios)
                    For Each prec In cat.Precios
                        ListEquivalenciaPrecios.Add(New detalleitemequivalencia_precios With
                                                    {
                                                    .rango_inicio = prec.rango_inicio,
                                                    .rango_final = prec.rango_final,
                                                    .precioCredito = prec.precioCredito,
                                                    .precio = prec.precio,
                                                    .precio_id = prec.precio_id,
                                                    .precioCode = prec.precioCode,
                                                    .estado = prec.estado
                                                    })
                    Next

                    ListaCatalogoPrecios.Add(New detalleitemequivalencia_catalogos With {
                                                 .idCatalogo = cat.Cat.idCatalogo,
                                                 .codigodetalle = cat.Cat.codigodetalle,
                                                 .equivalencia_id = cat.Cat.equivalencia_id,
                                                 .nombre_corto = cat.Cat.nombre_corto,
                                                 .nombre_largo = cat.Cat.nombre_largo,
                                                 .estado = cat.Cat.estado,
                                                 .predeterminado = cat.Cat.predeterminado,
                                                 .detalleitemequivalencia_precios = ListEquivalenciaPrecios
                                             })


                Next
                obEquivalencia.detalleitemequivalencia_catalogos = ListaCatalogoPrecios


                ListEquivalencia.Add(obEquivalencia)
            Next

            obj = New detalleitems With
                {
                .codigodetalle = i.detalleitems.codigodetalle,
                .idItem = i.detalleitems.idItem,
                .descripcionItem = i.detalleitems.descripcionItem,
                .unidad1 = i.detalleitems.unidad1,
                .tipoExistencia = i.detalleitems.tipoExistencia,
                .unidad2 = i.detalleitems.unidad2,
                .codigo = i.detalleitems.codigo,
                .origenProducto = i.detalleitems.origenProducto,
                .composicion = i.detalleitems.composicion,
                .detalleitem_equivalencias = ListEquivalencia,
                .totalesAlmacen = ListTotalesAlmacen,
                .recursoCostoLote = ListLotes
            }
            GetProductsCodigoInternoAlmacen.Add(obj)
        Next

        Return GetProductsCodigoInternoAlmacen

    End Function
    Public Function GetProductsCodigoInterno(be As detalleitems) As List(Of detalleitems)

        Dim consulta = HeliosData.detalleitems _
            .Include(Function(lot) lot.recursoCostoLote) _
            .Include(Function(i) i.totalesAlmacen) _
            .Include(Function(o) o.detalleitem_equivalencias.Select(
            Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                 .Where(Function(d) d.codigoInterno = (be.codigoInterno) And d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                 .Select(Function(o) New With
                                 {
                                 .detalleitems = o,
                                 .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                 .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                            {
                                            .Equivale = e,
                                            .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                {
                                                                                                                                .Cat = p,
                                                                                                                                .Precios = p.detalleitemequivalencia_precios
                                                                                                                                })
                                            }),
                                .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                               New With {
                                               .almacen = al,
                                               .TotalesInv = tot
                                               }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                    i.TotalesInv.cantidad > 0 And
                                                                    i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                    i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                    i.TotalesInv.status = 1)}).ToList
        'StatusArticulo.Activo

        '      Dim c = HeliosData.totalesAlmacen.Join(HeliosData.detalleitems, Function(post) post.idItem, Function(prod) prod.codigodetalle, Function(post, prod) _
        '                                       New With
        '                                       {
        '                                       .post = post,
        '                                       .prod = prod
        '                                       }).ToList



        '.Where(Function(d) d.descripcionItem.Contains(be.descripcionItem)).ToList


        'Dim consulta = HeliosData.detalleitems.Include(Function(o) o.detalleitem_equivalencias.Select(Function(y) y.detalleitemequivalencia_precios)).Where(Function(d) d.descripcionItem.StartsWith(be.descripcionItem)).ToList


        Dim obj As detalleitems
        Dim obEquivalencia As detalleitem_equivalencias
        Dim ListEquivalencia As List(Of detalleitem_equivalencias)
        Dim ListTotalesAlmacen As List(Of totalesAlmacen)
        Dim ListLotes As List(Of recursoCostoLote)
        Dim ListEquivalenciaPrecios As List(Of detalleitemequivalencia_precios)
        Dim ListaCatalogoPrecios As List(Of detalleitemequivalencia_catalogos)
        GetProductsCodigoInterno = New List(Of detalleitems)

        For Each i In consulta

            ListEquivalencia = New List(Of detalleitem_equivalencias)
            ListTotalesAlmacen = New List(Of totalesAlmacen)
            ListLotes = New List(Of recursoCostoLote)

            For Each lt In i.Lotes
                ListLotes.Add(New recursoCostoLote With
                              {
                              .codigoLote = lt.codigoLote,
                              .nroLote = lt.nroLote,
                              .idDocumento = lt.idDocumento,
                              .idproyecto = lt.idproyecto,
                              .codigoProducto = lt.codigoProducto,
                              .moneda = lt.moneda,
                              .detalle = lt.detalle,
                              .cantidad = lt.cantidad,
                              .precioUnitarioIva = lt.precioUnitarioIva,
                              .fechaentrada = lt.fechaentrada,
                              .fechaProduccion = lt.fechaProduccion,
                              .fechaVcto = lt.fechaVcto,
                              .serie = lt.serie,
                              .sku = lt.sku,
                              .composicion = lt.composicion,
                              .productoSustentado = lt.productoSustentado
                              })
            Next

            For Each inv In i.totalesAlmacen

                ListTotalesAlmacen.Add(New totalesAlmacen With {
                                       .idMovimiento = inv.TotalesInv.idMovimiento,
                                       .idEmpresa = inv.TotalesInv.idEmpresa,
                                       .idEstablecimiento = inv.TotalesInv.idEstablecimiento,
                                       .idAlmacen = inv.TotalesInv.idAlmacen,
                                       .codigoLote = inv.TotalesInv.codigoLote,
                                       .descripcion = inv.TotalesInv.descripcion,
                                       .idUnidad = inv.TotalesInv.idUnidad,
                                       .unidadMedida = inv.TotalesInv.unidadMedida,
                                       .cantidad = inv.TotalesInv.cantidad,
                                       .cantidad2 = inv.TotalesInv.cantidad2,
                                       .importeSoles = inv.TotalesInv.importeSoles,
                                       .importeDolares = inv.TotalesInv.importeDolares,
                                       .status = inv.TotalesInv.status
                                       })
            Next

            For Each eq In i.detalleitem_equivalencias
                obEquivalencia = New detalleitem_equivalencias
                obEquivalencia.detalle = eq.Equivale.detalle
                obEquivalencia.contenido = eq.Equivale.contenido
                obEquivalencia.unidadComercial = eq.Equivale.unidadComercial
                obEquivalencia.equivalencia_id = eq.Equivale.equivalencia_id
                obEquivalencia.fraccionUnidad = eq.Equivale.fraccionUnidad
                obEquivalencia.estado = eq.Equivale.estado

                ListaCatalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
                For Each cat In eq.detalleitemequivalencia_catalogos
                    ListEquivalenciaPrecios = New List(Of detalleitemequivalencia_precios)
                    For Each prec In cat.Precios
                        ListEquivalenciaPrecios.Add(New detalleitemequivalencia_precios With
                                                    {
                                                    .rango_inicio = prec.rango_inicio,
                                                    .rango_final = prec.rango_final,
                                                    .precioCredito = prec.precioCredito,
                                                    .precio = prec.precio,
                                                    .precio_id = prec.precio_id,
                                                    .precioCode = prec.precioCode,
                                                    .estado = prec.estado
                                                    })
                    Next

                    ListaCatalogoPrecios.Add(New detalleitemequivalencia_catalogos With {
                                                 .idCatalogo = cat.Cat.idCatalogo,
                                                 .codigodetalle = cat.Cat.codigodetalle,
                                                 .equivalencia_id = cat.Cat.equivalencia_id,
                                                 .nombre_corto = cat.Cat.nombre_corto,
                                                 .nombre_largo = cat.Cat.nombre_largo,
                                                 .estado = cat.Cat.estado,
                                                 .predeterminado = cat.Cat.predeterminado,
                                                 .detalleitemequivalencia_precios = ListEquivalenciaPrecios
                                             })


                Next
                obEquivalencia.detalleitemequivalencia_catalogos = ListaCatalogoPrecios


                ListEquivalencia.Add(obEquivalencia)
            Next

            obj = New detalleitems With
                {
                .codigodetalle = i.detalleitems.codigodetalle,
                .idItem = i.detalleitems.idItem,
                .descripcionItem = i.detalleitems.descripcionItem,
                .unidad1 = i.detalleitems.unidad1,
                .tipoExistencia = i.detalleitems.tipoExistencia,
                .unidad2 = i.detalleitems.unidad2,
                .codigo = i.detalleitems.codigo,
                .origenProducto = i.detalleitems.origenProducto,
                .composicion = i.detalleitems.composicion,
                .detalleitem_equivalencias = ListEquivalencia,
                .totalesAlmacen = ListTotalesAlmacen,
                .recursoCostoLote = ListLotes
            }
            GetProductsCodigoInterno.Add(obj)
        Next

        Return GetProductsCodigoInterno

    End Function

    Public Function GetProductsBarCodeAlmacen(be As detalleitems) As List(Of detalleitems)

        Dim consulta = HeliosData.detalleitems _
            .Include(Function(cat) cat.item) _
            .Include(Function(lot) lot.recursoCostoLote) _
            .Include(Function(i) i.totalesAlmacen) _
            .Include(Function(o) o.detalleitem_equivalencias.Select(
            Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                 .Where(Function(d) d.codigo = (be.codigo) And d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                 .Select(Function(o) New With
                                 {
                                 .detalleitems = o,
                                 .category = o.item,
                                 .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                 .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                            {
                                            .Equivale = e,
                                            .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                {
                                                                                                                                .Cat = p,
                                                                                                                                .Precios = p.detalleitemequivalencia_precios
                                                                                                                                })
                                            }),
                                .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                               New With {
                                               .almacen = al,
                                               .TotalesInv = tot
                                               }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                    i.TotalesInv.idAlmacen = be.idAlmacen And
                                                                    i.TotalesInv.cantidad > 0 And
                                                                    i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                    i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                    i.TotalesInv.status = 1)}).ToList
        'StatusArticulo.Activo

        '      Dim c = HeliosData.totalesAlmacen.Join(HeliosData.detalleitems, Function(post) post.idItem, Function(prod) prod.codigodetalle, Function(post, prod) _
        '                                       New With
        '                                       {
        '                                       .post = post,
        '                                       .prod = prod
        '                                       }).ToList



        '.Where(Function(d) d.descripcionItem.Contains(be.descripcionItem)).ToList


        'Dim consulta = HeliosData.detalleitems.Include(Function(o) o.detalleitem_equivalencias.Select(Function(y) y.detalleitemequivalencia_precios)).Where(Function(d) d.descripcionItem.StartsWith(be.descripcionItem)).ToList


        Dim obj As detalleitems
        Dim obEquivalencia As detalleitem_equivalencias
        Dim ListEquivalencia As List(Of detalleitem_equivalencias)
        Dim ListTotalesAlmacen As List(Of totalesAlmacen)
        Dim ListLotes As List(Of recursoCostoLote)
        Dim ListEquivalenciaPrecios As List(Of detalleitemequivalencia_precios)
        Dim ListaCatalogoPrecios As List(Of detalleitemequivalencia_catalogos)
        GetProductsBarCodeAlmacen = New List(Of detalleitems)

        For Each i In consulta

            ListEquivalencia = New List(Of detalleitem_equivalencias)
            ListTotalesAlmacen = New List(Of totalesAlmacen)
            ListLotes = New List(Of recursoCostoLote)

            For Each lt In i.Lotes
                ListLotes.Add(New recursoCostoLote With
                              {
                              .codigoLote = lt.codigoLote,
                              .nroLote = lt.nroLote,
                              .idDocumento = lt.idDocumento,
                              .idproyecto = lt.idproyecto,
                              .codigoProducto = lt.codigoProducto,
                              .moneda = lt.moneda,
                              .detalle = lt.detalle,
                              .cantidad = lt.cantidad,
                              .precioUnitarioIva = lt.precioUnitarioIva,
                              .fechaentrada = lt.fechaentrada,
                              .fechaProduccion = lt.fechaProduccion,
                              .fechaVcto = lt.fechaVcto,
                              .serie = lt.serie,
                              .sku = lt.sku,
                              .composicion = lt.composicion,
                              .productoSustentado = lt.productoSustentado
                              })
            Next

            For Each inv In i.totalesAlmacen

                ListTotalesAlmacen.Add(New totalesAlmacen With {
                                       .idMovimiento = inv.TotalesInv.idMovimiento,
                                       .idEmpresa = inv.TotalesInv.idEmpresa,
                                       .idEstablecimiento = inv.TotalesInv.idEstablecimiento,
                                       .idAlmacen = inv.TotalesInv.idAlmacen,
                                       .codigoLote = inv.TotalesInv.codigoLote,
                                       .descripcion = inv.TotalesInv.descripcion,
                                       .idUnidad = inv.TotalesInv.idUnidad,
                                       .unidadMedida = inv.TotalesInv.unidadMedida,
                                       .cantidad = inv.TotalesInv.cantidad,
                                       .cantidad2 = inv.TotalesInv.cantidad2,
                                       .importeSoles = inv.TotalesInv.importeSoles,
                                       .importeDolares = inv.TotalesInv.importeDolares,
                                       .status = inv.TotalesInv.status
                                       })
            Next

            For Each eq In i.detalleitem_equivalencias
                obEquivalencia = New detalleitem_equivalencias
                obEquivalencia.detalle = eq.Equivale.detalle
                obEquivalencia.contenido = eq.Equivale.contenido
                obEquivalencia.unidadComercial = eq.Equivale.unidadComercial
                obEquivalencia.equivalencia_id = eq.Equivale.equivalencia_id
                obEquivalencia.fraccionUnidad = eq.Equivale.fraccionUnidad
                obEquivalencia.estado = eq.Equivale.estado

                ListaCatalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
                For Each cat In eq.detalleitemequivalencia_catalogos
                    ListEquivalenciaPrecios = New List(Of detalleitemequivalencia_precios)
                    For Each prec In cat.Precios
                        ListEquivalenciaPrecios.Add(New detalleitemequivalencia_precios With
                                                    {
                                                    .rango_inicio = prec.rango_inicio,
                                                    .rango_final = prec.rango_final,
                                                    .precioCredito = prec.precioCredito,
                                                    .precio = prec.precio,
                                                    .precio_id = prec.precio_id,
                                                    .precioCode = prec.precioCode,
                                                    .estado = prec.estado
                                                    })
                    Next

                    ListaCatalogoPrecios.Add(New detalleitemequivalencia_catalogos With {
                                                 .idCatalogo = cat.Cat.idCatalogo,
                                                 .codigodetalle = cat.Cat.codigodetalle,
                                                 .equivalencia_id = cat.Cat.equivalencia_id,
                                                 .nombre_corto = cat.Cat.nombre_corto,
                                                 .nombre_largo = cat.Cat.nombre_largo,
                                                 .estado = cat.Cat.estado,
                                                 .predeterminado = cat.Cat.predeterminado,
                                                 .detalleitemequivalencia_precios = ListEquivalenciaPrecios
                                             })


                Next
                obEquivalencia.detalleitemequivalencia_catalogos = ListaCatalogoPrecios


                ListEquivalencia.Add(obEquivalencia)
            Next

            Dim category As item = Nothing
            If i.category IsNot Nothing Then
                category = New item With
                           {
                           .idItem = i.category.idItem,
                           .idPadre = i.category.idPadre,
                           .descripcion = i.category.descripcion,
                           .tipo = i.category.tipo,
                           .preciocompratipo = i.category.preciocompratipo,
                           .precioCompra = i.category.precioCompra,
                           .firstpercent = i.category.firstpercent,
                           .beforepercent = i.category.beforepercent
                           }
            End If

            obj = New detalleitems With
                {
                  .item = If(i.category IsNot Nothing, category, Nothing),
                .codigodetalle = i.detalleitems.codigodetalle,
                .idItem = i.detalleitems.idItem,
                .preciocompratipo = i.detalleitems.preciocompratipo,
                .precioCompra = i.detalleitems.precioCompra,
                .firstpercent = i.detalleitems.firstpercent,
                .beforepercent = i.detalleitems.beforepercent,
                .descripcionItem = i.detalleitems.descripcionItem,
                .unidad1 = i.detalleitems.unidad1,
                .tipoExistencia = i.detalleitems.tipoExistencia,
                .unidad2 = i.detalleitems.unidad2,
                .codigo = i.detalleitems.codigo,
                .origenProducto = i.detalleitems.origenProducto,
                .composicion = i.detalleitems.composicion,
                .fotoUrl = i.detalleitems.fotoUrl,
                .detalleitem_equivalencias = ListEquivalencia,
                .totalesAlmacen = ListTotalesAlmacen,
                .recursoCostoLote = ListLotes
            }
            GetProductsBarCodeAlmacen.Add(obj)
        Next

        Return GetProductsBarCodeAlmacen

    End Function
    Public Function GetProductsBarCode(be As detalleitems) As List(Of detalleitems)

        Dim consulta = HeliosData.detalleitems _
            .Include(Function(cat) cat.item) _
            .Include(Function(lot) lot.recursoCostoLote) _
            .Include(Function(i) i.totalesAlmacen) _
            .Include(Function(o) o.detalleitem_equivalencias.Select(
            Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                                 .Where(Function(d) d.codigo = (be.codigo) And d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                 .Select(Function(o) New With
                                 {
                                 .detalleitems = o,
                                 .category = o.item,
                                 .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                 .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                            {
                                            .Equivale = e,
                                            .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                {
                                                                                                                                .Cat = p,
                                                                                                                                .Precios = p.detalleitemequivalencia_precios
                                                                                                                                })
                                            }),
                                .totalesAlmacen = o.totalesAlmacen.Join(HeliosData.almacen, Function(tot) tot.idAlmacen, Function(al) al.idAlmacen, Function(tot, al) _
                                               New With {
                                               .almacen = al,
                                               .TotalesInv = tot
                                               }).Where(Function(i) i.almacen.tipo = "AF" And
                                                                    i.TotalesInv.cantidad > 0 And
                                                                    i.TotalesInv.idEmpresa = be.idEmpresa And
                                                                    i.TotalesInv.idEstablecimiento = be.idEstablecimiento And
                                                                    i.TotalesInv.status = 1)}).ToList
        'StatusArticulo.Activo

        '      Dim c = HeliosData.totalesAlmacen.Join(HeliosData.detalleitems, Function(post) post.idItem, Function(prod) prod.codigodetalle, Function(post, prod) _
        '                                       New With
        '                                       {
        '                                       .post = post,
        '                                       .prod = prod
        '                                       }).ToList



        '.Where(Function(d) d.descripcionItem.Contains(be.descripcionItem)).ToList


        'Dim consulta = HeliosData.detalleitems.Include(Function(o) o.detalleitem_equivalencias.Select(Function(y) y.detalleitemequivalencia_precios)).Where(Function(d) d.descripcionItem.StartsWith(be.descripcionItem)).ToList


        Dim obj As detalleitems
        Dim obEquivalencia As detalleitem_equivalencias
        Dim ListEquivalencia As List(Of detalleitem_equivalencias)
        Dim ListTotalesAlmacen As List(Of totalesAlmacen)
        Dim ListLotes As List(Of recursoCostoLote)
        Dim ListEquivalenciaPrecios As List(Of detalleitemequivalencia_precios)
        Dim ListaCatalogoPrecios As List(Of detalleitemequivalencia_catalogos)
        GetProductsBarCode = New List(Of detalleitems)

        For Each i In consulta

            ListEquivalencia = New List(Of detalleitem_equivalencias)
            ListTotalesAlmacen = New List(Of totalesAlmacen)
            ListLotes = New List(Of recursoCostoLote)

            For Each lt In i.Lotes
                ListLotes.Add(New recursoCostoLote With
                              {
                              .codigoLote = lt.codigoLote,
                              .nroLote = lt.nroLote,
                              .idDocumento = lt.idDocumento,
                              .idproyecto = lt.idproyecto,
                              .codigoProducto = lt.codigoProducto,
                              .moneda = lt.moneda,
                              .detalle = lt.detalle,
                              .cantidad = lt.cantidad,
                              .precioUnitarioIva = lt.precioUnitarioIva,
                              .fechaentrada = lt.fechaentrada,
                              .fechaProduccion = lt.fechaProduccion,
                              .fechaVcto = lt.fechaVcto,
                              .serie = lt.serie,
                              .sku = lt.sku,
                              .composicion = lt.composicion,
                              .productoSustentado = lt.productoSustentado
                              })
            Next

            For Each inv In i.totalesAlmacen

                ListTotalesAlmacen.Add(New totalesAlmacen With {
                                       .idMovimiento = inv.TotalesInv.idMovimiento,
                                       .idEmpresa = inv.TotalesInv.idEmpresa,
                                       .idEstablecimiento = inv.TotalesInv.idEstablecimiento,
                                       .idAlmacen = inv.TotalesInv.idAlmacen,
                                       .codigoLote = inv.TotalesInv.codigoLote,
                                       .descripcion = inv.TotalesInv.descripcion,
                                       .idUnidad = inv.TotalesInv.idUnidad,
                                       .unidadMedida = inv.TotalesInv.unidadMedida,
                                       .cantidad = inv.TotalesInv.cantidad,
                                       .cantidad2 = inv.TotalesInv.cantidad2,
                                       .importeSoles = inv.TotalesInv.importeSoles,
                                       .importeDolares = inv.TotalesInv.importeDolares,
                                       .status = inv.TotalesInv.status
                                       })
            Next

            For Each eq In i.detalleitem_equivalencias
                obEquivalencia = New detalleitem_equivalencias
                obEquivalencia.detalle = eq.Equivale.detalle
                obEquivalencia.contenido = eq.Equivale.contenido
                obEquivalencia.unidadComercial = eq.Equivale.unidadComercial
                obEquivalencia.equivalencia_id = eq.Equivale.equivalencia_id
                obEquivalencia.fraccionUnidad = eq.Equivale.fraccionUnidad
                obEquivalencia.estado = eq.Equivale.estado

                ListaCatalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
                For Each cat In eq.detalleitemequivalencia_catalogos
                    ListEquivalenciaPrecios = New List(Of detalleitemequivalencia_precios)
                    For Each prec In cat.Precios
                        ListEquivalenciaPrecios.Add(New detalleitemequivalencia_precios With
                                                    {
                                                    .rango_inicio = prec.rango_inicio,
                                                    .rango_final = prec.rango_final,
                                                    .precioCredito = prec.precioCredito,
                                                    .precio = prec.precio,
                                                    .precio_id = prec.precio_id,
                                                    .precioCode = prec.precioCode,
                                                    .estado = prec.estado
                                                    })
                    Next

                    ListaCatalogoPrecios.Add(New detalleitemequivalencia_catalogos With {
                                                 .idCatalogo = cat.Cat.idCatalogo,
                                                 .codigodetalle = cat.Cat.codigodetalle,
                                                 .equivalencia_id = cat.Cat.equivalencia_id,
                                                 .nombre_corto = cat.Cat.nombre_corto,
                                                 .nombre_largo = cat.Cat.nombre_largo,
                                                 .estado = cat.Cat.estado,
                                                 .predeterminado = cat.Cat.predeterminado,
                                                 .detalleitemequivalencia_precios = ListEquivalenciaPrecios
                                             })


                Next
                obEquivalencia.detalleitemequivalencia_catalogos = ListaCatalogoPrecios


                ListEquivalencia.Add(obEquivalencia)
            Next

            Dim category As item = Nothing
            If i.category IsNot Nothing Then
                category = New item With
                           {
                           .idItem = i.category.idItem,
                           .idPadre = i.category.idPadre,
                           .descripcion = i.category.descripcion,
                           .tipo = i.category.tipo,
                           .preciocompratipo = i.category.preciocompratipo,
                           .precioCompra = i.category.precioCompra,
                           .firstpercent = i.category.firstpercent,
                           .beforepercent = i.category.beforepercent
                           }
            End If

            obj = New detalleitems With
                {
                  .item = If(i.category IsNot Nothing, category, Nothing),
                .codigodetalle = i.detalleitems.codigodetalle,
                .idItem = i.detalleitems.idItem,
                .preciocompratipo = i.detalleitems.preciocompratipo,
                .precioCompra = i.detalleitems.precioCompra,
                .firstpercent = i.detalleitems.firstpercent,
                .beforepercent = i.detalleitems.beforepercent,
                .descripcionItem = i.detalleitems.descripcionItem,
                .unidad1 = i.detalleitems.unidad1,
                .tipoExistencia = i.detalleitems.tipoExistencia,
                .unidad2 = i.detalleitems.unidad2,
                .codigo = i.detalleitems.codigo,
                .origenProducto = i.detalleitems.origenProducto,
                .composicion = i.detalleitems.composicion,
                .fotoUrl = i.detalleitems.fotoUrl,
                .detalleitem_equivalencias = ListEquivalencia,
                .totalesAlmacen = ListTotalesAlmacen,
                .recursoCostoLote = ListLotes
            }
            GetProductsBarCode.Add(obj)
        Next

        Return GetProductsBarCode

    End Function

    Public Function GetProductosWithEquivalenciasSelCategory(be As detalleitems) As List(Of detalleitems)
        Dim consulta = HeliosData.detalleitems _
            .Include(Function(lot) lot.recursoCostoLote) _
            .Include(Function(ax) ax.detalleitems_conexo) _
            .Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
            .Where(Function(d) d.idItem = be.idItem And d.estado = "A") _
                                 .Select(Function(o) New With
                                 {
                                 .detalleitems = o,
                                 .detalleitems_conexo = o.detalleitems_conexo,
                                 .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                 .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                            {
                                            .Equivale = e,
                                            .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                            .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                {
                                                                                                                                .Cat = p,
                                                                                                                                .Precios = p.detalleitemequivalencia_precios
                                                                                                                                })
                                            })}).ToList

        'Dim consulta = HeliosData.detalleitems.Include(Function(o) o.detalleitem_equivalencias.Select(Function(y) y.detalleitemequivalencia_precios)).Where(Function(d) d.descripcionItem.StartsWith(be.descripcionItem)).ToList


        Dim obj As detalleitems
        Dim obEquivalencia As detalleitem_equivalencias
        Dim ListEquivalencia As List(Of detalleitem_equivalencias)
        Dim Listdetalleitems_conexo As List(Of detalleitems_conexo)
        Dim ListEquivalenciaPrecios As List(Of detalleitemequivalencia_precios)
        Dim ListaCatalogoPrecios As List(Of detalleitemequivalencia_catalogos)
        Dim ListaBeneficios As List(Of detalleitemequivalencia_beneficio)
        Dim ListaLotes As List(Of recursoCostoLote) = Nothing

        GetProductosWithEquivalenciasSelCategory = New List(Of detalleitems)

        For Each i In consulta
            Listdetalleitems_conexo = New List(Of detalleitems_conexo)
            For Each ax In i.detalleitems_conexo
                Listdetalleitems_conexo.Add(New detalleitems_conexo With {
                    .conexo_id = ax.conexo_id,
                    .codigodetalle = ax.codigodetalle,
                    .idProducto = ax.idProducto,
                    .detalle = ax.detalle,
                    .cantidad = ax.cantidad,
                    .equivalencia_id = ax.equivalencia_id,
                    .unidadComercial = ax.unidadComercial,
                    .fraccion = ax.fraccion,
                    .estado = ax.estado,
                    .vigencia = ax.vigencia,
                    .usuarioActualizacion = ax.usuarioActualizacion,
                    .fechaActualizacion = ax.fechaActualizacion
                                            })
            Next


            ListEquivalencia = New List(Of detalleitem_equivalencias)
            For Each eq In i.detalleitem_equivalencias
                obEquivalencia = New detalleitem_equivalencias
                obEquivalencia.codigodetalle = i.detalleitems.codigodetalle
                obEquivalencia.detalle = eq.Equivale.detalle
                obEquivalencia.unidadComercial = eq.Equivale.unidadComercial
                obEquivalencia.contenido = eq.Equivale.contenido
                obEquivalencia.equivalencia_id = eq.Equivale.equivalencia_id
                obEquivalencia.fraccionUnidad = eq.Equivale.fraccionUnidad
                obEquivalencia.estado = eq.Equivale.estado
                obEquivalencia.flag = eq.Equivale.flag
                obEquivalencia.contenido_neto = eq.Equivale.contenido_neto
                obEquivalencia.codigo = eq.Equivale.codigo

                ListaLotes = New List(Of recursoCostoLote)
                For Each lot In i.Lotes
                    Dim l As New recursoCostoLote With
                    {
                    .codigoLote = lot.codigoLote,
                    .nroLote = lot.nroLote,
                    .idDocumento = lot.idDocumento,
                    .idproyecto = lot.idproyecto,
                    .codigoProducto = lot.codigoProducto,
                    .moneda = lot.moneda,
                    .detalle = lot.detalle,
                    .cantidad = lot.cantidad,
                    .precioUnitarioIva = lot.precioUnitarioIva,
                    .fechaentrada = lot.fechaentrada,
                    .fechaProduccion = lot.fechaProduccion,
                    .fechaVcto = lot.fechaVcto,
                    .serie = lot.serie,
                    .sku = lot.sku,
                    .composicion = lot.composicion,
                    .productoSustentado = lot.productoSustentado
                    }
                    ListaLotes.Add(l)
                Next

                ListaBeneficios = New List(Of detalleitemequivalencia_beneficio)
                For Each ben In eq.detalleitemequivalencia_beneficio
                    ListaBeneficios.Add(New detalleitemequivalencia_beneficio With
                                        {
                                        .beneficio_id = ben.beneficio_id,
                                        .codigodetalle = ben.codigodetalle,
                                        .equivalencia_id = ben.equivalencia_id,
                                        .beneficio_detalle = ben.beneficio_detalle,
                                        .tipobeneficio = ben.tipobeneficio,
                                        .tipoafectacion = ben.tipoafectacion,
                                        .valor_evaluado = ben.valor_evaluado,
                                        .valor_conversion = ben.valor_conversion,
                                        .valor_beneficio = ben.valor_beneficio,
                                        .lote_id = ben.lote_id,
                                        .estado = ben.estado,
                                        .usuarioActualizacion = ben.usuarioActualizacion,
                                        .fechaActualizacion = ben.fechaActualizacion
                                        })
                Next


                ListaCatalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
                For Each cat In eq.detalleitemequivalencia_catalogos
                    ListEquivalenciaPrecios = New List(Of detalleitemequivalencia_precios)
                    For Each prec In cat.Precios
                        ListEquivalenciaPrecios.Add(New detalleitemequivalencia_precios With
                                                    {
                                                    .idCatalogo = cat.Cat.idCatalogo,
                                                    .rango_inicio = prec.rango_inicio,
                                                    .rango_final = prec.rango_final,
                                                    .precioCredito = prec.precioCredito,
                                                    .precioCreditoUSD = prec.precioCreditoUSD,
                                                    .precio = prec.precio,
                                                    .precioUSD = prec.precioUSD,
                                                    .precio_id = prec.precio_id,
                                                    .precioCode = prec.precioCode,
                                                    .estado = prec.estado
                                                    })
                    Next


                    ListaCatalogoPrecios.Add(New detalleitemequivalencia_catalogos With {
                                             .idCatalogo = cat.Cat.idCatalogo,
                                             .codigodetalle = cat.Cat.codigodetalle,
                                             .equivalencia_id = cat.Cat.equivalencia_id,
                                             .nombre_corto = cat.Cat.nombre_corto,
                                             .nombre_largo = cat.Cat.nombre_largo,
                                             .estado = cat.Cat.estado,
                                             .predeterminado = cat.Cat.predeterminado,
                                             .detalleitemequivalencia_precios = ListEquivalenciaPrecios
                                             })
                Next
                obEquivalencia.detalleitemequivalencia_catalogos = ListaCatalogoPrecios
                obEquivalencia.detalleitemequivalencia_beneficio = ListaBeneficios
                ListEquivalencia.Add(obEquivalencia)
            Next

            obj = New detalleitems With
            {
            .codigodetalle = i.detalleitems.codigodetalle,
            .estado = i.detalleitems.estado,
            .idItem = i.detalleitems.idItem,
            .descripcionItem = i.detalleitems.descripcionItem,
            .unidad1 = i.detalleitems.unidad1,
            .tipoExistencia = i.detalleitems.tipoExistencia,
            .unidad2 = i.detalleitems.unidad2,
            .codigo = i.detalleitems.codigo,
            .origenProducto = i.detalleitems.origenProducto,
            .composicion = i.detalleitems.composicion,
            .detalleitem_equivalencias = ListEquivalencia,
            .recursoCostoLote = ListaLotes,
            .tipoOtroImpuesto = i.detalleitems.tipoOtroImpuesto,
            .otroImpuesto = i.detalleitems.otroImpuesto,
            .detalleitems_conexo = Listdetalleitems_conexo
            }
            GetProductosWithEquivalenciasSelCategory.Add(obj)
        Next

    End Function

    Public Function GetProductosWithEquivalencias(be As detalleitems) As List(Of detalleitems)

        Dim consulta As Object = Nothing
        'Dim consulta = HeliosData.detalleitems _
        '    .Include(Function(cat) cat.item) _
        '    .Include(Function(lot) lot.recursoCostoLote) _
        '    .Include(Function(ax) ax.detalleitems_conexo) _
        '    .Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
        '    .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A") _
        '                         .Select(Function(o) New With
        '                         {
        '                         .detalleitems = o,
        '                         .category = o.item,
        '                         .detalleitems_conexo = o.detalleitems_conexo,
        '                         .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
        '                         .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
        '                                    {
        '                                    .Equivale = e,
        '                                    .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
        '                                    .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
        '                                                                                                                        {
        '                                                                                                                        .Cat = p,
        '                                                                                                                        .Precios = p.detalleitemequivalencia_precios
        '                                                                                                                        })
        '                                    })}).ToList




        Select Case be.typeConsult
            Case "NOMBRE"
                consulta = HeliosData.detalleitems _
            .Include(Function(c) c.item) _
            .Include(Function(lot) lot.recursoCostoLote) _
            .Include(Function(ax) ax.detalleitems_conexo) _
            .Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
            .Join(HeliosData.item, Function(prod1) CInt(prod1.unidad2), Function(subcat1) subcat1.idItem, Function(prod1, subcat1) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod1,
                                                                                             .subcategoria = subcat1
                                                                                             }) _
                .Join(HeliosData.item, Function(prod2) CInt(prod2.prod1.marcaRef), Function(marca) marca.idItem, Function(prod2, marca) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod2.prod1,
                                                                                             .subcategoria = prod2.subcategoria,
                                                                                             .marca = marca
                                                                                             }) _
                .Join(HeliosData.item, Function(prod3) CInt(prod3.prod1.idItem), Function(categ) categ.idItem, Function(prod3, categ) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod3.prod1,
                                                                                             .subcategoria = prod3.subcategoria,
                                                                                             .marca = prod3.marca,
                                                                                             .categ = categ
                                                                                             }) _
                .Join(HeliosData.item, Function(prod4) CInt(prod4.prod1.idClasificacion), Function(clas) clas.idItem, Function(prod4, clas) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod4.prod1,
                                                                                             .subcategoria = prod4.subcategoria,
                                                                                             .marca = prod4.marca,
                                                                                             .categ = prod4.categ,
                                                                                             .clas = clas
                                                                                             }) _
                .Join(HeliosData.item, Function(prod5) CInt(prod5.prod1.idCaracteristica), Function(pres) pres.idItem, Function(prod5, pres) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod5.prod1,
                                                                                             .subcategoria = prod5.subcategoria,
                                                                                             .marca = prod5.marca,
                                                                                             .categ = prod5.categ,
                                                                                             .clas = prod5.clas,
                                                                                             .pres = pres
                                                                                             }) _
            .Where(Function(d) d.prod1.descripcionItem.Contains(be.descripcionItem) And d.prod1.estado = "A" And d.prod1.idEmpresa = be.idEmpresa And d.prod1.idEstablecimiento = be.idEstablecimiento) _
                                 .Select(Function(o) New With
                                 {
                                 .detalleitems = o,
                                 .category = o.prod1.item,
                                 .detalleitems_conexo = o.prod1.detalleitems_conexo,
                                 .Lotes = o.prod1.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                 .detalleitem_equivalencias = o.prod1.detalleitem_equivalencias.Select(Function(e) New With
                                            {
                                            .Equivale = e,
                                            .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                            .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                {
                                                                                                                                .Cat = p,
                                                                                                                                .Precios = p.detalleitemequivalencia_precios
                                                                                                                                })
                                            })}).ToList

            Case "CATEGORIA"

                consulta = HeliosData.detalleitems _
                    .Include(Function(c) c.item) _
                    .Include(Function(lot) lot.recursoCostoLote) _
                    .Include(Function(ax) ax.detalleitems_conexo) _
                    .Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                    .Join(HeliosData.item, Function(prod1) CInt(prod1.unidad2), Function(subcat1) subcat1.idItem, Function(prod1, subcat1) _
                                                                                        New With
                                                                                        {
                                                                                        .prod1 = prod1,
                                                                                        .subcategoria = subcat1
                                                                                        }) _
                        .Join(HeliosData.item, Function(prod2) CInt(prod2.prod1.marcaRef), Function(marca) marca.idItem, Function(prod2, marca) _
                                                                                        New With
                                                                                        {
                                                                                        .prod1 = prod2.prod1,
                                                                                        .subcategoria = prod2.subcategoria,
                                                                                        .marca = marca
                                                                                        }) _
                .Join(HeliosData.item, Function(prod3) CInt(prod3.prod1.idItem), Function(categ) categ.idItem, Function(prod3, categ) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod3.prod1,
                                                                                             .subcategoria = prod3.subcategoria,
                                                                                             .marca = prod3.marca,
                                                                                             .categ = categ
                                                                                             }) _
                .Join(HeliosData.item, Function(prod4) CInt(prod4.prod1.idClasificacion), Function(clas) clas.idItem, Function(prod4, clas) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod4.prod1,
                                                                                             .subcategoria = prod4.subcategoria,
                                                                                             .marca = prod4.marca,
                                                                                             .categ = prod4.categ,
                                                                                             .clas = clas
                                                                                             }) _
                .Join(HeliosData.item, Function(prod5) CInt(prod5.prod1.idCaracteristica), Function(pres) pres.idItem, Function(prod5, pres) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod5.prod1,
                                                                                             .subcategoria = prod5.subcategoria,
                                                                                             .marca = prod5.marca,
                                                                                             .categ = prod5.categ,
                                                                                             .clas = prod5.clas,
                                                                                             .pres = pres
                                                                                             }) _
                       .Where(Function(d) d.prod1.idItem = (be.idItem) And d.prod1.estado = "A" And d.prod1.idEmpresa = be.idEmpresa And d.prod1.idEstablecimiento = be.idEstablecimiento) _
                            .Select(Function(o) New With
                            {
                            .detalleitems = o,
                            .category = o.prod1.item,
                            .detalleitems_conexo = o.prod1.detalleitems_conexo,
                            .Lotes = o.prod1.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                            .detalleitem_equivalencias = o.prod1.detalleitem_equivalencias.Select(Function(e) New With
                                       {
                                       .Equivale = e,
                                       .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                       .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                           {
                                                                                                                           .Cat = p,
                                                                                                                           .Precios = p.detalleitemequivalencia_precios
                                                                                                                           })
                                       })}).ToList


            Case "SUBCATEGORIA"
                consulta = HeliosData.detalleitems _
                    .Include(Function(c) c.item) _
                    .Include(Function(lot) lot.recursoCostoLote) _
                    .Include(Function(ax) ax.detalleitems_conexo) _
                    .Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                    .Join(HeliosData.item, Function(prod1) CInt(prod1.unidad2), Function(subcat1) subcat1.idItem, Function(prod1, subcat1) _
                                                                                        New With
                                                                                        {
                                                                                        .prod1 = prod1,
                                                                                        .subcategoria = subcat1
                                                                                        }) _
                        .Join(HeliosData.item, Function(prod2) CInt(prod2.prod1.marcaRef), Function(marca) marca.idItem, Function(prod2, marca) _
                                                                                        New With
                                                                                        {
                                                                                        .prod1 = prod2.prod1,
                                                                                        .subcategoria = prod2.subcategoria,
                                                                                        .marca = marca
                                                                                        }) _
                .Join(HeliosData.item, Function(prod3) CInt(prod3.prod1.idItem), Function(categ) categ.idItem, Function(prod3, categ) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod3.prod1,
                                                                                             .subcategoria = prod3.subcategoria,
                                                                                             .marca = prod3.marca,
                                                                                             .categ = categ
                                                                                             }) _
                .Join(HeliosData.item, Function(prod4) CInt(prod4.prod1.idClasificacion), Function(clas) clas.idItem, Function(prod4, clas) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod4.prod1,
                                                                                             .subcategoria = prod4.subcategoria,
                                                                                             .marca = prod4.marca,
                                                                                             .categ = prod4.categ,
                                                                                             .clas = clas
                                                                                             }) _
                .Join(HeliosData.item, Function(prod5) CInt(prod5.prod1.idCaracteristica), Function(pres) pres.idItem, Function(prod5, pres) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod5.prod1,
                                                                                             .subcategoria = prod5.subcategoria,
                                                                                             .marca = prod5.marca,
                                                                                             .categ = prod5.categ,
                                                                                             .clas = prod5.clas,
                                                                                             .pres = pres
                                                                                             }) _
                       .Where(Function(d) d.prod1.unidad2 = (be.unidad2) And d.prod1.estado = "A" And d.prod1.idEmpresa = be.idEmpresa And d.prod1.idEstablecimiento = be.idEstablecimiento) _
                            .Select(Function(o) New With
                            {
                            .detalleitems = o,
                            .category = o.prod1.item,
                            .detalleitems_conexo = o.prod1.detalleitems_conexo,
                            .Lotes = o.prod1.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                            .detalleitem_equivalencias = o.prod1.detalleitem_equivalencias.Select(Function(e) New With
                                       {
                                       .Equivale = e,
                                       .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                       .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                           {
                                                                                                                           .Cat = p,
                                                                                                                           .Precios = p.detalleitemequivalencia_precios
                                                                                                                           })
                                       })}).ToList
            Case "MARCA"

                consulta = HeliosData.detalleitems _
                    .Include(Function(c) c.item) _
                    .Include(Function(lot) lot.recursoCostoLote) _
                    .Include(Function(ax) ax.detalleitems_conexo) _
                    .Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                    .Join(HeliosData.item, Function(prod1) CInt(prod1.unidad2), Function(subcat1) subcat1.idItem, Function(prod1, subcat1) _
                                                                                        New With
                                                                                        {
                                                                                        .prod1 = prod1,
                                                                                        .subcategoria = subcat1
                                                                                        }) _
                        .Join(HeliosData.item, Function(prod2) CInt(prod2.prod1.marcaRef), Function(marca) marca.idItem, Function(prod2, marca) _
                                                                                        New With
                                                                                        {
                                                                                        .prod1 = prod2.prod1,
                                                                                        .subcategoria = prod2.subcategoria,
                                                                                        .marca = marca
                                                                                        }) _
                .Join(HeliosData.item, Function(prod3) CInt(prod3.prod1.idItem), Function(categ) categ.idItem, Function(prod3, categ) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod3.prod1,
                                                                                             .subcategoria = prod3.subcategoria,
                                                                                             .marca = prod3.marca,
                                                                                             .categ = categ
                                                                                             }) _
                .Join(HeliosData.item, Function(prod4) CInt(prod4.prod1.idClasificacion), Function(clas) clas.idItem, Function(prod4, clas) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod4.prod1,
                                                                                             .subcategoria = prod4.subcategoria,
                                                                                             .marca = prod4.marca,
                                                                                             .categ = prod4.categ,
                                                                                             .clas = clas
                                                                                             }) _
                .Join(HeliosData.item, Function(prod5) CInt(prod5.prod1.idCaracteristica), Function(pres) pres.idItem, Function(prod5, pres) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod5.prod1,
                                                                                             .subcategoria = prod5.subcategoria,
                                                                                             .marca = prod5.marca,
                                                                                             .categ = prod5.categ,
                                                                                             .clas = prod5.clas,
                                                                                             .pres = pres
                                                                                             }) _
                       .Where(Function(d) d.prod1.marcaRef = (be.marcaRef) And d.prod1.estado = "A" And d.prod1.idEmpresa = be.idEmpresa And d.prod1.idEstablecimiento = be.idEstablecimiento) _
                            .Select(Function(o) New With
                            {
                            .detalleitems = o,
                            .category = o.prod1.item,
                            .detalleitems_conexo = o.prod1.detalleitems_conexo,
                            .Lotes = o.prod1.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                            .detalleitem_equivalencias = o.prod1.detalleitem_equivalencias.Select(Function(e) New With
                                       {
                                       .Equivale = e,
                                       .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                       .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                           {
                                                                                                                           .Cat = p,
                                                                                                                           .Precios = p.detalleitemequivalencia_precios
                                                                                                                           })
                                       })}).ToList

            Case "TALLA"

                consulta = HeliosData.detalleitems _
                    .Include(Function(c) c.item) _
                    .Include(Function(lot) lot.recursoCostoLote) _
                    .Include(Function(ax) ax.detalleitems_conexo) _
                    .Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                    .Join(HeliosData.item, Function(prod1) CInt(prod1.unidad2), Function(subcat1) subcat1.idItem, Function(prod1, subcat1) _
                                                                                        New With
                                                                                        {
                                                                                        .prod1 = prod1,
                                                                                        .subcategoria = subcat1
                                                                                        }) _
                        .Join(HeliosData.item, Function(prod2) CInt(prod2.prod1.marcaRef), Function(marca) marca.idItem, Function(prod2, marca) _
                                                                                        New With
                                                                                        {
                                                                                        .prod1 = prod2.prod1,
                                                                                        .subcategoria = prod2.subcategoria,
                                                                                        .marca = marca
                                                                                        }) _
                .Join(HeliosData.item, Function(prod3) CInt(prod3.prod1.idItem), Function(categ) categ.idItem, Function(prod3, categ) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod3.prod1,
                                                                                             .subcategoria = prod3.subcategoria,
                                                                                             .marca = prod3.marca,
                                                                                             .categ = categ
                                                                                             }) _
                .Join(HeliosData.item, Function(prod4) CInt(prod4.prod1.idClasificacion), Function(clas) clas.idItem, Function(prod4, clas) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod4.prod1,
                                                                                             .subcategoria = prod4.subcategoria,
                                                                                             .marca = prod4.marca,
                                                                                             .categ = prod4.categ,
                                                                                             .clas = clas
                                                                                             }) _
                .Join(HeliosData.item, Function(prod5) CInt(prod5.prod1.idCaracteristica), Function(pres) pres.idItem, Function(prod5, pres) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod5.prod1,
                                                                                             .subcategoria = prod5.subcategoria,
                                                                                             .marca = prod5.marca,
                                                                                             .categ = prod5.categ,
                                                                                             .clas = prod5.clas,
                                                                                             .pres = pres
                                                                                             }) _
                       .Where(Function(d) d.prod1.talla = (be.talla) And d.prod1.estado = "A" And d.prod1.idEmpresa = be.idEmpresa And d.prod1.idEstablecimiento = be.idEstablecimiento) _
                            .Select(Function(o) New With
                            {
                            .detalleitems = o,
                            .category = o.prod1.item,
                            .detalleitems_conexo = o.prod1.detalleitems_conexo,
                            .Lotes = o.prod1.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                            .detalleitem_equivalencias = o.prod1.detalleitem_equivalencias.Select(Function(e) New With
                                       {
                                       .Equivale = e,
                                       .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                       .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                           {
                                                                                                                           .Cat = p,
                                                                                                                           .Precios = p.detalleitemequivalencia_precios
                                                                                                                           })
                                       })}).ToList

            Case "COLOR"

                consulta = HeliosData.detalleitems _
                    .Include(Function(c) c.item) _
                    .Include(Function(lot) lot.recursoCostoLote) _
                    .Include(Function(ax) ax.detalleitems_conexo) _
                    .Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                    .Join(HeliosData.item, Function(prod1) CInt(prod1.unidad2), Function(subcat1) subcat1.idItem, Function(prod1, subcat1) _
                                                                                        New With
                                                                                        {
                                                                                        .prod1 = prod1,
                                                                                        .subcategoria = subcat1
                                                                                        }) _
                        .Join(HeliosData.item, Function(prod2) CInt(prod2.prod1.marcaRef), Function(marca) marca.idItem, Function(prod2, marca) _
                                                                                        New With
                                                                                        {
                                                                                        .prod1 = prod2.prod1,
                                                                                        .subcategoria = prod2.subcategoria,
                                                                                        .marca = marca
                                                                                        }) _
                .Join(HeliosData.item, Function(prod3) CInt(prod3.prod1.idItem), Function(categ) categ.idItem, Function(prod3, categ) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod3.prod1,
                                                                                             .subcategoria = prod3.subcategoria,
                                                                                             .marca = prod3.marca,
                                                                                             .categ = categ
                                                                                             }) _
                .Join(HeliosData.item, Function(prod4) CInt(prod4.prod1.idClasificacion), Function(clas) clas.idItem, Function(prod4, clas) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod4.prod1,
                                                                                             .subcategoria = prod4.subcategoria,
                                                                                             .marca = prod4.marca,
                                                                                             .categ = prod4.categ,
                                                                                             .clas = clas
                                                                                             }) _
                .Join(HeliosData.item, Function(prod5) CInt(prod5.prod1.idCaracteristica), Function(pres) pres.idItem, Function(prod5, pres) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod5.prod1,
                                                                                             .subcategoria = prod5.subcategoria,
                                                                                             .marca = prod5.marca,
                                                                                             .categ = prod5.categ,
                                                                                             .clas = prod5.clas,
                                                                                             .pres = pres
                                                                                             }) _
                       .Where(Function(d) d.prod1.color = (be.color) And d.prod1.estado = "A" And d.prod1.idEmpresa = be.idEmpresa And d.prod1.idEstablecimiento = be.idEstablecimiento) _
                            .Select(Function(o) New With
                            {
                            .detalleitems = o,
                            .category = o.prod1.item,
                            .detalleitems_conexo = o.prod1.detalleitems_conexo,
                            .Lotes = o.prod1.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                            .detalleitem_equivalencias = o.prod1.detalleitem_equivalencias.Select(Function(e) New With
                                       {
                                       .Equivale = e,
                                       .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                       .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                           {
                                                                                                                           .Cat = p,
                                                                                                                           .Precios = p.detalleitemequivalencia_precios
                                                                                                                           })
                                       })}).ToList

            Case "ADICIONAL1"

                consulta = HeliosData.detalleitems _
                    .Include(Function(c) c.item) _
                    .Include(Function(lot) lot.recursoCostoLote) _
                    .Include(Function(ax) ax.detalleitems_conexo) _
                    .Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                    .Join(HeliosData.item, Function(prod1) CInt(prod1.unidad2), Function(subcat1) subcat1.idItem, Function(prod1, subcat1) _
                                                                                        New With
                                                                                        {
                                                                                        .prod1 = prod1,
                                                                                        .subcategoria = subcat1
                                                                                        }) _
                        .Join(HeliosData.item, Function(prod2) CInt(prod2.prod1.marcaRef), Function(marca) marca.idItem, Function(prod2, marca) _
                                                                                        New With
                                                                                        {
                                                                                        .prod1 = prod2.prod1,
                                                                                        .subcategoria = prod2.subcategoria,
                                                                                        .marca = marca
                                                                                        }) _
                .Join(HeliosData.item, Function(prod3) CInt(prod3.prod1.idItem), Function(categ) categ.idItem, Function(prod3, categ) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod3.prod1,
                                                                                             .subcategoria = prod3.subcategoria,
                                                                                             .marca = prod3.marca,
                                                                                             .categ = categ
                                                                                             }) _
                .Join(HeliosData.item, Function(prod4) CInt(prod4.prod1.idClasificacion), Function(clas) clas.idItem, Function(prod4, clas) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod4.prod1,
                                                                                             .subcategoria = prod4.subcategoria,
                                                                                             .marca = prod4.marca,
                                                                                             .categ = prod4.categ,
                                                                                             .clas = clas
                                                                                             }) _
                .Join(HeliosData.item, Function(prod5) CInt(prod5.prod1.idCaracteristica), Function(pres) pres.idItem, Function(prod5, pres) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod5.prod1,
                                                                                             .subcategoria = prod5.subcategoria,
                                                                                             .marca = prod5.marca,
                                                                                             .categ = prod5.categ,
                                                                                             .clas = prod5.clas,
                                                                                             .pres = pres
                                                                                             }) _
                       .Where(Function(d) d.prod1.electricidad = (be.electricidad) And d.prod1.estado = "A" And d.prod1.idEmpresa = be.idEmpresa And d.prod1.idEstablecimiento = be.idEstablecimiento) _
                            .Select(Function(o) New With
                            {
                            .detalleitems = o,
                            .category = o.prod1.item,
                            .detalleitems_conexo = o.prod1.detalleitems_conexo,
                            .Lotes = o.prod1.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                            .detalleitem_equivalencias = o.prod1.detalleitem_equivalencias.Select(Function(e) New With
                                       {
                                       .Equivale = e,
                                       .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                       .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                           {
                                                                                                                           .Cat = p,
                                                                                                                           .Precios = p.detalleitemequivalencia_precios
                                                                                                                           })
                                       })}).ToList

            Case "ADICIONAL2"

                consulta = HeliosData.detalleitems _
                    .Include(Function(c) c.item) _
                    .Include(Function(lot) lot.recursoCostoLote) _
                    .Include(Function(ax) ax.detalleitems_conexo) _
                    .Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                    .Join(HeliosData.item, Function(prod1) CInt(prod1.unidad2), Function(subcat1) subcat1.idItem, Function(prod1, subcat1) _
                                                                                        New With
                                                                                        {
                                                                                        .prod1 = prod1,
                                                                                        .subcategoria = subcat1
                                                                                        }) _
                        .Join(HeliosData.item, Function(prod2) CInt(prod2.prod1.marcaRef), Function(marca) marca.idItem, Function(prod2, marca) _
                                                                                        New With
                                                                                        {
                                                                                        .prod1 = prod2.prod1,
                                                                                        .subcategoria = prod2.subcategoria,
                                                                                        .marca = marca
                                                                                        }) _
                .Join(HeliosData.item, Function(prod3) CInt(prod3.prod1.idItem), Function(categ) categ.idItem, Function(prod3, categ) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod3.prod1,
                                                                                             .subcategoria = prod3.subcategoria,
                                                                                             .marca = prod3.marca,
                                                                                             .categ = categ
                                                                                             }) _
                .Join(HeliosData.item, Function(prod4) CInt(prod4.prod1.idClasificacion), Function(clas) clas.idItem, Function(prod4, clas) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod4.prod1,
                                                                                             .subcategoria = prod4.subcategoria,
                                                                                             .marca = prod4.marca,
                                                                                             .categ = prod4.categ,
                                                                                             .clas = clas
                                                                                             }) _
                .Join(HeliosData.item, Function(prod5) CInt(prod5.prod1.idCaracteristica), Function(pres) pres.idItem, Function(prod5, pres) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod5.prod1,
                                                                                             .subcategoria = prod5.subcategoria,
                                                                                             .marca = prod5.marca,
                                                                                             .categ = prod5.categ,
                                                                                             .clas = prod5.clas,
                                                                                             .pres = pres
                                                                                             }) _
                       .Where(Function(d) d.prod1.transmision = (be.transmision) And d.prod1.estado = "A" And d.prod1.idEmpresa = be.idEmpresa And d.prod1.idEstablecimiento = be.idEstablecimiento) _
                            .Select(Function(o) New With
                            {
                            .detalleitems = o,
                            .category = o.prod1.item,
                            .detalleitems_conexo = o.prod1.detalleitems_conexo,
                            .Lotes = o.prod1.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                            .detalleitem_equivalencias = o.prod1.detalleitem_equivalencias.Select(Function(e) New With
                                       {
                                       .Equivale = e,
                                       .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                       .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                           {
                                                                                                                           .Cat = p,
                                                                                                                           .Precios = p.detalleitemequivalencia_precios
                                                                                                                           })
                                       })}).ToList



            Case "PRESENTACION/MODELO"

                consulta = HeliosData.detalleitems _
                   .Include(Function(c) c.item) _
                   .Include(Function(lot) lot.recursoCostoLote) _
                   .Include(Function(ax) ax.detalleitems_conexo) _
                   .Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                   .Join(HeliosData.item, Function(prod1) CInt(prod1.unidad2), Function(subcat1) subcat1.idItem, Function(prod1, subcat1) _
                                                                                       New With
                                                                                       {
                                                                                       .prod1 = prod1,
                                                                                       .subcategoria = subcat1
                                                                                       }) _
                       .Join(HeliosData.item, Function(prod2) CInt(prod2.prod1.marcaRef), Function(marca) marca.idItem, Function(prod2, marca) _
                                                                                       New With
                                                                                       {
                                                                                       .prod1 = prod2.prod1,
                                                                                       .subcategoria = prod2.subcategoria,
                                                                                       .marca = marca
                                                                                       }) _
               .Join(HeliosData.item, Function(prod3) CInt(prod3.prod1.idItem), Function(categ) categ.idItem, Function(prod3, categ) _
                                                                                            New With
                                                                                            {
                                                                                            .prod1 = prod3.prod1,
                                                                                            .subcategoria = prod3.subcategoria,
                                                                                            .marca = prod3.marca,
                                                                                            .categ = categ
                                                                                            }) _
               .Join(HeliosData.item, Function(prod4) CInt(prod4.prod1.idClasificacion), Function(clas) clas.idItem, Function(prod4, clas) _
                                                                                            New With
                                                                                            {
                                                                                            .prod1 = prod4.prod1,
                                                                                            .subcategoria = prod4.subcategoria,
                                                                                            .marca = prod4.marca,
                                                                                            .categ = prod4.categ,
                                                                                            .clas = clas
                                                                                            }) _
               .Join(HeliosData.item, Function(prod5) CInt(prod5.prod1.idCaracteristica), Function(pres) pres.idItem, Function(prod5, pres) _
                                                                                            New With
                                                                                            {
                                                                                            .prod1 = prod5.prod1,
                                                                                            .subcategoria = prod5.subcategoria,
                                                                                            .marca = prod5.marca,
                                                                                            .categ = prod5.categ,
                                                                                            .clas = prod5.clas,
                                                                                            .pres = pres
                                                                                            }) _
                      .Where(Function(d) d.prod1.presentacion = (be.presentacion) And d.prod1.estado = "A" And d.prod1.idEmpresa = be.idEmpresa And d.prod1.idEstablecimiento = be.idEstablecimiento) _
                           .Select(Function(o) New With
                           {
                           .detalleitems = o,
                           .category = o.prod1.item,
                           .detalleitems_conexo = o.prod1.detalleitems_conexo,
                           .Lotes = o.prod1.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                           .detalleitem_equivalencias = o.prod1.detalleitem_equivalencias.Select(Function(e) New With
                                      {
                                      .Equivale = e,
                                      .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                      .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                          {
                                                                                                                          .Cat = p,
                                                                                                                          .Precios = p.detalleitemequivalencia_precios
                                                                                                                          })
                                      })}).ToList

            Case "CODIGO INTERNO"

                consulta = HeliosData.detalleitems _
                    .Include(Function(c) c.item) _
                    .Include(Function(lot) lot.recursoCostoLote) _
                    .Include(Function(ax) ax.detalleitems_conexo) _
                    .Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                    .Join(HeliosData.item, Function(prod1) CInt(prod1.unidad2), Function(subcat1) subcat1.idItem, Function(prod1, subcat1) _
                                                                                        New With
                                                                                        {
                                                                                        .prod1 = prod1,
                                                                                        .subcategoria = subcat1
                                                                                        }) _
                        .Join(HeliosData.item, Function(prod2) CInt(prod2.prod1.marcaRef), Function(marca) marca.idItem, Function(prod2, marca) _
                                                                                        New With
                                                                                        {
                                                                                        .prod1 = prod2.prod1,
                                                                                        .subcategoria = prod2.subcategoria,
                                                                                        .marca = marca
                                                                                        }) _
                .Join(HeliosData.item, Function(prod3) CInt(prod3.prod1.idItem), Function(categ) categ.idItem, Function(prod3, categ) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod3.prod1,
                                                                                             .subcategoria = prod3.subcategoria,
                                                                                             .marca = prod3.marca,
                                                                                             .categ = categ
                                                                                             }) _
                .Join(HeliosData.item, Function(prod4) CInt(prod4.prod1.idClasificacion), Function(clas) clas.idItem, Function(prod4, clas) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod4.prod1,
                                                                                             .subcategoria = prod4.subcategoria,
                                                                                             .marca = prod4.marca,
                                                                                             .categ = prod4.categ,
                                                                                             .clas = clas
                                                                                             }) _
                .Join(HeliosData.item, Function(prod5) CInt(prod5.prod1.idCaracteristica), Function(pres) pres.idItem, Function(prod5, pres) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod5.prod1,
                                                                                             .subcategoria = prod5.subcategoria,
                                                                                             .marca = prod5.marca,
                                                                                             .categ = prod5.categ,
                                                                                             .clas = prod5.clas,
                                                                                             .pres = pres
                                                                                             }) _
                       .Where(Function(d) d.prod1.codigoInterno = (be.codigo) And d.prod1.estado = "A" And d.prod1.idEmpresa = be.idEmpresa And d.prod1.idEstablecimiento = be.idEstablecimiento) _
                            .Select(Function(o) New With
                            {
                            .detalleitems = o,
                            .category = o.prod1.item,
                            .detalleitems_conexo = o.prod1.detalleitems_conexo,
                            .Lotes = o.prod1.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                            .detalleitem_equivalencias = o.prod1.detalleitem_equivalencias.Select(Function(e) New With
                                       {
                                       .Equivale = e,
                                       .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                       .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                           {
                                                                                                                           .Cat = p,
                                                                                                                           .Precios = p.detalleitemequivalencia_precios
                                                                                                                           })
                                       })}).ToList


            Case "PESO"
            Case "CODIGO BARRA"
                consulta = HeliosData.detalleitems _
                    .Include(Function(c) c.item) _
                    .Include(Function(lot) lot.recursoCostoLote) _
                    .Include(Function(ax) ax.detalleitems_conexo) _
                    .Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
                    .Join(HeliosData.item, Function(prod1) CInt(prod1.unidad2), Function(subcat1) subcat1.idItem, Function(prod1, subcat1) _
                                                                                        New With
                                                                                        {
                                                                                        .prod1 = prod1,
                                                                                        .subcategoria = subcat1
                                                                                        }) _
                        .Join(HeliosData.item, Function(prod2) CInt(prod2.prod1.marcaRef), Function(marca) marca.idItem, Function(prod2, marca) _
                                                                                        New With
                                                                                        {
                                                                                        .prod1 = prod2.prod1,
                                                                                        .subcategoria = prod2.subcategoria,
                                                                                        .marca = marca
                                                                                        }) _
                .Join(HeliosData.item, Function(prod3) CInt(prod3.prod1.idItem), Function(categ) categ.idItem, Function(prod3, categ) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod3.prod1,
                                                                                             .subcategoria = prod3.subcategoria,
                                                                                             .marca = prod3.marca,
                                                                                             .categ = categ
                                                                                             }) _
                .Join(HeliosData.item, Function(prod4) CInt(prod4.prod1.idClasificacion), Function(clas) clas.idItem, Function(prod4, clas) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod4.prod1,
                                                                                             .subcategoria = prod4.subcategoria,
                                                                                             .marca = prod4.marca,
                                                                                             .categ = prod4.categ,
                                                                                             .clas = clas
                                                                                             }) _
                .Join(HeliosData.item, Function(prod5) CInt(prod5.prod1.idCaracteristica), Function(pres) pres.idItem, Function(prod5, pres) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod5.prod1,
                                                                                             .subcategoria = prod5.subcategoria,
                                                                                             .marca = prod5.marca,
                                                                                             .categ = prod5.categ,
                                                                                             .clas = prod5.clas,
                                                                                             .pres = pres
                                                                                             }) _
                       .Where(Function(d) d.prod1.codigo = (be.codigo) And d.prod1.estado = "A" And d.prod1.idEmpresa = be.idEmpresa And d.prod1.idEstablecimiento = be.idEstablecimiento) _
                            .Select(Function(o) New With
                            {
                            .detalleitems = o,
                            .category = o.prod1.item,
                            .detalleitems_conexo = o.prod1.detalleitems_conexo,
                            .Lotes = o.prod1.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                            .detalleitem_equivalencias = o.prod1.detalleitem_equivalencias.Select(Function(e) New With
                                       {
                                       .Equivale = e,
                                       .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                       .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                           {
                                                                                                                           .Cat = p,
                                                                                                                           .Precios = p.detalleitemequivalencia_precios
                                                                                                                           })
                                       })}).ToList


            Case Else 'ELSE PRODUCTO
                consulta = HeliosData.detalleitems _
           .Include(Function(c) c.item) _
           .Include(Function(lot) lot.recursoCostoLote) _
           .Include(Function(ax) ax.detalleitems_conexo) _
           .Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
           .Join(HeliosData.item, Function(prod1) CInt(prod1.unidad2), Function(subcat1) subcat1.idItem, Function(prod1, subcat1) _
                                                                                            New With
                                                                                            {
                                                                                            .prod1 = prod1,
                                                                                            .subcategoria = subcat1
                                                                                            }) _
           .Join(HeliosData.item, Function(prod2) CInt(prod2.prod1.marcaRef), Function(marca) marca.idItem, Function(prod2, marca) _
                                                                                            New With
                                                                                            {
                                                                                            .prod1 = prod2.prod1,
                                                                                            .subcategoria = prod2.subcategoria,
                                                                                            .marca = marca
                                                                                            }) _
                .Join(HeliosData.item, Function(prod3) CInt(prod3.prod1.idItem), Function(categ) categ.idItem, Function(prod3, categ) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod3.prod1,
                                                                                             .subcategoria = prod3.subcategoria,
                                                                                             .marca = prod3.marca,
                                                                                             .categ = categ
                                                                                             }) _
                .Join(HeliosData.item, Function(prod4) CInt(prod4.prod1.idClasificacion), Function(clas) clas.idItem, Function(prod4, clas) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod4.prod1,
                                                                                             .subcategoria = prod4.subcategoria,
                                                                                             .marca = prod4.marca,
                                                                                             .categ = prod4.categ,
                                                                                             .clas = clas
                                                                                             }) _
                .Join(HeliosData.item, Function(prod5) CInt(prod5.prod1.idCaracteristica), Function(pres) pres.idItem, Function(prod5, pres) _
                                                                                             New With
                                                                                             {
                                                                                             .prod1 = prod5.prod1,
                                                                                             .subcategoria = prod5.subcategoria,
                                                                                             .marca = prod5.marca,
                                                                                             .categ = prod5.categ,
                                                                                             .clas = prod5.clas,
                                                                                             .pres = pres
                                                                                             }) _
           .Where(Function(d) d.prod1.descripcionItem.Contains(be.descripcionItem) And d.prod1.estado = "A" And d.prod1.idEmpresa = be.idEmpresa And d.prod1.idEstablecimiento = be.idEstablecimiento) _
                                .Select(Function(o) New With
                                {
                                .detalleitems = o,
                                .category = o.prod1.item,
                                .detalleitems_conexo = o.prod1.detalleitems_conexo,
                                .Lotes = o.prod1.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                .detalleitem_equivalencias = o.prod1.detalleitem_equivalencias.Select(Function(e) New With
                                           {
                                           .Equivale = e,
                                           .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                           .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                               {
                                                                                                                               .Cat = p,
                                                                                                                               .Precios = p.detalleitemequivalencia_precios
                                                                                                                               })
                                           })}).ToList
        End Select




        Dim obj As detalleitems
        Dim obEquivalencia As detalleitem_equivalencias
        Dim ListEquivalencia As List(Of detalleitem_equivalencias)
        Dim Listdetalleitems_conexo As List(Of detalleitems_conexo)
        Dim ListEquivalenciaPrecios As List(Of detalleitemequivalencia_precios)
        Dim ListaCatalogoPrecios As List(Of detalleitemequivalencia_catalogos)
        Dim ListaBeneficios As List(Of detalleitemequivalencia_beneficio)
        Dim ListaLotes As List(Of recursoCostoLote) = Nothing

        GetProductosWithEquivalencias = New List(Of detalleitems)

        For Each i In consulta
            Listdetalleitems_conexo = New List(Of detalleitems_conexo)
            For Each ax In i.detalleitems_conexo
                Listdetalleitems_conexo.Add(New detalleitems_conexo With {
                    .conexo_id = ax.conexo_id,
                    .codigodetalle = ax.codigodetalle,
                    .idProducto = ax.idProducto,
                    .detalle = ax.detalle,
                    .cantidad = ax.cantidad,
                    .equivalencia_id = ax.equivalencia_id,
                    .unidadComercial = ax.unidadComercial,
                    .fraccion = ax.fraccion,
                    .estado = ax.estado,
                    .vigencia = ax.vigencia,
                    .usuarioActualizacion = ax.usuarioActualizacion,
                    .fechaActualizacion = ax.fechaActualizacion
                                            })
            Next


            ListEquivalencia = New List(Of detalleitem_equivalencias)
            For Each eq In i.detalleitem_equivalencias
                obEquivalencia = New detalleitem_equivalencias
                obEquivalencia.codigodetalle = i.detalleitems.prod1.codigodetalle
                obEquivalencia.detalle = eq.Equivale.detalle
                obEquivalencia.unidadComercial = eq.Equivale.unidadComercial
                obEquivalencia.contenido = eq.Equivale.contenido
                obEquivalencia.equivalencia_id = eq.Equivale.equivalencia_id
                obEquivalencia.fraccionUnidad = eq.Equivale.fraccionUnidad
                obEquivalencia.estado = eq.Equivale.estado
                obEquivalencia.flag = eq.Equivale.flag
                obEquivalencia.contenido_neto = eq.Equivale.contenido_neto
                obEquivalencia.codigo = eq.equivale.codigo

                ListaLotes = New List(Of recursoCostoLote)
                For Each lot In i.Lotes
                    Dim l As New recursoCostoLote With
                {
                .codigoLote = lot.codigoLote,
                .nroLote = lot.nroLote,
                .idDocumento = lot.idDocumento,
                .idproyecto = lot.idproyecto,
                .codigoProducto = lot.codigoProducto,
                .moneda = lot.moneda,
                .detalle = lot.detalle,
                .cantidad = lot.cantidad,
                .precioUnitarioIva = lot.precioUnitarioIva,
                .fechaentrada = lot.fechaentrada,
                .fechaProduccion = lot.fechaProduccion,
                .fechaVcto = lot.fechaVcto,
                .serie = lot.serie,
                .sku = lot.sku,
                .composicion = lot.composicion,
                .productoSustentado = lot.productoSustentado
                }
                    ListaLotes.Add(l)
                Next

                ListaBeneficios = New List(Of detalleitemequivalencia_beneficio)
                For Each ben In eq.detalleitemequivalencia_beneficio
                    ListaBeneficios.Add(New detalleitemequivalencia_beneficio With
                                    {
                                    .beneficio_id = ben.beneficio_id,
                                    .codigodetalle = ben.codigodetalle,
                                    .equivalencia_id = ben.equivalencia_id,
                                    .beneficio_detalle = ben.beneficio_detalle,
                                    .tipobeneficio = ben.tipobeneficio,
                                    .tipoafectacion = ben.tipoafectacion,
                                    .valor_evaluado = ben.valor_evaluado,
                                    .valor_conversion = ben.valor_conversion,
                                    .valor_beneficio = ben.valor_beneficio,
                                    .lote_id = ben.lote_id,
                                    .estado = ben.estado,
                                    .usuarioActualizacion = ben.usuarioActualizacion,
                                    .fechaActualizacion = ben.fechaActualizacion
                                    })
                Next


                ListaCatalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
                For Each cat In eq.detalleitemequivalencia_catalogos
                    ListEquivalenciaPrecios = New List(Of detalleitemequivalencia_precios)
                    For Each prec In cat.Precios
                        ListEquivalenciaPrecios.Add(New detalleitemequivalencia_precios With
                                                {
                                                .idCatalogo = cat.Cat.idCatalogo,
                                                .rango_inicio = prec.rango_inicio,
                                                .rango_final = prec.rango_final,
                                                .precioCredito = prec.precioCredito,
                                                .precioCreditoUSD = prec.precioCreditoUSD,
                                                .precio = prec.precio,
                                                .precioUSD = prec.precioUSD,
                                                .precio_id = prec.precio_id,
                                                .precioCode = prec.precioCode,
                                                .estado = prec.estado
                                                })
                    Next


                    ListaCatalogoPrecios.Add(New detalleitemequivalencia_catalogos With {
                                         .idCatalogo = cat.Cat.idCatalogo,
                                         .codigodetalle = cat.Cat.codigodetalle,
                                         .equivalencia_id = cat.Cat.equivalencia_id,
                                         .nombre_corto = cat.Cat.nombre_corto,
                                         .nombre_largo = cat.Cat.nombre_largo,
                                         .estado = cat.Cat.estado,
                                         .predeterminado = cat.Cat.predeterminado,
                                         .detalleitemequivalencia_precios = ListEquivalenciaPrecios
                                         })
                Next
                obEquivalencia.detalleitemequivalencia_catalogos = ListaCatalogoPrecios
                obEquivalencia.detalleitemequivalencia_beneficio = ListaBeneficios
                ListEquivalencia.Add(obEquivalencia)
            Next
            Dim category As item = Nothing
            If i.category IsNot Nothing Then
                category = New item With
                {
                .idItem = i.category.idItem,
                .idPadre = i.category.idPadre,
                .idEmpresa = i.category.idEmpresa,
                .idEstablecimiento = i.category.idEstablecimiento,
                .fechaIngreso = i.category.fechaIngreso,
                .descripcion = i.category.descripcion,
                .tipo = i.category.tipo,
                .preciocompratipo = i.category.preciocompratipo,
                .precioCompra = i.category.precioCompra,
                .firstpercent = i.category.firstpercent,
                .beforepercent = i.category.beforepercent
                }
            End If

            'obj = New detalleitems With
            '{
            '.item = category,
            '.codigodetalle = i.detalleitems.codigodetalle,
            '.estado = i.detalleitems.estado,
            '.idItem = i.detalleitems.idItem,
            '.descripcionItem = i.detalleitems.descripcionItem,
            '.unidad1 = i.detalleitems.unidad1,
            '.tipoExistencia = i.detalleitems.tipoExistencia,
            '.unidad2 = i.detalleitems.unidad2,
            '.codigo = i.detalleitems.codigo,
            '.origenProducto = i.detalleitems.origenProducto,
            '.composicion = i.detalleitems.composicion,
            '.detalleitem_equivalencias = ListEquivalencia,
            '.recursoCostoLote = ListaLotes,
            '.tipoOtroImpuesto = i.detalleitems.tipoOtroImpuesto,
            '.otroImpuesto = i.detalleitems.otroImpuesto,
            '.precioCompra = i.detalleitems.precioCompra,
            '.preciocompratipo = i.detalleitems.preciocompratipo,
            '.firstpercent = i.detalleitems.firstpercent,
            '.beforepercent = i.detalleitems.beforepercent,
            '.detalleitems_conexo = Listdetalleitems_conexo
            '}
            obj = New detalleitems With
            {
            .CustomSubCategoria = New item With
            {
            .idItem = i.detalleitems.subcategoria.idItem,
            .descripcion = i.detalleitems.subcategoria.descripcion,
            .idPadre = i.detalleitems.subcategoria.idPadre
            },
            .customMarca = New item With
            {
            .idItem = i.detalleitems.marca.idItem,
            .descripcion = i.detalleitems.marca.descripcion,
            .idPadre = i.detalleitems.marca.idPadre
            },
            .customCategoria = New item With
            {
            .idItem = i.detalleitems.categ.idItem,
            .descripcion = i.detalleitems.categ.descripcion,
            .idPadre = i.detalleitems.categ.idPadre
            },
            .customClasificacion = New item With
            {
            .idItem = i.detalleitems.clas.idItem,
            .descripcion = i.detalleitems.clas.descripcion,
            .idPadre = i.detalleitems.clas.idPadre
            },
            .customPresentacion = New item With
            {
            .idItem = i.detalleitems.pres.idItem,
            .descripcion = i.detalleitems.pres.descripcion,
            .idPadre = i.detalleitems.pres.idPadre
            },
            .item = category,
            .codigodetalle = i.detalleitems.prod1.codigodetalle,
            .estado = i.detalleitems.prod1.estado,
            .idItem = i.detalleitems.prod1.idItem,
            .descripcionItem = i.detalleitems.prod1.descripcionItem,
            .unidad1 = i.detalleitems.prod1.unidad1,
            .tipoExistencia = i.detalleitems.prod1.tipoExistencia,
            .unidad2 = i.detalleitems.prod1.unidad2,
            .codigo = i.detalleitems.prod1.codigo,
            .origenProducto = i.detalleitems.prod1.origenProducto,
            .composicion = i.detalleitems.prod1.composicion,
            .detalleitem_equivalencias = ListEquivalencia,
            .recursoCostoLote = ListaLotes,
            .tipoOtroImpuesto = i.detalleitems.prod1.tipoOtroImpuesto,
            .otroImpuesto = i.detalleitems.prod1.otroImpuesto,
            .marcaRef = i.detalleitems.prod1.marcaRef,
            .color = i.detalleitems.prod1.color,
            .talla = i.detalleitems.prod1.talla,
            .Peso = i.detalleitems.prod1.Peso,
            .tipoBien = i.detalleitems.prod1.tipoBien,
            .transmision = i.detalleitems.prod1.transmision,
            .electricidad = i.detalleitems.prod1.electricidad,
            .codigoInterno = i.detalleitems.prod1.codigoInterno,
            .detalleitems_conexo = Listdetalleitems_conexo
            }
            GetProductosWithEquivalencias.Add(obj)
        Next
        Return GetProductosWithEquivalencias
    End Function

    'Public Function GetProductosWithEquivalencias(be As detalleitems) As List(Of detalleitems)
    '    'Include("detalleitem_equivalencias").Include("detalleitemequivalencia_precios")

    '    'Dim results = warmCountries.Join(europeanCountries, Function(warm) warm, Function(european) european, Function(warm, european) warm)


    '    'INNER JOIN
    '    'Dim c = HeliosData.totalesAlmacen.Join(HeliosData.detalleitems, Function(post) post.idItem, Function(prod) prod.codigodetalle, Function(post, prod) _
    '    '                                       New With
    '    '                                       {
    '    '                                       .post = post,
    '    '                                       .prod = prod
    '    '                                       }).ToList

    '    'LAMBDA MULTIPLE INLCUIDE
    '    'Dim result = HeliosData.detalleitems _
    '    '    .Include(Function(o) o.detalleitem_equivalencias _
    '    '    .Select(Function(y) y.detalleitemequivalencia_precios)) _
    '    '    .GroupJoin(HeliosData.totalesAlmacen, Function(lang) lang.codigodetalle, Function(pers) pers.idItem,
    '    '         Function(lang, ps) New With
    '    '         {
    '    '         .CodigoDetalle = lang.codigodetalle,
    '    '         .DescripcionProducto = lang.descripcionItem,
    '    '         .Codigo = lang.codigo,
    '    '         .unidad = lang.unidad1,
    '    '         .item = lang.item,
    '    '         .Stock = CType(ps.Sum(Function(p) p.cantidad), Decimal?),
    '    '         .Persons = ps
    '    '             }
    '    '         ).ToList

    '    '   Dim consulta = HeliosData.detalleitems.Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))).Where(Function(d) d.descripcionItem.Contains(be.descripcionItem)).ToList


    '    '   Dim consulta = HeliosData.detalleitems.Include(Function(j) j.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).Select(Function(lote) lote).Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))).Where(Function(d) d.descripcionItem.Contains(be.descripcionItem)).ToList


    '    Dim consulta = HeliosData.detalleitems _
    '        .Include(Function(lot) lot.recursoCostoLote) _
    '        .Include(Function(o) o.detalleitem_equivalencias.Select(
    '        Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
    '                             .Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And d.estado = "A") _
    '                             .Select(Function(o) New With
    '                             {
    '                             .detalleitems = o,
    '                             .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
    '                             .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
    '                                        {
    '                                        .Equivale = e,
    '                                        .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
    '                                                                                                                            {
    '                                                                                                                            .Cat = p,
    '                                                                                                                            .Precios = p.detalleitemequivalencia_precios
    '                                                                                                                            })
    '                                        })}).ToList

    '    'Dim consulta = HeliosData.detalleitems.Include(Function(o) o.detalleitem_equivalencias.Select(Function(y) y.detalleitemequivalencia_precios)).Where(Function(d) d.descripcionItem.StartsWith(be.descripcionItem)).ToList


    '    Dim obj As detalleitems
    '    Dim obEquivalencia As detalleitem_equivalencias
    '    Dim ListEquivalencia As List(Of detalleitem_equivalencias)
    '    Dim ListEquivalenciaPrecios As List(Of detalleitemequivalencia_precios)
    '    Dim ListaCatalogoPrecios As List(Of detalleitemequivalencia_catalogos)
    '    Dim ListaLotes As List(Of recursoCostoLote) = Nothing

    '    GetProductosWithEquivalencias = New List(Of detalleitems)

    '    For Each i In consulta

    '        ListEquivalencia = New List(Of detalleitem_equivalencias)
    '        For Each eq In i.detalleitem_equivalencias
    '            obEquivalencia = New detalleitem_equivalencias
    '            obEquivalencia.codigodetalle = i.codigodetalle
    '            obEquivalencia.detalle = eq.detalle
    '            obEquivalencia.unidadComercial = eq.unidadComercial
    '            obEquivalencia.contenido = eq.contenido
    '            obEquivalencia.equivalencia_id = eq.equivalencia_id
    '            obEquivalencia.fraccionUnidad = eq.fraccionUnidad
    '            obEquivalencia.estado = eq.estado
    '            obEquivalencia.contenido_neto = eq.contenido_neto

    '            ListaLotes = New List(Of recursoCostoLote)
    '            For Each lot In i.recursoCostoLote
    '                ListaLotes.Add(lot)
    '            Next


    '            ListaCatalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
    '            For Each cat In eq.detalleitemequivalencia_catalogos
    '                ListEquivalenciaPrecios = New List(Of detalleitemequivalencia_precios)
    '                For Each prec In cat.detalleitemequivalencia_precios
    '                    ListEquivalenciaPrecios.Add(New detalleitemequivalencia_precios With
    '                                                {
    '                                                .idCatalogo = cat.idCatalogo,
    '                                                .rango_inicio = prec.rango_inicio,
    '                                                .rango_final = prec.rango_final,
    '                                                .precioCredito = prec.precioCredito,
    '                                                .precioCreditoUSD = prec.precioCreditoUSD,
    '                                                .precio = prec.precio,
    '                                                .precioUSD = prec.precioUSD,
    '                                                .precio_id = prec.precio_id,
    '                                                .precioCode = prec.precioCode,
    '                                                .estado = prec.estado
    '                                                })
    '                Next


    '                ListaCatalogoPrecios.Add(New detalleitemequivalencia_catalogos With {
    '                                         .idCatalogo = cat.idCatalogo,
    '                                         .codigodetalle = cat.codigodetalle,
    '                                         .equivalencia_id = cat.equivalencia_id,
    '                                         .nombre_corto = cat.nombre_corto,
    '                                         .nombre_largo = cat.nombre_largo,
    '                                         .estado = cat.estado,
    '                                         .predeterminado = cat.predeterminado,
    '                                         .detalleitemequivalencia_precios = ListEquivalenciaPrecios
    '                                         })


    '            Next
    '            obEquivalencia.detalleitemequivalencia_catalogos = ListaCatalogoPrecios
    '            ListEquivalencia.Add(obEquivalencia)
    '        Next

    '        obj = New detalleitems With
    '        {
    '        .codigodetalle = i.codigodetalle,
    '        .estado = i.estado,
    '        .idItem = i.idItem,
    '        .descripcionItem = i.descripcionItem,
    '        .unidad1 = i.unidad1,
    '        .tipoExistencia = i.tipoExistencia,
    '        .unidad2 = i.unidad2,
    '        .codigo = i.codigo,
    '        .origenProducto = i.origenProducto,
    '        .composicion = i.composicion,
    '        .detalleitem_equivalencias = ListEquivalencia,
    '        .recursoCostoLote = ListaLotes
    '        }
    '        GetProductosWithEquivalencias.Add(obj)
    '    Next
    '    Return GetProductosWithEquivalencias
    'End Function

    Public Function GetProductosWithEquivalenciasV2(be As detalleitems) As List(Of detalleitems)

        'Dim consulta = HeliosData.detalleitems.Include(Function(o) o.detalleitem_equivalencias.Select(Function(y) y.detalleitemequivalencia_precios)).Where(Function(d) d.descripcionItem.StartsWith(be.descripcionItem)).ToList

        Dim consulta = HeliosData.detalleitems _
            .Include(Function(o) o.detalleitem_equivalencias) _
            .Include(Function(o) o.detalleitem_precios) _
            .Where(Function(d) d.descripcionItem.StartsWith(be.descripcionItem)).ToList


        Dim obj As detalleitems
        Dim obEquivalencia As detalleitem_equivalencias
        Dim ListEquivalencia As List(Of detalleitem_equivalencias)
        Dim ListEquivalenciaPrecios As List(Of detalleitem_precios)


        GetProductosWithEquivalenciasV2 = New List(Of detalleitems)

        For Each i In consulta
            ListEquivalenciaPrecios = New List(Of detalleitem_precios)
            For Each prec In i.detalleitem_precios
                ListEquivalenciaPrecios.Add(New detalleitem_precios With
                                                {
                                                .precio_id = prec.precio_id,
                                                .codigodetalle = prec.codigodetalle,
                                                .tipo_rango = prec.tipo_rango,
                                                .rango_inicio = prec.rango_inicio,
                                                .rango_final = prec.rango_final,
                                                .tipo_precio = prec.tipo_precio,
                                                .ultimoCosto = prec.ultimoCosto,
                                                .VContadoPrecioConIgv = prec.VContadoPrecioConIgv,
                                                .VContadoPrecioSinIgv = prec.VContadoPrecioSinIgv,
                                                .VCreditoPrecioConIgv = prec.VCreditoPrecioConIgv,
                                                .VCreditoPrecioSinIgv = prec.VCreditoPrecioSinIgv,
                                                .estado = prec.estado,
                                                .usuarioActualizacion = prec.usuarioActualizacion,
                                                .fechaActualizacion = prec.fechaActualizacion
                                                })
            Next

            ListEquivalencia = New List(Of detalleitem_equivalencias)
            For Each eq In i.detalleitem_equivalencias
                obEquivalencia = New detalleitem_equivalencias
                obEquivalencia.detalle = eq.detalle
                obEquivalencia.unidadComercial = eq.unidadComercial
                obEquivalencia.contenido = eq.contenido
                obEquivalencia.equivalencia_id = eq.equivalencia_id
                obEquivalencia.fraccionUnidad = eq.fraccionUnidad
                obEquivalencia.contenido_neto = eq.contenido_neto
                obEquivalencia.codigo = eq.codigo
                ListEquivalencia.Add(obEquivalencia)
            Next

            obj = New detalleitems With
            {
            .codigodetalle = i.codigodetalle,
            .idItem = i.idItem,
            .descripcionItem = i.descripcionItem,
            .unidad1 = i.unidad1,
            .tipoExistencia = i.tipoExistencia,
            .unidad2 = i.unidad2,
            .codigo = i.codigo,
            .origenProducto = i.origenProducto,
            .composicion = i.composicion,
            .detalleitem_equivalencias = ListEquivalencia,
            .detalleitem_precios = ListEquivalenciaPrecios
            }
            GetProductosWithEquivalenciasV2.Add(obj)
        Next

        Return GetProductosWithEquivalenciasV2

    End Function

    Public Function GetArticulosSinAlmacenSearchCodigo(empresa As String, search As String) As List(Of detalleitems)
        GetArticulosSinAlmacenSearchCodigo = New List(Of detalleitems)
        Dim consulta = (From art In HeliosData.detalleitems
                        Where
                           art.idEmpresa = empresa And
                            art.codigo.Trim.Contains(search) And
                           Not (Not _
                           (From TotalesAlmacen In HeliosData.totalesAlmacen
                            Where
                                TotalesAlmacen.idItem = art.codigodetalle
                            Select New With {
                                TotalesAlmacen
                                }).FirstOrDefault() Is Nothing)
                        Select
                           codigodetalle = art.codigodetalle,
                           idItem = art.idItem,
                           idEmpresa = art.idEmpresa,
                           idEstablecimiento = art.idEstablecimiento,
                           cuenta = art.cuenta,
                           descripcionItem = art.descripcionItem,
                           presentacion = art.presentacion,
                           unidad1 = art.unidad1,
                           unidad2 = art.unidad2,
                           TipoExistencia = art.tipoExistencia,
                           origenProducto = art.origenProducto,
                           tipoProducto = art.tipoProducto,
                           nroOrden = art.nroOrden,
                           codigo = art.codigo,
                           marcaRef = art.marcaRef,
                           AfectoCompra = art.AfectoCompra,
                           AfectoVenta = art.AfectoVenta,
                           estado = art.estado,
                           usuarioActualizacion = art.usuarioActualizacion,
                           fechaActualizacion = art.fechaActualizacion,
                            precioMenor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = art.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
                                            And configuracionPrecioProductoes0.idproducto = art.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            precioMenorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = art.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
                                            And configuracionPrecioProductoes0.idproducto = art.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                            PrecioMayor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = art.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
                                            And configuracionPrecioProductoes0.idproducto = art.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            PrecioMayorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = art.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
                                            And configuracionPrecioProductoes0.idproducto = art.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                            PrecioGranMayor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = art.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
                                            And configuracionPrecioProductoes0.idproducto = art.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            PrecioGranMayorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = art.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
                                            And configuracionPrecioProductoes0.idproducto = art.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME))
        ).ToList

        For Each i In consulta
            GetArticulosSinAlmacenSearchCodigo.Add(New detalleitems With
                                        {
                                        .codigodetalle = i.codigodetalle,
                                        .idItem = i.idItem,
                                        .idEmpresa = i.idEmpresa,
                                        .idEstablecimiento = i.idEstablecimiento,
                                        .cuenta = i.cuenta,
                                        .descripcionItem = i.descripcionItem,
                                        .presentacion = i.presentacion,
                                        .unidad1 = i.unidad1,
                                        .unidad2 = i.unidad2,
                                        .tipoExistencia = i.TipoExistencia,
                                        .origenProducto = i.origenProducto,
                                        .tipoProducto = i.tipoProducto,
                                        .nroOrden = i.nroOrden,
                                        .codigo = i.codigo,
                                        .marcaRef = i.marcaRef,
                                        .AfectoCompra = i.AfectoCompra,
                                        .AfectoVenta = i.AfectoVenta,
                                        .estado = i.estado,
                                        .usuarioActualizacion = i.usuarioActualizacion,
                                        .fechaActualizacion = i.fechaActualizacion,
                                                 .precioMenor = i.precioMenor.GetValueOrDefault,
                                                 .precioMayor = i.PrecioMayor.GetValueOrDefault,
                                                 .precioGranMayor = i.PrecioGranMayor.GetValueOrDefault,
                                                 .precioMenorME = i.precioMenorME.GetValueOrDefault,
                                                 .precioMayorME = i.PrecioMayorME.GetValueOrDefault,
                                                 .precioGranMayorME = i.PrecioGranMayorME.GetValueOrDefault
                                        })
        Next



    End Function

    Public Function GetArticulosSinAlmacenSearchText(empresa As String, search As String) As List(Of detalleitems)
        GetArticulosSinAlmacenSearchText = New List(Of detalleitems)
        Dim consulta = (From art In HeliosData.detalleitems
                        Where
                           art.idEmpresa = empresa And
                            art.descripcionItem.Trim.Contains(search) And
                           Not (Not _
                           (From TotalesAlmacen In HeliosData.totalesAlmacen
                            Where
                                TotalesAlmacen.idItem = art.codigodetalle
                            Select New With {
                                TotalesAlmacen
                                }).FirstOrDefault() Is Nothing)
                        Select
                           codigodetalle = art.codigodetalle,
                           idItem = art.idItem,
                           idEmpresa = art.idEmpresa,
                           idEstablecimiento = art.idEstablecimiento,
                           cuenta = art.cuenta,
                           descripcionItem = art.descripcionItem,
                           presentacion = art.presentacion,
                           unidad1 = art.unidad1,
                           unidad2 = art.unidad2,
                           TipoExistencia = art.tipoExistencia,
                           origenProducto = art.origenProducto,
                           tipoProducto = art.tipoProducto,
                           nroOrden = art.nroOrden,
                           codigo = art.codigo,
                           marcaRef = art.marcaRef,
                           AfectoCompra = art.AfectoCompra,
                           AfectoVenta = art.AfectoVenta,
                           estado = art.estado,
                           usuarioActualizacion = art.usuarioActualizacion,
                           fechaActualizacion = art.fechaActualizacion,
                            precioMenor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = art.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
                                            And configuracionPrecioProductoes0.idproducto = art.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            precioMenorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = art.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
                                            And configuracionPrecioProductoes0.idproducto = art.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                            PrecioMayor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = art.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
                                            And configuracionPrecioProductoes0.idproducto = art.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            PrecioMayorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = art.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
                                            And configuracionPrecioProductoes0.idproducto = art.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                            PrecioGranMayor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = art.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
                                            And configuracionPrecioProductoes0.idproducto = art.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            PrecioGranMayorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = art.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
                                            And configuracionPrecioProductoes0.idproducto = art.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME))
        ).ToList

        For Each i In consulta
            GetArticulosSinAlmacenSearchText.Add(New detalleitems With
                                        {
                                        .codigodetalle = i.codigodetalle,
                                        .idItem = i.idItem,
                                        .idEmpresa = i.idEmpresa,
                                        .idEstablecimiento = i.idEstablecimiento,
                                        .cuenta = i.cuenta,
                                        .descripcionItem = i.descripcionItem,
                                        .presentacion = i.presentacion,
                                        .unidad1 = i.unidad1,
                                        .unidad2 = i.unidad2,
                                        .tipoExistencia = i.TipoExistencia,
                                        .origenProducto = i.origenProducto,
                                        .tipoProducto = i.tipoProducto,
                                        .nroOrden = i.nroOrden,
                                        .codigo = i.codigo,
                                        .marcaRef = i.marcaRef,
                                        .AfectoCompra = i.AfectoCompra,
                                        .AfectoVenta = i.AfectoVenta,
                                        .estado = i.estado,
                                        .usuarioActualizacion = i.usuarioActualizacion,
                                        .fechaActualizacion = i.fechaActualizacion,
                                                 .precioMenor = i.precioMenor.GetValueOrDefault,
                                                 .precioMayor = i.PrecioMayor.GetValueOrDefault,
                                                 .precioGranMayor = i.PrecioGranMayor.GetValueOrDefault
                                        })
        Next



    End Function

    ''' <summary>
    ''' Articulos sin almacenes
    ''' </summary>
    ''' <param name="empresa"></param>
    ''' <param name="opcion"></param>
    ''' <returns></returns>
    Public Function GetArticulosSinAlmacen(empresa As String, opcion As Byte) As List(Of detalleitems)
        GetArticulosSinAlmacen = New List(Of detalleitems)
        Select Case opcion
            Case 1
                Dim consulta = (From art In HeliosData.detalleitems
                                Where
                                   art.idEmpresa = empresa And
                                   Not (Not _
                                   (From TotalesAlmacen In HeliosData.totalesAlmacen
                                    Where
                                        TotalesAlmacen.idItem = art.codigodetalle
                                    Select New With {
                                        TotalesAlmacen
                                        }).FirstOrDefault() Is Nothing)
                                Select
                                   codigodetalle = art.codigodetalle,
                                   idItem = art.idItem,
                                   idEmpresa = art.idEmpresa,
                                   idEstablecimiento = art.idEstablecimiento,
                                   cuenta = art.cuenta,
                                   descripcionItem = art.descripcionItem,
                                   presentacion = art.presentacion,
                                   unidad1 = art.unidad1,
                                   unidad2 = art.unidad2,
                                   TipoExistencia = art.tipoExistencia,
                                   origenProducto = art.origenProducto,
                                   tipoProducto = art.tipoProducto,
                                   nroOrden = art.nroOrden,
                                   codigo = art.codigo,
                                   marcaRef = art.marcaRef,
                                   AfectoCompra = art.AfectoCompra,
                                   AfectoVenta = art.AfectoVenta,
                                   estado = art.estado,
                                   usuarioActualizacion = art.usuarioActualizacion,
                                   fechaActualizacion = art.fechaActualizacion).ToList

                For Each i In consulta
                    GetArticulosSinAlmacen.Add(New detalleitems With
                                        {
                                        .codigodetalle = i.codigodetalle,
                                        .idItem = i.idItem,
                                        .idEmpresa = i.idEmpresa,
                                        .idEstablecimiento = i.idEstablecimiento,
                                        .cuenta = i.cuenta,
                                        .descripcionItem = i.descripcionItem,
                                        .presentacion = i.presentacion,
                                        .unidad1 = i.unidad1,
                                        .unidad2 = i.unidad2,
                                        .tipoExistencia = i.TipoExistencia,
                                        .origenProducto = i.origenProducto,
                                        .tipoProducto = i.tipoProducto,
                                        .nroOrden = i.nroOrden,
                                        .codigo = i.codigo,
                                        .marcaRef = i.marcaRef,
                                        .AfectoCompra = i.AfectoCompra,
                                        .AfectoVenta = i.AfectoVenta,
                                        .estado = i.estado,
                                        .usuarioActualizacion = i.usuarioActualizacion,
                                        .fechaActualizacion = i.fechaActualizacion
                                        })
                Next

            Case 2


                Dim consulta = (From art In HeliosData.detalleitems
                                Where
                                   art.idEmpresa = empresa And
                                   Not (Not _
                                   (From TotalesAlmacen In HeliosData.totalesAlmacen
                                    Where
                                        TotalesAlmacen.idItem = art.codigodetalle
                                    Select New With {
                                        TotalesAlmacen
                                        }).FirstOrDefault() Is Nothing)
                                Select
                                   codigodetalle = art.codigodetalle,
                                   idItem = art.idItem,
                                   idEmpresa = art.idEmpresa,
                                   idEstablecimiento = art.idEstablecimiento,
                                   cuenta = art.cuenta,
                                   descripcionItem = art.descripcionItem,
                                   presentacion = art.presentacion,
                                   unidad1 = art.unidad1,
                                   unidad2 = art.unidad2,
                                   TipoExistencia = art.tipoExistencia,
                                   origenProducto = art.origenProducto,
                                   tipoProducto = art.tipoProducto,
                                   nroOrden = art.nroOrden,
                                   codigo = art.codigo,
                                   marcaRef = art.marcaRef,
                                   AfectoCompra = art.AfectoCompra,
                                   AfectoVenta = art.AfectoVenta,
                                   estado = art.estado,
                                   usuarioActualizacion = art.usuarioActualizacion,
                                   fechaActualizacion = art.fechaActualizacion).Count


                GetArticulosSinAlmacen.Add(New detalleitems With {.capacidad = consulta.ToString()})
        End Select

    End Function

    Public Function GetDetalleItemsXEmpresaAll(empresa As String, estable As Integer, tipo As String) As List(Of detalleitems)
        Dim obj As New detalleitems
        Dim Lista As New List(Of detalleitems)

        Dim tipoCompras As New List(Of String)
        tipoCompras.Add(TIPO_COMPRA.COMPRA)
        tipoCompras.Add(TIPO_COMPRA.OTRAS_ENTRADAS)
        tipoCompras.Add(TIPO_COMPRA.NOTA_DE_COMPRA)
        tipoCompras.Add(TIPO_COMPRA.NOTA_DE_COMPRA_EN_ESPERA)
        'p.tipoExistencia = tipo And
        Dim pageNumber = 1
        Dim pageSize = 10
        '   Dim result = HeliosData.detalleitems.Skip((pageNumber - 1) * pageSize).Take(pageSize)

        Dim consulta = (From p In HeliosData.detalleitems
                        Group Join clas In HeliosData.item
                            On p.idItem Equals clas.idItem
                            Into clas1 = Group
                        From cx In clas1.DefaultIfEmpty()
                        Group Join marca In HeliosData.item
                            On p.unidad2 Equals marca.idItem
                            Into marca1 = Group
                        From mx In marca1.DefaultIfEmpty()
                        Where p.idEmpresa = empresa And
                            p.idEstablecimiento = estable And
                            p.tipoExistencia = tipo And p.estado = "A"
                        Select
                            codigoProd = p.codigodetalle,
                            preciocompra = p.precioCompra,
                            descripcion = p.descripcionItem,
                            clasificaion = cx.descripcion,
                            marca = mx.descripcion,
                            gravado = p.origenProducto,
                            tipoex = p.tipoExistencia,
                            unidad = p.unidad1,
                            codigobarra = p.codigo,
                            presentacion = p.presentacion,
                            precioMenor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            precioMenorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                            PrecioMayor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            PrecioMayorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                            PrecioGranMayor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            PrecioGranMayorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                            UltimaCompra = (
                            ((From
                                  d In HeliosData.documentocompradetalle
                              Join comp In HeliosData.documentocompra
                                      On comp.idDocumento Equals d.idDocumento
                              Where
                                  d.idItem = p.codigodetalle And
                                  d.documentocompra.fechaDoc =
                                  CType((Aggregate ss In HeliosData.documentocompradetalle
                                             Where
                                                 ss.idItem = p.codigodetalle And
                                                 tipoCompras.Contains(ss.documentocompra.tipoCompra)
                                                 Into Max(ss.documentocompra.fechaDoc)), DateTime?)
                              Select New With
                                  {
                                  d,
                                  comp
                                  }).FirstOrDefault())),
                            UltimaEntradaInicio = (
                            ((From
                                  d In HeliosData.documentoLibroDiarioDetalle
                              Where
                                  d.idItem = p.codigodetalle And
                                  d.documentoLibroDiario.tipoRegistro = "APT_EXT" And
                                  d.documentoLibroDiario.fecha = CType((Aggregate ss In HeliosData.documentoLibroDiarioDetalle
                                                                     Where ss.idItem = p.codigodetalle And
                                                                         ss.documentoLibroDiario.tipoRegistro = "APT_EXT"
                                                                         Into Max(ss.documentoLibroDiario.fecha)), DateTime?)
                              Select New With
                                  {
                                  d
                                  }).FirstOrDefault().d))
                            ).OrderBy(Function(o) o.descripcion).ToList


        For Each i In consulta
            obj = New detalleitems

            If i.UltimaCompra IsNot Nothing Then

                obj.CustomDetalleCompra = New documentocompradetalle With
                {
                    .FechaDoc = i.UltimaCompra.comp.fechaDoc,
                    .monto1 = i.UltimaCompra.d.monto1,
                    .destino = i.UltimaCompra.d.destino,
                    .importe = i.UltimaCompra.d.importe
                }
                obj.CustomDetalleCompra.documentocompra = New documentocompra With
                {
                .tipoCompra = i.UltimaCompra.comp.tipoCompra
                }
            End If

            If i.UltimaEntradaInicio IsNot Nothing Then
                obj.InventarioInicio = i.UltimaEntradaInicio
            End If

            obj.codigodetalle = i.codigoProd
            obj.descripcionItem = i.descripcion
            obj.NomClasificacion = i.clasificaion
            obj.NomMarca = i.marca
            obj.origenProducto = i.gravado
            obj.tipoExistencia = i.tipoex
            obj.unidad1 = i.unidad
            obj.unidad2 = i.marca
            obj.presentacion = i.presentacion
            obj.codigo = i.codigobarra
            obj.precioCompra = i.preciocompra
            obj.precioMenor = i.precioMenor.GetValueOrDefault
            obj.precioMayor = i.PrecioMayor.GetValueOrDefault
            obj.precioGranMayor = i.PrecioGranMayor.GetValueOrDefault

            obj.precioMenorME = i.precioMenorME.GetValueOrDefault
            obj.precioMayorME = i.PrecioMayorME.GetValueOrDefault
            obj.precioGranMayorME = i.PrecioGranMayorME.GetValueOrDefault
            Lista.Add(obj)
        Next

        Return Lista
    End Function

    Function SubProductosEntregables(idEntre As Integer) As List(Of detalleitems)

        Dim detalle As New detalleitems
        Dim lista As New List(Of detalleitems)
        Dim consulta2 = (From a In HeliosData.detalleitems
                         Join i In HeliosData.recursoCosto
                         On a.codigodetalle Equals i.codigo
                         Where i.idpadre = idEntre).ToList

        For Each i In consulta2
            detalle = New detalleitems

            detalle.origenProducto = i.a.origenProducto
            detalle.codigodetalle = i.a.codigodetalle
            detalle.descripcionItem = i.a.descripcionItem
            detalle.presentacion = i.a.presentacion
            detalle.unidad1 = i.a.unidad1
            detalle.tipoExistencia = i.a.tipoExistencia

            lista.Add(detalle)

        Next

        Return lista
    End Function

    Function GetUbicaProductoNombreCambioInventario(strNomProducto As String, tipoExistencia As String) As detalleitems
        Dim consulta As New detalleitems
        consulta = (From a In HeliosData.detalleitems
                    Where a.descripcionItem = strNomProducto _
                    And a.tipoExistencia = tipoExistencia).FirstOrDefault

        Return consulta
    End Function


    Public Function GetExistenciasByempresaNombre(nombre As String, IDEmpresa As String) As List(Of detalleitems)
        Dim obj As New detalleitems
        Dim Lista As New List(Of detalleitems)

        Dim consulta = (From p In HeliosData.detalleitems
                        Group Join clas In HeliosData.item
                       On p.idItem Equals clas.idItem
                       Into clas1 = Group
                        From cx In clas1.DefaultIfEmpty()
                        Group Join marca In HeliosData.item
                       On p.marcaRef Equals marca.idItem
                       Into marca1 = Group
                        From mx In marca1.DefaultIfEmpty()
                        Where p.descripcionItem.Contains(nombre) And
                            p.idEmpresa = IDEmpresa And p.estado = "A"
                        Select
                       codigo = p.codigodetalle,
                       descripcion = p.descripcionItem,
                       clasificaion = cx.descripcion,
                       marca = mx.descripcion,
                       gravado = p.origenProducto,
                       tipoex = p.tipoExistencia,
                       unidad = p.unidad1,
                       codigoBar = p.codigo,
                       presentacion = p.presentacion).OrderBy(Function(o) o.descripcion).ToList


        For Each i In consulta
            obj = New detalleitems
            obj.codigodetalle = i.codigo
            obj.descripcionItem = i.descripcion
            obj.NomClasificacion = i.clasificaion
            obj.NomMarca = i.marca
            obj.origenProducto = i.gravado
            obj.tipoExistencia = i.tipoex
            obj.unidad1 = i.unidad
            obj.presentacion = i.presentacion
            obj.tipoExistencia = i.tipoex
            obj.codigo = i.codigoBar
            Lista.Add(obj)
        Next

        Return Lista
    End Function

    Public Function GetExistenciasByempresaNombreFull(idempresa As String, nombre As String) As List(Of detalleitems)
        Dim obj As New detalleitems
        Dim Lista As New List(Of detalleitems)
        Dim tipoCompras As New List(Of String)
        tipoCompras.Add(TIPO_COMPRA.COMPRA)
        tipoCompras.Add(TIPO_COMPRA.OTRAS_ENTRADAS)
        tipoCompras.Add(TIPO_COMPRA.NOTA_DE_COMPRA)
        Dim delimitadores() As String = {" "}
        Dim vectoraux() As String
        vectoraux = nombre.Split(delimitadores, StringSplitOptions.None)

        'mostrar resultado
        'For Each item As String In vectoraux
        '    NuevaDescripcion += item & "%"
        'Next

        Dim consulta = HeliosData.usp_GetProductsWithParameters(idempresa, "01", nombre).ToList

        For Each i In consulta

            obj = New detalleitems
            If i.UltimaEntrada IsNot Nothing Then
                Dim s As String = i.UltimaEntrada
                Dim datosEntrada() As String = s.Split(New Char() {","c})
                '   Dim parts As String() = s.Split(New Char() {","c})

                Dim tipcompra As String = datosEntrada(0)
                Dim fechacompra As String = datosEntrada(1)
                Dim destino As String = datosEntrada(2)
                Dim baseimponible = datosEntrada(3)
                Dim total = datosEntrada(4)
                Dim cant = datosEntrada(5)

                obj.CustomDetalleCompra = New documentocompradetalle With
                {
                    .FechaDoc = fechacompra,' i.UltimaCompra.comp.fechaDoc,
                    .monto1 = cant,'i.UltimaCompra.d.monto1,
                    .destino = destino,' i.UltimaCompra.d.destino,
                    .importe = total'i.UltimaCompra.d.importe
                }
                obj.CustomDetalleCompra.documentocompra = New documentocompra With
                {
                .tipoCompra = tipcompra' i.UltimaCompra.comp.tipoCompra
                }
            End If

            'If i.UltimaEntradaInicio IsNot Nothing Then
            '    obj.InventarioInicio = i.UltimaEntradaInicio
            'End If

            obj.codigodetalle = i.codigodetalle
            obj.descripcionItem = i.descripcionItem
            obj.NomClasificacion = i.GrupoName
            obj.NomMarca = i.MarcaName
            obj.origenProducto = i.origenProducto
            obj.tipoExistencia = i.tipoExistencia
            obj.unidad1 = i.unidad1
            obj.unidad2 = i.MarcaName
            obj.presentacion = String.Empty 'i.presentacion
            obj.codigo = i.codigo
            obj.precioCompra = i.precioCompra
            obj.precioMenor = i.menor.GetValueOrDefault '  i.precioMenor.GetValueOrDefault
            obj.precioMayor = i.mayor.GetValueOrDefault ' i.PrecioMayor.GetValueOrDefault
            obj.precioGranMayor = i.granMayor.GetValueOrDefault ' i.PrecioGranMayor.GetValueOrDefault

            obj.precioMenorME = 0 ' i.precioMenorME.GetValueOrDefault
            obj.precioMayorME = 0 ' i.PrecioMayorME.GetValueOrDefault
            obj.precioGranMayorME = 0 ' i.PrecioGranMayorME.GetValueOrDefault
            Lista.Add(obj)
        Next

        'If vectoraux.Count = 1 Then
        '    Dim filter1 As String = vectoraux(0)

        '    Dim consulta = (From p In HeliosData.detalleitems
        '                    Group Join clas In HeliosData.item
        '                   On p.idItem Equals clas.idItem
        '                   Into clas1 = Group
        '                    From cx In clas1.DefaultIfEmpty()
        '                    Group Join marca In HeliosData.item
        '                   On p.unidad2 Equals marca.idItem
        '                   Into marca1 = Group
        '                    From mx In marca1.DefaultIfEmpty()
        '                    Where p.idEmpresa = idempresa And p.descripcionItem.Contains(filter1)
        '                    Select
        '                   codigo = p.codigodetalle,
        '                        preciocompra = p.precioCompra,
        '                   descripcion = p.descripcionItem,
        '                   clasificaion = cx.descripcion,
        '                   marca = mx.descripcion,
        '                   gravado = p.origenProducto,
        '                   tipoex = p.tipoExistencia,
        '                   unidad = p.unidad1,
        '                   codigoBar = p.codigo,
        '                   presentacion = p.presentacion,
        '                        precioMenor = (
        '                        ((From
        '                              configuracionPrecioProductoes
        '                              In HeliosData.configuracionPrecioProducto
        '                          Where
        '                              configuracionPrecioProductoes.idproducto = p.codigodetalle And
        '                              CLng(configuracionPrecioProductoes.idPrecio) = 1 And
        '                              configuracionPrecioProductoes.fecha =
        '                              (Aggregate t2 In
        '                                   (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                    Where
        '                                        CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
        '                                        And configuracionPrecioProductoes0.idproducto = p.codigodetalle
        '                                    Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                          Select New With
        '                              {
        '                              configuracionPrecioProductoes.precioMN
        '                              }).FirstOrDefault().precioMN)),
        '                        PrecioMayor = (
        '                        ((From
        '                              configuracionPrecioProductoes
        '                              In HeliosData.configuracionPrecioProducto
        '                          Where
        '                              configuracionPrecioProductoes.idproducto = p.codigodetalle And
        '                              CLng(configuracionPrecioProductoes.idPrecio) = 2 And
        '                              configuracionPrecioProductoes.fecha =
        '                              (Aggregate t2 In
        '                                   (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                    Where
        '                                        CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
        '                                        And configuracionPrecioProductoes0.idproducto = p.codigodetalle
        '                                    Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                          Select New With
        '                              {
        '                              configuracionPrecioProductoes.precioMN
        '                              }).FirstOrDefault().precioMN)),
        '                        PrecioGranMayor = (
        '                        ((From
        '                              configuracionPrecioProductoes
        '                              In HeliosData.configuracionPrecioProducto
        '                          Where
        '                              configuracionPrecioProductoes.idproducto = p.codigodetalle And
        '                              CLng(configuracionPrecioProductoes.idPrecio) = 3 And
        '                              configuracionPrecioProductoes.fecha =
        '                              (Aggregate t2 In
        '                                   (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                    Where
        '                                        CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
        '                                        And configuracionPrecioProductoes0.idproducto = p.codigodetalle
        '                                    Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                          Select New With
        '                              {
        '                              configuracionPrecioProductoes.precioMN
        '                              }).FirstOrDefault().precioMN)),
        '                        UltimaCompra = (
        '                        ((From
        '                              d In HeliosData.documentocompradetalle
        '                          Join comp In HeliosData.documentocompra
        '                                  On comp.idDocumento Equals d.idDocumento
        '                          Where
        '                              d.idItem = p.codigodetalle And
        '                              d.documentocompra.fechaDoc =
        '                              CType((Aggregate ss In HeliosData.documentocompradetalle
        '                                         Where
        '                                             ss.idItem = p.codigodetalle And
        '                                             tipoCompras.Contains(ss.documentocompra.tipoCompra)
        '                                             Into Max(ss.documentocompra.fechaDoc)), DateTime?)
        '                          Select New With
        '                              {
        '                              d,
        '                              comp
        '                              }).FirstOrDefault())),
        '                        UltimaEntradaInicio = (
        '                        ((From
        '                              d In HeliosData.documentoLibroDiarioDetalle
        '                          Where
        '                              d.idItem = p.codigodetalle And
        '                              d.documentoLibroDiario.tipoRegistro = "APT_EXT" And
        '                              d.documentoLibroDiario.fecha = CType((Aggregate ss In HeliosData.documentoLibroDiarioDetalle
        '                                                                 Where ss.idItem = p.codigodetalle And
        '                                                                     ss.documentoLibroDiario.tipoRegistro = "APT_EXT"
        '                                                                     Into Max(ss.documentoLibroDiario.fecha)), DateTime?)
        '                          Select New With
        '                              {
        '                              d
        '                              }).FirstOrDefault().d))
        '                    ).OrderBy(Function(o) o.descripcion).ToList

        '    For Each i In consulta

        '        obj = New detalleitems
        '        If i.UltimaCompra IsNot Nothing Then
        '            obj.CustomDetalleCompra = New documentocompradetalle With
        '            {
        '                .FechaDoc = i.UltimaCompra.comp.fechaDoc,
        '                .monto1 = i.UltimaCompra.d.monto1,
        '                .destino = i.UltimaCompra.d.destino,
        '                .importe = i.UltimaCompra.d.importe
        '            }
        '            obj.CustomDetalleCompra.documentocompra = New documentocompra With
        '            {
        '            .tipoCompra = i.UltimaCompra.comp.tipoCompra
        '            }
        '        End If
        '        If i.UltimaEntradaInicio IsNot Nothing Then
        '            obj.InventarioInicio = i.UltimaEntradaInicio
        '        End If
        '        obj.codigodetalle = i.codigo
        '        obj.descripcionItem = i.descripcion.ToUpper
        '        obj.NomClasificacion = i.clasificaion
        '        obj.NomMarca = i.marca
        '        obj.origenProducto = i.gravado
        '        obj.tipoExistencia = i.tipoex
        '        obj.unidad1 = i.unidad
        '        obj.unidad2 = i.marca
        '        obj.presentacion = i.presentacion
        '        obj.tipoExistencia = i.tipoex
        '        obj.codigo = i.codigoBar
        '        obj.precioCompra = i.preciocompra
        '        obj.precioMenor = i.precioMenor.GetValueOrDefault
        '        obj.precioMayor = i.PrecioMayor.GetValueOrDefault
        '        obj.precioGranMayor = i.PrecioGranMayor.GetValueOrDefault
        '        Lista.Add(obj)
        '    Next

        'ElseIf vectoraux.Count = 2 Then

        '    Dim filter1 As String = vectoraux(0)
        '    Dim filter2 As String = vectoraux(1)

        '    Dim consulta = (From p In HeliosData.detalleitems
        '                    Group Join clas In HeliosData.item
        '                   On p.idItem Equals clas.idItem
        '                   Into clas1 = Group
        '                    From cx In clas1.DefaultIfEmpty()
        '                    Group Join marca In HeliosData.item
        '                   On p.unidad2 Equals marca.idItem
        '                   Into marca1 = Group
        '                    From mx In marca1.DefaultIfEmpty()
        '                    Where p.idEmpresa = idempresa And p.descripcionItem.StartsWith(filter1) And p.descripcionItem.Contains(filter2)
        '                    Select
        '                   codigo = p.codigodetalle,
        '                        preciocompra = p.precioCompra,
        '                   descripcion = p.descripcionItem,
        '                   clasificaion = cx.descripcion,
        '                   marca = mx.descripcion,
        '                   gravado = p.origenProducto,
        '                   tipoex = p.tipoExistencia,
        '                   unidad = p.unidad1,
        '                   codigoBar = p.codigo,
        '                   presentacion = p.presentacion,
        '                        precioMenor = (
        '                        ((From
        '                              configuracionPrecioProductoes
        '                              In HeliosData.configuracionPrecioProducto
        '                          Where
        '                              configuracionPrecioProductoes.idproducto = p.codigodetalle And
        '                              CLng(configuracionPrecioProductoes.idPrecio) = 1 And
        '                              configuracionPrecioProductoes.fecha =
        '                              (Aggregate t2 In
        '                                   (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                    Where
        '                                        CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
        '                                        And configuracionPrecioProductoes0.idproducto = p.codigodetalle
        '                                    Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                          Select New With
        '                              {
        '                              configuracionPrecioProductoes.precioMN
        '                              }).FirstOrDefault().precioMN)),
        '                        PrecioMayor = (
        '                        ((From
        '                              configuracionPrecioProductoes
        '                              In HeliosData.configuracionPrecioProducto
        '                          Where
        '                              configuracionPrecioProductoes.idproducto = p.codigodetalle And
        '                              CLng(configuracionPrecioProductoes.idPrecio) = 2 And
        '                              configuracionPrecioProductoes.fecha =
        '                              (Aggregate t2 In
        '                                   (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                    Where
        '                                        CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
        '                                        And configuracionPrecioProductoes0.idproducto = p.codigodetalle
        '                                    Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                          Select New With
        '                              {
        '                              configuracionPrecioProductoes.precioMN
        '                              }).FirstOrDefault().precioMN)),
        '                        PrecioGranMayor = (
        '                        ((From
        '                              configuracionPrecioProductoes
        '                              In HeliosData.configuracionPrecioProducto
        '                          Where
        '                              configuracionPrecioProductoes.idproducto = p.codigodetalle And
        '                              CLng(configuracionPrecioProductoes.idPrecio) = 3 And
        '                              configuracionPrecioProductoes.fecha =
        '                              (Aggregate t2 In
        '                                   (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                    Where
        '                                        CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
        '                                        And configuracionPrecioProductoes0.idproducto = p.codigodetalle
        '                                    Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                          Select New With
        '                              {
        '                              configuracionPrecioProductoes.precioMN
        '                              }).FirstOrDefault().precioMN)),
        '                        UltimaCompra = (
        '                        ((From
        '                              d In HeliosData.documentocompradetalle
        '                          Join comp In HeliosData.documentocompra
        '                                  On comp.idDocumento Equals d.idDocumento
        '                          Where
        '                              d.idItem = p.codigodetalle And
        '                              d.documentocompra.fechaDoc =
        '                              CType((Aggregate ss In HeliosData.documentocompradetalle
        '                                         Where
        '                                             ss.idItem = p.codigodetalle And
        '                                             tipoCompras.Contains(ss.documentocompra.tipoCompra)
        '                                             Into Max(ss.documentocompra.fechaDoc)), DateTime?)
        '                          Select New With
        '                              {
        '                              d,
        '                              comp
        '                              }).FirstOrDefault())),
        '                        UltimaEntradaInicio = (
        '                        ((From
        '                              d In HeliosData.documentoLibroDiarioDetalle
        '                          Where
        '                              d.idItem = p.codigodetalle And
        '                              d.documentoLibroDiario.tipoRegistro = "APT_EXT" And
        '                              d.documentoLibroDiario.fecha = CType((Aggregate ss In HeliosData.documentoLibroDiarioDetalle
        '                                                                 Where ss.idItem = p.codigodetalle And
        '                                                                     ss.documentoLibroDiario.tipoRegistro = "APT_EXT"
        '                                                                     Into Max(ss.documentoLibroDiario.fecha)), DateTime?)
        '                          Select New With
        '                              {
        '                              d
        '                              }).FirstOrDefault().d))
        '                   ).OrderBy(Function(o) o.descripcion).ToList


        '    For Each i In consulta

        '        obj = New detalleitems
        '        If i.UltimaCompra IsNot Nothing Then
        '            obj.CustomDetalleCompra = New documentocompradetalle With
        '            {
        '                .FechaDoc = i.UltimaCompra.comp.fechaDoc,
        '                .monto1 = i.UltimaCompra.d.monto1,
        '                .destino = i.UltimaCompra.d.destino,
        '                .importe = i.UltimaCompra.d.importe
        '            }
        '            obj.CustomDetalleCompra.documentocompra = New documentocompra With
        '            {
        '            .tipoCompra = i.UltimaCompra.comp.tipoCompra
        '            }
        '        End If
        '        If i.UltimaEntradaInicio IsNot Nothing Then
        '            obj.InventarioInicio = i.UltimaEntradaInicio
        '        End If
        '        obj.codigodetalle = i.codigo
        '        obj.descripcionItem = i.descripcion.ToUpper
        '        obj.NomClasificacion = i.clasificaion
        '        obj.NomMarca = i.marca
        '        obj.origenProducto = i.gravado
        '        obj.tipoExistencia = i.tipoex
        '        obj.unidad1 = i.unidad
        '        obj.unidad2 = i.marca
        '        obj.presentacion = i.presentacion
        '        obj.tipoExistencia = i.tipoex
        '        obj.codigo = i.codigoBar
        '        obj.precioCompra = i.preciocompra
        '        obj.precioMenor = i.precioMenor.GetValueOrDefault
        '        obj.precioMayor = i.PrecioMayor.GetValueOrDefault
        '        obj.precioGranMayor = i.PrecioGranMayor.GetValueOrDefault
        '        Lista.Add(obj)
        '    Next
        'ElseIf vectoraux.Count = 3 Then

        '    Dim filter1 As String = vectoraux(0)
        '    Dim filter2 As String = vectoraux(1)
        '    Dim filter3 As String = vectoraux(2)

        '    Dim consulta = (From p In HeliosData.detalleitems
        '                    Group Join clas In HeliosData.item
        '                   On p.idItem Equals clas.idItem
        '                   Into clas1 = Group
        '                    From cx In clas1.DefaultIfEmpty()
        '                    Group Join marca In HeliosData.item
        '                   On p.unidad2 Equals marca.idItem
        '                   Into marca1 = Group
        '                    From mx In marca1.DefaultIfEmpty()
        '                    Where p.idEmpresa = idempresa And p.descripcionItem.StartsWith(filter1) And p.descripcionItem.Contains(filter2) And p.descripcionItem.Contains(filter3)
        '                    Select
        '                   codigo = p.codigodetalle,
        '                        preciocompra = p.precioCompra,
        '                   descripcion = p.descripcionItem,
        '                   clasificaion = cx.descripcion,
        '                   marca = mx.descripcion,
        '                   gravado = p.origenProducto,
        '                   tipoex = p.tipoExistencia,
        '                   unidad = p.unidad1,
        '                   codigoBar = p.codigo,
        '                   presentacion = p.presentacion,
        '                        precioMenor = (
        '                        ((From
        '                              configuracionPrecioProductoes
        '                              In HeliosData.configuracionPrecioProducto
        '                          Where
        '                              configuracionPrecioProductoes.idproducto = p.codigodetalle And
        '                              CLng(configuracionPrecioProductoes.idPrecio) = 1 And
        '                              configuracionPrecioProductoes.fecha =
        '                              (Aggregate t2 In
        '                                   (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                    Where
        '                                        CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
        '                                        And configuracionPrecioProductoes0.idproducto = p.codigodetalle
        '                                    Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                          Select New With
        '                              {
        '                              configuracionPrecioProductoes.precioMN
        '                              }).FirstOrDefault().precioMN)),
        '                        PrecioMayor = (
        '                        ((From
        '                              configuracionPrecioProductoes
        '                              In HeliosData.configuracionPrecioProducto
        '                          Where
        '                              configuracionPrecioProductoes.idproducto = p.codigodetalle And
        '                              CLng(configuracionPrecioProductoes.idPrecio) = 2 And
        '                              configuracionPrecioProductoes.fecha =
        '                              (Aggregate t2 In
        '                                   (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                    Where
        '                                        CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
        '                                        And configuracionPrecioProductoes0.idproducto = p.codigodetalle
        '                                    Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                          Select New With
        '                              {
        '                              configuracionPrecioProductoes.precioMN
        '                              }).FirstOrDefault().precioMN)),
        '                        PrecioGranMayor = (
        '                        ((From
        '                              configuracionPrecioProductoes
        '                              In HeliosData.configuracionPrecioProducto
        '                          Where
        '                              configuracionPrecioProductoes.idproducto = p.codigodetalle And
        '                              CLng(configuracionPrecioProductoes.idPrecio) = 3 And
        '                              configuracionPrecioProductoes.fecha =
        '                              (Aggregate t2 In
        '                                   (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                    Where
        '                                        CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
        '                                        And configuracionPrecioProductoes0.idproducto = p.codigodetalle
        '                                    Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                          Select New With
        '                              {
        '                              configuracionPrecioProductoes.precioMN
        '                              }).FirstOrDefault().precioMN)),
        '                        UltimaCompra = (
        '                        ((From
        '                              d In HeliosData.documentocompradetalle
        '                          Join comp In HeliosData.documentocompra
        '                                  On comp.idDocumento Equals d.idDocumento
        '                          Where
        '                              d.idItem = p.codigodetalle And
        '                              d.documentocompra.fechaDoc =
        '                              CType((Aggregate ss In HeliosData.documentocompradetalle
        '                                         Where
        '                                             ss.idItem = p.codigodetalle And
        '                                             tipoCompras.Contains(ss.documentocompra.tipoCompra)
        '                                             Into Max(ss.documentocompra.fechaDoc)), DateTime?)
        '                          Select New With
        '                              {
        '                              d,
        '                              comp
        '                              }).FirstOrDefault())),
        '                        UltimaEntradaInicio = (
        '                        ((From
        '                              d In HeliosData.documentoLibroDiarioDetalle
        '                          Where
        '                              d.idItem = p.codigodetalle And
        '                              d.documentoLibroDiario.tipoRegistro = "APT_EXT" And
        '                              d.documentoLibroDiario.fecha = CType((Aggregate ss In HeliosData.documentoLibroDiarioDetalle
        '                                                                 Where ss.idItem = p.codigodetalle And
        '                                                                     ss.documentoLibroDiario.tipoRegistro = "APT_EXT"
        '                                                                     Into Max(ss.documentoLibroDiario.fecha)), DateTime?)
        '                          Select New With
        '                              {
        '                              d
        '                              }).FirstOrDefault().d))
        '                  ).OrderBy(Function(o) o.descripcion).ToList


        '    For Each i In consulta

        '        obj = New detalleitems
        '        If i.UltimaCompra IsNot Nothing Then
        '            obj.CustomDetalleCompra = New documentocompradetalle With
        '            {
        '                .FechaDoc = i.UltimaCompra.comp.fechaDoc,
        '                .monto1 = i.UltimaCompra.d.monto1,
        '                .destino = i.UltimaCompra.d.destino,
        '                .importe = i.UltimaCompra.d.importe
        '            }
        '            obj.CustomDetalleCompra.documentocompra = New documentocompra With
        '            {
        '            .tipoCompra = i.UltimaCompra.comp.tipoCompra
        '            }
        '        End If
        '        If i.UltimaEntradaInicio IsNot Nothing Then
        '            obj.InventarioInicio = i.UltimaEntradaInicio
        '        End If
        '        obj.codigodetalle = i.codigo
        '        obj.descripcionItem = i.descripcion.ToUpper
        '        obj.NomClasificacion = i.clasificaion
        '        obj.NomMarca = i.marca
        '        obj.origenProducto = i.gravado
        '        obj.tipoExistencia = i.tipoex
        '        obj.unidad1 = i.unidad
        '        obj.unidad2 = i.marca
        '        obj.presentacion = i.presentacion
        '        obj.tipoExistencia = i.tipoex
        '        obj.codigo = i.codigoBar
        '        obj.precioCompra = i.preciocompra
        '        obj.precioMenor = i.precioMenor.GetValueOrDefault
        '        obj.precioMayor = i.PrecioMayor.GetValueOrDefault
        '        obj.precioGranMayor = i.PrecioGranMayor.GetValueOrDefault
        '        Lista.Add(obj)
        '    Next

        'Else
        '    Dim filter1 As String = vectoraux(0)

        '    Dim consulta = (From p In HeliosData.detalleitems
        '                    Group Join clas In HeliosData.item
        '                   On p.idItem Equals clas.idItem
        '                   Into clas1 = Group
        '                    From cx In clas1.DefaultIfEmpty()
        '                    Group Join marca In HeliosData.item
        '                   On p.unidad2 Equals marca.idItem
        '                   Into marca1 = Group
        '                    From mx In marca1.DefaultIfEmpty()
        '                    Where p.idEmpresa = idempresa And p.descripcionItem.Contains(filter1)
        '                    Select
        '                   codigo = p.codigodetalle,
        '                        preciocompra = p.precioCompra,
        '                   descripcion = p.descripcionItem,
        '                   clasificaion = cx.descripcion,
        '                   marca = mx.descripcion,
        '                   gravado = p.origenProducto,
        '                   tipoex = p.tipoExistencia,
        '                   unidad = p.unidad1,
        '                   codigoBar = p.codigo,
        '                   presentacion = p.presentacion,
        '                        precioMenor = (
        '                        ((From
        '                              configuracionPrecioProductoes
        '                              In HeliosData.configuracionPrecioProducto
        '                          Where
        '                              configuracionPrecioProductoes.idproducto = p.codigodetalle And
        '                              CLng(configuracionPrecioProductoes.idPrecio) = 1 And
        '                              configuracionPrecioProductoes.fecha =
        '                              (Aggregate t2 In
        '                                   (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                    Where
        '                                        CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
        '                                        And configuracionPrecioProductoes0.idproducto = p.codigodetalle
        '                                    Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                          Select New With
        '                              {
        '                              configuracionPrecioProductoes.precioMN
        '                              }).FirstOrDefault().precioMN)),
        '                        PrecioMayor = (
        '                        ((From
        '                              configuracionPrecioProductoes
        '                              In HeliosData.configuracionPrecioProducto
        '                          Where
        '                              configuracionPrecioProductoes.idproducto = p.codigodetalle And
        '                              CLng(configuracionPrecioProductoes.idPrecio) = 2 And
        '                              configuracionPrecioProductoes.fecha =
        '                              (Aggregate t2 In
        '                                   (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                    Where
        '                                        CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
        '                                        And configuracionPrecioProductoes0.idproducto = p.codigodetalle
        '                                    Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                          Select New With
        '                              {
        '                              configuracionPrecioProductoes.precioMN
        '                              }).FirstOrDefault().precioMN)),
        '                        PrecioGranMayor = (
        '                        ((From
        '                              configuracionPrecioProductoes
        '                              In HeliosData.configuracionPrecioProducto
        '                          Where
        '                              configuracionPrecioProductoes.idproducto = p.codigodetalle And
        '                              CLng(configuracionPrecioProductoes.idPrecio) = 3 And
        '                              configuracionPrecioProductoes.fecha =
        '                              (Aggregate t2 In
        '                                   (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                    Where
        '                                        CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
        '                                        And configuracionPrecioProductoes0.idproducto = p.codigodetalle
        '                                    Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                          Select New With
        '                              {
        '                              configuracionPrecioProductoes.precioMN
        '                              }).FirstOrDefault().precioMN)),
        '                        UltimaCompra = (
        '                        ((From
        '                              d In HeliosData.documentocompradetalle
        '                          Join comp In HeliosData.documentocompra
        '                                  On comp.idDocumento Equals d.idDocumento
        '                          Where
        '                              d.idItem = p.codigodetalle And
        '                              d.documentocompra.fechaDoc =
        '                              CType((Aggregate ss In HeliosData.documentocompradetalle
        '                                         Where
        '                                             ss.idItem = p.codigodetalle And
        '                                             tipoCompras.Contains(ss.documentocompra.tipoCompra)
        '                                             Into Max(ss.documentocompra.fechaDoc)), DateTime?)
        '                          Select New With
        '                              {
        '                              d,
        '                              comp
        '                              }).FirstOrDefault())),
        '                        UltimaEntradaInicio = (
        '                        ((From
        '                              d In HeliosData.documentoLibroDiarioDetalle
        '                          Where
        '                              d.idItem = p.codigodetalle And
        '                              d.documentoLibroDiario.tipoRegistro = "APT_EXT" And
        '                              d.documentoLibroDiario.fecha = CType((Aggregate ss In HeliosData.documentoLibroDiarioDetalle
        '                                                                 Where ss.idItem = p.codigodetalle And
        '                                                                     ss.documentoLibroDiario.tipoRegistro = "APT_EXT"
        '                                                                     Into Max(ss.documentoLibroDiario.fecha)), DateTime?)
        '                          Select New With
        '                              {
        '                              d
        '                              }).FirstOrDefault().d))
        '                    ).OrderBy(Function(o) o.descripcion).ToList


        '    For Each i In consulta

        '        obj = New detalleitems
        '        If i.UltimaCompra IsNot Nothing Then
        '            obj.CustomDetalleCompra = New documentocompradetalle With
        '            {
        '                .FechaDoc = i.UltimaCompra.comp.fechaDoc,
        '                .monto1 = i.UltimaCompra.d.monto1,
        '                .destino = i.UltimaCompra.d.destino,
        '                .importe = i.UltimaCompra.d.importe
        '            }
        '            obj.CustomDetalleCompra.documentocompra = New documentocompra With
        '            {
        '            .tipoCompra = i.UltimaCompra.comp.tipoCompra
        '            }
        '        End If
        '        If i.UltimaEntradaInicio IsNot Nothing Then
        '            obj.InventarioInicio = i.UltimaEntradaInicio
        '        End If
        '        obj.codigodetalle = i.codigo
        '        obj.descripcionItem = i.descripcion.ToUpper
        '        obj.NomClasificacion = i.clasificaion
        '        obj.NomMarca = i.marca
        '        obj.origenProducto = i.gravado
        '        obj.tipoExistencia = i.tipoex
        '        obj.unidad1 = i.unidad
        '        obj.unidad2 = i.marca
        '        obj.presentacion = i.presentacion
        '        obj.tipoExistencia = i.tipoex
        '        obj.codigo = i.codigoBar
        '        obj.precioCompra = i.preciocompra
        '        obj.precioMenor = i.precioMenor.GetValueOrDefault
        '        obj.precioMayor = i.PrecioMayor.GetValueOrDefault
        '        obj.precioGranMayor = i.PrecioGranMayor.GetValueOrDefault
        '        Lista.Add(obj)
        '    Next
        'End If



        Return Lista
    End Function

    Public Function GetPrecioPorProducto(idempresa As String, idProducto As Integer) As List(Of detalleitems)
        Dim obj As New detalleitems
        Dim Lista As New List(Of detalleitems)
        Dim tipoCompras As New List(Of String)
        tipoCompras.Add(TIPO_COMPRA.COMPRA)
        tipoCompras.Add(TIPO_COMPRA.OTRAS_ENTRADAS)
        tipoCompras.Add(TIPO_COMPRA.NOTA_DE_COMPRA)

        Dim consulta = (From p In HeliosData.detalleitems
                        Group Join clas In HeliosData.item
                       On p.idItem Equals clas.idItem
                       Into clas1 = Group
                        From cx In clas1.DefaultIfEmpty()
                        Group Join marca In HeliosData.item
                       On p.unidad2 Equals marca.idItem
                       Into marca1 = Group
                        From mx In marca1.DefaultIfEmpty()
                        Where p.idEmpresa = idempresa And p.codigodetalle = idProducto
                        Select
                       codigo = p.codigodetalle,
                            preciocompra = p.precioCompra,
                       descripcion = p.descripcionItem,
                       clasificaion = cx.descripcion,
                       marca = mx.descripcion,
                       gravado = p.origenProducto,
                       tipoex = p.tipoExistencia,
                       unidad = p.unidad1,
                       codigoBar = p.codigo,
                       presentacion = p.presentacion,
                            precioMenor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            PrecioMayor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            PrecioGranMayor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            UltimaCompra = (
                            ((From
                                  d In HeliosData.documentocompradetalle
                              Join comp In HeliosData.documentocompra
                                      On comp.idDocumento Equals d.idDocumento
                              Where
                                  d.idItem = p.codigodetalle And
                                  d.documentocompra.fechaDoc =
                                  CType((Aggregate ss In HeliosData.documentocompradetalle
                                             Where
                                                 ss.idItem = p.codigodetalle And
                                                 tipoCompras.Contains(ss.documentocompra.tipoCompra)
                                                 Into Max(ss.documentocompra.fechaDoc)), DateTime?)
                              Select New With
                                  {
                                  d,
                                  comp
                                  }).FirstOrDefault())),
                            UltimaEntradaInicio = (
                            ((From
                                  d In HeliosData.documentoLibroDiarioDetalle
                              Where
                                  d.idItem = p.codigodetalle And
                                  d.documentoLibroDiario.tipoRegistro = "APT_EXT" And
                                  d.documentoLibroDiario.fecha = CType((Aggregate ss In HeliosData.documentoLibroDiarioDetalle
                                                                     Where ss.idItem = p.codigodetalle And
                                                                         ss.documentoLibroDiario.tipoRegistro = "APT_EXT"
                                                                         Into Max(ss.documentoLibroDiario.fecha)), DateTime?)
                              Select New With
                                  {
                                  d
                                  }).FirstOrDefault().d))
                            ).OrderBy(Function(o) o.descripcion).ToList


        For Each i In consulta

            obj = New detalleitems
            If i.UltimaCompra IsNot Nothing Then
                obj.CustomDetalleCompra = New documentocompradetalle With
                {
                    .FechaDoc = i.UltimaCompra.comp.fechaDoc,
                    .monto1 = i.UltimaCompra.d.monto1,
                    .destino = i.UltimaCompra.d.destino,
                    .importe = i.UltimaCompra.d.importe
                }
                obj.CustomDetalleCompra.documentocompra = New documentocompra With
                {
                .tipoCompra = i.UltimaCompra.comp.tipoCompra
                }
            End If
            If i.UltimaEntradaInicio IsNot Nothing Then
                obj.InventarioInicio = i.UltimaEntradaInicio
            End If
            obj.codigodetalle = i.codigo
            obj.descripcionItem = i.descripcion.ToUpper
            obj.NomClasificacion = i.clasificaion
            obj.NomMarca = i.marca
            obj.origenProducto = i.gravado
            obj.tipoExistencia = i.tipoex
            obj.unidad1 = i.unidad
            obj.unidad2 = i.marca
            obj.presentacion = i.presentacion
            obj.tipoExistencia = i.tipoex
            obj.codigo = i.codigoBar
            obj.precioCompra = i.preciocompra
            obj.precioMenor = i.precioMenor.GetValueOrDefault
            obj.precioMayor = i.PrecioMayor.GetValueOrDefault
            obj.precioGranMayor = i.PrecioGranMayor.GetValueOrDefault
            Lista.Add(obj)
        Next

        Return Lista
    End Function

    Public Function GetExistenciasByempresaCodigo(idempresa As String, idEstable As Integer, codigoBarra As String) As List(Of detalleitems)
        Dim obj As New detalleitems
        Dim Lista As New List(Of detalleitems)
        Dim tipoCompras As New List(Of String)
        tipoCompras.Add(TIPO_COMPRA.COMPRA)
        tipoCompras.Add(TIPO_COMPRA.OTRAS_ENTRADAS)
        tipoCompras.Add(TIPO_COMPRA.NOTA_DE_COMPRA)
        tipoCompras.Add(TIPO_COMPRA.NOTA_DE_COMPRA_EN_ESPERA)
        Dim consulta = (From p In HeliosData.detalleitems
                        Group Join clas In HeliosData.item
                       On p.idItem Equals clas.idItem
                       Into clas1 = Group
                        From cx In clas1.DefaultIfEmpty()
                        Group Join marca In HeliosData.item
                       On p.unidad2 Equals marca.idItem
                       Into marca1 = Group
                        From mx In marca1.DefaultIfEmpty()
                        Where p.idEmpresa = idempresa And
                            p.idEstablecimiento = idEstable And
                            p.codigo = codigoBarra
                        Select
                       codigoProducto = p.codigodetalle,
                            preciocompra = p.precioCompra,
                       descripcion = p.descripcionItem,
                       clasificaion = cx.descripcion,
                       marca = mx.descripcion,
                       gravado = p.origenProducto,
                       tipoex = p.tipoExistencia,
                       unidad = p.unidad1,
                       codigoBar = p.codigo,
                        presentacion = p.presentacion,
                            precioMenor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            PrecioMayor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            PrecioGranMayor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            UltimaCompra = (
                            ((From
                                  d In HeliosData.documentocompradetalle
                              Join comp In HeliosData.documentocompra
                                      On comp.idDocumento Equals d.idDocumento
                              Where
                                  d.idItem = p.codigodetalle And
                                  d.documentocompra.fechaDoc =
                                  CType((Aggregate ss In HeliosData.documentocompradetalle
                                             Where
                                                 ss.idItem = p.codigodetalle And
                                                 tipoCompras.Contains(ss.documentocompra.tipoCompra)
                                                 Into Max(ss.documentocompra.fechaDoc)), DateTime?)
                              Select New With
                                  {
                                  d,
                                  comp
                                  }).FirstOrDefault())),
                            UltimaEntradaInicio = (
                            ((From
                                  d In HeliosData.documentoLibroDiarioDetalle
                              Where
                                  d.idItem = p.codigodetalle And
                                  d.documentoLibroDiario.tipoRegistro = "APT_EXT" And
                                  d.documentoLibroDiario.fecha = CType((Aggregate ss In HeliosData.documentoLibroDiarioDetalle
                                                                     Where ss.idItem = p.codigodetalle And
                                                                         ss.documentoLibroDiario.tipoRegistro = "APT_EXT"
                                                                         Into Max(ss.documentoLibroDiario.fecha)), DateTime?)
                              Select New With
                                  {
                                  d
                                  }).FirstOrDefault().d))
                            ).OrderBy(Function(o) o.descripcion).ToList


        For Each i In consulta
            obj = New detalleitems
            If i.UltimaCompra IsNot Nothing Then
                obj.CustomDetalleCompra = New documentocompradetalle With
                {
                    .FechaDoc = i.UltimaCompra.comp.fechaDoc,
                    .monto1 = i.UltimaCompra.d.monto1,
                    .destino = i.UltimaCompra.d.destino,
                    .importe = i.UltimaCompra.d.importe
                }
                obj.CustomDetalleCompra.documentocompra = New documentocompra With
                {
                .tipoCompra = i.UltimaCompra.comp.tipoCompra
                }
            End If
            If i.UltimaEntradaInicio IsNot Nothing Then
                obj.InventarioInicio = i.UltimaEntradaInicio
            End If
            obj.codigodetalle = i.codigoProducto
            obj.descripcionItem = i.descripcion
            obj.NomClasificacion = i.clasificaion
            obj.NomMarca = i.marca
            obj.origenProducto = i.gravado
            obj.tipoExistencia = i.tipoex
            obj.unidad1 = i.unidad
            obj.presentacion = i.presentacion
            obj.tipoExistencia = i.tipoex
            obj.codigo = i.codigoBar
            obj.precioCompra = i.preciocompra
            obj.precioMenor = i.precioMenor.GetValueOrDefault
            obj.precioMayor = i.PrecioMayor.GetValueOrDefault
            obj.precioGranMayor = i.PrecioGranMayor.GetValueOrDefault
            Lista.Add(obj)
        Next

        Return Lista
    End Function

    Public Function GetExistenciasByempresa() As List(Of detalleitems)
        Dim obj As New detalleitems
        Dim Lista As New List(Of detalleitems)

        Dim consulta = (From p In HeliosData.detalleitems
                        Group Join clas In HeliosData.item
                        On p.idItem Equals clas.idItem
                        Into clas1 = Group
                        From cx In clas1.DefaultIfEmpty()
                        Group Join marca In HeliosData.item
                        On p.marcaRef Equals marca.idItem
                        Into marca1 = Group
                        From mx In marca1.DefaultIfEmpty()
                        Where p.idEmpresa = Gempresas.IdEmpresaRuc
                        Select
                        codigo = p.codigodetalle,
                        descripcion = p.descripcionItem,
                        clasificaion = cx.descripcion,
                        marca = mx.descripcion,
                        gravado = p.origenProducto,
                        tipoex = p.tipoExistencia,
                        unidad = p.unidad1,
                        presentacion = p.presentacion).OrderBy(Function(o) o.descripcion).ToList


        For Each i In consulta
            obj = New detalleitems
            obj.codigodetalle = i.codigo
            obj.descripcionItem = i.descripcion
            obj.NomClasificacion = i.clasificaion
            obj.NomMarca = i.marca
            obj.origenProducto = i.gravado
            obj.tipoExistencia = i.tipoex
            obj.unidad1 = i.unidad
            obj.presentacion = i.presentacion
            obj.tipoExistencia = i.tipoex
            Lista.Add(obj)
        Next

        Return Lista
    End Function

    Public Function GetTipoExistenciasByempresa(tipo As Integer) As List(Of detalleitems)
        Dim obj As New detalleitems
        Dim Lista As New List(Of detalleitems)

        Dim consulta = (From p In HeliosData.detalleitems
                        Group Join clas In HeliosData.item
                     On p.idItem Equals clas.idItem
                     Into clas1 = Group
                        From cx In clas1.DefaultIfEmpty()
                        Group Join marca In HeliosData.item
                     On p.marcaRef Equals marca.idItem
                     Into marca1 = Group
                        From mx In marca1.DefaultIfEmpty()
                        Where p.tipoExistencia = tipo
                        Select
                     codigo = p.codigodetalle,
                     descripcion = p.descripcionItem,
                     clasificaion = cx.descripcion,
                     marca = mx.descripcion,
                     gravado = p.origenProducto,
                     tipoex = p.tipoExistencia,
                     unidad = p.unidad1,
                     codigobarra = p.codigo,
                     presentacion = p.presentacion).OrderBy(Function(o) o.descripcion).ToList


        'Dim consulta = (From p In HeliosData.detalleitems _
        '               Group Join clas In HeliosData.item _
        '               On p.idItem Equals clas.idItem _
        '               Into clas1 = Group _
        '               From cx In clas1.DefaultIfEmpty() _
        '               Group Join marca In HeliosData.item _
        '               On p.marcaRef Equals marca.idItem _
        '               Into marca1 = Group _
        '               From mx In marca1.DefaultIfEmpty() _
        '               Where p.idEmpresa = Gempresas.IdEmpresaRuc And _
        '               p.tipoExistencia = tipo _
        '               Select _
        '               codigo = p.codigodetalle,
        '               descripcion = p.descripcionItem,
        '               clasificaion = cx.descripcion,
        '               marca = mx.descripcion,
        '               gravado = p.origenProducto,
        '               tipoex = p.tipoExistencia,
        '               unidad = p.unidad1,
        '               codigobarra = p.codigo,
        '               presentacion = p.presentacion).OrderBy(Function(o) o.descripcion).ToList


        For Each i In consulta
            obj = New detalleitems
            obj.codigodetalle = i.codigo
            obj.descripcionItem = i.descripcion
            obj.NomClasificacion = i.clasificaion
            obj.NomMarca = i.marca
            obj.origenProducto = i.gravado
            obj.tipoExistencia = i.tipoex
            obj.unidad1 = i.unidad
            obj.presentacion = i.presentacion
            obj.tipoExistencia = i.tipoex
            obj.codigo = i.codigobarra
            Lista.Add(obj)
        Next

        Return Lista
    End Function

    Public Function GetProductosSinAsignarPrecios(be As detalleitems) As List(Of detalleitems)
        Dim obj As detalleitems

        Dim tipoCompras As New List(Of String)
        tipoCompras.Add(TIPO_COMPRA.COMPRA)
        tipoCompras.Add(TIPO_COMPRA.OTRAS_ENTRADAS)
        tipoCompras.Add(TIPO_COMPRA.NOTA_DE_COMPRA)
        Dim consulta = (From art In HeliosData.detalleitems
                        Group Join clas In HeliosData.item
                            On art.idItem Equals clas.idItem
                            Into clas1 = Group
                        From cx In clas1.DefaultIfEmpty()
                        Group Join marca In HeliosData.item
                            On art.unidad2 Equals marca.idItem
                            Into marca1 = Group
                        From mx In marca1.DefaultIfEmpty()
                        Where
                           art.idEmpresa = be.idEmpresa And
                            art.idEstablecimiento = be.idEstablecimiento And
                            art.tipoExistencia = "01" And
                           Not (Not _
                           (From TotalesAlmacen In HeliosData.configuracionPrecioProducto
                            Where
                                TotalesAlmacen.idproducto = art.codigodetalle
                            Select New With {
                                TotalesAlmacen
                                }).FirstOrDefault() Is Nothing)
                        Select
                            codigoProd = art.codigodetalle,
                            preciocompra = art.precioCompra,
                            descripcion = art.descripcionItem,
                            clasificaion = cx.descripcion,
                            marca = mx.descripcion,
                            gravado = art.origenProducto,
                            tipoex = art.tipoExistencia,
                            unidad = art.unidad1,
                            codigobarra = art.codigo,
                            presentacion = art.presentacion,
                            UltimaCompra = (
                            ((From
                                  d In HeliosData.documentocompradetalle
                              Join comp In HeliosData.documentocompra
                                      On comp.idDocumento Equals d.idDocumento
                              Where
                                  d.idItem = art.codigodetalle And
                                  d.documentocompra.fechaDoc =
                                  CType((Aggregate ss In HeliosData.documentocompradetalle
                                             Where
                                                 ss.idItem = art.codigodetalle And
                                                 tipoCompras.Contains(ss.documentocompra.tipoCompra)
                                                 Into Max(ss.documentocompra.fechaDoc)), DateTime?)
                              Select New With
                                  {
                                  d,
                                  comp
                                  }).FirstOrDefault())),
                            UltimaEntradaInicio = (
                            ((From
                                  d In HeliosData.documentoLibroDiarioDetalle
                              Where
                                  d.idItem = art.codigodetalle And
                                  d.documentoLibroDiario.tipoRegistro = "APT_EXT" And
                                  d.documentoLibroDiario.fecha = CType((Aggregate ss In HeliosData.documentoLibroDiarioDetalle
                                                                     Where ss.idItem = art.codigodetalle And
                                                                         ss.documentoLibroDiario.tipoRegistro = "APT_EXT"
                                                                         Into Max(ss.documentoLibroDiario.fecha)), DateTime?)
                              Select New With
                                  {
                                  d
                                  }).FirstOrDefault().d))
                            ).OrderBy(Function(o) o.descripcion).ToList


        GetProductosSinAsignarPrecios = New List(Of detalleitems)
        For Each i In consulta
            obj = New detalleitems

            If i.UltimaCompra IsNot Nothing Then

                obj.CustomDetalleCompra = New documentocompradetalle With
                {
                    .FechaDoc = i.UltimaCompra.comp.fechaDoc,
                    .monto1 = i.UltimaCompra.d.monto1,
                    .destino = i.UltimaCompra.d.destino,
                    .importe = i.UltimaCompra.d.importe
                }
                obj.CustomDetalleCompra.documentocompra = New documentocompra With
                {
                .tipoCompra = i.UltimaCompra.comp.tipoCompra
                }
            End If

            If i.UltimaEntradaInicio IsNot Nothing Then
                obj.InventarioInicio = i.UltimaEntradaInicio
            End If

            obj.codigodetalle = i.codigoProd
            obj.descripcionItem = i.descripcion
            obj.NomClasificacion = i.clasificaion
            obj.NomMarca = i.marca
            obj.origenProducto = i.gravado
            obj.tipoExistencia = i.tipoex
            obj.unidad1 = i.unidad
            obj.unidad2 = i.marca
            obj.presentacion = i.presentacion
            obj.codigo = i.codigobarra
            obj.precioCompra = i.preciocompra
            obj.precioMenor = 0
            obj.precioMayor = 0
            obj.precioGranMayor = 0

            obj.precioMenorME = 0
            obj.precioMayorME = 0
            obj.precioGranMayorME = 0
            GetProductosSinAsignarPrecios.Add(obj)
        Next
    End Function

    Public Function GetTipoExistenciasByEmpresaConPrecios(empresa As String, tipo As String) As List(Of detalleitems)
        Dim obj As New detalleitems
        Dim Lista As New List(Of detalleitems)

        Dim consulta = HeliosData.usp_GetProductsEmpresa(empresa, tipo).ToList

        'Dim tipoCompras As New List(Of String)
        'tipoCompras.Add(TIPO_COMPRA.COMPRA)
        'tipoCompras.Add(TIPO_COMPRA.OTRAS_ENTRADAS)
        'tipoCompras.Add(TIPO_COMPRA.NOTA_DE_COMPRA)
        ''p.tipoExistencia = tipo And
        'Dim consulta = (From p In HeliosData.detalleitems
        '                Group Join clas In HeliosData.item
        '                    On p.idItem Equals clas.idItem
        '                    Into clas1 = Group
        '                From cx In clas1.DefaultIfEmpty()
        '                Group Join marca In HeliosData.item
        '                    On p.unidad2 Equals marca.idItem
        '                    Into marca1 = Group
        '                From mx In marca1.DefaultIfEmpty()
        '                Where p.idEmpresa = empresa
        '                Select
        '                    codigo = p.codigodetalle,
        '                    preciocompra = p.precioCompra,
        '                    descripcion = p.descripcionItem,
        '                    clasificaion = cx.descripcion,
        '                    marca = mx.descripcion,
        '                    gravado = p.origenProducto,
        '                    tipoex = p.tipoExistencia,
        '                    unidad = p.unidad1,
        '                    codigobarra = p.codigo,
        '                    presentacion = p.presentacion,
        '                    precioMenor = (
        '                    ((From
        '                          configuracionPrecioProductoes
        '                          In HeliosData.configuracionPrecioProducto
        '                      Where
        '                          configuracionPrecioProductoes.idproducto = p.codigodetalle And
        '                          CLng(configuracionPrecioProductoes.idPrecio) = 1 And
        '                          configuracionPrecioProductoes.fecha =
        '                          (Aggregate t2 In
        '                               (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                Where
        '                                    CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
        '                                    And configuracionPrecioProductoes0.idproducto = p.codigodetalle
        '                                Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                      Select New With
        '                          {
        '                          configuracionPrecioProductoes.precioMN
        '                          }).FirstOrDefault().precioMN)),
        '                    precioMenorME = (
        '                    ((From
        '                          configuracionPrecioProductoes
        '                          In HeliosData.configuracionPrecioProducto
        '                      Where
        '                          configuracionPrecioProductoes.idproducto = p.codigodetalle And
        '                          CLng(configuracionPrecioProductoes.idPrecio) = 1 And
        '                          configuracionPrecioProductoes.fecha =
        '                          (Aggregate t2 In
        '                               (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                Where
        '                                    CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
        '                                    And configuracionPrecioProductoes0.idproducto = p.codigodetalle
        '                                Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                      Select New With
        '                          {
        '                          configuracionPrecioProductoes.precioME
        '                          }).FirstOrDefault().precioME)),
        '                    PrecioMayor = (
        '                    ((From
        '                          configuracionPrecioProductoes
        '                          In HeliosData.configuracionPrecioProducto
        '                      Where
        '                          configuracionPrecioProductoes.idproducto = p.codigodetalle And
        '                          CLng(configuracionPrecioProductoes.idPrecio) = 2 And
        '                          configuracionPrecioProductoes.fecha =
        '                          (Aggregate t2 In
        '                               (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                Where
        '                                    CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
        '                                    And configuracionPrecioProductoes0.idproducto = p.codigodetalle
        '                                Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                      Select New With
        '                          {
        '                          configuracionPrecioProductoes.precioMN
        '                          }).FirstOrDefault().precioMN)),
        '                    PrecioMayorME = (
        '                    ((From
        '                          configuracionPrecioProductoes
        '                          In HeliosData.configuracionPrecioProducto
        '                      Where
        '                          configuracionPrecioProductoes.idproducto = p.codigodetalle And
        '                          CLng(configuracionPrecioProductoes.idPrecio) = 2 And
        '                          configuracionPrecioProductoes.fecha =
        '                          (Aggregate t2 In
        '                               (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                Where
        '                                    CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
        '                                    And configuracionPrecioProductoes0.idproducto = p.codigodetalle
        '                                Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                      Select New With
        '                          {
        '                          configuracionPrecioProductoes.precioME
        '                          }).FirstOrDefault().precioME)),
        '                    PrecioGranMayor = (
        '                    ((From
        '                          configuracionPrecioProductoes
        '                          In HeliosData.configuracionPrecioProducto
        '                      Where
        '                          configuracionPrecioProductoes.idproducto = p.codigodetalle And
        '                          CLng(configuracionPrecioProductoes.idPrecio) = 3 And
        '                          configuracionPrecioProductoes.fecha =
        '                          (Aggregate t2 In
        '                               (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                Where
        '                                    CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
        '                                    And configuracionPrecioProductoes0.idproducto = p.codigodetalle
        '                                Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                      Select New With
        '                          {
        '                          configuracionPrecioProductoes.precioMN
        '                          }).FirstOrDefault().precioMN)),
        '                    PrecioGranMayorME = (
        '                    ((From
        '                          configuracionPrecioProductoes
        '                          In HeliosData.configuracionPrecioProducto
        '                      Where
        '                          configuracionPrecioProductoes.idproducto = p.codigodetalle And
        '                          CLng(configuracionPrecioProductoes.idPrecio) = 3 And
        '                          configuracionPrecioProductoes.fecha =
        '                          (Aggregate t2 In
        '                               (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                Where
        '                                    CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
        '                                    And configuracionPrecioProductoes0.idproducto = p.codigodetalle
        '                                Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                      Select New With
        '                          {
        '                          configuracionPrecioProductoes.precioME
        '                          }).FirstOrDefault().precioME)),
        '                    UltimaCompra = (
        '                    ((From
        '                          d In HeliosData.documentocompradetalle
        '                      Join comp In HeliosData.documentocompra
        '                              On comp.idDocumento Equals d.idDocumento
        '                      Where
        '                          d.idItem = p.codigodetalle And
        '                          d.documentocompra.fechaDoc =
        '                          CType((Aggregate ss In HeliosData.documentocompradetalle
        '                                     Where
        '                                         ss.idItem = p.codigodetalle And
        '                                         tipoCompras.Contains(ss.documentocompra.tipoCompra)
        '                                         Into Max(ss.documentocompra.fechaDoc)), DateTime?)
        '                      Select New With
        '                          {
        '                          d,
        '                          comp
        '                          }).FirstOrDefault())),
        '                    UltimaEntradaInicio = (
        '                    ((From
        '                          d In HeliosData.documentoLibroDiarioDetalle
        '                      Where
        '                          d.idItem = p.codigodetalle And
        '                          d.documentoLibroDiario.tipoRegistro = "APT_EXT" And
        '                          d.documentoLibroDiario.fecha = CType((Aggregate ss In HeliosData.documentoLibroDiarioDetalle
        '                                                             Where ss.idItem = p.codigodetalle And
        '                                                                 ss.documentoLibroDiario.tipoRegistro = "APT_EXT"
        '                                                                 Into Max(ss.documentoLibroDiario.fecha)), DateTime?)
        '                      Select New With
        '                          {
        '                          d
        '                          }).FirstOrDefault().d))
        '                    ).OrderBy(Function(o) o.descripcion).ToList




        Dim datosPreciosMenor() As String
        Dim datosPreciosMayor() As String
        Dim datosPreciosGranMenor() As String

        Dim ValorprecioMenorMN As Decimal = 0
        Dim ValorprecioMenorME As Decimal = 0
        Dim ValorprecioMayorMN As Decimal = 0
        Dim ValorprecioMayorME As Decimal = 0
        Dim ValorprecioGMayorMN As Decimal = 0
        Dim ValorprecioGMayorME As Decimal = 0
        For Each i In consulta
            obj = New detalleitems

            '   Dim valorNulo() As String = {"0.00", "0.00"}
            Dim precMenor As String = i.menor
            Dim precMayor As String = i.mayor
            Dim precGMayor As String = i.granMayor


            If precMenor IsNot Nothing Then
                datosPreciosMenor = precMenor.Split(New Char() {"|"c})
                ValorprecioMenorMN = datosPreciosMenor(0)
                ValorprecioMenorME = If(datosPreciosMenor(1) = "", 0, datosPreciosMenor(1))
            Else
                ValorprecioMenorMN = 0
                ValorprecioMenorME = 0
            End If

            If precMayor IsNot Nothing Then
                datosPreciosMayor = precMayor.Split(New Char() {"|"c})
                ValorprecioMayorMN = datosPreciosMayor(0)
                ValorprecioMayorME = If(datosPreciosMayor(1) = "", 0, datosPreciosMayor(1))
            Else
                ValorprecioMayorMN = 0
                ValorprecioMayorME = 0
            End If

            If precGMayor IsNot Nothing Then
                datosPreciosGranMenor = precGMayor.Split(New Char() {"|"c})
                ValorprecioGMayorMN = datosPreciosGranMenor(0)
                ValorprecioGMayorME = If(datosPreciosGranMenor(1) = "", 0, datosPreciosGranMenor(1))
            Else
                ValorprecioGMayorMN = 0
                ValorprecioGMayorME = 0
            End If

            If i.UltimaEntrada IsNot Nothing Then
                Dim s As String = i.UltimaEntrada

                Dim datosEntrada() As String = s.Split(New Char() {","c})


                '   Dim parts As String() = s.Split(New Char() {","c})

                Dim tipcompra As String = datosEntrada(0)
                Dim fechacompra As String = datosEntrada(1)
                Dim destino As String = datosEntrada(2)
                Dim baseimponible = datosEntrada(3)
                Dim total = datosEntrada(4)
                Dim cant = datosEntrada(5)



                obj.CustomDetalleCompra = New documentocompradetalle With
                {
                    .FechaDoc = fechacompra,' i.UltimaCompra.comp.fechaDoc,
                    .monto1 = cant,'i.UltimaCompra.d.monto1,
                    .destino = destino,' i.UltimaCompra.d.destino,
                    .importe = total'i.UltimaCompra.d.importe
                }
                obj.CustomDetalleCompra.documentocompra = New documentocompra With
                {
                .tipoCompra = tipcompra' i.UltimaCompra.comp.tipoCompra
                }
            End If

            'If i.UltimaEntradaInicio IsNot Nothing Then
            '    obj.InventarioInicio = i.UltimaEntradaInicio
            'End If

            obj.codigodetalle = i.codigodetalle
            obj.descripcionItem = i.descripcionItem
            obj.NomClasificacion = i.GrupoName
            obj.NomMarca = i.MarcaName
            obj.origenProducto = i.origenProducto
            obj.tipoExistencia = i.tipoExistencia
            obj.unidad1 = i.unidad1
            obj.unidad2 = i.MarcaName
            obj.presentacion = String.Empty 'i.presentacion
            obj.codigo = i.codigo
            obj.precioCompra = i.precioCompra
            obj.precioMenor = ValorprecioMenorMN ' i.menor.GetValueOrDefault '  i.precioMenor.GetValueOrDefault
            obj.precioMayor = ValorprecioMayorMN ' i.mayor.GetValueOrDefault ' i.PrecioMayor.GetValueOrDefault
            obj.precioGranMayor = ValorprecioGMayorMN ' i.granMayor.GetValueOrDefault ' i.PrecioGranMayor.GetValueOrDefault

            obj.precioMenorME = ValorprecioMenorME ' 0 ' i.precioMenorME.GetValueOrDefault
            obj.precioMayorME = ValorprecioMayorME '0 ' i.PrecioMayorME.GetValueOrDefault
            obj.precioGranMayorME = ValorprecioGMayorME ' 0 ' i.PrecioGranMayorME.GetValueOrDefault
            Lista.Add(obj)
        Next

        Return Lista
    End Function

    Public Function GetDetalleItemsXEmpresa(empresa As String, idEstable As Integer, tipo As String, search As String) As List(Of detalleitems)
        Dim obj As New detalleitems
        Dim Lista As New List(Of detalleitems)

        Dim tipoCompras As New List(Of String)
        tipoCompras.Add(TIPO_COMPRA.COMPRA)
        tipoCompras.Add(TIPO_COMPRA.OTRAS_ENTRADAS)
        tipoCompras.Add(TIPO_COMPRA.NOTA_DE_COMPRA)
        tipoCompras.Add(TIPO_COMPRA.NOTA_DE_COMPRA_EN_ESPERA)
        'p.tipoExistencia = tipo And
        Dim pageNumber = 1
        Dim pageSize = 10
        '   Dim result = HeliosData.detalleitems.Skip((pageNumber - 1) * pageSize).Take(pageSize)

        Dim consulta = (From p In HeliosData.detalleitems
                        Group Join clas In HeliosData.item
                            On p.idItem Equals clas.idItem
                            Into clas1 = Group
                        From cx In clas1.DefaultIfEmpty()
                        Group Join marca In HeliosData.item
                            On p.unidad2 Equals marca.idItem
                            Into marca1 = Group
                        From mx In marca1.DefaultIfEmpty()
                        Where p.idEmpresa = empresa And
                            p.idEstablecimiento = idEstable And
                            p.tipoExistencia = tipo And
                            p.descripcionItem.Contains(search)
                        Select
                            Composicion = p.composicion,
                            codigoProd = p.codigodetalle,
                            preciocompra = p.precioCompra,
                            descripcion = p.descripcionItem,
                            clasificaion = cx.descripcion,
                            marca = mx.descripcion,
                            gravado = p.origenProducto,
                            tipoex = p.tipoExistencia,
                            unidad = p.unidad1,
                            codigobarra = p.codigo,
                            presentacion = p.presentacion,
                            precioMenor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            precioMenorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                            PrecioMayor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            PrecioMayorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                            PrecioGranMayor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            PrecioGranMayorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                            UltimaCompra = (
                            ((From
                                  d In HeliosData.documentocompradetalle
                              Join comp In HeliosData.documentocompra
                                      On comp.idDocumento Equals d.idDocumento
                              Where
                                  d.idItem = p.codigodetalle And
                                  d.documentocompra.fechaDoc =
                                  CType((Aggregate ss In HeliosData.documentocompradetalle
                                             Where
                                                 ss.idItem = p.codigodetalle And
                                                 tipoCompras.Contains(ss.documentocompra.tipoCompra)
                                                 Into Max(ss.documentocompra.fechaDoc)), DateTime?)
                              Select New With
                                  {
                                  d,
                                  comp
                                  }).FirstOrDefault())),
                            UltimaEntradaInicio = (
                            ((From
                                  d In HeliosData.documentoLibroDiarioDetalle
                              Where
                                  d.idItem = p.codigodetalle And
                                  d.documentoLibroDiario.tipoRegistro = "APT_EXT" And
                                  d.documentoLibroDiario.fecha = CType((Aggregate ss In HeliosData.documentoLibroDiarioDetalle
                                                                     Where ss.idItem = p.codigodetalle And
                                                                         ss.documentoLibroDiario.tipoRegistro = "APT_EXT"
                                                                         Into Max(ss.documentoLibroDiario.fecha)), DateTime?)
                              Select New With
                                  {
                                  d
                                  }).FirstOrDefault().d))
                            ).OrderBy(Function(o) o.descripcion).ToList


        For Each i In consulta
            obj = New detalleitems

            If i.UltimaCompra IsNot Nothing Then

                obj.CustomDetalleCompra = New documentocompradetalle With
                {
                    .FechaDoc = i.UltimaCompra.comp.fechaDoc,
                    .monto1 = i.UltimaCompra.d.monto1,
                    .destino = i.UltimaCompra.d.destino,
                    .importe = i.UltimaCompra.d.importe
                }
                obj.CustomDetalleCompra.documentocompra = New documentocompra With
                {
                .tipoCompra = i.UltimaCompra.comp.tipoCompra
                }
            End If

            If i.UltimaEntradaInicio IsNot Nothing Then
                obj.InventarioInicio = i.UltimaEntradaInicio
            End If

            obj.codigodetalle = i.codigoProd
            obj.composicion = i.Composicion
            obj.descripcionItem = i.descripcion
            obj.NomClasificacion = i.clasificaion
            obj.NomMarca = i.marca
            obj.origenProducto = i.gravado
            obj.tipoExistencia = i.tipoex
            obj.unidad1 = i.unidad
            obj.unidad2 = i.marca
            obj.presentacion = i.presentacion
            obj.codigo = i.codigobarra
            obj.precioCompra = i.preciocompra
            obj.precioMenor = i.precioMenor.GetValueOrDefault
            obj.precioMayor = i.PrecioMayor.GetValueOrDefault
            obj.precioGranMayor = i.PrecioGranMayor.GetValueOrDefault

            obj.precioMenorME = i.precioMenorME.GetValueOrDefault
            obj.precioMayorME = i.PrecioMayorME.GetValueOrDefault
            obj.precioGranMayorME = i.PrecioGranMayorME.GetValueOrDefault
            Lista.Add(obj)
        Next

        Return Lista
    End Function

    Public Function GetProductosMarca(be As detalleitems) As List(Of detalleitems)
        Dim obj As New detalleitems
        Dim Lista As New List(Of detalleitems)
        Dim tipoCompras As New List(Of String)
        tipoCompras.Add(TIPO_COMPRA.COMPRA)
        tipoCompras.Add(TIPO_COMPRA.OTRAS_ENTRADAS)
        tipoCompras.Add(TIPO_COMPRA.NOTA_DE_COMPRA)


        Dim consulta = (From p In HeliosData.detalleitems
                        Group Join clas In HeliosData.item
                            On p.idItem Equals clas.idItem
                            Into clas1 = Group
                        From cx In clas1.DefaultIfEmpty()
                        Join marca In HeliosData.item
                            On p.unidad2 Equals marca.idItem
                        Where p.idEmpresa = be.idEmpresa And
                            p.unidad2 = be.unidad2
                        Select
                            codigo = p.codigodetalle,
                            preciocompra = p.precioCompra,
                            descripcion = p.descripcionItem,
                            clasificaion = cx.descripcion,
                            marca = marca.descripcion,
                            gravado = p.origenProducto,
                            tipoex = p.tipoExistencia,
                            unidad = p.unidad1,
                            codigobarra = p.codigo,
                            presentacion = p.presentacion,
                            precioMenor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            precioMenorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                            PrecioMayor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            PrecioMayorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                            PrecioGranMayor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            PrecioGranMayorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                            UltimaCompra = (
                            ((From
                                  d In HeliosData.documentocompradetalle
                              Join comp In HeliosData.documentocompra
                                      On comp.idDocumento Equals d.idDocumento
                              Where
                                  d.idItem = p.codigodetalle And
                                  d.documentocompra.fechaDoc =
                                  CType((Aggregate ss In HeliosData.documentocompradetalle
                                             Where
                                                 ss.idItem = p.codigodetalle And
                                                 tipoCompras.Contains(ss.documentocompra.tipoCompra)
                                                 Into Max(ss.documentocompra.fechaDoc)), DateTime?)
                              Select New With
                                  {
                                  d,
                                  comp
                                  }).FirstOrDefault())),
                            UltimaEntradaInicio = (
                            ((From
                                  d In HeliosData.documentoLibroDiarioDetalle
                              Where
                                  d.idItem = p.codigodetalle And
                                  d.documentoLibroDiario.tipoRegistro = "APT_EXT" And
                                  d.documentoLibroDiario.fecha = CType((Aggregate ss In HeliosData.documentoLibroDiarioDetalle
                                                                     Where ss.idItem = p.codigodetalle And
                                                                         ss.documentoLibroDiario.tipoRegistro = "APT_EXT"
                                                                         Into Max(ss.documentoLibroDiario.fecha)), DateTime?)
                              Select New With
                                  {
                                  d
                                  }).FirstOrDefault().d))
                         ).OrderBy(Function(o) o.descripcion).ToList


        'UltimaCompra2 = (CType((Aggregate t1 In
        '                                                              (From d In HeliosData.documentocompradetalle
        '                                                               Where
        '                                                                   d.idItem = CStr(p.codigodetalle) And
        '                                                                   d.documentocompra.tipoCompra = "CMP"
        '                                                               Select New With {
        '                                                                   d.documentocompra
        '                                                                   }) Into Max(t1.documentocompra.fechaDoc)), DateTime?))

        'Dim consulta = (From p In HeliosData.detalleitems _
        '               Group Join clas In HeliosData.item _
        '               On p.idItem Equals clas.idItem _
        '               Into clas1 = Group _
        '               From cx In clas1.DefaultIfEmpty() _
        '               Group Join marca In HeliosData.item _
        '               On p.marcaRef Equals marca.idItem _
        '               Into marca1 = Group _
        '               From mx In marca1.DefaultIfEmpty() _
        '               Where p.idEmpresa = Gempresas.IdEmpresaRuc And _
        '               p.tipoExistencia = tipo _
        '               Select _
        '               codigo = p.codigodetalle,
        '               descripcion = p.descripcionItem,
        '               clasificaion = cx.descripcion,
        '               marca = mx.descripcion,
        '               gravado = p.origenProducto,
        '               tipoex = p.tipoExistencia,
        '               unidad = p.unidad1,
        '               codigobarra = p.codigo,
        '               presentacion = p.presentacion).OrderBy(Function(o) o.descripcion).ToList


        For Each i In consulta
            obj = New detalleitems

            If i.UltimaCompra IsNot Nothing Then
                obj.CustomDetalleCompra = New documentocompradetalle With
                {
                    .monto1 = i.UltimaCompra.d.monto1,
                    .destino = i.UltimaCompra.d.destino,
                    .importe = i.UltimaCompra.d.importe
                }
                obj.CustomDetalleCompra.documentocompra = New documentocompra With
                {
                .tipoCompra = i.UltimaCompra.comp.tipoCompra
                }
            End If

            If i.UltimaEntradaInicio IsNot Nothing Then
                obj.InventarioInicio = i.UltimaEntradaInicio
            End If

            obj.codigodetalle = i.codigo
            obj.descripcionItem = i.descripcion
            obj.NomClasificacion = i.clasificaion
            obj.NomMarca = i.marca
            obj.origenProducto = i.gravado
            obj.tipoExistencia = i.tipoex
            obj.unidad1 = i.unidad
            obj.unidad2 = i.marca
            obj.presentacion = i.presentacion
            obj.tipoExistencia = i.tipoex
            obj.codigo = i.codigobarra
            obj.precioCompra = i.preciocompra
            obj.precioMenor = i.precioMenor.GetValueOrDefault
            obj.precioMayor = i.PrecioMayor.GetValueOrDefault
            obj.precioGranMayor = i.PrecioGranMayor.GetValueOrDefault

            obj.precioMenorME = i.precioMenorME.GetValueOrDefault
            obj.precioMayorME = i.PrecioMayorME.GetValueOrDefault
            obj.precioGranMayorME = i.PrecioGranMayorME.GetValueOrDefault
            Lista.Add(obj)
        Next

        Return Lista
    End Function

    Public Function GetProductosGrupo(be As detalleitems) As List(Of detalleitems)
        Dim obj As New detalleitems
        Dim Lista As New List(Of detalleitems)
        Dim tipoCompras As New List(Of String)
        tipoCompras.Add(TIPO_COMPRA.COMPRA)
        tipoCompras.Add(TIPO_COMPRA.OTRAS_ENTRADAS)
        tipoCompras.Add(TIPO_COMPRA.NOTA_DE_COMPRA)

        Dim consulta = (From p In HeliosData.detalleitems
                        Join clas In HeliosData.item
                            On p.idItem Equals clas.idItem
                        Group Join marca In HeliosData.item
                            On p.unidad2 Equals marca.idItem
                            Into marca1 = Group
                        From mx In marca1.DefaultIfEmpty()
                        Where p.idEmpresa = be.idEmpresa And
                            p.idItem = be.idItem
                        Select
                            codigo = p.codigodetalle,
                            preciocompra = p.precioCompra,
                            descripcion = p.descripcionItem,
                            clasificaion = clas.descripcion,
                            marca = mx.descripcion,
                            gravado = p.origenProducto,
                            tipoex = p.tipoExistencia,
                            unidad = p.unidad1,
                            codigobarra = p.codigo,
                            presentacion = p.presentacion,
                            precioMenor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            precioMenorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                            PrecioMayor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            PrecioMayorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                            PrecioGranMayor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            PrecioGranMayorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = p.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
                                            And configuracionPrecioProductoes0.idproducto = p.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                            UltimaCompra = (
                            ((From
                                  d In HeliosData.documentocompradetalle
                              Join comp In HeliosData.documentocompra
                                      On comp.idDocumento Equals d.idDocumento
                              Where
                                  d.idItem = p.codigodetalle And
                                  d.documentocompra.fechaDoc =
                                  CType((Aggregate ss In HeliosData.documentocompradetalle
                                             Where
                                                 ss.idItem = p.codigodetalle And
                                                 tipoCompras.Contains(ss.documentocompra.tipoCompra)
                                                 Into Max(ss.documentocompra.fechaDoc)), DateTime?)
                              Select New With
                                  {
                                  d,
                                  comp
                                  }).FirstOrDefault())),
                            UltimaEntradaInicio = (
                            ((From
                                  d In HeliosData.documentoLibroDiarioDetalle
                              Where
                                  d.idItem = p.codigodetalle And
                                  d.documentoLibroDiario.tipoRegistro = "APT_EXT" And
                                  d.documentoLibroDiario.fecha = CType((Aggregate ss In HeliosData.documentoLibroDiarioDetalle
                                                                     Where ss.idItem = p.codigodetalle And
                                                                         ss.documentoLibroDiario.tipoRegistro = "APT_EXT"
                                                                         Into Max(ss.documentoLibroDiario.fecha)), DateTime?)
                              Select New With
                                  {
                                  d
                                  }).FirstOrDefault().d))
                            ).OrderBy(Function(o) o.descripcion).ToList



        For Each i In consulta
            obj = New detalleitems

            If i.UltimaCompra IsNot Nothing Then
                obj.CustomDetalleCompra = New documentocompradetalle With
                {
                    .monto1 = i.UltimaCompra.d.monto1,
                    .destino = i.UltimaCompra.d.destino,
                    .importe = i.UltimaCompra.d.importe
                }
                obj.CustomDetalleCompra.documentocompra = New documentocompra With
                {
                .tipoCompra = i.UltimaCompra.comp.tipoCompra
                }
            End If

            If i.UltimaEntradaInicio IsNot Nothing Then
                obj.InventarioInicio = i.UltimaEntradaInicio
            End If

            obj.codigodetalle = i.codigo
            obj.descripcionItem = i.descripcion
            obj.NomClasificacion = i.clasificaion
            obj.NomMarca = i.marca
            obj.origenProducto = i.gravado
            obj.tipoExistencia = i.tipoex
            obj.unidad1 = i.unidad
            obj.unidad2 = i.marca
            obj.presentacion = i.presentacion
            obj.tipoExistencia = i.tipoex
            obj.codigo = i.codigobarra
            obj.precioCompra = i.preciocompra
            obj.precioMenor = i.precioMenor.GetValueOrDefault
            obj.precioMayor = i.PrecioMayor.GetValueOrDefault
            obj.precioGranMayor = i.PrecioGranMayor.GetValueOrDefault

            obj.precioMenorME = i.precioMenorME.GetValueOrDefault
            obj.precioMayorME = i.PrecioMayorME.GetValueOrDefault
            obj.precioGranMayorME = i.PrecioGranMayorME.GetValueOrDefault
            Lista.Add(obj)
        Next

        Return Lista
    End Function

    Public Function GetProductosBusquedaPersonalizada(be As detalleitems, caso As String) As List(Of detalleitems)
        Dim obj As New detalleitems
        Dim Lista As New List(Of detalleitems)

        Select Case caso
            Case "MARCA"
                Lista = GetProductosMarca(be)
            Case "CLASIFICACION"
                Lista = GetProductosGrupo(be)
        End Select

        Return Lista
    End Function

    Public Function GetExistenciaByCodeBar(intCodigoBar As String) As detalleitems
        Return HeliosData.detalleitems.Where(Function(o) o.codigo = intCodigoBar).FirstOrDefault
    End Function

    Public Function GetUbicarProductoXcodigoBarra(ByVal idEmpresa As String, idEstablec As Integer, codigoBar As String) As detalleitems


        'Dim lista = (From n In HeliosData.detalleitems _
        '        Join i In HeliosData.item _
        '        On n.idItem Equals i.idItem _
        '                          Where n.idEmpresa = idEmpresa _
        '              And n.idEstablecimiento = idEstablec _
        '              And n.codigo = codigoBar).FirstOrDefault
        Dim lista = (From n In HeliosData.detalleitems
                     Where n.codigo = codigoBar And n.estado = "A").FirstOrDefault

        If Not IsNothing(lista) Then
            Dim ob As New detalleitems
            ob.idEmpresa = lista.idEmpresa
            ob.idEstablecimiento = lista.idEstablecimiento
            ob.codigodetalle = lista.codigodetalle
            ob.idItem = lista.idItem
            ob.cuenta = lista.cuenta
            ob.descripcionItem = lista.descripcionItem
            ob.presentacion = lista.presentacion
            ob.unidad1 = lista.unidad1
            ob.tipoExistencia = lista.tipoExistencia
            ob.origenProducto = lista.origenProducto
            ob.tipoProducto = lista.tipoProducto
            'ob.Utilidad = lista.i.utilidad
            'ob.UtilidadMayor = lista.i.utilidadmayor
            'ob.UtilidadGranMayor = lista.i.utilidadgranmayor
            ob.codigo = lista.codigo
            Return ob
        Else
            Return Nothing
        End If


        'listadoProductos.Add(n)

    End Function

    Public Function GetUbicarProductoIdHijo(ByVal idEmpresa As String, idEstablec As Integer, IdItem As Integer, tipo As String) As List(Of detalleitems)
        Dim listadoProductos As New List(Of detalleitems)
        Dim lista = (From n In HeliosData.detalleitems
                     Join i In HeliosData.item
                     On n.idItem Equals i.idItem
                     Where n.idEmpresa = idEmpresa _
         And n.idEstablecimiento = idEstablec _
         And n.idItem = IdItem _
         And n.tipoExistencia = tipo Order By n.descripcionItem).ToList

        For Each i In lista
            Dim n As New detalleitems
            n.idEmpresa = i.n.idEmpresa
            n.idEstablecimiento = i.n.idEstablecimiento
            n.codigodetalle = i.n.codigodetalle
            n.idItem = i.n.idItem
            n.cuenta = i.n.cuenta
            n.descripcionItem = i.n.descripcionItem
            n.presentacion = i.n.presentacion
            n.unidad1 = i.n.unidad1
            n.tipoExistencia = i.n.tipoExistencia
            n.origenProducto = i.n.origenProducto
            n.tipoProducto = i.n.tipoProducto
            n.Utilidad = i.i.utilidad
            n.UtilidadMayor = i.i.utilidadmayor
            n.UtilidadGranMayor = i.i.utilidadgranmayor
            n.codigo = i.n.codigo
            listadoProductos.Add(n)
        Next

        Return listadoProductos
    End Function

    Public Function Insert(ByVal ProductoBE As detalleitems) As detalleitems
        Using ts As New TransactionScope
            'Se inserta asiento
            HeliosData.detalleitems.Add(ProductoBE)
            HeliosData.SaveChanges()
            ts.Complete()
            ProductoBE = ProductoBE
            Return ProductoBE
        End Using
    End Function


    Public Function ReviewProductos(ProductoBE As detalleitems) As List(Of detalleitems)
        Dim com As List(Of detalleitems) = HeliosData.detalleitems.OrderBy(Function(o) o.descripcionItem) _
            .Where(Function(o) o.idEmpresa = ProductoBE.idEmpresa _
            And o.descripcionItem.Contains(ProductoBE.descripcionItem)).Take(15).ToList

        Return com
    End Function

    Public Function InsertNuevaItems(ByVal ProductoBE As detalleitems) As Integer
        Dim objDEtalle As New detalleitems
        Try
            Dim consulta As Integer = HeliosData.detalleitems.Where(Function(o) o.idItem = ProductoBE.idItem _
                                                                                And o.descripcionItem = ProductoBE.descripcionItem _
                                                                                And o.unidad1 = ProductoBE.unidad1 _
                                                                                And o.presentacion = ProductoBE.presentacion _
                                                                                And o.origenProducto = ProductoBE.origenProducto).Count

            If consulta > 0 Then
                Throw New Exception("El producto ya esta registrado, ingrese otro.")
            Else
                Using ts As New TransactionScope
                    '    objDEtalle = New detalleitems
                    With objDEtalle
                        .Action = Business.Entity.BaseBE.EntityAction.INSERT
                        .idEmpresa = ProductoBE.idEmpresa
                        .idEstablecimiento = ProductoBE.idEstablecimiento
                        .idItem = ProductoBE.idItem
                        .descripcionItem = ProductoBE.descripcionItem
                        .tipoExistencia = ProductoBE.tipoExistencia
                        .presentacion = ProductoBE.presentacion
                        .cuenta = ProductoBE.cuenta
                        .origenProducto = ProductoBE.origenProducto
                        .tipoProducto = ProductoBE.tipoProducto
                        .unidad1 = ProductoBE.unidad1
                        .marcaRef = ProductoBE.marcaRef
                        .estado = ProductoBE.estado
                        .fechaActualizacion = Date.Now
                    End With
                    HeliosData.detalleitems.Add(objDEtalle)
                    HeliosData.SaveChanges()
                    ts.Complete()
                End Using
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return objDEtalle.codigodetalle
    End Function

    Public Function InsertNuevaItems2(ByVal ProductoBE As detalleitems) As Integer
        Dim objDEtalle As New detalleitems
        Try
            Using ts As New TransactionScope
                '    objDEtalle = New detalleitems
                With objDEtalle
                    '.Action = Business.Entity.BaseBE.EntityAction.INSERT
                    .idEmpresa = ProductoBE.idEmpresa
                    .idEstablecimiento = ProductoBE.idEstablecimiento
                    .descripcionItem = ProductoBE.descripcionItem
                    .tipoExistencia = ProductoBE.tipoExistencia
                    .presentacion = ProductoBE.presentacion
                    .origenProducto = ProductoBE.origenProducto
                    .tipoProducto = ProductoBE.tipoProducto
                    .unidad1 = ProductoBE.unidad1
                    .unidad2 = ProductoBE.unidad2
                    .marcaRef = ProductoBE.marcaRef
                    .codigo = ProductoBE.codigo
                    .estado = ProductoBE.estado
                    .fechaActualizacion = Date.Now
                End With
                HeliosData.detalleitems.Add(objDEtalle)
                HeliosData.SaveChanges()
                ts.Complete()
                Return objDEtalle.codigodetalle
            End Using

        Catch ex As Exception
            Throw ex
        End Try

        Return objDEtalle.codigodetalle
    End Function

    Function GrabarSolo(ByVal ProductoBE As detalleitems) As Integer
        Dim objDEtalle As New detalleitems
        Dim objTotales As New totalesAlmacen
        Dim totalesAlmacen As New totalesAlmacenBL
        Dim preciosBL As New ConfiguracionPrecioProductoBL
        ' Dim varAlmacen As Integer
        Try
            If Not IsNothing(ProductoBE.codigo) Then
                If ProductoBE.codigo.Trim.Length > 0 Then
                    Dim validarCodigoBar As Integer = HeliosData.detalleitems.Where(Function(o) o.codigo = ProductoBE.codigo And
                                                                                        o.idEmpresa = ProductoBE.idEmpresa).Count

                    If validarCodigoBar > 0 Then
                        Throw New Exception("El producto ya esta registrado, ingrese otro.")
                    End If
                End If
            Else

            End If

            Dim consulta As Integer = HeliosData.detalleitems.Where(Function(o) _
                                                                            o.descripcionItem = ProductoBE.descripcionItem And
                                                                            o.unidad1 = ProductoBE.unidad1 And
                                                                            o.origenProducto = ProductoBE.origenProducto And
                                                                            o.idEmpresa = ProductoBE.idEmpresa).Count

            If consulta > 0 Then
                Throw New Exception("El producto ya esta registrado, ingrese otro.")
            End If

            Using ts As New TransactionScope
                '    objDEtalle = New detalleitems
                With objDEtalle
                    .Action = Business.Entity.BaseBE.EntityAction.INSERT
                    .idEmpresa = ProductoBE.idEmpresa
                    .idEstablecimiento = ProductoBE.idEstablecimiento
                    .idItem = ProductoBE.idItem
                    .descripcionItem = ProductoBE.descripcionItem
                    .tipoExistencia = ProductoBE.tipoExistencia
                    '   .presentacion = ProductoBE.presentacion
                    .cuenta = ProductoBE.cuenta
                    .origenProducto = ProductoBE.origenProducto
                    .tipoProducto = ProductoBE.tipoProducto
                    .unidad1 = ProductoBE.unidad1
                    .unidad2 = ProductoBE.unidad2
                    .marcaRef = ProductoBE.marcaRef
                    .estado = ProductoBE.estado
                    .codigo = ProductoBE.codigo
                    '.fechaLote = ProductoBE.fechaLote
                    .Retencion = ProductoBE.Retencion
                    .ValorRetencion = ProductoBE.ValorRetencion
                    .Percepcion = ProductoBE.Percepcion
                    .ValorPercepcion = ProductoBE.ValorPercepcion
                    .AfectoCompra = ProductoBE.AfectoCompra
                    .AfectoVenta = ProductoBE.AfectoVenta
                    .fechaActualizacion = Date.Now
                End With
                HeliosData.detalleitems.Add(objDEtalle)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using

        Catch ex As Exception
            Throw ex
        End Try
        Return objDEtalle.codigodetalle
    End Function

    Function GrabarSoloV2(ByVal ProductoBE As detalleitems) As Integer
        Dim objDEtalle As New detalleitems
        Dim objTotales As New totalesAlmacen
        Dim totalesAlmacen As New totalesAlmacenBL
        Dim preciosBL As New ConfiguracionPrecioProductoBL
        ' Dim varAlmacen As Integer
        Try
            If Not IsNothing(ProductoBE.codigo) Then
                If ProductoBE.codigo.Trim.Length > 0 Then
                    Dim validarCodigoBar As Integer = HeliosData.detalleitems.Where(Function(o) o.codigo = ProductoBE.codigo And
                                                                                        o.idEmpresa = ProductoBE.idEmpresa And o.estado = "A").Count
                    If validarCodigoBar > 0 Then
                        Throw New Exception("El codigo de Barra ya existe, ingrese otro.")
                    End If
                End If
            Else
            End If

            If Not IsNothing(ProductoBE.codigoInterno) Then
                If ProductoBE.codigoInterno.Trim.Length > 0 Then


                    Dim validarCodigoInterno As Integer = HeliosData.detalleitems.Where(Function(o) o.codigoInterno = ProductoBE.codigoInterno And
                                                                                        o.idEmpresa = ProductoBE.idEmpresa And o.estado = "A").Count

                    If validarCodigoInterno > 0 Then
                        Throw New Exception("El codigo interno ya existe, ingrese otro.")
                    End If
                End If
            Else
            End If


            Dim consulta As Integer = HeliosData.detalleitems.Where(Function(o) _
                                                                            o.descripcionItem = ProductoBE.descripcionItem And
                                                                            o.unidad1 = ProductoBE.unidad1 And
                                                                            o.origenProducto = ProductoBE.origenProducto And
                                                                            o.idEmpresa = ProductoBE.idEmpresa And o.estado = "A").Count

            If consulta > 0 Then
                Throw New Exception("El producto ya esta registrado, ingrese otro.")
            End If

            Using ts As New TransactionScope

                For Each i In ProductoBE.detalleitem_equivalencias.ToList
                    i.detalle = ProductoBE.unidad1
                Next

                HeliosData.detalleitems.Add(ProductoBE)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using

        Catch ex As Exception
            Throw ex
        End Try
        Return ProductoBE.codigodetalle
    End Function


    Public Function InsertItemDualTabla(ByVal ProductoBE As detalleitems) As Integer
        'Dim objDEtalle As New detalleitems
        'Dim objTotales As New totalesAlmacen
        'Dim totalesAlmacen As New totalesAlmacenBL
        Dim preciosBL As New ConfiguracionPrecioProductoBL
        Dim codigoProducto = 0
        ' Dim varAlmacen As Integer
        Try
            'If Not IsNothing(ProductoBE.codigo) Then
            '    If ProductoBE.codigo.Trim.Length > 0 Then
            '        Dim validarCodigoBar As Integer = HeliosData.detalleitems.Where(Function(o) o.codigo = ProductoBE.codigo).Count

            '        If validarCodigoBar > 0 Then
            '            Throw New Exception("El producto ya esta registrado, ingrese otro.")
            '        End If
            '    End If
            'Else

            'End If

            'Dim consulta As Integer = HeliosData.detalleitems.Where(Function(o) _
            '                                                                o.descripcionItem = ProductoBE.descripcionItem And
            '                                                                o.unidad1 = ProductoBE.unidad1 And
            '                                                                o.origenProducto = ProductoBE.origenProducto).Count

            'If consulta > 0 Then
            '    Throw New Exception("El producto ya esta registrado, ingrese otro.")
            'End If

            Using ts As New TransactionScope
                '    '    objDEtalle = New detalleitems
                '    With objDEtalle
                '        .Action = Business.Entity.BaseBE.EntityAction.INSERT
                '        .idEmpresa = ProductoBE.idEmpresa
                '        .idEstablecimiento = ProductoBE.idEstablecimiento
                '        .idItem = ProductoBE.idItem
                '        .descripcionItem = ProductoBE.descripcionItem
                '        .tipoExistencia = ProductoBE.tipoExistencia
                '        '   .presentacion = ProductoBE.presentacion
                '        .cuenta = ProductoBE.cuenta
                '        .origenProducto = ProductoBE.origenProducto
                '        .tipoProducto = ProductoBE.tipoProducto
                '        .unidad1 = ProductoBE.unidad1
                '        .unidad2 = ProductoBE.unidad2
                '        .marcaRef = ProductoBE.marcaRef
                '        .estado = ProductoBE.estado
                '        .codigo = ProductoBE.codigo
                '        '.fechaLote = ProductoBE.fechaLote
                '        .Retencion = ProductoBE.Retencion
                '        .ValorRetencion = ProductoBE.ValorRetencion
                '        .Percepcion = ProductoBE.Percepcion
                '        .ValorPercepcion = ProductoBE.ValorPercepcion
                '        .AfectoCompra = ProductoBE.AfectoCompra
                '        .AfectoVenta = ProductoBE.AfectoVenta
                '        .fechaActualizacion = Date.Now
                '    End With
                codigoProducto = GrabarSoloV2(ProductoBE)
                If ProductoBE.CustomPrecios IsNot Nothing Then
                    If ProductoBE.CustomPrecios.Count > 0 Then
                        preciosBL.GrabarListadoPrecios(ProductoBE.CustomPrecios, codigoProducto)
                    End If
                End If

                'eliosData.detalleitems.Add(objDEtalle)
                HeliosData.SaveChanges()
                ts.Complete()

                'objTotales = New totalesAlmacen
                'objTotales.idEmpresa = objDEtalle.idEmpresa
                'objTotales.idEstablecimiento = objDEtalle.idEstablecimiento
                'objTotales.idAlmacen = ProductoBE.idAlmacen '
                'objTotales.origenRecaudo = objDEtalle.origenProducto
                'objTotales.tipoCambio = TmpTipoCambio
                'objTotales.tipoExistencia = objDEtalle.tipoExistencia
                'objTotales.idItem = objDEtalle.codigodetalle
                'objTotales.descripcion = objDEtalle.descripcionItem
                'objTotales.idUnidad = objDEtalle.unidad1
                'objTotales.cantidad = 0
                'objTotales.precioUnitarioCompra = 0
                'objTotales.importeSoles = 0
                'objTotales.importeDolares = 0
                'objTotales.cantidadMinima = ProductoBE.cantMinima
                'objTotales.cantidadMaxima = ProductoBE.cantMax
                'objTotales.usuarioActualizacion = "Jiuni"
                'objTotales.fechaActualizacion = DateTime.Now
                'totalesAlmacen.Insert(objTotales)
            End Using


        Catch ex As Exception
            Throw ex
        End Try

        Return codigoProducto 'objDEtalle.codigodetalle
    End Function

    Public Function InsertItemDualTablaV2(ByVal ProductoBE As detalleitems) As Integer
        Dim objDEtalle As New detalleitems
        Dim objTotales As New totalesAlmacen
        Dim totalesAlmacen As New totalesAlmacenBL
        ' Dim varAlmacen As Integer
        Try



            'If Not IsNothing(ProductoBE.codigo) Then
            '    Dim consulta As Integer = HeliosData.detalleitems.Where(Function(o) o.codigo = ProductoBE.codigo).Count

            '    If consulta > 0 Then
            '        Throw New Exception("El producto ya esta registrado, ingrese otro.")
            '    End If


            'Else
            '    Dim consulta As Integer = HeliosData.detalleitems.Where(Function(o) o.idItem = ProductoBE.idItem _
            '                                                                        And o.descripcionItem = ProductoBE.descripcionItem _
            '                                                                        And o.unidad1 = ProductoBE.unidad1 _
            '                                                                        And o.presentacion = ProductoBE.presentacion _
            '                                                                        And o.origenProducto = ProductoBE.origenProducto).Count

            '    If consulta > 0 Then
            '        Throw New Exception("El producto ya esta registrado, ingrese otro.")
            '    End If
            'End If

            'Dim consulta As Integer = HeliosData.detalleitems.Where(Function(o) o.descripcionItem = ProductoBE.descripcionItem And o.tipoExistencia).Count

            Using ts As New TransactionScope
                '    objDEtalle = New detalleitems
                With objDEtalle
                    .Action = Business.Entity.BaseBE.EntityAction.INSERT
                    .idEmpresa = ProductoBE.idEmpresa
                    .idEstablecimiento = ProductoBE.idEstablecimiento
                    .idItem = ProductoBE.idItem
                    .descripcionItem = ProductoBE.descripcionItem
                    .tipoExistencia = ProductoBE.tipoExistencia
                    ' .presentacion = ProductoBE.presentacion
                    .cuenta = ProductoBE.cuenta
                    .origenProducto = ProductoBE.origenProducto
                    .tipoProducto = ProductoBE.tipoProducto
                    .unidad1 = ProductoBE.unidad1
                    .marcaRef = ProductoBE.marcaRef
                    .estado = ProductoBE.estado
                    .codigo = ProductoBE.codigo
                    .fechaActualizacion = Date.Now
                End With
                HeliosData.detalleitems.Add(objDEtalle)
                HeliosData.SaveChanges()
                ts.Complete()

                objTotales = New totalesAlmacen
                objTotales.idEmpresa = objDEtalle.idEmpresa
                objTotales.idEstablecimiento = objDEtalle.idEstablecimiento
                objTotales.idAlmacen = ProductoBE.idAlmacen '
                objTotales.origenRecaudo = objDEtalle.origenProducto
                objTotales.tipoCambio = TmpTipoCambio
                objTotales.tipoExistencia = objDEtalle.tipoExistencia
                objTotales.idItem = objDEtalle.codigodetalle
                objTotales.descripcion = objDEtalle.descripcionItem
                objTotales.idUnidad = objDEtalle.unidad1
                objTotales.cantidad = ProductoBE.CantidadKardex
                objTotales.precioUnitarioCompra = 0
                objTotales.importeSoles = ProductoBE.ImporteKardex
                objTotales.importeDolares = 0
                objTotales.cantidadMinima = ProductoBE.cantMinima
                objTotales.cantidadMaxima = ProductoBE.cantMax
                objTotales.usuarioActualizacion = "Jiuni"
                objTotales.status = StatusArticulo.Activo
                objTotales.fechaActualizacion = DateTime.Now
                totalesAlmacen.Insert(objTotales)
            End Using


        Catch ex As Exception
            Throw ex
        End Try

        Return objDEtalle.codigodetalle
    End Function


    Public Sub ListadoItemsDeInicio(ByVal list As List(Of detalleitems), documentoBE As documento)
        Dim t As New totalesAlmacen
        Dim inv As New InventarioMovimiento
        Dim objDEtalle As New detalleitems
        Dim documentoBL As New documentoBL
        Dim documentoLibroBL As New documentoLibroDiarioBL
        Dim objTotales As New totalesAlmacen
        Dim totalesAlmacen As New totalesAlmacenBL
        Dim cierreBL As New cierreinventarioBL
        ' Dim varAlmacen As Integer
        Dim precioBL As New ConfiguracionPrecioProductoBL
        Dim docDetalle As New documentoLibroDiarioDetalle
        Dim codigoProducto As Integer
        Dim loteBL As New recursoCostoLoteBL
        Try
            Using ts As New TransactionScope
                documentoBL.Insert(documentoBE)
                documentoLibroBL.InsertCabecera(documentoBE.documentoLibroDiario, documentoBE.idDocumento)

                For Each i In list

                    Dim articuloExistente = HeliosData.detalleitems.Where(Function(o) o.codigo = i.codigo).FirstOrDefault
                    If Not IsNothing(articuloExistente) Then
                        codigoProducto = articuloExistente.codigodetalle
                    Else
                        codigoProducto = Me.InsertNuevaItems2(i)
                    End If

                    docDetalle = New documentoLibroDiarioDetalle With {
                        .idDocumento = documentoBE.idDocumento,
                        .cuenta = "N",
                        .idItem = codigoProducto,
                        .descripcion = i.descripcionItem,
                        .tipoAsiento = "N",
                        .importeMN = i.CustomTotalAlmacen.importeSoles,
                        .importeME = i.CustomTotalAlmacen.importeDolares,
                        .usuarioActualizacion = i.usuarioActualizacion,
                    .fechaActualizacion = i.fechaActualizacion
                        }
                    HeliosData.documentoLibroDiarioDetalle.Add(docDetalle)

                    '---------------------------------------------------------------------------------------------
                    Dim codigoLote = loteBL.GrabarLotesOne(i.customLote)

                    If IsNothing(articuloExistente) Then
                        objTotales = New totalesAlmacen
                        objTotales.idEmpresa = i.CustomTotalAlmacen.idEmpresa
                        objTotales.codigoLote = codigoLote
                        objTotales.idEstablecimiento = i.CustomTotalAlmacen.idEstablecimiento
                        objTotales.idAlmacen = i.CustomTotalAlmacen.idAlmacen '
                        objTotales.origenRecaudo = i.CustomTotalAlmacen.origenRecaudo
                        objTotales.tipoCambio = TmpTipoCambio
                        objTotales.tipoExistencia = i.CustomTotalAlmacen.tipoExistencia
                        objTotales.idItem = codigoProducto
                        objTotales.descripcion = i.CustomTotalAlmacen.descripcion
                        objTotales.idUnidad = i.CustomTotalAlmacen.idUnidad
                        objTotales.unidadMedida = i.CustomTotalAlmacen.idUnidad
                        objTotales.cantidad = i.CustomTotalAlmacen.cantidad
                        objTotales.precioUnitarioCompra = 0
                        objTotales.importeSoles = i.CustomTotalAlmacen.importeSoles
                        objTotales.importeDolares = i.CustomTotalAlmacen.importeDolares
                        objTotales.cantidadMinima = i.CustomTotalAlmacen.cantidadMinima
                        objTotales.cantidadMaxima = i.CustomTotalAlmacen.cantidadMaxima
                        objTotales.status = StatusArticulo.Activo
                        objTotales.usuarioActualizacion = i.usuarioActualizacion
                        objTotales.fechaActualizacion = DateTime.Now
                        HeliosData.totalesAlmacen.Add(objTotales)

                    Else
                        t = New totalesAlmacen
                        t.idEmpresa = i.CustomTotalAlmacen.idEmpresa
                        t.idEstablecimiento = i.CustomTotalAlmacen.idEstablecimiento
                        t.tipoExistencia = i.CustomTotalAlmacen.tipoExistencia
                        t.descripcion = i.CustomTotalAlmacen.descripcion
                        ' t.descripcion = i.DetalleItem
                        t.idUnidad = i.CustomTotalAlmacen.idUnidad
                        t.unidadMedida = i.CustomTotalAlmacen.idUnidad
                        t.idAlmacen = i.CustomTotalAlmacen.idAlmacen '
                        t.origenRecaudo = i.CustomTotalAlmacen.origenRecaudo
                        t.idItem = codigoProducto
                        t.cantidad = i.CustomTotalAlmacen.cantidad
                        t.precioUnitarioCompra = 0
                        t.importeSoles = i.CustomTotalAlmacen.importeSoles
                        t.importeDolares = i.CustomTotalAlmacen.importeDolares
                        t.usuarioActualizacion = i.usuarioActualizacion
                        t.fechaActualizacion = DateTime.Now
                        totalesAlmacen.UpdateStockOtrasEntradas(t)
                    End If


                    '----------------------------InventarioMovimiento ------------------------------------------------------
                    inv = New InventarioMovimiento With
                          {
                              .idEmpresa = Gempresas.IdEmpresaRuc,
                              .idEstablecimiento = GEstableciento.IdEstablecimiento,
                              .idAlmacen = i.CustomTotalAlmacen.idAlmacen,
                              .nrolote = codigoLote,
                              .tipoOperacion = StatusTipoOperacion.SALDO_INICIAL_O_CIERRES,
                              .tipoDocAlmacen = "9901",
                              .serie = documentoBE.documentoLibroDiario.serie,
                              .numero = documentoBE.documentoLibroDiario.nroDoc,
                              .idDocumento = documentoBE.idDocumento,
                              .idDocumentoRef = documentoBE.idDocumento,
                              .descripcion = i.descripcionItem,
                              .fecha = documentoBE.fechaProceso,
                              .tipoRegistro = "E",
                              .destinoGravadoItem = i.origenProducto,
                              .tipoProducto = i.tipoExistencia,
                              .idItem = codigoProducto,
                              .presentacion = i.presentacion,
                              .cantidad = i.CustomTotalAlmacen.cantidad,
                              .unidad = i.unidad1,
                              .cantidad2 = 0,
                              .unidad2 = i.presentacion,
                              .precUnite = 0,
                              .precUniteUSD = 0,
                              .monto = i.CustomTotalAlmacen.importeSoles,
                              .montoUSD = i.CustomTotalAlmacen.importeDolares,
                              .status = "D",
                              .entragado = "SI",
                              .usuarioActualizacion = i.usuarioActualizacion,
                              .fechaActualizacion = i.fechaActualizacion
                          }
                    HeliosData.InventarioMovimiento.Add(inv)

                    '----------------------------------------------------------------------------------------------
                    If documentoBE.IsInicio = True Then
                        'i.CustomCierreInventario.idItem = codigoProducto
                        'cierreBL.InsertCierre(i.CustomCierreInventario)
                    End If

                    precioBL.GrabarPrecioApertura(i.CustomPrecios, codigoProducto)

                Next
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function GetUbicarDetalleItems(ByVal idEmpresa As String, idEstablec As Integer, Nombre As String) As Integer
        'Dim objDetalle As New detalleitems
        Dim codigodDetalle As Integer = 0

        Dim RecursoBE = (From n In HeliosData.detalleitems
                         Where n.idEmpresa = idEmpresa _
                         And n.idEstablecimiento = idEstablec _
                         And n.descripcionItem = Nombre).FirstOrDefault

        If (Not IsNothing(RecursoBE)) Then
            Return RecursoBE.codigodetalle
        Else
            Return codigodDetalle
        End If


        'End Using
    End Function

    Public Function GetUbicarDetalleItemTipoExistencia(ByVal idEmpresa As String, idEstablec As Integer, intIdCategoria As Integer, strTipoExistencia As String) As List(Of detalleitems)
        Return (From n In HeliosData.detalleitems
                Where n.idEmpresa = idEmpresa _
                And n.idEstablecimiento = idEstablec _
                And n.idItem = intIdCategoria _
                And n.tipoExistencia = strTipoExistencia Order By n.descripcionItem).ToList

    End Function

    Public Function GetUbicarProductoXdescripcion(ByVal idEmpresa As String, idEstablec As Integer, intIdCategoria As Integer, strTipoExistencia As String, strBusqueda As String) As List(Of detalleitems)
        Return (From n In HeliosData.detalleitems
                Where n.idEmpresa = idEmpresa _
                And n.idEstablecimiento = idEstablec _
                And n.tipoExistencia = strTipoExistencia _
                And n.descripcionItem.StartsWith(strBusqueda) Take 10).ToList

    End Function


    Public Function GetUbicarProductoXdescripcion2(ByVal idEmpresa As String, idEstablec As Integer, intIdCategoria As Integer, strTipoExistencia As String, strBusqueda As String) As List(Of detalleitems)
        Dim listadoProductos As New List(Of detalleitems)
        'n.idEmpresa = idEmpresa _
        'n.idEstablecimiento = idEstablec _

        Dim lista = (From n In HeliosData.detalleitems
                     Group Join marca In HeliosData.item On marca.idItem Equals n.unidad2
                         Into marca_join = Group
                     From marca In marca_join.DefaultIfEmpty()
                     Where n.tipoExistencia = strTipoExistencia _
                      And n.descripcionItem.Trim.StartsWith(strBusqueda) Take 50 Order By n.descripcionItem).ToList

        For Each i In lista
            Dim n As New detalleitems
            If i.marca IsNot Nothing Then
                n.NomMarca = i.marca.descripcion
            Else
                n.NomMarca = "Sin definir"
            End If
            n.estado = i.n.estado
            n.idEmpresa = i.n.idEmpresa
            n.idEstablecimiento = i.n.idEstablecimiento
            n.codigodetalle = i.n.codigodetalle
            n.idItem = i.n.idItem
            n.cuenta = i.n.cuenta
            n.descripcionItem = i.n.descripcionItem
            n.presentacion = i.n.presentacion
            n.unidad1 = i.n.unidad1
            n.tipoExistencia = i.n.tipoExistencia
            n.origenProducto = i.n.origenProducto
            n.tipoProducto = i.n.tipoProducto
            n.codigo = i.n.codigo
            listadoProductos.Add(n)
        Next

        Return listadoProductos
    End Function


    Public Function GetItemsByDescripcion(be As detalleitems) As List(Of detalleitems)
        Dim listadoProductos As New List(Of detalleitems)
        'n.idEmpresa = idEmpresa _
        'n.idEstablecimiento = idEstablec _
        Dim lista = (From n In HeliosData.detalleitems
                     Group Join marca In HeliosData.item On marca.idItem Equals n.unidad2
                         Into marca_join = Group
                     From marca In marca_join.DefaultIfEmpty()
                     Where n.descripcionItem.Contains(be.descripcionItem) Order By n.descripcionItem).ToList

        For Each i In lista
            Dim n As New detalleitems

            If i.marca IsNot Nothing Then
                n.NomMarca = i.marca.descripcion
            Else
                n.NomMarca = "Sin definir"
            End If
            n.estado = i.n.estado
            n.idEmpresa = i.n.idEmpresa
            n.idEstablecimiento = i.n.idEstablecimiento
            n.codigodetalle = i.n.codigodetalle
            n.idItem = i.n.idItem
            n.cuenta = i.n.cuenta
            n.descripcionItem = i.n.descripcionItem
            n.presentacion = i.n.presentacion
            n.unidad1 = i.n.unidad1
            n.tipoExistencia = i.n.tipoExistencia
            n.origenProducto = i.n.origenProducto
            n.tipoProducto = i.n.tipoProducto
            n.codigo = i.n.codigo
            listadoProductos.Add(n)
        Next

        Return listadoProductos
    End Function

    Public Function GetProductsSistemaByEmpresa(be As detalleitems) As List(Of usp_GetProductsSistema_Result)
        Dim listadoProductos As New List(Of detalleitems)
        Return HeliosData.usp_GetProductsSistema(be.descripcionItem, be.idEmpresa).ToList
    End Function

    Public Function InsertActaConstitucion(ByVal actividadBE As detalleitems) As Integer
        Using ts As New TransactionScope
            HeliosData.detalleitems.Add(actividadBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return actividadBE.codigodetalle
        End Using
    End Function

    Public Sub InsertLista(ByVal ProductoListaBE As List(Of detalleitems))
        Using ts As New TransactionScope
            'Se inserta asiento
            'For Each i In ProductoListaBE
            'If IsNothing(GetUbicaProductoNombre(i.descripcionItem, i.idEmpresa, i.idEstablecimiento)) Then
            '  HeliosData.detalleitems.Add(i)
            DetalleItemsSaveList(ProductoListaBE)
            'Else

            'End If
            'Next
            HeliosData.SaveChanges()
            ts.Complete()
            ProductoListaBE = ProductoListaBE
        End Using
    End Sub

    Private Sub DetalleItemsSaveList(ProductoListaBE As List(Of detalleitems))
        Using ts As New TransactionScope
            HeliosData.detalleitems.AddRange(ProductoListaBE)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Update(ByVal ProductoBE As detalleitems)
        Dim objDEtalle As New detalleitems
        Dim totales As New totalesAlmacenBL
        Dim lista As New List(Of Integer)
        lista.Add(ProductoBE.codigodetalle)

        Using ts As New TransactionScope

            'Se actualiza asiento
            objDEtalle = HeliosData.detalleitems.Where(Function(O) O.codigodetalle = ProductoBE.codigodetalle).First


            If Not IsNothing(ProductoBE.codigoInterno) Then
                If ProductoBE.codigoInterno.Trim.Length > 0 Then


                    Dim validarCodigoInterno As Integer = HeliosData.detalleitems.Where(Function(o) o.codigoInterno = ProductoBE.codigoInterno And
                                                                                        o.idEmpresa = ProductoBE.idEmpresa And o.estado = "A" And Not o.idItem = ProductoBE.idItem).Count

                    If validarCodigoInterno > 0 Then
                        Throw New Exception("El codigo interno ya existe, ingrese otro.")
                    End If
                End If
            Else
            End If


            If Not IsNothing(ProductoBE.codigo) Then
                If ProductoBE.codigo.Trim.Length > 0 Then
                    Dim validarCodigoBar As Integer =
                        HeliosData.detalleitems.Where(Function(o) _
                                                          o.codigo <> objDEtalle.codigo And
                                                          o.codigo = ProductoBE.codigo).Count

                    If validarCodigoBar > 0 Then
                        Throw New Exception("El codigo de barra ingresado, ya esta siendo usado por otro producto, ingrese otro.")
                    End If
                End If
            End If

            Dim consulta As Integer = HeliosData.detalleitems.Where(Function(o) _
                                  o.descripcionItem <> objDEtalle.descripcionItem And
                                  o.unidad1 <> objDEtalle.unidad1 And
                                  o.origenProducto <> objDEtalle.origenProducto And
                                  o.descripcionItem = ProductoBE.descripcionItem And
                                  o.unidad1 = ProductoBE.unidad1 And
                                  o.origenProducto = ProductoBE.origenProducto).Count

            If consulta > 0 Then
                Throw New Exception("El producto ya esta registrado, ingrese otro.")
            End If

            Dim unidades = HeliosData.detalleitem_equivalencias.Where(Function(o) o.codigodetalle = ProductoBE.codigodetalle).ToList

            For Each i In unidades
                i.detalle = ProductoBE.unidad1
            Next

            'unidades.detalle = ProductoBE.unidad1

            With objDEtalle
                .fotoUrl = ProductoBE.fotoUrl
                .idItem = ProductoBE.idItem
                .descripcionItem = ProductoBE.descripcionItem
                .marcaRef = ProductoBE.marcaRef
                .tipoExistencia = ProductoBE.tipoExistencia
                .composicion = ProductoBE.composicion
                .productoRestringido = ProductoBE.productoRestringido
                .presentacion = ProductoBE.presentacion
                '  .presentacion = ProductoBE.presentacion
                .cuenta = ProductoBE.cuenta
                .origenProducto = ProductoBE.origenProducto
                .tipoProducto = ProductoBE.tipoProducto
                .unidad1 = ProductoBE.unidad1
                .unidad2 = ProductoBE.unidad2
                .codigo = ProductoBE.codigo
                .codigoInterno = ProductoBE.codigoInterno
                .talla = ProductoBE.talla
                .color = ProductoBE.color
                .Peso = ProductoBE.Peso
                .unidad2 = ProductoBE.unidad2
                .idClasificacion = ProductoBE.idClasificacion
                .idCaracteristica = ProductoBE.idCaracteristica
                .electricidad = ProductoBE.electricidad
                .transmision = ProductoBE.transmision
                .AfectoStock = ProductoBE.AfectoStock
                .cantidadMinima = ProductoBE.cantidadMinima
                .cantidadMaxima = ProductoBE.cantidadMaxima
                .fechaActualizacion = Date.Now
                .tipoOtroImpuesto = ProductoBE.tipoOtroImpuesto
                .otroImpuesto = ProductoBE.otroImpuesto
            End With

            'Dim objT = HeliosData.totalesAlmacen.Where(Function(o) o.idItem = ProductoBE.codigodetalle).FirstOrDefault

            'If Not IsNothing(objT) Then
            '    objT.descripcion = ProductoBE.descripcionItem
            '    objT.tipoExistencia = ProductoBE.tipoExistencia
            '    objT.idUnidad = ProductoBE.unidad1
            '    objT.origenRecaudo = ProductoBE.origenProducto
            'End If

            'totales.UpdateTipoCant(ProductoBE)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub DeleteProductoAllReferences(ByVal ProductoBE As detalleitems)
        Try
            Using ts As New TransactionScope
                Dim conInventario As Integer = HeliosData.InventarioMovimiento.Where(Function(o) o.idItem = ProductoBE.codigodetalle And o.idEmpresa = ProductoBE.idEmpresa And o.idEstablecimiento = ProductoBE.idEstablecimiento).Count
                If conInventario > 0 Then
                    Throw New Exception("El producto se encuentra en el inventario no puede eliminarse.")
                Else
                    Dim tbldetalleItem As detalleitems = HeliosData.detalleitems.Where(Function(o) o.codigodetalle = ProductoBE.codigodetalle).FirstOrDefault
                    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(tbldetalleItem)

                    Dim tbltotales As List(Of totalesAlmacen) = HeliosData.totalesAlmacen.Where(Function(o) o.idItem = ProductoBE.codigodetalle).ToList
                    For Each i In tbltotales
                        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(i)
                    Next

                    Dim tblListadoPrecios As List(Of listadoPrecios) = HeliosData.listadoPrecios.Where(Function(o) o.idItem = ProductoBE.codigodetalle).ToList
                    For Each i In tblListadoPrecios
                        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(i)
                    Next
                End If
                HeliosData.SaveChanges()
                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Delete(ByVal ProductoBE As detalleitems)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(ProductoBE)
    End Sub

    Public Function GetExistenciasByEstablecimiento(intEstable As Integer) As List(Of detalleitems)
        '    Dim con = HeliosData.detalleitems.Include("item").Where(Function(o) o.idEstablecimiento = intEstable).ToList
        Dim obj As detalleitems
        Dim con = (From a In HeliosData.detalleitems
                   Group Join cat In HeliosData.item
                       On cat.idItem Equals a.idItem
                       Into ov = Group
                   From x In ov.DefaultIfEmpty()
                   Group Join marca In HeliosData.item
                       On a.unidad2 Equals marca.idItem
                       Into marca = Group
                   From marca_empty In marca.DefaultIfEmpty()
                   Where a.idEstablecimiento = intEstable And a.estado <> "D").ToList


        'Dim con = HeliosData.detalleitems _
        '    .Include(Function(o) o.item) _
        '    .Where(Function(o) o.idEstablecimiento = intEstable).ToList

        GetExistenciasByEstablecimiento = New List(Of detalleitems)
        'For Each i In con
        '    obj = New detalleitems
        '    If i.item IsNot Nothing Then
        '        obj.item = New item With
        '        {
        '        .idItem = i.item.idItem,
        '        .descripcion = i.item.descripcion
        '        }

        '    End If
        '    obj.codigodetalle = i.a.codigodetalle
        '    obj.codigo = i.a.codigo
        '    obj.descripcionItem = i.a.descripcionItem
        '    obj.unidad1 = i.a.unidad1
        '    obj.tipoExistencia = i.a.tipoExistencia
        '    obj.origenProducto = i.a.origenProducto
        '    obj.estado = i.a.estado
        '    GetExistenciasByEstablecimiento.Add(obj)
        'Next

        'For Each i In con
        '    obj = New detalleitems
        '    If i.item IsNot Nothing Then
        '        obj.item = New item With
        '        {
        '        .idItem = i.item.idItem,
        '        .descripcion = i.item.descripcion
        '        }

        '    End If
        '    obj.codigodetalle = i.codigodetalle
        '    obj.codigo = i.codigo
        '    obj.descripcionItem = i.descripcionItem
        '    obj.unidad1 = i.unidad1
        '    obj.tipoExistencia = i.tipoExistencia
        '    obj.origenProducto = i.origenProducto
        '    obj.estado = i.estado
        '    GetExistenciasByEstablecimiento.Add(obj)
        'Next

        For Each i In con
            obj = New detalleitems
            If i.x IsNot Nothing Then
                obj.item = New item With
                {
                .idItem = i.x.idItem,
                .descripcion = i.x.descripcion
                }

            End If

            If i.marca_empty IsNot Nothing Then
                obj.customMarca = New item With
                {
                .idItem = i.marca_empty.idItem,
                .descripcion = i.marca_empty.descripcion
                }
            End If

            obj.codigodetalle = i.a.codigodetalle
            obj.codigo = i.a.codigo
            obj.descripcionItem = i.a.descripcionItem
            obj.unidad1 = i.a.unidad1
            obj.tipoExistencia = i.a.tipoExistencia
            obj.origenProducto = i.a.origenProducto
            obj.estado = i.a.estado
            GetExistenciasByEstablecimiento.Add(obj)
        Next

        'fsddfd
        'Return (From a In HeliosData.detalleitems Where a.idEstablecimiento = intEstable).ToList
    End Function

    Public Function GetArticulosSytem(empresa As String, search As String) As List(Of detalleitems)
        '    Dim con = HeliosData.detalleitems.Include("item").Where(Function(o) o.idEstablecimiento = intEstable).ToList
        Dim obj As detalleitems
        Dim lista As New List(Of detalleitems)
        Dim con = HeliosData.usp_GetProductsSistema(search, empresa).ToList


        'Dim con = HeliosData.detalleitems _
        '    .Include(Function(o) o.item) _
        '    .Where(Function(o) o.idEstablecimiento = intEstable).ToList

        '  GetExistenciasByEstablecimiento = New List(Of detalleitems)
        'For Each i In con
        '    obj = New detalleitems
        '    If i.item IsNot Nothing Then
        '        obj.item = New item With
        '        {
        '        .idItem = i.item.idItem,
        '        .descripcion = i.item.descripcion
        '        }

        '    End If
        '    obj.codigodetalle = i.a.codigodetalle
        '    obj.codigo = i.a.codigo
        '    obj.descripcionItem = i.a.descripcionItem
        '    obj.unidad1 = i.a.unidad1
        '    obj.tipoExistencia = i.a.tipoExistencia
        '    obj.origenProducto = i.a.origenProducto
        '    obj.estado = i.a.estado
        '    GetExistenciasByEstablecimiento.Add(obj)
        'Next

        'For Each i In con
        '    obj = New detalleitems
        '    If i.item IsNot Nothing Then
        '        obj.item = New item With
        '        {
        '        .idItem = i.item.idItem,
        '        .descripcion = i.item.descripcion
        '        }

        '    End If
        '    obj.codigodetalle = i.codigodetalle
        '    obj.codigo = i.codigo
        '    obj.descripcionItem = i.descripcionItem
        '    obj.unidad1 = i.unidad1
        '    obj.tipoExistencia = i.tipoExistencia
        '    obj.origenProducto = i.origenProducto
        '    obj.estado = i.estado
        '    GetExistenciasByEstablecimiento.Add(obj)
        'Next

        For Each i In con
            obj = New detalleitems
            obj.NomClasificacion = i.NameGrupo
            obj.NomMarca = i.descripcion
            obj.codigodetalle = i.codigodetalle
            obj.codigo = i.codigo
            obj.descripcionItem = i.descripcionItem
            obj.unidad1 = i.unidad1
            obj.tipoExistencia = i.tipoExistencia
            obj.origenProducto = i.origenProducto
            obj.estado = i.estado
            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Function GetExistenciasByEstablecimientoEspecial(intEstable As Integer) As List(Of detalleitems)
        '    Dim con = HeliosData.detalleitems.Include("item").Where(Function(o) o.idEstablecimiento = intEstable).ToList
        Dim obj As detalleitems

        Dim con = HeliosData.detalleitems.Include(Function(o) o.item).Where(Function(o) o.idEstablecimiento = intEstable And o.tipoProducto = "E").ToList
        GetExistenciasByEstablecimientoEspecial = New List(Of detalleitems)


        For Each i In con
            obj = New detalleitems
            If i.item IsNot Nothing Then
                obj.item = New item With
                {
                .idItem = i.item.idItem,
                .descripcion = i.item.descripcion
                }

            End If
            obj.codigodetalle = i.codigodetalle
            obj.codigo = i.codigo
            obj.descripcionItem = i.descripcionItem
            obj.unidad1 = i.unidad1
            obj.tipoExistencia = i.tipoExistencia
            obj.origenProducto = i.origenProducto
            obj.estado = i.estado
            GetExistenciasByEstablecimientoEspecial.Add(obj)
        Next

    End Function


    Function GetListaProductoClasificado(intEstable As Integer, intClasificacion As Integer) As List(Of detalleitems)
        Return (From a In HeliosData.detalleitems Where a.idEstablecimiento = intEstable And
                a.idItem = intClasificacion Select a).ToList
    End Function

    Function GetUbicaProductoID(intIdProducto As Integer) As detalleitems
        'Dim consulta As New detalleitems

        'Dim i = HeliosData.detalleitems.Include(Function(o) o.detalleitem_equivalencias.Select(Function(y) y.detalleitemequivalencia_precios)).Where(Function(d) d.codigodetalle = intIdProducto).SingleOrDefault

        Dim i = HeliosData.detalleitems.Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))).Include(Function(x) x.detalleitems_conexo).Where(Function(d) d.codigodetalle = intIdProducto).SingleOrDefault

        'consulta = HeliosData.detalleitems _
        '            .Include(Function(o) o.detalleitem_equivalencias) _
        '            .Include(Function(o) o.detalleitem_precios) _
        '            .Where(Function(a) a.codigodetalle = intIdProducto).SingleOrDefault

        Dim obj As detalleitems = Nothing
        Dim obEquivalencia As detalleitem_equivalencias
        Dim ListEquivalencia As List(Of detalleitem_equivalencias)
        Dim Listdetalleitems_conexo As List(Of detalleitems_conexo)
        Dim ListEquivalenciaPrecios As List(Of detalleitemequivalencia_precios)
        Dim ListaCatalogoPrecios As List(Of detalleitemequivalencia_catalogos)

        GetUbicaProductoID = New detalleitems

        If i IsNot Nothing Then
            Listdetalleitems_conexo = New List(Of detalleitems_conexo)
            For Each cx In i.detalleitems_conexo
                Listdetalleitems_conexo.Add(New detalleitems_conexo With
                                            {
                                            .conexo_id = cx.conexo_id,
                                            .codigodetalle = cx.codigodetalle,
                                            .detalle = cx.detalle,
                                            .cantidad = cx.cantidad,
                                            .equivalencia_id = cx.equivalencia_id,
                                            .unidadComercial = cx.unidadComercial,
                                            .fraccion = cx.fraccion,
                                            .estado = cx.estado,
                                            .vigencia = cx.vigencia
                                            })
            Next

            ListEquivalencia = New List(Of detalleitem_equivalencias)
            For Each eq In i.detalleitem_equivalencias
                obEquivalencia = New detalleitem_equivalencias
                obEquivalencia.codigodetalle = i.codigodetalle
                obEquivalencia.detalle = eq.detalle
                obEquivalencia.unidadComercial = eq.unidadComercial
                obEquivalencia.contenido = eq.contenido
                obEquivalencia.equivalencia_id = eq.equivalencia_id
                obEquivalencia.fraccionUnidad = eq.fraccionUnidad
                obEquivalencia.estado = eq.estado
                obEquivalencia.flag = eq.flag
                obEquivalencia.contenido_neto = eq.contenido_neto


                ListaCatalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
                For Each cat In eq.detalleitemequivalencia_catalogos
                    ListEquivalenciaPrecios = New List(Of detalleitemequivalencia_precios)
                    For Each prec In cat.detalleitemequivalencia_precios
                        ListEquivalenciaPrecios.Add(New detalleitemequivalencia_precios With
                                                    {
                                                    .idCatalogo = cat.idCatalogo,
                                                    .rango_inicio = prec.rango_inicio,
                                                    .rango_final = prec.rango_final,
                                                    .precioCredito = prec.precioCredito,
                                                    .precioCreditoUSD = prec.precioCreditoUSD,
                                                    .precio = prec.precio,
                                                    .precioUSD = prec.precioUSD,
                                                    .precio_id = prec.precio_id,
                                                    .precioCode = prec.precioCode,
                                                    .estado = prec.estado
                                                    })
                    Next


                    ListaCatalogoPrecios.Add(New detalleitemequivalencia_catalogos With {
                                             .idCatalogo = cat.idCatalogo,
                                             .codigodetalle = cat.codigodetalle,
                                             .equivalencia_id = cat.equivalencia_id,
                                             .nombre_corto = cat.nombre_corto,
                                             .nombre_largo = cat.nombre_largo,
                                             .estado = cat.estado,
                                             .predeterminado = cat.predeterminado,
                                             .detalleitemequivalencia_precios = ListEquivalenciaPrecios
                                             })


                Next
                obEquivalencia.detalleitemequivalencia_catalogos = ListaCatalogoPrecios
                ListEquivalencia.Add(obEquivalencia)
            Next

            obj = New detalleitems With
            {
            .codigodetalle = i.codigodetalle,
            .tipoOtroImpuesto = i.tipoOtroImpuesto,
            .otroImpuesto = i.otroImpuesto,
            .presentacion = i.presentacion,
            .descripcionItem = i.descripcionItem,
            .unidad1 = i.unidad1,
            .unidad2 = i.unidad2,
            .idItem = i.idItem,
            .idClasificacion = i.idClasificacion,
            .marcaRef = i.marcaRef,
            .tipoExistencia = i.tipoExistencia,
            .codigo = i.codigo,
            .origenProducto = i.origenProducto,
            .composicion = i.composicion,
            .idCaracteristica = i.idCaracteristica,
            .tipoBien = i.tipoBien,
            .tipoItem = i.tipoItem,
            .productoRestringido = i.productoRestringido,
            .AfectoStock = i.AfectoStock,
            .cantidadMinima = i.cantidadMinima,
            .cantidadMaxima = i.cantidadMaxima,
            .precioCompra = i.precioCompra,
            .preciocompratipo = i.preciocompratipo,
            .firstpercent = i.firstpercent,
            .beforepercent = i.beforepercent,
            .talla = i.talla,
            .color = i.color,
            .Peso = i.Peso,
            .electricidad = i.electricidad,
            .transmision = i.transmision,
            .codigoInterno = i.codigoInterno,
            .detalleitem_equivalencias = ListEquivalencia,
            .detalleitems_conexo = Listdetalleitems_conexo
            }
        End If

        Return obj
    End Function

    Function GetUbicaProductoNombre(strNomProducto As String, strEmpresa As String, intIdEstable As Integer) As detalleitems
        Dim consulta As New detalleitems
        consulta = (From a In HeliosData.detalleitems
                    Where a.descripcionItem = strNomProducto _
                    And a.idEmpresa = strEmpresa And
                    a.idEstablecimiento = intIdEstable).FirstOrDefault

        Return consulta
    End Function

    Public Function InsertDetalleItemExcel(ByVal intIdItem As Integer, ByVal strIdEmpresa As String, ByVal intIdEstable As Integer, ByVal strDescripcion As String, ByVal intIdTipExist As String, ByVal intCuentaCont As String) As Integer
        Dim objDEtalle As detalleitems
        Dim CodigoDetalleItem As Integer = 0

        Dim consulta = (From a In HeliosData.detalleitems Where a.descripcionItem = strDescripcion
                        Select a.codigodetalle).FirstOrDefault

        If ((consulta) = 0) Then
            Using ts As New TransactionScope
                objDEtalle = New detalleitems
                With objDEtalle
                    .Action = Business.Entity.BaseBE.EntityAction.INSERT
                    .idItem = intIdItem
                    .idEmpresa = strIdEmpresa
                    .idEstablecimiento = intIdEstable
                    .descripcionItem = strDescripcion
                    .cuenta = intCuentaCont
                    .unidad1 = "01"
                    .tipoExistencia = intIdTipExist
                    .origenProducto = 1
                    .tipoProducto = 1
                    .estado = 1
                    .fechaActualizacion = Date.Now
                    .usuarioActualizacion = "NN"
                End With
                HeliosData.detalleitems.Add(objDEtalle)
                HeliosData.SaveChanges()
                ts.Complete()
                CodigoDetalleItem = objDEtalle.codigodetalle
            End Using
        Else
            CodigoDetalleItem = consulta
        End If
        Return CodigoDetalleItem
    End Function

    Public Function InsertDetalle(ByVal itemBE As detalleitems) As Integer
        Dim productoBL As New detalleitemsBL()
        Using ts As New TransactionScope
            'Se inserta item
            Dim consulta As Integer = HeliosData.detalleitems.Where(Function(o) o.idEmpresa = itemBE.idEmpresa _
                                                              And o.idEstablecimiento = itemBE.idEstablecimiento And
                                                              o.descripcionItem = itemBE.descripcionItem).Count

            If consulta > 0 Then
                Throw New Exception("Existencia existente en la base de datos, ingrese otro!")
            Else
                HeliosData.detalleitems.Add(itemBE)
                HeliosData.SaveChanges()
                ts.Complete()
            End If
            'Se inserta detalle
            Return itemBE.idItem
        End Using
    End Function

    Public Function InsertDetalleProduccion(ByVal itemBE As detalleitems) As Integer
        Dim productoBL As New detalleitemsBL()
        Using ts As New TransactionScope
            'Se inserta item
            ''Dim consulta = HeliosData.detalleitems.Where(Function(o) o.idEmpresa = itemBE.idEmpresa _
            '                                                  And o.idEstablecimiento = itemBE.idEstablecimiento And _
            '                                                  o.descripcionItem = itemBE.descripcionItem And o.tipoExistencia = TipoExistencia.MateriaPrima).FirstOrDefault

            'If Not IsNothing(consulta) Then
            '    Return consulta.codigodetalle
            '    HeliosData.SaveChanges()
            '    ts.Complete()
            '    'Throw New Exception("Existencia existente en la base de datos, ingrese otro!")
            'Else
            Dim cod = InsertNuevaItems2(itemBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return cod
            'End If

        End Using
    End Function

    Public Function GetUbicarProductoXNotificacion(ByVal idEmpresa As String, idEstablec As Integer, intIdItem As Integer) As detalleitems
        Dim i = (From d In HeliosData.detalleitems
                 Join it In HeliosData.item
                 On d.idItem Equals it.idItem
                 Where d.idEmpresa = idEmpresa _
     And d.idEstablecimiento = idEstablec _
     And d.codigodetalle = intIdItem).FirstOrDefault

        Dim n As New detalleitems
        n.idEmpresa = i.d.idEmpresa
        n.idEstablecimiento = i.d.idEstablecimiento
        n.codigodetalle = i.d.codigodetalle
        n.idItem = i.d.idItem
        n.cuenta = i.d.cuenta
        n.descripcionItem = i.d.descripcionItem
        n.presentacion = i.d.presentacion
        n.unidad1 = i.d.unidad1
        n.tipoExistencia = i.d.tipoExistencia
        n.origenProducto = i.d.origenProducto
        n.tipoProducto = i.d.tipoProducto
        n.Utilidad = i.it.utilidad
        n.UtilidadMayor = i.it.utilidadmayor
        n.UtilidadGranMayor = i.it.utilidadgranmayor

        Return n
    End Function

    Public Function InsertDetalleCambioInventario(ByVal objDetalle As detalleitems) As Integer
        Dim objDEtalleItems As detalleitems
        Dim CodigoDetalleItem As Integer = 0

        Using ts As New TransactionScope
            objDEtalleItems = New detalleitems
            With objDEtalleItems
                .Action = Business.Entity.BaseBE.EntityAction.INSERT

                .idEmpresa = objDetalle.idEmpresa
                .idEstablecimiento = objDetalle.idEstablecimiento
                .descripcionItem = objDetalle.descripcionItem
                .cuenta = objDetalle.cuenta
                .unidad1 = objDetalle.unidad1
                .tipoExistencia = objDetalle.tipoExistencia
                .origenProducto = 1
                .tipoProducto = 1
                .estado = 1
                .fechaActualizacion = Date.Now
                .usuarioActualizacion = "Maykol"
            End With
            HeliosData.detalleitems.Add(objDetalle)
            HeliosData.SaveChanges()
            ts.Complete()
            CodigoDetalleItem = objDetalle.codigodetalle
        End Using

        Return CodigoDetalleItem
    End Function

    Public Sub CambiarEstadoItem(be As detalleitems)
        Dim item = HeliosData.detalleitems.Where(Function(o) o.codigodetalle = be.codigodetalle).Single
        Using ts As New TransactionScope
            item.estado = be.estado
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub actualizarPrecioCompra(be As detalleitems)
        Dim item = HeliosData.detalleitems.Where(Function(o) o.codigodetalle = be.codigodetalle).Single
        Using ts As New TransactionScope
            item.precioCompra = be.precioCompra
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EliminarProductoSinInventario(be As detalleitems)
        Try
            Dim item = HeliosData.InventarioMovimiento.Where(Function(o) o.idItem = be.codigodetalle).ToList()
            If item.Count > 0 Then
                Throw New Exception("No puede eliminar el producto, posee inventario vigente!")
            End If
            Using ts As New TransactionScope
                Dim producto = HeliosData.detalleitems.Where(Function(o) o.codigodetalle = be.codigodetalle).SingleOrDefault

                If Not IsNothing(producto) Then
                    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(producto)
                    HeliosData.SaveChanges()
                Else
                    Throw New Exception("No se puede eliminar el producto, no se ubica!")
                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function InsertCopyItemXIdEsblecimiento(ByVal itemBE As detalleitems) As detalleitems
        Dim productoBL As New detalleitemsBL()
        Dim documenovetaBL As New documentoventaAbarrotesBL
        Dim detalleBE As New detalleitems
        Dim objitem As New detalleitems

        Dim EQUIVALECIA As New detalleitem_equivalencias
        Dim LISTAEQUIVALECIA As New List(Of detalleitem_equivalencias)
        Dim EQUIVALECIA_CAT As New detalleitemequivalencia_catalogos
        Dim LISTAEQUIVALECIA_CAT As New List(Of detalleitemequivalencia_catalogos)
        Dim EQUIVALECIA_pRECIO As New detalleitemequivalencia_precios
        Dim LISTAEQUIVALECIA_CAT_PRECIO As New List(Of detalleitemequivalencia_precios)


        Using ts As New TransactionScope
            'Se inserta item
            Dim existeDetalleItem = HeliosData.detalleitems.Any(Function(o) o.descripcionItem = itemBE.descripcionItem And o.idEstablecimiento = itemBE.idEstablecimiento)

            If existeDetalleItem = False Then
                Dim ProductoOld = HeliosData.detalleitems _
                                                .Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos _
                                                .Select(Function(p) p.detalleitemequivalencia_precios))) _
                                                .Where(Function(o) o.codigodetalle = itemBE.codigodetalle) _
                                                .SingleOrDefault()


                If ProductoOld IsNot Nothing Then
                    objitem.idItem = ProductoOld.idItem   'UCNuenExistencia.txtCategoria.Tag
                    objitem.idEmpresa = ProductoOld.idEmpresa
                    objitem.idEstablecimiento = itemBE.idEstablecimiento  ' frmCanastaExistencias.cboEstablecimiento.SelectedValue
                    objitem.marcaRef = ProductoOld.marcaRef
                    objitem.descripcionItem = ProductoOld.descripcionItem
                    objitem.unidad1 = ProductoOld.unidad1
                    objitem.unidad2 = ProductoOld.unidad2  'UCNuenExistencia.txtSubCategoria.Tag
                    objitem.cuenta = ProductoOld.cuenta
                    objitem.composicion = ProductoOld.composicion
                    objitem.presentacion = ProductoOld.presentacion
                    objitem.cantMax = ProductoOld.cantMax
                    objitem.cantMinima = ProductoOld.cantMinima
                    objitem.color = ProductoOld.color
                    objitem.talla = ProductoOld.talla
                    objitem.codigo = ProductoOld.codigo
                    objitem.origenProducto = ProductoOld.origenProducto
                    objitem.tipoProducto = ProductoOld.tipoProducto
                    objitem.Percepcion = ProductoOld.Percepcion
                    objitem.Retencion = ProductoOld.Retencion
                    objitem.AfectoCompra = ProductoOld.AfectoCompra
                    objitem.AfectoVenta = ProductoOld.AfectoVenta
                    objitem.ValorPercepcion = ProductoOld.ValorPercepcion
                    objitem.ValorRetencion = ProductoOld.ValorRetencion
                    objitem.usuarioActualizacion = ProductoOld.usuarioActualizacion
                    objitem.fechaActualizacion = DateTime.Now
                    objitem.idAlmacen = ProductoOld.idAlmacen
                    objitem.productoRestringido = ProductoOld.productoRestringido
                    objitem.tipoOtroImpuesto = ProductoOld.tipoOtroImpuesto
                    objitem.otroImpuesto = ProductoOld.otroImpuesto
                    objitem.tipoOtroImpuesto = ProductoOld.tipoOtroImpuesto
                    objitem.otroImpuesto = ProductoOld.otroImpuesto
                    objitem.igv = ProductoOld.igv
                    objitem.AfectoStock = ProductoOld.AfectoStock
                    objitem.estado = ProductoOld.estado
                    objitem.cantidadMinima = ProductoOld.cantidadMinima
                    objitem.cantidadMaxima = ProductoOld.cantidadMaxima

                    For Each EQUIVAOLD In ProductoOld.detalleitem_equivalencias

                        For Each EQUIVA_CAT_OLD In EQUIVAOLD.detalleitemequivalencia_catalogos

                            For Each EQUIVA_PRECIO_OLD In EQUIVA_CAT_OLD.detalleitemequivalencia_precios

                                EQUIVALECIA_pRECIO = New detalleitemequivalencia_precios
                                EQUIVALECIA_pRECIO.rango_inicio = EQUIVA_PRECIO_OLD.rango_inicio
                                EQUIVALECIA_pRECIO.rango_final = EQUIVA_PRECIO_OLD.rango_final
                                EQUIVALECIA_pRECIO.precioCode = EQUIVA_PRECIO_OLD.precioCode
                                EQUIVALECIA_pRECIO.precio = EQUIVA_PRECIO_OLD.precio
                                EQUIVALECIA_pRECIO.precioUSD = EQUIVA_PRECIO_OLD.precioUSD
                                EQUIVALECIA_pRECIO.precioCredito = EQUIVA_PRECIO_OLD.precioCredito
                                EQUIVALECIA_pRECIO.precioCreditoUSD = EQUIVA_PRECIO_OLD.precioCreditoUSD
                                EQUIVALECIA_pRECIO.estado = EQUIVA_PRECIO_OLD.estado
                                EQUIVALECIA_pRECIO.usuarioActualizacion = EQUIVA_PRECIO_OLD.usuarioActualizacion
                                EQUIVALECIA_pRECIO.fechaActualizacion = EQUIVA_PRECIO_OLD.fechaActualizacion
                                LISTAEQUIVALECIA_CAT_PRECIO.Add(EQUIVALECIA_pRECIO)
                            Next

                            EQUIVALECIA_CAT = New detalleitemequivalencia_catalogos
                            EQUIVALECIA_CAT.nombre_corto = EQUIVA_CAT_OLD.nombre_corto
                            EQUIVALECIA_CAT.nombre_largo = EQUIVA_CAT_OLD.nombre_largo
                            EQUIVALECIA_CAT.predeterminado = EQUIVA_CAT_OLD.predeterminado
                            EQUIVALECIA_CAT.estado = EQUIVA_CAT_OLD.estado
                            EQUIVALECIA_CAT.detalleitemequivalencia_precios = LISTAEQUIVALECIA_CAT_PRECIO

                            LISTAEQUIVALECIA_CAT.Add(EQUIVALECIA_CAT)

                        Next

                        EQUIVALECIA = New detalleitem_equivalencias
                        'EQUIVALECIA.codigodetalle = EQUIVAOLD.codigodetalle
                        'EQUIVALECIA.equivalencia_id = EQUIVAOLD.equivalencia_id
                        EQUIVALECIA.detalle = EQUIVAOLD.detalle
                        EQUIVALECIA.unidadComercial = EQUIVAOLD.unidadComercial
                        EQUIVALECIA.contenido = EQUIVAOLD.contenido
                        EQUIVALECIA.fraccionUnidad = EQUIVAOLD.fraccionUnidad
                        EQUIVALECIA.estado = EQUIVAOLD.estado
                        EQUIVALECIA.contenido_neto = EQUIVAOLD.contenido_neto
                        EQUIVALECIA.flag = EQUIVAOLD.contenido_neto
                        EQUIVALECIA.usuarioActualizacion = EQUIVAOLD.usuarioActualizacion
                        EQUIVALECIA.fechaActualizacion = EQUIVAOLD.fechaActualizacion
                        EQUIVALECIA.codigo = EQUIVAOLD.codigo
                        EQUIVALECIA.detalleitemequivalencia_catalogos = LISTAEQUIVALECIA_CAT

                        LISTAEQUIVALECIA.Add(EQUIVALECIA)
                    Next

                    objitem.detalleitem_equivalencias = LISTAEQUIVALECIA

                    detalleBE = documenovetaBL.CrearNuevoItemUN(objitem)
                    HeliosData.SaveChanges()
                    ts.Complete()
                    objitem = objitem
                End If
            Else
                Throw New Exception("Existencia existente en la base de datos, ingrese otro!")
            End If
            Return objitem
        End Using
    End Function

#Region "Restaurnt"
    Public Function GetProductosWithEquivalenciasXTipo(be As detalleitems) As List(Of detalleitems)

        Dim consulta = HeliosData.detalleitems.Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))).Where(Function(d) d.descripcionItem.Contains(be.descripcionItem) And be.ListaTipoExistencia.Contains(d.tipoExistencia)).ToList

        Dim obj As detalleitems
        Dim obEquivalencia As detalleitem_equivalencias
        Dim ListEquivalencia As List(Of detalleitem_equivalencias)
        Dim ListEquivalenciaPrecios As List(Of detalleitemequivalencia_precios)
        Dim ListaCatalogoPrecios As List(Of detalleitemequivalencia_catalogos)


        GetProductosWithEquivalenciasXTipo = New List(Of detalleitems)

        For Each i In consulta

            ListEquivalencia = New List(Of detalleitem_equivalencias)
            For Each eq In i.detalleitem_equivalencias
                obEquivalencia = New detalleitem_equivalencias
                obEquivalencia.detalle = eq.detalle
                obEquivalencia.unidadComercial = eq.unidadComercial
                obEquivalencia.contenido = eq.contenido
                obEquivalencia.equivalencia_id = eq.equivalencia_id
                obEquivalencia.fraccionUnidad = eq.fraccionUnidad
                obEquivalencia.estado = eq.estado

                ListaCatalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
                For Each cat In eq.detalleitemequivalencia_catalogos
                    ListEquivalenciaPrecios = New List(Of detalleitemequivalencia_precios)
                    For Each prec In cat.detalleitemequivalencia_precios
                        ListEquivalenciaPrecios.Add(New detalleitemequivalencia_precios With
                                                    {
                                                    .rango_inicio = prec.rango_inicio,
                                                    .rango_final = prec.rango_final,
                                                    .precioCredito = prec.precioCredito,
                                                    .precio = prec.precio,
                                                    .precio_id = prec.precio_id,
                                                    .precioCode = prec.precioCode,
                                                    .estado = prec.estado
                                                    })
                    Next

                    ListaCatalogoPrecios.Add(New detalleitemequivalencia_catalogos With {
                                             .idCatalogo = cat.idCatalogo,
                                             .codigodetalle = cat.codigodetalle,
                                             .equivalencia_id = cat.equivalencia_id,
                                             .nombre_corto = cat.nombre_corto,
                                             .nombre_largo = cat.nombre_largo,
                                             .estado = cat.estado,
                                             .predeterminado = cat.predeterminado,
                                             .detalleitemequivalencia_precios = ListEquivalenciaPrecios
                                             })

                Next
                obEquivalencia.detalleitemequivalencia_catalogos = ListaCatalogoPrecios
                ListEquivalencia.Add(obEquivalencia)
            Next

            obj = New detalleitems With
            {
            .codigodetalle = i.codigodetalle,
            .idItem = i.idItem,
            .descripcionItem = i.descripcionItem,
            .unidad1 = i.unidad1,
            .tipoExistencia = i.tipoExistencia,
            .unidad2 = i.unidad2,
            .codigo = i.codigo,
            .origenProducto = i.origenProducto,
            .composicion = i.composicion,
            .detalleitem_equivalencias = ListEquivalencia
            }
            GetProductosWithEquivalenciasXTipo.Add(obj)
        Next

        Return GetProductosWithEquivalenciasXTipo

    End Function

    Public Function GetProductosWithEquivalenciasXCat(be As detalleitems) As List(Of detalleitems)


        Dim ESTADO As New List(Of String)
        ESTADO.Add("MIN")
        ESTADO.Add("SOLO")
        Dim consulta = HeliosData.detalleitems _
            .Include(Function(t) t.item) _
            .Include(Function(lot) lot.recursoCostoLote) _
            .Include(Function(ax) ax.detalleitems_conexo) _
            .Include(Function(o) o.detalleitem_equivalencias.Select(Function(c) c.detalleitemequivalencia_catalogos.Select(Function(p) p.detalleitemequivalencia_precios))) _
            .Where(Function(d) d.unidad2 = be.idItem And d.estado = "A" And d.idEmpresa = be.idEmpresa And d.idEstablecimiento = be.idEstablecimiento) _
                                 .Select(Function(o) New With
                                 {
                                 .detalleitems = o,
                                 .category = o.item,
                                 .detalleitems_conexo = o.detalleitems_conexo,
                                 .Lotes = o.recursoCostoLote.OrderByDescending(Function(x) x.fechaentrada).Take(2).ToList,
                                 .detalleitem_equivalencias = o.detalleitem_equivalencias.Select(Function(e) New With
                                            {
                                            .Equivale = e,
                                            .detalleitemequivalencia_beneficio = e.detalleitemequivalencia_beneficio,
                                            .detalleitemequivalencia_catalogos = e.detalleitemequivalencia_catalogos.Select(Function(p) New With
                                                                                                                                {
                                                                                                                                .Cat = p,
                                                                                                                                .Precios = p.detalleitemequivalencia_precios
                                                                                                                                })
                                            })}).ToList

        Dim obj As detalleitems
        Dim obEquivalencia As detalleitem_equivalencias
        Dim ListEquivalencia As List(Of detalleitem_equivalencias)
        Dim Listdetalleitems_conexo As List(Of detalleitems_conexo)
        Dim ListEquivalenciaPrecios As List(Of detalleitemequivalencia_precios)
        Dim ListaCatalogoPrecios As List(Of detalleitemequivalencia_catalogos)
        Dim ListaBeneficios As List(Of detalleitemequivalencia_beneficio)
        Dim ListaLotes As List(Of recursoCostoLote) = Nothing

        GetProductosWithEquivalenciasXCat = New List(Of detalleitems)

        For Each i In consulta
            Listdetalleitems_conexo = New List(Of detalleitems_conexo)
            For Each ax In i.detalleitems_conexo
                Listdetalleitems_conexo.Add(New detalleitems_conexo With {
                    .conexo_id = ax.conexo_id,
                    .codigodetalle = ax.codigodetalle,
                    .idProducto = ax.idProducto,
                    .detalle = ax.detalle,
                    .cantidad = ax.cantidad,
                    .equivalencia_id = ax.equivalencia_id,
                    .unidadComercial = ax.unidadComercial,
                    .fraccion = ax.fraccion,
                    .estado = ax.estado,
                    .vigencia = ax.vigencia,
                    .usuarioActualizacion = ax.usuarioActualizacion,
                    .fechaActualizacion = ax.fechaActualizacion
                                            })
            Next

            ListEquivalencia = New List(Of detalleitem_equivalencias)
            For Each eq In i.detalleitem_equivalencias.Where(Function(O) ESTADO.Contains(O.Equivale.flag)).ToList
                obEquivalencia = New detalleitem_equivalencias
                obEquivalencia.codigodetalle = i.detalleitems.codigodetalle
                obEquivalencia.detalle = eq.Equivale.detalle
                obEquivalencia.unidadComercial = eq.Equivale.unidadComercial
                obEquivalencia.contenido = eq.Equivale.contenido
                obEquivalencia.equivalencia_id = eq.Equivale.equivalencia_id
                obEquivalencia.fraccionUnidad = eq.Equivale.fraccionUnidad
                obEquivalencia.estado = eq.Equivale.estado
                obEquivalencia.flag = eq.Equivale.flag
                obEquivalencia.contenido_neto = eq.Equivale.contenido_neto
                obEquivalencia.codigo = eq.Equivale.codigo
                ListaLotes = New List(Of recursoCostoLote)
                For Each lot In i.Lotes
                    Dim l As New recursoCostoLote With
                {
                .codigoLote = lot.codigoLote,
                .nroLote = lot.nroLote,
                .idDocumento = lot.idDocumento,
                .idproyecto = lot.idproyecto,
                .codigoProducto = lot.codigoProducto,
                .moneda = lot.moneda,
                .detalle = lot.detalle,
                .cantidad = lot.cantidad,
                .precioUnitarioIva = lot.precioUnitarioIva,
                .fechaentrada = lot.fechaentrada,
                .fechaProduccion = lot.fechaProduccion,
                .fechaVcto = lot.fechaVcto,
                .serie = lot.serie,
                .sku = lot.sku,
                .composicion = lot.composicion,
                .productoSustentado = lot.productoSustentado
                }
                    ListaLotes.Add(l)
                Next

                ListaBeneficios = New List(Of detalleitemequivalencia_beneficio)
                For Each ben In eq.detalleitemequivalencia_beneficio
                    ListaBeneficios.Add(New detalleitemequivalencia_beneficio With
                                    {
                                    .beneficio_id = ben.beneficio_id,
                                    .codigodetalle = ben.codigodetalle,
                                    .equivalencia_id = ben.equivalencia_id,
                                    .beneficio_detalle = ben.beneficio_detalle,
                                    .tipobeneficio = ben.tipobeneficio,
                                    .tipoafectacion = ben.tipoafectacion,
                                    .valor_evaluado = ben.valor_evaluado,
                                    .valor_conversion = ben.valor_conversion,
                                    .valor_beneficio = ben.valor_beneficio,
                                    .lote_id = ben.lote_id,
                                    .estado = ben.estado,
                                    .usuarioActualizacion = ben.usuarioActualizacion,
                                    .fechaActualizacion = ben.fechaActualizacion
                                    })
                Next


                ListaCatalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
                For Each cat In eq.detalleitemequivalencia_catalogos
                    ListEquivalenciaPrecios = New List(Of detalleitemequivalencia_precios)
                    For Each prec In cat.Precios
                        ListEquivalenciaPrecios.Add(New detalleitemequivalencia_precios With
                                                {
                                                .idCatalogo = cat.Cat.idCatalogo,
                                                .rango_inicio = prec.rango_inicio,
                                                .rango_final = prec.rango_final,
                                                .precioCredito = prec.precioCredito,
                                                .precioCreditoUSD = prec.precioCreditoUSD,
                                                .precio = prec.precio,
                                                .precioUSD = prec.precioUSD,
                                                .precio_id = prec.precio_id,
                                                .precioCode = prec.precioCode,
                                                .estado = prec.estado
                                                })
                    Next

                    ListaCatalogoPrecios.Add(New detalleitemequivalencia_catalogos With {
                                         .idCatalogo = cat.Cat.idCatalogo,
                                         .codigodetalle = cat.Cat.codigodetalle,
                                         .equivalencia_id = cat.Cat.equivalencia_id,
                                         .nombre_corto = cat.Cat.nombre_corto,
                                         .nombre_largo = cat.Cat.nombre_largo,
                                         .estado = cat.Cat.estado,
                                         .predeterminado = cat.Cat.predeterminado,
                                         .detalleitemequivalencia_precios = ListEquivalenciaPrecios
                                         })
                Next
                obEquivalencia.detalleitemequivalencia_catalogos = ListaCatalogoPrecios
                obEquivalencia.detalleitemequivalencia_beneficio = ListaBeneficios
                ListEquivalencia.Add(obEquivalencia)
            Next

            obj = New detalleitems With
            {
            .codigodetalle = i.detalleitems.codigodetalle,
            .estado = i.detalleitems.estado,
            .idItem = i.detalleitems.idItem,
            .descripcionItem = i.detalleitems.descripcionItem,
            .unidad1 = i.detalleitems.unidad1,
               .presentacion = i.detalleitems.presentacion,
            .tipoExistencia = i.detalleitems.tipoExistencia,
            .unidad2 = i.detalleitems.unidad2,
            .codigo = i.detalleitems.codigo,
            .origenProducto = i.detalleitems.origenProducto,
            .composicion = i.detalleitems.composicion,
            .AfectoStock = i.detalleitems.AfectoStock,
            .detalleitem_equivalencias = ListEquivalencia,
            .recursoCostoLote = ListaLotes,
            .tipoOtroImpuesto = i.detalleitems.tipoOtroImpuesto,
            .otroImpuesto = i.detalleitems.otroImpuesto,
            .detalleitems_conexo = Listdetalleitems_conexo
            }
            GetProductosWithEquivalenciasXCat.Add(obj)
        Next

    End Function

    Public Sub actualizarMarcaProducto(be As detalleitems)
        Dim item = HeliosData.detalleitems.Where(Function(o) o.codigodetalle = be.codigodetalle).Single
        Using ts As New TransactionScope
            item.idItem = be.idItem
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetUbicarProductoXTipoExistencia(ByVal idEmpresa As String, idEstablec As Integer, strTipoExistencia As String) As List(Of detalleitems)
        Return (From n In HeliosData.detalleitems
                Where n.idEmpresa = idEmpresa _
                And n.idEstablecimiento = idEstablec _
                And n.tipoExistencia = strTipoExistencia).ToList

    End Function

    Public Function GetUbicarProductoXMarca(ByVal detalleItemBE As detalleitems) As List(Of detalleitems)

        Dim listaDetalle As New List(Of detalleitems)

        Dim consulta = (From d In HeliosData.detalleitems
                        Join it In HeliosData.item
                 On d.idItem Equals it.idItem
                        Where d.idEmpresa = detalleItemBE.idEmpresa _
     And d.idEstablecimiento = detalleItemBE.idEstablecimiento).Distinct.ToList


        For Each i In consulta
            Dim n As New detalleitems
            n.idEmpresa = i.d.idEmpresa
            n.idEstablecimiento = i.d.idEstablecimiento
            n.codigodetalle = i.d.codigodetalle
            n.idItem = i.d.idItem
            n.cuenta = i.d.cuenta
            n.descripcionItem = i.d.descripcionItem
            n.presentacion = i.it.descripcion
            n.unidad1 = i.d.unidad1
            n.tipoExistencia = i.d.tipoExistencia
            n.origenProducto = i.d.origenProducto
            n.tipoProducto = i.d.tipoProducto
            n.Utilidad = i.it.utilidad
            n.UtilidadMayor = i.it.utilidadmayor
            n.UtilidadGranMayor = i.it.utilidadgranmayor
            listaDetalle.Add(n)
        Next
        Return listaDetalle
    End Function

    Public Function GetExistenciasXTipoExistencia(detalleitemsBE As detalleitems) As List(Of detalleitems)

        Dim obj As detalleitems
        Dim con = (From a In HeliosData.detalleitems
                   Group Join cat In HeliosData.item
                       On cat.idItem Equals a.unidad2
                       Into ov = Group
                   From x In ov.DefaultIfEmpty()
                   Where a.idEmpresa = detalleitemsBE.idEmpresa And a.idEstablecimiento = detalleitemsBE.idEstablecimiento And a.tipoExistencia = detalleitemsBE.tipoExistencia).ToList

        GetExistenciasXTipoExistencia = New List(Of detalleitems)

        For Each i In con
            obj = New detalleitems

            If i.x IsNot Nothing Then
                obj.item = New item With
                {
                .idItem = i.x.idItem,
                .descripcion = i.x.descripcion
                }

            End If

            obj.codigodetalle = i.a.codigodetalle
            obj.codigo = i.a.codigo
            obj.descripcionItem = i.a.descripcionItem
            obj.unidad1 = i.a.unidad1
            obj.tipoExistencia = i.a.tipoExistencia
            obj.origenProducto = i.a.origenProducto
            obj.estado = i.a.estado
            GetExistenciasXTipoExistencia.Add(obj)
        Next

    End Function

#End Region

End Class
