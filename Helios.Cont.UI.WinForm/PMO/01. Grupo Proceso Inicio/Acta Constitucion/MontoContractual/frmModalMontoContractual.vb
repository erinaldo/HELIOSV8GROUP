Imports Helios.General.Constantes
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity

Public Class frmModalMontoContractual

    Public Property actyon As String
    Public codigo As Integer

    Private Sub ImprimirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ImprimirToolStripButton.Click
        Dispose()
    End Sub

    Private Sub nupHitos_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles nupHitos.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nupPorcentaje.Select(0, nupPorcentaje.Text.Length)
            nupPorcentaje.Focus()
        End If
    End Sub

    Private Sub NumericUpDown2_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles nupPorcentaje.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtMonto.Select(0, txtMonto.Text.Length)
            txtMonto.Focus()
        End If
    End Sub

    Private Sub txtConcepto_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtConcepto.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nupPorcentaje.Select(0, nupPorcentaje.Text.Length)
            nupPorcentaje.Focus()
        End If
    End Sub
    Private Sub nudLaborDiaria_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMonto.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtObservaciones.Select(0, txtObservaciones.Text.Length)
            txtObservaciones.Focus()
        End If
    End Sub

    Private Sub txtDiasTrabajados_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDiasTrabajados.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtObservaciones.Select(0, txtObservaciones.Text.Length)
            txtObservaciones.Focus()
        End If
    End Sub

    Sub LimpiarCajas()
        txtMonto.Value = 0
        nupHitos.Value = 0
        txtDiasTrabajados.Value = 0
        txtFechaFacturacion.Value = Date.Now
        txtConcepto.Text = ""
        nupPorcentaje.Value = 0
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case actyon
            Case ENTITY_ACTIONS.INSERT
                Grabar()
            Case ENTITY_ACTIONS.UPDATE
                Editar()
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Sub Grabar()
        Dim intIdRecursoActividad As Integer
        Dim actividadSA As New ActividadesSA
        Dim actividad As New Actividades
        Try

            If (GModoProyecto = "Aprobado") Then
                actividad = New Actividades With {
                           .Action = Business.Entity.BaseBE.EntityAction.INSERT,
                           .idEmpresa = Gempresas.IdEmpresaRuc,
                           .idEstablecimiento = GEstableciento.IdEstablecimiento,
                           .idProyecto = GProyectos.IdProyectoActividad,
                           .idActividad = GProyectos.IdProyecto,
                           .NombreActividad = nupHitos.Value,
                           .idPadre = GProyectos.IdProyecto,
                           .descripcion = txtConcepto.Text,
                           .modulo = "HT",
                           .cantidad = nupPorcentaje.Value,
                           .FechaInicio = txtFechaFacturacion.Value,
                           .Dias = txtDiasTrabajados.Value,
                           .importePrecUni = txtMonto.Text,
                           .Observacion = txtObservaciones.Text,
                           .usuarioActualizacion = "NN",
                           .flag = "AP",
                           .fechaActualizacion = DateTime.Now}
            Else

                actividad = New Actividades With {
           .Action = Business.Entity.BaseBE.EntityAction.INSERT,
           .idEmpresa = Gempresas.IdEmpresaRuc,
           .idEstablecimiento = GEstableciento.IdEstablecimiento,
           .idProyecto = GProyectos.IdProyectoActividad,
           .idActividad = GProyectos.IdProyecto,
           .NombreActividad = nupHitos.Value,
           .idPadre = GProyectos.IdProyecto,
           .descripcion = txtConcepto.Text,
           .modulo = "HT",
           .cantidad = nupPorcentaje.Value,
           .FechaInicio = txtFechaFacturacion.Value,
           .Dias = txtDiasTrabajados.Value,
           .importePrecUni = txtMonto.Text,
           .Observacion = txtObservaciones.Text,
           .usuarioActualizacion = "NN",
           .flag = "A",
           .fechaActualizacion = DateTime.Now}
            End If

            intIdRecursoActividad = actividadSA.InsertarEDT(actividad)
            If intIdRecursoActividad <> Nothing Then
                lblEstado.Text = "Monto contractual registrado"
                lblEstado.Image = My.Resources.ok4
                frmActaConstitucionMaster.dgvFormaPago.Rows.Add(intIdRecursoActividad, Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, GProyectos.IdProyecto, nupHitos.Value, _
                                                                txtConcepto.Text, nupPorcentaje.Value, txtMonto.Value, FormatDateTime(txtFechaFacturacion.Value, DateFormat.ShortDate), txtDiasTrabajados.Value, "HT", txtObservaciones.Text)
                Dispose()
            Else
                lblEstado.Text = "Error al grabar monto contractual!"
                lblEstado.Image = My.Resources.cross
            End If

            Dispose()
        Catch ex As Exception
            lblEstado.Text = "Error al grabar monto contractual" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try
    End Sub

    Sub Editar()
        ' .idActividad = codigo,
        Dim actividadSA As New ActividadesSA
        Dim actividad As New Actividades
        Try
            If (GModoProyecto = "Aprobado") Then
                actividad = New Actividades With {
           .Action = Business.Entity.BaseBE.EntityAction.INSERT,
            .idEmpresa = Gempresas.IdEmpresaRuc,
           .idEstablecimiento = GEstableciento.IdEstablecimiento,
           .idProyecto = GProyectos.IdProyectoActividad,
           .idActividad = GProyectos.IdProyecto,
           .NombreActividad = nupHitos.Value,
           .idPadre = GProyectos.IdProyecto,
           .descripcion = txtConcepto.Text,
           .cantidad = nupPorcentaje.Value,
           .modulo = "HT",
           .FechaInicio = txtFechaFacturacion.Value,
           .Dias = txtDiasTrabajados.Value,
           .importePrecUni = txtMonto.Text,
             .Observacion = txtObservaciones.Text,
           .usuarioActualizacion = "NN",
           .flag = "AP",
           .fechaActualizacion = DateTime.Now}
            Else
                actividad = New Actividades With {
           .Action = Business.Entity.BaseBE.EntityAction.INSERT,
            .idEmpresa = Gempresas.IdEmpresaRuc,
           .idEstablecimiento = GEstableciento.IdEstablecimiento,
           .idProyecto = GProyectos.IdProyectoActividad,
           .idActividad = GProyectos.IdProyecto,
           .NombreActividad = nupHitos.Value,
           .idPadre = GProyectos.IdProyecto,
           .descripcion = txtConcepto.Text,
           .cantidad = nupPorcentaje.Value,
           .modulo = "HT",
           .FechaInicio = txtFechaFacturacion.Value,
           .Dias = txtDiasTrabajados.Value,
           .importePrecUni = txtMonto.Text,
             .Observacion = txtObservaciones.Text,
           .flag = "A",
           .usuarioActualizacion = "NN",
           .fechaActualizacion = DateTime.Now}
            End If

            lblEstado.Text = "Monto contractual actualizado!"
            lblEstado.Image = My.Resources.ok4

            If (actividadSA.UpdateEDT(actividad)) Then
                lblEstado.Text = "Monto contractual editado!"
                lblEstado.Image = My.Resources.ok4
                With frmActaConstitucionMaster.dgvFormaPago
                    .Item(0, frmActaConstitucionMaster.dgvFormaPago.CurrentRow.Index).Value = codigo
                    .Item(1, frmActaConstitucionMaster.dgvFormaPago.CurrentRow.Index).Value = Gempresas.IdEmpresaRuc
                    .Item(2, frmActaConstitucionMaster.dgvFormaPago.CurrentRow.Index).Value = GEstableciento.IdEstablecimiento
                    .Item(3, frmActaConstitucionMaster.dgvFormaPago.CurrentRow.Index).Value = GProyectos.IdProyecto
                    .Item(4, frmActaConstitucionMaster.dgvFormaPago.CurrentRow.Index).Value = nupHitos.Value
                    .Item(6, frmActaConstitucionMaster.dgvFormaPago.CurrentRow.Index).Value = nupPorcentaje.Value
                    .Item(5, frmActaConstitucionMaster.dgvFormaPago.CurrentRow.Index).Value = txtConcepto.Text
                    .Item(7, frmActaConstitucionMaster.dgvFormaPago.CurrentRow.Index).Value = txtMonto.Value
                    .Item(8, frmActaConstitucionMaster.dgvFormaPago.CurrentRow.Index).Value = FormatDateTime(txtFechaFacturacion.Value, DateFormat.ShortDate)
                    .Item(9, frmActaConstitucionMaster.dgvFormaPago.CurrentRow.Index).Value = txtDiasTrabajados.Value
                    .Item(10, frmActaConstitucionMaster.dgvFormaPago.CurrentRow.Index).Value = "HT"
                    .Item(11, frmActaConstitucionMaster.dgvFormaPago.CurrentRow.Index).Value = txtObservaciones.Text
                End With
                Dispose()
            Else
                lblEstado.Text = "Error al grabar monto contractual!"
                lblEstado.Image = My.Resources.cross
            End If

            Dispose()
        Catch ex As Exception
            lblEstado.Text = "Error al Actualizar monto contractual" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try

    End Sub

    Private Sub txtFechaFacturacion_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtFechaFacturacion.ValueChanged
        If (txtFechaFacturacion.Value.Date < Date.Now.Date) Then
            txtDiasTrabajados.Value = ((Date.Now.Date) - (txtFechaFacturacion.Value.Date)).TotalDays
        Else
            txtDiasTrabajados.Value = 0
        End If
    End Sub
End Class