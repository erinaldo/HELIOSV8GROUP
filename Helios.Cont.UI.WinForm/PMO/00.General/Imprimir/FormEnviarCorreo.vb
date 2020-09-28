Imports System.Net.Mail
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports System.IO
Imports OpenInvoicePeru.Comun.Dto.Intercambio
Imports OpenInvoicePeru.Comun.Dto.Modelos
Imports System.Net

Public Class FormEnviarCorreo

    Dim instance As New Printing.PrinterSettings
    Dim impresosaPredt As String = instance.PrinterName
    Public DocumentoID As Integer
    Dim ListaDatosGenrales As New List(Of datosGenerales)
    Dim objDatosGenrales As New datosGenerales
    Public serieFactura As String
    Public numeroFactura As String
    Public tipoDocumento As String
    Dim EnvioXml As Boolean = False
    Private Const FormatoFecha As String = "yyyy-MM-dd"
    Public QR As String
    Public HASH As String
    Public CERTIFICADO As String
    Public Property tienda As String = String.Empty
    Public Property EmailCliente As String
    Public Property documentoBE As documento

    Public Property DatosGeneralesBE As New datosGenerales

    Public Property fileUbicacionDoc As String = String.Empty
    Dim VISTAHTML As AlternateView

    Dim fileNameDocument As String = String.Empty

    Dim WithEvents CLIENTE As New WebClient 'LO DECLARAMOS CON EVENTS PARA PODER UTILIZAR LOS PROCEDIMIENTOS PROGRESSCHANGED Y COMPLETED
    Dim WithEvents CDR As New WebClient

    Public Property rutaxml As String = String.Empty
    Public Property rutaCDR As String = String.Empty


    Public Sub New(Datos As datosGenerales, idConfiguracion As Integer, fileUbicacion As String, fileNameDoc As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        TextBoxDESTINO.Select()
        TextBoxDESTINO.Focus()
        ' Agregue cualquie
        ' inicialización después de la llamada a InitializeComponent().
        'cargarDatos(idConfiguracion)
        'cargarCliente(nroRuc)
        fileUbicacionDoc = fileUbicacion
        DatosGeneralesBE = Datos
        fileNameDocument = fileNameDoc
        ProgressBar2.Style = ProgressBarStyle.Marquee
    End Sub

    Public Sub DescargarXMLyCDR()
        Try

            INSTACIA1(fileNameDocument)
            INSTACIA2(fileNameDocument)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub INSTACIA1(nombreXML As String)
        'C:\CLIENTES\10408199358\FACTURAS
        'CLIENTE.DownloadFileAsync(New Uri("http://138.128.171.106/" & "XML" & "/" & Gempresas.IdEmpresaRuc & "/FACTURAS/" & fileNameDocument & ".xml"), "C:\FACTURASELECTRONICAS\PDF\" & fileNameDocument & ".xml")
        rutaxml = "C:\FACTURASELECTRONICAS\PDF\" & fileNameDocument & ".xml"
    End Sub

    Private Sub INSTACIA2(nombreCDR As String)

        'CDR.DownloadFileAsync(New Uri("http://138.128.171.106/" & "XML" & "/" & Gempresas.IdEmpresaRuc & "/FACTURAS/R" & fileNameDocument & ".zip"), "C:\FACTURASELECTRONICAS\PDF\" & fileNameDocument & ".zip")
        rutaCDR = "C:\FACTURASELECTRONICAS\PDF\" & fileNameDocument & ".zip"
    End Sub

    Public Sub CargarDatosEnvio()
        Try

            If (TextBoxDESTINO.Text.Length <= 0) Then
                MessageBox.Show("DEBE INGRESAR UN EMAIL DESTINO")
                Exit Sub
            End If

            If (DatosGeneralesBE.e_mail.Length <= 0 Or DatosGeneralesBE.password.Length <= 0) Then
                enviarCorreo(GImpresion.EmailEnvio, GImpresion.PasswordEnvio, TextBoxDESTINO.Text, TextBoxTEXTO.Text, TextBoxASUNTO.Text, fileUbicacionDoc, Nothing, False, String.Empty)
            Else
                enviarCorreo(DatosGeneralesBE.e_mail, DatosGeneralesBE.password, TextBoxDESTINO.Text, TextBoxTEXTO.Text, TextBoxASUNTO.Text, fileUbicacionDoc, Nothing, False, String.Empty)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub cargardatosPrevios(textoEnviar As String)
        Dim MIHTML As String = textoEnviar 'TEXTO HTML QUE SE ENVIARA

        'DEFINE QUE ESTAMOS ENVIANDO UN MAIL EN FORMATO HTML
        VISTAHTML = AlternateView.CreateAlternateViewFromString(MIHTML, Nothing, System.Net.Mime.MediaTypeNames.Text.Html)
    End Sub

    Public Sub enviarCorreo(txtEmailEmpresa As String, txtContrasenaEmpresa As String, txtEmailDestino As String, txtDescripcion As String,
                             txtAsunto As String, nombreComplemento As String, ArchivoXml As String, EnviarXML As Boolean,
                             enviarDirecionEnvio As String)
        'PROCEDIMIENTO ESTANDAR DE ENVIO DE MAILS
        Dim pdfArchivo As String = String.Empty
        Try
            Dim MISMTP As New SmtpClient
            Dim MENSAJE As New System.Net.Mail.MailMessage
            MENSAJE.From = New MailAddress(txtEmailEmpresa)
            MENSAJE.To.Add(txtEmailDestino)
            MENSAJE.Subject = txtAsunto
            MENSAJE.Body = txtDescripcion


            If File.Exists(rutaxml) Then
                Dim ADJUNTOXML As Attachment = New Attachment(rutaxml)
                If (Not IsNothing(ADJUNTOXML)) Then
                    MENSAJE.Attachments.Add(ADJUNTOXML)
                End If
            End If

            If File.Exists(rutaCDR) Then
                Dim ADJUNTOXML As Attachment = New Attachment(rutaCDR)
                If (Not IsNothing(ADJUNTOXML)) Then
                    MENSAJE.Attachments.Add(ADJUNTOXML)
                End If
            End If


            pdfArchivo = nombreComplemento

            'If (ARCHIVO = "C:\FacturasSoftPack\" & nombreComplemento & ".pdf") Then
            If (pdfArchivo.Length > 0) Then
                Dim ADJUNTO As Attachment = New Attachment(pdfArchivo)
                MENSAJE.IsBodyHtml = True
                MENSAJE.Priority = System.Net.Mail.MailPriority.Normal
                MENSAJE.Attachments.Add(ADJUNTO)
                MENSAJE.AlternateViews.Add(VISTAHTML)
                Dim ORIGEN As String = txtEmailEmpresa.ToLower
                ORIGEN = ORIGEN.Remove(0, ORIGEN.IndexOf("@") + 1)

                If ORIGEN = "gmail.com" Then 'PARA GMAIL
                    MISMTP.Host = "SMTP.GMAIL.COM"
                    MISMTP.Port = "587"
                ElseIf ORIGEN = "hotmail.com" Or ORIGEN = "outlook.com" Then 'PARA HOTMAIL Y OUTLOOK
                    MISMTP.Host = "SMTP.LIVE.COM"
                    MISMTP.Port = "587"
                ElseIf ORIGEN = "zohomail.com" Then 'PARA HOTMAIL Y OUTLOOK
                    MISMTP.Host = "SMTP.zoho.com"
                    MISMTP.Port = "587"
                ElseIf ORIGEN = "spk.com.pe" Then 'PARA HOTMAIL Y OUTLOOK
                    MISMTP.Host = "SMTP.zoho.com"
                    MISMTP.Port = "587"
                Else
                    MISMTP.Host = "127.0.0.1"
                End If
                MISMTP.EnableSsl = True

                MISMTP.Credentials = New Net.NetworkCredential(txtEmailEmpresa, txtContrasenaEmpresa)
                MISMTP.Send(MENSAJE)
                MENSAJE.Attachments.Clear()
                MISMTP.Dispose()


            End If
            'Next
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
            Dispose()
        End Try
    End Sub

    'Public Sub CARGARTIPO(intIdDocumento As Integer, direccionXML As String)
    '    Try
    '        If (Not IsNothing(objDatosGenrales)) Then
    '            Select Case objDatosGenrales.formato
    '                Case 1
    '                    ImprimirTicketA4(intIdDocumento, direccionXML)
    '                Case 2
    '                    ImprimirTicketDirectaA4Formato2(intIdDocumento)
    '                Case 3
    '                    ImprimirTicketDirectaA4Formato_Detraccion(intIdDocumento)
    '                Case Else
    '                    ImprimirTicketA4(intIdDocumento, direccionXML)
    '            End Select
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub


    Function CrearEmisor() As Compania
        Dim Emisor As New Compania

        Emisor.NroDocumento = Gempresas.IdEmpresaRuc '"20603127278"
        Emisor.TipoDocumento = "6"
        Emisor.NombreComercial = Gempresas.NomEmpresa '"INVERSIONES SEÑOR DE ACORIA S.A.C."
        Emisor.NombreLegal = Gempresas.NomEmpresa '"INVERSIONES SEÑOR DE ACORIA S.A.C."
        Emisor.CodigoAnexo = "0001"

        Return Emisor

    End Function

    Private Sub cargarDatosTipoformato(idConfiguracion As Integer)
        'Dim datosGeneralesSA As New datosGeneralesSA
        Dim datosGeneralesSA As New datosGeneralesSA


        objDatosGenrales = datosGeneralesSA.UbicaEmpresaID(CStr(idConfiguracion))

        If (Not IsNothing(objDatosGenrales)) Then
            'TextBoxUSUARIO.Text = objDatosGenrales.e_mail
            'TextBoxCONTRASEÑA.Text = objDatosGenrales.password
            TextBoxUSUARIO.Text = objDatosGenrales.e_mail
            TextBoxCONTRASEÑA.Text = objDatosGenrales.password
            objDatosGenrales = objDatosGenrales
        Else
            MessageBox.Show("No existe correo configurado de la empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxUSUARIO.Text = String.Empty
            TextBoxCONTRASEÑA.Text = String.Empty
        End If
    End Sub

    Private Sub cargarDatos(id As Integer)
        'Dim datosGeneralesSA As New datosGeneralesSA
        Dim datosGeneralesSA As New datosGeneralesSA
        Dim objDAtos As New datosGenerales
        objDAtos = New datosGenerales
        objDAtos.idEmpresa = Gempresas.IdEmpresaRuc

        ListaDatosGenrales = CustomListaDatosGenerales.Where(Function(o) o.idConfiguracion = id And o.NombreFormato = "A4").ToList   'datosGeneralesSA.UbicaEmpresaFull(objDAtos)

        'objDatosGenrales = datosGeneralesSA.UbicaEmpresaID(Gempresas.IdEmpresaRuc)

        If ((ListaDatosGenrales.Count > 0)) Then
            For Each item In ListaDatosGenrales
                If (Not IsNothing(item)) Then
                    'TextBoxUSUARIO.Text = objDatosGenrales.e_mail
                    'TextBoxCONTRASEÑA.Text = objDatosGenrales.password
                    TextBoxUSUARIO.Text = item.e_mail
                    TextBoxCONTRASEÑA.Text = item.password
                    objDatosGenrales = item
                Else
                    MessageBox.Show("No existe correo configurado de la empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TextBoxUSUARIO.Text = String.Empty
                    TextBoxCONTRASEÑA.Text = String.Empty
                End If
                Exit For
            Next
        Else
            ListaDatosGenrales = CustomListaDatosGenerales.Where(Function(o) o.NombreFormato = "A4").ToList
            For Each item In ListaDatosGenrales
                If (Not IsNothing(item)) Then
                    'TextBoxUSUARIO.Text = objDatosGenrales.e_mail
                    'TextBoxCONTRASEÑA.Text = objDatosGenrales.password
                    TextBoxUSUARIO.Text = item.e_mail
                    TextBoxCONTRASEÑA.Text = item.password
                    objDatosGenrales = item
                Else
                    MessageBox.Show("No existe correo configurado de la empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TextBoxUSUARIO.Text = String.Empty
                    TextBoxCONTRASEÑA.Text = String.Empty
                End If
                Exit For
            Next

        End If

    End Sub

    Private Sub cargarCliente(IdEntidad As String)
        Try
            'Dim datosGeneralesSA As New datosGeneralesSA
            Dim entidadSA As New entidadSA
            Dim objDAtos As New entidad
            objDAtos = New entidad
            objDAtos.idEmpresa = Gempresas.IdEmpresaRuc
            objDAtos.nrodoc = IdEntidad

            Dim entidad = entidadSA.UbicarClienteXID(objDAtos)

            If (Not IsNothing(entidad)) Then
                TextBoxDESTINO.Text = entidad.email
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub



#Region "ENVIAR FORMATO 1 - A4"

    Public Sub ImprimirTicketA4(intIdDocumento As Integer, direccionXML As String)
        Dim a As TicketA4 = New TicketA4
        ' Logo de la Empresa
        Dim lista As New List(Of String)

        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim ticket As New CrearTicket()
        Dim nombreComprabante As String
        '  Dim r As Record = dgPedidos.Table.CurrentRecord
        Dim entidadSA As New entidadSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
        Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
        Dim tipoComprobante As String = String.Empty

        Select Case comprobante.tipoDocumento
            Case "12.1"
                '//DATOS GENERALES RUC - SERIE NUMERO Y TIPO COMPROBANTE
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       comprobante.serieVenta & "-" & CStr(comprobante.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                nombreComprabante = "BOLETA" & comprobante.serieVenta & CStr(comprobante.numeroVenta).PadLeft(8, "0"c)
                tipoComprobante = "1"
            Case "12.2"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       comprobante.serieVenta & "-" & CStr(comprobante.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                nombreComprabante = "FACTURA" & comprobante.serieVenta & CStr(comprobante.numeroVenta).PadLeft(8, "0"c)
                tipoComprobante = "1"
            Case "03"
                If (comprobante.tipoVenta = "VELC") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       comprobante.serieVenta & "-" & CStr(comprobante.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA ELECTRONICA")
                    nombreComprabante = "BOLETA ELECTRONICA" & comprobante.serieVenta & CStr(comprobante.numeroVenta).PadLeft(8, "0"c)
                    tipoComprobante = "2"
                ElseIf (comprobante.tipoVenta = "VPOS") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       comprobante.serieVenta & "-" & CStr(comprobante.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                    nombreComprabante = "BOLETA" & comprobante.serieVenta & CStr(comprobante.numeroVenta).PadLeft(8, "0"c)
                    tipoComprobante = "1"
                End If
            Case "01"
                If (comprobante.tipoVenta = "VELC") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       comprobante.serieVenta & "-" & CStr(comprobante.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA ELECTRONICA")
                    nombreComprabante = "FACTURA ELECTRONICA" & comprobante.serieVenta & CStr(comprobante.numeroVenta).PadLeft(8, "0"c)
                    tipoComprobante = "2"
                ElseIf (comprobante.tipoVenta = "VPOS") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       comprobante.serieVenta & "-" & CStr(comprobante.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                    nombreComprabante = "FACTURA" & comprobante.serieVenta & CStr(comprobante.numeroVenta).PadLeft(8, "0"c)
                    tipoComprobante = "1"
                End If
            Case "07"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                     comprobante.serieVenta & "-" & CStr(comprobante.numeroVenta).PadLeft(8, "0"c),
                                     "NOTA DE CREDITO")
                nombreComprabante = "NOTA DE CREDITO" & comprobante.serieVenta & CStr(comprobante.numeroVenta).PadLeft(8, "0"c)
                tipoComprobante = "2"
            Case "9903"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      comprobante.serie & "-" & CStr(comprobante.numeroDoc).PadLeft(8, "0"c),
                                      "COTIZACIÓN")
                nombreComprabante = "COTIZACIÓN" & comprobante.serie & CStr(comprobante.numeroDoc).PadLeft(8, "0"c)
            Case Else
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      comprobante.serieVenta & "-" & CStr(comprobante.numeroVenta).PadLeft(8, "0"c),
                                      "NOTA")
                nombreComprabante = "NOTA" & comprobante.serieVenta & CStr(comprobante.numeroVenta).PadLeft(8, "0"c)
                tipoComprobante = "1"
        End Select


        'Dim rucCliente As String
        If (objDatosGenrales.logo.Length > 0) Then
            '//POSISCION DE LA IMAGEN
            a.PosicionLogo = objDatosGenrales.posicionLogo
            ' Logo de la Empresa
            a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
        End If

        '//DATOS GENERALES DE LA EMPRESA
        Dim Telefono As String = String.Empty
        If (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length > 0 And objDatosGenrales.telefono4.Length = 0) Then
            Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3)
        ElseIf (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length = 0 And objDatosGenrales.telefono4.Length = 0) Then
            Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
        ElseIf (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length > 0 And objDatosGenrales.telefono4.Length > 0) Then
            Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3 & " - " & objDatosGenrales.telefono4)
        Else
            Telefono = ("TELF: " & objDatosGenrales.telefono1)
        End If

        a.AnadirLineaEmpresa(objDatosGenrales.razonSocial,
                            objDatosGenrales.nombreCorto,
                            "Domicilio Fiscal: " & objDatosGenrales.direccionPrincipal,
                            "Establ. Anexo: " & objDatosGenrales.direccionSecudaria,
                            "Telf: " & Telefono)




        If comprobante.idCliente <> 0 Then
            Dim entidad = entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault
            Dim NBoletaElectronica As String = entidad.nombreCompleto
            Dim nBoletaNumero As String
            'ticket.TextoIzquierda(NBoletaElectronica)
            If entidad.nrodoc.Trim.Length = 11 Then
                nBoletaNumero = "R.U.C. - " & entidad.nrodoc
            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                nBoletaNumero = "D.N.I. - " & entidad.nrodoc
            Else
                nBoletaNumero = entidad.nrodoc
            End If

            '//DATOS DEL CLIENTE
            'Fecha de Factura
            'Lugar de la factura
            'Nombre del cliente
            'direccion del cliente
            'numero del cliente
            'direccion de entrega
            'tipo moneda de la empresa
            'telefono de la empresa
            a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechaDoc.Value.ToShortDateString(),
                                              "",
                                              NBoletaElectronica,
                                             entidad.direccion,
                                             comprobante.nombrePedido,
                                              nBoletaNumero,
                                              "PEN",
                                              "")

            If (Not IsNothing(HASH)) Then
                If HASH.Trim.Length > 0 Then
                    QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
                          "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
                          "|" & HASH & "|" & CERTIFICADO)

                    QrCodeImgControl1.Text = QR
                Else
                    QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
                         "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                    QrCodeImgControl1.Text = QR
                End If
            Else
                QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
                     "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                QrCodeImgControl1.Text = QR
            End If


        Else
            Dim NBoletaElectronica As String = comprobante.nombrePedido
            'ticket.TextoIzquierda(NBoletaElectronica)
            'Fecha de Factura
            'Lugar de la factura
            'Nombre del cliente
            'direccion del cliente
            'numero del cliente
            'direccion de entrega
            'tipo moneda de la empresa
            'telefono de la empresa
            '//DATOS DEL CLIENTE
            'Fecha de Factura
            'Lugar de la factura
            'Nombre del cliente
            'direccion del cliente
            'numero del cliente
            'direccion de entrega
            'tipo moneda de la empresa
            'telefono de la empresa
            a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechaDoc.Value.ToShortDateString(),
                                              "",
                                              NBoletaElectronica,
                                             "",
                                             "",
                                              "",
                                              "PEN",
                                              "")

            'Codigo qr
            QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
                      "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & "VARIOS" & "|" & "0")

            QrCodeImgControl1.Text = QR
        End If


        '//DATOS COMPLEMENTARIOS
        'Nro. Pedido
        'Fecha Pedido
        'Orden de compra
        'fecha de Orden de Compra
        'Guia de remisiionm
        'FEcha de guia de remisuion
        'forma de venta
        'Tipo de Venta

        Dim tipoVenta As String = String.Empty

        Select Case comprobante.estadoCobro
            Case "DC"
                tipoVenta = "CONTADO"
            Case "PN"
                tipoVenta = "CREDITO"
        End Select

        a.AnadirLineaDatosComplementarios("",
                                          "",
                                          "",
                                              "",
                                              "",
                                              "",
                                              "",
                                          tipoVenta)

        '//DATOS DE LOS DETALLES DE LOS ITEMS
        '*********************** TODO LOS DETALLES DE LOS ITEM *********************
        'CODIGO
        'DESCRIPCION
        'CANTIDAD
        'UM
        'VALOR VENTA UNITARIO
        'DESCUENTO
        'VALOR DE VENTA TOTAL
        'OTROS CARGOS
        'IMPUESTOS
        'PRECIO DE VENTA
        'VALOR TOTAL


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

            a.AnadirLineaElementosFactura(i.codigoBarra,
                                      i.nombreItem,
                                      i.monto1,
                                      i.CustomEquivalencia.unidadComercial,
                                      (i.montokardex) / i.monto1,
                                      "0.00",
                                      i.montokardex,
                                      "0.00",
                                      i.montoIgv,
                                      i.importeMN / i.monto1,
                                      i.importeMN)

        Next

        '********************************** RESUMEN GENERAL DE LA FACTURA **************************
        'GRATUITAS
        a.AnadirDatosGenerales("S/", "0.00")
        'EXONERADAS
        a.AnadirDatosGenerales("S/", ExoMN)
        'INAFECTA
        a.AnadirDatosGenerales("S/", InaMN)
        'GRAVADA
        a.AnadirDatosGenerales("S/", gravMN)
        'TOTAL DESCUENTO
        a.AnadirDatosGenerales("S/", "0.00")
        'I.S.C.
        a.AnadirDatosGenerales("S/", "0.00")
        'I.G.V
        a.AnadirDatosGenerales("S/", comprobante.igv01)
        'IMPORTE TOTAL
        a.AnadirDatosGenerales("S/", comprobante.ImporteNacional)


        '//DESCRIICION DE DETALLE DE TOTAL IMKPORTE Y NUMEROS BANCARIOS

        ''DESCRIPCION DEL IMPORTE TOTAL EN LETRAS
        'BANCO SOLES
        'BANCO DOLARES
        'NOTA DE CAMBIOS
        a.AnadirLineaTotalFactura(comprobante.ImporteNacional,
                                  objDatosGenrales.nroCuentaSoles,
                                  objDatosGenrales.nroCuentaSoles,
                                  objDatosGenrales.nroCuentaDolares,
                                   objDatosGenrales.nroCuentaDolares2,
                                  objDatosGenrales.glosario)


        a.headerImagenQR = QrCodeImgControl1.Image

        Select Case tipoComprobante

            Case "1"
                a.tipoComprobante = "1"
                'a.GuardanImpresion("Microsoft Print to PDF", txtDireccionEnvio.Text, TextBoxUSUARIO.Text, TextBoxCONTRASEÑA.Text, TextBoxDESTINO.Text, TextBoxASUNTO.Text, TextBoxTEXTO.Text)

            Case "2"
                a.tipoComprobante = "2"
                'a.GuardanImpresion("Microsoft Print to PDF", txtDireccionEnvio.Text, TextBoxUSUARIO.Text, TextBoxCONTRASEÑA.Text, TextBoxDESTINO.Text, TextBoxASUNTO.Text, TextBoxTEXTO.Text)

        End Select

        direccionXML = String.Empty
    End Sub
#End Region

#Region "IMPRIMIR NOTA DE CREDITO"
    Sub ImprimirTicketDevolucionA4Formato2(intIdDocumento As Integer, numeroImpresion As Integer)
        Dim a As TicketNotaA4v2 = New TicketNotaA4v2
        ' Logo de la Empresa
        Dim lista As New List(Of String)
        Dim numero As Integer = 1
        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim ticket As New CrearTicket()
        Dim nombreComprabante As String
        '  Dim r As Record = dgPedidos.Table.CurrentRecord
        Dim entidadSA As New entidadSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA

        'Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
        Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
        'Dim comprobantePadre = documentoSA.GetUbicar_documentoventaAbarrotesPorIDPadre(intIdDocumento)
        Dim tipoComprobante As String = String.Empty
        Dim comprobante = documentoSA.GetUbicar_NotaXID(intIdDocumento)

        Select Case comprobante.tipoDocumento
            Case "12.1"
                '//DATOS GENERALES RUC - SERIE NUMERO Y TIPO COMPROBANTE
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       comprobante.serieVenta & "-" & CStr(comprobante.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                nombreComprabante = "BOLETA" & comprobante.serieVenta & CStr(comprobante.numeroVenta).PadLeft(8, "0"c)
                tipoComprobante = "1"
            Case "12.2"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       comprobante.serieVenta & "-" & CStr(comprobante.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                nombreComprabante = "FACTURA" & comprobante.serieVenta & CStr(comprobante.numeroVenta).PadLeft(8, "0"c)
                tipoComprobante = "1"
            Case "03"
                If (comprobante.tipoVenta = "VELC") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       comprobante.serieVenta & "-" & CStr(comprobante.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA ELECTRONICA")
                    nombreComprabante = "BOLETA ELECTRONICA" & comprobante.serieVenta & CStr(comprobante.numeroVenta).PadLeft(8, "0"c)
                    tipoComprobante = "2"
                ElseIf (comprobante.tipoVenta = "VPOS") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       comprobante.serieVenta & "-" & CStr(comprobante.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                    nombreComprabante = "BOLETA" & comprobante.serieVenta & CStr(comprobante.numeroVenta).PadLeft(8, "0"c)
                    tipoComprobante = "1"
                End If
            Case "01"
                If (comprobante.tipoVenta = "VELC") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       comprobante.serieVenta & "-" & CStr(comprobante.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA ELECTRONICA")
                    nombreComprabante = "FACTURA ELECTRONICA" & comprobante.serieVenta & CStr(comprobante.numeroVenta).PadLeft(8, "0"c)
                    tipoComprobante = "2"
                ElseIf (comprobante.tipoVenta = "VPOS") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       comprobante.serieVenta & "-" & CStr(comprobante.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                    nombreComprabante = "FACTURA" & comprobante.serieVenta & CStr(comprobante.numeroVenta).PadLeft(8, "0"c)
                    tipoComprobante = "1"
                End If
            Case "07"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                     comprobante.serieVenta & "-" & CStr(comprobante.numeroVenta).PadLeft(8, "0"c),
                                     "NOTA DE CREDITO")
                nombreComprabante = "NOTA DE CREDITO" & comprobante.serieVenta & CStr(comprobante.numeroVenta).PadLeft(8, "0"c)
                tipoComprobante = "2"
            Case "9903"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      comprobante.serie & "-" & CStr(comprobante.numeroDoc).PadLeft(8, "0"c),
                                      "COTIZACIÓN")
                nombreComprabante = "COTIZACIÓN" & comprobante.serie & CStr(comprobante.numeroDoc).PadLeft(8, "0"c)
            Case Else
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      comprobante.serieVenta & "-" & CStr(comprobante.numeroVenta).PadLeft(8, "0"c),
                                      "NOTA")
                nombreComprabante = "NOTA" & comprobante.serieVenta & CStr(comprobante.numeroVenta).PadLeft(8, "0"c)
                tipoComprobante = "1"
        End Select

        'Dim rucCliente As String
        If (objDatosGenrales.logo.Length > 0) Then
            '//POSISCION DE LA IMAGEN
            a.PosicionLogo = objDatosGenrales.posicionLogo
            ' Logo de la Empresa
            a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
        End If

        '//DATOS GENERALES DE LA EMPRESA
        Dim Telefono As String = String.Empty
        If (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length > 0 And objDatosGenrales.telefono4.Length = 0) Then
            Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3)
        ElseIf (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length = 0 And objDatosGenrales.telefono4.Length = 0) Then
            Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
        ElseIf (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length > 0 And objDatosGenrales.telefono4.Length > 0) Then
            Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3 & " - " & objDatosGenrales.telefono4)
        Else
            Telefono = ("TELF: " & objDatosGenrales.telefono1)
        End If

        a.AnadirLineaEmpresa(objDatosGenrales.razonSocial,
                            objDatosGenrales.nombreCorto,
                            "Domicilio Fiscal: " & objDatosGenrales.direccionPrincipal,
                            "Establ. Anexo: " & objDatosGenrales.direccionSecudaria,
                            "Telf: " & Telefono)


        Select Case comprobante.tipoDocumento
            Case "07"
                '//DATOS GENERALES RUC - SERIE NUMERO Y TIPO COMPROBANTE
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       comprobante.serieVenta & "-" & CStr(comprobante.numeroVenta).PadLeft(8, "0"c),
                                       "NOTA DE CREDITO")
                nombreComprabante = "NOTA DE CREDITO" & comprobante.serieVenta & comprobante.numeroVenta
                tipoComprobante = "2"
        End Select

        Dim entidad = documentoBE.documentoventaAbarrotes.CustomEntidad ' entidadSA.UbicarEntidadPorID(documentoBE.documentoventaAbarrotes.idCliente).FirstOrDefault
        Dim NBoletaElectronica As String '= entidad.nombreCompleto
        Dim nBoletaNumero As String
        'ticket.TextoIzquierda(NBoletaElectronica)

        If (Not IsNothing(entidad.nrodoc)) Then

            If entidad.nrodoc.Trim.Length = 11 Then
                nBoletaNumero = "R.U.C. - " & entidad.nrodoc
            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                nBoletaNumero = "D.N.I. - " & entidad.nrodoc
            Else
                nBoletaNumero = entidad.nrodoc
            End If
        Else
            nBoletaNumero = "-"
        End If


        If entidad.tipoEntidad = "VR" Then
            NBoletaElectronica = documentoBE.documentoventaAbarrotes.nombrePedido
        Else
            NBoletaElectronica = entidad.nombreCompleto
        End If

        '//DATOS DEL CLIENTE
        'Fecha de Factura
        'Lugar de la factura
        'Nombre del cliente
        'direccion del cliente
        'numero del cliente
        'direccion de entrega
        'tipo moneda de la empresa
        'telefono de la empresa
        a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechaDoc.Value.ToShortDateString(),
                                              "",
                                              NBoletaElectronica,
                                             entidad.direccion,
                                             comprobante.nombrePedido,
                                              nBoletaNumero,
                                              "PEN",
                                              "")

        If (Not IsNothing(HASH)) Then
            If HASH.Trim.Length > 0 Then
                QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
                      "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
                      "|" & HASH & "|" & CERTIFICADO)

                QrCodeImgControl1.Text = QR
            Else
                QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
                     "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                QrCodeImgControl1.Text = QR
            End If
        Else
            QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
                 "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

            QrCodeImgControl1.Text = QR
        End If



        '//DATOS COMPLEMENTARIOS
        'Nro. Pedido
        'Fecha Pedido
        'Orden de compra
        'fecha de Orden de Compra
        'Guia de remisiionm
        'FEcha de guia de remisuion
        'forma de venta
        'Tipo de Venta

        Dim tipoEmision As String = String.Empty

        'Select Case comprobante.estadoCobro
        '    Case "DC"
        '        tipoVenta = "CONTADO"
        '    Case "PN"
        '        tipoVenta = "CREDITO"
        'End Select

        Select Case comprobante.notaCredito
            Case "01"
                tipoEmision = "Anulación de la Operación"
            Case "02"
                tipoEmision = "Anulación por error en el RUC"
            Case "03"
                tipoEmision = "Anulación por error en la descripción"
            Case "04"
                tipoEmision = "Descuento global"
            Case "05"
                tipoEmision = "Descuento por item"
            Case "06"
                tipoEmision = "devolución total"
            Case "07"
                tipoEmision = "devolución por item"
            Case "08"
                tipoEmision = "Bonificación"
            Case "09"
                tipoEmision = "disminución en el valor"
            Case "10"
                tipoEmision = "Otros conceptos"
            Case "11"
                tipoEmision = "Ajustes de Operaciones de exportación"
        End Select

        Dim NombreComprobante As String = String.Empty
        Select Case comprobante.TipoDocNota
            Case "01"
                NombreComprobante = "FACTURA ELECTRONICA"
            Case "02"
                NombreComprobante = "BOLETA ELECTRONICA"
        End Select

        '//DATOS COMPLEMENTARIOS
        'Nro. Pedido
        'Fecha Pedido
        'Orden de compra
        'fecha de Orden de Compra
        'Guia de remisiionm
        'FEcha de guia de remisuion
        'MOTIVO DE EMISION
        'TIPO DOC
        'NRO DOCUMENTO

        Dim numeroafect As String = String.Format("{0:00000000}", comprobante.numeroDoc)

        a.AnadirLineaDatosComplementarios(CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha),
                                              "-",
                                             comprobante.nroOrdenVenta,
                                              "-",
                                              comprobante.nroGuia,
                                              "-",
                                              tipoEmision,
                                          NombreComprobante,
                                          comprobante.serie & "-" & numeroafect)

        '//DATOS DE LOS DETALLES DE LOS ITEMS
        '*********************** TODO LOS DETALLES DE LOS ITEM *********************
        'CODIGO
        'DESCRIPCION
        'CANTIDAD
        'UM
        'VALOR VENTA UNITARIO
        'DESCUENTO
        'VALOR DE VENTA TOTAL
        'OTROS CARGOS
        'IMPUESTOS
        'PRECIO DE VENTA
        'VALOR TOTAL


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

            a.AnadirLineaElementosFactura(numero,
                                 $"{i.nombreItem} {i.detalleAdicional}",
                                  CInt(i.monto1),
                                   i.unidad1,
                                  "0.00",
                                  "0.00",
                                  i.montokardex,
                                  "0.00",
                                  i.montoIgv,
                                  i.importeMN,
                                  i.importeMN)

            numero += 1

        Next

        a.AnadirLineaNotaCredito(tipoEmision, comprobante.glosa)

        '********************************** RESUMEN GENERAL DE LA FACTURA **************************
        'GRATUITAS
        a.AnadirDatosGenerales("S/", "0.00")
        'EXONERADAS
        a.AnadirDatosGenerales("S/", ExoMN)
        'INAFECTA
        a.AnadirDatosGenerales("S/", InaMN)
        'GRAVADA
        a.AnadirDatosGenerales("S/", gravMN)
        'TOTAL DESCUENTO
        a.AnadirDatosGenerales("S/", "0.00")
        'I.S.C.
        a.AnadirDatosGenerales("S/", "0.00")
        'I.G.V
        a.AnadirDatosGenerales("S/", comprobante.igv01.GetValueOrDefault)
        'I.G.V
        a.AnadirDatosGenerales("S/", comprobante.icbper.GetValueOrDefault)
        'IMPORTE TOTAL
        a.AnadirDatosGenerales("S/", comprobante.ImporteNacional.GetValueOrDefault)

        '//DESCRIICION DE DETALLE DE TOTAL IMKPORTE Y NUMEROS BANCARIOS

        ''DESCRIPCION DEL IMPORTE TOTAL EN LETRAS
        'BANCO SOLES
        'BANCO DOLARES
        'NOTA DE CAMBIOS
        a.AnadirLineaTotalFactura(comprobante.ImporteNacional,
                                  objDatosGenrales.nroCuentaSoles,
                                    objDatosGenrales.nroCuentaSoles2,
                                  objDatosGenrales.nroCuentaDolares,
                                   objDatosGenrales.nroCuentaDolares2,
                                  objDatosGenrales.glosario)


        a.headerImagenQR = QrCodeImgControl1.Image


        'Select Case tipoComprobante
        '    Case "1"
        '        a.tipoComprobante = "1"
        '        a.GuardanImpresion("Microsoft Print to PDF", txtDireccionEnvio.Text, TextBoxUSUARIO.Text, TextBoxCONTRASEÑA.Text, TextBoxDESTINO.Text, TextBoxASUNTO.Text, TextBoxTEXTO.Text)
        '    Case "2"
        '        a.tipoComprobante = "2"
        '        a.GuardanImpresion("Microsoft Print to PDF", txtDireccionEnvio.Text, TextBoxUSUARIO.Text, TextBoxCONTRASEÑA.Text, TextBoxDESTINO.Text, TextBoxASUNTO.Text, TextBoxTEXTO.Text)
        'End Select

    End Sub
