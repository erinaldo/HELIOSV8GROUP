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

Public Class frmCompraAnticipada

    Dim ListaAsientonTransito As New List(Of asiento)
    Dim tipoCompra As String
    Public Property TotalesXcanbeceras As TotalesXcanbecera
    Public Property idAlmacenVirtual() As Integer
    Public Property ManipulacionEstado() As String
    Public Property ListaTipoCambio As New List(Of tipoCambio)
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

        ' Add any initialization after the InitializeComponent() call.
        'ListaDefaultDeInicio()
        Loadcontroles()
        GetTableGrid()
        ConfiguracionInicio()
        AddRowDefault()
        Me.KeyPreview = True
    End Sub


    Public Sub New(intIdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'ListaDefaultDeInicio()
        Loadcontroles()
        GetTableGrid()
        ConfiguracionInicio()
        UbicarDocumento(intIdDocumento)
        Me.KeyPreview = True
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

#Region "Métodos"

    Public Sub llenarGrid(grid As GridGroupingControl, tag As Integer)
        Dim empresaPeriodoSA As New empresaCierreMensualSA
        Dim compraSA As New DocumentoCompraSA
        If (tag = 1) Then

            gridCaja = grid
            CalculoPagos()
            Me.Cursor = Cursors.WaitCursor
            Try

                If Not txtProveedor.Text.Length > 0 Then

                    MessageBox.Show("Ingrese el cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtProveedor.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
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



                Dim CONTEO As Integer = 0
                For Each item In dgvCompra.Table.Records
                    If (item.GetValue("cantPendiente") > 0) Then
                        CONTEO += 1
                    End If
                Next



                '***********************************************************************
                If dgvCompra.Table.Records.Count > 0 Then
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
                                                                                            .tipoDoc = cboTipoDoc.SelectedValue,
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


                        Dim sumaPagos As Decimal = 0
                        Dim totalPago As Decimal = 0
                        For Each i In grid.Table.Records
                            sumaPagos += CDec(i.GetValue("montoMN"))
                            If (i.GetValue("moneda") = "EXTRANJERO") Then
                                If (i.GetValue("montoME") = 0) Then
                                    Throw New Exception("Debe Ingresar importe extranjero!")
                                End If

                            End If
                        Next

                        If (sumaPagos) = DigitalGauge2.Value Then

                            'If MessageBoxAdv.Show("Desea imprimir la venta?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                            '    If dgvPagos.Table.Records.Count > 0 Then
                            '        llenarDatos()
                            '        imprimir(True)
                            '    End If
                            'End If
                            Grabar()
                            'Dispose()

                        Else
                            MessageBoxAdv.Show("Debe realizar el cobro en su integridad, no parcial!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If


                    Else
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

                    Me.lblEstado.Text = "Ingrese items a la canasta de venta!"
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

    'Sub AddRowDefault()

    '    Me.dgvCompra.Table.AddNewRecord.SetCurrent()
    '    Me.dgvCompra.Table.AddNewRecord.BeginEdit()
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", 1)
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", "422")
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("item", "ANTICIPOS A PROVEEDORES")
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
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", "432")
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("item", "ANTICIPOS OTORGADOS")
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
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", "422")
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", "ANTICIPOS A PROVEEDORES")
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
            Me.dgvCompra.Table.CurrentRecord.SetValue("estadoPag", "NO")
            Me.dgvCompra.Table.CurrentRecord.SetValue("pagado", 0.0)
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
            tipoCompra = TIPO_COMPRA.COMPRA_ANTICIPADA_RECIBIDA
        Else
            lblEstado.Text = "No puede ingresar otro tipo de Anticipo, "
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
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", "432")
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", "ANTICIPOS OTORGADOS")
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
            Me.dgvCompra.Table.CurrentRecord.SetValue("estadoPag", "NO")
            Me.dgvCompra.Table.CurrentRecord.SetValue("pagado", 0.0)
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
            tipoCompra = TIPO_COMPRA.COMPRA_ANTICIPADA_OTORGADO
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
    'Sub GetObtenerSaldoEF()
    '    Dim EFSA As New EstadosFinancierosSA

    '    txtFondoEF.DecimalValue = EFSA.GetEstadoSaldoEF(New estadosFinancieros With {.idestado = cboDepositoHijo.SelectedValue}).importeBalanceMN

    'End Sub

    'Private Sub cargarDatosCuenta(idCaja As Integer)
    '    Dim estadoSA As New EstadosFinancierosSA
    '    Dim estadoBL As New estadosFinancieros

    '    estadoBL = estadoSA.GetUbicar_estadosFinancierosPorID(idCaja)
    '    If (Not IsNothing(estadoBL)) Then
    '        ComboBoxAdv1.SelectedValue = estadoBL.codigo


    '        'GetObtenerSaldoEF()

    '    End If
    'End Sub

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
            ' Tag = 0

            ComboBoxAdv1.ValueMember = "codigoDetalle"
            ComboBoxAdv1.DisplayMember = "descripcion"
            ComboBoxAdv1.DataSource = taBLASA.GetListaTablaDetalle(4, "1")
            ComboBoxAdv1.SelectedValue = -1


        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargarCtasFinan()
        If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo("EF")
            'Dim lista As New List(Of String)
            'lista.Add("001")
            'lista.Add("109")

            'ListaDocPago(lista)
            'cboTipoDoc.SelectedValue = "001"
        ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo("BC")
            'Dim lista As New List(Of String)
            'lista.Add("001")
            'lista.Add("003")
            'lista.Add("007")
            'lista.Add("111")
            'ListaDocPago(lista)
            'cboTipoDoc.SelectedValue = "001"
        End If
    End Sub


    'Private Sub ListaDefaultDeInicio()
    '    dockingManager1.DockControlInAutoHideMode(GroupBox3, Syncfusion.Windows.Forms.Tools.DockingStyle.Top, 65)
    '    Me.DockingClientPanel1.AutoScroll = True
    '    Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    '    dockingManager1.SetDockLabel(GroupBox3, "Entidad Financiera")
    '    dockingManager1.CloseEnabled = False
    '    dockingManager1.SetDockVisibility(GroupBox3, False)
    'End Sub


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
                lblPerido.Text = .fechaContable
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
                txtProveedor.Text = nEntidad.nombreCompleto
                txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                txtTipoCambio.DecimalValue = .tcDolLoc
                txtIva.DoubleValue = .tasaIgv
                txtGlosa.Text = .glosa
                txtProveedor.Tag = nEntidad.idEntidad
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
            'PanelServicios.Visible = False
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
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.periodo = lblPerido.Text
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_Anticipada
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
              .cuenta = "40111",
              .descripcion = "I.G.V.",
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    Public Function AS_Proveedor(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "4212",
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
            'nMovimiento.monto = CDec(r.GetValue("totalmn"))
            'nMovimiento.montoUSD = CDec(r.GetValue("totalme"))
            nMovimiento.monto = CDec(r.GetValue("vcmn"))
            nMovimiento.montoUSD = CDec(r.GetValue("vcme"))
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            asientoTransitod.movimiento.Add(nMovimiento)

            'If CDec(r.GetValue("percepcionMN")) > 0 Then
            '    asientoTransitod.movimiento.Add(AS_IGV(CDec(r.GetValue("percepcionMN")), CDec(r.GetValue("percepcionME"))))
            'End If


        Next
        If TotalesXcanbeceras.IgvMN > 0 Then
            asientoTransitod.movimiento.Add(AS_IGV(TotalesXcanbeceras.IgvMN, TotalesXcanbeceras.IgvME))
        End If
        asientoTransitod.movimiento.Add(AS_Proveedor(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Sub UpdateServicioPublico()
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
            .tipoDoc = cboTipoDoc.SelectedValue
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
            .tipoCompra = tipoCompra ' TIPO_COMPRA.COMPRA_ANTICIPADA
            'If cboRetencion.Text = "SI" Then
            '    .destino = TIPO_SITUACION.SUSPENSION_RETENCION.TIENE
            'Else
            .destino = TIPO_SITUACION.SUSPENSION_RETENCION.NO_TIENE
            'End If
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
            objDocumentoCompraDet.estadoPago = Nothing
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.tipoCompra = tipoCompra ' TIPO_COMPRA.COMPRA_ANTICIPADA
            objDocumentoCompraDet.FechaDoc = txtFecha.Value
            objDocumentoCompraDet.CuentaProvedor = "4212" ' txtCuenta.Text.Trim
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.Serie = txtSerie.Text.Trim
            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            objDocumentoCompraDet.TipoDoc = cboTipoDoc.SelectedValue
            objDocumentoCompraDet.destino = r.GetValue("gravado")
            objDocumentoCompraDet.CuentaItem = Nothing
            objDocumentoCompraDet.idItem = r.GetValue("idProducto")
            objDocumentoCompraDet.tipoExistencia = TipoRecurso.SERVICIO
            objDocumentoCompraDet.descripcionItem = r.GetValue("item")

            If r.GetValue("Action") = 2 Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.UPDATE
            ElseIf r.GetValue("Action") = 1 Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            ElseIf r.GetValue("Action") = 3 Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.DELETE
            End If

            If IsNumeric(r.GetValue("cantidad")) Then
                If CDec(r.GetValue("cantidad")) > 0 Then
                    objDocumentoCompraDet.monto1 = CDec(r.GetValue("cantidad")) ' cantidad
                Else
                    If MessageBoxAdv.Show("Desea ingresar el item con cantidad cero?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        objDocumentoCompraDet.monto1 = 0
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
            objDocumentoCompraDet.montoIgv = CDec(r.GetValue("ivamn"))
            objDocumentoCompraDet.otrosTributos = 0 ' CDec(i.Cells(15).Value())
            '**********************************************************************************
            objDocumentoCompraDet.montokardexUS = CDec(r.GetValue("vcme"))
            objDocumentoCompraDet.montoIscUS = 0
            objDocumentoCompraDet.montoIgvUS = CDec(r.GetValue("ivame"))
            objDocumentoCompraDet.otrosTributosUS = 0
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
        lblEstado.Text = "compra registrada!"

        Dispose()
    End Sub

    Function GetSaldoEF() As GFichaUsuario
        Dim EFSA As New EstadosFinancierosSA
        Dim EF As New estadosFinancieros
        Dim gficha As New GFichaUsuario

        EF = EFSA.GetEstadoSaldoEF(New estadosFinancieros With {.idestado = cboDepositoHijo.SelectedValue})
        gficha.SaldoMN = EF.importeBalanceMN
        gficha.SaldoME = EF.importeBalanceME
        Return gficha

    End Function

    Sub Grabar()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()

        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad
        Dim FichaEFSaldo As New GFichaUsuario
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
            .tipoDoc = cboTipoDoc.SelectedValue
            .fechaProceso = txtFecha.Value
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "104"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            '.TipoConfiguracion = GConfiguracion.TipoConfiguracion
            '.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .idPadre = Nothing
            .codigoLibro = "8"
            .tipoDoc = cboTipoDoc.SelectedValue
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .fechaVcto = txtFecVcto.Value
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
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = txtGlosa.Text.Trim
            .referenciaDestino = Nothing
            .tipoCompra = tipoCompra  'TIPO_COMPRA.COMPRA_ANTICIPADA
            'If cboRetencion.Text = "SI" Then
            '    .destino = TIPO_SITUACION.SUSPENSION_RETENCION.TIENE
            'Else
            .destino = TIPO_SITUACION.SUSPENSION_RETENCION.NO_TIENE
            'End If
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
            'objDocumentoCompraDet.estadoPago = Nothing
            objDocumentoCompraDet.estadoPago = "PG" 'r.GetValue("valPago")
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.tipoCompra = tipoCompra  'TIPO_COMPRA.COMPRA_ANTICIPADA
            objDocumentoCompraDet.FechaDoc = txtFecha.Value
            objDocumentoCompraDet.CuentaProvedor = "4212" ' txtCuenta.Text.Trim
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.Serie = txtSerie.Text.Trim
            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            objDocumentoCompraDet.TipoDoc = cboTipoDoc.SelectedValue
            objDocumentoCompraDet.destino = r.GetValue("gravado")
            objDocumentoCompraDet.CuentaItem = Nothing
            objDocumentoCompraDet.idItem = r.GetValue("idProducto")
            objDocumentoCompraDet.tipoExistencia = TipoRecurso.SERVICIO
            objDocumentoCompraDet.descripcionItem = r.GetValue("item")

            If IsNumeric(r.GetValue("cantidad")) Then
                If CDec(r.GetValue("cantidad")) > 0 Then
                    objDocumentoCompraDet.monto1 = CDec(r.GetValue("cantidad")) ' cantidad
                Else
                    If MessageBoxAdv.Show("Desea ingresar el item con cantidad cero?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        objDocumentoCompraDet.monto1 = 0
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
            objDocumentoCompraDet.montoIgv = CDec(r.GetValue("ivamn"))
            objDocumentoCompraDet.otrosTributos = 0 ' CDec(i.Cells(15).Value())
            '**********************************************************************************
            objDocumentoCompraDet.montokardexUS = CDec(r.GetValue("vcme"))
            objDocumentoCompraDet.montoIscUS = 0
            objDocumentoCompraDet.montoIgvUS = CDec(r.GetValue("ivame"))
            objDocumentoCompraDet.otrosTributosUS = 0
            objDocumentoCompraDet.preEvento = Nothing  '= "00", Nothing, dgvCompra.Rows(S).Cells(23).Value())
            objDocumentoCompraDet.bonificacion = r.GetValue("valBonif")

            objDocumentoCompraDet.percepcionMN = CDec(r.GetValue("percepcionMN"))
            objDocumentoCompraDet.percepcionME = CDec(r.GetValue("percepcionME"))
            '**********************************************************************************
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvCompra.Rows(S).Cells(28).Value()), Nothing, CDate(dgvCompra.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
            objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
            ListaDetalle.Add(objDocumentoCompraDet)
        Next
        '''''
        'Dim consultaPagados = (From n In ListaDetalle
        '                      Where n.estadoPago = "Pagado").Count

        'If consultaPagados > 0 Then


        '    Dim SumaItemsPagados = (From n In ListaDetalle
        '                      Where n.estadoPago = "Pagado" _
        '                      Select n.importe).Sum

        '    If cboDepositoHijo.Text.Trim.Length > 0 Then
        '        ndocumento.documentocompra.CajaSeleccionada = cboDepositoHijo.SelectedValue
        '    Else
        '        Throw New Exception("Debe seleccionar una entidad financiera válida!")
        '    End If

        '    'obteniendo saldo  de la entidad financiera seleccionada
        '    FichaEFSaldo = GetSaldoEF()


        '    If SumaItemsPagados > FichaEFSaldo.SaldoMN Then
        '        Throw New Exception("El importe compra execede al monto de la cuenta financiera actual!")
        '    End If

        ndocumento.ListaCustomDocumento = ListaDocumentoCaja()


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

        ''''''''''''
        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        Dim xcod As Integer = CompraSA.SaveRegistroCompraAnticipada(ndocumento)
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
    End Sub

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
                objCaja.glosa = "Por ventas directa " & "nro. " & "-" & txtNumero.Text & " fecha: " & txtFecha.Value
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
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = "4212"
        nMovimiento.descripcion = txtProveedor.Text
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

    End Sub

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = Nothing ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Anticipada
        nAsiento.periodo = lblPerido.Text
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

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


    '''
    Private Sub AsientoItemPagado()
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim cajaSa As New EstadosFinancierosSA
        Try
            nAsiento = New asiento
            nAsiento.idDocumento = 0
            nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
            nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
            nAsiento.idEntidad = CInt(txtProveedor.Tag)
            nAsiento.nombreEntidad = txtProveedor.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            nAsiento.fechaProceso = txtFecha.Value
            nAsiento.codigoLibro = "8"
            nAsiento.periodo = lblPerido.Text
            nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
            nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_Anticipada
            nAsiento.importeMN = TotalesXcanbeceras.TotalMN
            nAsiento.importeME = TotalesXcanbeceras.TotalME
            nAsiento.glosa = txtGlosa.Text.Trim
            nAsiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.fechaActualizacion = DateTime.Now

            For Each r As Record In dgvCompra.Table.Records
                nMovimiento = New movimiento
                nMovimiento.cuenta = "4212"
                nMovimiento.descripcion = r.GetValue("item")
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
                nMovimiento.monto = r.GetValue("totalmn")
                nMovimiento.montoUSD = r.GetValue("totalme")
                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nAsiento.movimiento.Add(nMovimiento)

                nMovimiento = New movimiento
                nMovimiento.cuenta = cajaSa.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta
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

    'Public Sub CargarListaGasto()
    '    Dim cuentaSA As New mascaraGastosEmpresaSA
    '    Try
    '        lsvServicios.Columns.Clear()
    '        lsvServicios.Items.Clear()
    '        lsvServicios.Columns.Add("Cuenta", 75)
    '        lsvServicios.Columns.Add("Descripcion", 318)
    '        '  lsvServicios.Columns.Add("Cuenta Padre", 0)
    '        For Each i As mascaraGastosEmpresa In cuentaSA.ListarCuentasServiciosPublicos(Gempresas.IdEmpresaRuc)
    '            Dim n As New ListViewItem(i.cuentaCompra)
    '            n.SubItems.Add(i.descripcionCompra)
    '            lsvServicios.Items.Add(n)
    '        Next
    '    Catch ex As Exception
    '        lblEstado.Text = ("Error al cargar datos. " & vbCrLf & ex.Message)
    '        Timer1.Enabled = True
    '        PanelError.Visible = True
    '        TiempoEjecutar(10)
    '    End Try
    'End Sub

    Sub ConfiguracionInicio()
        TotalesXcanbeceras = New TotalesXcanbecera()
        'CargarListaGasto()
        'configurando docking manager
        'dockingManager1.DockControlInAutoHideMode(PanelServicios, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 356)
        'Me.DockingClientPanel1.AutoScroll = True
        'Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        'dockingManager1.SetDockLabel(PanelServicios, "Servicios")
        'dockingManager1.CloseEnabled = False
        'dockingManager1.SetDockVisibility(PanelServicios, False)

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
        txtGlosa.Text = "Por la compra según " & ""
        txtIva.DoubleValue = TmpIGV / 100
        '   lblPerido.Text = PeriodoGeneral

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
        dt.Columns.Add("estadoPag", GetType(String))
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

        Dim Comprobantes = (From n In listatabla _
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
                txtProveedor.Text = .nombreCompleto
                txtProveedor.Tag = .idEntidad
                '   txtCuenta.Text = .cuentaAsiento
                txtRuc.Text = .nrodoc
                txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End With
        Else
            txtProveedor.Clear()
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

#End Region

    Private Sub frmCompraAnticipada_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCompraAnticipada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ggcStyle2 As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns(1).Appearance.AnyRecordFieldCell
        ggcStyle2.CellType = "ComboBox"
        ggcStyle2.DataSource = Me.GetTableAsientos
        ggcStyle2.ValueMember = "id"
        ggcStyle2.DisplayMember = "name"
        ggcStyle2.DropDownStyle = GridDropDownStyle.Exclusive
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
                End If
                txtNumero.Select()

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As EventArgs) Handles txtSerie.LostFocus
        Try
            If txtSerie.Text.Trim.Length > 0 Then
                '  If chFormato.Checked = True Then
                txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                'End If
            End If

        Catch ex As Exception

            If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerie.Text), 2, 1)) = True Then

                If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1)) = True Then

                    If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1)) = True Then

                        If Len(txtSerie.Text) <= 2 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1))

                        ElseIf Len(txtSerie.Text) <= 3 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 2))

                        ElseIf Len(txtSerie.Text) <= 4 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 3))

                        ElseIf Len(txtSerie.Text) <= 5 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 4))

                        End If
                    End If
                Else

                    txtSerie.Select()
                    txtSerie.Focus()
                    txtSerie.Clear()
                    lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                End If

            Else

                txtSerie.Select()
                txtSerie.Focus()
                txtSerie.Clear()
                lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If

        End Try

        If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
            txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
        End If
    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
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
        Try
            If txtNumero.Text.Trim.Length > 0 Then
                '    If chFormato.Checked = True Then
                txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))

                'End If
            End If
        Catch ex As Exception
            'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
            txtNumero.Select()
            txtNumero.Focus()
            txtNumero.Clear()
            lblEstado.Text = "Error de formato verifiuqe el ingreso!"
        End Try

        If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
            txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
        End If
    End Sub

    Public Function GetTableAsientos() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("id", GetType(String))
        dt.Columns.Add("name", GetType(String))

        Dim dr As DataRow = dt.NewRow()
        dr(0) = "1"
        dr(1) = "GRAVADO"
        dt.Rows.Add(dr)

        Dim dr1 As DataRow = dt.NewRow()
        dr1(0) = "2"
        dr1(1) = "EXONERADO"
        dt.Rows.Add(dr1)

        Return dt

    End Function

    'Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs)
    '    'Me.Cursor = Cursors.WaitCursor
    '    'If e.KeyCode = Keys.Enter Then
    '    '    e.SuppressKeyPress = True
    '    '    If txtRuc.Text.Trim.Length > 0 Then

    '    '        UbicarEntidadPorRuc(txtRuc.Text.Trim)
    '    '        'End If
    '    '        If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
    '    '            txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
    '    '        End If
    '    '    End If
    '    'End If
    '    'Me.Cursor = Cursors.Arrow
    '    Me.Cursor = Cursors.WaitCursor
    '    If e.KeyCode = Keys.Enter Then
    '        e.SuppressKeyPress = True
    '        If txtRuc.Text.Trim.Length > 0 Then
    '            'If VAL_RUC(txtRuc.Text) = False Then
    '            '    MessageBoxAdv.Show("RUC NO VALIDO", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            'Else
    '            '    MessageBoxAdv.Show("OK", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            UbicarEntidadPorRuc(txtRuc.Text.Trim)
    '            'End If

    '        End If
    '    End If
    '    Me.Cursor = Cursors.Arrow

    'End Sub

    'Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs)
    '    If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.[End] Then
    '    Else
    '        Me.popupControlContainer1.Font = New Font("Segoe UI", 8)
    '        Me.popupControlContainer1.Size = New Size(241, 110)
    '        Me.popupControlContainer1.ParentControl = Me.txtProveedor
    '        Me.popupControlContainer1.ShowPopup(Point.Empty)

    '        Dim con = (ListadoProveedores.Where(Function(s) s.nombreCompleto.StartsWith(txtProveedor.Text))).ToList()

    '        lsvProveedor.DataSource = con
    '        lsvProveedor.DisplayMember = "nombreCompleto"
    '        lsvProveedor.ValueMember = "idEntidad"
    '    End If
    '    If e.KeyCode = Keys.Down Then
    '        Me.popupControlContainer1.Font = New Font("Segoe UI", 8)
    '        Me.popupControlContainer1.Size = New Size(241, 110)
    '        Me.popupControlContainer1.ParentControl = Me.txtProveedor
    '        Me.popupControlContainer1.ShowPopup(Point.Empty)
    '        txtProveedor.Focus()
    '    End If

    '    If e.KeyCode = Keys.Escape Then
    '        If Me.popupControlContainer1.IsShowing() Then
    '            Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
    '        End If
    '    End If
    'End Sub

    Private Sub lsvServicios_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA
        Dim entidadSA As New entidadSA
        Dim cajaSA As New EstadosFinancierosSA
        'If lsvServicios.SelectedItems.Count > 0 Then

        '    Me.dgvCompra.Table.AddNewRecord.SetCurrent()
        '    Me.dgvCompra.Table.AddNewRecord.BeginEdit()
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", 1)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", lsvServicios.SelectedItems(0).SubItems(0).Text)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("item", lsvServicios.SelectedItems(0).SubItems(1).Text)
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

        'End If
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

    Private Sub dgvCompra_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCompra.QueryCellStyleInfo
        If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "chPago" Then
            e.Style.CellType = "CheckBox"
            e.Style.CellValueType = GetType(Boolean)
            '   e.Style.CellValue = CheckBoxValue
            e.Style.[ReadOnly] = False
            e.Style.CellAppearance = GridCellAppearance.Raised
            e.Style.Enabled = True
            e.Style.Description = e.Style.CellValue.ToString()
        End If

        'Try
        '    If e.TableCellIdentity.RowIndex > -1 Then
        '        If e.TableCellIdentity.Column IsNot Nothing Then
        '            Dim str = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 16).CellValue
        '            If Not IsNothing(str) Then
        '                If str = "3" Then
        '                    e.Style.BackColor = Color.FromArgb(255, 192, 192)
        '                End If
        '            End If
        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
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

        'e.Handled = True
        'If Not IsNothing(e.TableCellIdentity.Column) Then
        '    Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

        '    If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "gravado")) Then

        '        Dim str = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue
        '        Select Case str
        '            Case "GS"
        '                e.Style.[ReadOnly] = False
        '                e.Style.BackColor = Color.AliceBlue
        '                '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
        '            Case Else
        '                e.Style.[ReadOnly] = True
        '                e.Style.BackColor = Color.AliceBlue
        '        End Select
        '    End If
        'End If
    End Sub

    Private Sub dgvCompra_SaveCellText(sender As Object, e As GridCellTextEventArgs) Handles dgvCompra.SaveCellText
        Dim style As GridTableCellStyleInfo = DirectCast(e.Style, GridTableCellStyleInfo)
        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
            '  Me.CheckBoxValue = Boolean.Parse(e.Text)
            e.Handled = True
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
        Dim style As GridTableCellStyleInfo = DirectCast(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
        Dim el As Element = Me.dgvCompra.Table.GetInnerMostCurrentElement()

        Dim colindexVal As Integer = style.CellIdentity.ColIndex

        Dim RowIndex2 As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        If RowIndex2 > -1 Then
            Select Case colindexVal
                Case 17

                    'If IsNothing(GFichaUsuarios) Then
                    '    lblEstado.Text = "Debe iniciar una caja, antes de realizar esta operación.!"
                    '    PanelError.Visible = True
                    '    Timer1.Enabled = True
                    '    TiempoEjecutar(10)
                    '    'Me.dgvCompra.TableModel(e.Inner.RowIndex, 16).CellValue = False
                    '    Exit Sub
                    'Else
                    If style.Enabled Then
                        Dim column As Integer = Me.dgvCompra.TableModel.NameToColIndex("chPago")
                        ' Console.WriteLine("CheckBoxClicked")
                        '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
                        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
                            chk = CBool(Me.dgvCompra.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

                            e.TableControl.BeginUpdate()

                            e.TableControl.EndUpdate(True)
                        End If
                        If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "chPago" Then
                            Dim currentRecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            Dim curStatus As Boolean = Boolean.Parse(style.Text)
                            e.TableControl.BeginUpdate()

                            If curStatus Then
                                '   CheckBoxValue = False
                            End If
                            If curStatus = True Then
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex

                                Me.dgvCompra.TableModel(RowIndex, 18).CellValue = "No Pagado"

                            Else
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex

                                Me.dgvCompra.TableModel(RowIndex, 18).CellValue = "Pagado"



                            End If
                            e.TableControl.EndUpdate()
                            If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
                            ElseIf Not ht.Contains(curStatus) Then
                            End If
                            ht.Clear()
                        End If
                    End If
                    'End If


            End Select

            Me.dgvCompra.TableControl.Refresh()
            TotalTalesXcolumna()
        End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellChanged
        Dim cc As GridCurrentCell = Me.dgvCompra.TableControl.CurrentCell
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
                    'If Me.dgvCompra.Table.CurrentRecord.GetValue("gravado") = "1" Or Me.dgvCompra.Table.CurrentRecord.GetValue("gravado") = "2" Then

                    Calculos()

                    'Else
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", "1")
                    'Calculos()
                    'End If
            End Select
        End If
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

                    UpdateServicioPublico()
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

    Private chk As Boolean, check As Boolean = False
    Private ht As New ArrayList()


    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        cargarCtasFinan()
        Me.Cursor = Cursors.Arrow
    End Sub

    'Private Sub cboDepositoHijo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepositoHijo.SelectedIndexChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim value As Object = Me.cboDepositoHijo.SelectedValue

    '    If IsNumeric(value) Then
    '        cargarDatosCuenta(CInt(value))
    '    Else
    '        'txtFondoEF.DecimalValue = 0
    '    End If
    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Private Sub txtTipoCambio_TextChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.TextChanged
        If IsNumeric(txtTipoCambio.Text) Then
            If txtTipoCambio.Text > 0 Then

                TipoCambio()
            End If


        End If
    End Sub

    Private Sub lsvServicios_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        AddRowDefault432()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        AddRowDefault()
    End Sub

    Private Sub tb19_Click(sender As Object, e As EventArgs) Handles tb19.Click

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

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo proveedor"
        f.strTipo = TIPO_ENTIDAD.PROVEEDOR
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.tipoPersona(TIPO_ENTIDAD.PROVEEDOR)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, entidad)
            txtProveedor.Text = c.nombreCompleto
            txtProveedor.Tag = c.idEntidad
            txtRuc.Text = c.nrodoc
            txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo proveedor"
        f.strTipo = TIPO_ENTIDAD.PROVEEDOR
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.tipoPersona(TIPO_ENTIDAD.PROVEEDOR)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, entidad)
            'ListadoProveedores.Add(c)
            txtProveedor.Text = c.nombreCompleto
            txtProveedor.Tag = c.idEntidad
            txtRuc.Text = c.nrodoc
            txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
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

            With frmCajasXusuarioCompras
                .DigitalGauge2.Value = DigitalGauge2.Value
                .txtFecha.Value = txtFecha.Value
                .txtTipoDoc.Text = cboTipoDoc.Text
                .txtSerie.Text = txtSerie.Text
                .txtNumero.Text = txtSerie.Text
                .txtCliente.Text = txtProveedor.Text
                .txtCliente.Tag = txtProveedor.Tag
                .txtRuc.Text = txtRuc.Text
                .tipoVenta = TIPO_COMPRA.COMPRA_ANTICIPADA_RECIBIDA
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

    Private Sub txtNumero_TextChanged(sender As Object, e As EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub frmCompraAnticipada_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.F7 Then


                'If txtProveedor.Text.Length > 0 Then
                '    If txtProveedor.ForeColor = Color.Black Then
                '        MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '        txtProveedor.Select()
                '        Me.Cursor = Cursors.Arrow
                '        Exit Sub
                '    End If
                'End If

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
                    .txtTipoDoc.Text = cboTipoDoc.Text
                    .txtSerie.Text = txtSerie.Text
                    .txtNumero.Text = txtSerie.Text
                    .txtCliente.Text = txtProveedor.Text
                    .txtCliente.Tag = txtProveedor.Tag
                    .txtRuc.Text = txtRuc.Text
                    .tipoVenta = TIPO_COMPRA.COMPRA_ANTICIPADA_RECIBIDA
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
End Class