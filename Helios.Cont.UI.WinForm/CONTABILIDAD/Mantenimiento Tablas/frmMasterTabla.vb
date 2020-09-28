Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmMasterTabla

#Region "Metodos"

    Sub ObtenerListaTablaNombre(strNombreTabla As String)
        Dim TablaDetalleSA As New tablaDetalleSA
        lsvTablas.Items.Clear()
        For Each i In TablaDetalleSA.ObtenerTablaPorNombre(strNombreTabla)
            Dim n As New ListViewItem(i.codigoDetalle)
            n.SubItems.Add(i.descripcion)
            n.SubItems.Add(i.idtabla)
            lsvTablas.Items.Add(n)
        Next
    End Sub

    Sub eliminarTablaDetalle()

        Dim tabladetalleSA As New tablaDetalleSA
        Dim TabDetall As New tabladetalle
        Try
            TabDetall = New tabladetalle With {
            .Action = Business.Entity.BaseBE.EntityAction.INSERT,
            .codigoDetalle = lsvTablas.SelectedItems(0).SubItems(0).Text}

            If (tabladetalleSA.DeleteTablaDetalle(TabDetall)) Then
                lblEstado.Text = "Detalle Eliminado!"
                lblEstado.Image = My.Resources.ok4

                lsvTablas.SelectedItems(0).Remove()

            Else
                lblEstado.Text = "Error al Eliminar "
                lblEstado.Image = My.Resources.cross
            End If

        Catch ex As Exception
            lblEstado.Text = "Error al Eliminar" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try

    End Sub

#End Region

    Private Sub frmMasterTabla_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmMasterTabla_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim propiedadListView As System.Reflection.PropertyInfo
        propiedadListView = GetType(ListView).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance)
        propiedadListView.SetValue(lsvTablas, True, Nothing)
    End Sub

    Private Sub LinkLabel1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LinkLabel1.MouseClick
        LinkLabel1.ContextMenuStrip.Show(LinkLabel1, e.Location)
    End Sub

    Private Sub ImprimirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ImprimirToolStripButton.Click
        Dispose()
    End Sub

    Private Sub TipoDeMedioDePagoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TipoDeMedioDePagoToolStripMenuItem.Click
        txtTabla.Text = TipoDeMedioDePagoToolStripMenuItem.Text
        txtidtabla.Text = "1"
        ObtenerListaTablaNombre(TipoDeMedioDePagoToolStripMenuItem.Text)
    End Sub

    Private Sub TipoDeDocumentoDeIdentidadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TipoDeDocumentoDeIdentidadToolStripMenuItem.Click
        txtTabla.Text = TipoDeDocumentoDeIdentidadToolStripMenuItem.Text
        txtidtabla.Text = "2"
        ObtenerListaTablaNombre(TipoDeDocumentoDeIdentidadToolStripMenuItem.Text)
    End Sub

    Private Sub EntidadFinancieraToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EntidadFinancieraToolStripMenuItem.Click
        txtTabla.Text = EntidadFinancieraToolStripMenuItem.Text
        txtidtabla.Text = "3"
        ObtenerListaTablaNombre(EntidadFinancieraToolStripMenuItem.Text)
    End Sub

    Private Sub TipoDeMonedaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TipoDeMonedaToolStripMenuItem.Click
        txtTabla.Text = TipoDeMonedaToolStripMenuItem.Text
        txtidtabla.Text = "4"
        ObtenerListaTablaNombre(TipoDeMonedaToolStripMenuItem.Text)
    End Sub

    Private Sub TipoDeExistenciaTabla5ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TipoDeExistenciaTabla5ToolStripMenuItem.Click
        txtTabla.Text = TipoDeExistenciaTabla5ToolStripMenuItem.Text
        txtidtabla.Text = "5"
        ObtenerListaTablaNombre(TipoDeExistenciaTabla5ToolStripMenuItem.Text)
    End Sub

    Private Sub UnidadDeMedidaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UnidadDeMedidaToolStripMenuItem.Click
        txtTabla.Text = UnidadDeMedidaToolStripMenuItem.Text
        txtidtabla.Text = "6"
        ObtenerListaTablaNombre(UnidadDeMedidaToolStripMenuItem.Text)
    End Sub

    Private Sub CódigoDelLibroORegistroToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CódigoDelLibroORegistroToolStripMenuItem.Click
        txtTabla.Text = CódigoDelLibroORegistroToolStripMenuItem.Text
        txtidtabla.Text = "8"
        ObtenerListaTablaNombre(CódigoDelLibroORegistroToolStripMenuItem.Text)
    End Sub

    Private Sub TipoDeComprobanteDePagoODocumentoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TipoDeComprobanteDePagoODocumentoToolStripMenuItem.Click
        txtTabla.Text = TipoDeComprobanteDePagoODocumentoToolStripMenuItem.Text
        txtidtabla.Text = "10"
        ObtenerListaTablaNombre(TipoDeComprobanteDePagoODocumentoToolStripMenuItem.Text)
    End Sub

    Private Sub TipoEstablecimientosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TipoEstablecimientosToolStripMenuItem.Click
        txtTabla.Text = TipoEstablecimientosToolStripMenuItem.Text
        txtidtabla.Text = "14"
        ObtenerListaTablaNombre(TipoEstablecimientosToolStripMenuItem.Text)
    End Sub

    Private Sub NacionalidadesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NacionalidadesToolStripMenuItem.Click
        txtTabla.Text = NacionalidadesToolStripMenuItem.Text
        txtidtabla.Text = "98"
        ObtenerListaTablaNombre(NacionalidadesToolStripMenuItem.Text)
    End Sub

    Private Sub CargosUOcupaciónToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CargosUOcupaciónToolStripMenuItem.Click
        txtTabla.Text = CargosUOcupaciónToolStripMenuItem.Text
        txtidtabla.Text = "200"
        ObtenerListaTablaNombre(CargosUOcupaciónToolStripMenuItem.Text)
    End Sub

    Private Sub GradoDeInstrucciónToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GradoDeInstrucciónToolStripMenuItem.Click
        txtTabla.Text = GradoDeInstrucciónToolStripMenuItem.Text
        txtidtabla.Text = "201"
        ObtenerListaTablaNombre(GradoDeInstrucciónToolStripMenuItem.Text)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

    End Sub

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click

        If (txtTabla.Text <> "") Then
            With frmTablaDetalle
                .txtTablaMaestra.Text = txtTabla.Text
                '.limpiarCajas()
                .actyon = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            If (txtTabla.Text = "") Then
                lblEstado.Text = "Debe seleccionar una tabla"
                lblEstado.Image = My.Resources.cross
            End If
        End If
    End Sub

    Private Sub txtTabla_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTabla.TextChanged

    End Sub

    Private Sub AbrirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles AbrirToolStripButton.Click
        If lsvTablas.SelectedItems.Count > 0 Then
            With frmTablaDetalle
                .actyon = ENTITY_ACTIONS.UPDATE
                .txtTablaMaestra.Text = txtTabla.Text
                .txtCodigo.Text = lsvTablas.SelectedItems(0).SubItems(0).Text
                .txtDescripcion.Text = lsvTablas.SelectedItems(0).SubItems(1).Text
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else

            lblEstado.Text = "Debe seleccionar una tabla"
            lblEstado.Image = My.Resources.cross

        End If
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        If lsvTablas.SelectedItems.Count > 0 Then
            eliminarTablaDetalle()
        Else
            lblEstado.Text = "Debe seleccionar una fila"
            lblEstado.Image = My.Resources.cross
        End If
    End Sub
End Class