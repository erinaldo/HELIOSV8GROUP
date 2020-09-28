Imports System.Drawing.Printing
Imports Helios.Cont.Business.Entity
Imports Syncfusion.DocIO
Imports Syncfusion.DocIO.DLS
Imports Syncfusion.DocToPDFConverter
Imports Syncfusion.OfficeChartToImageConverter
Imports Syncfusion.Pdf
Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess


Public Class ucEmisionGuiaPaso5
    Public Property CustomDocumento As documento
    Private FormImpresionNuevo As FormImpresionNuevo
    Public Sub New(formGuiaRemision8 As FormGuiaRemision8)

        ' This call is required by the designer.
        InitializeComponent()
        _formGuiaRemision8 = formGuiaRemision8

        ' Add any initialization after the InitializeComponent() call.

    End Sub


#Region "mETODOS"


    Public Sub UpdateEnvioSunatEstado(idDoc As Integer, estado As String)
        Try

            Dim docSA As New DocumentoGuiaSA
            docSA.UpdateGuiaXEstado(idDoc, estado)
        Catch ex As Exception
        End Try



    End Sub

    Public Sub EnvioGuiaDeGuiaRemision(be As documentoGuia, idPSE As Integer)


        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim entidadSA As New entidadSA
        Dim DetalleGuia As Fact.Sunat.Business.Entity.DocumentoGuiaRemisionDetalle
        Try
            Dim comprobante = be

            Dim receptor = comprobante.CustomEntidad
            Dim numerovent As String = String.Format("{0:00000000}", comprobante.numeroDoc)
            Dim tipoDoc = String.Format("{0:00}", comprobante.tipoDoc)
            Dim conteo As Integer = 0
            '//Enviando el documento
            Dim Guia As New Fact.Sunat.Business.Entity.DocumentoGuiaRemision
            'Datos del Cliente 
            Guia.Action = 0
            Guia.idEmpresa = idPSE 'lblIdPse.Text
            Guia.Contribuyente_id = Gempresas.IdEmpresaRuc
            Guia.EnvioSunat = "NO"
            'Remitente de la guia
            Guia.NroDocumentoRem = receptor.nrodoc
            Guia.TipoDocumentoRem = receptor.tipoDoc
            Guia.NombreLegalRem = receptor.nombreCompleto
            'Destinatario de la guia
            Guia.NroDocumentoDest = comprobante.DocDestinatario
            Guia.TipoDocumentoDest = comprobante.TipoDocDestinatario
            Guia.NombreLegalDest = comprobante.nombreDestinatario
            'Datos Generales De La guia
            Guia.IdDocumento = comprobante.serie & "-" & numerovent
            Guia.FechaEmision = comprobante.fechaDoc
            Guia.FechaRecepcion = DateTime.Now 'fecha en la que se envia al PSE
            Guia.Moneda = "1"
            Guia.HoraEmision = comprobante.fechaDoc.Value.ToString("HH:mm:ss")
            Guia.TipoDocumento = tipoDoc
            Guia.TipoOperacion = "0101"
            Guia.glosa = comprobante.glosa

            Guia.ShipmentId = 1 '"001"
            Guia.CodigoMotivoTraslado = "01"
            Guia.DescripcionMotivo = comprobante.motivoTraslado
            Guia.Transbordo = 0
            Guia.PesoBrutoTotal = comprobante.PesoBruTotal
            Guia.NroPallets = 0
            Guia.ModalidadTraslado = "01"
            Guia.FechaInicioTraslado = DateTime.Now

            Guia.RucTransportista = comprobante.RucTrasporte
            Guia.RazonSocialTransportista = comprobante.razonSocialTrasportista
            Guia.NroPlacaVehiculo = comprobante.placaVehiculo
            Guia.NroDocumentoConductor = comprobante.NroDocumentoConductor


            Guia.UbigeoPartida = comprobante.puntoPartida
            Guia.DireccionCompletaPartida = comprobante.direccionPartida

            Guia.UbigeoLlegada = comprobante.puntoLlegada
            Guia.DireccionCompletaLlegada = comprobante.DireccionLlegada
            Guia.NumeroContenedor = String.Empty
            Guia.CodigoPuerto = String.Empty

            Guia.FechaRecepcion = DateTime.Now
            Guia.EnvioSunat = "NO"




            For Each i In comprobante.documentoguiaDetalle
                DetalleGuia = New Fact.Sunat.Business.Entity.DocumentoGuiaRemisionDetalle


                DetalleGuia.Id = conteo
                DetalleGuia.CodigoItem = i.idItem
                DetalleGuia.Descripcion = i.descripcionItem
                DetalleGuia.UnidadMedida = i.unidadMedida
                DetalleGuia.Cantidad = i.cantidad
                DetalleGuia.LineaReferencia = 1

                Guia.DocumentoGuiaRemisionDetalle.Add(DetalleGuia)
            Next
            'Enviando al PSE
            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoGuiaRemisionSA.DocumentoGuiaElectronicoSaveValidado(Guia, Nothing)

            If codigo.idGuia > 0 Then
                UpdateEnvioSunatEstado(comprobante.idDocumento, "SI")
                'MessageBox.Show("La Factura se Envio Correctamente al PSE")
            End If

        Catch ex As Exception

            'MessageBox.Show("No se Pudo Enviar")

        End Try


    End Sub

