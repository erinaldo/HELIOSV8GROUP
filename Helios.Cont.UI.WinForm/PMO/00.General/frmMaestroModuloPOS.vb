Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Tools
Imports System.IO
Imports System.Reflection
Imports Tulpep.NotificationWindow

Public Class frmMaestroModuloPOS

#Region "Attributes"
    Dim i As Integer = 0
    Public Property LightBox As New HeliosLogin
    Public empresaPeriodoSA As New empresaCierreMensualSA
    Protected compraSA As DocumentoCompraSA
    Public Property dt As New DataTable
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0

    Protected Friend ImportePorPagarAproveedores As Decimal = 0
    Protected Friend ImportePorCobrarAclientes As Decimal = 0
    Protected Friend conteoEnTransito As Integer = 0
    Protected Friend conteoStockMinimo As Integer = 0
    Protected Friend conteoArticulosSinPrecio As Decimal = 0
    Protected Friend conteoArticulosVencidos As Decimal = 0
    Protected Friend conteoTransArticulosPendientes As Decimal = 0
    Protected Friend conteoTransArticulosConfirmados As Decimal = 0
    Protected Friend totalSA As New TotalesAlmacenSA
    Protected Friend frmNuevaMembresia As frmMaestroMembresia
    Protected Friend frmRegistroClienteMembresia As frmRegistroClienteMembresia
    Protected Friend frmListadoProveedoresXpagar As frmListadoProveedoresXpagar
    Protected Friend frmListadoClientesXpagar As frmListadoClientesXpagar
    Public Delegate Sub _delegadoProveedores()
    Public Delegate Sub _delegadoClientes()
    Public Delegate Sub _delegadoSeleccionDGVLogistica(r As Record)
    Protected ListaMeses As List(Of MesesAnio)
    Private Property configuracionInicioSA As New ConfiguracionInicioSA
    Private Property AsegurableSA As New Helios.Seguridad.WCFService.ServiceAccess.AsegurableSA
    '  Public notify As PopupNotifier
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        PanelPagos.Visible = False
        splashControl1.SplashControlPanel.BorderType = SplashBorderType.None
        splashControl1.ShowDialogSplash(Me)
        splashControl1.AutoMode = False
        splashControl1.HostForm = Me
        ' Add any initialization after the InitializeComponent() call.
        '   LoadDockingPanel()
        FormatoGrid(dgvLogistica)
        FormatoGrid(dgvComercial)
        FormatoGrid(dgvFinanzas)

    End Sub

#End Region

