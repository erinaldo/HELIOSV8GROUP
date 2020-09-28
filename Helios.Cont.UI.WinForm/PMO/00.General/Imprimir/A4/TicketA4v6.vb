Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO

Public Class TicketA4v6

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
    Public lineaEspacio As Integer = 70
    Dim listaPaginas As New List(Of ArrayList)
    Dim listaArrays As Integer = 0
    Dim comienzo As Integer = 0
    Public tipoComprobante As String = String.Empty
    Public TipoMoneda As String = String.Empty
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
                'DibujaDatosComplemnetarios()
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
                            listaPaginas.RemoveAt(0)
                            'comienzo += 1
                            Exit Sub 'es necesario el Exit Sub, si no cae en un bucle 
                    End Select
                Next
            End If
            e.HasMorePages = False
            Exit Sub
        Next
    End Sub

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

    Private Sub DrawImageQR()
        Try
            If (Not IsNothing(headerImageQR.Width)) Then
                If (headerImageQR.Width <> 0) Then
                    Dim destRect As New Rectangle(6, 250, 28, 28)

                    gfx.DrawImage(headerImagenQR, destRect)
                    Dim height As Double = (headerImagenQR.Height / 200)
                    imageQR = CInt(Math.Round(height) + 3)
                    'lineaEspacio = lineaEspacio + 22
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "GUARDARIMPRSION"
    Public Function GuardanImpresion(ByVal impresora As String, ByVal NombreNumero As String) As String

        If (File.Exists(Path.Combine("C:\FACTURASELECTRONICAS\PDF\", NombreNumero & ".pdf"))) Then
            Kill(Path.Combine("C:\FACTURASELECTRONICAS\PDF\", NombreNumero & ".pdf"))
        End If

        DocumentoAImprimir.PrinterSettings.PrinterName = impresora
        My.Computer.FileSystem.CreateDirectory("C:\FACTURASELECTRONICAS\PDF\")
        DocumentoAImprimir.PrinterSettings.PrintToFile = True
        DocumentoAImprimir.PrinterSettings.PrintFileName = Path.Combine("C:\FACTURASELECTRONICAS\PDF\", NombreNumero & ".pdf")
        lineasTotal()
        DocumentoAImprimir.Print()

        Return Path.Combine("C:\FACTURASELECTRONICAS\PDF\", NombreNumero & ".pdf")

    End Function
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


        DrawRoundedRectangle(gfx, 134, 5, 68, 35, 10)

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
            Dim R2 As New RectangleF(132, 20, 70, 40)
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
    Public Sub AnadirLineaCaracteresDatosGEnerales(ByVal fechaEmisiom As String, ByVal Lugar As String,
                                                   ByVal Nombre As String, ByVal direccion As String,
                                                  ByVal direccionEntrega As String, ByVal docIdentidad As String,
                                                  ByVal moneda As String, ByVal telefono As String)

        Dim ordTot As OrdernarSubEncabezadoDatosGenerales = New OrdernarSubEncabezadoDatosGenerales()
        LineasDeEncabezadoIzquierda.Add(ordTot.GenerarImprimir(fechaEmisiom, Lugar, Nombre, direccion,
                                                               direccionEntrega, docIdentidad, moneda, telefono))
    End Sub

    ' //Dibuja PARTE IZQUIERDA DE DATOS DEL CLIENTE
    Private Sub DibujaLaSubCabeceraIzquierda()

        '//FORMATO DEL TEXTO UBICACION
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Near
        '//LLAMA EL ENCABEZADO DE LA IMPRESION
        Dim ordTot As OrdernarSubEncabezadoDatosGenerales = New OrdernarSubEncabezadoDatosGenerales()
        'FUENTE DE LA IMPRESION Y TAMAÑO
        Dim FuenteImpresaEncabezado = New Font("Segoe UI", 7, FontStyle.Regular)

        '//DIBUJA EL RECTANGULO DE LOS DATOS DEL CLIENTE
        Dim blackPen As New Pen(Color.Black, 0)
        gfx.DrawRectangle(blackPen, 5, 43, 197, 17)

        '//SE IMPRIME LOS DATOS
        For Each Cabecera As String In LineasDeEncabezadoIzquierda
            '//SE CREA UN RECTANGULO
            Dim R2 As New RectangleF(26, 44, 180, 3)
            CadenaPorEscribirEnLinea = ordTot.OrdernarfechaEmision(Cabecera)
            gfx.DrawString("FECHA", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 44, New StringFormat())
            gfx.DrawString(":", FuenteImpresaEncabezado, ColorDeLaFuente, 25, 44, New StringFormat())
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R7 As New RectangleF(149, 44, 180, 3)
            CadenaPorEscribirEnLinea = ordTot.Obtenermoneda(Cabecera)
            gfx.DrawString(":", FuenteImpresaEncabezado, ColorDeLaFuente, 147, 44, New StringFormat())
            gfx.DrawString("TIPO MONEDA", FuenteImpresaEncabezado, ColorDeLaFuente, 130, 44, New StringFormat())
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R7, StringFormat)


            Dim NuevoCaracter As String
            NuevoCaracter = ordTot.ObtenerNombre(Cabecera)
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R3 As New RectangleF(26, 47, 180, 3)
            CadenaPorEscribirEnLinea = NuevoCaracter
            gfx.DrawString("CLIENTE", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 47, New StringFormat())
            gfx.DrawString(":", FuenteImpresaEncabezado, ColorDeLaFuente, 25, 47, New StringFormat())
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R3, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R4 As New RectangleF(26, 50, 180, 3)
            'documkentop
            CadenaPorEscribirEnLinea = ordTot.ObtenerdocIdentidad(Cabecera)
            gfx.DrawString("DOC. IDENTIDAD", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 50, New StringFormat())
            gfx.DrawString(":", FuenteImpresaEncabezado, ColorDeLaFuente, 25, 50, New StringFormat())
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R4, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R5 As New RectangleF(26, 53, 180, 3)
            'direccioon
            NuevoCaracter = ordTot.Obtenerdireccion(Cabecera)

            CadenaPorEscribirEnLinea = ordTot.Obtenerdireccion(Cabecera)
            gfx.DrawString("DIRECCION", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 53, New StringFormat())
            gfx.DrawString(":", FuenteImpresaEncabezado, ColorDeLaFuente, 25, 53, New StringFormat())
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R5, StringFormat)

            ''se crea un rectangulo para manipular texto dentro del rectangulo
            'Dim R6 As New RectangleF(26, 56, 180, 3)
            'NuevoCaracter = ordTot.ObtenerdireccionEntrega(Cabecera)
            'CadenaPorEscribirEnLinea = NuevoCaracter
            'gfx.DrawString(":", FuenteImpresaEncabezado, ColorDeLaFuente, 25, 56, New StringFormat())
            'gfx.DrawString("COMPRADOR", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 56, New StringFormat())
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R6, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R6 As New RectangleF(26, 56, 180, 3)
            NuevoCaracter = ordTot.ObtenerdireccionEntrega(Cabecera)
            CadenaPorEscribirEnLinea = NuevoCaracter
            gfx.DrawString(":", FuenteImpresaEncabezado, ColorDeLaFuente, 25, 56, New StringFormat())
            gfx.DrawString("VENDEDOR", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 56, New StringFormat())
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R6, StringFormat)

        Next

    End Sub

#End Region

#Region "DATOS COMPLEMEMTARIOS"
    '*****************************************************************************
    '****************************** NOMBRE DE ENCABEZADO DATOS GENERALES ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public LineasDeDatosComplementarios As ArrayList = New ArrayList()

    '//AÑADIR LAS LINEAS DE DATOS DEL CLIENTE
    Public Sub AnadirLineaDatosComplementarios(ByVal NroPedido As String,
                                 ByVal FechaPedido As String,
                                 ByVal OrdenCompra As String,
                                 ByVal FechaOrden As String,
                                 ByVal GuiaRemision As String,
                                 ByVal FechaGuia As String,
                                 ByVal FormaPago As String,
                                 ByVal TipoVenta As String)

        Dim ordTot As OrdernarDatosComplementarios = New OrdernarDatosComplementarios()
        LineasDeDatosComplementarios.Add(ordTot.GenerarTotal(NroPedido, FechaPedido, OrdenCompra, FechaOrden,
                                                               GuiaRemision, FechaGuia, FormaPago, TipoVenta))
    End Sub

    ' //Dibuja PARTE IZQUIERDA DE DATOS DEL CLIENTE
    Private Sub DibujaDatosComplemnetarios()

        '//FORMATO DEL TEXTO UBICACION
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Center
        '//LLAMA EL ENCABEZADO DE LA IMPRESION
        Dim ordTot As OrdernarDatosComplementarios = New OrdernarDatosComplementarios()
        'FUENTE DE LA IMPRESION Y TAMAÑO
        Dim FuenteImpresaEncabezado = New Font("Segoe UI", 7, FontStyle.Regular)

        '//DIBUJA EL RECTANGULO DE LOS DATOS DEL CLIENTE
        Dim blackPen As New Pen(Color.Black, 0)

        '//SE IMPRIME LOS DATOS
        For Each Cabecera As String In LineasDeDatosComplementarios
            '//SE CREA UN RECTANGULO
            'Dim R1 As New RectangleF(6, 80, 45, 3)
            'CadenaPorEscribirEnLinea = ordTot.ObtenerNroPedido(Cabecera)
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R1, StringFormat)

            '' '//SE CREA UN RECTANGULO
            'Dim R2 As New RectangleF(6, 82, 35, 3)
            'CadenaPorEscribirEnLinea = ordTot.ObtenerFechaPedido(Cabecera)
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)

            '//SE CREA UN RECTANGULO
            Dim R3 As New RectangleF(6, 80, 65, 3)
            CadenaPorEscribirEnLinea = ordTot.ObtenerOrdenCompra(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R3, StringFormat)

            '' '//SE CREA UN RECTANGULO
            'Dim R4 As New RectangleF(45, 82, 35, 3)
            'CadenaPorEscribirEnLinea = ordTot.ObtenerFechaOrden(Cabecera)
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R4, StringFormat)

            '//SE CREA UN RECTANGULO
            Dim R5 As New RectangleF(70, 80, 65, 3)
            CadenaPorEscribirEnLinea = ordTot.ObtenerGuiaRemision(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R5, StringFormat)

            '' '//SE CREA UN RECTANGULO
            'Dim R6 As New RectangleF(84, 82, 35, 3)
            'CadenaPorEscribirEnLinea = ordTot.ObtenerFechaGuia(Cabecera)
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R6, StringFormat)

            '//SE CREA UN RECTANGULO
            Dim R7 As New RectangleF(135, 80, 67, 3)
            CadenaPorEscribirEnLinea = ordTot.ObtenerTipoVenta(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R7, StringFormat)

            '' '//SE CREA UN RECTANGULO
            'Dim R8 As New RectangleF(162, 80, 38, 3)
            'CadenaPorEscribirEnLinea = ordTot.ObtenerTipoVenta(Cabecera)
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R8, StringFormat)

        Next

        '//TITULO DE LOS DATOS COMPLEMENTARIO
        Dim FuenteImpresaComplemeneto = New Font("Segoe UI", 7, FontStyle.Bold)
        gfx.DrawString("                                Orden de Compra                                                              Guía de Remisión                                                                     Guía de Transportista", FuenteImpresaComplemeneto, ColorDeLaFuente, 5, 71, New StringFormat())

        '//SE DIBUJA TODA LAS LINEAS DE LOS DATOS COMPLEMENTARIOS
        gfx.DrawRectangle(blackPen, 5, 67, 197, 10)
        gfx.DrawRectangle(blackPen, 5, 67, 65, 19)
        'gfx.DrawRectangle(blackPen, 50, 67, 45, 19)
        gfx.DrawRectangle(blackPen, 70, 67, 65, 19)
        'gfx.DrawRectangle(blackPen, 122, 69, 39, 17)
        gfx.DrawRectangle(blackPen, 135, 67, 67, 19)

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
                                      ByVal UM As String, ByVal PrecioVenta As String, ByVal VentaTotal As Decimal)

        Dim ordTot As OrdenarElementoFacturaXPagina = New OrdenarElementoFacturaXPagina()
        LineasElementosFacturaPorPaginacion.Add(ordTot.GenerarImprimir(numeracion, codigo, Descripcion, cantidad, UM,
                                                          PrecioVenta, VentaTotal))
    End Sub

    'Dibuja `parte de la derecha de la factura
    Private Sub DibujaElementosFactura(i As ArrayList)
        '//LINEA DONDE COMIENZA A DIBUJAR LOS DETALLES
        lineaEspacio = 70
        '//LLAMA A LOS DATOS DE LOS DETALLES
        Dim ordTot As OrdenarElementoFacturaXPagina = New OrdenarElementoFacturaXPagina()
        '//FUENTES DE LA IMPRESO
        Dim FuenteImpresaDetalle = New Font("Segoe UI", 8, FontStyle.Regular)
        Dim FuenteImpresaEncabezado = New Font("Segoe UI", 9, FontStyle.Bold)
        '//COLOR DE LA IMPRESION
        Dim blackPen As New Pen(Color.Black, 0)
        '//TEXTO DEL ENCABEZADO
        gfx.DrawString("    Cantidad                                                       Descripciòn                                                              UM      Precio Unit.           Valor Total", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 63, New StringFormat())

        '//SE CREA EL CUADRO O TABLAS DE LOS DETALLES
        'crear rectangulo d e la cabecera
        gfx.DrawRectangle(blackPen, 5, 61, 197, 7)

        'crear la fila codigo
        gfx.DrawRectangle(blackPen, 5, 61, 20, 175)
        'crear la fila descrpcion
        gfx.DrawRectangle(blackPen, 25, 61, 118, 175)
        'crear la fila um
        gfx.DrawRectangle(blackPen, 143, 61, 10, 175)
        ''crear la fila Venta Total
        gfx.DrawRectangle(blackPen, 153, 61, 24, 175)
        ''crear la fila Venta Total
        gfx.DrawRectangle(blackPen, 177, 61, 25, 175)


        Dim elemento As String = "", espacios As String = ""
        Dim nroEspacios As Integer = 0
        Dim PrecioVenta As String = String.Empty
        Dim ValidarTotal As String = String.Empty
        Dim Cantidad As String = String.Empty
        Dim Codigo As String = String.Empty
        'Dim numeracion As Integer = 0
        Dim um As String = String.Empty
        Dim descripcion As String = String.Empty
        Dim contadorPagina As Integer = 0

        For Each Item As String In i

            '//CODIGO DEL IMPRESION
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R1 As New RectangleF(4, lineaEspacio, 20, 130)
            Codigo = 0.0
            Codigo = ordTot.ObtenerCantidad(Item)
            'Colocar la cantidad a la derecha.
            Dim StringFormatCodigo As New StringFormat
            StringFormatCodigo.Alignment = StringAlignment.Far
            CadenaPorEscribirEnLinea = Codigo
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R1, StringFormatCodigo)

            '//CODIGO DEL UM
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R4 As New RectangleF(144, lineaEspacio, 10, 130)
            'Colocar la cantidad a la derecha.
            Dim StringFormatUM As New StringFormat
            StringFormatUM.Alignment = StringAlignment.Near
            CadenaPorEscribirEnLinea = ordTot.ObtenerUM(Item)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R4, StringFormatUM)


            '//CODIGO DEL PRECIO UNITARIO
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R5 As New RectangleF(153, lineaEspacio, 24, 130)
            'Colocar la cantidad a la derecha.
            Dim StringFormatPrecioUnit As New StringFormat
            StringFormatPrecioUnit.Alignment = StringAlignment.Far
            PrecioVenta = 0.0
            PrecioVenta = FormatNumber(ordTot.ObtenerPrecioVenta(Item), 2)
            CadenaPorEscribirEnLinea = PrecioVenta
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R5, StringFormatPrecioUnit)

            '//CODIGO DE LA VENTA TOTAL
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R6 As New RectangleF(177, lineaEspacio, 25, 130)
            'Colocar la cantidad a la derecha.
            Dim StringFormatTotal As New StringFormat
            StringFormatTotal.Alignment = StringAlignment.Far
            ValidarTotal = 0.0
            elemento = String.Empty
            ValidarTotal = FormatNumber(ordTot.ObtenerVentaTotal(Item), 2)
            CadenaPorEscribirEnLinea = ValidarTotal '.TrimStart("0")
            'CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R6, StringFormatTotal)

            '//CODIGO DEL LA DESCRIPCION DEL PRODCUTO
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R3 As New RectangleF(26, lineaEspacio, 115, 130)
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
            ' //OTROS DEATALLES DE LA IMPRESION
            contadorPagina += 1
            If (contadorPagina = 49) Then

                contadorPagina = 0
            End If
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
            PrecioVenta = FormatNumber(ordTot.ObtenerPrecioVenta(Item), 2)
            CadenaPorEscribirEnLinea = PrecioVenta

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R6 As New RectangleF(179, lineaEspacio, 25, 130)
            'Colocar la cantidad a la derecha.
            Dim StringFormatTotal As New StringFormat
            StringFormatTotal.Alignment = StringAlignment.Far
            ValidarTotal = 0.0
            elemento = String.Empty
            ValidarTotal = FormatNumber(ordTot.ObtenerVentaTotal(Item), 2)
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

            AnadirLineaElementosFacturaXPagina("", Codigo, ordTot.ObtenerDescripcion(Item), ordTot.ObtenerCantidad(Item), ordTot.ObtenerUM(Item), FormatNumber(ordTot.ObtenerPrecioVenta(Item), 2), CDec(FormatNumber(ordTot.ObtenerVentaTotal(Item), 2)))

            If (lineaEspacio >= 225) Then
            lineaEspacio = 70
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

