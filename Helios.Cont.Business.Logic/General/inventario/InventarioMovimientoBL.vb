Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class InventarioMovimientoBL
    Inherits BaseBL

#Region "DEPURADO"
    Public Function GetMovimientosKardexByMesSustentado(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento)
        Dim obj As New InventarioMovimiento
        Dim lista As New List(Of InventarioMovimiento)


        Select Case be.tipoConsulta
            Case "EMPRESA"
                Dim consulta = (From t In HeliosData.InventarioMovimiento
                                Join art In HeliosData.detalleitems
                                    On art.codigodetalle Equals t.idItem
                                Join Lote In HeliosData.recursoCostoLote
                                    On Lote.codigoLote Equals t.nrolote
                                Where
                                    t.idEmpresa = be.idEmpresa And
                                    art.estado = "A" And
                                    Lote.productoSustentado = be.customLote.productoSustentado And
                                    CLng(t.fecha.Value.Year) = be.fecha.Value.Year And
                                    CLng(t.fecha.Value.Month) = be.fecha.Value.Month And
                                    t.idAlmacen = be.idAlmacen
                                Order By art.descripcionItem, art.codigodetalle, t.tipoProducto, art.origenProducto, t.nrolote, t.fecha Ascending
                                Select
                                    Lote.nroLote,
                                    Lote.codigoLote,
                                    Lote.fechaVcto,
                                    t.idInventario,
                                    t.fecha,
                                    t.idEmpresa,
                                    t.idAlmacen,
                                    t.tipoProducto,
                                    t.idDocumento,
                                    t.idDocumentoRef,
                                    t.tipoRegistro,
                                    t.serie,
                                    t.numero,
                                    t.tipoOperacion,
                                    art.codigodetalle,
                                    art.origenProducto,
                                    t.descripcion,
                                    art.descripcionItem,
                                    art.unidad1,
                                    t.cantidad,
                                    t.monto,
                                    DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                            Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                            Select New With
                                                                    {
                                                                    c.descripcion
                                                                    }).FirstOrDefault().descripcion,
                                    Valor_venta = (From c In HeliosData.documentoventaAbarrotesDet
                                                   Where c.idDocumento = t.idDocumento And c.idItem = t.idItem And
                                                       c.codigoLote = t.nrolote
                                                   Select New With
                                                               {
                                                               c.montokardex
                                                               }).FirstOrDefault().montokardex).ToList


                'Dim listaVenta = consulta.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.VENTA).ToList
                For Each i In consulta
                    obj = New InventarioMovimiento
                    obj.customLote = New recursoCostoLote With
                        {
                        .codigoLote = i.codigoLote,
                        .nroLote = i.nroLote,
                        .fechaVcto = i.fechaVcto
                    }
                    obj.idInventario = i.idInventario
                    obj.ValorDeVenta = i.Valor_venta.GetValueOrDefault
                    'obj.NombreAlmacen = i.descripcionAlmacen
                    obj.fecha = i.fecha
                    obj.idEmpresa = i.idEmpresa
                    obj.idAlmacen = i.idAlmacen
                    obj.tipoProducto = i.tipoProducto
                    obj.idDocumento = i.idDocumento
                    obj.idDocumentoRef = i.idDocumentoRef
                    obj.tipoRegistro = i.tipoRegistro
                    obj.serie = i.serie
                    obj.numero = i.numero
                    obj.tipoOperacion = i.tipoOperacion
                    obj.DetalleTipoOperacion = i.DetalleTipoOperacion
                    obj.idItem = i.codigodetalle
                    obj.destinoGravadoItem = i.origenProducto
                    obj.descripcion = i.descripcionItem
                    obj.nombreItem = i.descripcionItem
                    obj.unidad = i.unidad1
                    obj.cantidad = i.cantidad
                    obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
                    obj.monto = i.monto
                    obj.montoOther = 0 ' i.CierreImporteMesAnterior.GetValueOrDefault
                    lista.Add(obj)
                Next

            Case "UNIDAD_ORGANICA"
                Dim consulta = (From t In HeliosData.InventarioMovimiento
                                Join art In HeliosData.detalleitems
                                    On art.codigodetalle Equals t.idItem
                                Join Lote In HeliosData.recursoCostoLote
                                    On Lote.codigoLote Equals t.nrolote
                                Where
                                      t.idEmpresa = be.idEmpresa And
                                    t.idEstablecimiento = be.idEstablecimiento And
                                    art.estado = "A" And
                                    Lote.productoSustentado = be.customLote.productoSustentado And
                                    CLng(t.fecha.Value.Year) = be.fecha.Value.Year And
                                    CLng(t.fecha.Value.Month) = be.fecha.Value.Month And
                                    t.idAlmacen = be.idAlmacen
                                Order By art.descripcionItem, art.codigodetalle, t.tipoProducto, art.origenProducto, t.nrolote, t.fecha Ascending
                                Select
                                    Lote.nroLote,
                                    Lote.codigoLote,
                                    Lote.fechaVcto,
                                    t.idInventario,
                                    t.fecha,
                                    t.idEmpresa,
                                    t.idAlmacen,
                                    t.tipoProducto,
                                    t.idDocumento,
                                    t.idDocumentoRef,
                                    t.tipoRegistro,
                                    t.serie,
                                    t.numero,
                                    t.tipoOperacion,
                                    art.codigodetalle,
                                    art.origenProducto,
                                    t.descripcion,
                                    art.descripcionItem,
                                    art.unidad1,
                                    t.cantidad,
                                    t.monto,
                                    DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                            Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                            Select New With
                                                                    {
                                                                    c.descripcion
                                                                    }).FirstOrDefault().descripcion,
                                    Valor_venta = (From c In HeliosData.documentoventaAbarrotesDet
                                                   Where c.idDocumento = t.idDocumento And c.idItem = t.idItem And
                                                       c.codigoLote = t.nrolote
                                                   Select New With
                                                               {
                                                               c.montokardex
                                                               }).FirstOrDefault().montokardex).ToList


                'Dim listaVenta = consulta.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.VENTA).ToList
                For Each i In consulta
                    obj = New InventarioMovimiento
                    obj.customLote = New recursoCostoLote With
                        {
                        .codigoLote = i.codigoLote,
                        .nroLote = i.nroLote,
                        .fechaVcto = i.fechaVcto
                    }
                    obj.idInventario = i.idInventario
                    obj.ValorDeVenta = i.Valor_venta.GetValueOrDefault
                    'obj.NombreAlmacen = i.descripcionAlmacen
                    obj.fecha = i.fecha
                    obj.idEmpresa = i.idEmpresa
                    obj.idAlmacen = i.idAlmacen
                    obj.tipoProducto = i.tipoProducto
                    obj.idDocumento = i.idDocumento
                    obj.idDocumentoRef = i.idDocumentoRef
                    obj.tipoRegistro = i.tipoRegistro
                    obj.serie = i.serie
                    obj.numero = i.numero
                    obj.tipoOperacion = i.tipoOperacion
                    obj.DetalleTipoOperacion = i.DetalleTipoOperacion
                    obj.idItem = i.codigodetalle
                    obj.destinoGravadoItem = i.origenProducto
                    obj.descripcion = i.descripcionItem
                    obj.nombreItem = i.descripcionItem
                    obj.unidad = i.unidad1
                    obj.cantidad = i.cantidad
                    obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
                    obj.monto = i.monto
                    obj.montoOther = 0 ' i.CierreImporteMesAnterior.GetValueOrDefault
                    lista.Add(obj)
                Next
        End Select


        Return lista
    End Function

    Public Function GetKardexPeridoByExistencia(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim cierreBL As New cierreinventarioBL
        Dim cierre As New cierreinventario
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim producto As String = Nothing
        Dim productoCache As String = Nothing
        Try
            Dim periodoCierre As String = String.Format("{0:00}", be.fecha.Value.Month) & be.fecha.Value.Year

            Dim inventarios = (From p In HeliosData.InventarioMovimiento
                               Where p.idAlmacen = be.idAlmacen _
                                   And p.fecha.Value.Month = CInt(be.fecha.Value.Month) _
                                   And p.fecha.Value.Year = CInt(be.fecha.Value.Year) _
                                   And p.tipoProducto = be.tipoExistencia _
                                   And p.idItem = be.idItem
                               Order By p.descripcion, p.fecha Ascending
                               Select New With
                                           {.idInventario = p.idInventario,
                                            .Fecha = p.fecha,
                                            .idEmpresa = p.idEmpresa,
                                            .idAlmacen = p.idAlmacen,
                                            .idItem = p.idItem,
                                            .nombreItem = p.descripcion,
                                            .marca = p.marca,
                                            .cantidad = p.cantidad,
                                            .unidad = p.unidad,
                                            .UnitproceE = p.precUnite,
                                            .monto = p.monto,
                                            .disponible = p.disponible,
                                            .estado = p.status,
                                            .TipoRegistro = p.tipoRegistro,
                                            .Glosa = p.descripcion,
                                            .NroDoc = p.serie & "-" & p.numero,
                                            .Cuenta = p.cuentaOrigen,
                                            .IdDocumento = p.idDocumento,
                                            .TipoProducto = p.tipoProducto,
                                            .DestinoGravado = p.destinoGravadoItem,
                                            .CostoUS = p.montoUSD,
                                            .tipoOperacion = p.tipoOperacion
                                           }
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento
                objInventarioMovimientoBO.idInventario = obj.idInventario
                objInventarioMovimientoBO.fecha = obj.Fecha
                objInventarioMovimientoBO.idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa)
                objInventarioMovimientoBO.idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen)
                objInventarioMovimientoBO.idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem)
                objInventarioMovimientoBO.nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem)
                objInventarioMovimientoBO.marca = obj.marca
                objInventarioMovimientoBO.disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible)
                objInventarioMovimientoBO.status = IIf(IsDBNull(obj.estado), Nothing, obj.estado)
                objInventarioMovimientoBO.tipoRegistro = obj.TipoRegistro.ToString
                objInventarioMovimientoBO.glosa = obj.Glosa
                objInventarioMovimientoBO.NumDocCompra = obj.NroDoc
                objInventarioMovimientoBO.cuentaOrigen = obj.Cuenta
                objInventarioMovimientoBO.idDocumento = obj.IdDocumento
                objInventarioMovimientoBO.tipoProducto = obj.TipoProducto
                objInventarioMovimientoBO.destinoGravadoItem = obj.DestinoGravado
                objInventarioMovimientoBO.tipoOperacion = obj.tipoOperacion
                'cierre = cierreBL.RecuperarCierre(year, mes - 1, obj.idItem)
                objInventarioMovimientoBO.cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad)
                objInventarioMovimientoBO.unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad)
                objInventarioMovimientoBO.precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE)
                objInventarioMovimientoBO.monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto)
                objInventarioMovimientoBO.montoUSD = obj.CostoUS
                listaInventario.Add(objInventarioMovimientoBO)

                producto = obj.idItem
                productoCache = obj.nombreItem

            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetMovimientosKardexByExistencia(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento)
        Dim obj As New InventarioMovimiento
        Dim lista As New List(Of InventarioMovimiento)

        Dim consulta = (From t In HeliosData.InventarioMovimiento
                        Join art In HeliosData.detalleitems
                        On art.codigodetalle Equals t.idItem
                        Group Join lote In HeliosData.recursoCostoLote
                            On lote.codigoLote Equals t.nrolote
                            Into ov2 = Group
                        From x2 In ov2.DefaultIfEmpty()
                        Where
                            art.estado = "A" And
                            x2.productoSustentado = be.customLote.productoSustentado And
                             CLng(t.fecha.Value.Year) = be.fecha.Value.Year And
                            CLng(t.fecha.Value.Month) = be.fecha.Value.Month And
                            t.idAlmacen = be.idAlmacen And
                            t.tipoProducto = be.tipoProducto
                        Order By art.descripcionItem, t.nrolote, t.fecha Ascending
                        Select
                            x2.nroLote,
                            x2.codigoLote,
                            x2.fechaVcto,
                            x2.productoSustentado,
                            t.idInventario,
                            t.fecha,
                            t.idEmpresa,
                            t.idEstablecimiento,
                            t.idAlmacen,
                            t.tipoProducto,
                            t.idDocumento,
                            t.tipoRegistro,
                            t.serie,
                            t.numero,
                            t.tipoOperacion,
                            art.codigodetalle,
                            art.origenProducto,
                            t.descripcion,
                            art.descripcionItem,
                            art.unidad1,
                            t.cantidad,
                            t.monto,
                            DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                    Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                    Select New With
                                                            {
                                                            c.descripcion
                                                            }).FirstOrDefault().descripcion,
                            Valor_venta = (From c In HeliosData.documentoventaAbarrotesDet
                                           Where c.idDocumento = t.idDocumento And c.idItem = t.idItem And
                                               c.codigoLote = t.nrolote
                                           Select New With
                                                       {
                                                       c.montokardex
                                                       }).FirstOrDefault().montokardex).ToList


        For Each i In consulta
            obj = New InventarioMovimiento
            obj.customLote = New recursoCostoLote With
                {
                .codigoLote = i.codigoLote,
                .nroLote = i.nroLote,
                .fechaVcto = i.fechaVcto.GetValueOrDefault,
                .productoSustentado = i.productoSustentado
            }
            obj.idInventario = i.idInventario
            obj.ValorDeVenta = i.Valor_venta.GetValueOrDefault
            obj.fecha = i.fecha
            obj.idEmpresa = i.idEmpresa
            obj.idEstablecimiento = i.idEstablecimiento
            obj.idAlmacen = i.idAlmacen
            obj.tipoProducto = i.tipoProducto
            obj.idDocumento = i.idDocumento
            obj.tipoRegistro = i.tipoRegistro
            obj.serie = i.serie
            obj.numero = i.numero
            obj.DetalleTipoOperacion = i.DetalleTipoOperacion
            obj.tipoOperacion = i.tipoOperacion
            obj.idItem = i.codigodetalle
            obj.destinoGravadoItem = i.origenProducto
            obj.descripcion = i.descripcionItem
            obj.nombreItem = i.descripcionItem
            obj.unidad = i.unidad1
            obj.cantidad = i.cantidad
            obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
            obj.monto = i.monto
            obj.montoOther = 0 ' i.CierreImporteMesAnterior.GetValueOrDefault
            lista.Add(obj)
        Next
        Return lista
    End Function


#End Region

    Public Function GetMovimientosLote(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        GetMovimientosLote = New List(Of InventarioMovimiento)

        Dim con = HeliosData.InventarioMovimiento.Join(HeliosData.documento, Function(inv) inv.idDocumento, Function(doc) doc.idDocumento, Function(inv, doc) _
                  New With {
                  .inventario = inv,
                  .documento = doc
                  }).Join(HeliosData.almacen, Function(inv) inv.inventario.idAlmacen, Function(al) al.idAlmacen, Function(inv, al) _
                          New With {
                          .inventario = inv.inventario,
                          .documento = inv.documento,
                          .almacen = al
                          }) _
                  .Where(Function(o) o.inventario.fecha >= be.fecha And o.inventario.nrolote = be.nrolote).ToList

        For Each i In con
            GetMovimientosLote.Add(New InventarioMovimiento With {
                                   .idorigenDetalle = i.inventario.idorigenDetalle,
                                   .idDocumento = i.inventario.idDocumento,
                                   .tipoRegistro = i.inventario.tipoRegistro,
                                   .idInventario = i.inventario.idInventario,
                                   .fecha = i.inventario.fecha,
                                   .tipoOperacion = i.inventario.tipoOperacion,
                                   .tipoDocAlmacen = i.documento.tipoDoc,
                                   .numero = i.documento.nroDoc,
                                   .cantidad = i.inventario.cantidad,
                                   .idAlmacen = i.almacen.idAlmacen,
                                   .NombreAlmacen = i.almacen.descripcionAlmacen
                                   })
        Next



    End Function


    Public Function GetRentabilidad(be As InventarioMovimiento, fechaini As DateTime, fechafin As DateTime, tipo As String) As List(Of InventarioMovimiento)
        Dim obj As New InventarioMovimiento
        Dim lista As New List(Of InventarioMovimiento)
        Select Case tipo
            Case "Mes"
                Dim consulta = (From t In HeliosData.InventarioMovimiento
                                Join art In HeliosData.detalleitems
                                      On art.codigodetalle Equals t.idItem
                                Join Lote In HeliosData.recursoCostoLote
                                    On Lote.codigoLote Equals t.nrolote
                                Where
                                          CLng(t.fecha.Value.Year) = fechaini.Year And
                                          CLng(t.fecha.Value.Month) = fechaini.Month And
                                          t.idAlmacen = be.idAlmacen
                                Order By art.descripcionItem, t.tipoProducto, art.origenProducto, t.nrolote, t.fecha Ascending
                                Select
                                          t.idInventario,
                                    Lote.nroLote,
                                    Lote.codigoLote,
                                    Lote.fechaVcto,
                                    t.fecha,
                                    t.idEmpresa,
                                    t.idAlmacen,
                                    t.tipoProducto,
                                    t.idDocumento,
                                    t.tipoRegistro,
                                    t.serie,
                                    t.numero,
                                    t.tipoOperacion,
                                    art.codigodetalle,
                                    art.origenProducto,
                                    t.descripcion,
                                    art.descripcionItem,
                                    art.unidad1,
                                    t.cantidad,
                                    t.monto,
                                    DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                            Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                            Select New With
                                                            {
                                                            c.descripcion
                                                            }).FirstOrDefault().descripcion,
                            Valor_venta = (From c In HeliosData.documentoventaAbarrotesDet
                                           Where c.idDocumento = t.idDocumento And c.idItem = t.idItem And
                                               c.codigoLote = t.nrolote
                                           Select New With
                                                       {
                                                       c.montokardex
                                                       }).FirstOrDefault().montokardex).ToList


                'Dim listaVenta = consulta.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.VENTA).ToList
                For Each i In consulta
                    obj = New InventarioMovimiento
                    obj.customLote = New recursoCostoLote With
                        {
                        .codigoLote = i.codigoLote,
                        .nroLote = i.nroLote,
                        .fechaVcto = i.fechaVcto
                    }
                    obj.idInventario = i.idInventario
                    obj.ValorDeVenta = i.Valor_venta.GetValueOrDefault
                    'obj.NombreAlmacen = i.descripcionAlmacen
                    obj.fecha = i.fecha
                    obj.idEmpresa = i.idEmpresa
                    obj.idAlmacen = i.idAlmacen
                    obj.tipoProducto = i.tipoProducto
                    obj.idDocumento = i.idDocumento
                    obj.tipoRegistro = i.tipoRegistro
                    obj.serie = i.serie
                    obj.numero = i.numero
                    obj.tipoOperacion = i.tipoOperacion
                    obj.DetalleTipoOperacion = i.DetalleTipoOperacion
                    obj.idItem = i.codigodetalle
                    obj.destinoGravadoItem = i.origenProducto
                    obj.descripcion = i.descripcionItem
                    obj.nombreItem = i.descripcionItem
                    obj.unidad = i.unidad1
                    obj.cantidad = i.cantidad
                    obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
                    obj.monto = i.monto
                    obj.montoOther = 0 ' i.CierreImporteMesAnterior.GetValueOrDefault
                    lista.Add(obj)
                Next
            Case "Dia"

                Dim consulta = (From t In HeliosData.InventarioMovimiento
                                Join art In HeliosData.detalleitems
                                    On art.codigodetalle Equals t.idItem
                                Join Lote In HeliosData.recursoCostoLote
                                    On Lote.codigoLote Equals t.nrolote
                                Where
                                    CLng(t.fecha.Value.Year) = fechaini.Year And
                                    CLng(t.fecha.Value.Month) = fechaini.Month _
                                    And t.idAlmacen = be.idAlmacen
                                Order By art.descripcionItem, t.tipoProducto, art.origenProducto, t.nrolote, t.fecha Ascending
                                Select
                                    t.idInventario,
                                    Lote.nroLote,
                                    Lote.codigoLote,
                                    Lote.fechaVcto,
                                    t.fecha,
                                    t.idEmpresa,
                                    t.idAlmacen,
                                    t.tipoProducto,
                                    t.idDocumento,
                                    t.tipoRegistro,
                                    t.serie,
                                    t.numero,
                                    t.tipoOperacion,
                                    art.codigodetalle,
                                    art.origenProducto,
                                    t.descripcion,
                                    art.descripcionItem,
                                    art.unidad1,
                                    t.cantidad,
                                    t.monto,
                                    DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                            Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                            Select New With
                                                            {
                                                            c.descripcion
                                                            }).FirstOrDefault().descripcion,
                            Valor_venta = (From c In HeliosData.documentoventaAbarrotesDet
                                           Where c.idDocumento = t.idDocumento And c.idItem = t.idItem And
                                               c.codigoLote = t.nrolote
                                           Select New With
                                                       {
                                                       c.montokardex
                                                       }).FirstOrDefault().montokardex).ToList


                'Dim listaVenta = consulta.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.VENTA).ToList
                For Each i In consulta
                    obj = New InventarioMovimiento
                    obj.customLote = New recursoCostoLote With
                        {
                        .codigoLote = i.codigoLote,
                        .nroLote = i.nroLote,
                        .fechaVcto = i.fechaVcto
                    }
                    obj.idInventario = i.idInventario
                    obj.ValorDeVenta = i.Valor_venta.GetValueOrDefault
                    'obj.NombreAlmacen = i.descripcionAlmacen
                    obj.fecha = i.fecha
                    obj.idEmpresa = i.idEmpresa
                    obj.idAlmacen = i.idAlmacen
                    obj.tipoProducto = i.tipoProducto
                    obj.idDocumento = i.idDocumento
                    obj.tipoRegistro = i.tipoRegistro
                    obj.serie = i.serie
                    obj.numero = i.numero
                    obj.tipoOperacion = i.tipoOperacion
                    obj.DetalleTipoOperacion = i.DetalleTipoOperacion
                    obj.idItem = i.codigodetalle
                    obj.destinoGravadoItem = i.origenProducto
                    obj.descripcion = i.descripcionItem
                    obj.nombreItem = i.descripcionItem
                    obj.unidad = i.unidad1
                    obj.cantidad = i.cantidad
                    obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
                    obj.monto = i.monto
                    obj.montoOther = 0 ' i.CierreImporteMesAnterior.GetValueOrDefault
                    lista.Add(obj)
                Next
        End Select

        Return lista
    End Function

    Public Function GetListaInicioExistencia(fechaInicio As Date, idempresa As String, almacen As Integer) As List(Of InventarioMovimiento)
        Dim inv As New InventarioMovimiento
        Dim con = (From i In HeliosData.InventarioMovimiento
                   Join d In HeliosData.detalleitems On d.codigodetalle Equals i.idItem
                   Join det In HeliosData.documentoLibroDiarioDetalle
                       On det.idDocumento Equals i.idDocumento And det.idItem Equals i.idItem
                   Join documentoLibro In HeliosData.documentoLibroDiario On documentoLibro.idDocumento Equals det.idDocumento
                   Join lote In HeliosData.recursoCostoLote On lote.codigoLote Equals i.nrolote
                   Where i.fecha.Value.Year = fechaInicio.Year _
                       And i.fecha.Value.Month = fechaInicio.Month _
                       And i.idEmpresa = idempresa _
                       And i.idAlmacen = almacen _
                       And documentoLibro.tipoRegistro = "APT_EXT" _
                       And i.tipoOperacion = StatusTipoOperacion.SALDO_INICIAL_O_CIERRES).ToList

        GetListaInicioExistencia = New List(Of InventarioMovimiento)
        For Each i In con
            inv = New InventarioMovimiento
            inv.codigoBarra = i.d.codigo
            inv.idItem = i.d.codigodetalle
            inv.idInventario = i.i.idInventario
            inv.Secuencia = i.det.secuencia
            inv.descripcion = i.d.descripcionItem
            inv.unidad = i.d.unidad1
            inv.tipoExistencia = i.d.tipoExistencia
            inv.destinoGravadoItem = i.d.origenProducto
            inv.cantidad = i.i.cantidad
            inv.monto = i.i.monto
            inv.nrolote = i.i.nrolote
            GetListaInicioExistencia.Add(inv)
        Next
    End Function

#Region "Métodos de transito"

    Sub GetMasivo(compra As documentocompradetalle)

    End Sub

    Sub GetParcial(compra As documentocompradetalle)

    End Sub

    Sub GrabarArticulosEntransito(be As documento)
        Dim nuevoTA As New totalesAlmacen
        Dim documentoBL As New documentoBL
        Dim guiaBL As New documentoGuiaBL
        Dim obj As New InventarioMovimiento
        Dim InventarioBL As New InventarioMovimientoBL
        Dim t As New totalesAlmacen
        Dim totalesBL As New totalesAlmacenBL
        Dim detalleBE As New documentocompradetalle
        Dim saldo As Decimal = 0
        Dim asientoBL As New AsientoBL
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim cuentaMascara As New cuentaMascara
        Dim cuentaMascaraBL As New cuentaMascaraBL
        Try
            Using ts As New TransactionScope
                Dim codref = be.documentoGuia.documentoguiaDetalle(0).idDocumentoPadre
                guiaBL.InsertGuiaNuevo(be, codref)

                nAsiento = New asiento
                nAsiento.idDocumento = codref
                nAsiento.periodo = PeriodoGeneral
                nAsiento.idEmpresa = be.idEmpresa
                nAsiento.idCentroCostos = be.idCentroCosto
                nAsiento.idEntidad = Nothing
                nAsiento.nombreEntidad = Nothing
                nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
                nAsiento.fechaProceso = be.fechaProceso
                nAsiento.codigoLibro = "13"
                nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
                nAsiento.tipoAsiento = ASIENTO_CONTABLE.PRODUCTOS_EN_TRANSITO
                nAsiento.importeMN = be.documentoGuia.importeMN
                nAsiento.importeME = be.documentoGuia.importeME
                nAsiento.glosa = be.documentoGuia.glosa
                nAsiento.usuarioActualizacion = be.usuarioActualizacion
                nAsiento.fechaActualizacion = be.fechaActualizacion
                asientoBL.InsertDefault(nAsiento, codref)

                Dim codAsiento = nAsiento.idAsiento
                Dim codigoLotex As Integer = 0
                For Each i In be.InventarioMovimiento
                    Select Case i.tipoRegistro
                        Case Status.Entrada_almacen
                            Dim compraDet = (From n In HeliosData.documentocompradetalle
                                             Where n.secuencia = i.idorigenDetalle).FirstOrDefault

                            codigoLotex = compraDet.codigoLote
                            i.nrolote = codigoLotex

                            'If compraDet.ItemEntregadototal = "N" Then

                            'Else
                            '    Throw New Exception("Algunos artículos ya fueron procesados en en otro lugar." & vbCrLf &
                            '                         "Intente otra vez.")
                            'End If

                            Select Case be.TipoEnvio
                                Case "MASIVO"
                                    If compraDet.ItemEntregadototal = "N" Then

                                    Else
                                        Throw New Exception("Algunos artículos ya fueron procesados en en otro lugar." & vbCrLf &
                                                     "Intente otra vez.")
                                    End If

                                    '  compraDet.almacenRef = i.idAlmacen
                                    compraDet.ItemEntregadototal = "S"
                                    compraDet.usuarioModificacion = i.usuarioActualizacion
                                Case "PARCIAL"

                                    If Not IsNothing(compraDet) Then
                                        detalleBE = New documentocompradetalle
                                        detalleBE = InventarioBL.GetMovimientosBytem(compraDet.secuencia)
                                        '   detalleBE = InventarioBL.GetMovimientosBytemAlmacen(compraDet.secuencia, i.idAlmacen)

                                        'saldo = i.cantidad - detalleBE.monto1.GetValueOrDefault
                                        saldo = compraDet.monto1 - detalleBE.monto1.GetValueOrDefault


                                        '     compraDet.almacenRef = i.idAlmacen
                                        If saldo = 0 Then
                                            compraDet.ItemEntregadototal = "S"
                                            compraDet.usuarioModificacion = i.usuarioActualizacion
                                        Else
                                            compraDet.ItemEntregadototal = "N"
                                            compraDet.usuarioModificacion = i.usuarioActualizacion
                                        End If
                                    End If
                            End Select

                            'registro de los asientos contables
                            nMovimiento = New movimiento
                            nMovimiento.idAsiento = codAsiento
                            Select Case i.tipoProducto
                                Case "01"
                                    cuentaMascara = cuentaMascaraBL.UbicarCuentaXmoduloXitem(be.idEmpresa, "01", "ITEM", "ALM01.1")
                                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                                Case "03"
                                    cuentaMascara = cuentaMascaraBL.UbicarCuentaXmoduloXitem(be.idEmpresa, "03", "ITEM", "ALM03.1")
                                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                                Case "04"
                                    cuentaMascara = cuentaMascaraBL.UbicarCuentaXmoduloXitem(be.idEmpresa, "04", "ITEM", "ALM04.1")
                                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                                Case "05"
                                    cuentaMascara = cuentaMascaraBL.UbicarCuentaXmoduloXitem(be.idEmpresa, "05", "ITEM", "ALM05.1")
                                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                                Case "08"
                                    nMovimiento.cuenta = "33"
                            End Select
                            nMovimiento.descripcion = i.descripcion
                            nMovimiento.tipo = "D"
                            nMovimiento.monto = i.monto
                            nMovimiento.montoUSD = i.montoUSD
                            nMovimiento.usuarioActualizacion = i.usuarioActualizacion
                            nMovimiento.fechaActualizacion = i.fechaActualizacion
                            HeliosData.movimiento.Add(nMovimiento)

                            '----------------- haber----------------------------------------

                            nMovimiento = New movimiento
                            nMovimiento.idAsiento = codAsiento
                            Select Case i.tipoProducto
                                Case "01"
                                    cuentaMascara = cuentaMascaraBL.UbicarCuentaXmoduloXitem(be.idEmpresa, "01", "ITEM", "ALM01.2")
                                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                                Case "03"
                                    cuentaMascara = cuentaMascaraBL.UbicarCuentaXmoduloXitem(be.idEmpresa, "03", "ITEM", "ALM03.2")
                                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                                Case "04"
                                    cuentaMascara = cuentaMascaraBL.UbicarCuentaXmoduloXitem(be.idEmpresa, "04", "ITEM", "ALM04.2")
                                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                                Case "05"
                                    cuentaMascara = cuentaMascaraBL.UbicarCuentaXmoduloXitem(be.idEmpresa, "05", "ITEM", "ALM05.2")
                                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                                Case "08"
                                    nMovimiento.cuenta = "28"
                            End Select
                            nMovimiento.descripcion = i.descripcion
                            nMovimiento.tipo = "H"
                            nMovimiento.monto = i.monto
                            nMovimiento.montoUSD = i.montoUSD
                            nMovimiento.usuarioActualizacion = i.usuarioActualizacion
                            nMovimiento.fechaActualizacion = i.fechaActualizacion
                            HeliosData.movimiento.Add(nMovimiento)
                    End Select

                    obj = New InventarioMovimiento With
                          {
                              .idorigenDetalle = i.idorigenDetalle,
                              .nrolote = codigoLotex,
                              .idEmpresa = i.idEmpresa,
                              .idEstablecimiento = i.idEstablecimiento,
                              .idAlmacen = i.idAlmacen,
                              .tipoOperacion = i.tipoOperacion,
                              .tipoDocAlmacen = i.tipoDocAlmacen,
                              .serie = i.serie,
                              .numero = i.numero,
                              .idDocumento = i.idDocumento,
                              .idDocumentoRef = i.idDocumento,
                              .idItem = i.idItem,
                              .descripcion = i.descripcion,
                              .fecha = i.fecha,
                              .tipoRegistro = i.tipoRegistro,
                              .destinoGravadoItem = i.destinoGravadoItem,
                              .tipoProducto = i.tipoProducto,
                              .cantidad = i.cantidad,
                              .unidad = i.unidad,
                              .cantidad2 = 0,
                              .unidad2 = 0,
                              .precUnite = 0,
                              .precUniteUSD = 0,
                              .monto = i.monto,
                              .montoUSD = i.montoUSD,
                              .status = i.status,
                              .entragado = i.entragado,
                              .usuarioActualizacion = i.usuarioActualizacion,
                              .fechaActualizacion = i.fechaActualizacion
                              }
                    HeliosData.InventarioMovimiento.Add(obj)

                    'TotalesAmacen
                    Select Case i.TipoAlmacen
                        Case TipoAlmacen.transito

                        Case Else

                            Select Case be.TipoEnvio
                                Case "MASIVO"
                                    nuevoTA = New totalesAlmacen With
                                           {
                                               .idEmpresa = i.idEmpresa,
                                               .codigoLote = codigoLotex,
                                               .idEstablecimiento = i.idEstablecimiento,
                                               .idAlmacen = i.idAlmacen,
                                               .origenRecaudo = i.destinoGravadoItem,
                                               .tipoExistencia = i.tipoProducto,
                                               .idItem = i.idItem,
                                               .descripcion = i.descripcion,
                                               .idUnidad = i.unidad,
                                               .unidadMedida = i.unidad,
                                               .cantidad = i.cantidad,
                                               .importeSoles = i.monto,
                                               .importeDolares = i.montoUSD,
                                               .cantidadMaxima = 10000,
                                               .cantidadMinima = 10,
                                               .status = StatusArticulo.Activo,
                                               .usuarioActualizacion = i.usuarioActualizacion,
                                               .fechaActualizacion = i.fechaActualizacion}
                                    HeliosData.totalesAlmacen.Add(nuevoTA)

                                Case "PARCIAL"
                                    Dim TA = HeliosData.totalesAlmacen.Where(Function(o) o.idAlmacen = i.idAlmacen And o.idItem = i.idItem And o.codigoLote = codigoLotex).FirstOrDefault
                                    If TA Is Nothing Then
                                        nuevoTA = New totalesAlmacen With
                                           {
                                               .idEmpresa = i.idEmpresa,
                                               .codigoLote = codigoLotex,
                                               .idEstablecimiento = i.idEstablecimiento,
                                               .idAlmacen = i.idAlmacen,
                                               .origenRecaudo = i.destinoGravadoItem,
                                               .tipoExistencia = i.tipoProducto,
                                               .idItem = i.idItem,
                                               .descripcion = i.descripcion,
                                               .idUnidad = i.unidad,
                                               .unidadMedida = i.unidad,
                                               .cantidad = i.cantidad,
                                               .importeSoles = i.monto,
                                               .importeDolares = i.montoUSD,
                                               .cantidadMaxima = 10000,
                                               .cantidadMinima = 10,
                                               .status = StatusArticulo.Activo,
                                               .usuarioActualizacion = i.usuarioActualizacion,
                                               .fechaActualizacion = i.fechaActualizacion}
                                        HeliosData.totalesAlmacen.Add(nuevoTA)
                                    Else

                                    End If
                            End Select

                    End Select

                Next

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GrabarEnvioTransito(be As documento)
        Dim totalesBL As New totalesAlmacenBL
        Dim InventarioBL As New InventarioMovimientoBL
        Dim empresaCierreMensualBL As New empresaCierreMensualBL
        Dim cierreinventarioBL As New cierreinventarioBL
        Try

            Dim fechaActual = New Date(be.fechaProceso.Year, be.fechaProceso.Month, 1)
            Dim fechaAnterior = fechaActual.AddMonths(-1)

            'si es false es porque no esta dentro del inicio de operaciones
            Dim valor = empresaCierreMensualBL.GetValidaFechaInicioOperacion(be.idEmpresa, fechaActual, be.idCentroCosto)
            If valor = "False" Then
                If cierreinventarioBL.InventarioEstaCerradoV2(be.idEmpresa, fechaActual.Year, fechaActual.Month, be.idCentroCosto) Then
                    Throw New Exception("El período: " & MonthName(fechaActual.Month) & ", esta cerrado!")
                End If

                If empresaCierreMensualBL.EstadoMesCerrado(New empresaCierreMensual With
                                                {.idEmpresa = be.idEmpresa,
                                                .idCentroCosto = be.idCentroCosto,
                                                 .anio = fechaAnterior.Year,
                                                 .mes = fechaAnterior.Month}) = False Then
                    Throw New Exception("Debe cerrar el período anterior: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
                End If
            ElseIf valor = "True" Then
                Throw New Exception("No puede ingresar en un período anterior al inicio de operaciones")
            Else
                If cierreinventarioBL.InventarioEstaCerradoV2(be.idEmpresa, fechaActual.Year, fechaActual.Month, be.idCentroCosto) Then
                    Throw New Exception("El período: " & MonthName(fechaActual.Month) & ", esta cerrado!")
                End If

                'If empresaCierreMensualBL.EstadoMesCerrado(New empresaCierreMensual With
                '                                    {.idEmpresa = objDocumento.idEmpresa,
                '                                     .anio = fechaAnterior.Year,
                '                                     .mes = fechaAnterior.Month}) = False Then
                '    Throw New Exception("Debe cerrar el período anterior: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
                'End If
            End If

            Using ts As New TransactionScope
                GrabarArticulosEntransito(be)

                Select Case be.TipoEnvio
                    Case "MASIVO"

                    Case "PARCIAL"

                        Dim listaAlmacenes = be.InventarioMovimiento.Where(Function(o) o.TipoAlmacen = "AF").ToList
                        Dim lstAlmacenesDeSalida = (From destino In listaAlmacenes
                                                    Select New With {destino.idAlmacen, destino.tipoProducto, destino.idItem, destino.nrolote}).Distinct.ToList

                        'Dim lstAlmacenesDestino = (From envio In objDocumento.documentocompra.documentocompradetalle
                        '                           Select New With {envio.almacenDestino, envio.tipoExistencia, envio.idItem, envio.codigoLote}).Distinct.ToList



                        For Each a In lstAlmacenesDeSalida
                            Dim lista = InventarioBL.GetCuracionEntradasAlmacenByArticuloLote(New InventarioMovimiento With {.idAlmacen = a.idAlmacen,
                                                                                                                         .fecha = New DateTime(be.fechaProceso.Year, be.fechaProceso.Month, 1),
                                                                                                                         .tipoProducto = a.tipoProducto,
                                                                                                                         .idItem = a.idItem, .nrolote = a.nrolote}, Nothing)

                            totalesBL.GetCurarKardexCaberasLOTE(lista)
                        Next
                End Select
                'Dim listaAlmacenes = be.InventarioMovimiento.Where(Function(o) o.TipoAlmacen = "AF").ToList
                'For Each a In listaAlmacenes

                '    Dim listaAcurar = InventarioBL.GetCuracionEntradasAlmacenByArticulo(
                '                        New InventarioMovimiento With {.idAlmacen = a.idAlmacen,
                '                                                       .fecha = New DateTime(a.fecha.Value.Year, a.fecha.Value.Month, 1),
                '                                                       .tipoProducto = a.tipoProducto,
                '                                                       .idItem = a.idItem}, Nothing)
                '    totalesBL.GetCurarKardexCaberas(listaAcurar)

                'Next

                'Dim listaAlmacenesVirtual = be.InventarioMovimiento.Where(Function(o) o.TipoAlmacen = "AV").ToList
                'For Each a In listaAlmacenesVirtual

                '    Dim listaAcurar = InventarioBL.GetCuracionEntradasAlmacenByArticulo(
                '                        New InventarioMovimiento With {.idAlmacen = a.idAlmacen,
                '                                                       .fecha = New DateTime(a.fecha.Value.Year, a.fecha.Value.Month, 1),
                '                                                       .tipoProducto = a.tipoProducto,
                '                                                       .idItem = a.idItem}, Nothing)
                '    totalesBL.GetCurarKardexCaberas(listaAcurar)

                'Next

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetCountExistenciaTransito(be As documentocompra) As Integer
        Dim obj As New documentocompradetalle
        Dim lista As New List(Of documentocompradetalle)

        Dim tipoCompra As New List(Of String)
        tipoCompra.Add(TIPO_COMPRA.COMPRA)
        tipoCompra.Add(TIPO_COMPRA.NOTA_DE_COMPRA)
        tipoCompra.Add(TIPO_COMPRA.OTRAS_ENTRADAS)

        Dim consulta = (From inv In HeliosData.inventarioTransito
                        Join det In HeliosData.documentocompradetalle
                            On det.idDocumento Equals inv.idDocumentoCompra And det.secuencia Equals inv.secuencia
                        Join ent In HeliosData.entidad On ent.idEntidad Equals det.documentocompra.idProveedor
                        Join prod In HeliosData.detalleitems On prod.codigodetalle Equals det.idItem
                        Where
                            tipoCompra.Contains(det.documentocompra.tipoCompra) And
                            det.documentocompra.estadoPago <> "ANU" And
                             inv.idEstablecimiento = be.idCentroCosto And
                             inv.status = be.StatusEntregaProductosTransito).Count


        Return consulta
    End Function

    ''' <summary>
    ''' Verificar si un comprobante de compra tiene articulos en transito
    ''' </summary>
    ''' <param name="be"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTieneArticulosEnTransitoCompra(be As documentocompra) As Boolean
        Dim obj As New documentocompradetalle
        Dim lista As New List(Of documentocompradetalle)

        Dim consulta = (From p In HeliosData.documentocompradetalle _
                       Join doc In HeliosData.documentocompra _
                       On p.idDocumento Equals doc.idDocumento _
                       Where doc.idDocumento = be.idDocumento _
                       And p.ItemEntregadototal = "N").Count


        GetTieneArticulosEnTransitoCompra = False
        If consulta > 0 Then
            GetTieneArticulosEnTransitoCompra = True
        End If

        Return consulta
    End Function

    Public Function GetExistenciaTransito(be As documentocompra) As List(Of documentocompradetalle)
        Dim obj As New documentocompradetalle
        Dim lista As New List(Of documentocompradetalle)

        Dim consulta = (From det In HeliosData.documentocompradetalle _
                       Group Join guia In HeliosData.documentoguiaDetalle _
                       On New With {.IdDocumentoPadre = det.idDocumento, det.idItem} _
                       Equals New With {.IdDocumentoPadre = CInt(guia.idDocumentoPadre), guia.idItem} Into guia_join = Group _
                       From guia In guia_join.DefaultIfEmpty() _
                       Where _
                        CStr(det.ItemEntregadototal) = "N" And _
                        CLng(det.documentocompra.idCentroCosto) = be.idCentroCosto And _
                        det.documentocompra.tipoCompra = "CMP" _
                       Group New With {det.documentocompra, det, guia} By _
                       det.documentocompra.idDocumento, _
                       det.documentocompra.fechaDoc, _
                       det.documentocompra.tipoDoc, _
                       det.documentocompra.serie, _
                       det.documentocompra.numeroDoc, _
                       det.documentocompra.monedaDoc, _
                       det.documentocompra.tcDolLoc, _
                       det.documentocompra.idProveedor, _
                       det.secuencia, _
                       det.destino, _
                       det.tipoExistencia, _
                       det.idItem, _
                       det.descripcionItem, _
                       det.almacenRef, _
                       det.unidad1, _
                       det.monto1, _
                       det.montokardex, _
                       det.montokardexUS _
                       Into g = Group _
                        Select _
                        idDocumento, _
                        fechaDoc, _
                        secuencia, _
                        destino, _
                        tipoExistencia, _
                        idItem, _
                        descripcionItem, _
                        almacenRef, _
                        unidad1, _
                        monto1, _
                        tipoDoc, _
                        serie, _
                        numeroDoc, _
                        monedaDoc, _
                        tcDolLoc, _
                        idProveedor, _
                        montokardex, _
                        montokardexUS, _
                        canGuia = CType(g.Sum(Function(p) p.guia.cantidad), Decimal?), _
                        MontoMNGuia = CType(g.Sum(Function(p) p.guia.importeMN), Decimal?), _
                        MontoMEGuia = CType(g.Sum(Function(p) p.guia.importeME), Decimal?), _
                        Saldo = CType((monto1 - g.Sum(Function(p) p.guia.cantidad)), Decimal?)).ToList


        'Dim consulta = (From det In HeliosData.documentocompradetalle _
        '                Join doc In HeliosData.documentocompra On New With {det.idDocumento} Equals New With {doc.idDocumento} _
        '                Join per In HeliosData.entidad On New With {.IdPersona = CInt(doc.idProveedor)} Equals New With {.IdPersona = per.idEntidad} _
        '                Group Join guia In HeliosData.documentoguiaDetalle On guia.idDocumento Equals det.idDocumento And _
        '                 guia.idItem Equals det.idItem Into guia_join = Group
        '                From guia In guia_join.DefaultIfEmpty()
        '                Where
        '                CLng(doc.idCentroCosto) = be.idCentroCosto And
        '                doc.tipoCompra = be.tipoCompra And
        '                det.ItemEntregadototal = "N"
        '                Group New With {det, guia} By
        '                det.idDocumento,
        '                doc.fechaDoc,
        '                det.secuencia,
        '                det.destino,
        '                det.tipoExistencia,
        '                det.idItem,
        '                det.descripcionItem,
        '                det.almacenRef,
        '                det.unidad1,
        '                det.monto1,
        '                det.montokardex,
        '                det.montokardexUS,
        '                doc.tipoDoc,
        '                doc.serie,
        '                doc.numeroDoc,
        '                doc.monedaDoc,
        '                doc.tcDolLoc,
        '                doc.idProveedor,
        '                per.nombreCompleto
        '                Into g = Group
        '                Select
        '                idDocumento,
        '                fechaDoc,
        '                secuencia,
        '                destino,
        '                tipoExistencia,
        '                idItem,
        '                descripcionItem,
        '                almacenRef,
        '                unidad1,
        '                monto1,
        '                movCant = CType(g.Sum(Function(p) p.guia.cantidad), Decimal?),
        '                montokardex,
        '                movImporte = CType(g.Sum(Function(p) p.guia.importeMN), Decimal?),
        '                montokardexUS,
        '                movImporteUS = CType(g.Sum(Function(p) p.guia.importeME), Decimal?),
        '                tipoDoc,
        '                serie,
        '                numeroDoc,
        '                monedaDoc,
        '                tcDolLoc,
        '                idProveedor,
        '                nombreCompleto).ToList

        For Each i In consulta
            obj = New documentocompradetalle
            obj.idDocumento = i.idDocumento
            obj.FechaDoc = i.fechaDoc
            obj.secuencia = i.secuencia
            obj.destino = i.destino
            obj.tipoExistencia = i.tipoExistencia
            obj.idItem = i.idItem
            obj.descripcionItem = i.descripcionItem
            obj.almacenRef = i.almacenRef
            obj.unidad1 = i.unidad1

            obj.monto1 = i.monto1
            obj.GuiaCantidad = i.canGuia.GetValueOrDefault

            obj.montokardex = i.montokardex
            obj.GuiaMontoMN = i.MontoMNGuia.GetValueOrDefault

            obj.montokardexUS = i.montokardexUS
            obj.GuiaMontoME = i.MontoMEGuia.GetValueOrDefault

            obj.TipoDoc = i.tipoDoc
            obj.Serie = i.serie
            obj.NumDoc = i.numeroDoc
            obj.Moneda = i.monedaDoc
            obj.tipoCambio = i.tcDolLoc
            obj.idEntidad = i.idProveedor
            obj.NombreProveedor = String.Empty

            lista.Add(obj)
        Next
        Return lista
    End Function

    Public Function GetProveedoresEnTransito(be As documentocompra) As List(Of entidad)
        Dim obj As New entidad
        Dim lista As New List(Of entidad)

        Dim listaTipo As New List(Of String)

        listaTipo.Add(TIPO_COMPRA.NOTA_DE_COMPRA)
        listaTipo.Add("CMP")
        listaTipo.Add("CPG")

        Dim consulta = ((From det In HeliosData.documentocompradetalle
                         Where
                         CStr(det.ItemEntregadototal) = "N" And
                        listaTipo.Contains(det.documentocompra.tipoCompra) And
                         CLng(det.documentocompra.idCentroCosto) = be.idCentroCosto
                         Order By
                             det.documentocompra.entidad.nombreCompleto()
                         Select
                             IdProveedor = CType(det.documentocompra.idProveedor, Int32?),
                             det.documentocompra.entidad.nombreCompleto,
                             det.documentocompra.entidad.nrodoc) _
                     .Distinct()).ToList


        For Each i In consulta
            obj = New entidad
            obj.idEntidad = i.IdProveedor
            obj.nombreCompleto = i.nombreCompleto
            obj.nrodoc = i.nrodoc
            lista.Add(obj)
        Next
        Return lista
    End Function

    Public Function GetComprobantesEnTransito(be As documentocompra) As List(Of documentocompra)
        Dim obj As New documentocompra
        Dim lista As New List(Of documentocompra)

        Dim listaTipo As New List(Of String)

        listaTipo.Add("CMP")
        listaTipo.Add("CPG")

        'Select Case be.TipoExistencia
        '    Case "00" ' Todos
        Dim consulta = (From det In HeliosData.documentocompradetalle
                        Group Join guia In HeliosData.documentoguiaDetalle
                            On guia.idDocumentoPadre Equals det.idDocumento _
                            And guia.secuenciaRef Equals det.secuencia Into guia_join = Group
                        From guia In guia_join.DefaultIfEmpty()
                        Where
                            CStr(det.ItemEntregadototal) = "N" And
                            CLng(det.documentocompra.idCentroCosto) = be.idCentroCosto And
                            listaTipo.Contains(det.documentocompra.tipoCompra) And
                            det.documentocompra.idProveedor = be.idProveedor
                        Group New With {det.documentocompra, det, guia} By
                            det.documentocompra.idDocumento,
                            det.documentocompra.fechaDoc,
                            det.documentocompra.serie,
                            det.documentocompra.numeroDoc,
                            det.documentocompra.tipoDoc,
                            det.documentocompra.importeTotal
                            Into g = Group
                        Select
                            idDocumento,
                            serie,
                            numeroDoc,
                            tipoDoc,
                            fechaDoc,
                            importeTotal).Distinct().ToList

        For Each i In consulta
            obj = New documentocompra
            obj.idDocumento = i.idDocumento
            obj.fechaDoc = i.fechaDoc
            obj.numeroDoc = CInt(i.serie) & "-" & CInt(i.numeroDoc)
            obj.tipoDoc = i.tipoDoc
            obj.importeTotal = i.importeTotal
            lista.Add(obj)
        Next

        'Case Else

        'Dim consulta = (From det In HeliosData.documentocompradetalle _
        '      Group Join guia In HeliosData.documentoguiaDetalle _
        '      On guia.idDocumentoPadre Equals det.idDocumento _
        '      And guia.secuenciaRef Equals det.secuencia Into guia_join = Group _
        '      From guia In guia_join.DefaultIfEmpty() _
        '      Where _
        '       CStr(det.ItemEntregadototal) = "N" And _
        '       CStr(det.tipoExistencia) = be.TipoExistencia And _
        '       CLng(det.documentocompra.idCentroCosto) = be.idCentroCosto And _
        '       det.documentocompra.tipoCompra = "CMP" And _
        '       det.documentocompra.idProveedor = be.idProveedor _
        '      Group New With {det.documentocompra, det, guia} By _
        '      det.documentocompra.idDocumento, _
        '      det.documentocompra.serie, _
        '      det.documentocompra.numeroDoc _
        '      Into g = Group _
        '       Select _
        '       idDocumento, _
        '       serie, _
        '       numeroDoc).Distinct().ToList


        'For Each i In consulta
        '    obj = New documentocompra
        '    obj.idDocumento = i.idDocumento
        '    obj.numeroDoc = CInt(i.serie) & "-" & CInt(i.numeroDoc)
        '    lista.Add(obj)
        'Next
        'End Select

        Return lista
    End Function

    Public Function GetExistenciaTransitoByProveedor(be As documentocompra) As List(Of documentocompradetalle)
        Dim obj As New documentocompradetalle
        Dim lista As New List(Of documentocompradetalle)
        Dim listaTipo As New List(Of String)

        listaTipo.Add(TIPO_COMPRA.NOTA_DE_COMPRA)
        listaTipo.Add("CMP")
        listaTipo.Add("CPG")

        Select Case be.TipoExistencia
            Case "00" ' Todos
                Dim consulta = (From det In HeliosData.documentocompradetalle
                                Group Join guia In HeliosData.documentoguiaDetalle
                                    On guia.idDocumentoPadre Equals det.idDocumento _
                                    And guia.secuenciaRef Equals det.secuencia Into guia_join = Group
                                From guia In guia_join.DefaultIfEmpty()
                                Where
                                    CStr(det.ItemEntregadototal) = "N" And
                                    CLng(det.documentocompra.idCentroCosto) = be.idCentroCosto And
                                    listaTipo.Contains(det.documentocompra.tipoCompra) And
                                    det.documentocompra.idProveedor = be.idProveedor
                                Group New With {det.documentocompra, det, guia} By
                                    det.documentocompra.idDocumento,
                                    det.documentocompra.fechaDoc,
                                    det.documentocompra.tipoDoc,
                                    det.documentocompra.serie,
                                    det.documentocompra.numeroDoc,
                                    det.documentocompra.monedaDoc,
                                    det.documentocompra.tcDolLoc,
                                    det.documentocompra.idProveedor,
                                    det.secuencia,
                                    det.destino,
                                    det.tipoExistencia,
                                    det.idItem,
                                    det.descripcionItem,
                                    det.almacenRef,
                                    det.unidad1,
                                    det.monto1,
                                    det.montokardex,
                                    det.montokardexUS,
                                    det.importe,
                                    det.importeUS
                                    Into g = Group
                                Select
                                    idDocumento,
                                    fechaDoc,
                                    secuencia,
                                    destino,
                                    tipoExistencia,
                                    idItem,
                                    descripcionItem,
                       almacenRef,
                       unidad1,
                       monto1,
                       tipoDoc,
                       serie,
                       numeroDoc,
                       monedaDoc,
                       tcDolLoc,
                       idProveedor,
                       montokardex,
                       montokardexUS,
                                    importe,
                                    importeUS,
                       canGuia = CType(g.Sum(Function(p) p.guia.cantidad), Decimal?),
                       MontoMNGuia = CType(g.Sum(Function(p) p.guia.importeMN), Decimal?),
                       MontoMEGuia = CType(g.Sum(Function(p) p.guia.importeME), Decimal?),
                       Saldo = CType((monto1 - g.Sum(Function(p) p.guia.cantidad)), Decimal?)).ToList

                For Each i In consulta
                    obj = New documentocompradetalle
                    obj.idDocumento = i.idDocumento
                    obj.FechaDoc = i.fechaDoc
                    obj.secuencia = i.secuencia
                    obj.destino = i.destino
                    obj.tipoExistencia = i.tipoExistencia
                    obj.idItem = i.idItem
                    obj.descripcionItem = i.descripcionItem
                    obj.almacenRef = i.almacenRef
                    obj.unidad1 = i.unidad1

                    obj.monto1 = i.monto1
                    obj.GuiaCantidad = i.canGuia.GetValueOrDefault

                    obj.importe = i.importe
                    obj.montokardex = i.montokardex
                    obj.GuiaMontoMN = i.MontoMNGuia.GetValueOrDefault

                    obj.importeUS = i.importeUS
                    obj.montokardexUS = i.montokardexUS
                    obj.GuiaMontoME = i.MontoMEGuia.GetValueOrDefault

                    obj.TipoDoc = i.tipoDoc
                    obj.Serie = i.serie
                    obj.NumDoc = i.numeroDoc
                    obj.Moneda = i.monedaDoc
                    obj.tipoCambio = i.tcDolLoc
                    obj.idEntidad = i.idProveedor
                    obj.NombreProveedor = String.Empty

                    lista.Add(obj)
                Next

            Case Else

                Dim consulta = (From det In HeliosData.documentocompradetalle
                                Group Join guia In HeliosData.documentoguiaDetalle
                      On guia.idDocumentoPadre Equals det.idDocumento _
                      And guia.secuenciaRef Equals det.secuencia Into guia_join = Group
                                From guia In guia_join.DefaultIfEmpty()
                                Where
                       CStr(det.ItemEntregadototal) = "N" And
                       CStr(det.tipoExistencia) = be.TipoExistencia And
                       CLng(det.documentocompra.idCentroCosto) = be.idCentroCosto And
                        listaTipo.Contains(det.documentocompra.tipoCompra) And
                       det.documentocompra.idProveedor = be.idProveedor
                                Group New With {det.documentocompra, det, guia} By
                      det.documentocompra.idDocumento,
                      det.documentocompra.fechaDoc,
                      det.documentocompra.tipoDoc,
                      det.documentocompra.serie,
                      det.documentocompra.numeroDoc,
                      det.documentocompra.monedaDoc,
                      det.documentocompra.tcDolLoc,
                      det.documentocompra.idProveedor,
                      det.secuencia,
                      det.destino,
                      det.tipoExistencia,
                      det.idItem,
                      det.descripcionItem,
                      det.almacenRef,
                      det.unidad1,
                      det.monto1,
                      det.montokardex,
                      det.montokardexUS
                      Into g = Group
                                Select
                       idDocumento,
                       fechaDoc,
                       secuencia,
                       destino,
                       tipoExistencia,
                       idItem,
                       descripcionItem,
                       almacenRef,
                       unidad1,
                       monto1,
                       tipoDoc,
                       serie,
                       numeroDoc,
                       monedaDoc,
                       tcDolLoc,
                       idProveedor,
                       montokardex,
                       montokardexUS,
                       canGuia = CType(g.Sum(Function(p) p.guia.cantidad), Decimal?),
                       MontoMNGuia = CType(g.Sum(Function(p) p.guia.importeMN), Decimal?),
                       MontoMEGuia = CType(g.Sum(Function(p) p.guia.importeME), Decimal?),
                       Saldo = CType((monto1 - g.Sum(Function(p) p.guia.cantidad)), Decimal?)).ToList




                For Each i In consulta
                    obj = New documentocompradetalle
                    obj.idDocumento = i.idDocumento
                    obj.FechaDoc = i.fechaDoc
                    obj.secuencia = i.secuencia
                    obj.destino = i.destino
                    obj.tipoExistencia = i.tipoExistencia
                    obj.idItem = i.idItem
                    obj.descripcionItem = i.descripcionItem
                    obj.almacenRef = i.almacenRef
                    obj.unidad1 = i.unidad1

                    obj.monto1 = i.monto1
                    obj.GuiaCantidad = i.canGuia.GetValueOrDefault

                    obj.montokardex = i.montokardex
                    obj.GuiaMontoMN = i.MontoMNGuia.GetValueOrDefault

                    obj.montokardexUS = i.montokardexUS
                    obj.GuiaMontoME = i.MontoMEGuia.GetValueOrDefault

                    obj.TipoDoc = i.tipoDoc
                    obj.Serie = i.serie
                    obj.NumDoc = i.numeroDoc
                    obj.Moneda = i.monedaDoc
                    obj.tipoCambio = i.tcDolLoc
                    obj.idEntidad = i.idProveedor
                    obj.NombreProveedor = String.Empty

                    lista.Add(obj)
                Next
        End Select

        Return lista
    End Function

    Public Function GetExistenciaTransitoByCompra(be As documentocompra) As List(Of documentocompradetalle)
        Dim obj As New documentocompradetalle
        Dim lista As New List(Of documentocompradetalle)

        Select Case be.TipoExistencia
            Case "00" ' Todos
                Dim consulta = (From det In HeliosData.documentocompradetalle
                                Group Join guia In HeliosData.documentoguiaDetalle
                                    On guia.idDocumentoPadre Equals det.idDocumento _
                                    And guia.secuenciaRef Equals det.secuencia Into guia_join = Group
                                From guia In guia_join.DefaultIfEmpty()
                                Where det.documentocompra.idDocumento = be.idDocumento _
                                    And CStr(det.ItemEntregadototal) = "N"
                                Group New With {det.documentocompra, det, guia} By
                      det.documentocompra.idDocumento,
                      det.documentocompra.fechaDoc,
                      det.documentocompra.tipoDoc,
                      det.documentocompra.serie,
                      det.documentocompra.numeroDoc,
                      det.documentocompra.monedaDoc,
                      det.documentocompra.tcDolLoc,
                      det.documentocompra.idProveedor,
                      det.secuencia,
                      det.destino,
                      det.tipoExistencia,
                      det.idItem,
                      det.descripcionItem,
                      det.almacenRef,
                      det.unidad1,
                      det.monto1,
                      det.montokardex,
                      det.montokardexUS
                      Into g = Group
                                Select
                       idDocumento,
                       fechaDoc,
                       secuencia,
                       destino,
                       tipoExistencia,
                       idItem,
                       descripcionItem,
                       almacenRef,
                       unidad1,
                       monto1,
                       tipoDoc,
                       serie,
                       numeroDoc,
                       monedaDoc,
                       tcDolLoc,
                       idProveedor,
                       montokardex,
                       montokardexUS,
                       canGuia = CType(g.Sum(Function(p) p.guia.cantidad), Decimal?),
                       MontoMNGuia = CType(g.Sum(Function(p) p.guia.importeMN), Decimal?),
                       MontoMEGuia = CType(g.Sum(Function(p) p.guia.importeME), Decimal?),
                       Saldo = CType((monto1 - g.Sum(Function(p) p.guia.cantidad)), Decimal?)).ToList

                For Each i In consulta
                    obj = New documentocompradetalle
                    obj.idDocumento = i.idDocumento
                    obj.FechaDoc = i.fechaDoc
                    obj.secuencia = i.secuencia
                    obj.destino = i.destino
                    obj.tipoExistencia = i.tipoExistencia
                    obj.idItem = i.idItem
                    obj.descripcionItem = i.descripcionItem
                    obj.almacenRef = i.almacenRef
                    obj.unidad1 = i.unidad1

                    obj.monto1 = i.monto1
                    obj.GuiaCantidad = i.canGuia.GetValueOrDefault

                    obj.montokardex = i.montokardex
                    obj.GuiaMontoMN = i.MontoMNGuia.GetValueOrDefault

                    obj.montokardexUS = i.montokardexUS
                    obj.GuiaMontoME = i.MontoMEGuia.GetValueOrDefault

                    obj.TipoDoc = i.tipoDoc
                    obj.Serie = i.serie
                    obj.NumDoc = i.numeroDoc
                    obj.Moneda = i.monedaDoc
                    obj.tipoCambio = i.tcDolLoc
                    obj.idEntidad = i.idProveedor
                    obj.NombreProveedor = String.Empty

                    lista.Add(obj)
                Next

            Case Else

                Dim consulta = (From det In HeliosData.documentocompradetalle
                                Group Join guia In HeliosData.documentoguiaDetalle
                      On guia.idDocumentoPadre Equals det.idDocumento _
                      And guia.secuenciaRef Equals det.secuencia Into guia_join = Group
                                From guia In guia_join.DefaultIfEmpty()
                                Where
                                det.documentocompra.idDocumento = be.idDocumento _
                                And CStr(det.ItemEntregadototal) = "N"
                                Group New With {det.documentocompra, det, guia} By
                      det.documentocompra.idDocumento,
                      det.documentocompra.fechaDoc,
                      det.documentocompra.tipoDoc,
                      det.documentocompra.serie,
                      det.documentocompra.numeroDoc,
                      det.documentocompra.monedaDoc,
                      det.documentocompra.tcDolLoc,
                      det.documentocompra.idProveedor,
                      det.secuencia,
                      det.destino,
                      det.tipoExistencia,
                      det.idItem,
                      det.descripcionItem,
                      det.almacenRef,
                      det.unidad1,
                      det.monto1,
                      det.montokardex,
                      det.montokardexUS
                      Into g = Group
                                Select
                       idDocumento,
                       fechaDoc,
                       secuencia,
                       destino,
                       tipoExistencia,
                       idItem,
                       descripcionItem,
                       almacenRef,
                       unidad1,
                       monto1,
                       tipoDoc,
                       serie,
                       numeroDoc,
                       monedaDoc,
                       tcDolLoc,
                       idProveedor,
                       montokardex,
                       montokardexUS,
                       canGuia = CType(g.Sum(Function(p) p.guia.cantidad), Decimal?),
                       MontoMNGuia = CType(g.Sum(Function(p) p.guia.importeMN), Decimal?),
                       MontoMEGuia = CType(g.Sum(Function(p) p.guia.importeME), Decimal?),
                       Saldo = CType((monto1 - g.Sum(Function(p) p.guia.cantidad)), Decimal?)).ToList




                For Each i In consulta
                    obj = New documentocompradetalle
                    obj.idDocumento = i.idDocumento
                    obj.FechaDoc = i.fechaDoc
                    obj.secuencia = i.secuencia
                    obj.destino = i.destino
                    obj.tipoExistencia = i.tipoExistencia
                    obj.idItem = i.idItem
                    obj.descripcionItem = i.descripcionItem
                    obj.almacenRef = i.almacenRef
                    obj.unidad1 = i.unidad1

                    obj.monto1 = i.monto1
                    obj.GuiaCantidad = i.canGuia.GetValueOrDefault

                    obj.montokardex = i.montokardex
                    obj.GuiaMontoMN = i.MontoMNGuia.GetValueOrDefault

                    obj.montokardexUS = i.montokardexUS
                    obj.GuiaMontoME = i.MontoMEGuia.GetValueOrDefault

                    obj.TipoDoc = i.tipoDoc
                    obj.Serie = i.serie
                    obj.NumDoc = i.numeroDoc
                    obj.Moneda = i.monedaDoc
                    obj.tipoCambio = i.tcDolLoc
                    obj.idEntidad = i.idProveedor
                    obj.NombreProveedor = String.Empty

                    lista.Add(obj)
                Next
        End Select

        Return lista
    End Function

    Public Function GetMovimientosBytem(intSecuencia As Integer) As documentocompradetalle
        Dim obj As New documentocompradetalle
        Dim lista As New List(Of documentocompradetalle)

        Dim consulta = Aggregate det In HeliosData.documentocompradetalle
                        Join guia In HeliosData.documentoguiaDetalle On det.idDocumento Equals guia.idDocumentoPadre _
                        And det.idItem Equals guia.idItem
                        Where det.secuencia = intSecuencia
                        Into CantidadMov = Sum(guia.cantidad),
                        sumaMN = Sum(guia.importeMN)


        obj = New documentocompradetalle
        obj.monto1 = consulta.CantidadMov

        Return obj
    End Function

    Public Function GetMovimientosBytemAlmacen(intSecuencia As Integer, idalmacen As Integer) As documentocompradetalle
        Dim obj As New documentocompradetalle
        Dim lista As New List(Of documentocompradetalle)

        Dim consulta = Aggregate det In HeliosData.documentocompradetalle
                        Join guia In HeliosData.documentoguiaDetalle On det.idDocumento Equals guia.idDocumentoPadre _
                        And det.idItem Equals guia.idItem
                        Where det.secuencia = intSecuencia And
                            guia.almacenRef = idalmacen
                        Into CantidadMov = Sum(guia.cantidad),
                        sumaMN = Sum(guia.importeMN)


        obj = New documentocompradetalle
        obj.monto1 = consulta.CantidadMov

        Return obj
    End Function

    Public Function ObtenerProductosEnTransito(ByVal strIdEmpresa As String, ByVal strIdEstablecimiento As String, ByVal strTipoAlmacen As String, ByVal Mes As String, ByVal Anio As String, ByVal strTipoProducto As String) As List(Of InventarioMovimiento)
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim tablaSA As New tabladetalleBL

        Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                          Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                          Join a In HeliosData.almacen On p.idAlmacen Equals a.idAlmacen
                          Join dc In HeliosData.documentocompra On p.idDocumento Equals dc.idDocumento _
                          Join pr In HeliosData.Persona On dc.idProveedor Equals pr.idPersona _
                          Where p.idEmpresa = strIdEmpresa And p.idEstablecimiento = strIdEstablecimiento And p.status = "D" _
                          And a.tipo = strTipoAlmacen _
                          And p.tipoProducto = strTipoProducto).ToList


        For Each obj In inventarios

            objInventarioMovimientoBO = New InventarioMovimiento()

            objInventarioMovimientoBO.idInventario = obj.p.idInventario
            objInventarioMovimientoBO.destinoGravadoItem = IIf(IsDBNull(obj.p.destinoGravadoItem), Nothing, obj.p.destinoGravadoItem)
            objInventarioMovimientoBO.tipoProducto = IIf(IsDBNull(obj.p.tipoProducto), Nothing, obj.p.tipoProducto)
            objInventarioMovimientoBO.idAlmacen = IIf(IsDBNull(obj.p.idAlmacen), Nothing, obj.p.idAlmacen)
            objInventarioMovimientoBO.NombreAlmacen = IIf(IsDBNull(obj.a.descripcionAlmacen), Nothing, obj.a.descripcionAlmacen)
            objInventarioMovimientoBO.idDocumento = IIf(IsDBNull(obj.p.idDocumento), Nothing, obj.p.idDocumento)
            objInventarioMovimientoBO.idDocumentoRef = IIf(IsDBNull(obj.p.idDocumentoRef), Nothing, obj.p.idDocumentoRef)
            objInventarioMovimientoBO.idItem = IIf(IsDBNull(obj.p.idItem), Nothing, obj.p.idItem)
            objInventarioMovimientoBO.descripcion = IIf(IsDBNull(obj.q.descripcionItem), Nothing, obj.q.descripcionItem)
            objInventarioMovimientoBO.precUnite = IIf(IsDBNull(obj.p.precUnite), Nothing, obj.p.precUnite)
            objInventarioMovimientoBO.cantidad = IIf(IsDBNull(obj.p.cantidad), Nothing, obj.p.cantidad)
            objInventarioMovimientoBO.unidad = IIf(IsDBNull(obj.p.unidad), Nothing, obj.p.unidad)
            objInventarioMovimientoBO.monto = IIf(IsDBNull(obj.p.monto), Nothing, obj.p.monto)
            objInventarioMovimientoBO.montoUSD = IIf(IsDBNull(obj.p.montoUSD), Nothing, obj.p.montoUSD)
            objInventarioMovimientoBO.cuentaOrigen = IIf(IsDBNull(obj.p.cuentaOrigen), Nothing, obj.p.cuentaOrigen)
            objInventarioMovimientoBO.fecha = IIf(IsDBNull(obj.p.fecha), Nothing, obj.p.fecha)
            objInventarioMovimientoBO.ComprobanteCompra = IIf(IsDBNull(obj.dc.tipoDoc), Nothing, obj.dc.tipoDoc)
            objInventarioMovimientoBO.NumDocCompra = IIf(IsDBNull(obj.dc.serie & "-" & obj.dc.numeroDoc), Nothing, obj.dc.serie & "-" & obj.dc.numeroDoc)
            objInventarioMovimientoBO.TipoCambio = IIf(IsDBNull(obj.dc.tcDolLoc), Nothing, obj.dc.tcDolLoc)
            objInventarioMovimientoBO.precUniteUSD = IIf(IsDBNull(obj.p.precUniteUSD), Nothing, obj.p.precUniteUSD)
            objInventarioMovimientoBO.preEvento = IIf(IsDBNull(obj.p.preEvento), Nothing, obj.p.preEvento)
            objInventarioMovimientoBO.glosa = IIf(IsDBNull(obj.p.descripcion), "s/c", obj.p.descripcion)
            objInventarioMovimientoBO.fechavcto = IIf(IsDBNull(obj.p.fechavcto), Nothing, obj.p.fechavcto)
            objInventarioMovimientoBO.presentacion = IIf(IsDBNull(obj.p.presentacion), Nothing, obj.p.presentacion)
            objInventarioMovimientoBO.IdProveedor = IIf(IsDBNull(obj.dc.idProveedor), Nothing, obj.dc.idProveedor)
            objInventarioMovimientoBO.nombreProveedor = IIf(IsDBNull(obj.pr.nombreCompleto), Nothing, obj.pr.nombreCompleto)
            If IsNothing(obj.p.presentacion) Then
                'objInventarioMovimientoBO.NombrePresentacion = Nothing
            Else
                'objInventarioMovimientoBO.NombrePresentacion = tablaSA.GetUbicarTablaID(21, obj.p.presentacion).descripcion
            End If
            objInventarioMovimientoBO.Secuencia = obj.p.idorigenDetalle
            listaInventario.Add(objInventarioMovimientoBO)
        Next

        Return listaInventario

    End Function
#End Region

#Region "Reporte Para Cierre"
    Dim Inv As New InventarioMovimiento
    Dim lista As New List(Of InventarioMovimiento)

    Public Function ListadoCierreInvPorPeriodo2(inventarioMov As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim meses As New List(Of Integer)
        meses.Add(inventarioMov.fecha.Value.Month - 1)
        meses.Add(inventarioMov.fecha.Value.Month)

        Dim consulta = (From tot In HeliosData.totalesAlmacen _
                       Join inv In HeliosData.InventarioMovimiento _
                       On tot.idItem Equals inv.idItem _
                       Join alm In HeliosData.almacen _
                       On alm.idAlmacen Equals tot.idAlmacen _
                       Where tot.idEmpresa = inventarioMov.idEmpresa And alm.tipo <> "AV" _
                       And inv.fecha.Value.Year = inventarioMov.fecha.Value.Year _
                       And meses.Contains(inv.fecha.Value.Month) _
                       Group inv By tot.idItem, tot.descripcion, alm.idAlmacen, alm.descripcionAlmacen,
                       tot.tipoExistencia, tot.idUnidad, tot.origenRecaudo _
                       Into g = Group _
                         Select New With {.idAlmacen = idAlmacen,
                                        .NomAlmacen = descripcionAlmacen,
                                        .idItem = idItem,
                                        .NomItem = descripcion,
                                        .tipoExistencia = tipoExistencia,
                                        .UM = idUnidad,
                                        .origenProducto = origenRecaudo,
                                        g, .SumaCantidad = g.Sum(Function(o) o.cantidad),
                                        .SumaMN = g.Sum(Function(o) o.monto),
                                        .SumaME = g.Sum(Function(o) o.montoUSD)}).ToList

        For Each i In consulta
            Inv = New InventarioMovimiento
            Inv.idAlmacen = i.idAlmacen
            Inv.NombreAlmacen = i.NomAlmacen
            Inv.idItem = i.idItem
            Inv.descripcion = i.NomItem
            Inv.tipoExistencia = i.tipoExistencia
            Inv.unidad = i.UM
            Inv.destinoGravadoItem = i.origenProducto
            Inv.cantidad = i.SumaCantidad.GetValueOrDefault
            Inv.monto = i.SumaMN.GetValueOrDefault
            Inv.montoUSD = i.SumaME.GetValueOrDefault
            lista.Add(Inv)
        Next

        Return lista

    End Function

    Public Function MostrarCierreInvPorPeriodo(inventarioMov As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim Inv As New InventarioMovimiento
        Dim lista As New List(Of InventarioMovimiento)
        'Dim meses As New List(Of Integer)

        'meses.Add(inventarioMov.fecha.Value.Month - 1)
        'meses.Add(inventarioMov.fecha.Value.Month)


        Dim consulta = (From n In HeliosData.InventarioMovimiento _
                       Join alm In HeliosData.almacen _
                       On n.idAlmacen Equals alm.idAlmacen _
                       Join prod In HeliosData.detalleitems _
                       On prod.codigodetalle Equals n.idItem _
                       Where n.idEmpresa = inventarioMov.idEmpresa And alm.tipo <> "AV" _
                       And n.fecha.Value.Year = inventarioMov.fecha.Value.Year _
                       And n.fecha.Value.Month = inventarioMov.fecha.Value.Month _
                       Group n By alm.idAlmacen, alm.descripcionAlmacen, prod.codigodetalle, prod.descripcionItem,
                       prod.tipoExistencia, prod.unidad1, prod.presentacion, prod.origenProducto _
                       Into g = Group _
                       Select New With {.idAlmacen = idAlmacen,
                                        .NomAlmacen = descripcionAlmacen,
                                        .idItem = codigodetalle,
                                        .NomItem = descripcionItem,
                                        .tipoExistencia = tipoExistencia,
                                        .UM = unidad1,
                                        .Presentacion = presentacion,
                                        .origenProducto = origenProducto,
                                        g, .SumaCantidad = g.Sum(Function(o) o.cantidad),
                                        .SumaMN = g.Sum(Function(o) o.monto),
                                        .SumaME = g.Sum(Function(o) o.montoUSD)}).ToList


        For Each i In consulta
            Inv = New InventarioMovimiento
            Inv.idAlmacen = i.idAlmacen
            Inv.NombreAlmacen = i.NomAlmacen
            Inv.idItem = i.idItem
            Inv.descripcion = i.NomItem
            Inv.tipoExistencia = i.tipoExistencia
            Inv.unidad = i.UM
            Inv.presentacion = i.Presentacion
            Inv.destinoGravadoItem = i.origenProducto
            Inv.cantidad = i.SumaCantidad.GetValueOrDefault
            Inv.monto = i.SumaMN.GetValueOrDefault
            Inv.montoUSD = i.SumaME.GetValueOrDefault
            lista.Add(Inv)
        Next

        Return lista

    End Function
#End Region


#Region "marca"
    Public Function ObtenerMarcaPorAlmacenesPorAnio(ByVal idAlmacen As String, ByVal marca As String, ByVal Anio As Integer) As List(Of InventarioMovimiento)
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Try
            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Join m In HeliosData.tabladetalle On m.codigoDetalle Equals p.marca _
                                   Where p.idAlmacen = idAlmacen _
                                   And m.codigoDetalle = marca _
                                   And m.idtabla = CInt(503) _
                                   And p.fecha.Value.Year = Anio _
                                   Order By p.fecha _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = q.descripcionItem, _
                                            .cantidad = p.cantidad, _
                                            .unidad = p.unidad, _
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = doc.nroDoc, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .marca = p.marca, _
                                            .tipoOperacion = p.tipoOperacion _
                                           } _
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento With _
                                            {.idInventario = obj.idInventario, _
                                             .fecha = obj.Fecha, _
                                             .idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa), _
                                             .idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen), _
                                             .idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem), _
                                             .nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem), _
                                             .cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad), _
                                             .unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad), _
                                             .precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE), _
                                             .monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto), _
                                             .disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible), _
                                             .status = IIf(IsDBNull(obj.estado), Nothing, obj.estado), _
                                             .tipoRegistro = obj.TipoRegistro.ToString, _
                                             .glosa = obj.Glosa, _
                                             .NumDocCompra = obj.NroDoc, _
                                             .cuentaOrigen = obj.Cuenta, _
                                             .idDocumento = obj.IdDocumento, _
                                             .tipoProducto = obj.TipoProducto, _
                                             .destinoGravadoItem = obj.DestinoGravado, _
                                             .montoUSD = obj.CostoUS, _
                                             .marca = obj.marca, _
                                             .tipoOperacion = obj.tipoOperacion _
                                             }
                listaInventario.Add(objInventarioMovimientoBO)
            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function ObtenerMarcaPorAlmacenes(ByVal idAlmacen As String, ByVal marca As String) As List(Of InventarioMovimiento)
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Try
            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Join m In HeliosData.tabladetalle On m.codigoDetalle Equals p.marca _
                                   Where p.idAlmacen = idAlmacen _
                                   And m.codigoDetalle = marca _
                                   And m.idtabla = CInt(503) _
                                   And p.fecha.Value.Day = CDate(DateTime.Now).Day _
                                   And p.fecha.Value.Month = CDate(DateTime.Now).Month _
                                   And p.fecha.Value.Year = CDate(DateTime.Now).Year
                                   Order By p.fecha _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = q.descripcionItem, _
                                            .cantidad = p.cantidad, _
                                            .unidad = p.unidad, _
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = doc.nroDoc, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .marca = p.marca, _
                                            .CostoUS = p.montoUSD _
                                           } _
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento With _
                                            {.idInventario = obj.idInventario, _
                                             .fecha = obj.Fecha, _
                                             .idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa), _
                                             .idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen), _
                                             .idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem), _
                                             .nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem), _
                                             .cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad), _
                                             .unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad), _
                                             .precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE), _
                                             .monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto), _
                                             .disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible), _
                                             .status = IIf(IsDBNull(obj.estado), Nothing, obj.estado), _
                                             .tipoRegistro = obj.TipoRegistro.ToString, _
                                             .glosa = obj.Glosa, _
                                             .NumDocCompra = obj.NroDoc, _
                                             .cuentaOrigen = obj.Cuenta, _
                                             .idDocumento = obj.IdDocumento, _
                                             .tipoProducto = obj.TipoProducto, _
                                             .destinoGravadoItem = obj.DestinoGravado, _
                                             .marca = obj.marca, _
                                             .montoUSD = obj.CostoUS _
                                             }
                listaInventario.Add(objInventarioMovimientoBO)
            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    Public Function ObtenerMarcaPorAlmacenesPorMes(ByVal idAlmacen As String, marca As String, ByVal periodo As Integer, ByVal mes As String) As List(Of InventarioMovimiento)
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Try
            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Join m In HeliosData.tabladetalle On m.codigoDetalle Equals p.marca _
                                   Where p.idAlmacen = idAlmacen _
                                   And m.codigoDetalle = marca _
                                   And m.idtabla = CInt(503) _
                                   And p.fecha.Value.Month = CInt(mes) _
                                   And p.fecha.Value.Year = periodo _
                                   Order By p.fecha _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = q.descripcionItem, _
                                            .cantidad = p.cantidad, _
                                            .unidad = p.unidad, _
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = doc.nroDoc, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .tipoOperacion = p.tipoOperacion, _
                                           .marca = p.marca _
                                           } _
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento With _
                                            {.idInventario = obj.idInventario, _
                                             .fecha = obj.Fecha, _
                                             .idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa), _
                                             .idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen), _
                                             .idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem), _
                                             .nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem), _
                                             .cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad), _
                                             .unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad), _
                                             .precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE), _
                                             .monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto), _
                                             .disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible), _
                                             .status = IIf(IsDBNull(obj.estado), Nothing, obj.estado), _
                                             .tipoRegistro = obj.TipoRegistro.ToString, _
                                             .glosa = obj.Glosa, _
                                             .NumDocCompra = obj.NroDoc, _
                                             .cuentaOrigen = obj.Cuenta, _
                                             .idDocumento = obj.IdDocumento, _
                                             .tipoProducto = obj.TipoProducto, _
                                             .destinoGravadoItem = obj.DestinoGravado, _
                                             .montoUSD = obj.CostoUS, _
                                             .marca = obj.marca, _
                                             .tipoOperacion = obj.tipoOperacion _
                                             }
                listaInventario.Add(objInventarioMovimientoBO)
            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region


    Public Function GetCostoVentaMensual(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim cierreBL As New cierreinventarioBL
        Dim cierre As New cierreinventario
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim producto As String = Nothing
        Dim productoCache As String = Nothing
        Dim listaTipo As New List(Of String)

        listaTipo.Add("E")
        listaTipo.Add("S")

        Try
            Dim periodoCierre As String = String.Format("{0:00}", be.fecha.Value.Month) & be.fecha.Value.Year

            ' Dim periodoVal = CStr(be.fecha.Value.Month) & CStr(be.fecha.Value.Year)

            Dim consult = (From a In HeliosData.cierreCostoVenta
                           Where a.periodo = periodoCierre).FirstOrDefault


            If Not IsNothing(consult) Then
                Throw New Exception("Tiene Cierre este Periodo")
            Else

                Dim inventarios = (From p In HeliosData.InventarioMovimiento
                                   Join estable In HeliosData.centrocosto On estable.idCentroCosto Equals p.idEstablecimiento
                                   Join alm In HeliosData.almacen On alm.idAlmacen Equals p.idAlmacen
                                   Where p.fecha.Value.Year = CInt(be.fecha.Value.Year) _
                                   And p.fecha.Value.Month = CInt(be.fecha.Value.Month) _
                                   And p.idEmpresa = be.idEmpresa _
                                   And listaTipo.Contains(p.tipoRegistro)
                                   Order By p.idAlmacen, p.descripcion, p.tipoProducto, p.fecha Ascending
                                   Select New With
                                               {.idInventario = p.idInventario,
                                                .idestablecimiento = estable.idCentroCosto,
                                                .NomEstable = estable.nombre,
                                                .NomAlmacen = alm.descripcionAlmacen,
                                                .Fecha = p.fecha,
                                                .idEmpresa = p.idEmpresa,
                                                .idAlmacen = p.idAlmacen,
                                                .idItem = p.idItem,
                                                .nombreItem = p.descripcion,
                                                .marca = p.marca,
                                                .cantidad = p.cantidad,
                                                .unidad = p.unidad,
                                                .UnitproceE = p.precUnite,
                                                .monto = p.monto,
                                                .disponible = p.disponible,
                                                .estado = p.status,
                                                .TipoRegistro = p.tipoRegistro,
                                                .Glosa = p.descripcion,
                                                .NroDoc = p.serie & "-" & p.numero,
                                                .Cuenta = p.cuentaOrigen,
                                                .IdDocumento = p.idDocumento,
                                                .TipoProducto = p.tipoProducto,
                                                .DestinoGravado = p.destinoGravadoItem,
                                                .CostoUS = p.montoUSD,
                                                .tipoOperacion = p.tipoOperacion
                                               }
                                    ).ToList

                For Each obj In inventarios
                    objInventarioMovimientoBO = New InventarioMovimiento
                    objInventarioMovimientoBO.idEstablecimiento = obj.idestablecimiento
                    objInventarioMovimientoBO.idInventario = obj.idInventario
                    objInventarioMovimientoBO.NomEstablecimiento = obj.NomEstable
                    objInventarioMovimientoBO.NombreAlmacen = obj.NomAlmacen
                    objInventarioMovimientoBO.fecha = obj.Fecha
                    objInventarioMovimientoBO.idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa)
                    objInventarioMovimientoBO.idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen)
                    objInventarioMovimientoBO.idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem)
                    objInventarioMovimientoBO.nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem)
                    objInventarioMovimientoBO.marca = obj.marca
                    objInventarioMovimientoBO.disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible)
                    objInventarioMovimientoBO.status = IIf(IsDBNull(obj.estado), Nothing, obj.estado)
                    objInventarioMovimientoBO.tipoRegistro = obj.TipoRegistro.ToString
                    objInventarioMovimientoBO.glosa = obj.Glosa
                    objInventarioMovimientoBO.NumDocCompra = obj.NroDoc
                    objInventarioMovimientoBO.cuentaOrigen = obj.Cuenta
                    objInventarioMovimientoBO.idDocumento = obj.IdDocumento
                    objInventarioMovimientoBO.tipoProducto = obj.TipoProducto
                    objInventarioMovimientoBO.destinoGravadoItem = obj.DestinoGravado
                    objInventarioMovimientoBO.tipoOperacion = obj.tipoOperacion
                    'cierre = cierreBL.RecuperarCierre(year, mes - 1, obj.idItem)
                    objInventarioMovimientoBO.cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad)
                    objInventarioMovimientoBO.unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad)
                    objInventarioMovimientoBO.precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE)
                    objInventarioMovimientoBO.monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto)
                    objInventarioMovimientoBO.montoUSD = obj.CostoUS
                    listaInventario.Add(objInventarioMovimientoBO)

                    producto = obj.idItem
                    productoCache = obj.nombreItem

                Next

                Return listaInventario

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetKardexByPerido(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim cierreBL As New cierreinventarioBL
        Dim cierre As New cierreinventario
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim producto As String = Nothing
        Dim productoCache As String = Nothing
        Try
            '  Dim periodoCierre As String = String.Format("{0:00}", be.fecha.Value.Month) & be.fecha.Value.Year

            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Where p.idAlmacen = be.idAlmacen _
                                   And p.fecha.Value.Month = CInt(be.fecha.Value.Month) _
                                   And p.fecha.Value.Year = CInt(be.fecha.Value.Year) _
                                   Order By p.descripcion, p.fecha Ascending _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = p.descripcion, _
                                            .marca = p.marca, _
                                            .cantidad = p.cantidad, _
                                            .unidad = p.unidad, _
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = p.serie & "-" & p.numero, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .tipoOperacion = p.tipoOperacion _
                                           } _
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento
                objInventarioMovimientoBO.idInventario = obj.idInventario
                objInventarioMovimientoBO.fecha = obj.Fecha
                objInventarioMovimientoBO.idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa)
                objInventarioMovimientoBO.idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen)
                objInventarioMovimientoBO.idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem)
                objInventarioMovimientoBO.nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem)
                objInventarioMovimientoBO.marca = obj.marca
                objInventarioMovimientoBO.disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible)
                objInventarioMovimientoBO.status = IIf(IsDBNull(obj.estado), Nothing, obj.estado)
                objInventarioMovimientoBO.tipoRegistro = obj.TipoRegistro.ToString
                objInventarioMovimientoBO.glosa = obj.Glosa
                objInventarioMovimientoBO.NumDocCompra = obj.NroDoc
                objInventarioMovimientoBO.cuentaOrigen = obj.Cuenta
                objInventarioMovimientoBO.idDocumento = obj.IdDocumento
                objInventarioMovimientoBO.tipoProducto = obj.TipoProducto
                objInventarioMovimientoBO.destinoGravadoItem = obj.DestinoGravado
                objInventarioMovimientoBO.tipoOperacion = obj.tipoOperacion
                'cierre = cierreBL.RecuperarCierre(year, mes - 1, obj.idItem)
                objInventarioMovimientoBO.cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad)
                objInventarioMovimientoBO.unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad)
                objInventarioMovimientoBO.precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE)
                objInventarioMovimientoBO.monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto)
                objInventarioMovimientoBO.montoUSD = obj.CostoUS
                listaInventario.Add(objInventarioMovimientoBO)

                producto = obj.idItem
                productoCache = obj.nombreItem

            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Function GetKardexByAnio(be As InventarioMovimiento) As List(Of InventarioMovimiento)
    '    Dim cierreBL As New cierreinventarioBL
    '    Dim cierre As New cierreinventario
    '    Dim objInventarioMovimientoBO As InventarioMovimiento
    '    Dim listaInventario As New List(Of InventarioMovimiento)
    '    Dim producto As String = Nothing
    '    Dim productoCache As String = Nothing
    '    Try
    '        Dim periodoCierre As String = String.Format("{0:00}", be.fecha.Value.Month) & be.fecha.Value.Year

    '        Dim inventarios = (From p In HeliosData.InventarioMovimiento _
    '                               Where p.idAlmacen = be.idAlmacen _
    '                               And p.fecha.Value.Year = CInt(be.fecha.Value.Year) _
    '                               Order By p.descripcion, p.fecha Ascending _
    '                               Select New With _
    '                                       {.idInventario = p.idInventario, _
    '                                        .Fecha = p.fecha, _
    '                                        .idEmpresa = p.idEmpresa, _
    '                                        .idAlmacen = p.idAlmacen, _
    '                                        .idItem = p.idItem, _
    '                                        .nombreItem = p.descripcion, _
    '                                        .marca = p.marca, _
    '                                        .cantidad = p.cantidad, _
    '                                        .unidad = p.unidad, _
    '                                        .UnitproceE = p.precUnite, _
    '                                        .monto = p.monto, _
    '                                        .disponible = p.disponible, _
    '                                        .estado = p.status, _
    '                                        .TipoRegistro = p.tipoRegistro, _
    '                                        .Glosa = p.descripcion, _
    '                                        .NroDoc = p.serie & "-" & p.numero, _
    '                                        .Cuenta = p.cuentaOrigen, _
    '                                        .IdDocumento = p.idDocumento, _
    '                                        .TipoProducto = p.tipoProducto, _
    '                                        .DestinoGravado = p.destinoGravadoItem, _
    '                                        .CostoUS = p.montoUSD, _
    '                                        .tipoOperacion = p.tipoOperacion _
    '                                       } _
    '                            ).ToList

    '        For Each obj In inventarios
    '            objInventarioMovimientoBO = New InventarioMovimiento
    '            objInventarioMovimientoBO.idInventario = obj.idInventario
    '            objInventarioMovimientoBO.fecha = obj.Fecha
    '            objInventarioMovimientoBO.idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa)
    '            objInventarioMovimientoBO.idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen)
    '            objInventarioMovimientoBO.idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem)
    '            objInventarioMovimientoBO.nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem)
    '            objInventarioMovimientoBO.marca = obj.marca
    '            objInventarioMovimientoBO.disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible)
    '            objInventarioMovimientoBO.status = IIf(IsDBNull(obj.estado), Nothing, obj.estado)
    '            objInventarioMovimientoBO.tipoRegistro = obj.TipoRegistro.ToString
    '            objInventarioMovimientoBO.glosa = obj.Glosa
    '            objInventarioMovimientoBO.NumDocCompra = obj.NroDoc
    '            objInventarioMovimientoBO.cuentaOrigen = obj.Cuenta
    '            objInventarioMovimientoBO.idDocumento = obj.IdDocumento
    '            objInventarioMovimientoBO.tipoProducto = obj.TipoProducto
    '            objInventarioMovimientoBO.destinoGravadoItem = obj.DestinoGravado
    '            objInventarioMovimientoBO.tipoOperacion = obj.tipoOperacion
    '            'cierre = cierreBL.RecuperarCierre(year, mes - 1, obj.idItem)
    '            objInventarioMovimientoBO.cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad)
    '            objInventarioMovimientoBO.unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad)
    '            objInventarioMovimientoBO.precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE)
    '            objInventarioMovimientoBO.monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto)
    '            objInventarioMovimientoBO.montoUSD = obj.CostoUS
    '            listaInventario.Add(objInventarioMovimientoBO)

    '            producto = obj.idItem
    '            productoCache = obj.nombreItem

    '        Next

    '        Return listaInventario
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Public Function GetMovimientosKardexByMes(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento)
        Dim obj As New InventarioMovimiento
        Dim lista As New List(Of InventarioMovimiento)

        'Dim consulta = (From t In HeliosData.InventarioMovimiento
        '                Join art In HeliosData.detalleitems
        '                On art.codigodetalle Equals t.idItem
        '                Where
        '                    CLng(t.fecha.Value.Year) = be.fecha.Value.Year And
        '                    CLng(t.fecha.Value.Month) = be.fecha.Value.Month And
        '                    t.idAlmacen = be.idAlmacen
        '                Order By art.descripcionItem, t.tipoProducto, art.origenProducto, t.fecha Ascending
        '                Select
        '                    t.idInventario,
        '                    t.fecha,
        '                    t.idEmpresa,
        '                    t.idAlmacen,
        '                    t.tipoProducto,
        '                    t.idDocumento,
        '                    t.tipoRegistro,
        '                    t.serie,
        '                    t.numero,
        '                    t.tipoOperacion,
        '                    art.codigodetalle,
        '                    art.origenProducto,
        '                    t.descripcion,
        '                    art.descripcionItem,
        '                    art.unidad1,
        '                    t.cantidad,
        '                    t.monto,
        '                    DetalleTipoOperacion = (From c In HeliosData.tabladetalle
        '                                            Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
        '                                            Select New With
        '                                                    {
        '                                                    c.descripcion
        '                                                    }).FirstOrDefault().descripcion,
        '                    Valor_venta = (From c In HeliosData.documentoventaAbarrotesDet
        '                                   Where c.idDocumento = t.idDocumento And c.idItem = t.idItem
        '                                   Select New With
        '                                               {
        '                                               c.montokardex
        '                                               }).FirstOrDefault().montokardex).ToList


        Dim consulta = (From t In HeliosData.InventarioMovimiento
                        Join art In HeliosData.detalleitems
                            On art.codigodetalle Equals t.idItem
                        Join Lote In HeliosData.recursoCostoLote
                            On Lote.codigoLote Equals t.nrolote
                        Where
                            art.estado = "A" And
                            CLng(t.fecha.Value.Year) = be.fecha.Value.Year And
                            CLng(t.fecha.Value.Month) = be.fecha.Value.Month And
                            t.idAlmacen = be.idAlmacen
                        Order By
                            art.descripcionItem,
                            art.codigodetalle,
                            t.tipoProducto,
                            art.origenProducto,
                            t.nrolote,
                            t.fecha Ascending
                        Select
                            Lote.nroLote,
                            Lote.codigoLote,
                            Lote.fechaVcto,
                            t.idInventario,
                            t.fecha,
                            t.idEmpresa,
                            t.idAlmacen,
                            t.tipoProducto,
                            t.idDocumento,
                            t.idDocumentoRef,
                            t.tipoRegistro,
                            t.serie,
                            t.numero,
                            t.tipoOperacion,
                            art.codigodetalle,
                            art.origenProducto,
                            t.descripcion,
                            art.descripcionItem,
                            art.unidad1,
                            t.cantidad,
                            t.monto,
                            DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                    Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                    Select New With
                                                            {
                                                            c.descripcion
                                                            }).FirstOrDefault().descripcion,
                            Valor_venta = (From c In HeliosData.documentoventaAbarrotesDet
                                           Where c.idDocumento = t.idDocumento And c.idItem = t.idItem And
                                               c.codigoLote = t.nrolote
                                           Select New With
                                                       {
                                                       c.montokardex
                                                       }).FirstOrDefault().montokardex).ToList


        'Dim listaVenta = consulta.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.VENTA).ToList
        For Each i In consulta
            obj = New InventarioMovimiento
            obj.customLote = New recursoCostoLote With
                {
                .codigoLote = i.codigoLote,
                .nroLote = i.nroLote,
                .fechaVcto = i.fechaVcto
            }
            obj.idInventario = i.idInventario
            obj.ValorDeVenta = i.Valor_venta.GetValueOrDefault
            'obj.NombreAlmacen = i.descripcionAlmacen
            obj.fecha = i.fecha
            obj.idEmpresa = i.idEmpresa
            obj.idAlmacen = i.idAlmacen
            obj.tipoProducto = i.tipoProducto
            obj.idDocumento = i.idDocumento
            obj.idDocumentoRef = i.idDocumentoRef
            obj.tipoRegistro = i.tipoRegistro
            obj.serie = i.serie
            obj.numero = i.numero
            obj.tipoOperacion = i.tipoOperacion
            obj.DetalleTipoOperacion = i.DetalleTipoOperacion
            obj.idItem = i.codigodetalle
            obj.destinoGravadoItem = i.origenProducto
            obj.descripcion = i.descripcionItem
            obj.nombreItem = i.descripcionItem
            obj.unidad = i.unidad1
            obj.cantidad = i.cantidad
            obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
            obj.monto = i.monto
            obj.montoOther = 0 ' i.CierreImporteMesAnterior.GetValueOrDefault
            lista.Add(obj)
        Next
        Return lista
    End Function



    Public Function GetMovimientosKardexByMesAllAlmacen(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim obj As New InventarioMovimiento
        Dim lista As New List(Of InventarioMovimiento)


        Dim consulta = (From t In HeliosData.InventarioMovimiento
                        Join art In HeliosData.detalleitems
                        On art.codigodetalle Equals t.idItem
                        Where
                            art.estado = "A" And
                            CLng(t.fecha.Value.Year) = be.fecha.Value.Year And
                            CLng(t.fecha.Value.Month) = be.fecha.Value.Month
                        Order By t.idAlmacen, art.descripcionItem, t.tipoProducto, art.origenProducto, t.fecha Ascending
                        Select
                            t.idInventario,
                            t.fecha,
                            t.idEmpresa,
                            t.idAlmacen,
                            t.tipoProducto,
                            t.idDocumento,
                            t.tipoRegistro,
                            t.serie,
                            t.numero,
                            t.tipoOperacion,
                            art.codigodetalle,
                            art.origenProducto,
                            t.descripcion,
                            art.descripcionItem,
                            art.unidad1,
                            t.cantidad,
                            t.monto,
                            DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                    Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                    Select New With
                                                            {
                                                            c.descripcion
                                                            }).FirstOrDefault().descripcion).ToList


        For Each i In consulta
            obj = New InventarioMovimiento
            obj.idInventario = i.idInventario
            'obj.NombreAlmacen = i.descripcionAlmacen
            obj.fecha = i.fecha
            obj.idEmpresa = i.idEmpresa
            obj.idAlmacen = i.idAlmacen
            obj.tipoProducto = i.tipoProducto
            obj.idDocumento = i.idDocumento
            obj.tipoRegistro = i.tipoRegistro
            obj.serie = i.serie
            obj.numero = i.numero
            obj.tipoOperacion = i.tipoOperacion
            obj.DetalleTipoOperacion = i.DetalleTipoOperacion
            obj.idItem = i.codigodetalle
            obj.destinoGravadoItem = i.origenProducto
            obj.descripcion = i.descripcionItem
            obj.nombreItem = i.descripcionItem
            obj.unidad = i.unidad1
            obj.cantidad = i.cantidad
            obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
            obj.monto = i.monto
            obj.montoOther = 0 ' i.CierreImporteMesAnterior.GetValueOrDefault
            lista.Add(obj)
        Next
        Return lista
    End Function

    Public Function GetKardexByAnio(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim cierreBL As New cierreinventarioBL
        Dim cierre As New cierreinventario
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim producto As String = Nothing
        Dim productoCache As String = Nothing
        Try
            'Dim periodoCierre As String = String.Format("{0:00}", be.fecha.Value.Month) & be.fecha.Value.Year

            Dim inventarios = (From p In HeliosData.InventarioMovimiento
                               Where p.idAlmacen = be.idAlmacen _
                                   And p.fecha.Value.Year = CInt(be.fecha.Value.Year)
                               Order By p.descripcion, p.tipoProducto, p.fecha Ascending
                               Select New With
                                           {.idInventario = p.idInventario,
                                            .Fecha = p.fecha,
                                            .idEmpresa = p.idEmpresa,
                                            .idAlmacen = p.idAlmacen,
                                            .idItem = p.idItem,
                                            .nombreItem = p.descripcion,
                                            .marca = p.marca,
                                            .cantidad = p.cantidad,
                                            .unidad = p.unidad,
                                            .UnitproceE = p.precUnite,
                                            .monto = p.monto,
                                            .disponible = p.disponible,
                                            .estado = p.status,
                                            .TipoRegistro = p.tipoRegistro,
                                            .Glosa = p.descripcion,
                                            .NroDoc = p.serie & "-" & p.numero,
                                            .Cuenta = p.cuentaOrigen,
                                            .IdDocumento = p.idDocumento,
                                            .TipoProducto = p.tipoProducto,
                                            .DestinoGravado = p.destinoGravadoItem,
                                            .CostoUS = p.montoUSD,
                                            .tipoOperacion = p.tipoOperacion
                                           }
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento
                objInventarioMovimientoBO.idInventario = obj.idInventario
                objInventarioMovimientoBO.fecha = obj.Fecha
                objInventarioMovimientoBO.idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa)
                objInventarioMovimientoBO.idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen)
                objInventarioMovimientoBO.idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem)
                objInventarioMovimientoBO.nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem)
                objInventarioMovimientoBO.marca = obj.marca
                objInventarioMovimientoBO.disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible)
                objInventarioMovimientoBO.status = IIf(IsDBNull(obj.estado), Nothing, obj.estado)
                objInventarioMovimientoBO.tipoRegistro = obj.TipoRegistro.ToString
                objInventarioMovimientoBO.glosa = obj.Glosa
                objInventarioMovimientoBO.NumDocCompra = obj.NroDoc
                objInventarioMovimientoBO.cuentaOrigen = obj.Cuenta
                objInventarioMovimientoBO.idDocumento = obj.IdDocumento
                objInventarioMovimientoBO.tipoProducto = obj.TipoProducto
                objInventarioMovimientoBO.destinoGravadoItem = obj.DestinoGravado
                objInventarioMovimientoBO.tipoOperacion = obj.tipoOperacion
                'cierre = cierreBL.RecuperarCierre(year, mes - 1, obj.idItem)
                objInventarioMovimientoBO.cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad)
                objInventarioMovimientoBO.unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad)
                objInventarioMovimientoBO.precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE)
                objInventarioMovimientoBO.monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto)
                objInventarioMovimientoBO.montoUSD = obj.CostoUS
                listaInventario.Add(objInventarioMovimientoBO)

                producto = obj.idItem
                productoCache = obj.nombreItem

            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetKardexByAnioAlmacenAll(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim cierreBL As New cierreinventarioBL
        Dim cierre As New cierreinventario
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim producto As String = Nothing
        Dim productoCache As String = Nothing
        Try
            ''Dim periodoCierre As String = String.Format("{0:00}", be.fecha.Value.Month) & be.fecha.Value.Year

            Dim inventarios = (From p In HeliosData.InventarioMovimiento
                               Join estable In HeliosData.centrocosto On estable.idCentroCosto Equals p.idEstablecimiento _
                               Join alm In HeliosData.almacen On alm.idAlmacen Equals p.idAlmacen _
                               Where p.fecha.Value.Year = CInt(be.fecha.Value.Year) _
                               And p.idEmpresa = be.idEmpresa _
                               Order By p.idAlmacen, p.descripcion, p.tipoProducto, p.fecha Ascending
                               Select New With
                                           {.idInventario = p.idInventario,
                                            .idestablecimiento = estable.idCentroCosto,
                                            .NomEstable = estable.nombre,
                                            .NomAlmacen = alm.descripcionAlmacen,
                                            .Fecha = p.fecha,
                                            .idEmpresa = p.idEmpresa,
                                            .idAlmacen = p.idAlmacen,
                                            .idItem = p.idItem,
                                            .nombreItem = p.descripcion,
                                            .marca = p.marca,
                                            .cantidad = p.cantidad,
                                            .unidad = p.unidad,
                                            .UnitproceE = p.precUnite,
                                            .monto = p.monto,
                                            .disponible = p.disponible,
                                            .estado = p.status,
                                            .TipoRegistro = p.tipoRegistro,
                                            .Glosa = p.descripcion,
                                            .NroDoc = p.serie & "-" & p.numero,
                                            .Cuenta = p.cuentaOrigen,
                                            .IdDocumento = p.idDocumento,
                                            .TipoProducto = p.tipoProducto,
                                            .DestinoGravado = p.destinoGravadoItem,
                                            .CostoUS = p.montoUSD,
                                            .tipoOperacion = p.tipoOperacion
                                           }
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento
                objInventarioMovimientoBO.idEstablecimiento = obj.idestablecimiento
                objInventarioMovimientoBO.idInventario = obj.idInventario
                objInventarioMovimientoBO.NomEstablecimiento = obj.NomEstable
                objInventarioMovimientoBO.NombreAlmacen = obj.NomAlmacen
                objInventarioMovimientoBO.fecha = obj.Fecha
                objInventarioMovimientoBO.idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa)
                objInventarioMovimientoBO.idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen)
                objInventarioMovimientoBO.idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem)
                objInventarioMovimientoBO.nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem)
                objInventarioMovimientoBO.marca = obj.marca
                objInventarioMovimientoBO.disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible)
                objInventarioMovimientoBO.status = IIf(IsDBNull(obj.estado), Nothing, obj.estado)
                objInventarioMovimientoBO.tipoRegistro = obj.TipoRegistro.ToString
                objInventarioMovimientoBO.glosa = obj.Glosa
                objInventarioMovimientoBO.NumDocCompra = obj.NroDoc
                objInventarioMovimientoBO.cuentaOrigen = obj.Cuenta
                objInventarioMovimientoBO.idDocumento = obj.IdDocumento
                objInventarioMovimientoBO.tipoProducto = obj.TipoProducto
                objInventarioMovimientoBO.destinoGravadoItem = obj.DestinoGravado
                objInventarioMovimientoBO.tipoOperacion = obj.tipoOperacion
                'cierre = cierreBL.RecuperarCierre(year, mes - 1, obj.idItem)
                objInventarioMovimientoBO.cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad)
                objInventarioMovimientoBO.unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad)
                objInventarioMovimientoBO.precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE)
                objInventarioMovimientoBO.monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto)
                objInventarioMovimientoBO.montoUSD = obj.CostoUS
                listaInventario.Add(objInventarioMovimientoBO)

                producto = obj.idItem
                productoCache = obj.nombreItem

            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetSelXtipoExistenciaVenta(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim cierreBL As New cierreinventarioBL
        Dim cierre As New cierreinventario
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim producto As String = Nothing
        Dim productoCache As String = Nothing
        Try
            '    Dim periodoCierre As String = String.Format("{0:00}", be.fecha.Value.Month) & be.fecha.Value.Year

            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                               Join doc In HeliosData.documentoventaAbarrotes _
                               On doc.idDocumento Equals p.idDocumento _
                               Join per In HeliosData.entidad On per.idEntidad Equals doc.idCliente _
                               Where p.idAlmacen = be.idAlmacen _
                                   And p.fecha.Value.Year = CInt(be.fecha.Value.Year) _
                                   And p.tipoOperacion = "01" _
                                   And p.tipoProducto = be.tipoProducto _
                                   Order By p.descripcion, p.fecha Ascending _
                                   Select New With
                                           {.iddoc = doc.idDocumento,
                                            .Fecha = doc.fechaDoc,
                                            .tipodoc = doc.tipoDocumento,
                                            .serie = doc.serie,
                                            .numero = doc.numeroDocNormal,
                                            .Cliente = per.nombreCompleto,
                                            .moneda = doc.moneda,
                                            .ImporteMN = p.monto,
                                            .ImporteME = p.montoUSD
                                           }
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento
                objInventarioMovimientoBO.idDocumento = obj.iddoc
                objInventarioMovimientoBO.fecha = obj.Fecha
                objInventarioMovimientoBO.ComprobanteCompra = obj.tipodoc
                objInventarioMovimientoBO.serie = obj.serie
                objInventarioMovimientoBO.numero = obj.numero
                objInventarioMovimientoBO.nombreProveedor = obj.Cliente
                objInventarioMovimientoBO.monedaOther = obj.moneda
                objInventarioMovimientoBO.monto = obj.ImporteMN * -1
                objInventarioMovimientoBO.montoUSD = obj.ImporteME * -1
                listaInventario.Add(objInventarioMovimientoBO)
            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetKardexByfechaDocumentoLote(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim cierreBL As New cierreinventarioBL
        Dim cierre As New cierreinventario
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim producto As String = Nothing
        Dim productoCache As String = Nothing
        Try

            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Where p.idAlmacen = be.idAlmacen _
                                   And p.fecha.Value.Year = CInt(be.fecha.Value.Year) _
                                   And p.nrolote = be.nrolote _
                                   Order By p.descripcion, p.fecha Ascending _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = p.descripcion, _
                                            .marca = p.marca, _
                                            .cantidad = p.cantidad, _
                                            .unidad = p.unidad, _
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = p.serie & "-" & p.numero, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .tipoOperacion = p.tipoOperacion _
                                           } _
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento
                objInventarioMovimientoBO.idInventario = obj.idInventario
                objInventarioMovimientoBO.fecha = obj.Fecha
                objInventarioMovimientoBO.idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa)
                objInventarioMovimientoBO.idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen)
                objInventarioMovimientoBO.idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem)
                objInventarioMovimientoBO.nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem)
                objInventarioMovimientoBO.marca = obj.marca
                objInventarioMovimientoBO.disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible)
                objInventarioMovimientoBO.status = IIf(IsDBNull(obj.estado), Nothing, obj.estado)
                objInventarioMovimientoBO.tipoRegistro = obj.TipoRegistro.ToString
                objInventarioMovimientoBO.glosa = obj.Glosa
                objInventarioMovimientoBO.NumDocCompra = obj.NroDoc
                objInventarioMovimientoBO.cuentaOrigen = obj.Cuenta
                objInventarioMovimientoBO.idDocumento = obj.IdDocumento
                objInventarioMovimientoBO.tipoProducto = obj.TipoProducto
                objInventarioMovimientoBO.destinoGravadoItem = obj.DestinoGravado
                objInventarioMovimientoBO.tipoOperacion = obj.tipoOperacion
                'cierre = cierreBL.RecuperarCierre(year, mes - 1, obj.idItem)
                objInventarioMovimientoBO.cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad)
                objInventarioMovimientoBO.unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad)
                objInventarioMovimientoBO.precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE)
                objInventarioMovimientoBO.monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto)
                objInventarioMovimientoBO.montoUSD = obj.CostoUS
                listaInventario.Add(objInventarioMovimientoBO)

                producto = obj.idItem
                productoCache = obj.nombreItem

            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetKardexByDia(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim cierreBL As New cierreinventarioBL
        Dim cierre As New cierreinventario
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim producto As String = Nothing
        Dim productoCache As String = Nothing
        Try
            '_                                  Where p.idEstablecimiento = GEstableciento.IdEstablecimiento _
            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                               Where p.fecha.Value.Month = CInt(be.fecha.Value.Month) _
                                   And p.fecha.Value.Day = CInt(be.fecha.Value.Day) _
                                   Order By p.descripcion, p.fecha Ascending _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = p.descripcion, _
                                            .marca = p.marca, _
                                            .cantidad = p.cantidad, _
                                            .unidad = p.unidad, _
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = p.serie & "-" & p.numero, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .tipoOperacion = p.tipoOperacion _
                                           } _
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento
                objInventarioMovimientoBO.idInventario = obj.idInventario
                objInventarioMovimientoBO.fecha = obj.Fecha
                objInventarioMovimientoBO.idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa)
                objInventarioMovimientoBO.idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen)
                objInventarioMovimientoBO.idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem)
                objInventarioMovimientoBO.nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem)
                objInventarioMovimientoBO.marca = obj.marca
                objInventarioMovimientoBO.disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible)
                objInventarioMovimientoBO.status = IIf(IsDBNull(obj.estado), Nothing, obj.estado)
                objInventarioMovimientoBO.tipoRegistro = obj.TipoRegistro.ToString
                objInventarioMovimientoBO.glosa = obj.Glosa
                objInventarioMovimientoBO.NumDocCompra = obj.NroDoc
                objInventarioMovimientoBO.cuentaOrigen = obj.Cuenta
                objInventarioMovimientoBO.idDocumento = obj.IdDocumento
                objInventarioMovimientoBO.tipoProducto = obj.TipoProducto
                objInventarioMovimientoBO.destinoGravadoItem = obj.DestinoGravado
                objInventarioMovimientoBO.tipoOperacion = obj.tipoOperacion
                'cierre = cierreBL.RecuperarCierre(year, mes - 1, obj.idItem)
                objInventarioMovimientoBO.cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad)
                objInventarioMovimientoBO.unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad)
                objInventarioMovimientoBO.precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE)
                objInventarioMovimientoBO.monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto)
                objInventarioMovimientoBO.montoUSD = obj.CostoUS
                listaInventario.Add(objInventarioMovimientoBO)

                producto = obj.idItem
                productoCache = obj.nombreItem

            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' Mostrar Kardex por día laboral (x año)
    ''' </summary>
    ''' <param name="be"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetKardexByAnioDiaLaboral(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim cierreBL As New cierreinventarioBL
        Dim cierre As New cierreinventario
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim producto As String = Nothing
        Dim productoCache As String = Nothing
        Try

            Dim inventarios = (From p In HeliosData.InventarioMovimiento
                               Where p.idAlmacen = be.idAlmacen _
                                   And p.fechaLaboral.Value.Year = CInt(be.fechaLaboral.Value.Year)
                               Order By p.descripcion, p.tipoProducto, p.fechaLaboral Ascending
                               Select New With
                                           {.idInventario = p.idInventario,
                                            .fechaLaboral = p.fechaLaboral,
                                            .idEmpresa = p.idEmpresa,
                                            .idAlmacen = p.idAlmacen,
                                            .idItem = p.idItem,
                                            .nombreItem = p.descripcion,
                                            .marca = p.marca,
                                            .cantidad = p.cantidad,
                                            .unidad = p.unidad,
                                            .UnitproceE = p.precUnite,
                                            .monto = p.monto,
                                            .disponible = p.disponible,
                                            .estado = p.status,
                                            .TipoRegistro = p.tipoRegistro,
                                            .Glosa = p.descripcion,
                                            .NroDoc = p.serie & "-" & p.numero,
                                            .Cuenta = p.cuentaOrigen,
                                            .IdDocumento = p.idDocumento,
                                            .TipoProducto = p.tipoProducto,
                                            .DestinoGravado = p.destinoGravadoItem,
                                            .CostoUS = p.montoUSD,
                                            .tipoOperacion = p.tipoOperacion
                                           }
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento
                objInventarioMovimientoBO.idInventario = obj.idInventario
                objInventarioMovimientoBO.fecha = obj.fechaLaboral
                objInventarioMovimientoBO.idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa)
                objInventarioMovimientoBO.idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen)
                objInventarioMovimientoBO.idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem)
                objInventarioMovimientoBO.nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem)
                objInventarioMovimientoBO.marca = obj.marca
                objInventarioMovimientoBO.disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible)
                objInventarioMovimientoBO.status = IIf(IsDBNull(obj.estado), Nothing, obj.estado)
                objInventarioMovimientoBO.tipoRegistro = obj.TipoRegistro.ToString
                objInventarioMovimientoBO.glosa = obj.Glosa
                objInventarioMovimientoBO.NumDocCompra = obj.NroDoc
                objInventarioMovimientoBO.cuentaOrigen = obj.Cuenta
                objInventarioMovimientoBO.idDocumento = obj.IdDocumento
                objInventarioMovimientoBO.tipoProducto = obj.TipoProducto
                objInventarioMovimientoBO.destinoGravadoItem = obj.DestinoGravado
                objInventarioMovimientoBO.tipoOperacion = obj.tipoOperacion
                'cierre = cierreBL.RecuperarCierre(year, mes - 1, obj.idItem)
                objInventarioMovimientoBO.cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad)
                objInventarioMovimientoBO.unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad)
                objInventarioMovimientoBO.precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE)
                objInventarioMovimientoBO.monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto)
                objInventarioMovimientoBO.montoUSD = obj.CostoUS
                listaInventario.Add(objInventarioMovimientoBO)

                producto = obj.idItem
                productoCache = obj.nombreItem

            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetKardexByAnioDiaLaboralLote(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim cierreBL As New cierreinventarioBL
        Dim cierre As New cierreinventario
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim producto As String = Nothing
        Dim productoCache As String = Nothing
        Try

            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Where p.idAlmacen = be.idAlmacen _
                                   And p.fechaLaboral.Value.Year = CInt(be.fechaLaboral.Value.Year) _
                                   And p.nrolote = be.nrolote _
                                   Order By p.descripcion, p.fechaLaboral Ascending _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .fechaLaboral = p.fechaLaboral, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = p.descripcion, _
                                            .marca = p.marca, _
                                            .cantidad = p.cantidad, _
                                            .unidad = p.unidad, _
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = p.serie & "-" & p.numero, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .tipoOperacion = p.tipoOperacion _
                                           } _
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento
                objInventarioMovimientoBO.idInventario = obj.idInventario
                objInventarioMovimientoBO.fecha = obj.fechaLaboral
                objInventarioMovimientoBO.idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa)
                objInventarioMovimientoBO.idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen)
                objInventarioMovimientoBO.idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem)
                objInventarioMovimientoBO.nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem)
                objInventarioMovimientoBO.marca = obj.marca
                objInventarioMovimientoBO.disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible)
                objInventarioMovimientoBO.status = IIf(IsDBNull(obj.estado), Nothing, obj.estado)
                objInventarioMovimientoBO.tipoRegistro = obj.TipoRegistro.ToString
                objInventarioMovimientoBO.glosa = obj.Glosa
                objInventarioMovimientoBO.NumDocCompra = obj.NroDoc
                objInventarioMovimientoBO.cuentaOrigen = obj.Cuenta
                objInventarioMovimientoBO.idDocumento = obj.IdDocumento
                objInventarioMovimientoBO.tipoProducto = obj.TipoProducto
                objInventarioMovimientoBO.destinoGravadoItem = obj.DestinoGravado
                objInventarioMovimientoBO.tipoOperacion = obj.tipoOperacion
                'cierre = cierreBL.RecuperarCierre(year, mes - 1, obj.idItem)
                objInventarioMovimientoBO.cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad)
                objInventarioMovimientoBO.unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad)
                objInventarioMovimientoBO.precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE)
                objInventarioMovimientoBO.monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto)
                objInventarioMovimientoBO.montoUSD = obj.CostoUS
                listaInventario.Add(objInventarioMovimientoBO)

                producto = obj.idItem
                productoCache = obj.nombreItem

            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GetKardexByDiaLaboral_1(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim cierreBL As New cierreinventarioBL
        Dim cierre As New cierreinventario
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim producto As String = Nothing
        Dim productoCache As String = Nothing
        Try

            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Where p.fechaLaboral.Value.Year = CInt(be.fechaLaboral.Value.Year) _
                                   And p.fechaLaboral.Value.Month = CInt(be.fechaLaboral.Value.Month) _
                                   And p.fechaLaboral.Value.Day = CInt(be.fechaLaboral.Value.Day) _
                                   Order By p.descripcion, p.fechaLaboral Ascending _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .fechaLaboral = p.fechaLaboral, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = p.descripcion, _
                                            .marca = p.marca, _
                                            .cantidad = p.cantidad, _
                                            .unidad = p.unidad, _
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = p.serie & "-" & p.numero, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .tipoOperacion = p.tipoOperacion _
                                           } _
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento
                objInventarioMovimientoBO.idInventario = obj.idInventario
                objInventarioMovimientoBO.fecha = obj.fechaLaboral
                objInventarioMovimientoBO.idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa)
                objInventarioMovimientoBO.idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen)
                objInventarioMovimientoBO.idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem)
                objInventarioMovimientoBO.nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem)
                objInventarioMovimientoBO.marca = obj.marca
                objInventarioMovimientoBO.disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible)
                objInventarioMovimientoBO.status = IIf(IsDBNull(obj.estado), Nothing, obj.estado)
                objInventarioMovimientoBO.tipoRegistro = obj.TipoRegistro.ToString
                objInventarioMovimientoBO.glosa = obj.Glosa
                objInventarioMovimientoBO.NumDocCompra = obj.NroDoc
                objInventarioMovimientoBO.cuentaOrigen = obj.Cuenta
                objInventarioMovimientoBO.idDocumento = obj.IdDocumento
                objInventarioMovimientoBO.tipoProducto = obj.TipoProducto
                objInventarioMovimientoBO.destinoGravadoItem = obj.DestinoGravado
                objInventarioMovimientoBO.tipoOperacion = obj.tipoOperacion
                'cierre = cierreBL.RecuperarCierre(year, mes - 1, obj.idItem)
                objInventarioMovimientoBO.cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad)
                objInventarioMovimientoBO.unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad)
                objInventarioMovimientoBO.precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE)
                objInventarioMovimientoBO.monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto)
                objInventarioMovimientoBO.montoUSD = obj.CostoUS
                listaInventario.Add(objInventarioMovimientoBO)

                producto = obj.idItem
                productoCache = obj.nombreItem

            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetCuracionEntradasAlmacen(be As InventarioMovimiento, cierre As cierreinventario) As List(Of totalesAlmacen)
        Dim NuevaListaInventario As New List(Of InventarioMovimiento)
        'Dim ListaCurar As List(Of totalesAlmacen)
        Dim precUnit As Decimal = 0
        Dim pmAcumnulado As Decimal = 0
        Dim saldoCantidadAnual As Decimal = 0
        Dim saldoImporteAnual As Decimal = 0
        Dim ImporteSaldo As Decimal = 0
        Dim canSaldo As Decimal = 0

        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing
        '''''''''''
        Dim consulta = GetMovimientosKardexByMes(be, cierre)
        '''''''''''
        ImporteSaldo = 0
        canSaldo = 0

        'ListaCurar = New List(Of totalesAlmacen)
        GetCuracionEntradasAlmacen = New List(Of totalesAlmacen)
        NuevaListaInventario = New List(Of InventarioMovimiento)
        For Each i As InventarioMovimiento In consulta
            cantidadDeficit = 0
            importeDeficit = 0

            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    If producto = i.idItem Then
                        productoCache = i.nombreItem
                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec(i.monto)
                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0

                        canSaldo = canSaldo + i.cantidad2.GetValueOrDefault
                        ImporteSaldo = ImporteSaldo + i.montoOther.GetValueOrDefault
                        canSaldo = CDec(i.cantidad) + canSaldo
                        ImporteSaldo = CDec(i.monto) + ImporteSaldo

                    End If
                    If canSaldo > 0 Then
                        precUnit = ImporteSaldo / canSaldo
                    Else
                        precUnit = 0
                    End If
                    pmAcumnulado = precUnit
                Case "S", "D"
                    Dim co As Decimal = 0
                    co = CDec(i.cantidad) * pmAcumnulado

                    If producto = i.idItem Then
                        productoCache = i.nombreItem
                        Select Case i.tipoOperacion
                            Case "9913"
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo = ImporteSaldo

                            Case "9914"
                                canSaldo = canSaldo
                                ImporteSaldo += i.monto

                            Case "9916"
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += i.monto

                            Case StatusTipoOperacion.REVERSIONES
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += i.monto

                            Case Else
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += co
                        End Select

                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0

                        canSaldo = canSaldo + i.cantidad2.GetValueOrDefault
                        ImporteSaldo = ImporteSaldo + i.montoOther.GetValueOrDefault

                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
                    End If

                    If canSaldo > 0 Then
                        precUnit = ImporteSaldo / canSaldo
                    Else
                        precUnit = 0
                    End If
                    pmAcumnulado = precUnit
            End Select

            producto = i.idItem
            productoCache = i.nombreItem

            NuevaListaInventario.Add(New InventarioMovimiento With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                   .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                   .idAlmacen = i.idAlmacen,
                                                                   .idItem = i.idItem,
                                                                   .descripcion = i.nombreItem,
                                                                   .tipoExistencia = i.tipoProducto,
                                                                   .unidad = i.unidad,
                                                                   .CantSaldo = canSaldo,
                                                                   .saldoMonto = ImporteSaldo})
        Next


        Dim listaAGuardar = (From n In NuevaListaInventario _
                        Select n.idItem, n.idAlmacen
                        Order By idItem).Distinct.ToList()

        'asignando cierre de inventario
        '----------------------------------------------------------------------------------


        For Each c In listaAGuardar
            Dim obj = NuevaListaInventario.Where(Function(o) o.idItem = c.idItem And o.idAlmacen = c.idAlmacen).LastOrDefault

            GetCuracionEntradasAlmacen.Add(New totalesAlmacen With {.idAlmacen = c.idAlmacen,
                                                                   .idItem = obj.idItem,
                                                                   .cantidad = obj.CantSaldo,
                                                                   .importeSoles = obj.saldoMonto,
                                                                   .importeDolares = 0})


        Next

        Return GetCuracionEntradasAlmacen
    End Function

    ''' <summary>
    ''' Retorna Lista de kardex de un articulo x producto o articulo
    ''' </summary>
    ''' <param name="be"></param>
    ''' <param name="cierre"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCuracionEntradasAlmacenByArticulo(be As InventarioMovimiento, cierre As cierreinventario) As List(Of totalesAlmacen)
        Dim NuevaListaInventario As New List(Of InventarioMovimiento)
        'Dim ListaCurar As List(Of totalesAlmacen)
        Dim precUnit As Decimal = 0
        Dim pmAcumnulado As Decimal = 0
        Dim saldoCantidadAnual As Decimal = 0
        Dim saldoImporteAnual As Decimal = 0
        Dim ImporteSaldo As Decimal = 0
        Dim canSaldo As Decimal = 0

        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing
        '''''''''''
        Dim consulta = GetMovimientosKardexByArticulo(be, cierre)
        '''''''''''
        ImporteSaldo = 0
        canSaldo = 0

        'ListaCurar = New List(Of totalesAlmacen)
        GetCuracionEntradasAlmacenByArticulo = New List(Of totalesAlmacen)
        NuevaListaInventario = New List(Of InventarioMovimiento)
        For Each i As InventarioMovimiento In consulta
            cantidadDeficit = 0
            importeDeficit = 0

            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    If producto = i.idItem Then
                        productoCache = i.nombreItem
                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec(i.monto)
                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0

                        canSaldo = canSaldo + i.cantidad2.GetValueOrDefault
                        ImporteSaldo = ImporteSaldo + i.montoOther.GetValueOrDefault
                        canSaldo = CDec(i.cantidad) + canSaldo
                        ImporteSaldo = CDec(i.monto) + ImporteSaldo

                    End If
                    If canSaldo > 0 Then
                        precUnit = ImporteSaldo / canSaldo
                    Else
                        precUnit = 0
                    End If
                    pmAcumnulado = precUnit
                Case "S", "D"
                    Dim co As Decimal = 0
                    co = CDec(i.cantidad) * pmAcumnulado

                    If producto = i.idItem Then
                        productoCache = i.nombreItem
                        Select Case i.tipoOperacion
                            Case "9913"
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo = ImporteSaldo

                            Case "9914"
                                canSaldo = canSaldo
                                ImporteSaldo += i.monto

                            Case "9916"
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += i.monto

                            Case StatusTipoOperacion.REVERSIONES
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += i.monto

                            Case Else
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += co
                        End Select

                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0

                        canSaldo = canSaldo + i.cantidad2.GetValueOrDefault
                        ImporteSaldo = ImporteSaldo + i.montoOther.GetValueOrDefault

                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
                    End If

                    If canSaldo > 0 Then
                        precUnit = ImporteSaldo / canSaldo
                    Else
                        precUnit = 0
                    End If
                    pmAcumnulado = precUnit
            End Select

            producto = i.idItem
            productoCache = i.nombreItem

            NuevaListaInventario.Add(New InventarioMovimiento With {.idEmpresa = i.idEmpresa,
                                                                   .idEstablecimiento = i.idEstablecimiento,
                                                                   .idAlmacen = i.idAlmacen,
                                                                   .idItem = i.idItem,
                                                                   .descripcion = i.nombreItem,
                                                                   .tipoExistencia = i.tipoProducto,
                                                                   .unidad = i.unidad,
                                                                   .CantSaldo = canSaldo,
                                                                   .saldoMonto = ImporteSaldo})
        Next


        Dim listaAGuardar = (From n In NuevaListaInventario
                             Select n.idItem, n.idAlmacen
                             Order By idItem).Distinct.ToList()

        'asignando cierre de inventario
        '----------------------------------------------------------------------------------


        For Each c In listaAGuardar
            Dim obj = NuevaListaInventario.Where(Function(o) o.idItem = c.idItem And o.idAlmacen = c.idAlmacen).LastOrDefault

            GetCuracionEntradasAlmacenByArticulo.Add(New totalesAlmacen With {.idAlmacen = c.idAlmacen,
                                                                   .idItem = obj.idItem,
                                                                   .cantidad = obj.CantSaldo,
                                                                   .importeSoles = obj.saldoMonto,
                                                                   .importeDolares = 0})


        Next

        Return GetCuracionEntradasAlmacenByArticulo
    End Function


    Public Function GetCuracionEntradasAlmacenByArticuloLote(be As InventarioMovimiento, cierre As cierreinventario) As List(Of totalesAlmacen)
        Dim NuevaListaInventario As New List(Of InventarioMovimiento)
        'Dim ListaCurar As List(Of totalesAlmacen)

        Dim precUnit As Decimal = 0
        Dim precUnitME As Decimal = 0
        Dim pmAcumnulado As Decimal = 0
        Dim pmAcumnuladoME As Decimal = 0
        Dim saldoCantidadAnual As Decimal = 0
        Dim saldoImporteAnual As Decimal = 0
        Dim ImporteSaldo As Decimal = 0

        Dim saldoImporteAnualME As Decimal = 0
        Dim ImporteSaldoME As Decimal = 0

        Dim canSaldo As Decimal = 0
        Dim CodigoLotex As Integer = 0

        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim importeDeficitME As Decimal = 0
        Dim productoCache As String = Nothing
        '''''''''''
        Dim consulta = GetMovimientosKardexByArticuloLote(be, cierre)
        '''''''''''
        ImporteSaldo = 0
        ImporteSaldoME = 0
        canSaldo = 0

        'ListaCurar = New List(Of totalesAlmacen)
        GetCuracionEntradasAlmacenByArticuloLote = New List(Of totalesAlmacen)
        NuevaListaInventario = New List(Of InventarioMovimiento)
        For Each i As InventarioMovimiento In consulta
            cantidadDeficit = 0
            importeDeficit = 0
            importeDeficitME = 0

            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    If producto = i.idItem AndAlso CodigoLotex = be.nrolote Then
                        productoCache = i.nombreItem
                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec(i.monto)
                        ImporteSaldoME += CDec(i.montoUSD)
                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo
                        importeDeficitME = ImporteSaldoME

                        canSaldo = 0
                        ImporteSaldo = 0
                        ImporteSaldoME = 0

                        canSaldo = canSaldo + i.cantidad2.GetValueOrDefault
                        ImporteSaldo = ImporteSaldo + i.montoOther.GetValueOrDefault
                        ImporteSaldo = ImporteSaldoME + i.montoOtherME.GetValueOrDefault

                        canSaldo = CDec(i.cantidad) + canSaldo
                        ImporteSaldo = CDec(i.monto) + ImporteSaldo
                        ImporteSaldoME = CDec(i.montoUSD) + ImporteSaldoME
                    End If
                    If canSaldo > 0 Then
                        precUnit = ImporteSaldo / canSaldo
                        precUnitME = ImporteSaldoME / canSaldo
                    Else
                        precUnit = 0
                        precUnitME = 0
                    End If
                    pmAcumnulado = precUnit
                    pmAcumnuladoME = precUnitME
                Case "S", "D"
                    Dim co As Decimal = 0
                    Dim coME As Decimal = 0
                    co = CDec(i.cantidad) * pmAcumnulado
                    coME = CDec(i.cantidad) * pmAcumnuladoME

                    If producto = i.idItem AndAlso CodigoLotex = be.nrolote Then
                        productoCache = i.nombreItem
                        Select Case i.tipoOperacion
                            Case "9913"
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo = ImporteSaldo
                                ImporteSaldoME = ImporteSaldoME

                            Case "9914"
                                canSaldo = canSaldo
                                ImporteSaldo += i.monto
                                ImporteSaldoME += i.montoUSD

                            Case "9916"
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += i.monto
                                ImporteSaldoME += i.montoUSD

                            Case StatusTipoOperacion.REVERSIONES
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += i.monto
                                ImporteSaldoME += i.montoUSD

                            Case Else
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += co
                                ImporteSaldoME += coME
                        End Select

                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo
                        importeDeficitME = ImporteSaldoME

                        canSaldo = 0
                        ImporteSaldo = 0
                        ImporteSaldoME = 0

                        canSaldo = canSaldo + i.cantidad2.GetValueOrDefault
                        ImporteSaldo = ImporteSaldo + i.montoOther.GetValueOrDefault
                        ImporteSaldoME = ImporteSaldoME + i.montoOtherME.GetValueOrDefault

                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
                        ImporteSaldoME += CDec((i.cantidad * pmAcumnuladoME))
                    End If

                    If canSaldo > 0 Then
                        precUnit = ImporteSaldo / canSaldo
                    Else
                        precUnit = 0
                    End If
                    pmAcumnulado = precUnit
            End Select

            producto = i.idItem
            CodigoLotex = be.nrolote
            productoCache = i.nombreItem

            NuevaListaInventario.Add(New InventarioMovimiento With {.idEmpresa = i.idEmpresa,
                                                                   .idEstablecimiento = i.idEstablecimiento,
                                                                   .nrolote = be.nrolote,
                                                                   .idAlmacen = i.idAlmacen,
                                                                   .idItem = i.idItem,
                                                                   .descripcion = i.nombreItem,
                                                                   .tipoExistencia = i.tipoProducto,
                                                                   .unidad = i.unidad,
                                                                   .CantSaldo = canSaldo,
                                                                   .saldoMonto = ImporteSaldo,
                                                                   .saldoMontoUsd = ImporteSaldoME})
        Next


        Dim listaAGuardar = (From n In NuevaListaInventario
                             Select n.idItem, n.idAlmacen, n.nrolote
                             Order By idItem).Distinct.ToList()

        'asignando cierre de inventario
        '----------------------------------------------------------------------------------


        For Each c In listaAGuardar
            Dim obj = NuevaListaInventario.Where(Function(o) o.idItem = c.idItem And o.idAlmacen = c.idAlmacen And o.nrolote = c.nrolote).LastOrDefault

            GetCuracionEntradasAlmacenByArticuloLote.Add(New totalesAlmacen With {.idAlmacen = c.idAlmacen,
                                                                   .idItem = obj.idItem,
                                                                   .NroLote = obj.nrolote,
                                                                   .cantidad = obj.CantSaldo,
                                                                   .importeSoles = obj.saldoMonto,
                                                                   .importeDolares = obj.saldoMontoUsd})


        Next

        Return GetCuracionEntradasAlmacenByArticuloLote
    End Function

    'Public Function GetActualizarInventarioSelArticulo(be As InventarioMovimiento, cierre As cierreinventario) As List(Of totalAlmacendetalleitem)
    '    Dim NuevaListaInventario As New List(Of InventarioMovimiento)

    '    Dim precUnit As Decimal = 0
    '    Dim pmAcumnulado As Decimal = 0
    '    Dim saldoCantidadAnual As Decimal = 0
    '    Dim saldoImporteAnual As Decimal = 0
    '    Dim ImporteSaldo As Decimal = 0
    '    Dim canSaldo As Decimal = 0

    '    Dim producto As String = Nothing
    '    Dim cantidadDeficit As Decimal = 0
    '    Dim importeDeficit As Decimal = 0
    '    Dim productoCache As String = Nothing
    '    '''''''''''
    '    Dim consulta = GetMovimientosSelArticulo(be, cierre)
    '    '''''''''''
    '    ImporteSaldo = 0
    '    canSaldo = 0

    '    'ListaCurar = New List(Of totalesAlmacen)
    '    GetActualizarInventarioSelArticulo = New List(Of totalAlmacendetalleitem)
    '    NuevaListaInventario = New List(Of InventarioMovimiento)
    '    For Each i As InventarioMovimiento In consulta
    '        cantidadDeficit = 0
    '        importeDeficit = 0

    '        Select Case i.tipoRegistro
    '            Case "E", "EA", "EC"
    '                If producto = i.idItem Then
    '                    productoCache = i.nombreItem
    '                    canSaldo += CDec(i.cantidad)
    '                    ImporteSaldo += CDec(i.monto)
    '                Else
    '                    cantidadDeficit = canSaldo
    '                    importeDeficit = ImporteSaldo

    '                    canSaldo = 0
    '                    ImporteSaldo = 0

    '                    canSaldo = canSaldo + i.cantidad2.GetValueOrDefault
    '                    ImporteSaldo = ImporteSaldo + i.montoOther.GetValueOrDefault
    '                    canSaldo = CDec(i.cantidad) + canSaldo
    '                    ImporteSaldo = CDec(i.monto) + ImporteSaldo

    '                End If
    '                If canSaldo > 0 Then
    '                    precUnit = ImporteSaldo / canSaldo
    '                Else
    '                    precUnit = 0
    '                End If
    '                pmAcumnulado = precUnit
    '            Case "S", "D"
    '                Dim co As Decimal = 0
    '                co = CDec(i.cantidad) * pmAcumnulado

    '                If producto = i.idItem Then
    '                    productoCache = i.nombreItem
    '                    Select Case i.tipoOperacion
    '                        Case "9913"
    '                            canSaldo += CDec(i.cantidad)
    '                            ImporteSaldo = ImporteSaldo

    '                        Case "9914"
    '                            canSaldo = canSaldo
    '                            ImporteSaldo += i.monto

    '                        Case "9916"
    '                            canSaldo += CDec(i.cantidad)
    '                            ImporteSaldo += i.monto

    '                        Case StatusTipoOperacion.REVERSIONES
    '                            canSaldo += CDec(i.cantidad)
    '                            ImporteSaldo += i.monto

    '                        Case Else
    '                            canSaldo += CDec(i.cantidad)
    '                            ImporteSaldo += co
    '                    End Select

    '                Else
    '                    cantidadDeficit = canSaldo
    '                    importeDeficit = ImporteSaldo

    '                    canSaldo = 0
    '                    ImporteSaldo = 0

    '                    canSaldo = canSaldo + i.cantidad2.GetValueOrDefault
    '                    ImporteSaldo = ImporteSaldo + i.montoOther.GetValueOrDefault

    '                    canSaldo += CDec(i.cantidad)
    '                    ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
    '                End If

    '                If canSaldo > 0 Then
    '                    precUnit = ImporteSaldo / canSaldo
    '                Else
    '                    precUnit = 0
    '                End If
    '                pmAcumnulado = precUnit
    '        End Select

    '        producto = i.idItem
    '        productoCache = i.nombreItem

    '        NuevaListaInventario.Add(New InventarioMovimiento With {.idEmpresa = i.idEmpresa,
    '                                                               .idEstablecimiento = i.idEstablecimiento,
    '                                                               .idAlmacen = i.idAlmacen,
    '                                                               .idItem = i.idItem,
    '                                                               .descripcion = i.nombreItem,
    '                                                               .tipoExistencia = i.tipoProducto,
    '                                                               .unidad = i.unidad,
    '                                                               .CantSaldo = canSaldo,
    '                                                               .saldoMonto = ImporteSaldo})
    '    Next


    '    Dim listaAGuardar = (From n In NuevaListaInventario
    '                         Select n.idItem, n.idAlmacen
    '                         Order By idItem).Distinct.ToList()

    '    'asignando cierre de inventario
    '    '----------------------------------------------------------------------------------


    '    For Each c In listaAGuardar
    '        Dim obj = NuevaListaInventario.Where(Function(o) o.idItem = c.idItem And o.idAlmacen = c.idAlmacen).LastOrDefault

    '        GetActualizarInventarioSelArticulo.Add(New totalAlmacendetalleitem With
    '                                               {
    '                                               .idAlmacen = c.idAlmacen,
    '                                               .codigodetalle = obj.idItem,
    '                                               .cantidad = obj.CantSaldo,
    '                                               .costo = obj.saldoMonto
    '                                               })


    '    Next

    '    '      Return GetActualizarInventarioSelArticulo
    'End Function

    Public Function GetMovimientosKardexByArticulo(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento)
        Dim obj As New InventarioMovimiento
        Dim lista As New List(Of InventarioMovimiento)

        Dim consulta = (From t In HeliosData.InventarioMovimiento
                        Join art In HeliosData.detalleitems
                        On art.codigodetalle Equals t.idItem
                        Group Join lote In HeliosData.recursoCostoLote
                            On lote.codigoLote Equals t.nrolote
                            Into ov2 = Group
                        From x2 In ov2.DefaultIfEmpty()
                        Where
                             CLng(t.fecha.Value.Year) = be.fecha.Value.Year And
                            CLng(t.fecha.Value.Month) = be.fecha.Value.Month And
                            t.idAlmacen = be.idAlmacen And
                            t.tipoProducto = be.tipoProducto And
                            t.idItem = be.idItem
                        Order By art.descripcionItem, t.nrolote, t.fecha Ascending
                        Select
                            x2.nroLote,
                            x2.codigoLote,
                            x2.fechaVcto,
                            t.idInventario,
                            t.fecha,
                            t.idEmpresa,
                            t.idEstablecimiento,
                            t.idAlmacen,
                            t.tipoProducto,
                            t.idDocumento,
                            t.tipoRegistro,
                            t.serie,
                            t.numero,
                            t.tipoOperacion,
                            art.codigodetalle,
                            art.origenProducto,
                            t.descripcion,
                            art.descripcionItem,
                            art.unidad1,
                            t.cantidad,
                            t.monto,
                            DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                    Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                    Select New With
                                                            {
                                                            c.descripcion
                                                            }).FirstOrDefault().descripcion,
                            Valor_venta = (From c In HeliosData.documentoventaAbarrotesDet
                                           Where c.idDocumento = t.idDocumento And c.idItem = t.idItem And
                                               c.codigoLote = t.nrolote
                                           Select New With
                                                       {
                                                       c.montokardex
                                                       }).FirstOrDefault().montokardex).ToList

        'Dim consulta = (From t In HeliosData.InventarioMovimiento _
        '                Join art In HeliosData.detalleitems _
        '                On art.codigodetalle Equals t.idItem _
        '                Where
        '                    CLng(t.fecha.Value.Year) = be.fecha.Value.Year And
        '                    CLng(t.fecha.Value.Month) = be.fecha.Value.Month And
        '                    t.idAlmacen = be.idAlmacen And
        '                    t.tipoProducto = be.tipoProducto And
        '                    t.idItem = be.idItem
        '                Order By art.descripcionItem, t.fecha Ascending
        '                Select
        '                    t.idInventario,
        '                    t.fecha,
        '                    t.idEmpresa,
        '                    t.idAlmacen,
        '                    t.tipoProducto,
        '                    t.idDocumento,
        '                    t.tipoRegistro,
        '                    t.serie,
        '                    t.numero,
        '                    t.tipoOperacion,
        '                    t.idItem,
        '                    t.destinoGravadoItem,
        '                    t.descripcion,
        '                    art.descripcionItem,
        '                    t.unidad,
        '                    t.cantidad,
        '                    t.monto,
        '                    DetalleTipoOperacion = (From c In HeliosData.tabladetalle
        '                                            Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
        '                                            Select New With
        '                                                    {
        '                                                    c.descripcion
        '                                                    }).FirstOrDefault().descripcion,
        '                    CierreCantMesAnterior = (
        '                    ((From c In HeliosData.cierreinventario
        '                      Where
        '                          c.idItem = t.idItem And
        '                          c.idAlmacen = t.idAlmacen And
        '                          CLng(c.anio) = cierre.anio And
        '                          CLng(c.mes) = cierre.mes And
        '                          c.idAlmacen = t.idAlmacen
        '                      Select New With {
        '                          c.cantidad
        '                          }).FirstOrDefault().cantidad)),
        '                    CierreImporteMesAnterior = (
        '                    ((From c In HeliosData.cierreinventario
        '                      Where
        '                          c.idItem = t.idItem And
        '                          c.idAlmacen = t.idAlmacen And
        '                          CLng(c.anio) = cierre.anio And
        '                          CLng(c.mes) = cierre.mes And
        '                          c.idAlmacen = t.idAlmacen
        '                      Select New With {
        '                          c.importe
        '                          }).FirstOrDefault().importe))).ToList


        For Each i In consulta
            obj = New InventarioMovimiento
            obj.customLote = New recursoCostoLote With
                {
                .codigoLote = i.codigoLote,
                .nroLote = i.nroLote,
                .fechaVcto = i.fechaVcto.GetValueOrDefault
            }
            obj.idInventario = i.idInventario
            obj.ValorDeVenta = i.Valor_venta.GetValueOrDefault
            obj.fecha = i.fecha
            obj.idEmpresa = i.idEmpresa
            obj.idEstablecimiento = i.idEstablecimiento
            obj.idAlmacen = i.idAlmacen
            obj.tipoProducto = i.tipoProducto
            obj.idDocumento = i.idDocumento
            obj.tipoRegistro = i.tipoRegistro
            obj.serie = i.serie
            obj.numero = i.numero
            obj.DetalleTipoOperacion = i.DetalleTipoOperacion
            obj.tipoOperacion = i.tipoOperacion
            obj.idItem = i.codigodetalle
            obj.destinoGravadoItem = i.origenProducto
            obj.descripcion = i.descripcionItem
            obj.nombreItem = i.descripcionItem
            obj.unidad = i.unidad1
            obj.cantidad = i.cantidad
            obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
            obj.monto = i.monto
            obj.montoOther = 0 ' i.CierreImporteMesAnterior.GetValueOrDefault
            lista.Add(obj)
        Next
        Return lista
    End Function

    Public Function GetMovimientosKardexByArticuloSNAT(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento)
        Dim obj As New InventarioMovimiento
        Dim lista As New List(Of InventarioMovimiento)

        Dim consulta = (From t In HeliosData.InventarioMovimiento
                        Join art In HeliosData.detalleitems
                        On art.codigodetalle Equals t.idItem
                        Group Join lote In HeliosData.recursoCostoLote
                            On lote.codigoLote Equals t.nrolote
                            Into ov2 = Group
                        From x2 In ov2.DefaultIfEmpty()
                        Where
                            art.estado = "A" And
                            x2.productoSustentado = be.customLote.productoSustentado And
                             CLng(t.fecha.Value.Year) = be.fecha.Value.Year And
                            CLng(t.fecha.Value.Month) = be.fecha.Value.Month And
                            t.idAlmacen = be.idAlmacen And
                            t.tipoProducto = be.tipoProducto And
                            t.idItem = be.idItem
                        Order By art.descripcionItem, t.nrolote, t.fecha Ascending
                        Select
                            x2.nroLote,
                            x2.codigoLote,
                            x2.fechaVcto,
                            x2.productoSustentado,
                            t.idInventario,
                            t.fecha,
                            t.idEmpresa,
                            t.idEstablecimiento,
                            t.idAlmacen,
                            t.tipoProducto,
                            t.idDocumento,
                            t.tipoRegistro,
                            t.serie,
                            t.numero,
                            t.tipoOperacion,
                            art.codigodetalle,
                            art.origenProducto,
                            t.descripcion,
                            art.descripcionItem,
                            art.unidad1,
                            t.cantidad,
                            t.monto,
                            DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                    Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                    Select New With
                                                            {
                                                            c.descripcion
                                                            }).FirstOrDefault().descripcion,
                            Valor_venta = (From c In HeliosData.documentoventaAbarrotesDet
                                           Where c.idDocumento = t.idDocumento And c.idItem = t.idItem And
                                               c.codigoLote = t.nrolote
                                           Select New With
                                                       {
                                                       c.montokardex
                                                       }).FirstOrDefault().montokardex).ToList


        For Each i In consulta
            obj = New InventarioMovimiento
            obj.customLote = New recursoCostoLote With
                {
                .codigoLote = i.codigoLote,
                .nroLote = i.nroLote,
                .fechaVcto = i.fechaVcto.GetValueOrDefault,
                .productoSustentado = i.productoSustentado
            }
            obj.idInventario = i.idInventario
            obj.ValorDeVenta = i.Valor_venta.GetValueOrDefault
            obj.fecha = i.fecha
            obj.idEmpresa = i.idEmpresa
            obj.idEstablecimiento = i.idEstablecimiento
            obj.idAlmacen = i.idAlmacen
            obj.tipoProducto = i.tipoProducto
            obj.idDocumento = i.idDocumento
            obj.tipoRegistro = i.tipoRegistro
            obj.serie = i.serie
            obj.numero = i.numero
            obj.DetalleTipoOperacion = i.DetalleTipoOperacion
            obj.tipoOperacion = i.tipoOperacion
            obj.idItem = i.codigodetalle
            obj.destinoGravadoItem = i.origenProducto
            obj.descripcion = i.descripcionItem
            obj.nombreItem = i.descripcionItem
            obj.unidad = i.unidad1
            obj.cantidad = i.cantidad
            obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
            obj.monto = i.monto
            obj.montoOther = 0 ' i.CierreImporteMesAnterior.GetValueOrDefault
            lista.Add(obj)
        Next
        Return lista
    End Function

    Public Function GetMovimientosKardexByArticuloLote(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento)
        Dim obj As New InventarioMovimiento
        Dim lista As New List(Of InventarioMovimiento)

        Dim consulta = (From t In HeliosData.InventarioMovimiento
                        Join art In HeliosData.detalleitems
                            On art.codigodetalle Equals t.idItem
                        Join lote In HeliosData.recursoCostoLote
                            On lote.codigoLote Equals t.nrolote
                        Where
                             CLng(t.fecha.Value.Year) = be.fecha.Value.Year And
                            CLng(t.fecha.Value.Month) = be.fecha.Value.Month And
                            t.idAlmacen = be.idAlmacen And
                            t.tipoProducto = be.tipoProducto And
                            t.idItem = be.idItem And
                            t.nrolote = be.nrolote
                        Order By art.descripcionItem, t.fecha Ascending
                        Select
                            t.idInventario,
                            t.nrolote,
                            t.fecha,
                            t.idEmpresa,
                            t.idEstablecimiento,
                            t.idAlmacen,
                            t.tipoProducto,
                            t.idDocumento,
                            t.tipoRegistro,
                            t.serie,
                            t.numero,
                            t.tipoOperacion,
                            art.codigodetalle,
                            art.origenProducto,
                            t.descripcion,
                            art.descripcionItem,
                            art.unidad1,
                            t.cantidad,
                            t.monto,
                            t.montoUSD,
                            DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                    Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                    Select New With
                                                            {
                                                            c.descripcion
                                                            }).FirstOrDefault().descripcion,
                            Valor_venta = (From c In HeliosData.documentoventaAbarrotesDet
                                           Where c.idDocumento = t.idDocumento And c.idItem = be.idItem
                                           Select New With
                                                       {
                                                       c.montokardex
                                                       }).FirstOrDefault().montokardex).ToList

        'Dim consulta = (From t In HeliosData.InventarioMovimiento _
        '                Join art In HeliosData.detalleitems _
        '                On art.codigodetalle Equals t.idItem _
        '                Where
        '                    CLng(t.fecha.Value.Year) = be.fecha.Value.Year And
        '                    CLng(t.fecha.Value.Month) = be.fecha.Value.Month And
        '                    t.idAlmacen = be.idAlmacen And
        '                    t.tipoProducto = be.tipoProducto And
        '                    t.idItem = be.idItem
        '                Order By art.descripcionItem, t.fecha Ascending
        '                Select
        '                    t.idInventario,
        '                    t.fecha,
        '                    t.idEmpresa,
        '                    t.idAlmacen,
        '                    t.tipoProducto,
        '                    t.idDocumento,
        '                    t.tipoRegistro,
        '                    t.serie,
        '                    t.numero,
        '                    t.tipoOperacion,
        '                    t.idItem,
        '                    t.destinoGravadoItem,
        '                    t.descripcion,
        '                    art.descripcionItem,
        '                    t.unidad,
        '                    t.cantidad,
        '                    t.monto,
        '                    DetalleTipoOperacion = (From c In HeliosData.tabladetalle
        '                                            Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
        '                                            Select New With
        '                                                    {
        '                                                    c.descripcion
        '                                                    }).FirstOrDefault().descripcion,
        '                    CierreCantMesAnterior = (
        '                    ((From c In HeliosData.cierreinventario
        '                      Where
        '                          c.idItem = t.idItem And
        '                          c.idAlmacen = t.idAlmacen And
        '                          CLng(c.anio) = cierre.anio And
        '                          CLng(c.mes) = cierre.mes And
        '                          c.idAlmacen = t.idAlmacen
        '                      Select New With {
        '                          c.cantidad
        '                          }).FirstOrDefault().cantidad)),
        '                    CierreImporteMesAnterior = (
        '                    ((From c In HeliosData.cierreinventario
        '                      Where
        '                          c.idItem = t.idItem And
        '                          c.idAlmacen = t.idAlmacen And
        '                          CLng(c.anio) = cierre.anio And
        '                          CLng(c.mes) = cierre.mes And
        '                          c.idAlmacen = t.idAlmacen
        '                      Select New With {
        '                          c.importe
        '                          }).FirstOrDefault().importe))).ToList


        For Each i In consulta
            obj = New InventarioMovimiento
            obj.idInventario = i.idInventario
            obj.nrolote = i.nrolote
            obj.ValorDeVenta = i.Valor_venta.GetValueOrDefault
            obj.fecha = i.fecha
            obj.idEmpresa = i.idEmpresa
            obj.idEstablecimiento = i.idEstablecimiento
            obj.idAlmacen = i.idAlmacen
            obj.tipoProducto = i.tipoProducto
            obj.idDocumento = i.idDocumento
            obj.tipoRegistro = i.tipoRegistro
            obj.serie = i.serie
            obj.numero = i.numero
            obj.DetalleTipoOperacion = i.DetalleTipoOperacion
            obj.tipoOperacion = i.tipoOperacion
            obj.idItem = i.codigodetalle
            obj.destinoGravadoItem = i.origenProducto
            obj.descripcion = i.descripcionItem
            obj.nombreItem = i.descripcionItem
            obj.unidad = i.unidad1
            obj.cantidad = i.cantidad
            obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
            obj.monto = i.monto
            obj.montoUSD = i.montoUSD
            obj.montoOther = 0 ' i.CierreImporteMesAnterior.GetValueOrDefault
            obj.montoOtherME = 0
            lista.Add(obj)
        Next
        Return lista
    End Function

    Public Function GetMovimientosSelArticulo(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento)
        Dim obj As New InventarioMovimiento
        Dim lista As New List(Of InventarioMovimiento)

        Dim consulta = (From t In HeliosData.InventarioMovimiento
                        Join art In HeliosData.detalleitems
                            On art.codigodetalle Equals t.idItem
                        Join lote In HeliosData.recursoCostoLote
                            On lote.codigoLote Equals t.nrolote
                        Where
                             CLng(t.fecha.Value.Year) = be.fecha.Value.Year And
                            CLng(t.fecha.Value.Month) = be.fecha.Value.Month And
                            t.idAlmacen = be.idAlmacen And
                            t.tipoProducto = be.tipoProducto And
                            t.idItem = be.idItem
                        Order By art.descripcionItem, t.fecha Ascending
                        Select
                            t.idInventario,
                            t.nrolote,
                            t.fecha,
                            t.idEmpresa,
                            t.idEstablecimiento,
                            t.idAlmacen,
                            t.tipoProducto,
                            t.idDocumento,
                            t.tipoRegistro,
                            t.serie,
                            t.numero,
                            t.tipoOperacion,
                            art.codigodetalle,
                            art.origenProducto,
                            t.descripcion,
                            art.descripcionItem,
                            art.unidad1,
                            t.cantidad,
                            t.monto,
                            DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                    Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                    Select New With
                                                            {
                                                            c.descripcion
                                                            }).FirstOrDefault().descripcion,
                            Valor_venta = (From c In HeliosData.documentoventaAbarrotesDet
                                           Where c.idDocumento = t.idDocumento And c.idItem = be.idItem
                                           Select New With
                                                       {
                                                       c.montokardex
                                                       }).FirstOrDefault().montokardex).ToList




        For Each i In consulta
            obj = New InventarioMovimiento
            obj.idInventario = i.idInventario
            obj.nrolote = i.nrolote
            obj.ValorDeVenta = i.Valor_venta.GetValueOrDefault
            obj.fecha = i.fecha
            obj.idEmpresa = i.idEmpresa
            obj.idEstablecimiento = i.idEstablecimiento
            obj.idAlmacen = i.idAlmacen
            obj.tipoProducto = i.tipoProducto
            obj.idDocumento = i.idDocumento
            obj.tipoRegistro = i.tipoRegistro
            obj.serie = i.serie
            obj.numero = i.numero
            obj.DetalleTipoOperacion = i.DetalleTipoOperacion
            obj.tipoOperacion = i.tipoOperacion
            obj.idItem = i.codigodetalle
            obj.destinoGravadoItem = i.origenProducto
            obj.descripcion = i.descripcionItem
            obj.nombreItem = i.descripcionItem
            obj.unidad = i.unidad1
            obj.cantidad = i.cantidad
            obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
            obj.monto = i.monto
            obj.montoOther = 0 ' i.CierreImporteMesAnterior.GetValueOrDefault
            lista.Add(obj)
        Next
        Return lista
    End Function


    Public Function ObtenerProdPorAlmacenesXMesAllExis(ByVal idAlmacen As String, ByVal year As Integer, ByVal mes As String, ByVal tipoexistencia As String) As List(Of InventarioMovimiento)
        Dim cierreBL As New cierreinventarioBL
        Dim cierre As New cierreinventario
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim producto As String = Nothing
        Dim productoCache As String = Nothing
        Try
            Dim periodoCierre As String = String.Format("{0:00}", mes) & year

            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Where p.idAlmacen = idAlmacen _
                                   And p.fecha.Value.Month = CInt(mes) _
                                   And p.tipoProducto = tipoexistencia _
                                   And p.fecha.Value.Year = year _
                                   Order By q.descripcionItem, p.fecha Ascending _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = q.descripcionItem, _
                                            .marca = p.marca, _
                                            .cantidad = p.cantidad, _
                                            .unidad = p.unidad, _
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = doc.nroDoc, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .tipoOperacion = p.tipoOperacion _
                                           } _
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento
                objInventarioMovimientoBO.idInventario = obj.idInventario
                objInventarioMovimientoBO.fecha = obj.Fecha
                objInventarioMovimientoBO.idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa)
                objInventarioMovimientoBO.idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen)
                objInventarioMovimientoBO.idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem)
                objInventarioMovimientoBO.nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem)
                objInventarioMovimientoBO.marca = obj.marca
                objInventarioMovimientoBO.disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible)
                objInventarioMovimientoBO.status = IIf(IsDBNull(obj.estado), Nothing, obj.estado)
                objInventarioMovimientoBO.tipoRegistro = obj.TipoRegistro.ToString
                objInventarioMovimientoBO.glosa = obj.Glosa
                objInventarioMovimientoBO.NumDocCompra = obj.NroDoc
                objInventarioMovimientoBO.cuentaOrigen = obj.Cuenta
                objInventarioMovimientoBO.idDocumento = obj.IdDocumento
                objInventarioMovimientoBO.tipoProducto = obj.TipoProducto
                objInventarioMovimientoBO.destinoGravadoItem = obj.DestinoGravado
                objInventarioMovimientoBO.tipoOperacion = obj.tipoOperacion
                'cierre = cierreBL.RecuperarCierre(year, mes - 1, obj.idItem)
                objInventarioMovimientoBO.cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad)
                objInventarioMovimientoBO.unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad)
                objInventarioMovimientoBO.precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE)
                objInventarioMovimientoBO.monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto)
                objInventarioMovimientoBO.montoUSD = obj.CostoUS
                'Select Case obj.TipoRegistro
                '    Case "E", "EA", "EC"



                '    Case "S", "D"

                'End Select
                listaInventario.Add(objInventarioMovimientoBO)

                producto = obj.idItem
                productoCache = obj.nombreItem

            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerProdPorAlmacenes(ByVal idAlmacen As String, ByVal strItem As String) As List(Of InventarioMovimiento)
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Try
            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Where p.idAlmacen = idAlmacen _
                                   And p.idItem = strItem _
                                   And p.fecha.Value.Day = CDate(DateTime.Now).Day _
                                   And p.fecha.Value.Month = CDate(DateTime.Now).Month _
                                   And p.fecha.Value.Year = CDate(DateTime.Now).Year
                                   Order By p.fecha _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = q.descripcionItem, _
                                            .marca = p.marca, _
                                            .cantidad = p.cantidad, _
                                            .unidad = p.unidad, _
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = doc.nroDoc, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD _
                                           } _
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento With _
                                            {.idInventario = obj.idInventario, _
                                             .fecha = obj.Fecha, _
                                             .idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa), _
                                             .idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen), _
                                             .idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem), _
                                             .nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem), _
                                             .marca = obj.marca, _
                                             .cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad), _
                                             .unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad), _
                                             .precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE), _
                                             .monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto), _
                                             .disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible), _
                                             .status = IIf(IsDBNull(obj.estado), Nothing, obj.estado), _
                                             .tipoRegistro = obj.TipoRegistro.ToString, _
                                             .glosa = obj.Glosa, _
                                             .NumDocCompra = obj.NroDoc, _
                                             .cuentaOrigen = obj.Cuenta, _
                                             .idDocumento = obj.IdDocumento, _
                                             .tipoProducto = obj.TipoProducto, _
                                             .destinoGravadoItem = obj.DestinoGravado, _
                                             .montoUSD = obj.CostoUS _
                                             }
                listaInventario.Add(objInventarioMovimientoBO)
            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerProdPorAlmacenesXdiaAll(ByVal idAlmacen As String) As List(Of InventarioMovimiento)
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Try
            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Where p.idAlmacen = idAlmacen _
                                   And p.fecha.Value.Day = CDate(DateTime.Now).Day _
                                   And p.fecha.Value.Month = CDate(DateTime.Now).Month _
                                   And p.fecha.Value.Year = CDate(DateTime.Now).Year
                                   Order By q.descripcionItem, p.fecha Ascending _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = q.descripcionItem, _
                                            .marca = q.marcaRef, _
                                            .cantidad = p.cantidad, _
                                            .unidad = p.unidad, _
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = doc.nroDoc, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD _
                                           } _
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento With _
                                            {.idInventario = obj.idInventario, _
                                             .fecha = obj.Fecha, _
                                             .idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa), _
                                             .idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen), _
                                             .idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem), _
                                             .nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem), _
                                             .marca = obj.marca, _
                                             .cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad), _
                                             .unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad), _
                                             .precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE), _
                                             .monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto), _
                                             .disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible), _
                                             .status = IIf(IsDBNull(obj.estado), Nothing, obj.estado), _
                                             .tipoRegistro = obj.TipoRegistro.ToString, _
                                             .glosa = obj.Glosa, _
                                             .NumDocCompra = obj.NroDoc, _
                                             .cuentaOrigen = obj.Cuenta, _
                                             .idDocumento = obj.IdDocumento, _
                                             .tipoProducto = obj.TipoProducto, _
                                             .destinoGravadoItem = obj.DestinoGravado, _
                                             .montoUSD = obj.CostoUS _
                                             }
                listaInventario.Add(objInventarioMovimientoBO)
            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerItmesPorAlmacen(ByVal idAlmacen As String) As List(Of InventarioMovimiento)
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Try
            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Where p.idAlmacen = idAlmacen _
                                   Order By p.idItem, p.fecha _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = q.descripcionItem, _
                                            .cantidad = p.cantidad, _
                                            .unidad = p.unidad, _
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = doc.nroDoc, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD _
                                           } _
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento With _
                                            {.idInventario = obj.idInventario, _
                                             .fecha = obj.Fecha, _
                                             .idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa), _
                                             .idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen), _
                                             .idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem), _
                                             .nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem), _
                                             .cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad), _
                                             .unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad), _
                                             .precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE), _
                                             .monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto), _
                                             .disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible), _
                                             .status = IIf(IsDBNull(obj.estado), Nothing, obj.estado), _
                                             .tipoRegistro = obj.TipoRegistro.ToString, _
                                             .glosa = obj.Glosa, _
                                             .NumDocCompra = obj.NroDoc, _
                                             .cuentaOrigen = obj.Cuenta, _
                                             .idDocumento = obj.IdDocumento, _
                                             .tipoProducto = obj.TipoProducto, _
                                             .destinoGravadoItem = obj.DestinoGravado, _
                                             .montoUSD = obj.CostoUS _
                                             }
                listaInventario.Add(objInventarioMovimientoBO)
            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Function ObtenerProductosEnTransito(ByVal strIdEmpresa As String, ByVal strIdEstablecimiento As String, ByVal strTipoAlmacen As String, ByVal Mes As String, ByVal Anio As String, ByVal strTipoProducto As String) As List(Of InventarioMovimiento)
    '    Dim objInventarioMovimientoBO As InventarioMovimiento
    '    Dim listaInventario As New List(Of InventarioMovimiento)
    '    Dim tablaSA As New tabladetalleBL
    '    'Dim inventarioConsulta = (From inv In HeliosData.InventarioMovimiento _
    '    '                          Join a In HeliosData.almacen On inv.idAlmacen Equals a.idAlmacen
    '    '                          Join dc In HeliosData.documentocompra On inv.idDocumento Equals dc.idDocumento _
    '    '                          Join ent In HeliosData.entidad On dc.idProveedor Equals ent.idEntidad _
    '    '                          Where inv.idEmpresa = strIdEmpresa And inv.idEstablecimiento = strIdEstablecimiento And inv.status = "D" _
    '    '                        And a.tipo = strTipoAlmacen And Month(inv.fecha) = Mes And Year(inv.fecha) = Anio _
    '    '                        And inv.tipoProducto = strTipoProducto).ToList

    '    'For Each obj In inventarioConsulta
    '    '    objInventarioMovimientoBO = New InventarioMovimiento() With _
    '    '                                {
    '    '                                    .idInventario = obj.inv.idInventario,
    '    '                                    .destinoGravadoItem = IIf(IsDBNull(obj.inv.destinoGravadoItem), Nothing, obj.inv.destinoGravadoItem),
    '    '                                    .tipoProducto = IIf(IsDBNull(obj.inv.tipoProducto), Nothing, obj.inv.tipoProducto),
    '    '                                    .idAlmacen = IIf(IsDBNull(obj.inv.idAlmacen), Nothing, obj.inv.idAlmacen),
    '    '                                    .NombreAlmacen = IIf(IsDBNull(obj.a.descripcionAlmacen), Nothing, obj.a.descripcionAlmacen),
    '    '                                    .idDocumento = IIf(IsDBNull(obj.inv.idDocumento), Nothing, obj.inv.idDocumento),
    '    '                                    .idDocumentoRef = IIf(IsDBNull(obj.inv.idDocumentoRef), Nothing, obj.inv.idDocumentoRef),
    '    '                                    .idItem = IIf(IsDBNull(obj.inv.idItem), Nothing, obj.inv.idItem),
    '    '                                    .descripcion = IIf(IsDBNull(obj.inv.descripcion), Nothing, obj.inv.descripcion),
    '    '                                    .precUnite = IIf(IsDBNull(obj.inv.precUnite), Nothing, obj.inv.precUnite),
    '    '                                    .cantidad = IIf(IsDBNull(obj.inv.cantidad), Nothing, obj.inv.cantidad),
    '    '                                    .unidad = IIf(IsDBNull(obj.inv.unidad), Nothing, obj.inv.unidad),
    '    '                                    .monto = IIf(IsDBNull(obj.inv.monto), Nothing, obj.inv.monto),
    '    '                                    .montoUSD = IIf(IsDBNull(obj.inv.montoUSD), Nothing, obj.inv.montoUSD),
    '    '                                    .cuentaOrigen = IIf(IsDBNull(obj.inv.cuentaOrigen), Nothing, obj.inv.cuentaOrigen),
    '    '                                    .fecha = IIf(IsDBNull(obj.inv.fecha), Nothing, obj.inv.fecha),
    '    '                                    .ComprobanteCompra = IIf(IsDBNull(obj.dc.tipoDoc), Nothing, obj.dc.tipoDoc),
    '    '                                    .NumDocCompra = IIf(IsDBNull(obj.dc.serie & "-" & obj.dc.numeroDoc), Nothing, obj.dc.serie & "-" & obj.dc.numeroDoc),
    '    '                                    .TipoCambio = IIf(IsDBNull(obj.dc.tcDolLoc), Nothing, obj.dc.tcDolLoc),
    '    '                                    .precUniteUSD = IIf(IsDBNull(obj.inv.precUniteUSD), Nothing, obj.inv.precUniteUSD),
    '    '                                    .preEvento = IIf(IsDBNull(obj.inv.preEvento), Nothing, obj.inv.preEvento),
    '    '                                    .glosa = IIf(IsDBNull(obj.inv.descripcion), "s/c", obj.inv.descripcion),
    '    '                                    .fechavcto = IIf(IsDBNull(obj.inv.fechavcto), Nothing, obj.inv.fechavcto),
    '    '                                    .presentacion = IIf(IsDBNull(obj.inv.presentacion), Nothing, obj.inv.presentacion),
    '    '                                    .IdProveedor = IIf(IsDBNull(obj.ent.idEntidad), Nothing, obj.ent.idEntidad),
    '    '                                    .nombreProveedor = IIf(IsDBNull(obj.ent.nombreCompleto), Nothing, obj.ent.nombreCompleto),
    '    '                                    .tipoRegistro = obj.inv.tipoRegistro
    '    '                                }
    '    '    listaInventario.Add(objInventarioMovimientoBO)
    '    'Next

    '    'Return listaInventario


    '    'Dim inventarios = (From p In HeliosData.InventarioMovimiento _
    '    '                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
    '    '                   Join a In HeliosData.almacen On p.idAlmacen Equals a.idAlmacen
    '    '                   Join dc In HeliosData.documentocompra On p.idDocumento Equals dc.idDocumento _
    '    '                   Join dct In HeliosData.documentocompradetalle On p.idDocumento Equals dct.idDocumento _
    '    '                   And p.idItem Equals dct.idItem _
    '    '                   Join pr In HeliosData.entidad On dc.idProveedor Equals pr.idEntidad _
    '    '                   Join t In HeliosData.tabladetalle On p.presentacion Equals t.codigoDetalle _
    '    '                   Where p.idEmpresa = strIdEmpresa And p.idEstablecimiento = strIdEstablecimiento And p.status = "D" _
    '    '                   And a.tipo = strTipoAlmacen And Month(p.fecha) = Mes And Year(p.fecha) = Anio _
    '    '                   And p.tipoProducto = strTipoProducto And t.idtabla = 21).ToList


    '    'Join t In HeliosData.tabladetalle On p.presentacion Equals t.codigoDetalle _And t.idtabla = 21

    '    '
    '    '

    '    Dim inventarios = (From p In HeliosData.InventarioMovimiento _
    '                      Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
    '                      Join a In HeliosData.almacen On p.idAlmacen Equals a.idAlmacen
    '                      Join dc In HeliosData.documentocompra On p.idDocumento Equals dc.idDocumento _
    '                      Join pr In HeliosData.entidad On dc.idProveedor Equals pr.idEntidad _
    '                      Where p.idEmpresa = strIdEmpresa And p.idEstablecimiento = strIdEstablecimiento And p.status = "D" _
    '                      And a.tipo = strTipoAlmacen _
    '                      And p.tipoProducto = strTipoProducto).ToList


    '    For Each obj In inventarios

    '        objInventarioMovimientoBO = New InventarioMovimiento()

    '        objInventarioMovimientoBO.idInventario = obj.p.idInventario
    '        objInventarioMovimientoBO.destinoGravadoItem = IIf(IsDBNull(obj.p.destinoGravadoItem), Nothing, obj.p.destinoGravadoItem)
    '        objInventarioMovimientoBO.tipoProducto = IIf(IsDBNull(obj.p.tipoProducto), Nothing, obj.p.tipoProducto)
    '        objInventarioMovimientoBO.idAlmacen = IIf(IsDBNull(obj.p.idAlmacen), Nothing, obj.p.idAlmacen)
    '        objInventarioMovimientoBO.NombreAlmacen = IIf(IsDBNull(obj.a.descripcionAlmacen), Nothing, obj.a.descripcionAlmacen)
    '        objInventarioMovimientoBO.idDocumento = IIf(IsDBNull(obj.p.idDocumento), Nothing, obj.p.idDocumento)
    '        objInventarioMovimientoBO.idDocumentoRef = IIf(IsDBNull(obj.p.idDocumentoRef), Nothing, obj.p.idDocumentoRef)
    '        objInventarioMovimientoBO.idItem = IIf(IsDBNull(obj.p.idItem), Nothing, obj.p.idItem)
    '        objInventarioMovimientoBO.descripcion = IIf(IsDBNull(obj.q.descripcionItem), Nothing, obj.q.descripcionItem)
    '        objInventarioMovimientoBO.precUnite = IIf(IsDBNull(obj.p.precUnite), Nothing, obj.p.precUnite)
    '        objInventarioMovimientoBO.cantidad = IIf(IsDBNull(obj.p.cantidad), Nothing, obj.p.cantidad)
    '        objInventarioMovimientoBO.unidad = IIf(IsDBNull(obj.p.unidad), Nothing, obj.p.unidad)
    '        objInventarioMovimientoBO.monto = IIf(IsDBNull(obj.p.monto), Nothing, obj.p.monto)
    '        objInventarioMovimientoBO.montoUSD = IIf(IsDBNull(obj.p.montoUSD), Nothing, obj.p.montoUSD)
    '        objInventarioMovimientoBO.cuentaOrigen = IIf(IsDBNull(obj.p.cuentaOrigen), Nothing, obj.p.cuentaOrigen)
    '        objInventarioMovimientoBO.fecha = IIf(IsDBNull(obj.p.fecha), Nothing, obj.p.fecha)
    '        objInventarioMovimientoBO.ComprobanteCompra = IIf(IsDBNull(obj.dc.tipoDoc), Nothing, obj.dc.tipoDoc)
    '        objInventarioMovimientoBO.NumDocCompra = IIf(IsDBNull(obj.dc.serie & "-" & obj.dc.numeroDoc), Nothing, obj.dc.serie & "-" & obj.dc.numeroDoc)
    '        objInventarioMovimientoBO.TipoCambio = IIf(IsDBNull(obj.dc.tcDolLoc), Nothing, obj.dc.tcDolLoc)
    '        objInventarioMovimientoBO.precUniteUSD = IIf(IsDBNull(obj.p.precUniteUSD), Nothing, obj.p.precUniteUSD)
    '        objInventarioMovimientoBO.preEvento = IIf(IsDBNull(obj.p.preEvento), Nothing, obj.p.preEvento)
    '        objInventarioMovimientoBO.glosa = IIf(IsDBNull(obj.p.descripcion), "s/c", obj.p.descripcion)
    '        objInventarioMovimientoBO.fechavcto = IIf(IsDBNull(obj.p.fechavcto), Nothing, obj.p.fechavcto)
    '        objInventarioMovimientoBO.presentacion = IIf(IsDBNull(obj.p.presentacion), Nothing, obj.p.presentacion)
    '        objInventarioMovimientoBO.IdProveedor = IIf(IsDBNull(obj.dc.idProveedor), Nothing, obj.dc.idProveedor)
    '        objInventarioMovimientoBO.nombreProveedor = IIf(IsDBNull(obj.pr.nombreCompleto), Nothing, obj.pr.nombreCompleto)
    '        If IsNothing(obj.p.presentacion) Then
    '            objInventarioMovimientoBO.NombrePresentacion = Nothing
    '        Else
    '            objInventarioMovimientoBO.NombrePresentacion = tablaSA.GetUbicarTablaID(21, obj.p.presentacion).descripcion
    '        End If
    '        objInventarioMovimientoBO.Secuencia = obj.p.idorigenDetalle
    '        listaInventario.Add(objInventarioMovimientoBO)
    '    Next

    '    Return listaInventario

    'End Function

    'Public Function ObtenerProductosEnTransito(ByVal strIdEmpresa As String, ByVal strIdEstablecimiento As String, ByVal strTipoAlmacen As String, ByVal Mes As String, ByVal Anio As String, ByVal strTipoProducto As String) As List(Of InventarioMovimiento)
    '    Dim objInventarioMovimientoBO As InventarioMovimiento
    '    Dim listaInventario As New List(Of InventarioMovimiento)
    '    Dim inventarios = (From p In HeliosData.InventarioMovimiento _
    '                       Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
    '                       Join a In HeliosData.almacen On p.idAlmacen Equals a.idAlmacen
    '                       Join dc In HeliosData.documentocompra On p.idDocumento Equals dc.idDocumento _
    '                       Join dct In HeliosData.documentocompradetalle On p.idDocumento Equals dct.idDocumento _
    '                       And p.idItem Equals dct.idItem _
    '                       Join pr In HeliosData.entidad On dc.idProveedor Equals pr.idEntidad _
    '                       Join t In HeliosData.tabladetalle On p.presentacion Equals t.codigoDetalle _
    '                       Where p.idEmpresa = strIdEmpresa And p.idEstablecimiento = strIdEstablecimiento And p.status = "D" _
    '                       And a.tipo = strTipoAlmacen And Month(p.fecha) = Mes And Year(p.fecha) = Anio _
    '                       And p.tipoProducto = strTipoProducto And t.idtabla = 21).ToList


    '    For Each obj In inventarios
    '        objInventarioMovimientoBO = New InventarioMovimiento() With _
    '                                    {
    '                                        .idInventario = obj.p.idInventario,
    '                                        .destinoGravadoItem = IIf(IsDBNull(obj.p.destinoGravadoItem), Nothing, obj.p.destinoGravadoItem),
    '                                        .tipoProducto = IIf(IsDBNull(obj.p.tipoProducto), Nothing, obj.p.tipoProducto),
    '                                        .idAlmacen = IIf(IsDBNull(obj.p.idAlmacen), Nothing, obj.p.idAlmacen),
    '                                        .NombreAlmacen = IIf(IsDBNull(obj.a.descripcionAlmacen), Nothing, obj.a.descripcionAlmacen),
    '                                        .idDocumento = IIf(IsDBNull(obj.p.idDocumento), Nothing, obj.p.idDocumento),
    '                                        .idDocumentoRef = IIf(IsDBNull(obj.p.idDocumentoRef), Nothing, obj.p.idDocumentoRef),
    '                                        .idItem = IIf(IsDBNull(obj.p.idItem), Nothing, obj.p.idItem),
    '                                        .descripcion = IIf(IsDBNull(obj.q.descripcionItem), Nothing, obj.q.descripcionItem),
    '                                        .precUnite = IIf(IsDBNull(obj.p.precUnite), Nothing, obj.p.precUnite),
    '                                        .cantidad = IIf(IsDBNull(obj.p.cantidad), Nothing, obj.p.cantidad),
    '                                        .unidad = IIf(IsDBNull(obj.p.unidad), Nothing, obj.p.unidad),
    '                                        .monto = IIf(IsDBNull(obj.p.monto), Nothing, obj.p.monto),
    '                                        .montoUSD = IIf(IsDBNull(obj.p.montoUSD), Nothing, obj.p.montoUSD),
    '                                        .cuentaOrigen = IIf(IsDBNull(obj.p.cuentaOrigen), Nothing, obj.p.cuentaOrigen),
    '                                        .fecha = IIf(IsDBNull(obj.p.fecha), Nothing, obj.p.fecha),
    '                                        .ComprobanteCompra = IIf(IsDBNull(obj.dc.tipoDoc), Nothing, obj.dc.tipoDoc),
    '                                        .NumDocCompra = IIf(IsDBNull(obj.dc.serie & "-" & obj.dc.numeroDoc), Nothing, obj.dc.serie & "-" & obj.dc.numeroDoc),
    '                                        .TipoCambio = IIf(IsDBNull(obj.dc.tcDolLoc), Nothing, obj.dc.tcDolLoc),
    '                                        .precUniteUSD = IIf(IsDBNull(obj.p.precUniteUSD), Nothing, obj.p.precUniteUSD),
    '                                        .preEvento = IIf(IsDBNull(obj.p.preEvento), Nothing, obj.p.preEvento),
    '                                        .glosa = IIf(IsDBNull(obj.p.descripcion), "s/c", obj.p.descripcion),
    '                                        .fechavcto = IIf(IsDBNull(obj.p.fechavcto), Nothing, obj.p.fechavcto),
    '                                        .presentacion = IIf(IsDBNull(obj.p.presentacion), Nothing, obj.p.presentacion),
    '                                        .IdProveedor = IIf(IsDBNull(obj.dc.idProveedor), Nothing, obj.dc.idProveedor),
    '                                        .nombreProveedor = IIf(IsDBNull(obj.pr.nombreCompleto), Nothing, obj.pr.nombreCompleto),
    '                                        .NombrePresentacion = IIf(IsDBNull(obj.t.descripcion), Nothing, obj.t.descripcion),
    '                                        .Secuencia = obj.dct.secuencia
    '                                                             }
    '        listaInventario.Add(objInventarioMovimientoBO)
    '    Next

    '    Return listaInventario

    'End Function

    Public Function ObtenerProductosEnTransitoPorDocumento(ByVal strIdEmpresa As String, ByVal strIdEstablecimiento As String, ByVal strTipoAlmacen As String, ByVal Mes As String, ByVal Anio As String, ByVal strTipoProducto As String,
                                                           strNumDocCompra As String) As List(Of InventarioMovimiento)
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                           Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                           Join a In HeliosData.almacen On p.idAlmacen Equals a.idAlmacen
                           Join dc In HeliosData.documentocompra On p.idDocumento Equals dc.idDocumento _
                           Join dct In HeliosData.documentocompradetalle On p.idDocumento Equals dct.idDocumento _
                           And p.idItem Equals dct.idItem _
                           Join pr In HeliosData.entidad On dc.idProveedor Equals pr.idEntidad _
                           Join t In HeliosData.tabladetalle On p.presentacion Equals t.codigoDetalle _
                           Where p.idEmpresa = strIdEmpresa And p.idEstablecimiento = strIdEstablecimiento And p.status = "D" _
                           And a.tipo = strTipoAlmacen And Month(p.fecha) = Mes And Year(p.fecha) = Anio _
                           And p.tipoProducto = strTipoProducto And t.idtabla = 21 _
                           And dc.numeroDoc.Contains(strNumDocCompra)).ToList


        For Each obj In inventarios
            objInventarioMovimientoBO = New InventarioMovimiento() With _
                                        {
                                            .idInventario = obj.p.idInventario,
                                            .destinoGravadoItem = IIf(IsDBNull(obj.p.destinoGravadoItem), Nothing, obj.p.destinoGravadoItem),
                                            .tipoProducto = IIf(IsDBNull(obj.p.tipoProducto), Nothing, obj.p.tipoProducto),
                                            .idAlmacen = IIf(IsDBNull(obj.p.idAlmacen), Nothing, obj.p.idAlmacen),
                                            .NombreAlmacen = IIf(IsDBNull(obj.a.descripcionAlmacen), Nothing, obj.a.descripcionAlmacen),
                                            .idDocumento = IIf(IsDBNull(obj.p.idDocumento), Nothing, obj.p.idDocumento),
                                            .idDocumentoRef = IIf(IsDBNull(obj.p.idDocumentoRef), Nothing, obj.p.idDocumentoRef),
                                            .idItem = IIf(IsDBNull(obj.p.idItem), Nothing, obj.p.idItem),
                                            .descripcion = IIf(IsDBNull(obj.q.descripcionItem), Nothing, obj.q.descripcionItem),
                                            .precUnite = IIf(IsDBNull(obj.p.precUnite), Nothing, obj.p.precUnite),
                                            .cantidad = IIf(IsDBNull(obj.p.cantidad), Nothing, obj.p.cantidad),
                                            .unidad = IIf(IsDBNull(obj.p.unidad), Nothing, obj.p.unidad),
                                            .monto = IIf(IsDBNull(obj.p.monto), Nothing, obj.p.monto),
                                            .montoUSD = IIf(IsDBNull(obj.p.montoUSD), Nothing, obj.p.montoUSD),
                                            .cuentaOrigen = IIf(IsDBNull(obj.p.cuentaOrigen), Nothing, obj.p.cuentaOrigen),
                                            .fecha = IIf(IsDBNull(obj.p.fecha), Nothing, obj.p.fecha),
                                            .ComprobanteCompra = IIf(IsDBNull(obj.dc.tipoDoc), Nothing, obj.dc.tipoDoc),
                                            .NumDocCompra = IIf(IsDBNull(obj.dc.serie & "-" & obj.dc.numeroDoc), Nothing, obj.dc.serie & "-" & obj.dc.numeroDoc),
                                            .TipoCambio = IIf(IsDBNull(obj.dc.tcDolLoc), Nothing, obj.dc.tcDolLoc),
                                            .precUniteUSD = IIf(IsDBNull(obj.p.precUniteUSD), Nothing, obj.p.precUniteUSD),
                                            .preEvento = IIf(IsDBNull(obj.p.preEvento), Nothing, obj.p.preEvento),
                                            .glosa = IIf(IsDBNull(obj.p.descripcion), "s/c", obj.p.descripcion),
                                            .fechavcto = IIf(IsDBNull(obj.p.fechavcto), Nothing, obj.p.fechavcto),
                                            .presentacion = IIf(IsDBNull(obj.p.presentacion), Nothing, obj.p.presentacion),
                                            .IdProveedor = IIf(IsDBNull(obj.dc.idProveedor), Nothing, obj.dc.idProveedor),
                                            .nombreProveedor = IIf(IsDBNull(obj.pr.nombreCompleto), Nothing, obj.pr.nombreCompleto),
                                            .NombrePresentacion = IIf(IsDBNull(obj.t.descripcion), Nothing, obj.t.descripcion),
                                            .Secuencia = obj.dct.secuencia
                                                                 }
            listaInventario.Add(objInventarioMovimientoBO)
        Next

        Return listaInventario

    End Function


    Public Function SaveOrigen2(ByVal objCollectionSalida As List(Of InventarioMovimiento)) As Boolean
        Dim ObjDistribucion As New InventarioMovimiento()
        Dim valConteo As Short
        Dim valId As Integer
        Dim objinventario As New InventarioMovimiento
        Try

            Using ts As New TransactionScope()
                For Each i In objCollectionSalida

                    valId = i.idInventario
                    valConteo = (From n In HeliosData.InventarioMovimiento _
                          Where n.idInventario = valId And n.entragado = "NO").Count

                    objinventario = (From s In HeliosData.InventarioMovimiento _
                                    Where s.idInventario = valId).First

                    objinventario.status = "P"

                    If valConteo > 0 Then
                        ObjDistribucion = New InventarioMovimiento
                        ObjDistribucion.idEmpresa = i.idEmpresa
                        ObjDistribucion.idEstablecimiento = i.idEstablecimiento
                        ObjDistribucion.idAlmacen = i.idAlmacen
                        ObjDistribucion.tipoOperacion = i.tipoOperacion
                        ObjDistribucion.tipoDocAlmacen = i.tipoDocAlmacen
                        ObjDistribucion.serie = i.serie
                        ObjDistribucion.numero = i.numero
                        ObjDistribucion.idDocumento = i.idDocumento
                        ObjDistribucion.idDocumentoRef = i.idDocumentoRef
                        ObjDistribucion.descripcion = i.descripcion
                        ObjDistribucion.fecha = i.fecha
                        ObjDistribucion.tipoRegistro = i.tipoRegistro
                        ObjDistribucion.destinoGravadoItem = i.destinoGravadoItem
                        ObjDistribucion.tipoProducto = i.tipoProducto
                        ObjDistribucion.OrigentipoProducto = i.OrigentipoProducto
                        ObjDistribucion.cuentaOrigen = i.cuentaOrigen
                        ObjDistribucion.idItem = i.idItem
                        ObjDistribucion.presentacion = i.presentacion
                        ObjDistribucion.fechavcto = i.fechavcto
                        ObjDistribucion.cantidad = i.cantidad
                        ObjDistribucion.unidad = i.unidad
                        ObjDistribucion.cantidad2 = i.cantidad2
                        ObjDistribucion.unidad2 = i.unidad2
                        ObjDistribucion.precUnite = i.precUnite
                        ObjDistribucion.precUniteUSD = i.precUniteUSD
                        ObjDistribucion.monto = i.monto
                        ObjDistribucion.montoUSD = i.montoUSD
                        ObjDistribucion.montoOther = i.montoOther
                        ObjDistribucion.monedaOther = i.monedaOther
                        ObjDistribucion.disponible = i.disponible
                        ObjDistribucion.disponible2 = i.disponible2
                        ObjDistribucion.saldoMonto = i.saldoMonto
                        ObjDistribucion.saldoMontoUsd = i.saldoMontoUsd
                        ObjDistribucion.status = i.status
                        ObjDistribucion.entragado = i.entragado
                        ObjDistribucion.preEvento = i.preEvento
                        ObjDistribucion.usuarioActualizacion = i.usuarioActualizacion
                        ObjDistribucion.fechaActualizacion = Date.Now
                        HeliosData.InventarioMovimiento.Add(ObjDistribucion)
                    ElseIf valConteo = 0 Then
                        Continue For
                    End If
                Next
                HeliosData.SaveChanges()
                ts.Complete()
                Return True
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveDestino(ByVal objEntrada As List(Of InventarioMovimiento)) As Boolean
        Dim ObjDistribucion As New InventarioMovimiento()
        Dim valConteo As Short
        Dim valId As Integer
        '   Dim ObjListMascaraEx As New HeliosBL.MascaraContable2BOList()
        '   Dim objListaExistencia() As HeliosBL.MascaraContable2BO
        Dim objinventario As New InventarioMovimiento()
        Try
            Using ts As New TransactionScope()
                '   With objinventario
                For Each i In objEntrada

                    valId = i.idInventario
                    valConteo = (From n In HeliosData.InventarioMovimiento _
                          Where n.idInventario = valId And n.entragado = "NO").Count

                    objinventario = (From s In HeliosData.InventarioMovimiento _
                                    Where s.idInventario = valId).First

                    objinventario.entragado = "SI"

                    If valConteo > 0 Then
                        ObjDistribucion = New InventarioMovimiento()
                        ObjDistribucion.idEmpresa = i.idEmpresa
                        ObjDistribucion.idEstablecimiento = i.idEstablecimiento
                        ObjDistribucion.idAlmacen = i.idAlmacen
                        ObjDistribucion.tipoOperacion = i.tipoOperacion
                        ObjDistribucion.tipoDocAlmacen = i.tipoDocAlmacen
                        ObjDistribucion.serie = i.serie
                        ObjDistribucion.numero = i.numero
                        ObjDistribucion.idDocumento = i.idDocumento
                        ObjDistribucion.idDocumentoRef = i.idDocumentoRef
                        ObjDistribucion.descripcion = i.descripcion
                        ObjDistribucion.fecha = i.fecha
                        ObjDistribucion.tipoRegistro = i.tipoRegistro
                        ObjDistribucion.destinoGravadoItem = i.destinoGravadoItem
                        ObjDistribucion.tipoProducto = i.tipoProducto
                        ObjDistribucion.OrigentipoProducto = i.OrigentipoProducto
                        ObjDistribucion.cuentaOrigen = i.cuentaOrigen
                        ObjDistribucion.idItem = i.idItem
                        ObjDistribucion.presentacion = i.presentacion
                        ObjDistribucion.fechavcto = i.fechavcto
                        ObjDistribucion.cantidad = i.cantidad
                        ObjDistribucion.unidad = i.unidad
                        ObjDistribucion.cantidad2 = i.cantidad2
                        ObjDistribucion.unidad2 = i.unidad2
                        ObjDistribucion.precUnite = i.precUnite
                        ObjDistribucion.precUniteUSD = i.precUniteUSD
                        ObjDistribucion.monto = i.monto
                        ObjDistribucion.montoUSD = i.montoUSD
                        ObjDistribucion.montoOther = i.montoOther
                        ObjDistribucion.monedaOther = i.monedaOther
                        ObjDistribucion.disponible = i.disponible
                        ObjDistribucion.disponible2 = i.disponible2
                        ObjDistribucion.saldoMonto = i.saldoMonto
                        ObjDistribucion.saldoMontoUsd = i.saldoMontoUsd
                        ObjDistribucion.status = i.status
                        ObjDistribucion.entragado = i.entragado
                        ObjDistribucion.preEvento = i.preEvento
                        ObjDistribucion.usuarioActualizacion = i.usuarioActualizacion
                        ObjDistribucion.fechaActualizacion = Date.Now
                        HeliosData.InventarioMovimiento.Add(ObjDistribucion)

                    ElseIf valConteo = 0 Then
                        Continue For
                    End If
                Next
                '  ObjContext.AddToInventarioMovimiento(objinventario)
                HeliosData.SaveChanges()
                ts.Complete()
                Return True
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertItemsEnTransito(ByVal objSalida As List(Of InventarioMovimiento),
                                 ByVal objEntrada As List(Of InventarioMovimiento),
                                 ByVal listaAsiento As List(Of asiento),
                                 ByVal objTotalesAlmacen As List(Of totalesAlmacen), documento As documento,
                                 totalesAlmAV As List(Of totalesAlmacen))

        Dim totalesBL As New totalesAlmacenBL
        Dim AsientoBL As New AsientoBL
        Dim guiaBL As New documentoGuiaBL
        Using ts As New TransactionScope()
            guiaBL.InsertGuiaDistribucion(documento)
            ' ActualizarAlmacenCompra(objEntrada)
            '  UpdateCollections(objSalida)
            SaveOrigen2(objSalida) ' -- ORIGEN(S) COLLECTIONS SALIDA
            SaveDestino(objEntrada) ' -- DESTINO(E) COLLECTIONS ENTRADAS
            totalesBL.SaveTotalesLista(objTotalesAlmacen, 0)
            totalesBL.DeleteTotalesAlmacen(totalesAlmAV)
            AsientoBL.SavebyGroup(listaAsiento)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub InsertItemsEnTransitoSL(ByVal objSalida As List(Of InventarioMovimiento),
                            ByVal objEntrada As List(Of InventarioMovimiento),
                            ByVal listaAsiento As List(Of asiento),
                            ByVal objTotalesAlmacen As List(Of totalesAlmacen), documento As documento,
                            totalesAlmAV As List(Of totalesAlmacen),
                            ByVal objListaPrecios As List(Of listadoPrecios))

        Dim totalesBL As New totalesAlmacenBL
        Dim AsientoBL As New AsientoBL
        Dim guiaBL As New documentoGuiaBL
        Dim lista As New listadoPreciosBL
        Using ts As New TransactionScope()
            guiaBL.InsertGuiaDistribucionSL(documento)
            SaveOrigen2(objSalida) ' -- ORIGEN(S) COLLECTIONS SALIDA
            SaveDestino(objEntrada) ' -- DESsqlTINO(E) COLLECTIONS ENTRADAS
            totalesBL.SaveTotalesLista(objTotalesAlmacen, 0)
            totalesBL.DeleteTotalesAlmacen(totalesAlmAV)
            AsientoBL.SavebyGroup(listaAsiento)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub InsertAV(ByVal InventarioMovimientoBE As documentocompradetalle, intIdDocumento As documento)
        Using ts As New TransactionScope
            Insert(InventarioMovimientoBE, intIdDocumento)
            HeliosData.SaveChanges()
            ts.Complete()

        End Using
    End Sub

    Public Sub InsertVentaTicket(ByVal InventarioMovimientoBE As documentoventaAbarrotesDet, intIdDocumento As documento)
        Using ts As New TransactionScope
            InsertVentaPagada(InventarioMovimientoBE, intIdDocumento)
            HeliosData.SaveChanges()
            ts.Complete()

        End Using
    End Sub

    Public Function InsertTransferencia(ByVal InventarioMovimientoBE As documentocompradetalle) As Integer
        Dim objInventario As New InventarioMovimiento
        Dim almacenBL As New almacenBL
        Using ts As New TransactionScope
            objInventario = New InventarioMovimiento
            objInventario.idorigenDetalle = InventarioMovimientoBE.secuencia
            objInventario.idEmpresa = InventarioMovimientoBE.IdEmpresa
            objInventario.idEstablecimiento = InventarioMovimientoBE.IdEstablecimiento
            objInventario.tipoOperacion = InventarioMovimientoBE.TipoOperacion
            objInventario.nrolote = InventarioMovimientoBE.codigoLote
            objInventario.tipoDocAlmacen = InventarioMovimientoBE.TipoDoc
            objInventario.serie = InventarioMovimientoBE.Serie
            objInventario.numero = InventarioMovimientoBE.NumDoc
            objInventario.idDocumento = InventarioMovimientoBE.idDocumento
            objInventario.idDocumentoRef = InventarioMovimientoBE.idDocumento
            objInventario.marca = InventarioMovimientoBE.marcaRef
            objInventario.descripcion = InventarioMovimientoBE.descripcionItem
            objInventario.fechaLaboral = InventarioMovimientoBE.FechaLaboral
            objInventario.fecha = InventarioMovimientoBE.FechaDoc
            objInventario.tipoRegistro = InventarioMovimientoBE.TipoRegistro
            objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
            objInventario.tipoProducto = InventarioMovimientoBE.tipoExistencia
            objInventario.cuentaOrigen = InventarioMovimientoBE.CuentaItem
            objInventario.idItem = InventarioMovimientoBE.idItem
            objInventario.presentacion = InventarioMovimientoBE.unidad2
            objInventario.fechavcto = InventarioMovimientoBE.FechaVcto

            Select Case InventarioMovimientoBE.TipoRegistro
                Case "E"
                    objInventario.idAlmacen = InventarioMovimientoBE.almacenDestino ' ALMACEN DE DESTINO DE LA MERCADERIA TRASLADADA
                    objInventario.cantidad = InventarioMovimientoBE.monto1
                    objInventario.unidad = InventarioMovimientoBE.unidad1
                    objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
                    objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2
                    objInventario.precUnite = InventarioMovimientoBE.precioUnitario
                    objInventario.precUniteUSD = InventarioMovimientoBE.precioUnitarioUS
                    objInventario.monto = InventarioMovimientoBE.importe
                    objInventario.montoUSD = InventarioMovimientoBE.importeUS
                Case Else
                    objInventario.idAlmacen = InventarioMovimientoBE.almacenRef ' ALMACEN DE ORIGEN DE SALIDA DE MERCADERIA
                    objInventario.cantidad = InventarioMovimientoBE.monto1 * -1
                    objInventario.unidad = InventarioMovimientoBE.unidad1
                    objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
                    objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2
                    objInventario.precUnite = InventarioMovimientoBE.precioUnitario
                    objInventario.precUniteUSD = InventarioMovimientoBE.precioUnitarioUS
                    objInventario.monto = InventarioMovimientoBE.importe * -1
                    objInventario.montoUSD = InventarioMovimientoBE.importeUS * -1
            End Select
            objInventario.disponible = 0
            objInventario.disponible2 = 0
            objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
            objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
            objInventario.status = "D"
            objInventario.entragado = "NO"
            objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
            objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion
            HeliosData.InventarioMovimiento.Add(objInventario)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objInventario.idInventario
        End Using
    End Function

    Public Function Insert(ByVal InventarioMovimientoBE As documentocompradetalle, objDocumento As documento) As Integer
        Dim objInventario As New InventarioMovimiento
        Dim almacenBL As New almacenBL
        Using ts As New TransactionScope
            objInventario = New InventarioMovimiento
            objInventario.idorigenDetalle = InventarioMovimientoBE.secuencia
            objInventario.idEmpresa = InventarioMovimientoBE.IdEmpresa
            objInventario.idEstablecimiento = InventarioMovimientoBE.IdEstablecimiento
            objInventario.idAlmacen = almacenBL.GetUbicar_almacenVirtual(InventarioMovimientoBE.IdEstablecimiento).idAlmacen
            objInventario.tipoOperacion = "02"
            objInventario.tipoDocAlmacen = InventarioMovimientoBE.TipoDoc
            objInventario.serie = InventarioMovimientoBE.Serie
            objInventario.numero = InventarioMovimientoBE.NumDoc
            objInventario.idDocumento = objDocumento.idDocumento
            objInventario.idDocumentoRef = objDocumento.idDocumento
            objInventario.marca = InventarioMovimientoBE.marcaRef
            If InventarioMovimientoBE.bonificacion = "S" Then
                objInventario.descripcion = String.Concat("BONIFICACION: ", InventarioMovimientoBE.descripcionItem)
            Else
                objInventario.descripcion = String.Concat("ENTRADA: ", InventarioMovimientoBE.descripcionItem)
            End If
            objInventario.fecha = InventarioMovimientoBE.FechaDoc
            Select Case InventarioMovimientoBE.bonificacion
                Case "S"
                    objInventario.tipoRegistro = "EB"
                Case Else
                    objInventario.tipoRegistro = "E"
            End Select

            objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
            objInventario.tipoProducto = InventarioMovimientoBE.tipoExistencia
            objInventario.cuentaOrigen = InventarioMovimientoBE.CuentaItem
            objInventario.idItem = InventarioMovimientoBE.idItem
            objInventario.presentacion = InventarioMovimientoBE.unidad2
            objInventario.fechavcto = InventarioMovimientoBE.FechaVcto
            objInventario.cantidad = InventarioMovimientoBE.monto1
            objInventario.unidad = InventarioMovimientoBE.unidad1
            objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
            objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2
            'If documentocompradetalle(x).Monto1 = 0 Then
            '    objInventario.precUnite = 0 ' Math.Round((documentocompradetalle(x).Montokardex + documentocompradetalle(x).MontoIsc + documentocompradetalle(x).OtrosTributos) / documentocompradetalle(x).Monto1, 4)
            '    objInventario.precUniteUSD = 0
            ' Else
            objInventario.precUnite = InventarioMovimientoBE.precioUnitario
            objInventario.precUniteUSD = InventarioMovimientoBE.precioUnitarioUS
            ' End If
            '         If documentocompradetalle(x).Bonificacion = "S" Then
            'objInventario.monto = documentocompradetalle(x).BonificacionMN
            'objInventario.montoUSD = documentocompradetalle(x).BonificacionME
            'Else
            If InventarioMovimientoBE.bonificacion = "S" Then
                objInventario.monto = InventarioMovimientoBE.importe
                objInventario.montoUSD = InventarioMovimientoBE.importeUS
            Else
                Select Case objDocumento.tipoDoc
                    Case "03", "02"
                        objInventario.monto = InventarioMovimientoBE.importe
                        objInventario.montoUSD = InventarioMovimientoBE.importeUS
                    Case Else
                        Select Case InventarioMovimientoBE.destino
                            Case "1"
                                objInventario.monto = InventarioMovimientoBE.montokardex
                                objInventario.montoUSD = InventarioMovimientoBE.montokardexUS
                            Case Else
                                objInventario.monto = InventarioMovimientoBE.importe
                                objInventario.montoUSD = InventarioMovimientoBE.importeUS

                        End Select
                End Select
            End If

            objInventario.disponible = InventarioMovimientoBE.monto1
            objInventario.disponible2 = 0
            objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
            objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
            objInventario.status = "D"
            objInventario.entragado = "NO"
            objInventario.preEvento = InventarioMovimientoBE.preEvento
            objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
            objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion

            HeliosData.InventarioMovimiento.Add(objInventario)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objInventario.idInventario
        End Using
    End Function

    Public Function InsertVentaPagada(ByVal InventarioMovimientoBE As documentoventaAbarrotesDet, objDocumento As documento) As Integer
        Dim objInventario As New InventarioMovimiento
        Dim almacenBL As New almacenBL
        Dim almacen As New almacen
        Using ts As New TransactionScope

            almacen = almacenBL.GetUbicar_almacenPorID(InventarioMovimientoBE.idAlmacenOrigen)

            objInventario = New InventarioMovimiento
            objInventario.nrolote = InventarioMovimientoBE.codigoLote
            objInventario.idEmpresa = almacen.idEmpresa
            objInventario.idEstablecimiento = almacen.idEstablecimiento
            objInventario.idAlmacen = InventarioMovimientoBE.idAlmacenOrigen  ' almacenBL.GetUbicar_almacenVirtual(InventarioMovimientoBE.IdEstablecimiento).idAlmacen
            objInventario.tipoOperacion = "01"
            objInventario.serie = InventarioMovimientoBE.Serie
            objInventario.numero = InventarioMovimientoBE.NumDoc
            objInventario.idDocumento = objDocumento.idDocumento
            objInventario.idDocumentoRef = objDocumento.idDocumento
            'If InventarioMovimientoBE.bonificacion = "S" Then
            '    objInventario.descripcion = String.Concat("BONIFICACION: ", InventarioMovimientoBE.descripcionItem)
            'Else
            objInventario.descripcion = InventarioMovimientoBE.DetalleItem
            ' End If
            objInventario.fechaLaboral = InventarioMovimientoBE.FechaLaboral
            If Not IsNothing(objDocumento.documentoventaAbarrotes.fechaConfirmacion) Then
                objInventario.fecha = objDocumento.documentoventaAbarrotes.fechaConfirmacion
            Else
                objInventario.fecha = objDocumento.documentoventaAbarrotes.fechaDoc
            End If

            objInventario.tipoRegistro = "S"
            objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
            objInventario.tipoProducto = InventarioMovimientoBE.tipoExistencia
            objInventario.cuentaOrigen = InventarioMovimientoBE.cuentaOrigen
            objInventario.idItem = InventarioMovimientoBE.idItem
            objInventario.presentacion = InventarioMovimientoBE.unidad2
            objInventario.fechavcto = InventarioMovimientoBE.fechaVcto
            objInventario.cantidad = InventarioMovimientoBE.monto1 * -1
            objInventario.unidad = InventarioMovimientoBE.unidad1
            objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
            objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2
            'If documentocompradetalle(x).Monto1 = 0 Then
            '    objInventario.precUnite = 0 ' Math.Round((documentocompradetalle(x).Montokardex + documentocompradetalle(x).MontoIsc + documentocompradetalle(x).OtrosTributos) / documentocompradetalle(x).Monto1, 4)
            '    objInventario.precUniteUSD = 0
            ' Else
            objInventario.precUnite = InventarioMovimientoBE.precioUnitario
            objInventario.precUniteUSD = InventarioMovimientoBE.precioUnitarioUS
            ' End If
            '         If documentocompradetalle(x).Bonificacion = "S" Then
            'objInventario.monto = documentocompradetalle(x).BonificacionMN
            'objInventario.montoUSD = documentocompradetalle(x).BonificacionME
            'Else
            Select Case objDocumento.tipoDoc
                Case "03", "02"
                    objInventario.monto = InventarioMovimientoBE.salidaCostoMN * -1
                    objInventario.montoUSD = InventarioMovimientoBE.salidaCostoME * -1
                Case Else
                    Select Case InventarioMovimientoBE.destino
                        Case "1"
                            objInventario.monto = InventarioMovimientoBE.salidaCostoMN * -1
                            objInventario.montoUSD = InventarioMovimientoBE.salidaCostoME * -1
                        Case Else
                            objInventario.monto = InventarioMovimientoBE.salidaCostoMN * -1
                            objInventario.montoUSD = InventarioMovimientoBE.salidaCostoME * -1

                    End Select

            End Select

            ' objInventario.disponible = InventarioMovimientoBE.monto1
            objInventario.disponible2 = 0
            objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
            objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
            objInventario.status = "D"
            objInventario.entragado = "SI"
            objInventario.preEvento = InventarioMovimientoBE.preEvento
            objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
            objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion

            HeliosData.InventarioMovimiento.Add(objInventario)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objInventario.idInventario
        End Using
    End Function

    Public Function InsertOtrasSalidasAlmacen(ByVal InventarioMovimientoBE As documentoventaAbarrotesDet, objDocumento As documento) As Integer
        Dim objInventario As New InventarioMovimiento
        Dim almacenBL As New almacenBL
        Using ts As New TransactionScope
            objInventario = New InventarioMovimiento
            objInventario.idEmpresa = InventarioMovimientoBE.IdEmpresa
            objInventario.idEstablecimiento = InventarioMovimientoBE.establecimientoOrigen
            objInventario.idAlmacen = InventarioMovimientoBE.idAlmacenOrigen  ' almacenBL.GetUbicar_almacenVirtual(InventarioMovimientoBE.IdEstablecimiento).idAlmacen
            objInventario.tipoOperacion = "01"
            objInventario.tipoDocAlmacen = InventarioMovimientoBE.TipoDoc
            objInventario.serie = InventarioMovimientoBE.Serie
            objInventario.numero = InventarioMovimientoBE.NumDoc
            objInventario.idDocumento = objDocumento.idDocumento
            objInventario.idDocumentoRef = objDocumento.idDocumento
            'If InventarioMovimientoBE.bonificacion = "S" Then
            '    objInventario.descripcion = String.Concat("BONIFICACION: ", InventarioMovimientoBE.descripcionItem)
            'Else
            objInventario.descripcion = String.Concat("SALIDA: ", InventarioMovimientoBE.DetalleItem)
            ' End If
            objInventario.fecha = objDocumento.fechaProceso
            objInventario.tipoRegistro = "S"
            objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
            objInventario.tipoProducto = InventarioMovimientoBE.tipoExistencia
            objInventario.cuentaOrigen = InventarioMovimientoBE.cuentaOrigen
            objInventario.idItem = InventarioMovimientoBE.idItem
            objInventario.presentacion = InventarioMovimientoBE.unidad2
            objInventario.fechavcto = InventarioMovimientoBE.fechaVcto
            objInventario.cantidad = InventarioMovimientoBE.monto1 * -1
            objInventario.unidad = InventarioMovimientoBE.unidad1
            objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
            objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2

            objInventario.precUnite = InventarioMovimientoBE.precioUnitario
            objInventario.precUniteUSD = InventarioMovimientoBE.precioUnitarioUS
            objInventario.monto = InventarioMovimientoBE.importeMN * -1
            objInventario.montoUSD = InventarioMovimientoBE.importeME * -1
            objInventario.disponible = InventarioMovimientoBE.monto1
            objInventario.disponible2 = 0
            objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
            objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
            objInventario.status = "D"
            objInventario.entragado = "SI"
            objInventario.preEvento = InventarioMovimientoBE.preEvento
            objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
            objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion

            HeliosData.InventarioMovimiento.Add(objInventario)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objInventario.idInventario
        End Using
    End Function

    Public Function InsertNotaCredito(ByVal InventarioMovimientoBE As documentocompradetalle, objDocumento As documento) As Integer
        Dim objInventario As New InventarioMovimiento
        Dim almacenBL As New almacenBL
        Using ts As New TransactionScope
            objInventario = New InventarioMovimiento
            objInventario.idEmpresa = InventarioMovimientoBE.IdEmpresa
            objInventario.nrolote = InventarioMovimientoBE.codigoLote
            objInventario.idEstablecimiento = InventarioMovimientoBE.IdEstablecimiento
            objInventario.idAlmacen = InventarioMovimientoBE.almacenRef   ' almacenBL.GetUbicar_almacenVirtual(InventarioMovimientoBE.IdEstablecimiento).idAlmacen
            objInventario.tipoOperacion = InventarioMovimientoBE.TipoOperacion
            objInventario.tipoDocAlmacen = InventarioMovimientoBE.TipoDoc
            objInventario.serie = InventarioMovimientoBE.Serie
            objInventario.numero = InventarioMovimientoBE.NumDoc
            objInventario.idDocumento = objDocumento.idDocumento
            objInventario.idDocumentoRef = objDocumento.idDocumento

            objInventario.fecha = objDocumento.fechaProceso
            objInventario.fechaLaboral = InventarioMovimientoBE.FechaLaboral

            objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
            objInventario.tipoProducto = InventarioMovimientoBE.tipoExistencia
            objInventario.cuentaOrigen = InventarioMovimientoBE.CuentaItem
            objInventario.idItem = InventarioMovimientoBE.idItem
            objInventario.presentacion = InventarioMovimientoBE.unidad2
            objInventario.fechavcto = InventarioMovimientoBE.FechaVcto

            If objDocumento.documentocompra.sustentado = Notas_Credito.BOF_REDUC_COSTO_IGUAL_COMPRA Then
                objInventario.tipoRegistro = "E"
                objInventario.descripcion = InventarioMovimientoBE.descripcionItem
                objInventario.cantidad = InventarioMovimientoBE.monto1
                objInventario.precUnite = 0
                objInventario.precUniteUSD = 0
                Select Case objDocumento.tipoDoc
                    Case "03", "02"
                        objInventario.monto = InventarioMovimientoBE.montokardex
                        objInventario.montoUSD = InventarioMovimientoBE.montokardexUS
                    Case Else
                        Select Case InventarioMovimientoBE.destino
                            Case "1"
                                objInventario.monto = InventarioMovimientoBE.montokardex
                                objInventario.montoUSD = InventarioMovimientoBE.montokardexUS
                            Case Else
                                objInventario.monto = InventarioMovimientoBE.montokardex
                                objInventario.montoUSD = InventarioMovimientoBE.montokardexUS

                        End Select

                End Select

            Else

                objInventario.tipoRegistro = "S"
                objInventario.descripcion = InventarioMovimientoBE.descripcionItem
                objInventario.cantidad = InventarioMovimientoBE.monto1 * -1
                objInventario.precUnite = InventarioMovimientoBE.precioUnitario
                objInventario.precUniteUSD = InventarioMovimientoBE.precioUnitarioUS
                Select Case objDocumento.tipoDoc
                    Case "03", "02"
                        objInventario.monto = InventarioMovimientoBE.montokardex * -1
                        objInventario.montoUSD = InventarioMovimientoBE.montokardexUS * -1
                    Case Else
                        Select Case InventarioMovimientoBE.destino
                            Case "1"
                                objInventario.monto = InventarioMovimientoBE.montokardex * -1
                                objInventario.montoUSD = InventarioMovimientoBE.montokardexUS * -1
                            Case Else
                                objInventario.monto = InventarioMovimientoBE.montokardex * -1
                                objInventario.montoUSD = InventarioMovimientoBE.montokardexUS * -1

                        End Select

                End Select
            End If

            objInventario.unidad = InventarioMovimientoBE.unidad1
            objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
            objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2

            objInventario.disponible = InventarioMovimientoBE.monto1
            objInventario.disponible2 = 0
            objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
            objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
            objInventario.status = "D"
            objInventario.entragado = "SI"
            '    objInventario.preEvento = InventarioMovimientoBE.preEvento
            objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
            objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion

            HeliosData.InventarioMovimiento.Add(objInventario)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objInventario.idInventario
        End Using
    End Function

    Public Function InsertNotaCreditoVenta(ByVal InventarioMovimientoBE As documentoventaAbarrotesDet, objDocumento As documento) As Integer
        Dim objInventario As New InventarioMovimiento
        Dim almacenBL As New almacenBL
        Using ts As New TransactionScope
            objInventario = New InventarioMovimiento
            objInventario.nrolote = InventarioMovimientoBE.codigoLote
            objInventario.idEmpresa = InventarioMovimientoBE.IdEmpresa
            objInventario.idEstablecimiento = InventarioMovimientoBE.IdEstablecimiento
            objInventario.idAlmacen = InventarioMovimientoBE.idAlmacenOrigen    ' almacenBL.GetUbicar_almacenVirtual(InventarioMovimientoBE.IdEstablecimiento).idAlmacen
            objInventario.tipoOperacion = InventarioMovimientoBE.TipoOperacion
            objInventario.tipoDocAlmacen = InventarioMovimientoBE.TipoDoc
            objInventario.serie = InventarioMovimientoBE.Serie
            objInventario.numero = InventarioMovimientoBE.NumDoc
            objInventario.idDocumento = objDocumento.idDocumento
            objInventario.idDocumentoRef = objDocumento.idDocumento

            objInventario.fecha = objDocumento.fechaProceso

            objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
            objInventario.tipoProducto = InventarioMovimientoBE.tipoExistencia
            objInventario.cuentaOrigen = Nothing ' InventarioMovimientoBE.CuentaItem
            objInventario.idItem = InventarioMovimientoBE.idItem
            objInventario.presentacion = InventarioMovimientoBE.unidad2
            objInventario.fechavcto = InventarioMovimientoBE.fechaVcto

            If objDocumento.documentoventaAbarrotes.sustentado = Notas_Credito.BOF_REDUC_COSTO_IGUAL_COMPRA Then
                objInventario.tipoRegistro = "E"
                objInventario.descripcion = String.Concat("ENTRADA: ", InventarioMovimientoBE.DetalleItem)
                objInventario.cantidad = InventarioMovimientoBE.monto1
                objInventario.precUnite = 0
                objInventario.precUniteUSD = 0
                Select Case objDocumento.tipoDoc
                    Case "03", "02"
                        objInventario.monto = InventarioMovimientoBE.salidaCostoMN
                        objInventario.montoUSD = InventarioMovimientoBE.salidaCostoME
                    Case Else
                        Select Case InventarioMovimientoBE.destino
                            Case "1"
                                objInventario.monto = InventarioMovimientoBE.salidaCostoMN
                                objInventario.montoUSD = InventarioMovimientoBE.salidaCostoME
                            Case Else
                                objInventario.monto = InventarioMovimientoBE.salidaCostoMN
                                objInventario.montoUSD = InventarioMovimientoBE.salidaCostoME

                        End Select

                End Select

            Else

                objInventario.tipoRegistro = "E"
                objInventario.descripcion = InventarioMovimientoBE.DetalleItem
                objInventario.cantidad = InventarioMovimientoBE.monto1
                objInventario.precUnite = InventarioMovimientoBE.precioUnitario
                objInventario.precUniteUSD = InventarioMovimientoBE.precioUnitarioUS
                Select Case objDocumento.tipoDoc
                    Case "03", "02"
                        objInventario.monto = InventarioMovimientoBE.salidaCostoMN
                        objInventario.montoUSD = InventarioMovimientoBE.salidaCostoME
                    Case Else
                        Select Case InventarioMovimientoBE.destino
                            Case "1"
                                objInventario.monto = InventarioMovimientoBE.salidaCostoMN
                                objInventario.montoUSD = InventarioMovimientoBE.salidaCostoME
                            Case Else
                                objInventario.monto = InventarioMovimientoBE.salidaCostoMN
                                objInventario.montoUSD = InventarioMovimientoBE.salidaCostoME

                        End Select

                End Select
            End If

            objInventario.unidad = InventarioMovimientoBE.unidad1
            objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
            objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2

            objInventario.disponible = InventarioMovimientoBE.monto1
            objInventario.disponible2 = 0
            objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
            objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
            objInventario.status = "D"
            objInventario.entragado = "SI"
            '         objInventario.preEvento = InventarioMovimientoBE.preEvento
            objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
            objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion

            HeliosData.InventarioMovimiento.Add(objInventario)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objInventario.idInventario
        End Using
    End Function

    Public Function InsertNotaCreditoBoNif(ByVal InventarioMovimientoBE As documentocompradetalle, objDocumento As documento) As Integer
        Dim objInventario As New InventarioMovimiento
        Dim almacenBL As New almacenBL
        Using ts As New TransactionScope
            objInventario = New InventarioMovimiento
            objInventario.idEmpresa = InventarioMovimientoBE.IdEmpresa
            objInventario.idEstablecimiento = InventarioMovimientoBE.IdEstablecimiento
            objInventario.idAlmacen = InventarioMovimientoBE.almacenRef   ' almacenBL.GetUbicar_almacenVirtual(InventarioMovimientoBE.IdEstablecimiento).idAlmacen
            objInventario.tipoOperacion = InventarioMovimientoBE.TipoOperacion
            objInventario.tipoDocAlmacen = InventarioMovimientoBE.TipoDoc
            objInventario.serie = InventarioMovimientoBE.Serie
            objInventario.numero = InventarioMovimientoBE.NumDoc
            objInventario.idDocumento = objDocumento.idDocumento
            objInventario.idDocumentoRef = objDocumento.idDocumento

            objInventario.fecha = objDocumento.fechaProceso

            objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
            objInventario.tipoProducto = InventarioMovimientoBE.tipoExistencia
            objInventario.cuentaOrigen = InventarioMovimientoBE.CuentaItem
            objInventario.idItem = InventarioMovimientoBE.idItem
            objInventario.presentacion = InventarioMovimientoBE.unidad2
            objInventario.fechavcto = InventarioMovimientoBE.FechaVcto

            objInventario.tipoRegistro = "E"
            objInventario.descripcion = String.Concat("ENTRADA: ", InventarioMovimientoBE.DetalleItem)
            objInventario.cantidad = InventarioMovimientoBE.monto1
            objInventario.precUnite = 0
            objInventario.precUniteUSD = 0
            Select Case objDocumento.tipoDoc
                Case "03", "02"
                    objInventario.monto = InventarioMovimientoBE.montokardex
                    objInventario.montoUSD = InventarioMovimientoBE.montokardexUS
                Case Else
                    Select Case InventarioMovimientoBE.destino
                        Case "1"
                            objInventario.monto = InventarioMovimientoBE.montokardex
                            objInventario.montoUSD = InventarioMovimientoBE.montokardexUS
                        Case Else
                            objInventario.monto = InventarioMovimientoBE.montokardex
                            objInventario.montoUSD = InventarioMovimientoBE.montokardexUS

                    End Select

            End Select

            objInventario.unidad = InventarioMovimientoBE.unidad1
            objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
            objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2

            objInventario.disponible = InventarioMovimientoBE.monto1
            objInventario.disponible2 = 0
            objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
            objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
            objInventario.status = "D"
            objInventario.entragado = "SI"
            objInventario.preEvento = InventarioMovimientoBE.preEvento
            objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
            objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion

            HeliosData.InventarioMovimiento.Add(objInventario)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objInventario.idInventario
        End Using
    End Function

    Public Function InsertNotaCreditoBoNifVenta(ByVal InventarioMovimientoBE As documentoventaAbarrotesDet, objDocumento As documento) As Integer
        Dim objInventario As New InventarioMovimiento
        Dim almacenBL As New almacenBL
        Using ts As New TransactionScope
            objInventario = New InventarioMovimiento
            objInventario.idEmpresa = InventarioMovimientoBE.IdEmpresa
            objInventario.idEstablecimiento = InventarioMovimientoBE.IdEstablecimiento
            objInventario.idAlmacen = InventarioMovimientoBE.idAlmacenOrigen    ' almacenBL.GetUbicar_almacenVirtual(InventarioMovimientoBE.IdEstablecimiento).idAlmacen
            objInventario.tipoOperacion = InventarioMovimientoBE.TipoOperacion
            objInventario.tipoDocAlmacen = InventarioMovimientoBE.TipoDoc
            objInventario.serie = InventarioMovimientoBE.Serie
            objInventario.numero = InventarioMovimientoBE.NumDoc
            objInventario.idDocumento = objDocumento.idDocumento
            objInventario.idDocumentoRef = objDocumento.idDocumento

            objInventario.fecha = objDocumento.fechaProceso

            objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
            objInventario.tipoProducto = InventarioMovimientoBE.tipoExistencia
            objInventario.cuentaOrigen = Nothing ' InventarioMovimientoBE.CuentaItem
            objInventario.idItem = InventarioMovimientoBE.idItem
            objInventario.presentacion = InventarioMovimientoBE.unidad2
            objInventario.fechavcto = InventarioMovimientoBE.fechaVcto

            objInventario.tipoRegistro = "E"
            objInventario.descripcion = String.Concat("ENTRADA: ", InventarioMovimientoBE.DetalleItem)
            objInventario.cantidad = InventarioMovimientoBE.monto1
            objInventario.precUnite = 0
            objInventario.precUniteUSD = 0
            Select Case objDocumento.tipoDoc
                Case "03", "02"
                    objInventario.monto = InventarioMovimientoBE.montokardex
                    objInventario.montoUSD = InventarioMovimientoBE.montokardexUS
                Case Else
                    Select Case InventarioMovimientoBE.destino
                        Case "1"
                            objInventario.monto = InventarioMovimientoBE.montokardex
                            objInventario.montoUSD = InventarioMovimientoBE.montokardexUS
                        Case Else
                            objInventario.monto = InventarioMovimientoBE.montokardex
                            objInventario.montoUSD = InventarioMovimientoBE.montokardexUS

                    End Select

            End Select

            objInventario.unidad = InventarioMovimientoBE.unidad1
            objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
            objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2

            objInventario.disponible = InventarioMovimientoBE.monto1
            objInventario.disponible2 = 0
            objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
            objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
            objInventario.status = "D"
            objInventario.entragado = "SI"
            objInventario.preEvento = InventarioMovimientoBE.preEvento
            objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
            objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion

            HeliosData.InventarioMovimiento.Add(objInventario)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objInventario.idInventario
        End Using
    End Function

    Public Function InsertNotaCredito_Bonificacion(ByVal InventarioMovimientoBE As documentocompradetalle, objDocumento As documento) As Integer
        Dim objInventario As New InventarioMovimiento
        Dim almacenBL As New almacenBL
        Using ts As New TransactionScope
            objInventario = New InventarioMovimiento
            objInventario.idEmpresa = InventarioMovimientoBE.IdEmpresa
            objInventario.idEstablecimiento = InventarioMovimientoBE.IdEstablecimiento
            objInventario.idAlmacen = InventarioMovimientoBE.almacenRef   ' almacenBL.GetUbicar_almacenVirtual(InventarioMovimientoBE.IdEstablecimiento).idAlmacen
            objInventario.tipoOperacion = InventarioMovimientoBE.TipoOperacion
            objInventario.tipoDocAlmacen = InventarioMovimientoBE.TipoDoc
            objInventario.serie = InventarioMovimientoBE.Serie
            objInventario.numero = InventarioMovimientoBE.NumDoc
            objInventario.idDocumento = objDocumento.idDocumento
            objInventario.idDocumentoRef = objDocumento.idDocumento

            objInventario.fecha = objDocumento.fechaProceso

            objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
            objInventario.tipoProducto = InventarioMovimientoBE.tipoExistencia
            objInventario.cuentaOrigen = InventarioMovimientoBE.CuentaItem
            objInventario.idItem = InventarioMovimientoBE.idItem
            objInventario.presentacion = InventarioMovimientoBE.unidad2
            objInventario.fechavcto = InventarioMovimientoBE.FechaVcto

            Select Case InventarioMovimientoBE.FlagBonif
                Case "<>"
                    objInventario.tipoRegistro = "E"
                    objInventario.descripcion = String.Concat("ENTRADA: ", InventarioMovimientoBE.DetalleItem)
                    objInventario.cantidad = InventarioMovimientoBE.monto1
                    objInventario.precUnite = 0
                    objInventario.precUniteUSD = 0
                    objInventario.monto = InventarioMovimientoBE.importe
                    objInventario.montoUSD = InventarioMovimientoBE.importeUS
                Case "="
                    objInventario.tipoRegistro = "E"
                    objInventario.descripcion = String.Concat("ENTRADA: ", InventarioMovimientoBE.DetalleItem)
                    objInventario.cantidad = InventarioMovimientoBE.monto1
                    objInventario.precUnite = 0
                    objInventario.precUniteUSD = 0
                    objInventario.monto = InventarioMovimientoBE.importe
                    objInventario.montoUSD = InventarioMovimientoBE.importeUS
                Case "=!"
                    objInventario.tipoRegistro = "S"
                    objInventario.descripcion = String.Concat("SALIDA: ", InventarioMovimientoBE.DetalleItem)
                    objInventario.cantidad = 0
                    objInventario.precUnite = 0
                    objInventario.precUniteUSD = 0
                    objInventario.monto = InventarioMovimientoBE.importe * -1
                    objInventario.montoUSD = InventarioMovimientoBE.importeUS * -1
            End Select


            objInventario.unidad = InventarioMovimientoBE.unidad1
            objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
            objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2

            objInventario.disponible = InventarioMovimientoBE.monto1
            objInventario.disponible2 = 0
            objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
            objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
            objInventario.status = "D"
            objInventario.entragado = "SI"
            objInventario.preEvento = InventarioMovimientoBE.preEvento
            objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
            objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion

            HeliosData.InventarioMovimiento.Add(objInventario)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objInventario.idInventario
        End Using
    End Function

    Public Function InsertNotaCredito_BonificacionVenta(ByVal InventarioMovimientoBE As documentoventaAbarrotesDet, objDocumento As documento) As Integer
        Dim objInventario As New InventarioMovimiento
        Dim almacenBL As New almacenBL
        Using ts As New TransactionScope
            objInventario = New InventarioMovimiento
            objInventario.idEmpresa = InventarioMovimientoBE.IdEmpresa
            objInventario.idEstablecimiento = InventarioMovimientoBE.IdEstablecimiento
            objInventario.idAlmacen = InventarioMovimientoBE.idAlmacenOrigen    ' almacenBL.GetUbicar_almacenVirtual(InventarioMovimientoBE.IdEstablecimiento).idAlmacen
            objInventario.tipoOperacion = InventarioMovimientoBE.TipoOperacion
            objInventario.tipoDocAlmacen = InventarioMovimientoBE.TipoDoc
            objInventario.serie = InventarioMovimientoBE.Serie
            objInventario.numero = InventarioMovimientoBE.NumDoc
            objInventario.idDocumento = objDocumento.idDocumento
            objInventario.idDocumentoRef = objDocumento.idDocumento

            objInventario.fecha = objDocumento.fechaProceso

            objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
            objInventario.tipoProducto = InventarioMovimientoBE.tipoExistencia
            objInventario.cuentaOrigen = Nothing ' InventarioMovimientoBE.CuentaItem
            objInventario.idItem = InventarioMovimientoBE.idItem
            objInventario.presentacion = InventarioMovimientoBE.unidad2
            objInventario.fechavcto = InventarioMovimientoBE.fechaVcto

            Select Case InventarioMovimientoBE.FlagBonif
                Case "<>"
                    objInventario.tipoRegistro = "E"
                    objInventario.descripcion = String.Concat("ENTRADA: ", InventarioMovimientoBE.DetalleItem)
                    objInventario.cantidad = InventarioMovimientoBE.monto1
                    objInventario.precUnite = 0
                    objInventario.precUniteUSD = 0
                    objInventario.monto = InventarioMovimientoBE.importeMN
                    objInventario.montoUSD = InventarioMovimientoBE.importeME
                Case "="
                    objInventario.tipoRegistro = "E"
                    objInventario.descripcion = String.Concat("ENTRADA: ", InventarioMovimientoBE.DetalleItem)
                    objInventario.cantidad = InventarioMovimientoBE.monto1
                    objInventario.precUnite = 0
                    objInventario.precUniteUSD = 0
                    objInventario.monto = InventarioMovimientoBE.importeMN
                    objInventario.montoUSD = InventarioMovimientoBE.importeME
                Case "=!"
                    objInventario.tipoRegistro = "S"
                    objInventario.descripcion = String.Concat("SALIDA: ", InventarioMovimientoBE.DetalleItem)
                    objInventario.cantidad = 0
                    objInventario.precUnite = 0
                    objInventario.precUniteUSD = 0
                    objInventario.monto = InventarioMovimientoBE.importeMN * -1
                    objInventario.montoUSD = InventarioMovimientoBE.importeME * -1
            End Select


            objInventario.unidad = InventarioMovimientoBE.unidad1
            objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
            objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2

            objInventario.disponible = InventarioMovimientoBE.monto1
            objInventario.disponible2 = 0
            objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
            objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
            objInventario.status = "D"
            objInventario.entragado = "SI"
            objInventario.preEvento = InventarioMovimientoBE.preEvento
            objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
            objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion

            HeliosData.InventarioMovimiento.Add(objInventario)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objInventario.idInventario
        End Using
    End Function

    Public Function InsertNotaCredito_Venta(ByVal InventarioMovimientoBE As documentoventaAbarrotesDet, objDocumento As documento) As Integer
        Dim objInventario As New InventarioMovimiento
        Dim almacenBL As New almacenBL
        Using ts As New TransactionScope
            objInventario = New InventarioMovimiento
            objInventario.idEmpresa = InventarioMovimientoBE.IdEmpresa
            objInventario.idEstablecimiento = InventarioMovimientoBE.IdEstablecimiento
            objInventario.idAlmacen = InventarioMovimientoBE.idAlmacenOrigen    ' almacenBL.GetUbicar_almacenVirtual(InventarioMovimientoBE.IdEstablecimiento).idAlmacen
            objInventario.tipoOperacion = "01"
            objInventario.tipoDocAlmacen = InventarioMovimientoBE.TipoDoc
            objInventario.serie = InventarioMovimientoBE.Serie
            objInventario.numero = InventarioMovimientoBE.NumDoc
            objInventario.idDocumento = objDocumento.idDocumento
            objInventario.idDocumentoRef = objDocumento.idDocumento

            objInventario.fecha = objDocumento.fechaProceso

            objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
            objInventario.tipoProducto = InventarioMovimientoBE.tipoExistencia
            objInventario.cuentaOrigen = InventarioMovimientoBE.cuentaOrigen
            objInventario.idItem = InventarioMovimientoBE.idItem
            objInventario.presentacion = InventarioMovimientoBE.unidad2
            objInventario.fechavcto = InventarioMovimientoBE.fechaVcto

            objInventario.tipoRegistro = "E"
            objInventario.descripcion = String.Concat("ENTRADA: ", InventarioMovimientoBE.DetalleItem)
            objInventario.cantidad = InventarioMovimientoBE.monto1
            objInventario.precUnite = 0
            objInventario.precUniteUSD = 0

            objInventario.monto = InventarioMovimientoBE.salidaCostoMN
            objInventario.montoUSD = InventarioMovimientoBE.salidaCostoME

            objInventario.unidad = InventarioMovimientoBE.unidad1
            objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
            objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2

            objInventario.disponible = InventarioMovimientoBE.monto1
            objInventario.disponible2 = 0
            objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
            objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
            objInventario.status = "D"
            objInventario.entragado = "SI"
            objInventario.preEvento = InventarioMovimientoBE.preEvento
            objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
            objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion

            HeliosData.InventarioMovimiento.Add(objInventario)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objInventario.idInventario
        End Using
    End Function

    Public Function InsertNotaDebito(ByVal InventarioMovimientoBE As documentocompradetalle, objDocumento As documento) As Integer
        Dim objInventario As New InventarioMovimiento
        Dim almacenBL As New almacenBL
        Using ts As New TransactionScope
            objInventario = New InventarioMovimiento
            objInventario.idEmpresa = InventarioMovimientoBE.IdEmpresa
            objInventario.idEstablecimiento = InventarioMovimientoBE.IdEstablecimiento
            objInventario.idAlmacen = InventarioMovimientoBE.almacenRef   ' almacenBL.GetUbicar_almacenVirtual(InventarioMovimientoBE.IdEstablecimiento).idAlmacen
            objInventario.tipoOperacion = InventarioMovimientoBE.TipoOperacion
            objInventario.tipoDocAlmacen = InventarioMovimientoBE.TipoDoc
            objInventario.serie = InventarioMovimientoBE.Serie
            objInventario.numero = InventarioMovimientoBE.NumDoc
            objInventario.idDocumento = objDocumento.idDocumento
            objInventario.idDocumentoRef = objDocumento.idDocumento

            objInventario.fecha = objDocumento.fechaProceso
            objInventario.fechaLaboral = InventarioMovimientoBE.FechaLaboral

            objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
            objInventario.tipoProducto = InventarioMovimientoBE.tipoExistencia
            objInventario.cuentaOrigen = InventarioMovimientoBE.CuentaItem
            objInventario.idItem = InventarioMovimientoBE.idItem
            objInventario.presentacion = InventarioMovimientoBE.unidad2
            objInventario.fechavcto = InventarioMovimientoBE.FechaVcto

            objInventario.tipoRegistro = "E"
            objInventario.descripcion = InventarioMovimientoBE.descripcionItem
            objInventario.cantidad = InventarioMovimientoBE.monto1
            objInventario.precUnite = 0
            objInventario.precUniteUSD = 0
            Select Case objDocumento.tipoDoc
                Case "03", "02"
                    objInventario.monto = InventarioMovimientoBE.importe
                    objInventario.montoUSD = InventarioMovimientoBE.importeUS
                Case Else
                    Select Case InventarioMovimientoBE.destino
                        Case "1"
                            objInventario.monto = InventarioMovimientoBE.montokardex
                            objInventario.montoUSD = InventarioMovimientoBE.montokardexUS
                        Case Else
                            objInventario.monto = InventarioMovimientoBE.importe
                            objInventario.montoUSD = InventarioMovimientoBE.importeUS

                    End Select

            End Select


            objInventario.unidad = InventarioMovimientoBE.unidad1
            objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
            objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2

            objInventario.disponible = InventarioMovimientoBE.monto1
            objInventario.disponible2 = 0
            objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
            objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
            objInventario.status = "D"
            objInventario.entragado = "SI"
            '   objInventario.preEvento = InventarioMovimientoBE.preEvento
            objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
            objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion

            HeliosData.InventarioMovimiento.Add(objInventario)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objInventario.idInventario
        End Using
    End Function

    Public Function InsertPagado(ByVal InventarioMovimientoBE As documentocompradetalle, objDocumento As documento) As Integer
        Dim objInventario As New InventarioMovimiento
        Dim almacenBL As New almacenBL
        Using ts As New TransactionScope
            objInventario = New InventarioMovimiento
            objInventario.nrolote = InventarioMovimientoBE.nrolote
            objInventario.idorigenDetalle = InventarioMovimientoBE.secuencia
            objInventario.idEmpresa = InventarioMovimientoBE.IdEmpresa
            objInventario.idEstablecimiento = InventarioMovimientoBE.IdEstablecimiento
            objInventario.idAlmacen = InventarioMovimientoBE.almacenRef
            objInventario.tipoDocAlmacen = InventarioMovimientoBE.TipoDoc
            objInventario.tipoOperacion = InventarioMovimientoBE.TipoOperacion
            objInventario.serie = InventarioMovimientoBE.Serie
            objInventario.numero = InventarioMovimientoBE.NumDoc
            objInventario.idDocumento = objDocumento.idDocumento
            objInventario.idDocumentoRef = objDocumento.idDocumento
            objInventario.marca = InventarioMovimientoBE.marcaRef
            objInventario.descripcion = InventarioMovimientoBE.descripcionItem
            'If InventarioMovimientoBE.bonificacion = "S" Then
            '    objInventario.descripcion = String.Concat("BONIFICACION: ", InventarioMovimientoBE.descripcionItem)
            'Else
            '    objInventario.descripcion = String.Concat("ENTRADA: ", InventarioMovimientoBE.descripcionItem)
            'End If
            objInventario.fechaLaboral = InventarioMovimientoBE.FechaLaboral
            objInventario.fecha = InventarioMovimientoBE.FechaDoc
            objInventario.tipoRegistro = "EA"
            objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
            objInventario.tipoProducto = InventarioMovimientoBE.tipoExistencia
            objInventario.cuentaOrigen = InventarioMovimientoBE.CuentaItem
            objInventario.idItem = InventarioMovimientoBE.idItem
            objInventario.presentacion = InventarioMovimientoBE.unidad2
            objInventario.fechavcto = InventarioMovimientoBE.FechaVcto
            objInventario.cantidad = InventarioMovimientoBE.monto1
            objInventario.unidad = InventarioMovimientoBE.unidad1
            objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
            objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2

            objInventario.precUnite = InventarioMovimientoBE.precioUnitario
            objInventario.precUniteUSD = InventarioMovimientoBE.precioUnitarioUS

            If InventarioMovimientoBE.bonificacion = "S" Then
                objInventario.monto = InventarioMovimientoBE.montokardex
                objInventario.montoUSD = InventarioMovimientoBE.montokardexUS
            Else
                Select Case objDocumento.tipoDoc
                    Case "03", "02"
                        objInventario.monto = InventarioMovimientoBE.montokardex
                        objInventario.montoUSD = InventarioMovimientoBE.montokardexUS
                    Case Else
                        Select Case InventarioMovimientoBE.destino
                            Case "1"
                                objInventario.monto = InventarioMovimientoBE.montokardex
                                objInventario.montoUSD = InventarioMovimientoBE.montokardexUS
                            Case Else
                                objInventario.monto = InventarioMovimientoBE.importe
                                objInventario.montoUSD = InventarioMovimientoBE.importeUS

                        End Select
                End Select
            End If

            objInventario.disponible = InventarioMovimientoBE.monto1
            objInventario.disponible2 = 0
            objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
            objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS



            objInventario.status = "D"
            objInventario.entragado = InventarioMovimientoBE.entregable
            objInventario.preEvento = InventarioMovimientoBE.preEvento
            objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
            objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion

            HeliosData.InventarioMovimiento.Add(objInventario)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objInventario.idInventario
        End Using
    End Function

    Public Function InsertAlmacenOEDefault(ByVal InventarioMovimientoBE As documentocompradetalle, objDocumento As documento) As Integer
        Dim objInventario As New InventarioMovimiento
        Dim almacenBL As New almacenBL
        Using ts As New TransactionScope
            objInventario = New InventarioMovimiento
            objInventario.idEmpresa = InventarioMovimientoBE.IdEmpresa
            objInventario.idEstablecimiento = almacenBL.GetUbicar_almacenPorID(InventarioMovimientoBE.almacenRef).idEstablecimiento
            objInventario.nrolote = InventarioMovimientoBE.nrolote
            objInventario.idAlmacen = InventarioMovimientoBE.almacenRef
            objInventario.tipoDocAlmacen = InventarioMovimientoBE.TipoDoc
            objInventario.tipoOperacion = InventarioMovimientoBE.TipoOperacion
            objInventario.serie = InventarioMovimientoBE.Serie
            objInventario.numero = InventarioMovimientoBE.NumDoc
            objInventario.idDocumento = objDocumento.idDocumento
            objInventario.idDocumentoRef = objDocumento.idDocumento
            objInventario.descripcion = InventarioMovimientoBE.descripcionItem
            objInventario.fecha = InventarioMovimientoBE.FechaDoc
            objInventario.fechaLaboral = InventarioMovimientoBE.FechaLaboral
            objInventario.tipoRegistro = "EA"
            objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
            objInventario.tipoProducto = InventarioMovimientoBE.tipoExistencia
            objInventario.cuentaOrigen = InventarioMovimientoBE.CuentaItem
            objInventario.idItem = InventarioMovimientoBE.idItem
            objInventario.presentacion = InventarioMovimientoBE.unidad2
            objInventario.fechavcto = InventarioMovimientoBE.FechaVcto
            objInventario.cantidad = InventarioMovimientoBE.monto1
            objInventario.unidad = InventarioMovimientoBE.unidad1
            objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
            objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2
            objInventario.precUnite = InventarioMovimientoBE.precioUnitario
            objInventario.precUniteUSD = InventarioMovimientoBE.precioUnitarioUS
            objInventario.monto = InventarioMovimientoBE.importe
            objInventario.montoUSD = InventarioMovimientoBE.importeUS

            objInventario.disponible = InventarioMovimientoBE.monto1
            objInventario.disponible2 = 0
            objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
            objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
            objInventario.status = "D"
            objInventario.entragado = "SI"
            objInventario.preEvento = InventarioMovimientoBE.preEvento
            objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
            objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion

            HeliosData.InventarioMovimiento.Add(objInventario)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objInventario.idInventario
        End Using
    End Function

    Public Function InsertAlmacenOSDefault(ByVal InventarioMovimientoBE As documentocompradetalle, objDocumento As documento) As Integer
        Dim objInventario As New InventarioMovimiento
        Dim almacenBL As New almacenBL
        Using ts As New TransactionScope
            objInventario = New InventarioMovimiento
            objInventario.nrolote = InventarioMovimientoBE.nrolote
            objInventario.idEmpresa = InventarioMovimientoBE.IdEmpresa
            objInventario.idEstablecimiento = almacenBL.GetUbicar_almacenPorID(InventarioMovimientoBE.almacenRef).idEstablecimiento
            objInventario.idAlmacen = InventarioMovimientoBE.almacenRef
            objInventario.tipoDocAlmacen = InventarioMovimientoBE.TipoDoc
            objInventario.tipoOperacion = InventarioMovimientoBE.TipoOperacion
            objInventario.serie = InventarioMovimientoBE.Serie
            objInventario.numero = InventarioMovimientoBE.NumDoc
            objInventario.idDocumento = objDocumento.idDocumento
            objInventario.idDocumentoRef = objDocumento.idDocumento
            objInventario.descripcion = InventarioMovimientoBE.descripcionItem
            objInventario.fechaLaboral = InventarioMovimientoBE.FechaLaboral
            objInventario.fecha = InventarioMovimientoBE.FechaDoc
            objInventario.tipoRegistro = "S"
            objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
            objInventario.tipoProducto = InventarioMovimientoBE.tipoExistencia
            objInventario.cuentaOrigen = InventarioMovimientoBE.CuentaItem
            objInventario.idItem = InventarioMovimientoBE.idItem
            objInventario.presentacion = InventarioMovimientoBE.unidad2
            objInventario.fechavcto = InventarioMovimientoBE.FechaVcto
            objInventario.cantidad = InventarioMovimientoBE.monto1 * -1
            objInventario.unidad = InventarioMovimientoBE.unidad1
            objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
            objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2
            objInventario.precUnite = InventarioMovimientoBE.precioUnitario
            objInventario.precUniteUSD = InventarioMovimientoBE.precioUnitarioUS
            objInventario.monto = InventarioMovimientoBE.importe * -1
            objInventario.montoUSD = InventarioMovimientoBE.importeUS * -1

            objInventario.disponible = InventarioMovimientoBE.monto1
            objInventario.disponible2 = 0
            objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
            objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
            objInventario.status = "D"
            objInventario.entragado = "SI"
            objInventario.preEvento = InventarioMovimientoBE.preEvento
            objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
            objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion

            HeliosData.InventarioMovimiento.Add(objInventario)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objInventario.idInventario
        End Using
    End Function

    Public Function InsertAlmacenOE(ByVal InventarioMovimientoBE As documentocompradetalle, objDocumento As documento) As Integer
        Dim objInventario As New InventarioMovimiento
        Dim almacenBL As New almacenBL
        Using ts As New TransactionScope
            objInventario = New InventarioMovimiento
            objInventario.idEmpresa = InventarioMovimientoBE.IdEmpresa
            objInventario.idEstablecimiento = almacenBL.GetUbicar_almacenPorID(InventarioMovimientoBE.almacenDestino).idEstablecimiento
            objInventario.idAlmacen = InventarioMovimientoBE.almacenDestino
            objInventario.tipoDocAlmacen = InventarioMovimientoBE.TipoDoc
            objInventario.tipoOperacion = InventarioMovimientoBE.TipoOperacion
            objInventario.serie = InventarioMovimientoBE.Serie
            objInventario.numero = InventarioMovimientoBE.NumDoc
            objInventario.idDocumento = objDocumento.idDocumento
            objInventario.idDocumentoRef = objDocumento.idDocumento
            objInventario.descripcion = String.Concat("OTRAS ENTRADAS: ", InventarioMovimientoBE.descripcionItem)
            objInventario.fecha = InventarioMovimientoBE.FechaDoc
            objInventario.tipoRegistro = "EA"
            objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
            objInventario.tipoProducto = InventarioMovimientoBE.tipoExistencia
            objInventario.cuentaOrigen = InventarioMovimientoBE.CuentaItem
            objInventario.idItem = InventarioMovimientoBE.idItem
            objInventario.presentacion = InventarioMovimientoBE.unidad2
            objInventario.fechavcto = InventarioMovimientoBE.FechaVcto
            objInventario.cantidad = InventarioMovimientoBE.monto1
            objInventario.unidad = InventarioMovimientoBE.unidad1
            objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
            objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2
            objInventario.precUnite = InventarioMovimientoBE.precioUnitario
            objInventario.precUniteUSD = InventarioMovimientoBE.precioUnitarioUS
            objInventario.monto = InventarioMovimientoBE.importe
            objInventario.montoUSD = InventarioMovimientoBE.importeUS

            objInventario.disponible = InventarioMovimientoBE.monto1
            objInventario.disponible2 = 0
            objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
            objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
            objInventario.status = "D"
            objInventario.entragado = "SI"
            objInventario.preEvento = InventarioMovimientoBE.preEvento
            objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
            objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion

            HeliosData.InventarioMovimiento.Add(objInventario)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objInventario.idInventario
        End Using
    End Function

    Public Function InsertAlmacenOE_Origen(ByVal InventarioMovimientoBE As documentocompradetalle, objDocumento As documento) As Integer
        Dim objInventario As New InventarioMovimiento
        Dim almacenBL As New almacenBL
        Using ts As New TransactionScope
            objInventario = New InventarioMovimiento
            objInventario.idEmpresa = InventarioMovimientoBE.IdEmpresa
            objInventario.idEstablecimiento = almacenBL.GetUbicar_almacenPorID(InventarioMovimientoBE.almacenRef).idEstablecimiento
            objInventario.idAlmacen = InventarioMovimientoBE.almacenRef
            objInventario.tipoDocAlmacen = InventarioMovimientoBE.TipoDoc
            objInventario.tipoOperacion = InventarioMovimientoBE.TipoOperacion
            objInventario.serie = InventarioMovimientoBE.Serie
            objInventario.numero = InventarioMovimientoBE.NumDoc
            objInventario.idDocumento = objDocumento.idDocumento
            objInventario.idDocumentoRef = objDocumento.idDocumento
            objInventario.descripcion = String.Concat("TRANSFERENCIA ENTRE ALMACENES: ", InventarioMovimientoBE.descripcionItem)
            objInventario.fecha = InventarioMovimientoBE.FechaDoc
            objInventario.tipoRegistro = "S"
            objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
            objInventario.tipoProducto = InventarioMovimientoBE.tipoExistencia
            objInventario.cuentaOrigen = InventarioMovimientoBE.CuentaItem
            objInventario.idItem = InventarioMovimientoBE.idItem
            objInventario.presentacion = InventarioMovimientoBE.unidad2
            objInventario.fechavcto = InventarioMovimientoBE.FechaVcto
            objInventario.cantidad = InventarioMovimientoBE.monto1 * -1
            objInventario.unidad = InventarioMovimientoBE.unidad1
            objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
            objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2
            objInventario.precUnite = InventarioMovimientoBE.precioUnitario
            objInventario.precUniteUSD = InventarioMovimientoBE.precioUnitarioUS
            objInventario.monto = InventarioMovimientoBE.importe * -1
            objInventario.montoUSD = InventarioMovimientoBE.importeUS * -1

            objInventario.disponible = InventarioMovimientoBE.monto1
            objInventario.disponible2 = 0
            objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
            objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
            objInventario.status = "D"
            objInventario.entragado = "SI"
            objInventario.preEvento = InventarioMovimientoBE.preEvento
            objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
            objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion

            HeliosData.InventarioMovimiento.Add(objInventario)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objInventario.idInventario
        End Using
    End Function

    Public Function InsertAportes(ByVal InventarioMovimientoBE As documentocompradetalle, objDocumento As documento) As Integer
        Dim objInventario As New InventarioMovimiento
        Dim almacenBL As New almacenBL
        Using ts As New TransactionScope
            objInventario = New InventarioMovimiento
            objInventario.idEmpresa = InventarioMovimientoBE.IdEmpresa
            objInventario.idEstablecimiento = InventarioMovimientoBE.IdEstablecimiento
            objInventario.idAlmacen = InventarioMovimientoBE.almacenRef
            objInventario.tipoDocAlmacen = InventarioMovimientoBE.TipoDoc
            objInventario.tipoOperacion = "17"
            objInventario.serie = InventarioMovimientoBE.Serie
            objInventario.numero = InventarioMovimientoBE.NumDoc
            objInventario.idDocumento = objDocumento.idDocumento
            objInventario.idDocumentoRef = objDocumento.idDocumento
            objInventario.descripcion = String.Concat("POR APORTES: ", InventarioMovimientoBE.descripcionItem)
            objInventario.fecha = InventarioMovimientoBE.FechaDoc
            objInventario.tipoRegistro = "EA"
            objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
            objInventario.tipoProducto = InventarioMovimientoBE.tipoExistencia
            objInventario.cuentaOrigen = InventarioMovimientoBE.CuentaItem
            objInventario.idItem = InventarioMovimientoBE.idItem
            objInventario.presentacion = InventarioMovimientoBE.unidad2
            objInventario.fechavcto = InventarioMovimientoBE.FechaVcto
            objInventario.cantidad = InventarioMovimientoBE.monto1
            objInventario.unidad = InventarioMovimientoBE.unidad1
            objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
            objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2
            objInventario.precUnite = InventarioMovimientoBE.precioUnitario
            objInventario.precUniteUSD = InventarioMovimientoBE.precioUnitarioUS
            objInventario.monto = InventarioMovimientoBE.importe
            objInventario.montoUSD = InventarioMovimientoBE.importeUS

            objInventario.disponible = InventarioMovimientoBE.monto1
            objInventario.disponible2 = 0
            objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
            objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
            objInventario.status = "D"
            objInventario.entragado = "SI"
            objInventario.preEvento = InventarioMovimientoBE.preEvento
            objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
            objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion

            HeliosData.InventarioMovimiento.Add(objInventario)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objInventario.idInventario
        End Using
    End Function

    Public Sub Update(ByVal InventarioMovimientoBE As InventarioMovimiento)
        Using ts As New TransactionScope
            Dim InvMovimiento As InventarioMovimiento = HeliosData.InventarioMovimiento.Where(Function(o) _
                                            o.idInventario = InventarioMovimientoBE.idInventario _
                                            And o.idAlmacen = InventarioMovimientoBE.idAlmacen _
                                            And o.idDocumento = InventarioMovimientoBE.idDocumento _
                                            And o.idItem = InventarioMovimientoBE.idItem).First()

            InvMovimiento.idEmpresa = InventarioMovimientoBE.idEmpresa
            InvMovimiento.idEstablecimiento = InventarioMovimientoBE.idEstablecimiento
            InvMovimiento.tipoOperacion = InventarioMovimientoBE.tipoOperacion
            InvMovimiento.tipoDocAlmacen = InventarioMovimientoBE.tipoDocAlmacen
            InvMovimiento.serie = InventarioMovimientoBE.serie
            InvMovimiento.numero = InventarioMovimientoBE.numero
            InvMovimiento.idDocumentoRef = InventarioMovimientoBE.idDocumentoRef
            InvMovimiento.descripcion = InventarioMovimientoBE.descripcion
            InvMovimiento.fecha = InventarioMovimientoBE.fecha
            InvMovimiento.tipoRegistro = InventarioMovimientoBE.tipoRegistro
            InvMovimiento.destinoGravadoItem = InventarioMovimientoBE.destinoGravadoItem
            InvMovimiento.tipoProducto = InventarioMovimientoBE.tipoProducto
            InvMovimiento.OrigentipoProducto = InventarioMovimientoBE.OrigentipoProducto
            InvMovimiento.cuentaOrigen = InventarioMovimientoBE.cuentaOrigen
            InvMovimiento.presentacion = InventarioMovimientoBE.presentacion
            InvMovimiento.fechavcto = InventarioMovimientoBE.fechavcto
            InvMovimiento.cantidad = InventarioMovimientoBE.cantidad
            InvMovimiento.unidad = InventarioMovimientoBE.unidad
            InvMovimiento.cantidad2 = InventarioMovimientoBE.cantidad2
            InvMovimiento.unidad2 = InventarioMovimientoBE.unidad2
            InvMovimiento.precUnite = InventarioMovimientoBE.precUnite
            InvMovimiento.precUniteUSD = InventarioMovimientoBE.precUniteUSD
            InvMovimiento.monto = InventarioMovimientoBE.monto
            InvMovimiento.montoUSD = InventarioMovimientoBE.montoUSD
            InvMovimiento.montoOther = InventarioMovimientoBE.montoOther
            InvMovimiento.monedaOther = InventarioMovimientoBE.monedaOther
            InvMovimiento.disponible = InventarioMovimientoBE.disponible
            InvMovimiento.disponible2 = InventarioMovimientoBE.disponible2
            InvMovimiento.saldoMonto = InventarioMovimientoBE.saldoMonto
            InvMovimiento.saldoMontoUsd = InventarioMovimientoBE.saldoMontoUsd
            InvMovimiento.status = InventarioMovimientoBE.status
            InvMovimiento.entragado = InventarioMovimientoBE.entragado
            InvMovimiento.preEvento = InventarioMovimientoBE.preEvento
            InvMovimiento.usuarioActualizacion = InventarioMovimientoBE.usuarioActualizacion
            InvMovimiento.consignado = InventarioMovimientoBE.consignado
            InvMovimiento.fechaActualizacion = InventarioMovimientoBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(InvMovimiento).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal InventarioMovimientoBE As InventarioMovimiento)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(InventarioMovimientoBE)
    End Sub

    Public Sub DeleteInventarioPorDocumento(intIdDocumento As Integer)
        Using ts As New TransactionScope
            Dim consulta As List(Of InventarioMovimiento) = HeliosData.InventarioMovimiento.Where(Function(o) o.idDocumento = intIdDocumento).ToList
            For Each obj In consulta
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(obj)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub DeleteInventarioPorDocumentoXitem(intIdDocumento As Integer, intIdAlmacen As Integer, intIdItem As Integer)
        Dim consulta As InventarioMovimiento = HeliosData.InventarioMovimiento.Where(Function(o) o.idDocumento = intIdDocumento And o.idAlmacen = intIdAlmacen _
                                                                                                And o.idItem = intIdItem).FirstOrDefault

        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)

        HeliosData.SaveChanges()
    End Sub

    Public Function GetListar_InventarioMovimiento() As List(Of InventarioMovimiento)
        Return (From a In HeliosData.InventarioMovimiento Select a).ToList
    End Function

    Public Function GetUbicar_InventarioMovimientoPorID(idInventario As Integer) As InventarioMovimiento
        Return (From a In HeliosData.InventarioMovimiento
                 Where a.idInventario = idInventario Select a).First
    End Function

    Public Function GetUbicar_InventarioMovimientoCompra(idDocumento As Integer, strTipoRegistro As String) As InventarioMovimiento
        Return (From a In HeliosData.InventarioMovimiento
                Where a.idDocumento = idDocumento _
                 And a.tipoRegistro = strTipoRegistro Select a).First
    End Function

    Public Function GetUbicar_InventarioMovimiento(idDocumento As Integer) As List(Of InventarioMovimiento)
        Dim con = HeliosData.InventarioMovimiento.Where(Function(o) o.idDocumento = idDocumento).ToList
        Return con
    End Function

    Public Function InsertTransferenciaDistribucion(ByVal InventarioMovimientoBE As documentoguiaDetalle) As Integer
        Dim objInventario As New InventarioMovimiento
        Dim almacenBL As New almacenBL
        Using ts As New TransactionScope
            objInventario = New InventarioMovimiento
            objInventario.idorigenDetalle = InventarioMovimientoBE.secuencia
            objInventario.nrolote = InventarioMovimientoBE.codigoLote
            objInventario.idEmpresa = InventarioMovimientoBE.idEmpresa
            objInventario.idEstablecimiento = InventarioMovimientoBE.IdEstablecimiento
            objInventario.tipoOperacion = "11"
            objInventario.tipoDocAlmacen = "99"
            objInventario.serie = InventarioMovimientoBE.Serie
            objInventario.numero = InventarioMovimientoBE.numerodoc
            objInventario.idDocumento = InventarioMovimientoBE.idDocumento
            objInventario.idDocumentoRef = InventarioMovimientoBE.idDocumento
            'objInventario.marca = InventarioMovimientoBE.marcaRef
            objInventario.descripcion = InventarioMovimientoBE.descripcionItem
            objInventario.fechaLaboral = InventarioMovimientoBE.fecha
            objInventario.fecha = InventarioMovimientoBE.fecha
            objInventario.tipoRegistro = InventarioMovimientoBE.TipoRegistro
            objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
            objInventario.tipoProducto = InventarioMovimientoBE.tipoExistencia
            'objInventario.cuentaOrigen = InventarioMovimientoBE.CuentaItem
            objInventario.idItem = InventarioMovimientoBE.idItem
            objInventario.presentacion = InventarioMovimientoBE.unidadMedida
            objInventario.fechavcto = InventarioMovimientoBE.fecha

            Select Case InventarioMovimientoBE.TipoRegistro
                Case "E"
                    objInventario.idAlmacen = InventarioMovimientoBE.almacenRef  ' ALMACEN DE DESTINO DE LA MERCADERIA TRASLADADA
                    objInventario.cantidad = InventarioMovimientoBE.cantConforme
                    objInventario.unidad = InventarioMovimientoBE.unidadMedida
                    objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
                    objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2
                    objInventario.precUnite = InventarioMovimientoBE.precioUnitario
                    objInventario.precUniteUSD = InventarioMovimientoBE.precioUnitarioUS
                    objInventario.monto = InventarioMovimientoBE.importeMN
                    objInventario.montoUSD = InventarioMovimientoBE.importeME
                Case Else
                    objInventario.idAlmacen = InventarioMovimientoBE.almacenRef ' ALMACEN DE ORIGEN DE SALIDA DE MERCADERIA
                    objInventario.cantidad = InventarioMovimientoBE.cantPendiente * -1
                    objInventario.unidad = InventarioMovimientoBE.unidadMedida
                    objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
                    objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2
                    objInventario.precUnite = InventarioMovimientoBE.precioUnitario
                    objInventario.precUniteUSD = InventarioMovimientoBE.precioUnitarioUS
                    objInventario.monto = InventarioMovimientoBE.importeMN * -1
                    objInventario.montoUSD = InventarioMovimientoBE.importeME * -1
            End Select
            objInventario.disponible = 0
            objInventario.disponible2 = 0
            objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
            objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
            objInventario.status = "D"
            objInventario.entragado = "NO"
            objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
            objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion
            HeliosData.InventarioMovimiento.Add(objInventario)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objInventario.idInventario
        End Using
    End Function

    Public Function InsertCambioInventario(ByVal InventarioMovimientoBE As documentocompradetalle, objDocumento As documento, strIdItem As Integer, strTipoExistencia As String) As Integer
        Dim objInventario As New InventarioMovimiento
        Dim almacenBL As New almacenBL
        Using ts As New TransactionScope
            objInventario = New InventarioMovimiento
            objInventario.idorigenDetalle = InventarioMovimientoBE.secuencia
            objInventario.idEmpresa = InventarioMovimientoBE.IdEmpresa
            objInventario.idEstablecimiento = InventarioMovimientoBE.IdEstablecimiento
            objInventario.tipoOperacion = InventarioMovimientoBE.TipoOperacion
            objInventario.tipoDocAlmacen = InventarioMovimientoBE.TipoDoc
            objInventario.serie = InventarioMovimientoBE.Serie
            objInventario.numero = InventarioMovimientoBE.NumDoc
            objInventario.idDocumento = objDocumento.idDocumento
            objInventario.idDocumentoRef = objDocumento.idDocumento
            objInventario.marca = InventarioMovimientoBE.marcaRef
            objInventario.descripcion = InventarioMovimientoBE.descripcionItem
            objInventario.fechaLaboral = InventarioMovimientoBE.FechaLaboral
            objInventario.fecha = InventarioMovimientoBE.FechaDoc
            objInventario.tipoRegistro = InventarioMovimientoBE.TipoRegistro
            objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
            objInventario.tipoProducto = strTipoExistencia
            objInventario.cuentaOrigen = InventarioMovimientoBE.CuentaItem
            objInventario.idItem = strIdItem
            objInventario.presentacion = InventarioMovimientoBE.unidad2
            objInventario.fechavcto = InventarioMovimientoBE.FechaVcto

            Select Case InventarioMovimientoBE.TipoRegistro
                Case "E"
                    objInventario.idAlmacen = InventarioMovimientoBE.almacenDestino ' ALMACEN DE DESTINO DE LA MERCADERIA TRASLADADA
                    objInventario.cantidad = InventarioMovimientoBE.monto1
                    objInventario.unidad = InventarioMovimientoBE.unidad1
                    objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
                    objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2
                    objInventario.precUnite = InventarioMovimientoBE.precioUnitario
                    objInventario.precUniteUSD = InventarioMovimientoBE.precioUnitarioUS
                    objInventario.monto = InventarioMovimientoBE.importe
                    objInventario.montoUSD = InventarioMovimientoBE.importeUS
                Case Else
                    objInventario.idAlmacen = InventarioMovimientoBE.almacenRef ' ALMACEN DE ORIGEN DE SALIDA DE MERCADERIA
                    objInventario.cantidad = InventarioMovimientoBE.monto1 * -1
                    objInventario.unidad = InventarioMovimientoBE.unidad1
                    objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
                    objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2
                    objInventario.precUnite = InventarioMovimientoBE.precioUnitario
                    objInventario.precUniteUSD = InventarioMovimientoBE.precioUnitarioUS
                    objInventario.monto = InventarioMovimientoBE.importe * -1
                    objInventario.montoUSD = InventarioMovimientoBE.importeUS * -1
            End Select
            objInventario.disponible = 0
            objInventario.disponible2 = 0
            objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
            objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
            objInventario.status = "D"
            objInventario.entragado = "NO"
            objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
            objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion
            HeliosData.InventarioMovimiento.Add(objInventario)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objInventario.idInventario
        End Using
    End Function

    Public Function GetMovimientosKardexByMesXusuario(be As InventarioMovimiento, listaUsuario As List(Of String), tipo As String, periodo As String, fechainicio As DateTime, fechaFin As DateTime) As List(Of InventarioMovimiento)
        Dim obj As New InventarioMovimiento
        Dim lista As New List(Of InventarioMovimiento)
        Dim listaOperacion As New List(Of String)
        listaOperacion.Add("02")
        listaOperacion.Add("03.01")
        listaOperacion.Add("07.01")
        listaOperacion.Add("08.01")
        listaOperacion.Add("09.01")
        listaOperacion.Add("10.03")
        listaOperacion.Add("9904")
        listaOperacion.Add("10.07")
        listaOperacion.Add("05")
        listaOperacion.Add("0000")
        listaOperacion.Add("04.01")
        listaOperacion.Add("08.02")
        listaOperacion.Add("09.02")
        listaOperacion.Add("12")
        listaOperacion.Add("13")
        listaOperacion.Add("14")
        listaOperacion.Add("15")
        listaOperacion.Add("06")
        listaOperacion.Add("0001")
        listaOperacion.Add("11")
        listaOperacion.Add("01")

        Select Case tipo
            Case "XDia"
                Dim consulta = (From t In HeliosData.InventarioMovimiento
                                Join art In HeliosData.detalleitems
                       On art.codigodetalle Equals t.idItem
                                Where
                                    art.estado = "A" And
                           (t.fecha) >= fechainicio And
                           (t.fecha) <= fechaFin And
                           t.idAlmacen = be.idAlmacen And
                           listaUsuario.Contains(t.usuarioActualizacion) And
                           listaOperacion.Contains(t.tipoOperacion)
                                Order By art.descripcionItem, t.tipoProducto, art.origenProducto, t.fecha Ascending
                                Select
                           t.idInventario,
                           t.fecha,
                           t.idEmpresa,
                           t.idAlmacen,
                           t.tipoProducto,
                           t.idDocumento,
                           t.tipoRegistro,
                           t.serie,
                           t.numero,
                           t.tipoOperacion,
                           art.codigodetalle,
                           art.origenProducto,
                           t.descripcion,
                           art.descripcionItem,
                           art.unidad1,
                           t.cantidad,
                           t.monto,
                           DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                   Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                   Select New With
                                                           {
                                                           c.descripcion
                                                           }).FirstOrDefault().descripcion,
                           Valor_venta = (From c In HeliosData.documentoventaAbarrotesDet
                                          Where c.idDocumento = t.idDocumento And c.idItem = t.idItem
                                          Select New With
                                                      {
                                                      c.montokardex
                                                      }).FirstOrDefault().montokardex).ToList


                'Dim listaVenta = consulta.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.VENTA).ToList
                For Each i In consulta
                    obj = New InventarioMovimiento
                    obj.idInventario = i.idInventario
                    obj.ValorDeVenta = i.Valor_venta.GetValueOrDefault
                    'obj.NombreAlmacen = i.descripcionAlmacen
                    obj.fecha = i.fecha
                    obj.idEmpresa = i.idEmpresa
                    obj.idAlmacen = i.idAlmacen
                    obj.tipoProducto = i.tipoProducto
                    obj.idDocumento = i.idDocumento
                    obj.tipoRegistro = i.tipoRegistro
                    obj.serie = i.serie
                    obj.numero = i.numero
                    obj.tipoOperacion = i.tipoOperacion
                    obj.DetalleTipoOperacion = i.DetalleTipoOperacion
                    obj.idItem = i.codigodetalle
                    obj.destinoGravadoItem = i.origenProducto
                    obj.descripcion = i.descripcionItem
                    obj.nombreItem = i.descripcionItem
                    obj.unidad = i.unidad1
                    obj.cantidad = i.cantidad
                    obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
                    obj.monto = i.monto
                    obj.montoOther = 0 ' i.CierreImporteMesAnterior.GetValueOrDefault
                    lista.Add(obj)
                Next

            Case "XPeriodo"
                Dim consulta = (From t In HeliosData.InventarioMovimiento
                                Join art In HeliosData.detalleitems
                       On art.codigodetalle Equals t.idItem
                                Where
                                    art.estado = "A" And
                           CLng(t.fecha.Value.Year) = be.fechaLaboral.Value.Year And
                           CLng(t.fecha.Value.Month) = be.fechaLaboral.Value.Month And
                           t.idAlmacen = be.idAlmacen And
                           listaUsuario.Contains(t.usuarioActualizacion) And
                           listaOperacion.Contains(t.tipoOperacion)
                                Order By art.descripcionItem, t.tipoProducto, art.origenProducto, t.fecha Ascending
                                Select
                           t.idInventario,
                           t.fecha,
                           t.idEmpresa,
                           t.idAlmacen,
                           t.tipoProducto,
                           t.idDocumento,
                           t.tipoRegistro,
                           t.serie,
                           t.numero,
                           t.tipoOperacion,
                           art.codigodetalle,
                           art.origenProducto,
                           t.descripcion,
                           art.descripcionItem,
                           art.unidad1,
                           t.cantidad,
                           t.monto,
                           DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                   Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                   Select New With
                                                           {
                                                           c.descripcion
                                                           }).FirstOrDefault().descripcion,
                           Valor_venta = (From c In HeliosData.documentoventaAbarrotesDet
                                          Where c.idDocumento = t.idDocumento And c.idItem = t.idItem
                                          Select New With
                                                      {
                                                      c.montokardex
                                                      }).FirstOrDefault().montokardex).ToList


                'Dim listaVenta = consulta.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.VENTA).ToList
                For Each i In consulta
                    obj = New InventarioMovimiento
                    obj.idInventario = i.idInventario
                    obj.ValorDeVenta = i.Valor_venta.GetValueOrDefault
                    'obj.NombreAlmacen = i.descripcionAlmacen
                    obj.fecha = i.fecha
                    obj.idEmpresa = i.idEmpresa
                    obj.idAlmacen = i.idAlmacen
                    obj.tipoProducto = i.tipoProducto
                    obj.idDocumento = i.idDocumento
                    obj.tipoRegistro = i.tipoRegistro
                    obj.serie = i.serie
                    obj.numero = i.numero
                    obj.tipoOperacion = i.tipoOperacion
                    obj.DetalleTipoOperacion = i.DetalleTipoOperacion
                    obj.idItem = i.codigodetalle
                    obj.destinoGravadoItem = i.origenProducto
                    obj.descripcion = i.descripcionItem
                    obj.nombreItem = i.descripcionItem
                    obj.unidad = i.unidad1
                    obj.cantidad = i.cantidad
                    obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
                    obj.monto = i.monto
                    obj.montoOther = 0 ' i.CierreImporteMesAnterior.GetValueOrDefault
                    lista.Add(obj)
                Next

            Case "XTodo"
                Dim consulta = (From t In HeliosData.InventarioMovimiento
                                Join art In HeliosData.detalleitems
                       On art.codigodetalle Equals t.idItem
                                Where
                                    art.estado = "A" And
                           CLng(t.fecha.Value.Year) = be.fechaLaboral.Value.Year And
                           CLng(t.fecha.Value.Month) = be.fechaLaboral.Value.Month And
                           t.idAlmacen = be.idAlmacen And
                           listaUsuario.Contains(t.usuarioActualizacion) And
                           listaOperacion.Contains(t.tipoOperacion)
                                Order By art.descripcionItem, t.tipoProducto, art.origenProducto, t.fecha Ascending
                                Select
                           t.idInventario,
                           t.fecha,
                           t.idEmpresa,
                           t.idAlmacen,
                           t.tipoProducto,
                           t.idDocumento,
                           t.tipoRegistro,
                           t.serie,
                           t.numero,
                           t.tipoOperacion,
                           art.codigodetalle,
                           art.origenProducto,
                           t.descripcion,
                           art.descripcionItem,
                           art.unidad1,
                           t.cantidad,
                           t.monto,
                           DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                   Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                   Select New With
                                                           {
                                                           c.descripcion
                                                           }).FirstOrDefault().descripcion,
                           Valor_venta = (From c In HeliosData.documentoventaAbarrotesDet
                                          Where c.idDocumento = t.idDocumento And c.idItem = t.idItem
                                          Select New With
                                                      {
                                                      c.montokardex
                                                      }).FirstOrDefault().montokardex).ToList


                'Dim listaVenta = consulta.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.VENTA).ToList
                For Each i In consulta
                    obj = New InventarioMovimiento
                    obj.idInventario = i.idInventario
                    obj.ValorDeVenta = i.Valor_venta.GetValueOrDefault
                    'obj.NombreAlmacen = i.descripcionAlmacen
                    obj.fecha = i.fecha
                    obj.idEmpresa = i.idEmpresa
                    obj.idAlmacen = i.idAlmacen
                    obj.tipoProducto = i.tipoProducto
                    obj.idDocumento = i.idDocumento
                    obj.tipoRegistro = i.tipoRegistro
                    obj.serie = i.serie
                    obj.numero = i.numero
                    obj.tipoOperacion = i.tipoOperacion
                    obj.DetalleTipoOperacion = i.DetalleTipoOperacion
                    obj.idItem = i.codigodetalle
                    obj.destinoGravadoItem = i.origenProducto
                    obj.descripcion = i.descripcionItem
                    obj.nombreItem = i.descripcionItem
                    obj.unidad = i.unidad1
                    obj.cantidad = i.cantidad
                    obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
                    obj.monto = i.monto
                    obj.montoOther = 0 ' i.CierreImporteMesAnterior.GetValueOrDefault
                    lista.Add(obj)
                Next
        End Select

        Return lista
    End Function

    Public Function GetMovimientosKardexByMesAllAlmacenXusuario(be As InventarioMovimiento, listaUsuario As List(Of String), tipo As String, periodo As String, fechaInicio As DateTime, fechaFin As DateTime) As List(Of InventarioMovimiento)
        Dim obj As New InventarioMovimiento
        Dim lista As New List(Of InventarioMovimiento)
        Dim listaOperacion As New List(Of String)
        listaOperacion.Add("02")
        listaOperacion.Add("03.01")
        listaOperacion.Add("07.01")
        listaOperacion.Add("08.01")
        listaOperacion.Add("09.01")
        listaOperacion.Add("10.03")
        listaOperacion.Add("9904")
        listaOperacion.Add("10.07")
        listaOperacion.Add("05")
        listaOperacion.Add("0000")
        listaOperacion.Add("04.01")
        listaOperacion.Add("08.02")
        listaOperacion.Add("09.02")
        listaOperacion.Add("12")
        listaOperacion.Add("13")
        listaOperacion.Add("14")
        listaOperacion.Add("15")
        listaOperacion.Add("06")
        listaOperacion.Add("0001")
        listaOperacion.Add("11")
        listaOperacion.Add("01")

        Select Case tipo
            Case "XTodo"
                Dim consulta = (From t In HeliosData.InventarioMovimiento
                                Join art In HeliosData.detalleitems
                     On art.codigodetalle Equals t.idItem
                                Where
                                    art.estado = "A" And
                      CLng(t.fecha.Value.Year) = be.fechaLaboral.Value.Year And
                         CLng(t.fecha.Value.Month) = be.fechaLaboral.Value.Month And
                            listaUsuario.Contains(t.usuarioActualizacion) And
                            listaOperacion.Contains(t.tipoOperacion)
                                Order By t.idAlmacen, art.descripcionItem, t.tipoProducto, art.origenProducto, t.fecha Ascending
                                Select
                         t.idInventario,
                         t.fecha,
                         t.idEmpresa,
                         t.idAlmacen,
                         t.tipoProducto,
                         t.idDocumento,
                         t.tipoRegistro,
                         t.serie,
                         t.numero,
                         t.tipoOperacion,
                         art.codigodetalle,
                         art.origenProducto,
                         t.descripcion,
                         art.descripcionItem,
                         art.unidad1,
                         t.cantidad,
                         t.monto,
                         DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                 Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                 Select New With
                                                         {
                                                         c.descripcion
                                                         }).FirstOrDefault().descripcion).ToList


                For Each i In consulta
                    obj = New InventarioMovimiento
                    obj.idInventario = i.idInventario
                    'obj.NombreAlmacen = i.descripcionAlmacen
                    obj.fecha = i.fecha
                    obj.idEmpresa = i.idEmpresa
                    obj.idAlmacen = i.idAlmacen
                    obj.tipoProducto = i.tipoProducto
                    obj.idDocumento = i.idDocumento
                    obj.tipoRegistro = i.tipoRegistro
                    obj.serie = i.serie
                    obj.numero = i.numero
                    obj.tipoOperacion = i.tipoOperacion
                    obj.DetalleTipoOperacion = i.DetalleTipoOperacion
                    obj.idItem = i.codigodetalle
                    obj.destinoGravadoItem = i.origenProducto
                    obj.descripcion = i.descripcionItem
                    obj.nombreItem = i.descripcionItem
                    obj.unidad = i.unidad1
                    obj.cantidad = i.cantidad
                    obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
                    obj.monto = i.monto
                    obj.montoOther = 0 ' i.CierreImporteMesAnterior.GetValueOrDefault
                    lista.Add(obj)
                Next
            Case "XDia"
                Dim consulta = (From t In HeliosData.InventarioMovimiento
                                Join art In HeliosData.detalleitems
                     On art.codigodetalle Equals t.idItem
                                Where
                                    art.estado = "A" And
                          (t.fecha) >= fechaInicio And
                           (t.fecha) <= fechaFin And
                         listaUsuario.Contains(t.usuarioActualizacion) And
                            listaOperacion.Contains(t.tipoOperacion)
                                Order By t.idAlmacen, art.descripcionItem, t.tipoProducto, art.origenProducto, t.fecha Ascending
                                Select
                         t.idInventario,
                         t.fecha,
                         t.idEmpresa,
                         t.idAlmacen,
                         t.tipoProducto,
                         t.idDocumento,
                         t.tipoRegistro,
                         t.serie,
                         t.numero,
                         t.tipoOperacion,
                         art.codigodetalle,
                         art.origenProducto,
                         t.descripcion,
                         art.descripcionItem,
                         art.unidad1,
                         t.cantidad,
                         t.monto,
                         DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                 Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                 Select New With
                                                         {
                                                         c.descripcion
                                                         }).FirstOrDefault().descripcion).ToList


                For Each i In consulta
                    obj = New InventarioMovimiento
                    obj.idInventario = i.idInventario
                    'obj.NombreAlmacen = i.descripcionAlmacen
                    obj.fecha = i.fecha
                    obj.idEmpresa = i.idEmpresa
                    obj.idAlmacen = i.idAlmacen
                    obj.tipoProducto = i.tipoProducto
                    obj.idDocumento = i.idDocumento
                    obj.tipoRegistro = i.tipoRegistro
                    obj.serie = i.serie
                    obj.numero = i.numero
                    obj.tipoOperacion = i.tipoOperacion
                    obj.DetalleTipoOperacion = i.DetalleTipoOperacion
                    obj.idItem = i.codigodetalle
                    obj.destinoGravadoItem = i.origenProducto
                    obj.descripcion = i.descripcionItem
                    obj.nombreItem = i.descripcionItem
                    obj.unidad = i.unidad1
                    obj.cantidad = i.cantidad
                    obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
                    obj.monto = i.monto
                    obj.montoOther = 0 ' i.CierreImporteMesAnterior.GetValueOrDefault
                    lista.Add(obj)
                Next
            Case "XPeriodo"
                Dim consulta = (From t In HeliosData.InventarioMovimiento
                                Join art In HeliosData.detalleitems
                     On art.codigodetalle Equals t.idItem
                                Where
                                    art.estado = "A" And
                        CLng(t.fecha.Value.Year) = be.fechaLaboral.Value.Year And
                         CLng(t.fecha.Value.Month) = be.fechaLaboral.Value.Month And
                         listaUsuario.Contains(t.usuarioActualizacion) And
                            listaOperacion.Contains(t.tipoOperacion)
                                Order By t.idAlmacen, art.descripcionItem, t.tipoProducto, art.origenProducto, t.fecha Ascending
                                Select
                         t.idInventario,
                         t.fecha,
                         t.idEmpresa,
                         t.idAlmacen,
                         t.tipoProducto,
                         t.idDocumento,
                         t.tipoRegistro,
                         t.serie,
                         t.numero,
                         t.tipoOperacion,
                         art.codigodetalle,
                         art.origenProducto,
                         t.descripcion,
                         art.descripcionItem,
                         art.unidad1,
                         t.cantidad,
                         t.monto,
                         DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                 Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                 Select New With
                                                         {
                                                         c.descripcion
                                                         }).FirstOrDefault().descripcion).ToList


                For Each i In consulta
                    obj = New InventarioMovimiento
                    obj.idInventario = i.idInventario
                    'obj.NombreAlmacen = i.descripcionAlmacen
                    obj.fecha = i.fecha
                    obj.idEmpresa = i.idEmpresa
                    obj.idAlmacen = i.idAlmacen
                    obj.tipoProducto = i.tipoProducto
                    obj.idDocumento = i.idDocumento
                    obj.tipoRegistro = i.tipoRegistro
                    obj.serie = i.serie
                    obj.numero = i.numero
                    obj.tipoOperacion = i.tipoOperacion
                    obj.DetalleTipoOperacion = i.DetalleTipoOperacion
                    obj.idItem = i.codigodetalle
                    obj.destinoGravadoItem = i.origenProducto
                    obj.descripcion = i.descripcionItem
                    obj.nombreItem = i.descripcionItem
                    obj.unidad = i.unidad1
                    obj.cantidad = i.cantidad
                    obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
                    obj.monto = i.monto
                    obj.montoOther = 0 ' i.CierreImporteMesAnterior.GetValueOrDefault
                    lista.Add(obj)
                Next
        End Select

        Return lista
    End Function


#Region "MARTIN"

    Public Function ObtenerConsultaKaredexProductos(strEmpresa As String, intIdEstablecimiento As Integer, ByVal idAlmacen As String, ByVal desde As Date, ByVal hasta As Date) As List(Of InventarioMovimiento)
        Dim Lista As New List(Of InventarioMovimiento)
        Dim objRecurso As New InventarioMovimiento
        Dim cant As Decimal = 0
        Dim cost As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim consulta = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Where p.idAlmacen = idAlmacen _
                                   And p.idEmpresa = strEmpresa _
                                   And p.idEstablecimiento = intIdEstablecimiento _
                                   And p.fecha >= desde _
                                   And p.fecha <= hasta _
                                     Order By p.idItem, p.fecha Ascending).ToList

        Dim x = 0
        For Each obj In consulta
            objRecurso = New InventarioMovimiento

            objRecurso.idInventario = obj.p.idInventario
            objRecurso.idEmpresa = obj.p.idEmpresa
            objRecurso.idEstablecimiento = obj.p.idEstablecimiento
            objRecurso.idAlmacen = obj.p.idAlmacen
            objRecurso.tipoOperacion = obj.p.tipoOperacion
            objRecurso.tipoDocAlmacen = obj.p.tipoDocAlmacen
            objRecurso.serie = obj.p.serie
            objRecurso.numero = obj.p.numero
            objRecurso.idDocumento = obj.p.idDocumento
            objRecurso.idDocumentoRef = obj.p.idDocumentoRef
            objRecurso.descripcion = obj.q.descripcionItem
            objRecurso.fecha = obj.p.fecha
            objRecurso.tipoRegistro = obj.p.tipoRegistro
            objRecurso.destinoGravadoItem = obj.p.destinoGravadoItem
            objRecurso.tipoProducto = obj.p.tipoProducto
            objRecurso.OrigentipoProducto = obj.p.OrigentipoProducto
            objRecurso.cuentaOrigen = obj.p.cuentaOrigen
            objRecurso.idItem = obj.p.idItem
            objRecurso.presentacion = obj.p.presentacion
            objRecurso.fechavcto = obj.p.fechavcto

            objRecurso.unidad = obj.p.unidad
            objRecurso.cantidad2 = obj.p.cantidad2
            objRecurso.unidad2 = obj.p.unidad2

            If obj.p.tipoRegistro = "E" Then
                objRecurso.cantidad = Math.Round(CDec(obj.p.cantidad), 2)
                objRecurso.precUnite = Math.Round(CDec(obj.p.precUnite), 2)
                objRecurso.monto = Math.Round(CDec(obj.p.monto), 2)
                objRecurso.CantSalida = "0.00"
                objRecurso.PrUnitS = "0.00"
                objRecurso.CostoSalida = "0.00"
            ElseIf obj.p.tipoRegistro = "S" Then
                objRecurso.cantidad = "0.00"
                objRecurso.precUnite = "0.00"
                objRecurso.monto = "0.00"
                objRecurso.CantSalida = Math.Round(CDec(obj.p.cantidad), 2)
                objRecurso.PrUnitS = Math.Round(CDec(obj.p.precUnite), 2)
                objRecurso.CostoSalida = Math.Round(CDec(obj.p.monto), 2)
            ElseIf obj.p.tipoRegistro = "EA" Then
                objRecurso.cantidad = Math.Round(CDec(obj.p.cantidad), 2)
                objRecurso.precUnite = Math.Round(CDec(obj.p.precUnite), 2)
                objRecurso.monto = Math.Round(CDec(obj.p.monto), 2)
                objRecurso.CantSalida = "0.00"
                objRecurso.PrUnitS = "0.00"
                objRecurso.CostoSalida = "0.00"
            End If


            objRecurso.precUniteUSD = obj.p.precUniteUSD
            objRecurso.montoUSD = obj.p.montoUSD
            objRecurso.montoOther = obj.p.montoOther
            objRecurso.monedaOther = obj.p.monedaOther
            objRecurso.disponible = obj.p.disponible
            objRecurso.disponible2 = obj.p.disponible2
            objRecurso.saldoMonto = obj.p.saldoMonto
            objRecurso.saldoMontoUsd = obj.p.saldoMontoUsd
            objRecurso.status = obj.p.status
            objRecurso.entragado = obj.p.entragado
            objRecurso.preEvento = obj.p.preEvento
            objRecurso.usuarioActualizacion = obj.p.usuarioActualizacion
            objRecurso.consignado = obj.p.consignado
            objRecurso.fechaActualizacion = obj.p.fechaActualizacion




            If x = 0 Then
                cant += Math.Round(CDec(obj.p.cantidad), 2)
                objRecurso.CantSaldo = cant

                cost += Math.Round(CDec(obj.p.monto), 2)
                objRecurso.CostoSaldo = cost
            Else
                cant = Math.Round(cant + CDec(obj.p.cantidad), 2)
                objRecurso.CantSaldo = cant
                cost = Math.Round(cost + CDec(obj.p.monto), 2)
                objRecurso.CostoSaldo = cost
            End If



            Lista.Add(objRecurso)
        Next

        Return Lista

    End Function


    Public Function ObtenerConsultaKaredexFecha(strEmpresa As String, intIdEstablecimiento As Integer, ByVal idAlmacen As String, ByVal strItem As String, ByVal desde As Date, ByVal hasta As Date) As List(Of InventarioMovimiento)
        Dim Lista As New List(Of InventarioMovimiento)
        Dim objRecurso As New InventarioMovimiento
        Dim cant As Decimal = 0
        Dim cost As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim consulta = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Where p.idAlmacen = idAlmacen _
                                   And p.idEmpresa = strEmpresa _
                                   And p.idEstablecimiento = intIdEstablecimiento _
                                   And p.idItem = strItem _
                                   And p.fecha >= desde _
                                   And p.fecha <= hasta _
                                   Order By p.idItem, p.fecha Ascending).ToList


        Dim x = 0
        For Each obj In consulta
            objRecurso = New InventarioMovimiento

            objRecurso.idInventario = obj.p.idInventario
            objRecurso.idEmpresa = obj.p.idEmpresa
            objRecurso.idEstablecimiento = obj.p.idEstablecimiento
            objRecurso.idAlmacen = obj.p.idAlmacen
            objRecurso.tipoOperacion = obj.p.tipoOperacion
            objRecurso.tipoDocAlmacen = obj.p.tipoDocAlmacen
            objRecurso.serie = obj.p.serie
            objRecurso.numero = obj.p.numero
            objRecurso.idDocumento = obj.p.idDocumento
            objRecurso.idDocumentoRef = obj.p.idDocumentoRef
            objRecurso.descripcion = obj.q.descripcionItem
            objRecurso.fecha = obj.p.fecha
            objRecurso.tipoRegistro = obj.p.tipoRegistro
            objRecurso.destinoGravadoItem = obj.p.destinoGravadoItem
            objRecurso.tipoProducto = obj.p.tipoProducto
            objRecurso.OrigentipoProducto = obj.p.OrigentipoProducto
            objRecurso.cuentaOrigen = obj.p.cuentaOrigen
            objRecurso.idItem = obj.p.idItem
            objRecurso.presentacion = obj.p.presentacion
            objRecurso.fechavcto = obj.p.fechavcto



            objRecurso.unidad = obj.p.unidad
            objRecurso.cantidad2 = obj.p.cantidad2
            objRecurso.unidad2 = obj.p.unidad2

            If obj.p.tipoRegistro = "E" Then
                objRecurso.cantidad = Math.Round(CDec(obj.p.cantidad), 2)
                objRecurso.precUnite = Math.Round(CDec(obj.p.precUnite), 2)
                objRecurso.monto = Math.Round(CDec(obj.p.monto), 2)
                objRecurso.CantSalida = "0.00"
                objRecurso.PrUnitS = "0.00"
                objRecurso.CostoSalida = "0.00"
            ElseIf obj.p.tipoRegistro = "S" Then
                objRecurso.cantidad = "0.00"
                objRecurso.precUnite = "0.00"
                objRecurso.monto = "0.00"
                objRecurso.CantSalida = Math.Round(CDec(obj.p.cantidad), 2)
                objRecurso.PrUnitS = Math.Round(CDec(obj.p.precUnite), 2)
                objRecurso.CostoSalida = Math.Round(CDec(obj.p.monto), 2)
            ElseIf obj.p.tipoRegistro = "EA" Then
                objRecurso.cantidad = Math.Round(CDec(obj.p.cantidad), 2)
                objRecurso.precUnite = Math.Round(CDec(obj.p.precUnite), 2)
                objRecurso.monto = Math.Round(CDec(obj.p.monto), 2)
                objRecurso.CantSalida = "0.00"
                objRecurso.PrUnitS = "0.00"
                objRecurso.CostoSalida = "0.00"
            End If


            objRecurso.precUniteUSD = obj.p.precUniteUSD
            objRecurso.montoUSD = obj.p.montoUSD
            objRecurso.montoOther = obj.p.montoOther
            objRecurso.monedaOther = obj.p.monedaOther
            objRecurso.disponible = obj.p.disponible
            objRecurso.disponible2 = obj.p.disponible2
            objRecurso.saldoMonto = obj.p.saldoMonto
            objRecurso.saldoMontoUsd = obj.p.saldoMontoUsd
            objRecurso.status = obj.p.status
            objRecurso.entragado = obj.p.entragado
            objRecurso.preEvento = obj.p.preEvento
            objRecurso.usuarioActualizacion = obj.p.usuarioActualizacion
            objRecurso.consignado = obj.p.consignado
            objRecurso.fechaActualizacion = obj.p.fechaActualizacion




            If x = 0 Then
                cant += Math.Round(CDec(obj.p.cantidad), 2)
                objRecurso.CantSaldo = cant

                cost += Math.Round(CDec(obj.p.monto), 2)
                objRecurso.CostoSaldo = cost
            Else
                cant = Math.Round(cant + CDec(obj.p.cantidad), 2)
                objRecurso.CantSaldo = cant
                cost = Math.Round(cost + CDec(obj.p.monto), 2)
                objRecurso.CostoSaldo = cost
            End If



            Lista.Add(objRecurso)
        Next

        Return Lista

    End Function

    Public Function ObtenerProdPorAlmacenesPorMes(ByVal idAlmacen As String, ByVal strItem As String, ByVal periodo As Integer, ByVal mes As String) As List(Of InventarioMovimiento)
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Try
            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Where p.idAlmacen = idAlmacen _
                                   And p.idItem = strItem _
                                   And p.fecha.Value.Month = CInt(mes) _
                                   And p.fecha.Value.Year = periodo _
                                   Order By p.fecha _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = q.descripcionItem, _
                                            .marca = p.marca, _
                                            .cantidad = p.cantidad, _
                                            .unidad = p.unidad, _
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = doc.nroDoc, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .tipoOperacion = p.tipoOperacion _
                                           } _
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento With _
                                            {.idInventario = obj.idInventario, _
                                             .fecha = obj.Fecha, _
                                             .idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa), _
                                             .idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen), _
                                             .idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem), _
                                             .nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem), _
                                             .marca = obj.marca, _
                                             .cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad), _
                                             .unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad), _
                                             .precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE), _
                                             .monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto), _
                                             .disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible), _
                                             .status = IIf(IsDBNull(obj.estado), Nothing, obj.estado), _
                                             .tipoRegistro = obj.TipoRegistro.ToString, _
                                             .glosa = obj.Glosa, _
                                             .NumDocCompra = obj.NroDoc, _
                                             .cuentaOrigen = obj.Cuenta, _
                                             .idDocumento = obj.IdDocumento, _
                                             .tipoProducto = obj.TipoProducto, _
                                             .destinoGravadoItem = obj.DestinoGravado, _
                                             .montoUSD = obj.CostoUS, _
                                             .tipoOperacion = obj.tipoOperacion _
                                             }
                listaInventario.Add(objInventarioMovimientoBO)
            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerProdPorAlmacenesPorMesAll(ByVal idAlmacen As String, ByVal year As Integer, ByVal mes As String) As List(Of InventarioMovimiento)
        Dim cierreBL As New cierreinventarioBL
        Dim cierre As New cierreinventario
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim producto As String = Nothing
        Dim productoCache As String = Nothing
        Try
            Dim periodoCierre As String = String.Format("{0:00}", mes) & year

            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Where p.idAlmacen = idAlmacen _
                                   And p.fecha.Value.Month = CInt(mes) _
                                   And p.fecha.Value.Year = year _
                                   Order By q.descripcionItem, p.fecha Ascending _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = q.descripcionItem, _
                                            .marca = p.marca, _
                                            .cantidad = p.cantidad, _
                                            .unidad = p.unidad, _
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = doc.nroDoc, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .tipoOperacion = p.tipoOperacion _
                                           } _
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento
                objInventarioMovimientoBO.idInventario = obj.idInventario
                objInventarioMovimientoBO.fecha = obj.Fecha
                objInventarioMovimientoBO.idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa)
                objInventarioMovimientoBO.idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen)
                objInventarioMovimientoBO.idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem)
                objInventarioMovimientoBO.nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem)
                objInventarioMovimientoBO.marca = obj.marca
                objInventarioMovimientoBO.disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible)
                objInventarioMovimientoBO.status = IIf(IsDBNull(obj.estado), Nothing, obj.estado)
                objInventarioMovimientoBO.tipoRegistro = obj.TipoRegistro.ToString
                objInventarioMovimientoBO.glosa = obj.Glosa
                objInventarioMovimientoBO.NumDocCompra = obj.NroDoc
                objInventarioMovimientoBO.cuentaOrigen = obj.Cuenta
                objInventarioMovimientoBO.idDocumento = obj.IdDocumento
                objInventarioMovimientoBO.tipoProducto = obj.TipoProducto
                objInventarioMovimientoBO.destinoGravadoItem = obj.DestinoGravado
                objInventarioMovimientoBO.tipoOperacion = obj.tipoOperacion
                'cierre = cierreBL.RecuperarCierre(year, mes - 1, obj.idItem)
                objInventarioMovimientoBO.cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad)
                objInventarioMovimientoBO.unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad)
                objInventarioMovimientoBO.precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE)
                objInventarioMovimientoBO.monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto)
                objInventarioMovimientoBO.montoUSD = obj.CostoUS

                listaInventario.Add(objInventarioMovimientoBO)

                producto = obj.idItem
                productoCache = obj.nombreItem

            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerKardexRangoFecha(ByVal idAlmacen As String, fecDesde As Date, fecHasta As Date) As List(Of InventarioMovimiento)
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Try
            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Where p.idAlmacen = idAlmacen _
                                   And p.fecha.Value >= fecDesde _
                                   And p.fecha.Value <= fecHasta _
                                   Order By q.descripcionItem, p.fecha Ascending _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = q.descripcionItem, _
                                            .marca = p.marca, _
                                            .cantidad = p.cantidad, _
                                            .unidad = p.unidad, _
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = doc.nroDoc, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .tipoOperacion = p.tipoOperacion _
                                           } _
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento With _
                                            {.idInventario = obj.idInventario, _
                                             .fecha = obj.Fecha, _
                                             .idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa), _
                                             .idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen), _
                                             .idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem), _
                                             .nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem), _
                                             .marca = obj.marca, _
                                             .cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad), _
                                             .unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad), _
                                             .precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE), _
                                             .monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto), _
                                             .disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible), _
                                             .status = IIf(IsDBNull(obj.estado), Nothing, obj.estado), _
                                             .tipoRegistro = obj.TipoRegistro.ToString, _
                                             .glosa = obj.Glosa, _
                                             .NumDocCompra = obj.NroDoc, _
                                             .cuentaOrigen = obj.Cuenta, _
                                             .idDocumento = obj.IdDocumento, _
                                             .tipoProducto = obj.TipoProducto, _
                                             .destinoGravadoItem = obj.DestinoGravado, _
                                             .montoUSD = obj.CostoUS, _
                                             .tipoOperacion = obj.tipoOperacion _
                                             }
                listaInventario.Add(objInventarioMovimientoBO)
            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerProdPorAlmacenesPorAnio(ByVal idAlmacen As String, ByVal strItem As String, ByVal Anio As Integer) As List(Of InventarioMovimiento)
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Try
            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Where p.idAlmacen = idAlmacen _
                                   And p.idItem = strItem _
                                   And p.fecha.Value.Year = Anio _
                                   Order By p.fecha _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = q.descripcionItem, _
                                           .marca = p.marca, _
                                            .cantidad = p.cantidad, _
                                            .unidad = p.unidad, _
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = doc.nroDoc, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .tipoOperacion = p.tipoOperacion _
                                           } _
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento With _
                                            {.idInventario = obj.idInventario, _
                                             .fecha = obj.Fecha, _
                                             .idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa), _
                                             .idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen), _
                                             .idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem), _
                                             .nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem), _
                                             .marca = obj.marca, _
                                             .cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad), _
                                             .unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad), _
                                             .precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE), _
                                             .monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto), _
                                             .disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible), _
                                             .status = IIf(IsDBNull(obj.estado), Nothing, obj.estado), _
                                             .tipoRegistro = obj.TipoRegistro.ToString, _
                                             .glosa = obj.Glosa, _
                                             .NumDocCompra = obj.NroDoc, _
                                             .cuentaOrigen = obj.Cuenta, _
                                             .idDocumento = obj.IdDocumento, _
                                             .tipoProducto = obj.TipoProducto, _
                                             .destinoGravadoItem = obj.DestinoGravado, _
                                             .montoUSD = obj.CostoUS, _
                                             .tipoOperacion = obj.tipoOperacion _
                                             }
                listaInventario.Add(objInventarioMovimientoBO)
            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerProdPorAlmacenesPorAnioAll(ByVal idAlmacen As String, ByVal Anio As Integer) As List(Of InventarioMovimiento)
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Try
            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Where p.idAlmacen = idAlmacen _
                                   And p.fecha.Value.Year = Anio _
                                   Order By q.descripcionItem, p.fecha _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = q.descripcionItem, _
                                            .marca = p.marca, _
                                            .cantidad = p.cantidad, _
                                            .unidad = p.unidad, _
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = doc.nroDoc, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .tipoOperacion = p.tipoOperacion _
                                           } _
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento With _
                                            {.idInventario = obj.idInventario, _
                                             .fecha = obj.Fecha, _
                                             .idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa), _
                                             .idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen), _
                                             .idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem), _
                                             .nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem), _
                                             .marca = obj.marca, _
                                             .cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad), _
                                             .unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad), _
                                             .precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE), _
                                             .monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto), _
                                             .disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible), _
                                             .status = IIf(IsDBNull(obj.estado), Nothing, obj.estado), _
                                             .tipoRegistro = obj.TipoRegistro.ToString, _
                                             .glosa = obj.Glosa, _
                                             .NumDocCompra = obj.NroDoc, _
                                             .cuentaOrigen = obj.Cuenta, _
                                             .idDocumento = obj.IdDocumento, _
                                             .tipoProducto = obj.TipoProducto, _
                                             .destinoGravadoItem = obj.DestinoGravado, _
                                             .montoUSD = obj.CostoUS, _
                                             .tipoOperacion = obj.tipoOperacion _
                                             }
                listaInventario.Add(objInventarioMovimientoBO)
            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ObtenerProdPorAlmacenesPorRango(ByVal idAlmacen As String, ByVal strItem As String, ByVal desde As Date, ByVal hasta As Date) As List(Of InventarioMovimiento)
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Try
            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Where p.idAlmacen = idAlmacen _
                                   And p.idItem = strItem _
                                   And p.fecha >= desde _
                                   And p.fecha <= hasta _
                                   Order By p.fecha _
                                 Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = q.descripcionItem, _
                                            .marca = p.marca, _
                                            .cantidad = p.cantidad, _
                                            .unidad = p.unidad, _
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = doc.nroDoc, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .tipoOperacion = p.tipoOperacion _
                                           } _
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento With _
                                            {.idInventario = obj.idInventario, _
                                             .fecha = obj.Fecha, _
                                             .idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa), _
                                             .idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen), _
                                             .idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem), _
                                             .nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem), _
                                             .marca = obj.marca, _
                                             .cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad), _
                                             .unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad), _
                                             .precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE), _
                                             .monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto), _
                                             .disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible), _
                                             .status = IIf(IsDBNull(obj.estado), Nothing, obj.estado), _
                                             .tipoRegistro = obj.TipoRegistro.ToString, _
                                             .glosa = obj.Glosa, _
                                             .NumDocCompra = obj.NroDoc, _
                                             .cuentaOrigen = obj.Cuenta, _
                                             .idDocumento = obj.IdDocumento, _
                                             .tipoProducto = obj.TipoProducto, _
                                             .destinoGravadoItem = obj.DestinoGravado, _
                                             .montoUSD = obj.CostoUS, _
                                             .tipoOperacion = obj.tipoOperacion _
                                             }
                listaInventario.Add(objInventarioMovimientoBO)
            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub EditarArticuloInicio(inv As InventarioMovimiento)
        Dim inventario As New InventarioMovimientoBL
        Dim totalesBL As New totalesAlmacenBL
        Using ts As New TransactionScope
            GetUpdateArticulo(inv)

            Dim TA = HeliosData.totalesAlmacen.Where(Function(o) o.idItem = inv.idItem And o.idAlmacen = inv.idAlmacen And o.codigoLote = inv.nrolote).FirstOrDefault


            Dim listaAcurar = inventario.GetCuracionEntradasAlmacenByArticuloLote(New InventarioMovimiento With {.idAlmacen = TA.idAlmacen,
                                                                              .fecha = New DateTime(inv.fecha.Value.Year,
                                                                                                    inv.fecha.Value.Month, 1),
                                                                                                    .tipoProducto = TA.tipoExistencia,
                                                                                                    .idItem = TA.idItem,
                                                                                                    .nrolote = inv.nrolote}, Nothing)
            totalesBL.GetCurarKardexCaberasLOTE(listaAcurar)


            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Private Sub GetUpdateArticulo(inv As InventarioMovimiento)
        Using ts As New TransactionScope
            Dim objInv = HeliosData.InventarioMovimiento.Where(Function(o) o.idInventario = inv.idInventario).FirstOrDefault
            If objInv IsNot Nothing Then
                objInv.cantidad = inv.cantidad
                objInv.monto = inv.monto
            End If

            Dim doc = HeliosData.documentoLibroDiarioDetalle.Where(Function(o) o.secuencia = inv.Secuencia).FirstOrDefault
            If doc IsNot Nothing Then
                doc.monto1 = inv.cantidad
                doc.importeMN = inv.monto
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetRentabilidadV2(be As InventarioMovimiento, fechaini As DateTime, fechafin As DateTime, tipo As String) As List(Of InventarioMovimiento)
        Dim obj As New InventarioMovimiento
        Dim lista As New List(Of InventarioMovimiento)
        Select Case tipo
            Case "Mes"

                Dim consulta = (From t In HeliosData.InventarioMovimiento
                                Join art In HeliosData.detalleitems
                                    On art.codigodetalle Equals t.idItem
                                Join Lote In HeliosData.recursoCostoLote
                                    On Lote.codigoLote Equals t.nrolote
                                Where
                                    CLng(t.fecha.Value.Year) = fechaini.Year And
                                    CLng(t.fecha.Value.Month) = fechaini.Month _
                                    And t.idAlmacen = be.idAlmacen
                                Order By art.descripcionItem, t.tipoProducto, art.origenProducto, t.nrolote, t.fecha Ascending
                                Select
                                    t.idInventario,
                                    t.contenido_neto,
                                    Lote.nroLote,
                                    Lote.codigoLote,
                                    Lote.fechaVcto,
                                    t.fecha,
                                    t.idEmpresa,
                                    t.idAlmacen,
                                    t.tipoProducto,
                                    t.idDocumento,
                                    t.tipoRegistro,
                                    t.serie,
                                    t.numero,
                                    t.tipoOperacion,
                                    art.codigodetalle,
                                    art.origenProducto,
                                    t.descripcion,
                                    art.descripcionItem,
                                    art.unidad1,
                                    t.cantidad2,
                                    t.unidad2,
                                    t.cantidad,
                                    t.monto,
                                    t.montoOther,
                                    DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                            Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                            Select New With
                                                            {
                                                            c.descripcion
                                                            }).FirstOrDefault().descripcion).ToList


                'Dim listaVenta = consulta.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.VENTA).ToList
                For Each i In consulta
                    obj = New InventarioMovimiento
                    obj.customLote = New recursoCostoLote With
                        {
                        .codigoLote = i.codigoLote,
                        .nroLote = i.nroLote,
                        .fechaVcto = i.fechaVcto
                    }
                    obj.idInventario = i.idInventario
                    If (i.origenProducto = 1) Then
                        obj.ValorDeVenta = (i.monto / 1.18)
                    ElseIf (i.origenProducto = 2) Then
                        obj.ValorDeVenta = i.monto
                    End If

                    'obj.NombreAlmacen = i.descripcionAlmacen
                    obj.fecha = i.fecha
                    obj.idEmpresa = i.idEmpresa
                    obj.idAlmacen = i.idAlmacen
                    obj.tipoProducto = i.tipoProducto
                    obj.idDocumento = i.idDocumento
                    obj.tipoRegistro = i.tipoRegistro
                    obj.serie = i.serie
                    obj.numero = i.numero
                    obj.tipoOperacion = i.tipoOperacion
                    obj.DetalleTipoOperacion = i.DetalleTipoOperacion
                    obj.idItem = i.codigodetalle
                    obj.destinoGravadoItem = i.origenProducto
                    obj.descripcion = i.descripcionItem
                    obj.nombreItem = i.descripcionItem
                    obj.unidad = i.unidad2 ' i.unidad1
                    Select Case i.tipoRegistro
                        Case "E", "EN"
                            obj.cantidad = i.cantidad.GetValueOrDefault
                        Case Else
                            obj.cantidad = i.cantidad.GetValueOrDefault
                    End Select
                    obj.NombrePresentacion = "" 'i.tipoVenta
                    obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
                    obj.monto = i.monto
                    'obj.saldoMonto = i.montoOther
                    obj.montoOther = i.montoOther ' i.CierreImporteMesAnterior.GetValueOrDefault
                    lista.Add(obj)
                Next
            Case "Dia"

                Dim consulta = (From t In HeliosData.InventarioMovimiento
                                Join art In HeliosData.detalleitems
                                    On art.codigodetalle Equals t.idItem
                                Join Lote In HeliosData.recursoCostoLote
                                    On Lote.codigoLote Equals t.nrolote
                                Where
                                    CLng(t.fecha.Value.Year) = fechaini.Year And
                                    CLng(t.fecha.Value.Month) = fechaini.Month And
                                     CLng(t.fecha.Value.Day) = fechaini.Day _
                                    And t.idAlmacen = be.idAlmacen
                                Order By art.descripcionItem, t.tipoProducto, art.origenProducto, t.nrolote, t.fecha Ascending
                                Select
                                    t.idInventario,
                                    t.contenido_neto,
                                    Lote.nroLote,
                                    Lote.codigoLote,
                                    Lote.fechaVcto,
                                    t.fecha,
                                    t.idEmpresa,
                                    t.idAlmacen,
                                    t.tipoProducto,
                                    t.idDocumento,
                                    t.tipoRegistro,
                                    t.serie,
                                    t.numero,
                                    t.tipoOperacion,
                                    art.codigodetalle,
                                    art.origenProducto,
                                    t.descripcion,
                                    art.descripcionItem,
                                    art.unidad1,
                                    t.cantidad2,
                                    t.unidad2,
                                    t.cantidad,
                                    t.monto,
                                    t.montoOther,
                                    DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                            Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                            Select New With
                                                            {
                                                            c.descripcion
                                                            }).FirstOrDefault().descripcion).ToList

                'DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                '                        Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                '                        Select New With
                '                                            {
                '                                            c.descripcion
                '                                            }).FirstOrDefault().descripcion,
                '                     tipoVenta = (From c In HeliosData.documentoventaAbarrotesDet
                '                                  Join x In HeliosData.configuracionPrecio
                '                      On x.idPrecio Equals c.tipoVenta
                '                                  Where c.idDocumento = t.idDocumento And c.idItem = t.idItem
                '                                  Select New With
                '                                            {
                '                                            x.precio
                '                                            }).FirstOrDefault().precio).ToList


                'Dim listaVenta = consulta.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.VENTA).ToList
                For Each i In consulta
                    obj = New InventarioMovimiento
                    obj.customLote = New recursoCostoLote With
                        {
                        .codigoLote = i.codigoLote,
                        .nroLote = i.nroLote,
                        .fechaVcto = i.fechaVcto
                    }
                    obj.idInventario = i.idInventario
                    If (i.origenProducto = 1) Then
                        obj.ValorDeVenta = (i.monto / 1.18)
                    ElseIf (i.origenProducto = 2) Then
                        obj.ValorDeVenta = i.monto
                    End If

                    'obj.NombreAlmacen = i.descripcionAlmacen
                    obj.fecha = i.fecha
                    obj.idEmpresa = i.idEmpresa
                    obj.idAlmacen = i.idAlmacen
                    obj.tipoProducto = i.tipoProducto
                    obj.idDocumento = i.idDocumento
                    obj.tipoRegistro = i.tipoRegistro
                    obj.serie = i.serie
                    obj.numero = i.numero
                    obj.tipoOperacion = i.tipoOperacion
                    obj.DetalleTipoOperacion = i.DetalleTipoOperacion
                    obj.idItem = i.codigodetalle
                    obj.destinoGravadoItem = i.origenProducto
                    obj.descripcion = i.descripcionItem
                    obj.nombreItem = i.descripcionItem
                    obj.unidad = i.unidad2 ' i.unidad1
                    obj.contenido_neto = i.contenido_neto
                    Select Case i.tipoRegistro
                        Case "E", "EN"
                            obj.cantidad = i.cantidad.GetValueOrDefault
                        Case Else
                            obj.cantidad = i.cantidad.GetValueOrDefault
                    End Select
                    ' i.cantidad
                    obj.NombrePresentacion = "" ' i.tipoVenta
                    obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
                    obj.monto = i.monto
                    'obj.saldoMonto = i.montoOther
                    obj.montoOther = i.montoOther ' i.CierreImporteMesAnterior.GetValueOrDefault
                    lista.Add(obj)
                Next
            Case "ItemDia"
                Dim consulta = (From t In HeliosData.InventarioMovimiento
                                Join art In HeliosData.detalleitems
                                    On art.codigodetalle Equals t.idItem
                                Join Lote In HeliosData.recursoCostoLote
                                    On Lote.codigoLote Equals t.nrolote
                                Where
                                    CLng(t.fecha.Value.Year) = fechaini.Year And
                                    CLng(t.fecha.Value.Month) = fechaini.Month And
                                     CLng(t.fecha.Value.Day) = fechaini.Day And
                                    t.idItem = be.idItem _
                                    And t.idAlmacen = be.idAlmacen
                                Order By art.descripcionItem, t.tipoProducto, art.origenProducto, t.nrolote, t.fecha Ascending
                                Select
                                    t.idInventario,
                                    t.contenido_neto,
                                    Lote.nroLote,
                                    Lote.codigoLote,
                                    Lote.fechaVcto,
                                    t.fecha,
                                    t.idEmpresa,
                                    t.idAlmacen,
                                    t.tipoProducto,
                                    t.idDocumento,
                                    t.tipoRegistro,
                                    t.serie,
                                    t.numero,
                                    t.tipoOperacion,
                                    art.codigodetalle,
                                    art.origenProducto,
                                    t.descripcion,
                                    art.descripcionItem,
                                    art.unidad1,
                                    t.cantidad,
                                     t.cantidad2,
                                    t.monto,
                                    t.montoOther,
                                    DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                            Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                            Select New With
                                                            {
                                                            c.descripcion
                                                            }).FirstOrDefault().descripcion).ToList

                'Dim listaVenta = consulta.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.VENTA).ToList
                For Each i In consulta
                    obj = New InventarioMovimiento
                    obj.customLote = New recursoCostoLote With
                        {
                        .codigoLote = i.codigoLote,
                        .nroLote = i.nroLote,
                        .fechaVcto = i.fechaVcto
                    }
                    obj.idInventario = i.idInventario
                    If (i.origenProducto = 1) Then
                        obj.ValorDeVenta = (i.monto / 1.18)
                    ElseIf (i.origenProducto = 2) Then
                        obj.ValorDeVenta = i.monto
                    End If

                    'obj.NombreAlmacen = i.descripcionAlmacen
                    obj.fecha = i.fecha
                    obj.contenido_neto = i.contenido_neto
                    obj.idEmpresa = i.idEmpresa
                    obj.idAlmacen = i.idAlmacen
                    obj.tipoProducto = i.tipoProducto
                    obj.idDocumento = i.idDocumento
                    obj.tipoRegistro = i.tipoRegistro
                    obj.serie = i.serie
                    obj.numero = i.numero
                    obj.tipoOperacion = i.tipoOperacion
                    obj.DetalleTipoOperacion = i.DetalleTipoOperacion
                    obj.idItem = i.codigodetalle
                    obj.destinoGravadoItem = i.origenProducto
                    obj.descripcion = i.descripcionItem
                    obj.nombreItem = i.descripcionItem
                    obj.unidad = i.unidad1
                    Select Case i.tipoRegistro
                        Case "E", "EN"
                            obj.cantidad = i.cantidad.GetValueOrDefault
                        Case Else
                            obj.cantidad = i.cantidad.GetValueOrDefault
                    End Select
                    obj.NombrePresentacion = "" ' i.tipoVenta
                    obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
                    obj.monto = i.monto
                    'obj.saldoMonto = i.montoOther
                    obj.montoOther = i.montoOther ' i.CierreImporteMesAnterior.GetValueOrDefault
                    lista.Add(obj)
                Next
            Case "ItemMes"
                Dim consulta = (From t In HeliosData.InventarioMovimiento
                                Join art In HeliosData.detalleitems
                                    On art.codigodetalle Equals t.idItem
                                Join Lote In HeliosData.recursoCostoLote
                                    On Lote.codigoLote Equals t.nrolote
                                Where
                                    CLng(t.fecha.Value.Year) = fechaini.Year And
                                    CLng(t.fecha.Value.Month) = fechaini.Month And
                                     t.idItem = be.idItem _
                                    And t.idAlmacen = be.idAlmacen
                                Order By art.descripcionItem, t.tipoProducto, art.origenProducto, t.nrolote, t.fecha Ascending
                                Select
                                    t.idInventario,
                                    t.contenido_neto,
                                    Lote.nroLote,
                                    Lote.codigoLote,
                                    Lote.fechaVcto,
                                    t.fecha,
                                    t.idEmpresa,
                                    t.idAlmacen,
                                    t.tipoProducto,
                                    t.idDocumento,
                                    t.tipoRegistro,
                                    t.serie,
                                    t.numero,
                                    t.tipoOperacion,
                                    art.codigodetalle,
                                    art.origenProducto,
                                    t.descripcion,
                                    art.descripcionItem,
                                    art.unidad1,
                                    t.cantidad,
                                     t.cantidad2,
                                    t.monto,
                                    t.montoOther,
                                    DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                            Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                            Select New With
                                                            {
                                                            c.descripcion
                                                            }).FirstOrDefault().descripcion).ToList

                'Dim listaVenta = consulta.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.VENTA).ToList
                For Each i In consulta
                    obj = New InventarioMovimiento
                    obj.customLote = New recursoCostoLote With
                        {
                        .codigoLote = i.codigoLote,
                        .nroLote = i.nroLote,
                        .fechaVcto = i.fechaVcto
                    }
                    obj.idInventario = i.idInventario
                    If (i.origenProducto = 1) Then
                        obj.ValorDeVenta = (i.monto / 1.18)
                    ElseIf (i.origenProducto = 2) Then
                        obj.ValorDeVenta = i.monto
                    End If

                    'obj.NombreAlmacen = i.descripcionAlmacen
                    obj.fecha = i.fecha
                    obj.contenido_neto = i.contenido_neto
                    obj.idEmpresa = i.idEmpresa
                    obj.idAlmacen = i.idAlmacen
                    obj.tipoProducto = i.tipoProducto
                    obj.idDocumento = i.idDocumento
                    obj.tipoRegistro = i.tipoRegistro
                    obj.serie = i.serie
                    obj.numero = i.numero
                    obj.tipoOperacion = i.tipoOperacion
                    obj.DetalleTipoOperacion = i.DetalleTipoOperacion
                    obj.idItem = i.codigodetalle
                    obj.destinoGravadoItem = i.origenProducto
                    obj.descripcion = i.descripcionItem
                    obj.nombreItem = i.descripcionItem
                    obj.unidad = i.unidad1
                    Select Case i.tipoRegistro
                        Case "E", "EN"
                            obj.cantidad = i.cantidad.GetValueOrDefault
                        Case Else
                            obj.cantidad = i.cantidad.GetValueOrDefault
                    End Select
                    obj.NombrePresentacion = "" 'i.tipoVenta
                    obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
                    obj.monto = i.monto
                    'obj.saldoMonto = i.montoOther
                    obj.montoOther = i.montoOther ' i.CierreImporteMesAnterior.GetValueOrDefault
                    lista.Add(obj)
                Next

            Case "ClienteDia"
                Dim consulta = (From t In HeliosData.InventarioMovimiento
                                Join doc In HeliosData.documentoventaAbarrotes
                                    On doc.idDocumento Equals t.idDocumento
                                Join art In HeliosData.detalleitems
                                    On art.codigodetalle Equals t.idItem
                                Join Lote In HeliosData.recursoCostoLote
                                    On Lote.codigoLote Equals t.nrolote
                                Where
                                    CLng(t.fecha.Value.Year) = fechaini.Year And
                                    CLng(t.fecha.Value.Month) = fechaini.Month And
                                     CLng(t.fecha.Value.Day) = fechaini.Day And
                                    doc.idCliente = be.IdProveedor _
                                    And t.idAlmacen = be.idAlmacen
                                Order By art.descripcionItem, t.tipoProducto, art.origenProducto, t.nrolote, t.fecha Ascending
                                Select
                                    t.idInventario,
                                    t.contenido_neto,
                                    Lote.nroLote,
                                    Lote.codigoLote,
                                    Lote.fechaVcto,
                                    t.fecha,
                                    t.idEmpresa,
                                    t.idAlmacen,
                                    t.tipoProducto,
                                    t.idDocumento,
                                    t.tipoRegistro,
                                    t.serie,
                                    t.numero,
                                    t.tipoOperacion,
                                    art.codigodetalle,
                                    art.origenProducto,
                                    t.descripcion,
                                    art.descripcionItem,
                                    art.unidad1,
                                    t.cantidad,
                                     t.cantidad2,
                                    t.monto,
                                    t.montoOther,
                                    DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                            Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                            Select New With
                                                            {
                                                            c.descripcion
                                                            }).FirstOrDefault().descripcion).ToList

                'Dim listaVenta = consulta.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.VENTA).ToList
                For Each i In consulta
                    obj = New InventarioMovimiento
                    obj.customLote = New recursoCostoLote With
                        {
                        .codigoLote = i.codigoLote,
                        .nroLote = i.nroLote,
                        .fechaVcto = i.fechaVcto
                    }
                    obj.idInventario = i.idInventario
                    If (i.origenProducto = 1) Then
                        obj.ValorDeVenta = (i.monto / 1.18)
                    ElseIf (i.origenProducto = 2) Then
                        obj.ValorDeVenta = i.monto
                    End If

                    'obj.NombreAlmacen = i.descripcionAlmacen
                    obj.fecha = i.fecha
                    obj.contenido_neto = i.contenido_neto
                    obj.idEmpresa = i.idEmpresa
                    obj.idAlmacen = i.idAlmacen
                    obj.tipoProducto = i.tipoProducto
                    obj.idDocumento = i.idDocumento
                    obj.tipoRegistro = i.tipoRegistro
                    obj.serie = i.serie
                    obj.numero = i.numero
                    obj.tipoOperacion = i.tipoOperacion
                    obj.DetalleTipoOperacion = i.DetalleTipoOperacion
                    obj.idItem = i.codigodetalle
                    obj.destinoGravadoItem = i.origenProducto
                    obj.descripcion = i.descripcionItem
                    obj.nombreItem = i.descripcionItem
                    obj.unidad = i.unidad1
                    Select Case i.tipoRegistro
                        Case "E", "EN"
                            obj.cantidad = i.cantidad.GetValueOrDefault
                        Case Else
                            obj.cantidad = i.cantidad.GetValueOrDefault
                    End Select
                    obj.NombrePresentacion = "" 'i.tipoVenta
                    obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
                    obj.monto = i.monto
                    'obj.saldoMonto = i.montoOther
                    obj.montoOther = i.montoOther ' i.CierreImporteMesAnterior.GetValueOrDefault
                    lista.Add(obj)
                Next
            Case "ClienteMes"
                Dim consulta = (From t In HeliosData.InventarioMovimiento
                                Join doc In HeliosData.documentoventaAbarrotes
                                    On doc.idDocumento Equals t.idDocumento
                                Join art In HeliosData.detalleitems
                                    On art.codigodetalle Equals t.idItem
                                Join Lote In HeliosData.recursoCostoLote
                                    On Lote.codigoLote Equals t.nrolote
                                Where
                                    CLng(t.fecha.Value.Year) = fechaini.Year And
                                    CLng(t.fecha.Value.Month) = fechaini.Month And
                                    doc.idCliente = be.IdProveedor _
                                    And t.idAlmacen = be.idAlmacen
                                Order By art.descripcionItem, t.tipoProducto, art.origenProducto, t.nrolote, t.fecha Ascending
                                Select
                                    t.idInventario,
                                    t.contenido_neto,
                                    Lote.nroLote,
                                    Lote.codigoLote,
                                    Lote.fechaVcto,
                                    t.fecha,
                                    t.idEmpresa,
                                    t.idAlmacen,
                                    t.tipoProducto,
                                    t.idDocumento,
                                    t.tipoRegistro,
                                    t.serie,
                                    t.numero,
                                    t.tipoOperacion,
                                    art.codigodetalle,
                                    art.origenProducto,
                                    t.descripcion,
                                    art.descripcionItem,
                                    art.unidad1,
                                    t.cantidad,
                                     t.cantidad2,
                                    t.monto,
                                    t.montoOther,
                                    DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                            Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                            Select New With
                                                            {
                                                            c.descripcion
                                                            }).FirstOrDefault().descripcion).ToList

                'Dim listaVenta = consulta.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.VENTA).ToList
                For Each i In consulta
                    obj = New InventarioMovimiento
                    obj.customLote = New recursoCostoLote With
                        {
                        .codigoLote = i.codigoLote,
                        .nroLote = i.nroLote,
                        .fechaVcto = i.fechaVcto
                    }
                    obj.idInventario = i.idInventario
                    If (i.origenProducto = 1) Then
                        obj.ValorDeVenta = (i.monto / 1.18)
                    ElseIf (i.origenProducto = 2) Then
                        obj.ValorDeVenta = i.monto
                    End If

                    'obj.NombreAlmacen = i.descripcionAlmacen
                    obj.fecha = i.fecha
                    obj.contenido_neto = i.contenido_neto
                    obj.idEmpresa = i.idEmpresa
                    obj.idAlmacen = i.idAlmacen
                    obj.tipoProducto = i.tipoProducto
                    obj.idDocumento = i.idDocumento
                    obj.tipoRegistro = i.tipoRegistro
                    obj.serie = i.serie
                    obj.numero = i.numero
                    obj.tipoOperacion = i.tipoOperacion
                    obj.DetalleTipoOperacion = i.DetalleTipoOperacion
                    obj.idItem = i.codigodetalle
                    obj.destinoGravadoItem = i.origenProducto
                    obj.descripcion = i.descripcionItem
                    obj.nombreItem = i.descripcionItem
                    obj.unidad = i.unidad1
                    Select Case i.tipoRegistro
                        Case "E", "EN"
                            obj.cantidad = i.cantidad.GetValueOrDefault
                        Case Else
                            obj.cantidad = i.cantidad.GetValueOrDefault
                    End Select
                    obj.NombrePresentacion = "" 'i.tipoVenta
                    obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
                    obj.monto = i.monto
                    'obj.saldoMonto = i.montoOther
                    obj.montoOther = i.montoOther ' i.CierreImporteMesAnterior.GetValueOrDefault
                    lista.Add(obj)
                Next

        End Select

        Return lista
    End Function

    Public Function GetRentabilidadPorComprobante(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim obj As New InventarioMovimiento
        Dim lista As New List(Of InventarioMovimiento)

        Dim consulta = (From t In HeliosData.InventarioMovimiento
                        Join art In HeliosData.detalleitems
                            On art.codigodetalle Equals t.idItem
                        Join Lote In HeliosData.recursoCostoLote
                            On Lote.codigoLote Equals t.nrolote
                        Where
                            t.idAlmacen = be.idAlmacen And
                            t.idDocumento = be.idDocumento
                        Order By art.descripcionItem,
                            t.tipoProducto, art.origenProducto, t.nrolote, t.fecha Ascending
                        Select
                                    t.idInventario,
                                    Lote.nroLote,
                                    Lote.codigoLote,
                                    Lote.fechaVcto,
                                    t.fecha,
                                    t.idEmpresa,
                                    t.idAlmacen,
                                    t.tipoProducto,
                                    t.idDocumento,
                                    t.tipoRegistro,
                                    t.serie,
                                    t.numero,
                                    t.tipoOperacion,
                                    art.codigodetalle,
                                    art.origenProducto,
                                    t.descripcion,
                                    art.descripcionItem,
                                    art.unidad1,
                                    t.cantidad,
                                    t.monto,
                                    t.montoOther,
                                    DetalleTipoOperacion = (From c In HeliosData.tabladetalle
                                                            Where c.idtabla = 12 And c.codigoDetalle = t.tipoOperacion
                                                            Select New With
                                                            {
                                                            c.descripcion
                                                            }).FirstOrDefault().descripcion,
                                     tipoVenta = (From c In HeliosData.documentoventaAbarrotesDet
                                                  Join x In HeliosData.configuracionPrecio
                                      On x.idPrecio Equals c.tipoVenta
                                                  Where c.idDocumento = t.idDocumento And c.idItem = t.idItem
                                                  Select New With
                                                            {
                                                            x.precio
                                                            }).FirstOrDefault().precio).ToList


        'Dim listaVenta = consulta.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.VENTA).ToList
        For Each i In consulta
            obj = New InventarioMovimiento
            obj.customLote = New recursoCostoLote With
                        {
                        .codigoLote = i.codigoLote,
                        .nroLote = i.nroLote,
                        .fechaVcto = i.fechaVcto
                    }
            obj.idInventario = i.idInventario
            If (i.origenProducto = 1) Then
                obj.ValorDeVenta = (i.monto / 1.18)
            ElseIf (i.origenProducto = 2) Then
                obj.ValorDeVenta = i.monto
            End If

            'obj.NombreAlmacen = i.descripcionAlmacen
            obj.fecha = i.fecha
            obj.idEmpresa = i.idEmpresa
            obj.idAlmacen = i.idAlmacen
            obj.tipoProducto = i.tipoProducto
            obj.idDocumento = i.idDocumento
            obj.tipoRegistro = i.tipoRegistro
            obj.serie = i.serie
            obj.numero = i.numero
            obj.tipoOperacion = i.tipoOperacion
            obj.DetalleTipoOperacion = i.DetalleTipoOperacion
            obj.idItem = i.codigodetalle
            obj.destinoGravadoItem = i.origenProducto
            obj.descripcion = i.descripcionItem
            obj.nombreItem = i.descripcionItem
            obj.unidad = i.unidad1
            obj.cantidad = i.cantidad
            obj.NombrePresentacion = i.tipoVenta
            obj.cantidad2 = 0 ' i.CierreCantMesAnterior.GetValueOrDefault
            obj.monto = i.monto
            'obj.saldoMonto = i.montoOther
            obj.montoOther = i.montoOther ' i.CierreImporteMesAnterior.GetValueOrDefault
            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Sub editarTrasnferenciaItem(inventario As InventarioMovimiento)
        Using ts As New TransactionScope

            editarTrasnferenciaItemOperation(inventario)
            ActualizarInventarioPorItem(inventario)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Private Sub ActualizarInventarioPorItem(be As InventarioMovimiento)
        Dim inventarioBL As New InventarioMovimientoBL
        Dim totalesBL As New totalesAlmacenBL

        Using ts As New TransactionScope
            'Select Case be.tipoDocumento
            '    Case "01", "03", "9907"
            '        'Dim i = HeliosData.InventarioMovimiento.Where(Function(o) o.idDocumento = be.idDocumento And o.idItem = idproducto And o.nrolote = codigoLote).SingleOrDefault
            '        Dim listaVenta = HeliosData.InventarioMovimiento.Where(Function(o) o.idDocumento = be.idDocumento And o.idItem = idproducto And o.nrolote = codigoLote).Distinct.ToList '.SingleOrDefault


            Dim con = HeliosData.InventarioMovimiento.Join(HeliosData.documento, Function(inv) inv.idDocumento, Function(doc) doc.idDocumento, Function(inv, doc) _
                  New With {
                  .inventario = inv,
                  .documento = doc
                  }).Join(HeliosData.almacen, Function(inv) inv.inventario.idAlmacen, Function(al) al.idAlmacen, Function(inv, al) _
                          New With {
                          .inventario = inv.inventario,
                          .documento = inv.documento,
                          .almacen = al
                          }) _
                  .Where(Function(o) o.inventario.fecha >= be.fecha And o.inventario.nrolote = be.nrolote).Select(Function(o) _
                        New With {
                        .idalmacen = o.inventario.idAlmacen,
                        .tipoProducto = o.inventario.tipoProducto,
                        .idItem = o.inventario.idItem,
                        .nrolote = o.inventario.nrolote
                        }).Distinct.ToList

            For Each i In con

                Dim lista = inventarioBL.GetCuracionEntradasAlmacenByArticuloLote(
                                    New InventarioMovimiento With {
                                    .idAlmacen = i.idalmacen,
                                    .fecha = Date.Now,
                                    .tipoProducto = i.tipoProducto,
                                    .idItem = i.idItem,
                                    .nrolote = i.nrolote
                                    }, Nothing)
                totalesBL.GetCurarKardexCaberasLOTE(lista)

                ' totalesBL.GetTotalizarInventario(lista)
            Next
            '    Case "9903" ' PROFORMA

            '    Case "1000" ' PRE VENTA

            'End Select
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub editarTrasnferenciaItemOperation(inventario As InventarioMovimiento)
        Using ts As New TransactionScope

            Dim consulta = HeliosData.InventarioMovimiento.Where(Function(o) o.idorigenDetalle = inventario.idorigenDetalle And
                                                                     o.idDocumento = inventario.idDocumento And
                                                                     o.tipoOperacion = "11").ToList

            For Each i In consulta
                Select Case i.tipoRegistro
                    Case "E"
                        Dim costoUnitario = i.monto / i.cantidad
                        Dim monto As Decimal = costoUnitario * inventario.cantidad
                        i.cantidad = inventario.cantidad
                        i.precUnite = costoUnitario
                        i.monto = monto
                    Case "S"
                        i.cantidad = inventario.cantidad * -1
                        i.precUnite = 0
                        i.monto = 0
                End Select
            Next

            Dim ventaItem = HeliosData.documentoventaAbarrotesDet.Where(Function(o) o.secuencia = inventario.idorigenDetalle).SingleOrDefault
            If ventaItem IsNot Nothing Then
                ventaItem.monto1 = inventario.cantidad
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EliminarItemOperation(inventario As InventarioMovimiento)
        Using ts As New TransactionScope
            Dim lista = EliminarItemOperation_Single(inventario)
            ActualizarInventarioPorItemEliminado(lista)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function EliminarItemOperation_Single(inventario As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim ventaDetalleBL As New documentoventaAbarrotesDetBL

        Using ts As New TransactionScope

            Dim inv = HeliosData.InventarioMovimiento.Where(Function(o) o.idorigenDetalle = inventario.idorigenDetalle).ToList

            '  Dim ventaItem = HeliosData.documentoventaAbarrotesDet.Where(Function(o) o.secuencia = inv.FirstOrDefault.idorigenDetalle).SingleOrDefault
            ventaDetalleBL.DeleteItemVenta(New documentoventaAbarrotesDet With {.idDocumento = inv.FirstOrDefault.idDocumento, .secuencia = inventario.idorigenDetalle})

            For Each i In inv
                HeliosData.InventarioMovimiento.Remove(i)
            Next

            HeliosData.SaveChanges()
            ts.Complete()
            Return inv
        End Using
    End Function

    Private Sub ActualizarInventarioPorItemEliminado(listaInventario As List(Of InventarioMovimiento))
        Dim inventarioBL As New InventarioMovimientoBL
        Dim totalesBL As New totalesAlmacenBL

        Using ts As New TransactionScope
            'Select Case be.tipoDocumento
            '    Case "01", "03", "9907"
            '        'Dim i = HeliosData.InventarioMovimiento.Where(Function(o) o.idDocumento = be.idDocumento And o.idItem = idproducto And o.nrolote = codigoLote).SingleOrDefault
            '        Dim listaVenta = HeliosData.InventarioMovimiento.Where(Function(o) o.idDocumento = be.idDocumento And o.idItem = idproducto And o.nrolote = codigoLote).Distinct.ToList '.SingleOrDefault


            Dim con = listaInventario.Select(Function(o) New With
                        {
                        .idAlmacen = o.idAlmacen,
                        .tipoProducto = o.tipoProducto,
                        .idItem = o.idItem,
                        .nrolote = o.nrolote
                        }).Distinct.ToList


            For Each i In con

                Dim lista = inventarioBL.GetCuracionEntradasAlmacenByArticuloLote(
                                    New InventarioMovimiento With {
                                    .idAlmacen = i.idAlmacen,
                                    .fecha = Date.Now,
                                    .tipoProducto = i.tipoProducto,
                                    .idItem = i.idItem,
                                    .nrolote = i.nrolote
                                    }, Nothing)
                totalesBL.GetCurarKardexCaberasLOTE(lista)

                ' totalesBL.GetTotalizarInventario(lista)
            Next
            '    Case "9903" ' PROFORMA

            '    Case "1000" ' PRE VENTA

            'End Select
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

#End Region
End Class
