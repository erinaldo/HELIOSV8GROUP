Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO

Public Class GuiaRemision

#Region "variables"
    Public gfx As Graphics
    Public imageHeight As Integer = 0
    Public imageQR As Integer = 0
    Public PosicionLogo As String = String.Empty
    Private headerImagep As Image
    Private headerImageQR As Image
    Public CadenaPorEscribirEnLinea As String = String.Empty
    Dim lineaEspacioDatosEmpresa As Integer = 0
    Private WithEvents DocumentoAImprimir As New PrintDocument
    Public ColorDeLaFuente As SolidBrush = New SolidBrush(Color.Black)
    Public lineaEspacio As Integer = 95
    Dim listaPaginas As New List(Of ArrayList)
    Dim listaArrays As Integer = 0
    Dim comienzo As Integer = 0
    Public tipoComprobante As String = String.Empty
#End Region

    Public Sub ImprimeTicket(ByVal impresora As String, ByVal conteoImpresion As Integer)

        'Dim pr As New PrintDocument 
        DocumentoAImprimir.PrinterSettings.PrinterName = impresora
        'pr.PrinterSettings.printpa() 
        ' pr.PrintPage += New 
        ' PrintPageEventHandler(pr_PrintPage) 
        lineasTotal()

        For number As Integer = conteoImpresion To 1 Step -1
            DocumentoAImprimir.Print()
        Next

    End Sub

    Private Sub DocumentoAImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocumentoAImprimir.PrintPage
        For Each X In listaPaginas
            If (X.Count > 0) Then
                e.Graphics.PageUnit = GraphicsUnit.Millimeter
                gfx = e.Graphics

                imageHeight = 0
                DrawImage()

                If (PosicionLogo <> "IT") Then
                    DibujaDatosEmpresa()
                End If
                DibujaLaSubCabeceraIzquierda()
                DibujaLaCabeceraDerecha()
                DibujaDatosComplemnetarios()
                DibujaDatosPuntosLLegadaPartida()
                DibujaDatosGenerales(1)
                DibujaDatosConductor()
                DibujaDatosTransporte()

                For Each i In listaPaginas
                    Select Case listaArrays
                        Case 1
                            DibujaElementosFactura(i)
                            'DibujaTotalFacturaFinal()
                            'DrawImageQR()
                            e.HasMorePages = False
                            Exit Sub
                        Case Else
                            DibujaElementosFactura(i)
                            'DibujaTotalFactura()
                            'DrawImageQR()
                            listaArrays -= 1
                            e.HasMorePages = True
                            listaPaginas.RemoveAt(0)
                            ' se comento por error ojo
                            'listaPaginas.RemoveAt(comienzo)
                            'comienzo += 1
                            Exit Sub 'es necesario el Exit Sub, si no cae en un bucle 
                    End Select
                Next
            End If
            e.HasMorePages = False
            Exit Sub
        Next
    End Sub

