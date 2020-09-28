Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports OpenInvoicePeru.Comun.Dto.Intercambio
Imports OpenInvoicePeru.Comun.Dto.Modelos
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.IO
Imports System.Net
Imports System.Xml

Public Class FormImpresionEquivalencia
#Region "Attributes"

    Dim m_xmld As XmlDocument
    Dim m_nodelist As XmlNodeList
    Dim m_node As XmlNode


    Private VENTAsa As New documentoVentaAbarrotesSA
    Dim instance As New Printing.PrinterSettings
    Dim impresosaPredt As String = instance.PrinterName
    Public QR As String
    Public HASH As String
    Public CERTIFICADO As String
    Public DocumentoID As Integer
    Private documentoBE As New documento
    Public objDatosGenrales As New datosGenerales
    Private Const FormatoFecha As String = "yyyy-MM-dd"
    Dim listaDatos As New List(Of datosGenerales)
    Public Property tienda As String = String.Empty
    Public Property FormaPago As String = String.Empty
    Public Property TIPOiMPESION As Integer
    Public Property Email As String

    Public Property tipoComprobante As String

    Dim documentoventaSA As New documentoVentaAbarrotesSA

    Dim listaDocumento As New List(Of documentoventaAbarrotes)

    Dim listaDocumentodET As New List(Of documentoventaAbarrotesDet)

    Public Property ListaproductosVendidos As New List(Of documentoventaAbarrotesDet)

    Public nombremesa As String = String.Empty
    Public Property FechaPedido As DateTime

    Public Property COSTO As String
    Public Property VUELTO As String
    Public Property RECIBIDO As String

    Public Property LLAMARENTIDAD As New entidad

    Public Property LLAMARTRANSPORTE As New documentoventaTransporte

    Dim WithEvents CLIENTE As New WebClient 'LO DECLARAMOS CON EVENTS PARA PODER UTILIZAR LOS PROCEDIMIENTOS PROGRESSCHANGED Y COMPLETED
    Dim WithEvents CDR As New WebClient

    Public Property fileName As String = String.Empty

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.KeyPreview = True
        FormatoGridBlack(gridGroupingControl1, False)
        gridGroupingControl1.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell

        CargarDatos()

        ChecDomicilio.Checked = True

    End Sub

    Public Sub New(ID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.KeyPreview = True
        FormatoGridBlack(gridGroupingControl1, False)
        gridGroupingControl1.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell

        CargarDatos()


        Dim venta = VENTAsa.GetVentaID(New documento With {.idDocumento = ID})
        documentoBE = New documento With {.idDocumento = ID}
        documentoBE.documentoventaAbarrotes = venta
        CargarDomiciliosCliente(venta.CustomEntidad.entidadAtributos.ToList)
        listaDocumento = documentoventaSA.CobrosxDocumentoImpresion(ID)

        Select Case documentoBE.documentoventaAbarrotes.CustomEntidad.tipoEntidad
            Case "VR"
                ChecDomicilio.Enabled = False
                ChecDomicilio.Checked = True
                Button1.Enabled = False
                Button2.Enabled = False
                gridGroupingControl1.Visible = False
            Case Else
                ChecDomicilio.Enabled = True
                Button1.Enabled = True
                Button2.Enabled = True
                gridGroupingControl1.Visible = True

                If documentoBE.documentoventaAbarrotes.CustomEntidad.tipoDoc = "1" Then ' DNI
                    ChecDomicilio.Checked = True
                ElseIf documentoBE.documentoventaAbarrotes.CustomEntidad.tipoDoc = "6" Then ' RUC
                    ChecDomicilio.Checked = False
                Else
                    ChecDomicilio.Enabled = False
                End If

        End Select

        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)

        'C:\CLIENTES\10408199358\FACTURAS
        CLIENTE.DownloadFileAsync(New Uri("http://138.128.171.106/" & "XML" & "/" & Gempresas.IdEmpresaRuc & "/FACTURAS/" & fileName & ".xml"), "C:\FACTURASELECTRONICAS\PDF\" & fileName & ".xml")

        CDR.DownloadFileAsync(New Uri("http://138.128.171.106/" & "XML" & "/" & Gempresas.IdEmpresaRuc & "/FACTURAS/R" & fileName & ".zip"), "C:\FACTURASELECTRONICAS\PDF\" & fileName & ".zip")


    End Sub


    Public Sub New(doc As documento)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridBlack(gridGroupingControl1, False)
        gridGroupingControl1.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        CargarDatos()
        CargarDomiciliosCliente(doc.documentoventaAbarrotes.CustomEntidad.entidadAtributos.ToList)
        documentoBE = doc

        Select Case documentoBE.documentoventaAbarrotes.CustomEntidad.tipoEntidad
            Case "VR"
                ChecDomicilio.Enabled = False
                ChecDomicilio.Checked = True
                Button1.Enabled = False
                Button2.Enabled = False
                gridGroupingControl1.Visible = False
            Case Else
                ChecDomicilio.Enabled = True
                Button1.Enabled = True
                Button2.Enabled = True
                gridGroupingControl1.Visible = True

                If documentoBE.documentoventaAbarrotes.CustomEntidad.tipoDoc = "1" Then ' DNI
                    ChecDomicilio.Checked = True
                ElseIf documentoBE.documentoventaAbarrotes.CustomEntidad.tipoDoc = "6" Then ' RUC
                    ChecDomicilio.Checked = False
                Else
                    ChecDomicilio.Enabled = False
                End If

        End Select

        Me.KeyPreview = True
    End Sub

    Public Sub New(DOCUMENTO As List(Of documentoventaAbarrotesDet), TIPO As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.KeyPreview = True
        FormatoGridBlack(gridGroupingControl1, False)
        gridGroupingControl1.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell

        CargarDatos()

        ChecDomicilio.Checked = True
        listaDocumentodET = DOCUMENTO

    End Sub

#End Region


    Sub ValidarRucXML()
        'Creamos el "Document"
        m_xmld = New XmlDocument()

        'Cargamos el archivo
        m_xmld.Load("C:\SPKconfiguration.xml")

        'Obtenemos la lista de los nodos "name"
        m_nodelist = m_xmld.SelectNodes("/spk/impresion")

        'Iniciamos el ciclo de lectura
        For Each m_node In m_nodelist
            'Obtenemos el Elemento RUC
            Dim mNombre = m_node.ChildNodes.Item(0).InnerText
            If mNombre.ToString.Trim.Length > 0 Then
                GImpresion.ImpresoraPDF = mNombre
            End If
        Next

    End Sub

#Region "Methods"
    Private Sub CargarDomiciliosCliente(ListaDomicilios As List(Of entidadAtributos))
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("domicilios")

        For Each i In ListaDomicilios
            dt.Rows.Add(i.idAtributo, i.valorAtributo)
        Next

        gridGroupingControl1.DataSource = dt
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.F2
                btnImprimir.PerformClick()

            Case Keys.F3
                btnCorreo.PerformClick()

            Case Keys.F4
                btnPdf.PerformClick()
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

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

    Function CrearEmisor() As Compania
        Dim Emisor As New Compania

        Emisor.NroDocumento = Gempresas.IdEmpresaRuc '"20603127278"
        Emisor.TipoDocumento = "6"
        Emisor.NombreComercial = Gempresas.NomEmpresa '"INVERSIONES SEÑOR DE ACORIA S.A.C."
        Emisor.NombreLegal = Gempresas.NomEmpresa '"INVERSIONES SEÑOR DE ACORIA S.A.C."
        Emisor.CodigoAnexo = "0001"

        Return Emisor

    End Function

    Private Sub cargarDatos(idConfiguracion As Integer)
        Try
            '     Dim datosGeneralesSA As New datosGeneralesSA

            objDatosGenrales = listaDatos.Where(Function(o) o.idConfiguracion = idConfiguracion).SingleOrDefault '  datosGeneralesSA.UbicaEmpresaID(idConfiguracion)
            If (Not IsNothing(objDatosGenrales)) Then
                If (objDatosGenrales.NombreFormato = "A4") Then
                    txtFormato.Text = "A4"
                ElseIf (objDatosGenrales.NombreFormato = "TK") Then
                    txtFormato.Text = "TICKET"
                ElseIf (objDatosGenrales.NombreFormato = "A5") Then
                    txtFormato.Text = "A5"
                End If
                If (Not IsNothing(objDatosGenrales.nroImpresion)) Then
                    txtNroImpresion.DecimalValue = objDatosGenrales.nroImpresion
                Else
                    txtNroImpresion.DecimalValue = 0
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub ImprimirTicket(imprimir As String, intIdDocumento As Integer, formato As String, tipoImpresion As String)
        Dim fileName As String = String.Empty
        Select Case formato
            Case "1"
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
                Dim nombreCliente As String
                Dim rucCliente As String = String.Empty
                Dim tipocomprobante As String = String.Empty

                If (objDatosGenrales.logo.Length > 0) Then
                    ' Logo de la Empresa
                    a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
                End If

                If (objDatosGenrales.nombreImpresion = "C") Then
                    a.tipoImagen = False
                ElseIf (objDatosGenrales.nombreImpresion = "R") Then
                    a.tipoImagen = True
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
                If (objDatosGenrales.telefono3.Length > 0) Then
                    a.TextoIzquierda("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3)
                ElseIf (objDatosGenrales.telefono2.Length > 0) Then
                    a.TextoIzquierda("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
                Else
                    a.TextoIzquierda("TELF: " & objDatosGenrales.telefono1)
                End If

                Dim nombreComprador As String = String.Empty
                'If documentoBE.documentoventaAbarrotes.idCliente <> 0 Then

                Dim NBoletaElectronica As String = Nothing
                Dim DIRECCIONclIENTE As String = String.Empty
                'If documentoBE.documentoventaAbarrotes.idCliente <> 0 Then
                Dim entidad = documentoBE.documentoventaAbarrotes.CustomEntidad  'entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault

                Select Case entidad.tipoEntidad
                    Case "VR"
                        NBoletaElectronica = documentoBE.documentoventaAbarrotes.nombrePedido
                    Case Else
                        NBoletaElectronica = entidad.nombreCompleto
                End Select


                'DIRECCIONclIENTE = entidad.DireccionSeleccionada ' entidad.direccion
                If (ChecDomicilio.Checked = False) Then
                    entidad.direccion = documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada
                    DIRECCIONclIENTE = entidad.direccion
                Else
                    DIRECCIONclIENTE = entidad.direccion ' entidad.direccion
                End If
                nombreCliente = (NBoletaElectronica)

                Select Case entidad.tipoEntidad
                    Case "VR"
                        rucCliente = "-"
                    Case Else
                        If (Not IsNothing(entidad.nrodoc)) Then
                            If entidad.nrodoc.Trim.Length = 11 Then
                                rucCliente = "R.U.C. - " & entidad.nrodoc
                            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                                rucCliente = "D.N.I. - " & entidad.nrodoc
                            Else
                                rucCliente = ("NRO DOC.: " & entidad.nrodoc)
                            End If
                        Else
                            rucCliente = "-"
                        End If
                End Select

                'Codigo qr

                If (Not IsNothing(HASH)) Then
                    If HASH.Trim.Length > 0 Then
                        QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                          "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
                          "|" & HASH & "|" & CERTIFICADO)

                        QrCodeImgControl1.Text = QR
                    Else
                        QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                         "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                        QrCodeImgControl1.Text = QR
                    End If
                End If

                QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                       "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                QrCodeImgControl1.Text = QR

                'QrCodeImgControl1.Image

                'Else
                '    Dim NBoletaElectronica As String = documentoBE.documentoventaAbarrotes.nombrePedido
                '    nombreCliente = (NBoletaElectronica)

                '    'Codigo qr
                '    QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                '              "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & "VARIOS" & "|" & "0")

                '    QrCodeImgControl1.Text = QR

                'End If

                Select Case documentoBE.documentoventaAbarrotes.tipoDocumento
                    Case "12.1"
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET BOLETA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, documentoBE.documentoventaAbarrotes.nombrePedido, "", rucCliente, "NAC", "966557413")
                        a.tipoComprobante = 1
                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    Case "12.2"
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET FACTURA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, documentoBE.documentoventaAbarrotes.nombrePedido, "", rucCliente, "NAC", "966557413")
                        a.tipoComprobante = 1
                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    Case "03"
                        If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA ELECTRONICA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, nombreComprador, "", rucCliente, "NAC", "966557413")
                            a.tipoComprobante = 2
                            fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                        ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA   N° " & CStr(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, "0"c) & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, nombreComprador, "", rucCliente, "NAC", "966557413")
                            a.tipoComprobante = 1
                            fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                        End If
                    Case "01"
                        If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA ELECTRONICA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, nombreComprador, "", rucCliente, "NAC", "966557413")
                            a.tipoComprobante = 2
                            fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                        ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA   N° " & CStr(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, "0"c) & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, nombreComprador, "", rucCliente, "NAC", "966557413")
                            a.tipoComprobante = 1
                            fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                        End If
                    Case "9903" '"9901"
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "COTIZACIÓN   N° " & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, documentoBE.documentoventaAbarrotes.nombrePedido, "", rucCliente, "NAC", "966557413")
                        a.tipoComprobante = 1
                        fileName = Gempresas.IdEmpresaRuc & "-" & GEstableciento.IdEstablecimiento & "-" & "TICKET COTIZACIÓN" & "-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    Case "07"
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "NOTA DE CREDITO ELECTRONICA N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, documentoBE.documentoventaAbarrotes.nombrePedido, "", rucCliente, "NAC", "966557413")
                        a.tipoComprobante = 2
                        fileName = Gempresas.IdEmpresaRuc & "-" & GEstableciento.IdEstablecimiento & "-" & "NOTA DE CREDITO ELECTRONICA" & "-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    Case Else
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET NOTA   N° " & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, documentoBE.documentoventaAbarrotes.nombrePedido, "", rucCliente, "NAC", "966557413")
                        a.tipoComprobante = 1
                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                End Select

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

                    precioUnit = (Math.Round(CDbl(i.importeMN / i.monto1), 2))
                    PrecioTotal = i.importeMN

                    If (Not IsNothing(i.CustomEquivalencia)) Then
                        a.AnadirLineaElementosFactura(i.monto1, $"{i.nombreItem} {i.detalleAdicional}({i.CustomEquivalencia.unidadComercial})", "", String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                    Else
                        a.AnadirLineaElementosFactura(i.monto1, $"{i.nombreItem} {i.detalleAdicional}", i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                    End If

                    'a.AnadirElemento(i.monto1, i.CustomEquivalencia.unidadComercial, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal), i.nombreItem)
                    'a.AnadirNombreElemento(i.nombreItem)
                Next


                a.AnadirDatosGenerales("S/", ExoMN)
                a.AnadirDatosGenerales("S/", InaMN)
                a.AnadirDatosGenerales("S/", gravMN)
                a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.igv01.GetValueOrDefault)
                a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.icbper.GetValueOrDefault)
                a.AnadirDatosGenerales("S/", String.Format("{0:0.00}", documentoBE.documentoventaAbarrotes.ImporteNacional.GetValueOrDefault))

                a.headerImagenQR = QrCodeImgControl1.Image

                Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = documentoBE.documentoventaAbarrotes.usuarioActualizacion).FirstOrDefault

                a.AnadirLineaDatos("Vendedor: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno, "Representacion impresa", "http://facturador.softpack.com.pe/")

                '//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
                '//parametro de tipo string que debe de ser el nombre de la impresora. 
                'a.ImprimeTicket(imprimir, txtNroImpresion.DecimalValue)

                If (tipoImpresion = "PDF") Then

                    Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)
                    If (fileUbicacion.Length > 0) Then

                        Dim myProcess As New Process
                        Dim PathShell As String = fileUbicacion

                        myProcess.StartInfo.FileName = PathShell
                        myProcess.StartInfo.UseShellExecute = True
                        myProcess.StartInfo.RedirectStandardOutput = False
                        myProcess.Start()
                        myProcess.Dispose()

                    Else
                        MessageBox.Show("VERIFICAR DOCUMENTO A ENVIAR")
                    End If

                ElseIf (tipoImpresion = "GUARDAR") Then
                    a.ImprimeTicket(imprimir, 1)

                ElseIf (tipoImpresion = "DIRECTO") Then
                    a.ImprimeTicket(imprimir, txtNroImpresion.DecimalValue)
                End If

