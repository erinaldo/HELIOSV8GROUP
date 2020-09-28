Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class FrmDetalleIngresoSunat
#Region "Metodos"
    Sub ObtenerListaTablaId(intIdPadre As Integer)
        Dim ingresoSunatSA As New ingresoSunatSA
        Try
            dgvIngresoSunat.Rows.Clear()
            For Each i In ingresoSunatSA.ObtenerTablaPorId(intIdPadre)
                dgvIngresoSunat.Rows.Add(i.idIngresoSunat, i.codigoSunat,
                                         i.cuentaContable, i.descripcion, i.idPadre)
            Next
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Sub eliminarIngresoSunat()

        Dim ingresodetalleSA As New ingresoSunatSA
        Dim ingresosunat As New ingresoSunat
        Try
            ingresosunat = New ingresoSunat With {
            .Action = Business.Entity.BaseBE.EntityAction.INSERT,
            .idIngresoSunat = dgvIngresoSunat.SelectedRows(0).Cells(0).Value}

            If (ingresodetalleSA.DeleteIngresoSunat(ingresosunat)) Then
                lblEstado.Text = " Eliminado!"
                lblEstado.Image = My.Resources.ok4

                dgvIngresoSunat.Rows.RemoveAt(dgvIngresoSunat.CurrentRow.Index)

            Else
                lblEstado.Text = "Error al Eliminar "
                lblEstado.Image = My.Resources.cross
            End If

        Catch ex As Exception
            lblEstado.Text = "Error al Eliminar" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try

    End Sub
    



#End Region

    Private Sub ToolStrip2_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip2.ItemClicked

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

    End Sub

    Private Sub LinkLabel1_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LinkLabel1.MouseDoubleClick
        LinkLabel1.ContextMenuStrip.Show(LinkLabel1, e.Location)
    End Sub

    Private Sub INGRESOSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles INGRESOSToolStripMenuItem.Click
        txtDescripcion.Text = INGRESOSToolStripMenuItem.Text
        txtCodigo.Text = "100"
        ObtenerListaTablaId(txtCodigo.Text)
    End Sub

    Private Sub INGRESOSASIGNACIONESToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles INGRESOSASIGNACIONESToolStripMenuItem.Click
        txtDescripcion.Text = INGRESOSASIGNACIONESToolStripMenuItem.Text
        txtCodigo.Text = "200"
        ObtenerListaTablaId(txtCodigo.Text)
    End Sub

    Private Sub INGRESOSBONIFICACIONESToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles INGRESOSBONIFICACIONESToolStripMenuItem.Click
        txtDescripcion.Text = INGRESOSBONIFICACIONESToolStripMenuItem.Text
        txtCodigo.Text = "300"
        ObtenerListaTablaId(txtCodigo.Text)
    End Sub

    Private Sub INGRESOSGRATIFICACIONESAGUINALDOSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles INGRESOSGRATIFICACIONESAGUINALDOSToolStripMenuItem.Click
        txtDescripcion.Text = INGRESOSGRATIFICACIONESAGUINALDOSToolStripMenuItem.Text
        txtCodigo.Text = "400"
        ObtenerListaTablaId(txtCodigo.Text)
    End Sub

    Private Sub INGRESOSINDEMNIZACIONESToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles INGRESOSINDEMNIZACIONESToolStripMenuItem.Click
        txtDescripcion.Text = INGRESOSINDEMNIZACIONESToolStripMenuItem.Text
        txtCodigo.Text = "500"
        ObtenerListaTablaId(txtCodigo.Text)
    End Sub

    Private Sub DESCUENTOSALTRABAJADORToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DESCUENTOSALTRABAJADORToolStripMenuItem.Click
        txtDescripcion.Text = DESCUENTOSALTRABAJADORToolStripMenuItem.Text
        txtCodigo.Text = "700"
        ObtenerListaTablaId(txtCodigo.Text)
    End Sub

    Private Sub CONCEPTOSVARIOSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CONCEPTOSVARIOSToolStripMenuItem.Click
        txtDescripcion.Text = CONCEPTOSVARIOSToolStripMenuItem.Text
        txtCodigo.Text = "900"
        ObtenerListaTablaId(txtCodigo.Text)
    End Sub

    Private Sub OTROSCONCEPTOSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OTROSCONCEPTOSToolStripMenuItem.Click
        txtDescripcion.Text = OTROSCONCEPTOSToolStripMenuItem.Text
        txtCodigo.Text = "1000"
        ObtenerListaTablaId(txtCodigo.Text)
    End Sub

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click
        If (txtDescripcion.Text <> "") Then
            With FrmDetalleIngresoMantenimiento
                .txtTablaMaestra.Text = txtDescripcion.Text
                '.limpiarCajas()
                .actyon = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            If (txtDescripcion.Text = "") Then
                lblEstado.Text = "Debe seleccionar una tabla"
                lblEstado.Image = My.Resources.cross
            End If
        End If
    End Sub

    Private Sub AbrirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles AbrirToolStripButton.Click
        If dgvIngresoSunat.Rows.Count > 0 Then
            With FrmDetalleIngresoMantenimiento 
                .actyon = ENTITY_ACTIONS.UPDATE
                .txtTablaMaestra.Text = txtDescripcion.Text
                .txtCodigo.Text = dgvIngresoSunat.SelectedRows(0).Cells(1).Value
                .txtDescripcion.Text = dgvIngresoSunat.SelectedRows(0).Cells(3).Value
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else

            lblEstado.Text = "Debe seleccionar una tabla"
            lblEstado.Image = My.Resources.cross

        End If
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        If dgvIngresoSunat.Rows.Count > 0 Then
            eliminarIngresoSunat()
        Else
            lblEstado.Text = "Debe seleccionar una fila"
            lblEstado.Image = My.Resources.cross
        End If
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDescripcion.TextChanged

    End Sub

    Private Sub dgvIngresoSunat_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIngresoSunat.CellContentClick

    End Sub

    Private Sub dgvIngresoSunat_CellMouseDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvIngresoSunat.CellMouseDoubleClick
        If dgvIngresoSunat.Rows.Count > 0 Then
            If Tag = "1" Then

                FrmMasterPlanilla.dgvIngresos.Rows.Add(dgvIngresoSunat.SelectedRows(0).Cells(4).Value(), dgvIngresoSunat.SelectedRows(0).Cells(1).Value(), "", dgvIngresoSunat.SelectedRows(0).Cells(3).Value(), "0", "0", "0", "0", "0", "0")

            End If
        End If
    End Sub
End Class