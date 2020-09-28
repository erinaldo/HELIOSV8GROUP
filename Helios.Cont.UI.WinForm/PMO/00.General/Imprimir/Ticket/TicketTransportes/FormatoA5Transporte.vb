Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Net.Mail
Imports ZXing

Public Class FormatoA5Transporte
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
    Public NombreDeLaFuente As String = "Draft"
    Public TamanoDeLaFuente As Integer = 7

    Public FuenteImpresa As Font
    Public ColorDeLaFuente As SolidBrush = New SolidBrush(Color.Black)

    Public gfx As Graphics

    Public CadenaPorEscribirEnLinea As String = ""
    Private WithEvents DocumentoAImprimir As New PrintDocument
    Public lineaEspacio As Integer = 76
    Dim listaPaginas As New List(Of ArrayList)
    Dim ListaArray As New ArrayList
    Public lineaEspacioPagina As Integer = 5
    Public tipoImagen As Boolean
    Public tipoEncabezado As Boolean
    Public tipoPublicidad As Boolean
    Public tipoLogo As String
    Public HORAsALIDA As String
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
                'LineasElementosFacturaPorPaginacion.Clear()
                DrawImage()
                'DrawHeader()

                contador = 0
                'CARACTERURES MAXIMOS DE LA HOJA
                CaracteresMaximos = 80
                CaracteresMaximosGuion = 80
                CaracteresMaximosDescripcion = 80
                'tipoComprobante = String.Empty
                imageHeight = 0

                'DibujaEspacio()
                'DibujaDatosEmpresa()
                'DibujaDatosNombrePropietario()

                imageHeight = 0
                DrawImage()

                'Select Case tipoLogo
                '    Case "CR"
                '        Select Case tipoEncabezado
                '            Case True
                '                lineaEspacioPagina = 20
                '                DibujaDatosEmpresa()
                '                DibujaDatosNombrePropietario()
                '                count = 28
                '            Case False
                '                lineaEspacioPagina = 20
                '                DibujaDatosEmpresa()
                '                count = 28
                '        End Select

                '        Select Case tipoPublicidad
                '            Case True
                '                DibujaDatosNombrePublicidad()
                '        End Select
                '    Case "IZ"
                '        Select Case tipoEncabezado
                '            Case True
                '                lineaEspacioPagina = 5
                '                DibujaDatosEmpresa()
                '                DibujaDatosNombrePropietario()
                '                count = 28
                '            Case False
                '                lineaEspacioPagina = 5
                '                DibujaDatosEmpresa()
                '                count = 28
                '        End Select

                '        Select Case tipoPublicidad
                '            Case True
                '                DibujaDatosNombrePublicidad()
                '        End Select
                '    Case Else
                '        Select Case tipoEncabezado
                '            Case True
                '                DibujaDatosEmpresa()
                '                DibujaDatosNombrePropietario()
                '                count = 28
                '            Case False
                '                DibujaDatosEmpresa()
                '                count = 23
                '        End Select

                '        Select Case tipoPublicidad
                '            Case True
                '                DibujaDatosNombrePublicidad()
                '        End Select
                'End Select

                'DibujaLaCabecera()
                DibujaLaCabeceraDerecha()
                DibujaLaSubCabeceraIzquierda()

                DottedLineGuion()
                DibujaDatosGenerales(1)

                For Each i In listaPaginas
                    Select Case listaArrays
                        Case 1
                            DibujaElementosFactura(i)
                            DibujaTotalFacturaFinal()
                            DrawImageQR()
                            e.HasMorePages = False
                            Exit Sub
                        Case Else
                            DibujaElementosFactura(i)
                            DibujaTotalFactura()
                            DrawImageQR()
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

    Public Property MaximoCaracter() As Integer
        Get
            Return CaracteresMaximos
        End Get
        Set(ByVal value As Integer)
            If (value <> CaracteresMaximos) Then CaracteresMaximos = value
        End Set
    End Property



    Public Property MaximoCaracterDescripcion() As Integer
        Get
            Return CaracteresMaximosDescripcion
        End Get
        Set(ByVal value As Integer)
            If (value <> CaracteresMaximosDescripcion) Then CaracteresMaximosDescripcion = value
        End Set
    End Property

    Public Property MaximoCaracterCaracter() As Integer
        Get
            Return CaracteresMaximosGuion
        End Get
        Set(ByVal value As Integer)
            If (value <> CaracteresMaximosGuion) Then CaracteresMaximosGuion = value
        End Set
    End Property

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

    Private Function AlineaTextoaCentro(ByVal Izquierda As Integer) As String
        Dim espacios As String = ""
        Dim spaces As Integer = (MaximoCaracter - 80) - Izquierda
        Dim x As Integer
        For x = 0 To spaces
            espacios += " "
        Next
        Return espacios
    End Function

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



    Private Function DottedLine() As String

        Dim dotted As String = ""
        Dim x As Integer
        For x = 0 To MaximoCaracter()
            dotted += "="
        Next
        Return dotted
    End Function

    Public Function DottedLineGuion() As String

        Dim dotted As String = ""
        Dim x As Integer
        For x = 0 To MaximoCaracter
            dotted += "-"
        Next
        Return dotted
    End Function

    Private Function Renglon() As Double
        Return MargenSuperior + (contador * FuenteImpresa.GetHeight(gfx) + imageHeight)
    End Function

    Private Function RenglonGeneral() As Double
        Return MargenSuperior + (contador * FuenteImpresa.GetHeight(gfx) + imageHeight)
    End Function

    Private Sub DrawImage()
        Try

            If (Not IsNothing(headerImagep.Width)) Then
                If (headerImagep.Width <> 0) Then
                    Dim destRect As New Rectangle(15, 5, 110, 39)

                    gfx.DrawImage(HeaderImage, destRect)
                    Dim height As Double = (HeaderImage.Height / 200)
                    imageHeight = CInt(Math.Round(height) + 3)
                    'lineaEspacio = lineaEspacio + 22
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrawImageQR()
        Try

            If (Not IsNothing(headerImageQR.Width)) Then
                If (headerImageQR.Width <> 0) Then
                    Dim destRect As New Rectangle(8, 242, 28, 28)

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
        Dim FuenteImpresaEncabezadoIzquierda = New Font("Draft", 7, FontStyle.Regular)
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        'stringformat para alinear el text
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Near

        For Each Cabecera As String In LineasDeLaCabeza

            'If (lineaEspacioPagina > 31) Then
            '    Dim R2 As New RectangleF(5, count + 10, 100, 40)
            '    CadenaPorEscribirEnLinea = Cabecera
            '    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoIzquierda, Brushes.Black, R2, StringFormat)
            '    count += 6
            '    Exit For
            'Else
            Dim R2 As New RectangleF(5, count, 100, 40)
            CadenaPorEscribirEnLinea = Cabecera
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoIzquierda, Brushes.Black, R2, StringFormat)
            count += 6
            'End If

            'contador += 1
            'End If
        Next Cabecera
        'DibujaEspacio()
    End Sub

    Private Sub DibujaLaSubCabecera()

        For Each SubCabecera As String In LineasDeLaSubCabeza

            If (SubCabecera.Length > MaximoCaracter()) Then

                Dim CaracterActual As Integer = 0
                Dim LongitudSubcabecera As Integer = SubCabecera.Length

                While (LongitudSubcabecera > MaximoCaracter())

                    CadenaPorEscribirEnLinea = SubCabecera
                    gfx.DrawString(CadenaPorEscribirEnLinea.Substring(CaracterActual, MaximoCaracter), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

                    contador += 1
                    CaracterActual += MaximoCaracter()
                    LongitudSubcabecera -= MaximoCaracter()
                End While
                CadenaPorEscribirEnLinea = SubCabecera
                gfx.DrawString(CadenaPorEscribirEnLinea.Substring(CaracterActual, CadenaPorEscribirEnLinea.Length - CaracterActual), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
                contador += 1

            Else

                CadenaPorEscribirEnLinea = SubCabecera

                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

                contador += 1

                'CadenaPorEscribirEnLinea = DottedLine()

                'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

                'contador += 1
            End If
        Next SubCabecera
        'DibujaEspacio()
    End Sub

    Private Sub DibujaCaractares()

        For Each SubCabecera As String In LineasDeCaracteres

            If (SubCabecera.Length > MaximoCaracterCaracter()) Then

                Dim CaracterActual As Integer = 0
                Dim LongitudSubcabecera As Integer = SubCabecera.Length

                While (LongitudSubcabecera > MaximoCaracterCaracter())

                    CadenaPorEscribirEnLinea = SubCabecera
                    gfx.DrawString(CadenaPorEscribirEnLinea.Substring(CaracterActual, MaximoCaracterCaracter), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

                    contador += 1
                    CaracterActual += MaximoCaracterCaracter()
                    LongitudSubcabecera -= MaximoCaracterCaracter()
                End While
                CadenaPorEscribirEnLinea = SubCabecera
                gfx.DrawString(CadenaPorEscribirEnLinea.Substring(CaracterActual, CadenaPorEscribirEnLinea.Length - CaracterActual), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
                contador += 1

            Else

                'CadenaPorEscribirEnLinea = SubCabecera

                'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

                'contador += 1

                CadenaPorEscribirEnLinea = DottedLineGuion()

                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

                contador += 1
            End If
        Next SubCabecera
        'DibujaEspacio()
    End Sub

    Private Sub DibujaElementos()

        Dim OrdenElemento As OrdenarElementos = New OrdenarElementos()
        Dim OrdenNombreElemento As OrdenarElementos = New OrdenarElementos()

        'DIBUJA LOS ELEMENTOS DE LA CABECERA DE LOS DETALLES
        gfx.DrawString("CANT  |ARTICULO   |UM  |PRECIO   |IMPORTE", FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

        contador += 1

        CadenaPorEscribirEnLinea = DottedLineGuion()
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
        contador += 1

        'DibujaEspacio()

        For Each Elemento As String In Elementos

            CadenaPorEscribirEnLinea = OrdenElemento.ObtenerCantidadDeElementos(Elemento)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())



            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

            Dim Nombre As String = OrdenElemento.ObtenerNombreElemento(Elemento)

            ' espacio de los detalles de los articulos - ancho de la izquierda
            MargenIzquierdo = 2
            'If (Nombre.Length > MaximoCaracterDescripcion) Then

            '        Dim CaracterActual As Integer = 0
            '        Dim LongitudElemento As Integer = Nombre.Length

            'While (LongitudElemento > MaximoCaracterDescripcion)

            '    CadenaPorEscribirEnLinea = OrdenElemento.ObtenerNombreElemento(Elemento)
            '    gfx.DrawString("         " + CadenaPorEscribirEnLinea.Substring(CaracterActual, MaximoCaracterDescripcion), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

            '    contador += 1
            '    CaracterActual += MaximoCaracterDescripcion
            '    LongitudElemento -= MaximoCaracterDescripcion
            'End While

            'CadenaPorEscribirEnLinea = OrdenElemento.ObtenerNombreElemento(Elemento)
            '    gfx.DrawString("         " + CadenaPorEscribirEnLinea.Substring(CaracterActual, CadenaPorEscribirEnLinea.Length - CaracterActual), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon() + 10, New StringFormat())
            '    contador += 1

            'Else
            'For Each x As String In Nombre_Elementos
            Dim nombreArticlo As String
            Dim enviarNombre As String
            nombreArticlo = OrdenElemento.ObtenerNombreElemento(Elemento)

            If (nombreArticlo.Length > 30) Then
                enviarNombre = nombreArticlo.Substring(0, 30)
            Else
                enviarNombre = nombreArticlo
            End If

            gfx.DrawString("      " + enviarNombre, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
            contador += 1
            '************************************************************************
            'Next x
            'enviar los noombre de articulo del ticket


            CadenaPorEscribirEnLinea = OrdenElemento.ObtenerUMElemento(Elemento)
            gfx.DrawString("                  " + OrdenElemento.ObtenerUMElemento(Elemento), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

            CadenaPorEscribirEnLinea = OrdenElemento.ObtenerprecioUnitElemento(Elemento)
            'CadenaPorEscribirEnLinea = AlineaTextoaLaDerechaV2(CadenaPorEscribirEnLinea.Length + 5) + CadenaPorEscribirEnLinea
            gfx.DrawString("                        " + CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

            'CadenaPorEscribirEnLinea = OrdenElemento.ObtenerPrecioElemento(Elemento)
            'CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
            'gfx.DrawString("                                                                             " + CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

            CadenaPorEscribirEnLinea = OrdenElemento.ObtenerPrecioElemento(Elemento)
            CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

            contador += 1
            'End If
        Next Elemento

        MargenIzquierdo = 2
        'DibujaEspacio()
        CadenaPorEscribirEnLinea = DottedLineGuion()

        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
        contador += 1
        'DibujaEspacio()
    End Sub

    Private Sub DibujaTotales()

        Dim ordTot As OrdernarTotal = New OrdernarTotal()

        For Each total As String In Totales

            CadenaPorEscribirEnLinea = ordTot.ObtenerTotalCantidad(total)
            CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
            MargenIzquierdo = 0

            CadenaPorEscribirEnLinea = "         " + ordTot.ObtenerTotalNombre(total)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
            contador += 1
        Next total
        MargenIzquierdo = 0
        DibujaEspacio()
        'DibujaEspacio()
    End Sub

    Private Sub DibujarPieDePagina()

        For Each PieDePagina As String In LineasDelPie

            If (PieDePagina.Length > MaximoCaracter()) Then

                Dim currentChar As Integer = 0
                Dim LongitudPieDePagina As Integer = PieDePagina.Length

                While (LongitudPieDePagina > MaximoCaracter())

                    CadenaPorEscribirEnLinea = PieDePagina
                    gfx.DrawString(CadenaPorEscribirEnLinea.Substring(currentChar, MaximoCaracter), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

                    contador += 1
                    currentChar += MaximoCaracter()
                    LongitudPieDePagina -= MaximoCaracter()
                End While
                CadenaPorEscribirEnLinea = PieDePagina
                gfx.DrawString(CadenaPorEscribirEnLinea.Substring(currentChar, CadenaPorEscribirEnLinea.Length - currentChar), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
                contador += 1

            Else

                Dim espacios As String = ""
                'sacamos la cantidad de espacios libres y el resultado lo dividimos entre dos
                Dim centrar As Integer = ((CaracteresMaximos) - PieDePagina.Length) / 2
                'Obtenemos la longitud del texto restante
                For i As Integer = 0 To centrar - 1
                    'Agrega espacios para centrar
                    espacios += " "
                Next

                'agregamos el fragmento restante, agregamos antes del texto los espacios

                'LineasDeLaCabeza.Add(espacios & PieDePagina)

                CadenaPorEscribirEnLinea = espacios & PieDePagina
                'CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

                contador += 1
            End If
        Next PieDePagina
        MargenIzquierdo = 10
        DibujaEspacio()
    End Sub

    Private Sub DibujaEspacio()
        CadenaPorEscribirEnLinea = "   "
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
        contador += 1
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

    Public Sub ImprimeTicket(ByVal impresora As String)

        FuenteImpresa = New Font(NombreLetra, TamanoLetra, FontStyle.Regular)
        'Dim pr As New PrintDocument 
        DocumentoAImprimir.PrinterSettings.PrinterName = impresora
        'pr.PrinterSettings.printpa() 
        ' pr.PrintPage += New 
        ' PrintPageEventHandler(pr_PrintPage) 
        lineasTotal()

        DocumentoAImprimir.Print()

    End Sub
    Dim lineasConteo As Decimal = 0.0
    Dim lineasTotales As Integer = 0
    Dim listaArrays As Integer = 0
    Dim numeracion As Integer = 0
    Private Sub lineasTotal()
        Dim total As Integer
        'For Each item In LineasElementosFactura
        '    Dim ordTot As OrdenarElementoFactura = New OrdenarElementoFactura()
        '    Dim nombreArticlo As String
        '    'Dim enviarNombre As String
        '    nombreArticlo = ordTot.ObtenerDescripcion(item)

        '    'Colocar la cantidad a la derecha.
        '    Dim StringFormatDescrip As New StringFormat
        '    StringFormatDescrip.Alignment = StringAlignment.Near

        '    If (nombreArticlo.Length > 55) Then
        '        total = nombreArticlo.Length / 55
        '        lineaEspacio += (3 * total)
        '    End If
        '    lineaEspacio += 5
        'Next


        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdenarElementoFactura = New OrdenarElementoFactura()
        'Fuente de la impresion
        Dim FuenteImpresaDetalle = New Font("Draft", 8, FontStyle.Regular)
        Dim FuenteImpresaEncabezado = New Font("Draft", 8, FontStyle.Regular)
        'Se dibuja uin rectangulo parte derecha
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        Dim elemento As String = "", espacios As String = ""
        Dim nroEspacios As Integer = 0
        Dim PrecioVenta As String = String.Empty
        Dim ValidarTotal As String = String.Empty
        Dim Cantidad As String = String.Empty
        Dim Codigo As String = String.Empty

        Dim um As String = String.Empty
        Dim descripcion As String = String.Empty
        Dim contadorPagina As Integer = 0

        Dim CONTEO As Integer = 0

        For Each Item As String In LineasElementosFactura
            CONTEO = Item.Count
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R0 As New RectangleF(5, lineaEspacio, 10, 30)
            'conteo de item
            numeracion += 1
            'Colocar la cantidad a la derecha.
            Dim StringFormat As New StringFormat
            StringFormat.Alignment = StringAlignment.Far

            CadenaPorEscribirEnLinea = numeracion
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R0, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R1 As New RectangleF(15, lineaEspacio, 20, 30)
            Codigo = 0.0
            Codigo = ordTot.OptenerCodigo(Item)

            'Colocar la cantidad a la derecha.
            Dim StringFormatCodigo As New StringFormat
            StringFormatCodigo.Alignment = StringAlignment.Far

            CadenaPorEscribirEnLinea = Codigo
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R1, StringFormatCodigo)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R4 As New RectangleF(126, lineaEspacio, 10, 30)
            'Colocar la cantidad a la derecha.
            Dim StringFormatUM As New StringFormat
            StringFormatUM.Alignment = StringAlignment.Near

            CadenaPorEscribirEnLinea = ordTot.ObtenerUM(Item)
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R4, StringFormatUM)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R2 As New RectangleF(135, lineaEspacio, 20, 30)

            Cantidad = 0.0
            Cantidad = ordTot.ObtenerCantidad(Item)

            'Colocar la cantidad a la derecha.
            Dim StringFormatCantidad As New StringFormat
            StringFormatCantidad.Alignment = StringAlignment.Far

            CadenaPorEscribirEnLinea = Cantidad
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R2, StringFormatCantidad)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R5 As New RectangleF(155, lineaEspacio, 24, 30)
            'Colocar la cantidad a la derecha.
            Dim StringFormatPrecioUnit As New StringFormat
            StringFormatPrecioUnit.Alignment = StringAlignment.Far

            PrecioVenta = 0.0
            PrecioVenta = FormatNumber(ordTot.ObtenerPrecioVenta(Item), 2)

            CadenaPorEscribirEnLinea = PrecioVenta
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R5, StringFormatPrecioUnit)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R6 As New RectangleF(179, lineaEspacio, 25, 30)
            'Colocar la cantidad a la derecha.
            Dim StringFormatTotal As New StringFormat
            StringFormatTotal.Alignment = StringAlignment.Far

            ValidarTotal = 0.0
            elemento = String.Empty
            ValidarTotal = FormatNumber(ordTot.ObtenerVentaTotal(Item), 2)

            CadenaPorEscribirEnLinea = ValidarTotal '.TrimStart("0")
            'CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R6, StringFormatTotal)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R3 As New RectangleF(36, lineaEspacio, 90, 30)
            Dim nombreArticlo As String
            'Dim enviarNombre As String
            nombreArticlo = ordTot.ObtenerDescripcion(Item)

            'Colocar la cantidad a la derecha.
            Dim StringFormatDescrip As New StringFormat
            StringFormatDescrip.Alignment = StringAlignment.Near

            If (nombreArticlo.Length > 55) Then
                total = nombreArticlo.Length / 55

                CadenaPorEscribirEnLinea = nombreArticlo
                'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R3, StringFormatDescrip)
                lineaEspacio += (3 * total)
            Else
                CadenaPorEscribirEnLinea = nombreArticlo
                'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R3, StringFormatDescrip)
            End If
            lineaEspacio += 5

            AnadirLineaElementosFacturaXPagina(numeracion, Codigo, ordTot.ObtenerDescripcion(Item), ordTot.ObtenerCantidad(Item), ordTot.ObtenerUM(Item), FormatNumber(ordTot.ObtenerPrecioVenta(Item), 2), CDec(FormatNumber(ordTot.ObtenerVentaTotal(Item), 2)))
            If (lineaEspacio >= 105) Then
                lineaEspacio = 76
                listaPaginas.Add(LineasElementosFacturaPorPaginacion)
                LineasElementosFacturaPorPaginacion = New ArrayList
                'LineasElementosFacturaPorPaginacion.Clear()
            End If


        Next Item

        listaPaginas.Add(LineasElementosFacturaPorPaginacion)
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
        Dim FuenteImpresaEncabezado = New Font("Draft", 16, FontStyle.Regular)

        'se dibuja un rectangulo
        gfx.DrawRectangle(blackPen, 132, 5, 70, 35)

        'Se imprime los datos dentro del rectangulo
        For Each Cabecera As String In LineasDeEncabezadoDerecha
            'se captura NumeroRuc del Array
            Dim R1 As New RectangleF(132, 8, 70, 40)
            CadenaPorEscribirEnLinea = ordTot.ObtenerNumeroRuc(Cabecera)
            gfx.DrawString("R.U.C. " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R1, StringFormat)

            Dim R2 As New RectangleF(130, 20, 70, 40)
            CadenaPorEscribirEnLinea = ordTot.ObtenerTipoComprobante(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)

            Dim R3 As New RectangleF(130, 32, 70, 40)
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

        'stringformat para alinear el text
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Near
        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarSubEncabezadoDatosGenerales = New OrdernarSubEncabezadoDatosGenerales()
        'Fuente de la impresion
        Dim FuenteImpresaEncabezado = New Font("Draft", 10, FontStyle.Regular)
        'Se dibuja uin rectangulo parte derecha
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        gfx.DrawRectangle(blackPen, 5, 44, 197, 25)

        'Se imprime los datos dentro del rectangulo
        For Each Cabecera As String In LineasDeEncabezadoIzquierda
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R2 As New RectangleF(5, 44, 197, 25)
            'se captura NumeroRuc del Array
            CadenaPorEscribirEnLinea = ordTot.OrdernarfechaEmision(Cabecera)
            '125 =  direccion hacia la derechja de la hoja, Renglon() - 17 = parte de arriba de la hoja
            gfx.DrawString("FECHA                  : " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
            'gfx.DrawString("FECHA                 : " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, Brushes.Black, R2, StringFormat)

            Dim NuevoCaracter As String
            'Dim MaximoCaracter As Integer
            'Dim NuevoMaxCaracter As Integer
            'Dim NuevoCaracter As String
            NuevoCaracter = ordTot.ObtenerNombre(Cabecera)
            'MaximoCaracter = NuevoCaracter.Length
            'If (MaximoCaracter > 50) Then
            '    NuevoMaxCaracter = MaximoCaracter / 2
            '    CadenaPorEscribirEnLinea = NuevoCaracter.ToString.Substring(0, NuevoMaxCaracter)
            '    gfx.DrawString("CLIENTE              : " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 6, 30, New StringFormat())
            '    contador += 1
            '    CadenaPorEscribirEnLinea = NuevoCaracter.ToString.Substring(NuevoMaxCaracter + 1)
            '    gfx.DrawString("                           " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 6, 34, New StringFormat())

            'Else
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R3 As New RectangleF(5, 48, 197, 25)
            CadenaPorEscribirEnLinea = NuevoCaracter
            gfx.DrawString("PASAJEROS         : " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R3, StringFormat)
            '    contador += 1
            '    CadenaPorEscribirEnLinea = ""
            '    gfx.DrawString("                           " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 6, 34, New StringFormat())

            'End If
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R4 As New RectangleF(5, 52, 197, 25)
            'documkentop
            CadenaPorEscribirEnLinea = ordTot.ObtenerdocIdentidad(Cabecera)
            gfx.DrawString("DNI.                        : " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R4, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R5 As New RectangleF(5, 56, 197, 25)
            'direccioon
            NuevoCaracter = ordTot.Obtenerdireccion(Cabecera)
            'MaximoCaracter = NuevoCaracter.Length
            'If (MaximoCaracter > 50) Then
            '    NuevoMaxCaracter = MaximoCaracter / 2
            '    CadenaPorEscribirEnLinea = NuevoCaracter.ToString.Substring(0, NuevoMaxCaracter)
            '    gfx.DrawString("DIRECCION         : " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 6, 42, New StringFormat())
            '    contador += 1
            '    CadenaPorEscribirEnLinea = NuevoCaracter.ToString.Substring(NuevoMaxCaracter + 1)
            '    gfx.DrawString("                     " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 6, 44, New StringFormat())
            'Else
            CadenaPorEscribirEnLinea = ordTot.Obtenerdireccion(Cabecera)
            gfx.DrawString("RAZON SOCIAL     : " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R5, StringFormat)
            '    contador += 1
            '    CadenaPorEscribirEnLinea = ""
            '    gfx.DrawString("                     " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 6, 44, New StringFormat())
            'End If

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R6 As New RectangleF(5, 60, 197, 25)
            'direccion entrega
            NuevoCaracter = ordTot.ObtenerdireccionEntrega(Cabecera)
            'MaximoCaracter = NuevoCaracter.Length
            'If (MaximoCaracter > 45) Then
            '    NuevoMaxCaracter = MaximoCaracter / 2
            CadenaPorEscribirEnLinea = NuevoCaracter
            gfx.DrawString("RUC.                       : " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R6, StringFormat)


            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R7 As New RectangleF(80, 44, 197, 25)
            'documkentop
            CadenaPorEscribirEnLinea = ordTot.Obtenermoneda(Cabecera)
            gfx.DrawString("FECHA DE VIAJE: " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R7, StringFormat)


            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R77 As New RectangleF(140, 44, 197, 25)
            'documkentop
            CadenaPorEscribirEnLinea = (HORAsALIDA)
            gfx.DrawString("HORA: " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R77, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R8 As New RectangleF(5, 64, 197, 25)
            'documkentop
            CadenaPorEscribirEnLinea = ordTot.ObtenerTelefono(Cabecera)
            gfx.DrawString("AGENCIA ORIGEN: " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R8, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R9 As New RectangleF(85, 64, 197, 25)
            'documkentop
            CadenaPorEscribirEnLinea = ordTot.ObtenerLugar(Cabecera)
            gfx.DrawString("AGENCIA DESTINO: " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R9, StringFormat)

            contador += 1
        Next

    End Sub

    '*****************************************************************************
    '****************************** NOMBRE DE LOS ELEMENTOS ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasElementosFactura As ArrayList = New ArrayList()
    Public LineasElementosFacturaPorPaginacion As ArrayList = New ArrayList()

    'Linea para capturar el ruc y numeroComprobante de la Factura
    Public Sub AnadirLineaElementosFactura(ByVal codigo As String, ByVal Descripcion As String, ByVal cantidad As String,
                                      ByVal UM As String, ByVal ValorVentaUnit As String, ByVal Descuento As String,
                                      ByVal ValorVentaTotal As String, ByVal OtrosCargos As String,
                                      ByVal Impuestos As String, ByVal PrecioVenta As String, ByVal VentaTotal As String)

        Dim ordTot As OrdenarElementoFactura = New OrdenarElementoFactura()
        LineasElementosFactura.Add(ordTot.GenerarImprimir(codigo, Descripcion, cantidad, UM,
                                                          ValorVentaUnit, Descuento, ValorVentaTotal, OtrosCargos,
                                                          Impuestos, PrecioVenta, VentaTotal))
    End Sub

    Public Sub AnadirLineaElementosFacturaXPagina(ByVal numeracion As String, ByVal codigo As String, ByVal Descripcion As String, ByVal cantidad As String,
                                      ByVal UM As String, ByVal PrecioVenta As String, ByVal VentaTotal As Decimal)

        Dim ordTot As OrdenarElementoFacturaXPagina = New OrdenarElementoFacturaXPagina()
        LineasElementosFacturaPorPaginacion.Add(ordTot.GenerarImprimir(numeracion, codigo, Descripcion, cantidad, UM,
                                                          PrecioVenta, VentaTotal))
    End Sub


    'Dibuja `parte de la derecha de la factura
    Private Sub DibujaElementosFactura(i As ArrayList)
        lineaEspacio = 76
        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdenarElementoFacturaXPagina = New OrdenarElementoFacturaXPagina()
        'Fuente de la impresion
        Dim FuenteImpresaDetalle = New Font("Draft", 10, FontStyle.Regular)
        Dim FuenteImpresaEncabezado = New Font("Draft", 8, FontStyle.Bold)
        'Se dibuja uin rectangulo parte derecha
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)

        'Crear texto del EncabezaDO
        gfx.DrawString("    N°          Tipo                                                Descripciòn                                                         UM            Cant.           Precio Unit.           Valor Total", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 71, New StringFormat())
        'gfx.DrawString("                                                                                                                                                                           Vta. Unit.", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 76, New StringFormat())
        'crear rectangulo d e la cabecera
        gfx.DrawRectangle(blackPen, 5, 70, 197, 5)
        'crear la fila numero
        gfx.DrawRectangle(blackPen, 5, 70, 10, 35)
        'crear la fila 4
        gfx.DrawRectangle(blackPen, 15, 70, 20, 35)
        'crear la fila descrpcion
        gfx.DrawRectangle(blackPen, 35, 70, 88, 35)
        'crear la fila um
        gfx.DrawRectangle(blackPen, 123, 70, 10, 35)
        'crear la fila cantidad
        gfx.DrawRectangle(blackPen, 133, 70, 20, 35)
        ''crear la fila Venta Total
        gfx.DrawRectangle(blackPen, 153, 70, 24, 35)
        ''crear la fila Venta Total
        gfx.DrawRectangle(blackPen, 177, 70, 25, 35)


        Dim elemento As String = "", espacios As String = ""
        Dim nroEspacios As Integer = 0
        'Dim ValorVentaUnit As String = String.Empty
        'Dim Descuento As String = String.Empty
        'Dim ValorVentaTotal As String = String.Empty
        'Dim OtrosCargos As String = String.Empty
        'Dim Impuestos As String = String.Empty
        Dim PrecioVenta As String = String.Empty
        Dim ValidarTotal As String = String.Empty
        Dim Cantidad As String = String.Empty
        Dim Codigo As String = String.Empty
        'Dim numeracion As Integer = 0
        Dim um As String = String.Empty
        Dim descripcion As String = String.Empty
        Dim contadorPagina As Integer = 0

        For Each Item As String In i
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R0 As New RectangleF(5, lineaEspacio, 10, 30)
            'conteo de item
            numeracion += 1
            'Colocar la cantidad a la derecha.
            Dim StringFormat As New StringFormat
            StringFormat.Alignment = StringAlignment.Far

            CadenaPorEscribirEnLinea = ordTot.OptenerNumeracion(Item)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R0, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R1 As New RectangleF(15, lineaEspacio, 20, 30)
            Codigo = 0.0
            Codigo = ordTot.OptenerCodigo(Item)

            'Colocar la cantidad a la derecha.
            Dim StringFormatCodigo As New StringFormat
            StringFormatCodigo.Alignment = StringAlignment.Far

            CadenaPorEscribirEnLinea = Codigo
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R1, StringFormatCodigo)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R4 As New RectangleF(123, lineaEspacio, 10, 30)
            'Colocar la cantidad a la derecha.
            Dim StringFormatUM As New StringFormat
            StringFormatUM.Alignment = StringAlignment.Near

            CadenaPorEscribirEnLinea = ordTot.ObtenerUM(Item)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R4, StringFormatUM)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R2 As New RectangleF(133, lineaEspacio, 20, 30)

            Cantidad = 0.0
            Cantidad = ordTot.ObtenerCantidad(Item)

            'Colocar la cantidad a la derecha.
            Dim StringFormatCantidad As New StringFormat
            StringFormatCantidad.Alignment = StringAlignment.Far

            CadenaPorEscribirEnLinea = Cantidad
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R2, StringFormatCantidad)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R5 As New RectangleF(153, lineaEspacio, 24, 30)
            'Colocar la cantidad a la derecha.
            Dim StringFormatPrecioUnit As New StringFormat
            StringFormatPrecioUnit.Alignment = StringAlignment.Far

            PrecioVenta = 0.0
            PrecioVenta = FormatNumber(ordTot.ObtenerPrecioVenta(Item), 2)
            'elemento = String.Empty
            ''Colocar la cantidad a la derecha.
            'nroEspacios = (10 - PrecioVenta.ToString().Length)
            'espacios = ""
            'For i As Integer = 0 To nroEspacios - 1
            '    'Generamos los espacios necesarios para alinear a la derecha
            '    espacios += " "
            'Next
            'elemento += espacios & PrecioVenta.ToString()

            CadenaPorEscribirEnLinea = PrecioVenta
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R5, StringFormatPrecioUnit)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R6 As New RectangleF(177, lineaEspacio, 25, 30)
            'Colocar la cantidad a la derecha.
            Dim StringFormatTotal As New StringFormat
            StringFormatTotal.Alignment = StringAlignment.Far

            ValidarTotal = 0.0
            elemento = String.Empty
            ValidarTotal = FormatNumber(ordTot.ObtenerVentaTotal(Item), 2)
            ''ValidarTotal = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator
            ''Colocar la cantidad a la derecha.
            'nroEspacios = (15 - ValidarTotal.Length)
            'espacios = ""
            'For i As Integer = 0 To nroEspacios - 1
            '    'Generamos los espacios necesarios para alinear a la derecha
            '    espacios += " "
            'Next
            'elemento += espacios & FormatNumber(ValidarTotal.ToString(), 2)
            ''agregamos la cantidad con los espacios

            CadenaPorEscribirEnLinea = ValidarTotal '.TrimStart("0")
            'CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R6, StringFormatTotal)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R3 As New RectangleF(36, lineaEspacio, 90, 30)
            Dim total As Integer
            Dim nombreArticlo As String
            'Dim enviarNombre As String
            nombreArticlo = ordTot.ObtenerDescripcion(Item)

            'Colocar la cantidad a la derecha.
            Dim StringFormatDescrip As New StringFormat
            StringFormatDescrip.Alignment = StringAlignment.Near

            If (nombreArticlo.Length > 55) Then
                total = nombreArticlo.Length / 55
                'Dim lineaEspacio2 As Integer = 82
                'For index As Integer = 1 To total
                'Dim R33 As New RectangleF(36, lineaEspacio, 90, 130)
                '    CadenaPorEscribirEnLinea = nombreArticlo
                '    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R33, StringFormatDescrip)
                '    lineaEspacio += 5
                'Next
                CadenaPorEscribirEnLinea = nombreArticlo
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R3, StringFormatDescrip)
                lineaEspacio += (3 * total)
            Else
                CadenaPorEscribirEnLinea = nombreArticlo
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R3, StringFormatDescrip)

            End If

            count += 1
            contadorPagina += 1
            If (contadorPagina = 7) Then

                contadorPagina = 0
            End If
            lineaEspacio += 5
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
    Public LineasTotalFactura As ArrayList = New ArrayList()

    'Linea para capturar el ruc y numeroComprobante de la Factura
    Public Sub AnadirDatosGenerales(ByVal codigo As String, ByVal cantidad As String)
        Dim ordTot As OrdernarTotalFactura = New OrdernarTotalFactura()
        LineasTotalFactura.Add(ordTot.GenerarTotal(codigo, cantidad))
    End Sub

    Private Sub DibujaTotalFactura()
        Dim contadorGeneral As Integer = 0
        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarTotalFactura = New OrdernarTotalFactura()
        'Fuente de la impresion
        Dim FuenteImpresaEncabezado = New Font("Draft", 9, FontStyle.Regular)
        Dim FuenteImpresaEncabezadoTexto = New Font("Draft", 9, FontStyle.Regular)
        'Se dibuja uin rectangulo parte derecha
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)

        ''Crear texto del EncabezaDO
        'crear el Rectanguilo del importe General
        gfx.DrawRectangle(blackPen, 139, 106, 63, 27)
        'gfx.DrawRectangle(blackPen, 140, 261, 65, 20)

        'Encabezados de los importes Generales
        CadenaPorEscribirEnLinea = "OP. GRATUITAS"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 106, New StringFormat())

        CadenaPorEscribirEnLinea = "OP. EXONERADAS"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 109, New StringFormat())

        CadenaPorEscribirEnLinea = "OP. INAFECTO"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 112, New StringFormat())

        CadenaPorEscribirEnLinea = "OP. GRAVADA"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 115, New StringFormat())

        CadenaPorEscribirEnLinea = "TOTL DSCTO."
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 118, New StringFormat())

        CadenaPorEscribirEnLinea = "I.S.C."
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 121, New StringFormat())

        CadenaPorEscribirEnLinea = "I.G.V."
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 124, New StringFormat())

        CadenaPorEscribirEnLinea = "IMPORTE TOTAL"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 127, New StringFormat())


        'Importes CApturados del sistema
        For Each Elemento As String In LineasTotalFactura

            CadenaPorEscribirEnLinea = ordTot.ObtenerTotalNombre(Elemento)
            CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 160, contadorGeneral + 106, New StringFormat())


            Dim R2 As New RectangleF(182, contadorGeneral + 106, 20, 30)
            CadenaPorEscribirEnLinea = "0.00"

            'Colocar la cantidad a la derecha.
            Dim StringFormatCantidad As New StringFormat
            StringFormatCantidad.Alignment = StringAlignment.Far

            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R2, StringFormatCantidad)

            CadenaPorEscribirEnLinea = "0.00"
            CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormatCantidad)
            contadorGeneral += 3

        Next

    End Sub

    'Dibuja `parte de la derecha de la factura
    Private Sub DibujaTotalFacturaFinal()
        Dim contadorGeneral As Integer = 0
        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarTotalFactura = New OrdernarTotalFactura()
        'Fuente de la impresion
        Dim FuenteImpresaEncabezado = New Font("Draft", 9, FontStyle.Regular)
        Dim FuenteImpresaEncabezadoTexto = New Font("Draft", 9, FontStyle.Regular)
        'Se dibuja uin rectangulo parte derecha
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)

        ''Crear texto del EncabezaDO
        'crear el Rectanguilo del importe General
        gfx.DrawRectangle(blackPen, 139, 106, 63, 27)
        'gfx.DrawRectangle(blackPen, 140, 261, 65, 20)

        'Encabezados de los importes Generales
        CadenaPorEscribirEnLinea = "OP. GRATUITAS"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 106, New StringFormat())

        CadenaPorEscribirEnLinea = "OP. EXONERADAS"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 109, New StringFormat())

        CadenaPorEscribirEnLinea = "OP. INAFECTO"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 112, New StringFormat())

        CadenaPorEscribirEnLinea = "OP. GRAVADA"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 115, New StringFormat())

        CadenaPorEscribirEnLinea = "TOTL DSCTO."
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 118, New StringFormat())

        CadenaPorEscribirEnLinea = "I.S.C."
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 121, New StringFormat())

        CadenaPorEscribirEnLinea = "I.G.V."
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 124, New StringFormat())

        CadenaPorEscribirEnLinea = "IMPORTE TOTAL"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 127, New StringFormat())


        'Importes CApturados del sistema
        For Each Elemento As String In LineasTotalFactura

            CadenaPorEscribirEnLinea = ordTot.ObtenerTotalNombre(Elemento)
            CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 160, contadorGeneral + 106, New StringFormat())


            Dim R2 As New RectangleF(182, contadorGeneral + 106, 20, 30)
            CadenaPorEscribirEnLinea = FormatNumber(ordTot.ObtenerTotalImporte(Elemento), 2)

            'Colocar la cantidad a la derecha.
            Dim StringFormatCantidad As New StringFormat
            StringFormatCantidad.Alignment = StringAlignment.Far

            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R2, StringFormatCantidad)

            CadenaPorEscribirEnLinea = FormatNumber(ordTot.ObtenerTotalImporte(Elemento), 2)
            CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormatCantidad)
            contadorGeneral += 3

        Next

    End Sub

    '*****************************************************************************
    '****************************** NOMBRE importes TOTALES ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasDatosComplementaria As ArrayList = New ArrayList()

    'Linea para capturar el ruc y numeroComprobante de la Factura
    Public Sub AnadirLineaTotalFactura(ByVal codigo As String)

        Dim ordTot As OrdernarDatosComplentariasTransporte = New OrdernarDatosComplentariasTransporte()
        LineasDatosComplementaria.Add(ordTot.GenerarTotal(codigo))
    End Sub

    'Dibuja `parte de la derecha de la factura
    Private Sub DibujaDatosGenerales(Paginacion As String)

        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarDatosComplentarias = New OrdernarDatosComplentarias()
        'Fuente de la impresion
        Dim FuenteImpresaEncabezado = New Font("Draft", 6, FontStyle.Regular)
        'Se dibuja uin rectangulo parte derecha
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        Dim contadorDatos As Integer = 0
        ''Crear texto del EncabezaDO
        'gfx.DrawString("Còdigo  Cantidad    UM                 Descripciòn                      P. Unit.    Lista   Dsctos     Total", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 60, New StringFormat())
        ''crear rectangulo de la cabecera
        'gfx.DrawRectangle(blackPen, 5, 57, 200, 10)
        'crear la fila codigo
        gfx.DrawRectangle(blackPen, 5, 106, 133, 5)
        'crear la fila cantidad
        gfx.DrawRectangle(blackPen, 5, 112, 133, 21)
        'gfx.DrawLine(blackPen, 5, 250, 138, 250)
        'gfx.DrawLine(blackPen, 70, 264, 95, 264)
        'gfx.DrawLine(blackPen, 104, 112, 104, 133)
        'gfx.DrawLine(blackPen, 137, 116, 104, 116)
        ''linea de la firma
        'gfx.DrawLine(blackPen, 105, 130, 135, 130)
        'crear la fila cantidad
        'gfx.DrawRectangle(blackPen, 5, 252, 133, 18)

        'For Each Elemento As String In LineasDatosComplementaria
        '    CadenaPorEscribirEnLinea = ordTot.ObtenerTotalNombre(Elemento)
        '    Dim conver As String
        '    Dim numeroConverson As Decimal = Convert.ToDecimal(CadenaPorEscribirEnLinea)
        '    conver = Conversion.Enletras(numeroConverson)
        '    gfx.DrawString(conver & " SOLES", FuenteImpresaEncabezado, ColorDeLaFuente, 11, contadorDatos + 107, New StringFormat())
        'Next

        'CadenaPorEscribirEnLinea = ""
        'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 23, contadorDatos + 111, New StringFormat())

        'CadenaPorEscribirEnLinea = "RECIBI CONFORME"
        'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 108, contadorDatos + 113, New StringFormat())

        ''CadenaPorEscribirEnLinea = "Nombre"
        ''gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 80, contadorDatos + 265, New StringFormat())

        'CadenaPorEscribirEnLinea = "Firma"
        'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 116, contadorDatos + 130, New StringFormat())

        If (tipoComprobante = "2") Then
            'CadenaPorEscribirEnLinea = "Representaciòn impresa del Comprobante electronico"
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 40, contadorDatos + 117, New StringFormat())

            'CadenaPorEscribirEnLinea = "Para consultar su comprobante electronico entre al link"
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 40, contadorDatos + 120, New StringFormat())

            'CadenaPorEscribirEnLinea = "http://www.softpack.com.pe"
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 40, contadorDatos + 123, New StringFormat())

            ''CadenaPorEscribirEnLinea = "Consulta a partir del 8vo. dìa de su emision"
            ''gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 90, contadorDatos + 270, New StringFormat())

            CadenaPorEscribirEnLinea = "TERMINOS Y CONDICIONES"
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 40, contadorDatos + 112, New StringFormat())

            CadenaPorEscribirEnLinea = "1. Postergaciones con 4 horas de anticipo"
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 40, contadorDatos + 114, New StringFormat())

            CadenaPorEscribirEnLinea = "2. Niños mayores de (5) años pagan pasaje y ocupan su asiento. Asi mismo no se venderan a"
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 40, contadorDatos + 116, New StringFormat())

            CadenaPorEscribirEnLinea = "    menores de edad que no sean identificados con su DNI y autorización notarial de sus "
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 40, contadorDatos + 118, New StringFormat())

            CadenaPorEscribirEnLinea = "    padres cuando corresponda"
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 40, contadorDatos + 120, New StringFormat())


            CadenaPorEscribirEnLinea = "3. La empresa no se responsabiliza por la perdida de equipaje en el salon. Su cuidado es exclusiva"
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 40, contadorDatos + 122, New StringFormat())

            CadenaPorEscribirEnLinea = "    responsabilidad del pasajero, Asi mismo no se responsabiliza por bultos no declarados"
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 40, contadorDatos + 124, New StringFormat())



            CadenaPorEscribirEnLinea = "4. El pasajero debe presentarse 1 hora antes de la hora de viaje"
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 40, contadorDatos + 126, New StringFormat())

            CadenaPorEscribirEnLinea = "5. El equipaje consta de maletas, maletines, mochilas y bolsa de mano de uso personal"
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 40, contadorDatos + 128, New StringFormat())

            CadenaPorEscribirEnLinea = "Autorizado mendiante resolución de SUNAT / Representación impresa puede ser consultado: http://www.spk.com.pe/"
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 5, contadorDatos + 133, New StringFormat())


        End If
        'CadenaPorEscribirEnLinea = "Pag." & Paginacion
        'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 8, contadorDatos + 280, New StringFormat())

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
        'Dim R2 As New RectangleF(5, 5, 100, 80)
        'Fuente de la impresion
        Dim FuenteImpresaEncabezado2 As Font
        Dim FuenteImpresaEncabezado As Font

        If (tipoLogo = "CR") Then
            FuenteImpresaEncabezado = New Font("Draft", 7, FontStyle.Italic)

            'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
            Dim ordTot As OrdernarEmpresa = New OrdernarEmpresa()
            ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
            Dim blackPen As New Pen(Color.Black, 0)
            'stringformat para alinear el text
            Dim StringFormat As New StringFormat
            StringFormat.Alignment = StringAlignment.Center

            For Each Elemento As String In LineasDatosEmpresa
                'CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                'contador += 1
                Dim NumTotalNombre = ordTot.ObtenerTotalNombre(Elemento).Count
                If (NumTotalNombre >= 36 And NumTotalNombre < 65) Then
                    Dim R2 As New RectangleF(5, lineaEspacioPagina, 100, 12)
                    CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                    lineaEspacioPagina += 1
                ElseIf (NumTotalNombre >= 65) Then
                    If (tipoLogo = "CR") Then
                        FuenteImpresaEncabezado2 = New Font("Draft", 7, FontStyle.Italic)
                    Else
                        FuenteImpresaEncabezado2 = New Font("Draft", 12, FontStyle.Italic)
                    End If

                    Dim R2 As New RectangleF(5, lineaEspacioPagina, 100, 17)
                    CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado2, Brushes.Black, R2, StringFormat)
                    lineaEspacioPagina += 2
                Else
                    Dim R2 As New RectangleF(5, lineaEspacioPagina, 100, 5)
                    CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                    'lineaEspacio += 5
                End If
            Next
        ElseIf (tipoLogo = "IZ") Then
            FuenteImpresaEncabezado = New Font("Draft", 10, FontStyle.Italic)
            'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
            Dim ordTot As OrdernarEmpresa = New OrdernarEmpresa()
            ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
            Dim blackPen As New Pen(Color.Black, 0)
            'stringformat para alinear el text
            Dim StringFormat As New StringFormat
            StringFormat.Alignment = StringAlignment.Center

            For Each Elemento As String In LineasDatosEmpresa
                'CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                'contador += 1
                Dim NumTotalNombre = ordTot.ObtenerTotalNombre(Elemento).Count
                If (NumTotalNombre >= 36 And NumTotalNombre < 65) Then
                    Dim R2 As New RectangleF(55, lineaEspacioPagina, 50, 12)
                    CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                    lineaEspacioPagina += 1
                ElseIf (NumTotalNombre >= 65) Then
                    If (tipoLogo = "IZ") Then
                        FuenteImpresaEncabezado2 = New Font("Draft", 8, FontStyle.Italic)
                    Else
                        FuenteImpresaEncabezado2 = New Font("Draft", 12, FontStyle.Italic)
                    End If

                    Dim R2 As New RectangleF(55, lineaEspacioPagina, 50, 17)
                    CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado2, Brushes.Black, R2, StringFormat)
                    lineaEspacioPagina += 2
                Else
                    Dim R2 As New RectangleF(55, lineaEspacioPagina, 50, 10)
                    CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                    'lineaEspacio += 5
                End If
            Next

        Else
            FuenteImpresaEncabezado = New Font("Draft", 14, FontStyle.Italic)

            'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
            Dim ordTot As OrdernarEmpresa = New OrdernarEmpresa()
            ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
            Dim blackPen As New Pen(Color.Black, 0)
            'stringformat para alinear el text
            Dim StringFormat As New StringFormat
            StringFormat.Alignment = StringAlignment.Center

            For Each Elemento As String In LineasDatosEmpresa
                'CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                'contador += 1
                Dim NumTotalNombre = ordTot.ObtenerTotalNombre(Elemento).Count
                If (NumTotalNombre >= 36 And NumTotalNombre < 65) Then
                    Dim R2 As New RectangleF(5, lineaEspacioPagina, 100, 12)
                    CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                    lineaEspacioPagina += 1
                ElseIf (NumTotalNombre >= 65) Then
                    If (tipoLogo = "CR") Then
                        FuenteImpresaEncabezado2 = New Font("Draft", 8, FontStyle.Italic)
                    Else
                        FuenteImpresaEncabezado2 = New Font("Draft", 12, FontStyle.Italic)
                    End If

                    Dim R2 As New RectangleF(5, lineaEspacioPagina, 100, 17)
                    CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado2, Brushes.Black, R2, StringFormat)
                    lineaEspacioPagina += 2
                Else
                    Dim R2 As New RectangleF(5, lineaEspacioPagina, 100, 5)
                    CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                    'lineaEspacio += 5
                End If
            Next

        End If


        ''llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        'Dim ordTot As OrdernarEmpresa = New OrdernarEmpresa()
        '' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        'Dim blackPen As New Pen(Color.Black, 0)
        ''stringformat para alinear el text
        'Dim StringFormat As New StringFormat
        'StringFormat.Alignment = StringAlignment.Center

        'For Each Elemento As String In LineasDatosEmpresa
        '    'CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
        '    'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
        '    'contador += 1
        '    Dim NumTotalNombre = ordTot.ObtenerTotalNombre(Elemento).Count
        '    If (NumTotalNombre >= 36 And NumTotalNombre < 65) Then
        '        Dim R2 As New RectangleF(5, lineaEspacioPagina, 100, 12)
        '        CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
        '        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
        '        lineaEspacioPagina += 1
        '    ElseIf (NumTotalNombre >= 65) Then
        '        If (tipoLogo = "CR") Then
        '            FuenteImpresaEncabezado2 = New Font("Draft", 8, FontStyle.Italic)
        '        Else
        '            FuenteImpresaEncabezado2 = New Font("Draft", 12, FontStyle.Italic)
        '        End If

        '        Dim R2 As New RectangleF(5, lineaEspacioPagina, 100, 17)
        '        CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
        '        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado2, Brushes.Black, R2, StringFormat)
        '        lineaEspacioPagina += 2
        '    Else
        '        Dim R2 As New RectangleF(5, lineaEspacioPagina, 100, 5)
        '        CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNombre(Elemento))
        '        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
        '        'lineaEspacio += 5
        '    End If
        'Next

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
        Dim FuenteImpresaEncabezado = New Font("Draft", 7, FontStyle.Regular)



        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarPropietario = New OrdernarPropietario()
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        'stringformat para alinear el text
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Center

        'MUESTRA QUE ESPACIO SE DARA AL PROPIETARIO PARA QUE EL ESPACIO NO SEA MUY GRANDE

        Select Case tipoLogo
            Case "CR"
                FuenteImpresaEncabezado = New Font("Draft", 7, FontStyle.Regular)
                If (lineaEspacioPagina = 21) Then
                    lineaEspacioPagina += 2
                ElseIf (lineaEspacioPagina = 22) Then
                    lineaEspacioPagina += 1
                Else
                    lineaEspacioPagina += 3
                End If
            Case "IZ"
                FuenteImpresaEncabezado = New Font("Draft", 8, FontStyle.Regular)
                If (lineaEspacioPagina = 7) Then
                    lineaEspacioPagina += 9
                ElseIf (lineaEspacioPagina = 22) Then
                    lineaEspacioPagina += 5
                ElseIf (lineaEspacioPagina = 6) Then
                    lineaEspacioPagina += 11
                ElseIf (lineaEspacioPagina = 5) Then
                    lineaEspacioPagina += 11
                Else
                    lineaEspacioPagina += 11
                End If
            Case "SL"
                FuenteImpresaEncabezado = New Font("Draft", 8, FontStyle.Regular)
                If (lineaEspacioPagina = 6) Then
                    lineaEspacioPagina += 9
                ElseIf (lineaEspacioPagina = 7) Then
                    lineaEspacioPagina += 9
                ElseIf (lineaEspacioPagina = 5) Then
                    lineaEspacioPagina += 6
                Else
                    lineaEspacioPagina += 9
                End If
        End Select




        For Each Elemento As String In LineasDatosNombrePropietario
            'Dim linea As Integer = 23
            'If ((ordTot.ObtenerTotalPropietario(Elemento)).Count > 60) Then
            '    Dim R2 As New RectangleF(5, linea, 60, 20)
            '    CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalPropietario(Elemento))
            '    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
            '    linea += 5
            'Else
            '    Dim R2 As New RectangleF(5, linea, 60, 5)
            '    CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalPropietario(Elemento))
            '    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
            '    'lineaEspacio += 5
            'End If

            Dim NumNombrePropietario = (ordTot.ObtenerTotalPropietario(Elemento)).Count
            If (NumNombrePropietario >= 35 And NumNombrePropietario <= 65) Then
                Dim R2 As New RectangleF(5, lineaEspacioPagina, 100, 6)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalPropietario(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                lineaEspacioPagina += 1
            ElseIf (NumNombrePropietario > 65) Then
                Dim R2 As New RectangleF(5, lineaEspacioPagina, 100, 10)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalPropietario(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                lineaEspacioPagina += 2
            Else
                Dim R2 As New RectangleF(5, lineaEspacioPagina, 100, 3)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalPropietario(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                'lineaEspacio += 5
            End If

        Next

    End Sub

    ''*****************************************************************************
    ''****************************** NOMBRE importes TOTALES ******************
    ''Se declara el array para la Factura parte izquierda - datos generales
    'Public LineasDatosNombrePropietario As ArrayList = New ArrayList()

    ''Linea para capturar el ruc y numeroComprobante de la Factura
    'Public Sub AnadirLineaNombrePropietario(ByVal nombrePropietario As String)

    '    Dim ordTot As OrdernarPropietario = New OrdernarPropietario()
    '    LineasDatosNombrePropietario.Add(ordTot.GenerarTotal(nombrePropietario))
    'End Sub

    ''Dibuja `parte de la derecha de la factura
    'Private Sub DibujaDatosNombrePropietario()
    '    'se crea un rectangulo para manipular texto dentro del rectangulo

    '    'Fuente de la impresion
    '    Dim FuenteImpresaEncabezado = New Font("Draft", 7, FontStyle.Regular)

    '    'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
    '    Dim ordTot As OrdernarPropietario = New OrdernarPropietario()
    '    ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
    '    Dim blackPen As New Pen(Color.Black, 0)
    '    'stringformat para alinear el text
    '    Dim StringFormat As New StringFormat
    '    StringFormat.Alignment = StringAlignment.Near

    '    For Each Elemento As String In LineasDatosNombrePropietario
    '        Dim linea As Integer = 23
    '        If ((ordTot.ObtenerTotalPropietario(Elemento)).Count > 60) Then
    '            Dim R2 As New RectangleF(5, linea, 60, 20)
    '            CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalPropietario(Elemento))
    '            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
    '            linea += 5
    '        Else
    '            Dim R2 As New RectangleF(5, linea, 60, 5)
    '            CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalPropietario(Elemento))
    '            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
    '            'lineaEspacio += 5
    '        End If
    '    Next

    'End Sub


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
        Dim FuenteImpresaEncabezado = New Font("Draft", 7, FontStyle.Regular)

        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarPublicidad = New OrdernarPublicidad()
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        'stringformat para alinear el text
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Center

        'MUESTRA QUE ESPACIO SE DARA AL PROPIETARIO PARA QUE EL ESPACIO NO SEA MUY GRANDE
        Select Case tipoLogo
            Case "CR"
                If (lineaEspacioPagina = 29) Then
                    lineaEspacioPagina += 5
                ElseIf (lineaEspacioPagina = 28) Then
                    lineaEspacioPagina += 3
                ElseIf (lineaEspacioPagina = 26) Then
                    lineaEspacioPagina += 2
                ElseIf (lineaEspacioPagina = 27) Then
                    lineaEspacioPagina += 2
                ElseIf (lineaEspacioPagina = 24) Then
                    lineaEspacioPagina += 2
                ElseIf (lineaEspacioPagina) = 25 Then
                    lineaEspacioPagina += 1
                Else
                    lineaEspacioPagina += 2
                End If
            Case "IZ"
                If (lineaEspacioPagina = 17) Then
                    lineaEspacioPagina += 5
                ElseIf (lineaEspacioPagina = 18) Then
                    lineaEspacioPagina += 5
                ElseIf (lineaEspacioPagina = 16) Then
                    lineaEspacioPagina += 5
                ElseIf (lineaEspacioPagina = 7) Then
                    lineaEspacioPagina += 10
                ElseIf (lineaEspacioPagina = 6) Then
                    lineaEspacioPagina += 10
                ElseIf (lineaEspacioPagina = 5) Then
                    lineaEspacioPagina += 15
                Else
                    lineaEspacioPagina += 10
                End If
            Case "SL"
                If (lineaEspacioPagina = 17) Then
                    lineaEspacioPagina += 3
                ElseIf (lineaEspacioPagina = 18) Then
                    lineaEspacioPagina += 4
                ElseIf (lineaEspacioPagina = 16) Then
                    lineaEspacioPagina += 5
                ElseIf (lineaEspacioPagina = 19) Then
                    lineaEspacioPagina += 5
                ElseIf (lineaEspacioPagina = 22) Then
                    lineaEspacioPagina += 3
                ElseIf (lineaEspacioPagina = 23) Then
                    lineaEspacioPagina += 5
                ElseIf (lineaEspacioPagina = 21) Then
                    lineaEspacioPagina += 3
                ElseIf (lineaEspacioPagina = 7) Then
                    lineaEspacioPagina += 10
                ElseIf (lineaEspacioPagina = 13) Then
                    lineaEspacioPagina += 5
                ElseIf (lineaEspacioPagina = 12) Then
                    lineaEspacioPagina += 3
                ElseIf (lineaEspacioPagina = 11) Then
                    lineaEspacioPagina += 5
                ElseIf (lineaEspacioPagina = 6) Then
                    lineaEspacioPagina += 11
                ElseIf (lineaEspacioPagina = 5) Then
                    lineaEspacioPagina += 11
                Else
                    lineaEspacioPagina += 5
                End If
        End Select


        For Each Elemento As String In LineasDatosNombrePublicidad

            Dim NumNombrePublicidad = (ordTot.ObtenerPublicidad(Elemento)).Count
            If (NumNombrePublicidad >= 41 And NumNombrePublicidad < 65) Then
                Dim R2 As New RectangleF(3, lineaEspacioPagina, 100, 6)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerPublicidad(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                lineaEspacioPagina += 1
            ElseIf (NumNombrePublicidad > 65) Then
                Dim R2 As New RectangleF(3, lineaEspacioPagina, 100, 10)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerPublicidad(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
                lineaEspacioPagina += 4
            Else
                Dim R2 As New RectangleF(3, lineaEspacioPagina, 100, 3)
                CadenaPorEscribirEnLinea = (ordTot.ObtenerPublicidad(Elemento))
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)

            End If

        Next

    End Sub

End Class