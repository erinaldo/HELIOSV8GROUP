Imports System.Data.Entity.Migrations
Imports System.Transactions
Imports Helios.Cont.Business.Entity
Imports System.Data.Entity
Public Class detalleitemcatalogo_comisionBL
    Inherits BaseBL

    Public Function detalleitemcatalogo_comisionSelCatalogo(be As detalleitemcatalogo_comision) As detalleitemcatalogo_comision
        Dim con = HeliosData.detalleitemcatalogo_comision _
            .Include(Function(o) o.detalleitemcatalogo_comisiondetalle) _
            .Where(Function(o) o.idCatalogo = be.idCatalogo).SingleOrDefault()
        Return MappingComisionSingle(con)
    End Function

    Public Function detalleitemcatalogo_comisionSelCatalogoList(be As detalleitemcatalogo_comision) As List(Of detalleitemcatalogo_comision)
        Dim con = HeliosData.detalleitemcatalogo_comision _
            .Include(Function(o) o.detalleitemcatalogo_comisiondetalle) _
            .Where(Function(o) o.codigodetalle = be.codigodetalle And
                               o.equivalencia_id = be.equivalencia_id And
                               o.idCatalogo = be.idCatalogo).ToList()
        Return MappingComision(con)
    End Function

    Public Function detalleitemcatalogo_comisionSelUnidadComercial(be As detalleitemcatalogo_comision) As detalleitemcatalogo_comision
        Dim con = HeliosData.detalleitemcatalogo_comision _
            .Include(Function(o) o.detalleitemcatalogo_comisiondetalle) _
            .Where(Function(o) o.equivalencia_id = be.equivalencia_id).SingleOrDefault()
        Return MappingComisionSingle(con)
    End Function

    Public Function detalleitemcatalogo_comisionJoinList(be As detalleitemcatalogo_comision) As List(Of detalleitemcatalogo_comision)


        Dim con = HeliosData.detalleitemcatalogo_comision _
            .Include(Function(det) det.detalleitemcatalogo_comisiondetalle) _
            .Join(HeliosData.detalleitems, Function(comi) comi.codigodetalle, Function(prod) prod.codigodetalle, Function(comi, prod) New With
                                                                                                                     {
                                                                                                                     .producto = prod,
                                                                                                                     .detalleitemcatalogo_comision = comi,
                                                                                                                     .detalleitemcatalogo_comisiondetalle = comi.detalleitemcatalogo_comisiondetalle
                                                                                                                     }) _
             .Join(HeliosData.detalleitem_equivalencias, Function(comi2) comi2.detalleitemcatalogo_comision.equivalencia_id, Function(prod2) prod2.equivalencia_id, Function(comi2, prod2) New With
                                                                                                                     {
                                                                                                                     .producto = comi2.producto,
                                                                                                                     .detalleitemcatalogo_comision = comi2.detalleitemcatalogo_comision,
                                                                                                                     .detalleitemcatalogo_comisiondetalle = comi2.detalleitemcatalogo_comisiondetalle,
                                                                                                                     .unidadComercial = prod2
                                                                                                                     }) _
        .Join(HeliosData.detalleitemequivalencia_catalogos, Function(comi3) comi3.detalleitemcatalogo_comision.idCatalogo, Function(prod3) prod3.idCatalogo, Function(comi3, prod3) New With
                                                                                                                     {
                                                                                                                     .producto = comi3.producto,
                                                                                                                     .detalleitemcatalogo_comision = comi3.detalleitemcatalogo_comision,
                                                                                                                     .detalleitemcatalogo_comisiondetalle = comi3.detalleitemcatalogo_comisiondetalle,
                                                                                                                     .unidadComercial = comi3.unidadComercial,
                                                                                                                     .catalogoprecio = prod3
                                                                                                                     }) _
            .Where(Function(o) o.detalleitemcatalogo_comision.unidadNegocio = be.unidadNegocio).ToList()

        detalleitemcatalogo_comisionJoinList = New List(Of detalleitemcatalogo_comision)
        Dim obj As detalleitemcatalogo_comision
        Dim listaDetalle As List(Of detalleitemcatalogo_comisiondetalle)
        For Each i In con
            obj = New detalleitemcatalogo_comision
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
            obj.idComision = i.detalleitemcatalogo_comision.idComision
            obj.codigodetalle = i.detalleitemcatalogo_comision.codigodetalle
            obj.equivalencia_id = i.detalleitemcatalogo_comision.equivalencia_id
            obj.idCatalogo = i.detalleitemcatalogo_comision.idCatalogo
            obj.nombre_comision = i.detalleitemcatalogo_comision.nombre_comision
            obj.tipo_comision = i.detalleitemcatalogo_comision.tipo_comision
            obj.bloqueado = i.detalleitemcatalogo_comision.bloqueado
            obj.vigencia = i.detalleitemcatalogo_comision.vigencia
            obj.apartir_de = i.detalleitemcatalogo_comision.apartir_de
            obj.montoMaximo = i.detalleitemcatalogo_comision.montoMaximo
            obj.montoMinimo = i.detalleitemcatalogo_comision.montoMinimo


            listaDetalle = New List(Of detalleitemcatalogo_comisiondetalle)
            For Each det In i.detalleitemcatalogo_comisiondetalle.ToList
                listaDetalle.Add(New detalleitemcatalogo_comisiondetalle() With {
                                 .idComision = det.idComision,
                                 .idComisiondetalle = det.idComisiondetalle,
                                 .IdUsuario = det.IdUsuario,
                                 .tipoUsuario = det.tipoUsuario,
                                 .vence = det.vence,
                                 .bloqueado = det.bloqueado,
                                 .moneda = det.moneda,
                                 .formaEntregaPago = det.formaEntregaPago,
                                 .dias_restringidos = det.dias_restringidos,
                                 .importe_comisionMN = det.importe_comisionMN,
                                 .importe_comisionME = det.importe_comisionME
                                 })
            Next
            obj.detalleitemcatalogo_comisiondetalle = listaDetalle
            detalleitemcatalogo_comisionJoinList.Add(obj)
        Next
    End Function

    Public Function detalleitemcatalogo_comisionList(be As detalleitemcatalogo_comision) As List(Of detalleitemcatalogo_comision)
        Dim con = HeliosData.detalleitemcatalogo_comision _
            .Include(Function(o) o.detalleitemcatalogo_comisiondetalle) _
            .Where(Function(o) o.unidadNegocio = be.unidadNegocio).ToList()
        Return MappingComision(con)
    End Function

    Public Function MappingComision(lista As List(Of detalleitemcatalogo_comision)) As List(Of detalleitemcatalogo_comision)
        MappingComision = New List(Of detalleitemcatalogo_comision)
        For Each i In lista
            MappingComision.Add(New detalleitemcatalogo_comision With {
                                .idComision = i.idComision,
                                .empresa = i.empresa,
                                .unidadNegocio = i.unidadNegocio,
                                .codigodetalle = i.codigodetalle,
                                .equivalencia_id = i.equivalencia_id,
                                .idCatalogo = i.idCatalogo,
                                .nombre_comision = i.nombre_comision,
                                .tipo_comision = i.tipo_comision,
                                .bloqueado = i.bloqueado,
                                .vigencia = i.vigencia,
                                .apartir_de = i.apartir_de,
                                .montoMaximo = i.montoMaximo,
                                .montoMinimo = i.montoMinimo,
                                .detalleitemcatalogo_comisiondetalle = GetMappingDetalleComision(i.detalleitemcatalogo_comisiondetalle.ToList())
                                })
        Next

    End Function

    Public Function MappingComisionSingle(i As detalleitemcatalogo_comision) As detalleitemcatalogo_comision
        MappingComisionSingle = New detalleitemcatalogo_comision With {
                                  .idComision = i.idComision,
                                  .empresa = i.empresa,
                                  .unidadNegocio = i.unidadNegocio,
                                  .codigodetalle = i.codigodetalle,
                                  .equivalencia_id = i.equivalencia_id,
                                  .idCatalogo = i.idCatalogo,
                                  .nombre_comision = i.nombre_comision,
                                  .tipo_comision = i.tipo_comision,
                                  .bloqueado = i.bloqueado,
                                  .vigencia = i.vigencia,
                                  .apartir_de = i.apartir_de,
                                  .montoMaximo = i.montoMaximo,
                                  .montoMinimo = i.montoMinimo,
                                  .detalleitemcatalogo_comisiondetalle = GetMappingDetalleComision(i.detalleitemcatalogo_comisiondetalle.ToList())
                                  }
    End Function

    Private Function GetMappingDetalleComision(list As List(Of detalleitemcatalogo_comisiondetalle)) As List(Of detalleitemcatalogo_comisiondetalle)
        GetMappingDetalleComision = New List(Of detalleitemcatalogo_comisiondetalle)
        For Each i In list
            GetMappingDetalleComision.Add(New detalleitemcatalogo_comisiondetalle With {
                                          .idComision = i.idComision,
                                          .idComisiondetalle = i.idComisiondetalle,
                                          .IdUsuario = i.IdUsuario,
                                          .tipoUsuario = i.tipoUsuario,
                                          .vence = i.vence,
                                          .bloqueado = i.bloqueado,
                                          .moneda = i.moneda,
                                          .formaEntregaPago = i.formaEntregaPago,
                                          .dias_restringidos = i.dias_restringidos,
                                          .importe_comisionMN = i.importe_comisionMN,
                                          .importe_comisionME = i.importe_comisionME
                                          })
        Next

    End Function

    Public Function detalleitemcatalogo_comisionSave(be As detalleitemcatalogo_comision) As detalleitemcatalogo_comision
        Using ts As New TransactionScope()

            Select Case be.Action
                Case BaseBE.EntityAction.INSERT
                    HeliosData.detalleitemcatalogo_comision.Add(be)
                Case BaseBE.EntityAction.UPDATE
                    HeliosData.detalleitemcatalogo_comision.AddOrUpdate(be)
                Case BaseBE.EntityAction.DELETE
                    HeliosData.detalleitemcatalogo_comision.AddOrUpdate(be)
            End Select
            HeliosData.SaveChanges()
            ts.Complete()
            Return be
        End Using
    End Function

End Class
