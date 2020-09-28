Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmGuiaDetalle

    Public Sub UbicarDetalleGuia(intIdDocumento As Integer)
        Dim DetalleSA As New DocumentoGuiaDetalleSA
        Dim ItemSA As New detalleitemsSA
        lsvCanasta.Items.Clear()
        For Each i As documentoguiaDetalle In DetalleSA.UbicarDocumentoGuiaDetalle(intIdDocumento)
            Dim n As New ListViewItem()
            n.Text = i.idDocumento
            n.SubItems.Add(i.cantidad)
            n.SubItems.Add(i.idItem)
            With ItemSA.InvocarProductoID(i.idItem)
                n.SubItems.Add(.descripcionItem)
                n.SubItems.Add(.unidad1)
                n.SubItems.Add(.presentacion)
            End With
            n.SubItems.Add(i.importeMN)
            n.SubItems.Add(i.importeME)
            n.SubItems.Add(i.NombreEstablecimiento)
            n.SubItems.Add(i.NombreAlmacen)
            lsvCanasta.Items.Add(n)
        Next
    End Sub

    Private Sub frmGuiaDetalle_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub
End Class