#Region "GUARDARIMPRSION"
    Public Function GuardanImpresion(ByVal impresora As String, ByVal NombreNumero As String) As String

        Dim ubicacion As String = String.Empty

        ubicacion = Path.Combine("C:\FACTURASELECTRONICAS\PDF\", NombreNumero & ".pdf")

        If (File.Exists(ubicacion)) Then
            Kill(ubicacion)
        End If

        DocumentoAImprimir.PrinterSettings.PrinterName = impresora
        My.Computer.FileSystem.CreateDirectory("C:\FACTURASELECTRONICAS\PDF\")
        DocumentoAImprimir.PrinterSettings.PrintToFile = True
        DocumentoAImprimir.PrinterSettings.PrintFileName = ubicacion
        lineasTotal()
        DocumentoAImprimir.Print()

        Return ubicacion

    End Function

#End Region

#Region "METODOS IMAGEN"

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

    Private Sub DrawImage()
        Try
            Select Case PosicionLogo
                Case "CT"
                    If (Not IsNothing(headerImagep.Width)) Then
                        If (headerImagep.Width <> 0) Then
                            Dim destRect As New Rectangle(35, 5, 55, 20)
                            gfx.DrawImage(HeaderImage, destRect)
                            Dim height As Double = (HeaderImage.Height / 200)
                            imageHeight = CInt(Math.Round(height) + 3)
                            lineaEspacioDatosEmpresa = 25
                        End If
                    End If
                Case "IZ"
                    If (Not IsNothing(headerImagep.Width)) Then
                        If (headerImagep.Width <> 0) Then
                            Dim destRect As New Rectangle(5, 5, 45, 35)
                            gfx.DrawImage(HeaderImage, destRect)
                            Dim height As Double = (HeaderImage.Height / 200)
                            imageHeight = CInt(Math.Round(height) + 3)
                            lineaEspacioDatosEmpresa = 5
                        End If
                    End If
                Case "IT"
                    If (Not IsNothing(headerImagep.Width)) Then
                        If (headerImagep.Width <> 0) Then
                            'Dim destRect As New Rectangle(20, 7, 100, 38)
                            Dim destRect As New Rectangle(5, 5, 130, 38)
                            gfx.DrawImage(HeaderImage, destRect)
                            Dim height As Double = (HeaderImage.Height / 200)
                            imageHeight = CInt(Math.Round(height) + 3)
                            'lineaEspacio = lineaEspacio + 22
                        End If
                    End If
            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Private Sub DrawImageQR()
    '    Try
    '        If (Not IsNothing(headerImageQR.Width)) Then
    '            If (headerImageQR.Width <> 0) Then
    '                Dim destRect As New Rectangle(8, 257, 25, 25)

    '                gfx.DrawImage(headerImagenQR, destRect)
    '                Dim height As Double = (headerImagenQR.Height / 200)
    '                imageQR = CInt(Math.Round(height) + 3)
    '                'lineaEspacio = lineaEspacio + 22
    '            End If
    '        End If

    '    Catch ex As Exception

    '    End Try

    'End Sub

#End Region

#Region "DATOS DE EMPRESA"
    '*****************************************************************************
    '****************************** NOMBRE DATOS EMPRESA ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasDatosEmpresa As ArrayList = New ArrayList()

    'Linea para capturar datos de la empresa
    Public Sub AnadirLineaEmpresa(ByVal razonSocial As String,
                                 ByVal NombreComercial As String,
                                 ByVal DireccionPrincipal As String,
                                 ByVal DireccionAnexo As String,
                                 ByVal Telefono As String)
        Dim ordTot As OrdernarDatosEmpresa = New OrdernarDatosEmpresa()
        LineasDatosEmpresa.Add(ordTot.GenerarTotal(razonSocial,
                                                   NombreComercial,
                                                   DireccionPrincipal,
                                                   DireccionAnexo,
                                                   Telefono))
    End Sub

    'Dibuja `parte izquierda de la factura
    Private Sub DibujaDatosEmpresa()
        Dim ordTot As OrdernarDatosEmpresa = New OrdernarDatosEmpresa()
        Select Case PosicionLogo
            Case "CT"
                'Se imprime los datos dentro del rectangulo
                For Each Item As String In LineasDatosEmpresa
                    '//FUENTE DE IMPRESION
                    Dim FuenteImpresion = New Font("Segoe UI", 8, FontStyle.Bold)
                    '//se crea un rectangulo para manipular texto dentro del rectangulo
                    Dim R0 As New RectangleF(5, lineaEspacioDatosEmpresa, 130, 100)
                    '//STRING FORMAT DEL TEXTO PARA LA POSICION
                    Dim StringFormat As New StringFormat
                    StringFormat.Alignment = StringAlignment.Center
                    CadenaPorEscribirEnLinea = ordTot.ObtenerRazonSocial(Item)
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresion, Brushes.Black, R0, StringFormat)
                    lineaEspacioDatosEmpresa += 3

                    '//FUENTE DE NOMBRE COMERCIAL
                    Dim FuenteImpresionComercial = New Font("Segoe UI", 6, FontStyle.Bold)
                    '//se crea un rectangulo para manipular texto dentro del rectangulo
                    Dim R1 As New RectangleF(5, lineaEspacioDatosEmpresa, 130, 3)
                    '//STRING FORMAT DEL TEXTO PARA LA POSICION
                    Dim StringFormatNombrecomercial As New StringFormat
                    StringFormatNombrecomercial.Alignment = StringAlignment.Center
                    CadenaPorEscribirEnLinea = ordTot.ObtenerNombreComercial(Item)
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresionComercial, Brushes.Black, R1, StringFormatNombrecomercial)
                    lineaEspacioDatosEmpresa += 3

                    '//FUENTE DE IMPRESION
                    Dim FuenteImpresionDireccion = New Font("Segoe UI", 6, FontStyle.Bold)
                    '//se crea un rectangulo para manipular texto dentro del rectangulo
                    Dim R2 As New RectangleF(5, lineaEspacioDatosEmpresa, 130, 3)
                    '//STRING FORMAT DEL TEXTO PARA LA POSICION
                    Dim StringFormatDireccion As New StringFormat
                    StringFormat.Alignment = StringAlignment.Near
                    CadenaPorEscribirEnLinea = ordTot.ObtenerDireccionPrincipal(Item)
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresionDireccion, Brushes.Black, R2, StringFormatDireccion)
                    lineaEspacioDatosEmpresa += 3

                    '//FUENTE DE IMPRESION
                    '//se crea un rectangulo para manipular texto dentro del rectangulo
                    Dim R3 As New RectangleF(5, lineaEspacioDatosEmpresa, 130, 3)
                    '//STRING FORMAT DEL TEXTO PARA LA POSICION
                    'Dim StringFormatDireccion As New StringFormat
                    'StringFormatDireccion.Alignment = StringAlignment.Near
                    CadenaPorEscribirEnLinea = ordTot.ObtenerDireccionAnexo(Item)
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresionDireccion, Brushes.Black, R3, StringFormatDireccion)
                    lineaEspacioDatosEmpresa += 3

                    '//FUENTE DE IMPRESION
                    '//se crea un rectangulo para manipular texto dentro del rectangulo
                    Dim R4 As New RectangleF(5, lineaEspacioDatosEmpresa, 130, 3)
                    '//STRING FORMAT DEL TEXTO PARA LA POSICION
                    CadenaPorEscribirEnLinea = ordTot.ObtenerTelefono(Item)
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresionDireccion, Brushes.Black, R4, StringFormatDireccion)

                Next

            Case "IZ"
                'Se imprime los datos dentro del rectangulo
                For Each Item As String In LineasDatosEmpresa
                    '//FUENTE DE IMPRESION

                    If (ordTot.ObtenerRazonSocial(Item).Length < 30) Then
                        Dim FuenteImpresion = New Font("Segoe UI", 12, FontStyle.Bold)
                        '//se crea un rectangulo para manipular texto dentro del rectangulo
                        Dim R0 As New RectangleF(46, lineaEspacioDatosEmpresa, 85, 100)
                        '//STRING FORMAT DEL TEXTO PARA LA POSICION
                        Dim StringFormat As New StringFormat
                        StringFormat.Alignment = StringAlignment.Center
                        CadenaPorEscribirEnLinea = ordTot.ObtenerRazonSocial(Item)
                        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresion, Brushes.Black, R0, StringFormat)

                        If (ordTot.ObtenerNombreComercial(Item).Length > 0) Then
                            lineaEspacioDatosEmpresa += 12
                        Else
                            lineaEspacioDatosEmpresa += 4
                        End If

                    Else
                        Dim FuenteImpresion = New Font("Segoe UI", 9, FontStyle.Bold)
                        '//se crea un rectangulo para manipular texto dentro del rectangulo
                        Dim R0 As New RectangleF(46, lineaEspacioDatosEmpresa, 85, 100)
                        '//STRING FORMAT DEL TEXTO PARA LA POSICION
                        Dim StringFormat As New StringFormat
                        StringFormat.Alignment = StringAlignment.Center
                        CadenaPorEscribirEnLinea = ordTot.ObtenerRazonSocial(Item)
                        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresion, Brushes.Black, R0, StringFormat)
                        lineaEspacioDatosEmpresa += 6

                        If (ordTot.ObtenerNombreComercial(Item).Length > 0) Then
                            lineaEspacioDatosEmpresa += 6
                        Else
                            lineaEspacioDatosEmpresa += 3
                        End If
                    End If

                    '//FUENTE DE NOMBRE COMERCIAL
                    Dim FuenteImpresionComercial = New Font("Segoe UI", 6, FontStyle.Bold)
                    '//se crea un rectangulo para manipular texto dentro del rectangulo
                    Dim R1 As New RectangleF(46, lineaEspacioDatosEmpresa, 80, 6)
                    '//STRING FORMAT DEL TEXTO PARA LA POSICION
                    Dim StringFormatNombrecomercial As New StringFormat
                    StringFormatNombrecomercial.Alignment = StringAlignment.Center
                    CadenaPorEscribirEnLinea = ordTot.ObtenerNombreComercial(Item)
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresionComercial, Brushes.Black, R1, StringFormatNombrecomercial)
                    lineaEspacioDatosEmpresa += 6

                    '//FUENTE DE IMPRESION
                    Dim FuenteImpresionDireccion = New Font("Segoe UI", 6, FontStyle.Bold)
                    '//se crea un rectangulo para manipular texto dentro del rectangulo
                    Dim R2 As New RectangleF(50, lineaEspacioDatosEmpresa, 80, 6)
                    '//STRING FORMAT DEL TEXTO PARA LA POSICION
                    Dim StringFormatDireccion As New StringFormat
                    StringFormatDireccion.Alignment = StringAlignment.Near
                    CadenaPorEscribirEnLinea = ordTot.ObtenerDireccionPrincipal(Item)
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresionDireccion, Brushes.Black, R2, StringFormatDireccion)
                    lineaEspacioDatosEmpresa += 6

                    '//FUENTE DE IMPRESION
                    '//se crea un rectangulo para manipular texto dentro del rectangulo
                    Dim R3 As New RectangleF(50, lineaEspacioDatosEmpresa, 80, 6)
                    '//STRING FORMAT DEL TEXTO PARA LA POSICION
                    'Dim StringFormatDireccion As New StringFormat
                    'StringFormatDireccion.Alignment = StringAlignment.Near
                    CadenaPorEscribirEnLinea = ordTot.ObtenerDireccionAnexo(Item)
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresionDireccion, Brushes.Black, R3, StringFormatDireccion)
                    lineaEspacioDatosEmpresa += 6

                    '//FUENTE DE IMPRESION
                    '//se crea un rectangulo para manipular texto dentro del rectangulo
                    Dim R4 As New RectangleF(50, lineaEspacioDatosEmpresa, 80, 3)
                    '//STRING FORMAT DEL TEXTO PARA LA POSICION
                    CadenaPorEscribirEnLinea = ordTot.ObtenerTelefono(Item)
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresionDireccion, Brushes.Black, R4, StringFormatDireccion)
                Next

            Case Else
                lineaEspacioDatosEmpresa = 6
                'Se imprime los datos dentro del rectangulo
                For Each Item As String In LineasDatosEmpresa

                    '//FUENTE DE IMPRESION
                    Dim FuenteImpresion = New Font("Segoe UI", 12, FontStyle.Bold)
                    '//se crea un rectangulo para manipular texto dentro del rectangulo
                    Dim R0 As New RectangleF(6, lineaEspacioDatosEmpresa, 130, 100)
                    '//STRING FORMAT DEL TEXTO PARA LA POSICION
                    Dim StringFormat As New StringFormat
                    StringFormat.Alignment = StringAlignment.Center
                    CadenaPorEscribirEnLinea = ordTot.ObtenerRazonSocial(Item)
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresion, Brushes.Black, R0, StringFormat)

                    Dim RazonSocial As String = ordTot.ObtenerRazonSocial(Item)

                    If (RazonSocial.Length > 50) Then
                        lineaEspacioDatosEmpresa += 10
                    Else
                        lineaEspacioDatosEmpresa += 7
                    End If

                    '//FUENTE DE NOMBRE COMERCIAL
                    Dim FuenteImpresionComercial = New Font("Segoe UI", 7, FontStyle.Bold)
                    '//se crea un rectangulo para manipular texto dentro del rectangulo
                    Dim R1 As New RectangleF(6, lineaEspacioDatosEmpresa, 130, 6)
                    '//STRING FORMAT DEL TEXTO PARA LA POSICION
                    Dim StringFormatNombrecomercial As New StringFormat
                    StringFormatNombrecomercial.Alignment = StringAlignment.Center
                    CadenaPorEscribirEnLinea = ordTot.ObtenerNombreComercial(Item)
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresionComercial, Brushes.Black, R1, StringFormatNombrecomercial)
                    lineaEspacioDatosEmpresa += 6

                    '//FUENTE DE IMPRESION
                    Dim FuenteImpresionDireccion = New Font("Segoe UI", 7, FontStyle.Bold)
                    '//se crea un rectangulo para manipular texto dentro del rectangulo
                    Dim R2 As New RectangleF(6, lineaEspacioDatosEmpresa, 130, 6)
                    '//STRING FORMAT DEL TEXTO PARA LA POSICION
                    Dim StringFormatDireccion As New StringFormat
                    StringFormat.Alignment = StringAlignment.Near
                    CadenaPorEscribirEnLinea = ordTot.ObtenerDireccionPrincipal(Item)
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresionDireccion, Brushes.Black, R2, StringFormatDireccion)
                    lineaEspacioDatosEmpresa += 6

                    '//FUENTE DE IMPRESION
                    '//se crea un rectangulo para manipular texto dentro del rectangulo
                    Dim R3 As New RectangleF(6, lineaEspacioDatosEmpresa, 130, 6)
                    '//STRING FORMAT DEL TEXTO PARA LA POSICION
                    'Dim StringFormatDireccion As New StringFormat
                    'StringFormatDireccion.Alignment = StringAlignment.Near
                    CadenaPorEscribirEnLinea = ordTot.ObtenerDireccionAnexo(Item)
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresionDireccion, Brushes.Black, R3, StringFormatDireccion)
                    lineaEspacioDatosEmpresa += 6

                    '//FUENTE DE IMPRESION
                    '//se crea un rectangulo para manipular texto dentro del rectangulo
                    Dim R4 As New RectangleF(6, lineaEspacioDatosEmpresa, 130, 6)
                    '//STRING FORMAT DEL TEXTO PARA LA POSICION
                    CadenaPorEscribirEnLinea = ordTot.ObtenerTelefono(Item)
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresionDireccion, Brushes.Black, R4, StringFormatDireccion)

                Next
        End Select


    End Sub

    '*****************************************************************************
    '****************************** NOMBRE DE DATOS COMPLEMENTARIOS ******************
    'Se declara el array para la Factura parte derecha
    Public LineasDeEncabezadoDerecha As ArrayList = New ArrayList()

    'Linea para capturar el ruc y numeroComprobante de la Factura
    Public Sub AnadirLineaEncabezadoDerecha(ByVal Ruc As String, ByVal NumeroFactura As String, tipoComprobante As String)
        Dim ordTot As OrdernarEncabezadoFactura = New OrdernarEncabezadoFactura()
        LineasDeEncabezadoDerecha.Add(ordTot.GenerarImprimir(Ruc, NumeroFactura, tipoComprobante))
    End Sub

    Public Sub DrawRoundedRectangle(ByVal objGraphics As Graphics,
                                    ByVal m_intxAxis As Integer,
                                    ByVal m_intyAxis As Integer,
                                    ByVal m_intWidth As Integer,
                                    ByVal m_intHeight As Integer,
                                    ByVal m_diameter As Integer)

        Dim blackPen As New Pen(Color.Black, 0)

        'Dim g As Graphics
        Dim BaseRect As New RectangleF(m_intxAxis, m_intyAxis, m_intWidth, m_intHeight)
        Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(m_diameter, m_diameter))

        'top left Arc
        objGraphics.DrawArc(blackPen, ArcRect, 180, 90)
        objGraphics.DrawLine(blackPen, m_intxAxis + CInt(m_diameter / 2), m_intyAxis, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis)

        ' top right arc
        ArcRect.X = BaseRect.Right - m_diameter
        objGraphics.DrawArc(blackPen, ArcRect, 270, 90)
        objGraphics.DrawLine(blackPen, m_intxAxis + m_intWidth, m_intyAxis + CInt(m_diameter / 2), m_intxAxis + m_intWidth, m_intyAxis + m_intHeight - CInt(m_diameter / 2))

        ' bottom right arc
        ArcRect.Y = BaseRect.Bottom - m_diameter
        objGraphics.DrawArc(blackPen, ArcRect, 0, 90)
        objGraphics.DrawLine(blackPen, m_intxAxis + CInt(m_diameter / 2), m_intyAxis + m_intHeight, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis + m_intHeight)

        ' bottom left arc
        ArcRect.X = BaseRect.Left
        objGraphics.DrawArc(blackPen, ArcRect, 90, 90)
        objGraphics.DrawLine(blackPen, m_intxAxis, m_intyAxis + CInt(m_diameter / 2), m_intxAxis, m_intyAxis + m_intHeight - CInt(m_diameter / 2))

    End Sub


    Private Sub DibujaLaCabeceraDerecha()
        '//COLOR DE LINEA Y GROSOR
        Dim blackPen As New Pen(Color.Black, 0)

        '//DIBUJA EL RECTANGULO 
        'gfx.DrawRectangle(blackPen, 134, 5, 68, 35)


        DrawRoundedRectangle(gfx, 134, 5, 66, 35, 10)

        '//ALINEAR EL TEXTO 
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Center

        '//LLAMA A LA CLASES PARA DIBUJAR LOS TEXTOS
        Dim ordTot As OrdernarEncabezadoFactura = New OrdernarEncabezadoFactura()

        '//FUENTE DE LA IMPRESION
        Dim FuenteImpresaEncabezado = New Font("Segoe UI", 16, FontStyle.Regular)

        '//IMPRIME LOS DATOS 
        For Each Cabecera As String In LineasDeEncabezadoDerecha
            '//DIBUJA UN RECTANGULO PARA MANIPULAR EL TEXTO DENTRO
            Dim R1 As New RectangleF(132, 8, 70, 40)
            CadenaPorEscribirEnLinea = ordTot.ObtenerNumeroRuc(Cabecera)
            gfx.DrawString("R.U.C. " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R1, StringFormat)
            '//DIBUJA UN RECTANGULO PARA MANIPULAR EL TEXTO DENTRO
            Dim R2 As New RectangleF(132, 17, 70, 40)
            CadenaPorEscribirEnLinea = ordTot.ObtenerTipoComprobante(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
            '//DIBUJA UN RECTANGULO PARA MANIPULAR EL TEXTO DENTRO
            Dim R3 As New RectangleF(132, 32, 70, 40)
            CadenaPorEscribirEnLinea = ordTot.ObtenerNumeroFactura(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R3, StringFormat)
        Next

    End Sub

#End Region

#Region "DATOS DEL CLIENTE"

    '*****************************************************************************
    '****************************** NOMBRE DE ENCABEZADO DATOS GENERALES ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasDeEncabezadoIzquierda As ArrayList = New ArrayList()

    '//AÑADIR LAS LINEAS DE DATOS DEL CLIENTE
    Public Sub AnadirLineaCaracteresDatosGEnerales(ByVal fechaEmisiom As String, ByVal fechaInicioTraslado As String,
                                                   ByVal motivoDeTraslado As String, ByVal ModalidadTransporte As String,
                                                  ByVal TipoDeTraslado As String, ByVal PesoBruto As String)

        Dim ordTot As OrdernarSubEncabezadoInicioTraslado = New OrdernarSubEncabezadoInicioTraslado()
        LineasDeEncabezadoIzquierda.Add(ordTot.GenerarImprimir(fechaEmisiom, fechaInicioTraslado, motivoDeTraslado, ModalidadTransporte,
                                                               TipoDeTraslado, PesoBruto))
    End Sub

    ' //Dibuja PARTE IZQUIERDA DE DATOS DEL CLIENTE
    Private Sub DibujaLaSubCabeceraIzquierda()

        '//FORMATO DEL TEXTO UBICACION
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Near
        '//LLAMA EL ENCABEZADO DE LA IMPRESION
        Dim ordTot As OrdernarSubEncabezadoInicioTraslado = New OrdernarSubEncabezadoInicioTraslado()
        'FUENTE DE LA IMPRESION Y TAMAÑO
        Dim FuenteImpresaEncabezadoTitulo = New Font("Segoe UI", 8, FontStyle.Bold)
        Dim FuenteImpresaEncabezado = New Font("Segoe UI", 7, FontStyle.Regular)

        '//DIBUJA EL RECTANGULO DE LOS DATOS DEL CLIENTE
        Dim blackPen As New Pen(Color.Black, 0)
        gfx.DrawRectangle(blackPen, 5, 43, 195, 25)

        '//SE IMPRIME LOS DATOS
        For Each Cabecera As String In LineasDeEncabezadoIzquierda

            'fechaEmisiom, fechaInicioTraslado, motivoDeTraslado, ModalidadTransporte,
            '                                                           TipoDeTraslado, PesoBruto

            'titulo
            Dim RT As New RectangleF(6, 43, 180, 23)
            CadenaPorEscribirEnLinea = "DATOS DEL INICIO DEL TRASLADO"
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTitulo, Brushes.Black, RT, StringFormat)

            '//SE CREA UN RECTANGULO
            Dim R2 As New RectangleF(60, 46, 180, 25)
            CadenaPorEscribirEnLinea = ordTot.OrdernarfechaEmision(Cabecera)
            gfx.DrawString("FECHA DE EMISIÓN", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 46, New StringFormat())
            gfx.DrawString(":", FuenteImpresaEncabezado, ColorDeLaFuente, 58, 46, New StringFormat())
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)


            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R3 As New RectangleF(60, 49, 180, 25)
            CadenaPorEscribirEnLinea = ordTot.ObtenerfechaInicioTraslado(Cabecera)
            gfx.DrawString("FECHA DE INICIO DE TRASLADO", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 49, New StringFormat())
            gfx.DrawString(":", FuenteImpresaEncabezado, ColorDeLaFuente, 58, 49, New StringFormat())
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R3, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R4 As New RectangleF(60, 52, 180, 25)
            'documkentop
            CadenaPorEscribirEnLinea = ordTot.ObtenermotivoDeTraslado(Cabecera)
            gfx.DrawString("MOTIVO DE TRASLADO", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 52, New StringFormat())
            gfx.DrawString(":", FuenteImpresaEncabezado, ColorDeLaFuente, 58, 52, New StringFormat())
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R4, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R5 As New RectangleF(60, 55, 180, 25)
            CadenaPorEscribirEnLinea = ordTot.ObtenerModalidadTransporte(Cabecera)
            gfx.DrawString("MODALIDAD DE TRANSPORTE", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 55, New StringFormat())
            gfx.DrawString(":", FuenteImpresaEncabezado, ColorDeLaFuente, 58, 55, New StringFormat())
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R5, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R6 As New RectangleF(60, 58, 180, 25)
            CadenaPorEscribirEnLinea = ordTot.ObtenerTipoDeTraslado(Cabecera)
            gfx.DrawString(":", FuenteImpresaEncabezado, ColorDeLaFuente, 58, 58, New StringFormat())
            gfx.DrawString("TIPO DE TRASLADO", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 58, New StringFormat())
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R6, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R7 As New RectangleF(60, 61, 180, 25)
            CadenaPorEscribirEnLinea = ordTot.ObtenerPesoBruto(Cabecera)
            gfx.DrawString(":", FuenteImpresaEncabezado, ColorDeLaFuente, 58, 61, New StringFormat())
            gfx.DrawString("PESO BRUTO TOTAL DE GUÍA (KGM)", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 61, New StringFormat())
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R7, StringFormat)


        Next

    End Sub

