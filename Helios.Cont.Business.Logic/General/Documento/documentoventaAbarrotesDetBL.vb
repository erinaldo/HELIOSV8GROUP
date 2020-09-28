Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class documentoventaAbarrotesDetBL
    Inherits BaseBL

    Public Function GetDetalleVentaGuiaSelventa(be As documentoventaAbarrotesDet) As List(Of documentoventaAbarrotesDet)
        'Dim con = (From caja In HeliosData.documentoventaAbarrotesDet
        '           Group Join mov In HeliosData.documentoguiaDetalle On caja.secuencia Equals mov.secuenciaRef Into mov_join = Group
        '           From mov In mov_join.DefaultIfEmpty()
        '           Where
        '           caja.idDocumento = be.idDocumento
        '           Group New With {caja, mov} By
        '               caja.secuencia,
        '               caja.idDocumento,
        '               caja.idItem,
        '               caja.nombreItem,
        '               caja.tipoExistencia,
        '               caja.unidad1,
        '               caja.monto1,
        '               caja.idAlmacenOrigen
        '               Into g = Group
        '           Select
        '               idDocumento,
        '               secuencia,
        '               idItem,
        '               nombreItem,
        '               tipoExistencia,
        '               unidad1,
        '               monto1,
        '               idAlmacenOrigen,
        '               movCant = CType(g.Sum(Function(p) p.mov.cantidad), Decimal?)).ToList

        'Dim con = (From caja In HeliosData.documentoventaAbarrotesDet
        '           Where
        '           caja.idDocumento = be.idDocumento
        '           Select
        '               caja.idDocumento,
        '               caja.secuencia,
        '               caja.idItem,
        '               caja.nombreItem,
        '               caja.tipoExistencia,
        '               caja.unidad1,
        '              caja.monto1,
        '               caja.idAlmacenOrigen,
        '               movCant = (CType((Aggregate t1 In
        '            (From w In HeliosData.documentoguiaDetalle
        '             Join b In HeliosData.documentoGuia On w.idDocumento Equals b.idDocumento
        '             Where w.secuenciaRef = caja.secuencia And b.estado = "VG"
        '             Select New With {
        '            w.cantidad
        '            }) Into Sum(t1.cantidad)), Decimal?)))



        Dim con = (From caja In HeliosData.documentoventaAbarrotesDet
                   Where
                   caja.idDocumento = be.idDocumento
                   Select
                       caja.idDocumento,
                       caja.secuencia,
                       caja.idItem,
                       caja.nombreItem,
                       caja.tipoExistencia,
                       caja.unidad1,
                      caja.monto1,
                       caja.idAlmacenOrigen,
                       contenido = (From i In HeliosData.detalleitem_equivalencias
                                    Where i.codigodetalle = caja.idItem And i.equivalencia_id = caja.equivalencia_id).FirstOrDefault,
                       movCant = (CType((Aggregate t1 In
                    (From w In HeliosData.documentoguiaDetalle
                     Join b In HeliosData.documentoGuia On w.idDocumento Equals b.idDocumento
                     Where w.secuenciaRef = caja.secuencia And b.estado = "VG"
                     Select New With {
                    w.cantidad
                    }) Into Sum(t1.cantidad)), Decimal?)))



        GetDetalleVentaGuiaSelventa = New List(Of documentoventaAbarrotesDet)
        For Each i In con
            Dim boj = New documentoventaAbarrotesDet
            boj.idDocumento = i.idDocumento
            boj.secuencia = i.secuencia
            boj.idItem = i.idItem
            boj.nombreItem = i.nombreItem
            boj.tipoExistencia = i.tipoExistencia
            boj.unidad1 = i.unidad1
            boj.monto1 = i.monto1
            boj.idAlmacenOrigen = i.idAlmacenOrigen
            boj.cantidadEntrega = i.movCant.GetValueOrDefault
            If i.contenido IsNot Nothing Then
                boj.monto2 = i.contenido.contenido_neto
                boj.nombreComercial = i.contenido.unidadComercial
            Else
                boj.monto2 = 1
                boj.nombreComercial = "UNIDAD"
            End If

            GetDetalleVentaGuiaSelventa.Add(boj)
        Next

    End Function

    Public Function MappingDetalleVentaList(lista As List(Of documentoventaAbarrotesDet)) As List(Of documentoventaAbarrotesDet)
        Dim lst = New List(Of documentoventaAbarrotesDet)
        For Each i In lista
            lst.Add(MappingDetail(i))
        Next
        Return lst
    End Function

    Private Function MappingDetail(be As documentoventaAbarrotesDet) As documentoventaAbarrotesDet
        Dim docVentaAbarrotesDet = New documentoventaAbarrotesDet

        docVentaAbarrotesDet.idDocumento = be.idDocumento
        docVentaAbarrotesDet.idAlmacenOrigen = be.idAlmacenOrigen
        docVentaAbarrotesDet.establecimientoOrigen = be.establecimientoOrigen
        docVentaAbarrotesDet.cuentaOrigen = be.cuentaOrigen
        docVentaAbarrotesDet.idItem = be.idItem
        docVentaAbarrotesDet.nombreItem = be.nombreItem
        docVentaAbarrotesDet.fechaVcto = be.fechaVcto
        docVentaAbarrotesDet.tipoExistencia = be.tipoExistencia
        docVentaAbarrotesDet.destino = be.destino
        docVentaAbarrotesDet.unidad1 = be.unidad1
        docVentaAbarrotesDet.monto1 = be.monto1
        docVentaAbarrotesDet.unidad2 = be.unidad2
        docVentaAbarrotesDet.monto2 = be.monto2
        docVentaAbarrotesDet.precioUnitario = be.precioUnitario
        docVentaAbarrotesDet.precioUnitarioUS = be.precioUnitarioUS
        docVentaAbarrotesDet.importeMN = be.importeMN
        docVentaAbarrotesDet.importeME = be.importeME
        docVentaAbarrotesDet.importeMNK = be.importeMNK
        docVentaAbarrotesDet.importeMEK = be.importeMEK
        docVentaAbarrotesDet.descuentoMN = be.descuentoMN
        docVentaAbarrotesDet.descuentoME = be.descuentoME
        docVentaAbarrotesDet.montokardex = be.montokardex
        docVentaAbarrotesDet.montoIsc = be.montoIsc
        docVentaAbarrotesDet.montoIgv = be.montoIgv
        docVentaAbarrotesDet.otrosTributos = be.otrosTributos
        docVentaAbarrotesDet.montokardexUS = be.montokardexUS
        docVentaAbarrotesDet.montoIscUS = be.montoIscUS
        docVentaAbarrotesDet.montoIgvUS = be.montoIgvUS
        docVentaAbarrotesDet.otrosTributosUS = be.otrosTributosUS
        docVentaAbarrotesDet.salidaCostoMN = be.salidaCostoMN
        docVentaAbarrotesDet.salidaCostoME = be.salidaCostoME
        docVentaAbarrotesDet.preEvento = be.preEvento
        docVentaAbarrotesDet.estadoMovimiento = be.estadoMovimiento
        docVentaAbarrotesDet.tipoVenta = be.tipoVenta
        docVentaAbarrotesDet.estadoEntrega = be.estadoEntrega
        docVentaAbarrotesDet.idPadreDTVenta = be.idPadreDTVenta
        docVentaAbarrotesDet.estadoPago = be.estadoPago
        docVentaAbarrotesDet.categoria = be.categoria
        docVentaAbarrotesDet.estadoEntrega = be.estadoEntrega
        docVentaAbarrotesDet.usuarioModificacion = be.usuarioModificacion
        docVentaAbarrotesDet.fechaModificacion = be.fechaModificacion

        Return docVentaAbarrotesDet
    End Function

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

        Dim Compensa = Aggregate p In HeliosData.documentoventaAbarrotesDet
                      Join compra In HeliosData.documentoventaAbarrotes
                      On p.idDocumento Equals compra.idDocumento
                                 Where p.idPadreDTVenta = intIdSecuencia _
                                 And lista.Contains(compra.tipoDocumento) And compra.tipoVenta = "COMPV"
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

        objDetalle.montoCompesacion = Compensa.comp.GetValueOrDefault
        objDetalle.montoCompesacionme = Compensa.compme.GetValueOrDefault

        Return objDetalle

    End Function


    Public Function InsertSingleReconocimiento(ByVal documentoventaAbarrotesDetBE As documentoventaAbarrotesDet, intIdDocumento As Integer) As Integer
        Dim docVentaAbarrotesDet As New documentoventaAbarrotesDet
        Dim objcondicionBL As New documentoGuiaDetalleCondicionBL
        Dim objcondicion As New documentoguiaDetalleCondicion

        Using ts As New TransactionScope
            docVentaAbarrotesDet.idDocumento = intIdDocumento
            'docVentaAbarrotesDet.codigoLote = documentoventaAbarrotesDetBE.codigoLote
            ' docVentaAbarrotesDet.idAlmacenOrigen = documentoventaAbarrotesDetBE.idAlmacenOrigen
            docVentaAbarrotesDet.establecimientoOrigen = documentoventaAbarrotesDetBE.establecimientoOrigen
            'docVentaAbarrotesDet.cuentaOrigen = documentoventaAbarrotesDetBE.cuentaOrigen
            docVentaAbarrotesDet.idItem = documentoventaAbarrotesDetBE.idItem
            docVentaAbarrotesDet.nombreItem = documentoventaAbarrotesDetBE.DetalleItem
            docVentaAbarrotesDet.fechaVcto = documentoventaAbarrotesDetBE.fechaVcto
            ' docVentaAbarrotesDet.tipoExistencia = documentoventaAbarrotesDetBE.tipoExistencia
            docVentaAbarrotesDet.destino = documentoventaAbarrotesDetBE.destino
            'docVentaAbarrotesDet.unidad1 = documentoventaAbarrotesDetBE.unidad1
            docVentaAbarrotesDet.monto1 = documentoventaAbarrotesDetBE.monto1
            ' docVentaAbarrotesDet.unidad2 = documentoventaAbarrotesDetBE.unidad2
            'docVentaAbarrotesDet.monto2 = documentoventaAbarrotesDetBE.monto2
            docVentaAbarrotesDet.precioUnitario = documentoventaAbarrotesDetBE.precioUnitario
            docVentaAbarrotesDet.precioUnitarioUS = documentoventaAbarrotesDetBE.precioUnitarioUS
            docVentaAbarrotesDet.importeMN = documentoventaAbarrotesDetBE.importeMN
            docVentaAbarrotesDet.importeME = documentoventaAbarrotesDetBE.importeME
            ' docVentaAbarrotesDet.importeMNK = documentoventaAbarrotesDetBE.importeMNK
            ' docVentaAbarrotesDet.importeMEK = documentoventaAbarrotesDetBE.importeMEK
            'docVentaAbarrotesDet.descuentoMN = documentoventaAbarrotesDetBE.descuentoMN
            ' docVentaAbarrotesDet.descuentoME = documentoventaAbarrotesDetBE.descuentoME
            ' docVentaAbarrotesDet.montokardex = documentoventaAbarrotesDetBE.montokardex
            ' docVentaAbarrotesDet.montoIsc = documentoventaAbarrotesDetBE.montoIsc
            docVentaAbarrotesDet.montoIgv = documentoventaAbarrotesDetBE.montoIgv
            ' docVentaAbarrotesDet.otrosTributos = documentoventaAbarrotesDetBE.otrosTributos
            docVentaAbarrotesDet.montokardexUS = documentoventaAbarrotesDetBE.montokardexUS
            docVentaAbarrotesDet.montoIscUS = documentoventaAbarrotesDetBE.montoIscUS
            docVentaAbarrotesDet.montoIgvUS = documentoventaAbarrotesDetBE.montoIgvUS
            docVentaAbarrotesDet.otrosTributosUS = documentoventaAbarrotesDetBE.otrosTributosUS
            'docVentaAbarrotesDet.salidaCostoMN = documentoventaAbarrotesDetBE.salidaCostoMN
            'docVentaAbarrotesDet.salidaCostoME = documentoventaAbarrotesDetBE.salidaCostoME
            ' docVentaAbarrotesDet.preEvento = documentoventaAbarrotesDetBE.preEvento
            docVentaAbarrotesDet.estadoMovimiento = documentoventaAbarrotesDetBE.estadoMovimiento
            'docVentaAbarrotesDet.tipoVenta = documentoventaAbarrotesDetBE.tipoVenta
            docVentaAbarrotesDet.estadoEntrega = documentoventaAbarrotesDetBE.estadoEntrega
            ' docVentaAbarrotesDet.idPadreDTVenta = documentoventaAbarrotesDetBE.idPadreDTVenta
            docVentaAbarrotesDet.estadoPago = documentoventaAbarrotesDetBE.estadoPago

            'docVentaAbarrotesDet.categoria = documentoventaAbarrotesDetBE.categoria
            docVentaAbarrotesDet.estadoEntrega = documentoventaAbarrotesDetBE.estadoEntrega
            docVentaAbarrotesDet.usuarioModificacion = documentoventaAbarrotesDetBE.usuarioModificacion
            docVentaAbarrotesDet.fechaModificacion = documentoventaAbarrotesDetBE.fechaModificacion

            HeliosData.documentoventaAbarrotesDet.Add(docVentaAbarrotesDet)
            HeliosData.SaveChanges()
            ts.Complete()
            Return docVentaAbarrotesDet.secuencia
        End Using
    End Function



    Public Function InsertSingle2(ByVal documentoventaAbarrotesDetBE As documentoventaAbarrotesDet, intIdDocumento As Integer) As Integer
        Dim docVentaAbarrotesDet As New documentoventaAbarrotesDet
        Using ts As New TransactionScope
            docVentaAbarrotesDet.idDocumento = intIdDocumento
            'docVentaAbarrotesDet.idAlmacenOrigen = documentoventaAbarrotesDetBE.idAlmacenOrigen
            docVentaAbarrotesDet.establecimientoOrigen = documentoventaAbarrotesDetBE.establecimientoOrigen
            'docVentaAbarrotesDet.cuentaOrigen = documentoventaAbarrotesDetBE.cuentaOrigen
            docVentaAbarrotesDet.idItem = documentoventaAbarrotesDetBE.idItem
            docVentaAbarrotesDet.nombreItem = documentoventaAbarrotesDetBE.DetalleItem
            'docVentaAbarrotesDet.fechaVcto = documentoventaAbarrotesDetBE.fechaVcto
            docVentaAbarrotesDet.tipoExistencia = documentoventaAbarrotesDetBE.tipoExistencia
            docVentaAbarrotesDet.destino = documentoventaAbarrotesDetBE.destino
            'docVentaAbarrotesDet.unidad1 = documentoventaAbarrotesDetBE.unidad1
            docVentaAbarrotesDet.monto1 = CDec(0.0)
            'docVentaAbarrotesDet.unidad2 = documentoventaAbarrotesDetBE.unidad2
            'docVentaAbarrotesDet.monto2 = documentoventaAbarrotesDetBE.monto2
            'docVentaAbarrotesDet.precioUnitario = documentoventaAbarrotesDetBE.precioUnitario
            'docVentaAbarrotesDet.precioUnitarioUS = documentoventaAbarrotesDetBE.precioUnitarioUS
            docVentaAbarrotesDet.importeMN = documentoventaAbarrotesDetBE.importeMN
            docVentaAbarrotesDet.importeME = documentoventaAbarrotesDetBE.importeME
            docVentaAbarrotesDet.importeMNK = CDec(0.0)
            docVentaAbarrotesDet.importeMEK = CDec(0.0)
            docVentaAbarrotesDet.descuentoMN = CDec(0.0)
            docVentaAbarrotesDet.descuentoME = CDec(0.0)
            docVentaAbarrotesDet.montokardex = CDec(0.0)
            docVentaAbarrotesDet.montoIsc = CDec(0.0)
            docVentaAbarrotesDet.montoIgv = CDec(0.0)
            docVentaAbarrotesDet.otrosTributos = CDec(0.0)
            docVentaAbarrotesDet.montokardexUS = CDec(0.0)
            docVentaAbarrotesDet.montoIscUS = CDec(0.0)
            docVentaAbarrotesDet.montoIgvUS = CDec(0.0)
            docVentaAbarrotesDet.otrosTributosUS = CDec(0.0)
            docVentaAbarrotesDet.salidaCostoMN = CDec(0.0)
            docVentaAbarrotesDet.salidaCostoME = CDec(0.0)
            '    docVentaAbarrotesDet.preEvento = documentoventaAbarrotesDetBE.preEvento
            ' docVentaAbarrotesDet.estadoMovimiento = documentoventaAbarrotesDetBE.estadoMovimiento
            docVentaAbarrotesDet.tipoVenta = documentoventaAbarrotesDetBE.tipoVenta
            docVentaAbarrotesDet.entregado = documentoventaAbarrotesDetBE.entregado
            docVentaAbarrotesDet.idPadreDTVenta = documentoventaAbarrotesDetBE.idPadreDTVenta

            'docVentaAbarrotesDet.estadoPago = documentoventaAbarrotesDetBE.estadoPago
            Select Case documentoventaAbarrotesDetBE.estadoPago
                Case "Pagado"
                    docVentaAbarrotesDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
                Case "Pendiente"
                    docVentaAbarrotesDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                Case Else
                    docVentaAbarrotesDet.estadoPago = docVentaAbarrotesDet.estadoPago
            End Select


            docVentaAbarrotesDet.estadoEntrega = documentoventaAbarrotesDetBE.estadoEntrega
            'docVentaAbarrotesDet.categoria = documentoventaAbarrotesDetBE.categoria

            docVentaAbarrotesDet.usuarioModificacion = documentoventaAbarrotesDetBE.usuarioModificacion
            docVentaAbarrotesDet.fechaModificacion = documentoventaAbarrotesDetBE.fechaModificacion

            HeliosData.documentoventaAbarrotesDet.Add(docVentaAbarrotesDet)
            HeliosData.SaveChanges()
            ts.Complete()
            Return docVentaAbarrotesDet.secuencia
        End Using
    End Function

    Public Function ListadoNotasVentaDetalleHijos(intIdDocumento As Integer) As List(Of documentoventaAbarrotesDet)
        Dim lista As New List(Of documentoventaAbarrotesDet)
        Dim a As New documentoventaAbarrotesDet

        Dim cc = (From c In HeliosData.documentoventaAbarrotesDet
                  Join i In HeliosData.documentoventaAbarrotes
                  On i.idDocumento Equals c.idDocumento
                  Where i.idPadre = intIdDocumento).ToList


        For Each i In cc
            a = New documentoventaAbarrotesDet
            a.idDocumento = i.c.idDocumento
            a.DetalleItem = i.c.DetalleItem
            a.importeMN = i.c.importeMN
            a.importeME = i.c.importeME

            lista.Add(a)
        Next

        Return lista
    End Function

    Public Function GetAnalisiRentabilidad(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strPeriodo As String) As List(Of documentoventaAbarrotesDet)
        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
        Dim objInventarioMovimientoBO As New documentoventaAbarrotesDet
        Try
            Dim consulta = From cab In HeliosData.documentoventaAbarrotes _
                               Join det In HeliosData.documentoventaAbarrotesDet _
                               On cab.idDocumento Equals det.idDocumento _
                               Where cab.idEmpresa = strIdEmpresa _
                               AndAlso cab.idEstablecimiento = intIdEstablecimiento _
                               And cab.fechaPeriodo = strPeriodo And cab.estadoCobro = "DC" _
                               Group det By _
                               cab.fechaPeriodo, det.nombreItem, det.tipoExistencia, det.unidad1, det.monto2, det.tipoVenta _
                               Into g = Group _
                               Select New With {
                                   .Fechaperiodo = fechaPeriodo,
                                   .nombreitem = nombreItem,
                                   .TipoExistencia = tipoExistencia,
                                   .Unidad = unidad1,
                                   .Presentacion = monto2,
                                   .TipoVenta = tipoVenta,
                                   g, .TotalCantidad = g.Sum(Function(det) det.monto1),
                                   .TotalBaseMN = g.Sum(Function(det) det.montokardex),
                                   .TotalBaseME = g.Sum(Function(det) det.montokardexUS),
                                   .TotalSalidaMN = g.Sum(Function(det) det.salidaCostoMN),
                                   .TotalSalidaME = g.Sum(Function(det) det.salidaCostoME)
                                   }


            Try

                For Each obj In consulta
                    objInventarioMovimientoBO = New documentoventaAbarrotesDet With _
                                                {
                                                    .FechaPeriodo = obj.Fechaperiodo, _
                                                    .nombreItem = obj.nombreitem, _
                                                    .tipoExistencia = obj.TipoExistencia, _
                                                    .unidad1 = obj.Unidad, _
                                                    .monto2 = obj.Presentacion, _
                                                    .tipoVenta = obj.TipoVenta, _
                                                    .monto1 = obj.TotalCantidad, _
                                                    .montokardex = obj.TotalBaseMN, _
                                                    .montokardexUS = obj.TotalBaseME, _
                                                    .salidaCostoMN = obj.TotalSalidaMN, _
                                                    .salidaCostoME = obj.TotalSalidaME _
                                                 }
                    ListaDetalle.Add(objInventarioMovimientoBO)
                Next
            Catch ex As ArgumentOutOfRangeException
                MsgBox(ex.Message)
            End Try
            Return ListaDetalle
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub UpdateVentaTicket(ByVal documentoventaAbarrotesDetBE As documentoventaAbarrotesDet)
        Dim docVentaAbarrotesDet As New List(Of documentoventaAbarrotesDet)
        Using ts As New TransactionScope

            docVentaAbarrotesDet = HeliosData.documentoventaAbarrotesDet.Where(Function(o) o.idDocumento = documentoventaAbarrotesDetBE.idDocumento).ToList

            For Each i As documentoventaAbarrotesDet In docVentaAbarrotesDet
                i.entregado = documentoventaAbarrotesDetBE.entregado
                i.estadoPago = "DC"
                'HeliosData.ObjectStateManager.GetObjectStateEntry(i).State.ToString()
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function InsertSingle(ByVal documentoventaAbarrotesDetBE As documentoventaAbarrotesDet, intIdDocumento As Integer) As Integer
        Dim docVentaAbarrotesDet As New documentoventaAbarrotesDet
        Using ts As New TransactionScope
            docVentaAbarrotesDet.equivalencia_id = documentoventaAbarrotesDetBE.equivalencia_id
            docVentaAbarrotesDet.idDocumento = intIdDocumento
            docVentaAbarrotesDet.codigoLote = documentoventaAbarrotesDetBE.codigoLote
            docVentaAbarrotesDet.idAlmacenOrigen = documentoventaAbarrotesDetBE.idAlmacenOrigen
            docVentaAbarrotesDet.establecimientoOrigen = documentoventaAbarrotesDetBE.establecimientoOrigen
            docVentaAbarrotesDet.cuentaOrigen = documentoventaAbarrotesDetBE.cuentaOrigen
            docVentaAbarrotesDet.idItem = documentoventaAbarrotesDetBE.idItem
            docVentaAbarrotesDet.nombreItem = documentoventaAbarrotesDetBE.DetalleItem
            docVentaAbarrotesDet.fechaVcto = documentoventaAbarrotesDetBE.fechaVcto
            docVentaAbarrotesDet.tipoExistencia = documentoventaAbarrotesDetBE.tipoExistencia
            docVentaAbarrotesDet.destino = documentoventaAbarrotesDetBE.destino
            docVentaAbarrotesDet.unidad1 = documentoventaAbarrotesDetBE.unidad1
            docVentaAbarrotesDet.monto1 = documentoventaAbarrotesDetBE.monto1
            docVentaAbarrotesDet.unidad2 = documentoventaAbarrotesDetBE.unidad2
            docVentaAbarrotesDet.monto2 = documentoventaAbarrotesDetBE.monto2
            docVentaAbarrotesDet.precioUnitario = documentoventaAbarrotesDetBE.precioUnitario
            docVentaAbarrotesDet.precioUnitarioUS = documentoventaAbarrotesDetBE.precioUnitarioUS
            docVentaAbarrotesDet.importeMN = documentoventaAbarrotesDetBE.importeMN
            docVentaAbarrotesDet.importeME = documentoventaAbarrotesDetBE.importeME
            docVentaAbarrotesDet.importeMNK = documentoventaAbarrotesDetBE.importeMNK
            docVentaAbarrotesDet.importeMEK = documentoventaAbarrotesDetBE.importeMEK
            docVentaAbarrotesDet.descuentoMN = documentoventaAbarrotesDetBE.descuentoMN
            docVentaAbarrotesDet.descuentoME = documentoventaAbarrotesDetBE.descuentoME
            docVentaAbarrotesDet.montokardex = documentoventaAbarrotesDetBE.montokardex
            docVentaAbarrotesDet.montoIsc = documentoventaAbarrotesDetBE.montoIsc
            docVentaAbarrotesDet.montoIgv = documentoventaAbarrotesDetBE.montoIgv
            docVentaAbarrotesDet.otrosTributos = documentoventaAbarrotesDetBE.otrosTributos
            docVentaAbarrotesDet.montokardexUS = documentoventaAbarrotesDetBE.montokardexUS
            docVentaAbarrotesDet.montoIscUS = documentoventaAbarrotesDetBE.montoIscUS
            docVentaAbarrotesDet.montoIgvUS = documentoventaAbarrotesDetBE.montoIgvUS
            docVentaAbarrotesDet.otrosTributosUS = documentoventaAbarrotesDetBE.otrosTributosUS
            docVentaAbarrotesDet.salidaCostoMN = documentoventaAbarrotesDetBE.salidaCostoMN
            docVentaAbarrotesDet.salidaCostoME = documentoventaAbarrotesDetBE.salidaCostoME
            docVentaAbarrotesDet.notaCreditoMN = documentoventaAbarrotesDetBE.notaCreditoMN
            '    docVentaAbarrotesDet.preEvento = documentoventaAbarrotesDetBE.preEvento
            docVentaAbarrotesDet.estadoMovimiento = documentoventaAbarrotesDetBE.estadoMovimiento
            docVentaAbarrotesDet.tipoVenta = documentoventaAbarrotesDetBE.tipoVenta
            docVentaAbarrotesDet.entregado = documentoventaAbarrotesDetBE.entregado
            docVentaAbarrotesDet.idPadreDTVenta = documentoventaAbarrotesDetBE.idPadreDTVenta

            docVentaAbarrotesDet.montoIcbper = documentoventaAbarrotesDetBE.montoIcbper
            docVentaAbarrotesDet.montoIcbperUS = documentoventaAbarrotesDetBE.montoIcbperUS
            docVentaAbarrotesDet.tasaIcbper = documentoventaAbarrotesDetBE.tasaIcbper
            'docVentaAbarrotesDet.estadoPago = documentoventaAbarrotesDetBE.estadoPago
            Select Case documentoventaAbarrotesDetBE.estadoPago
                Case "Pagado"
                    docVentaAbarrotesDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
                Case "Pendiente"
                    docVentaAbarrotesDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                Case Else
                    docVentaAbarrotesDet.estadoPago = documentoventaAbarrotesDetBE.estadoPago
            End Select


            docVentaAbarrotesDet.estadoEntrega = documentoventaAbarrotesDetBE.estadoEntrega
            docVentaAbarrotesDet.categoria = documentoventaAbarrotesDetBE.categoria

            docVentaAbarrotesDet.usuarioModificacion = documentoventaAbarrotesDetBE.usuarioModificacion
            docVentaAbarrotesDet.fechaModificacion = documentoventaAbarrotesDetBE.fechaModificacion

            HeliosData.documentoventaAbarrotesDet.Add(docVentaAbarrotesDet)
            HeliosData.SaveChanges()
            ts.Complete()
            Return docVentaAbarrotesDet.secuencia
        End Using
    End Function

    Public Function Insert(ByVal documentoventaAbarrotesDetBE As documentoventaAbarrotesDet) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoventaAbarrotesDet.Add(documentoventaAbarrotesDetBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoventaAbarrotesDetBE.secuencia
        End Using
    End Function

    Public Sub Update(ByVal documentoventaAbarrotesDetBE As documentoventaAbarrotesDet, strTipoDoc As String)
        Dim OBJD As New documentoventaAbarrotesDet
        Using ts As New TransactionScope
            If documentoventaAbarrotesDetBE.Action = Business.Entity.BaseBE.EntityAction.UPDATE Then
                Dim docVentaAbarrotesDet As documentoventaAbarrotesDet = HeliosData.documentoventaAbarrotesDet.Where(Function(o) _
                                           o.idDocumento = documentoventaAbarrotesDetBE.idDocumento _
                                           And o.secuencia = documentoventaAbarrotesDetBE.secuencia).First()

                docVentaAbarrotesDet.idAlmacenOrigen = documentoventaAbarrotesDetBE.idAlmacenOrigen
                docVentaAbarrotesDet.establecimientoOrigen = documentoventaAbarrotesDetBE.establecimientoOrigen
                docVentaAbarrotesDet.cuentaOrigen = documentoventaAbarrotesDetBE.cuentaOrigen
                docVentaAbarrotesDet.idItem = documentoventaAbarrotesDetBE.idItem
                docVentaAbarrotesDet.nombreItem = documentoventaAbarrotesDetBE.DetalleItem
                docVentaAbarrotesDet.fechaVcto = documentoventaAbarrotesDetBE.fechaVcto
                docVentaAbarrotesDet.tipoExistencia = documentoventaAbarrotesDetBE.tipoExistencia
                docVentaAbarrotesDet.destino = documentoventaAbarrotesDetBE.destino
                docVentaAbarrotesDet.unidad1 = documentoventaAbarrotesDetBE.unidad1
                docVentaAbarrotesDet.monto1 = documentoventaAbarrotesDetBE.monto1
                docVentaAbarrotesDet.unidad2 = documentoventaAbarrotesDetBE.unidad2
                docVentaAbarrotesDet.monto2 = documentoventaAbarrotesDetBE.monto2
                docVentaAbarrotesDet.precioUnitario = documentoventaAbarrotesDetBE.precioUnitario
                docVentaAbarrotesDet.precioUnitarioUS = documentoventaAbarrotesDetBE.precioUnitarioUS
                docVentaAbarrotesDet.importeMN = documentoventaAbarrotesDetBE.importeMN
                docVentaAbarrotesDet.importeME = documentoventaAbarrotesDetBE.importeME
                docVentaAbarrotesDet.importeMNK = documentoventaAbarrotesDetBE.importeMNK
                docVentaAbarrotesDet.importeMEK = documentoventaAbarrotesDetBE.importeMEK
                docVentaAbarrotesDet.descuentoMN = documentoventaAbarrotesDetBE.descuentoMN
                docVentaAbarrotesDet.descuentoME = documentoventaAbarrotesDetBE.descuentoME
                docVentaAbarrotesDet.montokardex = documentoventaAbarrotesDetBE.montokardex
                docVentaAbarrotesDet.montoIsc = documentoventaAbarrotesDetBE.montoIsc
                docVentaAbarrotesDet.montoIgv = documentoventaAbarrotesDetBE.montoIgv
                docVentaAbarrotesDet.otrosTributos = documentoventaAbarrotesDetBE.otrosTributos
                docVentaAbarrotesDet.montokardexUS = documentoventaAbarrotesDetBE.montokardexUS
                docVentaAbarrotesDet.montoIscUS = documentoventaAbarrotesDetBE.montoIscUS
                docVentaAbarrotesDet.montoIgvUS = documentoventaAbarrotesDetBE.montoIgvUS
                docVentaAbarrotesDet.otrosTributosUS = documentoventaAbarrotesDetBE.otrosTributosUS
                docVentaAbarrotesDet.salidaCostoMN = documentoventaAbarrotesDetBE.salidaCostoMN
                docVentaAbarrotesDet.salidaCostoME = documentoventaAbarrotesDetBE.salidaCostoME
                docVentaAbarrotesDet.preEvento = documentoventaAbarrotesDetBE.preEvento
                docVentaAbarrotesDet.estadoMovimiento = documentoventaAbarrotesDetBE.estadoMovimiento
                docVentaAbarrotesDet.tipoVenta = documentoventaAbarrotesDetBE.tipoVenta
                docVentaAbarrotesDet.entregado = documentoventaAbarrotesDetBE.entregado
                docVentaAbarrotesDet.usuarioModificacion = documentoventaAbarrotesDetBE.usuarioModificacion
                docVentaAbarrotesDet.fechaModificacion = documentoventaAbarrotesDetBE.fechaModificacion

                'HeliosData.ObjectStateManager.GetObjectStateEntry(docVentaAbarrotesDet).State.ToString()

            ElseIf documentoventaAbarrotesDetBE.Action = Business.Entity.BaseBE.EntityAction.INSERT Then

                OBJD = New documentoventaAbarrotesDet
                OBJD.idDocumento = documentoventaAbarrotesDetBE.idDocumento
                OBJD.idAlmacenOrigen = documentoventaAbarrotesDetBE.idAlmacenOrigen
                OBJD.establecimientoOrigen = documentoventaAbarrotesDetBE.establecimientoOrigen
                OBJD.cuentaOrigen = documentoventaAbarrotesDetBE.cuentaOrigen
                OBJD.idItem = documentoventaAbarrotesDetBE.idItem
                OBJD.nombreItem = documentoventaAbarrotesDetBE.DetalleItem
                OBJD.fechaVcto = documentoventaAbarrotesDetBE.fechaVcto
                OBJD.tipoExistencia = documentoventaAbarrotesDetBE.tipoExistencia
                OBJD.destino = documentoventaAbarrotesDetBE.destino
                OBJD.unidad1 = documentoventaAbarrotesDetBE.unidad1
                OBJD.monto1 = documentoventaAbarrotesDetBE.monto1
                OBJD.unidad2 = documentoventaAbarrotesDetBE.unidad2
                OBJD.monto2 = documentoventaAbarrotesDetBE.monto2
                OBJD.precioUnitario = documentoventaAbarrotesDetBE.precioUnitario
                OBJD.precioUnitarioUS = documentoventaAbarrotesDetBE.precioUnitarioUS
                OBJD.importeMN = documentoventaAbarrotesDetBE.importeMN
                OBJD.importeME = documentoventaAbarrotesDetBE.importeME
                OBJD.importeMNK = documentoventaAbarrotesDetBE.importeMNK
                OBJD.importeMEK = documentoventaAbarrotesDetBE.importeMEK
                OBJD.descuentoMN = documentoventaAbarrotesDetBE.descuentoMN
                OBJD.descuentoME = documentoventaAbarrotesDetBE.descuentoME
                OBJD.montokardex = documentoventaAbarrotesDetBE.montokardex
                OBJD.montoIsc = documentoventaAbarrotesDetBE.montoIsc
                OBJD.montoIgv = documentoventaAbarrotesDetBE.montoIgv
                OBJD.otrosTributos = documentoventaAbarrotesDetBE.otrosTributos
                OBJD.montokardexUS = documentoventaAbarrotesDetBE.montokardexUS
                OBJD.montoIscUS = documentoventaAbarrotesDetBE.montoIscUS
                OBJD.montoIgvUS = documentoventaAbarrotesDetBE.montoIgvUS
                OBJD.otrosTributosUS = documentoventaAbarrotesDetBE.otrosTributosUS
                OBJD.salidaCostoMN = documentoventaAbarrotesDetBE.salidaCostoMN
                OBJD.salidaCostoME = documentoventaAbarrotesDetBE.salidaCostoME
                OBJD.preEvento = documentoventaAbarrotesDetBE.preEvento
                OBJD.estadoMovimiento = documentoventaAbarrotesDetBE.estadoMovimiento
                OBJD.tipoVenta = documentoventaAbarrotesDetBE.tipoVenta
                OBJD.entregado = documentoventaAbarrotesDetBE.entregado
                OBJD.usuarioModificacion = documentoventaAbarrotesDetBE.usuarioModificacion
                OBJD.fechaModificacion = documentoventaAbarrotesDetBE.fechaModificacion
                HeliosData.documentoventaAbarrotesDet.Add(OBJD)

            ElseIf documentoventaAbarrotesDetBE.Action = Business.Entity.BaseBE.EntityAction.DELETE Then
                Dim consulta = (From n In HeliosData.documentoventaAbarrotesDet _
                               Where n.secuencia = documentoventaAbarrotesDetBE.secuencia).First

                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)

            End If


            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub UpdateVentaV2(ByVal documentoventaAbarrotesDetBE As documentoventaAbarrotesDet, strTipoDoc As String)
        Dim OBJD As New documentoventaAbarrotesDet
        Using ts As New TransactionScope
            If documentoventaAbarrotesDetBE.Action = Business.Entity.BaseBE.EntityAction.UPDATE Then
                Dim docVentaAbarrotesDet As documentoventaAbarrotesDet = HeliosData.documentoventaAbarrotesDet.Where(Function(o) _
                                           o.idDocumento = documentoventaAbarrotesDetBE.idDocumento _
                                           And o.secuencia = documentoventaAbarrotesDetBE.secuencia).FirstOrDefault()

                If (Not IsNothing(docVentaAbarrotesDet)) Then
                    docVentaAbarrotesDet.idAlmacenOrigen = documentoventaAbarrotesDetBE.idAlmacenOrigen
                    docVentaAbarrotesDet.establecimientoOrigen = documentoventaAbarrotesDetBE.establecimientoOrigen
                    docVentaAbarrotesDet.cuentaOrigen = documentoventaAbarrotesDetBE.cuentaOrigen
                    docVentaAbarrotesDet.idItem = documentoventaAbarrotesDetBE.idItem
                    docVentaAbarrotesDet.nombreItem = documentoventaAbarrotesDetBE.DetalleItem
                    docVentaAbarrotesDet.fechaVcto = documentoventaAbarrotesDetBE.fechaVcto
                    docVentaAbarrotesDet.tipoExistencia = documentoventaAbarrotesDetBE.tipoExistencia
                    docVentaAbarrotesDet.destino = documentoventaAbarrotesDetBE.destino
                    docVentaAbarrotesDet.unidad1 = documentoventaAbarrotesDetBE.unidad1
                    docVentaAbarrotesDet.monto1 = documentoventaAbarrotesDetBE.monto1
                    docVentaAbarrotesDet.unidad2 = documentoventaAbarrotesDetBE.unidad2
                    docVentaAbarrotesDet.monto2 = documentoventaAbarrotesDetBE.monto2
                    docVentaAbarrotesDet.precioUnitario = documentoventaAbarrotesDetBE.precioUnitario
                    docVentaAbarrotesDet.precioUnitarioUS = documentoventaAbarrotesDetBE.precioUnitarioUS
                    docVentaAbarrotesDet.importeMN = documentoventaAbarrotesDetBE.importeMN
                    docVentaAbarrotesDet.importeME = documentoventaAbarrotesDetBE.importeME
                    docVentaAbarrotesDet.importeMNK = documentoventaAbarrotesDetBE.importeMNK
                    docVentaAbarrotesDet.importeMEK = documentoventaAbarrotesDetBE.importeMEK
                    docVentaAbarrotesDet.descuentoMN = documentoventaAbarrotesDetBE.descuentoMN
                    docVentaAbarrotesDet.descuentoME = documentoventaAbarrotesDetBE.descuentoME
                    docVentaAbarrotesDet.montokardex = documentoventaAbarrotesDetBE.montokardex
                    docVentaAbarrotesDet.montoIsc = documentoventaAbarrotesDetBE.montoIsc
                    docVentaAbarrotesDet.montoIgv = documentoventaAbarrotesDetBE.montoIgv
                    docVentaAbarrotesDet.otrosTributos = documentoventaAbarrotesDetBE.otrosTributos
                    docVentaAbarrotesDet.montokardexUS = documentoventaAbarrotesDetBE.montokardexUS
                    docVentaAbarrotesDet.montoIscUS = documentoventaAbarrotesDetBE.montoIscUS
                    docVentaAbarrotesDet.montoIgvUS = documentoventaAbarrotesDetBE.montoIgvUS
                    docVentaAbarrotesDet.otrosTributosUS = documentoventaAbarrotesDetBE.otrosTributosUS
                    docVentaAbarrotesDet.salidaCostoMN = documentoventaAbarrotesDetBE.salidaCostoMN
                    docVentaAbarrotesDet.salidaCostoME = documentoventaAbarrotesDetBE.salidaCostoME
                    docVentaAbarrotesDet.preEvento = documentoventaAbarrotesDetBE.preEvento
                    docVentaAbarrotesDet.estadoMovimiento = documentoventaAbarrotesDetBE.estadoMovimiento
                    docVentaAbarrotesDet.tipoVenta = documentoventaAbarrotesDetBE.tipoVenta
                    docVentaAbarrotesDet.entregado = documentoventaAbarrotesDetBE.entregado
                    docVentaAbarrotesDet.usuarioModificacion = documentoventaAbarrotesDetBE.usuarioModificacion
                    docVentaAbarrotesDet.fechaModificacion = documentoventaAbarrotesDetBE.fechaModificacion
                Else
                    OBJD = New documentoventaAbarrotesDet
                    OBJD.idDocumento = documentoventaAbarrotesDetBE.idDocumento
                    OBJD.idAlmacenOrigen = documentoventaAbarrotesDetBE.idAlmacenOrigen
                    OBJD.establecimientoOrigen = documentoventaAbarrotesDetBE.establecimientoOrigen
                    OBJD.cuentaOrigen = documentoventaAbarrotesDetBE.cuentaOrigen
                    OBJD.idItem = documentoventaAbarrotesDetBE.idItem
                    OBJD.nombreItem = documentoventaAbarrotesDetBE.DetalleItem
                    OBJD.fechaVcto = documentoventaAbarrotesDetBE.fechaVcto
                    OBJD.tipoExistencia = documentoventaAbarrotesDetBE.tipoExistencia
                    OBJD.destino = documentoventaAbarrotesDetBE.destino
                    OBJD.unidad1 = documentoventaAbarrotesDetBE.unidad1
                    OBJD.monto1 = documentoventaAbarrotesDetBE.monto1
                    OBJD.unidad2 = documentoventaAbarrotesDetBE.unidad2
                    OBJD.monto2 = documentoventaAbarrotesDetBE.monto2
                    OBJD.precioUnitario = documentoventaAbarrotesDetBE.precioUnitario
                    OBJD.precioUnitarioUS = documentoventaAbarrotesDetBE.precioUnitarioUS
                    OBJD.importeMN = documentoventaAbarrotesDetBE.importeMN
                    OBJD.importeME = documentoventaAbarrotesDetBE.importeME
                    OBJD.importeMNK = documentoventaAbarrotesDetBE.importeMNK
                    OBJD.importeMEK = documentoventaAbarrotesDetBE.importeMEK
                    OBJD.descuentoMN = documentoventaAbarrotesDetBE.descuentoMN
                    OBJD.descuentoME = documentoventaAbarrotesDetBE.descuentoME
                    OBJD.montokardex = documentoventaAbarrotesDetBE.montokardex
                    OBJD.montoIsc = documentoventaAbarrotesDetBE.montoIsc
                    OBJD.montoIgv = documentoventaAbarrotesDetBE.montoIgv
                    OBJD.otrosTributos = documentoventaAbarrotesDetBE.otrosTributos
                    OBJD.montokardexUS = documentoventaAbarrotesDetBE.montokardexUS
                    OBJD.montoIscUS = documentoventaAbarrotesDetBE.montoIscUS
                    OBJD.montoIgvUS = documentoventaAbarrotesDetBE.montoIgvUS
                    OBJD.otrosTributosUS = documentoventaAbarrotesDetBE.otrosTributosUS
                    OBJD.salidaCostoMN = documentoventaAbarrotesDetBE.salidaCostoMN
                    OBJD.salidaCostoME = documentoventaAbarrotesDetBE.salidaCostoME
                    OBJD.preEvento = documentoventaAbarrotesDetBE.preEvento
                    OBJD.estadoMovimiento = documentoventaAbarrotesDetBE.estadoMovimiento
                    OBJD.tipoVenta = documentoventaAbarrotesDetBE.tipoVenta
                    OBJD.entregado = documentoventaAbarrotesDetBE.entregado
                    OBJD.usuarioModificacion = documentoventaAbarrotesDetBE.usuarioModificacion
                    OBJD.fechaModificacion = documentoventaAbarrotesDetBE.fechaModificacion
                    HeliosData.documentoventaAbarrotesDet.Add(OBJD)
                End If



                'HeliosData.ObjectStateManager.GetObjectStateEntry(docVentaAbarrotesDet).State.ToString()

            ElseIf documentoventaAbarrotesDetBE.Action = Business.Entity.BaseBE.EntityAction.INSERT Then

                OBJD = New documentoventaAbarrotesDet
                OBJD.idDocumento = documentoventaAbarrotesDetBE.idDocumento
                OBJD.idAlmacenOrigen = documentoventaAbarrotesDetBE.idAlmacenOrigen
                OBJD.establecimientoOrigen = documentoventaAbarrotesDetBE.establecimientoOrigen
                OBJD.cuentaOrigen = documentoventaAbarrotesDetBE.cuentaOrigen
                OBJD.idItem = documentoventaAbarrotesDetBE.idItem
                OBJD.nombreItem = documentoventaAbarrotesDetBE.DetalleItem
                OBJD.fechaVcto = documentoventaAbarrotesDetBE.fechaVcto
                OBJD.tipoExistencia = documentoventaAbarrotesDetBE.tipoExistencia
                OBJD.destino = documentoventaAbarrotesDetBE.destino
                OBJD.unidad1 = documentoventaAbarrotesDetBE.unidad1
                OBJD.monto1 = documentoventaAbarrotesDetBE.monto1
                OBJD.unidad2 = documentoventaAbarrotesDetBE.unidad2
                OBJD.monto2 = documentoventaAbarrotesDetBE.monto2
                OBJD.precioUnitario = documentoventaAbarrotesDetBE.precioUnitario
                OBJD.precioUnitarioUS = documentoventaAbarrotesDetBE.precioUnitarioUS
                OBJD.importeMN = documentoventaAbarrotesDetBE.importeMN
                OBJD.importeME = documentoventaAbarrotesDetBE.importeME
                OBJD.importeMNK = documentoventaAbarrotesDetBE.importeMNK
                OBJD.importeMEK = documentoventaAbarrotesDetBE.importeMEK
                OBJD.descuentoMN = documentoventaAbarrotesDetBE.descuentoMN
                OBJD.descuentoME = documentoventaAbarrotesDetBE.descuentoME
                OBJD.montokardex = documentoventaAbarrotesDetBE.montokardex
                OBJD.montoIsc = documentoventaAbarrotesDetBE.montoIsc
                OBJD.montoIgv = documentoventaAbarrotesDetBE.montoIgv
                OBJD.otrosTributos = documentoventaAbarrotesDetBE.otrosTributos
                OBJD.montokardexUS = documentoventaAbarrotesDetBE.montokardexUS
                OBJD.montoIscUS = documentoventaAbarrotesDetBE.montoIscUS
                OBJD.montoIgvUS = documentoventaAbarrotesDetBE.montoIgvUS
                OBJD.otrosTributosUS = documentoventaAbarrotesDetBE.otrosTributosUS
                OBJD.salidaCostoMN = documentoventaAbarrotesDetBE.salidaCostoMN
                OBJD.salidaCostoME = documentoventaAbarrotesDetBE.salidaCostoME
                OBJD.preEvento = documentoventaAbarrotesDetBE.preEvento
                OBJD.estadoMovimiento = documentoventaAbarrotesDetBE.estadoMovimiento
                OBJD.tipoVenta = documentoventaAbarrotesDetBE.tipoVenta
                OBJD.entregado = documentoventaAbarrotesDetBE.entregado
                OBJD.usuarioModificacion = documentoventaAbarrotesDetBE.usuarioModificacion
                OBJD.fechaModificacion = documentoventaAbarrotesDetBE.fechaModificacion
                HeliosData.documentoventaAbarrotesDet.Add(OBJD)

            ElseIf documentoventaAbarrotesDetBE.Action = Business.Entity.BaseBE.EntityAction.DELETE Then
                Dim consulta = (From n In HeliosData.documentoventaAbarrotesDet
                                Where n.secuencia = documentoventaAbarrotesDetBE.secuencia).First

                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)

            End If


            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub DeleteItemVenta(ByVal documentoventaAbarrotesDetBE As documentoventaAbarrotesDet)
        Try
            Using ts As New TransactionScope
                EliminarItem(documentoventaAbarrotesDetBE)

                Dim docDetalle = (From n In HeliosData.documentoventaAbarrotesDet
                                  Where n.idDocumento = documentoventaAbarrotesDetBE.idDocumento).ToList


                If Not IsNothing(docDetalle) Then
                    Dim documento = (From i In HeliosData.documentoventaAbarrotes
                                     Where i.idDocumento = documentoventaAbarrotesDetBE.idDocumento).FirstOrDefault


                    documento.bi01 = docDetalle.Where(Function(o) o.destino = "1").Sum(Function(o) o.montokardex)
                    documento.bi01us = docDetalle.Where(Function(o) o.destino = "1").Sum(Function(o) o.montokardexUS)

                    documento.bi02 = docDetalle.Where(Function(o) o.destino = "2").Sum(Function(o) o.montokardex)
                    documento.bi02us = docDetalle.Where(Function(o) o.destino = "2").Sum(Function(o) o.montokardexUS)

                    documento.igv01 = docDetalle.Sum(Function(o) o.montoIgv)
                    documento.igv01us = docDetalle.Sum(Function(o) o.montoIgvUS)

                    documento.importeCostoMN = docDetalle.Sum(Function(o) o.salidaCostoMN)
                    documento.importeCostoME = docDetalle.Sum(Function(o) o.salidaCostoME)

                    documento.ImporteNacional = docDetalle.Sum(Function(o) o.importeMN)
                    documento.ImporteExtranjero = docDetalle.Sum(Function(o) o.importeME)
                End If

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EliminarItem(documentoventaAbarrotesDetBE As documentoventaAbarrotesDet)
        Using ts As New TransactionScope
            Dim consulta = (From n In HeliosData.documentoventaAbarrotesDet _
                       Where n.secuencia = documentoventaAbarrotesDetBE.secuencia).FirstOrDefault

            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetListar_documentoventaAbarrotesDet() As List(Of documentoventaAbarrotesDet)
        Return (From a In HeliosData.documentoventaAbarrotesDet Select a).ToList
    End Function

    Public Function GetUbicar_documentoventaAbarrotesDetPorID(Secuencia As Integer) As documentoventaAbarrotesDet
        Return (From a In HeliosData.documentoventaAbarrotesDet
                 Where a.secuencia = Secuencia).First
    End Function

    Public Function GetUbicar_documentoventaAbarrotesDetPorIDocumento(intidDocumento As Integer) As List(Of documentoventaAbarrotesDet)
        Return (From a In HeliosData.documentoventaAbarrotesDet
                 Where a.idDocumento = intidDocumento Select a).ToList
    End Function

    Public Function UbicarDetallePinturas(intidDocumento As Integer) As List(Of documentoventaAbarrotesDet)
        Dim obj As New documentoventaAbarrotesDet
        Dim Lista As New List(Of documentoventaAbarrotesDet)

        Dim con = (From n In HeliosData.documentoventaAbarrotesDet _
                  Join itemx In HeliosData.detalleitems _
                  On itemx.codigodetalle Equals n.idItem _
                  Join marca In HeliosData.item _
                  On marca.idItem Equals itemx.marcaRef
                  Where n.idDocumento = intidDocumento And n.tipoExistencia = TipoExistencia.ProductoTerminado).ToList

        For Each i In con
            obj = New documentoventaAbarrotesDet
            obj.idDocumento = i.n.idDocumento
            obj.idItem = i.itemx.codigodetalle
            obj.nombreItem = i.itemx.descripcionItem
            obj.secuencia = i.n.secuencia
            obj.unidad1 = i.itemx.unidad1
            obj.tipoExistencia = i.itemx.tipoExistencia
            obj.NomMarca = i.marca.descripcion
            obj.monto1 = i.n.monto1
            Lista.Add(obj)
        Next

        Return Lista
    End Function

    Public Function Get_EditarDetalleVentaSinLote(intidDocumento As Integer) As List(Of documentoventaAbarrotesDet)
        Dim detalle As New documentoventaAbarrotesDet
        Dim lista As New List(Of documentoventaAbarrotesDet)

        Dim consulta = (From doc In HeliosData.documentoventaAbarrotesDet
                        Join alm In HeliosData.totalesAlmacen On CInt(doc.idAlmacenOrigen) Equals alm.idAlmacen _
                            And doc.idItem Equals CStr(alm.idItem)
                        Join al In HeliosData.almacen On alm.idAlmacen Equals al.idAlmacen
                        Where
                             CLng(doc.idDocumento) = intidDocumento
                        Group New With {doc, al, alm} By
                            doc.secuencia,
                            doc.tipoVenta,
                            al.descripcionAlmacen,
                            doc.idAlmacenOrigen,
                            doc.idItem,
                            doc.nombreItem,
                            doc.tipoExistencia,
                            doc.destino,
                            doc.unidad1,
                            doc.monto1,
                            doc.precioUnitario,
                            doc.precioUnitarioUS,
                            doc.importeMN,
                            doc.importeME,
                            doc.importeMNK,
                            doc.importeMEK,
                            doc.salidaCostoMN,
                            doc.salidaCostoME,
                            doc.montokardex,
                            doc.montokardexUS,
                            doc.montoIgv,
                            doc.montoIgvUS,
                            doc.entregado,
                            doc.codigoLote,
                            doc.estadoPago,
                            doc.idDocumento
                            Into g = Group
                        Select
                            secuencia,
                            tipoVenta,
                            descripcionAlmacen,
                            IdAlmacenOrigen = CType(idAlmacenOrigen, Int32?),
                            idItem,
                            nombreItem,
                            tipoExistencia,
                            destino,
                            unidad1,
                            monto1,
                            stockAlm = CType(g.Sum(Function(p) p.alm.cantidad), Decimal?),
                            precioUnitario,
                            precioUnitarioUS,
                            importeMN,
                            importeME,
                            importeMNK,
                            importeMEK,
                            salidaCostoMN,
                            salidaCostoME,
                            montokardex,
                            montokardexUS,
                            montoIgv,
                            montoIgvUS,
                            entregado,
                            codigoLote,
                            estadoPago,
                            idDocumento).ToList

        For Each i In consulta
            detalle = New documentoventaAbarrotesDet
            detalle.secuencia = i.secuencia
            detalle.idAlmacenOrigen = i.IdAlmacenOrigen
            detalle.NombreAlmacen = i.descripcionAlmacen
            detalle.tipoVenta = i.tipoVenta
            detalle.idItem = i.idItem
            detalle.nombreItem = i.nombreItem
            detalle.tipoExistencia = i.tipoExistencia
            detalle.destino = i.destino
            detalle.unidad1 = i.unidad1
            detalle.monto1 = i.monto1
            detalle.stock = i.stockAlm + i.monto1
            detalle.precioUnitario = i.precioUnitario
            detalle.precioUnitarioUS = i.precioUnitarioUS
            detalle.importeMN = i.importeMN
            detalle.importeME = i.importeME
            detalle.importeMNK = i.importeMNK
            detalle.importeMEK = i.importeMEK
            detalle.salidaCostoMN = i.salidaCostoMN
            detalle.salidaCostoME = i.salidaCostoME
            detalle.montokardex = i.montokardex
            detalle.montokardexUS = i.montokardexUS
            detalle.montoIgv = i.montoIgv
            detalle.montoIgvUS = i.montoIgvUS
            detalle.entregado = i.entregado
            detalle.codigoLote = i.codigoLote
            detalle.estadoPago = i.estadoPago
            lista.Add(detalle)
        Next

        Return lista
    End Function


    Public Function usp_EditarDetalleVenta(intidDocumento As Integer) As List(Of documentoventaAbarrotesDet)
        Dim det As New documentoventaAbarrotesDet
        Dim lista As New List(Of documentoventaAbarrotesDet)
        Dim conuslta = (From n In HeliosData.usp_EditarDetalleVenta(intidDocumento) _
                       Select n).ToList

        For Each i In conuslta
            det = New documentoventaAbarrotesDet
            det.secuencia = i.secuencia
            det.idAlmacenOrigen = i.idAlmacenOrigen
            det.NombreAlmacen = i.descripcionAlmacen
            det.tipoVenta = i.tipoVenta
            det.idItem = i.idItem
            det.nombreItem = i.nombreItem
            det.tipoExistencia = i.tipoExistencia
            det.destino = i.destino
            det.unidad1 = i.unidad1
            det.monto1 = i.cantidad
            det.stock = i.stock
            det.precioUnitario = i.precioUnitario
            det.precioUnitarioUS = i.precioUnitarioUS
            det.importeMN = i.importeMN
            det.importeME = i.importeME
            det.importeMNK = i.importeMNK
            det.importeMEK = i.importeMEK
            det.salidaCostoMN = i.salidaCostoMN
            det.salidaCostoME = i.salidaCostoME
            det.montokardex = i.montokardex
            det.montokardexUS = i.montokardexUS
            det.montoIgv = i.montoIgv
            det.montoIgvUS = i.montoIgvUS
            det.entregado = i.entregado
            det.codigoLote = i.codigoLote
            det.estadoPago = i.estadoPago
            lista.Add(det)
        Next

        Return lista
    End Function

    Public Function GetListarAllVentasEntregablesDeMercaderia(intIdEstablec As Integer, strPeriodo As String, stridDocumento As Integer) As List(Of documentoventaAbarrotesDet)
        Dim Lista As New List(Of documentoventaAbarrotesDet)
        Dim ListaTipo As New List(Of String)

        ListaTipo.Add(TIPO_VENTA.VENTA_GENERAL)
        ListaTipo.Add(TIPO_VENTA.VENTA_POS_DIRECTA)

        Dim objRecurso As New documentoventaAbarrotesDet
        Dim consulta = (From doc In HeliosData.documentoventaAbarrotes
                        Join compra In HeliosData.documentoventaAbarrotesDet
                       On doc.idDocumento Equals compra.idDocumento
                        Where doc.idEstablecimiento = intIdEstablec And
                       doc.fechaPeriodo = strPeriodo And ListaTipo.Contains(doc.tipoVenta) And doc.idDocumento = stridDocumento).ToList

        For Each obj In consulta
            objRecurso = New documentoventaAbarrotesDet

            Dim totals3 = Aggregate p In HeliosData.documentoGuia
                     Join compra In HeliosData.documentoguiaDetalle
                     On p.idDocumento Equals compra.idDocumento
                                Where compra.idDocumentoPadre = obj.doc.idDocumento _
                                And compra.idItem = obj.compra.idItem
                Into mne = Sum(p.importeME),
                mn = Sum(compra.cantidad)

            objRecurso.idDocumento = obj.compra.idDocumento
            objRecurso.secuencia = obj.compra.secuencia
            objRecurso.FechaDoc = obj.compra.FechaDoc
            objRecurso.tipoExistencia = obj.compra.tipoExistencia
            objRecurso.Serie = obj.compra.Serie
            objRecurso.idItem = obj.compra.idItem
            objRecurso.nombreItem = obj.compra.nombreItem
            objRecurso.idItem = obj.compra.idItem
            objRecurso.tipoVenta = obj.compra.tipoVenta
            objRecurso.monto1 = obj.compra.monto1
            objRecurso.monto2 = totals3.mn.GetValueOrDefault
            Lista.Add(objRecurso)
        Next

        Return Lista
    End Function
    Public Function InsertSingleContado(ByVal documentoventaAbarrotesDetBE As documentoventaAbarrotesDet, intIdDocumento As Integer) As Integer
        Dim docVentaAbarrotesDet As New documentoventaAbarrotesDet
        Dim objcondicionBL As New documentoGuiaDetalleCondicionBL
        Dim objcondicion As New documentoguiaDetalleCondicion

        Using ts As New TransactionScope
            docVentaAbarrotesDet.idDocumento = intIdDocumento
            docVentaAbarrotesDet.codigoLote = documentoventaAbarrotesDetBE.codigoLote
            docVentaAbarrotesDet.idAlmacenOrigen = documentoventaAbarrotesDetBE.idAlmacenOrigen
            docVentaAbarrotesDet.establecimientoOrigen = documentoventaAbarrotesDetBE.establecimientoOrigen
            docVentaAbarrotesDet.cuentaOrigen = documentoventaAbarrotesDetBE.cuentaOrigen
            docVentaAbarrotesDet.idItem = documentoventaAbarrotesDetBE.idItem
            docVentaAbarrotesDet.nombreItem = documentoventaAbarrotesDetBE.DetalleItem
            docVentaAbarrotesDet.fechaVcto = documentoventaAbarrotesDetBE.fechaVcto
            docVentaAbarrotesDet.tipoExistencia = documentoventaAbarrotesDetBE.tipoExistencia
            docVentaAbarrotesDet.destino = documentoventaAbarrotesDetBE.destino
            docVentaAbarrotesDet.unidad1 = documentoventaAbarrotesDetBE.unidad1
            docVentaAbarrotesDet.monto1 = documentoventaAbarrotesDetBE.monto1
            docVentaAbarrotesDet.unidad2 = documentoventaAbarrotesDetBE.unidad2
            docVentaAbarrotesDet.monto2 = documentoventaAbarrotesDetBE.monto2
            docVentaAbarrotesDet.precioUnitario = documentoventaAbarrotesDetBE.precioUnitario
            docVentaAbarrotesDet.precioUnitarioUS = documentoventaAbarrotesDetBE.precioUnitarioUS
            docVentaAbarrotesDet.importeMN = documentoventaAbarrotesDetBE.importeMN
            docVentaAbarrotesDet.importeME = documentoventaAbarrotesDetBE.importeME
            docVentaAbarrotesDet.importeMNK = documentoventaAbarrotesDetBE.importeMNK
            docVentaAbarrotesDet.importeMEK = documentoventaAbarrotesDetBE.importeMEK
            docVentaAbarrotesDet.descuentoMN = documentoventaAbarrotesDetBE.descuentoMN
            docVentaAbarrotesDet.descuentoME = documentoventaAbarrotesDetBE.descuentoME
            docVentaAbarrotesDet.montokardex = documentoventaAbarrotesDetBE.montokardex
            docVentaAbarrotesDet.montoIsc = documentoventaAbarrotesDetBE.montoIsc
            docVentaAbarrotesDet.montoIgv = documentoventaAbarrotesDetBE.montoIgv
            docVentaAbarrotesDet.otrosTributos = documentoventaAbarrotesDetBE.otrosTributos
            docVentaAbarrotesDet.montokardexUS = documentoventaAbarrotesDetBE.montokardexUS
            docVentaAbarrotesDet.montoIscUS = documentoventaAbarrotesDetBE.montoIscUS
            docVentaAbarrotesDet.montoIgvUS = documentoventaAbarrotesDetBE.montoIgvUS
            docVentaAbarrotesDet.otrosTributosUS = documentoventaAbarrotesDetBE.otrosTributosUS
            docVentaAbarrotesDet.salidaCostoMN = documentoventaAbarrotesDetBE.salidaCostoMN
            docVentaAbarrotesDet.salidaCostoME = documentoventaAbarrotesDetBE.salidaCostoME
            docVentaAbarrotesDet.preEvento = documentoventaAbarrotesDetBE.preEvento
            docVentaAbarrotesDet.estadoMovimiento = documentoventaAbarrotesDetBE.estadoMovimiento
            docVentaAbarrotesDet.tipoVenta = documentoventaAbarrotesDetBE.tipoVenta
            docVentaAbarrotesDet.estadoEntrega = documentoventaAbarrotesDetBE.estadoEntrega
            docVentaAbarrotesDet.idPadreDTVenta = documentoventaAbarrotesDetBE.idPadreDTVenta
            docVentaAbarrotesDet.estadoPago = documentoventaAbarrotesDetBE.estadoPago

            docVentaAbarrotesDet.categoria = documentoventaAbarrotesDetBE.categoria
            docVentaAbarrotesDet.estadoEntrega = documentoventaAbarrotesDetBE.estadoEntrega
            docVentaAbarrotesDet.usuarioModificacion = documentoventaAbarrotesDetBE.usuarioModificacion
            docVentaAbarrotesDet.idCajaUsuario = documentoventaAbarrotesDetBE.idCajaUsuario
            docVentaAbarrotesDet.fechaModificacion = documentoventaAbarrotesDetBE.fechaModificacion

            docVentaAbarrotesDet.beneficiobase = documentoventaAbarrotesDetBE.beneficiobase
            docVentaAbarrotesDet.tipobeneficio = documentoventaAbarrotesDetBE.tipobeneficio

            HeliosData.documentoventaAbarrotesDet.Add(docVentaAbarrotesDet)
            HeliosData.SaveChanges()
            ts.Complete()
            Return docVentaAbarrotesDet.secuencia
        End Using
    End Function



    Public Function GetListarAllVentasPorCajaAbierta(intIdPersona As Integer, fechaInicio As DateTime, fechaFin As DateTime) As List(Of documentoventaAbarrotesDet)
        Dim Lista As New List(Of documentoventaAbarrotesDet)
        Dim ListaTipo As New List(Of String)

        Dim objRecurso As New documentoventaAbarrotesDet
        '        Dim consulta = (From d In HeliosData.documentoventaAbarrotesDet Join
        '                        v In HeliosData.documentoventaAbarrotes
        '                        On d.idDocumento Equals v.idDocumento
        'Where
        '  d.usuarioModificacion = CStr(intIdPersona) And
        '  CStr(v.fechaDoc) >= fechaInicio And
        '  CStr(v.fechaDoc) <= fechaFin
        'Group d By
        '  d.tipoExistencia,
        '  d.importeMN
        ' Into g = Group
        'Select
        '  Column1 = CType(g.Sum(Function(p) p.importeMN), Decimal?),
        '  tipoExistencia).ToList



        Dim consulta = (From v In HeliosData.documentoventaAbarrotesDet
Where
  v.usuarioModificacion = CStr(intIdPersona) And
  CStr(v.documentoventaAbarrotes.fechaDoc) >= fechaInicio And
  CStr(v.documentoventaAbarrotes.fechaDoc) <= fechaFin
Group v By v.tipoExistencia Into g = Group
Select
  Column1 = CType(g.Sum(Function(p) p.importeMN), Decimal?),
  tipoExistencia).ToList

        For Each obj In consulta
            objRecurso = New documentoventaAbarrotesDet

            objRecurso.importeMN = obj.Column1
            objRecurso.tipoExistencia = obj.tipoExistencia

            Lista.Add(objRecurso)
        Next

        Return Lista
    End Function

    Public Function GetListarAllVentasPorUsuarioGeneral(intIdPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String) As List(Of documentoventaAbarrotesDet)
        Dim Lista As New List(Of documentoventaAbarrotesDet)
        Dim ListaTipo As New List(Of String)

        Dim objRecurso As New documentoventaAbarrotesDet

        Select Case tipo
            Case "XDia"
                Dim consulta = (From v In HeliosData.documentoventaAbarrotesDet
                                Where
                               (intIdPersona.Contains(v.usuarioModificacion)) And
                                CStr(v.documentoventaAbarrotes.fechaDoc) >= fechaInicio And
                                CStr(v.documentoventaAbarrotes.fechaDoc) <= fechaFin
                                Group v By v.tipoExistencia Into g = Group
                                Select
                                Column1 = CType(g.Sum(Function(p) p.importeMN), Decimal?),
                                tipoExistencia).ToList

                For Each obj In consulta
                    objRecurso = New documentoventaAbarrotesDet

                    objRecurso.importeMN = obj.Column1
                    objRecurso.tipoExistencia = obj.tipoExistencia

                    Lista.Add(objRecurso)
                Next

                Return Lista
            Case "XPeriodo"
                Dim consulta = (From v In HeliosData.documentoventaAbarrotesDet
                                Where
                                (intIdPersona.Contains(v.usuarioModificacion)) And
                                CStr(v.documentoventaAbarrotes.fechaPeriodo) = periodo
                                Group v By v.tipoExistencia Into g = Group
                                Select
                                Column1 = CType(g.Sum(Function(p) p.importeMN), Decimal?),
                                tipoExistencia).ToList

                For Each obj In consulta
                    objRecurso = New documentoventaAbarrotesDet

                    objRecurso.importeMN = obj.Column1
                    objRecurso.tipoExistencia = obj.tipoExistencia

                    Lista.Add(objRecurso)
                Next
            Case "XTodo"
                Dim consulta = (From v In HeliosData.documentoventaAbarrotesDet
                                Where
                                (intIdPersona.Contains(v.usuarioModificacion))
                                Group v By v.tipoExistencia Into g = Group
                                Select
                                Column1 = CType(g.Sum(Function(p) p.importeMN), Decimal?),
                                tipoExistencia).ToList

                For Each obj In consulta
                    objRecurso = New documentoventaAbarrotesDet

                    objRecurso.importeMN = obj.Column1
                    objRecurso.tipoExistencia = obj.tipoExistencia

                    Lista.Add(objRecurso)
                Next
        End Select

        Return Lista
    End Function

    Public Function GetListarAllVentasDetallado(idDocumento As Integer, tipoexistencia As String) As List(Of documentoventaAbarrotesDet)
        Dim Lista As New List(Of documentoventaAbarrotesDet)
        Dim ListaTipo As New List(Of String)

        Dim docVentaAbarrotesDet As New documentoventaAbarrotesDet

        Dim consulta = (From v In HeliosData.documentoventaAbarrotesDet
                        Where
                            v.tipoExistencia = tipoexistencia).ToList

        For Each documentoventaAbarrotesDetBE In consulta
            docVentaAbarrotesDet = New documentoventaAbarrotesDet

            docVentaAbarrotesDet.idDocumento = documentoventaAbarrotesDetBE.idDocumento
            docVentaAbarrotesDet.idAlmacenOrigen = documentoventaAbarrotesDetBE.idAlmacenOrigen
            docVentaAbarrotesDet.establecimientoOrigen = documentoventaAbarrotesDetBE.establecimientoOrigen
            docVentaAbarrotesDet.cuentaOrigen = documentoventaAbarrotesDetBE.cuentaOrigen
            docVentaAbarrotesDet.idItem = documentoventaAbarrotesDetBE.idItem
            docVentaAbarrotesDet.nombreItem = documentoventaAbarrotesDetBE.nombreItem
            docVentaAbarrotesDet.fechaVcto = documentoventaAbarrotesDetBE.fechaVcto
            docVentaAbarrotesDet.tipoExistencia = documentoventaAbarrotesDetBE.tipoExistencia
            docVentaAbarrotesDet.destino = documentoventaAbarrotesDetBE.destino
            docVentaAbarrotesDet.unidad1 = documentoventaAbarrotesDetBE.unidad1
            docVentaAbarrotesDet.monto1 = documentoventaAbarrotesDetBE.monto1
            docVentaAbarrotesDet.unidad2 = documentoventaAbarrotesDetBE.unidad2
            docVentaAbarrotesDet.monto2 = documentoventaAbarrotesDetBE.monto2
            docVentaAbarrotesDet.precioUnitario = documentoventaAbarrotesDetBE.precioUnitario
            docVentaAbarrotesDet.precioUnitarioUS = documentoventaAbarrotesDetBE.precioUnitarioUS
            docVentaAbarrotesDet.importeMN = documentoventaAbarrotesDetBE.importeMN
            docVentaAbarrotesDet.importeME = documentoventaAbarrotesDetBE.importeME
            docVentaAbarrotesDet.importeMNK = documentoventaAbarrotesDetBE.importeMNK
            docVentaAbarrotesDet.importeMEK = documentoventaAbarrotesDetBE.importeMEK
            docVentaAbarrotesDet.descuentoMN = documentoventaAbarrotesDetBE.descuentoMN
            docVentaAbarrotesDet.descuentoME = documentoventaAbarrotesDetBE.descuentoME
            docVentaAbarrotesDet.montokardex = documentoventaAbarrotesDetBE.montokardex
            docVentaAbarrotesDet.montoIsc = documentoventaAbarrotesDetBE.montoIsc
            docVentaAbarrotesDet.montoIgv = documentoventaAbarrotesDetBE.montoIgv
            docVentaAbarrotesDet.otrosTributos = documentoventaAbarrotesDetBE.otrosTributos
            docVentaAbarrotesDet.montokardexUS = documentoventaAbarrotesDetBE.montokardexUS
            docVentaAbarrotesDet.montoIscUS = documentoventaAbarrotesDetBE.montoIscUS
            docVentaAbarrotesDet.montoIgvUS = documentoventaAbarrotesDetBE.montoIgvUS
            docVentaAbarrotesDet.otrosTributosUS = documentoventaAbarrotesDetBE.otrosTributosUS
            docVentaAbarrotesDet.salidaCostoMN = documentoventaAbarrotesDetBE.salidaCostoMN
            docVentaAbarrotesDet.salidaCostoME = documentoventaAbarrotesDetBE.salidaCostoME
            docVentaAbarrotesDet.preEvento = documentoventaAbarrotesDetBE.preEvento
            docVentaAbarrotesDet.estadoMovimiento = documentoventaAbarrotesDetBE.estadoMovimiento
            docVentaAbarrotesDet.tipoVenta = documentoventaAbarrotesDetBE.tipoVenta
            docVentaAbarrotesDet.estadoEntrega = documentoventaAbarrotesDetBE.estadoEntrega
            docVentaAbarrotesDet.idPadreDTVenta = documentoventaAbarrotesDetBE.idPadreDTVenta
            docVentaAbarrotesDet.estadoPago = documentoventaAbarrotesDetBE.estadoPago
            docVentaAbarrotesDet.categoria = documentoventaAbarrotesDetBE.categoria
            docVentaAbarrotesDet.estadoEntrega = documentoventaAbarrotesDetBE.estadoEntrega
            docVentaAbarrotesDet.usuarioModificacion = documentoventaAbarrotesDetBE.usuarioModificacion
            docVentaAbarrotesDet.fechaModificacion = documentoventaAbarrotesDetBE.fechaModificacion

            Lista.Add(docVentaAbarrotesDet)
        Next

        Return Lista
    End Function

