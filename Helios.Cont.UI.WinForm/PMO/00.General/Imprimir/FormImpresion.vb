Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports OpenInvoicePeru.Comun.Dto.Intercambio
Imports OpenInvoicePeru.Comun.Dto.Modelos
Imports System.IO

Public Class FormImpresion

    Dim instance As New Printing.PrinterSettings
    Dim impresosaPredt As String = instance.PrinterName
    Public QR As String
    Public HASH As String
    Public CERTIFICADO As String
    Public DocumentoID As Integer
    Public objDatosGenrales As New datosGenerales
    Private Const FormatoFecha As String = "yyyy-MM-dd"



    'Private Sub cargarDatos()
    '    Dim datosGeneralesSA As New datosGeneralesSA
    '    objDatosGenrales = datosGeneralesSA.UbicaEmpresaID(Gempresas.IdEmpresaRuc)
    'End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.F11
                Button2.PerformClick()

            Case Keys.F12
                Button4.PerformClick()

            Case Keys.F10
                Button3.PerformClick()
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Function CrearEmisor() As Compania
        Dim Emisor As New Compania

        Emisor.NroDocumento = Gempresas.IdEmpresaRuc '"20603127278"
        Emisor.TipoDocumento = "6"
        Emisor.NombreComercial = Gempresas.NomEmpresa '"INVERSIONES SEÑOR DE ACORIA S.A.C."
        Emisor.NombreLegal = Gempresas.NomEmpresa '"INVERSIONES SEÑOR DE ACORIA S.A.C."
        Emisor.CodigoAnexo = "0001"

        Return Emisor

    End Function

    Public Sub XmlFactura(comprobante As documentoventaAbarrotes, comprobanteDetalle As List(Of documentoventaAbarrotesDet))

        'Detalle de la Factura
        Dim DetalleItems As DetalleDocumento
        Dim ListaItems As New List(Of DetalleDocumento)

        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA

        Dim enti As New entidadSA

        Dim conteo As Integer = 0

        Dim tipoDoc As String = ""

        Dim documentoElectronico As New OpenInvoicePeru.Comun.Dto.Modelos.DocumentoElectronico

        'Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(idDocumento)
        'Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(idDocumento)

        Dim receptor = enti.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, comprobante.idCliente)

        Dim numerovent As String = String.Format("{0:00000000}", comprobante.numeroVenta)

        Dim fechaFact As DateTime = comprobante.fechaDoc




        Try

            'Datos Cabezera Factura-------------------------------
            documentoElectronico.Emisor = CrearEmisor()

            'documentoElectronico.Receptor = CrearReceptor()
            documentoElectronico.Receptor.NroDocumento = receptor.nrodoc
            documentoElectronico.Receptor.TipoDocumento = receptor.tipoDoc
            documentoElectronico.Receptor.NombreLegal = receptor.nombreCompleto



            documentoElectronico.IdDocumento = comprobante.serieVenta & "-" & numerovent

            'documentoElectronico.IdDocumento = documento.serieVenta & "-" & documento.numeroVenta

            documentoElectronico.FechaEmision = fechaFact.ToString(FormatoFecha)  ' documento.fechaDoc.Value.Year & "-" & String.Format("{0:00}", documento.fechaDoc.Value.Month) & "-" & String.Format("{0:00}", documento.fechaDoc.Value.Day)
            documentoElectronico.HoraEmision = fechaFact.ToString("HH:mm:ss")

            If comprobante.moneda = "1" Then
                documentoElectronico.Moneda = "PEN"
            ElseIf comprobante.moneda = "2" Then
                documentoElectronico.Moneda = "USD"
            End If

            tipoDoc = String.Format("{0:00}", comprobante.tipoDocumento)

            documentoElectronico.TipoDocumento = tipoDoc
            documentoElectronico.TotalIgv = comprobante.igv01
            documentoElectronico.TotalVenta = comprobante.ImporteNacional 'documento.bi01 + documento.bi02 
            documentoElectronico.Gravadas = comprobante.bi01
            'documentoElectronico.Exoneradas = documento.bi02
            documentoElectronico.Exoneradas = comprobante.bi02
            documentoElectronico.TipoOperacion = "0101" 'String.Format("{0:00}", documento.tipoOperacion)
            'documentoElectronico .Inafectas = "Falta"
            'documentoElectronico .Gratuitas = "falta"
            'documentoElectronico.DescuentoGlobal = "falta"
            'documentoElectronico .TotalIsc = "falta"
            'documentoElectronico .MontoPercepcion = "falta"
            'documentoElectronico.MontoDetraccion = "falta"
            'documentoElectronico .CalculoDetraccion = "falta"
            'documentoElectronico .TotalOtrosTributos = "falta"

            'Anexar con Anticipo
            'documentoElectronico.TipoDocAnticipo = "falta"
            'documentoElectronico.MonedaAnticipo = "falta"
            'documentoElectronico.MontoAnticipo = "falta"
            'documentoElectronico.DocAnticipo = "falta"

            'DatosGuiaTransportista
            'documentoElectronico.DatosGuiaTransportista = "Falta"

            'documentoElectronico.DatosGuiaTransportista.DireccionOrigen = "Datos Origen" tipo contribuyente
            'documentoElectronico.DatosGuiaTransportista.DireccionDestino = "Datos Destino" tipo contribuyente
            'documentoElectronico.DatosGuiaTransportista.RucTransportista = ""
            'documentoElectronico.DatosGuiaTransportista.TipoDocTransportista = ""
            'documentoElectronico.DatosGuiaTransportista.NombreTransportista = ""
            'documentoElectronico.DatosGuiaTransportista.NroLicenciaConducir = ""
            'documentoElectronico.DatosGuiaTransportista.PlacaVehiculo = ""
            'documentoElectronico.DatosGuiaTransportista.CodigoAutorizacion = ""
            'documentoElectronico.DatosGuiaTransportista.MarcaVehiculo = ""
            'documentoElectronico.DatosGuiaTransportista.ModoTransporte = ""
            'documentoElectronico.DatosGuiaTransportista.UnidadMedida = ""
            'documentoElectronico.DatosGuiaTransportista.PesoBruto = ""

            'Datos Detalle Factura---------------------------------------------
            For Each i In comprobanteDetalle
                conteo += 1

                DetalleItems = New DetalleDocumento
                DetalleItems.Id = conteo
                DetalleItems.Cantidad = i.monto1
                DetalleItems.PrecioReferencial = i.precioUnitario
                DetalleItems.CodigoItem = i.idItem
                DetalleItems.Descripcion = i.nombreItem
                DetalleItems.UnidadMedida = i.unidad1
                DetalleItems.Impuesto = i.montoIgv
                If i.destino = "1" Then
                    DetalleItems.TipoImpuesto = "10" 'CATALOGO 7
                    DetalleItems.TipoPrecio = "01" 'CATALOGO 16
                    DetalleItems.PrecioUnitario = CalculoBaseImponible(i.precioUnitario, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
                ElseIf i.destino = "2" Then
                    DetalleItems.TipoImpuesto = "20" 'CATALOGO 7
                    DetalleItems.TipoPrecio = "01" '"02"  'CATALOGO 16
                    DetalleItems.PrecioUnitario = i.precioUnitario
                End If

                DetalleItems.TotalVenta = i.montokardex
                'DetalleItems .Descuento = "falta"
                'DetalleItems .ImpuestoSelectivo = "falta"
                'DetalleItems.OtroImpuesto = "falta"
                'DetalleItems.PlacaVehiculo = "falta"
                ListaItems.Add(DetalleItems)
            Next
            documentoElectronico.Items = ListaItems

            'Relacionar con Documentos como nota de credito nota debito
            'For Each 
            'DocRelacionado = New DocumentoRelacionado
            '    DocRelacionado.NroDocumento = "F001-1"
            '    DocRelacionado.TipoDocumento = "07"
            '    ListaDocRelacionado.Add(DocRelacionado)
            'Next
            'documentoElectronico.Relacionados = ListaDocRelacionado

            Dim documentoResponse = RestHelper(Of DocumentoElectronico, DocumentoResponse).Execute("GenerarFactura", documentoElectronico)

            If Not documentoResponse.Exito Then
                MessageBox.Show(documentoResponse.MensajeError)
                Exit Sub
            End If

            Dim firmado As New FirmadoRequest() With {
                .TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma,
                .CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("C:\CERIFICADOSOFTPACK.pfx")),
                .PasswordCertificado = "7cZGKQsu4idgwzib"
            }

            Dim responseFirma = RestHelper(Of FirmadoRequest, FirmadoResponse).Execute("Firmar", firmado)

            If Not responseFirma.Exito Then
                Throw New InvalidOperationException(responseFirma.MensajeError)
            End If

            HASH = responseFirma.ResumenFirma
            CERTIFICADO = responseFirma.ValorFirma

            File.WriteAllBytes("C:\FACTURASELECTRONICAS\FACTURAS\" & documentoElectronico.Emisor.NroDocumento & "-" & tipoDoc & "-" & documentoElectronico.IdDocumento & ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))


            'MessageBox.Show("Se Genero Correctamente el xml")

        Catch ex As Exception
            MsgBox("Problemas con el servidor" & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarDatosFormato()

        'brnImprimir.Select()
        'brnImprimir.Focus()
        Me.KeyPreview = True
    End Sub

    Public Sub CarcagarCodigoQR(CODIGO As String)
        'OBTENER LA IMAGEN DEL CODIGO QR GENERADO
        Dim img As Image = DirectCast(QrCodeImgControl1.Image.Clone, Image)
        'GUARDAR LA IMAGEN A UN ARCHIVO .jpg
        Dim sv As New SaveFileDialog
        sv.AddExtension = True
        sv.Filter = "Imagen JPG (*.jpg)|*.jpg"
        sv.ShowDialog()
        If Not String.IsNullOrEmpty(sv.FileName) Then
            img.Save(sv.FileName)
        End If
        img.Dispose()


    End Sub

    Private Sub cargarDatos(idConfiguracion As Integer)
        Dim datosGeneralesSA As New datosGeneralesSA
        objDatosGenrales = datosGeneralesSA.UbicaEmpresaID(idConfiguracion)

        If (objDatosGenrales.formatoImpresion = "A4") Then
            rbA4.Checked = True
            rbTicket.Checked = False
        ElseIf (objDatosGenrales.formatoImpresion = "TK") Then
            rbTicket.Checked = True
            rbA4.Checked = False
        End If

    End Sub

    Private Sub cargarDatosFormato()
        Dim datosGeneralesSA As New datosGeneralesSA
        Dim objDatosGenerales As New datosGenerales
        Dim listaDatos As New List(Of datosGenerales)
        Dim conteo As Integer = 1
        objDatosGenerales.idEmpresa = Gempresas.IdEmpresaRuc
        listaDatos = datosGeneralesSA.UbicaEmpresaFull(objDatosGenerales)

        For Each item In listaDatos
            item.nombreProforma = item.nombreGiro & " - " & item.formatoImpresion
            conteo += 1
        Next

        If listaDatos.Count > 0 Then
            cboFormato.ValueMember = "idConfiguracion"
            cboFormato.DisplayMember = "nombreProforma"
            cboFormato.DataSource = listaDatos
            cargarDatos(cboFormato.SelectedValue)
        End If

    End Sub

    'Private Sub cargarDatos()
    '    Dim datosGeneralesSA As New datosGeneralesSA
    '    objDatosGenrales = datosGeneralesSA.UbicaEmpresaID(Gempresas.IdEmpresaRuc)
    'End Sub

    Sub ImprimirTicketGladis(imprimir As String, intIdDocumento As Integer)
        Dim a As pruebaTicketSGladis = New pruebaTicketSGladis
        'a.HeaderImage = "C:\Documents and Settings\Administrador\Mis documentos\COMPU.jpg" 
        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim precioUnit As Decimal = 0
        Dim PrecioTotal As Decimal = 0
        Dim entidadSA As New entidadSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
        Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)

        a.TextoCentroEmpresa("REPRESENTACIONES PIEROS")
        a.TextoCentro("RUC. " & "20486529131")
        'a.TextoCentroEmpresa(Gempresas.NomEmpresa)
        'a.TextoCentro(Gempresas.IdEmpresaRuc)
        a.TextoCentro("PROLG. HUANUCO NRO. 199 PROLG. PACHITEA Nº 190-HUANCAYO")
        a.TextoCentro("Telf: " & "964009993")
        'a.TextoCentro("Venta: Bolsas de toda dimensiòn - ")
        'a.TextoCentro("Descartables en general")
        a.AnadirLineaCaracteres("")

        Select Case comprobante.tipoDocumento
            Case "12.1"
                'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaSubcabeza("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta & "jh " & comprobante.fechaDoc.Value.ToShortDateString() & "-" & comprobante.fechaDoc.Value.ToShortTimeString())

            Case "12.2"
                '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaSubcabeza("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta & " " & comprobante.fechaDoc.Value.ToShortDateString() & "-" & comprobante.fechaDoc.Value.ToShortTimeString())

            Case Else
                a.AnadirLineaSubcabeza("Ticket nota # " & comprobante.numeroVenta & " " & comprobante.fechaDoc.Value.ToShortDateString() & " - " & comprobante.fechaDoc.Value.ToShortTimeString())
        End Select

        If comprobante.idCliente <> 0 Then
            Dim entidad = entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault
            Dim NBoletaElectronica As String = "Cliente: " & entidad.nombreCompleto
            a.AnadirLineaSubcabeza(NBoletaElectronica)
            If entidad.nrodoc.Trim.Length = 11 Then
                a.AnadirLineaSubcabeza("RUC.: " & entidad.nrodoc)
            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                a.AnadirLineaSubcabeza("DNI.: " & entidad.nrodoc)
            Else
                a.AnadirLineaSubcabeza("NRO DOC.: " & entidad.nrodoc)
            End If
        Else
            Dim NBoletaElectronica As String = "Cliente: " & comprobante.nombrePedido
            a.AnadirLineaSubcabeza(NBoletaElectronica)
        End If

        'a.AnadirLineaSubcabeza("Cliente: " & "Maykol Charly Sanchez Coris")
        'a.AnadirLineaSubcabeza("FECHA: " + comprobante.fechaDoc.Value.ToShortDateString() + " - " + comprobante.fechaDoc.Value.ToShortTimeString())
        'a.AnadirLineaSubcabeza("HORA: " + comprobante.fechaDoc.Value.ToShortTimeString())

        'a.DottedLineGuion()
        ''El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        ''de que al final de cada linea agrega una linea punteada "==========" 

        'a.AnadirLineaSubcabeza("Le atendió: Prueba")
        'a.AnadirLineaSubcabeza(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString())

        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
        'del producto y el tercero es el precio 
        'a.AnadirElemento("1", "Articulohfghfghfghfghfghfhjghjghjghjg", "UND", "11.00", "111.00")
        a.AnadirLineaCaracteres("")
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

            precioUnit = (Math.Round(CDbl(i.importeMN / i.monto1), 2))
            PrecioTotal = i.importeMN
            a.AnadirElemento(i.monto1, i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal), i.nombreItem)
            'a.AnadirNombreElemento(i.nombreItem)
        Next


        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio 
        'a.AnadirTotal("SUBTOTAL", "29.75")
        'a.AnadirTotal("IVA", "5.25")
        'a.AnadirLineaCaracteres("")
        a.AnadirTotal("", "")
        'a.AnadirTotal("EXONERADA...S/.", ExoMN)
        'a.AnadirTotal("INAFECTA....S/.", InaMN)
        'a.AnadirTotal("GRAVADA.....S/.", gravMN)
        'a.AnadirTotal("IGV.........S/.", comprobante.igv01)
        'La M indica que es un decimal en C#
        a.AnadirTotal("TOTAL.......S/.", String.Format("{0:0.00}", comprobante.ImporteNacional))
        'ticket.TextoIzquierda("")
        'a.AnadirTotal("         EFECTIVO....S/.", comprobante.ImporteNacional)
        'ticket.AgregarTotales("         CAMBIO........$", 0)

        'Texto final del Ticket.
        'ticket.TextoIzquierda("")
        'a.AnadeLineaAlPie("ARTICULOS VENDIDOS: " & comprobanteDetalle.Count)
        a.AnadeLineaAlPie("")

        'a.AnadirTotal("TOTAL", String.Format("{0:0.00}", Math.Round(CDbl(comprobante.ImporteNacional), 2)))

        a.AnadeLineaAlPie("¡GRACIAS POR SU COMPRA!")

        '//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        '//parametro de tipo string que debe de ser el nombre de la impresora. 
        a.ImprimeTicket(imprimir)

    End Sub
    Sub ImprimirTicket(imprimir As String, intIdDocumento As Integer)
        Dim a As TickeNuevoFormato = New TickeNuevoFormato
        'a.HeaderImage = "C:\Documents and Settings\Administrador\Mis documentos\COMPU.jpg" 
        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim precioUnit As Decimal = 0
        Dim PrecioTotal As Decimal = 0
        Dim entidadSA As New entidadSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
        Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
        Dim nombreCliente As String
        Dim rucCliente As String = String.Empty


        If comprobante.tipoDocumento = "01" And comprobante.tipoVenta = "VELC" Then
            XmlFactura(comprobante, comprobanteDetalle)
        End If

        'a.AnadirLineaEmpresa(objDatosGenrales.razonSocial)
        '' propietario
        'If ((objDatosGenrales.nombreCorto).Count > 0) Then
        '    a.AnadirLineaNombrePropietario("DE: " & objDatosGenrales.nombreCorto)
        'End If


        If (objDatosGenrales.logo.Length > 0) Then
            ' Logo de la Empresa
            a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
        End If

        If (objDatosGenrales.nombreImpresion = "C") Then
            a.tipoImagen = True
        ElseIf (objDatosGenrales.nombreImpresion = "R") Then
            a.tipoImagen = False
        End If

        'Direccion de La empresa general
        If (objDatosGenrales.tipoImpresion = "S") Then
            a.tipoEncabezado = True
            a.AnadirLineaEmpresa(objDatosGenrales.nombreCorto)
            a.AnadirLineaNombrePropietario(objDatosGenrales.razonSocial)
        ElseIf (objDatosGenrales.tipoImpresion = "N") Then
            a.tipoEncabezado = False
            a.AnadirLineaEmpresa(objDatosGenrales.razonSocial)

        End If

        If (objDatosGenrales.publicidad.Length > 0) Then
            a.tipoPublicidad = True
            a.AnadirLineaNombrePublidad(objDatosGenrales.publicidad)
        Else
            a.tipoPublicidad = False
        End If

        'Dim nombreCliente As String
        'Dim rucCliente As String
        'Dim nombreCliente As String
        'Dim rucCliente As String

        'ruc
        a.TextoIzquierda("R.U.C.: " & objDatosGenrales.idEmpresa)
        'direccion de la empresa
        a.TextoIzquierda("Direccion Principal: " & objDatosGenrales.direccionPrincipal)
        'a.TextoIzquierda("Direccion Secundaria: " & objDatosGenrales.direccionSecudaria)
        'Telefono de la empresa
        a.TextoIzquierda("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
        'a.TextoIzquierda("")

        'a.AnadirLineaEmpresa(Gempresas.NomEmpresa)
        ''Telefono de la empresa
        'a.TextoIzquierda(Gempresas.direccionEmpresa)
        ''direccion de la empresa
        'a.TextoIzquierda(Gempresas.TelefonoEmpresa)
        'a.TextoIzquierda("")


        'a.TextoCentroEmpresa(objDatosGenrales.razonSocial)
        'a.TextoCentro("R.U.C.: " & objDatosGenrales.idEmpresa)
        ''a.TextoCentroEmpresa(Gempresas.NomEmpresa)
        ''a.TextoCentro(Gempresas.IdEmpresaRuc)
        'a.TextoCentro(objDatosGenrales.direccionPrincipal)
        'If (Not IsNothing(objDatosGenrales.direccionSecudaria)) Then
        '    a.TextoCentro(objDatosGenrales.direccionSecudaria)
        'End If
        'a.TextoCentro("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
        ''a.TextoCentro("Venta: Bolsas de toda dimensiòn - ")
        ''a.TextoCentro("Descartables en general")
        'a.AnadirLineaCaracteres("")

        If comprobante.idCliente <> 0 Then
            Dim entidad = entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault
            Dim NBoletaElectronica As String = entidad.nombreCompleto
            nombreCliente = (NBoletaElectronica)
            If entidad.nrodoc.Trim.Length = 11 Then
                rucCliente = ("RUC.: " & entidad.nrodoc)
            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                rucCliente = ("DNI.: " & entidad.nrodoc)
            Else
                rucCliente = ("NRO DOC.: " & entidad.nrodoc)
            End If

            'Codigo qr

            If (Not IsNothing(HASH)) Then
                If HASH.Trim.Length > 0 Then
                    QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
                          "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
                          "|" & HASH & "|" & CERTIFICADO)

                    QrCodeImgControl1.Text = QR
                Else
                    QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
                         "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                    QrCodeImgControl1.Text = QR
                End If
            End If

            QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
                       "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

            QrCodeImgControl1.Text = QR

            'QrCodeImgControl1.Image

        Else
                Dim NBoletaElectronica As String = comprobante.nombrePedido
            nombreCliente = (NBoletaElectronica)

            'Codigo qr
            QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
                      "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & "VARIOS" & "|" & "0")

            QrCodeImgControl1.Text = QR

        End If

        Select Case comprobante.tipoDocumento
            Case "12.1"
                a.AnadirLineaCaracteresDatosGEnerales(CStr(comprobante.fechaDoc.Value.ToShortDateString()), "TICKET BOLETA   N° " & comprobante.serieVenta & "-" & comprobante.numeroVenta, nombreCliente, comprobante.nombrePedido, "", rucCliente, "NAC", "966557413")

                'a.AnadirLineaSubcabeza("Ticket Boleta    N° " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
            Case "12.2"
                a.AnadirLineaCaracteresDatosGEnerales(CStr(comprobante.fechaDoc.Value.ToShortDateString()), "TICKET FACTURA   N° " & comprobante.serieVenta & "-" & comprobante.numeroVenta, nombreCliente, comprobante.nombrePedido, "", rucCliente, "NAC", "966557413")

                'a.AnadirLineaSubcabeza("Ticket Factura    N° " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
            Case "03"
                If (comprobante.tipoVenta = "VELC") Then
                    a.AnadirLineaCaracteresDatosGEnerales(CStr(comprobante.fechaDoc.Value.ToShortDateString()), "BOLETA ELECTRONICA   N° " & comprobante.serieVenta & "-" & comprobante.numeroVenta, nombreCliente, comprobante.nombrePedido, "", rucCliente, "NAC", "966557413")

                    'a.AnadirLineaSubcabeza("Boleta electronica    N° " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                ElseIf (comprobante.tipoVenta = "VPOS") Then
                    a.AnadirLineaCaracteresDatosGEnerales(CStr(comprobante.fechaDoc.Value.ToShortDateString()), "BOLETA   N° " & CStr(comprobante.serieVenta).PadLeft(3, "0"c) & "-" & comprobante.numeroVenta, nombreCliente, comprobante.nombrePedido, "", rucCliente, "NAC", "966557413")

                    'a.AnadirLineaSubcabeza("Boleta de venta    N° " & CStr(comprobante.serieVenta).PadLeft(3, "0"c) & "-" & comprobante.numeroVenta)
                End If
            Case "01"
                If (comprobante.tipoVenta = "VELC") Then
                    a.AnadirLineaCaracteresDatosGEnerales(CStr(comprobante.fechaDoc.Value.ToShortDateString()), "FACTURA ELECTRONICA   N° " & comprobante.serieVenta & "-" & comprobante.numeroVenta, nombreCliente, comprobante.nombrePedido, "", rucCliente, "NAC", "966557413")

                    'a.AnadirLineaSubcabeza("Factura electronica    N° " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                ElseIf (comprobante.tipoVenta = "VPOS") Then
                    a.AnadirLineaCaracteresDatosGEnerales(CStr(comprobante.fechaDoc.Value.ToShortDateString()), "FACTURA   N° " & CStr(comprobante.serieVenta).PadLeft(3, "0"c) & "-" & comprobante.numeroVenta, nombreCliente, comprobante.nombrePedido, "", rucCliente, "NAC", "966557413")

                    'a.AnadirLineaSubcabeza("Fartura    N° " & CStr(comprobante.serieVenta).PadLeft(3, "0"c) & "-" & comprobante.numeroVenta)
                End If
            Case "9901"
                a.AnadirLineaCaracteresDatosGEnerales(CStr(comprobante.fechaDoc.Value.ToShortDateString()), "PROFORMA   N° " & 0, nombreCliente, comprobante.nombrePedido, "", rucCliente, "NAC", "966557413")

            Case Else
                a.AnadirLineaCaracteresDatosGEnerales(CStr(comprobante.fechaDoc.Value.ToShortDateString()), "TICKET NOTA   N° " & comprobante.numeroVenta, nombreCliente, comprobante.nombrePedido, "", rucCliente, "NAC", "966557413")

                'a.AnadirLineaSubcabeza("Ticket nota    N° " & comprobante.numeroVenta)
        End Select

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

            precioUnit = (Math.Round(CDbl(i.importeMN / i.monto1), 2))
            PrecioTotal = i.importeMN

            a.AnadirLineaElementosFactura(i.monto1, i.nombreItem, i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))

            'a.AnadirElemento(i.monto1, i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal), i.nombreItem)
            'a.AnadirNombreElemento(i.nombreItem)
        Next


        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio 
        'a.AnadirTotal("SUBTOTAL", "29.75")
        'a.AnadirTotal("IVA", "5.25")
        'a.AnadirLineaCaracteres("")

        a.AnadirDatosGenerales("S/", ExoMN)
        a.AnadirDatosGenerales("S/", InaMN)
        a.AnadirDatosGenerales("S/", gravMN)
        a.AnadirDatosGenerales("S/", comprobante.igv01)
        a.AnadirDatosGenerales("S/", String.Format("{0:0.00}", comprobante.ImporteNacional))

        a.headerImagenQR = QrCodeImgControl1.Image


        'a.AnadirTotal("", "")
        'a.AnadirTotal("EXONERADA...S/.", ExoMN)
        'a.AnadirTotal("INAFECTA....S/.", InaMN)
        'a.AnadirTotal("GRAVADA.....S/.", gravMN)
        'a.AnadirTotal("IGV.........S/.", comprobante.igv01)
        ''La M indica que es un decimal en C#
        'a.AnadirTotal("TOTAL.......S/.", String.Format("{0:0.00}", comprobante.ImporteNacional))
        'ticket.TextoIzquierda("")
        'a.AnadirTotal("         EFECTIVO....S/.", comprobante.ImporteNacional)
        'ticket.AgregarTotales("         CAMBIO........$", 0)

        'Texto final del Ticket.
        'ticket.TextoIzquierda("")
        'a.AnadeLineaAlPie("ARTICULOS VENDIDOS: " & comprobanteDetalle.Count)
        'a.AnadeLineaAlPie("")

        ''a.AnadirTotal("TOTAL", String.Format("{0:0.00}", Math.Round(CDbl(comprobante.ImporteNacional), 2)))

        'a.AnadeLineaAlPie("¡GRACIAS POR SU COMPRA!")

        '//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        '//parametro de tipo string que debe de ser el nombre de la impresora. 
        a.ImprimeTicket(imprimir, "1")
        'a.ImprimeTicket(imprimir)
    End Sub

    'Sub ImprimirTicketIvan(imprimir As String, intIdDocumento As Integer)
    '    Dim a As pruebaTicket = New pruebaTicket
    '    'a.HeaderImage = "C:\Documents and Settings\Administrador\Mis documentos\COMPU.jpg" 
    '    Dim gravMN As Decimal = 0
    '    Dim gravME As Decimal = 0
    '    Dim ExoMN As Decimal = 0
    '    Dim ExoME As Decimal = 0
    '    Dim InaMN As Decimal = 0
    '    Dim InaME As Decimal = 0
    '    Dim precioUnit As Decimal = 0
    '    Dim PrecioTotal As Decimal = 0
    '    Dim entidadSA As New entidadSA
    '    Dim documentoSA As New documentoVentaAbarrotesSA
    '    Dim documentoDetSA As New documentoVentaAbarrotesDetSA
    '    Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
    '    Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)

    '    a.TextoCentroEmpresa("MAS PERNOS SAC.")
    '    a.TextoCentro("20601215935")
    '    'a.TextoCentroEmpresa(Gempresas.NomEmpresa)
    '    'a.TextoCentro(Gempresas.IdEmpresaRuc)
    '    a.TextoCentro("Prol. Angaraes N°.399")
    '    a.TextoCentro("Telf: " & "-")
    '    'a.TextoCentro("Venta: Bolsas de toda dimensiòn - ")
    '    'a.TextoCentro("Descartables en general")
    '    a.AnadirLineaCaracteres("")

    '    Select Case comprobante.tipoDocumento
    '        Case "12.1"
    '            'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
    '            a.AnadirLineaSubcabeza("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
    '        Case "12.2"
    '            '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
    '            a.AnadirLineaSubcabeza("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)

    '        Case Else
    '            a.AnadirLineaSubcabeza("Ticket nota # " & comprobante.numeroVenta)
    '    End Select

    '    If comprobante.idCliente <> 0 Then
    '        Dim entidad = entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault
    '        Dim NBoletaElectronica As String = "Cliente: " & entidad.nombreCompleto
    '        a.AnadirLineaSubcabeza(NBoletaElectronica)
    '        If entidad.nrodoc.Trim.Length = 11 Then
    '            a.AnadirLineaSubcabeza("RUC.: " & entidad.nrodoc)
    '        ElseIf entidad.nrodoc.Trim.Length = 8 Then
    '            a.AnadirLineaSubcabeza("DNI.: " & entidad.nrodoc)
    '        Else
    '            a.AnadirLineaSubcabeza("NRO DOC.: " & entidad.nrodoc)
    '        End If
    '    Else
    '        Dim NBoletaElectronica As String = "Cliente: " & comprobante.nombrePedido
    '        a.AnadirLineaSubcabeza(NBoletaElectronica)
    '    End If

    '    'a.AnadirLineaSubcabeza("Cliente: " & "Maykol Charly Sanchez Coris")
    '    a.AnadirLineaSubcabeza("FECHA: " + comprobante.fechaDoc.Value.ToShortDateString())
    '    a.AnadirLineaSubcabeza("HORA: " + comprobante.fechaDoc.Value.ToShortTimeString())

    '    'a.DottedLineGuion()
    '    ''El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
    '    ''de que al final de cada linea agrega una linea punteada "==========" 

    '    'a.AnadirLineaSubcabeza("Le atendió: Prueba")
    '    'a.AnadirLineaSubcabeza(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString())

    '    'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
    '    'del producto y el tercero es el precio 
    '    'a.AnadirElemento("1", "Articulohfghfghfghfghfghfhjghjghjghjg", "UND", "11.00", "111.00")
    '    a.AnadirLineaCaracteres("")
    '    For Each i In comprobanteDetalle

    '        Select Case i.destino
    '            Case OperacionGravada.Grabado
    '                gravMN += CDec(i.montokardex)
    '                gravME += CDec(i.montokardexUS)

    '            Case OperacionGravada.Exonerado
    '                ExoMN += CDec(i.montokardex)
    '                ExoME += CDec(i.montokardexUS)

    '            Case OperacionGravada.Inafecto
    '                InaMN += CDec(i.montokardex)
    '                InaME += CDec(i.montokardexUS)
    '        End Select

    '        precioUnit = (Math.Round(CDbl(i.importeMN / i.monto1), 2))
    '        PrecioTotal = i.importeMN
    '        a.AnadirElemento(i.monto1, i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal), i.nombreItem)
    '        'a.AnadirNombreElemento(i.nombreItem)
    '    Next


    '    'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio 
    '    'a.AnadirTotal("SUBTOTAL", "29.75")
    '    'a.AnadirTotal("IVA", "5.25")
    '    'a.AnadirLineaCaracteres("")
    '    a.AnadirTotal("", "")
    '    a.AnadirTotal("EXONERADA...S/.", ExoMN)
    '    a.AnadirTotal("INAFECTA....S/.", InaMN)
    '    a.AnadirTotal("GRAVADA.....S/.", gravMN)
    '    a.AnadirTotal("IGV.........S/.", comprobante.igv01)
    '    'La M indica que es un decimal en C#
    '    a.AnadirTotal("TOTAL.......S/.", String.Format("{0:0.00}", comprobante.ImporteNacional))
    '    'ticket.TextoIzquierda("")
    '    'a.AnadirTotal("         EFECTIVO....S/.", comprobante.ImporteNacional)
    '    'ticket.AgregarTotales("         CAMBIO........$", 0)

    '    'Texto final del Ticket.
    '    'ticket.TextoIzquierda("")
    '    a.AnadeLineaAlPie("ARTICULOS VENDIDOS: " & comprobanteDetalle.Count)
    '    a.AnadeLineaAlPie("")

    '    'a.AnadirTotal("TOTAL", String.Format("{0:0.00}", Math.Round(CDbl(comprobante.ImporteNacional), 2)))

    '    a.AnadeLineaAlPie("¡GRACIAS POR SU COMPRA!")

    '    '//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
    '    '//parametro de tipo string que debe de ser el nombre de la impresora. 
    '    a.ImprimeTicket(imprimir)

    'End Sub

    Sub ImprimirTicketA4(imprimir As String, intIdDocumento As Integer)
        Dim a As Ticket = New Ticket
        ' Logo de la Empresa
        'a.HeaderImage = Image.FromFile("C:\LogosSistema\images.png")
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


        'Dim tipoComprobante As String

        If comprobante.tipoDocumento = "01" And comprobante.tipoVenta = "VELC" Then
            XmlFactura(comprobante, comprobanteDetalle)
        End If

        'Dim nombreCliente As String
        'Dim rucCliente As String
        If (objDatosGenrales.logo.Length > 0) Then
            ' Logo de la Empresa
            a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
        End If

        Select Case objDatosGenrales.logo.Length
            Case > 0
                If (objDatosGenrales.posicionLogo = "CT") Then
                    If (objDatosGenrales.nombreImpresion = "C") Then
                        a.tipoImagen = True
                        a.tipoLogo = "CR"
                    ElseIf (objDatosGenrales.nombreImpresion = "R") Then
                        a.tipoImagen = False
                        a.tipoLogo = "CR"
                    End If
                ElseIf (objDatosGenrales.posicionLogo = "IZ") Then

                    If (objDatosGenrales.nombreImpresion = "C") Then
                        a.tipoImagen = True
                        a.tipoLogo = "IZ"
                    ElseIf (objDatosGenrales.nombreImpresion = "R") Then
                        a.tipoImagen = False
                        a.tipoLogo = "IZ"
                    End If
                End If
            Case <= 0
                a.tipoLogo = "SL"
        End Select



        'Direccion de La empresa general
        If (objDatosGenrales.tipoImpresion = "S") Then
            a.tipoEncabezado = True
            a.AnadirLineaEmpresa(objDatosGenrales.nombreCorto)
            a.AnadirLineaNombrePropietario(objDatosGenrales.razonSocial)
        ElseIf (objDatosGenrales.tipoImpresion = "N") Then
            a.tipoEncabezado = False
            a.AnadirLineaEmpresa(objDatosGenrales.razonSocial)

        End If

        If (objDatosGenrales.publicidad.Length > 0) Then
            a.tipoPublicidad = True
            a.AnadirLineaNombrePublidad(objDatosGenrales.publicidad)
        Else
            a.tipoPublicidad = False
        End If


        'Direccion de La empresa general




        'a.AnadirLineaEmpresa(objDatosGenrales.razonSocial)

        'If ((objDatosGenrales.nombreCorto).Count > 0) Then
        '    a.AnadirLineaNombrePropietario("De: " & objDatosGenrales.nombreCorto)
        'End If
        'direccion de la empresa
        a.TextoIzquierda("Domicilio Fiscal: " & objDatosGenrales.direccionPrincipal)
        a.TextoIzquierda("Establ. Anexo: " & objDatosGenrales.direccionSecudaria)
        'Telefono de la empresa
        a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
        a.TextoIzquierda("")

        'a.AnadirLineaEmpresa(Gempresas.NomEmpresa)
        ''Telefono de la empresa
        'a.TextoIzquierda(Gempresas.direccionEmpresa)
        ''direccion de la empresa
        'a.TextoIzquierda(Gempresas.TelefonoEmpresa)
        'a.TextoIzquierda("")

        Select Case comprobante.tipoDocumento
            Case "12.1"
                'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "BOLETA")
                'ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                nombreComprabante = "BOLETA" & comprobante.serieVenta & comprobante.numeroVenta
                tipoComprobante = "1"
            Case "12.2"
                '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                'ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "FACTURA")
                nombreComprabante = "FACTURA" & comprobante.serieVenta & comprobante.numeroVenta
                tipoComprobante = "1"
            Case "03"
                If (comprobante.tipoVenta = "VELC") Then
                    a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "BOLETA ELECTRONICA")
                    nombreComprabante = "FACTURA" & comprobante.serieVenta & comprobante.numeroVenta
                    tipoComprobante = "2"
                ElseIf (comprobante.tipoVenta = "VPOS") Then
                    a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "BOLETA")
                    nombreComprabante = "FACTURA" & comprobante.serieVenta & comprobante.numeroVenta
                    tipoComprobante = "1"
                End If
            Case "01"
                If (comprobante.tipoVenta = "VELC") Then
                    a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "FACTURA ELECTRONICA")
                    nombreComprabante = "FACTURA" & comprobante.serieVenta & comprobante.numeroVenta
                    tipoComprobante = "2"
                ElseIf (comprobante.tipoVenta = "VPOS") Then
                    a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "FACTURA")
                    nombreComprabante = "FACTURA" & comprobante.serieVenta & comprobante.numeroVenta
                    tipoComprobante = "1"
                End If
            Case "9901"
                a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, 0 & " - " & CStr(0).PadLeft(8, "0"c), "PROFORMA")
                nombreComprabante = "PROFORMA" & comprobante.serieVenta & comprobante.numeroVenta
                tipoComprobante = "1"
            Case Else

                a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "NOTA")
                nombreComprabante = "NOTA" & comprobante.serieVenta & comprobante.numeroVenta
                tipoComprobante = "1"
        End Select

        'a.TextoDerecha("RUC: " & "12345678911")
        'Numero de Ruc y Numeracion

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
            'Fecha de Factura
            'Lugar de la factura
            'Nombre del cliente
            'direccion del cliente
            'numero del cliente
            'direccion de entrega
            'tipo moneda de la empresa
            'telefono de la empresa
            a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechaDoc.Value.ToShortDateString(), "Huancayo - Perù", NBoletaElectronica, entidad.direccion, "", nBoletaNumero, "PEN", entidad.telefono)

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
            a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechaDoc.Value.ToShortDateString(), "Huancayo - Perù", NBoletaElectronica, "", "", "", "PEN", "")

            'Codigo qr
            QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
                      "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & "VARIOS" & "|" & "0")

            QrCodeImgControl1.Text = QR
        End If

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
            a.AnadirLineaElementosFactura(i.idItem, i.nombreItem, i.monto1, i.unidad1, (i.montokardex) / i.monto1, "0.00", i.montokardex, "0.00", i.montoIgv, i.importeMN / i.monto1, i.importeMN)
            'ticket.AgregaArticuloV2(i.nombreItem, String.Format("{0:0.00}", i.monto1), String.Format("{0:0.00}", i.importeMN / i.monto1), i.importeMN)
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
        'DESCRIPCION DEL IMPORTE TOTAL EN LETRAS
        a.AnadirLineaTotalFactura(comprobante.ImporteNacional)
        'IMPRIMIR LA FACTUIRA

        a.headerImagenQR = QrCodeImgControl1.Image


        Select Case tipoComprobante
            Case "1"
                a.tipoComprobante = "1"
                'enviarCorreo("maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura", "", NombreNumero)
                'a.GuardanImpresion("Microsoft Print to PDF", nombreComprabante, "maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura")
                a.ImprimeTicket(imprimir)
            Case "2"
                a.tipoComprobante = "2"
                'enviarCorreo("maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura", "", NombreNumero)
                'a.GuardanImpresion("Microsoft Print to PDF", nombreComprabante, "maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura")
                a.ImprimeTicket(imprimir)
        End Select

    End Sub

    Sub ImprimirTicketPDF(imprimir As String, intIdDocumento As Integer)
        Dim a As Ticket = New Ticket
        ' Logo de la Empresa
        'a.HeaderImage = Image.FromFile("C:\LogosSistema\images.png")
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
        Dim tipoComprobante As String


        'Dim tipoComprobante As String



        'Dim nombreCliente As String
        'Dim rucCliente As String
        If (objDatosGenrales.logo.Length > 0) Then
            ' Logo de la Empresa
            a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
        End If

        Select Case objDatosGenrales.logo.Length
            Case < 0
                If (objDatosGenrales.logo.Length > 0) Then
                    If (objDatosGenrales.nombreImpresion = "C") Then
                        a.tipoImagen = True
                        a.tipoLogo = "CR"
                    ElseIf (objDatosGenrales.nombreImpresion = "R") Then
                        a.tipoImagen = False
                        a.tipoLogo = "CR"
                    End If
                ElseIf (objDatosGenrales.logo.Length <= 0) Then

                    If (objDatosGenrales.nombreImpresion = "C") Then
                        a.tipoImagen = True
                        a.tipoLogo = "IZ"
                    ElseIf (objDatosGenrales.nombreImpresion = "R") Then
                        a.tipoImagen = False
                        a.tipoLogo = "IZ"
                    End If
                End If
            Case >= 0
                a.tipoLogo = "SL"
        End Select



        'Direccion de La empresa general
        If (objDatosGenrales.tipoImpresion = "S") Then
            a.tipoEncabezado = True
            a.AnadirLineaEmpresa(objDatosGenrales.nombreCorto)
            a.AnadirLineaNombrePropietario(objDatosGenrales.razonSocial)
        ElseIf (objDatosGenrales.tipoImpresion = "N") Then
            a.tipoEncabezado = False
            a.AnadirLineaEmpresa(objDatosGenrales.razonSocial)

        End If

        If (objDatosGenrales.publicidad.Length > 0) Then
            a.tipoPublicidad = True
            a.AnadirLineaNombrePublidad(objDatosGenrales.publicidad)
        Else
            a.tipoPublicidad = False
        End If


        'Direccion de La empresa general




        'a.AnadirLineaEmpresa(objDatosGenrales.razonSocial)

        'If ((objDatosGenrales.nombreCorto).Count > 0) Then
        '    a.AnadirLineaNombrePropietario("De: " & objDatosGenrales.nombreCorto)
        'End If
        'direccion de la empresa
        a.TextoIzquierda("Domicilio fiscal: " & objDatosGenrales.direccionPrincipal)
        a.TextoIzquierda("E. Anexo: " & objDatosGenrales.direccionSecudaria)
        'Telefono de la empresa
        a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
        a.TextoIzquierda("")

        'a.AnadirLineaEmpresa(Gempresas.NomEmpresa)
        ''Telefono de la empresa
        'a.TextoIzquierda(Gempresas.direccionEmpresa)
        ''direccion de la empresa
        'a.TextoIzquierda(Gempresas.TelefonoEmpresa)
        'a.TextoIzquierda("")

        Select Case comprobante.tipoDocumento
            Case "12.1"
                'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "BOLETA")
                'ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                nombreComprabante = "BOLETA" & comprobante.serieVenta & comprobante.numeroVenta
                tipoComprobante = "1"
            Case "12.2"
                '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                'ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "FACTURA")
                nombreComprabante = "FACTURA" & comprobante.serieVenta & comprobante.numeroVenta
                tipoComprobante = "1"
            Case "03"
                If (comprobante.tipoVenta = "VELC") Then
                    a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "BOLETA ELECTRONICA")
                    nombreComprabante = "FACTURA" & comprobante.serieVenta & comprobante.numeroVenta
                    tipoComprobante = "2"
                ElseIf (comprobante.tipoVenta = "VPOS") Then
                    a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "BOLETA")
                    nombreComprabante = "FACTURA" & comprobante.serieVenta & comprobante.numeroVenta
                    tipoComprobante = "1"
                End If
            Case "01"
                If (comprobante.tipoVenta = "VELC") Then
                    a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "FACTURA ELECTRONICA")
                    nombreComprabante = "FACTURA" & comprobante.serieVenta & comprobante.numeroVenta
                    tipoComprobante = "2"
                ElseIf (comprobante.tipoVenta = "VPOS") Then
                    a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "FACTURA")
                    nombreComprabante = "FACTURA" & comprobante.serieVenta & comprobante.numeroVenta
                    tipoComprobante = "1"
                End If
            Case "9901"
                a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, 0 & " - " & CStr(0).PadLeft(8, "0"c), "PROFORMA")
                nombreComprabante = "PROFORMA" & comprobante.serieVenta & comprobante.numeroVenta
                tipoComprobante = "1"
            Case Else

                a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "NOTA")
                nombreComprabante = "NOTA" & comprobante.serieVenta & comprobante.numeroVenta
                tipoComprobante = "1"
        End Select

        'a.TextoDerecha("RUC: " & "12345678911")
        'Numero de Ruc y Numeracion

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
            'Fecha de Factura
            'Lugar de la factura
            'Nombre del cliente
            'direccion del cliente
            'numero del cliente
            'direccion de entrega
            'tipo moneda de la empresa
            'telefono de la empresa
            a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechaDoc.Value.ToShortDateString(), "Huancayo - Perù", NBoletaElectronica, entidad.direccion, "", nBoletaNumero, "PEN", entidad.telefono)

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
            a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechaDoc.Value.ToShortDateString(), "Huancayo - Perù", NBoletaElectronica, "", "", "", "PEN", "")
        End If

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
            a.AnadirLineaElementosFactura(i.idItem, i.nombreItem, i.monto1, i.unidad1, (i.montokardex) / i.monto1, "0.00", i.montokardex, "0.00", i.montoIgv, i.importeMN / i.monto1, i.importeMN)
            'ticket.AgregaArticuloV2(i.nombreItem, String.Format("{0:0.00}", i.monto1), String.Format("{0:0.00}", i.importeMN / i.monto1), i.importeMN)
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
        'DESCRIPCION DEL IMPORTE TOTAL EN LETRAS
        a.AnadirLineaTotalFactura(comprobante.ImporteNacional)
        'IMPRIMIR LA FACTUIRA

        Select Case tipoComprobante
            Case "1"
                a.tipoComprobante = "1"
                'enviarCorreo("maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura", "", NombreNumero)
                'a.GuardanImpresion("Microsoft Print to PDF", nombreComprabante, "maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura")
                a.ImprimeTicket(imprimir)
            Case "2"
                a.tipoComprobante = "2"
                'enviarCorreo("maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura", "", NombreNumero)
                'a.GuardanImpresion("Microsoft Print to PDF", nombreComprabante, "maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura")
                a.ImprimeTicket(imprimir)
        End Select

    End Sub

    Sub ImprimirTicketEnviarComprobante(imprimir As String, intIdDocumento As Integer)
        Dim a As Ticket = New Ticket
        ' Logo de la Empresa
        'a.HeaderImage = Image.FromFile("C:\LogosSistema\images.png")
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
        Dim tipoComprobante As String


        'Dim tipoComprobante As String



        'Dim nombreCliente As String
        'Dim rucCliente As String
        If (objDatosGenrales.logo.Length > 0) Then
            ' Logo de la Empresa
            a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
        End If

        Select Case objDatosGenrales.logo.Length
            Case < 0
                If (objDatosGenrales.logo.Length > 0) Then
                    If (objDatosGenrales.nombreImpresion = "C") Then
                        a.tipoImagen = True
                        a.tipoLogo = "CR"
                    ElseIf (objDatosGenrales.nombreImpresion = "R") Then
                        a.tipoImagen = False
                        a.tipoLogo = "CR"
                    End If
                ElseIf (objDatosGenrales.logo.Length <= 0) Then

                    If (objDatosGenrales.nombreImpresion = "C") Then
                        a.tipoImagen = True
                        a.tipoLogo = "IZ"
                    ElseIf (objDatosGenrales.nombreImpresion = "R") Then
                        a.tipoImagen = False
                        a.tipoLogo = "IZ"
                    End If
                End If
            Case >= 0
                a.tipoLogo = "SL"
        End Select



        'Direccion de La empresa general
        If (objDatosGenrales.tipoImpresion = "S") Then
            a.tipoEncabezado = True
            a.AnadirLineaEmpresa(objDatosGenrales.nombreCorto)
            a.AnadirLineaNombrePropietario(objDatosGenrales.razonSocial)
        ElseIf (objDatosGenrales.tipoImpresion = "N") Then
            a.tipoEncabezado = False
            a.AnadirLineaEmpresa(objDatosGenrales.razonSocial)

        End If

        If (objDatosGenrales.publicidad.Length > 0) Then
            a.tipoPublicidad = True
            a.AnadirLineaNombrePublidad(objDatosGenrales.publicidad)
        Else
            a.tipoPublicidad = False
        End If


        'Direccion de La empresa general




        'a.AnadirLineaEmpresa(objDatosGenrales.razonSocial)

        'If ((objDatosGenrales.nombreCorto).Count > 0) Then
        '    a.AnadirLineaNombrePropietario("De: " & objDatosGenrales.nombreCorto)
        'End If
        'direccion de la empresa
        a.TextoIzquierda("Domicilio fiscal: " & objDatosGenrales.direccionPrincipal)
        a.TextoIzquierda("E. Anexo: " & objDatosGenrales.direccionSecudaria)
        'Telefono de la empresa
        a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
        a.TextoIzquierda("")

        'a.AnadirLineaEmpresa(Gempresas.NomEmpresa)
        ''Telefono de la empresa
        'a.TextoIzquierda(Gempresas.direccionEmpresa)
        ''direccion de la empresa
        'a.TextoIzquierda(Gempresas.TelefonoEmpresa)
        'a.TextoIzquierda("")

        Select Case comprobante.tipoDocumento
            Case "12.1"
                'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "BOLETA")
                'ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                nombreComprabante = "BOLETA" & comprobante.serieVenta & comprobante.numeroVenta
                tipoComprobante = "1"
            Case "12.2"
                '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                'ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "FACTURA")
                nombreComprabante = "FACTURA" & comprobante.serieVenta & comprobante.numeroVenta
                tipoComprobante = "1"
            Case "03"
                If (comprobante.tipoVenta = "VELC") Then
                    a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "BOLETA ELECTRONICA")
                    nombreComprabante = "FACTURA" & comprobante.serieVenta & comprobante.numeroVenta
                    tipoComprobante = "2"
                ElseIf (comprobante.tipoVenta = "VPOS") Then
                    a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "BOLETA")
                    nombreComprabante = "FACTURA" & comprobante.serieVenta & comprobante.numeroVenta
                    tipoComprobante = "1"
                End If
            Case "01"
                If (comprobante.tipoVenta = "VELC") Then
                    a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "FACTURA ELECTRONICA")
                    nombreComprabante = "FACTURA" & comprobante.serieVenta & comprobante.numeroVenta
                    tipoComprobante = "2"
                ElseIf (comprobante.tipoVenta = "VPOS") Then
                    a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "FACTURA")
                    nombreComprabante = "FACTURA" & comprobante.serieVenta & comprobante.numeroVenta
                    tipoComprobante = "1"
                End If
            Case "9901"
                a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, 0 & " - " & CStr(0).PadLeft(8, "0"c), "PROFORMA")
                nombreComprabante = "PROFORMA" & comprobante.serieVenta & comprobante.numeroVenta
                tipoComprobante = "1"
            Case Else

                a.AnadirLineaCaracteresFactura(objDatosGenrales.idEmpresa, comprobante.serieVenta & " - " & CStr(comprobante.numeroVenta).PadLeft(8, "0"c), "NOTA")
                nombreComprabante = "NOTA" & comprobante.serieVenta & comprobante.numeroVenta
                tipoComprobante = "1"
        End Select

        'a.TextoDerecha("RUC: " & "12345678911")
        'Numero de Ruc y Numeracion

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
            'Fecha de Factura
            'Lugar de la factura
            'Nombre del cliente
            'direccion del cliente
            'numero del cliente
            'direccion de entrega
            'tipo moneda de la empresa
            'telefono de la empresa
            a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechaDoc.Value.ToShortDateString(), "Huancayo - Perù", NBoletaElectronica, entidad.direccion, "", nBoletaNumero, "PEN", entidad.telefono)

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
            a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechaDoc.Value.ToShortDateString(), "Huancayo - Perù", NBoletaElectronica, "", "", "", "PEN", "")
        End If

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
            a.AnadirLineaElementosFactura(i.idItem, i.nombreItem, i.monto1, i.unidad1, (i.montokardex) / i.monto1, "0.00", i.montokardex, "0.00", i.montoIgv, i.importeMN / i.monto1, i.importeMN)
            'ticket.AgregaArticuloV2(i.nombreItem, String.Format("{0:0.00}", i.monto1), String.Format("{0:0.00}", i.importeMN / i.monto1), i.importeMN)
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
        'DESCRIPCION DEL IMPORTE TOTAL EN LETRAS
        a.AnadirLineaTotalFactura(comprobante.ImporteNacional)
        'IMPRIMIR LA FACTUIRA

        Select Case tipoComprobante
            Case "1"
                a.tipoComprobante = "1"
                'enviarCorreo("maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura", "", NombreNumero)
                'a.GuardanImpresion("Microsoft Print to PDF", nombreComprabante, "maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura")
                a.ImprimeTicket(imprimir)
            Case "2"
                a.tipoComprobante = "2"
                'enviarCorreo("maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura", "", NombreNumero)
                'a.GuardanImpresion("Microsoft Print to PDF", nombreComprabante, "maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura")
                a.ImprimeTicket(imprimir)
        End Select

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles brnImprimir.Click
        Try
            If (rbTicket.Checked = True) Then
                'cargarDatos()
                If (Not IsNothing(objDatosGenrales)) Then
                    ImprimirTicket(ComboBox1.Text, DocumentoID)
                    Close()
                Else
                    MessageBox.Show("No tiene una configuración de datos generales de la empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            ElseIf (rbA4.Checked = True) Then
                'cargarDatos()
                If (Not IsNothing(objDatosGenrales)) Then
                    ImprimirTicketA4(ComboBox1.Text, DocumentoID)
                    Close()
                Else
                    MessageBox.Show("No tiene una configuración de datos generales de la empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    ' Dim defaultPrinterSetting As System.Drawing.Printing.PrinterSettings = Nothing
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Clear()
        Me.CenterToParent()

        ' defaultPrinterSetting = DocumentPrinter.GetDefaultPrinterSetting
        '  Dim f = System.Drawing.Printing.PrinterSettings.InstalledPrinters
        ' If System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count > 0 Then
        For Each item As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            ComboBox1.Items.Add(item.ToString)
        Next
        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedText = impresosaPredt
            brnImprimir.Focus()
            brnImprimir.Select()
        End If
        '   End If

        'CarcagarCodigoQR(QR)

        QrCodeImgControl1.Text = QR
    End Sub

    Private Sub rbTicket_CheckedChanged(sender As Object, e As EventArgs) Handles rbTicket.CheckedChanged
        If (rbTicket.Checked = True) Then
            rbTicket.Checked = True
            rbA4.Checked = False
        End If
    End Sub

    Private Sub rbA4_CheckedChanged(sender As Object, e As EventArgs) Handles rbA4.CheckedChanged
        If (rbA4.Checked = True) Then
            rbA4.Checked = True
            rbTicket.Checked = False
        End If
    End Sub

    Private Sub btnConfigurar_Click(sender As Object, e As EventArgs) 
        PageSetupDialog1.Document.DefaultPageSettings.Color = False
        PageSetupDialog1.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub cboFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFormato.SelectedIndexChanged
        If (Not IsNothing(cboFormato.SelectedValue)) Then
            cargarDatos(cboFormato.SelectedValue)

        End If
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dispose()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If (rbTicket.Checked = True) Then
                'cargarDatos()
                If (Not IsNothing(objDatosGenrales)) Then
                    ImprimirTicket(ComboBox1.Text, DocumentoID)
                    Close()
                Else
                    MessageBox.Show("No tiene una configuración de datos generales de la empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            ElseIf (rbA4.Checked = True) Then
                'cargarDatos()
                If (Not IsNothing(objDatosGenrales)) Then
                    ImprimirTicketA4(ComboBox1.Text, DocumentoID)
                    Close()
                Else
                    MessageBox.Show("No tiene una configuración de datos generales de la empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Cursor = Cursors.WaitCursor
        'If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then
        '    Dim f As New FormEnviarCorreo   ' frmVentaNuevoFormato
        '    f.DocumentoID = Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")

        '    Select Case Me.dgPedidos.Table.CurrentRecord.GetValue("serie")
        '        Case "B001"
        '            f.TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA ELECTRONICA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        '            f.txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA ELECTRONICA-" & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        '            f.serieFactura = Me.dgPedidos.Table.CurrentRecord.GetValue("serie")
        '            f.numeroFactura = Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        '            f.tipoDocumento = Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc")
        '            direccionArchivo = Gempresas.IdEmpresaRuc & "-BOLETA ELECTRONICA-" & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc") & ".pdf"
        '        Case "F001"
        '            f.TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA ELECTRONICA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        '            f.txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA ELECTRONICA-" & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        '            f.serieFactura = Me.dgPedidos.Table.CurrentRecord.GetValue("serie")
        '            f.numeroFactura = Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        '            f.tipoDocumento = Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc")
        '            direccionArchivo = Gempresas.IdEmpresaRuc & "-FACTURA ELECTRONICA-" & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc") & ".pdf"
        '        Case Else
        '            If (Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc") = "01") Then
        '                f.TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        '                f.txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        '                direccionArchivo = Gempresas.IdEmpresaRuc & "-FACTURA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc") & ".pdf"
        '            ElseIf (Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc") = "03") Then
        '                f.TextBoxASUNTO.Text = "BOLETA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        '                f.txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        '                direccionArchivo = Gempresas.IdEmpresaRuc & "-BOLETA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc") & ".pdf"
        '            ElseIf (Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc") = "9901") Then
        '                f.TextBoxASUNTO.Text = "PROFORMA " & 0 & "-" & 0
        '                f.txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-PROFORMA " & 0 & "-" & 0
        '                direccionArchivo = Gempresas.IdEmpresaRuc & "-PROFORMA " & 0 & "-" & 0 & ".pdf"
        '            Else
        '                f.TextBoxASUNTO.Text = "NOTA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        '                f.txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-NOTA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        '                direccionArchivo = Gempresas.IdEmpresaRuc & "-NOTA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc") & ".pdf"
        '            End If
        '    End Select


        '    If Not System.IO.File.Exists("C:\FACTURASELECTRONICAS\PDF\" & direccionArchivo) Then
        '        f.ImprimirTicketA4(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
        '    End If

        '    f.StartPosition = FormStartPosition.CenterScreen
        '    ' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    f.ShowDialog()
        'Else
        '    MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        'Cursor = Cursors.Default

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ImprimirTicketEnviarComprobante("Microsoft Print to PDF", DocumentoID)
    End Sub

    Private Sub FormImpresion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub PrintPreviewDialog1_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog1.Load

    End Sub
End Class
