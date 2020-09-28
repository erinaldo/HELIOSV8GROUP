Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmAportesCaja

    Inherits frmMaster
    Public Property ListaMovimientos As New List(Of movimiento)

#Region "Variables"

    Dim colorx As New GridMetroColors()
    Dim srtNomAlmacen As String = Nothing
    Dim strUM As String = Nothing
    Dim strTipoEx As String = Nothing
    Dim strCuenta As String = Nothing
    Dim intIdEstableAlm As Integer
    Dim strIdPresentacion As String = Nothing
    Public fecha As DateTime
    Dim selAlmacenPC As String

    Public Property ListaAsientonTransito As New List(Of asiento)
    Public Property ManipulacionEstado() As String
    Private cantidaExistente As New List(Of Integer)
    Dim cuentaMascaraSA As New cuentaMascaraSA
    Dim cuentaMascara As New cuentaMascara
    Private comboTable As DataTable
    Private comboTableCuentas As DataTable
    Public Property sumaMN() As Decimal
    Public Property sumaME() As Decimal
#End Region


    Public Property ListaAsientos As New List(Of asiento)




    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'CargarListas()
        'lblPerido.Text = PeriodoGeneral

        configuracionModuloV2(Gempresas.IdEmpresaRuc, "OES", Me.Text, GEstableciento.IdEstablecimiento)
        'ListaDefaultDeInicio()
        'GridCFG(dgvCompra)
        ObtenerTablaGenerales()
        cargarDatos()
        DockingInicio()
        cboTipoCuenta.SelectedIndex = -1
        cboDepositoHijo.DataSource = New List(Of estadosFinancieros)
    End Sub

    Public Sub cargarCajasEditar(entidad As String)
        cargarCtasFinanEditar(entidad)
    End Sub


    Sub GridCFG(GGC As GridGroupingControl)
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(15, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Private Sub DockingInicio()


        dockingManager1.DockControlInAutoHideMode(PopupControlContainer1, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 250)
        'Me.DockingClientPanel1.AutoScroll = True
        'Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        dockingManager1.SetDockLabel(PopupControlContainer1, "Diferencia T/C")
        dockingManager1.SetDockVisibility(PopupControlContainer1, False)

        dockingManager1.DockControlInAutoHideMode(PopupControlContainer3, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 250)
        'Me.DockingClientPanel1.AutoScroll = True
        'Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        dockingManager1.SetDockLabel(PopupControlContainer3, "Diferencia Pagos")
        dockingManager1.SetDockVisibility(PopupControlContainer3, False)
        'dockingManager1.CloseEnabled = False

    End Sub


#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        'If Not parpadear Then
        '    lblEstado.ForeColor = lblEstado.BackColor
        '    lblEstado.BackColor = Color.Yellow
        'Else
        '    lblEstado.ForeColor = SystemColors.WindowText
        'End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            'lblEstado.ForeColor = Color.Navy
            'lblEstado.BackColor = Color.Transparent
            PanelError.Visible = False
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

#Region "Métodos"

    'Public Sub configuracionModulo(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion = New GConfiguracionModulo
    '            GConfiguracion.IdModulo = .idModulo
    '            GConfiguracion.NomModulo = strNomModulo
    '            GConfiguracion.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion.ConfigComprobante = .IdEnumeracion
    '                        GConfiguracion.TipoComprobante = .tipo
    '                        GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                        GConfiguracion.Serie = .serie
    '                        GConfiguracion.ValorActual = .valorInicial
    '                    End With
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen
    '                    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '                    End With
    '                End With
    '            End If
    '            If Not IsNothing(.ConfigentidadFinanciera) Then
    '                With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '                    GConfiguracion.IDCaja = .idestado
    '                    GConfiguracion.NomCaja = .descripcion
    '                End With
    '            End If

    '        End With
    '    Else
    '        lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '    End If
    'End Sub

    Public Sub configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
        Try

            Dim moduloConfiguracionSA As New ModuloConfiguracionSA
            Dim moduloConfiguracion As New moduloConfiguracion
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)
                GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
                GConfiguracion.Serie = RecuperacionNumeracion.serie
                GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function GetTableAsientos() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("id", GetType(String))
        dt.Columns.Add("name", GetType(String))

        Dim dr As DataRow = dt.NewRow()
        dr(0) = "D"
        dr(1) = "DEBE"
        dt.Rows.Add(dr)

        Dim dr1 As DataRow = dt.NewRow()
        dr1(0) = "H"
        dr1(1) = "HABER"
        dt.Rows.Add(dr1)

        Return dt

    End Function


    Public Sub GetTableAlmacen2()
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        comboTableh = New DataTable("Cuentas")
        comboTableh.Columns.Add("idCuenta")
        comboTableh.Columns.Add("descripcionCuenta")

        For Each i In cuentaSA.ObtenerCuentasPorEmpresaEscalableV2(Gempresas.IdEmpresaRuc)
            comboTableh.Rows.Add(New Object() {i.cuenta, i.descripcion})
        Next

    End Sub

    Function GetMaxIDMovimiento() As Integer
        If ListaMovimientos.Count > 0 Then
            Return ListaMovimientos.Max(Function(o) o.idmovimiento)
        Else
            Return 0
        End If
    End Function

    Sub RegsitarMovimiento(nAsiento As asiento)
        Dim n As New movimiento
        n.cuenta = "10"
        n.idAsiento = nAsiento.idAsiento
        n.idmovimiento = GetMaxIDMovimiento() + 1
        n.tipo = "D"
        n.Cant = 1
        n.PUmn = 0
        n.PUme = 0
        n.monto = 0
        n.montoUSD = 0
        ListaMovimientos.Add(n)
    End Sub

    Sub RegistrarAsientos()
        Dim nAsiento As New asiento

        If ListaAsientonTransito.Count > 0 Then
            nAsiento.idAsiento = ListaAsientonTransito.Count + 1
        Else
            nAsiento.idAsiento = 1
        End If
        nAsiento.Descripcion = "Asiento Nro. " & ListaAsientonTransito.Count + 1
        ListaAsientonTransito.Add(nAsiento)


    End Sub


    Sub updateMovimiento(r As Record)

        Try
            Dim consulta = (From n In ListaMovimientos _
                       Where n.idmovimiento = r.GetValue("id")).FirstOrDefault

            If Not IsNothing(consulta) Then
                consulta.cuenta = r.GetValue("cuenta")
                Dim md = r.GetValue("Modulo").ToString
                If md.Trim.Length > 0 Then
                    consulta.nombreEntidad = r.GetValue("Modulo")
                Else
                    consulta.nombreEntidad = String.Empty
                End If

                Dim des = r.GetValue("descripcion").ToString
                If des.Trim.Length > 0 Then
                    consulta.descripcion = r.GetValue("descripcion")
                Else
                    consulta.descripcion = String.Empty
                End If
                consulta.tipo = r.GetValue("tipoAsiento")
                consulta.Cant = r.GetValue("cant")
                consulta.PUmn = r.GetValue("pumn")
                consulta.PUme = r.GetValue("pume")
                consulta.monto = r.GetValue("importeMN")
                consulta.montoUSD = r.GetValue("importeME")
            End If

            '      RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message)
        End Try
    End Sub

    Private Sub cargarCtasFinanEditar(tipoCta As String)
        If tipoCta = "EF" Then
            cboTipoCuenta.SelectedText = "CUENTAS EN EFECTIVO"
            CargarCajasTipo("EF")
            cboDepositoHijo.Enabled = True
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("109")
            ListaDocPago(lista)
        ElseIf tipoCta = "BC" Then
            cboTipoCuenta.Text = "CUENTAS EN BANCO"
            CargarCajasTipo("BC")
            cboDepositoHijo.Enabled = True
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("007")
            lista.Add("111")
            ListaDocPago(lista)

        ElseIf tipoCta = "TC" Then
            cboTipoCuenta.Text = "TARJETA DE CREDITO"
            CargarCajasTipo("TC")
            cboDepositoHijo.Enabled = True
            Dim lista As New List(Of String)
            lista.Add("001")
            ListaDocPago(lista)
        End If

    End Sub

    Private Sub cargarCtasFinan()
        If cboTipoCuenta.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo("EF")
            cboDepositoHijo.Enabled = True
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("109")
            ListaDocPago(lista)
        ElseIf cboTipoCuenta.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo("BC")
            cboDepositoHijo.Enabled = True
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("007")
            lista.Add("111")
            ListaDocPago(lista)

        ElseIf cboTipoCuenta.Text = "TARJETA DE CREDITO" Then
            CargarCajasTipo("TC")
            cboDepositoHijo.Enabled = True
            Dim lista As New List(Of String)
            lista.Add("001")
            ListaDocPago(lista)
        End If
    End Sub

    Public Sub CargarTiposDeCambio()
        Dim dt As New DataTable
        Dim documentoCajaEtalleSA As New DocumentoCajaDetalleSA

        dt.Columns.Add("TC", GetType(Decimal))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))

        For Each i In documentoCajaEtalleSA.ObtenerCajaDetalleME(txtFondoME.Value, cboDepositoHijo.SelectedValue)
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.diferTipoCambio
            dr(1) = i.montoUsd
            dr(2) = i.montoSoles

            dt.Rows.Add(dr)

        Next
        dgvTipoCambio.DataSource = dt
    End Sub


    Public Sub CargarDiferenciasdeImporte()
        Dim dt As New DataTable
        Dim documentoCajaEtalleSA As New DocumentoCajaDetalleSA
        Dim ListadocumentoCajaEtalle As New List(Of documentoCajaDetalle)
        Dim sumatoriaMN As Decimal
        Dim sumatoriaME As Decimal
        Dim DifsumatoriaMN As Decimal
        Dim DifsumatoriaME As Decimal
        Dim diferenciaCaja As Decimal

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("TC", GetType(Decimal))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("TCCompra", GetType(Decimal))
        dt.Columns.Add("importeCompraMN", GetType(Decimal))
        dt.Columns.Add("importeCompraME", GetType(Decimal))
        dt.Columns.Add("difMNCajaMN", GetType(Decimal))
        dt.Columns.Add("difMNCajaME", GetType(Decimal))

        ListadocumentoCajaEtalle = documentoCajaEtalleSA.ObtenerCajaDetalleME(txtFondoME.Value, cboDepositoHijo.SelectedValue)

        Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Clear()
        Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Remove("Row1")

        Dim gridStackedHeaderRowDescriptor1 As New GridStackedHeaderRowDescriptor()
        gridStackedHeaderRowDescriptor1.Name = "Row1"

        Dim gridStackedHeaderRowDescriptor2 As New GridStackedHeaderRowDescriptor()
        gridStackedHeaderRowDescriptor1.Name = "Row2"

        ' Create an object for GridStackedHeaderDescriptor
        Dim gridStackedHeaderDescriptor1 As New GridStackedHeaderDescriptor()
        Dim gridStackedHeaderDescriptor2 As New GridStackedHeaderDescriptor()
        Dim gridStackedHeaderDescriptor3 As New GridStackedHeaderDescriptor()
        Dim gridStackedHeaderDescriptor4 As New GridStackedHeaderDescriptor()

        gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.Themed = False
        gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.TextColor = System.Drawing.Color.White
        gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.BackColor = Color.Red

        gridStackedHeaderDescriptor1.HeaderText = "CAJA Y BANCOS - " & cboDepositoHijo.Text

        gridStackedHeaderDescriptor1.Name = "StackedHeader 1"

        gridStackedHeaderDescriptor2.HeaderText = "CUENTAS POR PAGAR"
        gridStackedHeaderDescriptor2.Name = "StackedHeader 2"

        gridStackedHeaderDescriptor3.HeaderText = "DIFERENCIAS"
        gridStackedHeaderDescriptor3.Name = "StackedHeader 3"

        gridStackedHeaderDescriptor4.HeaderText = "DIFERENCIA T/C POR CAJA"
        gridStackedHeaderDescriptor4.Name = "StackedHeader 4"

        gridStackedHeaderDescriptor1.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("idDocumento"),
                                                                New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TC"),
                                                                 New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeMN"),
                                                                       New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeME")})


        gridStackedHeaderDescriptor2.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TCCompra"),
                                                                New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeCompraMN"),
                                                                       New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeCompraME")})

        gridStackedHeaderDescriptor3.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("difMNCajaMN"),
                                                                New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("difMNCajaME")})

        gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor1)
        gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor2)
        gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor3)
        gridStackedHeaderRowDescriptor2.Headers.Add(gridStackedHeaderDescriptor4)

        Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Add(gridStackedHeaderRowDescriptor2)
        Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Add(gridStackedHeaderRowDescriptor1)
        Me.dgvDiferencia.TopLevelGroupOptions.ShowStackedHeaders = True

        If Not IsNothing(ListadocumentoCajaEtalle) Then

            For Each i In ListadocumentoCajaEtalle
                Dim dr As DataRow = dt.NewRow()

                dr(0) = i.idDocumento
                dr(1) = i.diferTipoCambio
                dr(2) = i.montoSoles
                dr(3) = i.montoUsd
                dr(4) = txtTipoCambio.Value
                sumatoriaMN = CDec(i.montoUsd * txtTipoCambio.Value).ToString("N2")
                sumatoriaME = CDec(i.montoUsd)
                dr(5) = sumatoriaMN
                dr(6) = sumatoriaME
                DifsumatoriaMN = CDec((txtTipoCambio.Value - i.diferTipoCambio) * i.montoUsd).ToString("N2")
                DifsumatoriaME = CDec(i.montoUsd - sumatoriaME)
                dr(7) = DifsumatoriaMN
                dr(8) = DifsumatoriaME

                diferenciaCaja += DifsumatoriaMN

                dt.Rows.Add(dr)
            Next
            dgvDiferencia.DataSource = dt
            Me.dgvDiferencia.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'txtImporteCompramn.Value = sumatoriaMN
            txtDiferenciaMontos.Value = diferenciaCaja

        Else
        End If



    End Sub

    Private Sub cargarDatosCuenta(idCaja As Integer)
        Dim estadoSA As New EstadosFinancierosSA
        Dim estadoBL As New estadosFinancieros
        Dim estadoSaldoBL As New estadosFinancieros

        estadoBL = estadoSA.GetUbicar_estadosFinancierosPorID(idCaja)
        estadoSaldoBL = estadoSA.GetEstadoSaldoEFME(idCaja, txtFechaTrans.Value)
        If (Not IsNothing(estadoBL)) Then
            cboMoneda.SelectedValue = estadoBL.codigo
            txtCuentaO.Text = estadoBL.cuenta
            lblDeudaPendienteme.Text = estadoSaldoBL.importeBalanceME
            lblDeudaPendientemn.Text = estadoSaldoBL.importeBalanceMN

            Select Case cboMoneda.SelectedValue
                Case 1
                    pnNacional.Location = New Point(53, 22)
                    pnExtranjero.Location = New Point(549, 23)
                    pnExtranjero.Enabled = False
                    pnNacional.Enabled = True
                    pnExtranjero.Visible = True
                    pnTipoCambio.Visible = True
                    pnNacional.Visible = True
                    pnImpMEDisp.Location = New Point(170, 21)
                    pnImpMNDisp.Location = New Point(9, 21)
                    pnTipoCambio.Visible = False
                    pnExtranjero.Visible = False
                    pnDiferencia.Visible = False
                    txtTipoCambio.Value = TmpTipoCambio
                    pnDetalleEntrada.Enabled = True
                    pnImpMEDisp.Visible = False
                Case 2
                    pnImpMEDisp.Location = New Point(9, 21)
                    pnImpMNDisp.Location = New Point(170, 21)
                    pnExtranjero.Enabled = True
                    pnNacional.Enabled = False
                    pnImpMEDisp.Visible = True
                    Select Case lblMovimiento.Text
                        Case "OTRAS ENTRADAS A CAJA"
                            pnExtranjero.Visible = True
                            pnTipoCambio.Visible = True
                            pnNacional.Location = New Point(380, 22)
                            pnExtranjero.Location = New Point(53, 22)
                            pnNacional.Visible = True
                            pnTipoCambio.Visible = True
                            pnExtranjero.Visible = True
                            pnDiferencia.Visible = False
                            txtTipoCambio.Value = 0.0
                        Case "OTRAS SALIDAS DE CAJA"
                            pnExtranjero.Location = New Point(53, 22)
                            pnNacional.Location = New Point(380, 22)
                            pnTipoCambio.Location = New Point(270, 22)
                            pnExtranjero.Visible = True
                            pnTipoCambio.Visible = True
                            pnNacional.Visible = True
                            pnDiferencia.Visible = True

                    End Select
                    pnDetalleEntrada.Enabled = True
            End Select
        End If
    End Sub

    Public Sub CargarCajasTipo(strBusqueda As String)
        Dim estadoSA As New EstadosFinancierosSA
        Dim taBLASA As New tablaDetalleSA
        Dim ListaestadoBL As New List(Of estadosFinancieros)
        Dim estadoBL As New estadosFinancieros

        Try

            Me.cboDepositoHijo.DataSource = estadoSA.ObtenerEFPorCuentaFinanciera(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .tipo = strBusqueda,
                                                                                  .tipoConsulta = StatusTipoConsulta.XEmpresa})
            Me.cboDepositoHijo.DisplayMember = "descripcion"
            Me.cboDepositoHijo.ValueMember = "idestado"
            cboDepositoHijo.SelectedValue = -1
            cboDepositoHijo.Tag = 0

            cboMoneda.ValueMember = "codigoDetalle"
            cboMoneda.DisplayMember = "descripcion"
            cboMoneda.DataSource = taBLASA.GetListaTablaDetalle(4, "1")
            cboMoneda.SelectedValue = -1

        Catch ex As Exception

        End Try
    End Sub


    Public Sub ListaDocPago(listaCuenta As List(Of String))
        Dim tablaSA As New tablaDetalleSA
        Dim tabla As New List(Of tabladetalle)

        tabla = tablaSA.GetListaTablaDetalle(1, "1")
        tabla = (From n In tabla _
                     Where listaCuenta.Contains(n.codigoDetalle) _
                    Select n).ToList
        cboTipoDocumento.DataSource = tabla
        cboTipoDocumento.ValueMember = "codigoDetalle"
        cboTipoDocumento.DisplayMember = "descripcion"
        cboTipoDocumento.SelectedValue = "001"
    End Sub

    Public Sub ObtenerTablaGenerales()
        Dim tablaSA As New tablaDetalleSA

        cboEntidad.ValueMember = "codigoDetalle"
        cboEntidad.DisplayMember = "descripcion"
        cboEntidad.DataSource = tablaSA.GetListaTablaDetalle(3, "1")
        cboEntidad.SelectedValue = -1

        cbotipoOperacion.ValueMember = "codigoDetalle"
        cbotipoOperacion.DisplayMember = "descripcion"
        cbotipoOperacion.DataSource = tablaSA.GetListaTablaDetalleMotivo(12, "1", "17")
    End Sub


