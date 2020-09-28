Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class documentoPedidoBL
    Inherits BaseBL

    'Public Sub updatePedidoXPreventa(listaId As List(Of Integer), i As documentoPedido)
    '    Try
    '        Dim documentoPedidoDetBL As New documentoPedidoDetBL

    '        Using ts As New TransactionScope

    '            For Each item In listaId
    '                Dim obj = (From n In HeliosData.documentoPedido
    '                           Where n.idEmpresa = i.idEmpresa And
    '                               n.estado = i.estado And
    '                               n.idInfraestructura = i.idInfraestructura And
    '                               n.idDocumento = item).FirstOrDefault
    '                If (Not IsNothing(obj)) Then
    '                    obj.tipoVenta = i.tipoVenta
    '                    HeliosData.SaveChanges()

    '                End If

    '            Next

    '            documentoPedidoDetBL.EditarListaEstadoPreVenta(i)

    '            ts.Complete()

    '        End Using
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub


    'Public Sub updatePedidoXConfirmacionCaja(listaId As List(Of Integer), i As documentoPedido)
    '    Try
    '        Using ts As New TransactionScope

    '            For Each item In listaId
    '                Dim obj = (From n In HeliosData.documentoPedido
    '                           Where n.idEmpresa = i.idEmpresa And
    '                                                                n.idInfraestructura = i.idInfraestructura And
    '                               n.idDocumento = item).FirstOrDefault
    '                If (Not IsNothing(obj)) Then
    '                    obj.estadoCobro = i.estadoCobro
    '                    obj.estadoEntrega = i.estadoEntrega
    '                    HeliosData.SaveChanges()

    '                End If



    '            Next

    '            ts.Complete()

    '        End Using
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub

    'Public Function GrabarPedido(objDocumento As documento) As Integer
    '    Dim DocumentoBL As New documentoBL
    '    Dim numeracionBL As New numeracionBoletasBL
    '    Dim PedidoDetBL As New documentoPedidoDetBL

    '    Try
    '        Using ts As New TransactionScope()
    '            objDocumento.fechaActualizacion = DateTime.Now
    '            Dim cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(objDocumento.documentoPedido.IdNumeracion))
    '            objDocumento.nroDoc = objDocumento.documentoPedido.serie & "-" & cval
    '            DocumentoBL.Insert(objDocumento)
    '            objDocumento.documentoPedido.numeroDoc = cval
    '            Me.InsertSingle(objDocumento.documentoPedido, objDocumento.idDocumento)
    '            For Each i In objDocumento.documentoPedido.documentoPedidoDet
    '                PedidoDetBL.InsertSingle(i, objDocumento.idDocumento)
    '            Next
    '            HeliosData.SaveChanges()
    '            ts.Complete()
    '            Return objDocumento.idDocumento
    '        End Using
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Public Sub InsertSingle(ByVal documentoventaAbarrotesBE As documentoPedido, intIdDocmento As Integer)
    '    Dim docPedido As New documentoPedido
    '    'Dim numeracionBL As New numeracionBoletasBL
    '    'Dim cval As Integer = 0
    '    Using ts As New TransactionScope
    '        docPedido.idDocumento = intIdDocmento
    '        docPedido.codigoLibro = documentoventaAbarrotesBE.codigoLibro
    '        docPedido.tipoOperacion = documentoventaAbarrotesBE.tipoOperacion
    '        docPedido.fechaVcto = documentoventaAbarrotesBE.fechaVcto
    '        docPedido.idEmpresa = documentoventaAbarrotesBE.idEmpresa
    '        docPedido.idEstablecimiento = documentoventaAbarrotesBE.idEstablecimiento
    '        docPedido.tipoDocumento = documentoventaAbarrotesBE.tipoDocumento
    '        docPedido.fechaDoc = documentoventaAbarrotesBE.fechaDoc
    '        docPedido.horaVenta = documentoventaAbarrotesBE.horaVenta
    '        docPedido.fechaConfirmacion = documentoventaAbarrotesBE.fechaConfirmacion
    '        docPedido.fechaPeriodo = documentoventaAbarrotesBE.fechaPeriodo
    '        docPedido.serie = documentoventaAbarrotesBE.serie
    '        '  cval = Convert.ToInt32(objSystemaCodeEO.UPDATEConteo(Me.IdEmpresa, Me.IdEstablecimiento, Me.DocumentoSerie, Me.Serie))
    '        ' If documentoventaAbarrotesBE.serie = "0001" Then
    '        'cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(documentoventaAbarrotesBE.IdNumeracion))
    '        'ElseIf Me.Serie = "0002" Then
    '        'cval = Convert.ToInt32(objSystemaCodeEO.UPDATEConteo(Me.IdEmpresa, Me.IdEstablecimiento, "FAC", "0002"))
    '        'End If
    '        docPedido.numeroDoc = documentoventaAbarrotesBE.numeroDoc
    '        docPedido.numeroDocNormal = documentoventaAbarrotesBE.numeroDocNormal
    '        docPedido.idClientePedido = documentoventaAbarrotesBE.idClientePedido
    '        docPedido.nombrePedido = documentoventaAbarrotesBE.nombrePedido
    '        docPedido.idCliente = documentoventaAbarrotesBE.idCliente
    '        docPedido.moneda = documentoventaAbarrotesBE.moneda
    '        docPedido.tipoCambio = documentoventaAbarrotesBE.tipoCambio
    '        docPedido.tasaIgv = documentoventaAbarrotesBE.tasaIgv
    '        docPedido.bi01 = documentoventaAbarrotesBE.bi01
    '        docPedido.bi02 = documentoventaAbarrotesBE.bi02
    '        docPedido.isc01 = documentoventaAbarrotesBE.isc01
    '        docPedido.isc02 = documentoventaAbarrotesBE.isc02
    '        docPedido.igv01 = documentoventaAbarrotesBE.igv01
    '        docPedido.igv02 = documentoventaAbarrotesBE.igv02
    '        docPedido.otc01 = documentoventaAbarrotesBE.otc01
    '        docPedido.otc02 = documentoventaAbarrotesBE.otc02
    '        docPedido.bi01us = documentoventaAbarrotesBE.bi01us
    '        docPedido.bi02us = documentoventaAbarrotesBE.bi02us
    '        docPedido.isc01us = documentoventaAbarrotesBE.isc01us
    '        docPedido.isc02us = documentoventaAbarrotesBE.isc02us
    '        docPedido.igv01us = documentoventaAbarrotesBE.igv01us
    '        docPedido.igv02us = documentoventaAbarrotesBE.igv02us
    '        docPedido.otc01us = documentoventaAbarrotesBE.otc01us
    '        docPedido.otc02us = documentoventaAbarrotesBE.otc02us
    '        docPedido.ImporteNacional = documentoventaAbarrotesBE.ImporteNacional
    '        docPedido.ImporteExtranjero = documentoventaAbarrotesBE.ImporteExtranjero
    '        docPedido.importeCostoMN = documentoventaAbarrotesBE.importeCostoMN
    '        docPedido.importeCostoME = documentoventaAbarrotesBE.importeCostoME
    '        docPedido.estadoCobro = documentoventaAbarrotesBE.estadoCobro
    '        docPedido.estado = documentoventaAbarrotesBE.estado
    '        docPedido.establecimientoCobro = documentoventaAbarrotesBE.establecimientoCobro
    '        docPedido.entidadFinanciera = documentoventaAbarrotesBE.entidadFinanciera
    '        docPedido.glosa = documentoventaAbarrotesBE.glosa
    '        docPedido.terminos = documentoventaAbarrotesBE.terminos
    '        docPedido.notaCredito = documentoventaAbarrotesBE.notaCredito
    '        docPedido.tipoVenta = documentoventaAbarrotesBE.tipoVenta
    '        docPedido.modulo = documentoventaAbarrotesBE.modulo
    '        docPedido.idPadre = documentoventaAbarrotesBE.idPadre
    '        docPedido.estadoEntrega = documentoventaAbarrotesBE.estadoEntrega
    '        docPedido.idInfraestructura = documentoventaAbarrotesBE.idInfraestructura
    '        docPedido.usuarioActualizacion = documentoventaAbarrotesBE.usuarioActualizacion
    '        docPedido.fechaActualizacion = documentoventaAbarrotesBE.fechaActualizacion

    '        HeliosData.documentoPedido.Add(docPedido)
    '        HeliosData.SaveChanges()
    '        ts.Complete()
    '        documentoventaAbarrotesBE.idDocumento = docPedido.idDocumento
    '        documentoventaAbarrotesBE.numeroDoc = docPedido.numeroDoc
    '    End Using
    'End Sub

    'Public Function GetListarAllPedidoXMesaPeriodo(intIdEstablec As Integer, strPeriodo As String, idInfraestructura As Integer) As List(Of documentoPedido)
    '    Dim entidadembresiaBL As New Entidadmembresia_GymBL
    '    Dim Lista As New List(Of documentoPedido)
    '    Dim ListaTipo As New List(Of String)

    '    ListaTipo.Add(TIPO_VENTA.VENTA_NOTA_PEDIDO)
    '    'ListaTipo.Add(TIPO_VENTA.VENTA_HEREDAD)
    '    'ListaTipo.Add(TIPO_VENTA.VENTA_POS_DIRECTA)
    '    'ListaTipo.Add(TIPO_VENTA.VENTA_ANTICIPADA_OTORGADO)
    '    ''ListaTipo.Add(TIPO_VENTA.VENTA_NORMAL_CONTADO)
    '    ''ListaTipo.Add(TIPO_VENTA.VENTA_NORMAL_CREDITO)
    '    ''ListaTipo.Add(TIPO_VENTA.VENTA_NORMAL_SERVICIO)
    '    ''ListaTipo.Add(TIPO_VENTA.VENTA_NORMAL_SERVICIO_CREDITO)
    '    'ListaTipo.Add(TIPO_VENTA.VENTA_AL_TICKET)
    '    'ListaTipo.Add(TIPO_COMPRA.NOTA_CREDITO)
    '    'ListaTipo.Add(TIPO_COMPRA.NOTA_DEBITO)
    '    'ListaTipo.Add(TIPO_VENTA.VENTA_ELECTRONICA)
    '    'ListaTipo.Add(TIPO_COMPRA.NOTA_CREDITO_ELECTRONICA)

    '    Dim objRecurso As New documentoPedido
    '    Dim consultaVentas = (From doc In HeliosData.documento
    '                          Join compra In HeliosData.documentoPedido
    '                   On doc.idDocumento Equals compra.idDocumento
    '                          Group Join entidad In HeliosData.entidad
    '                   On compra.idCliente Equals entidad.idEntidad
    '                   Into ords = Group
    '                          From e In ords.DefaultIfEmpty
    '                          Where doc.idCentroCosto = intIdEstablec And
    '                   compra.fechaPeriodo = strPeriodo And ListaTipo.Contains(compra.tipoVenta) _
    '                   And compra.estadoCobro <> "ANU" And
    '                              compra.idInfraestructura = idInfraestructura
    '                          Order By compra.fechaDoc Ascending).ToList

    '    For Each obj In consultaVentas
    '        objRecurso = New documentoPedido

    '        objRecurso.idDocumento = obj.compra.idDocumento
    '        objRecurso.tipoOperacion = obj.doc.tipoOperacion
    '        objRecurso.fechaDoc = obj.compra.fechaDoc
    '        objRecurso.tipoDocumento = obj.compra.tipoDocumento
    '        objRecurso.serie = obj.compra.serie
    '        objRecurso.serieVenta = obj.compra.serieVenta
    '        objRecurso.numeroDoc = obj.compra.numeroDoc
    '        objRecurso.numeroVenta = obj.compra.numeroVenta
    '        objRecurso.numeroDocNormal = obj.compra.numeroDocNormal
    '        objRecurso.nombrePedido = obj.compra.nombrePedido
    '        If Not IsNothing(obj.e) Then
    '            objRecurso.tipoDocEntidad = obj.e.tipoDoc
    '            objRecurso.NroDocEntidad = obj.e.nrodoc
    '            objRecurso.NombreEntidad = obj.e.nombreCompleto
    '            objRecurso.TipoPersona = obj.e.tipoPersona
    '        Else
    '            objRecurso.tipoDocEntidad = String.Empty
    '            objRecurso.NroDocEntidad = String.Empty
    '            objRecurso.NombreEntidad = String.Empty
    '            objRecurso.TipoPersona = String.Empty
    '        End If
    '        Select Case obj.compra.tipoDocumento
    '            Case "07"
    '                objRecurso.ImporteNacional = obj.compra.ImporteNacional * -1
    '                objRecurso.ImporteExtranjero = obj.compra.ImporteExtranjero * -1
    '            Case "08"
    '                objRecurso.ImporteNacional = obj.compra.ImporteNacional
    '                objRecurso.ImporteExtranjero = obj.compra.ImporteExtranjero
    '            Case Else
    '                objRecurso.ImporteNacional = obj.compra.ImporteNacional
    '                objRecurso.ImporteExtranjero = obj.compra.ImporteExtranjero
    '        End Select

    '        objRecurso.tipoCambio = obj.compra.tipoCambio
    '        objRecurso.moneda = obj.compra.moneda
    '        objRecurso.estadoCobro = obj.compra.estadoCobro
    '        objRecurso.tipoVenta = obj.compra.tipoVenta
    '        objRecurso.notaCredito = obj.compra.notaCredito
    '        objRecurso.usuarioActualizacion = obj.compra.usuarioActualizacion
    '        objRecurso.estadoEntrega = obj.compra.estadoEntrega
    '        objRecurso.idPadre = obj.compra.idPadre
    '        objRecurso.EnvioSunat = obj.compra.EnvioSunat
    '        Lista.Add(objRecurso)
    '    Next

    '    '.idEmpresa = Gempresas.IdEmpresaRuc,
    '    Dim consultaMembresia = entidadembresiaBL.GetRegistroMembresiasByPeriodo(New Entidadmembresia_Gym With {
    '                                                                             .idEstablecimiento = intIdEstablec,
    '                                                                             .periodo = strPeriodo})

    '    For Each i In consultaMembresia
    '        objRecurso = New documentoPedido

    '        objRecurso.idDocumento = i.idDocumento
    '        objRecurso.tipoOperacion = StatusTipoOperacion.VENTA
    '        objRecurso.fechaDoc = i.fechaRegistro
    '        objRecurso.tipoDocumento = i.tipodoc
    '        objRecurso.serie = i.serie
    '        objRecurso.serieVenta = i.serie
    '        objRecurso.numeroDoc = i.numero
    '        objRecurso.numeroVenta = i.numero
    '        objRecurso.numeroDocNormal = i.numero
    '        objRecurso.nombrePedido = "-"
    '        objRecurso.tipoDocEntidad = i.CustomEntidad.tipoDoc
    '        objRecurso.NroDocEntidad = i.CustomEntidad.nrodoc
    '        objRecurso.NombreEntidad = i.CustomEntidad.nombreCompleto
    '        objRecurso.TipoPersona = "Socio"
    '        objRecurso.ImporteNacional = i.importe
    '        objRecurso.ImporteExtranjero = 0
    '        objRecurso.tipoCambio = 1
    '        objRecurso.moneda = "NAC"
    '        objRecurso.estadoCobro = i.statusPago
    '        objRecurso.tipoVenta = TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
    '        objRecurso.notaCredito = 0
    '        objRecurso.usuarioActualizacion = "" ' i.usuarioActualizacion
    '        objRecurso.estadoEntrega = "E"
    '        Lista.Add(objRecurso)
    '    Next

    '    Return Lista
    'End Function

    'Public Function GetListarAllPedidosPeriodoPendiente(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoPedido)
    '    Dim Lista As New List(Of documentoPedido)
    '    Dim ListaTipo As New List(Of String)

    '    ListaTipo.Add(TIPO_VENTA.VENTA_GENERAL)
    '    ListaTipo.Add(TIPO_VENTA.VENTA_POS_DIRECTA)
    '    'ListaTipo.Add(TIPO_VENTA.VENTA_ANTICIPADA)
    '    ListaTipo.Add(TIPO_VENTA.VENTA_ANTICIPADA_OTORGADO)
    '    ListaTipo.Add(TIPO_VENTA.VENTA_ANTICIPADA_RECIBIDO)
    '    'ListaTipo.Add(TIPO_VENTA.VENTA_NORMAL_CONTADO)
    '    'ListaTipo.Add(TIPO_VENTA.VENTA_NORMAL_CREDITO)
    '    'ListaTipo.Add(TIPO_VENTA.VENTA_NORMAL_SERVICIO)
    '    'ListaTipo.Add(TIPO_VENTA.VENTA_NORMAL_SERVICIO_CREDITO)
    '    ListaTipo.Add(TIPO_VENTA.VENTA_AL_TICKET)
    '    ListaTipo.Add(TIPO_COMPRA.NOTA_CREDITO)
    '    ListaTipo.Add(TIPO_COMPRA.NOTA_DEBITO)

    '    Dim objRecurso As New documentoPedido
    '    Dim consulta = (From doc In HeliosData.documento
    '                    Join compra In HeliosData.documentoPedido
    '                   On doc.idDocumento Equals compra.idDocumento
    '                    Join infra In HeliosData.infraestructura
    '                      On compra.idInfraestructura Equals infra.idInfraestructura
    '                    Where doc.idCentroCosto = intIdEstablec And
    '                   compra.fechaPeriodo = strPeriodo And (compra.tipoVenta) = "VNP" _
    '                   And compra.estadoCobro = "PN"
    '                    Order By compra.fechaDoc Ascending).ToList

    '    For Each obj In consulta
    '        objRecurso = New documentoPedido

    '        objRecurso.idDocumento = obj.compra.idDocumento
    '        objRecurso.tipoOperacion = obj.doc.tipoOperacion
    '        objRecurso.fechaDoc = obj.compra.fechaDoc
    '        objRecurso.tipoDocumento = obj.compra.tipoDocumento
    '        objRecurso.serie = obj.compra.serie
    '        objRecurso.numeroDoc = obj.compra.numeroDoc
    '        objRecurso.numeroDocNormal = obj.compra.numeroDocNormal
    '        objRecurso.nombrePedido = obj.compra.nombrePedido
    '        'If Not IsNothing(obj.e) Then
    '        '    objRecurso.idCliente = obj.e.idEntidad
    '        '    objRecurso.tipoDocEntidad = obj.e.tipoDoc
    '        '    objRecurso.NroDocEntidad = obj.e.nrodoc
    '        '    objRecurso.NombreEntidad = obj.e.nombreCompleto
    '        '    objRecurso.TipoPersona = obj.e.tipoPersona
    '        'Else
    '        objRecurso.idCliente = 0
    '            objRecurso.tipoDocEntidad = String.Empty
    '            objRecurso.NroDocEntidad = String.Empty
    '            objRecurso.NombreEntidad = String.Empty
    '            objRecurso.TipoPersona = String.Empty
    '        'End If

    '        objRecurso.ImporteNacional = obj.compra.ImporteNacional
    '        objRecurso.tipoCambio = obj.compra.tipoCambio
    '        objRecurso.ImporteExtranjero = obj.compra.ImporteExtranjero
    '        objRecurso.moneda = obj.compra.moneda
    '        objRecurso.estadoCobro = obj.compra.estadoCobro
    '        objRecurso.tipoVenta = obj.compra.tipoVenta
    '        objRecurso.notaCredito = obj.compra.notaCredito
    '        objRecurso.usuarioActualizacion = obj.compra.usuarioActualizacion
    '        objRecurso.estadoEntrega = obj.compra.estadoEntrega
    '        objRecurso.idInfraestructura = obj.compra.idInfraestructura
    '        objRecurso.nombreInfra = obj.infra.nombre
    '        Lista.Add(objRecurso)
    '    Next

    '    Return Lista
    'End Function

    'Public Function GetUbicar_documentoPedidoPorID(idDocumento As Integer) As documentoPedido
    '    Return (From a In HeliosData.documentoPedido
    '            Where a.idDocumento = idDocumento Select a).FirstOrDefault
    'End Function

    'Public Function GetUbicar_documentoPedidoPorIDInfraestructura(documentoPedidoBE As documentoPedido) As List(Of documentoPedido)
    '    Return (From a In HeliosData.documentoPedido
    '            Where a.idInfraestructura = documentoPedidoBE.idInfraestructura And a.idEmpresa = documentoPedidoBE.idEmpresa Select a).ToList
    'End Function

    'Public Function GrabarCambioInfraestructura(i As documentoPedido) As Integer
    '    Try
    '        Using ts As New TransactionScope
    '            Dim obj = (From n In HeliosData.documentoPedido
    '                       Where n.idInfraestructura = i.pedidoOrigen And n.idEmpresa = i.idEmpresa And
    '                           i.estado = i.estado).FirstOrDefault


    '            obj.idInfraestructura = i.pedidoDestino


    '            'HeliosData.infraestructura.Add(obj)
    '            HeliosData.SaveChanges()
    '            ts.Complete()

    '            Return True
    '        End Using
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    'Public Function DeletePedidoXInfraestructura(documentoPedido As documentoPedido) As Integer
    '    Dim docuemntoBE As New documento
    '    Dim documentoBL As New documentoBL
    '    Using ts As New TransactionScope

    '        Dim consulta = HeliosData.documentoPedido.Where(Function(o) o.idInfraestructura = documentoPedido.idInfraestructura And
    '                                                            o.idEmpresa = documentoPedido.idEmpresa).ToList

    '        If (consulta.Count > 0) Then
    '            For Each obj In consulta
    '                docuemntoBE.idDocumento = obj.idDocumento
    '                Exit For
    '            Next
    '            documentoBL.DeleteSingle(docuemntoBE)
    '        End If

    '        ts.Complete()
    '    End Using
    '    Return docuemntoBE.idDocumento
    'End Function

    'Public Function GetListaPreVentaXinfraestructura(documentoPedido As documentoPedido) As List(Of documentoPedido)

    '    Dim documenPedidoBE As New documentoPedido
    '    Dim listadocumentopedidoBL As New List(Of documentoPedido)

    '    Using ts As New TransactionScope

    '        Dim consultaVentas = (From doc In HeliosData.documentoPedido
    '                              Group Join inf In HeliosData.infraestructura On
    '              doc.idInfraestructura Equals inf.idInfraestructura Into inf_join = Group
    '                              From inf In inf_join.DefaultIfEmpty()
    '                              Where doc.idEmpresa = documentoPedido.idEmpresa And
    '               doc.estado = documentoPedido.estado And doc.tipoVenta = documentoPedido.tipoVenta
    '                              Group New With {inf, doc} By
    '              doc.idEmpresa,
    '             doc.estado,
    '                                  doc.idInfraestructura,
    '                                  inf.nombre,
    '                                  inf.numero
    '                              Into g = Group
    '                              Select New With {
    '                                    .estado = estado,
    '                                    .idEmpresa = idEmpresa,
    '                                    .idInfraestructura = idInfraestructura,
    '                                  .nombre = nombre,
    '                                  .Numero = numero}).ToList


    '        'Dim consulta = HeliosData.documentoPedido.Where(Function(o) o.idEmpresa = documentoPedido.idEmpresa _
    '        '                                                 And o.estado = documentoPedido.estado _
    '        '                                                 And o.tipoVenta = documentoPedido.tipoVenta).GroupBy(Function(x) x.idEmpresa, Function(x) x.idInfraestructura).ToList


    '        For Each i In consultaVentas
    '            documenPedidoBE = New documentoPedido
    '            documenPedidoBE.estado = i.estado
    '            documenPedidoBE.idEmpresa = i.idEmpresa
    '            documenPedidoBE.idInfraestructura = i.idInfraestructura
    '            documenPedidoBE.nombreInfra = i.nombre
    '            documenPedidoBE.numeroDoc = i.Numero

    '            listadocumentopedidoBL.Add(documenPedidoBE)
    '        Next
    '        Return listadocumentopedidoBL

    '        ts.Complete()
    '    End Using

    'End Function

    'Public Function GetUbicar_documentoventaPedidoPorListID(ListaIdDocumento As List(Of Integer)) As List(Of documentoPedido)
    '    Return (From a In HeliosData.documentoPedido
    '            Where ListaIdDocumento.Contains(a.idDocumento) Select a).ToList
    'End Function

End Class
