Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class frmAnticipoXVenta

    Dim ListaAsientonTransito As New List(Of asiento)
    Dim tipoVenta As String
    Public Property TotalesXcanbeceras As TotalesXcanbecera
    Public Property idAlmacenVirtual() As Integer
    Public Property ManipulacionEstado() As String
    Public Property ListaTipoCambio As New List(Of tipoCambio)
    Dim saldoMN As Decimal
    Dim gridCaja As New GridGroupingControl


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

        Me.KeyPreview = True

        ' Add any initialization after the InitializeComponent() call.
        Loadcontroles()
        GetTableGrid()
        ConfiguracionInicio()
        AddRowDefault()

        'GridCFG(dgvPagos)
        saldoMN = DigitalGauge2.Value
        'If (Not IsNothing(usuario.IDUsuario)) Then
        '    dgvPagos.DataSource = UbicarCajasHijas()
        '    'cargarDatosCuentas()
        '    'CargarCajasTipo(usuario.IDUsuario)
        '    'CMBCajasDelUsuarioPV()
        '    'dgvPagos.ShowColumnHeaders = True
        '    'Panel6.Size = New Size(1164, 223)
        'End If
        ToolStripLabel10.Text = Gempresas.NomEmpresa
        ToolStripLabel12.Text = GEstableciento.NombreEstablecimiento
    End Sub


    Public Sub New(intIdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Loadcontroles()
        GetTableGrid()
        ConfiguracionInicio()
        UbicarDocumento(intIdDocumento)

    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean



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

    Public Sub llenarGrid(grid As GridGroupingControl, tag As Integer)
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

                If Not txtCliente.Text.Trim.Length > 0 Then
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

                If txtFecVcto.IsNullDate Then
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
                        Grabar()
                    ElseIf ManipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                        'Dim Filas As Integer = dgvCompra.DisplayedRowCount(True)
                        'If Filas > 0 Then
                        '    UpdateCompra()

                        '     UpdateServicioPublico()
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


    'Sub AddRowDefault()

    '    Me.dgvCompra.Table.AddNewRecord.SetCurrent()
    '    Me.dgvCompra.Table.AddNewRecord.BeginEdit()
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", 1)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", "122")
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("item", "ANTICIPOS DE CLIENTES")
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 1)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("ivamn", 0)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("ivame", 0)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("Action", "1")
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")
    '    Me.dgvCompra.Table.AddNewRecord.EndEdit()

    'End Sub

    'Sub AddRowDefault432()

    '    Me.dgvCompra.Table.AddNewRecord.SetCurrent()
    '    Me.dgvCompra.Table.AddNewRecord.BeginEdit()
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", 1)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", "132")
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("item", "ANTICIPOS RECIBIDOS")
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 1)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("ivamn", 0)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("ivame", 0)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("Action", "1")
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")
    '    Me.dgvCompra.Table.AddNewRecord.EndEdit()

    'End Sub

    Sub AddRowDefault()
        Dim contador As Integer = 0
        For Each r As Record In dgvCompra.Table.Records
            If (r.GetValue("estado") = 1) Then
                contador += 1
            End If
        Next

        If (contador = 0) Then
            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", 1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", "122")
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", "ANTICIPOS DE CLIENTES")
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("ivamn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("ivame", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
            Me.dgvCompra.Table.CurrentRecord.SetValue("Action", "1")
            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")
            Me.dgvCompra.Table.CurrentRecord.SetValue("estado", 0)
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
            tipoVenta = TIPO_VENTA.VENTA_ANTICIPADA_OTORGADO
        Else
            lblEstado.Text = "No puede ingresar otro tipo de Anticipo"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
        End If



    End Sub

    Sub AddRowDefault432()
        Dim contador2 As Integer = 0
        For Each r As Record In dgvCompra.Table.Records
            If (r.GetValue("estado") = 0) Then
                contador2 += 1
            End If
        Next

        If (contador2 = 0) Then
            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", 1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", "132")
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", "ANTICIPOS RECIBIDOS")
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("ivamn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("ivame", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
            Me.dgvCompra.Table.CurrentRecord.SetValue("Action", "1")
            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")
            Me.dgvCompra.Table.CurrentRecord.SetValue("estado", 1)
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
            tipoVenta = TIPO_VENTA.VENTA_ANTICIPADA_RECIBIDO
        Else
            lblEstado.Text = "No puede ingresar otro tipo de Anticipo"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
        End If
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

            If colDestinoGravado = 1 Then
                valPercepMN = r.GetValue("percepcionMN")
                valPercepME = r.GetValue("percepcionME")
            Else
                valPercepMN = 0
                valPercepME = 0

            End If

            '****************************************************************

            cantidad = r.GetValue("cantidad")
            r.SetValue("cantidad", cantidad.ToString("N2"))
            Select Case cboMoneda.SelectedValue
                Case 1 'MONEDA NACIONAL
                    VC = r.GetValue("vcmn")
                    VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)

                Case 2 'MONEDA EXTRANJERA
                    VCme = r.GetValue("vcme") ' 
                    VC = Math.Round(VCme * CDec(txtTipoCambio.DecimalValue), 2)

            End Select

            If cantidad > 0 Then
                Igv = Math.Round(VC * (TmpIGV / 100), 2)
                IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

                colBI = VC + Igv + valPercepMN
                colBIme = VCme + IgvME + valPercepME

                colPrecUnit = Math.Round(VC / cantidad, 2)
                colPrecUnitme = Math.Round(VCme / cantidad, 2)
            ElseIf cantidad = 0 Then
                Igv = Math.Round(VC * (TmpIGV / 100), 2)
                IgvME = Math.Round(VCme * (TmpIGV / 100), 2)
                colBI = VC + Igv + valPercepMN
                colBIme = VCme + IgvME + valPercepME
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


            Select Case colDestinoGravado
                Case "2", "3", "4"
                    r.SetValue("vcmn", VC.ToString("N2"))
                    r.SetValue("vcme", VCme.ToString("N2"))
                    r.SetValue("pumn", colPrecUnit.ToString("N2"))
                    r.SetValue("pume", colPrecUnitme.ToString("N2"))
                    r.SetValue("totalmn", VC.ToString("N2"))
                    r.SetValue("totalme", VCme.ToString("N2"))
                    r.SetValue("ivamn", 0)
                    r.SetValue("ivame", 0)
                    r.SetValue("percepcionMN", 0)
                    r.SetValue("percepcionME", 0)

                Case Else
                    If cantidad > 0 Then
                        r.SetValue("vcmn", VC.ToString("N2"))
                        r.SetValue("vcme", VCme.ToString("N2"))
                        r.SetValue("pumn", colPrecUnit.ToString("N2"))
                        r.SetValue("pume", colPrecUnitme.ToString("N2"))
                        r.SetValue("totalmn", colBI.ToString("N2"))
                        r.SetValue("totalme", colBIme.ToString("N2"))
                        r.SetValue("ivamn", Igv.ToString("N2"))
                        r.SetValue("ivame", IgvME.ToString("N2"))
                        r.SetValue("percepcionMN", valPercepMN)
                        r.SetValue("percepcionME", valPercepME)
                    End If

                    'End If
            End Select
        Next
        TotalTalesXcolumna()

    End Sub


    Public Sub CargarCajasTipo(strBusqueda As String)
        Dim estadoSA As New EstadosFinancierosSA
        Dim taBLASA As New tablaDetalleSA
        Dim ListaestadoBL As New List(Of estadosFinancieros)
        Dim estadoBL As New estadosFinancieros

        Try

        Catch ex As Exception

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
                txtFecha.Value = .fechaDoc
                lblIdDocumento.Text = .idDocumento
                PeriodoGeneral = .fechaContable
                txtSerie.Text = .serie
                txtNumero.Text = .numeroDoc
                cboMoneda.SelectedValue = .monedaDoc
                cboTipoDoc.SelectedValue = .tipoDoc


                Select Case cboMoneda.SelectedValue
                    Case 1

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("ivamn").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

                        dgvCompra.TableDescriptor.Columns("pume").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                        dgvCompra.TableDescriptor.Columns("ivame").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 0

                        cboMoneda.SelectedValue = 1
                        tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                    Case 2

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                        dgvCompra.TableDescriptor.Columns("ivamn").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 0

                        dgvCompra.TableDescriptor.Columns("pume").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 65
                        dgvCompra.TableDescriptor.Columns("ivame").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 70
                        tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                        cboMoneda.SelectedValue = 2
                End Select

                nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                txtRuc.Text = nEntidad.nrodoc
                txtCliente.Tag = nEntidad.idEntidad
                txtCliente.Text = nEntidad.nombreCompleto

                txtTipoCambio.DecimalValue = .tcDolLoc
                txtIva.DoubleValue = .tasaIgv
                txtGlosa.Text = .glosa

                'Select Case .destino
                '    Case "SI"
                '        cboRetencion.Text = "SI"
                '        GroupBox2.Enabled = True
                '        dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0
                '        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
                '    Case "NO"
                '        cboRetencion.Text = "NO"
                '        GroupBox2.Enabled = False
                '        dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 70
                '        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 70
                'End Select

            End With

            'DETALLE DE LA COMPRA
            dgvCompra.Table.Records.DeleteAll()
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

                Me.dgvCompra.Table.CurrentRecord.SetValue("ivamn", i.montoIgv)
                Me.dgvCompra.Table.CurrentRecord.SetValue("ivame", i.montoIgvUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("Action", "2")

                Select Case i.estadoPago
                    Case TIPO_COMPRA.PAGO.PAGADO
                        Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", True)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "Pagado")
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")
                End Select

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
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtCliente.Tag
        nAsiento.nombreEntidad = txtCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Anticipada
        nAsiento.importeMN = TotalesXcanbeceras.TotalMN
        nAsiento.importeME = TotalesXcanbeceras.TotalME
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
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

    Public Function AS_Proveedor(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "1213",
              .descripcion = txtCliente.Text,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    'Public Sub AsientoCompra()
    '    Dim asientoTransitod As New asiento
    '    Dim mascaraSA As New mascaraContable2SA
    '    Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
    '    Dim nMovimiento As New movimiento

    '    asientoTransitod = AsientoCabeceraCompra(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME) ' CABECERA ASIENTO

    '    '---------------------------------------------------------------------------------------------
    '    'DETALLE DEL ASIENTO DE COMPRA
    '    'MOVIMIENTOS
    '    For Each r As Record In dgvCompra.Table.Records

    '        '   If dgvCompra.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
    '        nMovimiento = New movimiento
    '        nMovimiento.cuenta = "1213" ' r.GetValue("idProducto")
    '        nMovimiento.descripcion = r.GetValue("item")
    '        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
    '        'nMovimiento.monto = CDec(r.GetValue("totalmn"))
    '        'nMovimiento.montoUSD = CDec(r.GetValue("totalme"))
    '        nMovimiento.monto = CDec(r.GetValue("vcmn"))
    '        nMovimiento.montoUSD = CDec(r.GetValue("vcme"))
    '        nMovimiento.fechaActualizacion = DateTime.Now
    '        nMovimiento.usuarioActualizacion = usuario.IDUsuario
    '        asientoTransitod.movimiento.Add(nMovimiento)

    '        'If CDec(r.GetValue("percepcionMN")) > 0 Then
    '        '    asientoTransitod.movimiento.Add(AS_IGV(CDec(r.GetValue("percepcionMN")), CDec(r.GetValue("percepcionME"))))
    '        'End If


    '    Next
    '    If TotalesXcanbeceras.IgvMN > 0 Then
    '        asientoTransitod.movimiento.Add(AS_IGV(TotalesXcanbeceras.IgvMN, TotalesXcanbeceras.IgvME))
    '    End If
    '    asientoTransitod.movimiento.Add(AS_Proveedor(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))

    '    ListaAsientonTransito.Add(asientoTransitod)
    'End Sub

    Sub AsientoVenta(listadoExistencias As List(Of documentoventaAbarrotesDet))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In listadoExistencias
                         Into totalMN = Sum(n.importeMN),
                         TotalME = Sum(n.importeME)

        nAsiento = New asiento
        nAsiento.idAsiento = 0
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = 0
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing
        nAsiento.idEntidad = CInt(txtCliente.Tag) ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Anticipada
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.TotalME.GetValueOrDefault
        nAsiento.fechaActualizacion = DateTime.Now
        nAsiento.usuarioActualizacion = usuario.IDUsuario

        ListaAsientonTransito.Add(nAsiento)

        'nAsiento.movimiento.Add(AS_Cliente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.TotalME.GetValueOrDefault))

        Dim SumaIGV = Aggregate n In listadoExistencias
                       Into totalIGVMN = Sum(n.montoIgv),
                       totalIGVME = Sum(n.montoIgvUS)

        If SumaIGV.totalIGVMN.GetValueOrDefault > 0 Then
            nAsiento.movimiento.Add(AS_IGV(SumaIGV.totalIGVMN.GetValueOrDefault, SumaIGV.totalIGVME.GetValueOrDefault))
        End If
        'nAsiento.movimiento.Add(AS_CAJA(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))

        'For Each i As Record In gridCaja.Table.Records
        '    '   If dgvCompra.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
        '    nMovimiento = New movimiento
        '    nMovimiento.cuenta = i.GetValue("cuenta")
        '    nMovimiento.descripcion = i.GetValue("ef")
        '    nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        '    'nMovimiento.monto = CDec(r.GetValue("totalmn"))
        '    'nMovimiento.montoUSD = CDec(r.GetValue("totalme"))
        '    nMovimiento.monto = CDec(i.GetValue("montoMN"))
        '    nMovimiento.montoUSD = CDec(i.GetValue("montoMN") * TmpTipoCambio)
        '    nMovimiento.fechaActualizacion = DateTime.Now
        '    nMovimiento.usuarioActualizacion = usuario.IDUsuario
        '    nAsiento.movimiento.Add(nMovimiento)

        '    'If CDec(r.GetValue("percepcionMN")) > 0 Then
        '    '    asientoTransitod.movimiento.Add(AS_IGV(CDec(r.GetValue("percepcionMN")), CDec(r.GetValue("percepcionME"))))
        '    'End If

        'Nextgr


        For Each r As Record In dgvCompra.Table.Records

            '   If dgvCompra.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
            nMovimiento = New movimiento
            nMovimiento.cuenta = r.GetValue("idProducto")
            nMovimiento.descripcion = r.GetValue("item")
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            'nMovimiento.monto = CDec(r.GetValue("totalmn"))
            'nMovimiento.montoUSD = CDec(r.GetValue("totalme"))
            nMovimiento.monto = CDec(r.GetValue("vcmn"))
            nMovimiento.montoUSD = CDec(r.GetValue("vcme"))
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)

            'If CDec(r.GetValue("percepcionMN")) > 0 Then
            '    asientoTransitod.movimiento.Add(AS_IGV(CDec(r.GetValue("percepcionMN")), CDec(r.GetValue("percepcionME"))))
            'End If

        Next


        nAsiento.movimiento.Add(AS_Proveedor(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))

        'nMovimiento = New movimiento
        'nMovimiento.cuenta = txtCuentaO.Text
        ''nMovimiento.descripcion = txtCajaOrigen.Text
        'nMovimiento.descripcion = cboDepositoHijo.Text
        'nMovimiento.tipo = "D"
        'nMovimiento.monto = CDec(txtFondoMN.Value)
        'nMovimiento.montoUSD = CDec(txtFondoME.Value)
        'nMovimiento.usuarioActualizacion = usuario.IDUsuario
        'nMovimiento.fechaActualizacion = DateTime.Now
        'asientoBL.movimiento.Add(nMovimiento)


    End Sub

    Public Function AS_Cliente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "1213",
              .descripcion = txtCliente.Text,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function


    'Sub UpdateServicioPublico()
    '    Dim CompraSA As New DocumentoCompraSA
    '    Dim ndocumento As New documento()

    '    Dim nDocumentoCompra As New documentocompra()
    '    Dim objDocumentoCompraDet As New documentocompradetalle
    '    Dim entidadSA As New entidadSA
    '    Dim entidad As New entidad

    '    Dim asientoSA As New AsientoSA
    '    Dim nAsiento As New asiento
    '    Dim nMovimiento As New movimiento

    '    Dim ListaDetalle As New List(Of documentocompradetalle)

    '    ListaAsientonTransito = New List(Of asiento)

    '    dgvCompra.TableControl.CurrentCell.EndEdit()
    '    dgvCompra.TableControl.Table.TableDirty = True
    '    dgvCompra.TableControl.Table.EndEdit()

    '    With ndocumento
    '        .idDocumento = lblIdDocumento.Text
    '        .Action = Business.Entity.BaseBE.EntityAction.INSERT
    '        .idEmpresa = Gempresas.IdEmpresaRuc
    '        .idCentroCosto = GEstableciento.IdEstablecimiento
    '        If IsNothing(GProyectos) Then
    '        Else
    '            .idProyecto = GProyectos.IdProyectoActividad
    '        End If
    '        .tipoDoc = cboTipoDoc.SelectedValue
    '        .fechaProceso = txtFecha.Value
    '        .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
    '        .idOrden = Nothing ' Me.IdOrden
    '        .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
    '        .idEntidad = Val(txtCliente.Tag)
    '        .entidad = txtCliente.Text
    '        .tipoEntidad = TIPO_ENTIDAD.CLIENTE
    '        .nrodocEntidad = txtRuc.Text
    '        .tipoOperacion = StatusTipoOperacion.ANTICIPOS_RECIBIDOS
    '        .usuarioActualizacion = usuario.IDUsuario
    '        .fechaActualizacion = DateTime.Now
    '    End With

    '    With nDocumentoCompra
    '        .tipoOperacion = StatusTipoOperacion.ANTICIPOS_RECIBIDOS
    '        '.TipoConfiguracion = GConfiguracion.TipoConfiguracion
    '        '.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
    '        .idDocumento = lblIdDocumento.Text
    '        .idPadre = Nothing
    '        .codigoLibro = "14"
    '        .tipoDoc = cboTipoDoc.SelectedValue
    '        .idEmpresa = Gempresas.IdEmpresaRuc
    '        .idCentroCosto = GEstableciento.IdEstablecimiento
    '        .fechaDoc = txtFecha.Value
    '        .fechaContable = PeriodoGeneral
    '        .serie = txtSerie.Text.Trim
    '        .numeroDoc = txtNumero.Text
    '        .idProveedor = CInt(txtCliente.Tag)
    '        .nombreProveedor = txtCliente.Text
    '        .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")
    '        .tasaIgv = txtIva.DoubleValue
    '        .tcDolLoc = txtTipoCambio.DecimalValue
    '        .tipoRecaudo = Nothing
    '        .regimen = Nothing
    '        .tasaRegimen = 0
    '        .nroRegimen = Nothing
    '        '****************** DESTINO EN SOLES ************************************************************************
    '        .bi01 = TotalesXcanbeceras.base1
    '        .bi02 = TotalesXcanbeceras.base2

    '        .igv01 = TotalesXcanbeceras.MontoIgv1
    '        .igv02 = TotalesXcanbeceras.MontoIgv2


    '        '****************** DESTINO EN DOLARES ************************************************************************
    '        .bi01us = TotalesXcanbeceras.base1me
    '        .bi02us = TotalesXcanbeceras.base2me

    '        .igv01us = TotalesXcanbeceras.MontoIgv1me
    '        .igv02us = TotalesXcanbeceras.MontoIgv2me

    '        '****************************************************************************************************************
    '        .importeTotal = TotalesXcanbeceras.TotalMN
    '        .importeUS = TotalesXcanbeceras.TotalME
    '        .estadoPago = "DC" ' TIPO_COMPRA.PAGO.PAGADO
    '        .glosa = txtGlosa.Text.Trim
    '        .referenciaDestino = Nothing
    '        .tipoCompra = tipoVenta  'TIPO_COMPRA.COMPRA_ANTICIPADA
    '        'If cboRetencion.Text = "SI" Then
    '        '    .destino = TIPO_SITUACION.SUSPENSION_RETENCION.TIENE
    '        'Else
    '        .destino = TIPO_SITUACION.SUSPENSION_RETENCION.NO_TIENE
    '        'End If
    '        .situacion = statusComprobantes.Normal
    '        .usuarioActualizacion = usuario.IDUsuario
    '        .fechaActualizacion = DateTime.Now
    '    End With
    '    ndocumento.documentocompra = nDocumentoCompra


    '    'ASIENTOS CONTABLES
    '    For Each r As Record In dgvCompra.Table.Records

    '        objDocumentoCompraDet = New documentocompradetalle
    '        objDocumentoCompraDet.estadoPago = "DC" 'TIPO_COMPRA.PAGO.PAGADO  'Nothing
    '        objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
    '        objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
    '        objDocumentoCompraDet.tipoCompra = tipoVenta ' TIPO_COMPRA.COMPRA_ANTICIPADA
    '        objDocumentoCompraDet.FechaDoc = txtFecha.Value
    '        objDocumentoCompraDet.CuentaProvedor = "4212" ' txtCuenta.Text.Trim
    '        objDocumentoCompraDet.NombreProveedor = txtCliente.Text.Trim
    '        objDocumentoCompraDet.Serie = txtSerie.Text.Trim
    '        objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
    '        objDocumentoCompraDet.TipoDoc = cboTipoDoc.SelectedValue
    '        objDocumentoCompraDet.destino = r.GetValue("gravado")
    '        objDocumentoCompraDet.CuentaItem = Nothing
    '        objDocumentoCompraDet.idItem = r.GetValue("idProducto")
    '        objDocumentoCompraDet.tipoExistencia = TipoRecurso.SERVICIO
    '        objDocumentoCompraDet.descripcionItem = r.GetValue("item")

    '        If r.GetValue("Action") = 2 Then
    '            objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.UPDATE
    '        ElseIf r.GetValue("Action") = 1 Then
    '            objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
    '        ElseIf r.GetValue("Action") = 3 Then
    '            objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.DELETE
    '        End If

    '        If IsNumeric(r.GetValue("cantidad")) Then
    '            If CDec(r.GetValue("cantidad")) > 0 Then
    '                objDocumentoCompraDet.monto1 = CDec(r.GetValue("cantidad")) ' cantidad
    '            Else
    '                If MessageBoxAdv.Show("Desea ingresar el item con cantidad cero?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
    '                    objDocumentoCompraDet.monto1 = 0
    '                Else
    '                    lblEstado.Text = "Ingrese una cantidad mayor a cero del item, " & r.GetValue("item")
    '                    Timer1.Enabled = True
    '                    PanelError.Visible = True
    '                    TiempoEjecutar(10)
    '                    Exit Sub
    '                End If
    '            End If
    '        Else
    '            lblEstado.Text = "Ingrese una cantidad válida del item, " & r.GetValue("item")
    '            Timer1.Enabled = True
    '            PanelError.Visible = True
    '            TiempoEjecutar(10)
    '            Exit Sub
    '        End If
    '        objDocumentoCompraDet.unidad1 = Nothing
    '        objDocumentoCompraDet.unidad2 = Nothing
    '        objDocumentoCompraDet.monto2 = Nothing
    '        objDocumentoCompraDet.almacenRef = Nothing
    '        objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("pumn"))
    '        objDocumentoCompraDet.precioUnitarioUS = CDec(r.GetValue("pume"))
    '        If IsNumeric(r.GetValue("totalmn")) Then
    '            If CDec(r.GetValue("totalmn")) > 0 Then
    '                objDocumentoCompraDet.importe = CDec(r.GetValue("totalmn"))
    '            Else
    '                lblEstado.Text = "Ingrese un importe mayor a cero del item, " & r.GetValue("item")
    '                Timer1.Enabled = True
    '                PanelError.Visible = True
    '                TiempoEjecutar(10)
    '                Exit Sub
    '            End If
    '        Else
    '            lblEstado.Text = "Ingrese un importe válido del item, " & r.GetValue("item")
    '            Timer1.Enabled = True
    '            PanelError.Visible = True
    '            TiempoEjecutar(10)
    '            Exit Sub
    '        End If


    '        objDocumentoCompraDet.importeUS = CDec(r.GetValue("totalme"))
    '        objDocumentoCompraDet.montokardex = CDec(r.GetValue("vcmn"))
    '        objDocumentoCompraDet.montoIsc = 0 ' CDec(i.Cells(13).Value())
    '        objDocumentoCompraDet.montoIgv = CDec(r.GetValue("ivamn"))
    '        objDocumentoCompraDet.otrosTributos = 0 ' CDec(i.Cells(15).Value())
    '        '**********************************************************************************
    '        objDocumentoCompraDet.montokardexUS = CDec(r.GetValue("vcme"))
    '        objDocumentoCompraDet.montoIscUS = 0
    '        objDocumentoCompraDet.montoIgvUS = CDec(r.GetValue("ivame"))
    '        objDocumentoCompraDet.otrosTributosUS = 0
    '        objDocumentoCompraDet.preEvento = Nothing  '= "00", Nothing, dgvCompra.Rows(S).Cells(23).Value())
    '        objDocumentoCompraDet.bonificacion = r.GetValue("valBonif")

    '        objDocumentoCompraDet.percepcionMN = CDec(r.GetValue("percepcionMN"))
    '        objDocumentoCompraDet.percepcionME = CDec(r.GetValue("percepcionME"))
    '        '**********************************************************************************
    '        objDocumentoCompraDet.fechaModificacion = DateTime.Now
    '        objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvCompra.Rows(S).Cells(28).Value()), Nothing, CDate(dgvCompra.Rows(S).Cells(28).Value()))
    '        objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
    '        objDocumentoCompraDet.secuencia = CDec(r.GetValue("codigo"))
    '        objDocumentoCompraDet.idDocumento = lblIdDocumento.Text
    '        ListaDetalle.Add(objDocumentoCompraDet)
    '    Next

    '    'Dim listaExistencias As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle).ToList

    '    'If CDec(txtTotalPagar.DecimalValue) > 0 Then
    '    '    AsientoVenta()
    '    'End If

    '    ndocumento.asiento = ListaAsientonTransito
    '    ndocumento.documentocompra.documentocompradetalle = ListaDetalle
    '    CompraSA.UpdateReciboHonorario(ndocumento)
    '    lblEstado.Text = "compra registrada!"

    '    Dispose()
    'End Sub


    Sub Grabar()
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)

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
            .tipoDoc = cboTipoDoc.SelectedValue
            .fechaProceso = txtFecha.Value
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .idEntidad = Val(txtCliente.Tag)
            .entidad = txtCliente.Text
            .tipoEntidad = TIPO_ENTIDAD.CLIENTE
            .nrodocEntidad = txtRuc.Text
            .tipoOperacion = StatusTipoOperacion.ANTICIPOS_RECIBIDOS
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoVenta
            '.TipoConfiguracion = GConfiguracion.TipoConfiguracion
            '.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .tipoOperacion = StatusTipoOperacion.ANTICIPOS_RECIBIDOS
            .codigoLibro = "14"
            .tipoDocumento = cboTipoDoc.SelectedValue
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .fechaVcto = txtFecVcto.Value
            .fechaPeriodo = PeriodoGeneral
            .nombrePedido = txtCliente.Text
            .serie = txtSerie.Text.Trim
            .serieVenta = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text
            .numeroVenta = CInt(txtNumero.Text)
            .idCliente = CInt(txtCliente.Tag)
            .usuarioActualizacion = txtCliente.Text
            .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIva.DoubleValue
            .tipoCambio = txtTipoCambio.DecimalValue
            '.tipo = Nothing
            '.regimen = Nothing
            '.tasaRegimen = 0
            '.nroRegimen = Nothing
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
            .ImporteNacional = TotalesXcanbeceras.TotalMN
            .ImporteExtranjero = TotalesXcanbeceras.TotalME
            .estadoCobro = "DC" 'TIPO_COMPRA.PAGO.PAGADO
            .glosa = txtGlosa.Text.Trim
            .tipoVenta = tipoVenta  'TIPO_VENTA.VENTA_ANTICIPADA
            '.tipo = TIPO_VENTA.VENTA_ANTICIPADA
            'If cboRetencion.Text = "SI" Then
            '    .destino = TIPO_SITUACION.SUSPENSION_RETENCION.TIENE
            'Else
            .EstadoPagoDevolucion = TIPO_SITUACION.SUSPENSION_RETENCION.NO_TIENE
            'End If
            '.situacion = "ALTF"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentoventaAbarrotes = nDocumentoVenta


        'If CDec(txtTotalPagar.DecimalValue) > 0 Then
        '    AsientoVenta()
        'End If
        'ASIENTOS CONTABLES
        For Each r As Record In dgvCompra.Table.Records

            objDocumentoVentaDet = New documentoventaAbarrotesDet
            'objDocumentoCompraDet.estadoPago = Nothing
            objDocumentoVentaDet.estadoPago = "DC" 'TIPO_COMPRA.PAGO.PAGADO
            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento
            objDocumentoVentaDet.tipoVenta = tipoVenta '.VENTA_ANTICIPADA
            objDocumentoVentaDet.FechaDoc = txtFecha.Value
            objDocumentoVentaDet.CuentaProvedor = "1213" ' txtCuenta.Text.Trim
            objDocumentoVentaDet.NombreProveedor = txtCliente.Text.Trim
            objDocumentoVentaDet.Serie = txtSerie.Text.Trim
            objDocumentoVentaDet.NumDoc = txtNumero.Text.Trim
            objDocumentoVentaDet.TipoDoc = cboTipoDoc.SelectedValue
            objDocumentoVentaDet.destino = r.GetValue("gravado")
            'objDocumentoVentaDet.CuentaItem = Nothing
            objDocumentoVentaDet.idItem = r.GetValue("idProducto")
            objDocumentoVentaDet.tipoExistencia = TipoRecurso.SERVICIO
            objDocumentoVentaDet.DetalleItem = r.GetValue("item")


            If IsNumeric(r.GetValue("cantidad")) Then
                If CDec(r.GetValue("cantidad")) > 0 Then
                    objDocumentoVentaDet.monto1 = CDec(r.GetValue("cantidad")) ' cantidad
                Else
                    If MessageBoxAdv.Show("Desea ingresar el item con cantidad cero?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        objDocumentoVentaDet.monto1 = 0
                    Else
                        lblEstado.Text = "Ingrese una cantidad mayor a cero del item, " & r.GetValue("item")
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        Exit Sub
                    End If
                End If
            Else
                lblEstado.Text = "Ingrese una cantidad válida del item, " & r.GetValue("item")
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Exit Sub
            End If
            objDocumentoVentaDet.unidad1 = Nothing
            objDocumentoVentaDet.unidad2 = Nothing
            objDocumentoVentaDet.monto2 = Nothing
            objDocumentoVentaDet.categoria = 0
            objDocumentoVentaDet.idAlmacenOrigen = 0
            objDocumentoVentaDet.idPadreDTVenta = 0

            'objDocumentoVentaDet.almacenRef = Nothing
            objDocumentoVentaDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoVentaDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            If IsNumeric(r.GetValue("totalmn")) Then
                If CDec(r.GetValue("totalmn")) > 0 Then
                    objDocumentoVentaDet.importeMN = CDec(r.GetValue("totalmn"))
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


            objDocumentoVentaDet.importeME = CDec(r.GetValue("totalme"))
            objDocumentoVentaDet.montokardex = CDec(r.GetValue("vcmn"))
            objDocumentoVentaDet.montoIsc = 0 ' CDec(i.Cells(13).Value())
            objDocumentoVentaDet.montoIgv = CDec(r.GetValue("ivamn"))
            objDocumentoVentaDet.otrosTributos = 0 ' CDec(i.Cells(15).Value())
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = CDec(r.GetValue("vcme"))
            objDocumentoVentaDet.montoIscUS = 0
            objDocumentoVentaDet.montoIgvUS = CDec(r.GetValue("ivame"))
            objDocumentoVentaDet.otrosTributosUS = 0
            objDocumentoVentaDet.preEvento = Nothing  '= "00", Nothing, dgvCompra.Rows(S).Cells(23).Value())

            'objDocumentoVentaDet.bonificacion = r.GetValue("valBonif")

            'objDocumentoVentaDet.percepcionMN = CDec(r.GetValue("percepcionMN"))
            'objDocumentoVentaDet.percepcionME = CDec(r.GetValue("percepcionME"))
            '**********************************************************************************
            objDocumentoVentaDet.fechaModificacion = DateTime.Now
            objDocumentoVentaDet.fechaVcto = Date.Now ' IIf(IsNothing(dgvCompra.Rows(S).Cells(28).Value()), Nothing, CDate(dgvCompra.Rows(S).Cells(28).Value()))
            objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim
            objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario


            ListaDetalle.Add(objDocumentoVentaDet)
        Next
        '''''
        'Dim consultaPagados = (From n In ListaDetalle
        '                      Where n.estadoPago = "Pagado").Count

        'If consultaPagados > 0 Then


        '    Dim SumaItemsPagados = (From n In ListaDetalle
        '                      Where n.estadoPago = "Pagado" _
        '                      Select n.importe).Sum

        'Throw New Exception("Debe seleccionar una entidad financiera válida!")
        'End If


        'If consultaPagados > 0 Then
        '    AsientoItemPagado()
        'End If

        'Dim consultaNoPagados = (From n In ListaDetalle
        '                 Where n.estadoPago = "No Pagado").Count

        'If consultaNoPagados > 0 Then
        '    ndocumento.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
        'Else
        '    ndocumento.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PAGADO
        'End If

        ''''''
        ndocumento.ListaCustomDocumento = ListaDocumentoCaja()
        ''''''

        Dim listaExistencias As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle).ToList
        If CDec(txtTotalPagar.DecimalValue) > 0 Then
            AsientoVenta(listaExistencias)
        End If


        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle
        Dim xcod As Integer = VentaSA.SaveRegistroHonorariosVenta(ndocumento)
        lblEstado.Text = "compra registrada!"

        Dispose()
    End Sub

    ''' <summary>
    ''' 
    ''' 
    ''' </summary>
    ''' <remarks></remarks>

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
                nDocumentoCaja.tipoDoc = cboTipoDoc.SelectedValue 'GConfiguracion2.TipoComprobante
                nDocumentoCaja.fechaProceso = txtFecha.Value
                nDocumentoCaja.nroDoc = txtSerie.Text & "-" & txtNumero.Text 'GConfiguracion2.Serie
                nDocumentoCaja.idOrden = Nothing
                Select Case i.GetValue("moneda")
                    Case "NACIONAL"
                        nDocumentoCaja.moneda = 1

                    Case "EXTRANJERO"
                        nDocumentoCaja.moneda = 2
                End Select
                nDocumentoCaja.idEntidad = Val(txtCliente.Tag)
                nDocumentoCaja.entidad = txtCliente.Text
                nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
                nDocumentoCaja.nrodocEntidad = txtRuc.Text
                nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
                nDocumentoCaja.fechaActualizacion = DateTime.Now

                'DOCUMENTO CAJA
                objCaja = New documentoCaja
                objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                objCaja.idDocumento = 0
                objCaja.periodo = lblPerido.Text
                If txtCliente.Text.Trim.Length > 0 Then
                    objCaja.codigoProveedor = txtCliente.Tag
                End If
                objCaja.idEmpresa = Gempresas.IdEmpresaRuc
                objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
                objCaja.fechaProceso = txtFecha.Value
                objCaja.fechaCobro = txtFecha.Value
                objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                If txtCliente.Text.Trim.Length > 0 Then
                    objCaja.IdProveedor = txtCliente.Tag
                End If
                objCaja.TipoDocumentoPago = cboTipoDoc.SelectedValue
                objCaja.codigoLibro = "14"
                objCaja.tipoDocPago = cboTipoDoc.SelectedValue
                objCaja.NumeroDocumento = txtSerie.Text ' GConfiguracion2.Serie
                objCaja.numeroOperacion = i.GetValue("numOper")

                objCaja.montoSoles = Decimal.Parse(i.GetValue("montoMN"))
                Select Case i.GetValue("moneda")
                    Case "NACIONAL"
                        objCaja.moneda = 1
                        objCaja.tipoCambio = TmpTipoCambio
                        objCaja.montoUsd = Decimal.Parse(objCaja.montoSoles * TmpTipoCambio)
                    Case "EXTRANJERO"
                        objCaja.moneda = 2
                        objCaja.tipoCambio = i.GetValue("tipocambio")
                        objCaja.montoUsd = Decimal.Parse(i.GetValue("montoME"))
                End Select


                objCaja.estado = "P"
                objCaja.glosa = "Por ventas directa " & "nro. " & "-" & txtNumeroGuia.Text & " fecha: " & txtFecha.Value
                objCaja.entregado = "SI"
                objCaja.movimientoCaja = TIPO_VENTA.VENTA_ANTICIPADA
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

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = CInt(txtCliente.Tag)  ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Anticipada
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
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

        ListaAsientonTransito.Add(asiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = ef.cuenta
        nMovimiento.descripcion = ef.descripcion
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        'OJO LA CUENTA CONTABLE
        nMovimiento = New movimiento
        nMovimiento.cuenta = "1213"
        nMovimiento.descripcion = txtCliente.Text
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        'For Each i In gridCaja.Table.Records

        '    '   If dgvCompra.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
        '    nMovimiento = New movimiento
        '    nMovimiento.cuenta = i.GetValue("cuenta")
        '    nMovimiento.descripcion = i.GetValue("ef")
        '    nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        '    'nMovimiento.monto = CDec(r.GetValue("totalmn"))
        '    'nMovimiento.montoUSD = CDec(r.GetValue("totalme"))
        '    nMovimiento.monto = CDec(i.GetValue("montoMN"))
        '    nMovimiento.montoUSD = CDec(i.GetValue("montoMN") * TmpTipoCambio)
        '    nMovimiento.fechaActualizacion = DateTime.Now
        '    nMovimiento.usuarioActualizacion = usuario.IDUsuario
        '    asiento.movimiento.Add(nMovimiento)

        '    'If CDec(r.GetValue("percepcionMN")) > 0 Then
        '    '    asientoTransitod.movimiento.Add(AS_IGV(CDec(r.GetValue("percepcionMN")), CDec(r.GetValue("percepcionME"))))
        '    'End If

        'Next

    End Sub

    Private Sub ListaDetalleCaja(doc As documentoCaja)
        Dim obj As New documentoCajaDetalle
        Dim lista As New List(Of documentoCajaDetalle)
        For Each i As ListViewItem In lsvPagosRegistrados.Items
            If doc.NombreEntidad = i.SubItems(1).Text Then
                obj = New documentoCajaDetalle
                obj.fecha = txtFecha.Value
                obj.idItem = CInt(i.SubItems(2).Text)
                obj.DetalleItem = i.SubItems(3).Text
                obj.montoSoles = FormatNumber(Decimal.Parse(i.SubItems(4).Text), 2) ' CDbl(i.SubItems(4).Text)
                obj.montoUsd = FormatNumber(Decimal.Parse(i.SubItems(5).Text), 2) ' CDbl(i.SubItems(5).Text)

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

    Private Sub AsientoItemPagado()
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim cajaSa As New EstadosFinancierosSA
        Try
            nAsiento = New asiento
            nAsiento.idDocumento = 0
            nAsiento.periodo = lblPerido.Text
            nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
            nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
            nAsiento.idEntidad = CInt(txtCliente.Tag)
            nAsiento.nombreEntidad = txtCliente.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
            nAsiento.fechaProceso = txtFecha.Value
            nAsiento.codigoLibro = "14"
            nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
            nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Anticipada
            nAsiento.importeMN = TotalesXcanbeceras.TotalMN
            nAsiento.importeME = TotalesXcanbeceras.TotalME
            nAsiento.glosa = txtGlosa.Text.Trim
            nAsiento.usuarioActualizacion = "jiuni"
            nAsiento.fechaActualizacion = DateTime.Now

            For Each r As Record In dgvCompra.Table.Records
                nMovimiento = New movimiento
                nMovimiento.cuenta = "1213"
                nMovimiento.descripcion = r.GetValue("item")
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
                nMovimiento.monto = r.GetValue("totalmn")
                nMovimiento.montoUSD = r.GetValue("totalme")
                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = "Jiuni"
                nAsiento.movimiento.Add(nMovimiento)

                nMovimiento = New movimiento
                nMovimiento.cuenta = txtCliente.Tag
                nMovimiento.descripcion = r.GetValue("item")
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
                nMovimiento.monto = r.GetValue("totalmn")
                nMovimiento.montoUSD = r.GetValue("totalme")
                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = "Jiuni"
                nAsiento.movimiento.Add(nMovimiento)

                nMovimiento = New movimiento
                nMovimiento.cuenta = "40"
                nMovimiento.descripcion = r.GetValue("item")
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
                nMovimiento.monto = r.GetValue("totalmn")
                nMovimiento.montoUSD = r.GetValue("totalme")
                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nAsiento.movimiento.Add(nMovimiento)

            Next
            ListaAsientonTransito.Add(nAsiento)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

    End Sub
    ''' <summary>
    ''' ''''''''
    ''' </summary>
    ''' <remarks></remarks>

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
            'totalpercepMN += CDec(r.GetValue("percepcionMN"))
            'totalpercepME += CDec(r.GetValue("percepcionME"))

            'If r.GetValue("valBonif") = "S" Then
            '    totalDesc += CDec(r.GetValue("igvmn"))
            '    totalDescme += CDec(r.GetValue("igvme"))
            'Else
            totalVC += CDec(r.GetValue("vcmn"))
            totalVCme += CDec(r.GetValue("vcme"))

            totalIVA += CDec(r.GetValue("ivamn"))
            totalIVAme += CDec(r.GetValue("ivame"))

            total += CDec(r.GetValue("totalmn"))
            totalme += CDec(r.GetValue("totalme"))
            'End If

            Select Case r.GetValue("gravado")
                Case "1"
                    bs1 += CDec(r.GetValue("vcmn"))
                    bs1me += CDec(r.GetValue("vcme"))

                    igv1 += CDec(r.GetValue("ivamn"))
                    igv1me += CDec(r.GetValue("ivame"))
                Case "2"
                    bs2 += CDec(r.GetValue("vcmn"))
                    bs2me += CDec(r.GetValue("vcme"))

                    igv2 += CDec(r.GetValue("ivamn"))
                    igv2me += CDec(r.GetValue("ivame"))
            End Select

        Next

        TotalesXcanbeceras = New TotalesXcanbecera()

        'TotalesXcanbeceras.PercepcionMN = totalpercepMN
        'TotalesXcanbeceras.PercepcionME = totalpercepME

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

        If colDestinoGravado = 1 Then
            valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
            valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
        Else
            valPercepMN = 0
            valPercepME = 0

        End If

        '****************************************************************

        cantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
        Select Case cboMoneda.SelectedValue
            Case 1 'MONEDA NACIONAL
                VC = Me.dgvCompra.Table.CurrentRecord.GetValue("vcmn")
                VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)

            Case 2 'MONEDA EXTRANJERA
                VCme = Me.dgvCompra.Table.CurrentRecord.GetValue("vcme") ' 
                VC = Math.Round(VCme * CDec(txtTipoCambio.DecimalValue), 2)

        End Select

        If cantidad > 0 Then
            Igv = Math.Round(VC * (TmpIGV / 100), 2)
            IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

            colBI = VC + Igv + valPercepMN
            colBIme = VCme + IgvME + valPercepME

            colPrecUnit = Math.Round(VC / cantidad, 2)
            colPrecUnitme = Math.Round(VCme / cantidad, 2)
        ElseIf cantidad = 0 Then
            Igv = Math.Round(VC * (TmpIGV / 100), 2)
            IgvME = Math.Round(VCme * (TmpIGV / 100), 2)
            colBI = VC + Igv + valPercepMN
            colBIme = VCme + IgvME + valPercepME
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


        Select Case colDestinoGravado
            Case "2", "3", "4"
                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", VC.ToString("N2"))
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", VCme.ToString("N2"))
                Me.dgvCompra.Table.CurrentRecord.SetValue("ivamn", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("ivame", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)

            Case Else
                If cantidad > 0 Then
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                    Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                    Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", colBI.ToString("N2"))
                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", colBIme.ToString("N2"))
                    Me.dgvCompra.Table.CurrentRecord.SetValue("ivamn", Igv.ToString("N2"))
                    Me.dgvCompra.Table.CurrentRecord.SetValue("ivame", IgvME.ToString("N2"))
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", valPercepMN)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", valPercepME)
                End If

                'End If
        End Select

        TotalTalesXcolumna()
    End Sub


    Sub ConfiguracionInicio()
        TotalesXcanbeceras = New TotalesXcanbecera()
        'configurando docking manager

        '  If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
        dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
        dgvCompra.TableDescriptor.Columns("ivamn").Width = 65
        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

        dgvCompra.TableDescriptor.Columns("pume").Width = 0
        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
        dgvCompra.TableDescriptor.Columns("ivame").Width = 0
        dgvCompra.TableDescriptor.Columns("totalme").Width = 0
        cboMoneda.SelectedValue = 1
        '  End If

        'confgiurando variables generales
        txtGlosa.Text = "Por la venta según " & ""
        txtIva.DoubleValue = TmpIGV / 100
        lblPerido.Text = PeriodoGeneral

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
        dt.Columns.Add("ivamn", GetType(Decimal))
        dt.Columns.Add("ivame", GetType(Decimal))
        dt.Columns.Add("pumn", GetType(Decimal))
        dt.Columns.Add("pume", GetType(Decimal))
        dt.Columns.Add("percepcionMN", GetType(Decimal))
        dt.Columns.Add("percepcionME", GetType(Decimal))
        dt.Columns.Add("Action", GetType(String))
        dt.Columns.Add("chPago", GetType(Boolean))
        dt.Columns.Add("valPago", GetType(String))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("pagado", GetType(Decimal))
        dgvCompra.DataSource = dt
    End Sub

    Public Sub Loadcontroles()
        Dim listatabla As New List(Of tabladetalle)
        Dim TablaSA As New tablaDetalleSA
        Dim entidadSA As New entidadSA

        txtFecVcto.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        DateTimePickerAdv1.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(1, "NACIONAL")
        dt.Rows.Add(2, "EXTRANJERA")

        cboMoneda.ValueMember = "id"
        cboMoneda.DisplayMember = "name"
        cboMoneda.DataSource = dt
        cboMoneda.SelectedIndex = 0

        'COMPROBANTE TIPO DOCUMENTOS
        Dim list As New List(Of String)
        list.Add("07")
        list.Add("08")
        list.Add("02")
        listatabla = New List(Of tabladetalle)
        listatabla = TablaSA.GetListaTablaDetalle(10, "1")

        Dim Comprobantes = (From n In listatabla
                            Where Not list.Contains(n.codigoDetalle)).ToList


        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.ValueMember = "codigoDetalle"
        cboTipoDoc.DataSource = Comprobantes
        txtTipoCambio.DecimalValue = TmpTipoCambio
    End Sub

    Public Sub UbicarEntidadPorRuc(strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                txtCliente.Text = .nombreCompleto
                txtCliente.Tag = .idEntidad
                '   txtCuenta.Text = .cuentaAsiento
                txtRuc.Text = .nrodoc
                txtCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End With
        Else
            txtCliente.Clear()
            '  txtCuenta.Clear()
            txtRuc.Clear()
            If MessageBoxAdv.Show("Desea crear un nuevo proveedor?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Dim f As New frmCrearENtidades
                f.CaptionLabels(0).Text = "Nuevo proveedor"
                f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        End If
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
#End Region

    Private Sub frmAnticipoXVenta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub


    Private Sub frmAnticipoXVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub tb19_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles tb19.ButtonStateChanged
        If Not IsNothing(TotalesXcanbeceras) Then
            If tb19.ToggleState = ToggleButton2.ToggleButtonState.ON Then
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseME
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvME
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalME
                txtRetencion.DecimalValue = TotalesXcanbeceras.PercepcionME

                dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                dgvCompra.TableDescriptor.Columns("ivamn").Width = 0
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 0

                dgvCompra.TableDescriptor.Columns("pume").Width = 60
                dgvCompra.TableDescriptor.Columns("vcme").Width = 65
                dgvCompra.TableDescriptor.Columns("ivame").Width = 65
                dgvCompra.TableDescriptor.Columns("totalme").Width = 70
                cboMoneda.SelectedValue = 2

                txtTipoCambio.DecimalValue = 0.0

            ElseIf tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseMN
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvMN
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalMN
                txtRetencion.DecimalValue = TotalesXcanbeceras.PercepcionMN

                dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                dgvCompra.TableDescriptor.Columns("ivamn").Width = 65
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

                dgvCompra.TableDescriptor.Columns("pume").Width = 0
                dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                dgvCompra.TableDescriptor.Columns("ivame").Width = 0
                dgvCompra.TableDescriptor.Columns("totalme").Width = 0
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

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        AddRowDefault()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        AddRowDefault432()
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
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

            If Not txtCliente.Text.Trim.Length > 0 Then
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


            If txtFecVcto.IsNullDate Then
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
                    Grabar()
                ElseIf ManipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                    'Dim Filas As Integer = dgvCompra.DisplayedRowCount(True)
                    'If Filas > 0 Then
                    '    UpdateCompra()

                    'UpdateServicioPublico()
                    'Dim Filas As Integer = dgvCompra.DisplayedRowCount(True)
                    'If Filas > 0 Then
                    '    UpdateCompra()
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

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs)
        txtCliente.ForeColor = Color.Black
        txtCliente.Tag = Nothing
    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs)
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtRuc.Text.Trim.Length > 0 Then
                'If VAL_RUC(txtRuc.Text) = False Then
                '    MessageBoxAdv.Show("RUC NO VALIDO", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                '    MessageBoxAdv.Show("OK", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UbicarEntidadPorRuc(txtRuc.Text.Trim)
                'End If

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.strTipo = TIPO_ENTIDAD.PROVEEDOR
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.tipoPersona(TIPO_ENTIDAD.PROVEEDOR)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, entidad)
            txtCliente.Text = c.nombreCompleto
            txtCliente.Tag = c.idEntidad
            txtRuc.Text = c.nrodoc
            txtCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick
        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style.Enabled Then
            If style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style.TableCellIdentity.Column.Name = "chPago" Then
                e.Inner.Cancel = True
            End If
            Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If
    End Sub

    Private Sub dgvCompra_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCheckBoxClick
        'Dim style As GridTableCellStyleInfo = DirectCast(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
        'Dim el As Element = Me.dgvCompra.Table.GetInnerMostCurrentElement()

        'Dim colindexVal As Integer = style.CellIdentity.ColIndex

        'Dim RowIndex2 As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        'If RowIndex2 > -1 Then
        '    Select Case colindexVal
        '        Case 17

        '            'If IsNothing(GFichaUsuarios) Then
        '            '    lblEstado.Text = "Debe iniciar una caja, antes de realizar esta operación.!"
        '            '    PanelError.Visible = True
        '            '    Timer1.Enabled = True
        '            '    TiempoEjecutar(10)
        '            '    'Me.dgvCompra.TableModel(e.Inner.RowIndex, 16).CellValue = False
        '            '    Exit Sub
        '            'Else
        '            If style.Enabled Then
        '                Dim column As Integer = Me.dgvCompra.TableModel.NameToColIndex("chPago")
        '                ' Console.WriteLine("CheckBoxClicked")
        '                '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
        '                If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
        '                    chk = CBool(Me.dgvCompra.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

        '                    e.TableControl.BeginUpdate()

        '                    e.TableControl.EndUpdate(True)
        '                End If
        '                If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "chPago" Then
        '                    Dim currentRecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
        '                    Dim curStatus As Boolean = Boolean.Parse(style.Text)
        '                    e.TableControl.BeginUpdate()

        '                    If curStatus Then
        '                        '   CheckBoxValue = False
        '                    End If
        '                    If curStatus = True Then
        '                        Dim RowIndex As Integer = e.Inner.RowIndex
        '                        Dim ColIndex As Integer = e.Inner.ColIndex

        '                        Me.dgvCompra.TableModel(RowIndex, 18).CellValue = "No Pagado"

        '                    Else
        '                        Dim RowIndex As Integer = e.Inner.RowIndex
        '                        Dim ColIndex As Integer = e.Inner.ColIndex

        '                        Me.dgvCompra.TableModel(RowIndex, 18).CellValue = "Pagado"



        '                    End If
        '                    e.TableControl.EndUpdate()
        '                    If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
        '                    ElseIf Not ht.Contains(curStatus) Then
        '                    End If
        '                    ht.Clear()
        '                End If
        '            End If
        '            'End If


        '    End Select

        '    Me.dgvCompra.TableControl.Refresh()
        '    TotalTalesXcolumna()
        'End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCompra.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
        Calculos()
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
        '    Select Case ColIndex
        '        Case 5, 10 'Valor de compra
        '            Calculos()

        '        Case 8
        '            Dim colPercepcionME As Decimal = 0
        '            colPercepcionME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")) / TmpTipoCambio, 2)
        '            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", colPercepcionME)
        '            Calculos()

        '        Case 1
        '            'If Me.dgvCompra.Table.CurrentRecord.GetValue("gravado") = "1" Or Me.dgvCompra.Table.CurrentRecord.GetValue("gravado") = "2" Then

        '            Calculos()

        '            'Else
        '            'Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", "1")
        '            'Calculos()
        '            'End If
        '    End Select
        'End If
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtCliente.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtCliente.Text.Trim
                End If
                txtNumero.Select()
                'Tag = 1
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtCliente.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtCliente.Text.Trim
                End If
                'cboMoneda.Select()
                txtCliente.Select()
                Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.CLIENTE)
                f.CaptionLabels(0).Text = "Cliente"
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                If Not IsNothing(f.Tag) Then
                    Dim c = DirectCast(f.Tag, entidad)
                    'Dim c = CType(f.Tag, entidad)
                    txtCliente.Text = c.nombreCompleto
                    txtCliente.Tag = c.idEntidad
                    txtRuc.Text = c.nrodoc
                    txtRuc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                End If
                'txtProveedor.Focus()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumero.Clear()
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        Try
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
            'If (chIdentificacion.Checked = True) Then
            '    If Not TXTcOMPRADOR.Text.Trim.Length > 0 Then
            '        lblEstado.Text = "Ingresar el nombre de comprador"
            '        Timer1.Enabled = True
            '        PanelError.Visible = True
            '        TiempoEjecutar(10)

            '        Me.Cursor = Cursors.Arrow
            '        Exit Sub
            '    Else
            '        lblEstado.Text = "Done comprador"
            '    End If
            'Else
            'If txtRuc.Text.Trim.Length > 0 Then
            '    If txtRuc.ForeColor = Color.Black Then
            '        MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        txtCliente.Select()
            '        Me.Cursor = Cursors.Arrow
            '        Exit Sub
            '    End If
            'End If

            'If txtRuc.Text.Trim.Length > 0 Then
            '    If txtRuc.ForeColor = Color.Black Then
            '        MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        txtRuc.Select()
            '        Me.Cursor = Cursors.Arrow
            '        Exit Sub
            '    End If
            'End If
            'End If

            With frmCajasXusuario
                .DigitalGauge2.Value = DigitalGauge2.Value
                .txtFecha.Value = txtFecha.Value
                .txtTipoDoc.Text = cboTipoDoc.Text
                .txtSerie.Text = txtSerie.Text
                .txtNumero.Text = txtNumero.Text
                .txtCliente.Text = txtCliente.Text
                .txtRuc.Text = txtRuc.Text
                .tipoVenta = TIPO_VENTA.VENTA_ANTICIPADA
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

