Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class FormCajaMaestro

    Private TabCuentasFinancieras As TabFN_CuentasFinancieras
    Private TabPagos As TabFN_CuentasPagar
    Private TabCobros As TabFN_CuentasCobrar
    Private TabMovimientos As TabFN_MovimientoCuentas
    Private TabUsuariosCaja As TabFN_UsuariosCaja
    Private TabFN_StatusCajeros As TabFN_StatusCajeros
    Private TabFN_OtrosIngresos As TabFN_OtrosIngresos
    Private TabFN_OtrosEgresos As TabFN_OtrosEgresos
    Private TabFN_Transferencia As TabFN_Transferencia

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.CUENTAS_FINANCIERAS_Formulario___, AutorizacionRolList) Then
            'With frmModalCaja
            '    .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            '    .ObtenerMascaraMercaderia()
            '    .txtCuentaID.Text = "104"
            '    .StartPosition = FormStartPosition.CenterParent
            '    .ShowDialog()
            'End With
            Dim f As New frmModalCaja
            f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            f.ObtenerMascaraMercaderia()
            f.txtCuentaID.Text = "104"
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Me.Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ABRIR_CAJA_Formulario___, AutorizacionRolList) Then
            Dim f As New FormCrearCajero
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            'Dim f As New frmModalAbrirCajaUsuario ' frmCreaUsuarioEmpresa
            ''    f.cboMesCompra.SelectedValue = String.Format("0:00", DateTime.Now.Month)
            'f.cboMesCompra.Enabled = True
            'f.txtDia.Value = DateTime.Now
            'f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            'f.txtPeriodo.Value = DateTime.Now
            'f.StartPosition = FormStartPosition.CenterParent
            'f.ShowDialog()
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ADMINISTRAR_CUENTAS_FINANCIERAS_Formulario___, AutorizacionRolList) Then
            PanelBody.Controls.Clear()
            TabCuentasFinancieras = New TabFN_CuentasFinancieras() With {
                .Dock = DockStyle.Fill
            }
            TabCuentasFinancieras.BringToFront()
            PanelBody.Controls.Add(TabCuentasFinancieras)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.MOVIMIENTOS_Formulario___, AutorizacionRolList) Then
            PanelBody.Controls.Clear()
            TabMovimientos = New TabFN_MovimientoCuentas() With {
                .Dock = DockStyle.Fill
            }
            TabMovimientos.BringToFront()
            PanelBody.Controls.Add(TabMovimientos)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnEditCompra_Click(sender As Object, e As EventArgs) Handles btnCuentasXPagar.Click
        'PanelBody.Controls.Clear()
        'TabPagos = New TabFN_CuentasPagar() With {
        '    .Dock = DockStyle.Fill
        '}
        'TabPagos.BringToFront()
        'PanelBody.Controls.Add(TabPagos)

        Dim f As New FormCuentasPagarAnalisis
        f.StartPosition = FormStartPosition.CenterParent
        f.Show()
    End Sub

    Private Sub btnEliminarCompra_Click(sender As Object, e As EventArgs) Handles btnCuentasXCobrar.Click

        Dim f As New FormCuentasCobrarAnalisis
        f.StartPosition = FormStartPosition.CenterParent
        f.Show()
        'PanelBody.Controls.Clear()
        'TabCobros = New TabFN_CuentasCobrar() With {
        '    .Dock = DockStyle.Fill
        '}
        'TabCobros.BringToFront()
        'PanelBody.Controls.Add(TabCobros)
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        PanelBody.Controls.Clear()
        TabUsuariosCaja = New TabFN_UsuariosCaja() With {
            .Dock = DockStyle.Fill
        }
        TabUsuariosCaja.BringToFront()
        PanelBody.Controls.Add(TabUsuariosCaja)
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.HISTORIAL_DE_CAJA_Formulario___, AutorizacionRolList) Then
            PanelBody.Controls.Clear()
            TabFN_StatusCajeros = New TabFN_StatusCajeros With {
                .Dock = DockStyle.Fill
            }
            TabFN_StatusCajeros.BringToFront()
            PanelBody.Controls.Add(TabFN_StatusCajeros)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles btOtrosIngresos.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.OTROS_INGRESOS_Formulario___, AutorizacionRolList) Then
            PanelBody.Controls.Clear()
            TabFN_OtrosIngresos = New TabFN_OtrosIngresos With {
                .Dock = DockStyle.Fill
            }
            TabFN_OtrosIngresos.BringToFront()
            PanelBody.Controls.Add(TabFN_OtrosIngresos)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs) Handles btOtrosEgresos.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.OTROS_GASTOS_Formulario___, AutorizacionRolList) Then
            PanelBody.Controls.Clear()
            TabFN_OtrosEgresos = New TabFN_OtrosEgresos With {
                .Dock = DockStyle.Fill
            }
            TabFN_OtrosEgresos.BringToFront()
            PanelBody.Controls.Add(TabFN_OtrosEgresos)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton14_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        PanelBody.Controls.Clear()
        TabFN_Transferencia = New TabFN_Transferencia With {
            .Dock = DockStyle.Fill
        }
        TabFN_Transferencia.BringToFront()
        PanelBody.Controls.Add(TabFN_Transferencia)
    End Sub

    Private Sub FormCajaMaestro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   ToolStripEx8.Visible = False
        ToolStripPanelItem1.Visible = True  'cuentas x cobrar y pagar
        ToolStripButton16.Visible = True
        ToolStripButton14.Visible = True
        'btnCuentasXPagar.Visible = false
    End Sub

    Private Sub ToolStripButton16_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton16.Click
        Dim f As New FormMaestroModuloAnticipos
        f.StartPosition = FormStartPosition.CenterParent
        f.Show()
    End Sub

    Private Sub btnHistorialPago_Click(sender As Object, e As EventArgs) Handles btnHistorialPago.Click
        Dim f As New frmBancarioConfirmar
        f.StartPosition = FormStartPosition.CenterParent
        f.Show()
    End Sub

    Private Sub ToolStripPanelItem1_Click(sender As Object, e As EventArgs) Handles ToolStripPanelItem1.Click

    End Sub

    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs) Handles ToolStripButton17.Click


        Dim f As New frmReclamaciones
        f.StartPosition = FormStartPosition.CenterParent
        f.Show()
    End Sub
End Class