Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmTabbBusqueda
   

    Sub ProveedoresShows()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        'With frmModalEntidades
        '    .lblTipo.Text = TIPO_ENTIDAD.PROVEEDOR
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    'If datos.Count > 0 Then
        '    '    lsvDocs.Items.Clear()
        '    '    txtBusqueda.DisplayMember = datos(0).NombreEntidad
        '    '    txtBusqueda.Text = datos(0).NombreEntidad
        '    '    txtBusqueda.ValueMember = datos(0).ID
        '    '    ObtenerDocumentosPorProveedor(datos(0).ID)
        '    'End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub

#Region "Metodos"
    'Public Sub ObtenerDocumentosPorProveedor(intIdEntidad As Integer)
    '    Dim documentoSA As New DocumentoCompraSA

    '    Try
    '        lsvDocs.Items.Clear()
    '        For Each i As documentocompra In documentoSA.GetListarComprasPorProveedor(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, intIdEntidad)
    '            Dim n As New ListViewItem(i.idDocumento)
    '            n.SubItems.Add(i.fechaDoc)
    '            n.SubItems.Add(i.tipoDoc)
    '            n.SubItems.Add(i.numeroDoc)
    '            lsvDocs.Items.Add(n)
    '        Next
    '    Catch ex As Exception

    '    End Try
    'End Sub
#End Region
    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        ProveedoresShows()
    End Sub

    Private Sub frmTabbBusqueda_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cboBuscar.Text = "Rango de fecha"
    End Sub

    Private Sub cboBuscar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboBuscar.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles cboBuscar.TextChanged
        Select Case cboBuscar.Text
            Case "Rango de fecha"
                QTabPage1.Parent = QTabControl1
                QTabPage2.Parent = Nothing
                QTabPage3.Parent = Nothing
            Case "Nro. de comprobante"
                QTabPage1.Parent = Nothing
                QTabPage2.Parent = QTabControl1
                QTabPage3.Parent = Nothing
            Case "Entidad"
                QTabPage1.Parent = Nothing
                QTabPage2.Parent = Nothing
                QTabPage3.Parent = QTabControl1
        End Select



    End Sub
End Class