Imports Syncfusion.GridHelperClasses
Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms
Imports System.Drawing.Printing
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class TabCM_Proformas
#Region "Attributes"
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim filter As New GridExcelFilter()
#End Region

    Dim ImporteSobranteMN As Decimal
    Dim ImporteTotalMN As Decimal
    Dim ImporteTotalME As Decimal
    Dim estadoImpresion As Integer


    Public Título As String = ""
    Private prtSettings As PrinterSettings
    Private prtDoc As PrintDocument
    Private ppc As New PrintPreviewControl
    Private prtFont As System.Drawing.Font
    Dim conteo As Integer = 0
    Dim datosEst As Integer = 0
    Private lineaActual As Integer
    Public fontNCabecera As New System.Drawing.Font("Arial", 8, FontStyle.Regular)
    Dim X1, X2, X3, X4, X5 As Integer
    Dim W1, W2, W3, W4, W5 As Integer
    Dim Y As Integer
    Public NFecha As String
    Public NNombre As String
    Public NDireccion As String
    Public NProforma As String
    Dim lblIdDocreferenciaAnticipo As Integer
    Dim lblNumeroDoc As Integer

    Public listaproforma As New List(Of documentoventaAbarrotesDet)

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GradientPanel17.Visible = True
        GetCombos()
        FormatoGridAvanzado(dgPedidos, True, False)
    End Sub
#End Region

