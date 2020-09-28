Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Grouping

Public Class FormMaestroComercial

#Region "Fields"
    Private cierreSA As New empresaCierreMensualSA
    Private TabRegistroVenta As TabCM_RegistroVentas
    Private TabClientes As TabCM_Clientes
    Private TabCM_Pedidos As TabCM_Pedidos
    Private TabCM_RegistroNotaVentas As TabCM_RegistroNotaVentas
    Private TabCM_Proformas As TabCM_Proformas
    Private FormVentaNota As FormVentaNota
    Private TabCM_Ofertas As TabCM_Ofertas
    Private TabCM_EnviarComprobante As TabCM_EnviarComprobante
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GetCombos()
        '   GetConteoVenta()
        ' Ultimas24()
        ToolStripButton9.Enabled = True
    End Sub
#End Region

#Region "Methdos"
    Sub Ultimas24()
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim conteos = ventaSA.GetVentasPorFechaConteo(
                    New documentoventaAbarrotes With
                    {
                    .idEstablecimiento = GEstableciento.IdEstablecimiento,
                    .fechaDoc = DateTime.Now
                    }, "24 horas")

        ToolVentas.Text = conteos(0) & " - Ventas"
        ToolNotas.Text = conteos(1) & " - Notas"
        'ToolStripButton45.Text = "48 horas"
        ToolTotal.Text = CInt(conteos(0)) + CInt(conteos(1))
    End Sub

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
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Try
            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.VENTA_GENERAl_Formulario___, AutorizacionRolList) Then
                Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
                fechaAnt = fechaAnt.AddMonths(-1)
                Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
                If periodoAnteriorEstaCerrado = False Then
                    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                    Cursor = Cursors.Default
                    Exit Sub
                End If

                Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
                If Not IsNothing(valida) Then
                    If valida = True Then
                        MessageBox.Show("No puede realizar está operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
                If cboMesPedido.Text.Trim.Length > 0 Then
                    Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                    If Not IsNothing(cajaUsuario) Then
                        GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

                        Dim f As New FormVentaGeneral ' frmVentaNuevoFormato
                        Select Case tmpConfigInicio.FormatoVenta
                            Case "MKT"
                                f.RBProforma.Checked = True
                            Case Else
                                f.inicioComprobante = "PROFORMA"
                        End Select
                        f.lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                        f.StartPosition = FormStartPosition.CenterScreen
                        ' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        f.Show(Me)
                    Else
                        MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboMesPedido.Select()
                    cboMesPedido.DroppedDown = True
                End If
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default

        'Try
        '    If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.COTIZACION_PROFORMA_Formulario___, AutorizacionRolList) Then
        '        Dim f As New frmFormularioCotizacion
        '        f.lblPerido.Text = String.Format("{0:00}", DateTime.Now.Month) & "/" & cboAnio.Text
        '        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '        f.StartPosition = FormStartPosition.CenterParent
        '        f.ShowDialog()
        '    Else
        '        MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If


        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Try
            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.VENTA_POR_LOTES_Formulario___, AutorizacionRolList) Then
                Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
                fechaAnt = fechaAnt.AddMonths(-1)
                Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
                If periodoAnteriorEstaCerrado = False Then
                    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                    Cursor = Cursors.Default
                    Exit Sub
                End If

                Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
                If Not IsNothing(valida) Then
                    If valida = True Then
                        MessageBox.Show("No puede realizar está operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
                If cboMesPedido.Text.Trim.Length > 0 Then
                    Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                    If Not IsNothing(cajaUsuario) Then
                        GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

                        Dim f As New frmVentaNuevoFormato
                        f.lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                        f.StartPosition = FormStartPosition.CenterScreen
                        f.Show(Me)
                    Else
                        MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboMesPedido.Select()
                    cboMesPedido.DroppedDown = True
                End If
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripDropDownButton3_Click(sender As Object, e As EventArgs)
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ADMINISTRAR_VENTA_GENERAL, AutorizacionRolList) Then
        '    PanelRegistro.Visible = True
        '    PanelBody.Controls.Clear()
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.CLIENTES_Formulario___, AutorizacionRolList) Then
            PanelRegistro.Visible = False
            PanelBody.Controls.Clear()
            TabClientes = New TabCM_Clientes() With {
                .Dock = DockStyle.Fill
            }
            TabClientes.BringToFront()
            PanelBody.Controls.Add(TabClientes)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        Dim periodo = String.Format("{0:00}", cboMesPedido.SelectedValue)
        periodo = periodo & "/" & cboAnio.Text
        PanelBody.Controls.Clear()
        TabRegistroVenta = New TabCM_RegistroVentas(periodo, cboAnio.Text, String.Format("{0:00}", cboMesPedido.SelectedValue), cboTipoRegistro.Text) With {
            .Dock = DockStyle.Fill
        }
        TabRegistroVenta.BringToFront()
        PanelBody.Controls.Add(TabRegistroVenta)
    End Sub

    Private Sub btnEditCompra_Click(sender As Object, e As EventArgs) Handles btnEditCompra.Click, ToolStripButton27.Click
        If TabCM_Ofertas IsNot Nothing Then
            Dim r As Record = TabCM_Ofertas.GridOfertas.Table.CurrentRecord
            If r IsNot Nothing Then
                Dim f As New FormOfertaVentas(r.GetValue("id"))
                f.Manipulacion = ENTITY_ACTIONS.UPDATE
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
            Else
                MessageBox.Show("Debe indicar una oferta válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If

    End Sub

    Private Sub FormMaestroComercial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RibbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.Birds
        ToolStripEx1.Visible = False
        ToolStripEx3.Visible = True
        ToolStripTabVentaSinInventario.Visible = False
        ToolStripTabOfertas.Visible = False
        '  bVentaElec.Visible = False
        ToolStripTabVentas.Visible = True
        ToolStripEx19.Visible = True
        '  ToolStripPanelItem3.Visible = False
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.VER_NOTA_DE_VENTA_Formulario__, AutorizacionRolList) Then
        PanelRegistro.Visible = False
            PanelBody.Controls.Clear()
            TabCM_RegistroNotaVentas = New TabCM_RegistroNotaVentas() With {
                .Dock = DockStyle.Fill
            }
            TabCM_RegistroNotaVentas.BringToFront()
            PanelBody.Controls.Add(TabCM_RegistroNotaVentas)
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ADMINISTRAR_PROFORMA_Formulario___, AutorizacionRolList) Then
            PanelRegistro.Visible = False
            PanelBody.Controls.Clear()
            TabCM_Proformas = New TabCM_Proformas With {
                .Dock = DockStyle.Fill
            }
            TabCM_Proformas.BringToFront()
            PanelBody.Controls.Add(TabCM_Proformas)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realizar está operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If cboMesPedido.Text.Trim.Length > 0 Then
                Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

                    FormVentaNota = New FormVentaNota
                    FormVentaNota.lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                    FormVentaNota.StartPosition = FormStartPosition.CenterScreen
                    FormVentaNota.ShowDialog()
                Else
                    MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesPedido.Select()
                cboMesPedido.DroppedDown = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        Dim f As New FormVentaNueva
        f.ComboComprobante.Text = "PEDIDO DE VENTA"
        f.StartPosition = FormStartPosition.CenterParent
        f.Show(Me)
        'Dim cajaUsuarioSA As New cajaUsuarioSA
        'Try
        '    If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.VENTA_GENERAl_Formulario___, AutorizacionRolList) Then
        '        Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
        '        fechaAnt = fechaAnt.AddMonths(-1)
        '        Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        '        If periodoAnteriorEstaCerrado = False Then
        '            MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
        '            Cursor = Cursors.Default
        '            Exit Sub
        '        End If

        '        Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
        '        If Not IsNothing(valida) Then
        '            If valida = True Then
        '                MessageBox.Show("No puede realizar está operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                Exit Sub
        '            End If
        '        End If
        '        If cboMesPedido.Text.Trim.Length > 0 Then
        '            Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
        '            If Not IsNothing(cajaUsuario) Then
        '                GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

        '                Dim f As New FormVentaGeneral ' frmVentaNuevoFormato
        '                f.lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
        '                f.StartPosition = FormStartPosition.CenterScreen
        '                ' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '                f.Show(Me)
        '            Else
        '                MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            End If
        '        Else
        '            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            cboMesPedido.Select()
        '            cboMesPedido.DroppedDown = True
        '        End If
        '    Else
        '        MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If
        'Catch ex As Exception
        'MsgBox(ex.Message)
        'End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton23_Click(sender As Object, e As EventArgs)
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cierreSA As New empresaCierreMensualSA
        Try

            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.VENTA_ELECTRONICA_Formulario___, AutorizacionRolList) Then
                Dim fechaAnt = DateTime.Now
                fechaAnt = fechaAnt.AddMonths(-1)
                Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
                If periodoAnteriorEstaCerrado = False Then
                    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                    Cursor = Cursors.Default
                    Exit Sub
                End If

                Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = DateTime.Now.Year, .mes = DateTime.Now.Month})
                If Not IsNothing(valida) Then
                    If valida = True Then
                        MessageBox.Show("No puede realizar está operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If

                Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

                    Dim f As New FormVentaGeneralFE  ' frmVentaNuevoFormato
                    f.lblPerido.Text = String.Format("{0:00}", DateTime.Now.Month) & "/" & DateTime.Now.Year
                    f.StartPosition = FormStartPosition.CenterScreen
                    ' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.Show(Me)
                Else
                    MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton24_Click(sender As Object, e As EventArgs)
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cierreSA As New empresaCierreMensualSA
        Try
            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.VENTA_FORMATO_FISICO_Formulario___, AutorizacionRolList) Then
                Dim fechaAnt = DateTime.Now
                fechaAnt = fechaAnt.AddMonths(-1)
                Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
                If periodoAnteriorEstaCerrado = False Then
                    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                    Cursor = Cursors.Default
                    Exit Sub
                End If

                Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = DateTime.Now.Year, .mes = DateTime.Now.Month})
                If Not IsNothing(valida) Then
                    If valida = True Then
                        MessageBox.Show("No puede realizar está operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If

                Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

                    Dim f As New FormVentaGeneral ' frmVentaNuevoFormato
                    f.lblPerido.Text = String.Format("{0:00}", DateTime.Now.Month) & "/" & DateTime.Now.Year
                    f.StartPosition = FormStartPosition.CenterScreen
                    ' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.Show(Me)
                Else
                    MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub RibbonControlAdv1_SelectedTabItemChanged(sender As Object, e As Syncfusion.Windows.Forms.Tools.SelectedTabChangedEventArgs) Handles RibbonControlAdv1.SelectedTabItemChanged
        PanelRegistro.Visible = False
        PanelBody.Controls.Clear()
    End Sub

    Private Sub ToolStripButton25_Click(sender As Object, e As EventArgs)
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cierreSA As New empresaCierreMensualSA
        Try
            Dim fechaAnt = DateTime.Now
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = DateTime.Now.Year, .mes = DateTime.Now.Month})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realizar está operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If

            Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
            If Not IsNothing(cajaUsuario) Then
                GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

                Dim f As New FormVentaGeneralNV  ' frmVentaNuevoFormato
                f.lblPerido.Text = String.Format("{0:00}", DateTime.Now.Month) & "/" & DateTime.Now.Year
                f.StartPosition = FormStartPosition.CenterScreen
                ' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.Show(Me)
            Else
                MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton26_Click(sender As Object, e As EventArgs) Handles ToolStripButton26.Click
        Dim f As New FormOfertaVentas
        f.Manipulacion = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
    End Sub

    Private Sub ToolStripButton32_Click(sender As Object, e As EventArgs) Handles ToolStripButton32.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVO_PEDIDO_SI_Formulario___, AutorizacionRolList) Then
            Dim f As New FormVentaNuevoPosEspecial 'frmVentaNuevoPOS
            f.lblPerido.Text = String.Format("{0:00}", DateTime.Now.Month) & "/" & DateTime.Now.Year
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show(Me)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton36_Click(sender As Object, e As EventArgs) Handles ToolStripButton36.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cierreSA As New empresaCierreMensualSA
        Try
            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.VENTA_FORMATO_FISICO_SI_Formulario___, AutorizacionRolList) Then
                Dim fechaAnt = DateTime.Now
                fechaAnt = fechaAnt.AddMonths(-1)
                Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
                If periodoAnteriorEstaCerrado = False Then
                    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                    Cursor = Cursors.Default
                    Exit Sub
                End If

                Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = DateTime.Now.Year, .mes = DateTime.Now.Month})
                If Not IsNothing(valida) Then
                    If valida = True Then
                        MessageBox.Show("No puede realizar está operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If

                Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

                    Dim f As New FormVentaGeneralServ  ' frmVentaNuevoFormato
                    f.tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA
                    f.lblPerido.Text = String.Format("{0:00}", DateTime.Now.Month) & "/" & DateTime.Now.Year
                    f.StartPosition = FormStartPosition.CenterScreen
                    ' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.Show(Me)
                Else
                    MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton37_Click(sender As Object, e As EventArgs) Handles ToolStripButton37.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.VER_REGISTRO_DE_VENTAS_Formulario___, AutorizacionRolList) Then
            Dim periodo = String.Format("{0:00}", cboMesPedido.SelectedValue)
            periodo = periodo & "/" & cboAnio.Text
            PanelBody.Controls.Clear()
            TabRegistroVenta = New TabCM_RegistroVentas(periodo, cboAnio.Text, String.Format("{0:00}", cboMesPedido.SelectedValue), "TODOS") With {
            .Dock = DockStyle.Fill
        }
            TabRegistroVenta.BringToFront()
            PanelBody.Controls.Add(TabRegistroVenta)
            PanelRegistro.Visible = True
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripDropDownButton3_Click_1(sender As Object, e As EventArgs) Handles ToolStripDropDownButton3.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.VER_REGISTRO_DE_VENTA_Formulario___, AutorizacionRolList) Then
            Dim periodo = String.Format("{0:00}", cboMesPedido.SelectedValue)
            periodo = periodo & "/" & cboAnio.Text
            PanelBody.Controls.Clear()
            TabRegistroVenta = New TabCM_RegistroVentas(periodo, cboAnio.Text, String.Format("{0:00}", cboMesPedido.SelectedValue), "TODOS") With {
                .Dock = DockStyle.Fill
            }
            TabRegistroVenta.BringToFront()
            PanelBody.Controls.Add(TabRegistroVenta)
            PanelRegistro.Visible = True
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton34_Click(sender As Object, e As EventArgs) Handles ToolStripButton34.Click
        Try
            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVA_PROFORMAS_SI_Formulario___, AutorizacionRolList) Then
                Dim f As New frmFormularioCotizacion
                f.lblPerido.Text = String.Format("{0:00}", DateTime.Now.Month) & "/" & cboAnio.Text
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

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

    Private Sub ToolStripButton35_Click(sender As Object, e As EventArgs) Handles ToolStripButton35.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.GESTIONAR_PROFORMAS_SI_Formulario___, AutorizacionRolList) Then
            PanelRegistro.Visible = False
            PanelBody.Controls.Clear()
            TabCM_Proformas = New TabCM_Proformas With {
                .Dock = DockStyle.Fill
            }
            TabCM_Proformas.BringToFront()
            PanelBody.Controls.Add(TabCM_Proformas)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton38_Click(sender As Object, e As EventArgs) Handles ToolStripButton38.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.REGISTRO_DE_CLIENTES_Formulario___, AutorizacionRolList) Then
            PanelRegistro.Visible = False
            PanelBody.Controls.Clear()
            TabClientes = New TabCM_Clientes() With {
                .Dock = DockStyle.Fill
            }
            TabClientes.BringToFront()
            PanelBody.Controls.Add(TabClientes)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton40_Click(sender As Object, e As EventArgs) Handles ToolStripButton40.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVO_CLIENTES_Formulario___, AutorizacionRolList) Then
            With frmCrearENtidades
                .CaptionLabels(0).Text = "Nuevo cliente"
                .strTipo = TIPO_ENTIDAD.CLIENTE
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton39_Click(sender As Object, e As EventArgs) Handles ToolStripButton39.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NOTAS_DE_VENTA_Formulario___, AutorizacionRolList) Then
            PanelRegistro.Visible = False
            PanelBody.Controls.Clear()
            TabCM_RegistroNotaVentas = New TabCM_RegistroNotaVentas() With {
                .Dock = DockStyle.Fill
            }
            TabCM_RegistroNotaVentas.BringToFront()
            PanelBody.Controls.Add(TabCM_RegistroNotaVentas)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolRecientes_Click(sender As Object, e As EventArgs) Handles ToolRecientes.Click
        PanelBody.Controls.Clear()
        TabCM_Ofertas = New TabCM_Ofertas() With {
            .Dock = DockStyle.Fill
        }
        TabCM_Ofertas.BringToFront()
        PanelBody.Controls.Add(TabCM_Ofertas)
        PanelRegistro.Visible = False
    End Sub

    Private Sub ToolStripButton23_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton23.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cierreSA As New empresaCierreMensualSA
        Try
            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.VENTA_ELECTRONICAS_SI_Formulario___, AutorizacionRolList) Then
                Dim fechaAnt = DateTime.Now
                fechaAnt = fechaAnt.AddMonths(-1)
                Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
                If periodoAnteriorEstaCerrado = False Then
                    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                    Cursor = Cursors.Default
                    Exit Sub
                End If

                Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = DateTime.Now.Year, .mes = DateTime.Now.Month})
                If Not IsNothing(valida) Then
                    If valida = True Then
                        MessageBox.Show("No puede realizar está operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If

                Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

                    Dim f As New FormVentaGeneralSinInventario ' frmVentaNuevoFormato
                    'f.tipoVenta = TIPO_VENTA.VENTA_ELECTRONICA
                    f.lblPerido.Text = String.Format("{0:00}", DateTime.Now.Month) & "/" & DateTime.Now.Year
                    f.StartPosition = FormStartPosition.CenterScreen
                    ' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.Show(Me)
                Else
                    MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton24_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton24.Click
        Dim periodo = String.Format("{0:00}", cboMesPedido.SelectedValue)
        periodo = periodo & "/" & cboAnio.Text
        PanelBody.Controls.Clear()
        TabCM_EnviarComprobante = New TabCM_EnviarComprobante(periodo, cboAnio.Text, String.Format("{0:00}", cboMesPedido.SelectedValue)) With {
            .Dock = DockStyle.Fill
        }
        TabCM_EnviarComprobante.BringToFront()
        PanelBody.Controls.Add(TabCM_EnviarComprobante)
        'PanelRegistro.Visible = True
    End Sub

    Private Sub ToolStripButton44_Click(sender As Object, e As EventArgs) Handles ToolStripButton44.Click
        Dim periodo = String.Format("{0:00}", cboMesPedido.SelectedValue)
        periodo = periodo & "/" & cboAnio.Text
        PanelBody.Controls.Clear()
        TabCM_EnviarComprobante = New TabCM_EnviarComprobante(periodo, cboAnio.Text, String.Format("{0:00}", cboMesPedido.SelectedValue)) With {
            .Dock = DockStyle.Fill
        }
        TabCM_EnviarComprobante.BringToFront()
        PanelBody.Controls.Add(TabCM_EnviarComprobante)
        PanelRegistro.Visible = True
    End Sub

    Private Sub ToolStripButton45_Click(sender As Object, e As EventArgs) Handles ToolStripButton45.Click
        Cursor = Cursors.WaitCursor
        Dim ventaSA As New documentoVentaAbarrotesSA
        Try

            'Dim conteos = ventaSA.GetVentasPorFechaConteo(
            '    New documentoventaAbarrotes With
            '    {
            '    .idEstablecimiento = GEstableciento.IdEstablecimiento,
            '    .fechaDoc = DateTime.Now
            '    }, "24 horas")

            GetConteoVenta()
            'Select Case ToolStripButton45.Text
            '    Case "24 horas"
            '        PanelBody.Controls.Clear()
            '        TabRegistroVenta = New TabCM_RegistroVentas(New documentoventaAbarrotes With
            '                                  {
            '                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
            '                                  .fechaDoc = DateTime.Now
            '                                  }, "24 horas") With {
            '            .Dock = DockStyle.Fill
            '        }
            '        TabRegistroVenta.BringToFront()
            '        PanelBody.Controls.Add(TabRegistroVenta)

            '        ToolStripButton45.Text = "48 horas"
            '    Case "48 horas"
            '        PanelBody.Controls.Clear()
            '        TabRegistroVenta = New TabCM_RegistroVentas(New documentoventaAbarrotes With
            '                                  {
            '                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
            '                                  .fechaDoc = DateTime.Now
            '                                  }, "48 horas") With {
            '            .Dock = DockStyle.Fill
            '        }
            '        TabRegistroVenta.BringToFront()
            '        PanelBody.Controls.Add(TabRegistroVenta)
            '        ToolStripButton45.Text = "72 horas"
            '    Case "72 horas"
            '        PanelBody.Controls.Clear()
            '        TabRegistroVenta = New TabCM_RegistroVentas(New documentoventaAbarrotes With
            '                                  {
            '                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
            '                                  .fechaDoc = DateTime.Now
            '                                  }, "72 horas") With {
            '            .Dock = DockStyle.Fill
            '        }
            '        TabRegistroVenta.BringToFront()
            '        PanelBody.Controls.Add(TabRegistroVenta)

            '        ToolStripButton45.Text = "24 horas"
            'End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Cursor = Cursors.Default
    End Sub

    Sub GetConteoVenta()
        Dim ventaSA As New documentoVentaAbarrotesSA
        Select Case ToolStripButton45.Text
            Case "24 horas"

                Dim conteos = ventaSA.GetVentasPorFechaConteo(
                    New documentoventaAbarrotes With
                    {
                    .idEstablecimiento = GEstableciento.IdEstablecimiento,
                    .fechaDoc = DateTime.Now
                    }, "24 horas")

                ToolVentas.Text = conteos(0) & " - Ventas"
                ToolNotas.Text = conteos(1) & " - Notas"
                ToolStripButton45.Text = "48 horas"
                ToolTotal.Text = CInt(conteos(0)) + CInt(conteos(1))
            Case "48 horas"

                Dim conteos = ventaSA.GetVentasPorFechaConteo(
                    New documentoventaAbarrotes With
                    {
                    .idEstablecimiento = GEstableciento.IdEstablecimiento,
                    .fechaDoc = DateTime.Now
                    }, "48 horas")

                ToolVentas.Text = conteos(0) & " - Ventas"
                ToolNotas.Text = conteos(1) & " - Notas"
                ToolStripButton45.Text = "72 horas"
                ToolTotal.Text = CInt(conteos(0)) + CInt(conteos(1))
            Case "72 horas"
                Dim conteos = ventaSA.GetVentasPorFechaConteo(
                    New documentoventaAbarrotes With
                    {
                    .idEstablecimiento = GEstableciento.IdEstablecimiento,
                    .fechaDoc = DateTime.Now
                    }, "72 horas")

                ToolVentas.Text = conteos(0) & " - Ventas"
                ToolNotas.Text = conteos(1) & " - Notas"
                ToolStripButton45.Text = "24 horas"
                ToolTotal.Text = CInt(conteos(0)) + CInt(conteos(1))
        End Select
    End Sub

    Private Sub ToolVentas_Click(sender As Object, e As EventArgs) Handles ToolVentas.Click
        Cursor = Cursors.WaitCursor
        Select Case ToolStripButton45.Text
            Case "24 horas"
                PanelBody.Controls.Clear()
                TabRegistroVenta = New TabCM_RegistroVentas(New documentoventaAbarrotes With
                                          {
                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                          .fechaDoc = DateTime.Now
                                          }, "24 horas") With {
                    .Dock = DockStyle.Fill
                }
                TabRegistroVenta.BringToFront()
                PanelBody.Controls.Add(TabRegistroVenta)

               ' ToolStripButton45.Text = "48 horas"
            Case "48 horas"
                PanelBody.Controls.Clear()
                TabRegistroVenta = New TabCM_RegistroVentas(New documentoventaAbarrotes With
                                          {
                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                          .fechaDoc = DateTime.Now
                                          }, "48 horas") With {
                    .Dock = DockStyle.Fill
                }
                TabRegistroVenta.BringToFront()
                PanelBody.Controls.Add(TabRegistroVenta)
             '   ToolStripButton45.Text = "72 horas"
            Case "72 horas"
                PanelBody.Controls.Clear()
                TabRegistroVenta = New TabCM_RegistroVentas(New documentoventaAbarrotes With
                                          {
                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                          .fechaDoc = DateTime.Now
                                          }, "72 horas") With {
                    .Dock = DockStyle.Fill
                }
                TabRegistroVenta.BringToFront()
                PanelBody.Controls.Add(TabRegistroVenta)

                '  ToolStripButton45.Text = "24 horas"
        End Select
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolNotas_Click(sender As Object, e As EventArgs) Handles ToolNotas.Click
        Cursor = Cursors.WaitCursor
        Select Case ToolStripButton45.Text
            Case "24 horas"
                PanelBody.Controls.Clear()
                TabCM_RegistroNotaVentas = New TabCM_RegistroNotaVentas(New documentoventaAbarrotes With
                                          {
                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                          .fechaDoc = DateTime.Now
                                          }, "24 horas") With {
                    .Dock = DockStyle.Fill
                }
                TabCM_RegistroNotaVentas.BringToFront()
                PanelBody.Controls.Add(TabCM_RegistroNotaVentas)

            '    ToolStripButton45.Text = "48 horas"
            Case "48 horas"
                PanelBody.Controls.Clear()
                TabCM_RegistroNotaVentas = New TabCM_RegistroNotaVentas(New documentoventaAbarrotes With
                                          {
                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                          .fechaDoc = DateTime.Now
                                          }, "48 horas") With {
                    .Dock = DockStyle.Fill
                }
                TabCM_RegistroNotaVentas.BringToFront()
                PanelBody.Controls.Add(TabCM_RegistroNotaVentas)
              '  ToolStripButton45.Text = "72 horas"
            Case "72 horas"
                PanelBody.Controls.Clear()
                TabCM_RegistroNotaVentas = New TabCM_RegistroNotaVentas(New documentoventaAbarrotes With
                                          {
                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                          .fechaDoc = DateTime.Now
                                          }, "72 horas") With {
                    .Dock = DockStyle.Fill
                }
                TabCM_RegistroNotaVentas.BringToFront()
                PanelBody.Controls.Add(TabCM_RegistroNotaVentas)

                '   ToolStripButton45.Text = "24 horas"
        End Select
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton25_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton25.Click
        Dim f As New FormRegistroVentaMensual
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub ToolStripButton46_Click(sender As Object, e As EventArgs) Handles ToolStripButton46.Click
        Dim f As New FormMaestroBeneficiosGeneral
        f.Show()
    End Sub

    Private Sub ToolStripButton49_Click(sender As Object, e As EventArgs) Handles ToolStripButton49.Click
        Dim f As New FormVentaNueva
        f.ComboComprobante.Text = "PROFORMA"
        f.StartPosition = FormStartPosition.CenterParent
        f.Show(Me)
    End Sub

    Private Sub ToolStripButton48_Click(sender As Object, e As EventArgs) Handles ToolStripButton48.Click
        'Dim cajaUsuario = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario).SingleOrDefault

        'If Not IsNothing(cajaUsuario) Then
        ''    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

        Dim f As New FormVentaNueva
            f.StartPosition = FormStartPosition.CenterParent
            f.Show(Me)
        'Else
        '    MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub
#End Region

End Class