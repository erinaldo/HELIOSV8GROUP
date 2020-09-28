Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class recursoCostoDetalleBL
    Inherits BaseBL


    Public Sub GrabarDetalleCosteoReal(be As List(Of recursoCostoDetalle), idEntregable As Integer, idDocumento As Integer, idSecuencia As UInteger)
        Dim obj As New recursoCostoDetalle
        Dim asientoBL As New AsientoBL
        Try
            Using ts As New TransactionScope

                Dim objetoValidar As recursoCosto = HeliosData.recursoCosto.Where(Function(o) o.idCosto = idEntregable).FirstOrDefault

                For Each i In be

                    Me.GrabarDetalleCR(i)

                Next

                CambioEstadoProductosTerminado(idDocumento, idSecuencia)


                'asientoBL.SavebyGroup(listaAsiento)

                'HeliosData.SaveChanges()
                If Not IsNothing(obj) Then
                    objetoValidar.estado = "EJE"
                End If

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CambioEstadoProductosTerminado(idDocumento As Integer, idSecuencia As Integer)
        Using ts As New TransactionScope
            Dim obj As documentocompradetalle = HeliosData.documentocompradetalle.Where(Function(o) o.idDocumento = idDocumento And o.secuencia = idSecuencia).FirstOrDefault

            If Not IsNothing(obj) Then
                obj.tipoCosto = "PEC"
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetListadoRecursosPorEntregableCosteado(idEntregable As Integer, fechaPeriodo As DateTime) As List(Of recursoCostoDetalle)
        ' Return HeliosData.GetRecursosByEntregable(idEntregable, fechaPeriodo).ToList
        Dim lista As New List(Of recursoCostoDetalle)
        Dim objeto As New recursoCostoDetalle


        Dim consulta = (From det In HeliosData.recursoCostoDetalle
                        Join Proceso In HeliosData.recursoCosto On CInt(det.idProceso) Equals Proceso.idCosto
                        Join ProductoTerminado In HeliosData.recursoCosto On CInt(Proceso.idpadre) Equals ProductoTerminado.idCosto
                        Where
          det.idCosto = idEntregable And
          det.fechaTrabajo.Value.Year = fechaPeriodo.Year And
          det.fechaTrabajo.Value.Month = fechaPeriodo.Month And det.tipoCosto = "RC"
                        Select
          det.secuencia,
          ElmentoCosto = det.recursoCosto.nombreCosto,
          ProdTerminado = ProductoTerminado.nombreCosto,
          Proceso = Proceso.nombreCosto,
          det.fechaRegistro,
          det.iditem,
          det.destino,
          det.descripcion,
          det.um,
          det.cant,
          det.montoMN,
          det.montoME,
          det.documentoRef,
          det.operacion,
          det.fechaTrabajo,
          det.motivoCosto,
          det.elementoCosto,
          det.Periodo).ToList

        For Each i In consulta
            objeto = New recursoCostoDetalle
            objeto.secuencia = i.secuencia
            objeto.fechaRegistro = i.fechaRegistro
            objeto.iditem = i.iditem
            objeto.destino = i.destino
            objeto.descripcion = i.descripcion
            objeto.um = i.um
            objeto.cant = i.cant

            objeto.montoMN = i.montoMN
            objeto.montoME = i.montoME
            objeto.documentoRef = i.documentoRef
            objeto.operacion = i.operacion
            objeto.fechaTrabajo = i.fechaTrabajo
            objeto.Periodo = i.Periodo
            objeto.motivoCosto = i.motivoCosto
            objeto.elementoCosto = i.elementoCosto
            lista.Add(objeto)
        Next

        Return lista
    End Function

    Public Sub GrabarRecursoSalidaProd(be As documentocompradetalle, idDocSalida As Integer, sec As Integer, per As String)
        Dim obj As New recursoCostoDetalle
        Dim asientoBL As New AsientoBL
        Using ts As New TransactionScope

            'Dim compraDet = (From n In HeliosData.documentocompradetalle
            '                 Where n.secuencia = sec).FirstOrDefault

            'compraDet.idCosto = be.idCosto
            'compraDet.tipoCosto = be.tipoCosto

            obj = New recursoCostoDetalle With
                      {
                .idCosto = be.idCosto,
                .fechaRegistro = be.FechaDoc,
                .iditem = be.idItem,
                .destino = be.destino,
                .descripcion = be.descripcionItem,
                .um = be.unidad1,
                .cant = be.monto1,
                .puMN = 0,
                .puME = 0,
                .montoMN = be.importe,
                .montoME = be.importeUS,
                .documentoRef = idDocSalida,
                .itemRef = sec,
                .operacion = be.TipoOperacion,
                .procesado = "N",
                .idProceso = be.idProceso,
                .tipoCosto = "RL",
                .fechaTrabajo = be.FechaDoc,
                .idDocSalida = idDocSalida,
                .elementoCosto = "MPD",
                .motivoCosto = be.motivoCosto,
                .Periodo = per
                    }
            HeliosData.recursoCostoDetalle.Add(obj)


            '.idDocSalida = idDocSalida,

            'asientoBL.SavebyGroup(listaAsiento)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub


    Public Sub GrabarRecursoProduccion(be As List(Of recursoCostoDetalle))
        Dim obj As New recursoCostoDetalle
        Dim asientoBL As New AsientoBL
        Try

            For Each i In be

                Me.GrabarDetalleCR(i)

            Next



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GrabarDetalleCR(be As recursoCostoDetalle)
        Dim obj As New recursoCostoDetalle
        Dim asientoBL As New AsientoBL
        Using ts As New TransactionScope

            obj = New recursoCostoDetalle With
                      {
                .idCosto = be.idCosto,
            .idRecursoAfectado = be.secuencia,
            .fechaRegistro = be.fechaRegistro,
            .iditem = be.iditem,
            .destino = be.destino,
            .descripcion = be.descripcion,
            .um = be.um,
            .cant = be.cant,
            .puMN = be.puMN,
            .puME = be.puME,
            .montoMN = be.montoMN,
            .montoME = be.montoME,
            .operacion = be.operacion,
            .procesado = be.procesado,
            .tipoCosto = be.tipoCosto,
            .idProceso = be.idProceso,
            .fechaTrabajo = be.fechaTrabajo,
            .Periodo = be.Periodo,
            .motivoCosto = be.motivoCosto,
                .elementoCosto = be.elementoCosto
                    }
            HeliosData.recursoCostoDetalle.Add(obj)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Function GetListadoRecursosPorEntregable(idEntregable As Integer, fechaPeriodo As DateTime) As List(Of recursoCostoDetalle)
        ' Return HeliosData.GetRecursosByEntregable(idEntregable, fechaPeriodo).ToList
        Dim lista As New List(Of recursoCostoDetalle)
        Dim objeto As New recursoCostoDetalle

        Dim list As New List(Of String)
        list.Add("RL")
        list.Add("RP")


        Dim consulta = (From det In HeliosData.recursoCostoDetalle
                        Join Proceso In HeliosData.recursoCosto On CInt(det.idProceso) Equals Proceso.idCosto
                        Join ProductoTerminado In HeliosData.recursoCosto On CInt(Proceso.idpadre) Equals ProductoTerminado.idCosto
                        Where
          det.idCosto = idEntregable And
          det.fechaTrabajo.Value.Year = fechaPeriodo.Year And
          det.fechaTrabajo.Value.Month = fechaPeriodo.Month And list.Contains(det.tipoCosto)
                        Select
          det.secuencia,
          ElmentoCosto = det.recursoCosto.nombreCosto,
          ProdTerminado = ProductoTerminado.nombreCosto,
          Proceso = Proceso.nombreCosto,
          det.fechaRegistro,
          det.iditem,
          det.destino,
          det.descripcion,
          det.um,
          det.cant,
          det.montoMN,
          det.montoME,
          det.documentoRef,
          det.operacion,
          det.fechaTrabajo,
          det.Periodo,
          det.elementoCosto,
          montoCosto = (CType((Aggregate t1 In
                                    (From rec In HeliosData.recursoCostoDetalle
                                     Where
                                     rec.idRecursoAfectado = det.secuencia And Not rec.tipoCosto = "RP"
                                     Select New With {
                                         rec.montoMN
                                     }) Into Sum(t1.montoMN)), Decimal?)),
                  cantidadCosto = (CType((Aggregate t1 In
                                    (From rec In HeliosData.recursoCostoDetalle
                                     Where
                                     rec.idRecursoAfectado = det.secuencia And Not rec.tipoCosto = "RP"
                                     Select New With {
                                         rec.cant
                                     }) Into Sum(t1.cant)), Decimal?))).ToList

        For Each i In consulta
            objeto = New recursoCostoDetalle
            objeto.secuencia = i.secuencia
            objeto.fechaRegistro = i.fechaRegistro
            objeto.iditem = i.iditem
            objeto.destino = i.destino
            objeto.descripcion = i.descripcion
            objeto.um = i.um
            objeto.cant = i.cant

            objeto.montoMN = i.montoMN
            objeto.montoME = i.montoME
            objeto.documentoRef = i.documentoRef
            objeto.operacion = i.operacion
            objeto.fechaTrabajo = i.fechaTrabajo
            objeto.Periodo = i.Periodo
            objeto.montoCosto = i.montoCosto.GetValueOrDefault
            objeto.cantidadCosto = i.cantidadCosto.GetValueOrDefault
            objeto.elementoCosto = i.elementoCosto
            lista.Add(objeto)
        Next

        Return lista
    End Function

    Public Sub GrabarDetalleRecursosLibro(be As List(Of recursoCostoDetalle), listaAsiento As List(Of asiento))
        Dim obj As New recursoCostoDetalle
        Dim asientoBL As New AsientoBL
        Using ts As New TransactionScope
            For Each i In be
                Dim compraDet = (From n In HeliosData.documentoLibroDiarioDetalle
                                 Where n.secuencia = i.itemRef).FirstOrDefault

                compraDet.idCosto = i.idCosto
                compraDet.tipoCosto = i.tipoCosto

                'Select Case i.recursoCosto.subtipo
                '    Case TipoCosto.CONTRATOS_DE_CONSTRUCCION
                '        compraDet.tipoCosto = TipoCosto.CONTRATOS_DE_CONSTRUCCION

                '    Case TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS
                '        compraDet.tipoCosto = TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS

                '    Case TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES
                '        compraDet.tipoCosto = TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES


                '    Case (TipoCosto.OP_CONTINUA_DE_BIENES)
                '        compraDet.tipoCosto = TipoCosto.OP_CONTINUA_DE_BIENES

                '    Case (TipoCosto.OP_CONTINUA_DE_SERVICIOS)
                '        compraDet.tipoCosto = TipoCosto.OP_CONTINUA_DE_SERVICIOS

                '    Case (TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE)
                '        compraDet.tipoCosto = TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE

                '    Case (TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES)
                '        compraDet.tipoCosto = TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES

                '    Case (TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE)
                '        compraDet.tipoCosto = TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE

                '    Case "ACTIVO FIJO", TipoCosto.ActivoFijo
                '        compraDet.tipoCosto = TipoCosto.ActivoFijo
                '    Case "GASTO ADMINISTRATIVO", TipoCosto.GastoAdministrativo
                '        compraDet.tipoCosto = TipoCosto.GastoAdministrativo
                '    Case "GASTO DE VENTAS", TipoCosto.GastoVentas
                '        compraDet.tipoCosto = TipoCosto.GastoVentas
                '    Case "GASTO FINANCIERO", TipoCosto.GastoFinanciero
                '        compraDet.tipoCosto = TipoCosto.GastoFinanciero
                'End Select


                obj = New recursoCostoDetalle With
                      {
                .idCosto = i.idCosto,
                .fechaRegistro = i.fechaRegistro,
                .iditem = i.iditem,
                .descripcion = i.descripcion,
                .montoMN = i.montoMN,
                .montoME = i.montoME,
                .documentoRef = i.documentoRef,
                .itemRef = i.itemRef,
                .cant = i.cant,
                .operacion = i.operacion,
                .procesado = i.procesado,
                .idProceso = i.idProceso,
                .tipoCosto = "RL",
                .elementoCosto = i.elementoCosto,
                .fechaTrabajo = i.fechaTrabajo,
                .Periodo = i.Periodo
                    }
                HeliosData.recursoCostoDetalle.Add(obj)
            Next
            asientoBL.SavebyGroup(listaAsiento)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Function GetRecursoPlaneadoConteo(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim obj As New recursoCostoDetalle
        Dim Lista As New List(Of recursoCostoDetalle)


        Select Case be.procesado
            Case "PL"
                Dim con = (From det In HeliosData.recursoCostoDetalle _
                 Join proceso In HeliosData.recursoCosto On New With {.IdCosto = CInt(det.recursoCosto.idpadre)} Equals New With {.IdCosto = proceso.idCosto}
                 Where _
                 CStr(det.tipoCosto) = be.procesado And _
                 CLng(proceso.idpadre) = be.idCosto _
                 Group det By det.iditem Into g = Group _
                 Select _
                 iditem, _
                 total = CType(g.Count(Function(p) p.secuencia <> Nothing), Int64?)).ToList


                For Each i In con
                    obj = New recursoCostoDetalle
                    obj.iditem = i.iditem
                    Select Case i.iditem
                        Case TipoRecursoPlaneado.Inventario
                            obj.descripcion = "INVENTARIO"
                        Case TipoRecursoPlaneado.ManoDeObra
                            obj.descripcion = "MANO DE OBRA"
                        Case TipoRecursoPlaneado.ActivoInmovilizado
                            obj.descripcion = "ACTIVOS INMOVILIZADOS"
                        Case TipoRecursoPlaneado.Terceros
                            obj.descripcion = "TERCEROS"
                    End Select
                    obj.cant = i.total
                    Lista.Add(obj)
                Next

            Case "RQ"
                Dim con = (From det In HeliosData.recursoCostoDetalle _
                 Where _
                 CStr(det.tipoCosto) = be.procesado And _
                 CLng(det.idCosto) = be.idCosto _
                 Group det By det.iditem Into g = Group _
                 Select _
                 iditem, _
                 total = CType(g.Count(Function(p) p.secuencia <> Nothing), Int64?)).ToList


                For Each i In con
                    obj = New recursoCostoDetalle
                    obj.iditem = i.iditem
                    Select Case i.iditem
                        Case TipoRecursoPlaneado.Inventario
                            obj.descripcion = "INVENTARIO"
                        Case TipoRecursoPlaneado.ManoDeObra
                            obj.descripcion = "MANO DE OBRA"
                        Case TipoRecursoPlaneado.ActivoInmovilizado
                            obj.descripcion = "ACTIVOS INMOVILIZADOS"
                        Case TipoRecursoPlaneado.Terceros
                            obj.descripcion = "TERCEROS"
                    End Select
                    obj.cant = i.total
                    Lista.Add(obj)
                Next

        End Select


        Return Lista
    End Function

    Public Function GetRecursoPlaneadosPendientesAprobacion(be As recursoCostoDetalle) As List(Of recursoCostoDetalle)
        Dim obj As New recursoCostoDetalle
        Dim Lista As New List(Of recursoCostoDetalle)

        Select Case be.idCosto
            Case 0
                'Dim con = (From det In HeliosData.recursoCostoDetalle _
                '        Join proy In HeliosData.recursoCosto _
                '        On proy.idCosto Equals det.idCosto _
                '        Where _
                '        CStr(det.tipoCosto) = be.tipoCosto And _
                '        det.procesado = be.procesado).ToList

                Dim consulta = (From det In HeliosData.recursoCostoDetalle _
                               Group Join cst In HeliosData.recursoCosto_compraDetalle On New With {.Secuenciacosto = det.secuencia} Equals New With {.Secuenciacosto = cst.secuenciacosto} Into cst_join = Group _
                               From cst In cst_join.DefaultIfEmpty() _
                               Where _
                               det.tipoCosto = be.tipoCosto And _
                               det.procesado = be.procesado _
                               Group New With {det, det.recursoCosto, cst} By _
                               det.secuencia, _
                               IdCosto = CType(det.recursoCosto.idCosto, Int32?), _
                               det.recursoCosto.nombreCosto, _
                               det.descripcion, _
                               det.um, _
                               det.iditem, _
                               det.cant, _
                               det.tipoCosto, _
                               det.idProceso, _
                               det.fechaRegistro _
                               Into g = Group _
                               Select _
                               idProceso, _
                               Secuencia = CType(secuencia, Int32?), _
                               IdCosto = CType(IdCosto, Int32?), _
                               nombreCosto, _
                               descripcion, _
                               um, _
                               iditem, _
                               planeado = cant, _
                               tipoCosto, _
                               fechaRegistro, _
                               ejecutado = CType(g.Sum(Function(p) p.cst.cantidad), Decimal?)).ToList


                For Each i In consulta
                    obj = New recursoCostoDetalle
                    obj.secuencia = i.Secuencia
                    obj.IdProyecto = i.IdCosto
                    obj.NombreCosto = i.nombreCosto
                    obj.um = i.um
                    obj.tipoCosto = i.tipoCosto
                    obj.idProceso = i.idProceso
                    obj.iditem = i.iditem
                    obj.descripcion = i.descripcion
                    obj.cant = i.planeado
                    obj.CantEjecutada = i.ejecutado.GetValueOrDefault
                    obj.fechaRegistro = i.fechaRegistro.GetValueOrDefault
                    Lista.Add(obj)
                Next

            Case Else
                'Dim con = (From det In HeliosData.recursoCostoDetalle _
                '           Join proy In HeliosData.recursoCosto _
                '           On proy.idCosto Equals det.idCosto _
                '           Where _
                '           CStr(det.tipoCosto) = be.tipoCosto And _
                '           CLng(det.idCosto) = be.idCosto And _
                '           det.procesado = be.procesado).ToList

                Dim consulta = (From det In HeliosData.recursoCostoDetalle _
                               Group Join cst In HeliosData.recursoCosto_compraDetalle On New With {.Secuenciacosto = det.secuencia} Equals New With {.Secuenciacosto = cst.secuenciacosto} Into cst_join = Group _
                               From cst In cst_join.DefaultIfEmpty() _
                               Where _
                               det.tipoCosto = be.tipoCosto And _
                               CLng(det.recursoCosto.idCosto) = be.idCosto And _
                               det.procesado = be.procesado _
                               Group New With {det, det.recursoCosto, cst} By _
                               det.secuencia, _
                               IdCosto = CType(det.recursoCosto.idCosto, Int32?), _
                               det.recursoCosto.nombreCosto, _
                               det.descripcion, _
                               det.um, _
                               det.iditem, _
                               det.cant, _
                               det.tipoCosto, _
                               det.idProceso, _
                               det.fechaRegistro _
                               Into g = Group _
                               Select _
                               idProceso, _
                               Secuencia = CType(secuencia, Int32?), _
                               IdCosto = CType(IdCosto, Int32?), _
                               nombreCosto, _
                               descripcion, _
                               um, _
                               iditem, _
                               planeado = cant, _
                               tipoCosto, _
                               fechaRegistro, _
                               ejecutado = CType(g.Sum(Function(p) p.cst.cantidad), Decimal?)).ToList




                For Each i In consulta
                    obj = New recursoCostoDetalle
                    obj.secuencia = i.Secuencia
                    obj.IdProyecto = i.IdCosto
                    obj.NombreCosto = i.nombreCosto
                    obj.um = i.um
                    obj.tipoCosto = i.tipoCosto
                    obj.idProceso = i.idProceso
                    obj.iditem = i.iditem
                    obj.descripcion = i.descripcion
                    obj.cant = i.planeado
                    obj.CantEjecutada = i.ejecutado.GetValueOrDefault
                    obj.fechaRegistro = i.fechaRegistro.GetValueOrDefault
                    Lista.Add(obj)
                Next
        End Select



        Return Lista
    End Function

    Public Sub EliminarProcesos(i As recursoCosto)

        Dim obj As recursoCosto = HeliosData.recursoCosto.Where(Function(o) o.idCosto = i.idCosto).FirstOrDefault
        Dim conDetalleACT As Integer = HeliosData.recursoCosto.Where(Function(o) o.idpadre = i.idCosto).Count
        Try
            Using ts As New TransactionScope
                If Not IsNothing(obj) Then
                    If conDetalleACT > 0 Then
                        Throw New Exception("No puede eliminar el proceso, posee actividades asignadas")
                    Else
                        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(obj)
                    End If
                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarCostoDetalleBySec(i As recursoCostoDetalle)

        Dim obj As recursoCosto = HeliosData.recursoCosto.Where(Function(o) o.idCosto = i.idCosto).FirstOrDefault
        Dim conDetalle As Integer = HeliosData.recursoCostoDetalle.Where(Function(o) o.idCosto = i.idCosto).Count
        Try
            Using ts As New TransactionScope
                If Not IsNothing(obj) Then
                    If conDetalle > 0 Then
                        Throw New Exception("No puede eliminar la actividad, posee recursos asignados")
                    Else
                        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(obj)
                    End If
                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetReporteElmentoCostoAnual(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim obj As New recursoCostoDetalle
        Dim lista As New List(Of recursoCostoDetalle)

        Dim con = (From det In HeliosData.recursoCostoDetalle _
                   Where CLng(det.recursoCosto.idpadre) = be.idCosto And _
                   (det.fechaRegistro.Value.Year) = be.Anio _
                   Group New With {det.recursoCosto, det} By _
                   det.recursoCosto.nombreCosto, _
                   MesLab = det.fechaRegistro.Value.Month _
                   Into g = Group _
                   Select _
                   mesLaborado = MesLab, _
                   nombreCosto, _
                   total = CType(g.Sum(Function(p) p.det.montoMN), Decimal?)).ToList


        For Each i In con
            obj = New recursoCostoDetalle
            obj.MesTrabajado = i.mesLaborado
            obj.NombreCosto = i.nombreCosto
            obj.montoMN = i.total
            lista.Add(obj)
        Next
        Return lista

    End Function

    Public Function GetReporteElmentoCostoByProceso(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim obj As New recursoCostoDetalle
        Dim lista As New List(Of recursoCostoDetalle)


        Dim con = (From det In HeliosData.recursoCostoDetalle _
                  Join proceso In HeliosData.recursoCosto On New With {.IdCosto = CInt(det.idProceso)} Equals New With {.IdCosto = proceso.idCosto} _
                  Where CLng(det.recursoCosto.idpadre) = be.idCosto _
                  Group New With {det.recursoCosto, det, proceso} By _
                  det.recursoCosto.nombreCosto, _
                  det.idProceso, _
                  NomProceso = proceso.nombreCosto _
                  Into g = Group _
                  Select
                  nombreCosto,
                  NomProceso,
                  idProceso,
                  total = CType(g.Sum(Function(p) p.det.montoMN), Decimal?)).ToList


        For Each i In con
            obj = New recursoCostoDetalle
            obj.NombreProceso = i.NomProceso
            obj.NombreCosto = i.nombreCosto
            obj.montoMN = i.total
            lista.Add(obj)
        Next
        Return lista

    End Function

    Public Function GetSumaTotalElementoCosto(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim obj As New recursoCostoDetalle
        Dim lista As New List(Of recursoCostoDetalle)
        Dim consulta = (From det In HeliosData.recursoCostoDetalle _
                       Where _
                       CLng(det.recursoCosto.idpadre) = be.idCosto _
                       Group New With {det.recursoCosto, det} By det.recursoCosto.codigo, det.recursoCosto.nombreCosto Into g = Group _
                       Select _
                       nombreCosto, codigo, _
                       MN = CType(g.Sum(Function(p) p.det.montoMN), Decimal?), _
                       MEX = CType(g.Sum(Function(p) p.det.montoME), Decimal?)).ToList


        For Each i In consulta
            obj = New recursoCostoDetalle
            obj.descripcion = i.nombreCosto
            obj.operacion = i.codigo
            obj.montoMN = i.MN
            obj.montoME = i.MEX
            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Function GetSumaTotalImportesByCosto(be As recursoCosto) As recursoCosto
        Dim obj As New recursoCosto

        Dim consulta = Aggregate det In HeliosData.recursoCostoDetalle _
                       Join costo In HeliosData.recursoCosto _
                       On costo.idCosto Equals det.idCosto _
                       Where costo.idpadre = be.idCosto _
                       Into SumaMN = Sum(det.montoMN),
                       SumaME = Sum(det.montoME)


        obj = New recursoCosto
        obj.TotalMN = consulta.SumaMN.GetValueOrDefault
        obj.TotalME = consulta.SumaME.GetValueOrDefault

        Return obj
    End Function

    Public Sub CambioAsigancion(be As recursoCostoDetalle)
        Dim obj As recursoCostoDetalle = HeliosData.recursoCostoDetalle.Where(Function(o) o.secuencia = be.secuencia).FirstOrDefault
        Using ts As New TransactionScope
            If Not IsNothing(obj) Then
                obj.idProceso = be.idProceso
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub eliminarDetalleCostoByIdDocumento(intidDocumento As Integer)
        Using ts As New TransactionScope
            Dim ConsultaCosto = (From n In HeliosData.recursoCostoDetalle _
                             Where n.documentoRef = intidDocumento).ToList

            For Each i In ConsultaCosto
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(i)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GrabarDetalleRecursoFinanza(be As List(Of recursoCostoDetalle), listaAsiento As List(Of asiento))
        Dim obj As New recursoCostoDetalle
        Dim asientoBL As New AsientoBL
        Using ts As New TransactionScope
            For Each i In be


                'se actualzia el costeo dle asiento
                Dim caja = HeliosData.movimiento.Where(Function(o) o.idmovimiento = i.documentoRef).FirstOrDefault
                caja.idCosto = i.idCosto
                caja.tipoCosto = i.tipoCosto

                obj = New recursoCostoDetalle With
                      {
                .idCosto = i.idCosto,
                .fechaRegistro = i.fechaRegistro,
                .iditem = i.iditem,
                .destino = i.destino,
                .descripcion = i.descripcion,
                .um = i.um,
                .cant = i.cant,
                .puMN = i.puMN,
                .puME = i.puME,
                .montoMN = i.montoMN,
                .montoME = i.montoME,
                .documentoRef = i.documentoRef,
                .itemRef = i.itemRef,
                .operacion = i.operacion,
                .procesado = i.procesado,
                .idProceso = i.idProceso,
                .tipoCosto = "RL",
                .fechaTrabajo = i.fechaTrabajo,
                .Periodo = i.Periodo
                    }
                HeliosData.recursoCostoDetalle.Add(obj)
            Next
            asientoBL.SavebyGroup(listaAsiento)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub GrabarDetalleRecursos(be As List(Of recursoCostoDetalle), listaAsiento As List(Of asiento))
        Dim obj As New recursoCostoDetalle
        Dim asientoBL As New AsientoBL
        Using ts As New TransactionScope
            For Each i In be
                Dim compraDet = (From n In HeliosData.documentocompradetalle
                                 Where n.secuencia = i.itemRef).FirstOrDefault

                compraDet.idCosto = i.idCosto
                compraDet.tipoCosto = i.tipoCosto

                obj = New recursoCostoDetalle With
                      {
                .idCosto = i.idCosto,
                .fechaRegistro = i.fechaRegistro,
                .iditem = i.iditem,
                .destino = i.destino,
                .descripcion = i.descripcion,
                .um = i.um,
                .cant = i.cant,
                .puMN = i.puMN,
                .puME = i.puME,
                .montoMN = i.montoMN,
                .montoME = i.montoME,
                .documentoRef = i.documentoRef,
                .itemRef = i.itemRef,
                .operacion = i.operacion,
                .procesado = i.procesado,
                .idProceso = i.idProceso,
                .tipoCosto = "RL",
                .fechaTrabajo = i.fechaTrabajo,
                .Periodo = i.Periodo,
                .elementoCosto = i.elementoCosto
                    }
                HeliosData.recursoCostoDetalle.Add(obj)
            Next
            asientoBL.SavebyGroup(listaAsiento)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub GrabarDetalleRecursosByTarea(be As recursoCostoDetalle)
        Dim obj As New recursoCostoDetalle

        Using ts As New TransactionScope

            obj = New recursoCostoDetalle With
                  {
            .idCosto = be.idCosto,
            .fechaRegistro = be.fechaRegistro,
            .iditem = be.iditem,
            .destino = be.destino,
            .descripcion = be.descripcion,
            .um = be.um,
            .cant = be.cant,
            .puMN = be.puMN,
            .puME = be.puME,
            .montoMN = be.montoMN,
            .montoME = be.montoME,
            .documentoRef = be.documentoRef,
            .itemRef = be.itemRef,
            .operacion = Nothing,
            .procesado = "N",
            .idProceso = be.idProceso,
            .tipoCosto = be.tipoCosto}
            HeliosData.recursoCostoDetalle.Add(obj)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub


    Public Sub EditarDetalleRecursoTareaBySecuencia(be As recursoCostoDetalle)
        Dim obj As New recursoCostoDetalle

        Dim det As recursoCostoDetalle = HeliosData.recursoCostoDetalle.Where(Function(o) o.secuencia = be.secuencia).FirstOrDefault

        Using ts As New TransactionScope

            If Not IsNothing(det) Then
                det.iditem = be.iditem
                det.descripcion = be.descripcion
                det.um = be.um
                det.cant = be.cant
                det.montoMN = be.montoMN
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub EditarRequerimeintoBySec(be As recursoCostoDetalle)
        Dim obj As New recursoCostoDetalle

        Dim det As recursoCostoDetalle = HeliosData.recursoCostoDetalle.Where(Function(o) o.secuencia = be.secuencia).FirstOrDefault

        Using ts As New TransactionScope

            If Not IsNothing(det) Then
                det.fechaRegistro = be.fechaRegistro
                det.iditem = be.iditem
                det.descripcion = be.descripcion
                det.um = be.um
                det.cant = be.cant
                det.idProceso = be.idProceso
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub EliminarDetalleCostoPlan(be As recursoCostoDetalle)
        Dim obj As New recursoCostoDetalle

        Dim det As recursoCostoDetalle = HeliosData.recursoCostoDetalle.Where(Function(o) o.secuencia = be.secuencia).FirstOrDefault

        Using ts As New TransactionScope

            If Not IsNothing(det) Then
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(det)
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub


    Public Sub GrabarDetalleRecursosByOne(be As documentocompradetalle, intIdDocumento As Integer)
        Dim obj As New recursoCostoDetalle

        Using ts As New TransactionScope
            Dim compraDet = (From n In HeliosData.documentocompradetalle _
                                Where n.secuencia = be.secuencia).FirstOrDefault

            compraDet.idCosto = be.idCosto
            compraDet.tipoCosto = be.tipoCosto

            obj = New recursoCostoDetalle With
                  {
            .idCosto = be.idCosto,
            .fechaRegistro = be.FechaDoc,
            .iditem = be.idItem,
            .destino = be.destino,
            .descripcion = be.descripcionItem,
            .um = be.unidad1,
            .cant = be.monto1,
            .puMN = be.precioUnitario,
            .puME = be.precioUnitarioUS,
            .montoMN = be.importe,
            .montoME = be.importeUS,
            .documentoRef = intIdDocumento,
            .itemRef = be.secuencia,
            .operacion = "02",
            .procesado = "N",
            .idProceso = be.idProceso,
            .tipoCosto = "RL"
                }
            HeliosData.recursoCostoDetalle.Add(obj)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub GrabarDetalleRecursosByOneLibro(be As List(Of documentoLibroDiarioDetalle), intIdDocumento As Integer)
        Dim obj As New recursoCostoDetalle

        Using ts As New TransactionScope
            Dim compraDet = (From n In HeliosData.documentoLibroDiario _
                                Where n.idDocumento = intIdDocumento).FirstOrDefault

            compraDet.tieneCosto = "S"


            For Each i In be
                Dim codigoCuenta = Mid(i.cuenta, 1, 2)
                Select Case Val(codigoCuenta)
                    Case 62 To 68
                        obj = New recursoCostoDetalle With
                              {
                                  .idCosto = i.idCosto,
                                  .fechaRegistro = i.FechaDoc,
                                  .iditem = i.cuenta,
                                  .destino = "0",
                                  .descripcion = i.descripcion,
                                  .um = "07",
                                  .cant = 0,
                                  .puMN = 0,
                                  .puME = 0,
                                  .montoMN = i.importeMN,
                                  .montoME = i.importeME,
                                  .documentoRef = intIdDocumento,
                                  .itemRef = 0,
                                  .operacion = "9923",
                                  .procesado = "N",
                                  .idProceso = i.idProceso,
                                  .tipoCosto = "RL"
                              }
                        HeliosData.recursoCostoDetalle.Add(obj)
                End Select
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Function GetListadoRecursosByIdCosto(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim Lista As New List(Of recursoCostoDetalle)
        Dim obj As New recursoCostoDetalle
        Dim consulta = (From n In HeliosData.recursoCostoDetalle _
                        Where n.idCosto = be.idCosto).ToList

        For Each i In consulta
            obj = New recursoCostoDetalle With
                  {
            .secuencia = i.secuencia,
           .idCosto = i.idCosto,
            .iditem = i.iditem,
            .destino = i.destino,
            .descripcion = i.descripcion,
            .um = i.um,
            .cant = i.cant,
            .puMN = i.puMN,
            .puME = i.puME,
            .montoMN = i.montoMN,
            .montoME = i.montoME,
            .documentoRef = i.documentoRef,
            .itemRef = i.itemRef,
            .operacion = i.operacion,
            .procesado = i.procesado
                      }
            Lista.Add(obj)
        Next
        Return Lista
    End Function

    Public Function GetListadoRecursosByProceso(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim Lista As New List(Of recursoCostoDetalle)
        Dim obj As New recursoCostoDetalle
        Dim consulta = (From det In HeliosData.recursoCostoDetalle _
                        Join costo In HeliosData.recursoCosto _
                        On costo.idCosto Equals det.idCosto _
                        Where det.idProceso = be.idCosto).ToList

        For Each i In consulta
            obj = New recursoCostoDetalle With
                  {
            .secuencia = i.det.secuencia,
           .idCosto = i.costo.idCosto,
            .NombreCosto = i.costo.subtipo,
            .iditem = i.det.iditem,
            .destino = i.det.destino,
            .descripcion = i.det.descripcion,
            .um = i.det.um,
            .cant = i.det.cant,
            .puMN = i.det.puMN,
            .puME = i.det.puME,
            .montoMN = i.det.montoMN,
            .montoME = i.det.montoME,
            .documentoRef = i.det.documentoRef,
            .itemRef = i.det.itemRef,
            .operacion = i.det.operacion,
            .procesado = i.det.procesado
                      }
            Lista.Add(obj)
        Next
        Return Lista
    End Function

    Public Function GetCountItemsByProceso(be As recursoCosto) As Integer
        Dim Lista As New List(Of recursoCostoDetalle)
        Dim obj As New recursoCostoDetalle
        Dim consulta = (From det In HeliosData.recursoCostoDetalle _
                        Join costo In HeliosData.recursoCosto _
                        On costo.idCosto Equals det.idCosto _
                        Where det.idProceso = be.idCosto).Count

        Return consulta
    End Function


    Public Function GetListadoGastosConsolidados(be As recursoCosto) As List(Of recursoCostoDetalle)
        Return (From det In HeliosData.recursoCostoDetalle _
                        Where det.idCosto = be.idCosto And det.tipoCosto = "RL").ToList
    End Function


    Public Function GetListadoRecursosByPadre(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim Lista As New List(Of recursoCostoDetalle)
        Dim obj As New recursoCostoDetalle
        Dim consulta = (From det In HeliosData.recursoCostoDetalle
                        Join costo In HeliosData.recursoCosto
                        On costo.idCosto Equals det.idCosto
                        Join actividad In HeliosData.recursoCosto
                        On actividad.idCosto Equals det.idProceso
                        Where costo.idpadre = be.idCosto And det.tipoCosto = "RL").ToList

        For Each i In consulta
            obj = New recursoCostoDetalle With
                  {
            .secuencia = i.det.secuencia,
            .actividad = i.actividad.nombreCosto,
           .idCosto = i.costo.idCosto,
            .NombreCosto = i.costo.subtipo,
            .iditem = i.det.iditem,
            .destino = i.det.destino,
            .descripcion = i.det.descripcion,
            .um = i.det.um,
            .cant = i.det.cant,
            .puMN = i.det.puMN,
            .puME = i.det.puME,
            .montoMN = i.det.montoMN,
            .montoME = i.det.montoME,
            .documentoRef = i.det.documentoRef,
            .itemRef = i.det.itemRef,
            .operacion = i.det.operacion,
            .procesado = i.det.procesado
                      }
            Lista.Add(obj)
        Next
        Return Lista
    End Function

    Public Function GetListadoRecursosPorProyectoGeneral(be As recursoCosto) As List(Of usp_GetRecursosByProyectoGeneral_Result)
        Return HeliosData.usp_GetRecursosByProyectoGeneral(be.idCosto).ToList
    End Function

    Public Function GetRecursosAsignadosByCosto(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim Lista As New List(Of recursoCostoDetalle)
        Dim obj As New recursoCostoDetalle
        Dim consulta = (From det In HeliosData.recursoCostoDetalle _
                        Where det.idCosto = be.idCosto).ToList

        For Each i In consulta
            obj = New recursoCostoDetalle With
                  {
            .secuencia = i.secuencia,
            .fechaRegistro = i.fechaRegistro,
           .idCosto = i.idCosto,
            .iditem = i.iditem,
            .destino = i.destino,
            .descripcion = i.descripcion,
            .um = i.um,
            .cant = i.cant,
            .puMN = i.puMN,
            .puME = i.puME,
            .montoMN = i.montoMN,
            .montoME = i.montoME,
            .documentoRef = i.documentoRef,
            .itemRef = i.itemRef,
            .operacion = i.operacion,
            .procesado = i.procesado,
            .idProceso = i.idProceso
                      }
            Lista.Add(obj)
        Next
        Return Lista
    End Function


    Public Function GetRecursosAsignadosByProceso(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim Lista As New List(Of recursoCostoDetalle)
        Dim obj As New recursoCostoDetalle
        Dim consulta = (From det In HeliosData.recursoCostoDetalle _
                        Where det.idProceso = be.IdProceso).ToList

        For Each i In consulta
            obj = New recursoCostoDetalle With
                  {
            .secuencia = i.secuencia,
            .fechaRegistro = i.fechaRegistro,
            .idCosto = i.idCosto,
            .tipoCosto = i.tipoCosto,
            .iditem = i.iditem,
            .destino = i.destino,
            .descripcion = i.descripcion,
            .um = i.um,
            .cant = i.cant,
            .puMN = i.puMN,
            .puME = i.puME,
            .montoMN = i.montoMN,
            .montoME = i.montoME,
            .documentoRef = i.documentoRef,
            .itemRef = i.itemRef,
            .operacion = i.operacion,
            .procesado = i.procesado,
            .idProceso = i.idProceso
                      }
            Lista.Add(obj)
        Next
        Return Lista
    End Function

    Public Function GetRecursosAsignadosByTipoCosto(be As recursoCostoDetalle) As List(Of recursoCostoDetalle)
        Dim Lista As New List(Of recursoCostoDetalle)
        Dim obj As New recursoCostoDetalle
        Dim consulta = (From det In HeliosData.recursoCostoDetalle _
                        Join Activi In HeliosData.recursoCosto _
                        On Activi.idCosto Equals det.idCosto _
                        Join proc In HeliosData.recursoCosto _
                        On proc.idCosto Equals Activi.idpadre _
                        Join proy In HeliosData.recursoCosto _
                        On proy.idCosto Equals proc.idpadre _
                        Where proy.idCosto = be.idCosto And det.tipoCosto = be.tipoCosto And det.iditem = be.iditem).ToList

        For Each i In consulta
            obj = New recursoCostoDetalle With
                  {
            .secuencia = i.det.secuencia,
           .idCosto = i.det.idCosto,
            .iditem = i.det.iditem,
            .destino = i.det.destino,
            .descripcion = i.det.descripcion,
            .um = i.det.um,
            .cant = i.det.cant,
            .puMN = i.det.puMN,
            .puME = i.det.puME,
            .montoMN = i.det.montoMN,
            .montoME = i.det.montoME,
            .documentoRef = i.det.documentoRef,
            .itemRef = i.det.itemRef,
            .operacion = i.det.operacion,
            .procesado = i.det.procesado,
            .idProceso = i.det.idProceso,
            .NombreProceso = i.proc.nombreCosto,
            .NomActividad = i.Activi.nombreCosto,
            .idActividad = i.Activi.idCosto
                      }
            Lista.Add(obj)
        Next
        Return Lista
    End Function

    Public Function GetSumByCosto(be As recursoCosto) As Double

        Dim consulta = (From n In HeliosData.recursoCostoDetalle _
                        Join rec In HeliosData.recursoCosto _
                        On rec.idCosto Equals n.idCosto _
                        Where rec.subtipo = be.subtipo Select n.montoMN).Sum

        Return consulta.GetValueOrDefault
    End Function

    Public Function GetSumByCostoGastos(be As recursoCosto) As Double

        Dim consulta = (From n In HeliosData.recursoCostoDetalle _
                        Join rec In HeliosData.recursoCosto _
                        On rec.idCosto Equals n.idCosto _
                        Where rec.tipo = be.tipo Select n.montoMN).Sum

        Return consulta.GetValueOrDefault
    End Function

End Class
