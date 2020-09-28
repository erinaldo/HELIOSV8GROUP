Imports System.Drawing.Printing
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmVentasMaestro

#Region "Attributes"
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim filter As New GridExcelFilter()
    Dim cierreSA As New empresaCierreMensualSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)

    Public Property empresaAnioSA As New empresaPeriodoSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid(dgPedidos)
        Meses()
        ValidandoModulos()
    End Sub
#End Region

#Region "Methods"
    Private Sub ValidandoModulos()

        If Gempresas.IDProducto = "23" Then ' PosV00
            'entradas
            ToolStripMenuItem9.Visible = False
            ToolStripMenuItem11.Visible = False
            PUNTODEVENTACREDITOToolStripMenuItem.Visible = False
            PUNTODEVENTAMULTIUSOToolStripMenuItem.Visible = False
            VENTAFORMATOGENERALCONTADOToolStripMenuItem.Visible = False
            VENTAFORMATOGENERALCRÉDITOToolStripMenuItem.Visible = False
            VENTAFORMATOGENERALMULTIUSOToolStripMenuItem.Visible = False
            FghfToolStripMenuItem.Visible = False
            ToolStripMenuItem14.Visible = False
            NotaDeCreditoToolStripMenuItem.Visible = True
            ToolStripButton1.Visible = True
            VentaPOSContadoEntregaParcialToolStripMenuItem.Visible = False
        Else

        End If
    End Sub
    Public Function ValidarStock(idDocVenta As Integer)
        Dim documentoventa As New documentoVentaAbarrotesSA

        Dim sintock As Integer = 0
        sintock = documentoventa.StockEliminarNotaVenta(idDocVenta)

        Return sintock
    End Function




    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgPedidos.DataSource = table
            ProgressBar1.Visible = False
        End If
    End Sub

    Sub ImprimirTicket()
        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim ticket As New CrearTicket()

        Dim r As Record = dgPedidos.Table.CurrentRecord
        Dim entidadSA As New entidadSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(CInt(r.GetValue("idDocumento")))
        Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(Val(r.GetValue("idDocumento")))


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
        ticket.TextoExtremos("Caja # 1", "Ticket # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
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
        ' ticket.ImprimirTicket("BIXOLON SRP-270 (Copiar 1)")
        ticket.ImprimirTicket("BIXOLON SRP-270")
        'Nombre de la impresora ticketera

    End Sub

#Region "PRINT"
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

        Dim r As Record = dgPedidos.Table.CurrentRecord
        Dim entidadSA As New entidadSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(CInt(r.GetValue("idDocumento")))
        Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(Val(r.GetValue("idDocumento")))

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

            If comprobante.idCliente <> 0 Then
                Dim entidad = entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault
                Dim NBoletaElectronica As String = "Cliente: " & entidad.nombreCompleto
                'separacion del primer titulo con la segunda linea
                Dim fontNBoletaElectronica As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
                e.Graphics.DrawString(NBoletaElectronica, fontNBoletaElectronica,
                                       Brushes.Black, leftMargin - 100, yPos - 0)

            Else
                Dim NBoletaElectronica As String = "Cliente: " & comprobante.nombrePedido
                'separacion del primer titulo con la segunda linea
                Dim fontNBoletaElectronica As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
                e.Graphics.DrawString(NBoletaElectronica, fontNBoletaElectronica,
                                       Brushes.Black, leftMargin - 100, yPos - 0)
            End If


            Dim NNumeroBoleta As String = "Nro. doc: " & comprobante.serieVenta & "-" & comprobante.numeroVenta
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


            Dim NFecha As String = "Fecha: " & comprobante.fechaDoc
            'separacion del primer titulo con la segunda linea
            Dim fontNFecha As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            e.Graphics.DrawString(NFecha, fontNFecha,
                                   Brushes.Black, leftMargin - 100, yPos + 80)


            Dim NLinea2 As String = "------------------------------------------------------------"
            'separacion del primer titulo con la segunda linea
            Dim fontNLinea2 As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            e.Graphics.DrawString(NLinea2, fontNLinea2,
                                   Brushes.Black, leftMargin - 100, yPos + 100)

            '-----------------------------------------------------------------------------------------------------------------
            '------------------------------------------Segundo Encabezado datos del cliente -----------------------------------
            ' titulo 2 ubicacion de la hoja
            '10 masrgen a la izquierda
            ' ypos ubicacion hacia abajo del titulo primero

            Dim moneda As String = ""

            Select Case comprobante.moneda
                Case 2
                    moneda = "EXTRANJERA"
                Case 1
                    moneda = "NACIONAL"
            End Select

            'Dim cobroMn As Decimal
            ''Dim cobroME As Decimal
            'Dim vueltoMN As Decimal
            'Dim vueltoME As Decimal

            'For Each item In comprobanteDetalle.ToList
            '    cobroMn += item.GetValue("importePendiente")
            '    vueltoMN += item.GetValue("vueltoMN")
            '    vueltoME += item.GetValue("vueltoME")
            'Next

            '    If (TipoTicket = "ConRUC") Then
            ' &                            vbCrLf & "CAJA/TURNO: " & idCajaUsuario & _
            'vbCrLf & "TIPO MONEDA: " & moneda & _
            Select Case estadoImpresion
                Case 1
                    NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now &
                       vbCrLf & "CORRELATIVO: " & comprobante.serie & "-" & comprobante.numeroVenta &
                       vbCrLf & "------------------------------------------------------------"
                Case Else
                    NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now &
                    vbCrLf & "CORRELATIVO: " & comprobante.serie & "-" & comprobante.numeroVenta &
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

            Dim gravMN As Decimal = 0
            Dim gravME As Decimal = 0
            Dim ExoMN As Decimal = 0
            Dim ExoME As Decimal = 0
            Dim InaMN As Decimal = 0
            Dim InaME As Decimal = 0

            For Each i In comprobanteDetalle

                ' extract each item's text into the str variable
                Dim str As String
                str = (CDbl(i.monto1))

                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, X1 - 180, Y - 40)

                str = i.idItem
                Dim Rec As New RectangleF(X2 - 175, Y - 40, W2, 80)
                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, Rec)

                Dim lines, cols As Integer
                e.Graphics.MeasureString(str, fontNCabecera, New SizeF(W2, 50), New StringFormat, cols, lines)
                Dim subitm As Integer, Yc As Integer
                Yc = Y

                str = Math.Round(CDbl(i.importeMN) / CDbl(i.monto1), 2)
                Dim R2 As New RectangleF(X4 - 40, Y - 40, W4, 80)
                e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R2)

                'str = Math.Round(CDec(i.importeMN), 2)
                'Dim R3 As New RectangleF(X5 - 13, Y - 40, W5, 80)
                'e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R3)

                str = String.Format("{0:0.00}", i.importeMN)
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
                    str = i.idItem
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

                'Calculos sub totales
                Select Case r.GetValue("gravado")
                    Case OperacionGravada.Grabado
                        gravMN += CDec(i.montokardex)
                        gravMN += CDec(i.montokardexUS)

                    Case OperacionGravada.Exonerado
                        ExoMN += CDec(i.montokardex)
                        ExoME += CDec(i.montokardexUS)

                    Case OperacionGravada.Inafecto
                        InaMN += CDec(i.montokardex)
                        InaME += CDec(i.montokardexUS)
                End Select


            Next

            Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------------------------------"
            Dim fontNLinea1 As New System.Drawing.Font("Arial", 8, FontStyle.Regular)
            e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin - 100, Y - 73)


            Dim NTotalPagar As String = vbCrLf & vbCrLf & "Total S/. " & CDec(comprobante.ImporteNacional).ToString("N2")
            Dim fontNTotalPagar As New System.Drawing.Font("Ebrima", 9, FontStyle.Bold)
            e.Graphics.DrawString(NTotalPagar, fontNTotalPagar, Brushes.Black, leftMargin + 10, Y - 70)


            'Dim NExonerada As String = vbCrLf & vbCrLf & "Op. Exonerada                                         " & CDec(ExoMN).ToString("N2")
            'Dim fontNExonerada As New System.Drawing.Font("Arial", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NExonerada, fontNExonerada, Brushes.Black, leftMargin - 100, Y - 40)

            'Dim NIanfecta As String = vbCrLf & vbCrLf & "Op. Inafecta                                             " & CDec(InaMN).ToString("N2")
            'Dim fontNIanfecta As New System.Drawing.Font("Arial", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NIanfecta, fontNIanfecta, Brushes.Black, leftMargin - 100, Y - 25)

            'Dim NGravada As String = vbCrLf & vbCrLf & "Op. Gravada                                             " & CDec(gravMN).ToString("N2")
            'Dim fontNGravada As New System.Drawing.Font("Arial", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NGravada, fontNGravada, Brushes.Black, leftMargin - 100, Y - 10)

            'Dim NIGVE As String = vbCrLf & vbCrLf & "I.G.V. S/.                                                   " & CDec(comprobante.igv01).ToString("N2")
            'Dim fontNIGVE As New System.Drawing.Font("Arial", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NIGVE, fontNIGVE, Brushes.Black, leftMargin - 100, Y + 6)

            'Dim NREdondedo As String = vbCrLf & vbCrLf & "Redondeo S/.                                           " & CDec(0.0).ToString("N2")
            'Dim fontNREdondedo As New System.Drawing.Font("Arial", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NREdondedo, fontNREdondedo, Brushes.Black, leftMargin - 100, Y + 20)

            'Dim NDonacion As String = vbCrLf & vbCrLf & "Donación S/.                                            " & CDec(0.0).ToString("N2")
            'Dim fontNDonacion As New System.Drawing.Font("Arial", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NDonacion, fontNDonacion, Brushes.Black, leftMargin - 100, Y + 36)

            'Dim NDImporPagar As String = vbCrLf & vbCrLf & "Importa a Pagar S/.                                 " & CDec(comprobante.ImporteNacional).ToString("N2")
            'Dim fontNDImporPagar As New System.Drawing.Font("Arial", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NDImporPagar, fontNDImporPagar, Brushes.Black, leftMargin - 100, Y + 52)

            'Dim NImporteRecibido As String = vbCrLf & vbCrLf & "Importe Recibido S/.                                " & CDec(comprobante.ImporteNacional).ToString("N2")
            'Dim fontNImporteRecibido As New System.Drawing.Font("Arial", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NImporteRecibido, fontNImporteRecibido, Brushes.Black, leftMargin - 100, Y + 68)

            'Dim NVuelto As String = vbCrLf & vbCrLf & "Vuelto S/.                                                  " & CDec(0.0).ToString("N2")
            'Dim fontNVuelto As New System.Drawing.Font("Arial", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NVuelto, fontNVuelto, Brushes.Black, leftMargin - 100, Y + 84)


            'Select Case estadoImpresion
            '    Case 1
            '        Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & ""
            '        Dim fontNVendedor As New System.Drawing.Font("Arial", 7, FontStyle.Regular)
            '        e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 94, Y + 100)

            '        'Dim NComprador As String = vbCrLf & vbCrLf & "COMPRADOR: " & txtComprador.Text
            '        'Dim fontNComprador As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        'e.Graphics.DrawString(NComprador, fontNComprador, Brushes.Black, leftMargin - 94, Y + 116)

            '        Dim NGracias As String = vbCrLf & vbCrLf & "GRACIAS POR SU COMPRA"
            '        Dim fontNGracias As New System.Drawing.Font("Arial", 7, FontStyle.Regular)
            '        e.Graphics.DrawString(NGracias, fontNGracias, Brushes.Black, leftMargin - 94, Y + 116)

            '    Case Else
            '        Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & ""
            '        Dim fontNVendedor As New System.Drawing.Font("Arial", 7, FontStyle.Regular)
            '        e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 94, Y + 100)

            '        'Dim NComprador As String = vbCrLf & vbCrLf & "COMPRADOR: " & txtComprador.Text
            '        'Dim fontNComprador As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        'e.Graphics.DrawString(NComprador, fontNComprador, Brushes.Black, leftMargin - 94, Y + 116)

            '        Dim NGracias As String = vbCrLf & vbCrLf & "GRACIAS POR SU COMPRA"
            '        Dim fontNGracias As New System.Drawing.Font("Arial", 7, FontStyle.Regular)
            '        e.Graphics.DrawString(NGracias, fontNGracias, Brushes.Black, leftMargin - 94, Y + 116)
            'End Select

            Dim str2 As String
            Dim str4 As String
            Dim fontNExonerada As New System.Drawing.Font("Arial", 7, FontStyle.Regular)

            Dim BaseMN As Decimal = String.Format("{0:0.00}", ExoMN)
            Dim BaseMN2 As Decimal = String.Format("{0:0.00}", InaMN)
            Dim BaseMN3 As Decimal = String.Format("{0:0.00}", gravMN)
            Dim IgvMN As Decimal = String.Format("{0:0.00}", comprobante.igv01)
            Dim PercepcionMN As Decimal = String.Format("{0:0.00}", 0.0)
            Dim donacionMN As Decimal = String.Format("{0:0.00}", 0.0)
            Dim TotalMN As Decimal = String.Format("{0:0.00}", comprobante.ImporteNacional)
            Dim cobroMn2 As Decimal = String.Format("{0:0.00}", comprobante.ImporteNacional)
            Dim vueltoMN2 As Decimal = String.Format("{0:0.00}", 0.0)

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
                    str4 = CDec(BaseMN).ToString("N2")
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
                ElseIf ((BaseMN2.ToString.Length) = 5) Then
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

    Public Sub EliminarNota(intIdDocumentoNota As Integer)
        Dim compraSA As New documentoVentaAbarrotesSA
        Dim objDocumento As New documento
        Dim notaCredito As documentoventaAbarrotes
        Try
            notaCredito = compraSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumentoNota)
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .IdDocumentoAfectado = notaCredito.idPadre ' venta
                .idDocumento = intIdDocumentoNota
            End With
            compraSA.EliminarNotaCreditoMetodoVenta(objDocumento)
            Me.dgPedidos.Table.CurrentRecord.Delete()
            lblEstado.Text = "Nota eliminada correctamente!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Public Sub EliminarPVDirecta(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim objDocumento As New documento
        Try
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = intIdDocumento
            End With

            documentoSA.EliminarConsumoDirecto(objDocumento)
            'documentoSA.EliminarVentaTicketDirecta(objDocumento)

            Me.dgPedidos.Table.CurrentRecord.Delete()
            lblEstado.Text = "Pedido eliminado!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Public Sub EliminarVentaGeneral(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim objDocumento As New documento
        Try
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = intIdDocumento
            End With

            documentoSA.EliminarVentaGeneralPV(objDocumento)
            'Me.dgvVentas.Table.CurrentRecord.Delete()
            lblEstado.Text = "Venta Anulada!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Public Sub EliminarPV(intIdDocumento As Integer)
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim objDocumento As New documento
        Try
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = intIdDocumento
            End With

            documentoSA.EliminarVenta(objDocumento)
            'documentoSA.EliminarVentaGeneralPV(objDocumento)
            dgPedidos.Table.CurrentRecord.Delete()
            lblEstado.Text = "Pedido eliminado!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Public Sub EliminarNotaDebito(intIdDocumentoNota As Integer)
        Dim compraSA As New documentoVentaAbarrotesSA
        Dim objDocumento As New documento
        Dim notaCredito As documentoventaAbarrotes
        Try
            notaCredito = compraSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumentoNota)
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .IdDocumentoAfectado = notaCredito.idPadre ' venta
                .idDocumento = intIdDocumentoNota
                .ImporteMN = dgPedidos.Table.CurrentRecord.GetValue("importeTotal")
                .ImporteME = dgPedidos.Table.CurrentRecord.GetValue("importeUS")
            End With
            compraSA.EliminarNotaDebitoVenta(objDocumento)
            dgPedidos.Table.CurrentRecord.Delete()
            lblEstado.Text = "Nota eliminada correctamente!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub GetListaVentasPorPeriodo()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas de - " & cboMesPedido.SelectedValue & "/" & cboAnio.Text)
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
        dt.Columns.Add(New DataColumn("idPadre", GetType(Integer)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasPeriodo(GEstableciento.IdEstablecimiento, cboMesPedido.SelectedValue & "/" & cboAnio.Text)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serieVenta
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    dr(6) = i.numeroVenta

                Case TIPO_VENTA.COTIZACION
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL
                    dr(6) = i.numeroVenta
                Case "NTC"
                    dr(6) = i.numeroVenta
                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    dr(6) = i.numeroDoc
            End Select
            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(3) = i.nombrePedido
                    dr(7) = "-"
                    dr(8) = i.nombrePedido
                Case Else
                    dr(3) = i.NombreEntidad
                    dr(7) = i.NroDocEntidad
                    dr(8) = i.NombreEntidad
            End Select

            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"

                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    Select Case i.estadoCobro
                        Case Gimnasio_EstadoMembresiaPago.Completo
                            dr(14) = "Cobrado"
                        Case Gimnasio_EstadoMembresiaPago.IngresoLibre
                            dr(14) = "Libre"
                        Case Gimnasio_EstadoMembresiaPago.PagoParcial
                            dr(14) = "Parcial"
                        Case Gimnasio_EstadoMembresiaPago.Pendiente
                            dr(14) = "Pendiente"
                    End Select

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
            If i.tipoVenta = "NTC" Then
                dr(16) = i.idPadre
            End If

            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Private Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean, GGC As GridGroupingControl)
        Dim color As New GridMetroColors()
        Dim id As GridTableCellStyleInfoIdentity = GGC.TableControl.GetTableViewStyleInfo(row, col).TableCellIdentity
        If id.DisplayElement.IsRecord() Then
            Dim key As Integer = id.DisplayElement.GetRecord().Id
            'if (selectionColl.Contains(key))
            '    selectionColl[key] = isHover;
            'else
            hoveredIndex = row
            selectionColl.Clear()
            'if (selectionColl.Count == 0)
            '    selectionColl.Add(key, isHover);
            GGC.TableControl.Refresh()
        End If

        GGC.TableControl.Selections.Clear()

    End Sub

    Private Sub Meses()
        'Dim listaMeses As New List(Of MesesAnio)
        'Dim obj As New MesesAnio

        'For x = 1 To 12
        '    obj = New MesesAnio
        '    obj.Codigo = String.Format("{0:00}", CInt(x))
        '    obj.Mes = New DateTime(AnioGeneral).ToString("MMMM")
        '    listaMeses.Add(obj)
        'Next x

        cboMesPedido.DisplayMember = "Mes"
        cboMesPedido.ValueMember = "Codigo"
        cboMesPedido.DataSource = ListaDeMeses()
        cboMesPedido.SelectedValue = MesGeneral

        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = AnioGeneral
    End Sub

#End Region

#Region "Events"
    Private Sub ToggleButton21_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles ToggleButton21.ButtonStateChanged
        If ToggleButton21.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
            dgPedidos.TopLevelGroupOptions.ShowFilterBar = True
            dgPedidos.NestedTableGroupOptions.ShowFilterBar = True
            dgPedidos.ChildGroupOptions.ShowFilterBar = True
            For Each col As GridColumnDescriptor In dgPedidos.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True

            dgPedidos.OptimizeFilterPerformance = True
            dgPedidos.ShowNavigationBar = True
            filter.WireGrid(dgPedidos)
        Else
            filter.ClearFilters(dgPedidos)
            dgPedidos.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Try
            If Not IsNothing(dgPedidos.Table.CurrentRecord) Then
                'llenarDatos()
                'imprimir(True)
                ImprimirTicket()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub dgPedidos_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgPedidos.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgPedidos.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgPedidos_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgPedidos.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgPedidos)
    End Sub

    Private Sub CréditoEntregaTotalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CréditoEntregaTotalToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If cboMesPedido.Text.Trim.Length > 0 Then
            With frmVentaPVdirecta
                .lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                .CargarTipoDeVenta(TIPO_VENTA.VENTA_CREDITO_TOTAL)
                .StartPosition = FormStartPosition.CenterParent
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMesPedido.Select()
            cboMesPedido.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CréditoEntregaParcialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CréditoEntregaParcialToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If cboMesPedido.Text.Trim.Length > 0 Then
            With frmVentaPVdirecta
                .lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                '.btGrabar.Enabled = True
                .CargarTipoDeVenta(TIPO_VENTA.VENTA_CREDITO_PARCIAL)
                .StartPosition = FormStartPosition.CenterParent
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMesPedido.Select()
            cboMesPedido.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ContadoEntregaTotalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContadoEntregaTotalToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA

        If cboMesPedido.Text.Trim.Length > 0 Then
            cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
            If Not IsNothing(cajaUsuario) Then
                With frmVentaPVdirecta
                    .lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                    .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_TOTAL)
                    .StartPosition = FormStartPosition.CenterParent
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .ShowDialog()
                End With
            Else
                MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMesPedido.Select()
            cboMesPedido.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ContadoEntregaParcialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContadoEntregaParcialToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA

        If cboMesPedido.Text.Trim.Length > 0 Then
            cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
            If Not IsNothing(cajaUsuario) Then
                With frmVentaPVdirecta
                    .lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                    .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_PARCIAL)
                    .StartPosition = FormStartPosition.CenterParent
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .ShowDialog()
                End With
            Else
                MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMesPedido.Select()
            cboMesPedido.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub VentaAccesoTotalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaAccesoTotalToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        If cboMesPedido.Text.Trim.Length > 0 Then
            With frmVentaPVdirecta
                .lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                .CargarTipoDeVenta(TIPO_VENTA.VENTA_ANULADA)
                .StartPosition = FormStartPosition.CenterParent
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMesPedido.Select()
            cboMesPedido.DroppedDown = True
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub VentaCréditoEntregaTotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaCréditoEntregaTotaToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If cboMesPedido.Text.Trim.Length > 0 Then
            Dim f As New frmVenta
            f.lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.CargarTipoDeVenta(TIPO_VENTA.VENTA_CREDITO_TOTAL)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMesPedido.Select()
            cboMesPedido.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub VentaCréditoEntregaParcialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaCréditoEntregaParcialToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If cboMesPedido.Text.Trim.Length > 0 Then
            Dim f As New frmVenta
            f.lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.CargarTipoDeVenta(TIPO_VENTA.VENTA_CREDITO_PARCIAL)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMesPedido.Select()
            cboMesPedido.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub VentaContadoEntregaTotalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaContadoEntregaTotalToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA

        If cboMesPedido.Text.Trim.Length > 0 Then
            cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
            If Not IsNothing(cajaUsuario) Then
                With frmVenta
                    .lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_TOTAL)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMesPedido.Select()
            cboMesPedido.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub VentaContadoEntregaParcialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaContadoEntregaParcialToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA

        If cboMesPedido.Text.Trim.Length > 0 Then
            cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
            If Not IsNothing(cajaUsuario) Then
                With frmVenta
                    .lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_PARCIAL)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMesPedido.Select()
            cboMesPedido.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub VentaAccesoTotalToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VentaAccesoTotalToolStripMenuItem1.Click
        Cursor = Cursors.WaitCursor
        If cboMesPedido.Text.Trim.Length > 0 Then
            With frmVentaPVdirecta
                Dim f As New frmVenta
                'f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboanio.text
                f.lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.CargarTipoDeVenta(TIPO_VENTA.VENTA_ANULADA)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMesPedido.Select()
            cboMesPedido.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub VentaPOSContadoEntregaTotalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaPOSContadoEntregaTotalToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        ' Dim frm As New frmVentaPVdirecta
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If cboMesPedido.Text.Trim.Length > 0 Then
                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

                    With frmVentaPVdirecta
                        .lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                        '.btGrabar.Enabled = True
                        .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_TOTAL)
                        .StartPosition = FormStartPosition.CenterParent
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .ShowDialog()
                    End With
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesPedido.Select()
                cboMesPedido.DroppedDown = True
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub



    Private Sub VentaPOSContadoEntregaParcialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaPOSContadoEntregaParcialToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        '   Dim frm As New frmVentaPVdirecta
        Try

            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If cboMesPedido.Text.Trim.Length > 0 Then
                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)
                    With frmVentaPVdirecta
                        .lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                        '.btGrabar.Enabled = True
                        .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_PARCIAL)
                        .StartPosition = FormStartPosition.CenterParent
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .ShowDialog()
                    End With
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesPedido.Select()
                cboMesPedido.DroppedDown = True
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub VentaPOSCréditoEntregaTotalToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VentaPOSCréditoEntregaTotalToolStripMenuItem1.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If cboMesPedido.Text.Trim.Length > 0 Then
                With frmVentaPVdirecta
                    .chIdentificacion.Enabled = False
                    .lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                    .CargarTipoDeVenta(TIPO_VENTA.VENTA_CREDITO_TOTAL)
                    .StartPosition = FormStartPosition.CenterParent
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesPedido.Select()
                cboMesPedido.DroppedDown = True
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub VentaPOSCréditoEntregaParcialToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VentaPOSCréditoEntregaParcialToolStripMenuItem1.Click
        Cursor = Cursors.WaitCursor
        Try

            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If cboMesPedido.Text.Trim.Length > 0 Then
                With frmVentaPVdirecta
                    .chIdentificacion.Enabled = False
                    .lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                    .CargarTipoDeVenta(TIPO_VENTA.VENTA_CREDITO_PARCIAL)
                    .StartPosition = FormStartPosition.CenterParent
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesPedido.Select()
                cboMesPedido.DroppedDown = True
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub VentaContadoEntregaTotalToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VentaContadoEntregaTotalToolStripMenuItem1.Click
        Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        '     Dim frm As New frmVenta
        Try

            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If cboMesPedido.Text.Trim.Length > 0 Then
                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    With frmVenta
                        .lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_TOTAL)
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesPedido.Select()
                cboMesPedido.DroppedDown = True
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub VentaContadoEntregaTotalToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles VentaContadoEntregaTotalToolStripMenuItem2.Click
        Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        '    Dim frm As New frmVenta
        Try

            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If cboMesPedido.Text.Trim.Length > 0 Then
                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    With frmVenta
                        .lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_PARCIAL)
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesPedido.Select()
                cboMesPedido.DroppedDown = True
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub VentaCréditoEntregaTotalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaCréditoEntregaTotalToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If cboMesPedido.Text.Trim.Length > 0 Then
                Dim f As New frmVenta
                f.chIdentificacion.Enabled = False
                f.lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.CargarTipoDeVenta(TIPO_VENTA.VENTA_CREDITO_TOTAL)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesPedido.Select()
                cboMesPedido.DroppedDown = True
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub VentaCréditoEntrregaParcialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaCréditoEntrregaParcialToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If cboMesPedido.Text.Trim.Length > 0 Then
                Dim f As New frmVenta
                f.chIdentificacion.Enabled = False
                f.lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.CargarTipoDeVenta(TIPO_VENTA.VENTA_CREDITO_PARCIAL)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesPedido.Select()
                cboMesPedido.DroppedDown = True
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub VENTAFORMATOGENERALMULTIUSOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VENTAFORMATOGENERALMULTIUSOToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If cboMesPedido.Text.Trim.Length > 0 Then
                Dim f As New frmVenta
                f.lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.CargarTipoDeVenta(TIPO_VENTA.VENTA_ANULADA)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesPedido.Select()
                cboMesPedido.DroppedDown = True
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub FghfToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FghfToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If cboMesPedido.Text.Trim.Length > 0 Then
                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    With frmAnticipoXVenta
                        .lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesPedido.Select()
                cboMesPedido.DroppedDown = True
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        Cursor = Cursors.WaitCursor
        Dim ef As New EstadosFinancierosSA
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim usuarioSA As New UsuarioSA
        Dim usuarioxls As New Usuario
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
            If Not IsNothing(cajaUsuario) Then
                usuarioxls = usuarioSA.UbicarUsuarioXid(New Usuario With {.IDUsuario = usuario.IDUsuario})
                Dim F As New frmCobroPedidos
                F.txtNomUser.Text = usuarioxls.Full_Name
                If IsNothing(cajaUsuario.idPadre) Then
                    F.txtTipoUser.Text = "Usuario Responsable"
                    F.txtTipoUser.Tag = cajaUsuario.idcajaUsuario
                Else
                    F.txtTipoUser.Text = "Usuario Dependiente"
                    F.txtTipoUser.Tag = cajaUsuario.idcajaUsuario
                End If
                F.StartPosition = FormStartPosition.CenterParent
                F.ShowDialog()
            Else
                MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf GetListaVentasPorPeriodo))
        thread.Start()
    End Sub

    Private Sub VENTAFORMATOGENERALCONTADOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VENTAFORMATOGENERALCONTADOToolStripMenuItem.Click

    End Sub

    Private Sub PUNTODEVENTAMULTIUSOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PUNTODEVENTAMULTIUSOToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If dgPedidos.Table.Records.Count > 0 Then
            If Not IsNothing(dgPedidos.Table.CurrentRecord) Then
                If MessageBox.Show("Desea eliminar la nota de credito seleccionada!", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


                    If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then

                        If Me.dgPedidos.Table.CurrentRecord.GetValue("tipoCompra") = "NTC" Then


                            Dim tiene As Integer = ValidarStock(Me.dgPedidos.Table.CurrentRecord.GetValue("idPadre"))

                            If tiene = 0 Then

                                EliminarNota(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                            Else
                                MessageBox.Show("No se puede eliminar por que no hay stock!", "Atención")
                            End If
                        Else

                            MessageBox.Show("Seleccione una nota de credito!", "Atención")
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub frmVentasMaestro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripDropDownButton2_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton2.Click
        Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        ' Dim frm As New frmVentaPVdirecta
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realizar está operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If cboMesPedido.Text.Trim.Length > 0 Then
                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

                    With frmVentaPVdirecta
                        .lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                        '.btGrabar.Enabled = True
                        .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_TOTAL)
                        .StartPosition = FormStartPosition.CenterScreen
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .Show()
                    End With
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesPedido.Select()
                cboMesPedido.DroppedDown = True
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realizar está operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If cboMesPedido.Text.Trim.Length > 0 Then
                Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

                    Dim f As New frmVentaNuevoFormato
                    f.lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                    f.StartPosition = FormStartPosition.CenterScreen
                    ' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.ShowDialog()
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesPedido.Select()
                cboMesPedido.DroppedDown = True
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        PanelError.Visible = True
        Timer1.Enabled = True
        TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realizar está operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If cboMesPedido.Text.Trim.Length > 0 Then
                Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

                    Dim f As New frmVentaNuevoPOS
                    f.lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                    f.StartPosition = FormStartPosition.CenterScreen
                    ' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.ShowDialog()
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesPedido.Select()
                cboMesPedido.DroppedDown = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ButtonAdv18_Click(sender As Object, e As EventArgs) Handles ButtonAdv18.Click
        Dim r As Record = dgPedidos.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmCambiarPeriodo2(New documentoventaAbarrotes With {.idDocumento = Val(r.GetValue("idDocumento"))})
            f.operacion = StatusTipoOperacion.VENTA
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            ButtonAdv19_Click(sender, e)
        End If
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(dgPedidos.Table.CurrentRecord) Then
            Select Case dgPedidos.Table.CurrentRecord.GetValue("tipoCompra")
                Case TIPO_VENTA.VENTA_GENERAL
                    Dim f As New frmVenta(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.ShowDialog()
                Case TIPO_VENTA.VENTA_NOTA_PEDIDO
                    Dim f As New frmVentaPV(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.ShowDialog()
                Case TIPO_VENTA.VENTA_POS_DIRECTA
                    'Dim f As New frmVentaPVdirecta(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                    'f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    'f.ShowDialog()
                    Dim f As New frmVentaNuevoFormato(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                    f.btGrabar.Enabled = False
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                Case TIPO_VENTA.VENTA_AL_TICKET
                    Dim f As New frmVentaPV(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.WindowState = FormWindowState.Maximized
                    f.ShowDialog()
            End Select
        Else
            MessageBox.Show("Debe seleccionar un pedido/venta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then
            If MessageBox.Show("Desea Elimiar el item seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Select Case Me.dgPedidos.Table.CurrentRecord.GetValue("tipoCompra")
                    Case TIPO_COMPRA.NOTA_CREDITO
                        Dim tiene As Integer = ValidarStock(Me.dgPedidos.Table.CurrentRecord.GetValue("idPadre"))
                        If tiene = 0 Then
                            EliminarNota(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                        Else
                            MessageBox.Show("No se puede eliminar por que no hay stock!", "Atención")
                        End If
                        'EliminarNota(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                    Case TIPO_COMPRA.NOTA_DEBITO
                    '    EliminarNotaDebito(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                    Case TIPO_VENTA.VENTA_NOTA_PEDIDO
                        EliminarPV(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                    Case TIPO_VENTA.VENTA_GENERAL
                        'se elimina atraves de las notas de credito
                        EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                    Case TIPO_VENTA.VENTA_POS_DIRECTA, TIPO_VENTA.VENTA_AL_TICKET
                        EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                        '   EliminarPVDirecta(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                End Select
            End If
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.Click

    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        Dim f As New frmNotaDebitoVenta
        f.lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub
    Private Sub NotaDeCreditoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotaDeCreditoToolStripMenuItem.Click
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            Dim r As Record = dgPedidos.Table.CurrentRecord
            If Not IsNothing(r) Then
                Select Case r.GetValue("tipoCompra")

                    Case TIPO_VENTA.VENTA_POS_DIRECTA, TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_GENERAL, TIPO_VENTA.VENTA_ANTICIPADA, TIPO_VENTA.VENTA_ANTICIPADA_RECIBIDO, TIPO_VENTA.VENTA_ANTICIPADA_OTORGADO,
                        TIPO_VENTA.VENTA_CONTADO_TOTAL, TIPO_VENTA.VENTA_CONTADO_PARCIAL, TIPO_VENTA.VENTA_CREDITO_TOTAL, TIPO_VENTA.VENTA_CREDITO_PARCIAL

                        'If r.GetValue("estado") = "Anulado x NC." Then
                        '    MessageBox.Show("Este Documento ya fue anulado", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '    Exit Sub
                        'Else
                        Dim f As New frmNotaVentaNew(CInt(r.GetValue("idDocumento")))
                        f.lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                        f.txtFecha.Value = New Date(CInt(cboAnio.Text), CInt(cboMesPedido.SelectedValue), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        ButtonAdv19_Click(sender, e)
                        'End If

                    Case Else
                        MessageBox.Show("Debe seleccionar una venta", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub NotaDeCreditoEspecialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotaDeCreditoEspecialToolStripMenuItem.Click
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            Dim r As Record = dgPedidos.Table.CurrentRecord
            If Not IsNothing(r) Then
                Select Case r.GetValue("tipoCompra")

                    Case TIPO_VENTA.VENTA_POS_DIRECTA, TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_GENERAL, TIPO_VENTA.VENTA_ANTICIPADA, TIPO_VENTA.VENTA_ANTICIPADA_RECIBIDO, TIPO_VENTA.VENTA_ANTICIPADA_OTORGADO,
                         TIPO_VENTA.VENTA_CONTADO_TOTAL, TIPO_VENTA.VENTA_CONTADO_PARCIAL, TIPO_VENTA.VENTA_CREDITO_TOTAL, TIPO_VENTA.VENTA_CREDITO_PARCIAL

                        If r.GetValue("estado") = "Anulado x NC." Then
                            MessageBox.Show("Este Documento ya fue anulado", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        Else
                            Dim f As New frmNotaVentaEspecial(CInt(r.GetValue("idDocumento")))
                            f.StartPosition = FormStartPosition.CenterParent
                            f.lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                            f.txtFecha.Value = New Date(CInt(cboAnio.Text), CInt(cboMesPedido.SelectedValue), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                            f.ShowDialog()
                            ButtonAdv19_Click(sender, e)
                        End If

                    Case Else
                        MessageBox.Show("Debe seleccionar una venta", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

#End Region

End Class