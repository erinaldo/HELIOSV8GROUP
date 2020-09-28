Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Public Class frmTransferenciaSobrante
    Inherits frmMaster

    Public Sub GetUbicarNotificacion(strIdEmpresa As String, intIdEstablecimiento As Integer, strEstado As String)
        Dim notificacionAlmacenSA As New notificacionAlmacenSA

        Try
            lsvNotificaciones.Items.Clear()
            For Each i In notificacionAlmacenSA.GetUbicarNotificacion(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "NS")
                Dim n As New ListViewItem(i.idDocumento)
                n.SubItems.Add(i.glosa)
                n.SubItems.Add(i.idEmpresa)
                n.SubItems.Add(i.idCentroCosto)
                n.SubItems.Add(i.serie)
                n.SubItems.Add(i.numeroDoc)
                n.SubItems.Add(i.nombreProveedor)
                n.SubItems.Add(i.idProveedor)
                lsvNotificaciones.Items.Add(n)
            Next
            lsvNotificaciones.Text = "Nro. Notificaciones: " & lsvNotificaciones.Items.Count

        Catch ex As Exception
            lsvNotificaciones.Text = ex.Message
        End Try
    End Sub

    Private Sub frmTransferenciaSobrante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetUbicarNotificacion(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, TIPO_SITUACION.NOTIFICACION_SOBRANTE)
    End Sub

    Private Sub lsvNotificaciones_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvNotificaciones.MouseDoubleClick
        With frmAlmacenTransfenciaSobrante
            .UbicarDocumento(lsvNotificaciones.SelectedItems(0).SubItems(4).Text, lsvNotificaciones.SelectedItems(0).SubItems(5).Text, lsvNotificaciones.SelectedItems(0).SubItems(7).Text)
            .txtSerie.Text = lsvNotificaciones.SelectedItems(0).SubItems(4).Text
            .txtNumero.Text = lsvNotificaciones.SelectedItems(0).SubItems(6).Text
            .txtProveedor.Text = lsvNotificaciones.SelectedItems(0).SubItems(6).Text
            .idDocNotificacion = lsvNotificaciones.SelectedItems(0).SubItems(0).Text
            .lblPerido.Text = PeriodoGeneral
            .ShowDialog()
        End With
    End Sub

    Private Sub lsvNotificaciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvNotificaciones.SelectedIndexChanged

    End Sub
End Class