'// case 333333333333333333333
            Case "2"
                Dim documentoSA As New documentoVentaAbarrotesSA
                Dim documentoDetSA As New documentoVentaAbarrotesDetSA
                Dim a As TicketForGrandev4 = New TicketForGrandev4
                'a.HeaderImage = "C:\Documents and Settings\Administrador\Mis documentos\COMPU.jpg" 
                Dim gravMN As Decimal = 0
                Dim gravME As Decimal = 0
                Dim ExoMN As Decimal = 0
                Dim ExoME As Decimal = 0
                Dim InaMN As Decimal = 0
                Dim InaME As Decimal = 0
                Dim precioUnit As Decimal = 0
                Dim PrecioTotal As Decimal = 0

                Dim nombreCliente As String
                Dim rucCliente As String = String.Empty
                Dim importeTotalMN As Decimal
                Dim importeSumMN As Decimal
                'Dim comprobante = documentoSA.GetUbicar_NotaXID(intIdDocumento)
                'Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)

                If (objDatosGenrales.logo.Length > 0) Then
                    ' Logo de la Empresa
                    a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
                End If

                If (objDatosGenrales.nombreImpresion = "C") Then
                    a.tipoImagen = False
                ElseIf (objDatosGenrales.nombreImpresion = "R") Then
                    a.tipoImagen = True
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
                a.TextoIzquierda(objDatosGenrales.direccionPrincipal)
                a.TextoIzquierda(objDatosGenrales.direccionSecudaria)
                'Telefono de la empresa
                If (objDatosGenrales.telefono3.Length > 0) Then
                    a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3)
                ElseIf (objDatosGenrales.telefono2.Length > 0) Then
                    a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
                Else
                    a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1)
                End If


                Dim DIRECCIONclIENTE As String = String.Empty
                Dim NBoletaElectronica As String = String.Empty
                'If documentoBE.documentoventaAbarrotes.idCliente <> 0 Then
                Dim entidad = documentoBE.documentoventaAbarrotes.CustomEntidad  'entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault

                Select Case entidad.tipoEntidad
                    Case "VR"
                        NBoletaElectronica = documentoBE.documentoventaAbarrotes.nombrePedido
                    Case Else
                        NBoletaElectronica = entidad.nombreCompleto
                End Select


                If (ChecDomicilio.Checked = False) Then
                    entidad.direccion = documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada
                    DIRECCIONclIENTE = entidad.direccion
                Else
                    DIRECCIONclIENTE = entidad.direccion ' entidad.direccion
                End If
                nombreCliente = (NBoletaElectronica)

                Select Case entidad.tipoEntidad
                    Case "VR"
                        rucCliente = "-"
                    Case Else
                        If (Not IsNothing(entidad.nrodoc)) Then
                            If entidad.nrodoc.Trim.Length = 11 Then
                                rucCliente = "R.U.C. - " & entidad.nrodoc
                            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                                rucCliente = "D.N.I. - " & entidad.nrodoc
                            Else
                                rucCliente = ("NRO DOC.: " & entidad.nrodoc)
                            End If
                        Else
                            rucCliente = "-"
                        End If
                End Select

                'Codigo qr

                If (Not IsNothing(HASH)) Then
                    If HASH.Trim.Length > 0 Then
                        QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                                  "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
                                  "|" & HASH & "|" & CERTIFICADO)

                        QrCodeImgControl1.Text = QR
                    Else
                        QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                                 "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                        QrCodeImgControl1.Text = QR
                    End If
                End If

                QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                               "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                QrCodeImgControl1.Text = QR

                'QrCodeImgControl1.Image

                'Else
                '    Dim NBoletaElectronica As String = documentoBE.documentoventaAbarrotes.nombrePedido
                '    nombreCliente = (NBoletaElectronica)

                '    'Codigo qr
                '    QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                '              "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & "VARIOS" & "|" & "0")

                '    QrCodeImgControl1.Text = QR

                'End If

                Select Case documentoBE.documentoventaAbarrotes.tipoDocumento
                    Case "12.1"
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET BOLETA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                        a.tipoComprobante = 1
                        a.AnadirLineaComprobante("TICKET BOLETA")
                        a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    Case "12.2"
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET FACTURA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                        a.tipoComprobante = 1
                        a.AnadirLineaComprobante("TICKET FACTURA")
                        a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    Case "03"
                        If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA DE VENTA ELECTRONICA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                            a.tipoComprobante = 2
                            a.AnadirLineaComprobante("BOLETA DE VENTA ELECTRONICA")
                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c))

                            Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = documentoBE.documentoventaAbarrotes.usuarioActualizacion).FirstOrDefault

                            If Not IsNothing(consultaNombre) Then
                                a.AnadirLineasDatosFinales("VENDEDOR: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)
                            Else
                                a.AnadirLineasDatosFinales("VENDEDOR: " & "VARIOS")
                            End If


                            a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE")
                            a.AnadirLineasDatosFinales("VENTA ELECTRONICA")
                            a.AnadirLineasDatosFinales("http://www.spk.com.pe")
                            a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia")
                            a.AnadirLineasDatosFinales("034-005-0010982")

                            a.AnadirLineasDatosFinales("")

                            'a.AnadirLineasDatosFinales("SIETE (7) DIAS DESPUES DE LA COMPRA")
                            'a.AnadirLineasDatosFinales("PRESENTAR TICKET ORIGINAL")
                            'a.AnadirLineasDatosFinales("maych_1@hotmail.com")
                            'a.AnadirLineasDatosFinales("TELEFONO DE ATENCION AL CLIENTE")
                            'a.AnadirLineasDatosFinales("(01)-12345678")
                            a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA")

                            fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                        ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA   N° " & CStr(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, "0"c) & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                            a.tipoComprobante = 1
                            a.AnadirLineaComprobante("BOLETA")
                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                            fileName = Gempresas.IdEmpresaRuc & "-" & GEstableciento.IdEstablecimiento & "-" & "TICKET BOLETA" & "-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                        End If
                    Case "01"
                        If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA ELECTRONICA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                            a.tipoComprobante = 2
                            a.AnadirLineaComprobante("FACTURA ELECTRONICA")
                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c))

                            Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = documentoBE.documentoventaAbarrotes.usuarioActualizacion).FirstOrDefault

                            If Not IsNothing(consultaNombre) Then
                                a.AnadirLineasDatosFinales("VENDEDOR: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)
                            Else
                                a.AnadirLineasDatosFinales("VENDEDOR: " & "VARIOS")
                            End If

                            a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE")
                            a.AnadirLineasDatosFinales("VENTA ELECTRONICA")
                            a.AnadirLineasDatosFinales("http://www.spk.com.pe")
                            a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia")
                            a.AnadirLineasDatosFinales("034-005-0010982")

                            a.AnadirLineasDatosFinales("")

                            'a.AnadirLineasDatosFinales("CUALQUIER CAMBIO O DEVOLUCION SERA HASTA")
                            'a.AnadirLineasDatosFinales("SIETE (7) DIAS DESPUES DE LA COMPRA")
                            'a.AnadirLineasDatosFinales("PRESENTAR TICKET ORIGINAL")
                            'a.AnadirLineasDatosFinales("maych_1@hotmail.com")
                            'a.AnadirLineasDatosFinales("TELEFONO DE ATENCION AL CLIENTE")
                            'a.AnadirLineasDatosFinales("(01)-12345678")
                            a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA")


                            fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                        ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA   N° " & CStr(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, "0"c) & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                            a.tipoComprobante = 1
                            a.AnadirLineaComprobante("FACTURA")
                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                            fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                        End If
                    Case "9901"
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "COTIZACIÓN   N° " & 0, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                        a.AnadirLineaComprobante("COTIZACIÓN")
                        a.AnadirLineaComprobante(0 & "-" & 0)
                        a.tipoComprobante = 1
                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    Case "07"

                        Dim tipoEmision As String = String.Empty

                        'Select Case comprobante.estadoCobro
                        '    Case "DC"
                        '        tipoVenta = "CONTADO"
                        '    Case "PN"
                        '        tipoVenta = "CREDITO"
                        'End Select

                        Select Case documentoBE.documentoventaAbarrotes.notaCredito
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
                        Select Case documentoBE.documentoventaAbarrotes.TipoDocNota
                            Case "01"
                                NombreComprobante = "FACTURA ELECTRONICA"
                            Case "02"
                                NombreComprobante = "BOLETA ELECTRONICA"
                        End Select

                        'Dim numeroafect As String = String.Format("{0:00000000}", comprobante.numeroDoc)

                        a.AnadirLineaCaracteresDatosGEnerales(documentoBE.documentoventaAbarrotes.fechaDoc,
                                                              "",
                                                              nombreCliente,
                                                              DIRECCIONclIENTE,
                                                              documentoBE.documentoventaAbarrotes.fechaDoc,
                                                              rucCliente,
                                                              "NAC",
                                                             tipoEmision)
                        a.tipoComprobante = 2
                        a.AnadirLineaComprobante("NOTA DE CREDITO ELECTRONICA")
                        a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c))

                        Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = documentoBE.documentoventaAbarrotes.usuarioActualizacion).FirstOrDefault

                        If Not IsNothing(consultaNombre) Then
                            a.AnadirLineasDatosFinales("VENDEDOR: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)
                        Else
                            a.AnadirLineasDatosFinales("VENDEDOR: " & "VARIOS")
                        End If
                        a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE")
                        a.AnadirLineasDatosFinales("VENTA ELECTRONICA")
                        a.AnadirLineasDatosFinales("http://www.spk.com.pe")
                        a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia")
                        a.AnadirLineasDatosFinales("034-005-0010982")
                        a.AnadirLineasDatosFinales("")
                        a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA")


                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    Case Else
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET NOTA   N° " & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                        a.tipoComprobante = 1
                        a.AnadirLineaComprobante("NOTA")
                        a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                        fileName = Gempresas.IdEmpresaRuc & "-" & GEstableciento.IdEstablecimiento & "-" & "TICKET NOTA" & "-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                End Select

                For Each i In documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList

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

                    If (Not IsNothing(i.CustomEquivalencia)) Then
                        a.AnadirLineaElementosFactura(i.monto1, $"{i.nombreItem} {i.detalleAdicional} ({i.CustomEquivalencia.unidadComercial})", i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", i.descuentoMN.GetValueOrDefault), String.Format("{0:0.00}", PrecioTotal))
                    Else
                        a.AnadirLineaElementosFactura(i.monto1, $"{i.nombreItem} {i.detalleAdicional}", i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", i.descuentoMN.GetValueOrDefault), String.Format("{0:0.00}", PrecioTotal))
                    End If

                    'a.AnadirElemento(i.monto1, i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal), i.nombreItem)
                    'a.AnadirNombreElemento(i.nombreItem)
                    importeTotalMN += i.importeMN
                Next

                a.AnadirDatosGenerales("S/", ExoMN)
                a.AnadirDatosGenerales("S/", InaMN)
                a.AnadirDatosGenerales("S/", gravMN)
                a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.igv01.GetValueOrDefault)
                a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.icbper.GetValueOrDefault)
                a.AnadirDatosGenerales("S/", String.Format("{0:0.00}", documentoBE.documentoventaAbarrotes.ImporteNacional.GetValueOrDefault))

                'a.AnadirDatosGenerales("S/",  )
                'a.AnadirDatosGenerales("S/", )

                a.AnadirLineasDatosDescripcionTotal(documentoBE.documentoventaAbarrotes.ImporteNacional)

                If (Not IsNothing(documentoBE.ListaCustomDocumento)) Then
                    For Each item In documentoBE.ListaCustomDocumento.ToList
                        a.AnadirLineasDescuento(item.documentoCaja.formaPagoName & ": " & item.documentoCaja.montoSoles)
                        importeSumMN += item.documentoCaja.montoSoles
                    Next

                    'a.AnadirLineasDescuento("PENDIENTE: " & importeTotalMN - importeSumMN)

                Else
                    For Each item In listaDocumento
                        Dim formasPago = Helios.General.TablasGenerales.GetFormasDePago()
                        Dim formaSel = formasPago.Where(Function(o) o.codigoDetalle = item.sustentado).SingleOrDefault

                        'a.AnadirLineasDescuento(item.NombreEntidad & ": " & item.ImporteNacional & "     " & " N°" & item.NroDocEntidad & "  OPER." & item.numeroVenta)
                        a.AnadirLineasDescuento(formaSel.descripcion & ": " & item.ImporteNacional)
                        importeSumMN += item.ImporteNacional

                    Next

                    'a.AnadirLineasDescuento("PENDIENTE: " & importeTotalMN - importeSumMN)
                End If

                a.headerImagenQR = QrCodeImgControl1.Image

                'a.AnadirLineaDatos("Vendedor: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno, "Representacion impresa del comprobante", "http://www.spk.com.pe")
                '//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
                '//parametro de tipo string que debe de ser el nombre de la impresora. 
                If (tipoImpresion = "PDF") Then

                    Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)
                    If (fileUbicacion.Length > 0) Then

                        Dim myProcess As New Process
                        Dim PathShell As String = fileUbicacion

                        myProcess.StartInfo.FileName = PathShell
                        myProcess.StartInfo.UseShellExecute = True
                        myProcess.StartInfo.RedirectStandardOutput = False
                        myProcess.Start()
                        myProcess.Dispose()

                    Else
                        MessageBox.Show("VERIFICAR DOCUMENTO A ENVIAR")
                    End If

                ElseIf (tipoImpresion = "GUARDAR") Then
                    'Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)
                    a.ImprimeTicket(imprimir, 1)
                ElseIf (tipoImpresion = "DIRECTO") Then
                    a.tipoComprobante = "2"
                    a.ImprimeTicket(imprimir, txtNroImpresion.DecimalValue)
                End If


            Case "3"
                Dim documentoSA As New documentoVentaAbarrotesSA
                Dim documentoDetSA As New documentoVentaAbarrotesDetSA
                Dim a As TicketForGrandev5 = New TicketForGrandev5
                'a.HeaderImage = "C:\Documents and Settings\Administrador\Mis documentos\COMPU.jpg" 
                Dim gravMN As Decimal = 0
                Dim gravME As Decimal = 0
                Dim ExoMN As Decimal = 0
                Dim ExoME As Decimal = 0
                Dim InaMN As Decimal = 0
                Dim InaME As Decimal = 0
                Dim precioUnit As Decimal = 0
                Dim PrecioTotal As Decimal = 0

                Dim nombreCliente As String
                Dim rucCliente As String = String.Empty
                Dim importeTotalMN As Decimal
                Dim importeSumMN As Decimal
                'Dim comprobante = documentoSA.GetUbicar_NotaXID(intIdDocumento)
                'Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)


                If (objDatosGenrales.logo.Length > 0) Then
                    ' Logo de la Empresa
                    a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
                End If

                If (objDatosGenrales.nombreImpresion = "C") Then
                    a.tipoImagen = False
                ElseIf (objDatosGenrales.nombreImpresion = "R") Then
                    a.tipoImagen = True
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
                a.TextoIzquierda(objDatosGenrales.direccionPrincipal)
                a.TextoIzquierda(objDatosGenrales.direccionSecudaria)
                'Telefono de la empresa
                If (objDatosGenrales.telefono3.Length > 0) Then
                    a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3)
                ElseIf (objDatosGenrales.telefono2.Length > 0) Then
                    a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
                Else
                    a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1)
                End If


                Dim DIRECCIONclIENTE As String = String.Empty
                Dim NBoletaElectronica As String = String.Empty
                'If documentoBE.documentoventaAbarrotes.idCliente <> 0 Then
                Dim entidad = documentoBE.documentoventaAbarrotes.CustomEntidad  'entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault

                Select Case entidad.tipoEntidad
                    Case "VR"
                        NBoletaElectronica = documentoBE.documentoventaAbarrotes.nombrePedido
                    Case Else
                        NBoletaElectronica = entidad.nombreCompleto
                End Select


                'DIRECCIONclIENTE = entidad.DireccionSeleccionada ' entidad.direccion
                If (ChecDomicilio.Checked = False) Then
                    entidad.direccion = documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada
                    DIRECCIONclIENTE = entidad.direccion
                Else
                    DIRECCIONclIENTE = entidad.direccion ' entidad.direccion
                End If
                nombreCliente = (NBoletaElectronica)

                Select Case entidad.tipoEntidad
                    Case "VR"
                        rucCliente = "-"
                    Case Else
                        If (Not IsNothing(entidad.nrodoc)) Then
                            If entidad.nrodoc.Trim.Length = 11 Then
                                rucCliente = "R.U.C. - " & entidad.nrodoc
                            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                                rucCliente = "D.N.I. - " & entidad.nrodoc
                            Else
                                rucCliente = ("NRO DOC.: " & entidad.nrodoc)
                            End If
                        Else
                            rucCliente = "-"
                        End If
                End Select

                'Codigo qr

                If (Not IsNothing(HASH)) Then
                    If HASH.Trim.Length > 0 Then
                        QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                                  "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
                                  "|" & HASH & "|" & CERTIFICADO)

                        QrCodeImgControl1.Text = QR
                    Else
                        QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                                 "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                        QrCodeImgControl1.Text = QR
                    End If
                End If

                QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                               "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                QrCodeImgControl1.Text = QR


                Select Case documentoBE.documentoventaAbarrotes.tipoDocumento
                    Case "12.1"
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET BOLETA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                        a.tipoComprobante = 1
                        a.AnadirLineaComprobante("TICKET BOLETA")
                        a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    Case "12.2"
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET FACTURA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                        a.tipoComprobante = 1
                        a.AnadirLineaComprobante("TICKET FACTURA")
                        a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                        fileName = Gempresas.IdEmpresaRuc & "-" & GEstableciento.IdEstablecimiento & "-" & "TICKET FACTURA" & "-" & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta
                    Case "03"
                        If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA DE VENTA ELECTRONICA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                            a.tipoComprobante = 2
                            a.AnadirLineaComprobante("BOLETA DE VENTA ELECTRONICA")
                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c))

                            Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = documentoBE.documentoventaAbarrotes.usuarioActualizacion).FirstOrDefault

                            If Not IsNothing(consultaNombre) Then
                                a.AnadirLineasDatosFinales("VENDEDOR: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)
                            Else
                                a.AnadirLineasDatosFinales("VENDEDOR: " & "VARIOS")
                            End If


                            a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE")
                            a.AnadirLineasDatosFinales("VENTA ELECTRONICA")
                            a.AnadirLineasDatosFinales("http://www.spk.com.pe")
                            a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia")
                            a.AnadirLineasDatosFinales("034-005-0010982")

                            a.AnadirLineasDatosFinales("")

                            a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA")

                            fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                        ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA   N° " & CStr(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, "0"c) & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                            a.tipoComprobante = 1
                            a.AnadirLineaComprobante("BOLETA")
                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                            fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                        End If
                    Case "01"
                        If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA ELECTRONICA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                            a.tipoComprobante = 2
                            a.AnadirLineaComprobante("FACTURA ELECTRONICA")
                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c))

                            Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = documentoBE.documentoventaAbarrotes.usuarioActualizacion).FirstOrDefault

                            If Not IsNothing(consultaNombre) Then
                                a.AnadirLineasDatosFinales("VENDEDOR: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)
                            Else
                                a.AnadirLineasDatosFinales("VENDEDOR: " & "VARIOS")
                            End If

                            a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE")
                            a.AnadirLineasDatosFinales("VENTA ELECTRONICA")
                            a.AnadirLineasDatosFinales("http://www.spk.com.pe")
                            a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia")
                            a.AnadirLineasDatosFinales("034-005-0010982")

                            a.AnadirLineasDatosFinales("")

                            a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA")

                            fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                        ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA   N° " & CStr(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, "0"c) & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                            a.tipoComprobante = 1
                            a.AnadirLineaComprobante("FACTURA")
                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                            fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                        End If
                    Case "9901"
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "COTIZACIÓN   N° " & 0, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                        a.AnadirLineaComprobante("COTIZACIÓN")
                        a.AnadirLineaComprobante(0 & "-" & 0)
                        a.tipoComprobante = 1
                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    Case "07"

                        Dim tipoEmision As String = String.Empty

                        'Select Case comprobante.estadoCobro
                        '    Case "DC"
                        '        tipoVenta = "CONTADO"
                        '    Case "PN"
                        '        tipoVenta = "CREDITO"
                        'End Select

                        Select Case documentoBE.documentoventaAbarrotes.notaCredito
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
                        Select Case documentoBE.documentoventaAbarrotes.TipoDocNota
                            Case "01"
                                NombreComprobante = "FACTURA ELECTRONICA"
                            Case "02"
                                NombreComprobante = "BOLETA ELECTRONICA"
                        End Select

                        'Dim numeroafect As String = String.Format("{0:00000000}", comprobante.numeroDoc)

                        a.AnadirLineaCaracteresDatosGEnerales(documentoBE.documentoventaAbarrotes.fechaDoc,
                                                              "",
                                                              nombreCliente,
                                                              DIRECCIONclIENTE,
                                                              documentoBE.documentoventaAbarrotes.fechaDoc,
                                                              rucCliente,
                                                              "NAC",
                                                             tipoEmision)
                        a.tipoComprobante = 2
                        a.AnadirLineaComprobante("NOTA DE CREDITO ELECTRONICA")
                        a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c))



                        Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = documentoBE.documentoventaAbarrotes.usuarioActualizacion).FirstOrDefault

                        If Not IsNothing(consultaNombre) Then
                            a.AnadirLineasDatosFinales("VENDEDOR: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)
                        Else
                            a.AnadirLineasDatosFinales("VENDEDOR: " & "VARIOS")
                        End If
                        a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE")
                        a.AnadirLineasDatosFinales("VENTA ELECTRONICA")
                        a.AnadirLineasDatosFinales("http://www.spk.com.pe")
                        a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia")
                        a.AnadirLineasDatosFinales("034-005-0010982")

                        a.AnadirLineasDatosFinales("")

                        a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA")

                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    Case Else
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET NOTA   N° " & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                        a.tipoComprobante = 1
                        a.AnadirLineaComprobante("NOTA")
                        a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                End Select

                For Each i In documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList

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

                    If (Not IsNothing(i.CustomEquivalencia)) Then
                        a.AnadirLineaElementosFactura(i.monto1, $"({i.CustomEquivalencia.unidadComercial}) {i.nombreItem} {i.detalleAdicional}", i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", i.descuentoMN.GetValueOrDefault), String.Format("{0:0.00}", PrecioTotal))
                    Else
                        a.AnadirLineaElementosFactura(i.monto1, $"{i.nombreItem} {i.detalleAdicional}", i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", i.descuentoMN.GetValueOrDefault), String.Format("{0:0.00}", PrecioTotal))
                    End If

                    'a.AnadirElemento(i.monto1, i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal), i.nombreItem)
                    'a.AnadirNombreElemento(i.nombreItem)
                    importeTotalMN += i.importeMN
                Next

                a.AnadirDatosGenerales("S/", ExoMN)
                a.AnadirDatosGenerales("S/", InaMN)
                a.AnadirDatosGenerales("S/", gravMN)
                a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.igv01.GetValueOrDefault)
                a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.icbper.GetValueOrDefault)
                a.AnadirDatosGenerales("S/", String.Format("{0:0.00}", documentoBE.documentoventaAbarrotes.ImporteNacional.GetValueOrDefault))

                a.AnadirLineasDatosDescripcionTotal(documentoBE.documentoventaAbarrotes.ImporteNacional)

                If (Not IsNothing(documentoBE.ListaCustomDocumento)) Then
                    For Each item In documentoBE.ListaCustomDocumento.ToList
                        a.AnadirLineasDescuento(item.documentoCaja.formaPagoName & ": " & item.documentoCaja.montoSoles)
                        importeSumMN += item.documentoCaja.montoSoles
                    Next

                    a.AnadirLineasDescuento("PENDIENTE: " & importeTotalMN - importeSumMN)

                Else
                    For Each item In listaDocumento
                        Dim formasPago = Helios.General.TablasGenerales.GetFormasDePago()
                        Dim formaSel = formasPago.Where(Function(o) o.codigoDetalle = item.sustentado).SingleOrDefault

                        'a.AnadirLineasDescuento(item.NombreEntidad & ": " & item.ImporteNacional & "     " & " N°" & item.NroDocEntidad & "  OPER." & item.numeroVenta)
                        a.AnadirLineasDescuento(formaSel.descripcion & ": " & item.ImporteNacional)
                        importeSumMN += item.ImporteNacional

                    Next

                    a.AnadirLineasDescuento("PENDIENTE: " & importeTotalMN - importeSumMN)
                End If

                a.headerImagenQR = QrCodeImgControl1.Image

                'a.AnadirLineaDatos("Vendedor: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno, "Representacion impresa del comprobante", "http://www.spk.com.pe")
                '//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
                '//parametro de tipo string que debe de ser el nombre de la impresora. 
                If (tipoImpresion = "PDF") Then

                    Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)

                    For index As Integer = 1 To 30

                    Next

                    If (fileUbicacion.Length > 0) Then

                        Dim myProcess As New Process
                        Dim PathShell As String = fileUbicacion

                        myProcess.StartInfo.FileName = PathShell
                        myProcess.StartInfo.UseShellExecute = True
                        myProcess.StartInfo.RedirectStandardOutput = False
                        myProcess.Start()
                        myProcess.Dispose()

                    Else
                        MessageBox.Show("VERIFICAR DOCUMENTO A ENVIAR")
                    End If

                ElseIf (tipoImpresion = "GUARDAR") Then
                    'Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)
                    a.ImprimeTicket(imprimir, 1)
                ElseIf (tipoImpresion = "DIRECTO") Then
                    a.tipoComprobante = "2"
                    a.ImprimeTicket(imprimir, txtNroImpresion.DecimalValue)
                End If

            Case "4"
                Dim documentoSA As New documentoVentaAbarrotesSA
                Dim documentoDetSA As New documentoVentaAbarrotesDetSA
                Dim a As TicketForGrandeNota = New TicketForGrandeNota
                'a.HeaderImage = "C:\Documents and Settings\Administrador\Mis documentos\COMPU.jpg" 
                Dim gravMN As Decimal = 0
                Dim gravME As Decimal = 0
                Dim ExoMN As Decimal = 0
                Dim ExoME As Decimal = 0
                Dim InaMN As Decimal = 0
                Dim InaME As Decimal = 0
                Dim precioUnit As Decimal = 0
                Dim PrecioTotal As Decimal = 0

                Dim nombreCliente As String
                Dim rucCliente As String = String.Empty
                Dim importeTotalMN As Decimal
                Dim importeSumMN As Decimal
                'Dim comprobante = documentoSA.GetUbicar_NotaXID(intIdDocumento)
                'Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)


                If (objDatosGenrales.logo.Length > 0) Then
                    ' Logo de la Empresa
                    a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
                End If

                If (objDatosGenrales.nombreImpresion = "C") Then
                    a.tipoImagen = False
                ElseIf (objDatosGenrales.nombreImpresion = "R") Then
                    a.tipoImagen = True
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
                a.TextoIzquierda("Direccion: " & objDatosGenrales.direccionPrincipal)
                'a.TextoIzquierda("Direccion Secundaria: " & objDatosGenrales.direccionSecudaria)
                'Telefono de la empresa
                If (objDatosGenrales.telefono3.Length > 0) Then
                    a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3)
                ElseIf (objDatosGenrales.telefono2.Length > 0) Then
                    a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
                Else
                    a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1)
                End If

                Dim DIRECCIONclIENTE As String = String.Empty
                Dim NBoletaElectronica As String = String.Empty
                'If documentoBE.documentoventaAbarrotes.idCliente <> 0 Then
                Dim entidad = documentoBE.documentoventaAbarrotes.CustomEntidad  'entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault

                Select Case entidad.tipoEntidad
                    Case "VR"
                        NBoletaElectronica = documentoBE.documentoventaAbarrotes.nombrePedido
                    Case Else
                        NBoletaElectronica = entidad.nombreCompleto
                End Select


                'DIRECCIONclIENTE = entidad.DireccionSeleccionada ' entidad.direccion
                If (ChecDomicilio.Checked = False) Then
                    entidad.direccion = documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada
                    DIRECCIONclIENTE = entidad.direccion
                Else
                    DIRECCIONclIENTE = entidad.direccion
                End If
                nombreCliente = (NBoletaElectronica)

                Select Case entidad.tipoEntidad
                    Case "VR"
                        rucCliente = "-"
                    Case Else
                        If (Not IsNothing(entidad.nrodoc)) Then
                            If entidad.nrodoc.Trim.Length = 11 Then
                                rucCliente = "R.U.C. - " & entidad.nrodoc
                            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                                rucCliente = "D.N.I. - " & entidad.nrodoc
                            Else
                                rucCliente = ("NRO DOC.: " & entidad.nrodoc)
                            End If
                        Else
                            rucCliente = "-"
                        End If
                End Select
                'Codigo qr

                If (Not IsNothing(HASH)) Then
                    If HASH.Trim.Length > 0 Then
                        QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                                  "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
                                  "|" & HASH & "|" & CERTIFICADO)

                        QrCodeImgControl1.Text = QR
                    Else
                        QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                                 "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                        QrCodeImgControl1.Text = QR
                    End If
                End If

                QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                               "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                QrCodeImgControl1.Text = QR

                'QrCodeImgControl1.Image

                'Else
                '    Dim NBoletaElectronica As String = documentoBE.documentoventaAbarrotes.nombrePedido
                '    nombreCliente = (NBoletaElectronica)

                '    'Codigo qr
                '    QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                '              "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & "VARIOS" & "|" & "0")

                '    QrCodeImgControl1.Text = QR

                'End If

                Select Case documentoBE.documentoventaAbarrotes.tipoDocumento
                    Case "12.1"
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET BOLETA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                        a.tipoComprobante = 1
                        a.AnadirLineaComprobante("TICKET BOLETA")
                        a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    Case "12.2"
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET FACTURA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                        a.tipoComprobante = 1
                        a.AnadirLineaComprobante("TICKET FACTURA")
                        a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    Case "03"
                        If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA DE VENTA ELECTRONICA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                            a.tipoComprobante = 2
                            a.AnadirLineaComprobante("BOLETA DE VENTA ELECTRONICA")
                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c))

                            Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = documentoBE.documentoventaAbarrotes.usuarioActualizacion).FirstOrDefault

                            If Not IsNothing(consultaNombre) Then
                                a.AnadirLineasDatosFinales("VENDEDOR: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)
                            Else
                                a.AnadirLineasDatosFinales("VENDEDOR: " & "VARIOS")
                            End If


                            a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE")
                            a.AnadirLineasDatosFinales("VENTA ELECTRONICA")
                            a.AnadirLineasDatosFinales("http://www.spk.com.pe")
                            a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia")
                            a.AnadirLineasDatosFinales("034-005-0010982")

                            a.AnadirLineasDatosFinales("")

                            'a.AnadirLineasDatosFinales("SIETE (7) DIAS DESPUES DE LA COMPRA")
                            'a.AnadirLineasDatosFinales("PRESENTAR TICKET ORIGINAL")
                            'a.AnadirLineasDatosFinales("maych_1@hotmail.com")
                            'a.AnadirLineasDatosFinales("TELEFONO DE ATENCION AL CLIENTE")
                            'a.AnadirLineasDatosFinales("(01)-12345678")
                            a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA")

                            fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                        ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA   N° " & CStr(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, "0"c) & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                            a.tipoComprobante = 1
                            a.AnadirLineaComprobante("BOLETA")
                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                            fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                        End If
                    Case "01"
                        If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA ELECTRONICA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                            a.tipoComprobante = 2
                            a.AnadirLineaComprobante("FACTURA ELECTRONICA")
                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c))

                            Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = documentoBE.documentoventaAbarrotes.usuarioActualizacion).FirstOrDefault

                            If Not IsNothing(consultaNombre) Then
                                a.AnadirLineasDatosFinales("VENDEDOR: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)
                            Else
                                a.AnadirLineasDatosFinales("VENDEDOR: " & "VARIOS")
                            End If

                            a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE")
                            a.AnadirLineasDatosFinales("VENTA ELECTRONICA")
                            a.AnadirLineasDatosFinales("http://www.spk.com.pe")
                            a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia")
                            a.AnadirLineasDatosFinales("034-005-0010982")

                            a.AnadirLineasDatosFinales("")

                            'a.AnadirLineasDatosFinales("CUALQUIER CAMBIO O DEVOLUCION SERA HASTA")
                            'a.AnadirLineasDatosFinales("SIETE (7) DIAS DESPUES DE LA COMPRA")
                            'a.AnadirLineasDatosFinales("PRESENTAR TICKET ORIGINAL")
                            'a.AnadirLineasDatosFinales("maych_1@hotmail.com")
                            'a.AnadirLineasDatosFinales("TELEFONO DE ATENCION AL CLIENTE")
                            'a.AnadirLineasDatosFinales("(01)-12345678")
                            a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA")


                            fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                        ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA   N° " & CStr(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, "0"c) & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                            a.tipoComprobante = 1
                            a.AnadirLineaComprobante("FACTURA")
                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                            fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                        End If
                    Case "9901"
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "COTIZACIÓN   N° " & 0, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                        a.AnadirLineaComprobante("COTIZACIÓN")
                        a.AnadirLineaComprobante(0 & "-" & 0)
                        a.tipoComprobante = 1
                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    Case "07"

                        Dim tipoEmision As String = String.Empty

                        'Select Case comprobante.estadoCobro
                        '    Case "DC"
                        '        tipoVenta = "CONTADO"
                        '    Case "PN"
                        '        tipoVenta = "CREDITO"
                        'End Select

                        Select Case documentoBE.documentoventaAbarrotes.notaCredito
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
                        Select Case documentoBE.documentoventaAbarrotes.TipoDocNota
                            Case "01"
                                NombreComprobante = "FACTURA ELECTRONICA"
                            Case "02"
                                NombreComprobante = "BOLETA ELECTRONICA"
                        End Select

                        'Dim numeroafect As String = String.Format("{0:00000000}", comprobante.numeroDoc)

                        a.AnadirLineaCaracteresDatosGEnerales(documentoBE.documentoventaAbarrotes.fechaDoc,
                                                              "",
                                                              nombreCliente,
                                                              DIRECCIONclIENTE,
                                                              documentoBE.documentoventaAbarrotes.fechaDoc,
                                                              rucCliente,
                                                              "NAC",
                                                             tipoEmision)
                        a.tipoComprobante = 2
                        a.AnadirLineaComprobante("NOTA DE CREDITO ELECTRONICA")
                        a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c))



                        Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = documentoBE.documentoventaAbarrotes.usuarioActualizacion).FirstOrDefault

                        If Not IsNothing(consultaNombre) Then
                            a.AnadirLineasDatosFinales("VENDEDOR: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)
                        Else
                            a.AnadirLineasDatosFinales("VENDEDOR: " & "VARIOS")
                        End If
                        a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE")
                        a.AnadirLineasDatosFinales("VENTA ELECTRONICA")
                        a.AnadirLineasDatosFinales("http://www.spk.com.pe")
                        a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia")
                        a.AnadirLineasDatosFinales("034-005-0010982")

                        a.AnadirLineasDatosFinales("")

                        a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA")
                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    Case Else
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET NOTA   N° " & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413")
                        a.tipoComprobante = 1
                        a.AnadirLineaComprobante("NOTA")
                        a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                End Select

                For Each i In documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList

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

                    If (i.monto1 > 0) Then
                        precioUnit = (Math.Round(CDbl(i.importeMN / i.monto1), 2))
                    ElseIf (i.monto1 = 0) Then
                        precioUnit = (Math.Round(CDbl(i.importeMN), 2))
                    End If


                    PrecioTotal = i.importeMN

                    a.AnadirLineaElementosFactura(i.monto1, $"{i.nombreItem} {i.detalleAdicional}", i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))

                    'a.AnadirElemento(i.monto1, i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal), i.nombreItem)
                    'a.AnadirNombreElemento(i.nombreItem)
                    importeTotalMN += i.importeMN
                Next

                a.AnadirDatosGenerales("S/", ExoMN)
                a.AnadirDatosGenerales("S/", InaMN)
                a.AnadirDatosGenerales("S/", gravMN)
                a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.igv01.GetValueOrDefault)
                a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.icbper.GetValueOrDefault)
                a.AnadirDatosGenerales("S/", String.Format("{0:0.00}", documentoBE.documentoventaAbarrotes.ImporteNacional.GetValueOrDefault))

                a.AnadirLineasDatosDescripcionTotal(documentoBE.documentoventaAbarrotes.ImporteNacional)

                a.headerImagenQR = QrCodeImgControl1.Image

                'a.AnadirLineaDatos("Vendedor: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno, "Representacion impresa del comprobante", "http://www.spk.com.pe")
                '//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
                '//parametro de tipo string que debe de ser el nombre de la impresora. 
                If (tipoImpresion = "PDF") Then

                    Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)
                    If (fileUbicacion.Length > 0) Then

                        Dim myProcess As New Process
                        Dim PathShell As String = fileUbicacion

                        myProcess.StartInfo.FileName = PathShell
                        myProcess.StartInfo.UseShellExecute = True
                        myProcess.StartInfo.RedirectStandardOutput = False
                        myProcess.Start()
                        myProcess.Dispose()

                    Else
                        MessageBox.Show("VERIFICAR DOCUMENTO A ENVIAR")
                    End If

                ElseIf (tipoImpresion = "GUARDAR") Then
                    Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)

                ElseIf (tipoImpresion = "DIRECTO") Then
                    a.tipoComprobante = "2"
                    a.ImprimeTicket(imprimir, txtNroImpresion.DecimalValue)
                End If

            Case "RESTAURANTE"
                Dim documentoSA As New documentoVentaAbarrotesSA
                Dim documentoDetSA As New documentoVentaAbarrotesDetSA
                Dim a As TicketForGrandetRest = New TicketForGrandetRest
                'a.HeaderImage = "C:\Documents and Settings\Administrador\Mis documentos\COMPU.jpg" 
                Dim gravMN As Decimal = 0
                Dim gravME As Decimal = 0
                Dim ExoMN As Decimal = 0
                Dim ExoME As Decimal = 0
                Dim InaMN As Decimal = 0
                Dim InaME As Decimal = 0
                Dim precioUnit As Decimal = 0
                Dim PrecioTotal As Decimal = 0

                Dim nombreCliente As String
                Dim rucCliente As String = String.Empty
                Dim importeTotalMN As Decimal
                Dim importeSumMN As Decimal
                'Dim comprobante = documentoSA.GetUbicar_NotaXID(intIdDocumento)
                'Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
                'If My.Computer.Network.IsAvailable = True Then
                '    'If My.Computer.Network.Ping("148.102.27.231") Then
                '    If (documentoBE.documentoventaAbarrotes.tipoDocumento = "01" And documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Or (documentoBE.documentoventaAbarrotes.tipoDocumento = "07" And documentoBE.documentoventaAbarrotes.tipoVenta = "NTCE") Then
                '        XmlFactura(documentoBE.documentoventaAbarrotes, documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList)
                '    End If
                '    'End If
                'End If

                If (objDatosGenrales.logo.Length > 0) Then
                    ' Logo de la Empresa
                    a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
                End If

                If (objDatosGenrales.nombreImpresion = "C") Then
                    a.tipoImagen = False
                ElseIf (objDatosGenrales.nombreImpresion = "R") Then
                    a.tipoImagen = True
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
                a.TextoIzquierda(objDatosGenrales.direccionPrincipal)
                a.TextoIzquierda(objDatosGenrales.direccionSecudaria)
                'Telefono de la empresa
                If (objDatosGenrales.telefono3.Length > 0) Then
                    a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3)
                ElseIf (objDatosGenrales.telefono2.Length > 0) Then
                    a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
                Else
                    a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1)
                End If

                Dim DIRECCIONclIENTE As String = String.Empty
                Dim NBoletaElectronica As String = String.Empty
                'If documentoBE.documentoventaAbarrotes.idCliente <> 0 Then
                Dim entidad = documentoBE.documentoventaAbarrotes.CustomEntidad  'entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault

                Select Case entidad.tipoEntidad
                    Case "VR"
                        NBoletaElectronica = documentoBE.documentoventaAbarrotes.nombrePedido
                    Case Else
                        NBoletaElectronica = entidad.nombreCompleto
                End Select


                DIRECCIONclIENTE = entidad.DireccionSeleccionada ' entidad.direccion
                nombreCliente = (NBoletaElectronica)

                Select Case entidad.tipoEntidad
                    Case "VR"
                        rucCliente = "-"
                    Case Else
                        If (Not IsNothing(entidad.nrodoc)) Then
                            If entidad.nrodoc.Trim.Length = 11 Then
                                rucCliente = "R.U.C. - " & entidad.nrodoc
                            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                                rucCliente = "D.N.I. - " & entidad.nrodoc
                            Else
                                rucCliente = ("NRO DOC.: " & entidad.nrodoc)
                            End If
                        Else
                            rucCliente = "-"
                        End If
                End Select

                'Codigo qr

                If (Not IsNothing(HASH)) Then
                    If HASH.Trim.Length > 0 Then
                        QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                                      "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
                                      "|" & HASH & "|" & CERTIFICADO)

                        QrCodeImgControl1.Text = QR
                    Else
                        QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                                     "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                        QrCodeImgControl1.Text = QR
                    End If
                End If

                QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                                   "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                QrCodeImgControl1.Text = QR

                'QrCodeImgControl1.Image

                'Else
                '    Dim NBoletaElectronica As String = documentoBE.documentoventaAbarrotes.nombrePedido
                '    nombreCliente = (NBoletaElectronica)

                '    'Codigo qr
                '    QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                '              "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & "VARIOS" & "|" & "0")

                '    QrCodeImgControl1.Text = QR

                'End If

                Select Case documentoBE.documentoventaAbarrotes.tipoDocumento
                    Case "12.1"
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET BOLETA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
                        a.tipoComprobante = 1
                        a.AnadirLineaComprobante("TICKET BOLETA")
                        a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)

                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)

                    Case "12.2"
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET FACTURA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
                        a.tipoComprobante = 1
                        a.AnadirLineaComprobante("TICKET FACTURA")
                        a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)

                    Case "03"
                        If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA DE VENTA ELECTRONICA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
                            a.tipoComprobante = 2
                            a.AnadirLineaComprobante("BOLETA DE VENTA ELECTRONICA")
                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c))


                            a.AnadirLineasDatosFinales("MONTO RECIBIDO  : " & String.Format("{0:0.00}", RECIBIDO))
                            a.AnadirLineasDatosFinales("CONSUMO TOTAL   : " & String.Format("{0:0.00}", documentoBE.documentoventaAbarrotes.ImporteNacional))
                            a.AnadirLineasDatosFinales("VUELTO            : " & String.Format("{0:0.00}", VUELTO))


                            Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = documentoBE.documentoventaAbarrotes.usuarioActualizacion).FirstOrDefault

                            If Not IsNothing(consultaNombre) Then
                                a.AnadirLineasDatosFinales("CAJERO: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)
                            Else
                                a.AnadirLineasDatosFinales("CAJERO: " & "VARIOS")
                            End If


                            a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE")
                            a.AnadirLineasDatosFinales("VENTA ELECTRONICA")
                            a.AnadirLineasDatosFinales("http://www.spk.com.pe")
                            a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia")
                            a.AnadirLineasDatosFinales("034-005-0010982")

                            a.AnadirLineasDatosFinales("")

                            'a.AnadirLineasDatosFinales("SIETE (7) DIAS DESPUES DE LA COMPRA")
                            'a.AnadirLineasDatosFinales("PRESENTAR TICKET ORIGINAL")
                            'a.AnadirLineasDatosFinales("maych_1@hotmail.com")
                            'a.AnadirLineasDatosFinales("TELEFONO DE ATENCION AL CLIENTE")
                            'a.AnadirLineasDatosFinales("(01)-12345678")
                            a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA")

                            fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)

                        ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA   N° " & CStr(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, "0"c) & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
                            a.tipoComprobante = 1
                            a.AnadirLineaComprobante("BOLETA")
                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                            fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)

                        End If
                    Case "01"
                        If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA ELECTRONICA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
                            a.tipoComprobante = 2
                            a.AnadirLineaComprobante("FACTURA ELECTRONICA")
                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c))


                            a.AnadirLineasDatosFinales("MONTO RECIBIDO  : " & String.Format("{0:0.00}", RECIBIDO))
                            a.AnadirLineasDatosFinales("CONSUMO TOTAL   : " & String.Format("{0:0.00}", documentoBE.documentoventaAbarrotes.ImporteNacional))
                            a.AnadirLineasDatosFinales("VUELTO            : " & String.Format("{0:0.00}", VUELTO))



                            Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = documentoBE.documentoventaAbarrotes.usuarioActualizacion).FirstOrDefault

                            If Not IsNothing(consultaNombre) Then
                                a.AnadirLineasDatosFinales("CAJERO: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)
                            Else
                                a.AnadirLineasDatosFinales("CAJERO: " & "VARIOS")
                            End If

                            a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE")
                            a.AnadirLineasDatosFinales("VENTA ELECTRONICA")
                            a.AnadirLineasDatosFinales("http://www.spk.com.pe")
                            a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia")
                            a.AnadirLineasDatosFinales("034-005-0010982")

                            a.AnadirLineasDatosFinales("")

                            'a.AnadirLineasDatosFinales("CUALQUIER CAMBIO O DEVOLUCION SERA HASTA")
                            'a.AnadirLineasDatosFinales("SIETE (7) DIAS DESPUES DE LA COMPRA")
                            'a.AnadirLineasDatosFinales("PRESENTAR TICKET ORIGINAL")
                            'a.AnadirLineasDatosFinales("maych_1@hotmail.com")
                            'a.AnadirLineasDatosFinales("TELEFONO DE ATENCION AL CLIENTE")
                            'a.AnadirLineasDatosFinales("(01)-12345678")
                            a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA")


                            fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)

                        ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA   N° " & CStr(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, "0"c) & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
                            a.tipoComprobante = 1
                            a.AnadirLineaComprobante("FACTURA")
                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                            fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)

                        End If
                    Case "9901"
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "COTIZACIÓN   N° " & 0, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
                        a.AnadirLineaComprobante("COTIZACIÓN")
                        a.AnadirLineaComprobante(0 & "-" & 0)
                        a.tipoComprobante = 1
                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)

                    Case "07"

                        Dim tipoEmision As String = String.Empty

                        'Select Case comprobante.estadoCobro
                        '    Case "DC"
                        '        tipoVenta = "CONTADO"
                        '    Case "PN"
                        '        tipoVenta = "CREDITO"
                        'End Select

                        Select Case documentoBE.documentoventaAbarrotes.notaCredito
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
                        Select Case documentoBE.documentoventaAbarrotes.TipoDocNota
                            Case "01"
                                NombreComprobante = "FACTURA ELECTRONICA"
                            Case "02"
                                NombreComprobante = "BOLETA ELECTRONICA"
                        End Select

                        'Dim numeroafect As String = String.Format("{0:00000000}", comprobante.numeroDoc)

                        a.AnadirLineaCaracteresDatosGEnerales(documentoBE.documentoventaAbarrotes.fechaDoc,
                                                                      "",
                                                                      nombreCliente,
                                                                      DIRECCIONclIENTE,
                                                                      documentoBE.documentoventaAbarrotes.fechaDoc,
                                                                      rucCliente,
                                                                      "NAC",
                                                                     tipoEmision)
                        a.tipoComprobante = 2
                        a.AnadirLineaComprobante("NOTA DE CREDITO ELECTRONICA")
                        a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c))

                        Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = documentoBE.documentoventaAbarrotes.usuarioActualizacion).FirstOrDefault

                        If Not IsNothing(consultaNombre) Then
                            a.AnadirLineasDatosFinales("CAJERO: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)
                        Else
                            a.AnadirLineasDatosFinales("CAJERO: " & "VARIOS")
                        End If
                        a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE")
                        a.AnadirLineasDatosFinales("VENTA ELECTRONICA")
                        a.AnadirLineasDatosFinales("http://www.spk.com.pe")
                        a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia")
                        a.AnadirLineasDatosFinales("034-005-0010982")
                        a.AnadirLineasDatosFinales("")
                        a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA")

                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)

                    Case Else
                        a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET NOTA   N° " & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
                        a.tipoComprobante = 1
                        a.AnadirLineaComprobante("NOTA")
                        a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                        'a.AnadirLineaSubcabeza("Ticket nota    N° " & comprobante.numeroVenta)

                        a.AnadirLineasDatosFinales("MONTO RECIBIDO  : " & String.Format("{0:0.00}", RECIBIDO))
                        a.AnadirLineasDatosFinales("CONSUMO TOTAL   : " & String.Format("{0:0.00}", documentoBE.documentoventaAbarrotes.ImporteNacional))
                        a.AnadirLineasDatosFinales("VUELTO            : " & String.Format("{0:0.00}", VUELTO))



                        Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = documentoBE.documentoventaAbarrotes.usuarioActualizacion).FirstOrDefault

                        If Not IsNothing(consultaNombre) Then
                            a.AnadirLineasDatosFinales("CAJERO: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)
                        Else
                            a.AnadirLineasDatosFinales("CAJERO: " & "VARIOS")
                        End If

                        a.AnadirLineasDatosFinales("Exija su boleta de venta")
                        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)

                End Select
                a.AnadirLineaComprobanteExtra(nombremesa)
                For Each i In documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList

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

                    If (Not IsNothing(i.CustomEquivalencia)) Then
                        a.AnadirLineaElementosFactura(i.monto1, $"{i.nombreItem} {i.detalleAdicional} ({i.CustomEquivalencia.unidadComercial})", i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", i.descuentoMN.GetValueOrDefault), String.Format("{0:0.00}", PrecioTotal))
                    Else
                        a.AnadirLineaElementosFactura(i.monto1, $"{i.nombreItem} {i.detalleAdicional}", i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", i.descuentoMN.GetValueOrDefault), String.Format("{0:0.00}", PrecioTotal))
                    End If

                    'a.AnadirElemento(i.monto1, i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal), i.nombreItem)
                    'a.AnadirNombreElemento(i.nombreItem)
                    importeTotalMN += i.importeMN
                Next

                a.AnadirDatosGenerales("S/", ExoMN)
                a.AnadirDatosGenerales("S/", InaMN)
                a.AnadirDatosGenerales("S/", gravMN)
                a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.igv01.GetValueOrDefault)
                a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.icbper.GetValueOrDefault)
                a.AnadirDatosGenerales("S/", String.Format("{0:0.00}", documentoBE.documentoventaAbarrotes.ImporteNacional.GetValueOrDefault))

                'a.AnadirDatosGenerales("", "")
                'a.AnadirDatosGenerales("S/", String.Format("{0:0.00}", VUELTO))

                'a.AnadirDatosGenerales("S/",  )
                'a.AnadirDatosGenerales("S/", )

                a.AnadirLineasDatosDescripcionTotal(documentoBE.documentoventaAbarrotes.ImporteNacional)

                If (Not IsNothing(documentoBE.ListaCustomDocumento)) Then
                    For Each item In documentoBE.ListaCustomDocumento.ToList
                        a.AnadirLineasDescuento(item.documentoCaja.formaPagoName & ": " & item.documentoCaja.montoSoles)
                        importeSumMN += item.documentoCaja.montoSoles
                    Next

                    'a.AnadirLineasDescuento("PENDIENTE: " & importeTotalMN - importeSumMN)

                Else
                    For Each item In listaDocumento
                        Dim formasPago = Helios.General.TablasGenerales.GetFormasDePago()
                        Dim formaSel = formasPago.Where(Function(o) o.codigoDetalle = item.sustentado).SingleOrDefault

                        'a.AnadirLineasDescuento(item.NombreEntidad & ": " & item.ImporteNacional & "     " & " N°" & item.NroDocEntidad & "  OPER." & item.numeroVenta)
                        a.AnadirLineasDescuento(formaSel.descripcion & ": " & item.ImporteNacional)
                        importeSumMN += item.ImporteNacional

                    Next

                    'a.AnadirLineasDescuento("PENDIENTE: " & importeTotalMN - importeSumMN)
                End If

                a.headerImagenQR = QrCodeImgControl1.Image

                'a.AnadirLineaDatos("Vendedor: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno, "Representacion impresa del comprobante", "http://www.spk.com.pe")
                '//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
                '//parametro de tipo string que debe de ser el nombre de la impresora. 
                If (tipoImpresion = "PDF") Then

                    Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)
                    If (fileUbicacion.Length > 0) Then

                        Dim myProcess As New Process
                        Dim PathShell As String = fileUbicacion

                        myProcess.StartInfo.FileName = PathShell
                        myProcess.StartInfo.UseShellExecute = True
                        myProcess.StartInfo.RedirectStandardOutput = False
                        myProcess.Start()
                        myProcess.Dispose()

                    Else
                        MessageBox.Show("VERIFICAR DOCUMENTO A ENVIAR")
                    End If

                ElseIf (tipoImpresion = "GUARDAR") Then
                    Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)

                ElseIf (tipoImpresion = "DIRECTO") Then
                    a.tipoComprobante = "2"
                    a.ImprimeTicket(imprimir, txtNroImpresion.DecimalValue)
                End If


            Case "TRANSPORTE"

                Dim a As TicketTransporteVer2 = New TicketTransporteVer2
                'a.HeaderImage = "C:\Documents and Settings\Administrador\Mis documentos\COMPU.jpg" 
                Dim gravMN As Decimal = 0
                Dim gravME As Decimal = 0
                Dim ExoMN As Decimal = 0
                Dim ExoME As Decimal = 0
                Dim InaMN As Decimal = 0
                Dim InaME As Decimal = 0
                Dim precioUnit As Decimal = 0
                Dim PrecioTotal As Decimal = 0
                Dim nombreCliente As String
                Dim rucCliente As String = String.Empty


                If (objDatosGenrales.logo.Length > 0) Then
                    ' Logo de la Empresa
                    a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
                End If

                If (objDatosGenrales.nombreImpresion = "C") Then
                    a.tipoImagen = False
                ElseIf (objDatosGenrales.nombreImpresion = "R") Then
                    a.tipoImagen = True
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

                'ruc
                a.TextoIzquierda("R.U.C.: " & objDatosGenrales.idEmpresa)
                'direccion de la empresa
                a.TextoIzquierda(objDatosGenrales.direccionPrincipal)
                a.TextoIzquierda(objDatosGenrales.direccionSecudaria)
                'Telefono de la empresa
                If (objDatosGenrales.telefono3.Length > 0) Then
                    a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3)
                ElseIf (objDatosGenrales.telefono2.Length > 0) Then
                    a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
                Else
                    a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1)
                End If

                Dim DIRECCIONclIENTE As String = String.Empty
                Dim NBoletaElectronica As String = String.Empty

                Dim entidadTrans = LLAMARENTIDAD
                Dim DOCUMENTOTransBE = LLAMARTRANSPORTE


                NBoletaElectronica = entidadTrans.nombreCompleto
                DIRECCIONclIENTE = entidadTrans.DireccionSeleccionada ' entidad.direccion
                nombreCliente = (NBoletaElectronica)

                '//ruc razon social
                If (Not IsNothing(entidadTrans.nrodoc)) Then
                    rucCliente = entidadTrans.nrodoc
                End If


                'Codigo qr

                If (Not IsNothing(HASH)) Then
                    If HASH.Trim.Length > 0 Then
                        QR = (Gempresas.IdEmpresaRuc & "|" & DOCUMENTOTransBE.tipoDocumento.ToString & "|" & DOCUMENTOTransBE.serie & "|" & DOCUMENTOTransBE.numero & "|" & Format(DOCUMENTOTransBE.igv1, 2) &
                                      "|" & DOCUMENTOTransBE.total & "|" & CDate(DOCUMENTOTransBE.fechadoc).Date.ToString(FormatoFecha) & "|" & entidadTrans.tipoDoc & "|" & entidadTrans.nrodoc &
                                      "|" & HASH & "|" & CERTIFICADO)

                        QrCodeImgControl1.Text = QR
                    Else
                        QR = (Gempresas.IdEmpresaRuc & "|" & DOCUMENTOTransBE.tipoDocumento.ToString & "|" & DOCUMENTOTransBE.serie & "|" & DOCUMENTOTransBE.numero & "|" & Format(DOCUMENTOTransBE.igv1, 2) &
                                      "|" & DOCUMENTOTransBE.total & "|" & CDate(DOCUMENTOTransBE.fechadoc).Date.ToString(FormatoFecha) & "|" & entidadTrans.tipoDoc & "|" & entidadTrans.nrodoc)

                        QrCodeImgControl1.Text = QR
                    End If
                End If

                QR = (Gempresas.IdEmpresaRuc & "|" & DOCUMENTOTransBE.tipoDocumento.ToString & "|" & DOCUMENTOTransBE.serie & "|" & DOCUMENTOTransBE.numero & "|" & Format(DOCUMENTOTransBE.igv1, 2) &
                                      "|" & DOCUMENTOTransBE.total & "|" & CDate(DOCUMENTOTransBE.fechadoc).Date.ToString(FormatoFecha) & "|" & entidadTrans.tipoDoc & "|" & entidadTrans.nrodoc)

                QrCodeImgControl1.Text = QR


                Select Case DOCUMENTOTransBE.tipoDocumento
                            'BOLETA DE VENTA ELECTRONICA   N° " & DOCUMENTOTransBE.serie & "-" & DOCUMENTOTransBE.numero
                    Case "03"

                        If (DOCUMENTOTransBE.CustomPerson.idPersona = LLAMARENTIDAD.nrodoc) Then
                            'a.AnadirLineaCaracteresDatosGEnerales(CDate(DOCUMENTOTransBE.fechaProgramada.Value).Date,
                            'CDate(DOCUMENTOTransBE.fechadoc.Value).Date,
                            'GEstableciento.NombreEstablecimiento,
                            'CDate(DOCUMENTOTransBE.fechaProgramada.Value).ToLongTimeString,
                            'GEstableciento.NombreEstablecimiento,
                            'DOCUMENTOTransBE.UbigeoCiudadOrigen & "-" & DOCUMENTOTransBE.UbigeoCiudadDestino,
                            'DOCUMENTOTransBE.UbigeoCiudadOrigen,
                            'DOCUMENTOTransBE.comprador,
                            '"--",
                            '"--",
                            'rucCliente,
                            '"9",
                            '"992",
                            'LLAMARENTIDAD.nombreCompleto,
                            'LLAMARENTIDAD.nrodoc,
                            '"13",
                            '"14",
                            '"15")

                            a.AnadirLineaCaracteresDatosGEnerales(CDate(DOCUMENTOTransBE.fechaProgramada.Value).Date,
                                       DOCUMENTOTransBE.ciudadOrigen,
                                      "GENERAL",
                                      CDate(DOCUMENTOTransBE.fechaProgramada.Value).ToLongTimeString,
                                      DOCUMENTOTransBE.numeroAsiento,
                                      "1",
                                      "2",
                                       DOCUMENTOTransBE.comprador,
                                      "CAR.CHUNAN NRO. 15 CPME. PICHUS (S70050250 A 200 METROS I.E. N30478) JUNIN - JAUJA - SAN PEDRO DE CHUNAN",
                                      DOCUMENTOTransBE.ciudadDestino,
                                      rucCliente,
                                      "NAC",
                                      "DEVOLUCION DEL DINERO",
                                      "3",
                                      "4",
                                      "5",
                                      "6",
                                      "7")


                            a.DIRECIONEMBAR = "DNI"

                        Else

                            'a.AnadirLineaCaracteresDatosGEnerales(CDate(DOCUMENTOTransBE.fechaProgramada.Value).Date,
                            '    CDate(DOCUMENTOTransBE.fechadoc.Value).Date,
                            '    GEstableciento.NombreEstablecimiento,
                            '    CDate(DOCUMENTOTransBE.fechaProgramada.Value).ToLongTimeString,
                            '    "SER",
                            '    DOCUMENTOTransBE.UbigeoCiudadOrigen & "-" & DOCUMENTOTransBE.UbigeoCiudadDestino,
                            '    DOCUMENTOTransBE.UbigeoCiudadOrigen,
                            '    DOCUMENTOTransBE.CustomPerson.nombreCompleto,
                            '    LLAMARENTIDAD.nrodoc,
                            '    LLAMARENTIDAD.nombreCompleto,
                            '    DOCUMENTOTransBE.CustomPerson.idPersona,
                            '      "9",
                            '      "992",
                            '      LLAMARENTIDAD.nombreCompleto,
                            '      LLAMARENTIDAD.nrodoc,
                            '      "13",
                            '      "14",
                            '      "15")



                            a.AnadirLineaCaracteresDatosGEnerales(CDate(DOCUMENTOTransBE.fechaProgramada.Value).Date,
                                       DOCUMENTOTransBE.ciudadOrigen,
                                     "GENERAL",
                                      CDate(DOCUMENTOTransBE.fechaProgramada.Value).ToLongTimeString,
                                      DOCUMENTOTransBE.numeroAsiento,
                                      "1",
                                      "2",
                                       DOCUMENTOTransBE.comprador,
                                     LLAMARENTIDAD.nombreCompleto,
                                      DOCUMENTOTransBE.ciudadDestino,
                                      rucCliente,
                                      "NAC",
                                     LLAMARENTIDAD.nrodoc,
                                      "3",
                                      "4",
                                      "5",
                                      "6",
                                      "7")

                            a.DIRECIONEMBAR = "RUC"
                        End If

                        a.tipoComprobante = 2
                        a.AnadirLineaComprobante("BOLETA DE VENTA ELECTRONICA")
                        a.AnadirLineaComprobante(DOCUMENTOTransBE.serie & "-" & CStr(DOCUMENTOTransBE.numero).PadLeft(8, "0"c))


                        a.AnadirLineasDatosFinales("FECHA DE EMISION: " & DateTime.Now)

                        Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = DOCUMENTOTransBE.usuarioActualizacion).FirstOrDefault

                        If Not IsNothing(consultaNombre) Then
                            a.AnadirLineasDatosFinales("VENDEDOR: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)
                        Else
                            a.AnadirLineasDatosFinales("VENDEDOR: " & "VARIOS")
                        End If

                        fileName = Gempresas.IdEmpresaRuc & "-" & GEstableciento.IdEstablecimiento & "-" & "BOLETA DE VENTA ELECTRONICA" & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & documentoBE.documentoventaAbarrotes.numeroVenta



                    Case "01"



                        a.AnadirLineaCaracteresDatosGEnerales(CDate(DOCUMENTOTransBE.fechaProgramada.Value).Date,
                                        CDate(DOCUMENTOTransBE.fechadoc.Value).Date,
                                        GEstableciento.NombreEstablecimiento,
                                        CDate(DOCUMENTOTransBE.fechaProgramada.Value).ToLongTimeString,
                                        DOCUMENTOTransBE.numeroAsiento,
                                        DOCUMENTOTransBE.UbigeoCiudadOrigen & "-" & DOCUMENTOTransBE.UbigeoCiudadDestino,
                                        DOCUMENTOTransBE.UbigeoCiudadOrigen,
                                        DOCUMENTOTransBE.comprador,
                                        LLAMARENTIDAD.nrodoc,
                                        LLAMARENTIDAD.nombreCompleto,
                                        DOCUMENTOTransBE.CustomPerson.idPersona,
                                        LLAMARENTIDAD.nombreCompleto,
                                        "992",
                                        LLAMARENTIDAD.nombreCompleto,
                                        LLAMARENTIDAD.nrodoc,
                                        "13",
                                        "14",
                                        "15")


                        'a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA ELECTRONICA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
                        a.tipoComprobante = 2
                        a.AnadirLineaComprobante("FACTURA ELECTRONICA")
                        a.AnadirLineaComprobante(DOCUMENTOTransBE.serie & "-" & CStr(DOCUMENTOTransBE.numero).PadLeft(8, "0"c))


                        a.DIRECIONEMBAR = "RUC"

                        a.AnadirLineasDatosFinales("FECHA DE EMISION: " & DateTime.Now)

                        Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = DOCUMENTOTransBE.usuarioActualizacion).FirstOrDefault

                        If Not IsNothing(consultaNombre) Then
                            a.AnadirLineasDatosFinales("VENDEDOR: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)
                        Else
                            a.AnadirLineasDatosFinales("VENDEDOR: " & "VARIOS")
                        End If

                        fileName = Gempresas.IdEmpresaRuc & "-" & GEstableciento.IdEstablecimiento & "-" & "FACTURA ELECTRONICA" & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & documentoBE.documentoventaAbarrotes.numeroVenta



                End Select

                'a.AnadirLineaComprobanteExtra("ASIENTO N° " & DOCUMENTOTransBE.numeroAsiento)


                precioUnit = DOCUMENTOTransBE.total
                PrecioTotal = DOCUMENTOTransBE.total


                a.AnadirLineaElementosFactura(1, $"{"SERVICIO DE TRANSPORTE EN LA"}", "UND", String.Format("{0:0.00}", DOCUMENTOTransBE.total), String.Format("{0:0.00}", 0.0), String.Format("{0:0.00}", DOCUMENTOTransBE.total))


                If (DOCUMENTOTransBE.documentoventaTransporteDetalle.FirstOrDefault.destino = "1") Then
                    a.AnadirDatosGenerales("S/", DOCUMENTOTransBE.baseImponible1)
                    a.AnadirDatosGenerales("S/", DOCUMENTOTransBE.igv1)
                    a.AnadirDatosGenerales("S/", String.Format("{0:0.00}", DOCUMENTOTransBE.total))
                    a.DESTINO = 1
                ElseIf (DOCUMENTOTransBE.documentoventaTransporteDetalle.FirstOrDefault.destino = "2") Then
                    a.AnadirDatosGenerales("S/", DOCUMENTOTransBE.total)
                    a.AnadirDatosGenerales("S/", String.Format("{0:0.00}", DOCUMENTOTransBE.total))
                    a.DESTINO = 2
                End If


                'a.DESTINO = DOCUMENTOTransBE.documentoventaTransporteDetalle.FirstOrDefault.destino

                a.AnadirLineasDatosDescripcionTotal(DOCUMENTOTransBE.total)

                a.AnadirLineasDatosFinales("")
                a.AnadirLineasDatosFinales("TERMINOS Y CONDICIONES")
                a.AnadirLineasDatosFinales("1. Postergaciones con 4 horas de anticipo")
                a.AnadirLineasDatosFinales("2. Niños mayores de (5) años pagan pasaje y ocupan")
                a.AnadirLineasDatosFinales("su asiento. Asi mismo no se venderan a menores de")
                a.AnadirLineasDatosFinales("edad que no sean identificados con su DNI y")
                a.AnadirLineasDatosFinales("autorización notarial de sus padres cuando corresponda")
                a.AnadirLineasDatosFinales("3. La empresa no se responsabiliza por la perdida de")
                a.AnadirLineasDatosFinales("equipaje en el salon. Su cuidado es exclusiva")
                a.AnadirLineasDatosFinales("responsabilidad del pasajero, Asi mismo no se")
                a.AnadirLineasDatosFinales("responsabiliza por bultos no declarados")
                a.AnadirLineasDatosFinales("4. El pasajero debe presentarse 1 hora antes de la hora")
                a.AnadirLineasDatosFinales("de viaje")
                a.AnadirLineasDatosFinales("5. El equipaje consta de maletas, maletines, mochilas y")
                a.AnadirLineasDatosFinales("bolsa de mano de uso personal")
                a.AnadirLineasDatosFinales("Autorizado mendiante resolución de SUNAT")
                a.AnadirLineasDatosFinales("Representación impresa puede ser consultado")
                a.AnadirLineasDatosFinales("http://www.spk.com.pe/")


                a.headerImagenQR = QrCodeImgControl1.Image

                'a.AnadirLineaDatos("COMP.: " & DOCUMENTOTransBE.serie & "-" & CStr(DOCUMENTOTransBE.numero).PadLeft(8, "0"c),
                '                   "FECHA: " & CDate(DOCUMENTOTransBE.fechadoc.Value).Date,
                '                  "HORA: " & CDate(DOCUMENTOTransBE.fechaProgramada.Value).ToLongTimeString,
                '              "ORIGEN: " & DOCUMENTOTransBE.ciudadOrigen,
                '                "DESTINO: " & DOCUMENTOTransBE.ciudadDestino,
                '              "ASIENTO: " & DOCUMENTOTransBE.numeroAsiento,
                '              "IMPORTE: " & DOCUMENTOTransBE.total,
                '              "PISO: " & "1")

                ''a.RUTA = DOCUMENTOTransBE.ciudadOrigen & " - " & DOCUMENTOTransBE.ciudadDestino

                ''a.DIRECIONEMBAR = DOCUMENTOTransBE.ciudadDestino

                '//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
                '//parametro de tipo string que debe de ser el nombre de la impresora. 
                If (tipoImpresion = "PDF") Then

                    Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)
                    If (fileUbicacion.Length > 0) Then

                        Dim myProcess As New Process
                        Dim PathShell As String = fileUbicacion

                        myProcess.StartInfo.FileName = PathShell
                        myProcess.StartInfo.UseShellExecute = True
                        myProcess.StartInfo.RedirectStandardOutput = False
                        myProcess.Start()
                        myProcess.Dispose()

                    Else
                        MessageBox.Show("VERIFICAR DOCUMENTO A ENVIAR")
                    End If

                ElseIf (tipoImpresion = "GUARDAR") Then
                    Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)

                ElseIf (tipoImpresion = "DIRECTO") Then
                    a.tipoComprobante = "2"
                    a.ImprimeTicket(imprimir, txtNroImpresion.DecimalValue)
                End If


        End Select



    End Sub


    Sub ImprimirTicketA4(imprimir As String, intIdDocumento As Integer, NumeroImpresion As Integer, Impresiontipo As String)
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
        Dim nombreComprabante As String = String.Empty
        '  Dim r As Record = dgPedidos.Table.CurrentRecord
        Dim entidadSA As New entidadSA

        Dim tipocomprobante As String = String.Empty

        Dim fileName As String = String.Empty

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
                            Telefono)


        Select Case documentoBE.documentoventaAbarrotes.tipoDocumento
            Case "12.1"
                '//DATOS GENERALES RUC - SERIE NUMERO Y TIPO documentoBE.documentoventaAbarrotes
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "BOLETA"
            Case "12.2"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "FACTURA"
            Case "03"
                If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA ELECTRONICA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "2"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "BOLETA ELECTRONICA"
                ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "1"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "BOLETA"
                End If
            Case "01"
                If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA ELECTRONICA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "2"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "FACTURA ELECTRONICA"
                ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "1"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "FACTURA"
                End If
            Case "9903"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "COTIZACIÓN")
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "COTIZACIÓN"
            Case Else
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "NOTA")
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "NOTA"
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

        If (ChecDomicilio.Checked = False) Then
            entidad.direccion = documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada
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

        If (Impresiontipo = "PDF") Then

            'Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)

            'Dim ubicacionFile As String = String.Empty
            'Dim formulario As New formVerPDF(fileUbicacion)
            'formulario.BringToFront()
            'formulario.Show()

            Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)
            If (fileUbicacion.Length > 0) Then

                Dim myProcess As New Process
                Dim PathShell As String = fileUbicacion

                myProcess.StartInfo.FileName = PathShell
                myProcess.StartInfo.UseShellExecute = True
                myProcess.StartInfo.RedirectStandardOutput = False
                myProcess.Start()
                myProcess.Dispose()

            Else
                MessageBox.Show("VERIFICAR DOCUMENTO A ENVIAR")
            End If

        ElseIf (Impresiontipo = "ENVIAR") Then
            Dim cliente As String = NBoletaElectronica
            Dim Monto As String = documentoBE.documentoventaAbarrotes.ImporteNacional.GetValueOrDefault
            Dim FechaEmision As String = documentoBE.documentoventaAbarrotes.fechaDoc.Value.ToShortDateString()
            Dim param1 As String = ""
            param1 = Chr(34) & "width:100%" & Chr(34)
            Dim param2 As String = Chr(34) & "http://www.spk.com.pe" & Chr(34)
            Dim param3 As String = Chr(34) & "_blank" & Chr(34)
            Dim textoEnviar = "<!DOCTYPE html>
