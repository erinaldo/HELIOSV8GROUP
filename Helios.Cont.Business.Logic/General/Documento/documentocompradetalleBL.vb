Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class documentocompradetalleBL
    Inherits BaseBL

    Public Function GetProductosEntransitoEquivalencia(be As documentocompra) As List(Of inventarioTransito)
        Dim tipoCompra As New List(Of String)
        tipoCompra.Add(TIPO_COMPRA.COMPRA)
        tipoCompra.Add(TIPO_COMPRA.NOTA_DE_COMPRA)
        tipoCompra.Add(TIPO_COMPRA.OTRAS_ENTRADAS)

        Dim consulta = (From inv In HeliosData.inventarioTransito
                        Join det In HeliosData.documentocompradetalle
                            On det.idDocumento Equals inv.idDocumentoCompra And det.secuencia Equals inv.secuencia
                        Join ent In HeliosData.entidad On ent.idEntidad Equals det.documentocompra.idProveedor
                        Join prod In HeliosData.detalleitems On prod.codigodetalle Equals det.idItem
                        Join lote In HeliosData.recursoCostoLote On lote.idDocumento Equals det.idDocumento And lote.codigoProducto Equals det.idItem
                        Where
                            tipoCompra.Contains(det.documentocompra.tipoCompra) And
                            det.documentocompra.estadoPago <> "ANU" And
                             inv.idEstablecimiento = be.idCentroCosto And
                             inv.status = be.StatusEntregaProductosTransito
                        Select
                            lote_codigo = lote.codigoLote,
                            prod,
                            inv,
                            det.documentocompra.idDocumento,
                            det.documentocompra.idEmpresa,
                            det.documentocompra.idCentroCosto,
                            det.secuencia,
                            det.destino,
                            det.tipoExistencia,
                            det.idItem,
                            det.descripcionItem,
                            det.unidad1,
                            det.monto1,
                            det.monto2,
                            det.montokardex,
                            det.montokardexUS,
                            det.almacenRef,
                            det.documentocompra.tipoDoc,
                            det.documentocompra.serie,
                            det.documentocompra.numeroDoc,
                            det.codigoLote,
                            ent.idEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc).ToList

        'Dim consulta = (From det In HeliosData.documentocompradetalle
        '                Join alm In HeliosData.almacen On alm.idAlmacen Equals det.almacenRef
        '                Join ent In HeliosData.entidad On ent.idEntidad Equals det.documentocompra.idProveedor
        '                Join prod In HeliosData.detalleitems On prod.codigodetalle Equals det.idItem
        '                Where det.ItemEntregadototal = "N" And
        '                    det.documentocompra.idCentroCosto = be.idCentroCosto And
        '                    alm.tipo = "AV"
        '                Select
        '                    prod,
        '                    det.documentocompra.idDocumento,
        '                    det.secuencia,
        '                    det.destino,
        '                    det.tipoExistencia,
        '                    det.idItem,
        '                    det.descripcionItem,
        '                    det.unidad1,
        '                    det.monto1,
        '                    det.monto2,
        '                    det.montokardex,
        '                    det.montokardexUS,
        '                    det.almacenRef,
        '                    det.documentocompra.tipoDoc,
        '                    det.documentocompra.serie,
        '                    det.documentocompra.numeroDoc,
        '                    det.codigoLote,
        '                    ent.idEntidad,
        '                    ent.nombreCompleto,
        '                    ent.nrodoc).ToList


        GetProductosEntransitoEquivalencia = New List(Of inventarioTransito)
        For Each i In consulta
            GetProductosEntransitoEquivalencia.Add(New inventarioTransito With
                                                   {
                                                   .idInventario = i.inv.idInventario,
                                                   .idDocumentoCompra = i.inv.idDocumentoCompra,
                                                   .almacen = i.inv.almacen,
                                                   .secuencia = i.inv.secuencia,
                                                   .cantidad = i.inv.cantidad,
                                                   .cantidadOriginal = i.inv.cantidadOriginal,
                                                   .monto = i.inv.monto,
                                                   .montoME = i.inv.montoME,
                                                   .tipoOperacion = i.inv.tipoOperacion,
                                                   .CustomProducto = i.prod,
                                                   .CustomDetalleCompra = New documentocompradetalle With
                                                   {
                                                   .idDocumento = i.idDocumento,
                                                   .secuencia = i.secuencia,
                                                   .destino = i.destino,
                                                   .tipoExistencia = i.tipoExistencia,
                                                   .idItem = i.idItem,
                                                   .descripcionItem = i.descripcionItem,
                                                   .unidad1 = i.unidad1,
                                                   .monto1 = i.monto1,
                                                   .monto2 = i.monto2,
                                                   .montokardex = i.montokardex,
                                                   .montokardexUS = i.montokardexUS,
                                                   .almacenRef = i.almacenRef,
                                                   .codigoLote = i.lote_codigo,' i.codigoLote,
                                                   .documentocompra = New documentocompra With
                                                        {
                                                        .idDocumento = i.idDocumento,
                                                        .idEmpresa = i.idEmpresa,
                                                        .idCentroCosto = i.idCentroCosto,
                                                        .tipoDoc = i.tipoDoc,
                                                        .idProveedor = i.idEntidad,
                                                        .serie = i.serie,
                                                        .numeroDoc = i.numeroDoc,
                                                        .entidad = New entidad With {
                                                            .idEntidad = i.idEntidad,
                                                            .nombreCompleto = i.nombreCompleto,
                                                            .nrodoc = i.nrodoc
                                                            }
                                                        }
                                                     }
                                                   })

        Next


    End Function


    Public Sub InsertSingleTransAlmacenProduccion(documentocompradetalle As documentocompradetalle, intIdDocumento As Integer)
        Dim OBJD As New documentocompradetalle
        Using ts As New TransactionScope

            OBJD = New documentocompradetalle
            '    objInventario = New HeliosDAL.InventarioMovimiento
            OBJD.idDocumento = intIdDocumento ' Me.IdDocumento
            OBJD.idItem = documentocompradetalle.idItem
            OBJD.descripcionItem = documentocompradetalle.descripcionItem
            OBJD.tipoExistencia = documentocompradetalle.tipoExistencia
            OBJD.destino = documentocompradetalle.destino
            OBJD.unidad1 = documentocompradetalle.unidad1
            OBJD.monto1 = documentocompradetalle.monto1
            OBJD.unidad2 = documentocompradetalle.unidad2
            OBJD.monto2 = documentocompradetalle.monto2
            OBJD.precioUnitario = documentocompradetalle.precioUnitario
            OBJD.precioUnitarioUS = documentocompradetalle.precioUnitarioUS
            OBJD.importe = documentocompradetalle.importe
            OBJD.importeUS = documentocompradetalle.importeUS
            OBJD.montokardex = documentocompradetalle.montokardex
            OBJD.montoIsc = documentocompradetalle.montoIsc
            OBJD.montoIgv = documentocompradetalle.montoIgv
            OBJD.otrosTributos = documentocompradetalle.otrosTributos

            OBJD.tipoCosto = documentocompradetalle.tipoCosto
            OBJD.idCosto = documentocompradetalle.idCosto
            '*********************************************************************
            OBJD.montokardexUS = documentocompradetalle.montokardexUS
            OBJD.montoIscUS = documentocompradetalle.montoIscUS
            OBJD.montoIgvUS = documentocompradetalle.montoIgvUS
            OBJD.otrosTributosUS = documentocompradetalle.otrosTributosUS
            If IsNothing(documentocompradetalle.preEvento) Then
                OBJD.preEvento = Nothing
            Else
                OBJD.preEvento = documentocompradetalle.preEvento
            End If
            OBJD.bonificacion = documentocompradetalle.bonificacion
            'OBJD.monto = documentocompradetalle.importe
            'OBJD.saldoMontoNotaUSD = documentocompradetalle.importeUS
            OBJD.almacenRef = documentocompradetalle.almacenRef
            OBJD.almacenDestino = documentocompradetalle.almacenDestino
            OBJD.idPadreDTCompra = documentocompradetalle.idPadreDTCompra
            '*********************************************************************
            OBJD.usuarioModificacion = documentocompradetalle.usuarioModificacion
            OBJD.fechaModificacion = documentocompradetalle.fechaModificacion
            HeliosData.documentocompradetalle.Add(OBJD)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EnvioDeServiciosAProduccion(be As List(Of documentocompradetalle))

        For Each i In be
            Me.UpdateServicioDetalle(i)
        Next


    End Sub

    Public Sub UpdateServicioDetalle(i As documentocompradetalle)
        Dim item As New documentocompradetalle
        Dim documentolibroBL As New documentoLibroDiarioBL
        Using ts As New TransactionScope

            item = (From n In HeliosData.documentocompradetalle _
                   Where n.secuencia = i.secuencia).FirstOrDefault

            item.tipoCosto = i.tipoCosto


            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function SumaNotasXidPadreItemVentaOpcionDefault(intIdSecuencia As Integer) As documentoventaAbarrotesDet
        Dim objDetalle As New documentoventaAbarrotesDet
        Dim lista As New List(Of String)
        lista.Add("07")
        lista.Add("87")


        Dim lista2 As New List(Of String)
        lista2.Add("08")
        lista2.Add("88")

        Dim listaComp As New List(Of String)
        listaComp.Add("9901")

        Dim totals3 = Aggregate p In HeliosData.documentoventaAbarrotesDet
                      Join compra In HeliosData.documentoventaAbarrotes
                      On p.idDocumento Equals compra.idDocumento
                                 Where p.idPadreDTVenta = intIdSecuencia And Not compra.tipoVenta = "EXD" _
                                 And lista.Contains(compra.tipoDocumento)
                 Into mn = Sum(p.importeMN),
                      mne = Sum(p.importeME),
                      can = Sum(p.monto1),
                      kard = Sum(p.montokardex),
                     kardme = Sum(p.montokardexUS),
                          igv = Sum(p.montoIgv)

        Dim totals4 = Aggregate p In HeliosData.documentoventaAbarrotesDet
                     Join compra In HeliosData.documentoventaAbarrotes
                     On p.idDocumento Equals compra.idDocumento
                                Where p.idPadreDTVenta = intIdSecuencia _
                                And lista2.Contains(compra.tipoDocumento)
                Into DBmn = Sum(p.importeMN),
                     DBmne = Sum(p.importeME),
                          DBkard = Sum(p.montokardex),
                          DBkardme = Sum(p.montokardexUS)

        Dim Compensa = Aggregate p In HeliosData.documentoventaAbarrotesDet
                      Join compra In HeliosData.documentoventaAbarrotes
                      On p.idDocumento Equals compra.idDocumento
                                 Where p.idPadreDTVenta = intIdSecuencia _
                                 And lista.Contains(compra.tipoDocumento) And compra.tipoVenta = "COMPV"
                 Into comp = Sum(p.importeMN),
                      compme = Sum(p.importeME)

        Dim PagoDevuelto = Aggregate p In HeliosData.documentoventaAbarrotesDet
                      Join compra In HeliosData.documentoventaAbarrotes
                      On p.idDocumento Equals compra.idDocumento
                                 Where p.idPadreDTVenta = intIdSecuencia _
                                 And lista.Contains(compra.tipoDocumento) And compra.tipoVenta = "EXD"
                 Into comp = Sum(p.importeMN),
                      compme = Sum(p.importeME)



        objDetalle.monto1 = totals3.can.GetValueOrDefault
        objDetalle.importeMN = totals3.mn.GetValueOrDefault
        objDetalle.importeME = totals3.mne.GetValueOrDefault
        objDetalle.ImporteDBMN = totals4.DBmn.GetValueOrDefault
        objDetalle.ImporteDBME = totals4.DBmne.GetValueOrDefault

        objDetalle.montokardex = totals3.kard.GetValueOrDefault
        objDetalle.montokardexDB = totals4.DBkard.GetValueOrDefault
        objDetalle.montokardexUS = totals3.kardme.GetValueOrDefault
        objDetalle.montokardexDBUS = totals4.DBkardme.GetValueOrDefault

        objDetalle.montoIgv = totals3.igv.GetValueOrDefault


        objDetalle.montoCompesacion = Compensa.comp.GetValueOrDefault
        objDetalle.montoCompesacionme = Compensa.compme.GetValueOrDefault

        objDetalle.montoDevuelto = PagoDevuelto.comp.GetValueOrDefault
        objDetalle.montoDevueltome = PagoDevuelto.comp.GetValueOrDefault


        Return objDetalle

    End Function

    Public Function InsertSingle2(documentocompradetalle As documentocompradetalle, intIdDocumento As Integer) As Integer
        Dim OBJD As New documentocompradetalle
        Using ts As New TransactionScope

            OBJD = New documentocompradetalle
            OBJD.idDocumento = intIdDocumento ' Me.IdDocumento
            '    objInventario = New HeliosDAL.InventarioMovimiento
            'Select Case documentocompradetalle.estadoPago
            '    Case "Pagado"
            '        OBJD.estadoPago = TIPO_COMPRA.PAGO.PAGADO
            '    Case "No Pagado"
            '        OBJD.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            'End Select


            OBJD.idItem = documentocompradetalle.idItem
            OBJD.descripcionItem = documentocompradetalle.descripcionItem
            OBJD.tipoExistencia = documentocompradetalle.tipoExistencia
            OBJD.destino = documentocompradetalle.destino
            'OBJD.unidad1 = documentocompradetalle.unidad1
            'OBJD.monto1 = documentocompradetalle.monto1
            'OBJD.unidad2 = documentocompradetalle.unidad2
            'OBJD.monto2 = documentocompradetalle.monto2
            'OBJD.precioUnitario = documentocompradetalle.precioUnitario
            'OBJD.precioUnitarioUS = documentocompradetalle.precioUnitarioUS
            OBJD.importe = documentocompradetalle.importe
            OBJD.importeUS = documentocompradetalle.importeUS
            OBJD.montokardex = CDec(0.0)
            OBJD.montoIsc = CDec(0.0)
            OBJD.montoIgv = CDec(0.0)
            OBJD.otrosTributos = CDec(0.0)
            '*********************************************************************
            OBJD.montokardexUS = CDec(0.0)
            OBJD.montoIscUS = CDec(0.0)
            OBJD.montoIgvUS = CDec(0.0)
            OBJD.otrosTributosUS = CDec(0.0)
            '  If IsNothing(documentocompradetalle.preEvento) Then
            OBJD.preEvento = Nothing
            'Else
            'OBJD.preEvento = documentocompradetalle.preEvento
            'End If
            'OBJD.bonificacion = documentocompradetalle.bonificacion
            OBJD.notaCreditoMN = CDec(0.0)
            OBJD.notaCreditoME = CDec(0.0)

            OBJD.percepcionMN = CDec(0.0)
            OBJD.percepcionME = CDec(0.0)
            'OBJD.almacenRef = documentocompradetalle.almacenRef
            OBJD.idPadreDTCompra = documentocompradetalle.idPadreDTCompra

            OBJD.entregable = documentocompradetalle.entregable
            OBJD.fechaEntrega = documentocompradetalle.fechaEntrega
            '*********************************************************************
            'OBJD.situacion = documentocompradetalle.situacion
            'OBJD.operacionNota = documentocompradetalle.TipoOperacion
            'OBJD.categoria = documentocompradetalle.categoria
            'OBJD.ItemEntregadototal = documentocompradetalle.ItemEntregadototal
            'OBJD.nrolote = documentocompradetalle.nrolote

            'OBJD.idCosto = documentocompradetalle.idCosto
            'OBJD.tipoCosto = documentocompradetalle.tipoCosto

            OBJD.usuarioModificacion = documentocompradetalle.usuarioModificacion
            OBJD.fechaModificacion = documentocompradetalle.fechaModificacion
            HeliosData.documentocompradetalle.Add(OBJD)
            HeliosData.SaveChanges()
            ts.Complete()
            documentocompradetalle.secuencia = OBJD.secuencia
            Return OBJD.secuencia
        End Using
    End Function

    Public Function SumaNotasFinancierasDefault(intIdSecuencia As Integer) As documentocompradetalle
        Dim objDetalle As New documentocompradetalle
        Dim lista As New List(Of String)
        lista.Add("07")
        lista.Add("87")

        Dim lista2 As New List(Of String)
        lista2.Add("08")
        lista2.Add("88")

        Dim totals3 = Aggregate p In HeliosData.documentocompradetalle
                      Join compra In HeliosData.documentocompra
                      On p.idDocumento Equals compra.idDocumento
                                 Where p.idPadreDTCompra = intIdSecuencia _
                                 And lista.Contains(compra.tipoDoc) And compra.tipoCompra <> "NDD"
                 Into mn = Sum(p.importe),
                      mne = Sum(p.importeUS),
                      can = Sum(p.monto1),
                      kard = Sum(p.montokardex),
                          kardme = Sum(p.montokardexUS)

        Dim totals4 = Aggregate p In HeliosData.documentocompradetalle
                     Join compra In HeliosData.documentocompra
                     On p.idDocumento Equals compra.idDocumento
                     Where p.idPadreDTCompra = intIdSecuencia _
                     And lista2.Contains(compra.tipoDoc) And p.operacionNota = "9923"
                     Into DBmn = Sum(p.importe),
                         DBmne = Sum(p.importeUS),
                          DBkard = Sum(p.montokardex),
                          DBkardme = Sum(p.montokardexUS)

        Dim totals5 = Aggregate p In HeliosData.documentocompradetalle
                      Join compra In HeliosData.documentocompra
                      On p.idDocumento Equals compra.idDocumento
                                 Where p.idPadreDTCompra = intIdSecuencia _
                                 And compra.tipoCompra = "NDD"
                 Into mn = Sum(p.importe),
                      mne = Sum(p.importeUS),
                      kard = Sum(p.montokardex),
                          kardme = Sum(p.montokardexUS)



        objDetalle.monto1 = totals3.can.GetValueOrDefault
        objDetalle.importe = totals3.mn.GetValueOrDefault
        objDetalle.importeUS = totals3.mne.GetValueOrDefault
        objDetalle.ImporteDBMN = totals4.DBmn.GetValueOrDefault - totals5.mn.GetValueOrDefault
        objDetalle.ImporteDBME = totals4.DBmne.GetValueOrDefault - totals5.mne.GetValueOrDefault

        objDetalle.montokardex = totals3.kard.GetValueOrDefault
        objDetalle.montokardexDB = totals4.DBkard.GetValueOrDefault - totals5.kard.GetValueOrDefault
        objDetalle.montokardexUS = totals3.kardme.GetValueOrDefault
        objDetalle.montokardexDBUS = totals4.DBkardme.GetValueOrDefault - totals5.kardme.GetValueOrDefault
        'objDetalle.ImporteAJmn = Ajustes.AJmn.GetValueOrDefault
        'objDetalle.ImporteAJme = Ajustes.AJme.GetValueOrDefault
        Return objDetalle

    End Function


    Public Function ListadoNotasDetalleHijos(intIdDocumento As Integer) As List(Of documentocompradetalle)
        Dim lista As New List(Of documentocompradetalle)
        Dim a As New documentocompradetalle

        Dim cc = (From c In HeliosData.documentocompradetalle
                  Join i In HeliosData.documentocompra
                  On i.idDocumento Equals c.idDocumento
                  Where i.idPadre = intIdDocumento).ToList


        For Each i In cc
            a = New documentocompradetalle
            a.idDocumento = i.c.idDocumento
            a.DetalleItem = i.c.DetalleItem
            a.importe = i.c.importe
            a.importeUS = i.c.importeUS

            lista.Add(a)
        Next

        Return lista
    End Function

    Public Function GetCountItemsNoAsignados(compraBE As documentocompra) As Integer
        Dim doccompra As New documentocompradetalle
        Dim compraLista As New List(Of documentocompradetalle)
        Dim list As New List(Of String)

        list.Add(TIPO_COMPRA.NOTA_CREDITO)
        list.Add(TIPO_COMPRA.NOTA_DEBITO)
        list.Add(TIPO_COMPRA.COMPRA)
        list.Add(TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO)
        list.Add(TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS)
        list.Add(TIPO_VENTA.OTRAS_SALIDAS)

        Dim consulta = (From n In HeliosData.documentocompra
                        Join det In HeliosData.documentocompradetalle
                        On det.idDocumento Equals n.idDocumento
                        Where det.tipoExistencia = "GS" _
                        And n.idEmpresa = compraBE.idEmpresa And n.idCentroCosto = compraBE.idCentroCosto _
                        And n.fechaContable = compraBE.fechaContable And list.Contains(n.tipoCompra) _
                        And det.idItem >= "62" And det.idItem <= "68" _
                        And det.tipoCosto Is Nothing).Count


        Return consulta

    End Function


    Public Sub UpdateCostoItem(i As documentocompradetalle, documento As documento)
        Dim item As New documentocompradetalle
        Dim documentolibroBL As New documentoLibroDiarioBL
        Using ts As New TransactionScope

            item = (From n In HeliosData.documentocompradetalle _
                   Where n.secuencia = i.secuencia).FirstOrDefault

            item.tipoCosto = i.tipoCosto
            item.idCosto = i.idCosto

            documentolibroBL.GrabarLibroCosto(documento)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub UpdateCostoItemSingle(i As documentocompradetalle)
        Dim item As New documentocompradetalle
        Dim documentolibroBL As New documentoLibroDiarioBL
        Using ts As New TransactionScope

            item = (From n In HeliosData.documentocompradetalle _
                   Where n.secuencia = i.secuencia).FirstOrDefault

            item.tipoCosto = i.tipoCosto
            item.idCosto = i.idCosto

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub QuitarAsignacionRecurso(i As documentocompradetalle)
        Dim item As New documentocompradetalle
        Dim documentolibroBL As New documentoLibroDiarioBL
        Dim documentoBL As New documentoBL
        Dim asientoBL As New AsientoBL

        Using ts As New TransactionScope

            item = (From n In HeliosData.documentocompradetalle _
                   Where n.secuencia = i.secuencia).FirstOrDefault

            item.tipoCosto = i.tipoCosto
            item.idCosto = i.idCosto

            Dim RecuperIdAsiento = (From n In HeliosData.documentoLibroDiario _
                                    Where n.idReferencia = i.secuencia).FirstOrDefault

            documentoBL.DeleteSingleVariable(RecuperIdAsiento.idDocumento)
            asientoBL.DeleteGroup(RecuperIdAsiento.idDocumento)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function ListaRecursoAsignadoByIdCosto(i As documentocompradetalle, doccompra As documentocompra) As List(Of documentocompradetalle)
        Dim obj As New documentocompradetalle
        Dim lista As New List(Of documentocompradetalle)
        Dim consulta = (From n In HeliosData.documentocompradetalle _
                        Join compra In HeliosData.documentocompra _
                        On compra.idDocumento Equals n.idDocumento _
                        Join recurso In HeliosData.recursoCosto _
                        On recurso.idCosto Equals n.idCosto _
                       Where n.tipoCosto = i.tipoCosto _
                       And compra.fechaContable = doccompra.fechaContable _
                       And compra.idEmpresa = doccompra.idEmpresa _
                       And compra.idCentroCosto = doccompra.idCentroCosto).ToList

        For Each x In consulta
            obj = New documentocompradetalle
            obj.idDocumento = x.n.idDocumento
            obj.secuencia = x.n.secuencia
            obj.idItem = x.n.idItem
            obj.descripcionItem = x.n.descripcionItem
            obj.tipoExistencia = x.n.tipoExistencia
            obj.destino = x.n.destino
            obj.unidad1 = x.n.unidad1
            obj.monto1 = x.n.monto1
            obj.precioUnitario = x.n.precioUnitario
            obj.precioUnitarioUS = x.n.precioUnitarioUS
            obj.montokardex = x.n.montokardex
            obj.montokardexUS = x.n.montokardexUS
            obj.importe = x.n.importe
            obj.importeUS = x.n.importeUS
            obj.tipoExistencia = x.n.tipoExistencia
            obj.tipoCosto = x.n.tipoCosto
            obj.idCosto = x.n.idCosto
            obj.produccion = x.recurso.detalle
            obj.CodigoCosto = x.recurso.codigo
            obj.Inicio = x.recurso.inicio
            obj.Finaliza = x.recurso.finaliza
            obj.Status = x.recurso.status
            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Function ListaRecursoAsignadoByIdCostoSingle(i As documentocompradetalle, doccompra As documentocompra) As List(Of documentocompradetalle)
        Dim obj As New documentocompradetalle
        Dim lista As New List(Of documentocompradetalle)
        Dim consulta = (From n In HeliosData.documentocompradetalle _
                        Join compra In HeliosData.documentocompra _
                        On compra.idDocumento Equals n.idDocumento _
                        Join recurso In HeliosData.recursoCosto _
                        On recurso.idCosto Equals n.idCosto _
                       Where _
                       n.idCosto = i.idCosto _
                       And compra.fechaContable = doccompra.fechaContable _
                       And compra.idEmpresa = doccompra.idEmpresa _
                       And compra.idCentroCosto = doccompra.idCentroCosto).ToList

        For Each x In consulta
            obj = New documentocompradetalle
            obj.idDocumento = x.n.idDocumento
            obj.secuencia = x.n.secuencia
            obj.idItem = x.n.idItem
            obj.descripcionItem = x.n.descripcionItem
            obj.tipoExistencia = x.n.tipoExistencia
            obj.destino = x.n.destino
            obj.unidad1 = x.n.unidad1
            obj.monto1 = x.n.monto1
            obj.precioUnitario = x.n.precioUnitario
            obj.precioUnitarioUS = x.n.precioUnitarioUS
            obj.montokardex = x.n.montokardex
            obj.montokardexUS = x.n.montokardexUS
            obj.importe = x.n.importe
            obj.importeUS = x.n.importeUS
            obj.tipoExistencia = x.n.tipoExistencia
            obj.tipoCosto = x.n.tipoCosto
            obj.idCosto = x.n.idCosto
            obj.produccion = x.recurso.detalle
            obj.CodigoCosto = x.recurso.codigo
            obj.Inicio = x.recurso.inicio
            obj.Finaliza = x.recurso.finaliza
            obj.Status = x.recurso.status
            lista.Add(obj)
        Next

        Return lista
    End Function


    Public Function UbicarDetalleCompraEval(intIdDocumento As Integer) As List(Of documentocompradetalle)
        Dim cd As New documentocompradetalle
        Dim lista As New List(Of documentocompradetalle)
        Try
            Dim consulta = (From n In HeliosData.uspListarDetalleCompraPoridDocumento(intIdDocumento)
                           Select n).ToList

            For Each i In consulta
                cd = New documentocompradetalle
                cd.secuencia = i.secuencia
                cd.idItem = i.idItem
                cd.descripcionItem = i.descripcionItem
                cd.tipoExistencia = i.tipoExistencia
                cd.destino = i.destino
                cd.unidad1 = i.unidad1
                cd.monto1 = i.monto1
                cd.unidad2 = i.unidad2
                cd.monto2 = i.monto2
                cd.precioUnitario = i.precioUnitario
                cd.precioUnitarioUS = i.precioUnitarioUS
                cd.importe = i.importe
                cd.importeUS = i.importeUS
                cd.montokardex = i.montokardex
                cd.montoIsc = i.montoIsc
                cd.montoIgv = i.montoIgv
                cd.otrosTributos = i.otrosTributos
                cd.montokardexUS = i.montokardexUS
                cd.montoIscUS = i.montoIscUS
                cd.montoIgvUS = i.montoIgvUS
                cd.otrosTributosUS = i.otrosTributosUS
                cd.preEvento = i.preEvento
                cd.bonificacion = i.bonificacion
                cd.almacenRef = i.almacenRef
                cd.almacenDestino = i.almacenDestino
                cd.situacion = i.situacion
                cd.idPadreDTCompra = i.idPadreDTCompra
                cd.fechaEntrega = i.fechaEntrega
                cd.estadoPago = i.estadoPago
                cd.categoria = i.categoria
                cd.percepcionMN = i.percepcionMN
                cd.percepcionME = i.percepcionME
                cd.NumNotas = i.notas
                cd.NumPagos = i.pagos
                cd.UltimaVenta = i.Ultima_Venta
                lista.Add(cd)
            Next

            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SP_UbicarDetalleCompraControl(intIdDocumento As Integer) As List(Of documentocompradetalle)
        Dim cd As New documentocompradetalle
        Dim lista As New List(Of documentocompradetalle)

        Dim consulta = (From n In HeliosData.uspListarDetalleCompraPoridDocumentoControl(intIdDocumento) _
                       Select n).ToList


        For Each i In consulta
            cd = New documentocompradetalle
            cd.IdEmpresa = i.idempresa
            cd.IdEstablecimiento = i.idCentroCosto
            cd.secuencia = i.secuencia
            cd.idItem = i.idItem
            cd.descripcionItem = i.descripcionItem
            cd.tipoExistencia = i.tipoExistencia
            cd.monto1 = i.monto1
            cd.importe = i.importe
            cd.importeUS = i.importeUS
            cd.montokardex = i.montokardex
            cd.montokardexUS = i.montokardexUS
            cd.almacenRef = i.almacenRef.GetValueOrDefault
            cd.NomAlmacen = i.descripcionAlmacen
            cd.CantidadDisponible = i.Disponible_Can.GetValueOrDefault
            cd.fechaEntrega = i.fechaEntrega
            cd.NumNotas = i.notas.GetValueOrDefault
            cd.NumPagos = i.pagos.GetValueOrDefault
            cd.UltimaVenta = i.Ultima_Venta.GetValueOrDefault
            lista.Add(cd)
        Next

        Return lista
        
    End Function

    Public Function ListaComprasXporveedor(fecInic As DateTime, fecHasta As DateTime, idProv As Integer) As List(Of documentocompradetalle)
        Dim obj As New documentocompradetalle
        Dim lista As New List(Of documentocompradetalle)

        Dim listaCompra As New List(Of String)
        listaCompra.Add(TIPO_COMPRA.COMPRA)
        listaCompra.Add(TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO)
        'listaCompra.Add(TIPO_COMPRA.COMPRA_ANTICIPADA)
        listaCompra.Add(TIPO_COMPRA.COMPRA_ANTICIPADA_OTORGADO)
        listaCompra.Add(TIPO_COMPRA.COMPRA_ANTICIPADA_RECIBIDA)
        listaCompra.Add(TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS)

        If idProv = -1 Then ' TODOS LOS PROVEEDORES
            Dim consulta = (From n In HeliosData.documentocompra _
                       Join c1 In HeliosData.documentocompradetalle _
                       On n.idDocumento Equals c1.idDocumento _
                       Join p In HeliosData.detalleitems _
                       On c1.idItem Equals p.codigodetalle _
                      Join e In HeliosData.entidad _
                      On n.idProveedor Equals e.idEntidad _
                      Where n.idEmpresa = Gempresas.IdEmpresaRuc _
                      And n.fechaDoc >= fecInic And n.fechaDoc <= fecHasta And listaCompra.Contains(n.tipoCompra)).ToList


            For Each i In consulta
                obj = New documentocompradetalle
                obj.TipoDoc = i.n.tipoDoc
                obj.Serie = i.n.serie
                obj.NumDoc = i.n.numeroDoc
                obj.FechaDoc = i.n.fechaDoc
                obj.NombreProveedor = i.e.nombreCompleto
                obj.descripcionItem = i.p.descripcionItem
                obj.monto1 = i.c1.monto1
                obj.precioUnitario = i.c1.precioUnitario
                obj.montokardex = i.c1.montokardex
                obj.montoIgv = i.c1.montoIgv
                obj.importe = i.c1.importe
                lista.Add(obj)
            Next


        Else ' POR PROVEEDOR
            Dim consulta = (From n In HeliosData.documentocompra _
                       Join c1 In HeliosData.documentocompradetalle _
                       On n.idDocumento Equals c1.idDocumento _
                       Join p In HeliosData.detalleitems _
                       On c1.idItem Equals p.codigodetalle _
                      Join e In HeliosData.entidad _
                      On n.idProveedor Equals e.idEntidad _
                      Where n.idEmpresa = Gempresas.IdEmpresaRuc And n.idProveedor = idProv _
                      And n.fechaDoc >= fecInic And n.fechaDoc <= fecHasta And listaCompra.Contains(n.tipoCompra)).ToList


            For Each i In consulta
                obj = New documentocompradetalle
                obj.TipoDoc = i.n.tipoDoc
                obj.Serie = i.n.serie
                obj.NumDoc = i.n.numeroDoc
                obj.FechaDoc = i.n.fechaDoc
                obj.NombreProveedor = i.e.nombreCompleto
                obj.descripcionItem = i.p.descripcionItem
                obj.monto1 = i.c1.monto1
                obj.precioUnitario = i.c1.precioUnitario
                obj.montokardex = i.c1.montokardex
                obj.montoIgv = i.c1.montoIgv
                obj.importe = i.c1.importe
                lista.Add(obj)
            Next
        End If


        Return lista
    End Function

