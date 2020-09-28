Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports System.Drawing
Imports System.Drawing.Printing
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class frmCobroPedidos
    Inherits frmMaster

#Region "Attributes"
    Dim EntidadSeleccionda As New entidad
    Dim EntidadSA As New entidadSA
#End Region

    Public Título As String = ""
    Private prtSettings As PrinterSettings
    Private prtDoc As PrintDocument
    Private ppc As New PrintPreviewControl
    Private prtFont As System.Drawing.Font
    Dim conteo As Integer = 0
    Dim datosEst As Integer = 0
    Private lineaActual As Integer
    Public fontNCabecera As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    Dim X1, X2, X3, X4, X5 As Integer
    Dim W1, W2, W3, W4, W5 As Integer
    Dim Y As Integer
    Public NCliente As String
    Dim TipoTicket As String
    Dim lblIdDocreferenciaAnticipo As Integer
    Dim lblNumeroDoc As Integer
    Dim ImporteSobranteMN As Decimal
    Dim ImporteTotalMN As Decimal
    Dim ImporteTotalME As Decimal
    Dim estadoImpresion As Integer
    Public Property ListaAsientonTransito As New List(Of asiento)
    Dim contadorAutomatico As Integer = 0
    Dim UcConfigCaja As New ucConfiguracionCaja
    Dim UserControl1 As New ucConfiguracion
    Dim Sep As Char
    Dim cajaSA As New EstadosFinancierosSA
    Dim caja As New estadosFinancieros
    Dim listaCajaUsuario As New List(Of cajaUsuariodetalle)
    Dim listaDetalleProducto As New List(Of documentoventaAbarrotesDet)
    Dim cajausuario As New List(Of cajaUsuario)
    Dim saldoMN As Decimal
    Dim totalMN As Decimal
    Dim totalCobro As Decimal
    Dim idCajaUsuario As Integer
    Dim vueltoMN As Decimal = 0
    Dim vueltoME As Decimal = 0
    Dim igvModifMEVenta As Decimal = 0
    Dim Pago As String = "DC"
    Public Property TotalesXcanbeceras As TotalesXcanbecera

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtFechaCobro.Value = Date.Now
        DockingInicio()
        dgvPagos.ShowColumnHeaders = True
        GridCFG(dgvPagos)
        dgvPagos.DataSource = UbicarCajasHijas()
        cargarDatosCuentas()
        CargarCajasTipo(usuario.IDUsuario)
        CMBCajasDelUsuarioPV()
        saldoMN = DigitalGauge2.Value
    End Sub

    Public Sub New(idDocumentoVenta As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        txtFechaCobro.Value = Date.Now
        DockingInicio()
        dgvPagos.ShowColumnHeaders = True
        'cargarDatosCuentas()
        'dgvPagos.DataSource = UbicarCajasHijas()
        'CargarCajasTipo(usuario.IDUsuario)
        GridCFG(dgvPagos)
        Aplica()
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT1", Me.Text, GEstableciento.IdEstablecimiento)
        ObtenerVentaPorIdDocumento(idDocumentoVenta)
        dgvPagos.DataSource = UbicarCajasHijas()
        cargarDatosCuentas()
        CargarCajasTipo(usuario.IDUsuario)
        CMBCajasDelUsuarioPV()
        saldoMN = DigitalGauge2.Value

        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf ObtenerDetallePedido))
        thread.Start()
    End Sub

    'Public Sub New(nroDoc As Integer)

    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.
    '    'txtFechaCobro.Value = New DateTime(AnioGeneral, MesGeneral, DiaLaboral.Date.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0)
    '    txtFechaCobro.Value = Date.Now
    '    DockingInicio()
    '    dgvPagos.ShowColumnHeaders = True
    '    'cargarDatosCuentas()
    '    'dgvPagos.DataSource = UbicarCajasHijas()
    '    'CargarCajasTipo(usuario.IDUsuario)
    '    GridCFG(dgvPagos)
    '    Aplica()
    '    configuracionModulo(Gempresas.IdEmpresaRuc, "VT1", Me.Text)
    '    ObtenerVentaPorCodigo(nroDoc)
    '    txtNumeroPedido.Text = nroDoc

    '    dgvPagos.DataSource = UbicarCajasHijas()
    '    cargarDatosCuentas()
    '    CargarCajasTipo(usuario.IDUsuario)
    '    CMBCajasDelUsuarioPV()
    '    saldoMN = DigitalGauge2.Value
    'End Sub

