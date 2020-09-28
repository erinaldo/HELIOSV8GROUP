Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmPlanGestionProyecto

#Region "Métodos"
    Sub FasesShow(intIdPadre As Integer, strModulo As String, strFlag As String)
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        With frmModalActividadPorProyecto
            Select Case strModulo
                Case TIPO_ACTIVIDAD_MODULO.FASE
                    .lblTitulo.Text = "FASE"
                Case TIPO_ACTIVIDAD_MODULO.ENTREGABLE
                    .lblTitulo.Text = "ENTREGABLE"
                Case TIPO_ACTIVIDAD_MODULO.ACTIVIDAD
                    .lblTitulo.Text = "ACTIVIDAD"
                Case TIPO_ACTIVIDAD_MODULO.PROYECTO
                    .lblTitulo.Text = "PROYECTO"
            End Select

            .ListaModal(intIdPadre, strModulo, strFlag)
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                GModoTRabajos = New GModoTrabajo
                GModoTRabajos.IdActividad = datos(0).ID
                GModoTRabajos.NombreActividad = datos(0).NombreEntidad
            End If
        End With
        Me.Cursor = Cursors.Arrow
    End Sub


    Sub TrabajadoresShow()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        'With frmModalTrab
        '    .lblTipo.Text = TIPO_ENTIDAD.PERSONAL_PLANILLA
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtIdResponsable.Text = datos(0).ID
        '        txtResponsable.Text = datos(0).NombreEntidad
        '    Else
        '        txtIdResponsable.Text = String.Empty
        '        txtResponsable.Text = String.Empty
        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Public Sub ObtenerListaEDT(strTipoModulo As String, strFlag As String)
        Dim ActividadSA As New ActividadesSA
        Try
            dgvEDT.Rows.Clear()
            For Each i In ActividadSA.GetListaActividadPorProyecto(GProyectos.IdProyectoActividad, strTipoModulo, strFlag)
                dgvEDT.Rows.Add(i.idActividad, i.idEmpresa, i.idEstablecimiento,
                                i.idProyecto, i.NombreActividad, i.descripcion,
                                i.modulo, i.responsable, i.nombreTrab,
                                FormatDateTime(i.FechaInicio.Value, DateFormat.ShortDate), i.Dias, i.Observacion)
            Next
            lblRowsEDT.Text = "Filas: " & dgvEDT.Rows.Count
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Public Sub ObtenerListaActividades(strTipoModulo As String, strFlag As String)
        Dim ActividadSA As New ActividadesSA
        Try
            dgvActividad.Rows.Clear()
            For Each i In ActividadSA.GetListaActividadPorProyecto(GProyectos.IdProyectoActividad, strTipoModulo, strFlag)
                dgvActividad.Rows.Add(i.idActividad, i.NombreActividad, i.responsable, i.nombreTrab, FormatDateTime(i.FechaInicio.Value, DateFormat.ShortDate), FormatDateTime(i.FechaFinal.Value, DateFormat.ShortDate))
            Next
            lblRowsActividad.Text = "Filas: " & dgvActividad.Rows.Count
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Public Sub ObtenerFases(strTipoModulo As String, strFlag As String)
        Dim ActividadSA As New ActividadesSA
        Try
            dgvFases.Rows.Clear()
            For Each i In ActividadSA.GetListaActividadPorProyecto(GProyectos.IdProyectoActividad, strTipoModulo, strFlag)
                dgvFases.Rows.Add(i.idActividad, i.NombreActividad)
            Next
            lblFilaFAses.Text = "Filas: " & dgvFases.Rows.Count
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Public Sub ObtenerListaGasto(strTipoRecurso As String, stridActividad As Integer)
        Dim recursoSA As New actividadRecursoSA
        Try
            dgvGastos.Rows.Clear()
            For Each i In recursoSA.GetListaGastoPlaneacion(GProyectos.IdProyecto, strTipoRecurso, stridActividad)
                dgvGastos.Rows.Add(i.fechaIngreso.Value.Date, i.idActividadRecurso, i.Descripcion, i.detalleExtra, i.unidadMedida, i.TipoRecurso, i.CantRequerida,
                                      i.ValorMercadoPu, i.TotalCosto, i.OtrosDeduc, i.DeducPlanilla,
                                      i.TotalDeduc, i.NetoPagar, i.Otros1,
                                      i.AporPlanilla, i.TotalAporte, i.TotalRetenciones, i.ReferenciaSustento, i.PorIgv,
                                      i.Costo, i.NoSustentado, i.Porcentaje, i.Igv, i.PsptoReferencial, i.Total, i.Clasificacion)
            Next
            lblRowsGasto.Text = "Filas: " & dgvGastos.Rows.Count
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Public Sub GetListaGPlaneacionIngreso(strTipoRecurso As String, stridActividad As Integer)
        Dim recursoSA As New actividadRecursoSA
        Try
            dgvIngresos.Rows.Clear()
            For Each i In recursoSA.GetListaGPlaneacionIngreso(GProyectos.IdProyecto, strTipoRecurso, stridActividad)

                dgvIngresos.Rows.Add(i.fechaIngreso.Value.Date, i.idActividadRecurso, i.Descripcion, i.detalleExtra, i.unidadMedida,
                                     i.TipoRecurso, i.CantRequerida, i.ValorMercadoPu, i.CostoDirecto, i.PorGastosGenerales,
                                     i.GastosGenerales, i.PorUtilidad, i.Utilidad, i.OtrosIn1, i.ValorVenta,
                                     i.PorIgv, i.Igv, i.TotalProyecto, i.PorPercep, i.Percepciones,
                                     i.OtrosIn2, i.TotalPorCobrar, i.PorDetracciones, i.Detracciones,
                                     i.PorRetenciones, i.Retenciones, i.OtroIn3, i.NetoCobrar, i.Porcentaje)

            Next
            ToolStripLabel3.Text = "Filas: " & dgvIngresos.Rows.Count
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Public Sub ObtenerListaCotizacion(strTipoRecurso As String)
        Dim recursoSA As New actividadRecursoSA
        Try
            dgvGastos.Rows.Clear()
            For Each i In recursoSA.ListaRecursosCotizacionGastoFinal(GProyectos.IdProyecto, strTipoRecurso, "C")

                dgvGastos.Rows.Add(i.fechaIngreso.Value.Date, i.idActividadRecurso, i.Descripcion, i.detalleExtra, i.unidadMedida, i.TipoRecurso, i.CantRequerida,
                                      i.ValorMercadoPu, i.TotalCosto, i.OtrosDeduc, i.DeducPlanilla,
                                      i.TotalDeduc, i.NetoPagar, i.Otros1,
                                      i.AporPlanilla, i.TotalAporte, i.TotalRetenciones, i.ReferenciaSustento, i.PorIgv,
                                      i.Costo, i.NoSustentado, i.Porcentaje, i.Igv, i.PsptoReferencial, i.Total)
            Next
            For Each i In recursoSA.ListaRecursosGastosFinal(GProyectos.IdProyecto, strTipoRecurso, "G")
                dgvGastos.Rows.Add(i.fechaIngreso.Value.Date, i.idActividadRecurso, i.Descripcion, i.detalleExtra, i.unidadMedida, i.TipoRecurso, i.CantRequerida,
                                      i.ValorMercadoPu, i.TotalCosto, i.OtrosDeduc, i.DeducPlanilla,
                                      i.TotalDeduc, i.NetoPagar, i.Otros1,
                                      i.AporPlanilla, i.TotalAporte, i.TotalRetenciones, i.ReferenciaSustento, i.PorIgv,
                                      i.Costo, i.NoSustentado, i.Porcentaje, i.Igv, i.PsptoReferencial, i.Total)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub eliminarEDT(intIdFila As Integer, dg As DataGridView)

        Dim actividadSA As New ActividadesSA
        Dim actividad As New Actividades
        Try
            actividad = New Actividades With {
            .Action = Business.Entity.BaseBE.EntityAction.INSERT,
            .idActividad = intIdFila}

            If (actividadSA.DeleteEDT(actividad)) Then

                dg.Rows.RemoveAt(dg.CurrentRow.Index)
                'dgvGastos.Rows.Remove(dgvEDT.SelectedRows(0))
            Else
                lblEstado.Text = "Error al Eliminar EDT"
                lblEstado.Image = My.Resources.cross
            End If

        Catch ex As Exception
            lblEstado.Text = "Error al Eliminar" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try

    End Sub

    Sub Grabar()
        Dim intIdRecursoActividad As Integer
        Dim actividadSA As New ActividadesSA
        Dim actividad As New Actividades
        Try
            actividad = New Actividades With {
            .Action = Business.Entity.BaseBE.EntityAction.INSERT,
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .idProyecto = GProyectos.IdProyectoActividad,
            .idActividad = GProyectos.IdProyecto,
            .NombreActividad = txtFase.Text.Trim,
            .idPadre = GProyectos.IdProyecto,
            .responsable = Nothing,
            .modulo = TIPO_ACTIVIDAD_MODULO.FASE,
            .descripcion = txtFase.Text.Trim,
            .Dias = Nothing,
            .FechaInicio = Nothing,
            .Observacion = Nothing,
            .Estado = "SA",
            .flag = "AP",
            .usuarioActualizacion = "NN",
            .fechaActualizacion = DateTime.Now}
            intIdRecursoActividad = actividadSA.InsertarEDT(actividad)
            If intIdRecursoActividad <> Nothing Then
                lblEstado.Text = "Fase registrada"
                lblEstado.Image = My.Resources.ok4
                PanelFase.Height = 0
                With dgvFases.Rows
                    .Add(actividad.idActividad, actividad.NombreActividad)
                End With
            Else
                lblEstado.Text = "Error al grabar Fase!"
                lblEstado.Image = My.Resources.cross
            End If

        Catch ex As Exception
            lblEstado.Text = "Error al grabar EDT" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try
    End Sub

    Sub GrabarActividad()
        Dim intIdRecursoActividad As Integer
        Dim actividadSA As New ActividadesSA
        Dim actividad As New Actividades
        Try
            actividad = New Actividades With {
            .Action = Business.Entity.BaseBE.EntityAction.INSERT,
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .idProyecto = GProyectos.IdProyectoActividad,
            .idActividad = GProyectos.IdProyecto,
            .NombreActividad = txtNomActividad.Text.Trim,
            .idPadre = GProyectos.IdProyecto,
            .responsable = txtIdResponsable.Text.Trim,
            .modulo = TIPO_ACTIVIDAD_MODULO.ACTIVIDAD,
            .descripcion = txtNomActividad.Text.Trim,
            .Dias = Nothing,
            .FechaInicio = txtInicioAct.Value,
            .FechaFinal = txtFinAct.Value,
            .Estado = "SA",
            .Observacion = Nothing,
            .usuarioActualizacion = "NN",
            .flag = "AP",
            .fechaActualizacion = DateTime.Now}
            intIdRecursoActividad = actividadSA.InsertarEDT(actividad)
            If intIdRecursoActividad <> Nothing Then
                lblEstado.Text = "Actividad registrada"
                lblEstado.Image = My.Resources.ok4
                PanelActividad.Height = 0
                With dgvActividad.Rows
                    .Add(actividad.idActividad, actividad.NombreActividad, actividad.responsable, txtResponsable.Text, actividad.FechaInicio, actividad.FechaFinal)
                End With
            Else
                lblEstado.Text = "Error al grabar actividad!"
                lblEstado.Image = My.Resources.cross
            End If

        Catch ex As Exception
            lblEstado.Text = "Error al grabar actividad" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try
    End Sub

    Sub EditarActividad()
        Dim intIdRecursoActividad As Integer
        Dim actividadSA As New ActividadesSA
        Dim actividad As New Actividades
        Try
            actividad = New Actividades With {
            .Action = Business.Entity.BaseBE.EntityAction.INSERT,
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .idProyecto = GProyectos.IdProyectoActividad,
            .idActividad = dgvActividad.Item(0, dgvActividad.CurrentRow.Index).Value,
            .NombreActividad = txtNomActividad.Text.Trim,
            .idPadre = GProyectos.IdProyecto,
            .responsable = txtIdResponsable.Text.Trim,
            .modulo = TIPO_ACTIVIDAD_MODULO.ACTIVIDAD,
            .descripcion = txtNomActividad.Text.Trim,
            .Dias = Nothing,
            .FechaInicio = txtInicioAct.Value,
            .FechaFinal = txtFinAct.Value,
            .Observacion = Nothing,
            .flag = "AP",
            .usuarioActualizacion = "NN",
            .fechaActualizacion = DateTime.Now}
            intIdRecursoActividad = actividadSA.UpdateEDT(actividad)
            If intIdRecursoActividad <> Nothing Then
                lblEstado.Text = "Actividad modificada"
                lblEstado.Image = My.Resources.ok4
                PanelActividad.Height = 0
                With dgvActividad
                    .Item(1, .CurrentRow.Index).Value = actividad.NombreActividad
                    .Item(2, .CurrentRow.Index).Value = actividad.responsable
                    .Item(3, .CurrentRow.Index).Value = txtResponsable.Text
                    .Item(4, .CurrentRow.Index).Value = actividad.FechaInicio
                    .Item(5, .CurrentRow.Index).Value = actividad.FechaFinal
                End With
            Else
                lblEstado.Text = "Error al modificar actividad!"
                lblEstado.Image = My.Resources.cross
            End If

        Catch ex As Exception
            lblEstado.Text = "Error al modificar Actividad" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try
    End Sub

    Sub EditarFase()
        Dim intIdRecursoActividad As Integer
        Dim actividadSA As New ActividadesSA
        Dim actividad As New Actividades
        Try
            actividad = New Actividades With {
            .Action = Business.Entity.BaseBE.EntityAction.INSERT,
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .idProyecto = GProyectos.IdProyectoActividad,
            .idActividad = lblIdFase.Text,
            .NombreActividad = txtFase.Text.Trim,
            .idPadre = GProyectos.IdProyecto,
            .responsable = Nothing,
            .modulo = TIPO_ACTIVIDAD_MODULO.FASE,
            .descripcion = txtFase.Text.Trim,
            .Dias = Nothing,
            .FechaInicio = Nothing,
            .Observacion = Nothing,
            .flag = "AP",
            .usuarioActualizacion = "NN",
            .fechaActualizacion = DateTime.Now}
            intIdRecursoActividad = actividadSA.UpdateEDT(actividad)
            If intIdRecursoActividad <> Nothing Then
                lblEstado.Text = "Fase modificada"
                lblEstado.Image = My.Resources.ok4
                PanelFase.Height = 0
                With dgvFases
                    '   .Item(0, .CurrentRow.Index).Value = actividad.idActividad
                    .Item(1, .CurrentRow.Index).Value = actividad.NombreActividad
                End With

                'Dispose()
            Else
                lblEstado.Text = "Error al grabar Fase!"
                lblEstado.Image = My.Resources.cross
            End If

        Catch ex As Exception
            lblEstado.Text = "Error al grabar EDT" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try
    End Sub

    Public Sub EliminarRegistroLiquidacionPlanificacion(ByVal strCodigo As String, strRefSustento As String, dgv As DataGridView)
        Dim objActividadEO As New totalesLiquidacion()
        Dim objLiquidacionSA As New totalesLiquidacionSA
        Dim ILiquidacion As New actividadRecurso

        Dim actividadSA As New actividadRecursoSA
        Try

            ILiquidacion = actividadSA.UbicaRecursoID(strCodigo)

            With objActividadEO
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .idActividad = GModoTRabajos.IdActividad
                .secuencia = strCodigo

                .LI_cfAcum_ini = ILiquidacion.Igv ' dgvCadenaSum.Item(22, dgvCadenaSum.CurrentRow.Index).Value
                .LI_cfAcum_ns = ILiquidacion.Igv ' dgvCadenaSum.Item(22, dgvCadenaSum.CurrentRow.Index).Value
                .LI_afAcum_adic = ILiquidacion.Igv 'dgvCadenaSum.Item(22, dgvCadenaSum.CurrentRow.Index).Value

                'Dim suma As Decimal = 0
                'suma = Math.Round(dgvCadenaSum.Item(19, dgvCadenaSum.CurrentRow.Index).Value + dgvCadenaSum.Item(28, dgvCadenaSum.CurrentRow.Index).Value + dgvCadenaSum.Item(29, dgvCadenaSum.CurrentRow.Index).Value, 2)

                .LR_costov_ini = Math.Round(CDec(ILiquidacion.Costo) + 0 + 0, 2) '  suma
                .LR_costov_ns = Math.Round(CDec(ILiquidacion.Costo) + 0 + 0, 2) ' suma
                .LR_costov_adic = Math.Round(CDec(ILiquidacion.Costo) + 0 + 0, 2) '  suma

                '3ER REPORTE
                .LOO_ReDeAp_ini = 0 ' ILiquidacion.LOO_ReDeAp_ini ' dgvCadenaSum.Item(31, dgvCadenaSum.CurrentRow.Index).Value
                .LOO_ReDeAp_ns = 0 ' ILiquidacion.LOO_ReDeAp_ns 'dgvCadenaSum.Item(31, dgvCadenaSum.CurrentRow.Index).Value
                .LOO_ReDeAp_adic = 0 'ILiquidacion.LOO_ReDeAp_adic 'dgvCadenaSum.Item(31, dgvCadenaSum.CurrentRow.Index).Value

                Select Case strRefSustento

                    Case TipoReferenciaSustento.COSTO_IGV, TipoReferenciaSustento.SOLO_COSTO
                        .AF_TotalPagoProvSust_ini = ILiquidacion.NetoPagar ' dgvCadenaSum.Item(27, dgvCadenaSum.CurrentRow.Index).Value 'NETO PAGAR
                        .AF_TotalPagoProvSust_ns = ILiquidacion.NetoPagar ' dgvCadenaSum.Item(27, dgvCadenaSum.CurrentRow.Index).Value
                        .AF_TotalPagoProvSust_adic = ILiquidacion.NetoPagar ' dgvCadenaSum.Item(27, dgvCadenaSum.CurrentRow.Index).Value

                    Case TipoReferenciaSustento.NO_SUSTENTADO
                        .AF_TotalPagoProvSust_ini = 0
                        .AF_TotalPagoProvSust_ns = 0
                        .AF_TotalPagoProvSust_adic = 0

                        'NO SUSTENTADOS
                        .AF_RefGastoNoSust_ini = ILiquidacion.NoSustentado ' dgvCadenaSum.Item(20, dgvCadenaSum.CurrentRow.Index).Value
                        .AF_RefGastoNoSust_ns = ILiquidacion.NoSustentado ' dgvCadenaSum.Item(20, dgvCadenaSum.CurrentRow.Index).Value
                        '  .AF_RefGastoNoSust_adic = dgvCadenaSum.Item(20, dgvCadenaSum.CurrentRow.Index).Value
                End Select
                'ANALISIS FINANCIERO

                .LP_TotalPagoProvCSSust_ini = ILiquidacion.NetoPagar ' dgvCadenaSum.Item(27, dgvCadenaSum.CurrentRow.Index).Value
                .LP_TotalPagoProvCSSust_ns = ILiquidacion.NetoPagar ' dgvCadenaSum.Item(27, dgvCadenaSum.CurrentRow.Index).Value
                .LP_TotalPagoProvCSSust_adic = ILiquidacion.NetoPagar ' dgvCadenaSum.Item(27, dgvCadenaSum.CurrentRow.Index).Value

                .tipoPlan = "B"
                .tipoLiquidacion = "INCIDENCIA DIRECTA"
                .Otros = "CADIN"
            End With
            objLiquidacionSA.GetEliminarLiquidacion(objActividadEO)
            lblEstado.Text = "registro eliminado!"
            lblEstado.Image = My.Resources.ok4
            dgvGastos.Rows.RemoveAt(dgvGastos.CurrentRow.Index)
        Catch ex As Exception
            MsgBox("Error al eliminar registro." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del sistema")
        End Try

    End Sub

    Public Sub eliminarING(ByVal strCodigo As String)
        Dim objActividadEO As New totalesLiquidacion()
        Dim objLiquidacionSA As New totalesLiquidacionSA
        Dim ILiquidacion As New actividadRecurso

        Dim actividadSA As New actividadRecursoSA

        Try
            ILiquidacion = actividadSA.UbicaRecursoID(strCodigo)


            With objActividadEO
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .idActividad = GModoTRabajos.IdActividad
                .secuencia = strCodigo

                .LI_ib_ini = dgvIngresos.Item(16, dgvIngresos.CurrentRow.Index).Value
                .LI_ib_ns = dgvIngresos.Item(16, dgvIngresos.CurrentRow.Index).Value
                .LI_ib_adic = dgvIngresos.Item(16, dgvIngresos.CurrentRow.Index).Value

                .LR_ventan_ini = dgvIngresos.Item(14, dgvIngresos.CurrentRow.Index).Value
                .LR_ventan_ns = dgvIngresos.Item(14, dgvIngresos.CurrentRow.Index).Value
                .LR_ventan_adic = dgvIngresos.Item(14, dgvIngresos.CurrentRow.Index).Value

                .detraccion_ini = dgvIngresos.Item(23, dgvIngresos.CurrentRow.Index).Value
                .detraccion_ns = dgvIngresos.Item(23, dgvIngresos.CurrentRow.Index).Value
                .detraccion_adic = dgvIngresos.Item(23, dgvIngresos.CurrentRow.Index).Value

                'ANALISIS FINANCIERO
                '---------------------------------------------------------------------------------
                .AF_EjecucionIng_ini = CDec(dgvIngresos.Item(17, dgvIngresos.CurrentRow.Index).Value) 'TOTAL PROYECTO
                .AF_EjecucionIng_ns = CDec(dgvIngresos.Item(17, dgvIngresos.CurrentRow.Index).Value)
                .AF_EjecucionIng_adic = CDec(dgvIngresos.Item(17, dgvIngresos.CurrentRow.Index).Value)

                .AF_Percepcion_ini = dgvIngresos.Item(19, dgvIngresos.CurrentRow.Index).Value 'PERCEPCIONES
                .AF_Percepcion_ns = dgvIngresos.Item(19, dgvIngresos.CurrentRow.Index).Value
                .AF_Percepcion_adic = dgvIngresos.Item(19, dgvIngresos.CurrentRow.Index).Value

                .AF_Otrosps_ini = dgvIngresos.Item(20, dgvIngresos.CurrentRow.Index).Value 'OTROS (+)
                .AF_Otrosps_ns = dgvIngresos.Item(20, dgvIngresos.CurrentRow.Index).Value
                .AF_Otrosps_adic = dgvIngresos.Item(20, dgvIngresos.CurrentRow.Index).Value

                .AF_Detraccion_ini = dgvIngresos.Item(23, dgvIngresos.CurrentRow.Index).Value 'DETRACCIONES
                .AF_Detraccion_ns = dgvIngresos.Item(23, dgvIngresos.CurrentRow.Index).Value
                .AF_Detraccion_adic = dgvIngresos.Item(23, dgvIngresos.CurrentRow.Index).Value

                .AF_Retencion_ini = dgvIngresos.Item(25, dgvIngresos.CurrentRow.Index).Value 'RETENCIONES
                .AF_Retencion_ns = dgvIngresos.Item(25, dgvIngresos.CurrentRow.Index).Value
                .AF_Retencion_adic = dgvIngresos.Item(25, dgvIngresos.CurrentRow.Index).Value

                .AF_Otrosng_ini = dgvIngresos.Item(26, dgvIngresos.CurrentRow.Index).Value ' OTROS(-)
                .AF_Otrosng_ns = dgvIngresos.Item(26, dgvIngresos.CurrentRow.Index).Value
                .AF_Otrosng_adic = dgvIngresos.Item(26, dgvIngresos.CurrentRow.Index).Value

                .totalIngresos = dgvIngresos.Item(17, dgvIngresos.CurrentRow.Index).Value

                .tipoPlan = "B"
                .tipoLiquidacion = "INGRESOS"
                .Otros = "INGRESOS"

            End With
            objLiquidacionSA.GetEliminarLiquidacion(objActividadEO)
            lblEstado.Text = "registro eliminado!"
            lblEstado.Image = My.Resources.ok4
            dgvIngresos.Rows.RemoveAt(dgvIngresos.CurrentRow.Index)
        Catch ex As Exception
            MsgBox("Error al eliminar registro." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del sistema")
        End Try

    End Sub

#End Region

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dispose()
    End Sub

    Private Sub frmPlanGestionProyecto_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub ToolStripButton8_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton8.Click
        'With frmModalEDT
        '    .limpiarCajas()
        '    .actyon = ENTITY_ACTIONS.INSERT
        '    .XDireccion = TIPO_DIRECCION.PLANIFICACION
        '    .nupHitos.Value = dgvEDT.RowCount + 1
        '    .lblCambiar.Focus()
        '    .txtFechaIEDT.Value = txtInicio.Value
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With
    End Sub

    Private Sub ToolStripButton9_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton9.Click
        If dgvEDT.Rows.Count > 0 Then
            'With frmModalEDT
            '    .actyon = ENTITY_ACTIONS.UPDATE
            '    .XDireccion = TIPO_DIRECCION.PLANIFICACION
            '    .lblId.Text = (dgvEDT.SelectedRows(0).Cells(0).Value)
            '    .nupHitos.Value = (dgvEDT.SelectedRows(0).Cells(4).Value)
            '    .txtConcepto.Text = (dgvEDT.SelectedRows(0).Cells(5).Value)

            '    .txtIdResponsable.Text = (dgvEDT.SelectedRows(0).Cells(7).Value)
            '    .txtDirector.Text = (dgvEDT.SelectedRows(0).Cells(8).Value)
            '    .txtFechaIEDT.Value = (dgvEDT.SelectedRows(0).Cells(9).Value)
            '    '.txtDiasTrabajados.Value = (dgvEDT.SelectedRows(0).Cells(10).Value)
            '    .txtDescripcionEDT.Text = (dgvEDT.SelectedRows(0).Cells(11).Value)
            '    .lblEstado.Text = "Editar Registro"
            '    .StartPosition = FormStartPosition.CenterParent
            '    .ShowDialog()
            'End With
        End If
    End Sub

    Private Sub ToolStripButton10_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton10.Click
        If dgvEDT.Rows.Count > 0 Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                eliminarEDT(dgvEDT.Item(0, dgvEDT.CurrentRow.Index).Value, dgvEDT)
                lblEstado.Text = "EDT Eliminado!"
                lblEstado.Image = My.Resources.ok4
            End If
        Else
            lblEstado.Text = "Debe seleccionar una fila"
            lblEstado.Image = My.Resources.cross
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If txtFase.Text.Trim.Length > 0 Then
            If LinkLabel1.Text = "Agregar nueva fase" Then
                Grabar()
            ElseIf LinkLabel1.Text = "Editar fase" Then
                EditarFase()
            End If
        Else
            lblEstado.Text = "Ingrese una descripción válida.!"
            lblEstado.Image = My.Resources.warning2
        End If
      
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        txtFase.Text = dgvFases.Item(1, dgvFases.CurrentRow.Index).Value
        lblIdFase.Text = dgvFases.Item(0, dgvFases.CurrentRow.Index).Value
        LinkLabel1.Text = "Editar fase"
        PanelFase.Height = 48
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        PanelFase.Height = 0
    End Sub

    Private Sub ToolStripButton3_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        LinkLabel1.Text = "Agregar nueva fase"
        txtFase.Clear()
        PanelFase.Height = 48
    End Sub

    Private Sub frmPlanGestionProyecto_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtProyecto.Text = GProyectos.NombreProyecto
        txtInicio.Value = GProyectos.FechaInicio
        txtFinaliza.Value = GProyectos.FechaFin
        PanelFase.Height = 0
        PanelActividad.Height = 0
    End Sub

    Private Sub ToolStripButton6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton6.Click
        If dgvFases.Rows.Count > 0 Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                eliminarEDT(dgvFases.Item(0, dgvFases.CurrentRow.Index).Value, dgvFases)
                lblEstado.Text = "Fase Eliminada!"
                lblEstado.Image = My.Resources.ok4
            End If
        Else
            lblEstado.Text = "Debe seleccionar una fila"
            lblEstado.Image = My.Resources.cross
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        PanelActividad.Height = 0
    End Sub

    Private Sub ToolStripButton12_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton12.Click
        LinkLabel2.Text = "Agregar Actividad"
        PanelActividad.Height = 83
        txtNomActividad.Clear()
        txtIdResponsable.Clear()
        txtResponsable.Clear()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        TrabajadoresShow()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        If Not txtNomActividad.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese una descripción válida.!"
            lblEstado.Image = My.Resources.warning2
            txtNomActividad.Focus()
            Exit Sub
        End If

        If Not txtIdResponsable.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese un responsable para la actividad.!"
            lblEstado.Image = My.Resources.warning2
            txtIdResponsable.Focus()
            Exit Sub
        End If

        If LinkLabel2.Text = "Agregar Actividad" Then
            GrabarActividad()
        ElseIf LinkLabel2.Text = "Editar Actividad" Then
            EditarActividad()
        End If
    End Sub

    Private Sub ToolStripButton13_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton13.Click
        txtNomActividad.Text = dgvActividad.Item(1, dgvActividad.CurrentRow.Index).Value
        txtIdResponsable.Text = dgvActividad.Item(2, dgvActividad.CurrentRow.Index).Value
        txtResponsable.Text = dgvActividad.Item(3, dgvActividad.CurrentRow.Index).Value
        ' lblIdFase.Text = dgvActividad.Item(0, dgvActividad.CurrentRow.Index).Value
        LinkLabel2.Text = "Editar Actividad"
        PanelActividad.Height = 83
    End Sub

    Private Sub ToolStripButton14_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton14.Click
        If dgvActividad.Rows.Count > 0 Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                eliminarEDT(dgvActividad.Item(0, dgvActividad.CurrentRow.Index).Value, dgvActividad)
                lblEstado.Text = "Actividad Eliminada!"
                lblEstado.Image = My.Resources.ok4
            End If
        Else
            lblEstado.Text = "Debe seleccionar una fila"
            lblEstado.Image = My.Resources.cross
        End If
    End Sub

    Private Sub NuevoToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton1.Click
        'With frmModalSuministros
        '    .ObtenerUM()
        '    .ObtenerClasificacion()
        '    .XManipulacion = ENTITY_ACTIONS.INSERT
        '    .XDireccion = TIPO_DIRECCION.PLANIFICACION
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    lblRowsGasto.Text = "Filas: " & dgvGastos.Rows.Count
        'End With
    End Sub

    Private Sub AbrirToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles AbrirToolStripButton1.Click
        If dgvGastos.Rows.Count > 0 Then
            'With frmModalSuministros
            '    .ObtenerUM()
            '    .ObtenerClasificacion()
            '    .XManipulacion = ENTITY_ACTIONS.UPDATE
            '    .XDireccion = TIPO_DIRECCION.PLANIFICACION
            '    .UbicarID(dgvGastos.Item(1, dgvGastos.CurrentRow.Index).Value, dgvGastos.Item(25, dgvGastos.CurrentRow.Index).Value)
            '    .StartPosition = FormStartPosition.CenterParent
            '    .ShowDialog()
            'End With
        End If
    End Sub

    Private Sub GuardarToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton2.Click
        If dgvGastos.Rows.Count > 0 Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminarRegistroLiquidacionPlanificacion(dgvGastos.Item(1, dgvGastos.CurrentRow.Index).Value, dgvGastos.Item(17, dgvGastos.CurrentRow.Index).Value, dgvGastos)
            End If

        End If
    End Sub

    Private Sub FASEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FASEToolStripMenuItem.Click
        FasesShow(GProyectos.IdProyectoActividad, TIPO_ACTIVIDAD_MODULO.FASE, "AP")
    End Sub

    Private Sub ENTREGBALEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ENTREGBALEToolStripMenuItem.Click
        FasesShow(GProyectos.IdProyectoActividad, TIPO_ACTIVIDAD_MODULO.ENTREGABLE, "AP")
    End Sub

    Private Sub ACTIVIDADToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ACTIVIDADToolStripMenuItem.Click
        FasesShow(GProyectos.IdProyectoActividad, TIPO_ACTIVIDAD_MODULO.ACTIVIDAD, "AP")
    End Sub

    Private Sub ToolStripButton16_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton16.Click
        With frmModalIngresos
            .ObtenerUM()
            .XManipulacion = ENTITY_ACTIONS.INSERT
            .XDireccion = TIPO_DIRECCION.PLANIFICACION
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            ToolStripLabel3.Text = "Filas: " & dgvIngresos.Rows.Count
        End With
    End Sub

    Private Sub ToolStripButton17_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton17.Click
        If dgvIngresos.Rows.Count > 0 Then
            With frmModalIngresos
                .ObtenerUM()
                .XManipulacion = ENTITY_ACTIONS.UPDATE
                .XDireccion = TIPO_DIRECCION.PLANIFICACION
                .UbicarID(dgvIngresos.Item(1, dgvIngresos.CurrentRow.Index).Value)
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub ToolStripButton18_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton18.Click
        If dgvIngresos.Rows.Count > 0 Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                eliminarING(dgvIngresos.Item(1, dgvIngresos.CurrentRow.Index).Value)
            End If
        End If
    End Sub
End Class