#Region "caja"
    Dim colorx As New GridMetroColors()
    Dim ListadocajaDelUsuario As New List(Of cajaUsuario)
    Dim idCajaUsuario As Integer
    Dim cajausuario As New List(Of cajaUsuario)

    Public Function UbicarCajasHijas() As DataTable

        Dim dt As New DataTable
        dt.Columns.Add("idEntidad")
        dt.Columns.Add("ef")
        dt.Columns.Add("pago")
        dt.Columns.Add("moneda")
        dt.Columns.Add("tipocambio", GetType(Decimal))
        dt.Columns.Add("montoMN", GetType(Double))
        dt.Columns.Add("montoME", GetType(Double))
        dt.Columns.Add("total", GetType(Double))
        dt.Columns.Add("importePendiente", GetType(Decimal))
        dt.Columns.Add("vueltoMN", GetType(Decimal))
        dt.Columns.Add("vueltoME", GetType(Decimal))
        dt.Columns.Add("saldo", GetType(Decimal))
        dt.Columns.Add("idempresa", GetType(String))

        Return dt
    End Function

    Sub cargarDatosCuentas()
        Dim cuentaUsuarioDetalleSA As New cajaUsuarioSA

        Dim objCuenta As New cajaUsuario

        objCuenta = cuentaUsuarioDetalleSA.UbicarUsuarioAbierto(usuario.IDUsuario)

        If (Not IsNothing(objCuenta)) Then
            idCajaUsuario = objCuenta.idcajaUsuario
        End If


    End Sub

    Public Sub CargarCajasTipo(idpersona As Integer)
        Dim cajausuariosa As New cajaUsuarioSA
        Try
            If (Not IsNothing(idpersona) And (idCajaUsuario) > 0) Then
                cajaUsuario = cajausuariosa.ResumenTransaccionesXusuarioCaja(New cajaUsuario With {.idcajaUsuario = idCajaUsuario, .idPersona = idpersona})
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False


        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Private Sub CMBCajasDelUsuarioPV()
        Try
            'Dim cajausuariosa As New cajaUsuarioSA
            'Dim cajausuarios As New cajaUsuario
            'Dim servicioSA As New servicioSA

            'ListadocajaDelUsuario = New List(Of cajaUsuario)
            'cajausuarios = cajausuariosa.UbicarUsuarioAbierto(usuario.IDUsuario)
            'If Not IsNothing(cajausuarios) Then
            '    ListadocajaDelUsuario = cajausuariosa.ResumenTransaccionesXusuarioCaja(New cajaUsuario With {.idcajaUsuario = cajausuarios.idcajaUsuario, .idPersona = usuario.IDUsuario})
            'End If

            'For Each item In cajaUsuario
            '    GridPago(item)
            'Next

            'Dim dt As New DataTable("Historial de últimas entradas ")
            'dt.Columns.Add("idEntidad")
            'dt.Columns.Add("tipo")
            'dt.Columns.Add("nombreEntidad")

            'For Each i In ListadocajaDelUsuario
            '    Dim dr As DataRow = dt.NewRow
            '    dr(0) = i.idEntidad
            '    dr(1) = i.Tipo
            '    dr(2) = i.NombreEntidad
            '    dt.Rows.Add(dr)

            'Next
            'dgvEntidades.DataSource = dt
            'dgvEntidades.TableOptions.ListBoxSelectionMode = SelectionMode.One

            'Dim cajaBE = (From a In cajausuario Where a.Tipo = CuentaFinanciera.Efectivo And a.moneda = TipoMoneda.Nacional).FirstOrDefault

            'If Not IsNothing(cajaBE) Then
            'Else
            'PanelError.Visible = True
            'lblEstado.Text = "ya existe una entidad financiera!"
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Sub GridPago(cajaBE As cajaUsuario)

    '    Dim cuentaUsuarioDetalleSA As New cajaUsuarioDetalleSA
    '    Dim contador As Integer = 0
    '    Dim saldooagado As Integer = 0
    '    Dim contadorMon As Integer = 0
    '    For Each i In dgvPagos.Table.Records
    '        If (i.GetValue("idEntidad") = cajaBE.idEntidad) Then
    '            contador += 1
    '        End If
    '        If (dgvPagos.Table.Records.Count > 1) Then
    '            If (i.GetValue("saldo") = 0) Then
    '                saldooagado = 1
    '            End If
    '        End If
    '        If (i.GetValue("moneda") = "EXTRANJERO") Then
    '            contadorMon = 1
    '        End If

    '    Next

    '    If (contador = 0) Then


    '        If Not IsNothing(cajaBE) Then
    '            If (cajaBE.moneda = TipoMoneda.Nacional And cajaBE.Tipo = CuentaFinanciera.Efectivo) Then
    '                'Dim i = (From a In listaCajaUsuario Where a.moneda = 1).FirstOrDefault

    '                Me.dgvPagos.Table.AddNewRecord.SetCurrent()
    '                Me.dgvPagos.Table.AddNewRecord.BeginEdit()
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "EFECTIVO")
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "NACIONAL")
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0) '5
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)

    '                Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 0
    '                If (contadorMon = 1) Then
    '                    Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 90
    '                    Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
    '                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 90
    '                Else
    '                    Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 0
    '                    Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 0
    '                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 0
    '                End If

    '                Me.dgvPagos.Table.AddNewRecord.EndEdit()


    '            ElseIf (cajaBE.moneda = TipoMoneda.Extranjero And cajaBE.Tipo = CuentaFinanciera.Efectivo) Then
    '                'Dim i = (From a In listaCajaUsuario Where a.moneda = 2).FirstOrDefault

    '                Me.dgvPagos.Table.AddNewRecord.SetCurrent()
    '                Me.dgvPagos.Table.AddNewRecord.BeginEdit()
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "EFECTIVO")
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "EXTRANJERO")
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", CDec(TmpTipoCambioTransaccionCompra))
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)
    '                Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 50

    '                Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 90
    '                Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
    '                Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 90

    '                Me.dgvPagos.Table.AddNewRecord.EndEdit()

    '            ElseIf (cajaBE.moneda = TipoMoneda.Nacional And cajaBE.Tipo = CuentaFinanciera.Banco) Then
    '                'Dim i = (From a In listaCajaUsuario Where a.moneda = 1).FirstOrDefault

    '                Me.dgvPagos.Table.AddNewRecord.SetCurrent()
    '                Me.dgvPagos.Table.AddNewRecord.BeginEdit()
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "BANCO")
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "NACIONAL")
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)
    '                If (contadorMon = 1) Then
    '                    Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 90
    '                    Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
    '                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 90
    '                Else
    '                    Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 0
    '                    Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 0
    '                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 0
    '                End If
    '                Me.dgvPagos.Table.AddNewRecord.EndEdit()


    '            ElseIf (cajaBE.moneda = TipoMoneda.Extranjero And cajaBE.Tipo = CuentaFinanciera.Banco) Then
    '                'Dim i = (From a In listaCajaUsuario Where a.moneda = 2).FirstOrDefault

    '                Me.dgvPagos.Table.AddNewRecord.SetCurrent()
    '                Me.dgvPagos.Table.AddNewRecord.BeginEdit()
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "BANCO")
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "EXTRANJERO")
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", CDec(TmpTipoCambioTransaccionCompra))
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)
    '                Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 50

    '                Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 90
    '                Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
    '                Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 90

    '                Me.dgvPagos.Table.AddNewRecord.EndEdit()


    '            ElseIf (cajaBE.moneda = TipoMoneda.Nacional And cajaBE.Tipo = CuentaFinanciera.Tarjeta_Credito) Then
    '                'Dim i = (From a In listaCajaUsuario Where a.moneda = 1).FirstOrDefault

    '                Me.dgvPagos.Table.AddNewRecord.SetCurrent()
    '                Me.dgvPagos.Table.AddNewRecord.BeginEdit()
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "TARJETA CREDITO")
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "NACIONAL")
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)
    '                If (contadorMon = 1) Then
    '                    Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 90
    '                    Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
    '                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 90
    '                Else
    '                    Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 0
    '                    Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 0
    '                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 0
    '                End If
    '                Me.dgvPagos.Table.AddNewRecord.EndEdit()


    '            ElseIf (cajaBE.moneda = TipoMoneda.Extranjero And cajaBE.Tipo = CuentaFinanciera.Tarjeta_Credito) Then
    '                'Dim i = (From a In listaCajaUsuario Where a.moneda = 2).FirstOrDefault

    '                Me.dgvPagos.Table.AddNewRecord.SetCurrent()
    '                Me.dgvPagos.Table.AddNewRecord.BeginEdit()
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "TARJETA CREDITO")
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "EXTRANJERO")
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", CDec(TmpTipoCambioTransaccionCompra))
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)
    '                Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 50

    '                Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 90
    '                Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
    '                Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 90

    '                Me.dgvPagos.Table.AddNewRecord.EndEdit()

    '            End If
    '        End If


    '        'If (saldooagado = 0) Then


    '        'Else
    '        '    PanelError.Visible = True
    '        '    lblEstado.Text = "Ya realizo todo el pago!"
    '        '    Timer1.Enabled = True
    '        '    TiempoEjecutar(10)
    '        'End If

    '    Else
    '        PanelError.Visible = True
    '        lblEstado.Text = "ya existe una entidad financiera!"
    '        Timer1.Enabled = True
    '        TiempoEjecutar(10)
    '    End If


    'End Sub

