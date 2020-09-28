Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO

Public Class EmbarqueTransporte

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
    Public tipoEncabezado As Boolean

    Public conductor1 As String
    Public licencia1 As String
    Public conductor2 As String
    Public licencia2 As String
    Public ayudante As String


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
        e.Graphics.PageUnit = GraphicsUnit.Millimeter
        gfx = e.Graphics

        imageHeight = 0
        DrawImage()

        If (PosicionLogo <> "IT") Then
            DibujaDatosEmpresa()
        End If

        DibujaLaCabeceraDerecha()
        'DibujaDatosComplemnetarios()
        'DibujaDatosGenerales(1)
        DibujaLaSubCabeceraIzquierda()
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
                    listaPaginas.RemoveAt(comienzo)
                    comienzo += 1
                    Exit Sub 'es necesario el Exit Sub, si no cae en un bucle 
            End Select
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
                    Dim destRect As New Rectangle(8, 256, 28, 28)

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
    Public Sub GuardanImpresion(ByVal impresora As String, ByVal NombreNumero As String, txtEmailEmpresa As String,
                             txtContrasenaEmpresa As String, txtEmailDestino As String, txtDescripcion As String,
                             txtAsunto As String)

        DocumentoAImprimir.PrinterSettings.PrinterName = impresora
        My.Computer.FileSystem.CreateDirectory("C:\FACTURASELECTRONICAS\PDF\")
        DocumentoAImprimir.PrinterSettings.PrintToFile = True
        DocumentoAImprimir.PrinterSettings.PrintFileName = Path.Combine("C:\FACTURASELECTRONICAS\PDF\", NombreNumero & ".pdf")
        lineasTotal()
        DocumentoAImprimir.Print()
        'enviarCorreo(txtEmailEmpresa, txtContrasenaEmpresa, txtEmailDestino, txtDescripcion, NombreNumero, NombreNumero)

    End Sub
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
                    Dim R2 As New RectangleF(5, lineaEspacioDatosEmpresa, 130, 4)
                    '//STRING FORMAT DEL TEXTO PARA LA POSICION
                    Dim StringFormatDireccion As New StringFormat
                    StringFormat.Alignment = StringAlignment.Near
                    CadenaPorEscribirEnLinea = ordTot.ObtenerDireccionPrincipal(Item)
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresionDireccion, Brushes.Black, R2, StringFormatDireccion)
                    lineaEspacioDatosEmpresa += 3

                    '//FUENTE DE IMPRESION
                    '//se crea un rectangulo para manipular texto dentro del rectangulo
                    Dim R3 As New RectangleF(5, lineaEspacioDatosEmpresa, 130, 4)
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
                    Dim FuenteImpresion = New Font("Segoe UI", 14, FontStyle.Bold)
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
                    Dim FuenteImpresionComercial = New Font("Segoe UI", 8, FontStyle.Bold)
                    '//se crea un rectangulo para manipular texto dentro del rectangulo
                    Dim R1 As New RectangleF(6, lineaEspacioDatosEmpresa, 130, 6)
                    '//STRING FORMAT DEL TEXTO PARA LA POSICION
                    Dim StringFormatNombrecomercial As New StringFormat
                    StringFormatNombrecomercial.Alignment = StringAlignment.Center
                    CadenaPorEscribirEnLinea = ordTot.ObtenerNombreComercial(Item)
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresionComercial, Brushes.Black, R1, StringFormatNombrecomercial)
                    lineaEspacioDatosEmpresa += 6

                    '//FUENTE DE IMPRESION
                    Dim FuenteImpresionDireccion = New Font("Segoe UI", 8, FontStyle.Bold)
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

        Dim blackPen As New Pen(Color.Black, 0.5)

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
        '//COLOR DE LINEA Y GROSO
        Dim blackPen As New Pen(Color.Black, 1)

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

        Dim FuenteImpresaEncabezado2 = New Font("Segoe UI", 13, FontStyle.Regular)

        '//IMPRIME LOS DATOS 
        For Each Cabecera As String In LineasDeEncabezadoDerecha
            '//DIBUJA UN RECTANGULO PARA MANIPULAR EL TEXTO DENTRO
            Dim R1 As New RectangleF(132, 8, 70, 40)
            CadenaPorEscribirEnLinea = ordTot.ObtenerNumeroRuc(Cabecera)
            gfx.DrawString("R.U.C. " & CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R1, StringFormat)
            '//DIBUJA UN RECTANGULO PARA MANIPULAR EL TEXTO DENTRO
            Dim R2 As New RectangleF(132, 20, 70, 40)
            CadenaPorEscribirEnLinea = ordTot.ObtenerTipoComprobante(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado2, Brushes.Black, R2, StringFormat)
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
    Public Sub AnadirLineaCaracteresDatosGEnerales(ByVal fechaEmisiom As String, ByVal Lugar As String, ByVal habitacion As String,
                                      ByVal TipoHabitacion As String, ByVal fechaIN As String, ByVal fechaON As String,
                                    ByVal dias As String,
                                                   ByVal Nombre As String, ByVal direccion As String,
                                                  ByVal direccionEntrega As String, ByVal docIdentidad As String,
                                                  ByVal moneda As String, ByVal telefono As String,
                                    ByVal conductor1 As String, ByVal Licencia As String, ByVal conductor2 As String,
                                    ByVal Licencia2 As String, ByVal ayudante As String)

        Dim ordTot As OrdernarSubEncabezadoDatosGeneralesTransporte = New OrdernarSubEncabezadoDatosGeneralesTransporte()
        LineasDeEncabezadoIzquierda.Add(ordTot.GenerarImprimir(fechaEmisiom, Lugar, habitacion, TipoHabitacion,
                                                               fechaIN, fechaON, dias, Nombre, direccion,
                                                               direccionEntrega, docIdentidad, moneda, telefono,
conductor1, Licencia, conductor2, Licencia2, ayudante))
    End Sub

    ' //Dibuja PARTE IZQUIERDA DE DATOS DEL CLIENTE
    Private Sub DibujaLaSubCabeceraIzquierda()

        '//FORMATO DEL TEXTO UBICACION
        Dim StringFormat As New StringFormat
        StringFormat.Alignment = StringAlignment.Near
        '//LLAMA EL ENCABEZADO DE LA IMPRESION
        Dim ordTot As OrdernarSubEncabezadoDatosGeneralesTransporte = New OrdernarSubEncabezadoDatosGeneralesTransporte()
        'FUENTE DE LA IMPRESION Y TAMAÑO
        Dim FuenteImpresaEncabezado = New Font("Segoe UI", 9, FontStyle.Regular)
        Dim FuenteImpresa = New Font("Segoe UI", 10, FontStyle.Bold)

        '//DIBUJA EL RECTANGULO DE LOS DATOS DEL CLIENTE
        Dim blackPen As New Pen(Color.Black, 0.1)
        gfx.DrawRectangle(blackPen, 5, 43, 78, 43)


        gfx.DrawLine(blackPen, 58, 47, 58, 59)
        gfx.DrawLine(blackPen, 35, 67, 35, 86)
        gfx.DrawLine(blackPen, 73, 59, 73, 67)

        gfx.DrawLine(blackPen, 160, 47, 160, 55)
        gfx.DrawLine(blackPen, 130, 47, 130, 55)
        gfx.DrawLine(blackPen, 110, 59, 110, 86)

        '//bijuar todo interior
        gfx.DrawRectangle(blackPen, 5, 43, 78, 4)
        gfx.DrawRectangle(blackPen, 35, 47, 48, 4)
        gfx.DrawRectangle(blackPen, 35, 51, 48, 4)
        gfx.DrawRectangle(blackPen, 35, 55, 48, 4)
        gfx.DrawRectangle(blackPen, 5, 59, 78, 4)
        gfx.DrawRectangle(blackPen, 5, 63, 78, 4)
        gfx.DrawRectangle(blackPen, 5, 67, 78, 4)
        gfx.DrawRectangle(blackPen, 5, 71, 78, 4)
        gfx.DrawRectangle(blackPen, 5, 75, 78, 4)
        gfx.DrawRectangle(blackPen, 5, 79, 78, 4)

        '//SE CREA UN RECTANGULO
        Dim R11 As New RectangleF(25, 43, 75, 4)
        gfx.DrawString("DATOS DEL VIAJE", FuenteImpresa, Brushes.Black, R11, StringFormat)

        '//SE CREA UN RECTANGULO
        Dim R12 As New RectangleF(40, 47, 75, 4)
        gfx.DrawString("Pasajeros", FuenteImpresaEncabezado, Brushes.Black, R12, StringFormat)

        '//SE CREA UN RECTANGULO
        Dim R13 As New RectangleF(40, 51, 75, 4)
        gfx.DrawString("Tripulantes", FuenteImpresaEncabezado, Brushes.Black, R13, StringFormat)

        '//SE CREA UN RECTANGULO
        Dim R14 As New RectangleF(40, 55, 75, 4)
        gfx.DrawString("Total", FuenteImpresaEncabezado, Brushes.Black, R14, StringFormat)

        '//SE CREA UN RECTANGULO
        Dim R15 As New RectangleF(5, 59, 75, 4)
        gfx.DrawString("Pasajeros embarcados en el terminal", FuenteImpresaEncabezado, Brushes.Black, R15, StringFormat)

        '//SE CREA UN RECTANGULO
        Dim R16 As New RectangleF(5, 63, 75, 4)
        gfx.DrawString("Pasajeros recogidos en paraderos y estaciones", FuenteImpresaEncabezado, Brushes.Black, R16, StringFormat)

        '//SE CREA UN RECTANGULO
        Dim R17 As New RectangleF(5, 67, 75, 4)
        gfx.DrawString("Ciudad de Origen", FuenteImpresaEncabezado, Brushes.Black, R17, StringFormat)

        '//SE CREA UN RECTANGULO
        Dim R18 As New RectangleF(5, 71, 75, 4)
        gfx.DrawString("Ciudad de Destino", FuenteImpresaEncabezado, Brushes.Black, R18, StringFormat)

        '//SE CREA UN RECTANGULO
        Dim R19 As New RectangleF(5, 75, 75, 4)
        gfx.DrawString("Fecha de Salida", FuenteImpresaEncabezado, Brushes.Black, R19, StringFormat)

        '//SE CREA UN RECTANGULO
        Dim R20 As New RectangleF(5, 79, 75, 4)
        gfx.DrawString("Hora de Salida", FuenteImpresaEncabezado, Brushes.Black, R20, StringFormat)

        '////////////////////////////////////////////////////////////////////////////////////////////////////

        gfx.DrawRectangle(blackPen, 84, 43, 118, 43)


        '//dibjar a la derecha
        gfx.DrawRectangle(blackPen, 84, 43, 118, 4)
        gfx.DrawRectangle(blackPen, 84, 47, 118, 4)
        gfx.DrawRectangle(blackPen, 84, 51, 118, 4)
        gfx.DrawRectangle(blackPen, 84, 55, 118, 4)
        gfx.DrawRectangle(blackPen, 84, 59, 118, 4)
        gfx.DrawRectangle(blackPen, 84, 63, 118, 4)
        gfx.DrawRectangle(blackPen, 84, 67, 118, 4)
        gfx.DrawRectangle(blackPen, 84, 71, 118, 4)
        gfx.DrawRectangle(blackPen, 84, 75, 118, 4)
        gfx.DrawRectangle(blackPen, 84, 79, 118, 4)


        '//SE CREA UN RECTANGULO
        Dim R21 As New RectangleF(125, 43, 118, 4)
        gfx.DrawString("DATOS DEL VEHICULO", FuenteImpresa, Brushes.Black, R21, StringFormat)

        '//SE CREA UN RECTANGULO
        Dim R23 As New RectangleF(100, 47, 118, 4)
        gfx.DrawString("Marca", FuenteImpresaEncabezado, Brushes.Black, R23, StringFormat)

        '//SE CREA UN RECTANGULO
        Dim R24 As New RectangleF(140, 47, 118, 4)
        gfx.DrawString("Placa", FuenteImpresaEncabezado, Brushes.Black, R24, StringFormat)

        '//SE CREA UN RECTANGULO
        Dim R25 As New RectangleF(180, 47, 118, 4)
        gfx.DrawString("Pisos", FuenteImpresaEncabezado, Brushes.Black, R25, StringFormat)

        '//SE CREA UN RECTANGULO
        Dim R26 As New RectangleF(120, 55, 118, 4)
        gfx.DrawString("DATOS DE LA TRIPULACION", FuenteImpresa, Brushes.Black, R26, StringFormat)

        '//SE CREA UN RECTANGULO
        Dim R27 As New RectangleF(85, 59, 118, 4)
        gfx.DrawString("Conductor:", FuenteImpresaEncabezado, Brushes.Black, R27, StringFormat)

        '//SE CREA UN RECTANGULO
        Dim R28 As New RectangleF(85, 63, 118, 4)
        gfx.DrawString("Licencia", FuenteImpresaEncabezado, Brushes.Black, R28, StringFormat)

        '//SE CREA UN RECTANGULO
        Dim R29 As New RectangleF(85, 67, 118, 4)
        gfx.DrawString("Conductor 2:", FuenteImpresaEncabezado, Brushes.Black, R29, StringFormat)

        '//SE CREA UN RECTANGULO
        Dim R30 As New RectangleF(85, 71, 118, 4)
        gfx.DrawString("Licencia", FuenteImpresaEncabezado, Brushes.Black, R30, StringFormat)

        '//SE CREA UN RECTANGULO
        Dim R31 As New RectangleF(85, 75, 118, 4)
        gfx.DrawString("Ayudante", FuenteImpresaEncabezado, Brushes.Black, R31, StringFormat)

        '//SE IMPRIME LOS DATOS
        For Each Cabecera As String In LineasDeEncabezadoIzquierda

            '            fechaEmisiom, Lugar, habitacion, TipoHabitacion,
            '                                                               fechaIN, fechaON, dias, Nombre, direccion,
            '                                                               direccionEntrega, docIdentidad, moneda, telefono,
            'conductor1, Licencia, conductor2, Licencia2, ayudante


            '//SE CREA UN RECTANGULO
            Dim R2 As New RectangleF(60, 47, 180, 25)
            CadenaPorEscribirEnLinea = ordTot.OrdernarfechaEmision(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R2, StringFormat)

            ''Dim NuevoCaracter As String

            ''NuevoCaracter = ordTot.ObtenerNombre(Cabecera)

            Dim R3 As New RectangleF(60, 51, 180, 25)
            CadenaPorEscribirEnLinea = ordTot.ObtenerLugar(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R3, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R4 As New RectangleF(60, 55, 180, 25)
            CadenaPorEscribirEnLinea = ordTot.ObtenerHabitacion(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R4, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R5 As New RectangleF(75, 59, 180, 25)
            CadenaPorEscribirEnLinea = ordTot.ObtenerTipoHabitacion(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R5, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R6 As New RectangleF(75, 63, 180, 25)
            CadenaPorEscribirEnLinea = ordTot.ObtenerFechaIN(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R6, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R7 As New RectangleF(38, 67, 180, 25)
            CadenaPorEscribirEnLinea = ordTot.ObtenerFechaON(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R7, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R8 As New RectangleF(38, 71, 180, 25)
            CadenaPorEscribirEnLinea = ordTot.ObtenerDias(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R8, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R9 As New RectangleF(38, 75, 180, 25)
            CadenaPorEscribirEnLinea = ordTot.ObtenerNombre(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R9, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R10 As New RectangleF(38, 79, 180, 25)
            CadenaPorEscribirEnLinea = ordTot.Obtenerdireccion(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R10, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R111 As New RectangleF(85, 51, 180, 25)
            CadenaPorEscribirEnLinea = ordTot.ObtenerdireccionEntrega(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R111, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R112 As New RectangleF(131, 51, 180, 25)
            CadenaPorEscribirEnLinea = ordTot.ObtenerdocIdentidad(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R112, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R113 As New RectangleF(161, 51, 180, 25)
            CadenaPorEscribirEnLinea = ordTot.Obtenermoneda(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R113, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R114 As New RectangleF(112, 59, 180, 25)
            CadenaPorEscribirEnLinea = conductor1
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R114, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R115 As New RectangleF(112, 63, 180, 25)
            CadenaPorEscribirEnLinea = licencia1
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R115, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R116 As New RectangleF(112, 67, 180, 25)
            CadenaPorEscribirEnLinea = conductor2
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R116, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R117 As New RectangleF(112, 71, 180, 25)
            CadenaPorEscribirEnLinea = licencia2
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R117, StringFormat)

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R118 As New RectangleF(112, 75, 180, 25)
            CadenaPorEscribirEnLinea = ayudante
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R118, StringFormat)

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
        Dim FuenteImpresaEncabezado = New Font("Segoe UI", 9, FontStyle.Regular)

        '//DIBUJA EL RECTANGULO DE LOS DATOS DEL CLIENTE
        Dim blackPen As New Pen(Color.Black, 0.5)

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
            Dim R3 As New RectangleF(6, 80, 65, 4)
            CadenaPorEscribirEnLinea = ordTot.ObtenerOrdenCompra(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R3, StringFormat)

            '' '//SE CREA UN RECTANGULO
            'Dim R4 As New RectangleF(45, 82, 35, 3)
            'CadenaPorEscribirEnLinea = ordTot.ObtenerFechaOrden(Cabecera)
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R4, StringFormat)

            '//SE CREA UN RECTANGULO
            Dim R5 As New RectangleF(70, 80, 65, 4)
            CadenaPorEscribirEnLinea = ordTot.ObtenerGuiaRemision(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R5, StringFormat)

            '' '//SE CREA UN RECTANGULO
            'Dim R6 As New RectangleF(84, 82, 35, 3)
            'CadenaPorEscribirEnLinea = ordTot.ObtenerFechaGuia(Cabecera)
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R6, StringFormat)

            '//SE CREA UN RECTANGULO
            Dim R7 As New RectangleF(135, 80, 67, 4)
            CadenaPorEscribirEnLinea = ordTot.ObtenerTipoVenta(Cabecera)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R7, StringFormat)

            '' '//SE CREA UN RECTANGULO
            'Dim R8 As New RectangleF(162, 80, 38, 3)
            'CadenaPorEscribirEnLinea = ordTot.ObtenerTipoVenta(Cabecera)
            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, Brushes.Black, R8, StringFormat)

        Next

        '//TITULO DE LOS DATOS COMPLEMENTARIO
        Dim FuenteImpresaComplemeneto = New Font("Segoe UI", 9, FontStyle.Bold)
        gfx.DrawString("                    Orden de Compra                                             Guía de Remisión                            Guía de Remisión de Transportista", FuenteImpresaComplemeneto, ColorDeLaFuente, 5, 71, New StringFormat())

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
        lineaEspacio = 95
        '//LLAMA A LOS DATOS DE LOS DETALLES
        Dim ordTot As OrdenarElementoFacturaXPagina = New OrdenarElementoFacturaXPagina()
        '//FUENTES DE LA IMPRESO
        Dim FuenteImpresaDetalle = New Font("Segoe UI", 8, FontStyle.Regular)
        Dim FuenteImpresaEncabezado = New Font("Segoe UI", 8, FontStyle.Bold)
        '//COLOR DE LA IMPRESION
        Dim blackPen As New Pen(Color.Black, 0.1)
        '//TEXTO DEL ENCABEZADO
        gfx.DrawString("ASIENTO                                  APELLIDOS Y NOMBRES                           EDAD         DNI                  DESTINO                       BOLETO            IMP. TOTAL", FuenteImpresaEncabezado, ColorDeLaFuente, 6, 88, New StringFormat())

        '//SE CREA EL CUADRO O TABLAS DE LOS DETALLES
        'crear rectangulo d e la cabecera
        gfx.DrawRectangle(blackPen, 5, 87, 197, 6)

        'crear la fila codigo
        gfx.DrawRectangle(blackPen, 5, 87, 14, 200)
        'crear la fila descrpcion
        gfx.DrawRectangle(blackPen, 19, 87, 78, 200)
        'crear la fila um
        gfx.DrawRectangle(blackPen, 97, 87, 10, 200)
        'crear la fila DNI
        gfx.DrawRectangle(blackPen, 107, 87, 19, 200)
        'crear la fila DESTINO
        gfx.DrawRectangle(blackPen, 126, 87, 28, 200)
        ''crear la fila Venta Tota
        gfx.DrawRectangle(blackPen, 154, 87, 27, 200)
        ''crear la fila Venta Total
        gfx.DrawRectangle(blackPen, 181, 87, 21, 200)


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
            Dim R1 As New RectangleF(7, lineaEspacio, 10, 200)
            Codigo = 0.0
            Codigo = ordTot.OptenerCodigo(Item)
            'Colocar la cantidad a la derecha.
            Dim StringFormatCodigo As New StringFormat
            StringFormatCodigo.Alignment = StringAlignment.Center
            CadenaPorEscribirEnLinea = Codigo
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R1, StringFormatCodigo)

            '//CODIGO DEL UM
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R4 As New RectangleF(100, lineaEspacio, 10, 200)
            'Colocar la cantidad a la derecha.
            Dim StringFormatUM As New StringFormat
            StringFormatUM.Alignment = StringAlignment.Near
            CadenaPorEscribirEnLinea = ordTot.ObtenerUM(Item)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R4, StringFormatUM)


            '//CODIGO DEL PRECIO UNITARIO
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R5 As New RectangleF(154, lineaEspacio, 30, 200)
            'Colocar la cantidad a la derecha.
            Dim StringFormatPrecioUnit As New StringFormat
            StringFormatPrecioUnit.Alignment = StringAlignment.Near
            PrecioVenta = 0.0
            PrecioVenta = ordTot.ObtenerPrecioVenta(Item)
            CadenaPorEscribirEnLinea = PrecioVenta
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R5, StringFormatPrecioUnit)

            '//CODIGO DE LA VENTA TOTAL
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R6 As New RectangleF(177, lineaEspacio, 25, 200)
            'Colocar la cantidad a la derecha.
            Dim StringFormatTotal As New StringFormat
            StringFormatTotal.Alignment = StringAlignment.Far
            ValidarTotal = 0.0
            elemento = String.Empty
            ValidarTotal = FormatNumber(ordTot.ObtenerVentaTotal(Item), 2)
            CadenaPorEscribirEnLinea = ValidarTotal '.TrimStart("0")
            'CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R6, StringFormatTotal)


            '//CODIGO DE LA DESTINO
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R66 As New RectangleF(127, lineaEspacio, 30, 200)
            'Colocar la cantidad a la derecha.
            Dim StringFormatDestino As New StringFormat
            StringFormatDestino.Alignment = StringAlignment.Near
            CadenaPorEscribirEnLinea = ordTot.ObtenerCantidad(Item)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R66, StringFormatDestino)

            '//CODIGO DE LA DESTINO
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R15 As New RectangleF(109, lineaEspacio, 30, 200)
            'Colocar la cantidad a la derecha.
            Dim StringFormatnumeracion As New StringFormat
            StringFormatnumeracion.Alignment = StringAlignment.Center
            CadenaPorEscribirEnLinea = ordTot.OptenerNumeracion(Item)
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaDetalle, Brushes.Black, R15, StringFormatDestino)

            '//CODIGO DEL LA DESCRIPCION DEL PRODCUTO
            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R3 As New RectangleF(19, lineaEspacio, 115, 200)
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
            lineaEspacio += 3

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
            Dim R1 As New RectangleF(15, lineaEspacio, 20, 200)
            Codigo = 0.0
            Codigo = ordTot.OptenerCodigo(Item)
            'Colocar la cantidad a la derecha.
            Dim StringFormatCodigo As New StringFormat
            StringFormatCodigo.Alignment = StringAlignment.Far
            CadenaPorEscribirEnLinea = Codigo


            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R4 As New RectangleF(126, lineaEspacio, 10, 200)
            'Colocar la cantidad a la derecha.
            Dim StringFormatUM As New StringFormat
            StringFormatUM.Alignment = StringAlignment.Near
            CadenaPorEscribirEnLinea = ordTot.ObtenerUM(Item)


            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R2 As New RectangleF(135, lineaEspacio, 20, 200)
            Cantidad = 0.0
            Cantidad = ordTot.ObtenerCantidad(Item)
            'Colocar la cantidad a la derecha.
            Dim StringFormatCantidad As New StringFormat
            StringFormatCantidad.Alignment = StringAlignment.Far
            CadenaPorEscribirEnLinea = Cantidad

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R5 As New RectangleF(155, lineaEspacio, 24, 200)
            'Colocar la cantidad a la derecha.
            Dim StringFormatPrecioUnit As New StringFormat
            StringFormatPrecioUnit.Alignment = StringAlignment.Far
            PrecioVenta = 0.0
            PrecioVenta = (ordTot.ObtenerPrecioVenta(Item))
            CadenaPorEscribirEnLinea = PrecioVenta

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R6 As New RectangleF(179, lineaEspacio, 25, 200)
            'Colocar la cantidad a la derecha.
            Dim StringFormatTotal As New StringFormat
            StringFormatTotal.Alignment = StringAlignment.Far
            ValidarTotal = 0.0
            elemento = String.Empty
            ValidarTotal = FormatNumber(ordTot.ObtenerVentaTotal(Item), 2)
            CadenaPorEscribirEnLinea = ValidarTotal '.TrimStart("0")

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R66 As New RectangleF(179, lineaEspacio, 25, 200)
            'Colocar la cantidad a la derecha.
            Dim StringFormatDestino As New StringFormat
            StringFormatDestino.Alignment = StringAlignment.Far
            CadenaPorEscribirEnLinea = ordTot.ObtenerImpuestos(Item) '.TrimStart("0")

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R77 As New RectangleF(179, lineaEspacio, 25, 200)
            'Colocar la cantidad a la derecha.
            Dim StringFormatNumeracion As New StringFormat
            StringFormatNumeracion.Alignment = StringAlignment.Far
            CadenaPorEscribirEnLinea = ordTot.ObtenerOtrosCargos(Item) '.TrimStart("0")

            'se crea un rectangulo para manipular texto dentro del rectangulo
            Dim R3 As New RectangleF(36, lineaEspacio, 90, 200)
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
            lineaEspacio += 3

            AnadirLineaElementosFacturaXPagina(ordTot.ObtenerOtrosCargos(Item), Codigo, ordTot.ObtenerDescripcion(Item), ordTot.ObtenerCantidad(Item), ordTot.ObtenerUM(Item), ordTot.ObtenerPrecioVenta(Item), CDec(FormatNumber(ordTot.ObtenerVentaTotal(Item), 2)))
            If (lineaEspacio >= 350) Then
                lineaEspacio = 95
                listaPaginas.Add(LineasElementosFacturaPorPaginacion)
                LineasElementosFacturaPorPaginacion = New ArrayList
            End If
        Next Item

        listaPaginas.Add(LineasElementosFacturaPorPaginacion)
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
        Dim FuenteImpresaEncabezado = New Font("Lucida Console", 9, FontStyle.Regular)
        Dim FuenteImpresaEncabezadoTexto = New Font("Segoe UI", 9, FontStyle.Regular)
        'Se dibuja uin rectangulo parte derecha
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0.5)

        ''Crear texto del EncabezaDO
        'crear el Rectanguilo del importe General
        gfx.DrawRectangle(blackPen, 139, 244, 63, 41)
        'gfx.DrawRectangle(blackPen, 140, 261, 65, 20)

        'Encabezados de los importes Generales
        CadenaPorEscribirEnLinea = "OP. GRATUITAS"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 245, New StringFormat())

        CadenaPorEscribirEnLinea = "OP. EXONERADAS"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 250, New StringFormat())

        CadenaPorEscribirEnLinea = "OP. INAFECTO"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 255, New StringFormat())

        CadenaPorEscribirEnLinea = "OP. GRAVADA"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 260, New StringFormat())

        CadenaPorEscribirEnLinea = "TOTL DSCTO."
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 265, New StringFormat())

        CadenaPorEscribirEnLinea = "I.S.C."
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 270, New StringFormat())

        CadenaPorEscribirEnLinea = "I.G.V."
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 275, New StringFormat())

        CadenaPorEscribirEnLinea = "IMPORTE TOTAL"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 280, New StringFormat())


        'Importes CApturados del sistema
        For Each Elemento As String In LineasTotalFactura

            CadenaPorEscribirEnLinea = "0.00"
            CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 155, contadorGeneral + 245, New StringFormat())

            CadenaPorEscribirEnLinea = "0.00"
            CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 170, contadorGeneral + 245, New StringFormat())
            contadorGeneral += 5

        Next

    End Sub

    Private Sub DibujaTotalFacturaFinal()
        Dim contadorGeneral As Integer = 0
        'llama a la clase OrdernarEncabezadoFactura para importar los datos de Ruc y numeroComprobante
        Dim ordTot As OrdernarTotalFactura = New OrdernarTotalFactura()
        'Fuente de la impresion
        Dim FuenteImpresaEncabezado = New Font("Lucida Console", 9, FontStyle.Regular)
        Dim FuenteImpresaEncabezadoTexto = New Font("Segoe UI", 9, FontStyle.Regular)
        'Se dibuja uin rectangulo parte derecha
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0.5)

        ''Crear texto del EncabezaDO
        'crear el Rectanguilo del importe General
        gfx.DrawRectangle(blackPen, 139, 244, 63, 41)
        'gfx.DrawRectangle(blackPen, 140, 261, 65, 20)

        'Encabezados de los importes Generales
        CadenaPorEscribirEnLinea = "OP. GRATUITAS"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 245, New StringFormat())

        CadenaPorEscribirEnLinea = "OP. EXONERADAS"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 250, New StringFormat())

        CadenaPorEscribirEnLinea = "OP. INAFECTO"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 255, New StringFormat())

        CadenaPorEscribirEnLinea = "OP. GRAVADA"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 260, New StringFormat())

        CadenaPorEscribirEnLinea = "TOTL DSCTO."
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 265, New StringFormat())

        CadenaPorEscribirEnLinea = "I.S.C."
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 270, New StringFormat())

        CadenaPorEscribirEnLinea = "I.G.V."
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 275, New StringFormat())

        CadenaPorEscribirEnLinea = "IMPORTE TOTAL"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 140, contadorGeneral + 280, New StringFormat())


        'Importes CApturados del sistema
        For Each Elemento As String In LineasTotalFactura

            CadenaPorEscribirEnLinea = ordTot.ObtenerTotalNombre(Elemento)
            CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezadoTexto, ColorDeLaFuente, 160, contadorGeneral + 245, New StringFormat())

            CadenaPorEscribirEnLinea = FormatNumber(ordTot.ObtenerTotalImporte(Elemento), 2)
            CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 170, contadorGeneral + 245, New StringFormat())
            contadorGeneral += 5

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
        Dim FuenteImpresaTitulo = New Font("Segoe UI", 9, FontStyle.Underline)
        Dim FuenteImpresaEncabezado = New Font("Segoe UI", 9, FontStyle.Regular)
        Dim FuenteImpresaEncabezadoNroCuenta = New Font("Segoe UI", 9, FontStyle.Regular)
        ' DIRECCION A  LA IZQUIERDA, ESPACIO PARA ABAJO, ANCHO DEL RECTANGULO, LARGO DEL RTECTRANGULO
        Dim blackPen As New Pen(Color.Black, 0.5)
        Dim contadorDatos As Integer = 0

        'crear restangulo con se describe el monto total del importe
        gfx.DrawRectangle(blackPen, 5, 244, 133, 10)
        'crear rectangulo con esta el codigo qr
        gfx.DrawRectangle(blackPen, 5, 255, 133, 30)


        gfx.DrawLine(blackPen, 105, 280, 138, 280)
        'linea de la fimar
        gfx.DrawLine(blackPen, 105, 255, 105, 285)
        'crear la fila cantidad

        '//TITULO
        CadenaPorEscribirEnLinea = "CUENTA ES SOLES:"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaTitulo, ColorDeLaFuente, 40, contadorDatos + 256, New StringFormat())

        CadenaPorEscribirEnLinea = "CUENTA EN DOLARES:"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaTitulo, ColorDeLaFuente, 40, contadorDatos + 270, New StringFormat())


        For Each Elemento As String In LineasDatosComplementaria
            CadenaPorEscribirEnLinea = ordTot.ObtenerTotalNombre(Elemento)
            Dim conver As String
            Dim numeroConverson As Decimal = Convert.ToDecimal(CadenaPorEscribirEnLinea)
            conver = Conversion.Enletras(numeroConverson)
            gfx.DrawString(conver & " SOLES", FuenteImpresaEncabezado, ColorDeLaFuente, 11, 249, New StringFormat())

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

        CadenaPorEscribirEnLinea = ""
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 23, contadorDatos + 222, New StringFormat())

        CadenaPorEscribirEnLinea = "RECIBI CONFORME"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 110, contadorDatos + 256, New StringFormat())

        CadenaPorEscribirEnLinea = "Firma"
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 116, contadorDatos + 280, New StringFormat())

        If (tipoComprobante = "2") Then

            CadenaPorEscribirEnLinea = "Consulte su documento electronico en " & "http://www.softpack.com.pe"
            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresaEncabezado, ColorDeLaFuente, 6, contadorDatos + 287, New StringFormat())

        End If

    End Sub
#End Region

End Class