#Region "CONFIG. PRECIOS"

    Public Function UltimasEntradasPorFecha(strEmpresa As String, intIdEstablecimiento As Integer, intAlnacenConsulta As Integer, IntIdItem As String) As List(Of documentocompradetalle)
        Dim lista As New List(Of String)
        Dim c As New documentocompradetalle
        Dim listaCompra As New List(Of documentocompradetalle)

        lista.Add(TIPO_COMPRA.COMPRA)
        lista.Add(TIPO_COMPRA.COMPRA_PAGADA)
        lista.Add(TIPO_COMPRA.OTRAS_ENTRADAS)
        lista.Add(TIPO_COMPRA.NOTA_DE_COMPRA)
        Dim consulta = (From n In HeliosData.documentocompra
                        Join det In HeliosData.documentocompradetalle
                        On n.idDocumento Equals det.idDocumento
                        Group Join ent In HeliosData.entidad
                        On ent.idEntidad Equals n.idProveedor Into mov_join = Group
                        From ent In mov_join.DefaultIfEmpty()
                        Where lista.Contains(n.tipoCompra) And
                            n.idEmpresa = strEmpresa And
                            n.idCentroCosto = intIdEstablecimiento And
                            det.idItem = IntIdItem Take intAlnacenConsulta Order By n.fechaDoc Descending).ToList


        'Dim com = (From n In HeliosData.saldoInicio _
        '                Join det In HeliosData.saldoInicioDetalle _
        '                On n.idDocumento Equals det.idDocumento _
        '               Where n.idEmpresa = strEmpresa And n.idCentroCosto = intIdEstablecimiento And _
        '               det.idModulo = (IntIdItem) And det.modulo = "MR" Take intAlnacenConsulta Order By n.fechaDoc Descending).ToList

        For Each i In consulta
            c = New documentocompradetalle
            c.idDocumento = i.n.idDocumento
            c.PorcIva = i.n.tasaIgv
            c.FechaDoc = i.n.fechaDoc
            c.tipoCompra = i.n.tipoCompra
            c.TipoDoc = i.n.tipoDoc
            c.Serie = i.n.serie
            c.NumDoc = i.n.numeroDoc
            If i.ent IsNot Nothing Then
                c.NombreProveedor = i.ent.nombreCompleto
            End If
            c.idItem = i.det.idItem
            c.descripcionItem = i.det.descripcionItem
            c.monto1 = i.det.monto1
            c.unidad1 = i.det.unidad1
            c.unidad2 = i.det.unidad2
            c.precioUnitario = i.det.precioUnitario
            c.precioUnitarioUS = i.det.precioUnitarioUS
            c.bonificacion = i.det.bonificacion
            c.montokardex = i.det.montokardex
            c.montokardexUS = i.det.montokardexUS
            c.importe = i.det.importe
            c.importeUS = i.det.importeUS
            listaCompra.Add(c)
        Next

        'For Each i In com
        '    c = New documentocompradetalle
        '    c.idDocumento = i.n.idDocumento
        '    c.PorcIva = 0
        '    c.FechaDoc = i.n.fechaDoc
        '    c.tipoCompra = i.n.tipoCompra
        '    c.TipoDoc = i.n.tipoDoc
        '    c.Serie = i.n.serie
        '    c.NumDoc = i.n.numeroDoc
        '    c.NombreProveedor = "-"
        '    c.idItem = i.det.idModulo
        '    c.descripcionItem = i.det.descripcionItem
        '    c.monto1 = i.det.cantidad
        '    c.unidad1 = Nothing
        '    c.unidad2 = Nothing
        '    c.precioUnitario = i.det.precioUnitario
        '    c.precioUnitarioUS = i.det.precioUnitarioUS
        '    c.bonificacion = Nothing
        '    c.montokardex = i.det.importe
        '    c.montokardexUS = i.det.importeUS
        '    c.importe = i.det.importe
        '    c.importeUS = i.det.importeUS
        '    listaCompra.Add(c)
        'Next

        Return listaCompra
    End Function

    'Public Function UltimasEntradasPorFechaXproveedor(strEmpresa As String, intIdEstablecimiento As Integer, intAlnacenConsulta As Integer, IntIdItem As String) As List(Of documentocompradetalle)
    '    Dim lista As New List(Of String)
    '    Dim c As New documentocompradetalle
    '    Dim listaCompra As New List(Of documentocompradetalle)

    '    lista.Add(TIPO_COMPRA.COMPRA)
    '    lista.Add(TIPO_COMPRA.OTRAS_ENTRADAS)
    '    Dim consulta = (From n In HeliosData.documentocompra _
    '                    Join det In HeliosData.documentocompradetalle _
    '                    On n.idDocumento Equals det.idDocumento _
    '                   Where lista.Contains(n.tipoCompra) _
    '                   And n.idEmpresa = strEmpresa And n.idCentroCosto = intIdEstablecimiento And _
    '                   det.idItem.Contains(IntIdItem) Take intAlnacenConsulta Order By n.fechaDoc Descending).ToList


    '    Dim com = (From n In HeliosData.saldoInicio _
    '                    Join det In HeliosData.saldoInicioDetalle _
    '                    On n.idDocumento Equals det.idDocumento _
    '                   Where n.idEmpresa = strEmpresa And n.idCentroCosto = intIdEstablecimiento And _
    '                   det.idModulo = (IntIdItem) And det.modulo = "MR" Take intAlnacenConsulta Order By n.fechaDoc Descending).ToList

    '    For Each i In consulta
    '        c = New documentocompradetalle
    '        c.idDocumento = i.n.idDocumento
    '        c.FechaDoc = i.n.fechaDoc
    '        c.tipoCompra = i.n.tipoCompra
    '        c.TipoDoc = i.n.tipoDoc
    '        c.Serie = i.n.serie
    '        c.NumDoc = i.n.numeroDoc
    '        c.idItem = i.det.idItem
    '        c.descripcionItem = i.det.descripcionItem
    '        c.monto1 = i.det.monto1
    '        c.unidad1 = i.det.unidad1
    '        c.unidad2 = i.det.unidad2
    '        c.precioUnitario = i.det.precioUnitario
    '        c.precioUnitarioUS = i.det.precioUnitarioUS
    '        c.bonificacion = i.det.bonificacion
    '        c.montokardex = i.det.montokardex
    '        c.montokardexUS = i.det.montokardexUS
    '        c.importe = i.det.importe
    '        c.importeUS = i.det.importeUS
    '        listaCompra.Add(c)
    '    Next

    '    For Each i In com
    '        c = New documentocompradetalle
    '        c.idDocumento = i.n.idDocumento
    '        c.FechaDoc = i.n.fechaDoc
    '        c.tipoCompra = i.n.tipoCompra
    '        c.TipoDoc = i.n.tipoDoc
    '        c.Serie = i.n.serie
    '        c.NumDoc = i.n.numeroDoc
    '        c.idItem = i.det.idModulo
    '        c.descripcionItem = i.det.descripcionItem
    '        c.monto1 = i.det.cantidad
    '        c.unidad1 = Nothing
    '        c.unidad2 = Nothing
    '        c.precioUnitario = i.det.precioUnitario
    '        c.precioUnitarioUS = i.det.precioUnitarioUS
    '        c.bonificacion = Nothing
    '        c.montokardex = i.det.importe
    '        c.montokardexUS = i.det.importeUS
    '        c.importe = i.det.importe
    '        c.importeUS = i.det.importeUS
    '        listaCompra.Add(c)
    '    Next

    '    Return listaCompra
    'End Function
