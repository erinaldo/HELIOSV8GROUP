Imports Helios.Cont.Business.Entity

Public Class ucBuscarEntidades
    Public Sub New(ucDistribucion As ucDistribucion)

        ' This call is required by the designer.
        InitializeComponent()
        _UcDistribucion = ucDistribucion
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public ReadOnly Property _UcDistribucion As ucDistribucion

    Private Sub TextLikeCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles TextLikeCliente.KeyDown
        'If e.KeyCode = Keys.Enter Then
        'e.SuppressKeyPress = True
        If _UcDistribucion.consultaClientes IsNot Nothing Then
                Dim filter = TextLikeCliente.Text.Trim
                Dim consulta = _UcDistribucion.consultaClientes.Where(Function(o) o.nombreCompleto.Contains(filter) Or o.nrodoc.Contains(filter)).ToList
                LsvProveedor.Items.Clear()
                If consulta.Count > 0 Then
                    FillLSVClientes(consulta)
                End If
            End If
        'End If
    End Sub

    Public Sub FillLSVClientes(consulta As List(Of entidad))
        LsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            n.SubItems.Add(i.tipoDoc)
            LsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Sub LsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick
        If LsvProveedor.SelectedItems.Count > 0 Then

            _UcDistribucion.TextCliente.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
            _UcDistribucion.TextCliente.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
            _UcDistribucion.LabelNumDoc.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text

            _UcDistribucion.GetVentasXdistribuirSelCliente(Integer.Parse(LsvProveedor.SelectedItems(0).SubItems(0).Text))
        End If
    End Sub

    Private Sub LsvProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LsvProveedor.SelectedIndexChanged

    End Sub
End Class