#Region "PRINT"
    Sub llenarDatos()

        PrintPreviewDialogTicket.Document = PrintTikect

        'PrintPreviewDialog1.ShowDialog()

        ' La fuente a usar en la impresión
        prtFont = New System.Drawing.Font("Courier New", 11)
        '
        ' La configuración actual de la impresora predeterminada
        prtSettings = New PrinterSettings

    End Sub

    Private Sub imprimir(ByVal esPreview As Boolean)

        ' imprimir o mostrar el PrintPreview
        '
        If prtSettings Is Nothing Then
            prtSettings = New PrinterSettings
        End If
        '
        'If chkSelAntes.Checked Then
        If seleccionarImpresora() = False Then Return
        'End If
        '
        If prtDoc Is Nothing Then
            prtDoc = New PrintDocument
            AddHandler prtDoc.PrintPage, AddressOf prt_PrintPageSinRuc

        End If
        '
        ' resetear la línea actual
        lineaActual = 0
        '
        ' la configuración a usar en la impresión
        prtDoc.PrinterSettings = prtSettings
        '
        If esPreview Then
            Dim prtPrev As New PrintPreviewDialog
            prtPrev.PrintPreviewControl.Zoom = 1.0
            prtPrev.Document = prtDoc
            prtPrev.Text = "Previsualizar datos de Ticket" & Título
            DirectCast(prtPrev, Form).WindowState = FormWindowState.Maximized
            prtPrev.ShowDialog()
        Else
            prtDoc.Print()
        End If
    End Sub

    Private Function seleccionarImpresora() As Boolean
        Dim prtDialog As New PrintDialog
        If prtSettings Is Nothing Then
            prtSettings = New PrinterSettings
        End If

        'SELECCION DE IMPRESORA
        'With prtDialog
        '    .AllowPrintToFile = False
        '    .AllowSelection = False
        '    .AllowSomePages = False
        '    .PrintToFile = False
        '    .ShowHelp = False
        '    .ShowNetwork = True

        '    .PrinterSettings = prtSettings

        '    If .ShowDialog() = DialogResult.OK Then
        '        prtSettings = .PrinterSettings
        '    Else
        '        Return False
        '    End If

        'End With
        Return (True)
    End Function

    Sub ImprimirTicket(intIddocumento As Integer)
        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim ticket As New CrearTicket()


        Dim entidadSA As New entidadSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIddocumento)
        Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIddocumento)


        'Ya podemos usar todos sus metodos
        ticket.AbreCajon()
        'Para abrir el cajon de dinero.
        'De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

        'Datos de la cabecera del Ticket.
        ticket.TextoCentro("DISTRIBUCIONES LUPITA")
        ticket.TextoCentro("ERM NEGOCIOS SAC.")
        ticket.TextoCentro("JR. GN. SANTA CRUZ 481 INT-1506")
        ticket.TextoCentro("JESUS MARIA - LIMA PERU")
        ticket.TextoCentro("SUC: JR.SEBASTIAN LORENTE 199 TAMBO-HYO.")
        ticket.TextoCentro("R.U.C: 20601923042")
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
        ticket.ImprimirTicket("BIXOLON SRP-270")
        'Nombre de la impresora ticketera

    End Sub

    'Public Sub prt_PrintPageSinRuc(ByVal sender As Object, _
    '                        ByVal e As PrintPageEventArgs)

    '    'mostrar si existe ruc o no
    '    Dim Ruc As String = ""
    '    ' Este evento se produce cada vez que se va a imprimir una página
    '    Dim pageWidth As Integer
    '    Dim lineHeight As Single
    '    Dim yPos As Single = e.MarginBounds.Top
    '    Dim leftMargin As Single = e.MarginBounds.Left

    '    Dim printFont As System.Drawing.Font

    '    ' Asignar el tipo de letra
    '    printFont = prtFont
    '    lineHeight = printFont.GetHeight(e.Graphics)

    '    If (lineaActual < 37 And lineaActual = 0) Then

    '        '--------------------------------------------- Encabezado del reporte -------------------------------------------
    '        Dim NEmpresa As String = Gempresas.NomEmpresa & vbLf
    '        'separacion del primer titulo con la segunda linea
    '        Dim fontNEmpresa As New System.Drawing.Font("Tahoma", 9, FontStyle.Bold)
    '        e.Graphics.DrawString(NEmpresa, fontNEmpresa, _
    '                               Brushes.Black, leftMargin - 60, yPos - 100)

    '        Dim EmpresaRUC As String = "RUC  " & Gempresas.IdEmpresaRuc & vbLf
    '        Dim fontNEmpresaRUC As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        e.Graphics.DrawString(EmpresaRUC, fontNEmpresaRUC, _
    '                               Brushes.Black, leftMargin - 50, yPos - 85)

    '        Dim NDireccion As String = "Jr. Ricardo Palma #881 - Chilca" & vbLf
    '        'separacion del primer titulo con la segunda linea
    '        Dim fontNDireccion As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        e.Graphics.DrawString(NDireccion, fontNDireccion, _
    '                               Brushes.Black, leftMargin - 100, yPos - 70)

    '        Dim NNumeroComprobante As String = "3159000 - 3142020" & vbLf
    '        'separacion del primer titulo con la segunda linea
    '        Dim fontNNumeroComprobante As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        e.Graphics.DrawString(NNumeroComprobante, fontNNumeroComprobante, _
    '                               Brushes.Black, leftMargin - 50, yPos - 55)


    '        Dim NBoletaElectronica As String = "BOLETA ELECTRONICA" & vbLf
    '        'separacion del primer titulo con la segunda linea
    '        Dim fontNBoletaElectronica As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        e.Graphics.DrawString(NBoletaElectronica, fontNBoletaElectronica, _
    '                               Brushes.Black, leftMargin - 60, yPos - 40)

    '        Dim NNumeroBoleta As String = "B625 - 0238791" & vbLf
    '        'separacion del primer titulo con la segunda linea
    '        Dim fontNNumeroBoleta As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        e.Graphics.DrawString(NNumeroBoleta, fontNNumeroBoleta, _
    '                               Brushes.Black, leftMargin - 40, yPos - 25)


    '        Dim NEstablecimiento As String = GEstableciento.NombreEstablecimiento & vbLf
    '        'separacion del primer titulo con la segunda linea
    '        Dim fontNEstablecimiento As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        e.Graphics.DrawString(NEstablecimiento, fontNEstablecimiento, _
    '                               Brushes.Black, leftMargin - 100, yPos + 0)


    '        Dim NDireccionEstab As String = "Jr. Ricardo Palma #881 - Chilca" & vbLf
    '        'separacion del primer titulo con la segunda linea
    '        Dim fontNDireccionEstab As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        e.Graphics.DrawString(NDireccionEstab, fontNDireccionEstab, _
    '                               Brushes.Black, leftMargin - 100, yPos + 12)

    '        Dim NLugar As String = "CHILCA - HUANCAYO" & vbLf
    '        'separacion del primer titulo con la segunda linea
    '        Dim fontNLugar As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        e.Graphics.DrawString(NLugar, fontNLugar, _
    '                               Brushes.Black, leftMargin - 100, yPos + 25)


    '        '-----------------------------------------------------------------------------------------------------------------
    '        '------------------------------------------Segundo Encabezado datos del cliente -----------------------------------
    '        ' titulo 2 ubicacion de la hoja
    '        '10 masrgen a la izquierda
    '        ' ypos ubicacion hacia abajo del titulo primero

    '        Dim moneda As String = ""

    '        Select Case cboMoneda.SelectedValue
    '            Case 2
    '                moneda = "EXTRANJERA"
    '            Case 1
    '                moneda = "NACIONAL"
    '        End Select

    '        Dim cobroMn As Decimal
    '        Dim cobroME As Decimal
    '        Dim vueltoMN As Decimal
    '        Dim vueltoME As Decimal

    '        For Each item As Record In dgvPagos.Table.Records
    '            cobroMn += item.GetValue("importePendiente")
    '            vueltoMN += item.GetValue("vueltoMN")
    '            vueltoME += item.GetValue("vueltoME")
    '        Next

    '        If (TipoTicket = "ConRUC") Then

    '            Select Case estadoImpresion
    '                Case 1
    '                    NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now & _
    '                       vbCrLf & "CORRELATIVO: " & txtNumeroPedido.Text & _
    '                       vbCrLf & "CAJA/TURNO: " & idCajaUsuario & _
    '                       vbCrLf & "TIPO MONEDA: " & moneda & _
    '                       vbCrLf & "------------------------------------------------------------"
    '                Case Else
    '                    NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now & _
    '                    vbCrLf & "CORRELATIVO: " & txtNumeroPedido.Text & _
    '                    vbCrLf & "CAJA/TURNO: " & idCajaUsuario & _
    '                    vbCrLf & "TIPO MONEDA: " & moneda & _
    '                    vbCrLf & "------------------------------------------------------------"

    '            End Select


    '            Dim fontNCliente As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
    '            e.Graphics.DrawString(NCliente, fontNCliente, Brushes.Black, leftMargin - 100, yPos + 20)


    '            'Dim NLinea As String = "----------------------------------------------------------" & vbLf
    '            ''separacion del primer titulo con la segunda linea
    '            'Dim fontNLinea As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
    '            'e.Graphics.DrawString(NLinea, fontNLinea, _
    '            '                       Brushes.Black, leftMargin - 100, yPos + 10)

    '            'margen a la derecha de toda la lista
    '            X1 = PrintTikect.DefaultPageSettings.Margins.Left + 85
    '            With PrintTikect.DefaultPageSettings
    '                pageWidth = (.PaperSize.Width) - (.Margins.Left + 10) - (.Margins.Right)
    '                If .Landscape Then
    '                    pageWidth = .PaperSize.Height - (.Margins.Top) - (.Margins.Bottom)
    '                End If
    '            End With
    '            'tamaño de la primera celda cantidad
    '            X2 = X1 + 17
    '            'tamaño de la segunda celda
    '            X3 = CInt(X2 + pageWidth * 3)

    '            X4 = X1 + 5
    '            X5 = X1 + 20

    '            W1 = (X2 - X1)
    '            W2 = (X3 - X2)
    '            W4 = (X3 - X2)
    '            W5 = (X3 - X2)
    '            W3 = pageWidth - W1 - W2

    '            'If itm < lsvDetalle.Items.Count Then
    '            'ubicacion para abajo
    '            Y = PrintTikect.DefaultPageSettings.Margins.Top + 115
    '            Dim fontNColumna As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
    '            ' Draw the column headers at the top of the page
    '            'ubicacion de las columnas para la izquierda
    '            e.Graphics.DrawString("Cant", fontNColumna, Brushes.Black, X1 - 187, Y + 5)
    '            e.Graphics.DrawString("Producto", fontNColumna, Brushes.Black, X2 - 175, Y + 5)
    '            e.Graphics.DrawString("P.U.", fontNColumna, Brushes.Black, X3 - 175, Y + 5)
    '            e.Graphics.DrawString("Total", fontNColumna, Brushes.Black, X4 + 2, Y + 5)
    '            ' Advance the Y coordinate for the first text line on the printout
    '            Y = Y + 20
    '            'End If
    '            Dim ii As Integer = 0
    '            Dim ultimaFila As Integer = 0

    '            For Each i As Record In dgvVenta.Table.Records

    '                ' extract each item's text into the str variable
    '                Dim str As String
    '                str = (CDbl(i.GetValue("cantidad")))

    '                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, X1 - 180, Y)

    '                str = i.GetValue("item")
    '                Dim R As New RectangleF(X2 - 175, Y, W2, 80)
    '                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, R)

    '                Dim lines, cols As Integer
    '                e.Graphics.MeasureString(str, fontNCabecera, New SizeF(W2, 50), New StringFormat, cols, lines)
    '                Dim subitm As Integer, Yc As Integer
    '                Yc = Y

    '                str = Math.Round(CDbl(i.GetValue("totalmn")) / CDbl(i.GetValue("cantidad")), 2)
    '                Dim R2 As New RectangleF(X4 - 45, Y, W4, 80)
    '                e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R2)

    '                str = Math.Round(CDec(i.GetValue("totalmn")), 2)
    '                Dim R3 As New RectangleF(X5 - 13, Y, W5, 80)
    '                e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R3)

    '                Dim conteo As Integer

    '                For subitm = 1 To 1
    '                    str = i.GetValue("idProducto")
    '                    'str = i.SubItems(subitm).Text
    '                    'conteo = 0
    '                    conteo = (str.Length / 2)
    '                    Dim strformat As New StringFormat
    '                    strformat.Trimming = StringTrimming.EllipsisCharacter
    '                    Yc = Yc + fontNCabecera.Height + 2
    '                Next
    '                Y = Y + lines * fontNCabecera.Height + (conteo + 2)
    '                Y = Math.Max(Y, Yc)

    '                With PrintTikect.DefaultPageSettings
    '                    If (Not e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Height - .Margins.Bottom))) Or _
    '                     (e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Width - .Margins.Bottom))) Then
    '                        e.HasMorePages = True
    '                        ii += 1
    '                        Exit Sub
    '                    Else
    '                        ii += 1
    '                        e.HasMorePages = False
    '                    End If
    '                End With

    '            Next

    '            Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------------------------------------------"
    '            Dim fontNLinea1 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin - 100, Y - 20)


    '            'Dim sumaPagos As String
    '            'Dim NIgv As String = vbCrLf & vbCrLf & "Redo S/.           " & CDec(0.0).ToString("N2")
    '            'Dim fontNIgv As New System.Drawing.Font("Tahoma", 4, FontStyle.Regular)
    '            'e.Graphics.DrawString(NIgv, fontNCliente, Brushes.Black, leftMargin + 40, Y - 0)

    '            'Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------"
    '            'Dim fontNLinea1 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin + 10, Y - 10)

    '            Dim NTotalPagar As String = vbCrLf & vbCrLf & "Sub Total S/. " & txtCobroMN.DecimalValue
    '            Dim fontNTotalPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NTotalPagar, fontNTotalPagar, Brushes.Black, leftMargin + 40, Y - 0)

    '            'For Each i In dgvPagos.Table.Records
    '            '    sumaPagos += CDbl(i.GetValue("montoMN"))
    '            'Next

    '            'Dim NExonerada As String = vbCrLf & vbCrLf & "Op. Exonerada                                                   " & CDec(vueltoMN).ToString("N2")
    '            'Dim fontNExonerada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NExonerada, fontNExonerada, Brushes.Black, leftMargin - 100, Y + 35)

    '            'Dim NIanfecta As String = vbCrLf & vbCrLf & "Op. Inafecta                                                      " & CDec(vueltoMN).ToString("N2")
    '            'Dim fontNIanfecta As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NIanfecta, fontNIanfecta, Brushes.Black, leftMargin - 100, Y + 50)

    '            'Dim NGravada As String = vbCrLf & vbCrLf & "Op. Gravada                                                      " & CDec(vueltoMN).ToString("N2")
    '            'Dim fontNGravada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NGravada, fontNGravada, Brushes.Black, leftMargin - 100, Y + 65)

    '            'Dim NIGVE As String = vbCrLf & vbCrLf & "I.G.V.                S/.                                            " & CDec(vueltoMN).ToString("N2")
    '            'Dim fontNIGVE As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NIGVE, fontNIGVE, Brushes.Black, leftMargin - 100, Y + 80)

    '            'Dim NTotal As String = vbCrLf & vbCrLf & "Importe Total     S/.                                            " & CDec(vueltoMN).ToString("N2")
    '            'Dim fontNTotal As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NTotal, fontNTotal, Brushes.Black, leftMargin - 100, Y + 95)
    '            'Dim NREdondedo As String = vbCrLf & vbCrLf & "Redondeo          S/.                                            " & CDec(vueltoMN).ToString("N2")
    '            'Dim fontNREdondedo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NREdondedo, fontNREdondedo, Brushes.Black, leftMargin - 100, Y + 110)

    '            'Dim NDonacion As String = vbCrLf & vbCrLf & "Donación           S/.                                            " & CDec(vueltoMN).ToString("N2")
    '            'Dim fontNDonacion As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NDonacion, fontNDonacion, Brushes.Black, leftMargin - 100, Y + 125)

    '            'Dim NDImporPagar As String = vbCrLf & vbCrLf & "Importa a Pagar S/.                                            " & CDec(vueltoMN).ToString("N2")
    '            'Dim fontNDImporPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NDImporPagar, fontNDImporPagar, Brushes.Black, leftMargin - 100, Y + 140)

    '            'Dim NLinea2 As String = "----------------------------------------------------------------"
    '            'Dim fontNLinea2 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NLinea2, fontNLinea2, Brushes.Black, leftMargin - 90, Y + 53)

    '            Dim NExonerada As String = vbCrLf & vbCrLf & "Op. Exonerada                                                   " & CDec(TotalesXcanbeceras.BaseMN).ToString("N2")
    '            Dim fontNExonerada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NExonerada, fontNExonerada, Brushes.Black, leftMargin - 100, Y + 35)

    '            Dim NIanfecta As String = vbCrLf & vbCrLf & "Op. Inafecta                                                      " & CDec(TotalesXcanbeceras.BaseMN2).ToString("N2")
    '            Dim fontNIanfecta As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NIanfecta, fontNIanfecta, Brushes.Black, leftMargin - 100, Y + 50)

    '            Dim NGravada As String = vbCrLf & vbCrLf & "Op. Gravada                                                      " & CDec(TotalesXcanbeceras.BaseMN3).ToString("N2")
    '            Dim fontNGravada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NGravada, fontNGravada, Brushes.Black, leftMargin - 100, Y + 65)

    '            Dim NIGVE As String = vbCrLf & vbCrLf & "I.G.V. S/.                                                          " & CDec(TotalesXcanbeceras.IgvMN).ToString("N2")
    '            Dim fontNIGVE As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NIGVE, fontNIGVE, Brushes.Black, leftMargin - 100, Y + 80)

    '            Dim NREdondedo As String = vbCrLf & vbCrLf & "Redondeo S/.                                                     " & CDec(TotalesXcanbeceras.PercepcionMN).ToString("N2")
    '            Dim fontNREdondedo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NREdondedo, fontNREdondedo, Brushes.Black, leftMargin - 100, Y + 95)

    '            Dim NDonacion As String = vbCrLf & vbCrLf & "Donación S/.                                                      " & CDec(0.0).ToString("N2")
    '            Dim fontNDonacion As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NDonacion, fontNDonacion, Brushes.Black, leftMargin - 100, Y + 110)

    '            Dim NDImporPagar As String = vbCrLf & vbCrLf & "Importa a Pagar S/.                                            " & CDec(DigitalGauge2.Value).ToString("N2")
    '            Dim fontNDImporPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NDImporPagar, fontNDImporPagar, Brushes.Black, leftMargin - 100, Y + 125)

    '            Dim NImporteRecibido As String = vbCrLf & vbCrLf & "Importe Recibido S/.                                           " & CDec(cobroMn).ToString("N2")
    '            Dim fontNImporteRecibido As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NImporteRecibido, fontNImporteRecibido, Brushes.Black, leftMargin - 100, Y + 140)

    '            Dim NVuelto As String = vbCrLf & vbCrLf & "Vuelto S/.                                                          " & CDec(vueltoMN).ToString("N2")
    '            Dim fontNVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NVuelto, fontNVuelto, Brushes.Black, leftMargin - 100, Y + 155)


    '            Select Case estadoImpresion
    '                Case 1
    '                    'Dim NSon As String = vbCrLf & vbCrLf & "SON: " & txtCobroMN.DecimalValue & " CON 00/100 Soles"
    '                    'Dim fontNSon As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    'e.Graphics.DrawString(NSon, fontNSon, Brushes.Black, leftMargin - 100, Y + 170)

    '                    'Dim NEfectivo As String = vbCrLf & vbCrLf & "EFECTIVO SOLES: " & txtCobroMN.DecimalValue & " (Soles)"
    '                    'Dim fontNEfectivo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    'e.Graphics.DrawString(NEfectivo, fontNEfectivo, Brushes.Black, leftMargin - 100, Y + 185)

    '                    'Dim NVuelto As String = vbCrLf & vbCrLf & "VUELTO:  S/. " & vueltoMN
    '                    'Dim fontNVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    'e.Graphics.DrawString(NVuelto, fontNVuelto, Brushes.Black, leftMargin - 100, Y + 200)

    '                    'Dim NCAjero As String = vbCrLf & vbCrLf & "CAJERO: " & "MAYKOL"
    '                    'Dim fontNCAjero As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    'e.Graphics.DrawString(NCAjero, fontNCAjero, Brushes.Black, leftMargin - 100, Y + 215)

    '                    'Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & "MAYKOL"
    '                    'Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    'e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 100, Y + 230)
    '                    Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & "MAYKOL"
    '                    Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 100, Y + 180)
    '                Case Else
    '                    Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & "MAYKOL"
    '                    Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 100, Y + 180)
    '                    'Dim NSon As String = vbCrLf & vbCrLf & "SON: " & txtCobroMN.DecimalValue & " CON 00/100 Soles"
    '                    'Dim fontNSon As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    'e.Graphics.DrawString(NSon, fontNSon, Brushes.Black, leftMargin - 100, Y + 170)

    '                    'Dim NEfectivo As String = vbCrLf & vbCrLf & "EFECTIVO SOLES: " & txtCobroMN.DecimalValue & " (Soles)"
    '                    'Dim fontNEfectivo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    'e.Graphics.DrawString(NEfectivo, fontNEfectivo, Brushes.Black, leftMargin - 100, Y + 185)

    '                    'Dim NVuelto As String = vbCrLf & vbCrLf & "VUELTO:  S/. " & vueltoMN
    '                    'Dim fontNVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    'e.Graphics.DrawString(NVuelto, fontNVuelto, Brushes.Black, leftMargin - 100, Y + 200)

    '                    'Dim NCAjero As String = vbCrLf & vbCrLf & "CAJERO: " & "MAYKOL"
    '                    'Dim fontNCAjero As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    'e.Graphics.DrawString(NCAjero, fontNCAjero, Brushes.Black, leftMargin - 100, Y + 215)

    '                    'Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & "MAYKOL"
    '                    'Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    'e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 100, Y + 230)
    '            End Select

    '            'Dim NFijar As String = "ANTES DE RETIRARSE VERIFIQUE SU DINERO" & _
    '            'vbCrLf & "GRACIAS. EVITEMOS MOLESTIAS INNECESARIAS"
    '            'Dim fontNFijar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NFijar, fontNFijar, Brushes.Black, leftMargin - 82, Y + 75)

    '            e.HasMorePages = False

    '        ElseIf (TipoTicket = "SinRUC") Then

    '            Select Case estadoImpresion
    '                Case 1
    '                    NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now & _
    '                       vbCrLf & "CORRELATIVO: " & txtNumeroPedido.Text & _
    '                       vbCrLf & "CAJA/TURNO: " & idCajaUsuario & _
    '                       vbCrLf & "TIPO MONEDA: " & moneda & _
    '                       vbCrLf & "------------------------------------------------------------"
    '                Case Else
    '                    NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now & _
    '                    vbCrLf & "CORRELATIVO: " & txtNumeroPedido.Text & _
    '                    vbCrLf & "CAJA/TURNO: " & idCajaUsuario & _
    '                    vbCrLf & "TIPO MONEDA: " & moneda & _
    '                    vbCrLf & "------------------------------------------------------------"

    '            End Select


    '            Dim fontNCliente As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
    '            e.Graphics.DrawString(NCliente, fontNCliente, Brushes.Black, leftMargin - 100, yPos + 20)


    '            'Dim NLinea As String = "----------------------------------------------------------" & vbLf
    '            ''separacion del primer titulo con la segunda linea
    '            'Dim fontNLinea As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
    '            'e.Graphics.DrawString(NLinea, fontNLinea, _
    '            '                       Brushes.Black, leftMargin - 100, yPos + 10)

    '            'margen a la derecha de toda la lista
    '            X1 = PrintTikect.DefaultPageSettings.Margins.Left + 85
    '            With PrintTikect.DefaultPageSettings
    '                pageWidth = (.PaperSize.Width) - (.Margins.Left + 10) - (.Margins.Right)
    '                If .Landscape Then
    '                    pageWidth = .PaperSize.Height - (.Margins.Top) - (.Margins.Bottom)
    '                End If
    '            End With
    '            'tamaño de la primera celda cantidad
    '            X2 = X1 + 17
    '            'tamaño de la segunda celda
    '            X3 = CInt(X2 + pageWidth * 3)

    '            X4 = X1 + 5
    '            X5 = X1 + 20

    '            W1 = (X2 - X1)
    '            W2 = (X3 - X2)
    '            W4 = (X3 - X2)
    '            W5 = (X3 - X2)
    '            W3 = pageWidth - W1 - W2

    '            'If itm < lsvDetalle.Items.Count Then
    '            'ubicacion para abajo
    '            Y = PrintTikect.DefaultPageSettings.Margins.Top + 115
    '            Dim fontNColumna As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
    '            ' Draw the column headers at the top of the page
    '            'ubicacion de las columnas para la izquierda
    '            e.Graphics.DrawString("Cant", fontNColumna, Brushes.Black, X1 - 187, Y + 5)
    '            e.Graphics.DrawString("Producto", fontNColumna, Brushes.Black, X2 - 175, Y + 5)
    '            e.Graphics.DrawString("P.U.", fontNColumna, Brushes.Black, X3 - 175, Y + 5)
    '            e.Graphics.DrawString("Total", fontNColumna, Brushes.Black, X4 + 2, Y + 5)
    '            ' Advance the Y coordinate for the first text line on the printout
    '            Y = Y + 20
    '            'End If
    '            Dim ii As Integer = 0
    '            Dim ultimaFila As Integer = 0

    '            For Each i As Record In dgvVenta.Table.Records

    '                ' extract each item's text into the str variable
    '                Dim str As String
    '                str = (CDbl(i.GetValue("cantidad")))

    '                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, X1 - 180, Y)

    '                str = i.GetValue("item")
    '                Dim R As New RectangleF(X2 - 175, Y, W2, 80)
    '                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, R)

    '                Dim lines, cols As Integer
    '                e.Graphics.MeasureString(str, fontNCabecera, New SizeF(W2, 50), New StringFormat, cols, lines)
    '                Dim subitm As Integer, Yc As Integer
    '                Yc = Y

    '                str = Math.Round(CDbl(i.GetValue("totalmn")) / CDbl(i.GetValue("cantidad")), 2)
    '                Dim R2 As New RectangleF(X4 - 45, Y, W4, 80)
    '                e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R2)

    '                str = Math.Round(CDec(i.GetValue("totalmn")), 2)
    '                Dim R3 As New RectangleF(X5 - 13, Y, W5, 80)
    '                e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R3)

    '                Dim conteo As Integer

    '                For subitm = 1 To 1
    '                    str = i.GetValue("idProducto")
    '                    'str = i.SubItems(subitm).Text
    '                    'conteo = 0
    '                    conteo = (str.Length / 2)
    '                    Dim strformat As New StringFormat
    '                    strformat.Trimming = StringTrimming.EllipsisCharacter
    '                    Yc = Yc + fontNCabecera.Height + 2
    '                Next
    '                Y = Y + lines * fontNCabecera.Height + (conteo + 2)
    '                Y = Math.Max(Y, Yc)

    '                With PrintTikect.DefaultPageSettings
    '                    If (Not e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Height - .Margins.Bottom))) Or _
    '                     (e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Width - .Margins.Bottom))) Then
    '                        e.HasMorePages = True
    '                        ii += 1
    '                        Exit Sub
    '                    Else
    '                        ii += 1
    '                        e.HasMorePages = False
    '                    End If
    '                End With

    '            Next

    '            Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------------------------------------------"
    '            Dim fontNLinea1 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin - 100, Y - 20)


    '            'Dim sumaPagos As String
    '            'Dim NIgv As String = vbCrLf & vbCrLf & "Redo S/.           " & CDec(0.0).ToString("N2")
    '            'Dim fontNIgv As New System.Drawing.Font("Tahoma", 4, FontStyle.Regular)
    '            'e.Graphics.DrawString(NIgv, fontNCliente, Brushes.Black, leftMargin + 40, Y - 0)

    '            'Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------"
    '            'Dim fontNLinea1 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin + 10, Y - 10)

    '            Dim NTotalPagar As String = vbCrLf & vbCrLf & "Sub Total S/. " & txtCobroMN.DecimalValue
    '            Dim fontNTotalPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NTotalPagar, fontNTotalPagar, Brushes.Black, leftMargin + 40, Y - 0)

    '            'For Each i In dgvPagos.Table.Records
    '            '    sumaPagos += CDbl(i.GetValue("montoMN"))
    '            'Next

    '            Dim NExonerada As String = vbCrLf & vbCrLf & "Op. Exonerada                                                   " & CDec(TotalesXcanbeceras.BaseMN).ToString("N2")
    '            Dim fontNExonerada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NExonerada, fontNExonerada, Brushes.Black, leftMargin - 100, Y + 35)

    '            Dim NIanfecta As String = vbCrLf & vbCrLf & "Op. Inafecta                                                      " & CDec(TotalesXcanbeceras.BaseMN2).ToString("N2")
    '            Dim fontNIanfecta As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NIanfecta, fontNIanfecta, Brushes.Black, leftMargin - 100, Y + 50)

    '            Dim NGravada As String = vbCrLf & vbCrLf & "Op. Gravada                                                      " & CDec(TotalesXcanbeceras.BaseMN3).ToString("N2")
    '            Dim fontNGravada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NGravada, fontNGravada, Brushes.Black, leftMargin - 100, Y + 65)

    '            Dim NIGVE As String = vbCrLf & vbCrLf & "I.G.V. S/.                                                          " & CDec(TotalesXcanbeceras.IgvMN).ToString("N2")
    '            Dim fontNIGVE As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NIGVE, fontNIGVE, Brushes.Black, leftMargin - 100, Y + 80)

    '            Dim NREdondedo As String = vbCrLf & vbCrLf & "Redondeo S/.                                                     " & CDec(TotalesXcanbeceras.PercepcionMN).ToString("N2")
    '            Dim fontNREdondedo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NREdondedo, fontNREdondedo, Brushes.Black, leftMargin - 100, Y + 95)

    '            Dim NDonacion As String = vbCrLf & vbCrLf & "Donación S/.                                                      " & CDec(0.0).ToString("N2")
    '            Dim fontNDonacion As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NDonacion, fontNDonacion, Brushes.Black, leftMargin - 100, Y + 110)

    '            Dim NDImporPagar As String = vbCrLf & vbCrLf & "Importa a Pagar S/.                                            " & CDec(DigitalGauge2.Value).ToString("N2")
    '            Dim fontNDImporPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NDImporPagar, fontNDImporPagar, Brushes.Black, leftMargin - 100, Y + 125)

    '            Dim NImporteRecibido As String = vbCrLf & vbCrLf & "Importe Recibido S/.                                           " & CDec(cobroMn).ToString("N2")
    '            Dim fontNImporteRecibido As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NImporteRecibido, fontNImporteRecibido, Brushes.Black, leftMargin - 100, Y + 140)

    '            Dim NVuelto As String = vbCrLf & vbCrLf & "Vuelto S/.                                                          " & CDec(vueltoMN).ToString("N2")
    '            Dim fontNVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NVuelto, fontNVuelto, Brushes.Black, leftMargin - 100, Y + 155)


    '            'Dim NExonerada As String = vbCrLf & vbCrLf & "Op. Exonerada                                                   " & CDec(vueltoMN).ToString("N2")
    '            'Dim fontNExonerada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NExonerada, fontNExonerada, Brushes.Black, leftMargin - 100, Y + 35)

    '            'Dim NIanfecta As String = vbCrLf & vbCrLf & "Op. Inafecta                                                      " & CDec(vueltoMN).ToString("N2")
    '            'Dim fontNIanfecta As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NIanfecta, fontNIanfecta, Brushes.Black, leftMargin - 100, Y + 50)

    '            'Dim NGravada As String = vbCrLf & vbCrLf & "Op. Gravada                                                      " & CDec(vueltoMN).ToString("N2")
    '            'Dim fontNGravada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NGravada, fontNGravada, Brushes.Black, leftMargin - 100, Y + 65)

    '            'Dim NIGVE As String = vbCrLf & vbCrLf & "I.G.V.                S/.                                            " & CDec(vueltoMN).ToString("N2")
    '            'Dim fontNIGVE As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NIGVE, fontNIGVE, Brushes.Black, leftMargin - 100, Y + 80)

    '            'Dim NTotal As String = vbCrLf & vbCrLf & "Importe Total     S/.                                            " & CDec(vueltoMN).ToString("N2")
    '            'Dim fontNTotal As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NTotal, fontNTotal, Brushes.Black, leftMargin - 100, Y + 95)
    '            'Dim NREdondedo As String = vbCrLf & vbCrLf & "Redondeo          S/.                                            " & CDec(vueltoMN).ToString("N2")
    '            'Dim fontNREdondedo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NREdondedo, fontNREdondedo, Brushes.Black, leftMargin - 100, Y + 110)

    '            'Dim NDonacion As String = vbCrLf & vbCrLf & "Donación           S/.                                            " & CDec(vueltoMN).ToString("N2")
    '            'Dim fontNDonacion As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NDonacion, fontNDonacion, Brushes.Black, leftMargin - 100, Y + 125)

    '            'Dim NDImporPagar As String = vbCrLf & vbCrLf & "Importa a Pagar S/.                                            " & CDec(vueltoMN).ToString("N2")
    '            'Dim fontNDImporPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NDImporPagar, fontNDImporPagar, Brushes.Black, leftMargin - 100, Y + 140)

    '            'Dim NLinea2 As String = "----------------------------------------------------------------"
    '            'Dim fontNLinea2 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NLinea2, fontNLinea2, Brushes.Black, leftMargin - 90, Y + 53)


    '            Select Case estadoImpresion
    '                Case 1
    '                    Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & "MAYKOL"
    '                    Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 100, Y + 180)
    '                    'Dim NSon As String = vbCrLf & vbCrLf & "SON: " & txtCobroMN.DecimalValue & " CON 00/100 Soles"
    '                    'Dim fontNSon As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    'e.Graphics.DrawString(NSon, fontNSon, Brushes.Black, leftMargin - 100, Y + 170)

    '                    'Dim NEfectivo As String = vbCrLf & vbCrLf & "EFECTIVO SOLES: " & txtCobroMN.DecimalValue & " (Soles)"
    '                    'Dim fontNEfectivo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    'e.Graphics.DrawString(NEfectivo, fontNEfectivo, Brushes.Black, leftMargin - 100, Y + 185)

    '                    'Dim NVuelto As String = vbCrLf & vbCrLf & "VUELTO:  S/. " & vueltoMN
    '                    'Dim fontNVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    'e.Graphics.DrawString(NVuelto, fontNVuelto, Brushes.Black, leftMargin - 100, Y + 200)

    '                    'Dim NCAjero As String = vbCrLf & vbCrLf & "CAJERO: " & "MAYKOL"
    '                    'Dim fontNCAjero As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    'e.Graphics.DrawString(NCAjero, fontNCAjero, Brushes.Black, leftMargin - 100, Y + 215)

    '                    'Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & "MAYKOL"
    '                    'Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    'e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 100, Y + 230)
    '                Case Else
    '                    Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & "MAYKOL"
    '                    Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 100, Y + 180)
    '                    '        Dim NSon As String = vbCrLf & vbCrLf & "SON: " & txtCobroMN.DecimalValue & " CON 00/100 Soles"
    '                    '        Dim fontNSon As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    '        e.Graphics.DrawString(NSon, fontNSon, Brushes.Black, leftMargin - 100, Y + 170)

    '                    '        Dim NEfectivo As String = vbCrLf & vbCrLf & "EFECTIVO SOLES: " & txtCobroMN.DecimalValue & " (Soles)"
    '                    '        Dim fontNEfectivo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    '        e.Graphics.DrawString(NEfectivo, fontNEfectivo, Brushes.Black, leftMargin - 100, Y + 185)

    '                    '        Dim NVuelto As String = vbCrLf & vbCrLf & "VUELTO:  S/. " & vueltoMN
    '                    '        Dim fontNVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    '        e.Graphics.DrawString(NVuelto, fontNVuelto, Brushes.Black, leftMargin - 100, Y + 200)

    '                    '        Dim NCAjero As String = vbCrLf & vbCrLf & "CAJERO: " & "MAYKOL"
    '                    '        Dim fontNCAjero As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    '        e.Graphics.DrawString(NCAjero, fontNCAjero, Brushes.Black, leftMargin - 100, Y + 215)

    '                    '        Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & "MAYKOL"
    '                    '        Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    '        e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 100, Y + 230)
    '            End Select

    '            'Dim NFijar As String = "ANTES DE RETIRARSE VERIFIQUE SU DINERO" & _
    '            'vbCrLf & "GRACIAS. EVITEMOS MOLESTIAS INNECESARIAS"
    '            'Dim fontNFijar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NFijar, fontNFijar, Brushes.Black, leftMargin - 82, Y + 75)

    '            e.HasMorePages = False

    '        End If

    '    End If



    'End Sub


    Public Sub prt_PrintPageSinRuc(ByVal sender As Object,
                           ByVal e As PrintPageEventArgs)

        'mostrar si existe ruc o no
        Dim Ruc As String = ""
        ' Este evento se produce cada vez que se va a imprimir una página
        Dim pageWidth As Integer
        Dim lineHeight As Single
        Dim yPos As Single = e.MarginBounds.Top
        Dim leftMargin As Single = e.MarginBounds.Left

        Dim printFont As System.Drawing.Font

        ' Asignar el tipo de letra
        printFont = prtFont
        lineHeight = printFont.GetHeight(e.Graphics)

        If (lineaActual < 37 And lineaActual = 0) Then

            '--------------------------------------------- Encabezado del reporte -------------------------------------------
            Dim NEmpresa As String = "DISTRIBUCIONES LUPITA" & vbLf
            'separacion del primer titulo con la segunda linea
            Dim fontNEmpresa As New System.Drawing.Font("Tahoma", 9, FontStyle.Bold)
            e.Graphics.DrawString(NEmpresa, fontNEmpresa,
                                   Brushes.Black, leftMargin - 50, yPos - 100)

            Dim EmpresaRUC As String = "ERM NEGOCIOS SAC." & vbLf
            Dim fontNEmpresaRUC As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            e.Graphics.DrawString(EmpresaRUC, fontNEmpresaRUC,
                                   Brushes.Black, leftMargin - 20, yPos - 85)

            Dim NDireccion As String = "Jr. Genr. Santa cruz 481 int-1506 " & vbCrLf

            Dim fontNDireccion As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            e.Graphics.DrawString(NDireccion, fontNDireccion,
                                   Brushes.Black, leftMargin - 70, yPos - 70)

            Dim NDireccion2 As String = "Jesus María - Lima"

            Dim fontNDireccion2 As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            e.Graphics.DrawString(NDireccion2, fontNDireccion2,
                                   Brushes.Black, leftMargin - 20, yPos - 55)

            Dim NDireccion3 As String = "Suc. Jr. Sebastian Lorente 199 El Tambo Hyo."


            'separacion del primer titulo con la segunda linea
            Dim fontNDireccion3 As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            e.Graphics.DrawString(NDireccion3, fontNDireccion3,
                                   Brushes.Black, leftMargin - 80, yPos - 42)


            Dim NDireccion4 As String = "RUC N°20601923042"
            Dim fontNDireccion4 As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            e.Graphics.DrawString(NDireccion4, fontNDireccion4,
                                   Brushes.Black, leftMargin - 35, yPos - 25)

            Dim NLineaa As String = "------------------------------------------------------------"
            'separacion del primer titulo con la segunda linea
            Dim fontNLineaa As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            e.Graphics.DrawString(NLineaa, fontNLineaa,
                                   Brushes.Black, leftMargin - 100, yPos - 10)

            If (TipoTicket = "ConRUC") Then
                Dim NBoletaElectronica As String = "Cliente: " & txtCliente.Text
                'separacion del primer titulo con la segunda linea
                Dim fontNBoletaElectronica As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
                e.Graphics.DrawString(NBoletaElectronica, fontNBoletaElectronica,
                                       Brushes.Black, leftMargin - 100, yPos - 0)

                Dim NRuc As String = "Ruc: " & txtRuc.Text
                'separacion del primer titulo con la segunda linea
                Dim fontNRuc As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
                e.Graphics.DrawString(NRuc, fontNRuc,
                                       Brushes.Black, leftMargin - 100, yPos + 20)


                Dim NNumeroBoleta As String = "Nro. doc: " & txtSerVenta.Text & "-" & txtnroVenta.Text
                'separacion del primer titulo con la segunda linea
                Dim fontNNumeroBoleta As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
                e.Graphics.DrawString(NNumeroBoleta, fontNNumeroBoleta,
                                       Brushes.Black, leftMargin - 100, yPos + 40)

                Dim NNumeroComprobante As String = "Código Máquina Reg.: USAFIKA12050121" & vbLf
                'separacion del primer titulo con la segunda linea
                Dim fontNNumeroComprobante As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
                e.Graphics.DrawString(NNumeroComprobante, fontNNumeroComprobante,
                                       Brushes.Black, leftMargin - 100, yPos + 60)


                Dim NCaja As String = "Caja: " & usuario.CustomUsuario.Nombres
                'separacion del primer titulo con la segunda linea
                Dim fontNCaja As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
                e.Graphics.DrawString(NCaja, fontNCaja,
                                       Brushes.Black, leftMargin - 100, yPos + 80)


                Dim NFecha As String = "Fecha: " & DiaLaboral
                'separacion del primer titulo con la segunda linea
                Dim fontNFecha As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
                e.Graphics.DrawString(NFecha, fontNFecha,
                                       Brushes.Black, leftMargin - 100, yPos + 100)

                Dim NLinea2 As String = "------------------------------------------------------------"
                'separacion del primer titulo con la segunda linea
                Dim fontNLinea2 As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
                e.Graphics.DrawString(NLinea2, fontNLinea2,
                                       Brushes.Black, leftMargin - 100, yPos + 120)

            Else

                Dim NBoletaElectronica As String = "Cliente: " & txtComprador.Text
                'separacion del primer titulo con la segunda linea
                Dim fontNBoletaElectronica As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
                e.Graphics.DrawString(NBoletaElectronica, fontNBoletaElectronica,
                                       Brushes.Black, leftMargin - 100, yPos - 0)

                Dim NNumeroBoleta As String = "Nro. doc: " & txtSerVenta.Text & "-" & txtnroVenta.Text
                'separacion del primer titulo con la segunda linea
                Dim fontNNumeroBoleta As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
                e.Graphics.DrawString(NNumeroBoleta, fontNNumeroBoleta,
                                       Brushes.Black, leftMargin - 100, yPos + 20)

                Dim NNumeroComprobante As String = "Código Máquina Reg.: USAFIKA12050121" & vbLf
                'separacion del primer titulo con la segunda linea
                Dim fontNNumeroComprobante As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
                e.Graphics.DrawString(NNumeroComprobante, fontNNumeroComprobante,
                                       Brushes.Black, leftMargin - 100, yPos + 40)


                Dim NCaja As String = "Caja: " & usuario.CustomUsuario.Nombres
                'separacion del primer titulo con la segunda linea
                Dim fontNCaja As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
                e.Graphics.DrawString(NCaja, fontNCaja,
                                       Brushes.Black, leftMargin - 100, yPos + 60)


                Dim NFecha As String = "Fecha: " & DiaLaboral
                'separacion del primer titulo con la segunda linea
                Dim fontNFecha As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
                e.Graphics.DrawString(NFecha, fontNFecha,
                                       Brushes.Black, leftMargin - 100, yPos + 80)

                Dim NLinea2 As String = "------------------------------------------------------------"
                'separacion del primer titulo con la segunda linea
                Dim fontNLinea2 As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
                e.Graphics.DrawString(NLinea2, fontNLinea2,
                                       Brushes.Black, leftMargin - 100, yPos + 100)

            End If





            '-----------------------------------------------------------------------------------------------------------------
            '------------------------------------------Segundo Encabezado datos del cliente -----------------------------------
            ' titulo 2 ubicacion de la hoja
            '10 masrgen a la izquierda
            ' ypos ubicacion hacia abajo del titulo primero

            Dim moneda As String = ""

            Select Case cboMoneda.SelectedValue
                Case 2
                    moneda = "EXTRANJERA"
                Case 1
                    moneda = "NACIONAL"
            End Select

            Dim cobroMn As Decimal
            'Dim cobroME As Decimal
            Dim vueltoMN As Decimal
            Dim vueltoME As Decimal

            For Each item As Record In dgvPagos.Table.Records
                cobroMn += item.GetValue("importePendiente")
                vueltoMN += item.GetValue("vueltoMN")
                vueltoME += item.GetValue("vueltoME")
            Next

            '    If (TipoTicket = "ConRUC") Then
            ' &                            vbCrLf & "CAJA/TURNO: " & idCajaUsuario & _
            'vbCrLf & "TIPO MONEDA: " & moneda & _
            Select Case estadoImpresion
                Case 1
                    NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now &
                       vbCrLf & "CORRELATIVO: " & txtNumeroPedido.Text &
                       vbCrLf & "------------------------------------------------------------"
                Case Else
                    NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now &
                    vbCrLf & "CORRELATIVO: " & txtNumeroPedido.Text &
                    vbCrLf & "------------------------------------------------------------"

            End Select


            'Dim fontNCliente As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            'e.Graphics.DrawString(NCliente, fontNCliente, Brushes.Black, leftMargin - 100, yPos - 20) '+20


            'Dim NLinea As String = "----------------------------------------------------------" & vbLf
            ''separacion del primer titulo con la segunda linea
            'Dim fontNLinea As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
            'e.Graphics.DrawString(NLinea, fontNLinea, _
            '                       Brushes.Black, leftMargin - 100, yPos + 30)

            'margen a la derecha de toda la lista
            X1 = PrintTikect.DefaultPageSettings.Margins.Left + 85
            With PrintTikect.DefaultPageSettings
                pageWidth = (.PaperSize.Width) - (.Margins.Left + 10) - (.Margins.Right)
                If .Landscape Then
                    pageWidth = .PaperSize.Height - (.Margins.Top) - (.Margins.Bottom)
                End If
            End With
            'tamaño de la primera celda cantidad
            X2 = X1 + 17
            'tamaño de la segunda celda
            X3 = CInt(X2 + pageWidth * 3)

            X4 = X1 + 5
            X5 = X1 + 20

            W1 = (X2 - X1)
            W2 = (X3 - X2)
            W4 = (X3 - X2)
            W5 = (X3 - X2)
            W3 = pageWidth - W1 - W2

            'If itm < lsvDetalle.Items.Count Then
            'ubicacion para abajo
            Y = PrintTikect.DefaultPageSettings.Margins.Top + 150
            Dim fontNColumna As New System.Drawing.Font("Arial", 8, FontStyle.Bold)
            ' Draw the column headers at the top of the page
            'ubicacion de las columnas para la izquierda
            e.Graphics.DrawString("Cant", fontNColumna, Brushes.Black, X1 - 187, Y - 37)
            e.Graphics.DrawString("Producto", fontNColumna, Brushes.Black, X2 - 175, Y - 37)
            e.Graphics.DrawString("P.U.", fontNColumna, Brushes.Black, X3 - 175, Y - 37)
            e.Graphics.DrawString("Total", fontNColumna, Brushes.Black, X4 + 2, Y - 37)
            ' Advance the Y coordinate for the first text line on the printout
            Y = Y + 20
            'End If
            Dim ii As Integer = 0
            Dim ultimaFila As Integer = 0

            For Each i As Record In dgvVenta.Table.Records

                ' extract each item's text into the str variable
                Dim str As String
                str = (CDbl(i.GetValue("cantidad")))

                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, X1 - 180, Y - 40)

                str = i.GetValue("item")
                Dim R As New RectangleF(X2 - 175, Y - 40, W2, 80)
                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, R)

                Dim lines, cols As Integer
                e.Graphics.MeasureString(str, fontNCabecera, New SizeF(W2, 50), New StringFormat, cols, lines)
                Dim subitm As Integer, Yc As Integer
                Yc = Y

                str = Math.Round(CDbl(i.GetValue("totalmn")) / CDbl(i.GetValue("cantidad")), 2)
                Dim R2 As New RectangleF(X4 - 45, Y - 40, W4, 80)
                e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R2)

                str = String.Format("{0:0.00}", i.GetValue("totalmn"))
                If (CDec(str.ToString.Length) = 4) Then
                    Dim R3 As New RectangleF(X5 + 9, Y - 40, W5, 80)
                    e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R3)
                ElseIf (str.ToString.Length = 8) Then
                    Dim R3 As New RectangleF(X5 - 11, Y - 40, W5, 80)
                    e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R3)
                ElseIf (str.ToString.Length = 6) Then
                    Dim R3 As New RectangleF(X5 + 0, Y - 40, W5, 80)
                    e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R3)
                ElseIf ((str.ToString.Length) = 7) Then
                    Dim R3 As New RectangleF(X5 - 9, Y - 40, W5, 80)
                    e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R3)
                ElseIf ((str.ToString.Length) = 5) Then
                    Dim R3 As New RectangleF(X5 + 5, Y - 40, W5, 80)
                    e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R3)
                Else
                    Dim R3 As New RectangleF(X5 - 13, Y - 40, W5, 80)
                    e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R3)
                End If

                Dim conteo As Integer

                For subitm = 1 To 1
                    str = i.GetValue("idProducto")
                    'str = i.SubItems(subitm).Text
                    'conteo = 0
                    conteo = (str.Length / 2)
                    Dim strformat As New StringFormat
                    strformat.Trimming = StringTrimming.EllipsisCharacter
                    Yc = Yc + fontNCabecera.Height + 2
                Next
                Y = Y + lines * fontNCabecera.Height + (conteo + 2)
                Y = Math.Max(Y, Yc)

                With PrintTikect.DefaultPageSettings
                    If (Not e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Height - .Margins.Bottom))) Or
                     (e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Width - .Margins.Bottom))) Then
                        e.HasMorePages = True
                        ii += 1
                        Exit Sub
                    Else
                        ii += 1
                        e.HasMorePages = False
                    End If
                End With

            Next

            Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------------------------------"
            Dim fontNLinea1 As New System.Drawing.Font("Arial", 8, FontStyle.Regular)
            e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin - 100, Y - 73)


            Dim NTotalPagar As String = vbCrLf & vbCrLf & "Total S/. " & txtCobroMN.DecimalValue
            Dim fontNTotalPagar As New System.Drawing.Font("Ebrima", 9, FontStyle.Bold)
            e.Graphics.DrawString(NTotalPagar, fontNTotalPagar, Brushes.Black, leftMargin + 10, Y - 70)

            Dim str2 As String
            Dim str4 As String
            Dim fontNExonerada As New System.Drawing.Font("Arial", 7, FontStyle.Regular)

            Dim BaseMN As Decimal = String.Format("{0:0.00}", TotalesXcanbeceras.BaseMN)
            Dim BaseMN2 As Decimal = String.Format("{0:0.00}", TotalesXcanbeceras.BaseMN2)
            Dim BaseMN3 As Decimal = String.Format("{0:0.00}", TotalesXcanbeceras.BaseMN3)
            Dim IgvMN As Decimal = String.Format("{0:0.00}", TotalesXcanbeceras.IgvMN)
            Dim PercepcionMN As Decimal = String.Format("{0:0.00}", TotalesXcanbeceras.PercepcionMN)
            Dim donacionMN As Decimal = String.Format("{0:0.00}", 0.0)
            Dim TotalMN As Decimal = String.Format("{0:0.00}", DigitalGauge2.Value)
            Dim cobroMn2 As Decimal = String.Format("{0:0.00}", cobroMn)
            Dim vueltoMN2 As Decimal = String.Format("{0:0.00}", vueltoMN)

            For index As Integer = 1 To 2
                str2 = ("Op. Exonerada")
                e.Graphics.DrawString(str2, fontNExonerada, Brushes.Black, leftMargin - 90, Y + 0)

                str2 = ("Op. Inafecta")
                e.Graphics.DrawString(str2, fontNExonerada, Brushes.Black, leftMargin - 90, Y + 20)

                str2 = ("Op. Gravada")
                e.Graphics.DrawString(str2, fontNExonerada, Brushes.Black, leftMargin - 90, Y + 40)

                str2 = ("I.G.V. S/.")
                e.Graphics.DrawString(str2, fontNExonerada, Brushes.Black, leftMargin - 90, Y + 60)

                str2 = ("Redondeo S/.")
                e.Graphics.DrawString(str2, fontNExonerada, Brushes.Black, leftMargin - 90, Y + 80)

                str2 = ("Donación S/.")
                e.Graphics.DrawString(str2, fontNExonerada, Brushes.Black, leftMargin - 90, Y + 100)

                str2 = ("Importa a Pagar S/.")
                e.Graphics.DrawString(str2, fontNExonerada, Brushes.Black, leftMargin - 90, Y + 120)

                str2 = ("Importe Recibido S/.")
                e.Graphics.DrawString(str2, fontNExonerada, Brushes.Black, leftMargin - 90, Y + 140)

                str2 = ("Vuelto S /.")
                e.Graphics.DrawString(str2, fontNExonerada, Brushes.Black, leftMargin - 90, Y + 160)

                'Op. Exonerada
                If (BaseMN.ToString.Length = 4) Then
                    str4 = CDec(BaseMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 99, Y + 0)
                ElseIf ((BaseMN.ToString.Length) = 8) Then
                    str4 = CDec(BaseMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 75, Y + 0)
                ElseIf ((BaseMN.ToString.Length) = 6) Then
                    str4 = CDec(BaseMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 88, Y + 0)
                ElseIf ((BaseMN.ToString.Length) = 7) Then
                    str4 = CDec(BaseMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 80, Y + 0)
                ElseIf ((BaseMN.ToString.Length) = 5) Then
                    str4 = CDec(BaseMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 95, Y + 0)
                Else
                    str4 = CDec(TotalesXcanbeceras.BaseMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 80, Y + 0)
                End If

                'Op. Inafecta
                If (CDec(BaseMN2.ToString.Length) = 4) Then
                    str4 = CDec(BaseMN2).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 99, Y + 20)
                ElseIf (BaseMN2.ToString.Length = 8) Then
                    str4 = CDec(BaseMN2).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 75, Y + 20)
                ElseIf (BaseMN2.ToString.Length = 6) Then
                    str4 = CDec(BaseMN2).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 88, Y + 20)
                ElseIf ((BaseMN2.ToString.Length) = 7) Then
                    str4 = CDec(BaseMN2).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 80, Y + 20)
                ElseIf ((BaseMN2.ToString.Length) = 6) Then
                    str4 = CDec(BaseMN2).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 95, Y + 20)
                Else
                    str4 = CDec(BaseMN2).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 80, Y + 20)
                End If

                'Op. Gravada
                If (CDec(BaseMN3.ToString.Length) = 4) Then
                    str4 = CDec(BaseMN3).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 99, Y + 40)
                ElseIf (BaseMN3.ToString.Length = 8) Then
                    str4 = CDec(BaseMN3).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 75, Y + 40)
                ElseIf (BaseMN3.ToString.Length = 6) Then
                    str4 = CDec(BaseMN3).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 88, Y + 40)
                ElseIf ((BaseMN3.ToString.Length) = 7) Then
                    str4 = CDec(BaseMN3).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 80, Y + 40)
                ElseIf ((BaseMN3.ToString.Length) = 5) Then
                    str4 = CDec(BaseMN3).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 95, Y + 40)
                Else
                    str4 = CDec(BaseMN3).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 80, Y + 40)
                End If

                'I.G.V. S/.
                If (CDec(IgvMN.ToString.Length) = 4) Then
                    str4 = CDec(IgvMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 99, Y + 60)
                ElseIf (IgvMN.ToString.Length = 8) Then
                    str4 = CDec(IgvMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 75, Y + 60)
                ElseIf (IgvMN.ToString.Length = 6) Then
                    str4 = CDec(IgvMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 88, Y + 60)
                ElseIf ((IgvMN.ToString.Length) = 7) Then
                    str4 = CDec(IgvMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 80, Y + 60)
                ElseIf ((IgvMN.ToString.Length) = 5) Then
                    str4 = CDec(IgvMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 95, Y + 60)
                Else
                    str4 = CDec(IgvMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 80, Y + 60)
                End If

                'Redondeo S/.
                If (CDec(PercepcionMN.ToString.Length) = 4) Then
                    str4 = CDec(PercepcionMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 99, Y + 80)
                ElseIf (PercepcionMN.ToString.Length = 8) Then
                    str4 = CDec(PercepcionMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 75, Y + 80)
                ElseIf (PercepcionMN.ToString.Length = 6) Then
                    str4 = CDec(PercepcionMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 88, Y + 80)
                ElseIf ((PercepcionMN.ToString.Length) = 7) Then
                    str4 = CDec(PercepcionMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 80, Y + 80)
                ElseIf ((PercepcionMN.ToString.Length) = 5) Then
                    str4 = CDec(PercepcionMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 95, Y + 80)
                Else
                    str4 = CDec(PercepcionMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 80, Y + 80)
                End If

                'Donación S/.
                If (CDec(donacionMN.ToString.Length) = 4) Then
                    str4 = CDec(donacionMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 99, Y + 100)
                ElseIf (donacionMN.ToString.Length = 8) Then
                    str4 = CDec(donacionMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 75, Y + 100)
                ElseIf (donacionMN.ToString.Length = 6) Then
                    str4 = CDec(donacionMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 88, Y + 100)
                ElseIf ((donacionMN.ToString.Length) = 7) Then
                    str4 = CDec(donacionMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 80, Y + 100)
                ElseIf ((donacionMN.ToString.Length) = 5) Then
                    str4 = CDec(donacionMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 95, Y + 100)
                Else
                    str4 = CDec(donacionMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 80, Y + 100)
                End If

                'Importa a Pagar S/.
                If (CDec(TotalMN.ToString.Length) = 4) Then
                    str4 = CDec(TotalMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 99, Y + 120)
                ElseIf (TotalMN.ToString.Length = 8) Then
                    str4 = CDec(TotalMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 75, Y + 120)
                ElseIf (TotalMN.ToString.Length = 6) Then
                    str4 = CDec(TotalMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 88, Y + 120)
                ElseIf ((TotalMN.ToString.Length) = 7) Then
                    str4 = CDec(TotalMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 80, Y + 120)
                ElseIf ((TotalMN.ToString.Length) = 5) Then
                    str4 = CDec(TotalMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 95, Y + 120)
                Else
                    str4 = CDec(TotalMN).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 80, Y + 120)
                End If

                'Importe Recibido S/.
                If (CDec(cobroMn2.ToString.Length) = 4) Then
                    str4 = CDec(cobroMn2).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 99, Y + 140)
                ElseIf (cobroMn2.ToString.Length = 8) Then
                    str4 = CDec(cobroMn2).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 75, Y + 140)
                ElseIf (cobroMn2.ToString.Length = 6) Then
                    str4 = CDec(cobroMn2).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 88, Y + 140)
                ElseIf ((cobroMn2.ToString.Length) = 7) Then
                    str4 = CDec(cobroMn2).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 80, Y + 140)
                ElseIf ((cobroMn2.ToString.Length) = 5) Then
                    str4 = CDec(cobroMn2).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 95, Y + 140)
                Else
                    str4 = CDec(cobroMn2).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 80, Y + 140)
                End If

                'Vuelto S /.
                If (CDec(vueltoMN2.ToString.Length) = 4) Then
                    str4 = CDec(vueltoMN2).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 99, Y + 160)
                ElseIf (vueltoMN2.ToString.Length = 8) Then
                    str4 = CDec(vueltoMN2).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 75, Y + 160)
                ElseIf (vueltoMN2.ToString.Length = 6) Then
                    str4 = CDec(vueltoMN2).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 88, Y + 160)
                ElseIf ((vueltoMN2.ToString.Length) = 7) Then
                    str4 = CDec(vueltoMN2).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 80, Y + 160)
                ElseIf ((vueltoMN2.ToString.Length) = 5) Then
                    str4 = CDec(vueltoMN2).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 95, Y + 160)
                Else
                    str4 = CDec(vueltoMN2).ToString("N2")
                    e.Graphics.DrawString(str4, fontNExonerada, Brushes.Black, leftMargin + 80, Y + 160)
                End If

            Next


            Select Case estadoImpresion
                Case 1
                    Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & ""
                    Dim fontNVendedor As New System.Drawing.Font("Arial", 7, FontStyle.Regular)
                    e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 94, Y + 180)

                    Dim NGracias As String = vbCrLf & vbCrLf & "GRACIAS POR SU COMPRA"
                    Dim fontNGracias As New System.Drawing.Font("Arial", 7, FontStyle.Regular)
                    e.Graphics.DrawString(NGracias, fontNGracias, Brushes.Black, leftMargin - 94, Y + 200)

                Case Else
                    Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & ""
                    Dim fontNVendedor As New System.Drawing.Font("Arial", 7, FontStyle.Regular)
                    e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 94, Y + 180)

                    Dim NGracias As String = vbCrLf & vbCrLf & "GRACIAS POR SU COMPRA"
                    Dim fontNGracias As New System.Drawing.Font("Arial", 7, FontStyle.Regular)
                    e.Graphics.DrawString(NGracias, fontNGracias, Brushes.Black, leftMargin - 94, Y + 200)
            End Select

            e.HasMorePages = False

            '   ElseIf (TipoTicket = "SinRUC") Then

            'Select Case estadoImpresion
            '    Case 1
            '        NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now & _
            '           vbCrLf & "CORRELATIVO: " & txtNumeroPedido.Text & _
            '           vbCrLf & "------------------------------------------------------------"
            '    Case Else
            '        NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now & _
            '        vbCrLf & "CORRELATIVO: " & txtNumeroPedido.Text & _
            '        vbCrLf & "------------------------------------------------------------"

            'End Select


            'Dim fontNCliente As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            'e.Graphics.DrawString(NCliente, fontNCliente, Brushes.Black, leftMargin - 100, yPos - 90) '+20


            ''Dim fontNCliente As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            ''e.Graphics.DrawString(NCliente, fontNCliente, Brushes.Black, leftMargin - 100, yPos - 80)


            ''Dim NLinea As String = "----------------------------------------------------------" & vbLf
            ' ''separacion del primer titulo con la segunda linea
            ''Dim fontNLinea As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
            ''e.Graphics.DrawString(NLinea, fontNLinea, _
            ''                       Brushes.Black, leftMargin - 100, yPos + 10)

            ''margen a la derecha de toda la lista
            'X1 = PrintTikect.DefaultPageSettings.Margins.Left + 85
            'With PrintTikect.DefaultPageSettings
            '    pageWidth = (.PaperSize.Width) - (.Margins.Left + 10) - (.Margins.Right)
            '    If .Landscape Then
            '        pageWidth = .PaperSize.Height - (.Margins.Top) - (.Margins.Bottom)
            '    End If
            'End With
            ''tamaño de la primera celda cantidad
            'X2 = X1 + 17
            ''tamaño de la segunda celda
            'X3 = CInt(X2 + pageWidth * 3)

            'X4 = X1 + 5
            'X5 = X1 + 20

            'W1 = (X2 - X1)
            'W2 = (X3 - X2)
            'W4 = (X3 - X2)
            'W5 = (X3 - X2)
            'W3 = pageWidth - W1 - W2

            ''If itm < lsvDetalle.Items.Count Then
            ''ubicacion para abajo
            'Y = PrintTikect.DefaultPageSettings.Margins.Top + 10
            'Dim fontNColumna As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
            '' Draw the column headers at the top of the page
            ''ubicacion de las columnas para la izquierda
            'e.Graphics.DrawString("Cant", fontNColumna, Brushes.Black, X1 - 187, Y - 37)
            'e.Graphics.DrawString("Producto", fontNColumna, Brushes.Black, X2 - 175, Y - 37)
            'e.Graphics.DrawString("P.U.", fontNColumna, Brushes.Black, X3 - 175, Y - 37)
            'e.Graphics.DrawString("Total", fontNColumna, Brushes.Black, X4 + 2, Y - 37)
            '' Advance the Y coordinate for the first text line on the printout
            'Y = Y + 20
            ''End If
            'Dim ii As Integer = 0
            'Dim ultimaFila As Integer = 0

            'For Each i As Record In dgvVenta.Table.Records

            '    ' extract each item's text into the str variable
            '    Dim str As String
            '    str = (CDbl(i.GetValue("cantidad")))

            '    e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, X1 - 180, Y - 40)

            '    str = i.GetValue("item")
            '    Dim R As New RectangleF(X2 - 175, Y - 40, W2, 80)
            '    e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, R)

            '    Dim lines, cols As Integer
            '    e.Graphics.MeasureString(str, fontNCabecera, New SizeF(W2, 50), New StringFormat, cols, lines)
            '    Dim subitm As Integer, Yc As Integer
            '    Yc = Y

            '    str = Math.Round(CDbl(i.GetValue("totalmn")) / CDbl(i.GetValue("cantidad")), 2)
            '    Dim R2 As New RectangleF(X4 - 45, Y - 40, W4, 80)
            '    e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R2)

            '    str = Math.Round(CDec(i.GetValue("totalmn")), 2)
            '    Dim R3 As New RectangleF(X5 - 13, Y - 40, W5, 80)
            '    e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R3)

            '    Dim conteo As Integer

            '    For subitm = 1 To 1
            '        str = i.GetValue("idProducto")
            '        'str = i.SubItems(subitm).Text
            '        'conteo = 0
            '        conteo = (str.Length / 2)
            '        Dim strformat As New StringFormat
            '        strformat.Trimming = StringTrimming.EllipsisCharacter
            '        Yc = Yc + fontNCabecera.Height + 2
            '    Next
            '    Y = Y + lines * fontNCabecera.Height + (conteo + 2)
            '    Y = Math.Max(Y, Yc)

            '    With PrintTikect.DefaultPageSettings
            '        If (Not e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Height - .Margins.Bottom))) Or _
            '         (e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Width - .Margins.Bottom))) Then
            '            e.HasMorePages = True
            '            ii += 1
            '            Exit Sub
            '        Else
            '            ii += 1
            '            e.HasMorePages = False
            '        End If
            '    End With

            'Next

            'Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------------------------------------------"
            'Dim fontNLinea1 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin - 100, Y - 75)


            'Dim NTotalPagar As String = vbCrLf & vbCrLf & "Sub Total S/. " & txtCobroMN.DecimalValue
            'Dim fontNTotalPagar As New System.Drawing.Font("Ebrima", 9, FontStyle.Bold)
            'e.Graphics.DrawString(NTotalPagar, fontNTotalPagar, Brushes.Black, leftMargin + 10, Y - 70)


            'Dim NExonerada As String = vbCrLf & vbCrLf & "Op. Exonerada                                         " & CDec(TotalesXcanbeceras.BaseMN).ToString("N2")
            'Dim fontNExonerada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NExonerada, fontNExonerada, Brushes.Black, leftMargin - 100, Y - 40)

            'Dim NIanfecta As String = vbCrLf & vbCrLf & "Op. Inafecta                                            " & CDec(TotalesXcanbeceras.BaseMN2).ToString("N2")
            'Dim fontNIanfecta As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NIanfecta, fontNIanfecta, Brushes.Black, leftMargin - 94, Y - 25)

            'Dim NGravada As String = vbCrLf & vbCrLf & "Op. Gravada                                            " & CDec(TotalesXcanbeceras.BaseMN3).ToString("N2")
            'Dim fontNGravada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NGravada, fontNGravada, Brushes.Black, leftMargin - 94, Y - 10)

            'Dim NIGVE As String = vbCrLf & vbCrLf & "I.G.V. S/.                                                " & CDec(TotalesXcanbeceras.IgvMN).ToString("N2")
            'Dim fontNIGVE As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NIGVE, fontNIGVE, Brushes.Black, leftMargin - 92, Y + 6)

            'Dim NREdondedo As String = vbCrLf & vbCrLf & "Redondeo S/.                                           " & CDec(TotalesXcanbeceras.PercepcionMN).ToString("N2")
            'Dim fontNREdondedo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NREdondedo, fontNREdondedo, Brushes.Black, leftMargin - 95, Y + 20)

            'Dim NDonacion As String = vbCrLf & vbCrLf & "Donación S/.                                            " & CDec(0.0).ToString("N2")
            'Dim fontNDonacion As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NDonacion, fontNDonacion, Brushes.Black, leftMargin - 94, Y + 36)

            'Dim NDImporPagar As String = vbCrLf & vbCrLf & "Importa a Pagar S/.                                  " & CDec(DigitalGauge2.Value).ToString("N2")
            'Dim fontNDImporPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NDImporPagar, fontNDImporPagar, Brushes.Black, leftMargin - 98, Y + 52)

            'Dim NImporteRecibido As String = vbCrLf & vbCrLf & "Importe Recibido S/.                                 " & CDec(cobroMn).ToString("N2")
            'Dim fontNImporteRecibido As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NImporteRecibido, fontNImporteRecibido, Brushes.Black, leftMargin - 98, Y + 68)

            'Dim NVuelto As String = vbCrLf & vbCrLf & "Vuelto S/.                                                " & CDec(vueltoMN).ToString("N2")
            'Dim fontNVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NVuelto, fontNVuelto, Brushes.Black, leftMargin - 94, Y + 84)


            'Select Case estadoImpresion
            '    Case 1
            '        Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & usuario.Alias
            '        Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 94, Y + 100)

            '        Dim NComprador As String = vbCrLf & vbCrLf & "COMPRADOR: " & txtComprador.Text
            '        Dim fontNComprador As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        e.Graphics.DrawString(NComprador, fontNComprador, Brushes.Black, leftMargin - 94, Y + 116)

            '        Dim NGracias As String = vbCrLf & vbCrLf & "GRACIAS POR SU COMPRA"
            '        Dim fontNGracias As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        e.Graphics.DrawString(NGracias, fontNGracias, Brushes.Black, leftMargin - 94, Y + 132)

            '    Case Else
            '        Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & usuario.Alias
            '        Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 94, Y + 100)

            '        Dim NComprador As String = vbCrLf & vbCrLf & "COMPRADOR: " & txtComprador.Text
            '        Dim fontNComprador As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        e.Graphics.DrawString(NComprador, fontNComprador, Brushes.Black, leftMargin - 94, Y + 116)

            '        Dim NGracias As String = vbCrLf & vbCrLf & "GRACIAS POR SU COMPRA"
            '        Dim fontNGracias As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        e.Graphics.DrawString(NGracias, fontNGracias, Brushes.Black, leftMargin - 94, Y + 132)
            'End Select



            'e.HasMorePages = False

            '      End If

        End If



    End Sub