#End Region

#Region "Manipulación Data"
    Public Sub AsientoContableCaja()
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento

        asientoBL = New asiento
        asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
        asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
        'asientoBL.idEntidad = txtCajaOrigen.ValueMember
        'asientoBL.nombreEntidad = txtCajaOrigen.Text

        asientoBL.idEntidad = cboDepositoHijo.SelectedValue
        asientoBL.nombreEntidad = cboDepositoHijo.Text
        asientoBL.periodo = PeriodoGeneral
        Select Case cboTipoCuenta.Text
            Case "CUENTAS EN EFECTIVO"
                asientoBL.tipoEntidad = "EF"
            Case "CUENTAS EN BANCO"
                asientoBL.tipoEntidad = "BC"
            Case "TARJETA DE CREDITO"
                asientoBL.tipoEntidad = "TR"
        End Select

        asientoBL.fechaProceso = txtFechaTrans.Value
        asientoBL.codigoLibro = "1"
        asientoBL.tipo = "D"
        asientoBL.tipoAsiento = ASIENTO_CONTABLE.Finanzas
        asientoBL.importeMN = CDec(txtFondoMN.Value)
        asientoBL.importeME = CDec(txtFondoME.Value)
        asientoBL.glosa = Glosa()


        Select Case lblMovimiento.Text
            Case "OTRAS ENTRADAS A CAJA"
                nMovimiento = New movimiento
                nMovimiento.cuenta = txtCuentaO.Text
                'nMovimiento.descripcion = txtCajaOrigen.Text
                nMovimiento.descripcion = cboDepositoHijo.Text
                nMovimiento.tipo = "D"
                nMovimiento.monto = CDec(txtFondoMN.Value)
                nMovimiento.montoUSD = CDec(txtFondoME.Value)
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)


                nMovimiento = New movimiento
                nMovimiento.cuenta = "5011"
                nMovimiento.descripcion = "Por aporte"
                nMovimiento.tipo = "H"
                nMovimiento.monto = CDec(txtFondoMN.Value)
                nMovimiento.montoUSD = CDec(txtFondoME.Value)
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)
            Case "OTRAS SALIDAS DE CAJA"

                nMovimiento = New movimiento
                nMovimiento.cuenta = "3000"
                nMovimiento.descripcion = "Por regularizar"
                nMovimiento.tipo = "D"
                nMovimiento.monto = CDec(txtFondoMN.Value)
                nMovimiento.montoUSD = CDec(txtFondoME.Value)
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)

                nMovimiento = New movimiento
                nMovimiento.cuenta = txtCuentaO.Text
                ' nMovimiento.descripcion = txtCajaOrigen.Text
                nMovimiento.descripcion = cboDepositoHijo.Text
                nMovimiento.tipo = "H"
                nMovimiento.monto = CDec(txtFondoMN.Value)
                nMovimiento.montoUSD = CDec(txtFondoME.Value)
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)

        End Select
        ListaAsientos.Add(asientoBL)
    End Sub

    Public Function Glosa() As String
        Return "Por movimientos " & lblMovimiento.Text & " con fecha " & txtFechaTrans.Value
    End Function

    Sub Calculo()
        Dim tcambio As Decimal = 0
        Dim Imn As Decimal = 0
        tcambio = txtTipoCambio.Value
        If tcambio > 0 Then
            Imn = txtFondoMN.Value
            txtFondoME.Value = Math.Round(Imn / tcambio, 2)
        End If
    End Sub

    Sub CalculoDolares()
        Dim tcambio As Decimal = 0
        Dim Imn As Decimal = 0
        tcambio = txtTipoCambio.Value

        If tcambio > 0 Then
            Imn = txtFondoME.Value
            txtFondoMN.Value = Math.Round(Imn * tcambio, 2).ToString("N2")
        End If

    End Sub

    Public Sub UbicarDocumento(intIdDocumento As Integer)
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim alEFSA As New EstadosFinancierosSA
        Dim tablaSA As New tablaDetalleSA
        Dim establecimientoSA As New establecimientoSA
        Try
            With documentoCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento)

                Select Case .tipoMovimiento
                    Case MovimientoCaja.SalidaDinero
                        lblMovimiento.Text = "OTRAS SALIDAS DE CAJA"
                    Case MovimientoCaja.EntradaDinero
                        lblMovimiento.Text = "OTRAS ENTRADAS A CAJA"
                End Select

                lblIdDocumento.Text = .idDocumento
                txtFechaTrans.Value = .fechaProceso
                Dim codigoDoc = .tipoDocPago

                cboMoneda.SelectedValue = .moneda


                Dim A As String
                A = .codigoLibro
                cbotipoOperacion.SelectedValue = A
                Select Case .tipoOperacion
                    Case 17
                        cbotipoOperacion.Text = "APORTES"

                End Select

                Select Case .moneda
                    Case 1
                        cboMoneda.Text = "NACIONAL"
                    Case 2
                        cboMoneda.Text = "EXTRANJERO"
                End Select

                With alEFSA.GetUbicar_estadosFinancierosPorID(.entidadFinanciera)
                    'txtEstablecimientoDestino.ValueMember = .idEstablecimiento
                    'txtEstablecimientoDestino.Text = establecimientoSA.UbicaEstablecimientoPorID(.idEstablecimiento).nombre
                    'txtCajaOrigen.ValueMember = .idestado
                    'txtCajaOrigen.Text = .descripcion
                    Select Case .tipo
                        Case CuentaFinanciera.Banco
                            cboTipoCuenta.Text = "CUENTAS EN BANCO"
                        Case CuentaFinanciera.Efectivo
                            cboTipoCuenta.Text = "CUENTAS EN EFECTIVO"

                        Case CuentaFinanciera.Tarjeta_Credito
                            cboTipoCuenta.Text = "TARJETA DE CREDITO"
                    End Select

                    cboDepositoHijo.SelectedValue = .idestado
                    cargarDatosCuenta(cboDepositoHijo.SelectedValue)

                    txtCuentaO.Text = .cuenta

                End With
                cboTipoDocumento.SelectedValue = codigoDoc
                Select Case codigoDoc
                    Case "001"

                        txtNumOper.Text = .numeroOperacion
                        txtCuentaCorriente.Text = .ctaCorrienteDeposito

                        If (Not IsNothing(.bancoEntidad)) Then
                            cboEntidad.SelectedValue = .bancoEntidad
                        End If

                        txtFechaEmision.Value = .fechaProceso
                        txtFechaCobro.Value = .fechaCobro

                    Case "007" 'cheques

                        txtNumOper.Text = .numeroOperacion
                        txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        If (Not IsNothing(.bancoEntidad)) Then
                            cboEntidad.SelectedValue = .bancoEntidad
                        End If
                        txtFechaEmision.Value = .fechaProceso
                        txtFechaCobro.Value = .fechaCobro
                    Case "111"

                        txtNumOper.Text = .numeroOperacion
                        txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        If (Not IsNothing(.bancoEntidad)) Then
                            cboEntidad.SelectedValue = .bancoEntidad
                        End If
                        txtFechaEmision.Value = .fechaProceso
                        txtFechaCobro.Value = .fechaCobro

                    Case "109"

                        txtNumOper.Text = .numeroOperacion
                        txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        If (Not IsNothing(.bancoEntidad)) Then
                            cboEntidad.SelectedValue = .bancoEntidad
                        End If
                        txtFechaEmision.Value = .fechaProceso
                        txtFechaCobro.Value = .fechaCobro
                End Select

                txtTipoCambio.Value = .tipoCambio
                txtFondoMN.Value = .montoSoles
                txtFondoME.Value = .montoUsd
                txtDescripcion.Text = .glosa
            End With

            With documentoCajaDetalleSA.GetUbicar_DetallePorIdDocumento(intIdDocumento).First
                lblSecuenciaDetalle.Text = .secuencia
            End With
            ' cboMovimiento.Enabled = False
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Public Sub GrabarOtrosMovimientos()
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Dim idNumeracion As Integer
        With ndocumento
            '    .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            '       .idProyecto = GProyectos.IdProyectoActividad
            .tipoDoc = "9901"
            .fechaProceso = txtFechaTrans.Value
            idNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .nroDoc = idNumeracion
            .idOrden = Nothing
            Select Case lblMovimiento.Text
                Case "OTRAS ENTRADAS A CAJA"
                    .tipoOperacion = cbotipoOperacion.SelectedValue
                Case "OTRAS SALIDAS DE CAJA"
                    .tipoOperacion = cbotipoOperacion.SelectedValue
            End Select
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With ndocumentoCaja
            '   .idDocumento = lblIdDocumento.Text
            .periodo = PeriodoGeneral
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            '     .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
            .TipoDocumentoPago = cboTipoDocumento.SelectedValue
            .codigoProveedor = Nothing 'txtPersona.ValueMember
            .codigoLibro = "1"
            '.fechaProceso = fecha
            '.fechaCobro = fecha
            .tipoDocPago = cboTipoDocumento.SelectedValue
            .numeroDoc = idNumeracion
            .moneda = cboMoneda.SelectedValue
            Select Case lblMovimiento.Text
                Case "OTRAS ENTRADAS A CAJA"
                    .codigoLibro = cbotipoOperacion.SelectedValue
                    .tipoMovimiento = MovimientoCaja.EntradaDinero
                    .tipoOperacion = "17"
                    .movimientoCaja = (MovimientoCaja.Aportes)
                    '.entidadFinanciera = txtCajaOrigen.ValueMember
                    '.entidadFinanciera = DirectCast(Me.cboEntidadFinanciera.SelectedItem, Categoria).Id
                    .entidadFinanciera = cboDepositoHijo.SelectedValue
                Case "OTRAS SALIDAS DE CAJA"
                    .codigoLibro = cbotipoOperacion.SelectedValue
                    .tipoMovimiento = MovimientoCaja.SalidaDinero
                    .tipoOperacion = "17"
                    .entidadFinanciera = cboDepositoHijo.SelectedValue
                    .movimientoCaja = (MovimientoCaja.Otras_Saliadas)
                    ' .entidadFinanciera = txtCajaOrigen.ValueMember
                    '.entidadFinanciera = DirectCast(Me.cboEntidadFinanciera.SelectedItem, Categoria).Id
            End Select

            If cboTipoDocumento.SelectedValue = "001" Then
                .numeroOperacion = txtNumOper.Text.Trim
                .ctaCorrienteDeposito = txtCuentaCorriente.Text
                .ctaIntebancaria = Nothing
                .bancoEntidad = cboEntidad.SelectedValue
                .fechaProceso = txtFechaTrans.Value
                .fechaCobro = txtFechaTrans.Value
                .entregado = "SI"

            ElseIf cboTipoDocumento.SelectedValue = "007" Then ' cheques
                .numeroOperacion = txtNumOper.Text.Trim
                .ctaCorrienteDeposito = txtCuentaCorriente.Text
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaProceso = txtFechaEmision.Value
                .fechaCobro = txtFechaCobro.Value
                .entregado = "NO"
            ElseIf cboTipoDocumento.SelectedValue = "111" Then
                .numeroOperacion = txtNumOper.Text.Trim
                .ctaCorrienteDeposito = txtCuentaCorriente.Text
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaProceso = txtFechaEmision.Value
                .fechaCobro = txtFechaCobro.Value
                .entregado = "NO"
            ElseIf cboTipoDocumento.SelectedValue = "109" Then
                .numeroOperacion = txtNumOper.Text.Trim
                .ctaCorrienteDeposito = txtCuentaCorriente.Text
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaCobro = txtFechaTrans.Value
                .fechaProceso = txtFechaTrans.Value
                .entregado = "NO"
            End If
            .tipoCambio = txtTipoCambio.Value
            .montoSoles = txtFondoMN.Value
            .montoUsd = txtFondoME.Value

            .glosa = txtDescripcion.Text.Trim
            .estado = "N"
            .usuarioModificacion = usuario.IDUsuario
            .fechaModificacion = txtFechaTrans.Value
        End With

        ndocumento.documentoCaja = ndocumentoCaja

        Select Case cboMoneda.SelectedValue
            Case 1
                ndocumentoCajaDetalle = New documentoCajaDetalle
                ndocumentoCajaDetalle.fecha = txtFechaTrans.Value
                ndocumentoCajaDetalle.idItem = "00"
                ndocumentoCajaDetalle.DetalleItem = Glosa()
                ndocumentoCajaDetalle.montoSoles = txtFondoMN.Value
                ndocumentoCajaDetalle.montoSolesTransacc = txtFondoMN.Value
                ndocumentoCajaDetalle.montoUsd = txtFondoME.Value
                ndocumentoCajaDetalle.montoUsdTransacc = txtFondoME.Value
                ndocumentoCajaDetalle.entregado = "SI"
                ndocumentoCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                ndocumentoCajaDetalle.tipoCambioTransacc = txtTipoCambio.Value
                ndocumentoCajaDetalle.documentoAfectado = 0
                ndocumentoCajaDetalle.moneda = cboMoneda.SelectedValue
                ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
                ndocumentoCajaDetalle.fechaModificacion = txtFechaTrans.Value
                ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
            Case 2
                ndocumentoCajaDetalle = New documentoCajaDetalle
                ndocumentoCajaDetalle.fecha = txtFechaTrans.Value
                ndocumentoCajaDetalle.idItem = "00"
                ndocumentoCajaDetalle.DetalleItem = Glosa()

                If (lblMovimiento.Tag = "OAC") Then
                    ndocumentoCajaDetalle.montoUsd = txtFondoME.Value
                    ndocumentoCajaDetalle.montoUsdTransacc = txtFondoME.Value
                    ndocumentoCajaDetalle.montoSoles = txtFondoMN.Value
                    ndocumentoCajaDetalle.montoSolesTransacc = txtFondoMN.Value
                    ndocumentoCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                    ndocumentoCajaDetalle.tipoCambioTransacc = txtTipoCambio.Value
                Else
                    ndocumentoCajaDetalle.montoUsd = txtFondoME.Value
                    ndocumentoCajaDetalle.montoUsdTransacc = txtFondoME.Value
                    ndocumentoCajaDetalle.montoSoles = txtFondoMN.Value
                    ndocumentoCajaDetalle.montoSolesTransacc = txtFondoMN.Value
                    ndocumentoCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                    ndocumentoCajaDetalle.tipoCambioTransacc = txtTipoCambio.Value
                End If

                ndocumentoCajaDetalle.entregado = "SI"
                ndocumentoCajaDetalle.documentoAfectado = 0
                ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
                ndocumentoCajaDetalle.fechaModificacion = txtFechaTrans.Value
                ndocumentoCajaDetalle.moneda = cboMoneda.SelectedValue
                ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
        End Select

        AsientoContableCaja()
        ndocumento.asiento = ListaAsientos


        ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle

        Dim xCodigoDoc As Integer = documentoCajaSA.SaveGroupCajaOtrosMovimientosSingleME(ndocumento)

        lblEstado.Text = "Caja registrada correctamente!"
        lblEstado.Image = My.Resources.ok4

        Dispose()
    End Sub

    Public Sub UPDATEOtrosMovimientos()
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)

        With ndocumento
            .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            '       .idProyecto = GProyectos.IdProyectoActividad
            .tipoDoc = "9901"
            .fechaProceso = txtFechaTrans.Value
            .nroDoc = Nothing
            .idOrden = Nothing
            '.tipoOperacion = "01"
            Select Case lblMovimiento.Text
                Case "OTRAS ENTRADAS A CAJA"
                    .tipoOperacion = cbotipoOperacion.SelectedValue
                Case "OTRAS SALIDAS DE CAJA"
                    .tipoOperacion = cbotipoOperacion.SelectedValue
            End Select
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With ndocumentoCaja
            .idDocumento = lblIdDocumento.Text
            .periodo = PeriodoGeneral
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .codigoLibro = "1"
            Select Case lblMovimiento.Text
                Case "OTRAS ENTRADAS A CAJA"
                    .codigoLibro = cbotipoOperacion.SelectedValue
                    .tipoMovimiento = MovimientoCaja.EntradaDinero
                    .tipoOperacion = "17"
                    '.entidadFinanciera = txtCajaOrigen.ValueMember
                    '.entidadFinanciera = DirectCast(Me.cboEntidadFinanciera.SelectedItem, Categoria).Id
                    .entidadFinanciera = cboDepositoHijo.SelectedValue
                Case "OTRAS SALIDAS DE CAJA"
                    .codigoLibro = cbotipoOperacion.SelectedValue
                    .tipoMovimiento = MovimientoCaja.SalidaDinero
                    .tipoOperacion = "17"
                    .entidadFinanciera = cboDepositoHijo.SelectedValue
                    ' .entidadFinanciera = txtCajaOrigen.ValueMember
                    '.entidadFinanciera = DirectCast(Me.cboEntidadFinanciera.SelectedItem, Categoria).Id
            End Select


            '.tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
            .TipoDocumentoPago = cboTipoDocumento.SelectedValue
            '.codigoProveedor = Nothing 'txtPersona.ValueMember
            '.fechaProceso = fecha
            '.fechaCobro = fecha
            .tipoDocPago = cboTipoDocumento.SelectedValue
            .numeroDoc = txtNumOper.Text
            .moneda = IIf(cboMoneda.Text = "MONEDA NACIONAL", "1", "2")
            'Select Case lblMovimiento.Text
            '    Case "OTRAS ENTRADAS A CAJA"
            '        .tipoMovimiento = "DC"
            '        .movimiento = "OEC"
            '        '.entidadFinanciera = txtCajaOrigen.ValueMember
            '        '.entidadFinanciera = DirectCast(Me.cboEntidadFinanciera.SelectedItem, Categoria).Id
            '        'cboEntidadFinanciera = cboDepositoHijo.SelectedValue
            '    Case "OTRAS SALIDAS DE CAJA"
            '        .tipoMovimiento = "PG"
            '        .movimiento = "OSC"
            '        ' .entidadFinanciera = txtCajaOrigen.ValueMember
            '        'cboEntidadFinanciera = cboDepositoHijo.SelectedValue
            '        '.entidadFinanciera = DirectCast(Me.cboEntidadFinanciera.SelectedItem, Categoria).Id
            'End Select
            If cboTipoDocumento.SelectedValue = "001" Then
                .numeroDoc = Nothing
                .numeroOperacion = txtNumOper.Text.Trim
                .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                .ctaIntebancaria = Nothing
                .bancoEntidad = cboEntidad.SelectedValue
                .fechaProceso = txtFechaEmision.Value
                .fechaCobro = Date.Now
                .entregado = "SI"

            ElseIf cboTipoDocumento.SelectedValue = "007" Then ' cheques
                .numeroDoc = txtNumOper.Text.Trim
                .numeroOperacion = Nothing
                .ctaCorrienteDeposito = Nothing
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaProceso = txtFechaEmision.Value
                .fechaCobro = txtFechaCobro.Value
                .entregado = "NO"
            ElseIf cboTipoDocumento.SelectedValue = "111" Then
                .numeroDoc = txtNumOper.Text.Trim
                .numeroOperacion = Nothing
                .ctaCorrienteDeposito = Nothing
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaProceso = txtFechaEmision.Value
                .fechaCobro = txtFechaCobro.Value
                .entregado = "NO"
            ElseIf cboTipoDocumento.SelectedValue = "109" Then
                .numeroDoc = txtNumOper.Text.Trim
                .numeroOperacion = Nothing
                .ctaCorrienteDeposito = Nothing
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaCobro = Date.Now
                .fechaProceso = Date.Now
                .entregado = "NO"
            End If
            .tipoCambio = txtTipoCambio.Value
            .montoSoles = txtFondoMN.Value
            .montoUsd = txtFondoME.Value

            .glosa = txtDescripcion.Text
            '.entregado = "SI"
            .usuarioModificacion = usuario.IDUsuario
            .fechaModificacion = DateTime.Now
            .estado = "N"
        End With

        ndocumento.documentoCaja = ndocumentoCaja

        ndocumentoCajaDetalle = New documentoCajaDetalle
        ndocumentoCajaDetalle.idDocumento = lblIdDocumento.Text
        ndocumentoCajaDetalle.secuencia = lblSecuenciaDetalle.Text
        ndocumentoCajaDetalle.fecha = txtFechaTrans.Value
        ndocumentoCajaDetalle.idItem = "00"
        ndocumentoCajaDetalle.DetalleItem = Glosa()
        ndocumentoCajaDetalle.montoSoles = txtFondoMN.Value

        ndocumentoCajaDetalle.montoUsd = txtFondoME.Value
        ndocumentoCajaDetalle.entregado = "SI"
        ndocumentoCajaDetalle.diferTipoCambio = txtTipoCambio.Value


        ndocumentoCajaDetalle.documentoAfectado = 0
        ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
        ndocumentoCajaDetalle.fechaModificacion = Date.Now
        ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)

        'AsientoContableCaja()
        ndocumento.asiento = ListaAsientos
        ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle

        documentoCajaSA.UpdateGroupCajaOtrosMovimientosSingle(ndocumento)
        lblEstado.Text = "Caja actualizada correctamente!"
        lblEstado.Image = My.Resources.ok4

        Dispose()
    End Sub
