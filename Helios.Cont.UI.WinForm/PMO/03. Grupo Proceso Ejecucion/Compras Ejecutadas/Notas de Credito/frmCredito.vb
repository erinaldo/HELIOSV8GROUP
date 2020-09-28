Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid

Public Class frmCredito
    Inherits frmMaster

    Public Property IdCompraOrigen() As Integer
    Public Property Moneda() As String
    Public Property IdProveedor() As Integer
    Public Property NomProveedor() As String
    Public Property CuentaProveedor() As String
    Public Property strTipoNota() As String = Nothing
    Public Property ManipulacionEstado() As String

    Public Property ListaAsientonTransito As New List(Of asiento)

    Public Property TipoCompra() As String
    Public Property IdUsuarioCaja() As String

    Dim toolTip As Popup
    Dim ucInfoCompra As New ucInfoCompra
    Public fecha As DateTime
    Dim tablaSA As New tablaDetalleSA
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GConfiguracion = New GConfiguracionModulo
        '  configuracionModulo(Gempresas.IdEmpresaRuc, "C2", Me.Text)
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        '   dockingManager1.DockControlInAutoHideMode(PanelDetalleCompra, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 680)
        dockingManager1.DockControl(PanelGlosa, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 70)
        dockingManager1.SetDockLabel(PanelGlosa, "Glosa")
        dockingClientPanel1.BringToFront()
        dockingManager1.MDIActivatedVisibility = True
        Me.dockingClientPanel1.AutoScroll = True
        Me.dockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        '  dockingManager1.SetDockLabel(PanelDetalleCompra, "Canasta de compras")
        'INICIO PERIODO
        txtPeriodo.Text = PeriodoGeneral  'String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & txtPeriodo.text
        txtGlosa.Text = (String.Concat("Por nota de credito", vbCrLf, "según/ ", Space(1), "documento", Space(1), "Nro.", Space(1), txtSerie.Text, "-", txtNumero.Text, vbCrLf, "fecha: ", fecha))
        dockingManager1.DockControlInAutoHideMode(Panel3, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
        dockingManager1.SetDockLabel(Panel3, "Existencias")
        dockingManager1.SetDockVisibility(Panel3, False)
        dockingManager1.CloseEnabled = False

        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")

        txtFechaComprobante.Select()
    End Sub

#Region "Variables DetalleCompra"
    Public Property nudBase4 As Decimal = 0
    Public Property nudBase1 As Decimal = 0
    Public Property nudBase2 As Decimal = 0
    Public Property nudBase3 As Decimal = 0

    Public Property nudMontoIgv1 As Decimal = 0
    Public Property nudMontoIgv2 As Decimal = 0
    Public Property nudMontoIgv3 As Decimal = 0

    Public Property nudBaseus4 As Decimal = 0
    Public Property nudBaseus1 As Decimal = 0
    Public Property nudBaseus2 As Decimal = 0
    Public Property nudBaseus3 As Decimal = 0

    Public Property nudMontoIgvus1 As Decimal = 0
    Public Property nudMontoIgvus2 As Decimal = 0
    Public Property nudMontoIgvus3 As Decimal = 0

    Public Property nudIsc1 As Decimal = 0
    Public Property nudIsc2 As Decimal = 0
    Public Property nudIsc3 As Decimal = 0
    Public Property nudIscus1 As Decimal = 0
    Public Property nudIscus2 As Decimal = 0
    Public Property nudIscus3 As Decimal = 0

    Public Property nudOtrosTributosus1 As Decimal = 0
    Public Property nudOtrosTributosus2 As Decimal = 0
    Public Property nudOtrosTributosus3 As Decimal = 0
    Public Property nudOtrosTributosus4 As Decimal = 0

    Public Property nudOtrosTributos1 As Decimal = 0
    Public Property nudOtrosTributos2 As Decimal = 0
    Public Property nudOtrosTributos3 As Decimal = 0
    Public Property nudOtrosTributos4 As Decimal = 0

    Public Property txtIdComprobanteCaja As Integer
    Public Property txtComprobanteCaja As String
    Public Property txtNumCaja As String
    Public Property txtIdEstablecimientoCaja As Integer
    Public Property txtEstablecimientoCaja As String
    Public Property txtIdCaja As Integer
    Public Property txtCaja As String
    Public Property txtCuentaEF As String

    '   Public Property GlosaCompra As String = Nothing
#End Region

#Region "Métodos"

    Public Sub CargarCajas(strBusqueda As String)
        Dim estadoSA As New EstadosFinancierosSA
        Try
            Me.lstEntidades.DataSource = estadoSA.ObtenerEstadosFinancierosPorMonedaXdescripcion(GEstableciento.IdEstablecimiento, Nothing, strBusqueda)
            Me.lstEntidades.DisplayMember = "descripcion"
            Me.lstEntidades.ValueMember = "idestado"
        Catch ex As Exception

        End Try
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


    'Private Function GlosaNotas() As String
    '    If Not String.IsNullOrEmpty(txtSerie.Text) And Not String.IsNullOrEmpty(txtNumero.Text) And _
    '    Not String.IsNullOrEmpty(NomProveedor) Then
    '        Return String.Concat("Por devolución de existencias", vbCrLf, "según/ ", Space(1), "NOTA DE CREDITO", Space(1), "Nro.", Space(1), txtSerie.Text, "-", txtNumero.Text, vbCrLf, "fecha: ", fecha)
    '    Else
    '        Return False
    '    End If
    'End Function

    Private Sub Validar_Numeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim Celda As DataGridViewCell = Me.dgvNuevoDoc.CurrentCell()

        If Celda.ColumnIndex = 7 Or Celda.ColumnIndex = 8 Or Celda.ColumnIndex = 11 Then

            If e.KeyChar = "."c Or e.KeyChar = ","c Then

                If InStr(Celda.EditedFormattedValue.ToString, ".", CompareMethod.Text) > 0 Then

                    e.Handled = True
                Else

                    e.Handled = False
                End If
            Else

                If Len(Trim(Celda.EditedFormattedValue.ToString)) > 0 Then

                    If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then

                        e.Handled = False
                    Else

                        e.Handled = True
                    End If
                Else

                    If e.KeyChar = "0"c Then

                        e.Handled = True
                    Else

                        If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then

                            e.Handled = False
                        Else

                            e.Handled = True
                        End If
                    End If
                End If
            End If
        End If
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

        If IdCompraOrigen > 0 Then

            With documentocompraSA.UbicarDocumentoCompra(IdCompraOrigen)
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

                If .estadoPago = TIPO_COMPRA.PAGO.PAGADO Then
                    ucInfoCompra.rbDocPagado.Checked = True

                    With objDocCaja.UbicarDocumento(documentoCajaDetalleSA.RecuperarIDCompra(IdCompraOrigen))
                        With documentoCajaSA.GetUbicar_documentoCajaPorID(documentoCajaDetalleSA.RecuperarIDCompra(IdCompraOrigen))
                            txtIdCaja = .entidadFinanciera
                            With estadoF.GetUbicar_estadosFinancierosPorID(.entidadFinanciera)
                                txtCaja = .descripcion
                                txtCuentaEF = .cuenta
                            End With
                        End With
                    End With
                Else
                    ucInfoCompra.rbTramite.Checked = True
                End If

            End With
        End If

        ' position the tooltip with its stem towards the right end of the button
        If n = Sys.Inicio Then

        ElseIf n = Sys.Proceso Then
            toolTip.Show(btnInfoCompra)
        End If


    End Sub

    Private Function ExisteDatoEnGrid(intIdItem As String) As Boolean
        For Each row As DataGridViewRow In dgvNuevoDoc.Rows
            If System.Convert.ToString(row.Cells(2).Value) = intIdItem Then
                lblEstado.Text = ("El item ya se encuentra en la canasta, ingrese otro!")
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function

    Public Sub UbicarDetalle(intIddocumento As Integer)
        Dim detalleSA As New DocumentoCompraDetalleSA
        Dim objLista As New DocumentoCajaDetalleSA
        Dim detalle As New documentocompradetalle
        Dim compraSA As New DocumentoCompraSA
        Dim entidadSA As New entidadSA
        Dim dt As New DataTable

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0

        Dim cCantidadNC As Decimal = 0
        Dim cCantidadDB As Decimal = 0
        Dim cTotalCantidad As Decimal = 0
        Try
            With compraSA.UbicarDocumentoCompra(intIddocumento)
                IdCompraOrigen = .idDocumento
                Moneda = .monedaDoc
                With entidadSA.UbicarEntidadPorID(.idProveedor).First
                    IdProveedor = .idEntidad
                    NomProveedor = .nombreCompleto
                    CuentaProveedor = .cuentaAsiento
                End With
                TipoCompra = .tipoCompra
                txtTipoCambio.Value = .tcDolLoc
                txtTipoCambio.ReadOnly = True
                txtIgv.Value = .tasaIgv

                IdUsuarioCaja = .usuarioActualizacion
                TipoCompra = .tipoCompra
                IdCompraOrigen = .idDocumento
                Moneda = .monedaDoc
            End With

            Dim saldomn As Decimal = 0
            Dim saldome As Decimal = 0

            dt.Columns.Add("sec", GetType(Integer))
            dt.Columns.Add("grav", GetType(String))
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("item", GetType(String))
            dt.Columns.Add("cantidad", GetType(Decimal))
            dt.Columns.Add("precMN", GetType(Decimal))
            dt.Columns.Add("importeMN", GetType(Decimal))
            dt.Columns.Add("precME", GetType(Decimal))
            dt.Columns.Add("importeME", GetType(Decimal))
            dt.Columns.Add("tipoEx", GetType(String))
            dt.Columns.Add("almacenRef", GetType(Integer))

            dt.Columns.Add("cantCompra", GetType(Decimal))
            dt.Columns.Add("compraMN", GetType(Decimal))
            dt.Columns.Add("compraME", GetType(Decimal))
            dt.Columns.Add("montokardex", GetType(Decimal))
            dt.Columns.Add("montokardexus", GetType(Decimal))
            dt.Columns.Add("montoIgv", GetType(Decimal))
            dt.Columns.Add("montoIgvUS", GetType(Decimal))
            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(intIddocumento)
                detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)
                Select Case i.EstadoCobro
                    Case TIPO_COMPRA.PAGO.PAGADO
                        cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe ' + detalle.ImporteDBMN
                        cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS '+ detalle.ImporteDBME
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe + detalle.ImporteDBMN - CDec(i.MontoPagadoSoles)
                        'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS + detalle.ImporteDBME - CDec(i.MontoPagadoUSD)
                        cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles)
                        cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD)
                End Select


                saldomn += cTotalmn
                saldome += cTotalme

                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.secuencia
                dr(1) = i.destino
                dr(2) = i.idItem
                dr(3) = i.DetalleItem
                Select Case i.TipoExistencia
                    Case "GS"
                        dr(4) = 0
                    Case Else
                        If IsNothing(detalle) Then
                            dr(4) = 0
                        Else
                            dr(4) = i.CantidadCompra - detalle.monto1  ' detalle.monto1
                        End If
                End Select
                dr(5) = 0
                If cTotalmn < 0 Then
                    cTotalmn = 0
                End If
                dr(6) = cTotalmn
                dr(7) = 0
                If cTotalme < 0 Then
                    cTotalme = 0
                End If
                dr(8) = cTotalme
                dr(9) = i.TipoExistencia
                dr(10) = i.almacenRef

                dr(11) = i.CantidadCompra
                dr(12) = i.MontoDeudaSoles
                dr(13) = i.MontoDeudaUSD
                dr(14) = i.montokardex
                dr(15) = i.montokardexus
                dr(16) = i.montoIgv
                dr(17) = i.montoIgvUS
                dt.Rows.Add(dr)
            Next
            dgvMov.DataSource = dt
            dgvMov.TableModel.RowHeights.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells)
            Me.dgvMov.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
            'For Each i As documentocompradetalle In detalleSA.UbicarDocumentoCompraDetalle(intIddocumento)

            '    Dim n As New ListViewItem(i.secuencia)
            '    n.SubItems.Add(i.idItem)
            '    n.SubItems.Add(i.descripcionItem)
            '    n.SubItems.Add(i.unidad1)
            '    n.SubItems.Add(i.unidad2)
            '    n.SubItems.Add(i.monto1)
            '    n.SubItems.Add(i.importe)
            '    n.SubItems.Add(i.importeUS)
            '    If IsNothing(i.almacenRef) Then
            '        n.SubItems.Add("Sin asignar")
            '    Else
            '        n.SubItems.Add(i.almacenRef)
            '    End If
            '    n.SubItems.Add(i.preEvento)
            '    n.SubItems.Add(i.tipoExistencia)
            '    '-------------------------------------------------------------------

            '    detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)

            '    If IsNothing(detalle) Then
            '        n.SubItems.Add(0)
            '        cCreditomn = 0
            '    Else
            '        n.SubItems.Add(detalle.importe)
            '        cCreditomn = detalle.importe
            '    End If

            '    If IsNothing(detalle) Then
            '        n.SubItems.Add(0)
            '        cCreditome = 0
            '    Else
            '        n.SubItems.Add(detalle.importeUS)
            '        cCreditome = detalle.importeUS
            '    End If

            '    If IsNothing(detalle) Then
            '        n.SubItems.Add(0)
            '        cDebitomn = 0
            '    Else
            '        n.SubItems.Add(detalle.ImporteDBMN)
            '        cDebitomn = detalle.ImporteDBMN
            '    End If

            '    If IsNothing(detalle) Then
            '        n.SubItems.Add(0)
            '        cDebitome = 0
            '    Else
            '        n.SubItems.Add(detalle.ImporteDBME)
            '        cDebitome = detalle.ImporteDBME
            '    End If
            '    cTotalmn = Math.Round(CDec(i.importe) - cCreditomn + cDebitomn, 2)
            '    cTotalme = Math.Round(CDec(i.importeUS) - cCreditome + cDebitome, 2)
            '    n.SubItems.Add(cTotalmn)
            '    n.SubItems.Add(cTotalme)

            '    Select Case i.tipoExistencia
            '        Case "GS"
            '            cCantidadNC = 0
            '        Case Else
            '            If IsNothing(detalle) Then
            '                n.SubItems.Add(0)
            '                cCantidadNC = 0
            '            Else
            '                n.SubItems.Add(detalle.monto1)
            '                cCantidadNC = detalle.monto1
            '            End If
            '    End Select



            '    If IsNothing(i.cantidadDebito) Then
            '        n.SubItems.Add(0)
            '        cCantidadDB = 0
            '    Else
            '        n.SubItems.Add(i.cantidadDebito)
            '        cCantidadDB = i.cantidadDebito
            '    End If
            '    cTotalCantidad = Math.Round(CDec(i.monto1) - cCantidadNC + cCantidadDB, 2)
            '    n.SubItems.Add(cTotalCantidad)
            '    n.SubItems.Add(i.destino)
            '    lsvCanasta.Items.Add(n)
            'Next
        Catch ex As Exception

        End Try
    End Sub


#End Region

