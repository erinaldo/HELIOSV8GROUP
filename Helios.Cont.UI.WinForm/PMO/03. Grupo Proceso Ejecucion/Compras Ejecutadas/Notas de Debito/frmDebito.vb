Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmDebito
    Inherits frmMaster

    Public Property IdCompraOrigen() As Integer
    Public Property Moneda() As String
    Public Property IdProveedor() As Integer
    Public Property NomProveedor() As String
    Public Property CuentaProveedor() As String
    Public Property TipoCompra() As String

    Public Property strTipoNota() As String = Nothing
    Public Property ManipulacionEstado() As String
    Public Property IdUsuarioCaja() As String
    Public Property ListaAsientonTransito As New List(Of asiento)

    Dim toolTip As Popup
    Dim ucInfoCompra As New ucInfoCompra
    Public fecha As DateTime

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

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GConfiguracion = New GConfiguracionModulo
        '  configuracionModulo(Gempresas.IdEmpresaRuc, "C2", Me.Text)
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        dockingManager1.DockControlInAutoHideMode(PanelDetalleCompra, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 680)
        dockingClientPanel1.BringToFront()
        dockingManager1.MDIActivatedVisibility = True
        Me.dockingClientPanel1.AutoScroll = True
        Me.dockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        dockingManager1.SetDockLabel(PanelDetalleCompra, "Canasta de compras")
        'INICIO PERIODO
        txtPeriodo.Text = PeriodoGeneral 'String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & txtPeriodo.Text
        txtFechaComprobante.Select()
        dockingManager1.CloseEnabled = False
    End Sub

#Region "Métodos"
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

    Private Function GlosaNotas() As String
        If Not String.IsNullOrEmpty(txtSerie.Text) And Not String.IsNullOrEmpty(txtNumero.Text) And _
        Not String.IsNullOrEmpty(NomProveedor) Then
            Return String.Concat("Por Incremento del costo", Space(1), "según/ ", Space(1), "NOTA DE DEBITO", Space(1), "Nro.", Space(1), txtSerie.Text, "-", txtNumero.Text, vbCrLf, "Fecha: ", fecha)
        Else
            Return False
        End If
    End Function

    Private Sub Validar_Numeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim Celda As DataGridViewCell = Me.dgvNuevoDoc.CurrentCell()

        If Celda.ColumnIndex = 7 Or Celda.ColumnIndex = 10 Or Celda.ColumnIndex = 11 Then

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

            lsvCanasta.Items.Clear()
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
            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(intIddocumento)
                detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)

                Select Case TipoCompra
                    Case TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION, TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
                        cTotalmn = CDec(i.MontoDeudaSoles) '- detalle.importe + detalle.ImporteDBMN
                        cTotalme = CDec(i.MontoDeudaUSD) '- detalle.importeUS + detalle.ImporteDBME
                    Case Else
                        cTotalmn = CDec(i.MontoDeudaSoles) '- detalle.importe + detalle.ImporteDBMN - CDec(i.MontoPagadoSoles)
                        cTotalme = CDec(i.MontoDeudaUSD) '- detalle.importeUS + detalle.ImporteDBME - CDec(i.MontoPagadoUSD)
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
                dr(6) = cTotalmn
                dr(7) = 0
                dr(8) = cTotalme
                dr(9) = i.TipoExistencia
                dr(10) = i.almacenRef

                dr(11) = i.CantidadCompra
                dr(12) = i.MontoDeudaSoles
                dr(13) = i.MontoDeudaUSD
                dt.Rows.Add(dr)
            Next
            dgvMov.DataSource = dt
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

    Public Sub configuracionModulo(strIDEmpresa As String, strIdModulo As String, strNomModulo As String)
        Dim moduloConfiguracionSA As New ModuloConfiguracionSA
        Dim moduloConfiguracion As New moduloConfiguracion
        Dim numeracionSA As New NumeracionBoletaSA
        Dim TablaSA As New tablaDetalleSA
        Dim almacenSA As New almacenSA
        Dim cajaSA As New EstadosFinancierosSA

        moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa)
        If Not IsNothing(moduloConfiguracion) Then
            With moduloConfiguracion
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.IdModulo = .idModulo
                GConfiguracion.NomModulo = strNomModulo
                GConfiguracion.TipoConfiguracion = .tipoConfiguracion
                Select Case .tipoConfiguracion
                    Case "P"
                        With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
                            GConfiguracion.ConfigComprobante = .IdEnumeracion
                            GConfiguracion.TipoComprobante = .tipo
                            GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
                            GConfiguracion.Serie = .serie
                            GConfiguracion.ValorActual = .valorInicial
                            'txtSerieComp.Visible = True
                            'txtSerieComp.Text = .serie
                            'txtNumeroComp.Visible = False
                            'txtIdComprobante.Text = GConfiguracion.TipoComprobante
                            'txtComprobante.Text = GConfiguracion.NombreComprobante
                            'LinkTipoDoc.Enabled = False
                            'txtSerieComp.Enabled = False
                        End With
                    Case "M"
                        'txtSerieComp.Visible = True
                        'txtNumeroComp.Visible = True
                        'LinkTipoDoc.Enabled = True
                        'txtSerieComp.Enabled = True
                End Select
                If Not IsNothing(.configAlmacen) Then
                    Dim estableSA As New establecimientoSA
                    With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
                        GConfiguracion.IdAlmacen = .idAlmacen
                        GConfiguracion.NombreAlmacen = .descripcionAlmacen

                        'txtAlmacen.Text = GConfiguracion.NombreAlmacen
                        'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
                        With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
                            'txtIdEstableAlmacen.Text = .idCentroCosto
                            'txtEstableAlmacen.Text = .nombre
                        End With
                    End With
                End If
                If Not IsNothing(.ConfigentidadFinanciera) Then
                    With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
                        GConfiguracion.IDCaja = .idestado
                        GConfiguracion.NomCaja = .descripcion
                    End With
                End If

            End With
        Else
            lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
            'Timer1.Enabled = True
            'TabCompra.Enabled = False
            'TiempoEjecutar(5)
        End If
    End Sub
