Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class frmModalEDT
    Public Property actyon As String
    Public XDireccion As String

#Region "Métodos"
    Public Sub limpiarCajas()
        lblId.Text = ""
        txtDescripcionEDT.Text = ""
        txtIdResponsable.Text = ""
        txtDirector.Text = ""
        txtConcepto.Text = ""
        nupHitos.Value = 0
        txtDiasTrabajados.Value = 0
        txtFechaIEDT.Value = Date.Now
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
           .responsable = txtIdResponsable.Text,
           .modulo = TIPO_ACTIVIDAD_MODULO.ENTREGABLE,
           .descripcion = txtConcepto.Text,
           .Dias = txtDiasTrabajados.Value,
           .FechaInicio = txtFechaIEDT.Value,
           .Observacion = txtDescripcionEDT.Text,
           .Estado = "SA",
           .flag = "AP",
           .usuarioActualizacion = "NN",
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
           .responsable = txtIdResponsable.Text,
           .modulo = TIPO_ACTIVIDAD_MODULO.ENTREGABLE,
           .descripcion = txtConcepto.Text,
           .Dias = txtDiasTrabajados.Value,
           .FechaInicio = txtFechaIEDT.Value,
           .Observacion = txtDescripcionEDT.Text,
           .Estado = "SA",
           .flag = "A",
           .usuarioActualizacion = "NN",
           .fechaActualizacion = DateTime.Now}
            End If
            intIdRecursoActividad = actividadSA.InsertarEDT(actividad)
            If intIdRecursoActividad <> Nothing Then
                lblEstado.Text = "EDT registrado"
                lblEstado.Image = My.Resources.ok4
                Select Case XDireccion
                    Case TIPO_DIRECCION.INICIACION
                        frmActaConstitucionMaster.dgvEDT.Rows.Add(intIdRecursoActividad, Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, _
                                                         GProyectos.IdProyecto, nupHitos.Value, txtConcepto.Text, "EDT", txtIdResponsable.Text, _
                                                         txtDirector.Text, FormatDateTime(txtFechaIEDT.Value, DateFormat.ShortDate), _
                                                        txtDiasTrabajados.Value, txtDescripcionEDT.Text)
                    Case TIPO_DIRECCION.PLANIFICACION
                        frmPlanGestionProyecto.dgvEDT.Rows.Add(intIdRecursoActividad, Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, _
                                                                 GProyectos.IdProyecto, nupHitos.Value, txtConcepto.Text, "EDT", txtIdResponsable.Text, _
                                                                 txtDirector.Text, FormatDateTime(txtFechaIEDT.Value, DateFormat.ShortDate), _
                                                                txtDiasTrabajados.Value, txtDescripcionEDT.Text)
                End Select
               
                Dispose()
            Else
                lblEstado.Text = "Error al grabar Cadena!"
                lblEstado.Image = My.Resources.cross
            End If

            Dispose()
        Catch ex As Exception
            lblEstado.Text = "Error al grabar EDT" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try
    End Sub

    Sub Editar()
        Dim actividadSA As New ActividadesSA
        Dim actividad As New Actividades
        Try
            If (GModoProyecto = "Aprobado") Then
                actividad = New Actividades With {
                            .Action = Business.Entity.BaseBE.EntityAction.INSERT,
                            .idActividad = lblId.Text,
                            .idEmpresa = Gempresas.IdEmpresaRuc,
                            .idEstablecimiento = GEstableciento.IdEstablecimiento,
                            .idProyecto = GProyectos.IdProyectoActividad,
                            .NombreActividad = nupHitos.Value,
                            .responsable = txtIdResponsable.Text,
                            .modulo = TIPO_ACTIVIDAD_MODULO.ENTREGABLE,
                            .idPadre = GProyectos.IdProyecto,
                            .descripcion = txtConcepto.Text,
                            .FechaInicio = txtFechaIEDT.Value,
                            .Observacion = txtDescripcionEDT.Text,
                             .cantidad = nupHitos.Value,
                            .Dias = txtDiasTrabajados.Value,
                            .usuarioActualizacion = "NN",
                            .flag = "AP",
                            .fechaActualizacion = DateTime.Now}
            Else
                actividad = New Actividades With {
            .Action = Business.Entity.BaseBE.EntityAction.INSERT,
            .idActividad = lblId.Text,
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .idProyecto = GProyectos.IdProyectoActividad,
            .NombreActividad = nupHitos.Value,
            .responsable = txtIdResponsable.Text,
            .modulo = TIPO_ACTIVIDAD_MODULO.ENTREGABLE,
            .idPadre = GProyectos.IdProyecto,
            .descripcion = txtConcepto.Text,
            .FechaInicio = txtFechaIEDT.Value,
            .Observacion = txtDescripcionEDT.Text,
             .cantidad = nupHitos.Value,
            .Dias = txtDiasTrabajados.Value,
            .usuarioActualizacion = "NN",
            .flag = "A",
            .fechaActualizacion = DateTime.Now}
            End If

            lblEstado.Text = "EDT Actualizado!"
            lblEstado.Image = My.Resources.ok4

            If (actividadSA.UpdateEDT(actividad)) Then
                lblEstado.Text = "Recurso editado!"
                lblEstado.Image = My.Resources.ok4
                Select Case XDireccion
                    Case TIPO_DIRECCION.INICIACION
                        With frmActaConstitucionMaster.dgvEDT
                            .Item(4, frmActaConstitucionMaster.dgvEDT.CurrentRow.Index).Value = nupHitos.Value
                            .Item(5, frmActaConstitucionMaster.dgvEDT.CurrentRow.Index).Value = txtConcepto.Text
                            .Item(7, frmActaConstitucionMaster.dgvEDT.CurrentRow.Index).Value = txtIdResponsable.Text
                            .Item(8, frmActaConstitucionMaster.dgvEDT.CurrentRow.Index).Value = txtDirector.Text
                            .Item(10, frmActaConstitucionMaster.dgvEDT.CurrentRow.Index).Value = txtDiasTrabajados.Value
                            .Item(9, frmActaConstitucionMaster.dgvEDT.CurrentRow.Index).Value = FormatDateTime(txtFechaIEDT.Value, DateFormat.ShortDate)
                            .Item(11, frmActaConstitucionMaster.dgvEDT.CurrentRow.Index).Value = txtDescripcionEDT.Text
                        End With
                    Case TIPO_DIRECCION.PLANIFICACION
                        With frmPlanGestionProyecto.dgvEDT
                            .Item(4, frmActaConstitucionMaster.dgvEDT.CurrentRow.Index).Value = nupHitos.Value
                            .Item(5, frmActaConstitucionMaster.dgvEDT.CurrentRow.Index).Value = txtConcepto.Text
                            .Item(7, frmActaConstitucionMaster.dgvEDT.CurrentRow.Index).Value = txtIdResponsable.Text
                            .Item(8, frmActaConstitucionMaster.dgvEDT.CurrentRow.Index).Value = txtDirector.Text
                            .Item(10, frmActaConstitucionMaster.dgvEDT.CurrentRow.Index).Value = txtDiasTrabajados.Value
                            .Item(9, frmActaConstitucionMaster.dgvEDT.CurrentRow.Index).Value = FormatDateTime(txtFechaIEDT.Value, DateFormat.ShortDate)
                            .Item(11, frmActaConstitucionMaster.dgvEDT.CurrentRow.Index).Value = txtDescripcionEDT.Text
                        End With
                End Select

               

                Dispose()
            Else
                lblEstado.Text = "Error al grabar Cadena!"
                lblEstado.Image = My.Resources.cross
            End If

            Dispose()
        Catch ex As Exception
            lblEstado.Text = "Error al Actualizar EDT" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try

    End Sub

    Sub TrabajadoresShow()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        With frmModalTrab
            .lblTipo.Text = TIPO_ENTIDAD.PERSONAL_PLANILLA
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                txtIdResponsable.Text = datos(0).ID
                txtDirector.Text = datos(0).NombreEntidad

            Else
                txtIdResponsable.Text = String.Empty
                txtDirector.Text = String.Empty

            End If
        End With

        Me.Cursor = Cursors.Arrow
    End Sub

