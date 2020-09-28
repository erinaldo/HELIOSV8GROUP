Imports Helios.Cont.Business.Entity
Imports Syncfusion.DocIO
Imports Syncfusion.DocIO.DLS
Imports Helios.General
Imports Syncfusion.OfficeChartToImageConverter
Imports Syncfusion.DocToPDFConverter
Imports Syncfusion.Pdf

Public Class FormReimpresionGuias
    Private doc As WordDocument

    Public Sub New(documentoGuia As documentoGuia)

        ' This call is required by the designer.
        InitializeComponent()
        _documentoGuia = documentoGuia

        ' Add any initialization after the InitializeComponent() call.
        Select Case documentoGuia.tipoVehiculo
            Case "PUBLICO"
                ImpresionGuiaPublica(_documentoGuia)
            Case "PRIVADO"
                GeneratePDf_Transporte_Privado(_documentoGuia)
        End Select
    End Sub

    Public ReadOnly Property _documentoGuia As documentoGuia

    Public Sub GeneratePDf_Transporte_Privado(guia As documentoGuia)

        Try
            doc = New WordDocument()
            '   Dim strPath As String = "D:\MyContract\reports\SalesInvoiceDemo2.doc"
            Dim strPath2 As String = "D:\Helios8\reports\DocumentoGuiaPrivado.doc"
            Dim strPath3 As String = "D:\Helios8\reports\DocumentoGuiaPrivada_generada.doc"
            'Dim strPath2 As String = "D:\Helios8\reports\Guia.doc"
            doc.Open(strPath2, FormatType.Doc)

            'Dim fieldCompany As String() = New String() {"NameCompany"}
            'Dim fieldCompanyValue As String() = New String() {Gempresas.NomEmpresa}
            Dim dt = GetTestOrderPrivado(guia)
            doc.MailMerge.ExecuteGroup(dt)
            doc.MailMerge.ExecuteGroup(GetDetalleGuia(guia.documentoguiaDetalle.ToList()))

            'List Venhiculos
            doc.MailMerge.ExecuteGroup(GetDetalleVehiculos(guia))

            'List Conductores
            doc.MailMerge.ExecuteGroup(GetDetalleConductores(guia))

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

    Private Function GetTestOrderPrivado(doc As documentoGuia) As DataTable
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
        dr(2) = doc.fechaDoc.GetValueOrDefault().ToShortDateString
        dr(3) = doc.fechaTraslado
        dr(4) = doc.motivoTraslado
        dr(5) = doc.tipoVehiculo
        dr(6) = doc.PesoBruTotal

        dr(7) = doc.nombreDestinatario
        dr(8) = doc.DocDestinatario

        dr(9) = "-" ' doc.documentoGuia.nroDocTrasportista
        dr(10) = "-" ' doc.documentoGuia.razonSocialTrasportista

        Dim PartidaSel As String = doc.puntoPartida
        Dim resultPartida() As String = Split(PartidaSel, ",")

        Dim partida = doc.puntoPartida.Replace(resultPartida(0) + ",", "")
        partida = partida.Replace(resultPartida(1) + ",", "")
        '----------------------------------------------------------------------------------------------------

        Dim LlegadaSel As String = doc.puntoLlegada
        Dim resultLlegada() As String = Split(LlegadaSel, ",")

        Dim llegada = doc.puntoLlegada.Replace(resultLlegada(0) + ",", "")
        llegada = llegada.Replace(resultLlegada(1) + ",", "")

        dr(11) = $"{partida}-{doc.direccionPartida}"
        dr(12) = $"{llegada}-{doc.DireccionLlegada}"
        dr(13) = doc.ObserTrasPublico
        dr(14) = $"{doc.serie}-{doc.numeroDoc}"
        dt.Rows.Add(dr)

        Return dt
    End Function

    Public Sub ImpresionGuiaPublica(guia As documentoGuia)

        Try
            doc = New WordDocument()
            '   Dim strPath As String = "D:\MyContract\reports\SalesInvoiceDemo2.doc"
            Dim strPath2 As String = "D:\Helios8\reports\NameCompany.doc"
            Dim strPath3 As String = "D:\Helios8\reports\NameCompany2.doc"
            'Dim strPath2 As String = "D:\Helios8\reports\Guia.doc"
            doc.Open(strPath2, FormatType.Doc)

            'Dim fieldCompany As String() = New String() {"NameCompany"}
            'Dim fieldCompanyValue As String() = New String() {Gempresas.NomEmpresa}
            Dim dt = GetTestOrder(guia)
            doc.MailMerge.ExecuteGroup(dt)
            doc.MailMerge.ExecuteGroup(GetDetalleGuia(guia.documentoguiaDetalle.ToList()))
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

    Private Function GetTestOrder(doc As documentoGuia) As DataTable
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
        dr(2) = doc.fechaDoc.GetValueOrDefault().ToShortDateString
        dr(3) = doc.fechaTraslado
        dr(4) = doc.motivoTraslado
        dr(5) = doc.tipoVehiculo
        dr(6) = doc.PesoBruTotal

        dr(7) = doc.nombreDestinatario
        dr(8) = doc.DocDestinatario

        dr(9) = doc.nroDocTrasportista
        dr(10) = doc.razonSocialTrasportista

        Dim PartidaSel As String = doc.puntoPartida
        Dim resultPartida() As String = Split(PartidaSel, ",")

        Dim partida = doc.puntoPartida.Replace(resultPartida(0) + ",", "")
        partida = partida.Replace(resultPartida(1) + ",", "")
        '----------------------------------------------------------------------------------------------------

        Dim LlegadaSel As String = doc.puntoLlegada
        Dim resultLlegada() As String = Split(LlegadaSel, ",")

        Dim llegada = doc.puntoLlegada.Replace(resultLlegada(0) + ",", "")
        llegada = llegada.Replace(resultLlegada(1) + ",", "")

        dr(11) = $"{partida}-{doc.direccionPartida}"
        dr(12) = $"{llegada}-{doc.DireccionLlegada}"
        dr(13) = doc.ObserTrasPublico
        dr(14) = $"{doc.serie}-{doc.numeroDoc}"
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
End Class