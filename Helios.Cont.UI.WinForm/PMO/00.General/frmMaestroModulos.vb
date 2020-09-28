Imports Syncfusion.Windows.Forms.Tools
Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports ExtendedListBoxControl.ExtendedListBoxItemClasses
Public Class frmMaestroModulos
    Inherits frmMaster



#Region "Métodos"
  

    Private Sub GrabarConfiInicio()
        Dim config As New configuracionInicio
        Dim existe As New configuracionInicio
        Dim configsa As New ConfiguracionInicioSA
        With config
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .idalmacenVenta = TmpIdAlmacen
            .anio = CStr(DateTime.Now.Year)
            .mes = String.Format("{0:00}", Convert.ToInt32(DateTime.Now.Month))
            'If IsDate(New DateTime(cboAnios.Text, txtMes.Value.Month, txtDiaLaboral.Value.Day)) Then
            .dia = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            'Else
            'Throw New Exception("Validar la fecha")
            'End If
            .periodo = String.Format("{0:00}", Convert.ToInt32(DateTime.Now.Month)) & "/" & DateTime.Now.Year
            .tipocambio = TmpTipoCambio
            .iva = TmpIGV
            .tipoIva = TmpTipoIVA
            .retencion4ta = TmpRetencion4

            'If rbConIva.Checked = True Then
            '    .tipoIva = "SIVA"
            'ElseIf rbSinIVA.Checked = True Then
            '    .tipoIva = "NIVA"
            'End If

            existe = configsa.ObtenerConfigXempresa(Gempresas.IdEmpresaRuc)

            If Not IsNothing(existe) Then
                configsa.EditarConfigInicio(config)
            Else
                'configsa.InsertConfigInicio(config)
            End If
            'GEstableciento = New GEstablecimiento
            'GEstableciento.IdEstablecimiento = GEstableciento.IdEstablecimiento
            'GEstableciento.NombreEstablecimiento = GEstableciento.NombreEstablecimiento
            'TmpIdAlmacen = TmpIdAlmacen
            'TmpNombreAlmacen = TmpNombreAlmacen
            AnioGeneral = CStr(DateTime.Now.Year)
            MesGeneral = String.Format("{0:00}", Convert.ToInt32(DateTime.Now.Month))
            DiaLaboral = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(DateTime.Now.Month)) & "/" & DateTime.Now.Year
            'TmpTipoCambio = TmpTipoCambio
            'TmpIGV = TmpIGV
            'If rbConIva.Checked = True Then
            '    TmpTipoIVA = "SIVA"
            'Else
            '    TmpTipoIVA = "NIVA"
            'End If
            'TmpTipoIVA = TmpTipoIVA
            'Dispose()
        End With
    End Sub

    Public Sub anioverificar()
        Dim AnioSA As New empresaPeriodoSA
        Dim Anio As New empresaPeriodo

        Anio.idEmpresa = Gempresas.IdEmpresaRuc
        Anio.periodo = CStr(DateTime.Now.Year)
        Anio.usuarioActualizacion = usuario.IDUsuario
        Anio.fechaActualizacion = DateTime.Now
        Anio.message = "verificar"
        AnioSA.InsertarPeriodo(Anio)

    End Sub

    Public Sub CargarConfiguracionInicioUsuariosDeCaja(strIdEmpresa As String)
        Dim configSA As New ConfiguracionInicioSA
        Dim config As New configuracionInicio
        Dim estableSA As New establecimientoSA
        Dim almaceSa As New almacenSA
        Dim cierreCajaSA As New CierreCajaSA
        Dim cierreInventarioSA As New CierreInventarioSA
        Dim empresaSA As New empresaSA
        Dim empresa As New empresa
        config = configSA.ObtenerConfigXempresa(strIdEmpresa)

        If Not IsNothing(config) Then

            empresa = empresaSA.UbicarEmpresaRuc(strIdEmpresa)

            With config
                Gempresas = New GEmpresa
                Gempresas.IdEmpresaRuc = strIdEmpresa
                Gempresas.NomEmpresa = empresa.razonSocial
                Gempresas.NomCorto = empresa.razonSocial

                GEstableciento = New GEstablecimiento
                GEstableciento.IdEstablecimiento = .idEstablecimiento
                GEstableciento.NombreEstablecimiento = estableSA.UbicaEstablecimientoPorID(.idEstablecimiento).nombre
                TmpIdAlmacen = .idalmacenVenta.GetValueOrDefault
                '     TmpNombreAlmacen = almaceSa.GetUbicar_almacenPorID(.idalmacenVenta).descripcionAlmacen
                AnioGeneral = .anio
                MesGeneral = .mes
                DiaLaboral = .dia
                PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(.mes)) & "/" & .anio
                TmpTipoCambio = .tipocambio
                TmpIGV = .iva
                TmpTipoIVA = .tipoIva
                TmpRetencion4 = .retencion4ta.GetValueOrDefault
            End With
            AreaTrabajo()

            'CajaInicioSaldo()
        End If

    End Sub

    Sub CajaInicioSaldo()
        Dim EfSA As New EstadosFinancierosSA
        Dim Ef As New estadosFinancieros
        Dim UsuarioEstadoCaja As New UsuarioEstadoCaja
        'Dim cajaUsuarioSA As New cajaUsuarioSA

        Ef = EfSA.GetUbicar_estadosFinancierosPorID(TmpIdEntidadFinanciera)
        If Not IsNothing(Ef) Then
            GFichaUsuarios = New GFichaUsuario
            GFichaUsuarios.IdCajaUsuario = usuario.IDUsuario
            GFichaUsuarios.IdPersona = usuario.IDUsuario
            GFichaUsuarios.NombrePersona = usuario.CustomUsuario.Nombres & ", " & usuario.CustomUsuario.ApellidoPaterno & " " & usuario.CustomUsuario.ApellidoMaterno
            GFichaUsuarios.ClaveUsuario = String.Empty
            GFichaUsuarios.IdCajaOrigen = TmpIdEntidadFinanciera
            GFichaUsuarios.IdCajaDestino = TmpIdEntidadFinanciera
            GFichaUsuarios.cuentaDestino = Ef.cuenta
            GFichaUsuarios.NomCajaDestinb = Ef.descripcion
            GFichaUsuarios.FechaApertura = DateTime.Now
            GFichaUsuarios.Moneda = Ef.codigo

            GFichaUsuarios.TipoCambio = Ef.tipocambio
            GFichaUsuarios.FondoMN = Ef.importeBalanceMN
            GFichaUsuarios.FondoME = Ef.importeBalanceME
            GFichaUsuarios.EstadoCaja = "A"
            GFichaUsuarios.EnUso = ""
            UsuarioEstadoCaja.GetSaldoActual(GFichaUsuarios)
        End If
    End Sub

    Public Sub CargarConfiguracionInicio(strIdEmpresa As String)
        Dim configSA As New ConfiguracionInicioSA
        Dim config As New configuracionInicio
        Dim estableSA As New establecimientoSA
        Dim almaceSa As New almacenSA
        Dim cierreCajaSA As New CierreCajaSA
        Dim cierreInventarioSA As New CierreInventarioSA
        'config = configSA.ObtenerConfigXempresa(Gempresas.IdEmpresaRuc)

        'If Not IsNothing(config) Then
        '    With config
        '        GEstableciento = New GEstablecimiento
        '        GEstableciento.IdEstablecimiento = .idEstablecimiento
        '        GEstableciento.NombreEstablecimiento = estableSA.UbicaEstablecimientoPorID(.idEstablecimiento).nombre
        '        TmpIdAlmacen = .idalmacenVenta
        '        TmpNombreAlmacen = almaceSa.GetUbicar_almacenPorID(.idalmacenVenta).descripcionAlmacen
        '        AnioGeneral = .anio
        '        MesGeneral = .mes
        '        DiaLaboral = .dia
        '        PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(.mes)) & "/" & .anio
        '        TmpTipoCambio = .tipocambio
        '        TmpIGV = .iva
        '        TmpTipoIVA = .tipoIva
        '        TmpRetencion4 = .retencion4ta.GetValueOrDefault
        '    End With
        AreaTrabajo()
        'If MessageBoxAdv.Show("Desea trabajar con el día actual, o dejar la última configuración?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        '    GrabarConfiInicio()
        '    anioverificar()
        'End If

        'MessageBoxAdv.Show("Configuración existente habilitada!", "Atención", MessageBoxButtons.OK)

        'If MessageBoxAdv.Show("Desea cambiar el IGV", "Atención", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

        '    With frmTipoCambio
        '        .ToolStrip3.Visible = True
        '        .txtFechaIgv.Value = DateTime.Now
        '        .StartPosition = FormStartPosition.CenterParent
        '        .txtCambio.Text = "Cambio"
        '        .ShowDialog()
        '        'ObtenerTipoCambioMax()
        '    End With
        'End If

        If cierreCajaSA.CajaTienePeriodoCerrado(Gempresas.IdEmpresaRuc, PeriodoGeneral) = True Then
            Label12.Image = ImageListAdv1.Images(9)
        Else
            Label12.Image = ImageListAdv1.Images(8)
        End If

        If cierreInventarioSA.PeriodoInventarioCerrado(Gempresas.IdEmpresaRuc, PeriodoGeneral.Replace("/", "")) = True Then
            Label11.Image = ImageListAdv1.Images(11)
            CierreInventarioPeriodo = True
        Else
            Label11.Image = ImageListAdv1.Images(10)
            CierreInventarioPeriodo = False
        End If
        'Else
        'MessageBoxAdv.Show("No dispone de una configuración de inicio.!", "Atención", MessageBoxButtons.OK)
        'If MessageBoxAdv.Show("Desea abrir el formulario de configuración?", "Atención", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        '    Dim LightBox As New frmConfigInicioXempresa(Gempresas.IdEmpresaRuc)
        '    LightBox.SetBounds(Me.Left, Me.Top, Me.ClientRectangle.Width, Me.ClientRectangle.Height)
        '    LightBox.Owner = Me
        '    LightBox.ShowDialog()
        'End If
        'End If


    End Sub
