Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmActaConstitucionMaster

#Region "Métodos"
    Public Sub validarCotizacion()
        NuevoToolStripButton.Enabled = False
        AbrirToolStripButton.Enabled = False
        GuardarToolStripButton1.Enabled = False
    End Sub

    Public Sub UpdateProyecto(strOpcion As String)
        Dim ProyectoPlaneacionSA As New ProyectoPlaneacionSA
        Dim ProyectoPlaneacion As New ProyectoPlaneacion
        Try
            Select Case strOpcion
                'Case "APROBADO"
                '    ProyectoPlaneacion = New ProyectoPlaneacion With {
                '    .estadoCosto = "A",
                '    .idProyecto = GProyectos.IdProyectoActividad,
                '    .idEmpresa = Gempresas.IdEmpresaRuc,
                '    .idEstablecimiento = GEstableciento.IdEstablecimiento,
                '    .nombreProyecto = txtPropuesta.Text,
                '    .responsable = GProyectos.DirectorProyecto,
                '    .fechaInicio = txtInicio.Value,
                '    .fechaFinal = txtFinaliza.Value,
                '    .fechaModificacion = Date.Now}
                Case "NO APROBADO"
                    ProyectoPlaneacion = New ProyectoPlaneacion With {
                   .estadoCosto = "NA",
                   .idProyecto = GProyectos.IdProyecto,
                   .idEmpresa = Gempresas.IdEmpresaRuc,
                   .idEstablecimiento = GEstableciento.IdEstablecimiento,
                   .nombreProyecto = txtPropuesta.Text,
                   .responsable = GProyectos.DirectorProyecto,
                   .fechaInicio = txtInicio.Value,
                   .fechaFinal = txtFinaliza.Value,
                 .fechaModificacion = Date.Now}
                Case "PARALIZADO"
                    ProyectoPlaneacion = New ProyectoPlaneacion With {
                       .estadoCosto = "D",
                     .idProyecto = GProyectos.IdProyecto,
                     .idEmpresa = Gempresas.IdEmpresaRuc,
                     .idEstablecimiento = GEstableciento.IdEstablecimiento,
                     .nombreProyecto = txtPropuesta.Text,
                        .responsable = GProyectos.DirectorProyecto,
                     .fechaInicio = txtInicio.Value,
                     .fechaFinal = txtFinaliza.Value,
                     .fechaModificacion = Date.Now}
            End Select


            If (ProyectoPlaneacionSA.EditarProyecto(ProyectoPlaneacion)) Then
                lblEstado.Text = "Se actualizó correctamente el proyecto"
                lblEstado.Image = My.Resources.ok4
            End If

        Catch ex As Exception
            lblEstado.Text = "Error al Actualizar el proyecto" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try
    End Sub

    Sub eliminarMontoContractual()

        Dim actividadSA As New ActividadesSA
        Dim actividad As New Actividades
        Try
            actividad = New Actividades With {
            .Action = Business.Entity.BaseBE.EntityAction.INSERT,
            .idActividad = dgvFormaPago.Item(0, dgvFormaPago.CurrentRow.Index).Value}

            If (actividadSA.DeleteEDT(actividad)) Then
                lblEstado.Text = "Monto contractual eliminado!"
                lblEstado.Image = My.Resources.ok4
                dgvFormaPago.Rows.RemoveAt(dgvFormaPago.CurrentRow.Index)
                'ValidarAprobado("Pago")
            Else
                lblEstado.Text = "Error al eliminar monto contractual"
                lblEstado.Image = My.Resources.cross
            End If

        Catch ex As Exception
            lblEstado.Text = "Error al Eliminar" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try

    End Sub

    Public Sub EliminarRegistroLiquidacion(ByVal strCodigo As String, strRefSustento As String, dgv As DataGridView, strTipoPlan As String)
        Dim objActividadEO As New totalesLiquidacion()
        Dim objLiquidacionSA As New totalesLiquidacionSA
        Dim ILiquidacion As New actividadRecurso
        Dim actividadSA As New actividadRecursoSA
        Try
            ILiquidacion = actividadSA.UbicaRecursoID(strCodigo)
            With objActividadEO
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .idActividad = GProyectos.IdProyecto
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

                .tipoPlan = strTipoPlan
                .tipoLiquidacion = "INCIDENCIA DIRECTA"
                .Otros = "CADIN"
            End With
            objLiquidacionSA.GetEliminarLiquidacion(objActividadEO)
            lblEstado.Text = "registro eliminado!"
            lblEstado.Image = My.Resources.ok4
            dgv.Rows.RemoveAt(dgv.CurrentRow.Index)
        Catch ex As Exception
            MsgBox("Error al eliminar registro." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del sistema")
        End Try

    End Sub

    Public Sub UbicarProyectoEstado(intIdProyecto As Integer)
        Dim proyectoSA As New ProyectoPlaneacionSA
        Dim proyecto As New ProyectoPlaneacion
        proyecto = proyectoSA.UbicarProyecto(intIdProyecto)
        If Not IsNothing(proyecto) Then
            Select Case proyecto.estadoCosto
                Case "A"
                    ValidarCotizacion()
                    chAprobado.Checked = True
                    lblAprobado.Enabled = False
                    ObtenerListaCotizacion("C", "AP")
                    ObtenerListaGasto("G", "INCIDENCIA DIRECTA", "AP")
                    ObtenerListaEDT("EDT", "AP")
                    ObtenerListaMontoContractual("HT", "AP")
                    'GModoProyecto = "Aprobado"
                Case "NA"
                    chNoAprobado.Checked = True
                    ObtenerListaCotizacion("C", "A")
                    ObtenerListaGasto("G", "INCIDENCIA DIRECTA", "A")
                    ObtenerListaEDT("EDT", "A")
                    ObtenerListaMontoContractual("HT", "A")
                    GModoProyecto = "NAProyecto"
                Case "D"
                    chDetenido.Checked = True
                    'ObtenerListaCotizacion("PRS")
                    'ObtenerListaEDT("EDT")
                    'ObtenerListaGasto("K", "INCIDENCIA DIRECTA")
            End Select

        End If

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
            txtInicio.Value = proyecto.fechaInicio
            txtFinaliza.Value = proyecto.fechaFinal
        End If
    End Sub

    Public Sub ObtenerListaCotizacion(strSustento As String, strTipoPlan As String)
        Dim recursoSA As New actividadRecursoSA
        Dim ItemsSA As New itemSA
        Try
            dgvPropuesta.Rows.Clear()
            For Each i In recursoSA.ListaRecursosCotizacionGasto(GProyectos.IdProyecto, strSustento, strTipoPlan)

                dgvPropuesta.Rows.Add(i.fechaIngreso, i.idActividadRecurso, i.Descripcion, i.detalleExtra, i.unidadMedida, i.laborDiaria,
                                      i.hm, i.porcentaje2, i.dias, i.costoUnithh,
                                      i.cant, i.costoUnit, i.costoDirecto1,
                                      i.costoDirecto2, i.ggPorc, i.ggImporte, i.utPorc,
                                      i.utImporte, i.costoFinal, i.igvPorc, i.igvImporte,
                                      i.precioFinal, i.cantFinal, i.precUnitFinal, i.ReferenciaSustento, i.Clasificacion, i.TipoRecurso)

            Next

            lblRows.Text = "Filas: " & dgvPropuesta.Rows.Count
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Public Sub ObtenerListaGasto(strSustento As String, strTipoPresupuesto As String, strTipoPlan As String)
        Dim recursoSA As New actividadRecursoSA
        Try
            dgvGastos.Rows.Clear()
            For Each i In recursoSA.ListaRecursosGastoPreliminar(GProyectos.IdProyecto, strSustento, strTipoPresupuesto, strTipoPlan)
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

    Public Sub ObtenerListaEDT(strTipoModulo As String, strFlag As String)
        Dim ActividadSA As New ActividadesSA
        Try
            dgvEDT.Rows.Clear()
            For Each i In ActividadSA.ListaEDT(GProyectos.IdProyecto, strTipoModulo, strFlag)
                dgvEDT.Rows.Add(i.idActividad, i.idEmpresa, i.idEstablecimiento, i.idProyecto, i.NombreActividad, i.descripcion, i.modulo, i.responsable, i.nombreTrab, FormatDateTime(i.FechaInicio.Value, DateFormat.ShortDate), i.Dias, i.Observacion)
            Next
            lblRows.Text = "Filas: " & dgvEDT.Rows.Count
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Public Sub ObtenerListaMontoContractual(strTipoModulo As String, strFlag As String)
        Dim ActividadSA As New ActividadesSA
        Try
            dgvFormaPago.Rows.Clear()
            For Each i In ActividadSA.GetUbicarMontoContractual(GProyectos.IdProyecto, strTipoModulo, strFlag)
                dgvFormaPago.Rows.Add(i.idActividad, i.idEmpresa, i.idEstablecimiento, i.idProyecto, i.NombreActividad, i.descripcion, i.cantidad, i.importePrecUni, FormatDateTime(i.FechaInicio.Value, DateFormat.ShortDate), i.Dias, i.modulo, i.Observacion)
            Next
            lblRows.Text = "Filas: " & dgvFormaPago.Rows.Count
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Sub eliminarEDT()

        Dim actividadSA As New ActividadesSA
        Dim actividad As New Actividades
        Try
            actividad = New Actividades With {
            .Action = Business.Entity.BaseBE.EntityAction.INSERT,
            .idActividad = dgvEDT.Item(0, dgvEDT.CurrentRow.Index).Value}

            If (actividadSA.DeleteEDT(actividad)) Then
                lblEstado.Text = "EDT Eliminado!"
                lblEstado.Image = My.Resources.ok4
                dgvEDT.Rows.RemoveAt(dgvEDT.CurrentRow.Index)
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
#End Region

    Private Sub frmActaConstitucionMaster_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dispose()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        If dgvPropuesta.Rows.Count > 0 Then
            chCotizacion.Checked = True
        Else
            chCotizacion.Checked = False
        End If
        If dgvGastos.Rows.Count > 0 Then
            chGasto.Checked = True
        Else
            chGasto.Checked = False
        End If
        If dgvEDT.Rows.Count > 0 Then
            chEDT.Checked = True
        Else
            chEDT.Checked = False
        End If
        If dgvFormaPago.Rows.Count > 0 Then
            chMontoContractual.Checked = True
        Else
            chMontoContractual.Checked = False
        End If
        If (dgvPropuesta.Rows.Count > 0 And dgvGastos.Rows.Count > 0 And dgvEDT.Rows.Count > 0 And dgvFormaPago.Rows.Count > 0) Then
            GbDesicion.Enabled = True
        End If
    End Sub

    Private Sub NuevoToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton1.Click
        With frmModalSuministros
            .ObtenerUM()
            .ObtenerClasificacion()
            .XManipulacion = ENTITY_ACTIONS.INSERT
            .XDireccion = TIPO_DIRECCION.INICIACION
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            lblRowsGasto.Text = "Filas: " & dgvGastos.Rows.Count
        End With
    End Sub
    Private Sub dgvGastos_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvGastos.CellFormatting
        If e.ColumnIndex = Me.dgvGastos.Columns("colTipoRecurso").Index _
  AndAlso (e.Value IsNot Nothing) Then

            With Me.dgvGastos.Rows(e.RowIndex).Cells(e.ColumnIndex)

                If e.Value.Equals("EX") Then
                    .ToolTipText = "RECURSO: EXISTENCIA"
                ElseIf e.Value.Equals("GS") Then
                    .ToolTipText = "RECURSO: SERVICIO, GASTO, CONTRATO"
                ElseIf e.Value.Equals("RH") Then
                    .ToolTipText = "RECURSO: RECURSOS HUMANOS"
                End If

            End With

        End If
    End Sub

    Private Sub AbrirToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles AbrirToolStripButton1.Click
        If dgvGastos.Rows.Count > 0 Then
            With frmModalSuministros
                .ObtenerUM()
                .ObtenerClasificacion()
                .XManipulacion = ENTITY_ACTIONS.UPDATE
                .XDireccion = TIPO_DIRECCION.INICIACION
                .UbicarID(dgvGastos.Item(1, dgvGastos.CurrentRow.Index).Value, dgvGastos.Item(25, dgvGastos.CurrentRow.Index).Value)
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click
        With frmModalCotizacion
            .actyon = ENTITY_ACTIONS.INSERT
            .ObtenerUM()
            .ObtenerClasificacion()
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                lblRows.Text = "Filas: " & dgvPropuesta.Rows.Count
        End With
    End Sub

    Private Sub AbrirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles AbrirToolStripButton.Click
        If dgvPropuesta.Rows.Count > 0 Then
            With frmModalCotizacion
                .actyon = ENTITY_ACTIONS.UPDATE
                .ObtenerUM()
                .ObtenerClasificacion()
                .UbicaCotizacionID(dgvPropuesta.Item(1, dgvPropuesta.CurrentRow.Index).Value, dgvPropuesta.Item(25, dgvPropuesta.CurrentRow.Index).Value)
                .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    lblRows.Text = "Filas: " & dgvPropuesta.Rows.Count
            End With
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        With frmModalEDT
            .limpiarCajas()
            .actyon = ENTITY_ACTIONS.INSERT
            .XDireccion = TIPO_DIRECCION.INICIACION
            .nupHitos.Value = dgvEDT.RowCount + 1
            .lblCambiar.Focus()
            .txtFechaIEDT.Value = txtInicio.Value
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub tsbEditarEDT_Click(sender As System.Object, e As System.EventArgs) Handles tsbEditarEDT.Click
        If dgvEDT.Rows.Count > 0 Then
            With frmModalEDT
                .actyon = ENTITY_ACTIONS.UPDATE
                .XDireccion = TIPO_DIRECCION.INICIACION
                .lblId.Text = (dgvEDT.SelectedRows(0).Cells(0).Value)
                .nupHitos.Value = (dgvEDT.SelectedRows(0).Cells(4).Value)
                .txtConcepto.Text = (dgvEDT.SelectedRows(0).Cells(5).Value)
                .txtIdResponsable.Text = (dgvEDT.SelectedRows(0).Cells(7).Value)
                .txtDirector.Text = (dgvEDT.SelectedRows(0).Cells(8).Value)
                .txtFechaIEDT.Value = (dgvEDT.SelectedRows(0).Cells(9).Value)
                '.txtDiasTrabajados.Value = (dgvEDT.SelectedRows(0).Cells(10).Value)
                .txtDescripcionEDT.Text = (dgvEDT.SelectedRows(0).Cells(11).Value)
                .lblEstado.Text = "Editar Registro"
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub tsbEliminarEDT_Click(sender As System.Object, e As System.EventArgs) Handles tsbEliminarEDT.Click
        If dgvEDT.Rows.Count > 0 Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                eliminarEDT()
            End If
        Else
            lblEstado.Text = "Debe seleccionar una fila"
            lblEstado.Image = My.Resources.cross
        End If
    End Sub

    Private Sub chNoAprobado_Click(sender As System.Object, e As System.EventArgs) Handles chNoAprobado.Click
        If (chNoAprobado.Checked = True) Then
            Dim result As Integer = MessageBox.Show("¿Desea no aprobar el proyecto?", "Proyecto", MessageBoxButtons.YesNo)
            Select Case result
                Case DialogResult.No
                    chNoAprobado.Checked = False
                    Select Case Tag
                        Case "A"
                            lblAprobado.Enabled = False
                            chAprobado.Checked = True
                        Case "NA"
                            chNoAprobado.Checked = True
                        Case "D"
                            chDetenido.Checked = True
                    End Select
                Case DialogResult.Yes
                    UpdateProyecto("NO APROBADO")
                    Tag = "NA"
                    lblAprobado.Enabled = True
                    chAprobado.Checked = False
                    chDetenido.Checked = False
            End Select
        End If
    End Sub

    Private Sub chDetenido_Click(sender As System.Object, e As System.EventArgs) Handles chDetenido.Click
        If (chDetenido.Checked = True) Then
            Dim result As Integer = MessageBox.Show("¿Desea paralizar el proyecto?", "Proyecto", MessageBoxButtons.YesNo)
            Select Case result
                Case DialogResult.No
                    chDetenido.Checked = False
                    Select Case Tag
                        Case "A"
                            lblAprobado.Enabled = False
                            chAprobado.Checked = True
                        Case "NA"
                            chNoAprobado.Checked = True
                        Case "D"
                            chDetenido.Checked = True
                    End Select
                Case DialogResult.Yes
                    UpdateProyecto("PARALIZADO")
                    Tag = "D"
                    lblAprobado.Enabled = True
                    chAprobado.Checked = False
                    chNoAprobado.Checked = False
            End Select
        End If
    End Sub

    Private Sub lblAprobado_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblAprobado.LinkClicked
        With frmActaConstitucionAprobado
            Dim result As Integer = MessageBox.Show("¿Desea aprobar el proyecto?", "Proyecto", MessageBoxButtons.YesNo)
            Select Case result
                Case DialogResult.Yes
                    Tag = "A"
                    'UpdateEDT(GProyectos.IdProyecto, GProyectos.IdProyectoActividad, "EDT")
                    'UpdateProyecto("APROBADO")
                    .ObtenerListaCotizacion("A")
                    chNoAprobado.Checked = False
                    chDetenido.Checked = False
                    chAprobado.Checked = True
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
            End Select
        End With
    End Sub

    Private Sub GuardarToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton2.Click
        If dgvGastos.Rows.Count > 0 Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If (GModoProyecto = "Aprobado") Then
                    EliminarRegistroLiquidacion(dgvGastos.Item(1, dgvGastos.CurrentRow.Index).Value, dgvGastos.Item(17, dgvGastos.CurrentRow.Index).Value, dgvGastos, "AP")
                Else
                    EliminarRegistroLiquidacion(dgvGastos.Item(1, dgvGastos.CurrentRow.Index).Value, dgvGastos.Item(17, dgvGastos.CurrentRow.Index).Value, dgvGastos, "A")
                End If

            End If

        End If
    End Sub

    Private Sub GuardarToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton1.Click
        If dgvPropuesta.Rows.Count > 0 Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If (GModoProyecto = "Aprobado") Then
                    EliminarRegistroLiquidacion(dgvPropuesta.Item(1, dgvPropuesta.CurrentRow.Index).Value, dgvPropuesta.Item(24, dgvPropuesta.CurrentRow.Index).Value, dgvPropuesta, "AP")
                Else
                    EliminarRegistroLiquidacion(dgvPropuesta.Item(1, dgvPropuesta.CurrentRow.Index).Value, dgvPropuesta.Item(24, dgvPropuesta.CurrentRow.Index).Value, dgvPropuesta, "A")
                End If

            End If

        End If
    End Sub

    Private Sub ToolStripButton3_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        With frmModalMontoContractual
            .LimpiarCajas()
            .actyon = ENTITY_ACTIONS.INSERT
            .nupHitos.Focus()
            .nupHitos.Value = dgvFormaPago.RowCount + 1
            .txtFechaFacturacion.MinDate = GProyectos.FechaInicio
            .txtFechaFacturacion.Value = GProyectos.FechaInicio
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub
    Private Sub ToolStripButton4_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        If dgvFormaPago.Rows.Count > 0 Then
            With frmModalMontoContractual
                .actyon = ENTITY_ACTIONS.UPDATE
                .codigo = (dgvFormaPago.SelectedRows(0).Cells(0).Value)
                .nupHitos.Value = (dgvFormaPago.SelectedRows(0).Cells(4).Value)
                .txtConcepto.Text = (dgvFormaPago.SelectedRows(0).Cells(5).Value)
                .nupPorcentaje.Value = (dgvFormaPago.SelectedRows(0).Cells(6).Value)
                .txtFechaFacturacion.Value = (dgvFormaPago.SelectedRows(0).Cells(8).Value)
                .txtMonto.Value = (dgvFormaPago.SelectedRows(0).Cells(7).Value)

                .txtDiasTrabajados.Value = (dgvFormaPago.SelectedRows(0).Cells(9).Value)
                .txtObservaciones.Text = (dgvFormaPago.SelectedRows(0).Cells(11).Value)
                .lblEstado.Text = "Editar Registro"
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub ToolStripButton6_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripButton6.Click
        If (dgvFormaPago.SelectedRows.Count > 0) Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                eliminarMontoContractual()
            End If
        Else
            lblEstado.Text = "Debe seleccionar una fila"
            lblEstado.Image = My.Resources.cross
        End If
    End Sub
End Class