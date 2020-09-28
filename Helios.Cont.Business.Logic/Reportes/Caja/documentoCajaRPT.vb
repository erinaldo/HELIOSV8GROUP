Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class documentoCajaRPT
    Inherits BaseBL

    Public Function GetListarMvimientosCajaPorPeriodoReporte(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim lista As New List(Of String)
        lista.Add("TEC")
        lista.Add("OEC")
        lista.Add("OSC")
        Dim consulta = From c In HeliosData.documentoCaja _
                        Join d In HeliosData.documento _
                        On c.idDocumento Equals d.idDocumento _
                    Group Join ent1 In HeliosData.estadosFinancieros _
                        On c.entidadFinanciera Equals ent1.idestado _
                        Into ords1 = Group _
                      From x In ords1.DefaultIfEmpty _
                       Group Join ent2 In HeliosData.estadosFinancieros _
                        On c.entidadFinancieraDestino Equals ent2.idestado _
                        Into ords2 = Group _
                      From x1 In ords2.DefaultIfEmpty _
                        Where c.idEmpresa = strIdEmpresa _
                        And c.idEstablecimiento = intIdEstablecimiento _
                        And c.periodo = strPeriodo And lista.Contains(c.tipoOperacion) _
                        Select New With {
                            .idDocumento = c.idDocumento,
                            .movimiento = c.tipoOperacion,
                            .cajaOrigen = x.descripcion,
                            .cajaDestino = x1.descripcion,
                            .moneda = c.moneda,
                            .tipoCambio = c.tipoCambio,
                            .FechaCobro = c.fechaCobro,
                            .TipoMovimiento = c.tipoMovimiento,
                            .TipoDoc = c.tipoDocPago,
                            .NumDoc = d.nroDoc,
                            .numOperacion = c.numeroOperacion,
                            .Glosa = c.glosa,
                            .MontoSoles = c.montoSoles,
                            .MontoDolares = c.montoUsd}

        For Each obj In consulta
            If (obj.TipoMovimiento = "DC" And obj.movimiento = "TEC") Then
            Else
                objMostrarEncaja = New documentoCaja() With _
                                         {
                                          .idDocumento = obj.idDocumento,
                                      .tipoOperacion = obj.movimiento,
                                      .NomCajaOrigen = obj.cajaOrigen,
                                      .NomCajaDestino = obj.cajaDestino,
                                      .moneda = obj.moneda,
                                      .tipoCambio = obj.tipoCambio,
                                      .fechaCobro = obj.FechaCobro,
                                      .tipoMovimiento = obj.TipoMovimiento,
                                      .tipoDocPago = obj.TipoDoc,
                                      .numeroDoc = obj.NumDoc,
                                      .numeroOperacion = obj.numOperacion,
                                      .glosa = obj.Glosa,
                                      .montoSoles = obj.MontoSoles,
                                      .montoUsd = obj.MontoDolares _
                                           }
                ListaCaja.Add(objMostrarEncaja)
            End If
        Next

        Return ListaCaja
    End Function

    Public Function GetListarMvimientosCajaPorDiaReporte(strIdEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim lista As New List(Of String)
        lista.Add("TEC")
        lista.Add("OEC")
        lista.Add("OSC")
        Dim consulta = From c In HeliosData.documentoCaja _
                        Join d In HeliosData.documento _
                        On c.idDocumento Equals d.idDocumento _
                    Group Join ent1 In HeliosData.estadosFinancieros _
                        On c.entidadFinanciera Equals ent1.idestado _
                        Into ords1 = Group _
                      From x In ords1.DefaultIfEmpty _
                       Group Join ent2 In HeliosData.estadosFinancieros _
                        On c.entidadFinancieraDestino Equals ent2.idestado _
                        Into ords2 = Group _
                      From x1 In ords2.DefaultIfEmpty _
                        Where c.idEmpresa = strIdEmpresa _
                        And c.idEstablecimiento = intIdEstablecimiento _
                        And c.fechaCobro.Value.Day = CDate(DateTime.Now).Day _
                        And c.fechaCobro.Value.Month = CDate(DateTime.Now).Month _
                        And c.fechaCobro.Value.Year = CDate(DateTime.Now).Year And lista.Contains(c.tipoOperacion) _
                        Select New With {
                            .idDocumento = c.idDocumento,
                            .movimiento = c.tipoOperacion,
                            .cajaOrigen = x.descripcion,
                            .cajaDestino = x1.descripcion,
                            .moneda = c.moneda,
                            .tipoCambio = c.tipoCambio,
                            .FechaCobro = c.fechaCobro,
                            .TipoMovimiento = c.tipoMovimiento,
                            .TipoDoc = c.tipoDocPago,
                            .NumDoc = d.nroDoc,
                            .numOperacion = c.numeroOperacion,
                            .Glosa = c.glosa,
                            .MontoSoles = c.montoSoles,
                            .MontoDolares = c.montoUsd}

        For Each obj In consulta
            If (obj.TipoMovimiento = "DC" And obj.movimiento = "TEC") Then
            Else
                objMostrarEncaja = New documentoCaja() With _
                               {
                                .idDocumento = obj.idDocumento,
                            .tipoOperacion = obj.movimiento,
                            .NomCajaOrigen = obj.cajaOrigen,
                            .NomCajaDestino = obj.cajaDestino,
                            .moneda = obj.moneda,
                            .tipoCambio = obj.tipoCambio,
                            .fechaCobro = obj.FechaCobro,
                            .tipoMovimiento = obj.TipoMovimiento,
                            .tipoDocPago = obj.TipoDoc,
                            .numeroDoc = obj.NumDoc,
                            .numeroOperacion = obj.numOperacion,
                            .glosa = obj.Glosa,
                            .montoSoles = obj.MontoSoles,
                            .montoUsd = obj.MontoDolares _
                                 }
                ListaCaja.Add(objMostrarEncaja)
            End If

            
        Next

        Return ListaCaja
    End Function

    Public Function ObtenerCajaOnlineRPT(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim DocumentoCompraBL As New documentocompraBL
        Dim DocumentoCompra As New documentocompra
        Dim DocumentoVenta As New documentoventaAbarrotes
        Dim DocumentoVentaBL As New documentoventaAbarrotesBL
        Dim entidadBL As New entidadBL
        Dim tablaDetalleBL As New tabladetalleBL
        Dim persona As New Persona
        Dim personaBL As New PersonaBL

        Dim SaldoSoles As Decimal = 0
        Dim SaldoUSD As Decimal = 0
        Dim CAJA_ENTRADA_COBRO As String = "CB"
        Dim CAJA_ENTRADA_PAGO As String = "CE"
        Dim CAJA_SALIDA_COBRO As String = "PG"
        Dim CAJA_SALIDA_PAGO As String = "CS"
        Dim CAJA_APORTE As String = "AP"
        Dim CAJA_VENTAS_ABARROTE As String = "DC"


        Dim strPeriodo As String = String.Concat(strMEs, "/", strAnio)
        Dim consulta = From c In HeliosData.documentoCaja _
                        Join cajadetalle In HeliosData.documentoCajaDetalle _
                        On cajadetalle.idDocumento Equals c.idDocumento _
                        Where c.idEmpresa = strIdEmpresa _
                        And c.idEstablecimiento = intIdEstablecimiento _
                        And c.periodo = strPeriodo _
                        And c.entidadFinanciera = strEntidadFinanciera _
                        Select New With {.FechaCobro = c.fechaCobro,
                                         .TipoMovimiento = c.tipoMovimiento,
                                         .TipoDoc = c.tipoDocPago,
                                         .NumDoc = c.numeroDoc, .Glosa = c.glosa,
                                         .MontoSoles = cajadetalle.montoSoles,
                                         .MontoDolares = cajadetalle.montoUsd,
                                         .NomDocPago = String.Empty,
                                         .DetalleItem = cajadetalle.DetalleItem,
                                         .codigoLibro = c.codigoLibro,
                                         .IdCompra = cajadetalle.documentoAfectado,
                                         .NomCaja = String.Empty,
                                         .IdPersona = c.codigoProveedor}



        For Each obj In consulta
            objMostrarEncaja = New documentoCaja

            objMostrarEncaja.fechaCobro = obj.FechaCobro
            objMostrarEncaja.tipoMovimiento = obj.TipoMovimiento
            objMostrarEncaja.TipoDocumentoPago = String.Concat(obj.TipoDoc, ":", obj.DetalleItem)
            objMostrarEncaja.NumeroDocumento = obj.NumDoc
            objMostrarEncaja.glosa = obj.Glosa

            Select Case obj.TipoMovimiento
                Case CAJA_ENTRADA_COBRO, CAJA_ENTRADA_PAGO, _
                     CAJA_APORTE, CAJA_VENTAS_ABARROTE
                    SaldoSoles += obj.MontoSoles
                    SaldoUSD += obj.MontoDolares
                    objMostrarEncaja.montoSoles = obj.MontoSoles
                    objMostrarEncaja.montoUsd = obj.MontoDolares
                    objMostrarEncaja.montoMNSalida = 0
                    objMostrarEncaja.montoMESalida = 0

                Case CAJA_SALIDA_PAGO, CAJA_SALIDA_COBRO

                    SaldoSoles -= obj.MontoSoles
                    SaldoUSD -= obj.MontoDolares

                    objMostrarEncaja.montoSoles = 0
                    objMostrarEncaja.montoUsd = 0
                    objMostrarEncaja.montoMNSalida = obj.MontoSoles
                    objMostrarEncaja.montoMESalida = obj.MontoDolares
            End Select
            objMostrarEncaja.saldoMN = SaldoSoles
            objMostrarEncaja.saldoME = SaldoUSD

            objMostrarEncaja.NombreCaja = obj.NomCaja
            Select Case obj.codigoLibro
                Case "9907"
                    objMostrarEncaja.NombreOperacion = "PAGO A PROVEEDOR"
                Case "02" ' COMPRAS
                    objMostrarEncaja.NombreOperacion = "COMPRA"
                Case "105" 'APERTURA DE CAJAS
                    objMostrarEncaja.NombreOperacion = "APERTURA DE CAJA"

                Case "01" 'VENTAS
                    objMostrarEncaja.NombreOperacion = "VENTA"
            End Select

            ListaCaja.Add(objMostrarEncaja)
        Next

        Return ListaCaja
    End Function

    Public Function ObtenerCajaOnlineDiaRPT(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim DocumentoCompraBL As New documentocompraBL
        Dim DocumentoCompra As New documentocompra
        Dim DocumentoVenta As New documentoventaAbarrotes
        Dim DocumentoVentaBL As New documentoventaAbarrotesBL
        Dim entidadBL As New entidadBL
        Dim tablaDetalleBL As New tabladetalleBL
        Dim persona As New Persona
        Dim personaBL As New PersonaBL

        Dim SaldoSoles As Decimal = 0
        Dim SaldoUSD As Decimal = 0
        Dim CAJA_ENTRADA_COBRO As String = "CB"
        Dim CAJA_ENTRADA_PAGO As String = "CE"
        Dim CAJA_SALIDA_COBRO As String = "PG"
        Dim CAJA_SALIDA_PAGO As String = "CS"
        Dim CAJA_APORTE As String = "AP"
        Dim CAJA_VENTAS_ABARROTE As String = "DC"

        Dim consulta = From c In HeliosData.documentoCaja _
                        Join cajadetalle In HeliosData.documentoCajaDetalle _
                        On cajadetalle.idDocumento Equals c.idDocumento _
                        Where c.idEmpresa = strIdEmpresa _
                        And c.idEstablecimiento = intIdEstablecimiento _
                         And c.fechaProceso.Value.Day = CDate(DateTime.Now).Day _
                                   And c.fechaProceso.Value.Month = CDate(DateTime.Now).Month _
                                   And c.fechaProceso.Value.Year = CDate(DateTime.Now).Year _
                        And c.entidadFinanciera = strEntidadFinanciera _
                        Select New With {.FechaCobro = c.fechaCobro,
                                         .TipoMovimiento = c.tipoMovimiento,
                                         .TipoDoc = c.tipoDocPago,
                                         .NumDoc = c.numeroDoc, .Glosa = c.glosa,
                                         .MontoSoles = cajadetalle.montoSoles,
                                         .MontoDolares = cajadetalle.montoUsd,
                                         .NomDocPago = String.Empty,
                                         .DetalleItem = cajadetalle.DetalleItem,
                                         .codigoLibro = c.codigoLibro,
                                         .IdCompra = cajadetalle.documentoAfectado,
                                         .NomCaja = String.Empty,
                                         .IdPersona = c.codigoProveedor}



        For Each obj In consulta
            objMostrarEncaja = New documentoCaja

            objMostrarEncaja.fechaCobro = obj.FechaCobro
            objMostrarEncaja.tipoMovimiento = obj.TipoMovimiento
            objMostrarEncaja.TipoDocumentoPago = String.Concat(obj.TipoDoc, ":", obj.DetalleItem)
            objMostrarEncaja.NumeroDocumento = obj.NumDoc
            objMostrarEncaja.glosa = obj.Glosa

            Select Case obj.TipoMovimiento
                Case CAJA_ENTRADA_COBRO, CAJA_ENTRADA_PAGO, _
                     CAJA_APORTE, CAJA_VENTAS_ABARROTE
                    SaldoSoles += obj.MontoSoles
                    SaldoUSD += obj.MontoDolares
                    objMostrarEncaja.montoSoles = obj.MontoSoles
                    objMostrarEncaja.montoUsd = obj.MontoDolares
                    objMostrarEncaja.montoMNSalida = 0
                    objMostrarEncaja.montoMESalida = 0

                Case CAJA_SALIDA_PAGO, CAJA_SALIDA_COBRO

                    SaldoSoles -= obj.MontoSoles
                    SaldoUSD -= obj.MontoDolares

                    objMostrarEncaja.montoSoles = 0
                    objMostrarEncaja.montoUsd = 0
                    objMostrarEncaja.montoMNSalida = obj.MontoSoles
                    objMostrarEncaja.montoMESalida = obj.MontoDolares
            End Select
            objMostrarEncaja.saldoMN = SaldoSoles
            objMostrarEncaja.saldoME = SaldoUSD

            objMostrarEncaja.NombreCaja = obj.NomCaja
            Select Case obj.codigoLibro
                Case "9907"
                    objMostrarEncaja.NombreOperacion = "PAGO A PROVEEDOR"
                Case "02" ' COMPRAS
                    objMostrarEncaja.NombreOperacion = "COMPRA"
                Case "105" 'APERTURA DE CAJAS
                    objMostrarEncaja.NombreOperacion = "APERTURA DE CAJA"

                Case "01" 'VENTAS
                    objMostrarEncaja.NombreOperacion = "VENTA"
            End Select

            ListaCaja.Add(objMostrarEncaja)
        Next

        Return ListaCaja
    End Function

    Public Function ObtenerCajaOnlineAcumuladoRPT(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim DocumentoCompraBL As New documentocompraBL
        Dim DocumentoCompra As New documentocompra
        Dim DocumentoVenta As New documentoventaAbarrotes
        Dim DocumentoVentaBL As New documentoventaAbarrotesBL
        Dim entidadBL As New entidadBL
        Dim tablaDetalleBL As New tabladetalleBL
        Dim persona As New Persona
        Dim personaBL As New PersonaBL

        Dim SaldoSoles As Decimal = 0
        Dim SaldoUSD As Decimal = 0
        Dim CAJA_ENTRADA_COBRO As String = "CB"
        Dim CAJA_ENTRADA_PAGO As String = "CE"
        Dim CAJA_SALIDA_COBRO As String = "PG"
        Dim CAJA_SALIDA_PAGO As String = "CS"
        Dim CAJA_APORTE As String = "AP"
        Dim CAJA_VENTAS_ABARROTE As String = "DC"

        Dim consulta = From c In HeliosData.documentoCaja _
                       Join cajadetalle In HeliosData.documentoCajaDetalle _
                        On cajadetalle.idDocumento Equals c.idDocumento _
                         Select New With {.FechaCobro = c.fechaCobro,
                                         .TipoMovimiento = c.tipoMovimiento,
                                         .TipoDoc = c.tipoDocPago,
                                         .NumDoc = c.numeroDoc, .Glosa = c.glosa,
                                         .MontoSoles = cajadetalle.montoSoles,
                                         .MontoDolares = cajadetalle.montoUsd,
                                         .NomDocPago = String.Empty,
                                         .DetalleItem = cajadetalle.DetalleItem,
                                         .codigoLibro = c.codigoLibro,
                                         .IdCompra = cajadetalle.documentoAfectado,
                                         .NomCaja = String.Empty,
                                         .IdPersona = c.codigoProveedor,
                                          .idEntidadFin = c.entidadFinanciera}



        For Each obj In consulta
            objMostrarEncaja = New documentoCaja

            objMostrarEncaja.fechaCobro = obj.FechaCobro
            objMostrarEncaja.tipoMovimiento = obj.TipoMovimiento
            objMostrarEncaja.TipoDocumentoPago = String.Concat(obj.TipoDoc, ":", obj.DetalleItem)
            objMostrarEncaja.NumeroDocumento = obj.NumDoc
            objMostrarEncaja.glosa = obj.Glosa

            Select Case obj.TipoMovimiento
                Case CAJA_ENTRADA_COBRO, CAJA_ENTRADA_PAGO, _
                     CAJA_APORTE, CAJA_VENTAS_ABARROTE
                    SaldoSoles += obj.MontoSoles
                    SaldoUSD += obj.MontoDolares
                    objMostrarEncaja.montoSoles = obj.MontoSoles
                    objMostrarEncaja.montoUsd = obj.MontoDolares
                    objMostrarEncaja.montoMNSalida = 0
                    objMostrarEncaja.montoMESalida = 0

                Case CAJA_SALIDA_PAGO, CAJA_SALIDA_COBRO

                    SaldoSoles -= obj.MontoSoles
                    SaldoUSD -= obj.MontoDolares

                    objMostrarEncaja.montoSoles = 0
                    objMostrarEncaja.montoUsd = 0
                    objMostrarEncaja.montoMNSalida = obj.MontoSoles
                    objMostrarEncaja.montoMESalida = obj.MontoDolares
            End Select
            objMostrarEncaja.saldoMN = SaldoSoles
            objMostrarEncaja.saldoME = SaldoUSD

            objMostrarEncaja.NombreCaja = obj.NomCaja
            Select Case obj.codigoLibro
                Case "9907"
                    objMostrarEncaja.NombreOperacion = "PAGO A PROVEEDOR"
                Case "02" ' COMPRAS
                    objMostrarEncaja.NombreOperacion = "COMPRA"
                Case "105" 'APERTURA DE CAJAS
                    objMostrarEncaja.NombreOperacion = "APERTURA DE CAJA"

                Case "01" 'VENTAS
                    objMostrarEncaja.NombreOperacion = "VENTA"
            End Select

            ListaCaja.Add(objMostrarEncaja)
        Next

        Return ListaCaja
    End Function

End Class
