Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid

Public Class FormTablaPrincipalCaja

#Region "Attributes"
    Private listaActivas As List(Of cajaUsuario)

    Private FormImpresionNuevo As FormImpresionEquivalencia
    Public Property SelRazon As entidad
    Public Alert As Alert
    Dim conf As New GConfiguracionModulo
    Property detalleitemsSA As New detalleitemsSA
    Dim i As Integer = 0
    'Public Property objPleaseWait As FeedbackForm2
    Public Property ConfiguracionInicioSA As New ConfiguracionInicioSA
    Public Property entidadSA As New entidadSA
    Public Property configuracionCuentasSA As New EstadosFinancierosConfiguracionPagosSA
    Public Property usuarioListSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA

    Public Property cajaUsuarioSA As New cajaUsuarioSA
    Private datosSA As New datosGeneralesSA

    Public Property DocumentoVenta As documentoventaAbarrotes
    '   Dim DockingClientPanel As DockingClientPanel

    Private cliventa As entidad
    Public Property CuentasHabilitadas As List(Of estadosFinancierosConfiguracionPagos)
    Private UCResumenVentas As UCResumenVentas
    Private UCCuentasXcobrar As UCCuentasXcobrar
    Private UCCuentasXpagar As UCCuentasXpagar



#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.KeyPreview = True
        txtTotalPagar.FrameBorderColor = Color.FromArgb(22, 163, 95)
        FormatoGridAvanzado(dgvCuentas, False, False)
        GetColumnsGrid()
        UCResumenVentas = New UCResumenVentas(Me) With {.Dock = DockStyle.Fill, .Visible = False}
        UCCuentasXcobrar = New UCCuentasXcobrar With {.Dock = DockStyle.Fill, .Visible = False}
        UCCuentasXpagar = New UCCuentasXpagar With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBody.Controls.Add(UCResumenVentas)
        PanelBody.Controls.Add(UCCuentasXcobrar)
        PanelBody.Controls.Add(UCCuentasXpagar)

        'GetDocsVenta()

    End Sub
#End Region

