Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormConfirmaVenta
    Public Property ListaBeneficios As List(Of Business.Entity.beneficio)
    Public ListaEstadosFinancieros As List(Of estadosFinancieros)
    Dim entidadSA As New entidadSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of entidad))
    Public Property listaClientes As List(Of entidad)
    Public Property TipoVentaGeneral As String
    Public Property GridVenta As GridGroupingControl
    Public TotalesXcanbeceras As TotalesXcanbecera
    Public Property formventa As FormVentaGeneral

    Public Sub New(Grid As GridGroupingControl, Totales As TotalesXcanbecera, form As FormVentaGeneral)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridVenta = Grid
        formventa = form
        TotalesXcanbeceras = New TotalesXcanbecera
        TotalesXcanbeceras = Totales
        threadClientes()
        bgCombos.RunWorkerAsync()
    End Sub


    Public Sub New(Grid As GridGroupingControl, Totales As TotalesXcanbecera)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridVenta = Grid
        TotalesXcanbeceras = New TotalesXcanbecera
        TotalesXcanbeceras = Totales
        threadClientes()
        bgCombos.RunWorkerAsync()
    End Sub
    Public Sub Loadcontroles()
        'cbotipoDocPago.DataSource = ListaComprobantesCaja 'tablaDetalleSA.GetListaTablaDetalle(10, "1")
        'cbotipoDocPago.ValueMember = "codigoDetalle"
        'cbotipoDocPago.DisplayMember = "descripcion"
        If ListaEstadosFinancieros.Count > 0 Then
            cbocajaPago.DataSource = ListaEstadosFinancieros ' cajaSA.GetCuentasFinancierasByEmpresa(Gempresas.IdEmpresaRuc, "EF")
            cbocajaPago.ValueMember = "idestado"
            cbocajaPago.DisplayMember = "descripcion"
        End If


    End Sub

#Region "Methods"
    Sub CalculosMontos()
        txtTotalBase.DecimalValue = txtTotalBase.DecimalValue
        txtTotalBase2.DecimalValue = txtTotalBase2.DecimalValue
        txtTotalBase3.DecimalValue = txtTotalBase3.DecimalValue
        txtTotalIva.DecimalValue = txtTotalIva.DecimalValue
        TextTotalDescuentos.DecimalValue = TextTotalDescuentos.DecimalValue
        txtTotalPagar.DecimalValue = txtTotalPagar.DecimalValue
    End Sub

    Public Sub GetDocsVenta()
        cboTipoDoc.Items.Clear()
        cboTipoDoc.Items.Add("NOTA DE VENTA")
        cboTipoDoc.Items.Add("BOLETA")
        cboTipoDoc.Items.Add("FACTURA")
        cboTipoDoc.Items.Add("FACTURA ELECTRONICA")
        cboTipoDoc.Items.Add("BOLETA ELECTRONICA")
        cboTipoDoc.Text = "NOTA DE VENTA"
    End Sub

    Public Sub GetDocProforma()
        cboTipoDoc.Items.Clear()
        cboTipoDoc.Items.Add("PROFORMA")
        cboTipoDoc.Text = "PROFORMA"
    End Sub

    'Public Class TotalesXcanbecera
    '    '   Private base_mn, base_me, igv_mn, igv_me, total_mn, total_me As Decimal?

    '    Public Property BaseMN() As Decimal
    '    Public Property BaseME() As Decimal

    '    Public Property BaseMN2() As Decimal
    '    Public Property BaseME2() As Decimal

    '    Public Property BaseMN3() As Decimal
    '    Public Property BaseME3() As Decimal

    '    Public Property IgvMN() As Decimal
    '    Public Property IgvME() As Decimal
    '    Public Property TotalMN() As Decimal
    '    Public Property TotalME() As Decimal

    '    Public Property base1() As Decimal
    '    Public Property base1me() As Decimal
    '    Public Property base2() As Decimal
    '    Public Property base2me() As Decimal
    '    Public Property MontoIgv1() As Decimal
    '    Public Property MontoIgv1me() As Decimal
    '    Public Property MontoIgv2() As Decimal
    '    Public Property MontoIgv2me() As Decimal

    '    Public Property PercepcionMN() As Decimal
    '    Public Property PercepcionME() As Decimal

    '    Public Sub New()
    '        BaseMN = 0
    '        BaseME = 0
    '        BaseMN2 = 0
    '        BaseME2 = 0
    '        BaseMN3 = 0
    '        BaseME3 = 0
    '        IgvMN = 0
    '        IgvME = 0
    '        TotalMN = 0
    '        TotalME = 0
    '        base1 = 0
    '        base1me = 0
    '        base2 = 0
    '        base2me = 0
    '        MontoIgv1 = 0
    '        MontoIgv1me = 0
    '        MontoIgv2 = 0
    '        MontoIgv2me = 0
    '        PercepcionMN = 0
    '        PercepcionME = 0
    '    End Sub


    'End Class