#End Region

#Region "DATOS COMPLEMEMTARIOS"
    '*****************************************************************************
    '****************************** NOMBRE DE ENCABEZADO DATOS GENERALES ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasDeDatosComplementarios As ArrayList = New ArrayList()

    '//AÑADIR LAS LINEAS DE DATOS DEL CLIENTE
    Public Sub AnadirLineaDatosComplementarios(ByVal nombre As String,
                                 ByVal documento As String)

        Dim ordTot As OrdernarDatosDEstinatario = New OrdernarDatosDEstinatario()
        LineasDeDatosComplementarios.Add(ordTot.GenerarTotal(nombre, documento))
    End Sub

    ' //Dibuja PARTE IZQUIERDA DE DATOS DEL CLIENTE
    Private Sub DibujaDatosComplemnetarios()

        '//FORMATO DEL TEXTO UBICACION
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Near
        '//LLAMA EL ENCABEZADO DE LA IMPRESION
        Dim ordTot As OrdernarDatosDEstinatario = New OrdernarDatosDEstinatario()
        'FUENTE DE LA IMPRESION Y TAMAÑO
        Dim FuenteImpresaEncabezado = New Font("Segoe UI", 7, FontStyle.Regular)
        Dim FuenteImpresaEncabezadoTITULO = New Font("Segoe UI", 8, FontStyle.Bold)
        '//DIBUJA EL RECTANGULO DE LOS DATOS DEL CLIENTE
        Dim blackPen As New Pen(Color.Black, 0)

        '//SE IMPRIME LOS DATOS
        For Each Cabecera As String In LineasDeDatosComplementarios

            '//SE CREA UN RECTANGULO
            Dim RT As New RectangleF(6, 69, 180, 3)
            CadenaPorEscribirEnLinea = "DATOS DEL DESTINATARIO"
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTITULO, Brushes.Black, RT, StringFormat)

            '//SE CREA UN RECTANGULO
            Dim R1 As New RectangleF(41, 72, 180, 3)
            gfx.DrawString("DENOMINACIÓN O RAZÓN", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 72, New StringFormat())
            gfx.DrawString(":", FuenteImpresaEncabezado, ColorDeLaFuente, 40, 72, New StringFormat())
            CadenaPorEscribirEnLinea = ordTot.ObtenerTotalNombre(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R1, StringFormat)

            ' '//SE CREA UN RECTANGULO
            Dim R2 As New RectangleF(41, 75, 180, 3)
            gfx.DrawString("DOCUMENTO DE IDENTIDAD", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 75, New StringFormat())
            gfx.DrawString(":", FuenteImpresaEncabezado, ColorDeLaFuente, 40, 75, New StringFormat())
            CadenaPorEscribirEnLinea = ordTot.ObtenerDocumento(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)

        Next

        '//SE DIBUJA TODA LAS LINEAS DE LOS DATOS COMPLEMENTARIOS
        gfx.DrawRectangle(blackPen, 5, 69, 195, 10)

    End Sub
