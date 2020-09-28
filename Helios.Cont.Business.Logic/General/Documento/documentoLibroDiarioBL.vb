Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class documentoLibroDiarioBL
    Inherits BaseBL
    ''' <summary>
    ''' Verificacion si se ha ingresado el inventario de apertura
    ''' </summary>
    ''' <param name="be"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TienenAperturaInventario(be As documentoLibroDiario) As Boolean
        Dim con = HeliosData.documentoLibroDiario.Where(Function(o) o.tipoRegistro = be.tipoRegistro).Count
        TienenAperturaInventario = False
        If con > 0 Then
            TienenAperturaInventario = True
        End If
    End Function


    Public Function ListaDeReconocimientosxEntregable(idEntregable As Integer) As List(Of documentoLibroDiario)
        Dim objeto As New documentoLibroDiario
        Dim lista As New List(Of documentoLibroDiario)


        Dim consulta = (From det In HeliosData.documentoLibroDiario
                        Where det.estado = "HREC" And det.idCosto = idEntregable
                        Select det.idDocumento,
                        det.fecha,
                        det.tipoDoc,
                        det.nroDoc,
                        det.importeMN,
                        det.tipoRazonSocial,
                        det.razonSocial,
                         MontoFacturado = (CType((Aggregate t1 In
                      (From w In HeliosData.documentoventaAbarrotesDet
                       Join a In HeliosData.documentoventaAbarrotes On New With {.IdDocumento = CInt(w.idDocumento)} Equals New With {.IdDocumento = a.idDocumento}
                       Where
                     w.idItem = det.idDocumento _
                        And a.tipoVenta = "VREC"
                       Select New With {
                     w.precioUnitario
                     }) Into Sum(t1.precioUnitario)), Decimal?)),
 MontoFacturadoIgv = (CType((Aggregate t1 In
                      (From w In HeliosData.documentoventaAbarrotesDet
                       Join a In HeliosData.documentoventaAbarrotes On New With {.IdDocumento = CInt(w.idDocumento)} Equals New With {.IdDocumento = a.idDocumento}
                       Where
                     w.idItem = det.idDocumento _
                        And a.tipoVenta = "VREC"
                       Select New With {
                     w.montoIgv
                     }) Into Sum(t1.montoIgv)), Decimal?)),
          MontoPago = (CType((Aggregate t1 In
                      (From w In HeliosData.documentoCajaDetalle
                       Join a In HeliosData.documentoCaja On New With {.IdDocumento = CInt(w.idDocumento)} Equals New With {.IdDocumento = a.idDocumento}
                       Where
                     w.idItem = det.idDocumento _
                        And a.tipoMovimiento = "DC"
                       Select New With {
                     w.montoSoles
                     }) Into Sum(t1.montoSoles)), Decimal?))).ToList




        For Each i In consulta
            objeto = New documentoLibroDiario

            objeto.idDocumento = i.idDocumento
            objeto.fecha = i.fecha
            objeto.tipoDoc = i.tipoDoc
            objeto.nroDoc = i.nroDoc
            objeto.importeMN = i.importeMN
            objeto.tipoRazonSocial = i.tipoRazonSocial
            objeto.razonSocial = i.razonSocial
            objeto.montoFacturado = i.MontoFacturado.GetValueOrDefault
            objeto.montoPago = i.MontoPago.GetValueOrDefault
            objeto.montoIgv = i.MontoFacturadoIgv.GetValueOrDefault



            lista.Add(objeto)
        Next


        Return lista
    End Function

    Public Function ListarAsientosManualesSinCosteo(compraBE As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)


        Dim consulta = (From n In HeliosData.documentoLibroDiario
                       Join det In HeliosData.documentoLibroDiarioDetalle
                       On det.idDocumento Equals n.idDocumento
                       Where n.idEmpresa = compraBE.idEmpresa And n.idEstablecimiento = compraBE.idEstablecimiento _
                        And n.tipoDoc = "9903" _
                        And (New String() {"18"}).Contains(det.cuenta.Substring(1 - 1, 2)) _
                        And det.tipoCosto = "PRE" _
                       Select det.idDocumento, n.tipoOperacion,
                       n.tipoDoc, n.nroDoc, n.moneda, n.fecha,
                       det.secuencia, det.idItem, det.cuenta, det.descripcion,
                       det.importeMN, det.importeME, det.tipoAsiento, n.modulo).ToList

        'Dim consulta = (From n In HeliosData.documentoLibroDiario
        '                Join det In HeliosData.documentoLibroDiarioDetalle
        '                On det.idDocumento Equals n.idDocumento
        '                Where n.idEmpresa = compraBE.idEmpresa And n.idEstablecimiento = compraBE.idEstablecimiento _
        '                 And n.tipoDoc = "9903" _
        '                 And (New String() {"18"}).Contains(det.cuenta.Substring(1 - 1, 2)) _
        '                 And Not (New String() {"PC", "PG", "HC", "HG"}).Contains(det.tipoCosto) _
        '                Select det.idDocumento, n.tipoOperacion,
        '                n.tipoDoc, n.nroDoc, n.moneda, n.fecha,
        '                det.secuencia, det.idItem, det.cuenta, det.descripcion,
        '                det.importeMN, det.importeME, det.tipoAsiento).ToList


        For Each i In consulta

            'Dim codigoCuenta = Mid(i.cuenta, 1, 2)

            'Select Case Val(codigoCuenta)
            '        Case 62 To 68

            doccompra = New documentoLibroDiarioDetalle
            'doccompra.idCosto = i.idCosto.GetValueOrDefault
            ' doccompra.NombreProyectoGeneral = i.Nameproyecto
            doccompra.idDocumento = i.idDocumento
            doccompra.tipoDocumento = i.tipoDoc
            doccompra.nroDoc = i.nroDoc
            doccompra.moneda = i.moneda
            doccompra.fecha = i.fecha
            doccompra.idDocumento = i.idDocumento
            doccompra.secuencia = i.secuencia
            doccompra.cuenta = i.cuenta
            doccompra.descripcion = i.descripcion
            doccompra.cuenta = i.cuenta
            doccompra.importeMN = i.importeMN
            doccompra.importeME = i.importeME
            doccompra.operacion = i.tipoOperacion
            doccompra.tipoAsiento = i.tipoAsiento
            doccompra.modulo = i.modulo
            compraLista.Add(doccompra)
            'End Select
        Next
        Return compraLista
    End Function

    Public Function GrabarDocumentoProyecto(documento As documento, idEntregable As Integer, listaR As List(Of recursoCostoDetalle), estadoProy As String) As Integer
        Dim documentoBL As New documentoBL
        Dim docDetalle As New documentoLibroDiarioDetalle
        Dim AsientoBL As New AsientoBL
        Dim recursoBL As New recursoCostoDetalleBL
        Dim obj As New recursoCostoDetalle
        Dim numeracionBL As New numeracionBoletasBL
        Dim recursosa As New recursoCostoBL
        Dim recursocostodetallebl As New recursoCostoDetalleBL

        Try
            Using ts As New TransactionScope
                Dim cval As Integer = 0
                cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(documento.documentoLibroDiario.IdNumeracion))


                documentoBL.InsertDocAsiento(documento, cval)
                InsertCabeceraCosteo(documento.documentoLibroDiario, documento.idDocumento, cval)


                AsientoBL.SavebyGroupDoc(documento)

                For Each i In listaR
                    recursocostodetallebl.GrabarDetalleCR(i)
                Next



                recursosa.CambioEstadoCostoReal(idEntregable, estadoProy)


                HeliosData.SaveChanges()
                ts.Complete()
                Return documento.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    

    Public Sub InsertCabeceraCosteo(ByVal documentocompraBE As documentoLibroDiario, intIdDocumento As Integer, val As Integer)
        Dim docCompra As New documentoLibroDiario
        Dim numeracionBL As New numeracionBoletasBL
        'Dim cval As Integer = 0
        Using ts As New TransactionScope
            docCompra.idDocumento = intIdDocumento
            docCompra.idEmpresa = documentocompraBE.idEmpresa
            docCompra.idEstablecimiento = documentocompraBE.idEstablecimiento
            docCompra.fecha = documentocompraBE.fecha
            docCompra.fechaPeriodo = documentocompraBE.fechaPeriodo
            docCompra.infoReferencial = documentocompraBE.infoReferencial
            docCompra.tipoDoc = documentocompraBE.tipoDoc
            docCompra.tipoRegistro = "NM"
            docCompra.tipoRazonSocial = documentocompraBE.tipoRazonSocial
            docCompra.razonSocial = documentocompraBE.razonSocial
            docCompra.fechaVct = documentocompraBE.fechaVct
            docCompra.modulo = documentocompraBE.modulo
            docCompra.estado = documentocompraBE.estado
            ' cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(documentocompraBE.IdNumeracion))

            docCompra.nroDoc = val '
            docCompra.tipoOperacion = documentocompraBE.tipoOperacion
            docCompra.moneda = documentocompraBE.moneda

            docCompra.tipoCambio = documentocompraBE.tipoCambio
            docCompra.importeMN = documentocompraBE.importeMN
            docCompra.importeME = documentocompraBE.importeME
            docCompra.idReferencia = documentocompraBE.idReferencia
            docCompra.tieneCosto = documentocompraBE.tieneCosto
            docCompra.idCosto = documentocompraBE.idCosto
            docCompra.usuarioActualizacion = documentocompraBE.usuarioActualizacion
            docCompra.fechaActualizacion = documentocompraBE.fechaActualizacion

            HeliosData.documentoLibroDiario.Add(docCompra)
            HeliosData.SaveChanges()
            ts.Complete()
            documentocompraBE.serie = documentocompraBE.serie
            documentocompraBE.nroDoc = val
            '   documentocompraBE.idDocumento = docCompra.idDocumento
        End Using
    End Sub

    Public Function HistorialCosteo(idEntregable As Integer) As List(Of documentoLibroDiario)
        Dim objeto As New documentoLibroDiario
        Dim lista As New List(Of documentoLibroDiario)


        Dim consulta = (From det In HeliosData.documentoLibroDiario
                        Where det.idCosto = idEntregable And det.tieneCosto = "P" And det.estado = "PREC" Or det.estado = "REC").ToList

        For Each i In consulta
            objeto = New documentoLibroDiario

            objeto.idDocumento = i.idDocumento
            objeto.fecha = i.fecha
            objeto.tipoDoc = i.tipoDoc
            objeto.nroDoc = i.nroDoc
            objeto.importeMN = i.importeMN
            objeto.tipoRazonSocial = i.tipoRazonSocial
            objeto.razonSocial = i.razonSocial
            objeto.estado = i.estado


            lista.Add(objeto)
        Next


        Return lista
    End Function

    Public Function ListaDeReconocimientos() As List(Of documentoLibroDiario)
        Dim objeto As New documentoLibroDiario
        Dim lista As New List(Of documentoLibroDiario)


        Dim consulta = (From det In HeliosData.documentoLibroDiario
                        Where det.estado = "HREC"
                        Select det.idDocumento,
                        det.fecha,
                        det.tipoDoc,
                        det.nroDoc,
                        det.importeMN,
                        det.tipoRazonSocial,
                        det.razonSocial,
                         MontoFacturado = (CType((Aggregate t1 In
                      (From w In HeliosData.documentoventaAbarrotesDet
                       Join a In HeliosData.documentoventaAbarrotes On New With {.IdDocumento = CInt(w.idDocumento)} Equals New With {.IdDocumento = a.idDocumento}
                       Where
                     w.idItem = det.idDocumento _
                        And a.tipoVenta = "VREC"
                       Select New With {
                     w.precioUnitario
                     }) Into Sum(t1.precioUnitario)), Decimal?)),
 MontoFacturadoIgv = (CType((Aggregate t1 In
                      (From w In HeliosData.documentoventaAbarrotesDet
                       Join a In HeliosData.documentoventaAbarrotes On New With {.IdDocumento = CInt(w.idDocumento)} Equals New With {.IdDocumento = a.idDocumento}
                       Where
                     w.idItem = det.idDocumento _
                        And a.tipoVenta = "VREC"
                       Select New With {
                     w.montoIgv
                     }) Into Sum(t1.montoIgv)), Decimal?)),
          MontoPago = (CType((Aggregate t1 In
                      (From w In HeliosData.documentoCajaDetalle
                       Join a In HeliosData.documentoCaja On New With {.IdDocumento = CInt(w.idDocumento)} Equals New With {.IdDocumento = a.idDocumento}
                       Where
                     w.idItem = det.idDocumento _
                        And a.tipoMovimiento = "DC"
                       Select New With {
                     w.montoSoles
                     }) Into Sum(t1.montoSoles)), Decimal?))).ToList




        For Each i In consulta
            objeto = New documentoLibroDiario

            objeto.idDocumento = i.idDocumento
            objeto.fecha = i.fecha
            objeto.tipoDoc = i.tipoDoc
            objeto.nroDoc = i.nroDoc
            objeto.importeMN = i.importeMN
            objeto.tipoRazonSocial = i.tipoRazonSocial
            objeto.razonSocial = i.razonSocial
            objeto.montoFacturado = i.MontoFacturado.GetValueOrDefault
            objeto.montoPago = i.MontoPago.GetValueOrDefault
            objeto.montoIgv = i.MontoFacturadoIgv.GetValueOrDefault



            lista.Add(objeto)
        Next


        Return lista
    End Function


    Public Function GrabarReconocmientoIngreso(documento As documento) As Integer
        Dim documentoBL As New documentoBL
        Dim docDetalle As New documentoLibroDiarioDetalle
        Dim AsientoBL As New AsientoBL
        Dim recursoBL As New recursoCostoDetalleBL
        Dim obj As New recursoCostoDetalle
        Dim numeracionBL As New numeracionBoletasBL
        Try
            Using ts As New TransactionScope


                Dim docLibroDiario As documentoLibroDiario = HeliosData.documentoLibroDiario.Where(Function(o) _
                                            o.idDocumento = documento.documentoLibroDiario.idDocReferencia).First()

                Dim cval As Integer = 0
                cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(documento.documentoLibroDiario.IdNumeracion))

                documentoBL.InsertDocAsiento(documento, cval)
                InsertCabeceraReconocimientoIngreso(documento.documentoLibroDiario, documento.idDocumento, cval)
                For Each i As documentoLibroDiarioDetalle In documento.documentoLibroDiario.documentoLibroDiarioDetalle

                    Me.DetalleReconocimientoIngreso(i, documento.idDocumento)

                Next




                docLibroDiario.estado = "REC"
                'AsientoBL.SavebyGroupDoc(documento)

                HeliosData.SaveChanges()
                ts.Complete()
                Return documento.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub DetalleReconocimientoIngreso(detalle As documentoLibroDiarioDetalle, iddoc As Integer)

        Dim docDetalle As New documentoLibroDiarioDetalle
        Using ts As New TransactionScope
            docDetalle.idDocumento = iddoc
            'docDetalle.cuenta = detalle.cuenta
            docDetalle.descripcion = detalle.descripcion
            'docDetalle.tipoAsiento = detalle.tipoAsiento
            docDetalle.importeMN = detalle.importeMN
            docDetalle.importeME = detalle.importeME
            ' docDetalle.estadoPago = detalle.estadoPago
            ' docDetalle.tipoPago = detalle.tipoPago
            ' docDetalle.ididentificacion = detalle.ididentificacion
            ' docDetalle.tipoIdentificacion = detalle.tipoIdentificacion
            ' docDetalle.glosa = detalle.glosa
            docDetalle.usuarioActualizacion = detalle.usuarioActualizacion
            docDetalle.fechaActualizacion = detalle.fechaActualizacion
            'docDetalle.tipoCosto = detalle.tipoCosto

            ' HeliosData.documentoLibroDiarioDetalle.Add(docDetalle)
            HeliosData.documentoLibroDiarioDetalle.Add(docDetalle)
            HeliosData.SaveChanges()
            ts.Complete()

            detalle.secuencia = docDetalle.secuencia
        End Using

    End Sub

    Public Sub InsertCabeceraReconocimientoIngreso(ByVal documentocompraBE As documentoLibroDiario, intIdDocumento As Integer, val As Integer)
        Dim docCompra As New documentoLibroDiario
        Dim numeracionBL As New numeracionBoletasBL
        'Dim cval As Integer = 0
        Using ts As New TransactionScope
            docCompra.idDocumento = intIdDocumento
            docCompra.idEmpresa = documentocompraBE.idEmpresa
            docCompra.idEstablecimiento = documentocompraBE.idEstablecimiento
            docCompra.fecha = documentocompraBE.fecha
            docCompra.fechaPeriodo = documentocompraBE.fechaPeriodo
            docCompra.infoReferencial = documentocompraBE.infoReferencial
            docCompra.tipoDoc = documentocompraBE.tipoDoc
            docCompra.tipoRegistro = "NM"
            docCompra.tipoRazonSocial = documentocompraBE.tipoRazonSocial
            docCompra.razonSocial = documentocompraBE.razonSocial
            docCompra.fechaVct = documentocompraBE.fechaVct
            docCompra.modulo = documentocompraBE.modulo
            docCompra.estado = "HREC"
            docCompra.idCosto = documentocompraBE.idCosto
            ' cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(documentocompraBE.IdNumeracion))

            docCompra.nroDoc = val '
            docCompra.tipoOperacion = documentocompraBE.tipoOperacion
            docCompra.moneda = documentocompraBE.moneda

            docCompra.tipoCambio = documentocompraBE.tipoCambio
            docCompra.importeMN = documentocompraBE.importeMN
            docCompra.importeME = documentocompraBE.importeME
            docCompra.idReferencia = documentocompraBE.idReferencia
            'docCompra.tieneCosto = documentocompraBE.tieneCosto
            'docCompra.idCosto = documentocompraBE.idCosto
            docCompra.usuarioActualizacion = documentocompraBE.usuarioActualizacion
            docCompra.fechaActualizacion = documentocompraBE.fechaActualizacion

            HeliosData.documentoLibroDiario.Add(docCompra)
            HeliosData.SaveChanges()
            ts.Complete()
            documentocompraBE.serie = documentocompraBE.serie
            documentocompraBE.nroDoc = val
            '   documentocompraBE.idDocumento = docCompra.idDocumento
        End Using
    End Sub

    Public Function ListaRecursosGastoLibroEntregable(compraBE As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim consulta = (From n In HeliosData.documentoLibroDiario
                       Join det In HeliosData.documentoLibroDiarioDetalle
                       On det.idDocumento Equals n.idDocumento
                       Where n.idEmpresa = compraBE.idEmpresa And n.idEstablecimiento = compraBE.idEstablecimiento _
                        And n.tipoDoc = "9903" And det.tipoCosto = "PG"
                       Select det.idDocumento, n.tipoOperacion,
                       n.tipoDoc, n.nroDoc, n.moneda, n.fecha,
                       det.secuencia, det.idItem, det.cuenta, det.descripcion,
                       det.importeMN, det.importeME, det.tipoAsiento, n.infoReferencial).ToList




        'Dim consulta = (From n In HeliosData.documentoLibroDiario
        '                Join det In HeliosData.documentoLibroDiarioDetalle
        '                On det.idDocumento Equals n.idDocumento
        '                Join REC In HeliosData.recursoCosto
        '                        On REC.idCosto Equals det.idCosto
        '                Where n.idEmpresa = compraBE.idEmpresa And n.idEstablecimiento = compraBE.idEstablecimiento _
        '                 And n.tipoDoc = "9903" And det.idCosto = compraBE.idCosto And det.tipoCosto = "PG"
        '                Select det.idDocumento, n.tipoOperacion,
        '                n.tipoDoc, n.nroDoc, n.moneda, n.fecha,
        '                det.secuencia, det.idItem, det.cuenta, det.descripcion,
        '                det.importeMN, det.importeME, det.tipoAsiento, det.tipoCosto, det.idCosto, REC.nombreCosto,
        '                    cuentaCosto = (From j In HeliosData.cuentaplanContableEmpresa
        '                                   Where j.idCosto = det.idCosto
        '                                   Select j.cuenta).First).ToList


        For Each i In consulta

            'Dim codigoCuenta = Mid(i.cuenta, 1, 2)

            'Select Case Val(codigoCuenta)
            '    Case 62 To 68

            doccompra = New documentoLibroDiarioDetalle
            'doccompra.idCosto = i.idCosto.GetValueOrDefault
            ' doccompra.NombreProyectoGeneral = i.Nameproyecto
            doccompra.idDocumento = i.idDocumento

            doccompra.tipoDocumento = i.tipoDoc
            doccompra.nroDoc = i.nroDoc
            doccompra.moneda = i.moneda
            doccompra.fecha = i.fecha
            doccompra.idDocumento = i.idDocumento
            doccompra.secuencia = i.secuencia
            doccompra.cuenta = i.cuenta
            doccompra.descripcion = i.descripcion
            doccompra.cuenta = i.cuenta
            doccompra.importeMN = i.importeMN
            doccompra.importeME = i.importeME
            doccompra.operacion = i.tipoOperacion
            doccompra.tipoAsiento = i.tipoAsiento
            doccompra.glosa = i.infoReferencial
            'doccompra.idCosto = i.idCosto
            'doccompra.tipoCosto = i.tipoCosto
            'doccompra.NombreRazon = i.nombreCosto
            'doccompra.cuentaCosto = i.cuentaCosto
            compraLista.Add(doccompra)
            'End Select
        Next
        Return compraLista
    End Function

    Public Function GetRecuperarAporteExistencia(be As documento) As documentoLibroDiario
        Dim documentoBL As New documentoBL
        Dim documentoLibroBL As New documentoLibroDiarioBL

        Dim documentoRec = HeliosData.documentoLibroDiario.Where(Function(o) o.idEmpresa = be.idEmpresa And o.tipoRegistro = "APT_EXT").FirstOrDefault

        If documentoRec Is Nothing Then
            Using ts As New TransactionScope
                documentoBL.Insert(be)
                documentoLibroBL.InsertCabecera(be.documentoLibroDiario, be.idDocumento)
                ts.Complete()
                be.documentoLibroDiario.idDocumento = be.idDocumento
                GetRecuperarAporteExistencia = be.documentoLibroDiario
                HeliosData.SaveChanges()
            End Using
        Else
            '  Dim documentoRec = HeliosData.documentoLibroDiario.Where(Function(o) o.idEmpresa = be.idEmpresa And o.tipoRegistro = "APT_EXT").FirstOrDefault
            GetRecuperarAporteExistencia = documentoRec
        End If

    End Function

    Public Function ListaRecursosCostoLibro(compraBE As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)

        Dim consulta = (From n In HeliosData.documentoLibroDiario _
                        Join det In HeliosData.documentoLibroDiarioDetalle _
                        On det.idDocumento Equals n.idDocumento _
                        Where n.idEmpresa = compraBE.idEmpresa And n.idEstablecimiento = compraBE.idEstablecimiento _
                        And n.fechaPeriodo = compraBE.fechaPeriodo And n.tipoDoc = "9903" _
                        And det.idCosto Is Nothing
                        Select det.idDocumento, n.tipoOperacion, _
                        n.tipoDoc, n.nroDoc, n.moneda, n.fecha, _
                        det.secuencia, det.idItem, det.cuenta, det.descripcion, _
                        det.importeMN, det.importeME, det.tipoAsiento).ToList


        For Each i In consulta

            Dim codigoCuenta = Mid(i.cuenta, 1, 2)

            Select Case Val(codigoCuenta)
                Case 62 To 68

                    doccompra = New documentoLibroDiarioDetalle
                    'doccompra.idCosto = i.idCosto.GetValueOrDefault
                    ' doccompra.NombreProyectoGeneral = i.Nameproyecto
                    doccompra.idDocumento = i.idDocumento

                    doccompra.tipoDocumento = i.tipoDoc
                    doccompra.nroDoc = i.nroDoc
                    doccompra.moneda = i.moneda
                    doccompra.fecha = i.fecha
                    doccompra.idDocumento = i.idDocumento
                    doccompra.secuencia = i.secuencia
                    doccompra.cuenta = i.cuenta
                    doccompra.descripcion = i.descripcion
                    doccompra.cuenta = i.cuenta
                    doccompra.importeMN = i.importeMN
                    doccompra.importeME = i.importeME
                    doccompra.operacion = i.tipoOperacion
                    doccompra.tipoAsiento = i.tipoAsiento
                    compraLista.Add(doccompra)
            End Select
        Next
        Return compraLista
    End Function


    Public Function ListaRecursosCostoLibroEntregable(compraBE As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)



        Dim consulta = (From n In HeliosData.documentoLibroDiario
                        Join det In HeliosData.documentoLibroDiarioDetalle
                        On det.idDocumento Equals n.idDocumento
                        Where n.idEmpresa = compraBE.idEmpresa And n.idEstablecimiento = compraBE.idEstablecimiento _
                         And n.tipoDoc = "9903" And det.tipoCosto = "PC"
                        Select det.idDocumento, n.tipoOperacion,
                        n.tipoDoc, n.nroDoc, n.moneda, n.fecha,
                        det.secuencia, det.idItem, det.cuenta, det.descripcion,
                        det.importeMN, det.importeME, det.tipoAsiento, n.infoReferencial).ToList

        'Dim consulta = (From n In HeliosData.documentoLibroDiario
        '                Join det In HeliosData.documentoLibroDiarioDetalle
        '                On det.idDocumento Equals n.idDocumento
        '                Join REC In HeliosData.recursoCosto
        '                On REC.idCosto Equals det.idCosto
        '                Where n.idEmpresa = compraBE.idEmpresa And n.idEstablecimiento = compraBE.idEstablecimiento _
        '                 And n.tipoDoc = "9903" And det.idCosto = compraBE.idCosto And det.tipoCosto = "PC"
        '                Select det.idDocumento, n.tipoOperacion,
        '                n.tipoDoc, n.nroDoc, n.moneda, n.fecha,
        '                det.secuencia, det.idItem, det.cuenta, det.descripcion,
        '                det.importeMN, det.importeME, det.tipoAsiento, det.tipoCosto, det.idCosto, REC.nombreCosto,
        '                    cuentaCosto = (From j In HeliosData.cuentaplanContableEmpresa
        '                                   Where j.idCosto = det.idCosto
        '                                   Select j.cuenta).FirstOrDefault).ToList


        For Each i In consulta

            Dim codigoCuenta = Mid(i.cuenta, 1, 2)

            'Select Case Val(codigoCuenta)
            '    Case 62 To 68

            doccompra = New documentoLibroDiarioDetalle
            'doccompra.idCosto = i.idCosto.GetValueOrDefault
            ' doccompra.NombreProyectoGeneral = i.Nameproyecto
            doccompra.idDocumento = i.idDocumento

            doccompra.tipoDocumento = i.tipoDoc
            doccompra.nroDoc = i.nroDoc
            doccompra.moneda = i.moneda
            doccompra.fecha = i.fecha
            doccompra.idDocumento = i.idDocumento
            doccompra.secuencia = i.secuencia
            doccompra.cuenta = i.cuenta
            doccompra.descripcion = i.descripcion
            doccompra.cuenta = i.cuenta
            doccompra.importeMN = i.importeMN
            doccompra.importeME = i.importeME
            doccompra.operacion = i.tipoOperacion
            doccompra.tipoAsiento = i.tipoAsiento
            doccompra.glosa = i.infoReferencial
            'doccompra.idCosto = i.idCosto
            'doccompra.tipoCosto = i.tipoCosto
            'doccompra.NombreRazon = i.nombreCosto
            'doccompra.cuentaCosto = i.cuentaCosto
            compraLista.Add(doccompra)
            ' End Select
        Next
        Return compraLista
    End Function

    Public Sub ActualizarDocumentoLibroDiarioASM(documento As documento)
        Dim librodetalleBL As New documentoLibroDiarioDetalleBL
        Dim asientoBL As New AsientoBL
        Dim docDetalle As New documentoLibroDiarioDetalle
        Dim recursoBL As New recursoCostoDetalleBL
        Try
            Using ts As New TransactionScope
                Dim docCabecera = HeliosData.documento.Where(Function(o) o.idDocumento = documento.idDocumento).FirstOrDefault
                docCabecera.fechaProceso = documento.documentoLibroDiario.fecha
                docCabecera.tipoOperacion = documento.tipoOperacion
                docCabecera.tipoEntidad = documento.tipoEntidad
                docCabecera.idEntidad = documento.idEntidad
                docCabecera.entidad = documento.entidad
                docCabecera.nrodocEntidad = documento.nrodocEntidad
                docCabecera.moneda = documento.moneda

                Dim asiento As documentoLibroDiario = HeliosData.documentoLibroDiario.Where(Function(o) o.idDocumento = documento.idDocumento).FirstOrDefault
                asiento.infoReferencial = documento.documentoLibroDiario.infoReferencial
                asiento.tipoOperacion = documento.tipoOperacion
                asiento.fecha = documento.documentoLibroDiario.fecha
                asiento.importeMN = documento.documentoLibroDiario.importeMN
                asiento.importeME = documento.documentoLibroDiario.importeME
                asiento.tieneCosto = documento.documentoLibroDiario.tieneCosto
                asiento.idCosto = documento.documentoLibroDiario.idCosto

                Dim mov As List(Of documentoLibroDiarioDetalle) = HeliosData.documentoLibroDiarioDetalle.Where(Function(o) o.idDocumento = documento.idDocumento).ToList

                For Each ob In mov
                    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(ob)
                    ' librodetalleBL.Delete(ob)
                Next
                asientoBL.DeleteGroup(documento.idDocumento)


                Select Case documento.documentoLibroDiario.tieneCosto
                    Case "S"
                        recursoBL.eliminarDetalleCostoByIdDocumento(documento.idDocumento)

                    Case Else

                End Select



                For Each i As documentoLibroDiarioDetalle In documento.documentoLibroDiario.documentoLibroDiarioDetalle
                    'docDetalle = New documentoLibroDiarioDetalle With {
                    '    .idDocumento = documento.idDocumento,
                    '    .cuenta = i.cuenta,
                    '    .idItem = i.idItem,
                    '    .descripcion = i.descripcion,
                    '    .tipoAsiento = i.tipoAsiento,
                    '    .importeMN = i.importeMN,
                    '    .tipoPago = i.tipoPago,
                    '    .importeME = i.importeME,
                    '    .usuarioActualizacion = i.usuarioActualizacion,
                    '    .fechaActualizacion = i.fechaActualizacion
                    '    }
                    'HeliosData.documentoLibroDiarioDetalle.Add(docDetalle)


                    Me.DetalleLibroDiarioSave(i, documento.idDocumento)


                    'If i.idCosto > 0 Then
                    '    Me.CosteoDetalleAst(i, documento.idDocumento)
                    'End If

                Next



                asientoBL.SavebyGroupDoc(documento)

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub





    Public Sub DetalleLibroDiarioSave(detalle As documentoLibroDiarioDetalle, iddoc As Integer)

        Dim docDetalle As New documentoLibroDiarioDetalle
        Using ts As New TransactionScope
            docDetalle.idDocumento = iddoc
            docDetalle.cuenta = detalle.cuenta
            docDetalle.descripcion = detalle.descripcion
            docDetalle.tipoAsiento = detalle.tipoAsiento
            docDetalle.importeMN = detalle.importeMN
            docDetalle.importeME = detalle.importeME
            docDetalle.estadoPago = detalle.estadoPago
            docDetalle.tipoPago = detalle.tipoPago
            docDetalle.ididentificacion = detalle.ididentificacion
            docDetalle.tipoIdentificacion = detalle.tipoIdentificacion
            docDetalle.glosa = detalle.glosa
            docDetalle.usuarioActualizacion = detalle.usuarioActualizacion
            docDetalle.fechaActualizacion = detalle.fechaActualizacion
            docDetalle.tipoCosto = detalle.tipoCosto
            ' HeliosData.documentoLibroDiarioDetalle.Add(docDetalle)
            HeliosData.documentoLibroDiarioDetalle.Add(docDetalle)
            HeliosData.SaveChanges()
            ts.Complete()

            detalle.secuencia = docDetalle.secuencia
        End Using

    End Sub

    Public Sub CosteoDetalleAst(detalle As documentoLibroDiarioDetalle, iddoc As Integer)

        Dim docDetalle As New recursoCostoDetalle

        'obj = New recursoCostoDetalle With
        Using ts As New TransactionScope
            docDetalle.idCosto = detalle.idCosto
            docDetalle.fechaRegistro = detalle.fechaRegistro
            docDetalle.iditem = detalle.idItem
            'docDetalle.destino = ""
            docDetalle.descripcion = detalle.descripcion
            docDetalle.um = "07"
            'docDetalle.cant = CDec(0)
            'docDetalle.puMN = CDec(0)
            'docDetalle.puME = CDec(0)
            docDetalle.montoMN = detalle.importeMN
            docDetalle.montoME = detalle.importeME
            docDetalle.documentoRef = iddoc
            docDetalle.itemRef = detalle.secuencia
            docDetalle.operacion = detalle.operacion
            docDetalle.procesado = detalle.procesado
            docDetalle.idProceso = detalle.idProceso
            docDetalle.tipoCosto = "RL"


            HeliosData.recursoCostoDetalle.Add(docDetalle)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
        'HeliosData.recursoCostoDetalle.Add(obj)
    End Sub

    Public Sub CambiarPeriodoLibroDiario(be As documentoLibroDiario)
        Using ts As New TransactionScope
            Dim obj = HeliosData.documentoLibroDiario.Where(Function(o) o.idDocumento = be.idDocumento).FirstOrDefault
            obj.fechaPeriodo = be.fechaPeriodo

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function UbicarCobrosPorAsientoManualRazon(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, monedaTipo As String) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim cronogramabl As New CronogramaBL
        Dim cronograma As New Cronograma
        Dim list As New List(Of String)


        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        'list.Add(TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION)
        'list.Add(TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION)

        list.Add(TIPO_COMPRA.COMPRA)
        list.Add(TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO)
        list.Add(TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS)
        'list.Add(TIPO_COMPRA.COMPRA_ANTICIPADA)
        list.Add("APT")

        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle _
                         Join doc In HeliosData.documentoLibroDiario _
                         On doc.idDocumento Equals n.idDocumento _
                       Group Join cajadet In HeliosData.documentoCajaDetalle _
                       On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle _
                       Into ords = Group _
                       From c In ords.DefaultIfEmpty _
                       Where doc.idEmpresa = strEmpresa And doc.idEstablecimiento = intIdEstablecimiento And doc.fecha.Value.Year = AnioGeneral _
                       And doc.razonSocial = strRuc And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "C" And doc.moneda = monedaTipo _
                             Group c By n.idDocumento, n.secuencia, doc.fecha, doc.fechaVct,
                       doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.tipoCambio, doc.fechaPeriodo, n.descripcion, n.cuenta,
                       n.importeME, n.estadoPago Into g = Group _
                       Select New With {
                                      .idDocumento = idDocumento,
                                      .secuencia = secuencia,
                                      .descripcion = descripcion,
                                      .cuenta = cuenta,
                                      .fechaPeriodo = fechaPeriodo,
                                      .fechaDoc = fecha,
                                      .fechaVcto = fechaVct,
                                      .numeroDoc = nroDoc,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .ImporteNacional = importeMN,
                                      .tipoCambio = tipoCambio,
                                      .ImporteExtranjero = importeME,
                                      .estadoCobro = estadoPago,
                                      .SumaTransMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                       .SumaTransME = g.Sum(Function(o) (o.montoUsd)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            doccompra.secuencia = i.secuencia
            doccompra.descripcion = i.descripcion
            doccompra.cuenta = i.cuenta
            doccompra.fechaPeriodo = i.fechaPeriodo
            doccompra.FechaDoc = i.fechaDoc
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.moneda = i.moneda
            doccompra.importeMN = i.ImporteNacional
            doccompra.tipoCambio = i.tipoCambio
            doccompra.importeME = i.ImporteExtranjero
            doccompra.estadoPago = i.estadoCobro
            doccompra.fechaVcto = i.fechaVcto

            'cronograma = cronogramabl.ObtenerMontoProgramadoAsiento(i.idDocumento, i.secuencia)
            'doccompra.montocrono = cronograma.montoAutorizadoMN
            'doccompra.montocronome = cronograma.montoAutorizadoME


            ' objitemsaldoant = docanti.ObtenerPagosAnticipoPorDocumento(i.idDocumento)

            Select Case i.moneda
                Case 1
                    'doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault) + objitemsaldoant.MontoPagadoSoles).ToString("N2")
                    'doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD
                    doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault)).ToString("N2")
                    doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault
                Case 2
                    'doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault) + objitemsaldoant.MontoPagadoSoles).ToString("N2")
                    'doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD
                    doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault)).ToString("N2")
                    doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault
            End Select

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function UbicarPagosPorAsientoManualRazon(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, monedaTipo As String) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim cronogramabl As New CronogramaBL
        Dim cronograma As New Cronograma
        Dim list As New List(Of String)


        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        'list.Add(TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION)
        'list.Add(TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION)

        list.Add(TIPO_COMPRA.COMPRA)
        list.Add(TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO)
        list.Add(TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS)
        'list.Add(TIPO_COMPRA.COMPRA_ANTICIPADA)
        list.Add("APT")

        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle _
                         Join doc In HeliosData.documentoLibroDiario _
                         On doc.idDocumento Equals n.idDocumento _
                       Group Join cajadet In HeliosData.documentoCajaDetalle _
                       On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle _
                       Into ords = Group _
                       From c In ords.DefaultIfEmpty _
                       Where doc.idEmpresa = strEmpresa And doc.idEstablecimiento = intIdEstablecimiento And doc.fecha.Value.Year = AnioGeneral _
                       And doc.razonSocial = strRuc And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "P" And doc.moneda = monedaTipo _
                             Group c By n.idDocumento, n.secuencia, doc.fecha, doc.fechaVct,
                       doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.tipoCambio, doc.fechaPeriodo, n.descripcion, n.cuenta,
                       n.importeME, n.estadoPago Into g = Group _
                       Select New With {
                                      .idDocumento = idDocumento,
                                      .secuencia = secuencia,
                                      .descripcion = descripcion,
                                      .cuenta = cuenta,
                                      .fechaPeriodo = fechaPeriodo,
                                      .fechaDoc = fecha,
                                      .fechaVcto = fechaVct,
                                      .numeroDoc = nroDoc,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .ImporteNacional = importeMN,
                                      .tipoCambio = tipoCambio,
                                      .ImporteExtranjero = importeME,
                                      .estadoCobro = estadoPago,
                                       .Conteo = ((Aggregate t1 In
                                        (From c In HeliosData.Cronograma
                                            Where
                                      c.idDocumentoRef = idDocumento And c.idDocumentoDetalleRef = secuencia And
                                    c.estado = "PN"
                                                 Select New With {
                                                c
                                         }) Into Count())),
                                      .SumaTransMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                       .SumaTransME = g.Sum(Function(o) (o.montoUsd)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            doccompra.secuencia = i.secuencia
            doccompra.descripcion = i.descripcion
            doccompra.cuenta = i.cuenta
            doccompra.fechaPeriodo = i.fechaPeriodo
            doccompra.FechaDoc = i.fechaDoc
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.moneda = i.moneda
            doccompra.importeMN = i.ImporteNacional
            doccompra.tipoCambio = i.tipoCambio
            doccompra.importeME = i.ImporteExtranjero
            doccompra.estadoPago = i.estadoCobro
            doccompra.fechaVcto = i.fechaVcto
            doccompra.conteoCuota = i.Conteo

            'cronograma = cronogramabl.ObtenerMontoProgramadoAsiento(i.idDocumento, i.secuencia)
            'doccompra.montocrono = cronograma.montoAutorizadoMN
            'doccompra.montocronome = cronograma.montoAutorizadoME


            ' objitemsaldoant = docanti.ObtenerPagosAnticipoPorDocumento(i.idDocumento)

            Select Case i.moneda
                Case 1
                    'doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault) + objitemsaldoant.MontoPagadoSoles).ToString("N2")
                    'doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD
                    doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault)).ToString("N2")
                    doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault
                Case 2
                    'doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault) + objitemsaldoant.MontoPagadoSoles).ToString("N2")
                    'doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD
                    doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault)).ToString("N2")
                    doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault
            End Select

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Function UbicarTodoPagosAsientoManualMNME(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim cronogramabl As New CronogramaBL
        Dim cronograma As New Cronograma
        Dim entidadbl As New entidadBL
        Dim personabl As New PersonaBL
        Dim list As New List(Of String)


        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        'list.Add(TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION)
        'list.Add(TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION)

        'list.Add(TIPO_COMPRA.COMPRA)
        'list.Add(TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO)
        'list.Add(TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS)
        ''list.Add(TIPO_COMPRA.COMPRA_ANTICIPADA)
        'list.Add("APT")

        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle _
                         Join doc In HeliosData.documentoLibroDiario _
                         On doc.idDocumento Equals n.idDocumento _
                       Group Join cajadet In HeliosData.documentoCajaDetalle _
                       On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle _
                       Into ords = Group _
                       From c In ords.DefaultIfEmpty _
                       Where doc.idEmpresa = strEmpresa And doc.idEstablecimiento = intIdEstablecimiento And doc.fecha.Value.Year = AnioGeneral _
                        And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "P" _
                             Group c By n.idDocumento, n.secuencia, doc.fecha, doc.fechaVct,
                       doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.tipoCambio, doc.fechaPeriodo, n.descripcion, n.cuenta, doc.razonSocial, doc.tipoRazonSocial,
                       n.importeME, n.estadoPago Into g = Group _
                       Select New With {
                                      .idDocumento = idDocumento,
                                      .secuencia = secuencia,
                                      .descripcion = descripcion,
                                      .cuenta = cuenta,
                                      .razonsocial = razonSocial,
                                      .tiporazon = tipoRazonSocial,
                                      .fechaPeriodo = fechaPeriodo,
                                      .fechaDoc = fecha,
                                      .fechaVcto = fechaVct,
                                      .numeroDoc = nroDoc,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .ImporteNacional = importeMN,
                                      .tipoCambio = tipoCambio,
                                      .ImporteExtranjero = importeME,
                                      .estadoCobro = estadoPago,
                                      .SumaTransMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                       .SumaTransME = g.Sum(Function(o) (o.montoUsd)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            doccompra.secuencia = i.secuencia
            doccompra.descripcion = i.descripcion
            doccompra.cuenta = i.cuenta
            doccompra.fechaPeriodo = i.fechaPeriodo
            doccompra.FechaDoc = i.fechaDoc
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.moneda = i.moneda
            doccompra.importeMN = i.ImporteNacional
            doccompra.tipoCambio = i.tipoCambio
            doccompra.importeME = i.ImporteExtranjero
            doccompra.estadoPago = i.estadoCobro
            doccompra.fechaVcto = i.fechaVcto
            doccompra.razonSocial = i.razonsocial
            doccompra.tipoRazon = i.tiporazon

            If i.tiporazon = "PR" Then
                doccompra.NombreRazon = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, i.tiporazon, i.razonsocial).nombreCompleto
            ElseIf i.tiporazon = "CL" Then
                doccompra.NombreRazon = entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, i.tiporazon, i.razonsocial).nombreCompleto
            ElseIf i.tiporazon = "TR" Then
                doccompra.NombreRazon = personabl.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonsocial, i.tiporazon).nombreCompleto
            End If

            cronograma = cronogramabl.ObtenerMontoProgramadoAsiento(i.idDocumento, i.secuencia)
            doccompra.montocrono = cronograma.montoAutorizadoMN
            doccompra.montocronome = cronograma.montoAutorizadoME


            ' objitemsaldoant = docanti.ObtenerPagosAnticipoPorDocumento(i.idDocumento)

            Select Case i.moneda
                Case 1
                    'doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault) + objitemsaldoant.MontoPagadoSoles).ToString("N2")
                    'doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD
                    doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault)).ToString("N2")
                    doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault
                Case 2
                    'doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault) + objitemsaldoant.MontoPagadoSoles).ToString("N2")
                    'doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD
                    doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault)).ToString("N2")
                    doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault
            End Select

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function ConteoDeAsientosNoNegociadosCobro() As Integer
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim cronogramabl As New CronogramaBL
        Dim cronograma As New Cronograma
        'Dim list As New List(Of String)
        Dim conteo As Integer = 0


        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        'list.Add(TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION)
        'list.Add(TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION)

        'list.Add(TIPO_COMPRA.COMPRA)
        'list.Add(TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO)
        'list.Add(TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS)
        ''list.Add(TIPO_COMPRA.COMPRA_ANTICIPADA)
        'list.Add("APT")

        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle _
                         Join doc In HeliosData.documentoLibroDiario _
                         On doc.idDocumento Equals n.idDocumento _
                       Group Join cajadet In HeliosData.documentoCajaDetalle _
                       On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle _
                       Into ords = Group _
                       From c In ords.DefaultIfEmpty _
                       Where doc.idEmpresa = Gempresas.IdEmpresaRuc And doc.idEstablecimiento = GEstableciento.IdEstablecimiento And doc.fecha.Value.Year = AnioGeneral _
                       And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "C" _
                             Group c By n.idDocumento, n.secuencia, doc.fecha, doc.fechaVct,
                       doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.tipoCambio, doc.fechaPeriodo, n.descripcion, n.cuenta,
                       n.importeME, n.estadoPago Into g = Group _
                       Select New With {
                                      .idDocumento = idDocumento,
                                      .secuencia = secuencia,
                                      .descripcion = descripcion,
                                      .cuenta = cuenta,
                                      .fechaPeriodo = fechaPeriodo,
                                      .fechaDoc = fecha,
                                      .fechaVcto = fechaVct,
                                      .numeroDoc = nroDoc,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .ImporteNacional = importeMN,
                                      .tipoCambio = tipoCambio,
                                      .ImporteExtranjero = importeME,
                                      .estadoCobro = estadoPago,
                                      .SumaTransMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                       .SumaTransME = g.Sum(Function(o) (o.montoUsd)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            doccompra.secuencia = i.secuencia
            doccompra.descripcion = i.descripcion
            doccompra.cuenta = i.cuenta
            doccompra.fechaPeriodo = i.fechaPeriodo
            doccompra.FechaDoc = i.fechaDoc
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.moneda = i.moneda
            doccompra.importeMN = i.ImporteNacional
            doccompra.tipoCambio = i.tipoCambio
            doccompra.importeME = i.ImporteExtranjero
            doccompra.estadoPago = i.estadoCobro
            doccompra.fechaVcto = i.fechaVcto

            cronograma = cronogramabl.ObtenerMontoProgramadoAsiento(i.idDocumento, i.secuencia)
            doccompra.montocrono = cronograma.montoAutorizadoMN
            doccompra.montocronome = cronograma.montoAutorizadoME


            ' objitemsaldoant = docanti.ObtenerPagosAnticipoPorDocumento(i.idDocumento)

            Select Case i.moneda
                Case 1
                    'doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault) + objitemsaldoant.MontoPagadoSoles).ToString("N2")
                    'doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD
                    doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault)).ToString("N2")
                    doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault

                    If doccompra.importeMN - doccompra.PagoSumaMN - doccompra.montocrono > 0 Then
                        conteo += 1
                    End If
                Case 2
                    'doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault) + objitemsaldoant.MontoPagadoSoles).ToString("N2")
                    'doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD
                    doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault)).ToString("N2")
                    doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault
                    If doccompra.importeME - doccompra.PagoSumaME - doccompra.montocronome > 0 Then
                        conteo += 1
                    End If
            End Select


        Next
        Return conteo
    End Function

    Public Function ConteoDeAsientosNoNegociados() As Integer
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim cronogramabl As New CronogramaBL
        Dim cronograma As New Cronograma
        Dim list As New List(Of String)
        Dim conteo As Integer = 0


        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        'list.Add(TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION)
        'list.Add(TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION)

        list.Add(TIPO_COMPRA.COMPRA)
        list.Add(TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO)
        list.Add(TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS)
        'list.Add(TIPO_COMPRA.COMPRA_ANTICIPADA)
        list.Add("APT")

        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle _
                         Join doc In HeliosData.documentoLibroDiario _
                         On doc.idDocumento Equals n.idDocumento _
                       Group Join cajadet In HeliosData.documentoCajaDetalle _
                       On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle _
                       Into ords = Group _
                       From c In ords.DefaultIfEmpty _
                       Where doc.idEmpresa = Gempresas.IdEmpresaRuc And doc.idEstablecimiento = GEstableciento.IdEstablecimiento And doc.fecha.Value.Year = AnioGeneral _
                       And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "P" _
                             Group c By n.idDocumento, n.secuencia, doc.fecha, doc.fechaVct,
                       doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.tipoCambio, doc.fechaPeriodo, n.descripcion, n.cuenta,
                       n.importeME, n.estadoPago Into g = Group _
                       Select New With {
                                      .idDocumento = idDocumento,
                                      .secuencia = secuencia,
                                      .descripcion = descripcion,
                                      .cuenta = cuenta,
                                      .fechaPeriodo = fechaPeriodo,
                                      .fechaDoc = fecha,
                                      .fechaVcto = fechaVct,
                                      .numeroDoc = nroDoc,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .ImporteNacional = importeMN,
                                      .tipoCambio = tipoCambio,
                                      .ImporteExtranjero = importeME,
                                      .estadoCobro = estadoPago,
                                      .SumaTransMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                       .SumaTransME = g.Sum(Function(o) (o.montoUsd)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            doccompra.secuencia = i.secuencia
            doccompra.descripcion = i.descripcion
            doccompra.cuenta = i.cuenta
            doccompra.fechaPeriodo = i.fechaPeriodo
            doccompra.FechaDoc = i.fechaDoc
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.moneda = i.moneda
            doccompra.importeMN = i.ImporteNacional
            doccompra.tipoCambio = i.tipoCambio
            doccompra.importeME = i.ImporteExtranjero
            doccompra.estadoPago = i.estadoCobro
            doccompra.fechaVcto = i.fechaVcto

            cronograma = cronogramabl.ObtenerMontoProgramadoAsiento(i.idDocumento, i.secuencia)
            doccompra.montocrono = cronograma.montoAutorizadoMN
            doccompra.montocronome = cronograma.montoAutorizadoME


            ' objitemsaldoant = docanti.ObtenerPagosAnticipoPorDocumento(i.idDocumento)

            Select Case i.moneda
                Case 1
                    'doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault) + objitemsaldoant.MontoPagadoSoles).ToString("N2")
                    'doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD
                    doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault)).ToString("N2")
                    doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault

                    If doccompra.importeMN - doccompra.PagoSumaMN - doccompra.montocrono > 0 Then
                        conteo += 1
                    End If
                Case 2
                    'doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault) + objitemsaldoant.MontoPagadoSoles).ToString("N2")
                    'doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD
                    doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault)).ToString("N2")
                    doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault
                    If doccompra.importeME - doccompra.PagoSumaME - doccompra.montocronome > 0 Then
                        conteo += 1
                    End If
            End Select


        Next
        Return conteo
    End Function


    Public Function CobrosGeneralesAsiento() As List(Of documentoLibroDiarioDetalle)

        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim list As New List(Of String)
        Dim listcrono As New List(Of String)

        listcrono.Add("PN")
        listcrono.Add("AP")
        listcrono.Add("OB")


        Dim consulta = (From mov In HeliosData.documentoLibroDiarioDetalle
                        Where mov.tipoPago = "C" _
                        Select
                        mov.cuenta, mov.descripcion,
                        PagoDeuda = (CType((Aggregate t1 In
                        (From m In HeliosData.documentoCajaDetalle
                         Join b In HeliosData.documentoLibroDiarioDetalle On New With {.IdDocumento = CInt(m.documentoAfectado)} Equals New With {.IdDocumento = b.IdDocumento} And New With {.secuencia = CInt(m.documentoAfectadodetalle)} Equals New With {.secuencia = b.secuencia}
                        Join a In HeliosData.documentoLibroDiario On New With {.IdDocumento = CInt(b.IdDocumento)} Equals New With {.IdDocumento = a.IdDocumento}
                        Where
                        a.Moneda = "1" And a.fecha.Value.Year = AnioGeneral And a.idEmpresa = Gempresas.IdEmpresaRuc And
                         b.cuenta = mov.cuenta And b.tipoPago = "C"
                        Select New With {
                        m.montoSolesTransacc
                        }) Into Sum(t1.montoSolesTransacc)), Decimal?)),
                        Deuda = (CType((Aggregate t1 In
                        (From w In HeliosData.documentoLibroDiario
                         Join a In HeliosData.documentoLibroDiarioDetalle On New With {.IdDocumento = CInt(w.idDocumento)} Equals New With {.IdDocumento = a.IdDocumento}
                        Where
                        w.moneda = "1" And w.fecha.Value.Year = AnioGeneral And w.idEmpresa = Gempresas.IdEmpresaRuc And
                        a.cuenta = mov.cuenta And a.tipoPago = "C"
                        Select New With {
                        a.importeMN
                        }) Into Sum(t1.importeMN)), Decimal?)),
                        MontoProgramado = (CType((Aggregate t1 In
                       (From m In HeliosData.Cronograma
                       Join b In HeliosData.documentoLibroDiarioDetalle On New With {.IdDocumento = CInt(m.idDocumentoRef)} Equals New With {.IdDocumento = b.IdDocumento} And New With {.secuencia = CInt(m.idDocumentoDetalleRef)} Equals New With {.secuencia = b.secuencia}
                        Join a In HeliosData.documentoLibroDiario On New With {.IdDocumento = CInt(b.IdDocumento)} Equals New With {.IdDocumento = a.IdDocumento}
                       Where
                       m.moneda = "1" And a.fecha.Value.Year = AnioGeneral And a.idEmpresa = Gempresas.IdEmpresaRuc And
                       b.cuenta = mov.cuenta And b.tipoPago = "C" And
                     listcrono.Contains(m.estado)
                       Select New With {
                       m.montoAutorizadoMN
                      }) Into Sum(t1.montoAutorizadoMN)), Decimal?)),
                      PagoDeudaME = (CType((Aggregate t1 In
                      (From m In HeliosData.documentoCajaDetalle
                        Join b In HeliosData.documentoLibroDiarioDetalle On New With {.IdDocumento = CInt(m.documentoAfectado)} Equals New With {.IdDocumento = b.IdDocumento} And New With {.secuencia = CInt(m.documentoAfectadodetalle)} Equals New With {.secuencia = b.secuencia}
                        Join a In HeliosData.documentoLibroDiario On New With {.IdDocumento = CInt(b.IdDocumento)} Equals New With {.IdDocumento = a.IdDocumento}
                      Where
                      a.moneda = "2" And a.fecha.Value.Year = AnioGeneral And a.idEmpresa = Gempresas.IdEmpresaRuc And
                         b.cuenta = mov.cuenta And b.tipoPago = "C"
                      Select New With {
                      m.montoUsdTransacc
                      }) Into Sum(t1.montoUsdTransacc)), Decimal?)),
                      DeudaME = (CType((Aggregate t1 In
                      (From w In HeliosData.documentoLibroDiario
                         Join a In HeliosData.documentoLibroDiarioDetalle On New With {.IdDocumento = CInt(w.idDocumento)} Equals New With {.IdDocumento = a.IdDocumento}
                      Where
                     w.moneda = "2" And w.fecha.Value.Year = AnioGeneral And w.idEmpresa = Gempresas.IdEmpresaRuc And
                        a.cuenta = mov.cuenta And a.tipoPago = "C"
                     Select New With {
                     a.importeME
                     }) Into Sum(t1.importeME)), Decimal?)),
                     MontoProgramadoME = (CType((Aggregate t1 In
                     (From m In HeliosData.Cronograma
                       Join b In HeliosData.documentoLibroDiarioDetalle On New With {.IdDocumento = CInt(m.idDocumentoRef)} Equals New With {.IdDocumento = b.IdDocumento} And New With {.secuencia = CInt(m.idDocumentoDetalleRef)} Equals New With {.secuencia = b.secuencia}
                        Join a In HeliosData.documentoLibroDiario On New With {.IdDocumento = CInt(b.IdDocumento)} Equals New With {.IdDocumento = a.IdDocumento}
                     Where
                     m.moneda = "2" And a.fecha.Value.Year = AnioGeneral And a.idEmpresa = Gempresas.IdEmpresaRuc And
                       b.cuenta = mov.cuenta And b.tipoPago = "C" And
                    listcrono.Contains(m.estado)
                    Select New With {
                     m.montoAutorizadoME
                     }) Into Sum(t1.montoAutorizadoME)), Decimal?))).Distinct().ToList


        For Each i In consulta
            doccompra = New documentoLibroDiarioDetalle
            doccompra.cuenta = i.cuenta
            doccompra.descripcion = i.descripcion
            doccompra.importeMN = i.Deuda.GetValueOrDefault
            doccompra.importeME = i.DeudaME.GetValueOrDefault
            doccompra.ImportePagoMN = i.PagoDeuda.GetValueOrDefault
            doccompra.ImportePagoME = i.PagoDeudaME.GetValueOrDefault
            doccompra.montocrono = i.MontoProgramado.GetValueOrDefault
            doccompra.montocronome = i.MontoProgramadoME.GetValueOrDefault
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function



    Public Function UbicarCobrosPorAsientoManualMNME(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim cronogramabl As New CronogramaBL
        Dim cronograma As New Cronograma
        Dim list As New List(Of String)


        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        'list.Add(TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION)
        'list.Add(TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION)

        list.Add(TIPO_COMPRA.COMPRA)
        list.Add(TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO)
        list.Add(TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS)
        'list.Add(TIPO_COMPRA.COMPRA_ANTICIPADA)
        list.Add("APT")

        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle _
                         Join doc In HeliosData.documentoLibroDiario _
                         On doc.idDocumento Equals n.idDocumento _
                       Group Join cajadet In HeliosData.documentoCajaDetalle _
                       On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle _
                       Into ords = Group _
                       From c In ords.DefaultIfEmpty _
                       Where doc.idEmpresa = strEmpresa And doc.idEstablecimiento = intIdEstablecimiento And doc.fecha.Value.Year = AnioGeneral _
                       And doc.razonSocial = strRuc And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "C" _
                             Group c By n.idDocumento, n.secuencia, doc.fecha, doc.fechaVct,
                       doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.tipoCambio, doc.fechaPeriodo, n.descripcion, n.cuenta,
                       n.importeME, n.estadoPago Into g = Group _
                       Select New With {
                                      .idDocumento = idDocumento,
                                      .secuencia = secuencia,
                                      .descripcion = descripcion,
                                      .cuenta = cuenta,
                                      .fechaPeriodo = fechaPeriodo,
                                      .fechaDoc = fecha,
                                      .fechaVcto = fechaVct,
                                      .numeroDoc = nroDoc,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .ImporteNacional = importeMN,
                                      .tipoCambio = tipoCambio,
                                      .ImporteExtranjero = importeME,
                                      .estadoCobro = estadoPago,
                                      .SumaTransMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                       .SumaTransME = g.Sum(Function(o) (o.montoUsd)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            doccompra.secuencia = i.secuencia
            doccompra.descripcion = i.descripcion
            doccompra.cuenta = i.cuenta
            doccompra.fechaPeriodo = i.fechaPeriodo
            doccompra.FechaDoc = i.fechaDoc
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.moneda = i.moneda
            doccompra.importeMN = i.ImporteNacional
            doccompra.tipoCambio = i.tipoCambio
            doccompra.importeME = i.ImporteExtranjero
            doccompra.estadoPago = i.estadoCobro
            doccompra.fechaVcto = i.fechaVcto

            cronograma = cronogramabl.ObtenerMontoProgramadoAsiento(i.idDocumento, i.secuencia)
            doccompra.montocrono = cronograma.montoAutorizadoMN
            doccompra.montocronome = cronograma.montoAutorizadoME


            ' objitemsaldoant = docanti.ObtenerPagosAnticipoPorDocumento(i.idDocumento)

            Select Case i.moneda
                Case 1
                    'doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault) + objitemsaldoant.MontoPagadoSoles).ToString("N2")
                    'doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD
                    doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault)).ToString("N2")
                    doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault
                Case 2
                    'doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault) + objitemsaldoant.MontoPagadoSoles).ToString("N2")
                    'doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD
                    doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault)).ToString("N2")
                    doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault
            End Select

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function UbicarPagosPorAsientoManualMNME(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim cronogramabl As New CronogramaBL
        Dim cronograma As New Cronograma
        Dim list As New List(Of String)


        Dim docanti As New documentoAnticipoDetalleBL
        Dim objitemsaldoant As New documentoAnticipoDetalle

        'list.Add(TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION)
        'list.Add(TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION)

        list.Add(TIPO_COMPRA.COMPRA)
        list.Add(TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO)
        list.Add(TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS)
        'list.Add(TIPO_COMPRA.COMPRA_ANTICIPADA)
        list.Add("APT")

        Dim consulta2 = (From n In HeliosData.documentoLibroDiarioDetalle _
                         Join doc In HeliosData.documentoLibroDiario _
                         On doc.idDocumento Equals n.idDocumento _
                       Group Join cajadet In HeliosData.documentoCajaDetalle _
                       On n.idDocumento Equals cajadet.documentoAfectado And n.secuencia Equals cajadet.documentoAfectadodetalle _
                       Into ords = Group _
                       From c In ords.DefaultIfEmpty _
                       Where doc.idEmpresa = strEmpresa And doc.idEstablecimiento = intIdEstablecimiento And doc.fecha.Value.Year = AnioGeneral _
                       And doc.razonSocial = strRuc And n.estadoPago = "PN" And doc.tipoRegistro = "NM" And n.tipoPago = "P" _
                             Group c By n.idDocumento, n.secuencia, doc.fecha, doc.fechaVct,
                       doc.nroDoc, doc.tipoDoc, doc.moneda, n.importeMN, doc.tipoCambio, doc.fechaPeriodo, n.descripcion, n.cuenta,
                       n.importeME, n.estadoPago Into g = Group _
                       Select New With {
                                      .idDocumento = idDocumento,
                                      .secuencia = secuencia,
                                      .descripcion = descripcion,
                                      .cuenta = cuenta,
                                      .fechaPeriodo = fechaPeriodo,
                                      .fechaDoc = fecha,
                                      .fechaVcto = fechaVct,
                                      .numeroDoc = nroDoc,
                                      .tipoDocumento = tipoDoc,
                                      .moneda = moneda,
                                      .ImporteNacional = importeMN,
                                      .tipoCambio = tipoCambio,
                                      .ImporteExtranjero = importeME,
                                      .estadoCobro = estadoPago,
                                      .SumaTransMN = g.Sum(Function(o) (o.montoSoles)),
                                      .SumaPagoMN = g.Sum(Function(o) (o.montoSoles)),
                                       .SumaTransME = g.Sum(Function(o) (o.montoUsd)),
                                      .SumaPagoME = g.Sum(Function(o) o.montoUsd)}).OrderBy(Function(o) o.fechaDoc).ToList


        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.idDocumento
            doccompra.secuencia = i.secuencia
            doccompra.descripcion = i.descripcion
            doccompra.cuenta = i.cuenta
            doccompra.fechaPeriodo = i.fechaPeriodo
            doccompra.FechaDoc = i.fechaDoc
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocumento = i.tipoDocumento
            doccompra.moneda = i.moneda
            doccompra.importeMN = i.ImporteNacional
            doccompra.tipoCambio = i.tipoCambio
            doccompra.importeME = i.ImporteExtranjero
            doccompra.estadoPago = i.estadoCobro
            doccompra.fechaVcto = i.fechaVcto

            cronograma = cronogramabl.ObtenerMontoProgramadoAsiento(i.idDocumento, i.secuencia)
            doccompra.montocrono = cronograma.montoAutorizadoMN
            doccompra.montocronome = cronograma.montoAutorizadoME


            ' objitemsaldoant = docanti.ObtenerPagosAnticipoPorDocumento(i.idDocumento)

            Select Case i.moneda
                Case 1
                    'doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault) + objitemsaldoant.MontoPagadoSoles).ToString("N2")
                    'doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD
                    doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault)).ToString("N2")
                    doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault
                Case 2
                    'doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault) + objitemsaldoant.MontoPagadoSoles).ToString("N2")
                    'doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault + objitemsaldoant.MontoPagadoUSD
                    doccompra.PagoSumaMN = CDec((i.SumaTransMN.GetValueOrDefault)).ToString("N2")
                    doccompra.PagoSumaME = i.SumaTransME.GetValueOrDefault
            End Select

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function



    Public Function DeudasGeneralesAsiento() As List(Of documentoLibroDiarioDetalle)

        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim list As New List(Of String)
        Dim listcrono As New List(Of String)

        listcrono.Add("PN")
        listcrono.Add("AP")
        listcrono.Add("OB")


        Dim consulta = (From mov In HeliosData.documentoLibroDiarioDetalle
                        Where mov.tipoPago = "P" _
                        Select
                        mov.cuenta, mov.descripcion,
                        PagoDeuda = (CType((Aggregate t1 In
                        (From m In HeliosData.documentoCajaDetalle
                         Join b In HeliosData.documentoLibroDiarioDetalle On New With {.IdDocumento = CInt(m.documentoAfectado)} Equals New With {.IdDocumento = b.IdDocumento} And New With {.secuencia = CInt(m.documentoAfectadodetalle)} Equals New With {.secuencia = b.secuencia}
                        Join a In HeliosData.documentoLibroDiario On New With {.IdDocumento = CInt(b.IdDocumento)} Equals New With {.IdDocumento = a.IdDocumento}
                        Where
                        a.Moneda = "1" And a.fecha.Value.Year = AnioGeneral And a.idEmpresa = Gempresas.IdEmpresaRuc And
                         b.cuenta = mov.cuenta And b.tipoPago = "P"
                        Select New With {
                        m.montoSolesTransacc
                        }) Into Sum(t1.montoSolesTransacc)), Decimal?)),
                        Deuda = (CType((Aggregate t1 In
                        (From w In HeliosData.documentoLibroDiario
                         Join a In HeliosData.documentoLibroDiarioDetalle On New With {.IdDocumento = CInt(w.idDocumento)} Equals New With {.IdDocumento = a.IdDocumento}
                        Where
                        w.moneda = "1" And w.fecha.Value.Year = AnioGeneral And w.idEmpresa = Gempresas.IdEmpresaRuc And
                        a.cuenta = mov.cuenta And a.tipoPago = "P"
                        Select New With {
                        a.importeMN
                        }) Into Sum(t1.importeMN)), Decimal?)),
                        MontoProgramado = (CType((Aggregate t1 In
                       (From m In HeliosData.Cronograma
                       Join b In HeliosData.documentoLibroDiarioDetalle On New With {.IdDocumento = CInt(m.idDocumentoRef)} Equals New With {.IdDocumento = b.IdDocumento} And New With {.secuencia = CInt(m.idDocumentoDetalleRef)} Equals New With {.secuencia = b.secuencia}
                        Join a In HeliosData.documentoLibroDiario On New With {.IdDocumento = CInt(b.IdDocumento)} Equals New With {.IdDocumento = a.IdDocumento}
                       Where
                       m.moneda = "1" And a.fecha.Value.Year = AnioGeneral And a.idEmpresa = Gempresas.IdEmpresaRuc And
                       b.cuenta = mov.cuenta And b.tipoPago = "P" And
                     listcrono.Contains(m.estado)
                       Select New With {
                       m.montoAutorizadoMN
                      }) Into Sum(t1.montoAutorizadoMN)), Decimal?)),
                      PagoDeudaME = (CType((Aggregate t1 In
                      (From m In HeliosData.documentoCajaDetalle
                        Join b In HeliosData.documentoLibroDiarioDetalle On New With {.IdDocumento = CInt(m.documentoAfectado)} Equals New With {.IdDocumento = b.IdDocumento} And New With {.secuencia = CInt(m.documentoAfectadodetalle)} Equals New With {.secuencia = b.secuencia}
                        Join a In HeliosData.documentoLibroDiario On New With {.IdDocumento = CInt(b.IdDocumento)} Equals New With {.IdDocumento = a.IdDocumento}
                      Where
                      a.moneda = "2" And a.fecha.Value.Year = AnioGeneral And a.idEmpresa = Gempresas.IdEmpresaRuc And
                         b.cuenta = mov.cuenta And b.tipoPago = "P"
                      Select New With {
                      m.montoUsdTransacc
                      }) Into Sum(t1.montoUsdTransacc)), Decimal?)),
                      DeudaME = (CType((Aggregate t1 In
                      (From w In HeliosData.documentoLibroDiario
                         Join a In HeliosData.documentoLibroDiarioDetalle On New With {.IdDocumento = CInt(w.idDocumento)} Equals New With {.IdDocumento = a.IdDocumento}
                      Where
                     w.moneda = "2" And w.fecha.Value.Year = AnioGeneral And w.idEmpresa = Gempresas.IdEmpresaRuc And
                        a.cuenta = mov.cuenta And a.tipoPago = "P"
                     Select New With {
                     a.importeME
                     }) Into Sum(t1.importeME)), Decimal?)),
                     MontoProgramadoME = (CType((Aggregate t1 In
                     (From m In HeliosData.Cronograma
                       Join b In HeliosData.documentoLibroDiarioDetalle On New With {.IdDocumento = CInt(m.idDocumentoRef)} Equals New With {.IdDocumento = b.IdDocumento} And New With {.secuencia = CInt(m.idDocumentoDetalleRef)} Equals New With {.secuencia = b.secuencia}
                        Join a In HeliosData.documentoLibroDiario On New With {.IdDocumento = CInt(b.IdDocumento)} Equals New With {.IdDocumento = a.IdDocumento}
                     Where
                     m.moneda = "2" And a.fecha.Value.Year = AnioGeneral And a.idEmpresa = Gempresas.IdEmpresaRuc And
                       b.cuenta = mov.cuenta And b.tipoPago = "P" And
                    listcrono.Contains(m.estado)
                    Select New With {
                     m.montoAutorizadoME
                     }) Into Sum(t1.montoAutorizadoME)), Decimal?))).Distinct().ToList


        For Each i In consulta
            doccompra = New documentoLibroDiarioDetalle
            doccompra.cuenta = i.cuenta
            doccompra.descripcion = i.descripcion
            doccompra.importeMN = i.Deuda.GetValueOrDefault
            doccompra.importeME = i.DeudaME.GetValueOrDefault
            doccompra.ImportePagoMN = i.PagoDeuda.GetValueOrDefault
            doccompra.ImportePagoME = i.PagoDeudaME.GetValueOrDefault
            doccompra.montocrono = i.MontoProgramado.GetValueOrDefault
            doccompra.montocronome = i.MontoProgramadoME.GetValueOrDefault
           
            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function



    Public Function UbicarGastosModulo(iddoc As Integer) As documentoLibroDiario


        Dim objeto As New documentoLibroDiario
        Dim consulta = HeliosData.documentoLibroDiario.Where(Function(o) o.idEmpresa = Gempresas.IdEmpresaRuc And o.idEstablecimiento = GEstableciento.IdEstablecimiento _
                                                                 And o.idDocumento = iddoc).FirstOrDefault

        objeto = New documentoLibroDiario
        objeto.idDocumento = consulta.idDocumento
        objeto.tipoRegistro = consulta.tipoRegistro
        objeto.infoReferencial = consulta.infoReferencial
        objeto.importeMN = consulta.importeMN
        objeto.importeME = consulta.importeME
        objeto.fecha = consulta.fecha
        objeto.fechaVct = consulta.fechaVct
        objeto.fechaPeriodo = consulta.fechaPeriodo
        objeto.tipoCambio = consulta.tipoCambio
        objeto.moneda = consulta.moneda


        Return objeto


    End Function

    Public Function GrabarGastoXModulo(documento As documento) As Integer
        Dim documentoBL As New documentoBL
        Dim docDetalle As New documentoLibroDiarioDetalle
        Dim AsientoBL As New AsientoBL
        Dim recursoBL As New recursoCostoDetalleBL
        Dim obj As New recursoCostoDetalle
        Dim numeracionBL As New numeracionBoletasBL
        Try
            Using ts As New TransactionScope
                Dim cval As Integer = 0
                cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(documento.documentoLibroDiario.IdNumeracion))


                documentoBL.InsertDocAsiento(documento, cval)
                InsertCabeceraLibro(documento.documentoLibroDiario, documento.idDocumento, cval)
                For Each i As documentoLibroDiarioDetalle In documento.documentoLibroDiario.documentoLibroDiarioDetalle
                    'docDetalle = New documentoLibroDiarioDetalle With {
                    '    .idDocumento = documento.idDocumento,
                    '    .cuenta = i.cuenta,
                    '    .descripcion = i.descripcion,
                    '    .tipoAsiento = i.tipoAsiento,
                    '    .importeMN = i.importeMN,
                    '    .importeME = i.importeME,
                    '    .estadoPago = i.estadoPago,
                    '    .tipoPago = i.tipoPago,
                    '    .ididentificacion = i.ididentificacion,
                    '    .tipoIdentificacion = i.tipoIdentificacion,
                    '    .glosa = i.glosa,
                    '    .usuarioActualizacion = i.usuarioActualizacion,
                    '.fechaActualizacion = i.fechaActualizacion
                    '    }
                    'HeliosData.documentoLibroDiarioDetalle.Add(docDetalle)

                    Me.DetalleLibroDiarioSave(i, documento.idDocumento)


                    'If i.idCosto > 0 Then
                    '    Me.CosteoDetalleAst(i, documento.idDocumento)
                    'End If

                    '    obj = New recursoCostoDetalle With
                    '      {
                    '.idCosto = i.idCosto,
                    '.fechaRegistro = i.fechaRegistro,
                    '.iditem = i.idItem,
                    '.destino = i.destino,
                    '.descripcion = i.descripcion,
                    '.um = "",
                    '.cant = CDec(0),
                    '.puMN = CDec(0),
                    '.puME = CDec(0),
                    '.montoMN = i.importeMN,
                    '.montoME = i.importeME,
                    '.documentoRef = documento.idDocumento,
                    '.itemRef = i.secuencia,
                    '.operacion = i.operacion,
                    '.procesado = i.procesado,
                    '.idProceso = i.idProceso,
                    '.tipoCosto = "RL"
                    '    }
                    '    HeliosData.recursoCostoDetalle.Add(obj)


                Next



                AsientoBL.SavebyGroupDoc(documento)


                HeliosData.SaveChanges()
                ts.Complete()
                Return documento.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Function GrabarGastoXModulo(documento As documento) As Integer
    '    Dim documentoBL As New documentoBL
    '    Dim docDetalle As New documentoLibroDiarioDetalle
    '    Dim AsientoBL As New AsientoBL
    '    Dim recursoBL As New recursoCostoDetalleBL
    '    Try
    '        Using ts As New TransactionScope
    '            documentoBL.Insert(documento)
    '            InsertCabeceraLibro(documento.documentoLibroDiario, documento.idDocumento)
    '            For Each i As documentoLibroDiarioDetalle In documento.documentoLibroDiario.documentoLibroDiarioDetalle
    '                docDetalle = New documentoLibroDiarioDetalle With {
    '                    .idDocumento = documento.idDocumento,
    '                    .cuenta = i.cuenta,
    '                    .descripcion = i.descripcion,
    '                    .tipoAsiento = i.tipoAsiento,
    '                    .importeMN = i.importeMN,
    '                    .importeME = i.importeME,
    '                    .estadoPago = i.estadoPago,
    '                    .tipoPago = i.tipoPago,
    '                    .ididentificacion = i.ididentificacion,
    '                    .tipoIdentificacion = i.tipoIdentificacion,
    '                    .glosa = i.glosa,
    '                    .usuarioActualizacion = i.usuarioActualizacion,
    '                .fechaActualizacion = i.fechaActualizacion
    '                    }
    '                HeliosData.documentoLibroDiarioDetalle.Add(docDetalle)
    '            Next



    '            AsientoBL.SavebyGroupDoc(documento)


    '            HeliosData.SaveChanges()
    '            ts.Complete()
    '            Return documento.idDocumento
    '        End Using
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function



    Public Function ListaGastosModulo(tipo As String, periodo As String) As List(Of documentoLibroDiario)

        Dim objetoDetalle As New List(Of documentoLibroDiario)
        Dim objeto As New documentoLibroDiario



        'Dim consulta = (From n In HeliosData.documentoLibroDiario _
        '               Join det In HeliosData.tabladetalle _
        '               On det.codigoDetalle Equals n.tipoRegistro _
        '               Where n.idEmpresa = Gempresas.IdEmpresaRuc _
        '               And n.idEstablecimiento = GEstableciento.IdEstablecimiento _
        '               And det.idtabla = CInt(30)).ToList

        Dim consulta = (From n In HeliosData.documentoLibroDiario _
                       Where n.idEmpresa = Gempresas.IdEmpresaRuc _
                       And n.idEstablecimiento = GEstableciento.IdEstablecimiento _
                       And n.tipoRegistro = "NM" And n.fechaPeriodo = periodo).ToList


        For Each i In consulta
            objeto = New documentoLibroDiario
            objeto.idDocumento = i.idDocumento
            objeto.infoReferencial = i.infoReferencial
            objeto.importeMN = i.importeMN
            objeto.importeME = i.importeME
            objeto.tipoCambio = i.tipoCambio
            objeto.fecha = i.fecha
            objeto.fechaVct = i.fechaVct
            objeto.nroDoc = i.nroDoc
            objeto.moneda = i.moneda
            objeto.razonSocial = i.razonSocial
            objeto.tipoRazonSocial = i.tipoRazonSocial

            objetoDetalle.Add(objeto)
        Next

        Return objetoDetalle


    End Function



    Public Function UbicarPagosModuloTodoProveedor(strEmpresa As String, intIdEstablecimiento As Integer, identificacion As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim list As New List(Of String)


        Dim consulta2 = (From n In HeliosData.documentoLibroDiario _
                       Join det In HeliosData.documentoLibroDiarioDetalle _
                       On n.idDocumento Equals det.idDocumento _
                       Where n.idEmpresa = strEmpresa And n.idEstablecimiento = intIdEstablecimiento _
                         And det.tipoPago = "P" And det.estadoPago = "PN" And n.razonSocial = identificacion).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.n.idDocumento
            doccompra.fecha = i.n.fecha
            doccompra.nroDoc = i.n.nroDoc
            doccompra.cuenta = i.det.cuenta
            doccompra.descripcion = i.det.descripcion
            doccompra.tipoAsiento = i.det.tipoAsiento
            doccompra.importeMN = i.det.importeMN
            doccompra.importeME = i.det.importeME
            doccompra.secuencia = i.det.secuencia
            doccompra.estadoPago = i.det.estadoPago
            doccompra.moneda = i.n.moneda
            doccompra.informacionReferencial = i.n.infoReferencial

            If IsNothing(i.n.razonSocial) Then

            Else
                doccompra.razonSocial = i.n.razonSocial
            End If

            doccompra.tipoRazon = i.n.tipoRazonSocial


            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function



    Public Function UbicarPagosModuloTodo(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim list As New List(Of String)


        Dim consulta = (From det In HeliosData.documentoLibroDiarioDetalle
                        Where
                         det.tipoPago = "P"
                        Group New With {det.documentoLibroDiario, det} By
                        RazonSocial = CType(det.documentoLibroDiario.razonSocial, Int32?),
                                                 det.cuenta,
                                     det.documentoLibroDiario.tipoRazonSocial
                                        Into g = Group
                                         Select
                                     RazonSocial = CType(RazonSocial, Int32?),
                                     cuenta,
                                     tipoRazonSocial,
                                     total = CType(g.Sum(Function(p) p.det.importeMN), Decimal?),
                                     totalme = CType(g.Sum(Function(p) p.det.importeME), Decimal?)).ToList


        For Each i In consulta
            doccompra = New documentoLibroDiarioDetalle
            doccompra.razonSocial = i.RazonSocial
            doccompra.tipoRazon = i.tipoRazonSocial
            doccompra.importeMN = i.total
            doccompra.importeME = i.totalme
            doccompra.cuenta = i.cuenta

           
            compraLista.Add(doccompra)
        Next
        Return compraLista



    End Function


    Public Function UbicarPagosModulo(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String, strPeriodo As String) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim list As New List(Of String)


        Dim consulta2 = (From n In HeliosData.documentoLibroDiario _
                       Join det In HeliosData.documentoLibroDiarioDetalle _
                       On n.idDocumento Equals det.idDocumento _
                       Where n.idEmpresa = strEmpresa And n.idEstablecimiento = intIdEstablecimiento And n.fechaPeriodo = strPeriodo _
                         And det.tipoPago = "P" And det.estadoPago = "PN" And det.cuenta.StartsWith(cuenta)).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.n.idDocumento
            doccompra.fecha = i.n.fecha
            doccompra.nroDoc = i.n.nroDoc
            doccompra.cuenta = i.det.cuenta
            doccompra.descripcion = i.det.descripcion
            doccompra.tipoAsiento = i.det.tipoAsiento
            doccompra.importeMN = i.det.importeMN
            doccompra.importeME = i.det.importeME
            doccompra.secuencia = i.det.secuencia
            doccompra.estadoPago = i.det.estadoPago
            doccompra.moneda = i.n.moneda
            doccompra.informacionReferencial = i.n.infoReferencial

            If IsNothing(i.n.razonSocial) Then

            Else
                doccompra.razonSocial = i.n.razonSocial
            End If

            doccompra.tipoRazon = i.n.tipoRazonSocial


            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function



    Public Function UbicarCobrosModuloTodoProveedor(strEmpresa As String, intIdEstablecimiento As Integer, identificacion As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim list As New List(Of String)


        Dim consulta2 = (From n In HeliosData.documentoLibroDiario _
                       Join det In HeliosData.documentoLibroDiarioDetalle _
                       On n.idDocumento Equals det.idDocumento _
                       Where n.idEmpresa = strEmpresa And n.idEstablecimiento = intIdEstablecimiento _
                         And det.tipoPago = "C" And det.estadoPago = "PN" And n.razonSocial = identificacion).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.n.idDocumento
            doccompra.fecha = i.n.fecha
            doccompra.nroDoc = i.n.nroDoc
            doccompra.cuenta = i.det.cuenta
            doccompra.descripcion = i.det.descripcion
            doccompra.tipoAsiento = i.det.tipoAsiento
            doccompra.importeMN = i.det.importeMN
            doccompra.importeME = i.det.importeME
            doccompra.secuencia = i.det.secuencia
            doccompra.estadoPago = i.det.estadoPago
            doccompra.moneda = i.n.moneda
            doccompra.informacionReferencial = i.n.infoReferencial

            If IsNothing(i.n.razonSocial) Then

            Else
                doccompra.razonSocial = i.n.razonSocial
            End If

            doccompra.tipoRazon = i.n.tipoRazonSocial


            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function



    Public Function UbicarCobrosModuloTodo(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim list As New List(Of String)


        Dim consulta = (From det In HeliosData.documentoLibroDiarioDetalle
                        Where
                         det.tipoPago = "C"
                        Group New With {det.documentoLibroDiario, det} By
                        RazonSocial = CType(det.documentoLibroDiario.razonSocial, Int32?),
                                                 det.cuenta,
                                     det.documentoLibroDiario.tipoRazonSocial
                                        Into g = Group
                                         Select
                                     RazonSocial = CType(RazonSocial, Int32?),
                                     cuenta,
                                     tipoRazonSocial,
                                     total = CType(g.Sum(Function(p) p.det.importeMN), Decimal?),
                                     totalme = CType(g.Sum(Function(p) p.det.importeME), Decimal?)).ToList


        For Each i In consulta
            doccompra = New documentoLibroDiarioDetalle
            doccompra.razonSocial = i.RazonSocial
            doccompra.tipoRazon = i.tipoRazonSocial
            doccompra.importeMN = i.total
            doccompra.importeME = i.totalme
            doccompra.cuenta = i.cuenta


            compraLista.Add(doccompra)
        Next
        Return compraLista



    End Function


    Public Function UbicarCobrosModulo(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String, strPeriodo As String) As List(Of documentoLibroDiarioDetalle)
        Dim doccompra As New documentoLibroDiarioDetalle
        Dim compraLista As New List(Of documentoLibroDiarioDetalle)
        Dim list As New List(Of String)


        Dim consulta2 = (From n In HeliosData.documentoLibroDiario _
                       Join det In HeliosData.documentoLibroDiarioDetalle _
                       On n.idDocumento Equals det.idDocumento _
                       Where n.idEmpresa = strEmpresa And n.idEstablecimiento = intIdEstablecimiento And n.fechaPeriodo = strPeriodo _
                         And det.tipoPago = "C" And det.estadoPago = "PN" And det.cuenta.StartsWith(cuenta)).ToList

        For Each i In consulta2
            doccompra = New documentoLibroDiarioDetalle
            doccompra.idDocumento = i.n.idDocumento
            doccompra.fecha = i.n.fecha
            doccompra.nroDoc = i.n.nroDoc
            doccompra.cuenta = i.det.cuenta
            doccompra.descripcion = i.det.descripcion
            doccompra.tipoAsiento = i.det.tipoAsiento
            doccompra.importeMN = i.det.importeMN
            doccompra.importeME = i.det.importeME
            doccompra.secuencia = i.det.secuencia
            doccompra.estadoPago = i.det.estadoPago
            doccompra.moneda = i.n.moneda
            doccompra.informacionReferencial = i.n.infoReferencial

            If IsNothing(i.n.razonSocial) Then

            Else
                doccompra.razonSocial = i.n.razonSocial
            End If

            doccompra.tipoRazon = i.n.tipoRazonSocial


            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function


    Public Sub UpdateGastoModulo(ByVal documentoLibroDiarioBE As documentoLibroDiario)
        Using ts As New TransactionScope
            Dim docLibroDiario As documentoLibroDiario = HeliosData.documentoLibroDiario.Where(Function(o) _
                                            o.idDocumento = documentoLibroDiarioBE.idDocumento).First()

            docLibroDiario.idEmpresa = documentoLibroDiarioBE.idEmpresa
            docLibroDiario.idEstablecimiento = documentoLibroDiarioBE.idEstablecimiento
            docLibroDiario.fecha = documentoLibroDiarioBE.fecha
            docLibroDiario.fechaVct = documentoLibroDiarioBE.fechaVct
            docLibroDiario.fechaPeriodo = documentoLibroDiarioBE.fechaPeriodo
            docLibroDiario.infoReferencial = documentoLibroDiarioBE.infoReferencial
            docLibroDiario.tipoRegistro = documentoLibroDiarioBE.tipoRegistro
            docLibroDiario.moneda = documentoLibroDiarioBE.moneda
            docLibroDiario.tipoCambio = documentoLibroDiarioBE.tipoCambio
            docLibroDiario.importeMN = documentoLibroDiarioBE.importeMN
            docLibroDiario.importeME = documentoLibroDiarioBE.importeME
            docLibroDiario.usuarioActualizacion = documentoLibroDiarioBE.usuarioActualizacion
            docLibroDiario.fechaActualizacion = documentoLibroDiarioBE.fechaActualizacion



            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetExistenciasInicio(be As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle)

        Dim obj As New documentoLibroDiarioDetalle
        Dim Lista As New List(Of documentoLibroDiarioDetalle)

        Dim consulta = (From n In HeliosData.documentoLibroDiario _
                       Join det In HeliosData.documentoLibroDiarioDetalle _
                       On det.idDocumento Equals n.idDocumento _
                       Where n.idEmpresa = be.idEmpresa _
                       And n.tipoRegistro = "APT_EXT" _
                       And n.tipoOperacion = "105").ToList

        For Each i In consulta
            obj = New documentoLibroDiarioDetalle
            obj.idDocumento = i.n.idDocumento
            obj.secuencia = i.det.secuencia
            obj.idItem = i.det.idItem
            obj.descripcion = i.det.descripcion
            obj.importeMN = i.det.importeMN
            obj.importeME = i.det.importeME
            Lista.Add(obj)
        Next

        Return Lista
    End Function


    Public Function GetSumaInicioExistencias(be As documentoLibroDiario) As documentoLibroDiario

        Dim obj As New documentoLibroDiario

        Dim consulta = Aggregate n In HeliosData.documentoLibroDiario _
                       Where n.idEmpresa = be.idEmpresa _
                       And n.tipoRegistro = "APT_EXT" _
                       And n.tipoOperacion = "105" _
                       Into SumaMN = Sum(n.importeMN),
                       SumaME = Sum(n.importeME)

        obj = New documentoLibroDiario
        obj.importeMN = consulta.SumaMN
        obj.importeME = consulta.SumaME

        Return obj
    End Function



    Public Function GetCuentasAperturaEmpresa(be As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle)

        Dim obj As New documentoLibroDiarioDetalle
        Dim Lista As New List(Of documentoLibroDiarioDetalle)

        Dim consulta = (From n In HeliosData.documentoLibroDiario _
                        Join det In HeliosData.documentoLibroDiarioDetalle _
                        On n.idDocumento Equals det.idDocumento _
                       Where n.idEmpresa = be.idEmpresa _
                       And n.tipoRegistro = "APT" _
                       And n.tipoOperacion = "105" Select det).ToList


        For Each i In consulta
            obj = New documentoLibroDiarioDetalle
            obj.secuencia = i.secuencia
            obj.cuenta = i.cuenta
            obj.descripcion = i.descripcion
            obj.tipoAsiento = i.tipoAsiento
            obj.importeMN = i.importeMN
            obj.importeME = i.importeME
            Lista.Add(obj)
        Next
        Return Lista
    End Function


    Public Function MostrarPagosVariosCP(intIdDocumentoPadre As Integer) As List(Of documentoLibroDiario)
        Dim listaLibro As New List(Of documentoLibroDiario)

        Dim librodiario = (From n In HeliosData.documentoLibroDiario _
                       Where n.idReferencia = intIdDocumentoPadre _
                       Select New With {
                           .idDocumento = n.idDocumento,
                           .fecha = n.fecha,
                           .tipo = "AJUSTE",
                           .tipoDoc = n.tipoDoc,
                           .serie = "-",
                           .numero = n.nroDoc,
                           .importe = n.importeMN,
                           .importeME = n.importeME
                           }).ToList

        Dim NC = (From c In HeliosData.documentocompra _
                     Where c.idPadre = intIdDocumentoPadre _
                     And c.tipoDoc = "07" _
                     Select New With {
                         .idDocumento = c.idDocumento,
                           .fecha = c.fechaDoc,
                           .tipo = "NOTA DE CREDITO",
                           .tipoDoc = c.tipoDoc,
                           .serie = c.serie,
                           .numero = c.numeroDoc,
                           .importe = c.importeTotal,
                           .importeME = c.importeUS
                         }).ToList


        Dim ND = (From c In HeliosData.documentocompra _
                    Where c.idPadre = intIdDocumentoPadre _
                    And c.tipoDoc = "08" _
                    Select New With {
                        .idDocumento = c.idDocumento,
                          .fecha = c.fechaDoc,
                          .tipo = "NOTA DE DEBITO",
                          .tipoDoc = c.tipoDoc,
                          .serie = c.serie,
                          .numero = c.numeroDoc,
                          .importe = c.importeTotal,
                          .importeME = c.importeUS
                        }).ToList


        Dim lista = librodiario.Concat(NC).Concat(ND).ToList

        For Each i In lista
            Dim libroBE As New documentoLibroDiario With
                {
                     .idDocumento = i.idDocumento,
                           .fecha = i.fecha,
                           .tipoRegistro = i.tipo,
                           .tipoDoc = i.tipoDoc,
                           .serie = i.serie,
                           .nroDoc = i.numero,
                           .importeMN = i.importe,
                           .importeME = i.importeME
                           }
            listaLibro.Add(libroBE)
        Next

        Return listaLibro
    End Function

    Public Sub DeleteLibroDiario(ByVal intIdDocumento As Integer)
        Using ts As New TransactionScope
            Dim ConsultaCosto = (From n In HeliosData.recursoCostoDetalle _
                                Where n.documentoRef = intIdDocumento).ToList

            For Each i In ConsultaCosto
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(i)
            Next

            Dim consulta As documento = HeliosData.documento.Where(Function(o) o.idDocumento = intIdDocumento).FirstOrDefault
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub ActualizarLibroDiarioDet(documento As documento)
        Dim librodetalleBL As New documentoLibroDiarioDetalleBL
        Dim asientoBL As New AsientoBL
        Dim docDetalle As New documentoLibroDiarioDetalle
        Dim recursoBL As New recursoCostoDetalleBL
        Try
            Using ts As New TransactionScope
                Dim asiento As documentoLibroDiario = HeliosData.documentoLibroDiario.Where(Function(o) o.idDocumento = documento.idDocumento).FirstOrDefault
                asiento.infoReferencial = documento.documentoLibroDiario.infoReferencial
                asiento.tipoOperacion = documento.tipoOperacion
                asiento.fecha = documento.documentoLibroDiario.fecha
                asiento.importeMN = documento.documentoLibroDiario.importeMN
                asiento.importeME = documento.documentoLibroDiario.importeME
                asiento.tieneCosto = documento.documentoLibroDiario.tieneCosto
                asiento.idCosto = documento.documentoLibroDiario.idCosto

                Dim mov As List(Of documentoLibroDiarioDetalle) = HeliosData.documentoLibroDiarioDetalle.Where(Function(o) o.idDocumento = documento.idDocumento).ToList

                For Each ob In mov
                    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(ob)
                    ' librodetalleBL.Delete(ob)
                Next
                asientoBL.DeleteGroup(documento.idDocumento)

                For Each i As documentoLibroDiarioDetalle In documento.documentoLibroDiario.documentoLibroDiarioDetalle
                    docDetalle = New documentoLibroDiarioDetalle With {
                        .idDocumento = documento.idDocumento,
                        .cuenta = i.cuenta,
                        .idItem = i.idItem,
                        .descripcion = i.descripcion,
                        .tipoAsiento = i.tipoAsiento,
                        .importeMN = i.importeMN,
                        .tipoPago = i.tipoPago,
                        .importeME = i.importeME,
                        .usuarioActualizacion = i.usuarioActualizacion,
                        .fechaActualizacion = i.fechaActualizacion
                        }
                    HeliosData.documentoLibroDiarioDetalle.Add(docDetalle)
                Next

                Select Case documento.documentoLibroDiario.tieneCosto
                    Case "S"
                        recursoBL.eliminarDetalleCostoByIdDocumento(documento.idDocumento)

                        Dim listaLibro As New List(Of documentoLibroDiarioDetalle)
                        listaLibro = (From l In documento.documentoLibroDiario.documentoLibroDiarioDetalle _
                                     Where l.cuenta.StartsWith("6")).ToList


                        recursoBL.GrabarDetalleRecursosByOneLibro(listaLibro, documento.idDocumento)
                    Case Else

                End Select

                asientoBL.SavebyGroupDoc(documento)

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Lista(libroBE As documentoLibroDiario) As List(Of documentoLibroDiario)
        Return HeliosData.documentoLibroDiario.Where(Function(o) o.idEmpresa = libroBE.idEmpresa And o.idEstablecimiento = libroBE.idEstablecimiento _
                                                         And o.tipoRegistro = libroBE.tipoRegistro And _
                                                         o.fechaPeriodo = libroBE.fechaPeriodo).ToList
    End Function


    Public Function GrabarAjustes(objDocumento As documento) As Integer
        Dim DocumentoBL As New documentoBL
        Dim asientoBL As New AsientoBL
        Dim cajaBL As New documentoCajaDetalleBL
        Dim docDetalle As New documentoLibroDiarioDetalle
        Try
            Using ts As New TransactionScope()
                DocumentoBL.Insert(objDocumento)

                Dim compra As documentocompra = HeliosData.documentocompra.Where(Function(o) o.idDocumento = objDocumento.documentoLibroDiario.idReferencia).FirstOrDefault
                InsertCabecera(objDocumento.documentoLibroDiario, objDocumento.idDocumento)

                For Each i As documentoLibroDiarioDetalle In objDocumento.documentoLibroDiario.documentoLibroDiarioDetalle
                    cajaBL.ActualizarItemsPagosAjustes(i, objDocumento.documentoLibroDiario.idReferencia)

                    docDetalle = New documentoLibroDiarioDetalle With {
                        .idDocumento = objDocumento.idDocumento,
                        .cuenta = i.cuenta,
                        .idItem = i.idItem,
                        .descripcion = i.descripcion,
                        .tipoAsiento = i.tipoAsiento,
                        .importeMN = i.importeMN,
                        .importeME = i.importeME,
                        .usuarioActualizacion = i.usuarioActualizacion,
                        .fechaActualizacion = i.fechaActualizacion
                        }
                    HeliosData.documentoLibroDiarioDetalle.Add(docDetalle)
                Next
            
                Dim CompraOriginal = (From n In HeliosData.documentocompradetalle _
                                Where n.idDocumento = compra.idDocumento AndAlso n.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO).Count

                If CompraOriginal > 0 Then
                    compra.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                Else
                    compra.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                End If


                HeliosData.SaveChanges()
                ts.Complete()
                Return objDocumento.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GrabarLibro(documento As documento) As Integer
        Dim documentoBL As New documentoBL
        Dim docDetalle As New documentoLibroDiarioDetalle
        Dim AsientoBL As New AsientoBL
        Dim recursoBL As New recursoCostoDetalleBL
        Try
            Using ts As New TransactionScope
                documentoBL.Insert(documento)
                InsertCabecera(documento.documentoLibroDiario, documento.idDocumento)
                For Each i As documentoLibroDiarioDetalle In documento.documentoLibroDiario.documentoLibroDiarioDetalle
                    docDetalle = New documentoLibroDiarioDetalle With {
                        .idDocumento = documento.idDocumento,
                        .cuenta = i.cuenta,
                        .idItem = i.idItem,
                        .descripcion = i.descripcion,
                        .tipoAsiento = i.tipoAsiento,
                        .importeMN = i.importeMN,
                        .importeME = i.importeME,
                        .usuarioActualizacion = i.usuarioActualizacion,
                        .fechaActualizacion = i.fechaActualizacion
                        }
                    HeliosData.documentoLibroDiarioDetalle.Add(docDetalle)
                Next

                Select Case documento.documentoLibroDiario.tieneCosto
                    Case "S"
                        Dim listaLibro As New List(Of documentoLibroDiarioDetalle)
                        listaLibro = (From l In documento.documentoLibroDiario.documentoLibroDiarioDetalle _
                                     Where l.cuenta.StartsWith("6")).ToList


                        recursoBL.GrabarDetalleRecursosByOneLibro(listaLibro, documento.idDocumento)
                    Case Else

                End Select

                AsientoBL.SavebyGroupDoc(documento)

                If Not IsNothing(documento.documentoLibroDiario.AsientoNotificado) Then
                    Dim venta As documentoventaAbarrotes = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = documento.documentoLibroDiario.AsientoNotificado)
                    venta.notificacionAsiento = "C"
                End If

                HeliosData.SaveChanges()
                ts.Complete()
                Return documento.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GrabarLibroCosto(documento As documento) As Integer
        Dim documentoBL As New documentoBL
        Dim docDetalle As New documentoLibroDiarioDetalle
        Dim AsientoBL As New AsientoBL
        Try
            Using ts As New TransactionScope
                documentoBL.Insert(documento)
                'documento.documentoLibroDiario.idReferencia = documento.idDocumento
                InsertCabecera(documento.documentoLibroDiario, documento.idDocumento)
                For Each i As documentoLibroDiarioDetalle In documento.documentoLibroDiario.documentoLibroDiarioDetalle
                    docDetalle = New documentoLibroDiarioDetalle With {
                        .idDocumento = documento.idDocumento,
                        .cuenta = i.cuenta,
                        .idItem = i.idItem,
                        .descripcion = i.descripcion,
                        .tipoAsiento = i.tipoAsiento,
                        .importeMN = i.importeMN,
                        .importeME = i.importeME,
                        .usuarioActualizacion = i.usuarioActualizacion,
                        .fechaActualizacion = i.fechaActualizacion
                        }
                    HeliosData.documentoLibroDiarioDetalle.Add(docDetalle)
                Next
                AsientoBL.SavebyGroupDoc(documento)
                HeliosData.SaveChanges()
                ts.Complete()
                Return documento.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub InsertCabeceraLibro(ByVal documentocompraBE As documentoLibroDiario, intIdDocumento As Integer, val As Integer)
        Dim docCompra As New documentoLibroDiario
        Dim numeracionBL As New numeracionBoletasBL
        'Dim cval As Integer = 0
        Using ts As New TransactionScope
            docCompra.idDocumento = intIdDocumento
            docCompra.idEmpresa = documentocompraBE.idEmpresa
            docCompra.idEstablecimiento = documentocompraBE.idEstablecimiento
            docCompra.fecha = documentocompraBE.fecha
            docCompra.fechaPeriodo = documentocompraBE.fechaPeriodo
            docCompra.infoReferencial = documentocompraBE.infoReferencial
            docCompra.tipoDoc = documentocompraBE.tipoDoc
            docCompra.tipoRegistro = "NM"
            docCompra.tipoRazonSocial = documentocompraBE.tipoRazonSocial
            docCompra.razonSocial = documentocompraBE.razonSocial
            docCompra.fechaVct = documentocompraBE.fechaVct
            docCompra.modulo = documentocompraBE.modulo
            ' cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(documentocompraBE.IdNumeracion))

            docCompra.nroDoc = val '
            docCompra.tipoOperacion = documentocompraBE.tipoOperacion
            docCompra.moneda = documentocompraBE.moneda

            docCompra.tipoCambio = documentocompraBE.tipoCambio
            docCompra.importeMN = documentocompraBE.importeMN
            docCompra.importeME = documentocompraBE.importeME
            docCompra.idReferencia = documentocompraBE.idReferencia
            docCompra.tieneCosto = documentocompraBE.tieneCosto
            docCompra.idCosto = documentocompraBE.idCosto
            docCompra.usuarioActualizacion = documentocompraBE.usuarioActualizacion
            docCompra.fechaActualizacion = documentocompraBE.fechaActualizacion

            HeliosData.documentoLibroDiario.Add(docCompra)
            HeliosData.SaveChanges()
            ts.Complete()
            documentocompraBE.serie = documentocompraBE.serie
            documentocompraBE.nroDoc = val
            '   documentocompraBE.idDocumento = docCompra.idDocumento
        End Using
    End Sub
    'Public Sub InsertCabeceraLibro(ByVal documentocompraBE As documentoLibroDiario, intIdDocumento As Integer)
    '    Dim docCompra As New documentoLibroDiario
    '    Dim numeracionBL As New numeracionBoletasBL
    '    Dim cval As Integer = 0
    '    Using ts As New TransactionScope
    '        docCompra.idDocumento = intIdDocumento
    '        docCompra.idEmpresa = documentocompraBE.idEmpresa
    '        docCompra.idEstablecimiento = documentocompraBE.idEstablecimiento
    '        docCompra.fecha = documentocompraBE.fecha
    '        docCompra.fechaPeriodo = documentocompraBE.fechaPeriodo
    '        docCompra.infoReferencial = documentocompraBE.infoReferencial
    '        docCompra.tipoDoc = documentocompraBE.tipoDoc
    '        docCompra.tipoRegistro = "NM"
    '        docCompra.tipoRazonSocial = documentocompraBE.tipoRazonSocial
    '        docCompra.razonSocial = documentocompraBE.razonSocial
    '        docCompra.fechaVct = documentocompraBE.fechaVct
    '        cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(documentocompraBE.IdNumeracion))

    '        docCompra.nroDoc = cval '
    '        docCompra.tipoOperacion = documentocompraBE.tipoOperacion
    '        docCompra.moneda = documentocompraBE.moneda

    '        docCompra.tipoCambio = documentocompraBE.tipoCambio
    '        docCompra.importeMN = documentocompraBE.importeMN
    '        docCompra.importeME = documentocompraBE.importeME
    '        docCompra.idReferencia = documentocompraBE.idReferencia
    '        docCompra.tieneCosto = documentocompraBE.tieneCosto
    '        docCompra.idCosto = documentocompraBE.idCosto
    '        docCompra.usuarioActualizacion = documentocompraBE.usuarioActualizacion
    '        docCompra.fechaActualizacion = documentocompraBE.fechaActualizacion

    '        HeliosData.documentoLibroDiario.Add(docCompra)
    '        HeliosData.SaveChanges()
    '        ts.Complete()
    '        documentocompraBE.serie = documentocompraBE.serie
    '        documentocompraBE.nroDoc = cval
    '        '   documentocompraBE.idDocumento = docCompra.idDocumento
    '    End Using
    'End Sub



    Public Sub InsertCabecera(ByVal documentocompraBE As documentoLibroDiario, intIdDocumento As Integer)
        Dim docCompra As New documentoLibroDiario
        Dim numeracionBL As New numeracionBoletasBL
        Dim cval As Integer = 0
        Using ts As New TransactionScope
            docCompra.idDocumento = intIdDocumento
            docCompra.idEmpresa = documentocompraBE.idEmpresa
            docCompra.idEstablecimiento = documentocompraBE.idEstablecimiento
            docCompra.fecha = documentocompraBE.fecha
            docCompra.fechaPeriodo = documentocompraBE.fechaPeriodo
            docCompra.infoReferencial = documentocompraBE.infoReferencial
            docCompra.tipoDoc = documentocompraBE.tipoDoc
            docCompra.tipoRegistro = documentocompraBE.tipoRegistro

            cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(documentocompraBE.IdNumeracion))

            docCompra.nroDoc = cval '
            docCompra.tipoOperacion = documentocompraBE.tipoOperacion
            docCompra.moneda = documentocompraBE.moneda

            docCompra.tipoCambio = documentocompraBE.tipoCambio
            docCompra.importeMN = documentocompraBE.importeMN
            docCompra.importeME = documentocompraBE.importeME
            docCompra.idReferencia = documentocompraBE.idReferencia
            docCompra.tieneCosto = documentocompraBE.tieneCosto
            docCompra.idCosto = documentocompraBE.idCosto
            docCompra.usuarioActualizacion = documentocompraBE.usuarioActualizacion
            docCompra.fechaActualizacion = documentocompraBE.fechaActualizacion

            HeliosData.documentoLibroDiario.Add(docCompra)
            HeliosData.SaveChanges()
            ts.Complete()
            documentocompraBE.serie = documentocompraBE.serie
            documentocompraBE.nroDoc = cval
            '   documentocompraBE.idDocumento = docCompra.idDocumento
        End Using
    End Sub

    Public Function Insert(ByVal documentoLibroDiarioBE As documentoLibroDiario) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoLibroDiario.Add(documentoLibroDiarioBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoLibroDiarioBE.idDocumento
        End Using
    End Function

    Public Sub Update(ByVal documentoLibroDiarioBE As documentoLibroDiario)
        Using ts As New TransactionScope
            Dim docLibroDiario As documentoLibroDiario = HeliosData.documentoLibroDiario.Where(Function(o) _
                                            o.idDocumento = documentoLibroDiarioBE.idDocumento).First()

            docLibroDiario.idEmpresa = documentoLibroDiarioBE.idEmpresa
            docLibroDiario.idEstablecimiento = documentoLibroDiarioBE.idEstablecimiento
            docLibroDiario.tipoRegistro = documentoLibroDiarioBE.tipoRegistro
            docLibroDiario.fecha = documentoLibroDiarioBE.fecha
            docLibroDiario.fechaPeriodo = documentoLibroDiarioBE.fechaPeriodo
            docLibroDiario.infoReferencial = documentoLibroDiarioBE.infoReferencial
            docLibroDiario.razonSocial = documentoLibroDiarioBE.razonSocial
            docLibroDiario.tipoDoc = documentoLibroDiarioBE.tipoDoc
            docLibroDiario.nroDoc = documentoLibroDiarioBE.nroDoc
            docLibroDiario.tipoOperacion = documentoLibroDiarioBE.tipoOperacion
            docLibroDiario.moneda = documentoLibroDiarioBE.moneda
            docLibroDiario.tipoCambio = documentoLibroDiarioBE.tipoCambio
            docLibroDiario.importeMN = documentoLibroDiarioBE.importeMN
            docLibroDiario.importeME = documentoLibroDiarioBE.importeME
            docLibroDiario.usuarioActualizacion = documentoLibroDiarioBE.usuarioActualizacion
            docLibroDiario.fechaActualizacion = documentoLibroDiarioBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docLibroDiario).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoLibroDiarioBE As documentoLibroDiario)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoLibroDiarioBE)
    End Sub

    Public Function GetListar_documentoLibroDiario() As List(Of documentoLibroDiario)
        Return (From a In HeliosData.documentoLibroDiario Select a).ToList
    End Function

    Public Function GetUbicar_documentoLibroDiarioPorID(idDocumento As Integer) As documentoLibroDiario
        Return (From a In HeliosData.documentoLibroDiario
                 Where a.idDocumento = idDocumento Select a).First
    End Function

    Public Sub GrabaritemExistenciaInicio(nuevoarticulo As detalleitems, item As totalesAlmacen, inv As InventarioMovimiento)
        Dim itemDetalle As New documentoLibroDiarioDetalle
        Dim detalleItemsBL As New detalleitemsBL
        Dim precioBL As New ConfiguracionPrecioProductoBL
        Dim loteBL As New recursoCostoLoteBL
        Using ts As New TransactionScope

            Dim codigoArticulo = detalleItemsBL.InsertItemDualTabla(nuevoarticulo)

            '     Dim existeItem = HeliosData.totalesAlmacen.Where(Function(o) o.idItem = item.idItem).FirstOrDefault
            Dim codigoLote = loteBL.GrabarLotesOne(item.CustomLote)
            '  If existeItem Is Nothing Then
            item.codigoLote = codigoLote
            item.idItem = codigoArticulo
            item.descripcion = nuevoarticulo.descripcionItem
            item.idUnidad = nuevoarticulo.unidad1
            item.unidadMedida = nuevoarticulo.unidad1
            HeliosData.totalesAlmacen.Add(item)

            '  End If

            'inventariomovimiento
            inv.nrolote = codigoLote
            inv.descripcion = nuevoarticulo.descripcionItem
            inv.idItem = codigoArticulo
            inv.unidad = nuevoarticulo.unidad1
            HeliosData.InventarioMovimiento.Add(inv)

            'item documentolibrodiariodetalle
            itemDetalle = New documentoLibroDiarioDetalle
            itemDetalle.idDocumento = inv.idDocumento
            itemDetalle.idItem = inv.idItem
            itemDetalle.descripcion = inv.descripcion
            itemDetalle.tipoAsiento = "N"
            itemDetalle.monto1 = inv.cantidad.GetValueOrDefault
            itemDetalle.importeMN = inv.monto.GetValueOrDefault
            itemDetalle.importeME = 0
            itemDetalle.usuarioActualizacion = "1"
            itemDetalle.fechaActualizacion = Date.Now
            itemDetalle.glosa = "Aporte existencia"
            HeliosData.documentoLibroDiarioDetalle.Add(itemDetalle)

            'precios
            precioBL.GrabarPrecioApertura(nuevoarticulo.CustomPrecios, codigoArticulo)

            ts.Complete()
        End Using
        HeliosData.SaveChanges()
    End Sub

    Public Sub GrabaritemExistenciaInicioExistente(nuevoarticulo As detalleitems, item As totalesAlmacen, inv As InventarioMovimiento)
        Dim itemDetalle As New documentoLibroDiarioDetalle
        Dim detalleItemsBL As New detalleitemsBL
        Dim precioBL As New ConfiguracionPrecioProductoBL
        Dim loteBL As New recursoCostoLoteBL
        Using ts As New TransactionScope

            'Dim codigoArticulo = detalleItemsBL.InsertItemDualTabla(nuevoarticulo)

            '     Dim existeItem = HeliosData.totalesAlmacen.Where(Function(o) o.idItem = item.idItem).FirstOrDefault
            Dim codigoLote = loteBL.GrabarLotesOne(item.CustomLote)
            '  If existeItem Is Nothing Then
            item.codigoLote = codigoLote
            item.idItem = nuevoarticulo.codigodetalle
            item.descripcion = nuevoarticulo.descripcionItem
            item.idUnidad = nuevoarticulo.unidad1
            item.unidadMedida = nuevoarticulo.unidad1
            HeliosData.totalesAlmacen.Add(item)

            '  End If

            'inventariomovimiento
            inv.nrolote = codigoLote
            inv.descripcion = nuevoarticulo.descripcionItem
            inv.idItem = nuevoarticulo.codigodetalle
            inv.unidad = nuevoarticulo.unidad1
            HeliosData.InventarioMovimiento.Add(inv)

            'item documentolibrodiariodetalle
            itemDetalle = New documentoLibroDiarioDetalle
            itemDetalle.idDocumento = inv.idDocumento
            itemDetalle.idItem = nuevoarticulo.codigodetalle
            itemDetalle.descripcion = inv.descripcion
            itemDetalle.tipoAsiento = "N"
            itemDetalle.monto1 = inv.cantidad.GetValueOrDefault
            itemDetalle.importeMN = inv.monto.GetValueOrDefault
            itemDetalle.importeME = 0
            itemDetalle.usuarioActualizacion = "1"
            itemDetalle.fechaActualizacion = Date.Now
            itemDetalle.glosa = "Aporte existencia"
            HeliosData.documentoLibroDiarioDetalle.Add(itemDetalle)

            'precios
            precioBL.GrabarPrecioApertura(nuevoarticulo.CustomPrecios, nuevoarticulo.codigodetalle)

            ts.Complete()
        End Using
        HeliosData.SaveChanges()
    End Sub
End Class
