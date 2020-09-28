Imports Helios.General.Constantes
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms

Public Class TabLG_LogEntradaMenu
    Dim formLogistica As FormMaestroLogistica

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label11_MouseUp(sender As Object, e As MouseEventArgs) Handles Label11.MouseUp
        If e.Button = MouseButtons.Left Then
            ContextCompra.Show(Label11, New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub NuevaCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaCompraToolStripMenuItem.Click
        Try
            'Dim fechaAnt = DateTime.Now
            'fechaAnt = fechaAnt.AddMonths(-1)
            'Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            'If periodoAnteriorEstaCerrado = False Then
            '    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            '    Cursor = Cursors.Default
            '    Exit Sub
            'End If

            'Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = DateTime.Now.Year, .mes = DateTime.Now.Month})
            'If Not IsNothing(valida) Then
            '    If valida = True Then
            '        MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        Cursor = Cursors.Default
            '        Exit Sub
            '    End If
            'End If
            Me.Cursor = Cursors.WaitCursor

            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVA_COMPRA_Formulario___, AutorizacionRolList) Then
                Dim f As New FormCompras
                f.ComboBoxAdv2.Visible = False
                f.CaptionLabels(0).Text = "Compra al crédito"
                f.lblPerido.Text = String.Format("{0:00}", DateTime.Now.Month) & "/" & DateTime.Now.Year
                f.cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
                f.cboMesCompra.Enabled = True
                '   f.txtDia.Value = DateTime.Now
                f.StartPosition = FormStartPosition.CenterScreen
                f.WindowState = FormWindowState.Normal
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.Show(Me)

            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click
        Dim f As New FormMantenimientoComprasRapidas
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.PANEL_LOGISTICA__, AutorizacionRolList) Then
            Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormMaestroLogistica").SingleOrDefault
            If frm Is Nothing Then
                formLogistica = New FormMaestroLogistica
                formLogistica.StartPosition = FormStartPosition.CenterScreen
                formLogistica.Show(Me)
            Else
                formLogistica.WindowState = FormWindowState.Normal
                formLogistica.BringToFront()
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class