#End Region

#Region "DATOS PUNTOS DE PARTIDA"
    '*****************************************************************************
    '****************************** NOMBRE DE ENCABEZADO DATOS GENERALES ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasDeDatosPuntoDePartida As ArrayList = New ArrayList()

    '//AÑADIR LAS LINEAS DE DATOS DEL CLIENTE
    Public Sub AnadirLineasDeDatosPuntoDePartida(ByVal Llegada As String,
                                 ByVal Partida As String)

        Dim ordTot As OrdernarDatosPuntosPartida = New OrdernarDatosPuntosPartida()
        LineasDeDatosPuntoDePartida.Add(ordTot.GenerarTotal(Llegada, Partida))
    End Sub

    ' //Dibuja PARTE IZQUIERDA DE DATOS DEL CLIENTE
    Private Sub DibujaDatosPuntosLLegadaPartida()

        '//FORMATO DEL TEXTO UBICACION
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Near
        '//LLAMA EL ENCABEZADO DE LA IMPRESION
        Dim ordTot As OrdernarDatosPuntosPartida = New OrdernarDatosPuntosPartida()
        'FUENTE DE LA IMPRESION Y TAMAÑO
        Dim FuenteImpresaEncabezado = New Font("Segoe UI", 7, FontStyle.Regular)
        Dim FuenteImpresaEncabezadoTITULO = New Font("Segoe UI", 8, FontStyle.Bold)
        '//DIBUJA EL RECTANGULO DE LOS DATOS DEL CLIENTE
        Dim blackPen As New Pen(Color.Black, 0)

        '//SE IMPRIME LOS DATOS
        For Each Cabecera As String In LineasDeDatosPuntoDePartida

            '//SE CREA UN RECTANGULO
            Dim RT As New RectangleF(6, 80, 180, 3)
            CadenaPorEscribirEnLinea = "DATOS DE PUNTO DE PARTIDA Y PUNTOS DE LEGADA"
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTITULO, Brushes.Black, RT, StringFormat)

            '//SE CREA UN RECTANGULO
            Dim R1 As New RectangleF(31, 83, 180, 3)
            gfx.DrawString("PUNTO DE PARTIDA", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 83, New StringFormat())
            gfx.DrawString(":", FuenteImpresaEncabezado, ColorDeLaFuente, 30, 83, New StringFormat())
            CadenaPorEscribirEnLinea = ordTot.ObtenerPartida(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R1, StringFormat)

            ' '//SE CREA UN RECTANGULO
            Dim R2 As New RectangleF(31, 86, 180, 3)
            gfx.DrawString("PUNTO DE LLEGADA", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 86, New StringFormat())
            gfx.DrawString(":", FuenteImpresaEncabezado, ColorDeLaFuente, 30, 86, New StringFormat())
            CadenaPorEscribirEnLinea = ordTot.ObtenerLlegada(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)

        Next

        '//SE DIBUJA TODA LAS LINEAS DE LOS DATOS COMPLEMENTARIOS
        gfx.DrawRectangle(blackPen, 5, 80, 195, 10)

    End Sub
