Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class actividadRecursoBL
    Inherits BaseBL
    Public Function GetListaInsumosPorProyecto(intIDProyecto As Integer, strTipoRecurso As String) 'As List(Of actividadRecurso)
        Dim consulta As New List(Of actividadRecurso)
        Dim objRecurso As New actividadRecurso
        Dim consulta2 = (From a In HeliosData.actividadRecurso _
                        Group Join Insumo In HeliosData.detalleitems _
                        On a.idItem Equals Insumo.codigodetalle _
                        Into ords = Group _
                        From e In ords.DefaultIfEmpty _
                        Where a.idProyecto = intIDProyecto _
                        And a.TipoRecurso = strTipoRecurso _
                        And a.tipoPlan = "B" And a.Sustentado = "1").ToList

        Select Case strTipoRecurso
            Case TipoRecurso.EXISTENCIA

                For Each obj In consulta2
                    objRecurso = New actividadRecurso
                    objRecurso.idActividadRecurso = obj.a.idActividadRecurso
                    objRecurso.idItem = obj.e.codigodetalle
                    objRecurso.Descripcion = obj.e.descripcionItem
                    objRecurso.unidadMedida = obj.e.unidad1
                    objRecurso.Tipo = obj.e.tipoExistencia
                    objRecurso.CantRequerida = obj.a.CantRequerida
                    objRecurso.ValorMercadoPu = obj.a.ValorMercadoPu
                    objRecurso.TotalCosto = obj.a.TotalCosto
                    objRecurso.cuentaContable = obj.e.cuenta
                    consulta.Add(objRecurso)
                Next
            Case TipoRecurso.SERVICIO

                For Each obj In consulta2
                    objRecurso = New actividadRecurso
                    objRecurso.idActividadRecurso = obj.a.idActividadRecurso
                    objRecurso.idItem = obj.a.cuentaContable
                    objRecurso.Descripcion = obj.a.Descripcion
                    objRecurso.unidadMedida = obj.a.unidadMedida
                    objRecurso.Tipo = Nothing
                    objRecurso.CantRequerida = obj.a.CantRequerida
                    objRecurso.ValorMercadoPu = obj.a.ValorMercadoPu
                    objRecurso.TotalCosto = obj.a.TotalCosto
                    objRecurso.cuentaContable = obj.a.cuentaContable
                    consulta.Add(objRecurso)
                Next
        End Select


        Return consulta
    End Function


    Public Sub InsertSingleCotizacionLiquidacionExcel(ByVal nRecurso As List(Of actividadRecurso), ByVal nGastos As List(Of actividadRecurso), ByVal nEDT As List(Of Actividades), nLiquidacion As List(Of totalesLiquidacion))
        Dim liquidacionBL As New totalesLiquidacionBL
        Dim ActividadesBL As New ActividadesBL
       
        Using ts As New TransactionScope
            If ((nLiquidacion.Count > 0)) Then
                InsertLista(nRecurso, nGastos)
                liquidacionBL.SaveLiquidacionPreliminarExcel(nLiquidacion, nLiquidacion(0).idActividad)
            End If
            If (nEDT.Count > 0) Then
                ActividadesBL.GrabarActividadEDTExcel(nEDT)
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    'Public Sub InsertSingleCotizacionLiquidacionExcel(ByVal nRecurso As List(Of actividadRecurso), ByVal nGastos As List(Of actividadRecurso), nLiquidacion As List(Of totalesLiquidacion))
    '    Dim liquidacionBL As New totalesLiquidacionBL
    '    Using ts As New TransactionScope
    '        InsertLista(nRecurso, nGastos)
    '        liquidacionBL.SaveLiquidacionPreliminarExcel(nLiquidacion, nLiquidacion(0).idActividad)
    '        HeliosData.SaveChanges()
    '        ts.Complete()
    '        'Return nRecurso.idActividadRecurso
    '    End Using
    'End Sub

    Public Function GetConteoActividadRecursos(intIDProyecto As Integer) As Integer
        Dim listTipoRecurso As New List(Of String)()
        listTipoRecurso.Add("EX")
        listTipoRecurso.Add("GS")
        listTipoRecurso.Add("RH")
        listTipoRecurso.Add("K")
        listTipoRecurso.Add("PRS")
        Dim consulta = (From a In HeliosData.actividadRecurso _
                        Where a.idActividad = intIDProyecto _
                        And listTipoRecurso.Contains(a.TipoRecurso) _
                        And a.Sustentado = 0).Count
        Return consulta
    End Function

    Public Function DeleteDefault(ByVal intCodigoDetalle As Integer) As Boolean
        Dim objEstado As New actividadRecurso()
        Try
            Using ts As New TransactionScope()
                objEstado = HeliosData.actividadRecurso.Where(Function(o) o.idActividadRecurso = intCodigoDetalle).First
                'HeliosData.ObjectStateManager.GetObjectStateEntry(objEstado).State.ToString()
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(objEstado)
                HeliosData.SaveChanges()
                ts.Complete()
                Return True
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertSingleLiquidacionIniciacion(ByVal nRecurso As actividadRecurso, nLiquidacion As totalesLiquidacion) As Integer
        Dim liquidacionBL As New totalesLiquidacionBL
        Dim idActividad As Integer
        Using ts As New TransactionScope
            idActividad = InsertSingleIniciacacion(nRecurso)
            liquidacionBL.SaveLiquidacionPreliminar(nLiquidacion, nRecurso.idActividadRecurso)
            HeliosData.SaveChanges()
            ts.Complete()
            Return idActividad
        End Using
    End Function

    Public Function InsertSingleIniciacacion(ByVal nRecurso As actividadRecurso) As Integer
        Dim objRecurso As New actividadRecurso
        Dim objRecursoCalculo As New actividadRecursoCalculo
        Dim ItemBL As New itemBL
        Dim IDItems As Integer
        Dim IDDetalleItem As Integer
        Dim DetalleItemBL As New detalleitemsBL
        Using ts As New TransactionScope

            If (nRecurso.TipoRecurso = "EX") Then
                IDItems = ItemBL.InsertItemExcel(nRecurso.Idempresa, nRecurso.IdEstablecimiento, nRecurso.Clasificacion)
                IDDetalleItem = DetalleItemBL.InsertDetalleItemExcel(IDItems, nRecurso.Idempresa, nRecurso.IdEstablecimiento, nRecurso.Descripcion, nRecurso.idTipoExistencia, nRecurso.cuentaContable)
            Else
                IDDetalleItem = 0
            End If

            objRecurso = New actividadRecurso
            With objRecurso
                .Action = Business.Entity.BaseBE.EntityAction.INSERT
                .idProyecto = nRecurso.idProyecto
                .idActividad = nRecurso.idActividad
                .tipoActividad = nRecurso.tipoActividad
                .Idempresa = nRecurso.Idempresa
                .IdEstablecimiento = nRecurso.IdEstablecimiento
                .fechaIngreso = nRecurso.fechaIngreso
                .TipoRecurso = nRecurso.TipoRecurso
                .cuentaContable = nRecurso.cuentaContable
                .Descripcion = nRecurso.Descripcion
                .detalleExtra = nRecurso.detalleExtra
                .idItem = IDDetalleItem
                .unidadMedida = nRecurso.unidadMedida
                .ValorMercadoPu = nRecurso.ValorMercadoPu
                .CantRequerida = nRecurso.CantRequerida
                .TotalCosto = nRecurso.TotalCosto
                .PsptoReferencial = nRecurso.PsptoReferencial
                .ReferenciaSustento = nRecurso.ReferenciaSustento
                .Costo = nRecurso.Costo
                .NoSustentado = nRecurso.NoSustentado
                .PorIgv = nRecurso.PorIgv
                .Igv = nRecurso.Igv
                .Total = nRecurso.Total
                .PorDeducPlanilla = nRecurso.PorDeducPlanilla
                .DeducPlanilla = nRecurso.DeducPlanilla
                .PorOtrosDeduc = nRecurso.PorOtrosDeduc
                .OtrosDeduc = nRecurso.OtrosDeduc
                .TotalDeduc = nRecurso.TotalDeduc
                .NetoPagar = nRecurso.NetoPagar
                .PorAporPlanilla = nRecurso.PorAporPlanilla
                .AporPlanilla = nRecurso.AporPlanilla
                .PorOtros1 = nRecurso.PorOtros1
                .Otros1 = nRecurso.Otros1
                .TotalAporte = nRecurso.TotalAporte
                .TotalRetenciones = nRecurso.TotalRetenciones
                .PorImpor1 = nRecurso.PorImpor1
                .Impor1 = nRecurso.Impor1
                .PorImpor2 = nRecurso.PorImpor2
                .Impor2 = nRecurso.Impor2
                .TotalImpor = nRecurso.TotalImpor
                .TipoPresupuesto = nRecurso.TipoPresupuesto
                .CostoDirecto = nRecurso.CostoDirecto
                .PorGastosGenerales = nRecurso.PorGastosGenerales
                .GastosGenerales = nRecurso.GastosGenerales
                .PorOtrosIn1 = nRecurso.PorOtrosIn1
                .OtrosIn1 = nRecurso.OtrosIn1
                .ValorVenta = nRecurso.ValorVenta
                .Porcentaje = nRecurso.Porcentaje
                .TotalProyecto = nRecurso.TotalProyecto
                .PorPercep = nRecurso.PorPercep
                .Percepciones = nRecurso.Percepciones
                .PorOtrosIn2 = nRecurso.PorOtrosIn2
                .OtrosIn2 = nRecurso.OtrosIn2
                .TotalPorCobrar = nRecurso.TotalPorCobrar
                .PorDetracciones = nRecurso.PorDetracciones
                .Detracciones = nRecurso.Detracciones
                .PorRetenciones = nRecurso.PorRetenciones
                .Retenciones = nRecurso.Retenciones
                .PorOtroIn3 = nRecurso.PorOtroIn3
                .OtroIn3 = nRecurso.OtroIn3
                .NetoCobrar = nRecurso.NetoCobrar
                .PorcentajeIngre = nRecurso.PorcentajeIngre
                .TipoIncidencia = nRecurso.TipoIncidencia
                .tipoPlan = nRecurso.tipoPlan
                .idOrden = nRecurso.idOrden
                .Sustentado = nRecurso.Sustentado
            End With

            HeliosData.actividadRecurso.Add(objRecurso)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objRecurso.idActividadRecurso
        End Using
    End Function

    Public Function InsertSingleLiquidacion(ByVal nRecurso As actividadRecurso, nLiquidacion As totalesLiquidacion) As Integer
        Dim liquidacionBL As New totalesLiquidacionBL
        Dim idActividad As Integer
        Using ts As New TransactionScope
            idActividad = InsertSingle(nRecurso)
            liquidacionBL.SaveLiquidacionPreliminar(nLiquidacion, nRecurso.idActividadRecurso)
            HeliosData.SaveChanges()
            ts.Complete()
            Return idActividad
        End Using
    End Function

    Public Function InsertSingle(ByVal nRecurso As actividadRecurso) As Integer
        Dim objRecurso As New actividadRecurso
        Dim objRecursoCalculo As New actividadRecursoCalculo
        Dim ItemBL As New itemBL
        Dim IDItems As Integer
        Dim IDDetalleItem As Integer
        Dim DetalleItemBL As New detalleitemsBL
        Using ts As New TransactionScope

            If (nRecurso.TipoRecurso = "EX") Then
                IDItems = ItemBL.InsertItemExcel(nRecurso.Idempresa, nRecurso.IdEstablecimiento, nRecurso.Clasificacion)
                IDDetalleItem = DetalleItemBL.InsertDetalleItemExcel(IDItems, nRecurso.Idempresa, nRecurso.IdEstablecimiento, nRecurso.Descripcion, nRecurso.idTipoExistencia, nRecurso.cuentaContable)
            Else
                IDDetalleItem = 0
            End If

            objRecurso = New actividadRecurso
            With objRecurso
                .Action = Business.Entity.BaseBE.EntityAction.INSERT
                .idProyecto = nRecurso.idProyecto
                .idActividad = nRecurso.idActividad
                .tipoActividad = nRecurso.tipoActividad
                .Idempresa = nRecurso.Idempresa
                .IdEstablecimiento = nRecurso.IdEstablecimiento
                .fechaIngreso = nRecurso.fechaIngreso
                .TipoRecurso = nRecurso.TipoRecurso
                .cuentaContable = nRecurso.cuentaContable
                .Descripcion = nRecurso.Descripcion
                .detalleExtra = nRecurso.detalleExtra
                .idItem = IDDetalleItem
                .unidadMedida = nRecurso.unidadMedida
                .ValorMercadoPu = nRecurso.ValorMercadoPu
                .CantRequerida = nRecurso.CantRequerida
                .TotalCosto = nRecurso.TotalCosto
                .PsptoReferencial = nRecurso.PsptoReferencial
                .ReferenciaSustento = nRecurso.ReferenciaSustento
                .Costo = nRecurso.Costo
                .NoSustentado = nRecurso.NoSustentado
                .PorIgv = nRecurso.PorIgv
                .Igv = nRecurso.Igv
                .Total = nRecurso.Total
                .PorDeducPlanilla = nRecurso.PorDeducPlanilla
                .DeducPlanilla = nRecurso.DeducPlanilla
                .PorOtrosDeduc = nRecurso.PorOtrosDeduc
                .OtrosDeduc = nRecurso.OtrosDeduc
                .TotalDeduc = nRecurso.TotalDeduc
                .NetoPagar = nRecurso.NetoPagar
                .PorAporPlanilla = nRecurso.PorAporPlanilla
                .AporPlanilla = nRecurso.AporPlanilla
                .PorOtros1 = nRecurso.PorOtros1
                .Otros1 = nRecurso.Otros1
                .TotalAporte = nRecurso.TotalAporte
                .TotalRetenciones = nRecurso.TotalRetenciones
                .PorImpor1 = nRecurso.PorImpor1
                .Impor1 = nRecurso.Impor1
                .PorImpor2 = nRecurso.PorImpor2
                .Impor2 = nRecurso.Impor2
                .TotalImpor = nRecurso.TotalImpor
                .TipoPresupuesto = nRecurso.TipoPresupuesto
                .CostoDirecto = nRecurso.CostoDirecto
                .PorGastosGenerales = nRecurso.PorGastosGenerales
                .GastosGenerales = nRecurso.GastosGenerales
                .PorUtilidad = nRecurso.Utilidad
                .PorOtrosIn1 = nRecurso.PorOtrosIn1
                .OtrosIn1 = nRecurso.OtrosIn1
                .ValorVenta = nRecurso.ValorVenta
                .Porcentaje = nRecurso.Porcentaje
                .TotalProyecto = nRecurso.TotalProyecto
                .PorPercep = nRecurso.PorPercep
                .Percepciones = nRecurso.Percepciones
                .PorOtrosIn2 = nRecurso.PorOtrosIn2
                .OtrosIn2 = nRecurso.OtrosIn2
                .TotalPorCobrar = nRecurso.TotalPorCobrar
                .PorDetracciones = nRecurso.PorDetracciones
                .Detracciones = nRecurso.Detracciones
                .PorRetenciones = nRecurso.PorRetenciones
                .Retenciones = nRecurso.Retenciones
                .PorOtroIn3 = nRecurso.PorOtroIn3
                .OtroIn3 = nRecurso.OtroIn3
                .NetoCobrar = nRecurso.NetoCobrar
                .PorcentajeIngre = nRecurso.PorcentajeIngre
                .TipoIncidencia = nRecurso.TipoIncidencia
                .tipoPlan = nRecurso.tipoPlan
                .idOrden = nRecurso.idOrden
                .Sustentado = nRecurso.Sustentado
            End With

            HeliosData.actividadRecurso.Add(objRecurso)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objRecurso.idActividadRecurso
        End Using
    End Function

    Public Function InsertSingleCotizacionLiquidacion(ByVal nRecurso As actividadRecurso, nLiquidacion As totalesLiquidacion) As Integer
        Dim liquidacionBL As New totalesLiquidacionBL
        Dim IdActividad As String
        Using ts As New TransactionScope
            IdActividad = InsertSingleCotizacion(nRecurso)
            liquidacionBL.SaveLiquidacionPreliminar(nLiquidacion, nRecurso.idActividadRecurso)
            HeliosData.SaveChanges()
            ts.Complete()
            Return IdActividad
        End Using
    End Function

    Public Function InsertSingleCotizacion(ByVal nRecurso As actividadRecurso) As Integer
        Dim objRecurso As New actividadRecurso
        Dim objRecursoCalculo As New actividadRecursoCalculo
        Dim ItemBL As New itemBL
        Dim IDItems As Integer
        Dim IDDetalleItem As Integer
        Dim DetalleItemBL As New detalleitemsBL
        Using ts As New TransactionScope

            If (nRecurso.TipoRecurso = "EX") Then
                IDItems = itemBL.InsertItemExcel(nRecurso.Idempresa, nRecurso.IdEstablecimiento, nRecurso.Clasificacion)
                IDDetalleItem = DetalleItemBL.InsertDetalleItemExcel(IDItems, nRecurso.Idempresa, nRecurso.IdEstablecimiento, nRecurso.Descripcion, nRecurso.idTipoExistencia, nRecurso.cuentaContable)

            Else
                IDDetalleItem = 0
            End If

            objRecurso = New actividadRecurso
            With objRecurso
                .Action = Business.Entity.BaseBE.EntityAction.INSERT
                .idProyecto = nRecurso.idProyecto
                .idActividad = nRecurso.idActividad
                .tipoActividad = nRecurso.tipoActividad
                .Idempresa = nRecurso.Idempresa
                .IdEstablecimiento = nRecurso.IdEstablecimiento
                .fechaIngreso = nRecurso.fechaIngreso
                .TipoRecurso = nRecurso.TipoRecurso
                .Descripcion = nRecurso.Descripcion
                .detalleExtra = nRecurso.detalleExtra
                .idItem = IDDetalleItem
                .unidadMedida = nRecurso.unidadMedida
                .cuentaContable = nRecurso.cuentaContable
                .tipoPlan = nRecurso.tipoPlan
                .ReferenciaSustento = nRecurso.ReferenciaSustento
                .ValorMercadoPu = nRecurso.ValorMercadoPu
                .CantRequerida = nRecurso.CantRequerida
                .TotalCosto = nRecurso.TotalCosto
                .OtrosDeduc = nRecurso.OtrosDeduc
                .DeducPlanilla = nRecurso.DeducPlanilla
                .TotalDeduc = nRecurso.TotalDeduc
                .NetoPagar = nRecurso.NetoPagar
                .Otros1 = nRecurso.Otros1
                .AporPlanilla = nRecurso.AporPlanilla
                .TotalAporte = nRecurso.TotalAporte
                .TotalRetenciones = nRecurso.TotalRetenciones
                .PorIgv = nRecurso.PorIgv
                .Costo = nRecurso.Costo
                .NoSustentado = nRecurso.NoSustentado
                .Porcentaje = nRecurso.Porcentaje
                .Igv = nRecurso.Igv
                .PsptoReferencial = nRecurso.PsptoReferencial
                .Total = nRecurso.Total
                .Sustentado = nRecurso.Sustentado
                .TipoPresupuesto = nRecurso.TipoPresupuesto
            End With

            objRecursoCalculo = New actividadRecursoCalculo
            With objRecursoCalculo
                '  .Action = ListaRecursoBE.Action
                .laborDiaria = nRecurso.actividadRecursoCalculo.laborDiaria
                .hm = nRecurso.actividadRecursoCalculo.hm
                .porcentaje = nRecurso.actividadRecursoCalculo.porcentaje
                .dias = nRecurso.actividadRecursoCalculo.dias
                .costoUnithh = nRecurso.actividadRecursoCalculo.costoUnithh
                .cant = nRecurso.actividadRecursoCalculo.cant
                .costoUnit = nRecurso.actividadRecursoCalculo.costoUnit
                .costoDirecto1 = nRecurso.actividadRecursoCalculo.costoDirecto1
                .costoDirecto2 = nRecurso.actividadRecursoCalculo.costoDirecto2
                .ggPorc = nRecurso.actividadRecursoCalculo.ggPorc
                .ggImporte = nRecurso.actividadRecursoCalculo.ggImporte
                .utPorc = nRecurso.actividadRecursoCalculo.utPorc
                .utImporte = nRecurso.actividadRecursoCalculo.utImporte
                .costoFinal = nRecurso.actividadRecursoCalculo.costoFinal
                .igvPorc = nRecurso.actividadRecursoCalculo.igvPorc
                .igvImporte = nRecurso.actividadRecursoCalculo.igvImporte
                .precioFinal = nRecurso.actividadRecursoCalculo.precioFinal
                .cantFinal = nRecurso.actividadRecursoCalculo.cantFinal
                .precUnitFinal = nRecurso.actividadRecursoCalculo.precUnitFinal
            End With
            objRecurso.actividadRecursoCalculo = objRecursoCalculo
            HeliosData.actividadRecurso.Add(objRecurso)
            HeliosData.SaveChanges()
            ts.Complete()
            Return objRecurso.idActividadRecurso
        End Using
    End Function

    Public Sub UpdateSingleCotizacionLiquidacion(ByVal nRecurso As actividadRecurso, ByVal nRecursoDelete As totalesLiquidacion, nLiquidacion As totalesLiquidacion)
        Dim liquidacionBL As New totalesLiquidacionBL
        Using ts As New TransactionScope
            liquidacionBL.UpdateLiquidacionPreliminar(nLiquidacion, nRecursoDelete, nRecurso.idActividadRecurso)
            UpdateSingleCotizacion(nRecurso)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub UpdateSingleCotizacion(ByVal nRecurso As actividadRecurso)
        Dim ItemBL As New itemBL
        Dim IDItems As Integer
        Dim IDDetalleItem As Integer
        Dim DetalleItemBL As New detalleitemsBL
        Using ts As New TransactionScope
            Dim objRecurso As actividadRecurso = HeliosData.actividadRecurso.Where(Function(o) o.idActividadRecurso = nRecurso.idActividadRecurso).First
            If (nRecurso.TipoRecurso = "EX") Then
                IDItems = ItemBL.InsertItemExcel(nRecurso.Idempresa, nRecurso.IdEstablecimiento, nRecurso.Clasificacion)
                IDDetalleItem = DetalleItemBL.InsertDetalleItemExcel(IDItems, nRecurso.Idempresa, nRecurso.IdEstablecimiento, nRecurso.Descripcion, nRecurso.idTipoExistencia, nRecurso.cuentaContable)
            Else
                IDDetalleItem = 0
            End If
            With objRecurso
                .Action = Business.Entity.BaseBE.EntityAction.UPDATE
                .fechaIngreso = nRecurso.fechaIngreso
                .idProyecto = nRecurso.idProyecto
                .idActividad = nRecurso.idActividad
                .tipoActividad = nRecurso.tipoActividad
                .Idempresa = nRecurso.Idempresa
                .idItem = IDDetalleItem
                .IdEstablecimiento = nRecurso.IdEstablecimiento
                .fechaIngreso = nRecurso.fechaIngreso
                .TipoRecurso = nRecurso.TipoRecurso
                .Descripcion = nRecurso.Descripcion
                .detalleExtra = nRecurso.detalleExtra
                .unidadMedida = nRecurso.unidadMedida
                .cuentaContable = nRecurso.cuentaContable
                .ReferenciaSustento = nRecurso.ReferenciaSustento
                .ValorMercadoPu = nRecurso.ValorMercadoPu
                .CantRequerida = nRecurso.CantRequerida
                .TotalCosto = nRecurso.TotalCosto
                .OtrosDeduc = nRecurso.OtrosDeduc
                .DeducPlanilla = nRecurso.DeducPlanilla
                .TotalDeduc = nRecurso.TotalDeduc
                .NetoPagar = nRecurso.NetoPagar
                .Otros1 = nRecurso.Otros1
                .AporPlanilla = nRecurso.AporPlanilla
                .TotalAporte = nRecurso.TotalAporte
                .TotalRetenciones = nRecurso.TotalRetenciones
                .PorIgv = nRecurso.PorIgv
                .Costo = nRecurso.Costo
                .NoSustentado = nRecurso.NoSustentado
                .Porcentaje = nRecurso.Porcentaje
                .Igv = nRecurso.Igv
                .PsptoReferencial = nRecurso.PsptoReferencial
                .Total = nRecurso.Total
                .tipoPlan = nRecurso.tipoPlan
                .Sustentado = nRecurso.Sustentado
                .TipoPresupuesto = nRecurso.TipoPresupuesto
            End With
            'HeliosData.ObjectStateManager.GetObjectStateEntry(objRecurso).State.ToString()
            Dim objRecursoCalculo As actividadRecursoCalculo = HeliosData.actividadRecursoCalculo.Where(Function(o) o.idActividadRecurso = nRecurso.idActividadRecurso).First
            With objRecursoCalculo
                '  .Action = ListaRecursoBE.Action
                .idActividadRecurso = nRecurso.idActividadRecurso
                .laborDiaria = nRecurso.actividadRecursoCalculo.laborDiaria
                .hm = nRecurso.actividadRecursoCalculo.hm
                .porcentaje = nRecurso.actividadRecursoCalculo.porcentaje
                .dias = nRecurso.actividadRecursoCalculo.dias
                .costoUnithh = nRecurso.actividadRecursoCalculo.costoUnithh
                .cant = nRecurso.actividadRecursoCalculo.cant
                .costoUnit = nRecurso.actividadRecursoCalculo.costoUnit
                .costoDirecto1 = nRecurso.actividadRecursoCalculo.costoDirecto1
                .costoDirecto2 = nRecurso.actividadRecursoCalculo.costoDirecto2
                .ggPorc = nRecurso.actividadRecursoCalculo.ggPorc
                .ggImporte = nRecurso.actividadRecursoCalculo.ggImporte
                .utPorc = nRecurso.actividadRecursoCalculo.utPorc
                .utImporte = nRecurso.actividadRecursoCalculo.utImporte
                .costoFinal = nRecurso.actividadRecursoCalculo.costoFinal
                .igvPorc = nRecurso.actividadRecursoCalculo.igvPorc
                .igvImporte = nRecurso.actividadRecursoCalculo.igvImporte
                .precioFinal = nRecurso.actividadRecursoCalculo.precioFinal
                .cantFinal = nRecurso.actividadRecursoCalculo.cantFinal
                .precUnitFinal = nRecurso.actividadRecursoCalculo.precUnitFinal
            End With
            'HeliosData.ObjectStateManager.GetObjectStateEntry(objRecursoCalculo).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub UpdateCotizacionFinal(ByVal ListaRecursoBE As List(Of actividadRecurso))
        Dim objRecurso As New actividadRecurso
        Dim objRecursoCalculo As New actividadRecursoCalculo
        Dim idActRecurso, idActividad As Integer
        Using ts As New TransactionScope
            For Each nrecurso In ListaRecursoBE
                idActRecurso = nrecurso.idActividadRecurso
                idActividad = nrecurso.idActividad
                Dim proyect As actividadRecurso = HeliosData.actividadRecurso.Where _
                                                  (Function(o) o.idActividadRecurso = idActRecurso _
                                                       And o.idActividad = idActividad).First()
                objRecurso = New actividadRecurso
                With proyect
                    .Action = Business.Entity.BaseBE.EntityAction.UPDATE
                    .idProyecto = nrecurso.idProyecto
                    .Sustentado = "1"
                End With
                'HeliosData.ObjectStateManager.GetObjectStateEntry(proyect).State.ToString()
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub UpdateSingleLiquidacionInciacion(ByVal nRecurso As actividadRecurso, ByVal nRecursoDelete As totalesLiquidacion, nLiquidacion As totalesLiquidacion)
        Dim liquidacionBL As New totalesLiquidacionBL
        Using ts As New TransactionScope

            ' liquidacionBL.DeleteLiquidacionModal(nRecursoDelete, nRecurso.idActividadRecurso)
            liquidacionBL.UpdateLiquidacionPreliminar(nLiquidacion, nRecursoDelete, nRecurso.idActividadRecurso)
            'OJO MIRAR ESO EN TODO LOS CASOS
            'If (nRecurso.tipoPlan = "A") Then
            UpdateSingleInciacion(nRecurso)
            'ElseIf (nRecurso.tipoPlan = "AP") Then
            '    InsertSingleIniciacacion(nRecurso)
            'End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub UpdateSingleInciacion(ByVal nRecurso As actividadRecurso)
        Dim ItemBL As New itemBL
        Dim IDItems As Integer
        Dim IDDetalleItem As Integer
        Dim DetalleItemBL As New detalleitemsBL
        Using ts As New TransactionScope
            '  HeliosData.actividadRecurso.Attach(nRecurso)
            Dim objRecurso As actividadRecurso = HeliosData.actividadRecurso.Where(Function(o) o.idActividadRecurso = nRecurso.idActividadRecurso).First
            If (nRecurso.TipoRecurso = "EX") Then
                IDItems = ItemBL.InsertItemExcel(nRecurso.Idempresa, nRecurso.IdEstablecimiento, nRecurso.Clasificacion)
                IDDetalleItem = DetalleItemBL.InsertDetalleItemExcel(IDItems, nRecurso.Idempresa, nRecurso.IdEstablecimiento, nRecurso.Descripcion, nRecurso.idTipoExistencia, nRecurso.cuentaContable)
            Else
                IDDetalleItem = 0
            End If
            objRecurso.fechaIngreso = nRecurso.fechaIngreso
            objRecurso.TipoRecurso = nRecurso.TipoRecurso
            objRecurso.cuentaContable = nRecurso.cuentaContable
            objRecurso.Descripcion = nRecurso.Descripcion
            objRecurso.detalleExtra = nRecurso.detalleExtra
            objRecurso.idItem = IDDetalleItem
            objRecurso.unidadMedida = nRecurso.unidadMedida
            objRecurso.ValorMercadoPu = nRecurso.ValorMercadoPu
            objRecurso.CantRequerida = nRecurso.CantRequerida
            objRecurso.TotalCosto = nRecurso.TotalCosto
            objRecurso.PsptoReferencial = nRecurso.PsptoReferencial
            objRecurso.ReferenciaSustento = nRecurso.ReferenciaSustento
            objRecurso.Costo = nRecurso.Costo
            objRecurso.NoSustentado = nRecurso.NoSustentado
            objRecurso.PorIgv = nRecurso.PorIgv
            objRecurso.Igv = nRecurso.Igv
            objRecurso.Total = nRecurso.Total
            objRecurso.PorDeducPlanilla = nRecurso.PorDeducPlanilla
            objRecurso.DeducPlanilla = nRecurso.DeducPlanilla
            objRecurso.PorOtrosDeduc = nRecurso.PorOtrosDeduc
            objRecurso.OtrosDeduc = nRecurso.OtrosDeduc
            objRecurso.TotalDeduc = nRecurso.TotalDeduc
            objRecurso.NetoPagar = nRecurso.NetoPagar
            objRecurso.PorAporPlanilla = nRecurso.PorAporPlanilla
            objRecurso.AporPlanilla = nRecurso.AporPlanilla
            objRecurso.PorOtros1 = nRecurso.PorOtros1
            objRecurso.Otros1 = nRecurso.Otros1
            objRecurso.TotalAporte = nRecurso.TotalAporte
            objRecurso.TotalRetenciones = nRecurso.TotalRetenciones
            objRecurso.PorImpor1 = nRecurso.PorImpor1
            objRecurso.Impor1 = nRecurso.Impor1
            objRecurso.PorImpor2 = nRecurso.PorImpor2
            objRecurso.Impor2 = nRecurso.Impor2
            objRecurso.TotalImpor = nRecurso.TotalImpor
            objRecurso.TipoPresupuesto = nRecurso.TipoPresupuesto
            objRecurso.CostoDirecto = nRecurso.CostoDirecto
            objRecurso.PorGastosGenerales = nRecurso.PorGastosGenerales
            objRecurso.GastosGenerales = nRecurso.GastosGenerales
            objRecurso.PorOtrosIn1 = nRecurso.PorOtrosIn1
            objRecurso.OtrosIn1 = nRecurso.OtrosIn1
            objRecurso.ValorVenta = nRecurso.ValorVenta
            objRecurso.Porcentaje = nRecurso.Porcentaje
            objRecurso.TotalProyecto = nRecurso.TotalProyecto
            objRecurso.PorPercep = nRecurso.PorPercep
            objRecurso.Percepciones = nRecurso.Percepciones
            objRecurso.PorOtrosIn2 = nRecurso.PorOtrosIn2
            objRecurso.OtrosIn2 = nRecurso.OtrosIn2
            objRecurso.TotalPorCobrar = nRecurso.TotalPorCobrar
            objRecurso.PorDetracciones = nRecurso.PorDetracciones
            objRecurso.Detracciones = nRecurso.Detracciones
            objRecurso.PorRetenciones = nRecurso.PorRetenciones
            objRecurso.Retenciones = nRecurso.Retenciones
            objRecurso.PorOtroIn3 = nRecurso.PorOtroIn3
            objRecurso.OtroIn3 = nRecurso.OtroIn3
            objRecurso.NetoCobrar = nRecurso.NetoCobrar
            objRecurso.PorcentajeIngre = nRecurso.PorcentajeIngre
            objRecurso.TipoIncidencia = nRecurso.TipoIncidencia
            objRecurso.tipoPlan = nRecurso.tipoPlan
            objRecurso.idOrden = nRecurso.idOrden
            objRecurso.Sustentado = nRecurso.Sustentado

            'HeliosData.ObjectStateManager.GetObjectStateEntry(objRecurso).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub UpdateSingleLiquidacion(ByVal nRecurso As actividadRecurso, ByVal nRecursoDelete As totalesLiquidacion, nLiquidacion As totalesLiquidacion)
        Dim liquidacionBL As New totalesLiquidacionBL
        Using ts As New TransactionScope

            ' liquidacionBL.DeleteLiquidacionModal(nRecursoDelete, nRecurso.idActividadRecurso)
            liquidacionBL.UpdateLiquidacionPreliminar(nLiquidacion, nRecursoDelete, nRecurso.idActividadRecurso)
            UpdateSingle(nRecurso)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub UpdateSingle(ByVal nRecurso As actividadRecurso)
        Dim ItemBL As New itemBL
        Dim IDItems As Integer
        Dim IDDetalleItem As Integer
        Dim DetalleItemBL As New detalleitemsBL
        Using ts As New TransactionScope
            '  HeliosData.actividadRecurso.Attach(nRecurso)
            Dim objRecurso As actividadRecurso = HeliosData.actividadRecurso.Where(Function(o) o.idActividadRecurso = nRecurso.idActividadRecurso).First
            If (nRecurso.TipoRecurso = "EX") Then
                IDItems = ItemBL.InsertItemExcel(nRecurso.Idempresa, nRecurso.IdEstablecimiento, nRecurso.Clasificacion)
                IDDetalleItem = DetalleItemBL.InsertDetalleItemExcel(IDItems, nRecurso.Idempresa, nRecurso.IdEstablecimiento, nRecurso.Descripcion, nRecurso.idTipoExistencia, nRecurso.cuentaContable)
            Else
                IDDetalleItem = 0
            End If
            objRecurso.fechaIngreso = nRecurso.fechaIngreso
            objRecurso.TipoRecurso = nRecurso.TipoRecurso
            objRecurso.cuentaContable = nRecurso.cuentaContable
            objRecurso.Descripcion = nRecurso.Descripcion
            objRecurso.detalleExtra = nRecurso.detalleExtra
            objRecurso.idItem = IDDetalleItem
            objRecurso.unidadMedida = nRecurso.unidadMedida
            objRecurso.ValorMercadoPu = nRecurso.ValorMercadoPu
            objRecurso.CantRequerida = nRecurso.CantRequerida
            objRecurso.TotalCosto = nRecurso.TotalCosto
            objRecurso.PsptoReferencial = nRecurso.PsptoReferencial
            objRecurso.ReferenciaSustento = nRecurso.ReferenciaSustento
            objRecurso.Costo = nRecurso.Costo
            objRecurso.NoSustentado = nRecurso.NoSustentado
            objRecurso.PorIgv = nRecurso.PorIgv
            objRecurso.Igv = nRecurso.Igv
            objRecurso.Total = nRecurso.Total
            objRecurso.PorDeducPlanilla = nRecurso.PorDeducPlanilla
            objRecurso.DeducPlanilla = nRecurso.DeducPlanilla
            objRecurso.PorOtrosDeduc = nRecurso.PorOtrosDeduc
            objRecurso.OtrosDeduc = nRecurso.OtrosDeduc
            objRecurso.TotalDeduc = nRecurso.TotalDeduc
            objRecurso.NetoPagar = nRecurso.NetoPagar
            objRecurso.PorAporPlanilla = nRecurso.PorAporPlanilla
            objRecurso.AporPlanilla = nRecurso.AporPlanilla
            objRecurso.PorOtros1 = nRecurso.PorOtros1
            objRecurso.Otros1 = nRecurso.Otros1
            objRecurso.TotalAporte = nRecurso.TotalAporte
            objRecurso.TotalRetenciones = nRecurso.TotalRetenciones
            objRecurso.PorImpor1 = nRecurso.PorImpor1
            objRecurso.Impor1 = nRecurso.Impor1
            objRecurso.PorImpor2 = nRecurso.PorImpor2
            objRecurso.Impor2 = nRecurso.Impor2
            objRecurso.TotalImpor = nRecurso.TotalImpor
            objRecurso.TipoPresupuesto = nRecurso.TipoPresupuesto
            objRecurso.CostoDirecto = nRecurso.CostoDirecto
            objRecurso.PorGastosGenerales = nRecurso.PorGastosGenerales
            objRecurso.GastosGenerales = nRecurso.GastosGenerales
            objRecurso.PorUtilidad = nRecurso.Utilidad
            objRecurso.PorOtrosIn1 = nRecurso.PorOtrosIn1
            objRecurso.OtrosIn1 = nRecurso.OtrosIn1
            objRecurso.ValorVenta = nRecurso.ValorVenta
            objRecurso.Porcentaje = nRecurso.Porcentaje
            objRecurso.TotalProyecto = nRecurso.TotalProyecto
            objRecurso.PorPercep = nRecurso.PorPercep
            objRecurso.Percepciones = nRecurso.Percepciones
            objRecurso.PorOtrosIn2 = nRecurso.PorOtrosIn2
            objRecurso.OtrosIn2 = nRecurso.OtrosIn2
            objRecurso.TotalPorCobrar = nRecurso.TotalPorCobrar
            objRecurso.PorDetracciones = nRecurso.PorDetracciones
            objRecurso.Detracciones = nRecurso.Detracciones
            objRecurso.PorRetenciones = nRecurso.PorRetenciones
            objRecurso.Retenciones = nRecurso.Retenciones
            objRecurso.PorOtroIn3 = nRecurso.PorOtroIn3
            objRecurso.OtroIn3 = nRecurso.OtroIn3
            objRecurso.NetoCobrar = nRecurso.NetoCobrar
            objRecurso.PorcentajeIngre = nRecurso.PorcentajeIngre
            objRecurso.TipoIncidencia = nRecurso.TipoIncidencia
            objRecurso.tipoPlan = nRecurso.tipoPlan
            objRecurso.idOrden = nRecurso.idOrden
            objRecurso.Sustentado = nRecurso.Sustentado

            'HeliosData.ObjectStateManager.GetObjectStateEntry(objRecurso).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub UpdateSingleSteptoStep(ByVal nRecurso As actividadRecurso)
        Using ts As New TransactionScope
            HeliosData.actividadRecurso.Attach(nRecurso)
            HeliosData.Entry(nRecurso).State = System.Data.Entity.EntityState.Modified
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub DeleteSingle(ByVal nRecurso As actividadRecurso)
        Using ts As New TransactionScope
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(nRecurso)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertLista(ByVal ListaRecursoBE As List(Of actividadRecurso), ByVal ListaGastoBE As List(Of actividadRecurso))
        'Dim productoBL As New detalleitemsBL
        'Dim nProducto As New detalleitems
        Dim objRecurso As New actividadRecurso
        Dim objRecursoGasto As New actividadRecurso
        Dim objRecursoCalculo As New actividadRecursoCalculo
        Dim TablaDetalleBL As New tabladetalleBL
        Dim ItemBL As New itemBL
        Dim IDItems As Integer
        Dim IDTablaDetalle As Integer
        Dim IDDetalleItem As Integer
        Dim DetalleItemBL As New detalleitemsBL
        Using ts As New TransactionScope
            For Each RecursoBE In ListaRecursoBE

                IDTablaDetalle = TablaDetalleBL.InsertTablaDetalleExcel(RecursoBE.unidadMedida)
                If (RecursoBE.TipoRecurso = "EX") Then
                    IDItems = ItemBL.InsertItemExcel(RecursoBE.Idempresa, RecursoBE.IdEstablecimiento, RecursoBE.Clasificacion)
                    IDDetalleItem = DetalleItemBL.InsertDetalleItemExcel(IDItems, RecursoBE.Idempresa, RecursoBE.IdEstablecimiento, RecursoBE.Descripcion, RecursoBE.idTipoExistencia, RecursoBE.cuentaContable)
                Else
                    IDDetalleItem = 0
                End If

                objRecurso = New actividadRecurso

                With objRecurso
                    .Action = Business.Entity.BaseBE.EntityAction.INSERT
                    .idProyecto = RecursoBE.idProyecto
                    .idActividad = RecursoBE.idActividad
                    .tipoActividad = RecursoBE.tipoActividad
                    .Idempresa = RecursoBE.Idempresa
                    .IdEstablecimiento = RecursoBE.IdEstablecimiento
                    .fechaIngreso = RecursoBE.fechaIngreso
                    .TipoRecurso = RecursoBE.TipoRecurso
                    .Descripcion = RecursoBE.Descripcion
                    .detalleExtra = RecursoBE.detalleExtra
                    .unidadMedida = IDTablaDetalle
                    .idItem = IDDetalleItem
                    .cuentaContable = RecursoBE.cuentaContable
                    .ValorMercadoPu = RecursoBE.ValorMercadoPu
                    .CantRequerida = RecursoBE.CantRequerida
                    .TotalCosto = RecursoBE.TotalCosto
                    .OtrosDeduc = RecursoBE.OtrosDeduc
                    .DeducPlanilla = RecursoBE.DeducPlanilla
                    .TotalDeduc = RecursoBE.TotalDeduc
                    .NetoPagar = RecursoBE.NetoPagar
                    .Otros1 = RecursoBE.Otros1
                    .AporPlanilla = RecursoBE.AporPlanilla
                    .TotalAporte = RecursoBE.TotalAporte
                    .TotalRetenciones = RecursoBE.TotalRetenciones
                    .PorIgv = RecursoBE.PorIgv
                    .Costo = RecursoBE.Costo
                    .NoSustentado = RecursoBE.NoSustentado
                    .Porcentaje = RecursoBE.Porcentaje
                    .Igv = RecursoBE.Igv
                    .PsptoReferencial = RecursoBE.PsptoReferencial
                    .Costo = RecursoBE.Costo
                    .TipoPresupuesto = RecursoBE.TipoPresupuesto
                    .Total = RecursoBE.Total
                    .tipoPlan = RecursoBE.tipoPlan
                    .Sustentado = RecursoBE.Sustentado
                    .ReferenciaSustento = RecursoBE.ReferenciaSustento
                End With

                objRecursoCalculo = New actividadRecursoCalculo
                With objRecursoCalculo
                    '  .Action = ListaRecursoBE.Action
                    .laborDiaria = RecursoBE.actividadRecursoCalculo.laborDiaria
                    .hm = RecursoBE.actividadRecursoCalculo.hm
                    .porcentaje = RecursoBE.actividadRecursoCalculo.porcentaje
                    .dias = RecursoBE.actividadRecursoCalculo.dias
                    .costoUnithh = RecursoBE.actividadRecursoCalculo.costoUnithh
                    .cant = RecursoBE.actividadRecursoCalculo.cant
                    .costoUnit = RecursoBE.actividadRecursoCalculo.costoUnit
                    .costoDirecto1 = RecursoBE.actividadRecursoCalculo.costoDirecto1
                    .costoDirecto2 = RecursoBE.actividadRecursoCalculo.costoDirecto2
                    .ggPorc = RecursoBE.actividadRecursoCalculo.ggPorc
                    .ggImporte = RecursoBE.actividadRecursoCalculo.ggImporte
                    .utPorc = RecursoBE.actividadRecursoCalculo.utPorc
                    .utImporte = RecursoBE.actividadRecursoCalculo.utImporte
                    .costoFinal = RecursoBE.actividadRecursoCalculo.costoFinal
                    .igvPorc = RecursoBE.actividadRecursoCalculo.igvPorc
                    .igvImporte = RecursoBE.actividadRecursoCalculo.igvImporte
                    .precioFinal = RecursoBE.actividadRecursoCalculo.precioFinal
                    .cantFinal = RecursoBE.actividadRecursoCalculo.cantFinal
                    .precUnitFinal = RecursoBE.actividadRecursoCalculo.precUnitFinal
                End With
                objRecurso.actividadRecursoCalculo = objRecursoCalculo
                HeliosData.actividadRecurso.Add(objRecurso)
            Next

            For Each RecursoGastoBE In ListaGastoBE

                IDTablaDetalle = TablaDetalleBL.InsertTablaDetalleExcel(RecursoGastoBE.unidadMedida)
                If (RecursoGastoBE.TipoRecurso = "EX") Then
                    IDItems = ItemBL.InsertItemExcel(RecursoGastoBE.Idempresa, RecursoGastoBE.IdEstablecimiento, RecursoGastoBE.Clasificacion)
                    IDDetalleItem = DetalleItemBL.InsertDetalleItemExcel(IDItems, RecursoGastoBE.Idempresa, RecursoGastoBE.IdEstablecimiento, RecursoGastoBE.Descripcion, RecursoGastoBE.idTipoExistencia, RecursoGastoBE.cuentaContable)
                Else
                    IDDetalleItem = 0
                End If
                objRecursoGasto = New actividadRecurso
                With objRecursoGasto
                    .Action = Business.Entity.BaseBE.EntityAction.INSERT
                    .idProyecto = RecursoGastoBE.idProyecto
                    .idActividad = RecursoGastoBE.idActividad
                    .tipoActividad = RecursoGastoBE.tipoActividad
                    .Idempresa = RecursoGastoBE.Idempresa
                    .IdEstablecimiento = RecursoGastoBE.IdEstablecimiento
                    .fechaIngreso = RecursoGastoBE.fechaIngreso
                    .TipoRecurso = RecursoGastoBE.TipoRecurso
                    .cuentaContable = RecursoGastoBE.cuentaContable
                    .Descripcion = RecursoGastoBE.Descripcion
                    .detalleExtra = RecursoGastoBE.detalleExtra
                    .unidadMedida = IDTablaDetalle
                    .idItem = IDDetalleItem
                    .ValorMercadoPu = RecursoGastoBE.ValorMercadoPu
                    .CantRequerida = RecursoGastoBE.CantRequerida
                    .TotalCosto = RecursoGastoBE.TotalCosto
                    .OtrosDeduc = 0
                    .DeducPlanilla = 0
                    .TotalDeduc = 0
                    .NetoPagar = RecursoGastoBE.NetoPagar
                    .Otros1 = 0
                    .AporPlanilla = 0
                    .TotalAporte = 0
                    .TotalRetenciones = 0

                    .ReferenciaSustento = RecursoGastoBE.ReferenciaSustento
                    .PorIgv = RecursoGastoBE.PorIgv
                    .Costo = RecursoGastoBE.Costo
                    .NoSustentado = RecursoGastoBE.NoSustentado
                    .Porcentaje = RecursoGastoBE.Porcentaje
                    .Igv = RecursoGastoBE.Igv
                    .PsptoReferencial = 0
                    .Total = RecursoGastoBE.Total
                    .tipoPlan = RecursoGastoBE.tipoPlan
                    .Sustentado = RecursoGastoBE.Sustentado
                    .TipoPresupuesto = RecursoGastoBE.TipoPresupuesto
                End With
                HeliosData.actividadRecurso.Add(objRecursoGasto)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetListaCotizacionAndGastoFinal(intIDProyecto As Integer, strTipoRecurso As String, strSustentado As String) 'As List(Of actividadRecurso)
        Dim consulta As New List(Of actividadRecurso)
        Dim listTipoRecurso As New List(Of String)()
        listTipoRecurso.Add("EX")
        listTipoRecurso.Add("GS")
        listTipoRecurso.Add("RH")
        Dim objRecurso As New actividadRecurso
        Dim consulta2 = (From a In HeliosData.actividadRecurso _
                        Group Join calculo In HeliosData.actividadRecursoCalculo _
                        On a.idActividadRecurso Equals calculo.idActividadRecurso _
                        Into ords = Group _
                        From e In ords.DefaultIfEmpty _
                        Where a.idActividad = intIDProyecto _
                        And a.tipoPlan = strTipoRecurso _
                        And listTipoRecurso.Contains(a.TipoRecurso) _
                        And a.Sustentado = strSustentado _
                        Select New With {.fechaIngreso = a.fechaIngreso,
                                         .idActividad = a.idActividad,
                                         .idActividadRecurso = a.idActividadRecurso,
                                         .Descripcion = a.Descripcion,
                                        .DetalleExtra = a.detalleExtra,
                                         .unidadMedida = a.unidadMedida,
                                         .Cant = a.CantRequerida,
                                        .CostoUnit = a.ValorMercadoPu,
                                        .igvImporte = a.Igv,
                                         .precioFinal = a.Total,
                                         .ReferenciaSustento = a.ReferenciaSustento,
                                         .Total = a.Total,
                                         .IdItem = a.idItem}).ToList
        For Each obj In consulta2
            objRecurso = New actividadRecurso With _
                               {
                                    .fechaIngreso = obj.fechaIngreso, _
                                   .idActividadRecurso = obj.idActividadRecurso, _
                                   .idActividad = obj.idActividad, _
                                .Descripcion = obj.Descripcion, _
                                .detalleExtra = obj.DetalleExtra, _
                               .unidadMedida = obj.unidadMedida, _
                                   .cant = obj.Cant, _
                                .costoUnit = obj.CostoUnit, _
                                .igvImporte = obj.igvImporte, _
                                .precioFinal = obj.precioFinal, _
                                    .ReferenciaSustento = obj.ReferenciaSustento, _
                                    .Total = obj.Total, _
                                    .idItem = obj.IdItem
                                 }
            consulta.Add(objRecurso)
        Next

        Return consulta
    End Function

    Public Function GetListaGastosFinal(intIDProyecto As Integer, strTipoRecurso As String, strSustentado As String) 'As List(Of actividadRecurso)
        Dim consulta As New List(Of actividadRecurso)
        Dim objRecurso As New actividadRecurso
        Dim listTipoRecurso As New List(Of String)()
        listTipoRecurso.Add("EX")
        listTipoRecurso.Add("GS")
        listTipoRecurso.Add("RH")
        listTipoRecurso.Add("K")
        Dim consulta2 = (From a In HeliosData.actividadRecurso _
                        Where a.idActividad = intIDProyecto _
                        And listTipoRecurso.Contains(a.TipoRecurso) _
                        And a.Sustentado = strSustentado _
                        And a.tipoPlan = strTipoRecurso _
                        Select New With {.fechaIngreso = a.fechaIngreso,
                                         .idActividad = a.idActividad,
                                         .idActividadRecurso = a.idActividadRecurso,
                                         .Descripcion = a.Descripcion,
                                         .tipoRecurso = a.TipoRecurso,
                                        .DetalleExtra = a.detalleExtra,
                                         .unidadMedida = a.unidadMedida,
                                         .Cant = a.CantRequerida,
                                        .CostoUnit = a.ValorMercadoPu,
                                         .Importeigv = a.Igv,
                                       .precioFinal = a.NetoPagar,
                                         .ReferenciaSustento = a.ReferenciaSustento,
                                         .Toral = a.Total}).ToList
        For Each obj In consulta2
            objRecurso = New actividadRecurso With _
                               {
                                   .fechaIngreso = obj.fechaIngreso, _
                                   .idActividadRecurso = obj.idActividadRecurso, _
                                   .idActividad = obj.idActividad, _
                                .Descripcion = obj.Descripcion, _
                                   .TipoRecurso = obj.tipoRecurso, _
                                .detalleExtra = obj.DetalleExtra, _
                                 .unidadMedida = obj.unidadMedida, _
                                   .CantRequerida = obj.Cant, _
                                .ValorMercadoPu = obj.CostoUnit, _
                                   .Igv = obj.Importeigv, _
                                .NetoPagar = obj.precioFinal, _
                                   .ReferenciaSustento = obj.ReferenciaSustento, _
                                   .Total = obj.Toral}
            consulta.Add(objRecurso)
        Next

        Return consulta
    End Function

    Public Function GetListaCotizacionAndGasto(intIDProyecto As Integer, strSustento As String, strTipoPlan As String) 'As List(Of actividadRecurso)
        Dim consulta As New List(Of actividadRecurso)
        Dim listTipoRecurso As New List(Of String)()
        listTipoRecurso.Add("EX")
        listTipoRecurso.Add("GS")
        listTipoRecurso.Add("RH")
        'listTipoRecurso.Add("PRS")
        Dim objRecurso As New actividadRecurso

        If (strTipoPlan = "A") Then
            Dim consulta2 = (From a In HeliosData.actividadRecurso _
                                   Group Join calculo In HeliosData.actividadRecursoCalculo _
                                   On a.idActividadRecurso Equals calculo.idActividadRecurso _
                                   Into ords = Group _
                                   From e In ords.DefaultIfEmpty _
                                   Group Join d In HeliosData.detalleitems _
                                   On a.idItem Equals d.codigodetalle _
                                    Into ords2 = Group _
                                   From dt In ords2.DefaultIfEmpty _
                                   Group Join i In HeliosData.item _
                                   On dt.idItem Equals i.idItem _
                                   Into ords3 = Group _
                                   From it In ords3.DefaultIfEmpty _
                                   Where a.idActividad = intIDProyecto _
                                   And a.tipoPlan = strTipoPlan _
                                   And a.Sustentado = strSustento _
                                   And listTipoRecurso.Contains(a.TipoRecurso) _
                                   Select New With {.fechaIngreso = a.fechaIngreso,
                                                    .idActividad = a.idActividad,
                                                    .idActividadRecurso = a.idActividadRecurso,
                                                    .Descripcion = a.Descripcion,
                                                   .DetalleExtra = a.detalleExtra,
                                                    .unidadMedida = a.unidadMedida,
                                                   .ReferenciaSustento = a.ReferenciaSustento,
                                                   .LaborDiaria = e.laborDiaria,
                                                   .CantHM = e.hm,
                                                   .Porcentaje = e.porcentaje,
                                                   .dias = e.dias,
                                                   .CostoUnithh = e.costoUnithh,
                                                   .Cant = e.cant,
                                                   .CostoUnit = e.costoUnit,
                                                   .CostoDirecto1 = e.costoDirecto1,
                                                   .CostoDirecto2 = e.costoDirecto2,
                                                    .ggPorc = e.ggPorc,
                                                    .ggImporte = e.ggImporte,
                                                    .utPoc = e.utPorc,
                                                    .utImporte = e.utImporte,
                                                    .CostoFinal = e.costoFinal,
                                                    .igvPorc = e.igvPorc,
                                                    .igvImporte = e.igvImporte,
                                                    .precioFinal = e.precioFinal,
                                                    .cantFinal = e.cantFinal,
                   .precUnitFinal = e.precUnitFinal,
                                                   .clasificacion = it.descripcion
                                                    }).ToList
            For Each obj In consulta2
                objRecurso = New actividadRecurso With _
                                   {
                                       .fechaIngreso = obj.fechaIngreso, _
                                       .idActividadRecurso = obj.idActividadRecurso, _
                                       .idActividad = obj.idActividad, _
                                    .Descripcion = obj.Descripcion, _
                                    .detalleExtra = obj.DetalleExtra, _
                                    .ReferenciaSustento = obj.ReferenciaSustento, _
                                       .unidadMedida = obj.unidadMedida, _
                                    .laborDiaria = obj.LaborDiaria, _
                                    .hm = obj.CantHM, _
                                    .porcentaje2 = obj.Porcentaje, _
                                    .dias = obj.dias, _
                                    .costoUnithh = obj.CostoUnithh, _
                                    .cant = obj.Cant, _
                                    .costoUnit = obj.CostoUnit, _
                                    .costoDirecto1 = obj.CostoDirecto1, _
                                    .costoDirecto2 = obj.CostoDirecto2, _
                                    .ggPorc = obj.ggPorc, _
                                    .ggImporte = obj.ggImporte, _
                                    .utPorc = obj.utPoc, _
                                    .utImporte = obj.utImporte, _
                                    .costoFinal = obj.CostoFinal, _
                                    .igvPorc = obj.igvPorc, _
                                    .igvImporte = obj.igvImporte, _
                                    .precioFinal = obj.precioFinal, _
                                    .cantFinal = obj.cantFinal, _
                                    .precUnitFinal = obj.precUnitFinal, _
                                        .Clasificacion = obj.clasificacion}
                consulta.Add(objRecurso)
            Next
        Else
            Dim consulta2 = (From a In HeliosData.actividadRecurso _
                       Group Join calculo In HeliosData.actividadRecursoCalculo _
                       On a.idActividadRecurso Equals calculo.idActividadRecurso _
                       Into ords = Group _
                       From e In ords.DefaultIfEmpty _
                           Group Join d In HeliosData.detalleitems _
                                   On a.idItem Equals d.codigodetalle _
                                    Into ords2 = Group _
                                   From dt In ords2.DefaultIfEmpty _
                                   Group Join i In HeliosData.item _
                                   On dt.idItem Equals i.idItem _
                                   Into ords3 = Group _
                                   From it In ords3.DefaultIfEmpty _
                       Where a.idActividad = intIDProyecto _
                       And a.tipoPlan = strTipoPlan _
                       And a.Sustentado = strSustento _
                       And listTipoRecurso.Contains(a.TipoRecurso) _
                       Select New With {.fechaIngreso = a.fechaIngreso,
                                        .idActividad = a.idActividad,
                                        .idActividadRecurso = a.idActividadRecurso,
                                        .Descripcion = a.Descripcion,
                                       .DetalleExtra = a.detalleExtra,
                                        .unidadMedida = a.unidadMedida,
                                       .ReferenciaSustento = a.ReferenciaSustento,
                                       .LaborDiaria = e.laborDiaria,
                                       .CantHM = e.hm,
                                       .Porcentaje = e.porcentaje,
                                       .dias = e.dias,
                                       .CostoUnithh = e.costoUnithh,
                                       .Cant = e.cant,
                                       .CostoUnit = e.costoUnit,
                                       .CostoDirecto1 = e.costoDirecto1,
                                       .CostoDirecto2 = e.costoDirecto2,
                                        .ggPorc = e.ggPorc,
                                        .ggImporte = e.ggImporte,
                                        .utPoc = e.utPorc,
                                        .utImporte = e.utImporte,
                                        .CostoFinal = e.costoFinal,
                                        .igvPorc = e.igvPorc,
                                        .igvImporte = e.igvImporte,
                                        .precioFinal = e.precioFinal,
                                        .cantFinal = e.cantFinal,
       .precUnitFinal = e.precUnitFinal,
                                        .clasificacion = it.descripcion
                                        }).ToList
            For Each obj In consulta2
                objRecurso = New actividadRecurso With _
                                   {
                                       .fechaIngreso = obj.fechaIngreso, _
                                       .idActividadRecurso = obj.idActividadRecurso, _
                                       .idActividad = obj.idActividad, _
                                    .Descripcion = obj.Descripcion, _
                                    .detalleExtra = obj.DetalleExtra, _
                                    .ReferenciaSustento = obj.ReferenciaSustento, _
                                       .unidadMedida = obj.unidadMedida, _
                                    .laborDiaria = obj.LaborDiaria, _
                                    .hm = obj.CantHM, _
                                    .porcentaje2 = obj.Porcentaje, _
                                    .dias = obj.dias, _
                                    .costoUnithh = obj.CostoUnithh, _
                                    .cant = obj.Cant, _
                                    .costoUnit = obj.CostoUnit, _
                                    .costoDirecto1 = obj.CostoDirecto1, _
                                    .costoDirecto2 = obj.CostoDirecto2, _
                                    .ggPorc = obj.ggPorc, _
                                    .ggImporte = obj.ggImporte, _
                                    .utPorc = obj.utPoc, _
                                    .utImporte = obj.utImporte, _
                                    .costoFinal = obj.CostoFinal, _
                                    .igvPorc = obj.igvPorc, _
                                    .igvImporte = obj.igvImporte, _
                                    .precioFinal = obj.precioFinal, _
                                    .cantFinal = obj.cantFinal, _
                                    .precUnitFinal = obj.precUnitFinal, _
                                       .Clasificacion = obj.clasificacion
                                     }
                consulta.Add(objRecurso)
            Next
        End If
        Return consulta
    End Function

    Public Function GetListaGastoPreliminar(intIDProyecto As Integer, strSustento As String, strTipoPresupuesto As String, strTipoPlan As String) 'As List(Of actividadRecurso)
        Dim consulta As New List(Of actividadRecurso)
        Dim objRecurso As New actividadRecurso
        Dim listTipoRecurso As New List(Of String)()
        listTipoRecurso.Add("EX")
        listTipoRecurso.Add("GS")
        listTipoRecurso.Add("RH")
        Dim consulta2 = (From a In HeliosData.actividadRecurso _
                        Group Join calculo In HeliosData.actividadRecursoCalculo _
                        On a.idActividadRecurso Equals calculo.idActividadRecurso _
                        Into ords = Group _
                        From e In ords.DefaultIfEmpty _
                        Group Join d In HeliosData.detalleitems _
                        On a.idItem Equals d.codigodetalle _
                        Into ords2 = Group _
                        From dt In ords2.DefaultIfEmpty _
                        Group Join i In HeliosData.item _
                        On dt.idItem Equals i.idItem _
                        Into ords3 = Group _
                        From it In ords3.DefaultIfEmpty _
                        Where a.idActividad = intIDProyecto _
                        And a.TipoPresupuesto = strTipoPresupuesto _
                        And a.tipoPlan = strTipoPlan _
                        And listTipoRecurso.Contains(a.TipoRecurso) _
                        And a.Sustentado = strSustento _
                        Select New With {.IdActividadRecurso = a.idActividadRecurso,
                                         .idActividad = a.idActividad,
                                         .fechaIngreso = a.fechaIngreso,
                                         .Descripcion = a.Descripcion,
                                        .DetalleExtra = a.detalleExtra,
                                         .tipoRecurso = a.TipoRecurso,
                                         .unidadMedida = a.unidadMedida,
                                        .ReferenciaSustento = a.ReferenciaSustento,
                                        .ValorMercado = a.ValorMercadoPu,
                                         .cantRequerida = a.CantRequerida,
                                         .TotalCosto = a.TotalCosto,
                                         .PstoRef = a.PsptoReferencial,
                                         .Costo = a.Costo,
                                         .NoSustentado = a.NoSustentado,
                                         .porcentaje = a.Porcentaje,
                                         .PorIgv = a.PorIgv,
                                         .Igv = a.Igv,
                                         .total = a.Total,
                                         .OtrosDeduc = a.OtrosDeduc,
                                         .DeducPlanilla = a.DeducPlanilla,
                                         .TotalDeduc = a.TotalDeduc,
                                         .NetoPagar = a.NetoPagar,
                                         .AporPlanilla = a.AporPlanilla,
                                         .otros1 = a.Otros1,
                                         .TotalAporte = a.TotalAporte,
                                         .TotalRetenciones = a.TotalRetenciones,
                                         .Tipopresupuesto = a.TipoPresupuesto,
                                         .clasificacion = it.descripcion}).ToList
        For Each obj In consulta2
            objRecurso = New actividadRecurso With _
                               {
                                   .idActividadRecurso = obj.IdActividadRecurso, _
                                   .idActividad = obj.idActividad, _
                                   .fechaIngreso = obj.fechaIngreso, _
                                   .Descripcion = obj.Descripcion, _
                                   .detalleExtra = obj.DetalleExtra, _
                                   .TipoRecurso = obj.tipoRecurso, _
                                   .unidadMedida = obj.unidadMedida, _
                                   .ReferenciaSustento = obj.ReferenciaSustento, _
                                   .ValorMercadoPu = obj.ValorMercado,
                                   .CantRequerida = obj.cantRequerida,
                                   .TotalCosto = obj.TotalCosto,
                                   .PsptoReferencial = obj.PstoRef,
                                   .Costo = obj.Costo,
                                   .NoSustentado = obj.NoSustentado,
                                   .Porcentaje = obj.porcentaje,
                                   .PorIgv = obj.PorIgv,
                                   .Igv = obj.Igv,
                                   .Total = obj.total,
                                   .OtrosDeduc = obj.OtrosDeduc,
                                   .DeducPlanilla = obj.DeducPlanilla,
                                   .TotalDeduc = obj.TotalDeduc,
                                   .NetoPagar = obj.NetoPagar,
                                   .AporPlanilla = obj.AporPlanilla,
                                   .Otros1 = obj.otros1,
                                   .TotalAporte = obj.TotalAporte,
                                   .TotalRetenciones = obj.TotalRetenciones,
                                   .TipoPresupuesto = obj.Tipopresupuesto,
                                   .Clasificacion = obj.clasificacion
                               }
            consulta.Add(objRecurso)
        Next

        Return consulta
    End Function

    Public Function GetListaGastoPreliminarLista(intIDProyecto As Integer, strTipoRecurso As String, strTipoPresupuesto As String) 'As List(Of actividadRecurso)
        Dim consulta As New List(Of actividadRecurso)
        Dim objRecurso As New actividadRecurso
        Dim consulta2 = (From a In HeliosData.actividadRecurso _
                        Where a.idProyecto = intIDProyecto _
                        And a.TipoPresupuesto = strTipoPresupuesto _
                        And a.TipoRecurso <> "PRS" _
                        Select New With {.IdActividadRecurso = a.idActividadRecurso,
                                         .idActividad = a.idActividad,
                                         .fechaIngreso = a.fechaIngreso,
                                         .Descripcion = a.Descripcion,
                                        .DetalleExtra = a.detalleExtra,
                                         .tipoRecurso = a.TipoRecurso,
                                         .unidadMedida = a.unidadMedida,
                                        .ReferenciaSustento = a.ReferenciaSustento,
                                        .ValorMercado = a.ValorMercadoPu,
                                         .cantRequerida = a.CantRequerida,
                                         .TotalCosto = a.TotalCosto,
                                         .PstoRef = a.PsptoReferencial,
                                         .Costo = a.Costo,
                                         .NoSustentado = a.NoSustentado,
                                         .porcentaje = a.Porcentaje,
                                         .PorIgv = a.PorIgv,
                                         .Igv = a.Igv,
                                         .total = a.Total,
                                         .OtrosDeduc = a.OtrosDeduc,
                                         .DeducPlanilla = a.DeducPlanilla,
                                         .TotalDeduc = a.TotalDeduc,
                                         .NetoPagar = a.NetoPagar,
                                         .AporPlanilla = a.AporPlanilla,
                                         .otros1 = a.Otros1,
                                         .TotalAporte = a.TotalAporte,
                                         .TotalRetenciones = a.TotalRetenciones,
                                         .Tipopresupuesto = a.TipoPresupuesto}).ToList
        For Each obj In consulta2
            objRecurso = New actividadRecurso With _
                               {
                                   .idActividadRecurso = obj.IdActividadRecurso, _
                                   .idActividad = obj.idActividad, _
                                   .fechaIngreso = obj.fechaIngreso, _
                                   .Descripcion = obj.Descripcion, _
                                   .detalleExtra = obj.DetalleExtra, _
                                   .TipoRecurso = obj.tipoRecurso, _
                                   .unidadMedida = obj.unidadMedida, _
                                   .ReferenciaSustento = obj.ReferenciaSustento, _
                                   .ValorMercadoPu = obj.ValorMercado,
                                   .CantRequerida = obj.cantRequerida,
                                   .TotalCosto = obj.TotalCosto,
                                   .PsptoReferencial = obj.PstoRef,
                                   .Costo = obj.Costo,
                                   .NoSustentado = obj.NoSustentado,
                                   .Porcentaje = obj.porcentaje,
                                   .PorIgv = obj.PorIgv,
                                   .Igv = obj.Igv,
                                   .Total = obj.total,
                                   .OtrosDeduc = obj.OtrosDeduc,
                                   .DeducPlanilla = obj.DeducPlanilla,
                                   .TotalDeduc = obj.TotalDeduc,
                                   .NetoPagar = obj.NetoPagar,
                                   .AporPlanilla = obj.AporPlanilla,
                                   .Otros1 = obj.otros1,
                                   .TotalAporte = obj.TotalAporte,
                                   .TotalRetenciones = obj.TotalRetenciones,
                                   .TipoPresupuesto = obj.Tipopresupuesto
                               }
            consulta.Add(objRecurso)
        Next

        Return consulta
    End Function

    Public Function GetListaGastoPlaneacion(intIDProyecto As Integer, strTipoRecurso As String, intIDActividad As Integer) 'As List(Of actividadRecurso)
        Dim consulta As New List(Of actividadRecurso)
        Dim listTipoRecurso As New List(Of String)()
        listTipoRecurso.Add("EX")
        listTipoRecurso.Add("GS")
        listTipoRecurso.Add("RH")
        Dim objRecurso As New actividadRecurso
        Dim consulta2 = (From a In HeliosData.actividadRecurso _
                        Group Join d In HeliosData.detalleitems _
                        On a.idItem Equals d.codigodetalle _
                        Into ords2 = Group _
                        From dt In ords2.DefaultIfEmpty _
                        Group Join i In HeliosData.item _
                        On dt.idItem Equals i.idItem _
                        Into ords3 = Group _
                        From it In ords3.DefaultIfEmpty _
                        Where a.idActividad = intIDActividad _
                        And a.tipoActividad = strTipoRecurso _
                        And listTipoRecurso.Contains(a.TipoRecurso) _
                        And a.tipoPlan = "B"
                        Select New With {.IdActividadRecurso = a.idActividadRecurso,
                                         .idActividad = a.idActividad,
                                         .fechaIngreso = a.fechaIngreso,
                                         .Descripcion = a.Descripcion,
                                        .DetalleExtra = a.detalleExtra,
                                         .tipoRecurso = a.TipoRecurso,
                                         .unidadMedida = a.unidadMedida,
                                        .ReferenciaSustento = a.ReferenciaSustento,
                                        .ValorMercado = a.ValorMercadoPu,
                                         .cantRequerida = a.CantRequerida,
                                         .TotalCosto = a.TotalCosto,
                                         .PstoRef = a.PsptoReferencial,
                                         .Costo = a.Costo,
                                         .NoSustentado = a.NoSustentado,
                                         .porcentaje = a.Porcentaje,
                                         .PorIgv = a.PorIgv,
                                         .Igv = a.Igv,
                                         .total = a.Total,
                                         .OtrosDeduc = a.OtrosDeduc,
                                         .DeducPlanilla = a.DeducPlanilla,
                                         .TotalDeduc = a.TotalDeduc,
                                         .NetoPagar = a.NetoPagar,
                                         .AporPlanilla = a.AporPlanilla,
                                         .otros1 = a.Otros1,
                                         .TotalAporte = a.TotalAporte,
                                         .TotalRetenciones = a.TotalRetenciones,
                                         .Tipopresupuesto = a.TipoPresupuesto,
                                         .clasificacion = it.descripcion}).ToList
        For Each obj In consulta2
            objRecurso = New actividadRecurso With _
                               {
                                   .idActividadRecurso = obj.IdActividadRecurso, _
                                   .idActividad = obj.idActividad, _
                                   .fechaIngreso = obj.fechaIngreso, _
                                   .Descripcion = obj.Descripcion, _
                                   .detalleExtra = obj.DetalleExtra, _
                                   .TipoRecurso = obj.tipoRecurso, _
                                   .unidadMedida = obj.unidadMedida, _
                                   .ReferenciaSustento = obj.ReferenciaSustento, _
                                   .ValorMercadoPu = obj.ValorMercado,
                                   .CantRequerida = obj.cantRequerida,
                                   .TotalCosto = obj.TotalCosto,
                                   .PsptoReferencial = obj.PstoRef,
                                   .Costo = obj.Costo,
                                   .NoSustentado = obj.NoSustentado,
                                   .Porcentaje = obj.porcentaje,
                                   .PorIgv = obj.PorIgv,
                                   .Igv = obj.Igv,
                                   .Total = obj.total,
                                   .OtrosDeduc = obj.OtrosDeduc,
                                   .DeducPlanilla = obj.DeducPlanilla,
                                   .TotalDeduc = obj.TotalDeduc,
                                   .NetoPagar = obj.NetoPagar,
                                   .AporPlanilla = obj.AporPlanilla,
                                   .Otros1 = obj.otros1,
                                   .TotalAporte = obj.TotalAporte,
                                   .TotalRetenciones = obj.TotalRetenciones,
                                   .TipoPresupuesto = obj.Tipopresupuesto,
                                   .Clasificacion = obj.clasificacion
                               }
            consulta.Add(objRecurso)
        Next

        Return consulta
    End Function

    Public Function GetListaGPlaneacionIngreso(intIDProyecto As Integer, strTipoRecurso As String, intIDActividad As Integer) 'As List(Of actividadRecurso)
        Dim consulta As New List(Of actividadRecurso)
        Dim objRecurso As New actividadRecurso
        Dim consulta2 = (From a In HeliosData.actividadRecurso _
                        Where a.idActividad = intIDActividad _
                        And a.tipoActividad = strTipoRecurso _
                        And a.TipoRecurso = "ING" _
                        And a.tipoPlan = "B"
                        Select New With {.IdActividadRecurso = a.idActividadRecurso,
                                         .idActividad = a.idActividad,
                                         .fechaIngreso = a.fechaIngreso,
                                         .Descripcion = a.Descripcion,
                                        .DetalleExtra = a.detalleExtra,
                                         .tipoRecurso = a.TipoRecurso,
                                         .unidadMedida = a.unidadMedida,
                                        .CantRequerida = a.CantRequerida,
                                        .ValorMercadoPu = a.ValorMercadoPu,
                                         .CostoDirecto = a.CostoDirecto,
                                         .PorGastosGenerales = a.PorGastosGenerales,
                                         .GastosGenerales = a.GastosGenerales,
                                         .PorUtilidad = a.PorUtilidad,
                                         .Utilidad = a.Utilidad,
                                         .OtrosIn1 = a.OtrosIn1,
                                         .ValorVenta = a.ValorVenta,
                                         .PorIgv = a.PorIgv,
                                         .Igv = a.Igv,
                                         .TotalProyecto = a.TotalProyecto,
                                         .PorPercep = a.PorPercep,
                                         .Percepciones = a.Percepciones,
                                         .OtrosIn2 = a.OtrosIn2,
                                         .TotalPorCobrar = a.TotalPorCobrar,
                                         .PorDetracciones = a.PorDetracciones,
                                         .Detracciones = a.Detracciones,
                                         .PorRetenciones = a.PorRetenciones,
                                         .Retenciones = a.Retenciones,
                                         .OtroIn3 = a.OtroIn3,
                                         .NetoCobrar = a.NetoCobrar,
                                         .Porcentaje = a.Porcentaje}).ToList
        For Each obj In consulta2
            objRecurso = New actividadRecurso With _
                               {
                                   .idActividadRecurso = obj.IdActividadRecurso, _
                                   .idActividad = obj.idActividad, _
                                   .fechaIngreso = obj.fechaIngreso, _
                                   .Descripcion = obj.Descripcion, _
                                   .detalleExtra = obj.DetalleExtra, _
                                   .TipoRecurso = obj.tipoRecurso, _
                                   .unidadMedida = obj.unidadMedida, _
                                   .CantRequerida = obj.CantRequerida, _
                                   .ValorMercadoPu = obj.ValorMercadoPu,
                                   .CostoDirecto = obj.CostoDirecto,
                                   .PorGastosGenerales = obj.PorGastosGenerales,
                                   .GastosGenerales = obj.GastosGenerales,
                                   .PorUtilidad = obj.PorUtilidad,
                                   .Utilidad = obj.Utilidad,
                                   .OtrosIn1 = obj.OtrosIn1,
                                   .ValorVenta = obj.ValorVenta,
                                   .PorIgv = obj.PorIgv,
                                   .Igv = obj.Igv,
                                   .TotalProyecto = obj.TotalProyecto,
                                   .PorPercep = obj.PorPercep,
                                   .Percepciones = obj.Percepciones,
                                   .OtrosIn2 = obj.OtrosIn2,
                                   .TotalPorCobrar = obj.TotalPorCobrar,
                                   .PorDetracciones = obj.PorDetracciones,
                                   .Detracciones = obj.Detracciones,
                                   .PorRetenciones = obj.PorRetenciones,
                                   .Retenciones = obj.Retenciones,
                                     .OtroIn3 = obj.OtroIn3,
                                   .NetoCobrar = obj.NetoCobrar,
                                   .Porcentaje = obj.Porcentaje}
            consulta.Add(objRecurso)
        Next

        Return consulta
    End Function

    Public Function GetUbicaActividadRecursoID(intActividad As Integer) As actividadRecurso
        Dim consulta = (From n In HeliosData.actividadRecurso _
                       Where n.idActividadRecurso = intActividad).FirstOrDefault
        Return consulta
    End Function

    Public Function GetUbicaCotizacionActividadRecursoID(intActividad As Integer) As actividadRecurso
        Dim consulta = (From n In HeliosData.actividadRecurso _
                        Join cal In HeliosData.actividadRecursoCalculo _
                        On n.idActividadRecurso Equals cal.idActividadRecurso _
                        Where n.idActividadRecurso = intActividad).FirstOrDefault

        Dim objRecurso As New actividadRecurso
        objRecurso.idActividadRecurso = consulta.n.idActividadRecurso
        objRecurso.fechaIngreso = consulta.n.fechaIngreso
        objRecurso.Descripcion = consulta.n.Descripcion
        objRecurso.TipoRecurso = consulta.n.TipoRecurso
        objRecurso.detalleExtra = consulta.n.detalleExtra
        objRecurso.unidadMedida = consulta.n.unidadMedida
        objRecurso.ReferenciaSustento = consulta.n.ReferenciaSustento
        objRecurso.laborDiaria = consulta.cal.laborDiaria
        objRecurso.hm = consulta.cal.hm
        objRecurso.Porcentaje = consulta.cal.porcentaje
        objRecurso.dias = consulta.cal.dias
        objRecurso.costoUnithh = consulta.cal.costoUnithh
        objRecurso.cant = consulta.cal.cant
        objRecurso.costoUnit = consulta.cal.costoUnit
        objRecurso.costoDirecto1 = consulta.cal.costoDirecto1
        objRecurso.costoDirecto2 = consulta.cal.costoDirecto2
        objRecurso.ggPorc = consulta.cal.ggPorc
        objRecurso.ggImporte = consulta.cal.ggImporte
        objRecurso.utPorc = consulta.cal.utPorc
        objRecurso.utImporte = consulta.cal.utImporte
        objRecurso.costoFinal = consulta.cal.costoFinal
        objRecurso.igvPorc = consulta.cal.igvPorc
        objRecurso.igvImporte = consulta.cal.igvImporte
        objRecurso.precioFinal = consulta.cal.precioFinal
        objRecurso.cantFinal = consulta.cal.cantFinal
        objRecurso.precUnitFinal = consulta.cal.precUnitFinal
        Return objRecurso
    End Function

    Public Sub InsertCotizacionFinal(ByVal ListaRecursoBE As List(Of actividadRecurso))
        Dim objDetalleItems As New detalleitemsBL
        Dim objRecurso As New actividadRecurso
        Dim objRecursoGasto As New actividadRecurso
        Dim objRecursoCalculo As New actividadRecursoCalculo
        Dim idActividadRecurso As Integer
        Dim liquidacionBL As New totalesLiquidacionBL
        Dim TablaDetalleBL As New tabladetalleBL
        Dim ItemBL As New itemBL
        Dim DetalleItemBL As New detalleitemsBL
        Dim IDDetalleItem As Integer

        Using ts As New TransactionScope

            For Each RecursoBE In ListaRecursoBE

                objRecurso = New actividadRecurso
                idActividadRecurso = RecursoBE.idActividadRecurso
                Select Case RecursoBE.Tipo
                    Case ("LC")
                        Dim consulta = (From n In HeliosData.actividadRecurso _
                                     Join cal In HeliosData.actividadRecursoCalculo _
                                        On n.idActividadRecurso Equals cal.idActividadRecurso _
                                        Where n.idActividadRecurso = idActividadRecurso).FirstOrDefault

                        If (RecursoBE.TipoRecurso = "EX") Then
                            IDDetalleItem = consulta.n.idItem
                        Else
                            IDDetalleItem = 0
                        End If

                        With objRecurso
                            .Action = Business.Entity.BaseBE.EntityAction.INSERT
                            .idActividad = consulta.n.idActividad
                            .idProyecto = RecursoBE.idProyecto
                            .tipoActividad = consulta.n.tipoActividad
                            .fechaIngreso = consulta.n.fechaIngreso
                            .TipoRecurso = RecursoBE.TipoRecurso
                            .idItem = IDDetalleItem
                            .cuentaContable = RecursoBE.cuentaContable
                            .Descripcion = consulta.n.Descripcion
                            .detalleExtra = consulta.n.detalleExtra
                            .unidadMedida = RecursoBE.unidadMedida
                            .ValorMercadoPu = consulta.n.ValorMercadoPu
                            .CantRequerida = consulta.n.CantRequerida
                            .TotalCosto = consulta.n.TotalCosto
                            .PsptoReferencial = consulta.n.PsptoReferencial
                            .ReferenciaSustento = consulta.n.ReferenciaSustento
                            .Costo = consulta.n.Costo
                            .NoSustentado = consulta.n.NoSustentado
                            .PorIgv = consulta.n.PorIgv
                            .Igv = consulta.n.Igv
                            .Total = consulta.n.Total
                            .PorDeducPlanilla = consulta.n.PorDeducPlanilla
                            .DeducPlanilla = consulta.n.DeducPlanilla
                            .PorOtrosDeduc = consulta.n.PorOtrosDeduc
                            .TotalDeduc = consulta.n.TotalDeduc
                            .OtrosDeduc = consulta.n.OtrosDeduc
                            .TotalDeduc = consulta.n.TotalDeduc
                            .NetoPagar = consulta.n.NetoPagar
                            .PorAporPlanilla = consulta.n.PorAporPlanilla
                            .AporPlanilla = consulta.n.AporPlanilla
                            .PorOtros1 = consulta.n.PorOtros1
                            .Otros1 = consulta.n.Otros1
                            .TotalAporte = consulta.n.TotalAporte
                            .TotalRetenciones = consulta.n.TotalRetenciones
                            .PorImpor1 = consulta.n.PorImpor1
                            .Impor1 = consulta.n.Impor1
                            .PorImpor2 = consulta.n.PorImpor2
                            .Impor2 = consulta.n.Impor2
                            .TotalImpor = consulta.n.TotalImpor
                            .TipoPresupuesto = consulta.n.TipoPresupuesto
                            .CostoDirecto = consulta.n.CostoDirecto
                            .PorGastosGenerales = consulta.n.PorGastosGenerales
                            .PorUtilidad = consulta.n.PorUtilidad
                            .Utilidad = consulta.n.Utilidad
                            .PorOtrosIn1 = consulta.n.PorOtrosIn1
                            .ValorVenta = consulta.n.ValorVenta
                            .Porcentaje = consulta.n.Porcentaje
                            .TotalProyecto = consulta.n.TotalProyecto
                            .PorPercep = consulta.n.PorPercep
                            .Percepciones = consulta.n.Percepciones
                            .PorOtrosIn2 = consulta.n.PorOtrosIn2
                            .OtrosIn2 = consulta.n.OtrosIn2
                            .TotalPorCobrar = consulta.n.TotalPorCobrar
                            .PorDetracciones = consulta.n.PorDetracciones
                            .Retenciones = consulta.n.Retenciones
                            .PorOtroIn3 = consulta.n.PorOtroIn3
                            .NetoCobrar = consulta.n.NetoCobrar
                            .TipoIncidencia = consulta.n.TipoIncidencia
                            .tipoPlan = RecursoBE.tipoPlan
                            .idOrden = consulta.n.idOrden
                            .Sustentado = "C"
                            'idActividadRecurso = objRecurso.idActividadRecurso
                        End With

                        objRecursoCalculo = New actividadRecursoCalculo
                        With objRecursoCalculo
                            '  .Action = ListaRecursoBE.Action
                            .laborDiaria = consulta.cal.laborDiaria
                            .hm = consulta.cal.hm
                            .porcentaje = consulta.cal.porcentaje
                            .dias = consulta.cal.dias
                            .costoUnithh = consulta.cal.costoUnithh
                            .cant = consulta.cal.cant
                            .costoUnit = consulta.cal.costoUnit
                            .costoDirecto1 = consulta.cal.costoDirecto1
                            .costoDirecto2 = consulta.cal.costoDirecto2
                            .ggPorc = consulta.cal.ggPorc
                            .ggImporte = consulta.cal.ggImporte
                            .utPorc = consulta.cal.utPorc
                            .utImporte = consulta.cal.utImporte
                            .costoFinal = consulta.cal.costoFinal
                            .igvPorc = consulta.cal.igvPorc
                            .igvImporte = consulta.cal.igvImporte
                            .precioFinal = consulta.cal.precioFinal
                            .cantFinal = consulta.cal.cantFinal
                            .precUnitFinal = consulta.cal.precUnitFinal

                        End With
                        objRecurso.actividadRecursoCalculo = objRecursoCalculo
                        HeliosData.actividadRecurso.Add(objRecurso)

                    Case ("LG")
                        Dim consulta = (From n In HeliosData.actividadRecurso _
                                        Where n.idActividadRecurso = idActividadRecurso).FirstOrDefault

                        If (RecursoBE.TipoRecurso = "EX") Then
                            IDDetalleItem = consulta.idItem
                        Else
                            IDDetalleItem = 0
                        End If

                        With objRecurso
                            .Action = Business.Entity.BaseBE.EntityAction.INSERT
                            .idProyecto = RecursoBE.idProyecto
                            .idActividad = consulta.idActividad
                            .tipoActividad = consulta.tipoActividad
                            .fechaIngreso = consulta.fechaIngreso
                            .TipoRecurso = RecursoBE.TipoRecurso
                            .idItem = IDDetalleItem
                            .cuentaContable = RecursoBE.cuentaContable
                            .Descripcion = consulta.Descripcion
                            .detalleExtra = consulta.detalleExtra
                            .unidadMedida = RecursoBE.unidadMedida
                            .ValorMercadoPu = consulta.ValorMercadoPu
                            .CantRequerida = consulta.CantRequerida
                            .TotalCosto = consulta.TotalCosto
                            .PsptoReferencial = consulta.PsptoReferencial
                            .ReferenciaSustento = consulta.ReferenciaSustento
                            .Costo = consulta.Costo
                            .NoSustentado = consulta.NoSustentado
                            .PorIgv = consulta.PorIgv
                            .Igv = consulta.Igv
                            .Total = consulta.Total
                            .PorDeducPlanilla = consulta.PorDeducPlanilla
                            .DeducPlanilla = consulta.DeducPlanilla
                            .PorOtrosDeduc = consulta.PorOtrosDeduc
                            .TotalDeduc = consulta.TotalDeduc
                            .OtrosDeduc = consulta.OtrosDeduc
                            .TotalDeduc = consulta.TotalDeduc
                            .NetoPagar = consulta.NetoPagar
                            .PorAporPlanilla = consulta.PorAporPlanilla
                            .AporPlanilla = consulta.AporPlanilla

                            .PorOtros1 = consulta.PorOtros1
                            .Otros1 = consulta.Otros1
                            .TotalAporte = consulta.TotalAporte
                            .TotalRetenciones = consulta.TotalRetenciones
                            .PorImpor1 = consulta.PorImpor1
                            .Impor1 = consulta.Impor1
                            .PorImpor2 = consulta.PorImpor2
                            .Impor2 = consulta.Impor2
                            .TotalImpor = consulta.TotalImpor
                            .TipoPresupuesto = consulta.TipoPresupuesto
                            .CostoDirecto = consulta.CostoDirecto
                            .PorGastosGenerales = consulta.PorGastosGenerales

                            .PorUtilidad = consulta.PorUtilidad
                            .Utilidad = consulta.Utilidad
                            .PorOtrosIn1 = consulta.PorOtrosIn1
                            .ValorVenta = consulta.ValorVenta
                            .Porcentaje = consulta.Porcentaje
                            .TotalProyecto = consulta.TotalProyecto
                            .PorPercep = consulta.PorPercep
                            .Percepciones = consulta.Percepciones
                            .PorOtrosIn2 = consulta.PorOtrosIn2
                            .OtrosIn2 = consulta.OtrosIn2
                            .TotalPorCobrar = consulta.TotalPorCobrar
                            .PorDetracciones = consulta.PorDetracciones
                            .Retenciones = consulta.Retenciones
                            .PorOtroIn3 = consulta.PorOtroIn3
                            .NetoCobrar = consulta.NetoCobrar
                            .TipoIncidencia = consulta.TipoIncidencia
                            .tipoPlan = RecursoBE.tipoPlan
                            .idOrden = consulta.idOrden
                            .Sustentado = "G"

                        End With
                        'objRecurso.actividadRecursoCalculo = objRecursoCalculo
                        HeliosData.actividadRecurso.Add(objRecurso)
                End Select
            Next
            'liquidacionBL.SaveLiquidacionPreliminarExcel(ListaLiquidacionBE, ListaLiquidacionBE(0).idActividad)
            liquidacionBL.GrabarTotalLiquidacionAP(ListaRecursoBE(0).Idempresa, ListaRecursoBE(0).IdEstablecimiento, ListaRecursoBE(0).idActividad, "A")
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub UpdateActividadRecursoMT(ByVal IdActividad As Integer, ByVal TipActividad As String, ByVal IdActividadAnt As Integer, ByVal TipActividadAnt As String)
        Dim ObjProyecto As New actividadRecurso
        Dim IDconsulta As Integer
        Using ts As New TransactionScope
            Dim objConsulta = (From a In HeliosData.actividadRecurso
                                Where a.idActividad = IdActividadAnt _
                                And a.tipoActividad = TipActividadAnt
                                Select a).ToList

            For Each consulta In objConsulta
                IDconsulta = consulta.idActividadRecurso
                Dim proyect As actividadRecurso = HeliosData.actividadRecurso.Where _
                                                  (Function(o) o.idActividadRecurso = IDconsulta).First()


                ObjProyecto = New actividadRecurso
                With proyect
                    .Action = Business.Entity.BaseBE.EntityAction.UPDATE
                    .idActividad = IdActividad
                    .tipoActividad = TipActividad
                End With
                'HeliosData.ObjectStateManager.GetObjectStateEntry(proyect).State.ToString()

            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub
End Class