#End Region

#Region "IMPRIMIR DIRECTP FORAMTO 1  - A4"
    Public Sub ImprimirTicketDirectaA4()
        Try

            Dim a As TicketA4 = New TicketA4
            ' Logo de la Empresa
            Dim lista As New List(Of String)
            Dim numeracion As Integer = 1
            Dim gravMN As Decimal = 0
            Dim gravME As Decimal = 0
            Dim ExoMN As Decimal = 0
            Dim ExoME As Decimal = 0
            Dim InaMN As Decimal = 0
            Dim InaME As Decimal = 0
            Dim ticket As New CrearTicket()
            Dim nombreComprabante As String
            '  Dim r As Record = dgPedidos.Table.CurrentRecord
            Dim entidadSA As New entidadSA
            'Dim documentoSA As New documentoVentaAbarrotesSA
            'Dim documentoDetSA As New documentoVentaAbarrotesDetSA
            'Dim documentoBE.documentoventaAbarrotes = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
            'Dim documentoBE.documentoventaAbarrotesDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
            Dim tipocomprobante As String = String.Empty

            If (Not IsNothing(documentoBE.documentoventaAbarrotes.CustomEntidad.email)) Then
                txtDireccionEnvio.Text = documentoBE.documentoventaAbarrotes.CustomEntidad.email
            End If

            'Dim rucCliente As String
            If (objDatosGenrales.logo.Length > 0) Then
                '//POSISCION DE LA IMAGEN
                a.PosicionLogo = objDatosGenrales.posicionLogo
                ' Logo de la Empresa
                a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
            End If

            '//DATOS GENERALES DE LA EMPRESA
            Dim Telefono As String = String.Empty
            If (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length > 0 And objDatosGenrales.telefono4.Length = 0) Then
                Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3)
            ElseIf (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length = 0 And objDatosGenrales.telefono4.Length = 0) Then
                Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
            ElseIf (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length > 0 And objDatosGenrales.telefono4.Length > 0) Then
                Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3 & " - " & objDatosGenrales.telefono4)
            Else
                Telefono = ("TELF: " & objDatosGenrales.telefono1)
            End If

            a.AnadirLineaEmpresa(objDatosGenrales.razonSocial,
                            objDatosGenrales.nombreCorto,
                            "Domicilio Fiscal: " & objDatosGenrales.direccionPrincipal,
                            "Establ. Anexo: " & objDatosGenrales.direccionSecudaria,
                            "Telf: " & Telefono)


            Select Case documentoBE.documentoventaAbarrotes.tipoDocumento
                Case "12.1"
                    '//DATOS GENERALES RUC - SERIE NUMERO Y TIPO documentoBE.documentoventaAbarrotes
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                    nombreComprabante = "BOLETA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipocomprobante = "1"

                    TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA ELECTRONICA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA ELECTRONICA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                    numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                    tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                Case "12.2"
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                    nombreComprabante = "FACTURA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipocomprobante = "1"

                    TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA ELECTRONICA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA ELECTRONICA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                    numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                    tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                Case "03"
                    If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA ELECTRONICA")
                        nombreComprabante = "BOLETA ELECTRONICA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                        tipocomprobante = "2"

                        TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA ELECTRONICA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA ELECTRONICA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                        numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                        tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                    ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                        nombreComprabante = "BOLETA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                        tipocomprobante = "1"

                        TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                        numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                        tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                    End If
                Case "01"
                    If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA ELECTRONICA")
                        nombreComprabante = "FACTURA ELECTRONICA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                        tipocomprobante = "2"


                        TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA ELECTRONICA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA ELECTRONICA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                        numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                        tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                    ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                        nombreComprabante = "FACTURA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                        tipocomprobante = "1"

                        TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                        numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                        tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                    End If
                Case "9903" '"9901"
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serie & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroDoc).PadLeft(8, "0"c),
                                      "COTIZACIÓN")
                    nombreComprabante = "COTIZACIÓN" & documentoBE.documentoventaAbarrotes.serie & documentoBE.documentoventaAbarrotes.numeroDoc
                    tipocomprobante = "1"

                    TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA" & 0 & "-" & 0
                    txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA-" & 0 & "-" & 0
                    serieFactura = 0
                    numeroFactura = 0
                    tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                Case Else
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "NOTA")
                    nombreComprabante = "NOTA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipocomprobante = "1"

                    TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                    numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                    tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

            End Select

            Dim entidad = documentoBE.documentoventaAbarrotes.CustomEntidad ' entidadSA.UbicarEntidadPorID(documentoBE.documentoventaAbarrotes.idCliente).FirstOrDefault
            Dim NBoletaElectronica As String '= entidad.nombreCompleto
            Dim nBoletaNumero As String
            'ticket.TextoIzquierda(NBoletaElectronica)


            If (Not IsNothing(entidad.nrodoc)) Then

                If entidad.nrodoc.Trim.Length = 11 Then
                    nBoletaNumero = "R.U.C. - " & entidad.nrodoc
                ElseIf entidad.nrodoc.Trim.Length = 8 Then
                    nBoletaNumero = "D.N.I. - " & entidad.nrodoc
                Else
                    nBoletaNumero = entidad.nrodoc
                End If
            Else
                nBoletaNumero = "-"
            End If

            If entidad.tipoEntidad = "VR" Then
                NBoletaElectronica = documentoBE.documentoventaAbarrotes.nombrePedido
            Else
                NBoletaElectronica = entidad.nombreCompleto
            End If

            '//DATOS DEL CLIENTE
            'Fecha de Factura
            'Lugar de la factura
            'Nombre del cliente
            'direccion del cliente
            'numero del cliente
            'direccion de entrega
            'tipo moneda de la empresa
            'telefono de la empresa
            a.AnadirLineaCaracteresDatosGEnerales(documentoBE.documentoventaAbarrotes.fechaDoc.Value.ToShortDateString(),
                                              "",
                                              NBoletaElectronica,
                                             entidad.direccion,
                                             documentoBE.documentoventaAbarrotes.nombrePedido,
                                              nBoletaNumero,
                                              "PEN",
                                              "")

            If (Not IsNothing(HASH)) Then
                If HASH.Trim.Length > 0 Then
                    QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                      "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
                      "|" & HASH & "|" & CERTIFICADO)

                    QrCodeImgControl1.Text = QR
                Else
                    QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                     "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                    QrCodeImgControl1.Text = QR
                End If
            Else
                QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                 "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                QrCodeImgControl1.Text = QR
            End If


            '//DATOS COMPLEMENTARIOS
            'Nro. Pedido
            'Fecha Pedido
            'Orden de compra
            'fecha de Orden de Compra
            'Guia de remisiionm
            'FEcha de guia de remisuion
            'forma de venta
            'Tipo de Venta

            Dim tipoVenta As String = String.Empty

            Select Case documentoBE.documentoventaAbarrotes.estadoCobro
                Case "DC"
                    tipoVenta = "CONTADO"
                Case "PN"
                    tipoVenta = "CREDITO"
            End Select

            a.AnadirLineaDatosComplementarios("-",
                                          "-",
                                          documentoBE.documentoventaAbarrotes.nroOrdenVenta,
                                              "-",
                                              documentoBE.documentoventaAbarrotes.nroGuia,
                                              "-",
                                              "-",
                                          tipoVenta)

            '//DATOS DE LOS DETALLES DE LOS ITEMS
            '*********************** TODO LOS DETALLES DE LOS ITEM *********************
            'CODIGO
            'DESCRIPCION
            'CANTIDAD
            'UM
            'VALOR VENTA UNITARIO
            'DESCUENTO
            'VALOR DE VENTA TOTAL
            'OTROS CARGOS
            'IMPUESTOS
            'PRECIO DE VENTA
            'VALOR TOTAL


            For Each i In documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet

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

                If (Not IsNothing(i.CustomEquivalencia)) Then
                    a.AnadirLineaElementosFactura(numeracion,
                                      $"{i.nombreItem} {i.detalleAdicional}({i.CustomEquivalencia.unidadComercial})",
                                    i.monto1,
                                    i.unidad1,
                                    (i.montokardex) / i.monto1,
                                    "0.00",
                                    i.montokardex,
                                    "0.00",
                                    i.montoIgv,
                                    i.importeMN / i.monto1,
                                    i.importeMN)
                Else
                    a.AnadirLineaElementosFactura(numeracion,
                                   $"{i.nombreItem} {i.detalleAdicional}",
                                    i.monto1,
                                    i.unidad1,
                                    (i.montokardex) / i.monto1,
                                    "0.00",
                                    i.montokardex,
                                    "0.00",
                                    i.montoIgv,
                                    i.importeMN / i.monto1,
                                    i.importeMN)
                End If


                numeracion += 1

            Next

            '********************************** RESUMEN GENERAL DE LA FACTURA **************************
            'GRATUITAS
            a.AnadirDatosGenerales("S/", "0.00")
            'EXONERADAS
            a.AnadirDatosGenerales("S/", ExoMN)
            'INAFECTA
            a.AnadirDatosGenerales("S/", InaMN)
            'GRAVADA
            a.AnadirDatosGenerales("S/", gravMN)
            'TOTAL DESCUENTO
            a.AnadirDatosGenerales("S/", "0.00")
            'I.S.C.
            a.AnadirDatosGenerales("S/", "0.00")
            'I.G.V
            a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.igv01.GetValueOrDefault)
            'BOLSA
            a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.icbper.GetValueOrDefault)
            'IMPORTE TOTAL
            a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.ImporteNacional.GetValueOrDefault)

            '//DESCRIICION DE DETALLE DE TOTAL IMKPORTE Y NUMEROS BANCARIOS

            ''DESCRIPCION DEL IMPORTE TOTAL EN LETRAS
            'BANCO SOLES
            'BANCO DOLARES
            'NOTA DE CAMBIOS
            a.AnadirLineaTotalFactura(documentoBE.documentoventaAbarrotes.ImporteNacional,
                                  objDatosGenrales.nroCuentaSoles,
                                    objDatosGenrales.nroCuentaSoles2,
                                  objDatosGenrales.nroCuentaDolares,
                                   objDatosGenrales.nroCuentaDolares2,
                                  objDatosGenrales.glosario)


            a.headerImagenQR = QrCodeImgControl1.Image


            Select Case tipocomprobante
                Case "1"
                    a.tipoComprobante = "1"
                    'a.GuardanImpresion("Microsoft Print to PDF", txtDireccionEnvio.Text, TextBoxUSUARIO.Text, TextBoxCONTRASEÑA.Text, TextBoxDESTINO.Text, TextBoxASUNTO.Text, TextBoxTEXTO.Text)

                Case "2"
                    a.tipoComprobante = "2"
                    'a.GuardanImpresion("Microsoft Print to PDF", txtDireccionEnvio.Text, TextBoxUSUARIO.Text, TextBoxCONTRASEÑA.Text, TextBoxDESTINO.Text, TextBoxASUNTO.Text, TextBoxTEXTO.Text)


            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub ImprimirTicketDirectaA4Formato5()
        Try

            Dim a As TicketA4v5 = New TicketA4v5
            ' Logo de la Empresa
            Dim lista As New List(Of String)
            Dim numeracion As Integer = 1
            Dim gravMN As Decimal = 0
            Dim gravME As Decimal = 0
            Dim ExoMN As Decimal = 0
            Dim ExoME As Decimal = 0
            Dim InaMN As Decimal = 0
            Dim InaME As Decimal = 0
            Dim ticket As New CrearTicket()
            Dim nombreComprabante As String
            '  Dim r As Record = dgPedidos.Table.CurrentRecord
            Dim entidadSA As New entidadSA
            'Dim documentoSA As New documentoVentaAbarrotesSA
            'Dim documentoDetSA As New documentoVentaAbarrotesDetSA
            'Dim documentoBE.documentoventaAbarrotes = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
            'Dim documentoBE.documentoventaAbarrotesDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
            Dim tipocomprobante As String = String.Empty

            If (Not IsNothing(documentoBE.documentoventaAbarrotes.CustomEntidad.email)) Then
                txtDireccionEnvio.Text = documentoBE.documentoventaAbarrotes.CustomEntidad.email
            End If


            'Dim rucCliente As String
            If (objDatosGenrales.logo.Length > 0) Then
                '//POSISCION DE LA IMAGEN
                a.PosicionLogo = objDatosGenrales.posicionLogo
                ' Logo de la Empresa
                a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
            End If

            '//DATOS GENERALES DE LA EMPRESA
            Dim Telefono As String = String.Empty
            If (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length > 0 And objDatosGenrales.telefono4.Length = 0) Then
                Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3)
            ElseIf (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length = 0 And objDatosGenrales.telefono4.Length = 0) Then
                Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
            ElseIf (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length > 0 And objDatosGenrales.telefono4.Length > 0) Then
                Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3 & " - " & objDatosGenrales.telefono4)
            Else
                Telefono = ("TELF: " & objDatosGenrales.telefono1)
            End If

            a.AnadirLineaEmpresa(objDatosGenrales.razonSocial,
                            objDatosGenrales.nombreCorto,
                            "Domicilio Fiscal: " & objDatosGenrales.direccionPrincipal,
                            "Establ. Anexo: " & objDatosGenrales.direccionSecudaria,
                            "Telf: " & Telefono)


            Select Case documentoBE.documentoventaAbarrotes.tipoDocumento
                Case "12.1"
                    '//DATOS GENERALES RUC - SERIE NUMERO Y TIPO documentoBE.documentoventaAbarrotes
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                    nombreComprabante = "BOLETA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipocomprobante = "1"

                    TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA ELECTRONICA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA ELECTRONICA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                    numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                    tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                Case "12.2"
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                    nombreComprabante = "FACTURA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipocomprobante = "1"

                    TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA ELECTRONICA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA ELECTRONICA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                    numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                    tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                Case "03"
                    If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA ELECTRONICA")
                        nombreComprabante = "BOLETA ELECTRONICA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                        tipocomprobante = "2"

                        TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA ELECTRONICA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA ELECTRONICA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                        numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                        tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                    ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                        nombreComprabante = "BOLETA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                        tipocomprobante = "1"

                        TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                        numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                        tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                    End If
                Case "01"
                    If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA ELECTRONICA")
                        nombreComprabante = "FACTURA ELECTRONICA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                        tipocomprobante = "2"


                        TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA ELECTRONICA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA ELECTRONICA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                        numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                        tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                    ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                        nombreComprabante = "FACTURA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                        tipocomprobante = "1"

                        TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                        numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                        tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                    End If
                Case "9903" '"9901"
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serie & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroDoc).PadLeft(8, "0"c),
                                      "COTIZACIÓN")
                    nombreComprabante = "COTIZACIÓN" & documentoBE.documentoventaAbarrotes.serie & documentoBE.documentoventaAbarrotes.numeroDoc
                    tipocomprobante = "1"

                    TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA" & 0 & "-" & 0
                    txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA-" & 0 & "-" & 0
                    serieFactura = 0
                    numeroFactura = 0
                    tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                Case Else
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "NOTA")
                    nombreComprabante = "NOTA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipocomprobante = "1"

                    TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                    numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                    tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

            End Select

            Dim entidad = documentoBE.documentoventaAbarrotes.CustomEntidad ' entidadSA.UbicarEntidadPorID(documentoBE.documentoventaAbarrotes.idCliente).FirstOrDefault
            Dim NBoletaElectronica As String '= entidad.nombreCompleto
            Dim nBoletaNumero As String
            'ticket.TextoIzquierda(NBoletaElectronica)


            If (Not IsNothing(entidad.nrodoc)) Then

                If entidad.nrodoc.Trim.Length = 11 Then
                    nBoletaNumero = "R.U.C. - " & entidad.nrodoc
                ElseIf entidad.nrodoc.Trim.Length = 8 Then
                    nBoletaNumero = "D.N.I. - " & entidad.nrodoc
                Else
                    nBoletaNumero = entidad.nrodoc
                End If
            Else
                nBoletaNumero = "-"
            End If

            If entidad.tipoEntidad = "VR" Then
                NBoletaElectronica = documentoBE.documentoventaAbarrotes.nombrePedido
            Else
                NBoletaElectronica = entidad.nombreCompleto
            End If

            '//DATOS DEL CLIENTE
            'Fecha de Factura
            'Lugar de la factura
            'Nombre del cliente
            'direccion del cliente
            'numero del cliente
            'direccion de entrega
            'tipo moneda de la empresa
            'telefono de la empresa
            a.AnadirLineaCaracteresDatosGEnerales(documentoBE.documentoventaAbarrotes.fechaDoc.Value.ToShortDateString(),
                                              "",
                                              NBoletaElectronica,
                                             entidad.direccion,
                                             documentoBE.documentoventaAbarrotes.nombrePedido,
                                              nBoletaNumero,
                                              "PEN",
                                              "")

            If (Not IsNothing(HASH)) Then
                If HASH.Trim.Length > 0 Then
                    QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                      "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
                      "|" & HASH & "|" & CERTIFICADO)

                    QrCodeImgControl1.Text = QR
                Else
                    QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                     "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                    QrCodeImgControl1.Text = QR
                End If
            Else
                QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                 "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                QrCodeImgControl1.Text = QR
            End If





            '//DATOS COMPLEMENTARIOS
            'Nro. Pedido
            'Fecha Pedido
            'Orden de compra
            'fecha de Orden de Compra
            'Guia de remisiionm
            'FEcha de guia de remisuion
            'forma de venta
            'Tipo de Venta

            Dim tipoVenta As String = String.Empty

            Select Case documentoBE.documentoventaAbarrotes.estadoCobro
                Case "DC"
                    tipoVenta = "CONTADO"
                Case "PN"
                    tipoVenta = "CREDITO"
            End Select

            a.AnadirLineaDatosComplementarios("-",
                                          "-",
                                          documentoBE.documentoventaAbarrotes.nroOrdenVenta,
                                              "-",
                                              documentoBE.documentoventaAbarrotes.nroGuia,
                                              "-",
                                              "-",
                                          tipoVenta)

            '//DATOS DE LOS DETALLES DE LOS ITEMS
            '*********************** TODO LOS DETALLES DE LOS ITEM *********************
            'CODIGO
            'DESCRIPCION
            'CANTIDAD
            'UM
            'VALOR VENTA UNITARIO
            'DESCUENTO
            'VALOR DE VENTA TOTAL
            'OTROS CARGOS
            'IMPUESTOS
            'PRECIO DE VENTA
            'VALOR TOTAL


            For Each i In documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet

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

                If (Not IsNothing(i.CustomEquivalencia)) Then
                    a.AnadirLineaElementosFactura(i.descuentoMN.GetValueOrDefault,
                                       $"{i.nombreItem} {i.detalleAdicional}({i.CustomEquivalencia.unidadComercial})",
                                      i.monto1,
                                      i.unidad1,
                                      (i.montokardex) / i.monto1,
                                      "0.00",
                                      i.montokardex,
                                      "0.00",
                                      i.montoIgv,
                                      i.importeMN / i.monto1,
                                      i.importeMN)

                Else
                    a.AnadirLineaElementosFactura(i.descuentoMN.GetValueOrDefault,
                              $"{i.nombreItem} {i.detalleAdicional}",
                                      i.monto1,
                                      i.unidad1,
                                      (i.montokardex) / i.monto1,
                                      "0.00",
                                      i.montokardex,
                                      "0.00",
                                      i.montoIgv,
                                      i.importeMN / i.monto1,
                                      i.importeMN)
                End If


                numeracion += 1

            Next

            '********************************** RESUMEN GENERAL DE LA FACTURA **************************
            'GRATUITAS
            a.AnadirDatosGenerales("S/", "0.00")
            'EXONERADAS
            a.AnadirDatosGenerales("S/", ExoMN)
            'INAFECTA
            a.AnadirDatosGenerales("S/", InaMN)
            'GRAVADA
            a.AnadirDatosGenerales("S/", gravMN)
            'TOTAL DESCUENTO
            a.AnadirDatosGenerales("S/", "0.00")
            'I.S.C.
            a.AnadirDatosGenerales("S/", "0.00")
            'I.G.V
            a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.igv01.GetValueOrDefault)
            'BOLSA
            a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.icbper.GetValueOrDefault)
            'IMPORTE TOTAL
            a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.ImporteNacional.GetValueOrDefault)


            '//DESCRIICION DE DETALLE DE TOTAL IMKPORTE Y NUMEROS BANCARIOS

            ''DESCRIPCION DEL IMPORTE TOTAL EN LETRAS
            'BANCO SOLES
            'BANCO DOLARES
            'NOTA DE CAMBIOS
            a.AnadirLineaTotalFactura(documentoBE.documentoventaAbarrotes.ImporteNacional,
                                  objDatosGenrales.nroCuentaSoles,
                                    objDatosGenrales.nroCuentaSoles2,
                                  objDatosGenrales.nroCuentaDolares,
                                   objDatosGenrales.nroCuentaDolares2,
                                  objDatosGenrales.glosario)


            a.headerImagenQR = QrCodeImgControl1.Image


            'Select Case tipocomprobante
            '    Case "1"
            '        a.tipoComprobante = "1"
            '        a.GuardanImpresion("Microsoft Print to PDF", txtDireccionEnvio.Text, TextBoxUSUARIO.Text, TextBoxCONTRASEÑA.Text, TextBoxDESTINO.Text, TextBoxASUNTO.Text, TextBoxTEXTO.Text)

            '    Case "2"
            '        a.tipoComprobante = "2"
            '        a.GuardanImpresion("Microsoft Print to PDF", txtDireccionEnvio.Text, TextBoxUSUARIO.Text, TextBoxCONTRASEÑA.Text, TextBoxDESTINO.Text, TextBoxASUNTO.Text, TextBoxTEXTO.Text)


            'End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

