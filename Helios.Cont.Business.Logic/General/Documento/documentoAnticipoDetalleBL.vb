Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class documentoAnticipoDetalleBL
    Inherits BaseBL


    Public Sub InsertDevolucionDetalle(objDocumentoBE As documento, intDocCaja As Integer)
        Dim nDetalle As New documentoAnticipoDetalle
        Using ts As New TransactionScope
            For Each i In objDocumentoBE.documentoAnticipo.documentoAnticipoDetalle
                nDetalle = New documentoAnticipoDetalle
                nDetalle.idDocumento = intDocCaja
                nDetalle.documentoAfectado = i.documentoAfectado
                'nDetalle.secuencia = i.secuencia
                nDetalle.idEmpresa = Gempresas.IdEmpresaRuc
                nDetalle.idEstablecimiento = GEstableciento.IdEstablecimiento
                nDetalle.fecha = i.fecha
                nDetalle.idAnticipo = i.idAnticipo
                nDetalle.DetalleItem = i.DetalleItem
                nDetalle.importeMN = i.importeMN
                nDetalle.importeME = i.importeME
                nDetalle.montoUsdRef = i.montoUsdRef
                'nDetalle.montoItf = i.montoItf
                'nDetalle.montoItfusd = i.montoItfusd
                nDetalle.entregado = i.entregado
                nDetalle.diferTipoCambio = i.diferTipoCambio
                ' nDetalle.difME = i.difME
                ' nDetalle.difMN = i.difMN
                nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                nDetalle.usuarioModificacion = i.usuarioModificacion
                nDetalle.fechaActualizacion = i.fechaActualizacion
                nDetalle.estadoAnticipo = i.estadoAnticipo

                HeliosData.documentoAnticipoDetalle.Add(nDetalle)

            Next

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Function ListadoAnticiposDetalleHijos(intIdDocumento As Integer) As List(Of documentoAnticipoDetalle)
        Dim lista As New List(Of documentoAnticipoDetalle)
        Dim a As New documentoAnticipoDetalle

        Dim cc = (From c In HeliosData.documentoAnticipoDetalle
                  Where c.documentoAfectado = intIdDocumento).ToList


        For Each i In cc
            a = New documentoAnticipoDetalle
            a.idDocumento = i.idDocumento
            a.DetalleItem = i.DetalleItem
            a.importeMN = i.importeMN
            a.importeME = i.importeME

            lista.Add(a)
        Next

        Return lista
    End Function


    Public Sub InsertPagosConAnticipoME(objDocumentoBE As documento, intDocCaja As Integer)
        Dim saldoME As Decimal = 0
        Dim saldoMN As Decimal = 0
        Dim lista As New List(Of String)
        lista.Add("2")
        lista.Add("0")

        Dim saldoItem As Decimal = 0
        Dim saldoItemME As Decimal = 0
        Dim nDetalle As New documentoAnticipoDetalle
        Dim nDetTemp As New documentoAnticipoDetalle
        Dim objItemsaldo As New documentoCajaDetalle
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim listatemporal As New List(Of documentoAnticipoDetalle)

        Using ts As New TransactionScope
            For Each i In objDocumentoBE.documentoAnticipo.documentoAnticipoDetalle
                Dim NCventa = Aggregate det In HeliosData.documentocompradetalle
                            Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento
                            Where v.tipoDoc = "07" And det.idPadreDTCompra = i.documentoAfectadodetalle
                            Into NCmn = Sum(det.importe),
                                 NCme = Sum(det.importeUS)

                Dim NBventa = Aggregate det In HeliosData.documentocompradetalle
                             Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento
                             Where v.tipoDoc = "08" And det.idPadreDTCompra = i.documentoAfectadodetalle
                             Into NBmn = Sum(det.importe),
                                  NBme = Sum(det.importeUS)

                Dim Ajustes = Aggregate p In HeliosData.documentoLibroDiarioDetalle
                 Join compra In HeliosData.documentoLibroDiario
                 On p.idDocumento Equals compra.idDocumento
                            Where p.cuenta = i.documentoAfectadodetalle _
                            And compra.tipoRegistro = "AJU"
            Into AJmn = Sum(p.importeMN),
                 AJme = Sum(p.importeME)

                objItemsaldo = cajaDetalleBL.ObtenerCuentasPorPagarPorProducto(i.documentoAfectado, i.documentoAfectadodetalle)
                objitemsaldoant = cajaDetalleBL.ObtenerCuentasPorPagarAnticipoPorProducto(i.documentoAfectado, i.documentoAfectadodetalle)
                Dim VentaDetalle As documentocompradetalle = HeliosData.documentocompradetalle.Where(Function(o) o.secuencia = i.documentoAfectadodetalle).FirstOrDefault

                '//////////
                Dim montotemp As Decimal = CDec(0.0)
                Dim consultatemp = (From id In listatemporal
                                    Where id.documentoAfectadodetalle = i.documentoAfectadodetalle).ToList

                If consultatemp.Count > 0 Then

                    For Each x In consultatemp
                        montotemp += x.importeMN
                    Next

                Else
                    montotemp = CDec(0.0)
                End If
                '////////////
                saldoItem = objItemsaldo.MontoDeudaSoles - i.importeMN - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault - Ajustes.AJmn.GetValueOrDefault - objitemsaldoant.MontoPagadoSoles - montotemp
                saldoItemME = objItemsaldo.MontoDeudaUSD - i.importeME - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault - Ajustes.AJme.GetValueOrDefault - objitemsaldoant.MontoPagadoUSD - montotemp



                If saldoItem <= 0 Then
                    VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                Else
                    VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                End If

                ' If (i.TipoConfirmacion = "OEC" Or i.TipoConfirmacion = "AR" Or i.TipoConfirmacion = "DC") Then
                nDetalle = New documentoAnticipoDetalle
                nDetalle.idDocumento = intDocCaja
                nDetalle.documentoAfectado = i.documentoAfectado
                'nDetalle.secuencia = i.secuencia
                nDetalle.idEmpresa = Gempresas.IdEmpresaRuc
                nDetalle.idEstablecimiento = GEstableciento.IdEstablecimiento
                nDetalle.fecha = i.fecha
                nDetalle.idAnticipo = i.idAnticipo
                nDetalle.DetalleItem = i.DetalleItem
                nDetalle.importeMN = i.importeMN
                nDetalle.importeME = i.importeME
                nDetalle.montoUsdRef = i.montoUsdRef
                'nDetalle.montoItf = i.montoItf
                'nDetalle.montoItfusd = i.montoItfusd
                nDetalle.entregado = i.entregado
                nDetalle.diferTipoCambio = i.diferTipoCambio
                ' nDetalle.difME = i.difME
                ' nDetalle.difMN = i.difMN
                nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                nDetalle.usuarioModificacion = i.usuarioModificacion
                nDetalle.fechaActualizacion = i.fechaActualizacion
                nDetalle.estadoAnticipo = i.estadoAnticipo

                HeliosData.documentoAnticipoDetalle.Add(nDetalle)



                nDetTemp = New documentoAnticipoDetalle
                nDetTemp.documentoAfectadodetalle = i.documentoAfectadodetalle
                nDetTemp.importeMN = i.importeMN
                listatemporal.Add(nDetTemp)

                'ElseIf (i.TipoConfirmacion = "OSC" Or i.TipoConfirmacion = "AO" Or i.TipoConfirmacion = "PG" Or i.TipoConfirmacion = "AI") Then

                '    Dim consultaCaja = (From c In HeliosData.documentoCaja _
                '                        Join d In HeliosData.documentoCajaDetalle _
                '                        On c.idDocumento Equals d.idDocumento _
                '                Where c.tipoMovimiento = "DC" And _
                '                lista.Contains(d.estadoCaja) And _
                '                c.entidadFinanciera = intEntidadFinanciera).ToList

                '    For Each item In consultaCaja

                '        Select Case i.moneda
                '            Case 1
                '                saldoMN = i.montoSoles
                '                If (saldoMN <> 0) Then
                '                    nDetalle = New documentoCajaDetalle
                '                    nDetalle.idDocumento = intDocCaja
                '                    nDetalle.documentoAfectado = i.documentoAfectado
                '                    nDetalle.secuencia = i.secuencia
                '                    nDetalle.fecha = i.fecha
                '                    nDetalle.idItem = i.idItem
                '                    nDetalle.DetalleItem = i.DetalleItem
                '                    nDetalle.montoItf = i.montoItf
                '                    nDetalle.montoItfusd = i.montoItfusd
                '                    nDetalle.entregado = i.entregado
                '                    nDetalle.difME = i.difME
                '                    nDetalle.difMN = i.difMN
                '                    nDetalle.usuarioModificacion = i.usuarioModificacion
                '                    nDetalle.fechaModificacion = i.fechaModificacion
                '                    nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                '                    If (item.d.montoSolesRef >= i.montoSoles And i.montoSoles = 0) Then
                '                        nDetalle.montoSoles = i.montoSoles
                '                        nDetalle.montoSolesRef = i.montoSoles
                '                        nDetalle.montoUsd = i.montoUsd
                '                        nDetalle.montoUsdRef = i.montoUsd
                '                        nDetalle.estadoCaja = i.estadoCaja
                '                        saldoME = item.d.montoUsd - i.montoUsd
                '                        nDetalle.diferTipoCambio = i.diferTipoCambio
                '                        i.montoUsd = saldoME
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                    ElseIf (item.d.montoSolesRef <= i.montoSoles And i.montoSoles = 0) Then
                '                        nDetalle.montoSoles = i.montoSoles
                '                        nDetalle.montoSolesRef = i.montoSoles
                '                        nDetalle.montoUsd = i.montoUsd
                '                        nDetalle.montoUsdRef = i.montoUsd
                '                        nDetalle.diferTipoCambio = i.diferTipoCambio
                '                        nDetalle.estadoCaja = i.estadoCaja
                '                        saldoMN = item.d.montoSoles - i.montoSoles
                '                        i.montoSoles = saldoMN
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                    ElseIf (item.d.montoSolesRef < i.montoSoles And i.montoSoles > 0) Then
                '                        'nDetalle.montoSoles = Math.Round(CDec(item.d.montoUsdRef * i.diferTipoCambio), 2)
                '                        nDetalle.montoSoles = item.d.montoSolesRef
                '                        nDetalle.montoSolesRef = item.d.montoSolesRef
                '                        nDetalle.montoUsdRef = Math.Round(CDec(item.d.montoSolesRef / item.d.diferTipoCambio), 2)
                '                        nDetalle.montoUsd = Math.Round(CDec(item.d.montoSolesRef / item.d.diferTipoCambio), 2)
                '                        nDetalle.diferTipoCambio = i.diferTipoCambio
                '                        nDetalle.estadoCaja = "1"
                '                        UpdateEstadoCajaMN(item.d.idDocumento, "1", nDetalle.montoSoles)
                '                        saldoMN = item.d.montoSoles - i.montoSoles
                '                        i.montoSoles = saldoMN
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                    ElseIf (item.d.montoSolesRef > i.montoSoles And i.montoSoles > 0) Then

                '                        If (item.d.montoSoles > i.montoSoles) Then
                '                            nDetalle.montoSoles = i.montoSoles
                '                            nDetalle.montoSolesRef = i.montoSoles
                '                            nDetalle.montoUsd = Math.Round(CDec((i.montoSoles) / item.d.diferTipoCambio), 2)
                '                            nDetalle.montoUsdRef = Math.Round(CDec((i.montoSoles) / item.d.diferTipoCambio), 2)
                '                            nDetalle.diferTipoCambio = item.d.diferTipoCambio
                '                            nDetalle.estadoCaja = "1"
                '                            UpdateEstadoCajaMN(item.d.idDocumento, "2", i.montoSoles)
                '                            saldoMN = item.d.montoSoles - i.montoSoles
                '                            i.montoSoles = 0
                '                        Else
                '                            nDetalle.montoSoles = i.montoSoles
                '                            nDetalle.montoSolesRef = i.montoSoles
                '                            nDetalle.montoUsd = Math.Round(CDec((i.montoSoles * -1) / item.d.diferTipoCambio), 2)
                '                            nDetalle.montoUsdRef = Math.Round(CDec((i.montoSoles * -1) / item.d.diferTipoCambio), 2)
                '                            nDetalle.diferTipoCambio = item.d.diferTipoCambio
                '                            nDetalle.estadoCaja = "1"
                '                            UpdateEstadoCajaMN(item.d.idDocumento, "2", i.montoSoles)
                '                            saldoMN = item.d.montoSoles - i.montoSoles
                '                            i.montoSoles = saldoMN
                '                        End If

                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                    ElseIf (item.d.montoSolesRef > i.montoSoles And i.montoSoles < 0) Then
                '                        nDetalle.montoSoles = (CDec(i.montoSoles * -1))
                '                        nDetalle.montoSolesRef = (CDec(i.montoSoles * -1))
                '                        nDetalle.montoUsd = Math.Round(CDec((i.montoSoles * -1) / item.d.diferTipoCambio), 2)
                '                        nDetalle.montoUsdRef = Math.Round(CDec((i.montoSoles * -1) / item.d.diferTipoCambio), 2)
                '                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                '                        nDetalle.estadoCaja = "1"
                '                        UpdateEstadoCajaMN(item.d.idDocumento, "2", nDetalle.montoSoles)
                '                        saldoMN = item.d.montoSoles - i.montoSoles
                '                        i.montoSoles = saldoMN
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                    ElseIf (item.d.montoSolesRef = i.montoSoles And i.montoSoles > 0) Then
                '                        nDetalle.montoSoles = i.montoSoles
                '                        nDetalle.montoSolesRef = i.montoSoles
                '                        nDetalle.montoUsd = Math.Round(CDec(i.montoSoles / item.d.diferTipoCambio), 2)
                '                        nDetalle.montoUsdRef = Math.Round(CDec(i.montoSoles / item.d.diferTipoCambio), 2)
                '                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                '                        nDetalle.estadoCaja = "1"
                '                        UpdateEstadoCajaMN(item.d.idDocumento, "1", i.montoSoles)
                '                        saldoMN = item.d.montoSoles - i.montoSoles
                '                        i.montoSoles = saldoMN
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                    End If
                '                End If
                'Case 2
                'saldoME = i.montoUsd
                'If (saldoME > 0) Then
                '    nDetalle = New documentoCajaDetalle
                '    nDetalle.idDocumento = intDocCaja
                '    nDetalle.documentoAfectado = i.documentoAfectado
                '    nDetalle.secuencia = i.secuencia
                '    nDetalle.fecha = i.fecha
                '    nDetalle.idItem = i.idItem
                '    nDetalle.DetalleItem = i.DetalleItem
                '    nDetalle.montoItf = i.montoItf
                '    nDetalle.montoItfusd = i.montoItfusd
                '    nDetalle.entregado = i.entregado
                '    nDetalle.difME = i.difME
                '    nDetalle.difMN = i.difMN
                '    nDetalle.usuarioModificacion = i.usuarioModificacion
                '    nDetalle.fechaModificacion = i.fechaModificacion
                '    nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                '    If (item.d.montoUsdRef >= i.montoUsd And i.montoUsd = 0) Then
                '        nDetalle.montoSoles = i.montoSoles
                '        nDetalle.montoSolesRef = i.montoSoles
                '        nDetalle.montoUsd = i.montoUsd
                '        nDetalle.montoUsdRef = i.montoUsd
                '        nDetalle.estadoCaja = i.estadoCaja
                '        saldoME = item.d.montoUsd - i.montoUsd
                '        nDetalle.diferTipoCambio = i.diferTipoCambio
                '        i.montoUsd = saldoME
                '        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '    ElseIf (item.d.montoUsdRef <= i.montoUsd And i.montoUsd = 0) Then
                '        nDetalle.montoSoles = i.montoSoles
                '        nDetalle.montoSolesRef = i.montoSoles
                '        nDetalle.montoUsd = i.montoUsd
                '        nDetalle.montoUsdRef = i.montoUsd
                '        nDetalle.diferTipoCambio = i.diferTipoCambio
                '        nDetalle.estadoCaja = i.estadoCaja
                '        saldoME = item.d.montoUsd - i.montoUsd
                '        i.montoUsd = saldoME
                '        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '    ElseIf (item.d.montoUsdRef < i.montoUsd And i.montoUsd > 0) Then
                '        nDetalle.montoSoles = Math.Round(CDec(item.d.montoUsdRef * item.d.diferTipoCambio), 2)
                '        nDetalle.montoSolesRef = Math.Round(CDec(item.d.montoUsdRef * item.d.diferTipoCambio), 2)
                '        nDetalle.montoUsd = item.d.montoUsdRef
                '        nDetalle.montoUsdRef = item.d.montoUsdRef
                '        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                '        nDetalle.estadoCaja = "1"
                '        UpdateEstadoCaja(item.d.idDocumento, "1", item.d.montoUsdRef)
                '        saldoME = saldoME - nDetalle.montoUsd
                '        i.montoUsd = saldoME
                '        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '    ElseIf (item.d.montoUsdRef > i.montoUsd And i.montoUsd > 0) Then
                '        nDetalle.montoSoles = Math.Round(CDec(i.montoUsd * item.d.diferTipoCambio), 2)
                '        nDetalle.montoSolesRef = Math.Round(CDec(i.montoUsd * item.d.diferTipoCambio), 2)
                '        nDetalle.montoUsd = i.montoUsd
                '        nDetalle.montoUsdRef = i.montoUsd
                '        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                '        nDetalle.estadoCaja = "1"
                '        UpdateEstadoCaja(item.d.idDocumento, "2", i.montoUsd)
                '        saldoME = saldoME - i.montoUsd
                '        i.montoUsd = saldoME
                '        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '    ElseIf (item.d.montoUsdRef > i.montoUsd And i.montoUsd < 0) Then
                '        nDetalle.montoSoles = Math.Round(CDec((i.montoUsd * -1) * item.d.diferTipoCambio), 2)
                '        nDetalle.montoSolesRef = Math.Round(CDec((i.montoUsd * -1) * item.d.diferTipoCambio), 2)
                '        nDetalle.montoUsd = Math.Round(CDec(i.montoUsd * -1), 2)
                '        nDetalle.montoUsdRef = Math.Round(CDec(i.montoUsd * -1), 2)
                '        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                '        nDetalle.estadoCaja = "1"
                '        UpdateEstadoCaja(item.d.idDocumento, "2", i.montoUsd)
                '        saldoME = item.d.montoUsd - i.montoUsd
                '        i.montoUsd = saldoME
                '        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '    ElseIf (item.d.montoUsdRef = i.montoUsd And i.montoUsd > 0) Then
                '        nDetalle.montoSoles = Math.Round(CDec(i.montoUsd * item.d.diferTipoCambio), 2)
                '        nDetalle.montoSolesRef = Math.Round(CDec(i.montoUsd * item.d.diferTipoCambio), 2)
                '        nDetalle.montoUsd = i.montoUsd
                '        nDetalle.montoUsdRef = i.montoUsd
                '        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                '        nDetalle.estadoCaja = i.estadoCaja
                '        nDetalle.estadoCaja = "1"
                '        UpdateEstadoCaja(item.d.idDocumento, "1", i.montoUsd)
                '        saldoME = saldoME - i.montoUsd
                '        i.montoUsd = saldoME
                '        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '    End If
                'End If
                'End Select

            Next
            ' End If
            'Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function ObtenerPagosAnticipoPorDocumento(strDocumentoAfectado As Integer) As documentoAnticipoDetalle
        Dim objItem As New documentoAnticipoDetalle
        Dim pagoSoles As Decimal = CDec(0.0)
        Dim pagoDolares As Decimal = CDec(0.0)
        Dim obj = (From p In HeliosData.documentoAnticipoDetalle
                   Where p.documentoAfectado = strDocumentoAfectado
                        ).ToList

        For Each i In obj
            pagoSoles += i.importeMN
            pagoDolares += i.importeME
        Next

        objItem = New documentoAnticipoDetalle() With
                           {
                            .MontoPagadoSoles = IIf(IsDBNull(pagoSoles), 0, pagoSoles),
                            .MontoPagadoUSD = IIf(IsDBNull(pagoDolares), 0, pagoDolares)
                            }

        Return objItem

        Return objItem
    End Function


    Public Function ObtenerPagosAnticiposDetails(strDocumentoAfectado As Integer) As List(Of documentoAnticipoDetalle)
        Dim objMostrarEncaja As New documentoAnticipoDetalle
        Dim ListaDetalle As New List(Of documentoAnticipoDetalle)

        Dim consulta2 = (From compradet In HeliosData.documentocompradetalle
                         Group Join caja In HeliosData.documentoAnticipoDetalle
                         On compradet.idDocumento Equals caja.documentoAfectado _
                         And compradet.secuencia Equals caja.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where compradet.idDocumento = strDocumentoAfectado And compradet.bonificacion <> "S"
                         Group c By
                      compradet.secuencia, compradet.destino, compradet.tipoExistencia,
                      compradet.idItem, compradet.descripcionItem, compradet.importe, compradet.importeUS,
                      compradet.bonificacion, compradet.monto1, compradet.almacenRef, compradet.montokardex, compradet.montokardexUS,
                      compradet.montoIgv, compradet.montoIgvUS, compradet.estadoPago
                      Into g = Group
                         Select New With {.iditem = idItem,
                                       .Descripcion = descripcionItem,
                                       .ImporteDeudaSoles = importe,
                                       .ImporteDeudaUSD = importeUS,
                                        g, .TotalImportePagadoSoles = g.Sum(Function(c) c.importeMN),
                                        .TotalImportePagadoDolares = g.Sum(Function(c) c.importeME),
                                       .bonificacion = bonificacion,
                                       .secuencia = secuencia,
                                       .destino = destino,
                                       .tipoex = tipoExistencia,
                                       .cantidad = monto1,
                                       .almacenRef = almacenRef,
                                       .montokardex = montokardex,
                                       .montokardexus = montokardexUS,
                                       .montoIgv = montoIgv,
                                       .montoIgvUS = montoIgvUS,
                                       .estadoPago = estadoPago
                                   }
                               ).ToList

        Dim ncMN As Decimal = 0
        Dim ncME As Decimal = 0
        Dim ndMN As Decimal = 0
        Dim ndME As Decimal = 0
        For Each obj In consulta2
            '.idItem = obj.iditem, _

            objMostrarEncaja = New documentoAnticipoDetalle() With
                               {
                                   .secuencia = obj.secuencia,
                                .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion),
                                .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles), 0, obj.TotalImportePagadoSoles),
                                .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares), 0, obj.TotalImportePagadoDolares)
                                }
            ListaDetalle.Add(objMostrarEncaja)
        Next
        Return ListaDetalle
    End Function

    Public Function InsertSingleAnticipoXVenta(ByVal documentoAnticipoDetalleBE As documentoCajaDetalle, intIdDocumentoCaja As Integer, intIdCompra As Integer) As Integer
        Dim docAnticipoDetalle As New documentoAnticipoDetalle
        Using ts As New TransactionScope

            docAnticipoDetalle = New documentoAnticipoDetalle
            docAnticipoDetalle.idDocumento = documentoAnticipoDetalleBE.razonSocial
            docAnticipoDetalle.idEmpresa = Gempresas.IdEmpresaRuc
            docAnticipoDetalle.idEstablecimiento = GEstableciento.IdEstablecimiento
            docAnticipoDetalle.codigoOperacion = "103"
            docAnticipoDetalle.descripcion = documentoAnticipoDetalleBE.DetalleItem
            docAnticipoDetalle.importeMN = documentoAnticipoDetalleBE.montoSoles
            docAnticipoDetalle.importeME = documentoAnticipoDetalleBE.montoUsd
            docAnticipoDetalle.docAfectado = intIdCompra
            docAnticipoDetalle.usuarioModificacion = "Jiuni"
            docAnticipoDetalle.fechaActualizacion = documentoAnticipoDetalleBE.fechaModificacion
            HeliosData.documentoAnticipoDetalle.Add(docAnticipoDetalle)
            HeliosData.SaveChanges()
            ts.Complete()
            documentoAnticipoDetalleBE.secuencia = docAnticipoDetalle.secuencia
        End Using
        Return docAnticipoDetalle.idDocumento
    End Function

    Public Function Insert(ByVal documentoAnticipoDetalleBE As documentoAnticipoDetalle) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoAnticipoDetalle.Add(documentoAnticipoDetalleBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoAnticipoDetalleBE.secuencia
        End Using
    End Function

    Public Sub Update(ByVal documentoAnticipoDetalleBE As documentoAnticipoDetalle)
        Using ts As New TransactionScope
            Dim docAnticipoDetalle As documentoAnticipoDetalle = HeliosData.documentoAnticipoDetalle.Where(Function(o) _
                                            o.idDocumento = documentoAnticipoDetalleBE.idDocumento _
                                            And o.secuencia = documentoAnticipoDetalleBE.secuencia).First()

            docAnticipoDetalle.idEmpresa = documentoAnticipoDetalleBE.idEmpresa
            docAnticipoDetalle.idEstablecimiento = documentoAnticipoDetalleBE.idEstablecimiento
            docAnticipoDetalle.codigoOperacion = documentoAnticipoDetalleBE.codigoOperacion
            docAnticipoDetalle.descripcion = documentoAnticipoDetalleBE.descripcion
            docAnticipoDetalle.importeMN = documentoAnticipoDetalleBE.importeMN
            docAnticipoDetalle.importeME = documentoAnticipoDetalleBE.importeME
            docAnticipoDetalle.usuarioModificacion = documentoAnticipoDetalleBE.usuarioModificacion
            docAnticipoDetalle.fechaActualizacion = documentoAnticipoDetalleBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docAnticipoDetalle).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoAnticipoDetalleBE As documentoAnticipoDetalle)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoAnticipoDetalleBE)
    End Sub

    Public Function GetListar_documentoAnticipoDetalle() As List(Of documentoAnticipoDetalle)
        Return (From a In HeliosData.documentoAnticipoDetalle Select a).ToList
    End Function

    Public Function GetUbicar_documentoAnticipoDetallePorID(Secuencia As Integer) As documentoAnticipoDetalle
        Return (From a In HeliosData.documentoAnticipoDetalle
                Where a.secuencia = Secuencia Select a).First
    End Function

    Public Sub InsertSingleAnticipo(documentoAnticipoDetalleBE As documentoAnticipoDetalle, intIdDocumento As Integer)
        Dim docAnticipoDetalle As New documentoAnticipoDetalle
        Using ts As New TransactionScope

            docAnticipoDetalle = New documentoAnticipoDetalle
            '    objInventario = New HeliosDAL.InventarioMovimiento
            docAnticipoDetalle.idDocumento = intIdDocumento ' Me.IdDocumento
            docAnticipoDetalle.idEmpresa = documentoAnticipoDetalleBE.idEmpresa
            docAnticipoDetalle.idEstablecimiento = documentoAnticipoDetalleBE.idEstablecimiento
            docAnticipoDetalle.codigoOperacion = documentoAnticipoDetalleBE.codigoOperacion
            docAnticipoDetalle.descripcion = documentoAnticipoDetalleBE.descripcion
            docAnticipoDetalle.importeMN = documentoAnticipoDetalleBE.importeMN
            docAnticipoDetalle.importeME = documentoAnticipoDetalleBE.importeME
            docAnticipoDetalle.usuarioModificacion = documentoAnticipoDetalleBE.usuarioModificacion
            docAnticipoDetalle.fechaActualizacion = documentoAnticipoDetalleBE.fechaActualizacion
            HeliosData.documentoAnticipoDetalle.Add(docAnticipoDetalle)
            HeliosData.SaveChanges()
            ts.Complete()
            documentoAnticipoDetalleBE.secuencia = docAnticipoDetalle.secuencia
        End Using
    End Sub

    Public Sub UpdateSingleAnticipo(documentoAnticipoDetalleBE As documentoAnticipoDetalle, intIdDocumento As Integer)
        Using ts As New TransactionScope
            Dim docAnticipoDetalle As documentoAnticipoDetalle = HeliosData.documentoAnticipoDetalle.Where(Function(o) _
                                            o.idDocumento = intIdDocumento).First()

            docAnticipoDetalle.idEmpresa = documentoAnticipoDetalleBE.idEmpresa
            docAnticipoDetalle.idEstablecimiento = documentoAnticipoDetalleBE.idEstablecimiento
            docAnticipoDetalle.codigoOperacion = documentoAnticipoDetalleBE.codigoOperacion
            docAnticipoDetalle.descripcion = documentoAnticipoDetalleBE.descripcion
            docAnticipoDetalle.importeMN = documentoAnticipoDetalleBE.importeMN
            docAnticipoDetalle.importeME = documentoAnticipoDetalleBE.importeME
            docAnticipoDetalle.usuarioModificacion = documentoAnticipoDetalleBE.usuarioModificacion
            docAnticipoDetalle.fechaActualizacion = documentoAnticipoDetalleBE.fechaActualizacion

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertarNotaCreditoDevolucion(intIdDocumento As Integer)
        Dim docAnticipoDetalle As New documentoAnticipoDetalle
        Using ts As New TransactionScope

            Dim consulta = (From a In HeliosData.documentoAnticipoDetalle
                            Where a.docAfectado = intIdDocumento).ToList

            For Each items In consulta
                docAnticipoDetalle = New documentoAnticipoDetalle
                docAnticipoDetalle.idDocumento = items.idDocumento
                docAnticipoDetalle.idEmpresa = items.idEmpresa
                docAnticipoDetalle.idEstablecimiento = items.idEstablecimiento
                docAnticipoDetalle.codigoOperacion = items.codigoOperacion
                docAnticipoDetalle.descripcion = items.descripcion
                docAnticipoDetalle.importeMN = CDec((-1) * items.importeMN)
                docAnticipoDetalle.importeME = CDec((-1) * items.importeME)
                docAnticipoDetalle.docAfectado = items.docAfectado
                docAnticipoDetalle.usuarioModificacion = items.usuarioModificacion
                docAnticipoDetalle.fechaActualizacion = items.fechaActualizacion
                HeliosData.documentoAnticipoDetalle.Add(docAnticipoDetalle)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


End Class
