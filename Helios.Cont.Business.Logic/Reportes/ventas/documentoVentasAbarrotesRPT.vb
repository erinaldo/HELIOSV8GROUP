Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class documentoVentasAbarrotesRPT
    Inherits BaseBL
    Public Function OntenerListadoVentasAbarrotesDia(strEmpresa As String, intIdEstablecimiento As Integer, day As Date) As List(Of documentoventaAbarrotes)

        Dim Lista As New List(Of documentoventaAbarrotes)
        Dim objRecurso As New documentoventaAbarrotes

        Dim TipoVenta As New List(Of String)
        TipoVenta.Add(TIPO_VENTA.VENTA_GENERAL)
        TipoVenta.Add(TIPO_VENTA.VENTA_AL_TICKET)
        TipoVenta.Add(TIPO_VENTA.VENTA_POS_DIRECTA)

        Dim consulta = (From doc In HeliosData.documento _
                       Join venta In HeliosData.documentoventaAbarrotes _
                       On doc.idDocumento Equals venta.idDocumento _
                       Where venta.idEmpresa = strEmpresa And venta.idEstablecimiento = intIdEstablecimiento _
                       And TipoVenta.Contains(venta.tipoVenta) _
                       And venta.fechaDoc.Value.Day = day.Day _
                       And venta.fechaDoc.Value.Month = day.Month _
                        And venta.fechaDoc.Value.Year = day.Year _
                       Order By venta.fechaDoc Ascending).ToList

        For Each obj In consulta
            objRecurso = New documentoventaAbarrotes

            objRecurso.idDocumento = obj.venta.idDocumento
            objRecurso.codigoLibro = obj.venta.codigoLibro
            objRecurso.idEmpresa = obj.venta.idEmpresa
            objRecurso.idEstablecimiento = obj.venta.idEstablecimiento
            objRecurso.tipoDocumento = obj.venta.tipoDocumento
            objRecurso.fechaDoc = obj.venta.fechaDoc
            objRecurso.horaVenta = obj.venta.horaVenta
            objRecurso.fechaConfirmacion = obj.venta.fechaConfirmacion
            objRecurso.fechaPeriodo = obj.venta.fechaPeriodo
            objRecurso.serie = obj.venta.serie
            objRecurso.numeroDoc = obj.venta.numeroDoc
            objRecurso.numeroDocNormal = obj.venta.numeroDocNormal
            objRecurso.idClientePedido = obj.venta.idClientePedido
            objRecurso.nombrePedido = obj.venta.nombrePedido
            objRecurso.idCliente = obj.venta.idCliente
            objRecurso.moneda = obj.venta.moneda
            objRecurso.tipoCambio = obj.venta.tipoCambio
            objRecurso.tasaIgv = obj.venta.tasaIgv
            objRecurso.bi01 = obj.venta.bi01
            objRecurso.bi02 = obj.venta.bi02
            objRecurso.isc01 = obj.venta.isc01
            objRecurso.isc02 = obj.venta.isc02
            objRecurso.igv01 = obj.venta.igv01
            objRecurso.igv02 = obj.venta.igv02
            objRecurso.otc01 = obj.venta.otc01
            objRecurso.otc02 = obj.venta.otc02
            objRecurso.bi01us = obj.venta.bi01us
            objRecurso.bi02us = obj.venta.bi02us
            objRecurso.isc01us = obj.venta.isc01us
            objRecurso.isc02us = obj.venta.isc02us
            objRecurso.igv01us = obj.venta.igv01us
            objRecurso.igv02us = obj.venta.igv02us
            objRecurso.otc01us = obj.venta.otc01us
            objRecurso.otc02us = obj.venta.otc02us
            objRecurso.ImporteNacional = obj.venta.ImporteNacional
            objRecurso.ImporteExtranjero = obj.venta.ImporteExtranjero
            objRecurso.importeCostoMN = obj.venta.importeCostoMN
            objRecurso.importeCostoME = obj.venta.importeCostoME
            objRecurso.estadoCobro = obj.venta.estadoCobro
            objRecurso.establecimientoCobro = obj.venta.establecimientoCobro
            objRecurso.entidadFinanciera = obj.venta.entidadFinanciera
            objRecurso.glosa = obj.venta.glosa
            objRecurso.notaCredito = obj.venta.notaCredito
            objRecurso.tipoVenta = obj.venta.tipoVenta
            objRecurso.modulo = obj.venta.modulo
            objRecurso.idPadre = obj.venta.idPadre
            objRecurso.usuarioActualizacion = obj.venta.usuarioActualizacion
            objRecurso.fechaActualizacion = obj.venta.fechaActualizacion
            Lista.Add(objRecurso)
        Next

        Return Lista

    End Function

    Public Function OntenerListadoVentasAbarrotesPorMes(strEmpresa As String, intIdEstablecimiento As Integer,
                                              mes As String, anio As Integer) As List(Of documentoventaAbarrotes)

        Dim Lista As New List(Of documentoventaAbarrotes)
        Dim TipoVenta As New List(Of String)
        TipoVenta.Add(TIPO_VENTA.VENTA_GENERAL)
        TipoVenta.Add(TIPO_VENTA.VENTA_AL_TICKET)
        TipoVenta.Add(TIPO_VENTA.VENTA_POS_DIRECTA)
        TipoVenta.Add(TIPO_COMPRA.NOTA_CREDITO)

        Dim objRecurso As New documentoventaAbarrotes
        Dim consulta = (From doc In HeliosData.documento
                        Join venta In HeliosData.documentoventaAbarrotes
                       On doc.idDocumento Equals venta.idDocumento
                        Where venta.idEmpresa = strEmpresa And venta.idEstablecimiento = intIdEstablecimiento _
                       And TipoVenta.Contains(venta.tipoVenta) _
                       And venta.fechaDoc.Value.Month = mes _
                       And venta.fechaDoc.Value.Year = anio
                        Order By venta.fechaDoc Ascending).ToList

        For Each obj In consulta
            objRecurso = New documentoventaAbarrotes

            objRecurso.idDocumento = obj.venta.idDocumento
            objRecurso.codigoLibro = obj.venta.codigoLibro
            objRecurso.idEmpresa = obj.venta.idEmpresa
            objRecurso.idEstablecimiento = obj.venta.idEstablecimiento
            objRecurso.tipoDocumento = obj.venta.tipoDocumento
            objRecurso.fechaDoc = obj.venta.fechaDoc
            objRecurso.horaVenta = obj.venta.horaVenta
            objRecurso.fechaConfirmacion = obj.venta.fechaConfirmacion
            objRecurso.fechaPeriodo = obj.venta.fechaPeriodo
            objRecurso.serie = obj.venta.serie
            objRecurso.serieVenta = obj.venta.serieVenta
            objRecurso.numeroDoc = obj.venta.numeroDoc
            objRecurso.numeroVenta = obj.venta.numeroVenta
            objRecurso.numeroDocNormal = obj.venta.numeroDocNormal
            objRecurso.idClientePedido = obj.venta.idClientePedido
            objRecurso.nombrePedido = obj.venta.nombrePedido
            objRecurso.idCliente = obj.venta.idCliente
            objRecurso.moneda = obj.venta.moneda
            objRecurso.tipoCambio = obj.venta.tipoCambio
            objRecurso.tasaIgv = obj.venta.tasaIgv

            Select Case obj.venta.tipoDocumento
                Case "07", "87"
                    objRecurso.bi01 = obj.venta.bi01.GetValueOrDefault * -1
                    objRecurso.bi02 = obj.venta.bi02.GetValueOrDefault * -1
                    objRecurso.isc01 = obj.venta.isc01.GetValueOrDefault * -1
                    objRecurso.isc02 = obj.venta.isc02.GetValueOrDefault * -1
                    objRecurso.igv01 = obj.venta.igv01.GetValueOrDefault * -1
                    objRecurso.igv02 = obj.venta.igv02.GetValueOrDefault * -1
                    objRecurso.otc01 = obj.venta.otc01.GetValueOrDefault * -1
                    objRecurso.otc02 = obj.venta.otc02.GetValueOrDefault * -1
                    objRecurso.bi01us = obj.venta.bi01us.GetValueOrDefault * -1
                    objRecurso.bi02us = obj.venta.bi02us.GetValueOrDefault * -1
                    objRecurso.isc01us = obj.venta.isc01us.GetValueOrDefault * -1
                    objRecurso.isc02us = obj.venta.isc02us.GetValueOrDefault * -1
                    objRecurso.igv01us = obj.venta.igv01us.GetValueOrDefault * -1
                    objRecurso.igv02us = obj.venta.igv02us.GetValueOrDefault * -1
                    objRecurso.otc01us = obj.venta.otc01us.GetValueOrDefault * -1
                    objRecurso.otc02us = obj.venta.otc02us.GetValueOrDefault * -1

                    objRecurso.ImporteNacional = obj.venta.ImporteNacional.GetValueOrDefault * -1
                    objRecurso.ImporteExtranjero = obj.venta.ImporteExtranjero.GetValueOrDefault * -1
                    objRecurso.importeCostoMN = obj.venta.importeCostoMN.GetValueOrDefault * -1
                    objRecurso.importeCostoME = obj.venta.importeCostoME.GetValueOrDefault * -1
                Case Else
                    objRecurso.bi01 = obj.venta.bi01
                    objRecurso.bi02 = obj.venta.bi02
                    objRecurso.isc01 = obj.venta.isc01
                    objRecurso.isc02 = obj.venta.isc02
                    objRecurso.igv01 = obj.venta.igv01
                    objRecurso.igv02 = obj.venta.igv02
                    objRecurso.otc01 = obj.venta.otc01
                    objRecurso.otc02 = obj.venta.otc02
                    objRecurso.bi01us = obj.venta.bi01us
                    objRecurso.bi02us = obj.venta.bi02us
                    objRecurso.isc01us = obj.venta.isc01us
                    objRecurso.isc02us = obj.venta.isc02us
                    objRecurso.igv01us = obj.venta.igv01us
                    objRecurso.igv02us = obj.venta.igv02us
                    objRecurso.otc01us = obj.venta.otc01us
                    objRecurso.otc02us = obj.venta.otc02us

                    objRecurso.ImporteNacional = obj.venta.ImporteNacional
                    objRecurso.ImporteExtranjero = obj.venta.ImporteExtranjero
                    objRecurso.importeCostoMN = obj.venta.importeCostoMN
                    objRecurso.importeCostoME = obj.venta.importeCostoME
            End Select
            objRecurso.estadoCobro = obj.venta.estadoCobro
            objRecurso.establecimientoCobro = obj.venta.establecimientoCobro
            objRecurso.entidadFinanciera = obj.venta.entidadFinanciera
            objRecurso.glosa = obj.venta.glosa
            objRecurso.notaCredito = obj.venta.notaCredito
            objRecurso.tipoVenta = obj.venta.tipoVenta
            objRecurso.modulo = obj.venta.modulo
            objRecurso.idPadre = obj.venta.idPadre
            objRecurso.usuarioActualizacion = obj.venta.usuarioActualizacion
            objRecurso.fechaActualizacion = obj.venta.fechaActualizacion
            Lista.Add(objRecurso)
        Next

        Return Lista

    End Function


    'martin reporte de ventas por empresa establecimiento y periodo

    Public Function OntenerListadoVentasAbarrotesPorDia(strEmpresa As String, intIdEstablecimiento As Integer, strTipoCompra As String) As List(Of documentoventaAbarrotes)
        Dim Lista As New List(Of documentoventaAbarrotes)
        Dim objRecurso As New documentoventaAbarrotes
        Dim consulta = (From doc In HeliosData.documento _
                       Join compra In HeliosData.documentoventaAbarrotes _
                       On doc.idDocumento Equals compra.idDocumento _
                       Group Join entidad In HeliosData.entidad _
                       On compra.idCliente Equals entidad.idEntidad _
                       Into ords = Group _
                       From e In ords.DefaultIfEmpty _
                       Where doc.idCentroCosto = intIdEstablecimiento And _
                       compra.fechaDoc.Value.Day = CDate(DateTime.Now).Day _
                       And compra.fechaDoc.Value.Month = CDate(DateTime.Now).Month _
                       And compra.fechaDoc.Value.Year = CDate(DateTime.Now).Year _
                       And compra.tipoVenta = strTipoCompra _
                       Order By compra.fechaDoc Ascending).ToList

        For Each obj In consulta
            objRecurso = New documentoventaAbarrotes

            objRecurso.idDocumento = obj.compra.idDocumento
            objRecurso.tipoOperacion = obj.doc.tipoOperacion
            objRecurso.fechaDoc = obj.compra.fechaDoc
            objRecurso.tipoDocumento = obj.compra.tipoDocumento
            objRecurso.serie = obj.compra.serie
            objRecurso.numeroDoc = obj.compra.numeroDoc
            objRecurso.numeroDocNormal = obj.compra.numeroDocNormal
            objRecurso.nombrePedido = obj.compra.nombrePedido
            If Not IsNothing(obj.e) Then
                objRecurso.tipoDocEntidad = obj.e.tipoDoc
                objRecurso.NroDocEntidad = obj.e.nrodoc
                objRecurso.NombreEntidad = obj.e.nombreCompleto
                objRecurso.TipoPersona = obj.e.tipoPersona
            Else
                objRecurso.tipoDocEntidad = String.Empty
                objRecurso.NroDocEntidad = String.Empty
                objRecurso.NombreEntidad = String.Empty
                objRecurso.TipoPersona = String.Empty
            End If

            objRecurso.ImporteNacional = obj.compra.ImporteNacional
            objRecurso.tipoCambio = obj.compra.tipoCambio
            objRecurso.ImporteExtranjero = obj.compra.ImporteExtranjero
            objRecurso.moneda = obj.compra.moneda
            objRecurso.estadoCobro = obj.compra.estadoCobro
            objRecurso.tipoVenta = obj.compra.tipoVenta
            Lista.Add(objRecurso)
        Next

        Return Lista
    End Function

    Public Function OntenerListadoVentasAbarrotesPorPeriodo(strEmpresa As String, intIdEstablecimiento As Integer,
                                               strPeriodo As String) As List(Of documentoventaAbarrotes)

        Dim Lista As New List(Of documentoventaAbarrotes)
        Dim objRecurso As New documentoventaAbarrotes
        Dim consulta = (From doc In HeliosData.documento _
                       Join venta In HeliosData.documentoventaAbarrotes _
                       On doc.idDocumento Equals venta.idDocumento _
                       Where venta.idEmpresa = strEmpresa And venta.idEstablecimiento = intIdEstablecimiento _
                       And venta.fechaPeriodo = strPeriodo _
                       Order By venta.fechaDoc Ascending).ToList

        For Each obj In consulta
            objRecurso = New documentoventaAbarrotes

            objRecurso.idDocumento = obj.venta.idDocumento
            objRecurso.codigoLibro = obj.venta.codigoLibro
            objRecurso.idEmpresa = obj.venta.idEmpresa
            objRecurso.idEstablecimiento = obj.venta.idEstablecimiento
            objRecurso.tipoDocumento = obj.venta.tipoDocumento
            objRecurso.fechaDoc = obj.venta.fechaDoc
            objRecurso.horaVenta = obj.venta.horaVenta
            objRecurso.fechaConfirmacion = obj.venta.fechaConfirmacion
            objRecurso.fechaPeriodo = obj.venta.fechaPeriodo
            objRecurso.serie = obj.venta.serie
            objRecurso.numeroDoc = obj.venta.numeroDoc
            objRecurso.numeroDocNormal = obj.venta.numeroDocNormal
            objRecurso.idClientePedido = obj.venta.idClientePedido
            objRecurso.nombrePedido = obj.venta.nombrePedido
            objRecurso.idCliente = obj.venta.idCliente
            objRecurso.moneda = obj.venta.moneda
            objRecurso.tipoCambio = obj.venta.tipoCambio
            objRecurso.tasaIgv = obj.venta.tasaIgv
            objRecurso.bi01 = obj.venta.bi01
            objRecurso.bi02 = obj.venta.bi02
            objRecurso.isc01 = obj.venta.isc01
            objRecurso.isc02 = obj.venta.isc02
            objRecurso.igv01 = obj.venta.igv01
            objRecurso.igv02 = obj.venta.igv02
            objRecurso.otc01 = obj.venta.otc01
            objRecurso.otc02 = obj.venta.otc02
            objRecurso.bi01us = obj.venta.bi01us
            objRecurso.bi02us = obj.venta.bi02us
            objRecurso.isc01us = obj.venta.isc01us
            objRecurso.isc02us = obj.venta.isc02us
            objRecurso.igv01us = obj.venta.igv01us
            objRecurso.igv02us = obj.venta.igv02us
            objRecurso.otc01us = obj.venta.otc01us
            objRecurso.otc02us = obj.venta.otc02us
            objRecurso.ImporteNacional = obj.venta.ImporteNacional
            objRecurso.ImporteExtranjero = obj.venta.ImporteExtranjero
            objRecurso.importeCostoMN = obj.venta.importeCostoMN
            objRecurso.importeCostoME = obj.venta.importeCostoME
            objRecurso.estadoCobro = obj.venta.estadoCobro
            objRecurso.establecimientoCobro = obj.venta.establecimientoCobro
            objRecurso.entidadFinanciera = obj.venta.entidadFinanciera
            objRecurso.glosa = obj.venta.glosa
            objRecurso.notaCredito = obj.venta.notaCredito
            objRecurso.tipoVenta = obj.venta.tipoVenta
            objRecurso.modulo = obj.venta.modulo
            objRecurso.idPadre = obj.venta.idPadre
            objRecurso.usuarioActualizacion = obj.venta.usuarioActualizacion
            objRecurso.fechaActualizacion = obj.venta.fechaActualizacion
            Lista.Add(objRecurso)
        Next

        Return Lista

    End Function

    'martin reporte ventas por empresa y periodo  



    Public Function OntenerListadoVentasAbarrotesEmpresa(strEmpresa As String,
                                               strPeriodo As String) As List(Of documentoventaAbarrotes)

        Dim Lista As New List(Of documentoventaAbarrotes)
        Dim objRecurso As New documentoventaAbarrotes
        Dim consulta = (From doc In HeliosData.documento _
                       Join venta In HeliosData.documentoventaAbarrotes _
                       On doc.idDocumento Equals venta.idDocumento _
                       Join centro In HeliosData.centrocosto _
                       On venta.idEstablecimiento Equals centro.idCentroCosto _
                       Where venta.idEmpresa = strEmpresa _
                       And venta.fechaPeriodo = strPeriodo _
                       Order By venta.fechaDoc Ascending).ToList

        For Each obj In consulta
            objRecurso = New documentoventaAbarrotes
            objRecurso.nombreEstablecimiento = obj.centro.nombre             'martin 
            objRecurso.idDocumento = obj.venta.idDocumento
            objRecurso.codigoLibro = obj.venta.codigoLibro
            objRecurso.idEmpresa = obj.venta.idEmpresa
            objRecurso.idEstablecimiento = obj.venta.idEstablecimiento
            objRecurso.tipoDocumento = obj.venta.tipoDocumento
            objRecurso.fechaDoc = obj.venta.fechaDoc
            objRecurso.horaVenta = obj.venta.horaVenta
            objRecurso.fechaConfirmacion = obj.venta.fechaConfirmacion
            objRecurso.fechaPeriodo = obj.venta.fechaPeriodo
            objRecurso.serie = obj.venta.serie
            objRecurso.numeroDoc = obj.venta.numeroDoc
            objRecurso.numeroDocNormal = obj.venta.numeroDocNormal
            objRecurso.idClientePedido = obj.venta.idClientePedido
            objRecurso.nombrePedido = obj.venta.nombrePedido
            objRecurso.idCliente = obj.venta.idCliente
            objRecurso.moneda = obj.venta.moneda
            objRecurso.tipoCambio = obj.venta.tipoCambio
            objRecurso.tasaIgv = obj.venta.tasaIgv
            objRecurso.bi01 = obj.venta.bi01
            objRecurso.bi02 = obj.venta.bi02
            objRecurso.isc01 = obj.venta.isc01
            objRecurso.isc02 = obj.venta.isc02
            objRecurso.igv01 = obj.venta.igv01
            objRecurso.igv02 = obj.venta.igv02
            objRecurso.otc01 = obj.venta.otc01
            objRecurso.otc02 = obj.venta.otc02
            objRecurso.bi01us = obj.venta.bi01us
            objRecurso.bi02us = obj.venta.bi02us
            objRecurso.isc01us = obj.venta.isc01us
            objRecurso.isc02us = obj.venta.isc02us
            objRecurso.igv01us = obj.venta.igv01us
            objRecurso.igv02us = obj.venta.igv02us
            objRecurso.otc01us = obj.venta.otc01us
            objRecurso.otc02us = obj.venta.otc02us
            objRecurso.ImporteNacional = obj.venta.ImporteNacional
            objRecurso.ImporteExtranjero = obj.venta.ImporteExtranjero
            objRecurso.importeCostoMN = obj.venta.importeCostoMN
            objRecurso.importeCostoME = obj.venta.importeCostoME
            objRecurso.estadoCobro = obj.venta.estadoCobro
            objRecurso.establecimientoCobro = obj.venta.establecimientoCobro
            objRecurso.entidadFinanciera = obj.venta.entidadFinanciera
            objRecurso.glosa = obj.venta.glosa
            objRecurso.notaCredito = obj.venta.notaCredito
            objRecurso.tipoVenta = obj.venta.tipoVenta
            objRecurso.modulo = obj.venta.modulo
            objRecurso.idPadre = obj.venta.idPadre
            objRecurso.usuarioActualizacion = obj.venta.usuarioActualizacion
            objRecurso.fechaActualizacion = obj.venta.fechaActualizacion
            Lista.Add(objRecurso)
        Next

        Return Lista

    End Function


    'martin ventas abarrotes por cliente


    Public Function OntenerListadoVentasAbarrotesPorCliente(strEmpresa As String, intIdEstablecimiento As Integer,
                                               strPeriodo As String, intIdCliente As Integer) As List(Of documentoventaAbarrotes)

        Dim Lista As New List(Of documentoventaAbarrotes)
        Dim objRecurso As New documentoventaAbarrotes
        Dim consulta = (From doc In HeliosData.documento _
                       Join venta In HeliosData.documentoventaAbarrotes _
                       On doc.idDocumento Equals venta.idDocumento _
                       Where venta.idEmpresa = strEmpresa And venta.idEstablecimiento = intIdEstablecimiento _
                       And venta.fechaPeriodo = strPeriodo _
                       And venta.idCliente = intIdCliente _
                       Order By venta.fechaDoc Ascending).ToList

        For Each obj In consulta
            objRecurso = New documentoventaAbarrotes

            objRecurso.idDocumento = obj.venta.idDocumento
            objRecurso.codigoLibro = obj.venta.codigoLibro
            objRecurso.idEmpresa = obj.venta.idEmpresa
            objRecurso.idEstablecimiento = obj.venta.idEstablecimiento
            objRecurso.tipoDocumento = obj.venta.tipoDocumento
            objRecurso.fechaDoc = obj.venta.fechaDoc
            objRecurso.horaVenta = obj.venta.horaVenta
            objRecurso.fechaConfirmacion = obj.venta.fechaConfirmacion
            objRecurso.fechaPeriodo = obj.venta.fechaPeriodo
            objRecurso.serie = obj.venta.serie
            objRecurso.numeroDoc = obj.venta.numeroDoc
            objRecurso.numeroDocNormal = obj.venta.numeroDocNormal
            objRecurso.idClientePedido = obj.venta.idClientePedido
            objRecurso.nombrePedido = obj.venta.nombrePedido
            objRecurso.idCliente = obj.venta.idCliente
            objRecurso.moneda = obj.venta.moneda
            objRecurso.tipoCambio = obj.venta.tipoCambio
            objRecurso.tasaIgv = obj.venta.tasaIgv
            objRecurso.bi01 = obj.venta.bi01
            objRecurso.bi02 = obj.venta.bi02
            objRecurso.isc01 = obj.venta.isc01
            objRecurso.isc02 = obj.venta.isc02
            objRecurso.igv01 = obj.venta.igv01
            objRecurso.igv02 = obj.venta.igv02
            objRecurso.otc01 = obj.venta.otc01
            objRecurso.otc02 = obj.venta.otc02
            objRecurso.bi01us = obj.venta.bi01us
            objRecurso.bi02us = obj.venta.bi02us
            objRecurso.isc01us = obj.venta.isc01us
            objRecurso.isc02us = obj.venta.isc02us
            objRecurso.igv01us = obj.venta.igv01us
            objRecurso.igv02us = obj.venta.igv02us
            objRecurso.otc01us = obj.venta.otc01us
            objRecurso.otc02us = obj.venta.otc02us
            objRecurso.ImporteNacional = obj.venta.ImporteNacional
            objRecurso.ImporteExtranjero = obj.venta.ImporteExtranjero
            objRecurso.importeCostoMN = obj.venta.importeCostoMN
            objRecurso.importeCostoME = obj.venta.importeCostoME
            objRecurso.estadoCobro = obj.venta.estadoCobro
            objRecurso.establecimientoCobro = obj.venta.establecimientoCobro
            objRecurso.entidadFinanciera = obj.venta.entidadFinanciera
            objRecurso.glosa = obj.venta.glosa
            objRecurso.notaCredito = obj.venta.notaCredito
            objRecurso.tipoVenta = obj.venta.tipoVenta
            objRecurso.modulo = obj.venta.modulo
            objRecurso.idPadre = obj.venta.idPadre
            objRecurso.usuarioActualizacion = obj.venta.usuarioActualizacion
            objRecurso.fechaActualizacion = obj.venta.fechaActualizacion
            Lista.Add(objRecurso)
        Next

        Return Lista

    End Function


End Class