#Region "Methods"

    Private Sub MostrarCuentasXpagar()
        If HubPagos.InvokeRequired Then
            Dim deleg As New _delegadoProveedores(AddressOf MostrarCuentasXpagar)
            Invoke(deleg, New Object() {})
        Else
            GetProveedoresXPagar(AnioGeneral, Gempresas.IdEmpresaRuc)
            HubPagos.Body.Text = ImportePorPagarAproveedores.ToString("N2")
        End If
    End Sub

    Private Sub MostrarCuentasXcobrar()
        If HubPagos.InvokeRequired Then
            Dim deleg As New _delegadoClientes(AddressOf MostrarCuentasXcobrar)
            Invoke(deleg, New Object() {})
        Else
            GetClientesXCobrar(AnioGeneral, Gempresas.IdEmpresaRuc)
            HubCobros.Body.Text = ImportePorCobrarAclientes.ToString("N2")
        End If
    End Sub

    Private Sub SelectDGLogistica(r As Record)
        Dim frm As New frmMaster
        If Me.InvokeRequired Then
            Dim deleg As New _delegadoSeleccionDGVLogistica(AddressOf SelectDGLogistica)
            Invoke(deleg, New Object() {r})
        Else
            Dim detalleModulo = r.GetValue("detalle")
            Dim ObtenerFRM = AutorizacionRolList.Where(Function(o) o.Nomasegurable = detalleModulo).FirstOrDefault
            If ObtenerFRM IsNot Nothing Then
                Dim formName As String = ObtenerFRM.Formulario
                formName = [Assembly].GetEntryAssembly.GetName.Name & "." & formName
                frm = DirectCast([Assembly].GetEntryAssembly.CreateInstance(formName), frmMaster)
                frm.StartPosition = FormStartPosition.CenterParent
                frm.ShowDialog()
            Else
                MessageBox.Show("Usuario no autorizado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            PictureBox2.Visible = False
            'Select Case r.GetValue("detalle")
            '    Case "Compras"
            '        Dim f As New frmComprasMaestro()
            '        f.ComprasAlContadoToolStripMenuItem.Visible = False
            '        f.StartPosition = FormStartPosition.CenterParent
            '        PictureBox2.Visible = False
            '        f.ShowDialog()

            '    Case "Proveedores"
            '        Dim f As New frmProveedoresMaestro
            '        f.StartPosition = FormStartPosition.CenterParent
            '        PictureBox2.Visible = False
            '        f.ShowDialog()

            '    Case "Otros ingresos a almacén"
            '        Cursor = Cursors.WaitCursor
            '        Try
            '            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
            '            If Not IsNothing(valida) Then
            '                If valida = True Then
            '                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '                    Exit Sub
            '                End If
            '            End If
            '            '       If AutorizacionRolSA.TienePermiso(AsegurablesSistema.MOVIMIENTO_INVENTARIO_OTRAS_ENTRADAS_Otros_Formulario__, AutorizacionRolList) Then
            '            With frmMovOtrasEntradas
            '                .lblPerido.Text = PeriodoGeneral
            '                .cboOperacion.SelectedValue = "0000"
            '                .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
            '                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '                .StartPosition = FormStartPosition.CenterParent
            '                PictureBox2.Visible = False
            '                .ShowDialog()
            '            End With
            '            ''
            '        Catch ex As Exception
            '            MessageBox.Show(ex.Message)
            '        End Try
            '        Cursor = Cursors.Default

            '    Case "Otros salidas de almacén"
            '        Cursor = Cursors.WaitCursor
            '        Try
            '            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
            '            If Not IsNothing(valida) Then
            '                If valida = True Then
            '                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '                    Exit Sub
            '                End If
            '            End If
            '            'If AutorizacionRolSA.TienePermiso(AsegurablesSistema.MOVIMIENTO_INVENTARIO_OTRAS_SALIDAS_Otros_Formulario__, AutorizacionRolList) Then
            '            With frmOtrasSalidasDeAlmacen
            '                .lblPerido.Text = PeriodoGeneral
            '                .cboOperacion.SelectedValue = "0001"
            '                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '                .StartPosition = FormStartPosition.CenterParent
            '                PictureBox2.Visible = False
            '                .ShowDialog()
            '            End With
            '            'Else
            '            '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '            'End If
            '        Catch ex As Exception
            '            MessageBox.Show(ex.Message)
            '        End Try
            '        Cursor = Cursors.Default

            '    Case "Recep. de inventario en tránsito por compras"
            '        Dim f As New frmExistenciasEnTransito()
            '        f.StartPosition = FormStartPosition.CenterParent
            '        PictureBox2.Visible = False
            '        f.ShowDialog()

            '    Case "Recep. de inventario en tránsito por transferencia"
            '        Dim f As New frmEntregaArticulosXconfirmar()
            '        f.StartPosition = FormStartPosition.CenterParent
            '        PictureBox2.Visible = False
            '        f.ShowDialog()

            '    Case "transferencias a otros almacenes"
            '        Dim f As New frmMovimientoTransferencia()
            '        f.StartPosition = FormStartPosition.CenterParent
            '        PictureBox2.Visible = False
            '        f.ShowDialog()

            '    Case "Kardex"
            '        Dim f As New frmModeloKardex()
            '        f.StartPosition = FormStartPosition.CenterParent
            '        PictureBox2.Visible = False
            '        f.ShowDialog()

            '    Case "Inventario Valorizado"
            '        Dim f As New frmInventarioValorizado()
            '        f.StartPosition = FormStartPosition.CenterParent
            '        PictureBox2.Visible = False
            '        f.ShowDialog()

            '    Case "Lista de precios - inventario"
            '        Dim f As New frmExistenciaPrecios()
            '        f.StartPosition = FormStartPosition.CenterParent
            '        PictureBox2.Visible = False
            '        f.ShowDialog()

            '    Case "Lista de precios - servicios"
            '        Dim f As New frmServiciosPrecios()
            '        f.StartPosition = FormStartPosition.CenterParent
            '        PictureBox2.Visible = False
            '        f.ShowDialog()

            '    Case "Movimientos de almacén (entradas, sálidas)"
            '        Dim f As New frmMovimientosInventario
            '        f.StartPosition = FormStartPosition.CenterParent
            '        PictureBox2.Visible = False
            '        f.ShowDialog()
            'End Select
        End If

    End Sub

    Private Sub SelectDGComercial(r As Record)
        Dim frm As New frmMaster
        If Me.InvokeRequired Then
            Dim deleg As New _delegadoSeleccionDGVLogistica(AddressOf SelectDGComercial)
            Invoke(deleg, New Object() {r})
        Else
            Dim detalleModulo = r.GetValue("detalle")
            Dim ObtenerFRM = AutorizacionRolList.Where(Function(o) o.Nomasegurable = detalleModulo).FirstOrDefault
            If ObtenerFRM IsNot Nothing Then
                Dim formName As String = ObtenerFRM.Formulario
                formName = [Assembly].GetEntryAssembly.GetName.Name & "." & formName
                frm = DirectCast([Assembly].GetEntryAssembly.CreateInstance(formName), frmMaster)
                frm.StartPosition = FormStartPosition.CenterParent
                frm.ShowDialog()
            Else
                MessageBox.Show("Usuario no autorizado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            LoadingComercial.Visible = False


            '    Select Case r.GetValue("detalle")

            '        Case "Clientes"
            '            Dim f As New frmClientesMaestro
            '            f.StartPosition = FormStartPosition.CenterParent
            '            f.ShowDialog()

            '        Case "Pre venta"
            '            Try
            '                Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
            '                If Not IsNothing(valida) Then
            '                    If valida = True Then
            '                        MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '                        Exit Sub
            '                    End If
            '                End If

            '                If AutorizacionRolSA.TienePermiso(AsegurablesSistema.PRE_VENTA_Formulario__, AutorizacionRolList) Then
            '                    Dim f As New frmVentaPV
            '                    f.lblPerido.Text = MesGeneral & "/" & AnioGeneral
            '                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '                    f.WindowState = FormWindowState.Maximized
            '                    f.StartPosition = FormStartPosition.CenterParent
            '                    f.ShowDialog()
            '                Else
            '                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '                End If
            '            Catch ex As Exception
            '                MessageBox.Show(ex.Message)
            '            End Try

            '        Case "Cotizaciones - proformas"
            '            If AutorizacionRolSA.TienePermiso(AsegurablesSistema.REGISTRO_DE_COTIZACIONES__, AutorizacionRolList) Then
            '                Dim f As New frmcotizacionMaestro
            '                '  f.ToolStripDropDownButton4.Visible = False
            '                f.StartPosition = FormStartPosition.CenterParent
            '                f.ShowDialog()
            '            Else
            '                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '            End If

            '        Case "Caja centralizada"
            '            If AutorizacionRolSA.TienePermiso(AsegurablesSistema.REGISTRO_PEDIDOS__, AutorizacionRolList) Then
            '                Dim f As New frmPedidoPendiente
            '                f.StartPosition = FormStartPosition.CenterParent
            '                f.ShowDialog()
            '            Else
            '                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '            End If

            '        Case "Venta POS: Contado ET."
            '            Try
            '                Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
            '                If Not IsNothing(valida) Then
            '                    If valida = True Then
            '                        MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '                        Exit Sub
            '                    End If
            '                End If


            '                'If AutorizacionRolSA.TienePermiso(AsegurablesSistema.CAJA_CENTRALIZADA_Formulario__, AutorizacionRolList) Then
            '                Dim ef As New EstadosFinancierosSA
            '                Dim cajaUsuario As New cajaUsuario
            '                Dim cajaUsuarioSA As New cajaUsuarioSA
            '                Dim usuarioSA As New UsuarioSA
            '                Dim usuarioxls As New Usuario
            '                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
            '                If Not IsNothing(cajaUsuario) Then
            '                    With frmVentaPVdirecta
            '                        .lblPerido.Text = MesGeneral & "/" & AnioGeneral
            '                        '.btGrabar.Enabled = True
            '                        .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_TOTAL)
            '                        .StartPosition = FormStartPosition.CenterParent
            '                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '                        .ShowDialog()
            '                    End With
            '                Else
            '                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '                End If
            '                'Else
            '                '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '                'End If
            '            Catch ex As Exception
            '                MessageBox.Show(ex.Message)
            '            End Try

            '        Case "Venta FORM.: Contado ET."
            '            Dim cierreSA As New empresaCierreMensualSA
            '            Cursor = Cursors.WaitCursor
            '            Dim cajaUsuario As New cajaUsuario
            '            Dim cajaUsuarioSA As New cajaUsuarioSA
            '            Try
            '                Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
            '                If Not IsNothing(valida) Then
            '                    If valida = True Then
            '                        MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '                        Exit Sub
            '                    End If
            '                End If
            '                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
            '                If Not IsNothing(cajaUsuario) Then
            '                    With frmVenta
            '                        .lblPerido.Text = MesGeneral & "/" & AnioGeneral
            '                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '                        .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_TOTAL)
            '                        .StartPosition = FormStartPosition.CenterParent
            '                        .ShowDialog()
            '                    End With
            '                Else
            '                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '                End If

            '            Catch ex As Exception
            '                MsgBox(ex.Message)
            '            End Try
            '            Cursor = Cursors.Default

            '        Case "Venta POS: Credito ET."
            '            Dim cierreSA As New empresaCierreMensualSA
            '            Cursor = Cursors.WaitCursor
            '            Try
            '                Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
            '                If Not IsNothing(valida) Then
            '                    If valida = True Then
            '                        MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '                        Exit Sub
            '                    End If
            '                End If
            '                With frmVentaPVdirecta
            '                    .lblPerido.Text = MesGeneral & "/" & AnioGeneral
            '                    .CargarTipoDeVenta(TIPO_VENTA.VENTA_CREDITO_TOTAL)
            '                    .StartPosition = FormStartPosition.CenterParent
            '                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '                    .ShowDialog()
            '                End With
            '            Catch ex As Exception
            '                MessageBox.Show(ex.Message)
            '            End Try
            '            Cursor = Cursors.Default

            '        Case "Venta FORM.: Credito ET."
            '            Dim cierreSA As New empresaCierreMensualSA
            '            Cursor = Cursors.WaitCursor
            '            Try
            '                Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
            '                If Not IsNothing(valida) Then
            '                    If valida = True Then
            '                        MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '                        Exit Sub
            '                    End If
            '                End If

            '                Dim f As New frmVenta
            '                f.lblPerido.Text = MesGeneral & "/" & AnioGeneral
            '                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '                f.CargarTipoDeVenta(TIPO_VENTA.VENTA_CREDITO_TOTAL)
            '                f.StartPosition = FormStartPosition.CenterParent
            '                f.ShowDialog()

            '            Catch ex As Exception
            '                MessageBox.Show(ex.Message)
            '            End Try
            '            Cursor = Cursors.Default

            '        Case "Registro de ventas"
            '            Dim f As New frmVentasMaestro
            '            f.ToolStripDropDownButton4.Visible = False
            '            f.StartPosition = FormStartPosition.CenterParent
            '            f.ShowDialog()
            '    End Select
            '    LoadingComercial.Visible = False
        End If

    End Sub

    Private Sub SelectDGFinanzas(r As Record)
        Dim frm As New frmMaster
        If Me.InvokeRequired Then
            Dim deleg As New _delegadoSeleccionDGVLogistica(AddressOf SelectDGFinanzas)
            Invoke(deleg, New Object() {r})
        Else
            Dim detalleModulo = r.GetValue("detalle")
            Dim ObtenerFRM = AutorizacionRolList.Where(Function(o) o.Nomasegurable = detalleModulo).FirstOrDefault
            If ObtenerFRM IsNot Nothing Then
                Dim formName As String = ObtenerFRM.Formulario
                formName = [Assembly].GetEntryAssembly.GetName.Name & "." & formName
                frm = DirectCast([Assembly].GetEntryAssembly.CreateInstance(formName), frmMaster)
                frm.StartPosition = FormStartPosition.CenterParent
                frm.ShowDialog()
            Else
                MessageBox.Show("Usuario no autorizado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            'Select Case r.GetValue("detalle")
            '    Case "Otras ingresos a caja"
            '        Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
            '        If Not IsNothing(valida) Then
            '            If valida = True Then
            '                MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '                Exit Sub
            '            End If
            '        End If
            '        With frmEntradaSalidaCaja
            '            .txtPeriodo.Value = New Date(AnioGeneral, CInt(MesGeneral), 1)
            '            .lblMovimiento.Tag = "OEC"
            '            .lblMovimiento.Text = "OTRAS ENTRADAS A CAJA"
            '            .CaptionLabels(0).Text = "OTRAS ENTRADAS A CAJA"
            '            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '            .txtTipoCambio.Value = TmpTipoCambio
            '            .cboMesCompra.SelectedValue = MesGeneral
            '            .cboMesCompra.Enabled = True
            '            .txtDia.Value = New Date(AnioGeneral, CInt(MesGeneral), DiaLaboral.Day)
            '            .StartPosition = FormStartPosition.CenterParent
            '            .ShowDialog()
            '        End With

            '    Case "Otras salidas de caja"
            '        Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
            '        If Not IsNothing(valida) Then
            '            If valida = True Then
            '                MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '                Exit Sub
            '            End If
            '        End If
            '        With frmEntradaSalidaCaja
            '            .txtPeriodo.Value = New Date(AnioGeneral, CInt(MesGeneral), 1)
            '            .lblMovimiento.Tag = "OSC"
            '            .lblMovimiento.Text = "OTRAS SALIDAS DE CAJA"
            '            .CaptionLabels(0).Text = "OTRAS SALIDAS DE CAJA"
            '            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '            .txtTipoCambio.Value = TmpTipoCambio
            '            .cboMesCompra.SelectedValue = MesGeneral
            '            .cboMesCompra.Enabled = True
            '            .txtDia.Value = New Date(AnioGeneral, CInt(MesGeneral), DiaLaboral.Day)
            '            .StartPosition = FormStartPosition.CenterParent
            '            .ShowDialog()
            '        End With

            '    Case "Cuentas por pagar"
            '        Dim f As New frmFinanzaCuentasPagar
            '        f.StartPosition = FormStartPosition.CenterParent
            '        f.ShowDialog()

            '    Case "Cuentas por cobrar"
            '        Dim f As New frmFinanzasCuentasPorCobrar
            '        f.StartPosition = FormStartPosition.CenterParent
            '        f.ShowDialog()

            '    Case "Anticipos recibidos"
            '        Dim f As New frmIngresoXAnticipoMaster
            '        f.StartPosition = FormStartPosition.CenterParent
            '        f.ShowDialog()
            '    Case "Reclamaciones de clientes"
            '        Dim f As New frmReclamaciones
            '        f.StartPosition = FormStartPosition.CenterParent
            '        f.ShowDialog()

            '    Case "Compensaciones"

            '    Case "Registro Otras Entradas a caja"
            '        Dim f As New frmOtrasEntradasCaja
            '        f.StartPosition = FormStartPosition.CenterParent
            '        f.ShowDialog()
            '    Case "Registro Otras Salidas de caja"
            '        Dim f As New frmOtrasSalidasCaja
            '        f.StartPosition = FormStartPosition.CenterParent
            '        f.ShowDialog()

            '    Case "Movimientos cuentas financieras"
            '        Dim f As New frmMovimientosMN
            '        f.StartPosition = FormStartPosition.CenterParent
            '        f.ShowDialog()

            'End Select
            LoadingFinanzas.Visible = False
        End If
    End Sub

    Private Sub LoadDockingPanel()
        DockingClientPanel1.AutoScroll = True
        DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None
        dockingManager1.DockControlInAutoHideMode(PanelPagos, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 338)
        dockingManager1.SetDockLabel(PanelPagos, "Pagos")
    End Sub

    Private Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean, GGC As GridGroupingControl)
        Dim color As New GridMetroColors()
        Dim id As GridTableCellStyleInfoIdentity = GGC.TableControl.GetTableViewStyleInfo(row, col).TableCellIdentity
        If id.DisplayElement.IsRecord() Then
            Dim key As Integer = id.DisplayElement.GetRecord().Id
            'if (selectionColl.Contains(key))
            '    selectionColl[key] = isHover;
            'else
            hoveredIndex = row
            selectionColl.Clear()
            'if (selectionColl.Count == 0)
            '    selectionColl.Add(key, isHover);
            GGC.TableControl.Refresh()
        End If

        GGC.TableControl.Selections.Clear()

    End Sub

    Public Function ConteoProductosSinPrecio() As Integer
        Dim totales As New List(Of totalesAlmacen)
        totales = totalSA.NumProductosSinListaPrecio(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento})

        Return totales.Count
    End Function

    Private Function GetCountExistenciaTransito() As Integer
        Dim compraSA As New DocumentoCompraSA


        Return compraSA.GetCountExistenciaTransito(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                       .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                       .tipoCompra = TIPO_COMPRA.COMPRA})



    End Function

    Public Sub GetTransitoConteo()
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim documentocompra = New List(Of documentocompra)
        documentocompra = DocumentoCompraSA.GetTransferenciasByEmpresa(GEstableciento.IdEstablecimiento)
        Dim i = (From a In documentocompra Where a.estadoEntrega = "PN").Count
        Dim x = (From a In documentocompra Where a.estadoEntrega = "DC").Count

        conteoTransArticulosPendientes = i
        conteoTransArticulosConfirmados = x

        'If i > 0 Then
        '    notify = New PopupNotifier
        '    notify.Image = ImageList1.Images(0)
        '    notify.TitleFont = New Font("Century Gothic", 10, FontStyle.Bold)
        '    notify.BorderColor = Color.FromKnownColor(KnownColor.HotTrack)
        '    notify.HeaderColor = Color.FromKnownColor(KnownColor.HotTrack)

        '    notify.TitleColor = Color.FromKnownColor(KnownColor.HotTrack)
        '    notify.TitleText = "ARTICULOS EN TRANSITO"
        '    notify.TitleFont = New Font("Century Gothic", 10, FontStyle.Bold)

        '    notify.BodyColor = Color.LavenderBlush
        '    notify.BorderColor = Color.FromArgb(75, 164, 249)

        '    notify.ContentText = "{" & i.ToString & "}" & " ARTICULOS PENDIENTES DE ENVIO A ALMACÉN"
        '    notify.ContentFont = New Font("Century Gothic", 9)
        '    notify.ContentColor = Color.Black
        '    notify.Popup()
        'End If

    End Sub

    Public Sub GetProveedoresXPagar(anio As Integer, empresa As String)
        compraSA = New DocumentoCompraSA
        Dim Xpagar = compraSA.GetProveedoresXpagar(anio, empresa).Sum(Function(o) o.Xpagar)
        ImportePorPagarAproveedores = Xpagar
    End Sub

    Public Sub GetClientesXCobrar(anio As Integer, empresa As String)
        compraSA = New DocumentoCompraSA
        Dim Xpagar = compraSA.GetClientesXcobrar(anio, empresa).Sum(Function(o) o.Xpagar)
        ImportePorCobrarAclientes = Xpagar
    End Sub

    Public Function GetInventarioEnAlertaConteo(be As totalesAlmacen) As Integer
        Return totalSA.GetAlertaIventarioMinimoConteo(be)
    End Function

    Private Sub GetAlertas()
        Dim TotalesAlmacenSA As New TotalesAlmacenSA
        conteoEnTransito = GetCountExistenciaTransito()
        conteoStockMinimo = GetInventarioEnAlertaConteo(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
        conteoArticulosSinPrecio = ConteoProductosSinPrecio()
        conteoArticulosVencidos = TotalesAlmacenSA.GetProductosXvencerMesCount(Gempresas.IdEmpresaRuc, DateTime.Now.Year, DateTime.Now.Month)
    End Sub


    Private Sub GetAlertaCompleted()
        dgvLogistica.Table.Records(3).SetValue("info", conteoEnTransito)
        dgvLogistica.Table.Records(2).SetValue("info", conteoTransArticulosConfirmados)
        dgvLogistica.Table.Records(4).SetValue("info", conteoTransArticulosPendientes)

        If conteoEnTransito > 0 Then
            Dim notify As New PopupNotifier
            notify.Image = ImageList1.Images(0)
            notify.TitleFont = New Font("Century Gothic", 10, FontStyle.Bold)
            notify.BorderColor = Color.FromKnownColor(KnownColor.HotTrack)
            notify.HeaderColor = Color.FromKnownColor(KnownColor.HotTrack)

            notify.TitleColor = Color.FromKnownColor(KnownColor.HotTrack)
            notify.TitleText = "ARTICULOS EN TRANSITO"
            notify.TitleFont = New Font("Century Gothic", 10, FontStyle.Bold)

            notify.BodyColor = Color.LavenderBlush
            notify.BorderColor = Color.FromArgb(75, 164, 249)

            If conteoEnTransito = 1 Then
                notify.ContentText = "{" & conteoEnTransito.ToString & "}" & " ARTICULO PENDIENTE DE ENVIO A ALMACÉN"
            Else
                notify.ContentText = "{" & conteoEnTransito.ToString & "}" & " ARTICULOS PENDIENTES DE ENVIO A ALMACÉN"
            End If
            notify.ContentFont = New Font("Century Gothic", 9)
            notify.ContentColor = Color.Black
            notify.Delay = 10000
            notify.Popup()
        End If
    End Sub


    Sub LoadModulosPOS()
        dgvLogistica.Table.Records.DeleteAll()
        dgvComercial.Table.Records.DeleteAll()
        dgvFinanzas.Table.Records.DeleteAll()

        'Logistica
        Dim listadoLogistica = AsegurableSA.GetAsegurablesByPadreXcliente(New Asegurable With {.IDEmpresa = Gempresas.IdEmpresaRuc, .Nombre = "PANEL LOGISTICA"})

        dt = New DataTable
        dt.Columns.Add("detalle")
        dt.Columns.Add("info")
        For Each log In listadoLogistica
            dt.Rows.Add(log.Nombre)
        Next


        'dt.Rows.Add("Compras")
        'dt.Rows.Add("Proveedores")
        'dt.Rows.Add("Movimientos de almacén (entradas, sálidas)")
        'dt.Rows.Add("Otros ingresos a almacén")
        'dt.Rows.Add("Otros salidas de almacén")
        'dt.Rows.Add("transferencias a otros almacenes", "0")
        'dt.Rows.Add("Recep. de inventario en tránsito por compras", "0")
        'dt.Rows.Add("Recep. de inventario en tránsito por transferencia", "0")
        'dt.Rows.Add("Kardex")
        'dt.Rows.Add("Inventario Valorizado")
        'dt.Rows.Add("Lista de precios - inventario")
        'dt.Rows.Add("Lista de precios - servicios")
        dgvLogistica.DataSource = dt
        dgvLogistica.TableDescriptor.Columns("detalle").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvLogistica.TableDescriptor.Columns("detalle").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        dgvLogistica.TableDescriptor.Columns("detalle").Appearance.AnyCell.TextColor = Color.Black

        'Comercial
        Dim listadoComercial = AsegurableSA.GetAsegurablesByPadreXcliente(New Asegurable With {.IDEmpresa = Gempresas.IdEmpresaRuc, .Nombre = "PANEL COMERCIAL"})

        dt = New DataTable
        dt.Columns.Add("detalle")
        'dt.Rows.Add("Registro de ventas")
        'dt.Rows.Add("Clientes")
        'dt.Rows.Add("Cotizaciones - proformas")
        'dt.Rows.Add("Pre venta")
        'dt.Rows.Add("Caja centralizada")
        'dt.Rows.Add("Venta POS: Contado ET.")
        'dt.Rows.Add("Venta FORM.: Contado ET.")
        'dt.Rows.Add("Venta POS: Credito ET.")
        'dt.Rows.Add("Venta FORM.: Credito ET.")
        For Each co In listadoComercial
            dt.Rows.Add(co.Nombre)
        Next

        dgvComercial.DataSource = dt
        dgvComercial.TableDescriptor.Columns("detalle").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvComercial.TableDescriptor.Columns("detalle").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        dgvComercial.TableDescriptor.Columns("detalle").Appearance.AnyCell.TextColor = Color.Black

        'Finanzas
        Dim listadofinanzas = AsegurableSA.GetAsegurablesByPadreXcliente(New Asegurable With {.IDEmpresa = Gempresas.IdEmpresaRuc, .Nombre = "PANEL FINANZAS"})

        dt = New DataTable
        dt.Columns.Add("detalle")

        For Each s In listadofinanzas
            dt.Rows.Add(s.Nombre)
        Next
        'dt.Rows.Add("Otras ingresos a caja")
        'dt.Rows.Add("Otras salidas de caja")
        'dt.Rows.Add("Movimientos cuentas financieras")
        'dt.Rows.Add("Registro Otras Entradas a caja")
        'dt.Rows.Add("Registro Otras Salidas de caja")
        'dt.Rows.Add("Cuentas por cobrar")
        'dt.Rows.Add("Cuentas por pagar")
        'dt.Rows.Add("Anticipos recibidos")
        'dt.Rows.Add("Reclamaciones de clientes")
        'dt.Rows.Add("Compensaciones")

        dgvFinanzas.DataSource = dt
        dgvFinanzas.TableDescriptor.Columns("detalle").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvFinanzas.TableDescriptor.Columns("detalle").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        dgvFinanzas.TableDescriptor.Columns("detalle").Appearance.AnyCell.TextColor = Color.Black


    End Sub

    'Sub ValidarFechaActual()
    '    Dim fechaInicio As Date = DiaLaboral

    '    If fechaInicio.Date <> Date.Now.Date Then

    '        TerminarProceso("Helios.Cont.Presentation.WinForm")
    '        TerminarProceso("SMSvcHost.exe")
    '        Application.ExitThread()
    '        '  Application.Restart()
    '        'For Each frm As Form In Application.OpenForms
    '        '    If frm IsNot Me Then

    '        '        If frm.Name = "FeedbackForm" Then

    '        '        Else
    '        '            frm.Close()
    '        '        End If
    '        '        'Cerramos todos los formularios menos el formulario principal que contiene el menú
    '        '    End If
    '        'Next
    '        'Timer2.Enabled = False
    '        'Inicio()
    '        'lblEstablecimiento.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
    '        'Label5.Text = PeriodoGeneral
    '    End If
    'End Sub

    'Sub Inicio()
    '    usuario = New AutenticacionUsuario
    '    usuario.CustomUsuario = New Usuario
    '    Dim LightBox As New HeliosLogin
    '    LightBox.SetBounds(Me.Left, Me.Top, Me.ClientRectangle.Width, Me.ClientRectangle.Height)
    '    LightBox.Owner = Me
    '    LightBox.ShowDialog()

    '    If Not IsNothing(usuario) Then
    '        ' SplitButton1.BackColor = Color.FromArgb(92, 184, 92)
    '        SplitButton1.BackColor = Color.FromArgb(213, 79, 185)
    '        Panel3.Enabled = True
    '        SplitButton1.Text = usuario.Alias
    '        'Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
    '        '    Case 1 ' ADMINISTRADOR

    '        '        Dim init As New frmInicioEmpresa
    '        '        init.StartPosition = FormStartPosition.CenterParent
    '        '        init.ShowDialog()

    '        '        'CargarConfiguracionInicio(Gempresas.IdEmpresaRuc)
    '        '        '     CoNteoNotifi()
    '        '    Case 2 ' USUARI BASICO => SOLO ACCESO AL PUNTP DE VENTA
    '        '        CargarConfiguracionInicioUsuariosDeCaja(Gempresas.IdEmpresaRuc)

    '        '    Case 3, 4 ' USUARIO PUNTO DE VENTA MANJEJO DE EFECTIVO
    '        '        CargarConfiguracionInicioUsuariosDeCaja(Gempresas.IdEmpresaRuc)
    '        'End Select

    '        Select Case (LightBox.empresaSPK.FirstOrDefault.TieneCaja)
    '            Case True
    '                CargarConfiguracionInicioUsuariosDeCaja(Gempresas.IdEmpresaRuc)
    '            Case False
    '                Dim init As New frmInicioEmpresa
    '                init.StartPosition = FormStartPosition.CenterParent
    '                init.ShowDialog()
    '        End Select

    '        Label24.Text = GEstableciento.NombreEstablecimiento

    '        'Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
    '        '    Case 1
    '        '        Label15.Text = usuario.CustomUsuario.Full_Name & "-" & "Administrador POS"
    '        '    Case 2
    '        '        Label15.Text = usuario.CustomUsuario.Full_Name & "-" & "Atención (Pre-venta)"
    '        '    Case 3
    '        '        Label15.Text = usuario.CustomUsuario.Full_Name & "-" & "Cajero (Caja centralizada)"
    '        '    Case 4
    '        '        Label15.Text = usuario.CustomUsuario.Full_Name & "-" & "Cajero (Venta Directa)"

    '        'End Select

    '        'If bg.IsBusy <> True Then
    '        '    ' Start the asynchronous operation.
    '        '    bg.RunWorkerAsync()
    '        'End If
    '    Else
    '        '  SplitButton1.BackColor = Color.FromArgb(22, 165, 220)
    '        SplitButton1.BackColor = Color.FromArgb(213, 79, 185)
    '        SplitButton1.Text = "Usuario"
    '        Panel3.Enabled = False
    '        MessageBox.Show("Usario o clave incorrectos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        'MatarProceso("SMSvcHost.exe")
    '        'Application.ExitThread()
    '        'Me.Close()
    '    End If
    'End Sub

    Private Function MatarProceso(ByVal StrNombreProceso As String,
    Optional ByVal DecirSINO As Boolean = True) As Boolean
        ' Variables para usar Wmi  
        Dim ListaProcesos As Object
        Dim ObjetoWMI As Object
        Dim ProcesoACerrar As Object

        MatarProceso = False

        ObjetoWMI = GetObject("winmgmts:")

        If ObjetoWMI Is DBNull.Value = False Then

            'instanciamos la variable  
            ListaProcesos = ObjetoWMI.InstancesOf("win32_process")

            For Each ProcesoACerrar In ListaProcesos
                If UCase(ProcesoACerrar.Name) = UCase(StrNombreProceso) Then
                    If DecirSINO Then
                        '   If MsgBox("¿Matar el proceso " & _
                        'ProcesoACerrar.Name & vbNewLine & "...¿Está seguro?", _
                        '                      vbYesNo + vbCritical) = vbYes Then

                        ProcesoACerrar.Terminate(0)
                        MatarProceso = True
                        '  End If
                    Else
                        'Matamos el proceso con el método Terminate  
                        ProcesoACerrar.Terminate(0)
                        MatarProceso = True
                    End If
                End If

            Next
        End If

        'Elimina las variables  
        ListaProcesos = Nothing
        ObjetoWMI = Nothing
    End Function

    Private Sub GrabarConfiInicio()
        Dim config As New configuracionInicio
        Dim existe As New configuracionInicio
        Dim configsa As New ConfiguracionInicioSA
        With config
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .idalmacenVenta = TmpIdAlmacen
            .anio = CStr(DateTime.Now.Year)
            .mes = String.Format("{0:00}", Convert.ToInt32(DateTime.Now.Month))
            .dia = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            .periodo = String.Format("{0:00}", Convert.ToInt32(DateTime.Now.Month)) & "/" & DateTime.Now.Year
            .tipocambio = TmpTipoCambio
            .iva = TmpIGV
            .tipoIva = TmpTipoIVA
            .retencion4ta = TmpRetencion4

            existe = configsa.ObtenerConfigXempresa(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)

            If Not IsNothing(existe) Then
                configsa.EditarConfigInicio(config)
            Else
                'configsa.InsertConfigInicio(config)
            End If

            AnioGeneral = CStr(DateTime.Now.Year)
            MesGeneral = String.Format("{0:00}", Convert.ToInt32(DateTime.Now.Month))
            DiaLaboral = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(DateTime.Now.Month)) & "/" & DateTime.Now.Year

        End With
    End Sub

    Private Function TerminarProceso(ByVal StrNombreProceso As String,
    Optional ByVal DecirSINO As Boolean = True) As Boolean
        ' Variables para usar Wmi  
        Dim ListaProcesos As Object
        Dim ObjetoWMI As Object
        Dim ProcesoACerrar As Object

        TerminarProceso = False

        ObjetoWMI = GetObject("winmgmts:")

        If ObjetoWMI Is DBNull.Value = False Then

            'instanciamos la variable  
            ListaProcesos = ObjetoWMI.InstancesOf("win32_process")

            For Each ProcesoACerrar In ListaProcesos
                If UCase(ProcesoACerrar.Name) = UCase(StrNombreProceso) Then
                    If DecirSINO Then
                        '   If MsgBox("¿Matar el proceso " & _
                        'ProcesoACerrar.Name & vbNewLine & "...¿Está seguro?", _
                        '                      vbYesNo + vbCritical) = vbYes Then

                        ProcesoACerrar.Terminate(0)
                        TerminarProceso = True
                        '  End If
                    Else
                        'Matamos el proceso con el método Terminate  
                        ProcesoACerrar.Terminate(0)
                        TerminarProceso = True
                    End If
                End If

            Next
        End If

        'Elimina las variables  
        ListaProcesos = Nothing
        ObjetoWMI = Nothing
    End Function

    Public Sub CargarConfiguracionInicioUsuariosDeCaja(strIdEmpresa As String)
        Dim configSA As New ConfiguracionInicioSA
        Dim config As New configuracionInicio
        Dim estableSA As New establecimientoSA
        Dim almaceSa As New almacenSA
        Dim cierreCajaSA As New CierreCajaSA
        Dim cierreInventarioSA As New CierreInventarioSA
        config = configSA.ObtenerConfigXempresa(strIdEmpresa, GEstableciento.IdEstablecimiento)

        If Not IsNothing(config) Then
            With config
                GEstableciento = New GEstablecimiento
                GEstableciento.IdEstablecimiento = .idCentroCosto
                GEstableciento.NombreEstablecimiento = estableSA.UbicaEstablecimientoPorID(.idCentroCosto).nombre
                Dim nomEmpresa = "EMR NEGOCIOS SAC." ' lblEstablecimiento.Text ' Gempresas.NomEmpresa
                Gempresas = New GEmpresa
                Gempresas.IdEmpresaRuc = CStr(strIdEmpresa).Trim
                Gempresas.NomEmpresa = nomEmpresa
                'TmpNombreAlmacen = almaceSa.GetUbicar_almacenPorID(.idalmacenVenta).descripcionAlmacen
                AnioGeneral = .anio
                MesGeneral = .mes
                DiaLaboral = .dia
                PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(.mes)) & "/" & .anio
                TmpTipoCambio = .tipocambio
                TmpIGV = .iva
                TmpTipoIVA = .tipoIva
                TmpRetencion4 = .retencion4ta.GetValueOrDefault
            End With
        End If
    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv9_Click(sender As Object, e As EventArgs) Handles ButtonAdv9.Click
        Dim f As New frmCuentasFinancieras
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub dgvLogistica_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvLogistica.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            'Dim str = dgvCompras.TableModel(e.TableCellIdentity.RowIndex, 1).CellValue
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Black
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvLogistica.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvComercial_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvComercial.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            'Dim str = dgvCompras.TableModel(e.TableCellIdentity.RowIndex, 1).CellValue
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Black
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvComercial.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvFinanzas_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvFinanzas.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            'Dim str = dgvCompras.TableModel(e.TableCellIdentity.RowIndex, 1).CellValue
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Black
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvFinanzas.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        'Cursor = Cursors.WaitCursor

        'Dim f2 As New frmPantallaAportesDeInicio '  frmInicioTrabajoEmpresa(Gempresas.IdEmpresaRuc)
        'f2.StartPosition = FormStartPosition.CenterParent
        'f2.ShowDialog()

        ''With frmInformacionGeneral
        ''    .lblPerido.Text = PeriodoGeneral
        ''    .StartPosition = FormStartPosition.CenterParent
        ''    .ShowDialog()
        ''End With
        'Cursor = Cursors.Default
    End Sub

    Private Sub Panel2_Click(sender As Object, e As EventArgs) Handles Panel2.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.PERMISO_Y_ROLES_DE_USUARIO__, AutorizacionRolList) Then
            'Dim f As New frmMaestroSistemaUsers
            'f.StartPosition = FormStartPosition.CenterScreen
            'f.Show()
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.CONFIGURACION_SISTEMA__, AutorizacionRolList) Then
            Dim f As New frmListaPermisos
            f.WindowState = FormWindowState.Maximized
            f.ShowDialog()
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BtDashBoard_Click(sender As Object, e As EventArgs) Handles BtDashBoard.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.INFORMACION_GERENCIAL_Dashword__, AutorizacionRolList) Then
            'Dim F As New frmTableroPorDia
            ''Dim f As New frmDashBoard
            'F.StartPosition = FormStartPosition.CenterParent
            'F.ShowDialog()
            With frmInformacionGeneral
                .lblPerido.Text = PeriodoGeneral
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With

        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.CONFIGURACION_DE_INICIO__, AutorizacionRolList) Then
            Dim f As New frmInicioEmpresa ' frmInicioEmpresa
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            'Label5.Text = "Período: " & PeriodoGeneral
            'lblEmpresa.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
            'Label24.Text = GEstableciento.NombreEstablecimiento

            ''If bg.IsBusy <> True Then
            ''    ' Start the asynchronous operation.
            ''    bg.RunWorkerAsync()
            ''End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SplitButton1_DropDowItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles SplitButton1.DropDowItemClicked
        Try
            Select Case e.ClickedItem.Text
                Case "Iniciar Sesion"
                    '   Inicio()
                    FormLogeo()
                Case "Cerrar Sesion"
                    '    SplitButton1.BackColor = Color.FromArgb(22, 165, 220)
                    SplitButton1.BackColor = Color.FromArgb(213, 79, 185)
                    SplitButton1.Text = "Usuario"
                    Panel3.Enabled = False
                    '   Inicio()
                    FormLogeo()
            End Select
            lblEmpresa.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
            Label5.Text = PeriodoGeneral
            LoadModulosPOS()
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FormLogeo()
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        i += 1000
        If i = 1000 Then
            i = 0
            Timer1.Stop()
            FormLogeo()
            LoadModulosPOS()
        End If
        Panel1.Enabled = True
        Panel3.Enabled = True
    End Sub

    Private Sub FormLogeo()
        LightBox = New HeliosLogin
        LightBox.SetBounds(Left, Top, ClientRectangle.Width, ClientRectangle.Height)
        LightBox.Owner = Me
        LightBox.ShowDialog()
        GetConfiguracionInicio()
        If Not IsNothing(LightBox.Tag) Then
            If Not IsNothing(usuario) Then
                SplitButton1.BackColor = Color.FromArgb(213, 79, 185)
                Panel3.Enabled = True
                SplitButton1.Text = usuario.Alias
                Timer2.Enabled = True
            End If
            If bg.IsBusy <> True Then
                ' Start the asynchronous operation.
                bg.RunWorkerAsync()
            End If
        Else
            MatarProceso("Helios.Cont.Presentation.WinForm")
            MatarProceso("SMSvcHost.exe")
            Application.ExitThread()
            Close()
        End If
    End Sub

    'Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
    '    'ValidarFechaActual()
    '    'Timer2.Enabled = True
    'End Sub

    Private Sub frmMaestroModuloPOS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MessageBoxAdv.Show("S O F T - P A C K, ¿Desea salir?", "Salir del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            TerminarProceso("Helios.Cont.Presentation.WinForm")
            TerminarProceso("SMSvcHost.exe")
            Application.ExitThread()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmMaestroModuloPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim boundWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim boundHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim x As Integer = boundWidth - Me.Width
        Dim y As Integer = boundHeight - Me.Height
        Me.Location = New Point(x \ 2, y \ 2)

        SplitButton1.Style = Syncfusion.Windows.Forms.Tools.SplitButtonVisualStyle.Metro
        SplitButton1.BackColor = Color.FromArgb(213, 79, 185)
        PopupMenusManager1.SetXPContextMenu(PictureBox1, PopupMenu1)
        Me.WindowState = FormWindowState.Normal
        Timer1.Enabled = True
        dgvLogistica.ShowColumnHeaders = False
        dgvComercial.ShowColumnHeaders = False
        dgvFinanzas.ShowColumnHeaders = False
        TmpProduccionPorLotes = True
    End Sub

    Private Sub dgvLogistica_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvLogistica.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvLogistica)
    End Sub

    Private Sub dgvComercial_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvComercial.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvComercial)
    End Sub

    Private Sub dgvFinanzas_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvFinanzas.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvFinanzas)
    End Sub

    Private Sub dgvLogistica_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvLogistica.TableControlCellDoubleClick
        PictureBox2.Visible = True
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() SelectDGLogistica(dgvLogistica.Table.CurrentRecord)))
        thread.Start()
    End Sub

    Private Sub dgvComercial_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvComercial.TableControlCellDoubleClick
        Dim r As Record = dgvComercial.Table.CurrentRecord
        If Not IsNothing(r) Then
            LoadingComercial.Visible = True
            Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() SelectDGComercial(r)))
            thread.Start()
        End If
    End Sub

    Private Sub dgvFinanzas_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvFinanzas.TableControlCellDoubleClick
        Dim r As Record = dgvFinanzas.Table.CurrentRecord
        If Not IsNothing(r) Then
            LoadingFinanzas.Visible = True
            Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() SelectDGFinanzas(r)))
            thread.Start()
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim f As New frmAdminUsuariosCaja
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim f As New frmAbrirCerrar_Caja
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.CIERRES__, AutorizacionRolList) Then
            Dim f As New frmselectCierre
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvComercial_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvComercial.TableControlCellClick

    End Sub

    Private Sub dgvFinanzas_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvFinanzas.TableControlCellClick

    End Sub

    Private Sub bg_DoWork(sender As Object, e As DoWorkEventArgs) Handles bg.DoWork
        GetAlertas()
        GetTransitoConteo()

        If Gempresas.IDProducto = 23 Then

        Else
            PanelPagos.Visible = True
            MostrarCuentasXpagar()
            MostrarCuentasXcobrar()
        End If
    End Sub

    Private Sub bg_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bg.RunWorkerCompleted
        GetAlertaCompleted()
        If conteoArticulosVencidos > 0 Then
            Dim frm As New frmAlertForm
            frm.StartPosition = FormStartPosition.CenterParent
            frm.ShowDialog()
        End If

        If Gempresas.IDProducto = "23" Then
            PanelPagos.Visible = False
        End If
    End Sub

    Private Sub GetConfiguracionInicio()
        Dim cierreSA As New empresaCierreMensualSA
        Dim tipoCambioSA As New tipoCambioSA
        Dim configuracion As New configuracionInicio
        Dim inicio = configuracionInicioSA.ObtenerConfigXempresa(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Dim anioSA As New empresaPeriodoSA


        Dim existeAnio = anioSA.GetUbicar_empresaPeriodoPorID(Gempresas.IdEmpresaRuc, Date.Now.Year, GEstableciento.IdEstablecimiento)
        If existeAnio Is Nothing Then
            Dim nuevoAnio As New empresaPeriodo With
                {
                .idEmpresa = Gempresas.IdEmpresaRuc,
                .periodo = Date.Now.Year,
                .cerrado = False,
                .usuarioActualizacion = usuario.IDUsuario,
                .fechaActualizacion = Date.Now
                }
            anioSA.InsertarPeriodo(nuevoAnio)

            existeAnio = nuevoAnio
        End If

        Dim tipoCambioDelDia = tipoCambioSA.ObtenerTipoCambioXfecha(Gempresas.IdEmpresaRuc, Date.Now.Date, GEstableciento.IdEstablecimiento)

        If tipoCambioDelDia Is Nothing Then
            'Agregar nueva instancia
            Dim objTC As New tipoCambio With
                                  {
                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                  .fechaIgv = Date.Now,
                                  .idRegulador = 100,
                                  .compra = 3,
                                  .venta = 3,
                                  .usuarioModificacion = usuario.IDUsuario,
                                  .fechaModificacion = Date.Now
                                  }

            tipoCambioSA.InsertTC(objTC)
            tipoCambioDelDia = objTC
        Else
            'utilizar instancia recuperada
        End If


        configuracion = New configuracionInicio With
                {
                .idEmpresa = Gempresas.IdEmpresaRuc,
                .idCentroCosto = GEstableciento.IdEstablecimiento,
                .periodo = String.Format("{0:00}", Date.Now.Month) & "/" & Date.Now.Year,
                .anio = existeAnio.periodo,
                .mes = Date.Now.Month,
                .dia = Date.Now,
                .tipocambio = 3,
                .iva = 18,
                .tipoIva = "IVA",
                .montoMaximo = 699,
                .proyecto = "N",
                .tipoCambioTransacCompra = 3,
                .tipoCambioTransacVenta = 3,
                .cronogramaPagos = False,
                .usacronogramapago = False
                }

        If inicio Is Nothing Then
            'crear nueva instancia
            configuracionInicioSA.InsertConfigInicio(configuracion)
            inicio = configuracion
        Else
            'actualizar instancia creada
            configuracion.iva = inicio.iva
            configuracion.montoMaximo = inicio.montoMaximo
            configuracionInicioSA.EditarConfigInicio(configuracion)
        End If

        'Variables y etiquetas
        tmpConfigInicio = configuracion

        AnioGeneral = existeAnio.periodo
        MesGeneral = String.Format("{0:00}", Date.Now.Month)
        DiaLaboral = Date.Now
        PeriodoGeneral = String.Format("{0:00}", Date.Now.Month) & "/" & existeAnio.periodo

        TmpTipoCambio = 3
        TmpTipoCambioTransaccionCompra = 3
        TmpTipoCambioTransaccionVenta = 3
        TmpIGV = inicio.iva
        MontoMaximoCliente = inicio.montoMaximo

        txtAnio.Value = New Date(existeAnio.periodo, Date.Now.Month, 1)
        Label5.Text = "Período: " & String.Format("{0:00}", Date.Now.Month) & "/" & existeAnio.periodo
        lblEmpresa.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
        Label24.Text = GEstableciento.NombreEstablecimiento
        Label15.Text = usuario.Alias

        'ValidandoCierre
        Dim fechaAnt = New Date(Date.Now.Year, CInt(Date.Now.Month), 1)
        fechaAnt = fechaAnt.AddMonths(-1)
        Dim periodoAnteriorEstaCerrado As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        If periodoAnteriorEstaCerrado = False Then
            MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            Cursor = Cursors.Default
            Dim f As New frmselectCierre("No Cerrado")
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If f.Tag = "No Cerrado" Then
                Exit Sub
            End If
            If IsNothing(f.Tag) Then
                Exit Sub
            End If
        End If


    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.HOJA_DE_TRABAJO_PRINCIPAL_, AutorizacionRolList) Then
            Dim f As New FrmHojaTrabajo
            f.Show()
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub lblAbrirCaja_Click(sender As Object, e As EventArgs) Handles lblAbrirCaja.Click
        'Dim f As New frmMembresiasClienteMaestro
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()



    End Sub

    Private Sub lblCerrarCaja_Click(sender As Object, e As EventArgs) Handles lblCerrarCaja.Click
        Dim f As New frmMembresiasPorVencer
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        LoadingAnimator.Wire(dgvLogistica.TableControl)
        'Dim f As New frmDetalleCostoVentas(AnioGeneral, Integer.Parse(MesGeneral))
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
        Dim f As New frmCostoDeVentas
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        LoadingAnimator.UnWire(dgvLogistica.TableControl)
    End Sub

    Private Sub dgvLogistica_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvLogistica.TableControlCellClick

    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click

    End Sub

    Private Sub HubPagos_Click(sender As Object, e As EventArgs) Handles HubPagos.Click
        Cursor = Cursors.WaitCursor
        compraSA = New DocumentoCompraSA
        Dim lista = compraSA.GetProveedoresXpagar(txtAnio.Value.Year, Gempresas.IdEmpresaRuc)

        frmListadoProveedoresXpagar = New frmListadoProveedoresXpagar(lista)
        frmListadoProveedoresXpagar.CaptionLabels(1).Text = "Año: " & txtAnio.Value.Year
        frmListadoProveedoresXpagar.StartPosition = FormStartPosition.CenterParent
        frmListadoProveedoresXpagar.ShowDialog()
        If bg.IsBusy <> True Then
            ' Start the asynchronous operation.
            bg.RunWorkerAsync()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        GetProveedoresXPagar(AnioGeneral, Gempresas.IdEmpresaRuc)
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.CENTRAL_DE_REPORTES__, AutorizacionRolList) Then
            Dim F As New frmMasterModelReportePOS
            F.StartPosition = FormStartPosition.CenterParent
            F.ShowDialog()
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub HubCorbros_Click(sender As Object, e As EventArgs) Handles HubCobros.Click
        Cursor = Cursors.WaitCursor
        compraSA = New DocumentoCompraSA
        Dim lista = compraSA.GetClientesXcobrar(txtAnio.Value.Year, Gempresas.IdEmpresaRuc)

        frmListadoClientesXpagar = New frmListadoClientesXpagar(lista)
        frmListadoClientesXpagar.CaptionLabels(1).Text = "Año: " & txtAnio.Value.Year
        frmListadoClientesXpagar.StartPosition = FormStartPosition.CenterParent
        frmListadoClientesXpagar.ShowDialog()
        If bg.IsBusy <> True Then
            ' Start the asynchronous operation.
            bg.RunWorkerAsync()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

    End Sub

    Private Sub SplitButton1_Click(sender As Object, e As EventArgs) Handles SplitButton1.Click

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.INFORMACION_GERENCIAL_Dashword__, AutorizacionRolList) Then
            Dim f As New frmTableroGeneral
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show()
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

#End Region


End Class