Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools

Public Class FormTablaPrincipalRestaurantPOS

#Region "Attributes"
    Property detalleitemsSA As New detalleitemsSA
    Private UCProformasByUsuario As UCProformasByUsuario
    Private UCPreVentasByUsuario As UCPreVentasByUsuario
    Dim i As Integer = 0
    'Public Property objPleaseWait As FeedbackForm2
    Public Property ConfiguracionInicioSA As New ConfiguracionInicioSA
    Public Property entidadSA As New entidadSA
    Public Property configuracionCuentasSA As New EstadosFinancierosConfiguracionPagosSA
    Public Property usuarioListSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA
    Public Property cajaUsuarioSA As New cajaUsuarioSA
    Private datosSA As New datosGeneralesSA
    '   Dim DockingClientPanel As DockingClientPanel
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'DockingClientPanel = New DockingClientPanel With {.BorderStyle = BorderStyle.None, .BackColor = Color.White, .Size = New Drawing.Size(974, 554)}
        'GradientPrincipal.Controls.Add(DockingClientPanel)
        'DockingClientPanel.Controls.Add(PanelHeader1)
        'DockingClientPanel.Controls.Add(PanelHeader2)
        'DockingClientPanel.Controls.Add(PanelBody)
        'DockingClientPanel.Controls.Add(PictureLoading)
        '   DockingClientPanel.Controls.Add(GradientPanel1)
        ' GradientPanel1.Visible = False


        UCProformasByUsuario = New UCProformasByUsuario With {.Dock = DockStyle.Fill, .Visible = False}
        UCPreVentasByUsuario = New UCPreVentasByUsuario With {.Dock = DockStyle.Fill, .Visible = True}
        PanelBody.Controls.Add(UCProformasByUsuario)
        PanelBody.Controls.Add(UCPreVentasByUsuario)
    End Sub
    Private Sub GetMenuModulos()
        With TreeViewMenu
            .Nodes.Add("Nueva compra")
            .Nodes.Add("Precios")
            .Nodes.Add("Mantenimiento general")
            '.Nodes.Add("Servicios")
            '.Nodes.Add("")
            '.Nodes.Add("")
        End With
    End Sub

    Private Sub FormLogeoNuevo()
        ' GetDeshabilitarControles()

        'objPleaseWait = New FeedbackForm2()
        'objPleaseWait.StartPosition = FormStartPosition.CenterScreen
        'objPleaseWait.Show()
        Application.DoEvents()
        GetConfiguracionInicioBasico()
        If bg.IsBusy <> True Then
            ' Start the asynchronous operation.
            bg.RunWorkerAsync()
        End If
    End Sub

    Private Sub GetConfiguracionInicioBasico()
        Dim cierreSA As New empresaCierreMensualSA
        Dim tipoCambioSA As New tipoCambioSA
        Dim configuracion As New configuracionInicio
        Dim inicio = ConfiguracionInicioSA.ObtenerConfigXempresa(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Dim anioSA As New empresaPeriodoSA

        '   LinkLabel2.Visible = False
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

        'Dim tipoCambioDelDia = tipoCambioSA.ObtenerTipoCambioXfecha(Gempresas.IdEmpresaRuc, Date.Now.Date)

        'If tipoCambioDelDia Is Nothing Then
        '    'Agregar nueva instancia
        '    Dim objTC As New tipoCambio With
        '                          {
        '                          .idEmpresa = Gempresas.IdEmpresaRuc,
        '                          .fechaIgv = Date.Now,
        '                          .idRegulador = 100,
        '                          .compra = 3,
        '                          .venta = 3,
        '                          .usuarioModificacion = usuario.IDUsuario,
        '                          .fechaModificacion = Date.Now
        '                          }

        '    tipoCambioSA.InsertTC(objTC)
        '    tipoCambioDelDia = objTC
        'Else
        '    'utilizar instancia recuperada
        'End If


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
                .usacronogramapago = False,
                .FormatoVenta = "MKT"
                }

        If inicio Is Nothing Then
            'crear nueva instancia
            ConfiguracionInicioSA.InsertConfigInicio(configuracion)
            inicio = configuracion
            tmpConfigInicio = configuracion
        Else
            'actualizar instancia creada
            configuracion.iva = inicio.iva
            configuracion.montoMaximo = inicio.montoMaximo
            ConfiguracionInicioSA.EditarConfigInicio(configuracion)
            tmpConfigInicio = inicio
        End If

        'Variables y etiquetas
        AnioGeneral = existeAnio.periodo
        MesGeneral = String.Format("{0:00}", Date.Now.Month)
        DiaLaboral = Date.Now
        PeriodoGeneral = String.Format("{0:00}", Date.Now.Month) & "/" & existeAnio.periodo

        TmpTipoCambio = 3
        TmpTipoCambioTransaccionCompra = 3
        TmpTipoCambioTransaccionVenta = 3
        TmpIGV = inicio.iva
        MontoMaximoCliente = inicio.montoMaximo

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
        'CaptionLabels(1).Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
        TextUsuario.Text = usuario.CustomUsuario.Full_Name
    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton7.Click, BunifuFlatButton6.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "Proformas"
                UCPreVentasByUsuario.Visible = False
                UCProformasByUsuario.Visible = True

            Case "Pre ventas"
                UCProformasByUsuario.Visible = False
                UCPreVentasByUsuario.Visible = True
        End Select
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim f As New FormControlRestaurant(1)
        'f.ComboComprobante.Enabled = False
        'f.ComboComprobante.Text = "PRE VENTA"
        f.StartPosition = FormStartPosition.CenterParent
        f.Show(Me)
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New FormVentaNueva
        f.ComboComprobante.Enabled = False
        f.ComboComprobante.Text = "PROFORMA"
        f.StartPosition = FormStartPosition.CenterParent
        f.Show(Me)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        i += 1000
        If i = 1000 Then
            i = 0
            Timer1.Stop()
            FormLogeoNuevo()
            'FormLogeo()
        End If
        PanelBody.Enabled = True
    End Sub

    Private Sub bg_DoWork(sender As Object, e As DoWorkEventArgs) Handles bg.DoWork

        VarClienteGeneral = entidadSA.UbicarEntidadVarios("VR", General.Gempresas.IdEmpresaRuc, String.Empty, GEstableciento.IdEstablecimiento)
        UsuariosList = usuarioListSA.ListadoUsuariosv2()
        Seguridad.General.ListaUsuariosSoftpack = UsuariosList
        CustomListaDatosGenerales = datosSA.UbicaEmpresaFull(New datosGenerales With {.idEmpresa = Gempresas.IdEmpresaRuc})
        ListadoProductosSingleton = detalleitemsSA.GetProductosWithInventario(New detalleitems With {
                                                                              .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                              .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                              .descripcionItem = ""
                                                                              })
    End Sub

    Private Sub bg_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bg.RunWorkerCompleted
        DockingClientPanel1.BorderStyle = BorderStyle.None
        dockingManager1.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.VS2010
        dockingManager1.ShowCaption = True
        dockingManager1.SetDockLabel(GradientPanel1, "Modulos adicionales")
        dockingManager1.DockControlInAutoHideMode(GradientPanel1, DockingStyle.Left, 219)
        GetMenuModulos()

        PictureLoading.Visible = False
        PanelHeader1.Visible = True
        PanelHeader2.Visible = True
        GradientPanel1.Visible = True
    End Sub

    Private Sub FormTablaPrincipalPOS_Load(sender As Object, e As EventArgs) Handles Me.Load
        Centrar(Me)
        Timer1.Enabled = True
    End Sub

    Private Sub bunifuImageButton2_Click(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click
        Me.Close()
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

    Private Sub FormTablaPrincipalPOS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBoxAdv.Show("S O F T - P A C K, ¿Desea salir?", "Salir del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            TerminarProceso("Helios.Cont.Presentation.WinForm")
            TerminarProceso("SMSvcHost.exe")
            Application.ExitThread()
            'bg.s

            If bg IsNot Nothing Then

            End If
            '       bg.CancelAsync()
        Else
            e.Cancel = True
        End If
    End Sub
#End Region

#Region "Events"
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData

            Case Keys.F1
                Dim f As New FormVentaNueva
                f.ComboComprobante.Enabled = False
                f.ComboComprobante.Text = "PRE VENTA"
                f.StartPosition = FormStartPosition.CenterParent
                f.Show(Me)

            Case Keys.F2
                Dim f As New FormVentaNueva
                f.ComboComprobante.Enabled = False
                f.ComboComprobante.Text = "PROFORMA"
                f.StartPosition = FormStartPosition.CenterParent
                f.Show(Me)

            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Dim user = UsuariosList.Where(Function(o) o.codigo = TextCodigo.Text.Trim).FirstOrDefault
        If user IsNot Nothing Then
            usuario = user.AutenticacionUsuario
        End If
    End Sub

    Private Sub TreeViewMenu_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeViewMenu.NodeMouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        If TreeViewMenu.SelectedNode IsNot Nothing Then
            Select Case TreeViewMenu.SelectedNode.Text
                Case "Nueva compra"
                    If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVA_COMPRA_Formulario___, AutorizacionRolList) Then
                        Dim f As New FormCrearCompra("COMPRAS")
                        f.ComboComprobante.Enabled = False
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog(Me)
                    Else
                        MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Case "Precios"
                    Dim FormPrecios = New FormExistenciaPreciosEquivalenciaV2
                    FormPrecios.StartPosition = FormStartPosition.CenterScreen
                    FormPrecios.Show(Me)
                Case "Mantenimiento general"
                    Dim f As New FormMantenimientoGeneral
                    f.StartPosition = FormStartPosition.CenterScreen
                    f.Show(Me)

            End Select
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PanelHeader1_Paint(sender As Object, e As PaintEventArgs) Handles PanelHeader1.Paint

    End Sub
#End Region

End Class