#End Region

#Region "SOLICITUDES"
    Public Sub UpdateSolicitudMartin(ByVal documentocompradetalleBE As documentocompradetalle, strTipoDoc As String)
        Dim OBJD As New documentocompradetalle
        Dim objNuevo As New totalesAlmacen

        Using ts As New TransactionScope


            If documentocompradetalleBE.Action = Business.Entity.BaseBE.EntityAction.UPDATE Then

                Dim docCompradetalle As documentocompradetalle = HeliosData.documentocompradetalle.Where(Function(o) _
                                         o.idDocumento = documentocompradetalleBE.idDocumento _
                                         And o.secuencia = documentocompradetalleBE.secuencia).First()


                docCompradetalle.idItem = documentocompradetalleBE.idItem
                docCompradetalle.descripcionItem = documentocompradetalleBE.descripcionItem
                docCompradetalle.tipoExistencia = documentocompradetalleBE.tipoExistencia
                docCompradetalle.destino = documentocompradetalleBE.destino
                docCompradetalle.unidad1 = documentocompradetalleBE.unidad1
                docCompradetalle.monto1 = documentocompradetalleBE.monto1
                docCompradetalle.unidad2 = documentocompradetalleBE.unidad2
                docCompradetalle.monto2 = documentocompradetalleBE.monto2
                docCompradetalle.precioUnitario = documentocompradetalleBE.precioUnitario
                docCompradetalle.precioUnitarioUS = documentocompradetalleBE.precioUnitarioUS
                docCompradetalle.importe = documentocompradetalleBE.importe
                docCompradetalle.importeUS = documentocompradetalleBE.importeUS
                docCompradetalle.montokardex = documentocompradetalleBE.montokardex
                docCompradetalle.montoIsc = documentocompradetalleBE.montoIsc
                docCompradetalle.montoIgv = documentocompradetalleBE.montoIgv
                docCompradetalle.otrosTributos = documentocompradetalleBE.otrosTributos
                docCompradetalle.montokardexUS = documentocompradetalleBE.montokardexUS
                docCompradetalle.montoIscUS = documentocompradetalleBE.montoIscUS
                docCompradetalle.montoIgvUS = documentocompradetalleBE.montoIgvUS
                docCompradetalle.otrosTributosUS = documentocompradetalleBE.otrosTributosUS
                docCompradetalle.preEvento = documentocompradetalleBE.preEvento
                'docCompradetalle.saldoMontoNota = documentocompradetalleBE.saldoMontoNota
                'docCompradetalle.saldoMontoNotaUSD = documentocompradetalleBE.saldoMontoNotaUSD
                docCompradetalle.bonificacion = documentocompradetalleBE.bonificacion
                docCompradetalle.almacenRef = documentocompradetalleBE.almacenRef
                docCompradetalle.usuarioModificacion = documentocompradetalleBE.usuarioModificacion
                docCompradetalle.fechaModificacion = documentocompradetalleBE.fechaModificacion
                docCompradetalle.entregable = documentocompradetalleBE.entregable
                docCompradetalle.fechaEntrega = documentocompradetalleBE.fechaEntrega


                'HeliosData.ObjectStateManager.GetObjectStateEntry(docCompradetalle).State.ToString()

            ElseIf documentocompradetalleBE.Action = Business.Entity.BaseBE.EntityAction.INSERT Then



                OBJD = New documentocompradetalle
                '    objInventario = New HeliosDAL.InventarioMovimiento
                OBJD.idDocumento = documentocompradetalleBE.idDocumento ' Me.IdDocumento
                OBJD.idItem = documentocompradetalleBE.idItem
                OBJD.descripcionItem = documentocompradetalleBE.descripcionItem
                OBJD.tipoExistencia = documentocompradetalleBE.tipoExistencia
                OBJD.destino = documentocompradetalleBE.destino
                OBJD.unidad1 = documentocompradetalleBE.unidad1
                OBJD.monto1 = documentocompradetalleBE.monto1
                OBJD.unidad2 = documentocompradetalleBE.unidad2
                OBJD.monto2 = documentocompradetalleBE.monto2
                OBJD.precioUnitario = documentocompradetalleBE.precioUnitario
                OBJD.precioUnitarioUS = documentocompradetalleBE.precioUnitarioUS
                OBJD.importe = documentocompradetalleBE.importe
                OBJD.importeUS = documentocompradetalleBE.importeUS
                OBJD.montokardex = documentocompradetalleBE.montokardex
                OBJD.montoIsc = documentocompradetalleBE.montoIsc
                OBJD.montoIgv = documentocompradetalleBE.montoIgv
                OBJD.otrosTributos = documentocompradetalleBE.otrosTributos
                '*********************************************************************
                OBJD.montokardexUS = documentocompradetalleBE.montokardexUS
                OBJD.montoIscUS = documentocompradetalleBE.montoIscUS
                OBJD.montoIgvUS = documentocompradetalleBE.montoIgvUS
                OBJD.otrosTributosUS = documentocompradetalleBE.otrosTributosUS
                If IsNothing(documentocompradetalleBE.preEvento) Then
                    OBJD.preEvento = Nothing
                Else
                    OBJD.preEvento = documentocompradetalleBE.preEvento
                End If
                OBJD.bonificacion = documentocompradetalleBE.bonificacion
                'OBJD.saldoMontoNota = documentocompradetalleBE.importe
                'OBJD.saldoMontoNotaUSD = documentocompradetalleBE.importeUS
                OBJD.almacenRef = documentocompradetalleBE.almacenRef
                '*********************************************************************
                OBJD.usuarioModificacion = documentocompradetalleBE.usuarioModificacion
                OBJD.fechaModificacion = documentocompradetalleBE.fechaModificacion

                OBJD.entregable = documentocompradetalleBE.entregable
                OBJD.fechaEntrega = documentocompradetalleBE.fechaEntrega



                HeliosData.documentocompradetalle.Add(OBJD)

            ElseIf documentocompradetalleBE.Action = Business.Entity.BaseBE.EntityAction.DELETE Then
                Dim consulta = (From n In HeliosData.documentocompradetalle _
                               Where n.secuencia = documentocompradetalleBE.secuencia).First

                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EstadoSoli(ByVal documentoBE As documentocompra)

        Using ts As New TransactionScope
            Dim doc As documentocompra = HeliosData.documentocompra.Where(Function(o) _
                                            o.idDocumento = documentoBE.idDocumento).First()
            doc.tipoCompra = documentoBE.tipoCompra
            'HeliosData.ObjectStateManager.GetObjectStateEntry(doc).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub
