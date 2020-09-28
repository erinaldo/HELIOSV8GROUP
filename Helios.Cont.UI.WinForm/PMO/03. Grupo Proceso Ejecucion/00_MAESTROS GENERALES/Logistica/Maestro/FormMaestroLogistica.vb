Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class FormMaestroLogistica

    Private empresaPeriodoSA As New empresaCierreMensualSA
    Private TabRegistroCompras As TabLG_RegistroCompras
    Private TabProveedores As TabLG_Proveedores
    Private TabTransito As TabLG_InventarioTransito
    Private UCEntregaDeMercaderiaLogistica As UCEntregaDeMercaderiaLogistica
    Private TabInvValorizado As TabLG_InventarioValorizado
    Private TabKardex As TabLG_Kardex
    Private TabLG_OtrasEntradas As TabLG_OtrasEntradas
    Private TabLG_Transferencias As TabLG_Transferencias
    Private TabLG_OtrasSalidas As TabLG_OtrasSalidas
    Private TabLG_HistorialInventario As TabLG_HistorialInventario
    Private TabLG_TransferenciasPendientes As TabLG_TransferenciasPendientes
    Private TabLG_ConfirmarTransferencia As TabLG_ConfirmarTransferencia
    Private TabLG_RegistroNotasCompra As TabLG_RegistroNotasCompra
    Private Thread As Thread
    Private ThreadSinInv As Thread
    Friend Delegate Sub SetDelegateTransito(ByVal pendientes As Integer, stockMinimo As Integer, conteoRechazados As Integer)
    Friend Delegate Sub SetDelegateTransitoTransferencia(ByVal pendientes As Integer, confirmados As Integer)
    Friend Delegate Sub SetDelegateSinStock(ByVal count As Integer)
    Private TabLG_NotasCredito As TabLG_NotasCredito
    Private TabLG_NotaDebito As TabLG_NotaDebito
    Private TabLG_Almacen As TabLG_Almacen

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GetCombos()
        ThreadTransito()
        ThreadTransitoTransferencia()
        'ThreadSinStock()
    End Sub

    Private Sub ThreadSinStock()
        Dim empresa = Gempresas.IdEmpresaRuc
        Dim estable = GEstableciento.IdEstablecimiento
        ThreadSinInv = New Thread(New System.Threading.ThreadStart(Sub() GetProductosSinStock(empresa, estable)))
        ThreadSinInv.Start()
    End Sub

    Public Sub ThreadTransito()
        Dim empresa = Gempresas.IdEmpresaRuc
        Dim estable = GEstableciento.IdEstablecimiento
        Thread = New Thread(New System.Threading.ThreadStart(Sub() GetProductosEnTransito(empresa, estable)))
        Thread.Start()
    End Sub

    Public Sub ThreadTransitoTransferencia()
        Dim empresa = Gempresas.IdEmpresaRuc
        Dim estable = GEstableciento.IdEstablecimiento
        Thread = New Thread(New System.Threading.ThreadStart(Sub() GetTransitoConteoTransferencia(estable)))
        Thread.Start()
    End Sub

    Private Sub GetProductosSinStock(empresa As String, estable As Integer?)
        Dim totalesSA As New TotalesAlmacenSA

        Dim ProductosSinStock = totalesSA.GetAlertaIventarioSinStockConteo(New totalesAlmacen With
                                                                           {
                                                                           .idEmpresa = empresa,
                                                                           .idEstablecimiento = estable
                                                                           })
        setConteoProductosSinStock(ProductosSinStock)
    End Sub

    Private Sub GetProductosEnTransito(empresa As String, estable As Integer?)
        Dim compraSA As New DocumentoCompraSA
        Dim totalesSA As New TotalesAlmacenSA

        Dim conteoTransito = compraSA.GetCountExistenciaTransito(New documentocompra With {
                                                   .idEmpresa = empresa,
                                                   .idCentroCosto = estable,
                                                   .StatusEntregaProductosTransito = "1"})

        Dim conteoRechazados = compraSA.GetCountExistenciaTransito(New documentocompra With {
                                                   .idEmpresa = empresa,
                                                   .idCentroCosto = estable,
                                                   .StatusEntregaProductosTransito = "2"})

        ' Dim pocoStock = totalesSA.GetAlertaIventarioMinimoConteo(New totalesAlmacen With {.idEmpresa = empresa})
        setConteoTransito(conteoTransito, 0, conteoRechazados)
    End Sub

    Private Sub setConteoTransito(pendientes As Integer, pocoStock As Integer, conteoRechazados As Integer)
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDelegateTransito(AddressOf setConteoTransito)
            Invoke(deleg, New Object() {pendientes, pocoStock, conteoRechazados})
        Else
            lblPendienteTransito.Text = conteoRechazados
            lblStockMinimo.Text = pocoStock
            lblRechazadosTransito.Text = pendientes
        End If
    End Sub

    Private Sub setConteoProductosSinStock(count As Integer)
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDelegateSinStock(AddressOf setConteoProductosSinStock)
            Invoke(deleg, New Object() {count})
        Else
            lblSinStock.Text = count
        End If
    End Sub

    Private Sub GetTransitoConteoTransferencia(estable As Integer)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim documentocompra = New List(Of documentocompra)
        documentocompra = DocumentoCompraSA.GetAlertaTransferenciasConteo(New Business.Entity.documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento, .tipoCompra = "TEA"}) '  DocumentoCompraSA.GetTransferenciasByEmpresa(estable)

        'Dim i = (From a In documentocompra Where a.estadoEntrega = "PN").Count
        'Dim x = (From a In documentocompra Where a.estadoEntrega = "DC").Count
        Dim i = (From a In documentocompra Where a.estadoEntrega = EstadoTransferenciaAlmacen.Pedido).Count
        Dim x = (From a In documentocompra Where a.estadoEntrega = EstadoTransferenciaAlmacen.EntregaConExito).Count


        Dim conteoTransArticulosPendientes = i
        Dim conteoTransArticulosConfirmados = x
        setConteoTransitoTransferencia(conteoTransArticulosPendientes, conteoTransArticulosConfirmados)
    End Sub

    Private Sub setConteoTransitoTransferencia(conteoTransArticulosPendientes As Integer, conteoTransArticulosConfirmados As Integer)
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDelegateTransitoTransferencia(AddressOf setConteoTransitoTransferencia)
            Invoke(deleg, New Object() {conteoTransArticulosPendientes, conteoTransArticulosConfirmados})
        Else
            lblPendTrans.Text = conteoTransArticulosPendientes
            lblEntregaTrans.Text = conteoTransArticulosConfirmados
        End If
    End Sub

    Private Sub GetCombos()
        Dim empresaAnioSA As New empresaPeriodoSA
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)

        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = DateTime.Now.Year
    End Sub

    Private Sub CompraDeExistenciasToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CompraDeServiciosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If
            Dim f As New frmServicioPublico
            f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            f.WindowState = FormWindowState.Normal
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripDropDownButton3_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton3.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.REGISTRO_DE_COMPRAS_Formulario___, AutorizacionRolList) Then
            GradientPanel11.Visible = True
            PanelBody.Controls.Clear()
        End If
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click

        If ToolStripTabItem2 Is RibbonControlAdv1.SelectedTab Then

        End If

        Dim periodo = String.Format("{0:00}", cboMesCompra.SelectedValue)
        periodo = periodo & "/" & cboAnio.Text

        PanelBody.Controls.Clear()
        TabRegistroCompras = New TabLG_RegistroCompras(periodo, Integer.Parse(cboAnio.Text), String.Format("{0:00}", cboMesCompra.SelectedValue)) With {
            .Dock = DockStyle.Fill
        }
        TabRegistroCompras.BringToFront()
        PanelBody.Controls.Add(TabRegistroCompras)
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.PROVEEDORES_Formulario___, AutorizacionRolList) Then
            GradientPanel11.Visible = False
            PanelBody.Controls.Clear()
            TabProveedores = New TabLG_Proveedores() With {
                .Dock = DockStyle.Fill
            }
            TabProveedores.BringToFront()
            PanelBody.Controls.Add(TabProveedores)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripDropDownButton4_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton4.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.INVENTARIO_EN_TRÀNSITO_Formulario___, AutorizacionRolList) Then
            GradientPanel11.Visible = False
            PanelBody.Controls.Clear()

            'TabTransito = New TabLG_InventarioTransito(Me) With {
            '    .Dock = DockStyle.Fill
            '}
            'TabTransito.BringToFront()
            'PanelBody.Controls.Add(TabTransito)

            UCEntregaDeMercaderiaLogistica = New UCEntregaDeMercaderiaLogistica(Me) With {
                .Dock = DockStyle.Fill
            }
            UCEntregaDeMercaderiaLogistica.BringToFront()
            PanelBody.Controls.Add(UCEntregaDeMercaderiaLogistica)

        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub ToolStripButton15_Click(sender As Object, e As EventArgs) Handles ToolStripButton15.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.INVENTARIO_VIGENTE_Formulario___, AutorizacionRolList) Then
            GradientPanel11.Visible = False
            PanelBody.Controls.Clear()
            TabInvValorizado = New TabLG_InventarioValorizado With {
                .Dock = DockStyle.Fill
            }
            TabInvValorizado.BringToFront()
            PanelBody.Controls.Add(TabInvValorizado)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub RibbonControlAdv1_SelectedTabItemChanged(sender As Object, e As Syncfusion.Windows.Forms.Tools.SelectedTabChangedEventArgs) Handles RibbonControlAdv1.SelectedTabItemChanged
        GradientPanel11.Visible = False
        PanelBody.Controls.Clear()
    End Sub

    Private Sub ToolStripButton22_Click(sender As Object, e As EventArgs) Handles ToolStripButton22.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.KARDEX_Formulario___, AutorizacionRolList) Then
            GradientPanel11.Visible = False
            PanelBody.Controls.Clear()
            TabKardex = New TabLG_Kardex(Me) With {
                .Dock = DockStyle.Fill
            }
            TabKardex.BringToFront()
            PanelBody.Controls.Add(TabKardex)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton25_Click(sender As Object, e As EventArgs) Handles ToolStripButton25.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.OTRAS_ENTRADAS_Formulario___, AutorizacionRolList) Then
            GradientPanel11.Visible = False
            PanelBody.Controls.Clear()
            TabLG_OtrasEntradas = New TabLG_OtrasEntradas With {
                .Dock = DockStyle.Fill
            }
            TabLG_OtrasEntradas.BringToFront()
            PanelBody.Controls.Add(TabLG_OtrasEntradas)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton26_Click(sender As Object, e As EventArgs) Handles ToolStripButton26.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.OTRAS_SALIDAS_Formulario___, AutorizacionRolList) Then
            GradientPanel11.Visible = False
            PanelBody.Controls.Clear()
            TabLG_OtrasSalidas = New TabLG_OtrasSalidas With {
                .Dock = DockStyle.Fill
            }
            TabLG_OtrasSalidas.BringToFront()
            PanelBody.Controls.Add(TabLG_OtrasSalidas)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub FormMaestroLogistica_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Thread.Abort()
        '  ThreadSinInv.Abort()
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        'ToolStripDropDownButton4_Click(sender, e)
    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NOTA_DE_CREDITO_Formulario___, AutorizacionRolList) Then
            GradientPanel11.Visible = False
            PanelBody.Controls.Clear()
            TabLG_NotasCredito = New TabLG_NotasCredito() With {
                .Dock = DockStyle.Fill
            }
            TabLG_NotasCredito.BringToFront()
            PanelBody.Controls.Add(TabLG_NotasCredito)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripDropDownButton2_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton2.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NOTA_DE_DEBITO_Formulario___, AutorizacionRolList) Then
            GradientPanel11.Visible = False
            PanelBody.Controls.Clear()
            TabLG_NotaDebito = New TabLG_NotaDebito() With {
                .Dock = DockStyle.Fill
            }
            TabLG_NotaDebito.BringToFront()
            PanelBody.Controls.Add(TabLG_NotaDebito)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub FormMaestroLogistica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripEx11.Visible = True
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim periodo = String.Format("{0:00}", cboMesCompra.SelectedValue)
        periodo = periodo & "/" & cboAnio.Text

        PanelBody.Controls.Clear()
        TabRegistroCompras = New TabLG_RegistroCompras(periodo) With {
            .Dock = DockStyle.Fill
        }
        TabRegistroCompras.BringToFront()
        PanelBody.Controls.Add(TabRegistroCompras)
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.INVENTARIO_HISTORIAL_Formulario___, AutorizacionRolList) Then
            GradientPanel11.Visible = False
            PanelBody.Controls.Clear()
            TabLG_HistorialInventario = New TabLG_HistorialInventario With {
                .Dock = DockStyle.Fill
            }
            TabLG_HistorialInventario.BringToFront()
            PanelBody.Controls.Add(TabLG_HistorialInventario)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton27_Click(sender As Object, e As EventArgs) Handles ToolStripButton27.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.TRANSFERENCIAS_Formulario___, AutorizacionRolList) Then
            GradientPanel11.Visible = False
            PanelBody.Controls.Clear()
            TabLG_Transferencias = New TabLG_Transferencias(Me) With {
            .Dock = DockStyle.Fill
        }
            TabLG_Transferencias.BringToFront()
            PanelBody.Controls.Add(TabLG_Transferencias)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton28_Click(sender As Object, e As EventArgs) Handles ToolStripButton28.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.TRANSFERENCIAS_Formulario___, AutorizacionRolList) Then
            GradientPanel11.Visible = False
            PanelBody.Controls.Clear()
            TabLG_ConfirmarTransferencia = New TabLG_ConfirmarTransferencia(Me) With {
                .Dock = DockStyle.Fill
            }
            TabLG_ConfirmarTransferencia.BringToFront()
            PanelBody.Controls.Add(TabLG_ConfirmarTransferencia)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton19_Click(sender As Object, e As EventArgs)
        'Dim f As New frmNuevoAlmacen
        'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog(Me)
    End Sub

    Private Sub ToolStripButton30_Click(sender As Object, e As EventArgs)
        'Cursor = Cursors.WaitCursor
        ''If TabLG_Almacen.Visible = True Then
        'Dim r As Syncfusion.Grouping.Record = TabLG_Almacen.dgAlmacen.Table.CurrentRecord
        'If Not IsNothing(r) Then
        '    Dim f As New frmNuevoAlmacen
        '    f.UbicarDocumento(Val(r.GetValue("idalmacen")))
        '    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.ShowDialog()
        'End If
        ''End If
        'Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ALMACEN_Formulario___, AutorizacionRolList) Then
            GradientPanel11.Visible = False
            PanelBody.Controls.Clear()
            TabLG_Almacen = New TabLG_Almacen() With {
                .Dock = DockStyle.Fill
            }
            TabLG_Almacen.BringToFront()
            PanelBody.Controls.Add(TabLG_Almacen)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton19_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton19.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVA_NOTA_Formulario___, AutorizacionRolList) Then
            Dim f As New FormNotaDeCompra(Me)
            f.cboMesCompra.SelectedValue = cboMesCompra.SelectedValue
            f.cboMesCompra.Enabled = True
            f.StartPosition = FormStartPosition.CenterParent
            f.WindowState = FormWindowState.Normal
            ' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.ShowDialog()
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub ToolStripButton20_Click(sender As Object, e As EventArgs) Handles ToolStripButton20.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.REGISTRO_DE_NOTA_Formulario___, AutorizacionRolList) Then
            'GradientPanel11.Visible = False
            'PanelBody.Controls.Clear()
            'TabLG_RegistroNotasCompra = New TabLG_RegistroNotasCompra() With {
            '    .Dock = DockStyle.Fill
            '}
            'TabLG_RegistroNotasCompra.BringToFront()
            'PanelBody.Controls.Add(TabLG_RegistroNotasCompra)
            Dim f As New FormGestionNotasCompra
            f.Show()
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton30_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton30.Click
        Dim f As New FormMantenimientoComprasRapidas
        f.StartPosition = FormStartPosition.CenterParent
        f.Show()
    End Sub

    Private Sub CompraGeneralToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompraGeneralToolStripMenuItem.Click
        Try
            'Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            'fechaAnt = fechaAnt.AddMonths(-1)
            'Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            'If periodoAnteriorEstaCerrado = False Then
            '    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            '    Cursor = Cursors.Default
            '    Exit Sub
            'End If

            'Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            'If Not IsNothing(valida) Then
            '    If valida = True Then
            '        MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        Cursor = Cursors.Default
            '        Exit Sub
            '    End If
            'End If
            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVA_COMPRA_Formulario___, AutorizacionRolList) Then
                'Dim f As New FormCompras(Me) '
                'f.ComboBoxAdv2.Visible = False
                'f.CaptionLabels(0).Text = "Compra al crédito"
                'f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                'f.cboMesCompra.SelectedValue = cboMesCompra.SelectedValue
                'f.cboMesCompra.Enabled = True
                ''f.txtDia.Value = Nothing
                ''      f.txtDia.Value = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), DiaLaboral.Day)
                'f.StartPosition = FormStartPosition.CenterScreen
                'f.WindowState = FormWindowState.Normal
                'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                'f.Show(Me)


                Dim f As New FormCrearCompra(Me)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CompraServiviosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompraServiviosToolStripMenuItem.Click
        Try

            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVA_COMPRA_Formulario___, AutorizacionRolList) Then
                Dim f As New frmServicioPublico  '
                f.ComboBoxAdv2.Visible = False
                f.CaptionLabels(0).Text = "Servicios Publicos"
                f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text

                'f.txtDia.Value = Nothing
                '      f.txtDia.Value = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), DiaLaboral.Day)
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
    End Sub

    Private Sub HonorariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HonorariosToolStripMenuItem.Click
        Try

            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVA_COMPRA_Formulario___, AutorizacionRolList) Then
                Dim f As New frmReciboHonorarios '
                f.ComboBoxAdv2.Visible = False
                f.Label40.Visible = False
                f.CaptionLabels(0).Text = "Recibo Por Honorarios"
                f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text

                'f.txtDia.Value = Nothing
                '      f.txtDia.Value = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), DiaLaboral.Day)
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
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click

    End Sub
End Class