<html>
<head>
    <title>FACTURA ELECTRÓNICA</title>
</head>
<body>
    <header>
        <h3>Estimado cliente: " & cliente & "</h3>
    </header>

    <section>
        <article>
            <div>
                <p>Informamos a usted que el documento " & nombreComprabante & " ya se encuentra disponible.</p>

            </div>
        </article>
    </section>

    <table style=" & param1 & ">
        <tr>
            <td>Tipo</td>
            <td>:</td>
            <td>" & tipocomprobante & "</td>
        </tr>
        <tr>
            <td>Numero</td>
            <td>:</td>
            <td>" & nombreComprabante & "</td>
        </tr>
        <tr>
            <td>Monto</td>
            <td>:</td>
            <td>S/." & Monto & "</td>
        </tr>
        <tr>
            <td>Fecha de emisión</td>
            <td>:</td>
            <td>" & FechaEmision & " </td>
        </tr>
        <tr>
            <td>Este documento puede ser validado en el URL</td>
            <td>:</td>
         <td ><a href=" & param2 & " target=" & param3 & "> http://www.spk.com.pe</a></td>
        </tr>

    </table>
    <BR />

    <p>Saluda atentamente,</p>
    <p>
        SOFTPACK ERP.
    </p>

</body>
</html>"
            Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)
            If (fileUbicacion.Length > 0) Then
                Dim f As New FormEnviarCorreo(objDatosGenrales, cboFormato.SelectedValue, fileUbicacion, fileName)
                f.TextBoxASUNTO.Text = "SoftPack Facturación Electrónica"
                f.cargardatosPrevios(textoEnviar)
                f.documentoBE = documentoBE
                f.StartPosition = FormStartPosition.CenterScreen
                f.ShowDialog()
            Else
                MessageBox.Show("VERIFICAR DOCUMENTO A ENVIAR")
            End If
        ElseIf (Impresiontipo = "GUARDAR") Then
            a.ImprimeTicket(imprimir, 1)
        ElseIf (Impresiontipo = "DIRECTO") Then
            a.ImprimeTicket(imprimir, NumeroImpresion)

        End If

    End Sub

    Sub ImprimirTicketA4v5(imprimir As String, intIdDocumento As Integer, NumeroImpresion As Integer, impresionTipo As String)
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
        Dim nombreComprabante As String = String.Empty
        '  Dim r As Record = dgPedidos.Table.CurrentRecord
        Dim entidadSA As New entidadSA
        'Dim documentoSA As New documentoVentaAbarrotesSA
        'Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        'Dim documentoBE.documentoventaAbarrotes = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
        'Dim documentoBE.documentoventaAbarrotesDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
        Dim tipocomprobante As String = String.Empty
        Dim fileName As String = String.Empty

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
                            Telefono)


        Select Case documentoBE.documentoventaAbarrotes.tipoDocumento
            Case "12.1"
                '//DATOS GENERALES RUC - SERIE NUMERO Y TIPO documentoBE.documentoventaAbarrotes
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "BOLETA"
            Case "12.2"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "FACTURA"
            Case "03"
                If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA ELECTRONICA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "2"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "BOLETA ELECTRONICA"
                ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "1"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "BOLETA"
                End If
            Case "01"
                If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA ELECTRONICA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "2"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "FACTURA ELECTRONICA"
                ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "1"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "FACTURA"
                End If
            Case "9903"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "COTIZACIÓN")
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "COTIZACIÓN"
            Case Else
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "NOTA")
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "NOTA"
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

        If (ChecDomicilio.Checked = False) Then
            entidad.direccion = documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada
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
                                          "-")

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

        If (impresionTipo = "PDF") Then

            Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)
            If (fileUbicacion.Length > 0) Then

                Dim myProcess As New Process
                Dim PathShell As String = fileUbicacion

                myProcess.StartInfo.FileName = PathShell
                myProcess.StartInfo.UseShellExecute = True
                myProcess.StartInfo.RedirectStandardOutput = False
                myProcess.Start()
                myProcess.Dispose()

            Else
                MessageBox.Show("VERIFICAR DOCUMENTO A ENVIAR")
            End If

        ElseIf (impresionTipo = "ENVIAR") Then
            Dim cliente As String = NBoletaElectronica
            Dim Monto As String = documentoBE.documentoventaAbarrotes.ImporteNacional.GetValueOrDefault
            Dim FechaEmision As String = documentoBE.documentoventaAbarrotes.fechaDoc.Value.ToShortDateString()
            Dim param1 As String = ""
            param1 = Chr(34) & "width:100%" & Chr(34)
            Dim param2 As String = Chr(34) & "http://www.spk.com.pe" & Chr(34)
            Dim param3 As String = Chr(34) & "_blank" & Chr(34)

            Dim textoEnviar = "<!DOCTYPE html>
