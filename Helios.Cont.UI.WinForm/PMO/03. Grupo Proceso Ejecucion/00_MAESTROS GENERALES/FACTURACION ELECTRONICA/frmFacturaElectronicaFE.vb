Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.IO
Imports OpenInvoicePeru.Comun.Dto.Intercambio
Imports OpenInvoicePeru.Comun.Dto.Modelos

Public Class frmFacturaElectronicaFE

#Region "Variables"
    Private Const UrlSunat As String = "https://www.sunat.gob.pe/ol-ti-itcpfegem/billService"

    'Private Const UrlSunat As String = "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService"

    Private Const FormatoFecha As String = "yyyy-MM-dd"
#End Region

#Region "Constructor"

    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        GetTableGrid()
        FormatoGridAvanzado(GridGroupingControl1, False, False)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        txtPeriodo.Value = DateTime.Now
    End Sub

#End Region

#Region "Metodos"
    Public Sub UpdateEnvioSunatEstado(idDoc As Integer, estado As String)
        Try

            Dim docSA As New documentoVentaAbarrotesSA

            docSA.UpdateFacturasXEstado(idDoc, estado)

            'MessageBox.Show("Se Genero Correctamente")
        Catch ex As Exception
            MessageBox.Show("No se Pudo Actualizar")
        End Try



    End Sub

    Public Sub UpdateEnvioSunat(idDoc As Integer)
        Try

            Dim docSA As New documentoVentaAbarrotesSA

            docSA.UpdateEnvioSunat(idDoc)

            'MessageBox.Show("Se Genero Correctamente")
        Catch ex As Exception
            MessageBox.Show("No se Pudo Actualizar")
        End Try



    End Sub


    Function CrearEmisor() As Compania
        Dim Emisor As New Compania

        Emisor.NroDocumento = Gempresas.IdEmpresaRuc '"20603127278"
        Emisor.TipoDocumento = "6"
        Emisor.NombreComercial = Gempresas.NomEmpresa '"INVERSIONES SEÑOR DE ACORIA S.A.C."
        Emisor.NombreLegal = Gempresas.NomEmpresa '"INVERSIONES SEÑOR DE ACORIA S.A.C."
        Emisor.CodigoAnexo = "0001"

        Return Emisor

    End Function

    'Function CrearEmisor() As Contribuyente
    '    Dim Emisor As New Contribuyente

    '    Emisor.NroDocumento = Gempresas.IdEmpresaRuc
    '    Emisor.TipoDocumento = "6" 'CATALOGO N° 06
    '    Emisor.Direccion = Gempresas.direccionEmpresa
    '    Emisor.Urbanizacion = "-"
    '    Emisor.Departamento = Gempresas.departamento
    '    Emisor.Provincia = Gempresas.provincia
    '    Emisor.Distrito = Gempresas.distrito
    '    Emisor.NombreComercial = Gempresas.NomEmpresa
    '    Emisor.NombreLegal = Gempresas.NomEmpresa
    '    Emisor.Ubigeo = Gempresas.ubigeo

    '    Return Emisor

    'End Function

    Function CrearReceptor() As Contribuyente
        Dim Emisor As New Contribuyente

        'Emisor.NroDocumento = txtruc.Text
        'Emisor.TipoDocumento = txtTipoDoc.Text
        ''Emisor.Direccion = "02-JIRON-AYACUCHO"
        ''Emisor.Urbanizacion = "_"
        ''Emisor.Departamento = "JUNIN"
        ''Emisor.Provincia = "HUANCAYO"
        ''Emisor.Distrito = "HUANCAYO"
        ''Emisor.NombreComercial = "SOFTPACK S.A.C"
        'Emisor.NombreLegal = TXTcOMPRADOR.Text
        ''Emisor.Ubigeo = "120101"

        Return Emisor

    End Function

    Public Sub NotaCreditoFacturaElectronica21(documentont As documentoventaAbarrotes, documentoDet As List(Of documentoventaAbarrotesDet))

        Dim det As DetalleDocumento
        Dim lista As New List(Of DetalleDocumento)
        Dim DocRel As New DocumentoRelacionado
        'Dim listaDocRel As New List(Of DocumentoRelacionado)
        Dim DocDiscrep As New Discrepancia
        ' Dim listaDiscrep As New List(Of Discrepancia)

        Dim count As Integer = 0
        Dim SerieDocumento As String = documentont.serieVenta
        Dim NumeroDocumento As String = String.Format("{0:00000000}", documentont.numeroVenta)
        Dim documentoId As String = SerieDocumento & "-" & NumeroDocumento

        Dim enti As New entidadSA

        Dim receptor = enti.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, documentont.idCliente)

        Try

            Dim documento = New OpenInvoicePeru.Comun.Dto.Modelos.DocumentoElectronico

            documento.Emisor = CrearEmisor()
            'documento.Receptor = CrearReceptor()
            documento.Receptor.NroDocumento = receptor.nrodoc
            documento.Receptor.TipoDocumento = receptor.tipoDoc
            documento.Receptor.NombreLegal = receptor.nombreCompleto


            documento.IdDocumento = documentoId
            documento.FechaEmision = documentont.fechaDoc.Value.Date.ToString(FormatoFecha)
            documento.HoraEmision = documentont.fechaDoc.Value.Date.ToString("HH:mm:ss")
            documento.Moneda = "PEN"
            documento.TipoDocumento = "07"
            documento.TotalIgv = Convert.ToDecimal(documentont.igv01)
            documento.TotalVenta = Convert.ToDecimal(documentont.ImporteNacional)
            documento.Gravadas = Convert.ToDecimal(documentont.bi01)


            'relacion documento origen
            DocRel.TipoDocumento = documentont.TipoDocNota
            DocRel.NroDocumento = documentont.serie & "-" & documentont.numeroDoc
            documento.Relacionados.Add(DocRel)


            DocDiscrep.NroReferencia = documentont.serie & "-" & documentont.numeroDoc
            DocDiscrep.Tipo = documentont.TipoDocNota
            DocDiscrep.Descripcion = "POR ANULACION"
            documento.Discrepancias.Add(DocDiscrep)



            For Each r In documentoDet
                det = New DetalleDocumento
                count += 1
                det.Id = count
                det.Cantidad = Decimal.Parse(r.monto1)
                det.PrecioReferencial = Decimal.Parse(r.precioUnitario)

                If r.destino = "1" Then
                    det.PrecioUnitario = Decimal.Parse(CalculoBaseImponible(r.precioUnitario, 1.18)) ' Decimal.Parse(r.precioUnitario)
                ElseIf r.destino = "2" Then
                    det.PrecioUnitario = Decimal.Parse(r.precioUnitario)
                End If

                det.TipoPrecio = "01"
                det.CodigoItem = r.idItem
                det.Descripcion = r.nombreItem
                det.UnidadMedida = r.unidad1
                det.Impuesto = Decimal.Parse(r.montoIgv)
                det.TipoImpuesto = "10" 'r.GetValue("TipoImpuesto").ToString() '"10"
                det.TotalVenta = Decimal.Parse(r.montokardex) 'Decimal.Parse(r.importeMN)

                lista.Add(det)

            Next

            documento.Items = lista




            'GENERANDO XML

            Dim documentoResponse = RestHelper(Of DocumentoElectronico, DocumentoResponse).Execute("GenerarNotaCredito", documento)

            If Not documentoResponse.Exito Then
                MessageBox.Show(documentoResponse.MensajeError)
                Exit Sub

            End If


            ' Firmado del Documento.
            Dim firmado As New FirmadoRequest() With {
                .TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma,
                .CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("C:\CERIFICADOSOFTPACK.pfx")),
                .PasswordCertificado = "7cZGKQsu4idgwzib"
            }

            Dim responseFirma = RestHelper(Of FirmadoRequest, FirmadoResponse).Execute("Firmar", firmado)

            If Not responseFirma.Exito Then
                MessageBox.Show(responseFirma.MensajeError)
                Exit Sub


            End If

            'File.WriteAllBytes("C:\FACTURASELECTRONICAS\" + documento.IdDocumento + ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))

            'Enviando a sunat


            Dim documentoRequest As New EnviarDocumentoRequest() With {
                .Ruc = documento.Emisor.NroDocumento,
                .UsuarioSol = "MARTIN88",
                .ClaveSol = "Samps008",
                .EndPointUrl = UrlSunat,
                .IdDocumento = documento.IdDocumento,
                .TipoDocumento = documento.TipoDocumento,
                .TramaXmlFirmado = responseFirma.TramaXmlFirmado
            }

            Dim enviarDocumentoResponse = RestHelper(Of EnviarDocumentoRequest, EnviarDocumentoResponse).Execute("EnviarDocumento", documentoRequest)

            If Not enviarDocumentoResponse.Exito Then


                'MessageBox.Show(enviarDocumentoResponse.MensajeError)
                'Exit Sub
                Throw New Exception(enviarDocumentoResponse.MensajeError)
            End If

            If Not enviarDocumentoResponse.CodigoRespuesta = 0 Then
                Throw New Exception(enviarDocumentoResponse.MensajeRespuesta)
            End If

            File.WriteAllBytes("C:\FACTURASELECTRONICAS\NOTASCREDITO\" + enviarDocumentoResponse.NombreArchivo + ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))
            File.WriteAllBytes("C:\FACTURASELECTRONICAS\NOTASCREDITO\" + "R-" + enviarDocumentoResponse.NombreArchivo + ".zip", Convert.FromBase64String(enviarDocumentoResponse.TramaZipCdr))

            'Console.WriteLine("Respuesta de SUNAT:")
            'Console.WriteLine(enviarDocumentoResponse.MensajeRespuesta)

            'MessageBox.Show("Respuesta de SUNAT:" & " " & enviarDocumentoResponse.MensajeRespuesta)
            UpdateEnvioSunat(documentont.idDocumento)

            MsgBox(enviarDocumentoResponse.MensajeRespuesta)

        Catch ex As Exception
            MsgBox("No se genero la factura electronica" & vbCrLf & ex.Message)
        End Try

    End Sub

    'Public Sub NotaCreditoFacturaElectronica(documentont As documentoventaAbarrotes, documentoDet As List(Of documentoventaAbarrotesDet))

    '    Dim det As DetalleDocumento
    '    Dim lista As New List(Of DetalleDocumento)
    '    Dim DocRel As New DocumentoRelacionado
    '    'Dim listaDocRel As New List(Of DocumentoRelacionado)
    '    Dim DocDiscrep As New Discrepancia
    '    ' Dim listaDiscrep As New List(Of Discrepancia)

    '    Dim count As Integer = 0
    '    Dim SerieDocumento As String = documentont.serieVenta
    '    Dim NumeroDocumento As String = String.Format("{0:00000000}", documentont.numeroVenta)
    '    Dim documentoId As String = SerieDocumento & "-" & NumeroDocumento


    '    Dim enti As New entidadSA




    '    Dim receptor = enti.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, documentont.idCliente)





    '    Try

    '        Dim documento = New OpenInvoicePeru.Comun.Dto.Modelos.DocumentoElectronico

    '        documento.Emisor = CrearEmisor()
    '        'documento.Receptor = CrearReceptor()
    '        documento.Receptor.NroDocumento = receptor.nrodoc
    '        documento.Receptor.TipoDocumento = receptor.tipoDoc
    '        documento.Receptor.NombreLegal = receptor.nombreCompleto


    '        documento.IdDocumento = documentoId
    '        documento.FechaEmision = documentont.fechaDoc.Value.Date.ToString(FormatoFecha)
    '        documento.Moneda = "PEN"
    '        documento.TipoDocumento = "07"
    '        documento.TotalIgv = Convert.ToDecimal(documentont.igv01)
    '        documento.TotalVenta = Convert.ToDecimal(documentont.ImporteNacional)
    '        documento.Gravadas = Convert.ToDecimal(documentont.bi01)


    '        'relacion documento origen
    '        DocRel.TipoDocumento = documentont.TipoDocNota
    '        DocRel.NroDocumento = documentont.serie & "-" & documentont.numeroDoc
    '        documento.Relacionados.Add(DocRel)


    '        DocDiscrep.NroReferencia = documentont.serie & "-" & documentont.numeroDoc
    '        DocDiscrep.Tipo = documentont.TipoDocNota
    '        DocDiscrep.Descripcion = "POR ANULACION"
    '        documento.Discrepancias.Add(DocDiscrep)





    '        For Each r In documentoDet
    '            det = New DetalleDocumento
    '            count += 1
    '            det.Id = count
    '            det.Cantidad = Decimal.Parse(r.monto1)
    '            det.PrecioReferencial = Decimal.Parse(r.precioUnitario)
    '            det.PrecioUnitario = Decimal.Parse(r.precioUnitario)
    '            det.TipoPrecio = "01"
    '            det.CodigoItem = r.idItem
    '            det.Descripcion = r.nombreItem
    '            det.UnidadMedida = r.unidad1
    '            det.Impuesto = Decimal.Parse(r.montoIgv)
    '            det.TipoImpuesto = "10" 'r.GetValue("TipoImpuesto").ToString() '"10"
    '            det.TotalVenta = Decimal.Parse(r.importeMN)







    '            lista.Add(det)



    '        Next

    '        documento.Items = lista




    '        'GENERANDO XML

    '        Dim documentoResponse = RestHelper(Of DocumentoElectronico, DocumentoResponse).Execute("GenerarNotaCredito", documento)

    '        If Not documentoResponse.Exito Then
    '            MessageBox.Show(documentoResponse.MensajeError)
    '            Exit Sub

    '        End If


    '        ' Firmado del Documento.
    '        Dim firmado As New FirmadoRequest() With {
    '            .TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma,
    '            .CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("C:\CERIFICADOSOFTPACK.pfx")),
    '            .PasswordCertificado = "7cZGKQsu4idgwzib"
    '        }

    '        Dim responseFirma = RestHelper(Of FirmadoRequest, FirmadoResponse).Execute("Firmar", firmado)

    '        If Not responseFirma.Exito Then
    '            MessageBox.Show(responseFirma.MensajeError)
    '            Exit Sub


    '        End If

    '        'File.WriteAllBytes("C:\FACTURASELECTRONICAS\" + documento.IdDocumento + ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))

    '        'Enviando a sunat


    '        Dim documentoRequest As New EnviarDocumentoRequest() With {
    '            .Ruc = documento.Emisor.NroDocumento,
    '            .UsuarioSol = "MARTIN88",
    '            .ClaveSol = "Samps008",
    '            .EndPointUrl = UrlSunat,
    '            .IdDocumento = documento.IdDocumento,
    '            .TipoDocumento = documento.TipoDocumento,
    '            .TramaXmlFirmado = responseFirma.TramaXmlFirmado
    '        }

    '        Dim enviarDocumentoResponse = RestHelper(Of EnviarDocumentoRequest, EnviarDocumentoResponse).Execute("EnviarDocumento", documentoRequest)

    '        If Not enviarDocumentoResponse.Exito Then


    '            'MessageBox.Show(enviarDocumentoResponse.MensajeError)
    '            'Exit Sub
    '            Throw New Exception(enviarDocumentoResponse.MensajeError)
    '        End If

    '        File.WriteAllBytes("C:\FACTURASELECTRONICAS\NOTASCREDITO\" + enviarDocumentoResponse.NombreArchivo + ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))
    '        File.WriteAllBytes("C:\FACTURASELECTRONICAS\NOTASCREDITO\" + "R-" + enviarDocumentoResponse.NombreArchivo + ".zip", Convert.FromBase64String(enviarDocumentoResponse.TramaZipCdr))

    '        'Console.WriteLine("Respuesta de SUNAT:")
    '        'Console.WriteLine(enviarDocumentoResponse.MensajeRespuesta)

    '        'MessageBox.Show("Respuesta de SUNAT:" & " " & enviarDocumentoResponse.MensajeRespuesta)
    '        UpdateEnvioSunat(documentont.idDocumento)

    '        MsgBox(enviarDocumentoResponse.MensajeRespuesta)

    '    Catch ex As Exception
    '        MsgBox("No se genero la factura electronica" & vbCrLf & ex.Message)
    '    End Try

    'End Sub


    Public Sub GenerarFacturaElectronica(idDocumento As Integer, Tipo As String, estado As String)

        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA

        If Tipo = "FACTURA" Then
            Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(idDocumento)
            Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(idDocumento)

            FacturacionElectronicaSoft21(comprobante, comprobanteDetalle, estado)

        ElseIf Tipo = "NOTAS DE CREDITO" Then




            Dim comprobanteNota = documentoSA.GetUbicar_NotaXID(idDocumento)
            Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(idDocumento)

            'If comprobanteNota.EnvioSunat = "SI" Then
            NotaCreditoFacturaElectronica21(comprobanteNota, comprobanteDetalle)
            'Else
            '    Exit Sub
            '    MessageBox.Show("Debe Enviar Primero la Factura Electronica Relacionada")
            'End If

        End If



    End Sub

    Sub FacturacionElectronicaSoft21(documento As documentoventaAbarrotes, documentoDet As List(Of documentoventaAbarrotesDet), estado As String)

        'Detalle de la Factura
        Dim DetalleItems As DetalleDocumento
        Dim ListaItems As New List(Of DetalleDocumento)

        Dim DocRelacionado As DocumentoRelacionado
        Dim ListaDocRelacionado As New List(Of DocumentoRelacionado)

        Dim enti As New entidadSA

        Dim conteo As Integer = 0

        Dim tipoDoc As String = ""

        Dim documentoElectronico As New OpenInvoicePeru.Comun.Dto.Modelos.DocumentoElectronico

        Dim receptor = enti.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, documento.idCliente)

        Dim numerovent As String = String.Format("{0:00000000}", documento.numeroVenta)

        Dim fechaFact As DateTime = documento.fechaDoc

        Try

            'Datos Cabezera Factura-------------------------------
            documentoElectronico.Emisor = CrearEmisor()

            'documentoElectronico.Receptor = CrearReceptor()
            documentoElectronico.Receptor.NroDocumento = receptor.nrodoc
            documentoElectronico.Receptor.TipoDocumento = receptor.tipoDoc
            documentoElectronico.Receptor.NombreLegal = receptor.nombreCompleto



            documentoElectronico.IdDocumento = documento.serieVenta & "-" & numerovent

            'documentoElectronico.IdDocumento = documento.serieVenta & "-" & documento.numeroVenta

            documentoElectronico.FechaEmision = fechaFact.ToString(FormatoFecha)  ' documento.fechaDoc.Value.Year & "-" & String.Format("{0:00}", documento.fechaDoc.Value.Month) & "-" & String.Format("{0:00}", documento.fechaDoc.Value.Day)
            documentoElectronico.HoraEmision = fechaFact.ToString("HH:mm:ss")

            If documento.moneda = "1" Then
                documentoElectronico.Moneda = "PEN"
            ElseIf documento.moneda = "2" Then
                documentoElectronico.Moneda = "USD"
            End If

            tipoDoc = String.Format("{0:00}", documento.tipoDocumento)

            documentoElectronico.TipoDocumento = tipoDoc
            documentoElectronico.TotalIgv = documento.igv01
            documentoElectronico.TotalVenta = documento.ImporteNacional 'documento.bi01 + documento.bi02 
            documentoElectronico.Gravadas = documento.bi01
            'documentoElectronico.Exoneradas = documento.bi02
            documentoElectronico.Exoneradas = documento.bi02
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
            For Each i In documentoDet
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

            'estos datos sirven para crear el código QR o el PDF417
            ' Console.WriteLine("Codigo Hash: {0} ", responseFirma.ResumenFirma) '28 caracteres
            'Console.WriteLine("Valor de la firma: {0}", responseFirma.ValorFirma)

            'File.WriteAllBytes("C:\FACTURASELECTRONICAS\" & "20603329156" & "-" & tipoDoc & "-" & documentoElectronico.IdDocumento & ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))
            'File.WriteAllBytes("C:\FACTURASELECTRONICAS\FACTURAS\" & "PRUEBA" & ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))
            'Console.WriteLine("Enviando a SUNAT....")

            Dim documentoRequest As New EnviarDocumentoRequest() With {
                .Ruc = documentoElectronico.Emisor.NroDocumento,
                .UsuarioSol = "MARTIN88",
                .ClaveSol = "Samps008",
                .EndPointUrl = UrlSunat,
                .IdDocumento = documentoElectronico.IdDocumento,
                .TipoDocumento = documentoElectronico.TipoDocumento,
                .TramaXmlFirmado = responseFirma.TramaXmlFirmado
            }

            Dim enviarDocumentoResponse = RestHelper(Of EnviarDocumentoRequest, EnviarDocumentoResponse).Execute("EnviarDocumento", documentoRequest)

            If Not enviarDocumentoResponse.Exito Then

                '   MessageBox.Show(enviarDocumentoResponse.MensajeError)
                Throw New Exception(enviarDocumentoResponse.MensajeError)
                'Exit Sub
                'Throw New InvalidOperationException(enviarDocumentoResponse.MensajeError)
            End If


            If Not enviarDocumentoResponse.CodigoRespuesta = 0 Then
                Throw New Exception(enviarDocumentoResponse.MensajeRespuesta)
            End If


            'File.WriteAllBytes("C:\FACTURASELECTRONICAS\" & Gempresas.IdEmpresaRuc & "-" & tipoDoc & "-" & documentoElectronico.IdDocumento & ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))
            File.WriteAllBytes("C:\FACTURASELECTRONICAS\FACTURAS\" & enviarDocumentoResponse.NombreArchivo & ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))
            'File.WriteAllBytes("C:\FACTURASELECTRONICAS\" & "R-" & Gempresas.IdEmpresaRuc & "-" & tipoDoc & "-" & documentoElectronico.IdDocumento & ".zip", Convert.FromBase64String(enviarDocumentoResponse.TramaZipCdr))
            File.WriteAllBytes("C:\FACTURASELECTRONICAS\FACTURAS\" & "R-" & enviarDocumentoResponse.NombreArchivo & ".zip", Convert.FromBase64String(enviarDocumentoResponse.TramaZipCdr))


            'UpdateEnvioSunat(documento.idDocumento)
            UpdateEnvioSunatEstado(documento.idDocumento, estado)

            MsgBox(enviarDocumentoResponse.MensajeRespuesta)
            'Console.WriteLine("Respuesta de SUNAT:")
            'Console.WriteLine(enviarDocumentoResponse.CodigoRespuesta)
            'Console.WriteLine(enviarDocumentoResponse.MensajeRespuesta)
            'MsgBox(enviarDocumentoResponse.MensajeRespuesta)



        Catch ex As Exception
            MsgBox("No se genero la factura electronica" & vbCrLf & ex.Message)
        End Try

    End Sub

    'Sub FacturacionElectronicaSoft(documento As documentoventaAbarrotes, documentoDet As List(Of documentoventaAbarrotesDet), estado As String)

    '    'Detalle de la Factura
    '    Dim DetalleItems As DetalleDocumento
    '    Dim ListaItems As New List(Of DetalleDocumento)

    '    Dim DocRelacionado As DocumentoRelacionado
    '    Dim ListaDocRelacionado As New List(Of DocumentoRelacionado)

    '    Dim enti As New entidadSA

    '    Dim conteo As Integer = 0

    '    Dim tipoDoc As String = ""

    '    Dim documentoElectronico As New OpenInvoicePeru.Comun.Dto.Modelos.DocumentoElectronico

    '    Dim receptor = enti.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, documento.idCliente)

    '    Dim numerovent As String = String.Format("{0:00000000}", documento.numeroVenta)

    '    Try

    '        'Datos Cabezera Factura-------------------------------
    '        documentoElectronico.Emisor = CrearEmisor()

    '        'documentoElectronico.Receptor = CrearReceptor()
    '        documentoElectronico.Receptor.NroDocumento = receptor.nrodoc
    '        documentoElectronico.Receptor.TipoDocumento = receptor.tipoDoc
    '        documentoElectronico.Receptor.NombreLegal = receptor.nombreCompleto



    '        documentoElectronico.IdDocumento = documento.serieVenta & "-" & numerovent

    '        'documentoElectronico.IdDocumento = documento.serieVenta & "-" & documento.numeroVenta

    '        documentoElectronico.FechaEmision = documento.fechaDoc.Value.Year & "-" & String.Format("{0:00}", documento.fechaDoc.Value.Month) & "-" & String.Format("{0:00}", documento.fechaDoc.Value.Day)
    '        If documento.moneda = "1" Then
    '            documentoElectronico.Moneda = "PEN"
    '        ElseIf documento.moneda = "2" Then
    '            documentoElectronico.Moneda = "USD"
    '        End If

    '        tipoDoc = String.Format("{0:00}", documento.tipoDocumento)

    '        documentoElectronico.TipoDocumento = tipoDoc
    '        documentoElectronico.TotalIgv = documento.igv01
    '        documentoElectronico.TotalVenta = documento.ImporteNacional
    '        documentoElectronico.Gravadas = documento.bi01
    '        documentoElectronico.Exoneradas = documento.bi02
    '        documentoElectronico.TipoOperacion = String.Format("{0:00}", documento.tipoOperacion)
    '        'documentoElectronico .Inafectas = "Falta"
    '        'documentoElectronico .Gratuitas = "falta"
    '        'documentoElectronico .DescuentoGlobal = "falta"
    '        'documentoElectronico .TotalIsc = "falta"
    '        'documentoElectronico .MontoPercepcion = "falta"
    '        'documentoElectronico.MontoDetraccion = "falta"
    '        'documentoElectronico .CalculoDetraccion = "falta"
    '        'documentoElectronico .TotalOtrosTributos = "falta"

    '        'Anexar con Anticipo
    '        'documentoElectronico.TipoDocAnticipo = "falta"
    '        'documentoElectronico.MonedaAnticipo = "falta"
    '        'documentoElectronico.MontoAnticipo = "falta"
    '        'documentoElectronico.DocAnticipo = "falta"

    '        'DatosGuiaTransportista
    '        'documentoElectronico.DatosGuiaTransportista = "Falta"

    '        'documentoElectronico.DatosGuiaTransportista.DireccionOrigen = "Datos Origen" tipo contribuyente
    '        'documentoElectronico.DatosGuiaTransportista.DireccionDestino = "Datos Destino" tipo contribuyente
    '        'documentoElectronico.DatosGuiaTransportista.RucTransportista = ""
    '        'documentoElectronico.DatosGuiaTransportista.TipoDocTransportista = ""
    '        'documentoElectronico.DatosGuiaTransportista.NombreTransportista = ""
    '        'documentoElectronico.DatosGuiaTransportista.NroLicenciaConducir = ""
    '        'documentoElectronico.DatosGuiaTransportista.PlacaVehiculo = ""
    '        'documentoElectronico.DatosGuiaTransportista.CodigoAutorizacion = ""
    '        'documentoElectronico.DatosGuiaTransportista.MarcaVehiculo = ""
    '        'documentoElectronico.DatosGuiaTransportista.ModoTransporte = ""
    '        'documentoElectronico.DatosGuiaTransportista.UnidadMedida = ""
    '        'documentoElectronico.DatosGuiaTransportista.PesoBruto = ""

    '        'Datos Detalle Factura---------------------------------------------
    '        For Each i In documentoDet
    '            conteo += 1

    '            DetalleItems = New DetalleDocumento
    '            DetalleItems.Id = conteo
    '            DetalleItems.Cantidad = i.monto1
    '            DetalleItems.PrecioReferencial = i.precioUnitario
    '            DetalleItems.PrecioUnitario = i.precioUnitario

    '            DetalleItems.CodigoItem = i.idItem
    '            DetalleItems.Descripcion = i.nombreItem
    '            DetalleItems.UnidadMedida = i.unidad1
    '            DetalleItems.Impuesto = i.montoIgv
    '            If i.destino = "1" Then
    '                DetalleItems.TipoImpuesto = "10" 'CATALOGO 7
    '                DetalleItems.TipoPrecio = "01" 'CATALOGO 16
    '            ElseIf i.destino = "2" Then
    '                DetalleItems.TipoImpuesto = "20" 'CATALOGO 7
    '                DetalleItems.TipoPrecio = "02"  'CATALOGO 16
    '            End If
    '            DetalleItems.TotalVenta = i.importeMN
    '            'DetalleItems .Descuento = "falta"
    '            'DetalleItems .ImpuestoSelectivo = "falta"
    '            'DetalleItems.OtroImpuesto = "falta"
    '            'DetalleItems.PlacaVehiculo = "falta"
    '            ListaItems.Add(DetalleItems)
    '        Next
    '        documentoElectronico.Items = ListaItems

    '        'Relacionar con Documentos como nota de credito nota debito
    '        'For Each 
    '        'DocRelacionado = New DocumentoRelacionado
    '        '    DocRelacionado.NroDocumento = "F001-1"
    '        '    DocRelacionado.TipoDocumento = "07"
    '        '    ListaDocRelacionado.Add(DocRelacionado)
    '        'Next
    '        'documentoElectronico.Relacionados = ListaDocRelacionado



    '        Dim documentoResponse = RestHelper(Of DocumentoElectronico, DocumentoResponse).Execute("GenerarFactura", documentoElectronico)

    '        If Not documentoResponse.Exito Then
    '            MessageBox.Show(documentoResponse.MensajeError)
    '            Exit Sub
    '        End If

    '        Dim firmado As New FirmadoRequest() With {
    '            .TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma,
    '            .CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("C:\CERIFICADOSOFTPACK.pfx")),
    '            .PasswordCertificado = "7cZGKQsu4idgwzib"
    '        }

    '        Dim responseFirma = RestHelper(Of FirmadoRequest, FirmadoResponse).Execute("Firmar", firmado)

    '        If Not responseFirma.Exito Then
    '            Throw New InvalidOperationException(responseFirma.MensajeError)
    '        End If

    '        'estos datos sirven para crear el código QR o el PDF417
    '        ' Console.WriteLine("Codigo Hash: {0} ", responseFirma.ResumenFirma) '28 caracteres
    '        'Console.WriteLine("Valor de la firma: {0}", responseFirma.ValorFirma)

    '        'File.WriteAllBytes("C:\FACTURASELECTRONICAS\" & "20603329156" & "-" & tipoDoc & "-" & documentoElectronico.IdDocumento & ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))

    '        'Console.WriteLine("Enviando a SUNAT....")

    '        Dim documentoRequest As New EnviarDocumentoRequest() With {
    '            .Ruc = documentoElectronico.Emisor.NroDocumento,
    '            .UsuarioSol = "MARTIN88",
    '            .ClaveSol = "Samps008",
    '            .EndPointUrl = UrlSunat,
    '            .IdDocumento = documentoElectronico.IdDocumento,
    '            .TipoDocumento = documentoElectronico.TipoDocumento,
    '            .TramaXmlFirmado = responseFirma.TramaXmlFirmado
    '        }

    '        Dim enviarDocumentoResponse = RestHelper(Of EnviarDocumentoRequest, EnviarDocumentoResponse).Execute("EnviarDocumento", documentoRequest)

    '        If Not enviarDocumentoResponse.Exito Then




    '            '   MessageBox.Show(enviarDocumentoResponse.MensajeError)
    '            Throw New Exception(enviarDocumentoResponse.MensajeError)
    '            'Exit Sub
    '            'Throw New InvalidOperationException(enviarDocumentoResponse.MensajeError)
    '        End If

    '        'File.WriteAllBytes("C:\FACTURASELECTRONICAS\" & Gempresas.IdEmpresaRuc & "-" & tipoDoc & "-" & documentoElectronico.IdDocumento & ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))
    '        File.WriteAllBytes("C:\FACTURASELECTRONICAS\FACTURAS\" & enviarDocumentoResponse.NombreArchivo & ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))
    '        'File.WriteAllBytes("C:\FACTURASELECTRONICAS\" & "R-" & Gempresas.IdEmpresaRuc & "-" & tipoDoc & "-" & documentoElectronico.IdDocumento & ".zip", Convert.FromBase64String(enviarDocumentoResponse.TramaZipCdr))
    '        File.WriteAllBytes("C:\FACTURASELECTRONICAS\FACTURAS\" & "R-" & enviarDocumentoResponse.NombreArchivo & ".zip", Convert.FromBase64String(enviarDocumentoResponse.TramaZipCdr))


    '        'UpdateEnvioSunat(documento.idDocumento)
    '        UpdateEnvioSunatEstado(documento.idDocumento, estado)

    '        MsgBox(enviarDocumentoResponse.MensajeRespuesta)
    '        'Console.WriteLine("Respuesta de SUNAT:")
    '        'Console.WriteLine(enviarDocumentoResponse.CodigoRespuesta)
    '        'Console.WriteLine(enviarDocumentoResponse.MensajeRespuesta)
    '        'MsgBox(enviarDocumentoResponse.MensajeRespuesta)

    '    Catch ex As Exception
    '        MsgBox("No se genero la factura electronica" & vbCrLf & ex.Message)
    '    End Try

    'End Sub
    Public Sub BuscarDocsFechaPeriodo(fecha As DateTime, tipoDoc As String)
        Dim docSA As New documentoVentaAbarrotesSA
        GridGroupingControl1.Table.Records.DeleteAll()
        Dim consulta = docSA.BuscarFacturanoEnviadasPeriodo(fecha, tipoDoc, Gempresas.IdEmpresaRuc)

        If consulta.Count = 0 Then

            MessageBox.Show("No hay documentos por enviar")
        Else
            For Each i In consulta
                Me.GridGroupingControl1.Table.AddNewRecord.SetCurrent()
                Me.GridGroupingControl1.Table.AddNewRecord.BeginEdit()
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("serie", i.serieVenta)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("numero", i.numeroVenta)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipodoc", i.tipoDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("importe", i.ImporteNacional)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("enviosunat", i.EnvioSunat)
                Me.GridGroupingControl1.Table.AddNewRecord.EndEdit()


            Next
        End If

    End Sub

    Public Sub BuscarDocsFecha(fecha As DateTime, tipoDoc As String)

        Dim docSA As New documentoVentaAbarrotesSA

        GridGroupingControl1.Table.Records.DeleteAll()

        Dim consulta = docSA.BuscarFacturanoEnviadas(fecha, tipoDoc, Gempresas.IdEmpresaRuc)

        If consulta.Count = 0 Then

            MessageBox.Show("No hay documentos por enviar")
        Else
            For Each i In consulta
                Me.GridGroupingControl1.Table.AddNewRecord.SetCurrent()
                Me.GridGroupingControl1.Table.AddNewRecord.BeginEdit()
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("serie", i.serieVenta)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("numero", i.numeroVenta)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipodoc", i.tipoDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("importe", i.ImporteNacional)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("enviosunat", i.EnvioSunat)
                Me.GridGroupingControl1.Table.AddNewRecord.EndEdit()
            Next
        End If

    End Sub


    Sub FormatoGridAvanzado(GGC As GridGroupingControl, FullRowSelect As Boolean, AllowProportionalColumnSizing As Boolean)
        Dim colorx As New GridMetroColors()
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = BorderStyle.None
        '  GGC.BrowseOnly = True
        If FullRowSelect = True Then
            GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
            GGC.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
            GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GGC.TableOptions.SelectionBackColor = Color.Gray
        End If
        GGC.AllowProportionalColumnSizing = AllowProportionalColumnSizing
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("importe")
        dt.Columns.Add("enviosunat")




        GridGroupingControl1.DataSource = dt
    End Sub
#End Region
    Private Sub frmFacturaElectronicaFE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click

        If chkFecha.Checked = True Then

            Select Case ComboBox1.Text
                Case "FACTURA"
                    BuscarDocsFecha(dtpFechaDocs.Value, "01")
                Case "NOTAS DE CREDITO"
                    BuscarDocsFecha(dtpFechaDocs.Value, "07")
                Case "NOTA DE DEBITO"
                    ' BuscarDocsFecha(dtpFechaDocs.Value, "08")
            End Select


        ElseIf chkPeriodo.Checked = True Then



            Select Case ComboBox1.Text
                Case "FACTURA"
                    BuscarDocsFechaPeriodo(txtPeriodo.Value, "01")
                Case "NOTAS DE CREDITO"
                    BuscarDocsFechaPeriodo(txtPeriodo.Value, "07")
                Case "NOTA DE DEBITO"
                    ' BuscarDocsFecha(dtpFechaDocs.Value, "08")
            End Select
        End If


    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim r As Record
        Try
            r = GridGroupingControl1.Table.CurrentRecord



            If r.GetValue("idDocumento") > 0 Then

                Select Case r.GetValue("tipodoc")
                    Case "01"


                        Dim clas = (r.GetValue("enviosunat"))

                        If clas.ToString.Trim.Length > 0 Then

                            If r.GetValue("enviosunat") = "NE" Then
                                GenerarFacturaElectronica(CInt(r.GetValue("idDocumento")), "FACTURA", "PE")
                            End If

                        Else

                            GenerarFacturaElectronica(CInt(r.GetValue("idDocumento")), "FACTURA", "SI")

                        End If



                        'If r.GetValue("enviosunat") = "NE" Then
                        '    GenerarFacturaElectronica(CInt(r.GetValue("idDocumento")), "FACTURA", "PE")

                        'ElseIf r.GetValue("enviosunat") = Nothing Then

                        '    GenerarFacturaElectronica(CInt(r.GetValue("idDocumento")), "FACTURA", "SI")

                        'End If







                    Case "07"
                        GenerarFacturaElectronica(CInt(r.GetValue("idDocumento")), "NOTAS DE CREDITO", "")
                    Case "08"

                End Select

                'GenerarFacturaElectronica(CInt(r.GetValue("idDocumento")))
                ' UpdateEnvioSunat(CInt(r.GetValue("idDocumento")))


                Select Case ComboBox1.Text
                    Case "FACTURA"
                        BuscarDocsFecha(dtpFechaDocs.Value, "01")
                    Case "NOTAS DE CREDITO"
                        BuscarDocsFecha(dtpFechaDocs.Value, "07")
                    Case "NOTA DE DEBITO"
                        BuscarDocsFecha(dtpFechaDocs.Value, "08")
                End Select
            Else
                MessageBox.Show("Seleccione un Documento para Enviar")

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dtpFechaDocs_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaDocs.ValueChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        GridGroupingControl1.Table.Records.DeleteAll()
    End Sub

    Private Sub chkFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkFecha.CheckedChanged

        GridGroupingControl1.Table.Records.DeleteAll()

        If chkFecha.Checked = True Then

            lblFecha.Visible = True
            dtpFechaDocs.Visible = True

            txtPeriodo.Visible = False
            lblPeriodo.Visible = False
            chkPeriodo.Checked = False

        ElseIf chkFecha.Checked = False Then
            lblFecha.Visible = False
            dtpFechaDocs.Visible = False

            txtPeriodo.Visible = True
            lblPeriodo.Visible = True

            chkPeriodo.Checked = True
        End If
    End Sub

    Private Sub chkPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkPeriodo.CheckedChanged

        GridGroupingControl1.Table.Records.DeleteAll()

        If chkPeriodo.Checked = True Then

            lblFecha.Visible = False
            dtpFechaDocs.Visible = False

            txtPeriodo.Visible = True
            lblPeriodo.Visible = True
            chkFecha.Checked = False

        ElseIf chkPeriodo.Checked = False Then
            lblFecha.Visible = True
            dtpFechaDocs.Visible = True

            txtPeriodo.Visible = False
            lblPeriodo.Visible = False

            chkFecha.Checked = True
        End If
    End Sub
End Class