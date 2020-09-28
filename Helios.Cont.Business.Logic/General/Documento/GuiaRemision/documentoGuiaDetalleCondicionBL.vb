Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class documentoGuiaDetalleCondicionBL
    Inherits BaseBL

    Public Sub SaveGuiaRemisionCondicion(objDocumento As List(Of documentoguiaDetalleCondicion), objDocumentoDet As List(Of documentoguiaDetalle))
        Dim ObjguiaDetalleCondicion As New documentoguiaDetalleCondicion
        Dim documentoDetBL As New documentoguiaDetalleBL
        Dim documentoBL As New documentoGuiaBL
        Dim documentoVentaBL As New documentoventaBL
        Dim documentoventaAbarroteBL As New documentoventaAbarrotesBL
        Dim idDocumento As Integer
        Dim contador As Integer = 0
        Dim contadorConforme As Integer = 0
        Dim idPadreDocumento As Integer = 0
        Using ts As New TransactionScope
            For Each item In objDocumento
                If (item.status = 1) Then
                    ObjguiaDetalleCondicion = New documentoguiaDetalleCondicion
                    With ObjguiaDetalleCondicion
                        .idDocumento = item.idDocumento
                        .secuencia = item.secuencia
                        .cantConforme = item.cantConforme
                        .descripcionCondicion = item.descripcionCondicion
                        .cantObservado = item.cantObservado
                        .nombreRececpcion = item.nombreRececpcion
                        .dniRecepcion = item.dniRecepcion
                        .estado = "PN"
                        .usuarioActualizacion = item.usuarioActualizacion
                        .fechaActualizacion = item.fechaActualizacion
                        idDocumento = item.idDocumento
                    End With
                    HeliosData.documentoguiaDetalleCondicion.Add(ObjguiaDetalleCondicion)
                End If
            Next

            Dim consulta = (From a In objDocumentoDet).ToList
            For Each x In consulta

                Dim Conforme = Aggregate a In objDocumento
                               Where a.idDocumento = x.idDocumento And a.secuencia = x.secuencia
              Into DBmn = Sum(CInt(a.cantConforme)),
                   DBmne = Sum(CInt(a.cantObservado))

                '  Dim Observacion = Aggregate a In objDocumento
                '                 Where a.idDocumento = x.idDocumento And a.secuencia = x.secuencia _
                'Into DBmn = Sum(a.cantidad), _
                '     DBmne = Sum(a.secuencia)

                If (x.cantidad = Conforme.DBmn) Then
                    idPadreDocumento = documentoDetBL.UpdateSingleDocDetalle(x.idDocumento, x.secuencia, TipoGuiaDetalle.Entrega_Total, 0, 1)
                    contadorConforme += 1

                    'ElseIf (x.cantidad = (Conforme.DBmn + Conforme.DBmne)) Then
                    '    idPadreDocumento = documentoDetBL.UpdateSingleDocDetalle(x.idDocumento, x.secuencia, TipoGuiaDetalle.Entrega_Parcial)
                    '    contador += 1
                Else
                    idPadreDocumento = documentoDetBL.UpdateSingleDocDetalle(x.idDocumento, x.secuencia, TipoGuiaDetalle.Entrega_Total, x.almacenRef, 1)
                    contador += 1
                End If
            Next

            If (contador > 0) Then
                documentoBL.UpdateSingleDoc(idDocumento, TipoGuia.Entregado)
            ElseIf (contadorConforme > 0 And contador = 0) Then
                documentoBL.UpdateSingleDoc(idDocumento, TipoGuia.Entregado)
                'documentoVentaBL.UpdateSingleDocVenta(idDocumento, TipoGuia.Entregado)
            End If
            If (Not IsNothing(idPadreDocumento)) Then
                documentoventaAbarroteBL.consultaEstadodocVenta(idPadreDocumento)
            End If

            HeliosData.SaveChanges()

            ts.Complete()

        End Using

    End Sub


    Public Function UbicarDocumentoGuiaDetCondicionFull(intIdDocumento As Integer) As List(Of documentoguiaDetalleCondicion)
        Dim DocDetalle As New documentoguiaDetalleCondicion
        Dim listaDetalle As New List(Of documentoguiaDetalleCondicion)

        Dim consulta = (From n In HeliosData.documentoguiaDetalleCondicion Where n.idDocumento = intIdDocumento And n.estado = "PN").ToList

        For Each i In consulta
            DocDetalle = New documentoguiaDetalleCondicion
            DocDetalle.idCondicion = i.idCondicion
            DocDetalle.idDocumento = i.idDocumento
            DocDetalle.secuencia = i.secuencia
            DocDetalle.nombreCondicion = i.nombreCondicion
            DocDetalle.descripcionCondicion = i.descripcionCondicion
            DocDetalle.cantConforme = i.cantConforme
            DocDetalle.cantObservado = i.cantObservado
            DocDetalle.estadoCondcion = i.estadoCondcion
            DocDetalle.usuarioActualizacion = i.usuarioActualizacion
            DocDetalle.fechaActualizacion = i.fechaActualizacion
            DocDetalle.nombreRececpcion = i.nombreRececpcion
            DocDetalle.estado = i.estado
            DocDetalle.dniRecepcion = i.dniRecepcion
            'DocDetalle.status = 1

            listaDetalle.Add(DocDetalle)
        Next

        Return listaDetalle
    End Function

    Public Sub SaveGuiaRemisionEntergado(objDocumento As documentoguiaDetalle, intIdDocumneto As Integer, intSecuencia As Integer)
        Dim ObjguiaDetalleCondicion As New documentoguiaDetalleCondicion

        Using ts As New TransactionScope

            ObjguiaDetalleCondicion = New documentoguiaDetalleCondicion
            With ObjguiaDetalleCondicion
                .idDocumento = intIdDocumneto
                .secuencia = intSecuencia
                .cantConforme = objDocumento.cantidad
                .descripcionCondicion = objDocumento.descripcionItem
                .cantObservado = 0
                .nombreRececpcion = objDocumento.nombreRecepcion
                .dniRecepcion = objDocumento.dniRecepcion
                .estado = "DC"
                .usuarioActualizacion = "MAYKOL"
                .fechaActualizacion = Date.Now

            End With
            HeliosData.documentoguiaDetalleCondicion.Add(ObjguiaDetalleCondicion)

            HeliosData.SaveChanges()
            ts.Complete()

        End Using

    End Sub

    Sub InsertarTransferencia_SPC(objDocumento As List(Of documentoguiaDetalleCondicion), objDocumentoDet As List(Of documentoguiaDetalle), objListaAsiento As documento)
        Dim ObjguiaDetalleCondicion As New documentoguiaDetalleCondicion
        Dim documentoDetBL As New documentoguiaDetalleBL
        Dim documentoBL As New documentoGuiaBL
        Dim documentoVentaBL As New documentoventaBL
        Dim documentoventaAbarroteBL As New documentoventaAbarrotesBL
        Dim documentocompradetalleBL As New documentocompradetalleBL
        Dim documentocompraBL As New documentocompraBL
        Dim AsientoBL As New AsientoBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim t As New totalesAlmacen
        Dim idDocumento As Integer
        Dim contador As Integer = 0
        Dim totalesBL As New totalesAlmacenBL
        Dim contadorConforme As Integer = 0
        Dim idPadreDocumento As Integer = 0
        Dim usuarioActualizacion As String = Nothing

        Using ts As New TransactionScope
            For Each item In objDocumento
                If (item.status = 1) Then
                    ObjguiaDetalleCondicion = New documentoguiaDetalleCondicion
                    With ObjguiaDetalleCondicion
                        .idDocumento = item.idDocumento
                        .secuencia = item.secuencia
                        .cantConforme = item.cantConforme
                        .descripcionCondicion = item.descripcionCondicion
                        .cantObservado = item.cantObservado
                        .nombreRececpcion = item.nombreRececpcion
                        .dniRecepcion = item.dniRecepcion
                        .estado = item.estado
                        .usuarioActualizacion = item.usuarioActualizacion
                        .fechaActualizacion = item.fechaActualizacion
                        idDocumento = item.idDocumento
                    End With
                    HeliosData.documentoguiaDetalleCondicion.Add(ObjguiaDetalleCondicion)
                End If
            Next

            Dim consulta = (From a In objDocumentoDet).ToList
            For Each x In consulta

                Dim Conforme = Aggregate a In objDocumento
                               Where a.idDocumento = x.idDocumento _
                                   And a.secuencia = x.secuencia _
                                   And a.estado = "PN"
                                   Into DBmn = Sum(CInt(a.cantConforme)),
                                   DBmne = Sum(CInt(a.cantObservado))

                '  Dim Observacion = Aggregate a In objDocumento
                '                 Where a.idDocumento = x.idDocumento And a.secuencia = x.secuencia _
                'Into DBmn = Sum(a.cantidad), _
                '     DBmne = Sum(a.secuencia)

                If (x.cantidad = Conforme.DBmn) Then
                    idPadreDocumento = documentoDetBL.UpdateSingleDocDetalle(x.idDocumento, x.secuencia, TipoGuiaDetalle.Entrega_Total, 0, 1)
                    contadorConforme += 1
                    objListaAsiento.idDocumento = idPadreDocumento
                    x.idDocumentoPadre = idPadreDocumento
                    'ElseIf (x.cantidad = (Conforme.DBmn + Conforme.DBmne)) Then
                    '    idPadreDocumento = documentoDetBL.UpdateSingleDocDetalle(x.idDocumento, x.secuencia, TipoGuiaDetalle.Entrega_Parcial)
                    '    contador += 1
                Else
                    idPadreDocumento = documentoDetBL.UpdateSingleDocDetalle(x.idDocumento, x.secuencia, TipoGuiaDetalle.Entrega_Parcial, x.almacenRef, 1)
                    contador += 1
                    objListaAsiento.idDocumento = idPadreDocumento
                    x.idDocumentoPadre = idPadreDocumento
                End If

                Dim nuevoTA = HeliosData.totalesAlmacen.Where(Function(o) o.idAlmacen = x.almacenRef _
                                                                  And o.idItem = x.idItem _
                                                                  And o.codigoLote = x.codigoLote).FirstOrDefault

                If nuevoTA Is Nothing Then
                    Dim lote = HeliosData.recursoCostoLote.Where(Function(o) o.codigoLote = x.codigoLote).SingleOrDefault
                    Dim obj = New totalesAlmacen With
                                        {
                                            .idEmpresa = x.idEmpresa,
                                            .idEstablecimiento = x.idEstablecimiento,
                                            .codigoLote = x.codigoLote,
                                            .idAlmacen = x.almacenRef,
                                            .origenRecaudo = x.destino,
                                            .tipoExistencia = x.tipoExistencia,
                                            .idItem = x.idItem,
                                            .descripcion = x.descripcionItem,
                                            .idUnidad = x.unidadMedida,
                                            .unidadMedida = x.unidadMedida,
                                            .cantidad = x.cantConforme,
                                            .importeSoles = x.importeMN,
                                            .importeDolares = x.importeME,
                                            .cantidadMaxima = 10000,
                                            .cantidadMinima = 10,
                                            .fechaVcto = lote.fechaVcto.GetValueOrDefault,
                                            .status = StatusArticulo.Activo,
                                            .usuarioActualizacion = x.usuarioModificacion,
                                            .fechaActualizacion = x.fechaModificacion}
                    HeliosData.totalesAlmacen.Add(obj)
                End If

                x.TipoRegistro = "E"
                inventarioBL.InsertTransferenciaDistribucion(x)

                ''ENTRADA DE ITEMS AL ALMACEN DE DESTINO

                't = New totalesAlmacen
                't.idEmpresa = Gempresas.IdEmpresaRuc
                't.idEstablecimiento = x.idEstablecimiento
                't.idAlmacen = x.almacenRef   ' almacen de DESTINO
                't.origenRecaudo = x.destino
                't.idItem = x.idItem
                't.descripcion = x.descripcionItem
                't.tipoExistencia = x.tipoExistencia
                't.tipoCambio = 0
                't.idUnidad = x.unidadMedida
                't.cantidad = x.cantConforme
                't.importeSoles = x.importeMN
                't.importeDolares = x.importeME
                't.usuarioActualizacion = x.usuarioModificacion
                't.fechaActualizacion = x.fechaModificacion
                'totalesBL.ActualizarItemsTransferencia(t)
                'usuarioActualizacion = x.usuarioModificacion
                'SALIDA DE ITEMS DEL ALMACEN DE ORIGEN
            Next

            documentoBL.UpdateSingleDoc(idDocumento, TipoGuia.Entregado)

            If (Not IsNothing(idPadreDocumento)) Then
                documentocompraBL.consultaEstadodocCompra(idPadreDocumento)
                documentocompradetalleBL.UpdateSingleUsuarioSistema(idPadreDocumento, usuarioActualizacion)
            End If
            AsientoBL.SavebyGroupDoc(objListaAsiento)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub SaveGuiaRemisionCondicionTransferenciaAlmacenSC(objDocumento As List(Of documentoguiaDetalleCondicion), objDocumentoDet As List(Of documentoguiaDetalle), objListaAsiento As documento)
        Dim inventarioBL As New InventarioMovimientoBL
        Dim totalesBL As New totalesAlmacenBL
        Using ts As New TransactionScope

            InsertarTransferencia_SPC(objDocumento, objDocumentoDet, objListaAsiento)

            'Dim ListaArticulos = HeliosData.almacen.Where(Function(o) o.idEmpresa = Gempresas.IdEmpresaRuc And o.tipo = TipoAlmacen.Deposito).ToList

            Dim consulta = (From a In objDocumentoDet).ToList

            For Each a In consulta
                Dim codigoLotex As Integer = a.codigoLote
                Dim lista = inventarioBL.GetCuracionEntradasAlmacenByArticuloLote(New InventarioMovimiento With {.idAlmacen = a.almacenRef,
                                                                                                                         .fecha = New DateTime(objDocumentoDet(0).fecha.Year, objDocumentoDet(0).fecha.Month, 1),
                                                                                                                         .tipoProducto = a.tipoExistencia,
                                                                                                                         .idItem = a.idItem, .nrolote = codigoLotex}, Nothing)

                totalesBL.GetCurarKardexCaberasLOTE(lista)

                'Dim listaAcurar = inventarioBL.GetCuracionEntradasAlmacenByArticulo(New InventarioMovimiento With {.idAlmacen = a.almacenRef,
                '                                                                                                       .fecha = New DateTime(objDocumentoDet(0).fecha.Year,
                '                                                                                                                             objDocumentoDet(0).fecha.Month, 1),
                '                                                                                                       .tipoProducto = a.tipoExistencia,
                '                                                                                                       .idItem = a.idItem}, Nothing)
                'totalesBL.GetCurarKardexCaberas(listaAcurar)
            Next

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


End Class