#End Region

#Region "METODOS DGV"
    Public Sub TotalesCabeceras()
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
            cTotalMN += CDec(i.Cells(10).Value)
            cTotalME += CDec(i.Cells(11).Value)

            cTotalBI += CDec(i.Cells(12).Value)
            cTotalBI_ME += CDec(i.Cells(16).Value)

            cTotalIGV += CDec(i.Cells(14).Value)
            cTotalIGV_ME += CDec(i.Cells(18).Value)

            cTotalIsc += CDec(i.Cells(13).Value)
            cTotalIsc_ME += CDec(i.Cells(17).Value)

            cTotalOTC += CDec(i.Cells(15).Value)
            cTotalOTC_ME += CDec(i.Cells(19).Value)
        Next

        lblTotalBase.Text = cTotalBI.ToString("N2")
        lblTotalBaseUS.Text = cTotalBI_ME.ToString("N2")

        lblTotalISc.Text = cTotalIsc.ToString("N2")
        lblTotalIScUS.Text = cTotalIsc_ME.ToString("N2")

        lblTotalMontoIgv.Text = cTotalIGV.ToString("N2")
        lblTotalMontoIgvUS.Text = cTotalIGV_ME.ToString("N2")

        lblOtrostribTotal.Text = cTotalOTC.ToString("N2")
        lblOtrostribTotalUS.Text = cTotalOTC_ME.ToString("N2")

        'Select Case txtIdComprobanteNota.Text
        '    Case "02", "03"
        lblTotalAdquisiones.Text = cTotalMN   'cTotalMN.ToString("N2")
        lblTotalUS.Text = cTotalME   'cTotalME.ToString("N2")
        lblBonificaMN.Text = cTotalMN.ToString("N2") 'cTotalMN.ToString("N2")
        lblBonificaME.Text = cTotalME.ToString("N2")
        '    Case "08"
        ''Instrucciones
        'lblTotalAdquisiones.Text = cTotalBI + cTotalIGV   'cTotalMN.ToString("N2")
        'lblTotalUS.Text = cTotalBI_ME + cTotalIGV_ME  'cTotalME.ToString("N2")
        '    Case Else

        'lblTotalAdquisiones.Text = cTotalBI + cTotalIGV   'cTotalMN.ToString("N2")
        'lblTotalUS.Text = cTotalBI_ME + cTotalIGV_ME  'cTotalME.ToString("N2")
        'End Select

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

                    total += dgvNuevoDoc.Rows(i).Cells(12).Value() ' total base 01 soles
                    tus1 += dgvNuevoDoc.Rows(i).Cells(16).Value() ' total base 01 dolares
                    totalIgv1 += dgvNuevoDoc.Rows(i).Cells(14).Value()
                    totalIgv1_ME += dgvNuevoDoc.Rows(i).Cells(18).Value()

                ElseIf dgvNuevoDoc.Rows(i).Cells(1).Value() = "2" Then

                    totalbase2 += dgvNuevoDoc.Rows(i).Cells(12).Value()
                    tus2 += dgvNuevoDoc.Rows(i).Cells(16).Value() ' total base 01
                    totalIgv2 += dgvNuevoDoc.Rows(i).Cells(14).Value()
                    totalIgv2_ME += dgvNuevoDoc.Rows(i).Cells(18).Value()

                ElseIf dgvNuevoDoc.Rows(i).Cells(1).Value() = "3" Then
                    totalBI3 += dgvNuevoDoc.Rows(i).Cells(12).Value()
                    totalBI3_ME += dgvNuevoDoc.Rows(i).Cells(16).Value() ' total base 01
                    totalIgv3 += dgvNuevoDoc.Rows(i).Cells(14).Value()
                    totalIgv3_ME += dgvNuevoDoc.Rows(i).Cells(18).Value()

                ElseIf dgvNuevoDoc.Rows(i).Cells(1).Value() = "4" Then
                    totalBI4 += dgvNuevoDoc.Rows(i).Cells(12).Value()
                    totalBI4_ME += dgvNuevoDoc.Rows(i).Cells(16).Value() ' total base 01
                    totalIgv4 += dgvNuevoDoc.Rows(i).Cells(14).Value()
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


                Dim colBI As Decimal = 0
                Dim colBI_ME As Decimal = 0
                Dim colIGV_ME As Decimal = 0
                Dim colIGV As Decimal = 0
                Dim colMN As Decimal = i.Cells(10).Value
                Dim colME As Decimal = Math.Round(CDec(i.Cells(10).Value) / CDec(txtTipoCambio.Value), 2)
                Dim colPrecUnit As Decimal = 0
                Dim colPrecUnitUSD As Decimal = 0


                If colMN > 0 Then

                    colPrecUnit = Math.Round(colMN / colCantidad, 2)

                    colPrecUnitUSD = Math.Round(colME / colCantidad, 2)

                    colBI = Math.Round(colMN / 1.18, 2)
                    colBI_ME = Math.Round(colME / 1.18, 2)
                    colIGV = Math.Round((colMN / 1.18) * 0.18, 2)
                    colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2)


                Else
                    colPrecUnit = 0

                    colPrecUnitUSD = 0

                    colBI = 0
                    colBI_ME = 0
                    colIGV = 0
                    colIGV_ME = 0
                End If
                'Select Case txtIdComprobanteNota.Text ' cboTipoDoc.SelectedValue
                '    Case "08"
                'If dgvDetalleCompra.Columns(e.ColumnIndex).Name = "ImporteNeto" Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "OTCus" Then
                '    totales_xx()
                'End If
                '   Case "03", "02"
                '   If dgvDetalleCompra.Columns(e.ColumnIndex).Name = "montoSolessc" Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "Can1" Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "montoUsdsc" Then 'Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "OTCus" Then
                If txtTipoCambio.Value = 0.0 Then
                    MsgBox("Ingrese Tipo de Cambio..!")
                    txtTipoCambio.Focus()
                    txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                    Exit Sub
                End If
                Dim NUDIGV_VALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
                'If colCantidad = 0 And colMN = 0 And colME = 0 Then
                '    i.Cells(8).Value() = "0.00"
                '    i.Cells(9).Value() = "0.00"
                '    Exit Sub
                'Else 'If colCantidad = 0 Then

                If colCantidad > 0 Then
                    If Moneda = 1 Then
                        ' DATOS SOLES
                        If i.Cells(1).Value = "4" Then
                            i.Cells(7).Value() = colCantidad
                            i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / colCantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                            i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / colCantidad), NumDigitos).ToString("N2")
                            i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                            i.Cells(10).Value() = colMN 'CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")

                            i.Cells(12).Value() = "0.00"
                            i.Cells(13).Value() = "0.00"
                            i.Cells(14).Value() = "0.00"
                            i.Cells(15).Value() = "0.00"
                            i.Cells(16).Value() = "0.00"
                            i.Cells(17).Value() = "0.00"
                            i.Cells(18).Value() = "0.00"
                            i.Cells(19).Value() = "0.00"
                        Else
                            i.Cells(7).Value() = colCantidad 'CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                            i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                            i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                            i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                            i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")


                            i.Cells(12).Value() = "0.00"
                            i.Cells(13).Value() = "0.00"
                            i.Cells(14).Value() = "0.00"
                            i.Cells(15).Value() = "0.00"
                            i.Cells(16).Value() = "0.00"
                            i.Cells(17).Value() = "0.00"
                            i.Cells(18).Value() = "0.00"
                            i.Cells(19).Value() = "0.00"
                        End If

                    ElseIf Moneda = 2 Then

                        Select Case colDestinoGravado
                            Case "4"
                                ' DATOS DOLARES

                                i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")


                                i.Cells(12).Value() = "0.00"
                                i.Cells(13).Value() = "0.00"
                                i.Cells(14).Value() = "0.00"
                                i.Cells(15).Value() = "0.00"
                                i.Cells(16).Value() = "0.00"
                                i.Cells(17).Value() = "0.00"
                                i.Cells(18).Value() = "0.00"
                                i.Cells(19).Value() = "0.00"
                            Case Else
                                ' DATOS DOLARES
                                i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")


                                i.Cells(12).Value() = "0.00"
                                i.Cells(13).Value() = "0.00"
                                i.Cells(14).Value() = "0.00"
                                i.Cells(15).Value() = "0.00"
                                i.Cells(16).Value() = "0.00"
                                i.Cells(17).Value() = "0.00"
                                i.Cells(18).Value() = "0.00"
                                i.Cells(19).Value() = "0.00"
                        End Select

                    End If
                End If
            Next
            totales_xx()
            TotalesCabeceras()

        End If

        '**********************************************************************************************************************************************************************************
        '  Case Else
        '       If dgvDetalleCompra.Columns(e.ColumnIndex).Name = "montoSolessc" Then
        'If txtTipoCambio.Value = 0.0 Then
        '    MsgBox("Ingrese Tipo de Cambio..!")
        '    txtTipoCambio.Focus()
        '    txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
        '    Exit Sub
        'End If

        'Dim NUDIGV_VALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
        'If colCantidad = 0 And colMN = 0 And colME = 0 Then
        '    i.Cells(8).Value() = "0.00"
        '    i.Cells(9).Value() = "0.00"
        '    Exit Sub

        'ElseIf colCantidad = 0 Then

        '    If Moneda = 1 Then
        '        ' DATOS SOLES
        '        Select Case colDestinoGravado
        '            Case "4"
        '                i.Cells(8).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
        '                i.Cells(9).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
        '                i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES
        '                i.Cells(10).Value() = colMN ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES

        '            Case Else

        '                ''   If dgvDetalleCompra.Item(27, dgvDetalleCompra.CurrentRow.Index).Value() = "S" Then
        '                'dgvDetalleCompra.Item(8, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
        '                'dgvDetalleCompra.Item(9, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
        '                'dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() = colMN ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
        '                'dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
        '                'dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
        '                'dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto igv del item
        '                'dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex USD
        '                'dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV USD
        '                'dgvDetalleCompra.Item(19, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
        '                'Else
        '                i.Cells(8).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
        '                i.Cells(9).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
        '                i.Cells(10).Value() = colMN ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
        '                i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
        '                i.Cells(12).Value() = colBI ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
        '                i.Cells(14).Value() = colIGV  ' Math.Round(CDec(neto - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

        '                i.Cells(16).Value() = colBI_ME ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
        '                i.Cells(18).Value() = colIGV_ME ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


        '                i.Cells(19).Value() = Math.Round(CDec(i.Cells(15).Value() / txtTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES
        '                '   End If
        '        End Select

        '    ElseIf Moneda = 2 Then
        '        ' DATOS DOLARES
        '        Select Case colDestinoGravado
        '            Case "4"
        '                i.Cells(9).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
        '                i.Cells(8).Value() = "0.00" 'Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 2)
        '                i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
        '                i.Cells(11).Value() = colME

        '                ' dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
        '                ' dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' igv del item

        '                '  dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
        '                '  dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV

        '                '  dgvDetalleCompra.Item(15, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(19, dgvDetalleCompra.CurrentRow.Index).Value() * nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS SOLES
        '            Case Else

        '                'If dgvDetalleCompra.Item(27, dgvDetalleCompra.CurrentRow.Index).Value() = "S" Then
        '                '    dgvDetalleCompra.Item(9, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
        '                '    dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() = colMN 'Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
        '                '    dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() = colME

        '                '    dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
        '                '    dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' igv del item

        '                '    dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
        '                '    dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV
        '                '    dgvDetalleCompra.Item(8, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 2)
        '                '    dgvDetalleCompra.Item(15, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS SOLES
        '                'Else
        '                i.Cells(8).Value() = "0.00"
        '                i.Cells(9).Value() = "0.00"
        '                i.Cells(10).Value() = colMN
        '                i.Cells(11).Value() = colME

        '                i.Cells(12).Value() = colBI ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
        '                i.Cells(14).Value() = colIGV ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' igv del item

        '                i.Cells(16).Value() = colBI_ME ' Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
        '                i.Cells(18).Value() = colIGV_ME ' Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV

        '                i.Cells(15).Value() = Math.Round(CDec(i.Cells(19).Value() * txtTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS SOLES
        '                'End If
        '        End Select

        '    End If
        'ElseIf colCantidad > 0 Then
        '    If Moneda = 1 Then
        '        ' DATOS SOLES
        '        If colDestinoGravado = "4" Then
        '            i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
        '            i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
        '            i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
        '            i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
        '            i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
        '            '  dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
        '            '  dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(neto - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' monto igv del item

        '            ' dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex USD
        '            ' dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV USD


        '            'dgvDetalleCompra.Item(19, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(15, dgvDetalleCompra.CurrentRow.Index).Value() / nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS DOLARES
        '        Else
        '            If i.Cells(27).Value() = "S" Then
        '                i.Cells(7).Value() = colCantidad '  CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
        '                i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
        '                i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
        '                i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
        '                i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
        '                i.Cells(12).Value() = "0.00" ' monto para el kardex
        '                i.Cells(14).Value() = "0.00" ' monto igv del item

        '                i.Cells(16).Value() = "0.00" ' monto para el kardex USD
        '                i.Cells(18).Value() = "0.00" ' monto para el IGV USD


        '                i.Cells(19).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
        '            Else
        '                i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
        '                i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
        '                i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
        '                i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
        '                i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
        '                i.Cells(12).Value() = colBI ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
        '                i.Cells(14).Value() = colIGV ' Math.Round(CDec(neto - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

        '                i.Cells(16).Value() = colBI_ME ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
        '                i.Cells(18).Value() = colIGV_ME ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


        '                '    i.Cells(19).Value() = Math.Round(CDec(i.Cells(15).Value() / txtTipoCambio.NumericValue), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES

        '            End If

        '        End If

        '    ElseIf Moneda = 2 Then

        '        Select Case colDestinoGravado
        '            Case "4"
        '                ' DATOS DOLARES
        '                i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
        '                i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
        '                i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
        '                i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
        '                i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
        '                '  dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
        '                '  dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' igv del item

        '                ' dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
        '                ' dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV

        '                ' dgvDetalleCompra.Item(15, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(19, dgvDetalleCompra.CurrentRow.Index).Value() * nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS SOLES
        '            Case Else
        '                ' DATOS DOLARES
        '                If i.Cells(27).Value() = "S" Then
        '                    i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
        '                    i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
        '                    i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
        '                    i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
        '                    i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
        '                    i.Cells(12).Value() = "0.00" ' monto para el kardex
        '                    i.Cells(14).Value() = "0.00" ' igv del item

        '                    i.Cells(16).Value() = "0.00" ' monto para el kardex
        '                    i.Cells(18).Value() = "0.00" ' monto para el IGV

        '                    i.Cells(15).Value() = "0.00" ' monto OTROS TRIBUTOS SOLES
        '                Else
        '                    i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
        '                    i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
        '                    i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
        '                    i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
        '                    i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
        '                    i.Cells(12).Value() = colBI ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
        '                    i.Cells(14).Value() = colIGV ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' igv del item

        '                    i.Cells(16).Value() = colBI_ME ' Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
        '                    i.Cells(18).Value() = colIGV_ME ' Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV

        '                    i.Cells(15).Value() = Math.Round(CDec(i.Cells(19).Value() * txtTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS SOLES
        '                End If

        '        End Select

        '    End If
        'End If
        'totales_xx()
        'TotalesCabeceras()


        '        End Select
        '    Next
        'End If

    End Sub
#End Region

#Region "Manipulción Data"

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
        nAsiento.glosa = GlosaNotas()
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Public Sub MV_Item_Transito(cCuenta As String, cproducto As String, cMonto As Decimal, cMontoUS As Decimal, strTipoExistencia As String)
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoTransito(cMonto, cMontoUS) ' CABECERA ASIENTO

        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento
        Select Case strTipoExistencia
            Case "01"
                With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
                    nMovimiento.cuenta = .destinoCompra
                End With
            Case "02", "03", "04", "05"
                With mascaraExistenciasSA.GetUbicar_mascaraContableExistenciaPorEmpresaCF(Gempresas.IdEmpresaRuc, cCuenta, strTipoExistencia)
                    nMovimiento.cuenta = .cuentaIngAlmacen2
                End With
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
                With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
                    nMovimiento.cuenta = .destinoCompra2
                End With
            Case "02", "03", "04", "05"
                With mascaraExistenciasSA.GetUbicar_mascaraContableExistenciaPorEmpresaCF(Gempresas.IdEmpresaRuc, cCuenta, strTipoExistencia)
                    nMovimiento.cuenta = .cuentaSalida
                End With
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

    Public Function AS_Proveedor(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = CuentaProveedor,
              .descripcion = NomProveedor,
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AS_IGV(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "40111",
              .descripcion = "I.G.V.",
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Sub AsientoNotaDedito()
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
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.COMPRA_NOTA_DEBITO
        nAsiento.importeMN = CDec(lblTotalAdquisiones.Text)
        nAsiento.importeME = CDec(lblTotalUS.Text)
        nAsiento.glosa = GlosaNotas()
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)


        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If dgvNuevoDoc.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                Select Case txtIdComprobanteNota.Text
                    Case "03", "02"
                        MV_Item_Transito(i.Cells(22).Value(), i.Cells(3).Value(), CDec(i.Cells(10).Value()), CDec(i.Cells(11).Value()), i.Cells(21).Value())
                    Case Else

                        Select Case i.Cells(1).Value()
                            Case "1"
                                MV_Item_Transito(i.Cells(22).Value(), i.Cells(3).Value(), CDec(i.Cells(12).Value()), CDec(i.Cells(16).Value()), i.Cells(21).Value())
                            Case Else
                                MV_Item_Transito(i.Cells(22).Value(), i.Cells(3).Value(), CDec(i.Cells(10).Value()), CDec(i.Cells(11).Value()), i.Cells(21).Value())

                        End Select


                End Select


                nMovimiento = New movimiento
                nMovimiento.cuenta = dgvNuevoDoc.Rows(i.Index).Cells(22).Value
                nMovimiento.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE

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

                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = "Jiuni"

                nAsiento.movimiento.Add(nMovimiento)
            End If
        Next
        nAsiento.movimiento.Add(AS_IGV(CDec(lblTotalMontoIgv.Text), CDec(lblTotalMontoIgvUS.Text)))
        nAsiento.movimiento.Add(AS_Proveedor(CDec(lblTotalAdquisiones.Text), CDec(lblTotalUS.Text)))

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

                        objTotalesDet.cantidad = 0
                        objTotalesDet.precioUnitarioCompra = CType(dgvNuevoDoc.Rows(i.Index).Cells(8).Value(), Decimal)

                        Select Case dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
                            Case "1"
                                objTotalesDet.importeSoles = CType(dgvNuevoDoc.Rows(i.Index).Cells(12).Value(), Decimal)
                                objTotalesDet.importeDolares = CType(dgvNuevoDoc.Rows(i.Index).Cells(16).Value(), Decimal)
                            Case Else
                                objTotalesDet.importeSoles = CType(dgvNuevoDoc.Rows(i.Index).Cells(10).Value(), Decimal)
                                objTotalesDet.importeDolares = CType(dgvNuevoDoc.Rows(i.Index).Cells(11).Value(), Decimal)
                        End Select

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
    Private Function GlosaCompra() As String
        If Not String.IsNullOrEmpty(txtSerie.Text) And Not String.IsNullOrEmpty(txtNumero.Text) And _
        Not String.IsNullOrEmpty(txtProveedor.Text) Then
            Return String.Concat("Por ingreso de dinero por nota de debito", Space(1), "Nro.", Space(1), txtSerie.Text, "-", txtNumero.Text)
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
        objCajaDetalle.DetalleItem = "Por nota de debito"
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
        Dim DocCaja As New documento
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

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
            .tipoDoc = "08"
            .fechaProceso = fecha
            .nroDoc = txtSerie.Text & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idPadre = IdCompraOrigen
            .codigoLibro = "1"
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

            .destino = TIPO_COMPRA.NOTA_DEBITO
            If CDec(lblBonificaMN.Text) > 0 Then
                If chDeposito.Checked = True Then
                    .estadoPago = Nota_Credito.DINERO_ENTREGADO
                Else
                    .estadoPago = Nota_Credito.DINERO_PENDIENTE_DE_ENTREGA
                End If
            Else
                'If chProceso.Checked = True Then
                '    .estadoPago = Nota_Credito.PROCESADO_SIN_MOVIMIENTOS
                'End If
            End If
            .glosa = GlosaNotas()
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.NOTA_DEBITO
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
            .sustentado = "01"
        End With
        ndocumento.documentocompra = nDocumentoCompra


        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.secuencia = i.Cells(0).Value()
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc

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
                    objDocumentoCompraDet.importeUS = CDec(i.Cells(11).Value())
                    objDocumentoCompraDet.montokardex = CDec(i.Cells(12).Value())
                    objDocumentoCompraDet.montoIsc = CDec(i.Cells(13).Value())
                    objDocumentoCompraDet.montoIgv = CDec(i.Cells(14).Value())
                    objDocumentoCompraDet.otrosTributos = CDec(i.Cells(15).Value())
                    '**********************************************************************************
                    objDocumentoCompraDet.montokardexUS = CDec(i.Cells(16).Value())
                    objDocumentoCompraDet.montoIscUS = CDec(i.Cells(17).Value())
                    objDocumentoCompraDet.montoIgvUS = CDec(i.Cells(18).Value())
                    objDocumentoCompraDet.otrosTributosUS = CDec(i.Cells(19).Value())


                Case Else
                    Select Case "01" ' strTipoNota
                        Case Notas_Credito.DEV_EXISTENCIA
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
                            objDocumentoCompraDet.monto1 = 0
                            objDocumentoCompraDet.importe = CDec(i.Cells(10).Value())
                            objDocumentoCompraDet.importeUS = CDec(i.Cells(11).Value())
                            objDocumentoCompraDet.montokardex = CDec(i.Cells(12).Value())
                            objDocumentoCompraDet.montoIsc = CDec(i.Cells(13).Value())
                            objDocumentoCompraDet.montoIgv = CDec(i.Cells(14).Value())
                            objDocumentoCompraDet.otrosTributos = CDec(i.Cells(15).Value())
                            '**********************************************************************************
                            objDocumentoCompraDet.montokardexUS = CDec(i.Cells(16).Value())
                            objDocumentoCompraDet.montoIscUS = CDec(i.Cells(17).Value())
                            objDocumentoCompraDet.montoIgvUS = CDec(i.Cells(18).Value())
                            objDocumentoCompraDet.otrosTributosUS = CDec(i.Cells(19).Value())

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
                            objDocumentoCompraDet.importeUS = CDec(i.Cells(11).Value())
                            objDocumentoCompraDet.montokardex = CDec(i.Cells(12).Value())
                            objDocumentoCompraDet.montoIsc = CDec(i.Cells(13).Value())
                            objDocumentoCompraDet.montoIgv = CDec(i.Cells(14).Value())
                            objDocumentoCompraDet.otrosTributos = CDec(i.Cells(15).Value())
                            '**********************************************************************************
                            objDocumentoCompraDet.montokardexUS = CDec(i.Cells(16).Value())
                            objDocumentoCompraDet.montoIscUS = CDec(i.Cells(17).Value())
                            objDocumentoCompraDet.montoIgvUS = CDec(i.Cells(18).Value())
                            objDocumentoCompraDet.otrosTributosUS = CDec(i.Cells(19).Value())

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
            objDocumentoCompraDet.precioUnitario = CDec(i.Cells(8).Value())
            objDocumentoCompraDet.precioUnitarioUS = CDec(i.Cells(9).Value())



            objDocumentoCompraDet.preEvento = i.Cells(23).Value() '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
            objDocumentoCompraDet.bonificacion = i.Cells(29).Value()


            objDocumentoCompraDet.idPadreDTCompra = i.Cells(0).Value()
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = "Jiuni"
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = GlosaNotas()
            ' objDocumentoCompraDet.BonificacionMN =

            ListaDetalle.Add(objDocumentoCompraDet)
        Next
        If chDeposito.Checked = True Then
            DocCaja = ComprobanteCaja()
        End If

        ListaTotales = ListaTotalesAlmacen()
        AsientoNotaDedito()
        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        Dim xcod As Integer = CompraSA.SaveCompraNotaDebito(ndocumento, ListaTotales, DocCaja)
        lblEstado.Text = "nota de débito registrada!"
        lblEstado.Image = My.Resources.ok4
        Dispose()
    End Sub
#End Region

    Private Sub frmDebito_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmDebito_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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

        '***********************************************************************
        If dgvNuevoDoc.Rows.Count > 0 Then
            Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
            Me.lblEstado.Text = "Done!"
            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                Grabar()
            Else
                Dim Filas As Integer = dgvNuevoDoc.DisplayedRowCount(True)
                If Filas > 0 Then
                    '  UpdateCompra()
                Else
                    Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                    Me.lblEstado.Text = "Ingrese items a la canasta de nota de débito!"
                    'Timer1.Enabled = True
                    'TiempoEjecutar(5)
                End If


            End If
        Else
            Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
            Me.lblEstado.Text = "Ingrese items a la canasta de nota de débito!"
            'Timer1.Enabled = True
            'TiempoEjecutar(5)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PegarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub btnInfoCompra_Click(sender As System.Object, e As System.EventArgs) Handles btnInfoCompra.Click
        Me.Cursor = Cursors.WaitCursor
        InfoCompra(Sys.Proceso)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnInfoCompra_MouseLeave(sender As Object, e As System.EventArgs) Handles btnInfoCompra.MouseLeave
        toolTip.Close()
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

    Private Sub lsvCanasta_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvCanasta.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Dim nInsumoSA As New detalleitemsSA
        Dim n As New GInsumo()
        Dim tablaSA As New tablaDetalleSA
        Dim objInsumo As GInsumo = GInsumo.InstanceSingle
        Try
            If lsvCanasta.SelectedItems.Count > 0 Then

                objInsumo.Clear()
                objInsumo.Secuencia = lsvCanasta.SelectedItems(0).SubItems(0).Text
                If CStr(lsvCanasta.SelectedItems(0).SubItems(9).Text).Trim.Length > 0 Then
                    objInsumo.IdActividadRecurso = lsvCanasta.SelectedItems(0).SubItems(9).Text
                End If
                objInsumo.IdInsumo = lsvCanasta.SelectedItems(0).SubItems(1).Text
                objInsumo.origenProducto = lsvCanasta.SelectedItems(0).SubItems(20).Text
                objInsumo.descripcionItem = lsvCanasta.SelectedItems(0).SubItems(2).Text
                objInsumo.tipoExistencia = lsvCanasta.SelectedItems(0).SubItems(10).Text
                objInsumo.unidad1 = lsvCanasta.SelectedItems(0).SubItems(3).Text
                objInsumo.Cantidad = lsvCanasta.SelectedItems(0).SubItems(19).Text
                objInsumo.PU = 0 ' lsvCanasta.SelectedItems(0).SubItems(6).Text
                objInsumo.Total = lsvCanasta.SelectedItems(0).SubItems(15).Text
                Select Case lsvCanasta.SelectedItems(0).SubItems(10).Text
                    Case "GS"

                    Case Else
                        With nInsumoSA.InvocarProductoID(lsvCanasta.SelectedItems(0).SubItems(1).Text)
                            objInsumo.origenProducto = .origenProducto
                            objInsumo.cuenta = .cuenta
                            objInsumo.presentacion = .presentacion
                            objInsumo.Nombrepresentacion = tablaSA.GetUbicarTablaID(21, .presentacion).descripcion
                        End With
                        objInsumo.IdAlmacen = lsvCanasta.SelectedItems(0).SubItems(8).Text
                End Select

            End If

            If Not IsNothing(objInsumo.descripcionItem) Then
                If ExisteDatoEnGrid(objInsumo.IdInsumo) = False Then
                    dgvNuevoDoc.Rows.Add(objInsumo.Secuencia, objInsumo.origenProducto,
                                   objInsumo.IdInsumo,
                                   objInsumo.descripcionItem,
                                   objInsumo.presentacion,
                                   objInsumo.Nombrepresentacion,
                                   objInsumo.unidad1,
                                   objInsumo.Cantidad,
                                   objInsumo.PU,
                                   objInsumo.PU,
                                   objInsumo.Total,
                                   objInsumo.Total, 0,
                                    0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                    objInsumo.tipoExistencia, objInsumo.cuenta, objInsumo.IdActividadRecurso, Nothing,
                                     Nothing, Nothing, Nothing, Nothing, Nothing, objInsumo.IdAlmacen,
                                     objInsumo.Cantidad, objInsumo.Total)
                End If
            End If
            If dgvNuevoDoc.Rows.Count > 0 Then
                CellEndEditRefresh()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
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
            txtTipoCambio.Select()
        End If
    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As System.EventArgs) Handles txtNumero.LostFocus
        If txtNumero.Text.Trim.Length > 0 Then
            txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))
        End If
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


            If colCantidad > 0 Then

                Select Case e.ColumnIndex

                    Case 10, 7
                        If Not CStr(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value).Trim.Length > 0 Then
                            lblEstado.Text = "Ingrese un importe válido!"
                            lblEstado.Image = My.Resources.warning2
                            Exit Sub
                        Else
                            colMN = dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value
                        End If
                        colPrecUnit = Math.Round(colMN / colCantidad, 2)
                        colBI = Math.Round(colMN / 1.18, 2)
                        colIGV = Math.Round((colMN / 1.18) * 0.18, 2) ' Math.Round(colBI * 0.18, 2)

                        saldoCan = CDec(dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value) - CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value)
                        saldoMN = CDec(dgvNuevoDoc.Item(34, dgvNuevoDoc.CurrentRow.Index).Value) - CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value)
                        Select Case TipoCompra
                            Case TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION, TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
                                dgvNuevoDoc.Item(37, dgvNuevoDoc.CurrentRow.Index).Value = CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value)
                            Case Else
                                If saldoMN < 0 Then
                                    saldoMN = saldoMN * -1
                                    dgvNuevoDoc.Item(37, dgvNuevoDoc.CurrentRow.Index).Value = saldoMN.ToString("N2")
                                    '    chProceso.Checked = False
                                Else
                                    dgvNuevoDoc.Item(37, dgvNuevoDoc.CurrentRow.Index).Value = "0.00"
                                    '   chProceso.Checked = True
                                End If
                        End Select


                        dgvNuevoDoc.Item(36, dgvNuevoDoc.CurrentRow.Index).Value = saldoCan.ToString("N2")


                        Select Case txtIdComprobanteNota.Text
                            'Case "08"
                            '    If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteNeto" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "OTCus" Then
                            '        totales_xx()
                            '    End If
                            Case "03", "02"
                                If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteNeto" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "OTCus" Then
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
                                        dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        Exit Sub

                                    ElseIf colCantidad = 0 Then
                                        If Moneda = 1 Then
                                            ' DATOS SOLES
                                            Select Case colDestinoGravado
                                                Case "4"
                                                    '     dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                                    dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2")
                                                    'dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(17, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                Case Else
                                                    '   dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                                    dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2")
                                                    'dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), 4)
                                                    'dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(17, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                            End Select

                                        End If
                                    ElseIf colCantidad > 0 Then
                                        If Moneda = 1 Then
                                            ' DATOS SOLES
                                            If dgvNuevoDoc.Item(1, dgvNuevoDoc.CurrentRow.Index).Value = "4" Then
                                                dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2")
                                                dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / colCantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                                dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") 'CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")

                                                'dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(17, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                            Else
                                                dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") 'CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                                dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                                dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")


                                                'dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(17, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
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
                                If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteNeto" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "OTCus" Then
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
                                        dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
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
                                                    'dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                                    'dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), 4)
                                                    'dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES
                                                    dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES

                                                Case Else

                                                    If dgvNuevoDoc.Item(27, dgvNuevoDoc.CurrentRow.Index).Value() = "S" Then
                                                        'dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                                        'dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), 4)
                                                        dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                                        'dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                                        'dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                                        'dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto igv del item
                                                        'dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el kardex USD
                                                        'dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el IGV USD
                                                        'dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                                                    Else
                                                        'dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                                        'dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), 4)
                                                        dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                                        'dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                                        dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = colBI.ToString("N2") ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                                        dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV.ToString("N2")  ' Math.Round(CDec(neto - CDec(dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                                        'dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                                        'dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() - CDec(dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                                        dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() / txtTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES
                                                    End If
                                            End Select

                                        End If
                                    ElseIf colCantidad > 0 Then
                                        If Moneda = 1 Then
                                            ' DATOS SOLES
                                            If colDestinoGravado = "4" Then
                                                dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                                dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                                'dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                                'dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                                dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")
                                                '  dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                                '  dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(neto - CDec(dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos) ' monto igv del item

                                                ' dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex USD
                                                ' dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() - CDec(dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV USD


                                                'dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() / nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS DOLARES
                                            Else
                                                If dgvNuevoDoc.Item(27, dgvNuevoDoc.CurrentRow.Index).Value() = "S" Then
                                                    dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") '  CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                                    dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                                    'dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                                    'dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                                    dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")
                                                    'dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                                    'dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto igv del item

                                                    'dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el kardex USD
                                                    'dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el IGV USD


                                                    '   dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                                                Else
                                                    dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                                    dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                                    'dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                                    'dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                                    dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")
                                                    dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = colBI.ToString("N2") ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                                    dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV.ToString("N2") ' Math.Round(CDec(neto - CDec(dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                                    'dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                                    'dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() - CDec(dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD

                                                    dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() / txtTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES
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
                            colME = dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value
                        End If
                        colPrecUnitUSD = Math.Round(colME / colCantidad, 2)
                        colBI_ME = Math.Round(colME / 1.18, 2)

                        colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)

                        saldoCan = CDec(dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value) - CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value)
                        saldoME = CDec(dgvNuevoDoc.Item(35, dgvNuevoDoc.CurrentRow.Index).Value) - CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value)

                        dgvNuevoDoc.Item(36, dgvNuevoDoc.CurrentRow.Index).Value = saldoCan.ToString("N2")

                        Select Case TipoCompra
                            Case TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION, TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
                                dgvNuevoDoc.Item(38, dgvNuevoDoc.CurrentRow.Index).Value = CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value)
                            Case Else
                                If saldoME < 0 Then
                                    saldoME = saldoME * -1
                                    dgvNuevoDoc.Item(38, dgvNuevoDoc.CurrentRow.Index).Value = saldoME.ToString("N2")
                                    '    chProceso.Checked = False
                                Else
                                    dgvNuevoDoc.Item(38, dgvNuevoDoc.CurrentRow.Index).Value = "0.00"
                                    '    chProceso.Checked = True
                                End If
                        End Select

                        Select Case txtIdComprobanteNota.Text
                            Case "03", "02"
                                If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteNeto" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "OTCus" Then
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
                                        dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
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
                                                    '   dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                                    dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2")  ' MONTO TOTAL DOLARES
                                                    'dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), 4)

                                                    'dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(17, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                Case Else
                                                    '      dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                                    dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                                    'dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), 4)
                                                    'dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(17, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                    'dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                            End Select
                                        End If
                                    ElseIf colCantidad > 0 Then
                                        If Moneda = 1 Then
                                            ' DATOS SOLES
                                            If dgvNuevoDoc.Item(1, dgvNuevoDoc.CurrentRow.Index).Value = "4" Then
                                                dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2")
                                                ' dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(neto / colCantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                                dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / colCantidad), NumDigitos).ToString("N2")
                                                dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                                '    dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" 'CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")

                                                'dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(17, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                            Else
                                                dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") 'CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                                '   dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                                dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                                dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                                '  dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")


                                                'dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(17, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                                'dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
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
                                        dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
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
                                                    'dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                                    'dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), 4)
                                                    dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES
                                                    '          dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES

                                                Case Else

                                                    If dgvNuevoDoc.Item(27, dgvNuevoDoc.CurrentRow.Index).Value() = "S" Then
                                                        'dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                                        'dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), 4)
                                                        'dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                                        dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                                        'dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                                        'dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto igv del item
                                                        'dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el kardex USD
                                                        'dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el IGV USD
                                                        'dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                                                    Else
                                                        'dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                                        'dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), 4)
                                                        'dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                                        dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                                        'dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                                        'dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"  ' Math.Round(CDec(neto - CDec(dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                                        dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                                        dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV_ME.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() - CDec(dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                                        dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() / txtTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES
                                                    End If
                                            End Select

                                        End If
                                    ElseIf colCantidad > 0 Then
                                        If Moneda = 1 Then
                                            ' DATOS SOLES
                                            If colDestinoGravado = "4" Then
                                                dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                                '  dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                                dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                                dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                                '   dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")
                                                '  dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                                '  dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(neto - CDec(dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos) ' monto igv del item

                                                ' dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex USD
                                                ' dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() - CDec(dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV USD


                                                'dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() / nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS DOLARES
                                            Else
                                                If dgvNuevoDoc.Item(27, dgvNuevoDoc.CurrentRow.Index).Value() = "S" Then
                                                    dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") '  CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                                    '   dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                                    dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                                    dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                                    'dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")
                                                    'dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                                    'dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto igv del item

                                                    'dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el kardex USD
                                                    'dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el IGV USD


                                                    'dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                                                Else
                                                    dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                                    '  dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                                    dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                                    dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                                    'dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")
                                                    'dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                                    'dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(neto - CDec(dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                                    dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                                    dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV_ME.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() - CDec(dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                                    dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() / txtTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES

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


                'saldoCan = CDec(dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value) - CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value)
                'saldoMN = CDec(dgvNuevoDoc.Item(34, dgvNuevoDoc.CurrentRow.Index).Value) - CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value)
                'saldoME = CDec(dgvNuevoDoc.Item(35, dgvNuevoDoc.CurrentRow.Index).Value) - CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value)


                'dgvNuevoDoc.Item(36, dgvNuevoDoc.CurrentRow.Index).Value = saldoCan
                'dgvNuevoDoc.Item(37, dgvNuevoDoc.CurrentRow.Index).Value = saldoMN
                'dgvNuevoDoc.Item(38, dgvNuevoDoc.CurrentRow.Index).Value = saldoME
            Else
                'colPrecUnit = 0

                'colPrecUnitUSD = 0

                'colBI = 0
                'colBI_ME = 0
                'colIGV = 0
                'colIGV_ME = 0
            End If

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

            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                If e.ColumnIndex = Me.dgvNuevoDoc.Columns("Can1").Index _
AndAlso (e.Value IsNot Nothing) Then
                    dgvNuevoDoc.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = "Cantidad máxima: " & CDec(dgvNuevoDoc.Rows(e.RowIndex).Cells(31).Value).ToString("N2")
                    If CDec(dgvNuevoDoc.Rows(e.RowIndex).Cells(7).Value) > CDec(dgvNuevoDoc.Rows(e.RowIndex).Cells(31).Value) Then
                        lblEstado.Text = "La cantidad ingresada excede a la cantidad del comprobante!"

                        dgvNuevoDoc.Rows(e.RowIndex).Cells(7).Value = 0
                        dgvNuevoDoc.Rows(e.RowIndex).Cells(8).Value = 0
                        dgvNuevoDoc.Rows(e.RowIndex).Cells(9).Value = 0
                    End If
                ElseIf e.ColumnIndex = Me.dgvNuevoDoc.Columns("ImporteNeto").Index _
    AndAlso (e.Value IsNot Nothing) Then
                    dgvNuevoDoc.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = "Importe máximo: " & CDec(dgvNuevoDoc.Rows(e.RowIndex).Cells(32).Value).ToString("N2")
                    If CDec(dgvNuevoDoc.Rows(e.RowIndex).Cells(10).Value) > CDec(dgvNuevoDoc.Rows(e.RowIndex).Cells(32).Value) Then
                        lblEstado.Text = "El importe ingresado es mayor al de origen, ingrese un valor menor!"

                        dgvNuevoDoc.Rows(e.RowIndex).Cells(10).Value = 0
                        dgvNuevoDoc.Rows(e.RowIndex).Cells(11).Value = 0
                        dgvNuevoDoc.Rows(e.RowIndex).Cells(8).Value = 0
                        dgvNuevoDoc.Rows(e.RowIndex).Cells(9).Value = 0
                    End If
                End If
            End If
        End If
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
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(10, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            Else
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(10, Me.dgvNuevoDoc.CurrentCell.RowIndex)
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

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        Me.popupControlContainer1.ParentControl = Me.txtProveedor
        Me.popupControlContainer1.ShowPopup(Point.Empty)
        CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

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
                        lsvCanasta.Items.Clear()
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

    Private Sub TextBoxExt1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt1.TextChanged

    End Sub

    Private Sub lsvCanasta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvCanasta.SelectedIndexChanged

    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProveedor.SelectedIndexChanged

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

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

  
    Private Sub chDeposito_CheckedChanged(sender As Object, e As EventArgs) Handles chDeposito.CheckedChanged
        If chDeposito.Checked = True Then
            PictureBox1.Visible = True
        Else
            PictureBox1.Visible = False
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
End Class