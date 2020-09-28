Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmGestionRecursosHumanos

#Region "Métodos"
    Public Sub GrabarEquipo(strNombre As String, NumDoc As String, intIdEstablecimiento As Integer)
        Dim nEquipo As New Actividades
        Dim nEquipoSA As New ActividadesSA
        nEquipo = New Actividades With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                      .idEstablecimiento = intIdEstablecimiento,
                                      .idProyecto = GProyectos.IdProyectoActividad,
                                      .NombreActividad = strNombre,
                                      .descripcion = strNombre,
                                      .modulo = TIPO_ACTIVIDAD_MODULO.EQUIPO_PROYECTO,
                                      .idPadre = GProyectos.IdProyecto,
                                      .responsable = NumDoc,
                                      .FechaInicio = Nothing,
                                      .FechaFinal = Nothing,
                                      .Estado = Nothing,
                                      .usuarioActualizacion = "NN",
                                      .fechaActualizacion = DateTime.Now}

        nEquipoSA.InsertarEDT(nEquipo)
        lblEstado.Text = "Nuevo miembro agregado a proyecto"
        lblEstado.Image = My.Resources.ok4
    End Sub

    Public Sub EliminarEquipo()
        Dim nEquipo As New Actividades
        Dim nEquipoSA As New ActividadesSA
        nEquipo = New Actividades With {.idActividad = lsvTRabadores.SelectedItems(0).SubItems(0).Text}
        nEquipoSA.DeleteEDT(nEquipo)
        lblEstado.Text = "Miembro Eliminado"
        lblEstado.Image = My.Resources.ok4
        lsvTRabadores.SelectedItems(0).Remove()
    End Sub

    Public Sub ObtenerListaEquipo(strTipoModulo As String)
        Dim ActividadSA As New ActividadesSA
        Dim establecimientoSA As New establecimientoSA
        Try
            lsvTRabadores.Items.Clear()
            'For Each i In ActividadSA.GetListaActividadPorProyecto(GProyectos.IdProyectoActividad, strTipoModulo)
            '    Dim n As New ListViewItem(i.idActividad)
            '    n.SubItems.Add(establecimientoSA.UbicaEstablecimientoPorID(i.idEstablecimiento).nombre)
            '    n.SubItems.Add(i.responsable)
            '    n.SubItems.Add(i.nombreTrab)
            '    lsvTRabadores.Items.Add(n)
            'Next
            lblEstado.Text = "Nro. trabajadores: " & lsvTRabadores.Items.Count
            lblEstado.Image = My.Resources.ok4
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Sub SeleccionrarEquipoProy()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        Dim a As New ENTITY_ACTIONS
        'With frmModalTrab
        '    .lblTipo.Text = TIPO_ENTIDAD.PERSONAL_PLANILLA
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        'txtidIntegrante.Text = datos(0).ID
        '        'txtIntegrante.Text = datos(0).NombreEntidad
        '        GrabarEquipo(datos(0).NombreEntidad, datos(0).ID, datos(0).IDEstable)
        '        ObtenerListaEquipo(TIPO_ACTIVIDAD_MODULO.EQUIPO_PROYECTO)
        '    Else
        '        'txtidIntegrante.Text = String.Empty
        '        'txtIntegrante.Text = String.Empty

        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub
#End Region

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click
        SeleccionrarEquipoProy()
    End Sub

    Private Sub frmGestionRecursosHumanos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmGestionRecursosHumanos_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtProyecto.Text = GProyectos.NombreProyecto
        txtInicio.Value = GProyectos.FechaInicio
        txtFinaliza.Value = GProyectos.FechaFin
        txtDirector.Text = GProyectos.NombreDirector
    End Sub

    Private Sub GuardarToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton1.Click
        If lsvTRabadores.SelectedItems.Count > 0 Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminarEquipo()
            End If
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dispose()
    End Sub
End Class