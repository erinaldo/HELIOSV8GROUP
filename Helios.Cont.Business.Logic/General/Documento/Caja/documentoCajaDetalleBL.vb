Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity.DbFunctions
Public Class documentoCajaDetalleBL
    Inherits BaseBL

    Public Function ObtenerCuentasPorCobrarPorProductoREC(strDocumentoAfectado As Integer, intSecventa As Integer) As documentoCajaDetalle
        Dim objItem As New documentoCajaDetalle
        Dim obj = (From p In HeliosData.documentoventaAbarrotesDet
                   Group Join c In HeliosData.documentoCajaDetalle
                      On p.idDocumento Equals c.documentoAfectado _
                      And p.secuencia Equals c.documentoAfectadodetalle
                      Into ords = Group
                   From c In ords.DefaultIfEmpty
                   Where p.idDocumento = strDocumentoAfectado And p.secuencia = intSecventa
                   Group c By
                      p.secuencia, p.destino,
                      p.idItem, p.nombreItem, p.importeMN, p.importeME,
                     p.monto1, p.estadoPago, p.montoIgv, p.montoIgvUS
                      Into g = Group
                   Select New With {.iditem = idItem,
                                       .Descripcion = nombreItem,
                                       .ImporteDeudaSoles = importeMN,
                                       .ImporteDeudaUSD = importeME,
                                        g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
                                        .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
                                       .secuencia = secuencia,
                                       .destino = destino,
                                       .cantidad = monto1,
                                       .estadoPago = estadoPago,
                                       .montoIgv = montoIgv,
                                       .montoIgvUS = montoIgvUS
                                   }
                               ).FirstOrDefault
        Dim ncMN As Decimal = 0
        Dim ncME As Decimal = 0
        Dim ndMN As Decimal = 0
        Dim ndME As Decimal = 0


        objItem = New documentoCajaDetalle() With
                           {
                               .secuencia = obj.secuencia,
                            .idItem = obj.iditem,
                            .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion),
                            .MontoDeudaSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles),
                            .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD),
                            .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles), 0, obj.TotalImportePagadoSoles),
                            .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares), 0, obj.TotalImportePagadoDolares),
                            .destino = obj.destino,
                               .CantidadCompra = obj.cantidad,
                               .EstadoCobro = obj.estadoPago,
                               .montoIgv = obj.montoIgv,
                               .montoIgvUS = obj.montoIgvUS
                            }

        Return objItem
    End Function

    Public Function ObtenerAnticipoDetails(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)
        Dim objeto As New documentoCajaDetalle

        'Dim consulta2 = (From compradet In HeliosData.documentocompradetalle
        '                 Group Join caja In HeliosData.documentoCajaDetalle
        '                 On compradet.idDocumento Equals caja.documentoAfectado _
        '                 And compradet.secuencia Equals caja.documentoAfectadodetalle
        '                 Into ords = Group
        '                 From c In ords.DefaultIfEmpty
        '                 Where compradet.idDocumento = strDocumentoAfectado
        '                 Group c By
        '              compradet.secuencia, compradet.destino, compradet.tipoExistencia,
        '              compradet.idItem, compradet.descripcionItem, compradet.importe, compradet.importeUS,
        '              compradet.bonificacion, compradet.monto1, compradet.almacenRef, compradet.montokardex, compradet.montokardexUS,
        '              compradet.montoIgv, compradet.montoIgvUS, compradet.estadoPago
        '              Into g = Group
        '                 Select New With {.iditem = idItem,
        '                               .Descripcion = descripcionItem,
        '                               .ImporteDeudaSoles = importe,
        '                               .ImporteDeudaUSD = importeUS,
        '                                g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
        '                                .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
        '                               .bonificacion = bonificacion,
        '                               .secuencia = secuencia,
        '                               .destino = destino,
        '                               .tipoex = tipoExistencia,
        '                               .cantidad = monto1,
        '                               .almacenRef = almacenRef,
        '                               .montokardex = montokardex,
        '                               .montokardexus = montokardexUS,
        '                               .montoIgv = montoIgv,
        '                               .montoIgvUS = montoIgvUS,
        '                               .estadoPago = estadoPago
        '                           }
        '                       ).ToList

        Dim consulta2 = (From det In HeliosData.documentoCajaDetalle
                         Join doc In HeliosData.documentoCaja
                         On det.idDocumento Equals doc.idDocumento
                         Where det.idDocumento = strDocumentoAfectado
                         Select
                             det.idDocumento,
                             det.secuencia,
                             det.idItem,
                             det.DetalleItem,
                             det.montoSoles,
                             det.montoUsd,
                             doc.estado,
                                 pagos = (CType((Aggregate t1 In
                                        (From p In HeliosData.documentoCajaDetalle
                                         Join k In HeliosData.documentoCaja
                                          On k.idDocumento Equals p.idDocumento
                                         Where
                                         p.idCajaPadre = det.idDocumento And k.movimientoCaja = "AC"
                                         Select New With {
                                             p.montoSoles
                                         }) Into Sum(t1.montoSoles)), Decimal?))).ToList

        For Each i In consulta2


            objeto = New documentoCajaDetalle

            objeto.idDocumento = i.idDocumento
            objeto.secuencia = i.secuencia
            objeto.idItem = i.idItem
            objeto.DetalleItem = i.DetalleItem
            objeto.montoSoles = i.montoSoles - i.pagos.GetValueOrDefault
            objeto.montoUsd = i.montoUsd
            objeto.EstadoCobro = i.estado

            ListaDetalle.Add(objeto)


        Next
        Return ListaDetalle
    End Function

    Public Sub InsertPagosDeCajaRec(objDocumentoBE As documento, intDocCaja As Integer, ventaOriginal As Integer)
        Dim saldoME As Decimal = 0
        Dim saldoItem As Decimal = 0
        Dim saldoItemME As Decimal = 0
        Dim nDetalle As New documentoCajaDetalle
        Dim objItemsaldo As New documentoCajaDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim lista As New List(Of String)
        lista.Add("07")
        lista.Add("87")
        lista.Add("9901")

        Dim lista2 As New List(Of String)
        lista2.Add("08")
        lista2.Add("88")

        Using ts As New TransactionScope
            For Each i In objDocumentoBE.documentoCaja.documentoCajaDetalle
                Dim NCventa = Aggregate det In HeliosData.documentoventaAbarrotesDet
                            Join v In HeliosData.documentoventaAbarrotes On v.idDocumento Equals det.idDocumento
                            Where lista.Contains(v.tipoDocumento) And det.idPadreDTVenta = i.documentoAfectadodetalle
                            Into NCmn = Sum(det.importeMN),
                                 NCme = Sum(det.importeME)

                Dim NBventa = Aggregate det In HeliosData.documentoventaAbarrotesDet
                             Join v In HeliosData.documentoventaAbarrotes On v.idDocumento Equals det.idDocumento
                             Where lista2.Contains(v.tipoDocumento) And det.idPadreDTVenta = i.documentoAfectadodetalle
                             Into NBmn = Sum(det.importeMN),
                                  NBme = Sum(det.importeME)


                objItemsaldo = cajaDetalleBL.ObtenerCuentasPorCobrarPorProductoREC(i.documentoAfectado, i.documentoAfectadodetalle)

                Dim VentaDetalle As documentoventaAbarrotesDet = HeliosData.documentoventaAbarrotesDet.Where(Function(o) o.secuencia = i.documentoAfectadodetalle).FirstOrDefault



                Select Case ventaOriginal
                    Case 1
                        saldoItem = objItemsaldo.MontoDeudaSoles - i.montoSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault
                        saldoItemME = objItemsaldo.MontoDeudaUSD - i.montoUsd - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault

                        If saldoItem <= 0 Then
                            VentaDetalle.estadoPago = TIPO_VENTA.PAGO.COBRADO
                        Else
                            VentaDetalle.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                        End If
                    Case 2
                        saldoItem = objItemsaldo.MontoDeudaSoles - i.montoSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault
                        saldoItemME = objItemsaldo.MontoDeudaUSD - i.montoUsd - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault

                        If saldoItemME <= 0 Then
                            VentaDetalle.estadoPago = TIPO_VENTA.PAGO.COBRADO
                        Else
                            VentaDetalle.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                        End If
                End Select






                nDetalle = New documentoCajaDetalle
                nDetalle.idDocumento = intDocCaja
                nDetalle.documentoAfectado = i.documentoAfectado
                nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                nDetalle.secuencia = i.secuencia
                nDetalle.fecha = i.fecha
                nDetalle.idItem = i.idItem
                nDetalle.DetalleItem = i.DetalleItem
                nDetalle.montoSoles = i.montoSoles
                nDetalle.montoSolesTransacc = i.montoSolesTransacc
                nDetalle.montoUsd = i.montoUsd
                nDetalle.montoUsdTransacc = i.montoUsdTransacc
                nDetalle.entregado = i.entregado
                nDetalle.diferTipoCambio = i.diferTipoCambio
                nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                nDetalle.idCajaUsuario = i.idCajaUsuario
                nDetalle.usuarioModificacion = i.usuarioModificacion
                nDetalle.fechaModificacion = i.fechaModificacion
                HeliosData.documentoCajaDetalle.Add(nDetalle)

            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function ObtenerCuentasPorCobrarPorDetailsREC(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)

        Dim consulta = (From p In HeliosData.documentoventaAbarrotesDet
                        Group Join c In HeliosData.documentoCajaDetalle
                      On p.idDocumento Equals c.documentoAfectado _
                      And p.secuencia Equals c.documentoAfectadodetalle
                      Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where p.idDocumento = strDocumentoAfectado
                        Group c By
                      p.secuencia, p.destino,
                      p.idItem, p.nombreItem, p.importeMN, p.importeME,
                     p.monto1, p.estadoPago, p.montoIgv, p.montoIgvUS
                      Into g = Group
                        Select New With {.iditem = idItem,
                                       .Descripcion = nombreItem,
                                       .ImporteDeudaSoles = importeMN,
                                       .ImporteDeudaUSD = importeME,
                                        g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
                                        .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
                                       .secuencia = secuencia,
                                       .destino = destino,
                                       .cantidad = monto1,
                                       .estadoPago = estadoPago,
                                       .montoIgv = montoIgv,
                                       .montoIgvUS = montoIgvUS
                                   }
                               ).ToList
        Dim ncMN As Decimal = 0
        Dim ncME As Decimal = 0
        Dim ndMN As Decimal = 0
        Dim ndME As Decimal = 0
        For Each obj In consulta

            objMostrarEncaja = New documentoCajaDetalle() With
                               {
                                   .secuencia = obj.secuencia,
                                .idItem = obj.iditem,
                                .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion),
                                .MontoDeudaSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles),
                                .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD),
                                .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles), 0, obj.TotalImportePagadoSoles),
                                .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares), 0, obj.TotalImportePagadoDolares),
                                .destino = obj.destino,
                                   .CantidadCompra = obj.cantidad,
                                   .EstadoCobro = obj.estadoPago,
                                   .montoIgv = obj.montoIgv,
                                   .montoIgvUS = obj.montoIgvUS
                                }
            ListaDetalle.Add(objMostrarEncaja)
        Next
        Return ListaDetalle
    End Function

    Public Sub InsertPagosDeCajaMENew(objDocumentoBE As documento, intDocCaja As Integer, ventaOriginal As Integer)
        Dim saldoME As Decimal = 0
        Dim saldoItem As Decimal = 0
        Dim saldoItemME As Decimal = 0
        Dim nDetalle As New documentoCajaDetalle
        Dim objItemsaldo As New documentoCajaDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim lista As New List(Of String)
        lista.Add("07")
        lista.Add("87")
        lista.Add("9901")
        lista.Add("20")

        Dim lista2 As New List(Of String)
        lista2.Add("08")
        lista2.Add("88")

        Using ts As New TransactionScope
            For Each i In objDocumentoBE.documentoCaja.documentoCajaDetalle
                Dim NCventa = Aggregate det In HeliosData.documentoventaAbarrotesDet _
                            Join v In HeliosData.documentoventaAbarrotes On v.idDocumento Equals det.idDocumento _
                            Where lista.Contains(v.tipoDocumento) And det.idPadreDTVenta = i.documentoAfectadodetalle _
                            Into NCmn = Sum(det.importeMN), _
                                 NCme = Sum(det.importeME)

                Dim NBventa = Aggregate det In HeliosData.documentoventaAbarrotesDet _
                             Join v In HeliosData.documentoventaAbarrotes On v.idDocumento Equals det.idDocumento _
                             Where lista2.Contains(v.tipoDocumento) And det.idPadreDTVenta = i.documentoAfectadodetalle _
                             Into NBmn = Sum(det.importeMN), _
                                  NBme = Sum(det.importeME)


                objItemsaldo = cajaDetalleBL.ObtenerCuentasPorCobrarPorProducto(i.documentoAfectado, i.documentoAfectadodetalle)

                Dim VentaDetalle As documentoventaAbarrotesDet = HeliosData.documentoventaAbarrotesDet.Where(Function(o) o.secuencia = i.documentoAfectadodetalle).FirstOrDefault



                Select Case ventaOriginal
                    Case 1
                        saldoItem = objItemsaldo.MontoDeudaSoles - i.montoSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault
                        saldoItemME = objItemsaldo.MontoDeudaUSD - i.montoUsd - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault

                        If saldoItem <= 0 Then
                            VentaDetalle.estadoPago = TIPO_VENTA.PAGO.COBRADO
                        Else
                            VentaDetalle.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                        End If
                    Case 2
                        saldoItem = objItemsaldo.MontoDeudaSoles - i.montoSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault
                        saldoItemME = objItemsaldo.MontoDeudaUSD - i.montoUsd - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault

                        If saldoItemME <= 0 Then
                            VentaDetalle.estadoPago = TIPO_VENTA.PAGO.COBRADO
                        Else
                            VentaDetalle.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                        End If
                End Select






                nDetalle = New documentoCajaDetalle
                nDetalle.idDocumento = intDocCaja
                nDetalle.documentoAfectado = i.documentoAfectado
                nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                nDetalle.secuencia = i.secuencia
                nDetalle.fecha = i.fecha
                nDetalle.idItem = i.idItem
                nDetalle.DetalleItem = i.DetalleItem
                nDetalle.montoSoles = i.montoSoles
                nDetalle.montoSolesTransacc = i.montoSolesTransacc
                nDetalle.montoUsd = i.montoUsd
                nDetalle.montoUsdTransacc = i.montoUsdTransacc
                nDetalle.entregado = i.entregado
                nDetalle.diferTipoCambio = i.diferTipoCambio
                nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                nDetalle.idCajaUsuario = i.idCajaUsuario
                nDetalle.usuarioModificacion = i.usuarioModificacion
                nDetalle.fechaModificacion = i.fechaModificacion
                HeliosData.documentoCajaDetalle.Add(nDetalle)

            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function ObtenerCuentasPorPagarAsientoDetails(listdoc As List(Of documentoLibroDiarioDetalle)) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)


        Dim list As New List(Of Integer)
        Dim list2 As New List(Of Integer)
        For Each i In listdoc
            list.Add(i.idDocumento)
            list2.Add(i.secuencia)
        Next



        Dim consulta2 = (From compradet In HeliosData.documentoLibroDiarioDetalle _
                         Join doc In HeliosData.documentoLibroDiario _
                           On doc.idDocumento Equals compradet.idDocumento _
                        Group Join caja In HeliosData.documentoCajaDetalle _
                         On compradet.idDocumento Equals caja.documentoAfectado _
                         And compradet.secuencia Equals caja.documentoAfectadodetalle _
                         Into ords = Group _
                      From c In ords.DefaultIfEmpty _
                      Where list.Contains(compradet.idDocumento) And list2.Contains(compradet.secuencia) _
                      Group c By _
                      compradet.secuencia,
                       compradet.descripcion, compradet.importeMN, compradet.importeME, compradet.cuenta,
                      compradet.estadoPago, compradet.idDocumento, doc.nroDoc, doc.tipoDoc, doc.fecha, doc.tipoCambio _
                      Into g = Group _
                      Select New With {.iddocumento = idDocumento,
                                       .tipodoc = tipoDoc,
                                       .fecha = fecha,
                                       .cuenta = cuenta,
                                       .tipocambio = tipoCambio,
                                       .numerodoc = nroDoc,
                                       .Descripcion = descripcion,
                                       .ImporteDeudaSoles = importeMN,
                                       .ImporteDeudaUSD = importeME,
                                        g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
                                        .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
                                       .secuencia = secuencia,
                                       .estadoPago = estadoPago
                                   }
                               ).ToList

        Dim ncMN As Decimal = 0
        Dim ncME As Decimal = 0
        Dim ndMN As Decimal = 0
        Dim ndME As Decimal = 0
        For Each obj In consulta2

            objMostrarEncaja = New documentoCajaDetalle() With _
                               {
                                   .secuencia = obj.secuencia, _
                                .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion), _
                                .MontoDeudaSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles), _
                                .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD), _
                                .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles.GetValueOrDefault), 0, obj.TotalImportePagadoSoles.GetValueOrDefault), _
                                .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares.GetValueOrDefault), 0, obj.TotalImportePagadoDolares.GetValueOrDefault), _
                                   .idDocumento = obj.iddocumento,
                                   .tipoDocumento = obj.tipodoc,
                                   .fechaDoc = obj.fecha,
                                   .tipoCambioTransacc = obj.tipocambio,
                                   .numeroDoc = obj.numerodoc,
                                   .cuenta = obj.cuenta,
                                   .EstadoCobro = obj.estadoPago
                                }
            ListaDetalle.Add(objMostrarEncaja)
        Next
        Return ListaDetalle
    End Function


    Public Function ObtenerCuentasPorPagarPorAsiento(strDocumentoAfectado As Integer, intSecCompra As Integer) As documentoCajaDetalle
        Dim objItem As New documentoCajaDetalle
        Dim obj = (From p In HeliosData.documentoLibroDiarioDetalle _
                       Group Join c In HeliosData.documentoCajaDetalle _
                      On p.idDocumento Equals c.documentoAfectado _
                      And p.secuencia Equals c.documentoAfectadodetalle _
                      Into ords = Group _
                      From c In ords.DefaultIfEmpty _
                      Where p.idDocumento = strDocumentoAfectado And p.secuencia = intSecCompra _
                      Group c By _
                      p.secuencia,
                       p.descripcion, p.importeMN, p.importeME,
                     p.estadoPago _
                      Into g = Group _
                      Select New With {.Descripcion = descripcion,
                                       .ImporteDeudaSoles = importeMN,
                                       .ImporteDeudaUSD = importeME,
                                        g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
                                        .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
                                       .secuencia = secuencia,
                                       .estadoPago = estadoPago
                                   }
                               ).FirstOrDefault
        Dim ncMN As Decimal = 0
        Dim ncME As Decimal = 0
        Dim ndMN As Decimal = 0
        Dim ndME As Decimal = 0


        objItem = New documentoCajaDetalle() With _
                           {
                             .secuencia = obj.secuencia, _
                            .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion), _
                            .MontoDeudaSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles), _
                            .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD), _
                            .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles), 0, obj.TotalImportePagadoSoles), _
                            .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares), 0, obj.TotalImportePagadoDolares), _
                               .EstadoCobro = obj.estadoPago
                            }

        Return objItem
    End Function

    Public Sub InsertPagosDeCajaLibroME(objDocumentoBE As documento, intDocCaja As Integer, listaDetalle As List(Of documentoCajaDetalle))
        Dim saldoME As Decimal = 0
        Dim saldoMN As Decimal = 0
        Dim saldoItem As Decimal = 0
        Dim saldoItemME As Decimal = 0
        Dim nDetalle As New documentoCajaDetalle
        Dim objItemsaldo As New documentoCajaDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim listadocumento As New List(Of documentoCajaDetalle)
        Dim pagoDoc As Decimal = CDec(0.0)
        Dim pagoDocME As Decimal = CDec(0.0)
        Dim idDoc As Integer = 0
        Dim idDocDet As Integer = 0
        Dim conteo As Integer = 0


        Using ts As New TransactionScope



            For Each i In objDocumentoBE.documentoCaja.documentoCajaDetalle
                conteo += 1

                If conteo = 1 Then
                    idDoc = i.documentoAfectado
                    idDocDet = i.documentoAfectadodetalle
                End If

                objItemsaldo = cajaDetalleBL.ObtenerCuentasPorPagarPorAsiento(i.documentoAfectado, i.documentoAfectadodetalle)
                Dim VentaDetalle As documentoLibroDiarioDetalle = HeliosData.documentoLibroDiarioDetalle.Where(Function(o) o.secuencia = i.documentoAfectadodetalle).FirstOrDefault

                'If conteo >= 2 Then
                '    If idDoc = i.documentoAfectado Then
                '        If idDocDet = i.documentoAfectadodetalle Then
                '            pagoDoc += i.montoSoles
                '            pagoDocME += i.montoUsd
                '        Else
                '            idDocDet = i.documentoAfectadodetalle
                '            pagoDoc = CDec(0.0)
                '            pagoDocME = CDec(0.0)
                '            conteo = 0
                '        End If
                '    Else
                '        idDoc = i.documentoAfectado
                '        pagoDoc = CDec(0.0)
                '        pagoDocME = CDec(0.0)
                '        conteo = 0
                '    End If
                'End If
                If conteo >= 2 Then
                    If idDoc = i.documentoAfectado Then
                        If idDocDet = i.documentoAfectadodetalle Then
                            pagoDoc += i.montoSoles
                            pagoDocME += i.montoUsd
                        Else
                            idDoc = i.documentoAfectado
                            idDocDet = i.documentoAfectadodetalle
                            pagoDoc = CDec(0.0)
                            pagoDocME = CDec(0.0)

                        End If
                    Else
                        idDoc = i.documentoAfectado
                        idDocDet = i.documentoAfectadodetalle
                        pagoDoc = CDec(0.0)
                        pagoDocME = CDec(0.0)

                    End If
                End If

                Select Case i.monedaDoc
                    Case 1
                        saldoItem = objItemsaldo.MontoDeudaSoles - i.montoSoles - objItemsaldo.MontoPagadoSoles - pagoDoc
                        saldoItemME = objItemsaldo.MontoDeudaUSD - i.montoUsd - objItemsaldo.MontoPagadoUSD - pagoDocME

                        If saldoItem <= 0 Then
                            VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                        Else
                            VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        End If
                    Case 2
                        saldoItem = objItemsaldo.MontoDeudaSoles - i.montoSoles - objItemsaldo.MontoPagadoSoles - pagoDoc
                        saldoItemME = objItemsaldo.MontoDeudaUSD - i.montoUsd - objItemsaldo.MontoPagadoUSD - pagoDocME

                        If saldoItemME <= 0 Then
                            VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                        Else
                            VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        End If
                End Select

                nDetalle = New documentoCajaDetalle
                nDetalle.idDocumento = intDocCaja
                nDetalle.documentoAfectado = i.documentoAfectado
                nDetalle.secuencia = i.secuencia
                nDetalle.fecha = i.fecha
                nDetalle.idItem = i.idItem
                nDetalle.DetalleItem = i.DetalleItem
                nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                nDetalle.montoSoles = i.montoSoles
                nDetalle.montoUsd = i.montoUsd
                nDetalle.entregado = i.entregado
                nDetalle.diferTipoCambio = i.diferTipoCambio
                nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                nDetalle.idCajaUsuario = i.idCajaUsuario
                nDetalle.usuarioModificacion = i.usuarioModificacion
                nDetalle.fechaModificacion = i.fechaModificacion

                HeliosData.documentoCajaDetalle.Add(nDetalle)



            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function ObtenerPagosDetailsAsientoManual(idprov As Integer, strperiodo As String, tipoP As String, modulo As String) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)

        Dim consulta2 = (From compradet In HeliosData.documentoLibroDiarioDetalle _
                         Join doc In HeliosData.documentoLibroDiario _
                           On doc.idDocumento Equals compradet.idDocumento _
                        Group Join caja In HeliosData.documentoCajaDetalle _
                         On compradet.idDocumento Equals caja.documentoAfectado _
                         And compradet.secuencia Equals caja.documentoAfectadodetalle _
                         Into ords = Group _
                      From c In ords.DefaultIfEmpty _
                      Where doc.razonSocial = idprov And doc.fechaPeriodo = strperiodo And compradet.tipoPago = tipoP And compradet.descripcion = modulo _
                      Group c By _
                      compradet.secuencia,
                       compradet.descripcion, compradet.importeMN, compradet.importeME,
                       compradet.estadoPago, doc.idDocumento, doc.nroDoc, doc.tipoDoc, doc.fecha, doc.tipoCambio _
                      Into g = Group _
                      Select New With {.iddocumento = idDocumento,
                                       .tipodoc = tipoDoc,
                                       .fecha = fecha,
                                       .tipocambio = tipoCambio,
                                       .numerodoc = nroDoc,
                                       .Descripcion = descripcion,
                                       .ImporteDeudaSoles = importeMN,
                                       .ImporteDeudaUSD = importeME,
                                        g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSolesTransacc),
                                        .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
                                       .secuencia = secuencia,
                                       .estadoPago = estadoPago
                                   }
                               ).ToList

        Dim ncMN As Decimal = 0
        Dim ncME As Decimal = 0
        Dim ndMN As Decimal = 0
        Dim ndME As Decimal = 0
        For Each obj In consulta2

            objMostrarEncaja = New documentoCajaDetalle() With _
                               {
                                   .secuencia = obj.secuencia, _
                                .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion), _
                                .MontoDeudaSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles), _
                                .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD), _
                                .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles.GetValueOrDefault), 0, obj.TotalImportePagadoSoles.GetValueOrDefault), _
                                .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares.GetValueOrDefault), 0, obj.TotalImportePagadoDolares.GetValueOrDefault), _
                                   .idDocumento = obj.iddocumento,
                                   .tipoDocumento = obj.tipodoc,
                                   .fechaDoc = obj.fecha,
                                   .tipoCambioTransacc = obj.tipocambio,
                                   .numeroDoc = obj.numerodoc,
                                   .EstadoCobro = obj.estadoPago
                                }
            ListaDetalle.Add(objMostrarEncaja)
        Next
        Return ListaDetalle
    End Function

    Public Function ObtenerCuentasPorPagarDocumentoDetailsME(listdoc As List(Of documentocompra)) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)

        Dim list As New List(Of Integer)
        For Each i In listdoc
            list.Add(i.idDocumento)
        Next

        Dim consulta2 = (From compradet In HeliosData.documentocompradetalle _
                         Join doc In HeliosData.documentocompra _
                           On doc.idDocumento Equals compradet.idDocumento _
                        Group Join caja In HeliosData.documentoCajaDetalle _
                         On compradet.idDocumento Equals caja.documentoAfectado _
                         And compradet.secuencia Equals caja.documentoAfectadodetalle _
                         Into ords = Group _
                      From c In ords.DefaultIfEmpty _
                      Where list.Contains(doc.idDocumento) And compradet.bonificacion <> "S" _
                      Group c By _
                      compradet.secuencia, compradet.destino, compradet.tipoExistencia,
                      compradet.idItem, compradet.descripcionItem, compradet.importe, compradet.importeUS,
                      compradet.bonificacion, compradet.monto1, compradet.almacenRef, compradet.montokardex, compradet.montokardexUS,
                      compradet.montoIgv, compradet.montoIgvUS, compradet.estadoPago, doc.idDocumento, doc.serie, doc.numeroDoc, doc.tipoDoc, doc.fechaDoc, doc.tcDolLoc _
                      Into g = Group _
                      Select New With {.iditem = idItem,
                                       .iddocumento = idDocumento,
                                       .tipodoc = tipoDoc,
                                       .serie = serie,
                                       .fecha = fechaDoc,
                                       .tipocambio = tcDolLoc,
                                       .numerodoc = numeroDoc,
                                       .Descripcion = descripcionItem,
                                       .ImporteDeudaSoles = importe,
                                       .ImporteDeudaUSD = importeUS,
                                        g, .TotalImportePagadoSolesTransac = g.Sum(Function(c) c.montoSolesTransacc),
                                       .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
                                        .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
                                          .TotalImportePagadoUSDTransac = g.Sum(Function(c) c.montoUsdTransacc),
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

            objMostrarEncaja = New documentoCajaDetalle() With _
                               {
                                   .secuencia = obj.secuencia, _
                                .idItem = obj.iditem, _
                                .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion), _
                                .MontoDeudaSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles), _
                                .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD), _
                                .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles.GetValueOrDefault), 0, obj.TotalImportePagadoSoles.GetValueOrDefault), _
                                .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares.GetValueOrDefault), 0, obj.TotalImportePagadoDolares.GetValueOrDefault), _
                                  .montoSolesTransacc = IIf(IsDBNull(obj.TotalImportePagadoSolesTransac.GetValueOrDefault), 0, obj.TotalImportePagadoSolesTransac.GetValueOrDefault), _
                                .montoUsdTransacc = IIf(IsDBNull(obj.TotalImportePagadoUSDTransac.GetValueOrDefault), 0, obj.TotalImportePagadoUSDTransac.GetValueOrDefault), _
                                .bonificacion = obj.bonificacion, _
                                   .destino = obj.destino, _
                                   .TipoExistencia = obj.tipoex,
                                   .CantidadCompra = obj.cantidad.GetValueOrDefault,
                                   .montokardex = obj.montokardex.GetValueOrDefault,
                                   .montokardexus = obj.montokardexus.GetValueOrDefault,
                                   .montoIgv = obj.montoIgv.GetValueOrDefault,
                                   .idDocumento = obj.iddocumento,
                                   .serie = obj.serie,
                                   .tipoDocumento = obj.tipodoc,
                                   .fechaDoc = obj.fecha,
                                   .tipoCambioTransacc = obj.tipocambio,
                                   .numeroDoc = obj.numerodoc,
                                   .montoIgvUS = obj.montoIgvUS.GetValueOrDefault,
                                   .almacenRef = IIf(IsDBNull(obj.almacenRef), 0, obj.almacenRef),
                                  .EstadoCobro = obj.estadoPago
                                }
            ListaDetalle.Add(objMostrarEncaja)
        Next
        Return ListaDetalle
    End Function



    Public Function ObtenerCuentasPorPagarDocumentoDetails(listdoc As List(Of documentocompra)) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)


        Dim list As New List(Of Integer)
        For Each i In listdoc
            list.Add(i.idDocumento)
        Next


        Dim consulta2 = (From compradet In HeliosData.documentocompradetalle _
                         Join doc In HeliosData.documentocompra _
                           On doc.idDocumento Equals compradet.idDocumento _
                        Group Join caja In HeliosData.documentoCajaDetalle _
                         On compradet.idDocumento Equals caja.documentoAfectado _
                         And compradet.secuencia Equals caja.documentoAfectadodetalle _
                         Into ords = Group _
                      From c In ords.DefaultIfEmpty _
                      Where list.Contains(doc.idDocumento) And compradet.bonificacion <> "S" _
                      Group c By _
                      compradet.secuencia, compradet.destino, compradet.tipoExistencia,
                      compradet.idItem, compradet.descripcionItem, compradet.importe, compradet.importeUS,
                      compradet.bonificacion, compradet.monto1, compradet.almacenRef, compradet.montokardex, compradet.montokardexUS,
                      compradet.montoIgv, compradet.montoIgvUS, compradet.estadoPago, doc.idDocumento, doc.serie, doc.numeroDoc, doc.tipoDoc, doc.fechaDoc, doc.tcDolLoc _
                      Into g = Group _
                      Select New With {.iditem = idItem,
                                       .iddocumento = idDocumento,
                                       .tipodoc = tipoDoc,
                                       .serie = serie,
                                       .fecha = fechaDoc,
                                       .tipocambio = tcDolLoc,
                                       .numerodoc = numeroDoc,
                                       .Descripcion = descripcionItem,
                                       .ImporteDeudaSoles = importe,
                                       .ImporteDeudaUSD = importeUS,
                                        g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
                                        .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
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

            objMostrarEncaja = New documentoCajaDetalle() With _
                               {
                                   .secuencia = obj.secuencia, _
                                .idItem = obj.iditem, _
                                .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion), _
                                .MontoDeudaSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles), _
                                .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD), _
                                .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles.GetValueOrDefault), 0, obj.TotalImportePagadoSoles.GetValueOrDefault), _
                                .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares.GetValueOrDefault), 0, obj.TotalImportePagadoDolares.GetValueOrDefault), _
                                .bonificacion = obj.bonificacion, _
                                   .destino = obj.destino, _
                                   .TipoExistencia = obj.tipoex,
                                   .CantidadCompra = obj.cantidad.GetValueOrDefault,
                                   .montokardex = obj.montokardex.GetValueOrDefault,
                                   .montokardexus = obj.montokardexus.GetValueOrDefault,
                                   .montoIgv = obj.montoIgv.GetValueOrDefault,
                                   .idDocumento = obj.iddocumento,
                                   .serie = obj.serie,
                                   .tipoDocumento = obj.tipodoc,
                                   .fechaDoc = obj.fecha,
                                   .tipoCambioTransacc = obj.tipocambio,
                                   .numeroDoc = obj.numerodoc,
                                   .montoIgvUS = obj.montoIgvUS.GetValueOrDefault,
                                   .almacenRef = IIf(IsDBNull(obj.almacenRef), 0, obj.almacenRef),
                                   .EstadoCobro = obj.estadoPago
                                }
            ListaDetalle.Add(objMostrarEncaja)
        Next
        Return ListaDetalle
    End Function


    Public Function ObtenerCuentasPorCobrarTodoDetails(idclie As Integer, strperiodo As String) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)

        Dim consulta = (From p In HeliosData.documentoventaAbarrotesDet _
                        Join doc In HeliosData.documentoventaAbarrotes _
                           On doc.idDocumento Equals p.idDocumento _
                       Group Join c In HeliosData.documentoCajaDetalle _
                      On p.idDocumento Equals c.documentoAfectado _
                      And p.secuencia Equals c.documentoAfectadodetalle _
                      Into ords = Group _
                      From c In ords.DefaultIfEmpty _
                      Where doc.idCliente = idclie And doc.fechaPeriodo = strperiodo _
                      Group c By _
                      p.secuencia, p.destino, p.tipoExistencia,
                      p.idItem, p.nombreItem, p.importeMN, p.importeME,
                     p.monto1, p.idAlmacenOrigen, p.estadoPago, p.montokardex, p.montokardexUS, p.montoIgv, p.montoIgvUS, p.importeMNK, p.importeMEK, doc.idDocumento, doc.serie, doc.numeroDoc, doc.tipoDocumento, doc.fechaDoc, doc.tipoCambio
                      Into g = Group _
                      Select New With {.iditem = idItem,
                                       .Descripcion = nombreItem,
                                       .iddocumento = idDocumento,
                                       .serie = serie,
                                       .nrodoc = numeroDoc,
                                       .tipodoc = tipoDocumento,
                                       .fechadoc = fechaDoc,
                                       .tipocambio = tipoCambio,
                                       .ImporteDeudaSoles = importeMN,
                                       .ImporteDeudaUSD = importeME,
                                        g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
                                        .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
                                       .secuencia = secuencia,
                                       .destino = destino,
                                       .tipoex = tipoExistencia,
                                       .cantidad = monto1,
                                       .almacenRef = idAlmacenOrigen,
                                       .estadoPago = estadoPago,
                                       .montoKardex = montokardex,
                                       .montoKardexUS = montokardexUS,
                                       .montoIgv = montoIgv,
                                       .montoIgvUS = montoIgvUS,
                                       .pmMN = importeMNK,
                                       .pmME = importeMEK
                                   }
                               ).ToList
        Dim ncMN As Decimal = 0
        Dim ncME As Decimal = 0
        Dim ndMN As Decimal = 0
        Dim ndME As Decimal = 0
        For Each obj In consulta

            objMostrarEncaja = New documentoCajaDetalle() With _
                               {
                                   .secuencia = obj.secuencia, _
                                .idItem = obj.iditem, _
                                .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion), _
                                .MontoDeudaSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles), _
                                .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD), _
                                .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles), 0, obj.TotalImportePagadoSoles), _
                                .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares), 0, obj.TotalImportePagadoDolares), _
                                .destino = obj.destino, _
                                   .TipoExistencia = obj.tipoex,
                                   .CantidadCompra = obj.cantidad,
                                   .almacenRef = IIf(IsDBNull(obj.almacenRef), 0, obj.almacenRef), _
                                   .EstadoCobro = obj.estadoPago,
                                   .montokardex = obj.montoKardex,
                                   .montokardexus = obj.montoKardexUS,
                                   .montoIgv = obj.montoIgv,
                                   .montoIgvUS = obj.montoIgvUS,
                                   .idDocumento = obj.iddocumento,
                                       .serie = obj.serie,
                                       .numeroDoc = obj.nrodoc,
                                       .tipoDocumento = obj.tipodoc,
                                       .fechaDoc = obj.fechadoc,
                                       .tipoCambioTransacc = obj.tipocambio,
                                   .pmMN = obj.pmMN,
                                   .pmME = obj.pmME
                                }
            ListaDetalle.Add(objMostrarEncaja)
        Next
        Return ListaDetalle
    End Function

    Public Function ObtenerCuentasPorPagarTodoDetails(idprov As Integer, strperiodo As String) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)

        Dim consulta2 = (From compradet In HeliosData.documentocompradetalle _
                         Join doc In HeliosData.documentocompra _
                           On doc.idDocumento Equals compradet.idDocumento _
                        Group Join caja In HeliosData.documentoCajaDetalle _
                         On compradet.idDocumento Equals caja.documentoAfectado _
                         And compradet.secuencia Equals caja.documentoAfectadodetalle _
                         Into ords = Group _
                      From c In ords.DefaultIfEmpty _
                      Where doc.idProveedor = idprov And doc.fechaContable = strperiodo And compradet.bonificacion <> "S" _
                      Group c By _
                      compradet.secuencia, compradet.destino, compradet.tipoExistencia,
                      compradet.idItem, compradet.descripcionItem, compradet.importe, compradet.importeUS,
                      compradet.bonificacion, compradet.monto1, compradet.almacenRef, compradet.montokardex, compradet.montokardexUS,
                      compradet.montoIgv, compradet.montoIgvUS, compradet.estadoPago, doc.idDocumento, doc.serie, doc.numeroDoc, doc.tipoDoc, doc.fechaDoc, doc.tcDolLoc _
                      Into g = Group _
                      Select New With {.iditem = idItem,
                                       .iddocumento = idDocumento,
                                       .tipodoc = tipoDoc,
                                       .serie = serie,
                                       .fecha = fechaDoc,
                                       .tipocambio = tcDolLoc,
                                       .numerodoc = numeroDoc,
                                       .Descripcion = descripcionItem,
                                       .ImporteDeudaSoles = importe,
                                       .ImporteDeudaUSD = importeUS,
                                        g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSolesTransacc),
                                        .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
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

            objMostrarEncaja = New documentoCajaDetalle() With _
                               {
                                   .secuencia = obj.secuencia, _
                                .idItem = obj.iditem, _
                                .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion), _
                                .MontoDeudaSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles), _
                                .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD), _
                                .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles.GetValueOrDefault), 0, obj.TotalImportePagadoSoles.GetValueOrDefault), _
                                .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares.GetValueOrDefault), 0, obj.TotalImportePagadoDolares.GetValueOrDefault), _
                                .bonificacion = obj.bonificacion, _
                                   .destino = obj.destino, _
                                   .TipoExistencia = obj.tipoex,
                                   .CantidadCompra = obj.cantidad.GetValueOrDefault,
                                   .montokardex = obj.montokardex.GetValueOrDefault,
                                   .montokardexus = obj.montokardexus.GetValueOrDefault,
                                   .montoIgv = obj.montoIgv.GetValueOrDefault,
                                   .idDocumento = obj.iddocumento,
                                   .serie = obj.serie,
                                   .tipoDocumento = obj.tipodoc,
                                   .fechaDoc = obj.fecha,
                                   .tipoCambioTransacc = obj.tipocambio,
                                   .numeroDoc = obj.numerodoc,
                                   .montoIgvUS = obj.montoIgvUS.GetValueOrDefault,
                                   .almacenRef = IIf(IsDBNull(obj.almacenRef), 0, obj.almacenRef),
                                   .EstadoCobro = obj.estadoPago
                                }
            ListaDetalle.Add(objMostrarEncaja)
        Next
        Return ListaDetalle
    End Function





    Public Function ListadoCajaDetallePago(intIdDocumento As Integer) As List(Of documentoCajaDetalle)
        Dim lista As New List(Of documentoCajaDetalle)
        Dim a As New documentoCajaDetalle

        Dim cc = (From c In HeliosData.documentoCajaDetalle _
                  Join det In HeliosData.documentoPrestamoDetalle _
                  On c.documentoAfectado Equals det.idCuota And c.documentoAfectadodetalle Equals det.secuencia _
                 Where det.idDocumento = intIdDocumento).ToList

        For Each i In cc
            a = New documentoCajaDetalle
            a.idDocumento = i.c.idDocumento
            a.DetalleItem = i.c.DetalleItem
            a.montoSoles = i.c.montoSoles
            a.montoUsd = i.c.montoUsd
            a.fecha = i.c.fecha

            lista.Add(a)
        Next

        Return lista
    End Function


    Public Function ListaPrestamosPorCobrarPorDetails(strDocumentoAfectado As Integer) As List(Of documentoPrestamoDetalle)
        Dim objMostrarEncaja As New documentoPrestamoDetalle
        Dim ListaDetalle As New List(Of documentoPrestamoDetalle)

        Dim consulta2 = (From p In HeliosData.documentoPrestamoDetalle _
                        Group Join c In HeliosData.documentoCajaDetalle _
                         On p.idCuota Equals c.documentoAfectado _
                         And p.secuencia Equals c.documentoAfectadodetalle _
                         Into ords = Group _
                      From c In ords.DefaultIfEmpty _
                      Where p.idDocumento = strDocumentoAfectado _
                      Group c By _
                      p.secuencia, p.idCuota, p.cuota, p.idDocumento, p.descripcion, p.estadoPago, p.montoSoles, p.montoUsd, p.cuenta, p.cuentaH, p.devengado, p.devengadoH _
                      Into g = Group _
                      Select New With {.idcuota = idCuota,
                                       .secuencia = secuencia,
                                       .iddocumento = idDocumento,
                                       .descripcion = descripcion,
                                       .cuenta = cuenta,
                                        g, .TotalImportePagadoMN = g.Sum(Function(c) c.montoSoles),
                                       .TotalImportePagadoME = g.Sum(Function(c) c.montoUsd),
                                       .deudaMonto = montoSoles,
                                      .deudaMontoME = montoUsd,
                                       .cuentaH = cuentaH,
                                       .devengado = devengado,
                                       .devengadoH = devengadoH,
                                       .cuota = cuota
                                   }
                               ).ToList

        'Dim ncMN As Decimal = 0
        'Dim ncME As Decimal = 0
        'Dim ndMN As Decimal = 0
        'Dim ndME As Decimal = 0
        For Each obj In consulta2

            objMostrarEncaja = New documentoPrestamoDetalle() With _
                                   {
                                       .idCuota = obj.idcuota, _
                                       .secuencia = obj.secuencia, _
                                       .idDocumento = obj.iddocumento, _
                                       .descripcion = obj.descripcion, _
                                       .cuenta = obj.cuenta, _
                                       .PagadoMonto = IIf(IsDBNull(obj.TotalImportePagadoMN), 0, obj.TotalImportePagadoMN), _
                                       .PagadoMontoME = IIf(IsDBNull(obj.TotalImportePagadoME), 0, obj.TotalImportePagadoME), _
                                       .DeudaMonto = IIf(IsDBNull(obj.deudaMonto), 0, obj.deudaMonto), _
                                       .DeudaMontoME = IIf(IsDBNull(obj.deudaMontoME), 0, obj.deudaMontoME), _
                                       .cuentaH = obj.cuentaH, _
                                       .devengado = obj.devengado, _
                                       .devengadoH = obj.devengadoH, _
                                       .cuota = obj.cuota
                                    }



            'If obj.fechaplazo < DateTime.Now And obj.estadoPago = "PN" Then
            '    objMostrarEncaja = New documentoCajaDetalle() With _
            '                       {
            '                           .secuencia = obj.idcuota, _
            '                           .referencia = obj.referencia, _
            '                           .PagadoMonto = IIf(IsDBNull(obj.TotalImportePagadoMN), 0, obj.TotalImportePagadoMN), _
            '                           .PagadoMontoME = IIf(IsDBNull(obj.TotalImportePagadoME), 0, obj.TotalImportePagadoME), _
            '                           .DeudaMonto = IIf(IsDBNull(obj.deudaMonto), 0, obj.deudaMonto)
            '                        }

            'Else
            '    objMostrarEncaja = New documentoCajaDetalle() With _
            '                       {
            '                           .secuencia = obj.idcuota, _
            '                           .referencia = obj.referencia, _
            '                       .PagadoMonto = IIf(IsDBNull(obj.TotalImportePagadoMN), 0, obj.TotalImportePagadoMN), _
            '                       .PagadoMontoME = IIf(IsDBNull(obj.TotalImportePagadoME), 0, obj.TotalImportePagadoME), _
            '                             .DeudaMonto = IIf(IsDBNull(obj.deudaMonto), 0, obj.deudaMonto), _
            '                             .DeudaMora = CDec(0.0), _
            '                             .DeudaMoraME = CDec(0.0), _
            '                            .DeudaComp = CDec(0.0), _
            '                             .DeudaCompME = CDec(0.0), _
            '                            .DeudaMorOtro = CDec(0.0), _
            '                             .DeudaMorOtroMe = CDec(0.0), _
            '                            .DeudaMorOtro1 = CDec(0.0), _
            '                             .DeudaMorOtro1ME = CDec(0.0)
            '                        }
            'End If

            ListaDetalle.Add(objMostrarEncaja)
        Next
        Return ListaDetalle
    End Function


    Public Function GetMovimientoXusuarioInfoDetalle(intUsuario As Integer, fechaActual As Date) As List(Of documentoCajaDetalle)
        Dim obj As New documentoCajaDetalle
        Dim Lista As New List(Of documentoCajaDetalle)
        Dim consulta = (From n In HeliosData.documentoCaja _
                        Join det In HeliosData.documentoCajaDetalle _
                        On det.idDocumento Equals n.idDocumento _
                     Where n.usuarioModificacion = intUsuario _
                     And n.fechaCobro.Value.Year = fechaActual.Year _
                     And n.fechaCobro.Value.Month = fechaActual.Month _
                     And n.fechaCobro.Value.Day = fechaActual.Day Select det).ToList

        For Each i In consulta
            obj = New documentoCajaDetalle
            obj.idDocumento = i.idDocumento
            obj.DetalleItem = i.DetalleItem
            obj.montoSoles = i.montoSoles
            obj.montoUsd = i.montoUsd
            Lista.Add(obj)
        Next
        Return Lista

    End Function

    Public Function ListadoAnticiposDetalle(idAnticipo As String) As List(Of documentoAnticipoDetalle)
        Dim lista As New List(Of documentoAnticipoDetalle)
        Dim a As New documentoAnticipoDetalle

        Dim doc As New documentocompraBL
        Dim docCompra As New documentocompra

        Dim cc = (From c In HeliosData.documentoAnticipoDetalle _
                 Where c.idAnticipo = idAnticipo).ToList


        For Each i In cc
            a = New documentoAnticipoDetalle
            a.idDocumento = i.idDocumento
            a.DetalleItem = i.DetalleItem
            a.importeMN = i.importeMN
            a.importeME = i.importeME
            a.fecha = i.fecha


            If Not IsNothing(i.documentoAfectado) Then
                a.documentoAfectado = i.documentoAfectado
                docCompra = doc.UbicarCompraPorIdDocumento(i.documentoAfectado)
                a.tipoDoc = docCompra.tipoDoc
                a.serie = docCompra.serie
                a.numeroDoc = docCompra.numeroDoc
                a.idProveedor = docCompra.idProveedor
            End If

            lista.Add(a)
        Next

        Return lista
    End Function


    Public Function ObtenerCuentasPorCobrarAnticipoOtorPorProducto(strDocumentoAfectado As Integer, intSecCompra As Integer) As documentoAnticipoDetalle
        Dim objItem As New documentoAnticipoDetalle
        Dim obj = (From p In HeliosData.documentoventaAbarrotesDet _
                       Group Join c In HeliosData.documentoAnticipoDetalle _
                      On p.idDocumento Equals c.documentoAfectado _
                      And p.secuencia Equals c.documentoAfectadodetalle _
                      Into ords = Group _
                      From c In ords.DefaultIfEmpty _
                      Where p.idDocumento = strDocumentoAfectado And p.secuencia = intSecCompra _
                      Group c By _
                      p.secuencia, p.destino, p.tipoExistencia,
                      p.idItem, p.nombreItem, p.importeMN, p.importeME,
                     p.monto1, p.idAlmacenOrigen, p.estadoPago, p.montokardex, p.montokardexUS, p.montoIgv, p.montoIgvUS _
                      Into g = Group _
                      Select New With {.iditem = idItem,
                                       .Descripcion = nombreItem,
                                       .ImporteDeudaSoles = importeMN,
                                       .ImporteDeudaUSD = importeME,
                                        g, .TotalImportePagadoSoles = g.Sum(Function(c) c.importeMN),
                                        .TotalImportePagadoDolares = g.Sum(Function(c) c.importeME),
                                       .secuencia = secuencia
                                   }
                               ).FirstOrDefault
        Dim ncMN As Decimal = 0
        Dim ncME As Decimal = 0
        Dim ndMN As Decimal = 0
        Dim ndME As Decimal = 0
        ' .idItem = obj.iditem, _

        objItem = New documentoAnticipoDetalle() With _
                           {
                               .secuencia = obj.secuencia, _
                            .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion), _
                            .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles), 0, obj.TotalImportePagadoSoles), _
                            .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares), 0, obj.TotalImportePagadoDolares)
                            }

        Return objItem
    End Function



    Public Function ObtenerCuentasPorPagarAnticipoPorProducto(strDocumentoAfectado As Integer, intSecCompra As Integer) As documentoAnticipoDetalle
        Dim objItem As New documentoAnticipoDetalle
        Dim obj = (From p In HeliosData.documentocompradetalle _
                       Group Join c In HeliosData.documentoAnticipoDetalle _
                      On p.idDocumento Equals c.documentoAfectado _
                      And p.secuencia Equals c.documentoAfectadodetalle _
                      Into ords = Group _
                      From c In ords.DefaultIfEmpty _
                      Where p.idDocumento = strDocumentoAfectado And p.secuencia = intSecCompra _
                      Group c By _
                      p.secuencia, p.destino, p.tipoExistencia,
                      p.idItem, p.descripcionItem, p.importe, p.importeUS,
                     p.monto1, p.almacenRef, p.estadoPago, p.montokardex, p.montokardexUS, p.montoIgv, p.montoIgvUS _
                      Into g = Group _
                      Select New With {.iditem = idItem,
                                       .Descripcion = descripcionItem,
                                       .ImporteDeudaSoles = importe,
                                       .ImporteDeudaUSD = importeUS,
                                        g, .TotalImportePagadoSoles = g.Sum(Function(c) c.importeMN),
                                        .TotalImportePagadoDolares = g.Sum(Function(c) c.importeME),
                                       .secuencia = secuencia
                                   }
                               ).FirstOrDefault
        Dim ncMN As Decimal = 0
        Dim ncME As Decimal = 0
        Dim ndMN As Decimal = 0
        Dim ndME As Decimal = 0
        ' .idItem = obj.iditem, _

        objItem = New documentoAnticipoDetalle() With _
                           {
                               .secuencia = obj.secuencia, _
                            .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion), _
                            .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles), 0, obj.TotalImportePagadoSoles), _
                            .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares), 0, obj.TotalImportePagadoDolares)
                            }

        Return objItem
    End Function


    Public Function ObtenerCuentasPorPagarPorCuota(strDocumentoAfectado As Integer, intSecCompra As Integer) As documentoCajaDetalle
        Dim objItem As New documentoCajaDetalle
        Dim obj = (From p In HeliosData.documentoPrestamoDetalle _
                       Group Join c In HeliosData.documentoCajaDetalle _
                      On p.idCuota Equals c.documentoAfectado _
                      And p.secuencia Equals c.documentoAfectadodetalle _
                      Into ords = Group _
                      From c In ords.DefaultIfEmpty _
                      Where p.idCuota = strDocumentoAfectado And p.secuencia = intSecCompra _
                      Group c By _
                      p.secuencia, p.idCuota, p.idDocumento, p.descripcion, p.estadoPago, p.montoSoles, p.montoUsd _
                      Into g = Group _
                      Select New With {.secuencia = secuencia,
                                        g, .TotalImportePagadoMN = g.Sum(Function(c) c.montoSoles),
                                        .TotalImportePagadoME = g.Sum(Function(c) c.montoUsd),
                                       .deudaMonto = montoSoles,
                                       .deudaMontoME = montoUsd,
                                       .estadoPago = estadoPago
                                   }
                               ).FirstOrDefault


        objItem = New documentoCajaDetalle() With _
                               {
                                   .secuencia = obj.secuencia, _
                                   .PagadoMonto = IIf(IsDBNull(obj.TotalImportePagadoMN), 0, obj.TotalImportePagadoMN), _
                                   .PagadoMontoME = IIf(IsDBNull(obj.TotalImportePagadoME), 0, obj.TotalImportePagadoME), _
                                         .DeudaMonto = IIf(IsDBNull(obj.deudaMonto), 0, obj.deudaMonto), _
                                        .DeudaMontoME = IIf(IsDBNull(obj.deudaMontoME), 0, obj.deudaMontoME)
                                }


        'Dim ncMN As Decimal = 0
        'Dim ncME As Decimal = 0
        'Dim ndMN As Decimal = 0
        'Dim ndME As Decimal = 0

        'If obj.fechaplazo < DateTime.Now And obj.estadoPago = "PN" Then

        '    objItem = New documentoCajaDetalle() With _
        '                       {
        '                           .secuencia = obj.secuencia, _
        '                           .PagadoMonto = IIf(IsDBNull(obj.TotalImportePagadoMN), 0, obj.TotalImportePagadoMN), _
        '                           .PagadoMontoME = IIf(IsDBNull(obj.TotalImportePagadoME), 0, obj.TotalImportePagadoME), _
        '                                 .DeudaMonto = IIf(IsDBNull(obj.deudaMonto), 0, obj.deudaMonto), _
        '                                .DeudaMontoME = IIf(IsDBNull(obj.deudaMontoME), 0, obj.deudaMontoME)
        '                        }

        'Else

        '    objItem = New documentoCajaDetalle() With _
        '                       {
        '                           .secuencia = obj.idcuota, _
        '                           .PagadoMonto = IIf(IsDBNull(obj.TotalImportePagadoMN), 0, obj.TotalImportePagadoMN), _
        '                           .PagadoMontoME = IIf(IsDBNull(obj.TotalImportePagadoME), 0, obj.TotalImportePagadoME), _
        '                           .PagadoInteres = IIf(IsDBNull(obj.TotalInteresPagadoMN), 0, obj.TotalInteresPagadoMN), _
        '                                   .PagadoInteresME = IIf(IsDBNull(obj.TotalInteresPagadoME), 0, obj.TotalInteresPagadoME), _
        '                                .PagadoSeguro = IIf(IsDBNull(obj.TotalSeguroPagadoMN), 0, obj.TotalSeguroPagadoMN), _
        '                                   .PagadoSeguroME = IIf(IsDBNull(obj.TotalSeguroPagadoME), 0, obj.TotalSeguroPagadoME), _
        '                                   .PagadoOtro = IIf(IsDBNull(obj.TotalOtroPagadoMN), 0, obj.TotalOtroPagadoMN), _
        '                                    .PagadoOtroME = IIf(IsDBNull(obj.TotalOtroPagadoME), 0, obj.TotalOtroPagadoME), _
        '                                   .PagadoPortes = IIf(IsDBNull(obj.TotalPortesPagadoMN), 0, obj.TotalPortesPagadoMN), _
        '                                   .PagadoPortesME = IIf(IsDBNull(obj.TotalPortesPagadoME), 0, obj.TotalPortesPagadoME), _
        '                                   .PagadoEnv = IIf(IsDBNull(obj.TotalEnvPagadoMN), 0, obj.TotalEnvPagadoMN), _
        '                                   .PagadoEnvME = IIf(IsDBNull(obj.TotalEnvPagadoME), 0, obj.TotalEnvPagadoME), _
        '                                   .PagadoMora = IIf(IsDBNull(obj.TotalMoraPagadoMN), 0, obj.TotalMoraPagadoMN), _
        '                                   .PagadoMoraME = IIf(IsDBNull(obj.TotalMoraPagadoME), 0, obj.TotalMoraPagadoME), _
        '                                   .PagadoComp = IIf(IsDBNull(obj.TotalCompPagadoMN), 0, obj.TotalCompPagadoMN), _
        '                                   .PagadoCompME = IIf(IsDBNull(obj.TotalCompPagadoME), 0, obj.TotalCompPagadoME), _
        '                                   .PagadoMorOtro = IIf(IsDBNull(obj.TotalMorOtroPagadoMN), 0, obj.TotalMorOtroPagadoMN), _
        '                                   .PagadoMorOtroMe = IIf(IsDBNull(obj.TotalMorOtroPagadoME), 0, obj.TotalMorOtroPagadoME), _
        '                                   .PagadoMorOtro1 = IIf(IsDBNull(obj.TotalMorOtro1PagadoMN), 0, obj.TotalMorOtro1PagadoMN), _
        '                                   .PagadoMorOtro1ME = IIf(IsDBNull(obj.TotalMorOtro1PagadoME), 0, obj.TotalMorOtro1PagadoME), _
        '                                 .DeudaMonto = IIf(IsDBNull(obj.deudaMonto), 0, obj.deudaMonto), _
        '                                .DeudaMontoME = IIf(IsDBNull(obj.deudaMontoME), 0, obj.deudaMontoME), _
        '                                .DeudaInteres = IIf(IsDBNull(obj.deudaInteres), 0, obj.deudaInteres), _
        '                                .DeudaInteresME = IIf(IsDBNull(obj.deudaInteresME), 0, obj.deudaInteresME), _
        '                                 .DeudaSeguro = IIf(IsDBNull(obj.deudaSeguro), 0, obj.deudaSeguro), _
        '                                .DeudaSeguroME = IIf(IsDBNull(obj.deudaSeguroME), 0, obj.deudaSeguroME), _
        '                           .DeudaOtro = IIf(IsDBNull(obj.deudaOtro), 0, obj.deudaOtro), _
        '                           .DeudaOtroME = IIf(IsDBNull(obj.deudaOtroME), 0, obj.deudaOtroME), _
        '                                 .DeudaPortes = IIf(IsDBNull(obj.deudaPortes), 0, obj.deudaPortes), _
        '                                 .DeudaPortesME = IIf(IsDBNull(obj.deudaPortesME), 0, obj.deudaPortesME), _
        '                                 .DeudaEnv = IIf(IsDBNull(obj.deudaEnv), 0, obj.deudaEnv), _
        '                                 .DeudaEnvME = IIf(IsDBNull(obj.deudaEnvME), 0, obj.deudaEnvME), _
        '                                 .DeudaMora = CDec(0.0), _
        '                                 .DeudaMoraME = CDec(0.0), _
        '                                .DeudaComp = CDec(0.0), _
        '                                 .DeudaCompME = CDec(0.0), _
        '                                .DeudaMorOtro = CDec(0.0), _
        '                                 .DeudaMorOtroMe = CDec(0.0), _
        '                                .DeudaMorOtro1 = CDec(0.0), _
        '                                 .DeudaMorOtro1ME = CDec(0.0)
        '                        }


        'End If
        Return objItem
    End Function

    'Public Function ObtenerCuentasPorPagarPorCuota(strDocumentoAfectado As Integer, intSecCompra As Integer) As documentoCajaDetalle
    '    Dim objItem As New documentoCajaDetalle
    '    Dim obj = (From p In HeliosData.documentoPrestamos _
    '                   Group Join c In HeliosData.documentoCajaDetalle _
    '                  On p.idDocumento Equals c.documentoAfectado _
    '                  And p.idCuota Equals c.documentoAfectadodetalle _
    '                  Into ords = Group _
    '                  From c In ords.DefaultIfEmpty _
    '                  Where p.idDocumento = strDocumentoAfectado And p.idCuota = intSecCompra _
    '                  Group c By _
    '                  p.idCuota, p.estadoPago, p.montoSoles, p.montoDolares, p.montoInteresSoles, p.montoInteresUSD, p.montoSeguro, p.montoSeguroME,
    '                  p.montoPortes, p.montoPortesME, p.montoOtro, p.montoOtroME, p.montoEnvCuenta, p.montoEnvCuentaME, p.intMoratorio, p.intMoratorioME,
    '                  p.IntCompensatorio, p.IntCompensatorioME, p.otros, p.otrosME, p.otros1, p.otros1ME, p.fechaVcto, p.fechaPlazo _
    '                  Into g = Group _
    '                  Select New With {.idcuota = idCuota,
    '                                    g, .TotalImportePagadoMN = g.Sum(Function(c) c.capitalMN),
    '                                    .TotalImportePagadoME = g.Sum(Function(c) c.capitalME),
    '                                   .TotalInteresPagadoMN = g.Sum(Function(c) c.interesMN),
    '                                   .TotalInteresPagadoME = g.Sum(Function(c) c.interesME),
    '                                   .TotalSeguroPagadoMN = g.Sum(Function(c) c.seguroMN),
    '                                   .TotalSeguroPagadoME = g.Sum(Function(c) c.seguroME),
    '                                   .TotalOtroPagadoMN = g.Sum(Function(c) c.otroMN),
    '                                    .TotalOtroPagadoME = g.Sum(Function(c) c.otroMN),
    '                                   .TotalPortesPagadoMN = g.Sum(Function(c) c.portesMN),
    '                                   .TotalPortesPagadoME = g.Sum(Function(c) c.portesME),
    '                                   .TotalEnvPagadoMN = g.Sum(Function(c) c.envMN),
    '                                   .TotalEnvPagadoME = g.Sum(Function(c) c.envME),
    '                                   .TotalMoraPagadoMN = g.Sum(Function(c) c.moraMN),
    '                                   .TotalMoraPagadoME = g.Sum(Function(c) c.moraME),
    '                                   .TotalCompPagadoMN = g.Sum(Function(c) c.compMN),
    '                                   .TotalCompPagadoME = g.Sum(Function(c) c.compME),
    '                                   .TotalMorOtroPagadoMN = g.Sum(Function(c) c.morOtroMN),
    '                                   .TotalMorOtroPagadoME = g.Sum(Function(c) c.morOtroME),
    '                                   .TotalMorOtro1PagadoMN = g.Sum(Function(c) c.morOtro1MN),
    '                                   .TotalMorOtro1PagadoME = g.Sum(Function(c) c.morOtro1ME),
    '                                   .deudaMonto = montoSoles,
    '                                   .deudaMontoME = montoDolares,
    '                                   .deudaInteres = montoInteresSoles,
    '                                   .deudaInteresME = montoInteresUSD,
    '                                   .deudaSeguro = montoSeguro,
    '                                   .deudaSeguroME = montoSeguroME,
    '                                   .deudaPortes = montoPortes,
    '                                   .deudaOtro = montoOtro,
    '                                   .deudaOtroME = montoOtroME,
    '                                    .deudaPortesME = montoPortesME,
    '                                   .deudaEnv = montoEnvCuenta,
    '                                   .deudaEnvME = montoEnvCuentaME,
    '                                   .deudaMora = intMoratorio,
    '                                   .deudaMoraME = intMoratorioME,
    '                                   .deudaComp = IntCompensatorio,
    '                                   .deudaCompME = IntCompensatorioME,
    '                                   .deudaMorOtro = otros,
    '                                   .deudaMorOtroMe = otrosME,
    '                                   .deudaMorOtro1 = otros1,
    '                                   .deudaMorOtro1ME = otros1ME,
    '                                   .fechaVcto = fechaVcto,
    '                                   .fechaplazo = fechaPlazo,
    '                                   .estadoPago = estadoPago
    '                               }
    '                           ).FirstOrDefault
    '    Dim ncMN As Decimal = 0
    '    Dim ncME As Decimal = 0
    '    Dim ndMN As Decimal = 0
    '    Dim ndME As Decimal = 0

    '    If obj.fechaplazo < DateTime.Now And obj.estadoPago = "PN" Then

    '        objItem = New documentoCajaDetalle() With _
    '                           {
    '                               .secuencia = obj.idcuota, _
    '                               .PagadoMonto = IIf(IsDBNull(obj.TotalImportePagadoMN), 0, obj.TotalImportePagadoMN), _
    '                               .PagadoMontoME = IIf(IsDBNull(obj.TotalImportePagadoME), 0, obj.TotalImportePagadoME), _
    '                               .PagadoInteres = IIf(IsDBNull(obj.TotalInteresPagadoMN), 0, obj.TotalInteresPagadoMN), _
    '                                       .PagadoInteresME = IIf(IsDBNull(obj.TotalInteresPagadoME), 0, obj.TotalInteresPagadoME), _
    '                                    .PagadoSeguro = IIf(IsDBNull(obj.TotalSeguroPagadoMN), 0, obj.TotalSeguroPagadoMN), _
    '                                       .PagadoSeguroME = IIf(IsDBNull(obj.TotalSeguroPagadoME), 0, obj.TotalSeguroPagadoME), _
    '                                       .PagadoOtro = IIf(IsDBNull(obj.TotalOtroPagadoMN), 0, obj.TotalOtroPagadoMN), _
    '                                        .PagadoOtroME = IIf(IsDBNull(obj.TotalOtroPagadoME), 0, obj.TotalOtroPagadoME), _
    '                                       .PagadoPortes = IIf(IsDBNull(obj.TotalPortesPagadoMN), 0, obj.TotalPortesPagadoMN), _
    '                                       .PagadoPortesME = IIf(IsDBNull(obj.TotalPortesPagadoME), 0, obj.TotalPortesPagadoME), _
    '                                       .PagadoEnv = IIf(IsDBNull(obj.TotalEnvPagadoMN), 0, obj.TotalEnvPagadoMN), _
    '                                       .PagadoEnvME = IIf(IsDBNull(obj.TotalEnvPagadoME), 0, obj.TotalEnvPagadoME), _
    '                                       .PagadoMora = IIf(IsDBNull(obj.TotalMoraPagadoMN), 0, obj.TotalMoraPagadoMN), _
    '                                       .PagadoMoraME = IIf(IsDBNull(obj.TotalMoraPagadoME), 0, obj.TotalMoraPagadoME), _
    '                                       .PagadoComp = IIf(IsDBNull(obj.TotalCompPagadoMN), 0, obj.TotalCompPagadoMN), _
    '                                       .PagadoCompME = IIf(IsDBNull(obj.TotalCompPagadoME), 0, obj.TotalCompPagadoME), _
    '                                       .PagadoMorOtro = IIf(IsDBNull(obj.TotalMorOtroPagadoMN), 0, obj.TotalMorOtroPagadoMN), _
    '                                       .PagadoMorOtroMe = IIf(IsDBNull(obj.TotalMorOtroPagadoME), 0, obj.TotalMorOtroPagadoME), _
    '                                       .PagadoMorOtro1 = IIf(IsDBNull(obj.TotalMorOtro1PagadoMN), 0, obj.TotalMorOtro1PagadoMN), _
    '                                       .PagadoMorOtro1ME = IIf(IsDBNull(obj.TotalMorOtro1PagadoME), 0, obj.TotalMorOtro1PagadoME), _
    '                                     .DeudaMonto = IIf(IsDBNull(obj.deudaMonto), 0, obj.deudaMonto), _
    '                                    .DeudaMontoME = IIf(IsDBNull(obj.deudaMontoME), 0, obj.deudaMontoME), _
    '                                    .DeudaInteres = IIf(IsDBNull(obj.deudaInteres), 0, obj.deudaInteres), _
    '                                    .DeudaInteresME = IIf(IsDBNull(obj.deudaInteresME), 0, obj.deudaInteresME), _
    '                                     .DeudaSeguro = IIf(IsDBNull(obj.deudaSeguro), 0, obj.deudaSeguro), _
    '                                    .DeudaSeguroME = IIf(IsDBNull(obj.deudaSeguroME), 0, obj.deudaSeguroME), _
    '                               .DeudaOtro = IIf(IsDBNull(obj.deudaOtro), 0, obj.deudaOtro), _
    '                               .DeudaOtroME = IIf(IsDBNull(obj.deudaOtroME), 0, obj.deudaOtroME), _
    '                                     .DeudaPortes = IIf(IsDBNull(obj.deudaPortes), 0, obj.deudaPortes), _
    '                                     .DeudaPortesME = IIf(IsDBNull(obj.deudaPortesME), 0, obj.deudaPortesME), _
    '                                     .DeudaEnv = IIf(IsDBNull(obj.deudaEnv), 0, obj.deudaEnv), _
    '                                     .DeudaEnvME = IIf(IsDBNull(obj.deudaEnvME), 0, obj.deudaEnvME), _
    '                                     .DeudaMora = IIf(IsDBNull(obj.deudaMora), 0, obj.deudaMora), _
    '                                     .DeudaMoraME = IIf(IsDBNull(obj.deudaMoraME), 0, obj.deudaMoraME), _
    '                                    .DeudaComp = IIf(IsDBNull(obj.deudaComp), 0, obj.deudaComp), _
    '                                     .DeudaCompME = IIf(IsDBNull(obj.deudaCompME), 0, obj.deudaCompME), _
    '                                    .DeudaMorOtro = IIf(IsDBNull(obj.deudaMorOtro), 0, obj.deudaMorOtro), _
    '                                     .DeudaMorOtroMe = IIf(IsDBNull(obj.deudaMorOtroMe), 0, obj.deudaMorOtroMe), _
    '                                    .DeudaMorOtro1 = IIf(IsDBNull(obj.deudaMorOtro1), 0, obj.deudaMorOtro1), _
    '                                     .DeudaMorOtro1ME = IIf(IsDBNull(obj.deudaMorOtro1ME), 0, obj.deudaMorOtro1ME)
    '                            }

    '    Else

    '        objItem = New documentoCajaDetalle() With _
    '                           {
    '                               .secuencia = obj.idcuota, _
    '                               .PagadoMonto = IIf(IsDBNull(obj.TotalImportePagadoMN), 0, obj.TotalImportePagadoMN), _
    '                               .PagadoMontoME = IIf(IsDBNull(obj.TotalImportePagadoME), 0, obj.TotalImportePagadoME), _
    '                               .PagadoInteres = IIf(IsDBNull(obj.TotalInteresPagadoMN), 0, obj.TotalInteresPagadoMN), _
    '                                       .PagadoInteresME = IIf(IsDBNull(obj.TotalInteresPagadoME), 0, obj.TotalInteresPagadoME), _
    '                                    .PagadoSeguro = IIf(IsDBNull(obj.TotalSeguroPagadoMN), 0, obj.TotalSeguroPagadoMN), _
    '                                       .PagadoSeguroME = IIf(IsDBNull(obj.TotalSeguroPagadoME), 0, obj.TotalSeguroPagadoME), _
    '                                       .PagadoOtro = IIf(IsDBNull(obj.TotalOtroPagadoMN), 0, obj.TotalOtroPagadoMN), _
    '                                        .PagadoOtroME = IIf(IsDBNull(obj.TotalOtroPagadoME), 0, obj.TotalOtroPagadoME), _
    '                                       .PagadoPortes = IIf(IsDBNull(obj.TotalPortesPagadoMN), 0, obj.TotalPortesPagadoMN), _
    '                                       .PagadoPortesME = IIf(IsDBNull(obj.TotalPortesPagadoME), 0, obj.TotalPortesPagadoME), _
    '                                       .PagadoEnv = IIf(IsDBNull(obj.TotalEnvPagadoMN), 0, obj.TotalEnvPagadoMN), _
    '                                       .PagadoEnvME = IIf(IsDBNull(obj.TotalEnvPagadoME), 0, obj.TotalEnvPagadoME), _
    '                                       .PagadoMora = IIf(IsDBNull(obj.TotalMoraPagadoMN), 0, obj.TotalMoraPagadoMN), _
    '                                       .PagadoMoraME = IIf(IsDBNull(obj.TotalMoraPagadoME), 0, obj.TotalMoraPagadoME), _
    '                                       .PagadoComp = IIf(IsDBNull(obj.TotalCompPagadoMN), 0, obj.TotalCompPagadoMN), _
    '                                       .PagadoCompME = IIf(IsDBNull(obj.TotalCompPagadoME), 0, obj.TotalCompPagadoME), _
    '                                       .PagadoMorOtro = IIf(IsDBNull(obj.TotalMorOtroPagadoMN), 0, obj.TotalMorOtroPagadoMN), _
    '                                       .PagadoMorOtroMe = IIf(IsDBNull(obj.TotalMorOtroPagadoME), 0, obj.TotalMorOtroPagadoME), _
    '                                       .PagadoMorOtro1 = IIf(IsDBNull(obj.TotalMorOtro1PagadoMN), 0, obj.TotalMorOtro1PagadoMN), _
    '                                       .PagadoMorOtro1ME = IIf(IsDBNull(obj.TotalMorOtro1PagadoME), 0, obj.TotalMorOtro1PagadoME), _
    '                                     .DeudaMonto = IIf(IsDBNull(obj.deudaMonto), 0, obj.deudaMonto), _
    '                                    .DeudaMontoME = IIf(IsDBNull(obj.deudaMontoME), 0, obj.deudaMontoME), _
    '                                    .DeudaInteres = IIf(IsDBNull(obj.deudaInteres), 0, obj.deudaInteres), _
    '                                    .DeudaInteresME = IIf(IsDBNull(obj.deudaInteresME), 0, obj.deudaInteresME), _
    '                                     .DeudaSeguro = IIf(IsDBNull(obj.deudaSeguro), 0, obj.deudaSeguro), _
    '                                    .DeudaSeguroME = IIf(IsDBNull(obj.deudaSeguroME), 0, obj.deudaSeguroME), _
    '                               .DeudaOtro = IIf(IsDBNull(obj.deudaOtro), 0, obj.deudaOtro), _
    '                               .DeudaOtroME = IIf(IsDBNull(obj.deudaOtroME), 0, obj.deudaOtroME), _
    '                                     .DeudaPortes = IIf(IsDBNull(obj.deudaPortes), 0, obj.deudaPortes), _
    '                                     .DeudaPortesME = IIf(IsDBNull(obj.deudaPortesME), 0, obj.deudaPortesME), _
    '                                     .DeudaEnv = IIf(IsDBNull(obj.deudaEnv), 0, obj.deudaEnv), _
    '                                     .DeudaEnvME = IIf(IsDBNull(obj.deudaEnvME), 0, obj.deudaEnvME), _
    '                                     .DeudaMora = CDec(0.0), _
    '                                     .DeudaMoraME = CDec(0.0), _
    '                                    .DeudaComp = CDec(0.0), _
    '                                     .DeudaCompME = CDec(0.0), _
    '                                    .DeudaMorOtro = CDec(0.0), _
    '                                     .DeudaMorOtroMe = CDec(0.0), _
    '                                    .DeudaMorOtro1 = CDec(0.0), _
    '                                     .DeudaMorOtro1ME = CDec(0.0)
    '                            }


    '    End If
    '    Return objItem
    'End Function

    Public Sub InsertPagosDeCajaPrestamoME(objDocumentoBE As documento, intDocCaja As Integer, intEntidadFinanciera As Integer)
        Dim saldoMN As Decimal = 0
        Dim saldoME As Decimal = 0

        Dim saldoItem As Decimal = 0
        Dim saldoItemME As Decimal = 0

        Dim SaldoTotal As Decimal = 0
        Dim SaldoTotalME As Decimal = 0


        Dim nDetalle As New documentoCajaDetalle
        Dim objItemsaldo As New documentoCajaDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL

        Using ts As New TransactionScope
            For Each i In objDocumentoBE.documentoCaja.documentoCajaDetalle


                objItemsaldo = cajaDetalleBL.ObtenerCuentasPorPagarPorCuota(i.documentoAfectado, i.documentoAfectadodetalle)
                Dim VentaDetalle As documentoPrestamoDetalle = HeliosData.documentoPrestamoDetalle.Where(Function(o) o.secuencia = i.documentoAfectadodetalle).FirstOrDefault
                saldoItem = objItemsaldo.DeudaMonto - i.montoSoles - objItemsaldo.PagadoMonto
                saldoItemME = objItemsaldo.DeudaMontoME - i.montoUsd - objItemsaldo.PagadoMontoME
                SaldoTotal = saldoItem
                SaldoTotalME = saldoItemME
                If SaldoTotal <= 0 Then
                    VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                    VentaDetalle.tieneCosto = "S"
                Else
                    VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                End If
                If (objDocumentoBE.documentoCaja.tipoMovimiento = MovimientoCaja.EntradaDinero) Then
                    nDetalle = New documentoCajaDetalle
                    nDetalle.idDocumento = intDocCaja
                    nDetalle.documentoAfectado = i.documentoAfectado
                    nDetalle.secuencia = i.secuencia
                    nDetalle.fecha = i.fecha
                    nDetalle.idItem = i.idItem
                    nDetalle.DetalleItem = i.DetalleItem
                    nDetalle.montoSoles = i.montoSoles
                    nDetalle.montoUsd = i.montoUsd
                    nDetalle.entregado = i.entregado
                    nDetalle.diferTipoCambio = i.diferTipoCambio
                    nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                    nDetalle.usuarioModificacion = i.usuarioModificacion
                    nDetalle.fechaModificacion = i.fechaModificacion
                    HeliosData.documentoCajaDetalle.Add(nDetalle)

                ElseIf (objDocumentoBE.documentoCaja.tipoMovimiento = MovimientoCaja.SalidaDinero) Then

                    Dim consultaCaja = (From c In HeliosData.documentoCaja _
                                        Join d In HeliosData.documentoCajaDetalle _
                                        On c.idDocumento Equals d.idDocumento _
                                Where c.tipoMovimiento = "DC" And _
                                c.entidadFinanciera = intEntidadFinanciera).ToList

                    For Each item In consultaCaja

                        Select Case i.moneda
                            Case 1
                                saldoMN = i.montoSoles
                                If (saldoMN <> 0) Then
                                    nDetalle = New documentoCajaDetalle
                                    nDetalle.idDocumento = intDocCaja
                                    nDetalle.documentoAfectado = i.documentoAfectado
                                    nDetalle.secuencia = i.secuencia
                                    nDetalle.fecha = i.fecha
                                    nDetalle.idItem = i.idItem
                                    nDetalle.DetalleItem = i.DetalleItem
                                    nDetalle.entregado = i.entregado
                                    nDetalle.usuarioModificacion = i.usuarioModificacion
                                    nDetalle.fechaModificacion = i.fechaModificacion
                                    nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                                    If (item.d.montoSoles >= i.montoSoles And i.montoSoles = 0) Then
                                        nDetalle.montoSoles = i.montoSoles
                                        nDetalle.montoUsd = i.montoUsd
                                        saldoME = item.d.montoUsd - i.montoUsd
                                        nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                                        i.montoUsd = saldoME
                                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                                    ElseIf (item.d.montoSoles <= i.montoSoles And i.montoSoles = 0) Then
                                        nDetalle.montoSoles = i.montoSoles

                                        nDetalle.montoUsd = i.montoUsd

                                        nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                        nDetalle.diferTipoCambio = item.d.diferTipoCambio

                                        saldoMN = item.d.montoSoles - i.montoSoles
                                        i.montoSoles = saldoMN
                                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                                    ElseIf (item.d.montoSoles < i.montoSoles And i.montoSoles > 0) Then
                                        'nDetalle.montoSoles = Math.Round(CDec(item.d.montoUsdRef * i.diferTipoCambio), 2)
                                        nDetalle.montoSoles = item.d.montoSoles
                                        nDetalle.montoUsd = Math.Round(CDec(item.d.montoSoles / item.d.diferTipoCambio), 2)
                                        nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                        nDetalle.diferTipoCambio = item.d.diferTipoCambio

                                        saldoMN = item.d.montoSoles - i.montoSoles
                                        i.montoSoles = saldoMN
                                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                                    ElseIf (item.d.montoSoles > i.montoSoles And i.montoSoles > 0) Then

                                        If (item.d.montoSoles > i.montoSoles) Then
                                            nDetalle.montoSoles = i.montoSoles

                                            nDetalle.montoUsd = Math.Round(CDec((i.montoSoles) / item.d.diferTipoCambio), 2)
                                            nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                            nDetalle.diferTipoCambio = item.d.diferTipoCambio


                                            saldoMN = item.d.montoSoles - i.montoSoles
                                            i.montoSoles = 0
                                        Else
                                            nDetalle.montoSoles = i.montoSoles

                                            nDetalle.montoUsd = Math.Round(CDec((i.montoSoles * -1) / item.d.diferTipoCambio), 2)
                                            nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                            nDetalle.diferTipoCambio = item.d.diferTipoCambio

                                            saldoMN = item.d.montoSoles - i.montoSoles
                                            i.montoSoles = saldoMN
                                        End If

                                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                                    ElseIf (item.d.montoSoles > i.montoSoles And i.montoSoles < 0) Then
                                        nDetalle.montoSoles = (CDec(i.montoSoles * -1))
                                        nDetalle.montoUsd = Math.Round(CDec((i.montoSoles * -1) / item.d.diferTipoCambio), 2)
                                        nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                        nDetalle.diferTipoCambio = item.d.diferTipoCambio


                                        saldoMN = item.d.montoSoles - i.montoSoles
                                        i.montoSoles = saldoMN
                                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                                    ElseIf (item.d.montoSoles = i.montoSoles And i.montoSoles > 0) Then
                                        nDetalle.montoSoles = i.montoSoles

                                        nDetalle.montoUsd = Math.Round(CDec(i.montoSoles / item.d.diferTipoCambio), 2)

                                        nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                        nDetalle.diferTipoCambio = item.d.diferTipoCambio


                                        saldoMN = item.d.montoSoles - i.montoSoles
                                        i.montoSoles = saldoMN
                                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                                    End If
                                End If
                            Case 2
                                saldoME = i.montoUsd
                                If (saldoME > 0) Then
                                    nDetalle = New documentoCajaDetalle
                                    nDetalle.idDocumento = intDocCaja
                                    nDetalle.documentoAfectado = i.documentoAfectado
                                    nDetalle.secuencia = i.secuencia
                                    nDetalle.fecha = i.fecha
                                    nDetalle.idItem = i.idItem
                                    nDetalle.DetalleItem = i.DetalleItem
                                    nDetalle.entregado = i.entregado
                                    nDetalle.usuarioModificacion = i.usuarioModificacion
                                    nDetalle.fechaModificacion = i.fechaModificacion
                                    nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                                    If (item.d.montoUsd >= i.montoUsd And i.montoUsd = 0) Then
                                        nDetalle.montoSoles = i.montoSoles
                                        nDetalle.montoUsd = i.montoUsd
                                        saldoME = item.d.montoUsd - i.montoUsd
                                        nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                                        i.montoUsd = saldoME
                                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                                    ElseIf (item.d.montoUsd <= i.montoUsd And i.montoUsd = 0) Then
                                        nDetalle.montoSoles = i.montoSoles
                                        nDetalle.montoUsd = i.montoUsd
                                        nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                                        saldoME = item.d.montoUsd - i.montoUsd
                                        i.montoUsd = saldoME
                                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                                    ElseIf (item.d.montoUsd < i.montoUsd And i.montoUsd > 0) Then
                                        nDetalle.montoSoles = Math.Round(CDec(item.d.montoUsd * item.d.diferTipoCambio), 2)
                                        nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                                        saldoME = saldoME - nDetalle.montoUsd
                                        i.montoUsd = saldoME
                                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                                    ElseIf (item.d.montoUsd > i.montoUsd And i.montoUsd > 0) Then
                                        nDetalle.montoSoles = Math.Round(CDec(i.montoUsd * item.d.diferTipoCambio), 2)
                                        nDetalle.montoUsd = i.montoUsd
                                        nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                                        saldoME = saldoME - i.montoUsd
                                        i.montoUsd = saldoME
                                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                                    ElseIf (item.d.montoUsd > i.montoUsd And i.montoUsd < 0) Then
                                        nDetalle.montoSoles = Math.Round(CDec((i.montoUsd * -1) * item.d.diferTipoCambio), 2)
                                        nDetalle.montoUsd = Math.Round(CDec(i.montoUsd * -1), 2)
                                        nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                                        saldoME = item.d.montoUsd - i.montoUsd
                                        i.montoUsd = saldoME
                                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                                    ElseIf (item.d.montoUsd = i.montoUsd And i.montoUsd > 0) Then
                                        nDetalle.montoSoles = Math.Round(CDec(i.montoUsd * item.d.diferTipoCambio), 2)
                                        nDetalle.montoUsd = i.montoUsd

                                        nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                        nDetalle.diferTipoCambio = item.d.diferTipoCambio

                                        saldoME = saldoME - i.montoUsd
                                        i.montoUsd = saldoME
                                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                                    End If
                                End If
                        End Select

                    Next
                End If



            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub
    Public Function ObtenerPrestamosPorCobrarPorDetails(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)

        Dim consulta2 = (From p In HeliosData.documentoPrestamos _
                        Group Join c In HeliosData.documentoCajaDetalle _
                         On p.idDocumento Equals c.documentoAfectado _
                         And p.idCuota Equals c.documentoAfectadodetalle _
                         Into ords = Group _
                      From c In ords.DefaultIfEmpty _
                      Where p.idDocumento = strDocumentoAfectado _
                      Group c By _
                      p.idCuota, p.referencia, p.estadoPago, p.montoSoles, p.montoDolares,
                       p.fechaPlazo, p.fechaVcto _
                      Into g = Group _
                      Select New With {.idcuota = idCuota,
                                       .referencia = referencia,
                                       .deudaMonto = montoSoles,
                                       .deudaMontoME = montoDolares,
                                        .estadoPago = estadoPago,
                                        .fechaplazo = fechaPlazo,
                                       .fechavcto = fechaVcto
                                   }
                               ).ToList

        Dim ncMN As Decimal = 0
        Dim ncME As Decimal = 0
        Dim ndMN As Decimal = 0
        Dim ndME As Decimal = 0
        For Each obj In consulta2


            If obj.fechaPlazo < DateTime.Now And obj.estadoPago = "PN" Then
                objMostrarEncaja = New documentoCajaDetalle() With _
                                   {
                                       .secuencia = obj.idcuota, _
                                       .referencia = obj.referencia,
                                         .DeudaMonto = IIf(IsDBNull(obj.deudaMonto), 0, obj.deudaMonto), _
                                        .DeudaMontoME = IIf(IsDBNull(obj.deudaMontoME), 0, obj.deudaMontoME), _
                                       .EstadoCobro = obj.estadoPago, _
                                         .fechaPlazo = obj.fechaplazo, _
                                       .fechaVcto = obj.fechavcto
                                    }

            Else
                objMostrarEncaja = New documentoCajaDetalle() With _
                                   {
                                       .secuencia = obj.idcuota, _
                                       .referencia = obj.referencia, _
                                         .DeudaMonto = IIf(IsDBNull(obj.deudaMonto), 0, obj.deudaMonto), _
                                        .DeudaMontoME = IIf(IsDBNull(obj.deudaMontoME), 0, obj.deudaMontoME), _
                                         .DeudaMora = CDec(0.0), _
                                         .DeudaMoraME = CDec(0.0), _
                                        .DeudaComp = CDec(0.0), _
                                         .DeudaCompME = CDec(0.0), _
                                        .DeudaMorOtro = CDec(0.0), _
                                         .DeudaMorOtroMe = CDec(0.0), _
                                        .DeudaMorOtro1 = CDec(0.0), _
                                         .DeudaMorOtro1ME = CDec(0.0), _
                                       .fechaPlazo = obj.fechaplazo, _
                                       .EstadoCobro = obj.estadoPago, _
                                       .fechaVcto = obj.fechavcto
                                    }
            End If


            ListaDetalle.Add(objMostrarEncaja)
        Next
        Return ListaDetalle
    End Function


    Public Function ListarDetallePagosXcodigoLibro(caja As documentoCaja) As List(Of documentoCajaDetalle)
        Dim obj As New documentoCajaDetalle
        Dim lista As New List(Of documentoCajaDetalle)
        Try
            Dim consulta = (From n In HeliosData.documentoCaja _
                    Join det In HeliosData.documentoCajaDetalle _
                    On n.idDocumento Equals det.idDocumento _
                    Where n.idEmpresa = caja.idEmpresa AndAlso n.idEstablecimiento = caja.idEstablecimiento _
                    AndAlso n.codigoLibro = caja.codigoLibro).ToList

            For Each i In consulta
                obj = New documentoCajaDetalle
                obj.tipoDocumento = i.n.tipoDocPago
                obj.numeroDoc = i.n.numeroDoc
                obj.moneda = i.n.moneda
                obj.DetalleItem = i.det.DetalleItem
                obj.montoSoles = i.det.montoSoles
                obj.montoUsd = i.det.montoUsd
                obj.documentoAfectado = i.det.documentoAfectado
                lista.Add(obj)
            Next
            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListadoCajaDetalleHijos(intIdDocumento As Integer) As List(Of documentoCajaDetalle)
        Dim lista As New List(Of documentoCajaDetalle)
        Dim a As New documentoCajaDetalle

        Dim cc = (From c In HeliosData.documentoCajaDetalle _
                 Where c.documentoAfectado = intIdDocumento).ToList


        For Each i In cc
            a = New documentoCajaDetalle
            a.idDocumento = i.idDocumento
            a.DetalleItem = i.DetalleItem
            a.montoSoles = i.montoSoles
            a.montoUsd = i.montoUsd

            lista.Add(a)
        Next

        Return lista
    End Function

    Public Function ReportePagosDetalladoPorCliente(fecINic As DateTime, fecHAsta As DateTime, idClie As Integer, MetodoPago As String) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)

        If idClie = -1 Then
            Dim coN = (From c In HeliosData.documentoCaja _
                Join cd In HeliosData.documentoCajaDetalle _
                On c.idDocumento Equals cd.idDocumento _
                Join venta In HeliosData.documentoventaAbarrotes _
                On venta.idDocumento Equals cd.documentoAfectado _
                Join e In HeliosData.entidad _
                On e.idEntidad Equals venta.idCliente _
                Where venta.idEmpresa = Gempresas.IdEmpresaRuc _
                And c.fechaCobro >= fecINic And c.fechaCobro <= fecHAsta _
                    And c.tipoDocPago = MetodoPago Order By e.nombreCompleto).ToList


            For Each obj In coN

                objMostrarEncaja = New documentoCajaDetalle() With _
                                   {
                                       .idItem = obj.venta.tipoDocumento, _
                                       .serie = obj.venta.serie, _
                                       .numeroDoc = IIf(IsDBNull(obj.venta.numeroDoc), Nothing, obj.venta.numeroDoc), _
                                       .fecha = obj.venta.fechaDoc, _
                                       .usuarioModificacion = obj.e.nombreCompleto, _
                                       .entregado = obj.c.tipoDocPago, _
                                       .DetalleItem = obj.cd.DetalleItem, _
                                       .montoSoles = obj.cd.montoSoles, _
                                       .montoUsd = obj.cd.montoUsd _
                                    }
                ListaDetalle.Add(objMostrarEncaja)
            Next

        Else

            Dim coN = (From c In HeliosData.documentoCaja _
                Join cd In HeliosData.documentoCajaDetalle _
                On c.idDocumento Equals cd.idDocumento _
                Join venta In HeliosData.documentoventaAbarrotes _
                On venta.idDocumento Equals cd.documentoAfectado _
                Join e In HeliosData.entidad _
                On e.idEntidad Equals venta.idCliente _
                Where venta.idEmpresa = Gempresas.IdEmpresaRuc _
                And c.fechaCobro >= fecINic And c.fechaCobro <= fecHAsta And venta.idCliente = idClie _
                    And c.tipoDocPago = MetodoPago).ToList



            For Each obj In coN

                objMostrarEncaja = New documentoCajaDetalle() With _
                                    {
                                       .idItem = obj.venta.tipoDocumento, _
                                       .serie = obj.venta.serie, _
                                       .numeroDoc = IIf(IsDBNull(obj.venta.numeroDoc), Nothing, obj.venta.numeroDoc), _
                                       .fecha = obj.venta.fechaDoc, _
                                       .usuarioModificacion = obj.e.nombreCompleto, _
                                       .entregado = obj.c.tipoDocPago, _
                                       .DetalleItem = obj.cd.DetalleItem, _
                                       .montoSoles = obj.cd.montoSoles, _
                                       .montoUsd = obj.cd.montoUsd _
                                    }
                ListaDetalle.Add(objMostrarEncaja)
            Next
        End If


        Return ListaDetalle
    End Function

    Public Function ReporteCuentasPorCobrarPorCliente(fecINic As DateTime, fecHAsta As DateTime, idProv As Integer, MetodoPago As String) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)

        If idProv = -1 Then
            Dim coN = From c In HeliosData.documentoCaja _
                Join cd In HeliosData.documentoCajaDetalle _
                On c.idDocumento Equals cd.idDocumento _
                Join venta In HeliosData.documentoventaAbarrotes _
                On venta.idDocumento Equals cd.documentoAfectado _
                Join e In HeliosData.entidad _
                On e.idEntidad Equals venta.idCliente _
                Where venta.idEmpresa = Gempresas.IdEmpresaRuc _
                And c.fechaCobro >= fecINic And c.fechaCobro <= fecHAsta _
                    And c.tipoDocPago = MetodoPago Order By e.nombreCompleto _
                    Group cd By _
                    venta.tipoDocumento, venta.serie, venta.numeroDoc, e.nombreCompleto,
      c.fechaCobro, c.tipoDocPago,
      venta.fechaDoc, venta.ImporteNacional, venta.ImporteExtranjero
                    Into g = Group Select New With {.tipoDoc = tipoDocumento,
                                     .serie = serie,
                                     .Numero = numeroDoc,
                                     .FechaPago = fechaCobro,
                                     .Proveedor = nombreCompleto,
                                     .tipoDocPago = tipoDocPago,
                                     .FechaCompra = fechaDoc,
                                     .ImporteDeudaSoles = ImporteNacional,
                                     .ImporteDeudaUSD = ImporteExtranjero,
                                      .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
                                      .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd)
                                    }


            For Each obj In coN

                objMostrarEncaja = New documentoCajaDetalle() With _
                                   {
                                       .idItem = obj.tipoDoc, _
                                       .serie = obj.serie, _
                                       .numeroDoc = IIf(IsDBNull(obj.Numero), Nothing, obj.Numero), _
                                       .fecha = obj.FechaPago, _
                                       .entregado = obj.Proveedor, _
                                       .usuarioModificacion = obj.tipoDocPago, _
                                       .fechaModificacion = obj.FechaCompra, _
                                    .montoSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles), _
                                    .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD), _
                                    .montoUsd = IIf(IsDBNull(obj.TotalImportePagadoSoles), 0, obj.TotalImportePagadoSoles), _
                                    .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares), 0, obj.TotalImportePagadoDolares)
                                    }
                ListaDetalle.Add(objMostrarEncaja)
            Next

        Else

            Dim coN = From c In HeliosData.documentoCaja _
                Join cd In HeliosData.documentoCajaDetalle _
                On c.idDocumento Equals cd.idDocumento _
                Join venta In HeliosData.documentoventaAbarrotes _
                On venta.idDocumento Equals cd.documentoAfectado _
                Join e In HeliosData.entidad _
                On e.idEntidad Equals venta.idCliente _
                Where venta.idEmpresa = Gempresas.IdEmpresaRuc _
                And c.fechaCobro >= fecINic And c.fechaCobro <= fecHAsta And venta.idCliente = idProv _
                    And c.tipoDocPago = MetodoPago _
                    Group c By _
                    venta.tipoDocumento, venta.serie, venta.numeroDoc, e.nombreCompleto,
      c.fechaCobro, c.tipoDocPago,
      venta.fechaDoc, venta.ImporteNacional, venta.ImporteExtranjero
                    Into g = Group Select New With {.tipoDoc = tipoDocumento,
                                     .serie = serie,
                                     .Numero = numeroDoc,
                                     .FechaPago = fechaCobro,
                                     .Proveedor = nombreCompleto,
                                     .tipoDocPago = tipoDocPago,
                                     .FechaCompra = fechaDoc,
                                     .ImporteDeudaSoles = ImporteNacional,
                                     .ImporteDeudaUSD = ImporteExtranjero,
                                      g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
                                      .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd)
                                    }


            For Each obj In coN

                objMostrarEncaja = New documentoCajaDetalle() With _
                                   {
                                       .idItem = obj.tipoDoc, _
                                       .serie = obj.serie, _
                                       .numeroDoc = IIf(IsDBNull(obj.Numero), Nothing, obj.Numero), _
                                       .fecha = obj.FechaPago, _
                                       .entregado = obj.Proveedor, _
                                       .usuarioModificacion = obj.tipoDocPago, _
                                       .fechaModificacion = obj.FechaCompra, _
                                    .montoSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles), _
                                    .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD), _
                                    .montoUsd = IIf(IsDBNull(obj.TotalImportePagadoSoles), 0, obj.TotalImportePagadoSoles), _
                                    .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares), 0, obj.TotalImportePagadoDolares)
                                    }
                ListaDetalle.Add(objMostrarEncaja)
            Next
        End If


        Return ListaDetalle
    End Function

    Public Function InsertCajaDetalleSL(ByVal i As documentoCajaDetalle, intIdDocumentoCaja As Integer, intIdCompra As Integer) As Integer
        Dim nDetalle As New documentoCajaDetalle
        Using ts As New TransactionScope

            nDetalle = New documentoCajaDetalle
            nDetalle.idDocumento = intIdDocumentoCaja
            nDetalle.documentoAfectado = intIdCompra
            nDetalle.secuencia = i.secuencia
            nDetalle.fecha = i.fecha
            nDetalle.idItem = i.idItem
            nDetalle.DetalleItem = i.DetalleItem
            nDetalle.montoSoles = i.montoSoles
            nDetalle.montoUsd = i.montoUsd
            nDetalle.entregado = i.entregado
            nDetalle.diferTipoCambio = i.diferTipoCambio
            nDetalle.usuarioModificacion = i.usuarioModificacion
            nDetalle.fechaModificacion = i.fechaModificacion
            HeliosData.documentoCajaDetalle.Add(nDetalle)
            HeliosData.SaveChanges()
            ts.Complete()
            Return nDetalle.secuencia
        End Using
    End Function

    Public Function InsertarNuevaFila(ByVal i As documentoCajaDetalle) As Integer
        Dim nDetalle As New documentoCajaDetalle
        Using ts As New TransactionScope

            nDetalle = New documentoCajaDetalle
            nDetalle.idDocumento = i.idDocumento
            nDetalle.entidadFinanciera = i.entidadFinanciera
            nDetalle.documentoAfectado = i.documentoAfectado
            nDetalle.secuencia = i.secuencia
            nDetalle.fecha = i.fecha
            nDetalle.idItem = i.idItem
            nDetalle.DetalleItem = i.DetalleItem
            nDetalle.montoSoles = i.montoSoles
            nDetalle.montoUsd = i.montoUsd
            nDetalle.entregado = i.entregado
            nDetalle.diferTipoCambio = i.diferTipoCambio
            nDetalle.usuarioModificacion = i.usuarioModificacion
            nDetalle.fechaModificacion = i.fechaModificacion
            HeliosData.documentoCajaDetalle.Add(nDetalle)
            HeliosData.SaveChanges()
            ts.Complete()
            Return nDetalle.secuencia
        End Using
    End Function

    Public Function ConsultaEstadoPago(intIDDOcumentoCompra As Integer) As documentoCajaDetalle
        Dim detalle As New documentoCajaDetalle
        Dim xCobrado = Aggregate x In HeliosData.documentoCajaDetalle _
                             Where x.documentoAfectado = intIDDOcumentoCompra _
             Into impMN = Sum(x.montoSoles), _
                  impME = Sum(x.montoUsd)

        detalle.ImporteNacional = xCobrado.impMN.GetValueOrDefault
        detalle.ImporteExtranjero = xCobrado.impME.GetValueOrDefault
        Return detalle
    End Function

    'Public Function ObtenerCuentasPorCobrarPorDetails(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)
    '    Dim objMostrarEncaja As New documentoCajaDetalle
    '    Dim ListaDetalle As New List(Of documentoCajaDetalle)

    '    Dim consulta = (From p In HeliosData.documentoventaAbarrotesDet _
    '                   Group Join c In HeliosData.documentoCajaDetalle _
    '                  On p.idDocumento Equals c.documentoAfectado _
    '                  And p.idItem Equals c.idItem _
    '                  Into ords = Group _
    '                  From c In ords.DefaultIfEmpty _
    '                  Where p.idDocumento = strDocumentoAfectado _
    '                  Group c By _
    '                  p.idItem, p.nombreItem, p.importeMN, p.importeME _
    '                  Into g = Group _
    '                  Select New With {.iditem = idItem,
    '                                   .Descripcion = nombreItem,
    '                                   .ImporteDeudaSoles = importeMN,
    '                                   .ImporteDeudaUSD = importeME,
    '                                    g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
    '                                    .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd)
    '                               }
    '                           )

    '    For Each obj In consulta
    '        objMostrarEncaja = New documentoCajaDetalle() With _
    '                           {
    '                            .idItem = obj.iditem, _
    '                            .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion), _
    '                            .MontoDeudaSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles), _
    '                            .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD), _
    '                            .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles), 0, obj.TotalImportePagadoSoles), _
    '                            .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares), 0, obj.TotalImportePagadoDolares) _
    '                            }
    '        ListaDetalle.Add(objMostrarEncaja)
    '    Next
    '    Return ListaDetalle
    'End Function

    Private Function SumaNotas(intSecuencia As Integer, strCodigoNota As String) As documentoCajaDetalle
        Dim detalle As New documentoCajaDetalle

        Dim totals3 = Aggregate p In HeliosData.documentocompradetalle _
               Join compra In HeliosData.documentocompra _
               On p.idDocumento Equals compra.idDocumento _
                          Where p.idPadreDTCompra = intSecuencia _
                          And compra.tipoDoc = strCodigoNota
          Into mn = Sum(p.importe), _
               mne = Sum(p.importeUS)

        detalle.ImporteNacional = totals3.mn
        detalle.ImporteExtranjero = totals3.mne
        Return detalle
    End Function

    Public Function ObtenerCuentasPorPagarPorDetails(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)

        Dim consulta2 = (From compradet In HeliosData.documentocompradetalle _
                        Group Join caja In HeliosData.documentoCajaDetalle _
                         On compradet.idDocumento Equals caja.documentoAfectado _
                         And compradet.secuencia Equals caja.documentoAfectadodetalle _
                         Into ords = Group _
                      From c In ords.DefaultIfEmpty _
                      Where compradet.idDocumento = strDocumentoAfectado _
                      Group c By _
                      compradet.secuencia, compradet.destino, compradet.tipoExistencia,
                      compradet.idItem, compradet.descripcionItem, compradet.importe, compradet.importeUS,
                      compradet.bonificacion, compradet.monto1, compradet.almacenRef, compradet.montokardex, compradet.montokardexUS,
                      compradet.montoIgv, compradet.montoIgvUS, compradet.estadoPago _
                      Into g = Group _
                      Select New With {.iditem = idItem,
                                       .Descripcion = descripcionItem,
                                       .ImporteDeudaSoles = importe,
                                       .ImporteDeudaUSD = importeUS,
                                        g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
                                        .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
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

        'Dim consulta2 = (From compradet In HeliosData.documentocompradetalle _
        '                Group Join caja In HeliosData.documentoCajaDetalle _
        '                 On compradet.idDocumento Equals caja.documentoAfectado _
        '                 And compradet.secuencia Equals caja.documentoAfectadodetalle _
        '                 Into ords = Group _
        '              From c In ords.DefaultIfEmpty _
        '              Where compradet.idDocumento = strDocumentoAfectado And compradet.bonificacion <> "S" _
        '              Group c By _
        '              compradet.secuencia, compradet.destino, compradet.tipoExistencia,
        '              compradet.idItem, compradet.descripcionItem, compradet.importe, compradet.importeUS,
        '              compradet.bonificacion, compradet.monto1, compradet.almacenRef, compradet.montokardex, compradet.montokardexUS,
        '              compradet.montoIgv, compradet.montoIgvUS, compradet.estadoPago _
        '              Into g = Group _
        '              Select New With {.iditem = idItem,
        '                               .Descripcion = descripcionItem,
        '                               .ImporteDeudaSoles = importe,
        '                               .ImporteDeudaUSD = importeUS,
        '                                g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
        '                                .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
        '                               .bonificacion = bonificacion,
        '                               .secuencia = secuencia,
        '                               .destino = destino,
        '                               .tipoex = tipoExistencia,
        '                               .cantidad = monto1,
        '                               .almacenRef = almacenRef,
        '                               .montokardex = montokardex,
        '                               .montokardexus = montokardexUS,
        '                               .montoIgv = montoIgv,
        '                               .montoIgvUS = montoIgvUS,
        '                               .estadoPago = estadoPago
        '                           }
        '                       ).ToList

        Dim ncMN As Decimal = 0
        Dim ncME As Decimal = 0
        Dim ndMN As Decimal = 0
        Dim ndME As Decimal = 0
        For Each obj In consulta2
            'If obj.bonificacion = "S" Then

            'End If
            objMostrarEncaja = New documentoCajaDetalle() With _
                               {
                                   .secuencia = obj.secuencia, _
                                .idItem = obj.iditem, _
                                .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion), _
                                .MontoDeudaSoles = obj.ImporteDeudaSoles.GetValueOrDefault,
                                .MontoDeudaUSD = obj.ImporteDeudaUSD.GetValueOrDefault,
                                .MontoPagadoSoles = obj.TotalImportePagadoSoles.GetValueOrDefault,
                                .MontoPagadoUSD = obj.TotalImportePagadoDolares.GetValueOrDefault,
                                .bonificacion = obj.bonificacion, _
                                   .destino = obj.destino, _
                                   .TipoExistencia = obj.tipoex,
                                   .CantidadCompra = obj.cantidad.GetValueOrDefault,
                                   .montokardex = obj.montokardex.GetValueOrDefault,
                                   .montokardexus = obj.montokardexus.GetValueOrDefault,
                                   .montoIgv = obj.montoIgv.GetValueOrDefault,
                                   .montoIgvUS = obj.montoIgvUS.GetValueOrDefault,
                                   .almacenRef = obj.almacenRef.GetValueOrDefault,
                                   .EstadoCobro = obj.estadoPago
                                }
            ListaDetalle.Add(objMostrarEncaja)
        Next
        Return ListaDetalle
    End Function


    Public Function ObtenerCuentasPorPagarPorDetailsME(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)

        Dim consulta2 = (From compradet In HeliosData.documentocompradetalle _
                        Group Join caja In HeliosData.documentoCajaDetalle _
                         On compradet.idDocumento Equals caja.documentoAfectado _
                         And compradet.secuencia Equals caja.documentoAfectadodetalle _
                         Into ords = Group _
                      From c In ords.DefaultIfEmpty _
                      Where compradet.idDocumento = strDocumentoAfectado And compradet.bonificacion <> "S" _
                      Group c By _
                      compradet.secuencia, compradet.destino, compradet.tipoExistencia,
                      compradet.idItem, compradet.descripcionItem, compradet.importe, compradet.importeUS,
                      compradet.bonificacion, compradet.monto1, compradet.almacenRef, compradet.montokardex, compradet.montokardexUS,
                      compradet.montoIgv, compradet.montoIgvUS, compradet.estadoPago _
                      Into g = Group _
                      Select New With {.iditem = idItem,
                                       .Descripcion = descripcionItem,
                                       .ImporteDeudaSoles = importe,
                                       .ImporteDeudaUSD = importeUS,
                                        g, .TotalImportePagadoSolesTransac = g.Sum(Function(c) c.montoSolesTransacc),
                                       .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
                                        .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
                                          .TotalImportePagadoUSDTransac = g.Sum(Function(c) c.montoUsdTransacc),
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

            objMostrarEncaja = New documentoCajaDetalle() With _
                               {
                                   .secuencia = obj.secuencia, _
                                .idItem = obj.iditem, _
                                .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion), _
                                .MontoDeudaSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles), _
                                .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD), _
                                .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles.GetValueOrDefault), 0, obj.TotalImportePagadoSoles.GetValueOrDefault), _
                                .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares.GetValueOrDefault), 0, obj.TotalImportePagadoDolares.GetValueOrDefault), _
                                  .montoSolesTransacc = IIf(IsDBNull(obj.TotalImportePagadoSolesTransac.GetValueOrDefault), 0, obj.TotalImportePagadoSolesTransac.GetValueOrDefault), _
                                .montoUsdTransacc = IIf(IsDBNull(obj.TotalImportePagadoUSDTransac.GetValueOrDefault), 0, obj.TotalImportePagadoUSDTransac.GetValueOrDefault), _
                                .bonificacion = obj.bonificacion, _
                                   .destino = obj.destino, _
                                   .TipoExistencia = obj.tipoex,
                                   .CantidadCompra = obj.cantidad.GetValueOrDefault,
                                   .montokardex = obj.montokardex.GetValueOrDefault,
                                   .montokardexus = obj.montokardexus.GetValueOrDefault,
                                   .montoIgv = obj.montoIgv.GetValueOrDefault,
                                   .montoIgvUS = obj.montoIgvUS.GetValueOrDefault,
                                   .almacenRef = IIf(IsDBNull(obj.almacenRef), 0, obj.almacenRef),
            .EstadoCobro = obj.estadoPago}
            ListaDetalle.Add(objMostrarEncaja)
        Next
        Return ListaDetalle
    End Function


    Public Function ObtenerCuentasPorPagarBySecuencia(strItemAfectado As Integer) As documentoCajaDetalle
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)

        Dim obj = (From compradet In HeliosData.documentocompradetalle
                   Group Join caja In HeliosData.documentoCajaDetalle
                        On compradet.idDocumento Equals caja.documentoAfectado _
                        And compradet.secuencia Equals caja.documentoAfectadodetalle
                        Into ords = Group
                   From c In ords.DefaultIfEmpty
                   Where compradet.secuencia = strItemAfectado
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
                                       g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
                                       .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
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
                              ).FirstOrDefault

        'Dim obj = (From compradet In HeliosData.documentocompradetalle _
        '                Group Join caja In HeliosData.documentoCajaDetalle _
        '                 On compradet.idDocumento Equals caja.documentoAfectado _
        '                 And compradet.secuencia Equals caja.documentoAfectadodetalle _
        '                 Into ords = Group _
        '              From c In ords.DefaultIfEmpty _
        '              Where compradet.secuencia = strItemAfectado And compradet.bonificacion <> "S" _
        '              Group c By _
        '              compradet.secuencia, compradet.destino, compradet.tipoExistencia,
        '              compradet.idItem, compradet.descripcionItem, compradet.importe, compradet.importeUS,
        '              compradet.bonificacion, compradet.monto1, compradet.almacenRef, compradet.montokardex, compradet.montokardexUS,
        '              compradet.montoIgv, compradet.montoIgvUS, compradet.estadoPago _
        '              Into g = Group _
        '              Select New With {.iditem = idItem,
        '                               .Descripcion = descripcionItem,
        '                               .ImporteDeudaSoles = importe,
        '                               .ImporteDeudaUSD = importeUS,
        '                                g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
        '                                .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
        '                               .bonificacion = bonificacion,
        '                               .secuencia = secuencia,
        '                               .destino = destino,
        '                               .tipoex = tipoExistencia,
        '                               .cantidad = monto1,
        '                               .almacenRef = almacenRef,
        '                               .montokardex = montokardex,
        '                               .montokardexus = montokardexUS,
        '                               .montoIgv = montoIgv,
        '                               .montoIgvUS = montoIgvUS,
        '                               .estadoPago = estadoPago
        '                           }
        '                       ).FirstOrDefault

        Dim ncMN As Decimal = 0
        Dim ncME As Decimal = 0
        Dim ndMN As Decimal = 0
        Dim ndME As Decimal = 0

        objMostrarEncaja = New documentoCajaDetalle() With
                           {
                               .secuencia = obj.secuencia,
                            .idItem = obj.iditem,
                            .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion),
                            .MontoDeudaSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles),
                            .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD),
                            .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles.GetValueOrDefault), 0, obj.TotalImportePagadoSoles.GetValueOrDefault),
                            .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares.GetValueOrDefault), 0, obj.TotalImportePagadoDolares.GetValueOrDefault),
        .bonificacion = obj.bonificacion,
                               .destino = obj.destino,
                               .TipoExistencia = obj.tipoex,
                               .CantidadCompra = obj.cantidad.GetValueOrDefault,
                               .montokardex = obj.montokardex.GetValueOrDefault,
                               .montokardexus = obj.montokardexus.GetValueOrDefault,
                               .montoIgv = obj.montoIgv.GetValueOrDefault,
                               .montoIgvUS = obj.montoIgvUS.GetValueOrDefault,
                               .almacenRef = IIf(IsDBNull(obj.almacenRef), 0, obj.almacenRef),
                               .EstadoCobro = obj.estadoPago
                            }

        Return objMostrarEncaja
    End Function
    'Public Function ObtenerCuentasPorPagarBySecuencia(strItemAfectado As Integer) As documentoCajaDetalle
    '    Dim objMostrarEncaja As New documentoCajaDetalle
    '    Dim ListaDetalle As New List(Of documentoCajaDetalle)

    '    Dim obj = (From compradet In HeliosData.documentocompradetalle _
    '                   Group Join caja In HeliosData.documentoCajaDetalle _
    '                    On compradet.idDocumento Equals caja.documentoAfectado _
    '                    And compradet.secuencia Equals caja.documentoAfectadodetalle _
    '                    Into ords = Group _
    '                 From c In ords.DefaultIfEmpty _
    '                 Where compradet.secuencia = strItemAfectado _
    '                 Group c By _
    '                 compradet.secuencia, compradet.destino, compradet.tipoExistencia,
    '                 compradet.idItem, compradet.descripcionItem, compradet.importe, compradet.importeUS,
    '                 compradet.bonificacion, compradet.monto1, compradet.almacenRef, compradet.montokardex, compradet.montokardexUS,
    '                 compradet.montoIgv, compradet.montoIgvUS, compradet.estadoPago _
    '                 Into g = Group _
    '                 Select New With {.iditem = idItem,
    '                                  .Descripcion = descripcionItem,
    '                                  .ImporteDeudaSoles = importe,
    '                                  .ImporteDeudaUSD = importeUS,
    '                                   g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
    '                                   .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
    '                                  .bonificacion = bonificacion,
    '                                  .secuencia = secuencia,
    '                                  .destino = destino,
    '                                  .tipoex = tipoExistencia,
    '                                  .cantidad = monto1,
    '                                  .almacenRef = almacenRef,
    '                                  .montokardex = montokardex,
    '                                  .montokardexus = montokardexUS,
    '                                  .montoIgv = montoIgv,
    '                                  .montoIgvUS = montoIgvUS,
    '                                  .estadoPago = estadoPago
    '                              }
    '                          ).FirstOrDefault

    '    'Dim obj = (From compradet In HeliosData.documentocompradetalle _
    '    '                Group Join caja In HeliosData.documentoCajaDetalle _
    '    '                 On compradet.idDocumento Equals caja.documentoAfectado _
    '    '                 And compradet.secuencia Equals caja.documentoAfectadodetalle _
    '    '                 Into ords = Group _
    '    '              From c In ords.DefaultIfEmpty _
    '    '              Where compradet.secuencia = strItemAfectado And compradet.bonificacion <> "S" _
    '    '              Group c By _
    '    '              compradet.secuencia, compradet.destino, compradet.tipoExistencia,
    '    '              compradet.idItem, compradet.descripcionItem, compradet.importe, compradet.importeUS,
    '    '              compradet.bonificacion, compradet.monto1, compradet.almacenRef, compradet.montokardex, compradet.montokardexUS,
    '    '              compradet.montoIgv, compradet.montoIgvUS, compradet.estadoPago _
    '    '              Into g = Group _
    '    '              Select New With {.iditem = idItem,
    '    '                               .Descripcion = descripcionItem,
    '    '                               .ImporteDeudaSoles = importe,
    '    '                               .ImporteDeudaUSD = importeUS,
    '    '                                g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
    '    '                                .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
    '    '                               .bonificacion = bonificacion,
    '    '                               .secuencia = secuencia,
    '    '                               .destino = destino,
    '    '                               .tipoex = tipoExistencia,
    '    '                               .cantidad = monto1,
    '    '                               .almacenRef = almacenRef,
    '    '                               .montokardex = montokardex,
    '    '                               .montokardexus = montokardexUS,
    '    '                               .montoIgv = montoIgv,
    '    '                               .montoIgvUS = montoIgvUS,
    '    '                               .estadoPago = estadoPago
    '    '                           }
    '    '                       ).FirstOrDefault

    '    Dim ncMN As Decimal = 0
    '    Dim ncME As Decimal = 0
    '    Dim ndMN As Decimal = 0
    '    Dim ndME As Decimal = 0

    '    objMostrarEncaja = New documentoCajaDetalle() With _
    '                       {
    '                           .secuencia = obj.secuencia, _
    '                        .idItem = obj.iditem, _
    '                        .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion), _
    '                        .MontoDeudaSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles), _
    '                        .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD), _
    '                        .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles.GetValueOrDefault), 0, obj.TotalImportePagadoSoles.GetValueOrDefault), _
    '                        .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares.GetValueOrDefault), 0, obj.TotalImportePagadoDolares.GetValueOrDefault), _
    '                        .bonificacion = obj.bonificacion, _
    '                           .destino = obj.destino, _
    '                           .TipoExistencia = obj.tipoex,
    '                           .CantidadCompra = obj.cantidad.GetValueOrDefault,
    '                           .montokardex = obj.montokardex.GetValueOrDefault,
    '                           .montokardexus = obj.montokardexus.GetValueOrDefault,
    '                           .montoIgv = obj.montoIgv.GetValueOrDefault,
    '                           .montoIgvUS = obj.montoIgvUS.GetValueOrDefault,
    '                           .almacenRef = IIf(IsDBNull(obj.almacenRef), 0, obj.almacenRef),
    '                           .EstadoCobro = obj.estadoPago
    '                        }

    '    Return objMostrarEncaja
    'End Function

    Public Function ReporteCuentasPorPagarPorProveedor(fecINic As DateTime, fecHAsta As DateTime, idProv As Integer, MetodoPago As String) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)

        If idProv = -1 Then
            Dim coN = From c In HeliosData.documentoCaja _
                Join cd In HeliosData.documentoCajaDetalle _
                On c.idDocumento Equals cd.idDocumento _
                Join compra In HeliosData.documentocompra _
                On compra.idDocumento Equals cd.documentoAfectado _
                Join e In HeliosData.entidad _
                On e.idEntidad Equals compra.idProveedor _
                Where compra.idEmpresa = Gempresas.IdEmpresaRuc _
                And c.fechaCobro >= fecINic And c.fechaCobro <= fecHAsta _
                    And c.tipoDocPago = MetodoPago Order By e.nombreCompleto _
                    Group cd By _
                    compra.tipoDoc, compra.serie, compra.numeroDoc, e.nombreCompleto,
      c.fechaCobro, c.tipoDocPago,
      compra.fechaDoc, compra.importeTotal, compra.importeUS
                    Into g = Group Select New With {.tipoDoc = tipoDoc,
                                     .serie = serie,
                                     .Numero = numeroDoc,
                                     .FechaPago = fechaCobro,
                                     .Proveedor = nombreCompleto,
                                     .tipoDocPago = tipoDocPago,
                                     .FechaCompra = fechaDoc,
                                     .ImporteDeudaSoles = importeTotal,
                                     .ImporteDeudaUSD = importeUS,
                                      .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
                                      .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd)
                                    }


            For Each obj In coN

                objMostrarEncaja = New documentoCajaDetalle() With _
                                   {
                                       .tipoDocumento = obj.tipoDoc, _
                                       .serie = obj.serie, _
                                       .numeroDoc = IIf(IsDBNull(obj.Numero), Nothing, obj.Numero), _
                                       .fecha = obj.FechaPago, _
                                       .entregado = obj.Proveedor, _
                                       .TipoExistencia = obj.tipoDocPago, _
                                       .fechaDoc = obj.FechaCompra, _
                                    .MontoDeudaSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles), _
                                    .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD), _
                                    .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles), 0, obj.TotalImportePagadoSoles), _
                                    .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares), 0, obj.TotalImportePagadoDolares)
                                    }
                ListaDetalle.Add(objMostrarEncaja)
            Next

        Else

            Dim coN = From c In HeliosData.documentoCaja _
                Join cd In HeliosData.documentoCajaDetalle _
                On c.idDocumento Equals cd.idDocumento _
                Join compra In HeliosData.documentocompra _
                On compra.idDocumento Equals cd.documentoAfectado _
                Join e In HeliosData.entidad _
                On e.idEntidad Equals compra.idProveedor _
                Where compra.idEmpresa = Gempresas.IdEmpresaRuc _
                And c.fechaCobro >= fecINic And c.fechaCobro <= fecHAsta And compra.idProveedor = idProv _
                    And c.tipoDocPago = MetodoPago _
                    Group c By _
                    compra.tipoDoc, compra.serie, compra.numeroDoc, e.nombreCompleto,
      c.fechaCobro, c.tipoDocPago,
      compra.fechaDoc, compra.importeTotal, compra.importeUS
                    Into g = Group Select New With {.tipoDoc = tipoDoc,
                                     .serie = serie,
                                     .Numero = numeroDoc,
                                     .FechaPago = fechaCobro,
                                     .Proveedor = nombreCompleto,
                                     .tipoDocPago = tipoDocPago,
                                     .FechaCompra = fechaDoc,
                                     .ImporteDeudaSoles = importeTotal,
                                     .ImporteDeudaUSD = importeUS,
                                      g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
                                      .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd)
                                    }


            For Each obj In coN

                objMostrarEncaja = New documentoCajaDetalle() With _
                                   {
                                       .tipoDocumento = obj.tipoDoc, _
                                       .serie = obj.serie, _
                                       .numeroDoc = IIf(IsDBNull(obj.Numero), Nothing, obj.Numero), _
                                       .fecha = obj.FechaPago, _
                                       .entregado = obj.Proveedor, _
                                       .TipoExistencia = obj.tipoDocPago, _
                                       .fechaDoc = obj.FechaCompra, _
                                    .MontoDeudaSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles), _
                                    .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD), _
                                    .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles), 0, obj.TotalImportePagadoSoles), _
                                    .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares), 0, obj.TotalImportePagadoDolares)
                                    }
                ListaDetalle.Add(objMostrarEncaja)
            Next
        End If


        Return ListaDetalle
    End Function

    Public Function ReportePagosDetalladoPorProveedor(fecINic As DateTime, fecHAsta As DateTime, idProv As Integer, MetodoPago As String) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)

        If idProv = -1 Then
            Dim coN = (From c In HeliosData.documentoCaja _
                Join cd In HeliosData.documentoCajaDetalle _
                On c.idDocumento Equals cd.idDocumento _
                Join compra In HeliosData.documentocompra _
                On compra.idDocumento Equals cd.documentoAfectado _
                Join e In HeliosData.entidad _
                On e.idEntidad Equals compra.idProveedor _
                Where compra.idEmpresa = Gempresas.IdEmpresaRuc _
                And c.fechaCobro >= fecINic And c.fechaCobro <= fecHAsta _
                    And c.tipoDocPago = MetodoPago Order By e.nombreCompleto).ToList


            For Each obj In coN

                objMostrarEncaja = New documentoCajaDetalle() With _
                                   {
                                       .tipoDocumento = obj.compra.tipoDoc, _
                                       .serie = obj.compra.serie, _
                                       .numeroDoc = IIf(IsDBNull(obj.compra.numeroDoc), Nothing, obj.compra.numeroDoc), _
                                       .fecha = obj.compra.fechaDoc, _
                                       .entregado = obj.e.nombreCompleto, _
                                       .TipoExistencia = obj.c.tipoDocPago, _
                                       .DetalleItem = obj.cd.DetalleItem, _
                                       .montoSoles = obj.cd.montoSoles, _
                                       .montoUsd = obj.cd.montoUsd _
                                    }
                ListaDetalle.Add(objMostrarEncaja)
            Next

        Else

            Dim coN = (From c In HeliosData.documentoCaja _
                Join cd In HeliosData.documentoCajaDetalle _
                On c.idDocumento Equals cd.idDocumento _
                Join compra In HeliosData.documentocompra _
                On compra.idDocumento Equals cd.documentoAfectado _
                Join e In HeliosData.entidad _
                On e.idEntidad Equals compra.idProveedor _
                Where compra.idEmpresa = Gempresas.IdEmpresaRuc _
                And c.fechaCobro >= fecINic And c.fechaCobro <= fecHAsta And compra.idProveedor = idProv _
                    And c.tipoDocPago = MetodoPago).ToList



            For Each obj In coN

                objMostrarEncaja = New documentoCajaDetalle() With _
                                    {
                                       .tipoDocumento = obj.compra.tipoDoc, _
                                       .serie = obj.compra.serie, _
                                       .numeroDoc = IIf(IsDBNull(obj.compra.numeroDoc), Nothing, obj.compra.numeroDoc), _
                                       .fecha = obj.compra.fechaDoc, _
                                       .entregado = obj.e.nombreCompleto, _
                                       .TipoExistencia = obj.c.tipoDocPago, _
                                       .DetalleItem = obj.cd.DetalleItem, _
                                       .montoSoles = obj.cd.montoSoles, _
                                       .montoUsd = obj.cd.montoUsd _
                                    }
                ListaDetalle.Add(objMostrarEncaja)
            Next
        End If


        Return ListaDetalle
    End Function

    Public Function ObtenerCuentasPorPagarPorDetailsVentas(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)

        Dim consulta2 = (From compradet In HeliosData.documentoventaAbarrotesDet _
                 Group Join caja In HeliosData.documentoCajaDetalle _
                  On compradet.idDocumento Equals caja.documentoAfectado _
                  And compradet.secuencia Equals caja.documentoAfectadodetalle _
                  Into ords = Group _
               From c In ords.DefaultIfEmpty _
               Where compradet.idDocumento = strDocumentoAfectado _
               Group c By _
               compradet.secuencia, compradet.destino, compradet.tipoExistencia,
                      compradet.idItem, compradet.nombreItem, compradet.importeMN, compradet.importeME,
                      compradet.notaCreditoMN, compradet.notaCreditoME,
                      compradet.notaDebitoMN, compradet.notaDebitoME, compradet.monto1,
                      compradet.idAlmacenOrigen, compradet.montokardex, compradet.montokardexUS,
                      compradet.montoIgv, compradet.montoIgvUS, compradet.salidaCostoMN, compradet.salidaCostoME _
               Into g = Group _
              Select New With {.iditem = idItem,
                                       .Descripcion = nombreItem,
                                       .ImporteDeudaSoles = importeMN,
                                       .ImporteDeudaUSD = importeME,
                                        g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
                                        .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
                                       .notaCreditoMN = notaCreditoMN,
                                       .notaCreditoME = notaCreditoME,
                                       .notaDebitoMN = notaDebitoMN,
                                       .notaDebitoME = notaDebitoME,
                                       .secuencia = secuencia,
                                       .destino = destino,
                                       .tipoex = tipoExistencia,
                                       .cantidad = monto1,
                                       .almacenRef = idAlmacenOrigen,
                                       .montokardex = montokardex,
                                       .montokardexus = montokardexUS,
                                       .montoIgv = montoIgv,
                                       .montoIgvUS = montoIgvUS,
                                       .salidaCostoMN = salidaCostoMN,
                                       .salidaCostoME = salidaCostoME
                                   }
                               ).ToList

        'Dim consulta = (From p In HeliosData.documentoventaAbarrotesDet _
        '               Group Join c In HeliosData.documentoCajaDetalle _
        '              On p.idDocumento Equals c.documentoAfectado _
        '              And p.secuencia Equals c.documentoAfectadodetalle _
        '              Into ords = Group _
        '              From c In ords.DefaultIfEmpty _
        '              Where p.idDocumento = strDocumentoAfectado _
        '              Group c By _
        '              p.secuencia, p.destino, p.tipoExistencia,
        '              p.idItem, p.nombreItem, p.importeMN, p.importeME,
        '              p.notaCreditoMN, p.notaCreditoME,
        '              p.notaDebitoMN, p.notaDebitoME, p.monto1, p.idAlmacenOrigen, p.montokardex, p.montokardexUS,
        '              p.montoIgv, p.montoIgvUS, p.salidaCostoMN, p.salidaCostoME _
        '              Into g = Group _
        '              Select New With {.iditem = idItem,
        '                               .Descripcion = nombreItem,
        '                               .ImporteDeudaSoles = importeMN,
        '                               .ImporteDeudaUSD = importeME,
        '                                g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
        '                                .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
        '                               .notaCreditoMN = notaCreditoMN,
        '                               .notaCreditoME = notaCreditoME,
        '                               .notaDebitoMN = notaDebitoMN,
        '                               .notaDebitoME = notaDebitoME,
        '                               .secuencia = secuencia,
        '                               .destino = destino,
        '                               .tipoex = tipoExistencia,
        '                               .cantidad = monto1,
        '                               .almacenRef = idAlmacenOrigen,
        '                               .montokardex = montokardex,
        '                               .montokardexus = montokardexUS,
        '                               .montoIgv = montoIgv,
        '                               .montoIgvUS = montoIgvUS,
        '                               .salidaCostoMN = salidaCostoMN,
        '                               .salidaCostoME = salidaCostoME
        '                           }
        '                       )
        Dim ncMN As Decimal = 0
        Dim ncME As Decimal = 0
        Dim ndMN As Decimal = 0
        Dim ndME As Decimal = 0
        For Each obj In consulta2

            objMostrarEncaja = New documentoCajaDetalle() With _
                               {
                                   .secuencia = obj.secuencia, _
                                .idItem = obj.iditem, _
                                .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion), _
                                .MontoDeudaSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles), _
                                .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD), _
                                .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles), 0, obj.TotalImportePagadoSoles), _
                                .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares), 0, obj.TotalImportePagadoDolares), _
                                .notaCreditoMN = IIf(IsDBNull(obj.notaCreditoMN), 0, obj.notaCreditoMN), _
                                .notaCreditoME = IIf(IsDBNull(obj.notaCreditoME), 0, obj.notaCreditoME), _
                                .notaDebitoMN = IIf(IsDBNull(obj.notaDebitoMN), 0, obj.notaDebitoMN), _
                                .notaDebitoME = IIf(IsDBNull(obj.notaDebitoME), 0, obj.notaDebitoME), _
                                   .destino = obj.destino, _
                                   .TipoExistencia = obj.tipoex,
                                   .CantidadCompra = obj.cantidad,
                                   .montokardex = obj.montokardex,
                                   .montokardexus = obj.montokardexus,
                                   .montoIgv = obj.montoIgv,
                                   .montoIgvUS = obj.montoIgvUS,
                                   .almacenRef = IIf(IsDBNull(obj.almacenRef), 0, obj.almacenRef), _
                                   .salidaCostoMN = obj.salidaCostoMN,
                                   .salidaCostoME = obj.salidaCostoME
                                }
            ListaDetalle.Add(objMostrarEncaja)
        Next
        Return ListaDetalle
    End Function

    Public Function ObtenerPagosAcumPrestamos(strDocumentoAfectado As Integer, srtTipoCobro As String) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim prestamosBL As New prestamosBL
        Dim prestamos As New prestamos
        Dim ListaDetalle As New List(Of documentoCajaDetalle)
        Dim saldo As Decimal = 0

        Dim consulta = (From p In HeliosData.documentoPrestamos _
                        Where p.idDocumento = strDocumentoAfectado _
                                Select p).ToList


        Dim DocEstado = Aggregate x In HeliosData.documentoCajaDetalle _
                            Where x.documentoAfectado = strDocumentoAfectado _
                            And x.entregado = srtTipoCobro _
            Into PagadoMN = Sum(x.montoSoles), _
                 PagadoME = Sum(x.montoUsd)


        prestamos = prestamosBL.UbicarPrestamoXcodigoSingle(consulta(0).idDocumento)

        Select Case srtTipoCobro
            Case "C"
                saldo = prestamos.monto - DocEstado.PagadoMN.GetValueOrDefault
            Case "I"
                saldo = DocEstado.PagadoMN.GetValueOrDefault
        End Select

        If saldo <= 0 Then
            Throw New Exception("El prestamo ya está cancelado!")
        Else
            For Each obj In consulta
                objMostrarEncaja = New documentoCajaDetalle()

                Dim xCobrado = Aggregate x In HeliosData.documentoCajaDetalle _
                                 Where x.documentoAfectado = strDocumentoAfectado _
                                 And x.entregado = srtTipoCobro And x.idItem = obj.idCuota _
                 Into nc = Sum(x.montoSoles), _
                      nce = Sum(x.montoUsd)

                Dim saldox = obj.montoSoles - xCobrado.nc.GetValueOrDefault

                If Not saldox <= 0 Then
                    objMostrarEncaja.idItem = obj.idCuota
                    objMostrarEncaja.DetalleItem = IIf(IsDBNull(obj.referencia), Nothing, obj.referencia)
                    objMostrarEncaja.MontoDeudaSoles = IIf(IsDBNull(obj.montoSoles), 0, obj.montoSoles)
                    objMostrarEncaja.MontoDeudaUSD = IIf(IsDBNull(obj.montoDolares), 0, obj.montoDolares)
                    objMostrarEncaja.MontoPagadoSoles = IIf(IsDBNull(xCobrado.nc), 0, xCobrado.nc)
                    objMostrarEncaja.MontoPagadoUSD = IIf(IsDBNull(xCobrado.nce), 0, xCobrado.nce)
                    ListaDetalle.Add(objMostrarEncaja)
                End If
            Next
            Return ListaDetalle
        End If
    End Function

    Public Function Insert(ByVal documentoCajaDetalleBE As documento, intIdDocumentoCaja As Integer, intIdCompra As Integer) As Integer
        Dim nDetalle As New documentoCajaDetalle
        Dim saldoItem As Decimal = 0
        Dim saldoItemme As Decimal = 0
        Using ts As New TransactionScope

            For Each i In documentoCajaDetalleBE.documentoCaja.documentoCajaDetalle


                nDetalle = New documentoCajaDetalle
                nDetalle.idDocumento = intIdDocumentoCaja
                nDetalle.documentoAfectado = intIdCompra
                nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                nDetalle.secuencia = i.secuencia
                nDetalle.fecha = i.fecha
                nDetalle.idItem = i.idItem
                nDetalle.DetalleItem = i.DetalleItem
                nDetalle.montoSoles = i.montoSoles
                nDetalle.montoSolesTransacc = i.montoSoles
                nDetalle.montoUsd = i.montoUsd
                nDetalle.montoUsdTransacc = i.montoUsd
                nDetalle.entregado = i.entregado
                nDetalle.diferTipoCambio = i.diferTipoCambio
                nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                nDetalle.idCajaUsuario = i.idCajaUsuario
                nDetalle.usuarioModificacion = i.usuarioModificacion
                nDetalle.fechaModificacion = i.fechaModificacion

                HeliosData.documentoCajaDetalle.Add(nDetalle)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
            Return nDetalle.secuencia
        End Using
    End Function

    Public Function InsertarVentaDetallePago(ByVal documentoCajaDetalleBE As documento, intIdDocumentoCaja As Integer, intIdCompra As Integer, secuencia As Integer) As Integer
        Dim nDetalle As New documentoCajaDetalle
        Dim saldoItem As Decimal = 0
        Dim saldoItemme As Decimal = 0
        Using ts As New TransactionScope

            For Each i In documentoCajaDetalleBE.documentoCaja.documentoCajaDetalle


                nDetalle = New documentoCajaDetalle
                nDetalle.idDocumento = intIdDocumentoCaja
                nDetalle.documentoAfectado = intIdCompra
                nDetalle.documentoAfectadodetalle = secuencia 'i.documentoAfectadodetalle
                nDetalle.secuencia = i.secuencia
                nDetalle.fecha = i.fecha
                nDetalle.idItem = i.idItem
                nDetalle.DetalleItem = i.DetalleItem
                nDetalle.montoSoles = i.montoSoles
                nDetalle.montoSolesTransacc = i.montoSoles
                nDetalle.montoUsd = i.montoUsd
                nDetalle.montoUsdTransacc = i.montoUsd
                nDetalle.entregado = i.entregado
                nDetalle.diferTipoCambio = i.diferTipoCambio
                nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                nDetalle.idCajaUsuario = i.idCajaUsuario
                nDetalle.usuarioModificacion = i.usuarioModificacion
                nDetalle.fechaModificacion = i.fechaModificacion

                HeliosData.documentoCajaDetalle.Add(nDetalle)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
            Return nDetalle.secuencia
        End Using
    End Function


    Public Function InsertCajaME(ByVal documentoCajaDetalleBE As documento, intIdDocumentoCaja As Integer, intEntidadFinanciera As Integer) As Integer
        Dim nDocumentoCaja As New documentoCaja
        Dim saldoME As Decimal = 0
        Dim saldoMN As Decimal = 0
        Dim nDetalle As New documentoCajaDetalle

        Using ts As New TransactionScope
            For Each i In documentoCajaDetalleBE.documentoCaja.documentoCajaDetalle

                nDetalle = New documentoCajaDetalle
                nDetalle.idDocumento = intIdDocumentoCaja
                nDetalle.documentoAfectado = intIdDocumentoCaja
                nDetalle.secuencia = i.secuencia
                nDetalle.fecha = i.fecha
                nDetalle.idItem = i.idItem
                nDetalle.DetalleItem = i.DetalleItem
                nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                nDetalle.montoSoles = i.montoSoles
                nDetalle.montoUsd = i.montoUsd
                nDetalle.entregado = i.entregado
                nDetalle.diferTipoCambio = i.diferTipoCambio
                nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                nDetalle.idCajaUsuario = i.idCajaUsuario
                nDetalle.usuarioModificacion = i.usuarioModificacion
                nDetalle.fechaModificacion = i.fechaModificacion
                nDetalle.idCajaUsuario = i.idCajaUsuario
                nDetalle.idCajaPadre = i.idCajaPadre
                HeliosData.documentoCajaDetalle.Add(nDetalle)


                'If (documentoCajaDetalleBE.documentoCaja.tipoMovimiento = MovimientoCaja.EntradaDinero) Then
                '    nDetalle = New documentoCajaDetalle
                '    nDetalle.idDocumento = intIdDocumentoCaja
                '    nDetalle.documentoAfectado = intIdDocumentoCaja
                '    nDetalle.secuencia = i.secuencia
                '    nDetalle.fecha = i.fecha
                '    nDetalle.idItem = i.idItem
                '    nDetalle.DetalleItem = i.DetalleItem
                '    nDetalle.montoSoles = i.montoSoles
                '    nDetalle.montoSolesTransacc = i.montoSolesTransacc
                '    nDetalle.montoUsd = i.montoUsd
                '    nDetalle.montoUsdTransacc = i.montoUsdTransacc
                '    nDetalle.entregado = i.entregado
                '    nDetalle.diferTipoCambio = i.diferTipoCambio
                '    nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                '    nDetalle.usuarioModificacion = i.usuarioModificacion
                '    nDetalle.fechaModificacion = i.fechaModificacion


                '    HeliosData.documentoCajaDetalle.Add(nDetalle)
                'ElseIf (documentoCajaDetalleBE.documentoCaja.tipoMovimiento = MovimientoCaja.SalidaDinero) Then

                '    Dim consultaCaja = (From c In HeliosData.documentoCaja _
                '                        Join d In HeliosData.documentoCajaDetalle _
                '                        On c.idDocumento Equals d.idDocumento _
                '                Where c.tipoMovimiento = "DC" And _
                '                c.entidadFinanciera = intEntidadFinanciera _
                '                Order By d.fecha).ToList

                '    For Each item In consultaCaja

                '        Dim Salidas = (Aggregate n In HeliosData.documentoCaja Join
                '                 d In HeliosData.documentoCajaDetalle On n.idDocumento Equals d.idDocumento _
                '                    Where n.entidadFinanciera = intEntidadFinanciera And n.tipoMovimiento = "PG" And _
                '                    d.idCajaPadre = item.d.idDocumento _
                '                    Into sumMN = Sum(d.montoSoles), sumME = Sum(d.montoUsd))


                '        Select Case i.moneda
                '            Case 1
                '                saldoMN = i.montoSoles
                '                If (saldoMN > 0) Then
                '                    nDetalle = New documentoCajaDetalle
                '                    nDetalle.idDocumento = intIdDocumentoCaja
                '                    nDetalle.documentoAfectado = item.d.secuencia
                '                    nDetalle.secuencia = i.secuencia
                '                    nDetalle.fecha = i.fecha
                '                    nDetalle.idItem = i.idItem
                '                    nDetalle.DetalleItem = i.DetalleItem
                '                    nDetalle.entregado = i.entregado
                '                    nDetalle.idCajaPadre = item.c.idDocumento
                '                    nDetalle.usuarioModificacion = i.usuarioModificacion
                '                    nDetalle.fechaModificacion = i.fechaModificacion
                '                    If ((item.d.montoSoles - Salidas.sumME.GetValueOrDefault) >= i.montoSoles And i.montoSoles = 0) Then
                '                        nDetalle.montoSoles = i.montoSoles
                '                        nDetalle.montoUsd = i.montoUsd
                '                        nDetalle.diferTipoCambio = i.diferTipoCambio
                '                        saldoMN = item.d.montoSoles - i.montoSoles
                '                        i.montoSoles = saldoMN
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                    ElseIf ((item.d.montoSoles - Salidas.sumME.GetValueOrDefault) <= i.montoSoles And i.montoSoles = 0) Then
                '                        nDetalle.montoSoles = i.montoSoles
                '                        nDetalle.montoUsd = i.montoUsd
                '                        nDetalle.diferTipoCambio = i.diferTipoCambio
                '                        saldoMN = item.d.montoSoles - i.montoSoles
                '                        i.montoSoles = saldoMN
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                    ElseIf ((item.d.montoSoles - Salidas.sumME.GetValueOrDefault) < i.montoSoles And i.montoSoles > 0) Then
                '                        nDetalle.montoSoles = item.d.montoSoles
                '                        nDetalle.montoUsd = (item.d.montoUsd - Salidas.sumME.GetValueOrDefault)
                '                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                '                        saldoMN = saldoMN - nDetalle.montoSoles
                '                        i.montoSoles = saldoMN
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                    ElseIf ((item.d.montoSoles - Salidas.sumME.GetValueOrDefault) > i.montoSoles And i.montoSoles > 0) Then
                '                        nDetalle.montoSoles = i.montoSoles
                '                        nDetalle.montoUsd = i.montoUsd
                '                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                '                        saldoMN = saldoMN - i.montoSoles
                '                        i.montoSoles = saldoMN
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                    ElseIf ((item.d.montoSoles - Salidas.sumME.GetValueOrDefault) > i.montoSoles And i.montoSoles < 0) Then
                '                        nDetalle.montoSoles = i.montoSoles
                '                        nDetalle.montoUsd = Math.Round(CDec(i.montoUsd * -1), 2)
                '                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                '                        saldoMN = item.d.montoSoles - i.montoSoles
                '                        i.montoSoles = saldoMN
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                    ElseIf ((item.d.montoSoles - Salidas.sumME.GetValueOrDefault) = i.montoSoles And i.montoSoles > 0) Then
                '                        nDetalle.montoSoles = i.montoSoles
                '                        nDetalle.montoUsd = i.montoUsd
                '                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                '                        saldoMN = saldoMN - i.montoSoles
                '                        i.montoSoles = saldoMN
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                    End If
                '                End If
                '            Case 2
                '                saldoME = i.montoUsd
                '                If (saldoME > 0) Then
                '                    nDetalle = New documentoCajaDetalle
                '                    nDetalle.idDocumento = intIdDocumentoCaja
                '                    nDetalle.documentoAfectado = item.d.secuencia
                '                    nDetalle.secuencia = i.secuencia
                '                    nDetalle.fecha = i.fecha
                '                    nDetalle.idItem = i.idItem
                '                    nDetalle.DetalleItem = i.DetalleItem
                '                    nDetalle.idCajaPadre = item.c.idDocumento
                '                    nDetalle.entregado = i.entregado
                '                    nDetalle.usuarioModificacion = i.usuarioModificacion
                '                    nDetalle.fechaModificacion = i.fechaModificacion
                '                    If ((item.d.montoUsd - Salidas.sumME.GetValueOrDefault) >= i.montoUsd And i.montoUsd = 0) Then
                '                        nDetalle.montoSoles = i.montoSoles
                '                        nDetalle.montoSolesTransacc = CDec(i.montoUsd * i.tipoCambioTransacc).ToString("N2")
                '                        nDetalle.montoUsd = i.montoUsd
                '                        nDetalle.diferTipoCambio = i.diferTipoCambio
                '                        nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                '                        saldoME = item.d.montoUsd - i.montoUsd
                '                        i.montoUsd = saldoME
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                    ElseIf ((item.d.montoUsd - Salidas.sumME.GetValueOrDefault) <= i.montoUsd And i.montoUsd = 0) Then
                '                        nDetalle.montoSoles = i.montoSoles
                '                        nDetalle.montoUsd = i.montoUsd
                '                        nDetalle.montoSolesTransacc = CDec(i.montoUsd * i.tipoCambioTransacc).ToString("N2")
                '                        nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                '                        nDetalle.diferTipoCambio = i.diferTipoCambio
                '                        saldoME = item.d.montoUsd - i.montoUsd
                '                        i.montoUsd = saldoME
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                    ElseIf ((item.d.montoUsd - Salidas.sumME.GetValueOrDefault) < i.montoUsd And i.montoUsd > 0 And (item.d.montoUsd - Salidas.sumME.GetValueOrDefault) > 0) Then
                '                        nDetalle.montoSoles = Math.Round(CDec((item.d.montoUsd - Salidas.sumME.GetValueOrDefault) * item.d.diferTipoCambio), 2)
                '                        nDetalle.montoUsd = (item.d.montoUsd - Salidas.sumME.GetValueOrDefault)
                '                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                '                        nDetalle.montoSolesTransacc = CDec(i.montoUsd * i.tipoCambioTransacc).ToString("N2")
                '                        nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                '                        saldoME = saldoME - nDetalle.montoUsd
                '                        i.montoUsd = saldoME
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                    ElseIf ((item.d.montoUsd - Salidas.sumME.GetValueOrDefault) > i.montoUsd And i.montoUsd > 0) Then
                '                        nDetalle.montoSoles = Math.Round(CDec(i.montoUsd * item.d.diferTipoCambio), 2)
                '                        nDetalle.montoUsd = i.montoUsd
                '                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                '                        nDetalle.montoSolesTransacc = CDec(i.montoUsd * i.tipoCambioTransacc).ToString("N2")
                '                        nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                '                        saldoME = saldoME - i.montoUsd
                '                        i.montoUsd = saldoME
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                    ElseIf ((item.d.montoUsd - Salidas.sumME.GetValueOrDefault) > i.montoUsd And i.montoUsd < 0) Then
                '                        nDetalle.montoSoles = Math.Round(CDec((i.montoUsd * -1) * item.d.diferTipoCambio), 2)
                '                        nDetalle.montoUsd = Math.Round(CDec(i.montoUsd * -1), 2)
                '                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                '                        nDetalle.montoSolesTransacc = CDec(i.montoUsd * i.tipoCambioTransacc).ToString("N2")
                '                        nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                '                        saldoME = item.d.montoUsd - i.montoUsd
                '                        i.montoUsd = saldoME
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                    ElseIf ((item.d.montoUsd - Salidas.sumME.GetValueOrDefault) = i.montoUsd And i.montoUsd > 0) Then
                '                        nDetalle.montoSoles = Math.Round(CDec(i.montoUsd * item.d.diferTipoCambio), 2)
                '                        nDetalle.montoUsd = i.montoUsd
                '                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                '                        nDetalle.montoSolesTransacc = CDec(i.montoUsd * i.tipoCambioTransacc).ToString("N2")
                '                        nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                '                        saldoME = saldoME - i.montoUsd
                '                        i.montoUsd = saldoME
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                    End If
                '                End If
                '        End Select

                '    Next
                'End If
            Next

            HeliosData.SaveChanges()
            ts.Complete()
            Return nDetalle.secuencia
        End Using
    End Function

    Public Function InsertDetalleNotaC(ByVal ListaCompra As List(Of documentocompradetalle), intIdDocumentoCaja As Integer, intIdCompra As Integer) As Integer
        Dim nDetalle As New documentoCajaDetalle
        Dim saldoItem As Decimal = 0
        Dim saldoItemme As Decimal = 0
        Using ts As New TransactionScope

            For Each i In ListaCompra

                nDetalle = New documentoCajaDetalle
                nDetalle.idDocumento = intIdDocumentoCaja
                nDetalle.documentoAfectado = intIdCompra
                nDetalle.documentoAfectadodetalle = i.secuencia
                nDetalle.fecha = DateTime.Now
                nDetalle.idItem = i.idItem
                nDetalle.DetalleItem = i.descripcionItem
                nDetalle.montoSoles = i.importe
                nDetalle.montoUsd = i.importeUS


                nDetalle.entregado = "SI"
                nDetalle.diferTipoCambio = 0


                nDetalle.usuarioModificacion = i.usuarioModificacion
                nDetalle.fechaModificacion = i.fechaModificacion

                HeliosData.documentoCajaDetalle.Add(nDetalle)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
            Return nDetalle.secuencia
        End Using
    End Function


    Public Function InsertDetalleNotaCVenta(ByVal ListaCompra As List(Of documentoventaAbarrotesDet), intIdDocumentoCaja As Integer, intIdCompra As Integer) As Integer
        Dim nDetalle As New documentoCajaDetalle
        Dim saldoItem As Decimal = 0
        Dim saldoItemme As Decimal = 0
        Using ts As New TransactionScope

            For Each i In ListaCompra

                nDetalle = New documentoCajaDetalle
                nDetalle.idDocumento = intIdDocumentoCaja
                nDetalle.documentoAfectado = intIdCompra
                nDetalle.documentoAfectadodetalle = i.secuencia
                nDetalle.fecha = DateTime.Now
                nDetalle.idItem = i.idItem
                nDetalle.DetalleItem = i.nombreItem
                nDetalle.montoSoles = i.importeMN
                nDetalle.montoUsd = i.importeME


                nDetalle.entregado = "SI"
                nDetalle.diferTipoCambio = 0


                nDetalle.usuarioModificacion = i.usuarioModificacion
                nDetalle.fechaModificacion = i.fechaModificacion

                HeliosData.documentoCajaDetalle.Add(nDetalle)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
            Return nDetalle.secuencia
        End Using
    End Function

    Public Function InsertApertura(ByVal documentoCajaDetalleBE As documento, intIdDocumentoCaja As Integer) As Integer
        Dim nDetalle As New documentoCajaDetalle
        Using ts As New TransactionScope

            For Each i In documentoCajaDetalleBE.documentoCaja.documentoCajaDetalle
                nDetalle = New documentoCajaDetalle
                nDetalle.idDocumento = intIdDocumentoCaja
                nDetalle.documentoAfectado = intIdDocumentoCaja
                nDetalle.secuencia = i.secuencia
                nDetalle.fecha = i.fecha
                nDetalle.idItem = i.idItem
                nDetalle.DetalleItem = i.DetalleItem
                nDetalle.montoSoles = i.montoSoles
                nDetalle.montoUsd = i.montoUsd
                nDetalle.entregado = i.entregado
                nDetalle.diferTipoCambio = i.diferTipoCambio
                nDetalle.usuarioModificacion = i.usuarioModificacion
                nDetalle.fechaModificacion = i.fechaModificacion
                HeliosData.documentoCajaDetalle.Add(nDetalle)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
            Return nDetalle.secuencia
        End Using
    End Function

    Public Function InsertGym(ByVal documentoCajaDetalleBE As documento, intIdDocumentoCaja As Integer, idMembresia As Integer) As Integer
        Dim nDetalle As New documentoCajaDetalle
        Using ts As New TransactionScope

            For Each i In documentoCajaDetalleBE.documentoCaja.documentoCajaDetalle
                nDetalle = New documentoCajaDetalle
                nDetalle.idDocumento = intIdDocumentoCaja
                nDetalle.documentoAfectado = idMembresia
                nDetalle.secuencia = i.secuencia
                nDetalle.fecha = i.fecha
                nDetalle.idItem = i.idItem
                nDetalle.DetalleItem = i.DetalleItem
                nDetalle.montoSoles = i.montoSoles
                nDetalle.montoUsd = i.montoUsd
                nDetalle.entregado = i.entregado
                nDetalle.diferTipoCambio = i.diferTipoCambio
                nDetalle.estado = i.estado
                nDetalle.usuarioModificacion = i.usuarioModificacion
                nDetalle.fechaModificacion = i.fechaModificacion
                HeliosData.documentoCajaDetalle.Add(nDetalle)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
            Return nDetalle.secuencia
        End Using
    End Function

    Public Function UpdateApertura(ByVal documentoCajaDetalleBE As documento, intIdDocumentoCaja As Integer) As Integer
        'Dim nDetalle As New documentoCajaDetalle
        Using ts As New TransactionScope

            For Each i In documentoCajaDetalleBE.documentoCaja.documentoCajaDetalle

                Dim nID = (From n In HeliosData.documentoCajaDetalle _
                  Where n.idDocumento = intIdDocumentoCaja).First

                'nID = New documentoCajaDetalle
                'nDetalle.idDocumento = intIdDocumentoCaja
                'nDetalle.documentoAfectado = intIdDocumentoCaja
                'nDetalle.secuencia = i.secuencia
                nID.fecha = i.fecha
                nID.idItem = i.idItem
                nID.DetalleItem = i.DetalleItem
                nID.montoSoles = i.montoSoles
                nID.montoUsd = i.montoUsd

                nID.entregado = i.entregado
                nID.diferTipoCambio = i.diferTipoCambio

                nID.usuarioModificacion = i.usuarioModificacion
                nID.fechaModificacion = i.fechaModificacion

            Next
            HeliosData.SaveChanges()
            ts.Complete()
            Return 0
        End Using
    End Function

    Public Function UpdateOtrosMov(ByVal documentoCajaDetalleBE As documento, intIdDocumentoCaja As Integer) As Integer
        Using ts As New TransactionScope

            Dim nDetalle As documentoCajaDetalle = HeliosData.documentoCajaDetalle.Where(Function(o) o.idDocumento = intIdDocumentoCaja _
                                                                                            And o.secuencia = documentoCajaDetalleBE.documentoCaja.documentoCajaDetalle(0).secuencia).First

            With documentoCajaDetalleBE.documentoCaja.documentoCajaDetalle(0)
                nDetalle.fecha = .fecha
                nDetalle.idItem = .idItem
                nDetalle.DetalleItem = .DetalleItem
                nDetalle.montoSoles = .montoSoles
                nDetalle.montoUsd = .montoUsd
            End With
            'HeliosData.ObjectStateManager.GetObjectStateEntry(nDetalle).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
            Return nDetalle.secuencia
        End Using
    End Function

    'Public Function InsertTransferencia(ByVal InventarioMovimientoBE As documentocompradetalle, objDocumento As documento) As Integer
    '    Dim objInventario As New InventarioMovimiento
    '    Dim almacenBL As New almacenBL
    '    Using ts As New TransactionScope
    '        objInventario = New InventarioMovimiento
    '        objInventario.idorigenDetalle = InventarioMovimientoBE.secuencia
    '        objInventario.idEmpresa = InventarioMovimientoBE.IdEmpresa
    '        objInventario.idEstablecimiento = InventarioMovimientoBE.IdEstablecimiento
    '        objInventario.tipoOperacion = InventarioMovimientoBE.TipoOperacion
    '        objInventario.tipoDocAlmacen = InventarioMovimientoBE.TipoDoc
    '        objInventario.serie = InventarioMovimientoBE.Serie
    '        objInventario.numero = InventarioMovimientoBE.NumDoc
    '        objInventario.idDocumento = objDocumento.idDocumento
    '        objInventario.idDocumentoRef = objDocumento.idDocumento
    '        objInventario.marca = InventarioMovimientoBE.marcaRef
    '        objInventario.descripcion = InventarioMovimientoBE.descripcionItem
    '        objInventario.fechaLaboral = InventarioMovimientoBE.FechaLaboral
    '        objInventario.fecha = InventarioMovimientoBE.FechaDoc
    '        objInventario.tipoRegistro = InventarioMovimientoBE.TipoRegistro
    '        objInventario.destinoGravadoItem = InventarioMovimientoBE.destino
    '        objInventario.tipoProducto = InventarioMovimientoBE.tipoExistencia
    '        objInventario.cuentaOrigen = InventarioMovimientoBE.CuentaItem
    '        objInventario.idItem = InventarioMovimientoBE.idItem
    '        objInventario.presentacion = InventarioMovimientoBE.unidad2
    '        objInventario.fechavcto = InventarioMovimientoBE.FechaVcto

    '        Select Case InventarioMovimientoBE.TipoRegistro
    '            Case "E"
    '                objInventario.idAlmacen = InventarioMovimientoBE.almacenDestino ' ALMACEN DE DESTINO DE LA MERCADERIA TRASLADADA
    '                objInventario.cantidad = InventarioMovimientoBE.monto1
    '                objInventario.unidad = InventarioMovimientoBE.unidad1
    '                objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
    '                objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2
    '                objInventario.precUnite = InventarioMovimientoBE.precioUnitario
    '                objInventario.precUniteUSD = InventarioMovimientoBE.precioUnitarioUS
    '                objInventario.monto = InventarioMovimientoBE.importe
    '                objInventario.montoUSD = InventarioMovimientoBE.importeUS
    '            Case Else
    '                objInventario.idAlmacen = InventarioMovimientoBE.almacenRef ' ALMACEN DE ORIGEN DE SALIDA DE MERCADERIA
    '                objInventario.cantidad = InventarioMovimientoBE.monto1 * -1
    '                objInventario.unidad = InventarioMovimientoBE.unidad1
    '                objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
    '                objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2
    '                objInventario.precUnite = InventarioMovimientoBE.precioUnitario
    '                objInventario.precUniteUSD = InventarioMovimientoBE.precioUnitarioUS
    '                objInventario.monto = InventarioMovimientoBE.importe * -1
    '                objInventario.montoUSD = InventarioMovimientoBE.importeUS * -1
    '        End Select
    '        objInventario.disponible = 0
    '        objInventario.disponible2 = 0
    '        objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
    '        objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
    '        objInventario.status = "D"
    '        objInventario.entragado = "NO"
    '        objInventario.usuarioActualizacion = InventarioMovimientoBE.usuarioModificacion
    '        objInventario.fechaActualizacion = InventarioMovimientoBE.fechaModificacion
    '        HeliosData.InventarioMovimiento.Add(objInventario)
    '        HeliosData.SaveChanges()
    '        ts.Complete()
    '        Return objInventario.idInventario
    '    End Using
    'End Function

    Public Function InsertTransferencia(ByVal documentoCajaDetalleBE As documento, intIdDocumentoCaja As Integer, intIdDocumentoPadre As Integer) As Integer
        Dim nDetalle As New documentoCajaDetalle
        Using ts As New TransactionScope

            For Each i In documentoCajaDetalleBE.documentoCaja.documentoCajaDetalle
                nDetalle = New documentoCajaDetalle
                nDetalle.idDocumento = intIdDocumentoCaja
                nDetalle.documentoAfectado = intIdDocumentoPadre
                nDetalle.secuencia = i.secuencia
                nDetalle.fecha = i.fecha
                nDetalle.idItem = i.idItem
                nDetalle.DetalleItem = i.DetalleItem
                nDetalle.montoSoles = i.montoSoles
                nDetalle.montoUsd = i.montoUsd


                nDetalle.entregado = i.entregado
                nDetalle.diferTipoCambio = i.diferTipoCambio


                nDetalle.usuarioModificacion = i.usuarioModificacion
                nDetalle.fechaModificacion = i.fechaModificacion

                HeliosData.documentoCajaDetalle.Add(nDetalle)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
            Return nDetalle.secuencia
        End Using
    End Function


    Public Function UpdateTransferencia(ByVal documentoCajaDetalleBE As documento, intIdDocumentoCaja As Integer, intIdDocumentoPadre As Integer) As Integer
        Dim nDetalle As New documentoCajaDetalle
        Using ts As New TransactionScope

            For Each i In documentoCajaDetalleBE.documentoCaja.documentoCajaDetalle

                Dim nID = (From n In HeliosData.documentoCajaDetalle _
               Where n.idDocumento = intIdDocumentoCaja).First

                nID.fecha = i.fecha
                nID.idItem = i.idItem
                nID.DetalleItem = i.DetalleItem
                nID.montoSoles = i.montoSoles
                nID.montoUsd = i.montoUsd

                nID.entregado = i.entregado
                nID.diferTipoCambio = i.diferTipoCambio

                nID.usuarioModificacion = i.usuarioModificacion
                nID.fechaModificacion = i.fechaModificacion

            Next
            HeliosData.SaveChanges()
            ts.Complete()
            Return 0
        End Using
    End Function

    Public Function EditarGrupo(ByVal documentoCajaDetalleBE As documento, intIdDocumentoCaja As Integer) As Integer
        Dim nDetalle As New documentoCajaDetalle
        Using ts As New TransactionScope

            For Each i In documentoCajaDetalleBE.documentoCaja.documentoCajaDetalle
                If i.Action = BaseBE.EntityAction.UPDATE Then
                    Dim xSec As Integer = i.secuencia
                    nDetalle = HeliosData.documentoCajaDetalle.Where(Function(o) _
                                         o.idDocumento = intIdDocumentoCaja _
                                         And o.secuencia = xSec).First()

                    nDetalle.fecha = i.fecha
                    nDetalle.montoSoles = i.montoSoles
                    nDetalle.montoUsd = i.montoUsd


                    nDetalle.diferTipoCambio = i.diferTipoCambio


                    nDetalle.usuarioModificacion = i.usuarioModificacion
                    nDetalle.fechaModificacion = i.fechaModificacion
                    'HeliosData.ObjectStateManager.GetObjectStateEntry(nDetalle).State.ToString()
                End If
            Next
            HeliosData.SaveChanges()
            ts.Complete()
            Return nDetalle.secuencia
        End Using
    End Function

    Public Sub Update(ByVal documentoCajaDetalleBE As documentoCajaDetalle)
        Using ts As New TransactionScope
            Dim docCajaDetalle As documentoCajaDetalle = HeliosData.documentoCajaDetalle.Where(Function(o) _
                                            o.idDocumento = documentoCajaDetalleBE.idDocumento _
                                            And o.secuencia = documentoCajaDetalleBE.secuencia).First()

            docCajaDetalle.fecha = documentoCajaDetalleBE.fecha
            docCajaDetalle.idItem = documentoCajaDetalleBE.idItem
            docCajaDetalle.DetalleItem = documentoCajaDetalleBE.DetalleItem
            docCajaDetalle.montoSoles = documentoCajaDetalleBE.montoSoles
            docCajaDetalle.montoUsd = documentoCajaDetalleBE.montoUsd

            docCajaDetalle.entregado = documentoCajaDetalleBE.entregado
            docCajaDetalle.diferTipoCambio = documentoCajaDetalleBE.diferTipoCambio

            docCajaDetalle.usuarioModificacion = documentoCajaDetalleBE.usuarioModificacion
            docCajaDetalle.documentoAfectado = documentoCajaDetalleBE.documentoAfectado
            docCajaDetalle.fechaModificacion = documentoCajaDetalleBE.fechaModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docCajaDetalle).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoCajaDetalleBE As documentoCajaDetalle)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoCajaDetalleBE)
    End Sub

    Public Function GetListar_documentoCajaDetalle() As List(Of documentoCajaDetalle)
        Return (From a In HeliosData.documentoCajaDetalle Select a).ToList
    End Function

    Public Function GetUbicar_documentoCajaDetallePorID(Secuencia As Integer) As documentoCajaDetalle
        Return (From a In HeliosData.documentoCajaDetalle
                 Where a.secuencia = Secuencia Select a).First
    End Function

    Public Function GetUbicar_DetallePorIdDocumento(intIdDocumento As Integer) As List(Of documentoCajaDetalle)
        Return (From a In HeliosData.documentoCajaDetalle
                 Where a.idDocumento = intIdDocumento Select a).ToList
    End Function

    Public Function GetUbicar_DetalleXdocumentoAfectado(docAfectado As Integer) As List(Of documentoCajaDetalle)
        Dim detalleSA As New documentoCajaDetalle
        Dim lista As New List(Of documentoCajaDetalle)
        Dim con = (From a In HeliosData.documentoCajaDetalle
                   Join c In HeliosData.documentoCaja _
                   On a.idDocumento Equals c.idDocumento _
                 Where a.documentoAfectado = docAfectado).ToList

        For Each i In con
            detalleSA = New documentoCajaDetalle
            detalleSA.idDocumento = i.c.idDocumento
            detalleSA.fechaDoc = i.c.fechaProceso
            detalleSA.tipoDocumento = i.c.tipoDocPago
            detalleSA.numeroDoc = i.c.numeroDoc
            detalleSA.tipoCambioTransacc = i.c.tipoCambio
            detalleSA.montoSoles = i.c.montoSoles
            detalleSA.montoUsd = i.c.montoUsd
            detalleSA.entregado = i.c.entregado
            lista.Add(detalleSA)
        Next
        Return lista
    End Function

    Public Function RecuperarIDCompra(intIdDocumentoCompra As Integer) As Integer

        Dim consulta = (From n In HeliosData.documentoCajaDetalle _
                       Where n.documentoAfectado = intIdDocumentoCompra).FirstOrDefault

        If Not IsNothing(consulta) Then
            Return consulta.idDocumento
        Else
            Return 0
        End If
    End Function

    'Public Sub DeleteDocumentoCaja(intIdPadre As Integer)
    '    Dim documentoBl As New documentoBL
    '    Dim cajaDetalle As List(Of documentoCajaDetalle) = HeliosData.documentoCajaDetalle.Where(Function(o) o.documentoAfectado = intIdPadre).ToList

    '    Using ts As New TransactionScope
    '        If (Not IsNothing(cajaDetalle)) Then
    '            For Each i In cajaDetalle
    '                documentoBl.DeleteSinglePagado(i.idDocumento)
    '            Next
    '        End If
    '        HeliosData.SaveChanges()
    '        ts.Complete()
    '    End Using
    'End Sub

    Public Sub DeleteDocumentoCaja(intIdPadre As Integer)
        Dim documentoBl As New documentoBL
        Dim cajaDetalle As List(Of documentoCajaDetalle) = HeliosData.documentoCajaDetalle.Where(Function(o) o.documentoAfectado = intIdPadre).ToList

        Using ts As New TransactionScope
            If (Not IsNothing(cajaDetalle)) Then
                For Each i In cajaDetalle
                    documentoBl.DeleteSinglePagado(i.idDocumento)
                    documentoBl.DeleteSinglePagadoDetalles(i.secuencia)
                Next
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function UbicarUltimaFechaPago(intIdDocumento As Integer) As DateTime
        Dim consulta = (From n In HeliosData.documentoCajaDetalle _
                   Where n.documentoAfectado = intIdDocumento _
                   Select n.fecha).Max

        Return consulta
    End Function

    Public Function ObtenerCajaDetalleME(ByVal montoUSD As Decimal, intEntidadFinanciera As Integer) As List(Of documentoCajaDetalle)
        Dim nDocumentoCaja As New documentoCaja
        Dim saldoME As Decimal = 0.0
        Dim nDetalle As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)

        Using ts As New TransactionScope

            Dim consultaCaja = (From c In HeliosData.documentoCaja _
                                        Join d In HeliosData.documentoCajaDetalle _
                                        On c.idDocumento Equals d.idDocumento _
                                Where c.tipoMovimiento = "DC" And _
                                c.entidadFinanciera = intEntidadFinanciera _
                                Order By d.fecha).ToList

            For Each item In consultaCaja

                Dim Salidas = (Aggregate n In HeliosData.documentoCaja Join
                     d In HeliosData.documentoCajaDetalle On n.idDocumento Equals d.idDocumento _
                   Where n.entidadFinanciera = intEntidadFinanciera And n.tipoMovimiento = "PG" _
                   And d.idCajaPadre = item.d.idDocumento _
                   Into sumMN = Sum(d.montoSoles), sumME = Sum(d.montoUsd))


                nDetalle = New documentoCajaDetalle
                saldoME = montoUSD
                If (saldoME > 0) Then
                    If ((item.d.montoUsd - Salidas.sumME.GetValueOrDefault) >= montoUSD And montoUSD = 0) Then
                        nDetalle.montoSoles = Math.Round(CDec((item.d.montoUsd - Salidas.sumME.GetValueOrDefault) * item.d.diferTipoCambio), 2)
                        nDetalle.diferTipoCambio = CDec(item.d.diferTipoCambio)
                        nDetalle.montoUsd = CDec(montoUSD)
                        nDetalle.idDocumento = item.d.idDocumento
                        saldoME = item.d.montoUsd - CDec(montoUSD)
                        montoUSD = saldoME
                        ListaDetalle.Add(nDetalle)
                    ElseIf ((item.d.montoUsd - Salidas.sumME.GetValueOrDefault) <= montoUSD And montoUSD = 0) Then
                        nDetalle.montoSoles = Math.Round(CDec((item.d.montoUsd - Salidas.sumME.GetValueOrDefault) * item.d.diferTipoCambio), 2)
                        nDetalle.diferTipoCambio = CDec(item.d.diferTipoCambio)
                        nDetalle.montoUsd = CDec(montoUSD)
                        nDetalle.idDocumento = item.d.idDocumento
                        saldoME = item.d.montoUsd - CDec(montoUSD)
                        montoUSD = saldoME
                        ListaDetalle.Add(nDetalle)
                    ElseIf ((item.d.montoUsd - Salidas.sumME.GetValueOrDefault) < montoUSD And montoUSD > 0) Then
                        nDetalle.montoSoles = Math.Round(CDec((item.d.montoUsd - Salidas.sumME.GetValueOrDefault) * item.d.diferTipoCambio), 2)
                        nDetalle.diferTipoCambio = CDec(item.d.diferTipoCambio)
                        nDetalle.montoUsd = CDec((item.d.montoUsd - Salidas.sumME.GetValueOrDefault))
                        saldoME = saldoME - CDec((item.d.montoUsd - Salidas.sumME.GetValueOrDefault))
                        nDetalle.idDocumento = item.d.idDocumento
                        montoUSD = saldoME
                        ListaDetalle.Add(nDetalle)
                    ElseIf ((item.d.montoUsd - Salidas.sumME.GetValueOrDefault) > montoUSD And montoUSD > 0) Then
                        nDetalle.diferTipoCambio = CDec(item.d.diferTipoCambio)
                        nDetalle.montoSoles = Math.Round(CDec(montoUSD * item.d.diferTipoCambio), 2)
                        nDetalle.montoUsd = CDec(montoUSD)
                        saldoME = saldoME - CDec(montoUSD)
                        nDetalle.idDocumento = item.d.idDocumento
                        montoUSD = saldoME
                        ListaDetalle.Add(nDetalle)
                    ElseIf ((item.d.montoUsd - Salidas.sumME.GetValueOrDefault) > montoUSD And montoUSD < 0) Then
                        nDetalle.diferTipoCambio = CDec(item.d.diferTipoCambio)
                        nDetalle.montoSoles = Math.Round(CDec((montoUSD * -1) * item.d.diferTipoCambio), 2)
                        nDetalle.montoUsd = CDec((montoUSD * -1))
                        nDetalle.idDocumento = item.d.idDocumento
                        saldoME = CDec(item.d.montoUsd - montoUSD)
                        montoUSD = saldoME
                        ListaDetalle.Add(nDetalle)
                    ElseIf ((item.d.montoUsd - Salidas.sumME.GetValueOrDefault) = montoUSD And montoUSD > 0) Then
                        nDetalle.diferTipoCambio = CDec(item.d.diferTipoCambio)
                        nDetalle.montoSoles = Math.Round(CDec(montoUSD * item.d.diferTipoCambio), 2)
                        nDetalle.montoUsd = CDec(montoUSD)
                        nDetalle.idDocumento = item.d.idDocumento
                        saldoME = saldoME - CDec(montoUSD)
                        montoUSD = saldoME
                        ListaDetalle.Add(nDetalle)
                    End If
                End If
            Next
            HeliosData.SaveChanges()
            ts.Complete()
            Return ListaDetalle
        End Using

    End Function


    Public Function ObtenerCajaDetalle(ByVal montoMN As Decimal, intEntidadFinanciera As Integer) As List(Of documentoCajaDetalle)
        Dim nDocumentoCaja As New documentoCaja
        Dim saldoMN As Decimal = 0
        Dim nDetalle As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)
        Dim lista As New List(Of String)
        lista.Add("2")
        lista.Add("0")

        Using ts As New TransactionScope

            Dim consultaCaja = (From c In HeliosData.documentoCaja _
                                        Join d In HeliosData.documentoCajaDetalle _
                                        On c.idDocumento Equals d.idDocumento _
                                Where c.tipoMovimiento = "DC" And _
                                c.entidadFinanciera = intEntidadFinanciera).ToList

            For Each item In consultaCaja
                nDetalle = New documentoCajaDetalle
                saldoMN = montoMN
                If (saldoMN > 0) Then
                    If (item.d.montoSoles >= montoMN And montoMN = 0) Then
                        nDetalle.montoUsd = Math.Round(CDec(item.d.montoSoles / item.d.diferTipoCambio), 2)
                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                        nDetalle.montoSoles = montoMN
                        saldoMN = item.d.montoSoles - montoMN
                        montoMN = saldoMN
                        ListaDetalle.Add(nDetalle)
                    ElseIf (item.d.montoSoles <= montoMN And montoMN = 0) Then
                        nDetalle.montoUsd = Math.Round(CDec(item.d.montoSoles / item.d.diferTipoCambio), 2)
                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                        nDetalle.montoSoles = montoMN
                        saldoMN = item.d.montoSoles - montoMN
                        montoMN = saldoMN
                        ListaDetalle.Add(nDetalle)
                    ElseIf (item.d.montoSoles < montoMN And montoMN > 0) Then
                        nDetalle.montoUsd = Math.Round(CDec(item.d.montoSoles / item.d.diferTipoCambio), 2)
                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                        nDetalle.montoSoles = item.d.montoSoles
                        saldoMN = saldoMN - item.d.montoSoles
                        montoMN = saldoMN
                        ListaDetalle.Add(nDetalle)
                    ElseIf (item.d.montoSoles > montoMN And montoMN > 0) Then
                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                        nDetalle.montoUsd = Math.Round(CDec(montoMN / item.d.diferTipoCambio), 2)
                        nDetalle.montoSoles = montoMN
                        saldoMN = saldoMN - montoMN
                        montoMN = saldoMN
                        ListaDetalle.Add(nDetalle)
                    ElseIf (item.d.montoSoles > montoMN And montoMN < 0) Then
                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                        nDetalle.montoUsd = Math.Round(CDec((montoMN * -1) / item.d.diferTipoCambio), 2)
                        nDetalle.montoSoles = (montoMN * -1)
                        saldoMN = item.d.montoUsd - montoMN
                        montoMN = saldoMN
                        ListaDetalle.Add(nDetalle)
                    ElseIf (item.d.montoSoles = montoMN And montoMN > 0) Then
                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                        nDetalle.montoUsd = Math.Round(CDec(montoMN / item.d.diferTipoCambio), 2)
                        nDetalle.montoSoles = montoMN
                        saldoMN = saldoMN - montoMN
                        montoMN = saldoMN
                        ListaDetalle.Add(nDetalle)
                    End If
                End If
            Next
            HeliosData.SaveChanges()
            ts.Complete()
            Return ListaDetalle
        End Using
    End Function

    Public Function InsertAperturaME(ByVal documentoCajaDetalleBE As documento, intIdDocumentoCaja As Integer, intEntidadFianciera As Integer) As List(Of documentoCajaDetalle)
        Dim nDocumentoCaja As New documentoCaja
        Dim saldoME As Decimal = 0
        Dim saldoMN As Decimal = 0
        Dim nDetalle As New documentoCajaDetalle
        Dim listadocumento As New List(Of documentoCajaDetalle)
        Dim listadocumentoDestino As New List(Of documentoCajaDetalle)


        Using ts As New TransactionScope
            'Dim ListadocumentoCajaDetalle2 = ConsultaMovimientoME(intEntidadFianciera)

            For Each i In documentoCajaDetalleBE.documentoCaja.documentoCajaDetalle

                nDetalle = New documentoCajaDetalle
                nDetalle.idDocumento = intIdDocumentoCaja
                nDetalle.documentoAfectado = i.documentoAfectado
                nDetalle.secuencia = i.secuencia
                nDetalle.fecha = i.fecha
                nDetalle.idItem = i.idItem
                nDetalle.DetalleItem = i.DetalleItem
                nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                nDetalle.montoSoles = i.montoSoles
                nDetalle.montoUsd = i.montoUsd
                nDetalle.entregado = i.entregado
                nDetalle.diferTipoCambio = i.diferTipoCambio
                nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                nDetalle.idCajaUsuario = i.idCajaUsuario
                nDetalle.usuarioModificacion = i.usuarioModificacion
                nDetalle.fechaModificacion = i.fechaModificacion
                nDetalle.idCajaPadre = i.idCajaPadre
                HeliosData.documentoCajaDetalle.Add(nDetalle)

                '    Dim consultaCaja = (From c In ListadocumentoCajaDetalle2
                '                            Order By c.fecha).ToList

                '    For Each item In consultaCaja
                '        Dim Salidas = (Aggregate n In listadocumento _
                '                   Where n.documentoAfectado = item.idDocumento And _
                '                   n.secuencia = item.secuencia _
                '                   Into sumMN = Sum(n.montoSoles), sumME = Sum(n.montoUsd))



                '        Select Case i.moneda

                '            Case 1
                '                saldoMN = i.montoSoles
                '                saldoME = i.montoUsd
                '                If (saldoMN > 0) Then
                '                    nDetalle = New documentoCajaDetalle
                '                    nDetalle.idDocumento = intIdDocumentoCaja
                '                    nDetalle.documentoAfectado = i.documentoAfectado
                '                    nDetalle.secuencia = item.secuencia
                '                    nDetalle.fecha = i.fecha
                '                    nDetalle.idItem = i.idItem
                '                    nDetalle.DetalleItem = i.DetalleItem
                '                    nDetalle.diferTipoCambio = item.diferTipoCambio
                '                    nDetalle.tipoCambioTransacc = item.tipoCambioTransacc
                '                    nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                '                    nDetalle.idCajaPadre = item.secuencia
                '                    nDetalle.usuarioModificacion = i.usuarioModificacion
                '                    nDetalle.fechaModificacion = i.fechaModificacion
                '                    nDetalle.entregado = i.entregado

                '                    If ((item.montoSoles - Salidas.sumMN.GetValueOrDefault) >= i.montoSoles And i.montoSoles = 0) Then
                '                        nDetalle.montoSoles = i.montoSoles
                '                        nDetalle.montoUsd = i.montoUsd
                '                        saldoME = item.montoUsd - i.montoUsd
                '                        i.montoUsd = saldoME
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                    ElseIf ((item.montoSoles - Salidas.sumMN.GetValueOrDefault) <= i.montoSoles And i.montoSoles = 0) Then
                '                        nDetalle.montoSoles = i.montoSoles
                '                        nDetalle.montoUsd = i.montoUsd
                '                        saldoME = item.montoUsd - i.montoUsd
                '                        i.montoUsd = saldoME
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                        listadocumentoDestino.Add(nDetalle)
                '                    ElseIf ((item.montoSoles - Salidas.sumMN.GetValueOrDefault) < i.montoSoles And i.montoSoles > 0 And (item.montoSoles - Salidas.sumMN.GetValueOrDefault) > 0) Then
                '                        'nDetalle.montoSolesTransacc = Math.Round(CDec((item.montoUsd - Salidas.sumME.GetValueOrDefault) * i.tipoCambioTransacc), 2)
                '                        nDetalle.montoSolesTransacc = CDec(item.montoSoles - Salidas.sumMN.GetValueOrDefault)
                '                        nDetalle.montoUsdTransacc = CDec((item.montoUsd - Salidas.sumME.GetValueOrDefault)).ToString("N2")
                '                        nDetalle.montoSoles = CDec(item.montoSoles - Salidas.sumMN.GetValueOrDefault)
                '                        nDetalle.montoUsd = CDec((item.montoSoles - Salidas.sumMN.GetValueOrDefault) / item.diferTipoCambio).ToString("N2")
                '                        saldoME = saldoME - nDetalle.montoUsd
                '                        i.montoUsd = saldoME
                '                        saldoMN = saldoMN - nDetalle.montoSolesTransacc
                '                        i.montoSoles = saldoMN
                '                        Dim docuem As New documentoCajaDetalle
                '                        docuem.documentoAfectado = item.idDocumento
                '                        docuem.secuencia = item.secuencia
                '                        docuem.montoSoles = nDetalle.montoSoles
                '                        docuem.montoUsd = nDetalle.montoUsd
                '                        listadocumento.Add(docuem)
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                        listadocumentoDestino.Add(nDetalle)
                '                    ElseIf ((item.montoSoles - Salidas.sumMN) > i.montoSoles And i.montoSoles > 0) Then
                '                        'nDetalle.montoSolesTransacc = Math.Round(CDec(i.montoUsd * i.tipoCambioTransacc), 2)
                '                        nDetalle.montoSolesTransacc = (CDec(i.montoSoles))
                '                        nDetalle.montoUsdTransacc = CDec((i.montoSoles) / item.tipoCambioTransacc).ToString("N2")
                '                        nDetalle.montoSoles = CDec(i.montoSoles)
                '                        nDetalle.montoUsd = CDec(i.montoSoles / item.diferTipoCambio).ToString("N2")
                '                        saldoME = saldoME - i.montoUsd
                '                        i.montoUsd = saldoME
                '                        saldoMN = saldoMN - i.montoSoles
                '                        i.montoSoles = saldoMN
                '                        Dim docuem As New documentoCajaDetalle
                '                        docuem.documentoAfectado = item.idDocumento
                '                        docuem.secuencia = item.secuencia
                '                        docuem.montoSoles = nDetalle.montoSoles
                '                        docuem.montoUsd = nDetalle.montoUsd
                '                        listadocumento.Add(docuem)
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                        listadocumentoDestino.Add(nDetalle)
                '                    ElseIf ((item.montoSoles - Salidas.sumMN) > i.montoSoles And i.montoSoles < 0) Then

                '                        nDetalle.montoSolesTransacc = CDec(i.montoSoles * -1)
                '                        nDetalle.montoUsdTransacc = Math.Round(CDec((i.montoSoles * -1) / i.tipoCambioTransacc), 2)
                '                        nDetalle.montoSoles = CDec(i.montoSoles * -1)
                '                        nDetalle.montoUsd = Math.Round(CDec((i.montoSoles * -1) / i.tipoCambioTransacc), 2)
                '                        saldoME = item.montoUsd - i.montoUsd
                '                        i.montoUsd = saldoME
                '                        Dim docuem As New documentoCajaDetalle
                '                        docuem.documentoAfectado = item.idDocumento
                '                        docuem.secuencia = item.secuencia
                '                        docuem.montoSoles = nDetalle.montoSoles
                '                        docuem.montoUsd = nDetalle.montoUsd
                '                        listadocumento.Add(docuem)
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                        listadocumentoDestino.Add(nDetalle)
                '                    ElseIf ((item.montoSoles - Salidas.sumMN) = i.montoSoles And i.montoSoles > 0) Then
                '                        'nDetalle.montoSolesTransacc = Math.Round(CDec(i.montoUsd * i.tipoCambioTransacc), 2)
                '                        nDetalle.montoSolesTransacc = i.montoSoles
                '                        nDetalle.montoUsdTransacc = CDec((i.montoSoles) / i.tipoCambioTransacc).ToString("N2")
                '                        nDetalle.montoSoles = i.montoSoles
                '                        nDetalle.montoUsd = CDec(i.montoSoles / item.diferTipoCambio).ToString("N2")
                '                        saldoME = saldoME - i.montoUsd
                '                        i.montoUsd = saldoME
                '                        Dim docuem As New documentoCajaDetalle
                '                        docuem.documentoAfectado = item.idDocumento
                '                        docuem.secuencia = item.secuencia
                '                        docuem.montoSoles = nDetalle.montoSoles
                '                        docuem.montoUsd = nDetalle.montoUsd
                '                        listadocumento.Add(docuem)
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                        listadocumentoDestino.Add(nDetalle)
                '                    End If
                '                End If
                '            Case 2
                '                saldoMN = CDec(i.montoUsd * item.tipoCambioTransacc).ToString("N2")
                '                saldoME = i.montoUsd
                '                If (saldoME > 0) Then
                '                    nDetalle = New documentoCajaDetalle
                '                    nDetalle.idDocumento = intIdDocumentoCaja
                '                    nDetalle.documentoAfectado = i.documentoAfectado
                '                    nDetalle.secuencia = i.secuencia
                '                    nDetalle.fecha = i.fecha
                '                    nDetalle.idItem = i.idItem
                '                    nDetalle.DetalleItem = i.DetalleItem
                '                    nDetalle.diferTipoCambio = item.diferTipoCambio
                '                    nDetalle.tipoCambioTransacc = item.tipoCambioTransacc
                '                    nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                '                    nDetalle.idCajaPadre = item.secuencia
                '                    nDetalle.usuarioModificacion = i.usuarioModificacion
                '                    nDetalle.fechaModificacion = i.fechaModificacion
                '                    nDetalle.entregado = i.entregado

                '                    If ((item.montoUsd - Salidas.sumME.GetValueOrDefault) >= i.montoUsd And i.montoUsd = 0) Then
                '                        nDetalle.montoSoles = i.montoSoles
                '                        nDetalle.montoUsd = i.montoUsd
                '                        saldoME = item.montoUsd - i.montoUsd
                '                        i.montoUsd = saldoME

                '                    ElseIf ((item.montoUsd - Salidas.sumME.GetValueOrDefault) <= i.montoUsd And i.montoUsd = 0) Then
                '                        nDetalle.montoSoles = i.montoSoles
                '                        nDetalle.montoUsd = i.montoUsd
                '                        saldoME = item.montoUsd - i.montoUsd
                '                        i.montoUsd = saldoME
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                        listadocumentoDestino.Add(nDetalle)
                '                    ElseIf ((item.montoUsd - Salidas.sumME.GetValueOrDefault) < i.montoUsd And i.montoUsd > 0 And (item.montoUsd - Salidas.sumME.GetValueOrDefault) > 0) Then
                '                        'nDetalle.montoSolesTransacc = Math.Round(CDec((item.montoUsd - Salidas.sumME.GetValueOrDefault) * i.tipoCambioTransacc), 2)
                '                        nDetalle.montoSolesTransacc = CDec(((item.montoUsd - Salidas.sumME.GetValueOrDefault) * item.tipoCambioTransacc)).ToString("n2")
                '                        nDetalle.montoUsdTransacc = CDec((item.montoUsd - Salidas.sumME.GetValueOrDefault)).ToString("N2")
                '                        nDetalle.montoSoles = Math.Round(CDec((item.montoUsd - Salidas.sumME.GetValueOrDefault) * item.diferTipoCambio), 2)
                '                        nDetalle.montoUsd = (item.montoUsd - Salidas.sumME.GetValueOrDefault)
                '                        saldoME = saldoME - nDetalle.montoUsd
                '                        i.montoUsd = saldoME
                '                        saldoMN = saldoMN - nDetalle.montoSolesTransacc
                '                        i.montoSoles = saldoMN
                '                        Dim docuem As New documentoCajaDetalle
                '                        docuem.documentoAfectado = item.idDocumento
                '                        docuem.secuencia = item.secuencia
                '                        docuem.montoSoles = nDetalle.montoSoles
                '                        docuem.montoUsd = nDetalle.montoUsd
                '                        listadocumento.Add(docuem)
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                        listadocumentoDestino.Add(nDetalle)
                '                    ElseIf ((item.montoUsd - Salidas.sumME) > i.montoUsd And i.montoUsd > 0) Then
                '                        'nDetalle.montoSolesTransacc = Math.Round(CDec(i.montoUsd * i.tipoCambioTransacc), 2)
                '                        nDetalle.montoSolesTransacc = Math.Round(CDec(i.montoUsd * item.tipoCambioTransacc), 2)
                '                        nDetalle.montoUsdTransacc = CDec((i.montoUsd)).ToString("N2")
                '                        nDetalle.montoSoles = Math.Round(CDec(i.montoUsd * item.diferTipoCambio), 2)
                '                        nDetalle.montoUsd = i.montoUsd
                '                        saldoME = saldoME - i.montoUsd
                '                        i.montoUsd = saldoME
                '                        saldoMN = saldoMN - i.montoSoles
                '                        i.montoSoles = saldoMN
                '                        Dim docuem As New documentoCajaDetalle
                '                        docuem.documentoAfectado = item.idDocumento
                '                        docuem.secuencia = item.secuencia
                '                        docuem.montoSoles = nDetalle.montoSoles
                '                        docuem.montoUsd = nDetalle.montoUsd
                '                        listadocumento.Add(docuem)
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                        listadocumentoDestino.Add(nDetalle)
                '                    ElseIf ((item.montoUsd - Salidas.sumME) > i.montoUsd And i.montoUsd < 0) Then

                '                        nDetalle.montoSolesTransacc = CDec(i.montoSoles * -1)
                '                        nDetalle.montoUsdTransacc = Math.Round(CDec((i.montoSoles * -1) / item.tipoCambioTransacc), 2)
                '                        nDetalle.montoSoles = Math.Round(CDec((i.montoUsd * -1) * item.diferTipoCambio), 2)
                '                        nDetalle.montoUsd = Math.Round(CDec(i.montoUsd * -1), 2)
                '                        saldoME = item.montoUsd - i.montoUsd
                '                        i.montoUsd = saldoME
                '                        Dim docuem As New documentoCajaDetalle
                '                        docuem.documentoAfectado = item.idDocumento
                '                        docuem.secuencia = item.secuencia
                '                        docuem.montoSoles = nDetalle.montoSoles
                '                        docuem.montoUsd = nDetalle.montoUsd
                '                        listadocumento.Add(docuem)
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                        listadocumentoDestino.Add(nDetalle)
                '                    ElseIf ((item.montoUsd - Salidas.sumME) = i.montoUsd And i.montoUsd > 0) Then
                '                        'nDetalle.montoSolesTransacc = Math.Round(CDec(i.montoUsd * i.tipoCambioTransacc), 2)
                '                        nDetalle.montoSolesTransacc = i.montoSoles
                '                        nDetalle.montoUsdTransacc = CDec((i.montoSoles) / item.tipoCambioTransacc).ToString("N2")
                '                        nDetalle.montoSoles = Math.Round(CDec(i.montoUsd * item.diferTipoCambio), 2)
                '                        nDetalle.montoUsd = i.montoUsd
                '                        saldoME = saldoME - i.montoUsd
                '                        i.montoUsd = saldoME
                '                        Dim docuem As New documentoCajaDetalle
                '                        docuem.documentoAfectado = item.idDocumento
                '                        docuem.secuencia = item.secuencia
                '                        docuem.montoSoles = nDetalle.montoSoles
                '                        docuem.montoUsd = nDetalle.montoUsd
                '                        listadocumento.Add(docuem)
                '                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                '                        listadocumentoDestino.Add(nDetalle)
                '                    End If
                '                End If
                '        End Select
                '    Next
            Next

            HeliosData.SaveChanges()
            ts.Complete()
            Return listadocumentoDestino
        End Using
    End Function


    Public Function InsertTransferenciaME(ByVal documentoCajaDetalleBE As List(Of documentoCajaDetalle), intIdDocumentoCaja As Integer) As Integer
        'Dim nDetalle As New documentoCajaDetalle
        'Using ts As New TransactionScope

        Dim nDocumentoCaja As New documentoCaja
        Dim saldoME As Decimal = 0
        Dim nDetalle As New documentoCajaDetalle

        Using ts As New TransactionScope


            For Each item In documentoCajaDetalleBE

                nDetalle = New documentoCajaDetalle
                nDetalle.idDocumento = intIdDocumentoCaja
                nDetalle.documentoAfectado = item.documentoAfectado
                nDetalle.secuencia = Nothing
                nDetalle.fecha = item.fecha
                nDetalle.idItem = item.idItem
                nDetalle.DetalleItem = item.DetalleItem
                nDetalle.montoSoles = item.montoSoles
                '   nDetalle.montoSolesTransacc = item.montoSolesTransacc
                nDetalle.montoUsd = item.montoUsd
                ' nDetalle.montoUsdTransacc = item.montoUsdTransacc
                nDetalle.entregado = item.entregado
                nDetalle.diferTipoCambio = item.diferTipoCambio
                nDetalle.tipoCambioTransacc = item.tipoCambioTransacc
                nDetalle.usuarioModificacion = item.usuarioModificacion
                nDetalle.fechaModificacion = item.fechaModificacion
                HeliosData.documentoCajaDetalle.Add(nDetalle)

            Next
            HeliosData.SaveChanges()
            ts.Complete()
            Return nDetalle.secuencia
        End Using
    End Function

    Public Function Getransferencia(documentoBE As documento, intIdDocumentoCaja As Integer) As Integer
        'Dim nDetalle As New documentoCajaDetalle
        'Using ts As New TransactionScope

        Dim nDocumentoCaja As New documentoCaja
        Dim saldoME As Decimal = 0
        Dim nDetalle As New documentoCajaDetalle

        Using ts As New TransactionScope


            For Each item In documentoBE.documentoCaja.documentoCajaDetalle

                nDetalle = New documentoCajaDetalle
                nDetalle.idDocumento = intIdDocumentoCaja
                nDetalle.documentoAfectado = item.documentoAfectado
                nDetalle.secuencia = Nothing
                nDetalle.fecha = item.fecha
                nDetalle.idItem = item.idItem
                nDetalle.DetalleItem = item.DetalleItem
                nDetalle.montoSoles = item.montoSoles
                '   nDetalle.montoSolesTransacc = item.montoSolesTransacc
                nDetalle.montoUsd = item.montoUsd
                ' nDetalle.montoUsdTransacc = item.montoUsdTransacc
                nDetalle.entregado = item.entregado
                nDetalle.diferTipoCambio = item.diferTipoCambio
                nDetalle.tipoCambioTransacc = item.tipoCambioTransacc
                nDetalle.usuarioModificacion = item.usuarioModificacion
                nDetalle.fechaModificacion = item.fechaModificacion
                nDetalle.idCajaPadre = item.idCajaPadre
                HeliosData.documentoCajaDetalle.Add(nDetalle)

            Next
            HeliosData.SaveChanges()
            ts.Complete()
            Return nDetalle.secuencia
        End Using
    End Function

    'Public Sub InsertPagosDeCajaCompraME(objDocumentoBE As documento, intDocCaja As Integer, intEntidadFinanciera As Integer, listaDetalle As List(Of documentoCajaDetalle), ventaOriginal As Integer)
    '    Dim saldoME As Decimal = 0
    '    Dim saldoMN As Decimal = 0
    '    Dim saldoItem As Decimal = 0
    '    Dim saldoItemME As Decimal = 0
    '    Dim nDetalle As New documentoCajaDetalle
    '    Dim objItemsaldo As New documentoCajaDetalle
    '    Dim cajaDetalleBL As New documentoCajaDetalleBL
    '    Dim listadocumento As New List(Of documentoCajaDetalle)

    '    Using ts As New TransactionScope
    '        For Each i In objDocumentoBE.documentoCaja.documentoCajaDetalle
    '            Dim NCventa = Aggregate det In HeliosData.documentocompradetalle _
    '                        Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento _
    '                        Where v.tipoDoc = "07" And det.idPadreDTCompra = i.documentoAfectadodetalle _
    '                        Into NCmn = Sum(det.importe), _
    '                             NCme = Sum(det.importeUS)

    '            Dim NBventa = Aggregate det In HeliosData.documentocompradetalle _
    '                         Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento _
    '                         Where v.tipoDoc = "08" And det.idPadreDTCompra = i.documentoAfectadodetalle _
    '                         Into NBmn = Sum(det.importe), _
    '                              NBme = Sum(det.importeUS)

    '            '    Dim Ajustes = Aggregate p In HeliosData.documentoLibroDiarioDetalle _
    '            '     Join compra In HeliosData.documentoLibroDiario _
    '            '     On p.idDocumento Equals compra.idDocumento _
    '            '                Where p.cuenta = i.documentoAfectadodetalle _
    '            '                And compra.tipoRegistro = "AJU"
    '            'Into AJmn = Sum(p.importeMN), _
    '            '     AJme = Sum(p.importeME)

    '            objItemsaldo = cajaDetalleBL.ObtenerCuentasPorPagarPorProducto(i.documentoAfectado, i.documentoAfectadodetalle)
    '            Dim VentaDetalle As documentocompradetalle = HeliosData.documentocompradetalle.Where(Function(o) o.secuencia = i.documentoAfectadodetalle).FirstOrDefault

    '            'Select Case ventaOriginal
    '            '    Case 1
    '            '        saldoItem = objItemsaldo.MontoDeudaSoles - i.montoSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault - Ajustes.AJmn.GetValueOrDefault
    '            '        saldoItemME = objItemsaldo.MontoDeudaUSD - i.montoUsd - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault - Ajustes.AJme.GetValueOrDefault

    '            '        If saldoItem <= 0 Then
    '            '            VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PAGADO
    '            '        Else
    '            '            VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
    '            '        End If
    '            '    Case 2
    '            '        saldoItem = objItemsaldo.MontoDeudaSoles - i.montoSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault - Ajustes.AJmn.GetValueOrDefault
    '            '        saldoItemME = objItemsaldo.MontoDeudaUSD - i.montoUsd - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault - Ajustes.AJme.GetValueOrDefault

    '            '        If saldoItemME <= 0 Then
    '            '            VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PAGADO
    '            '        Else
    '            '            VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
    '            '        End If
    '            'End Select

    '            Select Case ventaOriginal
    '                Case 1
    '                    saldoItem = objItemsaldo.MontoDeudaSoles - i.montoSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault
    '                    saldoItemME = objItemsaldo.MontoDeudaUSD - i.montoUsd - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault

    '                    If saldoItem <= 0 Then
    '                        VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PAGADO
    '                    Else
    '                        VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
    '                    End If
    '                Case 2
    '                    saldoItem = objItemsaldo.MontoDeudaSoles - i.montoSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault
    '                    saldoItemME = objItemsaldo.MontoDeudaUSD - i.montoUsd - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault

    '                    If saldoItemME <= 0 Then
    '                        VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PAGADO
    '                    Else
    '                        VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
    '                    End If
    '            End Select


    '            If (objDocumentoBE.documentoCaja.tipoMovimiento = MovimientoCaja.EntradaDinero) Then
    '                nDetalle = New documentoCajaDetalle
    '                nDetalle.idDocumento = intDocCaja
    '                nDetalle.documentoAfectado = i.documentoAfectado
    '                nDetalle.secuencia = i.secuencia
    '                nDetalle.fecha = i.fecha
    '                nDetalle.idItem = i.idItem
    '                nDetalle.DetalleItem = i.DetalleItem
    '                nDetalle.montoSoles = i.montoSoles
    '                nDetalle.montoUsd = i.montoUsd

    '                nDetalle.entregado = i.entregado
    '                nDetalle.diferTipoCambio = i.diferTipoCambio


    '                nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
    '                nDetalle.usuarioModificacion = i.usuarioModificacion
    '                nDetalle.fechaModificacion = i.fechaModificacion

    '                HeliosData.documentoCajaDetalle.Add(nDetalle)

    '                'for
    '            ElseIf (objDocumentoBE.documentoCaja.tipoMovimiento = MovimientoCaja.SalidaDinero) Then

    '                Dim consultaCaja = (From c In listaDetalle
    '                                    Order By c.fecha).ToList

    '                For Each item In consultaCaja
    '                    Dim Salidas = (Aggregate n In listadocumento _
    '                               Where n.documentoAfectado = item.idDocumento And _
    '                               n.secuencia = item.secuencia _
    '                               Into sumMN = Sum(n.montoSoles), sumME = Sum(n.montoUsd))

    '                    saldoMN = i.montoSoles
    '                    saldoME = i.montoUsd
    '                    If (saldoME > 0) Then
    '                        nDetalle = New documentoCajaDetalle
    '                        nDetalle.idDocumento = intDocCaja
    '                        nDetalle.documentoAfectado = i.documentoAfectado
    '                        nDetalle.secuencia = i.secuencia
    '                        nDetalle.fecha = i.fecha
    '                        nDetalle.idItem = i.idItem
    '                        nDetalle.DetalleItem = i.DetalleItem
    '                        nDetalle.diferTipoCambio = item.diferTipoCambio
    '                        nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
    '                        nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
    '                        nDetalle.idCajaPadre = item.idDocumento
    '                        nDetalle.usuarioModificacion = i.usuarioModificacion
    '                        nDetalle.fechaModificacion = i.fechaModificacion
    '                        nDetalle.entregado = i.entregado

    '                        If ((item.montoUsd - Salidas.sumME.GetValueOrDefault) >= i.montoUsd And i.montoUsd = 0) Then
    '                            nDetalle.montoSoles = i.montoSoles
    '                            nDetalle.montoUsd = i.montoUsd
    '                            saldoME = item.montoUsd - i.montoUsd
    '                            i.montoUsd = saldoME
    '                            HeliosData.documentoCajaDetalle.Add(nDetalle)
    '                        ElseIf ((item.montoUsd - Salidas.sumME.GetValueOrDefault) <= i.montoUsd And i.montoUsd = 0) Then
    '                            nDetalle.montoSoles = i.montoSoles
    '                            nDetalle.montoUsd = i.montoUsd
    '                            saldoME = item.montoUsd - i.montoUsd
    '                            i.montoUsd = saldoME
    '                            HeliosData.documentoCajaDetalle.Add(nDetalle)
    '                        ElseIf ((item.montoUsd - Salidas.sumME.GetValueOrDefault) < i.montoUsd And i.montoUsd > 0 And (item.montoUsd - Salidas.sumME.GetValueOrDefault) > 0) Then
    '                            'nDetalle.montoSolesTransacc = Math.Round(CDec((item.montoUsd - Salidas.sumME.GetValueOrDefault) * i.tipoCambioTransacc), 2)
    '                            nDetalle.montoSolesTransacc = CDec(((item.montoUsd - Salidas.sumME.GetValueOrDefault) * i.tipoCambioTransacc)).ToString("n2")
    '                            nDetalle.montoUsdTransacc = CDec((item.montoUsd - Salidas.sumME.GetValueOrDefault)).ToString("N2")
    '                            nDetalle.montoSoles = Math.Round(CDec((item.montoUsd - Salidas.sumME.GetValueOrDefault) * item.diferTipoCambio), 2)
    '                            nDetalle.montoUsd = (item.montoUsd - Salidas.sumME.GetValueOrDefault)
    '                            saldoME = saldoME - nDetalle.montoUsd
    '                            i.montoUsd = saldoME
    '                            saldoMN = saldoMN - nDetalle.montoSolesTransacc
    '                            i.montoSoles = saldoMN
    '                            Dim docuem As New documentoCajaDetalle
    '                            docuem.documentoAfectado = item.idDocumento
    '                            docuem.secuencia = item.secuencia
    '                            docuem.montoSoles = nDetalle.montoSoles
    '                            docuem.montoUsd = nDetalle.montoUsd
    '                            listadocumento.Add(docuem)
    '                            HeliosData.documentoCajaDetalle.Add(nDetalle)
    '                        ElseIf ((item.montoUsd - Salidas.sumME) > i.montoUsd And i.montoUsd > 0) Then
    '                            'nDetalle.montoSolesTransacc = Math.Round(CDec(i.montoUsd * i.tipoCambioTransacc), 2)
    '                            nDetalle.montoSolesTransacc = CDec(i.montoSoles)
    '                            nDetalle.montoUsdTransacc = CDec((i.montoSoles) / i.tipoCambioTransacc).ToString("N2")
    '                            nDetalle.montoSoles = Math.Round(CDec(i.montoUsd * item.diferTipoCambio), 2)
    '                            nDetalle.montoUsd = i.montoUsd
    '                            saldoME = saldoME - i.montoUsd
    '                            i.montoUsd = saldoME
    '                            saldoMN = saldoMN - i.montoSoles
    '                            i.montoSoles = saldoMN
    '                            Dim docuem As New documentoCajaDetalle
    '                            docuem.documentoAfectado = item.idDocumento
    '                            docuem.secuencia = item.secuencia
    '                            docuem.montoSoles = nDetalle.montoSoles
    '                            docuem.montoUsd = nDetalle.montoUsd
    '                            listadocumento.Add(docuem)
    '                            HeliosData.documentoCajaDetalle.Add(nDetalle)
    '                        ElseIf ((item.montoUsd - Salidas.sumME) > i.montoUsd And i.montoUsd < 0) Then

    '                            nDetalle.montoSolesTransacc = CDec(i.montoSoles * -1)
    '                            nDetalle.montoUsdTransacc = Math.Round(CDec((i.montoSoles * -1) / i.tipoCambioTransacc), 2)
    '                            nDetalle.montoSoles = Math.Round(CDec((i.montoUsd * -1) * item.diferTipoCambio), 2)
    '                            nDetalle.montoUsd = Math.Round(CDec(i.montoUsd * -1), 2)
    '                            saldoME = item.montoUsd - i.montoUsd
    '                            i.montoUsd = saldoME
    '                            Dim docuem As New documentoCajaDetalle
    '                            docuem.documentoAfectado = item.idDocumento
    '                            docuem.secuencia = item.secuencia
    '                            docuem.montoSoles = nDetalle.montoSoles
    '                            docuem.montoUsd = nDetalle.montoUsd
    '                            listadocumento.Add(docuem)
    '                            HeliosData.documentoCajaDetalle.Add(nDetalle)
    '                        ElseIf ((item.montoUsd - Salidas.sumME) = i.montoUsd And i.montoUsd > 0) Then
    '                            'nDetalle.montoSolesTransacc = Math.Round(CDec(i.montoUsd * i.tipoCambioTransacc), 2)
    '                            nDetalle.montoSolesTransacc = i.montoSoles
    '                            nDetalle.montoUsdTransacc = CDec((i.montoSoles) / i.tipoCambioTransacc).ToString("N2")
    '                            nDetalle.montoSoles = Math.Round(CDec(i.montoUsd * item.diferTipoCambio), 2)
    '                            nDetalle.montoUsd = i.montoUsd
    '                            saldoME = saldoME - i.montoUsd
    '                            i.montoUsd = saldoME
    '                            Dim docuem As New documentoCajaDetalle
    '                            docuem.documentoAfectado = item.idDocumento
    '                            docuem.secuencia = item.secuencia
    '                            docuem.montoSoles = nDetalle.montoSoles
    '                            docuem.montoUsd = nDetalle.montoUsd
    '                            listadocumento.Add(docuem)
    '                            HeliosData.documentoCajaDetalle.Add(nDetalle)
    '                        End If
    '                    End If

    '                    'End Select

    '                Next
    '            End If
    '        Next
    '        HeliosData.SaveChanges()
    '        ts.Complete()
    '    End Using
    'End Sub

    Public Sub GetPagoDetalleSave(objDocumentoBE As documento, intDocCaja As Integer, ventaOriginal As Integer)
        Dim saldoME As Decimal = 0
        Dim saldoMN As Decimal = 0
        Dim saldoItem As Decimal = 0
        Dim saldoItemME As Decimal = 0
        Dim nDetalle As New documentoCajaDetalle
        Dim objItemsaldo As New documentoCajaDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim listadocumento As New List(Of documentoCajaDetalle)
        Dim pagoDoc As Decimal = CDec(0.0)
        Dim pagoDocME As Decimal = CDec(0.0)
        Dim idDoc As Integer = 0
        Dim idDocDet As Integer = 0
        Dim conteo As Integer = 0

        Dim lista As New List(Of String)
        lista.Add("07")
        lista.Add("9901")

        Dim lista2 As New List(Of String)
        lista2.Add("08")
        lista2.Add("40")

        Using ts As New TransactionScope
            For Each i In objDocumentoBE.documentoCaja.documentoCajaDetalle
                conteo += 1
                If conteo = 1 Then
                    idDoc = i.documentoAfectado
                    idDocDet = i.documentoAfectadodetalle
                End If
                Dim NCventa = Aggregate det In HeliosData.documentocompradetalle
                            Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento
                            Where lista.Contains(v.tipoDoc) And det.idPadreDTCompra = i.documentoAfectadodetalle
                            Into NCmn = Sum(det.importe),
                                 NCme = Sum(det.importeUS)

                Dim NBventa = Aggregate det In HeliosData.documentocompradetalle
                             Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento
                             Where lista2.Contains(v.tipoDoc) And det.idPadreDTCompra = i.documentoAfectadodetalle
                             Into NBmn = Sum(det.importe),
                                  NBme = Sum(det.importeUS)



                objItemsaldo = cajaDetalleBL.ObtenerCuentasPorPagarPorProducto(i.documentoAfectado, i.documentoAfectadodetalle)
                Dim VentaDetalle As documentocompradetalle = HeliosData.documentocompradetalle.Where(Function(o) o.secuencia = i.documentoAfectadodetalle).FirstOrDefault


                If conteo >= 2 Then
                    If idDoc = i.documentoAfectado Then
                        If idDocDet = i.documentoAfectadodetalle Then
                            pagoDoc += i.montoSoles
                            pagoDocME += i.montoUsd
                        Else
                            idDoc = i.documentoAfectado
                            idDocDet = i.documentoAfectadodetalle
                            pagoDoc = CDec(0.0)
                            pagoDocME = CDec(0.0)

                        End If
                    Else
                        idDoc = i.documentoAfectado
                        idDocDet = i.documentoAfectadodetalle
                        pagoDoc = CDec(0.0)
                        pagoDocME = CDec(0.0)

                    End If
                End If



                Select Case ventaOriginal
                    Case 1
                        saldoItem = objItemsaldo.MontoDeudaSoles - i.montoSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault - pagoDoc
                        saldoItemME = objItemsaldo.MontoDeudaUSD - i.montoUsd - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault - pagoDocME

                        If saldoItem <= 0 Then
                            VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                        Else
                            VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        End If
                    Case 2
                        saldoItem = objItemsaldo.MontoDeudaSoles - i.montoSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault - pagoDoc
                        saldoItemME = objItemsaldo.MontoDeudaUSD - i.montoUsd - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault - pagoDocME

                        If saldoItemME <= 0 Then
                            VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                        Else
                            VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        End If
                End Select

                nDetalle = New documentoCajaDetalle
                nDetalle.idDocumento = intDocCaja
                nDetalle.documentoAfectado = i.documentoAfectado
                nDetalle.secuencia = i.secuencia
                nDetalle.fecha = i.fecha
                nDetalle.idItem = i.idItem
                nDetalle.DetalleItem = i.DetalleItem
                nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                nDetalle.montoSoles = i.montoSoles
                nDetalle.montoUsd = i.montoUsd
                nDetalle.entregado = i.entregado
                nDetalle.diferTipoCambio = i.diferTipoCambio
                nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                nDetalle.idCajaUsuario = i.idCajaUsuario
                nDetalle.usuarioModificacion = i.usuarioModificacion
                nDetalle.fechaModificacion = i.fechaModificacion

                HeliosData.documentoCajaDetalle.Add(nDetalle)

            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GetPagoDetalleMembresia(objDocumentoBE As documento, intDocCaja As Integer, ventaOriginal As Integer)
        Dim saldoME As Decimal = 0
        Dim saldoMN As Decimal = 0
        Dim saldoItem As Decimal = 0
        Dim saldoItemME As Decimal = 0
        Dim nDetalle As New documentoCajaDetalle
        Dim objItemsaldo As New documentoCajaDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim listadocumento As New List(Of documentoCajaDetalle)
        Dim pagoDoc As Decimal = CDec(0.0)
        Dim pagoDocME As Decimal = CDec(0.0)
        Dim idDoc As Integer = 0
        Dim idDocDet As Integer = 0
        Dim conteo As Integer = 0

        Dim lista As New List(Of String)
        lista.Add("07")
        lista.Add("9901")

        Using ts As New TransactionScope
            For Each i In objDocumentoBE.documentoCaja.documentoCajaDetalle
                nDetalle = New documentoCajaDetalle
                nDetalle.idDocumento = intDocCaja
                nDetalle.documentoAfectado = i.documentoAfectado
                nDetalle.secuencia = i.secuencia
                nDetalle.fecha = i.fecha
                nDetalle.idItem = i.idItem
                nDetalle.DetalleItem = i.DetalleItem
                nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                nDetalle.montoSoles = i.montoSoles
                nDetalle.montoUsd = i.montoUsd
                nDetalle.entregado = i.entregado
                nDetalle.diferTipoCambio = i.diferTipoCambio
                nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                nDetalle.idCajaUsuario = i.idCajaUsuario
                nDetalle.usuarioModificacion = i.usuarioModificacion
                nDetalle.fechaModificacion = i.fechaModificacion
                HeliosData.documentoCajaDetalle.Add(nDetalle)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertPagosDeCajaCompraME(objDocumentoBE As documento, intDocCaja As Integer, intEntidadFinanciera As Integer, listaDetalle As List(Of documentoCajaDetalle), ventaOriginal As Integer)

        Dim lista As New List(Of String)
        lista.Add("07")
        lista.Add("87")

        Dim lista2 As New List(Of String)
        lista2.Add("08")
        lista2.Add("88")


        Dim saldoME As Decimal = 0
        Dim saldoMN As Decimal = 0
        Dim saldoItem As Decimal = 0
        Dim saldoItemME As Decimal = 0
        Dim nDetalle As New documentoCajaDetalle
        Dim objItemsaldo As New documentoCajaDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim listadocumento As New List(Of documentoCajaDetalle)

        Using ts As New TransactionScope
            For Each i In objDocumentoBE.documentoCaja.documentoCajaDetalle
                Dim NCventa = Aggregate det In HeliosData.documentocompradetalle _
                            Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento _
                            Where lista.Contains(v.tipoDoc) And det.idPadreDTCompra = i.documentoAfectadodetalle _
                            Into NCmn = Sum(det.importe), _
                                 NCme = Sum(det.importeUS)

                Dim NBventa = Aggregate det In HeliosData.documentocompradetalle _
                             Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento _
                             Where lista2.Contains(v.tipoDoc) And det.idPadreDTCompra = i.documentoAfectadodetalle _
                             Into NBmn = Sum(det.importe), _
                                  NBme = Sum(det.importeUS)

                '    Dim Ajustes = Aggregate p In HeliosData.documentoLibroDiarioDetalle _
                '     Join compra In HeliosData.documentoLibroDiario _
                '     On p.idDocumento Equals compra.idDocumento _
                '                Where p.cuenta = i.documentoAfectadodetalle _
                '                And compra.tipoRegistro = "AJU"
                'Into AJmn = Sum(p.importeMN), _
                '     AJme = Sum(p.importeME)

                objItemsaldo = cajaDetalleBL.ObtenerCuentasPorPagarPorProducto(i.documentoAfectado, i.documentoAfectadodetalle)
                Dim VentaDetalle As documentocompradetalle = HeliosData.documentocompradetalle.Where(Function(o) o.secuencia = i.documentoAfectadodetalle).FirstOrDefault

                Select Case ventaOriginal
                    Case 1
                        saldoItem = objItemsaldo.MontoDeudaSoles - i.montoSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault
                        saldoItemME = objItemsaldo.MontoDeudaUSD - i.montoUsd - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault

                        If saldoItem <= 0 Then
                            VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                        Else
                            VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        End If
                    Case 2
                        saldoItem = objItemsaldo.MontoDeudaSoles - i.montoSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault
                        saldoItemME = objItemsaldo.MontoDeudaUSD - i.montoUsd - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault

                        If saldoItemME <= 0 Then
                            VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                        Else
                            VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        End If
                End Select




                If (objDocumentoBE.documentoCaja.tipoMovimiento = MovimientoCaja.EntradaDinero) Then
                    nDetalle = New documentoCajaDetalle
                    nDetalle.idDocumento = intDocCaja
                    nDetalle.documentoAfectado = i.documentoAfectado
                    nDetalle.secuencia = i.secuencia
                    nDetalle.fecha = i.fecha
                    nDetalle.idItem = i.idItem
                    nDetalle.DetalleItem = i.DetalleItem
                    nDetalle.montoSoles = i.montoSoles
                    nDetalle.montoUsd = i.montoUsd
                    nDetalle.entregado = i.entregado
                    nDetalle.diferTipoCambio = i.diferTipoCambio
                    nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                    nDetalle.idCajaUsuario = i.idCajaUsuario
                    nDetalle.usuarioModificacion = i.usuarioModificacion
                    nDetalle.fechaModificacion = i.fechaModificacion

                    HeliosData.documentoCajaDetalle.Add(nDetalle)

                    'for
                ElseIf (objDocumentoBE.documentoCaja.tipoMovimiento = MovimientoCaja.SalidaDinero) Then

                    Dim consultaCaja = (From c In listaDetalle
                                        Order By c.fecha).ToList

                    For Each item In consultaCaja
                        Dim Salidas = (Aggregate n In listadocumento _
                                   Where n.documentoAfectado = item.idDocumento And _
                                   n.secuencia = item.secuencia _
                                   Into sumMN = Sum(n.montoSoles), sumME = Sum(n.montoUsd))

                        saldoMN = i.montoSoles
                        saldoME = i.montoUsd


                        Select Case i.moneda
                            Case 1

                                If (ventaOriginal) Then
                                    If (saldoME > 0) Then
                                        nDetalle = New documentoCajaDetalle
                                        nDetalle.idDocumento = intDocCaja
                                        nDetalle.documentoAfectado = i.documentoAfectado
                                        nDetalle.secuencia = i.secuencia
                                        nDetalle.fecha = i.fecha
                                        nDetalle.idItem = i.idItem
                                        nDetalle.DetalleItem = i.DetalleItem
                                        nDetalle.diferTipoCambio = item.diferTipoCambio
                                        nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                        nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                                        nDetalle.idCajaPadre = item.secuencia
                                        nDetalle.idCajaUsuario = i.idCajaUsuario
                                        nDetalle.usuarioModificacion = i.usuarioModificacion
                                        nDetalle.fechaModificacion = i.fechaModificacion
                                        nDetalle.entregado = i.entregado

                                        If ((item.montoUsd - Salidas.sumME.GetValueOrDefault) >= i.montoUsd And i.montoUsd = 0) Then
                                            nDetalle.montoSoles = i.montoSoles
                                            nDetalle.montoUsd = i.montoUsd
                                            saldoME = item.montoUsd - i.montoUsd
                                            i.montoUsd = saldoME
                                            HeliosData.documentoCajaDetalle.Add(nDetalle)
                                        ElseIf ((item.montoUsd - Salidas.sumME.GetValueOrDefault) <= i.montoUsd And i.montoUsd = 0) Then
                                            nDetalle.montoSoles = i.montoSoles
                                            nDetalle.montoUsd = i.montoUsd
                                            saldoME = item.montoUsd - i.montoUsd
                                            i.montoUsd = saldoME
                                            HeliosData.documentoCajaDetalle.Add(nDetalle)
                                        ElseIf ((item.montoUsd - Salidas.sumME.GetValueOrDefault) < i.montoUsd And i.montoUsd > 0 And (item.montoUsd - Salidas.sumME.GetValueOrDefault) > 0) Then
                                            'nDetalle.montoSolesTransacc = Math.Round(CDec((item.montoUsd - Salidas.sumME.GetValueOrDefault) * i.tipoCambioTransacc), 2)
                                            nDetalle.montoSolesTransacc = CDec(((item.montoUsd - Salidas.sumME.GetValueOrDefault) * i.tipoCambioTransacc)).ToString("n2")
                                            nDetalle.montoUsdTransacc = CDec((item.montoUsd - Salidas.sumME.GetValueOrDefault)).ToString("N2")
                                            nDetalle.montoSoles = Math.Round(CDec((item.montoUsd - Salidas.sumME.GetValueOrDefault) * item.diferTipoCambio), 2)
                                            nDetalle.montoUsd = (item.montoUsd - Salidas.sumME.GetValueOrDefault)
                                            saldoME = saldoME - nDetalle.montoUsd
                                            i.montoUsd = saldoME
                                            saldoMN = saldoMN - nDetalle.montoSolesTransacc
                                            i.montoSoles = saldoMN
                                            Dim docuem As New documentoCajaDetalle
                                            docuem.documentoAfectado = item.idDocumento
                                            docuem.secuencia = item.secuencia
                                            docuem.montoSoles = nDetalle.montoSoles
                                            docuem.montoUsd = nDetalle.montoUsd
                                            listadocumento.Add(docuem)
                                            HeliosData.documentoCajaDetalle.Add(nDetalle)
                                        ElseIf ((item.montoUsd - Salidas.sumME) > i.montoUsd And i.montoUsd > 0) Then
                                            'nDetalle.montoSolesTransacc = Math.Round(CDec(i.montoUsd * i.tipoCambioTransacc), 2)
                                            nDetalle.montoSolesTransacc = CDec(i.montoSoles)
                                            nDetalle.montoUsdTransacc = CDec((i.montoSoles) / i.tipoCambioTransacc).ToString("N2")
                                            nDetalle.montoSoles = Math.Round(CDec(i.montoUsd * item.diferTipoCambio), 2)
                                            nDetalle.montoUsd = i.montoUsd
                                            saldoME = saldoME - i.montoUsd
                                            i.montoUsd = saldoME
                                            saldoMN = saldoMN - i.montoSoles
                                            i.montoSoles = saldoMN
                                            Dim docuem As New documentoCajaDetalle
                                            docuem.documentoAfectado = item.idDocumento
                                            docuem.secuencia = item.secuencia
                                            docuem.montoSoles = nDetalle.montoSoles
                                            docuem.montoUsd = nDetalle.montoUsd
                                            listadocumento.Add(docuem)
                                            HeliosData.documentoCajaDetalle.Add(nDetalle)
                                        ElseIf ((item.montoUsd - Salidas.sumME) > i.montoUsd And i.montoUsd < 0) Then

                                            nDetalle.montoSolesTransacc = CDec(i.montoSoles * -1)
                                            nDetalle.montoUsdTransacc = Math.Round(CDec((i.montoSoles * -1) / i.tipoCambioTransacc), 2)
                                            nDetalle.montoSoles = Math.Round(CDec((i.montoUsd * -1) * item.diferTipoCambio), 2)
                                            nDetalle.montoUsd = Math.Round(CDec(i.montoUsd * -1), 2)
                                            saldoME = item.montoUsd - i.montoUsd
                                            i.montoUsd = saldoME
                                            Dim docuem As New documentoCajaDetalle
                                            docuem.documentoAfectado = item.idDocumento
                                            docuem.secuencia = item.secuencia
                                            docuem.montoSoles = nDetalle.montoSoles
                                            docuem.montoUsd = nDetalle.montoUsd
                                            listadocumento.Add(docuem)
                                            HeliosData.documentoCajaDetalle.Add(nDetalle)
                                        ElseIf ((item.montoUsd - Salidas.sumME) = i.montoUsd And i.montoUsd > 0) Then
                                            'nDetalle.montoSolesTransacc = Math.Round(CDec(i.montoUsd * i.tipoCambioTransacc), 2)
                                            nDetalle.montoSolesTransacc = i.montoSoles
                                            nDetalle.montoUsdTransacc = CDec((i.montoSoles) / i.tipoCambioTransacc).ToString("N2")
                                            nDetalle.montoSoles = Math.Round(CDec(i.montoUsd * item.diferTipoCambio), 2)
                                            nDetalle.montoUsd = i.montoUsd
                                            saldoME = saldoME - i.montoUsd
                                            i.montoUsd = saldoME
                                            Dim docuem As New documentoCajaDetalle
                                            docuem.documentoAfectado = item.idDocumento
                                            docuem.secuencia = item.secuencia
                                            docuem.montoSoles = nDetalle.montoSoles
                                            docuem.montoUsd = nDetalle.montoUsd
                                            listadocumento.Add(docuem)
                                            HeliosData.documentoCajaDetalle.Add(nDetalle)
                                        End If
                                    End If
                                Else
                                    If (saldoMN > 0) Then
                                        nDetalle = New documentoCajaDetalle
                                        nDetalle.idDocumento = intDocCaja
                                        nDetalle.documentoAfectado = i.documentoAfectado
                                        nDetalle.secuencia = i.secuencia
                                        nDetalle.fecha = i.fecha
                                        nDetalle.idItem = i.idItem
                                        nDetalle.DetalleItem = i.DetalleItem
                                        nDetalle.diferTipoCambio = item.diferTipoCambio
                                        nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                        nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                                        nDetalle.idCajaPadre = item.secuencia
                                        nDetalle.idCajaUsuario = i.idCajaUsuario
                                        nDetalle.usuarioModificacion = i.usuarioModificacion
                                        nDetalle.fechaModificacion = i.fechaModificacion
                                        nDetalle.entregado = i.entregado

                                        If ((item.montoSoles - Salidas.sumMN.GetValueOrDefault) >= i.montoSoles And i.montoSoles = 0) Then
                                            nDetalle.montoSoles = i.montoSoles
                                            nDetalle.montoUsd = i.montoUsd
                                            saldoME = item.montoUsd - i.montoUsd
                                            i.montoUsd = saldoME
                                            HeliosData.documentoCajaDetalle.Add(nDetalle)
                                        ElseIf ((item.montoSoles - Salidas.sumMN.GetValueOrDefault) <= i.montoSoles And i.montoSoles = 0) Then
                                            nDetalle.montoSoles = i.montoSoles
                                            nDetalle.montoUsd = i.montoUsd
                                            saldoME = item.montoUsd - i.montoUsd
                                            i.montoUsd = saldoME
                                            HeliosData.documentoCajaDetalle.Add(nDetalle)
                                        ElseIf ((item.montoSoles - Salidas.sumMN.GetValueOrDefault) < i.montoSoles And i.montoSoles > 0 And (item.montoSoles - Salidas.sumMN.GetValueOrDefault) > 0) Then
                                            'nDetalle.montoSolesTransacc = Math.Round(CDec((item.montoUsd - Salidas.sumME.GetValueOrDefault) * i.tipoCambioTransacc), 2)
                                            nDetalle.montoSolesTransacc = CDec(item.montoSoles - Salidas.sumMN.GetValueOrDefault)
                                            nDetalle.montoUsdTransacc = CDec((item.montoUsd - Salidas.sumME.GetValueOrDefault)).ToString("N2")
                                            nDetalle.montoSoles = CDec(item.montoSoles - Salidas.sumMN.GetValueOrDefault)
                                            nDetalle.montoUsd = CDec((item.montoSoles - Salidas.sumMN.GetValueOrDefault) / item.diferTipoCambio).ToString("N2")
                                            saldoME = saldoME - nDetalle.montoUsd
                                            i.montoUsd = saldoME
                                            saldoMN = saldoMN - nDetalle.montoSolesTransacc
                                            i.montoSoles = saldoMN
                                            Dim docuem As New documentoCajaDetalle
                                            docuem.documentoAfectado = item.idDocumento
                                            docuem.secuencia = item.secuencia
                                            docuem.montoSoles = nDetalle.montoSoles
                                            docuem.montoUsd = nDetalle.montoUsd
                                            listadocumento.Add(docuem)
                                            HeliosData.documentoCajaDetalle.Add(nDetalle)
                                        ElseIf ((item.montoSoles - Salidas.sumMN) > i.montoSoles And i.montoSoles > 0) Then
                                            'nDetalle.montoSolesTransacc = Math.Round(CDec(i.montoUsd * i.tipoCambioTransacc), 2)
                                            nDetalle.montoSolesTransacc = (CDec(i.montoSoles))
                                            nDetalle.montoUsdTransacc = CDec((i.montoSoles) / i.tipoCambioTransacc).ToString("N2")
                                            nDetalle.montoSoles = CDec(i.montoSoles)
                                            nDetalle.montoUsd = CDec(i.montoSoles / item.diferTipoCambio).ToString("N2")
                                            saldoME = saldoME - i.montoUsd
                                            i.montoUsd = saldoME
                                            saldoMN = saldoMN - i.montoSoles
                                            i.montoSoles = saldoMN
                                            Dim docuem As New documentoCajaDetalle
                                            docuem.documentoAfectado = item.idDocumento
                                            docuem.secuencia = item.secuencia
                                            docuem.montoSoles = nDetalle.montoSoles
                                            docuem.montoUsd = nDetalle.montoUsd
                                            listadocumento.Add(docuem)
                                            HeliosData.documentoCajaDetalle.Add(nDetalle)
                                        ElseIf ((item.montoSoles - Salidas.sumMN) > i.montoSoles And i.montoSoles < 0) Then

                                            nDetalle.montoSolesTransacc = CDec(i.montoSoles * -1)
                                            nDetalle.montoUsdTransacc = Math.Round(CDec((i.montoSoles * -1) / i.tipoCambioTransacc), 2)
                                            nDetalle.montoSoles = CDec(i.montoSoles * -1)
                                            nDetalle.montoUsd = Math.Round(CDec((i.montoSoles * -1) / i.tipoCambioTransacc), 2)
                                            saldoME = item.montoUsd - i.montoUsd
                                            i.montoUsd = saldoME
                                            Dim docuem As New documentoCajaDetalle
                                            docuem.documentoAfectado = item.idDocumento
                                            docuem.secuencia = item.secuencia
                                            docuem.montoSoles = nDetalle.montoSoles
                                            docuem.montoUsd = nDetalle.montoUsd
                                            listadocumento.Add(docuem)
                                            HeliosData.documentoCajaDetalle.Add(nDetalle)
                                        ElseIf ((item.montoSoles - Salidas.sumMN) = i.montoSoles And i.montoSoles > 0) Then
                                            'nDetalle.montoSolesTransacc = Math.Round(CDec(i.montoUsd * i.tipoCambioTransacc), 2)
                                            nDetalle.montoSolesTransacc = i.montoSoles
                                            nDetalle.montoUsdTransacc = CDec((i.montoSoles) / i.tipoCambioTransacc).ToString("N2")
                                            nDetalle.montoSoles = i.montoSoles
                                            nDetalle.montoUsd = CDec(i.montoSoles / item.diferTipoCambio).ToString("N2")
                                            saldoME = saldoME - i.montoUsd
                                            i.montoUsd = saldoME
                                            Dim docuem As New documentoCajaDetalle
                                            docuem.documentoAfectado = item.idDocumento
                                            docuem.secuencia = item.secuencia
                                            docuem.montoSoles = nDetalle.montoSoles
                                            docuem.montoUsd = nDetalle.montoUsd
                                            listadocumento.Add(docuem)
                                            HeliosData.documentoCajaDetalle.Add(nDetalle)
                                        End If
                                    End If

                                End If



                            Case 2

                                If (saldoME > 0) Then
                                    nDetalle = New documentoCajaDetalle
                                    nDetalle.idDocumento = intDocCaja
                                    nDetalle.documentoAfectado = i.documentoAfectado
                                    nDetalle.secuencia = i.secuencia
                                    nDetalle.fecha = i.fecha
                                    nDetalle.idItem = i.idItem
                                    nDetalle.DetalleItem = i.DetalleItem
                                    nDetalle.diferTipoCambio = item.diferTipoCambio
                                    nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                    nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                                    nDetalle.idCajaPadre = item.secuencia
                                    nDetalle.idCajaUsuario = i.idCajaUsuario
                                    nDetalle.usuarioModificacion = i.usuarioModificacion
                                    nDetalle.fechaModificacion = i.fechaModificacion
                                    nDetalle.entregado = i.entregado

                                    If ((item.montoUsd - Salidas.sumME.GetValueOrDefault) >= i.montoUsd And i.montoUsd = 0) Then
                                        nDetalle.montoSoles = i.montoSoles
                                        nDetalle.montoUsd = i.montoUsd
                                        saldoME = item.montoUsd - i.montoUsd
                                        i.montoUsd = saldoME
                                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                                    ElseIf ((item.montoUsd - Salidas.sumME.GetValueOrDefault) <= i.montoUsd And i.montoUsd = 0) Then
                                        nDetalle.montoSoles = i.montoSoles
                                        nDetalle.montoUsd = i.montoUsd
                                        saldoME = item.montoUsd - i.montoUsd
                                        i.montoUsd = saldoME
                                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                                    ElseIf ((item.montoUsd - Salidas.sumME.GetValueOrDefault) < i.montoUsd And i.montoUsd > 0 And (item.montoUsd - Salidas.sumME.GetValueOrDefault) > 0) Then
                                        'nDetalle.montoSolesTransacc = Math.Round(CDec((item.montoUsd - Salidas.sumME.GetValueOrDefault) * i.tipoCambioTransacc), 2)
                                        nDetalle.montoSolesTransacc = CDec(((item.montoUsd - Salidas.sumME.GetValueOrDefault) * i.tipoCambioTransacc)).ToString("n2")
                                        nDetalle.montoUsdTransacc = CDec((item.montoUsd - Salidas.sumME.GetValueOrDefault)).ToString("N2")
                                        nDetalle.montoSoles = Math.Round(CDec((item.montoUsd - Salidas.sumME.GetValueOrDefault) * item.diferTipoCambio), 2)
                                        nDetalle.montoUsd = (item.montoUsd - Salidas.sumME.GetValueOrDefault)
                                        saldoME = saldoME - nDetalle.montoUsd
                                        i.montoUsd = saldoME
                                        saldoMN = saldoMN - nDetalle.montoSolesTransacc
                                        i.montoSoles = saldoMN
                                        Dim docuem As New documentoCajaDetalle
                                        docuem.documentoAfectado = item.idDocumento
                                        docuem.secuencia = item.secuencia
                                        docuem.montoSoles = nDetalle.montoSoles
                                        docuem.montoUsd = nDetalle.montoUsd
                                        listadocumento.Add(docuem)
                                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                                    ElseIf ((item.montoUsd - Salidas.sumME) > i.montoUsd And i.montoUsd > 0) Then
                                        'nDetalle.montoSolesTransacc = Math.Round(CDec(i.montoUsd * i.tipoCambioTransacc), 2)
                                        nDetalle.montoSolesTransacc = CDec(i.montoSoles)
                                        nDetalle.montoUsdTransacc = CDec((i.montoSoles) / i.tipoCambioTransacc).ToString("N2")
                                        nDetalle.montoSoles = Math.Round(CDec(i.montoUsd * item.diferTipoCambio), 2)
                                        nDetalle.montoUsd = i.montoUsd
                                        saldoME = saldoME - i.montoUsd
                                        i.montoUsd = saldoME
                                        saldoMN = saldoMN - i.montoSoles
                                        i.montoSoles = saldoMN
                                        Dim docuem As New documentoCajaDetalle
                                        docuem.documentoAfectado = item.idDocumento
                                        docuem.secuencia = item.secuencia
                                        docuem.montoSoles = nDetalle.montoSoles
                                        docuem.montoUsd = nDetalle.montoUsd
                                        listadocumento.Add(docuem)
                                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                                    ElseIf ((item.montoUsd - Salidas.sumME) > i.montoUsd And i.montoUsd < 0) Then

                                        nDetalle.montoSolesTransacc = CDec(i.montoSoles * -1)
                                        nDetalle.montoUsdTransacc = Math.Round(CDec((i.montoSoles * -1) / i.tipoCambioTransacc), 2)
                                        nDetalle.montoSoles = Math.Round(CDec((i.montoUsd * -1) * item.diferTipoCambio), 2)
                                        nDetalle.montoUsd = Math.Round(CDec(i.montoUsd * -1), 2)
                                        saldoME = item.montoUsd - i.montoUsd
                                        i.montoUsd = saldoME
                                        Dim docuem As New documentoCajaDetalle
                                        docuem.documentoAfectado = item.idDocumento
                                        docuem.secuencia = item.secuencia
                                        docuem.montoSoles = nDetalle.montoSoles
                                        docuem.montoUsd = nDetalle.montoUsd
                                        listadocumento.Add(docuem)
                                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                                    ElseIf ((item.montoUsd - Salidas.sumME) = i.montoUsd And i.montoUsd > 0) Then
                                        'nDetalle.montoSolesTransacc = Math.Round(CDec(i.montoUsd * i.tipoCambioTransacc), 2)
                                        nDetalle.montoSolesTransacc = i.montoSoles
                                        nDetalle.montoUsdTransacc = CDec((i.montoSoles) / i.tipoCambioTransacc).ToString("N2")
                                        nDetalle.montoSoles = Math.Round(CDec(i.montoUsd * item.diferTipoCambio), 2)
                                        nDetalle.montoUsd = i.montoUsd
                                        saldoME = saldoME - i.montoUsd
                                        i.montoUsd = saldoME
                                        Dim docuem As New documentoCajaDetalle
                                        docuem.documentoAfectado = item.idDocumento
                                        docuem.secuencia = item.secuencia
                                        docuem.montoSoles = nDetalle.montoSoles
                                        docuem.montoUsd = nDetalle.montoUsd
                                        listadocumento.Add(docuem)
                                        HeliosData.documentoCajaDetalle.Add(nDetalle)
                                    End If
                                End If

                        End Select

                    Next
                End If
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    'Public Sub UpdateEstadoCajaMN(intIdDocumentoCaja As Integer, estadoCaja As String, montoRetiro As Decimal)
    '    Using ts As New TransactionScope
    '        Dim nDetalle As documentoCajaDetalle = HeliosData.documentoCajaDetalle.Where(Function(o) o.idDocumento = intIdDocumentoCaja).First
    '        nDetalle.estadoCaja = estadoCaja
    '        Select Case nDetalle.estadoCaja
    '            Case 1
    '                If (CDec(nDetalle.montoSolesRef = montoRetiro)) Then
    '                    nDetalle.montoUsdRef = 0
    '                    nDetalle.montoSolesRef = 0
    '                Else
    '                    nDetalle.montoUsdRef = Math.Round(CDec(nDetalle.montoUsdRef - CDec(montoRetiro)), 2)
    '                    nDetalle.montoSolesRef = Math.Round(CDec((nDetalle.montoUsdRef - montoRetiro) * nDetalle.diferTipoCambio), 2)
    '                End If
    '            Case 2
    '                If (CDec(nDetalle.montoSolesRef >= montoRetiro) And montoRetiro < 0) Then
    '                    nDetalle.montoUsdRef = Math.Round(CDec(nDetalle.montoUsdRef - CDec(montoRetiro * -1)), 2)
    '                    nDetalle.montoSolesRef = Math.Round(CDec((nDetalle.montoUsdRef - (montoRetiro * -1)) * nDetalle.diferTipoCambio), 2)
    '                ElseIf (CDec(nDetalle.montoSolesRef >= montoRetiro) And montoRetiro > 0) Then
    '                    nDetalle.montoUsdRef = Math.Round(CDec((nDetalle.montoSolesRef - montoRetiro) / nDetalle.diferTipoCambio), 2)
    '                    nDetalle.montoSolesRef = Math.Round(CDec(nDetalle.montoSolesRef - montoRetiro), 2)
    '                Else
    '                    nDetalle.montoUsdRef = 0
    '                    nDetalle.montoSolesRef = 0
    '                End If
    '        End Select

    '        HeliosData.SaveChanges()
    '        ts.Complete()
    '    End Using
    'End Sub

    Function ConsultaMovimientoME(intEntidadFinanciera As Integer) As List(Of documentoCajaDetalle)
        Dim lista As New List(Of documentoCajaDetalle)
        Dim nDetalle As New documentoCajaDetalle
        Dim objItemsaldo As New documentoCajaDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL

        Using ts As New TransactionScope

            Dim consultaCaja = (From c In HeliosData.documentoCaja _
                                Join d In HeliosData.documentoCajaDetalle _
                                On c.idDocumento Equals d.idDocumento _
                        Where c.tipoMovimiento = "DC" And _
                        c.entidadFinanciera = intEntidadFinanciera _
                        Order By d.fecha).ToList

            For Each item In consultaCaja

                Dim Salidas = (Aggregate n In HeliosData.documentoCaja Join
                        d In HeliosData.documentoCajaDetalle On n.idDocumento Equals d.idDocumento _
                           Where n.entidadFinanciera = intEntidadFinanciera And n.tipoMovimiento = "PG" And _
                           d.idCajaPadre = item.d.secuencia _
                           Into sumMN = Sum(d.montoSoles), sumME = Sum(d.montoUsd))

                Select Case item.c.moneda
                    Case 2


                        nDetalle = New documentoCajaDetalle
                        nDetalle.montoSoles = item.d.montoSoles - Salidas.sumMN.GetValueOrDefault
                        nDetalle.montoUsd = item.d.montoUsd - Salidas.sumME.GetValueOrDefault
                        nDetalle.idDocumento = item.d.idDocumento
                        nDetalle.documentoAfectado = item.d.documentoAfectado
                        nDetalle.secuencia = item.d.secuencia
                        nDetalle.fecha = item.d.fecha
                        nDetalle.idItem = item.d.idItem
                        nDetalle.DetalleItem = item.d.DetalleItem
                        nDetalle.entregado = item.d.entregado
                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                        nDetalle.tipoCambioTransacc = item.d.tipoCambioTransacc
                        nDetalle.documentoAfectadodetalle = item.d.documentoAfectadodetalle
                        nDetalle.idCajaPadre = item.d.idDocumento
                        nDetalle.usuarioModificacion = item.d.usuarioModificacion
                        nDetalle.fechaModificacion = item.d.fechaModificacion

                    Case 1

                        nDetalle = New documentoCajaDetalle
                        nDetalle.montoSoles = item.d.montoSoles - Salidas.sumMN.GetValueOrDefault
                        nDetalle.montoUsd = item.d.montoUsd - Salidas.sumME.GetValueOrDefault
                        nDetalle.idDocumento = item.d.idDocumento
                        nDetalle.documentoAfectado = item.d.documentoAfectado
                        nDetalle.secuencia = item.d.secuencia
                        nDetalle.fecha = item.d.fecha
                        nDetalle.idItem = item.d.idItem
                        nDetalle.DetalleItem = item.d.DetalleItem
                        nDetalle.entregado = item.d.entregado
                        nDetalle.diferTipoCambio = item.d.diferTipoCambio
                        nDetalle.tipoCambioTransacc = item.d.tipoCambioTransacc
                        nDetalle.documentoAfectadodetalle = item.d.documentoAfectadodetalle
                        nDetalle.idCajaPadre = item.d.idDocumento
                        nDetalle.usuarioModificacion = item.d.usuarioModificacion
                        nDetalle.fechaModificacion = item.d.fechaModificacion

                End Select
                If (nDetalle.montoUsd > 0) Then
                    lista.Add(nDetalle)
                End If
            Next

            Return lista

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Function

    '    Function ConsultaMovimientosPorCajaxEstadoFinanciero(idCajausaurio As Integer) As List(Of documentoCajaDetalle)
    '        Dim lista As New List(Of documentoCajaDetalle)
    '        Dim nDetalle As New documentoCajaDetalle
    '        Dim objItemsaldo As New documentoCajaDetalle
    '        Dim cajaDetalleBL As New documentoCajaDetalleBL

    '        '        Dim consultaCaja = (From DCD In HeliosData.documentoCajaDetalle
    '        'Join DV In HeliosData.estadosFinancieros On New With {.EntidadFinanciera = DCD.documentoCaja.entidadFinanciera} Equals New With {.EntidadFinanciera = CStr(DV.idestado)}
    '        'Where
    '        'CLng(DCD.documentoCaja.idCajaUsuario) = idCajausaurio
    '        'Group New With {DV, DCD} By
    '        'DV.tipo,
    '        'DV.codigo,
    '        '  DV.descripcion
    '        'Into g = Group
    '        'Select
    '        'Column1 = CType(g.Sum(Function(p) p.DCD.montoSoles), Decimal?),
    '        'tipo,
    '        'codigo,
    '        '  descripcion).ToList

    '        Dim consultaCaja = (From u In HeliosData.cajaUsuariodetalle
    'Join f In HeliosData.estadosFinancieros On New With {.Idestado = CInt(u.idEntidad)} Equals New With {.Idestado = f.idestado}
    'Where
    '  CLng(u.idcajaUsuario) = idCajausaurio
    'Select
    '  IdEntidad = CType(u.idEntidad, Int32?),
    '  f.descripcion,
    '  u.importeMN,
    '  f.tipo,
    '  Column1 = (CType((Aggregate t1 In
    '    (From c In HeliosData.documentoCaja
    '    Join x In HeliosData.cajaUsuariodetalle
    '          On New With {c.entidadFinanciera, .IdEntidad = c.entidadFinanciera} Equals (New With {.EntidadFinanciera = CStr(f.idestado), .IdEntidad = CStr(x.IdEntidad)})
    '    Select New With {
    '      c.montoSoles
    '    }) Into Sum(t1.montoSoles)), Decimal?))).ToList

    '        For Each item In consultaCaja
    '            nDetalle = New documentoCajaDetalle
    '            nDetalle.idCajaPadre = item.IdEntidad
    '            nDetalle.estado = item.tipo
    '            nDetalle.montoSoles = item.Column1.GetValueOrDefault
    '            nDetalle.nomEntidad = item.descripcion
    '            nDetalle.ImporteExtranjero = item.importeMN
    '            lista.Add(nDetalle)

    '        Next

    '        Return lista

    '    End Function

    Function ListacajausuarioXDetalleAcumulado(intIdPersona As Integer, fechaInicio As DateTime, fechaFin As DateTime) As List(Of documentoventaAbarrotesDet)
        Dim lista As New List(Of documentoventaAbarrotesDet)
        Dim nDetalle As New documentoventaAbarrotesDet
        Dim objItemsaldo As New documentoventaAbarrotes
        Dim cajaDetalleBL As New documentoCajaDetalleBL

        Using ts As New TransactionScope

            Dim consultaCaja = (From v In HeliosData.documentoventaAbarrotesDet
                     Join d In HeliosData.documentoventaAbarrotes
                     On v.idDocumento Equals d.idDocumento
                     Join x In HeliosData.configuracionPrecio
                     On v.tipoVenta Equals x.idPrecio
Where v.usuarioModificacion = CStr(intIdPersona) And
  CStr(d.fechaDoc) >= fechaInicio And
  CStr(d.fechaDoc) <= fechaFin).ToList


            For Each item In consultaCaja
                nDetalle = New documentoventaAbarrotesDet
                nDetalle.unidad1 = item.v.unidad1
                nDetalle.monto1 = item.v.monto1
                nDetalle.tipoVenta = item.v.tipoVenta
                nDetalle.importeME = item.x.tasaPorcentaje
                nDetalle.importeMN = item.v.importeMN
                nDetalle.estadoPago = item.d.estadoCobro
                nDetalle.tipoExistencia = item.v.tipoExistencia
                lista.Add(nDetalle)

            Next

            Return lista

        End Using
    End Function

    Function ListacajausuarioXCuentasXcobrar(intIdPersona As Integer, fechaInicio As DateTime, fechaFin As DateTime) As List(Of documentoventaAbarrotes)
        Dim lista As New List(Of documentoventaAbarrotes)
        Dim nDetalle As New documentoventaAbarrotes
        Dim objItemsaldo As New documentoventaAbarrotes
        Dim cajaDetalleBL As New documentoCajaDetalleBL

        Using ts As New TransactionScope


            '            Dim consultaCaja = (From c In HeliosData.documentoventaAbarrotes
            'Join d In HeliosData.documentoventaAbarrotesDet
            '      On New With {.IdDocumento = CInt(c.idDocumento)} Equals (New With {d.idDocumento})
            '            Where d.usuarioModificacion = CStr(intIdPersona) And
            '  CStr(c.fechaDoc) >= fechaInicio And
            '  CStr(c.fechaDoc) <= fechaFin And
            '            c.estadoCobro = "PN" Select c).ToList

            Dim consultaCaja = (From v In HeliosData.documentoventaAbarrotesDet
                                Where
  v.usuarioModificacion = CStr(intIdPersona) And
  CStr(v.documentoventaAbarrotes.fechaDoc) >= fechaInicio And
  CStr(v.documentoventaAbarrotes.fechaDoc) <= fechaFin And
  v.documentoventaAbarrotes.estadoCobro = "PN"
                                Group New With {v, v.documentoventaAbarrotes} By
  v.usuarioModificacion,
  ImporteNacional = CType(v.documentoventaAbarrotes.ImporteNacional, Decimal?),
  v.documentoventaAbarrotes.tipoOperacion,
  v.documentoventaAbarrotes.numeroDocNormal,
  v.documentoventaAbarrotes.nombrePedido,
  v.documentoventaAbarrotes.serie,
v.documentoventaAbarrotes.fechaDoc
            Into g = Group
                                Select
  ImporteNacional = CType(ImporteNacional, Decimal?),
  tipoOperacion,
  usuarioModificacion,
  numeroDocNormal,
  nombrePedido,
   fechaDoc,
  serie).ToList


            For Each item In consultaCaja
                nDetalle = New documentoventaAbarrotes
                nDetalle.numeroDocNormal = item.numeroDocNormal
                nDetalle.ImporteNacional = item.ImporteNacional
                nDetalle.nombrePedido = item.nombrePedido
                nDetalle.serie = item.serie
                nDetalle.tipoOperacion = item.tipoOperacion
                nDetalle.fechaDoc = item.FechaDoc
                lista.Add(nDetalle)

            Next

            Return lista

            'HeliosData.SaveChanges()
            'ts.Complete()
        End Using
    End Function


    Function ListacajausuarioXCuentasXCompra(intIdPersona As Integer, fechaInicio As DateTime, fechaFin As DateTime) As List(Of documentocompra)
        Dim lista As New List(Of documentocompra)
        Dim nDetalle As New documentocompra
        Dim objItemsaldo As New documentoventaAbarrotes
        Dim cajaDetalleBL As New documentoCajaDetalleBL

        Using ts As New TransactionScope


            '            Dim consultaCaja = (From c In HeliosData.documentoventaAbarrotes
            'Join d In HeliosData.documentoventaAbarrotesDet
            '      On New With {.IdDocumento = CInt(c.idDocumento)} Equals (New With {d.idDocumento})
            '            Where d.usuarioModificacion = CStr(intIdPersona) And
            '  CStr(c.fechaDoc) >= fechaInicio And
            '  CStr(c.fechaDoc) <= fechaFin And
            '            c.estadoCobro = "PN" Select c).ToList

            Dim consultaCaja = (From v In HeliosData.documentocompradetalle
                                Where
  v.usuarioModificacion = CStr(intIdPersona) And
  CStr(v.documentocompra.fechaDoc) >= fechaInicio And
  CStr(v.documentocompra.fechaDoc) <= fechaFin And
  v.documentocompra.estadoPago = "PG"
                                Group New With {v, v.documentocompra} By
  v.usuarioModificacion,
  ImporteNacional = CType(v.documentocompra.importeTotal, Decimal?),
  v.documentocompra.codigoLibro,
  v.documentocompra.numeroDoc,
  v.documentocompra.idProveedor,
  v.documentocompra.serie,
  v.documentocompra.fechaDoc
 Into g = Group
                                Select
  ImporteNacional = CType(ImporteNacional, Decimal?),
  codigoLibro,
  usuarioModificacion,
  numeroDoc,
  idProveedor,
   fechaDoc,
  serie).ToList


            For Each item In consultaCaja
                nDetalle = New documentocompra
                nDetalle.numeroDoc = item.numeroDoc
                nDetalle.importeTotal = item.ImporteNacional
                nDetalle.nombreProveedor = item.idProveedor
                nDetalle.serie = item.serie
                nDetalle.tipoOperacion = item.codigoLibro
                nDetalle.fechaDoc = item.fechaDoc
                lista.Add(nDetalle)

            Next

            Return lista

            'HeliosData.SaveChanges()
            'ts.Complete()
        End Using
    End Function

    '    Function ConsultaMovimientosPorCajaxEstadoFinanciero(idCajausaurio As Integer) As List(Of documentoCajaDetalle)
    '        Dim lista As New List(Of documentoCajaDetalle)
    '        Dim nDetalle As New documentoCajaDetalle
    '        Dim objItemsaldo As New documentoCajaDetalle
    '        Dim cajaDetalleBL As New documentoCajaDetalleBL

    '        '        Dim consultaCaja = (From DCD In HeliosData.documentoCajaDetalle
    '        'Join DV In HeliosData.estadosFinancieros On New With {.EntidadFinanciera = DCD.documentoCaja.entidadFinanciera} Equals New With {.EntidadFinanciera = CStr(DV.idestado)}
    '        'Where
    '        'CLng(DCD.documentoCaja.idCajaUsuario) = idCajausaurio
    '        'Group New With {DV, DCD} By
    '        'DV.tipo,
    '        'DV.codigo,
    '        '  DV.descripcion
    '        'Into g = Group
    '        'Select
    '        'Column1 = CType(g.Sum(Function(p) p.DCD.montoSoles), Decimal?),
    '        'tipo,
    '        'codigo,
    '        '  descripcion).ToList

    '        Dim consultaCaja = (From u In HeliosData.cajaUsuariodetalle
    'Join f In HeliosData.estadosFinancieros On New With {.Idestado = CInt(u.idEntidad)} Equals New With {.Idestado = f.idestado}
    'Where
    '  CLng(u.idcajaUsuario) = idCajausaurio
    'Select
    '  IdEntidad = CType(u.idEntidad, Int32?),
    '  f.descripcion,
    '  u.importeMN,
    '  f.tipo,
    '  Column1 = (CType((Aggregate t1 In
    '    (From c In HeliosData.documentoCaja
    '    Join x In HeliosData.cajaUsuariodetalle
    '          On New With {c.entidadFinanciera, .IdEntidad = c.entidadFinanciera} Equals (New With {.EntidadFinanciera = CStr(f.idestado), .IdEntidad = CStr(x.IdEntidad)})
    '    Select New With {
    '      c.montoSoles
    '    }) Into Sum(t1.montoSoles)), Decimal?))).ToList

    '        For Each item In consultaCaja
    '            nDetalle = New documentoCajaDetalle
    '            nDetalle.idCajaPadre = item.IdEntidad
    '            nDetalle.estado = item.tipo
    '            nDetalle.montoSoles = item.Column1.GetValueOrDefault
    '            nDetalle.nomEntidad = item.descripcion
    '            nDetalle.ImporteExtranjero = item.importeMN
    '            lista.Add(nDetalle)

    '        Next

    '        Return lista

    '    End Function

    Function ConsultaMovimientosPorCajaxEstadoFinanciero(idCajausaurio As Integer) As List(Of documentoCajaDetalle)
        Dim lista As New List(Of documentoCajaDetalle)
        Dim nDetalle As New documentoCajaDetalle
        Dim objItemsaldo As New documentoCajaDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL

        '       Dim consultaCaja = (From d In HeliosData.documentoCajaDetalle
        '                           Join u In HeliosData.cajaUsuariodetalle
        'On New With {.IdCajaUsuario = CInt(d.idCajaUsuario), d.documentoCaja.entidadFinanciera} _
        '       Equals (New With {.IdCajaUsuario = u.idcajaUsuario, .EntidadFinanciera = CStr(u.idEntidad)})
        '                           Join f In HeliosData.estadosFinancieros On New With {.Idestado = CInt(u.idEntidad)} Equals New With {.Idestado = f.idestado}
        '                           Where CLng(u.idcajaUsuario) = idCajausaurio
        '                                 Group New With {u, f, d} By
        '       u.idEntidad,
        '       f.descripcion,
        '       u.importeMN,
        '       f.tipo,
        '       f.codigo
        '       Into g = Group
        '                           Select
        ' Column1 = CType(g.Sum(Function(p) p.d.montoSoles), Decimal?),
        ' IdEntidad = CType(idEntidad, Int32?),
        ' descripcion,
        ' importeMN,
        ' tipo,
        ' codigo).ToList

        Dim consultaCaja = From ef In HeliosData.estadosFinancieros
                           Join dc In HeliosData.cajaUsuariodetalle
                           On ef.idestado Equals dc.idEntidad
                           Join emp In HeliosData.empresa
                     On ef.idEmpresa Equals emp.idEmpresa
                           Where dc.idcajaUsuario = idCajausaurio
                           Order By
                     ef.tipo
                           Select
                     emp.nombreCorto,
                     ef.idEmpresa,
                     ef.descripcion,
                     ef.idestado,
                     ef.codigo,
                     ef.tipo,
                     dc.importeMN,
                     Ingreso = (CType((Aggregate t1 In
                                       (From c In HeliosData.documentoCaja
                                        Where
                                        c.entidadFinanciera = CStr(ef.idestado) And
                                        c.tipoMovimiento = "DC" And
                                        c.idCajaUsuario = idCajausaurio
                                        Select New With {
                                            c.montoSoles
                                        }) Into Sum(t1.montoSoles)), Decimal?)),
                    Salida = (CType((Aggregate t1 In
                                     (From c In HeliosData.documentoCaja
                                      Where
                                      c.entidadFinanciera = CStr(ef.idestado) And
                                      c.tipoMovimiento = "PG" And
                                        c.idCajaUsuario = idCajausaurio
                                      Select New With {
                                          c.montoSoles
                                      }) Into Sum(t1.montoSoles)), Decimal?))



        If (consultaCaja.Count <> 0) Then
            For Each item In consultaCaja
                nDetalle = New documentoCajaDetalle
                nDetalle.idCajaPadre = item.idestado
                nDetalle.estado = item.tipo
                nDetalle.montoSoles = item.Ingreso.GetValueOrDefault
                nDetalle.nomEntidad = item.descripcion
                nDetalle.ImporteExtranjero = item.importeMN
                nDetalle.DeudaCompME = item.Salida.GetValueOrDefault
                nDetalle.moneda = item.codigo
                lista.Add(nDetalle)

            Next
        Else
            Dim consulta2 = (From cd In HeliosData.cajaUsuariodetalle
                             Join e In HeliosData.estadosFinancieros On New With {.Idestado = CInt(cd.idEntidad)} Equals New With {.Idestado = e.idestado}
                             Where
              CLng(cd.cajaUsuario.idcajaUsuario) = idCajausaurio
                             Group New With {e, cd.cajaUsuario, cd} By
              e.descripcion,
              e.tipo,
              e.idestado,
              e.codigo,
              IdcajaUsuario = CType(cd.cajaUsuario.idcajaUsuario, Int32?)
             Into g = Group
                             Select
              Column1 = CType(g.Sum(Function(p) p.cd.importeMN), Decimal?),
              descripcion,
              tipo,
              Idestado = CType(idestado, Int32?),
              codigo,
              IdcajaUsuario = CType(IdcajaUsuario, Int32?))

            For Each item In consulta2
                nDetalle = New documentoCajaDetalle
                nDetalle.idCajaPadre = item.Idestado
                nDetalle.estado = item.tipo
                nDetalle.montoSoles = 0.0
                nDetalle.nomEntidad = item.descripcion
                nDetalle.ImporteExtranjero = item.Column1.GetValueOrDefault
                nDetalle.moneda = item.codigo
                lista.Add(nDetalle)
            Next
        End If

        Return lista

    End Function

    Function ConsultaMovimientosPorCajaYTipoExistencia(idCajausaurio As Integer) As List(Of documentoCajaDetalle)
        Dim lista As New List(Of documentoCajaDetalle)
        Dim nDetalle As New documentoCajaDetalle
        Dim objItemsaldo As New documentoCajaDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL

        Using ts As New TransactionScope

            '          Dim consultaCaja = (From DocumentoCajaDetalle In HeliosData.documentoCajaDetalle
            '                              Join DocumentDet In HeliosData.documentoventaAbarrotesDet
            '         On DocumentoCajaDetalle.documentoAfectado Equals DocumentDet.idDocumento And _
            '          DocumentoCajaDetalle.idItem Equals DocumentDet.idItem _
            '          Where CLng(DocumentoCajaDetalle.idCajaUsuario) = idCajausaurio
            '          Group New With {DocumentDet, DocumentoCajaDetalle} By
            '          DocumentDet.tipoExistencia,
            '          DocumentoCajaDetalle.montoSoles
            '          Into g = Group
            '          Select
            'Column1 = CType(g.Sum(Function(p) p.DocumentoCajaDetalle.montoSoles), Decimal?),
            'tipoExistencia).ToList

            Dim consultaCaja = (From c In HeliosData.documentoCajaDetalle
Join d In HeliosData.documentoventaAbarrotesDet
      On New With {c.idItem, .IdDocumento = CInt(c.documentoAfectado)} Equals (New With {d.idItem, d.idDocumento})
            Where CLng(c.idCajaUsuario) = idCajausaurio
Group New With {d, c} By d.tipoExistencia Into g = Group
Select Column1 = CType(g.Sum(Function(p) p.c.montoSoles), Decimal?), tipoExistencia).ToList

            For Each item In consultaCaja
                nDetalle = New documentoCajaDetalle
                nDetalle.TipoExistencia = item.TipoExistencia
                nDetalle.montoSoles = item.Column1
                lista.Add(nDetalle)

            Next

            Return lista

            'HeliosData.SaveChanges()
            'ts.Complete()
        End Using
    End Function

#Region "CUENTAS POR COBRAR"
    Public Function SumaCobroPorDocumento(intIdEstable As Integer, strTipoDoc As String,
                                       strFiltro As String) As documentoCajaDetalle

        Dim docCajaDetalle As New documentoCajaDetalle
        Dim consulta = (From venta In HeliosData.documentoventaAbarrotes _
                       Group Join cab In HeliosData.documentoCajaDetalle _
                        On cab.documentoAfectado Equals venta.idDocumento _
                        Into ords = Group _
                       From e In ords.DefaultIfEmpty _
                         Where
                                venta.idEstablecimiento = intIdEstable _
                               And venta.tipoVenta = TIPO_VENTA.VENTA_AL_CREDITO _
                               And venta.tipoDocumento = strTipoDoc _
                               And venta.numeroDocNormal.Contains(strFiltro) _
                               Group e By _
                               venta.fechaPeriodo, venta.estadoCobro, _
                               venta.idDocumento, venta.tipoDocumento, venta.fechaDoc, venta.serie, _
                               venta.numeroDocNormal, venta.tipoCambio, venta.tasaIgv, venta.idCliente, _
                               venta.moneda, venta.ImporteNacional, venta.ImporteExtranjero _
                               Into g = Group _
                               Select New With {
                                   .estadoCobro = estadoCobro,
                                   .fechaPeriodo = fechaPeriodo,
                                   .iddocumento = idDocumento,
                                   .tipoDocumento = tipoDocumento,
                                   .fechaDoc = fechaDoc,
                                   .serie = serie,
                                   .numeroDocNormal = numeroDocNormal,
                                   .tipoCambio = tipoCambio,
                                   .tasaIgv = tasaIgv,
                                   .idCliente = idCliente,
                                   .moneda = moneda,
                                   .ImporteNacional = ImporteNacional,
                                   .ImporteExtranjero = ImporteExtranjero, _
        g, .PagadoSoles = g.Sum(Function(cab) cab.montoSoles),
        .PagadoUsd = g.Sum(Function(cab) cab.montoUsd)
                                   }).FirstOrDefault

        If Not IsNothing(consulta) Then
            docCajaDetalle.EstadoCobro = consulta.estadoCobro
            docCajaDetalle.FechaPeriodo = consulta.fechaPeriodo
            docCajaDetalle.idDocumento = consulta.iddocumento
            docCajaDetalle.tipoDocumento = consulta.tipoDocumento
            docCajaDetalle.fechaDoc = consulta.fechaDoc
            docCajaDetalle.serie = consulta.serie
            docCajaDetalle.numeroDocNormal = consulta.numeroDocNormal
            docCajaDetalle.tipoCambioTransacc = consulta.tipoCambio
            docCajaDetalle.tasaIgv = consulta.tasaIgv
            docCajaDetalle.idCliente = consulta.idCliente
            docCajaDetalle.moneda = consulta.moneda
            docCajaDetalle.ImporteNacional = consulta.ImporteNacional
            docCajaDetalle.ImporteExtranjero = consulta.ImporteExtranjero
            If Not IsNothing(consulta.PagadoSoles) Then
                docCajaDetalle.montoSoles = consulta.PagadoSoles
            Else
                docCajaDetalle.montoSoles = 0
            End If

            If Not IsNothing(consulta.PagadoUsd) Then
                docCajaDetalle.montoUsd = consulta.PagadoUsd
            Else
                docCajaDetalle.montoUsd = 0
            End If
        Else
            docCajaDetalle.montoSoles = 0
            docCajaDetalle.montoUsd = 0
        End If
        Return docCajaDetalle

    End Function

    Public Function SumaCobroPorDocumentoPagos(intIdEstable As Integer, strTipoDoc As String,
                                       strFiltro As String, strSerie As String) As documentoCajaDetalle
        Dim listDocs() As String = {"07", "08", "87", "88"}
        Dim strNumDoc As String = String.Format("{0:00000000000000000000}", Convert.ToInt32(strFiltro))

        Dim docCajaDetalle As New documentoCajaDetalle
        Dim consulta = (From venta In HeliosData.documentocompra _
                       Group Join cab In HeliosData.documentoCajaDetalle _
                        On cab.documentoAfectado Equals venta.idDocumento _
                        Into ords = Group _
                       From e In ords.DefaultIfEmpty _
                         Where Not listDocs.Contains(venta.tipoDoc) And _
                                venta.idCentroCosto = intIdEstable _
                               And venta.tipoDoc = strTipoDoc _
                               And venta.numeroDoc = (strNumDoc) _
                               And venta.serie = strSerie _
                               Group e By _
                               venta.fechaContable, venta.estadoPago, _
                               venta.idDocumento, venta.tipoDoc, venta.fechaDoc, venta.serie, _
                               venta.numeroDoc, venta.tcDolLoc, venta.tasaIgv, venta.idProveedor, _
                               venta.monedaDoc, venta.importeTotal, venta.importeUS, venta.tipoCompra _
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
                                   .moneda = monedaDoc,
                                   .ImporteNacional = importeTotal,
                                   .ImporteExtranjero = importeUS, _
        g, .PagadoSoles = g.Sum(Function(cab) cab.montoSoles),
        .PagadoUsd = g.Sum(Function(cab) cab.montoUsd),
                                   .tipoCompra = tipoCompra
                                   }).FirstOrDefault

        If Not IsNothing(consulta) Then
            docCajaDetalle.EstadoCobro = consulta.estadoCobro
            docCajaDetalle.FechaPeriodo = consulta.fechaPeriodo
            docCajaDetalle.idDocumento = consulta.iddocumento
            docCajaDetalle.tipoDocumento = consulta.tipoDocumento
            docCajaDetalle.fechaDoc = consulta.fechaDoc
            docCajaDetalle.serie = consulta.serie
            docCajaDetalle.numeroDocNormal = consulta.numeroDocNormal
            docCajaDetalle.tipoCambioTransacc = consulta.tipoCambio
            docCajaDetalle.tasaIgv = consulta.tasaIgv
            docCajaDetalle.idCliente = consulta.idCliente
            docCajaDetalle.moneda = consulta.moneda
            docCajaDetalle.ImporteNacional = consulta.ImporteNacional
            docCajaDetalle.ImporteExtranjero = consulta.ImporteExtranjero
            docCajaDetalle.TipoCompra = consulta.tipoCompra
            If Not IsNothing(consulta.PagadoSoles) Then
                docCajaDetalle.montoSoles = consulta.PagadoSoles
            Else
                docCajaDetalle.montoSoles = 0
            End If

            If Not IsNothing(consulta.PagadoUsd) Then
                docCajaDetalle.montoUsd = consulta.PagadoUsd
            Else
                docCajaDetalle.montoUsd = 0
            End If
        Else
            docCajaDetalle.montoSoles = 0
            docCajaDetalle.montoUsd = 0
        End If
        Return docCajaDetalle

    End Function


    Public Function SumaCobroPorCliente(intIdEstable As Integer, strFiltro As String, strPeriodo As String) As List(Of documentoCajaDetalle)

        Dim docCajaDetalle As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)

        Dim consulta = (From venta In HeliosData.documentoventaAbarrotes _
                       Group Join cab In HeliosData.documentoCajaDetalle _
                        On cab.documentoAfectado Equals venta.idDocumento _
                        Into ords = Group _
                       From e In ords.DefaultIfEmpty _
                         Where
                                venta.idEstablecimiento = intIdEstable _
                               And venta.tipoVenta = TIPO_VENTA.VENTA_AL_CREDITO _
                               And venta.idCliente = (strFiltro) _
                               And venta.fechaPeriodo = strPeriodo _
                               Group e By _
                               venta.fechaPeriodo, venta.estadoCobro, _
                               venta.idDocumento, venta.tipoDocumento, venta.fechaDoc, venta.serie, _
                               venta.numeroDocNormal, venta.tipoCambio, venta.tasaIgv, venta.idCliente, _
                               venta.moneda, venta.ImporteNacional, venta.ImporteExtranjero _
                               Into g = Group _
                               Select New With {
                                   .estadoCobro = estadoCobro,
                                   .fechaPeriodo = fechaPeriodo,
                                   .iddocumento = idDocumento,
                                   .tipoDocumento = tipoDocumento,
                                   .fechaDoc = fechaDoc,
                                   .serie = serie,
                                   .numeroDocNormal = numeroDocNormal,
                                   .tipoCambio = tipoCambio,
                                   .tasaIgv = tasaIgv,
                                   .idCliente = idCliente,
                                   .moneda = moneda,
                                   .ImporteNacional = ImporteNacional,
                                   .ImporteExtranjero = ImporteExtranjero, _
        g, .PagadoSoles = g.Sum(Function(cab) cab.montoSoles),
        .PagadoUsd = g.Sum(Function(cab) cab.montoUsd)
                                   }).ToList


        If Not IsNothing(consulta) Then
            For Each i In consulta
                docCajaDetalle = New documentoCajaDetalle
                docCajaDetalle.EstadoCobro = i.estadoCobro
                docCajaDetalle.FechaPeriodo = i.fechaPeriodo
                docCajaDetalle.idDocumento = i.iddocumento
                docCajaDetalle.tipoDocumento = i.tipoDocumento
                docCajaDetalle.fechaDoc = i.fechaDoc
                docCajaDetalle.serie = i.serie
                docCajaDetalle.numeroDocNormal = i.numeroDocNormal
                docCajaDetalle.tipoCambioTransacc = i.tipoCambio
                docCajaDetalle.tasaIgv = i.tasaIgv
                docCajaDetalle.idCliente = i.idCliente
                docCajaDetalle.moneda = i.moneda
                docCajaDetalle.ImporteNacional = i.ImporteNacional
                docCajaDetalle.ImporteExtranjero = i.ImporteExtranjero
                If Not IsNothing(i.PagadoSoles) Then
                    docCajaDetalle.montoSoles = i.PagadoSoles
                Else
                    docCajaDetalle.montoSoles = 0
                End If

                If Not IsNothing(i.PagadoUsd) Then
                    docCajaDetalle.montoUsd = i.PagadoUsd
                Else
                    docCajaDetalle.montoUsd = 0
                End If
                ListaDetalle.Add(docCajaDetalle)
            Next

        Else
            docCajaDetalle.montoSoles = 0
            docCajaDetalle.montoUsd = 0
        End If


        Return ListaDetalle

    End Function

    Public Function SumaCobroPorModulo(intIdEstable As Integer, strFiltro As String, strPeriodo As String, strTipoModuloVenta As String) As List(Of documentoCajaDetalle)

        Dim docCajaDetalle As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)

        Dim consulta = (From venta In HeliosData.documentoventaAbarrotes _
                       Group Join cab In HeliosData.documentoCajaDetalle _
                        On cab.documentoAfectado Equals venta.idDocumento _
                        Into ords = Group _
                       From e In ords.DefaultIfEmpty _
                         Where
                                venta.idEstablecimiento = intIdEstable _
                               And venta.tipoVenta = strTipoModuloVenta _
                               And venta.idCliente = (strFiltro) _
                               And venta.fechaPeriodo = strPeriodo _
                               Group e By _
                               venta.fechaPeriodo, venta.estadoCobro, _
                               venta.idDocumento, venta.tipoDocumento, venta.fechaDoc, venta.serie, _
                               venta.numeroDocNormal, venta.tipoCambio, venta.tasaIgv, venta.idCliente, _
                               venta.moneda, venta.ImporteNacional, venta.ImporteExtranjero _
                               Into g = Group _
                               Select New With {
                                   .estadoCobro = estadoCobro,
                                   .fechaPeriodo = fechaPeriodo,
                                   .iddocumento = idDocumento,
                                   .tipoDocumento = tipoDocumento,
                                   .fechaDoc = fechaDoc,
                                   .serie = serie,
                                   .numeroDocNormal = numeroDocNormal,
                                   .tipoCambio = tipoCambio,
                                   .tasaIgv = tasaIgv,
                                   .idCliente = idCliente,
                                   .moneda = moneda,
                                   .ImporteNacional = ImporteNacional,
                                   .ImporteExtranjero = ImporteExtranjero, _
        g, .PagadoSoles = g.Sum(Function(cab) cab.montoSoles),
        .PagadoUsd = g.Sum(Function(cab) cab.montoUsd)
                                   }).ToList


        If Not IsNothing(consulta) Then
            For Each i In consulta
                docCajaDetalle = New documentoCajaDetalle
                docCajaDetalle.EstadoCobro = i.estadoCobro
                docCajaDetalle.FechaPeriodo = i.fechaPeriodo
                docCajaDetalle.idDocumento = i.iddocumento
                docCajaDetalle.tipoDocumento = i.tipoDocumento
                docCajaDetalle.fechaDoc = i.fechaDoc
                docCajaDetalle.serie = i.serie
                docCajaDetalle.numeroDocNormal = i.numeroDocNormal
                docCajaDetalle.tipoCambioTransacc = i.tipoCambio
                docCajaDetalle.tasaIgv = i.tasaIgv
                docCajaDetalle.idCliente = i.idCliente
                docCajaDetalle.moneda = i.moneda
                docCajaDetalle.ImporteNacional = i.ImporteNacional
                docCajaDetalle.ImporteExtranjero = i.ImporteExtranjero
                If Not IsNothing(i.PagadoSoles) Then
                    docCajaDetalle.montoSoles = i.PagadoSoles
                Else
                    docCajaDetalle.montoSoles = 0
                End If

                If Not IsNothing(i.PagadoUsd) Then
                    docCajaDetalle.montoUsd = i.PagadoUsd
                Else
                    docCajaDetalle.montoUsd = 0
                End If
                ListaDetalle.Add(docCajaDetalle)
            Next

        Else
            docCajaDetalle.montoSoles = 0
            docCajaDetalle.montoUsd = 0
        End If


        Return ListaDetalle

    End Function

    Public Function SumaPagosPorProveedor(intIdEstable As Integer, strFiltro As String, strPeriodo As String) As List(Of documentoCajaDetalle)
        Dim listDocs() As String = {"07", "87", "08", "88"}

      
        Dim docCajaDetalle As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)

        Dim consulta = (From venta In HeliosData.documentocompra _
                       Group Join cab In HeliosData.documentoCajaDetalle _
                        On cab.documentoAfectado Equals venta.idDocumento _
                        Into ords = Group _
                       From e In ords.DefaultIfEmpty _
                         Where Not listDocs.Contains(venta.tipoDoc) And _
                                venta.idCentroCosto = intIdEstable _
                               And venta.idProveedor = (strFiltro) _
                               And venta.fechaContable = strPeriodo _
                               Group e By _
                               venta.fechaContable, venta.estadoPago, _
                               venta.idDocumento, venta.tipoDoc, venta.fechaDoc, venta.serie, _
                               venta.numeroDoc, venta.tcDolLoc, venta.tasaIgv, venta.idProveedor, _
                               venta.monedaDoc, venta.importeTotal, venta.importeUS, venta.tipoCompra _
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
                                   .moneda = monedaDoc,
                                   .ImporteNacional = importeTotal,
                                   .ImporteExtranjero = importeUS, _
        g, .PagadoSoles = g.Sum(Function(cab) cab.montoSoles),
        .PagadoUsd = g.Sum(Function(cab) cab.montoUsd),
                                   .tipoCompra = tipoCompra
                                   }).ToList


        If Not IsNothing(consulta) Then
            For Each i In consulta
                docCajaDetalle = New documentoCajaDetalle
                docCajaDetalle.EstadoCobro = i.estadoCobro
                docCajaDetalle.FechaPeriodo = i.fechaPeriodo
                docCajaDetalle.idDocumento = i.iddocumento
                docCajaDetalle.tipoDocumento = i.tipoDocumento
                docCajaDetalle.fechaDoc = i.fechaDoc
                docCajaDetalle.serie = i.serie
                docCajaDetalle.numeroDocNormal = i.numeroDocNormal
                docCajaDetalle.tipoCambioTransacc = i.tipoCambio
                docCajaDetalle.tasaIgv = i.tasaIgv
                docCajaDetalle.idCliente = i.idCliente
                docCajaDetalle.moneda = i.moneda
                docCajaDetalle.ImporteNacional = i.ImporteNacional
                docCajaDetalle.ImporteExtranjero = i.ImporteExtranjero
                If Not IsNothing(i.PagadoSoles) Then
                    docCajaDetalle.montoSoles = i.PagadoSoles
                Else
                    docCajaDetalle.montoSoles = 0
                End If

                If Not IsNothing(i.PagadoUsd) Then
                    docCajaDetalle.montoUsd = i.PagadoUsd
                Else
                    docCajaDetalle.montoUsd = 0
                End If
                docCajaDetalle.TipoCompra = i.tipoCompra
                ListaDetalle.Add(docCajaDetalle)
            Next

        Else
            docCajaDetalle.montoSoles = 0
            docCajaDetalle.montoUsd = 0
        End If


        Return ListaDetalle

    End Function

    Public Function SumaPagosPorIdDocumentoCompra(intIdDocumento As Integer) As documentoCajaDetalle
        Dim docCajaDetalle As New documentoCajaDetalle

        Dim consulta = (From compra In HeliosData.documentocompra _
                         Group Join cab In HeliosData.documentoCajaDetalle _
                        On cab.documentoAfectado Equals compra.idDocumento _
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
                                   .ImporteNacional = importeTotal,
                                   .ImporteExtranjero = importeUS, _
        g, .PagadoSoles = g.Sum(Function(cab) cab.montoSoles),
        .PagadoUsd = g.Sum(Function(cab) cab.montoUsd)}).FirstOrDefault


        If Not IsNothing(consulta) Then
            With consulta
                docCajaDetalle = New documentoCajaDetalle
                docCajaDetalle.EstadoCobro = .estadoCobro
                docCajaDetalle.FechaPeriodo = .fechaPeriodo
                docCajaDetalle.idDocumento = .iddocumento
                docCajaDetalle.tipoDocumento = .tipoDocumento
                docCajaDetalle.fechaDoc = .fechaDoc
                docCajaDetalle.serie = .serie
                docCajaDetalle.numeroDocNormal = .numeroDocNormal
                docCajaDetalle.tipoCambioTransacc = .tipoCambio
                docCajaDetalle.tasaIgv = .tasaIgv
                docCajaDetalle.idCliente = .idCliente
                docCajaDetalle.moneda = .moneda
                docCajaDetalle.ImporteNacional = .ImporteNacional
                docCajaDetalle.ImporteExtranjero = .ImporteExtranjero
                If Not IsNothing(.PagadoSoles) Then
                    docCajaDetalle.montoSoles = .PagadoSoles
                Else
                    docCajaDetalle.montoSoles = 0
                End If

                If Not IsNothing(.PagadoUsd) Then
                    docCajaDetalle.montoUsd = .PagadoUsd
                Else
                    docCajaDetalle.montoUsd = 0
                End If

                docCajaDetalle.TipoCompra = .tipocompra
            End With
        Else
            docCajaDetalle.montoSoles = 0
            docCajaDetalle.montoUsd = 0
        End If


        Return docCajaDetalle

    End Function


    Public Function ObtenerHistorialPagos(intIdDocumentoCompra As Integer) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)
        Try
            Dim objLista = From n In HeliosData.documentoCajaDetalle _
                                  Join d In HeliosData.documentoCaja _
                                  On n.idDocumento Equals d.idDocumento _
                                  Join t In HeliosData.tabladetalle _
                                  On d.tipoDocPago Equals t.codigoDetalle _
                                 Group Join e In HeliosData.entidad _
                                  On d.codigoProveedor Equals e.idEntidad _
                                  Into ords = Group _
                                  From e In ords.DefaultIfEmpty _
                                  Where n.documentoAfectado = intIdDocumentoCompra _
                                  And t.idtabla = 1 _
                                  Order By n.fecha _
                                  Select New With {
                                      .Documentoafectado = n.documentoAfectado,
                                      .CodigoProveedor = d.codigoProveedor,
                                      .NombreProveedor = e.nombreCompleto,
                                      .FechaCobro = d.fechaCobro,
                                      .Moneda = d.moneda,
                                      .TipoDocPago = d.tipoDocPago,
                                      .TipoCambio = d.tipoCambio,
                                      .NombreTipoDoc = t.descripcion,
                                      .NumOperacion = d.numeroOperacion,
                                      .idDocumento = n.idDocumento,
                                      .MontoSoles = n.montoSoles,
                                      .MontoUSd = n.montoUsd
                                      }

            For Each obj In objLista
                objMostrarEncaja = New documentoCajaDetalle With _
                                   {
                                    .documentoAfectado = obj.Documentoafectado, _
                                    .idCliente = obj.CodigoProveedor, _
                                    .nomEntidad = obj.NombreProveedor, _
                                    .fechaDoc = IIf(IsDBNull(obj.FechaCobro), Nothing, obj.FechaCobro), _
                                    .moneda = obj.Moneda, _
                                    .tipoDocumento = obj.TipoDocPago, _
                                    .tipoCambioTransacc = obj.TipoCambio, _
                                    .nomDocumento = obj.NombreTipoDoc, _
                                    .numeroDocNormal = IIf(IsDBNull(obj.NumOperacion), Nothing, obj.NumOperacion), _
                                    .idDocumento = obj.idDocumento,
                                    .montoSoles = IIf(IsDBNull(obj.MontoSoles), 0, obj.MontoSoles), _
                                    .montoUsd = IIf(IsDBNull(obj.MontoUSd), 0, obj.MontoUSd)
                                     }
                ListaDetalle.Add(objMostrarEncaja)
            Next
            Return ListaDetalle
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ObtenerHistorialPagoPrestamoXCuota(intIdCuota As Integer) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)
        Try
            Dim objLista = From n In HeliosData.documentoCajaDetalle _
                                  Join d In HeliosData.documentoCaja _
                                  On n.idDocumento Equals d.idDocumento _
                                  Join t In HeliosData.tabladetalle _
                                  On d.tipoDocPago Equals t.codigoDetalle _
                                 Group Join e In HeliosData.estadosFinancieros _
                                  On d.entidadFinanciera Equals e.idestado _
                                  Into ords = Group _
                                  From e In ords.DefaultIfEmpty _
                                  Where n.idItem = intIdCuota _
                                  And t.idtabla = 1 _
                                  Order By n.fecha _
                                  Select New With {
                                      .detalleItem = n.DetalleItem,
                                      .Documentoafectado = n.documentoAfectado,
                                      .CodigoProveedor = d.entidadFinanciera,
                                      .NombreProveedor = e.descripcion,
                                      .FechaCobro = d.fechaCobro,
                                      .Moneda = d.moneda,
                                      .TipoDocPago = d.tipoDocPago,
                                      .TipoCambio = d.tipoCambio,
                                      .NombreTipoDoc = t.descripcion,
                                      .NumOperacion = d.numeroOperacion,
                                      .NumDoc = d.numeroDoc,
                                      .idDocumento = n.idDocumento,
                                      .MontoSoles = n.montoSoles,
                                      .MontoUSd = n.montoUsd,
                                  .entregado = n.entregado,
                                      .usuarioCaja = d.usuarioModificacion
                                      }

            For Each obj In objLista
                objMostrarEncaja = New documentoCajaDetalle With _
                                   {
                                       .DetalleItem = obj.detalleItem, _
                                    .documentoAfectado = obj.Documentoafectado, _
                                    .idCliente = obj.CodigoProveedor, _
                                    .nomEntidad = obj.NombreProveedor, _
                                    .fechaDoc = IIf(IsDBNull(obj.FechaCobro), Nothing, obj.FechaCobro), _
                                    .moneda = obj.Moneda, _
                                    .tipoDocumento = obj.TipoDocPago, _
                                    .tipoCambioTransacc = obj.TipoCambio, _
                                    .nomDocumento = obj.NombreTipoDoc, _
                                    .numeroDocNormal = IIf(IsDBNull(obj.NumOperacion), Nothing, obj.NumOperacion), _
                                    .numeroDoc = IIf(IsDBNull(obj.NumDoc), Nothing, obj.NumDoc), _
                                    .idDocumento = obj.idDocumento,
                                    .montoSoles = IIf(IsDBNull(obj.MontoSoles), 0, obj.MontoSoles), _
                                    .montoUsd = IIf(IsDBNull(obj.MontoUSd), 0, obj.MontoUSd), _
                                       .entregado = obj.entregado,
                                       .usuarioModificacion = obj.usuarioCaja
                                     }
                ListaDetalle.Add(objMostrarEncaja)
            Next
            Return ListaDetalle
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerHistorialPagosPorIdPago(intIdDocumentoPago As Integer) As documentoCajaDetalle
        Dim objMostrarEncaja As New documentoCajaDetalle
        Try
            Dim objLista = (From n In HeliosData.documentoCajaDetalle _
                                  Join d In HeliosData.documentoCaja _
                                  On n.idDocumento Equals d.idDocumento _
                                  Join t In HeliosData.tabladetalle _
                                  On d.tipoDocPago Equals t.codigoDetalle _
                                 Group Join e In HeliosData.entidad _
                                  On d.codigoProveedor Equals e.idEntidad _
                                  Into ords = Group _
                                  From e In ords.DefaultIfEmpty _
                                  Where n.idDocumento = intIdDocumentoPago _
                                  And t.idtabla = 1 _
                                  Order By n.fecha _
                                  Select New With {
                                      .Documentoafectado = n.documentoAfectado,
                                      .CodigoProveedor = d.codigoProveedor,
                                      .NombreProveedor = e.nombreCompleto,
                                      .FechaCobro = d.fechaCobro,
                                      .Moneda = d.moneda,
                                      .TipoDocPago = d.tipoDocPago,
                                      .TipoCambio = d.tipoCambio,
                                      .NombreTipoDoc = t.descripcion,
                                      .NumOperacion = d.numeroOperacion,
                                      .idDocumento = n.idDocumento,
                                      .MontoSoles = n.montoSoles,
                                      .MontoUSd = n.montoUsd
                                      }).FirstOrDefault

            objMostrarEncaja = New documentoCajaDetalle

            objMostrarEncaja.documentoAfectado = objLista.Documentoafectado
            objMostrarEncaja.idCliente = objLista.CodigoProveedor
            objMostrarEncaja.nomEntidad = objLista.NombreProveedor
            objMostrarEncaja.fechaDoc = IIf(IsDBNull(objLista.FechaCobro), Nothing, objLista.FechaCobro)
            objMostrarEncaja.moneda = objLista.Moneda
            objMostrarEncaja.tipoDocumento = objLista.TipoDocPago
            objMostrarEncaja.tipoCambioTransacc = objLista.TipoCambio
            objMostrarEncaja.nomDocumento = objLista.NombreTipoDoc
            objMostrarEncaja.numeroDocNormal = IIf(IsDBNull(objLista.NumOperacion), Nothing, objLista.NumOperacion)
            objMostrarEncaja.idDocumento = objLista.idDocumento
            objMostrarEncaja.montoSoles = IIf(IsDBNull(objLista.MontoSoles), 0, objLista.MontoSoles)
            objMostrarEncaja.montoUsd = IIf(IsDBNull(objLista.MontoUSd), 0, objLista.MontoUSd)

            Return objMostrarEncaja
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerPagosDelDia() As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)
        Try
            Dim objLista = From n In HeliosData.documentoCajaDetalle _
                                  Join d In HeliosData.documentoCaja _
                                  On n.idDocumento Equals d.idDocumento _
                                  Join t In HeliosData.tabladetalle _
                                  On d.tipoDocPago Equals t.codigoDetalle _
                                 Group Join e In HeliosData.entidad _
                                  On d.codigoProveedor Equals e.idEntidad _
                                  Into ords = Group _
                                  From e In ords.DefaultIfEmpty _
                                  Where t.idtabla = 1 _
                                  And d.fechaCobro.Value.Year = DateTime.Now.Year _
                                  And d.fechaCobro.Value.Month = DateTime.Now.Month _
                                  And d.fechaCobro.Value.Day = DateTime.Now.Day _
                                  Order By n.fecha _
                                  Select New With {
                                      .Documentoafectado = n.documentoAfectado,
                                      .CodigoProveedor = d.codigoProveedor,
                                      .NombreProveedor = e.nombreCompleto,
                                      .FechaCobro = d.fechaCobro,
                                      .Moneda = d.moneda,
                                      .TipoDocPago = d.tipoDocPago,
                                      .TipoCambio = d.tipoCambio,
                                      .NombreTipoDoc = t.descripcion,
                                      .NumOperacion = d.numeroOperacion,
                                      .idDocumento = n.idDocumento,
                                      .MontoSoles = n.montoSoles,
                                      .MontoUSd = n.montoUsd
                                      }

            For Each obj In objLista
                objMostrarEncaja = New documentoCajaDetalle With _
                                   {
                                    .documentoAfectado = obj.Documentoafectado, _
                                    .idCliente = obj.CodigoProveedor, _
                                    .nomEntidad = obj.NombreProveedor, _
                                    .fechaDoc = IIf(IsDBNull(obj.FechaCobro), Nothing, obj.FechaCobro), _
                                    .moneda = obj.Moneda, _
                                    .tipoDocumento = obj.TipoDocPago, _
                                    .tipoCambioTransacc = obj.TipoCambio, _
                                    .nomDocumento = obj.NombreTipoDoc, _
                                    .numeroDocNormal = IIf(IsDBNull(obj.NumOperacion), Nothing, obj.NumOperacion), _
                                    .idDocumento = obj.idDocumento,
                                    .montoSoles = IIf(IsDBNull(obj.MontoSoles), 0, obj.MontoSoles), _
                                    .montoUsd = IIf(IsDBNull(obj.MontoUSd), 0, obj.MontoUSd)
                                     }
                ListaDetalle.Add(objMostrarEncaja)
            Next
            Return ListaDetalle
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerPagosDelDiaPorEstablecimiento(intIdEstablecimiento As Integer) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)
        Try
            Dim objLista = From n In HeliosData.documentoCajaDetalle _
                                  Join d In HeliosData.documentoCaja _
                                  On n.idDocumento Equals d.idDocumento _
                                  Join t In HeliosData.tabladetalle _
                                  On d.tipoDocPago Equals t.codigoDetalle _
                                 Group Join e In HeliosData.entidad _
                                  On d.codigoProveedor Equals e.idEntidad _
                                  Into ords = Group _
                                  From e In ords.DefaultIfEmpty _
                                  Where t.idtabla = 1 _
                                  And d.idEstablecimiento = intIdEstablecimiento _
                                  And d.fechaCobro.Value.Year = DateTime.Now.Year _
                                  And d.fechaCobro.Value.Month = DateTime.Now.Month _
                                  And d.fechaCobro.Value.Day = DateTime.Now.Day _
                                  Order By n.fecha _
                                  Select New With {
                                      .Documentoafectado = n.documentoAfectado,
                                      .CodigoProveedor = d.codigoProveedor,
                                      .NombreProveedor = e.nombreCompleto,
                                      .FechaCobro = d.fechaCobro,
                                      .Moneda = d.moneda,
                                      .TipoDocPago = d.tipoDocPago,
                                      .TipoCambio = d.tipoCambio,
                                      .NombreTipoDoc = t.descripcion,
                                      .NumOperacion = d.numeroOperacion,
                                      .idDocumento = n.idDocumento,
                                      .MontoSoles = n.montoSoles,
                                      .MontoUSd = n.montoUsd
                                      }

            For Each obj In objLista
                objMostrarEncaja = New documentoCajaDetalle With _
                                   {
                                    .documentoAfectado = obj.Documentoafectado, _
                                    .idCliente = obj.CodigoProveedor, _
                                    .nomEntidad = obj.NombreProveedor, _
                                    .fechaDoc = IIf(IsDBNull(obj.FechaCobro), Nothing, obj.FechaCobro), _
                                    .moneda = obj.Moneda, _
                                    .tipoDocumento = obj.TipoDocPago, _
                                    .tipoCambioTransacc = obj.TipoCambio, _
                                    .nomDocumento = obj.NombreTipoDoc, _
                                    .numeroDocNormal = IIf(IsDBNull(obj.NumOperacion), Nothing, obj.NumOperacion), _
                                    .idDocumento = obj.idDocumento,
                                    .montoSoles = IIf(IsDBNull(obj.MontoSoles), 0, obj.MontoSoles), _
                                    .montoUsd = IIf(IsDBNull(obj.MontoUSd), 0, obj.MontoUSd)
                                     }
                ListaDetalle.Add(objMostrarEncaja)
            Next
            Return ListaDetalle
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerPagosPorPeriodo(strPeriodo As String) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)
        Try
            Dim objLista = From n In HeliosData.documentoCajaDetalle _
                                  Join d In HeliosData.documentoCaja _
                                  On n.idDocumento Equals d.idDocumento _
                                  Join t In HeliosData.tabladetalle _
                                  On d.tipoDocPago Equals t.codigoDetalle _
                                 Group Join e In HeliosData.entidad _
                                  On d.codigoProveedor Equals e.idEntidad _
                                  Into ords = Group _
                                  From e In ords.DefaultIfEmpty _
                                  Where d.periodo = strPeriodo And _
                                  d.tipoMovimiento = "PG" And _
                                  t.idtabla = 1 _
                                  Order By n.fecha _
                                  Select New With {
                                      .Documentoafectado = n.documentoAfectado,
                                      .CodigoProveedor = d.codigoProveedor,
                                      .NombreProveedor = e.nombreCompleto,
                                      .FechaCobro = d.fechaCobro,
                                      .Moneda = d.moneda,
                                      .TipoDocPago = d.tipoDocPago,
                                      .TipoCambio = d.tipoCambio,
                                      .NombreTipoDoc = t.descripcion,
                                      .NumOperacion = d.numeroOperacion,
                                      .idDocumento = n.idDocumento,
                                      .MontoSoles = n.montoSoles,
                                      .montoUsd = n.montoUsd
                                      }

            For Each obj In objLista
                objMostrarEncaja = New documentoCajaDetalle With _
                                   {
                                    .documentoAfectado = obj.Documentoafectado, _
                                    .idCliente = obj.CodigoProveedor, _
                                    .nomEntidad = obj.NombreProveedor, _
                                    .fechaDoc = IIf(IsDBNull(obj.FechaCobro), Nothing, obj.FechaCobro), _
                                    .moneda = obj.Moneda, _
                                    .tipoDocumento = obj.TipoDocPago, _
                                    .tipoCambioTransacc = obj.TipoCambio, _
                                    .nomDocumento = obj.NombreTipoDoc, _
                                    .numeroDocNormal = IIf(IsDBNull(obj.NumOperacion), Nothing, obj.NumOperacion), _
                                    .idDocumento = obj.idDocumento,
                                    .montoSoles = IIf(IsDBNull(obj.MontoSoles), 0, obj.MontoSoles), _
                                    .montoUsd = IIf(IsDBNull(obj.montoUsd), 0, obj.montoUsd) _
                                     }
                ListaDetalle.Add(objMostrarEncaja)
            Next
            Return ListaDetalle
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertPagosDeCaja(objDocumentoBE As documento, intDocCaja As Integer)
        ' Dim idDocumentoRecuperado As Integer

        Dim lista As New List(Of String)
        lista.Add("07")
        lista.Add("87")

        Dim lista2 As New List(Of String)
        lista2.Add("08")
        lista2.Add("88")

        Dim saldoItem As Decimal = 0
        Dim saldoItemME As Decimal = 0
        Dim nDetalle As New documentoCajaDetalle
        Dim objItemsaldo As New documentoCajaDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL

        Using ts As New TransactionScope
            For Each i In objDocumentoBE.documentoCaja.documentoCajaDetalle
                Dim NCventa = Aggregate det In HeliosData.documentoventaAbarrotesDet _
                            Join v In HeliosData.documentoventaAbarrotes On v.idDocumento Equals det.idDocumento _
                            Where lista.Contains(v.tipoDocumento) And det.idPadreDTVenta = i.documentoAfectadodetalle _
                            Into NCmn = Sum(det.importeMN), _
                                 NCme = Sum(det.importeME)

                Dim NBventa = Aggregate det In HeliosData.documentoventaAbarrotesDet _
                             Join v In HeliosData.documentoventaAbarrotes On v.idDocumento Equals det.idDocumento _
                             Where lista2.Contains(v.tipoDocumento) And det.idPadreDTVenta = i.documentoAfectadodetalle _
                             Into NBmn = Sum(det.importeMN), _
                                  NBme = Sum(det.importeME)


                objItemsaldo = cajaDetalleBL.ObtenerCuentasPorCobrarPorProducto(i.documentoAfectado, i.documentoAfectadodetalle)

                Dim VentaDetalle As documentoventaAbarrotesDet = HeliosData.documentoventaAbarrotesDet.Where(Function(o) o.secuencia = i.documentoAfectadodetalle).FirstOrDefault

                saldoItem = objItemsaldo.MontoDeudaSoles - i.montoSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault
                saldoItemME = objItemsaldo.MontoDeudaUSD - i.montoUsd - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault

                If saldoItem <= 0 Then
                    VentaDetalle.estadoPago = TIPO_VENTA.PAGO.COBRADO
                Else
                    VentaDetalle.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                End If


                'cajaDetalleBL.Insert(objDocumentoBE, objDocumentoBE.idDocumento, objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado)

                nDetalle = New documentoCajaDetalle
                nDetalle.idDocumento = intDocCaja
                nDetalle.documentoAfectado = objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado
                nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                nDetalle.secuencia = i.secuencia
                nDetalle.fecha = i.fecha
                nDetalle.idItem = i.idItem
                nDetalle.DetalleItem = i.DetalleItem
                nDetalle.montoSoles = i.montoSoles
                nDetalle.montoUsd = i.montoUsd


                nDetalle.entregado = i.entregado
                nDetalle.diferTipoCambio = i.tipoCambioTransacc


                nDetalle.usuarioModificacion = i.usuarioModificacion
                nDetalle.fechaModificacion = i.fechaModificacion

                HeliosData.documentoCajaDetalle.Add(nDetalle)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertPagosDeCajaCompra(objDocumentoBE As documento, intDocCaja As Integer)
        ' Dim idDocumentoRecuperado As Integer

        Dim lista As New List(Of String)
        lista.Add("07")
        lista.Add("87")

        Dim lista2 As New List(Of String)
        lista2.Add("08")
        lista2.Add("88")

        Dim saldoItem As Decimal = 0
        Dim saldoItemME As Decimal = 0
        Dim nDetalle As New documentoCajaDetalle
        Dim objItemsaldo As New documentoCajaDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL

        Using ts As New TransactionScope
            For Each i In objDocumentoBE.documentoCaja.documentoCajaDetalle
                Dim NCventa = Aggregate det In HeliosData.documentocompradetalle _
                            Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento _
                            Where lista.Contains(v.tipoDoc) And det.idPadreDTCompra = i.documentoAfectadodetalle _
                            Into NCmn = Sum(det.importe), _
                                 NCme = Sum(det.importeUS)

                Dim NBventa = Aggregate det In HeliosData.documentocompradetalle _
                             Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento _
                             Where lista2.Contains(v.tipoDoc) And det.idPadreDTCompra = i.documentoAfectadodetalle _
                             Into NBmn = Sum(det.importe), _
                                  NBme = Sum(det.importeUS)

                Dim Ajustes = Aggregate p In HeliosData.documentoLibroDiarioDetalle _
                 Join compra In HeliosData.documentoLibroDiario _
                 On p.idDocumento Equals compra.idDocumento _
                            Where p.cuenta = i.documentoAfectadodetalle _
                            And compra.tipoRegistro = "AJU"
            Into AJmn = Sum(p.importeMN), _
                 AJme = Sum(p.importeME)


                objItemsaldo = cajaDetalleBL.ObtenerCuentasPorPagarPorProducto(i.documentoAfectado, i.documentoAfectadodetalle)

                Dim VentaDetalle As documentocompradetalle = HeliosData.documentocompradetalle.Where(Function(o) o.secuencia = i.documentoAfectadodetalle).FirstOrDefault

                saldoItem = objItemsaldo.MontoDeudaSoles - i.montoSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault - Ajustes.AJmn.GetValueOrDefault
                saldoItemME = objItemsaldo.MontoDeudaUSD - i.montoUsd - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault - Ajustes.AJme.GetValueOrDefault

                If saldoItem <= 0 Then
                    VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                Else
                    VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                End If


                'cajaDetalleBL.Insert(objDocumentoBE, objDocumentoBE.idDocumento, objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado)

                nDetalle = New documentoCajaDetalle
                nDetalle.idDocumento = intDocCaja
                nDetalle.documentoAfectado = objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado
                nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                nDetalle.secuencia = i.secuencia
                nDetalle.fecha = i.fecha
                nDetalle.idItem = i.idItem
                nDetalle.DetalleItem = i.DetalleItem
                nDetalle.montoSoles = i.montoSoles
                nDetalle.montoUsd = i.montoUsd


                nDetalle.entregado = i.entregado
                nDetalle.diferTipoCambio = i.diferTipoCambio


                nDetalle.usuarioModificacion = i.usuarioModificacion
                nDetalle.fechaModificacion = i.fechaModificacion

                HeliosData.documentoCajaDetalle.Add(nDetalle)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub ActualizarItemsPagos(objDocumentoBE As documentoventaAbarrotesDet, intIdDocumentoVentaOrigen As Integer)
        ' Dim idDocumentoRecuperado As Integer
        Dim lista As New List(Of String)
        lista.Add("07")
        lista.Add("87")
        lista.Add("9901")

        Dim lista2 As New List(Of String)
        lista2.Add("08")
        lista2.Add("88")

        Dim saldoItem As Decimal = 0
        Dim saldoItemME As Decimal = 0
        Dim nDetalle As New documentoCajaDetalle
        Dim objItemsaldo As New documentoCajaDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL

        Using ts As New TransactionScope
            Dim NCventa = Aggregate det In HeliosData.documentoventaAbarrotesDet _
                            Join v In HeliosData.documentoventaAbarrotes On v.idDocumento Equals det.idDocumento _
                            Where lista.Contains(v.tipoDocumento) And det.idPadreDTVenta = objDocumentoBE.idPadreDTVenta _
                            Into NCmn = Sum(det.importeMN), _
                                 NCme = Sum(det.importeME)

            Dim NBventa = Aggregate det In HeliosData.documentoventaAbarrotesDet _
                         Join v In HeliosData.documentoventaAbarrotes On v.idDocumento Equals det.idDocumento _
                         Where lista2.Contains(v.tipoDocumento) And det.idPadreDTVenta = objDocumentoBE.idPadreDTVenta _
                         Into NBmn = Sum(det.importeMN), _
                              NBme = Sum(det.importeME)


            objItemsaldo = cajaDetalleBL.ObtenerCuentasPorCobrarPorProducto(intIdDocumentoVentaOrigen, objDocumentoBE.idPadreDTVenta)

            Dim VentaDetalle As documentoventaAbarrotesDet = HeliosData.documentoventaAbarrotesDet.Where(Function(o) o.idDocumento = intIdDocumentoVentaOrigen And o.secuencia = objDocumentoBE.idPadreDTVenta).FirstOrDefault

            saldoItem = objItemsaldo.MontoDeudaSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault
            saldoItemME = objItemsaldo.MontoDeudaUSD - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault

            If saldoItem <= 0 Then
                VentaDetalle.estadoPago = TIPO_VENTA.PAGO.COBRADO
            Else
                VentaDetalle.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            End If

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub ActualizarItemsPagosCompra(objDocumentoBE As documentocompradetalle, intIdDocumentoVentaOrigen As Integer)
        ' Dim idDocumentoRecuperado As Integer

        Dim lista As New List(Of String)
        lista.Add("07")
        lista.Add("87")
        lista.Add("9901")

        Dim lista2 As New List(Of String)
        lista2.Add("08")
        lista2.Add("88")

        Dim saldoItem As Decimal = 0
        Dim saldoItemME As Decimal = 0
        Dim nDetalle As New documentoCajaDetalle
        Dim objItemsaldo As New documentoCajaDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL

        Using ts As New TransactionScope
            Dim NCventa = Aggregate det In HeliosData.documentocompradetalle
                            Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento
                            Where lista.Contains(v.tipoDoc) And det.idPadreDTCompra = objDocumentoBE.idPadreDTCompra And v.tipoCompra <> "EXD"
                            Into NCmn = Sum(det.importe),
                                 NCme = Sum(det.importeUS)

            Dim NBventa = Aggregate det In HeliosData.documentocompradetalle
                         Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento
                         Where lista2.Contains(v.tipoDoc) And det.idPadreDTCompra = objDocumentoBE.idPadreDTCompra
                         Into NBmn = Sum(det.importe),
                              NBme = Sum(det.importeUS)

            Dim Ajustes = Aggregate p In HeliosData.documentoLibroDiarioDetalle
               Join compra In HeliosData.documentoLibroDiario
               On p.idDocumento Equals compra.idDocumento
                          Where p.cuenta = objDocumentoBE.idPadreDTCompra _
                          And compra.tipoRegistro = "AJU"
          Into AJmn = Sum(p.importeMN),
               AJme = Sum(p.importeME)

            objItemsaldo = cajaDetalleBL.ObtenerCuentasPorPagarPorProducto(intIdDocumentoVentaOrigen, objDocumentoBE.idPadreDTCompra)

            Dim VentaDetalle As documentocompradetalle = HeliosData.documentocompradetalle.Where(Function(o) o.idDocumento = intIdDocumentoVentaOrigen And o.secuencia = objDocumentoBE.idPadreDTCompra).FirstOrDefault

            saldoItem = objItemsaldo.MontoDeudaSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault - Ajustes.AJmn.GetValueOrDefault
            saldoItemME = objItemsaldo.MontoDeudaUSD - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault - Ajustes.AJme.GetValueOrDefault

            If saldoItem <= 0 Then
                VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PAGADO
            Else
                VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            End If

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub ActualizarItemsPagosAjustes(objDocumentoBE As documentoLibroDiarioDetalle, intIdDocumentoVentaOrigen As Integer)
        ' Dim idDocumentoRecuperado As Integer

        Dim lista As New List(Of String)
        lista.Add("07")
        lista.Add("87")

        Dim lista2 As New List(Of String)
        lista2.Add("08")
        lista2.Add("88")

        Dim saldoItem As Decimal = 0
        Dim saldoItemME As Decimal = 0
        Dim nDetalle As New documentoCajaDetalle
        Dim objItemsaldo As New documentoCajaDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL

        Using ts As New TransactionScope
            Dim NCventa = Aggregate det In HeliosData.documentocompradetalle _
                            Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento _
                            Where lista.Contains(v.tipoDoc) And det.idPadreDTCompra = objDocumentoBE.secuencia _
                            Into NCmn = Sum(det.importe), _
                                 NCme = Sum(det.importeUS)

            Dim NBventa = Aggregate det In HeliosData.documentocompradetalle _
                         Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento _
                         Where lista2.Contains(v.tipoDoc) And det.idPadreDTCompra = objDocumentoBE.secuencia _
                         Into NBmn = Sum(det.importe), _
                              NBme = Sum(det.importeUS)


            objItemsaldo = cajaDetalleBL.ObtenerCuentasPorPagarPorProducto(intIdDocumentoVentaOrigen, objDocumentoBE.secuencia)

            Dim VentaDetalle As documentocompradetalle = HeliosData.documentocompradetalle.Where(Function(o) o.idDocumento = intIdDocumentoVentaOrigen And o.secuencia = objDocumentoBE.secuencia).FirstOrDefault

            saldoItem = objItemsaldo.MontoDeudaSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault - objDocumentoBE.importeMN
            saldoItemME = objItemsaldo.MontoDeudaUSD - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault - objDocumentoBE.importeME

            If saldoItem <= 0 Then
                VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PAGADO
            Else
                VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            End If

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub ActualizarItemsPagosFull(intIdDocumentoVentaOrigen As Integer)
        ' Dim idDocumentoRecuperado As Integer
        Dim lista As New List(Of String)
        lista.Add("07")
        lista.Add("87")

        Dim lista2 As New List(Of String)
        lista2.Add("08")
        lista2.Add("88")


        Dim saldoItem As Decimal = 0
        Dim saldoItemME As Decimal = 0
        Dim nDetalle As New documentoCajaDetalle
        Dim objItemsaldo As New documentoCajaDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL

        Using ts As New TransactionScope

            Dim ListaVentaDetalle = (From n In HeliosData.documentoventaAbarrotesDet _
                                    Where n.idDocumento = intIdDocumentoVentaOrigen).ToList

            For Each i In ListaVentaDetalle

                Dim NCventa = Aggregate det In HeliosData.documentoventaAbarrotesDet _
                        Join v In HeliosData.documentoventaAbarrotes On v.idDocumento Equals det.idDocumento _
                        Where lista.Contains(v.tipoDocumento) And det.idPadreDTVenta = i.secuencia _
                        Into NCmn = Sum(det.importeMN), _
                             NCme = Sum(det.importeME)

                Dim NBventa = Aggregate det In HeliosData.documentoventaAbarrotesDet _
                             Join v In HeliosData.documentoventaAbarrotes On v.idDocumento Equals det.idDocumento _
                             Where lista2.Contains(v.tipoDocumento) And det.idPadreDTVenta = i.secuencia _
                             Into NBmn = Sum(det.importeMN), _
                                  NBme = Sum(det.importeME)


                objItemsaldo = cajaDetalleBL.ObtenerCuentasPorCobrarPorProducto(intIdDocumentoVentaOrigen, i.secuencia)

                Dim VentaDetalle As documentoventaAbarrotesDet = HeliosData.documentoventaAbarrotesDet.Where(Function(o) o.idDocumento = intIdDocumentoVentaOrigen And o.secuencia = i.secuencia).FirstOrDefault

                saldoItem = objItemsaldo.MontoDeudaSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault
                saldoItemME = objItemsaldo.MontoDeudaUSD - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault

                If saldoItem <= 0 Then
                    VentaDetalle.estadoPago = TIPO_VENTA.PAGO.COBRADO
                Else
                    VentaDetalle.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                End If
            Next

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub ActualizarItemsPagosFullCompras(intIdDocumentoVentaOrigen As Integer)
        ' Dim idDocumentoRecuperado As Integer
        Dim lista As New List(Of String)
        lista.Add("07")
        lista.Add("87")

        Dim lista2 As New List(Of String)
        lista2.Add("08")
        lista2.Add("88")

        Dim saldoItem As Decimal = 0
        Dim saldoItemME As Decimal = 0
        Dim nDetalle As New documentoCajaDetalle
        Dim objItemsaldo As New documentoCajaDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL

        Using ts As New TransactionScope

            Dim ListaCompraDetalle = (From n In HeliosData.documentocompradetalle _
                                    Where n.idDocumento = intIdDocumentoVentaOrigen).ToList

            For Each i In ListaCompraDetalle

                Dim NCventa = Aggregate det In HeliosData.documentocompradetalle _
                        Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento _
                        Where lista.Contains(v.tipoDoc) And det.idPadreDTCompra = i.secuencia _
                        Into NCmn = Sum(det.importe), _
                             NCme = Sum(det.importeUS)

                Dim NBventa = Aggregate det In HeliosData.documentocompradetalle _
                             Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento _
                             Where lista2.Contains(v.tipoDoc) And det.idPadreDTCompra = i.secuencia _
                             Into NBmn = Sum(det.importe), _
                                  NBme = Sum(det.importeUS)


                Dim Ajustes = Aggregate p In HeliosData.documentoLibroDiarioDetalle _
                              Join compra In HeliosData.documentoLibroDiario _
                              On p.idDocumento Equals compra.idDocumento _
                              Where p.cuenta = i.secuencia _
                              And compra.tipoRegistro = "AJU"
                              Into AJmn = Sum(p.importeMN), _
                                  AJme = Sum(p.importeME)


                objItemsaldo = cajaDetalleBL.ObtenerCuentasPorPagarPorProducto(intIdDocumentoVentaOrigen, i.secuencia)

                Dim VentaDetalle As documentocompradetalle = HeliosData.documentocompradetalle.Where(Function(o) o.idDocumento = intIdDocumentoVentaOrigen And o.secuencia = i.secuencia).FirstOrDefault

                saldoItem = objItemsaldo.MontoDeudaSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault - Ajustes.AJmn.GetValueOrDefault
                saldoItemME = objItemsaldo.MontoDeudaUSD - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault - Ajustes.AJme.GetValueOrDefault

                If saldoItem <= 0 Then
                    VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                Else
                    VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                End If
            Next

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Function ObtenerPagosPorPeriodoporEstablecimiento(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)
        Try
            Dim objLista = From n In HeliosData.documentoCajaDetalle _
                                  Join d In HeliosData.documentoCaja _
                                  On n.idDocumento Equals d.idDocumento _
                                  Join t In HeliosData.tabladetalle _
                                  On d.tipoDocPago Equals t.codigoDetalle _
                                 Group Join e In HeliosData.entidad _
                                  On d.codigoProveedor Equals e.idEntidad _
                                  Into ords = Group _
                                  From e In ords.DefaultIfEmpty _
                                  Where d.periodo = strPeriodo And _
                                  d.tipoMovimiento = "PG" And _
                                  d.idEstablecimiento = intIdEstablecimiento And _
                                  t.idtabla = 1 _
                                  Order By n.fecha _
                                  Select New With {
                                      .Documentoafectado = n.documentoAfectado,
                                      .CodigoProveedor = d.codigoProveedor,
                                      .NombreProveedor = e.nombreCompleto,
                                      .FechaCobro = d.fechaCobro,
                                      .Moneda = d.moneda,
                                      .TipoDocPago = d.tipoDocPago,
                                      .TipoCambio = d.tipoCambio,
                                      .NombreTipoDoc = t.descripcion,
                                      .NumOperacion = d.numeroOperacion,
                                      .idDocumento = n.idDocumento,
                                      .MontoSoles = n.montoSoles,
                                      .MontoUSd = n.montoUsd
                                      }

            For Each obj In objLista
                objMostrarEncaja = New documentoCajaDetalle With _
                                   {
                                    .documentoAfectado = obj.Documentoafectado, _
                                    .idCliente = obj.CodigoProveedor, _
                                    .nomEntidad = obj.NombreProveedor, _
                                    .fechaDoc = IIf(IsDBNull(obj.FechaCobro), Nothing, obj.FechaCobro), _
                                    .moneda = obj.Moneda, _
                                    .tipoDocumento = obj.TipoDocPago, _
                                    .tipoCambioTransacc = obj.TipoCambio, _
                                    .nomDocumento = obj.NombreTipoDoc, _
                                    .numeroDocNormal = IIf(IsDBNull(obj.NumOperacion), Nothing, obj.NumOperacion), _
                                    .idDocumento = obj.idDocumento,
                                    .montoSoles = IIf(IsDBNull(obj.MontoSoles), 0, obj.MontoSoles), _
                                    .montoUsd = IIf(IsDBNull(obj.MontoUSd), 0, obj.MontoUSd)
                                     }
                ListaDetalle.Add(objMostrarEncaja)
            Next
            Return ListaDetalle
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerCuentasPorCobrarPorDetails(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)
        Dim objMostrarEncaja As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)

        Dim consulta = (From p In HeliosData.documentoventaAbarrotesDet
                        Group Join c In HeliosData.documentoCajaDetalle
                      On p.idDocumento Equals c.documentoAfectado _
                      And p.secuencia Equals c.documentoAfectadodetalle
                      Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where p.idDocumento = strDocumentoAfectado
                        Group c By
                      p.secuencia, p.destino, p.tipoExistencia,
                      p.idItem, p.nombreItem, p.importeMN, p.importeME,
                     p.monto1, p.idAlmacenOrigen, p.estadoPago, p.montokardex, p.montokardexUS, p.montoIgv, p.montoIgvUS, p.unidad1, p.importeMNK, p.importeMEK, p.precioUnitario
                      Into g = Group
                        Select New With {.iditem = idItem,
                                       .Descripcion = nombreItem,
                                       .ImporteDeudaSoles = importeMN,
                                       .ImporteDeudaUSD = importeME,
                                        g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
                                        .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
                                       .secuencia = secuencia,
                                       .destino = destino,
                                       .tipoex = tipoExistencia,
                                       .cantidad = monto1,
                                       .almacenRef = idAlmacenOrigen,
                                       .estadoPago = estadoPago,
                                       .montoKardex = montokardex,
                                       .montoKardexUS = montokardexUS,
                                       .montoIgv = montoIgv,
                                       .montoIgvUS = montoIgvUS,
                                       .pmMN = importeMNK,
                                       .pmME = importeMEK,
                                        .preciounitario = precioUnitario,
                                        .unidad1 = unidad1
                                   }
                               ).ToList
        Dim ncMN As Decimal = 0
        Dim ncME As Decimal = 0
        Dim ndMN As Decimal = 0
        Dim ndME As Decimal = 0
        For Each obj In consulta

            objMostrarEncaja = New documentoCajaDetalle() With
                               {
                                   .secuencia = obj.secuencia,
                                .idItem = obj.iditem,
                                .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion),
                                .MontoDeudaSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles),
                                .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD),
                                .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles), 0, obj.TotalImportePagadoSoles),
                                .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares), 0, obj.TotalImportePagadoDolares),
                                .destino = obj.destino,
                                   .TipoExistencia = obj.tipoex,
                                   .CantidadCompra = obj.cantidad,
                                   .almacenRef = IIf(IsDBNull(obj.almacenRef), 0, obj.almacenRef),
                                   .EstadoCobro = obj.estadoPago,
                                   .montokardex = obj.montoKardex,
                                   .montokardexus = obj.montoKardexUS,
                                   .montoIgv = obj.montoIgv,
                                   .montoIgvUS = obj.montoIgvUS,
                                   .pmMN = obj.pmMN,
                                   .pmME = obj.pmME,
                                   .precioUnitario = obj.preciounitario,
                                   .unidad1 = obj.unidad1
                                }
            ListaDetalle.Add(objMostrarEncaja)
        Next
        Return ListaDetalle
    End Function

    'Public Function ObtenerCuentasPorCobrarPorDetails(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)
    '    Dim objMostrarEncaja As New documentoCajaDetalle
    '    Dim ListaDetalle As New List(Of documentoCajaDetalle)

    '    Dim consulta = (From p In HeliosData.documentoventaAbarrotesDet
    '                    Group Join c In HeliosData.documentoCajaDetalle
    '                  On p.idDocumento Equals c.documentoAfectado _
    '                  And p.secuencia Equals c.documentoAfectadodetalle
    '                  Into ords = Group
    '                    From c In ords.DefaultIfEmpty
    '                    Where p.idDocumento = strDocumentoAfectado
    '                    Group c By
    '                  p.secuencia, p.destino, p.tipoExistencia,
    '                  p.idItem, p.nombreItem, p.importeMN, p.importeME,
    '                 p.monto1, p.idAlmacenOrigen, p.estadoPago, p.montokardex, p.montokardexUS, p.montoIgv, p.montoIgvUS, p.unidad1, p.importeMNK, p.importeMEK, p.precioUnitario
    '                  Into g = Group
    '                    Select New With {.iditem = idItem,
    '                                   .Descripcion = nombreItem,
    '                                   .ImporteDeudaSoles = importeMN,
    '                                   .ImporteDeudaUSD = importeME,
    '                                    g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
    '                                    .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
    '                                   .secuencia = secuencia,
    '                                   .destino = destino,
    '                                   .tipoex = tipoExistencia,
    '                                   .cantidad = monto1,
    '                                   .almacenRef = idAlmacenOrigen,
    '                                   .estadoPago = estadoPago,
    '                                   .montoKardex = montokardex,
    '                                   .montoKardexUS = montokardexUS,
    '                                   .montoIgv = montoIgv,
    '                                   .montoIgvUS = montoIgvUS,
    '                                   .pmMN = importeMNK,
    '                                   .pmME = importeMEK,
    '                                    .preciounitario = precioUnitario,
    '                                    .unidad1 = unidad1
    '                               }
    '                           ).ToList
    '    Dim ncMN As Decimal = 0
    '    Dim ncME As Decimal = 0
    '    Dim ndMN As Decimal = 0
    '    Dim ndME As Decimal = 0
    '    For Each obj In consulta

    '        objMostrarEncaja = New documentoCajaDetalle() With
    '                           {
    '                               .secuencia = obj.secuencia,
    '                            .idItem = obj.iditem,
    '                            .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion),
    '                            .MontoDeudaSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles),
    '                            .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD),
    '                            .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles), 0, obj.TotalImportePagadoSoles),
    '                            .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares), 0, obj.TotalImportePagadoDolares),
    '                            .destino = obj.destino,
    '                               .TipoExistencia = obj.tipoex,
    '                               .CantidadCompra = obj.cantidad,
    '                               .almacenRef = IIf(IsDBNull(obj.almacenRef), 0, obj.almacenRef),
    '                               .EstadoCobro = obj.estadoPago,
    '                               .montokardex = obj.montoKardex,
    '                               .montokardexus = obj.montoKardexUS,
    '                               .montoIgv = obj.montoIgv,
    '                               .montoIgvUS = obj.montoIgvUS,
    '                               .pmMN = obj.pmMN,
    '                               .pmME = obj.pmME,
    '                               .precioUnitario = obj.preciounitario,
    '                               .unidad1 = obj.unidad1
    '                            }
    '        ListaDetalle.Add(objMostrarEncaja)
    '    Next
    '    Return ListaDetalle
    'End Function

    Public Function ObtenerCuentasPorCobrarPorProducto(strDocumentoAfectado As Integer, intSecventa As Integer) As documentoCajaDetalle
        Dim objItem As New documentoCajaDetalle
        Dim obj = (From p In HeliosData.documentoventaAbarrotesDet
                   Group Join c In HeliosData.documentoCajaDetalle
                      On p.idDocumento Equals c.documentoAfectado _
                      And p.secuencia Equals c.documentoAfectadodetalle
                      Into ords = Group
                   From c In ords.DefaultIfEmpty
                   Where p.idDocumento = strDocumentoAfectado And p.secuencia = intSecventa
                   Group c By
                      p.secuencia, p.destino, p.tipoExistencia,
                      p.idItem, p.nombreItem, p.importeMN, p.importeME,
                     p.monto1, p.idAlmacenOrigen, p.estadoPago, p.montokardex, p.montokardexUS, p.montoIgv, p.montoIgvUS
                      Into g = Group
                   Select New With {.iditem = idItem,
                                       .Descripcion = nombreItem,
                                       .ImporteDeudaSoles = importeMN,
                                       .ImporteDeudaUSD = importeME,
                                        g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
                                        .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
                                       .secuencia = secuencia,
                                       .destino = destino,
                                       .tipoex = tipoExistencia,
                                       .cantidad = monto1,
                                       .almacenRef = idAlmacenOrigen,
                                       .estadoPago = estadoPago,
                                       .montoKardex = montokardex,
                                       .montoKardexUS = montokardexUS,
                                       .montoIgv = montoIgv,
                                       .montoIgvUS = montoIgvUS
                                   }
                               ).FirstOrDefault
        Dim ncMN As Decimal = 0
        Dim ncME As Decimal = 0
        Dim ndMN As Decimal = 0
        Dim ndME As Decimal = 0


        objItem = New documentoCajaDetalle() With
                           {
                               .secuencia = obj.secuencia,
                            .idItem = obj.iditem,
                            .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion),
                            .MontoDeudaSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles),
                            .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD),
                            .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles), 0, obj.TotalImportePagadoSoles),
                            .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares), 0, obj.TotalImportePagadoDolares),
                            .destino = obj.destino,
                               .TipoExistencia = obj.tipoex,
                               .CantidadCompra = obj.cantidad,
                               .almacenRef = IIf(IsDBNull(obj.almacenRef), 0, obj.almacenRef),
                               .EstadoCobro = obj.estadoPago,
                               .montokardex = obj.montoKardex,
                               .montokardexus = obj.montoKardexUS,
                               .montoIgv = obj.montoIgv,
                               .montoIgvUS = obj.montoIgvUS
                            }

        Return objItem
    End Function

    Public Function ObtenerCuentasPorPagarPorProducto(strDocumentoAfectado As Integer, intSecCompra As Integer) As documentoCajaDetalle
        Dim objItem As New documentoCajaDetalle
        Dim obj = (From p In HeliosData.documentocompradetalle _
                       Group Join c In HeliosData.documentoCajaDetalle _
                      On p.idDocumento Equals c.documentoAfectado _
                      And p.secuencia Equals c.documentoAfectadodetalle _
                      Into ords = Group _
                      From c In ords.DefaultIfEmpty _
                      Where p.idDocumento = strDocumentoAfectado And p.secuencia = intSecCompra _
                      Group c By _
                      p.secuencia, p.destino, p.tipoExistencia,
                      p.idItem, p.descripcionItem, p.importe, p.importeUS,
                     p.monto1, p.almacenRef, p.estadoPago, p.montokardex, p.montokardexUS, p.montoIgv, p.montoIgvUS _
                      Into g = Group _
                      Select New With {.iditem = idItem,
                                       .Descripcion = descripcionItem,
                                       .ImporteDeudaSoles = importe,
                                       .ImporteDeudaUSD = importeUS,
                                        g, .TotalImportePagadoSoles = g.Sum(Function(c) c.montoSoles),
                                       .TotalImportePagadoSolesTransac = g.Sum(Function(c) c.montoSolesTransacc),
                                        .TotalImportePagadoDolares = g.Sum(Function(c) c.montoUsd),
                                       .secuencia = secuencia,
                                       .destino = destino,
                                       .tipoex = tipoExistencia,
                                       .cantidad = monto1,
                                       .almacenRef = almacenRef,
                                       .estadoPago = estadoPago,
                                       .montoKardex = montokardex,
                                       .montoKardexUS = montokardexUS,
                                       .montoIgv = montoIgv,
                                       .montoIgvUS = montoIgvUS
                                   }
                               ).FirstOrDefault
        Dim ncMN As Decimal = 0
        Dim ncME As Decimal = 0
        Dim ndMN As Decimal = 0
        Dim ndME As Decimal = 0


        objItem = New documentoCajaDetalle() With _
                           {
                               .secuencia = obj.secuencia, _
                            .idItem = obj.iditem, _
                            .DetalleItem = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion), _
                            .MontoDeudaSoles = IIf(IsDBNull(obj.ImporteDeudaSoles), 0, obj.ImporteDeudaSoles), _
                            .MontoDeudaUSD = IIf(IsDBNull(obj.ImporteDeudaUSD), 0, obj.ImporteDeudaUSD), _
                            .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles), 0, obj.TotalImportePagadoSoles), _
                            .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares), 0, obj.TotalImportePagadoDolares), _
                            .destino = obj.destino, _
                               .TipoExistencia = obj.tipoex,
                               .CantidadCompra = obj.cantidad,
                               .almacenRef = IIf(IsDBNull(obj.almacenRef), 0, obj.almacenRef), _
                               .EstadoCobro = obj.estadoPago,
                               .montokardex = obj.montoKardex,
                               .montokardexus = obj.montoKardexUS,
                               .montoIgv = obj.montoIgv,
                               .montoIgvUS = obj.montoIgvUS
                            }

        Return objItem
    End Function


    Public Sub InsertPagosDeCajaME(objDocumentoBE As documento, intDocCaja As Integer)
        Dim saldoME As Decimal = 0
        Dim saldoItem As Decimal = 0
        Dim saldoItemME As Decimal = 0
        Dim nDetalle As New documentoCajaDetalle
        Dim objItemsaldo As New documentoCajaDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim lista As New List(Of String)
        lista.Add("07")
        lista.Add("87")

        Dim lista2 As New List(Of String)
        lista2.Add("08")
        lista2.Add("88")

        Using ts As New TransactionScope
            For Each i In objDocumentoBE.documentoCaja.documentoCajaDetalle
                Dim NCventa = Aggregate det In HeliosData.documentoventaAbarrotesDet _
                            Join v In HeliosData.documentoventaAbarrotes On v.idDocumento Equals det.idDocumento _
                            Where lista.Contains(v.tipoDocumento) And det.idPadreDTVenta = i.documentoAfectadodetalle _
                            Into NCmn = Sum(det.importeMN), _
                                 NCme = Sum(det.importeME)

                Dim NBventa = Aggregate det In HeliosData.documentoventaAbarrotesDet _
                             Join v In HeliosData.documentoventaAbarrotes On v.idDocumento Equals det.idDocumento _
                             Where lista2.Contains(v.tipoDocumento) And det.idPadreDTVenta = i.documentoAfectadodetalle _
                             Into NBmn = Sum(det.importeMN), _
                                  NBme = Sum(det.importeME)


                objItemsaldo = cajaDetalleBL.ObtenerCuentasPorCobrarPorProducto(i.documentoAfectado, i.documentoAfectadodetalle)

                Dim VentaDetalle As documentoventaAbarrotesDet = HeliosData.documentoventaAbarrotesDet.Where(Function(o) o.secuencia = i.documentoAfectadodetalle).FirstOrDefault

                saldoItem = objItemsaldo.MontoDeudaSoles - i.montoSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault
                saldoItemME = objItemsaldo.MontoDeudaUSD - i.montoUsd - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault

                If saldoItem <= 0 Then
                    VentaDetalle.estadoPago = TIPO_VENTA.PAGO.COBRADO
                Else
                    VentaDetalle.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                End If

                If (objDocumentoBE.documentoCaja.tipoMovimiento = MovimientoCaja.EntradaDinero) Then

                    nDetalle = New documentoCajaDetalle
                    nDetalle.idDocumento = intDocCaja
                    nDetalle.documentoAfectado = i.documentoAfectado
                    nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle
                    nDetalle.secuencia = i.secuencia
                    nDetalle.fecha = i.fecha
                    nDetalle.idItem = i.idItem
                    nDetalle.DetalleItem = i.DetalleItem
                    nDetalle.montoSoles = i.montoSoles
                    nDetalle.montoSolesTransacc = i.montoSolesTransacc
                    nDetalle.montoUsd = i.montoUsd
                    nDetalle.montoUsdTransacc = i.montoUsdTransacc
                    nDetalle.entregado = i.entregado
                    nDetalle.diferTipoCambio = i.diferTipoCambio
                    nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                    nDetalle.idCajaUsuario = i.idCajaUsuario
                    nDetalle.usuarioModificacion = i.usuarioModificacion
                    nDetalle.fechaModificacion = i.fechaModificacion
                    HeliosData.documentoCajaDetalle.Add(nDetalle)
                ElseIf (objDocumentoBE.documentoCaja.tipoMovimiento = MovimientoCaja.SalidaDinero) Then

                    Dim consultaCaja = (From c In HeliosData.documentoCaja _
                                        Join d In HeliosData.documentoCajaDetalle _
                                        On c.idDocumento Equals d.idDocumento _
                                Where c.tipoMovimiento = "DC" _
                                And c.entidadFinanciera = objDocumentoBE.documentoCaja.entidadFinanciera).ToList

                    For Each item In consultaCaja
                        saldoME = i.montoUsd
                        If (saldoME > 0) Then
                            If (item.d.montoUsd >= i.montoUsd And i.montoUsd = 0) Then
                                nDetalle = New documentoCajaDetalle
                                nDetalle.idDocumento = intDocCaja
                                nDetalle.documentoAfectado = intDocCaja
                                nDetalle.secuencia = i.secuencia
                                nDetalle.fecha = i.fecha
                                nDetalle.idItem = i.idItem
                                nDetalle.DetalleItem = i.DetalleItem
                                nDetalle.montoSoles = i.montoSoles
                                nDetalle.montoUsd = i.montoUsd
                                nDetalle.entregado = i.entregado
                                nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                nDetalle.diferTipoCambio = item.d.diferTipoCambio
                                nDetalle.idCajaUsuario = i.idCajaUsuario
                                nDetalle.usuarioModificacion = i.usuarioModificacion
                                nDetalle.fechaModificacion = i.fechaModificacion
                                saldoME = item.d.montoUsd - i.montoUsd
                                i.montoUsd = saldoME
                                HeliosData.documentoCajaDetalle.Add(nDetalle)
                            ElseIf (item.d.montoUsd <= i.montoUsd And i.montoUsd = 0) Then
                                nDetalle = New documentoCajaDetalle
                                nDetalle.idDocumento = intDocCaja
                                nDetalle.documentoAfectado = intDocCaja
                                nDetalle.secuencia = i.secuencia
                                nDetalle.fecha = i.fecha
                                nDetalle.idItem = i.idItem
                                nDetalle.DetalleItem = i.DetalleItem
                                nDetalle.montoSoles = i.montoSoles
                                nDetalle.montoUsd = i.montoUsd
                                nDetalle.entregado = i.entregado
                                nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                nDetalle.diferTipoCambio = item.d.diferTipoCambio
                                nDetalle.idCajaUsuario = i.idCajaUsuario
                                nDetalle.usuarioModificacion = i.usuarioModificacion
                                nDetalle.fechaModificacion = i.fechaModificacion
                                saldoME = item.d.montoUsd - i.montoUsd
                                i.montoUsd = saldoME
                                HeliosData.documentoCajaDetalle.Add(nDetalle)
                            ElseIf (item.d.montoUsd < i.montoUsd And i.montoUsd > 0) Then
                                nDetalle = New documentoCajaDetalle
                                nDetalle.idDocumento = intDocCaja
                                nDetalle.documentoAfectado = intDocCaja
                                nDetalle.secuencia = i.secuencia
                                nDetalle.fecha = i.fecha
                                nDetalle.idItem = i.idItem
                                nDetalle.DetalleItem = i.DetalleItem
                                nDetalle.montoSoles = CDec(item.d.montoUsd * item.d.diferTipoCambio)
                                nDetalle.montoUsd = item.d.montoUsd
                                nDetalle.entregado = i.entregado
                                nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                nDetalle.diferTipoCambio = item.d.diferTipoCambio
                                nDetalle.idCajaUsuario = i.idCajaUsuario
                                nDetalle.usuarioModificacion = i.usuarioModificacion
                                nDetalle.fechaModificacion = i.fechaModificacion
                                saldoME = saldoME - nDetalle.montoUsd
                                i.montoUsd = saldoME
                                HeliosData.documentoCajaDetalle.Add(nDetalle)
                            ElseIf (item.d.montoUsd > i.montoUsd And i.montoUsd > 0) Then
                                nDetalle = New documentoCajaDetalle
                                nDetalle.idDocumento = intDocCaja
                                nDetalle.documentoAfectado = intDocCaja
                                nDetalle.secuencia = i.secuencia
                                nDetalle.fecha = i.fecha
                                nDetalle.idItem = i.idItem
                                nDetalle.DetalleItem = i.DetalleItem
                                nDetalle.montoSoles = CDec(i.montoUsd * item.d.diferTipoCambio)
                                nDetalle.montoUsd = i.montoUsd
                                nDetalle.entregado = i.entregado
                                nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                nDetalle.diferTipoCambio = item.d.diferTipoCambio
                                nDetalle.idCajaUsuario = i.idCajaUsuario
                                nDetalle.usuarioModificacion = i.usuarioModificacion
                                nDetalle.fechaModificacion = i.fechaModificacion
                                saldoME = saldoME - i.montoUsd
                                i.montoUsd = saldoME
                                HeliosData.documentoCajaDetalle.Add(nDetalle)
                            ElseIf (item.d.montoUsd > i.montoUsd And i.montoUsd < 0) Then
                                nDetalle = New documentoCajaDetalle
                                nDetalle.idDocumento = intDocCaja
                                nDetalle.documentoAfectado = intDocCaja
                                nDetalle.secuencia = i.secuencia
                                nDetalle.fecha = i.fecha
                                nDetalle.idItem = i.idItem
                                nDetalle.DetalleItem = i.DetalleItem
                                nDetalle.montoSoles = CDec((i.montoUsd * -1) * item.d.diferTipoCambio)
                                nDetalle.montoUsd = (i.montoUsd * -1)
                                nDetalle.entregado = i.entregado
                                nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                nDetalle.diferTipoCambio = item.d.diferTipoCambio
                                nDetalle.idCajaUsuario = i.idCajaUsuario
                                nDetalle.usuarioModificacion = i.usuarioModificacion
                                nDetalle.fechaModificacion = i.fechaModificacion
                                saldoME = item.d.montoUsd - i.montoUsd
                                i.montoUsd = saldoME
                                HeliosData.documentoCajaDetalle.Add(nDetalle)
                            ElseIf (item.d.montoUsd = i.montoUsd And i.montoUsd > 0) Then
                                nDetalle = New documentoCajaDetalle
                                nDetalle.idDocumento = intDocCaja
                                nDetalle.documentoAfectado = intDocCaja
                                nDetalle.secuencia = i.secuencia
                                nDetalle.fecha = i.fecha
                                nDetalle.idItem = i.idItem
                                nDetalle.DetalleItem = i.DetalleItem
                                nDetalle.montoSoles = CDec(i.montoUsd * item.d.diferTipoCambio)
                                nDetalle.montoUsd = i.montoUsd
                                nDetalle.entregado = i.entregado
                                nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                                nDetalle.diferTipoCambio = item.d.diferTipoCambio
                                nDetalle.idCajaUsuario = i.idCajaUsuario
                                nDetalle.usuarioModificacion = i.usuarioModificacion
                                nDetalle.fechaModificacion = i.fechaModificacion
                                saldoME = saldoME - i.montoUsd
                                i.montoUsd = saldoME
                                HeliosData.documentoCajaDetalle.Add(nDetalle)
                            End If
                        End If
                    Next
                End If

            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function ConsultaCajaXEmpresa(strEmpresa As String) As documentoCajaDetalle
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL

        Try
            Dim nDetalle As New documentoCajaDetalle
            Using ts As New TransactionScope

                Dim EfectivoCajaEntrada = (Aggregate c In HeliosData.documentoCaja _
                                    Join d In HeliosData.documentoCajaDetalle _
                                    On c.idDocumento Equals d.idDocumento _
                                    Join e In HeliosData.estadosFinancieros _
                                    On c.entidadFinanciera Equals e.idestado
                                   Where c.idEmpresa = strEmpresa And c.tipoMovimiento = "DC" _
                                   And e.tipo = "EF" _
                              Into sumMN = Sum(d.montoSoles), sumME = Sum(c.montoUsd))

                Dim EfectivoCajaSalida = (Aggregate c In HeliosData.documentoCaja _
                               Join d In HeliosData.documentoCajaDetalle _
                               On c.idDocumento Equals d.idDocumento _
                               Join e In HeliosData.estadosFinancieros _
                               On c.entidadFinanciera Equals e.idestado
                              Where c.idEmpresa = strEmpresa And c.tipoMovimiento = "PG" _
                              And e.tipo = "EF" _
                         Into sumMN = Sum(d.montoSoles), sumME = Sum(c.montoUsd))

                Dim BancoCajaSalida = (Aggregate c In HeliosData.documentoCaja _
                               Join d In HeliosData.documentoCajaDetalle _
                               On c.idDocumento Equals d.idDocumento _
                               Join e In HeliosData.estadosFinancieros _
                               On c.entidadFinanciera Equals e.idestado
                              Where c.idEmpresa = strEmpresa And c.tipoMovimiento = "PG" _
                              And e.tipo = "BC" _
                         Into sumMN = Sum(d.montoSoles), sumME = Sum(c.montoUsd))

                Dim BancoCajaEntrada = (Aggregate c In HeliosData.documentoCaja _
                             Join d In HeliosData.documentoCajaDetalle _
                             On c.idDocumento Equals d.idDocumento _
                             Join e In HeliosData.estadosFinancieros _
                             On c.entidadFinanciera Equals e.idestado
                            Where c.idEmpresa = strEmpresa And c.tipoMovimiento = "DC" _
                            And e.tipo = "BC" _
                       Into sumMN = Sum(d.montoSoles), sumME = Sum(c.montoUsd))

                Dim TarjetaCajaSalida = (Aggregate c In HeliosData.documentoCaja _
                              Join d In HeliosData.documentoCajaDetalle _
                              On c.idDocumento Equals d.idDocumento _
                              Join e In HeliosData.estadosFinancieros _
                              On c.entidadFinanciera Equals e.idestado
                             Where c.idEmpresa = strEmpresa And c.tipoMovimiento = "PG" _
                             And e.tipo = "TC" _
                        Into sumMN = Sum(d.montoSoles), sumME = Sum(c.montoUsd))

                Dim TarjetaCajaEntrada = (Aggregate c In HeliosData.documentoCaja _
                             Join d In HeliosData.documentoCajaDetalle _
                             On c.idDocumento Equals d.idDocumento _
                             Join e In HeliosData.estadosFinancieros _
                              On c.entidadFinanciera Equals e.idestado
                            Where c.idEmpresa = strEmpresa And c.tipoMovimiento = "DC" _
                            And e.tipo = "TC" _
                       Into sumMN = Sum(d.montoSoles), sumME = Sum(c.montoUsd))

                Dim EntradaAnticipos = (Aggregate c In HeliosData.documentoCaja _
                                   Join d In HeliosData.documentoCajaDetalle _
                                   On c.idDocumento Equals d.idDocumento _
                           Where c.tipoMovimiento = "DC" And c.idEmpresa = strEmpresa _
                           And c.movimientoCaja = "AR"
                             Into sumMN = Sum(d.montoSoles), sumME = Sum(d.montoUsd))

                Dim SalidaAnticipos = (Aggregate c In HeliosData.documentoCaja _
                                   Join d In HeliosData.documentoCajaDetalle _
                                   On c.idDocumento Equals d.idDocumento _
                           Where c.tipoMovimiento = "pg" And c.idEmpresa = strEmpresa _
                           And c.movimientoCaja = "AO"
                             Into sumMN = Sum(d.montoSoles), sumME = Sum(d.montoUsd))

                'Dim EntradaAnticipos = (Aggregate c In HeliosData.documentoCaja _
                '               Join d In HeliosData.documentoCajaDetalle _
                '               On c.idDocumento Equals d.idDocumento _
                '       Where c.tipoMovimiento = "DC" And c.idEmpresa = strEmpresa _
                '       And c.movimientoCaja = "AR"
                '         Into sumMN = Sum(d.montoSoles), sumME = Sum(d.montoUsd))

                'Dim SalidaAnticipos = (Aggregate c In HeliosData.documentoCaja _
                '                   Join d In HeliosData.documentoCajaDetalle _
                '                   On c.idDocumento Equals d.idDocumento _
                '           Where c.tipoMovimiento = "PG" And c.idEmpresa = strEmpresa _
                '           And c.movimientoCaja = "AO"
                '             Into sumMN = Sum(d.montoSoles), sumME = Sum(d.montoUsd))

                nDetalle = New documentoCajaDetalle

                'Efectivo
                nDetalle.montoSoles = EfectivoCajaEntrada.sumMN.GetValueOrDefault - EfectivoCajaSalida.sumMN.GetValueOrDefault
                'BAnco
                nDetalle.montoUsd = BancoCajaEntrada.sumMN.GetValueOrDefault - BancoCajaSalida.sumMN.GetValueOrDefault
                'Tarjeta
                nDetalle.ImporteNacional = TarjetaCajaEntrada.sumMN.GetValueOrDefault - TarjetaCajaSalida.sumME.GetValueOrDefault

                'anticipo Otorgado
                nDetalle.salidaCostoMN = EntradaAnticipos.sumMN.GetValueOrDefault

                'anticipo recibido
                nDetalle.salidaCostoME = SalidaAnticipos.sumME.GetValueOrDefault

                ''prestamo recibido
                'nDetalle.salidaCostoMN = EntradaAnticipos.sumMN.GetValueOrDefault

                ''prestamo  otrogado
                'nDetalle.salidaCostoME = SalidaAnticipos.sumME.GetValueOrDefault

                Return nDetalle
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Function DocCajaXItem(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCajaDetalle)
    '    Dim Lista As New List(Of documentoCajaDetalle)
    '    Dim docCuenta As New documentoCajaDetalle

    '    Dim consulta = (From a In HeliosData.documentoCajaDetalle
    '                    Join c In HeliosData.entidad On CType(CInt(a.documentoCaja.codigoProveedor), Int32?) Equals c.idEntidad
    '                    Where
    '                        listaPersona.Contains(a.idCajaUsuario) And
    '                        a.documentoCaja.movimientoCaja = cajaBE.movimientoCaja And
    '                       a.documentoCaja.idEmpresa = cajaBE.idEmpresa And
    '                        a.documentoCaja.idEstablecimiento = cajaBE.idEstablecimiento And
    '                        a.documentoCaja.entidadFinanciera = cajaBE.entidadFinanciera
    '                    Select
    '                     FechaProceso = CType(a.documentoCaja.fechaProceso, DateTime?),
    '                     a.documentoCaja.tipoDocPago,
    '                     a.documentoCaja.numeroDoc,
    '                     a.montoSoles,
    '                     a.montoUsd,
    '                     a.DetalleItem,
    '                     c.nombreCompleto,
    '                     numero = c.nrodoc).ToList


    '    For Each item In consulta
    '        docCuenta = New documentoCajaDetalle

    '        docCuenta.fechaDoc = item.FechaProceso
    '        docCuenta.tipoDocumento = item.tipoDocPago
    '        docCuenta.numeroDoc = item.numeroDoc
    '        docCuenta.montoSoles = item.montoSoles.GetValueOrDefault
    '        docCuenta.montoUsd = item.montoUsd.GetValueOrDefault
    '        docCuenta.DetalleItem = item.DetalleItem
    '        docCuenta.nomEntidad = item.nombreCompleto

    '        Lista.Add(docCuenta)
    '    Next
    '    Return Lista
    'End Function

    Public Function DocCajaXItem(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCajaDetalle)
        Dim Lista As New List(Of documentoCajaDetalle)
        Dim docCuenta As New documentoCajaDetalle

        Dim consulta = (From a In HeliosData.documentoCajaDetalle
                        Join b In HeliosData.documentoventaAbarrotes On CInt(a.documentoAfectado) Equals b.idDocumento
                        Where
                            a.documentoCaja.fechaProceso.Value.Year = cajaBE.fechaProceso.Value.Year And
                            a.documentoCaja.fechaProceso.Value.Month = cajaBE.fechaProceso.Value.Month And
                            a.documentoCaja.fechaProceso.Value.Day = cajaBE.fechaProceso.Value.Day And
                            listaPersona.Contains(a.idCajaUsuario) And
                            a.documentoCaja.movimientoCaja = cajaBE.movimientoCaja And
                            a.documentoCaja.idEmpresa = cajaBE.idEmpresa And
                            a.documentoCaja.idEstablecimiento = cajaBE.idEstablecimiento And
                            cajaBE.ListaIDCajas.Contains(a.documentoCaja.entidadFinanciera)
                        Select
                        FechaProceso = CType(a.documentoCaja.fechaProceso, DateTime?),
                        a.documentoCaja.tipoDocPago,
                        a.documentoCaja.numeroDoc,
                        a.montoSoles,
                        a.montoUsd,
                        a.DetalleItem,
                        b.nombrePedido,
                           b.numeroVenta,
                       a.documentoCaja.glosa).ToList

        For Each item In consulta
            docCuenta = New documentoCajaDetalle
            docCuenta.fechaDoc = item.FechaProceso
            docCuenta.tipoDocumento = item.tipoDocPago
            docCuenta.numeroDoc = item.numeroVenta
            docCuenta.montoSoles = item.montoSoles.GetValueOrDefault
            docCuenta.montoUsd = item.montoUsd.GetValueOrDefault
            docCuenta.DetalleItem = item.DetalleItem
            docCuenta.nomEntidad = item.nombrePedido
            docCuenta.glosario = item.glosa
            Lista.Add(docCuenta)
        Next
        Return Lista
    End Function

    'Public Function DocCajaXItemVentas(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCajaDetalle)
    '    Dim Lista As New List(Of documentoCajaDetalle)
    '    Dim docCuenta As New documentoCajaDetalle
    '    Dim listaVenta As New List(Of String)
    '    listaVenta.Add(TIPO_VENTA.VENTA_POS_DIRECTA)
    '    listaVenta.Add(TIPO_VENTA.VENTA_AL_TICKET)

    '    Dim consulta = (From a In HeliosData.documentoCajaDetalle
    '                    Join c In HeliosData.entidad On CType(CInt(a.documentoCaja.codigoProveedor), Int32?) Equals c.idEntidad
    '                    Where
    '                        listaPersona.Contains(a.idCajaUsuario) And
    '                       listaVenta.Contains(a.documentoCaja.movimientoCaja) And
    '                       a.documentoCaja.idEmpresa = cajaBE.idEmpresa And
    '                        a.documentoCaja.idEstablecimiento = cajaBE.idEstablecimiento And
    '                        a.documentoCaja.entidadFinanciera = cajaBE.entidadFinanciera
    '                    Select
    '                     FechaProceso = CType(a.documentoCaja.fechaProceso, DateTime?),
    '                     a.documentoCaja.tipoDocPago,
    '                     a.documentoCaja.numeroDoc,
    '                     a.montoSoles,
    '                     a.montoUsd,
    '                     a.DetalleItem,
    '                     c.nombreCompleto,
    '                     numero = c.nrodoc).ToList


    '    For Each item In consulta
    '        docCuenta = New documentoCajaDetalle

    '        docCuenta.fechaDoc = item.FechaProceso
    '        docCuenta.tipoDocumento = item.tipoDocPago
    '        docCuenta.numeroDoc = item.numeroDoc
    '        docCuenta.montoSoles = item.montoSoles.GetValueOrDefault
    '        docCuenta.montoUsd = item.montoUsd.GetValueOrDefault
    '        docCuenta.DetalleItem = item.DetalleItem
    '        docCuenta.nomEntidad = item.nombreCompleto

    '        Lista.Add(docCuenta)
    '    Next
    '    Return Lista
    'End Function

    Public Function DocCajaXItemVentas(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCajaDetalle)
        Dim Lista As New List(Of documentoCajaDetalle)
        Dim docCuenta As New documentoCajaDetalle
        Dim listaVenta As New List(Of String)
        listaVenta.Add(TIPO_VENTA.VENTA_POS_DIRECTA)
        listaVenta.Add(TIPO_VENTA.VENTA_AL_TICKET)

        Dim consulta = (From a In HeliosData.documentoCajaDetalle
                        Join b In HeliosData.documentoventaAbarrotes On CInt(a.documentoAfectado) Equals b.idDocumento
                        Where
                            a.documentoCaja.fechaProceso.Value.Year = cajaBE.fechaProceso.Value.Year And
                            a.documentoCaja.fechaProceso.Value.Month = cajaBE.fechaProceso.Value.Month And
                            a.documentoCaja.fechaProceso.Value.Day = cajaBE.fechaProceso.Value.Day And
                            listaPersona.Contains(a.idCajaUsuario) And
                           listaVenta.Contains(a.documentoCaja.movimientoCaja) And
                           a.documentoCaja.idEmpresa = cajaBE.idEmpresa And
                            a.documentoCaja.idEstablecimiento = cajaBE.idEstablecimiento And
                            cajaBE.ListaIDCajas.Contains(a.documentoCaja.entidadFinanciera)
                        Select
                          FechaProceso = CType(a.documentoCaja.fechaProceso, DateTime?),
                        a.documentoCaja.tipoDocPago,
                        a.documentoCaja.numeroDoc,
                        a.montoSoles,
                        a.montoUsd,
                        a.DetalleItem,
                        b.nombrePedido,
                           b.numeroVenta,
                       a.documentoCaja.glosa).ToList


        For Each item In consulta
            docCuenta = New documentoCajaDetalle

            docCuenta.fechaDoc = item.FechaProceso
            docCuenta.tipoDocumento = item.tipoDocPago
            docCuenta.numeroDoc = item.numeroDoc
            docCuenta.montoSoles = item.montoSoles.GetValueOrDefault
            docCuenta.montoUsd = item.montoUsd.GetValueOrDefault
            docCuenta.DetalleItem = item.DetalleItem
            docCuenta.nomEntidad = item.nombrePedido
            docCuenta.glosario = item.glosa

            Lista.Add(docCuenta)
        Next
        Return Lista
    End Function

    Public Function DocCajaXItemVentasElectronicas(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCajaDetalle)
        Dim Lista As New List(Of documentoCajaDetalle)
        Dim docCuenta As New documentoCajaDetalle
        Dim listaVenta As New List(Of String)
        listaVenta.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaVenta.Add(TIPO_VENTA.VENTA_AL_TICKET)

        Dim consulta = (From a In HeliosData.documentoCajaDetalle
                        Join b In HeliosData.documentoventaAbarrotes On CInt(a.documentoAfectado) Equals b.idDocumento
                        Where
                            a.documentoCaja.fechaProceso.Value.Year = cajaBE.fechaProceso.Value.Year And
                            a.documentoCaja.fechaProceso.Value.Month = cajaBE.fechaProceso.Value.Month And
                            a.documentoCaja.fechaProceso.Value.Day = cajaBE.fechaProceso.Value.Day And
                            listaPersona.Contains(a.idCajaUsuario) And
                           listaVenta.Contains(a.documentoCaja.movimientoCaja) And
                           a.documentoCaja.idEmpresa = cajaBE.idEmpresa And
                            a.documentoCaja.idEstablecimiento = cajaBE.idEstablecimiento And
                             cajaBE.ListaIDCajas.Contains(a.documentoCaja.entidadFinanciera)
                        Select
                          FechaProceso = CType(a.documentoCaja.fechaProceso, DateTime?),
                        a.documentoCaja.tipoDocPago,
                        a.documentoCaja.numeroDoc,
                        a.montoSoles,
                        a.montoUsd,
                        a.DetalleItem,
                        b.nombrePedido,
                           b.numeroVenta,
                       a.documentoCaja.glosa).ToList


        For Each item In consulta
            docCuenta = New documentoCajaDetalle

            docCuenta.fechaDoc = item.FechaProceso
            docCuenta.tipoDocumento = item.tipoDocPago
            docCuenta.numeroDoc = item.numeroDoc
            docCuenta.montoSoles = item.montoSoles.GetValueOrDefault
            docCuenta.montoUsd = item.montoUsd.GetValueOrDefault
            docCuenta.DetalleItem = item.DetalleItem
            docCuenta.nomEntidad = item.nombrePedido
            docCuenta.glosario = item.glosa

            Lista.Add(docCuenta)
        Next
        Return Lista
    End Function


#End Region


End Class