#Region "METODOS DGV"
    Public Sub TotalesCabeceras()
        Dim colSaldoMN As Decimal = 0
        Dim colSaldoME As Decimal = 0
        Dim cTotalMN As Decimal = 0
        Dim cTotalME As Decimal = 0

        Dim cTotalBI As Decimal = 0
        Dim cTotalBI_ME As Decimal = 0

        Dim cTotalIGV As Decimal = 0
        Dim cTotalIGV_ME As Decimal = 0

        Dim cTotalIsc As Decimal = 0
        Dim cTotalIsc_ME As Decimal = 0

        Dim cTotalOTC As Decimal = 0
        Dim cTotalOTC_ME As Decimal = 0
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If i.Cells(27).Value <> "S" Then
                cTotalMN += CDec(i.Cells(10).Value)
                cTotalME += CDec(i.Cells(13).Value)

                cTotalBI += CDec(i.Cells(8).Value)
                cTotalBI_ME += CDec(i.Cells(11).Value)

                cTotalIGV += CDec(i.Cells(15).Value)
                cTotalIGV_ME += CDec(i.Cells(18).Value)

                'cTotalIsc += CDec(i.Cells(13).Value)
                'cTotalIsc_ME += CDec(i.Cells(17).Value)

                'cTotalOTC += CDec(i.Cells(15).Value)
                'cTotalOTC_ME += CDec(i.Cells(19).Value)

                colSaldoMN += CDec(i.Cells(37).Value)
                colSaldoME += CDec(i.Cells(38).Value)
            End If
        Next

        lblTotalBase.Text = cTotalBI.ToString("N2")
        lblTotalBaseUS.Text = cTotalBI_ME.ToString("N2")

        lblTotalISc.Text = 0 ' cTotalIsc.ToString("N2")
        lblTotalIScUS.Text = 0 ' cTotalIsc_ME.ToString("N2")

        lblTotalMontoIgv.Text = cTotalIGV.ToString("N2")
        lblTotalMontoIgvUS.Text = cTotalIGV_ME.ToString("N2")

        lblOtrostribTotal.Text = 0 ' cTotalOTC.ToString("N2")
        lblOtrostribTotalUS.Text = 0 ' cTotalOTC_ME.ToString("N2")

        lblBonificaMN.Text = colSaldoMN.ToString("N2")
        lblBonificaME.Text = colSaldoME.ToString("N2")

        Select Case txtIdComprobanteNota.Text
            Case "02", "03"
                lblTotalAdquisiones.Text = cTotalMN   'cTotalMN.ToString("N2")
                lblTotalUS.Text = cTotalME   'cTotalME.ToString("N2")
            Case "08"
                'Instrucciones
            Case Else

                lblTotalAdquisiones.Text = cTotalBI + cTotalIGV   'cTotalMN.ToString("N2")
                lblTotalUS.Text = cTotalBI_ME + cTotalIGV_ME  'cTotalME.ToString("N2")
        End Select

    End Sub

    Public Sub totales_xx()
        '     Dim objService = HeliosSEProxy.CrearProxyHELIOS
        ' Dim t As DataTable
        Dim i As Integer
        'Dim base1, base2 As Decimal
        'Dim baseus1, baseus2 As Decimal
        'Dim otc1, otc2 As Decimal ', otc3, otc4
        'Dim otc1US, otc2US As Decimal ', otc3US, otc4US
        Dim total, totalbase2 As Decimal ' igv, IGVUS As Decimal ' totalp As Decimal , totalbase3, totalbase4,
        Dim tus1, tus2 As Decimal 'tus3, tus4 
        Dim totalIgv1 As Decimal = 0
        Dim totalIgv1_ME As Decimal = 0
        Dim totalIgv2 As Decimal = 0
        Dim totalIgv2_ME As Decimal = 0
        Dim totalIgv3 As Decimal = 0
        Dim totalIgv3_ME As Decimal = 0
        Dim totalIgv4 As Decimal = 0
        Dim totalIgv4_ME As Decimal = 0

        Dim totalBI3 As Decimal = 0
        Dim totalBI3_ME As Decimal = 0
        Dim totalBI4 As Decimal = 0
        Dim totalBI4_ME As Decimal = 0


        Dim NUDVALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
        For i = 0 To dgvNuevoDoc.Rows.Count - 1
            'total += carrito.Rows(i)(5)
            If Not dgvNuevoDoc.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(209, 227, 254) Then
                If dgvNuevoDoc.Rows(i).Cells(1).Value() = "1" Then

                    total += dgvNuevoDoc.Rows(i).Cells(8).Value() ' total base 01 soles
                    tus1 += dgvNuevoDoc.Rows(i).Cells(11).Value() ' total base 01 dolares
                    totalIgv1 += dgvNuevoDoc.Rows(i).Cells(15).Value()
                    totalIgv1_ME += dgvNuevoDoc.Rows(i).Cells(18).Value()

                ElseIf dgvNuevoDoc.Rows(i).Cells(1).Value() = "2" Then

                    totalbase2 += dgvNuevoDoc.Rows(i).Cells(8).Value()
                    tus2 += dgvNuevoDoc.Rows(i).Cells(11).Value() ' total base 01
                    totalIgv2 += dgvNuevoDoc.Rows(i).Cells(15).Value()
                    totalIgv2_ME += dgvNuevoDoc.Rows(i).Cells(18).Value()

                ElseIf dgvNuevoDoc.Rows(i).Cells(1).Value() = "3" Then
                    totalBI3 += dgvNuevoDoc.Rows(i).Cells(8).Value()
                    totalBI3_ME += dgvNuevoDoc.Rows(i).Cells(11).Value() ' total base 01
                    totalIgv3 += dgvNuevoDoc.Rows(i).Cells(15).Value()
                    totalIgv3_ME += dgvNuevoDoc.Rows(i).Cells(18).Value()

                ElseIf dgvNuevoDoc.Rows(i).Cells(1).Value() = "4" Then
                    totalBI4 += dgvNuevoDoc.Rows(i).Cells(8).Value()
                    totalBI4_ME += dgvNuevoDoc.Rows(i).Cells(11).Value() ' total base 01
                    totalIgv4 += dgvNuevoDoc.Rows(i).Cells(15).Value()
                    totalIgv4_ME += dgvNuevoDoc.Rows(i).Cells(18).Value()
                End If
            End If
        Next
        nudBase1 = total.ToString("N2")
        nudBaseus1 = tus1.ToString("N2")
        nudBase2 = totalbase2.ToString("N2")
        nudBaseus2 = tus2.ToString("N2")

        nudBase3 = totalBI3.ToString("N2")
        nudBaseus3 = totalBI3_ME.ToString("N2")
        nudBase4 = totalBI4.ToString("N2")
        nudBaseus4 = totalBI4_ME.ToString("N2")

        nudMontoIgv1 = totalIgv1.ToString("N2")
        nudMontoIgvus1 = totalIgv1_ME.ToString("N2")
        nudMontoIgv2 = totalIgv2.ToString("N2")
        nudMontoIgvus2 = totalIgv2_ME.ToString("N2")

        nudMontoIgv3 = totalIgv3.ToString("N2")
        nudMontoIgvus3 = totalIgv3_ME.ToString("N2")
        nudMontoIgv3 = totalIgv3.ToString("N2")
        nudMontoIgvus3 = totalIgv3_ME.ToString("N2")





    End Sub

    Private Sub CellEndEditRefresh()
        '**************************************************************
        If dgvNuevoDoc.Rows.Count > 0 Then
            'DECLARANDO VARIABLES

            For Each i As DataGridViewRow In dgvNuevoDoc.Rows

                Dim colDestinoGravado As String = 0
                colDestinoGravado = i.Cells(1).Value

                Dim colCantidad As Decimal = CDec(i.Cells(7).Value)


                Dim colBI As Decimal = i.Cells(8).Value
                Dim colBI_ME As Decimal = i.Cells(11).Value
                Dim colIGV_ME As Decimal = 0
                Dim colIGV As Decimal = 0
                Dim colMN As Decimal = 0
                Dim colME As Decimal = 0
                Dim colPrecUnit As Decimal = 0
                Dim colPrecUnitUSD As Decimal = 0


                If colBI > 0 Then

                    colIGV = Math.Round(colBI * 0.18, 2) 'Math.Round((colMN / 1.18) * 0.18, 2)
                    colIGV_ME = Math.Round(colBI_ME * 0.18, 2) ' Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)

                    colMN = colBI + colIGV
                    colME = colBI_ME + colIGV_ME

                    colPrecUnit = Math.Round(colMN / colCantidad, 2)
                    colPrecUnitUSD = Math.Round(colME / colCantidad, 2)

                ElseIf colCantidad = 0 Then
                    colIGV = Math.Round(colBI * 0.18, 2) 'Math.Round((colMN / 1.18) * 0.18, 2)
                    colIGV_ME = Math.Round(colBI_ME * 0.18, 2) ' Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)

                    colMN = colBI + colIGV
                    colME = colBI_ME + colIGV_ME

                    colPrecUnit = 0
                    colPrecUnitUSD = 0
                Else
                    colPrecUnit = 0
                    colPrecUnitUSD = 0
                    colBI = 0
                    colBI_ME = 0
                    colIGV = 0
                    colIGV_ME = 0
                End If
                Select Case txtIdComprobanteNota.Text ' cboTipoDoc.SelectedValue
                    Case "08"

                    Case "03", "02"

                        If txtTipoCambio.Value = 0.0 Then
                            MsgBox("Ingrese Tipo de Cambio..!")
                            txtTipoCambio.Focus()
                            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                            Exit Sub
                        End If
                        Dim NUDIGV_VALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
                        If colCantidad = 0 And colMN = 0 And colME = 0 Then
                            i.Cells(9).Value() = "0.00"
                            i.Cells(12).Value() = "0.00"
                            Exit Sub
                        Else 'If colCantidad = 0 Then

                            If Moneda = 1 Then
                                ' DATOS SOLES
                                Select Case colDestinoGravado
                                    Case "4"
                                        '      i.Cells(9).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                        i.Cells(13).Value() = colBI_ME  ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2")  ' MONTO TOTAL DOLARES
                                        i.Cells(10).Value() = colBI
                                        'i.Cells(9).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)

                                        'i.Cells(12).Value() = "0.00"
                                        'i.Cells(13).Value() = "0.00"
                                        'i.Cells(14).Value() = "0.00"
                                        'i.Cells(15).Value() = "0.00"
                                        'i.Cells(16).Value() = "0.00"
                                        'i.Cells(17).Value() = "0.00"
                                        'i.Cells(18).Value() = "0.00"
                                        'i.Cells(19).Value() = "0.00"
                                    Case Else
                                        'i.Cells(8).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                        i.Cells(13).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        i.Cells(10).Value = colMN
                                        'i.Cells(9).Value = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
                                        'i.Cells(12).Value() = "0.00"
                                        'i.Cells(13).Value() = "0.00"
                                        'i.Cells(14).Value() = "0.00"
                                        'i.Cells(15).Value() = "0.00"
                                        'i.Cells(16).Value() = "0.00"
                                        'i.Cells(17).Value() = "0.00"
                                        'i.Cells(18).Value() = "0.00"
                                        'i.Cells(19).Value() = "0.00"
                                End Select

                            ElseIf Moneda = 2 Then
                                ' DATOS DOLARES
                                Select Case colDestinoGravado
                                    Case "4"
                                        'i.Cells(9).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                        'i.Cells(8).Value() = "0.00" 'Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 2)
                                        i.Cells(10).Value() = colBI
                                        i.Cells(13).Value() = colBI_ME
                                        'i.Cells(12).Value() = "0.00"
                                        'i.Cells(13).Value() = "0.00"
                                        'i.Cells(14).Value() = "0.00"
                                        'i.Cells(15).Value() = "0.00"
                                        'i.Cells(16).Value() = "0.00"
                                        'i.Cells(17).Value() = "0.00"
                                        'i.Cells(18).Value() = "0.00"
                                        'i.Cells(19).Value() = "0.00"
                                    Case Else
                                        'i.Cells(9).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                        i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        i.Cells(13).Value() = colME ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        'i.Cells(8).Value() = "0.00" 'Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 2)
                                        'i.Cells(12).Value() = "0.00"
                                        'i.Cells(13).Value() = "0.00"
                                        'i.Cells(14).Value() = "0.00"
                                        'i.Cells(15).Value() = "0.00"
                                        'i.Cells(16).Value() = "0.00"
                                        'i.Cells(17).Value() = "0.00"
                                        'i.Cells(18).Value() = "0.00"
                                        'i.Cells(19).Value() = "0.00"
                                End Select

                                '      End If
                            ElseIf colCantidad > 0 Then
                                If Moneda = 1 Then
                                    ' DATOS SOLES
                                    If i.Cells(1).Value = "4" Then
                                        i.Cells(7).Value() = colCantidad
                                        i.Cells(9).Value() = colPrecUnit ' Math.Round(CDec(neto / colCantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                        i.Cells(12).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / colCantidad), NumDigitos).ToString("N2")
                                        i.Cells(13).Value() = colBI_ME  ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        i.Cells(10).Value() = colBI 'CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")

                                        'i.Cells(12).Value() = "0.00"
                                        'i.Cells(13).Value() = "0.00"
                                        'i.Cells(14).Value() = "0.00"
                                        'i.Cells(15).Value() = "0.00"
                                        'i.Cells(16).Value() = "0.00"
                                        'i.Cells(17).Value() = "0.00"
                                        'i.Cells(18).Value() = "0.00"
                                        'i.Cells(19).Value() = "0.00"
                                    Else
                                        i.Cells(7).Value() = colCantidad 'CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        i.Cells(9).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                        i.Cells(12).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        i.Cells(13).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")


                                        'i.Cells(12).Value() = "0.00"
                                        'i.Cells(13).Value() = "0.00"
                                        'i.Cells(14).Value() = "0.00"
                                        'i.Cells(15).Value() = "0.00"
                                        'i.Cells(16).Value() = "0.00"
                                        'i.Cells(17).Value() = "0.00"
                                        'i.Cells(18).Value() = "0.00"
                                        'i.Cells(19).Value() = "0.00"
                                    End If

                                ElseIf Moneda = 2 Then

                                    Select Case colDestinoGravado
                                        Case "4"
                                            ' DATOS DOLARES

                                            i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            i.Cells(9).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            i.Cells(12).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                            i.Cells(10).Value() = colBI  ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            i.Cells(13).Value() = colBI_ME  ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")


                                            'i.Cells(12).Value() = "0.00"
                                            'i.Cells(13).Value() = "0.00"
                                            'i.Cells(14).Value() = "0.00"
                                            'i.Cells(15).Value() = "0.00"
                                            'i.Cells(16).Value() = "0.00"
                                            'i.Cells(17).Value() = "0.00"
                                            'i.Cells(18).Value() = "0.00"
                                            'i.Cells(19).Value() = "0.00"
                                        Case Else
                                            ' DATOS DOLARES
                                            i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            i.Cells(9).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            i.Cells(12).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                            i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            i.Cells(13).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")


                                            'i.Cells(12).Value() = "0.00"
                                            'i.Cells(13).Value() = "0.00"
                                            'i.Cells(14).Value() = "0.00"
                                            'i.Cells(15).Value() = "0.00"
                                            'i.Cells(16).Value() = "0.00"
                                            'i.Cells(17).Value() = "0.00"
                                            'i.Cells(18).Value() = "0.00"
                                            'i.Cells(19).Value() = "0.00"
                                    End Select

                                End If
                            End If
                            totales_xx()
                            TotalesCabeceras()

                        End If

                        '**********************************************************************************************************************************************************************************
                    Case Else
                        '       If dgvDetalleCompra.Columns(e.ColumnIndex).Name = "montoSolessc" Then
                        If txtTipoCambio.Value = 0.0 Then
                            MsgBox("Ingrese Tipo de Cambio..!")
                            txtTipoCambio.Focus()
                            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                            Exit Sub
                        End If

                        Dim NUDIGV_VALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
                        If colCantidad = 0 And colMN = 0 And colME = 0 Then
                            i.Cells(9).Value() = "0.00"
                            i.Cells(12).Value() = "0.00"
                            Exit Sub

                        ElseIf colCantidad = 0 Then

                            If Moneda = 1 Then
                                ' DATOS SOLES
                                Select Case colDestinoGravado
                                    Case "4"
                                        'i.Cells(9).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                        'i.Cells(12).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
                                        i.Cells(13).Value() = colBI_ME  ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES
                                        i.Cells(10).Value() = colBI ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES

                                    Case Else

                                        ''   If dgvDetalleCompra.Item(27, dgvDetalleCompra.CurrentRow.Index).Value() = "S" Then
                                        'dgvDetalleCompra.Item(8, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                        'dgvDetalleCompra.Item(9, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
                                        'dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() = colMN ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        'dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        'dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                        'dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto igv del item
                                        'dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex USD
                                        'dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV USD
                                        'dgvDetalleCompra.Item(19, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                                        'Else
                                        'i.Cells(8).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                        'i.Cells(9).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
                                        i.Cells(10).Value() = colMN ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        i.Cells(13).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        i.Cells(8).Value() = colBI ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                        i.Cells(15).Value() = colIGV  ' Math.Round(CDec(neto - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                        i.Cells(11).Value() = colBI_ME ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                        i.Cells(18).Value() = colIGV_ME ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                        'i.Cells(19).Value() = Math.Round(CDec(i.Cells(15).Value() / txtTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES
                                        '   End If
                                End Select

                            ElseIf Moneda = 2 Then
                                ' DATOS DOLARES
                                Select Case colDestinoGravado
                                    Case "4"
                                        'i.Cells(9).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                        'i.Cells(8).Value() = "0.00" 'Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 2)
                                        i.Cells(10).Value() = colBI  ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        i.Cells(13).Value() = colBI_ME

                                        ' dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                        ' dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' igv del item

                                        '  dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                        '  dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV

                                        '  dgvDetalleCompra.Item(15, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(19, dgvDetalleCompra.CurrentRow.Index).Value() * nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS SOLES
                                    Case Else

                                        'If dgvDetalleCompra.Item(27, dgvDetalleCompra.CurrentRow.Index).Value() = "S" Then
                                        '    dgvDetalleCompra.Item(9, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                        '    dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() = colMN 'Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        '    dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() = colME

                                        '    dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                        '    dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' igv del item

                                        '    dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                        '    dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV
                                        '    dgvDetalleCompra.Item(8, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 2)
                                        '    dgvDetalleCompra.Item(15, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS SOLES
                                        'Else
                                        'i.Cells(8).Value() = "0.00"
                                        'i.Cells(9).Value() = "0.00"
                                        i.Cells(10).Value() = colMN
                                        i.Cells(13).Value() = colME

                                        i.Cells(8).Value() = colBI ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                        i.Cells(15).Value() = colIGV ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' igv del item

                                        i.Cells(11).Value() = colBI_ME ' Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                        i.Cells(18).Value() = colIGV_ME ' Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV

                                        'i.Cells(15).Value() = Math.Round(CDec(i.Cells(19).Value() * txtTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS SOLES
                                        'End If
                                End Select

                            End If
                        ElseIf colCantidad > 0 Then
                            If Moneda = 1 Then
                                ' DATOS SOLES
                                If colDestinoGravado = "4" Then
                                    i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                    i.Cells(9).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                    i.Cells(12).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                    i.Cells(13).Value() = colBI_ME  ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    i.Cells(10).Value() = colBI ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                    '  dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                    '  dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(neto - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' monto igv del item

                                    ' dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex USD
                                    ' dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV USD


                                    'dgvDetalleCompra.Item(19, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(15, dgvDetalleCompra.CurrentRow.Index).Value() / nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS DOLARES
                                Else
                                    If i.Cells(27).Value() = "S" Then
                                        i.Cells(7).Value() = colCantidad '  CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        i.Cells(9).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                        i.Cells(12).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        i.Cells(13).Value() = colBI_ME  ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        i.Cells(10).Value() = colBI ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                        i.Cells(8).Value() = "0.00" ' monto para el kardex
                                        i.Cells(15).Value() = "0.00" ' monto igv del item

                                        i.Cells(11).Value() = "0.00" ' monto para el kardex USD
                                        i.Cells(18).Value() = "0.00" ' monto para el IGV USD


                                        'i.Cells(19).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                                    Else
                                        i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        i.Cells(9).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                        i.Cells(12).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        i.Cells(13).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                        i.Cells(8).Value() = colBI ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                        i.Cells(15).Value() = colIGV ' Math.Round(CDec(neto - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                        i.Cells(11).Value() = colBI_ME ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                        i.Cells(18).Value() = colIGV_ME ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                        '    i.Cells(19).Value() = Math.Round(CDec(i.Cells(15).Value() / txtTipoCambio.NumericValue), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES

                                    End If

                                End If

                            ElseIf Moneda = 2 Then

                                Select Case colDestinoGravado
                                    Case "4"
                                        ' DATOS DOLARES
                                        i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        i.Cells(9).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        i.Cells(12).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                        i.Cells(13).Value() = colBI_ME ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        i.Cells(11).Value() = colBI ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")

                                    Case Else
                                        ' DATOS DOLARES
                                        If i.Cells(27).Value() = "S" Then
                                            i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            i.Cells(9).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            i.Cells(12).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                            i.Cells(10).Value() = colBI ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            i.Cells(13).Value() = colBI_ME  ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                            i.Cells(8).Value() = "0.00" ' monto para el kardex
                                            i.Cells(15).Value() = "0.00" ' igv del item

                                            i.Cells(11).Value() = "0.00" ' monto para el kardex
                                            i.Cells(18).Value() = "0.00" ' monto para el IGV

                                            'i.Cells(15).Value() = "0.00" ' monto OTROS TRIBUTOS SOLES
                                        Else
                                            i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            i.Cells(9).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            i.Cells(12).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                            i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            i.Cells(13).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                            i.Cells(8).Value() = colBI ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            i.Cells(15).Value() = colIGV ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' igv del item

                                            i.Cells(11).Value() = colBI_ME ' Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            i.Cells(18).Value() = colIGV_ME ' Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV

                                            'i.Cells(15).Value() = Math.Round(CDec(i.Cells(19).Value() * txtTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS SOLES
                                        End If

                                End Select

                            End If
                        End If
                        totales_xx()
                        TotalesCabeceras()


                End Select
            Next
        End If

    End Sub
#End Region

#Region "CATEGORIA"
    Public Class Categoria

        Private _name As String
        Private _id As Integer
        Private _Utilidad As Decimal
        Private _UtilidadMayor As Decimal
        Private _UtilidadGranMayor As Decimal
        Public Sub New(ByVal name As String, ByVal id As Integer, ByVal utilidad As Decimal, utiMayor As Decimal, utiGranMayor As Decimal)
            _name = name
            _id = id
            _Utilidad = utilidad
            _UtilidadMayor = utiMayor
            _UtilidadGranMayor = utiGranMayor
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

        Public Property Utilidad() As Decimal
            Get
                Return _Utilidad
            End Get
            Set(ByVal value As Decimal)
                _Utilidad = value
            End Set
        End Property

        Public Property UtilidadMayor() As Decimal
            Get
                Return _UtilidadMayor
            End Get
            Set(ByVal value As Decimal)
                _UtilidadMayor = value
            End Set
        End Property

        Public Property UtilidadGranMayor() As Decimal
            Get
                Return _UtilidadGranMayor
            End Get
            Set(ByVal value As Decimal)
                _UtilidadGranMayor = value
            End Set
        End Property
    End Class

    Public Sub GrabarCategoria()
        Dim itemSA As New itemSA
        Dim item As New item
        Try
            With item
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .descripcion = txtNewClasificacion.Text.Trim
                .fechaIngreso = DateTime.Now
                .utilidad = nupUtilidad.Value
                .utilidadmayor = nupUtilidadMayor.Value
                .utilidadgranmayor = nupUtilidadGranMayor.Value
                .usuarioActualizacion = "Jiuni"
                .fechaActualizacion = DateTime.Now
            End With

            Dim codx As Integer = itemSA.SaveCategoria(item)
            lstCategoria.Items.Add(New Categoria(txtNewClasificacion.Text.Trim, codx, nupUtilidad.Value, nupUtilidadMayor.Value, nupUtilidadGranMayor.Value))
            Me.txtCategoria.ValueMember = CStr(codx)
            txtCategoria.Text = txtNewClasificacion.Text.Trim
            txtCategoria.Tag = nupUtilidad.Value
            ListadoProductosPorCategoriaTipoExistencia(codx, cboTipoExistencia.SelectedValue, nupUtilidad.Value, nupUtilidadMayor.Value, nupUtilidadGranMayor.Value)
        Catch ex As Exception
            lblEstado.Text = (ex.Message)
        End Try
    End Sub
#End Region

#Region "Manipulación Data"
    Private Sub ListaMercaderias(strTipoEx As String, strBusqueda As String)
        Dim existenciaSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        For Each i In existenciaSA.GetUbicarProductoXdescripcion2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Nothing, strTipoEx, strBusqueda)
            Dim n As New ListViewItem(i.codigodetalle)
            n.SubItems.Add(i.descripcionItem)
            n.SubItems.Add(i.unidad1)
            n.SubItems.Add(i.tipoExistencia)
            n.SubItems.Add(i.Utilidad)
            n.SubItems.Add(i.UtilidadMayor)
            n.SubItems.Add(i.UtilidadGranMayor)
            n.SubItems.Add(i.cuenta)
            lsvListadoItems.Items.Add(n)
        Next

    End Sub


    Private Sub ListadoProductosPorCategoriaTipoExistencia(strCategoria As Integer, strTipoExistencia As String, intUtilidad As Decimal, utiMayor As Decimal, utiGranMayor As Decimal)
        Dim itemSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        Try
            For Each i In itemSA.GetUbicarDetalleItemTipoExistencia(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strCategoria, strTipoExistencia)
                Dim n As New ListViewItem(i.codigodetalle)
                n.SubItems.Add(i.descripcionItem)
                n.SubItems.Add(i.unidad1)
                n.SubItems.Add(i.tipoExistencia)
                n.SubItems.Add(intUtilidad)
                n.SubItems.Add(utiMayor)
                n.SubItems.Add(utiGranMayor)
                n.SubItems.Add(i.cuenta)
                lsvListadoItems.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Function AS_Proveedor(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento
        If CDec(lblBonificaMN.Text) > 0 Then
            nMovimiento.cuenta = "16"
        Else
            nMovimiento.cuenta = "4212"
        End If
        nMovimiento.descripcion = txtProveedor.Text
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"

        Return nMovimiento
    End Function
    Dim cuentaMascara As New cuentaMascara
    Public Function AS_Default(cMonto As Decimal, cMontoUS As Decimal, tipoex As String, DescItem As String) As movimiento
        Dim nMovimiento As New movimiento
        Dim cuentaMascaraSA As New cuentaMascaraSA
        nMovimiento = New movimiento
        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, tipoex, "ITEM", "COMPRA")
        Select Case cuentaMascara.parametro
            Case "01"
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "03"
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "04"
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "05"
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        End Select
        nMovimiento.descripcion = DescItem
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"

        Return nMovimiento
    End Function

    Public Function AS_Caja(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        Dim UserCajaSA As New cajaUsuarioSA
        Dim UserCaja As New cajaUsuario
        Dim entidadFSA As New EstadosFinancierosSA
        Dim entidadF As New estadosFinancieros

        UserCaja = UserCajaSA.UbicarCajaUsuarioPorID(IdUsuarioCaja)
        entidadF = entidadFSA.GetUbicar_estadosFinancierosPorID(UserCaja.idCajaDestino)
        nMovimiento = New movimiento With {
              .cuenta = entidadF.cuenta,
              .descripcion = entidadF.descripcion,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = IdUsuarioCaja}

        Return nMovimiento
    End Function

    Public Function AS_IGV(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "40111",
              .descripcion = "I.G.V.",
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = IdProveedor
        nAsiento.nombreEntidad = NomProveedor
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = fecha
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.PRODUCTOS_EN_TRANSITO
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        If txtGlosa.Text.Trim.Length > 0 Then
            nAsiento.glosa = txtGlosa.Text.Trim
        Else
            nAsiento.glosa = String.Concat("Por devolución de existencias", vbCrLf, "según/ ", Space(1), "NOTA DE CREDITO", Space(1), "Nro.", Space(1), txtSerie.Text, "-", txtNumero.Text, vbCrLf, "fecha: ", fecha)
        End If

        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Public Function AsientoBeneficio(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = IdProveedor
        nAsiento.nombreEntidad = NomProveedor
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = fecha
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.COMPRA_NOTA_CREDITO
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        If txtGlosa.Text.Trim.Length > 0 Then
            nAsiento.glosa = txtGlosa.Text.Trim
        Else
            nAsiento.glosa = String.Concat("Por devolución de existencias", vbCrLf, "según/ ", Space(1), "NOTA DE CREDITO", Space(1), "Nro.", Space(1), txtSerie.Text, "-", txtNumero.Text, vbCrLf, "fecha: ", fecha)
        End If
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Public Sub MV_Item_Transito(cCuenta As String, cproducto As String, cMonto As Decimal, cMontoUS As Decimal, strTipoExistencia As String)
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento
        Dim cuentaMascaraSA As New cuentaMascaraSA

        asientoTransitod = AsientoTransito(cMonto, cMontoUS) ' CABECERA ASIENTO

        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento

        Select Case strTipoExistencia
            Case "01"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, strTipoExistencia, "ITEM", "EXT01.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "03"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, strTipoExistencia, "ITEM", "EXT03.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "04"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, strTipoExistencia, "ITEM", "EXT04.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "05"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, strTipoExistencia, "ITEM", "EXT05.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        End Select


        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento
        Select Case strTipoExistencia
            Case "01"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, strTipoExistencia, "ITEM", "TRANS01.1")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "03"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, strTipoExistencia, "ITEM", "TRANS03.1")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "04"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, strTipoExistencia, "ITEM", "TRANS04.1")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "05"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, strTipoExistencia, "ITEM", "TRANS05.1")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        End Select

        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Public Sub AsientoBeneficios_02(cMonto As Decimal, cMontoUS As Decimal)
        Dim asientoTransitod As New asiento
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoBeneficio(cMonto, cMontoUS) ' CABECERA ASIENTO
        ListaAsientonTransito.Add(asientoTransitod)


        asientoTransitod.movimiento.Add(AS_Proveedor(CDec(lblTotalAdquisiones.Text), CDec(lblTotalUS.Text)))
        asientoTransitod.movimiento.Add(AS_IGV(CDec(lblTotalMontoIgv.Text), CDec(lblTotalMontoIgvUS.Text)))

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If dgvNuevoDoc.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then

                nMovimiento = New movimiento
                nMovimiento.cuenta = "7311"
                nMovimiento.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
                'Select Case lblTipoDoc.Text
                '    Case "03", "02"
                '        nMovimiento.monto = CDec(i.SubItems(5).Text)
                '        nMovimiento.montoUSD = CDec(i.SubItems(6).Text)
                '    Case Else
                Select Case txtIdComprobanteNota.Text
                    Case "03", "02"
                        nMovimiento.monto = CDec(i.Cells(10).Value())
                        nMovimiento.montoUSD = CDec(i.Cells(11).Value())
                    Case Else
                        Select Case i.Cells(1).Value()
                            Case "1"
                                nMovimiento.monto = CDec(i.Cells(12).Value())
                                nMovimiento.montoUSD = CDec(i.Cells(16).Value())
                            Case Else
                                nMovimiento.monto = CDec(i.Cells(10).Value())
                                nMovimiento.montoUSD = CDec(i.Cells(11).Value())
                        End Select

                End Select
                'nMovimiento.monto = CDec(i.SubItems(13).Text)
                'nMovimiento.montoUSD = CDec(i.SubItems(14).Text)
                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = "Jiuni"

                asientoTransitod.movimiento.Add(nMovimiento)
            End If
        Next


    End Sub

    Sub AsientoNotaCredito()
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = IdProveedor
        nAsiento.nombreEntidad = NomProveedor
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = fecha
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.COMPRA_NOTA_CREDITO
        nAsiento.importeMN = CDec(lblTotalAdquisiones.Text)
        nAsiento.importeME = CDec(lblTotalUS.Text)
        If txtGlosa.Text.Trim.Length > 0 Then
            nAsiento.glosa = txtGlosa.Text.Trim
        Else
            nAsiento.glosa = String.Concat("Por devolución de existencias", vbCrLf, "según/ ", Space(1), "NOTA DE CREDITO", Space(1), "Nro.", Space(1), txtSerie.Text, "-", txtNumero.Text, vbCrLf, "fecha: ", fecha)
        End If
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)

        '    Select Case TipoCompra

        'Case TIPO_COMPRA.COMPRA_AL_CREDITO
        '    nAsiento.movimiento.Add(AS_Proveedor(CDec(lblTotalAdquisiones.Text), CDec(lblTotalUS.Text)))
        'Case TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION, TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
        '    nAsiento.movimiento.Add(AS_Caja(CDec(lblTotalAdquisiones.Text), CDec(lblTotalUS.Text)))
        '  End Select
        nAsiento.movimiento.Add(AS_Proveedor(CDec(lblTotalAdquisiones.Text), CDec(lblTotalUS.Text)))
        nAsiento.movimiento.Add(AS_IGV(CDec(lblTotalMontoIgv.Text), CDec(lblTotalMontoIgvUS.Text)))
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If dgvNuevoDoc.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                Select Case txtIdComprobanteNota.Text
                    Case "03", "02"
                        MV_Item_Transito(i.Cells(22).Value(), i.Cells(3).Value(), CDec(i.Cells(10).Value()), CDec(i.Cells(13).Value()), i.Cells(21).Value())
                    Case Else

                        Select Case i.Cells(1).Value()
                            Case "1"
                                MV_Item_Transito(i.Cells(22).Value(), i.Cells(3).Value(), CDec(i.Cells(8).Value()), CDec(i.Cells(11).Value()), i.Cells(21).Value())
                            Case Else
                                MV_Item_Transito(i.Cells(22).Value(), i.Cells(3).Value(), CDec(i.Cells(10).Value()), CDec(i.Cells(13).Value()), i.Cells(21).Value())

                        End Select


                End Select
                nAsiento.movimiento.Add(AS_Default(CDec(i.Cells(8).Value()), CDec(i.Cells(11).Value()), i.Cells(21).Value(), i.Cells(3).Value()))
            End If
        Next



        '   Return nAsiento
    End Sub

    Sub AsientoNotaCreditoOpcBenef()
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento
        Dim cuentaMascaraSA As New cuentaMascaraSA

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = IdProveedor
        nAsiento.nombreEntidad = NomProveedor
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = fecha
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.COMPRA_NOTA_CREDITO
        nAsiento.importeMN = CDec(lblTotalAdquisiones.Text)
        nAsiento.importeME = CDec(lblTotalUS.Text)
        If txtGlosa.Text.Trim.Length > 0 Then
            nAsiento.glosa = txtGlosa.Text.Trim
        Else
            nAsiento.glosa = String.Concat("Por devolución de existencias", vbCrLf, "según/ ", Space(1), "NOTA DE CREDITO", Space(1), "Nro.", Space(1), txtSerie.Text, "-", txtNumero.Text, vbCrLf, "fecha: ", fecha)
        End If
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)

        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If dgvNuevoDoc.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then


                nMovimiento = New movimiento
                Select Case dgvNuevoDoc.Rows(i.Index).Cells(21).Value()
                    Case "01"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS01.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    Case "03"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "TRANS03.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    Case "04"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "TRANS04.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    Case "05"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "TRANS05.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                End Select
                nMovimiento.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
                nMovimiento.tipo = "D"
                nMovimiento.monto = CDec(dgvNuevoDoc.Rows(i.Index).Cells(8).Value())
                nMovimiento.montoUSD = CDec(dgvNuevoDoc.Rows(i.Index).Cells(11).Value())
                nMovimiento.usuarioActualizacion = "Jiuni"
                nMovimiento.fechaActualizacion = DateTime.Now
                nAsiento.movimiento.Add(nMovimiento)

                nMovimiento = New movimiento
                nMovimiento.cuenta = "73"
                nMovimiento.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
                nMovimiento.tipo = "H"
                nMovimiento.monto = CDec(dgvNuevoDoc.Rows(i.Index).Cells(8).Value())
                nMovimiento.montoUSD = CDec(dgvNuevoDoc.Rows(i.Index).Cells(11).Value())
                nMovimiento.usuarioActualizacion = "Jiuni"
                nMovimiento.fechaActualizacion = DateTime.Now
                nAsiento.movimiento.Add(nMovimiento)

                totalMN += CDec(i.Cells(8).Value)
                totalME += CDec(i.Cells(11).Value)
            End If
        Next

        nAsiento.importeMN = totalMN
        nAsiento.importeME = totalME
        '   Return nAsiento
    End Sub


    Private Function ListaTotalesAlmacen() As List(Of totalesAlmacen)
        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim almacenSA As New almacenSA
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If dgvNuevoDoc.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then

                Select Case dgvNuevoDoc.Rows(i.Index).Cells(21).Value()
                    Case "GS"

                    Case Else
                        objTotalesDet = New totalesAlmacen
                        objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
                        objTotalesDet.SecuenciaDetalle = 0
                        objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
                        objTotalesDet.Modulo = "N"
                        objTotalesDet.idEstablecimiento = almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(30).Value()).idEstablecimiento
                        objTotalesDet.idAlmacen = dgvNuevoDoc.Rows(i.Index).Cells(30).Value()
                        objTotalesDet.origenRecaudo = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
                        objTotalesDet.tipoCambio = txtTipoCambio.Value
                        objTotalesDet.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(21).Value()
                        objTotalesDet.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
                        objTotalesDet.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
                        objTotalesDet.idUnidad = dgvNuevoDoc.Rows(i.Index).Cells(6).Value()
                        objTotalesDet.unidadMedida = Nothing

                        Select Case "01" ' strTipoNota
                            Case Notas_Credito.DEV_EXISTENCIA
                                objTotalesDet.cantidad = CType(dgvNuevoDoc.Rows(i.Index).Cells(7).Value() * -1, Decimal)
                                objTotalesDet.precioUnitarioCompra = CType(dgvNuevoDoc.Rows(i.Index).Cells(9).Value(), Decimal)

                                Select Case dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
                                    Case "1"
                                        objTotalesDet.importeSoles = CType(dgvNuevoDoc.Rows(i.Index).Cells(8).Value() * -1, Decimal)
                                        objTotalesDet.importeDolares = CType(dgvNuevoDoc.Rows(i.Index).Cells(11).Value() * -1, Decimal)
                                    Case Else
                                        objTotalesDet.importeSoles = CType(dgvNuevoDoc.Rows(i.Index).Cells(8).Value() * -1, Decimal)
                                        objTotalesDet.importeDolares = CType(dgvNuevoDoc.Rows(i.Index).Cells(11).Value() * -1, Decimal)
                                End Select
                            Case Notas_Credito.DR_REDUCCION_COSTOS,
                                Notas_Credito.DR_BENEFICIO, Notas_Credito.ERR_PRECIO
                                objTotalesDet.cantidad = 0
                                objTotalesDet.precioUnitarioCompra = CType(dgvNuevoDoc.Rows(i.Index).Cells(9).Value(), Decimal)

                                Select Case dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
                                    Case "1"
                                        objTotalesDet.importeSoles = CType(dgvNuevoDoc.Rows(i.Index).Cells(8).Value() * -1, Decimal)
                                        objTotalesDet.importeDolares = CType(dgvNuevoDoc.Rows(i.Index).Cells(11).Value() * -1, Decimal)
                                    Case Else
                                        objTotalesDet.importeSoles = CType(dgvNuevoDoc.Rows(i.Index).Cells(8).Value() * -1, Decimal)
                                        objTotalesDet.importeDolares = CType(dgvNuevoDoc.Rows(i.Index).Cells(11).Value() * -1, Decimal)
                                End Select

                            Case Notas_Credito.ERR_CANTIDAD
                                objTotalesDet.cantidad = CType(dgvNuevoDoc.Rows(i.Index).Cells(7).Value() * -1, Decimal)
                                objTotalesDet.precioUnitarioCompra = 0
                                objTotalesDet.importeSoles = 0
                                objTotalesDet.importeDolares = 0

                            Case Notas_Credito.BOF_REDUC_COSTO_IGUAL_COMPRA
                                objTotalesDet.cantidad = CType(dgvNuevoDoc.Rows(i.Index).Cells(7).Value(), Decimal)
                                objTotalesDet.precioUnitarioCompra = 0
                                objTotalesDet.importeSoles = 0
                                objTotalesDet.importeDolares = 0

                        End Select
                        'End Select
                        objTotalesDet.montoIsc = 0
                        objTotalesDet.montoIscUS = 0
                        objTotalesDet.Otros = 0
                        objTotalesDet.OtrosUS = 0
                        objTotalesDet.porcentajeUtilidad = 0
                        objTotalesDet.importePorcentaje = 0
                        objTotalesDet.importePorcentajeUS = 0
                        objTotalesDet.precioVenta = 0
                        objTotalesDet.precioVentaUS = 0
                        objTotalesDet.usuarioActualizacion = "NN"
                        objTotalesDet.fechaActualizacion = Date.Now
                        ListaTotales.Add(objTotalesDet)
                End Select


            End If

        Next

        Return ListaTotales
    End Function


    Private Function ListaTotalesBonificacion() As List(Of totalesAlmacen)
        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim almacenSA As New almacenSA
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If dgvNuevoDoc.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then

                Select Case dgvNuevoDoc.Rows(i.Index).Cells(21).Value()
                    Case "GS"

                    Case Else
                        objTotalesDet = New totalesAlmacen
                        objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
                        objTotalesDet.SecuenciaDetalle = 0
                        objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
                        objTotalesDet.Modulo = "N"
                        objTotalesDet.idEstablecimiento = almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(30).Value()).idEstablecimiento
                        objTotalesDet.idAlmacen = dgvNuevoDoc.Rows(i.Index).Cells(30).Value()
                        objTotalesDet.origenRecaudo = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
                        objTotalesDet.tipoCambio = txtTipoCambio.Value
                        objTotalesDet.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(21).Value()
                        objTotalesDet.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
                        objTotalesDet.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
                        objTotalesDet.idUnidad = dgvNuevoDoc.Rows(i.Index).Cells(6).Value()
                        objTotalesDet.unidadMedida = Nothing

                        objTotalesDet.cantidad = CType(dgvNuevoDoc.Rows(i.Index).Cells(7).Value(), Decimal)
                        objTotalesDet.precioUnitarioCompra = CType(dgvNuevoDoc.Rows(i.Index).Cells(9).Value(), Decimal)

                        objTotalesDet.importeSoles = CType(dgvNuevoDoc.Rows(i.Index).Cells(8).Value(), Decimal)
                        objTotalesDet.importeDolares = CType(dgvNuevoDoc.Rows(i.Index).Cells(11).Value(), Decimal)

                        objTotalesDet.montoIsc = 0
                        objTotalesDet.montoIscUS = 0
                        objTotalesDet.Otros = 0
                        objTotalesDet.OtrosUS = 0
                        objTotalesDet.porcentajeUtilidad = 0
                        objTotalesDet.importePorcentaje = 0
                        objTotalesDet.importePorcentajeUS = 0
                        objTotalesDet.precioVenta = 0
                        objTotalesDet.precioVentaUS = 0
                        objTotalesDet.usuarioActualizacion = "NN"
                        objTotalesDet.fechaActualizacion = Date.Now
                        ListaTotales.Add(objTotalesDet)
                End Select


            End If

        Next

        Return ListaTotales
    End Function

    Private Function ListaTotalesAlmacenReducCostos() As List(Of totalesAlmacen)
        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim almacenSA As New almacenSA
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If dgvNuevoDoc.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then

                Select Case dgvNuevoDoc.Rows(i.Index).Cells(21).Value()
                    Case "GS"

                    Case Else
                        objTotalesDet = New totalesAlmacen
                        objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
                        objTotalesDet.SecuenciaDetalle = 0
                        objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
                        objTotalesDet.Modulo = "N"
                        objTotalesDet.idEstablecimiento = almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(30).Value()).idEstablecimiento
                        objTotalesDet.idAlmacen = dgvNuevoDoc.Rows(i.Index).Cells(30).Value()
                        objTotalesDet.origenRecaudo = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
                        objTotalesDet.tipoCambio = txtTipoCambio.Value
                        objTotalesDet.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(21).Value()
                        objTotalesDet.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
                        objTotalesDet.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
                        objTotalesDet.idUnidad = dgvNuevoDoc.Rows(i.Index).Cells(6).Value()
                        objTotalesDet.unidadMedida = Nothing
                        Select Case dgvNuevoDoc.Rows(i.Index).Cells(40).Value()
                            Case "="
                                objTotalesDet.cantidad = CType(dgvNuevoDoc.Rows(i.Index).Cells(7).Value(), Decimal)
                                objTotalesDet.precioUnitarioCompra = CType(dgvNuevoDoc.Rows(i.Index).Cells(9).Value(), Decimal)

                                objTotalesDet.importeSoles = 0
                                objTotalesDet.importeDolares = 0
                            Case "=!"

                                objTotalesDet.cantidad = 0
                                objTotalesDet.precioUnitarioCompra = 0

                                objTotalesDet.importeSoles = CType(dgvNuevoDoc.Rows(i.Index).Cells(8).Value() * -1, Decimal)
                                objTotalesDet.importeDolares = CType(dgvNuevoDoc.Rows(i.Index).Cells(11).Value() * -1, Decimal)

                            Case "<>"
                                objTotalesDet.cantidad = CType(dgvNuevoDoc.Rows(i.Index).Cells(7).Value(), Decimal)
                                objTotalesDet.precioUnitarioCompra = CType(dgvNuevoDoc.Rows(i.Index).Cells(9).Value(), Decimal)

                                objTotalesDet.importeSoles = CType(dgvNuevoDoc.Rows(i.Index).Cells(8).Value(), Decimal)
                                objTotalesDet.importeDolares = CType(dgvNuevoDoc.Rows(i.Index).Cells(11).Value(), Decimal)
                        End Select

                        'End Select
                        objTotalesDet.montoIsc = 0
                        objTotalesDet.montoIscUS = 0
                        objTotalesDet.Otros = 0
                        objTotalesDet.OtrosUS = 0
                        objTotalesDet.porcentajeUtilidad = 0
                        objTotalesDet.importePorcentaje = 0
                        objTotalesDet.importePorcentajeUS = 0
                        objTotalesDet.precioVenta = 0
                        objTotalesDet.precioVentaUS = 0
                        objTotalesDet.usuarioActualizacion = "NN"
                        objTotalesDet.fechaActualizacion = Date.Now
                        ListaTotales.Add(objTotalesDet)
                End Select


            End If

        Next

        Return ListaTotales
    End Function


    Sub GuiaRemision(objDocumentoCompra As documento)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION

        With guiaRemisionBE
            '.idDocumento = lblIdDocumento.Text
            .codigoLibro = "8"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha
            .periodo = txtPeriodo.Text
            .tipoDoc = "99"
            .serie = txtSerieGuia.Text
            .numeroDoc = txtNumeroGuia.Text
            .idEntidad = IdProveedor
            .monedaDoc = IIf(Moneda = 1, "1", "2")
            .tasaIgv = txtTipoCambio.Value
            .tipoCambio = txtTipoCambio.Value
            .importeMN = CDec(lblTotalAdquisiones.Text)
            .importeME = CDec(lblTotalUS.Text)
            .glosa = "Guía de remisión por nota de credito"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If dgvNuevoDoc.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                documentoguiaDetalle = New documentoguiaDetalle
                '    documentoguiaDetalle.idDocumento = lblIdDocumento.Text
                documentoguiaDetalle.idItem = i.Cells(2).Value
                documentoguiaDetalle.descripcionItem = i.Cells(3).Value
                documentoguiaDetalle.destino = i.Cells(1).Value
                documentoguiaDetalle.unidadMedida = i.Cells(6).Value
                documentoguiaDetalle.cantidad = CDec(i.Cells(7).Value)
                documentoguiaDetalle.precioUnitario = CDec(i.Cells(9).Value)
                documentoguiaDetalle.precioUnitarioUS = CDec(i.Cells(12).Value)
                documentoguiaDetalle.importeMN = CDec(i.Cells(10).Value)
                documentoguiaDetalle.importeME = CDec(i.Cells(13).Value)
                documentoguiaDetalle.almacenRef = CInt(i.Cells(30).Value) ' CInt(i.Cells(30).Value)
                documentoguiaDetalle.usuarioModificacion = "Jiuni"
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
            End If
        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Private Function GlosaCompra() As String
        If Not String.IsNullOrEmpty(txtSerie.Text) And Not String.IsNullOrEmpty(txtNumero.Text) And _
        Not String.IsNullOrEmpty(txtProveedor.Text) Then
            Return String.Concat("Por ingreso de dinero por nota de crédito", Space(1), "Nro.", Space(1), txtSerie.Text, "-", txtNumero.Text)
        Else
            Return False
        End If
    End Function

    Function ComprobanteCaja() As documento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim nDocumentoCaja As New documento()
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)


        ef = efSA.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino)

        nDocumentoCaja.idDocumento = 0
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = ef.idEstablecimiento  'GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            nDocumentoCaja.idProyecto = GProyectos.IdProyectoActividad
        End If
        nDocumentoCaja.tipoDoc = "109"
        nDocumentoCaja.fechaProceso = fecha
        nDocumentoCaja.nroDoc = Nothing ' IIf(rbEfectivo.Checked = True, Nothing, txtNumCaja.Text.Trim)
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = "9912" ' INGRESO DE DINERO A CAJA
        nDocumentoCaja.usuarioActualizacion = "Jiuni"
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        objCaja.idDocumento = 0
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = ef.idEstablecimiento
        objCaja.fechaProceso = fecha
        objCaja.fechaCobro = fecha
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        objCaja.IdProveedor = txtProveedor.ValueMember
        objCaja.codigoLibro = "9912"
        objCaja.codigoProveedor = txtProveedor.ValueMember
        objCaja.TipoDocumentoPago = "109"
        objCaja.tipoDocPago = "109"
        objCaja.periodo = PeriodoGeneral
        objCaja.NumeroDocumento = Nothing ' IIf(txtNumCaja.Text.Trim.Length > 0, txtNumCaja.Text, Nothing)
        objCaja.moneda = "1" ' txtCodMoneda.Text ' IIf(cboMoneda.Text = "MONEDA NACIONAL (SOLES)", "SOL", "USD")
        objCaja.tipoCambio = txtTipoCambio.Value
        objCaja.montoSoles = CDec(lblTotalAdquisiones.Text)
        objCaja.montoUsd = CDec(lblTotalUS.Text)

        objCaja.glosa = GlosaCompra()
        objCaja.entregado = "SI"
        objCaja.entidadFinanciera = ef.idestado
        objCaja.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja

        '   For Each i As DataGridViewRow In dgvNuevoDoc.Rows
        objCajaDetalle = New documentoCajaDetalle
        objCajaDetalle.idDocumento = 0
        objCajaDetalle.fecha = fecha
        objCajaDetalle.idItem = "00"
        objCajaDetalle.DetalleItem = "Por excedente, nota de crédito"
        objCajaDetalle.montoSoles = CDec(lblBonificaMN.Text) 'CDec(lblTotalAdquisiones.Text)
        objCajaDetalle.montoUsd = CDec(lblBonificaME.Text) ' CDec(lblTotalUS.Text)
      
        objCajaDetalle.entregado = "SI"
        objCajaDetalle.documentoAfectado = 0 ' lblIdDoc.Text
        objCajaDetalle.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
        objCajaDetalle.fechaModificacion = DateTime.Now
        ListaDetalle.Add(objCajaDetalle)
        '   Next
        nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaDetalle


        'ASIENTO CONTABLE
        Dim asiento As New asiento
        Dim nMovimiento As New movimiento

        With asiento
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCostos = GEstableciento.IdEstablecimiento
            .idEntidad = txtProveedor.ValueMember
            .nombreEntidad = txtProveedor.Text
            .tipoEntidad = "PR"
            .fechaProceso = fecha
            .codigoLibro = "8"
            .tipo = "D"
            .tipoAsiento = "AS-NTC"
            .importeMN = CDec(lblBonificaMN.Text)
            .importeME = CDec(lblBonificaME.Text)
            .glosa = GlosaCompra()
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With

        nMovimiento = New movimiento
        nMovimiento.cuenta = ef.cuenta
        nMovimiento.descripcion = txtEntidadFinanciera.Text
        nMovimiento.tipo = "D"
        nMovimiento.monto = CDec(lblBonificaMN.Text)
        nMovimiento.montoUSD = CDec(lblBonificaME.Text)
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)


        nMovimiento = New movimiento
        nMovimiento.cuenta = "16"
        nMovimiento.descripcion = txtEntidadFinanciera.Text
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(lblBonificaMN.Text)
        nMovimiento.montoUSD = CDec(lblBonificaME.Text)
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asiento)

        Return nDocumentoCaja
    End Function

    Sub Grabar()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim nDocumentoExce As New documento
        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad
        Dim DocCaja As New documento

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim almacenSA As New almacenSA
        Dim ListaDetalle As New List(Of documentocompradetalle)
        Dim ListaTotales As New List(Of totalesAlmacen)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = "07"
            .fechaProceso = fecha
            .nroDoc = txtSerie.Text & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idPadre = IdCompraOrigen
            .codigoLibro = "8"
            .tipoDoc = txtIdComprobanteNota.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha
            .fechaContable = txtPeriodo.Text
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text
            .idProveedor = IdProveedor
            .nombreProveedor = NomProveedor
            .monedaDoc = IIf(Moneda = 1, "1", "2")
            .tasaIgv = txtIgv.Value    ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = txtTipoCambio.Value
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing
            '****************** DESTINO EN SOLES ************************************************************************
            .bi01 = IIf(nudBase1 = 0 Or nudBase1 = "0.00", CDec(0.0), CDec(nudBase1))
            .bi02 = IIf(nudBase2 = 0 Or nudBase2 = "0.00", CDec(0.0), CDec(nudBase2))
            .bi03 = IIf(nudBase3 = 0 Or nudBase3 = "0.00", CDec(0.0), CDec(nudBase3))
            .bi04 = IIf(nudBase4 = 0 Or nudBase4 = "0.00", CDec(0.0), CDec(nudBase4))
            .isc01 = IIf(nudIsc1 = 0 Or nudIsc1 = "0.00", CDec(0.0), CDec(nudIsc1))
            .isc02 = IIf(nudIsc2 = 0 Or nudIsc2 = "0.00", CDec(0.0), CDec(nudIsc2))
            .isc03 = IIf(nudIsc3 = 0 Or nudIsc3 = "0.00", CDec(0.0), CDec(nudIsc3))
            .igv01 = IIf(nudMontoIgv1 = 0 Or nudMontoIgv1 = "0.00", CDec(0.0), CDec(nudMontoIgv1))
            .igv02 = IIf(nudMontoIgv2 = 0 Or nudMontoIgv2 = "0.00", CDec(0.0), CDec(nudMontoIgv2))
            .igv03 = IIf(nudMontoIgv3 = 0 Or nudMontoIgv3 = "0.00", CDec(0.0), CDec(nudMontoIgv3))
            .otc01 = IIf(nudOtrosTributos1 = 0 Or nudOtrosTributos1 = "0.00", CDec(0.0), CDec(nudOtrosTributos1))
            .otc02 = IIf(nudOtrosTributos2 = 0 Or nudOtrosTributos2 = "0.00", CDec(0.0), CDec(nudOtrosTributos2))
            .otc03 = IIf(nudOtrosTributos3 = 0 Or nudOtrosTributos3 = "0.00", CDec(0.0), CDec(nudOtrosTributos3))
            .otc04 = IIf(nudOtrosTributos4 = 0 Or nudOtrosTributos4 = "0.00", CDec(0.0), CDec(nudOtrosTributos4))
            '****************************************************************************************************************

            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = IIf(nudBaseus1 = 0 Or nudBaseus1 = "0.00", CDec(0.0), CDec(nudBaseus1))
            .bi02us = IIf(nudBaseus2 = 0 Or nudBaseus2 = "0.00", CDec(0.0), CDec(nudBaseus2))
            .bi03us = IIf(nudBaseus3 = 0 Or nudBaseus3 = "0.00", CDec(0.0), CDec(nudBaseus3))
            .bi04us = IIf(nudBaseus4 = 0 Or nudBaseus4 = "0.00", CDec(0.0), CDec(nudBaseus4))
            .isc01us = IIf(nudIscus1 = 0 Or nudIscus1 = "0.00", CDec(0.0), CDec(nudIscus1))
            .isc02us = IIf(nudIscus2 = 0 Or nudIscus2 = "0.00", CDec(0.0), CDec(nudIscus2))
            .isc03us = IIf(nudIscus3 = 0 Or nudIscus3 = "0.00", CDec(0.0), CDec(nudIscus3))
            .igv01us = IIf(nudMontoIgvus1 = 0 Or nudMontoIgvus1 = "0.00", CDec(0.0), CDec(nudMontoIgvus1))
            .igv02us = IIf(nudMontoIgvus2 = 0 Or nudMontoIgvus2 = "0.00", CDec(0.0), CDec(nudMontoIgvus2))
            .igv03us = IIf(nudMontoIgvus3 = 0 Or nudMontoIgvus3 = "0.00", CDec(0.0), CDec(nudMontoIgvus3))
            .otc01us = IIf(nudOtrosTributosus1 = 0 Or nudOtrosTributosus1 = "0.00", CDec(0.0), CDec(nudOtrosTributosus1))
            .otc02us = IIf(nudOtrosTributosus2 = 0 Or nudOtrosTributosus2 = "0.00", CDec(0.0), CDec(nudOtrosTributosus2))
            .otc03us = IIf(nudOtrosTributosus3 = 0 Or nudOtrosTributosus3 = "0.00", CDec(0.0), CDec(nudOtrosTributosus3))
            .otc04us = IIf(nudOtrosTributosus4 = 0 Or nudOtrosTributosus4 = "0.00", CDec(0.0), CDec(nudOtrosTributosus4))
            '****************************************************************************************************************
            .importeTotal = IIf(lblTotalAdquisiones.Text = 0 Or lblTotalAdquisiones.Text = "0.00", CDec(0.0), CDec(lblTotalAdquisiones.Text))
            .importeUS = IIf(lblTotalUS.Text = 0 Or lblTotalUS.Text = "0.00", CDec(0.0), CDec(lblTotalUS.Text))
            Select Case cboOperacion.Text
                Case "DISMINUIR CANTIDAD"
                    .destino = "9913"
                Case "DISMINUIR IMPORTE"
                    .destino = "9914"
                Case "DISMINUIR CANTIDAD E IMPORTE"
                    .destino = "9915"
                Case "DEVOLUCION DE EXISTENCIAS"
                    .destino = "9916"
                Case "BONIFICACIONES RECIBIDAS (OPC. Beneficios)"
                    .destino = "9917"
                Case "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"
                    .destino = "9918"
            End Select

            If CDec(lblBonificaMN.Text) > 0 Then
                If chDeposito.Checked = True Then
                    .estadoPago = Nota_Credito.DINERO_ENTREGADO
                Else
                    .estadoPago = Nota_Credito.DINERO_PENDIENTE_DE_ENTREGA
                End If
            Else
                If chProceso.Checked = True Then
                    .estadoPago = Nota_Credito.PROCESADO_SIN_MOVIMIENTOS
                End If
            End If

            If txtGlosa.Text.Trim.Length > 0 Then
                .glosa = cboOperacion.Text & vbCrLf & txtGlosa.Text.Trim
            Else
                .glosa = cboOperacion.Text & vbCrLf & String.Concat("Por devolución de existencias", vbCrLf, "según/ ", Space(1), "NOTA DE CREDITO", Space(1), "Nro.", Space(1), txtSerie.Text, "-", txtNumero.Text, vbCrLf, "fecha: ", fecha)
            End If
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.NOTA_CREDITO
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
            .sustentado = "01" 'strTipoNota
        End With
        ndocumento.documentocompra = nDocumentoCompra


        For Each i As DataGridViewRow In dgvNuevoDoc.Rows

            If i.Cells(27).Value = "S" Then

                If i.Cells(39).Value = "Elegir almacén" Then
                    MessageBoxAdv.Show("Debe seleccionar un almacen valido!", "Atención", Nothing, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.secuencia = i.Cells(0).Value()
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            Select Case cboOperacion.Text
                Case "DISMINUIR CANTIDAD"
                    If Not CDec(i.Cells(7).Value()) > 0 Then
                        lblEstado.Text = "Ingrese una cantidad mayor a cero!"
                        Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(i.Index).Cells(7)
                        Me.dgvNuevoDoc.BeginEdit(True)
                        Exit Sub
                    End If

                    objDocumentoCompraDet.TipoOperacion = "9913"
                Case "DISMINUIR IMPORTE"
                    If Not CDec(i.Cells(8).Value()) > 0 Then
                        lblEstado.Text = "Ingrese un Valor de compra mayor a cero!"
                        Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(i.Index).Cells(8)
                        Me.dgvNuevoDoc.BeginEdit(True)
                        Exit Sub
                    End If

                    If Not CDec(i.Cells(11).Value()) > 0 Then
                        lblEstado.Text = "Ingrese un Valor de compra (ME) mayor a cero!"
                        Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(i.Index).Cells(11)
                        Me.dgvNuevoDoc.BeginEdit(True)
                        Exit Sub
                    End If


                    objDocumentoCompraDet.TipoOperacion = "9914"
                Case "DISMINUIR CANTIDAD E IMPORTE"
                    objDocumentoCompraDet.TipoOperacion = "9915"
                Case "DEVOLUCION DE EXISTENCIAS"

                    If Not CDec(i.Cells(7).Value()) > 0 Then
                        lblEstado.Text = "Ingrese una cantidad mayor a cero!"
                        Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(i.Index).Cells(7)
                        Me.dgvNuevoDoc.BeginEdit(True)
                        Exit Sub
                    End If

                    If Not CDec(i.Cells(8).Value()) > 0 Then
                        lblEstado.Text = "Ingrese un Valor de compra mayor a cero!"
                        Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(i.Index).Cells(8)
                        Me.dgvNuevoDoc.BeginEdit(True)
                        Exit Sub
                    End If

                    If Not CDec(i.Cells(11).Value()) > 0 Then
                        lblEstado.Text = "Ingrese un Valor de compra (ME) mayor a cero!"
                        Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(i.Index).Cells(11)
                        Me.dgvNuevoDoc.BeginEdit(True)
                        Exit Sub
                    End If

                    objDocumentoCompraDet.TipoOperacion = "9916"
                Case "BONIFICACIONES RECIBIDAS (OPC. Beneficios)"
                    objDocumentoCompraDet.TipoOperacion = "9917"
                Case "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"
                    objDocumentoCompraDet.TipoOperacion = "9918"

                    objDocumentoCompraDet.FlagBonif = i.Cells(40).Value()
            End Select
            Select Case i.Cells(21).Value()
                Case "GS"
                    'If Not CDec(i.Cells(7).Value()) > 0 Then
                    '    lblEstado.Text = "Ingrese una cantidad mayor a cero!"
                    '    Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(i.Index).Cells(7)
                    '    Me.dgvNuevoDoc.BeginEdit(True)
                    '    Exit Sub
                    'End If

                    If Not CDec(i.Cells(10).Value()) > 0 Then
                        lblEstado.Text = "Ingrese un importe mayor a cero!"
                        Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(i.Index).Cells(10)
                        Me.dgvNuevoDoc.BeginEdit(True)
                        Exit Sub
                    End If
                    objDocumentoCompraDet.monto1 = CDec(i.Cells(7).Value())
                    objDocumentoCompraDet.importe = CDec(i.Cells(10).Value())
                    objDocumentoCompraDet.importeUS = CDec(i.Cells(13).Value())
                    objDocumentoCompraDet.montokardex = CDec(i.Cells(8).Value())
                    objDocumentoCompraDet.montoIsc = 0 ' CDec(i.Cells(13).Value())
                    objDocumentoCompraDet.montoIgv = CDec(i.Cells(15).Value())
                    objDocumentoCompraDet.otrosTributos = 0 ' CDec(i.Cells(15).Value())
                    '**********************************************************************************
                    objDocumentoCompraDet.montokardexUS = CDec(i.Cells(11).Value())
                    objDocumentoCompraDet.montoIscUS = 0 'CDec(i.Cells(17).Value())
                    objDocumentoCompraDet.montoIgvUS = CDec(i.Cells(18).Value())
                    objDocumentoCompraDet.otrosTributosUS = 0 ' CDec(i.Cells(19).Value())


                Case Else
                    Select Case "01" ' strTipoNota
                        Case Notas_Credito.DEV_EXISTENCIA
                            'If Not CDec(i.Cells(7).Value()) > 0 Then
                            '    lblEstado.Text = "Ingrese una cantidad mayor a cero!"
                            '    Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(i.Index).Cells(7)
                            '    Me.dgvNuevoDoc.BeginEdit(True)
                            '    Exit Sub
                            'End If

                            'If Not CDec(i.Cells(10).Value()) > 0 Then
                            '    lblEstado.Text = "Ingrese un importe mayor a cero!"
                            '    Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(i.Index).Cells(10)
                            '    Me.dgvNuevoDoc.BeginEdit(True)
                            '    Exit Sub
                            'End If
                            objDocumentoCompraDet.monto1 = CDec(i.Cells(7).Value())
                            objDocumentoCompraDet.importe = CDec(i.Cells(10).Value())
                            objDocumentoCompraDet.importeUS = CDec(i.Cells(13).Value())
                            objDocumentoCompraDet.montokardex = CDec(i.Cells(8).Value())
                            objDocumentoCompraDet.montoIsc = 0 ' CDec(i.Cells(11).Value())
                            objDocumentoCompraDet.montoIgv = CDec(i.Cells(15).Value())
                            objDocumentoCompraDet.otrosTributos = 0 'CDec(i.Cells(15).Value())
                            '**********************************************************************************
                            objDocumentoCompraDet.montokardexUS = CDec(i.Cells(11).Value())
                            objDocumentoCompraDet.montoIscUS = 0 ' CDec(i.Cells(17).Value())
                            objDocumentoCompraDet.montoIgvUS = CDec(i.Cells(18).Value())
                            objDocumentoCompraDet.otrosTributosUS = 0 ' CDec(i.Cells(19).Value())

                        Case Notas_Credito.DR_REDUCCION_COSTOS,
                            Notas_Credito.DR_BENEFICIO, Notas_Credito.ERR_PRECIO

                            If Not CDec(i.Cells(10).Value()) > 0 Then
                                lblEstado.Text = "Ingrese un importe mayor a cero!"
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(i.Index).Cells(10)
                                Me.dgvNuevoDoc.BeginEdit(True)
                                Exit Sub
                            End If

                            objDocumentoCompraDet.monto1 = 0

                            objDocumentoCompraDet.importe = CDec(i.Cells(10).Value())
                            objDocumentoCompraDet.importeUS = CDec(i.Cells(13).Value())
                            objDocumentoCompraDet.montokardex = CDec(i.Cells(8).Value())
                            objDocumentoCompraDet.montoIsc = 0 'CDec(i.Cells(13).Value())
                            objDocumentoCompraDet.montoIgv = CDec(i.Cells(15).Value())
                            objDocumentoCompraDet.otrosTributos = 0 ' CDec(i.Cells(15).Value())
                            '**********************************************************************************
                            objDocumentoCompraDet.montokardexUS = CDec(i.Cells(11).Value())
                            objDocumentoCompraDet.montoIscUS = 0 ' CDec(i.Cells(17).Value())
                            objDocumentoCompraDet.montoIgvUS = CDec(i.Cells(18).Value())
                            objDocumentoCompraDet.otrosTributosUS = 0 ' CDec(i.Cells(19).Value())

                        Case Notas_Credito.ERR_CANTIDAD, Notas_Credito.BOF_REDUC_COSTO_IGUAL_COMPRA

                            If Not CDec(i.Cells(7).Value()) > 0 Then
                                lblEstado.Text = "Ingrese una cantidad mayor a cero!"
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(i.Index).Cells(7)
                                Me.dgvNuevoDoc.BeginEdit(True)
                                Exit Sub
                            End If

                            objDocumentoCompraDet.monto1 = CDec(i.Cells(7).Value())
                            objDocumentoCompraDet.importe = 0
                            objDocumentoCompraDet.importeUS = 0

                            objDocumentoCompraDet.montokardex = 0
                            objDocumentoCompraDet.montoIsc = 0
                            objDocumentoCompraDet.montoIgv = 0
                            objDocumentoCompraDet.otrosTributos = 0
                            '**********************************************************************************
                            objDocumentoCompraDet.montokardexUS = 0
                            objDocumentoCompraDet.montoIscUS = 0
                            objDocumentoCompraDet.montoIgvUS = 0
                            objDocumentoCompraDet.otrosTributosUS = 0
                    End Select

                    objDocumentoCompraDet.IdEstablecimiento = almacenSA.GetUbicar_almacenPorID(i.Cells(30).Value()).idEstablecimiento
                    objDocumentoCompraDet.almacenRef = CInt(i.Cells(30).Value())
            End Select
            objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
            objDocumentoCompraDet.CuentaProvedor = CuentaProveedor
            objDocumentoCompraDet.NombreProveedor = NomProveedor
            '   If dgvNuevoDoc.Rows(S).Cells(20).Value() = ENTITY_ACTIONS.INSERT Then
            If i.Cells(1).Value() = "1" Then '   ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES" Then
                objDocumentoCompraDet.destino = "1"
            ElseIf i.Cells(1).Value() = "2" Then '   ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV" Then
                objDocumentoCompraDet.destino = "2"
            ElseIf i.Cells(1).Value() = "3" Then '   ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "3"
            ElseIf i.Cells(1).Value() = "4" Then '   ADQUISICIONES NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "4"
            End If
            objDocumentoCompraDet.CuentaItem = i.Cells(22).Value()
            objDocumentoCompraDet.idItem = i.Cells(2).Value()
            objDocumentoCompraDet.descripcionItem = i.Cells(3).Value()
            objDocumentoCompraDet.DetalleItem = i.Cells(3).Value()
            objDocumentoCompraDet.tipoExistencia = i.Cells(21).Value()
            objDocumentoCompraDet.unidad1 = Nothing
            objDocumentoCompraDet.unidad2 = Nothing 'IDPRESENTACION
            objDocumentoCompraDet.monto2 = Nothing
            objDocumentoCompraDet.precioUnitario = CDec(i.Cells(9).Value())
            objDocumentoCompraDet.precioUnitarioUS = CDec(i.Cells(12).Value())



            objDocumentoCompraDet.preEvento = i.Cells(23).Value() '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
            objDocumentoCompraDet.bonificacion = i.Cells(29).Value()


            objDocumentoCompraDet.idPadreDTCompra = i.Cells(0).Value()
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = "Jiuni"
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))

            If txtGlosa.Text.Trim.Length > 0 Then
                objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
            Else
                objDocumentoCompraDet.Glosa = String.Concat("Por devolución de existencias", vbCrLf, "según/ ", Space(1), "NOTA DE CREDITO", Space(1), "Nro.", Space(1), txtSerie.Text, "-", txtNumero.Text, vbCrLf, "fecha: ", fecha)
            End If
            ' objDocumentoCompraDet.BonificacionMN =

            objDocumentoCompraDet.NumDoc = txtNumeroGuia.Text
            objDocumentoCompraDet.Serie = txtSerieGuia.Text
            objDocumentoCompraDet.TipoDoc = "99"
            ListaDetalle.Add(objDocumentoCompraDet)
            '   End If
        Next
        '---------------------------------------------------------------------------------
        If chDeposito.Checked = True Then
            DocCaja = ComprobanteCaja()
        End If

        Select Case cboOperacion.Text
            Case "DISMINUIR CANTIDAD"
                ListaTotales = ListaTotalesAlmacen()
            Case "DISMINUIR CANTIDAD E IMPORTE"

            Case "DEVOLUCION DE EXISTENCIAS", "DISMINUIR IMPORTE"
                ListaTotales = ListaTotalesAlmacen()
                AsientoNotaCredito()
                ndocumento.asiento = ListaAsientonTransito
            Case "BONIFICACIONES RECIBIDAS (OPC. Beneficios)"
                ListaTotales = ListaTotalesBonificacion()
                AsientoNotaCreditoOpcBenef()
                ndocumento.asiento = ListaAsientonTransito
            Case "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"
                ListaTotales = ListaTotalesAlmacenReducCostos()

        End Select

        'Select Case "01" 'strTipoNota

        '    Case Notas_Credito.ERR_CANTIDAD, Notas_Credito.BOF_REDUC_COSTO_IGUAL_COMPRA


        '    Case Notas_Credito.DEV_EXISTENCIA, Notas_Credito.DR_REDUCCION_COSTOS,
        '        Notas_Credito.ERR_PRECIO



        '    Case Notas_Credito.DR_BENEFICIO
        '        AsientoBeneficios_02(CDec(lblTotalAdquisiones.Text), CDec(lblTotalUS.Text))
        '        ndocumento.asiento = ListaAsientonTransito
        'End Select
        '---------------------------------------------------------------------------------

        'COMPROBANTE EXCEDENTE -(Doucumento venta abarrotes)----------------------------------------------------------------------------------------

        If TipoCompra = TIPO_COMPRA.COMPRA_PAGADA Then
            'If rbDocPagado.Checked = True Then
            '    '    nDocumentoExce = DocExcedente(CInt(lblIdDoc.Text), CDec(lblTotalAdquisiones.Text), CDec(lblTotalUS.Text))
            'End If
        ElseIf TipoCompra = TIPO_COMPRA.COMPRA_AL_CREDITO Then
            'Dim varDocExMN As Decimal = CDec(CustomToolTip.lblSaldoMN.Text) - CDec(lblTotalAdquisiones.Text)
            'Dim varDocExMe As Decimal = Math.Round(varDocExMN / CDec(txtTipoCambio.NumericValue), 2)
            'If varDocExMN < 0 Then
            '    '    nDocumentoExce = DocExcedente(CInt(lblIdDoc.Text), varDocExMN * -1, varDocExMe * -1)
            'End If
        End If

        '*************************************************************************************************************
        'ASIGNANDO LA GUIA DE REMISION SEGUN EL CASO
        Select Case "01" 'strTipoNota
            Case Notas_Credito.DEV_EXISTENCIA, Notas_Credito.ERR_CANTIDAD, Notas_Credito.BOF_REDUC_COSTO_IGUAL_COMPRA
                GuiaRemision(ndocumento)
        End Select
        '*************************************************************************************************************

        ndocumento.documentocompra.documentocompradetalle = ListaDetalle


        Dim xcod As Integer = CompraSA.SaveCompraNotaCredito(ndocumento, ListaTotales, DocCaja)
        lblEstado.Text = "nota de crédito registrada!"
        lblEstado.Image = My.Resources.ok4
        Dispose()
    End Sub
