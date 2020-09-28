Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class AsientoBL
    Inherits BaseBL

    Public Function GetHojaTrabajoXmodulo(be As asiento) As List(Of usp_HojaTrabajoXmodulo_Result)
        Return HeliosData.usp_HojaTrabajoXmodulo(be.periodo, be.idEmpresa, be.tipoAsiento).ToList
    End Function


    Public Function GetHojaTrabajCompras(be As asiento) As List(Of usp_HojaTrabajoCompras_Result)
        Return HeliosData.usp_HojaTrabajoCompras(be.periodo, be.idEmpresa).ToList
    End Function

    Public Function GetResumenLibroDiarioByPeriodo(be As asiento) As List(Of asiento)
        Dim obj As New asiento
        Dim lista As New List(Of asiento)
        Dim consulta = (From n In HeliosData.asiento
                        Join m In HeliosData.movimiento On m.idAsiento Equals n.idAsiento
                        Join doc In HeliosData.documento On doc.idDocumento Equals n.idDocumento
                        Where n.periodo = be.periodo And n.idEmpresa = Gempresas.IdEmpresaRuc).ToList

        For Each i In consulta
            obj = New asiento
            obj.idAsiento = i.n.idAsiento
            obj.periodo = i.n.periodo
            obj.tipoAsiento = i.n.tipoAsiento
            obj.cuentaCont = i.m.cuenta
            obj.tipoOperacion = i.doc.tipoOperacion
            obj.moneda = i.doc.moneda
            obj.idEntidad = i.doc.idEntidad
            obj.nombreEntidad = i.doc.entidad
            obj.NroDocEntidad = i.doc.nrodocEntidad
            obj.tipoDocumento = i.doc.tipoDoc
            obj.nroDoc = i.doc.nroDoc
            obj.fechaProceso = i.doc.fechaProceso
            obj.glosa = i.n.glosa
            obj.codigoLibro = i.n.codigoLibro
            obj.tipo = i.m.tipo
            obj.importeMN = i.m.monto
            obj.importeME = i.m.montoUSD
            lista.Add(obj)
        Next
        Return lista
    End Function

    Public Sub EliminarAsientoCostos(be As asiento)
        Dim recursoCostoBL As New recursoCostoDetalleBL
        Dim consulta = (From n In HeliosData.asiento
                        Where n.tipoAsiento = "ACCA" And n.idDocumento = be.idDocumento).ToList

        Using ts As New TransactionScope

            Select Case be.codigoLibro
                Case "02", "8", "13"
                    Dim obj As List(Of documentocompradetalle) = HeliosData.documentocompradetalle.Where(Function(o) o.idDocumento = be.idDocumento).ToList
                    For Each i In obj
                        i.tipoCosto = Nothing
                        i.idCosto = Nothing
                    Next
                Case Else
                    Dim obj As documentoCaja = HeliosData.documentoCaja.Where(Function(o) o.idDocumento = be.idDocumento).FirstOrDefault
                    If Not IsNothing(obj) Then
                        obj.estado = Nothing
                    End If

            End Select

            For Each i In consulta
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(i)
            Next

            'eliminado costos referenciados
            recursoCostoBL.eliminarDetalleCostoByIdDocumento(be.idDocumento)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub GrabarListaAsientosXConciliar(be As List(Of asiento))
        Dim obj As New recursoCostoDetalle
        Dim entidadBL As New entidadBL
        Try
            Using ts As New TransactionScope
                For Each i In be
                    Dim documentoOB = HeliosData.documento.Where(Function(o) o.idDocumento = i.idDocumento).FirstOrDefault
                    i.idEntidad = documentoOB.idEntidad
                    i.nombreEntidad = documentoOB.entidad
                    i.tipoEntidad = documentoOB.tipoEntidad

                    Select Case i.codigoLibro
                        Case "8", "13"
                            Dim compra = (From n In HeliosData.documentocompra
                                          Where n.idDocumento = i.idDocumento).FirstOrDefault

                            compra.aprobado = "S"





                            Dim cuentaCosto = From n1 In i.movimiento
                                              Where n1.cuenta.StartsWith("6")

                            For Each t In cuentaCosto
                                Dim codigoCuenta = Mid(t.cuenta, 1, 2)

                                Select Case Val(codigoCuenta)
                                    Case 62 To 68
                                        obj = New recursoCostoDetalle With
                                              {
                                                  .idCosto = i.idCosto,
                                                  .fechaRegistro = i.fechaProceso,
                                                  .iditem = t.cuenta,
                                                  .destino = "0",
                                                  .descripcion = t.descripcion,
                                                  .um = "07",
                                                  .cant = 0,
                                                  .puMN = 0,
                                                  .puME = 0,
                                                  .montoMN = t.monto,
                                                  .montoME = 0,
                                                  .documentoRef = i.idDocumento,
                                                  .itemRef = 0,
                                                  .operacion = "8",
                                                  .procesado = "N",
                                                  .idProceso = i.IdProceso,
                                                  .tipoCosto = "RL"
                                              }
                                        HeliosData.recursoCostoDetalle.Add(obj)
                                End Select
                            Next

                        Case Else
                            Dim caja = (From n In HeliosData.documentoCaja
                                        Where n.idDocumento = i.idDocumento).FirstOrDefault

                            caja.estado = "S"

                            Dim cuentaCosto = (From n1 In i.movimiento
                                               Where n1.cuenta.StartsWith("6")).ToList

                            If cuentaCosto.Count > 0 Then
                                caja.idcosto = Nothing
                                caja.asientoCosto = StatusAsientoCosto.AsientoPorConfirmar
                            Else
                                caja.idcosto = Nothing
                                caja.asientoCosto = StatusAsientoCosto.AsientoProcesado
                            End If

                            'For Each t In cuentaCosto
                            '    Dim codigoCuenta = Mid(t.cuenta, 1, 2)

                            '    Select Case Val(codigoCuenta)
                            '        Case 62 To 68
                            '            obj = New recursoCostoDetalle With
                            '                  {
                            '                      .idCosto = i.idCosto,
                            '                      .fechaRegistro = i.fechaProceso,
                            '                      .iditem = t.cuenta,
                            '                      .destino = "0",
                            '                      .descripcion = t.descripcion,
                            '                      .um = "07",
                            '                      .cant = 0,
                            '                      .puMN = 0,
                            '                      .puME = 0,
                            '                      .montoMN = t.monto,
                            '                      .montoME = 0,
                            '                      .documentoRef = i.idDocumento,
                            '                      .itemRef = 0,
                            '                      .operacion = "1",
                            '                      .procesado = "N",
                            '                      .idProceso = i.IdProceso,
                            '                      .tipoCosto = "RL"
                            '                  }
                            '            HeliosData.recursoCostoDetalle.Add(obj)
                            '    End Select
                            'Next

                    End Select

                    'InsertDefault2(i)
                Next
                SavebyGroupCosteo(be)
                ' SavebyGroup(be)

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub SavebyGroupCosteo(ByVal asientos As List(Of asiento))
        Using ts As New TransactionScope
            For Each obj In asientos
                Select Case obj.Action
                    Case BaseBE.EntityAction.INSERT
                        '       Me.Insert(obj)
                        Me.InsertTransitoCosteo(obj)
                    Case BaseBE.EntityAction.UPDATE
                        Me.Update(obj)
                    Case BaseBE.EntityAction.DELETE
                        Me.Delete(obj)
                End Select
            Next
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertTransitoCosteo(ByVal asientoBE As asiento)
        Dim movimientoBL As New movimientoBL
        Using ts As New TransactionScope
            'Se inserta asiento
            InsertDefault2(asientoBE)
            For Each movimientoBE In asientoBE.movimiento
                movimientoBL.InsertDefaultCosteo(movimientoBE, asientoBE.idAsiento)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function UbicarAsientoPorPeriodoXcodigo(srtFechaMes As Date, srtFechaAnio As Date, strAprobado As String, strCodigo As String) As List(Of asiento)
        Return (From a In HeliosData.asiento _
               Where a.fechaProceso.Value.Month = (srtFechaMes).Month _
                AndAlso a.fechaProceso.Value.Year = (srtFechaAnio.Year) _
                AndAlso a.tipo = strAprobado _
                And a.codigoLibro = strCodigo _
                Select a).ToList
    End Function

    'Public Sub New(Context As HELIOSEntities, ts As TransactionScope)
    '    MyBase.New(Context, ts)
    'End Sub

    ''' <summary>
    ''' inserta un asiento con todos su moviemientos
    ''' </summary>
    ''' <param name="asientoBE"></param>
    ''' <remarks></remarks>
    Public Sub Insert(ByVal asientoBE As asiento, intIdDocumento As Integer)
        Dim movimientoBL As New movimientoBL
        Using ts As New TransactionScope
            'Se inserta asiento
            '  HeliosData.asiento.Add(asientoBE)
            InsertDefault(asientoBE, intIdDocumento)
            'Se inserta detalle
            For Each movimientoBE In asientoBE.movimiento
                'HeliosData.movimiento.Add(movimientoBE)
                movimientoBL.InsertDefault(movimientoBE, asientoBE.idAsiento)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertCompras(ByVal asientoBE As asiento, intIdDocumento As Integer)
        Dim movimientoBL As New movimientoBL
        Dim idTipo As Integer
        Using ts As New TransactionScope
            'Se inserta asiento
            InsertDefault(asientoBE, intIdDocumento)
            For Each movimientoBE In asientoBE.movimiento
                idTipo = movimientoBL.InsertDefault(movimientoBE, asientoBE.idAsiento)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertPrestamo(ByVal asientoBE As asiento)
        Dim movimientoBL As New movimientoBL
        Dim idTipo As Integer
        Using ts As New TransactionScope
            'Se inserta asiento
            InsertDefault2(asientoBE)
            For Each movimientoBE In asientoBE.movimiento
                idTipo = movimientoBL.InsertDefault(movimientoBE, asientoBE.idAsiento)
                'totalesCuentaBL.InsertCC(movimientoBE, intIdDocumento, idTipo, asientoBE.idEmpresa, asientoBE.idCentroCostos)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertTransito(ByVal asientoBE As asiento)
        Dim movimientoBL As New movimientoBL
        Using ts As New TransactionScope
            'Se inserta asiento
            InsertDefault2(asientoBE)
            For Each movimientoBE In asientoBE.movimiento
                movimientoBL.InsertDefault(movimientoBE, asientoBE.idAsiento)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertDefault(ByVal asientoBE As asiento, intIdDocumento As Integer)
        Dim nasiento As New asiento
        Using ts As New TransactionScope
            'Se inserta asiento
            With nasiento
                nasiento.idDocumento = intIdDocumento
                nasiento.periodo = asientoBE.periodo
                nasiento.idEmpresa = asientoBE.idEmpresa
                nasiento.idCentroCostos = asientoBE.idCentroCostos
                nasiento.idEntidad = asientoBE.idEntidad
                nasiento.nombreEntidad = asientoBE.nombreEntidad
                nasiento.tipoEntidad = asientoBE.tipoEntidad
                nasiento.fechaProceso = asientoBE.fechaProceso
                nasiento.codigoLibro = asientoBE.codigoLibro
                nasiento.tipo = asientoBE.tipo
                nasiento.tipoAsiento = asientoBE.tipoAsiento
                nasiento.importeMN = asientoBE.importeMN
                nasiento.importeME = asientoBE.importeME
                nasiento.glosa = asientoBE.glosa
                nasiento.usuarioActualizacion = asientoBE.usuarioActualizacion
                nasiento.fechaActualizacion = asientoBE.fechaActualizacion
            End With
            HeliosData.asiento.Add(nasiento)
            HeliosData.SaveChanges()
            ts.Complete()
            asientoBE.idAsiento = nasiento.idAsiento
        End Using
    End Sub

    Public Sub InsertDefault2(ByVal asientoBE As asiento)
        Dim nasiento As New asiento
        Using ts As New TransactionScope
            'Se inserta asiento
            With nasiento
                nasiento.idDocumento = asientoBE.idDocumento
                nasiento.periodo = asientoBE.periodo
                nasiento.idEmpresa = asientoBE.idEmpresa
                nasiento.idCentroCostos = asientoBE.idCentroCostos
                nasiento.idEntidad = asientoBE.idEntidad
                nasiento.nombreEntidad = asientoBE.nombreEntidad
                nasiento.tipoEntidad = asientoBE.tipoEntidad
                nasiento.fechaProceso = asientoBE.fechaProceso
                nasiento.codigoLibro = asientoBE.codigoLibro
                nasiento.tipo = asientoBE.tipo
                nasiento.tipoAsiento = asientoBE.tipoAsiento
                nasiento.importeMN = asientoBE.importeMN
                nasiento.importeME = asientoBE.importeME
                nasiento.glosa = asientoBE.glosa
                nasiento.usuarioActualizacion = asientoBE.usuarioActualizacion
                nasiento.fechaActualizacion = asientoBE.fechaActualizacion
            End With
            HeliosData.asiento.Add(nasiento)
            HeliosData.SaveChanges()
            ts.Complete()
            asientoBE.idAsiento = nasiento.idAsiento
        End Using
    End Sub

    Public Sub Update(ByVal asientoBE As asiento)
        Using ts As New TransactionScope
            'Se actualiza asiento
            'HeliosData.asiento.Attach(asientoBE)
            HeliosData.asiento.Attach(asientoBE)
            HeliosData.Entry(asientoBE).State = System.Data.Entity.EntityState.Modified

            'HeliosData.asiento.ApplyCurrentValues(asientoBE)
            'Se inserta/actualiza/elimina detalle
            For Each movimientoBE In asientoBE.movimiento
                Select Case movimientoBE.Action
                    Case BaseBE.EntityAction.INSERT
                        HeliosData.movimiento.Add(movimientoBE)
                    Case BaseBE.EntityAction.UPDATE
                        HeliosData.movimiento.Attach(movimientoBE)
                    Case BaseBE.EntityAction.DELETE
                        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(movimientoBE)
                End Select
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal asientoBE As asiento)
        Using ts As New TransactionScope
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(asientoBE)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub DeletePorIdAsiento(ByVal intIdAsiento As Integer)
        Using ts As New TransactionScope
            Dim consulta As asiento = HeliosData.asiento.Where(Function(o) o.idAsiento = intIdAsiento).FirstOrDefault
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub DeletePorDocumento(ByVal intIdDocumento As Integer)
        Using ts As New TransactionScope
            Dim consulta As List(Of asiento) = HeliosData.asiento.Where(Function(o) o.idDocumento = intIdDocumento).ToList
            For Each i In consulta
                DeletePorIdAsiento(i.idAsiento)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub DeleteGroup(intIdDocumento As Integer)
        Using ts As New TransactionScope
            Dim asiento As List(Of asiento) = HeliosData.asiento.Where(Function(o) o.idDocumento = intIdDocumento).ToList
            For Each obj In asiento
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(obj)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub SavebyGroup(ByVal asientos As List(Of asiento))
        Using ts As New TransactionScope
            For Each obj In asientos
                Select Case obj.Action
                    Case BaseBE.EntityAction.INSERT
                        '       Me.Insert(obj)
                        Me.InsertTransito(obj)
                    Case BaseBE.EntityAction.UPDATE
                        Me.Update(obj)
                    Case BaseBE.EntityAction.DELETE
                        Me.Delete(obj)
                End Select
            Next
            ts.Complete()
        End Using
    End Sub

    Public Sub ActualizarEstadoAprobado(ByVal asientos As List(Of asiento))
        Using ts As New TransactionScope
            For Each obj In asientos
                Dim asiento As asiento = HeliosData.asiento.Where(Function(o) o.idAsiento = obj.idAsiento).FirstOrDefault
                If Not IsNothing(asiento) Then
                    asiento.tipo = obj.tipo
                End If
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub ReingresarAsientoContable(objAsiento As asiento)
        Try
            Using ts As New TransactionScope
                Dim asiento As asiento = HeliosData.asiento.Where(Function(o) o.idAsiento = objAsiento.idAsiento).FirstOrDefault
                Delete(asiento)
                InsertTransito(objAsiento)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarAsientoDetalleXidAsiento(objAsiento As asiento)

        Try
            Using ts As New TransactionScope
                Dim asiento As asiento = HeliosData.asiento.Where(Function(o) o.idAsiento = objAsiento.idAsiento).FirstOrDefault
                asiento.glosa = objAsiento.glosa
                asiento.fechaProceso = objAsiento.fechaProceso
                asiento.importeMN = objAsiento.importeMN
                asiento.importeME = objAsiento.importeME
                'movmieto
                For Each i In objAsiento.movimiento
                    Dim mov As movimiento = HeliosData.movimiento.Where(Function(o) o.idAsiento = objAsiento.idAsiento And o.idmovimiento = i.idmovimiento).FirstOrDefault
                    mov.cuenta = i.cuenta
                    mov.descripcion = i.descripcion
                    mov.tipo = i.tipo
                    mov.monto = i.monto
                    mov.montoUSD = i.montoUSD
                Next
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SavebyGroupDoc(ByVal DocumentoBL As documento)
        Using ts As New TransactionScope
            For Each obj In DocumentoBL.asiento
                Select Case obj.Action
                    Case BaseBE.EntityAction.INSERT
                        InsertCompras(obj, DocumentoBL.idDocumento)
                    Case BaseBE.EntityAction.UPDATE
                        Update(obj)
                    Case BaseBE.EntityAction.DELETE
                        Delete(obj)
                End Select
            Next
            HeliosData.SaveChanges()
            ts.Complete()

        End Using
    End Sub

    Public Function InsertarGrupoAsientos(ByVal DocumentoBL As documento) As Integer
        Dim codAsiento As Integer = 0
        Using ts As New TransactionScope
            For Each obj In DocumentoBL.asiento
                Select Case obj.Action
                    Case BaseBE.EntityAction.INSERT
                        Me.InsertDefault(obj, DocumentoBL.idDocumento)
                        codAsiento = obj.idAsiento
                    Case BaseBE.EntityAction.UPDATE
                        Me.Update(obj)
                    Case BaseBE.EntityAction.DELETE
                        Me.Delete(obj)
                End Select
            Next
            HeliosData.SaveChanges()
            ts.Complete()
            Return codAsiento
        End Using
    End Function


    Public Sub SavebyGroupDocPrestamo(ByVal DocumentoBL As documento)
        Using ts As New TransactionScope
            For Each obj In DocumentoBL.asiento
                Select Case obj.Action
                    Case BaseBE.EntityAction.INSERT
                        Me.InsertPrestamo(obj)
                    Case BaseBE.EntityAction.UPDATE
                        Me.Update(obj)
                    Case BaseBE.EntityAction.DELETE
                        Me.Delete(obj)
                End Select
            Next
            HeliosData.SaveChanges()
            ts.Complete()

        End Using
    End Sub

    Public Function GetAll() As List(Of asiento)
        Return (From a In HeliosData.asiento Select a).ToList
    End Function

    Public Function UbicarAsientoPorDocumento(intIdDocumento As Integer) As List(Of asiento)
        Return (From a In HeliosData.asiento Where a.idDocumento = intIdDocumento Select a).ToList
    End Function

    Public Function UbicarAsientoPorIDAsiento(intIdAsiento As Integer) As asiento
        Return (From a In HeliosData.asiento Where a.idAsiento = intIdAsiento).FirstOrDefault
    End Function

    Public Function UbicarAsientoPorEntidad(intidEntidad As Integer) As List(Of asiento)
        Return (From a In HeliosData.asiento Where a.idEntidad = intidEntidad Select a).ToList
    End Function

    Public Function UbicarAsientoPorTipo(srtidTipo As String) As List(Of asiento)
        Return (From a In HeliosData.asiento Where a.codigoLibro = srtidTipo Select a).ToList
    End Function

    Public Function UbicarAsientoPorFecha(srtFechaInicio As Date, srtFechaHasta As Date, srtidTipo As String) As List(Of asiento)
        Return (From a In HeliosData.asiento _
               Where a.fechaProceso >= (srtFechaInicio) _
                AndAlso a.fechaProceso <= (srtFechaHasta) _
                And a.codigoLibro = srtidTipo Select a).ToList
    End Function

    Public Function UbicarAsientoPorPeriodo(srtFechaMes As Date, srtFechaAnio As Date, strAprobado As String) As List(Of asiento)
        Return (From a In HeliosData.asiento _
               Where a.fechaProceso.Value.Month = (srtFechaMes).Month _
                AndAlso a.fechaProceso.Value.Year = (srtFechaAnio.Year) _
                AndAlso a.tipo = strAprobado _
                Select a).ToList
    End Function

End Class
