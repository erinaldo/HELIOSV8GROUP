Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmCanastaCompraDetalle
    Inherits frmMaster
#Region "Métodos"
    Public Sub UbicarDetalle(intIddocumento As Integer)
        Dim detalleSA As New DocumentoCompraDetalleSA
        Try
            lsvCanasta.Items.Clear()
            For Each i As documentocompradetalle In detalleSA.UbicarDocumentoCompraDetalle(intIddocumento)
                Dim n As New ListViewItem(i.secuencia)
                n.UseItemStyleForSubItems = False
                n.SubItems.Add(i.idItem)
                n.SubItems.Add(i.descripcionItem)
                n.SubItems.Add(i.unidad1)
                n.SubItems.Add(i.unidad2)
                n.SubItems.Add(i.monto1).BackColor = Color.LightYellow
                n.SubItems.Add(i.montokardex).BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption)
                n.SubItems.Add(i.montoIgv).BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption)
                n.SubItems.Add(i.importe).BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption)
                n.SubItems.Add(i.montokardexUS).BackColor = Color.FromArgb(225, 240, 190)
                n.SubItems.Add(i.montoIgvUS).BackColor = Color.FromArgb(225, 240, 190)
                n.SubItems.Add(i.importeUS).BackColor = Color.FromArgb(225, 240, 190)
                lsvCanasta.Items.Add(n)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub frmCanastaCompraDetalle_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub lsvCanasta_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvCanasta.MouseDoubleClick
        Dim nInsumoSA As New detalleitemsSA
        Dim n As New GInsumo()
        Dim tablaSA As New tablaDetalleSA
        Dim objInsumo As GInsumo = GInsumo.InstanceSingle
        Try
            If lsvCanasta.SelectedItems.Count > 0 Then

                objInsumo.Clear()
                objInsumo.Secuencia = lsvCanasta.SelectedItems(0).SubItems(0).Text
                objInsumo.IdInsumo = lsvCanasta.SelectedItems(0).SubItems(1).Text
                objInsumo.descripcionItem = lsvCanasta.SelectedItems(0).SubItems(2).Text
                objInsumo.unidad1 = lsvCanasta.SelectedItems(0).SubItems(3).Text
                objInsumo.Cantidad = lsvCanasta.SelectedItems(0).SubItems(5).Text
                objInsumo.PU = 0 ' lsvCanasta.SelectedItems(0).SubItems(6).Text
                objInsumo.Total = lsvCanasta.SelectedItems(0).SubItems(6).Text
                objInsumo.TotalUS = lsvCanasta.SelectedItems(0).SubItems(7).Text
                Dispose()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub lsvCanasta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvCanasta.SelectedIndexChanged

    End Sub

    Private Sub frmCanastaCompraDetalle_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class