#End Region


    Public Class Categoria

        Private _name As String
        Private _id As Integer
        Private _cuenta As String

        Public Sub New(ByVal name As String, ByVal id As Integer, ByVal cuenta As String)
            _name = name
            _id = id
            _cuenta = cuenta
        End Sub
        Sub New()
            ' TODO: Complete member initialization 
        End Sub

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property

        Public Property Cuenta() As String
            Get
                Return _cuenta
            End Get
            Set(ByVal value As String)
                _cuenta = value
            End Set
        End Property

    End Class

    Private Sub frmEntradaSalidaCaja_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Dim comboTableh As New DataTable

    Private Sub frmEntradaSalidaCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetTableAlmacen2()
    End Sub

    Private Sub PegarToolStripButton_Click(sender As Object, e As EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As Object, e As EventArgs)
        Select Case cboMoneda.SelectedValue
            Case 1
                Calculo()
            Case 2
                CalculoDolares()
        End Select
    End Sub


    Private Sub btGrabar_Click(sender As Object, e As EventArgs)

        If Not cboDepositoHijo.Text.Length > 0 Then
            lblEstado.Text = "Ingrese la entidad financiera."
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            cboDepositoHijo.Select()
            Exit Sub
        End If

        If Not cbotipoOperacion.Text.Length > 0 Then
            lblEstado.Text = "Ingrese tipo de operación."
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            cbotipoOperacion.Select()
            Exit Sub
        End If

        If Not txtDescripcion.Text.Length > 0 Then
            lblEstado.Text = "Ingrese el detalle del motivo."
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            txtDescripcion.Select()
            Exit Sub
        End If

        Select Case cboMoneda.SelectedValue
            Case 1
                If Not txtTipoCambio.Value > 0 Then
                    lblEstado.Text = "Debe ingresar un tipo de cambio mayor a cero!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                    Exit Sub
                End If

                If Not txtFondoMN.Value > 0 Then
                    lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    txtFondoMN.Select(0, txtFondoMN.Text.Length)
                    Exit Sub
                End If

            Case 2

                Select Case lblMovimiento.Text
                    Case "OTRAS ENTRADAS A CAJA"
                        If Not txtFondoME.Value > 0 Then
                            lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            txtFondoME.Select(0, txtFondoME.Text.Length)
                            Exit Sub
                        End If

                        If Not txtTipoCambio.Value > 0 Then
                            lblEstado.Text = "Debe ingresar un tipo de cambio mayor a cero!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                            Exit Sub
                        End If
                    Case "OTRAS SALIDAS DE CAJA"
                        If Not txtFondoME.Value > 0 Then
                            lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            txtFondoME.Select(0, txtFondoME.Text.Length)
                            Exit Sub
                        End If
                End Select

        End Select

        If cboTipoDocumento.SelectedValue = "001" Then
            If Not cboTipoDocumento.Text.Length > 0 Then
                lblEstado.Text = "Ingrese tipo documento."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                cboTipoDocumento.Select()
                Exit Sub
            End If

            If Not txtNumOper.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el número de operación."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                txtNumOper.Select()
                Exit Sub
            End If


            Select Case lblMovimiento.Text
                Case "OTRAS ENTRADAS A CAJA"

                Case "OTRAS SALIDAS DE CAJA"
                    If Not txtCuentaCorriente.Text.Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese el número de cuenta."
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        txtCuentaCorriente.Select()
                        Exit Sub
                    End If
            End Select

        ElseIf cboTipoDocumento.SelectedValue = "007" Then

        ElseIf cboTipoDocumento.SelectedValue = "109" Then
            If Not cboTipoDocumento.Text.Length > 0 Then
                lblEstado.Text = "Ingrese tipo documento."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                cboTipoDocumento.Select()
                Exit Sub
            End If

            If Not txtNumOper.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el número de operación."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                txtNumOper.Select()
                Exit Sub
            End If

        ElseIf cboTipoDocumento.SelectedValue = "111" Then

        End If


        Dim debetotal As Decimal
        Dim habertotal As Decimal
        Dim ListaMovimiento As New List(Of movimiento)

        debetotal = CDec(0.0)
        habertotal = CDec(0.0)

        'If lstAsiento.SelectedItems.Count > 0 Then
        '    Dim consulta = (From n In ListaMovimientos).ToList
        '    If consulta.Count > 0 Then
        '        ListaMovimiento = consulta
        '        For i As Integer = 0 To ListaMovimiento.Count - 1

        '            If ListaMovimiento(i).monto > 0 Then

        '                For j As Integer = 0 To 6
        '                    Select Case ListaMovimiento(i).tipo

        '                        Case "D"
        '                            Select Case j

        '                                Case 3
        '                                    debetotal += ListaMovimiento(i).monto
        '                            End Select

        '                        Case "H"
        '                            Select Case j

        '                                Case 3
        '                                    habertotal += ListaMovimiento(i).monto
        '                            End Select
        '                    End Select
        '                Next
        '            Else
        '                lblEstado.Text = "Las montos del asiento deben ser mayor a 0"
        '                PanelError.Visible = True
        '                Timer1.Enabled = True
        '                TiempoEjecutar(10)
        '                Exit Sub

        '            End If

        '        Next
        '    End If
        'End If

        'If debetotal > 0 Then
        '    If habertotal > 0 Then
        '        If debetotal = habertotal Then

        ''''''''''''''''''''''''''''''''''''''''

        Select Case ManipulacionEstado
            Case ENTITY_ACTIONS.INSERT
                GrabarOtrosMovimientos()
            Case ENTITY_ACTIONS.UPDATE
                UPDATEOtrosMovimientos()
        End Select

        ''''''''''''''''''''''''''''''''''

        '        Else

        'lblEstado.Text = "Las Asientos deben cuadrar"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)

        '        End If
        '    Else
        'lblEstado.Text = "Ingrese un Monto Haber"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)
        '    End If
        'Else
        'lblEstado.Text = "Ingrese un monto Debe"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)
        'End If



    End Sub

    Private Sub cboTipo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedValueChanged
        If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo("EF")
        ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo("BC")
        End If
    End Sub

    Private Sub cboDepositoHijo_Click(sender As Object, e As EventArgs) Handles cboDepositoHijo.Click
        cboDepositoHijo.Tag = 1
    End Sub

    Private Sub cboTipoDocumento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDocumento.SelectedIndexChanged
        If cboTipoDocumento.ValueMember.Trim.Length > 0 Then
            txtNumOper.Clear()
            txtCuentaCorriente.Clear()
            If cboTipoDocumento.SelectedValue = "109" Then 'EFECTIVO (que se genere un vocher de caja con los datos del comprobante que se está pagando) 

                pnEntidad.Visible = False
                pnFecha.Visible = False
                Label17.Text = "NRO. VOUCHER:"


            ElseIf cboTipoDocumento.SelectedValue = "007" Then ' CHEQUES

                pnEntidad.Visible = False
                pnFecha.Visible = True
                Label17.Text = "NRO. CHEQUE:"
                pnFecha.Location = New Point(25, 43)

            ElseIf cboTipoDocumento.SelectedValue = "001" Then ' DEPOSITO EN CUENTA 
                Select Case lblMovimiento.Text
                    Case "OTRAS ENTRADAS A CAJA"
                        pnEntidad.Visible = False
                        pnFecha.Visible = False
                        Label17.Text = "NRO. OPERACIÓN:"
                    Case "OTRAS SALIDAS DE CAJA"
                        pnEntidad.Visible = True
                        pnFecha.Visible = False
                        Label17.Text = "NRO. OPERACIÓN:"
                End Select


            ElseIf cboTipoDocumento.SelectedValue = "111" Then ' CHEQUE NO NEGOCIABLE 
                pnEntidad.Visible = False
                pnFecha.Visible = True
                Label17.Text = "NRO. CHEQUE:"
                pnFecha.Location = New Point(25, 43)

            End If
        End If
    End Sub

    Private Sub cboTipoCuenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoCuenta.SelectedIndexChanged
        cboMoneda.SelectedValue = -1
        txtTipoCambio.Value = 0.0
        txtCuentaCorriente.Clear()
        cboTipoDocumento.SelectedValue = -1
        txtDescripcion.Clear()
        txtNumOper.Clear()
        lblDeudaPendientemn.Value = 0
        lblDeudaPendienteme.Value = 0
        Select Case lblMovimiento.Text
            Case "OTRAS ENTRADAS A CAJA"
                pnEntidad.Visible = False
                pnFecha.Visible = False
                cboDepositoHijo.Enabled = False
            Case "OTRAS SALIDAS DE CAJA"
                pnEntidad.Visible = True
                pnFecha.Visible = False
                cboDepositoHijo.Enabled = False
        End Select
        cargarCtasFinan()
    End Sub

    Private Sub cboDepositoHijo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepositoHijo.SelectedIndexChanged
        Dim value As Object = Me.cboDepositoHijo.SelectedValue
        txtTipoCambio.Value = 0.0
        txtCuentaCorriente.Clear()
        txtDescripcion.Clear()
        txtNumOper.Clear()
        txtFondoME.Value = 0.0
        txtFondoMN.Value = 0.0
        lblDeudaPendientemn.Value = 0
        lblDeudaPendienteme.Value = 0

        If (cboDepositoHijo.Tag = 1) Then
            If IsNumeric(value) Then
                cargarDatosCuenta(CInt(value))
            Else
            End If
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtNumOper.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            'txtImporteCompramn.Clear()
        End Try
    End Sub

    Private Sub txtFondoMN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFondoMN.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                Select Case lblMovimiento.Text
                    Case "OTRAS ENTRADAS A CAJA"
                        txtTipoCambio.Select()
                        txtTipoCambio.Select(0, txtTipoCambio.Text.Length)

                    Case "OTRAS SALIDAS DE CAJA"
                        If (txtFondoMN.Value <= lblDeudaPendientemn.Value And txtFondoMN.Value <> 0) Then
                            txtTipoCambio.Select()
                            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                        Else
                            lblEstado.Text = "Debe ingresar un importe menor o igual!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            txtFondoMN.Value = 0.0
                            txtFondoMN.Select(0, txtFondoMN.Text.Length)
                        End If

                End Select

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub


    Private Sub txtFondoMN_ValueChanged(sender As Object, e As EventArgs) Handles txtFondoMN.ValueChanged

        Select Case cboMoneda.SelectedValue
            Case 1
                Calculo()
                Select Case lblMovimiento.Text
                    Case "OTRAS ENTRADAS A CAJA"
                        cargarDatos()
                    Case "OTRAS SALIDAS DE CAJA"
                        If (txtFondoMN.Value <= lblDeudaPendientemn.Value) Then
                            txtFondoMN.Select(0, txtFondoMN.Text.Length)
                            cargarDatos()
                        Else
                            lblEstado.Text = "Debe ingresar un importe menor o igual!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            txtFondoMN.Value = 0.0
                            txtFondoMN.Select(0, txtFondoMN.Text.Length)
                        End If

                End Select

        End Select
    End Sub

    Private Sub txtTipoCambio_ValueChanged_1(sender As Object, e As EventArgs) Handles txtTipoCambio.ValueChanged
        Select Case cboMoneda.SelectedValue
            Case 1
                Calculo()
                cargarDatos()
            Case 2
                Select Case lblMovimiento.Text
                    Case "OTRAS ENTRADAS A CAJA"
                        CalculoDolares()
                        cargarDatos()
                    Case "OTRAS SALIDAS DE CAJA"
                        CalculoDolares()
                        cargarDatos()
                        If (txtFondoME.Value > 0 And txtTipoCambio.Value > 0) Then
                            CargarDiferenciasdeImporte()
                        End If
                End Select

        End Select
    End Sub

    Private Sub txtFondoME_ValueChanged(sender As Object, e As EventArgs) Handles txtFondoME.ValueChanged
        Dim documentocajaSA As New DocumentoCajaSA
        Dim documentocajaDetalleSA As New DocumentoCajaDetalleSA
        Select Case cboMoneda.SelectedValue
            Case 1
                Calculo()
            Case 2
                Select Case lblMovimiento.Text
                    Case "OTRAS ENTRADAS A CAJA"
                        CalculoDolares()
                        cargarDatos()
                    Case "OTRAS SALIDAS DE CAJA"
                        CalculoDolares()
                        cargarDatos()

                        If (txtFondoME.Value > 0) Then
                            CargarTiposDeCambio()
                        End If

                        If (txtFondoME.Value > 0 And txtTipoCambio.Value > 0) Then
                            CargarDiferenciasdeImporte()
                        End If
                End Select
        End Select
    End Sub

    Private Sub dockingManager1_DockControlActivated(sender As Object, arg As Tools.DockActivationChangedEventArgs) Handles dockingManager1.DockControlActivated

    End Sub

    Private Sub txtFondoME_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFondoME.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                Select Case lblMovimiento.Text
                    Case "OTRAS ENTRADAS A CAJA"
                        txtTipoCambio.Select()
                        txtTipoCambio.Select(0, txtTipoCambio.Text.Length)

                    Case "OTRAS SALIDAS DE CAJA"
                        If (txtFondoME.Value <= lblDeudaPendienteme.Value And txtFondoME.Value <> 0) Then
                            txtTipoCambio.Select()
                            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                        Else
                            lblEstado.Text = "Debe ingresar un importe menor o igual!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            txtFondoME.Value = 0.0
                            txtFondoME.Select(0, txtFondoME.Text.Length)
                        End If

                End Select

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Private Sub cargarDatos()
        Dim n As New movimiento
        Select Case cboMoneda.SelectedValue
            Case 1
                If (txtFondoMN.Value > 0 And txtFondoME.Value > 0) Then
                    ListaMovimientos.Clear()
                    n.cuenta = txtCuentaO.Text
                    'n.idAsiento = lstAsiento.SelectedValue
                    n.idmovimiento = GetMaxIDMovimiento() + 1
                    n.tipo = "D"
                    n.Cant = 1
                    n.PUmn = CDec(txtFondoMN.Value / n.Cant)
                    n.PUme = CDec(txtFondoME.Value / n.Cant)
                    n.monto = txtFondoMN.Value
                    n.montoUSD = txtFondoME.Value
                    ListaMovimientos.Add(n)
                    'cargarAsientosDefault()

                End If
            Case 2
                Select Case lblMovimiento.Text
                    Case "OTRAS ENTRADAS A CAJA"
                        If (txtFondoMN.Value > 0 And txtFondoME.Value > 0) Then
                            ListaMovimientos.Clear()
                            n.cuenta = txtCuentaO.Text
                            'n.idAsiento = lstAsiento.SelectedValue
                            n.idmovimiento = GetMaxIDMovimiento() + 1
                            n.tipo = "D"
                            n.Cant = 1
                            n.PUmn = CDec(txtFondoMN.Value / n.Cant)
                            n.PUme = CDec(txtFondoME.Value / n.Cant)
                            n.monto = txtFondoMN.Value
                            n.montoUSD = txtFondoME.Value
                            ListaMovimientos.Add(n)
                            'cargarAsientosDefault()

                        End If
                    Case "OTRAS SALIDAS DE CAJA"
                        If (txtFondoME.Value > 0) Then
                            ListaMovimientos.Clear()
                            n.cuenta = txtCuentaO.Text
                            'n.idAsiento = lstAsiento.SelectedValue
                            n.idmovimiento = GetMaxIDMovimiento() + 1
                            n.tipo = "H"
                            n.Cant = 1
                            'n.PUmn = CDec(txtSaldoMN.Value / n.Cant)
                            n.PUme = CDec(txtFondoME.Value / n.Cant)
                            'n.monto = txtSaldoMN.Value
                            n.montoUSD = txtFondoME.Value
                            ListaMovimientos.Add(n)
                            'dgvCompra.Table.Records.DeleteAll()
                            'cargarAsientosDefault()
                        End If
                End Select

        End Select
    End Sub

    Private Sub txtNumOper_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumOper.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                Select Case lblMovimiento.Text
                    Case "OTRAS ENTRADAS A CAJA"
                        Select Case cboMoneda.SelectedValue
                            Case 1
                                txtFondoMN.Select()
                                txtFondoMN.Select(0, txtFondoMN.Text.Length)
                            Case 2
                                txtFondoME.Select()
                                txtFondoME.Select(0, txtFondoME.Text.Length)
                        End Select

                    Case "OTRAS SALIDAS DE CAJA"
                        txtCuentaCorriente.Select()
                End Select

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Private Sub txtCuentaCorriente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCuentaCorriente.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                Select Case lblMovimiento.Text
                    Case "OTRAS SALIDAS DE CAJA"
                        Select Case cboMoneda.SelectedValue
                            Case 1
                                txtFondoMN.Select()
                                txtFondoMN.Select(0, txtFondoMN.Text.Length)
                            Case 2
                                txtFondoME.Select()
                                txtFondoME.Select(0, txtFondoME.Text.Length)
                        End Select
                End Select

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs)


    End Sub

   

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Select Case cboMoneda.SelectedValue
            Case 1
                'If Not Me.PopupControlContainer3.IsShowing() Then
                '    ' Let the popup align around the source textBox.
                '    Me.PopupControlContainer1.ParentControl = Me.txtTipoCambio
                '    ' Passing Point.Empty will align it automatically around the above ParentControl.
                '    Me.PopupControlContainer1.ShowPopup(Point.Empty)
                'End If
                'If nudDeudaPendienteme.Text.Trim.Length > 0 Then
                '    Me.PopupControlContainer3.ParentControl = Me.txtImporteCompramn
                '    Me.PopupControlContainer3.ShowPopup(Point.Empty)
                '    CargarDiferenciasdeImporte()
                'End If
            Case 2
                If txtFondoME.Text.Trim.Length > 0 Then
                    If Not Me.PopupControlContainer3.IsShowing() Then
                        ' Let the popup align around the source textBox.
                        Me.PopupControlContainer3.ParentControl = Me.txtFondoME
                        ' Passing Point.Empty will align it automatically around the above ParentControl.
                        Me.PopupControlContainer3.ShowPopup(Point.Empty)
                    End If
                    Me.PopupControlContainer3.ParentControl = Me.txtFondoME
                    Me.PopupControlContainer3.ShowPopup(Point.Empty)
                    CargarDiferenciasdeImporte()
                End If
        End Select
    End Sub

    Private Sub txtNumOper_TextChanged(sender As Object, e As EventArgs) Handles txtNumOper.TextChanged

    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub pnDetalleEntrada_Paint(sender As Object, e As PaintEventArgs) Handles pnDetalleEntrada.Paint

    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        If Not cboDepositoHijo.Text.Length > 0 Then
            lblEstado.Text = "Ingrese la entidad financiera."
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            cboDepositoHijo.Select()
            Exit Sub
        End If

        If Not cbotipoOperacion.Text.Length > 0 Then
            lblEstado.Text = "Ingrese tipo de operación."
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            cbotipoOperacion.Select()
            Exit Sub
        End If
        Select Case cboMoneda.SelectedValue
            Case 1
                If Not txtTipoCambio.Value > 0 Then
                    lblEstado.Text = "Debe ingresar un tipo de cambio mayor a cero!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                    Exit Sub
                End If

                If Not txtFondoMN.Value > 0 Then
                    lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    txtFondoMN.Select(0, txtFondoMN.Text.Length)
                    Exit Sub
                End If

            Case 2

                Select Case lblMovimiento.Text
                    Case "OTRAS ENTRADAS A CAJA"
                        If Not txtFondoME.Value > 0 Then
                            lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            txtFondoME.Select(0, txtFondoME.Text.Length)
                            Exit Sub
                        End If

                        If Not txtTipoCambio.Value > 0 Then
                            lblEstado.Text = "Debe ingresar un tipo de cambio mayor a cero!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                            Exit Sub
                        End If
                    Case "OTRAS SALIDAS DE CAJA"
                        If Not txtFondoME.Value > 0 Then
                            lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            txtFondoME.Select(0, txtFondoME.Text.Length)
                            Exit Sub
                        End If

                        If Not cboEntidad.Text <> "" Then
                            lblEstado.Text = "Ingrese una entidad financiera."
                            Timer1.Enabled = True
                            PanelError.Visible = True
                            TiempoEjecutar(10)
                            txtCuentaCorriente.Select()
                            Exit Sub
                        End If

                        If Not txtTipoCambio.Value > 0 Then
                            lblEstado.Text = "Debe ingresar un tipo de cambio mayor a cero!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                            Exit Sub
                        End If

                End Select

        End Select

        If cboTipoDocumento.SelectedValue = "001" Then
            If Not cboTipoDocumento.Text.Length > 0 Then
                lblEstado.Text = "Ingrese tipo documento."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                cboTipoDocumento.Select()
                Exit Sub
            End If

            If Not txtNumOper.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el número de operación."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                txtNumOper.Select()
                Exit Sub
            End If


            Select Case lblMovimiento.Text
                Case "OTRAS ENTRADAS A CAJA"

                Case "OTRAS SALIDAS DE CAJA"
                    If Not txtCuentaCorriente.Text.Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese el número de cuenta."
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        txtCuentaCorriente.Select()
                        Exit Sub
                    End If

                    If Not cboEntidad.Text <> "" Then
                        lblEstado.Text = "Ingrese una entidad financiera."
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        txtCuentaCorriente.Select()
                        Exit Sub
                    End If
            End Select

        ElseIf cboTipoDocumento.SelectedValue = "007" Then

        ElseIf cboTipoDocumento.SelectedValue = "109" Then
            If Not cboTipoDocumento.Text.Length > 0 Then
                lblEstado.Text = "Ingrese tipo documento."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                cboTipoDocumento.Select()
                Exit Sub
            End If

            If Not txtNumOper.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el número de operación."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                txtNumOper.Select()
                Exit Sub
            End If

        ElseIf cboTipoDocumento.SelectedValue = "111" Then

        End If


        ''''''''''''''''''''''''''''''''''''''''

        Select Case ManipulacionEstado
            Case ENTITY_ACTIONS.INSERT
                GrabarOtrosMovimientos()
            Case ENTITY_ACTIONS.UPDATE
                UPDATEOtrosMovimientos()
        End Select

        ''''''''''''''''''''''''''''''''''

        '        Else

        'lblEstado.Text = "Las Asientos deben cuadrar"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)

        '        End If
        '    Else
        'lblEstado.Text = "Ingrese un Monto Haber"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)
        '    End If
        'Else
        'lblEstado.Text = "Ingrese un monto Debe"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)
        'End If
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Dispose()
    End Sub
End Class