Imports Helios.General.Constantes
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Public Class frmModalClasificacionItem

    Public Property actyon As String

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case actyon
            Case ENTITY_ACTIONS.INSERT
                Grabar()
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ImprimirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ImprimirToolStripButton.Click
        Dispose()
    End Sub

    Sub Grabar()
        Dim recursoSA As New itemSA
        Dim objrecurso As New item
        Dim codigo As Integer
        Try
            objrecurso = New item With {
            .Action = Business.Entity.BaseBE.EntityAction.INSERT,
             .idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .descripcion = txtDescipcionUM.Text,
            .fechaIngreso = Date.Now,
            .usuarioActualizacion = "NN",
            .fechaActualizacion = Date.Now}
            codigo = recursoSA.InsertarItemClasificaion(objrecurso)

            If (codigo <> Nothing) Then
                Select Case Tag
                    Case "MS"
                        With frmModalSuministros
                            .txtClasificacion.AutoCompleteCustomSource.Add(txtDescipcionUM.Text)
                            .txtCodigoItems.Text = codigo
                        End With
                    Case "MC"
                        With frmModalCotizacion
                            .txtClasificacion.AutoCompleteCustomSource.Add(txtDescipcionUM.Text)
                            .txtCodigoItems.Text = codigo
                        End With
                End Select
                lblEstado.Text = "Unidad Medida agregada!"
                lblEstado.Image = My.Resources.ok4

                Dispose()
            End If
        Catch ex As Exception
            lblEstado.Text = "Error Unidad Medida!"
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub
End Class