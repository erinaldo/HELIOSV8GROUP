Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmActaConstitucion

#Region "Métodos"

    'Sub GrabarCotizacion()
    '    Dim nProudctoSA As New detalleitemsSA
    '    Dim nProducto As New detalleitems
    '    Dim ListaProducto As New List(Of detalleitems)

    '    Try
    '        For Each i As DataGridViewRow In dgvImportar.Rows
    '            nProducto = New detalleitems
    '            nProducto.Action = Business.Entity.BaseBE.EntityAction.INSERT
    '            ' nProducto.idItem = 0
    '            nProducto.idEmpresa = TmpIdEmpresa
    '            nProducto.idEstablecimiento = TmpIdEstable
    '            nProducto.cuenta = "602111"
    '            nProducto.descripcionItem = i.Cells(1).Value
    '            nProducto.presentacion = Nothing
    '            nProducto.unidad1 = "01"
    '            nProducto.tipoExistencia = "03"
    '            nProducto.origenProducto = "1"
    '            nProducto.tipoProducto = "I"
    '            nProducto.estado = "1"
    '            nProducto.usuarioActualizacion = "NN"
    '            nProducto.fechaActualizacion = DateTime.Now
    '            ListaProducto.Add(nProducto)
    '        Next
    '        nProudctoSA.SaveListaProducto(ListaProducto)
    '        lblEstado.Text = "Cotización procesada"
    '        lblEstado.Image = My.Resources.ok4
    '    Catch ex As Exception
    '        lblEstado.Text = ex.Message
    '        lblEstado.Image = My.Resources.cross
    '    End Try
    'End Sub

    Sub GrabarCotizacion()
        Dim nRecursoSA As New actividadRecursoSA
        Dim nRecurso As New actividadRecurso
        Dim nRecursoGasto As New actividadRecurso
        nRecurso.actividadRecursoCalculo = New actividadRecursoCalculo()
        Dim ListaRecurso As New List(Of actividadRecurso)
        Dim ListaLiquidacion As New List(Of totalesLiquidacion)
        Dim ListaRecursoGasto As New List(Of actividadRecurso)
        Dim ListaRecursoEDT As New List(Of Actividades)
        Dim DetalleSA As New tablaDetalleSA
        Dim objDetalle As New tabladetalle
        Dim codigoDetalleEDT As Integer
        Dim actividadSA As New ActividadesSA
        Dim objLiquidacionDet As New totalesLiquidacion()
        Dim trabajadorSA = New Trabajador_PLSA()
        Dim objDetalleEDT As New Trabajador_PL
        Dim nRecursoEDT As New Actividades
        Dim tipRec As String = "NULL"
        Dim tipoCuenta As Integer = 0
        Dim conteo As Integer = 0
        Dim objTablaDetalle As New detalleitems
        Dim TabladetalleSA As New detalleitemsSA
        ' Dim actividad As New Actividades
        Try
            If (GModoProyecto = "Aprobado") Then
                For Each i As DataGridViewRow In dgvEDT.Rows
                    codigoDetalleEDT = trabajadorSA.ObtenerTrabPorDNIExcel(i.Cells(3).Value, GEstableciento.IdEstablecimiento)
                    If (codigoDetalleEDT = 0) Then
                        objDetalleEDT = New Trabajador_PL With {
                                                .Action = Business.Entity.BaseBE.EntityAction.INSERT,
                                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                .codTrabajdor = i.Cells(3).Value,
                                                .nombres = i.Cells(4).Value,
                                                .appat = i.Cells(5).Value,
                                                .apmat = i.Cells(6).Value,
                                                .tipoDoc = 1,
                                                .estado = 1}

                        trabajadorSA.GrabarTrabajador(objDetalleEDT)
                        nRecursoEDT = New Actividades With {
                         .Action = Business.Entity.BaseBE.EntityAction.INSERT,
                         .idEmpresa = Gempresas.IdEmpresaRuc,
                         .idEstablecimiento = GEstableciento.IdEstablecimiento,
                         .idProyecto = GProyectos.IdProyectoActividad,
                         .NombreActividad = i.Cells(1).Value,
                         .descripcion = i.Cells(2).Value,
                         .idPadre = GProyectos.IdProyecto,
                         .modulo = "EDT",
                         .responsable = i.Cells(3).Value,
                        .FechaInicio = i.Cells(7).Value,
                         .Dias = i.Cells(8).Value,
                         .Observacion = i.Cells(9).Value,
                         .flag = "AP",
                        .usuarioActualizacion = "NN",
                        .fechaActualizacion = Date.Now
                         }
                    Else
                        nRecursoEDT = New Actividades With {
                   .Action = Business.Entity.BaseBE.EntityAction.INSERT,
                   .idEmpresa = Gempresas.IdEmpresaRuc,
                   .idEstablecimiento = GEstableciento.IdEstablecimiento,
                   .idProyecto = GProyectos.IdProyectoActividad,
                   .NombreActividad = i.Cells(1).Value,
                   .descripcion = i.Cells(2).Value,
                   .idPadre = GProyectos.IdProyecto,
                   .modulo = "EDT",
                   .responsable = i.Cells(3).Value,
                  .FechaInicio = i.Cells(7).Value,
                   .Dias = i.Cells(8).Value,
                   .flag = "AP",
                   .Observacion = i.Cells(9).Value,
                  .usuarioActualizacion = "NN",
                        .fechaActualizacion = Date.Now
                   }
                    End If
                    ListaRecursoEDT.Add(nRecursoEDT)
                Next

                '   actividad = actividadSA.GetUbicaProyectoActividad(GProyectos.IdProyecto)
                For Each i As DataGridViewRow In dgvGastos.Rows

                    Select Case i.Cells(24).Value
                        Case "EXISTENCIA"
                            tipRec = TipoRecurso.EXISTENCIA
                            tipoCuenta = "602111"
                        Case "SERVICIO-CONTRATO"
                            tipRec = TipoRecurso.SERVICIO
                            tipoCuenta = "63"
                        Case "RECURSOS HUMANOS"
                            tipRec = TipoRecurso.RECURSOS_HUMANOS
                            tipoCuenta = "62"
                    End Select

                    nRecursoGasto = New actividadRecurso With {
                      .Action = Business.Entity.BaseBE.EntityAction.INSERT,
                      .idProyecto = GProyectos.IdProyectoActividad,
                      .idActividad = GProyectos.IdProyecto,
                      .tipoActividad = "PY",
                      .Idempresa = Gempresas.IdEmpresaRuc,
                      .IdEstablecimiento = GEstableciento.IdEstablecimiento,
                      .fechaIngreso = DateTime.Now,
                      .Clasificacion = i.Cells(23).Value,
                      .cuentaContable = tipoCuenta,
                        .unidadMedida = i.Cells(3).Value,
                      .TipoRecurso = tipRec,
                      .Descripcion = i.Cells(1).Value,
                      .detalleExtra = i.Cells(2).Value,
                      .ValorMercadoPu = CDec(i.Cells(5).Value),
                      .CantRequerida = CDec(i.Cells(4).Value),
                      .TotalCosto = CDec(i.Cells(6).Value),
                      .OtrosDeduc = 0,
                      .DeducPlanilla = 0,
                      .TotalDeduc = 0,
                      .NetoPagar = CDec(i.Cells(10).Value),
                      .Otros1 = 0,
                      .AporPlanilla = 0,
                      .TotalAporte = 0,
                      .TotalRetenciones = 0,
                      .ReferenciaSustento = i.Cells(15).Value,
                      .PorIgv = i.Cells(16).Value,
                      .Costo = CDec(i.Cells(17).Value),
                      .NoSustentado = CDec(i.Cells(18).Value),
                      .Porcentaje = CDec(i.Cells(19).Value),
                      .Igv = CDec(i.Cells(20).Value),
                      .PsptoReferencial = 0,
                      .Total = CDec(i.Cells(22).Value),
                      .tipoPlan = "AP",
                      .Sustentado = "G",
                      .TipoPresupuesto = "INCIDENCIA DIRECTA"}

                    'LIQUIDACION INSERT
                    objLiquidacionDet = New totalesLiquidacion()

                    objLiquidacionDet.idEmpresa = Gempresas.IdEmpresaRuc
                    objLiquidacionDet.idEstablecimiento = GEstableciento.IdEstablecimiento
                    objLiquidacionDet.idActividad = GProyectos.IdProyecto
                    objLiquidacionDet.tipoLiquidacion = "INCIDENCIA DIRECTA"
                    objLiquidacionDet.Otros = "CADIN"
                    objLiquidacionDet.modulo = "N"
                    objLiquidacionDet.Fecha = DateTime.Now.Date

                    objLiquidacionDet.LI_ib_ini = 0 ' nudIgv.Value  'IGV
                    objLiquidacionDet.LI_ib_ns = 0 'nudIgv.Value 'IGV
                    objLiquidacionDet.LI_ib_adic = 0 ' nudIgv.Value 'IGV


                    objLiquidacionDet.RefSustento1 = i.Cells(15).Value 'i.LI_cfAcum_ini


                    Select Case i.Cells(15).Value
                        Case TipoReferenciaSustento.COSTO_IGV
                            'PRIMERO(REPORTE)
                            objLiquidacionDet.LI_cfAcum_ini = Math.Round((CDec(i.Cells(22).Value) / 1.18) * 0.18, 2) 'i.LI_cfAcum_ini
                            objLiquidacionDet.LI_cfAcum_ns = Math.Round((CDec(i.Cells(22).Value) / 1.18) * 0.18, 2) ' i.LI_cfAcum_ns
                            objLiquidacionDet.LI_afAcum_adic = Math.Round((CDec(i.Cells(22).Value) / 1.18) * 0.18, 2) ' i.LI_afAcum_adic

                            'segundo(reporte)
                            objLiquidacionDet.LR_costov_ini = Math.Round((CDec(i.Cells(22).Value) / 1.18) + CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value), 2)
                            objLiquidacionDet.LR_costov_ns = Math.Round((CDec(i.Cells(22).Value) / 1.18) + +CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value), 2)
                            objLiquidacionDet.LR_costov_adic = Math.Round((CDec(i.Cells(22).Value) / 1.18) + +CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value), 2)

                            '3er reporte
                            objLiquidacionDet.LOO_ReDeAp_ini = Math.Round(CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value) + CDec(i.Cells(11).Value) + CDec(i.Cells(12).Value), 2)
                            objLiquidacionDet.LOO_ReDeAp_ns = Math.Round(CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value) + CDec(i.Cells(11).Value) + CDec(i.Cells(12).Value), 2)
                            objLiquidacionDet.LOO_ReDeAp_adic = Math.Round(CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value) + CDec(i.Cells(11).Value) + CDec(i.Cells(12).Value), 2)

                            'ANALISIS FINANCIERO
                            objLiquidacionDet.AF_TotalPagoProvSust_ini = CDec(i.Cells(22).Value)
                            objLiquidacionDet.AF_TotalPagoProvSust_ns = CDec(i.Cells(22).Value)
                            objLiquidacionDet.AF_TotalPagoProvSust_adic = CDec(i.Cells(22).Value)
                        Case TipoReferenciaSustento.SOLO_COSTO
                            'PRIMERO(REPORTE)
                            objLiquidacionDet.LI_cfAcum_ini = 0 'i.LI_cfAcum_ini
                            objLiquidacionDet.LI_cfAcum_ns = 0 ' i.LI_cfAcum_ns
                            objLiquidacionDet.LI_afAcum_adic = 0 ' i.LI_afAcum_adic

                            'segundo(reporte)
                            objLiquidacionDet.LR_costov_ini = Math.Round((CDec(i.Cells(22).Value)) + CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value), 2)
                            objLiquidacionDet.LR_costov_ns = Math.Round((CDec(i.Cells(22).Value)) + +CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value), 2)
                            objLiquidacionDet.LR_costov_adic = Math.Round((CDec(i.Cells(22).Value)) + +CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value), 2)
                            '3er reporte
                            objLiquidacionDet.LOO_ReDeAp_ini = Math.Round(CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value) + CDec(i.Cells(11).Value) + CDec(i.Cells(12).Value), 2)
                            objLiquidacionDet.LOO_ReDeAp_ns = Math.Round(CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value) + CDec(i.Cells(11).Value) + CDec(i.Cells(12).Value), 2)
                            objLiquidacionDet.LOO_ReDeAp_adic = Math.Round(CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value) + CDec(i.Cells(11).Value) + CDec(i.Cells(12).Value), 2)

                            'ANALISIS FINANCIERO
                            objLiquidacionDet.AF_TotalPagoProvSust_ini = CDec(i.Cells(22).Value)
                            objLiquidacionDet.AF_TotalPagoProvSust_ns = CDec(i.Cells(22).Value)
                            objLiquidacionDet.AF_TotalPagoProvSust_adic = CDec(i.Cells(22).Value)
                        Case TipoReferenciaSustento.NO_SUSTENTADO
                            objLiquidacionDet.LI_cfAcum_ini = 0 'i.LI_cfAcum_ini
                            objLiquidacionDet.LI_cfAcum_ns = 0 ' i.LI_cfAcum_ns
                            objLiquidacionDet.LI_afAcum_adic = 0 ' i.LI_afAcum_adic
                            'segundo(reporte)
                            objLiquidacionDet.LR_costov_ini = Math.Round(0 + CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value), 2)
                            objLiquidacionDet.LR_costov_ns = Math.Round(0 + +CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value), 2)
                            objLiquidacionDet.LR_costov_adic = Math.Round(0 + +CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value), 2)
                            '3er reporte
                            objLiquidacionDet.LOO_ReDeAp_ini = Math.Round(CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value) + CDec(i.Cells(11).Value) + CDec(i.Cells(12).Value), 2)
                            objLiquidacionDet.LOO_ReDeAp_ns = Math.Round(CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value) + CDec(i.Cells(11).Value) + CDec(i.Cells(12).Value), 2)
                            objLiquidacionDet.LOO_ReDeAp_adic = Math.Round(CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value) + CDec(i.Cells(11).Value) + CDec(i.Cells(12).Value), 2)

                            'ANALISIS FINANCIERO
                            objLiquidacionDet.AF_TotalPagoProvSust_ini = 0.0
                            objLiquidacionDet.AF_TotalPagoProvSust_ns = 0.0
                            objLiquidacionDet.AF_TotalPagoProvSust_adic = 0.0
                    End Select

                    'no sustentados
                    If (i.Cells(15).Value = "NO SUSTENTADO") Then
                        objLiquidacionDet.AF_RefGastoNoSust_ini = CDec(i.Cells(22).Value)
                    Else
                        objLiquidacionDet.AF_RefGastoNoSust_ini = 0
                    End If

                    If (i.Cells(15).Value = "NO SUSTENTADO") Then
                        objLiquidacionDet.AF_RefGastoNoSust_ns = CDec(i.Cells(22).Value)
                    Else
                        objLiquidacionDet.AF_RefGastoNoSust_ns = 0
                    End If

                    objLiquidacionDet.LP_TotalPagoProvCSSust_ini = CDec(i.Cells(22).Value)
                    objLiquidacionDet.LP_TotalPagoProvCSSust_ns = CDec(i.Cells(22).Value)
                    objLiquidacionDet.LP_TotalPagoProvCSSust_adic = CDec(i.Cells(22).Value)

                    objLiquidacionDet.tipoPlan = "AP"

                    objLiquidacionDet.usuarioActualizacion = "NN"
                    objLiquidacionDet.fechaActualizacion = DateTime.Now
                    ListaLiquidacion.Add(objLiquidacionDet)

                    ListaRecursoGasto.Add(nRecursoGasto)
                Next


                'cuando NO esta aprobado en proyecto
            Else
                For Each i As DataGridViewRow In dgvEDT.Rows
                    codigoDetalleEDT = trabajadorSA.ObtenerTrabPorDNIExcel(i.Cells(3).Value, GEstableciento.IdEstablecimiento)
                    If (codigoDetalleEDT = 0) Then
                        objDetalleEDT = New Trabajador_PL With {
                                                .Action = Business.Entity.BaseBE.EntityAction.INSERT,
                                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                .codTrabajdor = i.Cells(3).Value,
                                                .nombres = i.Cells(4).Value,
                                                .appat = i.Cells(5).Value,
                                                .apmat = i.Cells(6).Value,
                                                .tipoDoc = 1,
                                                .estado = 1}

                        trabajadorSA.GrabarTrabajador(objDetalleEDT)
                        nRecursoEDT = New Actividades With {
                         .Action = Business.Entity.BaseBE.EntityAction.INSERT,
                         .idEmpresa = Gempresas.IdEmpresaRuc,
                         .idEstablecimiento = GEstableciento.IdEstablecimiento,
                         .idProyecto = GProyectos.IdProyectoActividad,
                         .NombreActividad = i.Cells(1).Value,
                         .descripcion = i.Cells(2).Value,
                         .idPadre = GProyectos.IdProyecto,
                         .modulo = "EDT",
                         .responsable = i.Cells(3).Value,
                         .FechaInicio = i.Cells(7).Value,
                         .Dias = i.Cells(8).Value,
                         .Observacion = i.Cells(9).Value,
                          .flag = "A",
                        .usuarioActualizacion = "NN",
                         .fechaActualizacion = Date.Now
                         }
                    Else
                        nRecursoEDT = New Actividades With {
                   .Action = Business.Entity.BaseBE.EntityAction.INSERT,
                   .idEmpresa = Gempresas.IdEmpresaRuc,
                   .idEstablecimiento = GEstableciento.IdEstablecimiento,
                   .idProyecto = GProyectos.IdProyectoActividad,
                   .NombreActividad = i.Cells(1).Value,
                   .descripcion = i.Cells(2).Value,
                   .idPadre = GProyectos.IdProyecto,
                   .modulo = "EDT",
                   .responsable = i.Cells(3).Value,
                  .FechaInicio = i.Cells(7).Value,
                   .Dias = i.Cells(8).Value,
                   .Observacion = i.Cells(9).Value,
                   .flag = "A",
                  .usuarioActualizacion = "NN",
                        .fechaActualizacion = Date.Now
                   }
                    End If
                    ListaRecursoEDT.Add(nRecursoEDT)
                Next

                '   actividad = actividadSA.GetUbicaProyectoActividad(GProyectos.IdProyecto)
                For Each i As DataGridViewRow In dgvGastos.Rows
                    Select Case i.Cells(24).Value
                        Case "EXISTENCIA"
                            tipRec = TipoRecurso.EXISTENCIA
                            tipoCuenta = "602111"
                        Case "SERVICIO-CONTRATO"
                            tipRec = TipoRecurso.SERVICIO
                            tipoCuenta = "63"
                        Case "RECURSOS HUMANOS"
                            tipRec = TipoRecurso.RECURSOS_HUMANOS
                            tipoCuenta = "62"
                    End Select
                    nRecursoGasto = New actividadRecurso With {
                      .Action = Business.Entity.BaseBE.EntityAction.INSERT,
                      .idProyecto = GProyectos.IdProyectoActividad,
                      .idActividad = GProyectos.IdProyecto,
                      .tipoActividad = "PY",
                      .Idempresa = Gempresas.IdEmpresaRuc,
                      .IdEstablecimiento = GEstableciento.IdEstablecimiento,
                      .fechaIngreso = DateTime.Now,
                      .Clasificacion = i.Cells(23).Value,
                      .TipoRecurso = tipRec,
                      .unidadMedida = i.Cells(3).Value,
                      .cuentaContable = tipoCuenta,
                      .Descripcion = i.Cells(1).Value,
                      .detalleExtra = i.Cells(2).Value,
                      .ValorMercadoPu = CDec(i.Cells(5).Value),
                      .CantRequerida = CDec(i.Cells(4).Value),
                      .TotalCosto = CDec(i.Cells(6).Value),
                      .OtrosDeduc = 0,
                      .DeducPlanilla = 0,
                      .TotalDeduc = 0,
                      .NetoPagar = CDec(i.Cells(10).Value),
                      .Otros1 = 0,
                      .AporPlanilla = 0,
                      .TotalAporte = 0,
                      .TotalRetenciones = 0,
                      .ReferenciaSustento = i.Cells(15).Value,
                      .PorIgv = i.Cells(16).Value,
                      .Costo = CDec(i.Cells(17).Value),
                      .NoSustentado = CDec(i.Cells(18).Value),
                      .Porcentaje = CDec(i.Cells(19).Value),
                      .Igv = CDec(i.Cells(20).Value),
                      .PsptoReferencial = 0,
                      .Total = CDec(i.Cells(22).Value),
                      .tipoPlan = "A",
                      .Sustentado = "G",
                      .TipoPresupuesto = "INCIDENCIA DIRECTA"}

                    'LIQUIDACION INSERT
                    objLiquidacionDet = New totalesLiquidacion()

                    objLiquidacionDet.idEmpresa = Gempresas.IdEmpresaRuc
                    objLiquidacionDet.idEstablecimiento = GEstableciento.IdEstablecimiento
                    objLiquidacionDet.idActividad = GProyectos.IdProyecto
                    objLiquidacionDet.tipoLiquidacion = "INCIDENCIA DIRECTA"
                    objLiquidacionDet.Otros = "CADIN"
                    objLiquidacionDet.modulo = "N"
                    objLiquidacionDet.Fecha = DateTime.Now.Date

                    objLiquidacionDet.LI_ib_ini = 0 ' nudIgv.Value  'IGV
                    objLiquidacionDet.LI_ib_ns = 0 'nudIgv.Value 'IGV
                    objLiquidacionDet.LI_ib_adic = 0 ' nudIgv.Value 'IGV


                    objLiquidacionDet.RefSustento1 = i.Cells(15).Value 'i.LI_cfAcum_ini


                    Select Case i.Cells(15).Value
                        Case TipoReferenciaSustento.COSTO_IGV
                            'PRIMERO(REPORTE)
                            objLiquidacionDet.LI_cfAcum_ini = Math.Round((CDec(i.Cells(22).Value) / 1.18) * 0.18, 2) 'i.LI_cfAcum_ini
                            objLiquidacionDet.LI_cfAcum_ns = Math.Round((CDec(i.Cells(22).Value) / 1.18) * 0.18, 2) ' i.LI_cfAcum_ns
                            objLiquidacionDet.LI_afAcum_adic = Math.Round((CDec(i.Cells(22).Value) / 1.18) * 0.18, 2) ' i.LI_afAcum_adic

                            'segundo(reporte)
                            objLiquidacionDet.LR_costov_ini = Math.Round((CDec(i.Cells(22).Value) / 1.18) + CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value), 2)
                            objLiquidacionDet.LR_costov_ns = Math.Round((CDec(i.Cells(22).Value) / 1.18) + +CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value), 2)
                            objLiquidacionDet.LR_costov_adic = Math.Round((CDec(i.Cells(22).Value) / 1.18) + +CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value), 2)

                            '3er reporte
                            objLiquidacionDet.LOO_ReDeAp_ini = Math.Round(CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value) + CDec(i.Cells(11).Value) + CDec(i.Cells(12).Value), 2)
                            objLiquidacionDet.LOO_ReDeAp_ns = Math.Round(CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value) + CDec(i.Cells(11).Value) + CDec(i.Cells(12).Value), 2)
                            objLiquidacionDet.LOO_ReDeAp_adic = Math.Round(CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value) + CDec(i.Cells(11).Value) + CDec(i.Cells(12).Value), 2)

                            'ANALISIS FINANCIERO
                            objLiquidacionDet.AF_TotalPagoProvSust_ini = CDec(i.Cells(22).Value)
                            objLiquidacionDet.AF_TotalPagoProvSust_ns = CDec(i.Cells(22).Value)
                            objLiquidacionDet.AF_TotalPagoProvSust_adic = CDec(i.Cells(22).Value)
                        Case TipoReferenciaSustento.SOLO_COSTO
                            'PRIMERO(REPORTE)
                            objLiquidacionDet.LI_cfAcum_ini = 0 'i.LI_cfAcum_ini
                            objLiquidacionDet.LI_cfAcum_ns = 0 ' i.LI_cfAcum_ns
                            objLiquidacionDet.LI_afAcum_adic = 0 ' i.LI_afAcum_adic

                            'segundo(reporte)
                            objLiquidacionDet.LR_costov_ini = Math.Round((CDec(i.Cells(22).Value)) + CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value), 2)
                            objLiquidacionDet.LR_costov_ns = Math.Round((CDec(i.Cells(22).Value)) + +CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value), 2)
                            objLiquidacionDet.LR_costov_adic = Math.Round((CDec(i.Cells(22).Value)) + +CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value), 2)
                            '3er reporte
                            objLiquidacionDet.LOO_ReDeAp_ini = Math.Round(CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value) + CDec(i.Cells(11).Value) + CDec(i.Cells(12).Value), 2)
                            objLiquidacionDet.LOO_ReDeAp_ns = Math.Round(CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value) + CDec(i.Cells(11).Value) + CDec(i.Cells(12).Value), 2)
                            objLiquidacionDet.LOO_ReDeAp_adic = Math.Round(CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value) + CDec(i.Cells(11).Value) + CDec(i.Cells(12).Value), 2)

                            'ANALISIS FINANCIERO
                            objLiquidacionDet.AF_TotalPagoProvSust_ini = CDec(i.Cells(22).Value)
                            objLiquidacionDet.AF_TotalPagoProvSust_ns = CDec(i.Cells(22).Value)
                            objLiquidacionDet.AF_TotalPagoProvSust_adic = CDec(i.Cells(22).Value)
                        Case TipoReferenciaSustento.NO_SUSTENTADO
                            objLiquidacionDet.LI_cfAcum_ini = 0 'i.LI_cfAcum_ini
                            objLiquidacionDet.LI_cfAcum_ns = 0 ' i.LI_cfAcum_ns
                            objLiquidacionDet.LI_afAcum_adic = 0 ' i.LI_afAcum_adic
                            'segundo(reporte)
                            objLiquidacionDet.LR_costov_ini = Math.Round(0 + CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value), 2)
                            objLiquidacionDet.LR_costov_ns = Math.Round(0 + +CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value), 2)
                            objLiquidacionDet.LR_costov_adic = Math.Round(0 + +CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value), 2)
                            '3er reporte
                            objLiquidacionDet.LOO_ReDeAp_ini = Math.Round(CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value) + CDec(i.Cells(11).Value) + CDec(i.Cells(12).Value), 2)
                            objLiquidacionDet.LOO_ReDeAp_ns = Math.Round(CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value) + CDec(i.Cells(11).Value) + CDec(i.Cells(12).Value), 2)
                            objLiquidacionDet.LOO_ReDeAp_adic = Math.Round(CDec(i.Cells(7).Value) + CDec(i.Cells(8).Value) + CDec(i.Cells(11).Value) + CDec(i.Cells(12).Value), 2)

                            'ANALISIS FINANCIERO
                            objLiquidacionDet.AF_TotalPagoProvSust_ini = 0.0
                            objLiquidacionDet.AF_TotalPagoProvSust_ns = 0.0
                            objLiquidacionDet.AF_TotalPagoProvSust_adic = 0.0
                    End Select

                    'no sustentados
                    If (i.Cells(15).Value = "NO SUSTENTADO") Then
                        objLiquidacionDet.AF_RefGastoNoSust_ini = CDec(i.Cells(22).Value)
                    Else
                        objLiquidacionDet.AF_RefGastoNoSust_ini = 0
                    End If

                    If (i.Cells(15).Value = "NO SUSTENTADO") Then
                        objLiquidacionDet.AF_RefGastoNoSust_ns = CDec(i.Cells(22).Value)
                    Else
                        objLiquidacionDet.AF_RefGastoNoSust_ns = 0
                    End If

                    objLiquidacionDet.LP_TotalPagoProvCSSust_ini = CDec(i.Cells(22).Value)
                    objLiquidacionDet.LP_TotalPagoProvCSSust_ns = CDec(i.Cells(22).Value)
                    objLiquidacionDet.LP_TotalPagoProvCSSust_adic = CDec(i.Cells(22).Value)

                    objLiquidacionDet.tipoPlan = "A"

                    objLiquidacionDet.usuarioActualizacion = "NN"
                    objLiquidacionDet.fechaActualizacion = DateTime.Now
                    ListaLiquidacion.Add(objLiquidacionDet)

                    ListaRecursoGasto.Add(nRecursoGasto)
                Next

                For Each i As DataGridViewRow In dgvImportar.Rows
                    nRecurso = New actividadRecurso
                    nRecurso.Action = Business.Entity.BaseBE.EntityAction.INSERT
                    ' nProducto.idItem = 0
                    Select Case i.Cells(29).Value
                        Case "EXISTENCIA"
                            tipRec = TipoRecurso.EXISTENCIA
                            tipoCuenta = "602111"
                        Case "SERVICIO-CONTRATO"
                            tipRec = TipoRecurso.SERVICIO
                            tipoCuenta = "63"
                        Case "RECURSOS HUMANOS"
                            tipRec = TipoRecurso.RECURSOS_HUMANOS
                            tipoCuenta = "62"
                    End Select
                    nRecurso.Idempresa = Gempresas.IdEmpresaRuc
                    nRecurso.IdEstablecimiento = GEstableciento.IdEstablecimiento
                    nRecurso.idProyecto = GProyectos.IdProyectoActividad
                    nRecurso.idActividad = GProyectos.IdProyecto
                    nRecurso.unidadMedida = i.Cells(3).Value
                    nRecurso.tipoActividad = "PY"
                    nRecurso.fechaIngreso = DateTime.Now
                    nRecurso.TipoRecurso = tipRec
                    nRecurso.cuentaContable = tipoCuenta
                    nRecurso.Clasificacion = i.Cells(28).Value
                    nRecurso.Descripcion = i.Cells(1).Value
                    nRecurso.detalleExtra = i.Cells(2).Value
                    nRecurso.ReferenciaSustento = i.Cells(27).Value
                    nRecurso.ValorMercadoPu = CDec(i.Cells(26).Value)
                    nRecurso.CantRequerida = CDec(i.Cells(25).Value)
                    'nRecurso.Costo = CDec(i.Cells(22).Value)

                    Select Case i.Cells(27).Value
                        Case TipoReferenciaSustento.COSTO_IGV
                            nRecurso.Costo = Math.Round(CDec(i.Cells(24).Value) / 1.18, 2)
                            nRecurso.NoSustentado = 0
                            nRecurso.Igv = Math.Round((CDec(i.Cells(24).Value) / 1.18) * 0.18, 2)
                        Case TipoReferenciaSustento.SOLO_COSTO
                            nRecurso.Costo = Math.Round(CDec(i.Cells(24).Value), 2)
                            nRecurso.NoSustentado = 0
                            nRecurso.Igv = 0
                        Case TipoReferenciaSustento.NO_SUSTENTADO
                            nRecurso.NoSustentado = CDec(i.Cells(24).Value)
                            nRecurso.Igv = 0
                            nRecurso.Costo = 0
                    End Select
                    nRecurso.TotalCosto = CDec(i.Cells(24).Value)
                    nRecurso.Total = CDec(i.Cells(24).Value)
                    nRecurso.NetoPagar = CDec(i.Cells(24).Value)
                    nRecurso.PorIgv = CDec(i.Cells(18).Value)
                    nRecurso.TipoPresupuesto = "INCIDENCIA DIRECTA"
                    nRecurso.tipoPlan = "A"
                    nRecurso.Sustentado = "C"

                    nRecurso.actividadRecursoCalculo = New actividadRecursoCalculo()
                    With nRecurso.actividadRecursoCalculo
                        .laborDiaria = CDec(i.Cells(4).Value)
                        .hm = CDec(i.Cells(5).Value)
                        .porcentaje = CDec(i.Cells(6).Value)
                        .dias = CDec(i.Cells(7).Value)
                        .costoUnithh = CDec(i.Cells(8).Value)
                        .cant = CDec(i.Cells(9).Value)
                        .costoUnit = CDec(i.Cells(10).Value)
                        .costoDirecto1 = CDec(i.Cells(11).Value)
                        .costoDirecto2 = CDec(i.Cells(12).Value)
                        .ggPorc = CDec(i.Cells(13).Value)
                        .ggImporte = CDec(i.Cells(14).Value)
                        .utPorc = CDec(i.Cells(15).Value)
                        .utImporte = CDec(i.Cells(16).Value)
                        .costoFinal = CDec(i.Cells(17).Value)
                        .igvPorc = CDec(i.Cells(18).Value)
                        .igvImporte = CDec(i.Cells(19).Value)
                        .precioFinal = CDec(i.Cells(24).Value)
                        .cantFinal = CDec(i.Cells(25).Value)
                        .precUnitFinal = CDec(i.Cells(26).Value)
                    End With
                    'LIQUIDACION INSERT
                    objLiquidacionDet = New totalesLiquidacion()

                    objLiquidacionDet.idEmpresa = Gempresas.IdEmpresaRuc
                    objLiquidacionDet.idEstablecimiento = GEstableciento.IdEstablecimiento
                    objLiquidacionDet.idActividad = GProyectos.IdProyecto
                    objLiquidacionDet.tipoLiquidacion = "INCIDENCIA DIRECTA"
                    objLiquidacionDet.Otros = "CADIN"
                    objLiquidacionDet.modulo = "N"
                    objLiquidacionDet.Fecha = DateTime.Now.Date

                    objLiquidacionDet.LI_ib_ini = 0 ' nudIgv.Value  'IGV
                    objLiquidacionDet.LI_ib_ns = 0 'nudIgv.Value 'IGV
                    objLiquidacionDet.LI_ib_adic = 0 ' nudIgv.Value 'IGV


                    objLiquidacionDet.RefSustento1 = i.Cells(27).Value 'i.LI_cfAcum_ini


                    Select Case i.Cells(27).Value
                        Case TipoReferenciaSustento.COSTO_IGV
                            'PRIMERO(REPORTE)
                            objLiquidacionDet.LI_cfAcum_ini = Math.Round((CDec(i.Cells(24).Value) / 1.18) * 0.18, 2) 'i.LI_cfAcum_ini
                            objLiquidacionDet.LI_cfAcum_ns = Math.Round((CDec(i.Cells(24).Value) / 1.18) * 0.18, 2) ' i.LI_cfAcum_ns
                            objLiquidacionDet.LI_afAcum_adic = Math.Round((CDec(i.Cells(24).Value) / 1.18) * 0.18, 2) ' i.LI_afAcum_adic

                            'segundo(reporte)
                            objLiquidacionDet.LR_costov_ini = Math.Round((CDec(i.Cells(24).Value) / 1.18) + CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value), 2)
                            objLiquidacionDet.LR_costov_ns = Math.Round((CDec(i.Cells(24).Value) / 1.18) + +CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value), 2)
                            objLiquidacionDet.LR_costov_adic = Math.Round((CDec(i.Cells(24).Value) / 1.18) + +CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value), 2)

                            '3er reporte
                            objLiquidacionDet.LOO_ReDeAp_ini = Math.Round(CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value) + CDec(i.Cells(22).Value) + CDec(i.Cells(23).Value), 2)
                            objLiquidacionDet.LOO_ReDeAp_ns = Math.Round(CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value) + CDec(i.Cells(22).Value) + CDec(i.Cells(23).Value), 2)
                            objLiquidacionDet.LOO_ReDeAp_adic = Math.Round(CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value) + CDec(i.Cells(22).Value) + CDec(i.Cells(23).Value), 2)


                            objLiquidacionDet.LOO_ReDeAp_ini = Math.Round(CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value) + CDec(i.Cells(22).Value) + CDec(i.Cells(23).Value), 2)
                            objLiquidacionDet.LOO_ReDeAp_ns = Math.Round(CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value) + CDec(i.Cells(22).Value) + CDec(i.Cells(23).Value), 2)
                            objLiquidacionDet.LOO_ReDeAp_adic = Math.Round(CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value) + CDec(i.Cells(22).Value) + CDec(i.Cells(23).Value), 2)

                            'ANALISIS FINANCIERO
                            objLiquidacionDet.AF_TotalPagoProvSust_ini = CDec(i.Cells(24).Value)
                            objLiquidacionDet.AF_TotalPagoProvSust_ns = CDec(i.Cells(24).Value)
                            objLiquidacionDet.AF_TotalPagoProvSust_adic = CDec(i.Cells(24).Value)
                        Case TipoReferenciaSustento.SOLO_COSTO
                            'PRIMERO(REPORTE)
                            objLiquidacionDet.LI_cfAcum_ini = 0 'i.LI_cfAcum_ini
                            objLiquidacionDet.LI_cfAcum_ns = 0 ' i.LI_cfAcum_ns
                            objLiquidacionDet.LI_afAcum_adic = 0 ' i.LI_afAcum_adic

                            'segundo(reporte)
                            objLiquidacionDet.LR_costov_ini = Math.Round((CDec(i.Cells(24).Value)) + CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value), 2)
                            objLiquidacionDet.LR_costov_ns = Math.Round((CDec(i.Cells(24).Value)) + +CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value), 2)
                            objLiquidacionDet.LR_costov_adic = Math.Round((CDec(i.Cells(24).Value)) + +CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value), 2)
                            '3er reporte
                            objLiquidacionDet.LOO_ReDeAp_ini = Math.Round(CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value) + CDec(i.Cells(22).Value) + CDec(i.Cells(23).Value), 2)
                            objLiquidacionDet.LOO_ReDeAp_ns = Math.Round(CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value) + CDec(i.Cells(22).Value) + CDec(i.Cells(23).Value), 2)
                            objLiquidacionDet.LOO_ReDeAp_adic = Math.Round(CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value) + CDec(i.Cells(22).Value) + CDec(i.Cells(23).Value), 2)

                            'ANALISIS FINANCIERO
                            objLiquidacionDet.AF_TotalPagoProvSust_ini = CDec(i.Cells(24).Value)
                            objLiquidacionDet.AF_TotalPagoProvSust_ns = CDec(i.Cells(24).Value)
                            objLiquidacionDet.AF_TotalPagoProvSust_adic = CDec(i.Cells(24).Value)
                        Case TipoReferenciaSustento.NO_SUSTENTADO
                            objLiquidacionDet.LI_cfAcum_ini = 0 'i.LI_cfAcum_ini
                            objLiquidacionDet.LI_cfAcum_ns = 0 ' i.LI_cfAcum_ns
                            objLiquidacionDet.LI_afAcum_adic = 0 ' i.LI_afAcum_adic
                            'segundo(reporte)
                            objLiquidacionDet.LR_costov_ini = Math.Round(0 + CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value), 2)
                            objLiquidacionDet.LR_costov_ns = Math.Round(0 + +CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value), 2)
                            objLiquidacionDet.LR_costov_adic = Math.Round(0 + +CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value), 2)
                            '3er reporte
                            objLiquidacionDet.LOO_ReDeAp_ini = Math.Round(CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value) + CDec(i.Cells(22).Value) + CDec(i.Cells(23).Value), 2)
                            objLiquidacionDet.LOO_ReDeAp_ns = Math.Round(CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value) + CDec(i.Cells(22).Value) + CDec(i.Cells(23).Value), 2)
                            objLiquidacionDet.LOO_ReDeAp_adic = Math.Round(CDec(i.Cells(20).Value) + CDec(i.Cells(21).Value) + CDec(i.Cells(22).Value) + CDec(i.Cells(23).Value), 2)

                            'ANALISIS FINANCIERO
                            objLiquidacionDet.AF_TotalPagoProvSust_ini = 0.0
                            objLiquidacionDet.AF_TotalPagoProvSust_ns = 0.0
                            objLiquidacionDet.AF_TotalPagoProvSust_adic = 0.0
                    End Select

                    'no sustentados
                    If (i.Cells(27).Value = "NO SUSTENTADO") Then
                        objLiquidacionDet.AF_RefGastoNoSust_ini = CDec(i.Cells(24).Value)
                    Else
                        objLiquidacionDet.AF_RefGastoNoSust_ini = 0
                    End If

                    If (i.Cells(27).Value = "NO SUSTENTADO") Then
                        objLiquidacionDet.AF_RefGastoNoSust_ns = CDec(i.Cells(24).Value)
                    Else
                        objLiquidacionDet.AF_RefGastoNoSust_ns = 0
                    End If

                    'objLiquidacionDet.AF_RefGastoNoSust_ns = nudNoSustenta.Value
                    '     objLiquidacionDet.AF_RefGastoNoSust_adic = nudNoSustenta.Value

                    objLiquidacionDet.LP_TotalPagoProvCSSust_ini = CDec(i.Cells(24).Value)
                    objLiquidacionDet.LP_TotalPagoProvCSSust_ns = CDec(i.Cells(24).Value)
                    objLiquidacionDet.LP_TotalPagoProvCSSust_adic = CDec(i.Cells(24).Value)

                    objLiquidacionDet.tipoPlan = "A"

                    objLiquidacionDet.usuarioActualizacion = "NN"
                    objLiquidacionDet.fechaActualizacion = DateTime.Now
                    ListaLiquidacion.Add(objLiquidacionDet)
                    ListaRecurso.Add(nRecurso)
                Next
            End If
          
            nRecursoSA.SaveListaRecurso(ListaRecurso, ListaRecursoGasto, ListaRecursoEDT, ListaLiquidacion)
            lblEstado.Text = "Cotización procesada"
            lblEstado.Image = My.Resources.ok4
            dgvGastos.Rows.Clear()
            dgvImportar.Rows.Clear()
            dgvEDT.Rows.Clear()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.cross
        End Try
    End Sub

    Public Sub UbicarProyectoID(intIdProyecto As Integer)
        Dim proyectoSA As New ProyectoPlaneacionSA
        Dim TrabSA As New Trabajador_PLSA
        Dim Trab As New Trabajador_PL
        Dim proyecto As New ProyectoPlaneacion
        proyecto = proyectoSA.UbicarProyecto(intIdProyecto)
        If Not IsNothing(proyecto) Then
            txtPropuesta.Text = proyecto.nombreProyecto
            Trab = TrabSA.UbicarTrabDNI(proyecto.responsable, proyecto.idEstablecimiento)
            txtDirector.Text = Trab.appat & " " & Trab.apmat & ", " & Trab.nombres
        End If
    End Sub

    Sub CargarExcel()
        Dim strDestination As String = Nothing
        Dim productoSA As New detalleitemsSA()
        Dim productoBE As New detalleitems
        Dim dlgResult As DialogResult
        Try
            dgvImportar.Rows.Clear()
            'Show dialog
            With OpenFileDialog1
                .Filter = "Microsoft Excel 2003|*.xls;*.xlsx" ' "All Files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|XLS Files (*.xls)|*xls" '
                '  .ShowDialog()
                dlgResult = .ShowDialog
                strDestination = .FileName
                '  txtRuta.Text = strDestination
            End With
            'If (strDestination <> "OpenFileDialog1") Then
            If dlgResult <> Windows.Forms.DialogResult.Cancel Then
                Dim fileName = strDestination ' "C:\Users\Jiuni\Desktop\CArpeta Compartida\SERVER NET\Name2.xls" '
                Dim book = New LinqToExcel.ExcelQueryFactory(fileName)
                Dim users = From x In book.Worksheet(Of Insumos)() _
                            Select x
                For Each i In users
                    If CStr(i.Decripcion.Trim.Length > 0) Then
                        productoBE = productoSA.InvocarProductoNombre(i.Decripcion, Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
                        If Not IsNothing(productoBE) Then
                            dgvImportar.Rows.Add(productoBE.idItem, i.Decripcion,
                                  i.Extra, i.Unidad, i.LaborDiaria,
                                  i.CantHM, i.Porc, i.Dias, i.CostoHM, i.Cantidad, i.CostoUnitario,
                                  i.CostoDirecto1, i.CostoDirecto2, i.GGPorc, i.GGImporte, i.UTPorc, i.UTtImporte,
                                  i.CostoFinal, i.IgvPorc, i.IgvImporte, i.OtrosAportes, i.PlanillaAporte, i.OtrosDeduccion,
                                  i.PlanillaDeduccion, i.PrecioFinal, i.CantidadFinal,
                                  i.PrecioUnitFinal, i.Sustento, i.Clasificacion, i.tipoRecurso)
                        Else
                            dgvImportar.Rows.Add("0", i.Decripcion,
                               i.Extra, i.Unidad, i.LaborDiaria,
                               i.CantHM, i.Porc, i.Dias, i.CostoHM, i.Cantidad, i.CostoUnitario,
                               i.CostoDirecto1, i.CostoDirecto2, i.GGPorc, i.GGImporte, i.UTPorc, i.UTtImporte,
                               i.CostoFinal, i.IgvPorc, i.IgvImporte, i.OtrosAportes, i.PlanillaAporte, i.OtrosDeduccion,
                               i.PlanillaDeduccion, i.PrecioFinal, i.CantidadFinal,
                               i.PrecioUnitFinal, i.Sustento, i.Clasificacion, i.tipoRecurso)
                        End If

                    End If
                Next
                lblRows.Text = dgvImportar.Rows.Count & " fila(s)"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' Dim fileName = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "names.xls")


    End Sub

    Sub CargarExcelGasto()
        Dim strDestination As String = Nothing
        Dim productoSA As New detalleitemsSA()
        Dim productoBE As New detalleitems
        Dim dlgResult As DialogResult


        Try
            dgvGastos.Rows.Clear()

            'Show dialog

            With OpenFileDialog1
                .Filter = "Microsoft Excel 2003|*.xls;*.xlsx" ' "All Files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|XLS Files (*.xls)|*xls" '
                '  .ShowDialog()
                dlgResult = .ShowDialog
                strDestination = .FileName
                '  txtRuta.Text = strDestination
            End With
            'If (strDestination <> "OpenFileDialog1") Then
            If dlgResult <> Windows.Forms.DialogResult.Cancel Then
                Dim Costo, NoSustenta, Porcentaje, IGV, Total, TotalCosto As Decimal
                Dim fileName = strDestination ' "C:\Users\Jiuni\Desktop\CArpeta Compartida\SERVER NET\Name2.xls" '
                Dim book = New LinqToExcel.ExcelQueryFactory(fileName)
                Dim users = From x In book.Worksheet(Of gasto)() _
                            Select x

                For Each i In users
                    Select Case i.Sustento


                        Case TipoReferenciaSustento.COSTO_IGV
                            TotalCosto = Math.Round(i.Cantidad * i.Pu, 2)
                            Costo = Math.Round(TotalCosto / 1.18, 2)
                            NoSustenta = 0
                            Porcentaje = 0
                            IGV = Math.Round(Costo * 0.18, 2)
                            Total = Math.Round(Costo + IGV + NoSustenta + Porcentaje, 2)

                            If CStr(i.Decripcion.Trim.Length > 0) Then
                                dgvGastos.Rows.Add(0, i.Decripcion,
                                          i.Extra, i.Unidad, i.Cantidad,
                                          i.Pu, i.Cantidad * i.Pu,
                                          0, 0, 0,
                                          i.Cantidad * i.Pu, 0, 0, 0,
                                          0, i.Sustento, 18.0,
                                          Costo, NoSustenta, Porcentaje, IGV, 0, Total, i.Clasificacion, i.TipoRecurso)
                            End If
                        Case TipoReferenciaSustento.SOLO_COSTO
                            TotalCosto = Math.Round(i.Cantidad * i.Pu, 2)
                            Costo = Math.Round(TotalCosto, 2)
                            NoSustenta = 0
                            Porcentaje = 0
                            IGV = 0
                            Total = Math.Round(Costo + IGV + NoSustenta + Porcentaje, 2)
                            If CStr(i.Decripcion.Trim.Length > 0) Then
                                dgvGastos.Rows.Add(0, i.Decripcion,
                                          i.Extra, i.Unidad, i.Cantidad,
                                          i.Pu, i.Cantidad * i.Pu,
                                          0, 0, 0,
                                          i.Cantidad * i.Pu, 0, 0, 0,
                                          0, i.Sustento, 18.0,
                                          Costo, NoSustenta, Porcentaje, IGV, 0, Total, i.Clasificacion, i.TipoRecurso)
                            End If
                        Case TipoReferenciaSustento.NO_SUSTENTADO
                            TotalCosto = Math.Round(i.Cantidad * i.Pu, 2)
                            Costo = 0
                            NoSustenta = TotalCosto
                            Porcentaje = 0
                            IGV = 0
                            Total = Math.Round(Costo + IGV + NoSustenta + Porcentaje, 2)
                            If CStr(i.Decripcion.Trim.Length > 0) Then
                                dgvGastos.Rows.Add(0, i.Decripcion,
                                          i.Extra, i.Unidad, i.Cantidad,
                                          i.Pu, i.Cantidad * i.Pu,
                                          0, 0, 0,
                                          i.Cantidad * i.Pu, 0, 0, 0,
                                          0, i.Sustento, 18.0,
                                          Costo, NoSustenta, Porcentaje, IGV, 0, Total, i.Clasificacion, i.TipoRecurso)
                            End If
                    End Select
                Next
                lblRowsGasto.Text = dgvGastos.Rows.Count & " fila(s)"

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub CargarExcelEDT()
        Dim strDestination As String = Nothing
        Dim dlgResult As DialogResult


        Try
            dgvEDT.Rows.Clear()
            'Show dialog

            With OpenFileDialog1
                .Filter = "Microsoft Excel 2003|*.xls;*.xlsx" ' "All Files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|XLS Files (*.xls)|*xls" '
                '  .ShowDialog()
                dlgResult = .ShowDialog
                strDestination = .FileName
                '  txtRuta.Text = strDestination
            End With
            'If (strDestination <> "OpenFileDialog1") Then
            If dlgResult <> Windows.Forms.DialogResult.Cancel Then
                Dim DiasAtraso As Integer
                Dim fileName = strDestination ' "C:\Users\Jiuni\Desktop\CArpeta Compartida\SERVER NET\Name2.xls" '
                Dim book = New LinqToExcel.ExcelQueryFactory(fileName)
                Dim users = From x In book.Worksheet(Of Entregable)() _
                            Select x

                For Each i In users
                    DiasAtraso = ((Date.Now.Date) - (i.FechaEntregable)).TotalDays
                    If CStr(i.concepto.Trim.Length > 0) Then
                        dgvEDT.Rows.Add(0, i.nroEntregable, i.concepto, i.dniResponsable,
                                  i.nomResponsable, i.apPatResponsable, i.apMatResponsable,
                                  i.FechaEntregable, DiasAtraso, i.Descripcion)
                    End If
                Next
                lblRowEDT.Text = dgvEDT.Rows.Count & " fila(s)"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dispose()
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        GrabarCotizacion()
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Cursor = Cursors.WaitCursor
        Call CargarExcel()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        Me.Cursor = Cursors.WaitCursor
        Call CargarExcelGasto()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton5.Click
        Me.Cursor = Cursors.WaitCursor
        Call CargarExcelEDT()
        With frmActaConstitucionMaster
            .lblAprobado.Enabled = True
        End With
        Me.Cursor = Cursors.Arrow
    End Sub
End Class
