Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class FormPrincipalTranportes
#Region "Attributes"
    Public Property i As Integer
    Public Property objPleaseWait As FeedbackForm2
    Public Property entidadSA As New entidadSA
    Dim configuracionCuentasSA As New EstadosFinancierosConfiguracionPagosSA
    Public Property cajaUsuarioSA As New cajaUsuarioSA
    Public Property usuarioListSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA
    Public Property ConfiguracionInicioSA As New ConfiguracionInicioSA
    Public Property trans_Vehiculos As UCMaestroActivo
    Public Property FormMeaestroRutas As UCMaestroRutas
    Public Property TR_AsinarRutaVehiculo As UCAsignarRuta
    Public Property FormPreciosVehiculo As FormPreciosVehiculo
    Public Property UC_VentaPasajes As UC_VentaPasajes
    Public Property TabFN_CuentasFinancieras As TabFN_CuentasFinancieras
    Public Property UCPantallaEmbarque As UCPantallaEmbarque
    Public Property UCEncomiendas As UCEncomiendas
    Public Property UCFinanzasTrasnportes As UCFinanzasTrasnportes
    'Public Property UCMaestroAgencias As UCMaestroAgencia
    Public Property PersonaSA As New PersonaSA
    Public Property moduloConfiguracionSA As New ModuloConfiguracionSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Timer1.Enabled = True
        GroupBar1.BorderStyle = BorderStyle.None

    End Sub

#End Region

