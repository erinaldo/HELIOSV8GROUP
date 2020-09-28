Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmModalEstadosFinancieros

#Region "Métodos"
    Public Sub ObtenerEstadosFinancieros(ByVal intIdEstablecimiento As Integer, ByVal strTipoEF As String, ByVal strMoneda As String)
        Dim objEstados As New EstadosFinancierossa
        Try
            lsvTareas.Columns.Clear()
            lsvTareas.Items.Clear()
            lsvTareas.Columns.Add("ID", 0) '0
            lsvTareas.Columns.Add("cuenta", 0) '1
            lsvTareas.Columns.Add("codigo", 0) '2
            lsvTareas.Columns.Add("tipo", 0) '3
            lsvTareas.Columns.Add("Entidad Financiera", 290) '4
            For Each i In objEstados.ObtenerEstadosFinancierosPorMoneda(intIdEstablecimiento, strTipoEF, strMoneda)
                Dim n As New ListViewItem(i.idestado)
                n.SubItems.Add(i.cuenta)
                n.SubItems.Add(i.codigo)
                n.SubItems.Add(i.tipo)
                n.SubItems.Add(i.descripcion)
                lsvTareas.Items.Add(n)
            Next
        Catch ex As Exception
            MsgBox("No se pudo cargar la información para la lista de EF." & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Dispose()
    End Sub

    Private Sub lsvTareas_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvTareas.MouseDoubleClick
        If lsvTareas.SelectedItems.Count > 0 Then
            Dim n As New RecuperarTablas()
            Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
            datos.Clear()
            n.ID = lsvTareas.SelectedItems(0).SubItems(0).Text
            n.NombreCampo = lsvTareas.SelectedItems(0).SubItems(4).Text
            n.Codigo = lsvTareas.SelectedItems(0).SubItems(1).Text
            datos.Add(n)
            Dispose()
        End If
    End Sub

    Private Sub lsvTareas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvTareas.SelectedIndexChanged

    End Sub
End Class