#Region "Metodos"

    Public Function SumaPagosME() As Decimal
        SumaPagosME = 0
        For Each h In dgvCuentas.Table.Records
            'If i.GetValue("moneda") = "2" Then
            SumaPagosME += CDec(h.GetValue("abonadoME"))
            ' End If
        Next
        SumaPagosME = SumaPagosME
        '  TextPagadoME.DecimalValue = SumaPagosME
        Return SumaPagosME
    End Function
    Sub GetCajasActivas()
        Dim UsuarioBE = New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        UsuarioBE.idEmpresa = Gempresas.IdEmpresaRuc
        UsuarioBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        UsuarioBE.estadoCaja = "A"


        If GconfigCaja = "2" Then
            Dim query = (From i In ListaCajasActivas
                         Where i.idPersona = usuario.IDUsuario And i.estadoCaja = "A").ToList
            listaActivas = query

            ComboCaja.DataSource = listaActivas
            ComboCaja.ValueMember = "idcajaUsuario" ' "IDUsuario"
            ComboCaja.DisplayMember = "NombrePersona"
        Else
            listaActivas = cajaUsuarioSA.ListadoCajaXEstado(UsuarioBE)

            ComboCaja.DataSource = listaActivas
            ComboCaja.ValueMember = "idcajaUsuario" ' "IDUsuario"
            ComboCaja.DisplayMember = "NombrePersona"
        End If



    End Sub
    Private Sub FormLogeoNuevoIntro()
        'Dim Login As New FormOrgainizacion
        'Login.StartPosition = FormStartPosition.CenterParent
        'Login.ShowDialog(Me)
        'Application.DoEvents()
        'GetConfiguracionInicioBasico()
        'If bg.IsBusy <> True Then
        '    ' Start the asynchronous operation.
        '    bg.RunWorkerAsync()
        'End If

        Me.Dispose()
        Dim Login As New FormOrgainizacion
        Login.StartPosition = FormStartPosition.CenterParent
        Login.ShowDialog()
        Application.DoEvents()
        'GetConfiguracionInicioBasico()
        'If bg.IsBusy <> True Then
        '    ' Start the asynchronous operation.
        '    bg.RunWorkerAsync()
        'End If

    End Sub

    Public Sub CargarAlertaArqueo()

        Dim cajaSA As New cajaUsuarioSA
        Dim be As New cajaUsuario
        be.idEmpresa = Gempresas.IdEmpresaRuc
        be.idEstablecimiento = GEstableciento.IdEstablecimiento
        be.idPersona = usuario.IDUsuario

        Dim Cant = cajaSA.ListBoxClosedPendingUser(be)
        BunifuCustomLabel18.Text = Cant

        ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                             .estadoCaja = "A"
                                                             })


        Dim querybox = (From i In ListaCajasActivas
                        Where i.idPersona = usuario.IDUsuario And i.estadoCaja = "A").FirstOrDefault

        If querybox IsNot Nothing Then
            BunifuFlatButton3.Text = "ABIERTO"
            BunifuFlatButton3.Textcolor = Color.FromArgb(250, 203, 81)
        Else
            BunifuFlatButton3.Text = "CERRADO"
            BunifuFlatButton3.Textcolor = Color.FromKnownColor(KnownColor.Red)
        End If

    End Sub

    Public Sub LogeoUsuarioCaja()
        Try


            Dim usuarioSel = UsuariosList.Where(Function(o) o.IDUsuario = usuario.IDUsuario).FirstOrDefault
            If usuarioSel IsNot Nothing Then
                BunifuFlatButton2.Text = usuarioSel.Full_Name
                BunifuFlatButton2.Tag = usuarioSel.IDUsuario


                'Dim cargo = (From i In PositionList Where i.idCargo = usuarioSel.idCargo).FirstOrDefault

                'If cargo IsNot Nothing Then

                '    BunifuFlatButton1.Text = cargo.descripcion

                'End If


                Dim cajaAct = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario).SingleOrDefault


                If cajaAct IsNot Nothing Then


                    BunifuFlatButton3.Text = "ABIERTO"
                    BunifuFlatButton3.Textcolor = Color.FromArgb(250, 203, 81)

                End If

                Dim cajaSA As New cajaUsuarioSA
                Dim be As New cajaUsuario
                be.idEmpresa = Gempresas.IdEmpresaRuc
                be.idEstablecimiento = GEstableciento.IdEstablecimiento
                be.idPersona = usuario.IDUsuario

                Dim Cant = cajaSA.ListBoxClosedPendingUser(be)
                BunifuCustomLabel18.Text = Cant

                'TextRuc.Text = usuarioSel.NroDocumento
                'TextCodigoVendedor.Text = usuarioSel.codigo
                'RoundButton21.Enabled = True
                'Me.Size = New Size(732, 496)
                'Centrar(Me)
                'Else
                '    TextPeersona.Text = String.Empty
                '    TextPeersona.Tag = String.Empty
                '    TextRuc.Text = String.Empty
                '    RoundButton21.Enabled = False
                '    Me.Size = New Size(732, 139)
                '    Centrar(Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.F1
                Click_Boton_Importar()
            Case Keys.F2
                Boton_Grabar()

        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    'Sub Getclientepedido()
    '    Dim vendedor = UsuariosList.Where(Function(o) o.IDUsuario = DocumentoVenta.usuarioActualizacion).SingleOrDefault

    '    TextCodigoVendedor.Text = vendedor.Full_Name

    '    TextComprador.Text = DocumentoVenta.nombrePedido
    '    Label15.Text = $"{"Pedido Nro:"} {DocumentoVenta.serieVenta}-{DocumentoVenta.numeroVenta}"
    '    Select Case DocumentoVenta.tipoDocumento
    '        Case "01"
    '            cboTipoDoc.Text = "FACTURA"
    '        Case "03"
    '            cboTipoDoc.Text = "BOLETA"
    '        Case "9907"
    '            cboTipoDoc.Text = "NOTA DE VENTA"
    '    End Select

    '    Select Case DocumentoVenta.moneda
    '        Case "1"
    '            cboMoneda.Text = "NACIONAL"
    '        Case Else
    '            cboMoneda.Text = "EXTRANJERA"
    '    End Select

    '    If cliventa IsNot Nothing Then
    '        TextNumIdentrazon.Text = cliventa.nrodoc
    '        TextProveedor.Text = cliventa.nombreCompleto
    '        TextProveedor.Tag = cliventa.idEntidad
    '        If RadioButton2.Checked Then
    '            TextProveedor.Text = DocumentoVenta.nombrePedido
    '        End If
    '    End If
    'End Sub

    Sub Getclientepedido()
        Dim vendedor = UsuariosList.Where(Function(o) o.IDUsuario = DocumentoVenta.usuarioActualizacion).SingleOrDefault

        If vendedor IsNot Nothing Then
            TextCodigoVendedor.Text = vendedor.Full_Name
        End If

        TextComprador.Text = DocumentoVenta.nombrePedido
        Label15.Text = $"{"Pedido Nro:"} {DocumentoVenta.serieVenta}-{DocumentoVenta.numeroVenta}"
        Select Case DocumentoVenta.tipoDocumento
            Case "01"
                cboTipoDoc.Text = "FACTURA"
            Case "03"
                cboTipoDoc.Text = "BOLETA"
            Case "9907"
                cboTipoDoc.Text = "NOTA DE VENTA"
        End Select

        Select Case DocumentoVenta.moneda
            Case "1"
                cboMoneda.Text = "NACIONAL"
            Case Else
                cboMoneda.Text = "EXTRANJERA"
        End Select

        If cliventa IsNot Nothing Then
            TextNumIdentrazon.Text = cliventa.nrodoc
            TextProveedor.Text = cliventa.nombreCompleto
            TextProveedor.Tag = cliventa.idEntidad
            If RadioButton2.Checked Then
                TextProveedor.Text = DocumentoVenta.nombrePedido
            End If
        End If
        'VUELTO
        TextTotalPagosCliente.DecimalValue = 0
        'LabelTotalCobrarCliente.Text = "0.00"
        LabelVueltoCliente.Text = "0.00"
        '***********************************************
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

        TextUsuario.Text = usuario.CustomUsuario.Full_Name



        'ValidandoCierre
        Dim fechaAnt = New Date(Date.Now.Year, CInt(Date.Now.Month), 1)
        fechaAnt = fechaAnt.AddMonths(-1)
        'Dim periodoAnteriorEstaCerrado As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})


        Dim periodoAnteriorEstaCerrado As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
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

    'Sub CalculosMontos()
    '    txtTotalBase.DecimalValue = DocumentoVenta.bi01.GetValueOrDefault
    '    txtTotalBase2.DecimalValue = DocumentoVenta.bi02.GetValueOrDefault
    '    txtTotalBase3.DecimalValue = 0
    '    txtTotalIva.DecimalValue = DocumentoVenta.igv01.GetValueOrDefault
    '    TextSubTotal.DecimalValue = DocumentoVenta.ImporteNacional.GetValueOrDefault + DocumentoVenta.importeCostoMN.GetValueOrDefault
    '    txtTotalPagar.Text = TextSubTotal.DecimalValue - DocumentoVenta.importeCostoMN.GetValueOrDefault
    '    txtTotalPagar.Value = TextSubTotal.DecimalValue - DocumentoVenta.importeCostoMN.GetValueOrDefault
    '    TextTotalDescuentos.DecimalValue = DocumentoVenta.importeCostoMN.GetValueOrDefault
    'End Sub

    Sub CalculosMontos()
        If DocumentoVenta.moneda = "2" Then
            txtTotalBase.DecimalValue = DocumentoVenta.bi01us.GetValueOrDefault
            txtTotalBase2.DecimalValue = DocumentoVenta.bi02us.GetValueOrDefault
            txtTotalBase3.DecimalValue = 0
            txtTotalIcbper.DecimalValue = DocumentoVenta.icbper.GetValueOrDefault
            txtTotalIva.DecimalValue = DocumentoVenta.igv01us.GetValueOrDefault
            TextSubTotal.DecimalValue = DocumentoVenta.ImporteExtranjero.GetValueOrDefault + DocumentoVenta.importeCostoME.GetValueOrDefault
            txtTotalPagar.Text = TextSubTotal.DecimalValue - DocumentoVenta.importeCostoME.GetValueOrDefault
            txtTotalPagar.Value = TextSubTotal.DecimalValue - DocumentoVenta.importeCostoME.GetValueOrDefault
            LabelTotalCobrarCliente.Text = TextSubTotal.DecimalValue - DocumentoVenta.importeCostoMN.GetValueOrDefault
            TextTotalDescuentos.DecimalValue = DocumentoVenta.importeCostoME.GetValueOrDefault
        Else
            txtTotalBase.DecimalValue = DocumentoVenta.bi01.GetValueOrDefault
            txtTotalBase2.DecimalValue = DocumentoVenta.bi02.GetValueOrDefault
            txtTotalBase3.DecimalValue = 0
            txtTotalIcbper.DecimalValue = DocumentoVenta.icbper.GetValueOrDefault
            txtTotalIva.DecimalValue = DocumentoVenta.igv01.GetValueOrDefault
            TextSubTotal.DecimalValue = DocumentoVenta.ImporteNacional.GetValueOrDefault + DocumentoVenta.importeCostoMN.GetValueOrDefault
            txtTotalPagar.Text = TextSubTotal.DecimalValue - DocumentoVenta.importeCostoMN.GetValueOrDefault
            txtTotalPagar.Value = TextSubTotal.DecimalValue - DocumentoVenta.importeCostoMN.GetValueOrDefault
            LabelTotalCobrarCliente.Text = TextSubTotal.DecimalValue - DocumentoVenta.importeCostoMN.GetValueOrDefault
            TextTotalDescuentos.DecimalValue = DocumentoVenta.importeCostoMN.GetValueOrDefault
        End If

    End Sub

    Private Sub GetMappingColumnsGrid()
        Dim dt As New DataTable
        Dim SA As New EstadosFinancierosConfiguracionPagosSA
        With dt
            .Columns.Add("tipo")
            .Columns.Add("identidad")
            .Columns.Add("entidad")
            .Columns.Add("abonado")
            .Columns.Add("tipocambio")
            .Columns.Add("idforma")
            .Columns.Add("formaPago")
            .Columns.Add("nrooperacion")
            .Columns.Add("moneda")
            .Columns.Add("abonadoME")
        End With

        Dim usuariocaja = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario).FirstOrDefault

        If usuariocaja IsNot Nothing Then
            Dim listaCuentas = SA.GetConfigurationPayCaja(New estadosFinancierosConfiguracionPagos With
                                                 {
                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                 .IDCaja = usuariocaja.idcajaUsuario
                                                 })



            For Each j In listaCuentas.Where(Function(o) o.tipo <> "EE").ToList ' ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago <> "9991").ToList
                If CheckEfectivoDefault.Checked = True Then

                    If j.FormaPago = "EFECTIVO" And txtTotalPagar.Value > 0 Then

                        If DocumentoVenta.moneda = "1" Then
                            dt.Rows.Add(String.Empty, j.identidad, j.entidad, If(j.moneda = "1", txtTotalPagar.Value, 0), TmpTipoCambio, j.IDFormaPago, j.FormaPago, "-", j.moneda, 0)
                        Else
                            dt.Rows.Add(String.Empty, j.identidad, j.entidad, 0, TmpTipoCambio, j.IDFormaPago, j.FormaPago, "-", j.moneda, 0)
                        End If
                    Else
                        dt.Rows.Add(String.Empty, j.identidad, j.entidad, 0.0, TmpTipoCambio, j.IDFormaPago, j.FormaPago, "-", j.moneda, 0)
                    End If
                Else
                    dt.Rows.Add(String.Empty, j.identidad, j.entidad, 0.0, TmpTipoCambio, j.IDFormaPago, j.FormaPago, "-", j.moneda, 0)
                End If
            Next



            If ListaCuentasFinancierasConfiguradas.Count > 0 Then
                Dim cuponSel = ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago = "9991").SingleOrDefault
                PanelCupon.Tag = cuponSel
                TextCodigoCupon.Visible = True
                ButtonAdv4.Visible = True
            End If


            dgvCuentas.DataSource = dt
            '  lblPagoVenta.Text = CDec(txtTotalPagar.Text)
            LblPagoCredito.Visible = True
            lblPagoVenta.Visible = True

            Dim pagos As Decimal = SumaPagos()
            LblPagoCredito.Text = "SALDO POR COBRAR"
            lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(SumaPagos())
        End If
    End Sub
    'Private Sub GetMappingColumnsGrid()
    '    Dim dt As New DataTable
    '    Dim SA As New EstadosFinancierosConfiguracionPagosSA
    '    With dt
    '        .Columns.Add("tipo")
    '        .Columns.Add("identidad")
    '        .Columns.Add("entidad")
    '        .Columns.Add("abonado")
    '        .Columns.Add("tipocambio")
    '        .Columns.Add("idforma")
    '        .Columns.Add("formaPago")
    '        .Columns.Add("nrooperacion")
    '    End With

    '    Dim usuariocaja = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario).FirstOrDefault

    '    If usuariocaja IsNot Nothing Then
    '        Dim listaCuentas = SA.GetConfigurationPayCaja(New estadosFinancierosConfiguracionPagos With
    '                                             {
    '                                             .idEmpresa = Gempresas.IdEmpresaRuc,
    '                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
    '                                             .IDCaja = usuariocaja.idcajaUsuario
    '                                             })



    '        For Each i As estadosFinancierosConfiguracionPagos In listaCuentas.Where(Function(o) o.tipo <> "EE").ToList ' ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago <> "9991").ToList
    '            If CheckEfectivoDefault.Checked = True Then
    '                If i.FormaPago = "EFECTIVO" And CDec(txtTotalPagar.Text) > 0 Then
    '                    dt.Rows.Add(String.Empty, i.identidad, i.entidad, CDec(txtTotalPagar.Text), TmpTipoCambio, i.IDFormaPago, i.FormaPago, "-")



    '                Else
    '                    dt.Rows.Add(String.Empty, i.identidad, i.entidad, 0.0, TmpTipoCambio, i.IDFormaPago, i.FormaPago, "-")
    '                End If
    '            Else
    '                dt.Rows.Add(String.Empty, i.identidad, i.entidad, 0.0, TmpTipoCambio, i.IDFormaPago, i.FormaPago, "-")
    '            End If
    '        Next



    '        ' If ListaCuentasFinancierasConfiguradas.Count > 0 Then
    '        'Dim cuponSel = ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago = "9991").SingleOrDefault
    '        'PanelCupon.Tag = cuponSel
    '        'TextCodigoCupon.Visible = True
    '        'ButtonAdv4.Visible = True
    '        'End If


    '        dgvCuentas.DataSource = dt
    '        '  lblPagoVenta.Text = CDec(txtTotalPagar.Text)
    '        LblPagoCredito.Visible = True
    '        lblPagoVenta.Visible = True

    '        Dim pagos As Decimal = SumaPagos()
    '        LblPagoCredito.Text = "SALDO POR COBRAR"
    '        lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(SumaPagos())
    '    End If
    'End Sub



    'Private Sub HabilitarPago(opcion As Boolean)
    '    Select Case opcion
    '        Case True
    '            'pcLikeCategoria.Visible = True
    '            PanelVendedorInfo.Visible = True
    '            '  PanelDetalleDoc.Visible = True
    '            PanelMontos.Visible = True
    '            'Me.Size = New Size(1047, 599)

    '            For Each i As Record In dgvCuentas.Table.Records
    '                i.SetValue("abonado", 0)
    '            Next

    '            Dim pagos As Decimal = SumaPagos()

    '            LblPagoCredito.Text = "SALDO POR COBRAR"

    '            lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(SumaPagos())

    '            If (lblPagoVenta.Text = CDec(0.0)) Then
    '                ErrorProvider1.Clear()
    '            End If
    '            GetMappingColumnsGrid()
    '            PanelLoadingWaith.Visible = False
    '            BtEditar.Enabled = True
    '        Case False
    '            'pcLikeCategoria.Visible = False
    '            PanelVendedorInfo.Visible = False
    '            '  PanelDetalleDoc.Visible = False
    '            PanelMontos.Visible = False
    '            'Me.Size = New Size(834, 148)
    '            PanelLoadingWaith.Visible = True
    '            BtEditar.Enabled = False
    '    End Select
    '    Centrar(Me)
    'End Sub
    Public Sub ekje()



    End Sub
    Private Sub HabilitarPago(opcion As Boolean)
        Select Case opcion
            Case True
                'pcLikeCategoria.Visible = True
                PanelVendedorInfo.Visible = True
                '  PanelDetalleDoc.Visible = True
                PanelMontos.Visible = True
                'Me.Size = New Size(1047, 599)

                For Each h In dgvCuentas.Table.Records
                    h.SetValue("abonado", 0)
                Next



                Dim pagos As Decimal = SumaPagos()

                LblPagoCredito.Text = "SALDO POR COBRAR"

                lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(SumaPagos())

                If (lblPagoVenta.Text = CDec(0.0)) Then
                    ErrorProvider1.Clear()
                End If
                GetMappingColumnsGrid()
                PanelLoadingWaith.Visible = False
                BtEditar.Enabled = True
            Case False
                'pcLikeCategoria.Visible = False
                PanelVendedorInfo.Visible = False
                '  PanelDetalleDoc.Visible = False
                PanelMontos.Visible = False
                'Me.Size = New Size(834, 148)
                PanelLoadingWaith.Visible = True
                BtEditar.Enabled = False
        End Select
        Centrar(Me)
    End Sub

    'Sub centrar()
    '    Dim boundWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    '    Dim boundHeight As Integer = Screen.PrimaryScreen.Bounds.Height
    '    Dim x As Integer = boundWidth - Me.Width
    '    Dim y As Integer = boundHeight - Me.Height
    '    Me.Location = New Point(x \ 2, y \ 2)
    'End Sub

    Sub Reinicarcarga()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA
        Dim venta = DocumentoVentaSA.GetVentaID(New documento With {.idDocumento = DocumentoVenta.idDocumento})
        DocumentoVenta = venta
        BtOperacion.Enabled = True
        CalculosMontos()
        cliventa = venta.CustomEntidad ' entidadSA.UbicarEntidadPorID(DocumentoVenta.idCliente).FirstOrDefault
        Getclientepedido()
        HabilitarPago(True)
    End Sub

    Private Function MappingDocumento() As documento
        'Dim IDCliente As Integer = 0
        'Dim Cliente As String = String.Empty

        Dim fechaVenta = DateTime.Now


        'If UCEstructuraCabeceraVentaV2.RadioButton1.Checked = True Then ' razon social
        '    IDCliente = UCEstructuraCabeceraVentaV2.TextProveedor.Tag
        '    Cliente = UCEstructuraCabeceraVentaV2.TextProveedor.Text
        'Else ' cliente varios
        '    IDCliente = UCEstructuraCabeceraVentaV2.TextProveedor.Tag
        '    Cliente = UCEstructuraCabeceraVentaV2.TextProveedor.Text
        'End If

        MappingDocumento = New documento With
        {
         .TipoEnvio = "PREVENTA",
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .idProyecto = 0,
        .tipoDoc = cboTipoDoc.SelectedValue,
        .fechaProceso = fechaVenta,
        .moneda = "1",
        .idEntidad = TextProveedor.Tag,
        .entidad = TextProveedor.Text,
        .tipoEntidad = TIPO_ENTIDAD.CLIENTE,
        .nrodocEntidad = TextNumIdentrazon.Text,
        .nroDoc = "0",'$"{UCEstructuraCabeceraVentaV2.txtSerie.Text}-{UCEstructuraCabeceraVentaV2.txtNumero.Text}",
        .idOrden = 0,
        .tipoOperacion = StatusTipoOperacion.VENTA,
        .usuarioActualizacion = DocumentoVenta.usuarioActualizacion,' usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }
    End Function

    Private Sub MappingDocumentoCompraCabecera(be As documento)
        Dim tipoVenta As String = String.Empty
        Dim base1 As Decimal = 0
        Dim base2 As Decimal = 0

        Dim base1ME As Decimal = 0
        Dim base2ME As Decimal = 0

        Dim iva1 As Decimal = 0
        Dim iva1ME As Decimal = 0
        Dim iva2 As Decimal = 0
        Dim total As Decimal = 0 ' 
        Dim totalME As Decimal = 0 ' UCEstructuraDocumentocabecera.txtTotalPagar.DecimalValue

        Select Case be.moneda
            Case "1"
                base1 = txtTotalBase.DecimalValue
                base2 = txtTotalBase2.DecimalValue
                base1ME = Math.Round(txtTotalBase.DecimalValue / txtTipoCambio.DecimalValue, 2)
                base2ME = Math.Round(txtTotalBase2.DecimalValue / txtTipoCambio.DecimalValue, 2)
                iva1 = txtTotalIva.DecimalValue
                iva1ME = Math.Round(txtTotalIva.DecimalValue / txtTipoCambio.DecimalValue, 2)

                total = CDec(txtTotalPagar.Text)
                totalME = Math.Round(CDec(txtTotalPagar.Text) / txtTipoCambio.DecimalValue, 2)
            Case "2"

                base1ME = txtTotalBase.DecimalValue
                base2ME = txtTotalBase2.DecimalValue

                base1 = Math.Round(txtTotalBase.DecimalValue * txtTipoCambio.DecimalValue, 2)
                base2 = Math.Round(txtTotalBase2.DecimalValue * txtTipoCambio.DecimalValue, 2)

                iva1ME = txtTotalIva.DecimalValue
                iva1 = Math.Round(txtTotalIva.DecimalValue * txtTipoCambio.DecimalValue, 2)

                totalME = CDec(txtTotalPagar.Text)
                total = Math.Round(CDec(txtTotalPagar.Text) * txtTipoCambio.DecimalValue, 2)
        End Select


        Select Case be.tipoDoc
            Case "9907"
                tipoVenta = TIPO_VENTA.NOTA_DE_VENTA
            Case "01", "03"
                tipoVenta = TIPO_VENTA.VENTA_ELECTRONICA
            Case "9903" ' PROFORMA
                tipoVenta = TIPO_VENTA.COTIZACION
        End Select

        '.serie = UCEstructuraCabeceraVentaV2.txtSerie.Text.Trim,
        '.numeroDoc = UCEstructuraCabeceraVentaV2.txtNumero.Text.Trim,

        Dim obj As New documentoventaAbarrotes With
        {
        .codigoLibro = "8",
        .idEmpresa = be.idEmpresa,
        .idEstablecimiento = be.idCentroCosto,
        .fechaLaboral = Date.Now,
        .fechaDoc = be.fechaProceso,
        .fechaVcto = Nothing,
        .fechaPeriodo = GetPeriodo(be.fechaProceso, True),
        .tipoDocumento = be.tipoDoc,
        .idCliente = be.idEntidad,
        .nombrePedido = be.entidad,
        .moneda = be.moneda,
        .tasaIgv = DocumentoVenta.tasaIgv,
        .tipoCambio = txtTipoCambio.DecimalValue,
        .bi01 = base1,
        .bi02 = base2,
        .isc01 = 0,
        .isc02 = 0,
        .igv01 = iva1,
        .igv02 = 0,
        .otc01 = 0,
        .otc02 = 0,
        .bi01us = base1ME,
        .bi02us = base2ME,
        .isc01us = 0,
        .isc02us = 0,
        .igv01us = iva1ME,
        .igv02us = 0,
        .otc01us = 0,
        .otc02us = 0,
        .importeCostoMN = TextTotalDescuentos.DecimalValue,
        .terminos = If(ChPagoAvanzado.Checked = True, "CONTADO", "CREDITO"),
        .ImporteNacional = total,
        .ImporteExtranjero = totalME,
        .tipoVenta = tipoVenta,
        .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
        .glosa = "Venta de mercadería",
        .sustentado = "S",
        .idPadre = DocumentoVenta.idDocumento,
        .estadoEntrega = "1",
        .usuarioActualizacion = be.usuarioActualizacion,' usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }

        be.documentoventaAbarrotes = obj
        'Select Case UCCondicionesPago.RBNo.Checked
        '    Case True
        be.documentoventaAbarrotes.estadoCobro = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
        '    Case Else
        '        If UCCondicionesPago.UCPagoCompletoDocumento.TextPagado.DecimalValue > 0 Then
        '            be.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PagoParcial
        '        End If

        '        If UCCondicionesPago.UCPagoCompletoDocumento.TextSaldo.DecimalValue <= 0 Then
        '            be.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PAGADO
        '        End If
        'End Select
        be.documentoventaAbarrotes.documentoventaAbarrotesDet = New List(Of documentoventaAbarrotesDet)
    End Sub

    Private Sub MappingDocumentoCompraCabeceraDetalle(obj As documento)
        Dim objDet As documentoventaAbarrotesDet

        For Each i As documentoventaAbarrotesDet In DocumentoVenta.documentoventaAbarrotesDet.ToList
            Dim cod = System.Guid.NewGuid.ToString()


            Select Case i.tipoExistencia
                Case TipoExistencia.ServicioGasto
                    objDet = New documentoventaAbarrotesDet With
                            {
                            .AfectoInventario = i.AfectoInventario,
                            .CodigoCosto = cod,
                            .catalogo_id = 0,
                            .CustomCatalogo = Nothing,
                            .CustomEquivalencia = Nothing,
                            .CustomProducto = Nothing,
                            .idItem = "1",
                            .nombreItem = i.nombreItem,
                            .tipoExistencia = i.tipoExistencia,
                            .destino = i.destino,
                            .unidad1 = i.unidad1,
                            .monto1 = i.monto1,
                            .equivalencia_id = 0,
                            .unidad2 = Nothing,
                            .monto2 = i.monto2,
                            .precioUnitario = i.precioUnitario.GetValueOrDefault,
                            .precioUnitarioUS = i.precioUnitarioUS.GetValueOrDefault,
                            .importeMN = i.importeMN,
                            .importeME = i.importeME.GetValueOrDefault,
                            .montokardex = i.montokardex,
                            .montoIsc = 0,
                            .montoIgv = i.montoIgv,
                            .otrosTributos = 0,
                            .montokardexUS = i.montokardex.GetValueOrDefault,
                            .montoIscUS = 0,
                            .montoIgvUS = i.montoIgvUS.GetValueOrDefault,
                            .otrosTributosUS = 0,
                            .entregado = "1",
                            .estadoPago = i.estadoPago,
                            .bonificacion = i.bonificacion,
                            .descuentoMN = i.descuentoMN.GetValueOrDefault,
                            .usuarioModificacion = obj.usuarioActualizacion,' usuario.IDUsuario,
                            .fechaModificacion = Date.Now
                            }
                Case Else
                    objDet = New documentoventaAbarrotesDet With
                            {
                            .AfectoInventario = i.AfectoInventario,
                            .CodigoCosto = cod,
                            .catalogo_id = i.CustomCatalogo.idCatalogo,
                            .CustomCatalogo = i.CustomCatalogo,
                            .CustomEquivalencia = i.CustomEquivalencia,
                            .CustomProducto = i.CustomProducto,
                            .idItem = i.CustomProducto.codigodetalle,
                            .nombreItem = i.CustomProducto.descripcionItem,
                            .tipoExistencia = i.CustomProducto.tipoExistencia,
                            .destino = i.CustomProducto.origenProducto,
                            .unidad1 = i.CustomProducto.unidad1,
                            .monto1 = i.monto1,
                            .equivalencia_id = i.CustomEquivalencia.equivalencia_id,
                            .unidad2 = Nothing,
                            .monto2 = i.monto2,
                            .precioUnitario = i.precioUnitario.GetValueOrDefault,
                            .precioUnitarioUS = i.precioUnitarioUS.GetValueOrDefault,
                            .importeMN = i.importeMN,
                            .importeME = i.importeME.GetValueOrDefault,
                            .montokardex = i.montokardex,
                            .montoIsc = 0,
                            .montoIgv = i.montoIgv,
                            .otrosTributos = 0,
                            .montokardexUS = i.montokardex.GetValueOrDefault,
                            .montoIscUS = 0,
                            .montoIgvUS = i.montoIgvUS.GetValueOrDefault,
                            .otrosTributosUS = 0,
                            .entregado = "1",
                            .estadoPago = i.estadoPago,
                            .bonificacion = i.bonificacion,
                            .descuentoMN = i.descuentoMN.GetValueOrDefault,
                            .usuarioModificacion = obj.usuarioActualizacion,' usuario.IDUsuario,
                            .fechaModificacion = Date.Now
                            }
            End Select
            obj.documentoventaAbarrotes.documentoventaAbarrotesDet.Add(objDet)
        Next
    End Sub

    Private Sub MappingPagos(envio As EnvioImpresionVendedorPernos, obj As documento)
        Dim ListaPagos = ListaPagosCajas(obj.documentoventaAbarrotes, obj.documentoventaAbarrotes.documentoventaAbarrotesDet, envio)
        obj.ListaCustomDocumento = ListaPagos.ToList

        Dim SumaPagos As Decimal = 0
        For Each i As documento In ListaPagos
            SumaPagos += i.documentoCaja.montoSoles.GetValueOrDefault
        Next
        If SumaPagos = obj.documentoventaAbarrotes.ImporteNacional Then 'txtTotalPagar.DecimalValue Then
            obj.documentoventaAbarrotes.terminos = "CONTADO"
            obj.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.COBRADO
        Else
            'ndocumento.documentoventaAbarrotes.terminos = "PARCIAL"
            obj.documentoventaAbarrotes.terminos = "CREDITO"
            obj.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
        End If
        '     obj.documentoventaAbarrotes.estadoCobro = obj.documentoventaAbarrotes.GetEstadoPagoComprobante

    End Sub

    Public Function ListaPagosCajas(venta As documentoventaAbarrotes, ventaDetalle As List(Of documentoventaAbarrotesDet), envio As EnvioImpresionVendedorPernos) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)

        For Each i As Record In dgvCuentas.Table.Records
            If Decimal.Parse(i.GetValue("abonado")) > 0 Then
                nDocumentoCaja = New documento
                nDocumentoCaja.idDocumento = 0 'CInt(Me.Tag)
                nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
                nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
                nDocumentoCaja.fechaProceso = Date.Now ' txtFecha.Value
                nDocumentoCaja.tipoDoc = "9903" ' cbotipoDocPago.SelectedValue
                nDocumentoCaja.nroDoc = "0"
                nDocumentoCaja.nroDoc = conf.Serie
                nDocumentoCaja.idOrden = Nothing
                nDocumentoCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
                'If TextProveedor.Text.Trim.Length > 0 Then
                nDocumentoCaja.idEntidad = Val(TextProveedor.Tag)
                nDocumentoCaja.entidad = TextProveedor.Text
                nDocumentoCaja.nrodocEntidad = TextNumIdentrazon.Text
                'Else
                'nDocumentoCaja.entidad = TextProveedor.Text
                '    nDocumentoCaja.nrodocEntidad = 0
                ' nDocumentoCaja.idEntidad = Val(0)
                'End If
                nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
                nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                nDocumentoCaja.usuarioActualizacion = DocumentoVenta.usuarioActualizacion ' usuario.IDUsuario
                nDocumentoCaja.fechaActualizacion = DateTime.Now


                'DOCUMENTO CAJA
                objCaja = New documentoCaja
                objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                objCaja.idDocumento = 0
                objCaja.periodo = venta.fechaPeriodo
                objCaja.idEmpresa = Gempresas.IdEmpresaRuc
                objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
                objCaja.fechaProceso = Date.Now ' txtFecha.Value
                objCaja.fechaCobro = Date.Now ' txtFecha.Value
                objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                'If TextProveedor.Text.Trim.Length > 0 Then
                objCaja.codigoProveedor = TextProveedor.Tag
                objCaja.IdProveedor = Integer.Parse(TextProveedor.Tag)
                objCaja.idPersonal = Integer.Parse(TextProveedor.Tag)
                'End If
                objCaja.TipoDocumentoPago = "9903" 'cbotipoDocPago.SelectedValue
                objCaja.codigoLibro = "1"
                objCaja.tipoDocPago = venta.tipoDocumento
                objCaja.formapago = i.GetValue("idforma") ' "9903"
                objCaja.NumeroDocumento = "-"
                ' Dim numeroop = i.GetValue("nrooperacion")


                Dim numeroop = i.GetValue("nrooperacion")

                If numeroop.ToString.Trim.Length > 0 Then
                    objCaja.numeroOperacion = i.GetValue("nrooperacion")
                End If


                If i.GetValue("idforma") = "006" Or i.GetValue("idforma") = "007" Then
                    objCaja.estadopago = 1

                End If

                Select Case venta.tipoDocumento
                    Case "9907"
                        objCaja.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA
                    Case "9903"
                        objCaja.movimientoCaja = TIPO_VENTA.PROFORMA
                    Case Else
                        objCaja.movimientoCaja = TIPO_VENTA.VENTA_ELECTRONICA
                End Select

                'Select Case venta.tipoDocumento
                '    Case "9907"
                '        objCaja.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA
                '    Case Else
                '        objCaja.movimientoCaja = TipoVentaGeneral 'TIPO_VENTA.VENTA_POS_DIRECTA,
                'End Select
                objCaja.montoSoles = Decimal.Parse(i.GetValue("abonado"))

                objCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
                objCaja.tipoCambio = TmpTipoCambio
                objCaja.montoUsd = Decimal.Parse(objCaja.montoSoles / TmpTipoCambio)

                objCaja.estado = "1"
                objCaja.glosa = "Por ventas" & TextProveedor.Text & "con tipo Doc. " & cboTipoDoc.Text & ", fecha de venta " & Date.Now 'txtFecha.Value
                objCaja.entregado = "SI"

                objCaja.idCajaUsuario = envio.IDCaja ' GFichaUsuarios.IdCajaUsuario
                objCaja.entidadFinanciera = i.GetValue("identidad")
                objCaja.NombreEntidad = i.GetValue("entidad")
                objCaja.usuarioModificacion = DocumentoVenta.usuarioActualizacion ' usuario.IDUsuario
                objCaja.fechaModificacion = DateTime.Now
                nDocumentoCaja.documentoCaja = objCaja
                nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja, ventaDetalle)
                'asientoDocumento(nDocumentoCaja.documentoCaja)
                ListaDoc.Add(nDocumentoCaja)
            End If
        Next

        'If TextValoranticipo.DecimalValue > 0 Then
        '    listaAnticipoDetalle = New List(Of documentoAnticipoConciliacion)
        '    listaAnticipoDetalle = GetDetallePagoAnticipoV2(TextValoranticipo.DecimalValue, ventaDetalle)
        'End If

        'If PanelCupon.Visible Then
        '    If TextCuponImporte.DecimalValue > 0 Then
        '        ListaDoc.Add(AddPagoCuponCaja(venta, ventaDetalle))
        '    End If
        'End If

        Return ListaDoc
    End Function

    Private Function GetDetallePago(objCaja As documentoCaja, ventaDetalle As List(Of documentoventaAbarrotesDet)) As List(Of documentoCajaDetalle)
        Dim listaBeneficio As New List(Of String)
        listaBeneficio.Add("OFERTA")
        listaBeneficio.Add("REGALO")
        Dim montoPago = objCaja.montoSoles
        GetDetallePago = New List(Of documentoCajaDetalle)
        For Each i As documentoventaAbarrotesDet In ventaDetalle.Where(Function(o) Not listaBeneficio.Contains(o.tipobeneficio)).ToList()
            If montoPago > 0 Then
                If i.MontoSaldo > 0 Then
                    If i.MontoSaldo > montoPago Then
                        Dim canUso = montoPago
                        i.MontoPago = canUso
                        i.estadoPago = i.ItemPendiente
                    ElseIf i.MontoSaldo = montoPago Then
                        i.MontoPago = montoPago
                        i.estadoPago = i.ItemSaldado
                    Else
                        Dim canUso = i.MontoSaldo
                        i.MontoPago = canUso
                        i.estadoPago = i.ItemSaldado
                    End If
                    montoPago -= i.MontoPago 'ImporteDisponible

                    '.codigoLote = Integer.Parse(i.codigoLote),

                    GetDetallePago.Add(New documentoCajaDetalle With
                                   {
                                   .destino = i.CodigoCosto,
                                   .fecha = Date.Now,
                                   .codigoLote = 0,
                                   .otroMN = 0,
                                   .idItem = i.idItem,
                                   .DetalleItem = i.nombreItem,
                                   .montoSoles = i.MontoPago,
                                   .montoUsd = FormatNumber(i.MontoPago / TmpTipoCambio, 2),
                                   .diferTipoCambio = TmpTipoCambio,
                                   .tipoCambioTransacc = TmpTipoCambio,
                                   .entregado = "SI",
                                   .idCajaUsuario = objCaja.idCajaUsuario, ' GFichaUsuarios.IdCajaUsuario,
                                   .usuarioModificacion = DocumentoVenta.usuarioActualizacion, ' usuario.IDUsuario,
                                   .documentoAfectado = DocumentoVenta.idDocumento,
                                   .documentoAfectadodetalle = i.secuencia,
                                   .EstadoCobro = i.estadoPago,
                                   .fechaModificacion = DateTime.Now
                                   })
                    i.estadoPago = i.estadoPago
                    'Dim item = ventaDetalle.Where(Function(o) o.secuencia = i.secuencia).Single
                    'item.estadoPago = i.EstadoPagos
                End If
            End If
        Next
    End Function

    Private Sub PagoDirectoCheck()
        ChPagoAvanzado.Checked = True
    End Sub

    Private Function GetConfiguracionUsuario(usuarioSel As Seguridad.Business.Entity.Usuario, cajaUsuario As cajaUsuario) As EnvioImpresionVendedorPernos
        Dim envio As EnvioImpresionVendedorPernos
        envio = New EnvioImpresionVendedorPernos With
            {
            .CodigoVendedor = usuarioSel.codigo,
            .IDCaja = cajaUsuario.idcajaUsuario,' ComboCaja.SelectedValue,
            .IDVendedor = usuarioSel.IDUsuario,
            .print = True,
            .Nombreprint = String.Empty,
            .NombreCajero = usuarioSel.Full_Name,
            .EntidadFinanciera = 0,'ef.idestado,
            .EntidadFinancieraName = String.Empty
        }
        Return envio
    End Function

    Private Sub GetBeneficios()
        'ListaBeneficios = New List(Of Business.Entity.beneficio)
        'ListaBeneficios = beneficioSA.BeneficioListaClienteProductions(New Business.Entity.beneficio With {.idCliente = Integer.Parse(TXTcOMPRADOR.Tag)})

        'If ListaBeneficios.Count > 0 Then
        '    formventa.TotalesColumnaDescuentos(ListaBeneficios)
        'Else
        '    formventa.TotalesColumnaDescuentos(ListaBeneficios)
        'End If

        ' CalculosMontos()
        PagoDirectoCheck()
        'Me.dgvCuentas.Table.Records.DeleteAll()
        'Me.dgvCuentas.Table.AddNewRecord.SetCurrent()
        'Me.dgvCuentas.Table.AddNewRecord.BeginEdit()
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("tipo", Nothing) '0
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("identidad", cbocajaPago.SelectedValue)
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("entidad", cbocajaPago.Text)
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("abonado", CDec(txtTotalPagar.Text))
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("tipocambio", TmpTipoCambio)
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("idforma", Nothing)
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("formaPago", "CUENTA EFECTIVO")
        'Me.dgvCuentas.Table.AddNewRecord.EndEdit()
    End Sub

    Private Sub GetUbicarClienteGeneral()
        '  Dim entidadSA As New entidadSA
        '   Dim ClienteGeneral = entidadSA.UbicarEntidadVarios("VR", Gempresas.IdEmpresaRuc, String.Empty)
        If VarClienteGeneral IsNot Nothing Then
            'txtruc.Text = VarClienteGeneral.nrodoc
            'TXTcOMPRADOR.Text = VarClienteGeneral.nombreCompleto
            'TXTcOMPRADOR.Tag = VarClienteGeneral.idEntidad
            'TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            'txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            GetBeneficios()
        End If

    End Sub

    Private Sub GrabarVentaEquivalencia()
        Dim cajaUsuaroSA As New cajaUsuarioSA
        Dim envio As EnvioImpresionVendedorPernos = Nothing
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim obj As New documento
        Try
            '   Dim cajaUsuario = cajaUsuaroSA.UbicarCajaUsuarioPorID(codigo)
            'Dim usuarioSel = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario).SingleOrDefault
            Dim usuarioSel = listaActivas.Where(Function(o) o.idcajaUsuario = Integer.Parse(ComboCaja.SelectedValue)).SingleOrDefault
            If usuarioSel Is Nothing Then
                BtOperacion.Enabled = True
                MessageBox.Show("Debe aperturar una caja realizar la venta!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            'Dim codigoVendedor = UCCondicionesPago.UCPagoCompletoDocumento.TextCodigoVendedor.Text.Trim
            'Dim usuarioSel = UsuariosList.Where(Function(o) o.codigo = codigoVendedor).FirstOrDefault

            If usuarioSel IsNot Nothing Then
                obj = MappingDocumento()
                If ChPagoAvanzado.Checked = True Then
                    'Dim codigo As Integer = Integer.Parse(UCCondicionesPago.UCPagoCompletoDocumento.ComboCaja.SelectedValue)
                    'Dim cajaUsuario = cajaUsuaroSA.UbicarCajaUsuarioPorID(usuarioSel.idcajaUsuario)

                    Dim usuarioPedido = UsuariosList.Where(Function(o) o.IDUsuario = DocumentoVenta.usuarioActualizacion).SingleOrDefault

                    envio = GetConfiguracionUsuario(usuarioPedido, usuarioSel)
                ElseIf chCredito.Checked = True Then

                End If

                'Select Case UCEstructuraCabeceraVentaV2.ComboTerminosPago.Text
                '    Case "CONTADO"

                '    Case "CREDITO"

                '    Case "CRONOGRAMA"
                '        'If UCCondicionesPago.UCCronogramaPagos.ListaCronograma IsNot Nothing Then
                '        obj.Cronograma = New List(Of Cronograma)
                '        obj.Cronograma = UCCondicionesPago.UCCronogramaPagos.ListaCronograma
                '        'Else
                '        'Throw New Exception("Debe registrar el cronograma de pagos")
                '        'End If
                'End Select
                MappingDocumentoCompraCabecera(obj)
                MappingDocumentoCompraCabeceraDetalle(obj)

                Select Case obj.tipoDoc
                    Case "03", "01", "9907"
                        MappingPagos(envio, obj)
                    Case "9903", "1000" ' PROFORMA

                End Select

                'If validarCanastaDeVentas(obj) Then
                Dim docImpresion = obj
                '  obj.AfectaInventario = SwitchInventario.Value
                Dim ListaPagos = obj.ListaCustomDocumento
                Dim doc = ventaSA.GrabarVentaEquivalencia(obj)
                docImpresion.idDocumento = obj.idDocumento
                docImpresion.documentoventaAbarrotes.idDocumento = obj.idDocumento
                If cboTipoDoc.Text = "FACTURA" Or cboTipoDoc.Text = "BOLETA" Then
                    If My.Computer.Network.IsAvailable = True Then
                        If My.Computer.Network.Ping("138.128.171.106") Then
                            If Gempresas.ubigeo > 0 Then

                                Dim documentoSave = ventaSA.GetVentaID(New documento With {.idDocumento = doc.idDocumento})
                                Dim documentoEnvio As New documento With {.idDocumento = doc.idDocumento}
                                documentoEnvio.documentoventaAbarrotes = documentoSave
                                documentoEnvio.ListaCustomDocumento = ListaPagos
                                EnviarFacturaElectronica(documentoEnvio, Gempresas.ubigeo)

                                FormImpresionNuevo = New FormImpresionEquivalencia(documentoEnvio)  ' frmVentaNuevoFormato
                                FormImpresionNuevo.tienda = ""
                                FormImpresionNuevo.FormaPago = ""
                                FormImpresionNuevo.DocumentoID = doc.idDocumento
                                FormImpresionNuevo.Email = ""
                                FormImpresionNuevo.StartPosition = FormStartPosition.CenterScreen

                                FormImpresionNuevo.ShowDialog(Me)
                            End If
                        End If
                    Else
                        MessageBox.Show("Envio a Respositorio!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'Alert = New Alert("Envio a Respositorio", alertType.success)
                        'Alert.TopMost = True
                        'Alert.Show()
                    End If
                ElseIf cboTipoDoc.Text = "NOTA" Then

                    Dim documentoSave = ventaSA.GetVentaID(New documento With {.idDocumento = doc.idDocumento})
                    Dim documentoEnvio As New documento With {.idDocumento = doc.idDocumento}
                    documentoEnvio.documentoventaAbarrotes = documentoSave
                    documentoEnvio.ListaCustomDocumento = ListaPagos

                    FormImpresionNuevo = New FormImpresionEquivalencia(documentoEnvio)  ' frmVentaNuevoFormato
                    FormImpresionNuevo.tienda = ""
                    FormImpresionNuevo.FormaPago = ""
                    FormImpresionNuevo.DocumentoID = doc.idDocumento
                    FormImpresionNuevo.Email = ""
                    FormImpresionNuevo.StartPosition = FormStartPosition.CenterScreen

                    FormImpresionNuevo.ShowDialog(Me)
                End If
                '   MessageBox.Show("Venta registrada!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DocumentoVenta = Nothing

                ChPagoAvanzado.Checked = True
                PagoDirectoCheck()
                BtOperacion.Enabled = False
                TextCodigoVendedor.Clear()
                TextComprador.Clear()
                lblPagoVenta.Text = "0.00"
                txtTotalBase.DecimalValue = 0
                txtTotalBase2.DecimalValue = 0
                txtTotalBase3.DecimalValue = 0
                txtTotalIva.DecimalValue = 0
                TextTotalDescuentos.DecimalValue = 0
                txtTotalPagar.Value = 0
                LabelTotalCobrarCliente.Text = "0.00"
                TextPagoAnticipoDisponible.DecimalValue = 0
                TextValoranticipo.DecimalValue = 0
                'VUELTO
                TextTotalPagosCliente.DecimalValue = 0
                LabelTotalCobrarCliente.Text = "0.00"
                LabelVueltoCliente.Text = "0.00"
                '***********************************************
                GetUbicarClienteGeneral()

                chCredito.Checked = False
                LblPagoCredito.Visible = False
                chCobranzaParcial.Checked = False
                PanelCupon.Visible = False
                ErrorProvider1.Clear()
                GetMappingColumnsGrid()

                Alert = New Alert("Venta registrada", alertType.success)
                Alert.TopMost = True
                Alert.Show()

                HabilitarPago(False)
                Click_Boton_Importar()
                'BtImportar.PerformClick()
                '  Close()
                'Else
                '    MessageBox.Show("Debe ingresar una cantidad mayor a cero", "Verificar el detalle de venta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    btGrabar.Enabled = True
                'End If
            Else
                MessageBox.Show("Ingrese un código valido", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'btGrabar.Enabled = True
                'UCCondicionesPago.UCPagoCompletoDocumento.TextCodigoVendedor.Select()
            End If
        Catch ex As Exception
            BtOperacion.Enabled = True
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
        End Try
    End Sub

    'Private Sub GrabarVentaEquivalencia()
    '    Dim cajaUsuaroSA As New cajaUsuarioSA
    '    Dim envio As EnvioImpresionVendedorPernos = Nothing
    '    Dim ventaSA As New documentoVentaAbarrotesSA
    '    Dim obj As New documento
    '    Try
    '        '   Dim cajaUsuario = cajaUsuaroSA.UbicarCajaUsuarioPorID(codigo)
    '        Dim usuarioSel = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario).SingleOrDefault
    '        If usuarioSel Is Nothing Then
    '            BtOperacion.Enabled = True
    '            MessageBox.Show("Debe aperturar una caja realizar la venta!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Exit Sub
    '        End If

    '        'Dim codigoVendedor = UCCondicionesPago.UCPagoCompletoDocumento.TextCodigoVendedor.Text.Trim
    '        'Dim usuarioSel = UsuariosList.Where(Function(o) o.codigo = codigoVendedor).FirstOrDefault

    '        If usuarioSel IsNot Nothing Then
    '            obj = MappingDocumento()
    '            If ChPagoAvanzado.Checked = True Then
    '                'Dim codigo As Integer = Integer.Parse(UCCondicionesPago.UCPagoCompletoDocumento.ComboCaja.SelectedValue)
    '                Dim cajaUsuario = cajaUsuaroSA.UbicarCajaUsuarioPorID(usuarioSel.idcajaUsuario)

    '                Dim usuarioPedido = UsuariosList.Where(Function(o) o.IDUsuario = DocumentoVenta.usuarioActualizacion).SingleOrDefault

    '                envio = GetConfiguracionUsuario(usuarioPedido, cajaUsuario)
    '            ElseIf chCredito.Checked = True Then

    '            End If

    '            'Select Case UCEstructuraCabeceraVentaV2.ComboTerminosPago.Text
    '            '    Case "CONTADO"

    '            '    Case "CREDITO"

    '            '    Case "CRONOGRAMA"
    '            '        'If UCCondicionesPago.UCCronogramaPagos.ListaCronograma IsNot Nothing Then
    '            '        obj.Cronograma = New List(Of Cronograma)
    '            '        obj.Cronograma = UCCondicionesPago.UCCronogramaPagos.ListaCronograma
    '            '        'Else
    '            '        'Throw New Exception("Debe registrar el cronograma de pagos")
    '            '        'End If
    '            'End Select
    '            MappingDocumentoCompraCabecera(obj)
    '            MappingDocumentoCompraCabeceraDetalle(obj)

    '            Select Case obj.tipoDoc
    '                Case "03", "01", "9907"
    '                    MappingPagos(envio, obj)
    '                Case "9903", "1000" ' PROFORMA

    '            End Select

    '            'If validarCanastaDeVentas(obj) Then
    '            Dim docImpresion = obj
    '            '  obj.AfectaInventario = SwitchInventario.Value
    '            Dim ListaPagos = obj.ListaCustomDocumento
    '            Dim doc = ventaSA.GrabarVentaEquivalencia(obj)
    '            docImpresion.idDocumento = obj.idDocumento
    '            docImpresion.documentoventaAbarrotes.idDocumento = obj.idDocumento
    '            If cboTipoDoc.Text = "FACTURA" Or cboTipoDoc.Text = "BOLETA" Then
    '                If My.Computer.Network.IsAvailable = True Then
    '                    If My.Computer.Network.Ping("148.102.27.231") Then
    '                        If Gempresas.ubigeo > 0 Then

    '                            Dim documentoSave = ventaSA.GetVentaID(New documento With {.idDocumento = doc.idDocumento})
    '                            Dim documentoEnvio As New documento With {.idDocumento = doc.idDocumento}
    '                            documentoEnvio.documentoventaAbarrotes = documentoSave
    '                            documentoEnvio.ListaCustomDocumento = ListaPagos
    '                            EnviarFacturaElectronica(documentoEnvio, Gempresas.ubigeo)

    '                            FormImpresionNuevo = New FormImpresionEquivalencia(documentoEnvio)  ' frmVentaNuevoFormato
    '                            FormImpresionNuevo.tienda = ""
    '                            FormImpresionNuevo.FormaPago = ""
    '                            FormImpresionNuevo.DocumentoID = doc.idDocumento
    '                            FormImpresionNuevo.Email = ""
    '                            FormImpresionNuevo.StartPosition = FormStartPosition.CenterScreen

    '                            FormImpresionNuevo.ShowDialog(Me)
    '                        End If
    '                    End If
    '                Else
    '                    MessageBox.Show("Envio a Respositorio!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    'Alert = New Alert("Envio a Respositorio", alertType.success)
    '                    'Alert.TopMost = True
    '                    'Alert.Show()
    '                End If
    '            ElseIf cboTipoDoc.Text = "NOTA" Then

    '                Dim documentoSave = ventaSA.GetVentaID(New documento With {.idDocumento = doc.idDocumento})
    '                Dim documentoEnvio As New documento With {.idDocumento = doc.idDocumento}
    '                documentoEnvio.documentoventaAbarrotes = documentoSave
    '                documentoEnvio.ListaCustomDocumento = ListaPagos

    '                FormImpresionNuevo = New FormImpresionEquivalencia(documentoEnvio)  ' frmVentaNuevoFormato
    '                FormImpresionNuevo.tienda = ""
    '                FormImpresionNuevo.FormaPago = ""
    '                FormImpresionNuevo.DocumentoID = doc.idDocumento
    '                FormImpresionNuevo.Email = ""
    '                FormImpresionNuevo.StartPosition = FormStartPosition.CenterScreen

    '                FormImpresionNuevo.ShowDialog(Me)
    '            End If
    '            '   MessageBox.Show("Venta registrada!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            DocumentoVenta = Nothing

    '            ChPagoAvanzado.Checked = True
    '            PagoDirectoCheck()
    '            BtOperacion.Enabled = False
    '            TextCodigoVendedor.Clear()
    '            TextComprador.Clear()
    '            lblPagoVenta.Text = "0.00"
    '            txtTotalBase.DecimalValue = 0
    '            txtTotalBase2.DecimalValue = 0
    '            txtTotalBase3.DecimalValue = 0
    '            txtTotalIva.DecimalValue = 0
    '            TextTotalDescuentos.DecimalValue = 0
    '            txtTotalPagar.Text = "0.00"
    '            txtTotalPagar.Value = "0.00"
    '            TextPagoAnticipoDisponible.DecimalValue = 0
    '            TextValoranticipo.DecimalValue = 0
    '            GetUbicarClienteGeneral()

    '            chCredito.Checked = False
    '            LblPagoCredito.Visible = False
    '            '    chCobranzaParcial.Checked = False
    '            'PanelCupon.Visible = False
    '            ErrorProvider1.Clear()
    '            GetMappingColumnsGrid()

    '            Alert = New Alert("Venta registrada", alertType.success)
    '            Alert.TopMost = True
    '            Alert.Show()

    '            HabilitarPago(False)
    '            Click_Boton_Importar()
    '            '  Close()
    '            'Else
    '            '    MessageBox.Show("Debe ingresar una cantidad mayor a cero", "Verificar el detalle de venta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            '    btGrabar.Enabled = True
    '            'End If
    '        Else
    '            MessageBox.Show("Ingrese un código valido", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            'btGrabar.Enabled = True
    '            'UCCondicionesPago.UCPagoCompletoDocumento.TextCodigoVendedor.Select()
    '        End If
    '    Catch ex As Exception
    '        BtOperacion.Enabled = True
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
    '    End Try
    'End Sub

    Private Sub Click_Boton_Importar()
        PanelLoadingWaith.Controls.Clear()
        PanelLoadingWaith.Visible = True
        Dim entidadSA As New entidadSA
        Dim f As New FormCanastaPedidoDeVentas
        f.MaximizeBox = False
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            DocumentoVenta = CType(f.Tag, documentoventaAbarrotes)
            BtOperacion.Enabled = True
            CalculosMontos()
            cliventa = DocumentoVenta.CustomEntidad '  entidadSA.UbicarEntidadPorID(DocumentoVenta.idCliente).FirstOrDefault
            If cliventa.tipoEntidad = "VR" Then
                RadioButton2.Checked = True
            Else
                RadioButton1.Checked = True
            End If
            Getclientepedido()
            HabilitarPago(True)

        Else
            HabilitarPago(False)
            BtOperacion.Enabled = False
            '    MessageBox.Show("Debe seleccionar una venta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Public Sub EnviarFacturaElectronica(doc As documento, idPSE As Integer)

        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim entidadSA As New entidadSA
        Dim DetalleFactura As Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
        Try
            Dim comprobante = doc.documentoventaAbarrotes 'documentoSA.GetVentaID(New documento With {.idDocumento = doc.idDocumento})
            'Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(doc.idDocumento)
            Dim receptor = comprobante.CustomEntidad ' entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, comprobante.idCliente)
            Dim numerovent As String = String.Format("{0:00000000}", comprobante.numeroVenta)
            Dim tipoDoc = String.Format("{0:00}", comprobante.tipoDocumento)
            Dim conteo As Integer = 0
            '//Enviando el documento
            Dim Factura As New Fact.Sunat.Business.Entity.DocumentoElectronico
            'Datos del Cliente 
            Factura.Action = 0
            Factura.idEmpresa = idPSE 'lblIdPse.Text
            Factura.Contribuyente_id = Gempresas.IdEmpresaRuc
            Factura.EnvioSunat = "NO"
            'Receptor de la Factura
            Factura.NroDocumentoRec = receptor.nrodoc
            Factura.TipoDocumentoRec = receptor.tipoDoc
            Factura.NombreLegalRec = receptor.nombreCompleto
            'Datos Generales De La Factura
            Factura.IdDocumento = comprobante.serieVenta & "-" & numerovent
            Factura.FechaEmision = comprobante.fechaDoc
            Factura.FechaRecepcion = DateTime.Now 'fecha en la que se envia al PSE
            Factura.FechaVencimiento = DateTime.Now
            Factura.HoraEmision = comprobante.fechaDoc.Value.ToString("HH:mm:ss")
            Factura.TipoDocumento = tipoDoc
            Factura.TipoOperacion = "0101"

            If comprobante.importeCostoMN.GetValueOrDefault > 0 Then
                Factura.DescuentoGlobal = comprobante.importeCostoMN.GetValueOrDefault
            Else
                Factura.DescuentoGlobal = 0
            End If

            If comprobante.moneda = "1" Then
                Factura.Moneda = "PEN"
                Factura.TotalIgv = comprobante.igv01
                Factura.TotalVenta = comprobante.ImporteNacional
                Factura.Gravadas = comprobante.bi01
                Factura.Exoneradas = comprobante.bi02
            ElseIf comprobante.moneda = "2" Then
                Factura.Moneda = "USD"
                Factura.TotalIgv = comprobante.igv01us
                Factura.TotalVenta = comprobante.ImporteExtranjero
                Factura.Gravadas = comprobante.bi01us
                Factura.Exoneradas = comprobante.bi02us
            End If



            'Cargando el Detalle de la Factura
            Dim precioSinIva As Decimal = 0
            Dim precioConIva As Decimal = 0
            Dim cantEquiva As Decimal = 0
            For Each i As documentoventaAbarrotesDet In comprobante.documentoventaAbarrotesDet
                DetalleFactura = New Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
                Select Case i.tipoExistencia
                    Case TipoExistencia.ServicioGasto
                        cantEquiva = 1
                        DetalleFactura.CodigoItem = 1
                    Case Else
                        cantEquiva = i.monto1 * i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault
                        DetalleFactura.CodigoItem = i.idItem
                End Select

                'cantEquiva = i.monto1 * i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault
                precioSinIva = i.montokardex / cantEquiva
                precioConIva = i.importeMN / cantEquiva

                conteo += 1

                DetalleFactura.Id = conteo
                DetalleFactura.Cantidad = cantEquiva ' i.monto1 * i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault 'i.monto1

                DetalleFactura.Descripcion = i.nombreItem
                DetalleFactura.UnidadMedida = i.unidad1

                If doc.documentoventaAbarrotes.moneda = "1" Then
                    DetalleFactura.PrecioReferencial = precioConIva 'i.precioUnitario
                    DetalleFactura.Impuesto = i.montoIgv
                    DetalleFactura.TotalVenta = i.montokardex
                    If i.destino = "1" Then
                        DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
                        DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
                        DetalleFactura.PrecioUnitario = precioSinIva ' CalculoBaseImponible(i.precioUnitario, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
                    ElseIf i.destino = "2" Then
                        DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
                        DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
                        DetalleFactura.PrecioUnitario = precioConIva ' i.precioUnitario
                    End If
                ElseIf doc.documentoventaAbarrotes.moneda = "2" Then
                    'DetalleFactura.PrecioReferencial = i.precioUnitarioUS
                    'DetalleFactura.Impuesto = i.montoIgvUS
                    'DetalleFactura.TotalVenta = i.montokardexUS
                    'If i.destino = "1" Then
                    '    DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
                    '    DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
                    '    DetalleFactura.PrecioUnitario = CalculoBaseImponible(i.precioUnitarioUS, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
                    'ElseIf i.destino = "2" Then
                    '    DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
                    '    DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
                    '    DetalleFactura.PrecioUnitario = i.precioUnitarioUS
                    'End If
                End If
                'DetalleItems .Descuento = "falta"
                'DetalleItems .ImpuestoSelectivo = "falta"
                'DetalleItems.OtroImpuesto = "falta"
                'DetalleItems.PlacaVehiculo = "falta"
                Factura.DocumentoElectronicoDetalle.Add(DetalleFactura)
            Next
            'Enviando al PSE
            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoElectronicoSA.DocumentoElectronicoSave(Factura, Nothing)

            If codigo.idDocumentoElectronico > 0 Then
                UpdateEnvioSunatEstado(comprobante.idDocumento, "SI")
                'MessageBox.Show("La Factura se Envio Correctamente al PSE")
            End If

        Catch ex As Exception

            'MessageBox.Show("No se Pudo Enviar")

        End Try


    End Sub

    Public Sub UpdateEnvioSunatEstado(idDoc As Integer, estado As String)
        Try

            Dim docSA As New documentoVentaAbarrotesSA

            docSA.UpdateFacturasXEstado(idDoc, estado)

            'MessageBox.Show("Se Genero Correctamente")
        Catch ex As Exception
            'MessageBox.Show("No se Pudo Actualizar")
        End Try



    End Sub
#End Region

#Region "Events"
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
        ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                             .estadoCaja = "A"
                                                             })



        ''Dim be As New Helios.Seguridad.Business.Entity.jerarquiaCargo
        'be.IDEmpresa = Gempresas.IdEmpresaRuc
        'be.IDEstablecimiento = GEstableciento.IdEstablecimiento
        'PositionList = jerarquiaSA.ListaDeCargos(be)


        UsuariosList = usuarioListSA.ListadoUsuariosv2()
        Seguridad.General.ListaUsuariosSoftpack = UsuariosList
        CustomListaDatosGenerales = datosSA.UbicaEmpresaFull(New datosGenerales With {.idEmpresa = Gempresas.IdEmpresaRuc})
        ListadoProductosSingleton = detalleitemsSA.GetProductosWithInventario(New detalleitems With {
                                                                              .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                              .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                              .descripcionItem = ""
                                                                              })
        GetConfiguracionpagos()

        If UsuariosList IsNot Nothing Then
            Dim usuarioSel = UsuariosList.Where(Function(o) o.IDUsuario = usuario.IDUsuario).FirstOrDefault
            If usuarioSel IsNot Nothing Then
                'BunifuFlatButton2.Text = usuarioSel.Full_Name
                'BunifuFlatButton2.Tag = usuarioSel.IDUsuario

            End If
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

        ListaCuentasFinancierasConfiguradas = ListConfigurationPays
    End Sub

    Private Sub GetColumnsGrid()
        Dim dt As New DataTable

        With dt
            .Columns.Add("tipo")
            .Columns.Add("identidad")
            .Columns.Add("entidad")
            .Columns.Add("abonado")
            .Columns.Add("tipocambio")
            .Columns.Add("idforma")
            .Columns.Add("formaPago")
            .Columns.Add("nrooperacion")
        End With
        dgvCuentas.DataSource = dt
    End Sub

    Private Sub bg_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bg.RunWorkerCompleted

        PanelHeader1.Visible = True

        HabilitarPago(False)

        GetColumnsGrid()
        GetDocsVenta()
        GetCajasActivas()
        'GetInicioCuentas()
        ' Me.CaptionLabels(0).Text = $"{"Cajero:"} {usuario.CustomUsuario.Full_Name}"
        LogeoUsuarioCaja()

        If Gempresas.ubigeo IsNot Nothing Then
            ButtonAdv5.Text = "NUEVA VENTA"
        Else
            ButtonAdv5.Text = "NOTA VENTA"
        End If

        PictureLoading.Visible = False
        PanelHeader1.Visible = True
        PanelBootom.Visible = True
    End Sub

    'Private Sub GetInicioCuentas()
    '    Dim SA As New EstadosFinancierosConfiguracionPagosSA
    '    Dim usuariocaja = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario).FirstOrDefault
    '    If usuariocaja IsNot Nothing Then
    '        CuentasHabilitadas = SA.GetConfigurationPayCaja(New estadosFinancierosConfiguracionPagos With
    '                                            {
    '                                            .idEmpresa = Gempresas.IdEmpresaRuc,
    '                                            .idEstablecimiento = GEstableciento.IdEstablecimiento,
    '                                            .IDCaja = usuariocaja.idcajaUsuario
    '                                            })


    '    End If

    'End Sub


    Private Sub GetInicioCuentas(idCajaUsuario As Integer)
        Dim SA As New EstadosFinancierosConfiguracionPagosSA
        Dim usuariocaja = listaActivas.Where(Function(o) o.idcajaUsuario = idCajaUsuario).FirstOrDefault

        Dim dt As New DataTable

        With dt
            .Columns.Add("tipo")
            .Columns.Add("identidad")
            .Columns.Add("entidad")
            .Columns.Add("abonado")
            .Columns.Add("tipocambio")
            .Columns.Add("idforma")
            .Columns.Add("formaPago")
            .Columns.Add("nrooperacion")
        End With

        If usuariocaja IsNot Nothing Then
            CuentasHabilitadas = SA.GetConfigurationPayCaja(New estadosFinancierosConfiguracionPagos With
                                                {
                                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                .IDCaja = usuariocaja.idcajaUsuario
                                                })





            For Each j In CuentasHabilitadas.Where(Function(o) o.tipo <> "EE").ToList ' ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago <> "9991").ToList
                If CheckEfectivoDefault.Checked = True Then
                    If j.FormaPago = "EFECTIVO" And txtTotalPagar.Value > 0 Then
                        dt.Rows.Add(String.Empty, j.identidad, j.entidad, txtTotalPagar.Value, TmpTipoCambio, j.IDFormaPago, j.FormaPago, "-")



                    Else
                        dt.Rows.Add(String.Empty, j.identidad, j.entidad, 0.0, TmpTipoCambio, j.IDFormaPago, j.FormaPago, "-")
                    End If
                Else
                    dt.Rows.Add(String.Empty, j.identidad, j.entidad, 0.0, TmpTipoCambio, j.IDFormaPago, j.FormaPago, "-")
                End If
            Next



            'If ListaCuentasFinancierasConfiguradas.Count > 0 Then
            '    Dim cuponSel = ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago = "9991").SingleOrDefault
            '    PanelCupon.Tag = cuponSel
            '    TextCodigoCupon.Visible = True
            '    ButtonAdv4.Visible = True
            'End If


            dgvCuentas.DataSource = dt
            '  lblPagoVenta.Text = CDec(txtTotalPagar.Text)
            LblPagoCredito.Visible = True
            lblPagoVenta.Visible = True

            Dim pagos As Decimal = SumaPagos()
            LblPagoCredito.Text = "SALDO POR COBRAR"
            lblPagoVenta.Text = CDec(txtTotalPagar.Value) - CDec(SumaPagos())
        End If

    End Sub


    Public Sub GetDocsVenta()
        Dim ListaDocumentos As New List(Of tabladetalle)
        If Gempresas.ubigeo IsNot Nothing Then
            ListaDocumentos = GetComprobantesCompra()
        End If
        ListaDocumentos.Add(New tabladetalle With {.codigoDetalle = "9907", .descripcion = "NOTA"})

        cboTipoDoc.DataSource = ListaDocumentos
        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.ValueMember = "codigoDetalle"

        'cboTipoDoc.Items.Clear()
        'cboTipoDoc.Items.Add("NOTA DE VENTA")
        'cboTipoDoc.Items.Add("FACTURA")
        'cboTipoDoc.Items.Add("BOLETA")

    End Sub

    'Public Sub GetDocsVenta()
    '    Dim ListaDocumentos As New List(Of tabladetalle)
    '    If Gempresas.ubigeo IsNot Nothing Then
    '        ListaDocumentos = GetComprobantesCompra()
    '    End If
    '    ListaDocumentos.Add(New tabladetalle With {.codigoDetalle = "9907", .descripcion = "NOTA"})

    '    cboTipoDoc.DataSource = ListaDocumentos
    '    cboTipoDoc.DisplayMember = "descripcion"
    '    cboTipoDoc.ValueMember = "codigoDetalle"

    '    'cboTipoDoc.Items.Clear()
    '    'cboTipoDoc.Items.Add("NOTA DE VENTA")
    '    'cboTipoDoc.Items.Add("FACTURA")
    '    'cboTipoDoc.Items.Add("BOLETA")

    'End Sub

    Private Sub FormTablaPrincipalCaja_Load(sender As Object, e As EventArgs) Handles Me.Load
        Centrar(Me)
        Timer1.Enabled = True


    End Sub

    Private Sub FormTablaPrincipalCaja_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BtImportar.Click
        PanelLoadingWaith.Controls.Clear()
        PanelLoadingWaith.Visible = True
        Dim entidadSA As New entidadSA
        Dim f As New FormCanastaPedidoDeVentas
        f.MaximizeBox = False
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then


            If ListaCajasActivas.Count = 0 Or ListaCajasActivas Is Nothing Then
                MessageBox.Show("Debe registrar una caja para realizar la venta")
                ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                 .estadoCaja = "A"
                                                                 })
                Exit Sub
            End If

            If GconfigCaja = "2" Then

                Dim querybox = (From i In ListaCajasActivas
                                Where i.idPersona = usuario.IDUsuario And i.estadoCaja = "A").FirstOrDefault

                If querybox IsNot Nothing Then
                Else
                    MessageBox.Show("Su usuario no tiene una caja aperturada")
                    Exit Sub
                End If
            End If



            DocumentoVenta = CType(f.Tag, documentoventaAbarrotes)
            BtOperacion.Enabled = True
            CalculosMontos()
            cliventa = DocumentoVenta.CustomEntidad '  entidadSA.UbicarEntidadPorID(DocumentoVenta.idCliente).FirstOrDefault
            If cliventa.tipoEntidad = "VR" Then
                RadioButton2.Checked = True
            Else
                RadioButton1.Checked = True
            End If
            Getclientepedido()
            HabilitarPago(True)

        Else
            HabilitarPago(False)
            BtOperacion.Enabled = False
            '    MessageBox.Show("Debe seleccionar una venta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BtEditar_Click(sender As Object, e As EventArgs) Handles BtEditar.Click
        BtOperacion.Enabled = False
        Dim f As New FormVentaNueva(DocumentoVenta.idDocumento)
        f.ToolStrip1.Enabled = True
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        'End If
        'PictureLoad.Visible = False
        If f.Tag IsNot Nothing Then
            Dim c = CType(f.Tag, String)
            If c = "Grabado" Then
                Reinicarcarga()
            End If
        End If
        BtOperacion.Enabled = True
    End Sub

    Private Sub Boton_Grabar()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Try
            BtOperacion.Enabled = False
            'txtFecha.Value = DateTime.Now
            ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                             .estadoCaja = "A"
                                                             })

            Dim cajaUsuario = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario).SingleOrDefault
            If cajaUsuario Is Nothing Then
                BtOperacion.Enabled = True
                MessageBox.Show("Debe aperturar una caja realizar la venta!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Select Case cboTipoDoc.Text
                Case "FACTURA", "FACTURA"
                    Dim objeto As Boolean = ValidationRUC(TextNumIdentrazon.Text.Trim)
                    If objeto = False Then
                        BtOperacion.Enabled = True
                        MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                Case "BOLETA", "BOLETA"


                    If TextProveedor.Tag = VarClienteGeneral.idEntidad Then

                    Else
                        Dim rsp = validarDNIRUC(TextNumIdentrazon.Text.Trim)
                        If rsp = False Then
                            BtOperacion.Enabled = True
                            MessageBox.Show("Debe Ingresar un número correcto de DNI", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            Exit Sub
                        End If
                    End If
            End Select
            ' If ValidarGrabado() = True Then
            If chCredito.Checked = True Then

            ElseIf ChPagoAvanzado.Checked = True Then
                Dim pagos As Decimal = SumaPagos()

                If pagos <= 0 Then
                    BtOperacion.Enabled = True
                    MessageBox.Show("Debe ingresar un pago mayor a cero!", "Pagar venta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    '   objPleaseWait.Close()
                    Exit Sub
                End If

                If pagos > 0 AndAlso pagos < CDec(txtTotalPagar.Text) Then
                    BtOperacion.Enabled = True
                    If MessageBox.Show("Está realizando una cobranza parcial, Desea Continuar?", "Pagar venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        '        objPleaseWait.Close()
                        Exit Sub
                    End If
                End If
            End If

            Application.DoEvents()
            GrabarVentaEquivalencia()

        Catch ex As Exception
            '     objPleaseWait.Close()
            BtOperacion.Enabled = True
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtOperacion_Click(sender As Object, e As EventArgs) Handles BtOperacion.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Try
            BtOperacion.Enabled = False
            txtFecha.Value = DateTime.Now

            If listaActivas Is Nothing Then
            BtOperacion.Enabled = True
            MessageBox.Show("Debe aperturar una caja realizar la venta!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Select Case cboTipoDoc.Text
            Case "FACTURA", "FACTURA"
                Dim objeto As Boolean = ValidationRUC(TextNumIdentrazon.Text.Trim)
                If objeto = False Then
                    BtOperacion.Enabled = True
                    MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            Case "BOLETA", "BOLETA"


                If TextProveedor.Tag = VarClienteGeneral.idEntidad Then

                Else
                    Dim rsp = validarDNIRUC(TextNumIdentrazon.Text.Trim)
                    If rsp = False Then
                        BtOperacion.Enabled = True
                        MessageBox.Show("Debe Ingresar un número correcto de DNI", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If


        End Select

        ' If ValidarGrabado() = True Then


        If chCredito.Checked = True Then

        ElseIf ChPagoAvanzado.Checked = True Then
            Dim pagos As Decimal = 0 ' SumaPagos()
            Dim deudadTotal As Decimal = 0
            If DocumentoVenta.moneda = "1" Then
                pagos = SumaPagos()
                deudadTotal = DocumentoVenta.ImporteNacional
            Else
                pagos = SumaPagosME()
                deudadTotal = DocumentoVenta.ImporteExtranjero
            End If

            If pagos <= 0 Then
                BtOperacion.Enabled = True
                MessageBox.Show("Debe ingresar un pago mayor a cero!", "Pagar venta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                '   objPleaseWait.Close()
                Exit Sub
            End If

            If pagos > 0 AndAlso pagos < deudadTotal Then
                BtOperacion.Enabled = True
                If MessageBox.Show("Está realizando una cobranza parcial, Desea Continuar?", "Pagar venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    '        objPleaseWait.Close()
                    Exit Sub
                End If
            End If
        End If

        ' If ValidacionDeMontoTotalConDetalle() = True Then
        'objPleaseWait = New FeedbackForm()
        'objPleaseWait.StartPosition = FormStartPosition.CenterScreen
        'objPleaseWait.Show()
        Application.DoEvents()
        GrabarVentaEquivalencia()



        'Select Case cboTipoDoc.Text
        '    Case "BOLETA", "FACTURA"
        '        TipoVentaGeneral = TIPO_VENTA.VENTA_POS_DIRECTA
        '        GrabarVentaCasoEspecial()

        '    Case "FACTURA", "BOLETA"
        '        TipoVentaGeneral = TIPO_VENTA.VENTA_ELECTRONICA
        '        GrabarVentaCasoEspecial()

        '    Case "NOTA DE VENTA"
        '        GrabarNotaDeVenta()
        '    Case "PROFORMA"
        '        GrabarProforma()
        'End Select
        'Else
        '    MessageBox.Show("Los importes no coinciden, el detalle, con el total de la venta ", "Verificar importes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
        'End If
        Catch ex As Exception
        '     objPleaseWait.Close()
        BtOperacion.Enabled = True
        MsgBox(ex.Message)
        End Try

        'Dim cajaUsuarioSA As New cajaUsuarioSA
        'Try
        '    BtOperacion.Enabled = False
        '    'txtFecha.Value = DateTime.Now
        '    ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
        '                                                     .idEmpresa = Gempresas.IdEmpresaRuc,
        '                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '                                                     .estadoCaja = "A"
        '                                                     })

        '    Dim cajaUsuario = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario).SingleOrDefault
        '    If cajaUsuario Is Nothing Then
        '        BtOperacion.Enabled = True
        '        MessageBox.Show("Debe aperturar una caja realizar la venta!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        Exit Sub
        '    End If

        '    Select Case cboTipoDoc.Text
        '        Case "FACTURA", "FACTURA"
        '            Dim objeto As Boolean = ValidationRUC(TextNumIdentrazon.Text.Trim)
        '            If objeto = False Then
        '                BtOperacion.Enabled = True
        '                MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                Cursor = Cursors.Default
        '                Exit Sub
        '            End If
        '        Case "BOLETA", "BOLETA"


        '            If TextProveedor.Tag = VarClienteGeneral.idEntidad Then

        '            Else
        '                Dim rsp = validarDNIRUC(TextNumIdentrazon.Text.Trim)
        '                If rsp = False Then
        '                    BtOperacion.Enabled = True
        '                    MessageBox.Show("Debe Ingresar un número correcto de DNI", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                    Cursor = Cursors.Default
        '                    Exit Sub
        '                End If
        '            End If
        '    End Select
        '    ' If ValidarGrabado() = True Then
        '    If chCredito.Checked = True Then

        '    ElseIf ChPagoAvanzado.Checked = True Then
        '        Dim pagos As Decimal = SumaPagos()

        '        If pagos <= 0 Then
        '            BtOperacion.Enabled = True
        '            MessageBox.Show("Debe ingresar un pago mayor a cero!", "Pagar venta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        '            '   objPleaseWait.Close()
        '            Exit Sub
        '        End If

        '        If pagos > 0 AndAlso pagos < CDec(txtTotalPagar.Text) Then
        '            BtOperacion.Enabled = True
        '            If MessageBox.Show("Está realizando una cobranza parcial, Desea Continuar?", "Pagar venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
        '                '        objPleaseWait.Close()
        '                Exit Sub
        '            End If
        '        End If
        '    End If

        '    Application.DoEvents()
        '    GrabarVentaEquivalencia()

        'Catch ex As Exception
        '    '     objPleaseWait.Close()
        '    BtOperacion.Enabled = True
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Cursor = Cursors.WaitCursor
        If DocumentoVenta IsNot Nothing Then
            Dim frmDetalleVentaView = New frmDetalleVentaView(DocumentoVenta)
            frmDetalleVentaView.CaptionLabels(1).Text = DocumentoVenta.nombrePedido
            frmDetalleVentaView.StartPosition = FormStartPosition.CenterParent
            frmDetalleVentaView.ShowDialog(Me)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub cboTipoDoc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedValueChanged
        If cboTipoDoc.Text.Trim.Length > 0 Then
            'Select Case cboTipoDoc.Text
            '    Case "BOLETA"

            '        chAutoNumeracion.Enabled = True
            '        If chAutoNumeracion.Checked = True Then
            '            txtNumero.Clear()
            '            txtSerie.Visible = False
            '            txtSerie.ReadOnly = True
            '            txtNumero.Visible = False
            '            txtNumero.ReadOnly = True

            '            'txtruc.Text = 0
            '            'TXTcOMPRADOR.Text = "VARIOS"
            '            'txtruc.Select(0, txtruc.Text.Length)
            '            'txtruc.Focus()
            '            'Getclientepedido()

            '            ProgressBar2.Visible = True
            '            ProgressBar2.Style = ProgressBarStyle.Marquee
            '            BackgroundWorker1.RunWorkerAsync()

            '        Else
            '            txtNumero.Clear()
            '            txtSerie.Visible = True
            '            txtSerie.ReadOnly = False
            '            txtNumero.Visible = True
            '            txtNumero.ReadOnly = False
            '        End If
            '    Case "FACTURA"

            '        chAutoNumeracion.Enabled = True
            '        If chAutoNumeracion.Checked = True Then
            '            txtNumero.Clear()
            '            txtSerie.Visible = False
            '            txtSerie.ReadOnly = True
            '            txtNumero.Visible = False
            '            txtNumero.ReadOnly = True

            '            'txtruc.Clear()
            '            'TXTcOMPRADOR.Clear()
            '            'txtruc.Select(0, txtruc.Text.Length)
            '            'txtruc.Focus()
            '            '  Getclientepedido()

            '            ProgressBar2.Visible = True
            '            ProgressBar2.Style = ProgressBarStyle.Marquee
            '            BackgroundWorker1.RunWorkerAsync()

            '        Else
            '            txtNumero.Clear()
            '            txtSerie.Visible = True
            '            txtSerie.ReadOnly = False
            '            txtNumero.Visible = True
            '            txtNumero.ReadOnly = False
            '        End If
            '    Case "NOTA DE VENTA"

            '        chAutoNumeracion.Checked = True
            '        chAutoNumeracion.Enabled = False
            '        txtSerie.Visible = False
            '        txtNumero.Visible = False
            '        txtSerie.ReadOnly = False

            '        'txtruc.Text = 0
            '        'TXTcOMPRADOR.Text = "VARIOS"
            '        'txtruc.Select(0, txtruc.Text.Length)S
            '        'txtruc.Focus()

            '    Case "BOLETA"

            '        chAutoNumeracion.Enabled = True
            '        chAutoNumeracion.Checked = True

            '        'txtSerie.Visible = True
            '        'txtSerie.Text = "B001"
            '        'txtSerie.ReadOnly = True
            '        'txtNumero.Visible = True
            '        'txtNumero.ReadOnly = True
            '        txtNumero.Clear()
            '        txtSerie.Visible = False
            '        txtSerie.ReadOnly = True
            '        txtNumero.Visible = False
            '        txtNumero.ReadOnly = True

            '        'txtruc.Text = 0
            '        'TXTcOMPRADOR.Text = "VARIOS"
            '        'txtruc.Select(0, txtruc.Text.Length)
            '        'txtruc.Focus()

            '        ProgressBar2.Visible = True
            '        ProgressBar2.Style = ProgressBarStyle.Marquee
            '        BackgroundWorker1.RunWorkerAsync()
            '    Case "FACTURA"

            '        chAutoNumeracion.Enabled = True
            '        chAutoNumeracion.Checked = True

            '        'txtSerie.Visible = True
            '        'txtSerie.Text = "F001"
            '        'txtSerie.ReadOnly = True
            '        'txtNumero.Visible = True
            '        'txtNumero.ReadOnly = True

            '        txtNumero.Clear()
            '        txtSerie.Visible = False
            '        txtSerie.ReadOnly = True
            '        txtNumero.Visible = False
            '        txtNumero.ReadOnly = True

            '        'txtruc.Clear()
            '        'TXTcOMPRADOR.Clear()
            '        'txtruc.Select(0, txtruc.Text.Length)
            '        'txtruc.Focus()

            '        ProgressBar2.Visible = True
            '        ProgressBar2.Style = ProgressBarStyle.Marquee
            '        BackgroundWorker1.RunWorkerAsync()
            '    Case "PROFORMA"
            '        txtNumero.Clear()
            '        txtSerie.Visible = False
            '        txtSerie.ReadOnly = True
            '        txtNumero.Visible = False
            '        txtNumero.ReadOnly = True

            '        Getclientepedido()

            '        ProgressBar2.Visible = True
            '        ProgressBar2.Style = ProgressBarStyle.Marquee
            '        BackgroundWorker1.RunWorkerAsync()
            'End Select
            'GetResetCantidades()
        End If

    End Sub


    Private Function SumaPagos() As Decimal
        SumaPagos = 0
        Dim pagoCupones As Decimal = 0
        Dim pagoAnticipos As Decimal = 0
        For Each h In dgvCuentas.Table.Records
            'If i.GetValue("abonado") <= 0 Then
            '    Throw New Exception("El monto abonado debe sre mayor a cero")
            'End If
            SumaPagos += CDec(h.GetValue("abonado"))
        Next
        pagoCupones = TextCuponImporte.DecimalValue
        pagoAnticipos = TextValoranticipo.DecimalValue
        SumaPagos = SumaPagos + pagoCupones + pagoAnticipos
        Return SumaPagos
    End Function

    'Private Function SumaPagos() As Decimal
    '    SumaPagos = 0
    '    Dim pagoCupones As Decimal = 0
    '    Dim pagoAnticipos As Decimal = 0
    '    For Each i As Record In dgvCuentas.Table.Records
    '        'If i.GetValue("abonado") <= 0 Then
    '        '    Throw New Exception("El monto abonado debe sre mayor a cero")
    '        'End If
    '        SumaPagos += CDec(i.GetValue("abonado"))
    '    Next
    '    pagoCupones = 0 'TextCuponImporte.DecimalValue
    '    pagoAnticipos = TextValoranticipo.DecimalValue
    '    SumaPagos = SumaPagos + pagoCupones + pagoAnticipos
    '    Return SumaPagos
    'End Function

    Private Sub BtnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        GrabarEnFormBasico()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            TextNumIdentrazon.Enabled = True
            TextNumIdentrazon.Clear()
            TextProveedor.Clear()
            TextProveedor.Enabled = False
            TextNumIdentrazon.Select()
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            TextNumIdentrazon.Enabled = False
            cboTipoDoc.Text = "BOLETA"
            TextNumIdentrazon.Text = VarClienteGeneral.idEntidad
            TextProveedor.Text = VarClienteGeneral.nombreCompleto
            TextProveedor.Tag = VarClienteGeneral.idEntidad
            TextProveedor.Enabled = True
            TextProveedor.Focus()
            TextProveedor.SelectAll()

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextProveedor.Tag IsNot Nothing Then

            If Not TextProveedor.Tag = VarClienteGeneral.idEntidad Then

                Dim f As New frmCrearENtidades(CInt(TextProveedor.Tag))
                f.CaptionLabels(0).Text = "Editar Cliente"
                f.strTipo = TIPO_ENTIDAD.CLIENTE
                f.intIdEntidad = TextProveedor.Tag
                'f.UbicarEntidad(dgvProveedor.Table.CurrentRecord.GetValue("idEntidad"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                Dim cliente = entidadSA.UbicarEntidadPorID(CInt(TextProveedor.Tag)).FirstOrDefault

                If cliente IsNot Nothing Then
                    TextNumIdentrazon.Text = cliente.nrodoc
                    TextProveedor.Text = cliente.nombreCompleto
                    TextProveedor.Tag = cliente.idEntidad
                End If
            Else
                MessageBox.Show("Seleccione Solo RUC O DNI para editar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe seleccionar un cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ChPagoAvanzado_OnChange(sender As Object, e As EventArgs) Handles ChPagoAvanzado.OnChange
        If ChPagoAvanzado.Checked = True Then
            chCredito.Checked = False
            LblPagoCredito.Visible = False
            '    chCobranzaParcial.Checked = False
            '  PanelCupon.Visible = False
            ErrorProvider1.Clear()
            GetMappingColumnsGrid()
        Else
            '     PanelCupon.Visible = False
            ChPagoAvanzado.Checked = True
        End If
    End Sub
    Private Sub ValidacionCredito()
        LblPagoCredito.Text = "VENTA AL CREDITO"
        lblPagoVenta.Text = CDec(txtTotalPagar.Text)
        LblPagoCredito.Visible = True
        lblPagoVenta.Visible = True
        dgvCuentas.Table.Records.DeleteAll()
    End Sub
    Private Sub chCredito_OnChange(sender As Object, e As EventArgs) Handles chCredito.OnChange
        If chCredito.Checked = True Then
            chCredito.Checked = True
            LblPagoCredito.Visible = True
            'chCobranzaParcial.Checked = False
            ChPagoAvanzado.Checked = False
            ErrorProvider1.Clear()
            ValidacionCredito()
        Else
            chCredito.Checked = True
            LblPagoCredito.Visible = True
        End If
    End Sub

    'Private Sub dgvCuentas_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs)
    '    Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
    '    Try
    '        Select Case ColIndex
    '            Case 3
    '                Dim pagos As Decimal = SumaPagos()

    '                LblPagoCredito.Text = "SALDO POR COBRAR"

    '                lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(SumaPagos())

    '                If (lblPagoVenta.Text = CDec(0.0)) Then
    '                    ErrorProvider1.Clear()
    '                End If

    '                If pagos > CDec(txtTotalPagar.Text) Then
    '                    MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
    '                    Exit Sub
    '                End If
    '        End Select
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Verificar montos del pago")
    '    End Try
    'End Sub

    Private Sub BunifuCustomLabel4_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel4.Click


        If validarPermisos(PermisosDelSistema.VENTA_, AutorizacionRolList) = 1 Then



            If ListaCajasActivas.Count = 0 Or ListaCajasActivas Is Nothing Then
                MessageBox.Show("Debe registrar una caja para realizar la venta")
                ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                 .estadoCaja = "A"
                                                                 })
                Exit Sub
            End If

            If GconfigCaja = "2" Then

                Dim querybox = (From i In ListaCajasActivas
                                Where i.idPersona = usuario.IDUsuario And i.estadoCaja = "A").FirstOrDefault

                If querybox IsNot Nothing Then
                Else
                    MessageBox.Show("Su usuario no tiene una caja aperturada")
                    Exit Sub
                End If
            End If
            If ButtonAdv5.Text = "NOTA VENTA" Then
                Dim f As New FormVentaNueva
                f.ComboComprobante.Text = "NOTA DE VENTA"
                f.StartPosition = FormStartPosition.CenterParent
                f.Show(Me)
            Else
                Dim f As New FormVentaNueva
                f.ComboComprobante.Text = "VENTA"
                f.StartPosition = FormStartPosition.CenterParent
                f.Show(Me)
            End If
        End If

        'If ListaCajasActivas.Count = 0 Or ListaCajasActivas Is Nothing Then
        '    MessageBox.Show("Debe registrar una caja para realizar la venta")
        '    ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
        '                                                     .idEmpresa = Gempresas.IdEmpresaRuc,
        '                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '                                                     .estadoCaja = "A"
        '                                                     })
        '    Exit Sub
        'End If
        'Dim f As New FormVentaNueva
        'f.ComboComprobante.Text = "VENTA"
        'f.StartPosition = FormStartPosition.CenterParent
        'f.Show(Me)
    End Sub

    Private Sub TextNumIdentrazon_TextChanged(sender As Object, e As EventArgs) Handles TextNumIdentrazon.TextChanged

    End Sub

#Region "ClienteNuevo"

    Private Function GetConsultarDNIReniec(Dni As String) As String
        Dim CLIENTE As New WebClient
        Dim PAGINA As Stream = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" & Dni)
        Dim LECTOR As New StreamReader(PAGINA)
        Dim MIHTML As String = LECTOR.ReadToEnd
        ' Dim array = MIHTML.Split("|")

        Dim nombres = MIHTML.Replace("|", Space(1))
        Return Trim(nombres)
    End Function

    Private Function GetValidarLocalDB(idEntidad As String) As Boolean
        GetValidarLocalDB = False
        Dim entidadSA As New entidadSA

        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", idEntidad)
        If entidad IsNot Nothing Then
            SelRazon = New entidad
            SelRazon = entidad
            TextProveedor.Text = entidad.nombreCompleto
            TextProveedor.Tag = entidad.idEntidad
            GetValidarLocalDB = True
            PictureLoad.Visible = False

            If TextProveedor.Text.Trim.Length > 0 Then
                BtOperacion.Select()
                ' btOperacion.Focus()
            Else
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
            End If
        End If
    End Function

    Private Sub GrabarEntidadRapida()
        Dim obEntidad As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            obEntidad.idEmpresa = Gempresas.IdEmpresaRuc
            obEntidad.idOrganizacion = GEstableciento.IdEstablecimiento
            obEntidad.tipoEntidad = "CL"
            obEntidad.tipoDoc = SelRazon.tipoDoc
            obEntidad.tipoPersona = SelRazon.tipoPersona
            obEntidad.nrodoc = SelRazon.nrodoc
            obEntidad.nombreCompleto = TextProveedor.Text.Trim
            obEntidad.cuentaAsiento = "1213"
            obEntidad.direccion = SelRazon.direccion
            obEntidad.estado = StatusEntidad.Activo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            TextProveedor.Tag = codx
            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = TextNumIdentrazon.Text.Trim
            entidad.nombreCompleto = obEntidad.nombreCompleto
            entidad.tipoDoc = obEntidad.tipoDoc
            Me.Tag = entidad
            'If RadioButton2.Checked = True Then
            '    textPersona.Focus()
            '    textPersona.Select()
            'ElseIf RadioButton1.Checked = True Then
            '    txtruc.Focus()
            '    txtruc.Select()
            'End If
            'Transporte.ListaEmpresas.Add(entidad)

            '    Dispose()
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
    End Sub

    Private Async Sub GetConsultaSunatAsync(ruc As String)
        SelRazon = New entidad
        Dim nroDoc = ruc.Substring(0, 1).ToString
        If nroDoc = "1" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                If company.ContribuyenteTipo = "PERSONA NATURAL SIN NEGOCIO" Then
                    SelRazon.tipoPersona = "N"
                    SelRazon.tipoDoc = "6"
                End If
                SelRazon.tipoEntidad = "CL"
                SelRazon.nombreCompleto = company.RazonSocial
                TextProveedor.Text = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.nrodoc = company.Ruc
                SelRazon.direccion = company.DomicilioFiscal
                GrabarEntidadRapida()
                PictureLoad.Visible = False
            Else
                TextProveedor.Clear()
                PictureLoad.Visible = False
            End If
        ElseIf nroDoc = "2" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                SelRazon.tipoPersona = "J"
                SelRazon.tipoDoc = "6"
                '  End If
                SelRazon.nombreCompleto = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                TextProveedor.Text = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.direccion = company.DomicilioFiscal
                SelRazon.nrodoc = company.Ruc
                'If company.RepresentanteLegal IsNot Nothing Then
                '    If company.RepresentanteLegal.Dni41094462 IsNot Nothing Then
                '        With company.RepresentanteLegal.Dni41094462
                '            txtContacto.Text = String.Format("{0}/{1}/{2}", .Cargo, .Nombre, .Desde)
                '        End With
                '    End If
                'End If
                GrabarEntidadRapida()
                PictureLoad.Visible = False
            Else
                TextProveedor.Clear()
                PictureLoad.Visible = False
            End If
        End If

    End Sub

    Private Sub GrabarEnFormBasico()
        Dim f As New frmCrearENtidades
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim ent = CType(f.Tag, entidad)
            TextNumIdentrazon.Text = ent.nrodoc
            TextProveedor.Text = ent.nombreCompleto
            TextProveedor.Tag = ent.idEntidad
        Else
            TextNumIdentrazon.Text = String.Empty
            TextProveedor.Text = String.Empty
            TextProveedor.Tag = Nothing
        End If
    End Sub
#End Region

    Private Sub TextNumIdentrazon_KeyDown(sender As Object, e As KeyEventArgs) Handles TextNumIdentrazon.KeyDown
        Dim nombres = String.Empty
        Try
            'TextNumIdentrazon.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case TextNumIdentrazon.Text.Trim.Length
                    Case 8 'dni

                        SelRazon = New entidad

                        If My.Computer.Network.IsAvailable = True Then
                            PictureLoad.Visible = True
                            nombres = GetConsultarDNIReniec(TextNumIdentrazon.Text.Trim)

                            If nombres.Trim.Length > 0 Then

                                If nombres = "DNI no encontrado en Padrón Electoral" Then
                                    TextNumIdentrazon.Clear()
                                    TextProveedor.Text = String.Empty
                                    TextProveedor.Tag = Nothing
                                    PictureLoad.Visible = False
                                    Exit Sub
                                End If

                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = nombres
                                SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                TextProveedor.Text = nombres

                                Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)

                                If existeEnDB Is Nothing Then
                                    TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    GrabarEntidadRapida()
                                    PictureLoad.Visible = False
                                Else
                                    TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    TextProveedor.Tag = existeEnDB.idEntidad
                                    'If RadioButton2.Checked = True Then
                                    BtOperacion.Select()
                                    'TextFiltrar.Select()
                                    'ElseIf RadioButton1.Checked = True Then
                                    '    txtruc.Focus()
                                    '    txtruc.Select()
                                    'End If
                                End If
                            Else
                                TextNumIdentrazon.Clear()
                                TextProveedor.Text = String.Empty
                                TextProveedor.Tag = Nothing
                            End If
                            PictureLoad.Visible = False
                        Else

                            'CUANDO NO HAY CONEXION A INTERNET
                            Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)
                            If existeEnDB Is Nothing Then
                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = TextProveedor.Text.Trim
                                SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'GrabarEntidadRapida()
                                GrabarEnFormBasico()
                                PictureLoad.Visible = False
                            Else
                                TextProveedor.Text = existeEnDB.nombreCompleto
                                TextProveedor.Tag = existeEnDB.idEntidad
                                TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'If RadioButton2.Checked = True Then
                                ''TextFiltrar.Focus()
                                BtOperacion.Select()
                                'ElseIf RadioButton1.Checked = True Then
                                '    txtruc.Focus()
                                '    txtruc.Select()
                                'End If
                            End If
                        End If



                    Case 11 'razonSocial
                        PictureLoad.Visible = True
                        Dim objeto As Boolean = ValidationRUC(TextNumIdentrazon.Text.Trim)
                        If objeto = False Then
                            PictureLoad.Visible = False
                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            TextProveedor.Clear()
                            Exit Sub
                        End If

                        If My.Computer.Network.IsAvailable = True Then
                            'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                            If GetValidarLocalDB(TextNumIdentrazon.Text.Trim) = False Then
                                GetConsultaSunatAsync(TextNumIdentrazon.Text.Trim)
                                If TextProveedor.Text.Trim.Length > 0 Then
                                    BtOperacion.Select()
                                    ' 'TextFiltrar.Focus()
                                Else
                                    TextNumIdentrazon.Clear()
                                    TextNumIdentrazon.Select()
                                End If
                            End If
                        Else
                            'SI NO HAY CONEXION A INTERNET
                            If GetValidarLocalDB(TextNumIdentrazon.Text.Trim) = False Then
                                Dim nroDoc = TextNumIdentrazon.Text.Trim.Substring(0, 1).ToString
                                If nroDoc = "1" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "N"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico()
                                    PictureLoad.Visible = False
                                    If TextProveedor.Text.Trim.Length > 0 Then
                                        BtOperacion.Select()
                                        ' 'TextFiltrar.Focus()
                                    Else
                                        TextNumIdentrazon.Clear()
                                        TextNumIdentrazon.Select()
                                    End If
                                ElseIf nroDoc = "2" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "J"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico()
                                    PictureLoad.Visible = False
                                    If TextProveedor.Text.Trim.Length > 0 Then
                                        BtOperacion.Select()
                                        'TextFiltrar.Focus()
                                    Else
                                        TextNumIdentrazon.Clear()
                                        TextNumIdentrazon.Select()
                                    End If
                                End If
                            End If
                        End If

                    Case Else
                        TextProveedor.Text = String.Empty
                        TextNumIdentrazon.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select

            End If
            '    TextNumIdentrazon.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then
                PictureLoad.Visible = False
                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
                TextNumIdentrazon.Focus()
                TextProveedor.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BunifuCustomLabel5_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel5.Click
        Dim f As New FormVentaNueva
        f.ComboComprobante.Text = "PROFORMA"
        f.StartPosition = FormStartPosition.CenterParent
        f.Show(Me)
    End Sub

    Private Sub bunifuImageButton2_Click(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click
        Close()
    End Sub


    Function LogeoUsuarioCajaCodi()
        Dim usuarioSel = UsuariosList.Where(Function(o) o.IDUsuario = usuario.IDUsuario).FirstOrDefault
        If usuarioSel IsNot Nothing Then

            Return usuarioSel.codigo

        Else
            Return 0
        End If

    End Function
    Private Sub BunifuCustomLabel3_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel3.Click





        Me.Cursor = Cursors.WaitCursor

        PanelHeader1.Visible = False
        PanelPrincipal.Visible = False
        UCResumenVentas.Visible = True
        UCCuentasXcobrar.Visible = False
        UCCuentasXpagar.Visible = False

        If validarPermisos(PermisosDelSistema.CIERRE_DE_CAJA_, AutorizacionRolList) = 1 Then
            'Dim Form As New FormCierreXUsuario()
            'Form.StartPosition = FormStartPosition.CenterScreen
            'Form.ShowDialog(Me)
            Dim codigo = LogeoUsuarioCajaCodi()

            UCResumenVentas.TextCodigoVendedor.Text = codigo
            UCResumenVentas.CargarCierreXUsuario()

            'UCResumenVentas = New UCResumenVentas(codigo, Me)
            'PanelBody.Controls.Add(UCResumenVentas)
            'CargarAlertaArqueo()
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow


    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        PanelHeader1.Visible = True
        PanelPrincipal.Visible = True
        UCResumenVentas.Visible = False
        UCCuentasXcobrar.Visible = False
        UCCuentasXpagar.Visible = False
    End Sub

    Private Sub BunifuCustomLabel6_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel6.Click
        PanelHeader1.Visible = False
        PanelPrincipal.Visible = False
        UCResumenVentas.Visible = False
        UCCuentasXcobrar.Visible = True
        UCCuentasXpagar.Visible = False
    End Sub

    Private Sub PictureLoading_Click(sender As Object, e As EventArgs) Handles PictureLoading.Click

    End Sub

    Private Sub BunifuCustomLabel7_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel7.Click
        PanelHeader1.Visible = False
        PanelPrincipal.Visible = False
        UCResumenVentas.Visible = False
        UCCuentasXcobrar.Visible = False
        UCCuentasXpagar.Visible = True
    End Sub

    Private Sub BunifuCustomLabel1_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel1.Click
        Me.Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ABRIR_CAJA_Formulario___, AutorizacionRolList) Then
        If validarPermisos(PermisosDelSistema.CIERRE_DE_CAJA_, AutorizacionRolList) = 1 Then
            Dim f As New FormCrearCajero
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)

            CargarAlertaArqueo()

        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub BunifuCustomLabel14_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel14.Click
        Dispose()
        FormLogeoNuevoIntro()
    End Sub

    Private Sub ComboCaja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboCaja.SelectedIndexChanged

    End Sub

    Private Sub ComboCaja_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboCaja.SelectedValueChanged
        Cursor = Cursors.WaitCursor
        If IsNumeric(ComboCaja.SelectedValue) Then
            GetInicioCuentas(Integer.Parse(ComboCaja.SelectedValue))
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvCuentas_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCuentas.TableControlCellClick

    End Sub

    Private Sub dgvCuentas_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCuentas.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Try
            ' Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
            Dim cc As GridCurrentCell = dgvCuentas.TableControl.CurrentCell
            cc.ConfirmChanges()
            If cc.Renderer IsNot Nothing Then

                If cc.ColIndex > -1 Then
                    Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                    If style.TableCellIdentity.Column.Name = "abonado" Then
                        Dim pagos As Decimal = 0
                        Select Case DocumentoVenta.moneda
                            Case "2"
                                Dim tipocambio = CDec(style.TableCellIdentity.Table.CurrentRecord.GetValue("tipocambio"))
                                Dim pagoCelSoles As Decimal = Math.Round(CDec(style.TableCellIdentity.Table.CurrentRecord.GetValue("abonado")) / tipocambio, 2)
                                style.TableCellIdentity.Table.CurrentRecord.SetValue("abonadoME", pagoCelSoles)

                                pagos = SumaPagosME()

                                lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(SumaPagosME())

                                If (lblPagoVenta.Text = CDec(0.0)) Then
                                    ErrorProvider1.Clear()
                                End If

                                If pagos > CDec(DocumentoVenta.ImporteExtranjero) Then
                                    MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                                    dgvCuentas.Table.CurrentRecord.SetValue("abonadoME", 0)
                                    '  TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - pagos
                                    Exit Sub
                                End If

                            Case "1"

                                '  TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - pagos
                                'style.TableCellIdentity.Table.CurrentRecord.SetValue("abonadoME", 0)

                                pagos = SumaPagos()

                                lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(pagos)
                                If pagos > DocumentoVenta.ImporteNacional Then
                                    MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                                    dgvCuentas.Table.CurrentRecord.SetValue("abonadoME", 0)
                                    'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - pagos
                                    Exit Sub
                                End If
                        End Select




                        ' style.TableCellIdentity.Table.CurrentRecord.SetValue("tipocambio", 0)


                    ElseIf style.TableCellIdentity.Column.Name = "abonadoME" Then

                        If style.TableCellIdentity.Table.CurrentRecord IsNot Nothing Then
                            Dim pagos As Decimal = 0 'SumaPagosME()

                            Dim tipocambio = CDec(style.TableCellIdentity.Table.CurrentRecord.GetValue("tipocambio"))
                            Dim pagoCelSoles As Decimal = Math.Round(CDec(style.TableCellIdentity.Table.CurrentRecord.GetValue("abonadoME")) * tipocambio, 2)
                            style.TableCellIdentity.Table.CurrentRecord.SetValue("abonado", pagoCelSoles)

                            Select Case DocumentoVenta.moneda
                                Case "2"
                                    pagos = SumaPagosME()

                                    lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(pagos)


                                    If pagos > DocumentoVenta.ImporteExtranjero Then
                                        MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        dgvCuentas.Table.CurrentRecord.SetValue("abonadoME", 0)
                                        dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                                        '  TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())
                                        Exit Sub
                                    End If
                                Case "1"
                                    pagos = SumaPagos()

                                    lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(pagos)


                                    If pagos > DocumentoVenta.ImporteNacional Then
                                        MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        dgvCuentas.Table.CurrentRecord.SetValue("abonadoME", 0)
                                        dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                                        '  TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())
                                        Exit Sub
                                    End If
                            End Select
                        End If

                        'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())

                    ElseIf style.TableCellIdentity.Column.Name = "tipocambio" Then
                        Dim pagos As Decimal = 0
                        'Dim style As GridTableCellStyleInfo = e.TableControl.Model(cc.RowIndex, cc.ColIndex)
                        If style.TableCellIdentity.Table.CurrentRecord Is Nothing Then Exit Sub
                        Dim r = style.TableCellIdentity.Table.CurrentRecord
                        Select Case r.GetValue("moneda")
                            Case 1
                                Dim valorSoles = CDec(r.GetValue("abonado"))
                                Dim valorTipoCambio As Decimal = cc.Renderer.ControlText
                                Dim valorDolares = 0 ' 
                                If valorTipoCambio > 0 Then
                                    valorDolares = Math.Round(valorSoles / valorTipoCambio, 2)
                                Else
                                    valorDolares = 0
                                End If
                                r.SetValue("abonadoME", valorDolares)

                                Select Case DocumentoVenta.moneda
                                    Case "2"
                                        pagos = SumaPagosME()

                                        If pagos > CDec(DocumentoVenta.ImporteExtranjero) Then
                                            MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            dgvCuentas.Table.CurrentRecord.SetValue("abonadoME", 0)
                                            dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                                            dgvCuentas.Table.CurrentRecord.SetValue("tipocambio", 0)
                                            Exit Sub
                                        End If

                                    Case "1"
                                        pagos = SumaPagos()

                                        If pagos > CDec(DocumentoVenta.ImporteNacional) Then
                                            MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            dgvCuentas.Table.CurrentRecord.SetValue("abonadoME", 0)
                                            dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                                            dgvCuentas.Table.CurrentRecord.SetValue("tipocambio", 0)
                                            Exit Sub
                                        End If
                                End Select

                            Case 2
                                Dim valorDolares = CDec(r.GetValue("abonadoME"))
                                Dim valorTipoCambio As Decimal = cc.Renderer.ControlText
                                Dim valorSoles As Decimal = 0

                                If valorTipoCambio > 0 Then
                                    valorSoles = Math.Round(valorDolares * valorTipoCambio, 2)
                                    r.SetValue("abonado", valorSoles)
                                Else
                                    valorSoles = 0
                                    r.SetValue("abonado", valorSoles)
                                End If

                                Select Case DocumentoVenta.moneda
                                    Case "2"
                                        pagos = SumaPagosME()

                                        If pagos > CDec(DocumentoVenta.ImporteExtranjero) Then
                                            MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            dgvCuentas.Table.CurrentRecord.SetValue("abonadoME", 0)
                                            dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                                            dgvCuentas.Table.CurrentRecord.SetValue("tipocambio", 0)
                                            Exit Sub
                                        End If

                                    Case "1"
                                        pagos = SumaPagos()

                                        If pagos > CDec(DocumentoVenta.ImporteNacional) Then
                                            MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            dgvCuentas.Table.CurrentRecord.SetValue("abonadoME", 0)
                                            dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                                            dgvCuentas.Table.CurrentRecord.SetValue("tipocambio", 0)
                                            Exit Sub
                                        End If
                                End Select

                        End Select

                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Verificar montos del pago")
        End Try
    End Sub

    Private Sub GradientPanel19_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel19.Paint

    End Sub

    Private Sub dgvCuentas_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCuentas.QueryCellStyleInfo
        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement


            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "abonado")) Then
                Dim moneda As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("moneda").ToString()

                If moneda IsNot Nothing Then
                    Select Case moneda
                        Case "1"
                            'e.Style.BackColor = Color.Yellow
                            'e.Style.TextColor = Color.Black
                            e.Style.ReadOnly = False
                            e.Style.BackColor = Color.FromArgb(255, 255, 128)
                        Case Else
                            e.Style.ReadOnly = True
                            e.Style.BackColor = Color.White
                    End Select
                End If

            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "abonadoME")) Then
                Dim moneda As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("moneda").ToString()

                If moneda IsNot Nothing Then
                    Select Case moneda
                        Case "2"
                            'e.Style.BackColor = Color.Yellow
                            'e.Style.TextColor = Color.Black
                            e.Style.ReadOnly = False
                            e.Style.BackColor = Color.FromArgb(255, 255, 128)
                        Case Else
                            e.Style.ReadOnly = True
                            e.Style.BackColor = Color.White
                    End Select
                End If
            End If
        End If
    End Sub

    Private Sub ComboCaja_Click(sender As Object, e As EventArgs) Handles ComboCaja.Click

    End Sub

    Private Sub BunifuCustomLabel9_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel9.Click
        Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVA_SALIDA_CAJA_Botón___, AutorizacionRolList) Then
        If validarPermisos(PermisosDelSistema.SALIDA_DE_EFECTIVO_, AutorizacionRolList) = 1 Then
            'Else
            '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
            '    Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
            '    If Not IsNothing(cajaUsuario) Then
            '  GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)
            Dim f As New FormPagoEgreso
            f.txtAnioCompra.Text = DateTime.Now.Year
            f.cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
            f.txtHora.Value = DateTime.Now
            f.TxtDia.Text = DateTime.Now.Day ' ""
            f.StartPosition = FormStartPosition.CenterParent
            f.txtTipoCambio.Value = TmpTipoCambio
            f.ShowDialog(Me)
            'Else
            '    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuCustomLabel8_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel8.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVO_INGRESO_Botón___, AutorizacionRolList) Then

        If validarPermisos(PermisosDelSistema.INGRESO_DE_EFECTIVO_, AutorizacionRolList) = 1 Then


            ' Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
            'If Not IsNothing(cajaUsuario) Then
            '    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

            Dim f As New FormRealizacionDePagos
            f.txtAnioCompra.Text = DateTime.Now.Year
            f.cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
            f.txtHora.Value = DateTime.Now
            f.TxtDia.Text = DateTime.Now.Day ' ""
            f.StartPosition = FormStartPosition.CenterParent
            f.txtTipoCambio.Value = TmpTipoCambio
            f.ShowDialog(Me)
            'Else
            '    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TextTotalPagosCliente_TextChanged(sender As Object, e As EventArgs) Handles TextTotalPagosCliente.TextChanged
        If TextTotalPagosCliente.DecimalValue > 0 Then
            CalcularPagoDelCliente()
        Else
            LabelVueltoCliente.Text = "0.00"
        End If
    End Sub

    Private Sub CalcularPagoDelCliente()
        Dim totalPago As Decimal = TextTotalPagosCliente.DecimalValue
        Dim totalVenta As Decimal = txtTotalPagar.Value

        If totalVenta > totalPago Then
            LabelVueltoCliente.Text = "0.00"
            Exit Sub
        End If
        Dim vuelto As Decimal = totalPago - totalVenta
        LabelVueltoCliente.Text = vuelto.ToString("N2")
    End Sub

    Private Sub PanelTop_Paint(sender As Object, e As PaintEventArgs) Handles PanelTop.Paint

    End Sub

    Private Sub BunifuImageButton3_Click(sender As Object, e As EventArgs) Handles BunifuImageButton3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        System.Diagnostics.Process.Start("http://www.spk.com.pe")
    End Sub

    Private Sub BunifuCustomLabel18_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel18.Click
        Try
            Cursor = Cursors.WaitCursor
            BunifuCustomLabel1.Enabled = False
            If BunifuCustomLabel18.Text > 0 Then
            ListBoxClosedPending()
                Me.PopupProductos.Size = New Size(280, 147)
                Me.PopupProductos.ParentControl = Me.BunifuCustomLabel18
                Me.PopupProductos.ShowPopup(Point.Empty)
                Cursor = Cursors.Default
                BunifuCustomLabel1.Enabled = True
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            BunifuCustomLabel1.Enabled = True
        End Try
    End Sub


    Public Sub ListBoxClosedPending()


        Dim boxUserSA As New cajaUsuarioSA
        Dim be As New cajaUsuario
        be.idEmpresa = Gempresas.IdEmpresaRuc
        be.idEstablecimiento = GEstableciento.IdEstablecimiento
        be.idPersona = usuario.IDUsuario
        Dim ListOpenBox = boxUserSA.ListPendingForUserWithImport(be)

        ListAlertas.Items.Clear()
        For Each x In ListOpenBox
            Dim n As New ListViewItem(x.idcajaUsuario)
            n.SubItems.Add(x.fechaRegistro)
            n.SubItems.Add(x.fechaCierre)
            n.SubItems.Add(x.montoMN)
            n.SubItems.Add(x.montoME)
            ListAlertas.Items.Add(n)
        Next
        ListAlertas.Refresh()


    End Sub

    Private Sub BunifuCustomLabel20_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel20.Click
        PanelHeader1.Visible = True
        PanelPrincipal.Visible = True
        UCResumenVentas.Visible = False
        UCCuentasXcobrar.Visible = False
        UCCuentasXpagar.Visible = False
    End Sub

#End Region

End Class