<html>
<head>
    <title>FACTURA ELECTRÓNICA</title>
</head>
<body>
    <header>
        <h3>Estimado cliente: " & cliente & "</h3>
    </header>

    <section>
        <article>
            <div>
                <p>Informamos a usted que el documento " & nombreComprabante & " ya se encuentra disponible.</p>

            </div>
        </article>
    </section>

    <table style=" & param1 & ">
        <tr>
            <td>Tipo</td>
            <td>:</td>
            <td>" & tipocomprobante & "</td>
        </tr>
        <tr>
            <td>Numero</td>
            <td>:</td>
            <td>" & nombreComprabante & "</td>
        </tr>
        <tr>
            <td>Monto</td>
            <td>:</td>
            <td>S/." & Monto & "</td>
        </tr>
        <tr>
            <td>Fecha de emisión</td>
            <td>:</td>
            <td>" & FechaEmision & " </td>
        </tr>
        <tr>
            <td>Este documento puede ser validado en el URL</td>
            <td>:</td>
            <td ><a href=" & param2 & " target=" & param3 & "> http://www.spk.com.pe</a></td>
        </tr>

    </table>
    <BR />

    <p>Saluda atentamente,</p>
    <p>
        SOFTPACK ERP.
    </p>

</body>
</html>"
            Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)
            If (fileUbicacion.Length > 0) Then
                Dim f As New FormEnviarCorreo(objDatosGenrales, cboFormato.SelectedValue, fileUbicacion, fileName)
                f.TextBoxASUNTO.Text = "SoftPack Facturación Electrónica"
                f.cargardatosPrevios(textoEnviar)
                f.documentoBE = documentoBE
                f.StartPosition = FormStartPosition.CenterScreen
                f.ShowDialog()
            Else
                MessageBox.Show("VERIFICAR DOCUMENTO A ENVIAR")
            End If

        ElseIf (impresionTipo = "GUARDAR") Then
            a.ImprimeTicket(imprimir, 1)
        ElseIf (impresionTipo = "DIRECTO") Then
            a.ImprimeTicket(imprimir, NumeroImpresion)
        End If

    End Sub

    Sub ImprimirTicketA4_MATRICIAL(imprimir As String, intIdDocumento As Integer, NumeroImpresion As Integer, impresionTipo As String)
        Dim a As TicketA4_Matricial = New TicketA4_Matricial
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
        Dim nombreComprabante As String = String.Empty
        '  Dim r As Record = dgPedidos.Table.CurrentRecord
        Dim entidadSA As New entidadSA
        'Dim documentoSA As New documentoVentaAbarrotesSA
        'Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        'Dim documentoBE.documentoventaAbarrotes = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
        'Dim documentoBE.documentoventaAbarrotesDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
        Dim tipocomprobante As String = String.Empty
        Dim fileName As String = String.Empty

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
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "BOLETA"
            Case "12.2"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "FACTURA"
            Case "03"
                If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA ELECTRONICA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "2"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "BOLETA ELECTRONICA"
                ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "1"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "BOLETA"
                End If
            Case "01"
                If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA ELECTRONICA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "2"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "FACTURA ELECTRONICA"
                ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "1"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "FACTURA"
                End If
            Case "9903"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "COTIZACIÓN")
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "COTIZACIÓN"
            Case Else
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "NOTA")
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "NOTA"
        End Select

        Dim NBoletaElectronica As String = String.Empty

        If documentoBE.documentoventaAbarrotes.idCliente <> 0 Then
            Dim entidad = documentoBE.documentoventaAbarrotes.CustomEntidad ' entidadSA.UbicarEntidadPorID(documentoBE.documentoventaAbarrotes.idCliente).FirstOrDefault
            NBoletaElectronica = entidad.nombreCompleto
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

            If (ChecDomicilio.Checked = False) Then
                entidad.direccion = documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada
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


        Else
            NBoletaElectronica = documentoBE.documentoventaAbarrotes.nombrePedido
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
            a.AnadirLineaCaracteresDatosGEnerales(documentoBE.documentoventaAbarrotes.fechaDoc.Value.ToShortDateString(),
                                              "",
                                              NBoletaElectronica,
                                             "",
                                             "",
                                              "",
                                              "PEN",
                                              "")

            'Codigo qr
            QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                      "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & "VARIOS" & "|" & "0")

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

        Select Case tipocomprobante
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



        If (impresionTipo = "PDF") Then

            Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)
            If (fileUbicacion.Length > 0) Then

                Dim myProcess As New Process
                Dim PathShell As String = fileUbicacion

                myProcess.StartInfo.FileName = PathShell
                myProcess.StartInfo.UseShellExecute = True
                myProcess.StartInfo.RedirectStandardOutput = False
                myProcess.Start()
                myProcess.Dispose()

            Else
                MessageBox.Show("VERIFICAR DOCUMENTO A ENVIAR")
            End If

        ElseIf (impresionTipo = "ENVIAR") Then
            Dim cliente As String = NBoletaElectronica
            Dim Monto As String = documentoBE.documentoventaAbarrotes.ImporteNacional.GetValueOrDefault
            Dim FechaEmision As String = documentoBE.documentoventaAbarrotes.fechaDoc.Value.ToShortDateString()
            Dim param1 As String = ""
            param1 = Chr(34) & "width:100%" & Chr(34)
            Dim param2 As String = Chr(34) & "http://www.spk.com.pe" & Chr(34)
            Dim param3 As String = Chr(34) & "_blank" & Chr(34)
            Dim textoEnviar = "<!DOCTYPE html>
