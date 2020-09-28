Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports System.ComponentModel
Imports Syncfusion.GridHelperClasses
Public Class frmPedidoPendiente
    Inherits frmMaster

    Dim conf As New GConfiguracionModulo
    Dim colorx As New GridMetroColors()
    Dim lblCenter As New Label
    Dim lblPedidosCount As New Label
    Dim lblAnulado As New Label
    Dim filter As GridDynamicFilter = New GridDynamicFilter()
    Protected Friend frmDetalleVentaView As frmDetalleVentaView
    Protected Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Public Property ListaAsientos As List(Of asiento)
    Public ListaEstadosFinancieros As List(Of estadosFinancieros)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        GridCFGVenta(dgvCompra)
        Me.WindowState = FormWindowState.Normal

        btOperacion.Enabled = False
        dgvCompra.Enabled = False

        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf GetListaVentasPorPeriodo))
        thread.Start()
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

    'Private Sub GetNumeracion(strIdModulo As String, strIDEmpresa As String, intIdEstablecimiento As Integer)
    '    Dim cajaUsuarioSA As New cajaUsuarioSA
    '    Dim cajaSA As New EstadosFinancierosSA
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    conf = New GConfiguracionModulo
    '    conf = ConfigurarComprobanteVenta(moduloConfiguracion)

    '    ListaEstadosFinancieros = New List(Of estadosFinancieros)
    '    'ListaEstadosFinancieros = cajaSA.GetCuentasFinancierasByEmpresa(Gempresas.IdEmpresaRuc, "EF")

    '    For Each i As cajaUsuario In cajaUsuarioSA.ResumenTransaccionesXusuarioCajaPago(
    '        New cajaUsuario With
    '        {
    '        .idcajaUsuario = GFichaUsuarios.IdCajaUsuario,
    '        .idPersona = usuario.IDUsuario
    '        })

    '        ListaEstadosFinancieros.Add(
    '            New estadosFinancieros With
    '            {
    '            .idestado = i.idEntidad,
    '            .descripcion = i.NombreEntidad,
    '            .tipo = i.Tipo,
    '            .codigo = i.moneda
    '            })
    '    Next
    '    'SetDataSourceNumeracion(moduloConfiguracion)
    'End Sub

    Public Sub configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
        Try
            Dim cajaUsuarioSA As New cajaUsuarioSA
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

                ListaEstadosFinancieros = New List(Of estadosFinancieros)

                For Each i As cajaUsuario In cajaUsuarioSA.ResumenTransaccionesXusuarioCajaPago(
                    New cajaUsuario With
                    {
                    .idcajaUsuario = GFichaUsuarios.IdCajaUsuario,
                    .idPersona = usuario.IDUsuario
                    })

                    ListaEstadosFinancieros.Add(
                        New estadosFinancieros With
                        {
                        .idestado = i.idEntidad,
                        .descripcion = i.NombreEntidad,
                        .tipo = i.Tipo,
                        .codigo = i.moneda
                        })
                Next

            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub setDataSource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {table})
        Else
            dgvCompra.DataSource = table
            ProgressBar1.Visible = False
        End If
    End Sub

    Sub filters()
        Me.dgvCompra.TopLevelGroupOptions.ShowFilterBar = True
        'Enable the filter for each columns 
        '   For i As Integer = 0 To dgvCompra.TableDescriptor.Columns.Count - 1
        dgvCompra.TableDescriptor.Columns("pedido").AllowFilter = True
        dgvCompra.TableDescriptor.Columns("NroDocEntidad").AllowFilter = True '
        dgvCompra.TableDescriptor.Columns("importeTotal").AllowFilter = True
        '   Next
        filter.WireGrid(dgvCompra)
    End Sub

    Public Sub EliminarPV(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim objDocumento As New documento
        Try
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = intIdDocumento
            End With

            documentoSA.EliminarVentaGeneralPV(objDocumento)
            dgvCompra.Table.CurrentRecord.Delete()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetListaVentasPorPeriodo()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoPreparado", GetType(String)))
        dt.Columns.Add(New DataColumn("idcliente", GetType(Integer)))


        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasPeriodoPendiente(GEstableciento.IdEstablecimiento, PeriodoGeneral).OrderBy(Function(o) o.fechaDoc).ToList
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str
            dr(4) = i.tipoDocumento
            dr(5) = i.serie
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    'If i.tipoVenta = TIPO_VENTA.VENTA_AL_TICKET Then
                    '    dr(1) = "Venta Ticket"
                    'ElseIf i.tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA Then
                    '    dr(1) = "Venta Ticket directa"
                    'End If
                    dr(3) = i.nombrePedido
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.COTIZACION
                    '    dr(1) = "Cotización"
                    dr(3) = i.nombrePedido
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL

                    '    dr(1) = "Venta General"
                    dr(3) = "-"
                    dr(6) = i.numeroDoc

                Case "NTC"
                    '   dr(1) = "Nota de crédito"
                    dr(3) = "-"
                    dr(6) = i.numeroDoc
                Case "VNP"

                    dr(3) = i.nombrePedido
                    dr(6) = i.numeroDoc
            End Select

            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"
                Case Else
                    Select Case i.estadoCobro
                        Case "DC"
                            dr(14) = "Cobrado"
                        Case "ANU"
                            dr(14) = "Anulado"
                        Case TIPO_VENTA.AnuladaPorNotaCredito
                            dr(14) = "Anulado x NC."
                        Case Else
                            dr(14) = "Pendiente"
                    End Select
            End Select


            Select Case i.notaCredito
                Case StatusVentaMatizados.PorPreparar
                    dr(15) = "Pendiente"
                Case StatusVentaMatizados.TerminadaYentregada
                    dr(15) = "Entregada"
            End Select
            dr(16) = i.idCliente
            dt.Rows.Add(dr)
        Next
        setDataSource(dt)

    End Sub
#End Region
    
    Sub GridCFGVenta(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Close()
    End Sub
    Dim objPleaseWait As New FeedbackForm()
    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        btOperacion.Enabled = False
        Cursor = Cursors.WaitCursor
        Dim ef As New EstadosFinancierosSA
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim usuarioSA As New UsuarioSA
        Dim usuarioxls As New Usuario
        Try
            If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
                'If MessageBox.Show("Realizar el cobro ticket!", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If cboTipoDoc.Text.Trim.Length > 0 Then
                    cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                    If Not IsNothing(cajaUsuario) Then
                        usuarioxls = usuarioSA.UbicarUsuarioXid(New Usuario With {.IDUsuario = usuario.IDUsuario})
                        GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)
                        GetPagarVenta(dgvCompra.Table.CurrentRecord)
                        ButtonAdv15_Click(sender, e)
                        objPleaseWait.Close()
                        ChPagoDirecto.Checked = True
                        ChPagoAvanzado.Checked = False
                        PagoDirectoCheck()
                        btOperacion.Enabled = True
                    Else
                        MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        btOperacion.Enabled = True
                    End If
                Else
                    MessageBoxAdv.Show("Debe seleccionar el comprobante!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    btOperacion.Enabled = True
                End If
            Else
                MessageBox.Show("Debe seleccionar un pedido para cobrar!", "Seleccionar Fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btOperacion.Enabled = True
            End If
        Catch ex As Exception
            objPleaseWait.Close()
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btOperacion.Enabled = True
        End Try
        Cursor = Cursors.Default
    End Sub

    'Public Function ConfigurarComprobanteVenta(moduloConfiguracion As moduloConfiguracion) As GConfiguracionModulo
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion2 = New GConfiguracionModulo
    '            GConfiguracion2.IdModulo = .idModulo
    '            GConfiguracion2.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion2.ConfigComprobante = .IdEnumeracion

    '                        If cboTipoDoc.Text = "BOLETA" Then
    '                            GConfiguracion2.TipoComprobante = "12.1" ' .tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial

    '                        End If
    '                        If cboTipoDoc.Text = "FACTURA" Then
    '                            GConfiguracion2.TipoComprobante = "12.2" '.tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial

    '                        End If

    '                    End With
    '                Case "M"

    '            End Select

    '        End With
    '    Else
    '        MsgBox("Este módulo no contiene una configuración disponible, intentelo más tarde.!")
    '    End If
    '    Return GConfiguracion2
    'End Function



    Public Function ListaPagosCajas(lista As List(Of documentoCaja), be As documentoventaAbarrotes) As List(Of documento)
        Dim entidadSA As New entidadSA
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)
        Dim r As Record = dgvCompra.Table.CurrentRecord
        For Each i In lista

            nDocumentoCaja = New documento
            nDocumentoCaja.idDocumento = CInt(Me.Tag)
            nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
            nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
            nDocumentoCaja.tipoDoc = be.tipoDocumento ' conf.TipoComprobante ' cbotipoDocPago.SelectedValue
            nDocumentoCaja.fechaProceso = venta.fechaDoc
            nDocumentoCaja.nroDoc = be.serieVenta ' conf.Serie
            nDocumentoCaja.idOrden = Nothing
            nDocumentoCaja.moneda = 1

            Dim cliente = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, venta.idCliente)
            If cliente IsNot Nothing Then
                nDocumentoCaja.idEntidad = cliente.idEntidad
                nDocumentoCaja.entidad = cliente.nombreCompleto
                nDocumentoCaja.nrodocEntidad = cliente.nrodoc
            Else
                nDocumentoCaja.idEntidad = "0"
                nDocumentoCaja.entidad = "Clientes varios"
                nDocumentoCaja.nrodocEntidad = "-"
            End If
            nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
            nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
            nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
            nDocumentoCaja.fechaActualizacion = DateTime.Now

            '  documento CAJA
            objCaja = New documentoCaja
            objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
            objCaja.idDocumento = 0
            objCaja.periodo = venta.fechaPeriodo
            objCaja.idEmpresa = Gempresas.IdEmpresaRuc
            objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
            objCaja.fechaProceso = venta.fechaDoc
            objCaja.fechaCobro = DateTime.Now
            objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO

            If cliente IsNot Nothing Then
                objCaja.codigoProveedor = cliente.idEntidad
                objCaja.IdProveedor = cliente.idEntidad
                objCaja.idPersonal = Integer.Parse(cliente.idEntidad)
            End If

            objCaja.TipoDocumentoPago = be.tipoDocumento ' conf.TipoComprobante 'cbotipoDocPago.SelectedValue
            objCaja.codigoLibro = "1"
            objCaja.tipoDocPago = be.tipoDocumento
            objCaja.formapago = i.formapago
            objCaja.NumeroDocumento = "-"
            objCaja.numeroOperacion = "-"
            '  objCaja.movimientoCaja = TIPO_VENTA.VENTA_POS_DIRECTA
            Select Case be.tipoDocumento
                Case "9907"
                    objCaja.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA
                Case Else
                    objCaja.movimientoCaja = TIPO_VENTA.VENTA_AL_TICKET
            End Select
            objCaja.montoSoles = Decimal.Parse(i.montoSoles)

            objCaja.moneda = venta.moneda
            objCaja.tipoCambio = TmpTipoCambio
            objCaja.montoUsd = Decimal.Parse(objCaja.montoSoles / TmpTipoCambio)

            objCaja.estado = "1"
            objCaja.glosa = "Por ventas con ticket"
            objCaja.entregado = "SI"

            objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
            objCaja.entidadFinanciera = i.IdEntidadFinanciera
            objCaja.NombreEntidad = i.NomCajaOrigen
            objCaja.usuarioModificacion = usuario.IDUsuario
            objCaja.fechaModificacion = DateTime.Now
            nDocumentoCaja.documentoCaja = objCaja
            nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja)
            asientoDocumento(nDocumentoCaja.documentoCaja)
            ListaDoc.Add(nDocumentoCaja)
        Next

        Return ListaDoc
    End Function

    Public Function PagoCajaUnica(be As documentoventaAbarrotes) As List(Of documento)
        Dim entidadSA As New entidadSA
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)
        Dim r As Record = dgvCompra.Table.CurrentRecord

        nDocumentoCaja = New documento
        nDocumentoCaja.idDocumento = CInt(Me.Tag)
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
        nDocumentoCaja.tipoDoc = be.tipoDocumento ' conf.TipoComprobante ' cbotipoDocPago.SelectedValue
        nDocumentoCaja.fechaProceso = venta.fechaDoc
        nDocumentoCaja.nroDoc = be.serieVenta
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.moneda = 1

        Dim cliente = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, venta.idCliente)
        If cliente IsNot Nothing Then
            nDocumentoCaja.idEntidad = cliente.idEntidad
            nDocumentoCaja.entidad = cliente.nombreCompleto
            nDocumentoCaja.nrodocEntidad = cliente.nrodoc
        Else
            nDocumentoCaja.idEntidad = "0"
            nDocumentoCaja.entidad = "Clientes varios"
            nDocumentoCaja.nrodocEntidad = "-"
        End If
        nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
        nDocumentoCaja.fechaActualizacion = DateTime.Now


        '  documento CAJA
        objCaja = New documentoCaja
        objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
        objCaja.idDocumento = 0
        objCaja.periodo = venta.fechaPeriodo
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
        objCaja.fechaProceso = venta.fechaDoc
        objCaja.fechaCobro = DateTime.Now
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO

        If cliente IsNot Nothing Then
            objCaja.codigoProveedor = cliente.idEntidad
            objCaja.IdProveedor = cliente.idEntidad
            objCaja.idPersonal = Integer.Parse(cliente.idEntidad)
        End If

        objCaja.TipoDocumentoPago = be.tipoDocumento 'conf.TipoComprobante 'cbotipoDocPago.SelectedValue
        objCaja.codigoLibro = "1"
        objCaja.tipoDocPago = be.tipoDocumento ' conf.TipoComprobante
        objCaja.formapago = "EF"
        objCaja.NumeroDocumento = "-"
        objCaja.numeroOperacion = "-"
        Select Case be.tipoDocumento
            Case "9907"
                objCaja.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA
            Case Else
                objCaja.movimientoCaja = TIPO_VENTA.VENTA_AL_TICKET
        End Select
        objCaja.montoSoles = Decimal.Parse(dgvCompra.Table.CurrentRecord.GetValue("importeTotal"))

        objCaja.moneda = venta.moneda
        objCaja.tipoCambio = TmpTipoCambio
        objCaja.montoUsd = Decimal.Parse(objCaja.montoSoles / TmpTipoCambio)

        objCaja.estado = "1"
        objCaja.glosa = "Por ventas con ticket"
        objCaja.entregado = "SI"

        objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
        objCaja.entidadFinanciera = cbocajaPago.SelectedValue
        objCaja.NombreEntidad = cbocajaPago.Text
        objCaja.usuarioModificacion = usuario.IDUsuario
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja
        nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja)
        asientoDocumento(nDocumentoCaja.documentoCaja)
        ListaDoc.Add(nDocumentoCaja)

        Return ListaDoc
    End Function

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim entidadSA As New entidadSA
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = venta.fechaPeriodo
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        Dim cliente = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, venta.idCliente)
        If cliente IsNot Nothing Then
            nAsiento.idEntidad = cliente.idEntidad
            nAsiento.nombreEntidad = cliente.nombreCompleto
        Else
            nAsiento.idEntidad = "0"
            nAsiento.nombreEntidad = "Clientes varios"
        End If
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = venta.fechaDoc
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = venta.glosa
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Sub asientoDocumento(doc As documentoCaja)
        Dim asiento As New asiento
        Dim nMovimiento As New movimiento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros


        ef = efSA.GetUbicar_estadosFinancierosPorID(doc.entidadFinanciera)

        asiento = AsientoTransito(doc.montoSoles, doc.montoUsd)

        ListaAsientos.Add(asiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = ef.cuenta
        nMovimiento.descripcion = ef.descripcion
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = "1213"
        nMovimiento.descripcion = "Clientes"
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

    End Sub

    Private Function GetDetallePago(objCaja As documentoCaja) As List(Of documentoCajaDetalle)
        Dim montoPago = objCaja.montoSoles
        GetDetallePago = New List(Of documentoCajaDetalle)
        For Each i In ventaDetalle
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

                    GetDetallePago.Add(New documentoCajaDetalle With
                                   {
                                   .codigoLote = i.codigoLote,
                                   .fecha = Date.Now,
                                   .idItem = i.idItem,
                                   .DetalleItem = i.nombreItem,
                                   .montoSoles = i.MontoPago,
                                   .montoUsd = FormatNumber(i.MontoPago / TmpTipoCambio, 2),
                                   .diferTipoCambio = TmpTipoCambio,
                                   .tipoCambioTransacc = TmpTipoCambio,
                                   .entregado = "SI",
                                   .idCajaUsuario = GFichaUsuarios.IdCajaUsuario,
                                   .usuarioModificacion = usuario.IDUsuario,
                                   .documentoAfectado = CInt(Me.Tag),
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

    Sub ImprimirTicketAcumulado(intIdDocumento As Integer)
        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim ticket As New CrearTicket()

        '  Dim r As Record = dgPedidos.Table.CurrentRecord
        Dim entidadSA As New entidadSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
        Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)


        'Ya podemos usar todos sus metodos
        ticket.AbreCajon()
        'Para abrir el cajon de dinero.
        'De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

        'Datos de la cabecera del Ticket.
        ticket.TextoCentro(Gempresas.NomEmpresa)
        'ticket.TextoCentro("ERM NEGOCIOS SAC.")
        'ticket.TextoCentro("JR. GN. SANTA CRUZ 481 INT-1506")
        'ticket.TextoCentro("JESUS MARIA - LIMA PERU")
        'ticket.TextoCentro("SUC: JR.SEBASTIAN LORENTE 199 TAMBO-HYO.")
        ticket.TextoCentro(Gempresas.IdEmpresaRuc)
        '   ticket.TextoIzquierda("EMAIL: cmcmarce14@gmail.com")
        'Es el mio por si me quieren contactar ...
        ticket.TextoIzquierda("")
        Select Case comprobante.tipoDocumento
            Case "12.1"
                'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
            Case "12.2"
                '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)

            Case Else
                ticket.TextoIzquierda("Ticket nota # " & comprobante.numeroVenta)
        End Select


        ticket.lineasHorizontales()
        'Sub cabecera.
        ticket.TextoIzquierda("")

        If comprobante.idCliente <> 0 Then
            Dim entidad = entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault
            Dim NBoletaElectronica As String = "Cliente: " & entidad.nombreCompleto
            ticket.TextoIzquierda(NBoletaElectronica)
            If entidad.nrodoc.Trim.Length = 11 Then
                ticket.TextoIzquierda("RUC.: " & entidad.nrodoc)
            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                ticket.TextoIzquierda("DNI.: " & entidad.nrodoc)
            Else
                ticket.TextoIzquierda("NRO DOC.: " & entidad.nrodoc)
            End If

        Else
            Dim NBoletaElectronica As String = "Cliente: " & comprobante.nombrePedido
            ticket.TextoIzquierda(NBoletaElectronica)

        End If
        ticket.TextoIzquierda("COD. MAQUINA REG.: USAFIKA12050121")
        ticket.TextoIzquierda("")
        ticket.TextoExtremos("FECHA: " + comprobante.fechaDoc.Value.ToShortDateString(), "HORA: " + comprobante.fechaDoc.Value.ToShortTimeString())
        ticket.lineasHorizontales()

        'Articulos a vender.
        ticket.EncabezadoVentaV2()
        'NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
        'ticket.lineasAsteriscos()
        ticket.lineasHorizontales()
        'Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
        'foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
        '{
        'ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
        'decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
        '}

        Dim nuevoDetalle = (From member In comprobanteDetalle
                            Group member By keys = New With
                           {
                                Key member.destino,
                                Key member.idItem,
                                Key member.nombreItem
                           }
                                Into Group
                            Select New With
                                {
                                .idItem = keys.idItem,
                                .destino = keys.destino,
                                .nombreItem = keys.nombreItem,
                                .sumCantidad = Group.Sum(Function(x) x.monto1),
                                .SumMonto = Group.Max(Function(x) x.importeMN)
                                }).ToList

        For Each i In nuevoDetalle

            'Select Case i.destino
            '    Case OperacionGravada.Grabado
            '        gravMN += CDec(i.montokardex)
            '        gravME += CDec(i.montokardexUS)

            '    Case OperacionGravada.Exonerado
            '        ExoMN += CDec(i.montokardex)
            '        ExoME += CDec(i.montokardexUS)

            '    Case OperacionGravada.Inafecto
            '        InaMN += CDec(i.montokardex)
            '        InaME += CDec(i.montokardexUS)
            'End Select

            ticket.AgregaArticuloV2(
                i.nombreItem,
                String.Format("{0:0.00}", i.sumCantidad.GetValueOrDefault),
                String.Format("{0:0.00}", i.SumMonto / i.sumCantidad),
                i.SumMonto)
        Next
        ticket.lineasIgual()

        'Resumen de la venta. Sólo son ejemplos
        'ticket.AgregarTotales("         TOTAL.........$", comprobante.ImporteNacional)

        ticket.AgregarTotales("         EXONERADA...S/.", ExoMN)
        ticket.AgregarTotales("         INAFECTA....S/.", InaMN)
        ticket.AgregarTotales("         GRAVADA.....S/.", gravMN)
        ticket.AgregarTotales("         IGV.........S/.", comprobante.igv01)
        'La M indica que es un decimal en C#
        ticket.AgregarTotales("         TOTAL.......S/.", comprobante.ImporteNacional)
        ticket.TextoIzquierda("")
        ticket.AgregarTotales("         EFECTIVO....S/.", comprobante.ImporteNacional)
        'ticket.AgregarTotales("         CAMBIO........$", 0)

        'Texto final del Ticket.
        ticket.TextoIzquierda("")
        ticket.TextoIzquierda("ARTICULOS VENDIDOS: " & nuevoDetalle.Count)
        ticket.TextoIzquierda("")
        ticket.TextoCentro("¡GRACIAS POR SU COMPRA!")
        ticket.CortaTicket()

        ticket.ImprimirTicket("POS-80C")
        ' ticket.ImprimirTicket("BIXOLON SRP-270")
        'Nombre de la impresora ticketera

    End Sub

    Sub ImprimirTicket(intIdDocumento As Integer)
        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim ticket As New CrearTicket()

        '  Dim r As Record = dgPedidos.Table.CurrentRecord
        Dim entidadSA As New entidadSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
        Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)


        'Ya podemos usar todos sus metodos
        ticket.AbreCajon()
        'Para abrir el cajon de dinero.
        'De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

        'Datos de la cabecera del Ticket.
        ticket.TextoCentro(Gempresas.NomEmpresa)
        'ticket.TextoCentro("ERM NEGOCIOS SAC.")
        'ticket.TextoCentro("JR. GN. SANTA CRUZ 481 INT-1506")
        'ticket.TextoCentro("JESUS MARIA - LIMA PERU")
        'ticket.TextoCentro("SUC: JR.SEBASTIAN LORENTE 199 TAMBO-HYO.")
        ticket.TextoCentro(Gempresas.IdEmpresaRuc)
        '   ticket.TextoIzquierda("EMAIL: cmcmarce14@gmail.com")
        'Es el mio por si me quieren contactar ...
        ticket.TextoIzquierda("")
        Select Case comprobante.tipoDocumento
            Case "12.1"
                'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
            Case "12.2"
                '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
            Case Else
                ticket.TextoIzquierda("Ticket nota # " & comprobante.numeroVenta)

        End Select


        ticket.lineasHorizontales()
        'Sub cabecera.
        ticket.TextoIzquierda("")

        If comprobante.idCliente <> 0 Then
            Dim entidad = entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault
            Dim NBoletaElectronica As String = "Cliente: " & entidad.nombreCompleto
            ticket.TextoIzquierda(NBoletaElectronica)
            If entidad.nrodoc.Trim.Length = 11 Then
                ticket.TextoIzquierda("RUC.: " & entidad.nrodoc)
            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                ticket.TextoIzquierda("DNI.: " & entidad.nrodoc)
            Else
                ticket.TextoIzquierda("NRO DOC.: " & entidad.nrodoc)
            End If

        Else
            Dim NBoletaElectronica As String = "Cliente: " & comprobante.nombrePedido
            ticket.TextoIzquierda(NBoletaElectronica)

        End If
        ticket.TextoIzquierda("COD. MAQUINA REG.: USAFIKA12050121")
        ticket.TextoIzquierda("")
        ticket.TextoExtremos("FECHA: " + comprobante.fechaDoc.Value.ToShortDateString(), "HORA: " + comprobante.fechaDoc.Value.ToShortTimeString())
        ticket.lineasHorizontales()

        'Articulos a vender.
        ticket.EncabezadoVentaV2()
        'NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
        'ticket.lineasAsteriscos()
        ticket.lineasHorizontales()
        'Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
        'foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
        '{
        'ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
        'decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
        '}

        For Each i In comprobanteDetalle

            Select Case i.destino
                Case OperacionGravada.Grabado
                    gravMN += CDec(i.montokardex)
                    gravME += CDec(i.montokardexUS)

                Case OperacionGravada.Exonerado
                    ExoMN += CDec(i.montokardex)
                    ExoME += CDec(i.montokardexUS)

                Case OperacionGravada.Inafecto
                    InaMN += CDec(i.montokardex)
                    InaME += CDec(i.montokardexUS)
            End Select

            ticket.AgregaArticuloV2(i.nombreItem, String.Format("{0:0.00}", i.monto1), String.Format("{0:0.00}", i.importeMN / i.monto1), i.importeMN)
        Next
        ticket.lineasIgual()

        'Resumen de la venta. Sólo son ejemplos
        'ticket.AgregarTotales("         TOTAL.........$", comprobante.ImporteNacional)

        ticket.AgregarTotales("         EXONERADA...S/.", ExoMN)
        ticket.AgregarTotales("         INAFECTA....S/.", InaMN)
        ticket.AgregarTotales("         GRAVADA.....S/.", gravMN)
        ticket.AgregarTotales("         IGV.........S/.", comprobante.igv01)
        'La M indica que es un decimal en C#
        ticket.AgregarTotales("         TOTAL.......S/.", comprobante.ImporteNacional)
        ticket.TextoIzquierda("")
        ticket.AgregarTotales("         EFECTIVO....S/.", comprobante.ImporteNacional)
        'ticket.AgregarTotales("         CAMBIO........$", 0)

        'Texto final del Ticket.
        ticket.TextoIzquierda("")
        ticket.TextoIzquierda("ARTICULOS VENDIDOS: " & comprobanteDetalle.Count)
        ticket.TextoIzquierda("")
        ticket.TextoCentro("¡GRACIAS POR SU COMPRA!")
        ticket.CortaTicket()

        ' ticket.ImprimirTicket("POS-80C")
        ticket.ImprimirTicket("BIXOLON SRP-270")
        'Nombre de la impresora ticketera

    End Sub


    Public Property venta As documentoventaAbarrotes
    Public Property ventaDetalle As List(Of documentoventaAbarrotesDet)
    Private Sub GetPagarVenta(r As Record)
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim ventaDetalleSA As New documentoVentaAbarrotesDetSA
        ListaAsientos = New List(Of asiento)

        If ChPagoDirecto.Checked Then
            CobroDirecto()
        ElseIf ChPagoAvanzado.Checked = True Then
            Dim f As New frmFormatoPagoComprobantes
            f.txtMontoXcobrar.Text = Decimal.Parse(r.GetValue("importeTotal")) ' txtTotalPagar.DecimalValue
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If f.Tag IsNot Nothing Then
                objPleaseWait = New FeedbackForm()
                objPleaseWait.StartPosition = FormStartPosition.CenterScreen
                objPleaseWait.Show()
                Application.DoEvents()
                Dim c = CType(f.Tag, List(Of documentoCaja))
                If c.Count > 0 Then
                    OtrasFormasPago(c)
                Else
                    objPleaseWait.Close()
                    MessageBox.Show("Debe realizar el pago del comprobante", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    btOperacion.Enabled = True
                    Exit Sub
                End If
            End If
        Else
            CobroAlCredito()
        End If
    End Sub

    Private Sub OtrasFormasPago(c As List(Of documentoCaja))
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim ventaDetalleSA As New documentoVentaAbarrotesDetSA
        Dim documento As New documento
        Dim tipoDocVenta As String = Nothing
        Dim serieVenta As String = Nothing
        Dim tipoventa As String = TIPO_VENTA.VENTA_AL_TICKET
        Select Case cboTipoDoc.Text
            Case "BOLETA"
                tipoDocVenta = "12.1"
                serieVenta = conf.Serie
            Case "FACTURA"
                tipoDocVenta = "12.2"
                serieVenta = conf.Serie
            Case "NOTA DE VENTA"
                tipoDocVenta = "9907"
                serieVenta = "NOTA"
                tipoventa = TIPO_VENTA.NOTA_DE_VENTA
        End Select

        Dim r As Record = dgvCompra.Table.CurrentRecord
        venta = New documentoventaAbarrotes
        venta = ventaSA.GetUbicar_documentoventaAbarrotesPorID(Integer.Parse(dgvCompra.Table.CurrentRecord.GetValue("idDocumento")))


        Dim idcliente = 0 ' r.GetValue("idcliente")
        idcliente = r.GetValue("idcliente")
        Select Case cboTipoDoc.Text
            Case "FACTURA"
                If idcliente <= 0 Then
                    MessageBox.Show("Debe identificar a un cliente", "Razon social", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    btOperacion.Enabled = True
                End If
        End Select
        If idcliente > 0 Then
            venta.idCliente = idcliente
            venta.NombreEntidad = r.GetValue("NombreEntidad")
            venta.nombrePedido = r.GetValue("NombreEntidad")
        End If

        documento.idDocumento = venta.idDocumento

        venta.TipoConfiguracion = conf.TipoConfiguracion
        venta.IdNumeracion = IIf(IsNothing(conf.ConfigComprobante), 0, conf.ConfigComprobante)
        venta.serieVenta = serieVenta  ' conf.Serie
        venta.fechaConfirmacion = Date.Now
        venta.tipoDocumento = tipoDocVenta ' If(cboTipoDoc.Text = "BOLETA", "12.1", "12.2")
        venta.tipoVenta = tipoventa ' TIPO_VENTA.VENTA_AL_TICKET
        venta.glosa = "VENTA CON TICKET"
        venta.estadoEntrega = StatusArticuloVentaPreparado.Pendiente
        documento.documentoventaAbarrotes = venta

        ventaDetalle = New List(Of documentoventaAbarrotesDet)
        ventaDetalle = ventaDetalleSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(venta.idDocumento)
        documento.documentoventaAbarrotes.documentoventaAbarrotesDet = ventaDetalle
        documento.asiento = ListaAsientos
        documento.ListaCustomDocumento = ListaPagosCajas(c, venta)
        '--------------------------------------------------------------------------------------------------
        venta.documentoventaAbarrotesDet = ventaDetalle
        venta.estadoCobro = venta.GetEstadoPagoComprobante
        If venta.estadoCobro = "PN" Then
            documento.documentoventaAbarrotes.terminos = "CREDITO"
        Else
            documento.documentoventaAbarrotes.terminos = "CONTADO"
        End If
        documento.documentoventaAbarrotes.documentoventaAbarrotesDet = ventaDetalle
        ventaSA.CobrarVentaRapida(documento)
        dgvCompra.Table.CurrentRecord.Delete()
        If MessageBox.Show("Desea impirmir ticket ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ImprimirTicket(documento.idDocumento)
        End If
    End Sub

    Private Sub CobroDirecto()
        Dim tipoDocVenta As String = Nothing
        Dim serieVenta As String = Nothing
        Dim tipoventa As String = TIPO_VENTA.VENTA_AL_TICKET
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim ventaDetalleSA As New documentoVentaAbarrotesDetSA
        objPleaseWait = New FeedbackForm()
        objPleaseWait.StartPosition = FormStartPosition.CenterScreen
        objPleaseWait.Show()
        Application.DoEvents()

        Dim documento As New documento

        Select Case cboTipoDoc.Text
            Case "BOLETA"
                tipoDocVenta = "12.1"
                serieVenta = conf.Serie
            Case "FACTURA"
                tipoDocVenta = "12.2"
                serieVenta = conf.Serie
            Case "NOTA DE VENTA"
                tipoDocVenta = "9907"
                serieVenta = "NOTA"
                tipoventa = TIPO_VENTA.NOTA_DE_VENTA
        End Select

        Dim r As Record = dgvCompra.Table.CurrentRecord
        venta = New documentoventaAbarrotes
        venta = ventaSA.GetUbicar_documentoventaAbarrotesPorID(Integer.Parse(dgvCompra.Table.CurrentRecord.GetValue("idDocumento")))

        ventaDetalle = New List(Of documentoventaAbarrotesDet)
        ventaDetalle = ventaDetalleSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(venta.idDocumento)
        Dim montoVentaTotal = ventaDetalle.Sum(Function(o) o.importeMN).GetValueOrDefault
        '-------------------------------------------------------------------------------------------------------------

        documento.idDocumento = venta.idDocumento

        Dim idcliente = 0 ' r.GetValue("idcliente")
        idcliente = r.GetValue("idcliente")
        Select Case cboTipoDoc.Text
            Case "FACTURA"
                If idcliente <= 0 Then
                    MessageBox.Show("Debe identificar a un cliente", "Razon social", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    btOperacion.Enabled = True
                    Exit Sub
                End If

            Case "BOLETA"
                If montoVentaTotal > 699.99 Then
                    MessageBox.Show("Debe seleccionar una factura, debido al monto de venta", "Identificar factura", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    btOperacion.Enabled = True
                    Exit Sub
                End If
        End Select


        If idcliente > 0 Then
            venta.idCliente = idcliente
            venta.NombreEntidad = r.GetValue("NombreEntidad")
            venta.nombrePedido = r.GetValue("NombreEntidad")
        End If

        venta.TipoConfiguracion = conf.TipoConfiguracion
        venta.IdNumeracion = IIf(IsNothing(conf.ConfigComprobante), 0, conf.ConfigComprobante)
        venta.serieVenta = serieVenta 'conf.Serie
        venta.fechaConfirmacion = Date.Now
        venta.tipoDocumento = tipoDocVenta ' If(cboTipoDoc.Text = "BOLETA", "12.1", "12.2")
        venta.tipoVenta = tipoventa 'TIPO_VENTA.VENTA_AL_TICKET
        venta.glosa = "VENTA CON TICKET"
        venta.terminos = "CONTADO"
        venta.estadoEntrega = StatusArticuloVentaPreparado.Pendiente
        documento.documentoventaAbarrotes = venta

        'detalle de la venta
        documento.asiento = ListaAsientos
        documento.ListaCustomDocumento = PagoCajaUnica(venta)
        '--------------------------------------------------------------------------------------------------
        venta.documentoventaAbarrotesDet = ventaDetalle
        venta.estadoCobro = venta.GetEstadoPagoComprobante
        documento.documentoventaAbarrotes.documentoventaAbarrotesDet = ventaDetalle

        'ventaSA.CobrarVentaRapida(documento)
        ventaSA.CobrarVentaJiuni(documento)
        dgvCompra.Table.CurrentRecord.Delete()
        'If MessageBox.Show("Desea impirmir ticket ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '    'ImprimirTicket(documento.idDocumento)
        '    ImprimirTicketAcumulado(documento.idDocumento)
        '    ImprimirTicketAcumulado(documento.idDocumento)
        'End If

        'Dim f As New FormImpresionNuevo  ' frmVentaNuevoFormato
        'f.DocumentoID = documento.idDocumento
        'f.StartPosition = FormStartPosition.CenterScreen
        '' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.Show(Me)

    End Sub

    Private Sub CobroAlCredito()
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim ventaDetalleSA As New documentoVentaAbarrotesDetSA
        objPleaseWait = New FeedbackForm()
        objPleaseWait.StartPosition = FormStartPosition.CenterScreen
        objPleaseWait.Show()
        Application.DoEvents()

        Dim documento As New documento

        venta = New documentoventaAbarrotes
        venta = ventaSA.GetUbicar_documentoventaAbarrotesPorID(Integer.Parse(dgvCompra.Table.CurrentRecord.GetValue("idDocumento")))

        documento.idDocumento = venta.idDocumento

        venta.TipoConfiguracion = conf.TipoConfiguracion
        venta.IdNumeracion = IIf(IsNothing(conf.ConfigComprobante), 0, conf.ConfigComprobante)
        venta.serieVenta = conf.Serie
        venta.fechaConfirmacion = Date.Now
        venta.tipoDocumento = If(cboTipoDoc.Text = "BOLETA", "12.1", "12.2")
        venta.estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
        venta.tipoVenta = TIPO_VENTA.VENTA_AL_TICKET
        venta.terminos = "CREDITO"
        venta.glosa = "VENTA CON TICKET"
        documento.documentoventaAbarrotes = venta

        ventaDetalle = New List(Of documentoventaAbarrotesDet)
        ventaDetalle = ventaDetalleSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(venta.idDocumento)
        documento.documentoventaAbarrotes.documentoventaAbarrotesDet = ventaDetalle
        ventaSA.CobrarVentaRapida(documento)
        dgvCompra.Table.CurrentRecord.Delete()
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click

        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            If MessageBox.Show("Desea elimiar el pedido seleccionado?", "Pedidos de venta!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminarPV(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                ButtonAdv15_Click(sender, e)
            End If
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub frmPedidoPendiente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GradientPanel2.Enabled = True
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf GetListaVentasPorPeriodo))
        thread.Start()
    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick

    End Sub

    Private Sub dgvCompra_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellDoubleClick
        Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            btOperacion_Click(sender, e)
            'If MessageBox.Show("Realizar el cobro ticket!", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


            '    Dim ef As New EstadosFinancierosSA
            '    Dim cajaUsuario As New cajaUsuario
            '    Dim cajaUsuarioSA As New cajaUsuarioSA
            '    Dim usuarioSA As New UsuarioSA
            '    Dim usuarioxls As New Usuario
            '    cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)

            '    If Not IsNothing(cajaUsuario) Then
            '        usuarioxls = usuarioSA.UbicarUsuarioXid(New Usuario With {.IDUsuario = usuario.IDUsuario})

            '        GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

            '        Dim f As New frmCobroPedidos(Integer.Parse(dgvCompra.Table.CurrentRecord.GetValue("idDocumento")))
            '        f.txtNomUser.Text = usuarioxls.Full_Name
            '        'F.txtCajaOrigen.Tag = CInt(cajaUsuario.idCajaOrigen)
            '        'F.txtCajaOrigen.Text = ef.GetUbicar_estadosFinancierosPorID(CInt(cajaUsuario.idCajaOrigen)).descripcion
            '        '   F.GetObtenerSaldoEF()
            '        'F.GridPago()

            '        If IsNothing(cajaUsuario.idPadre) Then
            '            f.txtTipoUser.Text = "Usuario Responsable"
            '            f.txtTipoUser.Tag = cajaUsuario.idcajaUsuario
            '        Else
            '            f.txtTipoUser.Text = "Usuario Dependiente"
            '            f.txtTipoUser.Tag = cajaUsuario.idcajaUsuario
            '        End If

            '        f.StartPosition = FormStartPosition.CenterParent
            '        f.ShowDialog()
            '        ProgressBar1.Visible = True
            '        ProgressBar1.Style = ProgressBarStyle.Marquee
            '        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf GetListaVentasPorPeriodo))
            '        thread.Start()
            '        'Dim f As New frmCajaTicket
            '        'f.SinAnticipo()
            '        'f.Show()
            '    Else
            '        MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    End If

            '    'End If
        Else
            MessageBox.Show("Debe seleccionar un pedido para cobrar!", "Seleccionar Fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        LoadingAnimator.Wire(dgvCompra.TableControl)
        Dim r As Record = dgvCompra.Table.CurrentRecord
        Dim nombrePedido = Nothing
        If r IsNot Nothing Then
            frmDetalleVentaView = New frmDetalleVentaView(Integer.Parse(r.GetValue("idDocumento")))
            nombrePedido = r.GetValue("pedido")
            If nombrePedido.ToString.Trim.Length > 0 Then
                frmDetalleVentaView.CaptionLabels(1).Text = r.GetValue("pedido")
            Else
                frmDetalleVentaView.CaptionLabels(1).Text = r.GetValue("NombreEntidad")
            End If
            frmDetalleVentaView.StartPosition = FormStartPosition.CenterParent
            frmDetalleVentaView.ShowDialog()
        Else
            MessageBox.Show("Debe seleccionar un pedido!", "Seleccionar Fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        LoadingAnimator.UnWire(dgvCompra.TableControl)
    End Sub

    Private Sub GradientPanel15_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel15.Paint

    End Sub

    Private Sub ChPagoAvanzado_OnChange(sender As Object, e As EventArgs) Handles ChPagoAvanzado.OnChange
        If ChPagoAvanzado.Checked = True Then
            ChPagoDirecto.Checked = False
            cbocajaPago.Visible = False
        Else
            '       cbocajaPago.Visible = True
        End If
        If ChPagoAvanzado.Checked = False AndAlso ChPagoDirecto.Checked = False Then
            LblPagoCredito.Visible = True
        Else
            LblPagoCredito.Visible = False
        End If
    End Sub

    Private Sub ChPagoQuestion_OnChange(sender As Object, e As EventArgs) Handles ChPagoDirecto.OnChange
        PagoDirectoCheck()
    End Sub

    Private Sub PagoDirectoCheck()
        If ChPagoDirecto.Checked Then
            cbocajaPago.Visible = True
            ' ChPagoAvanzado.Visible = True
            ChPagoAvanzado.Checked = False
            Label8.Visible = True
        Else
            cbocajaPago.Visible = False
            ''  ChPagoAvanzado.Visible = False
            'ChPagoAvanzado.Checked = False
            'Label8.Visible = False
        End If
        If ChPagoAvanzado.Checked = False AndAlso ChPagoDirecto.Checked = False Then
            LblPagoCredito.Visible = True
        Else
            LblPagoCredito.Visible = False
        End If
    End Sub

    Private Sub dgvKardexVal_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles dgvCompra.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 8 Then
                If e.Inner.Style.CellValue.ToString.Trim.Length > 0 Then
                    e.Inner.Style.Description = e.Inner.Style.CellValue
                Else
                    e.Inner.Style.Description = "Identificar cliente. . ."
                End If

                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub dgvKardexVal_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgvCompra.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 8 Then
                Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.CLIENTE)
                f.CaptionLabels(0).Text = "Cliente"
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                If Not IsNothing(f.Tag) Then
                    Dim c = DirectCast(f.Tag, entidad)
                    'Dim c = CType(f.Tag, entidad)
                    'txtCliente2.Text = c.nombreCompleto
                    'txtCliente2.Tag = c.idEntidad
                    'txtRuc2.Text = c.nrodoc
                    'txtRuc2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    'txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                    'Dim idCliente = Integer.Parse(dgvCompra.TableModel(e.Inner.RowIndex, 10).CellValue)
                    'Dim NroIdentidadCliente = Integer.Parse(dgvCompra.TableModel(e.Inner.RowIndex, 7).CellValue)
                    'Dim nombreCliente = Integer.Parse(dgvCompra.TableModel(e.Inner.RowIndex, 8).CellValue)

                    dgvCompra.TableModel(e.Inner.RowIndex, 10).CellValue = c.idEntidad
                    dgvCompra.TableModel(e.Inner.RowIndex, 7).CellValue = c.nrodoc
                    dgvCompra.TableModel(e.Inner.RowIndex, 8).CellValue = c.nombreCompleto

                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipoDoc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedValueChanged
        'If cboTipoDoc.Text.Trim.Length > 0 Then
        '    ProgressBar2.Visible = True
        '    ProgressBar2.Style = ProgressBarStyle.Marquee
        '    BackgroundWorker1.RunWorkerAsync()
        'End If
        If cboTipoDoc.Text.Trim.Length > 0 Then
            dgvCompra.Visible = True
            GradientPanel2.Enabled = False
            Select Case cboTipoDoc.Text
                Case "BOLETA", "FACTURA"
                    dgvCompra.Visible = False
                    ProgressBar2.Visible = True
                    ProgressBar2.Style = ProgressBarStyle.Marquee
                    BackgroundWorker1.RunWorkerAsync()

                Case "NOTA DE VENTA"

                    dgvCompra.Visible = False
                    GradientPanel2.Enabled = True
                    btOperacion.Enabled = True
                    ProgressBar2.Visible = True
                    ProgressBar2.Style = ProgressBarStyle.Marquee
                    BackgroundWorker2.RunWorkerAsync()
                Case Else

                    dgvCompra.Visible = True
                    dgvCompra.Enabled = True
                    GradientPanel2.Enabled = True
            End Select

        End If

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim strIdModulo As String = Nothing
        If cboTipoDoc.Text = "BOLETA" Then
            strIdModulo = "VT2"
        ElseIf cboTipoDoc.Text = "FACTURA" Then
            strIdModulo = "VT3"
        End If
        Dim strIDEmpresa = Gempresas.IdEmpresaRuc
        configuracionModuloV2(strIDEmpresa, strIdModulo, "", GEstableciento.IdEstablecimiento)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        cbocajaPago.DataSource = ListaEstadosFinancieros ' cajaSA.GetCuentasFinancierasByEmpresa(Gempresas.IdEmpresaRuc, "EF")
        cbocajaPago.ValueMember = "idestado"
        cbocajaPago.DisplayMember = "descripcion"
        ProgressBar2.Visible = False
        btOperacion.Enabled = True
        dgvCompra.Visible = True
        dgvCompra.Enabled = True
        GradientPanel2.Enabled = True
    End Sub

    Private Sub frmPedidoPendiente_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        BackgroundWorker1.CancelAsync()
        BackgroundWorker2.CancelAsync()
    End Sub

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click

    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        GetCuentasFinancieras()
    End Sub

    Private Sub GetCuentasFinancieras()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        ListaEstadosFinancieros = New List(Of estadosFinancieros)
        'ListaEstadosFinancieros = cajaSA.GetCuentasFinancierasByEmpresa(Gempresas.IdEmpresaRuc, "EF")

        For Each i As cajaUsuario In cajaUsuarioSA.ResumenTransaccionesXusuarioCajaPago(
            New cajaUsuario With
            {
            .idcajaUsuario = GFichaUsuarios.IdCajaUsuario,
            .idPersona = usuario.IDUsuario
            })

            ListaEstadosFinancieros.Add(
                New estadosFinancieros With
                {
                .idestado = i.idEntidad,
                .descripcion = i.NombreEntidad,
                .tipo = i.Tipo,
                .codigo = i.moneda
                })
        Next
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        cbocajaPago.DataSource = ListaEstadosFinancieros ' cajaSA.GetCuentasFinancierasByEmpresa(Gempresas.IdEmpresaRuc, "EF")
        cbocajaPago.ValueMember = "idestado"
        cbocajaPago.DisplayMember = "descripcion"
        ProgressBar2.Visible = False
        btOperacion.Enabled = True
        dgvCompra.Visible = True
        dgvCompra.Enabled = True
        GradientPanel2.Enabled = True
    End Sub
End Class