#Region "DATOS DETALLE TOTALES"
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
        Dim FuenteImpresaEncabezado = New Font("Lucida Console", 8, FontStyle.Regular)
        Dim FuenteImpresaEncabezadoTexto = New Font("Segoe UI", 8, FontStyle.Regular)
        'Se dibuja uin rectangulo parte derecha
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)

        ''Crear texto del EncabezaDO
        'crear el Rectanguilo del importe General
        gfx.DrawRectangle(blackPen, 139, 237, 63, 41)
        'gfx.DrawRectangle(blackPen, 140, 261, 65, 20)

        'Encabezados de los importes Generales
        CadenaPorEscribirEnLinea = "OP. GRATUITAS"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 238, New StringFormat())

        CadenaPorEscribirEnLinea = "OP. EXONERADAS"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 242, New StringFormat())

        CadenaPorEscribirEnLinea = "OP. INAFECTO"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 246, New StringFormat())

        CadenaPorEscribirEnLinea = "OP. GRAVADA"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 250, New StringFormat())

        CadenaPorEscribirEnLinea = "TOTL DSCTO."
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 254, New StringFormat())

        CadenaPorEscribirEnLinea = "ISC"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 258, New StringFormat())

        CadenaPorEscribirEnLinea = "IGV"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 262, New StringFormat())

        CadenaPorEscribirEnLinea = "ICBPER"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 266, New StringFormat())

        CadenaPorEscribirEnLinea = "IMPORTE TOTAL"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 270, New StringFormat())

        'Importes CApturados del sistema
        For Each Elemento As String In LineasTotalFactura

            CadenaPorEscribirEnLinea = "0.00"
            CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 155, contadorGeneral + 238, New StringFormat())

            CadenaPorEscribirEnLinea = "0.00"
            CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 174, contadorGeneral + 238, New StringFormat())
            contadorGeneral += 4

        Next

    End Sub

    Private Sub DibujaTotalFacturaFinal()
        Dim contadorGeneral As Integer = 0
        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarTotalFactura = New OrdernarTotalFactura()
        'Fuente de la impresion
        Dim FuenteImpresaEncabezado = New Font("Lucida Console", 8, FontStyle.Regular)
        Dim FuenteImpresaEncabezadoTexto = New Font("Segoe UI", 8, FontStyle.Regular)
        'Se dibuja uin rectangulo parte derecha
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)

        ''Crear texto del EncabezaDO
        'crear el Rectanguilo del importe General
        gfx.DrawRectangle(blackPen, 139, 237, 63, 41)
        'gfx.DrawRectangle(blackPen, 140, 261, 65, 20)

        'Encabezados de los importes Generales
        CadenaPorEscribirEnLinea = "OP. GRATUITAS"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 238, New StringFormat())

        CadenaPorEscribirEnLinea = "OP. EXONERADAS"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 242, New StringFormat())

        CadenaPorEscribirEnLinea = "OP. INAFECTO"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 246, New StringFormat())

        CadenaPorEscribirEnLinea = "OP. GRAVADA"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 250, New StringFormat())

        CadenaPorEscribirEnLinea = "TOTL DSCTO."
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 254, New StringFormat())

        CadenaPorEscribirEnLinea = "ISC"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 258, New StringFormat())

        CadenaPorEscribirEnLinea = "IGV"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 262, New StringFormat())

        CadenaPorEscribirEnLinea = "ICBPER"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 266, New StringFormat())

        CadenaPorEscribirEnLinea = "IMPORTE TOTAL"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 270, New StringFormat())


        'Importes CApturados del sistema
        For Each Elemento As String In LineasTotalFactura

            CadenaPorEscribirEnLinea = ordTot.ObtenerTotalNombre(Elemento)
            CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 155, contadorGeneral + 238, New StringFormat())

            CadenaPorEscribirEnLinea = FormatNumber(ordTot.ObtenerTotalImporte(Elemento), 2)
            CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 174, contadorGeneral + 238, New StringFormat())
            contadorGeneral += 4

        Next

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
    'Dibuja `parte de la derecha de la factura
    Private Sub DibujaDatosGenerales(Paginacion As String)

        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarDatosComplentarias = New OrdernarDatosComplentarias()
        'Fuente de la impresion
        Dim FuenteImpresaTitulo = New Font("Segoe UI", 7, FontStyle.Underline)
        Dim FuenteImpresaEncabezado = New Font("Segoe UI", 7, FontStyle.Regular)
        Dim FuenteImpresaEncabezadoNroCuenta = New Font("Segoe UI", 7, FontStyle.Regular)
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0)
        Dim contadorDatos As Integer = 0

        'crear restangulo con se describe el monto total del importe
        gfx.DrawRectangle(blackPen, 5, 237, 133, 10)
        'crear rectangulo con esta el codigo qr
        gfx.DrawRectangle(blackPen, 5, 248, 133, 30)


        'gfx.DrawLine(blackPen, 105, 280, 138, 280)
        ''linea de la fimar
        'gfx.DrawLine(blackPen, 105, 255, 105, 285)
        ''crear la fila cantidad

        '//TITULO
        CadenaPorEscribirEnLinea = "CUENTA ES SOLES:"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaTitulo, ColorDeLaFuente, 35, contadorDatos + 249, New StringFormat())

        'CadenaPorEscribirEnLinea = "CUENTA EN DOLARES:"
        'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaTitulo, ColorDeLaFuente, 40, contadorDatos + 270, New StringFormat())


        For Each Elemento As String In LineasDatosComplementaria
            CadenaPorEscribirEnLinea = ordTot.ObtenerTotalNombre(Elemento)
            Dim conver As String
            Dim numeroConverson As Decimal = Convert.ToDecimal(CadenaPorEscribirEnLinea)
            conver = Conversion.Enletras(numeroConverson)

            If (TipoMoneda = "SOL") Then
                gfx.DrawString(conver & " SOLES", FuenteImpresaEncabezado, ColorDeLaFuente, 11, 240, New StringFormat())
            Else
                'gfx.DrawString(conver & " DOLARES AMERICANOS", FuenteImpresaEncabezado, ColorDeLaFuente, 11, 249, New StringFormat())
            End If

            CadenaPorEscribirEnLinea = ordTot.ObtenerTotalNroCuentaSoles(Elemento)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoNroCuenta, ColorDeLaFuente, 35, 251, New StringFormat())

            CadenaPorEscribirEnLinea = ordTot.ObtenerTotalNroCuentaSoles2(Elemento)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoNroCuenta, ColorDeLaFuente, 35, 254, New StringFormat())

            'CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNroCuentaDolares(Elemento))
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoNroCuenta, ColorDeLaFuente, 40, 274, New StringFormat())

            'CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalNroCuentaDolares2(Elemento))
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoNroCuenta, ColorDeLaFuente, 40, 277, New StringFormat())

            CadenaPorEscribirEnLinea = (ordTot.ObtenerTotalDescripcion(Elemento))
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoNroCuenta, ColorDeLaFuente, 5, 282, New StringFormat())

        Next

        'CadenaPorEscribirEnLinea = ""
        'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 23, contadorDatos + 222, New StringFormat())

        'CadenaPorEscribirEnLinea = "RECIBI CONFORME"
        'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 110, contadorDatos + 256, New StringFormat())

        'CadenaPorEscribirEnLinea = "Firma"
        'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 116, contadorDatos + 280, New StringFormat())

        If (tipoComprobante = "2") Then

            CadenaPorEscribirEnLinea = "Representación impresa del comprobante electrónico. Autorizado mediante resolución"
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 35, contadorDatos + 259, New StringFormat())

            CadenaPorEscribirEnLinea = "N° 034-005-0010982. Puede consultar su comprobante electrónico en"
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 35, contadorDatos + 262, New StringFormat())

            CadenaPorEscribirEnLinea = "http://www.spk.com.pe/"
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 35, contadorDatos + 265, New StringFormat())

            CadenaPorEscribirEnLinea = "Conserve su comprobante por regulación de SUNAT es indispensable presentarlo para"
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 35, contadorDatos + 268, New StringFormat())

            CadenaPorEscribirEnLinea = "cambios o devoluciones. Todo cambio o devolución es personal o dentro de los 7 días"
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 35, contadorDatos + 271, New StringFormat())

            CadenaPorEscribirEnLinea = "posteriores a la compra."
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 35, contadorDatos + 274, New StringFormat())

        End If

    End Sub
#End Region

End Class