#End Region

#Region "DATOS DEL TRANSPORTE"
    '*****************************************************************************
    '****************************** NOMBRE DE ENCABEZADO DATOS GENERALES ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasDeDatosTransporte As ArrayList = New ArrayList()

    '//AÑADIR LAS LINEAS DE DATOS DEL CLIENTE
    Public Sub AnadirLineasDeDatosTransporte(ByVal NroPLaca As String)

        Dim ordTot As OrdernarDatosTransportistas = New OrdernarDatosTransportistas()
        LineasDeDatosTransporte.Add(ordTot.GenerarTotal(NroPLaca))
    End Sub

    ' //Dibuja PARTE IZQUIERDA DE DATOS DEL CLIENTE
    Private Sub DibujaDatosTransporte()

        '//FORMATO DEL TEXTO UBICACION
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Near
        '//LLAMA EL ENCABEZADO DE LA IMPRESION
        Dim ordTot As OrdernarDatosTransportistas = New OrdernarDatosTransportistas()
        'FUENTE DE LA IMPRESION Y TAMAÑO
        Dim FuenteImpresaEncabezado = New Font("Segoe UI", 7, FontStyle.Regular)
        Dim FuenteImpresaEncabezadoTITULO = New Font("Segoe UI", 8, FontStyle.Bold)
        '//DIBUJA EL RECTANGULO DE LOS DATOS DEL CLIENTE
        Dim blackPen As New Pen(Color.Black, 0)
        Dim LINEA As Integer = 276
        '//SE IMPRIME LOS DATOS
        For Each Cabecera As String In LineasDeDatosTransporte
            '//SE CREA UN RECTANGULO
            Dim R1 As New RectangleF(30, LINEA, 180, 3)
            CadenaPorEscribirEnLinea = ordTot.ObtenerNroPLaca(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R1, StringFormat)
            LINEA = LINEA + 3
        Next

    End Sub
