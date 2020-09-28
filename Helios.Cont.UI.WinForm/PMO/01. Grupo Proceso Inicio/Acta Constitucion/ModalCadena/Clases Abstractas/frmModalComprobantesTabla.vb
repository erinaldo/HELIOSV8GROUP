Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmModalComprobantesTabla
    Public Property x_Establecimiento() As Integer
#Region "Métodos"
    Public Property Tablax As Tablas
    Enum Tablas
        TipoExistencia = 5
        Clasificacion = 0
        UnidadMedidad = 6
        Presentacion = 21
        Cuenta = 3
    End Enum
    Public Sub ObtenerComprobantesPorTipo(ByVal IntTabla As Integer)
        Dim tablaSA As New tablaDetalleSA
        Dim objListaItems As New itemSA
        Try

            lsvEntidades.Columns.Clear()
            lsvEntidades.Items.Clear()
            lsvEntidades.Columns.Add("ID", 50)
            lsvEntidades.Columns.Add("Código", 0)
            lsvEntidades.Columns.Add("Descripción", 240)

            Select Case IntTabla
                Case 0
                    For Each i In objListaItems.GetListaItemPorEstable(GEstableciento.IdEstablecimiento)
                        Dim n As New ListViewItem(i.idItem)
                        n.SubItems.Add(i.idItem)
                        n.SubItems.Add(i.descripcion)
                        lsvEntidades.Items.Add(n)
                    Next
                Case Else
                    For Each i As tabladetalle In tablaSA.GetListaTablaDetalle(IntTabla, "1")
                        Dim n As New ListViewItem(i.codigoDetalle)
                        n.SubItems.Add(i.codigoDetalle2)
                        n.SubItems.Add(i.descripcion)
                        lsvEntidades.Items.Add(n)
                    Next
            End Select
            If lsvEntidades.Items.Count > 0 Then
                lsvEntidades.Focus()
                lsvEntidades.Items(0).Selected = True
                lsvEntidades.Items(0).Focused = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub frmModalComprobantesTabla_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmModalComprobantesTabla_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ObtenerComprobantesPorTipo(lblTipo.Text)
        '    txtBusqueda.Select()
    End Sub

    Private Sub lsvEntidades_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lsvEntidades.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If lsvEntidades.SelectedItems.Count > 0 Then
                Dim n As New RecuperarTablas()
                Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
                datos.Clear()
                n.ID = lsvEntidades.SelectedItems(0).SubItems(0).Text
                n.NombreCampo = lsvEntidades.SelectedItems(0).SubItems(2).Text
                datos.Add(n)
                Dispose()
            End If
        End If
    End Sub

    Private Sub lsvEntidades_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvEntidades.MouseDoubleClick
        If lsvEntidades.SelectedItems.Count > 0 Then
            Dim n As New RecuperarTablas()
            Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
            datos.Clear()
            n.ID = lsvEntidades.SelectedItems(0).SubItems(0).Text
            n.NombreCampo = lsvEntidades.SelectedItems(0).SubItems(2).Text
            datos.Add(n)
            Dispose()
        End If
    End Sub

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click
        Select Case Tablax
            Case Tablas.Clasificacion
                'With frmManteNuevaClasificacion
                '    .X_Establecimiento = x_Establecimiento
                '    .Tag = "N"
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                '    Call ObtenerComprobantesPorTipo(0)
                'End With
        End Select
    End Sub

    Private Sub AbrirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles AbrirToolStripButton.Click
        If lsvEntidades.SelectedItems.Count > 0 Then
            'With frmManteNuevaClasificacion
            '    .X_Establecimiento = x_Establecimiento
            '    .lblId.Text = lsvEntidades.SelectedItems(0).SubItems(0).Text
            '    .txtDetalle.Text = lsvEntidades.SelectedItems(0).SubItems(2).Text
            '    .Tag = "E"
            '    .StartPosition = FormStartPosition.CenterParent
            '    .ShowDialog()
            '    Call ObtenerComprobantesPorTipo(0)
            'End With
        Else
            MsgBox("Seleccione un registro por favor.!", MsgBoxStyle.Information, "Atención!")
        End If
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub lsvEntidades_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvEntidades.SelectedIndexChanged

    End Sub
End Class