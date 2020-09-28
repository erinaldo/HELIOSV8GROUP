Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Net.Mail

Public Class TicketFCxCobrar
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
    Public CaracteresMaximos As Integer = 39
    Public CaracteresMaximosGuion As Integer = 39
    Public CaracteresMaximosDescripcion As Integer = 39
    Public tipoComprobante As String = String.Empty
    Public imageHeight As Integer = 0
    Public imageQR As Integer = 0
    Dim numeracion As Integer = 0
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
    Public lineaEspacio As Integer = 0
    Dim listaPaginas As New List(Of ArrayList)
    Dim ListaArray As New ArrayList

    Public tipoImagen As Boolean
    Public tipoEncabezado As Boolean
    Public tipoPublicidad As Boolean

    Public Sub GuardanImpresion(ByVal impresora As String, ByVal NombreNumero As String, txtEmailEmpresa As String,
                             txtContrasenaEmpresa As String, txtEmailDestino As String, txtDescripcion As String,
                             txtAsunto As String)

        If (File.Exists(Path.Combine("C:\FACTURASELECTRONICAS\PDF\", NombreNumero & ".pdf"))) Then
            Kill(Path.Combine("C:\FACTURASELECTRONICAS\PDF\", NombreNumero & ".pdf"))
        End If

        DocumentoAImprimir.PrinterSettings.PrinterName = impresora
        My.Computer.FileSystem.CreateDirectory("C:\FACTURASELECTRONICAS\PDF\")
        DocumentoAImprimir.PrinterSettings.PrintToFile = True
        DocumentoAImprimir.PrinterSettings.PrintFileName = Path.Combine("C:\FACTURASELECTRONICAS\PDF\", NombreNumero & ".pdf")
        'lineasTotal()
        DocumentoAImprimir.Print()

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


    Public Sub ImprimeTicket(ByVal impresora As String, ByVal conteoImpresion As Integer)

        'FuenteImpresa = New Font(NombreLetra, TamanoLetra, FontStyle.Regular)
        'Dim pr As New PrintDocument 
        DocumentoAImprimir.PrinterSettings.PrinterName = impresora
        'pr.PrinterSettings.printpa() 
        ' pr.PrintPage += New 
        ' PrintPageEventHandler(pr_PrintPage) 
        'lineasTotal()

        For number As Integer = conteoImpresion To 1 Step -1
            DocumentoAImprimir.Print()
        Next

    End Sub

    Dim comienzo As Integer = 0
    Dim contadorPAginas As Integer = 0
    Dim PAGINAS As Integer 'PARA NUMERAR LAS PAGINAS
    Private Sub DocumentoAImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocumentoAImprimir.PrintPage
        lineaEspacio = 0
        PAGINAS += 1
        e.Graphics.PageUnit = GraphicsUnit.Millimeter
        gfx = e.Graphics
        'LineasElementosFacturaPorPaginacion.Clear()
        DrawImage()
        'DrawHeader()
        contador = 0
        imageHeight = 0

        Select Case tipoEncabezado
            Case True
                DibujaDatosEmpresa()
                DibujaDatosNombrePropietario()
            Case False
                DibujaDatosEmpresa()
        End Select

        Select Case tipoPublicidad
            Case True
                DibujaDatosNombrePublicidad()
        End Select

        DibujaLaCabecera()
        DibujaDatosComprobante()
        DibujaLaSubCabeceraIzquierda()
        DibujaLineasDatosFinales()
    End Sub

    Public Property HeaderImage() As Image
        Get
            Return headerImagep
        End Get
        Set(ByVal value As Image)
            'If headerImagep.Width <> value.Width Then 

            'End If 
            headerImagep = value
        End Set
    End Property

    Public Property headerImagenQR() As Image
        Get
            Return headerImageQR
        End Get
        Set(ByVal value As Image)
            'If headerImagep.Width <> value.Width Then 

            'End If 
            headerImageQR = value
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


    Public Sub AnadirLineaCabeza(ByVal linea As String)
        LineasDeLaCabeza.Add(linea)
    End Sub

    Public Sub AnadirLineaSubcabeza(ByVal linea As String)
        LineasDeLaSubCabeza.Add(linea)
    End Sub

    Public Sub AnadirLineaCaracteres(ByVal linea As String)
        LineasDeCaracteres.Add(linea)
    End Sub

    'Metodo para centrar el texto
    Public Sub TextoCentro(texto As String)
        If texto.Length > CaracteresMaximos Then
            Dim caracterActual As Integer = 0
            'Nos indicara en que caracter se quedo al bajar el texto a la siguiente linea
            Dim longitudTexto As Integer = texto.Length
            While longitudTexto > CaracteresMaximos
                'Agregamos los fragmentos que salgan del texto
                LineasDeLaCabeza.Add(texto.Substring(caracterActual, CaracteresMaximos))
                caracterActual += CaracteresMaximos
                longitudTexto -= CaracteresMaximos
            End While
            'Variable para poner espacios restntes
            Dim espacios As String = ""
            'sacamos la cantidad de espacios libres y el resultado lo dividimos entre dos
            Dim centrar As Integer = ((CaracteresMaximos) - texto.Substring(caracterActual, texto.Length - caracterActual).Length) / 2
            'Obtenemos la longitud del texto restante.
            For i As Integer = 0 To centrar - 1
                'Agrega espacios para centrar
                espacios += " "
            Next

            'agregamos el fragmento restante, agregamos antes del texto los espacios
            LineasDeLaCabeza.Add(espacios & texto.Substring(caracterActual, texto.Length - caracterActual))
        Else
            Dim espacios As String = ""
            'sacamos la cantidad de espacios libres y el resultado lo dividimos entre dos
            Dim centrar As Integer = ((CaracteresMaximos) - texto.Length) / 2
            'Obtenemos la longitud del texto restante.
            For i As Integer = 0 To centrar - 1
                'Agrega espacios para centrar
                espacios += " "
            Next

            'agregamos el fragmento restante, agregamos antes del texto los espacios

            LineasDeLaCabeza.Add(espacios & texto)
        End If
    End Sub

    'Creamos un metodo para poner el texto a la izquierda
    Public Sub TextoIzquierda(texto As String)
        'Si la longitud del texto es mayor al numero maximo de caracteres permitidos, realizar el siguiente procedimiento.
        'If texto.Length > CaracteresMaximos Then
        '    Dim caracterActual As Integer = 0
        '    'Nos indicara en que caracter se quedo al bajar el texto a la siguiente linea
        '    Dim longitudTexto As Integer = texto.Length
        '    While longitudTexto > CaracteresMaximos
        '        'Agregamos los fragmentos que salgan del texto
        '        LineasDeLaCabeza.Add(texto.Substring(caracterActual, CaracteresMaximos))
        '        caracterActual += CaracteresMaximos
        '        longitudTexto -= CaracteresMaximos
        '    End While
        '    'agregamos el fragmento restante
        '    LineasDeLaCabeza.Add(texto.Substring(caracterActual, texto.Length - caracterActual))
        'Else
        'Si no es mayor solo agregarlo.
        LineasDeLaCabeza.Add(texto)
        'End If
    End Sub

    'Creamos un metodo para poner texto a la derecha.
    Public Sub TextoDerecha(texto As String)
        'Si la longitud del texto es mayor al numero maximo de caracteres permitidos, realizar el siguiente procedimiento.
        If texto.Length > CaracteresMaximos Then
            Dim caracterActual As Integer = 0
            'Nos indicara en que caracter se quedo al bajar el texto a la siguiente linea
            Dim longitudTexto As Integer = texto.Length
            While longitudTexto > CaracteresMaximos
                'Agregamos los fragmentos que salgan del texto
                LineasDeLaCabeza.Add(texto.Substring(caracterActual, CaracteresMaximos))
                caracterActual += CaracteresMaximos
                longitudTexto -= CaracteresMaximos
            End While
            'Variable para poner espacios restntes
            Dim espacios As String = ""
            'Obtenemos la longitud del texto restante.
            For i As Integer = 0 To (CaracteresMaximos - texto.Substring(caracterActual, texto.Length - caracterActual).Length) - 1
                'Agrega espacios para alinear a la derecha
                espacios += " "
            Next

            'agregamos el fragmento restante, agregamos antes del texto los espacios
            LineasDeLaCabeza.Add(espacios & texto.Substring(caracterActual, texto.Length - caracterActual))
        Else
            Dim espacios As String = ""
            'Obtenemos la longitud del texto restante.
            For i As Integer = 0 To (CaracteresMaximos - texto.Length) - 1
                'Agrega espacios para alinear a la derecha
                espacios += " "
            Next
            'Si no es mayor solo agregarlo.
            LineasDeLaCabeza.Add(espacios & texto)
        End If
    End Sub

    Public Sub AnadirElemento(ByVal cantidad As String, ByVal UM As String, ByVal precioUnit As String, ByVal precio As String, ByVal nombreArticulo As String)

        Dim NuevoElemento As OrdenarElementos = New OrdenarElementos()
        '''''items.Add(newitem. 
        Elementos.Add(NuevoElemento.GenerarElemento(cantidad, UM, precioUnit, precio, nombreArticulo))
    End Sub

    Public Sub AnadirNombreElemento(ByVal NombreElemento As String)

        Dim NuevoNombreElemento As OrdenarElementos = New OrdenarElementos()
        '''''items.Add(newitem. 
        Nombre_Elementos.Add(NuevoNombreElemento.GenerarNombreElemento(NombreElemento))
    End Sub

    Public Sub AnadirTotal(ByVal Nombre As String, ByVal Precio As String)
        Dim NuevoTotal As OrdernarTotal = New OrdernarTotal
        ' OrderTotal(newtotal) 

        Totales.Add(NuevoTotal.GenerarTotal(Nombre, Precio))
    End Sub

    Public Sub AnadeLineaAlPie(ByVal linea As String)
        LineasDelPie.Add(linea)
    End Sub


    Private Function AlineaTextoaLaDerecha(ByVal Izquierda As Integer) As String

        Dim espacios As String = ""
        Dim spaces As Integer = (14) - Izquierda
        Dim x As Integer
        For x = 0 To spaces
            espacios += " "
        Next
        Return espacios
    End Function

    Private Function AlineaTextoaLaDerechaPrecioUnit(ByVal Izquierda As Integer) As String

        Dim espacios As String = ""
        Dim spaces As Integer = (-10) - Izquierda
        Dim x As Integer
        For x = 0 To spaces
            espacios += " "
        Next
        Return espacios
    End Function

    Private Function Renglon() As Double
        Return MargenSuperior + (contador * FuenteImpresa.GetHeight(gfx) + imageHeight)
    End Function

    Private Function RenglonGeneral() As Double
        Return MargenSuperior + (contador * FuenteImpresa.GetHeight(gfx) + imageHeight)
    End Function

    Private Sub DrawImage()
        Try
            If (tipoImagen = True) Then
                If (Not IsNothing(headerImagep)) Then
                    If (headerImagep.Width <> 0) Then
                        Dim destRect As New Rectangle(5, 2, 55, 20)

                        gfx.DrawImage(HeaderImage, destRect)
                        Dim height As Double = (HeaderImage.Height / 200)
                        imageHeight = CInt(Math.Round(height) + 3)
                        lineaEspacio = lineaEspacio + 22

                    End If
                End If
            ElseIf (tipoImagen = False) Then
                If (Not IsNothing(headerImagep)) Then
                    If (headerImagep.Width <> 0) Then
                        Dim destRect As New Rectangle(7, 2, 50, 40)

                        gfx.DrawImage(HeaderImage, destRect)
                        Dim height As Double = (HeaderImage.Height / 200)
                        imageHeight = CInt(Math.Round(height) + 3)
                        lineaEspacio = lineaEspacio + 43

                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub DrawImageQR()
        Try

            If (Not IsNothing(headerImageQR.Width)) Then
                If (headerImageQR.Width <> 0) Then
                    Dim destRect As New Rectangle(22, lineaEspacio + 5, 15, 15)

                    gfx.DrawImage(headerImagenQR, destRect)
                    Dim height As Double = (headerImagenQR.Height / 200)
                    imageQR = CInt(Math.Round(height) + 3)
                    'lineaEspacio = lineaEspacio + 22
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DibujaLaCabecera()
        'se crea un rectangulo para manipular texto dentro del rectangulo
        'Dim R2 As New RectangleF(5, 25, 100, 80)
        'Fuente de la impresion
        Dim FuenteImpresaEncabezadoIzquierda = New Font("Tahoma", 7, FontStyle.Bold)
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        'stringformat para alinear el text
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Center
        Dim total As Integer
        'Dim count As Integer = 14


        Select Case tipoPublicidad
            Case True
                lineaEspacio = lineaEspacio + 5
            Case False
                'MUESTRA QUE ESPACIO SE DARA AL PROPIETARIO PARA QUE EL ESPACIO NO SEA MUY GRANDE
                If (lineaEspacio = 22 Or lineaEspacio = 0) Then
                    lineaEspacio += 5
                ElseIf (lineaEspacio = 23 Or lineaEspacio = 1) Then
                    lineaEspacio += 12
                ElseIf lineaEspacio = 42 Then
                    lineaEspacio += 12
                ElseIf lineaEspacio = 2 Then
                    lineaEspacio += 12
                ElseIf lineaEspacio = 24 Then
                    lineaEspacio += 12
                Else
                    lineaEspacio += 6
                End If

        End Select

        For Each Cabecera As String In LineasDeLaCabeza
            Dim R2 As New RectangleF(1, lineaEspacio, 60, 60)
            Dim nombreArticlo As String
            'Dim enviarNombre As String
            nombreArticlo = Cabecera

            'Colocar la cantidad a la derecha.
            'Dim StringFormatDescrip As New StringFormat
            'StringFormatDescrip.Alignment = StringAlignment.Near

            If (nombreArticlo.Length > 40) Then
                total = nombreArticlo.Length / 55

                CadenaPorEscribirEnLinea = nombreArticlo
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoIzquierda, Brushes.Black, R2, StringFormat)
                lineaEspacio += (3 * total)
            Else
                CadenaPorEscribirEnLinea = nombreArticlo
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoIzquierda, Brushes.Black, R2, StringFormat)
            End If

            'Dim R2 As New RectangleF(5, count, 60, 60)
            'CadenaPorEscribirEnLinea = Cabecera
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoIzquierda, Brushes.Black, R2, StringFormat)
            lineaEspacio += 4
            'contador += 1
            'End If
        Next Cabecera

        'DibujaEspacio()
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
    '****************************** NOMBRE DE DATOS COMPLEMENTARIOS ******************
    'Se declara el array para la Factura parte derecha
    Public LineasDatosComplementarios As ArrayList = New ArrayList()

    'Linea para capturar el ruc y numeroComprobante de la Factura
    Public Sub AnadirLineaDatosComplementarios(ByVal Ruc As String, ByVal NumeroFactura As String, tipoComprobante As String)
        Dim ordTot As OrdernarEncabezadoFactura = New OrdernarEncabezadoFactura()
        LineasDeEncabezadoDerecha.Add(ordTot.GenerarImprimir(Ruc, NumeroFactura, tipoComprobante))
    End Sub

    'Dibuja `parte de la derecha de la factura
    Private Sub DibujaLaCabeceraDerecha()

        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Aqua, 0)
        'stringformat para alinear el text
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Center
        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarEncabezadoFactura = New OrdernarEncabezadoFactura()
        'Fuente de la impresion
        Dim FuenteImpresaEncabezado = New Font("Tahoma", 16, FontStyle.Regular)

        'se dibuja un rectangulo
        gfx.DrawRectangle(blackPen, 110, 5, 93, 35)

        'Se imprime los datos dentro del rectangulo
        For Each Cabecera As String In LineasDeEncabezadoDerecha
            'se captura NumeroRuc del Array
            Dim R1 As New RectangleF(110, 8, 93, 40)
            CadenaPorEscribirEnLinea = ordTot.ObtenerNumeroRuc(Cabecera)
            gfx.DrawString("R.U.C. " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R1, StringFormat)

            Dim R2 As New RectangleF(110, 20, 93, 40)
            CadenaPorEscribirEnLinea = ordTot.ObtenerTipoComprobante(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)

            Dim R3 As New RectangleF(110, 32, 93, 40)
            CadenaPorEscribirEnLinea = ordTot.ObtenerNumeroFactura(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R3, StringFormat)

            'Dim R4 As New RectangleF(110, 30, 85, 40)
            'CadenaPorEscribirEnLinea = ordTot.ObtenerSerie(Cabecera)
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R3, StringFormat)
            'contador += 1
        Next

    End Sub

    '*****************************************************************************
    '****************************** NOMBRE DE ENCABEZADO DATOS GENERALES ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasDeEncabezadoIzquierda As ArrayList = New ArrayList()

    'Linea para capturar el ruc y numeroComprobante de la Factura
    Public Sub AnadirLineaCaracteresDatosGEnerales(ByVal fechaEmisiom As String, ByVal Lugar As String,
                                                   ByVal Nombre As String, ByVal direccion As String,
                                                  ByVal direccionEntrega As String, ByVal docIdentidad As String,
                                                  ByVal moneda As String, ByVal telefono As String)

        Dim ordTot As OrdernarSubEncabezadoDatosGenerales = New OrdernarSubEncabezadoDatosGenerales()
        LineasDeEncabezadoIzquierda.Add(ordTot.GenerarImprimir(fechaEmisiom, Lugar, Nombre, direccion,
                                                               direccionEntrega, docIdentidad, moneda, telefono))
    End Sub

    'Dibuja `parte de la derecha de la factura
    Private Sub DibujaLaSubCabeceraIzquierda()
        Dim total As Integer
        'stringformat para alinear el text
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Near
        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarSubEncabezadoDatosGenerales = New OrdernarSubEncabezadoDatosGenerales()
        'Fuente de la impresion
        Dim FuenteImpresaEncabezado = New Font("Tahoma", 7, FontStyle.Regular)

        Dim StringFormatLinea As New StringFormat
        StringFormatLinea.Alignment = StringAlignment.Near
        Dim R10 As New RectangleF(1, lineaEspacio - 1, 65, 60)
        gfx.DrawString("---------------------------------------------------------------------", FuenteImpresaEncabezado, Brushes.Black, R10, StringFormatLinea)

        'Dim count As Integer = 32
        lineaEspacio = lineaEspacio + 1
        'Se imprime los datos dentro del rectangulo
        For Each Cabecera As String In LineasDeEncabezadoIzquierda
            ''se crea un rectangulo para manipular texto dentro del rectangulo
            'Dim R2 As New RectangleF(1, lineaEspacio, 60, 25)
            ''se captura NumeroRuc del Array
            'CadenaPorEscribirEnLinea = ordTot.OrdernarfechaEmision(Cabecera)

            'gfx.DrawString("FECHA: " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
            'lineaEspacio += 3

            'se crea un rectangulo para manipular texto dentro del rectangulo

            Dim R4 As New RectangleF(1, lineaEspacio, 60, 25)
            'documkentop
            CadenaPorEscribirEnLinea = ordTot.ObtenerdocIdentidad(Cabecera)
            gfx.DrawString("DOC. : " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R4, StringFormat)
            lineaEspacio += 3

            CadenaPorEscribirEnLinea = CStr("CLIENTE: " & ordTot.ObtenerNombre(Cabecera))
            total = CStr(CadenaPorEscribirEnLinea).Length
            Dim saltodeLineaNombre As Integer = 1
            If (total <= 30) Then
                saltodeLineaNombre = saltodeLineaNombre * 3
                Dim R5 As New RectangleF(1, lineaEspacio, 60, saltodeLineaNombre)
                'se captura NumeroRuc del Array
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R5, StringFormat)
                lineaEspacio += 3
            ElseIf (total >= 30 And total <= 60) Then
                saltodeLineaNombre = 2 * 3
                Dim R5 As New RectangleF(1, lineaEspacio, 60, saltodeLineaNombre)
                'se captura NumeroRuc del Array
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R5, StringFormat)
                lineaEspacio += 6
            ElseIf (total > 60 And total <= 90) Then
                saltodeLineaNombre = 3 * 3
                Dim R5 As New RectangleF(1, lineaEspacio, 60, saltodeLineaNombre)
                'se captura NumeroRuc del Array
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R5, StringFormat)
                lineaEspacio += 6
            ElseIf (total >= 91) Then
                saltodeLineaNombre = 3 * 3
                Dim R5 As New RectangleF(1, lineaEspacio, 60, saltodeLineaNombre)
                'se captura NumeroRuc del Array
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R5, StringFormat)
                lineaEspacio += 9
            End If

            'CadenaPorEscribirEnLinea = CStr("DIRECCION: " & ordTot.Obtenerdireccion(Cabecera))
            'total = CStr(CadenaPorEscribirEnLinea).Length
            'Dim saltodeLineaDireccion As Integer = 1
            'If (total <= 30) Then
            '    saltodeLineaDireccion = saltodeLineaDireccion * 3
            '    Dim R5 As New RectangleF(1, lineaEspacio, 60, saltodeLineaDireccion)
            '    'se captura NumeroRuc del Array
            '    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R5, StringFormat)
            '    lineaEspacio += 3
            'ElseIf (total >= 30 And total <= 60) Then
            '    saltodeLineaDireccion = 2 * 3
            '    Dim R5 As New RectangleF(1, lineaEspacio, 60, saltodeLineaDireccion)
            '    'se captura NumeroRuc del Array
            '    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R5, StringFormat)
            '    lineaEspacio += 6
            'ElseIf (total > 60 And total <= 90) Then
            '    saltodeLineaDireccion = 3 * 3
            '    Dim R5 As New RectangleF(1, lineaEspacio, 60, saltodeLineaDireccion)
            '    'se captura NumeroRuc del Array
            '    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R5, StringFormat)
            '    lineaEspacio += 9
            'ElseIf (total >= 91) Then
            '    saltodeLineaDireccion = 3 * 3
            '    Dim R5 As New RectangleF(1, lineaEspacio, 60, saltodeLineaDireccion)
            '    'se captura NumeroRuc del Array
            '    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R5, StringFormat)
            '    lineaEspacio += 12
            'End If

        Next

    End Sub

    '*****************************************************************************
    '****************************** NOMBRE DE LOS ELEMENTOS ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasElementosFactura As ArrayList = New ArrayList()
    'Public LineasElementosFacturaPorPaginacion As ArrayList = New ArrayList()

    'Linea para capturar el ruc y numeroComprobante de la Factura
    Public Sub AnadirLineaElementosFactura(ByVal cantidad As String, ByVal Descripcion As String,
                                      ByVal UM As String, ByVal PrecioVenta As String, ByVal Descuento As String, ByVal VentaTotal As String)

        Dim ordTot As OrdenarElementoFacturaTicketv2 = New OrdenarElementoFacturaTicketv2()
        LineasElementosFactura.Add(ordTot.GenerarImprimir(cantidad, Descripcion, UM,
                                                           PrecioVenta, Descuento, VentaTotal))
    End Sub

    'Public Sub AnadirLineaElementosFacturaXPagina(ByVal numeracion As String, ByVal codigo As String, ByVal Descripcion As String, ByVal cantidad As String,
    '                                  ByVal UM As String, ByVal PrecioVenta As String, ByVal VentaTotal As String)

    '    Dim ordTot As OrdenarElementoFacturaXPagina = New OrdenarElementoFacturaXPagina()
    '    LineasElementosFacturaPorPaginacion.Add(ordTot.GenerarImprimir(numeracion, codigo, Descripcion, cantidad, UM,
    '                                                      PrecioVenta, VentaTotal))
    'End Sub

    Dim COUNT As Integer = 1

    Private Sub DibujaElementosFactura()
        lineaEspacio = lineaEspacio + 3 '55
        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdenarElementoFacturaTicketv2 = New OrdenarElementoFacturaTicketv2()
        'Fuente de la impresion
        Dim FuenteImpresaDetalle = New Font("Tahoma", 7, FontStyle.Regular)
        Dim FuenteImpresaEncabezado = New Font("Tahoma", 7, FontStyle.Regular)
        'Se dibuja uin rectangulo parte derecha
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)

        Dim StringFormatLinea As New StringFormat
        StringFormatLinea.Alignment = StringAlignment.Near

        Dim RLINEA As New RectangleF(1, lineaEspacio, 70, +5)
        gfx.DrawString("---------------------------------------------------------------------", FuenteImpresaEncabezado, Brushes.Black, RLINEA, StringFormatLinea)
        lineaEspacio += 3
        'Crear texto del EncabezaDO
        Dim REncabezado As New RectangleF(3, lineaEspacio, 70, +5)
        gfx.DrawString("    CANT        │       UM      │              ARTICULO         ", FuenteImpresaEncabezado, Brushes.Black, REncabezado, StringFormatLinea)
        Dim REncabezado2 As New RectangleF(3, lineaEspacio + 3, 70, +5)
        gfx.DrawString("     P.U.         │     DESC.    │               IMPORTE    ", FuenteImpresaEncabezado, Brushes.Black, REncabezado2, StringFormatLinea)
        lineaEspacio += 6
        Dim RLINEA2 As New RectangleF(1, lineaEspacio, 70, +5)
        gfx.DrawString("---------------------------------------------------------------------", FuenteImpresaEncabezado, Brushes.Black, RLINEA2, StringFormatLinea)
        lineaEspacio += 3
        Dim elemento As String = "", espacios As String = ""
        Dim nroEspacios As Integer = 0
        'Dim ValorVentaUnit As String = String.Empty
        'Dim Descuento As String = String.Empty
        'Dim ValorVentaTotal As String = String.Empty
        'Dim OtrosCargos As String = String.Empty
        'Dim Impuestos As String = String.Empty
        Dim PrecioVenta As String = String.Empty
        Dim Descuento As String = String.Empty
        Dim ValidarTotal As String = String.Empty
        Dim Cantidad As String = String.Empty
        Dim Codigo As String = String.Empty

        Dim um As String = String.Empty
        Dim descripcion As String = String.Empty
        Dim contadorPagina As Integer = 0


        For Each Item As String In LineasElementosFactura
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R0 As New RectangleF(1, lineaEspacio, 11, +5)
            'con 7 de tamaño
            'Dim R0 As New RectangleF(5, lineaEspacio, 13, +5)
            'conteo de item
            'numeracion += 1
            'Colocar la cantidad a la derecha.
            Dim StringFormat As New StringFormat
            StringFormat.Alignment = StringAlignment.Far

            CadenaPorEscribirEnLinea = ordTot.ObtenerCantidad(Item)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R0, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R4 As New RectangleF(12, lineaEspacio, 10, +5)
            'Colocar la cantidad a la derecha.
            Dim StringFormatUM As New StringFormat
            StringFormatUM.Alignment = StringAlignment.Near

            CadenaPorEscribirEnLinea = ordTot.ObtenerUM(Item)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R4, StringFormatUM)


            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R3 As New RectangleF(18, lineaEspacio, 50, +10)
            Dim total As Integer
            Dim nombreArticlo As String
            'Dim enviarNombre As String
            nombreArticlo = ordTot.ObtenerDescripcion(Item)

            'Colocar la cantidad a la derecha.
            Dim StringFormatDescrip As New StringFormat
            StringFormatDescrip.Alignment = StringAlignment.Near

            If (nombreArticlo.Length <= 28) Then
                CadenaPorEscribirEnLinea = nombreArticlo
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R3, StringFormatDescrip)
            ElseIf (nombreArticlo.Length > 28 And nombreArticlo.Length <= 50) Then
                CadenaPorEscribirEnLinea = nombreArticlo
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R3, StringFormatDescrip)
                lineaEspacio += (3)
            Else
                total = nombreArticlo.Length / 50
                CadenaPorEscribirEnLinea = nombreArticlo
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R3, StringFormatDescrip)
                lineaEspacio += (3 * total)
            End If


            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R5 As New RectangleF(10, lineaEspacio + 3, 15, +5)
            'Colocar la cantidad a la derecha.
            Dim StringFormatPrecioUnit As New StringFormat
            StringFormatPrecioUnit.Alignment = StringAlignment.Far

            PrecioVenta = 0.0
            PrecioVenta = FormatNumber(ordTot.ObtenerPrecioVenta(Item), 2)

            CadenaPorEscribirEnLinea = PrecioVenta
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R5, StringFormatPrecioUnit)

            '//DESCUENTO
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R10 As New RectangleF(30, lineaEspacio + 3, 15, +5)
            'Colocar la DESCUENTO a la derecha.
            Dim StringFormatDescuento As New StringFormat
            StringFormatPrecioUnit.Alignment = StringAlignment.Far

            Descuento = 0.0
            Descuento = FormatNumber(ordTot.ObtenerDescuento(Item), 2)

            CadenaPorEscribirEnLinea = Descuento
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R10, StringFormatDescuento)


            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R6 As New RectangleF(43, lineaEspacio + 3, 20, +5)
            'Colocar la cantidad a la derecha.
            Dim StringFormatTotal As New StringFormat
            StringFormatTotal.Alignment = StringAlignment.Far

            ValidarTotal = 0.0
            elemento = String.Empty
            ValidarTotal = FormatNumber(ordTot.ObtenerVentaTotal(Item), 2)

            CadenaPorEscribirEnLinea = ValidarTotal '.TrimStart("0")
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R6, StringFormatTotal)



            'COUNT += 1
            'contadorPagina += 1
            'If (contadorPagina = 49) Then

            '    contadorPagina = 0
            'End If
            lineaEspacio += 6



            'Item.Remove(COUNT)
            'LineasElementosFactura.Remove(COUNT)
            'If (lineaEspacio >= 260) Then
            '    Exit For
            'End If
        Next Item
        Dim r8 As New RectangleF(2, lineaEspacio, 65, +5)
        'Colocar la cantidad a la derecha.
        Dim StringFormatpuntos As New StringFormat
        StringFormatpuntos.Alignment = StringAlignment.Near
        gfx.DrawString("---------------------------------------------------------------------", FuenteImpresaDetalle, Brushes.Black, r8, StringFormatpuntos)
    End Sub


    '*****************************************************************************
    '****************************** NOMBRE importes TOTALES ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasDatosComplementaria As ArrayList = New ArrayList()

    'Linea para capturar el ruc y numeroComprobante de la Factura
    Public Sub AnadirLineaTotalFactura(ByVal codigo As String, ByVal CuentaSoles As String, ByVal CuentaSoles2 As String, ByVal CuentaDolares As String, ByVal CuentaDolares2 As String, ByVal DescripcionComplementaria As String)
        Dim ordTot As OrdernarDatosComplentarias = New OrdernarDatosComplentarias()
        LineasDatosComplementaria.Add(ordTot.GenerarTotal(codigo, CuentaSoles, CuentaSoles2, CuentaDolares, CuentaDolares2, DescripcionComplementaria))
    End Sub

    'Dibuja `parte de la derecha de la factura
    Private Sub DibujaDatosGenerales(Paginacion As String)

        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarDatosComplentarias = New OrdernarDatosComplentarias()
        'Fuente de la impresion
        Dim FuenteImpresaEncabezado = New Font("Tahoma", 7, FontStyle.Regular)
        'Se dibuja uin rectangulo parte derecha
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        Dim contadorDatos As Integer = 0
        ''Crear texto del EncabezaDO
        'gfx.DrawString("Còdigo  Cantidad    UM                 Descripciòn                      P. Unit.    Lista   Dsctos     Total", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 60, New StringFormat())
        ''crear rectangulo de la cabecera
        'gfx.DrawRectangle(blackPen, 5, 57, 200, 10)
        'crear la fila codigo
        gfx.DrawRectangle(blackPen, 5, 229, 133, 10)
        'crear la fila cantidad
        gfx.DrawRectangle(blackPen, 5, 240, 133, 30)
        gfx.DrawLine(blackPen, 5, 250, 138, 250)
        'gfx.DrawLine(blackPen, 70, 264, 95, 264)
        gfx.DrawLine(blackPen, 105, 264, 135, 264)
        gfx.DrawLine(blackPen, 90, 240, 90, 270)
        'crear la fila cantidad
        'gfx.DrawRectangle(blackPen, 5, 252, 133, 18)

        For Each Elemento As String In LineasDatosComplementaria
            CadenaPorEscribirEnLinea = ordTot.ObtenerTotalNombre(Elemento)
            Dim conver As String
            Dim numeroConverson As Decimal = Convert.ToDecimal(CadenaPorEscribirEnLinea)
            conver = Conversion.Enletras(numeroConverson)
            gfx.DrawString(conver & " SOLES", FuenteImpresaEncabezado, ColorDeLaFuente, 8, contadorDatos + 233, New StringFormat())
        Next

        CadenaPorEscribirEnLinea = ""
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 20, contadorDatos + 222, New StringFormat())

        CadenaPorEscribirEnLinea = "RECIBI CONFORME"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 105, contadorDatos + 245, New StringFormat())

        'CadenaPorEscribirEnLinea = "Nombre"
        'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 80, contadorDatos + 265, New StringFormat())

        CadenaPorEscribirEnLinea = "Firma"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 116, contadorDatos + 265, New StringFormat())

        'If (tipoComprobante = "2") Then
        CadenaPorEscribirEnLinea = "R.S. N°0340050010982/SUNAT"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 8, contadorDatos + 243, New StringFormat())

        CadenaPorEscribirEnLinea = "Representaciòn Impresa del Comprobante"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 8, contadorDatos + 253, New StringFormat())

        CadenaPorEscribirEnLinea = "Consulta su comprobante en www.softpack.com.pe"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 8, contadorDatos + 265, New StringFormat())

        'CadenaPorEscribirEnLinea = "Consulta a partir del 8vo. dìa de su emision"
        'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 90, contadorDatos + 270, New StringFormat())

        'End If
        CadenaPorEscribirEnLinea = "Pag." & Paginacion
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 8, contadorDatos + 280, New StringFormat())

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
        'se crea un rectangulo para manipular texto dentro del rectangulo

        'Fuente de la impresion
        Dim FuenteImpresaEncabezado = New Font("Tahoma", 10, FontStyle.Italic)

        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarEmpresa = New OrdernarEmpresa()
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        'stringformat para alinear el text
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Center



        For Each Elemento As String In LineasDatosEmpresa
            Dim NumTotalNombre = ordTot.ObtenerTotalNombre(Elemento).Count
            If (NumTotalNombre >= 30 And NumTotalNombre <= 60) Then
                Dim R2 As New RectangleF(1, lineaEspacio, 60, 12)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                lineaEspacio += 1
            ElseIf (NumTotalNombre > 60) Then
                Dim R2 As New RectangleF(1, lineaEspacio, 60, 17)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                lineaEspacio += 2
            Else
                Dim R2 As New RectangleF(1, lineaEspacio, 60, 5)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                'lineaEspacio += 5
            End If
        Next

    End Sub

    '*****************************************************************************
    '****************************** NOMBRE importes TOTALES ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasDatosComprobante As ArrayList = New ArrayList()

    'Linea para capturar el ruc y numeroComprobante de la Factura
    Public Sub AnadirLineaComprobante(ByVal nombreComprobante As String)

        Dim ordTot As OrdernarEmpresa = New OrdernarEmpresa()
        LineasDatosComprobante.Add(ordTot.GenerarTotal(nombreComprobante))
    End Sub

    'Dibuja `parte de la derecha de la factura
    Private Sub DibujaDatosComprobante()
        'se crea un rectangulo para manipular texto dentro del rectangulo

        'Fuente de la impresion
        Dim FuenteImpresaEncabezado = New Font("Tahoma", 9, FontStyle.Regular)

        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarEmpresa = New OrdernarEmpresa()
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        'stringformat para alinear el text
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Center

        lineaEspacio += 2

        For Each Elemento As String In LineasDatosComprobante
            Dim NumTotalNombre = ordTot.ObtenerTotalNombre(Elemento).Count
            If (NumTotalNombre >= 30 And NumTotalNombre <= 60) Then
                Dim R2 As New RectangleF(1, lineaEspacio, 60, 12)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                lineaEspacio += 5
            ElseIf (NumTotalNombre > 60) Then
                Dim R2 As New RectangleF(1, lineaEspacio, 60, 17)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                lineaEspacio += 5
            Else
                Dim R2 As New RectangleF(1, lineaEspacio, 60, 5)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                lineaEspacio += 5
            End If
        Next

    End Sub


    '*****************************************************************************
    '****************************** NOMBRE importes TOTALES ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasDatosNombrePropietario As ArrayList = New ArrayList()

    'Linea para capturar el ruc y numeroComprobante de la Factura
    Public Sub AnadirLineaNombrePropietario(ByVal nombrePropietario As String)

        Dim ordTot As OrdernarPropietario = New OrdernarPropietario()
        LineasDatosNombrePropietario.Add(ordTot.GenerarTotal(nombrePropietario))
    End Sub

    'Dibuja `parte de la derecha de la factura
    Private Sub DibujaDatosNombrePropietario()
        'se crea un rectangulo para manipular texto dentro del rectangulo

        'Fuente de la impresion
        Dim FuenteImpresaEncabezado = New Font("Tahoma", 7, FontStyle.Regular)

        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarPropietario = New OrdernarPropietario()
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        'stringformat para alinear el text
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Center


        'MUESTRA QUE ESPACIO SE DARA AL PROPIETARIO PARA QUE EL ESPACIO NO SEA MUY GRANDE
        If (lineaEspacio = 22 Or lineaEspacio = 0) Then
            lineaEspacio += 5
        ElseIf (lineaEspacio = 23 Or lineaEspacio = 1) Then
            lineaEspacio += 9
        ElseIf lineaEspacio = 40 Then
            lineaEspacio += 5
        Else
            lineaEspacio += 13
        End If

        For Each Elemento As String In LineasDatosNombrePropietario

            Dim NumNombrePropietario = (ordTot.ObtenerTotalPropietario(Elemento)).Count
            If (NumNombrePropietario >= 35 And NumNombrePropietario <= 65) Then
                Dim R2 As New RectangleF(1, lineaEspacio, 60, 6)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalPropietario(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                lineaEspacio += 1
            ElseIf (NumNombrePropietario > 65) Then
                Dim R2 As New RectangleF(1, lineaEspacio, 60, 10)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalPropietario(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                lineaEspacio += 2
            Else
                Dim R2 As New RectangleF(1, lineaEspacio, 60, 3)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalPropietario(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                'lineaEspacio += 5
            End If
        Next
        'For Each Elemento As String In LineasDatosNombrePropietario

        '    Dim NumNombrePropietario = (ordTot.ObtenerTotalPropietario(Elemento)).Count
        '    If (NumNombrePropietario > 60) Then
        '        Dim R2 As New RectangleF(3, lineaEspacio, 60, 30)
        '        CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalPropietario(Elemento))
        '        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
        '        'lineaEspacio += 5
        '    Else
        '        Dim R2 As New RectangleF(3, lineaEspacio, 60, 10)
        '        CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalPropietario(Elemento))
        '        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
        '        'lineaEspacio += 5
        '    End If
        'Next

    End Sub

    '*****************************************************************************
    '****************************** NOMBRE importes TOTALES ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasDatosNombrePublicidad As ArrayList = New ArrayList()

    'Linea para capturar el ruc y numeroComprobante de la Factura
    Public Sub AnadirLineaNombrePublidad(ByVal nombrePublicidad As String)

        Dim ordTot As OrdernarPublicidad = New OrdernarPublicidad()
        LineasDatosNombrePublicidad.Add(ordTot.GenerarTotal(nombrePublicidad))
    End Sub

    'Dibuja `parte de la derecha de la factura
    Private Sub DibujaDatosNombrePublicidad()
        'se crea un rectangulo para manipular texto dentro del rectangulo

        'Fuente de la impresion
        Dim FuenteImpresaEncabezado = New Font("Garamond", 7, FontStyle.Regular)

        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarPublicidad = New OrdernarPublicidad()
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        'stringformat para alinear el text
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Center

        'MUESTRA QUE ESPACIO SE DARA AL PROPIETARIO PARA QUE EL ESPACIO NO SEA MUY GRANDE
        If (lineaEspacio = 31 Or lineaEspacio = 5 Or lineaEspacio = 10) Then
            lineaEspacio += 3
        ElseIf (lineaEspacio = 32 Or lineaEspacio = 6 Or lineaEspacio = 11) Then
            lineaEspacio += 6
        ElseIf lineaEspacio = 22 Then
            lineaEspacio += 5
        ElseIf lineaEspacio = 23 Then
            lineaEspacio += 12
        ElseIf lineaEspacio = 1 Then
            lineaEspacio += 13
        Else
            lineaEspacio += 7
        End If

        For Each Elemento As String In LineasDatosNombrePublicidad

            Dim NumNombrePublicidad = (ordTot.ObtenerPublicidad(Elemento)).Count
            If (NumNombrePublicidad >= 41 And NumNombrePublicidad <= 65) Then
                Dim R2 As New RectangleF(1, lineaEspacio, 60, 6)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerPublicidad(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                lineaEspacio += 1
            ElseIf (NumNombrePublicidad > 65) Then
                Dim R2 As New RectangleF(1, lineaEspacio, 60, 10)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerPublicidad(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                lineaEspacio += 4
            Else
                Dim R2 As New RectangleF(1, lineaEspacio, 60, 3)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerPublicidad(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)

            End If

        Next

    End Sub

    '*****************************************************************************
    '****************************** NOMBRE importes TOTALES ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasDatosDescripcionTotal As ArrayList = New ArrayList()

    'Linea para capturar el ruc y numeroComprobante de la Factura
    Public Sub AnadirLineasDatosDescripcionTotal(ByVal nombreComprobante As String)

        Dim ordTot As OrdernarEmpresa = New OrdernarEmpresa()
        LineasDatosDescripcionTotal.Add(ordTot.GenerarTotal(nombreComprobante))
    End Sub

    'Dibuja `parte de la derecha de la factura
    Private Sub DibujaLineasDatosDescripcionTotal()
        'se crea un rectangulo para manipular texto dentro del rectangulo

        'Fuente de la impresion
        Dim FuenteImpresaEncabezado = New Font("Tahoma", 8, FontStyle.Regular)

        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarEmpresa = New OrdernarEmpresa()
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        'stringformat para alinear el text
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Near

        lineaEspacio += 5

        For Each Elemento As String In LineasDatosDescripcionTotal
            Dim NumTotalNombre = ordTot.ObtenerTotalNombre(Elemento).Count

            Dim conver As String
            Dim numeroConverson As Decimal = Convert.ToDecimal(ordTot.ObtenerTotalNombre(Elemento))
            conver = Conversion.Enletras(numeroConverson)

            If (NumTotalNombre >= 30 And NumTotalNombre <= 60) Then
                Dim R2 As New RectangleF(1, lineaEspacio, 60, 12)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                gfx.DrawString("SON " & conver & " SOLES", FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                lineaEspacio += 5

            ElseIf (NumTotalNombre > 60) Then
                Dim R2 As New RectangleF(1, lineaEspacio, 60, 17)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                gfx.DrawString("SON " & conver & " SOLES", FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                lineaEspacio += 5
            Else
                Dim R2 As New RectangleF(1, lineaEspacio, 60, 7)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                gfx.DrawString("SON " & conver & " SOLES", FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                lineaEspacio += 5
            End If
        Next

    End Sub


    '*****************************************************************************
    '****************************** NOMBRE importes TOTALES ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasDatosFinales As ArrayList = New ArrayList()

    'Linea para capturar el ruc y numeroComprobante de la Factura
    Public Sub AnadirLineasDatosFinales(ByVal nombreComprobante As String)

        Dim ordTot As OrdernarEmpresa = New OrdernarEmpresa()
        LineasDatosFinales.Add(ordTot.GenerarTotal(nombreComprobante))
    End Sub

    'Dibuja `parte de la derecha de la factura
    Private Sub DibujaLineasDatosFinales()
        'se crea un rectangulo para manipular texto dentro del rectangulo

        'Fuente de la impresion
        Dim FuenteImpresaEncabezado = New Font("Tahoma", 7, FontStyle.Regular)

        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarEmpresa = New OrdernarEmpresa()
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        'stringformat para alinear el text
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Near



        For Each Elemento As String In LineasDatosFinales

            Dim R2 As New RectangleF(1, lineaEspacio, 65, 5)
            CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
            lineaEspacio += 3
        Next

    End Sub



    '*****************************************************************************
    '****************************** NOMBRE importes TOTALES ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasDatosComplementario As ArrayList = New ArrayList()

    'Linea para capturar el ruc y numeroComprobante de la Factura
    Public Sub AnadirLineaDatos(ByVal nombreVendedor As String, DescripcionComprobante As String, correoEmpresa As String)

        Dim ordTot As OrdernarVendedor = New OrdernarVendedor()
        LineasDatosComplementario.Add(ordTot.GenerarTotal(nombreVendedor, DescripcionComprobante, correoEmpresa))
    End Sub

    'Dibuja `parte de la derecha de la factura
    Private Sub DibujaDatosComplementarios()
        'se crea un rectangulo para manipular texto dentro del rectangulo

        'Fuente de la impresion
        Dim FuenteImpresaEncabezado = New Font("Tahoma", 7, FontStyle.Regular)

        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarVendedor = New OrdernarVendedor()
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        'stringformat para alinear el text
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Center

        'MUESTRA QUE ESPACIO SE DARA AL PROPIETARIO PARA QUE EL ESPACIO NO SEA MUY GRANDE
        lineaEspacio += 20

        If (tipoComprobante = "2") Then

            For Each Elemento As String In LineasDatosComplementario

                Dim R2 As New RectangleF(1, lineaEspacio, 60, 3)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalDescripción(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)

                lineaEspacio += 3
                Dim R3 As New RectangleF(1, lineaEspacio, 60, 3)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalCorreo(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R3, StringFormat)
                lineaEspacio += 3

                Dim R4 As New RectangleF(1, lineaEspacio, 60, 3)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalVendedor(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R4, StringFormat)

            Next
        End If
        lineaEspacio += 3
        Dim R7 As New RectangleF(1, lineaEspacio, 65, +5)
        Dim StringFormatGeneral As New StringFormat
        StringFormatGeneral.Alignment = StringAlignment.Center
        gfx.DrawString("GRACIAS POR SU COMPRA", FuenteImpresaEncabezado, Brushes.Black, R7, StringFormatGeneral)

    End Sub

End Class