#End Region

#Region "DATOS DEL CONDUCTOR"
    '*****************************************************************************
    '****************************** NOMBRE DE ENCABEZADO DATOS GENERALES ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasDeDatosConductor As ArrayList = New ArrayList()

    '//AÑADIR LAS LINEAS DE DATOS DEL CLIENTE
    Public Sub AnadirLineasDeDatosConductor(ByVal TipoDoc As String,
                                 ByVal NroDoc As String)

        Dim ordTot As OrdernarDatosConductor = New OrdernarDatosConductor()
        LineasDeDatosConductor.Add(ordTot.GenerarTotal(TipoDoc, NroDoc))
    End Sub

    ' //Dibuja PARTE IZQUIERDA DE DATOS DEL CLIENTE
    Private Sub DibujaDatosConductor()

        '//FORMATO DEL TEXTO UBICACION
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Near
        '//LLAMA EL ENCABEZADO DE LA IMPRESION
        Dim ordTot As OrdernarDatosConductor = New OrdernarDatosConductor()
        'FUENTE DE LA IMPRESION Y TAMAÑO
        Dim FuenteImpresaEncabezado = New Font("Segoe UI", 7, FontStyle.Regular)
        Dim FuenteImpresaEncabezadoTITULO = New Font("Segoe UI", 8, FontStyle.Bold)
        '//DIBUJA EL RECTANGULO DE LOS DATOS DEL CLIENTE
        Dim blackPen As New Pen(Color.Black, 0)
        Dim LINEA As Integer = 255
        '//SE IMPRIME LOS DATOS
        For Each Cabecera As String In LineasDeDatosConductor

            '//SE CREA UN RECTANGULO
            Dim R1 As New RectangleF(30, LINEA, 180, 3)
            CadenaPorEscribirEnLinea = ordTot.ObtenerTipoDoc(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R1, StringFormat)

            ' '//SE CREA UN RECTANGULO
            Dim R2 As New RectangleF(60, LINEA, 180, 3)
            CadenaPorEscribirEnLinea = ordTot.ObtenerNroDoc(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)
            LINEA = LINEA + 3
        Next

    End Sub
