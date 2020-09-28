Imports Syncfusion.Windows.Forms.Tools
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports System.ComponentModel
Public Class frmMaestroModulosGimnasio

#Region "Attributes"
    Dim i As Integer = 0
    Public Property LightBox As New HeliosLogin
    Public empresaPeriodoSA As New empresaCierreMensualSA
    Public Property dt As New DataTable
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0

    Protected Friend conteoEnTransito As Integer = 0
    Protected Friend conteoStockMinimo As Integer = 0
    Protected Friend conteoArticulosSinPrecio As Decimal = 0
    Protected Friend conteoTransArticulosPendientes As Decimal = 0
    Protected Friend conteoTransArticulosConfirmados As Decimal = 0
    Protected Friend totalSA As New TotalesAlmacenSA
    Protected Friend frmNuevaMembresia As frmMaestroMembresia
    Protected Friend frmRegistroClienteMembresia As frmRegistroClienteMembresia
    Protected Friend frmCobroDirectoCliente As frmCobroDirectoCliente
    Protected Friend frmRegistroAsistenciaSocios As frmRegistroAsistenciaSocios
    Protected Friend frmTrainersMaster As frmTrainersMaster
    Protected Friend frmActividadesGymMaestro As frmActividadesGymMaestro

#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        splashControl1.SplashControlPanel.BorderType = SplashBorderType.None
        splashControl1.ShowDialogSplash(Me)
        splashControl1.AutoMode = False
        splashControl1.HostForm = Me
        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid(dgvLogistica)
        FormatoGrid(dgvComercial)
        FormatoGrid(dgvFinanzas)
        LoadModulosPOS()
    End Sub
#End Region