#End Region

    Private Sub frmCredito_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCredito_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        toolTip = New Popup(ucInfoCompra)
        toolTip.AutoClose = False
        toolTip.FocusOnOpen = False
        toolTip.ShowingAnimation = PopupAnimations.Blend
        InfoCompra(Sys.Inicio)
        btnInfoCompra.Image = My.Resources.b_drop
        TextBoxExt1.Metrocolor = Color.Red
        TextBoxExt1.FocusBorderColor = Color.Red


        ContextMenuStrip = New ContextMenuStrip()
        ContextMenuStrip.Items.Add("Seleccionar item")
        AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
        AddHandler Me.dgvMov.TableControlMouseDown, AddressOf gridGroupingControl1_TableControlMouseDown

        txtPeriodo.Select()
    End Sub

    Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim nInsumoSA As New detalleitemsSA
        Dim n As New GInsumo()
        Dim tablaSA As New tablaDetalleSA
        Dim objInsumo As GInsumo = GInsumo.InstanceSingle
        If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
            If e.ClickedItem.Text = "Seleccionar item" Then
                Select Case Me.dgvMov.Table.CurrentRecord.GetValue("tipoEx")
                    Case "GS"
                        If CDec(Me.dgvMov.Table.CurrentRecord.GetValue("importeMN")) > 0 Then
                            Try
                                '   If lsvCanasta.SelectedItems.Count > 0 Then

                                objInsumo.Clear()
                                objInsumo.Secuencia = Me.dgvMov.Table.CurrentRecord.GetValue("sec")
                                'If CStr(lsvCanasta.SelectedItems(0).SubItems(9).Text).Trim.Length > 0 Then
                                '    objInsumo.IdActividadRecurso = lsvCanasta.SelectedItems(0).SubItems(9).Text
                                'End If
                                objInsumo.IdInsumo = Me.dgvMov.Table.CurrentRecord.GetValue("idItem")
                                objInsumo.origenProducto = Me.dgvMov.Table.CurrentRecord.GetValue("grav")
                                objInsumo.descripcionItem = Me.dgvMov.Table.CurrentRecord.GetValue("item")
                                objInsumo.tipoExistencia = Me.dgvMov.Table.CurrentRecord.GetValue("tipoEx")

                                objInsumo.Cantidad = Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")
                                objInsumo.PU = 0 ' lsvCanasta.SelectedItems(0).SubItems(6).Text
                                objInsumo.Total = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN")
                                Select Case Me.dgvMov.Table.CurrentRecord.GetValue("tipoEx")
                                    Case "GS"

                                    Case Else
                                        With nInsumoSA.InvocarProductoID(Me.dgvMov.Table.CurrentRecord.GetValue("idItem"))
                                            objInsumo.unidad1 = .unidad1
                                            objInsumo.origenProducto = .origenProducto
                                            objInsumo.cuenta = .cuenta
                                            objInsumo.presentacion = .presentacion
                                            objInsumo.Nombrepresentacion = tablaSA.GetUbicarTablaID(21, .presentacion).descripcion
                                        End With
                                        objInsumo.IdAlmacen = Me.dgvMov.Table.CurrentRecord.GetValue("almacenRef")
                                End Select

                                '   End If

                                If Not IsNothing(objInsumo.descripcionItem) Then
                                    If ExisteDatoEnGrid(objInsumo.IdInsumo) = False Then
                                        dgvNuevoDoc.Rows.Add(objInsumo.Secuencia, objInsumo.origenProducto,
                                                       objInsumo.IdInsumo,
                                                       objInsumo.descripcionItem,
                                                       objInsumo.presentacion,
                                                       objInsumo.Nombrepresentacion,
                                                       objInsumo.unidad1,
                                                       objInsumo.Cantidad,
                                                       "0.00",
                                                       "0.00",
                                                       "0.00",
                                                       "0.00", 0,
                                                        0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                                        objInsumo.tipoExistencia, objInsumo.cuenta, objInsumo.IdActividadRecurso, Nothing,
                                                         Nothing, Nothing, Nothing, Nothing, Nothing, objInsumo.IdAlmacen,
                                                         Me.dgvMov.Table.CurrentRecord.GetValue("cantCompra"), Me.dgvMov.Table.CurrentRecord.GetValue("compraMN"),
                                                         Me.dgvMov.Table.CurrentRecord.GetValue("cantidad"),
                                                         Me.dgvMov.Table.CurrentRecord.GetValue("importeMN"),
                                                         Me.dgvMov.Table.CurrentRecord.GetValue("importeME"))
                                    End If
                                End If
                                If dgvNuevoDoc.Rows.Count > 0 Then
                                    CellEndEditRefresh()
                                End If

                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try
                        Else

                        End If


                    Case Else
                        If CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")) > 0 Then
                            Try
                                '   If lsvCanasta.SelectedItems.Count > 0 Then

                                objInsumo.Clear()
                                objInsumo.Secuencia = Me.dgvMov.Table.CurrentRecord.GetValue("sec")
                                'If CStr(lsvCanasta.SelectedItems(0).SubItems(9).Text).Trim.Length > 0 Then
                                '    objInsumo.IdActividadRecurso = lsvCanasta.SelectedItems(0).SubItems(9).Text
                                'End If
                                objInsumo.IdInsumo = Me.dgvMov.Table.CurrentRecord.GetValue("idItem")
                                objInsumo.origenProducto = Me.dgvMov.Table.CurrentRecord.GetValue("grav")
                                objInsumo.descripcionItem = Me.dgvMov.Table.CurrentRecord.GetValue("item")
                                objInsumo.tipoExistencia = Me.dgvMov.Table.CurrentRecord.GetValue("tipoEx")

                                objInsumo.Cantidad = Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")
                                objInsumo.PU = 0 ' lsvCanasta.SelectedItems(0).SubItems(6).Text
                                objInsumo.Total = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN")
                                Select Case Me.dgvMov.Table.CurrentRecord.GetValue("tipoEx")
                                    Case "GS"

                                    Case Else
                                        With nInsumoSA.InvocarProductoID(Me.dgvMov.Table.CurrentRecord.GetValue("idItem"))
                                            objInsumo.unidad1 = .unidad1
                                            objInsumo.origenProducto = .origenProducto
                                            objInsumo.cuenta = .cuenta
                                            objInsumo.presentacion = .presentacion
                                            objInsumo.Nombrepresentacion = tablaSA.GetUbicarTablaID(21, .presentacion).descripcion
                                        End With
                                        objInsumo.IdAlmacen = Me.dgvMov.Table.CurrentRecord.GetValue("almacenRef")
                                End Select

                                '   End If

                                If Not IsNothing(objInsumo.descripcionItem) Then
                                    If ExisteDatoEnGrid(objInsumo.IdInsumo) = False Then
                                        dgvNuevoDoc.Rows.Add(objInsumo.Secuencia, objInsumo.origenProducto,
                                                       objInsumo.IdInsumo,
                                                       objInsumo.descripcionItem,
                                                       objInsumo.presentacion,
                                                       objInsumo.Nombrepresentacion,
                                                       objInsumo.unidad1,
                                                       objInsumo.Cantidad,
                                                       "0.00",
                                                       "0.00",
                                                       "0.00",
                                                       "0.00", 0,
                                                        0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                                        objInsumo.tipoExistencia, objInsumo.cuenta, objInsumo.IdActividadRecurso, Nothing,
                                                         Nothing, Nothing, Nothing, Nothing, Nothing, objInsumo.IdAlmacen,
                                                         Me.dgvMov.Table.CurrentRecord.GetValue("cantCompra"), Me.dgvMov.Table.CurrentRecord.GetValue("compraMN"),
                                                         Me.dgvMov.Table.CurrentRecord.GetValue("cantidad"),
                                                         Me.dgvMov.Table.CurrentRecord.GetValue("importeMN"),
                                                         Me.dgvMov.Table.CurrentRecord.GetValue("importeME"))
                                    End If
                                End If
                                If dgvNuevoDoc.Rows.Count > 0 Then
                                    CellEndEditRefresh()
                                End If

                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try
                        Else

                        End If
                End Select


            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub gridGroupingControl1_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        Dim row As Integer = 0, col As Integer = 0
        Me.dgvMov.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = Me.dgvMov.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
        Else
            'If it is not column header cell
            dgvMov.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub


    Private Sub PegarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        txtConf.Text = ToolStripMenuItem1.Text
        'txtResena.Text = "Con movimiento de kardex: Importe y cantidad, afecta a cuentas por pagar."
        strTipoNota = Notas_Credito.DEV_EXISTENCIA
        Can1.Visible = True
        Can1.ReadOnly = False
        Can1.DefaultCellStyle.BackColor = Color.Yellow
        '  Can1.HeaderCell.Style.BackColor = Color.Yellow
        ImporteNeto.ReadOnly = False
        ImporteNeto.DefaultCellStyle.BackColor = Color.Yellow
        ImporteUS.ReadOnly = False
    End Sub

    Private Sub ReducciónDeCostosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ReducciónDeCostosToolStripMenuItem.Click
        txtConf.Text = ReducciónDeCostosToolStripMenuItem.Text
        strTipoNota = Notas_Credito.DR_REDUCCION_COSTOS
        '  txtResena.Text = "Con movimiento de kardex: Importe, afecta a cuentas por pagar."
        Can1.Visible = False
        Can1.ReadOnly = True
        Can1.DefaultCellStyle.BackColor = DefaultBackColor

        ImporteNeto.ReadOnly = False
        ImporteNeto.DefaultCellStyle.BackColor = Color.Yellow
        ImporteUS.ReadOnly = False
    End Sub

    Private Sub BeneficiosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BeneficiosToolStripMenuItem.Click
        txtConf.Text = BeneficiosToolStripMenuItem.Text
        strTipoNota = Notas_Credito.DR_BENEFICIO
        '      txtResena.Text = "Sin movimiento de kardex, afecta a cuentas por pagar."
        Can1.Visible = False
        Can1.ReadOnly = True
        Can1.DefaultCellStyle.BackColor = DefaultBackColor

        ImporteNeto.ReadOnly = False
        ImporteNeto.DefaultCellStyle.BackColor = Color.Yellow
        ImporteUS.ReadOnly = False
    End Sub

    Private Sub EnPrecioToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EnPrecioToolStripMenuItem.Click
        txtConf.Text = EnPrecioToolStripMenuItem.Text
        strTipoNota = Notas_Credito.ERR_PRECIO
        '  txtResena.Text = "Con movimiento de kardex: Importe, afecta a cuentas por pagar."
        Can1.Visible = False
        Can1.ReadOnly = True
        Can1.DefaultCellStyle.BackColor = DefaultBackColor

        ImporteNeto.ReadOnly = False
        ImporteNeto.DefaultCellStyle.BackColor = Color.Yellow
        ImporteUS.ReadOnly = False
    End Sub

    Private Sub EnCantidadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EnCantidadToolStripMenuItem.Click
        txtConf.Text = EnCantidadToolStripMenuItem.Text
        strTipoNota = Notas_Credito.ERR_CANTIDAD
        '    txtResena.Text = "Con movimiento de kardex: Cantidad, no afecta a cuentas por pagar."
        Can1.ReadOnly = False
        Can1.DefaultCellStyle.BackColor = Color.Yellow

        ImporteNeto.ReadOnly = True
        ImporteNeto.DefaultCellStyle.BackColor = DefaultBackColor
        ImporteUS.ReadOnly = True
    End Sub

    Private Sub ReducciónDeCostoProductoIgualAlCompradoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ReducciónDeCostoProductoIgualAlCompradoToolStripMenuItem.Click
        txtConf.Text = ReducciónDeCostoProductoIgualAlCompradoToolStripMenuItem.Text
        strTipoNota = Notas_Credito.BOF_REDUC_COSTO_IGUAL_COMPRA

        Can1.Visible = True
        Can1.ReadOnly = False
        Can1.DefaultCellStyle.BackColor = Color.Yellow
        '  Can1.HeaderCell.Style.BackColor = Color.Yellow
        ImporteNeto.ReadOnly = True
        ImporteNeto.DefaultCellStyle.BackColor = DefaultBackColor
        ImporteUS.ReadOnly = True
    End Sub

    Private Sub ReducciónDeCostoProductoIgualAlCompradoToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ReducciónDeCostoProductoIgualAlCompradoToolStripMenuItem1.Click
        txtConf.Text = ReducciónDeCostoProductoIgualAlCompradoToolStripMenuItem1.Text
        strTipoNota = Notas_Credito.BOF_REDUC_COSTO_DISTINTO_COMPRA
    End Sub

    Private Sub BeneficioDeTercerosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BeneficioDeTercerosToolStripMenuItem.Click
        txtConf.Text = BeneficioDeTercerosToolStripMenuItem.Text
        strTipoNota = Notas_Credito.BOF_BENEFICIO_TERCEROS
    End Sub

    Private Sub btnInfoCompra_Click(sender As System.Object, e As System.EventArgs) Handles btnInfoCompra.Click
        Me.Cursor = Cursors.WaitCursor
        If btnInfoCompra.Tag = "YES" Then
            InfoCompra(Sys.Proceso)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnInfoCompra_MouseLeave(sender As Object, e As System.EventArgs) Handles btnInfoCompra.MouseLeave
        toolTip.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

    End Sub

    Private Sub LinkLabel1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LinkLabel1.MouseClick
        LinkLabel1.ContextMenuStrip.Show(LinkLabel1, e.Location)
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        If dgvNuevoDoc.Rows.Count > 0 Then

            If Not IsNothing(dgvNuevoDoc.CurrentRow) Then



                If dgvNuevoDoc.Item(20, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT Then
                    dgvNuevoDoc.Rows.RemoveAt(dgvNuevoDoc.CurrentRow.Index)
                ElseIf dgvNuevoDoc.Item(20, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE Then
                    '   DeleteFilaDetalle(dgvNuevoDoc.Item(0, dgvNuevoDoc.CurrentRow.Index).Value)
                    dgvNuevoDoc.Item(20, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE
                    Dim pos As Integer = Me.dgvNuevoDoc.CurrentRow.Index

                    dgvNuevoDoc.CurrentCell = Nothing
                    Me.dgvNuevoDoc.Rows(pos).Visible = False


                End If
                If dgvNuevoDoc.Rows.Count > 0 Then
                    CellEndEditRefresh()
                Else
                    lblTotalAdquisiones.Text = "0.00"
                    lblTotalUS.Text = "0.00"
                    lblTotalBaseUS.Text = "0.00"
                    lblTotalBase.Text = "0.00"
                    lblTotalMontoIgvUS.Text = "0.00"
                    lblTotalMontoIgv.Text = "0.00"
                End If
            End If
        End If
    End Sub

    Private Sub dgvNuevoDoc_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellClick
        Select Case cboOperacion.Text
            Case "BONIFICACIONES RECIBIDAS (OPC. Beneficios)", "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"
                If Not dgvNuevoDoc.Item(21, dgvNuevoDoc.CurrentRow.Index).Value = "GS" Then
                    Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
                    datos.Clear()
                    If e.ColumnIndex = 39 Then
                        'Se ha pulsado sobre un botón
                        If e.RowIndex > -1 Then
                            With frmModalAlmacen
                                Tag = 0
                                .ObtenerAlmacenes(GEstableciento.IdEstablecimiento)
                                .StartPosition = FormStartPosition.CenterParent
                                .ShowDialog()
                                If datos.Count > 0 Then
                                    dgvNuevoDoc.Item(30, dgvNuevoDoc.CurrentRow.Index).Value = datos(0).ID
                                    dgvNuevoDoc.Item(39, dgvNuevoDoc.CurrentRow.Index).Value = datos(0).NombreEntidad
                                End If
                            End With
                        End If
                    End If
                End If
        End Select


    End Sub

    Private Sub dgvNuevoDoc_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellContentClick

    End Sub

    Private Sub dgvNuevoDoc_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellEndEdit
        Dim headerText As String = _
     dgvNuevoDoc.Columns(e.ColumnIndex).Name

        ' Abort validation if cell is not in the CompanyName column.

        dgvNuevoDoc.Rows(e.RowIndex).ErrorText = String.Empty
        If dgvNuevoDoc.Rows.Count > 0 Then
            'DECLARANDO VARIABLES
            Dim colDestinoGravado As Decimal = 0
            colDestinoGravado = dgvNuevoDoc.Item(1, dgvNuevoDoc.CurrentRow.Index).Value

            Dim colCantidad As Decimal = 0
            Select Case dgvNuevoDoc.Item(21, dgvNuevoDoc.CurrentRow.Index).Value
                Case "GS"
                    colCantidad = 1
                    dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value = 1
                Case Else
                    If Not CStr(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value).Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese una cantidad válida!"
                        lblEstado.Image = My.Resources.warning2
                        'Timer1.Enabled = True
                        'TiempoEjecutar(5)
                        Exit Sub
                    Else
                        colCantidad = dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value
                    End If
            End Select

            Dim colBI As Decimal = 0
            Dim colBI_ME As Decimal = 0
            Dim colIGV_ME As Decimal = 0
            Dim colIGV As Decimal = 0

            Dim saldoCan As Decimal = 0
            Dim saldoMN As Decimal = 0
            Dim saldoME As Decimal = 0

            Dim colMN As Decimal = 0
            Dim colME As Decimal = 0
            '  Dim colME As Decimal = Math.Round(CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value) / CDec(txtTipoCambio.Value), 2)
            Dim colPrecUnit As Decimal = 0 ' dgvNuevoDoc.Item(34, dgvNuevoDoc.CurrentRow.Index).Value / dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value
            Dim colPrecUnitUSD As Decimal = 0 ' dgvNuevoDoc.Item(35, dgvNuevoDoc.CurrentRow.Index).Value / dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value


            '     If colCantidad > 0 Then



            Select Case e.ColumnIndex

                Case 8, 7
                    If Not CStr(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value).Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese un importe válido!"
                        lblEstado.Image = My.Resources.warning2
                        Exit Sub
                    Else
                        colBI = dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value
                    End If


                    colIGV = Math.Round(colBI * 0.18, 2) 'Math.Round((colMN / 1.18) * 0.18, 2)

                    colMN = colBI + colIGV
                    dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value = colMN
                    If colCantidad > 0 Then
                        colPrecUnit = Math.Round(colMN / colCantidad, 2)
                        saldoCan = CDec(dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value) - CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value)
                    Else
                        colPrecUnit = 0
                        saldoCan = 0
                    End If

                    saldoMN = CDec(dgvNuevoDoc.Item(34, dgvNuevoDoc.CurrentRow.Index).Value) - CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value)
                    Select Case TipoCompra
                        Case TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION, TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
                            dgvNuevoDoc.Item(37, dgvNuevoDoc.CurrentRow.Index).Value = CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value)
                        Case Else
                            If saldoMN < 0 Then
                                saldoMN = saldoMN * -1
                                dgvNuevoDoc.Item(37, dgvNuevoDoc.CurrentRow.Index).Value = saldoMN.ToString("N2")
                                chProceso.Checked = False
                            Else
                                dgvNuevoDoc.Item(37, dgvNuevoDoc.CurrentRow.Index).Value = "0.00"
                                chProceso.Checked = True
                            End If
                    End Select


                    dgvNuevoDoc.Item(36, dgvNuevoDoc.CurrentRow.Index).Value = saldoCan.ToString("N2")


                    Select Case txtIdComprobanteNota.Text
                        Case "08"
                            If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "kardex" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "OTCus" Then
                                totales_xx()
                            End If
                        Case "03", "02"
                            If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "kardex" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "OTCus" Then
                                If txtTipoCambio.Value = 0.0 Then
                                    MsgBox("Ingrese Tipo de Cambio..!")
                                    txtTipoCambio.Focus()
                                    txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                                    Exit Sub
                                End If
                                '   Dim cantidad As Decimal = Convert.ToDecimal(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value())
                                '  Dim neto As Decimal = Convert.ToDecimal(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value())
                                '  Dim netous As Decimal = Convert.ToDecimal(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value())
                                Dim NUDIGV_VALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
                                If colCantidad = 0 And colMN = 0 And colME = 0 Then
                                    dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    Exit Sub

                                ElseIf colCantidad = 0 Then
                                    If Moneda = 1 Then
                                        ' DATOS SOLES
                                        Select Case colDestinoGravado
                                            Case "4"
                                                dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colBI.ToString("N2")

                                            Case Else
                                                dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2")

                                        End Select

                                    End If
                                ElseIf colCantidad > 0 Then
                                    If Moneda = 1 Then
                                        ' DATOS SOLES
                                        If dgvNuevoDoc.Item(1, dgvNuevoDoc.CurrentRow.Index).Value = "4" Then
                                            dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2")
                                            dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / colCantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                            dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colBI.ToString("N2") 'CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")

                                        Else
                                            dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") 'CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                            dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")

                                        End If
                                    End If
                                End If
                                'totales()
                                'subTotales("All")
                                totales_xx()
                                TotalesCabeceras()
                            End If
                            '**********************************************************************************************************************************************************************************
                            '**********************************************************************************************************************************************************************************
                            '**********************************************************************************************************************************************************************************
                        Case Else
                            If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "kardex" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "OTCus" Then
                                If txtTipoCambio.Value = 0.0 Then
                                    MsgBox("Ingrese Tipo de Cambio..!")
                                    txtTipoCambio.Focus()
                                    txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                                    Exit Sub
                                End If
                                ' Dim cantidad As Decimal = Convert.ToDecimal(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value())
                                ' Dim neto As Decimal = Convert.ToDecimal(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value())
                                ' Dim netous As Decimal = Convert.ToDecimal(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value())
                                Dim NUDIGV_VALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
                                If colCantidad = 0 And colMN = 0 And colME = 0 Then
                                    dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    Exit Sub
                                    'ElseIf neto > 0 And cantidad = 0 Then
                                    '    dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    '    dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    '    Exit Sub
                                ElseIf colCantidad = 0 Then

                                    If Moneda = 1 Then
                                        ' DATOS SOLES
                                        Select Case colDestinoGravado
                                            Case "4"

                                                dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colBI.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES

                                            Case Else

                                                If dgvNuevoDoc.Item(27, dgvNuevoDoc.CurrentRow.Index).Value() = "S" Then
                                                    dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colBI.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES

                                                Else

                                                    dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES

                                                    dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colBI.ToString("N2") ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                                    dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV.ToString("N2")  ' Math.Round(CDec(neto - CDec(dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                                    'dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() / txtTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES
                                                End If
                                        End Select

                                    End If
                                ElseIf colCantidad > 0 Then
                                    If Moneda = 1 Then
                                        ' DATOS SOLES
                                        If colDestinoGravado = "4" Then
                                            dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES

                                            dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colBI.ToString("N2") ' CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")

                                        Else
                                            If dgvNuevoDoc.Item(27, dgvNuevoDoc.CurrentRow.Index).Value() = "S" Then
                                                dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") '  CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                                dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES

                                                dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colBI.ToString("N2") ' CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")

                                            Else
                                                dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                                dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES

                                                dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")
                                                dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colBI.ToString("N2") ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                                dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV.ToString("N2") ' Math.Round(CDec(neto - CDec(dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item


                                            End If
                                        End If
                                    End If
                                End If
                                totales_xx()
                                TotalesCabeceras()
                            End If
                    End Select

                Case 11, 7 ' MONEDA EXTRANJERA

                    If Not CStr(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value).Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese un importe válido!"
                        lblEstado.Image = My.Resources.warning2
                        Exit Sub
                    Else
                        colBI_ME = dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value
                    End If

                    colIGV_ME = Math.Round(colBI_ME * 0.18, 2) 'Math.Round((colMN / 1.18) * 0.18, 2)

                    colME = colBI_ME + colIGV_ME
                    dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value = colME
                    If colCantidad > 0 Then
                        colPrecUnitUSD = Math.Round(colME / colCantidad, 2)
                        saldoCan = CDec(dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value) - CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value)
                    Else
                        colPrecUnitUSD = 0
                        saldoCan = 0
                    End If

                    saldoME = CDec(dgvNuevoDoc.Item(35, dgvNuevoDoc.CurrentRow.Index).Value) - CDec(dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value)

                    dgvNuevoDoc.Item(36, dgvNuevoDoc.CurrentRow.Index).Value = saldoCan.ToString("N2")

                    Select Case TipoCompra
                        Case TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION, TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
                            dgvNuevoDoc.Item(38, dgvNuevoDoc.CurrentRow.Index).Value = CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value)
                        Case Else
                            If saldoME < 0 Then
                                saldoME = saldoME * -1
                                dgvNuevoDoc.Item(38, dgvNuevoDoc.CurrentRow.Index).Value = saldoME.ToString("N2")
                                chProceso.Checked = False
                            Else
                                dgvNuevoDoc.Item(38, dgvNuevoDoc.CurrentRow.Index).Value = "0.00"
                                chProceso.Checked = True
                            End If
                    End Select

                    Select Case txtIdComprobanteNota.Text
                        Case "08"
                            If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Kardexus" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "OTCus" Then
                                totales_xx()
                            End If
                        Case "03", "02"
                            If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Kardexus" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "OTCus" Then
                                If txtTipoCambio.Value = 0.0 Then
                                    MsgBox("Ingrese Tipo de Cambio..!")
                                    txtTipoCambio.Focus()
                                    txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                                    Exit Sub
                                End If

                                Dim NUDIGV_VALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
                                If colCantidad = 0 And colMN = 0 And colME = 0 Then
                                    dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    Exit Sub

                                ElseIf colCantidad = 0 Then

                                    If Moneda = 1 Then
                                        ' DATOS SOLES
                                        Select Case colDestinoGravado
                                            Case "4"

                                                dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2")  ' MONTO TOTAL DOLARES

                                            Case Else

                                                dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES

                                        End Select
                                    End If
                                ElseIf colCantidad > 0 Then
                                    If Moneda = 1 Then
                                        ' DATOS SOLES
                                        If dgvNuevoDoc.Item(1, dgvNuevoDoc.CurrentRow.Index).Value = "4" Then
                                            dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2")

                                            dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / colCantidad), NumDigitos).ToString("N2")
                                            dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES

                                        Else
                                            dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") 'CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES

                                        End If
                                    End If
                                End If
                                'totales()
                                'subTotales("All")
                                totales_xx()
                                TotalesCabeceras()
                            End If

                        Case Else
                            If e.ColumnIndex = 11 Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "OTCus" Then
                                If txtTipoCambio.Value = 0.0 Then
                                    MsgBox("Ingrese Tipo de Cambio..!")
                                    txtTipoCambio.Focus()
                                    txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                                    Exit Sub
                                End If
                                ' Dim cantidad As Decimal = Convert.ToDecimal(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value())
                                ' Dim neto As Decimal = Convert.ToDecimal(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value())
                                ' Dim netous As Decimal = Convert.ToDecimal(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value())
                                Dim NUDIGV_VALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
                                If colCantidad = 0 And colMN = 0 And colME = 0 Then
                                    dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    Exit Sub

                                ElseIf colCantidad = 0 Then

                                    If Moneda = 1 Then
                                        ' DATOS SOLES
                                        Select Case colDestinoGravado
                                            Case "4"
                                                dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES


                                            Case Else

                                                If dgvNuevoDoc.Item(27, dgvNuevoDoc.CurrentRow.Index).Value() = "S" Then

                                                    dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES

                                                Else

                                                    dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES

                                                    dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                                    dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV_ME.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() - CDec(dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                                    'dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() / txtTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES
                                                End If
                                        End Select

                                    End If
                                ElseIf colCantidad > 0 Then
                                    If Moneda = 1 Then
                                        ' DATOS SOLES
                                        If colDestinoGravado = "4" Then
                                            dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES

                                        Else
                                            If dgvNuevoDoc.Item(27, dgvNuevoDoc.CurrentRow.Index).Value() = "S" Then
                                                dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") '  CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                                dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                                dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES

                                            Else
                                                dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                                dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                                dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES

                                                dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                                dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV_ME.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() - CDec(dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                                'dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() / txtTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES

                                            End If
                                        End If
                                    End If
                                End If
                                'totales()
                                'subTotales("All")
                                totales_xx()
                                TotalesCabeceras()
                            End If
                    End Select

            End Select



        End If
    End Sub

    Private Sub dgvNuevoDoc_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvNuevoDoc.CellFormatting
        If e.RowIndex > -1 Then
            If e.ColumnIndex = Me.dgvNuevoDoc.Columns("Gravado").Index _
AndAlso (e.Value IsNot Nothing) Then

                With Me.dgvNuevoDoc.Rows(e.RowIndex).Cells(e.ColumnIndex)

                    If e.Value.Equals("1") Then
                        .ToolTipText = "1: ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES"
                    ElseIf e.Value.Equals("2") Then
                        .ToolTipText = "2: ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV"
                    ElseIf e.Value.Equals("3") Then
                        .ToolTipText = "3: ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS"
                    ElseIf e.Value.Equals("4") Then
                        .ToolTipText = "4: ADQUISICIONES NO GRAVADAS"
                    End If

                End With

            End If

            Select Case cboOperacion.Text
                Case "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"
                    If e.ColumnIndex = Me.dgvNuevoDoc.Columns("colFlagBonif").Index _
AndAlso (e.Value IsNot Nothing) Then

                        If e.Value.Equals("=!") Then
                            Me.dgvNuevoDoc.Rows(e.RowIndex).Cells(7).ReadOnly = True
                        ElseIf e.Value.Equals("=") Then
                            Me.dgvNuevoDoc.Rows(e.RowIndex).Cells(7).ReadOnly = False
                            Me.dgvNuevoDoc.Rows(e.RowIndex).Cells(8).ReadOnly = True
                            Me.dgvNuevoDoc.Rows(e.RowIndex).Cells(11).ReadOnly = True
                        End If
                    End If
            End Select


            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                If e.ColumnIndex = Me.dgvNuevoDoc.Columns("Can1").Index _
AndAlso (e.Value IsNot Nothing) Then
                    dgvNuevoDoc.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = "Cantidad máxima: " & CDec(dgvNuevoDoc.Rows(e.RowIndex).Cells(31).Value).ToString("N2")

                    If dgvNuevoDoc.Rows(e.RowIndex).Cells(27).Value = "S" Then

                    Else
                        If CDec(dgvNuevoDoc.Rows(e.RowIndex).Cells(7).Value) > CDec(dgvNuevoDoc.Rows(e.RowIndex).Cells(31).Value) Then
                            lblEstado.Text = "La cantidad ingresada excede a la cantidad del comprobante!"

                            dgvNuevoDoc.Rows(e.RowIndex).Cells(7).Value = 0
                            dgvNuevoDoc.Rows(e.RowIndex).Cells(9).Value = 0
                            dgvNuevoDoc.Rows(e.RowIndex).Cells(12).Value = 0
                        End If
                    End If

                ElseIf e.ColumnIndex = Me.dgvNuevoDoc.Columns("ImporteNeto").Index _
    AndAlso (e.Value IsNot Nothing) Then
                    dgvNuevoDoc.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = "Importe máximo: " & CDec(dgvNuevoDoc.Rows(e.RowIndex).Cells(32).Value).ToString("N2")
                    If CDec(dgvNuevoDoc.Rows(e.RowIndex).Cells(10).Value) > CDec(dgvNuevoDoc.Rows(e.RowIndex).Cells(32).Value) Then

                        If dgvNuevoDoc.Rows(e.RowIndex).Cells(27).Value = "S" Then

                        Else
                            lblEstado.Text = "El importe ingresado es mayor al de origen, ingrese un valor menor!"

                            dgvNuevoDoc.Rows(e.RowIndex).Cells(10).Value = 0
                            dgvNuevoDoc.Rows(e.RowIndex).Cells(13).Value = 0
                            dgvNuevoDoc.Rows(e.RowIndex).Cells(9).Value = 0
                            dgvNuevoDoc.Rows(e.RowIndex).Cells(12).Value = 0
                        End If

                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgvNuevoDoc_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellValueChanged

    End Sub

    Private Sub dgvNuevoDoc_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgvNuevoDoc.CurrentCellDirtyStateChanged
        Try
            If dgvNuevoDoc.IsCurrentCellDirty Then
                dgvNuevoDoc.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If

            If TypeOf dgvNuevoDoc.CurrentCell Is DataGridViewCheckBoxCell Then
                dgvNuevoDoc.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If


        Catch
        End Try
    End Sub

    Private Sub dgvNuevoDoc_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvNuevoDoc.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf Validar_Numeros
    End Sub

    Private Sub dgvNuevoDoc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvNuevoDoc.KeyDown
        Dim conteo As Integer = dgvNuevoDoc.Rows.Count
        Try
            If e.KeyCode = Keys.Enter Then
                Select Case (dgvNuevoDoc.CurrentCell.ColumnIndex)
                    Case 7
                        If Moneda = 1 Then
                            If conteo = 1 Then
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(8, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            Else
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(8, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            End If
                        Else
                            If conteo = 1 Then
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(11, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            Else
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(11, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            End If
                        End If
                    Case 3
                        Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(0, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                    Case 10 Or 11
                        Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(23, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                End Select
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtSerieGuia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerieGuia.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtNumeroGuia.Select()
        End If
    End Sub

    Private Sub txtSerieGuia_LostFocus(sender As Object, e As System.EventArgs) Handles txtSerieGuia.LostFocus
        If txtSerieGuia.Text.Trim.Length > 0 Then
            txtSerieGuia.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
        End If
    End Sub

    Private Sub txtNumeroGuia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumeroGuia.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtGlosa.Text = (String.Concat("Operación: ", cboOperacion.Text.Trim, vbCrLf, "Por nota de credito", vbCrLf, "según/ ", Space(1), "documento", Space(1), "Nro.", Space(1), txtSerie.Text, "-", txtNumero.Text, vbCrLf, "fecha: ", fecha))
            txtTipoCambio.Select()
        End If
    End Sub

    Private Sub txtNumeroGuia_LostFocus(sender As Object, e As System.EventArgs) Handles txtNumeroGuia.LostFocus
        If txtNumeroGuia.Text.Trim.Length > 0 Then
            txtNumeroGuia.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))
        End If
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtGlosa.Text = (String.Concat("Operación: ", cboOperacion.Text.Trim, vbCrLf, "Por nota de credito", vbCrLf, "según/ ", Space(1), "documento", Space(1), "Nro.", Space(1), txtSerie.Text, "-", txtNumero.Text, vbCrLf, "fecha: ", fecha))
            txtNumero.Select()
        End If
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As System.EventArgs) Handles txtSerie.LostFocus
        If txtSerie.Text.Trim.Length > 0 Then
            txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
        End If
    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtSerieGuia.Select()
        End If
    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As System.EventArgs) Handles txtNumero.LostFocus
        Try
            If txtNumero.Text.Trim.Length > 0 Then
                txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))
            End If
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message)
        End Try

    End Sub

    Private Sub txtConf_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtConf.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtSerie.Select()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            fecha = New DateTime(txtFechaComprobante.Value.Year, txtFechaComprobante.Value.Month, txtFechaComprobante.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        Else
            fecha = New DateTime(fecha.Year, fecha.Month, txtFechaComprobante.Value.Day, txtFechaComprobante.Value.Hour, txtFechaComprobante.Value.Minute, txtFechaComprobante.Value.Second)
        End If
        If CDec(lblBonificaMN.Text) > 0 Then
            chDeposito.Enabled = True
        Else
            chDeposito.Enabled = False
        End If
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgvNuevoDoc.Rows.Count > 0 Then
                Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
                Me.lblEstado.Text = "Done!"

                If Not txtSerie.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número de serie de la nota de crédito"
                    txtSerie.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                If Not txtNumero.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número de la nota de crédito"
                    txtNumero.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If


                Select Case "01" ' strTipoNota
                    Case Notas_Credito.DEV_EXISTENCIA, Notas_Credito.ERR_CANTIDAD, Notas_Credito.BOF_REDUC_COSTO_IGUAL_COMPRA
                        If Not txtSerieGuia.Text.Trim.Length > 0 Then
                            lblEstado.Text = "Ingrese el número de serie de la guía de remisión"
                            txtSerieGuia.Select()
                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        End If

                        If Not txtNumeroGuia.Text.Trim.Length > 0 Then
                            lblEstado.Text = "Ingrese el número de la guía de remisión"
                            txtNumeroGuia.Select()
                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        End If
                End Select

                If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                    Grabar()
                Else
                    Dim Filas As Integer = dgvNuevoDoc.DisplayedRowCount(True)
                    If Filas > 0 Then
                        '  UpdateCompra()
                    Else
                        Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                        Me.lblEstado.Text = "Ingrese items a la canasta de nota de crédito!"
                        'Timer1.Enabled = True
                        'TiempoEjecutar(5)
                    End If


                End If
            Else
                Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                Me.lblEstado.Text = "Ingrese items a la canasta de nota de crédito!"
                'Timer1.Enabled = True
                'TiempoEjecutar(5)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
        '***********************************************************************

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvCanasta_SelectedIndexChanged(sender As Object, e As EventArgs)

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

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.ValueMember = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                '    txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text

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
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub TextBoxExt1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt1.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtProveedor.Text.Trim.Length > 0 Then
                Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
                datos.Clear()
                e.SuppressKeyPress = True
                With frmNotaCreditoModal
                    .RucProveedor = txtRuc.Text.Trim
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    If datos.Count > 0 Then
                        IdCompraOrigen = datos(0).ID
                        UbicarDetalle(datos(0).ID)

                        btnInfoCompra.Image = My.Resources.b_docsql
                        btnInfoCompra.Tag = "YES"
                        TextBoxExt1.Metrocolor = Color.FromKnownColor(KnownColor.Highlight)
                        TextBoxExt1.FocusBorderColor = Color.FromKnownColor(KnownColor.Highlight)
                        Dim str As String = datos(0).Appat.Replace("0", "")
                        TextBoxExt1.Text = String.Concat(datos(0).Cuenta, ", ", datos(0).Apmat, "-", str)

                    Else
                        dgvMov.Table.Records.DeleteAll()
                        dgvNuevoDoc.Rows.Clear()
                        btnInfoCompra.Image = My.Resources.b_drop
                        btnInfoCompra.Tag = "NO"
                        TextBoxExt1.Metrocolor = Color.Red
                        TextBoxExt1.FocusBorderColor = Color.Red
                        TextBoxExt1.Text = String.Empty
                    End If
                End With
            Else
                lblEstado.Text = "Debe seleccionar un proveedor para realizar esta operación!"
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TextBoxExt1_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBoxExt1.MouseClick

    End Sub

    Private Sub TextBoxExt1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt1.TextChanged

    End Sub

    Private Sub txtPeriodo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPeriodo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtProveedor.Select()
            txtProveedor.Focus()
        End If
    End Sub

    Private Sub txtPeriodo_TextChanged(sender As Object, e As EventArgs) Handles txtPeriodo.TextChanged

    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub

    Private Sub pcEntidad_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcEntidad.CloseUp
        Dim entidadSA As New entidadSA
        Dim cajaSA As New EstadosFinancierosSA
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstEntidades.SelectedItems.Count > 0 Then
                txtEntidadFinanciera.Text = lstEntidades.Text
                txtEntidadFinanciera.Tag = lstEntidades.SelectedValue
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtEntidadFinanciera.Focus()
        End If
    End Sub

    Private Sub txtEntidadFinanciera_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub pcEntidad_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcEntidad.BeforePopup
        Me.pcEntidad.BackColor = Color.FromArgb(227, 241, 254)
    End Sub


    Private Sub lstEntidades_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstEntidades.MouseDoubleClick
        If lstEntidades.SelectedItems.Count > 0 Then
            Me.pcEntidad.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub txtEntidadFinanciera_TextChanged(sender As Object, e As EventArgs) Handles txtEntidadFinanciera.TextChanged
        'pcEntidad.Font = New Font("Segoe UI", 8)
        'Me.pcEntidad.ParentControl = Me.txtEntidadFinanciera
        'Me.pcEntidad.ShowPopup(Point.Empty)
        'CargarCajas(txtEntidadFinanciera.Text.Trim)
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
                        .txtDni.Enabled = True
                        ModuloAppx = ModuloSistema.CAJA
                        .lblNivel.Text = "Caja"
                        .lblEstadoCaja.Visible = True
                        '.GroupBox1.Visible = True
                        '.GroupBox2.Visible = True
                        '.GroupBox4.Visible = True
                        '.cboMoneda.Visible = True
                        .Timer1.Enabled = True
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
                    .txtDni.Enabled = False
                    .StartPosition = FormStartPosition.CenterParent
                    '.UbicarUsuarioCaja(intIdDocumento, "COMPRA")
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

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim efSA As New EstadosFinancierosSA
        ManipulacionEstado = ENTITY_ACTIONS.INSERT

        GFichaUsuarios = New GFichaUsuario
        If TieneCuentaFinanciera() = True Then
            txtEntidadFinanciera.NearImage = My.Resources.iconBlackCheck
            txtEntidadFinanciera.Enabled = True
            With efSA.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino)
                txtEntidadFinanciera.Text = .descripcion
                txtEntidadFinanciera.Tag = .idestado
            End With
        Else
            txtEntidadFinanciera.NearImage = My.Resources.Login_01
            txtEntidadFinanciera.Clear()
            txtEntidadFinanciera.Tag = String.Empty
            txtEntidadFinanciera.Enabled = False
        End If
    End Sub

    Private Sub chDeposito_CheckedChanged(sender As Object, e As EventArgs) Handles chDeposito.CheckedChanged
        If chDeposito.Checked = True Then
            PictureBox1.Visible = True
        Else
            PictureBox1.Visible = False
        End If
    End Sub

    Private Sub dgvMov_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvMov.TableControlCellClick

    End Sub

    Private Sub dgvMov_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvMov.TableControlCurrentCellControlDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Dim nInsumoSA As New detalleitemsSA
        Dim n As New GInsumo()
        Dim tablaSA As New tablaDetalleSA
        Dim objInsumo As GInsumo = GInsumo.InstanceSingle
        If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
            Select Case Me.dgvMov.Table.CurrentRecord.GetValue("tipoEx")
                Case "GS"
                    If CDec(Me.dgvMov.Table.CurrentRecord.GetValue("importeMN")) > 0 Then
                        Try
                            '   If lsvCanasta.SelectedItems.Count > 0 Then

                            objInsumo.Clear()
                            objInsumo.Secuencia = Me.dgvMov.Table.CurrentRecord.GetValue("sec")
                            'If CStr(lsvCanasta.SelectedItems(0).SubItems(9).Text).Trim.Length > 0 Then
                            '    objInsumo.IdActividadRecurso = lsvCanasta.SelectedItems(0).SubItems(9).Text
                            'End If
                            objInsumo.IdInsumo = Me.dgvMov.Table.CurrentRecord.GetValue("idItem")
                            objInsumo.origenProducto = Me.dgvMov.Table.CurrentRecord.GetValue("grav")
                            objInsumo.descripcionItem = Me.dgvMov.Table.CurrentRecord.GetValue("item")
                            objInsumo.tipoExistencia = Me.dgvMov.Table.CurrentRecord.GetValue("tipoEx")

                            objInsumo.Cantidad = Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")
                            objInsumo.PU = 0 ' lsvCanasta.SelectedItems(0).SubItems(6).Text
                            objInsumo.Total = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN")
                            Select Case Me.dgvMov.Table.CurrentRecord.GetValue("tipoEx")
                                Case "GS"

                                Case Else
                                    With nInsumoSA.InvocarProductoID(Me.dgvMov.Table.CurrentRecord.GetValue("idItem"))
                                        objInsumo.unidad1 = .unidad1
                                        objInsumo.origenProducto = .origenProducto
                                        objInsumo.cuenta = .cuenta
                                        objInsumo.presentacion = .presentacion
                                        objInsumo.Nombrepresentacion = tablaSA.GetUbicarTablaID(21, .presentacion).descripcion
                                    End With
                                    objInsumo.IdAlmacen = Me.dgvMov.Table.CurrentRecord.GetValue("almacenRef")
                            End Select

                            '   End If

                            If Not IsNothing(objInsumo.descripcionItem) Then
                                If ExisteDatoEnGrid(objInsumo.IdInsumo) = False Then
                                    dgvNuevoDoc.Rows.Add(objInsumo.Secuencia, objInsumo.origenProducto,
                                                   objInsumo.IdInsumo,
                                                   objInsumo.descripcionItem,
                                                   objInsumo.presentacion,
                                                   objInsumo.Nombrepresentacion,
                                                   objInsumo.unidad1,
                                                   0,
                                                   "0.00",
                                                   "0.00",
                                                   "0.00",
                                                   "0.00", 0,
                                                    0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                                    objInsumo.tipoExistencia, objInsumo.cuenta, objInsumo.IdActividadRecurso, Nothing,
                                                     Nothing, Nothing, Nothing, Nothing, Nothing, objInsumo.IdAlmacen,
                                                     Me.dgvMov.Table.CurrentRecord.GetValue("cantCompra"), Me.dgvMov.Table.CurrentRecord.GetValue("compraMN"),
                                                     Me.dgvMov.Table.CurrentRecord.GetValue("cantidad"),
                                                     Me.dgvMov.Table.CurrentRecord.GetValue("importeMN"),
                                                     Me.dgvMov.Table.CurrentRecord.GetValue("importeME"), Nothing, Nothing, Nothing, "Elegir almacén")
                                End If
                            End If
                            If dgvNuevoDoc.Rows.Count > 0 Then
                                CellEndEditRefresh()
                            End If

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    Else

                    End If


                Case Else
                    If CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")) > 0 Then
                        Try
                            '   If lsvCanasta.SelectedItems.Count > 0 Then

                            objInsumo.Clear()
                            objInsumo.Secuencia = Me.dgvMov.Table.CurrentRecord.GetValue("sec")
                            'If CStr(lsvCanasta.SelectedItems(0).SubItems(9).Text).Trim.Length > 0 Then
                            '    objInsumo.IdActividadRecurso = lsvCanasta.SelectedItems(0).SubItems(9).Text
                            'End If
                            objInsumo.IdInsumo = Me.dgvMov.Table.CurrentRecord.GetValue("idItem")
                            objInsumo.origenProducto = Me.dgvMov.Table.CurrentRecord.GetValue("grav")
                            objInsumo.descripcionItem = Me.dgvMov.Table.CurrentRecord.GetValue("item")
                            objInsumo.tipoExistencia = Me.dgvMov.Table.CurrentRecord.GetValue("tipoEx")

                            objInsumo.Cantidad = Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")
                            objInsumo.PU = 0 ' lsvCanasta.SelectedItems(0).SubItems(6).Text
                            objInsumo.Total = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN")
                            Select Case Me.dgvMov.Table.CurrentRecord.GetValue("tipoEx")
                                Case "GS"

                                Case Else
                                    With nInsumoSA.InvocarProductoID(Me.dgvMov.Table.CurrentRecord.GetValue("idItem"))
                                        objInsumo.unidad1 = .unidad1
                                        objInsumo.origenProducto = .origenProducto
                                        objInsumo.cuenta = .cuenta
                                        objInsumo.presentacion = .presentacion
                                        objInsumo.Nombrepresentacion = tablaSA.GetUbicarTablaID(21, .presentacion).descripcion
                                    End With
                                    objInsumo.IdAlmacen = Me.dgvMov.Table.CurrentRecord.GetValue("almacenRef")
                            End Select

                            '   End If
                            Select Case cboOperacion.Text
                                Case "BONIFICACIONES RECIBIDAS (OPC. Beneficios)" ' "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"
                                    If Not IsNothing(objInsumo.descripcionItem) Then
                                        If ExisteDatoEnGrid(objInsumo.IdInsumo) = False Then
                                            dgvNuevoDoc.Rows.Add(objInsumo.Secuencia, objInsumo.origenProducto,
                                                           objInsumo.IdInsumo,
                                                           objInsumo.descripcionItem,
                                                           objInsumo.presentacion,
                                                           objInsumo.Nombrepresentacion,
                                                           objInsumo.unidad1,
                                                           0,
                                                           "0.00",
                                                           "0.00",
                                                           "0.00",
                                                           "0.00", 0,
                                                            0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                                            objInsumo.tipoExistencia, objInsumo.cuenta, objInsumo.IdActividadRecurso, Nothing,
                                                             Nothing, Nothing, "S", Nothing, Nothing, objInsumo.IdAlmacen,
                                                             Me.dgvMov.Table.CurrentRecord.GetValue("cantCompra"), Me.dgvMov.Table.CurrentRecord.GetValue("compraMN"),
                                                             Me.dgvMov.Table.CurrentRecord.GetValue("cantidad"),
                                                             Me.dgvMov.Table.CurrentRecord.GetValue("importeMN"),
                                                             Me.dgvMov.Table.CurrentRecord.GetValue("importeME"), Nothing, Nothing, Nothing, "Elegir almacén")
                                        End If
                                    End If

                                Case "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"
                                    ' Dim recupera As String = Nothing
                                    Dim f As New frmTipoItemBonifica()
                                    f.StartPosition = FormStartPosition.CenterParent
                                    f.ShowDialog()

                                    If SelecNombreEstable.Trim.Length > 0 Then
                                        Select Case SelecNombreEstable

                                            Case "="
                                                Dim almacenSA As New almacenSA
                                                If Not IsNothing(objInsumo.descripcionItem) Then
                                                    If ExisteDatoEnGrid(objInsumo.IdInsumo) = False Then
                                                        dgvNuevoDoc.Rows.Add(objInsumo.Secuencia, objInsumo.origenProducto,
                                                                       objInsumo.IdInsumo,
                                                                       objInsumo.descripcionItem,
                                                                       objInsumo.presentacion,
                                                                       objInsumo.Nombrepresentacion,
                                                                       objInsumo.unidad1,
                                                                       0,
                                                                       "0.00",
                                                                       "0.00",
                                                                       "0.00",
                                                                       "0.00", 0,
                                                                        0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                                                        objInsumo.tipoExistencia, objInsumo.cuenta, objInsumo.IdActividadRecurso, Nothing,
                                                                         Nothing, Nothing, "S", Nothing, Nothing, Me.dgvMov.Table.CurrentRecord.GetValue("almacenRef"),
                                                                         Me.dgvMov.Table.CurrentRecord.GetValue("cantCompra"), Me.dgvMov.Table.CurrentRecord.GetValue("compraMN"),
                                                                         Me.dgvMov.Table.CurrentRecord.GetValue("cantidad"),
                                                                         Me.dgvMov.Table.CurrentRecord.GetValue("importeMN"),
                                                                         Me.dgvMov.Table.CurrentRecord.GetValue("importeME"), Nothing, Nothing, Nothing, almacenSA.GetUbicar_almacenPorID(Me.dgvMov.Table.CurrentRecord.GetValue("almacenRef")).descripcionAlmacen, "=")
                                                    End If
                                                End If

                                            Case "=!"

                                                Dim almacenSA As New almacenSA
                                                If Not IsNothing(objInsumo.descripcionItem) Then
                                                    '    If ExisteDatoEnGrid(objInsumo.IdInsumo) = False Then
                                                    dgvNuevoDoc.Rows.Add(objInsumo.Secuencia, objInsumo.origenProducto,
                                                                   objInsumo.IdInsumo,
                                                                   objInsumo.descripcionItem,
                                                                   objInsumo.presentacion,
                                                                   objInsumo.Nombrepresentacion,
                                                                   objInsumo.unidad1,
                                                                   0,
                                                                   "0.00",
                                                                   "0.00",
                                                                   "0.00",
                                                                   "0.00", 0,
                                                                    0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                                                    objInsumo.tipoExistencia, objInsumo.cuenta, objInsumo.IdActividadRecurso, Nothing,
                                                                     Nothing, Nothing, "S", Nothing, Nothing, Me.dgvMov.Table.CurrentRecord.GetValue("almacenRef"),
                                                                     Me.dgvMov.Table.CurrentRecord.GetValue("cantCompra"), Me.dgvMov.Table.CurrentRecord.GetValue("compraMN"),
                                                                     Me.dgvMov.Table.CurrentRecord.GetValue("cantidad"),
                                                                     Me.dgvMov.Table.CurrentRecord.GetValue("importeMN"),
                                                                     Me.dgvMov.Table.CurrentRecord.GetValue("importeME"), Nothing, Nothing, Nothing, almacenSA.GetUbicar_almacenPorID(Me.dgvMov.Table.CurrentRecord.GetValue("almacenRef")).descripcionAlmacen, "=!")
                                                    '  End If
                                                End If
                                        End Select
                                    End If





                                Case Else

                                    If Not IsNothing(objInsumo.descripcionItem) Then
                                        If ExisteDatoEnGrid(objInsumo.IdInsumo) = False Then
                                            dgvNuevoDoc.Rows.Add(objInsumo.Secuencia, objInsumo.origenProducto,
                                                           objInsumo.IdInsumo,
                                                           objInsumo.descripcionItem,
                                                           objInsumo.presentacion,
                                                           objInsumo.Nombrepresentacion,
                                                           objInsumo.unidad1,
                                                           0,
                                                           "0.00",
                                                           "0.00",
                                                           "0.00",
                                                           "0.00", 0,
                                                            0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                                            objInsumo.tipoExistencia, objInsumo.cuenta, objInsumo.IdActividadRecurso, Nothing,
                                                             Nothing, Nothing, Nothing, Nothing, Nothing, objInsumo.IdAlmacen,
                                                             Me.dgvMov.Table.CurrentRecord.GetValue("cantCompra"), Me.dgvMov.Table.CurrentRecord.GetValue("compraMN"),
                                                             Me.dgvMov.Table.CurrentRecord.GetValue("cantidad"),
                                                             Me.dgvMov.Table.CurrentRecord.GetValue("importeMN"),
                                                             Me.dgvMov.Table.CurrentRecord.GetValue("importeME"))
                                        End If
                                    End If
                            End Select

                            If dgvNuevoDoc.Rows.Count > 0 Then
                                CellEndEditRefresh()
                            End If

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    Else

                    End If
            End Select
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboOperacion_Click(sender As Object, e As EventArgs) Handles cboOperacion.Click

    End Sub

    Private Sub cboOperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOperacion.SelectedIndexChanged
        Select Case cboOperacion.Text
            Case "DISMINUIR CANTIDAD"
                Panel2.Visible = False
                Can1.Visible = True
                Prec.Visible = False
                PrecUnitUS.Visible = False
                ImporteNeto.Visible = False
                ImporteUS.Visible = False
                kardex.Visible = False
                Kardexus.Visible = False
                kardex.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption)
                Kardexus.DefaultCellStyle.BackColor = Color.FromArgb(225, 240, 190)
                'dockingManager1.DockControlInAutoHideMode(Panel3, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
                'dockingManager1.SetDockLabel(Panel3, "Existencias")
                dockingManager1.SetDockVisibility(Panel3, False)
                colFlagBonif.Visible = False
            Case "DISMINUIR IMPORTE"
                Can1.Visible = False
                Prec.Visible = False
                PrecUnitUS.Visible = False
                ImporteNeto.Visible = True
                ImporteUS.Visible = True
                Panel2.Visible = True
                kardex.Visible = True
                Kardexus.Visible = True
                kardex.DefaultCellStyle.BackColor = Color.Yellow
                Kardexus.DefaultCellStyle.BackColor = Color.Yellow
                'dockingManager1.DockControlInAutoHideMode(Panel3, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
                'dockingManager1.SetDockLabel(Panel3, "Existencias")
                dockingManager1.SetDockVisibility(Panel3, False)
                colFlagBonif.Visible = False
            Case "DEVOLUCION DE EXISTENCIAS"
                Can1.Visible = True
                Prec.Visible = True
                PrecUnitUS.Visible = True
                ImporteNeto.Visible = True
                ImporteUS.Visible = True
                Panel2.Visible = True
                kardex.Visible = True
                Kardexus.Visible = True
                kardex.DefaultCellStyle.BackColor = Color.Yellow
                Kardexus.DefaultCellStyle.BackColor = Color.Yellow
                'dockingManager1.DockControlInAutoHideMode(Panel3, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
                'dockingManager1.SetDockLabel(Panel3, "Existencias")
                dockingManager1.SetDockVisibility(Panel3, False)
                colFlagBonif.Visible = False
            Case "BONIFICACIONES RECIBIDAS (OPC. Beneficios)" ', "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"
                Can1.Visible = True
                Prec.Visible = True
                PrecUnitUS.Visible = True
                ImporteNeto.Visible = True
                ImporteUS.Visible = True
                Panel2.Visible = True
                kardex.Visible = True
                Kardexus.Visible = True
                kardex.DefaultCellStyle.BackColor = Color.Yellow
                Kardexus.DefaultCellStyle.BackColor = Color.Yellow
                dockingManager1.DockControlInAutoHideMode(Panel3, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
                dockingManager1.SetDockLabel(Panel3, "Existencias")
                dockingManager1.SetDockVisibility(Panel3, True)
                dockingManager1.CloseEnabled = False
                Panel2.Visible = False
                colFlagBonif.Visible = False
            Case "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"
                Can1.Visible = True
                Prec.Visible = True
                PrecUnitUS.Visible = True
                ImporteNeto.Visible = True
                ImporteUS.Visible = True
                Panel2.Visible = True
                kardex.Visible = True
                Kardexus.Visible = True
                kardex.DefaultCellStyle.BackColor = Color.Yellow
                Kardexus.DefaultCellStyle.BackColor = Color.Yellow
                dockingManager1.DockControlInAutoHideMode(Panel3, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
                dockingManager1.SetDockLabel(Panel3, "Existencias")
                dockingManager1.SetDockVisibility(Panel3, True)
                dockingManager1.CloseEnabled = False
                Panel2.Visible = False
                colFlagBonif.Visible = True
        End Select
        txtGlosa.Text = (String.Concat("Operación: ", cboOperacion.Text.Trim, vbCrLf, "Por nota de credito", vbCrLf, "según/ ", Space(1), "documento", Space(1), "Nro.", Space(1), txtSerie.Text, "-", txtNumero.Text, vbCrLf, "fecha: ", fecha))
    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub txtCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCategoria.KeyDown

        Dim categoriaSA As New itemSA
        If e.KeyCode = Keys.Down Then
            If Not Me.PopupControlContainer2.IsShowing() Then
                ' Let the popup align around the source textBox.
                Me.PopupControlContainer2.Font = New Font("Segoe UI", 8)
                Me.PopupControlContainer2.Size = New Size(238, 110)
                Me.PopupControlContainer2.ParentControl = Me.txtCategoria
                Me.PopupControlContainer2.ShowPopup(Point.Empty)

                e.Handled = True
            End If
        End If
        '  End If
        ' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer2.IsShowing() Then
                Me.PopupControlContainer2.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtCategoria.Text.Trim.Length > 0 Then
                lstCategoria.Items.Clear()
                For Each i In categoriaSA.GetListaItemPorEstableLike(GEstableciento.IdEstablecimiento, txtCategoria.Text.Trim)
                    lstCategoria.Items.Add(New Categoria(i.descripcion, i.idItem, i.utilidad, i.utilidadmayor, i.utilidadgranmayor))
                Next
                lstCategoria.DisplayMember = "Name"
                lstCategoria.ValueMember = "Id"
                Me.PopupControlContainer2.Font = New Font("Segoe UI", 8)
                Me.PopupControlContainer2.Size = New Size(238, 110)
                Me.PopupControlContainer2.ParentControl = Me.txtCategoria
                Me.PopupControlContainer2.ShowPopup(Point.Empty)
            End If
        End If
    End Sub

    Private Sub txtCategoria_TextChanged(sender As Object, e As EventArgs) Handles txtCategoria.TextChanged

    End Sub

    Private Sub btmGrabarClasificacion_Click(sender As Object, e As EventArgs) Handles btmGrabarClasificacion.Click
        If Not txtNewClasificacion.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre de la clasificación"
            pcClasificacion.Font = New Font("Tahoma", 8)
            pcClasificacion.Size = New Size(337, 150)
            Me.pcClasificacion.ParentControl = Me.txtCategoria
            Me.pcClasificacion.ShowPopup(Point.Empty)
            txtNewClasificacion.Select()
            Exit Sub
        End If
        If Not nupUtilidad.Value > 0 Then
            lblEstado.Text = "Ingrese la utilidad de la clasificaión!"
            pcClasificacion.Font = New Font("Tahoma", 8)
            pcClasificacion.Size = New Size(337, 150)
            Me.pcClasificacion.ParentControl = Me.txtCategoria
            Me.pcClasificacion.ShowPopup(Point.Empty)
            nupUtilidad.Select()
            Exit Sub
        End If
        If Not nupUtilidadMayor.Value > 0 Then
            lblEstado.Text = "Ingrese la utilidad de la clasificaión!"
            pcClasificacion.Font = New Font("Tahoma", 8)
            pcClasificacion.Size = New Size(337, 150)
            Me.pcClasificacion.ParentControl = Me.txtCategoria
            Me.pcClasificacion.ShowPopup(Point.Empty)
            nupUtilidadMayor.Select()
            Exit Sub
        End If
        If Not nupUtilidadGranMayor.Value > 0 Then
            lblEstado.Text = "Ingrese la utilidad de la clasificaión!"
            pcClasificacion.Font = New Font("Tahoma", 8)
            pcClasificacion.Size = New Size(337, 150)
            Me.pcClasificacion.ParentControl = Me.txtCategoria
            Me.pcClasificacion.ShowPopup(Point.Empty)
            nupUtilidadGranMayor.Select()
            Exit Sub
        End If
        btmGrabarClasificacion.Tag = "G"
        Me.pcClasificacion.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Me.pcClasificacion.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub pcClasificacion_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcClasificacion.BeforePopup
        Me.pcClasificacion.BackColor = Color.White
    End Sub

    Private Sub pcClasificacion_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcClasificacion.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not txtNewClasificacion.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nombre de la clasificación"
                pcClasificacion.Font = New Font("Tahoma", 8)
                pcClasificacion.Size = New Size(337, 150)
                Me.pcClasificacion.ParentControl = Me.txtCategoria
                Me.pcClasificacion.ShowPopup(Point.Empty)
                txtNewClasificacion.Select()
                Exit Sub
            End If
            If Not nupUtilidad.Value > 0 Then
                lblEstado.Text = "Ingrese la utilidad de la clasificaión!"
                pcClasificacion.Font = New Font("Tahoma", 8)
                pcClasificacion.Size = New Size(337, 150)
                Me.pcClasificacion.ParentControl = Me.txtCategoria
                Me.pcClasificacion.ShowPopup(Point.Empty)
                nupUtilidad.Select()
                Exit Sub
            End If

            If btmGrabarClasificacion.Tag = "G" Then
                GrabarCategoria()
                btmGrabarClasificacion.Tag = "N"
            Else
                pcClasificacion.Font = New Font("Tahoma", 8)
                pcClasificacion.Size = New Size(337, 150)
                Me.pcClasificacion.ParentControl = Me.txtCategoria
                Me.pcClasificacion.ShowPopup(Point.Empty)
            End If

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCategoria.Focus()
        End If
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Me.Cursor = Cursors.WaitCursor
        If txtCategoria.Text.Trim.Length > 0 Then
            ListadoProductosPorCategoriaTipoExistencia(txtCategoria.ValueMember, cboTipoExistencia.SelectedValue, txtCategoria.Tag, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadMayor, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadGranMayor)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Cursor = Cursors.WaitCursor
        pcClasificacion.Font = New Font("Tahoma", 8)
        pcClasificacion.Size = New Size(337, 150)
        Me.pcClasificacion.ParentControl = Me.txtCategoria
        Me.pcClasificacion.ShowPopup(Point.Empty)
        txtNewClasificacion.Clear()
        txtNewClasificacion.Select()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonCategoria_Click(sender As Object, e As EventArgs) Handles ButtonCategoria.Click
        Me.PopupControlContainer2.Font = New Font("Segoe UI", 8)
        Me.PopupControlContainer2.Size = New Size(238, 110)
        Me.PopupControlContainer2.ParentControl = Me.txtCategoria
        Me.PopupControlContainer2.ShowPopup(Point.Empty)
    End Sub

    Private Sub cboTipoExistencia_Click(sender As Object, e As EventArgs) Handles cboTipoExistencia.Click

    End Sub

    Private Sub cboTipoExistencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoExistencia.SelectedIndexChanged
        If cboTipoExistencia.SelectedIndex > -1 Then
            If txtCategoria.Text.Trim.Length > 0 Then
                ListadoProductosPorCategoriaTipoExistencia(txtCategoria.ValueMember, cboTipoExistencia.SelectedValue, txtCategoria.Tag, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadMayor, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadGranMayor)
            End If
        End If
    End Sub

    Private Sub txtBuscarProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarProducto.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ListaMercaderias(cboTipoExistencia.SelectedValue, txtBuscarProducto.Text.Trim)
            '   End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvListadoItems_MouseClick(sender As Object, e As MouseEventArgs) Handles lsvListadoItems.MouseClick

    End Sub

    Private Sub lsvListadoItems_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvListadoItems.MouseDoubleClick
        Dim nInsumoSA As New detalleitemsSA
        Dim n As New GInsumo()
        Dim tablaSA As New tablaDetalleSA
        Dim objInsumo As GInsumo = GInsumo.InstanceSingle

        If txtProveedor.Text.Trim.Length > 0 Then
            If lsvListadoItems.SelectedItems.Count > 0 Then

                objInsumo.Clear()
                objInsumo.Secuencia = 0

                With nInsumoSA.InvocarProductoID(lsvListadoItems.SelectedItems(0).SubItems(0).Text)
                    objInsumo.unidad1 = .unidad1
                    objInsumo.origenProducto = .origenProducto
                    objInsumo.cuenta = .cuenta
                    objInsumo.presentacion = .presentacion
                    objInsumo.Nombrepresentacion = tablaSA.GetUbicarTablaID(21, .presentacion).descripcion

                    objInsumo.IdInsumo = .codigodetalle
                    objInsumo.origenProducto = .origenProducto
                    objInsumo.descripcionItem = .descripcionItem
                    objInsumo.tipoExistencia = .tipoExistencia

                    objInsumo.Cantidad = 0
                    objInsumo.PU = 0 ' lsvCanasta.SelectedItems(0).SubItems(6).Text
                    objInsumo.Total = 0
                End With
                Select Case cboOperacion.Text
                    Case "BONIFICACIONES RECIBIDAS (OPC. Beneficios)" ', "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"

                        If Not IsNothing(objInsumo.descripcionItem) Then
                            dgvNuevoDoc.Rows.Add(objInsumo.Secuencia, objInsumo.origenProducto,
                                           objInsumo.IdInsumo,
                                           objInsumo.descripcionItem,
                                           objInsumo.presentacion,
                                           objInsumo.Nombrepresentacion,
                                           objInsumo.unidad1,
                                           0,
                                           "0.00",
                                           "0.00",
                                           "0.00",
                                           "0.00", 0,
                                            0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                            objInsumo.tipoExistencia, objInsumo.cuenta, objInsumo.IdActividadRecurso, Nothing,
                                             Nothing, Nothing, "S", Nothing, Nothing, objInsumo.IdAlmacen,
                                             "0.00", "0.00",
                                             "0.00",
                                             "0.00",
                                             "0.00", Nothing, Nothing, Nothing, "Elegir almacén")

                        End If

                    Case "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"
                        If Not IsNothing(objInsumo.descripcionItem) Then
                            dgvNuevoDoc.Rows.Add(objInsumo.Secuencia, objInsumo.origenProducto,
                                           objInsumo.IdInsumo,
                                           objInsumo.descripcionItem,
                                           objInsumo.presentacion,
                                           objInsumo.Nombrepresentacion,
                                           objInsumo.unidad1,
                                           0,
                                           "0.00",
                                           "0.00",
                                           "0.00",
                                           "0.00", 0,
                                            0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                            objInsumo.tipoExistencia, objInsumo.cuenta, objInsumo.IdActividadRecurso, Nothing,
                                             Nothing, Nothing, "S", Nothing, Nothing, objInsumo.IdAlmacen,
                                             "0.00", "0.00",
                                             "0.00",
                                             "0.00",
                                             "0.00", Nothing, Nothing, Nothing, "Elegir almacén", "<>")

                        End If
                    Case Else
                        objInsumo.IdAlmacen = Me.dgvMov.Table.CurrentRecord.GetValue("almacenRef")

                        If Not IsNothing(objInsumo.descripcionItem) Then
                            dgvNuevoDoc.Rows.Add(objInsumo.Secuencia, objInsumo.origenProducto,
                                           objInsumo.IdInsumo,
                                           objInsumo.descripcionItem,
                                           objInsumo.presentacion,
                                           objInsumo.Nombrepresentacion,
                                           objInsumo.unidad1,
                                           0,
                                           "0.00",
                                           "0.00",
                                           "0.00",
                                           "0.00", 0,
                                            0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                            objInsumo.tipoExistencia, objInsumo.cuenta, objInsumo.IdActividadRecurso, Nothing,
                                             Nothing, Nothing, "S", Nothing, Nothing, objInsumo.IdAlmacen,
                                             Me.dgvMov.Table.CurrentRecord.GetValue("cantCompra"), Me.dgvMov.Table.CurrentRecord.GetValue("compraMN"),
                                             Me.dgvMov.Table.CurrentRecord.GetValue("cantidad"),
                                             Me.dgvMov.Table.CurrentRecord.GetValue("importeMN"),
                                             Me.dgvMov.Table.CurrentRecord.GetValue("importeME"))

                        End If
                End Select



                '   End If


            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar un proveedor?", "Atención", Nothing, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub lstCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstCategoria.MouseDoubleClick
        If lstCategoria.SelectedItems.Count > 0 Then
            Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub PopupControlContainer2_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer2.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstCategoria.SelectedItems.Count > 0 Then
                Me.txtCategoria.ValueMember = CStr(DirectCast(Me.lstCategoria.SelectedItem, Categoria).Id)
                txtCategoria.Tag = DirectCast(Me.lstCategoria.SelectedItem, Categoria).Utilidad
                txtCategoria.Text = lstCategoria.Text
                ListadoProductosPorCategoriaTipoExistencia(DirectCast(Me.lstCategoria.SelectedItem, Categoria).Id, cboTipoExistencia.SelectedValue, DirectCast(Me.lstCategoria.SelectedItem, Categoria).Utilidad, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadMayor, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadGranMayor)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCategoria.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvListadoItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvListadoItems.SelectedIndexChanged

    End Sub
End Class