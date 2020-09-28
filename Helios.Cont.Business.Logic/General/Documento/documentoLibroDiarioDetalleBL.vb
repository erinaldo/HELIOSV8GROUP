Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity.DbFunctions

Public Class documentoLibroDiarioDetalleBL
    Inherits BaseBL


    Public Sub UpdateTipoCosto(i As documentoLibroDiarioDetalle)
        Dim item As New documentoLibroDiarioDetalle
        Dim documentolibroBL As New documentoLibroDiarioBL
        Using ts As New TransactionScope

            item = (From n In HeliosData.documentoLibroDiarioDetalle _
                   Where n.secuencia = i.secuencia).FirstOrDefault

            item.tipoCosto = i.tipoCosto


            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EnvioCostoGastoLibro(be As List(Of documentoLibroDiarioDetalle))

        For Each i In be
            Me.UpdateTipoCosto(i)
        Next


    End Sub


    Public Function GetListaEstadoCuenta11y18Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoCuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim obj As New documentoLibroDiarioDetalle
        Dim query = (GetUbicar_EstadoCuenta11y18Mensual(strEmpresa, intIdEstablecimiento, tipoCuenta, FechaInicio, FechaFin).Union(GetUbicar_EstadoXCuentaActivoASNMensual(strEmpresa, intIdEstablecimiento, tipoCuenta, FechaInicio, FechaFin))).ToList
        Dim Lista As New List(Of documentoLibroDiarioDetalle)

        For Each i In query.ToList
            obj = New documentoLibroDiarioDetalle

            obj.idDocumento = i.idDocumento
            obj.informacionReferencial = i.informacionReferencial
            obj.nroDoc = i.nroDoc
            obj.tipoIdentificacion = i.tipoIdentificacion
            obj.numeroDoc = i.numeroDoc
            obj.tipoDocumento = i.tipoDocumento
            obj.FechaDoc = i.FechaDoc
            obj.moneda = i.moneda

            If i.tipoAsiento = "H" Then
                obj.importeMN = i.importeMN * -1
                obj.importeME = i.importeME * -1
            Else
                obj.importeMN = i.importeMN
                obj.importeME = i.importeME
            End If

            obj.tipoCambio = i.tipoCambio
            obj.cuenta = i.cuenta


            Lista.Add(obj)
        Next
        Return Lista
    End Function


    Public Function GetListaEstadoCuenta11y18(strEmpresa As String, intIdEstablecimiento As Integer, tipoCuenta As String) As List(Of documentoLibroDiarioDetalle)
        Dim obj As New documentoLibroDiarioDetalle
        Dim query = (GetUbicar_EstadoCuenta11y18(strEmpresa, intIdEstablecimiento, tipoCuenta).Union(GetUbicar_EstadoXCuentaActivoASN(strEmpresa, intIdEstablecimiento, tipoCuenta))).ToList
        Dim Lista As New List(Of documentoLibroDiarioDetalle)

        For Each i In query.ToList
            obj = New documentoLibroDiarioDetalle

            obj.idDocumento = i.idDocumento
            obj.informacionReferencial = i.informacionReferencial
            obj.nroDoc = i.nroDoc
            obj.tipoIdentificacion = i.tipoIdentificacion
            obj.numeroDoc = i.numeroDoc
            obj.tipoDocumento = i.tipoDocumento
            obj.FechaDoc = i.FechaDoc
            obj.moneda = i.moneda

            If i.tipoAsiento = "H" Then
                obj.importeMN = i.importeMN * -1
                obj.importeME = i.importeME * -1
            Else
                obj.importeMN = i.importeMN
                obj.importeME = i.importeME
            End If

            obj.tipoCambio = i.tipoCambio
            obj.cuenta = i.cuenta


            Lista.Add(obj)
        Next
        Return Lista
    End Function


    Public Function GetUbicar_EstadoXCuentaActivoASNMensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoCuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And TruncateTime(doc.fecha) >= FechaInicio.Date And TruncateTime(doc.fecha) <= FechaFin.Date _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "N" And n.cuenta.StartsWith(tipoCuenta)
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio, n.tipoAsiento,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .tipoAsiento = tipoAsiento,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(strEmpresa, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then

                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)

            ElseIf i.moneda = "2" Then

                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio

            End If
            doccompra.cuenta = i.cuenta
            doccompra.tipoAsiento = i.tipoAsiento
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function



    Public Function GetUbicar_EstadoXCuentaActivoASN(strEmpresa As String, intIdEstablecimiento As Integer, tipoCuenta As String) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "N" And n.cuenta.StartsWith(tipoCuenta)
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio, n.tipoAsiento,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .tipoAsiento = tipoAsiento,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then

                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)

            ElseIf i.moneda = "2" Then

                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio

            End If
            doccompra.cuenta = i.cuenta
            doccompra.tipoAsiento = i.tipoAsiento
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function GetUbicar_EstadoCuenta11y18Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoCuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentocompradetalle
                         Join doc In HeliosData.documentocompra
                         On doc.idDocumento Equals n.idDocumento
                         Where doc.idEmpresa = strEmpresa And TruncateTime(doc.fechaDoc) >= FechaInicio.Date And TruncateTime(doc.fechaDoc) <= FechaFin.Date _
                          And doc.tipoCompra = "CMP" And n.idItem.StartsWith(tipoCuenta)).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.n.idDocumento

            ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.doc.idProveedor)
            doccompra.informacionReferencial = ENTIDAD.nombreCompleto
            doccompra.nroDoc = ENTIDAD.nrodoc
            doccompra.tipoIdentificacion = ENTIDAD.tipoDoc


            doccompra.numeroDoc = i.doc.serie & " " & i.doc.numeroDoc
            doccompra.tipoDocumento = i.doc.tipoDoc
            doccompra.FechaDoc = i.doc.fechaDoc
            doccompra.moneda = i.doc.monedaDoc
            If i.doc.monedaDoc = "1" Then
                doccompra.importeMN = CDec(i.n.precioUnitario).ToString("N2")
                'doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.doc.monedaDoc = "2" Then
                doccompra.importeMN = CDec((i.n.precioUnitarioUS) * i.doc.tipocambio).ToString("N2")
                doccompra.importeME = CDec(i.n.precioUnitarioUS).ToString("N2")
                doccompra.tipoCambio = i.doc.tipocambio
            End If
            doccompra.cuenta = i.n.idItem
            doccompra.tipoAsiento = "D"

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function



    Public Function GetUbicar_EstadoCuenta11y18(strEmpresa As String, intIdEstablecimiento As Integer, tipoCuenta As String) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentocompradetalle
                         Join doc In HeliosData.documentocompra
                         On doc.idDocumento Equals n.idDocumento
                         Where doc.idEmpresa = strEmpresa And doc.fechaDoc.Value.Year = AnioGeneral _
                          And doc.tipoCompra = "CMP" And n.idItem.StartsWith(tipoCuenta)).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.n.idDocumento

            ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.doc.idProveedor)
            doccompra.informacionReferencial = ENTIDAD.nombreCompleto
            doccompra.nroDoc = ENTIDAD.nrodoc
            doccompra.tipoIdentificacion = ENTIDAD.tipoDoc


            doccompra.numeroDoc = i.doc.serie & " " & i.doc.numeroDoc
            doccompra.tipoDocumento = i.doc.tipoDoc
            doccompra.FechaDoc = i.doc.fechaDoc
            doccompra.moneda = i.doc.monedaDoc
            If i.doc.monedaDoc = "1" Then
                doccompra.importeMN = CDec(i.n.precioUnitario).ToString("N2")
                'doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.doc.monedaDoc = "2" Then
                doccompra.importeMN = CDec((i.n.precioUnitarioUS) * i.doc.tipocambio).ToString("N2")
                doccompra.importeME = CDec(i.n.precioUnitarioUS).ToString("N2")
                doccompra.tipoCambio = i.doc.tipocambio
            End If
            doccompra.cuenta = i.n.idItem
            doccompra.tipoAsiento = "D"

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function GetUbicar_EstadoCuenta40Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipo As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And TruncateTime(doc.fecha) >= FechaInicio.Date And TruncateTime(doc.fecha) <= FechaFin.Date _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = tipo And n.cuenta.StartsWith("40") And Not n.cuenta.StartsWith("40111")
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(strEmpresa, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                'doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function GetUbicar_EstadoCuenta40(strEmpresa As String, intIdEstablecimiento As Integer, tipo As String) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = tipo And n.cuenta.StartsWith("40") And Not n.cuenta.StartsWith("40111")
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                'doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function GetUbicar_EstadoCuenta30al38Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim list As New List(Of String)

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad

        list.Add("30")
        list.Add("31")
        list.Add("32")
        list.Add("33")
        list.Add("34")
        list.Add("35")
        list.Add("37")
        list.Add("38")


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And TruncateTime(doc.fecha) >= FechaInicio.Date And TruncateTime(doc.fecha) <= FechaFin.Date _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "C" And list.Contains(n.cuenta)
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(strEmpresa, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function GetUbicar_EstadoCuenta30al38(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim list As New List(Of String)

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad

        list.Add("30")
        list.Add("31")
        list.Add("32")
        list.Add("33")
        list.Add("34")
        list.Add("35")
        list.Add("37")
        list.Add("38")


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "C" And list.Contains(n.cuenta)
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function GetUbicar_EstadoCuenta20al28(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim list As New List(Of String)

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad

        list.Add("20")
        list.Add("21")
        list.Add("22")
        list.Add("23")
        list.Add("24")
        list.Add("25")
        list.Add("26")
        list.Add("27")
        list.Add("28")


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "C" And list.Contains(n.cuenta)
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function GetUbicar_EstadoCuenta1413Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim list As New List(Of String)

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad

        list.Add("1413")
        list.Add("1433")
        list.Add("1443")
        list.Add("1681")


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And TruncateTime(doc.fecha) >= FechaInicio.Date And TruncateTime(doc.fecha) <= FechaFin.Date _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "C" And list.Contains(n.cuenta)
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(strEmpresa, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function GetUbicar_EstadoCuenta1413(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim list As New List(Of String)

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad

        list.Add("1413")
        list.Add("1433")
        list.Add("1443")
        list.Add("1681")


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "C" And list.Contains(n.cuenta)
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function GetUbicar_EstadoCuenta16Mensual(strEmpresa As String, intIdEstablecimiento As Integer, PeriodoCont As String) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And doc.fechaPeriodo = PeriodoCont And doc.tipoRegistro = "NM" And n.tipoPago = "C" And n.cuenta.StartsWith("16") And Not n.cuenta.StartsWith("1681")
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio, n.tipoAsiento,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoAsiento = tipoAsiento,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                If i.tipoAsiento = "H" Then
                    doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2") * -1
                    'doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                    doccompra.importeME = CDec(0.0)
                Else

                    doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                    'doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                    doccompra.importeME = CDec(0.0)
                End If
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                If i.tipoAsiento = "H" Then

                    doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2") * -1
                    doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2") * -1

                Else

                    doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                    doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                End If
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function GetUbicar_EstadoCuenta16(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "C" And n.cuenta.StartsWith("16") And Not n.cuenta.StartsWith("1681")
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio, n.tipoAsiento,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoAsiento = tipoAsiento,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                If i.tipoAsiento = "H" Then
                    doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2") * -1
                    'doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                    doccompra.importeME = CDec(0.0)
                Else

                    doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                    'doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                    doccompra.importeME = CDec(0.0)
                End If
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                If i.tipoAsiento = "H" Then

                    doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2") * -1
                    doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2") * -1

                Else

                    doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                    doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                End If
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function GetUbicar_EstadoCuenta14Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And TruncateTime(doc.fecha) >= FechaInicio.Date And TruncateTime(doc.fecha) <= FechaFin.Date _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "C" And n.cuenta.StartsWith("14") And Not n.cuenta.StartsWith("1413") And Not n.cuenta.StartsWith("1433") And Not n.cuenta.StartsWith("1443")
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio, n.tipoAsiento,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoAsiento = tipoAsiento,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(strEmpresa, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                If i.tipoAsiento = "H" Then
                    doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2") * -1
                    'doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                    doccompra.importeME = CDec(0.0)
                Else

                    doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                    'doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                    doccompra.importeME = CDec(0.0)
                End If

                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                If i.tipoAsiento = "H" Then
                    doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2") * -1
                    doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2") * -1
                Else
                    doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                    doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                End If
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function GetUbicar_EstadoCuenta14(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "C" And n.cuenta.StartsWith("14") And Not n.cuenta.StartsWith("1413") And Not n.cuenta.StartsWith("1433") And Not n.cuenta.StartsWith("1443")
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio, n.tipoAsiento,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoAsiento = tipoAsiento,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                If i.tipoAsiento = "H" Then
                    doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2") * -1
                    'doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                    doccompra.importeME = CDec(0.0)
                Else

                    doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                    'doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                    doccompra.importeME = CDec(0.0)
                End If

                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                If i.tipoAsiento = "H" Then
                    doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2") * -1
                    doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2") * -1
                Else
                    doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                    doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                End If
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function GetUbicar_EstadoCuenta123133Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim list As New List(Of String)

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad

        list.Add("123")
        list.Add("133")


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And TruncateTime(doc.fecha) >= FechaInicio.Date And TruncateTime(doc.fecha) <= FechaFin.Date _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "C" And list.Contains(n.cuenta)
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio, n.tipoAsiento,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoAsiento = tipoAsiento,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(strEmpresa, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                If i.tipoAsiento = "H" Then
                    doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2") * -1
                    doccompra.importeME = CDec(0.0)
                Else
                    doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                    doccompra.importeME = CDec(0.0)
                End If
                doccompra.tipoCambio = CDec(0.0)

            ElseIf i.moneda = "2" Then
                If i.tipoAsiento = "H" Then
                    doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2") * -1
                    doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2") * -1
                Else

                    doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                    doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                End If
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function GetUbicar_EstadoCuenta123133(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim list As New List(Of String)

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad

        list.Add("123")
        list.Add("133")


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "C" And list.Contains(n.cuenta)
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio, n.tipoAsiento,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoAsiento = tipoAsiento,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                If i.tipoAsiento = "H" Then
                    doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2") * -1
                    doccompra.importeME = CDec(0.0)
                Else
                    doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                    doccompra.importeME = CDec(0.0)
                End If
                doccompra.tipoCambio = CDec(0.0)

            ElseIf i.moneda = "2" Then
                If i.tipoAsiento = "H" Then
                    doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2") * -1
                    doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2") * -1
                Else

                    doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                    doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                End If
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function GetUbicar_EstadoXCuentaActivoInversoMensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoCuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And TruncateTime(doc.fecha) >= FechaInicio.Date And TruncateTime(doc.fecha) <= FechaFin.Date _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "C" And n.cuenta.StartsWith(tipoCuenta)
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio, n.tipoAsiento,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoAsiento = tipoAsiento,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(strEmpresa, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                If i.tipoAsiento = "H" Then
                    doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                    doccompra.importeME = CDec(0.0)
                Else

                    doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2") * -1
                    doccompra.importeME = CDec(0.0)
                End If

                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                If i.tipoAsiento = "H" Then
                    doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                    doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                Else
                    doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2") * -1
                    doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                End If
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function GetUbicar_EstadoXCuentaActivoInverso(strEmpresa As String, intIdEstablecimiento As Integer, tipoCuenta As String) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "C" And n.cuenta.StartsWith(tipoCuenta)
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio, n.tipoAsiento,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoAsiento = tipoAsiento,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                If i.tipoAsiento = "H" Then
                    doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                    doccompra.importeME = CDec(0.0)
                Else

                    doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2") * -1
                    doccompra.importeME = CDec(0.0)
                End If

                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                If i.tipoAsiento = "H" Then
                    doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                    doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                Else
                    doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2") * -1
                    doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                End If
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function GetUbicar_EstadoXCuentaActivoMensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoCuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And TruncateTime(doc.fecha) >= FechaInicio.Date And TruncateTime(doc.fecha) <= FechaFin.Date And doc.tipoRegistro = "NM" And n.tipoPago = "C" And n.cuenta.StartsWith(tipoCuenta)
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(strEmpresa, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function GetUbicar_EstadoXCuentaActivo(strEmpresa As String, intIdEstablecimiento As Integer, tipoCuenta As String) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "C" And n.cuenta.StartsWith(tipoCuenta)
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function GetListaEstadoCuenta422Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, tipoCuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim obj As New documentoLibroDiarioDetalle
        Dim query = (UbicarAnticipo422CompraMensual(strEmpresa, intIdEstablecimiento, tipoAnticipo, FechaInicio, FechaFin).Union(GetUbicar_EstadoXCuentaPasivoMensual(strEmpresa, intIdEstablecimiento, tipoCuenta, FechaInicio, FechaFin)).Union(UbicarAnticiposOtorgadosMensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin))).ToList
        Dim Lista As New List(Of documentoLibroDiarioDetalle)

        For Each i In query.ToList
            obj = New documentoLibroDiarioDetalle

            obj.idDocumento = i.idDocumento
            obj.informacionReferencial = i.informacionReferencial
            obj.nroDoc = i.nroDoc
            obj.tipoIdentificacion = i.tipoIdentificacion
            obj.numeroDoc = i.numeroDoc
            obj.tipoDocumento = i.tipoDocumento
            obj.FechaDoc = i.FechaDoc
            obj.moneda = i.moneda
            obj.importeMN = i.importeMN
            obj.importeME = i.importeME
            obj.tipoCambio = i.tipoCambio
            obj.cuenta = i.cuenta


            Lista.Add(obj)
        Next
        Return Lista
    End Function

    Public Function GetListaEstadoCuenta422(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, tipoCuenta As String) As List(Of documentoLibroDiarioDetalle)
        Dim obj As New documentoLibroDiarioDetalle
        Dim query = (UbicarAnticipo422Compra(strEmpresa, intIdEstablecimiento, tipoAnticipo).Union(GetUbicar_EstadoXCuentaPasivo(strEmpresa, intIdEstablecimiento, tipoCuenta)).Union(UbicarAnticiposOtorgados(strEmpresa, intIdEstablecimiento))).ToList
        Dim Lista As New List(Of documentoLibroDiarioDetalle)

        For Each i In query.ToList
            obj = New documentoLibroDiarioDetalle

            obj.idDocumento = i.idDocumento
            obj.informacionReferencial = i.informacionReferencial
            obj.nroDoc = i.nroDoc
            obj.tipoIdentificacion = i.tipoIdentificacion
            obj.numeroDoc = i.numeroDoc
            obj.tipoDocumento = i.tipoDocumento
            obj.FechaDoc = i.FechaDoc
            obj.moneda = i.moneda
            obj.importeMN = i.importeMN
            obj.importeME = i.importeME
            obj.tipoCambio = i.tipoCambio
            obj.cuenta = i.cuenta


            Lista.Add(obj)
        Next
        Return Lista
    End Function


    Public Function GetListaEstadoCuenta432Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, tipoCuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim obj As New documentoLibroDiarioDetalle
        Dim query = (UbicarAnticipo432CompraMensual(strEmpresa, intIdEstablecimiento, tipoAnticipo, FechaInicio, FechaFin).Union(GetUbicar_EstadoXCuentaPasivoMensual(strEmpresa, intIdEstablecimiento, tipoCuenta, FechaInicio, FechaFin))).ToList
        Dim Lista As New List(Of documentoLibroDiarioDetalle)

        For Each i In query.ToList
            obj = New documentoLibroDiarioDetalle

            obj.idDocumento = i.idDocumento
            obj.informacionReferencial = i.informacionReferencial
            obj.nroDoc = i.nroDoc
            obj.tipoIdentificacion = i.tipoIdentificacion
            obj.numeroDoc = i.numeroDoc
            obj.tipoDocumento = i.tipoDocumento
            obj.FechaDoc = i.FechaDoc
            obj.moneda = i.moneda
            obj.importeMN = i.importeMN
            obj.importeME = i.importeME
            obj.tipoCambio = i.tipoCambio
            obj.cuenta = i.cuenta


            Lista.Add(obj)
        Next
        Return Lista
    End Function

    Public Function GetListaEstadoCuenta432(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, tipoCuenta As String) As List(Of documentoLibroDiarioDetalle)
        Dim obj As New documentoLibroDiarioDetalle
        Dim query = (UbicarAnticipo432Compra(strEmpresa, intIdEstablecimiento, tipoAnticipo).Union(GetUbicar_EstadoXCuentaPasivo(strEmpresa, intIdEstablecimiento, tipoCuenta))).ToList
        Dim Lista As New List(Of documentoLibroDiarioDetalle)

        For Each i In query.ToList
            obj = New documentoLibroDiarioDetalle

            obj.idDocumento = i.idDocumento
            obj.informacionReferencial = i.informacionReferencial
            obj.nroDoc = i.nroDoc
            obj.tipoIdentificacion = i.tipoIdentificacion
            obj.numeroDoc = i.numeroDoc
            obj.tipoDocumento = i.tipoDocumento
            obj.FechaDoc = i.FechaDoc
            obj.moneda = i.moneda
            obj.importeMN = i.importeMN
            obj.importeME = i.importeME
            obj.tipoCambio = i.tipoCambio
            obj.cuenta = i.cuenta


            Lista.Add(obj)
        Next
        Return Lista
    End Function


    Public Function GetListaEstadoCuenta132Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, tipoCuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim obj As New documentoLibroDiarioDetalle
        Dim query = (UbicarCuentasXPagarAnticipo132Mensual(strEmpresa, intIdEstablecimiento, tipoAnticipo, FechaInicio, FechaFin).Union(GetUbicar_EstadoXCuentaPasivoMensual(strEmpresa, intIdEstablecimiento, tipoCuenta, FechaInicio, FechaFin))).ToList
        Dim Lista As New List(Of documentoLibroDiarioDetalle)

        For Each i In query.ToList
            obj = New documentoLibroDiarioDetalle

            obj.idDocumento = i.idDocumento
            obj.informacionReferencial = i.informacionReferencial
            obj.nroDoc = i.nroDoc
            obj.tipoIdentificacion = i.tipoIdentificacion
            obj.numeroDoc = i.numeroDoc
            obj.tipoDocumento = i.tipoDocumento
            obj.FechaDoc = i.FechaDoc
            obj.moneda = i.moneda
            obj.importeMN = i.importeMN
            obj.importeME = i.importeME
            obj.tipoCambio = i.tipoCambio
            obj.cuenta = i.cuenta


            Lista.Add(obj)
        Next
        Return Lista
    End Function


    Public Function GetListaEstadoCuenta122Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, tipoCuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim obj As New documentoLibroDiarioDetalle
        Dim query = (UbicarCuentasXPagarAnticipoMensual(strEmpresa, intIdEstablecimiento, tipoAnticipo, FechaInicio, FechaFin).Union(GetUbicar_EstadoXCuentaPasivoMensual(strEmpresa, intIdEstablecimiento, tipoCuenta, FechaInicio, FechaFin)).Union(UbicarAnticiposRecibidosMensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin))).ToList
        Dim Lista As New List(Of documentoLibroDiarioDetalle)

        For Each i In query.ToList
            obj = New documentoLibroDiarioDetalle

            obj.idDocumento = i.idDocumento
            obj.informacionReferencial = i.informacionReferencial
            obj.nroDoc = i.nroDoc
            obj.tipoIdentificacion = i.tipoIdentificacion
            obj.numeroDoc = i.numeroDoc
            obj.tipoDocumento = i.tipoDocumento
            obj.FechaDoc = i.FechaDoc
            obj.moneda = i.moneda
            obj.importeMN = i.importeMN
            obj.importeME = i.importeME
            obj.tipoCambio = i.tipoCambio
            obj.cuenta = i.cuenta


            Lista.Add(obj)
        Next
        Return Lista
    End Function

    Public Function GetListaEstadoCuenta122(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, tipoCuenta As String) As List(Of documentoLibroDiarioDetalle)
        Dim obj As New documentoLibroDiarioDetalle
        Dim query = (UbicarCuentasXPagarAnticipo(strEmpresa, intIdEstablecimiento, tipoAnticipo).Union(GetUbicar_EstadoXCuentaPasivo(strEmpresa, intIdEstablecimiento, tipoCuenta)).Union(UbicarAnticiposRecibidos(strEmpresa, intIdEstablecimiento))).ToList
        Dim Lista As New List(Of documentoLibroDiarioDetalle)

        For Each i In query.ToList
            obj = New documentoLibroDiarioDetalle

            obj.idDocumento = i.idDocumento
            obj.informacionReferencial = i.informacionReferencial
            obj.nroDoc = i.nroDoc
            obj.tipoIdentificacion = i.tipoIdentificacion
            obj.numeroDoc = i.numeroDoc
            obj.tipoDocumento = i.tipoDocumento
            obj.FechaDoc = i.FechaDoc
            obj.moneda = i.moneda
            obj.importeMN = i.importeMN
            obj.importeME = i.importeME
            obj.tipoCambio = i.tipoCambio
            obj.cuenta = i.cuenta


            Lista.Add(obj)
        Next
        Return Lista
    End Function


    Public Function UbicarAnticiposRecibidos132Mensual(strEmpresa As String, intIdEstablecimiento As Integer, anioPeriodo As String, mesPeriodo As String) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim entidadbl As New entidadBL
        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoAnticipo
                         Where n.idEmpresa = Gempresas.IdEmpresaRuc _
                      And n.tipoAnticipo = "AR" And n.fechaDoc.Value.Year <= anioPeriodo And n.fechaDoc.Value.Month <= mesPeriodo).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            ' If i.tiporazon = "PR" Then
            ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonSocial)
            doccompra.informacionReferencial = ENTIDAD.nombreCompleto
            doccompra.nroDoc = ENTIDAD.nrodoc
            doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ' End If
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.Moneda

            If i.Moneda = "1" Then

                doccompra.importeMN = CDec(i.importeMN).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.Moneda = "2" Then

                doccompra.importeMN = CDec(i.importeMN * i.TipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.importeME).ToString("N2")
                doccompra.tipoCambio = i.TipoCambio
            End If

            doccompra.cuenta = "132"

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function UbicarAnticiposRecibidosMensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim entidadbl As New entidadBL
        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoAnticipo
                         Where n.idEmpresa = strEmpresa _
                      And n.tipoAnticipo = "AR" And TruncateTime(n.fechaDoc) >= FechaInicio.Date And TruncateTime(n.fechaDoc) <= FechaFin.Date).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            ' If i.tiporazon = "PR" Then
            ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "CL", i.razonSocial)
            doccompra.informacionReferencial = ENTIDAD.nombreCompleto
            doccompra.nroDoc = ENTIDAD.nrodoc
            doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ' End If
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.Moneda

            If i.Moneda = "1" Then

                doccompra.importeMN = CDec(i.importeMN).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.Moneda = "2" Then

                doccompra.importeMN = CDec(i.importeMN * i.TipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.importeME).ToString("N2")
                doccompra.tipoCambio = i.TipoCambio
            End If

            doccompra.cuenta = "122"

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function UbicarAnticiposRecibidos(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim entidadbl As New entidadBL
        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoAnticipo
                         Where n.idEmpresa = Gempresas.IdEmpresaRuc _
                      And n.tipoAnticipo = "AR").ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            ' If i.tiporazon = "PR" Then
            ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonSocial)
            doccompra.informacionReferencial = ENTIDAD.nombreCompleto
            doccompra.nroDoc = ENTIDAD.nrodoc
            doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ' End If
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.Moneda

            If i.Moneda = "1" Then

                doccompra.importeMN = CDec(i.importeMN).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.Moneda = "2" Then

                doccompra.importeMN = CDec(i.importeMN * i.TipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.importeME).ToString("N2")
                doccompra.tipoCambio = i.TipoCambio
            End If

            doccompra.cuenta = "122"

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function UbicarAnticiposOtorgadosMensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim entidadbl As New entidadBL
        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoAnticipo
                         Where n.idEmpresa = strEmpresa _
                      And n.tipoAnticipo = "AO" And TruncateTime(n.fechaDoc) >= FechaInicio.Date And TruncateTime(n.fechaDoc) <= FechaFin.Date).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            ' If i.tiporazon = "PR" Then
            ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.razonSocial)
            doccompra.informacionReferencial = ENTIDAD.nombreCompleto
            doccompra.nroDoc = ENTIDAD.nrodoc
            doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ' End If
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.Moneda

            If i.Moneda = "1" Then

                doccompra.importeMN = CDec(i.importeMN).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.Moneda = "2" Then

                doccompra.importeMN = CDec(i.importeMN * i.TipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.importeME).ToString("N2")
                doccompra.tipoCambio = i.TipoCambio
            End If

            doccompra.cuenta = "422"

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function UbicarAnticiposOtorgados(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim entidadbl As New entidadBL
        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoAnticipo
                         Where n.idEmpresa = Gempresas.IdEmpresaRuc _
                      And n.tipoAnticipo = "AO").ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            ' If i.tiporazon = "PR" Then
            ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonSocial)
            doccompra.informacionReferencial = ENTIDAD.nombreCompleto
            doccompra.nroDoc = ENTIDAD.nrodoc
            doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ' End If
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.Moneda

            If i.Moneda = "1" Then

                doccompra.importeMN = CDec(i.importeMN).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.Moneda = "2" Then

                doccompra.importeMN = CDec(i.importeMN * i.TipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.importeME).ToString("N2")
                doccompra.tipoCambio = i.TipoCambio
            End If

            doccompra.cuenta = "422"

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function UbicarAnticipo432CompraMensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim entidadbl As New entidadBL
        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentocompra
                         Where n.idEmpresa = strEmpresa _
                      And n.tipoCompra = tipoAnticipo And TruncateTime(n.fechaDoc) >= FechaInicio.Date And TruncateTime(n.fechaDoc) <= FechaFin.Date).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            ' If i.tiporazon = "PR" Then
            ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.idProveedor)
            doccompra.informacionReferencial = ENTIDAD.nombreCompleto
            doccompra.nroDoc = ENTIDAD.nrodoc
            doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ' End If
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDoc
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.monedaDoc

            If i.monedaDoc = "1" Then

                doccompra.importeMN = CDec(i.bi01).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.monedaDoc = "2" Then

                doccompra.importeMN = CDec(i.bi01us * i.tipocambio).ToString("N2")
                doccompra.importeME = CDec(i.bi01us).ToString("N2")
                doccompra.tipoCambio = i.tipocambio
            End If
            'If i.tipoVenta = "CRH" Then
            '    doccompra.cuenta = "122"
            'Else
            doccompra.cuenta = "432"
            'End If
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function UbicarAnticipo432Compra(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim entidadbl As New entidadBL
        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentocompra
                         Where n.idEmpresa = Gempresas.IdEmpresaRuc _
                      And n.tipoCompra = tipoAnticipo).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            ' If i.tiporazon = "PR" Then
            ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.idProveedor)
            doccompra.informacionReferencial = ENTIDAD.nombreCompleto
            doccompra.nroDoc = ENTIDAD.nrodoc
            doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ' End If
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDoc
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.monedaDoc

            If i.monedaDoc = "1" Then

                doccompra.importeMN = CDec(i.bi01).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.monedaDoc = "2" Then

                doccompra.importeMN = CDec(i.bi01us * i.tipocambio).ToString("N2")
                doccompra.importeME = CDec(i.bi01us).ToString("N2")
                doccompra.tipoCambio = i.tipocambio
            End If
            'If i.tipoVenta = "CRH" Then
            '    doccompra.cuenta = "122"
            'Else
            doccompra.cuenta = "432"
            'End If
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function UbicarAnticipo422CompraMensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim entidadbl As New entidadBL
        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentocompra
                         Where n.idEmpresa = strEmpresa _
                      And n.tipoCompra = tipoAnticipo And TruncateTime(n.fechaDoc) >= FechaInicio.Date And TruncateTime(n.fechaDoc) <= FechaFin.Date).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            ' If i.tiporazon = "PR" Then
            ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.idProveedor)
            doccompra.informacionReferencial = ENTIDAD.nombreCompleto
            doccompra.nroDoc = ENTIDAD.nrodoc
            doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ' End If
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDoc
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.monedaDoc

            If i.monedaDoc = "1" Then

                doccompra.importeMN = CDec(i.bi01).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.monedaDoc = "2" Then

                doccompra.importeMN = CDec(i.bi01us * i.tipocambio).ToString("N2")
                doccompra.importeME = CDec(i.bi01us).ToString("N2")
                doccompra.tipoCambio = i.tipocambio
            End If
            'If i.tipoVenta = "CRH" Then
            '    doccompra.cuenta = "122"
            'Else
            doccompra.cuenta = "422"
            'End If
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function UbicarAnticipo422Compra(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim entidadbl As New entidadBL
        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentocompra
                         Where n.idEmpresa = Gempresas.IdEmpresaRuc _
                      And n.tipoCompra = tipoAnticipo).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            ' If i.tiporazon = "PR" Then
            ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.idProveedor)
            doccompra.informacionReferencial = ENTIDAD.nombreCompleto
            doccompra.nroDoc = ENTIDAD.nrodoc
            doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ' End If
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDoc
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.monedaDoc

            If i.monedaDoc = "1" Then

                doccompra.importeMN = CDec(i.bi01).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.monedaDoc = "2" Then

                doccompra.importeMN = CDec(i.bi01us * i.tipocambio).ToString("N2")
                doccompra.importeME = CDec(i.bi01us).ToString("N2")
                doccompra.tipoCambio = i.tipocambio
            End If
            'If i.tipoVenta = "CRH" Then
            '    doccompra.cuenta = "122"
            'Else
            doccompra.cuenta = "422"
            'End If
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function UbicarCuentasXPagarAnticipo132Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim entidadbl As New entidadBL
        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoventaAbarrotes
                         Where n.idEmpresa = strEmpresa _
                      And n.tipoVenta = tipoAnticipo And TruncateTime(n.fechaDoc) >= FechaInicio.Date And TruncateTime(n.fechaDoc) <= FechaFin.Date).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            ' If i.tiporazon = "PR" Then
            ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "CL", i.idCliente)
            doccompra.informacionReferencial = ENTIDAD.nombreCompleto
            doccompra.nroDoc = ENTIDAD.nrodoc
            doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ' End If
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda

            If i.moneda = "1" Then

                doccompra.importeMN = CDec(i.bi01).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then

                doccompra.importeMN = CDec(i.bi01us * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.bi01us).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If


            doccompra.cuenta = "132"

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function UbicarCuentasXPagarAnticipoMensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim entidadbl As New entidadBL
        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoventaAbarrotes
                         Where n.idEmpresa = strEmpresa _
                      And n.tipoVenta = tipoAnticipo And TruncateTime(n.fechaDoc) >= FechaInicio.Date And TruncateTime(n.fechaDoc) <= FechaFin.Date).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            ' If i.tiporazon = "PR" Then
            ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "CL", i.idCliente)
            doccompra.informacionReferencial = ENTIDAD.nombreCompleto
            doccompra.nroDoc = ENTIDAD.nrodoc
            doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ' End If
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda

            If i.moneda = "1" Then

                doccompra.importeMN = CDec(i.bi01).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then

                doccompra.importeMN = CDec(i.bi01us * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.bi01us).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If


            doccompra.cuenta = "122"

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function UbicarCuentasXPagarAnticipo(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim entidadbl As New entidadBL
        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoventaAbarrotes
                         Where n.idEmpresa = Gempresas.IdEmpresaRuc _
                      And n.tipoVenta = tipoAnticipo).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            ' If i.tiporazon = "PR" Then
            ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.idCliente)
            doccompra.informacionReferencial = ENTIDAD.nombreCompleto
            doccompra.nroDoc = ENTIDAD.nrodoc
            doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ' End If
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda

            If i.moneda = "1" Then

                doccompra.importeMN = CDec(i.ImporteNacional).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then

                doccompra.importeMN = CDec(i.ImporteExtranjero * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            If i.tipoVenta = "CRH" Then
                doccompra.cuenta = "122"
            Else
                doccompra.cuenta = "132"
            End If
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function GetUbicar_EstadoCuenta423433Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim list As New List(Of String)

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad

        list.Add("423")
        list.Add("433")


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And TruncateTime(doc.fecha) >= FechaInicio.Date And TruncateTime(doc.fecha) <= FechaFin.Date _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "P" And list.Contains(n.cuenta)
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(strEmpresa, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function GetUbicar_EstadoCuenta423433(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim list As New List(Of String)

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad

        list.Add("423")
        list.Add("433")


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "P" And list.Contains(n.cuenta)
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function GetUbicar_EstadoXCuentaPasivoMensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoCuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And TruncateTime(doc.fecha) >= FechaInicio.Date And TruncateTime(doc.fecha) <= FechaFin.Date _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "P" And n.cuenta.StartsWith(tipoCuenta)
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(strEmpresa, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function GetUbicar_EstadoXCuentaPasivo(strEmpresa As String, intIdEstablecimiento As Integer, tipoCuenta As String) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "P" And n.cuenta.StartsWith(tipoCuenta)
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function GetUbicar_EstadoCuenta13Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And TruncateTime(doc.fecha) >= FechaInicio.Date And TruncateTime(doc.fecha) <= FechaFin.Date And doc.tipoRegistro = "NM" And n.tipoPago = "C" And n.cuenta.StartsWith("13") And Not n.cuenta.StartsWith("132") And Not n.cuenta.StartsWith("133")
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio, n.tipoAsiento,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoAsiento = tipoAsiento,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(strEmpresa, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                If i.tipoAsiento = "H" Then
                    doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2") * -1
                    doccompra.importeME = CDec(0.0)
                Else

                    doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                    doccompra.importeME = CDec(0.0)
                End If
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then

                If i.tipoAsiento = "H" Then
                    doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2") * -1
                    doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2") * -1
                Else
                    doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                    doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                End If

                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta


            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function GetUbicar_EstadoCuenta13(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "C" And n.cuenta.StartsWith("13") And Not n.cuenta.StartsWith("132") And Not n.cuenta.StartsWith("133")
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio, n.tipoAsiento,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoAsiento = tipoAsiento,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                If i.tipoAsiento = "H" Then
                    doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2") * -1
                    doccompra.importeME = CDec(0.0)
                Else

                    doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                    doccompra.importeME = CDec(0.0)
                End If
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then

                If i.tipoAsiento = "H" Then
                    doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2") * -1
                    doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2") * -1
                Else
                    doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                    doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                End If

                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta


            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function GetListaEstadoCuenta46Anual(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim obj As New documentoLibroDiarioDetalle
        Dim query = (UbicarCuentasXReclamar46Anual(strEmpresa, intIdEstablecimiento).Union(GetUbicar_EstadoXCuentaPasivo(strEmpresa, intIdEstablecimiento, "46"))).ToList
        Dim Lista As New List(Of documentoLibroDiarioDetalle)

        For Each i In query.ToList
            obj = New documentoLibroDiarioDetalle


            obj.idDocumento = i.idDocumento
            obj.informacionReferencial = i.informacionReferencial
            obj.nroDoc = i.nroDoc
            obj.tipoIdentificacion = i.tipoIdentificacion
            obj.numeroDoc = i.numeroDoc
            obj.tipoDocumento = i.tipoDocumento
            obj.FechaDoc = i.FechaDoc
            obj.moneda = i.moneda
            If i.tipoAsiento = "H" Then
                obj.importeMN = i.importeMN * -1
                obj.importeME = i.importeME * -1
            Else

                obj.importeMN = i.importeMN
                obj.importeME = i.importeME
            End If
            obj.tipoCambio = i.tipoCambio
            obj.cuenta = i.cuenta


            Lista.Add(obj)
        Next
        Return Lista
    End Function

    Public Function GetListaEstadoCuenta46Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim obj As New documentoLibroDiarioDetalle
        Dim query = (UbicarCuentasXReclamar46Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin).Union(GetUbicar_EstadoXCuentaPasivoMensual(strEmpresa, intIdEstablecimiento, "46", FechaInicio, FechaFin))).ToList
        Dim Lista As New List(Of documentoLibroDiarioDetalle)

        For Each i In query.ToList
            obj = New documentoLibroDiarioDetalle


            obj.idDocumento = i.idDocumento
            obj.informacionReferencial = i.informacionReferencial
            obj.nroDoc = i.nroDoc
            obj.tipoIdentificacion = i.tipoIdentificacion
            obj.numeroDoc = i.numeroDoc
            obj.tipoDocumento = i.tipoDocumento
            obj.FechaDoc = i.FechaDoc
            obj.moneda = i.moneda
            If i.tipoAsiento = "H" Then
                obj.importeMN = i.importeMN * -1
                obj.importeME = i.importeME * -1
            Else

                obj.importeMN = i.importeMN
                obj.importeME = i.importeME
            End If
            obj.tipoCambio = i.tipoCambio
            obj.cuenta = i.cuenta


            Lista.Add(obj)
        Next
        Return Lista
    End Function


    Public Function GetListaEstadoCuenta16Anual(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim obj As New documentoLibroDiarioDetalle
        Dim query = (UbicarCuentasXReclamar16Anual(strEmpresa, intIdEstablecimiento).Union(GetUbicar_EstadoXCuentaActivo(strEmpresa, intIdEstablecimiento, "16"))).ToList
        Dim Lista As New List(Of documentoLibroDiarioDetalle)

        For Each i In query.ToList
            obj = New documentoLibroDiarioDetalle


            obj.idDocumento = i.idDocumento
            obj.informacionReferencial = i.informacionReferencial
            obj.nroDoc = i.nroDoc
            obj.tipoIdentificacion = i.tipoIdentificacion
            obj.numeroDoc = i.numeroDoc
            obj.tipoDocumento = i.tipoDocumento
            obj.FechaDoc = i.FechaDoc
            obj.moneda = i.moneda
            If i.tipoAsiento = "H" Then
                obj.importeMN = i.importeMN * -1
                obj.importeME = i.importeME * -1
            Else

                obj.importeMN = i.importeMN
                obj.importeME = i.importeME
            End If
            obj.tipoCambio = i.tipoCambio
            obj.cuenta = i.cuenta


            Lista.Add(obj)
        Next
        Return Lista
    End Function

    Public Function GetListaEstadoCuenta16Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim obj As New documentoLibroDiarioDetalle
        Dim query = (UbicarCuentasXReclamar16Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin).Union(GetUbicar_EstadoXCuentaActivoMensual(strEmpresa, intIdEstablecimiento, "16", FechaInicio, FechaFin))).ToList
        Dim Lista As New List(Of documentoLibroDiarioDetalle)

        For Each i In query.ToList
            obj = New documentoLibroDiarioDetalle


            obj.idDocumento = i.idDocumento
            obj.informacionReferencial = i.informacionReferencial
            obj.nroDoc = i.nroDoc
            obj.tipoIdentificacion = i.tipoIdentificacion
            obj.numeroDoc = i.numeroDoc
            obj.tipoDocumento = i.tipoDocumento
            obj.FechaDoc = i.FechaDoc
            obj.moneda = i.moneda
            If i.tipoAsiento = "H" Then
                obj.importeMN = i.importeMN * -1
                obj.importeME = i.importeME * -1
            Else

                obj.importeMN = i.importeMN
                obj.importeME = i.importeME
            End If
            obj.tipoCambio = i.tipoCambio
            obj.cuenta = i.cuenta


            Lista.Add(obj)
        Next
        Return Lista
    End Function



    Public Function GetListaEstadoCuenta12Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim obj As New documentoLibroDiarioDetalle
        Dim query = (UbicarCuentasXCobrarComercialesMensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin).Union(GetUbicar_EstadoCuenta12Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin))).ToList
        Dim Lista As New List(Of documentoLibroDiarioDetalle)

        For Each i In query.ToList
            obj = New documentoLibroDiarioDetalle


            obj.idDocumento = i.idDocumento
            obj.informacionReferencial = i.informacionReferencial
            obj.nroDoc = i.nroDoc
            obj.tipoIdentificacion = i.tipoIdentificacion
            obj.numeroDoc = i.numeroDoc
            obj.tipoDocumento = i.tipoDocumento
            obj.FechaDoc = i.FechaDoc
            obj.moneda = i.moneda
            If i.tipoAsiento = "H" Then
                obj.importeMN = i.importeMN * -1
                obj.importeME = i.importeME * -1
            Else

                obj.importeMN = i.importeMN
                obj.importeME = i.importeME
            End If
            obj.tipoCambio = i.tipoCambio
            obj.cuenta = i.cuenta


            Lista.Add(obj)
        Next
        Return Lista
    End Function



    Public Function GetListaEstadoCuenta12(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim obj As New documentoLibroDiarioDetalle
        Dim query = (UbicarCuentasXCobrarComerciales(strEmpresa, intIdEstablecimiento).Union(GetUbicar_EstadoCuenta12(strEmpresa, intIdEstablecimiento))).ToList
        Dim Lista As New List(Of documentoLibroDiarioDetalle)

        For Each i In query.ToList
            obj = New documentoLibroDiarioDetalle


            obj.idDocumento = i.idDocumento
            obj.informacionReferencial = i.informacionReferencial
            obj.nroDoc = i.nroDoc
            obj.tipoIdentificacion = i.tipoIdentificacion
            obj.numeroDoc = i.numeroDoc
            obj.tipoDocumento = i.tipoDocumento
            obj.FechaDoc = i.FechaDoc
            obj.moneda = i.moneda
            If i.tipoAsiento = "H" Then
                obj.importeMN = i.importeMN * -1
                obj.importeME = i.importeME * -1
            Else

                obj.importeMN = i.importeMN
                obj.importeME = i.importeME
            End If
            obj.tipoCambio = i.tipoCambio
            obj.cuenta = i.cuenta


            Lista.Add(obj)
        Next
        Return Lista
    End Function

    Public Function GetUbicar_EstadoCuenta12Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And TruncateTime(doc.fecha) >= FechaInicio.Date And TruncateTime(doc.fecha) <= FechaFin.Date And doc.tipoRegistro = "NM" And n.tipoPago = "C" And n.cuenta.StartsWith("12") And Not n.cuenta.StartsWith("122") And Not n.cuenta.StartsWith("123")
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio, n.tipoAsiento,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoAsiento = tipoAsiento,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(strEmpresa, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                'doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            doccompra.tipoAsiento = i.tipoAsiento

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function GetUbicar_EstadoCuenta12(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "C" And n.cuenta.StartsWith("12") And Not n.cuenta.StartsWith("122") And Not n.cuenta.StartsWith("123")
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio, n.tipoAsiento,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoAsiento = tipoAsiento,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                'doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            doccompra.tipoAsiento = i.tipoAsiento

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function UbicarCuentasXReclamar46Anual(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim ENTIDAD As New entidad
        Dim entidadbl As New entidadBL
        Dim list As New List(Of String)



        list.Add("EXD")



        Dim consulta2 = (From n In HeliosData.documentoventaAbarrotes
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where n.idEmpresa = strEmpresa _
                         And n.estadoCobro = "PN" And list.Contains(n.tipoVenta)
                         Group c By n.idDocumento, n.tipoVenta, n.fechaPeriodo, n.fechaDoc, n.tipoDocumento,
                         n.serie, n.moneda, n.ImporteNacional, n.tipoCambio, n.nombrePedido, n.numeroDoc, n.idCliente,
                         n.ImporteExtranjero, n.estadoCobro Into g = Group
                         Select New With {
                                        .idDocumento = idDocumento,
                                        .fechaDoc = fechaDoc,
                                        .numeroDoc = serie & "-" & numeroDoc,
                                        .razonsocial = idCliente,
                                        .tiporazon = "CL",
                                        .tipoDocumento = tipoDocumento,
                                        .moneda = moneda,
                                        .tipoCambio = tipoCambio,
                                        .ImporteNacional = ImporteNacional,
                                        .ImporteExtranjero = ImporteExtranjero,
                                        .tipoVenta = tipoVenta,
                                        .SumaPagoMN = g.Sum(Function(o) o.montoSoles),
                                        .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento

            If IsNothing(i.razonsocial) Then
                doccompra.informacionReferencial = " "
                doccompra.nroDoc = ENTIDAD.nrodoc = " "
                doccompra.tipoIdentificacion = " "
            Else
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            End If
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = ((i.ImporteNacional) - (CDec((i.SumaPagoMN.GetValueOrDefault)).ToString("N2")))
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero) - (i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = ((i.ImporteExtranjero) - (i.SumaPagoME.GetValueOrDefault))
                doccompra.tipoCambio = i.tipoCambio
            End If

            doccompra.cuenta = "1213"
            doccompra.tipoAsiento = "D"

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function UbicarCuentasXReclamar46Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim ENTIDAD As New entidad
        Dim entidadbl As New entidadBL
        Dim list As New List(Of String)

        list.Add("EXD")

        Dim consulta2 = (From n In HeliosData.documentoventaAbarrotes
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where n.idEmpresa = strEmpresa _
                         And n.estadoCobro = "PN" And list.Contains(n.tipoVenta) _
                         And TruncateTime(n.fechaDoc) >= FechaInicio.Date And TruncateTime(n.fechaDoc) <= FechaFin.Date
                         Group c By n.idDocumento, n.tipoVenta, n.fechaPeriodo, n.fechaDoc, n.tipoDocumento,
                         n.serie, n.moneda, n.ImporteNacional, n.tipoCambio, n.nombrePedido, n.numeroDoc, n.idCliente,
                         n.ImporteExtranjero, n.estadoCobro Into g = Group
                         Select New With {
                                        .idDocumento = idDocumento,
                                        .fechaDoc = fechaDoc,
                                        .numeroDoc = serie & "-" & numeroDoc,
                                        .razonsocial = idCliente,
                                        .tiporazon = "CL",
                                        .tipoDocumento = tipoDocumento,
                                        .moneda = moneda,
                                        .tipoCambio = tipoCambio,
                                        .ImporteNacional = ImporteNacional,
                                        .ImporteExtranjero = ImporteExtranjero,
                                        .tipoVenta = tipoVenta,
                                        .SumaPagoMN = g.Sum(Function(o) o.montoSoles),
                                        .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento

            If IsNothing(i.razonsocial) Then
                doccompra.informacionReferencial = " "
                doccompra.nroDoc = ENTIDAD.nrodoc = " "
                doccompra.tipoIdentificacion = " "
            Else
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            End If
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = ((i.ImporteNacional) - (CDec((i.SumaPagoMN.GetValueOrDefault)).ToString("N2")))
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero) - (i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = ((i.ImporteExtranjero) - (i.SumaPagoME.GetValueOrDefault))
                doccompra.tipoCambio = i.tipoCambio
            End If

            doccompra.cuenta = "1213"
            doccompra.tipoAsiento = "D"

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function UbicarCuentasXCobrarComercialesMensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim ENTIDAD As New entidad
        Dim entidadbl As New entidadBL



        Dim consulta2 = (From c In HeliosData.documentoventaAbarrotes
                         Where
                  (New String() {"VNS", "VTAG", "VPOS", "VAO", "VAR"}).Contains(c.tipoVenta) And
                   c.idEmpresa = strEmpresa _
                   And TruncateTime(c.fechaDoc) <= FechaFin.Date _
                    And TruncateTime(c.fechaDoc) >= FechaInicio.Date
                         Select
                  c.idDocumento,
                  c.tipoVenta,
                  c.fechaPeriodo,
                  c.fechaDoc,
                  c.idCliente,
                  c.serie,
                  c.numeroDoc,
                  c.tipoDocumento,
                  c.moneda,
                  c.ImporteNacional,
                  c.tipoCambio,
                  c.ImporteExtranjero,
                  c.estadoCobro,
                  PagosMN = (CType((Aggregate t1 In
                                    (From DocumentoCajaDetalle In HeliosData.documentoCajaDetalle
                                     Where
                                     DocumentoCajaDetalle.documentoAfectado = c.idDocumento
                                     Select New With {
                                         DocumentoCajaDetalle.montoSoles
                                     }) Into Sum(t1.montoSoles)), Decimal?)),
                 PagosME = (CType((Aggregate t1 In
                                   (From DocumentoCajaDetalle In HeliosData.documentoCajaDetalle
                                    Where
                                    DocumentoCajaDetalle.documentoAfectado = c.idDocumento
                                    Select New With {
                                        DocumentoCajaDetalle.montoUsd
                                    }) Into Sum(t1.montoUsd)), Decimal?)),
                PagoNotaCredito = (CType((Aggregate t1 In
                                          (From Documentocompra In HeliosData.documentoventaAbarrotes
                                           Where
                                           (New String() {"07", "87", "9901"}).Contains(Documentocompra.tipoDocumento) And
                                           Documentocompra.idPadre = c.idDocumento And Documentocompra.tipoVenta <> "EXD"
                                           Select New With {
                                               Documentocompra.ImporteNacional
                                           }) Into Sum(t1.ImporteNacional)), Decimal?)),
                              Exedente = (CType((Aggregate t1 In
                                          (From Documentocompra In HeliosData.documentoventaAbarrotes
                                           Where
                                           (New String() {"07", "87", "9901"}).Contains(Documentocompra.tipoDocumento) And
                                           Documentocompra.idPadre = c.idDocumento And Documentocompra.tipoVenta = "EXD"
                                           Select New With {
                                               Documentocompra.ImporteNacional
                                           }) Into Sum(t1.ImporteNacional)), Decimal?)),
                       PagoNotaDebito = (CType((Aggregate t1 In
                                                (From Documentocompra In HeliosData.documentoventaAbarrotes
                                                 Where
                                                 (New String() {"08", "88"}).Contains(Documentocompra.tipoDocumento) And
                                                 Documentocompra.idPadre = c.idDocumento
                                                 Select New With {
                                                     Documentocompra.ImporteNacional
                                                 }) Into Sum(t1.ImporteNacional)), Decimal?)),
                             Conteo = ((Aggregate t1 In
                                        (From cro In HeliosData.Cronograma
                                         Where
                                         cro.idDocumentoRef = c.idDocumento And
                                         cro.estado = "PN"
                                         Select New With {
                                                cro
                                         }) Into Count()))).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento

            If IsNothing(i.idCliente) Then
                doccompra.informacionReferencial = " "
                doccompra.nroDoc = ENTIDAD.nrodoc = " "
                doccompra.tipoIdentificacion = " "
            Else
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "CL", i.idCliente)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            End If
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = ((i.ImporteNacional) - (CDec((i.PagosMN.GetValueOrDefault)).ToString("N2")) - (i.PagoNotaCredito.GetValueOrDefault - i.Exedente) + i.PagoNotaDebito.GetValueOrDefault)
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                'doccompra.importeMN = CDec((i.ImporteExtranjero) - (i.PagosME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                'doccompra.importeME = ((i.ImporteExtranjero) - (i.PagosME.GetValueOrDefault))
                doccompra.importeMN = CDec(0.0)
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = i.tipoCambio
            End If

            doccompra.cuenta = "1213"
            doccompra.tipoAsiento = "D"

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function UbicarCuentasXCobrarComerciales(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim ENTIDAD As New entidad
        Dim entidadbl As New entidadBL
        Dim list As New List(Of String)

        'list.Add(TIPO_VENTA.VENTA_NORMAL_CREDITO)
        'list.Add(TIPO_VENTA.VENTA_GENERAL)
        ''list.Add(TIPO_VENTA.VENTA_POS_DIRECTA)

        list.Add(TIPO_VENTA.VENTA_POS_DIRECTA)
        'list.Add(TIPO_VENTA.VENTA_AL_TICKET)
        list.Add(TIPO_VENTA.VENTA_GENERAL)
        'list.Add("VNP")
        'list.Add(TIPO_VENTA.VENTA_ANTICIPADA)
        'list.Add(TIPO_VENTA.VENTA_ANTICIPADA_RECIBIDO)
        'list.Add(TIPO_VENTA.VENTA_ANTICIPADA_OTORGADO)
        ''list.Add(TIPO_VENTA.VENTA_CONTADO_TOTAL)
        ''list.Add(TIPO_VENTA.VENTA_CONTADO_PARCIAL)
        'list.Add(TIPO_VENTA.VENTA_CREDITO_TOTAL)
        'list.Add(TIPO_VENTA.VENTA_CREDITO_PARCIAL)


        Dim consulta2 = (From n In HeliosData.documentoventaAbarrotes
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where n.idEmpresa = strEmpresa _
                         And n.estadoCobro = "PN" And list.Contains(n.tipoVenta)
                         Group c By n.idDocumento, n.tipoVenta, n.fechaPeriodo, n.fechaDoc, n.tipoDocumento,
                         n.serie, n.moneda, n.ImporteNacional, n.tipoCambio, n.nombrePedido, n.numeroDoc, n.idCliente,
                         n.ImporteExtranjero, n.estadoCobro Into g = Group
                         Select New With {
                                        .idDocumento = idDocumento,
                                        .fechaDoc = fechaDoc,
                                        .numeroDoc = serie & "-" & numeroDoc,
                                        .razonsocial = idCliente,
                                        .tiporazon = "CL",
                                        .tipoDocumento = tipoDocumento,
                                        .moneda = moneda,
                                        .tipoCambio = tipoCambio,
                                        .ImporteNacional = ImporteNacional,
                                        .ImporteExtranjero = ImporteExtranjero,
                                        .tipoVenta = tipoVenta,
                                        .SumaPagoMN = g.Sum(Function(o) o.montoSoles),
                                        .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento

            If IsNothing(i.razonsocial) Then
                doccompra.informacionReferencial = " "
                doccompra.nroDoc = ENTIDAD.nrodoc = " "
                doccompra.tipoIdentificacion = " "
            Else
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            End If
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = ((i.ImporteNacional) - (CDec((i.SumaPagoMN.GetValueOrDefault)).ToString("N2")))
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero) - (i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = ((i.ImporteExtranjero) - (i.SumaPagoME.GetValueOrDefault))
                doccompra.tipoCambio = i.tipoCambio
            End If

            doccompra.cuenta = "1213"
            doccompra.tipoAsiento = "D"

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function GetUbicar_EstadoCuenta43Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And TruncateTime(doc.fecha) >= FechaInicio.Date And TruncateTime(doc.fecha) <= FechaFin.Date _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "P" And n.cuenta.StartsWith("43") And Not n.cuenta.StartsWith("432") And Not n.cuenta.StartsWith("433")
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(strEmpresa, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                'doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function GetUbicar_EstadoCuenta43(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "P" And n.cuenta.StartsWith("43") And Not n.cuenta.StartsWith("432") And Not n.cuenta.StartsWith("433")
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                'doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function UbicarCuentasXReclamar16Anual(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim list As New List(Of String)
        Dim entidadbl As New entidadBL
        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim ENTIDAD As New entidad

        list.Add("EXD")


        Dim consulta2 = (From n In HeliosData.documentocompra
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                       On n.idDocumento Equals cajadet.documentoAfectado
                       Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where n.idEmpresa = Gempresas.IdEmpresaRuc And n.estadoPago = "PN" _
                      And list.Contains(n.tipoCompra)
                         Group c By n.idDocumento, n.tipoCompra, n.fechaContable, n.fechaDoc, n.idProveedor,
                       n.serie, n.numeroDoc, n.monedaDoc, n.importeTotal, n.tcDolLoc, n.tipoDoc,
                       n.importeUS, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fechaDoc,
                                      .numeroDoc = serie & "-" & numeroDoc,
                                      .razonsocial = idProveedor,
                                      .tiporazon = "PR",
                                      .tipoDocumento = tipoDoc,
                                      .moneda = monedaDoc,
                                      .tipoCambio = tcDolLoc,
                                      .ImporteNacional = importeTotal,
                                      .ImporteExtranjero = importeUS,
                                      .tipoCompra = tipoCompra,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            End If
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda

            If i.moneda = "1" Then
                objitemsaldoant = docanti.ObtenerPagosAnticipoPorDocumento(i.idDocumento)
                doccompra.importeMN = ((i.ImporteNacional) - (CDec((i.SumaPagoMN.GetValueOrDefault) + objitemsaldoant.MontoPagadoSoles).ToString("N2")))
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                objitemsaldoant = docanti.ObtenerPagosAnticipoPorDocumento(i.idDocumento)
                doccompra.importeMN = CDec(((i.ImporteExtranjero) - (i.SumaPagoME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD)) * i.tipoCambio).ToString("N2")
                doccompra.importeME = ((i.ImporteExtranjero) - (i.SumaPagoME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD))
                doccompra.tipoCambio = i.tipoCambio
            End If
            If i.tipoCompra = "CRH" Then
                doccompra.cuenta = "424"
            Else
                doccompra.cuenta = "4212"
            End If
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function UbicarCuentasXReclamar16Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim list As New List(Of String)
        Dim entidadbl As New entidadBL
        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim ENTIDAD As New entidad

        list.Add("EXD")


        Dim consulta2 = (From n In HeliosData.documentocompra
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                       On n.idDocumento Equals cajadet.documentoAfectado
                       Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where n.idEmpresa = strEmpresa And TruncateTime(n.fechaDoc) >= FechaInicio.Date And TruncateTime(n.fechaDoc) <= FechaFin.Date And n.estadoPago = "PN" _
                      And list.Contains(n.tipoCompra)
                         Group c By n.idDocumento, n.tipoCompra, n.fechaContable, n.fechaDoc, n.idProveedor,
                       n.serie, n.numeroDoc, n.monedaDoc, n.importeTotal, n.tcDolLoc, n.tipoDoc,
                       n.importeUS, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fechaDoc,
                                      .numeroDoc = serie & "-" & numeroDoc,
                                      .razonsocial = idProveedor,
                                      .tiporazon = "PR",
                                      .tipoDocumento = tipoDoc,
                                      .moneda = monedaDoc,
                                      .tipoCambio = tcDolLoc,
                                      .ImporteNacional = importeTotal,
                                      .ImporteExtranjero = importeUS,
                                      .tipoCompra = tipoCompra,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            End If
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda

            If i.moneda = "1" Then
                objitemsaldoant = docanti.ObtenerPagosAnticipoPorDocumento(i.idDocumento)
                doccompra.importeMN = ((i.ImporteNacional) - (CDec((i.SumaPagoMN.GetValueOrDefault) + objitemsaldoant.MontoPagadoSoles).ToString("N2")))
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                objitemsaldoant = docanti.ObtenerPagosAnticipoPorDocumento(i.idDocumento)
                doccompra.importeMN = CDec(((i.ImporteExtranjero) - (i.SumaPagoME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD)) * i.tipoCambio).ToString("N2")
                doccompra.importeME = ((i.ImporteExtranjero) - (i.SumaPagoME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD))
                doccompra.tipoCambio = i.tipoCambio
            End If
            If i.tipoCompra = "CRH" Then
                doccompra.cuenta = "424"
            Else
                doccompra.cuenta = "4212"
            End If
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function UbicarCuentasXPagarComercialesMensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim list As New List(Of String)
        Dim entidadbl As New entidadBL
        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim ENTIDAD As New entidad

        Dim consulta2 = (From c In HeliosData.documentocompra
                         Where
                 (New String() {"CVR", "CMP", "CSP", "CRH", "APT"}).Contains(c.tipoCompra) And
                  c.idEmpresa = strEmpresa _
                      And TruncateTime(c.fechaDoc) >= FechaInicio.Date _
                      And TruncateTime(c.fechaDoc) <= FechaFin.Date
                         Select
                 c.idDocumento,
                 c.tipoCompra,
                 c.fechaContable,
                 c.fechaDoc,
                 c.idProveedor,
                 c.serie,
                 c.numeroDoc,
                 c.tipoDoc,
                 c.tcDolLoc,
                 c.monedaDoc,
                 c.importeTotal,
                 c.importeUS,
                 c.estadoPago,
                 PagosMN = (CType((Aggregate t1 In
                                   (From DocumentoCajaDetalle In HeliosData.documentoCajaDetalle
                                    Join docaja In HeliosData.documentoCaja
                                   On docaja.idDocumento Equals DocumentoCajaDetalle.idDocumento
                                    Where
                                    DocumentoCajaDetalle.documentoAfectado = c.idDocumento _
                                     And TruncateTime(docaja.fechaProceso) >= FechaInicio.Date _
                                     And TruncateTime(docaja.fechaProceso) <= FechaFin.Date
                                    Select New With {
                                        DocumentoCajaDetalle.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                PagosME = (CType((Aggregate t1 In
                                  (From DocumentoCajaDetalle In HeliosData.documentoCajaDetalle
                                   Join doc In HeliosData.documentoCaja
                                   On doc.idDocumento Equals DocumentoCajaDetalle.idDocumento
                                   Where
                                   DocumentoCajaDetalle.documentoAfectado = c.idDocumento _
                                       And TruncateTime(doc.fechaProceso) >= FechaInicio.Date _
                                     And TruncateTime(doc.fechaProceso) <= FechaFin.Date
                                   Select New With {
                                       DocumentoCajaDetalle.montoUsd
                                   }) Into Sum(t1.montoUsd)), Decimal?)),
               PagoNotaCredito = (CType((Aggregate t1 In
                                         (From Documentocompra In HeliosData.documentocompra
                                          Where
                                          (New String() {"07", "87", "9901"}).Contains(Documentocompra.tipoDoc) And
                                          Documentocompra.idPadre = c.idDocumento And Documentocompra.tipoCompra <> "EXD" And
                                               TruncateTime(Documentocompra.fechaDoc) >= FechaInicio.Date _
                                             And TruncateTime(Documentocompra.fechaDoc) <= FechaFin.Date
                                          Select New With {
                                              Documentocompra.importeTotal
                                          }) Into Sum(t1.importeTotal)), Decimal?)),
                             Exedentes = (CType((Aggregate t1 In
                                          (From Documentocompra In HeliosData.documentocompra
                                           Where
                                           (New String() {"07", "87", "9901"}).Contains(Documentocompra.tipoDoc) And
                                           Documentocompra.idPadre = c.idDocumento And Documentocompra.tipoCompra = "EXD" And
                                               TruncateTime(Documentocompra.fechaDoc) >= FechaInicio.Date _
                                             And TruncateTime(Documentocompra.fechaDoc) <= FechaFin.Date
                                           Select New With {
                                               Documentocompra.importeTotal
                                           }) Into Sum(t1.importeTotal)), Decimal?)),
                      PagoNotaDebito = (CType((Aggregate t1 In
                                               (From Documentocompra In HeliosData.documentocompra
                                                Where
                                                (New String() {"08", "88"}).Contains(Documentocompra.tipoDoc) And
                                                Documentocompra.idPadre = c.idDocumento And
                                                     TruncateTime(Documentocompra.fechaDoc) >= FechaInicio.Date _
                                             And TruncateTime(Documentocompra.fechaDoc) <= FechaFin.Date
                                                Select New With {
                                                    Documentocompra.importeTotal
                                                }) Into Sum(t1.importeTotal)), Decimal?))).ToList





        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            'If i.tiporazon = "PR" Then
            ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.idProveedor)
            doccompra.informacionReferencial = ENTIDAD.nombreCompleto
            doccompra.nroDoc = ENTIDAD.nrodoc
            doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            'End If
            doccompra.numeroDoc = i.numeroDoc
            'doccompra.tipoDocumento = i.tipoDocumento
            'doccompra.FechaDoc = i.fechaDoc
            'doccompra.moneda = i.moneda
            doccompra.tipoDocumento = i.tipoDoc
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.monedaDoc

            If i.monedaDoc = "1" Then
                objitemsaldoant = docanti.ObtenerPagosAnticipoPorDocumento(i.idDocumento)
                doccompra.importeMN = ((i.importeTotal) - (CDec((i.PagosMN.GetValueOrDefault) + objitemsaldoant.MontoPagadoSoles).ToString("N2")) - (i.PagoNotaCredito.GetValueOrDefault - i.Exedentes.GetValueOrDefault) + i.PagoNotaDebito.GetValueOrDefault)
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.monedaDoc = "2" Then
                objitemsaldoant = docanti.ObtenerPagosAnticipoPorDocumento(i.idDocumento)
                'doccompra.importeMN = CDec(((i.importeUS) - (i.PagosME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD)) * i.tcDolLoc).ToString("N2")
                'doccompra.importeME = ((i.importeUS) - (i.PagosME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD))
                doccompra.importeMN = CDec(0.0)
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = i.tcDolLoc
            End If
            If i.tipoCompra = "CRH" Then
                doccompra.cuenta = "424"
            Else
                doccompra.cuenta = "4212"
            End If
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    'Public Function UbicarCuentasXPagarComercialesMensual(strEmpresa As String, intIdEstablecimiento As Integer, anioPeriodo As String, mesPeriodo As String) As List(Of documentoLibroDiarioDetalle)
    '    Dim doccompra As New documentoLibroDiarioDetalle
    '    Dim compraLista As New List(Of documentoLibroDiarioDetalle)
    '    Dim list As New List(Of String)
    '    Dim entidadbl As New entidadBL
    '    Dim docanti As New documentoAnticipoDetalleBL
    '    Dim objitemsaldoant As New documentoAnticipoDetalle
    '    Dim ENTIDAD As New entidad
    '    'list.Add(TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION)
    '    'list.Add(TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION)
    '    list.Add(TIPO_COMPRA.COMPRA)
    '    list.Add(TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO)
    '    list.Add(TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS)
    '    'list.Add(TIPO_COMPRA.COMPRA_ANTICIPADA)
    '    list.Add("APT")

    '    Dim consulta2 = (From n In HeliosData.documentocompra
    '                     Group Join cajadet In HeliosData.documentoCajaDetalle
    '                   On n.idDocumento Equals cajadet.documentoAfectado
    '                   Into ords = Group
    '                     From c In ords.DefaultIfEmpty
    '                     Where n.idEmpresa = Gempresas.IdEmpresaRuc And n.fechaDoc.Value.Year <= anioPeriodo And n.fechaDoc.Value.Month <= mesPeriodo And n.estadoPago = "PN" _
    '                  And list.Contains(n.tipoCompra)
    '                     Group c By n.idDocumento, n.tipoCompra, n.fechaContable, n.fechaDoc, n.idProveedor,
    '                   n.serie, n.numeroDoc, n.monedaDoc, n.importeTotal, n.tcDolLoc, n.tipoDoc,
    '                   n.importeUS, n.estadoPago Into g = Group
    '                     Select New With {
    '                                  .idDocumento = idDocumento,
    '                                  .fechaDoc = fechaDoc,
    '                                  .numeroDoc = serie & "-" & numeroDoc,
    '                                  .razonsocial = idProveedor,
    '                                  .tiporazon = "PR",
    '                                  .tipoDocumento = tipoDoc,
    '                                  .moneda = monedaDoc,
    '                                  .tipoCambio = tcDolLoc,
    '                                  .ImporteNacional = importeTotal,
    '                                  .ImporteExtranjero = importeUS,
    '                                  .tipoCompra = tipoCompra,
    '                                  .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
    '                                  .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList

    '    For Each i In consulta2
    '        doccompra = New documentoLibroDiarioDetalle
    '        doccompra.idDocumento = i.idDocumento
    '        If i.tiporazon = "PR" Then
    '            ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
    '            doccompra.informacionReferencial = ENTIDAD.nombreCompleto
    '            doccompra.nroDoc = ENTIDAD.nrodoc
    '            doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
    '        End If
    '        doccompra.numeroDoc = i.numeroDoc
    '        doccompra.tipoDocumento = i.tipoDocumento
    '        doccompra.FechaDoc = i.fechaDoc
    '        doccompra.moneda = i.moneda

    '        If i.moneda = "1" Then
    '            objitemsaldoant = docanti.ObtenerPagosAnticipoPorDocumento(i.idDocumento)
    '            doccompra.importeMN = ((i.ImporteNacional) - (CDec((i.SumaPagoMN.GetValueOrDefault) + objitemsaldoant.MontoPagadoSoles).ToString("N2")))
    '            doccompra.importeME = CDec(0.0)
    '            doccompra.tipoCambio = CDec(0.0)
    '        ElseIf i.moneda = "2" Then
    '            objitemsaldoant = docanti.ObtenerPagosAnticipoPorDocumento(i.idDocumento)
    '            doccompra.importeMN = CDec(((i.ImporteExtranjero) - (i.SumaPagoME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD)) * i.tipoCambio).ToString("N2")
    '            doccompra.importeME = ((i.ImporteExtranjero) - (i.SumaPagoME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD))
    '            doccompra.tipoCambio = i.tipoCambio
    '        End If
    '        If i.tipoCompra = "CRH" Then
    '            doccompra.cuenta = "424"
    '        Else
    '            doccompra.cuenta = "4212"
    '        End If
    '        compraLista.Add(doccompra)
    '    Next
    '    Return compraLista
    'End Function

    Public Function UbicarCuentasXPagarComerciales(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim list As New List(Of String)
        Dim entidadbl As New entidadBL
        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Dim ENTIDAD As New entidad
        'list.Add(TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION)
        'list.Add(TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION)
        list.Add(TIPO_COMPRA.COMPRA)
        list.Add(TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO)
        list.Add(TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS)
        'list.Add(TIPO_COMPRA.COMPRA_ANTICIPADA)
        list.Add("APT")

        Dim consulta2 = (From n In HeliosData.documentocompra
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                       On n.idDocumento Equals cajadet.documentoAfectado
                       Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where n.idEmpresa = strEmpresa And n.estadoPago = "PN" _
                      And list.Contains(n.tipoCompra)
                         Group c By n.idDocumento, n.tipoCompra, n.fechaContable, n.fechaDoc, n.idProveedor,
                       n.serie, n.numeroDoc, n.monedaDoc, n.importeTotal, n.tcDolLoc, n.tipoDoc,
                       n.importeUS, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fechaDoc,
                                      .numeroDoc = serie & "-" & numeroDoc,
                                      .razonsocial = idProveedor,
                                      .tiporazon = "PR",
                                      .tipoDocumento = tipoDoc,
                                      .moneda = monedaDoc,
                                      .tipoCambio = tcDolLoc,
                                      .ImporteNacional = importeTotal,
                                      .ImporteExtranjero = importeUS,
                                      .tipoCompra = tipoCompra,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            End If
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda

            If i.moneda = "1" Then
                objitemsaldoant = docanti.ObtenerPagosAnticipoPorDocumento(i.idDocumento)
                doccompra.importeMN = ((i.ImporteNacional) - (CDec((i.SumaPagoMN.GetValueOrDefault) + objitemsaldoant.MontoPagadoSoles).ToString("N2")))
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                objitemsaldoant = docanti.ObtenerPagosAnticipoPorDocumento(i.idDocumento)
                doccompra.importeMN = CDec(((i.ImporteExtranjero) - (i.SumaPagoME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD)) * i.tipoCambio).ToString("N2")
                doccompra.importeME = ((i.ImporteExtranjero) - (i.SumaPagoME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD))
                doccompra.tipoCambio = i.tipoCambio
            End If
            If i.tipoCompra = "CRH" Then
                doccompra.cuenta = "424"
            Else
                doccompra.cuenta = "4212"
            End If
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function



    Public Function GetListaEstadoCuenta42Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim obj As New documentoLibroDiarioDetalle
        Dim query = (UbicarCuentasXPagarComercialesMensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin).Union(GetUbicar_EstadoCuenta42Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin))).ToList
        Dim Lista As New List(Of documentoLibroDiarioDetalle)

        For Each i In query.ToList
            obj = New documentoLibroDiarioDetalle

            obj.idDocumento = i.idDocumento
            obj.informacionReferencial = i.informacionReferencial
            obj.nroDoc = i.nroDoc
            obj.tipoIdentificacion = i.tipoIdentificacion
            obj.numeroDoc = i.numeroDoc
            obj.tipoDocumento = i.tipoDocumento
            obj.FechaDoc = i.FechaDoc
            obj.moneda = i.moneda
            obj.importeMN = i.importeMN
            obj.importeME = i.importeME
            obj.tipoCambio = i.tipoCambio
            obj.cuenta = i.cuenta


            Lista.Add(obj)
        Next
        Return Lista
    End Function
    'Public Function GetListaEstadoCuenta42Mensual(strEmpresa As String, intIdEstablecimiento As Integer, anioPeriodo As String, mesPeriodo As String) As List(Of documentoLibroDiarioDetalle)
    '    Dim obj As New documentoLibroDiarioDetalle
    '    Dim query = (UbicarCuentasXPagarComercialesMensual(strEmpresa, intIdEstablecimiento, anioPeriodo, mesPeriodo).Union(GetUbicar_EstadoCuenta42Mensual(strEmpresa, intIdEstablecimiento, anioPeriodo, mesPeriodo))).ToList
    '    Dim Lista As New List(Of documentoLibroDiarioDetalle)

    '    For Each i In query.ToList
    '        obj = New documentoLibroDiarioDetalle

    '        obj.idDocumento = i.idDocumento
    '        obj.informacionReferencial = i.informacionReferencial
    '        obj.nroDoc = i.nroDoc
    '        obj.tipoIdentificacion = i.tipoIdentificacion
    '        obj.numeroDoc = i.numeroDoc
    '        obj.tipoDocumento = i.tipoDocumento
    '        obj.FechaDoc = i.FechaDoc
    '        obj.moneda = i.moneda
    '        obj.importeMN = i.importeMN
    '        obj.importeME = i.importeME
    '        obj.tipoCambio = i.tipoCambio
    '        obj.cuenta = i.cuenta


    '        Lista.Add(obj)
    '    Next
    '    Return Lista
    'End Function

    Public Function GetListaEstadoCuenta42(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim obj As New documentoLibroDiarioDetalle
        Dim query = (UbicarCuentasXPagarComerciales(strEmpresa, intIdEstablecimiento).Union(GetUbicar_EstadoCuenta42(strEmpresa, intIdEstablecimiento))).ToList
        Dim Lista As New List(Of documentoLibroDiarioDetalle)

        For Each i In query.ToList
            obj = New documentoLibroDiarioDetalle

            obj.idDocumento = i.idDocumento
            obj.informacionReferencial = i.informacionReferencial
            obj.nroDoc = i.nroDoc
            obj.tipoIdentificacion = i.tipoIdentificacion
            obj.numeroDoc = i.numeroDoc
            obj.tipoDocumento = i.tipoDocumento
            obj.FechaDoc = i.FechaDoc
            obj.moneda = i.moneda
            obj.importeMN = i.importeMN
            obj.importeME = i.importeME
            obj.tipoCambio = i.tipoCambio
            obj.cuenta = i.cuenta


            Lista.Add(obj)
        Next
        Return Lista
    End Function

    Public Function GetUbicar_EstadoCuenta42Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, fechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And TruncateTime(doc.fecha) >= FechaInicio.Date And TruncateTime(doc.fecha) <= fechaFin.Date And doc.tipoRegistro = "NM" And n.tipoPago = "P" And n.cuenta.StartsWith("42") And Not n.cuenta.StartsWith("422") And Not n.cuenta.StartsWith("423")
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(strEmpresa, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                'doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function GetUbicar_EstadoCuenta42(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "P" And n.cuenta.StartsWith("42") And Not n.cuenta.StartsWith("422") And Not n.cuenta.StartsWith("423")
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                'doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function GetUbicar_EstadoCuenta41Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And TruncateTime(doc.fecha) >= FechaInicio.Date And TruncateTime(doc.fecha) <= FechaFin.Date _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "P" And n.cuenta.StartsWith("41")
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(strEmpresa, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(strEmpresa, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function GetUbicar_EstadoCuenta41(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim PERSONA As New Persona
        Dim ENTIDAD As New entidad


        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle
                         Join doc In HeliosData.documentoLibroDiario
                         On doc.idDocumento Equals n.idDocumento
                         Group Join cajadet In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where doc.idEmpresa = strEmpresa And doc.fecha.Value.Year = AnioGeneral _
                          And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "P" And n.cuenta.StartsWith("41")
                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.tipoCambio,
                                doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                                 n.importeME, n.estadoPago Into g = Group
                         Select New With {
                                      .idDocumento = idDocumento,
                                      .fechaDoc = fecha,
                                      .numeroDoc = nroDoc,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .tipoCambio = tipoCambio,
                                      .ImporteNacional = importeMN,
                                      .ImporteExtranjero = importeME,
                                      .cuenta = cuenta,
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            If i.tiporazon = "PR" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "CL" Then
                ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
                doccompra.informacionReferencial = ENTIDAD.nombreCompleto
                doccompra.nroDoc = ENTIDAD.nrodoc
                doccompra.tipoIdentificacion = ENTIDAD.tipoDoc
            ElseIf i.tiporazon = "TR" Then
                PERSONA = personabl.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonsocial, "TR")
                doccompra.informacionReferencial = PERSONA.nombreCompleto
                doccompra.nroDoc = PERSONA.idPersona
                doccompra.tipoIdentificacion = PERSONA.tipodoc
            End If

            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.FechaDoc = i.fechaDoc
            doccompra.moneda = i.moneda
            If i.moneda = "1" Then
                doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
                doccompra.importeME = CDec(0.0)
                doccompra.tipoCambio = CDec(0.0)
            ElseIf i.moneda = "2" Then
                doccompra.importeMN = CDec((i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault) * i.tipoCambio).ToString("N2")
                doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")
                doccompra.tipoCambio = i.tipoCambio
            End If
            doccompra.cuenta = i.cuenta
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    'Public Function GetUbicar_EstadoCuenta41(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
    '    Dim doccompra As New documentoLibroDiarioDetalle
    '    Dim compraLista As New List(Of documentoLibroDiarioDetalle)

    '    Dim docanti As New documentoAnticipoDetalleBL
    '    Dim objitemsaldoant As New documentoAnticipoDetalle

    '    Dim entidadbl As New entidadBL
    '    Dim personabl As New PersonaBL
    '    Dim PERSONA As New Persona
    '    Dim ENTIDAD As New entidad


    '    Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle _
    '                     Join doc In HeliosData.documentoLibroDiario _
    '                     On doc.idDocumento Equals n.idDocumento _
    '                     Group Join cajadet In HeliosData.documentoCajaDetalle _
    '                     On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle _
    '                     Into ords = Group _
    '                      From c In ords.DefaultIfEmpty _
    '                     Where doc.idEmpresa = strEmpresa And doc.idEstablecimiento = intIdEstablecimiento And doc.fecha.Value.Year = AnioGeneral And doc.moneda = "1" _
    '                      And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "P" And n.cuenta.StartsWith("41") _
    '                         Group c By n.idDocumento, n.secuencia, doc.fecha, doc.fechaVct,
    '                   doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.tipoCambio, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
    '                   n.importeME, n.estadoPago Into g = Group _
    '                   Select New With {
    '                                  .idDocumento = idDocumento,
    '                                  .razonsocial = razonSocial,
    '                                  .tiporazon = tipoRazonSocial,
    '                                  .secuencia = secuencia,
    '                                  .descripcion = descripcion,
    '                                  .cuenta = cuenta,
    '                                  .fechaPeriodo = fechaPeriodo,
    '                                  .fechaDoc = fecha,
    '                                  .fechaVcto = fechaVct,
    '                                  .numeroDoc = nroDoc,
    '                                  .tipoDocumento = tipoDoc,
    '                                  .moneda = moneda,
    '                                  .ImporteNacional = importeMN,
    '                                  .tipoCambio = tipoCambio,
    '                                  .ImporteExtranjero = importeME,
    '                                  .estadoCobro = estadoPago,
    '                                  .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
    '                                  .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


    '    For Each i In consulta2
    '        doccompra = New documentoLibroDiarioDetalle
    '        doccompra.idDocumento = i.idDocumento
    '        doccompra.secuencia = i.secuencia
    '        If i.tiporazon = "PR" Then
    '            ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "PR", i.razonsocial)
    '            doccompra.informacionReferencial = ENTIDAD.nombreCompleto
    '            doccompra.razonSocial = ENTIDAD.nrodoc
    '        ElseIf i.tiporazon = "CL" Then
    '            ENTIDAD = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, "CL", i.razonsocial)
    '            doccompra.informacionReferencial = ENTIDAD.nombreCompleto
    '            doccompra.razonSocial = ENTIDAD.nrodoc
    '        ElseIf i.tiporazon = "TR" Then
    '            PERSONA = personabl.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonsocial, "TR")
    '            doccompra.informacionReferencial = PERSONA.nombreCompleto
    '            doccompra.razonSocial = PERSONA.idPersona
    '        End If

    '        doccompra.descripcion = i.descripcion
    '        doccompra.cuenta = i.cuenta
    '        doccompra.numeroDoc = i.numeroDoc
    '        doccompra.tipoDocumento = i.tipoDocumento
    '        doccompra.FechaDoc = i.fechaDoc
    '        doccompra.importeMN = CDec(i.ImporteNacional - (i.SumaPagoMN.GetValueOrDefault)).ToString("N2")
    '        doccompra.importeME = CDec(i.ImporteExtranjero - i.SumaPagoME.GetValueOrDefault).ToString("N2")

    '        compraLista.Add(doccompra)
    '    Next
    '    Return compraLista
    'End Function


    'Public Function GetUbicar_EstadoCuenta41() As List(Of documentoLibroDiarioDetalle)

    '    Dim lista As New List(Of documentoLibroDiarioDetalle)
    '    Dim det As New documentoLibroDiarioDetalle


    '    Dim consulta = (From a In HeliosData.documentoLibroDiarioDetalle
    '                    Join doc In HeliosData.documentoLibroDiario _
    '                   On a.idDocumento Equals doc.idDocumento _
    '             Where a.estadoPago = "PN" And a.cuenta.StartsWith("41")).ToList
    '    For Each i In consulta
    '        det = New documentoLibroDiarioDetalle

    '        det.idDocumento = i.doc.idDocumento
    '        det.ididentificacion = i.doc.razonSocial
    '        det.tipoDocumento = i.doc.tipoDoc
    '        det.nroDoc = i.doc.nroDoc

    '        det.cuenta = i.a.cuenta
    '        det.descripcion = i.a.descripcion
    '        det.tipoAsiento = i.a.tipoAsiento
    '        det.importeMN = i.a.importeMN
    '        det.importeME = i.a.importeME
    '        det.tipoPago = i.a.tipoPago


    '        lista.Add(det)

    '    Next


    '    Return lista
    'End Function


    Public Function GetUbicar_documentoModuloDetalle(intIdDocumento As Integer) As List(Of documentoLibroDiarioDetalle)

        Dim lista As New List(Of documentoLibroDiarioDetalle)
        Dim det As New documentoLibroDiarioDetalle


        Dim consulta = (From a In HeliosData.documentoLibroDiarioDetalle
                 Where a.idDocumento = intIdDocumento Select a).ToList
        For Each i In consulta
            det = New documentoLibroDiarioDetalle

            det.idDocumento = i.idDocumento

            det.secuencia = i.secuencia
            det.cuenta = i.cuenta
            det.descripcion = i.descripcion
            det.tipoAsiento = i.tipoAsiento

            det.importeMN = i.importeMN
            det.importeME = i.importeME
            det.descripcion = i.descripcion
            det.cuenta = i.cuenta

            det.tipoPago = i.tipoPago


            lista.Add(det)

        Next


        Return lista
    End Function


    Public Function Insert(ByVal documentoLibroDiarioDetalleBE As documentoLibroDiarioDetalle) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoLibroDiarioDetalle.Add(documentoLibroDiarioDetalleBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoLibroDiarioDetalleBE.Secuencia
        End Using
    End Function

    Public Sub Update(ByVal documentoLibroDiarioDetalleBE As documentoLibroDiarioDetalle)
        Using ts As New TransactionScope
            Dim docLibroDiarioDetalle As documentoLibroDiarioDetalle = HeliosData.documentoLibroDiarioDetalle.Where(Function(o) _
                                            o.idDocumento = documentoLibroDiarioDetalleBE.idDocumento _
                                            And o.secuencia = documentoLibroDiarioDetalleBE.secuencia).First()

            docLibroDiarioDetalle.cuenta = documentoLibroDiarioDetalleBE.cuenta
            docLibroDiarioDetalle.idItem = documentoLibroDiarioDetalleBE.idItem
            docLibroDiarioDetalle.descripcion = documentoLibroDiarioDetalleBE.descripcion
            docLibroDiarioDetalle.tipoAsiento = documentoLibroDiarioDetalleBE.tipoAsiento
            docLibroDiarioDetalle.importeMN = documentoLibroDiarioDetalleBE.importeMN
            docLibroDiarioDetalle.importeME = documentoLibroDiarioDetalleBE.importeME
            docLibroDiarioDetalle.Evento = documentoLibroDiarioDetalleBE.Evento
            docLibroDiarioDetalle.idEvento = documentoLibroDiarioDetalleBE.idEvento
            docLibroDiarioDetalle.cuentaPadre = documentoLibroDiarioDetalleBE.cuentaPadre
            docLibroDiarioDetalle.idEstablecimiento = documentoLibroDiarioDetalleBE.idEstablecimiento
            docLibroDiarioDetalle.entregadoCancelado = documentoLibroDiarioDetalleBE.entregadoCancelado
            docLibroDiarioDetalle.usuarioActualizacion = documentoLibroDiarioDetalleBE.usuarioActualizacion
            docLibroDiarioDetalle.fechaActualizacion = documentoLibroDiarioDetalleBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docLibroDiarioDetalle).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoLibroDiarioDetalleBE As documentoLibroDiarioDetalle)
        Using ts As New TransactionScope
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoLibroDiarioDetalleBE)
            'CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetListar_documentoLibroDiarioDetalle() As List(Of documentoLibroDiarioDetalle)
        Return (From a In HeliosData.documentoLibroDiarioDetalle Select a).ToList
    End Function

    Public Function GetUbicar_documentoLibroDiarioDetallePorID(Secuencia As Integer) As documentoLibroDiarioDetalle
        Return (From a In HeliosData.documentoLibroDiarioDetalle
                 Where a.secuencia = Secuencia Select a).First
    End Function

    Public Function GetUbicar_documentoLibroDiarioDetallePorIDDocumento(idDoc As Integer) As List(Of documentoLibroDiarioDetalle)
        Return (From a In HeliosData.documentoLibroDiarioDetalle
                 Where a.idDocumento = idDoc).ToList
    End Function
End Class
