Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmTotalProdAlmacen
    Inherits frmMaster

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub

    Public Sub ObtenerListaAlmacen(ByVal strIdAlmacen As String)
        Dim TotalesAlamacenSA As New TotalesAlmacenSA
        Dim establecimientoSA As New establecimientoSA
        Try
            lsvAlmacen.Items.Clear()
            For Each i In TotalesAlamacenSA.GetUbicarTotalesAlmacen(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strIdAlmacen)
                If (i.cantidad > 0) Then
                    Dim n As New ListViewItem(i.idMovimiento)
                    n.SubItems.Add(i.idEmpresa)
                    n.SubItems.Add(i.idEstablecimiento)
                    n.SubItems.Add(i.idItem)
                    n.SubItems.Add(i.descripcion)
                    n.SubItems.Add(i.cantidad)
                    n.SubItems.Add(i.idAlmacen)
                    n.SubItems.Add(i.NomAlmacen)
                    lsvAlmacen.Items.Add(n)
                End If
            Next
            lblEstado.Text = "Nro. trabajadores: " & lsvAlmacen.Items.Count
            lblEstado.Image = My.Resources.ok4
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Private Sub lsvAlmacen_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvAlmacen.MouseDoubleClick
      
    End Sub

    Private Sub frmTotalProdAlmacen_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub


    Private Sub frmTotalProdAlmacen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lsvAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvAlmacen.SelectedIndexChanged
        If lsvAlmacen.SelectedItems.Count > 0 Then
            txtCanDevolver.Value = lsvAlmacen.SelectedItems(0).SubItems(5).Text
            txtAlmacen.Text = lsvAlmacen.SelectedItems(0).SubItems(7).Text
            txtAlmacen.Tag = lsvAlmacen.SelectedItems(0).SubItems(6).Text
        End If
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        Dim n As New RecuperarCarteras
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        If txtCanDevolver.Value > 0 Then

            If txtCanDevolver.Value > CDec(txtCantidad.Text) Then
                MessageBox.Show("Ingrese una cantidad menor a la disponible.")
                txtCanDevolver.Select()
                txtCanDevolver.Focus()
                txtCanDevolver.Value = 0
                Exit Sub
            Else
                With frmAlmacenTransfenciaSobrante
                    n.NomProceso = txtAlmacen.Text
                    n.IdProceso = txtAlmacen.Tag
                    n.IdEvento = txtCanDevolver.Value
                    With totalesAlmacenSA.GetUbicarProductoTAlmacen(txtAlmacen.Tag, txtIdItem.Text)
                        n.PMmn = Math.Round(CDec(.importeSoles) / CDec(.cantidad), 2)
                        n.PMme = Math.Round(CDec(.importeDolares) / CDec(.cantidad), 2)
                    End With
                    n.Montomn = txtCanDevolver.Value * n.PMmn
                    n.Montome = txtCanDevolver.Value * n.PMme
                    datos.Add(n)
                End With
                Dispose()
            End If

     
        End If

        'If (CDec(lsvAlmacen.SelectedItems(0).SubItems(5).Text) >= CDec(txtCantidad.Text)) Then
     
    End Sub

    Private Sub txtCanDevolver_ValueChanged(sender As Object, e As EventArgs) Handles txtCanDevolver.ValueChanged
        'If txtCanDevolver.Value > CDec(txtCantidad.Text) Then
        '    MessageBox.Show("Ingrese una cantidad menor a la disponible.")
        '    txtCanDevolver.Select()
        '    txtCanDevolver.Focus()
        '    txtCanDevolver.Value = 0
        '    Exit Sub
        'Else


        'End If
    End Sub
End Class