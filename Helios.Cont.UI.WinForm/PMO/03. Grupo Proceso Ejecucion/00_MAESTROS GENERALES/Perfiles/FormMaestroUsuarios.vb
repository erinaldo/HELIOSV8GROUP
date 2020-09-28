Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class FormMaestroUsuarios

#Region "Fields"
    Private cierreSA As New empresaCierreMensualSA
    Private TabRegistroVenta As TabCM_RegistroVentas
    Private TabUsuario As TabUsuario
    Private TabUsuarios As TabUsuarios
    Private TabPerfiles As TabPerfiles
    Private TabPerfilesXUsuario As TabPerfilesXUsuario
    Private frmAutorizacionXperfil As frmAutorizacionXperfil
    Private TabCM_Proformas As TabCM_Proformas
    Private FormVentaNota As FormVentaNota
    Private TabPasswordXUsuario As TabPasswordXUsuario
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GetCombos()
    End Sub
#End Region

#Region "Methdos"
    Private Sub GetCombos()
        Dim empresaAnioSA As New empresaPeriodoSA
        cboMesPedido.DisplayMember = "Mes"
        cboMesPedido.ValueMember = "Codigo"
        cboMesPedido.DataSource = ListaDeMeses()
        cboMesPedido.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)

        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = DateTime.Now.Year
    End Sub
#End Region

#Region "Events"
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs)
        Try

            Dim f As New frmFormularioCotizacion
            f.lblPerido.Text = String.Format("{0:00}", DateTime.Now.Month) & "/" & cboAnio.Text
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            'Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
            'fechaAnt = fechaAnt.AddMonths(-1)
            'Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            'If periodoAnteriorEstaCerrado = False Then
            '    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            '    Cursor = Cursors.Default
            '    Exit Sub
            'End If

            'Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
            'If Not IsNothing(valida) Then
            '    If valida = True Then
            '        MessageBox.Show("No puede realizar está operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        Exit Sub
            '    End If
            'End If
            'If cboMesPedido.Text.Trim.Length > 0 Then
            '    Dim f As New frmVentaNuevoPOS
            '    f.lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
            '    f.StartPosition = FormStartPosition.CenterScreen
            '    f.ShowDialog()
            'Else
            '    MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    cboMesPedido.Select()
            '    cboMesPedido.DroppedDown = True
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVO_PERFIL_USUARIO_Formulario___, AutorizacionRolList) Then
            PanelBody.Controls.Clear()
            Dim f As New frmCrearPerfilesDelSistema
            f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVO_USUARIO_Formulario___, AutorizacionRolList) Then
            Dim f As New frmCrearUsuariosDelSistema
            f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            PanelBody.Controls.Clear()
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs)
        Dim periodo = String.Format("{0:00}", cboMesPedido.SelectedValue)
        periodo = periodo & "/" & cboAnio.Text
        PanelBody.Controls.Clear()
        TabRegistroVenta = New TabCM_RegistroVentas(periodo, cboAnio.Text, String.Format("{0:00}", cboMesPedido.SelectedValue), "TODOS") With {
            .Dock = DockStyle.Fill
        }
        TabRegistroVenta.BringToFront()
        PanelBody.Controls.Add(TabRegistroVenta)
    End Sub

    Private Sub btnEditCompra_Click(sender As Object, e As EventArgs)
        'PanelBody.Controls.Clear()
        'TabCM_Pedidos = New TabCM_Pedidos("PN") With {
        '    .Dock = DockStyle.Fill
        '}
        'TabCM_Pedidos.BringToFront()
        'PanelBody.Controls.Add(TabCM_Pedidos)
    End Sub

    Private Sub FormMaestroComercial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RibbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.Birds
        ToolStripEx3.Visible = True
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click

    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs)
        PanelBody.Controls.Clear()
        TabCM_Proformas = New TabCM_Proformas With {
            .Dock = DockStyle.Fill
        }
        TabCM_Proformas.BringToFront()
        PanelBody.Controls.Add(TabCM_Proformas)
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Try
            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.VER_RESUMEN_MODULOS_Formulario___, AutorizacionRolList) Then
                frmAutorizacionXperfil = New frmAutorizacionXperfil
                'frmAutorizacionXperfil.lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                frmAutorizacionXperfil.StartPosition = FormStartPosition.CenterScreen
                frmAutorizacionXperfil.ShowDialog()
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.VER_USUARIO_Formulario___, AutorizacionRolList) Then
            PanelBody.Controls.Clear()
            TabUsuarios = New TabUsuarios() With {
            .Dock = DockStyle.Fill
        }
            TabUsuarios.BringToFront()
            PanelBody.Controls.Add(TabUsuarios)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub ToolStripDropDownButton3_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton3.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.VER_PERFILES_Formulario___, AutorizacionRolList) Then
            PanelBody.Controls.Clear()
            TabPerfiles = New TabPerfiles() With {
            .Dock = DockStyle.Fill
        }
            TabPerfiles.BringToFront()
            PanelBody.Controls.Add(TabPerfiles)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.VER_PERFILES_X_USUARIO_Formulario___, AutorizacionRolList) Then
            PanelBody.Controls.Clear()
            TabPerfilesXUsuario = New TabPerfilesXUsuario() With {
            .Dock = DockStyle.Fill
        }
            TabPerfilesXUsuario.BringToFront()
            PanelBody.Controls.Add(TabPerfilesXUsuario)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton23_Click(sender As Object, e As EventArgs) Handles ToolStripButton23.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.USUARIO_PASSWORD_Formulario___, AutorizacionRolList) Then
            PanelBody.Controls.Clear()
            TabPasswordXUsuario = New TabPasswordXUsuario() With {
            .Dock = DockStyle.Fill
        }
            TabPasswordXUsuario.BringToFront()
            PanelBody.Controls.Add(TabPasswordXUsuario)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click

    End Sub
#End Region

End Class