#End Region

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        If (txtDescripcionEDT.Text <> "" And txtIdResponsable.Text <> "" _
            And nupHitos.Value <> Nothing) Then
            Me.Cursor = Cursors.WaitCursor
            Select Case actyon
                Case ENTITY_ACTIONS.INSERT
                    Grabar()
                Case ENTITY_ACTIONS.UPDATE
                    Editar()
            End Select
            Me.Cursor = Cursors.Arrow
        ElseIf (txtDescripcionEDT.Text = "" Or txtIdResponsable.Text = "" _
                Or nupHitos.Value = Nothing) Then
            lblEstado.Text = "Debe ingresar todo los campos correctamente"
            lblEstado.Image = My.Resources.cross

        End If

    End Sub

    Private Sub ImprimirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ImprimirToolStripButton.Click
        Dispose()
    End Sub

    Private Sub lblCambiar_Click(sender As System.Object, e As System.EventArgs) Handles lblCambiar.Click
        Call TrabajadoresShow()
    End Sub

    Private Sub txtConcepto_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtConcepto.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtDescripcionEDT.Select(0, txtDescripcionEDT.Text.Length)
            txtDescripcionEDT.Focus()
        End If
    End Sub

    Private Sub nupHitos_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles nupHitos.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtDescripcionEDT.Select(0, txtDescripcionEDT.Text.Length)
            txtDescripcionEDT.Focus()
        End If
    End Sub

    Private Sub txtDiasTrabajados_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDiasTrabajados.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtDescripcionEDT.Select(0, txtDescripcionEDT.Text.Length)
            txtDescripcionEDT.Focus()
        End If

    End Sub

    Private Sub txtFechaIEDT_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtFechaIEDT.ValueChanged
        If (txtFechaIEDT.Value.Date < Date.Now.Date) Then
            txtDiasTrabajados.Value = ((Date.Now.Date) - (txtFechaIEDT.Value.Date)).TotalDays
        Else
            txtDiasTrabajados.Value = 0
        End If
    End Sub

    Private Sub frmModalEDT_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