<html>
<head>
    <title>FACTURA ELECTRÓNICA</title>
</head>
<body>
    <header>
        <h3>Estimado cliente: " & cliente & "</h3>
    </header>

    <section>
        <article>
            <div>
                <p>Informamos a usted que el documento " & nombreComprabante & " ya se encuentra disponible.</p>

            </div>
        </article>
    </section>

    <table style=" & param1 & ">
        <tr>
            <td>Tipo</td>
            <td>:</td>
            <td>" & tipocomprobante & "</td>
        </tr>
        <tr>
            <td>Numero</td>
            <td>:</td>
            <td>" & nombreComprabante & "</td>
        </tr>
        <tr>
            <td>Monto</td>
            <td>:</td>
            <td>S/." & Monto & "</td>
        </tr>
        <tr>
            <td>Fecha de emisión</td>
            <td>:</td>
            <td>" & FechaEmision & " </td>
        </tr>
        <tr>
            <td>Este documento puede ser validado en el URL</td>
            <td>:</td>
            <td ><a href=" & param2 & " target=" & param3 & "> http://www.spk.com.pe</a></td>
        </tr>

    </table>
    <BR />

    <p>Saluda atentamente,</p>
    <p>
        SOFTPACK ERP.
    </p>

</body>
</html>"
            Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)
            If (fileUbicacion.Length > 0) Then
                Dim f As New FormEnviarCorreo(objDatosGenrales, cboFormato.SelectedValue, fileUbicacion, fileName)
                f.TextBoxASUNTO.Text = "SoftPack Facturación Electrónica"
                f.cargardatosPrevios(textoEnviar)
                f.documentoBE = documentoBE
                f.StartPosition = FormStartPosition.CenterScreen
                f.ShowDialog()
            Else
                MessageBox.Show("VERIFICAR DOCUMENTO A ENVIAR")
            End If

        ElseIf (impresionTipo = "GUARDAR") Then
            a.ImprimeTicket(imprimir, 1)
        ElseIf (impresionTipo = "DIRECTO") Then
            a.ImprimeTicket(imprimir, NumeroImpresion)
        End If

    End Sub

    Sub ImprimirTicketA4Formato2(imprimir As String, intIdDocumento As Integer, numeroImpresion As Integer, ImpresionTipo As String)
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
        Dim fileName As String = String.Empty
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
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "BOLETA"
            Case "12.2"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "FACTURA"
            Case "03"
                If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA ELECTRONICA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "2"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "BOLETA ELECTRONICA"
                ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "1"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "BOLETA"
                End If
            Case "01"
                If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA ELECTRONICA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "2"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "FACTURA ELECTRONICA"
                ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "1"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "FACTURA"
                End If
            Case "9903"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "COTIZACIÓN")
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "COTIZACIÓN"
            Case Else
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "NOTA")
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "NOTA"
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

        If (ChecDomicilio.Checked = False) Then
            entidad.direccion = documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada
        End If

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

        If (ImpresionTipo = "PDF") Then

            Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)
            If (fileUbicacion.Length > 0) Then

                Dim myProcess As New Process
                Dim PathShell As String = fileUbicacion

                myProcess.StartInfo.FileName = PathShell
                myProcess.StartInfo.UseShellExecute = True
                myProcess.StartInfo.RedirectStandardOutput = False
                myProcess.Start()
                myProcess.Dispose()

            Else
                MessageBox.Show("VERIFICAR DOCUMENTO A ENVIAR")
            End If

        ElseIf (ImpresionTipo = "ENVIAR") Then
            Dim cliente As String = NBoletaElectronica
            Dim Monto As String = documentoBE.documentoventaAbarrotes.ImporteNacional.GetValueOrDefault
            Dim FechaEmision As String = documentoBE.documentoventaAbarrotes.fechaDoc.Value.ToShortDateString()
            Dim param1 As String = ""
            param1 = Chr(34) & "width:100%" & Chr(34)
            Dim param2 As String = Chr(34) & "http://www.spk.com.pe" & Chr(34)
            Dim param3 As String = Chr(34) & "_blank" & Chr(34)
            Dim textoEnviar = "<!DOCTYPE html>