#End Region

    Public Sub GetCombos()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajaSA As New EstadosFinancierosSA
        Dim almacenSA As New almacenSA
        Dim tablaDetalleSA As New tablaDetalleSA

        ListaEstadosFinancieros = New List(Of estadosFinancieros)

        For Each i As cajaUsuario In cajaUsuarioSA.ResumenTransaccionesXusuarioCajaPago(New cajaUsuario With {.idcajaUsuario = General.GFichaUsuarios.IdCajaUsuario, .idPersona = usuario.IDUsuario})
            ListaEstadosFinancieros.Add(New estadosFinancieros With {.idestado = i.idEntidad, .descripcion = i.NombreEntidad, .tipo = i.Tipo, .codigo = i.moneda})
        Next
        'Else
        '    ListaEstadosFinancieros = cajaSA.GetCuentasFinancierasByEmpresa(Gempresas.IdEmpresaRuc, "EF")
        'End If

    End Sub

    Dim thread As System.Threading.Thread
    Private Sub threadClientes()
        Dim tipo = General.TIPO_ENTIDAD.CLIENTE
        Dim empresa = General.Gempresas.IdEmpresaRuc
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(tipo, empresa)))
        thread.Start()
    End Sub

    Private Sub GetClientes(tipo As String, empresa As String)
        Dim lista As New List(Of entidad)
        lista = New List(Of entidad)
        Dim varios = entidadSA.UbicarEntidadVarios("VR", General.Gempresas.IdEmpresaRuc, String.Empty, GEstableciento.IdEstablecimiento)
        'Dim lista = entidadSA.ObtenerListaEntidad(tipo, empresa)
        lista.Add(varios)
        lista.AddRange(entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = tipo, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}))
        setDataSource(lista)
    End Sub

    Private Sub setDataSource(ByVal lista As List(Of entidad))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {lista})
        Else
            listaClientes = New List(Of entidad)
            listaClientes = lista
            ProgressBar1.Visible = False
        End If
    End Sub

    Private Sub bgCombos_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgCombos.DoWork
        If bgCombos.CancellationPending Then
            ' MessageBox.Show("Up to here? ...")
            e.Cancel = True
        Else
            GetCombos()
        End If
    End Sub

    Private Sub bgCombos_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgCombos.RunWorkerCompleted
        If e.Cancelled Then

        Else
            Loadcontroles()
        End If
    End Sub

    Private Sub cboTipoDoc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedValueChanged
        If cboTipoDoc.Text.Trim.Length > 0 Then
            Select Case cboTipoDoc.Text
                Case "BOLETA"

                    chAutoNumeracion.Enabled = True
                    If chAutoNumeracion.Checked = True Then
                        txtNumero.Clear()
                        txtSerie.Visible = False
                        txtSerie.ReadOnly = True
                        txtNumero.Visible = False
                        txtNumero.ReadOnly = True

                        ProgressBar2.Visible = True
                        ProgressBar2.Style = ProgressBarStyle.Marquee
                        BackgroundWorker1.RunWorkerAsync()
                    Else
                        txtNumero.Clear()
                        txtSerie.Visible = True
                        txtSerie.ReadOnly = False
                        txtNumero.Visible = True
                        txtNumero.ReadOnly = False
                    End If
                Case "FACTURA"

                    chAutoNumeracion.Enabled = True
                    If chAutoNumeracion.Checked = True Then
                        txtNumero.Clear()
                        txtSerie.Visible = False
                        txtSerie.ReadOnly = True
                        txtNumero.Visible = False
                        txtNumero.ReadOnly = True

                        ProgressBar2.Visible = True
                        ProgressBar2.Style = ProgressBarStyle.Marquee
                        BackgroundWorker1.RunWorkerAsync()
                    Else
                        txtNumero.Clear()
                        txtSerie.Visible = True
                        txtSerie.ReadOnly = False
                        txtNumero.Visible = True
                        txtNumero.ReadOnly = False
                    End If
                Case "NOTA DE VENTA"

                    chAutoNumeracion.Checked = False
                    chAutoNumeracion.Enabled = False
                    txtSerie.Visible = False
                    txtNumero.Visible = False
                    txtSerie.ReadOnly = False

                Case "BOLETA ELECTRONICA"

                    chAutoNumeracion.Enabled = True
                    chAutoNumeracion.Checked = True

                    'txtSerie.Visible = True
                    'txtSerie.Text = "B001"
                    'txtSerie.ReadOnly = True
                    'txtNumero.Visible = True
                    'txtNumero.ReadOnly = True
                    txtNumero.Clear()
                    txtSerie.Visible = False
                    txtSerie.ReadOnly = True
                    txtNumero.Visible = False
                    txtNumero.ReadOnly = True

                    ProgressBar2.Visible = True
                    ProgressBar2.Style = ProgressBarStyle.Marquee
                    BackgroundWorker1.RunWorkerAsync()
                Case "FACTURA ELECTRONICA"

                    chAutoNumeracion.Enabled = True
                    chAutoNumeracion.Checked = True

                    'txtSerie.Visible = True
                    'txtSerie.Text = "F001"
                    'txtSerie.ReadOnly = True
                    'txtNumero.Visible = True
                    'txtNumero.ReadOnly = True

                    txtNumero.Clear()
                    txtSerie.Visible = False
                    txtSerie.ReadOnly = True
                    txtNumero.Visible = False
                    txtNumero.ReadOnly = True


                    ProgressBar2.Visible = True
                    ProgressBar2.Style = ProgressBarStyle.Marquee
                    BackgroundWorker1.RunWorkerAsync()
                Case "PROFORMA"
                    txtNumero.Clear()
                    txtSerie.Visible = False
                    txtSerie.ReadOnly = True
                    txtNumero.Visible = False
                    txtNumero.ReadOnly = True

                    ProgressBar2.Visible = True
                    ProgressBar2.Style = ProgressBarStyle.Marquee
                    BackgroundWorker1.RunWorkerAsync()
            End Select
            'GetResetCantidades()
        End If

    End Sub

    'Dim conf As New GConfiguracionModulo
    'Private Sub GetNumeracion(strIdModulo As String, strIDEmpresa As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    conf = New GConfiguracionModulo
    '    conf = ConfigurarComprobanteVenta(moduloConfiguracion)
    '    'SetDataSourceNumeracion(moduloConfiguracion)
    'End Sub

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

    '                        If cboTipoDoc.Text = "FACTURA ELECTRONICA" Then

    '                            GConfiguracion2.TipoComprobante = "01" '.tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial


    '                        End If
    '                        If cboTipoDoc.Text = "BOLETA ELECTRONICA" Then
    '                            GConfiguracion2.TipoComprobante = "03" ' .tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial

    '                        End If

    '                        If cboTipoDoc.Text = "PROFORMA" Then
    '                            GConfiguracion2.TipoComprobante = .tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial
    '                        End If
    '                    End With
    '                Case "M"

    '            End Select

    '        End With
    '    Else
    '        '  lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        ' Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
    '    Return GConfiguracion2
    'End Function


    Public Function configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer) As GConfiguracionModulo
        Try
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)

                If cboTipoDoc.Text = "BOLETA" Then
                    GConfiguracion.TipoComprobante = "12.1" ' .tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial

                End If
                If cboTipoDoc.Text = "FACTURA" Then
                    GConfiguracion.TipoComprobante = "12.2" '.tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial

                End If

                If cboTipoDoc.Text = "FACTURA ELECTRONICA" Then

                    GConfiguracion.TipoComprobante = "01" '.tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial


                End If
                If cboTipoDoc.Text = "BOLETA ELECTRONICA" Then
                    GConfiguracion.TipoComprobante = "03" ' .tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial

                End If

                If cboTipoDoc.Text = "PROFORMA" Then
                    GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
                End If
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return GConfiguracion
    End Function

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If BackgroundWorker1.CancellationPending Then
            ' MessageBox.Show("Up to here? ...")
            e.Cancel = True
        Else
            Dim strIdModulo As String = Nothing
            If cboTipoDoc.Text = "BOLETA" Then
                strIdModulo = "VT2"
            ElseIf cboTipoDoc.Text = "FACTURA" Then
                strIdModulo = "VT3"
            ElseIf cboTipoDoc.Text = "BOLETA ELECTRONICA" Then
                strIdModulo = "VT2E"
            ElseIf cboTipoDoc.Text = "FACTURA ELECTRONICA" Then
                strIdModulo = "VT3E"
            ElseIf cboTipoDoc.Text = "PROFORMA" Then
                strIdModulo = "COTIZACION"
            End If
            Dim strIDEmpresa = General.Gempresas.IdEmpresaRuc
            configuracionModuloV2(strIDEmpresa, strIdModulo, "", GEstableciento.IdEstablecimiento)
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Cancelled Then

        Else
            'Select Case cboTipoDoc.Text
            '    Case "FACTURA ELECTRONICA", "BOLETA ELECTRONICA"
            '        txtSerie.Text = conf.Serie
            '        txtNumero.Text = conf.ValorActual + 1

            '        ProgressBar2.Visible = False
            '    Case Else
            txtSerie.Text = GConfiguracion.Serie
            ProgressBar2.Visible = False

            'End Select

        End If
    End Sub

    Private Function ValidacionDeMontoTotalConDetalle() As Boolean
        ValidacionDeMontoTotalConDetalle = False

        Dim totalDetalle As Decimal = txtTotalBase.DecimalValue + txtTotalBase2.DecimalValue + txtTotalBase3.DecimalValue + txtTotalIva.DecimalValue

        Dim totalDoc As Decimal = txtTotalPagar.DecimalValue

        If totalDoc = totalDetalle Then
            ValidacionDeMontoTotalConDetalle = True
        End If

    End Function

    Dim objPleaseWait As New FeedbackForm()
    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Try
            If ValidarGrabado() = True Then
                ' If ValidacionDeMontoTotalConDetalle() = True Then
                objPleaseWait = New FeedbackForm()
                objPleaseWait.StartPosition = FormStartPosition.CenterScreen
                objPleaseWait.Show()
                Select Case cboTipoDoc.Text
                    Case "BOLETA", "FACTURA"
                        TipoVentaGeneral = TIPO_VENTA.VENTA_POS_DIRECTA
                        GrabarVentaCasoEspecial(GridVenta)

                    Case "FACTURA ELECTRONICA", "BOLETA ELECTRONICA"
                        TipoVentaGeneral = TIPO_VENTA.VENTA_ELECTRONICA
                        GrabarVentaCasoEspecial(GridVenta)

                    Case "NOTA DE VENTA"
                        GrabarNotaDeVenta(GridVenta)
                    Case "PROFORMA"
                        GrabarProforma(GridVenta)
                End Select
                'Else
                '    MessageBox.Show("Los importes no coinciden, el detalle, con el total de la venta ", "Verificar importes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End If
            End If
        Catch ex As Exception
            objPleaseWait.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0

        Select Case cboTipoDoc.Text

            Case "BOLETA", "FACTURA"
                If TXTcOMPRADOR.Text.Trim.Length = 0 Then
                    ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un cliente")
                    listaErrores += 1
                Else
                    ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
                End If

                If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                    ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
                Else
                    ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un cliente válido")
                    listaErrores += 1
                End If

                If chAutoNumeracion.Checked = False Then
                    If txtSerie.Text.Trim.Length = 0 Then
                        ErrorProvider1.SetError(txtSerie, "El campo serie es obligatorio")
                        listaErrores += 1
                    Else
                        ErrorProvider1.SetError(txtSerie, Nothing)
                    End If

                    If txtNumero.Text.Trim.Length = 0 Then
                        ErrorProvider1.SetError(txtNumero, "El campo número es obligatorio")
                        listaErrores += 1
                    Else
                        ErrorProvider1.SetError(txtNumero, Nothing)
                    End If
                End If
            Case "NOTA DE VENTA"
                'If TXTcOMPRADOR.Text.Trim.Length = 0 Then
                '    ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un cliente")
                '    listaErrores += 1
                'Else
                '    ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
                'End If

                'If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                '    ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
                'Else
                '    ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un cliente válido")
                '    listaErrores += 1
                'End If



            Case "BOLETA ELECTRONICA"

                If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                    ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
                Else
                    ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un cliente válido")
                    listaErrores += 1
                End If

            '    If txtTipoDocClie.Text = "6" Then
            '        ErrorProvider1.SetError(TXTcOMPRADOR, "Debe ingresar Cliente DNI/Otros")
            '        listaErrores += 1
            '    Else
            '        ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
            '    End If

            Case "FACTURA ELECTRONICA"

                If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                    ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
                Else
                    ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un cliente válido")
                    listaErrores += 1
                End If

                If txtTipoDocClie.Text = "1" Or txtTipoDocClie.Text = "0" Then
                    ErrorProvider1.SetError(TXTcOMPRADOR, "Debe ingresar Cliente RUC")
                    listaErrores += 1
                Else
                    ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
                End If
        End Select


        If txtTotalPagar.DecimalValue <= 0 Then
            ErrorProvider1.SetError(txtTotalPagar, "La venta debe ser mayor a cero")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtTotalPagar, Nothing)
        End If

        If listaErrores > 0 Then
            ValidarGrabado = False
        Else
            ValidarGrabado = True
        End If
    End Function

    Sub GrabarProforma(dgvCompra As GridGroupingControl)
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim docVentaSA As New documentoVentaAbarrotesSA

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
        Dim proveedor As String
        Dim idProveedor As Integer

        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()
        proveedor = TXTcOMPRADOR.Text
        idProveedor = CInt(TXTcOMPRADOR.Tag)

        '-------------------------------------------------------------------------------------
        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            ndocumento.idProyecto = GProyectos.IdProyectoActividad
        End If
        ndocumento.tipoDoc = GConfiguracion.TipoComprobante
        ndocumento.fechaProceso = txtFecha.Value
        ndocumento.nroDoc = GConfiguracion.Serie
        ndocumento.idOrden = Nothing ' Me.IdOrden
        ndocumento.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
        ndocumento.idEntidad = Val(idProveedor)
        ndocumento.entidad = proveedor
        ndocumento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        ndocumento.nrodocEntidad = txtruc.Text
        ndocumento.tipoOperacion = StatusTipoOperacion.VENTA
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now

        nDocumentoVenta = New documentoventaAbarrotes With {
            .IdDocumentoCotizacion = False,
                 .TipoConfiguracion = If(GConfiguracion Is Nothing, Nothing, GConfiguracion.TipoConfiguracion),
                  .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
                  .tipoOperacion = "01",
                  .codigoLibro = "14",
                  .tipoDocumento = GConfiguracion.TipoComprobante,
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                  .fechaDoc = txtFecha.Value,
                  .fechaPeriodo = GetPeriodo(txtFecha.Value, True),' lblPerido.Text,
                  .serie = GConfiguracion.Serie,
                  .numeroDocNormal = Nothing,
                  .idCliente = idProveedor,
                  .nombrePedido = proveedor,
                  .moneda = If(cboMoneda.Text = "NACIONAL", "1", "2"),
                  .tasaIgv = TmpIGV,
                  .tipoCambio = TmpTipoCambio,
                  .bi01 = TotalesXcanbeceras.base1,
                  .bi02 = TotalesXcanbeceras.base2,
                  .igv01 = TotalesXcanbeceras.MontoIgv1,
                  .igv02 = TotalesXcanbeceras.MontoIgv2,
                  .bi01us = TotalesXcanbeceras.base1me,
                  .bi02us = TotalesXcanbeceras.base2me,
                  .igv01us = TotalesXcanbeceras.MontoIgv1me,
                  .igv02us = TotalesXcanbeceras.MontoIgv2me,
                  .ImporteNacional = TotalesXcanbeceras.TotalMN,
                  .ImporteExtranjero = TotalesXcanbeceras.TotalME,
                  .tipoVenta = TIPO_VENTA.COTIZACION,
                  .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
                  .glosa = "Por cotizacion de venta",
                  .usuarioActualizacion = usuario.IDUsuario,
                  .fechaActualizacion = DateTime.Now}
        ndocumento.documentoventaAbarrotes = nDocumentoVenta


        'REGISTRANDO LA GUIA DE REMISION
        'GuiaRemision(ndocumento)

        For Each r As Record In dgvCompra.Table.Records
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            'Select Case r.GetValue("valPago")
            '    Case "Pagado"
            '        objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
            '    Case Else
            '        objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            'End Select
            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = txtFecha.Value
            objDocumentoVentaDet.Serie = GConfiguracion.Serie
            objDocumentoVentaDet.NumDoc = Nothing
            objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
            If r.GetValue("tipoExistencia") = "GS" Then
                objDocumentoVentaDet.idAlmacenOrigen = Nothing
                objDocumentoVentaDet.tipoVenta = Nothing
            Else
                objDocumentoVentaDet.idAlmacenOrigen = CInt(r.GetValue("almacen"))
                objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            End If
            objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = Nothing
            objDocumentoVentaDet.idItem = r.GetValue("idProducto")
            objDocumentoVentaDet.DetalleItem = r.GetValue("item")
            objDocumentoVentaDet.tipoExistencia = r.GetValue("tipoExistencia")
            objDocumentoVentaDet.destino = r.GetValue("gravado")
            objDocumentoVentaDet.unidad1 = r.GetValue("um")
            If CDec(r.GetValue("cantidad")) <= 0 Then
                MessageBox.Show("Debe ingresar un cantidad mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Exit Sub
            End If

            If CDec(r.GetValue("totalmn")) <= 0 Then
                MessageBox.Show("El importe de venta debe ser mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Exit Sub
            End If

            objDocumentoVentaDet.monto1 = CDec(r.GetValue("cantidad"))
            objDocumentoVentaDet.unidad2 = Nothing
            objDocumentoVentaDet.monto2 = Nothing 'i.Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoVentaDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            objDocumentoVentaDet.importeMN = CDec(r.GetValue("totalmn"))
            objDocumentoVentaDet.importeME = CDec(r.GetValue("totalme"))
            objDocumentoVentaDet.descuentoMN = 0
            objDocumentoVentaDet.descuentoME = 0

            objDocumentoVentaDet.montokardex = CDec(r.GetValue("vcmn"))
            objDocumentoVentaDet.montoIsc = 0
            objDocumentoVentaDet.montoIgv = CDec(r.GetValue("igvmn"))
            objDocumentoVentaDet.otrosTributos = 0
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = CDec(r.GetValue("vcme"))
            objDocumentoVentaDet.montoIscUS = 0
            objDocumentoVentaDet.montoIgvUS = CDec(r.GetValue("igvme"))
            objDocumentoVentaDet.otrosTributosUS = 0
            '  objDocumentoVentaDet.PreEvento = i.Cells(25).Value()
            objDocumentoVentaDet.estadoMovimiento = "NO" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = 0 'CDec(r.GetValue("puKardex"))
            objDocumentoVentaDet.importeMEK = 0 'CDec(r.GetValue("pukardeme"))
            objDocumentoVentaDet.fechaVcto = Nothing
            objDocumentoVentaDet.salidaCostoMN = CDec(r.GetValue("costoMN")) ' CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value())
            objDocumentoVentaDet.salidaCostoME = CDec(r.GetValue("costoME")) 'CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value())
            objDocumentoVentaDet.categoria = Nothing
            objDocumentoVentaDet.preEvento = Nothing
            objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoVentaDet.fechaModificacion = Date.Now

            objDocumentoVentaDet.Glosa = "Por cotizacion de venta"
            ListaDetalle.Add(objDocumentoVentaDet)
        Next

        '-------------------------------------------------------------------------------------
        '---------------- VALIDACION DE IMPORTE CON DETALLE DE VENTA -------------------------
        Dim sumaVentaMN As Decimal = ListaDetalle.Sum(Function(o) o.importeMN).GetValueOrDefault
        Dim sumaVentaME As Decimal = ListaDetalle.Sum(Function(o) o.importeME).GetValueOrDefault
        Dim sumaBase1MN As Decimal =
            ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Grabado).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaBase1ME As Decimal =
            ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Grabado).Sum(Function(o) o.montokardexUS).GetValueOrDefault

        Dim sumaBase2MN As Decimal =
            ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Exonerado).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaBase2ME As Decimal =
            ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Exonerado).Sum(Function(o) o.montokardexUS).GetValueOrDefault

        Dim sumaIgvMN As Decimal = ListaDetalle.Sum(Function(o) o.montoIgv).GetValueOrDefault
        Dim sumaIgvME As Decimal = ListaDetalle.Sum(Function(o) o.montoIgvUS).GetValueOrDefault

        Dim totalVentaDetalle As Decimal = sumaBase1MN + sumaBase2MN + sumaIgvMN
        Dim totalHeader As Decimal = txtTotalPagar.DecimalValue
        If totalHeader <> totalVentaDetalle Then
            Throw New Exception("Los importes no coinciden, tanto del detalle con la cabecera ")
        End If
        '-------------------------------------------------------------------------------------
        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle
        Dim cod = VentaSA.GrabarCotizacion(ndocumento)
        MessageBox.Show("Proforma registrada", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'LimpiarControles()
        'Alert = New Alert("Proforma registrada", alertType.success)
        'Alert.TopMost = True
        'Alert.Show()

        'Dim f As New FormImpresionNuevo
        'f.DocumentoID = cod
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.Show(Me)
        VentaSA.GetActualizarImpresion(New documentoventaAbarrotes With {.idDocumento = cod})
        Dim miInterfaz As ICommitOperacion = TryCast(Me.Owner, ICommitOperacion)
        If miInterfaz IsNot Nothing Then miInterfaz.Commit(True)
        objPleaseWait.Close()
        Close()

    End Sub

    Sub GrabarVentaCasoEspecial(GRID As GridGroupingControl)
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim ListProductosVendidos As New List(Of documentoventaAbarrotesDet)
        'objPleaseWait = New FeedbackForm()
        'objPleaseWait.StartPosition = FormStartPosition.CenterScreen
        'objPleaseWait.Show()
        Application.DoEvents()

        ListProductosVendidos = New List(Of documentoventaAbarrotesDet)
        ListProductosVendidos = GetDetalleVenta(GRID)

        If ListProductosVendidos.Count = 0 Then
            objPleaseWait.Close()
            Throw New Exception("Debe ingresar artículos a la canasta de venta")
        End If

        Dim listaDocumento As New List(Of documento)

        If ListProductosVendidos.Count > 0 Then
            Dim DocComprobante =
            CType(GetGrabarVentaComprobante(ListProductosVendidos.ToList()), documento)

            listaDocumento.Add(DocComprobante)
        End If

        Dim lista = VentaSA.Grabar_VentaEspecialSinLote(listaDocumento)

        GetImpresionTicketsEspecial(lista)
        ChPagoDirecto.Checked = True
        ChPagoAvanzado.Checked = False
        PagoDirectoCheck()

        Dim miInterfaz As ICommitOperacion = TryCast(Me.Owner, ICommitOperacion)
        If miInterfaz IsNot Nothing Then miInterfaz.Commit(True)
        objPleaseWait.Close()
        ' Close()
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

    Sub GuiaRemisionGenerico(beDocumento As documento)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION

        'Dim idCliente As Integer = 0
        'Dim nomCliente As String = Nothing

        'If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
        '    idCliente = TXTcOMPRADOR.Tag
        '    nomCliente = TXTcOMPRADOR.Text
        'Else
        '    nomCliente = TXTcOMPRADOR.Text
        'End If

        With guiaRemisionBE
            .idDocumento = 0
            .codigoLibro = "14"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .periodo = GetPeriodo(txtFecha.Value, True)
            .tipoDoc = "99"
            .idEntidad = beDocumento.documentoventaAbarrotes.idCliente ' idCliente
            .monedaDoc = beDocumento.documentoventaAbarrotes.moneda '"1"
            .tasaIgv = 0 'txtIva.DoubleValue
            .tipoCambio = beDocumento.documentoventaAbarrotes.tipoCambio ' txtTipoCambio.DecimalValue
            .importeMN = beDocumento.documentoventaAbarrotes.ImporteNacional
            .importeME = beDocumento.documentoventaAbarrotes.ImporteExtranjero
            .glosa = "Guia remision por ventas"
            .estado = TipoGuia.Entregado
            .direccionPartida = "ORIGEN"
            .fechaTraslado = Date.Now
            .estado = TipoGuia.Entregado
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        beDocumento.documentoGuia = guiaRemisionBE

        For Each r In beDocumento.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList
            If r.tipoExistencia <> "GS" Then
                documentoguiaDetalle = New documentoguiaDetalle
                'sdfsdfsdf
                'beDocumento.documentoGuia.serie = GConfiguracion2.Serie
                'beDocumento.documentoGuia.numeroDoc = GConfiguracion2.Serie
                documentoguiaDetalle.idDocumento = 0
                documentoguiaDetalle.idItem = r.idItem
                documentoguiaDetalle.descripcionItem = r.DetalleItem
                documentoguiaDetalle.destino = r.destino
                documentoguiaDetalle.unidadMedida = r.unidad1
                documentoguiaDetalle.cantidad = CDec(r.monto1)

                documentoguiaDetalle.almacenRef = r.idAlmacenOrigen
                documentoguiaDetalle.nombreRecepcion = beDocumento.documentoventaAbarrotes.NombreEntidad ' nomCliente
                documentoguiaDetalle.dniRecepcion = Nothing
                documentoguiaDetalle.puntoLlegada = "ORIGEN"
                documentoguiaDetalle.estado = TipoGuiaDetalle.Entrega_Total
                documentoguiaDetalle.usuarioModificacion = usuario.IDUsuario
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
                ' End If
            End If

        Next
        beDocumento.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Private Function GetDetalleVenta(GRID As GridGroupingControl) As List(Of documentoventaAbarrotesDet)
        Dim TipoEntrega = TipoEntregado.Entregado
        Dim objDocumentoVentaDet As documentoventaAbarrotesDet
        GetDetalleVenta = New List(Of documentoventaAbarrotesDet)
        For Each r As Record In GRID.Table.Records

            If CDec(r.GetValue("cantidad")) <= 0 Then
                Throw New Exception("Debe ingresar un cantidad mayor a cero.")
            End If

            If CDec(r.GetValue("totalmn")) <= 0 Then
                Throw New Exception("El importe de venta debe ser mayor a cero.")
            End If
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            If r.GetValue("tipoExistencia") = "OF" Then
                objDocumentoVentaDet.CustomOferta_Detalle = New ventaDetalle_oferta With {
                .id_oferta = r.GetValue("codigo")
                }
            End If

            objDocumentoVentaDet.codigoLote = 0 ' Integer.Parse(r.GetValue("codigoLote"))
            If ChPagoDirecto.Checked Then
                objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
            ElseIf ChPagoAvanzado.Checked Then
                If CDec(r.GetValue("MontoSaldo")) <= 0 Then
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
                Else
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                End If
            Else
                objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            End If

            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = txtFecha.Value
            objDocumentoVentaDet.Serie = GConfiguracion.Serie
            objDocumentoVentaDet.NumDoc = GConfiguracion.Serie
            objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
            If r.GetValue("tipoExistencia") = "GS" Then
                objDocumentoVentaDet.idAlmacenOrigen = Nothing
                objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            ElseIf r.GetValue("tipoExistencia") = "OF" Then
                objDocumentoVentaDet.idAlmacenOrigen = Nothing
                objDocumentoVentaDet.tipoVenta = "F"
            Else
                objDocumentoVentaDet.idAlmacenOrigen = CInt(r.GetValue("almacen"))
                objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            End If
            objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = Nothing
            objDocumentoVentaDet.idItem = r.GetValue("idProducto")
            objDocumentoVentaDet.DetalleItem = r.GetValue("item")
            objDocumentoVentaDet.nombreItem = r.GetValue("item")
            objDocumentoVentaDet.tipoExistencia = r.GetValue("tipoExistencia")
            objDocumentoVentaDet.destino = r.GetValue("gravado")
            objDocumentoVentaDet.unidad1 = r.GetValue("um")
            objDocumentoVentaDet.monto1 = CDec(r.GetValue("cantidad"))
            objDocumentoVentaDet.unidad2 = Nothing
            objDocumentoVentaDet.monto2 = Nothing ''CDec(r.GetValue("cantidad2")) '  Nothing 'i.Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoVentaDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            objDocumentoVentaDet.importeMN = CDec(r.GetValue("totalmn"))
            objDocumentoVentaDet.importeME = CDec(r.GetValue("totalme"))
            objDocumentoVentaDet.descuentoMN = 0
            objDocumentoVentaDet.descuentoME = 0

            objDocumentoVentaDet.montokardex = CDec(r.GetValue("vcmn"))
            objDocumentoVentaDet.montoIsc = 0
            objDocumentoVentaDet.montoIgv = CDec(r.GetValue("igvmn"))
            objDocumentoVentaDet.otrosTributos = 0
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = CDec(r.GetValue("vcme"))
            objDocumentoVentaDet.montoIscUS = 0
            objDocumentoVentaDet.montoIgvUS = CDec(r.GetValue("igvme"))
            objDocumentoVentaDet.otrosTributosUS = 0
            objDocumentoVentaDet.estadoMovimiento = "V" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = 0 ' CDec(r.GetValue("puKardex"))
            objDocumentoVentaDet.importeMEK = 0 ' CDec(r.GetValue("pukardeme"))
            objDocumentoVentaDet.fechaVcto = txtFecha.Value
            objDocumentoVentaDet.estadoEntrega = TipoEntrega
            objDocumentoVentaDet.cantidadEntrega = CDec(r.GetValue("cantEntregar"))
            objDocumentoVentaDet.salidaCostoMN = CDec(r.GetValue("costoMN"))
            objDocumentoVentaDet.salidaCostoME = CDec(r.GetValue("costoME"))
            objDocumentoVentaDet.preEvento = Nothing
            objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoVentaDet.fechaModificacion = DateTime.Now
            objDocumentoVentaDet.Glosa = "Por ventas"
            objDocumentoVentaDet.NomMarca = Nothing ' r.GetValue("marca")
            GetDetalleVenta.Add(objDocumentoVentaDet)
        Next
    End Function

    Private Function GetGrabarVentaComprobante(DetalleVenta As List(Of documentoventaAbarrotesDet)) As documento
        Dim tipoDocumentoVenta As String = Nothing
        Dim serieVenta As String = Nothing
        Dim numeroVenta As String = Nothing
        Dim NroDoc As String = Nothing
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim docVentaSA As New documentoVentaAbarrotesSA

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim TipoCobro As String
        Dim proveedor As String
        Dim idProveedor As Integer

        Dim sumaVentaMN As Decimal = DetalleVenta.Sum(Function(o) o.importeMN).GetValueOrDefault
        Dim sumaVentaME As Decimal = DetalleVenta.Sum(Function(o) o.importeME).GetValueOrDefault
        Dim sumaBase1MN As Decimal =
            DetalleVenta.Where(Function(o) o.destino = OperacionGravada.Grabado).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaBase1ME As Decimal =
            DetalleVenta.Where(Function(o) o.destino = OperacionGravada.Grabado).Sum(Function(o) o.montokardexUS).GetValueOrDefault

        Dim sumaBase2MN As Decimal =
            DetalleVenta.Where(Function(o) o.destino = OperacionGravada.Exonerado).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaBase2ME As Decimal =
            DetalleVenta.Where(Function(o) o.destino = OperacionGravada.Exonerado).Sum(Function(o) o.montokardexUS).GetValueOrDefault

        Dim sumaIgvMN As Decimal = DetalleVenta.Sum(Function(o) o.montoIgv).GetValueOrDefault
        Dim sumaIgvME As Decimal = DetalleVenta.Sum(Function(o) o.montoIgvUS).GetValueOrDefault
        '-------------------------------------------------------------------------------------
        '---------------- VALIDACION DE IMPORTE CON DETALLE DE VENTA -------------------------

        Dim totalVentaDetalle As Decimal = sumaBase1MN + sumaBase2MN + sumaIgvMN
        Dim totalHeader As Decimal = txtTotalPagar.DecimalValue
        If totalHeader <> totalVentaDetalle Then
            Throw New Exception("Los importes no coinciden, tanto del detalle con la cabecera ")
        End If

        '-------------------------------------------------------------------------------------

        Select Case chAutoNumeracion.Checked
            Case True
                Select Case cboTipoDoc.Text

                    Case "FACTURA ELECTRONICA", "BOLETA ELECTRONICA"
                        'tipoDocumentoVenta = If(cboTipoDoc.Text = "BOLETA ELECTRONICA", "03", "01")
                        'serieVenta = txtSerie.Text
                        'numeroVenta = txtNumero.Text
                        'NroDoc = String.Concat(txtSerie.Text.Trim, "-", txtNumero.Text.Trim)

                        tipoDocumentoVenta = GConfiguracion.TipoComprobante
                        serieVenta = GConfiguracion.Serie
                        numeroVenta = 1
                        NroDoc = GConfiguracion.Serie

                    Case Else

                        tipoDocumentoVenta = GConfiguracion.TipoComprobante
                        serieVenta = GConfiguracion.Serie
                        numeroVenta = 1
                        NroDoc = GConfiguracion.Serie

                End Select
            Case False
                tipoDocumentoVenta = If(cboTipoDoc.Text = "BOLETA", "03", "01")
                serieVenta = txtSerie.Text.Trim
                numeroVenta = txtNumero.Text.Trim
                NroDoc = String.Concat(txtSerie.Text.Trim, "-", txtNumero.Text.Trim)
        End Select


        ndocumento = New documento
        ndocumento.Action = BaseBE.EntityAction.INSERT
        ndocumento.IsFormatoGeneral = If(chAutoNumeracion.Checked, False, True)
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        ndocumento.tipoDoc = tipoDocumentoVenta 'conf.TipoComprobante
        ndocumento.fechaProceso = txtFecha.Value
        ndocumento.nroDoc = NroDoc ' conf.Serie
        ndocumento.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            ndocumento.entidad = TXTcOMPRADOR.Text
            ndocumento.nrodocEntidad = txtruc.Text
            ndocumento.idEntidad = Val(TXTcOMPRADOR.Tag)
        Else
            ndocumento.entidad = TXTcOMPRADOR.Text
            ndocumento.nrodocEntidad = 0
            ndocumento.idEntidad = Val(0)
        End If
        ndocumento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        ndocumento.tipoOperacion = StatusTipoOperacion.VENTA
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now
        TipoCobro = TIPO_VENTA.PAGO.COBRADO
        Dim TipoEntrega = TipoEntregado.Entregado
        Dim tipoEstado = TipoGuia.Entregado

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            proveedor = TXTcOMPRADOR.Text
            idProveedor = CInt(TXTcOMPRADOR.Tag)
        Else
            proveedor = TXTcOMPRADOR.Text
            idProveedor = 0
        End If

        nDocumentoVenta = New documentoventaAbarrotes With {
            .horaVenta = txtFecha.Value.TimeOfDay.ToString(),
                  .TipoConfiguracion = If(GConfiguracion Is Nothing, Nothing, GConfiguracion.TipoConfiguracion),
                  .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
                  .tipoOperacion = StatusTipoOperacion.VENTA,
                  .codigoLibro = "14",
                  .tipoDocumento = tipoDocumentoVenta,
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                  .fechaDoc = txtFecha.Value,
                  .fechaConfirmacion = txtFecha.Value,
                  .fechaPeriodo = GetPeriodo(txtFecha.Value, True),
                  .serie = serieVenta,
                  .serieVenta = serieVenta,
                  .numeroDocNormal = Nothing,
                  .numeroVenta = numeroVenta,
                  .idCliente = CInt(idProveedor),
                  .idClientePedido = CInt(idProveedor),
                  .nombrePedido = proveedor,
                  .moneda = If(cboMoneda.Text = "NACIONAL", "1", "2"),
                  .tasaIgv = TmpIGV,
                  .tipoCambio = TmpTipoCambio,
                  .bi01 = sumaBase1MN,
                  .bi02 = sumaBase2MN,
                  .igv01 = sumaIgvMN,
                  .igv02 = 0,
                  .bi01us = sumaBase1ME,
                  .bi02us = sumaBase2ME,
                  .igv01us = sumaIgvME,
                  .igv02us = 0,
                  .ImporteNacional = sumaVentaMN,
                  .ImporteExtranjero = sumaVentaME,
                  .tipoVenta = TipoVentaGeneral, 'TIPO_VENTA.VENTA_POS_DIRECTA,
                  .estadoCobro = TipoCobro,
                  .estadoEntrega = TipoEntrega,
                  .terminos = "CONTADO",
                  .glosa = "Por ventas",
                  .fechaVcto = txtFecha.Value,
                  .estado = StatusNotaDeVentas.Sustentado,
                  .usuarioActualizacion = usuario.IDUsuario,
                  .fechaActualizacion = DateTime.Now}
        'tipoEstado,
        ndocumento.documentoventaAbarrotes = nDocumentoVenta

        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = DetalleVenta

        '--------------------------------------------------------------------------------------
        'Dim listaExistencias As List(Of documentoventaAbarrotesDet) = (From n In DetalleVenta
        '                                                               Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList
        'If listaExistencias.Count > 0 Then
        '    AsientoVenta(listaExistencias)
        'End If

        'Dim listaServicios As List(Of documentoventaAbarrotesDet) = (From n In DetalleVenta
        '                                                             Where n.tipoExistencia = TipoRecurso.SERVICIO).ToList

        'If listaServicios.Count > 0 Then
        '    AsientoVentaServicios(listaServicios)
        'End If

        GuiaRemisionGenerico(ndocumento)

        If ChPagoDirecto.Checked Then
            ndocumento.ListaCustomDocumento = ListaDocumentoCajaGenerico(ndocumento.documentoventaAbarrotes)
            ndocumento.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.COBRADO
            ndocumento.documentoventaAbarrotes.terminos = "CONTADO"
        ElseIf ChPagoAvanzado.Checked = True Then
            Dim f As New frmFormatoPagoComprobantes
            f.txtMontoXcobrar.Text = nDocumentoVenta.ImporteNacional ' txtTotalPagar.DecimalValue
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            If f.Tag IsNot Nothing Then
                Dim c = CType(f.Tag, List(Of documentoCaja))
                If c.Count > 0 Then
                    Dim ListaPagos = ListaPagosCajas(c, ndocumento.documentoventaAbarrotes, ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet)
                    Dim SumaPagos As Decimal = 0
                    For Each i In ListaPagos
                        SumaPagos += i.documentoCaja.montoSoles.GetValueOrDefault
                    Next
                    If SumaPagos = nDocumentoVenta.ImporteNacional Then 'txtTotalPagar.DecimalValue Then
                        ndocumento.documentoventaAbarrotes.terminos = "CONTADO"
                    Else
                        'ndocumento.documentoventaAbarrotes.terminos = "PARCIAL"
                        ndocumento.documentoventaAbarrotes.terminos = "CREDITO"
                    End If
                    ndocumento.documentoventaAbarrotes.estadoCobro = ndocumento.documentoventaAbarrotes.GetEstadoPagoComprobante
                    ndocumento.ListaCustomDocumento = ListaPagos 'ListaPagosCajas(c)
                Else
                    Throw New Exception("Debe realizar el pago del comprobante")
                End If
            Else
                Throw New Exception("Debe realizar el pago del comprobante")
            End If
        Else
            ndocumento.documentoventaAbarrotes.estadoCobro = "PN"
            ndocumento.documentoventaAbarrotes.terminos = "CREDITO"
        End If

        '  ndocumento.asiento = ListaAsientonTransito
        Return ndocumento
    End Function

    Public Function ListaPagosCajas(lista As List(Of documentoCaja), venta As documentoventaAbarrotes, ventaDetalle As List(Of documentoventaAbarrotesDet)) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)
        For Each i In lista

            nDocumentoCaja = New documento
            nDocumentoCaja.idDocumento = CInt(Me.Tag)
            nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
            nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
            nDocumentoCaja.tipoDoc = venta.tipoDocumento ' cbotipoDocPago.SelectedValue
            nDocumentoCaja.fechaProceso = txtFecha.Value
            nDocumentoCaja.nroDoc = GConfiguracion.Serie
            nDocumentoCaja.idOrden = Nothing
            nDocumentoCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
            If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                nDocumentoCaja.idEntidad = Val(TXTcOMPRADOR.Tag)
                nDocumentoCaja.entidad = TXTcOMPRADOR.Text
                nDocumentoCaja.nrodocEntidad = txtruc.Text
            Else
                nDocumentoCaja.entidad = TXTcOMPRADOR.Text
                nDocumentoCaja.nrodocEntidad = 0
                nDocumentoCaja.idEntidad = Val(0)
            End If
            nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
            nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
            nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
            nDocumentoCaja.fechaActualizacion = DateTime.Now


            'DOCUMENTO CAJA
            objCaja = New documentoCaja
            objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
            objCaja.idDocumento = 0
            objCaja.periodo = venta.fechaPeriodo
            objCaja.idEmpresa = Gempresas.IdEmpresaRuc
            objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
            objCaja.fechaProceso = txtFecha.Value
            objCaja.fechaCobro = txtFecha.Value
            objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
            If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                objCaja.codigoProveedor = Integer.Parse(TXTcOMPRADOR.Tag)
                objCaja.IdProveedor = Integer.Parse(TXTcOMPRADOR.Tag)
                objCaja.idPersonal = Integer.Parse(TXTcOMPRADOR.Tag)
            End If
            objCaja.TipoDocumentoPago = venta.tipoDocumento 'cbotipoDocPago.SelectedValue
            objCaja.codigoLibro = "1"
            objCaja.tipoDocPago = venta.tipoDocumento
            objCaja.formapago = i.formapago
            objCaja.NumeroDocumento = "-"
            objCaja.numeroOperacion = "-"
            Select Case venta.tipoDocumento
                Case "9907"
                    objCaja.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA
                Case Else
                    objCaja.movimientoCaja = TipoVentaGeneral 'TIPO_VENTA.VENTA_POS_DIRECTA,
            End Select
            objCaja.montoSoles = Decimal.Parse(i.montoSoles)

            objCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
            objCaja.tipoCambio = TmpTipoCambio
            objCaja.montoUsd = Decimal.Parse(objCaja.montoSoles / TmpTipoCambio)

            objCaja.estado = "1"
            objCaja.glosa = "Por ventas POS directa del cliente: " & TXTcOMPRADOR.Text & "con tipo Doc. " & cboTipoDoc.Text & ", fecha de venta " & txtFecha.Value
            objCaja.entregado = "SI"

            objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
            objCaja.entidadFinanciera = i.IdEntidadFinanciera
            objCaja.NombreEntidad = i.NomCajaOrigen
            objCaja.usuarioModificacion = usuario.IDUsuario
            objCaja.fechaModificacion = DateTime.Now
            nDocumentoCaja.documentoCaja = objCaja
            nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja, ventaDetalle)
            '  asientoDocumento(nDocumentoCaja.documentoCaja)
            ListaDoc.Add(nDocumentoCaja)
        Next

        Return ListaDoc
    End Function

    Private Function GetDetallePago(objCaja As documentoCaja, ventaDetalle As List(Of documentoventaAbarrotesDet)) As List(Of documentoCajaDetalle)
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

                    '.codigoLote = Integer.Parse(i.codigoLote),

                    GetDetallePago.Add(New documentoCajaDetalle With
                                   {
                                   .fecha = Date.Now,
                                   .codigoLote = 0,
                                   .otroMN = 0,
                                   .idItem = i.idItem,
                                   .DetalleItem = i.DetalleItem,
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

    Function ListaDocumentoCajaGenerico(be As documentoventaAbarrotes) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)

        nDocumentoCaja = New documento
        'DOCUMENTO
        nDocumentoCaja.idDocumento = CInt(Me.Tag)
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
        nDocumentoCaja.tipoDoc = be.tipoDocumento ' cbotipoDocPago.SelectedValue
        nDocumentoCaja.fechaProceso = txtFecha.Value
        nDocumentoCaja.nroDoc = GConfiguracion.Serie
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            nDocumentoCaja.idEntidad = Val(TXTcOMPRADOR.Tag)
            nDocumentoCaja.entidad = TXTcOMPRADOR.Text
            nDocumentoCaja.nrodocEntidad = txtruc.Text
        Else
            nDocumentoCaja.entidad = TXTcOMPRADOR.Text
            nDocumentoCaja.nrodocEntidad = 0
            nDocumentoCaja.idEntidad = Val(0)
        End If
        nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        'DOCUMENTO CAJA
        objCaja = New documentoCaja
        objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
        objCaja.idDocumento = 0
        objCaja.periodo = be.fechaPeriodo
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
        objCaja.fechaProceso = txtFecha.Value
        objCaja.fechaCobro = txtFecha.Value
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            objCaja.codigoProveedor = Integer.Parse(TXTcOMPRADOR.Tag)
            objCaja.IdProveedor = Integer.Parse(TXTcOMPRADOR.Tag)
            objCaja.idPersonal = Integer.Parse(TXTcOMPRADOR.Tag)
        End If
        objCaja.tipoDocPago = be.tipoDocumento
        objCaja.TipoDocumentoPago = be.tipoDocumento 'cbotipoDocPago.SelectedValue
        objCaja.codigoLibro = "1"
        objCaja.formapago = "109"
        objCaja.NumeroDocumento = "-"
        objCaja.numeroOperacion = "-"
        objCaja.movimientoCaja = TipoVentaGeneral 'TIPO_VENTA.VENTA_POS_DIRECTA,
        objCaja.montoSoles = Decimal.Parse(be.ImporteNacional)

        objCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
        objCaja.tipoCambio = TmpTipoCambio
        objCaja.montoUsd = FormatNumber(objCaja.montoSoles / TmpTipoCambio, 2)

        objCaja.estado = "1"
        objCaja.glosa = "Por ventas POS directa del cliente: " & TXTcOMPRADOR.Text & "con tipo Doc. " & cboTipoDoc.Text & ", fecha de venta " & txtFecha.Value
        objCaja.entregado = "SI"

        objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
        objCaja.usuarioModificacion = usuario.IDUsuario
        objCaja.entidadFinanciera = cbocajaPago.SelectedValue
        objCaja.NombreEntidad = cbocajaPago.Text
        objCaja.fechaModificacion = DateTime.Now

        nDocumentoCaja.documentoCaja = objCaja
        ListaDoc.Add(nDocumentoCaja)
        ListaDetalleCajaGenerico(nDocumentoCaja.documentoCaja, be.documentoventaAbarrotesDet.ToList)
        ' asientoDocumento(nDocumentoCaja.documentoCaja)

        Return ListaDoc
    End Function

    Private Sub ListaDetalleCajaGenerico(doc As documentoCaja, detalleVenta As List(Of documentoventaAbarrotesDet))
        Dim obj As New documentoCajaDetalle
        Dim lista As New List(Of documentoCajaDetalle)
        For Each i In detalleVenta

            obj = New documentoCajaDetalle
            obj.fecha = Date.Now
            '   obj.codigoLote = Integer.Parse(i.codigoLote)
            obj.idItem = CInt(i.idItem)
            obj.DetalleItem = i.DetalleItem
            obj.montoSoles = FormatNumber(Decimal.Parse(i.importeMN), 2)
            obj.montoUsd = FormatNumber(Decimal.Parse(i.importeME), 2) '
            obj.diferTipoCambio = TmpTipoCambio
            obj.tipoCambioTransacc = TmpTipoCambio
            obj.entregado = "SI"
            obj.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
            obj.usuarioModificacion = usuario.IDUsuario
            obj.documentoAfectado = CInt(Me.Tag)
            obj.fechaModificacion = DateTime.Now
            lista.Add(obj)
        Next
        doc.documentoCajaDetalle = lista
    End Sub

    Private Sub GetImpresionTicketsEspecial(listaDocumento As List(Of documentoventaAbarrotes))
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim impresionTicketDoc = listaDocumento.Where(Function(o) o.tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA).FirstOrDefault
        If impresionTicketDoc IsNot Nothing Then
            'If MessageBox.Show("Desea imprimir la venta ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            '    ImprimirTicket(impresionTicketDoc.idDocumento)
            ' ImprimirTicketAcumulado(impresionTicketDoc.idDocumento)
            'Dim f As New FormImpresionNuevo  ' frmVentaNuevoFormato
            'f.DocumentoID = impresionTicketDoc.idDocumento
            'f.StartPosition = FormStartPosition.CenterScreen
            '' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            'f.Show(Me)
            ventaSA.GetActualizarImpresion(New documentoventaAbarrotes With {.idDocumento = impresionTicketDoc.idDocumento})
            'End If
        End If
    End Sub

    Sub GrabarNotaDeVenta(dgvCompra As GridGroupingControl)
        'objPleaseWait = New FeedbackForm()
        'objPleaseWait.StartPosition = FormStartPosition.CenterScreen
        'objPleaseWait.Show()
        Application.DoEvents()

        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim docVentaSA As New documentoVentaAbarrotesSA

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)

        Dim TipoCobro As String

        Dim proveedor As String
        Dim idProveedor As Integer
        Dim conteoCantidad As Integer

        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()

        '-------------------------------------------------------------------------------------
        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.IsFormatoGeneral = False
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        ndocumento.tipoDoc = "9907"
        ndocumento.fechaProceso = txtFecha.Value
        ndocumento.nroDoc = "1"
        ndocumento.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            ndocumento.entidad = TXTcOMPRADOR.Text
            ndocumento.nrodocEntidad = txtruc.Text
            ndocumento.idEntidad = Val(TXTcOMPRADOR.Tag)
        Else
            ndocumento.entidad = TXTcOMPRADOR.Text
            ndocumento.nrodocEntidad = 0
            ndocumento.idEntidad = Val(0)
        End If
        ndocumento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        ndocumento.tipoOperacion = StatusTipoOperacion.VENTA
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now
        TipoCobro = TIPO_VENTA.PAGO.COBRADO
        Dim TipoEntrega = TipoEntregado.Entregado
        Dim tipoEstado = TipoGuia.Entregado

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            proveedor = TXTcOMPRADOR.Text
            idProveedor = CInt(TXTcOMPRADOR.Tag)
        Else
            proveedor = TXTcOMPRADOR.Text
            idProveedor = 0
        End If

        nDocumentoVenta = New documentoventaAbarrotes With {
                  .tipoOperacion = StatusTipoOperacion.VENTA,
                  .horaVenta = txtFecha.Value.TimeOfDay.ToString(),
                  .codigoLibro = "14",
                  .tipoDocumento = "9907",
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                  .fechaDoc = txtFecha.Value,
                  .fechaConfirmacion = txtFecha.Value,
                  .fechaPeriodo = GetPeriodo(txtFecha.Value, True),' lblPerido.Text,
        .serie = "NOTA",
                  .serieVenta = "NOTA",
                  .numeroDoc = 1,
                  .numeroVenta = 1,
                  .numeroDocNormal = Nothing,
                  .idCliente = CInt(idProveedor),
                  .idClientePedido = CInt(idProveedor),
                  .nombrePedido = proveedor,
                  .moneda = If(cboMoneda.Text = "NACIONAL", "1", "2"),
                  .tasaIgv = TmpIGV,
                  .tipoCambio = TmpTipoCambio,
                  .bi01 = TotalesXcanbeceras.base1,
                  .bi02 = TotalesXcanbeceras.base2,
                  .igv01 = TotalesXcanbeceras.MontoIgv1,
                  .igv02 = TotalesXcanbeceras.MontoIgv2,
                  .bi01us = TotalesXcanbeceras.base1me,
                  .bi02us = TotalesXcanbeceras.base2me,
                  .igv01us = TotalesXcanbeceras.MontoIgv1me,
                  .igv02us = TotalesXcanbeceras.MontoIgv2me,
                  .ImporteNacional = TotalesXcanbeceras.TotalMN,
                  .ImporteExtranjero = TotalesXcanbeceras.TotalME,
                  .tipoVenta = TIPO_VENTA.NOTA_DE_VENTA,
                  .estado = StatusNotaDeVentas.NoSustentado,
                  .estadoCobro = TipoCobro,
                  .estadoEntrega = TipoEntrega,
                  .terminos = "CONTADO",
                  .glosa = "Por ventas con nota de venta del cliente: " & TXTcOMPRADOR.Text & "con tipo Doc. " & cboTipoDoc.Text & ", fecha de venta " & txtFecha.Value,
                  .fechaVcto = txtFecha.Value,
                  .usuarioActualizacion = usuario.IDUsuario,
                  .fechaActualizacion = DateTime.Now}
        'tipoEstado,
        ndocumento.documentoventaAbarrotes = nDocumentoVenta

        'REGISTRANDO LA GUIA DE REMISION
        'GuiaRemision(ndocumento)
        ListaDetalle = New List(Of documentoventaAbarrotesDet)
        For Each r As Record In dgvCompra.Table.Records

            If CDec(r.GetValue("cantidad")) <= 0 Then
                'MessageBoxAdv.Show("Debe ingresar un cantidad mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Throw New Exception("Debe ingresar un cantidad mayor a cero.")
                'Exit Sub
            End If

            If CDec(r.GetValue("totalmn")) <= 0 Then
                Throw New Exception("El importe de venta debe ser mayor a cero.")
                '  MessageBoxAdv.Show("El importe de venta debe ser mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                '  Exit Sub
            End If
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            objDocumentoVentaDet.codigoLote = 0 'Integer.Parse(r.GetValue("codigoLote"))
            If ChPagoDirecto.Checked Then
                objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
            ElseIf ChPagoAvanzado.Checked Then
                If CDec(r.GetValue("MontoSaldo")) <= 0 Then
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
                Else
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                End If
            Else
                objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            End If

            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = txtFecha.Value
            objDocumentoVentaDet.Serie = "NOTA"
            objDocumentoVentaDet.NumDoc = 1
            objDocumentoVentaDet.TipoDoc = "9907"
            If r.GetValue("tipoExistencia") = "GS" Then
                objDocumentoVentaDet.idAlmacenOrigen = Nothing
                objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            Else
                objDocumentoVentaDet.idAlmacenOrigen = CInt(r.GetValue("almacen"))
                objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            End If
            objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = Nothing
            objDocumentoVentaDet.idItem = r.GetValue("idProducto")
            objDocumentoVentaDet.DetalleItem = r.GetValue("item")
            objDocumentoVentaDet.nombreItem = r.GetValue("item")
            objDocumentoVentaDet.tipoExistencia = r.GetValue("tipoExistencia")
            objDocumentoVentaDet.destino = r.GetValue("gravado")
            objDocumentoVentaDet.unidad1 = r.GetValue("um")
            objDocumentoVentaDet.monto1 = CDec(r.GetValue("cantidad"))
            objDocumentoVentaDet.unidad2 = Nothing
            objDocumentoVentaDet.monto2 = 0 ' CDec(r.GetValue("cantidad2")) ' i.Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoVentaDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            objDocumentoVentaDet.importeMN = CDec(r.GetValue("totalmn"))
            objDocumentoVentaDet.importeME = CDec(r.GetValue("totalme"))
            objDocumentoVentaDet.descuentoMN = 0
            objDocumentoVentaDet.descuentoME = 0

            objDocumentoVentaDet.montokardex = CDec(r.GetValue("vcmn"))
            objDocumentoVentaDet.montoIsc = 0
            objDocumentoVentaDet.montoIgv = CDec(r.GetValue("igvmn"))
            objDocumentoVentaDet.otrosTributos = 0
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = CDec(r.GetValue("vcme"))
            objDocumentoVentaDet.montoIscUS = 0
            objDocumentoVentaDet.montoIgvUS = CDec(r.GetValue("igvme"))
            objDocumentoVentaDet.otrosTributosUS = 0
            objDocumentoVentaDet.estadoMovimiento = "V" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = 0 ' CDec(r.GetValue("puKardex"))
            objDocumentoVentaDet.importeMEK = 0 'CDec(r.GetValue("pukardeme"))
            objDocumentoVentaDet.fechaVcto = txtFecha.Value
            objDocumentoVentaDet.estadoEntrega = TipoEntrega
            objDocumentoVentaDet.cantidadEntrega = CDec(r.GetValue("cantEntregar"))
            objDocumentoVentaDet.salidaCostoMN = CDec(r.GetValue("costoMN")) ' Math.Round(CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value()), 2)
            objDocumentoVentaDet.salidaCostoME = CDec(r.GetValue("costoME")) 'Math.Round(CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value()), 2)

            If (TipoEntrega = TipoEntregado.PorEntregar) Then
                conteoCantidad = CDec(r.GetValue("cantEntregar"))
            End If
            objDocumentoVentaDet.NomMarca = Nothing ' r.GetValue("marca")
            objDocumentoVentaDet.categoria = Nothing
            objDocumentoVentaDet.preEvento = Nothing
            objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoVentaDet.fechaModificacion = DateTime.Now
            objDocumentoVentaDet.Glosa = "Por nota de ventas"
            ListaDetalle.Add(objDocumentoVentaDet)
        Next

        '-------------------------------------------------------------------------------------
        '---------------- VALIDACION DE IMPORTE CON DETALLE DE VENTA -------------------------

        Dim sumaVentaMN As Decimal = ListaDetalle.Sum(Function(o) o.importeMN).GetValueOrDefault
        Dim sumaVentaME As Decimal = ListaDetalle.Sum(Function(o) o.importeME).GetValueOrDefault
        Dim sumaBase1MN As Decimal =
            ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Grabado).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaBase1ME As Decimal =
            ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Grabado).Sum(Function(o) o.montokardexUS).GetValueOrDefault

        Dim sumaBase2MN As Decimal =
            ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Exonerado).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaBase2ME As Decimal =
            ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Exonerado).Sum(Function(o) o.montokardexUS).GetValueOrDefault

        Dim sumaIgvMN As Decimal = ListaDetalle.Sum(Function(o) o.montoIgv).GetValueOrDefault
        Dim sumaIgvME As Decimal = ListaDetalle.Sum(Function(o) o.montoIgvUS).GetValueOrDefault

        Dim totalVentaDetalle As Decimal = sumaBase1MN + sumaBase2MN + sumaIgvMN
        Dim totalHeader As Decimal = txtTotalPagar.DecimalValue
        If totalHeader <> totalVentaDetalle Then
            Throw New Exception("Los importes no coinciden, tanto del detalle con la cabecera ")
        End If
        '-------------------------------------------------------------------------------------
        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle

        'Dim listaExistencias As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle
        '                                                               Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList
        'If listaExistencias.Count > 0 Then
        '    AsientoVenta(listaExistencias)
        'End If

        'Dim listaServicios As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle
        '                                                             Where n.tipoExistencia = TipoRecurso.SERVICIO).ToList

        'If listaServicios.Count > 0 Then
        '    AsientoVentaServicios(listaServicios)
        'End If

        'GuiaRemision(ndocumento)

        If ChPagoDirecto.Checked Then
            ndocumento.ListaCustomDocumento = ListaDocumentoCaja(ndocumento.documentoventaAbarrotes)
            ndocumento.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.COBRADO
            ndocumento.documentoventaAbarrotes.terminos = "CONTADO"
        ElseIf ChPagoAvanzado.Checked = True Then
            Dim f As New FormPagoVariasCajas ' frmFormatoPagoComprobantes
            f.txtMontoXcobrar.Text = nDocumentoVenta.ImporteNacional ' txtTotalPagar.DecimalValue
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If f.Tag IsNot Nothing Then
                Dim c = CType(f.Tag, List(Of documentoCaja))
                If c.Count > 0 Then
                    Dim ListaPagos = ListaPagosCajas(c, ndocumento.documentoventaAbarrotes, ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet)
                    Dim SumaPagos As Decimal = 0
                    For Each i In ListaPagos
                        SumaPagos += i.documentoCaja.montoSoles.GetValueOrDefault
                    Next
                    If SumaPagos = nDocumentoVenta.ImporteNacional Then
                        ndocumento.documentoventaAbarrotes.terminos = "CONTADO"
                    Else
                        'ndocumento.documentoventaAbarrotes.terminos = "PARCIAL"
                        ndocumento.documentoventaAbarrotes.terminos = "CREDITO"
                    End If
                    ndocumento.documentoventaAbarrotes.estadoCobro = ndocumento.documentoventaAbarrotes.GetEstadoPagoComprobante
                    ndocumento.ListaCustomDocumento = ListaPagos 'ListaPagosCajas(c)
                Else
                    MessageBox.Show("Debe realizar el pago del comprobante", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Else
                MessageBox.Show("Debe realizar el pago del comprobante", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            ndocumento.documentoventaAbarrotes.estadoCobro = "PN"
            ndocumento.documentoventaAbarrotes.terminos = "CREDITO"
        End If


        Dim idDocuentoGrabado As Integer
        If ListaDetalle.Where(Function(o) o.monto1 = 0).Count = 0 Then
            '  ndocumento.asiento = ListaAsientonTransito
            idDocuentoGrabado = docVentaSA.Grabar_VentaNotaSinLote(ndocumento)

            GetImpresionTicketsEspecialNota(idDocuentoGrabado)

            ' LimpiarControles()
            ChPagoDirecto.Checked = True
            ChPagoAvanzado.Checked = False
            PagoDirectoCheck()

            Dim miInterfaz As ICommitOperacion = TryCast(Me.Owner, ICommitOperacion)
            If miInterfaz IsNot Nothing Then miInterfaz.Commit(True)
            objPleaseWait.Close()
            Close()

        Else
            Throw New Exception("Debe verificar que las celdas estan completas!")
        End If
    End Sub

    Private Sub GetImpresionTicketsEspecialNota(idDocumento As Integer)
        Dim ventaSA As New documentoVentaAbarrotesSA

        'If MessageBox.Show("Desea imprimir la venta ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        'ImprimirTicketGladis(idDocumento)
        'ImprimirTicketAcumulado(idDocumento)

        'Dim f As New FormImpresionNuevo  ' frmVentaNuevoFormato
        'f.DocumentoID = idDocumento
        'f.StartPosition = FormStartPosition.CenterScreen
        '' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.Show(Me)

        ventaSA.GetActualizarImpresion(New documentoventaAbarrotes With {.idDocumento = idDocumento})
        'End If
    End Sub

    Function ListaDocumentoCaja(VENTA As documentoventaAbarrotes) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)

        Dim tipoDocumento As String = Nothing
        Dim serieVenta As String = Nothing
        Dim numeroVenta As String = Nothing

        Select Case VENTA.tipoDocumento
            Case "9907"
                tipoDocumento = "9907"
                serieVenta = "NOTE"
                numeroVenta = "1"
            Case Else
                tipoDocumento = VENTA.tipoDocumento
                serieVenta = VENTA.serieVenta
                numeroVenta = VENTA.numeroVenta
        End Select

        nDocumentoCaja = New documento
        'DOCUMENTO
        nDocumentoCaja.idDocumento = CInt(Me.Tag)
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
        nDocumentoCaja.tipoDoc = tipoDocumento ' cbotipoDocPago.SelectedValue
        nDocumentoCaja.fechaProceso = txtFecha.Value
        nDocumentoCaja.nroDoc = serieVenta & "-" & numeroVenta
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            nDocumentoCaja.idEntidad = Val(TXTcOMPRADOR.Tag)
            nDocumentoCaja.entidad = TXTcOMPRADOR.Text
            nDocumentoCaja.nrodocEntidad = txtruc.Text
        Else
            nDocumentoCaja.entidad = TXTcOMPRADOR.Text
            nDocumentoCaja.nrodocEntidad = 0
            nDocumentoCaja.idEntidad = Val(0)
        End If
        nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        'DOCUMENTO CAJA
        objCaja = New documentoCaja
        objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
        objCaja.idDocumento = 0
        objCaja.periodo = VENTA.fechaPeriodo ' lblPerido.Text
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
        objCaja.fechaProceso = txtFecha.Value
        objCaja.fechaCobro = txtFecha.Value
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            objCaja.codigoProveedor = Integer.Parse(TXTcOMPRADOR.Tag)
            objCaja.IdProveedor = Integer.Parse(TXTcOMPRADOR.Tag)
            objCaja.idPersonal = Integer.Parse(TXTcOMPRADOR.Tag)
        End If
        objCaja.tipoDocPago = tipoDocumento
        objCaja.TipoDocumentoPago = tipoDocumento 'cbotipoDocPago.SelectedValue
        objCaja.codigoLibro = "1"
        objCaja.formapago = "109"
        objCaja.NumeroDocumento = "-"
        objCaja.numeroOperacion = "-"

        Select Case VENTA.tipoDocumento
            Case "9907"
                objCaja.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA
            Case Else
                objCaja.movimientoCaja = TIPO_VENTA.VENTA_POS_DIRECTA
        End Select

        objCaja.montoSoles = Decimal.Parse(VENTA.ImporteNacional)

        objCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
        objCaja.tipoCambio = TmpTipoCambio
        objCaja.montoUsd = FormatNumber(objCaja.montoSoles / TmpTipoCambio, 2)

        objCaja.estado = "1"
        objCaja.glosa = "Por ventas POS directa del cliente: " & TXTcOMPRADOR.Text & "con tipo Doc. " & cboTipoDoc.Text & ", fecha de venta " & txtFecha.Value
        objCaja.entregado = "SI"

        objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
        objCaja.usuarioModificacion = usuario.IDUsuario
        objCaja.entidadFinanciera = cbocajaPago.SelectedValue
        objCaja.NombreEntidad = cbocajaPago.Text
        objCaja.fechaModificacion = DateTime.Now

        nDocumentoCaja.documentoCaja = objCaja
        ListaDoc.Add(nDocumentoCaja)
        ListaDetalleCaja(nDocumentoCaja.documentoCaja)
        '  asientoDocumento(nDocumentoCaja.documentoCaja)

        Return ListaDoc
    End Function

    Private Sub ListaDetalleCaja(doc As documentoCaja)
        Dim obj As New documentoCajaDetalle
        Dim lista As New List(Of documentoCajaDetalle)
        For Each i As Record In GridVenta.Table.Records

            obj = New documentoCajaDetalle
            obj.fecha = Date.Now
            obj.codigoLote = 0 'Integer.Parse(i.GetValue("codigoLote"))
            obj.otroMN = 0 'Integer.Parse(i.GetValue("codigoLote"))
            obj.idItem = CInt(i.GetValue("idProducto"))
            obj.DetalleItem = i.GetValue("item")
            obj.montoSoles = FormatNumber(Decimal.Parse(i.GetValue("totalmn")), 2)
            obj.montoUsd = FormatNumber(Decimal.Parse(i.GetValue("totalme")), 2) '
            obj.diferTipoCambio = TmpTipoCambio
            obj.tipoCambioTransacc = TmpTipoCambio
            obj.entregado = "SI"
            obj.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
            obj.usuarioModificacion = usuario.IDUsuario
            obj.documentoAfectado = CInt(Me.Tag)
            obj.fechaModificacion = DateTime.Now
            lista.Add(obj)
        Next
        doc.documentoCajaDetalle = lista
    End Sub

    Private Sub FormConfirmaVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFecha.Value = DateTime.Now
        txtFecha.Enabled = True
    End Sub

    Private Sub TXTcOMPRADOR_TextChanged(sender As Object, e As EventArgs) Handles TXTcOMPRADOR.TextChanged
        TXTcOMPRADOR.ForeColor = Color.Black
        TXTcOMPRADOR.Tag = Nothing
        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            txtruc.Visible = True
        Else
            txtruc.Visible = False
        End If
    End Sub

    Private Sub TXTcOMPRADOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTcOMPRADOR.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TXTcOMPRADOR
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})



            Dim consulta2 = (From n In listaClientes
                             Where n.nombreCompleto.StartsWith(TXTcOMPRADOR.Text) Or n.nrodoc.StartsWith(TXTcOMPRADOR.Text)).ToList




            consulta.AddRange(consulta2)
            FillLSVClientes(consulta)
            e.Handled = True
        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TXTcOMPRADOR
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            LsvProveedor.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcLikeCategoria.IsShowing() Then
                Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub FillLSVClientes(consulta As List(Of entidad))
        LsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            n.SubItems.Add(i.tipoDoc)
            LsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick, TXTcOMPRADOR.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Me.Cursor = Cursors.WaitCursor
        Dim beneficioSA As New beneficioSA
        If e.PopupCloseType = PopupCloseType.Done Then
            If LsvProveedor.SelectedItems.Count > 0 Then
                If LsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                    Dim f As New frmCrearENtidades
                    f.CaptionLabels(0).Text = "Nuevo cliente"
                    f.strTipo = TIPO_ENTIDAD.CLIENTE
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    If Not IsNothing(f.Tag) Then
                        Dim c = CType(f.Tag, entidad)
                        listaClientes.Add(c)
                        txtTipoDocClie.Text = c.tipoDoc
                        TXTcOMPRADOR.Text = c.nombreCompleto
                        txtruc.Text = c.nrodoc
                        TXTcOMPRADOR.Tag = c.idEntidad
                        txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        txtruc.Visible = True
                        TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    End If
                Else
                    TXTcOMPRADOR.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                    TXTcOMPRADOR.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                    TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtruc.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
                    txtTipoDocClie.Text = LsvProveedor.SelectedItems(0).SubItems(3).Text
                    txtruc.Visible = True
                    ListaBeneficios = New List(Of Business.Entity.beneficio)
                    ListaBeneficios = beneficioSA.BeneficioListaClienteProductions(New Business.Entity.beneficio With {.idCliente = Integer.Parse(TXTcOMPRADOR.Tag)})

                    If ListaBeneficios.Count > 0 Then
                        formventa.TotalesColumnaDescuentos(ListaBeneficios)
                    Else
                        formventa.TotalesColumnaDescuentos(ListaBeneficios)
                    End If

                    CalculosMontos()

                    'TextBenefClienteBase.Text = beneficio.importeBase.GetValueOrDefault
                    'TextValorAfecto.Text = beneficio.valorConvertido

                    'Select Case beneficio.tipoAfectacion
                    '    Case "I"
                    '        TextTipoBeneficio.Text = "IMPORTE"
                    '    Case "C"
                    '        TextTipoBeneficio.Text = "CANTIDAD"
                    '    Case "P"
                    '        TextTipoBeneficio.Text = "PORCENTAJE"
                    'End Select

                End If
                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.TXTcOMPRADOR.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub FormConfirmaVenta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ListaEstadosFinancieros IsNot Nothing Then
            ListaEstadosFinancieros.Clear()
        End If
        bgCombos.CancelAsync()

        BackgroundWorker1.CancelAsync()
        If thread IsNot Nothing Then
            thread.Abort()
        End If
    End Sub

    Private Sub ChPagoDirecto_OnChange(sender As Object, e As EventArgs) Handles ChPagoDirecto.OnChange
        PagoDirectoCheck()
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
End Class