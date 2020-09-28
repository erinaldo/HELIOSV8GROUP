Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmAgrupacionActividades

#Region "Métodos y otros"
    Public Sub QuitarEnlazados(intIdActividad As Integer)
        Dim ActividadSA As New ActividadesSA
        Dim ActividadLista As New List(Of Actividades)
        Dim objActividad As New Actividades
        objActividad = New Actividades
        objActividad.idActividad = intIdActividad
        objActividad.idPadre = GProyectos.IdProyecto
        objActividad.Estado = "SA"
        ActividadLista.Add(objActividad)
        ActividadSA.UpdateIdPadreActividad(ActividadLista)

        lblEstado.Text = "Items Desenlazados correctamente!"
        lblEstado.Image = My.Resources.ok4
    End Sub

    Public Sub ObtenerListaEntregablesEnlazados(intIdPadre As Integer, strModulo As String, strEstado As String)
        Dim actividadSA As New ActividadesSA
        dgvEntregables.Rows.Clear()
        For Each i In actividadSA.GetBusquedaActividadGeneralPorEstado(intIdPadre, strModulo, strEstado, "AP")
            dgvEntregables.Rows.Add(i.idActividad,
                                    i.NombreActividad & "° " & "Entregable",
                                    i.descripcion, i.Observacion, FormatDateTime(i.FechaInicio, DateFormat.ShortDate), i.Dias)
        Next
        lblEstado.Text = "Filas encontradas: " & dgvEntregables.Rows.Count
        lblEstado.Image = My.Resources.ok4
    End Sub

    Public Sub ObtenerListaEntregablesEnlazadosACT(intIdPadre As Integer, strModulo As String, strEstado As String)
        Dim actividadSA As New ActividadesSA
        lsvActividades.Items.Clear()
        For Each i In actividadSA.GetBusquedaActividadGeneralPorEstado(intIdPadre, strModulo, strEstado, "AP")
            Dim n As New ListViewItem(i.idActividad)
            n.SubItems.Add(i.NombreActividad)
            n.SubItems.Add(i.FechaInicio)
            n.SubItems.Add(i.FechaFinal)
            lsvActividades.Items.Add(n)
        Next
        lblEstado.Text = "Actividades encontradas: " & lsvActividades.Items.Count
        lblEstado.Image = My.Resources.ok4
    End Sub

    Sub FasesShow(intIdPadre As Integer, strModulo As String, strFlag As String)
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        With frmModalBusquedaActividad
            .ListaModal(intIdPadre, strModulo, strFlag)
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                txtIdFase.Text = datos(0).ID
                txtFase.Text = datos(0).NombreEntidad
                ObtenerListaEntregablesEnlazados(datos(0).ID, TIPO_ACTIVIDAD_MODULO.ENTREGABLE, "A")
            End If
        End With
        Me.Cursor = Cursors.Arrow
    End Sub
#End Region

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        FasesShow(GProyectos.IdProyecto, TIPO_ACTIVIDAD_MODULO.FASE, "AP")
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        If (dgvEntregables.RowCount > 0) Then
            If MessageBox.Show("Desea quitar la asignación?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                QuitarEnlazados(dgvEntregables.Item(0, dgvEntregables.CurrentRow.Index).Value)
                dgvEntregables.Rows.RemoveAt(dgvEntregables.CurrentRow.Index)
            End If
        Else
            lblEstado.Text = "Error no existe entregable!"
            lblEstado.Image = My.Resources.cross
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        With frmModalActividadesNoActivas
            .lblFase.Text = "Fase:"
            .txtFase.Text = txtFase.Text.Trim
            .lblIdPadre.Text = txtIdFase.Text.Trim
            .Estado = TIPO_ACTIVIDAD_MODULO.ENTREGABLE
            .ObtenerLIsta(GProyectos.IdProyecto, TIPO_ACTIVIDAD_MODULO.ENTREGABLE)
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub frmAgrupacionActividades_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmAgrupacionActividades_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dispose()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        FasesShow(txtIdFase.Text.Trim, TIPO_ACTIVIDAD_MODULO.ENTREGABLE, "AP")
    End Sub

    Private Sub dgvEntregables_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEntregables.CellClick
        Me.Cursor = Cursors.WaitCursor
        If e.ColumnIndex = 6 Then
            With frmModalActividadesNoActivas
                .txtFase.Text = txtFase.Text.Trim
                .lblIdPadre.Text = txtIdFase.Text.Trim
                lblEstado.Text = "Plan de Gestion del Proyecto"
                .ObtenerLIsta(GProyectos.IdProyecto, TIPO_ACTIVIDAD_MODULO.ACTIVIDAD)
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvEntregables_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEntregables.CellContentClick

    End Sub

    Private Sub dgvEntregables_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvEntregables.SelectionChanged
        If dgvEntregables.Rows.Count > 0 Then
            ObtenerListaEntregablesEnlazadosACT(dgvEntregables.Item(0, dgvEntregables.CurrentRow.Index).Value, TIPO_ACTIVIDAD_MODULO.ACTIVIDAD, "A")
        End If

    End Sub

    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton5.Click
        If (dgvEntregables.RowCount > 0) Then
            With frmModalActividadesNoActivas
                .lblFase.Text = "E.D.T.:"
                .txtFase.Text = dgvEntregables.Item(2, dgvEntregables.CurrentRow.Index).Value ' txtFase.Text.Trim
                .Estado = TIPO_ACTIVIDAD_MODULO.ACTIVIDAD
                .lblIdPadre.Text = dgvEntregables.Item(0, dgvEntregables.CurrentRow.Index).Value ' txtIdFase.Text.Trim
                .ObtenerLIsta(GProyectos.IdProyecto, TIPO_ACTIVIDAD_MODULO.ACTIVIDAD)
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            lblEstado.Text = "Error no existe entregable!"
            lblEstado.Image = My.Resources.cross
        End If

    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        If (lsvActividades.SelectedItems.Count > 0) Then
            If MessageBox.Show("Desea quitar la asignación?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                QuitarEnlazados(lsvActividades.SelectedItems(0).SubItems(0).Text)
                lsvActividades.SelectedItems(0).Remove()
            End If
        Else
            lblEstado.Text = "Error no existe actividad!"
            lblEstado.Image = My.Resources.cross
        End If
       
    End Sub
End Class