#End Region

#Region "Generate guia"
    Public doc As WordDocument
    Dim startPageIndex As Integer = 0
    Dim endPageIndex As Integer = 0
    Dim images As System.Drawing.Image()
    Public ReadOnly Property _formGuiaRemision8 As FormGuiaRemision8

    Public Sub ExecuteMail_Doc(guia As documento)

        Try
            doc = New WordDocument()
            '   Dim strPath As String = "D:\MyContract\reports\SalesInvoiceDemo2.doc"
            Dim strPath2 As String = "D:\HELIOSV8\reports\NameCompany.doc"
            Dim strPath3 As String = "D:\HELIOSV8\reports\NameCompany2.doc"
            'Dim strPath2 As String = "D:\Helios8\reports\Guia.doc"
            doc.Open(strPath2, FormatType.Doc)

            'Dim fieldCompany As String() = New String() {"NameCompany"}
            'Dim fieldCompanyValue As String() = New String() {Gempresas.NomEmpresa}
            Dim dt = GetTestOrder(guia)
            doc.MailMerge.ExecuteGroup(dt)
            doc.MailMerge.ExecuteGroup(GetDetalleGuia(guia.documentoGuia.documentoguiaDetalle.ToList()))
            doc.MailMerge.Execute(dt)

            'doc.MailMerge.ExecuteGroup(GetTestOrderTotals())
            'doc.MailMerge.ExecuteGroup(GetTestOrderCake())
            '   doc.MailMerge += New MergeFieldEventHandler(MailMerge_MergeField)

            doc.Save(strPath3)
            'System.Diagnostics.Process.Start(strPath3)

            '    GetPDF(strPath3)
            GetPDFConvet(strPath3)

        Catch Ex As Exception
            MessageBox.Show(Ex.Message)
        End Try
    End Sub

    Public Sub GeneratePDf_Transporte_Privado(guia As documento)

        Try
            doc = New WordDocument()
            '   Dim strPath As String = "D:\MyContract\reports\SalesInvoiceDemo2.doc"
            Dim strPath2 As String = "D:\HELIOSV8\reports\DocumentoGuiaPrivado.doc"
            Dim strPath3 As String = "D:\HELIOSV8\reports\DocumentoGuiaPrivada_generada.doc"
            'Dim strPath2 As String = "D:\Helios8\reports\Guia.doc"
            doc.Open(strPath2, FormatType.Doc)

            'Dim fieldCompany As String() = New String() {"NameCompany"}
            'Dim fieldCompanyValue As String() = New String() {Gempresas.NomEmpresa}
            Dim dt = GetTestOrderPrivado(guia)
            doc.MailMerge.ExecuteGroup(dt)
            doc.MailMerge.ExecuteGroup(GetDetalleGuia(guia.documentoGuia.documentoguiaDetalle.ToList()))

            'List Venhiculos
            doc.MailMerge.ExecuteGroup(GetDetalleVehiculos(guia.documentoGuia))

            'List Conductores
            doc.MailMerge.ExecuteGroup(GetDetalleConductores(guia.documentoGuia))

            doc.MailMerge.Execute(dt)

            'doc.MailMerge.ExecuteGroup(GetTestOrderTotals())
            'doc.MailMerge.ExecuteGroup(GetTestOrderCake())
            '   doc.MailMerge += New MergeFieldEventHandler(MailMerge_MergeField)

            doc.Save(strPath3)
            'System.Diagnostics.Process.Start(strPath3)

            '    GetPDF(strPath3)
            GetPDFConvet(strPath3)

        Catch Ex As Exception
            MessageBox.Show(Ex.Message)
        End Try
    End Sub

    Private Sub GetPDFConvet(path As String)
        Dim wordDoc = New WordDocument(path, Syncfusion.DocIO.FormatType.Automatic)
        wordDoc.ChartToImageConverter = New ChartToImageConverter()
        wordDoc.ChartToImageConverter.ScalingMode = Syncfusion.OfficeChart.ScalingMode.Normal

        Dim Converter = New DocToPDFConverter()
        '//Enable Direct PDF rendering mode for faster conversion.
        Converter.Settings.EnableFastRendering = False
        Converter.Settings.EmbedCompleteFonts = False
        Converter.Settings.EmbedFonts = False
        Converter.Settings.AutoTag = False
        Converter.Settings.PreserveFormFields = True
        Converter.Settings.ExportBookmarks = True

        Dim pdfDoc As PdfDocument = Converter.ConvertToPDF(wordDoc)
        '  //Save the pdf file
        Dim pathSave = "C:\archivos\documentoguia.pdf"
        'pdfDoc.Save("DoctoPDF.pdf")
        pdfDoc.Save(pathSave)
        PdfViewerControl1.Load(pathSave)
    End Sub

    Private Sub GetPDF(strPath3 As String)
        Dim doc2 = New WordDocument(strPath3)
        images = doc.RenderAsImages(ImageType.Metafile)
        endPageIndex = images.Length
        doc2.Close()