#Region "Methods"
    Sub ImprimirTicket(intIdDocumento As Integer)
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
        ticket.TextoIzquierda("PROFORMA DE VENTA # " & comprobante.numeroDoc)


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
        '    ticket.TextoIzquierda("COD. MAQUINA REG.: USAFIKA12050121")
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

        ticket.ImprimirTicket("POS-80C")
        ' ticket.ImprimirTicket("BIXOLON SRP-270")
        'Nombre de la impresora ticketera

    End Sub

    Sub llenarDatos()

        PrintPreviewDialogTicket.Document = PrintTikect

        'PrintPreviewDialog1.ShowDialog()

        ' La fuente a usar en la impresión
        prtFont = New System.Drawing.Font("Courier New", 11)
        '
        ' La configuración actual de la impresora predeterminada
        prtSettings = New PrinterSettings

    End Sub

    Public Sub prt_PrintPageSinRuc(ByVal sender As Object, ByVal e As PrintPageEventArgs)

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

            NFecha = vbCrLf & vbCrLf & DateTime.Now
            Dim fontNFecha As New System.Drawing.Font("arial", 8, FontStyle.Regular)
            e.Graphics.DrawString(NFecha, fontNFecha, Brushes.Black, leftMargin - 35, yPos + 80)

            NProforma = vbCrLf & vbCrLf & "X"
            Dim fontNProforma As New System.Drawing.Font("arial", 8, FontStyle.Regular)
            e.Graphics.DrawString(NProforma, fontNProforma, Brushes.Black, leftMargin + 250, yPos + 40)

            NNombre = vbCrLf & vbCrLf & dgPedidos.Table.CurrentRecord.GetValue("NombreEntidad")
            Dim fontNNombre As New System.Drawing.Font("arial", 8, FontStyle.Regular)
            e.Graphics.DrawString(NNombre, fontNNombre, Brushes.Black, leftMargin - 37, yPos + 110)

            NDireccion = vbCrLf & vbCrLf & "-"
            Dim fontNDireccion As New System.Drawing.Font("arial", 8, FontStyle.Regular)
            e.Graphics.DrawString(NDireccion, fontNDireccion, Brushes.Black, leftMargin - 37, yPos + 130)


            'Dim NLinea As String = "----------------------------------------------------------" & vbLf
            ''separacion del primer titulo con la segunda linea
            'Dim fontNLinea As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
            'e.Graphics.DrawString(NLinea, fontNLinea, _
            '                       Brushes.Black, leftMargin - 100, yPos + 10)

            'margen a la derecha de toda la lista
            X1 = PrintTikect.DefaultPageSettings.Margins.Left + 130 '85
            With PrintTikect.DefaultPageSettings
                pageWidth = (.PaperSize.Width) - (.Margins.Left + 10) - (.Margins.Right) '10
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
            Y = PrintTikect.DefaultPageSettings.Margins.Top + 185
            Dim fontNColumna As New System.Drawing.Font("arial", 8, FontStyle.Bold)
            ' Draw the column headers at the top of the page
            'ubicacion de las columnas para la izquierda
            'e.Graphics.DrawString("Cant", fontNColumna, Brushes.Black, X1 - 187, Y + 5)
            'e.Graphics.DrawString("Producto", fontNColumna, Brushes.Black, X2 - 175, Y + 5)
            'e.Graphics.DrawString("P.U.", fontNColumna, Brushes.Black, X3 - 175, Y + 5)
            'e.Graphics.DrawString("Total", fontNColumna, Brushes.Black, X4 + 2, Y + 5)
            ' Advance the Y coordinate for the first text line on the printout
            Y = Y + 20
            'End If
            Dim ii As Integer = 0
            Dim ultimaFila As Integer = 0

            For Each i In listaproforma 'dgvCompra.Table.Records

                'If (MaxImpresion >= 1) Then
                ' extract each item's text into the str variable
                Dim str As String
                str = (CDbl(i.monto1))

                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, X1 - 180, Y)


                Dim nroCaracteres = i.nombreItem.Trim.Length

                If nroCaracteres >= 27 Then
                    str = i.nombreItem.Substring(0, 27).ToString()
                Else
                    str = i.nombreItem
                End If

                'str = i.nombreItem.Substring(0, 40)
                Dim R As New RectangleF(X2 - 175, Y, W2, 80)
                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, R)

                Dim lines, cols As Integer
                e.Graphics.MeasureString(str, fontNCabecera, New SizeF(W2, 50), New StringFormat, cols, lines)
                Dim subitm As Integer, Yc As Integer
                Yc = Y

                str = Math.Round(CDec(i.importeMN) / CDbl(i.monto1), 2)
                Dim R2 As New RectangleF(X4 + 40, Y, W4, 80)
                e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R2)

                str = Math.Round(CDec(i.importeMN), 2)
                Dim R3 As New RectangleF(X5 + 80, Y, W5, 80)
                e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R3)

                'Dim conteo As Integer

                'For subitm = 1 To 1
                '    str = i.nombreItem
                '    'str = i.SubItems(subitm).Text
                '    'conteo = 0
                '    conteo = (str.Length / 2)
                '    Dim strformat As New StringFormat
                '    strformat.Trimming = StringTrimming.EllipsisCharacter
                '    Yc = Yc + fontNCabecera.Height + 2
                'Next
                Y = Y + lines * fontNCabecera.Height + 10 '+ (conteo + 2)
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
                'End If

                'MaxImpresion = MaxImpresion - 1
            Next

            Dim NTotalPagar As String = vbCrLf & vbCrLf & listaproforma.Sum(Function(o) o.importeMN).GetValueOrDefault
            Dim fontNTotalPagar As New System.Drawing.Font("Ebrima", 9, FontStyle.Bold)
            e.Graphics.DrawString(NTotalPagar, fontNTotalPagar, Brushes.Black, leftMargin + 220, Y + 210)

            'oRIGINAL FORMATO

            'NFecha = vbCrLf & vbCrLf & DateTime.Now
            'Dim fontNFecha As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            'e.Graphics.DrawString(NFecha, fontNFecha, Brushes.Black, leftMargin + 5, yPos - 0)

            'NProforma = vbCrLf & vbCrLf & "X"
            'Dim fontNProforma As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            'e.Graphics.DrawString(NProforma, fontNProforma, Brushes.Black, leftMargin + 270, yPos - 30)

            'NNombre = vbCrLf & vbCrLf & "MAYKOL SANCGHEZ CORIS"
            'Dim fontNNombre As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            'e.Graphics.DrawString(NNombre, fontNNombre, Brushes.Black, leftMargin - 10, yPos + 35)

            'NDireccion = vbCrLf & vbCrLf & "CALLE REAL"
            'Dim fontNDireccion As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            'e.Graphics.DrawString(NDireccion, fontNDireccion, Brushes.Black, leftMargin - 10, yPos + 55)


            ''Dim NLinea As String = "----------------------------------------------------------" & vbLf
            '''separacion del primer titulo con la segunda linea
            ''Dim fontNLinea As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
            ''e.Graphics.DrawString(NLinea, fontNLinea, _
            ''                       Brushes.Black, leftMargin - 100, yPos + 10)

            ''margen a la derecha de toda la lista
            'X1 = PrintTikect.DefaultPageSettings.Margins.Left + 150 '85
            'With PrintTikect.DefaultPageSettings
            '    pageWidth = (.PaperSize.Width) - (.Margins.Left + 10) - (.Margins.Right) '10
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
            'Y = PrintTikect.DefaultPageSettings.Margins.Top + 100
            'Dim fontNColumna As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
            '' Draw the column headers at the top of the page
            ''ubicacion de las columnas para la izquierda
            'e.Graphics.DrawString("Cant", fontNColumna, Brushes.Black, X1 - 187, Y + 5)
            'e.Graphics.DrawString("Producto", fontNColumna, Brushes.Black, X2 - 175, Y + 5)
            'e.Graphics.DrawString("P.U.", fontNColumna, Brushes.Black, X3 - 175, Y + 5)
            'e.Graphics.DrawString("Total", fontNColumna, Brushes.Black, X4 + 2, Y + 5)
            '' Advance the Y coordinate for the first text line on the printout
            'Y = Y + 20
            ''End If
            'Dim ii As Integer = 0
            'Dim ultimaFila As Integer = 0

            'For Each i As Record In dgvCompra.Table.Records

            '    ' extract each item's text into the str variable
            '    Dim str As String
            '    str = (CDbl(i.GetValue("1")))

            '    e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, X1 - 180, Y)

            '    str = i.GetValue("2")
            '    Dim R As New RectangleF(X2 - 175, Y, W2, 80)
            '    e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, R)

            '    Dim lines, cols As Integer
            '    e.Graphics.MeasureString(str, fontNCabecera, New SizeF(W2, 50), New StringFormat, cols, lines)
            '    Dim subitm As Integer, Yc As Integer
            '    Yc = Y

            '    str = Math.Round(CDec(i.GetValue("3")) / CDbl(i.GetValue("1")), 2)
            '    Dim R2 As New RectangleF(X4 + 40, Y, W4, 80)
            '    e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R2)

            '    str = Math.Round(CDec(i.GetValue("3")), 2)
            '    Dim R3 As New RectangleF(X5 + 80, Y, W5, 80)
            '    e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R3)

            '    Dim conteo As Integer

            '    For subitm = 1 To 1
            '        str = i.GetValue("2")
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
            '        If (Not e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Height - .Margins.Bottom))) Or
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

            e.HasMorePages = False


        End If



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

        'For Each item In dgvCompra.Table.Records
        '    listaproforma.Add(item)
        'Next


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
        'If esPreview Then
        '    Dim prtPrev As New PrintPreviewDialog
        '    prtPrev.PrintPreviewControl.Zoom = 1.0
        '    prtPrev.Document = prtDoc
        '    prtPrev.Text = "Previsualizar datos de Ticket" & Título
        '    DirectCast(prtPrev, Form).WindowState = FormWindowState.Maximized
        '    prtPrev.ShowDialog()
        'Else
        prtDoc.Print()
        'End If
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

    Sub imprimirTicketMatricial(intIdDocumento As Integer)
        Dim contador As Integer = 1

        Dim list As New List(Of List(Of Record))
        Dim entidadSA As New entidadSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
        Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)

        Dim contacto As Integer = comprobanteDetalle.Count
        Dim contadorMax As Integer = comprobanteDetalle.Count

        If (comprobanteDetalle.Count = 1) Then
            listaproforma.AddRange(comprobanteDetalle)
            llenarDatos()
            imprimir(True)
            'prtDoc.PrinterSettings = prtSettings
            'prtDoc.Print()
            listaproforma = New List(Of documentoventaAbarrotesDet)
            contador = 0
        Else
            For Each item In comprobanteDetalle
                listaproforma.Add(item)
                If (contadorMax < contacto And contador = 14) Then
                    llenarDatos()
                    imprimir(True)
                    'prtDoc.PrinterSettings = prtSettings
                    'prtDoc.Print()
                    listaproforma = New List(Of documentoventaAbarrotesDet)
                    contador = 0
                ElseIf (contadorMax = 1 And contadorMax <> comprobanteDetalle.Count) Then
                    llenarDatos()
                    imprimir(True)
                    contacto = 0
                    contador = 0
                    listaproforma = New List(Of documentoventaAbarrotesDet)
                End If
                contadorMax = contadorMax - 1
                contador = contador + 1
            Next
        End If


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

    Public Sub EliminarPV(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim objDocumento As New documento
        Try
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = intIdDocumento
            End With

            documentoSA.EliminarPedidos(objDocumento)
            Me.dgPedidos.Table.CurrentRecord.Delete()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub GetListaCotizaciones()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Pedidos-")
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

        'lower case p
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        Dim str As String

        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarCotizaciones(GEstableciento.IdEstablecimiento, cboMesPedido.SelectedValue & "/" & AnioGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serie
            dr(6) = i.numeroDoc
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
            dr(9) = i.ImporteNacional
            dr(10) = i.tipoCambio
            dr(11) = i.ImporteExtranjero
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion
            dr(14) = i.estadoCobro
            dt.Rows.Add(dr)
        Next
        dgPedidos.DataSource = dt

    End Sub

    Private Sub GetCombos()
        Dim empresaAnioSA As New empresaPeriodoSA
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.ValueMember = "periodo"
        cboAnio.DisplayMember = "periodo"
        cboAnio.Text = DateTime.Now.Year.ToString

        cboMesPedido.DisplayMember = "Mes"
        cboMesPedido.ValueMember = "Codigo"
        cboMesPedido.DataSource = ListaDeMeses()
        cboMesPedido.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
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

#Region "Events"
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

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.REIMPRIMIR_PROFORMA_Botón___, AutorizacionRolList) Then
            Dim r As Record = dgPedidos.Table.CurrentRecord
            If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then
                'Dim f As New FormImpresionNuevo  ' frmVentaNuevoFormato
                'f.DocumentoID = Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")
                'f.StartPosition = FormStartPosition.CenterScreen
                '' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                'f.Show(Me)
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ELIMINAR_PROFORMA_Botón___, AutorizacionRolList) Then
            If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then
                If MessageBox.Show("Desea Elimiar el item seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarPV(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                End If
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.EDITAR_PROFORMA_Botón___, AutorizacionRolList) Then
            If Me.dgPedidos.Table.CurrentRecord IsNot Nothing Then
                'Dim f As New FormViewVentaGeneral(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                '' f.inicioComprobante = "PROFORMA"
                'f.StartPosition = FormStartPosition.CenterParent
                ''   f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                'f.ShowDialog()

                Dim f As New FormVentaModify(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)

                GetListaCotizaciones()
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If ToolStripButton3.Tag = "Inactivo" Then
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
            ToolStripButton3.Tag = "activo"
        Else
            ToolStripButton3.Tag = "Inactivo"
            filter.ClearFilters(dgPedidos)
            dgPedidos.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

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

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVA_PROFORMA_Botón___, AutorizacionRolList) Then
            If cboMesPedido.Text.Trim.Length > 0 AndAlso cboAnio.Text.Trim.Length > 0 Then
                Dim f As New frmFormularioCotizacion
                f.lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                GetListaCotizaciones()
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesPedido.Select()
                cboMesPedido.DroppedDown = True
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.EDITAR_PROFORMA_Botón___, AutorizacionRolList) Then
            Dim f As New frmFormularioCotizacion(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))

            f.StartPosition = FormStartPosition.CenterParent
            f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
            f.ShowDialog()
            GetListaCotizaciones()
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ELIMINAR_PROFORMA_Botón___, AutorizacionRolList) Then
            If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then
                If MessageBox.Show("Desea Elimiar el item seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarPV(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                End If
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.REIMPRIMIR_PROFORMA_Botón___, AutorizacionRolList) Then
            Dim r As Record = dgPedidos.Table.CurrentRecord
            If Not IsNothing(r) Then
                imprimirTicketMatricial(Val(r.GetValue("idDocumento")))
                '  ImprimirTicket(Val(r.GetValue("idDocumento")))
                'Dim f As New frmProformaRDLC(Val(r.GetValue("idDocumento")))
                'f.StartPosition = FormStartPosition.CenterParent
                'f.ShowDialog()
            Else
                MessageBox.Show("Debe seleccionar una cotización para imprimir", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Cursor = Cursors.WaitCursor
        GetListaCotizaciones()
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Cursor = Cursors.WaitCursor
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim ventaDetSA As New documentoVentaAbarrotesDetSA
        If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then
            'If MessageBox.Show("Desea realizar una venta?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            ClipBoardDocumento = New documento
            ClipBoardDocumento.documentoventaAbarrotes = ventaSA.GetUbicar_documentoventaAbarrotesPorID(Val(dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
            'Dim listaDetalle = CompraDetSA.UbicarDetalleCompraEval(Val(r.GetValue("idDocumento")))
            Dim listaDetalle = ventaDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(Val(dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
            ClipBoardDocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = listaDetalle
            MessageBox.Show("Comprobante copiado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        Cursor = Cursors.WaitCursor
        GetListaCotizaciones()
        Cursor = Cursors.Default
    End Sub
#End Region

End Class
