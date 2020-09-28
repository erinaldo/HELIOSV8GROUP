Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity

Public Class documentoPedidoDetBL
    Inherits BaseBL

    Public Function GetUbicar_DocveNTAxIdDistribucion(documentoPedidoBE As documentoPedido) As List(Of documentoventaAbarrotesDet)
        Try
            Dim docPedidoDet As New documentoventaAbarrotesDet
            Dim lista As New List(Of documentoventaAbarrotesDet)

            Dim CONSULTA = (From DET In HeliosData.documentoventaAbarrotesDet
                            Where documentoPedidoBE.ListaTipoVenta.Contains(DET.documentoventaAbarrotes.tipoVenta) And
                                  documentoPedidoBE.listaIdDistribucion.Contains(DET.idDistribucion) And
                                documentoPedidoBE.ListaEstado.Contains(DET.estadoPago) And DET.estadoDistribucion <> "X"
                            Select
                        DET.idDocumento, DET.secuencia, IdAlmacenOrigen = CType(DET.idAlmacenOrigen, Int32?),
                        DET.establecimientoOrigen,
                        DET.cuentaOrigen, DET.idItem, DET.nombreItem, DET.fechaVcto,
                          DET.tipoExistencia, DET.destino, DET.unidad1, DET.monto1, DET.unidad2,
                        DET.monto2, DET.precioUnitario, DET.precioUnitarioUS, DET.importeMN, DET.importeME,
                         DET.importeMNK, DET.importeMEK, DET.descuentoMN, DET.descuentoME,
                        DET.montokardex, DET.montoIsc, DET.montoIgv, DET.otrosTributos, DET.montokardexUS,
                        DET.montoIscUS, DET.montoIgvUS, DET.otrosTributosUS, DET.salidaCostoMN,
                        DET.salidaCostoME, DET.cantidadCredito, DET.cantidadDebito, DET.notaCreditoMN,
                        DET.notaCreditoME, DET.notaDebitoMN, DET.notaDebitoME, DET.preEvento, DET.idPadreDTVenta,
                        DET.estadoMovimiento, DET.tipoVenta, DET.entregado, DET.estadoPago, DET.categoria,
                        DET.estadoEntrega, DET.idCajaUsuario, DET.codigoLote, DET.idbeneficio, DET.tipobeneficio,
                        DET.beneficiobase, DET.usuarioModificacion,
                        DET.fechaModificacion, FechaDoc = CType(DET.documentoventaAbarrotes.fechaDoc, DateTime?), DET.idDistribucion,
                                DET.documentoventaAbarrotes.idCliente, DET.documentoventaAbarrotes.tipoDocumento, DET.documentoventaAbarrotes.nombrePedido).ToList

            For Each item In CONSULTA
                docPedidoDet = New documentoventaAbarrotesDet
                docPedidoDet.idDocumento = item.idDocumento
                docPedidoDet.secuencia = item.secuencia
                docPedidoDet.codigoLote = item.codigoLote
                docPedidoDet.idAlmacenOrigen = item.IdAlmacenOrigen
                docPedidoDet.establecimientoOrigen = item.establecimientoOrigen
                docPedidoDet.cuentaOrigen = item.cuentaOrigen
                docPedidoDet.idItem = item.idItem
                docPedidoDet.nombreItem = item.nombreItem
                docPedidoDet.fechaVcto = item.fechaVcto
                docPedidoDet.tipoExistencia = item.tipoExistencia
                docPedidoDet.destino = item.destino
                docPedidoDet.unidad1 = item.unidad1
                docPedidoDet.monto1 = item.monto1
                docPedidoDet.unidad2 = item.unidad2
                docPedidoDet.monto2 = item.monto2
                docPedidoDet.precioUnitario = item.precioUnitario
                docPedidoDet.precioUnitarioUS = item.precioUnitarioUS
                docPedidoDet.importeMN = item.importeMN
                docPedidoDet.importeME = item.importeME
                docPedidoDet.importeMNK = item.importeMNK
                docPedidoDet.importeMEK = item.importeMEK
                docPedidoDet.descuentoMN = item.descuentoMN
                docPedidoDet.descuentoME = item.descuentoME
                docPedidoDet.montokardex = item.montokardex
                docPedidoDet.montoIsc = item.montoIsc
                docPedidoDet.montoIgv = item.montoIgv
                docPedidoDet.otrosTributos = item.otrosTributos
                docPedidoDet.montokardexUS = item.montokardexUS
                docPedidoDet.montoIscUS = item.montoIscUS
                docPedidoDet.montoIgvUS = item.montoIgvUS
                docPedidoDet.otrosTributosUS = item.otrosTributosUS
                docPedidoDet.salidaCostoMN = item.salidaCostoMN
                docPedidoDet.salidaCostoME = item.salidaCostoME
                docPedidoDet.preEvento = item.preEvento
                docPedidoDet.estadoMovimiento = item.estadoMovimiento
                docPedidoDet.tipoVenta = item.tipoVenta
                docPedidoDet.entregado = item.entregado
                docPedidoDet.idPadreDTVenta = item.idPadreDTVenta
                docPedidoDet.estadoPago = item.estadoPago
                docPedidoDet.estadoEntrega = item.estadoEntrega
                docPedidoDet.categoria = item.categoria
                docPedidoDet.usuarioModificacion = item.usuarioModificacion
                docPedidoDet.fechaModificacion = item.fechaModificacion
                docPedidoDet.FechaDoc = item.FechaDoc
                docPedidoDet.idDistribucion = item.idDistribucion
                docPedidoDet.idCajaUsuario = item.idCliente
                docPedidoDet.NombreProveedor = item.nombrePedido
                docPedidoDet.TipoDoc = item.tipoDocumento
                lista.Add(docPedidoDet)
            Next
            Return lista
        Catch ex As Exception
            Throw ex
        End Try


    End Function


    Public Function GetUbicar_DocveNTAxIdCliente(documentoPedidoBE As documentoPedido) As List(Of documentoventaAbarrotesDet)
        Try
            Dim docPedidoDet As New documentoventaAbarrotesDet
            Dim lista As New List(Of documentoventaAbarrotesDet)

            Dim CONSULTA = (From DET In HeliosData.documentoventaAbarrotesDet
                            Where documentoPedidoBE.ListaTipoVenta.Contains(DET.documentoventaAbarrotes.tipoVenta) And
                                 DET.estadoDistribucion = documentoPedidoBE.estado And
                                DET.documentoventaAbarrotes.idCliente = documentoPedidoBE.idCliente And
                                documentoPedidoBE.ListaEstado.Contains(DET.estadoEntrega)
                            Select
                        DET.idDocumento, DET.secuencia, IdAlmacenOrigen = CType(DET.idAlmacenOrigen, Int32?),
                        DET.establecimientoOrigen,
                        DET.cuentaOrigen, DET.idItem, DET.nombreItem, DET.fechaVcto,
                          DET.tipoExistencia, DET.destino, DET.unidad1, DET.monto1, DET.unidad2,
                        DET.monto2, DET.precioUnitario, DET.precioUnitarioUS, DET.importeMN, DET.importeME,
                         DET.importeMNK, DET.importeMEK, DET.descuentoMN, DET.descuentoME,
                        DET.montokardex, DET.montoIsc, DET.montoIgv, DET.otrosTributos, DET.montokardexUS,
                        DET.montoIscUS, DET.montoIgvUS, DET.otrosTributosUS, DET.salidaCostoMN,
                        DET.salidaCostoME, DET.cantidadCredito, DET.cantidadDebito, DET.notaCreditoMN,
                        DET.notaCreditoME, DET.notaDebitoMN, DET.notaDebitoME, DET.preEvento, DET.idPadreDTVenta,
                        DET.estadoMovimiento, DET.tipoVenta, DET.entregado, DET.estadoPago, DET.categoria,
                        DET.estadoEntrega, DET.idCajaUsuario, DET.codigoLote, DET.idbeneficio, DET.tipobeneficio,
                        DET.beneficiobase, DET.usuarioModificacion,
                        DET.fechaModificacion, FechaDoc = CType(DET.documentoventaAbarrotes.fechaDoc, DateTime?), DET.idDistribucion,
                                DET.documentoventaAbarrotes.idCliente, DET.documentoventaAbarrotes.tipoDocumento, DET.documentoventaAbarrotes.nombrePedido).ToList

            For Each item In CONSULTA
                docPedidoDet = New documentoventaAbarrotesDet
                docPedidoDet.idDocumento = item.idDocumento
                docPedidoDet.secuencia = item.secuencia
                docPedidoDet.codigoLote = item.codigoLote
                docPedidoDet.idAlmacenOrigen = item.IdAlmacenOrigen
                docPedidoDet.establecimientoOrigen = item.establecimientoOrigen
                docPedidoDet.cuentaOrigen = item.cuentaOrigen
                docPedidoDet.idItem = item.idItem
                docPedidoDet.nombreItem = item.nombreItem
                docPedidoDet.fechaVcto = item.fechaVcto
                docPedidoDet.tipoExistencia = item.tipoExistencia
                docPedidoDet.destino = item.destino
                docPedidoDet.unidad1 = item.unidad1
                docPedidoDet.monto1 = item.monto1
                docPedidoDet.unidad2 = item.unidad2
                docPedidoDet.monto2 = item.monto2
                docPedidoDet.precioUnitario = item.precioUnitario
                docPedidoDet.precioUnitarioUS = item.precioUnitarioUS
                docPedidoDet.importeMN = item.importeMN
                docPedidoDet.importeME = item.importeME
                docPedidoDet.importeMNK = item.importeMNK
                docPedidoDet.importeMEK = item.importeMEK
                docPedidoDet.descuentoMN = item.descuentoMN
                docPedidoDet.descuentoME = item.descuentoME
                docPedidoDet.montokardex = item.montokardex
                docPedidoDet.montoIsc = item.montoIsc
                docPedidoDet.montoIgv = item.montoIgv
                docPedidoDet.otrosTributos = item.otrosTributos
                docPedidoDet.montokardexUS = item.montokardexUS
                docPedidoDet.montoIscUS = item.montoIscUS
                docPedidoDet.montoIgvUS = item.montoIgvUS
                docPedidoDet.otrosTributosUS = item.otrosTributosUS
                docPedidoDet.salidaCostoMN = item.salidaCostoMN
                docPedidoDet.salidaCostoME = item.salidaCostoME
                docPedidoDet.preEvento = item.preEvento
                docPedidoDet.estadoMovimiento = item.estadoMovimiento
                docPedidoDet.tipoVenta = item.tipoVenta
                docPedidoDet.entregado = item.entregado
                docPedidoDet.idPadreDTVenta = item.idPadreDTVenta
                docPedidoDet.estadoPago = item.estadoPago
                docPedidoDet.estadoEntrega = item.estadoEntrega
                docPedidoDet.categoria = item.categoria
                docPedidoDet.usuarioModificacion = item.usuarioModificacion
                docPedidoDet.fechaModificacion = item.fechaModificacion
                docPedidoDet.FechaDoc = item.FechaDoc
                docPedidoDet.idDistribucion = item.idDistribucion
                docPedidoDet.idCajaUsuario = item.idCliente
                docPedidoDet.NombreProveedor = item.nombrePedido
                docPedidoDet.TipoDoc = item.tipoDocumento
                lista.Add(docPedidoDet)
            Next
            Return lista
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function GetUbicar_DocXInfraXAreaFull(documentoPedidoBE As documentoPedido) As List(Of documentoPedidoDet)
        Dim docPedidoDet As New documentoPedidoDet
        Dim lista As New List(Of documentoPedidoDet)

        Try

            'Dim consulta = (From DET In HeliosData.documentoPedidoDet
            '                Join ALM In HeliosData.almacen On CInt(DET.idAlmacenOrigen) Equals ALM.idAlmacen
            '                Where ALM.tipo = documentoPedidoBE.tipo And
            '                     documentoPedidoBE.ListaTipoExistencia.Contains(DET.tipoExistencia) And
            '                      DET.documentoPedido.idEmpresa = documentoPedidoBE.idEmpresa And
            '                    documentoPedidoBE.ListaEstado.Contains(DET.estadoEntrega)
            '                Group New With {DET, DET.documentoPedido.idDistribucion} By
            '                 DET.idDocumento,
            '                 DET.secuencia,
            '                    DET.idAlmacenOrigen,
            '                    DET.establecimientoOrigen,
            '                    DET.cuentaOrigen, DET.idItem, DET.nombreItem,
            '                    DET.fechaVcto, DET.tipoExistencia, DET.destino,
            '                    DET.unidad1, DET.monto1, DET.unidad2, DET.monto2,
            '                    DET.precioUnitario, DET.precioUnitarioUS, DET.importeMN,
            '                    DET.importeME, DET.importeMNK, DET.importeMEK, DET.descuentoMN,
            '                    DET.descuentoME, DET.montokardex, DET.montoIsc, DET.montoIgv,
            '                    DET.otrosTributos, DET.montokardexUS, DET.montoIscUS,
            '                    DET.montoIgvUS, DET.otrosTributosUS, DET.salidaCostoMN,
            '                    DET.salidaCostoME, DET.cantidadCredito, DET.cantidadDebito,
            '                    DET.notaCreditoMN, DET.notaCreditoME, DET.notaDebitoMN,
            '                    DET.notaDebitoME, DET.preEvento, DET.idPadreDTVenta,
            '                    DET.estadoMovimiento, DET.tipoVenta, DET.entregado,
            '                    DET.estadoPago, DET.categoria, DET.estadoEntrega,
            '                    DET.idCajaUsuario, DET.codigoLote, DET.idbeneficio,
            '                    DET.tipobeneficio, DET.beneficiobase, DET.idArea,
            '                    DET.usuarioModificacion, DET.fechaModificacion,
            '                    DET.documentoPedido.fechaDoc
            '                    Into g = Group
            '                Select
            '                    idDocumento, secuencia, IdAlmacenOrigen = CType(idAlmacenOrigen, Int32?),
            '                    establecimientoOrigen, cuentaOrigen, idItem, nombreItem, fechaVcto,
            '                    tipoExistencia, destino, unidad1, monto1, unidad2, monto2,
            '                    precioUnitario, precioUnitarioUS, importeMN, importeME, importeMNK,
            '                    importeMEK, descuentoMN, descuentoME, montokardex, montoIsc,
            '                    montoIgv, otrosTributos, montokardexUS, montoIscUS, montoIgvUS,
            '                    otrosTributosUS, salidaCostoMN, salidaCostoME, cantidadCredito,
            '                    cantidadDebito, notaCreditoMN, notaCreditoME, notaDebitoMN,
            '                    notaDebitoME, preEvento, idPadreDTVenta, estadoMovimiento,
            '                    tipoVenta, entregado, estadoPago, categoria, estadoEntrega,
            '                    idCajaUsuario, codigoLote, idbeneficio, tipobeneficio,
            '                    beneficiobase, idArea, usuarioModificacion, fechaModificacion,
            '                    fechaDoc).ToList


            'For Each item In consulta
            '    docPedidoDet = New documentoPedidoDet
            '    docPedidoDet.idDocumento = item.idDocumento
            '    docPedidoDet.secuencia = item.secuencia
            '    docPedidoDet.codigoLote = item.codigoLote
            '    docPedidoDet.idAlmacenOrigen = item.IdAlmacenOrigen
            '    docPedidoDet.establecimientoOrigen = item.establecimientoOrigen
            '    docPedidoDet.cuentaOrigen = item.cuentaOrigen
            '    docPedidoDet.idItem = item.idItem
            '    docPedidoDet.nombreItem = item.nombreItem
            '    docPedidoDet.fechaVcto = item.fechaVcto
            '    docPedidoDet.tipoExistencia = item.tipoExistencia
            '    docPedidoDet.destino = item.destino
            '    docPedidoDet.unidad1 = item.unidad1
            '    docPedidoDet.monto1 = item.monto1
            '    docPedidoDet.unidad2 = item.unidad2
            '    docPedidoDet.monto2 = item.monto2
            '    docPedidoDet.precioUnitario = item.precioUnitario
            '    docPedidoDet.precioUnitarioUS = item.precioUnitarioUS
            '    docPedidoDet.importeMN = item.importeMN
            '    docPedidoDet.importeME = item.importeME
            '    docPedidoDet.importeMNK = item.importeMNK
            '    docPedidoDet.importeMEK = item.importeMEK
            '    docPedidoDet.descuentoMN = item.descuentoMN
            '    docPedidoDet.descuentoME = item.descuentoME
            '    docPedidoDet.montokardex = item.montokardex
            '    docPedidoDet.montoIsc = item.montoIsc
            '    docPedidoDet.montoIgv = item.montoIgv
            '    docPedidoDet.otrosTributos = item.otrosTributos
            '    docPedidoDet.montokardexUS = item.montokardexUS
            '    docPedidoDet.montoIscUS = item.montoIscUS
            '    docPedidoDet.montoIgvUS = item.montoIgvUS
            '    docPedidoDet.otrosTributosUS = item.otrosTributosUS
            '    docPedidoDet.salidaCostoMN = item.salidaCostoMN
            '    docPedidoDet.salidaCostoME = item.salidaCostoME
            '    docPedidoDet.preEvento = item.preEvento
            '    docPedidoDet.estadoMovimiento = item.estadoMovimiento
            '    docPedidoDet.tipoVenta = item.tipoVenta
            '    docPedidoDet.entregado = item.entregado
            '    docPedidoDet.idPadreDTVenta = item.idPadreDTVenta
            '    docPedidoDet.estadoPago = item.estadoPago
            '    docPedidoDet.estadoEntrega = item.estadoEntrega
            '    docPedidoDet.categoria = item.categoria
            '    docPedidoDet.usuarioModificacion = item.usuarioModificacion
            '    docPedidoDet.idArea = item.idArea
            '    docPedidoDet.FechaDoc = item.fechaDoc

            '    'If (item.tipoExistencia = "01") Then
            '    '    docPedidoDet.nombreArea = item.mercaderia
            '    'ElseIf (item.tipoExistencia = "GS") Then
            '    '    docPedidoDet.nombreArea = item.servicio
            '    'End If
            '    'docPedidoDet.nombreMesa = item.nombre & "-" & item.Numero


            '    lista.Add(docPedidoDet)
            'Next

        Catch ex As Exception

        End Try
        Return lista
    End Function

    Public Sub EditarEstadoPedido(i As documentoPedidoDet)
        Try
            Dim informacionBL As New informacionBL

            Using ts As New TransactionScope

                Dim obj = (From n In HeliosData.documentoPedidoDet
                           Where n.secuencia = i.secuencia).FirstOrDefault

                obj.estadoEntrega = i.estadoEntrega
                'obj.idArea = i.idArea

                i.informacionComplementariaBE.idDocumento = obj.idDocumento
                i.informacionComplementariaBE.idDocumentoDet = obj.secuencia
                informacionBL.Saveinformacion(i.informacionComplementariaBE)

                HeliosData.SaveChanges()
                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub EditarEstadoXDocumento(i As List(Of String))
        Try
            Dim informacionBL As New informacionBL

            Using ts As New TransactionScope

                For Each UpdateID In i
                    Dim objDoc = (From n In HeliosData.documentoventaAbarrotes
                                  Where n.idDocumento = UpdateID).ToList

                    For Each ITE In objDoc
                        ITE.tipoVenta = "VPN"
                        HeliosData.SaveChanges()
                    Next

                    Dim obj = (From n In HeliosData.documentoventaAbarrotesDet
                               Where n.idDocumento = UpdateID).ToList

                    For Each ITE In obj
                        ITE.estadoDistribucion = "C"
                        HeliosData.SaveChanges()
                    Next
                Next

                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub EditarEstadoPedidoMasivo(documentoPedidoDet As List(Of documentoPedidoDet))
        Try
            Dim informacionBL As New informacionBL

            Using ts As New TransactionScope

                For Each i In documentoPedidoDet
                    Dim obj = (From n In HeliosData.documentoPedidoDet
                               Where n.secuencia = i.secuencia).FirstOrDefault

                    obj.estadoEntrega = i.estadoEntrega
                    'obj.idArea = i.idArea
                    HeliosData.SaveChanges()

                    i.informacionComplementariaBE.idDocumento = obj.idDocumento
                    i.informacionComplementariaBE.idDocumentoDet = obj.secuencia
                    informacionBL.Saveinformacion(i.informacionComplementariaBE)

                Next

                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Sub EditarEstadoDocPedidoMasivo(documentoPedidoBE As distribucionInfraestructura)
        Try
            Dim informacionBL As New informacionBL
            Dim distribucionBL As New distribucionInfraestructuraBL
            Using ts As New TransactionScope


                Dim obj = (From n In HeliosData.documentoventaAbarrotesDet
                           Where n.idDistribucion = documentoPedidoBE.idDistribucion And n.estadoDistribucion = "C").ToList

                For Each i In obj
                    i.estadoDistribucion = "X"
                    HeliosData.SaveChanges()
                Next

                distribucionBL.updateDistribucionxID(documentoPedidoBE)

                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class