#End Region

    Public Property ManipulacionEstado() As String

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.splashControl1.SplashControlPanel.BorderType = SplashBorderType.None
        Me.splashControl1.ShowDialogSplash(Me)
        Me.splashControl1.AutoMode = False

        Me.splashControl1.HostForm = Me
        DockingClientPanel1.Enabled = False
        ' Add any initialization after the InitializeComponent() call.
        'lista()
        'HabilitarModulos()
    End Sub
    Dim gradientLabel1 As New GradientLabel
    Dim toolTipInfo1 As New ToolTipInfo()
    Private _ls As LoadStyle
    Public Enum LoadStyle
        OnLoad
        OnShown
        OnShownDoEvents
    End Enum


    'Sub CoNteoNotifi() '
    '    Dim notificacionAlmacenSA As New notificacionAlmacenSA
    '    Dim almacenSA As New TotalesAlmacenSA

    '    lblCCaja.Text = notificacionAlmacenSA.GetUbicarNotificacionConteo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, TIPO_SITUACION.NOTIFICACION_DOCUMENTO_CAJA)
    '    lblCCompras.Text = notificacionAlmacenSA.GetUbicarNotificacionConteo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, TIPO_SITUACION.NOTIFICACION_SOBRANTE)
    '    lblCAlmacen.Text = almacenSA.GetNotificacionAlmacen.Count


    'End Sub

