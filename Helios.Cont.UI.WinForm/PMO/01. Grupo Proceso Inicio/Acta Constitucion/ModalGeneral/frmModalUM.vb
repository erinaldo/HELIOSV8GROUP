Imports Helios.General.Constantes
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity

Public Class frmModalUM
    Public Property actyon As String

    Private Sub ImprimirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ImprimirToolStripButton.Click
        Me.Close()
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case actyon
            Case ENTITY_ACTIONS.INSERT
                Grabar()
        End Select
        Me.Cursor = Cursors.Arrow

    End Sub

    Sub Grabar()
        Dim recursoSA As New tablaDetalleSA
        Dim objrecurso As New tabladetalle
        Try

        
        objrecurso = New tabladetalle With {
        .Action = Business.Entity.BaseBE.EntityAction.INSERT,
        .idtabla = 6,
        .codigoDetalle = txtCodigoDetalle.Text,
        .descripcion = txtDescipcionUM.Text,
        .estadodetalle = 1,
        .usuarioModificacion = Nothing,
        .fechaModificacion = Date.Now}

            If (recursoSA.InsertarTablaDetalle(objrecurso) <> Nothing) Then
                Select Case Tag
                    Case "MS"
                        With frmModalSuministros
                            .txtUM.AutoCompleteCustomSource.Add(txtDescipcionUM.Text)
                            .txtCodigoDetalle.Text = txtCodigoDetalle.Text
                        End With
                    Case "MC"
                        With frmModalCotizacion
                            .txtUM.AutoCompleteCustomSource.Add(txtDescipcionUM.Text)
                            .txtCodigoDetalle.Text = txtCodigoDetalle.Text
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