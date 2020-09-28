Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms

Public Class FormGenerarComprobanteVenta

#Region "Attributes"
    Dim conf As New GConfiguracionModulo
    Property DocumentoNota As documento
    Public Property ListadoPagosNota As List(Of documento)
    Public Property Ventana As TabCM_RegistroNotaVentas
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of entidad))
    Public Property listaClientes As New List(Of entidad)
#End Region

#Region "Constructors"
    Public Sub New(doc As documento, VentanaSel As TabCM_RegistroNotaVentas)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Ventana = VentanaSel
        ListadoPagosNota = New List(Of documento)
        DocumentoNota = doc
        ListadoPagosNota = PagoMapping(DocumentoNota.idDocumento)
        threadClientes()
        txtNumero.Visible = True
    End Sub


#End Region

#Region "Events"
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim strIdModulo As String = Nothing
        If cboTipoDoc.Text = "TICKET BOLETA" Then
            strIdModulo = "VT2"
        ElseIf cboTipoDoc.Text = "TICKET FACTURA" Then
            strIdModulo = "VT3"
        End If
        Dim strIDEmpresa = Gempresas.IdEmpresaRuc
        configuracionModuloV2(strIDEmpresa, strIdModulo, "", GEstableciento.IdEstablecimiento)
    End Sub

    Private Sub cboTipoDoc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedValueChanged
        If cboTipoDoc.Text.Trim.Length > 0 Then
            txtSerie.Clear()
            txtNumero.Clear()
            Select Case cboTipoDoc.Text
                Case "BOLETA", "FACTURA"
                    txtSerie.Visible = True
                    txtNumero.Visible = True
                    txtSerie.Select()
                    txtSerie.SelectAll()
                Case "TICKET BOLETA", "TICKET FACTURA"
                    ProgressBar2.Visible = True
                    ProgressBar2.Style = ProgressBarStyle.Marquee
                    BackgroundWorker1.RunWorkerAsync()
                    txtSerie.Visible = False
                    txtNumero.Visible = False
            End Select

        End If
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Cursor = Cursors.WaitCursor
        '    Dim cierreSA As New empresaCierreMensualSA
        Try
            'Dim fechaEnvioAlmacen = txtFecha.Value

            'Dim fechaAnt = New Date(fechaEnvioAlmacen.Year, fechaEnvioAlmacen.Month, 1)
            'fechaAnt = fechaAnt.AddMonths(-1)

            'Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(
            '    New empresaCierreMensual With
            '    {
            '    .idEmpresa = Gempresas.IdEmpresaRuc,
            '    .anio = fechaAnt.Year,
            '    .mes = fechaAnt.Month
            '    })

            'If periodoAnteriorEstaCerrado = False Then
            '    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            '    Cursor = Cursors.Default
            '    Exit Sub
            'End If

            'Dim valida As Boolean = cierreSA.EstadoMesCerrado(
            '    New empresaCierreMensual With
            '    {
            '    .idEmpresa = Gempresas.IdEmpresaRuc,
            '    .anio = fechaEnvioAlmacen.Year, .mes = fechaEnvioAlmacen.Month
            '    })
            'If Not IsNothing(valida) Then
            '    If valida = True Then
            '        MessageBox.Show("No puede realizar está operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        Exit Sub
            '    End If
            'End If
            If ValidarGrabado() Then
                generarComprobante(DocumentoNota)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Cursor = Cursors.Default
    End Sub
#End Region