#Region "Notificaciones"
    'Public Sub MostrarNotificacionesCompras()
    '    Dim notificacionAlmacenSA As New notificacionAlmacenSA
    '    Dim notificacionAlmacen As New List(Of notificacionAlmacen)
    '    Dim dt As New DataTable()

    '    Dim bmp As Bitmap = My.Resources._Exit
    '    Me.Icon = Icon.FromHandle(bmp.GetHicon)

    '    notificacionAlmacen = notificacionAlmacenSA.GetUbicarNotificacion(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, TIPO_SITUACION.NOTIFICACION_SOBRANTE)

    '    If notificacionAlmacen.Count > 0 Then
    '        lblNotif.Image = ImageListAdv1.Images(4)
    '    Else
    '        lblNotif.Image = ImageListAdv1.Images(3)
    '    End If
    '    extendedListBoxControl1.Items.Clear()
    '    extendedListBoxControl1.Dock = DockStyle.Fill
    '    extendedListBoxControl1.Visible = True
    '    ExtendedListBoxControl2.Visible = False
    '    ExtendedListBoxControl3.Visible = False

    '    'Cargar datos notificacion de compras
    '    For Each i In notificacionAlmacen
    '        Dim xlbi As New ExtendedListBoxItem(50, 95, "Documento eliminado.", "Nro. " & i.serie & "-" & i.numeroDoc, i.idDocumento, i.idPadre, i.serie, i.numeroDoc, i.nombreProveedor, "COMPRA", Color.White, Color.White)
    '        xlbi.MaxString = "Tipo operación: Compra." & vbCrLf & _
    '            "Proveedor: " & i.nombreProveedor & vbCrLf & _
    '            "Nro. doc.: " & i.serie & "-" & i.numeroDoc
    '        xlbi.BorderType = BorderTypes.square
    '        xlbi.ExitIcon = Icon
    '        xlbi.TransparencyColor = Color.White
    '        xlbi.BackColor1_E = Color.White
    '        xlbi.BackColor1_C = Color.White
    '        xlbi.BackColor2_C = Color.White
    '        xlbi.BeginGlowValue = 200
    '        extendedListBoxControl1.AddItem(xlbi)
    '    Next
    'End Sub

    Public Sub MostrarNotificacionesCaja()
        Dim notificacionAlmacenSA As New notificacionAlmacenSA
        Dim notificacionAlmacenCaja As New List(Of notificacionAlmacen)
        Dim dt As New DataTable()

        Dim bmp As Bitmap = My.Resources._Exit
        Me.Icon = Icon.FromHandle(bmp.GetHicon)

        notificacionAlmacenCaja = notificacionAlmacenSA.GetUbicarNotificacionCaja(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, TIPO_SITUACION.NOTIFICACION_DOCUMENTO_CAJA)

        If notificacionAlmacenCaja.Count > 0 Then
            lblNotif.Image = ImageListAdv1.Images(4)
        Else
            lblNotif.Image = ImageListAdv1.Images(3)
        End If
        ExtendedListBoxControl2.Items.Clear()
        ExtendedListBoxControl2.Dock = DockStyle.Fill
        extendedListBoxControl1.Visible = False
        ExtendedListBoxControl2.Visible = True
        ExtendedListBoxControl3.Visible = False

        'Cargar datos notificacion de transferencia de caja
        For Each x In notificacionAlmacenCaja
            Dim xlbiCaja As New ExtendedListBoxItem(50, 95, "Documento eliminado.", "transferencia de caja con fecha. " & CDate(x.fechaDoc).Date, x.idDocumento, x.idPadre, x.entidadFinanciera, x.entidadFinancieraDestino, "CAJA", Nothing, Color.White, Color.White)
            xlbiCaja.MaxString = "Tipo operación:  Transferencia de Caja" & vbCrLf & _
                "Importe MN: " & x.importeTotal & vbCrLf & _
                "Importe ME: " & x.importeUS
            xlbiCaja.BorderType = BorderTypes.square
            xlbiCaja.ExitIcon = Icon
            xlbiCaja.TransparencyColor = Color.White
            xlbiCaja.BackColor1_E = Color.White
            xlbiCaja.BackColor1_C = Color.White
            xlbiCaja.BackColor2_C = Color.White
            xlbiCaja.BeginGlowValue = 200
            ExtendedListBoxControl2.AddItem(xlbiCaja)
        Next
    End Sub

    'Public Sub MostrarNotificacionesAlmacen()
    '    Dim TotalesAlmacenSA As New TotalesAlmacenSA
    '    Dim objTotalesAlmacen As New List(Of totalesAlmacen)
    '    Dim dt As New DataTable()

    '    Dim bmp As Bitmap = My.Resources.export_excel
    '    Me.Icon = Icon.FromHandle(bmp.GetHicon)

    '    objTotalesAlmacen = TotalesAlmacenSA.GetNotificacionAlmacen()

    '    If objTotalesAlmacen.Count > 0 Then
    '        lblNotif.Image = ImageListAdv1.Images(4)
    '    Else
    '        lblNotif.Image = ImageListAdv1.Images(3)
    '    End If
    '    ExtendedListBoxControl3.Items.Clear()
    '    extendedListBoxControl1.Visible = False
    '    ExtendedListBoxControl2.Visible = False
    '    ExtendedListBoxControl3.Visible = True
    '    ExtendedListBoxControl3.Dock = DockStyle.Fill

    '    'Cargar datos notificacion de compras
    '    For Each i In objTotalesAlmacen
    '        Dim xlbi As New ExtendedListBoxItem(50, 95, "Almacén Existencias.", i.descripcion, i.idMovimiento, i.idItem, i.idAlmacen, 0, 1, "ALMACEN", Color.White, Color.White)
    '        xlbi.MaxString = "Tipo: Existencias en Almacén" & vbCrLf & _
    '            "Existencia: " & i.descripcion & vbCrLf & _
    '            "Cantidad: " & CInt(i.cantidadMinima).ToString
    '        xlbi.BorderType = BorderTypes.square
    '        xlbi.ExitIcon = Icon
    '        xlbi.TransparencyColor = Color.White
    '        xlbi.BackColor1_E = Color.White
    '        xlbi.BackColor1_C = Color.White
    '        xlbi.BackColor2_C = Color.White
    '        xlbi.BeginGlowValue = 200

    '        ExtendedListBoxControl3.AddItem(xlbi)
    '    Next
    'End Sub

