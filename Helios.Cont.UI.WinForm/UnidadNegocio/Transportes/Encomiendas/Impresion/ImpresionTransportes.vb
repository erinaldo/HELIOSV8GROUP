Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Net.Mail
Imports ZXing

Public Class ImpresionTransportes
    Public LineasDeLaCabeza As ArrayList = New ArrayList()
    Public LineasDeLaSubCabeza As ArrayList = New ArrayList()
    Public LineasDeCaracteres As ArrayList = New ArrayList()
    Public Elementos As ArrayList = New ArrayList()
    Public Nombre_Elementos As ArrayList = New ArrayList()
    Public Totales As ArrayList = New ArrayList()
    Public LineasDelPie As ArrayList = New ArrayList()
    Private headerImagep As Image
    Private headerImageQR As Image
    Public contador As Decimal = 0
    'CARACTERURES MAXIMOS DE LA HOJA
    Public CaracteresMaximos As Integer = 80
    Public CaracteresMaximosGuion As Integer = 80
    Public CaracteresMaximosDescripcion As Integer = 80
    Public tipoComprobante As String = String.Empty
    Public imageHeight As Integer = 0
    Public imageQR As Integer = 0
    'MARGEN HACIA LA DERECHA
    Public MargenIzquierdo As Double = 5
    'MARGEN PARTE SUPERIOR
    Public MargenSuperior As Double = 10
    'TIPO DE LETRA
    Public NombreDeLaFuente As String = "Tahoma"
    Public TamanoDeLaFuente As Integer = 7

    Public FuenteImpresa As Font
    Public ColorDeLaFuente As SolidBrush = New SolidBrush(Color.Black)

    Public gfx As Graphics

    Public CadenaPorEscribirEnLinea As String = ""
    Private WithEvents DocumentoAImprimir As New PrintDocument
    Public lineaEspacio As Decimal = 62.0
    Dim listaPaginas As New List(Of ArrayList)
    Dim ListaArray As New ArrayList
    Public lineaEspacioPagina As Integer = 5

    Dim count As Integer = 1

    Dim comienzo As Integer = 0
    Dim contadorPAginas As Integer = 0
    Dim PAGINAS As Integer 'PARA NUMERAR LAS PAGINAS

    Private Sub DocumentoAImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocumentoAImprimir.PrintPage
        For Each X In listaPaginas
            If (X.Count > 0) Then
                PAGINAS += 1
                e.Graphics.PageUnit = GraphicsUnit.Millimeter
                gfx = e.Graphics

                contador = 0
                'CARACTERURES MAXIMOS DE LA HOJA
                CaracteresMaximos = 80
                CaracteresMaximosGuion = 80
                CaracteresMaximosDescripcion = 80
                imageHeight = 0

                DibujaDatosEmpresa()
                DibujaLaCabecera()

                DibujaDatosComplementarios()

                For Each i In listaPaginas
                    Select Case listaArrays
                        Case 1
                            DibujaElementosFactura(i)
                            'DibujaTotalFacturaFinal()

                            e.HasMorePages = False
                            Exit Sub
                        Case Else
                            DibujaElementosFactura(i)
                            'DibujaTotalFactura()

                            listaArrays -= 1
                            e.HasMorePages = True
                            listaPaginas.RemoveAt(comienzo)
                            'comienzo += 1
                            Exit Sub 'es necesario el Exit Sub, si no cae en un bucle 
                    End Select
                Next
            End If
            e.HasMorePages = False
            Exit Sub
        Next
    End Sub

    Public Property TamanoLetra() As Integer
        Get
            Return TamanoDeLaFuente
        End Get
        Set(ByVal value As Integer)
            If (value <> TamanoDeLaFuente) Then TamanoDeLaFuente = value
        End Set
    End Property

    Public Property NombreLetra() As String
        Get
            Return NombreDeLaFuente
        End Get
        Set(ByVal value As String)
            If (value <> NombreDeLaFuente) Then NombreDeLaFuente = value
        End Set
    End Property

    Public Sub ImprimeTicket(ByVal impresora As String)

        FuenteImpresa = New Font(NombreLetra, TamanoLetra, FontStyle.Regular)
        'Dim pr As New PrintDocument 
        DocumentoAImprimir.PrinterSettings.PrinterName = impresora
        DocumentoAImprimir.DefaultPageSettings .Landscape = true
        'pr.PrinterSettings.printpa() 
        ' pr.PrintPage += New 
        ' PrintPageEventHandler(pr_PrintPage) 
        lineasTotal()

        DocumentoAImprimir.Print()



    End Sub

    '*****************************************************************************
    '****************************** NOMBRE importes TOTALES ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasDatosEmpresa As ArrayList = New ArrayList()

    'Linea para capturar el ruc y numeroComprobante de la Factura
    Public Sub AnadirLineaEmpresa(ByVal nombreEmpresa As String)
        Dim ordTot As OrdernarEmpresa = New OrdernarEmpresa()
        LineasDatosEmpresa.Add(ordTot.GenerarTotal(nombreEmpresa))
    End Sub

    'Dibuja `parte de la derecha de la factura
    Private Sub DibujaDatosEmpresa()
        lineaEspacioPagina = 5
        'se crea un rectangulo para manipular texto dentro del rectangulo
        Dim R2 As New RectangleF(5, lineaEspacioPagina, 200, 12)
        'Fuente de la impresion

        Dim FuenteImpresaEncabezado As Font

        FuenteImpresaEncabezado = New Font("Tahoma", 14, FontStyle.Italic)

        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarEmpresa = New OrdernarEmpresa()
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        'stringformat para alinear el text
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Center

        For Each Elemento As String In LineasDatosEmpresa
            Dim NumTotalNombre = ordTot.ObtenerTotalNombre(Elemento).Count
            CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
            lineaEspacioPagina += 8
        Next


    End Sub


    '//TEXTO A LA IZQUIERDA DEL INFORME
    Public Sub TextoIzquierda(texto As String)
        LineasDeLaCabeza.Add(texto)
    End Sub

    Public Sub AnadirLineaCabeza(ByVal linea As String)
        LineasDeLaCabeza.Add(linea)
    End Sub

    Private Sub DibujaLaCabecera()

        'Fuente de la impresion
        Dim FuenteImpresaEncabezadoIzquierda = New Font("Tahoma", 8, FontStyle.Regular)
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        'stringformat para alinear el text
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Near

        For Each Cabecera As String In LineasDeLaCabeza
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R2 As New RectangleF(5, lineaEspacioPagina, 100, 40)
            CadenaPorEscribirEnLinea = Cabecera
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoIzquierda, Brushes.Black, R2, StringFormat)
            lineaEspacioPagina += 5

        Next Cabecera

    End Sub


    '**************************************** Llamar a la impresion ************************************
    Public Function ImpresoraExistente(ByVal impresora As String) As Boolean

        For Each strPrinter As String In PrinterSettings.InstalledPrinters

            If impresora = strPrinter Then
                Return True
            End If
        Next strPrinter
        Return False
    End Function

    Dim lineasConteo As Decimal = 0.0
    Dim lineasTotales As Integer = 0
    Dim listaArrays As Integer = 0
    Dim numeracion As Integer = 0

    Private Sub lineasTotal()
        Dim total As Integer

        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdenarElementoEncomienda = New OrdenarElementoEncomienda()
        'Fuente de la impresion
        Dim FuenteImpresaDetalle = New Font("Tahoma", 8, FontStyle.Regular)
        Dim FuenteImpresaEncabezado = New Font("Tahoma", 8, FontStyle.Regular)
        'Se dibuja uin rectangulo parte derecha
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        Dim elemento As String = "", espacios As String = ""
        Dim nroEspacios As Integer = 0
        Dim cantidad As String = String.Empty
        Dim tipo As String = String.Empty
        Dim detalle As String = String.Empty
        Dim Codigo As String = String.Empty
        Dim ValidarTotal As String = String.Empty
        Dim um As String = String.Empty
        Dim descripcion As String = String.Empty
        Dim contadorPagina As Integer = 0


        For Each Item As String In LineasElementosEncomienda
            '//////////////////////////////////////////////////////////////////////////////////////////////////
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R0 As New RectangleF(4, lineaEspacio, 20, 130)
            'Colocar la cantidad a la derecha.
            Dim StringFormat As New StringFormat
            StringFormat.Alignment = StringAlignment.Far
            'imprime el numero de guia de remiision
            CadenaPorEscribirEnLinea = ordTot.OptenerGuia(Item)
            ' gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R0, StringFormat)

            '//////////////////////////////////////////////////////////////////////////////////////////////////
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R4 As New RectangleF(86, lineaEspacio, 60, 7)
            'Colocar la cantidad a la derecha.
            Dim StringFormatUM As New StringFormat
            StringFormatUM.Alignment = StringAlignment.Near
            'COSIGANADO
            CadenaPorEscribirEnLinea = ordTot.ObtenerConsignado(Item)
            ' gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R4, StringFormatUM)


            '//////////////////////////////////////////////////////////////////////////////////////////////////
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R2 As New RectangleF(139, lineaEspacio, 20, 130)

            cantidad = 0.0
            cantidad = ordTot.ObtenerCantidad(Item)

            'Colocar la cantidad a la derecha.
            Dim StringFormatCantidad As New StringFormat
            StringFormatCantidad.Alignment = StringAlignment.Far
            'IMPRIME LA CANTIDAD
            CadenaPorEscribirEnLinea = cantidad
            ' gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R2, StringFormatCantidad)

            '//////////////////////////////////////////////////////////////////////////////////////////////////
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R5 As New RectangleF(176, lineaEspacio, 55, 7)
            'Colocar la cantidad a la derecha.
            Dim StringFormatPrecioUnit As New StringFormat
            StringFormatPrecioUnit.Alignment = StringAlignment.Near
            'IMPRIME LOS DETALLES DE ÑA CARTA
            detalle = 0.0
            detalle = (ordTot.ObtenerDetalle(Item))
            CadenaPorEscribirEnLinea = detalle
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R5, StringFormatPrecioUnit)


            '//////////////////////////////////////////////////////////////////////////////////////////////////
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R6 As New RectangleF(160, lineaEspacio, 15, 130)
            'Colocar la cantidad a la derecha.
            Dim StringFormatTotal As New StringFormat
            StringFormatTotal.Alignment = StringAlignment.Center
            ValidarTotal = 0.0
            elemento = String.Empty
            'IMPRIME EL TIPO DE PAQUETE
            ValidarTotal = ordTot.ObtenerTipo(Item)
            CadenaPorEscribirEnLinea = ValidarTotal '.TrimStart("0")
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R6, StringFormatTotal)

            '//////////////////////////////////////////////////////////////////////////////////////////////////
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R7 As New RectangleF(229, lineaEspacio, 20, 130)
            'Colocar la cantidad a la derecha.
            Dim StringFormatImporte As New StringFormat
            StringFormatImporte.Alignment = StringAlignment.Far
            elemento = String.Empty
            'iMPRIME EL IMPORTE
            ValidarTotal = ordTot.ObtenerImporte(Item)
            CadenaPorEscribirEnLinea = ValidarTotal
            ' gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R7, StringFormatImporte)
            '

            '//////////////////////////////////////////////////////////////////////////////////////////////////
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R1 As New RectangleF(26, lineaEspacio, 60, 130)
            Codigo = ordTot.OptenerRemitente(Item)
            'Colocar la cantidad a la derecha.
            Dim StringFormatCodigo As New StringFormat
            StringFormatCodigo.Alignment = StringAlignment.Near
            'imprime el remitente 
            'CadenaPorEscribirEnLinea = Codigo
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R1, StringFormatCodigo)
            'lineaEspacio += 3
            If (Codigo.Length > 60) Then
                total = Codigo.Length / 60
                total += 1
                'Dim lineaEspacio2 As Integer = 82
                'For index As Integer = 1 To total
                'Dim R33 As New RectangleF(36, lineaEspacio, 90, 130)
                '    CadenaPorEscribirEnLinea = nombreArticlo
                '    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R33, StringFormatDescrip)
                '    lineaEspacio += 5
                'Next
                '  lineaEsapcioAnterior = lineaEspacio
                CadenaPorEscribirEnLinea = Codigo
                ' gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R1, StringFormatCodigo)
                lineaEspacio += (3 * total)
            Else
                CadenaPorEscribirEnLinea = Codigo
                'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R1, StringFormatCodigo)
                '
            End If
            lineaEspacio += 3

            ''/////////////////////////////////////////////////////////////
            ''se crea un rectangulo para manipular texto dentro del rectangulo
            'Dim R10 As New RectangleF(36, lineaEspacio, 90, 130)
            'Dim fecha As String
            ''Dim enviarNombre As String
            'fecha = ordTot.ObtenerFecha(Item)
            ''Colocar la cantidad a la derecha.
            'Dim StringFormatfecha As New StringFormat
            'StringFormatDescrip.Alignment = StringAlignment.Near
            'CadenaPorEscribirEnLinea = fecha

            AnadirLineaElementosEncomiendaXPagiancion(ordTot.OptenerGuia(Item), ordTot.OptenerRemitente(Item), ordTot.ObtenerConsignado(Item), ordTot.ObtenerCantidad(Item), ordTot.ObtenerDetalle(Item), ordTot.ObtenerTipo(Item), ordTot.ObtenerImporte(Item), ordTot.ObtenerFecha(Item))
            If (lineaEspacio >= 115) Then
                lineaEspacio = 62
                listaPaginas.Add(LineasElementosEncomiendaPaginacion)
                LineasElementosEncomiendaPaginacion = New ArrayList
                'LineasElementosFacturaPorPaginacion.Clear()
            End If

        Next Item

        listaPaginas.Add(LineasElementosEncomiendaPaginacion)
        'LineasElementosFacturaPorPaginacion.Clear()
        'lineasConteo = CDec(lineaEspacio)
        'lineasTotales = (lineasConteo / 260)

        'If (lineasTotales = (lineaEspacio / 260)) Then
        '    lineasTotales = lineasTotales
        'Else
        '    lineasTotales = lineasTotales + 1
        'End If
        listaArrays = listaPaginas.Count
    End Sub



    '*****************************************************************************
    '****************************** NOMBRE DE ENCABEZADO FACTURA ******************
    'Se declara el array para la Factura parte derecha
    Public LineasDeEncabezadoDerecha As ArrayList = New ArrayList()

    'Linea para capturar el ruc y numeroComprobante de la Factura
    Public Sub AnadirLineaCaracteresFactura(ByVal Ruc As String, ByVal NumeroFactura As String,
                                            ByVal tipoComprobante As String)
        Dim ordTot As OrdernarEncabezadoFactura = New OrdernarEncabezadoFactura()
        LineasDeEncabezadoDerecha.Add(ordTot.GenerarImprimir(Ruc, NumeroFactura, tipoComprobante))
    End Sub


    '*****************************************************************************
    '****************************** NOMBRE DE LOS ELEMENTOS ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasElementosEncomienda As ArrayList = New ArrayList()
    Public LineasElementosEncomiendaPaginacion As ArrayList = New ArrayList()

    'Linea para capturar el ruc y numeroComprobante de la Factura
    Public Sub AnadirLineaElementosEncomienda(ByVal numeracion As String, ByVal Remitente As String, ByVal Consignado As String, ByVal cantidad As String,
                                      ByVal detalle As String, ByVal Tipo As String, ByVal Importe As Decimal, ByVal Fecha As String)

        Dim ordTot As OrdenarElementoEncomienda = New OrdenarElementoEncomienda()
        LineasElementosEncomienda.Add(ordTot.GenerarImprimir(numeracion, Remitente, Consignado, cantidad,
                                                          detalle, Tipo, Importe, Fecha))
    End Sub

    Public Sub AnadirLineaElementosEncomiendaXPagiancion(ByVal numeracion As String, ByVal Remitente As String, ByVal Consignado As String, ByVal cantidad As String,
                                      ByVal detalle As String, ByVal Tipo As String, ByVal Importe As Decimal, ByVal Fecha As String)

        Dim ordTot As OrdenarElementoEncomienda = New OrdenarElementoEncomienda()
        LineasElementosEncomiendaPaginacion.Add(ordTot.GenerarImprimir(numeracion, Remitente, Consignado, cantidad, detalle,
                                                          Tipo, Importe, Fecha))
    End Sub


    'Dibuja `parte de la derecha de la factura
    Private Sub DibujaElementosFactura(i As ArrayList)
        lineaEspacio = 62
        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdenarElementoEncomienda = New OrdenarElementoEncomienda()
        'Fuente de la impresion
        Dim FuenteImpresaDetalle = New Font("Tahoma", 8, FontStyle.Regular)
        Dim FuenteImpresaEncabezado = New Font("Tahoma", 8, FontStyle.Regular)
        Dim FuenteImpresaLinea = New Font("Tahoma", 6, FontStyle.Regular)
        'Se dibuja uin rectangulo parte derecha
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)

        'Crear texto del EncabezaDO
        gfx.DrawString("   GUIA N°                               CONSIGNADO                                                                           CONTENIDO                                                            IMPORTE               DNI                     FIRMA                 FECHA", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 51, New StringFormat())
        gfx.DrawString("                      NOMBRE                                                        CANT.                TIPO                                            DETALLE", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 56, New StringFormat())
        'crear rectangulo d e la cabecera
        gfx.DrawRectangle(blackPen, 5, 50, 285, 10)
        'crear la fila GUIA DE REMISION
        gfx.DrawRectangle(blackPen, 5, 50, 20, 130)
        'crear la fila REMITENTE
        gfx.DrawRectangle(blackPen, 25, 50, 60, 130)
        ''crear la fila CONSIGANADO
        'gfx.DrawRectangle(blackPen, 85, 50, 60, 130)
        'crear la fila CONMTENIDO
        gfx.DrawRectangle(blackPen, 85, 50, 115, 130)

        ''crear la fila cantidad
        gfx.DrawRectangle(blackPen, 85, 55, 15, 125)
        '''crear la fila TIPO
        gfx.DrawRectangle(blackPen, 100, 55, 25, 125)
        '''crear la fila DETALLE
        gfx.DrawRectangle(blackPen, 125, 55, 75, 125)


        ''crear la fila IMPORTE
        gfx.DrawRectangle(blackPen, 200, 50, 20, 130)
        ''crear la fila DNI
        gfx.DrawRectangle(blackPen, 220, 50, 25, 130)
        ''''crear la fIRMA
        gfx.DrawRectangle(blackPen, 245, 50, 25, 130)
        '''crear la fila FECHA
        gfx.DrawRectangle(blackPen, 270, 50, 20, 130)


        Dim total As Decimal

        Dim elemento As String = "", espacios As String = ""
        Dim nroEspacios As Integer = 0
        'Dim ValorVentaUnit As String = String.Empty
        'Dim Descuento As String = String.Empty
        'Dim ValorVentaTotal As String = String.Empty
        'Dim OtrosCargos As String = String.Empty
        'Dim Impuestos As String = String.Empty
        Dim DETALLE As String = String.Empty
        Dim ValidarTotal As String = String.Empty
        Dim Cantidad As String = String.Empty
        Dim Codigo As String = String.Empty
        Dim um As String = String.Empty
        Dim descripcion As String = String.Empty
        Dim contadorPagina As Integer = 0
        Dim lineaEsapcioAnterior As Integer = 0
        For Each Item As String In i
            '//////////////////////////////////////////////////////////////////////////////////////////////////
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R0 As New RectangleF(5, lineaEspacio, 20, 130)
            'Colocar la cantidad a la derecha.
            Dim StringFormat As New StringFormat
            StringFormat.Alignment = StringAlignment.Center
            'imprime el numero de guia de remiision
            CadenaPorEscribirEnLinea = ordTot.OptenerGuia(Item)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R0, StringFormat)

            ''//////////////////////////////////////////////////////////////////////////////////////////////////
            ''se crea un rectangulo para manipular texto dentro del rectangulo
            'Dim R4 As New RectangleF(220, lineaEspacio, 25, 7)
            ''Colocar la cantidad a la derecha.
            'Dim StringFormatUM As New StringFormat
            'StringFormatUM.Alignment = StringAlignment.Center
            ''COSIGANADO
            'CadenaPorEscribirEnLinea = "_ _ _ _ _ _ _"
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R4, StringFormatUM)

            ''//////////////////////////////////////////////////////////////////////////////////////////////////
            ''se crea un rectangulo para manipular texto dentro del rectangulo
            'Dim R14 As New RectangleF(245, lineaEspacio, 25, 7)
            ''COSIGANADO
            'CadenaPorEscribirEnLinea = "_ _ _ _ _ _ _ _"
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R14, StringFormatUM)

            ''//////////////////////////////////////////////////////////////////////////////////////////////////
            ''se crea un rectangulo para manipular texto dentro del rectangulo
            'Dim R10 As New RectangleF(270, lineaEspacio, 20, 7)
            ''COSIGANADO
            'CadenaPorEscribirEnLinea = "_ _ _ _ _ _ _"
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R10, StringFormatUM)


            '//////////////////////////////////////////////////////////////////////////////////////////////////
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R2 As New RectangleF(85, lineaEspacio, 15, 130)

            Cantidad = 0.0
            Cantidad = ordTot.ObtenerCantidad(Item)

            'Colocar la cantidad a la derecha.
            Dim StringFormatCantidad As New StringFormat
            StringFormatCantidad.Alignment = StringAlignment.Center
            'IMPRIME LA CANTIDAD
            CadenaPorEscribirEnLinea = Cantidad
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R2, StringFormatCantidad)

            '//////////////////////////////////////////////////////////////////////////////////////////////////
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R5 As New RectangleF(101, lineaEspacio, 25, 7)
            'Colocar la cantidad a la derecha.
            Dim StringFormatPrecioUnit As New StringFormat
            StringFormatPrecioUnit.Alignment = StringAlignment.Near
            'IMPRIME LOS DETALLES DE ÑA CARTA
            DETALLE = 0.0
            DETALLE = (ordTot.ObtenerDetalle(Item))
            CadenaPorEscribirEnLinea = DETALLE
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R5, StringFormatPrecioUnit)


            '//////////////////////////////////////////////////////////////////////////////////////////////////
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R6 As New RectangleF(126, lineaEspacio, 65, 7)
            'Colocar la cantidad a la derecha.
            Dim StringFormatTotal As New StringFormat
            StringFormatTotal.Alignment = StringAlignment.Near
            ValidarTotal = 0.0
            elemento = String.Empty
            'IMPRIME EL TIPO DE PAQUETE
            ValidarTotal = ordTot.ObtenerTipo(Item)
            CadenaPorEscribirEnLinea = ValidarTotal '.TrimStart("0")
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R6, StringFormatTotal)

            '//////////////////////////////////////////////////////////////////////////////////////////////////
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R7 As New RectangleF(200, lineaEspacio, 20, 130)
            'Colocar la cantidad a la derecha.
            Dim StringFormatImporte As New StringFormat
            StringFormatImporte.Alignment = StringAlignment.Far
            elemento = String.Empty
            'iMPRIME EL IMPORTE
            ValidarTotal = ordTot.ObtenerImporte(Item)
            CadenaPorEscribirEnLinea = ValidarTotal
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R7, StringFormatImporte)


            '//////////////////////////////////////////////////////////////////////////////////////////////////
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R1 As New RectangleF(26, lineaEspacio, 60, 130)
            Codigo = ordTot.ObtenerConsignado(Item)
            'Colocar la cantidad a la derecha.
            Dim StringFormatCodigo As New StringFormat
            StringFormatCodigo.Alignment = StringAlignment.Near
            'imprime el remitente 
            'CadenaPorEscribirEnLinea = Codigo
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R1, StringFormatCodigo)
            'lineaEspacio += 3

            If (Codigo.Length > 60) Then
                total = Codigo.Length / 60
                total += 1
                'Dim lineaEspacio2 As Integer = 82
                'For index As Integer = 1 To total
                'Dim R33 As New RectangleF(36, lineaEspacio, 90, 130)
                '    CadenaPorEscribirEnLinea = nombreArticlo
                '    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R33, StringFormatDescrip)
                '    lineaEspacio += 5
                'Next
                lineaEsapcioAnterior = lineaEspacio
                CadenaPorEscribirEnLinea = Codigo
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R1, StringFormatCodigo)
                lineaEspacio += (3 * total)
            Else
                CadenaPorEscribirEnLinea = Codigo
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R1, StringFormatCodigo)

            End If
            'lineaEspacio = lineaEsapcioAnterior

            count += 1
            contadorPagina += 1
            If (contadorPagina = 49) Then

                contadorPagina = 0
            End If


            lineaEspacio += 6
            '//////////////////////////////////////////////////////////////////////////////////////////////////
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R10 As New RectangleF(5, lineaEspacio, 288, 4)
            'COSIGANADO

            'Dim StringFormatLinea As New StringFormat
            'StringFormatLinea.Alignment = StringAlignment.Near

            'CadenaPorEscribirEnLinea = "_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ "
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaLinea, Brushes.Black, R10, StringFormatLinea)


            'lineaEspacio += 7
            'Item.Remove(COUNT)
            'LineasElementosFactura.Remove(COUNT)
            'If (lineaEspacio >= 260) Then
            '    Exit For
            'End If
        Next Item
    End Sub


    '*****************************************************************************
    '****************************** NOMBRE importes TOTALES ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasDatosComplementario As ArrayList = New ArrayList()

    'Linea para capturar el ruc y numeroComprobante de la Factura
    Public Sub AnadirLineaDatos(ByVal nombreAdministrador As String, nombreChofer As String, nombreConfirmado As String)

        Dim ordTot As OrdernarFirmasEncomiendas = New OrdernarFirmasEncomiendas()
        LineasDatosComplementario.Add(ordTot.GenerarTotal(nombreAdministrador, nombreChofer, nombreConfirmado))
    End Sub

    'Dibuja `parte de la derecha de la factura
    Private Sub DibujaDatosComplementarios()
        'se crea un rectangulo para manipular texto dentro del rectangulo

        'Fuente de la impresion
        Dim FuenteImpresaEncabezado = New Font("Tahoma", 7, FontStyle.Regular)

        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarFirmasEncomiendas = New OrdernarFirmasEncomiendas()
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        'stringformat para alinear el text
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Center

        'MUESTRA QUE ESPACIO SE DARA AL PROPIETARIO PARA QUE EL ESPACIO NO SEA MUY GRANDE
        'lineaEspacio += 9

        'For Each Elemento As String In LineasDatosComplementario



        'Next
        gfx.DrawLine(blackPen, 53, 194, 85, 194)
        'gfx.DrawLine(blackPen, 150, 210, 160, 210)
        gfx.DrawLine(blackPen, 120, 194, 152, 194)
        'lineaEspacio += 3

        gfx.DrawLine(blackPen, 190, 194, 225, 194)

        Dim R7 As New RectangleF(1, 195, 270, 5)
        Dim StringFormatGeneral As New StringFormat
        StringFormatGeneral.Alignment = StringAlignment.Center
        gfx.DrawString("        ADMINISTRADOR                                                                     CHOFER                                                                       RECIBIR CONFORME                             ", FuenteImpresaEncabezado, Brushes.Black, R7, StringFormatGeneral)

    End Sub


End Class