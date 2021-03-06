Imports Helios.General
Imports Helios.Cont.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmModalActividadPorProyecto

#Region "Métodos"
    Public Sub ListaModal(intIdPadre As Integer, strModulo As String, strFlag As String)
        Dim actividadSA As New ActividadesSA
        lsvActividad.Items.Clear()
        For Each i In actividadSA.GetListaActividadPorProyecto(intIdPadre, strModulo, strFlag)
            Dim n As New ListViewItem(i.idActividad)
            Select Case strModulo
                Case TIPO_ACTIVIDAD_MODULO.FASE
                    colFase.Text = "FASE"
                    n.SubItems.Add(i.NombreActividad)
                Case TIPO_ACTIVIDAD_MODULO.ENTREGABLE
                    colFase.Text = "ENTREGABLE"
                    n.SubItems.Add(i.descripcion)
                Case TIPO_ACTIVIDAD_MODULO.ACTIVIDAD
                    colFase.Text = "ACTIVIDAD"
                    n.SubItems.Add(i.NombreActividad)
                Case TIPO_ACTIVIDAD_MODULO.PROYECTO
                    colFase.Text = "PROYECTO"
                    n.SubItems.Add(i.NombreActividad)
            End Select
            lsvActividad.Items.Add(n)
        Next
    End Sub
#End Region

    Private Sub lsvActividad_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvActividad.MouseDoubleClick
        If lsvActividad.SelectedItems.Count > 0 Then
            Dim n As New RecuperarCarteras()
            Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            datos.Clear()
            n.ID = lsvActividad.SelectedItems(0).SubItems(0).Text
            n.NombreEntidad = lsvActividad.SelectedItems(0).SubItems(1).Text
            datos.Add(n)
            Dispose()
        End If
    End Sub

    Private Sub lsvActividad_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvActividad.SelectedIndexChanged

    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dispose()
    End Sub
End Class