#End Region

#Region "IMPRIMIR DIRECTP FORAMTO 2  - A4"
    Public Sub ImprimirTicketDirectaA4Formato2()
        Try

            Dim a As TicketA4v2 = New TicketA4v2
            ' Logo de la Empresa
            Dim lista As New List(Of String)

            Dim gravMN As Decimal = 0
            Dim gravME As Decimal = 0
            Dim ExoMN As Decimal = 0
            Dim ExoME As Decimal = 0
            Dim InaMN As Decimal = 0
            Dim InaME As Decimal = 0
            Dim ticket As New CrearTicket()
            Dim nombreComprabante As String
            '  Dim r As Record = dgPedidos.Table.CurrentRecord
            Dim entidadSA As New entidadSA
            'Dim documentoSA As New documentoVentaAbarrotesSA
            'Dim documentoDetSA As New documentoVentaAbarrotesDetSA
            'Dim documentoBE.documentoventaAbarrotes = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
            'Dim documentoBE.documentoventaAbarrotesDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
            Dim tipocomprobante As String = String.Empty

            'Dim rucCliente As String
            If (objDatosGenrales.logo.Length > 0) Then
                '//POSISCION DE LA IMAGEN
                a.PosicionLogo = objDatosGenrales.posicionLogo
                ' Logo de la Empresa
                a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
            End If

            '//DATOS GENERALES DE LA EMPRESA
            Dim Telefono As String = String.Empty
            If (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length > 0 And objDatosGenrales.telefono4.Length = 0) Then
                Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3)
            ElseIf (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length = 0 And objDatosGenrales.telefono4.Length = 0) Then
                Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
            ElseIf (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length > 0 And objDatosGenrales.telefono4.Length > 0) Then
                Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3 & " - " & objDatosGenrales.telefono4)
            Else
                Telefono = ("TELF: " & objDatosGenrales.telefono1)
            End If

            a.AnadirLineaEmpresa(objDatosGenrales.razonSocial,
                            objDatosGenrales.nombreCorto,
                            "Domicilio Fiscal: " & objDatosGenrales.direccionPrincipal,
                            "Establ. Anexo: " & objDatosGenrales.direccionSecudaria,
                            "Telf: " & Telefono)


            Select Case documentoBE.documentoventaAbarrotes.tipoDocumento
                Case "12.1"
                    '//DATOS GENERALES RUC - SERIE NUMERO Y TIPO documentoBE.documentoventaAbarrotes
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                    nombreComprabante = "BOLETA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipocomprobante = "1"

                    TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA ELECTRONICA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA ELECTRONICA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                    numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                    tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                Case "12.2"
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                    nombreComprabante = "FACTURA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipocomprobante = "1"

                    TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA ELECTRONICA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA ELECTRONICA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                    numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                    tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                Case "03"
                    If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA ELECTRONICA")
                        nombreComprabante = "BOLETA ELECTRONICA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                        tipocomprobante = "2"

                        TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA ELECTRONICA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA ELECTRONICA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                        numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                        tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                    ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                        nombreComprabante = "BOLETA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                        tipocomprobante = "1"

                        TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                        numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                        tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                    End If
                Case "01"
                    If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA ELECTRONICA")
                        nombreComprabante = "FACTURA ELECTRONICA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                        tipocomprobante = "2"


                        TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA ELECTRONICA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA ELECTRONICA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                        numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                        tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                    ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                        nombreComprabante = "FACTURA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                        tipocomprobante = "1"

                        TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                        numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                        tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                    End If
                Case "9903" '"9901"
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serie & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroDoc).PadLeft(8, "0"c),
                                      "COTIZACIÓN")
                    nombreComprabante = "COTIZACIÓN" & documentoBE.documentoventaAbarrotes.serie & documentoBE.documentoventaAbarrotes.numeroDoc
                    tipocomprobante = "1"

                    TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA" & 0 & "-" & 0
                    txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA-" & 0 & "-" & 0
                    serieFactura = 0
                    numeroFactura = 0
                    tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                Case Else
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "NOTA")
                    nombreComprabante = "NOTA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipocomprobante = "1"

                    TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                    numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                    tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento
            End Select

            Dim entidad = documentoBE.documentoventaAbarrotes.CustomEntidad ' entidadSA.UbicarEntidadPorID(documentoBE.documentoventaAbarrotes.idCliente).FirstOrDefault
            Dim NBoletaElectronica As String '= entidad.nombreCompleto
            Dim nBoletaNumero As String
            'ticket.TextoIzquierda(NBoletaElectronica)


            If (Not IsNothing(entidad.nrodoc)) Then

                If entidad.nrodoc.Trim.Length = 11 Then
                    nBoletaNumero = "R.U.C. - " & entidad.nrodoc
                ElseIf entidad.nrodoc.Trim.Length = 8 Then
                    nBoletaNumero = "D.N.I. - " & entidad.nrodoc
                Else
                    nBoletaNumero = entidad.nrodoc
                End If
            Else
                nBoletaNumero = "-"
            End If

            If entidad.tipoEntidad = "VR" Then
                NBoletaElectronica = documentoBE.documentoventaAbarrotes.nombrePedido
            Else
                NBoletaElectronica = entidad.nombreCompleto
            End If

            Dim tipomoneda As String = String.Empty

            If (documentoBE.documentoventaAbarrotes.moneda = 1) Then
                tipomoneda = "PEN"
                a.TipoMoneda = "SOL"
            ElseIf (documentoBE.documentoventaAbarrotes.moneda = 2) Then
                tipomoneda = "USD"
                a.TipoMoneda = "USD"
            End If

            '//DATOS DEL CLIENTE
            'Fecha de Factura
            'Lugar de la factura
            'Nombre del cliente
            'direccion del cliente
            'numero del cliente
            'direccion de entrega
            'tipo moneda de la empresa
            'telefono de la empresa
            a.AnadirLineaCaracteresDatosGEnerales(documentoBE.documentoventaAbarrotes.fechaDoc.Value.ToShortDateString(),
                                          "",
                                          NBoletaElectronica,
                                         entidad.direccion,
                                         documentoBE.documentoventaAbarrotes.nombrePedido,
                                          nBoletaNumero,
                                          tipomoneda,
                                          tienda)

            If (Not IsNothing(HASH)) Then
                If HASH.Trim.Length > 0 Then
                    QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                      "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
                      "|" & HASH & "|" & CERTIFICADO)

                    QrCodeImgControl1.Text = QR
                Else
                    QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                     "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                    QrCodeImgControl1.Text = QR
                End If
            Else
                QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                 "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                QrCodeImgControl1.Text = QR
            End If





            '//DATOS COMPLEMENTARIOS
            'Nro. Pedido
            'Fecha Pedido
            'Orden de compra
            'fecha de Orden de Compra
            'Guia de remisiionm
            'FEcha de guia de remisuion
            'forma de venta
            'Tipo de Venta

            Dim tipoVenta As String = String.Empty

            Select Case documentoBE.documentoventaAbarrotes.estadoCobro
                Case "DC"
                    tipoVenta = "CONTADO"
                Case "PN"
                    tipoVenta = "CREDITO"
            End Select

            a.AnadirLineaDatosComplementarios("-",
                                          "-",
                                          documentoBE.documentoventaAbarrotes.nroOrdenVenta,
                                              "-",
                                              documentoBE.documentoventaAbarrotes.nroGuia,
                                              "-",
                                              "-",
                                         "-")



            '********************************** RESUMEN GENERAL DE LA FACTURA **************************

            If (documentoBE.documentoventaAbarrotes.moneda = 1) Then

                '//DATOS DE LOS DETALLES DE LOS ITEMS
                '*********************** TODO LOS DETALLES DE LOS ITEM *********************
                'CODIGO
                'DESCRIPCION
                'CANTIDAD
                'UM
                'VALOR VENTA UNITARIO
                'DESCUENTO
                'VALOR DE VENTA TOTAL
                'OTROS CARGOS
                'IMPUESTOS
                'PRECIO DE VENTA
                'VALOR TOTAL


                For Each i In documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet

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


                    If (Not IsNothing(i.CustomEquivalencia)) Then
                        a.AnadirLineaElementosFactura(i.codigoBarra,
                                  $"{i.nombreItem} {i.detalleAdicional}({i.CustomEquivalencia.unidadComercial})",
                                     CInt(i.monto1),
                                        i.unidad1,
                                      (i.montokardex) / i.monto1,
                                      "0.00",
                                      i.montokardex,
                                      "0.00",
                                      i.montoIgv,
                                      i.importeMN / i.monto1,
                                      i.importeMN)

                    Else
                        a.AnadirLineaElementosFactura(i.codigoBarra,
                                      $"{i.nombreItem} {i.detalleAdicional}",
                                           CInt(i.monto1),
                                    i.unidad1,
                                            (i.montokardex) / i.monto1,
                                            "0.00",
                                            i.montokardex,
                                            "0.00",
                                            i.montoIgv,
                                            i.importeMN / i.monto1,
                                            i.importeMN)

                    End If


                Next

                '     '********************************** RESUMEN GENERAL DE LA FACTURA **************************
                'GRATUITAS
                a.AnadirDatosGenerales("S/", "0.00")
                'EXONERADAS
                a.AnadirDatosGenerales("S/", ExoMN)
                'INAFECTA
                a.AnadirDatosGenerales("S/", InaMN)
                'GRAVADA
                a.AnadirDatosGenerales("S/", gravMN)
                'TOTAL DESCUENTO
                a.AnadirDatosGenerales("S/", "0.00")
                'I.S.C.
                a.AnadirDatosGenerales("S/", "0.00")
                'I.G.V
                a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.igv01.GetValueOrDefault)
                'BOLSA
                a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.icbper.GetValueOrDefault)
                'IMPORTE TOTAL
                a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.ImporteNacional.GetValueOrDefault)

                '//DESCRIICION DE DETALLE DE TOTAL IMKPORTE Y NUMEROS BANCARIOS

                ''DESCRIPCION DEL IMPORTE TOTAL EN LETRAS
                'BANCO SOLES
                'BANCO DOLARES
                'NOTA DE CAMBIOS
                a.AnadirLineaTotalFactura(documentoBE.documentoventaAbarrotes.ImporteNacional,
                                      objDatosGenrales.nroCuentaSoles,
                                        objDatosGenrales.nroCuentaSoles2,
                                      objDatosGenrales.nroCuentaDolares,
                                       objDatosGenrales.nroCuentaDolares2,
                                      objDatosGenrales.glosario)

            ElseIf (documentoBE.documentoventaAbarrotes.moneda = 2) Then

                '//DATOS DE LOS DETALLES DE LOS ITEMS
                '*********************** TODO LOS DETALLES DE LOS ITEM *********************
                'CODIGO
                'DESCRIPCION
                'CANTIDAD
                'UM
                'VALOR VENTA UNITARIO
                'DESCUENTO
                'VALOR DE VENTA TOTAL
                'OTROS CARGOS
                'IMPUESTOS
                'PRECIO DE VENTA
                'VALOR TOTAL


                For Each i In documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet

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

                    a.AnadirLineaElementosFactura(i.codigoBarra,
                                      i.nombreItem,
                                     CInt(i.monto1),
                                      i.CustomEquivalencia.unidadComercial,
                                      (i.montokardexUS) / i.monto1,
                                      "0.00",
                                      i.montokardexUS,
                                      "0.00",
                                      i.montoIgvUS,
                                      i.importeME / i.monto1,
                                      i.importeME)

                Next

                'GRATUITAS
                a.AnadirDatosGenerales("$", "0.00")
                'EXONERADAS
                a.AnadirDatosGenerales("$", ExoME)
                'INAFECTA
                a.AnadirDatosGenerales("$", InaME)
                'GRAVADA
                a.AnadirDatosGenerales("$", gravME)
                'TOTAL DESCUENTO
                a.AnadirDatosGenerales("$", "0.00")
                'I.S.C.
                a.AnadirDatosGenerales("$", "0.00")
                'I.G.V
                a.AnadirDatosGenerales("$", documentoBE.documentoventaAbarrotes.igv01us)
                'IMPORTE TOTAL
                a.AnadirDatosGenerales("$", documentoBE.documentoventaAbarrotes.ImporteExtranjero)

                '//DESCRIICION DE DETALLE DE TOTAL IMKPORTE Y NUMEROS BANCARIOS

                ''DESCRIPCION DEL IMPORTE TOTAL EN LETRAS
                'BANCO SOLES
                'BANCO DOLARES
                'NOTA DE CAMBIOS
                a.AnadirLineaTotalFactura(documentoBE.documentoventaAbarrotes.ImporteExtranjero,
                                      objDatosGenrales.nroCuentaSoles,
                                        objDatosGenrales.nroCuentaSoles2,
                                      objDatosGenrales.nroCuentaDolares,
                                       objDatosGenrales.nroCuentaDolares2,
                                      objDatosGenrales.glosario)

            End If

            a.headerImagenQR = QrCodeImgControl1.Image


            'Select Case tipocomprobante
            '    Case "1"
            '        a.tipoComprobante = "1"
            '        a.GuardanImpresion("Microsoft Print to PDF", txtDireccionEnvio.Text, TextBoxUSUARIO.Text, TextBoxCONTRASEÑA.Text, TextBoxDESTINO.Text, TextBoxASUNTO.Text, TextBoxTEXTO.Text)

            '    Case "2"
            '        a.tipoComprobante = "2"
            '        a.GuardanImpresion("Microsoft Print to PDF", txtDireccionEnvio.Text, TextBoxUSUARIO.Text, TextBoxCONTRASEÑA.Text, TextBoxDESTINO.Text, TextBoxASUNTO.Text, TextBoxTEXTO.Text)

            'End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region