#Region "PrintSettings"
        'Create a PrintDialog
        Dim PrintDialog = New System.Windows.Forms.PrintDialog()
        '   // dialog.PrinterSetting
        PrintDialog.Document = New PrintDocument()
        '    //Set all Possible print ranges as true
        PrintDialog.AllowCurrentPage = True
        '   //printDialog.AllowSelection = true;
        PrintDialog.AllowSomePages = True
        '  //Set the start And end page index
        PrintDialog.PrinterSettings.FromPage = 1

        PrintDialog.PrinterSettings.ToPage = images.Length

#End Region

        If PrintDialog.ShowDialog = DialogResult.OK Then

            'Check if the Page Range exceeds the End page
            If PrintDialog.PrinterSettings.FromPage > 0 AndAlso PrintDialog.PrinterSettings.ToPage <= images.Length Then
                'Set the start page of the document to print
                startPageIndex = PrintDialog.PrinterSettings.FromPage - 1
                'Set the end page of the document to Print
                endPageIndex = PrintDialog.PrinterSettings.ToPage
                'Retrieve the Page need to be rendered
                PrintDialog.Document.Print()

                AddHandler PrintDialog.Document.PrintPage, AddressOf OnPrintPage


                '                    PrintDialog.Document.PrintPage += New PrintPageEventHandler(OnPrintPage)
                'Print the document
                PrintDialog.Document.Print()
            Else

                'If the Page range exceeds the 12
                'If MessageBox.Show("The page range is invalid" & Environment.NewLine & "Enter numbers between 1 and " + images.Length.ToString(), "Print Error", MessageBoxButtons.OK, MessageBoxIcon.[Error]) Is DialogResult.Yes Then
                'End If
            End If

            'Dispose the print dialog
            PrintDialog.Dispose()
            'Exit
            ' this.Close();
        End If
    End Sub

    Protected Overridable Sub OnPrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        'Current page width
        Dim currentPageWidth As Integer = images(startPageIndex).Width
        'Current page height
        Dim currentPageHeight As Integer = images(startPageIndex).Height
        'Visible clip bounds width
        Dim visibleClipBoundsWidth As Integer = CInt(e.Graphics.VisibleClipBounds.Width)
        'Visible clip bounds height
        Dim visibleClipBoundsHeight As Integer = CInt(e.Graphics.VisibleClipBounds.Height)

        'Check if the page layout is landscape or portrait
        If currentPageWidth > currentPageHeight Then
            'Translate the Position 
            e.Graphics.TranslateTransform(0, visibleClipBoundsHeight)
            'Rotates the object at 270 degrees
            e.Graphics.RotateTransform(270.0F)
            'Draw the current page
            e.Graphics.DrawImage(images(startPageIndex), New System.Drawing.Rectangle(0, 0, currentPageWidth, currentPageHeight))
        Else
            'Draw the current page
            e.Graphics.DrawImage(images(startPageIndex), New System.Drawing.Rectangle(0, 0, visibleClipBoundsWidth, visibleClipBoundsHeight))
        End If

        'Dispose the current page
        images(startPageIndex).Dispose()
        'Increment the start page index 
        startPageIndex += 1

        'check if the start page index is lesser than end page index
        If startPageIndex < endPageIndex Then
            e.HasMorePages = True 'if the document contain more than one pages
        Else
            startPageIndex = 0
        End If
    End Sub


    Private Sub MailMerge_MergeField(ByVal sender As Object, ByVal args As MergeFieldEventArgs)
        If args.RowIndex Mod 2 = 0 Then
            args.CharacterFormat.TextColor = Color.DarkBlue
        End If
    End Sub

    Private Function GetTestOrder(doc As documento) As DataTable
        Dim dt = New DataTable("Orders")
        dt.TableName = "Orders"
        dt.Columns.Add("NameCompany")
        dt.Columns.Add("idEmpresa")
        dt.Columns.Add("fecEmision")
        dt.Columns.Add("fecentregabien")
        dt.Columns.Add("motivo")
        dt.Columns.Add("modalidad")
        dt.Columns.Add("pesobruto")
        dt.Columns.Add("razonSocial") 'Destinatario
        dt.Columns.Add("razonSocialDoc") 'Destinatario
        dt.Columns.Add("numdocTrans") 'Transportista
        dt.Columns.Add("razonTrans") 'Transportista
        dt.Columns.Add("ubigeopartida")
        dt.Columns.Add("ubigeodestino")
        dt.Columns.Add("observaciones")
        dt.Columns.Add("nroguia")

        Dim dr As DataRow
        dr = dt.NewRow
        dr(0) = Gempresas.NomEmpresa
        dr(1) = Gempresas.IdEmpresaRuc
        dr(2) = doc.fechaProceso.ToShortDateString
        dr(3) = doc.documentoGuia.fechaTraslado
        dr(4) = doc.documentoGuia.motivoTraslado
        dr(5) = doc.documentoGuia.tipoVehiculo
        dr(6) = doc.documentoGuia.PesoBruTotal

        dr(7) = doc.documentoGuia.nombreDestinatario
        dr(8) = doc.documentoGuia.DocDestinatario

        dr(9) = doc.documentoGuia.nroDocTrasportista
        dr(10) = doc.documentoGuia.razonSocialTrasportista

        Dim partida = doc.documentoGuia.puntoPartida.Replace(_formGuiaRemision8._ucEmisionGuiaPaso3.comboDepartamento.SelectedValue + ",", "")
        partida = partida.Replace(_formGuiaRemision8._ucEmisionGuiaPaso3.comboProvincia.SelectedValue + ",", "")

        Dim llegada = doc.documentoGuia.puntoLlegada.Replace(_formGuiaRemision8._ucEmisionGuiaPaso3.comboDepartamentoLlegada.SelectedValue + ",", "")
        llegada = llegada.Replace(_formGuiaRemision8._ucEmisionGuiaPaso3.comboProvinciaLlegada.SelectedValue + ",", "")

        dr(11) = $"{partida}-{doc.documentoGuia.direccionPartida}"
        dr(12) = $"{llegada}-{doc.documentoGuia.DireccionLlegada}"
        dr(13) = doc.documentoGuia.ObserTrasPublico
        dr(14) = doc.nroDoc
        dt.Rows.Add(dr)

        Return dt
    End Function

    Private Function GetTestOrderPrivado(doc As documento) As DataTable
        Dim dt = New DataTable("Orders")
        dt.TableName = "Orders"
        dt.Columns.Add("NameCompany")
        dt.Columns.Add("idEmpresa")
        dt.Columns.Add("fecEmision")
        dt.Columns.Add("fecentregabien")
        dt.Columns.Add("motivo")
        dt.Columns.Add("modalidad")
        dt.Columns.Add("pesobruto")
        dt.Columns.Add("razonSocial") 'Destinatario
        dt.Columns.Add("razonSocialDoc") 'Destinatario
        dt.Columns.Add("numdocTrans") 'Transportista
        dt.Columns.Add("razonTrans") 'Transportista
        dt.Columns.Add("ubigeopartida")
        dt.Columns.Add("ubigeodestino")
        dt.Columns.Add("observaciones")
        dt.Columns.Add("nroguia")

        Dim dr As DataRow
        dr = dt.NewRow
        dr(0) = Gempresas.NomEmpresa
        dr(1) = Gempresas.IdEmpresaRuc
        dr(2) = doc.fechaProceso.ToShortDateString
        dr(3) = doc.documentoGuia.fechaTraslado
        dr(4) = doc.documentoGuia.motivoTraslado
        dr(5) = doc.documentoGuia.tipoVehiculo
        dr(6) = doc.documentoGuia.PesoBruTotal

        dr(7) = doc.documentoGuia.nombreDestinatario
        dr(8) = doc.documentoGuia.DocDestinatario

        dr(9) = "-" ' doc.documentoGuia.nroDocTrasportista
        dr(10) = "-" ' doc.documentoGuia.razonSocialTrasportista

        Dim partida = doc.documentoGuia.puntoPartida.Replace(_formGuiaRemision8._ucEmisionGuiaPaso3.comboDepartamento.SelectedValue + ",", "")
        partida = partida.Replace(_formGuiaRemision8._ucEmisionGuiaPaso3.comboProvincia.SelectedValue + ",", "")

        Dim llegada = doc.documentoGuia.puntoLlegada.Replace(_formGuiaRemision8._ucEmisionGuiaPaso3.comboDepartamentoLlegada.SelectedValue + ",", "")
        llegada = llegada.Replace(_formGuiaRemision8._ucEmisionGuiaPaso3.comboProvinciaLlegada.SelectedValue + ",", "")

        dr(11) = $"{partida}-{doc.documentoGuia.direccionPartida}"
        dr(12) = $"{llegada}-{doc.documentoGuia.DireccionLlegada}"
        dr(13) = doc.documentoGuia.ObserTrasPublico
        dr(14) = doc.nroDoc
        dt.Rows.Add(dr)

        Return dt
    End Function

    Private Function GetDetalleGuia(Lista As List(Of documentoguiaDetalle)) As DataTable
        Dim dt As New DataTable("Orderdetail")
        dt.TableName = "Orderdetail"
        dt.Columns.Add("nroItem")
        dt.Columns.Add("codigoBien")
        dt.Columns.Add("nombreItem")
        dt.Columns.Add("unidadItem")
        dt.Columns.Add("cantidadItem")

        Dim conteo As Integer = 1
        For Each i In Lista
            dt.Rows.Add(conteo, $"P-{i.idItem}", i.descripcionItem, i.unidadMedida, i.cantidad)
            conteo += 1
        Next
        Return dt
    End Function

    Private Function GetDetalleVehiculos(guia As documentoGuia) As DataTable
        Dim dt As New DataTable("Ordervehiculos")
        dt.TableName = "Ordervehiculos"
        dt.Columns.Add("nrovehiculo")
        dt.Columns.Add("nroplaca")
        Dim conteo As Integer = 1
        For Each i In guia.documentoGuiaProperties.Where(Function(o) o.tipo = "PLACA").ToList()
            dt.Rows.Add(conteo, $"PL-{i.property_value}")
            conteo += 1
        Next
        Return dt
    End Function

    Private Function GetDetalleConductores(guia As documentoGuia) As DataTable
        Dim dt As New DataTable("Orderconductores")
        dt.TableName = "Orderconductores"
        dt.Columns.Add("nroconductor")
        dt.Columns.Add("docConductor")
        dt.Columns.Add("numberDoc")
        Dim conteo As Integer = 1
        For Each i In guia.documentoGuiaProperties.Where(Function(o) o.tipo = "CONDUCTOR").ToList()
            dt.Rows.Add(conteo, i.property_value2, i.property_value)
            conteo += 1
        Next
        Return dt
    End Function

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        If CustomDocumento IsNot Nothing Then
            Select Case CustomDocumento.documentoGuia.tipoVehiculo
                Case "PUBLICO"
                    ExecuteMail_Doc(CustomDocumento)
                Case "PRIVADO"
                    GeneratePDf_Transporte_Privado(CustomDocumento)
            End Select

        End If
    End Sub

    Private Sub bunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles bunifuFlatButton7.Click
        Try
            If bunifuFlatButton7.Text = "SALIR" Then
                _formGuiaRemision8.Close()
            Else
                Dim GUIASA As New DocumentoGuiaSA
                If CustomDocumento IsNot Nothing Then
                    Dim docGuia = GUIASA.RegistrarGuiaRemision(CustomDocumento)



                    If My.Computer.Network.IsAvailable = True Then
                        If My.Computer.Network.Ping("138.128.171.106") Then
                            If Gempresas.ubigeo > 0 Then
                                Dim DocumentoGuiaSA As New DocumentoGuiaSA
                                Dim comprobante = DocumentoGuiaSA.GetVentaIDGuia(New documento With {.idDocumento = docGuia.idDocumento})
                                docGuia.documentoGuia = comprobante
                                EnvioGuiaDeGuiaRemision(comprobante, Gempresas.ubigeo)
                            End If
                        End If
                    Else
                        MessageBox.Show("Envío a Respositorio!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If


                    MessageBox.Show("Documento registrado con exito!", "Hecho!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'PdfViewerControl1 = Nothing
                    '    PdfViewerControl1.Unload()
                    ' PdfViewerControl1.Refresh()

                    BunifuFlatButton2.Enabled = True
                    BunifuFlatButton2.Visible = True

                    BunifuFlatButton3.Visible = False
                    BunifuFlatButton1.Visible = False
                    bunifuFlatButton7.Visible = True
                    bunifuFlatButton7.Text = "SALIR"
                    CustomDocumento.nroDoc = docGuia.nroDoc

                    CustomDocumento.documentoGuia.serie = docGuia.documentoGuia.serie
                    CustomDocumento.documentoGuia.numeroDoc = docGuia.documentoGuia.numeroDoc
                    CustomDocumento.documentoGuia.placaVehiculo = docGuia.documentoGuia.placaVehiculo
                    FormImpresionNuevo = New FormImpresionNuevo(CustomDocumento.documentoGuia)  ' frmVentaNuevoFormato

                    FormImpresionNuevo.StartPosition = FormStartPosition.CenterScreen

                    FormImpresionNuevo.ShowDialog(Me)

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        FormImpresionNuevo = New FormImpresionNuevo(CustomDocumento.documentoGuia)  ' frmVentaNuevoFormato

        FormImpresionNuevo.StartPosition = FormStartPosition.CenterScreen

        FormImpresionNuevo.ShowDialog(Me)
        ''If CustomDocumento IsNot Nothing Then
        ''    jjb
        ''    ExecuteMail_Doc(CustomDocumento)
        ''End If

        'If CustomDocumento IsNot Nothing Then
        '    Select Case CustomDocumento.documentoGuia.tipoVehiculo
        '        Case "PUBLICO"
        '            ExecuteMail_Doc(CustomDocumento)
        '        Case "PRIVADO"
        '            GeneratePDf_Transporte_Privado(CustomDocumento)
        '    End Select

        'End If



    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        _formGuiaRemision8.sliderTop.Left = (_formGuiaRemision8.BunifuFlatButton2).Left
        _formGuiaRemision8.sliderTop.Width = (_formGuiaRemision8.BunifuFlatButton2).Width

        _formGuiaRemision8._ucEmisionGuiaPaso1.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso2.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso3.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso5.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso4.Visible = True

        _formGuiaRemision8._ucEmisionGuiaPaso4.ComboTipoTransporte.Text = _formGuiaRemision8._ucEmisionGuiaPaso1.ComboTipoTransporte.Text
    End Sub

#End Region

End Class