<html>
<head>
    <title>FACTURA ELECTRÓNICA</title>
</head>
<body>
    <header>
        <h3>Estimado cliente: " & cliente & "</h3>
    </header>

    <section>
        <article>
            <div>
                <p>Informamos a usted que el documento " & nombreComprabante & " ya se encuentra disponible.</p>

            </div>
        </article>
    </section>

    <table style=" & param1 & ">
        <tr>
            <td>Tipo</td>
            <td>:</td>
            <td>" & tipocomprobante & "</td>
        </tr>
        <tr>
            <td>Numero</td>
            <td>:</td>
            <td>" & nombreComprabante & "</td>
        </tr>
        <tr>
            <td>Monto</td>
            <td>:</td>
            <td>S/." & Monto & "</td>
        </tr>
        <tr>
            <td>Fecha de emisión</td>
            <td>:</td>
            <td>" & FechaEmision & " </td>
        </tr>
        <tr>
            <td>Este documento puede ser validado en el URL</td>
            <td>:</td>
            <td ><a href=" & param2 & " target=" & param3 & "> http://www.spk.com.pe</a></td>
        </tr>

    </table>
    <BR />

    <p>Saluda atentamente,</p>
    <p>
        SOFTPACK ERP.
    </p>

</body>
</html>"
            Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)
            If (fileUbicacion.Length > 0) Then
                Dim f As New FormEnviarCorreo(objDatosGenrales, cboFormato.SelectedValue, fileUbicacion, fileName)
                f.TextBoxASUNTO.Text = "SoftPack Facturación Electrónica"
                f.cargardatosPrevios(textoEnviar)
                f.documentoBE = documentoBE
                f.StartPosition = FormStartPosition.CenterScreen
                f.ShowDialog()
            Else
                MessageBox.Show("VERIFICAR DOCUMENTO A ENVIAR")
            End If

        ElseIf (ImpresionTipo = "GUARDAR") Then
            a.ImprimeTicket(imprimir, 1)
        ElseIf (ImpresionTipo = "DIRECTO") Then
            a.ImprimeTicket(imprimir, numeroImpresion)
        End If

    End Sub



    Sub ImprimirTicketA4Formato6(imprimir As String, intIdDocumento As Integer, numeroImpresion As Integer, impresionTipo As String)
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
        Dim nombreComprabante As String = String.Empty
        '  Dim r As Record = dgPedidos.Table.CurrentRecord
        Dim entidadSA As New entidadSA
        'Dim documentoSA As New documentoVentaAbarrotesSA
        'Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        'Dim documentoBE.documentoventaAbarrotes = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
        'Dim documentoBE.documentoventaAbarrotesDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
        Dim tipocomprobante As String = String.Empty
        Dim fileName As String = String.Empty

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
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "BOLETA"
            Case "12.2"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "FACTURA"
            Case "03"
                If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA ELECTRONICA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "2"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "BOLETA ELECTRONICA"
                ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "1"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "BOLETA"
                End If
            Case "01"
                If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA ELECTRONICA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "2"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "FACTURA ELECTRONICA"
                ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "1"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "FACTURA"
                End If
            Case "9903"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "COTIZACIÓN")
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "COTIZACIÓN"
            Case Else
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "NOTA")
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "NOTA"
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

        If (ChecDomicilio.Checked = False) Then
            entidad.direccion = documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada
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

        If (impresionTipo = "PDF") Then

            Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)
            If (fileUbicacion.Length > 0) Then

                Dim myProcess As New Process
                Dim PathShell As String = fileUbicacion

                myProcess.StartInfo.FileName = PathShell
                myProcess.StartInfo.UseShellExecute = True
                myProcess.StartInfo.RedirectStandardOutput = False
                myProcess.Start()
                myProcess.Dispose()

            Else
                MessageBox.Show("VERIFICAR DOCUMENTO A ENVIAR")
            End If

        ElseIf (impresionTipo = "ENVIAR") Then
            Dim cliente As String = NBoletaElectronica
            Dim Monto As String = documentoBE.documentoventaAbarrotes.ImporteNacional.GetValueOrDefault
            Dim FechaEmision As String = documentoBE.documentoventaAbarrotes.fechaDoc.Value.ToShortDateString()
            Dim param1 As String = ""
            param1 = Chr(34) & "width:100%" & Chr(34)
            Dim param2 As String = Chr(34) & "http://www.spk.com.pe" & Chr(34)
            Dim param3 As String = Chr(34) & "_blank" & Chr(34)
            Dim textoEnviar = "<!DOCTYPE html>
<html>
<head>
    <title>FACTURA ELECTRÓNICA</title>
</head>
<body>
    <header>
        <h3>Estimado cliente: " & cliente & "</h3>
    </header>

    <section>
        <article>
            <div>
                <p>Informamos a usted que el documento " & nombreComprabante & " ya se encuentra disponible.</p>

            </div>
        </article>
    </section>

    <table style=" & param1 & ">
        <tr>
            <td>Tipo</td>
            <td>:</td>
            <td>" & tipocomprobante & "</td>
        </tr>
        <tr>
            <td>Numero</td>
            <td>:</td>
            <td>" & nombreComprabante & "</td>
        </tr>
        <tr>
            <td>Monto</td>
            <td>:</td>
            <td>S/." & Monto & "</td>
        </tr>
        <tr>
            <td>Fecha de emisión</td>
            <td>:</td>
            <td>" & FechaEmision & " </td>
        </tr>
        <tr>
            <td>Este documento puede ser validado en el URL</td>
            <td>:</td>
            <td ><a href=" & param2 & " target=" & param3 & "> http://www.spk.com.pe</a></td>
        </tr>

    </table>
    <BR />

    <p>Saluda atentamente,</p>
    <p>
        SOFTPACK ERP.
    </p>

