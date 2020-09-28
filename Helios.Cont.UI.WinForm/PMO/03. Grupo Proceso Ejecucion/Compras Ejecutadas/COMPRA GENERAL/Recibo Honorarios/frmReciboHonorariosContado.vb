Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class frmReciboHonorariosContado
    Inherits frmMaster
    Dim ListaAsientonTransito As New List(Of asiento)
    Public Property TotalesXcanbeceras As TotalesXcanbecera
    Public Property idAlmacenVirtual() As Integer
    Public Property ManipulacionEstado() As String
    Public Property ListaTipoCambio As New List(Of tipoCambio)
    Private idPadreOrden As Integer
    Dim gridCaja As New GridGroupingControl
    Dim saldoMN As Decimal

    Public Class TotalesXcanbecera
        '   Private base_mn, base_me, igv_mn, igv_me, total_mn, total_me As Decimal?

        Public Property BaseMN() As Decimal
        Public Property BaseME() As Decimal
        Public Property IgvMN() As Decimal
        Public Property IgvME() As Decimal
        Public Property TotalMN() As Decimal
        Public Property TotalME() As Decimal

        Public Property base1() As Decimal
        Public Property base1me() As Decimal
        Public Property base2() As Decimal
        Public Property base2me() As Decimal
        Public Property MontoIgv1() As Decimal
        Public Property MontoIgv1me() As Decimal
        Public Property MontoIgv2() As Decimal
        Public Property MontoIgv2me() As Decimal

        Public Property PercepcionMN() As Decimal
        Public Property PercepcionME() As Decimal

        Public Sub New()
            BaseMN = 0
            BaseME = 0
            IgvMN = 0
            IgvME = 0
            TotalMN = 0
            TotalME = 0
            base1 = 0
            base1me = 0
            base2 = 0
            base2me = 0
            MontoIgv1 = 0
            MontoIgv1me = 0
            MontoIgv2 = 0
            MontoIgv2me = 0
            PercepcionMN = 0
            PercepcionME = 0
        End Sub


    End Class

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Loadcontroles()
        If tmpConfigInicio.proyecto = "S" Then
            AddColumnProyecto()
        End If
        GetTableGrid()
        ConfiguracionInicio()
        saldoMN = DigitalGauge2.Value
        Me.KeyPreview = True
    End Sub

    Public Sub New(IdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Loadcontroles()
        If tmpConfigInicio.proyecto = "S" Then
            AddColumnProyecto()
        End If
        GetTableGrid()
        ConfiguracionInicio()
        UbicarDocumento(IdDocumento)
        saldoMN = DigitalGauge2.Value
        Me.KeyPreview = True
    End Sub

    Public Sub New(IdDocumento As Integer, strTipo As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Loadcontroles()
        If tmpConfigInicio.proyecto = "S" Then
            AddColumnProyecto()
        End If
        GetTableGrid()
        ConfiguracionInicio()
        UbicarDocumentoOrden(IdDocumento)
        idPadreOrden = IdDocumento
    End Sub

    Dim cuentaMascaraSA As New cuentaMascaraSA
    Dim cuentaMascara As New cuentaMascara
#Region "Métodos"

    Public Sub llenarGrid(grid As GridGroupingControl, tag As Integer)
        Dim empresaPeriodoSA As New empresaCierreMensualSA
        Dim compraSA As New DocumentoCompraSA
        If (tag = 1) Then
            Me.Cursor = Cursors.WaitCursor

            gridCaja = grid

            CalculoPagos()

            Try
                If IsNothing(txtFecVcto) Then
                    lblEstado.Text = "Ingresar la fecha de vencimiento"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                End If

                If Not txtSerie.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingresar un número de serie válido"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                Else
                    lblEstado.Text = "Done serie"
                End If

                If Not txtProveedor.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingresar un proveedor válido"

                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                Else
                    lblEstado.Text = "Done proveedor"

                End If

                If Not txtNumero.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingresar un número de comprobante válido"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                Else
                    lblEstado.Text = "Done número comprobante"

                End If

                If txtFecha.IsNullDate Then
                    lblEstado.Text = "Ingrese una fecha de vcto. válida"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                    Me.Cursor = Cursors.Arrow
                End If

                '***********************************************************************
                If dgvCompra.Table.Records.Count > 0 Then
                    Me.lblEstado.Text = "Done!"
                    If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                        Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = txtFecha.Value.Year, .mes = txtFecha.Value.Month})
                        If Not IsNothing(valida) Then
                            If valida = True Then
                                MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Cursor = Cursors.Default
                                Exit Sub
                            End If
                        End If

                        Dim comprobante = compraSA.CompraEsvalida(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                            .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                            .serie = txtSerie.Text.Trim,
                                                                                            .numeroDoc = txtNumero.Text.Trim,
                                                                                            .tipoDoc = "02",
                                                                                            .idProveedor = txtProveedor.Tag})

                        If comprobante = True Then ' si la compra es unica
                            Grabar()
                            Close()
                        Else
                            If MessageBox.Show("El número de comprobante ya existe en la base de datos!, desea seguir?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                Grabar()
                                Close()
                            End If
                        End If
                    ElseIf ManipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                        'Dim Filas As Integer = dgvCompra.DisplayedRowCount(True)
                        'If Filas > 0 Then
                        '    UpdateCompra()

                        'UpdateServicioPublico()
                    End If
                Else

                    Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                End If
            Catch ex As Exception
                lblEstado.Text = ex.Message
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                ListaAsientonTransito = New List(Of asiento)

            End Try
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Sub CalculoPagos()
        For Each i In dgvCompra.Table.Records
            i.SetValue("estado", "NO")
            i.SetValue("pagado", i.GetValue("totalmn"))
        Next

        For Each i As Record In gridCaja.Table.Records
            If CDbl(i.GetValue("montoMN")) > 0 Then
                CalculosSubpago(i)
            End If
        Next

    End Sub

    Sub CalculosSubpago(r As Record) 'row de pagos de cuentas financieras
        Dim pago As Decimal = CType((r.GetValue("montoMN")), Decimal)
        'Dim pagoME As Double = CType(r.GetValue("montoME"), Double)
        'Dim pagoME As Double
        'Dim valVenta As Double = 0
        Dim saldo As Double = 0
        'Dim saldoME As Double = 0

        Dim saldoPago As Double = 0
        'Dim saldoPagoME As Double = 0

        For Each i In dgvCompra.Table.Records
            Dim saldoGeneral As Double = i.GetValue("pagado") '+ saldoPago
            'Dim saldoGeneralME As Double = i.GetValue("pagadoME") '+ saldoPago

            If i.GetValue("estado") = "NO" Then

                If pago <= 0 Then
                    i.SetValue("estado", "NO")
                    i.SetValue("pagado", CType(i.GetValue("totalmn"), Double))
                    'i.SetValue("pagadoME", CType(i.GetValue("totalme"), Double))
                    Exit For
                End If

                If saldoGeneral >= pago Then
                    AddSubitemPago(r, pago, i)
                Else
                    AddSubitemPago(r, saldoGeneral, i)
                End If

                If pago >= saldoGeneral Then
                    i.SetValue("estado", "SI")
                    'pago = pago - saldoGeneral
                Else
                    i.SetValue("estado", "NO")
                    'pago = pago - saldoGeneral
                End If

                saldoPago = saldoGeneral - pago
                'saldoPagoME = saldoGeneralME - pagoME

                saldo = saldoGeneral - pago
                'saldoME = saldoGeneralME - pagoME

                If saldo <= 0 Then
                    'i.SetValue("estado", "SI")
                    i.SetValue("pagado", 0)
                    'i.SetValue("pagadoME", 0)
                Else
                    'i.SetValue("estado", "NO")
                    If saldo.ToString.Length > 3 Then
                        i.SetValue("pagado", (saldo))
                        'i.SetValue("pagadoME", Math.Round(saldoME, 2))
                    Else
                        i.SetValue("pagado", saldo)
                        'i.SetValue("pagadoME", saldoME)
                    End If
                End If

                pago = pago - saldoGeneral
                'pagoME = (pago * txtTipoCambio.Value)
            End If
        Next
    End Sub

    Sub AddSubitemPago(i As Record, valMN As Double, venta As Record)
        Dim oreg As New ListViewItem
        Dim tipoCambio As Decimal

        oreg = lsvPagosRegistrados.Items.Add(i.GetValue("pago"))
        oreg.SubItems.Add(i.GetValue("ef"))
        oreg.SubItems.Add(venta.GetValue("idProducto"))
        oreg.SubItems.Add(venta.GetValue("item"))
        oreg.SubItems.Add(valMN)
        tipoCambio = i.GetValue("tipocambio")
        'total = valMN / tipoCambi
        If (tipoCambio = 0) Then
            oreg.SubItems.Add((CDec(valMN / TmpTipoCambio)))
        Else

            oreg.SubItems.Add((CDec(valMN / tipoCambio)))
        End If

    End Sub

    Public Sub AddColumnProyecto()
        Dim costoSA As New recursoCostoSA
        dgvCompra.TableDescriptor.Columns.Add("proyecto")
        dgvCompra.TableDescriptor.VisibleColumns.Add("proyecto")
        dgvCompra.TableDescriptor.Columns("proyecto").MappingName = "proyecto"
        dgvCompra.TableDescriptor.Columns("proyecto").HeaderText = "Proyecto"
        dgvCompra.TableDescriptor.Columns("proyecto").Name = "proyecto"
        dgvCompra.TableDescriptor.Columns("proyecto").Width = 100
        dgvCompra.TableDescriptor.Columns("proyecto").ReadOnly = False
        dgvCompra.TableDescriptor.Columns("proyecto").AllowSort = False

        Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns("proyecto").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = costoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = "HC", .subtipo = "PY"})
        ggcStyle.ValueMember = "idCosto"
        ggcStyle.DisplayMember = "nombreCosto"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
    End Sub

    Sub TipoCambio()
        For Each r As Record In dgvCompra.Table.Records
            Dim cantidad As Decimal = 0
            Dim VC As Decimal = 0
            Dim VCme As Decimal = 0
            Dim Igv As Decimal = 0
            Dim IgvME As Decimal = 0
            Dim totalMN As Decimal = 0
            Dim colBI As Decimal = 0
            Dim colBIme As Decimal = 0
            Dim colPrecUnit As Decimal = 0
            Dim colPrecUnitme As Decimal = 0
            Dim colDestinoGravado As Integer

            Dim valPercepMN As Decimal = 0
            Dim valPercepME As Decimal = 0


            colDestinoGravado = r.GetValue("gravado")

            'If colDestinoGravado = 1 Then
            valPercepMN = r.GetValue("percepcionMN")
            valPercepME = r.GetValue("percepcionME")
            'Else
            'valPercepMN = 0
            'valPercepME = 0

            'End If

            '****************************************************************

            cantidad = r.GetValue("cantidad")
            r.SetValue("cantidad", cantidad.ToString("N2"))

            Select Case cboMoneda.SelectedValue
                Case 1
                    VC = r.GetValue("vcmn")
                    VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)
                Case 2

                    VCme = r.GetValue("vcme")
                    VC = Math.Round(VCme * CDec(txtTipoCambio.DecimalValue), 2)
            End Select

            If cantidad > 0 Then
                Igv = 0 ' Math.Round(VC * (TmpIGV / 100), 2)
                IgvME = 0 ' Math.Round(VCme * (TmpIGV / 100), 2)

                colBI = VC + Igv - valPercepMN
                colBIme = VCme + IgvME - valPercepME

                colPrecUnit = Math.Round(VC / cantidad, 2)
                colPrecUnitme = Math.Round(VCme / cantidad, 2)
            ElseIf cantidad = 0 Then
                Igv = 0 ' Math.Round(VC * (TmpIGV / 100), 2)
                IgvME = 0 ' Math.Round(VCme * (TmpIGV / 100), 2)
                colBI = VC + Igv - valPercepMN
                colBIme = VCme + IgvME - valPercepME
                colPrecUnit = 0
                colPrecUnitme = 0
            Else
                colPrecUnit = 0
                colPrecUnitme = 0

                colBI = 0
                colBIme = 0
                Igv = 0
                IgvME = 0
            End If

            ' DATOS SOLES
            r.SetValue("vcmn", VC.ToString("N2"))
            r.SetValue("vcme", VCme.ToString("N2"))
            r.SetValue("pumn", colPrecUnit.ToString("N2"))
            r.SetValue("pume", colPrecUnitme.ToString("N2"))
            r.SetValue("totalmn", colBI.ToString("N2"))
            r.SetValue("totalme", colBIme.ToString("N2"))
            r.SetValue("igvmn", 0)
            r.SetValue("igvme", 0)
            r.SetValue("percepcionMN", valPercepMN)
            r.SetValue("percepcionME", valPercepME)

        Next
        TotalTalesXcolumna()

    End Sub

    Public Sub UbicarDocumentoOrden(ByVal intIdDocumento As Integer)
        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New DocumentoCompraSA
        Dim objDocCompraDet As New DocumentoCompraDetalleSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad

        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim objDocCaja As New DocumentoSA
        Dim establecSA As New establecimientoSA
        Dim inventarioBL As New inventarioMovimientoSA
        Dim DocumentoGuiaSA As New DocumentoGuiaDetalleSA
        Dim DocumentoGuia As New documentoguiaDetalle

        Try

            'CABECERA COMPROBANTE
            With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
                If Not IsNothing(.fechaConstancia) Then
                    txtFecConstancia.Value = .fechaConstancia
                End If
                txtNroConstancia.Text = .nroConstancia
                txtFecha.Value = .fechaDoc
                lblIdDocumento.Text = .idDocumento
                lblPerido.Text = .fechaContable
                'txtSerie.Text = .serie
                'txtNumero.Text = .numeroDoc
                cboMoneda.SelectedValue = .monedaDoc

                txtOrden.Visible = True
                lblOrden.Visible = True


                Select Case cboMoneda.SelectedValue
                    Case 1

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

                        dgvCompra.TableDescriptor.Columns("pume").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 0
                        dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0

                        cboMoneda.SelectedValue = 1
                        tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                    Case 2

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 0

                        dgvCompra.TableDescriptor.Columns("pume").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 70
                        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 70
                        tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                        cboMoneda.SelectedValue = 2
                End Select

                nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                txtRuc.Text = nEntidad.nrodoc
                txtProveedor.Tag = nEntidad.idEntidad
                txtProveedor.Text = nEntidad.nombreCompleto

                txtTipoCambio.DecimalValue = .tcDolLoc
                txtIva.DoubleValue = .tasaIgv
                txtGlosa.Text = .glosa

                Select Case .destino
                    Case "SI"
                        cboRetencion.Text = "SI"
                        GroupBox2.Enabled = True
                        dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0
                        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
                    Case "NO"
                        cboRetencion.Text = "NO"
                        GroupBox2.Enabled = False
                        dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 70
                        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 70
                End Select

            End With

            'DETALLE DE LA COMPRA
            dgvCompra.Table.Records.DeleteAll()
            PanelServicios.Visible = False
            For Each i In objDocCompraDet.UbicarDocumentoCompraDetalle(intIdDocumento)

                Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", i.secuencia)
                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
                Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
                Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.descripcionItem)
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importe)

                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeUS)

                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", i.percepcionMN)
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", i.percepcionME)
                Me.dgvCompra.Table.CurrentRecord.SetValue("Action", "2")
                Me.dgvCompra.Table.CurrentRecord.SetValue("descripcion", i.descripcionItem)
                If tmpConfigInicio.proyecto = "S" Then
                    Me.dgvCompra.Table.CurrentRecord.SetValue("proyecto", i.idCosto)
                End If
                Me.dgvCompra.Table.AddNewRecord.EndEdit()
            Next
            btGrabar.Enabled = True
            TotalTalesXcolumna()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New DocumentoCompraSA
        Dim objDocCompraDet As New DocumentoCompraDetalleSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad

        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim objDocCaja As New DocumentoSA
        Dim establecSA As New establecimientoSA
        Dim inventarioBL As New inventarioMovimientoSA
        Dim DocumentoGuiaSA As New DocumentoGuiaDetalleSA
        Dim DocumentoGuia As New documentoguiaDetalle

        Try

            'CABECERA COMPROBANTE
            With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
                If Not IsNothing(.fechaConstancia) Then
                    txtFecConstancia.Value = .fechaConstancia
                End If
                txtNroConstancia.Text = .nroConstancia
                txtFecha.Value = .fechaDoc
                lblIdDocumento.Text = .idDocumento
                lblPerido.Text = .fechaContable
                txtSerie.Text = .serie
                txtNumero.Text = .numeroDoc
                cboMoneda.SelectedValue = .monedaDoc

                Select Case cboMoneda.SelectedValue
                    Case 1

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

                        dgvCompra.TableDescriptor.Columns("pume").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 0
                        dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0

                        cboMoneda.SelectedValue = 1
                        tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                    Case 2

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 0

                        dgvCompra.TableDescriptor.Columns("pume").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 70
                        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 70
                        tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                        cboMoneda.SelectedValue = 2
                End Select

                nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                txtRuc.Text = nEntidad.nrodoc
                txtProveedor.Text = nEntidad.nombreCompleto
                txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                txtTipoCambio.DecimalValue = .tcDolLoc
                txtIva.DoubleValue = .tasaIgv
                txtGlosa.Text = .glosa
                txtProveedor.Tag = nEntidad.idEntidad
                Select Case .destino
                    Case "SI"
                        cboRetencion.Text = "SI"
                        GroupBox2.Enabled = True
                        dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0
                        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
                    Case "NO"
                        cboRetencion.Text = "NO"
                        GroupBox2.Enabled = False
                        dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 70
                        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 70
                End Select

            End With

            'DETALLE DE LA COMPRA
            dgvCompra.Table.Records.DeleteAll()
            PanelServicios.Visible = False
            For Each i In objDocCompraDet.UbicarDocumentoCompraDetalle(intIdDocumento)

                Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", i.secuencia)
                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
                Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
                Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.descripcionItem)
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importe)

                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeUS)

                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", i.percepcionMN)
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", i.percepcionME)
                Me.dgvCompra.Table.CurrentRecord.SetValue("Action", "2")
                Me.dgvCompra.Table.CurrentRecord.SetValue("descripcion", i.descripcionItem)
                If tmpConfigInicio.proyecto = "S" Then
                    Me.dgvCompra.Table.CurrentRecord.SetValue("proyecto", i.idCosto)
                End If

                Me.dgvCompra.Table.AddNewRecord.EndEdit()
            Next
            btGrabar.Enabled = True
            TotalTalesXcolumna()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function AsientoCabeceraCompra(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        'ASIENTO POR LA COMPRA
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_ReciboHonorarios
        nAsiento.importeMN = TotalesXcanbeceras.TotalMN
        nAsiento.importeME = TotalesXcanbeceras.TotalME
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Public Function AS_IGV(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "40172",
              .descripcion = "I.G.V.",
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    Public Function AS_Proveedor(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "424",
              .descripcion = txtProveedor.Text,
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    Public Sub AsientoCompra()
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoCabeceraCompra(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME) ' CABECERA ASIENTO

        '---------------------------------------------------------------------------------------------
        'DETALLE DEL ASIENTO DE COMPRA
        'MOVIMIENTOS
        For Each r As Record In dgvCompra.Table.Records

            '   If dgvCompra.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
            nMovimiento = New movimiento
            nMovimiento.cuenta = r.GetValue("idProducto")
            nMovimiento.descripcion = r.GetValue("item")
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
            'nMovimiento.monto = CDec(r.GetValue("totalmn")) '''''''''''m
            'nMovimiento.montoUSD = CDec(r.GetValue("totalme")) ''''''''m
            nMovimiento.monto = CDec(r.GetValue("vcmn")) '''''''''''m
            nMovimiento.montoUSD = CDec(r.GetValue("vcme")) ''''''''m
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            asientoTransitod.movimiento.Add(nMovimiento)

            If cboRetencion.Text = "NO" Then
                If CDec(r.GetValue("percepcionMN")) > 0 Then
                    asientoTransitod.movimiento.Add(AS_IGV(CDec(r.GetValue("percepcionMN")), CDec(r.GetValue("percepcionME"))))
                End If
            End If


            '''''''''''''''''''''''''''''''''''''''''''''''''''
            'asiento del costo x entregar
            'nMovimiento = New movimiento
            'nMovimiento.cuenta = "91"
            'nMovimiento.descripcion = r.GetValue("item")
            'nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
            'nMovimiento.monto = CDec(r.GetValue("vcmn"))
            'nMovimiento.montoUSD = CDec(r.GetValue("vcme"))
            'nMovimiento.fechaActualizacion = DateTime.Now
            'nMovimiento.usuarioActualizacion = usuario.IDUsuario
            'asientoTransitod.movimiento.Add(nMovimiento)

            'nMovimiento = New movimiento
            'nMovimiento.cuenta = "791"
            'nMovimiento.descripcion = r.GetValue("item")
            'nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            'nMovimiento.monto = CDec(r.GetValue("vcmn"))
            'nMovimiento.montoUSD = CDec(r.GetValue("vcme"))
            'nMovimiento.fechaActualizacion = DateTime.Now
            'nMovimiento.usuarioActualizacion = usuario.IDUsuario
            'asientoTransitod.movimiento.Add(nMovimiento)

        Next
        asientoTransitod.movimiento.Add(AS_Proveedor(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub





    Sub UpdateHonorarios()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()

        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentocompradetalle)

        ListaAsientonTransito = New List(Of asiento)

        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()

        With ndocumento
            .idDocumento = lblIdDocumento.Text
            .Action = Business.Entity.BaseBE.EntityAction.UPDATE
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = "02"
            .fechaProceso = txtFecha.Value
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            '.TipoConfiguracion = GConfiguracion.TipoConfiguracion
            '.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .idDocumento = lblIdDocumento.Text
            .idPadre = Nothing
            .codigoLibro = "8"
            .tipoDoc = "02"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .fechaContable = lblPerido.Text
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text
            .idProveedor = CInt(txtProveedor.Tag)
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIva.DoubleValue
            .tcDolLoc = txtTipoCambio.DecimalValue
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing
            '****************** DESTINO EN SOLES ************************************************************************
            .bi01 = TotalesXcanbeceras.base1
            .bi02 = TotalesXcanbeceras.base2

            .igv01 = TotalesXcanbeceras.MontoIgv1
            .igv02 = TotalesXcanbeceras.MontoIgv2


            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = TotalesXcanbeceras.base1me
            .bi02us = TotalesXcanbeceras.base2me

            .igv01us = TotalesXcanbeceras.MontoIgv1me
            .igv02us = TotalesXcanbeceras.MontoIgv2me

            '****************************************************************************************************************
            .importeTotal = TotalesXcanbeceras.TotalMN
            .importeUS = TotalesXcanbeceras.TotalME
            .estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            .glosa = txtGlosa.Text.Trim
            .referenciaDestino = Nothing
            .tipoCompra = TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS
            If cboRetencion.Text = "SI" Then
                .destino = TIPO_SITUACION.SUSPENSION_RETENCION.TIENE
            Else
                .destino = TIPO_SITUACION.SUSPENSION_RETENCION.NO_TIENE
            End If
            .situacion = statusComprobantes.Normal
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        If CDec(txtTotalPagar.DecimalValue) > 0 Then
            AsientoCompra()
        End If
        'ASIENTOS CONTABLES
        For Each r As Record In dgvCompra.Table.Records

            objDocumentoCompraDet = New documentocompradetalle

            If tmpConfigInicio.proyecto = "S" Then

                Dim codproy = r.GetValue("proyecto")
                If IsNothing(codproy) Then
                    MessageBox.Show("Debe seleccionar un proyecto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If codproy.ToString.Trim.Length <= 0 Then
                    MessageBox.Show("Debe seleccionar un proyecto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                objDocumentoCompraDet.idCosto = CInt(r.GetValue("proyecto"))
                objDocumentoCompraDet.tipoCosto = "PY"
            Else
                objDocumentoCompraDet.tipoCosto = Nothing
            End If

            objDocumentoCompraDet.estadoPago = Nothing
            'agre



            'agre
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.tipoCompra = TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS
            objDocumentoCompraDet.FechaDoc = txtFecha.Value
            objDocumentoCompraDet.CuentaProvedor = "4212" ' txtCuenta.Text.Trim
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.Serie = txtSerie.Text.Trim
            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            objDocumentoCompraDet.TipoDoc = "02"
            objDocumentoCompraDet.destino = r.GetValue("gravado")
            objDocumentoCompraDet.CuentaItem = Nothing
            objDocumentoCompraDet.idItem = r.GetValue("idProducto")
            objDocumentoCompraDet.tipoExistencia = TipoRecurso.SERVICIO
            objDocumentoCompraDet.descripcionItem = r.GetValue("descripcion")


            If r.GetValue("Action") = 2 Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.UPDATE
            ElseIf r.GetValue("Action") = 1 Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            ElseIf r.GetValue("Action") = 3 Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.DELETE
            End If

            'If r.GetValue("Action") = Business.Entity.BaseBE.EntityAction.UPDATE Then

            'End If
            'ElseIf dgvCompra.Rows(i.Index).Cells(20).Value() = Business.Entity.BaseBE.EntityAction.INSERT Then
            '    objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            'ElseIf dgvCompra.Rows(i.Index).Cells(20).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then
            '    objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.DELETE
            'End If


            If IsNumeric(r.GetValue("cantidad")) Then
                If CDec(r.GetValue("cantidad")) < 0 Then
                    lblEstado.Text = "Debe ingresar una cantidad mayor a cero, " & r.GetValue("item")
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Exit Sub
                ElseIf CDec(r.GetValue("cantidad")) = 0 Then

                    If MessageBoxAdv.Show("Desea ingresar el item con cantidad cero?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        objDocumentoCompraDet.monto1 = 0
                    Else
                        lblEstado.Text = "Ingrese una cantidad mayor a cero del item, " & r.GetValue("item")
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        Exit Sub
                    End If
                Else
                    objDocumentoCompraDet.monto1 = CDec(r.GetValue("cantidad")) ' cantidad
                End If

            Else
                lblEstado.Text = "Ingrese una cantidad válida del item, " & r.GetValue("item")
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Exit Sub
            End If
            objDocumentoCompraDet.unidad1 = Nothing
            objDocumentoCompraDet.unidad2 = Nothing
            objDocumentoCompraDet.monto2 = Nothing
            objDocumentoCompraDet.almacenRef = Nothing
            objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoCompraDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            If IsNumeric(r.GetValue("totalmn")) Then
                If CDec(r.GetValue("totalmn")) > 0 Then
                    objDocumentoCompraDet.importe = CDec(r.GetValue("totalmn"))
                Else
                    lblEstado.Text = "Ingrese un importe mayor a cero del item, " & r.GetValue("item")
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If
            Else
                lblEstado.Text = "Ingrese un importe válido del item, " & r.GetValue("item")
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Exit Sub
            End If


            objDocumentoCompraDet.importeUS = CDec(r.GetValue("totalme"))
            objDocumentoCompraDet.montokardex = CDec(r.GetValue("vcmn"))



            objDocumentoCompraDet.montokardexUS = CDec(r.GetValue("vcme"))


            objDocumentoCompraDet.preEvento = Nothing  '= "00", Nothing, dgvCompra.Rows(S).Cells(23).Value())
            objDocumentoCompraDet.bonificacion = r.GetValue("valBonif")

            objDocumentoCompraDet.percepcionMN = CDec(r.GetValue("percepcionMN"))
            objDocumentoCompraDet.percepcionME = CDec(r.GetValue("percepcionME"))
            '**********************************************************************************
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvCompra.Rows(S).Cells(28).Value()), Nothing, CDate(dgvCompra.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
            objDocumentoCompraDet.secuencia = CDec(r.GetValue("codigo"))
            objDocumentoCompraDet.idDocumento = lblIdDocumento.Text
            ListaDetalle.Add(objDocumentoCompraDet)
        Next

        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        CompraSA.UpdateReciboHonorario(ndocumento)
        lblEstado.Text = "compra modificada!"
        Dispose()

    End Sub

    Sub Grabar()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()

        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentocompradetalle)

        ListaAsientonTransito = New List(Of asiento)

        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()

        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = "02"
            .fechaProceso = txtFecha.Value


            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            '.TipoConfiguracion = GConfiguracion.TipoConfiguracion
            '.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .idPadre = Nothing
            .codigoLibro = "8"
            .tipoDoc = "02"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            'martin
            .fechaVcto = txtFecVcto.Value
            .fechaContable = lblPerido.Text
            .fechaConstancia = txtFecConstancia.Value
            .nroConstancia = txtNroConstancia.Text
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text
            .idProveedor = CInt(txtProveedor.Tag)
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIva.DoubleValue
            .tcDolLoc = txtTipoCambio.DecimalValue
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing
            '****************** DESTINO EN SOLES ************************************************************************
            .bi01 = TotalesXcanbeceras.base1
            .bi02 = TotalesXcanbeceras.base2

            .igv01 = TotalesXcanbeceras.MontoIgv1
            .igv02 = TotalesXcanbeceras.MontoIgv2


            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = TotalesXcanbeceras.base1me
            .bi02us = TotalesXcanbeceras.base2me

            .igv01us = TotalesXcanbeceras.MontoIgv1me
            .igv02us = TotalesXcanbeceras.MontoIgv2me

            '****************************************************************************************************************
            .importeTotal = TotalesXcanbeceras.TotalMN
            .importeUS = TotalesXcanbeceras.TotalME
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = txtGlosa.Text.Trim
            .referenciaDestino = Nothing
            .tipoCompra = TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS
            If cboRetencion.Text = "SI" Then
                .destino = TIPO_SITUACION.SUSPENSION_RETENCION.TIENE
            Else
                .destino = TIPO_SITUACION.SUSPENSION_RETENCION.NO_TIENE
            End If
            Select Case chDetraccion.Checked
                Case True
                    .tieneDetraccion = "S"
                Case False
                    .tieneDetraccion = "N"
            End Select

            .aprobado = "N"
            .situacion = statusComprobantes.Normal
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        If CDec(txtTotalPagar.DecimalValue) > 0 Then
            AsientoCompra()
        End If
        'ASIENTOS CONTABLES
        For Each r As Record In dgvCompra.Table.Records
            objDocumentoCompraDet = New documentocompradetalle

            If tmpConfigInicio.proyecto = "S" Then

                Dim codproy = r.GetValue("proyecto")
                If IsNothing(codproy) Then
                    MessageBox.Show("Debe seleccionar un proyecto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If codproy.ToString.Trim.Length <= 0 Then
                    MessageBox.Show("Debe seleccionar un proyecto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                objDocumentoCompraDet.idCosto = CInt(r.GetValue("proyecto"))
                objDocumentoCompraDet.tipoCosto = "PY"
            Else
                objDocumentoCompraDet.tipoCosto = Nothing
            End If

            objDocumentoCompraDet.estadoPago = "PG"
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.tipoCompra = TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS
            objDocumentoCompraDet.FechaDoc = txtFecha.Value
            objDocumentoCompraDet.CuentaProvedor = "4212" ' txtCuenta.Text.Trim
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.Serie = txtSerie.Text.Trim
            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            objDocumentoCompraDet.TipoDoc = "02"
            objDocumentoCompraDet.destino = r.GetValue("gravado")
            objDocumentoCompraDet.CuentaItem = Nothing
            objDocumentoCompraDet.idItem = r.GetValue("idProducto")
            objDocumentoCompraDet.tipoExistencia = TipoRecurso.SERVICIO
            objDocumentoCompraDet.descripcionItem = r.GetValue("descripcion")

            If IsNumeric(r.GetValue("cantidad")) Then
                If CDec(r.GetValue("cantidad")) < 0 Then
                    lblEstado.Text = "Debe ingresar una cantidad mayor a cero, " & r.GetValue("item")
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Exit Sub
                ElseIf CDec(r.GetValue("cantidad")) = 0 Then

                    If MessageBoxAdv.Show("Desea ingresar el item con cantidad cero?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        objDocumentoCompraDet.monto1 = 0
                    Else
                        lblEstado.Text = "Ingrese una cantidad mayor a cero del item, " & r.GetValue("item")
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        Exit Sub
                    End If
                Else
                    objDocumentoCompraDet.monto1 = CDec(r.GetValue("cantidad")) ' cantidad
                End If

            Else
                lblEstado.Text = "Ingrese una cantidad válida del item, " & r.GetValue("item")
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Exit Sub
            End If
            objDocumentoCompraDet.unidad1 = Nothing
            objDocumentoCompraDet.unidad2 = Nothing
            objDocumentoCompraDet.monto2 = Nothing
            objDocumentoCompraDet.almacenRef = Nothing
            objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoCompraDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            If IsNumeric(r.GetValue("totalmn")) Then
                If CDec(r.GetValue("totalmn")) > 0 Then
                    objDocumentoCompraDet.importe = CDec(r.GetValue("totalmn"))
                Else
                    lblEstado.Text = "Ingrese un importe mayor a cero del item, " & r.GetValue("item")
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If

            Else
                lblEstado.Text = "Ingrese un importe válido del item, " & r.GetValue("item")
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Exit Sub
            End If


            objDocumentoCompraDet.importeUS = CDec(r.GetValue("totalme"))
            objDocumentoCompraDet.montokardex = CDec(r.GetValue("vcmn"))
            objDocumentoCompraDet.montoIsc = 0 ' CDec(i.Cells(13).Value())
            objDocumentoCompraDet.montoIgv = CDec(r.GetValue("igvmn"))
            objDocumentoCompraDet.otrosTributos = 0 ' CDec(i.Cells(15).Value())
            '**********************************************************************************
            objDocumentoCompraDet.montokardexUS = CDec(r.GetValue("vcme"))
            objDocumentoCompraDet.montoIscUS = 0
            objDocumentoCompraDet.montoIgvUS = CDec(r.GetValue("igvme"))
            objDocumentoCompraDet.otrosTributosUS = 0
            objDocumentoCompraDet.preEvento = Nothing  '= "00", Nothing, dgvCompra.Rows(S).Cells(23).Value())
            objDocumentoCompraDet.bonificacion = r.GetValue("valBonif")

            objDocumentoCompraDet.percepcionMN = CDec(r.GetValue("percepcionMN"))
            objDocumentoCompraDet.percepcionME = CDec(r.GetValue("percepcionME"))
            '**********************************************************************************
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvCompra.Rows(S).Cells(28).Value()), Nothing, CDate(dgvCompra.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
            ListaDetalle.Add(objDocumentoCompraDet)
        Next
        ndocumento.ListaCustomDocumento = ListaDocumentoCaja()
        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        Dim xcod As Integer = CompraSA.SaveRegistroHonorarios(ndocumento)
        lblEstado.Text = "compra registrada!"
        If tmpConfigInicio.cronogramaPagos = True Then
            If Not ComboBoxAdv2.Text = "DE CONTADO" Then
                If MessageBox.Show("¿Desea Negociar?" + vbCrLf + vbCrLf + Space(15) + txtFecha.Text, txtFecha.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then


                    With frmNegociacionPagos
                        .lblIdDocumento.Text = xcod
                        .txtImporteCompramn.Value = TotalesXcanbeceras.TotalMN
                        .txtImporteComprame.Value = TotalesXcanbeceras.TotalME
                        .txttipocambio.Value = txtTipoCambio.DecimalValue
                        ' .txtMoneda.Text = IIf(cboMoneda.SelectedValue = 1, "1", "2")
                        If cboMoneda.SelectedValue = "1" Then
                            .txtMoneda.Text = "NAC"
                        ElseIf cboMoneda.SelectedValue = "2" Then
                            .txtMoneda.Text = "EXT"
                        End If
                        .txtSerie.Text = txtSerie.Text.Trim
                        .txtNumero.Text = txtNumero.Text
                        .txtCliente.Text = txtProveedor.Text
                        .txtCliente.Tag = CInt(txtProveedor.Tag)
                        .txtRuc.Text = txtRuc.Text
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With

                Else

                End If

            End If
        End If
        '   Dispose()
    End Sub

    Private Sub ListaDetalleCaja(doc As documentoCaja)
        Dim obj As New documentoCajaDetalle
        Dim lista As New List(Of documentoCajaDetalle)
        For Each i As ListViewItem In lsvPagosRegistrados.Items
            If doc.NombreEntidad = i.SubItems(1).Text Then
                obj = New documentoCajaDetalle
                obj.fecha = Date.Now
                obj.idItem = CInt(i.SubItems(2).Text)
                obj.DetalleItem = i.SubItems(3).Text
                obj.montoSoles = CDbl(i.SubItems(4).Text)
                obj.montoUsd = CDbl(i.SubItems(5).Text)

                Select Case doc.moneda
                    Case 1
                        obj.diferTipoCambio = TmpTipoCambio
                        obj.tipoCambioTransacc = TmpTipoCambio
                    Case 2
                        obj.diferTipoCambio = doc.tipoCambio
                        obj.tipoCambioTransacc = doc.tipoCambio
                End Select


                obj.entregado = "SI"
                obj.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
                obj.usuarioModificacion = usuario.IDUsuario
                obj.documentoAfectado = CInt(Me.Tag)
                obj.fechaModificacion = DateTime.Now
                lista.Add(obj)
            End If
        Next
        doc.documentoCajaDetalle = lista
    End Sub


    Sub asientoDocumento(doc As documentoCaja)
        Dim asiento As New asiento
        Dim nMovimiento As New movimiento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros


        ef = efSA.GetUbicar_estadosFinancierosPorID(doc.entidadFinanciera)

        asiento = AsientoTransito2(doc.montoSoles, doc.montoUsd)

        ListaAsientonTransito.Add(asiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = ef.cuenta
        nMovimiento.descripcion = ef.descripcion
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)


        nMovimiento = New movimiento
        nMovimiento.cuenta = "4212"
        nMovimiento.descripcion = "Compra al contado"
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asiento.movimiento.Add(nMovimiento)

        'nMovimiento = New movimiento
        'nMovimiento.cuenta = "1213"
        'nMovimiento.descripcion = txtProveedor.Text
        'nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        'nMovimiento.monto = doc.montoSoles
        'nMovimiento.montoUSD = doc.montoUsd
        'nMovimiento.usuarioActualizacion = usuario.IDUsuario
        'nMovimiento.fechaActualizacion = DateTime.Now
        'asiento.movimiento.Add(nMovimiento)

    End Sub

    Public Function AsientoTransito2(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.periodo = lblPerido.Text
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = Nothing ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_COMPRAS
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_ReciboHonorarios
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Function ListaDocumentoCaja() As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)

        For Each i In gridCaja.Table.Records
            If CDbl(i.GetValue("montoMN") > 0) Then
                nDocumentoCaja = New documento
                'DOCUMENTO
                nDocumentoCaja.idDocumento = CInt(Me.Tag)
                nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
                nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
                nDocumentoCaja.tipoDoc = "14"
                nDocumentoCaja.fechaProceso = txtFecha.Value
                nDocumentoCaja.nroDoc = txtNumero.Text
                nDocumentoCaja.idOrden = Nothing
                Select Case i.GetValue("moneda")
                    Case "NACIONAL"
                        nDocumentoCaja.moneda = 1
                    Case "EXTRANJERO"
                        nDocumentoCaja.moneda = 2
                End Select
                nDocumentoCaja.idEntidad = Val(txtProveedor.Tag)
                nDocumentoCaja.entidad = txtProveedor.Text
                nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
                nDocumentoCaja.nrodocEntidad = txtRuc.Text
                nDocumentoCaja.tipoOperacion = StatusTipoOperacion.PAGO_A_PROVEEDORES
                nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
                nDocumentoCaja.fechaActualizacion = DateTime.Now

                'DOCUMENTO CAJA
                objCaja = New documentoCaja
                objCaja.tipoOperacion = StatusTipoOperacion.PAGO_A_PROVEEDORES
                objCaja.idDocumento = 0
                objCaja.periodo = lblPerido.Text
                If txtProveedor.Text.Trim.Length > 0 Then
                    objCaja.codigoProveedor = txtProveedor.Tag
                End If
                objCaja.idEmpresa = Gempresas.IdEmpresaRuc
                objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
                objCaja.fechaProceso = txtFecha.Value
                objCaja.fechaCobro = txtFecha.Value
                objCaja.tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
                If txtProveedor.Text.Trim.Length > 0 Then
                    objCaja.IdProveedor = txtProveedor.Tag
                End If
                objCaja.TipoDocumentoPago = "14"
                objCaja.codigoLibro = "1"
                objCaja.tipoDocPago = "14"
                objCaja.NumeroDocumento = txtNumero.Text
                objCaja.numeroOperacion = i.GetValue("numOper")

                objCaja.montoSoles = CDec(i.GetValue("montoMN"))
                Select Case i.GetValue("moneda")
                    Case "NACIONAL"
                        objCaja.moneda = 1
                        objCaja.tipoCambio = TmpTipoCambio
                        objCaja.montoUsd = CDec(objCaja.montoSoles * TmpTipoCambio)
                    Case "EXTRANJERO"
                        objCaja.moneda = 2
                        objCaja.tipoCambio = i.GetValue("tipocambio")
                        objCaja.montoUsd = CDec(i.GetValue("montoME"))
                End Select


                objCaja.estado = "P"
                objCaja.glosa = "Por compra directa " & "nro. " & "-" & txtNumero.Text & " fecha: " & txtFecha.Value
                objCaja.entregado = "SI"

                objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
                objCaja.usuarioModificacion = usuario.IDUsuario
                objCaja.entidadFinanciera = CInt(i.GetValue("idEntidad"))
                objCaja.NombreEntidad = (i.GetValue("ef"))
                objCaja.fechaModificacion = DateTime.Now

                'vuelto ticket
                'vueltoMN = CDec(i.GetValue("vueltoMN"))
                'vueltoME = CDec(i.GetValue("vueltoME"))

                nDocumentoCaja.documentoCaja = objCaja
                ListaDoc.Add(nDocumentoCaja)
                ListaDetalleCaja(nDocumentoCaja.documentoCaja)
                asientoDocumento(nDocumentoCaja.documentoCaja)
            End If
        Next

        Return ListaDoc
    End Function

    Sub TotalTalesXcolumna()
        Dim totalpercepMN As Decimal = 0
        Dim totalpercepME As Decimal = 0

        Dim totalVC As Decimal = 0
        Dim totalVCme As Decimal = 0

        Dim totalIVA As Decimal = 0
        Dim totalIVAme As Decimal = 0

        Dim totalDesc As Decimal = 0
        Dim totalDescme As Decimal = 0

        Dim total As Decimal = 0
        Dim totalme As Decimal = 0

        Dim bs1 As Decimal = 0
        Dim bs1me As Decimal = 0
        Dim bs2 As Decimal = 0
        Dim bs2me As Decimal = 0
        Dim igv1 As Decimal = 0
        Dim igv1me As Decimal = 0
        Dim igv2 As Decimal = 0
        Dim igv2me As Decimal = 0

        For Each r As Record In dgvCompra.Table.Records
            totalpercepMN += CDec(r.GetValue("percepcionMN"))
            totalpercepME += CDec(r.GetValue("percepcionME"))

            'If r.GetValue("valBonif") = "S" Then
            '    totalDesc += CDec(r.GetValue("igvmn"))
            '    totalDescme += CDec(r.GetValue("igvme"))
            'Else
            totalVC += CDec(r.GetValue("vcmn"))
            totalVCme += CDec(r.GetValue("vcme"))

            'totalIVA += CDec(r.GetValue("igvmn"))
            'totalIVAme += CDec(r.GetValue("igvme"))

            total += CDec(r.GetValue("totalmn"))
            totalme += CDec(r.GetValue("totalme"))
            'End If

            Select Case r.GetValue("gravado")
                Case "1"
                    bs1 += CDec(r.GetValue("vcmn"))
                    bs1me += CDec(r.GetValue("vcme"))

                    'igv1 += CDec(r.GetValue("igvmn"))
                    'igv1me += CDec(r.GetValue("igvme"))
                Case "2"
                    bs2 += CDec(r.GetValue("vcmn"))
                    bs2me += CDec(r.GetValue("vcme"))

                    'igv2 += CDec(r.GetValue("igvmn"))
                    'igv2me += CDec(r.GetValue("igvme"))
            End Select




        Next

        TotalesXcanbeceras = New TotalesXcanbecera()

        TotalesXcanbeceras.PercepcionMN = totalpercepMN
        TotalesXcanbeceras.PercepcionME = totalpercepME

        TotalesXcanbeceras.BaseMN = totalVC
        TotalesXcanbeceras.BaseME = totalVCme

        TotalesXcanbeceras.IgvMN = totalIVA
        TotalesXcanbeceras.IgvME = totalIVAme

        TotalesXcanbeceras.TotalMN = total
        TotalesXcanbeceras.TotalME = totalme

        TotalesXcanbeceras.base1 = bs1
        TotalesXcanbeceras.base1me = bs1me
        TotalesXcanbeceras.base2 = bs2
        TotalesXcanbeceras.base2me = bs2me

        TotalesXcanbeceras.MontoIgv1 = igv1
        TotalesXcanbeceras.MontoIgv1me = igv1me
        TotalesXcanbeceras.MontoIgv2 = igv2
        TotalesXcanbeceras.MontoIgv2me = igv2me

        '****************************************************

        Select Case cboMoneda.SelectedValue
            Case 1
                txtTotalBase.DecimalValue = totalVC
                txtTotalIva.DecimalValue = totalIVA
                txtTotalPagar.DecimalValue = total
                txtRetencion.DecimalValue = TotalesXcanbeceras.PercepcionMN
                DigitalGauge2.Value = total
            Case 2
                txtTotalBase.DecimalValue = totalVCme
                txtTotalIva.DecimalValue = totalIVAme
                txtTotalPagar.DecimalValue = totalme
                txtRetencion.DecimalValue = TotalesXcanbeceras.PercepcionME
                DigitalGauge2.Value = totalme
        End Select



    End Sub

    Sub Calculos()
        Dim cantidad As Decimal = 0
        Dim VC As Decimal = 0
        Dim VCme As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Integer

        Dim valPercepMN As Decimal = 0
        Dim valPercepME As Decimal = 0


        colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

        'If colDestinoGravado = 1 Then
        valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
        valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
        'Else
        'valPercepMN = 0
        'valPercepME = 0

        'End If

        '****************************************************************

        cantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))

        Select Case cboMoneda.SelectedValue
            Case 1
                VC = Me.dgvCompra.Table.CurrentRecord.GetValue("vcmn")
                VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)
            Case 2

                VCme = Me.dgvCompra.Table.CurrentRecord.GetValue("vcme")
                VC = Math.Round(VCme * CDec(txtTipoCambio.DecimalValue), 2)
        End Select

        If cantidad > 0 Then
            Igv = 0 ' Math.Round(VC * (TmpIGV / 100), 2)
            IgvME = 0 ' Math.Round(VCme * (TmpIGV / 100), 2)

            colBI = VC + Igv - valPercepMN
            colBIme = VCme + IgvME - valPercepME

            colPrecUnit = Math.Round(VC / cantidad, 2)
            colPrecUnitme = Math.Round(VCme / cantidad, 2)
        ElseIf cantidad = 0 Then
            Igv = 0 ' Math.Round(VC * (TmpIGV / 100), 2)
            IgvME = 0 ' Math.Round(VCme * (TmpIGV / 100), 2)
            colBI = VC + Igv - valPercepMN
            colBIme = VCme + IgvME - valPercepME
            colPrecUnit = 0
            colPrecUnitme = 0
        Else
            colPrecUnit = 0
            colPrecUnitme = 0

            colBI = 0
            colBIme = 0
            Igv = 0
            IgvME = 0
        End If



        ' DATOS SOLES
        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", colBI.ToString("N2"))
        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", colBIme.ToString("N2"))
        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", valPercepMN)
        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", valPercepME)


        TotalTalesXcolumna()
    End Sub

    Public Sub CargarCMBGastos()
        Dim planContableSA As New cuentaplanContableEmpresaSA
        Try
            cboCuentas.DataSource = Nothing
            cboCuentas.DisplayMember = "descripcion"
            cboCuentas.ValueMember = "cuenta"
            cboCuentas.DataSource = planContableSA.LoadCuentasPagoHonorarios(Gempresas.IdEmpresaRuc)
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try

    End Sub

    Public Sub CargarListaGasto()
        Dim cuentaSA As New mascaraGastosEmpresaSA
        Try
            lsvServicios.Columns.Clear()
            lsvServicios.Items.Clear()
            lsvServicios.Columns.Add("Cuenta", 75)
            lsvServicios.Columns.Add("Descripcion", 318)
            '  lsvServicios.Columns.Add("Cuenta Padre", 0)
            For Each i As mascaraGastosEmpresa In cuentaSA.ObtenerMascaraGastos(Gempresas.IdEmpresaRuc, txtServicio.Text)
                Dim n As New ListViewItem(i.cuentaCompra)
                n.SubItems.Add(i.descripcionCompra)
                lsvServicios.Items.Add(n)
            Next
        Catch ex As Exception
            lblEstado.Text = ("Error al cargar datos. " & vbCrLf & ex.Message)
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
        End Try
    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean



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
    Sub ConfiguracionInicio()
        TotalesXcanbeceras = New TotalesXcanbecera()
        CargarCMBGastos()
        'configurando docking manager
        dockingManager1.DockControlInAutoHideMode(PanelServicios, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 356)
        Me.DockingClientPanel1.AutoScroll = True
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        dockingManager1.SetDockLabel(PanelServicios, "Servicios")

        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            dgvCompra.TableDescriptor.Columns("pumn").Width = 60
            dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
            dgvCompra.TableDescriptor.Columns("totalmn").Width = 70 '
            dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 70

            dgvCompra.TableDescriptor.Columns("pume").Width = 0
            dgvCompra.TableDescriptor.Columns("vcme").Width = 0
            dgvCompra.TableDescriptor.Columns("totalme").Width = 0
            dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
            cboMoneda.SelectedValue = 1
        End If

        'confgiurando variables generales
        txtGlosa.Text = "Por la compra según " & ""
        txtIva.DoubleValue = TmpIGV / 100
        '  lblPerido.Text = PeriodoGeneral

        ListaTipoCambio = New List(Of tipoCambio)
        LoadTipoCambio()

        txtFecha.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtFecha.Select()
    End Sub

    Private Sub LoadTipoCambio()
        Dim tipocambioSA As New tipoCambioSA

        ListaTipoCambio = tipocambioSA.GetListar_tipoCambioByPeriodo(Gempresas.IdEmpresaRuc, CInt(MesGeneral), CInt(AnioGeneral), GEstableciento.IdEstablecimiento)

    End Sub

    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("codigo", GetType(String))
        dt.Columns.Add("gravado", GetType(String))
        dt.Columns.Add("idProducto", GetType(Integer))
        dt.Columns.Add("item", GetType(String))
        dt.Columns.Add("cantidad", GetType(Decimal))
        dt.Columns.Add("vcmn", GetType(Decimal))
        dt.Columns.Add("pcmn", GetType(Decimal))
        dt.Columns.Add("totalmn", GetType(Decimal))
        dt.Columns.Add("vcme", GetType(Decimal))
        dt.Columns.Add("pcme", GetType(Decimal))
        dt.Columns.Add("totalme", GetType(Decimal))
        dt.Columns.Add("igvmn", GetType(Decimal))
        dt.Columns.Add("igvme", GetType(Decimal))
        dt.Columns.Add("pumn", GetType(Decimal))
        dt.Columns.Add("pume", GetType(Decimal))
        dt.Columns.Add("percepcionMN", GetType(Decimal))
        dt.Columns.Add("percepcionME", GetType(Decimal))
        dt.Columns.Add("Action", GetType(String))
        dt.Columns.Add("pagado", GetType(Decimal))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        If tmpConfigInicio.proyecto = "S" Then
            dt.Columns.Add("proyecto")
        End If
        dgvCompra.DataSource = dt
    End Sub

    Public Sub Loadcontroles()
        Dim entidadSA As New entidadSA
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(1, "NACIONAL")
        dt.Rows.Add(2, "EXTRANJERA")

        cboMoneda.ValueMember = "id"
        cboMoneda.DisplayMember = "name"
        cboMoneda.DataSource = dt
        cboMoneda.SelectedIndex = 0
    End Sub

    Public Sub UbicarEntidadPorRuc(strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                txtProveedor.Text = .nombreCompleto
                txtProveedor.Tag = .idEntidad
                '   txtCuenta.Text = .cuentaAsiento
                txtRuc.Text = .nrodoc
                txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End With
        Else
            If MessageBoxAdv.Show("Desea crear un nuevo proveedor?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Dim f As New frmCrearENtidades
                f.CaptionLabels(0).Text = "Nuevo proveedor"
                f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                f.tipoPersona(TIPO_ENTIDAD.PROVEEDOR, txtRuc.Text)
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                txtProveedor.Clear()
                txtRuc.Clear()
                entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strNro)
                If Not IsNothing(entidad) Then
                    With entidad
                        txtProveedor.Text = .nombreCompleto
                        txtProveedor.Tag = .idEntidad
                        '   txtCuenta.Text = .cuentaAsiento
                        txtRuc.Text = .nrodoc
                        txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    End With
                End If

            End If
        End If
    End Sub

#End Region

    Private Sub frmReciboHonorarios_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmReciboHonorarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por la compra según " & "Recibo de Honorarios" & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
                End If
                txtNumero.Select()

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As EventArgs) Handles txtSerie.LostFocus
        'Try
        '    If txtSerie.Text.Trim.Length > 0 Then
        '        '  If chFormato.Checked = True Then
        '        txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
        '        'End If
        '    End If

        'Catch ex As Exception

        '    If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerie.Text), 2, 1)) = True Then

        '        If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1)) = True Then

        '            If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1)) = True Then

        '                If Len(txtSerie.Text) <= 2 Then

        '                    txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1))

        '                ElseIf Len(txtSerie.Text) <= 3 Then

        '                    txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 2))

        '                ElseIf Len(txtSerie.Text) <= 4 Then

        '                    txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 3))

        '                ElseIf Len(txtSerie.Text) <= 5 Then

        '                    txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 4))

        '                End If
        '            End If
        '        Else

        '            txtSerie.Select()
        '            txtSerie.Focus()
        '            txtSerie.Clear()
        '            lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
        '            Timer1.Enabled = True
        '            PanelError.Visible = True
        '            TiempoEjecutar(10)

        '        End If

        '    Else

        '        txtSerie.Select()
        '        txtSerie.Focus()
        '        txtSerie.Clear()
        '        lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
        '        Timer1.Enabled = True
        '        PanelError.Visible = True
        '        TiempoEjecutar(10)
        '    End If

        'End Try

        If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
            txtGlosa.Text = "Por la compra según " & "Recibo de Honorarios" & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
        End If

    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por la compra según " & "Recibo de Honorarios" & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
                End If
                'cboMoneda.Select()
                txtProveedor.Select()
                Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.PROVEEDOR)
                f.CaptionLabels(0).Text = "Proveedor"
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                If Not IsNothing(f.Tag) Then
                    Dim c = DirectCast(f.Tag, entidad)
                    'Dim c = CType(f.Tag, entidad)
                    txtProveedor.Text = c.nombreCompleto
                    txtProveedor.Tag = c.idEntidad
                    txtRuc.Text = c.nrodoc
                    txtRuc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                End If
                'txtProveedor.Focus()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumero.Clear()
        End Try

    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As EventArgs) Handles txtNumero.LostFocus
        'Try
        '    If txtNumero.Text.Trim.Length > 0 Then
        '        '    If chFormato.Checked = True Then
        '        txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))

        '        'End If
        '    End If
        'Catch ex As Exception
        '    'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
        '    txtNumero.Select()
        '    txtNumero.Focus()
        '    txtNumero.Clear()
        '    lblEstado.Text = "Error de formato verifiuqe el ingreso!"
        'End Try

        If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
            txtGlosa.Text = "Por la compra según " & "Recibo de Honorarios" & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
        End If
    End Sub

    Private Sub cboRetencion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRetencion.SelectedIndexChanged
        If cboRetencion.Text = "SI" Then
            GroupBox2.Enabled = True
            dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0
            dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
        Else
            GroupBox2.Enabled = False
            dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 70
            dgvCompra.TableDescriptor.Columns("percepcionME").Width = 70
        End If
    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtRuc.Text.Trim.Length > 0 Then

                UbicarEntidadPorRuc(txtRuc.Text.Trim)
                'End If
                If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por la compra según " & "Recibo de Honorarios" & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboCuentas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCuentas.SelectedIndexChanged
        If String.IsNullOrEmpty(cboCuentas.ValueMember.ToString) Then
            Exit Sub
        Else
            If cboCuentas.Text = "" Then
                cboCuentas.Text = ""
                txtServicio.Text = ""
            Else
                txtServicio.Text = cboCuentas.SelectedValue
                CargarListaGasto()
            End If
        End If
    End Sub

    Private Sub tb19_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles tb19.ButtonStateChanged
        If Not IsNothing(TotalesXcanbeceras) Then
            If tb19.ToggleState = ToggleButton2.ToggleButtonState.ON Then
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseME
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvME
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalME
                txtRetencion.DecimalValue = TotalesXcanbeceras.PercepcionME

                dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 0
                dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0

                dgvCompra.TableDescriptor.Columns("pume").Width = 60
                dgvCompra.TableDescriptor.Columns("vcme").Width = 70
                dgvCompra.TableDescriptor.Columns("totalme").Width = 70
                dgvCompra.TableDescriptor.Columns("percepcionME").Width = 70
                cboMoneda.SelectedValue = 2

                txtTipoCambio.DecimalValue = 0.0

            ElseIf tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseMN
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvMN
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalMN
                txtRetencion.DecimalValue = TotalesXcanbeceras.PercepcionMN

                dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 70
                dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 70

                dgvCompra.TableDescriptor.Columns("pume").Width = 0
                dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                dgvCompra.TableDescriptor.Columns("totalme").Width = 0
                dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
                cboMoneda.SelectedValue = 1

                Dim consulta = (From n In ListaTipoCambio
                                Where n.fechaIgv.Year = txtFecha.Value.Year _
                           And n.fechaIgv.Month = txtFecha.Value.Month _
                           And n.fechaIgv.Day = txtFecha.Value.Day).FirstOrDefault

                If Not IsNothing(consulta) Then
                    txtTipoCambio.DecimalValue = consulta.venta
                Else
                    txtTipoCambio.DecimalValue = 0
                End If
            End If
        End If
    End Sub

    Private Sub dgvCompra_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCompra.QueryCellStyleInfo
        If e.TableCellIdentity.RowIndex <> -1 Then
            Dim rec As GridRecordRow = TryCast(Me.dgvCompra.Table.DisplayElements(e.TableCellIdentity.RowIndex), GridRecordRow)
            If rec IsNot Nothing Then
                ' Applies format by checking the value Row1
                Dim dr As DataRowView = TryCast(rec.GetData(), DataRowView)
                If dr IsNot Nothing AndAlso dr("Action").Equals("3") Then
                    e.Style.Enabled = False
                    e.Style.BackColor = Color.FromArgb(255, 192, 192)
                ElseIf dr IsNot Nothing AndAlso dr("Action").Equals("2") Then
                    e.Style.Enabled = True
                    e.Style.BackColor = Color.White
                End If
            End If
        End If
    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellChanged
        Dim cc As GridCurrentCell = Me.dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()
        If Not IsNothing(cc) Then
            Select Case cc.ColIndex
                Case 4
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    Dim can = CDec(r.GetValue("cantidad"))
                    If can < 0 Then
                        r.SetValue("cantidad", 0)
                        MessageBox.Show("La cantidad debe ser mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Calculos()
                        Exit Sub
                    End If

                Case 5, 9 'Valor de compra
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    Dim vc = CDec(r.GetValue("vcmn"))
                    If vc < 0 Then
                        r.SetValue("vcmn", 0)
                        r.SetValue("vcme", 0)
                        MessageBox.Show("El valor de compra debe ser mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Calculos()
                        Exit Sub
                    End If
                    Calculos()
                Case 7
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    Dim colperce = CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN"))
                    If colperce < 0 Then
                        r.SetValue("percepcionMN", 0)
                        r.SetValue("percepcionME", 0)
                        MessageBox.Show("El valor de la percepción debe ser mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Calculos()
                        Exit Sub
                    End If

                    Dim colPercepcionME As Decimal = 0
                    colPercepcionME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")) / TmpTipoCambio, 2)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", colPercepcionME)
                    Calculos()
            End Select
        End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCompra.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
        '    Select Case ColIndex
        '        Case 4
        '            Dim r As Record = dgvCompra.Table.CurrentRecord
        '            Dim can = CDec(r.GetValue("cantidad"))
        '            If can < 0 Then
        '                r.SetValue("cantidad", 0)
        '                MessageBox.Show("La cantidad debe ser mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                Calculos()
        '                Exit Sub
        '            End If

        '        Case 5, 9 'Valor de compra
        '            Dim r As Record = dgvCompra.Table.CurrentRecord
        '            Dim vc = CDec(r.GetValue("vcmn"))
        '            If vc < 0 Then
        '                r.SetValue("vcmn", 0)
        '                r.SetValue("vcme", 0)
        '                MessageBox.Show("El valor de compra debe ser mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                Calculos()
        '                Exit Sub
        '            End If
        '            Calculos()
        '        Case 7
        '            Dim r As Record = dgvCompra.Table.CurrentRecord
        '            Dim colperce = CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN"))
        '            If colperce < 0 Then
        '                r.SetValue("percepcionMN", 0)
        '                r.SetValue("percepcionME", 0)
        '                MessageBox.Show("El valor de la percepción debe ser mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                Calculos()
        '                Exit Sub
        '            End If

        '            Dim colPercepcionME As Decimal = 0
        '            colPercepcionME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")) / TmpTipoCambio, 2)
        '            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", colPercepcionME)
        '            Calculos()
        '    End Select
        'End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

            If Me.dgvCompra.Table.CurrentRecord.GetValue("Action") = "3" Then
                Me.dgvCompra.Table.CurrentRecord.SetValue("Action", "2")
            ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("Action") = "2" Then
                Me.dgvCompra.Table.CurrentRecord.SetValue("Action", "3")
            ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("Action") = "1" Then
                Me.dgvCompra.Table.CurrentRecord.Delete()
            End If

            TotalTalesXcolumna()
        End If
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not txtSerie.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un número de serie válido"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done serie"
            End If

            If Not txtProveedor.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un proveedor válido"

                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done proveedor"

            End If

            If Not txtNumero.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un número de comprobante válido"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done número comprobante"

            End If

            '***********************************************************************
            If dgvCompra.Table.Records.Count > 0 Then
                Me.lblEstado.Text = "Done!"
                If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then

                    Grabar()

                ElseIf ManipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                    'Dim Filas As Integer = dgvCompra.DisplayedRowCount(True)
                    'If Filas > 0 Then
                    '    UpdateCompra()

                    UpdateHonorarios()
                    'Else

                    '    Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                    '    Timer1.Enabled = True
                    '    PanelError.Visible = True
                    '    TiempoEjecutar(10)

                    'End If


                End If
            Else

                Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)

            ListaAsientonTransito = New List(Of asiento)

        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtTipoCambio_TextChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.TextChanged
        If IsNumeric(txtTipoCambio.Text) Then
            If txtTipoCambio.Text > 0 Then

                TipoCambio()
            End If


        End If
    End Sub

    Private Sub txtFecha_ValueChanged(sender As Object, e As EventArgs) Handles txtFecha.ValueChanged
        If IsDate(txtFecha.Value) Then
            If txtFecha.Value.Date > DiaLaboral.Date Then
                txtFecha.Value = DiaLaboral
                MessageBox.Show("Debe respetar la fecha laboral o fechas inferiores a esta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            If cboMoneda.SelectedValue = 2 Then
                txtTipoCambio.DecimalValue = 0
            Else
                Dim consulta = (From n In ListaTipoCambio
                                Where n.fechaIgv.Year = txtFecha.Value.Year _
                           And n.fechaIgv.Month = txtFecha.Value.Month _
                           And n.fechaIgv.Day = txtFecha.Value.Day).FirstOrDefault

                If Not IsNothing(consulta) Then
                    txtTipoCambio.DecimalValue = consulta.venta
                Else
                    txtTipoCambio.DecimalValue = 0
                End If
            End If
        End If
    End Sub

    Private Sub Panel6_Click(sender As Object, e As EventArgs) Handles Panel6.Click
        With frmTipoCambio
            .txtFechaIgv.Value = DateTime.Now.Date
            .StartPosition = FormStartPosition.CenterParent
            .nudTipoCambioCompra.Value = 0
            .nudTipoCambio.Value = 0
            .ShowDialog()
            LoadTipoCambio()
        End With
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo proveedor"
        f.strTipo = TIPO_ENTIDAD.PROVEEDOR
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        Try


            If txtProveedor.Text.Length > 0 Then
                If txtProveedor.ForeColor = Color.Black Then
                    MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtProveedor.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
            End If

            If txtRuc.Text.Length > 0 Then
                If txtRuc.ForeColor = Color.Black Then
                    MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtRuc.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
            End If

            If Not txtNumero.Text.Length > 0 Then
                MessageBox.Show("Verificar el ingreso del número", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtRuc.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If Not txtSerie.Text.Length > 0 Then
                MessageBox.Show("Verificar el ingreso de la serie", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtRuc.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            With frmCajasXusuarioCompras
                .DigitalGauge2.Value = DigitalGauge2.Value
                .txtFecha.Value = txtFecha.Value
                .txtTipoDoc.Text = TextBoxExt2.Text
                .txtSerie.Text = txtSerie.Text
                .txtNumero.Text = txtSerie.Text
                .txtCliente.Text = txtProveedor.Text
                .txtCliente.Tag = txtProveedor.Tag
                .txtRuc.Text = txtRuc.Text
                .tipoVenta = TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With

        Catch ex As Exception
            lblEstado.Text = ex.Message
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)

        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GradientPanel4_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel4.Paint

    End Sub

    Private Sub frmReciboHonorariosContado_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.F7 Then


                If txtProveedor.Text.Length > 0 Then
                    If txtProveedor.ForeColor = Color.Black Then
                        MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtProveedor.Select()
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                End If

                If txtRuc.Text.Length > 0 Then
                    If txtRuc.ForeColor = Color.Black Then
                        MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtRuc.Select()
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                End If

                If Not txtSerie.Text.Length > 0 Then
                    MessageBox.Show("Verificar el ingreso de la serie", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtRuc.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                If Not txtNumero.Text.Length > 0 Then
                    MessageBox.Show("Verificar el ingreso del numero", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtRuc.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                With frmCajasXusuarioCompras
                    .DigitalGauge2.Value = DigitalGauge2.Value
                    .txtFecha.Value = txtFecha.Value
                    .txtTipoDoc.Text = TextBoxExt2.Text
                    .txtSerie.Text = txtSerie.Text
                    .txtNumero.Text = txtSerie.Text
                    .txtCliente.Text = txtProveedor.Text
                    .txtCliente.Tag = txtProveedor.Tag
                    .txtRuc.Text = txtRuc.Text
                    .tipoVenta = TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            ElseIf e.KeyCode = Keys.F6 Then
            End If

        Catch ex As Exception
            lblEstado.Text = ex.Message
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)

        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        If (txtServicio.Text.Length > 0) Then
            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", 2)
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", lsvServicios.SelectedItems(0).SubItems(0).Text)
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", lsvServicios.SelectedItems(0).SubItems(1).Text)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
            Me.dgvCompra.Table.CurrentRecord.SetValue("Action", 1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("descripcion", txtServicio.Text)
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
            txtServicio.Clear()
        Else
            MessageBox.Show("Debe ingresar una descripción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtServicio.Clear()
        End If
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.PROVEEDOR)
        f.CaptionLabels(0).Text = "Proveedor"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = DirectCast(f.Tag, entidad)
            'Dim c = CType(f.Tag, entidad)
            txtProveedor.Text = c.nombreCompleto
            txtProveedor.Tag = c.idEntidad
            txtRuc.Text = c.nrodoc
            txtRuc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub txtNumero_TextChanged(sender As Object, e As EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs) Handles txtSerie.TextChanged

    End Sub
End Class