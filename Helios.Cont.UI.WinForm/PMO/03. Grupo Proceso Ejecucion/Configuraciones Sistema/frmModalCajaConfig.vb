Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmModalCajaConfig
#Region "Métodos"
    Public Sub ObtenerEntidadesFinancieras(ByVal intIdEstablecimiento As Integer, ByVal strTipoEF As String, ByVal strMoneda As String)
        Dim objEstados As New EstadosFinancierosSA
        Try
            lsvCajas.Items.Clear()
            For Each i In objEstados.ObtenerEstadosFinancierosPorMoneda(intIdEstablecimiento, strTipoEF, strMoneda)
                Dim n As New ListViewItem(i.idestado)
                n.UseItemStyleForSubItems = False
                n.SubItems.Add(i.descripcion)
                n.SubItems.Add(i.tipo)
                n.SubItems.Add(i.codigo).BackColor = Color.LightYellow
                n.SubItems.Add(i.cuenta)
                lsvCajas.Items.Add(n)
            Next
            If lsvCajas.Items.Count > 0 Then
                lsvCajas.Focus()
                lsvCajas.Items(0).Selected = True
                lsvCajas.Items(0).Focused = True
            End If
        Catch ex As Exception
            MsgBox("No se pudo cargar la información para la lista de EF." & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

    Private Sub frmModalCajaConfig_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub KryptonComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub frmModalCajaConfig_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtEstablecimiento.ValueMember = GEstableciento.IdEstablecimiento
        txtEstablecimiento.Text = GEstableciento.NombreEstablecimiento

        ObtenerEntidadesFinancieras(GEstableciento.IdEstablecimiento, IIf(cboTipo.Text = "EFECTIVO", "EF", "BC"), IIf(cboMoneda.Text = "NACIONAL", "1", "2"))
    End Sub

    Private Sub lsvCajas_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lsvCajas.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If lsvCajas.SelectedItems.Count > 0 Then
                Dim n As New RecuperarTablas()
                Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
                datos.Clear()
                n.ID = lsvCajas.SelectedItems(0).SubItems(0).Text
                n.NombreCampo = lsvCajas.SelectedItems(0).SubItems(1).Text
                n.Codigo = lsvCajas.SelectedItems(0).SubItems(1).Text
                datos.Add(n)
                Dispose()
            End If
        End If
    End Sub

    Private Sub lsvCajas_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvCajas.MouseDoubleClick
        If lsvCajas.SelectedItems.Count > 0 Then
            Dim n As New RecuperarTablas()
            Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
            datos.Clear()
            n.ID = lsvCajas.SelectedItems(0).SubItems(0).Text
            n.NombreCampo = lsvCajas.SelectedItems(0).SubItems(1).Text
            n.Codigo = lsvCajas.SelectedItems(0).SubItems(1).Text
            datos.Add(n)
            Dispose()
        End If
    End Sub

    Private Sub lsvCajas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvCajas.SelectedIndexChanged

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalEstablecimientoCaja
        '    .StrParametroCarga = "ET"
        '    .ObtenerEstablecimientos()
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtEstablecimiento.ValueMember = datos(0).ID
        '        txtEstablecimiento.Text = datos(0).NombreCampo
        '        If txtEstablecimiento.ValueMember.Trim.Length > 0 And cboTipo.Text.Trim.Length > 0 And cboMoneda.Text.Trim.Length > 0 Then
        '            ObtenerEntidadesFinancieras(txtEstablecimiento.ValueMember, IIf(cboTipo.Text = "EFECTIVO", "EF", "BC"), IIf(cboMoneda.Text = "NACIONAL", "1", "2"))
        '        End If
        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        If cboTipo.SelectedIndex > -1 Then
            If txtEstablecimiento.ValueMember.Trim.Length > 0 And cboTipo.Text.Trim.Length > 0 And cboMoneda.Text.Trim.Length > 0 Then
                ObtenerEntidadesFinancieras(txtEstablecimiento.ValueMember, IIf(cboTipo.Text = "EFECTIVO", "EF", "BC"), IIf(cboMoneda.Text = "NACIONAL", "1", "2"))
            End If
        End If
    End Sub

    Private Sub cboMoneda_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboMoneda.SelectedIndexChanged
        If cboMoneda.SelectedIndex > -1 Then
            If txtEstablecimiento.ValueMember.Trim.Length > 0 And cboTipo.Text.Trim.Length > 0 And cboMoneda.Text.Trim.Length > 0 Then
                ObtenerEntidadesFinancieras(txtEstablecimiento.ValueMember, IIf(cboTipo.Text = "EFECTIVO", "EF", "BC"), IIf(cboMoneda.Text = "NACIONAL", "1", "2"))
            End If
        End If
    End Sub
End Class