#Region "Methods"

    Public Sub AlertasPSE()
        Dim documentosa As New DocumentoventaTransporteSA

        'Dim consulta = documentosa.AlertaPSETrasporte(Gempresas.IdEmpresaRuc)

        ' Dim Cant = (consulta.CantFact + consulta.CantNotaFact + consulta.CantFactAnu +
        'consulta.CantBol + consulta.CantNotaBol + consulta.CantBolAnu)

        Dim consulta = documentosa.AlertaEnvioPSETrasporte(Gempresas.IdEmpresaRuc)
        Dim Cant = (consulta.CpePen + consulta.AnuPen)

        If Cant > 0 Then
            If My.Computer.Network.IsAvailable = True Then

                Dim f As New FormEnviosPendientesPse  'frmMasterFacturacionPSE
                f.StartPosition = FormStartPosition.CenterParent
                f.lblAnulados.Text = consulta.AnuPen
                f.lblCpe.Text = consulta.CpePen
                f.ShowDialog()

                'MsgBox("Tengo conexión a Internet")
                'Dim f As New frmMasterPSETransporte 'frmMasterFacturacionPSE

                'f.lblFacturasPendientes.Text = consulta.CantFact
                'f.lblNotasPendiente.Text = consulta.CantNotaFact
                'f.lblFacturasAnuladas.Text = consulta.CantFactAnu

                'f.lblboletaspendientes.Text = consulta.CantBol
                'f.lblnotaboletas.Text = consulta.CantNotaBol
                'f.LBLBOLETASELIMINADAS.Text = consulta.CantBolAnu


                'f.StartPosition = FormStartPosition.CenterParent
                'f.ShowDialog()
            Else
                MsgBox("NO TIENE ACCESO A INTERNET !!ALERTA TIENE CPE PENDIENTES DE ENVIO")
                'MsgBox("No tengo conexión a Internet")
            End If
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

        'txtAnio.Value = New Date(existeAnio.periodo, Date.Now.Month, 1)
        'Label5.Text = "Período: " & String.Format("{0:00}", Date.Now.Month) & "/" & existeAnio.periodo
        'lblEmpresa.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
        'Label24.Text = GEstableciento.NombreEstablecimiento
        'Label15.Text = usuario.Alias

        'If Gempresas.ubigeo > 0 Then 'si usa facturacion electronica
        '    AlertasPSE()

        'End If

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
        LabelUsuario.Text = "USUARIO:" & vbCrLf & usuario.Alias
    End Sub

    Private Sub FormLogeoNuevo()
        ' GetDeshabilitarControles()

        objPleaseWait = New FeedbackForm2()
        objPleaseWait.StartPosition = FormStartPosition.CenterScreen
        objPleaseWait.Show()
        Application.DoEvents()
        GetConfiguracionInicioBasico()
        If bg.IsBusy <> True Then
            ' Start the asynchronous operation.
            bg.RunWorkerAsync()
        End If
    End Sub

    Private Sub GetConfiguracionpagos()
        Dim pagoSA As New EstadosFinancierosConfiguracionPagosSA

        ListConfigurationPays = New List(Of estadosFinancierosConfiguracionPagos)
        ListConfigurationPays = pagoSA.GetConfigurationPay(New estadosFinancierosConfiguracionPagos With
                {
                .idEmpresa = Gempresas.IdEmpresaRuc,
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                                                           })

    End Sub

    Public Sub cargarEncominda()
        sliderTop.Left = (CType(BunifuFlatButton15, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(BunifuFlatButton15, Bunifu.Framework.UI.BunifuFlatButton)).Width

        UCEncomiendas = New UCEncomiendas With
                      {
                      .Dock = DockStyle.Fill
                  }
        UCEncomiendas.BringToFront()
        PanelBody.Controls.Add(UCEncomiendas)
    End Sub

#End Region


#Region "Events"
    Private Sub bunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles bunifuFlatButton7.Click, BunifuFlatButton5.Click, BunifuFlatButton4.Click, BunifuFlatButton3.Click, BunifuFlatButton2.Click, BunifuFlatButton1.Click, BunifuFlatButton15.Click, BunifuFlatButton16.Click, BunifuFlatButton17.Click
        Try
            sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
            sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
            Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
            PanelBody.Controls.Clear()
            Select Case btn.Text
                Case "AGENCIA"
                    'UCMaestroAgencias = New UCMaestroAgencia With {
                    '    .Dock = DockStyle.Fill
                    '}
                    'UCMaestroAgencias.BringToFront()
                    'PanelBody.Controls.Add(UCMaestroAgencias)
                Case "RUTAS"
                    FormMeaestroRutas = New UCMaestroRutas() With {
                        .Dock = DockStyle.Fill
                    }
                    FormMeaestroRutas.BringToFront()
                    PanelBody.Controls.Add(FormMeaestroRutas)

                Case "ASIGNAR RUTAS"
                    TR_AsinarRutaVehiculo = New UCAsignarRuta() With {
                        .Dock = DockStyle.Fill
                    }
                    TR_AsinarRutaVehiculo.BringToFront()
                    PanelBody.Controls.Add(TR_AsinarRutaVehiculo)
                Case "PRECIOS"
                    FormPreciosVehiculo = New FormPreciosVehiculo() With {
                      .Dock = DockStyle.Fill
                    }
                    FormPreciosVehiculo.BringToFront()
                    PanelBody.Controls.Add(FormPreciosVehiculo)

                Case "VENTA"
                    UC_VentaPasajes = New UC_VentaPasajes() With {
                    .Dock = DockStyle.Fill
                    }
                    UC_VentaPasajes.BringToFront()
                    PanelBody.Controls.Add(UC_VentaPasajes)

                Case "ZONA EMBARQUE"
                    UCPantallaEmbarque = New UCPantallaEmbarque() With {
                        .Dock = DockStyle.Fill
                    }
                    UCPantallaEmbarque.BringToFront()
                    PanelBody.Controls.Add(UCPantallaEmbarque)

                Case "ENCOMIENDAS"
                    UCEncomiendas = New UCEncomiendas With
                        {
                        .Dock = DockStyle.Fill
                    }
                    UCEncomiendas.BringToFront()
                    PanelBody.Controls.Add(UCEncomiendas)

                Case "CUENTAS"
                    UCFinanzasTrasnportes = New UCFinanzasTrasnportes() With {
                        .Dock = DockStyle.Fill
                    }
                    UCFinanzasTrasnportes.BringToFront()
                    PanelBody.Controls.Add(UCFinanzasTrasnportes)

                Case "INFRAESTRUCTURA"
                    'Dim f As New FormVentaPasajes
                    'f.StartPosition = FormStartPosition.CenterScreen
                    'f.ShowDialog(Me)
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click, BunifuFlatButton9.Click, BunifuFlatButton8.Click
        slideLog.Top = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Top
        slideLog.Height = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Height
    End Sub

    Private Sub BunifuFlatButton12_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton12.Click, BunifuFlatButton14.Click, BunifuFlatButton13.Click, BunifuFlatButton11.Click, BunifuFlatButton10.Click
        slideComercial.Top = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Top
        slideComercial.Height = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Height
    End Sub

    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    i += 1000
    '    If i = 1000 Then
    '        i = 0
    '        Timer1.Stop()
    '        FormLogeoNuevo()
    '        'FormLogeo()
    '    End If
    '    Panel1.Enabled = True
    'End Sub

    Private Sub bg_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bg.DoWork
        'VarClienteGeneral = entidadSA.UbicarEntidadVarios("VR", General.Gempresas.IdEmpresaRuc, String.Empty)
        'Transporte.ListaModulosNumeracion = moduloConfiguracionSA.ListaModulosConfigurados(Gempresas.IdEmpresaRuc)

        'Transporte.ListaEmpresas = entidadSA.ObtenerListaEntidad("CL", Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)

        'Transporte.ListaPersonas = PersonaSA.ObtenerPersona(Gempresas.IdEmpresaRuc)

        'ListaCuentasFinancierasConfiguradas = configuracionCuentasSA.GetConfigurationPay(New estadosFinancierosConfiguracionPagos With
        '                                     {
        '                                     .idEmpresa = Gempresas.IdEmpresaRuc,
        '                                     .idEstablecimiento = GEstableciento.IdEstablecimiento
        '                                     })
        'UsuariosList = usuarioListSA.ListadoUsuariosv2()
        'ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
        '                                                     .idEmpresa = Gempresas.IdEmpresaRuc,
        '                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '                                                     .estadoCaja = "A"
        '                                                     })

        'GetConfiguracionpagos()


    End Sub

    Private Sub bg_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bg.RunWorkerCompleted
        'GetHabilitarControles()
        objPleaseWait.Close()
        UCEncomiendas = New UCEncomiendas With
                {
                .Dock = DockStyle.Fill
            }
        UCEncomiendas.BringToFront()
        PanelBody.Controls.Add(UCEncomiendas)
        BunifuFlatButton16.Enabled = True
    End Sub

    Private Sub BunifuCustomLabel7_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel7.Click
        Dim empresaSA As New empresaSA
        empresaSA.CrearBackupDatabase()
        MessageBox.Show("Backup creado con exito!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Dim cn As New SqlClient.SqlConnection("Data Source =.; Initial Catalog = HELIOS; User Id=jiu; Password=123;")
        'cn.Open()
        'Dim sql As String = "BACKUP DATABASE HELIOS TO DISK ='" & "D:\" & "Helios" & "' WITH INIT , NOUNLOAD , NAME ='" & "Helios" & "', NOSKIP , STATS = 10, NOFORMAT"
        'Dim cmd As New SqlClient.SqlCommand(sql, cn)
        'cmd.ExecuteNonQuery()
        'cn.Close()
        'cn.Dispose()
    End Sub

    Private Sub BunifuCustomLabel5_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel5.Click
        'Dim cn As New SqlClient.SqlConnection("Data Source=.; Initial Catalog=master; Integrated Security=True")
        'cn.Open()
        ''Dim sql As String = "BACKUP DATABASE HELIOS TO DISK ='" & "D:\" & "Helios.bak" & "' WITH INIT , NOUNLOAD , NAME ='" & "Helios-backup" & "', NOSKIP , STATS = 10, NOFORMAT"

        'Dim sql = "RESTORE DATABASE HELIOS FROM DISK='C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\Backup\HELIOS201902161251' WITH REPLACE, NOUNLOAD,  STATS = 10; "

        'Dim cmd As New SqlClient.SqlCommand(sql, cn)
        'cmd.ExecuteNonQuery()
        'cn.Close()
        'cn.Dispose()
    End Sub

    Private Sub BunifuCustomLabel10_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel10.Click
        Me.Cursor = Cursors.WaitCursor

        Try



            'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ABRIR_CAJA_Formulario___, AutorizacionRolList) Then
            Dim f As New FormCrearCajero
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)


        Catch ex As Exception

        End Try
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub FormPrincipalTranportes_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim objFormResizer As New FormResizer
        'objFormResizer.ResizeForm(Me, 864, 1152)
        Centrar(Me)
    End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BtnCuentasFinancieras.Click, BtnConfiguracion.Click
        PanelBody.Controls.Clear()

        SliderFinanzas.Top = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Top
        SliderFinanzas.Height = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Height


        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        PanelBody.Controls.Clear()
        Select Case btn.Text
            Case "   Cuentas Financieras"
                TabFN_CuentasFinancieras = New TabFN_CuentasFinancieras() With {
                .Dock = DockStyle.Fill
              }
                TabFN_CuentasFinancieras.BringToFront()
                PanelBody.Controls.Add(TabFN_CuentasFinancieras)
            Case "   Configuración de pagos"

        End Select


    End Sub

    Private Sub bunifuImageButton2_Click(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click


        'If Gempresas.ubigeo > 0 Then

        '    AlertasPSE()

        'End If
        ''If MessageBox.Show("S O F T - P A C K, ¿Desea salir?", "Salir del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        ''    TerminarProceso("Helios.Cont.Presentation.WinForm")
        ''    TerminarProceso("SMSvcHost.exe")
        ''    Application.ExitThread()
        ''    'bg.s

        ''    If bg IsNot Nothing Then

        ''    End If
        ''    '       bg.CancelAsync()
        ''Else
        ''    e.Cancel = True
        ''End If

        Close()
    End Sub

    Private Sub BunifuCustomLabel9_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel9.Click
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.FACTURACION_ELECTRONICA___, AutorizacionRolList) Then
        'Dim f As New frmMasterPSETransporte
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog(Me)

        ' Else
        'MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BunifuCustomLabel6_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel6.Click
        Dim f As New FormConfiguracionPago
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
    End Sub

    Private Sub panelheader_Paint(sender As Object, e As PaintEventArgs) Handles panelheader.Paint

    End Sub

    Private Sub BunifuCustomLabel11_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel11.Click
        FormLogeoNuevo()
    End Sub

    'Private Function TerminarProceso(ByVal StrNombreProceso As String,
    ''Optional ByVal DecirSINO As Boolean = True) As Boolean
    '    '    ' Variables para usar Wmi  
    '    '    Dim ListaProcesos As Object
    '    '    Dim ObjetoWMI As Object
    '    '    Dim ProcesoACerrar As Object

    '    '    TerminarProceso = False

    '    '    ObjetoWMI = GetObject("winmgmts:")

    '    '    If ObjetoWMI Is DBNull.Value = False Then

    '    '        'instanciamos la variable  
    '    '        ListaProcesos = ObjetoWMI.InstancesOf("win32_process")

    '    '        For Each ProcesoACerrar In ListaProcesos
    '    '            If UCase(ProcesoACerrar.Name) = UCase(StrNombreProceso) Then
    '    '                If DecirSINO Then
    '    '                    '   If MsgBox("¿Matar el proceso " & _
    '    '                    'ProcesoACerrar.Name & vbNewLine & "...¿Está seguro?", _
    '    '                    '                      vbYesNo + vbCritical) = vbYes Then

    '    '                    ProcesoACerrar.Terminate(0)
    '    '                    TerminarProceso = True
    '    '                    '  End If
    '    '                Else
    '    '                    'Matamos el proceso con el método Terminate  
    '    '                    ProcesoACerrar.Terminate(0)
    '    '                    TerminarProceso = True
    '    '                End If
    '    '            End If

    '    '        Next
    '    '    End If

    '    '    'Elimina las variables  
    '    '    ListaProcesos = Nothing
    '    '    ObjetoWMI = Nothing
    'End Function

    Private Sub FormPrincipalTranportes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        'If Gempresas.ubigeo > 0 Then
        '    AlertasPSE()
        'End If

        'If MessageBox.Show("S O F T - P A C K, ¿Desea salir?", "Salir del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        '    TerminarProceso("Helios.Cont.Presentation.WinForm")
        '    TerminarProceso("SMSvcHost.exe")
        '    Application.ExitThread()
        '    'bg.s

        '    If bg IsNot Nothing Then

        '    End If
        '    '       bg.CancelAsync()
        'Else
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub BtMaximizar_Click(sender As Object, e As EventArgs) Handles BtMaximizar.Click
        If WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        Else
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub sliderTop_Click(sender As Object, e As EventArgs) Handles sliderTop.Click

    End Sub
#End Region
End Class