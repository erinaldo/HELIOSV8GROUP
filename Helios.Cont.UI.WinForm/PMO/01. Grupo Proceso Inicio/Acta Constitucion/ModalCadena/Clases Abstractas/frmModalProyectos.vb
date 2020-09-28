Imports Helios.Cont.Business.Entity
Imports Helios.General

'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmModalProyectos

    Public IdEstablecimiento As Integer
    Public currentPage As Integer = 0
    Public currentSize As Integer = 10
    Public xConteo As Integer = 0
    Dim conteoPaginado As Integer

#Region "Métdoso"
    Public Sub ObtenerProyectosModal()
        Dim ProyectosSA As New ProyectoPlaneacionSA
        Dim actividad As New Actividades
        '   Dim actividadsa As New ActividadesSA
        Try
            lsvEntidades.Items.Clear()
            For Each i In ProyectosSA.ObtenerListaProyectos(GEstableciento.IdEstablecimiento)
                Dim n As New ListViewItem(i.idProyecto)
                n.SubItems.Add(i.nombreProyecto)
                n.SubItems.Add(i.fechaInicio)
                n.SubItems.Add(i.fechaFinal)
                n.SubItems.Add(i.responsable)
                n.SubItems.Add(i.idProyecto)
                lsvEntidades.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub frmModalProyectos_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dispose()
    End Sub

    Private Sub frmModalProyectos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lsvEntidades_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvEntidades.MouseDoubleClick
        If lsvEntidades.SelectedItems.Count > 0 Then
            Dim ActividadSA As New ActividadesSA
            Dim Actividad As New Actividades
            Dim n As New RecuperarCarteras()
            Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            datos.Clear()
            Actividad = ActividadSA.GetUbicaProyectoActividad(lsvEntidades.SelectedItems(0).SubItems(0).Text, "PY")
            n.ID = Actividad.idActividad ' lsvEntidades.SelectedItems(0).SubItems(0).Text
            n.NombreEntidad = lsvEntidades.SelectedItems(0).SubItems(1).Text
            n.IdResponsable = lsvEntidades.SelectedItems(0).SubItems(4).Text
            n.IdEvento = lsvEntidades.SelectedItems(0).SubItems(5).Text
            datos.Add(n)
            Dispose()
        End If
    End Sub


    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton7.Click


    End Sub



    Private Sub lsvEntidades_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvEntidades.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If lsvEntidades.GetItemAt(e.X, e.Y) IsNot Nothing Then
                '  lsvOrigen.GetItemAt(e.X, e.Y).Selected = True
                ContextMenuStrip1.Show(lsvEntidades, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub lsvEntidades_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvEntidades.SelectedIndexChanged

    End Sub
End Class