#Region "IMPRIMIR DIRECTP FORAMTO 2  - A4"
    Public Sub ImprimirTicketDirectaA4Formato6()
        Try

            Dim a As TicketA4v6 = New TicketA4v6
            ' Logo de la Empresa
            Dim lista As New List(Of String)

            Dim gravMN As Decimal = 0
            Dim gravME As Decimal = 0
            Dim ExoMN As Decimal = 0
            Dim ExoME As Decimal = 0
            Dim InaMN As Decimal = 0
            Dim InaME As Decimal = 0
            Dim ticket As New CrearTicket()
            Dim nombreComprabante As String
            '  Dim r As Record = dgPedidos.Table.CurrentRecord
            Dim entidadSA As New entidadSA
            'Dim documentoSA As New documentoVentaAbarrotesSA
            'Dim documentoDetSA As New documentoVentaAbarrotesDetSA
            'Dim documentoBE.documentoventaAbarrotes = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
            'Dim documentoBE.documentoventaAbarrotesDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
            Dim tipocomprobante As String = String.Empty

            'Dim rucCliente As String
            If (objDatosGenrales.logo.Length > 0) Then
                '//POSISCION DE LA IMAGEN
                a.PosicionLogo = objDatosGenrales.posicionLogo
                ' Logo de la Empresa
                a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
            End If

            '//DATOS GENERALES DE LA EMPRESA
            Dim Telefono As String = String.Empty
            If (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length > 0 And objDatosGenrales.telefono4.Length = 0) Then
                Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3)
            ElseIf (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length = 0 And objDatosGenrales.telefono4.Length = 0) Then
                Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
            ElseIf (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length > 0 And objDatosGenrales.telefono4.Length > 0) Then
                Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3 & " - " & objDatosGenrales.telefono4)
            Else
                Telefono = ("TELF: " & objDatosGenrales.telefono1)
            End If

            a.AnadirLineaEmpresa(objDatosGenrales.razonSocial,
                            objDatosGenrales.nombreCorto,
                            "Domicilio Fiscal: " & objDatosGenrales.direccionPrincipal,
                            "Establ. Anexo: " & objDatosGenrales.direccionSecudaria,
                            "Telf: " & Telefono)


            Select Case documentoBE.documentoventaAbarrotes.tipoDocumento
                Case "12.1"
                    '//DATOS GENERALES RUC - SERIE NUMERO Y TIPO documentoBE.documentoventaAbarrotes
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                    nombreComprabante = "BOLETA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipocomprobante = "1"

                    TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA ELECTRONICA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA ELECTRONICA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                    numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                    tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                Case "12.2"
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                    nombreComprabante = "FACTURA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipocomprobante = "1"

                    TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA ELECTRONICA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA ELECTRONICA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                    numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                    tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                Case "03"
                    If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA ELECTRONICA")
                        nombreComprabante = "BOLETA ELECTRONICA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                        tipocomprobante = "2"

                        TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA ELECTRONICA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA ELECTRONICA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                        numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                        tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                    ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                        nombreComprabante = "BOLETA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                        tipocomprobante = "1"

                        TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                        numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                        tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                    End If
                Case "01"
                    If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA ELECTRONICA")
                        nombreComprabante = "FACTURA ELECTRONICA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                        tipocomprobante = "2"


                        TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA ELECTRONICA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA ELECTRONICA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                        numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                        tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                    ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                        nombreComprabante = "FACTURA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                        tipocomprobante = "1"

                        TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                        numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                        tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                    End If
                Case "9903" '"9901"
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serie & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroDoc).PadLeft(8, "0"c),
                                      "COTIZACIÓN")
                    nombreComprabante = "COTIZACIÓN" & documentoBE.documentoventaAbarrotes.serie & documentoBE.documentoventaAbarrotes.numeroDoc
                    tipocomprobante = "1"

                    TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA" & 0 & "-" & 0
                    txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA-" & 0 & "-" & 0
                    serieFactura = 0
                    numeroFactura = 0
                    tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                Case Else
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "NOTA")
                    nombreComprabante = "NOTA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipocomprobante = "1"

                    TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                    numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                    tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

            End Select

            Dim entidad = documentoBE.documentoventaAbarrotes.CustomEntidad ' entidadSA.UbicarEntidadPorID(documentoBE.documentoventaAbarrotes.idCliente).FirstOrDefault
            Dim NBoletaElectronica As String '= entidad.nombreCompleto
            Dim nBoletaNumero As String
            'ticket.TextoIzquierda(NBoletaElectronica)


            If (Not IsNothing(entidad.nrodoc)) Then

                If entidad.nrodoc.Trim.Length = 11 Then
                    nBoletaNumero = "R.U.C. - " & entidad.nrodoc
                ElseIf entidad.nrodoc.Trim.Length = 8 Then
                    nBoletaNumero = "D.N.I. - " & entidad.nrodoc
                Else
                    nBoletaNumero = entidad.nrodoc
                End If
            Else
                nBoletaNumero = "-"
            End If

            If entidad.tipoEntidad = "VR" Then
                NBoletaElectronica = documentoBE.documentoventaAbarrotes.nombrePedido
            Else
                NBoletaElectronica = entidad.nombreCompleto
            End If

            Dim tipomoneda As String = String.Empty

            If (documentoBE.documentoventaAbarrotes.moneda = 1) Then
                tipomoneda = "PEN"
                a.TipoMoneda = "SOL"
            ElseIf (documentoBE.documentoventaAbarrotes.moneda = 2) Then
                tipomoneda = "USD"
                a.TipoMoneda = "USD"
            End If

            '//DATOS DEL CLIENTE
            'Fecha de Factura
            'Lugar de la factura
            'Nombre del cliente
            'direccion del cliente
            'numero del cliente
            'direccion de entrega
            'tipo moneda de la empresa
            'telefono de la empresa
            a.AnadirLineaCaracteresDatosGEnerales(documentoBE.documentoventaAbarrotes.fechaDoc.Value.ToShortDateString(),
                                              "",
                                              NBoletaElectronica,
                                             entidad.direccion,
                                            UsuariosList.Where(Function(o) o.IDUsuario = documentoBE.documentoventaAbarrotes.usuarioActualizacion).SingleOrDefault.Full_Name,
                                              nBoletaNumero,
                                              tipomoneda,
                                              tienda)

            If (Not IsNothing(HASH)) Then
                If HASH.Trim.Length > 0 Then
                    QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                      "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
                      "|" & HASH & "|" & CERTIFICADO)

                    QrCodeImgControl1.Text = QR
                Else
                    QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                     "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                    QrCodeImgControl1.Text = QR
                End If
            Else
                QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                 "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                QrCodeImgControl1.Text = QR
            End If

            '//DATOS COMPLEMENTARIOS
            'Nro. Pedido
            'Fecha Pedido
            'Orden de compra
            'fecha de Orden de Compra
            'Guia de remisiionm
            'FEcha de guia de remisuion
            'forma de venta
            'Tipo de Venta

            Dim tipoVenta As String = String.Empty

            Select Case documentoBE.documentoventaAbarrotes.estadoCobro
                Case "DC"
                    tipoVenta = "CONTADO"
                Case "PN"
                    tipoVenta = "CREDITO"
            End Select

            a.AnadirLineaDatosComplementarios("-",
                                          "-",
                                          documentoBE.documentoventaAbarrotes.nroOrdenVenta,
                                              "-",
                                              documentoBE.documentoventaAbarrotes.nroGuia,
                                              "-",
                                              "-",
                                         "-")



            '********************************** RESUMEN GENERAL DE LA FACTURA **************************

            If (documentoBE.documentoventaAbarrotes.moneda = 1) Then

                '//DATOS DE LOS DETALLES DE LOS ITEMS
                '*********************** TODO LOS DETALLES DE LOS ITEM *********************
                'CODIGO
                'DESCRIPCION
                'CANTIDAD
                'UM
                'VALOR VENTA UNITARIO
                'DESCUENTO
                'VALOR DE VENTA TOTAL
                'OTROS CARGOS
                'IMPUESTOS
                'PRECIO DE VENTA
                'VALOR TOTAL


                For Each i In documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet

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

                    If (Not IsNothing(i.CustomEquivalencia)) Then

                        a.AnadirLineaElementosFactura(i.codigoBarra,
                                        $"{i.nombreItem} {i.detalleAdicional}({i.CustomEquivalencia.unidadComercial})",
                                     CInt(i.monto1),
                                       i.unidad1,
                                      (i.montokardex) / i.monto1,
                                      "0.00",
                                      i.montokardex,
                                      "0.00",
                                      i.montoIgv,
                                      i.importeMN / i.monto1,
                                      i.importeMN)

                    Else
                        a.AnadirLineaElementosFactura(i.codigoBarra,
                                        $"{i.nombreItem} {i.detalleAdicional}",
                                     CInt(i.monto1),
                                       i.unidad1,
                                      (i.montokardex) / i.monto1,
                                      "0.00",
                                      i.montokardex,
                                      "0.00",
                                      i.montoIgv,
                                      i.importeMN / i.monto1,
                                      i.importeMN)
                    End If

                    'a.AnadirLineaElementosFactura(i.codigoBarra,
                    '                  i.nombreItem,
                    '                 CInt(i.monto1),
                    '                  i.CustomEquivalencia.unidadComercial,
                    '                  (i.montokardex) / i.monto1,
                    '                  "0.00",
                    '                  i.montokardex,
                    '                  "0.00",
                    '                  i.montoIgv,
                    '                  i.importeMN / i.monto1,
                    '                  i.importeMN)

                Next

                '********************************** RESUMEN GENERAL DE LA FACTURA **************************
                'GRATUITAS
                a.AnadirDatosGenerales("S/", "0.00")
                'EXONERADAS
                a.AnadirDatosGenerales("S/", ExoMN)
                'INAFECTA
                a.AnadirDatosGenerales("S/", InaMN)
                'GRAVADA
                a.AnadirDatosGenerales("S/", gravMN)
                'TOTAL DESCUENTO
                a.AnadirDatosGenerales("S/", "0.00")
                'I.S.C.
                a.AnadirDatosGenerales("S/", "0.00")
                'I.G.V
                a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.igv01.GetValueOrDefault)
                'BOLSA
                a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.icbper.GetValueOrDefault)
                'IMPORTE TOTAL
                a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.ImporteNacional.GetValueOrDefault)

                '//DESCRIICION DE DETALLE DE TOTAL IMKPORTE Y NUMEROS BANCARIOS

                ''DESCRIPCION DEL IMPORTE TOTAL EN LETRAS
                'BANCO SOLES
                'BANCO DOLARES
                'NOTA DE CAMBIOS
                a.AnadirLineaTotalFactura(documentoBE.documentoventaAbarrotes.ImporteNacional,
                                      objDatosGenrales.nroCuentaSoles,
                                        objDatosGenrales.nroCuentaSoles2,
                                      objDatosGenrales.nroCuentaDolares,
                                       objDatosGenrales.nroCuentaDolares2,
                                      objDatosGenrales.glosario)

            ElseIf (documentoBE.documentoventaAbarrotes.moneda = 2) Then

                '//DATOS DE LOS DETALLES DE LOS ITEMS
                '*********************** TODO LOS DETALLES DE LOS ITEM *********************
                'CODIGO
                'DESCRIPCION
                'CANTIDAD
                'UM
                'VALOR VENTA UNITARIO
                'DESCUENTO
                'VALOR DE VENTA TOTAL
                'OTROS CARGOS
                'IMPUESTOS
                'PRECIO DE VENTA
                'VALOR TOTAL


                For Each i In documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet

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

                    If (Not IsNothing(i.CustomEquivalencia)) Then
                        a.AnadirLineaElementosFactura(i.codigoBarra,
                                       $"{i.nombreItem} ({i.detalleAdicional})({i.CustomEquivalencia.unidadComercial})",
                                     CInt(i.monto1),
                                      i.unidad1,
                                      (i.montokardex) / i.monto1,
                                      "0.00",
                                      i.montokardex,
                                      "0.00",
                                      i.montoIgv,
                                      i.importeMN / i.monto1,
                                      i.importeMN)
                    Else
                        a.AnadirLineaElementosFactura(i.codigoBarra,
                                   $"{i.nombreItem} ({i.detalleAdicional})",
                                 CInt(i.monto1),
                                  i.unidad1,
                                  (i.montokardex) / i.monto1,
                                  "0.00",
                                  i.montokardex,
                                  "0.00",
                                  i.montoIgv,
                                  i.importeMN / i.monto1,
                                  i.importeMN)

                    End If



                Next

                'GRATUITAS
                a.AnadirDatosGenerales("$", "0.00")
                'EXONERADAS
                a.AnadirDatosGenerales("$", ExoME)
                'INAFECTA
                a.AnadirDatosGenerales("$", InaME)
                'GRAVADA
                a.AnadirDatosGenerales("$", gravME)
                'TOTAL DESCUENTO
                a.AnadirDatosGenerales("$", "0.00")
                'I.S.C.
                a.AnadirDatosGenerales("$", "0.00")
                'I.G.V
                a.AnadirDatosGenerales("$", documentoBE.documentoventaAbarrotes.igv01us)
                'IMPORTE TOTAL
                a.AnadirDatosGenerales("$", documentoBE.documentoventaAbarrotes.ImporteExtranjero)

                '//DESCRIICION DE DETALLE DE TOTAL IMKPORTE Y NUMEROS BANCARIOS

                ''DESCRIPCION DEL IMPORTE TOTAL EN LETRAS
                'BANCO SOLES
                'BANCO DOLARES
                'NOTA DE CAMBIOS
                a.AnadirLineaTotalFactura(documentoBE.documentoventaAbarrotes.ImporteExtranjero,
                                      objDatosGenrales.nroCuentaSoles,
                                        objDatosGenrales.nroCuentaSoles2,
                                      objDatosGenrales.nroCuentaDolares,
                                       objDatosGenrales.nroCuentaDolares2,
                                      objDatosGenrales.glosario)

            End If

            a.headerImagenQR = QrCodeImgControl1.Image


            'Select Case tipocomprobante
            '    Case "1"
            '        a.tipoComprobante = "1"
            '        a.GuardanImpresion("Microsoft Print to PDF", txtDireccionEnvio.Text, TextBoxUSUARIO.Text, TextBoxCONTRASEÑA.Text, TextBoxDESTINO.Text, TextBoxASUNTO.Text, TextBoxTEXTO.Text)

            '    Case "2"
            '        a.tipoComprobante = "2"
            '        a.GuardanImpresion("Microsoft Print to PDF", txtDireccionEnvio.Text, TextBoxUSUARIO.Text, TextBoxCONTRASEÑA.Text, TextBoxDESTINO.Text, TextBoxASUNTO.Text, TextBoxTEXTO.Text)

            'End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "IMPRIMIR DIRECTP FORAMTO 3  - A4"
    Public Sub ImprimirTicketDirectaA4Formato_Detraccion()
        Try

            Dim a As TicketA4v3 = New TicketA4v3
            ' Logo de la Empresa
            Dim lista As New List(Of String)

            Dim gravMN As Decimal = 0
            Dim gravME As Decimal = 0
            Dim ExoMN As Decimal = 0
            Dim ExoME As Decimal = 0
            Dim InaMN As Decimal = 0
            Dim InaME As Decimal = 0
            Dim ticket As New CrearTicket()
            Dim nombreComprabante As String
            '  Dim r As Record = dgPedidos.Table.CurrentRecord
            Dim entidadSA As New entidadSA
            'Dim documentoSA As New documentoVentaAbarrotesSA
            'Dim documentoDetSA As New documentoVentaAbarrotesDetSA
            'Dim documentoBE.documentoventaAbarrotes = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
            'Dim documentoBE.documentoventaAbarrotesDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
            Dim tipocomprobante As String = String.Empty

            'Dim rucCliente As String
            If (objDatosGenrales.logo.Length > 0) Then
                '//POSISCION DE LA IMAGEN
                a.PosicionLogo = objDatosGenrales.posicionLogo
                ' Logo de la Empresa
                a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
            End If

            '//DATOS GENERALES DE LA EMPRESA
            Dim Telefono As String = String.Empty
            If (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length > 0 And objDatosGenrales.telefono4.Length = 0) Then
                Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3)
            ElseIf (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length = 0 And objDatosGenrales.telefono4.Length = 0) Then
                Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
            ElseIf (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length > 0 And objDatosGenrales.telefono4.Length > 0) Then
                Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3 & " - " & objDatosGenrales.telefono4)
            Else
                Telefono = ("TELF: " & objDatosGenrales.telefono1)
            End If

            a.AnadirLineaEmpresa(objDatosGenrales.razonSocial,
                            objDatosGenrales.nombreCorto,
                            "Domicilio Fiscal: " & objDatosGenrales.direccionPrincipal,
                            "Establ. Anexo: " & objDatosGenrales.direccionSecudaria,
                            "Telf: " & Telefono)


            Select Case documentoBE.documentoventaAbarrotes.tipoDocumento
                Case "12.1"
                    '//DATOS GENERALES RUC - SERIE NUMERO Y TIPO documentoBE.documentoventaAbarrotes
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                    nombreComprabante = "BOLETA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipocomprobante = "1"

                    TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA ELECTRONICA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA ELECTRONICA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                    numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                    tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                Case "12.2"
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                    nombreComprabante = "FACTURA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipocomprobante = "1"

                    TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA ELECTRONICA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA ELECTRONICA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                    numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                    tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                Case "03"
                    If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA ELECTRONICA")
                        nombreComprabante = "BOLETA ELECTRONICA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                        tipocomprobante = "2"

                        TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA ELECTRONICA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA ELECTRONICA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                        numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                        tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                    ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                        nombreComprabante = "BOLETA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                        tipocomprobante = "1"

                        TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                        numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                        tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                    End If
                Case "01"
                    If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA ELECTRONICA")
                        nombreComprabante = "FACTURA ELECTRONICA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                        tipocomprobante = "2"


                        TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA ELECTRONICA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA ELECTRONICA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                        numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                        tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                    ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                        nombreComprabante = "FACTURA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                        tipocomprobante = "1"

                        TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                        numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                        tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                    End If
                Case "9903" '"9901"
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serie & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroDoc).PadLeft(8, "0"c),
                                      "COTIZACIÓN")
                    nombreComprabante = "COTIZACIÓN" & documentoBE.documentoventaAbarrotes.serie & documentoBE.documentoventaAbarrotes.numeroDoc
                    tipocomprobante = "1"

                    TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA" & 0 & "-" & 0
                    txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA-" & 0 & "-" & 0
                    serieFactura = 0
                    numeroFactura = 0
                    tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento

                Case Else
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "NOTA")
                    nombreComprabante = "NOTA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipocomprobante = "1"

                    TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    serieFactura = documentoBE.documentoventaAbarrotes.serieVenta
                    numeroFactura = documentoBE.documentoventaAbarrotes.numeroVenta
                    tipoDocumento = documentoBE.documentoventaAbarrotes.tipoDocumento
            End Select

            Dim entidad = documentoBE.documentoventaAbarrotes.CustomEntidad ' entidadSA.UbicarEntidadPorID(documentoBE.documentoventaAbarrotes.idCliente).FirstOrDefault
            Dim NBoletaElectronica As String '= entidad.nombreCompleto
            Dim nBoletaNumero As String
            'ticket.TextoIzquierda(NBoletaElectronica)


            If (Not IsNothing(entidad.nrodoc)) Then

                If entidad.nrodoc.Trim.Length = 11 Then
                    nBoletaNumero = "R.U.C. - " & entidad.nrodoc
                ElseIf entidad.nrodoc.Trim.Length = 8 Then
                    nBoletaNumero = "D.N.I. - " & entidad.nrodoc
                Else
                    nBoletaNumero = entidad.nrodoc
                End If
            Else
                nBoletaNumero = "-"
            End If

            If entidad.tipoEntidad = "VR" Then
                NBoletaElectronica = documentoBE.documentoventaAbarrotes.nombrePedido
            Else
                NBoletaElectronica = entidad.nombreCompleto
            End If

            '//DATOS DEL CLIENTE
            'Fecha de Factura
            'Lugar de la factura
            'Nombre del cliente
            'direccion del cliente
            'numero del cliente
            'direccion de entrega
            'tipo moneda de la empresa
            'telefono de la empresa
            a.AnadirLineaCaracteresDatosGEnerales(documentoBE.documentoventaAbarrotes.fechaDoc.Value.ToShortDateString(),
                                              "",
                                              NBoletaElectronica,
                                             entidad.direccion,
                                             documentoBE.documentoventaAbarrotes.nombrePedido,
                                              nBoletaNumero,
                                              "PEN",
                                              tienda)

            If (Not IsNothing(HASH)) Then
                If HASH.Trim.Length > 0 Then
                    QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                      "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
                      "|" & HASH & "|" & CERTIFICADO)

                    QrCodeImgControl1.Text = QR
                Else
                    QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                     "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                    QrCodeImgControl1.Text = QR
                End If
            Else
                QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                 "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                QrCodeImgControl1.Text = QR
            End If




            '//DATOS COMPLEMENTARIOS
            'Nro. Pedido
            'Fecha Pedido
            'Orden de compra
            'fecha de Orden de Compra
            'Guia de remisiionm
            'FEcha de guia de remisuion
            'forma de venta
            'Tipo de Venta

            Dim tipoVenta As String = String.Empty

            Select Case documentoBE.documentoventaAbarrotes.estadoCobro
                Case "DC"
                    tipoVenta = "CONTADO"
                Case "PN"
                    tipoVenta = "CREDITO"
            End Select

            a.AnadirLineaDatosComplementarios("-",
                                          "-",
                                          documentoBE.documentoventaAbarrotes.nroOrdenVenta,
                                              "-",
                                              documentoBE.documentoventaAbarrotes.nroGuia,
                                              "-",
                                              "",
                                          "")

            '//DATOS DE LOS DETALLES DE LOS ITEMS
            '*********************** TODO LOS DETALLES DE LOS ITEM *********************
            'CODIGO
            'DESCRIPCION
            'CANTIDAD
            'UM
            'VALOR VENTA UNITARIO
            'DESCUENTO
            'VALOR DE VENTA TOTAL
            'OTROS CARGOS
            'IMPUESTOS
            'PRECIO DE VENTA
            'VALOR TOTAL


            For Each i In documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet

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



                If (Not IsNothing(i.CustomEquivalencia)) Then
                    a.AnadirLineaElementosFactura(i.codigoBarra,
                               $"{i.nombreItem} {i.detalleAdicional}({i.CustomEquivalencia.unidadComercial})",
                                 CInt(i.monto1),
                                    i.unidad1,
                                  (i.montokardex) / i.monto1,
                                  "0.00",
                                  i.montokardex,
                                  "0.00",
                                  i.montoIgv,
                                  i.importeMN / i.monto1,
                                  i.importeMN)

                Else
                    a.AnadirLineaElementosFactura(i.codigoBarra,
                                      $"{i.nombreItem} {i.detalleAdicional}",
                                     CInt(i.monto1),
                                          i.unidad1,
                                      (i.montokardex) / i.monto1,
                                      "0.00",
                                      i.montokardex,
                                      "0.00",
                                      i.montoIgv,
                                      i.importeMN / i.monto1,
                                      i.importeMN)
                End If

            Next

            '********************************** RESUMEN GENERAL DE LA FACTURA **************************
            'GRATUITAS
            a.AnadirDatosGenerales("S/", "0.00")
            'EXONERADAS
            a.AnadirDatosGenerales("S/", ExoMN)
            'INAFECTA
            a.AnadirDatosGenerales("S/", InaMN)
            'GRAVADA
            a.AnadirDatosGenerales("S/", gravMN)
            'TOTAL DESCUENTO
            a.AnadirDatosGenerales("S/", "0.00")
            'I.S.C.
            a.AnadirDatosGenerales("S/", "0.00")
            'I.G.V
            a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.igv01.GetValueOrDefault)
            'BOLSA
            a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.icbper.GetValueOrDefault)
            'IMPORTE TOTAL
            a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.ImporteNacional.GetValueOrDefault)


            '//DESCRIICION DE DETALLE DE TOTAL IMKPORTE Y NUMEROS BANCARIOS

            ''DESCRIPCION DEL IMPORTE TOTAL EN LETRAS
            'BANCO SOLES
            'BANCO DOLARES
            'NOTA DE CAMBIOS
            a.AnadirLineaTotalFactura(documentoBE.documentoventaAbarrotes.ImporteNacional,
                                  objDatosGenrales.nroCuentaSoles,
                                    objDatosGenrales.nroCuentaSoles2,
                                  objDatosGenrales.nroCuentaDolares,
                                   objDatosGenrales.nroCuentaDolares2,
                                  objDatosGenrales.glosario)


            a.headerImagenQR = QrCodeImgControl1.Image

            a.AnadirLineaNotaCredito("", documentoBE.documentoventaAbarrotes.glosa)

            'Select Case tipocomprobante
            '    Case "1"
            '        a.tipoComprobante = "1"
            '        a.GuardanImpresion("Microsoft Print to PDF", txtDireccionEnvio.Text, TextBoxUSUARIO.Text, TextBoxCONTRASEÑA.Text, TextBoxDESTINO.Text, TextBoxASUNTO.Text, TextBoxTEXTO.Text)

            '    Case "2"
            '        a.tipoComprobante = "2"
            '        a.GuardanImpresion("Microsoft Print to PDF", txtDireccionEnvio.Text, TextBoxUSUARIO.Text, TextBoxCONTRASEÑA.Text, TextBoxDESTINO.Text, TextBoxASUNTO.Text, TextBoxTEXTO.Text)

            'End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub btnConfigurar_Click(sender As Object, e As EventArgs)
        PageSetupDialog1.Document.DefaultPageSettings.Color = False
        PageSetupDialog1.ShowDialog()
    End Sub

    '*****************************************************************************
    '****************************** NOMBRE importes TOTALES ******************
    'Se declara el array para la Factura parte izquierda - datos generales
    Public listaFacturas As ArrayList = New ArrayList()

    'Linea para capturar el ruc y numeroComprobante de la Factura
    Public Sub AnadirLineaFacElectronica(ByVal ruc As String, ByVal TipoDoc As String, ByVal serie As String,
                                                   ByVal numero As String)

        Dim ordTot As OrdenarElementoFacElectronico = New OrdenarElementoFacElectronico()
        listaFacturas.Add(ordTot.GenerarImprimir(ruc, TipoDoc, serie, numero))
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Try
            ButtonAdv4.Enabled = False
            ButtonAdv1.Enabled = False
            PanelLoading.Visible = True
            ProgressBar2.Visible = True
            Me.SuspendLayout()
            Me.ResumeLayout(True)
            Dim directorio As String = String.Empty
            BG.RunWorkerAsync()

            'If (TextBoxUSUARIO.Text.Length > 0 And TextBoxCONTRASEÑA.Text.Length > 0) Then
            '    enviarCorreo(TextBoxUSUARIO.Text, TextBoxCONTRASEÑA.Text, TextBoxDESTINO.Text, TextBoxTEXTO.Text, TextBoxASUNTO.Text, TextBoxASUNTO.Text, directorio, EnvioXml, txtDireccionEnvio.Text)
            '    ProgressBar2.Visible = False
            '    PanelLoading.Visible = False
            '    ButtonAdv4.Enabled = True
            '    ButtonAdv1.Enabled = True
            '    Dispose()
            'Else
            '    MessageBox.Show("Debe configurar un email de la empresa")
            '    ButtonAdv4.Enabled = True
            '    ButtonAdv1.Enabled = True
            '    Dispose()
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BG_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BG.DoWork
        Try
            DescargarXMLyCDR()
            CargarDatosEnvio()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BG_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BG.RunWorkerCompleted
        Try
            MessageBox.Show("Se realizó el envío correctamente!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