#End Region


#Region "DATOS DETALLE DE VENTA"
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
                                      ByVal UM As String, ByVal PrecioVenta As String, ByVal VentaTotal As String)

        Dim ordTot As OrdenarElementoFacturaXPagina = New OrdenarElementoFacturaXPagina()
        LineasElementosFacturaPorPaginacion.Add(ordTot.GenerarImprimir(numeracion, codigo, Descripcion, cantidad, UM,
                                                          PrecioVenta, VentaTotal))
    End Sub


    Private Sub DibujaElementosFactura(i As ArrayList)
        '//LINEA DONDE COMIENZA A DIBUJAR LOS DETALLES
        lineaEspacio = 98
        '//LLAMA A LOS DATOS DE LOS DETALLES
        Dim ordTot As OrdenarElementoFacturaXPagina = New OrdenarElementoFacturaXPagina()
        '//FUENTES DE LA IMPRESO
        Dim FuenteImpresaDetalle = New Font("Segoe UI", 8, FontStyle.Regular)
        Dim FuenteImpresaEncabezado = New Font("Segoe UI", 9, FontStyle.Bold)
        '//COLOR DE LA IMPRESION
        Dim blackPen As New Pen(Color.Black, 0)
        '//TEXTO DEL ENCABEZADO
        gfx.DrawString("NRO.                                                 DESCRIPCIÓN                                                                  COD.                 UM               CANTIDAD", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 92, New StringFormat())

        '//SE CREA EL CUADRO O TABLAS DE LOS DETALLES
        gfx.DrawRectangle(blackPen, 5, 91, 195, 7)
        'crear la fila codigo
        gfx.DrawRectangle(blackPen, 5, 91, 10, 155)
        'crear la fila descrpcion
        gfx.DrawRectangle(blackPen, 15, 91, 118, 155)

        'crear la fila cantidad
        gfx.DrawRectangle(blackPen, 133, 91, 18, 155)
        ''crear la fila PRECIO UNITARIO
        gfx.DrawRectangle(blackPen, 151, 91, 24, 155)
        ''crear la fila Venta Total
        gfx.DrawRectangle(blackPen, 175, 91, 25, 155)


        Dim elemento As String = "", espacios As String = ""
        Dim nroEspacios As Integer = 0
        Dim PrecioVenta As String = String.Empty
        Dim ValidarTotal As String = String.Empty
        Dim Cantidad As String = String.Empty
        Dim Codigo As String = String.Empty
        'Dim numeracion As Integer = 0
        Dim um As String = String.Empty
        Dim descripcion As String = String.Empty


        For Each Item As String In i

            '//CODIGO DEL IMPRESION
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R1 As New RectangleF(5, lineaEspacio, 9, 130)
            Codigo = 0.0
            Codigo = ordTot.OptenerCodigo(Item)
            'Colocar la cantidad a la derecha.
            Dim StringFormatCodigo As New StringFormat
            StringFormatCodigo.Alignment = StringAlignment.Far
            CadenaPorEscribirEnLinea = Codigo
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R1, StringFormatCodigo)



            '//CODIGO DEL CANTIDAD
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R2 As New RectangleF(131, lineaEspacio, 20, 130)
            Cantidad = 0.0
            Cantidad = ordTot.ObtenerCantidad(Item)
            'Colocar la cantidad a la derecha.
            Dim StringFormatCantidad As New StringFormat
            StringFormatCantidad.Alignment = StringAlignment.Far
            CadenaPorEscribirEnLinea = Cantidad
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R2, StringFormatCantidad)

            '//CODIGO DEL PRECIO UNITARIO
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R5 As New RectangleF(151, lineaEspacio, 24, 130)
            'Colocar la cantidad a la derecha.
            Dim StringFormatPrecioUnit As New StringFormat
            StringFormatPrecioUnit.Alignment = StringAlignment.Far
            PrecioVenta = 0.0
            PrecioVenta = ordTot.ObtenerPrecioVenta(Item)
            CadenaPorEscribirEnLinea = PrecioVenta
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R5, StringFormatPrecioUnit)

            '//CODIGO DE LA VENTA TOTAL
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R6 As New RectangleF(175, lineaEspacio, 25, 130)
            'Colocar la cantidad a la derecha.
            Dim StringFormatTotal As New StringFormat
            StringFormatTotal.Alignment = StringAlignment.Far
            ValidarTotal = 0.0
            elemento = String.Empty
            ValidarTotal = ordTot.ObtenerVentaTotal(Item)
            CadenaPorEscribirEnLinea = ValidarTotal '.TrimStart("0")
            'CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R6, StringFormatTotal)

            '//CODIGO DEL LA DESCRIPCION DEL PRODCUTO
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R3 As New RectangleF(16, lineaEspacio, 118, 130)
            Dim total As Integer
            Dim nombreArticlo As String
            'Dim enviarNombre As String
            nombreArticlo = ordTot.ObtenerDescripcion(Item)
            'Colocar la cantidad a la derecha.
            Dim StringFormatDescrip As New StringFormat
            StringFormatDescrip.Alignment = StringAlignment.Near

            If (nombreArticlo.Length > 60) Then
                total = nombreArticlo.Length / 65
                CadenaPorEscribirEnLinea = nombreArticlo
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R3, StringFormatDescrip)
                lineaEspacio += (3 * total)
            Else
                CadenaPorEscribirEnLinea = nombreArticlo
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R3, StringFormatDescrip)

            End If
            '        ' //OTROS DEATALLES DE LA IMPRESION
            '        contadorPagina += 1
            '        If (contadorPagina = 49) Then

            '            contadorPagina = 0
            '        End If
            lineaEspacio += 5

        Next Item
    End Sub

    '//DIBUJA EN MEMORIA LAS PAGINAS QUE SE IMPRIMIRA 
    Private Sub lineasTotal()
        Dim total As Integer

        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdenarElementoFactura = New OrdenarElementoFactura()
        'Fuente de la impresion
        Dim FuenteImpresaDetalle = New Font("Tahoma", 8, FontStyle.Regular)
        Dim FuenteImpresaEncabezado = New Font("Tahoma", 8, FontStyle.Regular)
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

        For Each Item As String In LineasElementosFactura

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R1 As New RectangleF(15, lineaEspacio, 20, 130)
            Codigo = 0.0
            Codigo = ordTot.OptenerCodigo(Item)
            'Colocar la cantidad a la derecha.
            Dim StringFormatCodigo As New StringFormat
            StringFormatCodigo.Alignment = StringAlignment.Far
            CadenaPorEscribirEnLinea = Codigo


            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R4 As New RectangleF(126, lineaEspacio, 10, 130)
            'Colocar la cantidad a la derecha.
            Dim StringFormatUM As New StringFormat
            StringFormatUM.Alignment = StringAlignment.Near
            CadenaPorEscribirEnLinea = ordTot.ObtenerUM(Item)


            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R2 As New RectangleF(135, lineaEspacio, 20, 130)
            Cantidad = 0.0
            Cantidad = ordTot.ObtenerCantidad(Item)
            'Colocar la cantidad a la derecha.
            Dim StringFormatCantidad As New StringFormat
            StringFormatCantidad.Alignment = StringAlignment.Far
            CadenaPorEscribirEnLinea = Cantidad

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R5 As New RectangleF(155, lineaEspacio, 24, 130)
            'Colocar la cantidad a la derecha.
            Dim StringFormatPrecioUnit As New StringFormat
            StringFormatPrecioUnit.Alignment = StringAlignment.Far
            PrecioVenta = 0.0
            PrecioVenta = ordTot.ObtenerPrecioVenta(Item)
            CadenaPorEscribirEnLinea = PrecioVenta

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R6 As New RectangleF(179, lineaEspacio, 25, 130)
            'Colocar la cantidad a la derecha.
            Dim StringFormatTotal As New StringFormat
            StringFormatTotal.Alignment = StringAlignment.Far
            ValidarTotal = 0.0
            elemento = String.Empty
            ValidarTotal = ordTot.ObtenerVentaTotal(Item)
            CadenaPorEscribirEnLinea = ValidarTotal '.TrimStart("0")

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R3 As New RectangleF(36, lineaEspacio, 90, 130)
            Dim nombreArticlo As String
            nombreArticlo = ordTot.ObtenerDescripcion(Item)
            'Colocar la cantidad a la derecha.
            Dim StringFormatDescrip As New StringFormat
            StringFormatDescrip.Alignment = StringAlignment.Near
            If (nombreArticlo.Length > 60) Then
                total = nombreArticlo.Length / 65
                CadenaPorEscribirEnLinea = nombreArticlo
                lineaEspacio += (3 * total)
            Else
                CadenaPorEscribirEnLinea = nombreArticlo
            End If
            lineaEspacio += 5

            AnadirLineaElementosFacturaXPagina("", Codigo, ordTot.ObtenerDescripcion(Item), ordTot.ObtenerCantidad(Item), ordTot.ObtenerUM(Item), ordTot.ObtenerPrecioVenta(Item), ordTot.ObtenerVentaTotal(Item))



            If (lineaEspacio >= 240) Then
                lineaEspacio = 95
                If (LineasElementosFacturaPorPaginacion.Count > 0) Then
                    listaPaginas.Add(LineasElementosFacturaPorPaginacion)
                    LineasElementosFacturaPorPaginacion = New ArrayList
                End If
            End If
        Next Item

        If (LineasElementosFacturaPorPaginacion.Count > 0) Then
            listaPaginas.Add(LineasElementosFacturaPorPaginacion)
        End If
        listaArrays = listaPaginas.Count


    End Sub