#Region "Methods"
    Protected Sub PararCaptura()
        If captura IsNot Nothing Then
            Try
                captura.StopCapture()
            Catch ex As Exception
                MessageBox.Show("no se pudo detener la captura")
            End Try
        End If
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


    End Sub

    Public Function GetInventarioEnAlertaConteo(be As totalesAlmacen) As Integer
        Return totalSA.GetAlertaIventarioMinimoConteo(be)
    End Function

    Private Sub GetAlertas()
        conteoEnTransito = GetCountExistenciaTransito()
        conteoStockMinimo = GetInventarioEnAlertaConteo(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
        conteoArticulosSinPrecio = ConteoProductosSinPrecio()
    End Sub

    Private Sub GetAlertaCompleted()
        If dgvLogistica.Table.Records.Count > 0 Then
            dgvLogistica.Table.Records(3).SetValue("info", conteoEnTransito)
            dgvLogistica.Table.Records(2).SetValue("info", conteoTransArticulosConfirmados)
            dgvLogistica.Table.Records(4).SetValue("info", conteoTransArticulosPendientes)
        End If
    End Sub


    Sub LoadModulosPOS()
        'Logistica
        dt = New DataTable
        dt.Columns.Add("detalle")
        dt.Columns.Add("info")
        dt.Rows.Add("Compras")
        dt.Rows.Add("Movimientos de almacén (entradas, sálidas)")
        'dt.Rows.Add("Otros ingresos a almacén")
        'dt.Rows.Add("Otros salidas de almacén")
        dt.Rows.Add("transferencias a otros almacenes", "0")
        dt.Rows.Add("Recep. de inventario en tránsito por compras", "0")
        dt.Rows.Add("Recep. de inventario en tránsito por transferencia", "0")
        dt.Rows.Add("Kardex")
        dt.Rows.Add("Inventario Valorizado")
        dt.Rows.Add("Lista de precios - membresías")
        dt.Rows.Add("Lista de precios - inventario")
        dt.Rows.Add("Lista de precios - servicios")
        dgvLogistica.DataSource = dt
        dgvLogistica.TableDescriptor.Columns("detalle").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvLogistica.TableDescriptor.Columns("detalle").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        dgvLogistica.TableDescriptor.Columns("detalle").Appearance.AnyCell.TextColor = Color.Black

        'Comercial
        dt = New DataTable
        dt.Columns.Add("detalle")
        dt.Rows.Add("Registro de ventas")
        dt.Rows.Add("Pre venta")
        dt.Rows.Add("Venta membresías")
        dt.Rows.Add("Caja centralizada")
        dt.Rows.Add("Gestion de membresías")
        dt.Rows.Add("Rentabilidad de membresías")

        dgvComercial.DataSource = dt
        dgvComercial.TableDescriptor.Columns("detalle").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvComercial.TableDescriptor.Columns("detalle").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        dgvComercial.TableDescriptor.Columns("detalle").Appearance.AnyCell.TextColor = Color.Black

        'Finanzas
        dt = New DataTable
        dt.Columns.Add("detalle")
        'dt.Rows.Add("Otras ingresos a caja")
        'dt.Rows.Add("Otras salidas de caja")
        dt.Rows.Add("Registro Otras Entradas a caja")
        dt.Rows.Add("Registro Otras Salidas de caja")
        dt.Rows.Add("Movimientos cuentas financieras")
        dt.Rows.Add("Cuentas por cobrar")
        dt.Rows.Add("Anticipos recibidos")
        dt.Rows.Add("Reclamaciones de clientes")
        dt.Rows.Add("Compensaciones")

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

    Sub Inicio()
        usuario = New AutenticacionUsuario
        usuario.CustomUsuario = New Usuario
        Dim LightBox As New HeliosLogin
        LightBox.SetBounds(Me.Left, Me.Top, Me.ClientRectangle.Width, Me.ClientRectangle.Height)
        LightBox.Owner = Me
        LightBox.ShowDialog()

        If Not IsNothing(usuario) Then
            ' SplitButton1.BackColor = Color.FromArgb(92, 184, 92)
            SplitButton1.BackColor = Color.FromArgb(213, 79, 185)
            Panel3.Enabled = True
            SplitButton1.Text = usuario.Alias
            Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
                Case 1 ' ADMINISTRADOR

                    Dim init As New frmInicioEmpresa
                    init.StartPosition = FormStartPosition.CenterParent
                    init.ShowDialog()

                    'CargarConfiguracionInicio(Gempresas.IdEmpresaRuc)
                    '     CoNteoNotifi()
                Case 2 ' USUARI BASICO => SOLO ACCESO AL PUNTP DE VENTA
                    CargarConfiguracionInicioUsuariosDeCaja(Gempresas.IdEmpresaRuc)

                Case 3, 4 ' USUARIO PUNTO DE VENTA MANJEJO DE EFECTIVO
                    CargarConfiguracionInicioUsuariosDeCaja(Gempresas.IdEmpresaRuc)
            End Select

            Label24.Text = GEstableciento.NombreEstablecimiento

            Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
                Case 1
                    Label15.Text = usuario.CustomUsuario.Full_Name & "-" & "Administrador POS"
                Case 2
                    Label15.Text = usuario.CustomUsuario.Full_Name & "-" & "Atención (Pre-venta)"
                Case 3
                    Label15.Text = usuario.CustomUsuario.Full_Name & "-" & "Cajero (Caja centralizada)"
                Case 4
                    Label15.Text = usuario.CustomUsuario.Full_Name & "-" & "Cajero (Venta Directa)"

            End Select

            If bg.IsBusy <> True Then
                ' Start the asynchronous operation.
                bg.RunWorkerAsync()
            End If
        Else
            '  SplitButton1.BackColor = Color.FromArgb(22, 165, 220)
            SplitButton1.BackColor = Color.FromArgb(213, 79, 185)
            SplitButton1.Text = "Usuario"
            Panel3.Enabled = False
            MessageBox.Show("Usuario o clave incorrectos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'MatarProceso("SMSvcHost.exe")
            'Application.ExitThread()
            'Me.Close()
        End If
    End Sub

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

            Me.dgvComercial.TableControl.Selections.Clear()
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
        Cursor = Cursors.WaitCursor
        With frmInformacionGeneral
            .lblPerido.Text = PeriodoGeneral
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub Panel2_Click(sender As Object, e As EventArgs) Handles Panel2.Click
        'Dim f As New frmMaestroSistemaUsers
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.Show()
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
            Dim F As New frmTableroPorDia
            'Dim f As New frmDashBoard
            F.StartPosition = FormStartPosition.CenterParent
            F.ShowDialog()
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.CONFIGURACION_DE_INICIO__, AutorizacionRolList) Then
            Dim f As New frmInicioEmpresa
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            Label5.Text = "Período: " & PeriodoGeneral
            lblEstablecimiento.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
            Label24.Text = GEstableciento.NombreEstablecimiento

            If bg.IsBusy <> True Then
                ' Start the asynchronous operation.
                bg.RunWorkerAsync()
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SplitButton1_DropDowItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles SplitButton1.DropDowItemClicked
        Try
            Select Case e.ClickedItem.Text
                Case "Iniciar Sesion"
                    Inicio()
                Case "Cerrar Sesion"
                    '    SplitButton1.BackColor = Color.FromArgb(22, 165, 220)
                    SplitButton1.BackColor = Color.FromArgb(213, 79, 185)
                    SplitButton1.Text = "Usuario"
                    Panel3.Enabled = False
                    Inicio()

            End Select
            lblEstablecimiento.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
            Label5.Text = PeriodoGeneral
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Inicio()
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        i += 1000
        If i = 1000 Then
            i = 0
            Timer1.Stop()

            LightBox = New HeliosLogin

            LightBox.SetBounds(Me.Left, Me.Top, Me.ClientRectangle.Width, Me.ClientRectangle.Height)
            LightBox.Owner = Me
            LightBox.ShowDialog()

            If Not IsNothing(LightBox.Tag) Then
                If Not IsNothing(usuario) Then
                    '   SplitButton1.BackColor = Color.FromArgb(92, 184, 92)
                    SplitButton1.BackColor = Color.FromArgb(213, 79, 185)
                    Panel3.Enabled = True
                    SplitButton1.Text = usuario.Alias
                    Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
                        Case 1 ' ADMINISTRADOR
                            Dim fSel As New frmInicioEmpresa
                            fSel.StartPosition = FormStartPosition.CenterParent
                            fSel.ShowDialog()
                            Label5.Text = "Período: " & PeriodoGeneral
                            lblEstablecimiento.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
                            Label24.Text = GEstableciento.NombreEstablecimiento
                        Case 2 ' USUARI BASICO => SOLO ACCESO AL PUNTP DE VENTA'
                            CargarConfiguracionInicioUsuariosDeCaja("20392657020")
                            Label5.Text = "Período: " & PeriodoGeneral
                            lblEstablecimiento.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
                            Label24.Text = GEstableciento.NombreEstablecimiento
                        Case 3, 4 ' USUARIO PUNTO DE VENTA MANJEJO DE EFECTIVO

                            Dim fSel As New frmInicioEmpresa
                            fSel.StartPosition = FormStartPosition.CenterParent
                            fSel.ShowDialog()
                            Label5.Text = "Período: " & PeriodoGeneral
                            lblEstablecimiento.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
                            Label24.Text = GEstableciento.NombreEstablecimiento
                            'Label5.Text = "Período: " & PeriodoGeneral
                    End Select
                    Timer2.Enabled = True
                End If
                Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
                    Case 1
                        Label15.Text = usuario.CustomUsuario.Full_Name & "-" & "Administrador POS"
                    Case 2
                        Label15.Text = usuario.CustomUsuario.Full_Name & "-" & "Atención (Pre-venta)"
                    Case 3
                        Label15.Text = usuario.CustomUsuario.Full_Name & "-" & "Cajero (Caja centralizada)"
                    Case 4
                        Label15.Text = usuario.CustomUsuario.Full_Name & "-" & "Cajero (Venta Directa)"

                End Select

                If bg.IsBusy <> True Then
                    ' Start the asynchronous operation.
                    bg.RunWorkerAsync()
                End If

                If Entidadmembresia_GymSA.GetMembresiasPorStatusMembresiaXfechaConteo(New Entidadmembresia_Gym With
                                                                                      {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                      .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                      .statusMembresia = Gimnasio_EstadoMembresia.Activo,
                                                                                      .fechaVcto = Date.Now}) > 0 Then

                    Dim f As New frmConfirmacionMembresiasVencidasNow(Date.Now.Date)
                    f.StartPosition = FormStartPosition.CenterParent
                    f.Show()
                End If



            Else
                'MessageBox.Show("Verificar si el usuario o clave es correcta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'Inicio()

                'Exit Sub
                MatarProceso("Helios.Cont.Presentation.WinForm")
                MatarProceso("SMSvcHost.exe")
                Application.ExitThread()
                Close()
            End If


            'Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
            '    Case 1 ' ADMINISTRADOR
            '        Dim fSel As New frmInicioEmpresa
            '        fSel.StartPosition = FormStartPosition.CenterParent
            '        fSel.ShowDialog()
            '        Label5.Text = "Período: " & PeriodoGeneral
            '        lblEmpresa.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
            '        'AlertasVenta()
            '        'AlertaMovAlmacen()
            '        'GetInventarioEnAlertaConteo(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})

            '    Case 2 ' USUARI BASICO => SOLO ACCESO AL PUNTP DE VENTA

            '    Case 3 ' USUARIO PUNTO DE VENTA MANJEJO DE EFECTIVO
            '        Label5.Text = "Período: " & PeriodoGeneral
            '        'lblEmpresa.Text = Gempresas.NomEmpresa & " - " & "20569026602"
            'End Select

            General.Constantes.InitHuella()
        End If
    End Sub

    Private Sub frmGimansio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Dim r As Record = dgvLogistica.Table.CurrentRecord
        If Not IsNothing(r) Then
            Select Case r.GetValue("detalle")
                Case "Compras"
                    Dim f As New frmComprasMaestro()
                    f.ComprasAlContadoToolStripMenuItem.Visible = False
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                Case "Otros ingresos a almacén"
                    Cursor = Cursors.WaitCursor
                    Try
                        Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
                        If Not IsNothing(valida) Then
                            If valida = True Then
                                MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            End If
                        End If
                        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.MOVIMIENTO_INVENTARIO_OTRAS_ENTRADAS_Otros_Formulario__, AutorizacionRolList) Then
                            With frmMovOtrasEntradas
                                .lblPerido.Text = PeriodoGeneral
                                .cboOperacion.SelectedValue = "0000"
                                .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                                .StartPosition = FormStartPosition.CenterParent
                                .ShowDialog()
                            End With
                        Else
                            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                    Cursor = Cursors.Default

                Case "Otros salidas de almacén"
                    Cursor = Cursors.WaitCursor
                    Try
                        Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
                        If Not IsNothing(valida) Then
                            If valida = True Then
                                MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            End If
                        End If
                        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.MOVIMIENTO_INVENTARIO_OTRAS_SALIDAS_Otros_Formulario__, AutorizacionRolList) Then
                            With frmOtrasSalidasDeAlmacen
                                .lblPerido.Text = PeriodoGeneral
                                .cboOperacion.SelectedValue = "0001"
                                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                                .StartPosition = FormStartPosition.CenterParent
                                .ShowDialog()
                            End With
                        Else
                            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                    Cursor = Cursors.Default

                Case "Recep. de inventario en tránsito por compras"
                    Dim f As New frmExistenciasEnTransito()
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                Case "Recep. de inventario en tránsito por transferencia"
                    Dim f As New frmEntregaArticulosXconfirmar()
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                Case "transferencias a otros almacenes"
                    Dim f As New frmMovimientoTransferencia()
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                Case "Kardex"
                    Dim f As New frmModeloKardex()
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                Case "Inventario Valorizado"
                    Dim f As New frmInventarioValorizado()
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                Case "Lista de precios - inventario"
                    Dim f As New frmExistenciaPrecios()
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                Case "Lista de precios - servicios"
                    Dim f As New frmServiciosPrecios()
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                Case "Lista de precios - membresías"
                    frmNuevaMembresia = New frmMaestroMembresia
                    frmNuevaMembresia.StartPosition = FormStartPosition.CenterParent
                    frmNuevaMembresia.ShowDialog()

                Case "Movimientos de almacén (entradas, sálidas)"
                    Dim f As New frmMovimientosInventario
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
            End Select

        End If
    End Sub

    Private Sub dgvComercial_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvComercial.TableControlCellDoubleClick
        Dim r As Record = dgvComercial.Table.CurrentRecord
        If Not IsNothing(r) Then
            Select Case r.GetValue("detalle")
                Case "Rentabilidad de membresías"
                    Dim f As New frmRentabilidadMembresiaByMes
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                Case "Venta membresías"

                    Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
                        Case 3, 4
                            frmRegistroClienteMembresia = New frmRegistroClienteMembresia
                            frmRegistroClienteMembresia.txtPeriodo.Value = New Date(AnioGeneral, CInt(MesGeneral), 1)
                            frmRegistroClienteMembresia.StartPosition = FormStartPosition.CenterParent
                            frmRegistroClienteMembresia.ShowDialog()
                        Case Else
                            MessageBox.Show("Debe iniciar una caja", "Iniciar sesión de caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Select

                Case "Pre venta"
                    Try
                        Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
                        If Not IsNothing(valida) Then
                            If valida = True Then
                                MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            End If
                        End If

                        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.PRE_VENTA_Formulario__, AutorizacionRolList) Then
                            Dim f As New frmVentaPV
                            f.lblPerido.Text = MesGeneral & "/" & AnioGeneral
                            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                            f.WindowState = FormWindowState.Maximized
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()
                        Else
                            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try

                Case "Caja centralizada"
                    If AutorizacionRolSA.TienePermiso(AsegurablesSistema.REGISTRO_PEDIDOS__, AutorizacionRolList) Then
                        Dim f As New frmPedidoPendiente
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                    Else
                        MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Case "Gestion de membresías"
                    Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
                    If Not IsNothing(valida) Then
                        If valida = True Then
                            MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    End If

                    Dim f As New frmMembresiasClienteMaestro
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                Case "Registro de ventas"
                    Dim f As New frmVentasMaestro
                    f.ToolStripDropDownButton4.Visible = False
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
            End Select
        End If
    End Sub

    Private Sub dgvFinanzas_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvFinanzas.TableControlCellDoubleClick
        Dim r As Record = dgvFinanzas.Table.CurrentRecord
        If Not IsNothing(r) Then
            Select Case r.GetValue("detalle")
                Case "Otras ingresos a caja"
                    Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
                    If Not IsNothing(valida) Then
                        If valida = True Then
                            MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    End If
                    Dim f As New frmEntradaSalidaCaja(StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO)
                    f.txtPeriodo.Value = New Date(AnioGeneral, CInt(MesGeneral), Date.Now.Day)
                    f.lblMovimiento.Tag = "OEC"
                    f.lblMovimiento.Text = "OTRAS ENTRADAS A CAJA"
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.txtTipoCambio.Value = TmpTipoCambio
                    f.cboMesCompra.SelectedValue = MesGeneral
                    f.cboMesCompra.Enabled = True
                    f.TxtDia.Text = ""
                    f.txtHora.Value = New Date(AnioGeneral, CInt(MesGeneral), Date.Now.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                Case "Otras salidas de caja"
                    Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
                    If Not IsNothing(valida) Then
                        If valida = True Then
                            MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    End If
                    Dim f As New frmEntradaSalidaCaja(StatusTipoOperacion.OTRAS_SALIDAS_DE_DINERO)
                    f.txtPeriodo.Value = New Date(AnioGeneral, CInt(MesGeneral), Date.Now.Day)
                    f.lblMovimiento.Tag = "OSC"
                    f.lblMovimiento.Text = "OTRAS SALIDAS DE CAJA"
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.txtTipoCambio.Value = TmpTipoCambio
                    f.cboMesCompra.SelectedValue = MesGeneral
                    f.cboMesCompra.Enabled = True
                    f.TxtDia.Text = ""
                    f.txtHora.Value = New Date(AnioGeneral, CInt(MesGeneral), Date.Now.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()


                Case "Cuentas por cobrar"
                    Dim f As New frmFinanzasCuentasPorCobrar
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                Case "Anticipos recibidos"

                Case "Reclamaciones de clientes"
                    Dim f As New frmReclamaciones
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                Case "Compensaciones"

                Case "Registro Otras Entradas a caja"
                    Dim f As New frmOtrasEntradasCaja
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                Case "Registro Otras Salidas de caja"
                    Dim f As New frmOtrasSalidasCaja
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                Case "Movimientos cuentas financieras"
                    Dim f As New frmMovimientosMN
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

            End Select

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
    End Sub

    Private Sub bg_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bg.RunWorkerCompleted
        GetAlertaCompleted()
    End Sub

    Private Sub frmMaestroModulosGimnasio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBoxAdv.Show("S O F T - P A C K, ¿Desea salir?", "Salir del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            pararcaptura
            TerminarProceso("Helios.Cont.Presentation.WinForm")
            TerminarProceso("SMSvcHost.exe")
            Application.ExitThread()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Dim f As New frmMembresiasPorVencer
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Try
            frmCobroDirectoCliente = New frmCobroDirectoCliente
            frmCobroDirectoCliente.StartPosition = FormStartPosition.CenterParent
            frmCobroDirectoCliente.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        frmRegistroAsistenciaSocios = New frmRegistroAsistenciaSocios
        frmRegistroAsistenciaSocios.StartPosition = FormStartPosition.CenterParent
        frmRegistroAsistenciaSocios.ShowDialog()
    End Sub

    Private Sub SplitButton1_Click(sender As Object, e As EventArgs) Handles SplitButton1.Click

    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        frmTrainersMaster = New frmTrainersMaster
        frmTrainersMaster.StartPosition = FormStartPosition.CenterParent
        frmTrainersMaster.ShowDialog()
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        frmActividadesGymMaestro = New frmActividadesGymMaestro
        frmActividadesGymMaestro.StartPosition = FormStartPosition.CenterParent
        frmActividadesGymMaestro.ShowDialog()
    End Sub
#End Region

End Class