#Region "Restaurant"
    Public Sub DeletePedidoRestaurant(ByVal documentoventaAbarrotesDetBE As documentoventaAbarrotes)
        Try
            Dim distriBL As New distribucionInfraestructuraBL
            Dim distriBE As New distribucionInfraestructura

            Using ts As New TransactionScope

                For Each item In documentoventaAbarrotesDetBE.ListaIdDocumento
                    Dim documento = (From i In HeliosData.documento
                                     Where i.idDocumento = item).FirstOrDefault

                    If (Not IsNothing(documento)) Then
                        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documento)

                        HeliosData.SaveChanges()
                    End If
                Next

                distriBE.idDistribucion = documentoventaAbarrotesDetBE.idCliente
                distriBE.idEmpresa = documentoventaAbarrotesDetBE.idEmpresa
                distriBE.estado = documentoventaAbarrotesDetBE.estado

                distriBL.updateDistribucionxID(distriBE)

                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub DeleteItemVentaRestaurant(ByVal documentoventaAbarrotesDetBE As documentoventaAbarrotesDet)
        Try
            Dim distriBL As New distribucionInfraestructuraBL
            Dim distriBE As New distribucionInfraestructura

            Using ts As New TransactionScope
                EliminarItem(documentoventaAbarrotesDetBE)

                Dim docDetalle = (From n In HeliosData.documentoventaAbarrotesDet
                                  Where n.idDistribucion = documentoventaAbarrotesDetBE.idDistribucion).ToList


                If Not IsNothing(docDetalle) Then

                    If (docDetalle.Count > 0) Then
                        Dim documento = (From i In HeliosData.documentoventaAbarrotes
                                         Where i.idDocumento = documentoventaAbarrotesDetBE.idDocumento).FirstOrDefault

                        Dim SumatoriaDoc = (From n In HeliosData.documentoventaAbarrotesDet
                                            Where n.idDocumento = documentoventaAbarrotesDetBE.idDocumento).ToList


                        documento.bi01 = SumatoriaDoc.Sum(Function(o) o.montokardex)
                        documento.bi01us = SumatoriaDoc.Sum(Function(o) o.montokardexUS)

                        documento.igv01 = SumatoriaDoc.Sum(Function(o) o.montoIgv)
                        documento.igv01us = SumatoriaDoc.Sum(Function(o) o.montoIgvUS)

                        documento.importeCostoMN = SumatoriaDoc.Sum(Function(o) o.salidaCostoMN)
                        documento.importeCostoME = SumatoriaDoc.Sum(Function(o) o.salidaCostoME)

                        documento.ImporteNacional = SumatoriaDoc.Sum(Function(o) o.importeMN)
                        documento.ImporteExtranjero = SumatoriaDoc.Sum(Function(o) o.importeME)

                        HeliosData.SaveChanges()
                    Else
                        Dim documento = (From i In HeliosData.documento
                                         Where i.idDocumento = documentoventaAbarrotesDetBE.idDocumento).FirstOrDefault

                        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documento)

                        distriBE.idDistribucion = documentoventaAbarrotesDetBE.idDistribucion
                        distriBE.idEmpresa = documentoventaAbarrotesDetBE.IdEmpresa
                        distriBE.estado = documentoventaAbarrotesDetBE.estadoDistribucion

                        distriBL.updateDistribucionxID(distriBE)

                        HeliosData.SaveChanges()
                    End If

                End If

                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function GetUbicar_documentoventaAbarrotesXListaIdDocumento(docVentaAbarrotesBE As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet)
        Try

            Dim listaDocumentoVentaAbarrotes As New List(Of documentoventaAbarrotesDet)
            Dim OBJD As New documentoventaAbarrotesDet

            Dim consulta = (From det In HeliosData.documentoventaAbarrotesDet
                            Where
                        docVentaAbarrotesBE.ListaEstado.Contains(det.idDistribucion) And
                        docVentaAbarrotesBE.ListaIdDocumento.Contains(det.idDocumento) And
                        det.estadoDistribucion = "A"
                            Select
                        det.idDocumento,
                        det.secuencia,
                        det.cuentaOrigen,
                        det.idItem,
                        det.nombreItem,
                        det.tipoExistencia,
                        det.destino,
                        det.equivalencia_id,
                        det.catalogo_id,
                        det.unidad2,
                        det.unidad1,
                        det.monto1,
                        det.precioUnitario,
                        det.precioUnitarioUS,
                        det.importeMN,
                        det.importeME,
                        det.descuentoMN,
                        det.descuentoME,
                        det.montoIgv,
                        det.montoIgvUS).ToList

            For Each documentoventaAbarrotesDetBE In consulta
                OBJD = New documentoventaAbarrotesDet
                OBJD.idDocumento = documentoventaAbarrotesDetBE.idDocumento
                OBJD.cuentaOrigen = documentoventaAbarrotesDetBE.cuentaOrigen
                OBJD.idItem = documentoventaAbarrotesDetBE.idItem
                OBJD.tipoExistencia = documentoventaAbarrotesDetBE.tipoExistencia
                OBJD.destino = documentoventaAbarrotesDetBE.destino
                OBJD.unidad1 = documentoventaAbarrotesDetBE.unidad1
                OBJD.monto1 = documentoventaAbarrotesDetBE.monto1
                OBJD.unidad2 = documentoventaAbarrotesDetBE.unidad2
                OBJD.nombreItem = documentoventaAbarrotesDetBE.nombreItem
                OBJD.precioUnitario = documentoventaAbarrotesDetBE.precioUnitario
                OBJD.precioUnitarioUS = documentoventaAbarrotesDetBE.precioUnitarioUS
                OBJD.importeMN = documentoventaAbarrotesDetBE.importeMN
                OBJD.importeME = documentoventaAbarrotesDetBE.importeME
                OBJD.descuentoMN = documentoventaAbarrotesDetBE.descuentoMN
                OBJD.descuentoME = documentoventaAbarrotesDetBE.descuentoME
                OBJD.montoIgv = documentoventaAbarrotesDetBE.montoIgv
                OBJD.montoIgvUS = documentoventaAbarrotesDetBE.montoIgvUS

                listaDocumentoVentaAbarrotes.Add(OBJD)
            Next
            Return listaDocumentoVentaAbarrotes
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetUbicar_ListaDocumento(docVentaAbarrotesBE As documentoventaAbarrotesDet) As documento
        Try

            Dim listaDocumentoVentaAbarrotes As New List(Of documentoventaAbarrotesDet)
            Dim OBJD As New documento

            Dim consulta = (From DET In HeliosData.documentoventaAbarrotesDet
                            Where
                                CLng(DET.idDistribucion) = docVentaAbarrotesBE.idDistribucion And
                                DET.estadoDistribucion = docVentaAbarrotesBE.estadoDistribucion
                            Group DET By DET.idDocumento Into g = Group
                            Select New With {
                                idDocumento}).ToList

            OBJD = New documento
            OBJD.ListaDocumentoID = New List(Of Integer)
            For Each documentoventaAbarrotesDetBE In consulta
                OBJD.ListaDocumentoID.Add(documentoventaAbarrotesDetBE.idDocumento)
            Next
            Return OBJD
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub updateMesa(ByVal InfraBE As distribucionInfraestructura)
        Try
            Dim distriBL As New distribucionInfraestructuraBL
            Dim distriBE As New distribucionInfraestructura

            Using ts As New TransactionScope

                Dim RecuperarDoc = (From i In HeliosData.documentoventaAbarrotesDet
                                    Where i.idDistribucion = InfraBE.idInfraestructura And
                                        i.estadoDistribucion = InfraBE.estado).ToList

                If (RecuperarDoc.Count > 0) Then
                    For Each item In RecuperarDoc
                        item.idDistribucion = InfraBE.InfraestructuraUpdate
                        HeliosData.SaveChanges()
                    Next
                End If

                distriBE = New distribucionInfraestructura
                distriBE.idEmpresa = InfraBE.idEmpresa
                distriBE.idDistribucion = InfraBE.idInfraestructura
                distriBE.estado = InfraBE.estado

                distriBL.updateDistribucionxID(distriBE)

                distriBE = New distribucionInfraestructura
                distriBE.idEmpresa = InfraBE.idEmpresa
                distriBE.idDistribucion = InfraBE.InfraestructuraUpdate
                distriBE.estado = InfraBE.Categoria

                distriBL.updateDistribucionxID(distriBE)

                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

End Class
