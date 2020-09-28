Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class FormMantenimientoGeneral

    Private TabTablasGenerales As TabMG_TablasGenerales
    Private TabMG_Productos As TabMG_Productos
    Private TabMG_Servicios As TabMG_Servicios

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ToolStripTabItem1.Visible = False
        ToolStripTabItem2.Visible = True
        ToolStripTabItem3.Visible = False
    End Sub

    Private Sub ToolStripDropDownButton4_Click_1(sender As Object, e As EventArgs) Handles ToolStripDropDownButton4.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVO_CATALOGO_Formulario___, AutorizacionRolList) Then
            If TabTablasGenerales Is Nothing Then
                Dim f As New frmNuevoitemTabladetalle
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            Else
                Dim f As New frmNuevoitemTabladetalle(Integer.Parse(TabTablasGenerales.cboTablas.SelectedValue.ToString))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.LISTA_CATALOGO_Formulario___, AutorizacionRolList) Then
            PanelBody.Controls.Clear()
            TabTablasGenerales = New TabMG_TablasGenerales With {
            .Dock = DockStyle.Fill
        }
            TabTablasGenerales.BringToFront()
            PanelBody.Controls.Add(TabTablasGenerales)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.LISTA_PRODUCTO_Formulario___, AutorizacionRolList) Then
            PanelBody.Controls.Clear()
            TabMG_Productos = New TabMG_Productos With {
                .Dock = DockStyle.Fill
            }
            TabMG_Productos.BringToFront()
            PanelBody.Controls.Add(TabMG_Productos)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVO_PRODUCTO_Formulario___, AutorizacionRolList) Then
            Dim frmNuevaExistencia As New frmNuevaExistencia
            With frmNuevaExistencia
                If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                    .UCNuenExistencia.cboTipoExistencia.Enabled = False
                    .UCNuenExistencia.cboUnidades.SelectedIndex = -1
                    .UCNuenExistencia.cboUnidades.Enabled = True
                Else

                End If

                If Gempresas.Regimen = "1" Then
                    .UCNuenExistencia.cboIgv.Text = "1 - GRAVADO"
                    .UCNuenExistencia.cboIgv.Enabled = True
                Else
                    .UCNuenExistencia.cboIgv.Text = "2 - EXONERADO"
                    .UCNuenExistencia.cboIgv.Enabled = True
                End If
                'UCNuenExistencia.chClasificacion.Checked = False
                .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
                .UCNuenExistencia.cboUnidades.Text = "UNIDAD (BIENES)"
                .EstadoManipulacion = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btNuevoServicio_Click(sender As Object, e As EventArgs) Handles btNuevoServicio.Click
        Dim f As New frmServicioPrecios()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub btListaServicio_Click(sender As Object, e As EventArgs) Handles btListaServicio.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.LISTA_PRODUCTO_Formulario___, AutorizacionRolList) Then
            PanelBody.Controls.Clear()
            TabMG_Servicios = New TabMG_Servicios With {
                .Dock = DockStyle.Fill
            }
            TabMG_Servicios.BringToFront()
            PanelBody.Controls.Add(TabMG_Servicios)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class