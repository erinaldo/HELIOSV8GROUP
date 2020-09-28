Imports Helios.General
Public Class FormMantenimientoGeneralEspecial

    Private TabTablasGenerales As TabMG_TablasGenerales
    Private TabMG_ProductosEspecial As TabMG_ProductosEspecial

    Private Sub ToolStripDropDownButton4_Click_1(sender As Object, e As EventArgs)
        If TabTablasGenerales Is Nothing Then
            Dim f As New frmNuevoitemTabladetalle
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Else
            Dim f As New frmNuevoitemTabladetalle(Integer.Parse(TabTablasGenerales.cboTablas.SelectedValue.ToString))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If


    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        PanelBody.Controls.Clear()
        TabTablasGenerales = New TabMG_TablasGenerales With {
            .Dock = DockStyle.Fill
        }
        TabTablasGenerales.BringToFront()
        PanelBody.Controls.Add(TabTablasGenerales)
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        PanelBody.Controls.Clear()
        TabMG_ProductosEspecial = New TabMG_ProductosEspecial With {
            .Dock = DockStyle.Fill
        }
        TabMG_ProductosEspecial.BringToFront()
        PanelBody.Controls.Add(TabMG_ProductosEspecial)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        With frmNuevaExistenciaEspecial
            If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                .cboTipoExistencia.Enabled = False
                .cboUnidades.SelectedIndex = -1
                .cboUnidades.Enabled = True
            Else

            End If

            If Gempresas.Regimen = "1" Then
                .cboIgv.Text = "1 - GRAVADO"
                .cboIgv.Enabled = True
            Else
                .cboIgv.Text = "2 - EXONERADO"
                .cboIgv.Enabled = True
            End If
            .chClasificacion.Checked = False
            .cboTipoExistencia.SelectedValue = "01"
            .cboUnidades.Text = "UNIDAD (BIENES)"
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With

        Me.Cursor = Cursors.Arrow
    End Sub
End Class