#End Region

    Sub AreaTrabajo()
        toolTipInfo1.Body.Size = New System.Drawing.Size(20, 20)
        toolTipInfo1.Body.Text = "Empresa: " & Gempresas.NomEmpresa & vbCrLf & "Establecimiento: " & GEstableciento.NombreEstablecimiento & vbCrLf & "Almacén de trabajo: " & TmpNombreAlmacen
        toolTipInfo1.Body.TextMargin = New System.Windows.Forms.Padding(3)
        'toolTipInfo1.Footer.Size = New System.Drawing.Size(20, 20)
        ''toolTipInfo1.Footer.Text = "ToolTip's Image and Text can be aligned using " & vbCr & vbLf & "  ImageAlign and TextAlign proper" + "ties."
        ''toolTipInfo1.Footer.TextMargin = New System.Windows.Forms.Padding(3)
        toolTipInfo1.Header.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CByte(0))
        '  toolTipInfo1.Header.Image = DirectCast(Resources.GetObject("resource.Image"), System.Drawing.Image)
        toolTipInfo1.Header.Size = New System.Drawing.Size(20, 20)
        toolTipInfo1.Header.Text = "Información"
        toolTipInfo1.Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        toolTipInfo1.Header.TextMargin = New System.Windows.Forms.Padding(3)
        Me.SuperToolTip1.SetToolTip(Label4, toolTipInfo1)

        Label5.Text = "Período: " & PeriodoGeneral
    End Sub

    Private Sub frmMaestroModulos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBoxAdv.Show("S O F T - P A C K, ¿Desea salir?", "Salir del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            MatarProceso("Helios.Cont.Presentation.WinForm")
            MatarProceso("SMSvcHost.exe")
            Application.ExitThread()
        Else
            e.Cancel = True
        End If
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
    Dim tip As New SuperToolTip
    Dim toolTipInfo11 As New Syncfusion.Windows.Forms.Tools.ToolTipInfo()
    Private Sub ToolTipInicio()
      

        'tip = New SuperToolTip
        'toolTipInfo1 = New Syncfusion.Windows.Forms.Tools.ToolTipInfo()

        toolTipInfo11.Header.Image = ImageListAdv1.Images(14)
        toolTipInfo11.Header.Font = New Font("Corbel", 10, FontStyle.Regular)
        toolTipInfo11.Header.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        toolTipInfo11.Header.Text = "Información general"
        toolTipInfo11.Header.TextAlign = System.Drawing.ContentAlignment.TopCenter
        toolTipInfo11.Body.Text = "Empresa: " & Gempresas.NomEmpresa
        toolTipInfo11.Body.Font = New Font("Corbel", 9, FontStyle.Regular)
        toolTipInfo11.Body.ForeColor = Color.DimGray
        toolTipInfo11.Footer.Text = "Establecimiento: " & GEstableciento.NombreEstablecimiento
        toolTipInfo11.Footer.Font = New Font("Corbel", 9, FontStyle.Regular)
        toolTipInfo11.Footer.ForeColor = Color.DimGray


        'Associating SuperToolTip for ToolStripTabItem

        tip.SetToolTip(Label3, toolTipInfo11)
    End Sub

    Private Sub frmMaestroModulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Me.SplitButton1.Style = Syncfusion.Windows.Forms.Tools.SplitButtonVisualStyle.Metro
        '   Me.SplitButton1.BackColor = Color.FromArgb(92, 184, 92)
        Me.PopupMenusManager1.SetXPContextMenu(Me.PictureBox1, Me.PopupMenu1)
        BarItem1.Enabled = False
        BarItem2.Enabled = False
        BarItem3.Visible = False
        BarItem5.Visible = False

        '    If _ls = LoadStyle.OnLoad Then



        ' End If
        Me.WindowState = FormWindowState.Normal
        Timer1.Enabled = True
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Cursor = Cursors.WaitCursor


        'If AutorizacionRolSA.TienePermiso(ModuloAsegurable.CONFIG_INICIO, AutorizacionRolList) Then
        'MessageBox.Show("Usuario autorizado")

        'Dim val As Object = CheckForm(frmMasterComprasGenerales)

        Dim f As New frmInicioEmpresa
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        Label5.Text = "Período: " & PeriodoGeneral
        lblEstablecimiento.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
        Label24.Text = GEstableciento.NombreEstablecimiento
        ToolTipInicio()
        'Else
        'MessageBox.Show("Usuario no autorizado")
        'End If


        'AlertasVenta()
        'AlertaMovAlmacen()
        'GetInventarioEnAlertaConteo(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})

        '  AreaTrabajo()
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub frmMaestroModulos_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

    End Sub

    Private Sub frmMaestroModulos_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub HubTile3_Click(sender As Object, e As EventArgs) Handles HubTile3.Click
        Me.Cursor = Cursors.WaitCursor
        '   If AutorizacionRolSA.TienePermiso(ModuloAsegurable.COMERCIAL, AutorizacionRolList) Then
        '   MessageBox.Show("Usuario autorizado")
        Dim f As New frmMasterGeneralVentas
        'f.Size = New Size(1340, 708)
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        'Else
        'MessageBox.Show("Usuario no autorizado")
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub
    Public Enum Asegurable 'Los códigos son los que están asignados en la BD
        Seguridad = 1
        AltaUsuario = 2
        UsuarioEnRol = 3
    End Enum

    Private Function CheckForm(_form As Form) As Form

        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return f
            End If
        Next

        Return Nothing

    End Function

    Private Sub BannerTile_Click(sender As Object, e As EventArgs) Handles BannerTile.Click
        Me.Cursor = Cursors.WaitCursor
        '     If AutorizacionRolSA.TienePermiso(ModuloAsegurable.COMPRAS, AutorizacionRolList) Then
        'MessageBox.Show("Usuario autorizado")

        'Dim val As Object = CheckForm(frmMasterComprasGenerales)

        Dim f As New frmMasterComprasGenerales
        f.Size = New Size(1340, 708)
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        'Else
        'MessageBox.Show("Usuario no autorizado")
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub HubTile2_Click(sender As Object, e As EventArgs) Handles HubTile2.Click
        Me.Cursor = Cursors.WaitCursor
        '  If AutorizacionRolSA.TienePermiso(ModuloAsegurable.INVENTARIO, AutorizacionRolList) Then
        'MessageBox.Show("Usuario autorizado")
        Dim f As New frmInventario ' frmMasterGeneralInventario
        f.Size = New Size(1340, 708)
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        'Else
        'MessageBox.Show("Usuario no autorizado")
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub HubTile5_Click(sender As Object, e As EventArgs) Handles HubTile5.Click
        Me.Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(ModuloAsegurable.FINANZAS, AutorizacionRolList) Then
        '    'MessageBox.Show("Usuario autorizado")
        '    Dim f As New frmFinanzas ' frmMasterCajas
        '    'f.WindowState = FormWindowState.Maximized
        '    'f.Size = New Size(1340, 708)
        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.ShowDialog()
        'Else
        '    MessageBox.Show("Usuario no autorizado")
        'End If

        '   If AutorizacionRolSA.TienePermiso(ModuloAsegurable.FINANZAS, AutorizacionRolList) Then
        'MessageBox.Show("Usuario autorizado")
        'Dim f As New frmModuloFinanzas  ' frmMasterCajas
        ''f.WindowState = FormWindowState.Maximized
        ''f.Size = New Size(1340, 708)
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
        'Else
        'MessageBox.Show("Usuario no autorizado")
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub HubTile4_Click(sender As Object, e As EventArgs) Handles HubTile4.Click
        Me.Cursor = Cursors.WaitCursor
        '  If AutorizacionRolSA.TienePermiso(ModuloAsegurable.CONTABILIDAD, AutorizacionRolList) Then
        '  MessageBox.Show("Usuario autorizado")
        Dim f As New frmMaestroAsientoContables
        f.Size = New Size(1340, 708)
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        'Else
        'MessageBox.Show("Usuario no autorizado")
        'End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub HubTile6_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmConfiguracionesInicio
        f.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub HubTile9_Click(sender As Object, e As EventArgs) Handles HubTile9.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ef As New EstadosFinancierosSA
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim usuarioSA As New UsuarioSA
        Dim usuarioxls As New Usuario
        cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)

        If Not IsNothing(cajaUsuario) Then
            usuarioxls = usuarioSA.UbicarUsuarioXid(New Usuario With {.IDUsuario = usuario.IDUsuario})

            Dim F As New frmCobroPedidos
            F.txtNomUser.Text = usuarioxls.Full_Name
            'F.txtCajaOrigen.Tag = CInt(cajaUsuario.idCajaOrigen)
            'F.txtCajaOrigen.Text = ef.GetUbicar_estadosFinancierosPorID(CInt(cajaUsuario.idCajaOrigen)).descripcion
            '   F.GetObtenerSaldoEF()
            'F.GridPago()


            If IsNothing(cajaUsuario.idPadre) Then
                F.txtTipoUser.Text = "Usuario Responsable"
                F.txtTipoUser.Tag = cajaUsuario.idcajaUsuario
            Else
                F.txtTipoUser.Text = "Usuario Dependiente"
                F.txtTipoUser.Tag = cajaUsuario.idcajaUsuario
            End If

            F.StartPosition = FormStartPosition.CenterParent
            F.ShowDialog()
            'Dim f As New frmCajaTicket
            'f.SinAnticipo()
            'f.Show()
        Else
            MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub HubTile10_Click(sender As Object, e As EventArgs) Handles HubTile10.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmMasterCierres
        f.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Public Class Modulos

        Public Property ListaNom As New List(Of Modulos)

        Sub New()

        End Sub

        Private Nombres As String
        Public Property Nom() As String
            Get
                Return Nombres
            End Get
            Set(ByVal value As String)
                Nombres = value
            End Set
        End Property

    End Class


    Dim ListaNom As New List(Of Modulos)
    Dim c As New Modulos
    Dim sec As Integer = 0
    Private Sub Timer2_Tick(sender As Object, e As EventArgs)
        'HubTile3.Title.Text = ListaNom(sec).Nom
        'HubTile3.Title.Font = New Font("Segoe UI", 9.5, FontStyle.Italic)
        'sec = sec + 1
        'If sec = 4 Then
        '    sec = 0
        'End If
    End Sub

    Private Sub HubTile11_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmUsuariosFinanza
        f.Size = New Size(1340, 708)
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub HubTile8_Click(sender As Object, e As EventArgs)
        'Dim f As New frmMasterCierreGeneral
        'f.ShowDialog()
    End Sub

    Private Sub HubTile7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblNotif_Click(sender As Object, e As EventArgs) Handles lblNotif.Click
        Me.Cursor = Cursors.WaitCursor

        If Me.dockingManager1.GetDockVisibility(Panel2) = False Then

            '    extendedListBoxControl1.Visible = True
            'DockVisibilityChangedEventArgs instance arg holds the control being changed the visibility  


            '       MessageBox.Show(Me.dockingManager1.GetDockLabel(Panel2) + " " + " window is closed.")

            dockingManager1.SetDockVisibility(Panel2, True)
            dockingManager1.SetDockLabel(Panel2, "Notificaciones")

            '   MostrarNotificaciones()
        Else
            dockingManager1.SetDockVisibility(Panel2, False)
            '     extendedListBoxControl1.Visible = False
        End If
        Me.Cursor = Cursors.Arrow
        'Panel2.BringToFront()
        'dockingManager1.DockControl(Panel2, Me, DockingStyle.Left, 257)


        'Dim f As New frmNotify
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.Show()
    End Sub

    Private Sub dockingManager1_DockMenuClick(sender As Object, arg As DockMenuClickEventArgs) Handles dockingManager1.DockMenuClick

    End Sub

    Private Sub dockingManager1_DockStateChanged(sender As Object, arg As DockStateChangeEventArgs) Handles dockingManager1.DockStateChanged

    End Sub

    Private Sub dockingManager1_DockVisibilityChanged(sender As Object, arg As DockVisibilityChangedEventArgs) Handles dockingManager1.DockVisibilityChanged
        'If Me.dockingManager1.GetDockVisibility(arg.Control) = False Then


        '    'DockVisibilityChangedEventArgs instance arg holds the control being changed the visibility  


        '    MessageBox.Show(Me.dockingManager1.GetDockLabel(arg.Control) + " " + " window is closed.")
        'End If
    End Sub

    Private Sub extendedListBoxControl1_ListItemClick(sender As Object, e As ExtendedListBoxControl.XLBIEventArgs) Handles extendedListBoxControl1.ListItemClick
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        Dim objNotificacionSA As New notificacionAlmacenSA
        datos.Clear()

        If (e.ctrlHit = True) Then
            If ((e.entry.Tipo) = "COMPRA") Then

                With frmAlmacenTransfenciaSobrante
                    .idDocNotificacion = e.entry.idDocInt
                    .UbicarDocumentoPorId(CInt(e.entry.idPadreInt))
                    .txtSerie.Text = e.entry.SerieInt
                    .txtNumero.Text = e.entry.DocInt
                    .txtProveedor.Text = e.entry.ProvInt
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    If datos.Count > 0 Then
                        If (datos(0).IdResponsable = "True") Then
                            extendedListBoxControl1.RemoveItem()
                        End If
                    End If
                End With

            End If
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub BtDashBoard_Click(sender As Object, e As EventArgs) Handles BtDashBoard.Click
        Me.Cursor = Cursors.WaitCursor
        Dim F As New frmTableroPorDia
        'Dim f As New frmDashBoard
        F.StartPosition = FormStartPosition.CenterParent
        F.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.PopupMenu1.Show(CType(sender, Control), New Point(e.X, e.Y))
        End If
    End Sub
    Public Function TieneCuentaFinanciera(Optional intIdDocumento As Integer = Nothing) As Boolean
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim estableSA As New establecimientoSA

        GFichaUsuarios = New GFichaUsuario
        Select Case ManipulacionEstado
            Case ENTITY_ACTIONS.INSERT

                If IsNothing(GFichaUsuarios.NombrePersona) Then
                    With frmFichaUsuarioCaja
                        ModuloAppx = ModuloSistema.CAJA
                        .lblNivel.Text = "Caja"
                        .lblEstadoCaja.Visible = True
                        '.GroupBox1.Visible = True
                        '.GroupBox2.Visible = True
                        '.GroupBox4.Visible = True
                        '.cboMoneda.Visible = True
                        .Timer1.Enabled = True
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                        If IsNothing(GFichaUsuarios.NombrePersona) Then
                            Return False
                        Else
                            Return True
                        End If
                    End With
                End If
            Case ENTITY_ACTIONS.UPDATE
                With frmFichaUsuarioCaja
                    ModuloAppx = ModuloSistema.CAJA
                    .lblNivel.Text = "Caja"
                    .lblEstadoCaja.Visible = True
                    '.GroupBox1.Visible = True
                    '.GroupBox2.Visible = True
                    '.GroupBox4.Visible = True
                    '.cboMoneda.Visible = True
                    .Timer1.Enabled = False
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    .StartPosition = FormStartPosition.CenterParent
                    '.UbicarUsuarioCaja(intIdDocumento, "VENTA")
                    .ShowDialog()
                    If IsNothing(GFichaUsuarios.NombrePersona) Then
                        Return False
                    Else
                        Return True
                    End If
                End With
        End Select
        Return True

    End Function
    Private Sub BarItem1_Click(sender As Object, e As EventArgs) Handles BarItem1.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(GFichaUsuarios.IdCajaUsuario) Then

            Select Case BarItemSesionCaja.Tag

                Case "PADRE"
                    With frmArqueoCaja
                        .ConsultaReportePadre(GFichaUsuarios.IdCajaUsuario)
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                Case "HIJO"
                    With frmArqueoCaja
                        .ConsultaReporte(GFichaUsuarios.IdCajaUsuario)
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
            End Select


        Else
            '  lblEstado.Text = "Seleccionar una caja activa!"
            '   Timer1.Enabled = True
            '   TiempoEjecutar(5)
        End If
        Me.Cursor = Cursors.Arrow


    End Sub

    Private Sub BarItemSesionCaja_Click(sender As Object, e As EventArgs) Handles BarItemSesionCaja.Click
        Dim cajaSa As New cajaUsuarioSA
        Me.Cursor = Cursors.WaitCursor

        If BarItemSesionCaja.Text = "Caja iniciada (cerrar sesión)" Then
            GFichaUsuarios = Nothing
            BarItemSesionCaja.Image = ImageListAdv1.Images(6)

            BarItemSesionCaja.Text = "Iniciar caja"
            BarItem1.Enabled = False
            BarItem2.Enabled = False
            BarItem3.Enabled = False
            '  BarItemSesionCaja.Enabled = True

        Else
            ManipulacionEstado = ENTITY_ACTIONS.INSERT
            If TieneCuentaFinanciera() = True Then

                BarItemSesionCaja.Image = ImageListAdv1.Images(5)
                BarItemSesionCaja.Text = "Caja iniciada (cerrar sesión)"
                With cajaSa.UbicarCajaUsuarioPorID(GFichaUsuarios.IdCajaUsuario)
                    If IsNothing(.idPadre) Then
                        BarItemSesionCaja.Tag = "PADRE"
                        BarItem5.Visible = True
                    Else
                        BarItemSesionCaja.Tag = "HIJO"
                        BarItem5.Visible = False
                    End If

                End With

                BarItem1.Enabled = True
                BarItem1.Image = ImageListAdv1.Images(7)
                BarItem2.Enabled = True
                BarItem3.Enabled = True
                '    BarItemSesionCaja.Enabled = False
            Else

                BarItemSesionCaja.Image = ImageListAdv1.Images(6)
                BarItemSesionCaja.Text = "Iniciar caja"
                BarItem1.Enabled = False
                BarItem2.Enabled = False
                BarItem3.Enabled = False
                '   BarItemSesionCaja.Enabled = True
            End If
        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub BarItem2_Click(sender As Object, e As EventArgs) Handles BarItem2.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajaUser As New cajaUsuario
        If Not IsNothing(GFichaUsuarios.IdCajaUsuario) Then
            'If cajaUsuarioSA.UbicarCajaUsuarioPorID(GFichaUsuarios.IdCajaUsuario).estadoCaja = "A" Then
            '    With frmCierreCaja
            '        .IDCajaUser = GFichaUsuarios.IdCajaUsuario
            '        .ListaCierresPorModulo(GFichaUsuarios.IdCajaUsuario)
            '        .UbicarCaja(GFichaUsuarios.IdCajaUsuario)
            '        .StartPosition = FormStartPosition.CenterParent
            '        .ShowDialog()
            '    End With
            'Else
            'lblEstado.Text = "La caja se encuentra cerrada!!"
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
            '   End If


            Select Case BarItemSesionCaja.Tag
                Case "PADRE"
                    With frmCierreCaja
                        .IDCajaUser = GFichaUsuarios.IdCajaUsuario
                        .ListaCierresPorModulo(GFichaUsuarios.IdCajaUsuario)
                        .UbicarCaja(GFichaUsuarios.IdCajaUsuario)
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                Case "HIJO"
                    If MessageBoxAdv.Show("Desea cerrar la caja?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        cajaUser = New cajaUsuario
                        cajaUser.idcajaUsuario = GFichaUsuarios.IdCajaUsuario
                        cajaUser.estadoCaja = "C"
                        cajaUsuarioSA.CerrarAbrirCajaSubUsuario(cajaUser)
                        MessageBoxAdv.Show("Caja cerrada correctamente", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
            End Select

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub HubTile13_Click(sender As Object, e As EventArgs) Handles HubTile13.Click
        Dim f As New frmVentaPV
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.WindowState = FormWindowState.Maximized
        'f.txtFecha.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
        'f.txtFecha.CustomFormat = "dd/MM/yyyy HH:mm tt"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub HubTile14_Click(sender As Object, e As EventArgs) Handles HubTile14.Click

        Dim ef As New EstadosFinancierosSA
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim usuarioSA As New UsuarioSA
        Dim usuarioxls As New Usuario
        cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)

        If Not IsNothing(cajaUsuario) Then

            Dim f As New frmVentaPVdirecta
            f.btGrabar.Enabled = True
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.CargarTipoDeVenta(TIPO_VENTA.VENTA_CREDITO_TOTAL)
            'f.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
            'f.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            f.lblPerido.Text = PeriodoGeneral
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show()
        Else
            MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If




        'With frmVentaTicketDirecta
        '    .btGrabar.Enabled = True
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    If .TieneCuentaFinanciera = True Then
        '        .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
        '        .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        '        .lblPerido.Text = PeriodoGeneral
        '        .StartPosition = FormStartPosition.CenterParent
        '        .ShowDialog()
        '    Else
        '        'lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
        '    End If
        'End With
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs)
        Dim F As New frmMasterModelReporte
        F.StartPosition = FormStartPosition.CenterParent
        F.ShowDialog()

    End Sub

    Private Sub BarItem4_Click(sender As Object, e As EventArgs) Handles BarItem4.Click
        With frmAsignaCajaUser
            .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub extendedListBoxControl1_MouseClick(sender As Object, e As MouseEventArgs) Handles extendedListBoxControl1.MouseClick
        '  MsgBox(extendedListBoxControl1.m)
    End Sub

    'Private Sub btUpdate_Click(sender As Object, e As EventArgs)
    '    MostrarNotificaciones()
    'End Sub

    Private Sub BarItem3_Click(sender As Object, e As EventArgs) Handles BarItem3.Click
        Dim cajaUser As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        If Not IsNothing(GFichaUsuarios) Then
            Select Case BarItemSesionCaja.Tag
                Case "PADRE"
                    With frmCierreCaja
                        .IDCajaUser = GFichaUsuarios.IdCajaUsuario
                        .ListaCierresPorModulo(GFichaUsuarios.IdCajaUsuario)
                        .UbicarCaja(GFichaUsuarios.IdCajaUsuario)
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                Case "HIJO"
                    If MessageBoxAdv.Show("Desea cerrar la caja?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        cajaUser = New cajaUsuario
                        cajaUser.idcajaUsuario = GFichaUsuarios.IdCajaUsuario
                        cajaUser.estadoCaja = "C"
                        cajaUsuarioSA.CerrarAbrirCajaSubUsuario(cajaUser)
                        MessageBoxAdv.Show("Caja cerrada correctamente", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
            End Select
        End If



    End Sub

    Private Sub ExtendedListBoxControl2_ListItemClick(sender As Object, e As ExtendedListBoxControl.XLBIEventArgs) Handles ExtendedListBoxControl2.ListItemClick
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        Dim objNotificacionSA As New notificacionAlmacenSA
        datos.Clear()

        If (e.ctrlHit = True) Then
            Me.Cursor = Cursors.Arrow
            If ((e.entry.Tipo) = "CAJA") Then
                objNotificacionSA.DeleteNotificacion(CInt(e.entry.idDocInt))
                ExtendedListBoxControl2.RemoveItem()
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ExtendedListBoxControl3_ListItemClick(sender As Object, e As ExtendedListBoxControl.XLBIEventArgs) Handles ExtendedListBoxControl3.ListItemClick
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        Dim objNotificacionSA As New notificacionAlmacenSA
        datos.Clear()

        If (e.ctrlHit = True) Then
            Me.Cursor = Cursors.Arrow
            If ((e.entry.Tipo) = "ALMACEN") Then
                'With frmPrueba
                '    .idAlmacen = e.entry.SerieInt
                '    .idExistencia = e.entry.idPadreInt
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                'End With
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub pbAlmacen_Click(sender As Object, e As EventArgs) Handles pbAlmacen.Click

        ExtendedListBoxControl3.Items.Clear()
        If lblCAlmacen.BackColor = Color.FromArgb(17, 130, 190) Then
            pbAlmacen.BackColor = Color.FromArgb(125, 125, 125)
            Label8.BackColor = Color.FromArgb(125, 125, 125)
            lblCAlmacen.BackColor = Color.FromArgb(125, 125, 125)
        Else
            '    MostrarNotificacionesAlmacen()
            pbAlmacen.BackColor = Color.FromArgb(17, 130, 190)
            Label8.BackColor = Color.FromArgb(17, 130, 190)
            lblCAlmacen.BackColor = Color.FromArgb(17, 130, 190)


            pbCaja.BackColor = Color.FromArgb(125, 125, 125)
            lblCaja.BackColor = Color.FromArgb(125, 125, 125)
            lblCCaja.BackColor = Color.FromArgb(125, 125, 125)


            pbCompra.BackColor = Color.FromArgb(125, 125, 125)
            lblCompra.BackColor = Color.FromArgb(125, 125, 125)
            lblCCompras.BackColor = Color.FromArgb(125, 125, 125)
        End If


    End Sub

    Private Sub pbCaja_Click(sender As Object, e As EventArgs) Handles pbCaja.Click

        ExtendedListBoxControl2.Items.Clear()
        If lblCCaja.BackColor = Color.FromArgb(17, 130, 190) Then
            pbCaja.BackColor = Color.FromArgb(125, 125, 125)
            lblCaja.BackColor = Color.FromArgb(125, 125, 125)
            lblCCaja.BackColor = Color.FromArgb(125, 125, 125)

        Else
            MostrarNotificacionesCaja()
            pbCaja.BackColor = Color.FromArgb(17, 130, 190)
            lblCaja.BackColor = Color.FromArgb(17, 130, 190)
            lblCCaja.BackColor = Color.FromArgb(17, 130, 190)

            pbAlmacen.BackColor = Color.FromArgb(125, 125, 125)
            Label8.BackColor = Color.FromArgb(125, 125, 125)
            lblCAlmacen.BackColor = Color.FromArgb(125, 125, 125)

            pbCompra.BackColor = Color.FromArgb(125, 125, 125)
            lblCompra.BackColor = Color.FromArgb(125, 125, 125)
            lblCCompras.BackColor = Color.FromArgb(125, 125, 125)
        End If
    End Sub

    Private Sub pbCompra_Click(sender As Object, e As EventArgs) Handles pbCompra.Click

        extendedListBoxControl1.Items.Clear()
        If lblCCompras.BackColor = Color.FromArgb(17, 130, 190) Then
            pbCompra.BackColor = Color.FromArgb(125, 125, 125)
            lblCompra.BackColor = Color.FromArgb(125, 125, 125)
            lblCCompras.BackColor = Color.FromArgb(125, 125, 125)

        Else
            '  MostrarNotificacionesCompras()
            pbCompra.BackColor = Color.FromArgb(17, 130, 190)
            lblCompra.BackColor = Color.FromArgb(17, 130, 190)
            lblCCompras.BackColor = Color.FromArgb(17, 130, 190)

            pbAlmacen.BackColor = Color.FromArgb(125, 125, 125)
            Label8.BackColor = Color.FromArgb(125, 125, 125)
            lblCAlmacen.BackColor = Color.FromArgb(125, 125, 125)

            pbCaja.BackColor = Color.FromArgb(125, 125, 125)
            lblCaja.BackColor = Color.FromArgb(125, 125, 125)
            lblCCaja.BackColor = Color.FromArgb(125, 125, 125)
        End If
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        '   MostrarNotificacionesAlmacen()
    End Sub


    Private Sub lblCaja_Click(sender As Object, e As EventArgs) Handles lblCaja.Click
        MostrarNotificacionesCaja()
    End Sub

    Private Sub lblCompra_Click(sender As Object, e As EventArgs) Handles lblCompra.Click
        'MostrarNotificacionesCompras()
    End Sub

    Private Sub BarItem5_Click(sender As Object, e As EventArgs) Handles BarItem5.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(GFichaUsuarios.IdCajaUsuario) Then

            'Select Case BarItemSesionCaja.Tag

            'Case "PADRE"
            Dim f As New frmUsuariosDependientesView
            f.UbicarCajaPadre(GFichaUsuarios.IdCajaUsuario)
            f.UbicarCajasHijas(GFichaUsuarios.IdCajaUsuario)
            f.StartPosition = FormStartPosition.CenterParent
            f.WindowState = FormWindowState.Maximized
            f.ShowDialog()

        Else

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Dim f As New frmListaPermisos
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
    End Sub

    Private Sub HubTile1_Click(sender As Object, e As EventArgs) Handles HubTile1.Click
        Me.Cursor = Cursors.WaitCursor
        '   If AutorizacionRolSA.TienePermiso(ModuloAsegurable.COMPRAS, AutorizacionRolList) Then
        Dim f As New frmMasterOrdenesGenerales
        f.Size = New Size(1340, 708)
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        'Else
        'MessageBox.Show("Usuario no autorizado")
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

        Dim f As New frmCierreInventario
        f.ShowDialog()
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Dim f As New frmCierreContabilidad
        f.ShowDialog()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim f As New frmCierreDeModulos
        f.ShowDialog()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        'Dim f As New frmInicioTrabajoEmpresa
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
    End Sub

    Private Sub Toolstripitem1_Click(sender As Object, e As EventArgs) Handles Toolstripitem1.Click

        'MessageBoxAdv.Show("Iniciar Sesion")
    End Sub

    Private Sub SplitButton1_DropDowItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles SplitButton1.DropDowItemClicked
        Try
            Select Case e.ClickedItem.Text
                Case "Iniciar Sesion"
                    Inicio()
                Case "Cerrar Sesion"
                    SplitButton1.BackColor = Color.FromArgb(22, 165, 220)
                    SplitButton1.Text = "Usuario"
                    DockingClientPanel1.Enabled = False
                    Inicio()

            End Select
            lblEstablecimiento.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
            Label5.Text = PeriodoGeneral
            ToolTipInicio()
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Inicio()
        End Try

    End Sub
    Sub Inicio()
        usuario = New AutenticacionUsuario
        usuario.CustomUsuario = New Usuario
        Dim LightBox As New HeliosLogin
        LightBox.SetBounds(Me.Left, Me.Top, Me.ClientRectangle.Width, Me.ClientRectangle.Height)
        LightBox.Owner = Me
        LightBox.ShowDialog()

        If Not IsNothing(usuario) Then
            SplitButton1.BackColor = Color.FromArgb(92, 184, 92)
            DockingClientPanel1.Enabled = True
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

                Case 3 ' USUARIO PUNTO DE VENTA MANJEJO DE EFECTIVO
                    CargarConfiguracionInicioUsuariosDeCaja(Gempresas.IdEmpresaRuc)
            End Select

            Label24.Text = GEstableciento.NombreEstablecimiento
        Else
            SplitButton1.BackColor = Color.FromArgb(22, 165, 220)
            SplitButton1.Text = "Usuario"
            DockingClientPanel1.Enabled = False
            MessageBox.Show("Usario o clave incorrectos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'MatarProceso("SMSvcHost.exe")
            'Application.ExitThread()
            'Me.Close()
        End If
    End Sub

    Dim i As Integer = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        i += 1000
        If i = 1000 Then
            i = 0
            Timer1.Stop()

            Dim LightBox As New HeliosLogin

            LightBox.SetBounds(Me.Left, Me.Top, Me.ClientRectangle.Width, Me.ClientRectangle.Height)
            LightBox.Owner = Me
            LightBox.ShowDialog()

            If Not IsNothing(LightBox.Tag) Then
                If Not IsNothing(usuario) Then
                    SplitButton1.BackColor = Color.FromArgb(92, 184, 92)
                    DockingClientPanel1.Enabled = True
                    SplitButton1.Text = usuario.Alias
                    Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
                        Case 1 ' ADMINISTRADOR

                            'Dim init As New frmInicioEmpresa
                            'init.StartPosition = FormStartPosition.CenterParent
                            'init.ShowDialog()

                            'CargarConfiguracionInicio(Gempresas.IdEmpresaRuc)
                            '     CoNteoNotifi()

                            Dim fSel As New frmInicioEmpresa
                            fSel.StartPosition = FormStartPosition.CenterParent
                            fSel.ShowDialog()
                            Label5.Text = "Período: " & PeriodoGeneral
                            lblEstablecimiento.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
                            Label24.Text = GEstableciento.NombreEstablecimiento

                        Case 2 ' USUARI BASICO => SOLO ACCESO AL PUNTP DE VENTA'
                            'CargarConfiguracionInicioUsuariosDeCaja(Gempresas.IdEmpresaRuc)
                            CargarConfiguracionInicioUsuariosDeCaja("20392657020")

                        Case 3 ' USUARIO PUNTO DE VENTA MANJEJO DE EFECTIVO
                            'Dim empresa As String
                            'empresa = Gempresas.IdEmpresaRuc

                            Dim fSel As New frmInicioEmpresa
                            fSel.StartPosition = FormStartPosition.CenterParent
                            fSel.ShowDialog()
                            Label5.Text = "Período: " & PeriodoGeneral
                            lblEstablecimiento.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
                            Label24.Text = GEstableciento.NombreEstablecimiento
                            'Label5.Text = "Período: " & PeriodoGeneral
                    End Select
                    ToolTipInicio()

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


        End If

    End Sub


    Private Sub SplitButton1_Click(sender As Object, e As EventArgs) Handles SplitButton1.Click

    End Sub

    Private Sub HubTile15_Click(sender As Object, e As EventArgs) Handles HubTile15.Click
        Me.Cursor = Cursors.WaitCursor

        '  If AutorizacionRolSA.TienePermiso(ModuloAsegurable.PLANEAMIENTO, AutorizacionRolList) Then
        'MessageBox.Show("Usuario autorizado")
        Dim f As New frmMasterpmo '  frmcentralProyectos ' frmCrearPaquetesTrabajo
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.Show()
        'Else
        'MessageBox.Show("Usuario no autorizado")
        'End If


        Me.Cursor = Cursors.Arrow


        'Me.Cursor = Cursors.WaitCursor
        'Dim f As New frmProyectDashboard
        'f.WindowState = FormWindowState.Maximized
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
        'Me.Cursor = Cursors.Arrow
        'Dim f As New frmMasterCostos
        'f.Size = New Size(1340, 708)
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog()
    End Sub

    Private Sub DockingClientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles DockingClientPanel1.Paint

    End Sub

    Private Sub HubTile16_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor

        '   If AutorizacionRolSA.TienePermiso(ModuloAsegurable.LISTA_PRECIOS, AutorizacionRolList) Then
        'MessageBox.Show("Usuario autorizado")
        Dim f As New frmTablasGenerales
        'f.Size = New Size(1040, 670) ' New Size(1340, 708)
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        'Else
        'MessageBox.Show("Usuario no autorizado")
        'End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim f As New FrmHojaTrabajo
        f.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmAlertaCostos
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub
   
    Private Sub SplitButton1_EnabledChanged(sender As Object, e As EventArgs) Handles SplitButton1.EnabledChanged

    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click
        'Dim f As New frmGastoModuloMaster
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()

        'Dim f As New frmEstadosFinancieros
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()

        Dim f As New frmEstadoGeneralEmpresa
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

    End Sub

    Private Sub SplitButton2_DropDowItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles SplitButton2.DropDowItemClicked
        Try
            Select Case e.ClickedItem.Text
                Case "Anticipos otorgados con comprobante de pago"
                    Dim f As New frmCompraAnticipada
                    f.StartPosition = FormStartPosition.CenterParent
                    f.WindowState = FormWindowState.Normal
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.ShowDialog()
                Case "Anticipos recibidos con comprobante de pago"
                    Me.Cursor = Cursors.WaitCursor
                    Dim f As New frmAnticipoXVenta
                    f = New frmAnticipoXVenta ' frmVentaConsumoDirecto
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    Me.Cursor = Cursors.Arrow
                Case "Anticipos recibidos por caja"
                    Me.Cursor = Cursors.WaitCursor
                    Dim f As New frmModalAnticipo
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    Me.Cursor = Cursors.Arrow
                Case "Anticipos otorgados por caja"
                    Me.Cursor = Cursors.WaitCursor
                    Dim f As New frmModalAnticipoOtor
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    Me.Cursor = Cursors.Arrow
            End Select
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Inicio()
        End Try
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            '   If AutorizacionRolSA.TienePermiso(ModuloAsegurable.CERRAR_CAJA, AutorizacionRolList) Then
            Dim f As New frmCerrarCajaXUsuario
            f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            'f.txtFecha.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
            'f.txtFecha.CustomFormat = "dd/MM/yyyy HH:mm tt"
            f.UbicarCajaUsuario(usuario.IDUsuario)
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show()
            'Else
            'MessageBox.Show("Usuario no autorizado")
            'End If


        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            '  If AutorizacionRolSA.TienePermiso(ModuloAsegurable.APERTURAR_CAJA, AutorizacionRolList) Then
            'MessageBox.Show("Usuario autorizado")
            Dim f As New frmAperturaCajaXUsuario
            f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            'f.txtFecha.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
            'f.txtFecha.CustomFormat = "dd/MM/yyyy HH:mm tt"
            f.UbicarCajaUsuario(usuario.IDUsuario)
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show()
            'Else
            'MessageBox.Show("Usuario no autorizado")
            'End If
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click
        Dim f As New frmPedidoPendiente
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmResultadoPorFuncion
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lblEstablecimiento_Click(sender As Object, e As EventArgs) Handles lblEstablecimiento.Click

    End Sub

    Private Sub lblGastosPendientes_Click(sender As Object, e As EventArgs) Handles lblGastosPendientes.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmAlertaCostos
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lblAlertaIngresos_Click(sender As Object, e As EventArgs) Handles lblAlertaIngresos.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmAlertaIngresosCosto
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub HubTile6_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub HubTile6_Click_2(sender As Object, e As EventArgs) Handles HubTile6.Click
        Dim f As New frmMaestroPlanilla
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub HubTile7_Click_1(sender As Object, e As EventArgs) Handles HubTile7.Click
        
    End Sub

    Private Sub HubTile8_Click_1(sender As Object, e As EventArgs) Handles HubTile8.Click
        Me.Cursor = Cursors.WaitCursor

        '    If AutorizacionRolSA.TienePermiso(ModuloAsegurable.LISTA_PRECIOS, AutorizacionRolList) Then
        'MessageBox.Show("Usuario autorizado")
        Dim f As New frmTablasGenerales
        'f.Size = New Size(1040, 670) ' New Size(1340, 708)
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        'Else
        'MessageBox.Show("Usuario no autorizado")
        'End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub HubTile12_Click(sender As Object, e As EventArgs) Handles HubTile12.Click
        Dim F As New frmMasterModelReporte
        F.StartPosition = FormStartPosition.CenterParent
        F.ShowDialog()
    End Sub

    Private Sub Panel37_Click(sender As Object, e As EventArgs) Handles Panel37.Click
        Dim f As New frmCostoVenta2
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub Panel37_Paint(sender As Object, e As PaintEventArgs) Handles Panel37.Paint

    End Sub

    Private Sub HubTile11_Click_1(sender As Object, e As EventArgs) Handles HubTile11.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmCashFlow ' frmselectCierre
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SplitButton2_Click(sender As Object, e As EventArgs) Handles SplitButton2.Click

    End Sub
End Class