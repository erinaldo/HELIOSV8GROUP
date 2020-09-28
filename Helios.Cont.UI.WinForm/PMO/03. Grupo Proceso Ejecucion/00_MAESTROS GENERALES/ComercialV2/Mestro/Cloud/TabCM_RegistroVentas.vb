Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.IO
Imports OpenInvoicePeru.Comun.Dto.Intercambio
Imports OpenInvoicePeru.Comun.Dto.Modelos

Public Class TabCM_RegistroVentas

    Property CierreSA As New empresaCierreMensualSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim filter As New GridExcelFilter()
    Private anioSel As String
    Private mesSel As String
    Dim ventaSA As New documentoVentaAbarrotesSA
    Private Const FormatoFecha As String = "yyyy-MM-dd"

    Public Sub New(periodo As String, anio As String, mes As String, tipoRegistro As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGrid(dgPedidos)
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        anioSel = anio
        mesSel = mes
        Select Case tipoRegistro
            Case "TODOS"
                Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorPeriodo(periodo)))
                thread.Start()
            Case "ELECTRONICOS"

                Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorTipo(periodo, TIPO_VENTA.VENTA_ELECTRONICA)))
                thread.Start()
            Case "FISICOS"
                Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorTipo(periodo, TIPO_VENTA.VENTA_POS_DIRECTA)))
                thread.Start()

            Case "FISICOS ANULADOS"
                Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorTipoAnulados(periodo, TIPO_VENTA.VENTA_POS_DIRECTA)))
                thread.Start()
            Case "ELECTRONICOS ANULADOS"
                Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorTipoAnulados(periodo, TIPO_VENTA.VENTA_ELECTRONICA)))
                thread.Start()
        End Select

    End Sub

    Public Sub New(be As documentoventaAbarrotes, opcionFecha As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid(dgPedidos)
        GetVentasXFecha(be, opcionFecha)
    End Sub

#Region "GetVentasUltimasHoras"
    Private Sub GetVentasXFecha(be As documentoventaAbarrotes, opcionFecha As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA
        Dim dt As New DataTable("Ventas")
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
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoPreparado", GetType(String)))
        dt.Columns.Add(New DataColumn("idPadre", GetType(Integer)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetVentasPorFecha(be, opcionFecha)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serieVenta
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    dr(6) = i.numeroVenta

                Case TIPO_VENTA.COTIZACION
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL
                    dr(6) = i.numeroVenta
                Case "NTC"
                    dr(6) = i.numeroVenta
                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    dr(6) = i.numeroDoc
                Case Else
                    dr(6) = i.numeroVenta
            End Select
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

            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"

                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    Select Case i.estadoCobro
                        Case Gimnasio_EstadoMembresiaPago.Completo
                            dr(14) = "Cobrado"
                        Case Gimnasio_EstadoMembresiaPago.IngresoLibre
                            dr(14) = "Libre"
                        Case Gimnasio_EstadoMembresiaPago.PagoParcial
                            dr(14) = "Parcial"
                        Case Gimnasio_EstadoMembresiaPago.Pendiente
                            dr(14) = "Pendiente"
                    End Select

                Case Else
                    Select Case i.estadoCobro
                        Case "DC"
                            dr(14) = "Cobrado"
                        Case "ANU"
                            dr(14) = "Anulado"
                        Case TIPO_VENTA.AnuladaPorNotaCredito
                            dr(14) = "Anulado x NC."
                        Case Else
                            dr(14) = "Pendiente"
                    End Select
            End Select


            Select Case i.notaCredito
                Case StatusVentaMatizados.PorPreparar
                    dr(15) = "Pendiente"
                Case StatusVentaMatizados.TerminadaYentregada
                    dr(15) = "Entregada"
            End Select
            If i.tipoVenta = "NTC" Then
                dr(16) = i.idPadre
            End If

            dr(17) = i.EnvioSunat

            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
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

    Function CrearEmisor() As Compania
        Dim Emisor As New Compania

        Emisor.NroDocumento = Gempresas.IdEmpresaRuc '"20603127278"
        Emisor.TipoDocumento = "6"
        Emisor.NombreComercial = Gempresas.NomEmpresa '"INVERSIONES SEÑOR DE ACORIA S.A.C."
        Emisor.NombreLegal = Gempresas.NomEmpresa '"INVERSIONES SEÑOR DE ACORIA S.A.C."
        Emisor.CodigoAnexo = "0001"

        Return Emisor

    End Function


    Sub FacturacionElectronicaSoft21(idDocumento As Integer, direccion As String)

        'Detalle de la Factura
        Dim DetalleItems As DetalleDocumento
        Dim ListaItems As New List(Of DetalleDocumento)

        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA

        Dim DocRelacionado As DocumentoRelacionado
        Dim ListaDocRelacionado As New List(Of DocumentoRelacionado)

        Dim enti As New entidadSA

        Dim conteo As Integer = 0

        Dim tipoDoc As String = ""

        Dim documentoElectronico As New OpenInvoicePeru.Comun.Dto.Modelos.DocumentoElectronico

        Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(idDocumento)
        Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(idDocumento)

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

            'estos datos sirven para crear el código QR o el PDF417
            ' Console.WriteLine("Codigo Hash: {0} ", responseFirma.ResumenFirma) '28 caracteres
            'Console.WriteLine("Valor de la firma: {0}", responseFirma.ValorFirma)
            'File.WriteAllBytes("C:\FACTURASELECTRONICAS\FACTURAS\" & EnviarDocumentoResponse.NombreArchivo & ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))
            File.WriteAllBytes("C:\FACTURASELECTRONICAS\" & "20603329156" & "-" & tipoDoc & "-" & documentoElectronico.IdDocumento & ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))
            'File.WriteAllBytes("C:\FACTURASELECTRONICAS\FACTURAS\" & "PRUEBA" & ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))
            'Console.WriteLine("Enviando a SUNAT....")

            'Dim documentoRequest As New EnviarDocumentoRequest() With {
            '    .Ruc = documentoElectronico.Emisor.NroDocumento,
            '    .UsuarioSol = "MARTIN88",
            '    .ClaveSol = "Samps008",
            '    .EndPointUrl = UrlSunat,
            '    .idDocumento = documentoElectronico.IdDocumento,
            '    .TipoDocumento = documentoElectronico.TipoDocumento,
            '    .TramaXmlFirmado = responseFirma.TramaXmlFirmado
            '}

            'Dim enviarDocumentoResponse = RestHelper(Of EnviarDocumentoRequest, EnviarDocumentoResponse).Execute("EnviarDocumento", documentoRequest)

            'If Not enviarDocumentoResponse.Exito Then

            '    '   MessageBox.Show(enviarDocumentoResponse.MensajeError)
            '    Throw New Exception(enviarDocumentoResponse.MensajeError)
            '    'Exit Sub
            '    'Throw New InvalidOperationException(enviarDocumentoResponse.MensajeError)
            'End If


            'If Not enviarDocumentoResponse.CodigoRespuesta = 0 Then
            '    Throw New Exception(enviarDocumentoResponse.MensajeRespuesta)
            'End If


            'File.WriteAllBytes("C:\FACTURASELECTRONICAS\" & Gempresas.IdEmpresaRuc & "-" & tipoDoc & "-" & documentoElectronico.IdDocumento & ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))
            'File.WriteAllBytes("C:\FACTURASELECTRONICAS\FACTURAS\" & enviarDocumentoResponse.NombreArchivo & ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))
            'File.WriteAllBytes("C:\FACTURASELECTRONICAS\" & "R-" & Gempresas.IdEmpresaRuc & "-" & tipoDoc & "-" & documentoElectronico.IdDocumento & ".zip", Convert.FromBase64String(enviarDocumentoResponse.TramaZipCdr))
            'File.WriteAllBytes("C:\FACTURASELECTRONICAS\FACTURAS\" & "R-" & enviarDocumentoResponse.NombreArchivo & ".zip", Convert.FromBase64String(enviarDocumentoResponse.TramaZipCdr))


            'UpdateEnvioSunat(documento.idDocumento)
            'UpdateEnvioSunatEstado(documento.idDocumento, estado)

            'MsgBox(enviarDocumentoResponse.MensajeRespuesta)
            'Console.WriteLine("Respuesta de SUNAT:")
            'Console.WriteLine(enviarDocumentoResponse.CodigoRespuesta)
            'Console.WriteLine(enviarDocumentoResponse.MensajeRespuesta)
            'MsgBox(enviarDocumentoResponse.MensajeRespuesta)



        Catch ex As Exception
            MsgBox("No se genero el xml" & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub EliminarPV(intIdDocumento As Integer)
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim objDocumento As New documento
        Try
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = intIdDocumento
            End With

            documentoSA.EliminarVenta(objDocumento)
            'documentoSA.EliminarVentaGeneralPV(objDocumento)
            dgPedidos.Table.CurrentRecord.Delete()
            lblEstado.Text = "Pedido eliminado!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Public Sub EliminarNota(intIdDocumentoNota As Integer)
        Dim compraSA As New documentoVentaAbarrotesSA
        Dim objDocumento As New documento
        Dim notaCredito As documentoventaAbarrotes
        Try
            notaCredito = compraSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumentoNota)
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .IdDocumentoAfectado = notaCredito.idPadre ' venta
                .idDocumento = intIdDocumentoNota
            End With
            compraSA.EliminarNotaCreditoMetodoVenta(objDocumento)
            Me.dgPedidos.Table.CurrentRecord.Delete()
            lblEstado.Text = "Nota eliminada correctamente!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Public Function ValidarStock(idDocVenta As Integer)
        Dim documentoventa As New documentoVentaAbarrotesSA

        Dim sintock As Integer = 0
        sintock = documentoventa.StockEliminarNotaVenta(idDocVenta)

        Return sintock
    End Function

    Private Sub GetListaVentasPorTipo(period As String, tipo As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas de - " & period)
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
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoPreparado", GetType(String)))
        dt.Columns.Add(New DataColumn("idPadre", GetType(Integer)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasPeriodoXTipo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, period, tipo, StatusTipoConsulta.XUNIDAD_ORGANICA)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serieVenta
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    dr(6) = i.numeroVenta

                Case TIPO_VENTA.COTIZACION
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL
                    dr(6) = i.numeroVenta
                Case "NTC"
                    dr(6) = i.numeroVenta
                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    dr(6) = i.numeroDoc
                Case Else
                    dr(6) = i.numeroVenta
            End Select
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

            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"

                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    Select Case i.estadoCobro
                        Case Gimnasio_EstadoMembresiaPago.Completo
                            dr(14) = "Cobrado"
                        Case Gimnasio_EstadoMembresiaPago.IngresoLibre
                            dr(14) = "Libre"
                        Case Gimnasio_EstadoMembresiaPago.PagoParcial
                            dr(14) = "Parcial"
                        Case Gimnasio_EstadoMembresiaPago.Pendiente
                            dr(14) = "Pendiente"
                    End Select

                Case Else
                    Select Case i.estadoCobro
                        Case "DC"
                            dr(14) = "Cobrado"
                        Case "ANU"
                            dr(14) = "Anulado"
                        Case TIPO_VENTA.AnuladaPorNotaCredito
                            dr(14) = "Anulado x NC."
                        Case Else
                            dr(14) = "Pendiente"
                    End Select
            End Select


            Select Case i.notaCredito
                Case StatusVentaMatizados.PorPreparar
                    dr(15) = "Pendiente"
                Case StatusVentaMatizados.TerminadaYentregada
                    dr(15) = "Entregada"
            End Select
            If i.tipoVenta = "NTC" Then
                dr(16) = i.idPadre
            End If

            dr(17) = i.EnvioSunat

            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub



    Private Sub GetListaVentasPorTipoAnulados(period As String, tipo As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas de - " & period)
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
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoPreparado", GetType(String)))
        dt.Columns.Add(New DataColumn("idPadre", GetType(Integer)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasPeriodoXTipoAnulados(GEstableciento.IdEstablecimiento, period, tipo)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serieVenta
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    dr(6) = i.numeroVenta

                Case TIPO_VENTA.COTIZACION
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL
                    dr(6) = i.numeroVenta
                Case "NTC"
                    dr(6) = i.numeroVenta
                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    dr(6) = i.numeroDoc
                Case Else
                    dr(6) = i.numeroVenta
            End Select
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

            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"

                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    Select Case i.estadoCobro
                        Case Gimnasio_EstadoMembresiaPago.Completo
                            dr(14) = "Cobrado"
                        Case Gimnasio_EstadoMembresiaPago.IngresoLibre
                            dr(14) = "Libre"
                        Case Gimnasio_EstadoMembresiaPago.PagoParcial
                            dr(14) = "Parcial"
                        Case Gimnasio_EstadoMembresiaPago.Pendiente
                            dr(14) = "Pendiente"
                    End Select

                Case Else
                    Select Case i.estadoCobro
                        Case "DC"
                            dr(14) = "Cobrado"
                        Case "ANU"
                            dr(14) = "Anulado"
                        Case TIPO_VENTA.AnuladaPorNotaCredito
                            dr(14) = "Anulado x NC."
                        Case Else
                            dr(14) = "Pendiente"
                    End Select
            End Select


            Select Case i.notaCredito
                Case StatusVentaMatizados.PorPreparar
                    dr(15) = "Pendiente"
                Case StatusVentaMatizados.TerminadaYentregada
                    dr(15) = "Entregada"
            End Select
            If i.tipoVenta = "NTC" Then
                dr(16) = i.idPadre
            End If

            dr(17) = i.EnvioSunat

            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub


    Private Sub GetListaVentasPorPeriodo(period As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas de - " & period)
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
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoPreparado", GetType(String)))
        dt.Columns.Add(New DataColumn("idPadre", GetType(Integer)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasPeriodo(GEstableciento.IdEstablecimiento, period)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serieVenta
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    dr(6) = i.numeroVenta

                Case TIPO_VENTA.COTIZACION
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL
                    dr(6) = i.numeroVenta
                Case "NTC"
                    dr(6) = i.numeroVenta
                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    dr(6) = i.numeroDoc
                Case Else
                    dr(6) = i.numeroVenta
            End Select
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

            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"

                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    Select Case i.estadoCobro
                        Case Gimnasio_EstadoMembresiaPago.Completo
                            dr(14) = "Cobrado"
                        Case Gimnasio_EstadoMembresiaPago.IngresoLibre
                            dr(14) = "Libre"
                        Case Gimnasio_EstadoMembresiaPago.PagoParcial
                            dr(14) = "Parcial"
                        Case Gimnasio_EstadoMembresiaPago.Pendiente
                            dr(14) = "Pendiente"
                    End Select

                Case Else
                    Select Case i.estadoCobro
                        Case "DC"
                            dr(14) = "Cobrado"
                        Case "ANU"
                            dr(14) = "Anulado"
                        Case TIPO_VENTA.AnuladaPorNotaCredito
                            dr(14) = "Anulado x NC."
                        Case Else
                            dr(14) = "Pendiente"
                    End Select
            End Select


            Select Case i.notaCredito
                Case StatusVentaMatizados.PorPreparar
                    dr(15) = "Pendiente"
                Case StatusVentaMatizados.TerminadaYentregada
                    dr(15) = "Entregada"
            End Select
            If i.tipoVenta = "NTC" Then
                dr(16) = i.idPadre
            End If

            dr(17) = i.EnvioSunat

            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgPedidos.DataSource = table
            ProgressBar1.Visible = False
        End If
    End Sub

    Private Sub dgPedidos_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgPedidos.TableControlCellClick

    End Sub

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

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Cursor = Cursors.WaitCursor
        Try
            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.EDITAR_VENTA_SI_Botón___, AutorizacionRolList) Then
                If Not IsNothing(dgPedidos.Table.CurrentRecord) Then
                    Select Case dgPedidos.Table.CurrentRecord.GetValue("tipoCompra")
                        'Case TIPO_VENTA.VENTA_GENERAL
                        '    Dim f As New frmVenta(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                        '    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        '    f.ShowDialog()
                        'Case TIPO_VENTA.VENTA_NOTA_PEDIDO
                        '    Dim f As New frmVentaPV(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                        '    f.StartPosition = FormStartPosition.CenterParent
                        '    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        '    f.ShowDialog()
                        Case TIPO_VENTA.VENTA_GENERAL, TIPO_VENTA.VENTA_POS_DIRECTA, TIPO_VENTA.VENTA_ELECTRONICA, TIPO_VENTA.VENTA_NOTA_PEDIDO
                            'Dim f As New frmVentaPVdirecta(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                            'f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                            'f.ShowDialog()
                            Dim f As New FormViewVentaGeneral(dgPedidos.Table.CurrentRecord.GetValue("idDocumento")) '
                            ' f.GroupBarMKT.Visible = True
                            f.btGrabar.Enabled = False
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()
                            'Case TIPO_VENTA.VENTA_AL_TICKET
                            '    Dim f As New frmVentaPV(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                            '    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                            '    f.WindowState = FormWindowState.Maximized
                            '    f.ShowDialog()
                    End Select
                Else
                    MessageBox.Show("Debe seleccionar un pedido/venta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ELIMINAR__ANULAR_SI_Botón___, AutorizacionRolList) Then
            If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then
                If MessageBox.Show("Desea Eliminar el item seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Select Case Me.dgPedidos.Table.CurrentRecord.GetValue("tipoCompra")
                        Case TIPO_COMPRA.NOTA_CREDITO
                            Dim tiene As Integer = ValidarStock(Me.dgPedidos.Table.CurrentRecord.GetValue("idPadre"))
                            If tiene = 0 Then
                                EliminarNota(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                            Else
                                MessageBox.Show("No se puede eliminar por que no hay stock!", "Atención")
                            End If
                        'EliminarNota(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                        Case TIPO_COMPRA.NOTA_DEBITO
                    '    EliminarNotaDebito(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                        Case TIPO_VENTA.VENTA_NOTA_PEDIDO
                            EliminarPV(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                        Case TIPO_VENTA.VENTA_GENERAL
                            'se elimina atraves de las notas de credito
                            EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                        Case TIPO_VENTA.VENTA_POS_DIRECTA, TIPO_VENTA.VENTA_AL_TICKET
                            EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                        '   EliminarPVDirecta(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))

                        Case TIPO_VENTA.VENTA_ELECTRONICA
                            If Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc") = "03" Then


                                Dim clas = (Me.dgPedidos.Table.CurrentRecord.GetValue("enviosunat"))

                                If clas.ToString.Trim.Length > 0 Then
                                    If Me.dgPedidos.Table.CurrentRecord.GetValue("enviosunat") = "SI" Then

                                        EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                                    Else
                                        MessageBox.Show("verifique el ticket de envio de la boleta para poder eliminar!", "Atención")
                                    End If
                                Else
                                    MessageBox.Show("La Boleta debe ser enviado a sunat para poder eliminar!", "Atención")
                                End If
                            Else
                                EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                            End If

                    End Select
                End If
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

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Try
            Dim fechaAnt = New Date(anioSel, CInt(mesSel), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = CierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = CierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = anioSel, .mes = CInt(mesSel)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            Dim r As Record = dgPedidos.Table.CurrentRecord
            If Not IsNothing(r) Then
                Select Case r.GetValue("tipoCompra")

                    Case TIPO_VENTA.VENTA_POS_DIRECTA, TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_GENERAL, TIPO_VENTA.VENTA_ANTICIPADA, TIPO_VENTA.VENTA_ANTICIPADA_RECIBIDO, TIPO_VENTA.VENTA_ANTICIPADA_OTORGADO,
                        TIPO_VENTA.VENTA_CONTADO_TOTAL, TIPO_VENTA.VENTA_CONTADO_PARCIAL, TIPO_VENTA.VENTA_CREDITO_TOTAL, TIPO_VENTA.VENTA_CREDITO_PARCIAL

                        'If r.GetValue("estado") = "Anulado x NC." Then
                        '    MessageBox.Show("Este Documento ya fue anulado", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '    Exit Sub
                        'Else
                        Dim f As New frmNotaVentaNew(CInt(r.GetValue("idDocumento")))
                        f.lblPerido.Text = mesSel & "/" & anioSel
                        f.txtFecha.Value = New Date(CInt(anioSel), CInt(mesSel), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()

                    Case TIPO_VENTA.VENTA_ELECTRONICA



                        If r.GetValue("tipoDoc") = "01" Then 'Or r.GetValue("tipoDoc") = "03" Then
                            Dim clas = (Me.dgPedidos.Table.CurrentRecord.GetValue("enviosunat"))

                            If clas.ToString.Trim.Length > 0 Then
                                If Me.dgPedidos.Table.CurrentRecord.GetValue("enviosunat") = "SI" Then

                                    Dim f As New FormNotaVentaDescuentoFE(CInt(r.GetValue("idDocumento"))) 'frmNotaVentaNewFE(CInt(r.GetValue("idDocumento")))
                                    f.lblPerido.Text = mesSel & "/" & anioSel
                                    f.txtFecha.Value = New Date(CInt(anioSel), CInt(mesSel), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                                    f.StartPosition = FormStartPosition.CenterParent
                                    f.ShowDialog()

                                Else
                                    MessageBox.Show("Debe enviar primero para poder emitir nota!", "Atención")
                                End If
                            Else
                                MessageBox.Show("La Factura debe ser enviado a sunat para poder eliminar!", "Atención")
                            End If




                        ElseIf r.GetValue("tipoDoc") = "03" Then


                            Dim clas = (Me.dgPedidos.Table.CurrentRecord.GetValue("enviosunat"))

                            If clas.ToString.Trim.Length > 0 Then
                                If Me.dgPedidos.Table.CurrentRecord.GetValue("enviosunat") = "SI" Then

                                    Dim f As New frmNotaVentaNewFE(CInt(r.GetValue("idDocumento")))
                                    f.lblPerido.Text = mesSel & "/" & anioSel
                                    f.txtFecha.Value = New Date(CInt(anioSel), CInt(mesSel), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                                    f.StartPosition = FormStartPosition.CenterParent
                                    f.ShowDialog()

                                Else
                                    MessageBox.Show("Debe enviar primero para poder emitir nota!", "Atención")
                                End If
                            Else
                                MessageBox.Show("La Boleta debe ser enviado a sunat para poder eliminar!", "Atención")
                            End If



                            'Dim f As New frmNotaVentaNewFE(CInt(r.GetValue("idDocumento")))
                            'f.lblPerido.Text = mesSel & "/" & anioSel
                            'f.txtFecha.Value = New Date(CInt(anioSel), CInt(mesSel), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                            'f.StartPosition = FormStartPosition.CenterParent
                            'f.ShowDialog()

                        Else

                            MessageBox.Show("Seleccione una Factura", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        End If


                    Case Else
                        MessageBox.Show("Debe seleccionar una venta", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        'Try
        '    Dim fechaAnt = New Date(anioSel, CInt(mesSel), 1)
        '    fechaAnt = fechaAnt.AddMonths(-1)
        '    Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        '    If periodoAnteriorEstaCerrado = False Then
        '        MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
        '        Cursor = Cursors.Default
        '        Exit Sub
        '    End If

        '    Dim valida As Boolean = CierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = anioSel, .mes = CInt(mesSel)})
        '    If Not IsNothing(valida) Then
        '        If valida = True Then
        '            MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            Exit Sub
        '        End If
        '    End If
        '    Dim r As Record = dgPedidos.Table.CurrentRecord
        '    If Not IsNothing(r) Then
        '        Select Case r.GetValue("tipoCompra")

        '            Case TIPO_VENTA.VENTA_POS_DIRECTA, TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_GENERAL, TIPO_VENTA.VENTA_ANTICIPADA, TIPO_VENTA.VENTA_ANTICIPADA_RECIBIDO, TIPO_VENTA.VENTA_ANTICIPADA_OTORGADO,
        '                TIPO_VENTA.VENTA_CONTADO_TOTAL, TIPO_VENTA.VENTA_CONTADO_PARCIAL, TIPO_VENTA.VENTA_CREDITO_TOTAL, TIPO_VENTA.VENTA_CREDITO_PARCIAL

        '                'If r.GetValue("estado") = "Anulado x NC." Then
        '                '    MessageBox.Show("Este Documento ya fue anulado", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                '    Exit Sub
        '                'Else
        '                Dim f As New frmNotaVentaNew(CInt(r.GetValue("idDocumento")))
        '                f.lblPerido.Text = mesSel & "/" & anioSel
        '                f.txtFecha.Value = New Date(CInt(anioSel), CInt(mesSel), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        '                f.StartPosition = FormStartPosition.CenterParent
        '                f.ShowDialog()

        '            Case TIPO_VENTA.VENTA_ELECTRONICA

        '                If r.GetValue("tipoDoc") = "01" Then

        '                    Dim f As New frmNotaVentaNewFE(CInt(r.GetValue("idDocumento")))
        '                    f.lblPerido.Text = mesSel & "/" & anioSel
        '                    f.txtFecha.Value = New Date(CInt(anioSel), CInt(mesSel), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        '                    f.StartPosition = FormStartPosition.CenterParent
        '                    f.ShowDialog()

        '                Else

        '                    MessageBox.Show("Seleccione una Factura", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        '                End If


        '            Case Else
        '                MessageBox.Show("Debe seleccionar una venta", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        End Select
        '    Else
        '        MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If
        'Catch ex As Exception
        '    lblEstado.Text = ex.Message
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        'End Try
    End Sub



    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Dim r As Record = dgPedidos.Table.CurrentRecord
        Dim ventaDetSA As New documentoVentaAbarrotesDetSA
        If Not IsNothing(r) Then

            If r.GetValue("tipoDoc") = "01" Or r.GetValue("tipoDoc") = "03" Then

                ClipBoardDocumento = New documento
                ClipBoardDocumento.documentoventaAbarrotes = ventaSA.GetUbicar_documentoventaAbarrotesPorID(Val(r.GetValue("idDocumento")))
                'Dim listaDetalle = CompraDetSA.UbicarDetalleCompraEval(Val(r.GetValue("idDocumento")))
                Dim listaDetalle = ventaDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(Val(r.GetValue("idDocumento")))
                ClipBoardDocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = listaDetalle
                MessageBox.Show("Comprobante copiado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        End If
    End Sub

    Private Sub PanelError_Paint(sender As Object, e As PaintEventArgs) Handles PanelError.Paint

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then
            '    Dim f As New FormImpresionNuevo  ' frmVentaNuevoFormato
            '    f.btnCorreo.Enabled = False
            '    f.DocumentoID = Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")
            '    f.StartPosition = FormStartPosition.CenterScreen
            '    ' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '    f.Show(Me)
            'Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Dim r As Record = dgPedidos.Table.CurrentRecord
        If Not IsNothing(r) Then
            Select Case r.GetValue("tipoCompra")




                Case TIPO_VENTA.VENTA_ELECTRONICA

                    If r.GetValue("tipoDoc") = "01" Then 'Or r.GetValue("tipoDoc") = "03" Then

                        '(CInt(r.GetValue("idDocumento")))

                        Cursor = Cursors.WaitCursor
                        Dim Direccion As String

                        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
                            Direccion = FolderBrowserDialog1.SelectedPath

                            Dim archivo As StreamWriter

                            If Strings.Right(Direccion, 1) = "\" Then
                                archivo = New StreamWriter(Direccion)
                            Else
                                archivo = New StreamWriter(Direccion & "\")
                            End If

                            FacturacionElectronicaSoft21((CInt(r.GetValue("idDocumento"))), Direccion)




                        End If


                        Cursor = Cursors.Default


                    Else

                        MessageBox.Show("Seleccione una Factura Electronica", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    End If


                Case Else
                    MessageBox.Show("Debe seleccionar una venta", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Select
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) 

    End Sub
End Class