#End Region

#Region "DATOS FINALES DE LA FACTURA"
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
        Dim FuenteImpresaTitulo = New Font("Segoe UI", 8, FontStyle.Bold)
        Dim FuenteImpresaEncabezado = New Font("Segoe UI", 7, FontStyle.Regular)
        Dim FuenteImpresaEncabezadoNroCuenta = New Font("Segoe UI", 7, FontStyle.Regular)
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        Dim contadorDatos As Integer = 0

        gfx.DrawRectangle(blackPen, 5, 247, 120, 42)
        gfx.DrawRectangle(blackPen, 126, 247, 74, 42)

        '//TITULO
        CadenaPorEscribirEnLinea = "DATOS DE LOS CONDUCTORES"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaTitulo, ColorDeLaFuente, 6, contadorDatos + 248, New StringFormat())


        '//TITULO
        CadenaPorEscribirEnLinea = "NRO."
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 6, contadorDatos + 252, New StringFormat())

        CadenaPorEscribirEnLinea = "TIPO DOC."
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 30, contadorDatos + 252, New StringFormat())


        CadenaPorEscribirEnLinea = "NRO. DOCUMENTO"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 60, contadorDatos + 252, New StringFormat())


        '//TITULO
        CadenaPorEscribirEnLinea = "DATOS DE LOS VEHICULOS"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaTitulo, ColorDeLaFuente, 6, contadorDatos + 270, New StringFormat())

        CadenaPorEscribirEnLinea = "NRO."
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 6, contadorDatos + 273, New StringFormat())

        CadenaPorEscribirEnLinea = "NRO. DE PLACA"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 30, contadorDatos + 273, New StringFormat())


        For Each Elemento As String In LineasDatosComplementaria

            CadenaPorEscribirEnLinea = ordTot.ObtenerTotalNroCuentaSoles(Elemento)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoNroCuenta, ColorDeLaFuente, 40, 260, New StringFormat())

            CadenaPorEscribirEnLinea = ordTot.ObtenerTotalNroCuentaSoles2(Elemento)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoNroCuenta, ColorDeLaFuente, 40, 263, New StringFormat())

            CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNroCuentaDolares(Elemento))
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoNroCuenta, ColorDeLaFuente, 40, 274, New StringFormat())

            CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNroCuentaDolares2(Elemento))
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoNroCuenta, ColorDeLaFuente, 40, 277, New StringFormat())

            CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalDescripcion(Elemento))
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoNroCuenta, ColorDeLaFuente, 5, 282, New StringFormat())

        Next


    End Sub
#End Region





End Class