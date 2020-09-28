Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmCanastaTributo
    Inherits frmMaster

#Region "Métodos"
    Public Sub UbicarDetalleTributo(intidDocumento As Integer)
        Dim DetalleSA As New DocumentoObligacionDetalleSA
        lsvCanasta.Items.Clear()

        For Each i As documentoObligacionDetalle In DetalleSA.UbicarDetallePorTributo(intidDocumento)
            Dim n As New ListViewItem(i.idDocumento)
            n.SubItems.Add(i.idItem)
            n.SubItems.Add(i.descripcionItem)
            n.SubItems.Add(i.unidadMedida)
            n.SubItems.Add("")
            n.SubItems.Add(i.porcTributo)
            n.SubItems.Add(i.importeMN)
            n.SubItems.Add(i.importeME)
            lsvCanasta.Items.Add(n)
        Next

    End Sub
#End Region

    Private Sub frmCanastaTributo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub QRibbonCaption1_ItemActivated(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs)

    End Sub
End Class