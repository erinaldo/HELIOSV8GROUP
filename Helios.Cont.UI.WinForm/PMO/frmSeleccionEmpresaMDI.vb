Imports Helios.Cont.Business.Entity
Imports Helios.General

'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms


Imports Syncfusion.Windows.Forms.Tools
Public Class frmSeleccionEmpresaMDI


    Public Shared AutenticacionUsuario As AutenticacionUsuario
    Public Shared AutorizacionRolList As List(Of AutorizacionRol)



    Public Sub New()
        InitializeComponent()
        
        ObtenerTipoCambioMax()
        GetControlesList()


    End Sub

#Region "Métodos"
    Private Sub Grabar()
        Dim config As New configuracionInicio
        Dim existe As New configuracionInicio
        Dim configsa As New ConfiguracionInicioSA
        Dim tipcambsa As New TipoCambioSunatV2
        Dim tipcambsaSA As New tipoCambioSA
        Dim existe2 As New TipoCambioSunatV2
        With config

            Gempresas = New GEmpresa
            Gempresas.IdEmpresaRuc = cboEmpresa.SelectedValue
            Gempresas.NomEmpresa = cboEmpresa.Text

            .idEmpresa = cboEmpresa.SelectedValue
            .idCentroCosto = cboEstablecimiento.SelectedValue
            .idalmacenVenta = Nothing ' CboAlmacen.SelectedValue
            .montoMaximo = txtmontomaximo.Value
            .anio = Me.MonthPeriodo.Value.Year
            .mes = String.Format("{0:00}", Convert.ToInt32(Me.MonthPeriodo.Value.Month))
            .dia = New DateTime(Me.MonthPeriodo.Value.Year, Me.MonthPeriodo.Value.Month, Me.MonthPeriodo.Value.Day)

            .periodo = String.Format("{0:00}", Convert.ToInt32(Me.MonthPeriodo.Value.Month)) & "/" & Me.MonthPeriodo.Value.Year
            .tipocambio = nudTipoCambio.Value
            .iva = txtIva.Value
            .tipoCambioTransacCompra = nudTCTransaccionCompra.Value
            .tipoCambioTransacVenta = nudTCTransaccionVenta.Value

            GEstableciento = New GEstablecimiento
            GEstableciento.IdEstablecimiento = cboEstablecimiento.SelectedValue
            GEstableciento.NombreEstablecimiento = cboEstablecimiento.Text
            TmpIdAlmacen = Nothing
            TmpNombreAlmacen = Nothing
            TmpTipoCambioTransaccionCompra = nudTCTransaccionCompra.Value
            TmpTipoCambioTransaccionVenta = nudTCTransaccionVenta.Value
            AnioGeneral = cboAnio.Text
            MesGeneral = String.Format("{0:00}", Convert.ToInt32(Me.MonthPeriodo.Value.Month))
            DiaLaboral = New DateTime(Me.MonthPeriodo.Value.Year, Me.MonthPeriodo.Value.Month, Me.MonthPeriodo.Value.Day)
            PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(Me.MonthPeriodo.Value.Month)) & "/" & Me.MonthPeriodo.Value.Year

            TmpTipoCambio = nudTipoCambio.Value
            TmpIGV = txtIva.Value
            MontoMaximoCliente = txtmontomaximo.Value

        End With
        configsa.EditarConfigInicio(config)
        Me.Tag = "Gravado"
        Dispose()
    End Sub

    Public Sub ObtenerConfiguracionPorEmpresa(strIdEmpresa As String)
        Dim configSA As New ConfiguracionInicioSA
        Dim config As New configuracionInicio
        Dim estableSA As New establecimientoSA
        Dim almacenSA As New almacenSA

        config = configSA.ObtenerConfigXempresa(strIdEmpresa, GEstableciento.IdEstablecimiento)
        If Not IsNothing(config) Then
            With config
                cboEstablecimiento.SelectedValue = .idCentroCosto
                cboAnio.Text = .anio
                Me.MonthPeriodo.Value = New Date(.anio, .mes, .dia.Value.Day)
                nudTipoCambio.Value = .tipocambio

                nudTCTransaccionCompra.Value = CDec(.tipoCambioTransacCompra.GetValueOrDefault)
                nudTCTransaccionVenta.Value = CDec(.tipoCambioTransacVenta.GetValueOrDefault)

                txtIva.Value = .iva

                '------------------------------------------------------------------------------

                GEstableciento = New GEstablecimiento
                GEstableciento.IdEstablecimiento = .idCentroCosto
                GEstableciento.NombreEstablecimiento = estableSA.UbicaEstablecimientoPorID(.idCentroCosto).nombre

                '                TmpIdAlmacen = .idalmacenVenta
                'TmpNombreAlmacen = almacenSA.GetUbicar_almacenPorID(.idalmacenVenta).descripcionAlmacen
                AnioGeneral = .anio
                MesGeneral = .mes
                DiaLaboral = .dia
                PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(.mes)) & "/" & .anio
                TmpTipoCambio = .tipocambio
                TmpIGV = .iva
                TmpTipoIVA = .tipoIva
                TmpRetencion4 = .retencion4ta.GetValueOrDefault
                MontoMaximoCliente = .montoMaximo
                txtmontomaximo.Value = .montoMaximo
                TmpTipoCambioTransaccionCompra = .tipoCambioTransacCompra.GetValueOrDefault
                TmpTipoCambioTransaccionVenta = .tipoCambioTransacVenta.GetValueOrDefault


            End With
        Else
            '   MessageBoxAdv.Show("No hay una configuración existente!", "Atención!", MessageBoxButtons.OK)
        End If
    End Sub

    Sub getEstablecimiento(strIdEmpresa As String)
        Dim estableSA As New establecimientoSA
        cboEstablecimiento.DataSource = estableSA.ObtenerListaEstablecimientos(strIdEmpresa)
        cboEstablecimiento.DisplayMember = "nombre"
        cboEstablecimiento.ValueMember = "idCentroCosto"
    End Sub

    Sub GetControlesList()
        Dim periodoSA As New empresaPeriodoSA

        cboAnio.DataSource = periodoSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"


    End Sub

    Private Sub ObtenerTipoCambioMax()
        Dim tipoCambioSA As New tipoCambioSA
        Dim tipoCambio As New tipoCambio

        tipoCambio = tipoCambioSA.GetListaTipoCambioMaxFecha(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        If (tipoCambio.compra.GetValueOrDefault > 0) Then
            With tipoCambio
                txtFechaIgv.Value = .fechaIgv
                'txtFechaIgv.Value = DateTime.Now
                nudTipoCambioCompra.Value = .compra
                nudTipoCambio.Value = .venta
            End With
        Else
            txtFechaIgv.Value = DateTime.Now
            nudTipoCambioCompra.Value = 0
            nudTipoCambio.Value = 0
        End If
    End Sub
#End Region

    Private Sub frmSeleccionEmpresaMDI_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated

    End Sub

    Private Sub frmSeleccionEmpresaMDI_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If MessageBoxAdv.Show("S O F T - P A C K, ¿Desea salir?", "Salir del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        '    MatarProceso("SMSvcHost.exe")
        '    Application.ExitThread()
        'Else
        'e.Cancel = True
        e.Cancel = True
        '  But hide it from the user.
        Me.Hide()
        'End If
    End Sub

    'Public Overloads Sub showm()
    '    Dim a As New SplashWindow
    '    a.ShowDialog()
    '    Application.DoEvents()
    'End Sub

    Sub Init(idEmpresa As String)
        Dim estable As New centrocosto
        Dim estableSA As New establecimientoSA
        Gempresas = GEmpresa.InstanceSingle()
        Gempresas.Clear()

        Dim empresaSA As New empresaSA
        With empresaSA.UbicarEmpresaRuc(idEmpresa)
            Gempresas.IdEmpresaRuc = .idEmpresa
            Gempresas.NomEmpresa = .razonSocial
            Gempresas.InicioOpeaciones = .inicioOperacion
        End With

        'Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
        '    Case 2

        '    Case Else
        '        Dim f As New frmInicioEmpresa
        '        f.StartPosition = FormStartPosition.CenterParent
        '        f.ShowDialog()

        ' ShowChildForm(frmMaestroModulos.LoadStyle.OnLoad)
        ' ShowChildFormPos_0(frmPos_0.LoadStyle.OnLoad)
        'Dim f As New frmPos_0
        'f.StartPosition = FormStartPosition.CenterScreen
        ''  f.TopMost = True
        'f.Show()
        Hide()
        'End Select
    End Sub

    Sub InitCaja(idEmpresa As String)
        Dim estable As New centrocosto
        Dim estableSA As New establecimientoSA
        Gempresas = GEmpresa.InstanceSingle()
        Gempresas.Clear()

        Dim empresaSA As New empresaSA
        With empresaSA.UbicarEmpresaRuc(idEmpresa)
            Gempresas.IdEmpresaRuc = .idEmpresa
            Gempresas.NomEmpresa = .razonSocial
        End With

        'ShowChildForm(frmMaestroModulos.LoadStyle.OnLoad)
        Hide()
    End Sub

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
                TmpIdAlmacen = .idalmacenVenta
                TmpNombreAlmacen = almaceSa.GetUbicar_almacenPorID(.idalmacenVenta).descripcionAlmacen
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

    Private Sub frmSeleccionEmpresaMDI_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim empresaSA = New empresaSA
        Dim empresa As New List(Of empresa)

        'Dim f1 As New HeliosLogin
        'f1.ShowDialog(Me)
        'f1.Close()

        'HeliosLogin.ShowDialog(Me)
        'If UserAccesoPermitido = True Then

        Me.Cursor = Cursors.WaitCursor
        empresa = empresaSA.ObtenerListaEmpresas()
        'Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
        '    Case 1
        '        If empresa.Count = 1 Then
        '            Init(empresa(0).idEmpresa)
        '        Else
        cboEmpresa.DisplayMember = "razonSocial"
        cboEmpresa.ValueMember = "idEmpresa"
        cboEmpresa.DataSource = empresa
        '        End If
        '    Case 2
        '        If empresa.Count = 1 Then
        'Init(empresa(0).idEmpresa)
        '            CargarConfiguracionInicioUsuariosDeCaja(Gempresas.IdEmpresaRuc)

        '            Dim f As New frmMasterGeneralVentas()
        '            f.StartPosition = FormStartPosition.CenterParent
        '            f.WindowState = FormWindowState.Maximized
        '            f.Show(Me)
        '            Me.Hide()
        '        End If
        '    Case 3
        '        If empresa.Count = 1 Then
        '            InitCaja(empresa(0).idEmpresa)
        '        Else
        '            lsvEmpresas.Items.Clear()
        '            For Each i In empresaSA.ObtenerListaEmpresas()
        '                Dim n As New ListViewItem(i.idEmpresa)
        '                n.SubItems.Add(i.razonSocial)
        '                lsvEmpresas.Items.Add(n)
        '            Next
        '        End If
        'End Select


        Me.Cursor = Cursors.Arrow
        'Else
        '    SALIR_SISTEMA()
        'End If

    End Sub

#Region "Salir"
    Sub SALIR_SISTEMA()
        MatarProceso("SMSvcHost.exe")
        Application.ExitThread()
    End Sub

    Private Function MatarProceso(ByVal StrNombreProceso As String, _
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
#End Region

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'If lsvEmpresas.SelectedItems.Count > 0 Then
        '    If lstAños.SelectedItems.Count > 0 Then
        '        With MDIPrincipal
        '            cIDUsuario = "44924568" ' txtDni.Text.Trim
        '            cNombreusuario = "DEFAULT" ' txtDni.Text.Trim
        '            CEmpresa = lsvEmpresas.SelectedItems(0).SubItems(0).Text
        '            CNombreEmpresa = lsvEmpresas.SelectedItems(0).SubItems(1).Text
        '            .lblPeriodo.Text = "0000"  ' cAnioPeriodo
        '            .lblNomEmpresa.Text = CNombreEmpresa ' lsvEmpresas.SelectedItems(0).SubItems(1).Text
        '            .lblRuc.Text = CEmpresa  ' lsvEmpresas.SelectedItems(0).SubItems(2).Text
        '            .lblDomicilio.Text = "" ' lsvEmpresas.SelectedItems(0).SubItems(3).Text
        '            .StartPosition = FormStartPosition.CenterScreen
        '            .Show()
        '            Hide()
        '        End With
        '    End If
        'Else

        '    MsgBox("Debe seleccionar una empresa, " & vbCrLf & "para empezar a trabajar.", MsgBoxStyle.Information, "Atención!")
        '    lsvEmpresas.Focus()
        '    '   lsvEmpresas.SelectedItems(0).Selected = True
        'End If



    End Sub

    Private Sub lsvEmpresas_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'Dim estable As New centrocosto
        'Dim estableSA As New establecimientoSA
        'Gempresas = GEmpresa.InstanceSingle()
        'Gempresas.Clear()
        'If lsvEmpresas.SelectedItems.Count > 0 Then

        '    Dim empresaSA As New empresaSA
        '    With empresaSA.UbicarEmpresaRuc(lsvEmpresas.SelectedItems(0).SubItems(0).Text)
        '        Gempresas.IdEmpresaRuc = .idEmpresa
        '        Gempresas.NomEmpresa = .razonSocial
        '    End With

        '    'With frmPMO
        '    '    .lblDescripcionEmpresa.Title = Gempresas.IdEmpresaRuc & ", " & Gempresas.NomEmpresa
        '    '    .StartPosition = FormStartPosition.CenterScreen

        '    'estable = estableSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc).FirstOrDefault
        '    'If Not IsNothing(estable) Then
        '    '    ' .lblEStablecimiento.Title = estable.nombre
        '    '    GEstableciento = GEstablecimiento.InstanceSingle()
        '    '    GEstableciento.Clear()
        '    '    With estableSA.UbicaEstablecimientoPorID(estable.idCentroCosto)
        '    '        GEstableciento.IdEstablecimiento = .idCentroCosto
        '    '        GEstableciento.NombreEstablecimiento = .nombre
        '    '        GEstableciento.TipoEstablecimiento = .TipoEstab
        '    '        GEstableciento.Ubigeo = .ubigeo
        '    '    End With
        '    'Else
        '    '    '  .lblEStablecimiento.Title = "Seleccionar establecimiento?"
        '    'End If

        '    '    Select Case cboTipo.Text
        '    '        Case "CONTABILIDAD"
        '    '            .lblProyecto.Visible = False
        '    '            .QToolBar1.Visible = True
        '    '            .LoadCaja()
        '    '            ModuloAppx = ModuloSistema.CONTABILIDAD
        '    '        Case "PUNTO DE VENTA"
        '    '            .lblProyecto.Visible = False
        '    '            .QToolBar1.Visible = True
        '    '            .LoadPuntoVenta()
        '    '            ModuloAppx = ModuloSistema.PUNTO_DE_VENTA
        '    '        Case "CAJA"
        '    '            .lblProyecto.Visible = False
        '    '            .QToolBar1.Visible = True
        '    '            .LoadTree()
        '    '            ModuloAppx = ModuloSistema.CAJA
        '    '        Case "PLANEAMIENTO"
        '    '            .lblProyecto.Visible = True
        '    '            .QToolBar1.Visible = True
        '    '            .LoadProcesosTree("2")
        '    '            ModuloAppx = ModuloSistema.PLANEAMIENTO
        '    '    End Select
        '    '    .Show()
        '    '    Hide()
        '    'End With

        '    'Dim FormPrincipal = New frmMasterpmo
        '    'FormPrincipal.WindowState = FormWindowState.Maximized
        '    'FormPrincipal.Show()

        '    ShowChildForm(frmMaestroModulos.LoadStyle.OnLoad)
        '    'Dim FormPrincipal = New frmMaestroModulos
        '    'FormPrincipal.WindowState = FormWindowState.Maximized
        '    'FormPrincipal.Show()
        '    Hide()
        'Else

        '    MsgBox("Debe seleccionar una empresa, " & vbCrLf & "para empezar a trabajar.", MsgBoxStyle.Information, "Atención!")
        '    lsvEmpresas.Focus()
        '    '   lsvEmpresas.SelectedItems(0).Selected = True
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    'Private Sub ShowChildForm(ls As frmMaestroModulos.LoadStyle)
    '    Dim frm As New frmMaestroModulos(ls)
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.ShowDialog()
    'End Sub

    'Private Sub ShowChildFormPos_0(ls As frmPos_0.LoadStyle)
    '    Dim frm As New frmPos_0(ls)
    '    frm.ShowDialog()
    'End Sub

    Private Sub btnMostrarAll_Click(sender As System.Object, e As System.EventArgs) Handles btnMostrarAll.Click
        '(Hide())
        Try
            Dispose()
            Global.System.Windows.Forms.Application.Exit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    '    cerrarProceso("regedit") ' Para cerrar el editor del registro
    'cerrarProceso("taskmgr") 'Para cerrar el administrador de tareas de Windows
    Private Sub cerrarProceso(ByVal proceso As String)
        Dim procesos() As Process = Process.GetProcesses
        Dim i As Integer
        For i = 0 To procesos.Length - 1
            If procesos(i).ProcessName = proceso Then
                procesos(i).Kill()
            End If
        Next
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)
        Dispose()
    End Sub

    Private Sub lsvEmpresas_MouseDown(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub lsvEmpresas_MouseLeave(sender As Object, e As System.EventArgs)

    End Sub


    Private Sub lsvEmpresas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTipo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipo.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboTipo_TextChanged(sender As System.Object, e As System.EventArgs) Handles cboTipo.TextChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dispose()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        With frmModalEmpresa
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If MessageBoxAdv.Show("S O F T - P A C K, ¿Desea salir?", "Salir del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            MatarProceso("SMSvcHost.exe")
            Application.ExitThread()
        Else
            'e.Cancel = True
        End If
    End Sub

    Private Sub cboEmpresa_Click(sender As Object, e As EventArgs) Handles cboEmpresa.Click

    End Sub

    Private Sub cboEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEmpresa.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Dim codEmpresa = cboEmpresa.SelectedValue

        If codEmpresa.ToString.Trim.Length > 0 Then
            getEstablecimiento(codEmpresa)
            ObtenerConfiguracionPorEmpresa(codEmpresa)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If txtFechaIgv.Value.Date = MonthPeriodo.SelectedDates(0).Date Then

        Else
            MessageBox.Show("Debe ingresar un t/c para la fecha de trabajo!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If cboAnio.Text.Trim.Length > 0 Then
            If txtIva.Value > 0 Then
                If nudTipoCambioCompra.Value > 0 Then
                    If nudTipoCambio.Value > 0 Then

                        If nudTCTransaccionCompra.Value > 0 Then
                            If nudTCTransaccionVenta.Value > 0 Then

                                If MessageBoxAdv.Show("Desea guardar la configuración con fecha" & vbCrLf & vbCrLf & _
                                              Space(25) & MonthPeriodo.Value.Date, "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

                                    Grabar()
                                Else
                                    Exit Sub
                                End If
                            Else
                                MessageBox.Show("Ingresar un tipo de cambio mayor a 0", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Question)
                            End If
                        Else
                            MessageBox.Show("Ingresar un tipo de cambio de transacción mayor a 0", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Question)

                        End If
                    Else
                        MessageBox.Show("Ingresar un tipo de cambio mayor a 0", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Question)
                    End If
                Else
                    MessageBox.Show("Ingresar un tipo de cambio de compra mayor a 0", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Question)
                End If
            Else
                MessageBox.Show("Ingresar un Iva mayor a 0", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Question)
                
            End If
        Else
            MessageBox.Show("Ingresar un año", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Question)
        End If

    End Sub

    Private Sub PictureBox17_Click(sender As Object, e As EventArgs) Handles PictureBox17.Click
        With frmTipoCambio
            .txtFechaIgv.Value = DateTime.Now.Date
            .StartPosition = FormStartPosition.CenterParent
            .nudTipoCambioCompra.Value = nudTipoCambioCompra.Value
            .nudTipoCambio.Value = nudTipoCambio.Value
            .ShowDialog()
            UbicarTC()
        End With
    End Sub

    Private Sub PictureBox16_Click(sender As Object, e As EventArgs) Handles PictureBox16.Click
        ObtenerTipoCambioMax()
    End Sub

    Private Sub frmSeleccionEmpresaMDI_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub MonthPeriodo_Load(sender As Object, e As EventArgs) Handles MonthPeriodo.Load

    End Sub
    Sub UbicarTC()
        Dim tipocambioSA As New tipoCambioSA
        Dim tipocambio As New tipoCambio

        Dim b = MonthPeriodo.SelectedDates(0).Date

        tipocambio = tipocambioSA.ObtenerTipoCambioXfecha(Gempresas.IdEmpresaRuc, MonthPeriodo.SelectedDates(0).Date, GEstableciento.IdEstablecimiento)

        If Not IsNothing(tipocambio) Then
            txtFechaIgv.Value = tipocambio.fechaIgv
            nudTipoCambioCompra.Value = tipocambio.compra
            nudTipoCambio.Value = tipocambio.venta
        Else
            txtFechaIgv.IsNullDate = True
            nudTipoCambioCompra.Value = 0
            nudTipoCambio.Value = 0
            '  MessageBox.Show("Falta ingresar el t/c para esta fecha.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            PictureBox17.Select()
        End If
    End Sub
    Private Sub MonthPeriodo_SelectionChanged(sender As Object, e As EventArgs) Handles MonthPeriodo.SelectionChanged
        UbicarTC()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Cursor = Cursors.WaitCursor
        Dim tipocambioSA As New tipoCambioSA
        If txtFechaIgv.IsNullDate = False Then
            If MessageBox.Show("Esta seguro de eliminar el t/c" & vbCrLf & "de la fecha: " & txtFechaIgv.Value.Date, "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                tipocambioSA.DeleteTC(New tipoCambio With {.fechaIgv = txtFechaIgv.Value.Date, .idRegulador = 100})
                MessageBox.Show("t/c eliminado correctamente", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtFechaIgv.IsNullDate = True
                nudTipoCambioCompra.Value = 0
                nudTipoCambio.Value = 0
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class