#End Region


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

    Private Sub dgvPagos_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs)
        If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Or e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement
            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record) Then
                Dim r As Record = el.GetRecord
                Dim value As Object = r.GetValue("pago")
                Dim moneda As Object = r.GetValue("moneda")

                Select Case value

                    Case "EFECTIVO"
                        Select Case moneda
                            Case "NACIONAL"
                                e.Style.BackColor = Color.Black  'ColorTranslator.FromHtml("#FFD01212")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 14
                                e.Style.Font.Facename = "Arial"
                            Case "EXTRANJERO"
                                e.Style.BackColor = Color.Black  'ColorTranslator.FromHtml("#FFD01212")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 14
                                e.Style.Font.Facename = "Arial"
                        End Select


                    Case "BANCO"
                        Select Case moneda
                            Case "NACIONAL"
                                e.Style.BackColor = Color.Black  'ColorTranslator.FromHtml("#FFD01212")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 14
                                e.Style.Font.Facename = "Arial"
                            Case "EXTRANJERO"
                                e.Style.BackColor = Color.Black  'ColorTranslator.FromHtml("#FFD01212")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 14
                                e.Style.Font.Facename = "Arial"
                        End Select


                    Case "TARJETA CREDITO"
                        Select Case moneda
                            Case "NACIONAL"
                                e.Style.BackColor = Color.Black  'ColorTranslator.FromHtml("#FFD01212")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 14
                                e.Style.Font.Facename = "Arial"
                            Case "EXTRANJERO"
                                e.Style.BackColor = Color.Black  'ColorTranslator.FromHtml("#FFD01212")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 14
                                e.Style.Font.Facename = "Arial"
                        End Select

                End Select

            End If

        End If

        e.Handled = True

        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue
            'If (Not IsNothing(str)) Then

            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "importePendiente")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("importePendiente")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue

                    e.Style.BackColor = Color.Black  'ColorTranslator.FromHtml("#FFD01212")
                    e.Style.TextColor = Color.White
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 14
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If


            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "saldo")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("saldo")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue

                    e.Style.BackColor = Color.Black  'ColorTranslator.FromHtml("#FFD01212")
                    e.Style.TextColor = Color.White
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 14
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If

            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "montoMN")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("montoMN")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue

                    e.Style.BackColor = Color.Black  'ColorTranslator.FromHtml("#FFD01212")
                    e.Style.TextColor = Color.White
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 14
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If

            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "montoME")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("montoME")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue
                    e.Style.BackColor = Color.Black  'ColorTranslator.FromHtml("#FFD01212")
                    e.Style.TextColor = Color.White
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 14
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If

            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "tipocambio")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("tipocambio")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue
                    'e.Style.BackColor = Color.FromArgb(255, 255, 128)
                    'e.Style.TextColor = Color.Black
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 14
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If
        End If

        'End If
    End Sub

    Private Sub frmAnticipoXVenta_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then

            With frmCajasXusuario
                .DigitalGauge2.Value = DigitalGauge2.Value
                .txtFecha.Value = txtFecha.Value
                .txtTipoDoc.Text = cboTipoDoc.Text
                .txtSerie.Text = txtSerie.Text
                .txtNumero.Text = txtNumero.Text
                .txtCliente.Text = txtCliente.Text
                .txtRuc.Text = txtRuc.Text
                .tipoVenta = TIPO_VENTA.VENTA_ANTICIPADA
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()

            End With

        ElseIf e.KeyCode = Keys.F6 Then
        End If
    End Sub

    Private Sub frmAnticipoXVenta_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.F6 Then

            With frmCajasXusuario
                .DigitalGauge2.Value = DigitalGauge2.Value
                .txtFecha.Value = txtFecha.Value
                .txtTipoDoc.Text = cboTipoDoc.Text
                .txtSerie.Text = txtSerie.Text
                .txtNumero.Text = txtNumero.Text
                .txtCliente.Text = txtCliente.Text
                .txtRuc.Text = txtRuc.Text
                .tipoVenta = TIPO_VENTA.VENTA_ANTICIPADA
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()

            End With

        ElseIf e.KeyCode = Keys.F6 Then
        End If
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, entidad)
            txtCliente.Text = c.nombreCompleto
            txtRuc.Text = c.nrodoc
            txtCliente.Tag = c.idEntidad
            txtRuc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
    End Sub

    Private Sub txtRuc_KeyDown_1(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtRuc.Text.Trim.Length > 0 Then
                'If VAL_RUC(txtRuc.Text) = False Then
                '    MessageBoxAdv.Show("RUC NO VALIDO", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                '    MessageBoxAdv.Show("OK", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UbicarEntidadPorRuc(txtRuc.Text.Trim)
                'End If

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs)
        'dgvPagos.Table.Records.DeleteAll()
        'CMBCajasDelUsuarioPV()
    End Sub

    Private Sub ToolStrip5_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip5.ItemClicked

    End Sub

    Private Sub txtNumero_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cboTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedIndexChanged
        'Tag = 1
    End Sub

    Private Sub frmAnticipoXVenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.F5) ' mayúsculas y minúsculas
                With frmCajasXusuario
                    .DigitalGauge2.Value = DigitalGauge2.Value
                    .txtFecha.Value = txtFecha.Value
                    .txtTipoDoc.Text = cboTipoDoc.Text
                    .txtSerie.Text = txtSerie.Text
                    .txtNumero.Text = txtNumero.Text
                    .txtCliente.Text = txtCliente.Text
                    .txtRuc.Text = txtRuc.Text
                    .tipoVenta = TIPO_VENTA.VENTA_ANTICIPADA
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
        End Select
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellChanged
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()

        If Not IsNothing(cc) Then
            Select Case cc.ColIndex
                Case 5, 10 'Valor de compra
                    Calculos()

                Case 8
                    Dim colPercepcionME As Decimal = 0
                    colPercepcionME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")) / TmpTipoCambio, 2)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", colPercepcionME)
                    Calculos()
                Case 1
                    Calculos()
            End Select
        End If
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.CLIENTE)
        f.CaptionLabels(0).Text = "Clientes"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = DirectCast(f.Tag, entidad)
            'Dim c = CType(f.Tag, entidad)
            txtCliente.Text = c.nombreCompleto
            txtCliente.Tag = c.idEntidad
            txtRuc.Text = c.nrodoc
            txtRuc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub txtNumero_TextChanged_1(sender As Object, e As EventArgs) Handles txtNumero.TextChanged

    End Sub
End Class