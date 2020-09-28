Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Tools
Imports System.Collections
Imports Syncfusion.Windows.Forms.Grid
Imports System.Collections.Specialized
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmPagosModal
    Inherits frmMaster

    Public Property TipoCompra() As String

    ''' <summary>
    ''' código de la compra de origen
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IDDocumentoCompra() As Integer
    Dim toolTip As Popup

    ''' <summary>
    ''' Control de usuario que muestra información de la compra
    ''' </summary>
    ''' <remarks></remarks>
    Dim ucInfoCompra As New ucInfoCompra

    ''' <summary>
    ''' Moneda de la compra de origen
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MonedaCompra() As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        EstadoPAgos()
        Me.WindowState = FormWindowState.Maximized
        dockingManager1.DockControlInAutoHideMode(Panel8, DockingStyle.Right, 565)
        dockingManager1.SetDockLabel(Panel8, "Compras")
    End Sub
#Region "Métodos"

    Public Sub EstadoPAgos()
        Dim CompraSA As New DocumentoCompraSA
        Dim Compra As New documentocompra
        Dim documentoCaja As New List(Of documentoCaja)
        Dim documentoCajaSA As New DocumentoCajaSA

        Compra = CompraSA.GetSumaCuentasXpagar(GEstableciento.IdEstablecimiento, "30")

        Label26.Text = FormatNumber(Compra.Monto30mn, 2)

        ' Compra = CompraSA.GetSumaCuentasXpagar(GEstableciento.IdEstablecimiento, "60")

        Label24.Text = FormatNumber(Compra.Monto60mn, 2)

        '  Compra = CompraSA.GetSumaCuentasXpagar(GEstableciento.IdEstablecimiento, "90")

        Label22.Text = FormatNumber(Compra.Monto90mn, 2)

        '   Compra = CompraSA.GetSumaCuentasXpagar(GEstableciento.IdEstablecimiento, "90+")

        Label4.Text = FormatNumber(Compra.Monto90Masmn, 2)

        Label11.Text = "S/." & FormatNumber(CDec(Label26.Text) + CDec(Label24.Text) + CDec(Label22.Text) + CDec(Label4.Text), 2)


        documentoCaja = documentoCajaSA.SumaxINgresosEgresosAnual()

        For Each i In documentoCaja
            Select Case i.tipoMovimiento
                Case "DC"

                Case "PG"
                    Label19.Text = "PENS/." & FormatNumber(i.montoSoles, 2)
            End Select
        Next
    End Sub

    ''' <summary>
    ''' Función que devuelve el número de cheques pendientes por proveedor
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConteoChequesPendientes()
        Dim documentoCajaSA As New DocumentoCajaSA
        Return documentoCajaSA.ListaChequesPendientesXProveedor(GEstableciento.IdEstablecimiento, txtProveedor.ValueMember, PeriodoGeneral)
    End Function

    Private Function ConteoComprasPendientes()
        Dim documentoCajaSA As New DocumentoCajaSA
        Return documentoCajaSA.ListaComprasPendientesXproveedor(GEstableciento.IdEstablecimiento, txtProveedor.ValueMember)
    End Function

    Private Sub EditarEstadoPagoCompra(strEstadoPago As String)
        Dim compraSA As New DocumentoCompraSA
        compraSA.EditarEstadoCompra(IDDocumentoCompra, strEstadoPago)
    End Sub

    Private Sub btnNuevoPago(strFormPago As String)
        Me.Cursor = Cursors.WaitCursor
        Dim objLista As New DocumentoCajaDetalleSA
        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0
        Dim detalle As New documentocompradetalle
        Dim detalleSA As New DocumentoCompraDetalleSA

        Select Case TipoCompra



            Case TIPO_COMPRA.COMPRA
                With frmPagos
                    '   .tbFormaPago.ToggleState = Tools.ToggleButtonState.Inactive
                    .dgvDetalleItems.Rows.Clear()
                    .manipulacionEstado = ENTITY_ACTIONS.INSERT
                    Select Case MonedaCompra
                        Case "NAC"
                            .lblIdProveedor = txtProveedor.ValueMember
                            .lblNomProveedor = txtProveedor.Text
                            .lblCuentaProveedor = "4212"
                            .lblIdDocumento.Text = IDDocumentoCompra

                            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(IDDocumentoCompra)
                                detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)
                                'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe + detalle.ImporteDBMN - CDec(i.MontoPagadoSoles)
                                'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS + detalle.ImporteDBME - CDec(i.MontoPagadoUSD)
                                cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles)
                                cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD)
                                saldomn += cTotalmn
                                saldome += cTotalme
                                If cTotalmn > 0 Or cTotalme > 0 Then
                                    .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                                                               Nothing, cTotalmn, cTotalme,
                                                               "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
                                End If

                            Next
                            txtImporteCompramn.Text = saldomn.ToString("N2")
                            txtImporteComprame.Text = saldome.ToString("N2")

                            '.nudImporteNac.Maximum = CDec(lblPagoMN.Text)
                            .txtSaldoPorPagar.DecimalValue = CDec(txtImporteCompramn.Text)
                            .lblDeudaPendienteme.Text = CDec(txtImporteComprame.Text)
                        Case Else

                    End Select

                    If CDec(txtImporteCompramn.Text) <= 0 Then
                        '    MsgBox("El documento ya se encuentra pagado.", MsgBoxStyle.Information, "Aviso del Sistema")
                        Label2.Text = "El documento ya se encuentra pagado."
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        EditarEstadoPagoCompra(TIPO_COMPRA.PAGO.PAGADO)
                        'PanelError.Visible = True
                        'Timer1.Enabled = True
                        'TiempoEjecutar(10)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    Else
                        EditarEstadoPagoCompra(TIPO_COMPRA.PAGO.PENDIENTE_PAGO)
                        'If .TieneCuentaFinanciera = True Then
                        '.txtFechaComprobante.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                        '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                        '.txtFechaComprobante.Enabled = False
                        .lblPerido.Text = PeriodoGeneral
                        'If strFormPago = "EFECTIVO" Then
                        '    .rbEfectivo.Checked = True
                        '    .LoadEfectivo()
                        '    .txtNumero.Visible = False
                        '    .txtNumero.Clear()
                        'ElseIf strFormPago = "OTROS" Then
                        '    .rbOtros.Checked = True
                        '    .LoadOtros()
                        '    .txtNumero.Visible = True
                        '    .txtNumero.Clear()
                        'End If
                        .cboTipoDoc.Enabled = True
                        .cboTipoDoc.ReadOnly = False
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                        'Else
                        '    Label2.Text = "Debe indicar una caja activa para realizar esta acción!"
                        '    Timer1.Enabled = True
                        '    PanelError.Visible = True
                        '    TiempoEjecutar(10)
                        'End If
                    End If
                End With
            Case TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION, TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
                Label2.Text = "La compra está pagada."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Me.Cursor = Cursors.Arrow
                Exit Sub
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub btnNuevoPagoNotas(intIdDocumentoNota As Integer, StrTipoNota As String)
        Me.Cursor = Cursors.WaitCursor
        Dim objLista As New DocumentoCajaDetalleSA
        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0


        With frmPagosNotas
            .Label23.Text = StrTipoNota
            .Label23.Visible = True
            '   .tbFormaPago.ToggleState = Tools.ToggleButtonState.Inactive
            .dgvDetalleItems.Rows.Clear()
            .manipulacionEstado = ENTITY_ACTIONS.INSERT
            Select Case MonedaCompra
                Case "NAC"
                    .lblIdProveedor = txtProveedor.ValueMember
                    .lblNomProveedor = txtProveedor.Text
                    .lblCuentaProveedor = "4212"
                    .lblIdDocumento.Text = intIdDocumentoNota

                    For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(intIdDocumentoNota)
                        cTotalmn = Math.Round(CDec(i.MontoDeudaSoles) - CDec(i.MontoPagadoSoles), 2)
                        cTotalme = Math.Round(CDec(i.MontoDeudaUSD) - CDec(i.MontoPagadoUSD), 2)
                        saldomn += cTotalmn
                        saldome += cTotalme
                        If cTotalmn > 0 Or cTotalme > 0 Then
                            .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                                                       Nothing, cTotalmn, cTotalme,
                                                       "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT)
                        End If

                    Next
                    'txtImporteCompramn.Text = saldomn.ToString("N2")
                    'txtImporteComprame.Text = saldome.ToString("N2")

                    '.nudImporteNac.Maximum = CDec(lblPagoMN.Text)
                    .lblDeudaPendiente.Text = CDec(cTotalmn)
                    .lblDeudaPendienteme.Text = CDec(cTotalme)
                Case Else

            End Select

            If CDec(saldomn) <= 0 Then
                '    MsgBox("El documento ya se encuentra pagado.", MsgBoxStyle.Information, "Aviso del Sistema")
                Label2.Text = "El documento ya se encuentra pagado."
                Timer1.Enabled = True
                TiempoEjecutar(10)
                'PanelError.Visible = True
                'Timer1.Enabled = True
                'TiempoEjecutar(10)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                If .TieneCuentaFinanciera = True Then
                    .txtFechaComprobante.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                    .txtFechaComprobante.Enabled = False
                    .lblPerido.Text = PeriodoGeneral
                    'If strFormPago = "EFECTIVO" Then
                    '    .rbEfectivo.Checked = True
                    '    .LoadEfectivo()
                    '    .txtNumero.Visible = False
                    '    .txtNumero.Clear()
                    'ElseIf strFormPago = "OTROS" Then
                    '    .rbOtros.Checked = True
                    '    .LoadOtros()
                    '    .txtNumero.Visible = True
                    '    .txtNumero.Clear()
                    'End If
                    .cboTipoDoc.Enabled = True
                    .cboTipoDoc.ReadOnly = False
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                Else
                    Label2.Text = "Debe indicar una caja activa para realizar esta acción!"
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    'PanelError.Visible = True
                    'Timer1.Enabled = True
                    'TiempoEjecutar(10)
                End If
            End If
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try

            'Me.lstEntidades.DataSource = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
            'Me.lstEntidades.DisplayMember = "nombreCompleto"
            'Me.lstEntidades.ValueMember = "idEntidad"
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub UbicarEntidadPorRuc(strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                txtProveedor.Text = .nombreCompleto
                txtProveedor.ValueMember = .idEntidad
                '      txtCuenta.Text = .cuentaAsiento
                txtRuc.Text = .nrodoc
            End With
        Else
            txtProveedor.Clear()
            txtProveedor.Clear()
            '        txtCuenta.Clear()
            txtRuc.Clear()
        End If
    End Sub

    Private Sub ObtenerPorDetails(strDocumentoAfectado As Integer)

        Dim objLista As New DocumentoCajaDetalleSA
        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0
        Dim detalle As New documentocompradetalle
        Dim detalleSA As New DocumentoCompraDetalleSA

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0
        Dim dt As New DataTable()
        Try
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("nombreItem", GetType(String))
            dt.Columns.Add("importeCompraMN", GetType(Decimal))
            dt.Columns.Add("importeCompraME", GetType(Decimal))
            dt.Columns.Add("acuentaMN", GetType(Decimal))
            dt.Columns.Add("acuentaME", GetType(Decimal))

            dt.Columns.Add("ndbMN", GetType(Decimal))
            dt.Columns.Add("ndbME", GetType(Decimal))

            dt.Columns.Add("ncMN", GetType(Decimal))
            dt.Columns.Add("ncME", GetType(Decimal))

            dt.Columns.Add("estado", GetType(String))
            dt.Columns.Add("secuencia", GetType(Integer))

            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(strDocumentoAfectado)
                detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)

                'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe + detalle.ImporteDBMN - CDec(i.MontoPagadoSoles)
                'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS + detalle.ImporteDBME - CDec(i.MontoPagadoUSD)
                cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles)
                cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD)
                saldomn += cTotalmn
                saldome += cTotalme

                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idItem
                dr(1) = i.DetalleItem

                'If TipoCompra = TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION Or TipoCompra = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION Then
                '    dr(2) = i.MontoDeudaSoles
                '    dr(3) = i.MontoDeudaUSD
                '    dr(4) = 0
                '    dr(5) = 0

                '    dr(6) = detalle.ImporteDBMN
                '    dr(7) = detalle.ImporteDBME
                '    dr(8) = detalle.importe
                '    dr(9) = detalle.importeUS
                '    dr(10) = "Pagado"
                '    dr(11) = i.secuencia
                'ElseIf TipoCompra = TIPO_COMPRA.COMPRA_AL_CREDITO Or TipoCompra = TIPO_COMPRA.COMPRA_AL_CREDITO_CON_RECEPCION Then
                dr(2) = i.MontoDeudaSoles
                dr(3) = i.MontoDeudaUSD
                dr(4) = i.MontoPagadoSoles
                dr(5) = i.MontoPagadoUSD
                dr(6) = detalle.ImporteDBMN
                dr(7) = detalle.ImporteDBME
                dr(8) = detalle.importe
                dr(9) = detalle.importeUS
                dr(10) = IIf(cTotalmn <= 0, "Pagado", "Pendiente")
                dr(11) = i.secuencia
                'End If
                dt.Rows.Add(dr)
            Next
            '  Me.dgvDoc.BeginUpdate()
            Me.dgvDoc.DataSource = dt
            Me.dgvDoc.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
            txtImporteCompramn.Text = saldomn.ToString("N2")
            txtImporteComprame.Text = saldome.ToString("N2")
        Catch ex As Exception
            MsgBox("Error al obtener datos.!" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
        End Try
    End Sub

    Private Sub loadNotas()
        Dim customers As New BaseCollection
        customers = BaseCollection.ListaPagosXNotasXidDocumento(IDDocumentoCompra)
        Me.GDB.Binder.SetDataBinding(customers, "")

        Dim childrenLevel As GridHierarchyLevel

        childrenLevel = Me.GDB.Binder.AddRelation("Children")

        If IsNothing(childrenLevel) Then
            'childrenLevel = Me.GDB.Binder.AddRelation("Children")
            'childrenLevel.ShowHeaders = False
        ElseIf childrenLevel.ShowHeaders = False Then

        ElseIf childrenLevel.ShowHeaders = True Then
            childrenLevel.ShowHeaders = False
            childrenLevel.RowStyle.BackColor = SystemColors.Window
        End If
        Me.GDB.Binder.RootHierarchyLevel.ShowHeaders = True


        Dim rootLevel As GridHierarchyLevel = Me.GDB.Binder.RootHierarchyLevel
        rootLevel.RowStyle.BackColor = SystemColors.Window
        Me.GDB.DefaultRowHeight = 18
        Me.GDB.DefaultColWidth = 70
        GDB.ShowTreeLines = True
        GDB.GridBoundColumns("IdDocumento").Hidden = True
        GDB.GridBoundColumns("EstadoPago").Width = 180
        'childrenLevel.ShowHeaders = False
        'Me.GDB.Binder.RootHierarchyLevel.ShowHeaders = True
        GDB.Refresh()
    End Sub

    Enum Sys
        Inicio
        Proceso
    End Enum

    Sub InfoCompra(n As Sys)
        Dim documentocompraSA As New DocumentoCompraSA
        Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        Dim strEstado As String = Nothing

        Dim objDocCaja As New DocumentoSA
        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim establecSA As New establecimientoSA
        Dim estadoF As New EstadosFinancierosSA

        If IDDocumentoCompra > 0 Then

            With documentocompraSA.UbicarDocumentoCompra(IDDocumentoCompra)
                ucInfoCompra.txtFecha.Text = .fechaDoc
                ucInfoCompra.txtPeriodo.Text = .fechaContable
                ucInfoCompra.txtComprobante.Text = tablaSA.GetUbicarTablaID(10, .tipoDoc).descripcion
                ucInfoCompra.txtSerie.Text = .serie
                ucInfoCompra.txtNumero.Text = .numeroDoc
                With entidadSA.UbicarEntidadPorID(.idProveedor).First
                    'txtProveedor.Text = .nombreCompleto
                    'txtProveedor.ValueMember = .idEntidad
                    'txtCuenta.Text = .cuentaAsiento

                    ucInfoCompra.txtProveedor.Text = .nombreCompleto
                    ucInfoCompra.txtCuenta.Text = .cuentaAsiento
                End With

                ucInfoCompra.txtTipoCompra.Text = .tipoCompra
                ucInfoCompra.txtMoneda.Text = .monedaDoc
                ucInfoCompra.txtIgv.Text = .igv01
                ucInfoCompra.txtTipoCambio.Text = .tcDolLoc
                ucInfoCompra.txtImportemn.Text = .importeTotal
                ucInfoCompra.txtImporteme.Text = .importeUS
                strEstado = .estadoPago

                'If .estadoPago = TIPO_COMPRA.PAGO.PAGADO Then
                '    ucInfoCompra.rbDocPagado.Checked = True

                '    With objDocCaja.UbicarDocumento(documentoCajaDetalleSA.RecuperarIDCompra(IdCompraOrigen))
                '        With documentoCajaSA.GetUbicar_documentoCajaPorID(documentoCajaDetalleSA.RecuperarIDCompra(IdCompraOrigen))
                '            txtIdCaja = .entidadFinanciera
                '            With estadoF.GetUbicar_estadosFinancierosPorID(.entidadFinanciera)
                '                txtCaja = .descripcion
                '                txtCuentaEF = .cuenta
                '            End With
                '        End With
                '    End With
                'Else
                '    ucInfoCompra.rbTramite.Checked = True
                'End If

            End With
        End If

        ' position the tooltip with its stem towards the right end of the button
        If n = Sys.Inicio Then

        ElseIf n = Sys.Proceso Then
            toolTip.Show(btnInfoCompra)
        End If


    End Sub

    Private Sub UbicarCompraXPorveedorNroSerie(RucProveedor As String)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoCompra As New List(Of documentocompra)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("tipoCompra", GetType(String))
        dt.Columns.Add("Fecha", GetType(String))
        dt.Columns.Add("periodo", GetType(String))

        dt.Columns.Add("TipoDoc", GetType(String))
        dt.Columns.Add("Serie", GetType(String))
        dt.Columns.Add("Numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("montoMN", GetType(Decimal))
        dt.Columns.Add("montoME", GetType(Decimal))

        documentoCompra = documentoCompraSA.UbicarCompraPorProveedorXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucProveedor, PeriodoGeneral)
        Dim str As String
        If Not IsNothing(documentoCompra) Then
            For Each i In documentoCompra
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.tipoCompra
                dr(2) = str
                dr(3) = i.fechaContable
                dr(4) = tablaSA.GetUbicarTablaID(10, i.tipoDoc).descripcion.Substring(0, 3)
                dr(5) = i.serie
                dr(6) = i.numeroDoc
                Select Case i.monedaDoc
                    Case 1
                        dr(7) = "NAC"
                    Case Else
                        dr(7) = "EXT"
                End Select
                dr(8) = i.importeTotal
                dr(9) = i.importeUS
                dt.Rows.Add(dr)
            Next
            dgvCompra.DataSource = dt

        Else

        End If
    End Sub

#End Region

    Sub LoadDetalles()

        IDDocumentoCompra = dgvCompra.Table.CurrentRecord.GetValue("idDocumento")
        TipoCompra = dgvCompra.Table.CurrentRecord.GetValue("tipoCompra")

        'Select Case dgvCompra.Table.CurrentRecord.GetValue("tipoCompra")
        '    Case TIPO_COMPRA.COMPRA_AL_CREDITO
        '        txTipoCompra.Text = "Compra al credito c/exist. trans."
        '    Case TIPO_COMPRA.COMPRA_AL_CREDITO_CON_RECEPCION
        '        txTipoCompra.Text = "Compra al credito c/recep. exist."
        '    Case TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION
        '        txTipoCompra.Text = "Compra al contado c/recep. exist."
        '    Case TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
        txTipoCompra.Text = "Compra" '"Compra al contado c/exist. trans."
        'End Select

        MonedaCompra = dgvCompra.Table.CurrentRecord.GetValue("moneda")
        btnInfoCompra.Image = My.Resources.b_docsql
        btnInfoCompra.Tag = "YES"
        TextBoxExt1.Metrocolor = Color.FromKnownColor(KnownColor.Highlight)
        TextBoxExt1.FocusBorderColor = Color.FromKnownColor(KnownColor.Highlight)
        Dim str As String = dgvCompra.Table.CurrentRecord.GetValue("Numero") '.Replace("0", "")
        TextBoxExt1.Text = String.Concat(dgvCompra.Table.CurrentRecord.GetValue("TipoDoc"), ", ", dgvCompra.Table.CurrentRecord.GetValue("Serie"), "-", str)
        ObtenerPorDetails(dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
        loadNotas()
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

    Private Sub frmPagosModal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmPagosModal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label18.Text = "TOTAL EGRESOS " & AnioGeneral
        ' Me.WindowState = FormWindowState.Maximized

        toolTip = New Popup(ucInfoCompra)
        toolTip.AutoClose = False
        toolTip.FocusOnOpen = False
        toolTip.ShowingAnimation = PopupAnimations.Blend
        InfoCompra(Sys.Inicio)
        btnInfoCompra.Image = My.Resources.b_drop
        TextBoxExt1.Metrocolor = Color.Red
        TextBoxExt1.FocusBorderColor = Color.Red
        txtProveedor.Select()

        TabSplitterContainer1.Collapsed = True
        '  TabSplitterPage2
    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.popupControlContainer1.ParentControl = Me.txtProveedor
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
        End If
    
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub popupControlContainer1_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles popupControlContainer1.BeforePopup
        Me.popupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.ValueMember = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                '    txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
                btChequesPN.Text = ConteoChequesPendientes()
                btComprasPN.Text = ConteoComprasPendientes()

                UbicarCompraXPorveedorNroSerie(txtRuc.Text)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            If Me.txtProveedor.Text.Trim.Length > 0 Then
                TextBoxExt1.Select()
                TextBoxExt1.Focus()
            Else
                Me.txtProveedor.Focus()
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TextBoxExt1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt1.KeyDown
        'Me.Cursor = Cursors.WaitCursor
        'If e.KeyCode = Keys.Enter Then
        '    e.SuppressKeyPress = True
        '    If txtProveedor.Text.Trim.Length > 0 Then
        '        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        '        datos.Clear()
        '        e.SuppressKeyPress = True
        '        With frmNotaCreditoModal
        '            .RucProveedor = txtRuc.Text.Trim
        '            .StartPosition = FormStartPosition.CenterParent
        '            .ShowDialog()
        '            If datos.Count > 0 Then
        '                IDDocumentoCompra = datos(0).ID
        '                TipoCompra = datos(0).NomProceso
        '                Select Case TipoCompra
        '                    Case TIPO_COMPRA.COMPRA_AL_CREDITO
        '                        txTipoCompra.Text = "Compra al credito c/exist. trans."
        '                    Case TIPO_COMPRA.COMPRA_AL_CREDITO_CON_RECEPCION
        '                        txTipoCompra.Text = "Compra al credito c/recep. exist."
        '                    Case TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION
        '                        txTipoCompra.Text = "Compra al contado c/recep. exist."
        '                    Case TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
        '                        txTipoCompra.Text = "Compra al contado c/exist. trans."
        '                End Select

        '                MonedaCompra = datos(0).NomEvento
        '                btnInfoCompra.Image = My.Resources.b_docsql
        '                btnInfoCompra.Tag = "YES"
        '                TextBoxExt1.Metrocolor = Color.FromKnownColor(KnownColor.Highlight)
        '                TextBoxExt1.FocusBorderColor = Color.FromKnownColor(KnownColor.Highlight)
        '                Dim str As String = datos(0).Appat.Replace("0", "")
        '                TextBoxExt1.Text = String.Concat(datos(0).Cuenta, ", ", datos(0).Apmat, "-", str)
        '                ObtenerPorDetails(datos(0).ID)
        '                loadNotas()
        '            Else
        '                'lsvCanasta.Items.Clear()
        '                'dgvNuevoDoc.Rows.Clear()
        '                btnInfoCompra.Image = My.Resources.b_drop
        '                btnInfoCompra.Tag = "NO"
        '                TextBoxExt1.Metrocolor = Color.Red
        '                TextBoxExt1.FocusBorderColor = Color.Red
        '                TextBoxExt1.Text = String.Empty
        '            End If
        '        End With
        '    Else
        '        Label2.Text = "Debe seleccionar un proveedor para realizar esta operación!"
        '    End If
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TextBoxExt1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt1.TextChanged

    End Sub

    Private Sub PegarToolStripButton_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub

    Private Sub btnInfoCompra_Click(sender As Object, e As EventArgs) Handles btnInfoCompra.Click
        Me.Cursor = Cursors.WaitCursor
        If btnInfoCompra.Tag = "YES" Then
            InfoCompra(Sys.Proceso)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub

    Private Sub btnInfoCompra_MouseLeave(sender As Object, e As EventArgs) Handles btnInfoCompra.MouseLeave
        toolTip.Close()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor 
        ObtenerPorDetails(IDDocumentoCompra)
        loadNotas()

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click
        btnNuevoPago("EFECTIVO")
    End Sub

#Region "Metodos Auxiliares Grid"

    ''' <summary>
    ''' Permite obtener el valor de un columna especifica de la fila que está actualmente seleccionada
    ''' </summary>
    ''' <param name="Grid"></param>
    '''  <param name="ColumnId"></param>
    '''  <param name="RowIndex"></param>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Private Function GetCellValue(Grid As GridDataBoundGrid, ColumnId As String, RowIndex As Integer) As String
        Dim ColIndex As Integer = GetColIndexById(Grid, ColumnId)

        Dim CellText As String = Grid.Item(RowIndex, ColIndex).FormattedText
        Return CellText
    End Function



    ''' <summary>
    ''' Permite obtener el valor de un columna especifica de la fila que está actualmente seleccionada
    ''' </summary>
    ''' <param name="Grid"></param>
    '''  <param name="ColumnId"></param>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Private Function GetCellValue(Grid As GridDataBoundGrid, ColumnId As String) As String
        Dim ColIndex As Integer = GetColIndexById(Grid, ColumnId)
        Dim RowIndex As Integer = GetSelectedRow(Grid)

        Dim CellText As String = Grid.Item(RowIndex, ColIndex).FormattedText
        Return CellText
    End Function

    Private Function GetCellMemberValue(Grid As GridDataBoundGrid, ColumnId As String) As String
        Dim ColIndex As Integer = GetColIndexById(Grid, ColumnId)
        Dim RowIndex As Integer = GetSelectedRow(Grid)

        Dim CellText As String = Grid.Item(RowIndex, ColIndex).CellValue
        Return CellText
    End Function

    Private Sub SetCellMemberValue(Grid As GridDataBoundGrid, ColumnId As String, value As String)
        Dim ColIndex As Integer = GetColIndexById(Grid, ColumnId)
        Dim RowIndex As Integer = GetSelectedRow(Grid)

        Grid.Item(RowIndex, ColIndex).Text = value
        Grid.Item(RowIndex, ColIndex).CellValue = value


    End Sub

    ''' <summary>
    ''' Permite obtener el index de la fila que está actualmente seleccionada
    ''' </summary>
    ''' <param name="Grid"></param>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Private Function GetSelectedRow(Grid As GridDataBoundGrid) As Integer
        Dim SelectedRow = Grid.Selections.GetSelectedRows(True, False)
        Return Grid.Binder.CurrentRowIndex()
    End Function

    ''' <summary>
    ''' Permite obtener el index de la columna pasada por parametros
    ''' </summary>
    ''' <param name="Grid"></param>
    '''  <param name="ColumnId"></param>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Private Function GetColIndexById(Grid As GridDataBoundGrid, ColumnId As String) As Integer
        Dim ColIndex As Integer
        ColIndex = Grid.NameToColIndex(ColumnId)

        Return ColIndex
    End Function
#End Region

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Cursor = Cursors.WaitCursor
        If GDB.Model.RowCount > 0 Then
            'Select Case TipoCompra
            '    Case TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION, TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION

            Select Case GetCellValue(GDB, "Operacion")
                Case "NOTA DE CREDITO"
                    Select Case GetCellValue(GDB, "EstadoPago")
                        Case "Devoluvión procesada"

                        Case "Pendiente de entrega"
                            '   If CDec(txtImporteCompramn.Text) < 0 Then
                            btnNuevoPagoNotas(GetCellValue(GDB, "IdDocumento"), "NOTA DE CREDITO")
                            '   End If
                        Case "Proceso normal"

                    End Select

                Case "NOTA DE DEBITO"
                    Select Case GetCellValue(GDB, "EstadoPago")
                        Case "Devoluvión procesada"

                        Case "Pendiente de entrega"
                            '  If CDec(txtImporteCompramn.Text) > 0 Then
                            btnNuevoPagoNotas(GetCellValue(GDB, "IdDocumento"), "NOTA DE DEBITO")
                            '  End If
                        Case "Proceso normal"

                    End Select


            End Select

            '  End Select
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ListaDeChequesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        If txtProveedor.ValueMember.Trim.Length > 0 Then
            With frmChequesXentidad
                .cust.IdProveedor = txtProveedor.ValueMember
                .cust.NombreProveedor = txtProveedor.Text
                .ListaChequesPeriodo()
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ActualizarToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If txtProveedor.ValueMember.Trim.Length > 0 Then
            btChequesPN.Text = ConteoChequesPendientes()
        End If
    End Sub

    Private Sub btnInfoComprasPendientes_Click(sender As Object, e As EventArgs)
        If txtProveedor.ValueMember.Trim.Length > 0 Then
            btComprasPN.Text = ConteoComprasPendientes()
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.Cursor = Cursors.WaitCursor
        If txtProveedor.ValueMember.Trim.Length > 0 Then
            With frmHistorial
                .IdDocumentoCompra = IDDocumentoCompra
                .HistorialCompra(IDDocumentoCompra)
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub DevoluciónExistenciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevoluciónExistenciaToolStripMenuItem.Click
        Dim i1 As Integer = Me.dgvDoc.Table.SelectedRecords.Count
        MessageBox.Show(i1.ToString())
    End Sub

    Private Sub ListaDeChuequesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListaDeChuequesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If txtProveedor.ValueMember.Trim.Length > 0 Then
            With frmChequesXentidad
                .cust.IdProveedor = txtProveedor.ValueMember
                .cust.NombreProveedor = txtProveedor.Text
                .ListaChequesPeriodo()
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ActualizarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ActualizarToolStripMenuItem1.Click
        If txtProveedor.ValueMember.Trim.Length > 0 Then
            btChequesPN.Text = ConteoChequesPendientes()
        End If
    End Sub

    Private Sub btDelete_Click(sender As Object, e As EventArgs) Handles btDelete.Click

        If IsNothing(GFichaUsuarios) Then
            Label2.Text = "Debe asignar una caja válida!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Else
            btnNuevoPago("EFECTIVO")
        End If

    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Me.Cursor = Cursors.WaitCursor
        If txtProveedor.ValueMember.Trim.Length > 0 Then
            With frmHistorial
                .IdDocumentoCompra = IDDocumentoCompra
                .LoadHistorialCajasXcompra()
                ' .HistorialCompra(IDDocumentoCompra)
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub btComprasPN_Click(sender As Object, e As EventArgs) Handles btComprasPN.Click

    End Sub

    Private Sub btChequesPN_Click(sender As Object, e As EventArgs) Handles btChequesPN.Click

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Cursor = Cursors.WaitCursor
        UbicarCompraXPorveedorNroSerie(txtRuc.Text)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvCompra.TableControlCurrentCellControlDoubleClick
        Me.Cursor = Cursors.WaitCursor
        LoadDetalles()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick

    End Sub
End Class