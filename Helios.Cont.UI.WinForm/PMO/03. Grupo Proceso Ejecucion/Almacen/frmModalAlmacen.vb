Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmModalAlmacen
    Inherits frmMaster

#Region "Métodos"

    Public Sub ObtenerAlmacenes(intIdEstablecimiento As Integer)
        Dim almacenSA As New almacenSA
        lsvAlmacen.Items.Clear()
        For Each i As almacen In almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = intIdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim n As New ListViewItem(i.idAlmacen)
            n.SubItems.Add(i.descripcionAlmacen)
            n.SubItems.Add(i.encargado)
            lsvAlmacen.Items.Add(n)
        Next
        If lsvAlmacen.Items.Count > 0 Then
            lsvAlmacen.Items(0).Selected = True
            lsvAlmacen.Items(0).Focused = True
        End If
        lblEstado.Text = "Almacenes encontrados: " & lsvAlmacen.Items.Count
        lblEstado.Image = My.Resources.ok4
    End Sub

    Public Sub ObtenerAlmacenes(intIdEstablecimiento As Integer, idAlmacen As Integer)
        Dim almacenSA As New almacenSA
        lsvAlmacen.Items.Clear()
        For Each i As almacen In almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = intIdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            If (i.idAlmacen <> idAlmacen) Then
                Dim n As New ListViewItem(i.idAlmacen)
                n.SubItems.Add(i.descripcionAlmacen)
                n.SubItems.Add(i.encargado)
                lsvAlmacen.Items.Add(n)
            End If

        Next
        If lsvAlmacen.Items.Count > 0 Then
            lsvAlmacen.Items(0).Selected = True
            lsvAlmacen.Items(0).Focused = True
        End If
        lblEstado.Text = "Almacenes encontrados: " & lsvAlmacen.Items.Count
        lblEstado.Image = My.Resources.ok4
    End Sub

#End Region

    Private Sub frmModalAlmacen_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmModalAlmacen_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs)
        Dispose()
    End Sub

    Private Sub lsvAlmacen_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lsvAlmacen.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If lsvAlmacen.SelectedItems.Count > 0 Then
                Dim n As New RecuperarCarteras()
                Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
                datos.Clear()
                n.ID = lsvAlmacen.SelectedItems(0).SubItems(0).Text
                n.NombreEntidad = lsvAlmacen.SelectedItems(0).SubItems(1).Text
                n.IdResponsable = lsvAlmacen.SelectedItems(0).SubItems(2).Text
                datos.Add(n)
                Dispose()
            End If
        End If
    End Sub

    Private Sub lsvAlmacen_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvAlmacen.MouseDoubleClick
        If lsvAlmacen.SelectedItems.Count > 0 Then
            Dim n As New RecuperarCarteras()
            Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            datos.Clear()
            n.ID = lsvAlmacen.SelectedItems(0).SubItems(0).Text
            n.NombreEntidad = lsvAlmacen.SelectedItems(0).SubItems(1).Text
            n.IdResponsable = lsvAlmacen.SelectedItems(0).SubItems(2).Text
            datos.Add(n)
            Dispose()
        End If
    End Sub

    Private Sub lsvAlmacen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvAlmacen.SelectedIndexChanged

    End Sub
End Class