#End Region


#Region "Métodos"
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Private Sub setDataSource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {table})
        Else
            dgvVenta.DataSource = table
            TotalTalesXcolumna()
            saldoMN = DigitalGauge2.Value
        End If
    End Sub

    Private Sub CMBCajasDelUsuarioPV()
        Try

            For Each item In cajausuario
                GridPago(item)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub TotalTalesXcolumna()
        Dim totalpercepMN As Decimal = 0
        Dim totalpercepME As Decimal = 0

        'VC01
        Dim totalVC As Decimal = 0
        Dim totalVCme As Decimal = 0

        'VC02
        Dim totalVC2 As Decimal = 0
        Dim totalVCme2 As Decimal = 0

        'VC03
        Dim totalVC3 As Decimal = 0
        Dim totalVCme3 As Decimal = 0

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

        For Each r As Record In dgvVenta.Table.Records
            totalpercepMN += CDec(r.GetValue("percepcionMN"))
            totalpercepME += CDec(r.GetValue("percepcionME"))

            'If r.GetValue("valBonif") = "S" Then
            '    totalDesc += CDec(r.GetValue("igvmn"))
            '    totalDescme += CDec(r.GetValue("igvme"))
            'Else

            Select Case r.GetValue("gravado")
                Case OperacionGravada.Grabado
                    totalVC += CDec(r.GetValue("vcmn"))
                    totalVCme += CDec(r.GetValue("vcme"))

                Case OperacionGravada.Exonerado
                    totalVC2 += CDec(r.GetValue("vcmn"))
                    totalVCme2 += CDec(r.GetValue("vcme"))

                Case OperacionGravada.Inafecto
                    totalVC3 += CDec(r.GetValue("vcmn"))
                    totalVCme3 += CDec(r.GetValue("vcme"))
            End Select



            totalIVA += CDec(r.GetValue("igvmn"))
            totalIVAme += CDec(r.GetValue("igvme"))

            total += CDec(r.GetValue("totalmn"))
            totalme += CDec(r.GetValue("totalme"))
            'End If

            Select Case r.GetValue("gravado")
                Case "1"
                    bs1 += CDec(r.GetValue("vcmn"))
                    bs1me += CDec(r.GetValue("vcme"))

                    igv1 += CDec(r.GetValue("igvmn"))
                    igv1me += CDec(r.GetValue("igvme"))
                Case "2"
                    bs2 += CDec(r.GetValue("vcmn"))
                    bs2me += CDec(r.GetValue("vcme"))

                    igv2 += CDec(r.GetValue("igvmn"))
                    igv2me += CDec(r.GetValue("igvme"))
            End Select

        Next

        TotalesXcanbeceras = New TotalesXcanbecera()

        TotalesXcanbeceras.PercepcionMN = totalpercepMN
        TotalesXcanbeceras.PercepcionME = totalpercepME

        TotalesXcanbeceras.BaseMN = totalVC
        TotalesXcanbeceras.BaseME = totalVCme

        TotalesXcanbeceras.BaseMN2 = totalVC2
        TotalesXcanbeceras.BaseME2 = totalVCme2

        TotalesXcanbeceras.BaseMN3 = totalVC3
        TotalesXcanbeceras.BaseME3 = totalVCme3

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
        'If cboMoneda.SelectedValue = 1 Then
        '    txtTotalBase3.DecimalValue = totalVC3
        '    txtTotalBase2.DecimalValue = totalVC2
        '    txtTotalBase.DecimalValue = totalVC
        '    txtTotalIva.DecimalValue = totalIVA
        '    txtTotalPagar2.DecimalValue = total
        '    DigitalGauge2.Value = total
        '    lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

        'Else
        '    txtTotalBase3.DecimalValue = totalVCme3
        '    txtTotalBase2.DecimalValue = totalVCme2
        '    txtTotalBase.DecimalValue = totalVCme
        '    txtTotalIva.DecimalValue = totalIVAme
        '    txtTotalPagar2.DecimalValue = totalme
        '    DigitalGauge2.Value = totalme
        '    lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME
        'End If


    End Sub

    Public Class TotalesXcanbecera
        '   Private base_mn, base_me, igv_mn, igv_me, total_mn, total_me As Decimal?

        Public Property BaseMN() As Decimal
        Public Property BaseME() As Decimal

        Public Property BaseMN2() As Decimal
        Public Property BaseME2() As Decimal

        Public Property BaseMN3() As Decimal
        Public Property BaseME3() As Decimal

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
            BaseMN2 = 0
            BaseME2 = 0
            BaseMN3 = 0
            BaseME3 = 0
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

    Sub cargarEstadosFinancieros(combo As Integer)
        'Dim combo As String

        If ((cboMoneda.Tag) >= 1) Then
            combo = cboMoneda.SelectedValue
            If (combo = 1) Then

                Select Case cboTipoPago.Text
                    Case "TARJETA DE CREDITO"
                        Dim x = (From a In cajausuario Where a.Tipo = "TC" And a.moneda = 1).ToList
                        Me.cboTarjeta.DataSource = x 'estadoSA.ObtenerEFPorCuentaFinanciera(GEstableciento.IdEstablecimiento, strBusqueda)
                        Me.cboTarjeta.DisplayMember = "NombreEntidad"
                        Me.cboTarjeta.ValueMember = "idEntidad"
                        'cboTarjeta.SelectedValue = -1
                    Case "EFECTIVO"
                        Dim x = (From a In cajausuario Where a.Tipo = "EF" And a.moneda = 1).ToList
                        Me.cboTarjeta.DataSource = x 'estadoSA.ObtenerEFPorCuentaFinanciera(GEstableciento.IdEstablecimiento, strBusqueda)
                        Me.cboTarjeta.DisplayMember = "NombreEntidad"
                        Me.cboTarjeta.ValueMember = "idEntidad"
                        'cboTarjeta.SelectedValue = -1
                    Case "BANCO"
                        Dim x = (From a In cajausuario Where a.Tipo = "BC" And a.moneda = 1).ToList
                        Me.cboTarjeta.DataSource = x 'estadoSA.ObtenerEFPorCuentaFinanciera(GEstableciento.IdEstablecimiento, strBusqueda)
                        Me.cboTarjeta.DisplayMember = "NombreEntidad"
                        Me.cboTarjeta.ValueMember = "idEntidad"
                        'cboTarjeta.SelectedValue = -1

                End Select
            Else
                Select Case cboTipoPago.Text
                    Case "TARJETA DE CREDITO"
                        Dim x = (From a In cajausuario Where a.Tipo = "TC" And a.moneda = 2).ToList
                        Me.cboTarjeta.DataSource = x 'estadoSA.ObtenerEFPorCuentaFinanciera(GEstableciento.IdEstablecimiento, strBusqueda)
                        Me.cboTarjeta.DisplayMember = "NombreEntidad"
                        Me.cboTarjeta.ValueMember = "idEntidad"

                    Case "EFECTIVO"
                        Dim x = (From a In cajausuario Where a.Tipo = "EF" And a.moneda = 2).ToList
                        Me.cboTarjeta.DataSource = x 'estadoSA.ObtenerEFPorCuentaFinanciera(GEstableciento.IdEstablecimiento, strBusqueda)
                        Me.cboTarjeta.DisplayMember = "NombreEntidad"
                        Me.cboTarjeta.ValueMember = "idEntidad"

                    Case "BANCO"
                        Dim x = (From a In cajausuario Where a.Tipo = "BC" And a.moneda = 2).ToList
                        Me.cboTarjeta.DataSource = x 'estadoSA.ObtenerEFPorCuentaFinanciera(GEstableciento.IdEstablecimiento, strBusqueda)
                        Me.cboTarjeta.DisplayMember = "NombreEntidad"
                        Me.cboTarjeta.ValueMember = "idEntidad"
                End Select
            End If
        End If
    End Sub


    Sub cargarDatosEstadosFinan()
        '--------------------- tipopago ------------------------
        cboTipoPago.Items.Clear()
        cboTipoPago.Items.Add("")
        cboTipoPago.Items.Add("EFECTIVO")
        cboTipoPago.Items.Add("BANCO")
        cboTipoPago.Items.Add("TARJETA DE CREDITO")
        'cboTarjeta.SelectedValue = -1
        'cboMoneda.SelectedValue = -1
        'txtMoneda.Text = "NAC"
        cboTipoPago.SelectedText = "EFECTIVO"

        '-------------------------- moneda -------------------

        Dim dt As New DataTable()

        dt.Columns.Add("id")
        dt.Columns.Add("name")

        Dim dr As DataRow = dt.NewRow
        dr(0) = "1"
        dr(1) = "NACIONAL"
        dt.Rows.Add(dr)

        Dim dr1 As DataRow = dt.NewRow
        dr1(0) = "2"
        dr1(1) = "EXTRANJERA"
        dt.Rows.Add(dr1)

        cboMoneda.DataSource = dt
        Me.cboMoneda.DisplayMember = "name"
        Me.cboMoneda.ValueMember = "id"
        cboMoneda.SelectedValue = 1
        cboMoneda.Tag = 1
        cargarEstadosFinancieros(cboMoneda.SelectedValue)

    End Sub


    Public Sub CargarCajasTipo(idpersona As Integer)
        Dim cajausuariosa As New cajaUsuarioSA

        Try

            cajausuario = cajausuariosa.ResumenTransaccionesXusuarioCaja(New cajaUsuario With {.idcajaUsuario = idcajaUsuario, .idPersona = idpersona})


            'If (Not IsNothing(cajausuario)) Then
            '    Dim i = (From a In cajausuario Where a.Tipo = "BC").ToList
            '    Me.cboTarjeta.DataSource = i 'estadoSA.ObtenerEFPorCuentaFinanciera(GEstableciento.IdEstablecimiento, strBusqueda)
            '    Me.cboTarjeta.DisplayMember = "NombreEntidad"
            '    Me.cboTarjeta.ValueMember = "idEntidad"
            '    cboTarjeta.SelectedValue = -1
            'End If

        Catch ex As Exception

        End Try
    End Sub

    Function ListaDocumentoCaja() As List(Of documento)
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)
        vueltoMN = 0
        vueltoME = 0
        For Each i In dgvPagos.Table.Records
            If CDbl(i.GetValue("montoMN") > 0) Then
                nDocumentoCaja = New documento
                'DOCUMENTO
                nDocumentoCaja.idDocumento = CInt(Me.Tag)
                nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
                nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
                nDocumentoCaja.tipoDoc = IIf(rbBoleta.Checked = True, "12.1", "12.2")
                nDocumentoCaja.fechaProceso = txtFechaCobro.Value
                nDocumentoCaja.nroDoc = txtSerieVenta.Text & "-" & txtNumeroVenta.Text
                nDocumentoCaja.idOrden = Nothing
                Select Case i.GetValue("moneda")
                    Case "NACIONAL"
                        nDocumentoCaja.moneda = 1
                    Case "EXTRANJERA"
                        nDocumentoCaja.moneda = 2
                End Select
                If Not IsNothing(EntidadSeleccionda) Then
                    If Not IsNothing(EntidadSeleccionda.nrodoc) Then
                        nDocumentoCaja.idEntidad = EntidadSeleccionda.idEntidad
                        nDocumentoCaja.entidad = EntidadSeleccionda.nombreCompleto
                        nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
                        nDocumentoCaja.nrodocEntidad = EntidadSeleccionda.nrodoc
                    Else
                        nDocumentoCaja.entidad = "SIN IDENTIDAD"
                        nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
                        nDocumentoCaja.nrodocEntidad = "-"
                    End If
                Else
                    nDocumentoCaja.entidad = "SIN IDENTIDAD"
                    nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
                    nDocumentoCaja.nrodocEntidad = "-"
                End If

                nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
                nDocumentoCaja.fechaActualizacion = DateTime.Now

                'DOCUMENTO CAJA
                objCaja = New documentoCaja
                objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                objCaja.idDocumento = 0
                objCaja.periodo = PeriodoGeneral
                If txtCliente.Text.Trim.Length > 0 Then
                    objCaja.codigoProveedor = lblNumeroDoc
                End If

                objCaja.fechaProceso = txtFechaCobro.Value
                objCaja.fechaCobro = txtFechaCobro.Value
                objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                If txtCliente.Text.Trim.Length > 0 Then
                    objCaja.IdProveedor = txtCliente.Tag
                End If
                objCaja.TipoDocumentoPago = IIf(rbBoleta.Checked = True, "12.1", "12.2")
                objCaja.codigoLibro = "14"
                objCaja.tipoDocPago = IIf(rbBoleta.Checked = True, "12.1", "12.2")
                objCaja.NumeroDocumento = txtSerieVenta.Text & "-" & txtNumeroVenta.Text
                objCaja.numeroOperacion = i.GetValue("numOper")
                objCaja.tipoCambio = i.GetValue("tipocambio")
                objCaja.montoSoles = Decimal.Parse(i.GetValue("montoMN"))
                Select Case i.GetValue("moneda")
                    Case "NACIONAL"
                        objCaja.moneda = 1
                    Case "EXTRANJERA"
                        objCaja.moneda = 2
                End Select

                objCaja.montoUsd = Decimal.Parse(i.GetValue("montoME"))
                objCaja.estado = "P"
                objCaja.glosa = "Por ventas con tipo doc. " & IIf(rbBoleta.Checked = True, "BOL, ", "FAC, ") & "nro. " & txtSerieVenta.Text & "-" & txtNumeroVenta.Text & " fecha: " & txtFechaComprobante.Value
                objCaja.entregado = "SI"
                '     Dim codUserCaja = GFichaUsuarios.IdCajaUsuario
                objCaja.movimientoCaja = "IPV"
                objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
                objCaja.usuarioModificacion = usuario.IDUsuario
                objCaja.entidadFinanciera = CInt(i.GetValue("idEntidad"))

                ef = efSA.GetUbicar_estadosFinancierosPorID(CInt(i.GetValue("idEntidad")))

                objCaja.idEmpresa = ef.idEmpresa
                objCaja.idEstablecimiento = ef.idEstablecimiento

                objCaja.NombreEntidad = (i.GetValue("ef"))
                objCaja.fechaModificacion = DateTime.Now

                'vuelto ticket
                vueltoMN = CDec(i.GetValue("vueltoMN"))
                vueltoME = CDec(i.GetValue("vueltoME"))

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
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = "1213"
        nMovimiento.descripcion = txtComprador.Text
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

    End Sub

    Private Sub ListaDetalleCaja(doc As documentoCaja)
        Dim obj As New documentoCajaDetalle
        Dim lista As New List(Of documentoCajaDetalle)
        For Each i As ListViewItem In lsvPagosRegistrados.Items
            If doc.NombreEntidad = i.SubItems(1).Text Then
                obj = New documentoCajaDetalle
                obj.fecha = txtFechaCobro.Value
                obj.idItem = CInt(i.SubItems(2).Text)
                obj.DetalleItem = i.SubItems(3).Text
                obj.montoSoles = FormatNumber(Decimal.Parse(i.SubItems(4).Text), 2)
                obj.montoSolesTransacc = FormatNumber(Decimal.Parse(i.SubItems(4).Text), 2)
                obj.montoUsd = FormatNumber(Decimal.Parse(i.SubItems(6).Text), 2)
                obj.montoUsdTransacc = FormatNumber(Decimal.Parse(i.SubItems(6).Text), 2)
                obj.documentoAfectadodetalle = (i.SubItems(5).Text)

                obj.tipoCambioTransacc = TmpTipoCambioTransaccionCompra
                obj.diferTipoCambio = TmpTipoCambioTransaccionCompra

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


    Sub AddSubitemPago(i As Record, valMN As Double, venta As Record)
        Dim oreg As New ListViewItem
        Dim tipoCambio As Decimal

        oreg = lsvPagosRegistrados.Items.Add(i.GetValue("pago"))
        oreg.SubItems.Add(i.GetValue("ef"))
        oreg.SubItems.Add(venta.GetValue("idProducto"))
        oreg.SubItems.Add(venta.GetValue("item"))
        oreg.SubItems.Add(valMN)
        oreg.SubItems.Add(venta.GetValue("codigo"))
        tipoCambio = i.GetValue("tipocambio")
        'total = valMN / tipoCambio
        If (tipoCambio = 0) Then
            oreg.SubItems.Add(Math.Round(CDec(valMN / TmpTipoCambio), 1))
        Else

            oreg.SubItems.Add(Math.Round(CDec(valMN / tipoCambio), 1))
        End If



    End Sub

    'Sub AddSubitemPago(i As Record, valMN As Double, valME As Double, venta As Record)
    '    Dim oreg As New ListViewItem

    '    oreg = lsvPagosRegistrados.Items.Add(i.GetValue("pago"))
    '    oreg.SubItems.Add(i.GetValue("ef"))
    '    oreg.SubItems.Add(venta.GetValue("idProducto"))
    '    oreg.SubItems.Add(venta.GetValue("item"))
    '    oreg.SubItems.Add(valMN)
    '    oreg.SubItems.Add(Math.Round(valMN / CDbl(i.GetValue("tipocambio")), 2))

    'End Sub

    Private Sub DockingInicio()
        dockingManager1.DockControlInAutoHideMode(PanelPagos, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 80)
        'Me.DockingClientPanel1.AutoScroll = True
        'Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        dockingManager1.SetDockLabel(PanelPagos, "Pagos")
        'dockingManager1.CloseEnabled = False

        dockingManager1.DockControlInAutoHideMode(Panel4, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 500)
        'Me.DockingClientPanel1.AutoScroll = True
        'Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        dockingManager1.SetDockLabel(Panel4, "Detalle Ventas")
        dockingManager1.CloseEnabled = False
    End Sub

    Sub CalculoPagos()
        For Each i In dgvVenta.Table.Records
            i.SetValue("estado", "NO")
            i.SetValue("pagado", i.GetValue("totalmn"))
        Next

        For Each i As Record In dgvPagos.Table.Records
            If CDbl(i.GetValue("montoMN")) > 0 Then
                CalculosSubpago(i)
            End If
        Next

    End Sub

    'Sub CalculoPagos()
    '    For Each i In dgvVenta.Table.Records
    '        i.SetValue("estado", "NO")
    '        i.SetValue("pagado", i.GetValue("totalmn"))
    '    Next

    '    For Each i As Record In dgvPagos.Table.Records
    '        If CDbl(i.GetValue("montoMN")) > 0 Then
    '            CalculosSubpago(i)
    '        End If
    '    Next

    'End Sub

    Sub CalculosSubpago(r As Record) 'row de pagos de cuentas financieras
        Dim pago As Decimal = CType(FormatNumber(r.GetValue("montoMN"), 2), Decimal)
        'Dim pagoME As Double = CType(r.GetValue("montoME"), Double)
        'Dim pagoME As Double
        'Dim valVenta As Double = 0
        Dim saldo As Double = 0
        'Dim saldoME As Double = 0

        Dim saldoPago As Double = 0
        'Dim saldoPagoME As Double = 0

        For Each i In dgvVenta.Table.Records
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

    'Sub CalculosSubpago(r As Record) 'row de pagos de cuentas financieras
    '    Dim pago As Double = CType(r.GetValue("montoMN"), Double)
    '    Dim pagoME As Double = CType(r.GetValue("montoME"), Double)
    '    'Dim valVenta As Double = 0
    '    Dim saldo As Double = 0
    '    Dim saldoME As Double = 0

    '    Dim saldoPago As Double = 0
    '    Dim saldoPagoME As Double = 0

    '    For Each i In dgvVenta.Table.Records
    '        Dim saldoGeneral As Double = i.GetValue("pagado") '+ saldoPago
    '        Dim saldoGeneralME As Double = i.GetValue("pagadoME") '+ saldoPago

    '        If i.GetValue("estado") = "NO" Then

    '            If pago <= 0 Then
    '                i.SetValue("estado", "NO")
    '                i.SetValue("pagado", CType(i.GetValue("totalmn"), Double))
    '                i.SetValue("pagadoME", CType(i.GetValue("totalme"), Double))
    '                Exit For
    '            End If

    '            If saldoGeneral >= pago Then
    '                AddSubitemPago(r, pago, pagoME, i)
    '            Else
    '                AddSubitemPago(r, saldoGeneral, saldoGeneralME, i)
    '            End If

    '            If pago >= saldoGeneral Then
    '                i.SetValue("estado", "SI")
    '                'pago = pago - saldoGeneral
    '            Else
    '                i.SetValue("estado", "NO")
    '                'pago = pago - saldoGeneral
    '            End If

    '            saldoPago = saldoGeneral - pago
    '            saldoPagoME = saldoGeneralME - pagoME

    '            saldo = saldoGeneral - pago
    '            saldoME = saldoGeneralME - pagoME

    '            If saldo <= 0 Then
    '                'i.SetValue("estado", "SI")
    '                i.SetValue("pagado", 0)
    '                i.SetValue("pagadoME", 0)
    '            Else
    '                'i.SetValue("estado", "NO")
    '                If saldo.ToString.Length > 3 Then
    '                    i.SetValue("pagado", Math.Round(saldo, 2))
    '                    i.SetValue("pagadoME", Math.Round(saldoME, 2))
    '                Else
    '                    i.SetValue("pagado", saldo)
    '                    i.SetValue("pagadoME", saldoME)
    '                End If
    '            End If

    '            pago = pago - saldoGeneral
    '            pagoME = pagoME - saldoGeneralME
    '        End If
    '    Next
    'End Sub

    Sub cargarDatosCuentas()
        Dim cuentaUsuarioDetalleSA As New cajaUsuarioSA
        idCajaUsuario = cuentaUsuarioDetalleSA.UbicarUsuarioAbierto(usuario.IDUsuario).idcajaUsuario
    End Sub

    Sub cargarDatosProductos(intIdDocumento As Integer)
        Dim ventaDetalleSA As New documentoVentaAbarrotesDetSA
        listaDetalleProducto = ventaDetalleSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
    End Sub

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

        Return dt
    End Function

    'Function comprobarDataPagos(intEntidad As Integer) As Integer
    '    Dim contador As Integer = 0
    '    For Each i In dgvPagos.Table.Records

    '        If (rbNacional.Checked = True) Then
    '            If (i.GetValue("numOper") = intEntidad And i.GetValue("moneda") = "NACIONAL") Then
    '                contador = 1
    '            End If
    '        ElseIf rbExtranjera.Checked = True Then
    '            If (i.GetValue("numOper") = intEntidad And i.GetValue("moneda") = "EXTRANJERA") Then
    '                contador = 1
    '            End If
    '        End If


    '    Next
    '    Return contador
    'End Function

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
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", DigitalGauge2.Value)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", DigitalGauge2.Value)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("cuenta", cajaBE.cuentaCajaOrigen)
    '                Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 0
    '                If (contadorMon = 1) Then
    '                    Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 175
    '                    Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
    '                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 75
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
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("cuenta", cajaBE.cuentaCajaOrigen)
    '                Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 175
    '                Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
    '                Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 75

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
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", DigitalGauge2.Value)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", DigitalGauge2.Value)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("cuenta", cajaBE.cuentaCajaOrigen)
    '                If (contadorMon = 1) Then
    '                    Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 175
    '                    Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
    '                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 75
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
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("cuenta", cajaBE.cuentaCajaOrigen)
    '                Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 50

    '                Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 175
    '                Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
    '                Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 75

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
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", DigitalGauge2.Value)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", DigitalGauge2.Value)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("cuenta", cajaBE.cuentaCajaOrigen)
    '                If (contadorMon = 1) Then
    '                    Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 175
    '                    Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
    '                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 75
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
    '                Me.dgvPagos.Table.CurrentRecord.SetValue("cuenta", cajaBE.cuentaCajaOrigen)
    '                Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 50

    '                Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 175
    '                Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
    '                Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 75

    '                Me.dgvPagos.Table.AddNewRecord.EndEdit()

    '            End If

    '        End If

    '        txtImporteRecibido.Text = DigitalGauge2.Value
    '        txtImporteCobrado.Text = DigitalGauge2.Value

    '    Else
    '        MessageBox.Show("ya existe una entidad financiera!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    End If


    'End Sub

    Sub GridPago(cajaBE As cajaUsuario)

        Dim cuentaUsuarioDetalleSA As New cajaUsuarioDetalleSA
        Dim contador As Integer = 0
        Dim saldooagado As Integer = 0
        Dim contadorMon As Integer = 0
        For Each i In dgvPagos.Table.Records
            If (i.GetValue("idEntidad") = cajaBE.idEntidad) Then
                contador += 1
            End If
            If (dgvPagos.Table.Records.Count > 1) Then
                If (i.GetValue("saldo") = 0) Then
                    saldooagado = 1
                End If
            End If
            If (i.GetValue("moneda") = "EXTRANJERO") Then
                contadorMon = 1
            End If
        Next

        If (contador = 0) Then

            If Not IsNothing(cajaBE) Then
                If (cajaBE.moneda = TipoMoneda.Nacional And cajaBE.Tipo = CuentaFinanciera.Efectivo) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 1).FirstOrDefault

                    Me.dgvPagos.Table.AddNewRecord.SetCurrent()
                    Me.dgvPagos.Table.AddNewRecord.BeginEdit()
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "EFECTIVO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "NACIONAL")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0) '5
                    If (contadorAutomatico = 0) Then
                        Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", DigitalGauge2.Value)
                        Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", DigitalGauge2.Value)
                        contadorAutomatico += 1
                    Else
                        Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                        Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    End If
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("cuenta", cajaBE.cuentaCajaOrigen)
                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 0
                    If (contadorMon = 1) Then
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 175
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 75
                    Else
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 0
                    End If

                    Me.dgvPagos.Table.AddNewRecord.EndEdit()


                ElseIf (cajaBE.moneda = TipoMoneda.Extranjero And cajaBE.Tipo = CuentaFinanciera.Efectivo) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 2).FirstOrDefault

                    Me.dgvPagos.Table.AddNewRecord.SetCurrent()
                    Me.dgvPagos.Table.AddNewRecord.BeginEdit()
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "EFECTIVO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "EXTRANJERO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", CDec(TmpTipoCambioTransaccionCompra))
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)
                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 50
                    Me.dgvPagos.Table.CurrentRecord.SetValue("cuenta", cajaBE.cuentaCajaOrigen)
                    Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 175
                    Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 75

                    Me.dgvPagos.Table.AddNewRecord.EndEdit()

                ElseIf (cajaBE.moneda = TipoMoneda.Nacional And cajaBE.Tipo = CuentaFinanciera.Banco) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 1).FirstOrDefault

                    Me.dgvPagos.Table.AddNewRecord.SetCurrent()
                    Me.dgvPagos.Table.AddNewRecord.BeginEdit()
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "BANCO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "NACIONAL")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                    If (contadorAutomatico = 0) Then
                        Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", DigitalGauge2.Value)
                        Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", DigitalGauge2.Value)
                        contadorAutomatico += 1
                    Else
                        Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                        Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    End If
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("cuenta", cajaBE.cuentaCajaOrigen)
                    If (contadorMon = 1) Then
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 175
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 75
                    Else
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 0
                    End If
                    Me.dgvPagos.Table.AddNewRecord.EndEdit()


                ElseIf (cajaBE.moneda = TipoMoneda.Extranjero And cajaBE.Tipo = CuentaFinanciera.Banco) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 2).FirstOrDefault

                    Me.dgvPagos.Table.AddNewRecord.SetCurrent()
                    Me.dgvPagos.Table.AddNewRecord.BeginEdit()
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "BANCO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "EXTRANJERO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", CDec(TmpTipoCambioTransaccionCompra))
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("cuenta", cajaBE.cuentaCajaOrigen)
                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 50

                    Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 175
                    Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 75

                    Me.dgvPagos.Table.AddNewRecord.EndEdit()


                ElseIf (cajaBE.moneda = TipoMoneda.Nacional And cajaBE.Tipo = CuentaFinanciera.Tarjeta_Credito) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 1).FirstOrDefault

                    Me.dgvPagos.Table.AddNewRecord.SetCurrent()
                    Me.dgvPagos.Table.AddNewRecord.BeginEdit()
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "TARJETA CREDITO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "NACIONAL")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                    If (contadorAutomatico = 0) Then
                        Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", DigitalGauge2.Value)
                        Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", DigitalGauge2.Value)
                        contadorAutomatico += 1
                    Else
                        Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                        Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    End If
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("cuenta", cajaBE.cuentaCajaOrigen)
                    If (contadorMon = 1) Then
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 175
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 75
                    Else
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 0
                    End If
                    Me.dgvPagos.Table.AddNewRecord.EndEdit()


                ElseIf (cajaBE.moneda = TipoMoneda.Extranjero And cajaBE.Tipo = CuentaFinanciera.Tarjeta_Credito) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 2).FirstOrDefault

                    Me.dgvPagos.Table.AddNewRecord.SetCurrent()
                    Me.dgvPagos.Table.AddNewRecord.BeginEdit()
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "TARJETA CREDITO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "EXTRANJERO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", CDec(TmpTipoCambioTransaccionCompra))
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("cuenta", cajaBE.cuentaCajaOrigen)
                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 50

                    Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 175
                    Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 75

                    Me.dgvPagos.Table.AddNewRecord.EndEdit()

                End If

            End If

            txtImporteRecibido.Text = DigitalGauge2.Value
            txtImporteCobrado.Text = DigitalGauge2.Value

        Else
            MessageBox.Show("ya existe una entidad financiera!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub limpiarConfirmarVenta()
        dgvVenta.Table.Records.DeleteAll()
        DigitalGauge2.Value = "0.00"
        txtSerieVenta.Clear()
        txtNumeroVenta.Clear()
        txtPeriodo.Clear()
        txtIgv.DecimalValue = 0
        txtIgvme.DecimalValue = 0
        txtComprador.Clear()
        txtMoneda.Clear()
        txtTipoCambio.Value = 0
        txtTasaIgv.Value = 0
        txtCobroMN.DecimalValue = 0
        txtCobroMe.DecimalValue = 0

        rbBoleta.Checked = True
        rbFactura.Checked = False
        'txtVueltoMN.DecimalValue = 0
        'txtVueltoME.DecimalValue = 0

        Panel3.Enabled = False
        '   pnVentas.Enabled = False

        '  txtTipoDocVenta.Text = String.Empty
        txtRuc.Text = "0000"
        txtCliente.Text = "Clientes varios"

        txtNumeroPedido.Clear()
        txtNumeroPedido.Focus()
        txtNumeroPedido.Select(0, txtNumeroPedido.Text.Length)
        estadoImpresion = 0
        dgvPagos.Table.Records.DeleteAll()
        cboMoneda.SelectedValue = -1
        cboTarjeta.SelectedValue = -1
        cboTipoPago.SelectedValue = -1
        'pnVentas.Size = New Size(357, 80)
    End Sub

    Public Function AS_CAJA(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "1213",
              .descripcion = txtComprador.Text,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = CInt(Me.Tag)
        nAsiento.periodo = lblPeriodo.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        If txtCliente.Text.Trim.Length > 0 Then
            nAsiento.idEntidad = txtCliente.Tag
            nAsiento.nombreEntidad = txtCliente.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        End If
        nAsiento.fechaProceso = txtFechaCobro.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = "Por ventas con tipo doc. " & IIf(rbBoleta.Checked = True, "BOL, ", "FAC, ") & "nro. " & txtSerieVenta.Text & "-" & txtNumeroVenta.Text & " fecha: " & txtFechaComprobante.Value
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Public Function AsientoTransferenciaMercaderiaToMatPrima() As List(Of asiento)
        Dim docSA As New documentoconsumodirectoSA
        Dim Lista As New List(Of documentoconsumodirecto)
        Dim nAsiento As New asiento
        Dim listaAsiento As New List(Of asiento)
        Dim nMovimiento As New movimiento
        Dim totaMN As Decimal = 0
        Dim totaME As Decimal = 0

        listaAsiento = New List(Of asiento)

        Lista = docSA.GetConsumoByidDocumento(New documentoconsumodirecto With {.idDocumento = Val(Me.Tag)})

        'Asiento Transferencia de mercaderia a materia prima
        nAsiento = New asiento
        nAsiento.idDocumento = CInt(Me.Tag)
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        If txtCliente.Text.Trim.Length > 0 Then
            nAsiento.idEntidad = txtCliente.Tag
            nAsiento.nombreEntidad = txtCliente.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        End If
        nAsiento.fechaProceso = txtFechaCobro.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = 0
        nAsiento.importeME = 0
        nAsiento.glosa = "Por la transferencia de mercaderia a materia prima"
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now


        totaMN = 0
        totaME = 0
        For Each i In Lista
            totaMN += i.costo

            nMovimiento = New movimiento
            nMovimiento.cuenta = "241"
            nMovimiento.descripcion = i.descripcion
            nMovimiento.tipo = "D"
            nMovimiento.monto = i.costo
            nMovimiento.montoUSD = 0
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            nAsiento.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = "20111"
            nMovimiento.descripcion = i.descripcion
            nMovimiento.tipo = "H"
            nMovimiento.monto = i.costo
            nMovimiento.montoUSD = 0
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            nAsiento.movimiento.Add(nMovimiento)
        Next
        nAsiento.importeMN = totaMN
        nAsiento.importeME = 0
        listaAsiento.Add(nAsiento)

        '------------------------------------------------------------------------------------------------

        'Asiento Salida de materia prima a produccion
        nAsiento = New asiento
        nAsiento.idDocumento = CInt(Me.Tag)
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        If txtCliente.Text.Trim.Length > 0 Then
            nAsiento.idEntidad = txtCliente.Tag
            nAsiento.nombreEntidad = txtCliente.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        End If
        nAsiento.fechaProceso = txtFechaCobro.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = 0
        nAsiento.importeME = 0
        nAsiento.glosa = "Sálida de materia prima a producción"
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        totaMN = 0
        totaME = 0
        For Each i In Lista
            totaMN += i.costo

            nMovimiento = New movimiento
            nMovimiento.cuenta = "6121"
            nMovimiento.descripcion = i.descripcion
            nMovimiento.tipo = "D"
            nMovimiento.monto = i.costo
            nMovimiento.montoUSD = 0
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            nAsiento.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = "241"
            nMovimiento.descripcion = i.descripcion
            nMovimiento.tipo = "H"
            nMovimiento.monto = i.costo
            nMovimiento.montoUSD = 0
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            nAsiento.movimiento.Add(nMovimiento)
        Next
        nAsiento.importeMN = totaMN
        nAsiento.importeME = 0
        listaAsiento.Add(nAsiento)

        '------------------------------------------------------------------------------------------------

        Return listaAsiento
    End Function

    Public Function AsientoProductoTerminado() As List(Of asiento)
        Dim nAsiento As New asiento
        Dim ListaGeneralAsiento As New List(Of asiento)
        Dim nMovimiento As New movimiento
        Dim consumoSA As New documentoconsumodirectoSA
        Dim venta As New documentoVentaAbarrotesDetSA
        Dim totalMN As Decimal = 0

        ListaGeneralAsiento = New List(Of asiento)
        'Asiento Transferencia de mercaderia a materia prima
        nAsiento = New asiento
        nAsiento.idDocumento = CInt(Me.Tag)
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        If txtCliente.Text.Trim.Length > 0 Then
            nAsiento.idEntidad = txtCliente.Tag
            nAsiento.nombreEntidad = txtCliente.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        End If
        nAsiento.fechaProceso = txtFechaCobro.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = 0
        nAsiento.importeME = 0
        nAsiento.glosa = "Productos en proceso"
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        totalMN = 0
        For Each i In venta.GetUbicar_documentoventaAbarrotesDetPorIDocumento(Val(Tag))

            nMovimiento = New movimiento
            nMovimiento.cuenta = "231"
            nMovimiento.descripcion = i.nombreItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
            nMovimiento.monto = consumoSA.GetSumaBySecuencia(New documentoconsumodirecto With {.secuencia = i.secuencia})
            totalMN += CDec(nMovimiento.monto)
            nMovimiento.montoUSD = 0
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = "713"
            nMovimiento.descripcion = i.nombreItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = consumoSA.GetSumaBySecuencia(New documentoconsumodirecto With {.secuencia = i.secuencia})
            nMovimiento.montoUSD = 0
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)
        Next
        nAsiento.importeMN = totalMN
        nAsiento.importeME = 0
        ListaGeneralAsiento.Add(nAsiento)


        'Asiento Producto terminado culminado
        nAsiento = New asiento
        nAsiento.idDocumento = CInt(Me.Tag)
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        If txtCliente.Text.Trim.Length > 0 Then
            nAsiento.idEntidad = txtCliente.Tag
            nAsiento.nombreEntidad = txtCliente.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        End If
        nAsiento.fechaProceso = txtFechaCobro.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = 0
        nAsiento.importeME = 0
        nAsiento.glosa = "Productos terminados concluidos"
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        totalMN = 0
        For Each i In venta.GetUbicar_documentoventaAbarrotesDetPorIDocumento(Val(Tag))

            nMovimiento = New movimiento
            nMovimiento.cuenta = "713"
            nMovimiento.descripcion = i.nombreItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
            nMovimiento.monto = consumoSA.GetSumaBySecuencia(New documentoconsumodirecto With {.secuencia = i.secuencia})
            totalMN += CDec(nMovimiento.monto)
            nMovimiento.montoUSD = 0
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = "231"
            nMovimiento.descripcion = i.nombreItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = consumoSA.GetSumaBySecuencia(New documentoconsumodirecto With {.secuencia = i.secuencia})
            nMovimiento.montoUSD = 0
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)

            '-------------- costo----------------------------------------------------------

            nMovimiento = New movimiento
            nMovimiento.cuenta = "921"
            nMovimiento.descripcion = i.nombreItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
            nMovimiento.monto = consumoSA.GetSumaBySecuencia(New documentoconsumodirecto With {.secuencia = i.secuencia})
            totalMN += CDec(nMovimiento.monto)
            nMovimiento.montoUSD = 0
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = "791"
            nMovimiento.descripcion = i.nombreItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = consumoSA.GetSumaBySecuencia(New documentoconsumodirecto With {.secuencia = i.secuencia})
            nMovimiento.montoUSD = 0
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)

        Next
        nAsiento.importeMN = totalMN
        nAsiento.importeME = 0
        ListaGeneralAsiento.Add(nAsiento)

        '-----------------------------------------------------------------------------------------------
        'Asiento Ingreso productos terminados a almacen
        nAsiento = New asiento
        nAsiento.idDocumento = CInt(Me.Tag)
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        If txtCliente.Text.Trim.Length > 0 Then
            nAsiento.idEntidad = txtCliente.Tag
            nAsiento.nombreEntidad = txtCliente.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        End If
        nAsiento.fechaProceso = txtFechaCobro.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = 0
        nAsiento.importeME = 0
        nAsiento.glosa = "Ingreso de productos terminados a almacén"
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        totalMN = 0
        For Each i In venta.GetUbicar_documentoventaAbarrotesDetPorIDocumento(Val(Tag))

            nMovimiento = New movimiento
            nMovimiento.cuenta = "211"
            nMovimiento.descripcion = i.nombreItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
            nMovimiento.monto = consumoSA.GetSumaBySecuencia(New documentoconsumodirecto With {.secuencia = i.secuencia})
            totalMN += CDec(nMovimiento.monto)
            nMovimiento.montoUSD = 0
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = "713"
            nMovimiento.descripcion = i.nombreItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = consumoSA.GetSumaBySecuencia(New documentoconsumodirecto With {.secuencia = i.secuencia})
            nMovimiento.montoUSD = 0
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)
        Next
        nAsiento.importeMN = totalMN
        nAsiento.importeME = 0
        ListaGeneralAsiento.Add(nAsiento)

        Return ListaGeneralAsiento
    End Function

    Public Sub CostoVentaConsumo(cproducto As String, cMonto As Decimal, cMontoUS As Decimal, strTipoExistencia As String)
        Dim asientoTransitod As New asiento
        'Dim mascaraSA As New mascaraContable2SA
        'Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoTransito(cMonto, cMontoUS) ' CABECERA ASIENTO
        nMovimiento = New movimiento
        nMovimiento.cuenta = "692"
        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento
        nMovimiento.cuenta = "211"
        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Public Sub MV_Item_Transito(cproducto As String, cMonto As Decimal, cMontoUS As Decimal, strTipoExistencia As String)
        Dim asientoTransitod As New asiento
        'Dim mascaraSA As New mascaraContable2SA
        'Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoTransito(cMonto, cMontoUS) ' CABECERA ASIENTO

        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento
        Select Case strTipoExistencia
            Case "01"
                '   With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
                nMovimiento.cuenta = "69112"
                '    End With
        End Select


        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento
        Select Case strTipoExistencia
            Case "01"
                'With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
                nMovimiento.cuenta = "20111"
                '     End With

        End Select

        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Public Function AS_IGV(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento

        nMovimiento = New movimiento With {
              .cuenta = "40111",
              .descripcion = "I.G.V.",
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
                    .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    Sub AsientoVenta()
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento
        Dim sumAsientoMN As Decimal = 0
        Dim sumAsientoME As Decimal = 0
        Dim sumItemMN As Decimal = 0
        Dim sumItemME As Decimal = 0

        'maykol 
        Dim SumIGVMN As Decimal
        Dim SumIGVUSD As Decimal
        Dim ccmonto As Decimal
        Dim ccmontoUSD As Decimal
        Dim total As Decimal
        Dim totalME As Decimal

        nAsiento.idAsiento = 0
        nAsiento.idDocumento = CInt(Me.Tag)
        nAsiento.periodo = lblPeriodo.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = CInt(Me.Tag)
        nAsiento.fechaProceso = txtFechaCobro.Value
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing
        If txtCliente.Text.Trim.Length > 0 Then
            nAsiento.idEntidad = txtCliente.Tag
            nAsiento.nombreEntidad = txtCliente.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        End If
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.glosa = "ASIENTO x VENTA PAGADA-TICKET"
        nAsiento.importeMN = txtCobroMN.DecimalValue
        nAsiento.importeME = txtCobroMe.DecimalValue
        nAsiento.fechaActualizacion = DateTime.Now
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        ListaAsientonTransito.Add(nAsiento)
        nAsiento.movimiento.Add(AS_CAJA(txtCobroMN.DecimalValue, txtCobroMe.DecimalValue))
        For Each i As Record In dgvVenta.Table.Records
            '  MV_Item_Transito(CStr(i.GetValue("item")), (i.GetValue("costoMN")), (i.GetValue("costoME")), CStr(i.GetValue("tipoExistencia")))

            nMovimiento = New movimiento
            nMovimiento.cuenta = "70111" 'RecuperaCuentaVenta(i.SubItems(10).Text, i.SubItems(13).Text)
            nMovimiento.descripcion = i.GetValue("item")
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER

            Select Case i.GetValue("gravado")
                Case "1"
                    nMovimiento.monto = CDec(i.GetValue("vcmn"))
                    nMovimiento.montoUSD = CDec(i.GetValue("vcme"))
                    sumItemMN += CDec(i.GetValue("vcmn"))
                    sumItemME += CDec(i.GetValue("vcme"))
                    sumAsientoMN += CDec(i.GetValue("totalmn"))
                    sumAsientoME += CDec(i.GetValue("totalme"))
                Case Else
                    nMovimiento.monto = CDec(i.GetValue("totalmn"))
                    nMovimiento.montoUSD = CDec(i.GetValue("totalme"))
            End Select

            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)

        Next

        If (txtIgv.DecimalValue > 0 And txtIgvme.DecimalValue > 0) Then

            SumIGVMN = sumItemMN + txtIgv.DecimalValue
            SumIGVUSD = sumItemME + txtIgvme.DecimalValue

            If (SumIGVMN > sumAsientoMN) Then
                ccmonto = SumIGVMN - sumAsientoMN
                total = CDec(nAsiento.movimiento(1).monto + (ccmonto * -1))
                nAsiento.movimiento(1).monto = total
            ElseIf (SumIGVMN < sumAsientoMN) Then
                ccmonto = SumIGVMN - sumAsientoMN
                totalME = CDec(nAsiento.movimiento(1).monto - ccmonto)
                nAsiento.movimiento(1).monto = totalME
            End If

            If (SumIGVUSD > sumAsientoME) Then
                ccmontoUSD = SumIGVUSD - sumAsientoME
                nAsiento.movimiento(0).montoUSD = (nAsiento.movimiento(0).montoUSD + (ccmontoUSD * -1))
            ElseIf (SumIGVUSD < sumAsientoME) Then
                ccmontoUSD = SumIGVUSD - sumAsientoME
                nAsiento.movimiento(0).montoUSD = (nAsiento.movimiento(0).montoUSD - ccmontoUSD)

            End If
        Else

        End If

        nAsiento.movimiento.Add(AS_IGV(txtIgv.DecimalValue, txtIgvme.DecimalValue))

        'Return nAsiento.movimiento
    End Sub

    Sub AsientoVentaConsumoInmediato()
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento
        Dim sumAsientoMN As Decimal = 0
        Dim sumAsientoME As Decimal = 0
        Dim sumItemMN As Decimal = 0
        Dim sumItemME As Decimal = 0

        'maykol 
        Dim SumIGVMN As Decimal
        Dim SumIGVUSD As Decimal
        Dim ccmonto As Decimal
        Dim ccmontoUSD As Decimal
        Dim total As Decimal
        Dim totalME As Decimal

        nAsiento.idAsiento = 0
        nAsiento.idDocumento = CInt(Me.Tag)
        nAsiento.periodo = lblPeriodo.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = CInt(Me.Tag)
        nAsiento.fechaProceso = txtFechaCobro.Value
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing
        If txtCliente.Text.Trim.Length > 0 Then
            nAsiento.idEntidad = txtCliente.Tag
            nAsiento.nombreEntidad = txtCliente.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        End If
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.glosa = "ASIENTO x VENTA PAGADA-TICKET"
        nAsiento.importeMN = txtCobroMN.DecimalValue
        nAsiento.importeME = txtCobroMe.DecimalValue
        nAsiento.fechaActualizacion = DateTime.Now
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        ListaAsientonTransito.Add(nAsiento)
        nAsiento.movimiento.Add(AS_CAJA(txtCobroMN.DecimalValue, txtCobroMe.DecimalValue))
        For Each i As Record In dgvVenta.Table.Records
            'CostoVentaConsumo(CStr(i.GetValue("item")), (i.GetValue("costoMN")), (i.GetValue("costoME")), CStr(i.GetValue("tipoExistencia")))
            Select Case CStr(i.GetValue("tipoExistencia"))
                Case TipoExistencia.Mercaderia
                    MV_Item_Transito(CStr(i.GetValue("item")), (i.GetValue("costoMN")), (i.GetValue("costoME")), CStr(i.GetValue("tipoExistencia")))

                Case TipoExistencia.ProductoTerminado
                    nMovimiento = New movimiento
                    nMovimiento.cuenta = "702"
                    '   nMovimiento.cuenta = "70111" 'RecuperaCuentaVenta(i.SubItems(10).Text, i.SubItems(13).Text)
                    nMovimiento.descripcion = i.GetValue("item")
                    nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER

                    Select Case i.GetValue("gravado")
                        Case "1"
                            nMovimiento.monto = CDec(i.GetValue("vcmn"))
                            nMovimiento.montoUSD = CDec(i.GetValue("vcme"))
                            sumItemMN += CDec(i.GetValue("vcmn"))
                            sumItemME += CDec(i.GetValue("vcme"))
                            sumAsientoMN += CDec(i.GetValue("totalmn"))
                            sumAsientoME += CDec(i.GetValue("totalme"))
                        Case Else
                            nMovimiento.monto = CDec(i.GetValue("totalmn"))
                            nMovimiento.montoUSD = CDec(i.GetValue("totalme"))
                    End Select

                    nMovimiento.fechaActualizacion = DateTime.Now
                    nMovimiento.usuarioActualizacion = usuario.IDUsuario
                    nAsiento.movimiento.Add(nMovimiento)
            End Select
        Next

        If (txtIgv.DecimalValue > 0 And txtIgvme.DecimalValue > 0) Then

            SumIGVMN = sumItemMN + txtIgv.DecimalValue
            SumIGVUSD = sumItemME + txtIgvme.DecimalValue

            If (SumIGVMN > sumAsientoMN) Then
                ccmonto = SumIGVMN - sumAsientoMN
                total = CDec(nAsiento.movimiento(1).monto + (ccmonto * -1))
                nAsiento.movimiento(1).monto = total
            ElseIf (SumIGVMN < sumAsientoMN) Then
                ccmonto = SumIGVMN - sumAsientoMN
                totalME = CDec(nAsiento.movimiento(1).monto - ccmonto)
                nAsiento.movimiento(1).monto = totalME
            End If

            If (SumIGVUSD > sumAsientoME) Then
                ccmontoUSD = SumIGVUSD - sumAsientoME
                nAsiento.movimiento(0).montoUSD = (nAsiento.movimiento(0).montoUSD + (ccmontoUSD * -1))
            ElseIf (SumIGVUSD < sumAsientoME) Then
                ccmontoUSD = SumIGVUSD - sumAsientoME
                nAsiento.movimiento(0).montoUSD = (nAsiento.movimiento(0).montoUSD - ccmontoUSD)

            End If
        Else

        End If

        nAsiento.movimiento.Add(AS_IGV(txtIgv.DecimalValue, txtIgvme.DecimalValue))

        'Return nAsiento.movimiento
    End Sub

    Function ComprobanteCaja() As documento
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle
        Dim ListaCajaDetalle As New List(Of documentoCajaDetalle)
        Dim cajaSA As New EstadosFinancierosSA
        Dim nDocumentoCaja As New documento()
        Dim caja As New estadosFinancieros

        caja = cajaSA.GetUbicar_estadosFinancierosPorID(0)

        nDocumentoCaja.idDocumento = CInt(Me.Tag)
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            nDocumentoCaja.idProyecto = GProyectos.IdProyectoActividad
        End If
        nDocumentoCaja.tipoDoc = IIf(rbBoleta.Checked = True, "12.1", "12.2")
        nDocumentoCaja.fechaProceso = txtFechaCobro.Value
        nDocumentoCaja.nroDoc = txtSerieVenta.Text & "-" & txtNumeroVenta.Text
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = IIf(rbBoleta.Checked = True, "12.1", "12.2") ' "01"
        'nDocumentoCaja.usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        objCaja.idDocumento = 0
        objCaja.periodo = PeriodoGeneral
        If txtCliente.Text.Trim.Length > 0 Then
            objCaja.codigoProveedor = lblNumeroDoc
        End If
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
        objCaja.fechaProceso = txtFechaCobro.Value
        objCaja.fechaCobro = txtFechaCobro.Value
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        If txtCliente.Text.Trim.Length > 0 Then
            objCaja.IdProveedor = txtCliente.Tag
        End If
        objCaja.TipoDocumentoPago = IIf(rbBoleta.Checked = True, "12.1", "12.2")
        objCaja.codigoLibro = IIf(rbBoleta.Checked = True, "12.1", "12.2") ' "01"
        objCaja.tipoDocPago = IIf(rbBoleta.Checked = True, "12.1", "12.2")
        objCaja.NumeroDocumento = txtSerieVenta.Text & "-" & txtNumeroVenta.Text
        objCaja.moneda = txtMoneda.Text
        objCaja.tipoCambio = txtTipoCambio.Text
        objCaja.montoSoles = CDec(txtCobroMN.DecimalValue)
        objCaja.montoUsd = CDec(txtCobroMe.DecimalValue)


        objCaja.glosa = "Por ventas con tipo doc. " & IIf(rbBoleta.Checked = True, "BOL, ", "FAC, ") & "nro. " & txtSerieVenta.Text & "-" & txtNumeroVenta.Text & " fecha: " & txtFechaComprobante.Value
        objCaja.entregado = "SI"
        objCaja.entidadFinanciera = 0
        objCaja.usuarioModificacion = usuario.IDUsuario
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja

        Return nDocumentoCaja
    End Function

    Function ObjDocCajaDetalle() As List(Of documentoCajaDetalle)
        Dim nDocumentoCaja As New documento()
        Dim objCajaDetalle As New documentoCajaDetalle
        Dim ListaCajaDetalle As New List(Of documentoCajaDetalle)
        Dim objCajaDetalleAnticipo As New documentoCajaDetalle

        For Each i As Record In dgvVenta.Table.Records
            objCajaDetalle = New documentoCajaDetalle
            objCajaDetalle.idDocumento = 0
            objCajaDetalle.fecha = txtFechaCobro.Value
            objCajaDetalle.idItem = i.GetValue("idProducto")
            objCajaDetalle.DetalleItem = i.GetValue("item")
            objCajaDetalle.montoSoles = CDbl(i.GetValue("totalmn"))
            objCajaDetalle.montoUsd = CDbl(i.GetValue("totalme"))
            objCajaDetalle.entregado = "SI"
            objCajaDetalle.documentoAfectado = CInt(Me.Tag)
            objCajaDetalle.usuarioModificacion = usuario.IDUsuario
            objCajaDetalle.fechaModificacion = DateTime.Now
            ListaCajaDetalle.Add(objCajaDetalle)
        Next

        Return ListaCajaDetalle
    End Function


    '  Public Property ListaDetalleVenta As New List(Of documentoventaAbarrotes)

    Public Sub ConfirmarVenta()
        Dim nDocumentoCaja As New documento()
        Dim ndocumento As New documento()
        Dim DocCaja As New documento
        Dim DocCajaAnticipo As New documento
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim asientoSA As New AsientoSA
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim cajaUsarioBE As New cajaUsuario
        Dim cajaUsariodetalleBE As New cajaUsuariodetalle
        Dim cajaUsariodetalleListaBE As New List(Of cajaUsuariodetalle)
        Dim nDocumentoVentaSA As New documentoVentaAbarrotesSA
        Dim nDocumentoVenta As New documentoventaAbarrotes
        Dim nDocumentoVentaDetalle As New documentoventaAbarrotesDet
        Dim ListaDocumentoVentaDetalle As New List(Of documentoventaAbarrotesDet)
        Dim nDocumentoanticipoDetalle As New documentoAnticipoDetalle
        Dim ListaDocumentoanticipoDetalle As New List(Of documentoAnticipoDetalle)

        Dim ListaDocumentoCajaDetalle As New List(Of documentoCajaDetalle)

        Try

            ListaAsientonTransito = New List(Of asiento)
            'INGRESANDO LA VENTA => CAJA

            'DocCaja = ComprobanteCaja()

            With ndocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = Val(Me.Tag)
                .tipoConfirmacion = "SA"
                .fechaProceso = DateTime.Now
                .tipoDoc = GConfiguracion.TipoComprobante
                .moneda = IIf(txtMonenda.Text = "NACIONAL", "1", "2")
                If Not IsNothing(EntidadSeleccionda) Then
                    If Not IsNothing(EntidadSeleccionda.nrodoc) Then
                        .idEntidad = EntidadSeleccionda.idEntidad
                        .entidad = EntidadSeleccionda.nombreCompleto
                        .nrodocEntidad = EntidadSeleccionda.nrodoc
                    Else
                        .idEntidad = 0
                        .entidad = "SIN IDENTIDAD"
                        .nrodocEntidad = "-"
                    End If
                Else
                    .idEntidad = 0
                    .entidad = "SIN IDENTIDAD"
                    .nrodocEntidad = "-"
                End If


                .tipoEntidad = TIPO_ENTIDAD.CLIENTE
                .usuarioActualizacion = usuario.IDUsuario
            End With

            'ListaDocumentoCajaDetalle = ObjDocCajaDetalle()

            AsientoVenta()

            ' AsientoVentaConsumoInmediato()

            With nDocumentoVenta
                .tipoOperacion = "01"
                .fechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                .TipoConfiguracion = GConfiguracion.TipoConfiguracion
                .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
                .idDocumento = Val(Me.Tag)
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .tipoDocumento = IIf(rbBoleta.Checked = True, "12.1", "12.2")
                .serie = txtSerieVenta.Text
                .serieVenta = GConfiguracion.Serie
                .fechaConfirmacion = txtFechaCobro.Value
                '  .NumeroDoc = txtNumeroDoc.Text
                If txtCliente.Text.Trim.Length > 0 Then
                    .idCliente = Val(txtCliente.Tag)
                End If

                .estadoCobro = TIPO_VENTA.PAGO.COBRADO   ' DOCUMENTO COBRADO
                .establecimientoCobro = caja.idEstablecimiento
                '.entidadFinanciera = caja.idestado
                .entidadFinanciera = 0
                .glosa = "Por ventas con tipo doc. " & IIf(rbBoleta.Checked = True, "BOL, ", "FAC, ") & "nro. " & txtSerieVenta.Text & "-" & txtNumeroVenta.Text & " fecha: " & txtFechaComprobante.Value
                .tipoVenta = TIPO_VENTA.VENTA_AL_TICKET
                .usuarioActualizacion = usuario.IDUsuario
            End With
            ndocumento.documentoventaAbarrotes = nDocumentoVenta

            With nDocumentoVentaDetalle
                .idDocumento = Val(Me.Tag)
                .entregado = "S"
            End With
            ListaDocumentoVentaDetalle.Add(nDocumentoVentaDetalle)
            ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDocumentoVentaDetalle

            ndocumento.ListaCustomDocumento = ListaDocumentoCaja()


            'ListaAsientonTransito.AddRange(AsientoTransferenciaMercaderiaToMatPrima)
            'ListaAsientonTransito.AddRange(AsientoProductoTerminado)
            ndocumento.asiento = ListaAsientonTransito


            nDocumentoVentaSA.ConfirmarVentaTicket(ndocumento, Nothing, Nothing, Nothing)
            ' nDocumentoVentaSA.ConfirmarVentaTicketConsumoDirecto(ndocumento)
            '  lblEstado.Text = "Venta confirmada correctamente!"
            'Timer1.Enabled = True
            'PanelError.Visible = True
            'TiempoEjecutar(10)

            nDocumentoVentaSA = New documentoVentaAbarrotesSA
            With nDocumentoVentaSA.GetUbicar_documentoventaAbarrotesPorID(CInt(Me.Tag))
                txtSerVenta.Text = .serieVenta
                txtnroVenta.Text = .numeroVenta
                '   ButtonAdv1.Enabled = True
            End With

            'If MessageBoxAdv.Show("Desea imprimir la venta?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            If dgvVenta.Table.Records.Count > 0 Then
                'llenarDatos()
                'imprimir(False)
                ImprimirTicket(Val(Me.Tag))
            End If
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Public Sub GetObtenerSaldoEF()
    '    Dim EFSA As New EstadosFinancierosSA
    '    Dim EF As New estadosFinancieros

    '    EF = EFSA.GetEstadoSaldoEF(New estadosFinancieros With {.idestado = CInt(txtCajaOrigen.Tag)})
    '    txtFondoEF.DecimalValue = EF.importeBalanceMN
    '    txtFondoEFme.DecimalValue = EF.importeBalanceME

    'End Sub

    'Public Sub configuracionModulo2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
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
    '                        GConfiguracion.NombreComprobante = "" 'TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                        GConfiguracion.Serie = .serie
    '                        GConfiguracion.ValorActual = .valorInicial
    '                        txtSeriePedido.Text = .serie
    '                        'txtSerieComp.Visible = True
    '                        'txtSerieComp.Text = .serie
    '                        'txtNumeroComp.Visible = False
    '                        'txtIdComprobante.Text = GConfiguracion.TipoComprobante
    '                        'txtComprobante.Text = GConfiguracion.NombreComprobante
    '                        'LinkTipoDoc.Enabled = False
    '                        'txtSerieComp.Enabled = False
    '                    End With
    '                Case "M"
    '                    'txtSerieComp.Visible = True
    '                    'txtNumeroComp.Visible = True
    '                    'LinkTipoDoc.Enabled = True
    '                    'txtSerieComp.Enabled = True
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen

    '                    'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '                    'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
    '                    'With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '                    '    'txtIdEstableAlmacen.Text = .idCentroCosto
    '                    '    'txtEstableAlmacen.Text = .nombre
    '                    'End With
    '                End With
    '            End If
    '            If Not IsNothing(.ConfigentidadFinanciera) Then
    '                'With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '                '    GConfiguracion.IDCaja = .idestado
    '                '    GConfiguracion.NomCaja = .descripcion
    '                'End With
    '            End If

    '        End With
    '    Else
    '        MessageBox.Show("Este módulo no contiene una configuración disponible, intentelo más tarde.!")
    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
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
                GConfiguracion.NombreComprobante = "" ' TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
                GConfiguracion.Serie = RecuperacionNumeracion.serie
                GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
                txtSeriePedido.Text = RecuperacionNumeracion.serie
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

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
    '            GConfiguracion2 = New GConfiguracionModulo
    '            GConfiguracion2.IdModulo = .idModulo
    '            GConfiguracion2.NomModulo = strNomModulo
    '            GConfiguracion2.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion2.ConfigComprobante = .IdEnumeracion

    '                        If rbBoleta.Checked = True Then
    '                            GConfiguracion2.TipoComprobante = "12.1" '.tipo
    '                            GConfiguracion2.NombreComprobante = "" 'TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial
    '                            txtSerVenta.Text = .serie
    '                            '    txtTipoDocVenta.Text = GConfiguracion2.NombreComprobante
    '                        End If


    '                        If rbFactura.Checked = True Then
    '                            GConfiguracion2.TipoComprobante = "12.2" ' .tipo
    '                            GConfiguracion2.NombreComprobante = "" ' TablaSA.GetUbicarTablaID(10, .tipo1).descripcion
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial1
    '                            txtSerVenta.Text = .serie
    '                            '  txtTipoDocVenta.Text = GConfiguracion2.NombreComprobante
    '                        End If
    '                        'txtSerieComp.Visible = True
    '                        'txtSerieComp.Text = .serie
    '                        'txtNumeroComp.Visible = False
    '                        'txtIdComprobante.Text = GConfiguracion.TipoComprobante
    '                        'txtComprobante.Text = GConfiguracion.NombreComprobante
    '                        'LinkTipoDoc.Enabled = False
    '                        'txtSerieComp.Enabled = False
    '                    End With
    '                Case "M"
    '                    'txtSerieComp.Visible = True
    '                    'txtNumeroComp.Visible = True
    '                    'LinkTipoDoc.Enabled = True
    '                    'txtSerieComp.Enabled = True
    '            End Select
    '            'If Not IsNothing(.configAlmacen) Then
    '            '    Dim estableSA As New establecimientoSA
    '            '    With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '            '        GConfiguracion2.IdAlmacen = .idAlmacen
    '            '        GConfiguracion2.NombreAlmacen = .descripcionAlmacen

    '            '        'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '            '        'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
    '            '        'With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '            '        '    'txtIdEstableAlmacen.Text = .idCentroCosto
    '            '        '    'txtEstableAlmacen.Text = .nombre
    '            '        'End With
    '            '    End With
    '            'End If
    '            'If Not IsNothing(.ConfigentidadFinanciera) Then
    '            '    With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '            '        GConfiguracion2.IDCaja = .idestado
    '            '        GConfiguracion2.NomCaja = .descripcion
    '            '    End With
    '            'End If

    '        End With
    '    Else
    '        MessageBox.Show("Este módulo no contiene una configuración disponible, intentelo más tarde.!")
    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
    'End Sub



    Private Sub CargarCajasComprobante(ByVal strCondicion As Boolean)
        PictureBox3.Visible = strCondicion
        txtRuc.Visible = strCondicion
        'Label16.Visible = strCondicion
        'Label15.Visible = strCondicion
        'txtCliente.Visible = strCondicion
        'Label3.Visible = strCondicion
        'txtCuenta.Visible = strCondicion
    End Sub

    Sub limpiarBoleta()
        txtRuc.Text = "0000"
        txtCliente.Text = "Clientes varios"
    End Sub

    'Public Sub ObtenerDetallePedido(ByVal intIdDocumento As Integer)
    '    Dim ventaDetalleSA As New documentoVentaAbarrotesDetSA

    '    Try
    '        Dim dt As New DataTable()
    '        dt.Columns.Add("codigo")
    '        dt.Columns.Add("gravado")
    '        dt.Columns.Add("idProducto")
    '        dt.Columns.Add("item")
    '        dt.Columns.Add("um")
    '        dt.Columns.Add("cantidad", GetType(Double))
    '        dt.Columns.Add("vcmn", GetType(Double))
    '        dt.Columns.Add("totalmn", GetType(Double))
    '        dt.Columns.Add("vcme", GetType(Double))
    '        dt.Columns.Add("totalme", GetType(Double))
    '        dt.Columns.Add("igvmn", GetType(Double))
    '        dt.Columns.Add("igvme", GetType(Double))
    '        dt.Columns.Add("tipoExistencia")
    '        dt.Columns.Add("almacen")
    '        dt.Columns.Add("pumn", GetType(Double))
    '        dt.Columns.Add("pume", GetType(Double))
    '        dt.Columns.Add("costoMN", GetType(Double))
    '        dt.Columns.Add("costoME", GetType(Double))
    '        dt.Columns.Add("pagado", GetType(Double))
    '        dt.Columns.Add("pagadoME", GetType(Double))
    '        dt.Columns.Add("estado", GetType(String))

    '        For Each i As documentoventaAbarrotesDet In listaDetalleProducto
    '            Dim dr As DataRow = dt.NewRow
    '            dr(0) = i.secuencia
    '            dr(1) = i.destino
    '            dr(2) = i.idItem
    '            dr(3) = i.nombreItem
    '            dr(4) = i.unidad1
    '            dr(5) = i.monto1

    '            dr(6) = i.montokardex
    '            dr(7) = i.importeMN
    '            dr(8) = i.montokardexUS
    '            dr(9) = i.importeME

    '            dr(10) = i.montoIgv
    '            dr(11) = i.montoIgvUS
    '            dr(12) = i.tipoExistencia
    '            'If i.tipoExistencia = "GS" Then
    '            '    dr(12) = String.Empty
    '            'Else
    '            dr(13) = i.idAlmacenOrigen
    '            'End If

    '            dr(14) = i.precioUnitario
    '            dr(15) = i.precioUnitarioUS
    '            dr(16) = i.salidaCostoMN
    '            dr(17) = i.salidaCostoME
    '            dr(18) = i.importeMN
    '            dr(19) = i.importeME
    '            dr(20) = "NO"
    '            dt.Rows.Add(dr)
    '        Next

    '        dgvVenta.DataSource = dt

    '    Catch ex As Exception
    '        MsgBox("Error al cargar datos." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")
    '    End Try
    'End Sub

    Public Sub ObtenerDetallePedido()
        Dim ventaDetalleSA As New documentoVentaAbarrotesDetSA

        Try
            Dim dt As New DataTable()
            dt.Columns.Add("codigo")
            dt.Columns.Add("gravado")
            dt.Columns.Add("idProducto")
            dt.Columns.Add("item")
            dt.Columns.Add("um")
            dt.Columns.Add("cantidad", GetType(Decimal))
            dt.Columns.Add("vcmn", GetType(Decimal))
            dt.Columns.Add("totalmn", GetType(Decimal))
            dt.Columns.Add("vcme", GetType(Decimal))
            dt.Columns.Add("totalme", GetType(Decimal))
            dt.Columns.Add("igvmn", GetType(Decimal))
            dt.Columns.Add("igvme", GetType(Decimal))
            dt.Columns.Add("tipoExistencia")
            dt.Columns.Add("almacen")
            dt.Columns.Add("pumn", GetType(Decimal))
            dt.Columns.Add("pume", GetType(Decimal))
            dt.Columns.Add("costoMN", GetType(Decimal))
            dt.Columns.Add("costoME", GetType(Decimal))
            dt.Columns.Add("pagado", GetType(Decimal))
            dt.Columns.Add("pagadoME", GetType(Decimal))
            dt.Columns.Add("estado", GetType(String))

            listaDetalleProducto = ventaDetalleSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(Tag)

            For Each i As documentoventaAbarrotesDet In listaDetalleProducto
                Dim dr As DataRow = dt.NewRow
                dr(0) = i.secuencia
                dr(1) = i.destino
                dr(2) = i.idItem
                dr(3) = i.nombreItem
                dr(4) = i.unidad1
                dr(5) = i.monto1

                dr(6) = i.montokardex
                dr(7) = i.importeMN
                dr(8) = i.montokardexUS
                dr(9) = i.importeME

                dr(10) = i.montoIgv
                dr(11) = i.montoIgvUS
                dr(12) = i.tipoExistencia
                'If i.tipoExistencia = "GS" Then
                '    dr(12) = String.Empty
                'Else
                dr(13) = i.idAlmacenOrigen
                'End If

                dr(14) = i.precioUnitario
                dr(15) = i.precioUnitarioUS
                dr(16) = i.salidaCostoMN
                dr(17) = i.salidaCostoME
                dr(18) = i.importeMN
                dr(19) = i.importeME
                dr(20) = "NO"
                dt.Rows.Add(dr)
            Next
            setDataSource(dt)
            'dgvVenta.DataSource = dt

        Catch ex As Exception
            MsgBox("Error al cargar datos." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")
        End Try
    End Sub

    Public Sub ObtenerVentaPorCodigo(strNumDoc As String)
        Dim docuemntoventaSA As New documentoVentaAbarrotesSA
        Dim docuemntoventa As New documentoventaAbarrotes
        Dim strxSerie As String = Nothing
        Dim monedaOpe As String = Nothing
        Try
            EntidadSeleccionda = New entidad
            '    ListaDetalleVenta = New List(Of documentoventaAbarrotes)
            strxSerie = String.Format("{0:00000}", txtSerieVenta.Text)
            docuemntoventa = docuemntoventaSA.GetObtenerVentaPorNumero(GEstableciento.IdEstablecimiento, PeriodoGeneral, TIPO_VENTA.VENTA_NOTA_PEDIDO, "9907", txtSeriePedido.Text, strNumDoc)
            If Not IsNothing(docuemntoventa) Then
                EntidadSeleccionda = EntidadSA.UbicarEntidadPorID(Val(docuemntoventa.idCliente)).FirstOrDefault
                'limpiarCajas()
                txtSerVenta.Clear()
                txtnroVenta.Clear()
                rbBoleta.Checked = False
                rbFactura.Checked = False

                lblPeriodo.Text = PeriodoGeneral

                DigitalGauge2.Value = "0.00"
                Me.Tag = String.Empty
                txtTipoCambio.Text = 0
                txtComprador.Text = String.Empty
                txtComprobante.Text = String.Empty
                txtNumeroVenta.Text = String.Empty
                txtSerieVenta.Text = String.Empty
                txtRuc.Text = String.Empty
                txtCliente.Text = String.Empty

                txtIgv.DecimalValue = 0
                txtIgvme.DecimalValue = 0
                txtTasaIgv.Value = 0
                dgvVenta.Table.Records.DeleteAll()

                txtCobroMN.DecimalValue = 0
                txtCobroMe.DecimalValue = 0

                Panel3.Enabled = True
                '   pnVentas.Enabled = True

                With docuemntoventa
                    txtFechaComprobante.Value = .fechaDoc
                    txtFechaComprobante.Enabled = False
                    Me.Tag = .idDocumento
                    txtTipoCambio.Text = .tipoCambio

                    '   lblInfoComprador.Text = "Comprador: " & .nombrePedido
                    txtComprobante.Text = .tipoDocumento
                    txtNumeroVenta.Text = .numeroDoc
                    txtSerieVenta.Text = .serie
                    txtMoneda.Text = .moneda
                    txtPeriodo.Text = .fechaPeriodo
                    txtIgv.DecimalValue = FormatNumber(.igv01, 2)
                    txtIgvme.DecimalValue = FormatNumber(.igv01us, 2)
                    txtTasaIgv.Value = .tasaIgv
                    'se agrego caja manual

                    cargarDatosEstadosFinan()
                    dgvPagos.Table.Records.DeleteAll()

                    'GridPago()
                    '   txtGlosa.Text = .glosa
                    txtMoneda.Text = .moneda

                    txtCobroMN.DecimalValue = FormatNumber(.ImporteNacional, 2)
                    txtCobroMe.DecimalValue = FormatNumber(.ImporteExtranjero, 2)

                    Select Case .moneda
                        Case 1
                            monedaOpe = "NACIONAL"
                            Dim c = CDec(.ImporteNacional).ToString("N2")
                            DigitalGauge2.Value = c 'FormatNumber(.ImporteNacional, 2)
                        Case 2
                            monedaOpe = "EXTRANJERA"
                            Dim c = CDec(.ImporteExtranjero).ToString("N2")
                            DigitalGauge2.Value = c 'FormatNumber(.ImporteNacional, 2)
                    End Select

                    If (.idCliente <> 0) Then
                        txtComprador.Visible = False
                        txtCliente.Visible = True
                        txtCliente.Text = .nombrePedido
                        txtCliente.Tag = .idCliente
                        txtRuc.Text = .NroDocEntidad
                        If txtRuc.Text.Length = 11 Then
                            rbFactura.Checked = True
                        Else
                            rbBoleta.Checked = True
                        End If
                    Else
                        txtCliente.Visible = False
                        txtComprador.Visible = True
                        txtComprador.Text = .nombrePedido
                        rbBoleta.Checked = True
                    End If
                End With
                dgvPagos.Table.Records.DeleteAll()
                For Each item In cajausuario
                    GridPago(item)
                Next
                cargarDatosProductos(docuemntoventa.idDocumento)
                ObtenerDetallePedido()
                TotalTalesXcolumna()
                saldoMN = DigitalGauge2.Value
            Else
                lblPeriodo.Text = ""
                txtSerVenta.Clear()
                txtnroVenta.Clear()
                rbBoleta.Checked = False
                rbFactura.Checked = False

                DigitalGauge2.Value = "0.00"
                Me.Tag = String.Empty
                txtTipoCambio.Text = 0
                txtComprador.Text = String.Empty
                txtComprobante.Text = String.Empty
                txtNumeroVenta.Text = String.Empty
                txtSerieVenta.Text = String.Empty

                txtIgv.DecimalValue = 0
                txtIgvme.DecimalValue = 0
                txtTasaIgv.Value = 0
                dgvVenta.Table.Records.DeleteAll()

                txtCobroMN.DecimalValue = 0
                txtCobroMe.DecimalValue = 0

                MessageBox.Show("El pedido ya fue procesado y/o no existe, ingrese otro número a consultar.", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNumeroPedido.Focus()
                txtNumeroPedido.Select(0, txtNumeroPedido.Text.Length)
                Panel3.Enabled = False
                '   pnVentas.Enabled = False
                txtNumeroPedido.Select(0, txtNumeroPedido.Text.Length)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub ObtenerVentaPorIdDocumento(iddoc As Integer)
        Dim docuemntoventaSA As New documentoVentaAbarrotesSA
        Dim docuemntoventa As New documentoventaAbarrotes
        Dim strxSerie As String = Nothing
        Dim monedaOpe As String = Nothing
        Try
            EntidadSeleccionda = New entidad
            '    ListaDetalleVenta = New List(Of documentoventaAbarrotes)
            strxSerie = String.Format("{0:00000}", txtSerieVenta.Text)
            docuemntoventa = docuemntoventaSA.GetUbicar_documentoventaAbarrotesPorID(iddoc)
            If Not IsNothing(docuemntoventa) Then

                If docuemntoventa.estadoCobro = "PN" Then
                    EntidadSeleccionda = EntidadSA.UbicarEntidadPorID(Val(docuemntoventa.idCliente)).FirstOrDefault
                    'limpiarCajas()
                    txtSerVenta.Clear()
                    txtnroVenta.Clear()
                    rbBoleta.Checked = False
                    rbFactura.Checked = False

                    lblPeriodo.Text = PeriodoGeneral

                    DigitalGauge2.Value = "0.00"
                    Me.Tag = String.Empty
                    txtTipoCambio.Text = 0
                    txtComprador.Text = String.Empty
                    txtComprobante.Text = String.Empty
                    txtNumeroVenta.Text = String.Empty
                    txtSerieVenta.Text = String.Empty
                    txtRuc.Text = String.Empty
                    txtCliente.Text = String.Empty

                    txtIgv.DecimalValue = 0
                    txtIgvme.DecimalValue = 0
                    txtTasaIgv.Value = 0
                    dgvVenta.Table.Records.DeleteAll()

                    txtCobroMN.DecimalValue = 0
                    txtCobroMe.DecimalValue = 0

                    Panel3.Enabled = True
                    '   pnVentas.Enabled = True

                    With docuemntoventa

                        txtNumeroPedido.Text = .numeroDoc

                        txtFechaComprobante.Value = .fechaDoc
                        txtFechaComprobante.Enabled = False
                        Me.Tag = .idDocumento
                        txtTipoCambio.Text = .tipoCambio

                        '   lblInfoComprador.Text = "Comprador: " & .nombrePedido
                        txtComprobante.Text = .tipoDocumento
                        txtNumeroVenta.Text = .numeroDoc

                        txtSerieVenta.Text = .serie
                        txtMoneda.Text = .moneda
                        txtPeriodo.Text = .fechaPeriodo
                        txtIgv.DecimalValue = FormatNumber(.igv01, 2)
                        txtIgvme.DecimalValue = FormatNumber(.igv01us, 2)
                        txtTasaIgv.Value = .tasaIgv
                        'se agrego caja manual

                        cargarDatosEstadosFinan()
                        dgvPagos.Table.Records.DeleteAll()

                        'GridPago()
                        '   txtGlosa.Text = .glosa
                        txtMoneda.Text = .moneda

                        txtCobroMN.DecimalValue = FormatNumber(.ImporteNacional, 2)
                        txtCobroMe.DecimalValue = FormatNumber(.ImporteExtranjero, 2)

                        Select Case .moneda
                            Case 1
                                monedaOpe = "NACIONAL"
                                Dim c = CDec(.ImporteNacional).ToString("N2")
                                DigitalGauge2.Value = c 'FormatNumber(.ImporteNacional, 2)
                            Case 2
                                monedaOpe = "EXTRANJERA"
                                Dim c = CDec(.ImporteExtranjero).ToString("N2")
                                DigitalGauge2.Value = c 'FormatNumber(.ImporteNacional, 2)
                        End Select

                        If (.idCliente <> 0) Then
                            txtComprador.Visible = False
                            txtCliente.Visible = True
                            txtCliente.Text = .nombrePedido
                            txtCliente.Tag = .idCliente
                            txtRuc.Text = .NroDocEntidad
                            If txtRuc.Text.Length = 11 Then
                                rbFactura.Checked = True
                            Else
                                rbBoleta.Checked = True
                            End If
                        Else
                            txtCliente.Visible = False
                            txtComprador.Visible = True
                            txtComprador.Text = .nombrePedido
                            rbBoleta.Checked = True
                        End If
                    End With
                    dgvPagos.Table.Records.DeleteAll()
                    For Each item In cajausuario
                        GridPago(item)
                    Next


                Else
                    MessageBox.Show("El comprobante ya fue cobrado!", "Venta cobrada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            Else
                lblPeriodo.Text = ""
                txtSerVenta.Clear()
                txtnroVenta.Clear()
                rbBoleta.Checked = False
                rbFactura.Checked = False

                DigitalGauge2.Value = "0.00"
                Me.Tag = String.Empty
                txtTipoCambio.Text = 0
                txtComprador.Text = String.Empty
                txtComprobante.Text = String.Empty
                txtNumeroVenta.Text = String.Empty
                txtSerieVenta.Text = String.Empty

                txtIgv.DecimalValue = 0
                txtIgvme.DecimalValue = 0
                txtTasaIgv.Value = 0
                dgvVenta.Table.Records.DeleteAll()

                txtCobroMN.DecimalValue = 0
                txtCobroMe.DecimalValue = 0

                MessageBox.Show("El pedido ya fue procesado y/o no existe, ingrese otro número a consultar.", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNumeroPedido.Focus()
                txtNumeroPedido.Select(0, txtNumeroPedido.Text.Length)
                Panel3.Enabled = False
                '   pnVentas.Enabled = False
                txtNumeroPedido.Select(0, txtNumeroPedido.Text.Length)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'Sub limpiarCajas()
    '    txtImporteCompramn.Value = 0
    '    txtImporteComprame.Value = 0
    '    txtTipoCambioCobro.Value = 0
    '    txtVueltoMN.Text = 0
    '    txtVueltoME.Text = 0
    'End Sub

    Sub Aplica()
        Dim DT As String
        'Para adaptar a la configuracion del PC huesped.
        DT = Replace(txtNumeroPedido.Text, ".", Sep)
        DT = Replace(DT, ",", Sep)
        '  Label1.Text = CDbl(DT)
        On Error Resume Next
        txtNumeroPedido.SelectionStart = 0
        txtNumeroPedido.SelectionLength = Len(txtNumeroPedido.Text)
        txtNumeroPedido.Focus()
    End Sub

#End Region

    Dim colorx As New GridMetroColors()
    Sub GridCFG(GGC As GridGroupingControl)
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
        'GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways

        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None

        'GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        'GGC.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left
        GGC.WantTabKey = True
        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Function DataSourceAlmacen() As DataTable
        Dim entidadSA As New EstadosFinancierosSA

        Dim dt As New DataTable()
        dt.Columns.Add("identidad")
        dt.Columns.Add("entidad")

        For Each i In entidadSA.ObtenerEstadosFinancierosPorEstablecimiento(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idestado
            dr(1) = i.descripcion
            dt.Rows.Add(dr)
        Next

        Return dt

    End Function

    Private Sub frmCobroPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvPagos.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        txtSeriePedido.EnableTouchMode = False
        txtNumeroPedido.EnableTouchMode = False
        btOperacion.EnableTouchMode = False
        Label19.Visible = False

    End Sub

    Private Sub txtNumeroPedido_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroPedido.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtSeriePedido.Text.Trim.Length > 0 Then
                Aplica()
                If txtNumeroPedido.Text.Trim.Length > 0 Then
                    ObtenerVentaPorCodigo(txtNumeroPedido.Text.Trim)
                Else
                    '    lblInfoComprador.Text = String.Empty
                    DigitalGauge2.Value = "0.00"
                End If
            Else
                MessageBox.Show("Ingrese el número de serie de venta!")
            End If
        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtNumeroPedido_TextChanged(sender As Object, e As EventArgs) Handles txtNumeroPedido.TextChanged
        If txtNumeroPedido.Text = Sep Then
            'si el separador decimal es tecleado directamente
            txtNumeroPedido.Text = "0" & Sep
            txtNumeroPedido.SelectionStart = Len(txtNumeroPedido.Text)
        ElseIf Not IsNumeric(Trim(txtNumeroPedido.Text)) Then
            Beep()
            If Len(txtNumeroPedido.Text) < 1 Then
                txtNumeroPedido.Text = ""
            Else
                txtNumeroPedido.Text = Microsoft.VisualBasic.Left(txtNumeroPedido.Text, Len(txtNumeroPedido.Text) - 1)
                txtNumeroPedido.SelectionStart = Len(txtNumeroPedido.Text)
            End If
        End If
    End Sub

    Private Sub rbBoleta_CheckedChanged(sender As Object, e As EventArgs) Handles rbBoleta.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        If rbBoleta.Checked = True Then
            Label19.Visible = False
            Label5.Visible = False
            GConfiguracion = New GConfiguracionModulo
            configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT2", Me.Text, GEstableciento.IdEstablecimiento)


            If (txtRuc.Text.Length = 11) Then

                Label5.Visible = True
                txtCliente.Visible = True
                txtComprador.Visible = False
                Label19.Visible = True
                'limpiarBoleta()
                CargarCajasComprobante(True)
                Label16.Location = New Point(541, 37)
                txtMonenda.Location = New Point(543, 55)
                'pnVentas.Size = New Size(357, 127)
                'pnDatos.Location = New Point(0, 418)
                txtRuc.Select()
                txtRuc.SelectAll()
                TipoTicket = "ConRUC"
            Else
                If (CDec(txtCobroMN.DecimalValue > 699.99)) Then
                    '    limpiarBoleta()
                    'CargarCajasComprobante(True)
                    '    pnVentas.Size = New Size(357, 127)
                    TipoTicket = "ConRUC"
                    txtRuc.Select()
                    txtRuc.SelectAll()
                    Label19.Visible = False
                    PictureBox3.Visible = True
                    Label5.Visible = True
                    txtRuc.Visible = True
                    Label16.Location = New Point(541, 37)
                    txtMonenda.Location = New Point(543, 55)

                    '   rbFactura.Enabled = False
                ElseIf txtRuc.Text.Length = 8 Then
                    '  limpiarBoleta()
                    'CargarCajasComprobante(True)
                    '    pnVentas.Size = New Size(357, 127)
                    TipoTicket = "SinRUC"
                    txtRuc.Select()
                    txtRuc.SelectAll()
                    Label19.Visible = False
                    PictureBox3.Visible = True
                    Label5.Visible = True
                    txtRuc.Visible = True
                    Label16.Location = New Point(541, 37)
                    txtMonenda.Location = New Point(543, 55)
                Else
                    txtComprador.Visible = True
                    PictureBox3.Visible = False
                    Label5.Visible = False
                    txtCliente.Visible = False
                    txtRuc.Visible = False
                    limpiarBoleta()
                    CargarCajasComprobante(False)
                    Label16.Location = New Point(373, 37)
                    txtMonenda.Location = New Point(375, 55)
                    'pnVentas.Size = New Size(357, 80)
                    TipoTicket = "SinRUC"
                End If
            End If

            'If (CDec(txtCobroMN.DecimalValue > 699.99)) Then
            '    limpiarBoleta()
            '    'CargarCajasComprobante(True)
            '    '    pnVentas.Size = New Size(357, 127)
            '    TipoTicket = "ConRUC"
            '    txtRuc.Select()
            '    txtRuc.SelectAll()

            '    PictureBox3.Visible = True
            '    Label5.Visible = True
            '    txtRuc.Visible = True
            '    Label16.Location = New Point(541, 37)
            '    txtMonenda.Location = New Point(543, 55)
            'Else
            '    PictureBox3.Visible = False
            '    Label5.Visible = False
            '    txtRuc.Visible = False
            '    limpiarBoleta()
            '    CargarCajasComprobante(False)
            '    Label16.Location = New Point(373, 37)
            '    txtMonenda.Location = New Point(375, 55)
            '    'pnVentas.Size = New Size(357, 80)
            '    TipoTicket = "SinRUC"
            'End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub rbFactura_CheckedChanged(sender As Object, e As EventArgs) Handles rbFactura.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        If rbFactura.Checked = True Then
            Label5.Visible = False
            Label19.Visible = True
            'limpiarBoleta()
            GConfiguracion = New GConfiguracionModulo
            configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT3", Me.Text, GEstableciento.IdEstablecimiento)
            CargarCajasComprobante(True)
            Label16.Location = New Point(541, 37)
            txtMonenda.Location = New Point(543, 55)
            'pnVentas.Size = New Size(357, 127)
            'pnDatos.Location = New Point(0, 418)
            txtRuc.Select()
            txtRuc.SelectAll()
            TipoTicket = "ConRUC"
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad
        Me.Cursor = Cursors.WaitCursor
        Try

            Dim sumaPagos As Decimal = 0
            Dim totalPago As Decimal = 0
            For Each i In dgvPagos.Table.Records
                sumaPagos += CDec(i.GetValue("montoMN"))
                If (i.GetValue("moneda") = "EXTRANJERO") Then
                    If (i.GetValue("montoME") = 0) Then
                        Throw New Exception("Debe Ingresar importe extranjero!")
                    End If

                End If
            Next

            If (sumaPagos) = txtCobroMN.DecimalValue Then
                If dgvVenta.Table.Records.Count > 0 Then

                    'llenarDatos()
                    'imprimir(True)
                    CalculoPagos()
                    ConfirmarVenta()
                    limpiarConfirmarVenta()
                    Close()
                End If
            Else
                MessageBoxAdv.Show("Debe realizar el cobro en su integridad, no parcial!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmCobroPedidos_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT1", Me.Text, GEstableciento.IdEstablecimiento)
        txtNumeroPedido.Select()
        txtNumeroPedido.Focus()
    End Sub

    Private Sub btnMin_Click(sender As Object, e As EventArgs)
        If dgvPagos.Table.Records.Count > 0 Then
            lsvPagosRegistrados.Items.Clear()
            dgvPagos.Table.Records.Delete(dgvPagos.Table.CurrentRecord)
            CalculoPagos()
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub
    Public Sub UbicarEntidadPorRuc(strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                txtCliente.Text = .nombreCompleto
                txtCliente.Tag = .idEntidad
                '   txtCuenta.Text = .cuentaAsiento
                txtRuc.Text = .nrodoc
            End With
        Else
            txtCliente.Clear()
            '  txtCuenta.Clear()
            txtRuc.Clear()
            If MessageBoxAdv.Show("Desea crear un nuevo cliente?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Dim f As New frmCrearENtidades
                f.CaptionLabels(0).Text = "Nuevo cliente"
                f.strTipo = TIPO_ENTIDAD.CLIENTE
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        End If
    End Sub
    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtRuc.Text.Trim.Length > 0 Then
                UbicarEntidadPorRuc(txtRuc.Text.Trim)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnEliminarItem_Click(sender As Object, e As EventArgs) Handles btnEliminarItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ventaSA As New documentoVentaAbarrotesDetSA
        Dim venta As New documentoventaAbarrotesDet
        Dim documentoSA As New DocumentoSA
        If Not IsNothing(dgvVenta.Table.CurrentRecord) Then

            If (dgvVenta.Table.Records.Count > 1) Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    venta.idDocumento = Me.Tag
                    venta.secuencia = dgvVenta.Table.CurrentRecord.GetValue("codigo")
                    ventaSA.DeleteItemVenta(venta)
                    dgvVenta.Table.DeleteRecord(dgvVenta.Table.CurrentRecord)
                    dgvVenta.Refresh()
                    If txtNumeroPedido.Text.Trim.Length > 0 Then
                        ObtenerVentaPorCodigo(txtNumeroPedido.Text.Trim)
                    End If
                End If
            ElseIf (dgvVenta.Table.Records.Count = 1) Then
                If MessageBox.Show("Se eliminará el documento?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    venta.idDocumento = Me.Tag

                    documentoSA.DeleteSingleVariable(Me.Tag)
                    Dispose()
                    'dgvVenta.Table.DeleteRecord(dgvVenta.Table.CurrentRecord)
                    'dgvVenta.Refresh()
                    'If txtNumeroPedido.Text.Trim.Length > 0 Then
                    '    ObtenerVentaPorCodigo(txtNumeroPedido.Text.Trim)
                    'End If
                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvPagos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPagos.TableControlCellClick

    End Sub

    Private Sub DockingClientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles DockingClientPanel1.Paint

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        If txtNumeroPedido.Text.Trim.Length > 0 Then
            ObtenerVentaPorCodigo(txtNumeroPedido.Text.Trim)
        Else
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click

        cboTipoPago.Text = "EFECTIVO"
        Me.dgvPagos.Table.Records.DeleteAll()
        saldoMN = DigitalGauge2.Value
        lsvPagosRegistrados.Items.Clear()
        dgvVenta.Table.Records.DeleteAll()
        ObtenerDetallePedido()

    End Sub

    Private Sub cboMoneda_Click(sender As Object, e As EventArgs) Handles cboMoneda.Click
        cboMoneda.Tag = 1
    End Sub

    Private Sub dgvPagos_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs)

        '************************** use usa para cambiar todo la fila el color *******************************

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
                                e.Style.BackColor = ColorTranslator.FromHtml("#FFD01212")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                            Case "EXTRANJERO"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FF2E8B57")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                        End Select


                    Case "BANCO"
                        Select Case moneda
                            Case "NACIONAL"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FF212121")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                            Case "EXTRANJERO"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FF484747")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                        End Select


                    Case "TARJETA CREDITO"
                        Select Case moneda
                            Case "NACIONAL"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FFD28306")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                            Case "EXTRANJERO"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FFB67208")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
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

                    e.Style.BackColor = Color.FromArgb(255, 255, 128)
                    e.Style.TextColor = Color.Black
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 10
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If


            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "saldo")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("saldo")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue

                    e.Style.BackColor = Color.FromArgb(255, 255, 128)
                    e.Style.TextColor = Color.Black
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 10
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If

            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "montoMN")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("montoMN")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue

                    e.Style.BackColor = Color.FromArgb(255, 255, 128)
                    e.Style.TextColor = Color.Black
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 10
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If

            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "montoME")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("montoME")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue

                    e.Style.BackColor = Color.FromArgb(255, 255, 128)
                    e.Style.TextColor = Color.Black
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 10
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
                    e.Style.Font.Size = 10
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"
                End If
            End If
        End If

        'End If
    End Sub

    Private Sub WriteStyles(pBox As PictureBox)
        Select Case pBox.Name
            Case "PictureBox9"
                Label7.Text = "Efectivo - MN."
            Case "PictureBox2"
                Label7.Text = "Efectivo - ME."
            Case "PictureBox5"
                Label7.Text = "Banco - MN."
            Case "PictureBox4"
                Label7.Text = "Banco - ME."
            Case "PictureBox10"
                Label7.Text = "Trajeta crédito - MN."
            Case "PictureBox6"
                Label7.Text = "Trajeta crédito - ME."
        End Select
        Label7.Visible = True
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs)
        dgvPagos.Table.Records.DeleteAll()
        ObtenerDetallePedido()
        saldoMN = DigitalGauge2.Value
    End Sub

    Private Sub dgvPagos_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvPagos.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim sumaPagos As Double = 0
        Dim sumaPagosME As Double = 0
        Dim sumatotal As Double = 0
        Dim numerOper As String
        Dim CobroMN As Decimal
        Dim CobroME As Decimal
        Dim importeIngreso As Decimal
        Dim tipoCambio As Decimal
        Dim calculoSaldoME As Decimal
        Dim entidadSA As New EstadosFinancierosSA
        Dim importeTotalRecibido As Decimal = 0
        Dim vueltoTotalEntregar As Decimal = 0
        Dim importeCobrado As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim contador As Integer = 0
        Dim ultimoSaldo As Decimal = 0
        Try
            If Not IsNothing(Me.dgvPagos.Table.CurrentRecord) Then
                Select Case ColIndex

                    Case 4 ' importe recibido

                        If (chTipoMovimientoCaja.Tag = 0) Then

                            If (CDec(txtImporteCobrado.Text) <> CDec(DigitalGauge2.Value)) Then
                                For Each i In dgvPagos.Table.Records
                                    importeCobrado += i.GetValue("importePendiente")
                                    ultimoSaldo = (CDec(DigitalGauge2.Value))
                                    totalMN = i.GetValue("importePendiente")
                                    CobroMN = i.GetValue("montoMN")
                                    If (i.GetValue("moneda") = "NACIONAL") Then
                                        If (totalMN > 0) Then
                                            If (Pago = "DC") Then
                                                If (totalMN >= CDec(DigitalGauge2.Value)) Then

                                                    If (contador = 0) Then
                                                        i.SetValue("montoMN", i.GetValue("importePendiente") - (i.GetValue("importePendiente") - CDec(DigitalGauge2.Value)))
                                                        i.SetValue("montoME", 0)
                                                        i.SetValue("vueltoMN", i.GetValue("importePendiente") - CDec(DigitalGauge2.Value))
                                                        i.SetValue("vueltoME", CDec((i.GetValue("importePendiente") - CDec(DigitalGauge2.Value)) / TmpTipoCambio))
                                                        i.SetValue("saldo", 0.0)
                                                        Pago = "PG"
                                                    Else
                                                        i.SetValue("montoMN", totalMN - (importeCobrado - CDec(ultimoSaldo)))
                                                        i.SetValue("montoME", 0)
                                                        i.SetValue("vueltoMN", importeCobrado - CDec(ultimoSaldo))
                                                        i.SetValue("vueltoME", 0)
                                                        i.SetValue("saldo", 0.0)
                                                    End If

                                                ElseIf (ultimoSaldo > CDec(totalMN)) Then

                                                    If (((ultimoSaldo)) > importeCobrado) Then
                                                        i.SetValue("montoMN", totalMN)
                                                        i.SetValue("montoME", 0)
                                                        i.SetValue("vueltoMN", 0)
                                                        i.SetValue("vueltoME", 0)
                                                        i.SetValue("saldo", (CDec(ultimoSaldo)) - importeCobrado)
                                                        contador += 1
                                                    Else
                                                        i.SetValue("montoMN", totalMN - (importeCobrado - CDec(ultimoSaldo)))
                                                        i.SetValue("montoME", 0)
                                                        i.SetValue("vueltoMN", importeCobrado - CDec(ultimoSaldo))
                                                        i.SetValue("vueltoME", 0)
                                                        i.SetValue("saldo", 0.0)
                                                        Pago = "PG"
                                                    End If

                                                End If
                                            Else


                                                'If (totalMN <> CobroMN) Then
                                                '    contador += 1
                                                '    If (contador <> 0) Then
                                                If (((ultimoSaldo)) > importeCobrado) Then
                                                    i.SetValue("montoMN", totalMN)
                                                    i.SetValue("montoME", 0)
                                                    i.SetValue("vueltoMN", 0)
                                                    i.SetValue("vueltoME", 0)
                                                    i.SetValue("saldo", (CDec(ultimoSaldo)) - importeCobrado)
                                                    contador += 1
                                                Else
                                                    i.SetValue("montoMN", totalMN - (importeCobrado - CDec(ultimoSaldo)))
                                                    i.SetValue("montoME", 0)
                                                    i.SetValue("vueltoMN", importeCobrado - CDec(ultimoSaldo))
                                                    i.SetValue("vueltoME", 0)
                                                    i.SetValue("saldo", 0.0)
                                                    Pago = "PG"
                                                End If
                                                'End If
                                                'Else
                                                '    'dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                                                '    'dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                                '    'dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                                '    'dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                                '    'dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                                '    'dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                                '    'PanelError.Visible = True
                                                '    'lblEstado.Text = "El pago ya se realizo en su totalidad!"
                                                '    'Timer1.Enabled = True
                                                '    'TiempoEjecutar(10)
                                                'End If

                                            End If
                                        End If
                                    End If
                                Next

                                txtImporteRecibido.Text = 0.0
                                txtImporteCobrado.Text = 0.0
                                txtVueltoMN.Text = 0.0
                                For Each x In dgvPagos.Table.Records
                                    txtImporteRecibido.Text += x.GetValue("importePendiente")
                                    txtImporteCobrado.Text += x.GetValue("montoMN")
                                    txtVueltoMN.Text += x.GetValue("vueltoMN")
                                Next
                            Else
                                If MessageBox.Show("Desea reiniciar los pagos?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    dgvPagos.Table.Records.DeleteAll()
                                    CMBCajasDelUsuarioPV()
                                    txtImporteCobrado.Text = 0.0
                                    txtImporteRecibido.Text = 0.0
                                    txtVueltoMN.Text = 0.0
                                    saldoMN = 0.0
                                    Pago = "DC"
                                Else
                                    dgvPagos.Table.CurrentRecord.SetValue("importePendiente", dgvPagos.Table.CurrentRecord.GetValue("montoMN"))
                                    MessageBox.Show("El pago ya se realizo en su totalidad!")
                                End If
                            End If

                        ElseIf (chTipoMovimientoCaja.Tag = 1) Then



                            If (dgvPagos.Table.CurrentRecord.GetValue("importePendiente") > 0) Then


                                If (dgvPagos.Table.CurrentRecord.GetValue("moneda") = "NACIONAL") Then
                                    importeIngreso = dgvPagos.Table.CurrentRecord.GetValue("importePendiente")
                                    'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                    dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                    dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                    dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                    'dgvVenta.Table.Records.DeleteAll()
                                    'ObtenerDetallePedido()

                                    dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                    saldoMN = 0
                                    For Each i In dgvPagos.Table.Records
                                        If (i.GetValue("saldo") <> 0) Then
                                            saldoMN = CDec(i.GetValue("saldo"))
                                        End If
                                        'importeTotalRecibido += CDec(i.GetValue("importePendiente"))
                                    Next
                                    If (saldoMN = 0) Then
                                        numerOper = DigitalGauge2.Value
                                        'importeCobrado = numerOper

                                    Else
                                        numerOper = saldoMN
                                    End If

                                    If (dgvPagos.Table.Records.Count > 0) Then

                                    Else

                                    End If

                                    If (importeIngreso >= CDec(DigitalGauge2.Value)) Then
                                        'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", TmpTipoCambio)
                                        'dgvPagos.Table.CurrentRecord.SetValue("montoME", CDec(DigitalGauge2.Value / TmpTipoCambio))
                                        dgvPagos.Table.CurrentRecord.SetValue("montoMN", CDec(DigitalGauge2.Value))
                                        'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", importeIngreso - CDec(DigitalGauge2.Value))
                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoME", CDec((importeIngreso - CDec(DigitalGauge2.Value)) / TmpTipoCambio))
                                        dgvPagos.Table.CurrentRecord.SetValue("saldo", CDec(numerOper) - CDec(DigitalGauge2.Value))

                                    ElseIf (importeIngreso < CDec(DigitalGauge2.Value)) Then
                                        'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", TmpTipoCambio)
                                        'dgvPagos.Table.CurrentRecord.SetValue("montoME", CDec(importeIngreso / TmpTipoCambio))
                                        dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)

                                        'txtTotalBase.Text = importeTotalRecibido
                                        'txtRetencion.Text = 0.0
                                        'txtTotalIva.Text = 0.0
                                    End If
                                    'lsvPagosRegistrados.Items.Clear()
                                    'CalculoPagos(r)
                                Else
                                    dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                    dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                    dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                    'txtTotalBase.Text = importeTotalRecibido
                                End If
                            Else
                                dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                                'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                'txtTotalBase.Text = 0.0
                                'txtRetencion.Text = 0.0
                                'txtTotalIva.Text = 0.0
                                MessageBox.Show("el monto no debe ser negativo!")
                            End If
                            'End If
                            txtImporteRecibido.Text = 0.0
                            txtImporteCobrado.Text = 0.0
                            txtVueltoMN.Text = 0.0
                            For Each x In dgvPagos.Table.Records
                                importeTotalRecibido += x.GetValue("importePendiente")
                                importeCobrado += x.GetValue("montoMN")
                                vueltoTotalEntregar += x.GetValue("vueltoMN")
                            Next
                            txtImporteRecibido.Text = importeTotalRecibido
                            txtImporteCobrado.Text = importeCobrado
                            txtVueltoMN.Text = vueltoTotalEntregar
                        End If

                    Case 5 ' moneda nacional
                        CobroMN = dgvPagos.Table.CurrentRecord.GetValue("montoMN")
                        importeIngreso = dgvPagos.Table.CurrentRecord.GetValue("importePendiente")

                        If (CobroMN > 0) Then
                            If (importeIngreso > 0) Then
                                dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                saldoMN = 0
                                For Each i In dgvPagos.Table.Records
                                    If (i.GetValue("saldo") <> 0) Then
                                        saldoMN = i.GetValue("saldo")
                                    End If
                                    'importeTotalRecibido += i.GetValue("montoMN")
                                    'vueltoTotalEntregar += i.GetValue("vueltoMN")
                                Next
                                If (saldoMN = 0) Then
                                    numerOper = DigitalGauge2.Value
                                Else
                                    numerOper = saldoMN
                                End If



                                If (dgvPagos.Table.CurrentRecord.GetValue("moneda") = "EXTRANJERO") Then

                                    CobroME = CDec(CobroMN / dgvPagos.Table.CurrentRecord.GetValue("tipocambio"))

                                    If (CobroME <> 0 And CobroMN <> 0) Then
                                        If (CobroME <= importeIngreso) Then
                                            If (CobroMN <= numerOper) Then
                                                'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", CDec(CobroMN / CobroME).ToString("N3"))
                                                tipoCambio = dgvPagos.Table.CurrentRecord.GetValue("tipocambio")
                                                If (numerOper <= CobroMN) Then
                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", ((importeIngreso - CobroME) * tipoCambio))
                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoME", (importeIngreso - CobroME))
                                                    dgvPagos.Table.CurrentRecord.SetValue("saldo", (0.0))
                                                    dgvPagos.Table.CurrentRecord.SetValue("montoME", (CobroME))
                                                Else

                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoME", (importeIngreso - CobroME))
                                                    dgvPagos.Table.CurrentRecord.SetValue("montoME", (CobroME))
                                                    If (numerOper > CobroMN) Then
                                                        dgvPagos.Table.CurrentRecord.SetValue("saldo", (numerOper - CobroMN))
                                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", ((importeIngreso - CobroME) * tipoCambio))
                                                    Else
                                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", ((importeIngreso - CobroME) * tipoCambio))
                                                        dgvPagos.Table.CurrentRecord.SetValue("saldo", (numerOper - CobroMN))
                                                    End If

                                                End If

                                                'txtRetencion.Text = importeTotalRecibido
                                                'txtTotalIva.Text = (vueltoTotalEntregar) - dgvPagos.Table.CurrentRecord.GetValue("montoMn")
                                                'lsvPagosRegistrados.Items.Clear()
                                                'CalculoPagos()
                                            Else

                                                If (CobroMN > numerOper) Then
                                                    'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                                    dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                                    dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                                    dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                                    MessageBox.Show("No debe exceder el monto permitido!")
                                                Else
                                                    dgvPagos.Table.CurrentRecord.SetValue("tipocambio", CDec(CobroMN / CobroME).ToString("N3"))
                                                    tipoCambio = dgvPagos.Table.CurrentRecord.GetValue("tipocambio")
                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", ((importeIngreso - CobroME) * tipoCambio))
                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoME", (importeIngreso - CobroME))
                                                    dgvPagos.Table.CurrentRecord.SetValue("saldo", (0.0))
                                                End If

                                            End If
                                        Else
                                            dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                            MessageBox.Show("No debe exceder el monto permitido!")
                                        End If



                                    Else
                                        calculoSaldoME = CDec(CobroMN / TmpTipoCambioTransaccionCompra)

                                        If (calculoSaldoME <= importeIngreso) Then


                                            If (CobroMN <= numerOper) Then
                                                'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", (TmpTipoCambio))
                                                'dgvPagos.Table.CurrentRecord.SetValue("montoME", (CobroMN / TmpTipoCambio))
                                                'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", (0))
                                                dgvPagos.Table.CurrentRecord.SetValue("montoME", CDec(CobroMN / TmpTipoCambioTransaccionCompra))
                                                dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", (importeIngreso - CDec(CobroMN / TmpTipoCambioTransaccionCompra)) * TmpTipoCambioTransaccionCompra)
                                                dgvPagos.Table.CurrentRecord.SetValue("vueltoME", importeIngreso - CDec(CobroMN / TmpTipoCambioTransaccionCompra)) '((importeIngreso - CobroMN) / TmpTipoCambio))
                                                dgvPagos.Table.CurrentRecord.SetValue("saldo", (numerOper - CobroMN))
                                                'lsvPagosRegistrados.Items.Clear()
                                                'CalculoPagos()
                                            Else
                                                dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                                dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                                dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                                dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                                dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                                MessageBox.Show("No debe exceder el monto permitido!")
                                            End If
                                        Else
                                            dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                            MessageBox.Show("No debe exceder el monto permitido!")
                                        End If

                                    End If

                                Else

                                    If (CobroMN <= importeIngreso) Then
                                        If (CobroMN <= numerOper) Then
                                            'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", (TmpTipoCambio))
                                            'dgvPagos.Table.CurrentRecord.SetValue("montoME", (CobroMN / TmpTipoCambio))
                                            'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", (0))
                                            dgvPagos.Table.CurrentRecord.SetValue("montoME", (0))
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", (importeIngreso - CobroMN))
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0) '((importeIngreso - CobroMN) / TmpTipoCambio))
                                            dgvPagos.Table.CurrentRecord.SetValue("saldo", (numerOper - CobroMN))


                                            'txtRetencion.Text = importeTotalRecibido
                                            'txtTotalIva.Text = (vueltoTotalEntregar) - dgvPagos.Table.CurrentRecord.GetValue("montoMn")

                                            'lsvPagosRegistrados.Items.Clear()
                                            'CalculoPagos()
                                        Else
                                            'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)

                                            'txtRetencion.Text = 0.0
                                            'txtTotalIva.Text = 0.0
                                            MessageBox.Show("No debe exceder el monto permitido!")
                                          
                                        End If
                                    Else
                                        'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)

                                        MessageBox.Show("No debe exceder el monto permitido!")

                                    End If

                                End If
                            Else
                                'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                MessageBox.Show("debe ingresar monto recibido!")
                            End If
                        Else
                            'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                            dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                            dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                            dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)

                            MessageBox.Show("El importe no debe ser negativo!")
                          
                        End If
                        txtImporteRecibido.Text = 0.0
                        txtImporteCobrado.Text = 0.0
                        txtVueltoMN.Text = 0.0
                        For Each x In dgvPagos.Table.Records
                            importeTotalRecibido += x.GetValue("importePendiente")
                            importeCobrado += x.GetValue("montoMN")
                            vueltoTotalEntregar += x.GetValue("vueltoMN")
                        Next
                        txtImporteRecibido.Text = importeTotalRecibido
                        txtImporteCobrado.Text = importeCobrado
                        txtVueltoMN.Text = vueltoTotalEntregar

                    Case 7

                End Select
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class