#End Region

    Public Function SumaNotasXidPadreItemOpcionDefault(intIdSecuencia As Integer) As documentocompradetalle
        Dim objDetalle As New documentocompradetalle
        Dim lista As New List(Of String)
        lista.Add("07")
        lista.Add("87")

        Dim lista2 As New List(Of String)
        lista2.Add("08")
        lista2.Add("88")

        Dim listaComp As New List(Of String)
        listaComp.Add("9901")


        Dim totals3 = Aggregate p In HeliosData.documentocompradetalle
                      Join compra In HeliosData.documentocompra
                      On p.idDocumento Equals compra.idDocumento
                                 Where p.idPadreDTCompra = intIdSecuencia _
                                 And lista.Contains(compra.tipoDoc) And compra.tipoCompra <> "NDD" And Not compra.tipoCompra = "EXD"
                 Into mn = Sum(p.importe),
                      mne = Sum(p.importeUS),
                      can = Sum(p.monto1),
                      kard = Sum(p.montokardex),
                          kardme = Sum(p.montokardexUS)

        Dim totals4 = Aggregate p In HeliosData.documentocompradetalle
                     Join compra In HeliosData.documentocompra
                     On p.idDocumento Equals compra.idDocumento
                     Where p.idPadreDTCompra = intIdSecuencia _
                     And lista2.Contains(compra.tipoDoc) And p.operacionNota <> "9923"
                     Into DBmn = Sum(p.importe),
                         DBmne = Sum(p.importeUS),
                          DBkard = Sum(p.montokardex),
                          DBkardme = Sum(p.montokardexUS)

        Dim Compensa = Aggregate p In HeliosData.documentocompradetalle
                      Join compra In HeliosData.documentocompra
                      On p.idDocumento Equals compra.idDocumento
                                 Where p.idPadreDTCompra = intIdSecuencia _
                                 And listaComp.Contains(compra.tipoDoc) And compra.tipoCompra = "COMP"
                 Into comp = Sum(p.importe),
                      compme = Sum(p.importeUS)



        Dim DineroDev = Aggregate p In HeliosData.documentocompradetalle
                      Join compra In HeliosData.documentocompra
                      On p.idDocumento Equals compra.idDocumento
                                 Where p.idPadreDTCompra = intIdSecuencia _
                                 And lista.Contains(compra.tipoDoc) And compra.tipoCompra = "EXD"
                 Into devuelto = Sum(p.importe),
                      devueltome = Sum(p.importeUS)





        'Dim Ajustes = Aggregate p In HeliosData.documentoLibroDiarioDetalle _
        '         Join compra In HeliosData.documentoLibroDiario _
        '         On p.idDocumento Equals compra.idDocumento _
        '                    Where p.cuenta = intIdSecuencia _
        '                    And compra.tipoRegistro = "AJU"
        '    Into AJmn = Sum(p.importeMN), _
        '         AJme = Sum(p.importeME)


        objDetalle.monto1 = totals3.can.GetValueOrDefault
        objDetalle.importe = totals3.mn.GetValueOrDefault
        objDetalle.importeUS = totals3.mne.GetValueOrDefault
        objDetalle.ImporteDBMN = totals4.DBmn.GetValueOrDefault
        objDetalle.ImporteDBME = totals4.DBmne.GetValueOrDefault

        objDetalle.montokardex = totals3.kard.GetValueOrDefault
        objDetalle.montokardexDB = totals4.DBkard.GetValueOrDefault
        objDetalle.montokardexUS = totals3.kardme.GetValueOrDefault
        objDetalle.montokardexDBUS = totals4.DBkardme.GetValueOrDefault
        objDetalle.montoCompesacion = Compensa.comp.GetValueOrDefault
        objDetalle.montoCompesacionme = Compensa.compme.GetValueOrDefault

        objDetalle.DineroDevuelto = DineroDev.devuelto.GetValueOrDefault
        objDetalle.DineroDevueltome = DineroDev.devueltome.GetValueOrDefault

        Return objDetalle

    End Function

    'Public Function SumaNotasXidPadreItemOpcionDefault(intIdSecuencia As Integer) As documentocompradetalle
    '    Dim objDetalle As New documentocompradetalle
    '    Dim lista As New List(Of String)
    '    lista.Add("07")
    '    lista.Add("87")

    '    Dim lista2 As New List(Of String)
    '    lista2.Add("08")
    '    lista2.Add("88")

    '    Dim totals3 = Aggregate p In HeliosData.documentocompradetalle
    '                  Join compra In HeliosData.documentocompra
    '                  On p.idDocumento Equals compra.idDocumento
    '                             Where p.idPadreDTCompra = intIdSecuencia _
    '                             And lista.Contains(compra.tipoDoc) And compra.tipoCompra <> "NDD"
    '             Into mn = Sum(p.importe),
    '                  mne = Sum(p.importeUS),
    '                  can = Sum(p.monto1),
    '                  kard = Sum(p.montokardex),
    '                      kardme = Sum(p.montokardexUS)

    '    Dim totals4 = Aggregate p In HeliosData.documentocompradetalle
    '                 Join compra In HeliosData.documentocompra
    '                 On p.idDocumento Equals compra.idDocumento
    '                 Where p.idPadreDTCompra = intIdSecuencia _
    '                 And lista2.Contains(compra.tipoDoc) And p.operacionNota <> "9923"
    '                 Into DBmn = Sum(p.importe),
    '                     DBmne = Sum(p.importeUS),
    '                      DBkard = Sum(p.montokardex),
    '                      DBkardme = Sum(p.montokardexUS)


    '    'Dim Ajustes = Aggregate p In HeliosData.documentoLibroDiarioDetalle _
    '    '         Join compra In HeliosData.documentoLibroDiario _
    '    '         On p.idDocumento Equals compra.idDocumento _
    '    '                    Where p.cuenta = intIdSecuencia _
    '    '                    And compra.tipoRegistro = "AJU"
    '    '    Into AJmn = Sum(p.importeMN), _
    '    '         AJme = Sum(p.importeME)


    '    objDetalle.monto1 = totals3.can.GetValueOrDefault
    '    objDetalle.importe = totals3.mn.GetValueOrDefault
    '    objDetalle.importeUS = totals3.mne.GetValueOrDefault
    '    objDetalle.ImporteDBMN = totals4.DBmn.GetValueOrDefault
    '    objDetalle.ImporteDBME = totals4.DBmne.GetValueOrDefault

    '    objDetalle.montokardex = totals3.kard.GetValueOrDefault
    '    objDetalle.montokardexDB = totals4.DBkard.GetValueOrDefault
    '    objDetalle.montokardexUS = totals3.kardme.GetValueOrDefault
    '    objDetalle.montokardexDBUS = totals4.DBkardme.GetValueOrDefault
    '    'objDetalle.ImporteAJmn = Ajustes.AJmn.GetValueOrDefault
    '    'objDetalle.ImporteAJme = Ajustes.AJme.GetValueOrDefault
    '    Return objDetalle

    'End Function
    'Public Function SumaNotasXidPadreItemOpcionDefault(intIdSecuencia As Integer) As documentocompradetalle
    '    Dim objDetalle As New documentocompradetalle
    '    Dim lista As New List(Of String)
    '    lista.Add("07")
    '    lista.Add("87")

    '    Dim lista2 As New List(Of String)
    '    lista2.Add("08")
    '    lista2.Add("88")

    '    Dim totals3 = Aggregate p In HeliosData.documentocompradetalle _
    '                  Join compra In HeliosData.documentocompra _
    '                  On p.idDocumento Equals compra.idDocumento _
    '                             Where p.idPadreDTCompra = intIdSecuencia _
    '                             And lista.Contains(compra.tipoDoc) _
    '             Into mn = Sum(p.importe), _
    '                  mne = Sum(p.importeUS), _
    '                  can = Sum(p.monto1)

    '    Dim totals4 = Aggregate p In HeliosData.documentocompradetalle _
    '                 Join compra In HeliosData.documentocompra _
    '                 On p.idDocumento Equals compra.idDocumento _
    '                 Where p.idPadreDTCompra = intIdSecuencia _
    '                 And lista2.Contains(compra.tipoDoc) And p.operacionNota <> "9923" _
    '                 Into DBmn = Sum(p.importe), _
    '                     DBmne = Sum(p.importeUS)


    '    'Dim Ajustes = Aggregate p In HeliosData.documentoLibroDiarioDetalle _
    '    '         Join compra In HeliosData.documentoLibroDiario _
    '    '         On p.idDocumento Equals compra.idDocumento _
    '    '                    Where p.cuenta = intIdSecuencia _
    '    '                    And compra.tipoRegistro = "AJU"
    '    '    Into AJmn = Sum(p.importeMN), _
    '    '         AJme = Sum(p.importeME)


    '    objDetalle.monto1 = totals3.can.GetValueOrDefault
    '    objDetalle.importe = totals3.mn.GetValueOrDefault
    '    objDetalle.importeUS = totals3.mne.GetValueOrDefault
    '    objDetalle.ImporteDBMN = totals4.DBmn.GetValueOrDefault
    '    objDetalle.ImporteDBME = totals4.DBmne.GetValueOrDefault
    '    'objDetalle.ImporteAJmn = Ajustes.AJmn.GetValueOrDefault
    '    'objDetalle.ImporteAJme = Ajustes.AJme.GetValueOrDefault
    '    Return objDetalle

    'End Function

    Public Function SumaNotasXidPadreItem(intIdSecuencia As Integer) As documentocompradetalle
        Dim lista As New List(Of String)
        lista.Add("07")
        lista.Add("87")
        lista.Add("9901")

        Dim lista2 As New List(Of String)
        lista2.Add("08")
        lista2.Add("88")
        lista2.Add("40")

        Dim objDetalle As New documentocompradetalle
        Dim totals3 = Aggregate p In HeliosData.documentocompradetalle _
                      Join compra In HeliosData.documentocompra _
                      On p.idDocumento Equals compra.idDocumento _
                                 Where p.idPadreDTCompra = intIdSecuencia _
                                 And lista.Contains(compra.tipoDoc) _
                                 Into mn = Sum(p.importe), _
                                 mne = Sum(p.importeUS), _
                                 can = Sum(p.monto1)

        Dim totals4 = Aggregate p In HeliosData.documentocompradetalle _
                     Join compra In HeliosData.documentocompra _
                     On p.idDocumento Equals compra.idDocumento _
                                Where p.idPadreDTCompra = intIdSecuencia _
                                And lista2.Contains(compra.tipoDoc) _
                                Into DBmn = Sum(p.importe), _
                                DBmne = Sum(p.importeUS)


        'Dim Ajustes = Aggregate p In HeliosData.documentoLibroDiarioDetalle _
        '         Join compra In HeliosData.documentoLibroDiario _
        '         On p.idDocumento Equals compra.idDocumento _
        '                    Where p.cuenta = intIdSecuencia _
        '                    And compra.tipoRegistro = "AJU"
        '    Into AJmn = Sum(p.importeMN), _
        '         AJme = Sum(p.importeME)


        objDetalle.monto1 = totals3.can.GetValueOrDefault
        objDetalle.importe = totals3.mn.GetValueOrDefault
        objDetalle.importeUS = totals3.mne.GetValueOrDefault
        objDetalle.ImporteDBMN = totals4.DBmn.GetValueOrDefault
        objDetalle.ImporteDBME = totals4.DBmne.GetValueOrDefault
        'objDetalle.ImporteAJmn = Ajustes.AJmn.GetValueOrDefault
        'objDetalle.ImporteAJme = Ajustes.AJme.GetValueOrDefault
        Return objDetalle

    End Function


    Public Function SumaNotasXidPadreItemVentas(intIdSecuencia As Integer) As documentoventaAbarrotesDet
        Dim objDetalle As New documentoventaAbarrotesDet
        Dim lista As New List(Of String)
        lista.Add("07")
        lista.Add("87")
        lista.Add("9901")
        lista.Add("20")

        Dim lista2 As New List(Of String)
        lista2.Add("08")
        lista2.Add("88")


        Dim totals3 = Aggregate p In HeliosData.documentoventaAbarrotesDet
                      Join compra In HeliosData.documentoventaAbarrotes
                      On p.idDocumento Equals compra.idDocumento
                                 Where p.idPadreDTVenta = intIdSecuencia _
                                 And lista.Contains(compra.tipoDocumento)
                 Into mn = Sum(p.importeMN),
                      mne = Sum(p.importeME),
                      can = Sum(p.monto1),
                      kard = Sum(p.montokardex),
                          kardme = Sum(p.montokardexUS)

        Dim totals4 = Aggregate p In HeliosData.documentoventaAbarrotesDet
                     Join compra In HeliosData.documentoventaAbarrotes
                     On p.idDocumento Equals compra.idDocumento
                                Where p.idPadreDTVenta = intIdSecuencia _
                                And lista2.Contains(compra.tipoDocumento)
                Into DBmn = Sum(p.importeMN),
                     DBmne = Sum(p.importeME),
                          DBkard = Sum(p.montokardex),
                          DBkardme = Sum(p.montokardexUS)


        objDetalle.monto1 = totals3.can.GetValueOrDefault
        objDetalle.importeMN = totals3.mn.GetValueOrDefault
        objDetalle.importeME = totals3.mne.GetValueOrDefault
        objDetalle.ImporteDBMN = totals4.DBmn.GetValueOrDefault
        objDetalle.ImporteDBME = totals4.DBmne.GetValueOrDefault

        objDetalle.montokardex = totals3.kard.GetValueOrDefault
        objDetalle.montokardexDB = totals4.DBkard.GetValueOrDefault
        objDetalle.montokardexUS = totals3.kardme.GetValueOrDefault
        objDetalle.montokardexDBUS = totals4.DBkardme.GetValueOrDefault

        Return objDetalle

    End Function

    Public Function GetUbicar_documentocompradetallePorCompraSL(strSerie As String, strNroDoc As String, strSitucion As String, intIdproveedor As Integer) As List(Of documentocompradetalle)
        Return (From a In HeliosData.documentocompradetalle
                Join b In HeliosData.documentocompra
                On a.idDocumento Equals b.idDocumento
                 Where b.serie = strSerie And b.numeroDoc = strNroDoc _
                 And a.situacion = strSitucion _
                 And b.idProveedor = intIdproveedor Select a).ToList
    End Function

    Public Function UltimasOtrasSalidasPorFecha(strEmpresa As String, intIdEstablecimiento As Integer, intCuota As Integer, intAlnacenConsulta As Integer, IntIdItem As String) As List(Of documentocompradetalle)
        Dim lista As New List(Of String)
        Dim c As New documentocompradetalle
        Dim listaCompra As New List(Of documentocompradetalle)

        lista.Add(TIPO_COMPRA.COMPRA_AL_CREDITO_CON_RECEPCION)
        lista.Add(TIPO_COMPRA.COMPRA_AL_CREDITO)
        lista.Add(TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION)
        lista.Add(TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION)
        lista.Add(TIPO_COMPRA.OTRAS_ENTRADAS)

        Dim consulta = (From n In HeliosData.documentocompra _
                        Join det In HeliosData.documentocompradetalle _
                        On n.idDocumento Equals det.idDocumento _
                       Where lista.Contains(n.tipoCompra) _
                       And n.idEmpresa = strEmpresa And n.idCentroCosto = intIdEstablecimiento And _
                       det.almacenRef = intAlnacenConsulta And _
                       det.idItem.Contains(IntIdItem) Take intCuota _
                       Order By n.fechaDoc Descending).ToList

        For Each i In consulta
            c = New documentocompradetalle
            c.idDocumento = i.n.idDocumento
            c.FechaDoc = i.n.fechaDoc
            c.tipoCompra = i.n.tipoCompra
            c.TipoDoc = i.n.tipoDoc
            c.Serie = i.n.serie
            c.NumDoc = i.n.numeroDoc
            c.idItem = i.det.idItem
            c.descripcionItem = i.det.descripcionItem
            c.unidad1 = i.det.unidad1
            c.unidad2 = i.det.unidad2
            c.monto1 = i.det.monto1
            c.precioUnitario = i.det.precioUnitario
            c.precioUnitarioUS = i.det.precioUnitarioUS
            c.bonificacion = i.det.bonificacion
            c.importe = i.det.importe
            c.importeUS = i.det.importeUS
            listaCompra.Add(c)
        Next
        Return listaCompra
    End Function

    Public Function SumatoriaImportesCompra(intIdDocumento As Integer) As documentocompradetalle
        Dim docCajaDetalle As New documentocompradetalle

        Dim consulta = (From compra In HeliosData.documentocompra _
                         Group Join cab In HeliosData.documentocompradetalle _
                        On compra.idDocumento Equals cab.idDocumento _
                        Into ords = Group _
                       From e In ords.DefaultIfEmpty _
                        Where compra.idDocumento = intIdDocumento _
                               Group e By _
                               compra.fechaContable, compra.estadoPago, _
                               compra.idDocumento, compra.tipoDoc, compra.fechaDoc, compra.serie, _
                               compra.numeroDoc, compra.tcDolLoc, compra.tasaIgv, compra.idProveedor, _
                               compra.monedaDoc, compra.importeTotal, compra.importeUS, compra.tipoCompra
                               Into g = Group _
                               Select New With {
                                   .estadoCobro = estadoPago,
                                   .fechaPeriodo = fechaContable,
                                   .iddocumento = idDocumento,
                                   .tipoDocumento = tipoDoc,
                                   .fechaDoc = fechaDoc,
                                   .serie = serie,
                                   .numeroDocNormal = numeroDoc,
                                   .tipoCambio = tcDolLoc,
                                   .tasaIgv = tasaIgv,
                                   .idCliente = idProveedor,
                                    .tipocompra = tipoCompra,
                                   .moneda = monedaDoc,
                                   g, .notaCreditoMN = g.Sum(Function(cab) cab.notaCreditoMN),
                                   .notaCreditoME = g.Sum(Function(cab) cab.notaCreditoME),
                                   .notaDebitoMN = g.Sum(Function(cab) cab.notaDebitoMN),
                                   .notaDebitoME = g.Sum(Function(cab) cab.notaDebitoME)}).FirstOrDefault


        If Not IsNothing(consulta) Then
            With consulta
                docCajaDetalle = New documentocompradetalle
                'docCajaDetalle.EstadoCobro = .estadoCobro
                'docCajaDetalle.FechaPeriodo = .fechaPeriodo
                docCajaDetalle.idDocumento = .iddocumento
                '   docCajaDetalle.tipoDocumento = .tipoDocumento
                docCajaDetalle.FechaDoc = .fechaDoc
                docCajaDetalle.Serie = .serie
                'docCajaDetalle.numeroDocNormal = .numeroDocNormal
                'docCajaDetalle.tipoCambio = .tipoCambio
                'docCajaDetalle.tasaIgv = .tasaIgv
                'docCajaDetalle.idCliente = .idCliente
                docCajaDetalle.Moneda = .moneda
                If IsNothing(.notaCreditoMN) Then
                    docCajaDetalle.notaCreditoMN = 0
                Else
                    docCajaDetalle.notaCreditoMN = .notaCreditoMN
                End If

                If IsNothing(.notaCreditoME) Then
                    docCajaDetalle.notaCreditoME = 0
                Else
                    docCajaDetalle.notaCreditoME = .notaCreditoME
                End If

                If IsNothing(.notaDebitoMN) Then
                    docCajaDetalle.notaDebitoMN = 0
                Else
                    docCajaDetalle.notaDebitoMN = .notaDebitoMN
                End If

                If IsNothing(.notaDebitoME) Then
                    docCajaDetalle.notaDebitoME = 0
                Else
                    docCajaDetalle.notaDebitoME = .notaDebitoME
                End If

            End With
        Else
            'docCajaDetalle.montoSoles = 0
            'docCajaDetalle.montoUsd = 0
        End If


        Return docCajaDetalle

    End Function

    Public Function TieneItemsEnAV(intIdDocumento As Integer) As Boolean
        Dim consulta = (From n In HeliosData.documentocompradetalle _
                       Where n.idDocumento = intIdDocumento _
                       And n.ItemEntregadototal = "N").Count

        If consulta > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Insert(ByVal documentocompradetalleBE As documentocompradetalle) As Integer
        Using ts As New TransactionScope
            HeliosData.documentocompradetalle.Add(documentocompradetalleBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentocompradetalleBE.secuencia
        End Using
    End Function

    Public Function InsertSingle(documentocompradetalle As documentocompradetalle, intIdDocumento As Integer) As Integer
        '  Dim OBJD As New documentocompradetalle
        Using ts As New TransactionScope
            Select Case documentocompradetalle.estadoPago
                Case "Pagado"
                    documentocompradetalle.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                Case "No Pagado"
                    documentocompradetalle.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                Case Else
                    documentocompradetalle.estadoPago = documentocompradetalle.estadoPago
            End Select
            documentocompradetalle.idDocumento = intIdDocumento
            documentocompradetalle.preEvento = "S"
            HeliosData.documentocompradetalle.Add(documentocompradetalle)

            'OBJD = New documentocompradetalle
            'OBJD.codigoLote = documentocompradetalle.codigoLote
            'OBJD.idDocumento = intIdDocumento ' Me.IdDocumento
            ''    objInventario = New HeliosDAL.InventarioMovimiento
            'Select Case documentocompradetalle.estadoPago
            '    Case "Pagado"
            '        OBJD.estadoPago = TIPO_COMPRA.PAGO.PAGADO
            '    Case "No Pagado"
            '        OBJD.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            '    Case Else
            '        OBJD.estadoPago = documentocompradetalle.estadoPago
            'End Select
            'OBJD.idItem = documentocompradetalle.idItem
            'OBJD.descripcionItem = documentocompradetalle.descripcionItem
            'OBJD.tipoExistencia = documentocompradetalle.tipoExistencia
            'OBJD.destino = documentocompradetalle.destino
            'OBJD.unidad1 = documentocompradetalle.unidad1
            'OBJD.monto1 = documentocompradetalle.monto1
            'OBJD.unidad2 = documentocompradetalle.unidad2
            'OBJD.monto2 = documentocompradetalle.monto2
            'OBJD.precioUnitario = documentocompradetalle.precioUnitario
            'OBJD.precioUnitarioUS = documentocompradetalle.precioUnitarioUS
            'OBJD.importe = documentocompradetalle.importe
            'OBJD.importeUS = documentocompradetalle.importeUS
            'OBJD.montokardex = documentocompradetalle.montokardex
            'OBJD.montoIsc = documentocompradetalle.montoIsc
            'OBJD.montoIgv = documentocompradetalle.montoIgv
            'OBJD.otrosTributos = documentocompradetalle.otrosTributos
            ''*********************************************************************
            'OBJD.montokardexUS = documentocompradetalle.montokardexUS
            'OBJD.montoIscUS = documentocompradetalle.montoIscUS
            'OBJD.montoIgvUS = documentocompradetalle.montoIgvUS
            'OBJD.otrosTributosUS = documentocompradetalle.otrosTributosUS
            ''  If IsNothing(documentocompradetalle.preEvento) Then
            'OBJD.preEvento = Nothing
            ''Else
            ''OBJD.preEvento = documentocompradetalle.preEvento
            ''End If
            'OBJD.bonificacion = documentocompradetalle.bonificacion
            'OBJD.notaCreditoMN = documentocompradetalle.notaCreditoMN
            'OBJD.notaCreditoME = documentocompradetalle.notaCreditoME

            'OBJD.percepcionMN = documentocompradetalle.percepcionMN
            'OBJD.percepcionME = documentocompradetalle.percepcionME
            'OBJD.almacenRef = documentocompradetalle.almacenRef
            'OBJD.idPadreDTCompra = documentocompradetalle.idPadreDTCompra

            'OBJD.entregable = documentocompradetalle.entregable
            'OBJD.fechaEntrega = documentocompradetalle.fechaEntrega
            ''*********************************************************************
            'OBJD.situacion = documentocompradetalle.situacion
            'OBJD.operacionNota = documentocompradetalle.TipoOperacion
            'OBJD.categoria = documentocompradetalle.categoria
            'OBJD.ItemEntregadototal = documentocompradetalle.ItemEntregadototal
            'OBJD.nrolote = documentocompradetalle.nrolote

            'OBJD.idCosto = documentocompradetalle.idCosto
            'OBJD.tipoCosto = documentocompradetalle.tipoCosto

            'OBJD.usuarioModificacion = documentocompradetalle.usuarioModificacion
            'OBJD.fechaModificacion = documentocompradetalle.fechaModificacion
            'HeliosData.documentocompradetalle.Add(OBJD)
            HeliosData.SaveChanges()
            ts.Complete()
            documentocompradetalle.secuencia = documentocompradetalle.secuencia
            Return documentocompradetalle.secuencia
        End Using
    End Function

    Public Function InsertSingleTransAlmacen(documentocompradetalle As documentocompradetalle, intIdDocumento As Integer) As Integer
        Dim OBJD As New documentocompradetalle
        Using ts As New TransactionScope

            OBJD = New documentocompradetalle
            '    objInventario = New HeliosDAL.InventarioMovimiento
            OBJD.idDocumento = intIdDocumento ' Me.IdDocumento
            OBJD.codigoLote = documentocompradetalle.codigoLote
            OBJD.idItem = documentocompradetalle.idItem
            OBJD.descripcionItem = documentocompradetalle.descripcionItem
            OBJD.tipoExistencia = documentocompradetalle.tipoExistencia
            OBJD.destino = documentocompradetalle.destino
            OBJD.unidad1 = documentocompradetalle.unidad1
            OBJD.monto1 = documentocompradetalle.monto1
            OBJD.unidad2 = documentocompradetalle.unidad2
            OBJD.monto2 = documentocompradetalle.monto2
            OBJD.precioUnitario = documentocompradetalle.precioUnitario
            OBJD.precioUnitarioUS = documentocompradetalle.precioUnitarioUS
            OBJD.importe = documentocompradetalle.importe
            OBJD.importeUS = documentocompradetalle.importeUS
            OBJD.montokardex = documentocompradetalle.montokardex
            OBJD.montoIsc = documentocompradetalle.montoIsc
            OBJD.montoIgv = documentocompradetalle.montoIgv
            OBJD.otrosTributos = documentocompradetalle.otrosTributos
            '*********************************************************************
            OBJD.montokardexUS = documentocompradetalle.montokardexUS
            OBJD.montoIscUS = documentocompradetalle.montoIscUS
            OBJD.montoIgvUS = documentocompradetalle.montoIgvUS
            OBJD.otrosTributosUS = documentocompradetalle.otrosTributosUS
            If IsNothing(documentocompradetalle.preEvento) Then
                OBJD.preEvento = Nothing
            Else
                OBJD.preEvento = documentocompradetalle.preEvento
            End If
            OBJD.bonificacion = documentocompradetalle.bonificacion
            'OBJD.monto = documentocompradetalle.importe
            'OBJD.saldoMontoNotaUSD = documentocompradetalle.importeUS
            OBJD.almacenRef = documentocompradetalle.almacenRef
            OBJD.almacenDestino = documentocompradetalle.almacenDestino
            OBJD.idPadreDTCompra = documentocompradetalle.idPadreDTCompra
            '*********************************************************************
            OBJD.usuarioModificacion = documentocompradetalle.usuarioModificacion
            OBJD.fechaModificacion = documentocompradetalle.fechaModificacion
            HeliosData.documentocompradetalle.Add(OBJD)
            HeliosData.SaveChanges()
            ts.Complete()
            Return OBJD.secuencia
        End Using
    End Function

    Public Sub Update(ByVal documentocompradetalleBE As documentocompradetalle, strTipoDoc As String)
        Dim OBJD As New documentocompradetalle
        Dim objNuevo As New totalesAlmacen

        Using ts As New TransactionScope


            If documentocompradetalleBE.Action = Business.Entity.BaseBE.EntityAction.UPDATE Then

                Dim docCompradetalle As documentocompradetalle = HeliosData.documentocompradetalle.Where(Function(o) _
                                         o.idDocumento = documentocompradetalleBE.idDocumento _
                                         And o.secuencia = documentocompradetalleBE.secuencia).First()


                docCompradetalle.idCosto = documentocompradetalleBE.idCosto
                docCompradetalle.idItem = documentocompradetalleBE.idItem
                docCompradetalle.ItemEntregadototal = documentocompradetalleBE.ItemEntregadototal
                docCompradetalle.descripcionItem = documentocompradetalleBE.descripcionItem
                docCompradetalle.tipoExistencia = documentocompradetalleBE.tipoExistencia
                docCompradetalle.destino = documentocompradetalleBE.destino
                docCompradetalle.unidad1 = documentocompradetalleBE.unidad1
                docCompradetalle.monto1 = documentocompradetalleBE.monto1
                docCompradetalle.unidad2 = documentocompradetalleBE.unidad2
                docCompradetalle.monto2 = documentocompradetalleBE.monto2
                docCompradetalle.precioUnitario = documentocompradetalleBE.precioUnitario
                docCompradetalle.precioUnitarioUS = documentocompradetalleBE.precioUnitarioUS
                docCompradetalle.importe = documentocompradetalleBE.importe
                docCompradetalle.importeUS = documentocompradetalleBE.importeUS
                docCompradetalle.montokardex = documentocompradetalleBE.montokardex
                docCompradetalle.montoIsc = documentocompradetalleBE.montoIsc
                docCompradetalle.montoIgv = documentocompradetalleBE.montoIgv
                docCompradetalle.otrosTributos = documentocompradetalleBE.otrosTributos
                docCompradetalle.montokardexUS = documentocompradetalleBE.montokardexUS
                docCompradetalle.montoIscUS = documentocompradetalleBE.montoIscUS
                docCompradetalle.montoIgvUS = documentocompradetalleBE.montoIgvUS
                docCompradetalle.otrosTributosUS = documentocompradetalleBE.otrosTributosUS
                docCompradetalle.preEvento = documentocompradetalleBE.preEvento
                docCompradetalle.bonificacion = documentocompradetalleBE.bonificacion
                docCompradetalle.almacenRef = documentocompradetalleBE.almacenRef
                docCompradetalle.usuarioModificacion = documentocompradetalleBE.usuarioModificacion
                docCompradetalle.fechaModificacion = documentocompradetalleBE.fechaModificacion
                docCompradetalle.percepcionMN = documentocompradetalleBE.percepcionMN
                docCompradetalle.percepcionME = documentocompradetalleBE.percepcionME
                docCompradetalle.fechaEntrega = documentocompradetalleBE.fechaEntrega


            ElseIf documentocompradetalleBE.Action = Business.Entity.BaseBE.EntityAction.INSERT Then
      


                OBJD = New documentocompradetalle
                OBJD.idCosto = documentocompradetalleBE.idCosto
                OBJD.tipoCosto = documentocompradetalleBE.tipoCosto

                '    objInventario = New HeliosDAL.InventarioMovimiento
                OBJD.idDocumento = documentocompradetalleBE.idDocumento ' Me.IdDocumento
                OBJD.idItem = documentocompradetalleBE.idItem
                OBJD.ItemEntregadototal = documentocompradetalleBE.ItemEntregadototal
                OBJD.descripcionItem = documentocompradetalleBE.descripcionItem
                OBJD.tipoExistencia = documentocompradetalleBE.tipoExistencia
                OBJD.destino = documentocompradetalleBE.destino
                OBJD.unidad1 = documentocompradetalleBE.unidad1
                OBJD.monto1 = documentocompradetalleBE.monto1
                OBJD.unidad2 = documentocompradetalleBE.unidad2
                OBJD.monto2 = documentocompradetalleBE.monto2
                OBJD.precioUnitario = documentocompradetalleBE.precioUnitario
                OBJD.precioUnitarioUS = documentocompradetalleBE.precioUnitarioUS
                OBJD.importe = documentocompradetalleBE.importe
                OBJD.importeUS = documentocompradetalleBE.importeUS
                OBJD.montokardex = documentocompradetalleBE.montokardex
                OBJD.montoIsc = documentocompradetalleBE.montoIsc
                OBJD.montoIgv = documentocompradetalleBE.montoIgv
                OBJD.otrosTributos = documentocompradetalleBE.otrosTributos
                '*********************************************************************
                OBJD.montokardexUS = documentocompradetalleBE.montokardexUS
                OBJD.montoIscUS = documentocompradetalleBE.montoIscUS
                OBJD.montoIgvUS = documentocompradetalleBE.montoIgvUS
                OBJD.otrosTributosUS = documentocompradetalleBE.otrosTributosUS
                If IsNothing(documentocompradetalleBE.preEvento) Then
                    OBJD.preEvento = Nothing
                Else
                    OBJD.preEvento = documentocompradetalleBE.preEvento
                End If
                OBJD.bonificacion = documentocompradetalleBE.bonificacion
                'OBJD.saldoMontoNota = documentocompradetalleBE.importe
                'OBJD.saldoMontoNotaUSD = documentocompradetalleBE.importeUS
                OBJD.almacenRef = documentocompradetalleBE.almacenRef
                '*********************************************************************
                OBJD.situacion = documentocompradetalleBE.situacion
                OBJD.usuarioModificacion = documentocompradetalleBE.usuarioModificacion
                OBJD.fechaModificacion = documentocompradetalleBE.fechaModificacion
                OBJD.percepcionMN = documentocompradetalleBE.percepcionMN
                OBJD.percepcionME = documentocompradetalleBE.percepcionME
                OBJD.fechaEntrega = documentocompradetalleBE.fechaEntrega

                HeliosData.documentocompradetalle.Add(OBJD)

            ElseIf documentocompradetalleBE.Action = Business.Entity.BaseBE.EntityAction.DELETE Then
                Dim consulta = (From n In HeliosData.documentocompradetalle _
                               Where n.secuencia = documentocompradetalleBE.secuencia).First

                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            End If
            HeliosData.SaveChanges()
            ts.Complete()
            If documentocompradetalleBE.Action = Business.Entity.BaseBE.EntityAction.UPDATE Then
                documentocompradetalleBE.secuencia = documentocompradetalleBE.secuencia
            ElseIf documentocompradetalleBE.Action = Business.Entity.BaseBE.EntityAction.INSERT Then
                documentocompradetalleBE.secuencia = OBJD.secuencia
            End If

        End Using
    End Sub

    Public Sub Delete(ByVal documentocompradetalleBE As documentocompradetalle)
        'Dim totales As New totalesAlmacenBL
        'Dim inventarioBL As New InventarioMovimientoBL

        'inventarioBL.DeleteInventarioPorDocumento(documentocompradetalleBE)
        'totales.DeleteTotalesAlmacen(listaTotales)
        DeleteSingle(documentocompradetalleBE)
        HeliosData.SaveChanges()
    End Sub

    Public Sub EliminarDetalleCompra(intIdDocumento As Integer)
        Dim totalesAlmacenBL As New totalesAlmacenBL
        Dim t As New totalesAlmacen
        Try
            Dim consulta = (From n In HeliosData.documentocompradetalle _
                           Where n.idDocumento = intIdDocumento).ToList

            Using ts As New TransactionScope
                For Each i In consulta

                    If i.tipoExistencia <> TipoRecurso.SERVICIO Then
                        If i.tipoExistencia <> "08" Then
                            t = New totalesAlmacen
                            t.idEmpresa = Gempresas.IdEmpresaRuc
                            t.idEstablecimiento = GEstableciento.IdEstablecimiento
                            t.idAlmacen = i.almacenRef  ' almacen de DESTINO
                            t.origenRecaudo = i.destino
                            t.idItem = i.idItem
                            t.descripcion = i.descripcionItem
                            t.tipoExistencia = i.tipoExistencia
                            t.tipoCambio = 0
                            t.idUnidad = i.unidad1
                            t.cantidad = i.monto1 * -1
                            t.importeSoles = i.montokardex * -1
                            t.importeDolares = i.montokardexUS * -1
                            t.usuarioActualizacion = i.usuarioModificacion
                            t.fechaActualizacion = i.fechaModificacion
                            totalesAlmacenBL.UpdateSingle2(t)
                        End If
                    End If

                    'CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(i)
                Next
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteSingle(ByVal documentocompradetalleBE As documentocompradetalle)
        Dim consulta As documentocompradetalle = HeliosData.documentocompradetalle.Where(Function(o) o.secuencia = documentocompradetalleBE.secuencia).First
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
        HeliosData.SaveChanges()
    End Sub

    Public Function GetListar_documentocompradetalle() As List(Of documentocompradetalle)
        Return (From a In HeliosData.documentocompradetalle Select a).ToList
    End Function

    Public Function GetUbicar_documentocompradetallePorID(Secuencia As Integer) As documentocompradetalle
        Return (From a In HeliosData.documentocompradetalle
                 Where a.secuencia = Secuencia Select a).First
    End Function

    Public Function GetUbicar_documentocompradetallePorCompra(intIdDocumento As Integer) As List(Of documentocompradetalle)
        Return (From a In HeliosData.documentocompradetalle
                Where a.idDocumento = intIdDocumento Select a).ToList
    End Function

    Public Function GetUbicarDetalleCompraLote(intIdDocumento As Integer) As List(Of documentocompradetalle)
        GetUbicarDetalleCompraLote = New List(Of documentocompradetalle)
        Dim consulta = (From a In HeliosData.documentocompradetalle
                        Join lote In HeliosData.recursoCostoLote
                            On lote.idDocumento Equals a.idDocumento And
                            lote.codigoProducto Equals a.idItem
                        Where a.idDocumento = intIdDocumento).ToList

        For Each i In consulta
            i.a.CustomRecursoCostoLote = New recursoCostoLote
            i.a.CustomRecursoCostoLote.codigoLote = i.lote.codigoLote
            i.a.CustomRecursoCostoLote.nroLote = i.lote.nroLote
            i.a.CustomRecursoCostoLote.fechaProduccion = i.lote.fechaProduccion.GetValueOrDefault
            i.a.CustomRecursoCostoLote.fechaVcto = i.lote.fechaVcto.GetValueOrDefault
            GetUbicarDetalleCompraLote.Add(i.a)
        Next

    End Function

    Public Function GeDetalleCompraItemLote(codigoLote As Integer) As documentocompradetalle

        Dim consulta = (From a In HeliosData.documentocompradetalle
                        Join lote In HeliosData.recursoCostoLote
                            On lote.codigoLote Equals a.codigoLote
                        Where a.codigoLote = codigoLote Select a).FirstOrDefault

        Return consulta
    End Function

    Public Function GetUbicar_documentocompradetallePorCompraEx(intIdDocumento As Integer) As List(Of documentocompradetalle)
        Return (From a In HeliosData.documentocompradetalle
                 Where a.idDocumento = intIdDocumento And a.tipoExistencia <> TipoRecurso.SERVICIO Select a).ToList
    End Function

    Public Function GetUbicar_documentocompradetallePorCompraSL(strSerie As String, strNroDoc As String, strSitucion As String) As List(Of documentocompradetalle)
        Return (From a In HeliosData.documentocompradetalle
                Join b In HeliosData.documentocompra
                On a.idDocumento Equals b.idDocumento
                 Where b.serie = strSerie And b.numeroDoc = strNroDoc _
                 And a.situacion = strSitucion Select a).ToList
    End Function

    Public Sub UpdateSingle2(ByVal objCompraDetalle As totalesAlmacen, ByVal intIdDocumento As Integer)
        Dim objNuevo As New totalesAlmacen
        Dim totalesCuenta As New documentocompradetalle
        Dim docuemntoCompraBL As New documentocompraBL

        'Dim consulta = (From c In HeliosData.documentocompradetalle _
        '                Join d In HeliosData.documentocompra _
        '                On c.idDocumento Equals d.idDocumento _
        '                        Where c.idDocumento = intIdDocumento _
        '                        And c.idItem = objCompraDetalle.idItem).FirstOrDefault

        totalesCuenta = HeliosData.documentocompradetalle.Where(Function(o) o.idDocumento = intIdDocumento And _
                                                          o.idItem = objCompraDetalle.idItem).FirstOrDefault

        If Not IsNothing(totalesCuenta) Then

            totalesCuenta.monto1 = CDec(totalesCuenta.monto1) - CDec(objCompraDetalle.cantidad)
            'totalesCuenta.importe = CDec(totalesCuenta.montokardex) - CDec(objCompraDetalle.importeSoles)
            totalesCuenta.precioUnitario = 0
            totalesCuenta.precioUnitarioUS = 0
            totalesCuenta.montokardex = CDec(totalesCuenta.montokardex) - CDec(objCompraDetalle.importeSoles)
            'totalesCuenta.montoIsc = CDec(objCompraDetalle.montoIsc).ToString
            'totalesCuenta.montoIgv = CDec(totalesCuenta.importe) - CDec(objCompraDetalle.importeSoles)
            totalesCuenta.montokardexUS = CDec(totalesCuenta.montokardexUS) - CDec(objCompraDetalle.importeDolares)
            'totalesCuenta.montoIscUS = CDec(objCompraDetalle.montoIscUS)
            'totalesCuenta.montoIgvUS = CDec(totalesCuenta.montoIgv) / CDec(docuemntoCompraBL.UbicarCompraPorIdDocumento(intIdDocumento).tcDolLoc)

        Else
            Throw New Exception("El comprobante no se encuentra, verifique su existencia!")
        End If
        'HeliosData.ObjectStateManager.GetObjectStateEntry(totalesCuenta).State.ToString()
        HeliosData.SaveChanges()
    End Sub

    Public Sub UpdateSingleDocCompraDetalle(ByVal intIdDocumento As Integer)
        Using ts As New TransactionScope
            Dim consulta = (From c In HeliosData.documentocompradetalle _
                                   Where c.idDocumento = intIdDocumento _
                                   Select c).ToList
            If Not IsNothing(consulta) Then
                For Each items In consulta
                    Select Case items.situacion
                        Case TIPO_SITUACION.ALMACEN_TRANSITO
                            DeleteSingle(items)
                        Case TIPO_SITUACION.ALMACEN_FISICO
                            items.situacion = TIPO_SITUACION.ALMACEN_FISICO_SOBRANTE
                    End Select
                    'HeliosData.ObjectStateManager.GetObjectStateEntry(items).State.ToString()
                Next
                HeliosData.SaveChanges()
                ts.Complete()
            Else
                Throw New Exception("El comprobante no se encuentra, verifique su existencia!")
            End If
        End Using
    End Sub

    Public Function GetUbicar_documentocompradetallePorItem(strNombreItem As String, strSitucion As String) As List(Of documentocompradetalle)
        Return (From a In HeliosData.documentocompradetalle
                Join b In HeliosData.documentocompra
                On a.idDocumento Equals b.idDocumento
                 Where a.descripcionItem = strNombreItem _
                 And a.situacion = strSitucion Select a).ToList
    End Function

    Public Function GetUbicar_documentocompradetallePorCompraNotificacion(strSerie As String, strNroDoc As String) As List(Of documentocompradetalle)
        Return (From a In HeliosData.documentocompradetalle
                Join b In HeliosData.documentocompra
                On a.idDocumento Equals b.idDocumento
                 Where b.serie = strSerie And b.numeroDoc = strNroDoc Select a).ToList
    End Function

    Public Sub UpdateSingle(ByVal idDocumento As Integer)
        Dim totalesCuenta As New documentocompradetalle

        Dim consulta = (From c In HeliosData.documento _
                                Where c.idDocumento = idDocumento _
                                Select c).FirstOrDefault

        If Not IsNothing(consulta) Then
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
        Else
            Throw New Exception("El comprobante no se encuentra, verifique su existencia!")
        End If

    End Sub

    Public Function UbicarDocumentoCompraDetalleSituacion(intIdDocumento As Integer, strSituacion As String) As List(Of documentocompradetalle)
        Return (From a In HeliosData.documentocompradetalle
                 Where a.idDocumento = intIdDocumento).ToList
    End Function

    Public Sub UpdateSingleDocCompraDetalleSL(ByVal intIdDocumento As Integer, ByVal intIdItem As Integer)
        Using ts As New TransactionScope
            Dim consulta = (From c In HeliosData.documentocompradetalle _
                                   Where c.idDocumento = intIdDocumento _
                                   And c.idItem = intIdItem _
                                   Select c).FirstOrDefault
            If Not IsNothing(consulta) Then
                consulta.situacion = TIPO_SITUACION.ALMACEN_FISICO
                'HeliosData.ObjectStateManager.GetObjectStateEntry(consulta).State.ToString()
                HeliosData.SaveChanges()
                ts.Complete()
            Else
                Throw New Exception("El comprobante no se encuentra, verifique su existencia!")
            End If
        End Using
    End Sub

    Public Function GetUbicar_proveedorPorIdItem(stridEmpresa As String, intIdEstablec As Integer, intIdItem As Integer) As List(Of documentocompradetalle)
        Dim lista As New List(Of String)
        Dim c As New documentocompradetalle
        Dim listaCompra As New List(Of documentocompradetalle)
        lista.Add(TIPO_SITUACION.ALMACEN_FISICO)

        Dim consulta = (From n In HeliosData.documentocompradetalle
                Join b In HeliosData.documentocompra
                On n.idDocumento Equals b.idDocumento
                 Join entidad In HeliosData.entidad _
                 On b.idProveedor Equals entidad.idEntidad _
                 Join prod In HeliosData.tabladetalle _
                 On n.tipoExistencia Equals prod.codigoDetalle
                 Where b.idEmpresa = stridEmpresa _
                 And b.idCentroCosto = intIdEstablec _
                 And n.idItem = intIdItem _
                 And lista.Contains(n.situacion) _
                 And prod.idtabla = 5).ToList

        For Each i In consulta
            c = New documentocompradetalle
            c.idDocumento = i.n.idDocumento
            c.FechaDoc = i.n.FechaDoc
            c.tipoExistencia = i.prod.descripcion
            c.idItem = i.n.idItem
            c.descripcionItem = i.n.descripcionItem
            c.monto1 = i.n.monto1
            c.precioUnitario = i.n.precioUnitario
            c.precioUnitarioUS = i.n.precioUnitarioUS
            c.bonificacion = i.n.bonificacion
            c.importe = i.n.importe
            c.importeUS = i.n.importeUS
            c.NombreProveedor = i.entidad.nombreCompleto
            c.idPadreDTCompra = i.entidad.idEntidad
            listaCompra.Add(c)
        Next
        Return listaCompra

    End Function

    Public Function GetUbicar_OrdenCompraHistorial(idDocumento As Integer, situacion As String) As List(Of documentocompradetalle)
        Dim c As New documentocompradetalle
        Dim listaCompra As New List(Of documentocompradetalle)
        Dim lista As New List(Of String)
        lista.Add(TIPO_COMPRA.ORDEN_COMPRA)
        lista.Add(TIPO_COMPRA.ORDEN_APROBADO)

        Dim consulta = (From n In HeliosData.documentocompradetalle
                Join b In HeliosData.documentocompra
                On n.idDocumento Equals b.idDocumento
                 Where b.idEmpresa = Gempresas.IdEmpresaRuc _
                 And b.idCentroCosto = GEstableciento.IdEstablecimiento _
                 And n.idDocumento = idDocumento _
                 And lista.Contains(n.situacion)).ToList




        For Each i In consulta

            Dim sumatoriaCant = (From p In HeliosData.documentoOtrosDatos _
                        Where p.idReferencia = i.n.secuencia Select p.cantidad).Sum

            c = New documentocompradetalle
            c.idDocumento = i.n.idDocumento
            c.secuencia = i.n.secuencia
            c.descripcionItem = i.n.descripcionItem
            c.monto2 = i.n.monto2
            c.monto1 = i.n.monto1
            c.idItem = i.n.idItem
            c.precioUnitario = i.n.precioUnitario
            c.precioUnitarioUS = i.n.precioUnitarioUS
            c.importe = i.n.importe
            c.importeUS = i.n.importeUS
            c.cantidadCredito = sumatoriaCant.GetValueOrDefault
            listaCompra.Add(c)

        Next
        Return listaCompra

    End Function

    Public Sub UpdateFullDocOrden(ByVal idDocumento As Integer, ByVal strSituacion As String)
        Using ts As New TransactionScope
            Dim consulta = (From c In HeliosData.documentocompradetalle _
                                   Where c.secuencia = idDocumento _
                                   Select c).First

            If Not IsNothing(consulta) Then
                'For Each i In consulta
                consulta.situacion = strSituacion
                HeliosData.SaveChanges()
                'Next

                ts.Complete()
            Else
                Throw New Exception("El comprobante no se encuentra, verifique su existencia!")
            End If
        End Using
    End Sub

    Public Sub UpdateSingleDocOrden(ByVal documentoCompraDeatlle As documentocompradetalle)
        Using ts As New TransactionScope
            Dim consulta = (From c In HeliosData.documentocompradetalle _
                                   Where c.secuencia = documentoCompraDeatlle.secuencia _
                                   Select c).First

            If Not IsNothing(consulta) Then

                consulta.situacion = documentoCompraDeatlle.situacion
                'CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
                HeliosData.SaveChanges()
                ts.Complete()
            Else
                Throw New Exception("El comprobante no se encuentra, verifique su existencia!")
            End If
        End Using
    End Sub

    Public Function InsertSingleOrden(documentocompradetalle As documentocompradetalle, intIdDocumento As Integer) As Integer
        Dim OBJD As New documentocompradetalle
        Dim compraOtros As New documentoOtrosDatosBL
        Using ts As New TransactionScope

            OBJD = New documentocompradetalle
            '    objInventario = New HeliosDAL.InventarioMovimiento
            OBJD.idDocumento = intIdDocumento ' Me.IdDocumento
            OBJD.idItem = documentocompradetalle.idItem
            OBJD.descripcionItem = documentocompradetalle.descripcionItem
            OBJD.tipoExistencia = documentocompradetalle.tipoExistencia
            OBJD.destino = documentocompradetalle.destino
            OBJD.unidad1 = documentocompradetalle.unidad1
            OBJD.monto1 = documentocompradetalle.monto1
            OBJD.unidad2 = documentocompradetalle.unidad2
            OBJD.monto2 = documentocompradetalle.monto2
            OBJD.precioUnitario = documentocompradetalle.precioUnitario
            OBJD.precioUnitarioUS = documentocompradetalle.precioUnitarioUS
            OBJD.importe = documentocompradetalle.importe
            OBJD.importeUS = documentocompradetalle.importeUS
            OBJD.montokardex = documentocompradetalle.montokardex
            OBJD.montoIsc = documentocompradetalle.montoIsc
            OBJD.montoIgv = documentocompradetalle.montoIgv
            OBJD.otrosTributos = documentocompradetalle.otrosTributos
            '*********************************************************************
            OBJD.montokardexUS = documentocompradetalle.montokardexUS
            OBJD.montoIscUS = documentocompradetalle.montoIscUS
            OBJD.montoIgvUS = documentocompradetalle.montoIgvUS
            OBJD.otrosTributosUS = documentocompradetalle.otrosTributosUS
            If IsNothing(documentocompradetalle.preEvento) Then
                OBJD.preEvento = Nothing
            Else
                OBJD.preEvento = documentocompradetalle.preEvento
            End If
            OBJD.bonificacion = documentocompradetalle.bonificacion
            OBJD.notaCreditoMN = documentocompradetalle.notaCreditoMN
            OBJD.notaCreditoME = documentocompradetalle.notaCreditoME
            'OBJD.monto = documentocompradetalle.importe
            'OBJD.saldoMontoNotaUSD = documentocompradetalle.importeUS
            OBJD.almacenRef = documentocompradetalle.almacenRef
            OBJD.idPadreDTCompra = documentocompradetalle.idPadreDTCompra

            OBJD.entregable = documentocompradetalle.entregable
            OBJD.fechaEntrega = documentocompradetalle.fechaEntrega
            '*********************************************************************
            OBJD.situacion = documentocompradetalle.situacion
            OBJD.porcUtimenor = documentocompradetalle.porcUtimenor
            OBJD.porcUtimayor = documentocompradetalle.porcUtimayor
            OBJD.porcUtigranMayor = documentocompradetalle.porcUtigranMayor
            OBJD.usuarioModificacion = documentocompradetalle.usuarioModificacion
            OBJD.fechaModificacion = documentocompradetalle.fechaModificacion
            HeliosData.documentocompradetalle.Add(OBJD)
            HeliosData.SaveChanges()
            ts.Complete()
            Return OBJD.secuencia

        End Using
    End Function

    Public Sub InsertSingleCambioInventario(documentocompradetalle As documentocompradetalle, intIdDocumento As Integer, intIdItem As Integer)
        Dim OBJD As New documentocompradetalle
        Using ts As New TransactionScope

            OBJD = New documentocompradetalle
            '    objInventario = New HeliosDAL.InventarioMovimiento
            OBJD.idDocumento = intIdDocumento ' Me.IdDocumento
            OBJD.idItem = intIdItem
            OBJD.descripcionItem = documentocompradetalle.descripcionItem
            OBJD.tipoExistencia = documentocompradetalle.tipoExistencia
            OBJD.destino = documentocompradetalle.destino
            OBJD.unidad1 = documentocompradetalle.unidad1
            OBJD.monto1 = documentocompradetalle.monto1
            OBJD.unidad2 = documentocompradetalle.unidad2
            OBJD.monto2 = documentocompradetalle.monto2
            OBJD.precioUnitario = documentocompradetalle.precioUnitario
            OBJD.precioUnitarioUS = documentocompradetalle.precioUnitarioUS
            OBJD.importe = documentocompradetalle.importe
            OBJD.importeUS = documentocompradetalle.importeUS
            OBJD.montokardex = documentocompradetalle.montokardex
            OBJD.montoIsc = documentocompradetalle.montoIsc
            OBJD.montoIgv = documentocompradetalle.montoIgv
            OBJD.otrosTributos = documentocompradetalle.otrosTributos
            '*********************************************************************
            OBJD.montokardexUS = documentocompradetalle.montokardexUS
            OBJD.montoIscUS = documentocompradetalle.montoIscUS
            OBJD.montoIgvUS = documentocompradetalle.montoIgvUS
            OBJD.otrosTributosUS = documentocompradetalle.otrosTributosUS
            If IsNothing(documentocompradetalle.preEvento) Then
                OBJD.preEvento = Nothing
            Else
                OBJD.preEvento = documentocompradetalle.preEvento
            End If
            OBJD.bonificacion = documentocompradetalle.bonificacion
            'OBJD.monto = documentocompradetalle.importe
            'OBJD.saldoMontoNotaUSD = documentocompradetalle.importeUS
            OBJD.almacenRef = documentocompradetalle.almacenRef
            OBJD.almacenDestino = documentocompradetalle.almacenDestino
            OBJD.idPadreDTCompra = documentocompradetalle.idPadreDTCompra
            '*********************************************************************
            OBJD.usuarioModificacion = documentocompradetalle.usuarioModificacion
            OBJD.fechaModificacion = documentocompradetalle.fechaModificacion
            HeliosData.documentocompradetalle.Add(OBJD)
            HeliosData.SaveChanges()
            ts.Complete()

        End Using
    End Sub



    Public Function GetUbicar_PorDocumento(intIdDocumento As Integer) As List(Of documentocompradetalle)
        Dim lista As New List(Of String)
        Dim c As New documentocompradetalle
        Dim listaCompra As New List(Of documentocompradetalle)


        Dim consulta = (From n In HeliosData.documentocompradetalle
                        Join b In HeliosData.documentocompra
                On n.idDocumento Equals b.idDocumento
                        Where n.idDocumento = intIdDocumento).ToList

        For Each i In consulta
            c = New documentocompradetalle
            c.idDocumento = i.n.idDocumento
            c.FechaDoc = i.b.fechaDoc
            c.idItem = i.n.idItem
            c.descripcionItem = i.n.descripcionItem
            c.monto1 = i.n.monto1
            c.precioUnitario = i.n.precioUnitario
            c.precioUnitarioUS = i.n.precioUnitarioUS
            c.bonificacion = i.n.bonificacion
            c.importe = i.n.importe
            c.importeUS = i.n.importeUS
            c.destino = i.n.destino
            c.unidad1 = i.n.unidad1
            c.Serie = i.b.serie
            c.idEntidad = i.b.idProveedor.GetValueOrDefault
            c.NumDoc = i.b.numeroDoc
            c.tipoExistencia = i.n.tipoExistencia
            c.almacenDestino = i.n.almacenDestino
            c.almacenRef = i.n.almacenRef
            listaCompra.Add(c)

        Next
        Return listaCompra

    End Function

    Public Sub UpdateSingleUsuarioSistema(ByVal idDocumento As Integer, idusuario As String)
        Using ts As New TransactionScope
            Dim consulta = (From c In HeliosData.documentocompradetalle
                            Where c.idDocumento = idDocumento
                            Select c).ToList

            If Not IsNothing(consulta) Then

                For Each item In consulta
                    item.usuarioModificacion = idusuario
                Next


                'CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
                HeliosData.SaveChanges()
                ts.Complete()
            Else
                Throw New Exception("No existe registros!")
            End If
        End Using
    End Sub

    Function ListaTotalXCompraDetalleAll(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer) As List(Of documentocompradetalle)
        Dim lista As New List(Of documentocompradetalle)
        Dim docCompra As New documentocompradetalle

        Dim listaCompra As New List(Of String)
        listaCompra.Add(TIPO_COMPRA.COMPRA)
        listaCompra.Add(TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS)
        listaCompra.Add(TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO)
        listaCompra.Add(TIPO_COMPRA.OTRAS_ENTRADAS)
        listaCompra.Add(TIPO_COMPRA.OTRAS_SALIDAS)
        listaCompra.Add(TIPO_COMPRA.TRANSFERENCIA_ENTRE_ALMACEN)

        Using ts As New TransactionScope
            Select Case tipo
                Case "XTodo"
                    Dim consultaCaja = (From a In HeliosData.documentocompradetalle
                                        Group Join b In HeliosData.entidad On New With {.IdProveedor = CInt(a.documentocompra.idProveedor)} _
                                        Equals New With {.IdProveedor = b.idEntidad}
                                        Into e_join = Group
                                        From e In e_join.DefaultIfEmpty()
                                        Where
                                                  listaCompra.Contains(a.documentocompra.tipoCompra) And
                                                  a.documentocompra.idEmpresa = strEmpresa And
                                                  a.documentocompra.idCentroCosto = idEstablec And
                                                  a.documentocompra.fechaDoc.Value.Year = intAnio
                                        Select
                                            a.idDocumento,
                                            a.secuencia,
                                            a.idItem,
                                            a.descripcionItem,
                                            a.tipoExistencia,
                                            a.destino,
                                            a.unidad1,
                                            a.monto1,
                                            a.unidad2,
                                            a.precioUnitario,
                                            a.precioUnitarioUS,
                                            a.importe,
                                            a.importeUS,
                                            a.montokardex,
                                            a.montokardexUS,
                                            a.almacenRef,
                                            a.almacenDestino,
                                            a.idPadreDTCompra,
                                            a.entregable,
                                            a.fechaEntrega,
                                            a.ItemEntregadototal,
                                            a.usuarioModificacion,
                                            a.fechaModificacion,
                                            a.documentocompra.tipoCompra,
                                            a.documentocompra.usuarioActualizacion,
                                            a.documentocompra.estadoEntrega,
                                            e.tipoPersona,
                                            e.nombreCompleto,
                                            a.documentocompra.fechaDoc,
                                            a.documentocompra.numeroDoc,
                                            a.documentocompra.serie,
                                            a.documentocompra.tipoDoc).ToList

                    For Each documentocompraBE In consultaCaja
                        docCompra = New documentocompradetalle
                        docCompra.idDocumento = documentocompraBE.idDocumento
                        docCompra.secuencia = documentocompraBE.secuencia
                        docCompra.idItem = documentocompraBE.idItem
                        docCompra.descripcionItem = documentocompraBE.descripcionItem
                        docCompra.tipoExistencia = documentocompraBE.tipoExistencia
                        docCompra.destino = documentocompraBE.destino
                        docCompra.unidad1 = documentocompraBE.unidad1
                        docCompra.monto1 = documentocompraBE.monto1
                        docCompra.unidad2 = documentocompraBE.unidad2
                        docCompra.precioUnitario = documentocompraBE.precioUnitario
                        docCompra.precioUnitarioUS = documentocompraBE.precioUnitarioUS
                        docCompra.importe = documentocompraBE.importe
                        docCompra.importeUS = documentocompraBE.importeUS
                        docCompra.montokardex = documentocompraBE.montokardex
                        docCompra.montokardexUS = documentocompraBE.montokardexUS
                        docCompra.almacenRef = documentocompraBE.almacenRef
                        docCompra.almacenDestino = documentocompraBE.almacenDestino
                        docCompra.idPadreDTCompra = documentocompraBE.idPadreDTCompra
                        docCompra.entregable = documentocompraBE.entregable
                        docCompra.fechaEntrega = documentocompraBE.fechaEntrega
                        docCompra.ItemEntregadototal = documentocompraBE.ItemEntregadototal
                        docCompra.usuarioModificacion = documentocompraBE.usuarioModificacion
                        docCompra.fechaModificacion = documentocompraBE.fechaModificacion
                        docCompra.tipoCompra = documentocompraBE.tipoCompra
                        docCompra.usuarioCaja = documentocompraBE.usuarioActualizacion
                        docCompra.estadoPago = documentocompraBE.estadoEntrega
                        docCompra.TipoRegistro = documentocompraBE.tipoPersona
                        docCompra.NombreProveedor = documentocompraBE.nombreCompleto
                        docCompra.FechaDoc = documentocompraBE.fechaDoc
                        docCompra.NumDoc = documentocompraBE.numeroDoc
                        docCompra.Serie = documentocompraBE.serie
                        docCompra.TipoDoc = documentocompraBE.tipoDoc
                        lista.Add(docCompra)
                    Next
                Case "XDia"

                    Dim consultaCaja = (From a In HeliosData.documentocompradetalle
                                        Join b In HeliosData.entidad
                                        On a.documentocompra.idProveedor Equals b.idEntidad
                                        Where
                                              CStr(a.documentocompra.fechaDoc) >= CDate(fechaInicio) And
                                               CStr(a.documentocompra.fechaDoc) <= CDate(fechaFin) And
                                                          listaCompra.Contains(a.documentocompra.tipoCompra) And
                                                  a.documentocompra.idEmpresa = strEmpresa And
                                                  a.documentocompra.idCentroCosto = idEstablec
                                        Select
                                            a.idDocumento,
                                            a.secuencia,
                                            a.idItem,
                                            a.descripcionItem,
                                            a.tipoExistencia,
                                            a.destino,
                                            a.unidad1,
                                            a.monto1,
                                            a.unidad2,
                                            a.precioUnitario,
                                            a.precioUnitarioUS,
                                            a.importe,
                                            a.importeUS,
                                            a.montokardex,
                                            a.montokardexUS,
                                            a.almacenRef,
                                            a.almacenDestino,
                                            a.idPadreDTCompra,
                                            a.entregable,
                                            a.fechaEntrega,
                                            a.ItemEntregadototal,
                                            a.usuarioModificacion,
                                            a.fechaModificacion,
                                             a.documentocompra.tipoCompra,
                                        a.documentocompra.usuarioActualizacion,
                                            a.documentocompra.estadoEntrega,
                                            b.tipoPersona,
                                            b.nombreCompleto,
                                             a.documentocompra.fechaDoc,
                                            a.documentocompra.numeroDoc,
                                            a.documentocompra.serie,
                                            a.documentocompra.tipoDoc).ToList

                    For Each documentocompraBE In consultaCaja
                        docCompra = New documentocompradetalle
                        docCompra.idDocumento = documentocompraBE.idDocumento
                        docCompra.secuencia = documentocompraBE.secuencia
                        docCompra.idItem = documentocompraBE.idItem
                        docCompra.descripcionItem = documentocompraBE.descripcionItem
                        docCompra.tipoExistencia = documentocompraBE.tipoExistencia
                        docCompra.destino = documentocompraBE.destino
                        docCompra.unidad1 = documentocompraBE.unidad1
                        docCompra.monto1 = documentocompraBE.monto1
                        docCompra.unidad2 = documentocompraBE.unidad2
                        docCompra.precioUnitario = documentocompraBE.precioUnitario
                        docCompra.precioUnitarioUS = documentocompraBE.precioUnitarioUS
                        docCompra.importe = documentocompraBE.importe
                        docCompra.importeUS = documentocompraBE.importeUS
                        docCompra.montokardex = documentocompraBE.montokardex
                        docCompra.montokardexUS = documentocompraBE.montokardexUS
                        docCompra.almacenRef = documentocompraBE.almacenRef
                        docCompra.almacenDestino = documentocompraBE.almacenDestino
                        docCompra.idPadreDTCompra = documentocompraBE.idPadreDTCompra
                        docCompra.entregable = documentocompraBE.entregable
                        docCompra.fechaEntrega = documentocompraBE.fechaEntrega
                        docCompra.ItemEntregadototal = documentocompraBE.ItemEntregadototal
                        docCompra.usuarioModificacion = documentocompraBE.usuarioModificacion
                        docCompra.fechaModificacion = documentocompraBE.fechaModificacion
                        docCompra.tipoCompra = documentocompraBE.tipoCompra
                        docCompra.usuarioCaja = documentocompraBE.usuarioActualizacion
                        docCompra.estadoPago = documentocompraBE.estadoEntrega
                        docCompra.TipoRegistro = documentocompraBE.tipoPersona
                        docCompra.NombreProveedor = documentocompraBE.nombreCompleto
                        docCompra.FechaDoc = documentocompraBE.fechaDoc
                        docCompra.NumDoc = documentocompraBE.numeroDoc
                        docCompra.Serie = documentocompraBE.serie
                        docCompra.TipoDoc = documentocompraBE.tipoDoc
                        lista.Add(docCompra)

                    Next
                Case "XPeriodo"

                    Dim consultaCaja = (From a In HeliosData.documentocompradetalle
                                Group Join b In HeliosData.entidad On New With {.IdProveedor = CInt(a.documentocompra.idProveedor)} _
                                Equals New With {.IdProveedor = b.idEntidad}
                                Into e_join = Group
                                From e In e_join.DefaultIfEmpty()
                                Where
                                          listaCompra.Contains(a.documentocompra.tipoCompra) And
                                          a.documentocompra.idEmpresa = strEmpresa And
                                          a.documentocompra.idCentroCosto = idEstablec And _
                                           a.documentocompra.fechaContable = periodo
                                Select
                                    a.idDocumento,
                                    a.secuencia,
                                    a.idItem,
                                    a.descripcionItem,
                                    a.tipoExistencia,
                                    a.destino,
                                    a.unidad1,
                                    a.monto1,
                                    a.unidad2,
                                    a.precioUnitario,
                                    a.precioUnitarioUS,
                                    a.importe,
                                    a.importeUS,
                                    a.montokardex,
                                    a.montokardexUS,
                                    a.almacenRef,
                                    a.almacenDestino,
                                    a.idPadreDTCompra,
                                    a.entregable,
                                    a.fechaEntrega,
                                    a.ItemEntregadototal,
                                    a.usuarioModificacion,
                                    a.fechaModificacion,
                                    a.documentocompra.tipoCompra,
                                    a.documentocompra.usuarioActualizacion,
                                    a.documentocompra.estadoEntrega,
                                    e.tipoPersona,
                                    e.nombreCompleto,
                                    a.documentocompra.fechaDoc,
                                    a.documentocompra.numeroDoc,
                                    a.documentocompra.serie,
                                    a.documentocompra.tipoDoc).ToList

                    For Each documentocompraBE In consultaCaja
                        docCompra = New documentocompradetalle
                        docCompra.idDocumento = documentocompraBE.idDocumento
                        docCompra.secuencia = documentocompraBE.secuencia
                        docCompra.idItem = documentocompraBE.idItem
                        docCompra.descripcionItem = documentocompraBE.descripcionItem
                        docCompra.tipoExistencia = documentocompraBE.tipoExistencia
                        docCompra.destino = documentocompraBE.destino
                        docCompra.unidad1 = documentocompraBE.unidad1
                        docCompra.monto1 = documentocompraBE.monto1
                        docCompra.unidad2 = documentocompraBE.unidad2
                        docCompra.precioUnitario = documentocompraBE.precioUnitario
                        docCompra.precioUnitarioUS = documentocompraBE.precioUnitarioUS
                        docCompra.importe = documentocompraBE.importe
                        docCompra.importeUS = documentocompraBE.importeUS
                        docCompra.montokardex = documentocompraBE.montokardex
                        docCompra.montokardexUS = documentocompraBE.montokardexUS
                        docCompra.almacenRef = documentocompraBE.almacenRef
                        docCompra.almacenDestino = documentocompraBE.almacenDestino
                        docCompra.idPadreDTCompra = documentocompraBE.idPadreDTCompra
                        docCompra.entregable = documentocompraBE.entregable
                        docCompra.fechaEntrega = documentocompraBE.fechaEntrega
                        docCompra.ItemEntregadototal = documentocompraBE.ItemEntregadototal
                        docCompra.usuarioModificacion = documentocompraBE.usuarioModificacion
                        docCompra.fechaModificacion = documentocompraBE.fechaModificacion
                        docCompra.tipoCompra = documentocompraBE.tipoCompra
                        docCompra.usuarioCaja = documentocompraBE.usuarioActualizacion
                        docCompra.estadoPago = documentocompraBE.estadoEntrega
                        docCompra.TipoRegistro = documentocompraBE.tipoPersona
                        docCompra.NombreProveedor = documentocompraBE.nombreCompleto
                        docCompra.FechaDoc = documentocompraBE.fechaDoc
                        docCompra.NumDoc = documentocompraBE.numeroDoc
                        docCompra.Serie = documentocompraBE.serie
                        docCompra.TipoDoc = documentocompraBE.tipoDoc
                        lista.Add(docCompra)
                    Next

            End Select

            Return lista

            'HeliosData.SaveChanges()
            'ts.Complete()
        End Using
    End Function

    Public Function ListaComprasPorveedorOrArticulo(strEmpresa As String, intIdEstable As Integer, fecInic As DateTime, fecHasta As DateTime, idProv As Integer, tipo As String, nombreitem As String) As List(Of documentocompradetalle)
        Dim obj As New documentocompradetalle
        Dim lista As New List(Of documentocompradetalle)

        Dim listaCompra As New List(Of String)
        listaCompra.Add(TIPO_COMPRA.COMPRA)
        listaCompra.Add(TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO)
        'listaCompra.Add(TIPO_COMPRA.COMPRA_ANTICIPADA)
        listaCompra.Add(TIPO_COMPRA.COMPRA_ANTICIPADA_OTORGADO)
        listaCompra.Add(TIPO_COMPRA.COMPRA_ANTICIPADA_RECIBIDA)
        listaCompra.Add(TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS)



        Select Case tipo
            Case "PR"
                If idProv = -1 Then ' TODOS LOS PROVEEDORES
                    Dim consulta = (From n In HeliosData.documentocompra
                                    Join c1 In HeliosData.documentocompradetalle
                               On n.idDocumento Equals c1.idDocumento
                                    Join p In HeliosData.detalleitems
                               On c1.idItem Equals p.codigodetalle
                                    Join e In HeliosData.entidad
                              On n.idProveedor Equals e.idEntidad
                                    Where n.idEmpresa = strEmpresa And
                              n.idCentroCosto = intIdEstable _
                              And n.fechaDoc >= fecInic And n.fechaDoc <= fecHasta _
                              And listaCompra.Contains(n.tipoCompra)).ToList


                    For Each i In consulta
                        obj = New documentocompradetalle
                        obj.TipoDoc = i.n.tipoDoc
                        obj.Serie = i.n.serie
                        obj.NumDoc = i.n.numeroDoc
                        obj.FechaDoc = i.n.fechaDoc
                        obj.NombreProveedor = i.e.nombreCompleto
                        obj.descripcionItem = i.p.descripcionItem
                        obj.monto1 = i.c1.monto1
                        obj.precioUnitario = i.c1.precioUnitario
                        obj.montokardex = i.c1.montokardex
                        obj.montoIgv = i.c1.montoIgv
                        obj.importe = i.c1.importe
                        lista.Add(obj)
                    Next

                Else ' POR PROVEEDOR
                    Dim consulta = (From n In HeliosData.documentocompra
                                    Join c1 In HeliosData.documentocompradetalle
                               On n.idDocumento Equals c1.idDocumento
                                    Join p In HeliosData.detalleitems
                               On c1.idItem Equals p.codigodetalle
                                    Join e In HeliosData.entidad
                              On n.idProveedor Equals e.idEntidad
                                    Where n.idEmpresa = strEmpresa And
                              n.idCentroCosto = intIdEstable _
                              And n.idProveedor = idProv _
                              And n.fechaDoc >= fecInic And n.fechaDoc <= fecHasta _
                              And listaCompra.Contains(n.tipoCompra)).ToList


                    For Each i In consulta
                        obj = New documentocompradetalle
                        obj.TipoDoc = i.n.tipoDoc
                        obj.Serie = i.n.serie
                        obj.NumDoc = i.n.numeroDoc
                        obj.FechaDoc = i.n.fechaDoc
                        obj.NombreProveedor = i.e.nombreCompleto
                        obj.descripcionItem = i.p.descripcionItem
                        obj.monto1 = i.c1.monto1
                        obj.precioUnitario = i.c1.precioUnitario
                        obj.montokardex = i.c1.montokardex
                        obj.montoIgv = i.c1.montoIgv
                        obj.importe = i.c1.importe
                        lista.Add(obj)
                    Next
                End If
            Case "ART"
                Dim consulta = (From n In HeliosData.documentocompra
                                Join c1 In HeliosData.documentocompradetalle
                              On n.idDocumento Equals c1.idDocumento
                                Join p In HeliosData.detalleitems
                              On c1.idItem Equals p.codigodetalle
                                Join e In HeliosData.entidad
                             On n.idProveedor Equals e.idEntidad
                                Where n.idEmpresa = strEmpresa And
                              n.idCentroCosto = intIdEstable _
                              And c1.descripcionItem.StartsWith(nombreitem) _
                             And n.fechaDoc >= fecInic And n.fechaDoc <= fecHasta And listaCompra.Contains(n.tipoCompra)).ToList


                For Each i In consulta
                    obj = New documentocompradetalle
                    obj.TipoDoc = i.n.tipoDoc
                    obj.Serie = i.n.serie
                    obj.NumDoc = i.n.numeroDoc
                    obj.FechaDoc = i.n.fechaDoc
                    obj.NombreProveedor = i.e.nombreCompleto
                    obj.descripcionItem = i.p.descripcionItem
                    obj.monto1 = i.c1.monto1
                    obj.precioUnitario = i.c1.precioUnitario
                    obj.montokardex = i.c1.montokardex
                    obj.montoIgv = i.c1.montoIgv
                    obj.importe = i.c1.importe
                    lista.Add(obj)
                Next

            Case "PRART"
                Dim consulta = (From n In HeliosData.documentocompra
                                Join c1 In HeliosData.documentocompradetalle
                              On n.idDocumento Equals c1.idDocumento
                                Join p In HeliosData.detalleitems
                              On c1.idItem Equals p.codigodetalle
                                Join e In HeliosData.entidad
                             On n.idProveedor Equals e.idEntidad
                                Where n.idEmpresa = strEmpresa And
                              n.idCentroCosto = intIdEstable And
                              n.idProveedor = idProv _
                              And c1.descripcionItem.StartsWith(nombreitem) _
                             And n.fechaDoc >= fecInic And n.fechaDoc <= fecHasta And listaCompra.Contains(n.tipoCompra)).ToList


                For Each i In consulta
                    obj = New documentocompradetalle
                    obj.TipoDoc = i.n.tipoDoc
                    obj.Serie = i.n.serie
                    obj.NumDoc = i.n.numeroDoc
                    obj.FechaDoc = i.n.fechaDoc
                    obj.NombreProveedor = i.e.nombreCompleto
                    obj.descripcionItem = i.p.descripcionItem
                    obj.monto1 = i.c1.monto1
                    obj.precioUnitario = i.c1.precioUnitario
                    obj.montokardex = i.c1.montokardex
                    obj.montoIgv = i.c1.montoIgv
                    obj.importe = i.c1.importe
                    lista.Add(obj)
                Next
        End Select

        Return lista
    End Function

    Public Sub actualizarEstadoTransitoItem(be As documentocompradetalle)
        Dim item = HeliosData.documentocompradetalle.Where(Function(o) o.secuencia = be.secuencia).FirstOrDefault
        Using ts As New TransactionScope
            item.ItemEntregadototal = be.ItemEntregadototal
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    'Private Function ValidacionCierreMensual(be As documento) As Boolean
    '    ValidacionCierreMensual = True

    '    Dim inventario As New InventarioMovimientoBL
    '    Dim totalesBL As New totalesAlmacenBL
    '    Dim inventarioBL As New InventarioMovimientoBL
    '    Dim codDoc As Integer = 0
    '    Dim cierreinventarioBL As New cierreinventarioBL
    '    Dim empresaCierreMensualBL As New empresaCierreMensualBL


    '    Dim fechaActual = New Date(be.documentocompra.fechaDoc.Value.Year, be.documentocompra.fechaDoc.Value.Month, 1)
    '    Dim fechaAnterior = fechaActual.AddMonths(-1)

    '    'si es false es porque no esta dentro del inicio de operaciones
    '    Dim valor = empresaCierreMensualBL.GetValidaFechaInicioOperacion(be.idEmpresa, fechaActual)
    '    If valor = "False" Then
    '        If cierreinventarioBL.InventarioEstaCerradoV2(be.idEmpresa, fechaActual.Year, fechaActual.Month) Then
    '            ValidacionCierreMensual = False
    '            Throw New Exception("El período: " & MonthName(fechaActual.Month) & ", esta cerrado!")
    '        End If

    '        If empresaCierreMensualBL.EstadoMesCerrado(New empresaCierreMensual With
    '                                            {.idEmpresa = be.idEmpresa,
    '                                             .anio = fechaAnterior.Year,
    '                                             .mes = fechaAnterior.Month}) = False Then
    '            ValidacionCierreMensual = False
    '            Throw New Exception("Debe cerrar el período anterior: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
    '        End If
    '    ElseIf valor = "True" Then
    '        ValidacionCierreMensual = False
    '        Throw New Exception("No puede ingresar en un período anterior al inicio de operaciones")
    '    Else
    '        If cierreinventarioBL.InventarioEstaCerradoV2(be.idEmpresa, fechaActual.Year, fechaActual.Month) Then
    '            ValidacionCierreMensual = False
    '            Throw New Exception("El período: " & MonthName(fechaActual.Month) & ", esta cerrado!")
    '        End If

    '        'If empresaCierreMensualBL.EstadoMesCerrado(New empresaCierreMensual With
    '        '                                    {.idEmpresa = objDocumento.idEmpresa,
    '        '                                     .anio = fechaAnterior.Year,
    '        '                                     .mes = fechaAnterior.Month}) = False Then
    '        '    Throw New Exception("Debe cerrar el período anterior: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
    '        'End If
    '    End If
    'End Function

    Public Sub EnvioProductosEnTransitoRapido(listaEnvios As List(Of inventarioTransito))
        Using ts As New TransactionScope
            EnvioProductos(listaEnvios)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Private Sub RegistrarInventarioValorizado(i As inventarioTransito)
        Using ts As New TransactionScope
            Dim estado As Integer

            Dim totales = HeliosData.totalesAlmacen.Where(Function(o) _
                              o.idAlmacen = i.AlmacenEnvio AndAlso
                              o.codigoLote = i.CustomDetalleCompra.codigoLote AndAlso
                              o.idItem = i.CustomProducto.codigodetalle).SingleOrDefault
            If totales Is Nothing Then
                Select Case i.status
                    Case 2
                        estado = StatusArticulo.Inactivo
                    Case 3
                        estado = StatusArticulo.Activo
                End Select

                Dim nuevoTA As New totalesAlmacen With
                    {
                    .idEmpresa = i.CustomDetalleCompra.documentocompra.idEmpresa,
                    .idEstablecimiento = i.CustomDetalleCompra.documentocompra.idCentroCosto,
                    .codigoLote = i.CustomDetalleCompra.codigoLote,
                    .idAlmacen = i.AlmacenEnvio,
                    .origenRecaudo = i.CustomProducto.origenProducto,
                    .tipoExistencia = i.CustomProducto.tipoExistencia,
                    .idItem = i.CustomProducto.codigodetalle,
                    .descripcion = i.CustomProducto.descripcionItem,
                    .idUnidad = i.CustomProducto.unidad1,
                    .unidadMedida = i.CustomProducto.unidad1,
                    .cantidad = i.cantidad,
                    .importeSoles = i.monto,
                    .importeDolares = i.montoME,
                    .cantidadMaxima = 10000,
                    .cantidadMinima = 10,
                    .fechaVcto = Date.Now,
                    .status = estado
                }
                HeliosData.totalesAlmacen.Add(nuevoTA)
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Private Sub EnvioProductos(listaEnvios As List(Of inventarioTransito))
        Dim inventario As New InventarioMovimientoBL
        Dim totalesBL As New totalesAlmacenBL
        Using ts As New TransactionScope
            GetEnvio(listaEnvios)

            For Each i In listaEnvios

                Select Case i.status
                    Case 3
                        Dim listaArticulos = (From n In i.CustomListaInventario
                                              Select
                                                 n.idItem, n.tipoProducto, n.idAlmacen, n.nrolote).Distinct.ToList()

                        For Each a In listaArticulos
                            Dim lista = inventario.GetCuracionEntradasAlmacenByArticuloLote(
                                New InventarioMovimiento With {
                                .idAlmacen = a.idAlmacen,
                                .fecha = Date.Now,
                                .tipoProducto = a.tipoProducto,
                                .idItem = a.idItem, .nrolote = a.nrolote
                                }, Nothing)
                            totalesBL.GetCurarKardexCaberasLOTE(lista)
                        Next
                    Case 2

                End Select

            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Private Sub GetEnvio(listaEnvios As List(Of inventarioTransito))
        Using ts As New TransactionScope
            For Each i In listaEnvios
                Dim transito = HeliosData.inventarioTransito.Where(Function(o) o.idInventario = i.idInventario).SingleOrDefault


                'HeliosData.InventarioMovimiento.AddRange(i.CustomListaInventario)

                GetInsertInventario(i.CustomListaInventario)

                RegistrarInventarioValorizado(i)

                Dim SumaCantidades = HeliosData.InventarioMovimiento.Where(Function(o) o.idorigenDetalle = i.secuencia And o.idDocumento = i.idDocumentoCompra And o.idAlmacen <> 1).Sum(Function(o) o.cantidad).GetValueOrDefault
                Dim saldoactual = i.CustomDetalleCompra.monto1 - SumaCantidades

                If saldoactual <= 0 Then
                    transito.status = 0
                    transito.cantidad = 0
                    transito.monto = 0
                    transito.montoME = 0
                Else
                    Dim costoUnitario = i.monto / i.cantidad
                    Dim costoUnitarioME As Decimal = 0
                    If i.cantidad.GetValueOrDefault > 0 Then
                        costoUnitarioME = i.montoME / i.cantidad
                    Else
                        costoUnitarioME = 0
                    End If
                    transito.cantidad = saldoactual
                    transito.monto = saldoactual * costoUnitario
                    transito.montoME = costoUnitarioME
                End If

                Dim lotes = (From n In i.CustomListaInventario
                             Where n.tipoRegistro = "E"
                             Select n.nrolote, n.fecha).Distinct.ToList

                Select Case i.status
                    Case 2 ' EN CURSO

                    Case 3 ' ENTREGADO
                        ActualizarLotes(lotes)
                End Select

                If i.CustomDetalleCompra.inventarioTransito IsNot Nothing Then
                    If i.CustomDetalleCompra.inventarioTransito.Count > 0 Then
                        HeliosData.inventarioTransito.AddRange(i.CustomDetalleCompra.inventarioTransito)
                    End If
                End If
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Private Sub GetInsertInventario(i As List(Of InventarioMovimiento))
        Using ts As New TransactionScope
            HeliosData.InventarioMovimiento.AddRange(i)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Private Sub ActualizarLotes(Lista As Object)
        Using ts As New TransactionScope
            For Each i In Lista
                Dim codigoLote = Integer.Parse(i.nrolote)

                Dim obj = HeliosData.recursoCostoLote.Where(Function(o) o.codigoLote = codigoLote).Single
                obj.fechaentrada = DateTime.Parse(i.fecha)
                obj.fechaProduccion = DateTime.Parse(i.fecha)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub
End Class