</body>
</html>"
            Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)
            If (fileUbicacion.Length > 0) Then
                Dim f As New FormEnviarCorreo(objDatosGenrales, cboFormato.SelectedValue, fileUbicacion, fileName)
                f.TextBoxASUNTO.Text = "SoftPack Facturación Electrónica"
                f.cargardatosPrevios(textoEnviar)
                f.documentoBE = documentoBE
                f.StartPosition = FormStartPosition.CenterScreen
                f.ShowDialog()
            Else
                MessageBox.Show("VERIFICAR DOCUMENTO A ENVIAR")
            End If

        ElseIf (impresionTipo = "GUARDAR") Then
            a.ImprimeTicket(imprimir, 1)
        ElseIf (impresionTipo = "DIRECTO") Then
            a.ImprimeTicket(imprimir, numeroImpresion)
        End If

    End Sub

    Sub ImprimirTicketA4_NotaCredito(imprimir As String, intIdDocumento As Integer, numeroImpresion As Integer)
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

        a.AnadirLineaDatosComplementarios(comprobante.fechaDoc,
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
                                      i.nombreItem,
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
        'BOLSA
        a.AnadirDatosGenerales("S/", comprobante.icbper.GetValueOrDefault)
        'IMPORTE TOTAL
        a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.ImporteNacional.GetValueOrDefault)


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


        Select Case tipoComprobante
            Case "1"
                a.tipoComprobante = "1"
                a.ImprimeTicket(imprimir, numeroImpresion)
            Case "2"
                a.tipoComprobante = "2"
                a.ImprimeTicket(imprimir, numeroImpresion)
        End Select


    End Sub


    Sub ImprimirTicketA5(imprimir As String, intIdDocumento As Integer, numeroImpresion As Integer, impresionTipo As String)
        Dim a As TicketA5 = New TicketA5
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
        Dim fileName As String = String.Empty

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
            Telefono = (objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3)
        ElseIf (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length = 0 And objDatosGenrales.telefono4.Length = 0) Then
            Telefono = (objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
        ElseIf (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length > 0 And objDatosGenrales.telefono4.Length > 0) Then
            Telefono = (objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3 & " - " & objDatosGenrales.telefono4)
        Else
            Telefono = (objDatosGenrales.telefono1)
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
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
            Case "12.2"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                nombreComprabante = "FACTURA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                tipocomprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
            Case "03"
                If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA ELECTRONICA")
                    nombreComprabante = "BOLETA ELECTRONICA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipocomprobante = "2"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                    nombreComprabante = "BOLETA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipocomprobante = "1"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                End If
            Case "01"
                If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA ELECTRONICA")
                    nombreComprabante = "FACTURA ELECTRONICA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipocomprobante = "2"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                    nombreComprabante = "FACTURA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipocomprobante = "1"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                End If
            Case "9903"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "COTIZACIÓN")
                nombreComprabante = "COTIZACIÓN" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                tipocomprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
            Case Else
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "NOTA")
                nombreComprabante = "NOTA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                tipocomprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
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
        Dim consultaVEndedro = (From ven In UsuariosList Where ven.IDUsuario = documentoBE.documentoventaAbarrotes.usuarioActualizacion).FirstOrDefault
        'a.AnadirLineaCaracteresDatosGEnerales(documentoBE.documentoventaAbarrotes.fechaDoc.Value.ToShortDateString(),
        '                                  "",
        '                                  NBoletaElectronica,
        '                                 entidad.direccion,
        '                                 documentoBE.documentoventaAbarrotes.nombrePedido,
        '                                  nBoletaNumero,
        '                                  "SOLES",
        '                                  tienda)

        If (ChecDomicilio.Checked = False) Then
            entidad.direccion = documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada
        End If

        a.AnadirLineaCaracteresDatosGEnerales(documentoBE.documentoventaAbarrotes.fechaDoc.Value.ToShortDateString(),
                                              "",
                                              NBoletaElectronica,
                                             entidad.direccion,
                                             consultaVEndedro.Nombres & " " & consultaVEndedro.ApellidoPaterno & " " & consultaVEndedro.ApellidoMaterno,
                                              nBoletaNumero,
                                              "SOLES",
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


            'a.AnadirLineaElementosFactura(numeracion,
            '                          i.nombreItem,
            '                          i.monto1,
            '                          i.CustomEquivalencia.unidadComercial,
            '                          (i.montokardex) / i.monto1,
            '                          "0.00",
            '                          i.montokardex,
            '                          "0.00",
            '                          i.montoIgv,
            '                          i.importeMN / i.monto1,
            '                          i.importeMN)

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


        If (impresionTipo = "PDF") Then

            Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)
            If (fileUbicacion.Length > 0) Then

                Dim myProcess As New Process
                Dim PathShell As String = fileUbicacion

                myProcess.StartInfo.FileName = PathShell
                myProcess.StartInfo.UseShellExecute = True
                myProcess.StartInfo.RedirectStandardOutput = False
                myProcess.Start()
                myProcess.Dispose()

            Else
                MessageBox.Show("VERIFICAR DOCUMENTO A ENVIAR")
            End If

        ElseIf (impresionTipo = "GUARDAR") Then
            a.ImprimeTicket(imprimir, 1)
        ElseIf (impresionTipo = "DIRECTO") Then
            a.ImprimeTicket(imprimir, numeroImpresion)
        End If

    End Sub

    'Sub ImprimirTicketDevolucionA4Formato2(imprimir As String, intIdDocumento As Integer, numeroImpresion As Integer)
    '    Dim a As TicketNotaA4v2 = New TicketNotaA4v2
    '    ' Logo de la Empresa
    '    Dim lista As New List(Of String)
    '    Dim numero As Integer = 1
    '    Dim gravMN As Decimal = 0
    '    Dim gravME As Decimal = 0
    '    Dim ExoMN As Decimal = 0
    '    Dim ExoME As Decimal = 0
    '    Dim InaMN As Decimal = 0
    '    Dim InaME As Decimal = 0
    '    Dim ticket As New CrearTicket()
    '    Dim nombreComprabante As String
    '    '  Dim r As Record = dgPedidos.Table.CurrentRecord
    '    Dim entidadSA As New entidadSA
    '    Dim documentoSA As New documentoVentaAbarrotesSA
    '    Dim documentoDetSA As New documentoVentaAbarrotesDetSA

    '    ''Dim documentoBE.documentoventaAbarrotes = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
    '    'Dim documentoBE.documentoventaAbarrotesDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
    '    ''Dim documentoBE.documentoventaAbarrotesPadre = documentoSA.GetUbicar_documentoventaAbarrotesPorIDPadre(intIdDocumento)
    '    Dim tipocomprobante As String = String.Empty
    '    'Dim documentoBE.documentoventaAbarrotes = documentoSA.GetUbicar_NotaXID(intIdDocumento)
    '    If My.Computer.Network.IsAvailable = True Then
    '        If My.Computer.Network.Ping("148.102.27.231") Then
    '            If (documentoBE.documentoventaAbarrotes.tipoDocumento = "01" And documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Or (documentoBE.documentoventaAbarrotes.tipoDocumento = "07" And documentoBE.documentoventaAbarrotes.tipoVenta = "NTCE") Then
    '                XmlFactura(documentoBE.documentoventaAbarrotes, documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet)
    '            End If
    '        End If
    '    End If
    '    'Dim rucCliente As String
    '    If (objDatosGenrales.logo.Length > 0) Then
    '        '//POSISCION DE LA IMAGEN
    '        a.PosicionLogo = objDatosGenrales.posicionLogo
    '        ' Logo de la Empresa
    '        a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
    '    End If

    '    '//DATOS GENERALES DE LA EMPRESA
    '    Dim Telefono As String = String.Empty
    '    If (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length > 0 And objDatosGenrales.telefono4.Length = 0) Then
    '        Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3)
    '    ElseIf (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length = 0 And objDatosGenrales.telefono4.Length = 0) Then
    '        Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
    '    ElseIf (objDatosGenrales.telefono2.Length > 0 And objDatosGenrales.telefono1.Length > 0 And objDatosGenrales.telefono3.Length > 0 And objDatosGenrales.telefono4.Length > 0) Then
    '        Telefono = ("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3 & " - " & objDatosGenrales.telefono4)
    '    Else
    '        Telefono = ("TELF: " & objDatosGenrales.telefono1)
    '    End If

    '    a.AnadirLineaEmpresa(objDatosGenrales.razonSocial,
    '                        objDatosGenrales.nombreCorto,
    '                        "Domicilio Fiscal: " & objDatosGenrales.direccionPrincipal,
    '                        "Establ. Anexo: " & objDatosGenrales.direccionSecudaria,
    '                        "Telf: " & Telefono)


    '    Select Case documentoBE.documentoventaAbarrotes.tipoDocumento
    '        Case "07"
    '            '//DATOS GENERALES RUC - SERIE NUMERO Y TIPO documentoBE.documentoventaAbarrotes
    '            a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
    '                                   documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
    '                                   "NOTA DE CREDITO")
    '            nombreComprabante = "NOTA DE CREDITO" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
    '            tipocomprobante = "2"
    '    End Select

    '    If documentoBE.documentoventaAbarrotes.idCliente <> 0 Then
    '        Dim entidad = entidadSA.UbicarEntidadPorID(documentoBE.documentoventaAbarrotes.idCliente).FirstOrDefault
    '        Dim NBoletaElectronica As String = entidad.nombreCompleto
    '        Dim nBoletaNumero As String
    '        'ticket.TextoIzquierda(NBoletaElectronica)
    '        If entidad.nrodoc.Trim.Length = 11 Then
    '            nBoletaNumero = "R.U.C. - " & entidad.nrodoc
    '        ElseIf entidad.nrodoc.Trim.Length = 8 Then
    '            nBoletaNumero = "D.N.I. - " & entidad.nrodoc
    '        Else
    '            nBoletaNumero = entidad.nrodoc
    '        End If

    '        '//DATOS DEL CLIENTE
    '        'Fecha de Factura
    '        'Lugar de la factura
    '        'Nombre del cliente
    '        'direccion del cliente
    '        'numero del cliente
    '        'direccion de entrega
    '        'tipo moneda de la empresa
    '        'telefono de la empresa
    '        a.AnadirLineaCaracteresDatosGEnerales(documentoBE.documentoventaAbarrotes.fechaDoc.Value.ToShortDateString(),
    '                                          "",
    '                                          NBoletaElectronica,
    '                                         entidad.direccion,
    '                                         documentoBE.documentoventaAbarrotes.nombrePedido,
    '                                          nBoletaNumero,
    '                                          "PEN",
    '                                          tienda)

    '        If (Not IsNothing(HASH)) Then
    '            If HASH.Trim.Length > 0 Then
    '                QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
    '                      "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
    '                      "|" & HASH & "|" & CERTIFICADO)

    '                QrCodeImgControl1.Text = QR
    '            Else
    '                QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
    '                     "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

    '                QrCodeImgControl1.Text = QR
    '            End If
    '        Else
    '            QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
    '                 "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

    '            QrCodeImgControl1.Text = QR
    '        End If


    '    Else
    '        Dim NBoletaElectronica As String = documentoBE.documentoventaAbarrotes.nombrePedido
    '        'ticket.TextoIzquierda(NBoletaElectronica)
    '        'Fecha de Factura
    '        'Lugar de la factura
    '        'Nombre del cliente
    '        'direccion del cliente
    '        'numero del cliente
    '        'direccion de entrega
    '        'tipo moneda de la empresa
    '        'telefono de la empresa
    '        '//DATOS DEL CLIENTE
    '        'Fecha de Factura
    '        'Lugar de la factura
    '        'Nombre del cliente
    '        'direccion del cliente
    '        'numero del cliente
    '        'direccion de entrega
    '        'tipo moneda de la empresa
    '        'telefono de la empresa
    '        a.AnadirLineaCaracteresDatosGEnerales(documentoBE.documentoventaAbarrotes.fechaDoc.Value.ToShortDateString(),
    '                                          "",
    '                                          NBoletaElectronica,
    '                                         "",
    '                                         "",
    '                                          "",
    '                                          "PEN",
    '                                         tienda)

    '        'Codigo qr
    '        QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
    '                  "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & "VARIOS" & "|" & "0")

    '        QrCodeImgControl1.Text = QR
    '    End If


    '    '//DATOS COMPLEMENTARIOS
    '    'Nro. Pedido
    '    'Fecha Pedido
    '    'Orden de compra
    '    'fecha de Orden de Compra
    '    'Guia de remisiionm
    '    'FEcha de guia de remisuion
    '    'forma de venta
    '    'Tipo de Venta

    '    Dim tipoEmision As String = String.Empty

    '    'Select Case documentoBE.documentoventaAbarrotes.estadoCobro
    '    '    Case "DC"
    '    '        tipoVenta = "CONTADO"
    '    '    Case "PN"
    '    '        tipoVenta = "CREDITO"
    '    'End Select

    '    Select Case documentoBE.documentoventaAbarrotes.notaCredito
    '        Case "01"
    '            tipoEmision = "Anulación de la Operación"
    '        Case "02"
    '            tipoEmision = "Anulación por error en el RUC"
    '        Case "03"
    '            tipoEmision = "Anulación por error en la descripción"
    '        Case "04"
    '            tipoEmision = "Descuento global"
    '        Case "05"
    '            tipoEmision = "Descuento por item"
    '        Case "06"
    '            tipoEmision = "devolución total"
    '        Case "07"
    '            tipoEmision = "devolución por item"
    '        Case "08"
    '            tipoEmision = "Bonificación"
    '        Case "09"
    '            tipoEmision = "disminución en el valor"
    '        Case "10"
    '            tipoEmision = "Otros conceptos"
    '        Case "11"
    '            tipoEmision = "Ajustes de Operaciones de exportación"
    '    End Select

    '    Dim NombredocumentoBE.documentoventaAbarrotes As String = String.Empty
    '    Select Case documentoBE.documentoventaAbarrotes.TipoDocNota
    '        Case "01"
    '            NombredocumentoBE.documentoventaAbarrotes = "FACTURA ELECTRONICA"
    '        Case "02"
    '            NombredocumentoBE.documentoventaAbarrotes = "BOLETA ELECTRONICA"
    '    End Select

    '    '//DATOS COMPLEMENTARIOS
    '    'Nro. Pedido
    '    'Fecha Pedido
    '    'Orden de compra
    '    'fecha de Orden de Compra
    '    'Guia de remisiionm
    '    'FEcha de guia de remisuion
    '    'MOTIVO DE EMISION
    '    'TIPO DOC
    '    'NRO DOCUMENTO

    '    Dim numeroafect As String = String.Format("{0:00000000}", documentoBE.documentoventaAbarrotes.numeroDoc)

    '    a.AnadirLineaDatosComplementarios(CDate(documentoBE.documentoventaAbarrotes.FechaNota).Date.ToString(FormatoFecha),
    '                                          "-",
    '                                         documentoBE.documentoventaAbarrotes.nroOrdenVenta,
    '                                          "-",
    '                                          documentoBE.documentoventaAbarrotes.nroGuia,
    '                                          "-",
    '                                          tipoEmision,
    '                                      NombredocumentoBE.documentoventaAbarrotes,
    '                                      documentoBE.documentoventaAbarrotes.serie & "-" & numeroafect)

    '    '//DATOS DE LOS DETALLES DE LOS ITEMS
    '    '*********************** TODO LOS DETALLES DE LOS ITEM *********************
    '    'CODIGO
    '    'DESCRIPCION
    '    'CANTIDAD
    '    'UM
    '    'VALOR VENTA UNITARIO
    '    'DESCUENTO
    '    'VALOR DE VENTA TOTAL
    '    'OTROS CARGOS
    '    'IMPUESTOS
    '    'PRECIO DE VENTA
    '    'VALOR TOTAL


    '    For Each i In documentoBE.documentoventaAbarrotesDetalle

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

    '        a.AnadirLineaElementosFactura(numero,
    '                                  i.nombreItem,
    '                                  CInt(i.monto1),
    '                                  i.CustomEquivalencia.unidadComercial,
    '                                  "0.00",
    '                                  "0.00",
    '                                  i.montokardex,
    '                                  "0.00",
    '                                  i.montoIgv,
    '                                  i.importeMN,
    '                                  i.importeMN)

    '        numero += 1

    '    Next

    '    a.AnadirLineaNotaCredito(tipoEmision, documentoBE.documentoventaAbarrotes.glosa)

    '    '********************************** RESUMEN GENERAL DE LA FACTURA **************************
    '    'GRATUITAS
    '    a.AnadirDatosGenerales("S/", "0.00")
    '    'EXONERADAS
    '    a.AnadirDatosGenerales("S/", ExoMN)
    '    'INAFECTA
    '    a.AnadirDatosGenerales("S/", InaMN)
    '    'GRAVADA
    '    a.AnadirDatosGenerales("S/", gravMN)
    '    'TOTAL DESCUENTO
    '    a.AnadirDatosGenerales("S/", "0.00")
    '    'I.S.C.
    '    a.AnadirDatosGenerales("S/", "0.00")
    '    'I.G.V
    '    a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.igv01)
    '    'IMPORTE TOTAL
    '    a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.ImporteNacional)


    '    '//DESCRIICION DE DETALLE DE TOTAL IMKPORTE Y NUMEROS BANCARIOS

    '    ''DESCRIPCION DEL IMPORTE TOTAL EN LETRAS
    '    'BANCO SOLES
    '    'BANCO DOLARES
    '    'NOTA DE CAMBIOS
    '    a.AnadirLineaTotalFactura(documentoBE.documentoventaAbarrotes.ImporteNacional,
    '                              objDatosGenrales.nroCuentaSoles,
    '                                objDatosGenrales.nroCuentaSoles2,
    '                              objDatosGenrales.nroCuentaDolares,
    '                               objDatosGenrales.nroCuentaDolares2,
    '                              objDatosGenrales.glosario)


    '    a.headerImagenQR = QrCodeImgControl1.Image


    '    Select Case tipodocumentoBE.documentoventaAbarrotes
    '        Case "1"
    '            a.tipodocumentoBE.documentoventaAbarrotes = "1"
    '            a.ImprimeTicket(imprimir, numeroImpresion)
    '        Case "2"
    '            a.tipodocumentoBE.documentoventaAbarrotes = "2"
    '            a.ImprimeTicket(imprimir, numeroImpresion)
    '    End Select

    'End Sub

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
            btnImprimir.Focus()
            btnImprimir.Select()
        End If
        '   End If

        QrCodeImgControl1.Text = QR
    End Sub

    Private Sub btnConfigurar_Click(sender As Object, e As EventArgs)
        PageSetupDialog1.Document.DefaultPageSettings.Color = False
        PageSetupDialog1.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try

            Select Case ChecDomicilio.Checked
                Case True ' sin definir
                    documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada = "SIN DEFINIR"

                Case False
                    If gridGroupingControl1.Table.Records.Count > 0 Then
                        Dim recordDom = gridGroupingControl1.Table.CurrentRecord
                        If recordDom IsNot Nothing Then
                            documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada = recordDom.GetValue("domicilios")

                        Else
                            MessageBox.Show("Debe seleccionar una direccion válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Debe seleccionar una direccion válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
            End Select

            If (txtFormato.Text = "TICKET") Then
                If (Not IsNothing(objDatosGenrales)) Then
                    If (TIPOiMPESION <> 1) Then
                        ImprimirTicket(ComboBox1.Text, DocumentoID, objDatosGenrales.formato, "DIRECTO")
                    Else
                        ImprimirTicket(ComboBox1.Text, DocumentoID, "6", "DIRECTO")
                    End If
                Else
                    MessageBox.Show("No tiene una configuración de datos generales de la empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            ElseIf (txtFormato.Text = "A4") Then
                If (Not IsNothing(objDatosGenrales)) Then
                    If (TIPOiMPESION <> 1) Then
                        Select Case objDatosGenrales.formato

                            Case 1
                                ImprimirTicketA4(ComboBox1.Text, DocumentoID, txtNroImpresion.DecimalValue, "DIRECTO")
                            Case 2
                                ImprimirTicketA4Formato2(ComboBox1.Text, DocumentoID, txtNroImpresion.DecimalValue, "DIRECTO")
                            Case 3
                                ImprimirTicketA4Formato_Detraccion(ComboBox1.Text, DocumentoID, txtNroImpresion.DecimalValue, "DIRECTO")
                            Case 4
                                ImprimirTicketA4_MATRICIAL(ComboBox1.Text, DocumentoID, txtNroImpresion.DecimalValue, "DIRECTO")
                            Case 5
                                ImprimirTicketA4v5(ComboBox1.Text, DocumentoID, txtNroImpresion.DecimalValue, "DIRECTO")
                            Case 6
                                ImprimirTicketA4Formato6(ComboBox1.Text, DocumentoID, txtNroImpresion.DecimalValue, "DIRECTO")
                            Case Else
                                ImprimirTicketA4(ComboBox1.Text, DocumentoID, txtNroImpresion.DecimalValue, "DIRECTO")
                        End Select
                    Else
                        ImprimirTicketDevolucionA4Formato2(ComboBox1.Text, DocumentoID, txtNroImpresion.DecimalValue, "DIRECTO")
                    End If
                Else
                    MessageBox.Show("No tiene una configuración de datos generales de la empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            ElseIf (txtFormato.Text = "A5") Then
                If (Not IsNothing(objDatosGenrales)) Then
                    ImprimirTicketA5(ComboBox1.Text, DocumentoID, txtNroImpresion.DecimalValue, "DIRECTO")
                Else
                    MessageBox.Show("No tiene una configuración de datos generales de la empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormImpresion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Dispose()
        End If
    End Sub

    Private Sub CargarDatos()
        Dim Action As Boolean = True
        Try
            Dim datosGeneralesSA As New datosGeneralesSA
            Dim objDatosGenerales As New datosGenerales

            '    objDatosGenerales.idEmpresa = Gempresas.IdEmpresaRuc
            listaDatos = CustomListaDatosGenerales ' datosGeneralesSA.UbicaEmpresaFull(objDatosGenerales)

            If listaDatos.Count > 0 Then
                cboFormato.ValueMember = "idConfiguracion"
                cboFormato.DisplayMember = "formatoImpresion"
                cboFormato.DataSource = listaDatos

                If (Not IsNothing(listaDatos)) Then

                    Dim consulta = (From list In listaDatos Where list.predeterminado = 1).FirstOrDefault

                    'For Each ITEM In listaDatos
                    If (Not IsNothing(consulta)) Then
                        cboFormato.SelectedValue = consulta.idConfiguracion
                        cargarDatos(cboFormato.SelectedValue)
                        Action = False
                        '        Exit For
                    Else
                        If (Action = True) Then
                            cargarDatos(cboFormato.SelectedValue)
                        End If
                    End If
                    'Next
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub ImprimirTicketDevolucionA4Formato2(imprimir As String, intIdDocumento As Integer, numeroImpresion As Integer, impresionTipo As String)
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
        Dim nombreComprabante As String = String.Empty
        '  Dim r As Record = dgPedidos.Table.CurrentRecord
        Dim entidadSA As New entidadSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA

        'Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
        Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
        'Dim comprobantePadre = documentoSA.GetUbicar_documentoventaAbarrotesPorIDPadre(intIdDocumento)
        Dim tipoComprobante As String = String.Empty
        Dim fileName As String = String.Empty

        Dim comprobante = documentoSA.GetUbicar_NotaXID(intIdDocumento)

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
                nombreComprabante = comprobante.serieVenta & comprobante.numeroVenta
                a.tipoComprobante = "2"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipoComprobante = "NOTA DE CREDITO"
        End Select

        Dim entidad = documentoBE.documentoventaAbarrotes.CustomEntidad ' entidadSA.UbicarEntidadPorID(documentoBE.documentoventaAbarrotes.idCliente).FirstOrDefault
        Dim NBoletaElectronica As String '= entidad.nombreCompleto
        Dim nBoletaNumero As String
        'ticket.TextoIzquierda(NBoletaElectronica)

        If entidad.nrodoc.Trim.Length = 11 Then
            nBoletaNumero = "R.U.C. - " & entidad.nrodoc
        ElseIf entidad.nrodoc.Trim.Length = 8 Then
            nBoletaNumero = "D.N.I. - " & entidad.nrodoc
        Else
            nBoletaNumero = entidad.nrodoc
        End If

        If entidad.tipoEntidad = "VR" Then
            NBoletaElectronica = documentoBE.documentoventaAbarrotes.nombrePedido
        Else
            NBoletaElectronica = entidad.nombreCompleto
        End If

        If (ChecDomicilio.Checked = False) Then
            entidad.direccion = documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada
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
                                              tienda)

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




        If (impresionTipo = "PDF") Then

            Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)

            Dim ubicacionFile As String = String.Empty
            Dim formulario As New formVerPDF(fileUbicacion)
            formulario.BringToFront()
            formulario.Show()

        ElseIf (impresionTipo = "ENVIAR") Then
            Dim cliente As String = NBoletaElectronica
            Dim Monto As String = documentoBE.documentoventaAbarrotes.ImporteNacional.GetValueOrDefault
            Dim FechaEmision As String = documentoBE.documentoventaAbarrotes.fechaDoc.Value.ToShortDateString()
            Dim param1 As String = ""
            param1 = Chr(34) & "width:100%" & Chr(34)
            Dim param2 As String = Chr(34) & "http://www.spk.com.pe" & Chr(34)
            Dim param3 As String = Chr(34) & "_blank" & Chr(34)
            Dim textoEnviar = "<!DOCTYPE html>
<html>
<head>
    <title>FACTURA ELECTRÓNICA</title>
</head>
<body>
    <header>
        <h3>Estimado cliente: " & cliente & "</h3>
    </header>

    <section>
        <article>
            <div>
                <p>Informamos a usted que el documento " & nombreComprabante & " ya se encuentra disponible.</p>

            </div>
        </article>
    </section>

    <table style=" & param1 & ">
        <tr>
            <td>Tipo</td>
            <td>:</td>
            <td>" & tipoComprobante & "</td>
        </tr>
        <tr>
            <td>Numero</td>
            <td>:</td>
            <td>" & nombreComprabante & "</td>
        </tr>
        <tr>
            <td>Monto</td>
            <td>:</td>
            <td>S/." & Monto & "</td>
        </tr>
        <tr>
            <td>Fecha de emisión</td>
            <td>:</td>
            <td>" & FechaEmision & " </td>
        </tr>
        <tr>
            <td>Este documento puede ser validado en el URL</td>
            <td>:</td>
            <td ><a href=" & param2 & " target=" & param3 & "> http://www.spk.com.pe</a></td>
        </tr>

    </table>
    <BR />

    <p>Saluda atentamente,</p>
    <p>
        SOFTPACK ERP.
    </p>

</body>
</html>"
            Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)
            If (fileUbicacion.Length > 0) Then
                Dim f As New FormEnviarCorreo(objDatosGenrales, cboFormato.SelectedValue, fileUbicacion, fileName)
                f.TextBoxASUNTO.Text = "SoftPack Facturación Electrónica"
                f.cargardatosPrevios(textoEnviar)
                f.documentoBE = documentoBE
                f.StartPosition = FormStartPosition.CenterScreen
                f.ShowDialog()
            Else
                MessageBox.Show("VERIFICAR DOCUMENTO A ENVIAR")
            End If

        ElseIf (impresionTipo = "GUARDAR") Then
            a.ImprimeTicket(imprimir, 1)
        ElseIf (impresionTipo = "DIRECTO") Then
            a.ImprimeTicket(imprimir, numeroImpresion)
        End If

    End Sub

#End Region

#Region "Events"
    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Close()
    End Sub

    Private Sub btnPdf_Click(sender As Object, e As EventArgs) Handles btnPdf.Click
        Try

            Select Case ChecDomicilio.Checked
                Case True ' sin definir
                    documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada = "SIN DEFINIR"

                Case False
                    If gridGroupingControl1.Table.Records.Count > 0 Then
                        Dim recordDom = gridGroupingControl1.Table.CurrentRecord
                        If recordDom IsNot Nothing Then
                            documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada = recordDom.GetValue("domicilios")

                        Else
                            MessageBox.Show("Debe seleccionar una direccion válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Debe seleccionar una direccion válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
            End Select

            If (txtFormato.Text = "TICKET") Then
                If (Not IsNothing(objDatosGenrales)) Then
                    If (TIPOiMPESION <> 1) Then
                        ImprimirTicket(GImpresion.ImpresoraPDF, DocumentoID, objDatosGenrales.formato, "GUARDAR")
                    Else
                        ImprimirTicket(GImpresion.ImpresoraPDF, DocumentoID, "6", "GUARDAR")
                    End If
                Else
                    MessageBox.Show("No tiene una configuración de datos generales de la empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            ElseIf (txtFormato.Text = "A4") Then
                If (Not IsNothing(objDatosGenrales)) Then
                    If (TIPOiMPESION <> 1) Then
                        Select Case objDatosGenrales.formato
                            Case 1
                                ImprimirTicketA4(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "GUARDAR")
                            Case 2
                                ImprimirTicketA4Formato2(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "GUARDAR")
                            Case 3
                                ImprimirTicketA4Formato_Detraccion(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "GUARDAR")
                            Case 4
                                ImprimirTicketA4_MATRICIAL(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "GUARDAR")
                            Case 5
                                ImprimirTicketA4v5(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "GUARDAR")
                            Case 6
                                ImprimirTicketA4Formato6(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "GUARDAR")
                            Case Else
                                ImprimirTicketA4(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "GUARDAR")
                        End Select
                    Else
                        ImprimirTicketDevolucionA4Formato2(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "GUARDAR")
                    End If
                Else
                    MessageBox.Show("No tiene una configuración de datos generales de la empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            ElseIf (txtFormato.Text = "A5") Then
                If (Not IsNothing(objDatosGenrales)) Then
                    ImprimirTicketA5(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "GUARDAR")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnCorreo_Click(sender As Object, e As EventArgs) Handles btnCorreo.Click
        Try

            Select Case ChecDomicilio.Checked
                Case True ' sin definir
                    documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada = "SIN DEFINIR"
                Case False
                    If gridGroupingControl1.Table.Records.Count > 0 Then
                        Dim recordDom = gridGroupingControl1.Table.CurrentRecord
                        If recordDom IsNot Nothing Then
                            documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada = recordDom.GetValue("domicilios")

                        Else
                            MessageBox.Show("Debe seleccionar una direccion válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Debe seleccionar una direccion válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
            End Select


            If (Not IsNothing(objDatosGenrales)) Then
                If (TIPOiMPESION = 1) Then
                    ImprimirTicketDevolucionA4Formato2(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "ENVIAR")
                Else
                    If (txtFormato.Text <> "TICKET") Then
                        Select Case objDatosGenrales.formato
                            Case 1
                                ImprimirTicketA4(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "ENVIAR")
                            Case 2
                                ImprimirTicketA4Formato2(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "ENVIAR")
                            Case 3
                                ImprimirTicketA4Formato_Detraccion(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "ENVIAR")
                            Case 4
                                ImprimirTicketA4_MATRICIAL(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "ENVIAR")
                            Case 5
                                ImprimirTicketA4v5(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "ENVIAR")
                            Case 6
                                ImprimirTicketA4Formato6(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "ENVIAR")
                            Case Else
                                ImprimirTicketA4(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "ENVIAR")
                        End Select
                    Else
                        ImprimirTicketA4(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "ENVIAR")
                    End If
                End If
            Else
                MessageBox.Show("No tiene una configuración de datos generales de la empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



        'Cursor = Cursors.WaitCursor
        'If (Not IsNothing(objDatosGenrales)) Then
        '    Dim f As New FormEnviarCorreo(Email, cboFormato.SelectedValue)
        '    f.documentoBE = documentoBE
        '    If (TIPOiMPESION = 1) Then
        '        f.ImprimirTicketDevolucionA4Formato2(DocumentoID, txtNroImpresion.DecimalValue)
        '    Else
        '        If (txtFormato.Text <> "TICKET") Then
        '            Select Case objDatosGenrales.formato
        '                Case 1
        '                    f.ImprimirTicketDirectaA4()
        '                Case 2
        '                    f.ImprimirTicketDirectaA4Formato2()
        '                Case 3
        '                    f.ImprimirTicketDirectaA4Formato_Detraccion()
        '                Case 5
        '                    f.ImprimirTicketDirectaA4Formato5()
        '                Case 6
        '                    f.ImprimirTicketDirectaA4Formato6()
        '                Case Else
        '                    f.ImprimirTicketDirectaA4()
        '            End Select
        '        Else
        '            f.ImprimirTicketDirectaA4()
        '        End If

        '    End If

        '    f.StartPosition = FormStartPosition.CenterScreen
        '    f.ShowDialog()
        'Else
        '    MessageBox.Show("No tiene una configuración de datos generales de la empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
        'Cursor = Cursors.Default
    End Sub

    Private Sub cboFormato_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboFormato.SelectionChangeCommitted
        If (Not IsNothing(cboFormato.SelectedValue)) Then
            cargarDatos(cboFormato.SelectedValue)
        End If
    End Sub

#Region "FORMATO 4  - OPERACION SUJETA A DETRACCION"
    Sub ImprimirTicketA4Formato_Detraccion(imprimir As String, intIdDocumento As Integer, numeroImpresion As Integer, ImpresionTipo As String)
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
        Dim nombreComprabante As String = String.Empty
        '  Dim r As Record = dgPedidos.Table.CurrentRecord
        Dim entidadSA As New entidadSA

        Dim tipocomprobante As String = String.Empty
        Dim fileName As String = String.Empty

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
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "BOLETA"
            Case "12.2"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "FACTURA"
            Case "03"
                If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA ELECTRONICA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "2"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "BOLETA ELECTRONICA"
                ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "1"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "BOLETA"
                End If
            Case "01"
                If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA ELECTRONICA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "2"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "FACTURA ELECTRONICA"
                ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                    nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    a.tipoComprobante = "1"
                    fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                    tipocomprobante = "FACTURA"
                End If
            Case "9903"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "COTIZACIÓN")
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "COTIZACIÓN"
            Case Else
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "NOTA")
                nombreComprabante = documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                a.tipoComprobante = "1"
                fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.documentoventaAbarrotes.tipoDocumento & "-" _
                              & documentoBE.documentoventaAbarrotes.serieVenta & "-" _
                              & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c)
                tipocomprobante = "NOTA"
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

        If (ChecDomicilio.Checked = False) Then
            entidad.direccion = documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada
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

        a.AnadirLineaNotaCredito("", documentoBE.documentoventaAbarrotes.descripcionVenta)


        If (ImpresionTipo = "PDF") Then

            Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)

            'Dim ubicacionFile As String = String.Empty
            'Dim formulario As New formVerPDF(fileUbicacion)
            'formulario.BringToFront()
            'formulario.Show()
            Dim myProcess As New Process
            Dim PathShell As String = fileUbicacion

            myProcess.StartInfo.FileName = PathShell
            myProcess.StartInfo.UseShellExecute = True
            myProcess.StartInfo.RedirectStandardOutput = False
            myProcess.Start()
            myProcess.Dispose()

        ElseIf (ImpresionTipo = "ENVIAR") Then
            Dim cliente As String = NBoletaElectronica
            Dim Monto As String = documentoBE.documentoventaAbarrotes.ImporteNacional.GetValueOrDefault
            Dim FechaEmision As String = documentoBE.documentoventaAbarrotes.fechaDoc.Value.ToShortDateString()
            Dim param1 As String = ""
            param1 = Chr(34) & "width:100%" & Chr(34)
            Dim param2 As String = Chr(34) & "http://www.spk.com.pe" & Chr(34)
            Dim param3 As String = Chr(34) & "_blank" & Chr(34)
            Dim textoEnviar = "<!DOCTYPE html>
<html>
<head>
    <title>FACTURA ELECTRÓNICA</title>
</head>
<body>
    <header>
        <h3>Estimado cliente: " & cliente & "</h3>
    </header>

    <section>
        <article>
            <div>
                <p>Informamos a usted que el documento " & nombreComprabante & " ya se encuentra disponible.</p>

            </div>
        </article>
    </section>

    <table style=" & param1 & ">
        <tr>
            <td>Tipo</td>
            <td>:</td>
            <td>" & tipocomprobante & "</td>
        </tr>
        <tr>
            <td>Numero</td>
            <td>:</td>
            <td>" & nombreComprabante & "</td>
        </tr>
        <tr>
            <td>Monto</td>
            <td>:</td>
            <td>S/." & Monto & "</td>
        </tr>
        <tr>
            <td>Fecha de emisión</td>
            <td>:</td>
            <td>" & FechaEmision & " </td>
        </tr>
        <tr>
            <td>Este documento puede ser validado en el URL</td>
            <td>:</td>
            <td ><a href=" & param2 & " target=" & param3 & "> http://www.spk.com.pe</a></td>
        </tr>

    </table>
    <BR />

    <p>Saluda atentamente,</p>
    <p>
        SOFTPACK ERP.
    </p>

</body>
</html>"
            Dim fileUbicacion = a.GuardanImpresion(imprimir, fileName)
            If (fileUbicacion.Length > 0) Then
                Dim f As New FormEnviarCorreo(objDatosGenrales, cboFormato.SelectedValue, fileUbicacion, fileName)
                f.TextBoxASUNTO.Text = "SoftPack Facturación Electrónica"
                f.cargardatosPrevios(textoEnviar)
                f.documentoBE = documentoBE
                'f.rutaCDR =
                '    f.rutaxml =
                f.StartPosition = FormStartPosition.CenterScreen
                f.ShowDialog()
            Else
                MessageBox.Show("VERIFICAR DOCUMENTO A ENVIAR")
            End If

        ElseIf (ImpresionTipo = "GUARDAR") Then
            a.ImprimeTicket(imprimir, 1)
        ElseIf (ImpresionTipo = "DIRECTO") Then
            a.ImprimeTicket(imprimir, numeroImpresion)
        End If


    End Sub

    Sub ImprimirTicketA4Formato_DetraccionPDF(imprimir As String, intIdDocumento As Integer, numeroImpresion As Integer)
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
        Dim tipoCoprobante As String = String.Empty

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
                tipoCoprobante = "1"
            Case "12.2"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                nombreComprabante = "FACTURA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                tipoCoprobante = "1"
            Case "03"
                If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA ELECTRONICA")
                    nombreComprabante = "BOLETA ELECTRONICA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipoCoprobante = "2"
                ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "BOLETA")
                    nombreComprabante = "BOLETA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipoCoprobante = "1"
                End If
            Case "01"
                If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA ELECTRONICA")
                    nombreComprabante = "FACTURA ELECTRONICA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipoCoprobante = "2"
                ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                    a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                       "FACTURA")
                    nombreComprabante = "FACTURA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                    tipoCoprobante = "1"
                End If
            Case "9903"
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "COTIZACIÓN")
                nombreComprabante = "COTIZACIÓN" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                tipoCoprobante = "1"
            Case Else
                a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                      documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c),
                                      "NOTA")
                nombreComprabante = "NOTA" & documentoBE.documentoventaAbarrotes.serieVenta & documentoBE.documentoventaAbarrotes.numeroVenta
                tipoCoprobante = "1"
        End Select

        If documentoBE.documentoventaAbarrotes.idCliente <> 0 Then
            Dim entidad = documentoBE.documentoventaAbarrotes.CustomEntidad ' entidadSA.UbicarEntidadPorID(documentoBE.documentoventaAbarrotes.idCliente).FirstOrDefault
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


        Else
            Dim NBoletaElectronica As String = documentoBE.documentoventaAbarrotes.nombrePedido
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
            a.AnadirLineaCaracteresDatosGEnerales(documentoBE.documentoventaAbarrotes.fechaDoc.Value.ToShortDateString(),
                                              "",
                                              NBoletaElectronica,
                                             "",
                                             "",
                                              "",
                                              "PEN",
                                             tienda)

            'Codigo qr
            QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
                      "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & "VARIOS" & "|" & "0")

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

            a.AnadirLineaElementosFactura(i.codigoBarra,
                                      i.nombreItem,
                                     CInt(i.monto1),
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
        a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.igv01)
        'IMPORTE TOTAL
        a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.ImporteNacional)


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


        Select Case tipoCoprobante
            Case "1"
                a.tipoComprobante = "1"
                a.ImprimeTicket(imprimir, numeroImpresion)
            Case "2"
                a.tipoComprobante = "2"
                a.ImprimeTicket(imprimir, numeroImpresion)
        End Select

    End Sub

    Private Sub cboFormato_Click(sender As Object, e As EventArgs) Handles cboFormato.Click

    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles ComboBox1.Click

    End Sub

    Private Sub gridGroupingControl1_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles gridGroupingControl1.TableControlCellClick

    End Sub

    Private Sub gridGroupingControl1_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles gridGroupingControl1.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

        Dim cc As GridCurrentCell = gridGroupingControl1.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            ' If cc.Renderer IsNot Nothing Then

            If cc.ColIndex > -1 Then



                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                If style.TableCellIdentity.Column.Name = "domicilios" Then

                    If cc.Renderer IsNot Nothing Then
                        '  If e.TableControl.Model.Modified = True Then
                        Dim text As String = cc.Renderer.ControlText
                        If gridGroupingControl1.Table.CurrentRecord IsNot Nothing Then
                            gridGroupingControl1.Table.CurrentRecord.SetValue("domicilios", text)
                            EditarDomicilio(gridGroupingControl1.Table.CurrentRecord)
                        End If
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "validar ingreso")
        End Try
    End Sub

    Private Sub EditarDomicilio(currentRecord As Record)
        Dim idAtr = Integer.Parse(currentRecord.GetValue("id"))
        Dim atributoSA As New entidadAtributosSA
        Dim AtributosCliente As New entidadAtributos
        AtributosCliente.Action = Business.Entity.BaseBE.EntityAction.UPDATE
        AtributosCliente.idAtributo = idAtr
        AtributosCliente.idEntidad = documentoBE.documentoventaAbarrotes.CustomEntidad.idEntidad
        AtributosCliente.tipo = "DOMICILIO"
        AtributosCliente.estado = 1
        AtributosCliente.valorAtributo = currentRecord.GetValue("domicilios")
        AtributosCliente.usuarioModificacion = usuario.IDUsuario
        AtributosCliente.fechaModificacion = Date.Now
        atributoSA.AtributoEntidadSave(AtributosCliente)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim atributoSA As New entidadAtributosSA
        Dim AtributosCliente As New entidadAtributos
        AtributosCliente.Action = Business.Entity.BaseBE.EntityAction.INSERT
        AtributosCliente.idEntidad = documentoBE.documentoventaAbarrotes.CustomEntidad.idEntidad
        AtributosCliente.tipo = "DOMICILIO"
        AtributosCliente.estado = 1
        AtributosCliente.valorAtributo = "NUEVO DOMICILIO..."
        AtributosCliente.usuarioModificacion = usuario.IDUsuario
        AtributosCliente.fechaModificacion = Date.Now
        Dim be = atributoSA.AtributoEntidadSave(AtributosCliente)


        With gridGroupingControl1.Table
            .AddNewRecord.SetCurrent()
            .AddNewRecord.BeginEdit()
            .CurrentRecord.SetValue("id", be.idAtributo)
            .CurrentRecord.SetValue("domicilios", "NUEVO DOMICILIO...")
            .AddNewRecord.EndEdit()
            .TableDirty = True
        End With

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If gridGroupingControl1.Table.CurrentRecord IsNot Nothing Then
            gridGroupingControl1.TableControl.CurrentCell.EndEdit()
            gridGroupingControl1.TableControl.Table.TableDirty = True
            gridGroupingControl1.TableControl.Table.EndEdit()

            If MessageBox.Show("Eliminar el domicilio seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim atributoSA As New entidadAtributosSA
                Dim id = gridGroupingControl1.Table.CurrentRecord.GetValue("id")
                atributoSA.AtributoEntidadSave(New entidadAtributos With {.Action = BaseBE.EntityAction.DELETE, .idAtributo = id})
                gridGroupingControl1.Table.CurrentRecord.Delete()
            End If
        Else
            MessageBox.Show("Seleccionar un domicilio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ChecDomicilio_CheckedChanged(sender As Object, e As EventArgs) Handles ChecDomicilio.CheckedChanged
        If ChecDomicilio.Checked = True Then
            gridGroupingControl1.Enabled = False
            gridGroupingControl1.Visible = False
            Button1.Enabled = False
            Button2.Enabled = False
        Else
            gridGroupingControl1.Enabled = True
            gridGroupingControl1.Visible = True
            Button1.Enabled = True
            Button2.Enabled = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try

            Select Case ChecDomicilio.Checked
                Case True ' sin definir
                    documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada = "SIN DEFINIR"

                Case False
                    If gridGroupingControl1.Table.Records.Count > 0 Then
                        Dim recordDom = gridGroupingControl1.Table.CurrentRecord
                        If recordDom IsNot Nothing Then
                            documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada = recordDom.GetValue("domicilios")

                        Else
                            MessageBox.Show("Debe seleccionar una direccion válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Debe seleccionar una direccion válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
            End Select

            If (txtFormato.Text = "TICKET") Then
                If (Not IsNothing(objDatosGenrales)) Then
                    If (TIPOiMPESION <> 1) Then
                        ImprimirTicket(GImpresion.ImpresoraPDF, DocumentoID, objDatosGenrales.formato, "PDF")
                    Else
                        ImprimirTicket(GImpresion.ImpresoraPDF, DocumentoID, "6", "PDF")
                    End If
                Else
                    MessageBox.Show("No tiene una configuración de datos generales de la empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            ElseIf (txtFormato.Text = "A4") Then
                If (Not IsNothing(objDatosGenrales)) Then
                    If (TIPOiMPESION <> 1) Then
                        Select Case objDatosGenrales.formato
                            Case 1
                                ImprimirTicketA4(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "PDF")
                            Case 2
                                ImprimirTicketA4Formato2(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "PDF")
                            Case 3
                                ImprimirTicketA4Formato_Detraccion(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "PDF")
                            Case 4
                                ImprimirTicketA4_MATRICIAL(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "PDF")
                            Case 5
                                ImprimirTicketA4v5(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "PDF")
                            Case 6
                                ImprimirTicketA4Formato6(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "PDF")
                            Case Else
                                ImprimirTicketA4(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "PDF")
                        End Select
                    Else
                        ImprimirTicketDevolucionA4Formato2(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "PDF")
                    End If
                Else
                    MessageBox.Show("No tiene una configuración de datos generales de la empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            ElseIf (txtFormato.Text = "A5") Then
                If (Not IsNothing(objDatosGenrales)) Then
                    ImprimirTicketA5(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "PDF")
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs)
        Try

            Select Case ChecDomicilio.Checked
                Case True ' sin definir
                    documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada = "SIN DEFINIR"

                Case False
                    If gridGroupingControl1.Table.Records.Count > 0 Then
                        Dim recordDom = gridGroupingControl1.Table.CurrentRecord
                        If recordDom IsNot Nothing Then
                            documentoBE.documentoventaAbarrotes.CustomEntidad.DireccionSeleccionada = recordDom.GetValue("domicilios")

                        Else
                            MessageBox.Show("Debe seleccionar una direccion válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Debe seleccionar una direccion válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
            End Select

            If (txtFormato.Text = "TICKET") Then
                If (Not IsNothing(objDatosGenrales)) Then
                    If (TIPOiMPESION <> 1) Then
                        ImprimirTicket(GImpresion.ImpresoraPDF, DocumentoID, objDatosGenrales.formato, "VER")
                    Else
                        ImprimirTicket(GImpresion.ImpresoraPDF, DocumentoID, "6", "VER")
                    End If
                Else
                    MessageBox.Show("No tiene una configuración de datos generales de la empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            ElseIf (txtFormato.Text = "A4") Then
                If (Not IsNothing(objDatosGenrales)) Then
                    If (TIPOiMPESION <> 1) Then
                        Select Case objDatosGenrales.formato
                            Case 1
                                ImprimirTicketA4(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "VER")
                            Case 2
                                ImprimirTicketA4Formato2(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "VER")
                            Case 3
                                ImprimirTicketA4Formato_Detraccion(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "VER")
                            Case 4
                                ImprimirTicketA4_MATRICIAL(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "VER")
                            Case 5
                                ImprimirTicketA4v5(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "VER")
                            Case 6
                                ImprimirTicketA4Formato6(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "PVERDF")
                            Case Else
                                ImprimirTicketA4(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "VER")
                        End Select
                    Else
                        ImprimirTicketDevolucionA4Formato2(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "VER")
                    End If
                Else
                    MessageBox.Show("No tiene una configuración de datos generales de la empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            ElseIf (txtFormato.Text = "A5") Then
                If (Not IsNothing(objDatosGenrales)) Then
                    ImprimirTicketA5(GImpresion.ImpresoraPDF, DocumentoID, txtNroImpresion.DecimalValue, "PDF")
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


#End Region
#End Region
End Class