#Region "Methods"
    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0

        Select Case cboTipoDoc.Text
            Case "BOLETA", "FACTURA"
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

            Case "TICKET BOLETA", "TICKET FACTURA"

        End Select

        If TXTcOMPRADOR.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un cliente")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
        End If

        If listaErrores > 0 Then
            ValidarGrabado = False
        Else
            ValidarGrabado = True
        End If
    End Function

    Private Sub threadClientes()
        Dim tipo = TIPO_ENTIDAD.CLIENTE
        Dim empresa = Gempresas.IdEmpresaRuc
        ProgressBar2.Visible = True
        ProgressBar2.Style = ProgressBarStyle.Marquee
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(tipo, empresa)))
        thread.Start()
    End Sub

    Private Sub GetClientes(tipo As String, empresa As String)
        Dim entidadSA As New entidadSA
        Dim lista = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = tipo, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
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
            ProgressBar2.Visible = False
        End If
    End Sub

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

    Function ListaDocumentoCaja(be As documentoventaAbarrotes) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)

        For Each i In ListadoPagosNota
            nDocumentoCaja = New documento
            'DOCUMENTO
            nDocumentoCaja.idEmpresa = i.idEmpresa
            nDocumentoCaja.idCentroCosto = i.idCentroCosto
            nDocumentoCaja.tipoDoc = be.tipoDocumento ' cbotipoDocPago.SelectedValue
            nDocumentoCaja.fechaProceso = txtFecha.Value
            nDocumentoCaja.nroDoc = i.nroDoc
            nDocumentoCaja.moneda = i.moneda
            nDocumentoCaja.idEntidad = i.idEntidad
            nDocumentoCaja.entidad = i.entidad
            nDocumentoCaja.nrodocEntidad = i.nrodocEntidad
            nDocumentoCaja.tipoEntidad = i.tipoEntidad
            nDocumentoCaja.tipoOperacion = StatusTipoOperacion.VENTA
            nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
            nDocumentoCaja.fechaActualizacion = DateTime.Now

            'DOCUMENTO CAJA
            objCaja = New documentoCaja
            objCaja.tipoOperacion = StatusTipoOperacion.VENTA
            objCaja.periodo = i.documentoCaja.periodo
            objCaja.idEmpresa = i.documentoCaja.idEmpresa
            objCaja.idEstablecimiento = i.documentoCaja.idEstablecimiento
            objCaja.fechaProceso = txtFecha.Value
            objCaja.fechaCobro = txtFecha.Value
            objCaja.tipoMovimiento = i.documentoCaja.tipoMovimiento
            objCaja.codigoProveedor = i.documentoCaja.codigoProveedor
            objCaja.IdProveedor = i.documentoCaja.IdProveedor
            objCaja.idPersonal = i.documentoCaja.idPersonal
            objCaja.tipoDocPago = be.tipoDocumento
            objCaja.TipoDocumentoPago = be.tipoDocumento 'cbotipoDocPago.SelectedValue
            objCaja.codigoLibro = i.documentoCaja.codigoLibro
            objCaja.formapago = i.documentoCaja.formapago
            objCaja.NumeroDocumento = i.documentoCaja.NumeroDocumento
            objCaja.numeroOperacion = i.documentoCaja.numeroOperacion
            objCaja.movimientoCaja = TIPO_VENTA.VENTA_HEREDAD
            objCaja.montoSoles = i.documentoCaja.montoSoles

            objCaja.moneda = i.documentoCaja.moneda
            objCaja.tipoCambio = i.documentoCaja.tipoCambio
            objCaja.montoUsd = i.documentoCaja.montoUsd

            objCaja.estado = i.documentoCaja.estado
            objCaja.glosa = i.documentoCaja.glosa
            objCaja.entregado = i.documentoCaja.entregado

            objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
            objCaja.usuarioModificacion = usuario.IDUsuario
            objCaja.entidadFinanciera = i.documentoCaja.entidadFinanciera
            objCaja.NombreEntidad = i.documentoCaja.NombreEntidad
            objCaja.fechaModificacion = DateTime.Now

            nDocumentoCaja.documentoCaja = objCaja
            ListaDoc.Add(nDocumentoCaja)
            ListaDetalleCaja(nDocumentoCaja.documentoCaja, i.documentoCaja.documentoCajaDetalle.ToList)
        Next
        '   asientoDocumento(nDocumentoCaja.documentoCaja)

        Return ListaDoc
    End Function

    Private Sub ListaDetalleCaja(documentoCaja As documentoCaja, list As List(Of documentoCajaDetalle))
        Dim obj As New documentoCajaDetalle
        Dim lista As New List(Of documentoCajaDetalle)
        For Each i In list

            obj = New documentoCajaDetalle
            obj.fecha = txtFecha.Value
            obj.codigoLote = i.otroMN
            obj.otroMN = i.otroMN
            obj.idItem = i.idItem
            obj.DetalleItem = i.DetalleItem
            obj.montoSoles = i.montoSoles
            obj.montoUsd = i.montoUsd
            obj.diferTipoCambio = TmpTipoCambio
            obj.tipoCambioTransacc = TmpTipoCambio
            obj.entregado = i.entregado
            obj.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
            obj.usuarioModificacion = usuario.IDUsuario
            obj.documentoAfectado = 0
            obj.fechaModificacion = DateTime.Now
            lista.Add(obj)
        Next
        documentoCaja.documentoCajaDetalle = lista
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

    '                        If cboTipoDoc.Text = "TICKET BOLETA" Then
    '                            GConfiguracion2.TipoComprobante = "12.1" ' .tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial

    '                        End If
    '                        If cboTipoDoc.Text = "TICKET FACTURA" Then
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

    'Private Sub GetNumeracion(strIdModulo As String, strIDEmpresa As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    conf = New GConfiguracionModulo
    '    conf = ConfigurarComprobanteVenta(moduloConfiguracion)
    '    'SetDataSourceNumeracion(moduloConfiguracion)
    'End Sub

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

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBar2.Visible = False

    End Sub

    Private Function PagoMapping(idDocumento As Integer) As List(Of documento)
        Dim cajaSA As New DocumentoCajaSA
        Dim cajaDetSA As New DocumentoCajaDetalleSA
        Dim doc As New documento
        Dim documentoSA As New DocumentoSA
        'Dim ListaDocumentoCaja = cajaSA.GetUbicar_documentoCajaPorID(idDocumento)
        Dim cajaDoc = cajaSA.ListadoComprobaNtesXidPadre(idDocumento)

        PagoMapping = New List(Of documento)
        For Each i In cajaDoc
            Dim ListaDetalle = cajaDetSA.GetUbicar_DetallePorIdDocumento(i.idDocumento)

            doc = New documento
            doc = documentoSA.UbicarDocumento(i.idDocumento)
            doc.documentoCaja = i
            doc.documentoCaja.documentoCajaDetalle = ListaDetalle.ToList
            PagoMapping.Add(doc)
        Next
        'Dim Pagos = cajaSA.GetPagoByComprobante(idDocumento)
        'Return Pagos.Distinct.ToList()
    End Function


    Private Sub generarComprobante(nota As documento)
        Dim tipodocVenta As String = Nothing
        Dim VentaSerie As String = Nothing
        Dim VentaNumero As String = Nothing

        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim venta As New documento
        Dim ventaDetalle As documentoventaAbarrotesDet
        Dim ventaDetalleNota = nota.documentoventaAbarrotes.documentoventaAbarrotesDet
        Dim ventaNota = nota.documentoventaAbarrotes
        Dim formatoGeneral As Boolean
        Select Case cboTipoDoc.Text
            Case "BOLETA"
                formatoGeneral = True
                tipodocVenta = "03"
                VentaSerie = txtSerie.Text.Trim
                VentaNumero = txtNumero.Text.Trim
            Case "FACTURA"
                formatoGeneral = True
                tipodocVenta = "01"
                VentaSerie = txtSerie.Text.Trim
                VentaNumero = txtNumero.Text.Trim
            Case "TICKET BOLETA"
                formatoGeneral = False
                tipodocVenta = "12.1"
                VentaSerie = conf.Serie
                VentaNumero = conf.Serie
            Case "TICKET FACTURA"
                formatoGeneral = False
                tipodocVenta = "12.2"
                VentaSerie = conf.Serie
                VentaNumero = conf.Serie
        End Select

        venta = nota
        venta.IsFormatoGeneral = formatoGeneral
        venta.tipoDoc = tipodocVenta
        venta.fechaProceso = txtFecha.Value
        venta.nroDoc = VentaSerie
        venta.usuarioActualizacion = usuario.IDUsuario
        venta.fechaActualizacion = DateTime.Now

        venta.documentoventaAbarrotes = New documentoventaAbarrotes
        venta.documentoventaAbarrotes = nota.documentoventaAbarrotes
        venta.documentoventaAbarrotes.TipoConfiguracion = conf.TipoConfiguracion
        venta.documentoventaAbarrotes.IdNumeracion = IIf(IsNothing(conf.ConfigComprobante), 0, conf.ConfigComprobante)
        venta.documentoventaAbarrotes.tipoOperacion = StatusTipoOperacion.VENTA
        venta.documentoventaAbarrotes.codigoLibro = "14"
        venta.documentoventaAbarrotes.tipoDocumento = tipodocVenta
        venta.documentoventaAbarrotes.idEmpresa = Gempresas.IdEmpresaRuc
        venta.documentoventaAbarrotes.idEstablecimiento = GEstableciento.IdEstablecimiento
        venta.documentoventaAbarrotes.fechaDoc = txtFecha.Value
        venta.documentoventaAbarrotes.fechaPeriodo = GetPeriodo(txtFecha.Value, True)
        venta.documentoventaAbarrotes.serie = VentaSerie
        venta.documentoventaAbarrotes.serieVenta = VentaSerie
        venta.documentoventaAbarrotes.numeroDoc = VentaNumero
        venta.documentoventaAbarrotes.numeroVenta = VentaNumero
        venta.documentoventaAbarrotes.tipoVenta = TIPO_VENTA.VENTA_HEREDAD
        venta.documentoventaAbarrotes.glosa = "Por venta de mercaderías"
        venta.documentoventaAbarrotes.estadoCobro = ventaNota.estadoCobro
        venta.documentoventaAbarrotes.terminos = ventaNota.terminos
        venta.documentoventaAbarrotes.estadoEntrega = ventaNota.estadoEntrega
        venta.documentoventaAbarrotes.horaVenta = txtFecha.Value.TimeOfDay.ToString()
        venta.documentoventaAbarrotes.idPadre = nota.idDocumento

        venta.documentoventaAbarrotes.idCliente = Integer.Parse(TXTcOMPRADOR.Tag)
        venta.documentoventaAbarrotes.idClientePedido = Integer.Parse(TXTcOMPRADOR.Tag)
        venta.documentoventaAbarrotes.nombrePedido = ventaNota.nombrePedido
        venta.documentoventaAbarrotes.moneda = ventaNota.moneda
        venta.documentoventaAbarrotes.tasaIgv = ventaNota.tasaIgv
        venta.documentoventaAbarrotes.tipoCambio = ventaNota.tipoCambio
        venta.documentoventaAbarrotes.bi01 = ventaNota.bi01
        venta.documentoventaAbarrotes.bi02 = ventaNota.bi02
        venta.documentoventaAbarrotes.igv01 = ventaNota.igv01
        venta.documentoventaAbarrotes.igv02 = ventaNota.igv02
        venta.documentoventaAbarrotes.bi01us = ventaNota.bi01us
        venta.documentoventaAbarrotes.bi02us = ventaNota.bi02us
        venta.documentoventaAbarrotes.igv01us = ventaNota.igv01us
        venta.documentoventaAbarrotes.igv02us = ventaNota.igv02us
        venta.documentoventaAbarrotes.estado = StatusNotaDeVentas.Sustentado
        venta.documentoventaAbarrotes.ImporteNacional = ventaNota.ImporteNacional
        venta.documentoventaAbarrotes.ImporteExtranjero = ventaNota.ImporteExtranjero

        venta.documentoventaAbarrotes.usuarioActualizacion = usuario.IDUsuario
        venta.documentoventaAbarrotes.fechaActualizacion = DateTime.Now

        For Each i In ventaDetalleNota
            ventaDetalle = New documentoventaAbarrotesDet
            ventaDetalle.codigoLote = i.codigoLote
            ventaDetalle.idAlmacenOrigen = i.idAlmacenOrigen
            ventaDetalle.estadoPago = i.estadoPago
            ventaDetalle.IdEmpresa = Gempresas.IdEmpresaRuc
            ventaDetalle.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value
            ventaDetalle.FechaDoc = txtFecha.Value
            ventaDetalle.Serie = VentaSerie
            ventaDetalle.NumDoc = VentaNumero
            ventaDetalle.TipoDoc = tipodocVenta
            ventaDetalle.tipoVenta = i.tipoVenta
            ventaDetalle.establecimientoOrigen = GEstableciento.IdEstablecimiento
            ventaDetalle.idItem = i.idItem
            ventaDetalle.DetalleItem = i.nombreItem
            ventaDetalle.tipoExistencia = i.tipoExistencia
            ventaDetalle.destino = i.destino
            ventaDetalle.unidad1 = i.unidad1
            ventaDetalle.monto1 = i.monto1
            ventaDetalle.precioUnitario = i.precioUnitario
            ventaDetalle.precioUnitarioUS = i.precioUnitarioUS
            ventaDetalle.importeMN = i.importeMN
            ventaDetalle.importeME = i.importeME
            ventaDetalle.montokardex = i.montokardex
            ventaDetalle.montoIgv = i.montoIgv
            ventaDetalle.montokardexUS = i.montokardexUS
            ventaDetalle.montoIgvUS = i.montoIgvUS
            ventaDetalle.estadoMovimiento = "V" 'ENTREGADO/COBRADO
            ventaDetalle.importeMNK = i.importeMNK
            ventaDetalle.importeMEK = i.importeMEK
            ventaDetalle.fechaVcto = txtFecha.Value
            ventaDetalle.estadoEntrega = TipoEntregado.Entregado
            ventaDetalle.cantidadEntrega = i.cantidadEntrega
            ventaDetalle.salidaCostoMN = i.salidaCostoMN ' Math.Round(CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value()), 2)
            ventaDetalle.salidaCostoME = i.salidaCostoME 'Math.Round(CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value()), 2)
            ventaDetalle.usuarioModificacion = usuario.IDUsuario
            ventaDetalle.fechaModificacion = DateTime.Now
            ventaDetalle.Glosa = "Por venta de mercaderías"
            venta.documentoventaAbarrotes.documentoventaAbarrotesDet.Add(ventaDetalle)
        Next

        GuiaRemision(venta, venta.documentoventaAbarrotes)

        venta.ListaCustomDocumento = ListaDocumentoCaja(venta.documentoventaAbarrotes)
        Dim ventaDoc = ventaSA.GenerarComprobanteVenta(venta)
        If MessageBox.Show("Desea imprimir la venta ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ImprimirTicketAcumulado(ventaDoc)
            ventaSA.GetActualizarImpresion(New documentoventaAbarrotes With {.idDocumento = ventaDoc})
        End If
        Ventana.threadResumenNotas()
        MsgBox("Venta registrada con éxito!", MsgBoxStyle.Information, "Documento susutentado!")
        Close()
    End Sub

    Sub GuiaRemision(venta As documento, ventaBE As documentoventaAbarrotes)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION

        Dim idCliente As Integer = 0
        Dim nomCliente As String = Nothing

        idCliente = ventaBE.idCliente
        nomCliente = ventaBE.NombreEntidad

        With guiaRemisionBE
            .idDocumento = 0
            .codigoLibro = "14"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .periodo = ventaBE.fechaPeriodo
            .tipoDoc = "99"
            .idEntidad = idCliente
            .monedaDoc = "1"
            .tasaIgv = 0 'txtIva.DoubleValue
            .tipoCambio = 1 ' txtTipoCambio.DecimalValue
            .importeMN = ventaBE.ImporteNacional
            .importeME = ventaBE.ImporteExtranjero
            .glosa = ventaBE.glosa
            .estado = TipoGuia.Entregado
            .direccionPartida = "ORIGEN"
            .fechaTraslado = Date.Now
            .estado = TipoGuia.Entregado
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        venta.documentoGuia = guiaRemisionBE

        For Each r In ventaBE.documentoventaAbarrotesDet.ToList
            If r.tipoExistencia <> "GS" Then
                documentoguiaDetalle = New documentoguiaDetalle
                documentoguiaDetalle.idDocumento = 0
                documentoguiaDetalle.idItem = r.idItem
                documentoguiaDetalle.descripcionItem = If(r.nombreItem Is Nothing, r.DetalleItem, r.nombreItem)
                documentoguiaDetalle.destino = r.destino
                documentoguiaDetalle.unidadMedida = r.unidad1
                documentoguiaDetalle.cantidad = r.monto1

                documentoguiaDetalle.almacenRef = r.idAlmacenOrigen
                documentoguiaDetalle.nombreRecepcion = nomCliente
                documentoguiaDetalle.dniRecepcion = Nothing
                documentoguiaDetalle.puntoLlegada = "ORIGEN"
                documentoguiaDetalle.estado = TipoGuiaDetalle.Entrega_Total
                documentoguiaDetalle.usuarioModificacion = usuario.IDUsuario
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
                ' End If
            End If

        Next
        venta.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Private Sub FormGenerarComprobanteVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFecha.Value = DateTime.Now
    End Sub

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

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
            LsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick, TXTcOMPRADOR.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Me.Cursor = Cursors.WaitCursor

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
                    txtruc.Visible = True
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
#End Region

End Class