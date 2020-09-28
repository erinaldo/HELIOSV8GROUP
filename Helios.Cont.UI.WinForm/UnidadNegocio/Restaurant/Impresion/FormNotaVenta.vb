Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports OpenInvoicePeru.Comun.Dto.Intercambio
Imports OpenInvoicePeru.Comun.Dto.Modelos
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.IO
Public Class FormNotaVenta
#Region "Attributes"
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

    Dim documentoventaSA As New documentoVentaAbarrotesSA
    Dim listaDocumento As New List(Of Integer)

    Dim listaDocumentodET As New List(Of documentoventaAbarrotesDet)
    Public Property ListaproductosVendidos As New List(Of documentoventaAbarrotesDet)

    Dim ListaProductos As New List(Of documentoventaAbarrotesDet)

    Dim tipoImpresion As Integer

#End Region

#Region "Constructors"
    Public Sub New(doc As documento)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        CargarDatos()

        documentoBE = doc

        'Select Case documentoBE.documentoventaAbarrotes.CustomEntidad.tipoEntidad
        '    Case "VR"
        '        ChecDomicilio.Enabled = False
        '        ChecDomicilio.Checked = True
        '        Button1.Enabled = False
        '        Button2.Enabled = False
        '        gridGroupingControl1.Visible = False
        '    Case Else
        '        ChecDomicilio.Enabled = True
        '        Button1.Enabled = True
        '        Button2.Enabled = True
        '        gridGroupingControl1.Visible = True

        '        If documentoBE.documentoventaAbarrotes.CustomEntidad.tipoDoc = "1" Then ' DNI
        '            ChecDomicilio.Checked = True
        '        ElseIf documentoBE.documentoventaAbarrotes.CustomEntidad.tipoDoc = "6" Then ' RUC
        '            ChecDomicilio.Checked = False
        '        Else
        '            ChecDomicilio.Enabled = False
        '        End If

        'End Select

        Me.KeyPreview = True
    End Sub

#End Region

#Region "Methods"
    Private Sub CargarDomiciliosCliente(ListaDomicilios As List(Of documentoventaAbarrotes))
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("pedido")

        For Each i In ListaDomicilios
            dt.Rows.Add(i.idDocumento, "PEDIDO " & i.preVenta, False)
        Next
        TIPOiMPESION = 0
        dgvPedidoDetalle.DataSource = dt

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.F2
                btnImprimir.PerformClick()


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

    Sub ImprimirTicket(imprimir As String, intIdDocumento As Integer, formato As String)
        Select Case FormaPago


'// case 333333333333333333333
            Case "3"
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
                        'a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET BOLETA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
                        a.tipoComprobante = 1
                        a.AnadirLineaComprobante("TICKET BOLETA")
                        a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)

                'a.AnadirLineaSubcabeza("Ticket Boleta    N° " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                    Case "12.2"
                        'a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET FACTURA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
                        a.tipoComprobante = 1
                        a.AnadirLineaComprobante("TICKET FACTURA")
                        a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                'a.AnadirLineaSubcabeza("Ticket Factura    N° " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                    Case "03"
                        If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                            'a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA DE VENTA ELECTRONICA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
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
                            a.AnadirLineasDatosFinales("http://facturador.softpack.com.pe/login")
                            a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia")
                            a.AnadirLineasDatosFinales("034-005-0010982")

                            a.AnadirLineasDatosFinales("")

                            'a.AnadirLineasDatosFinales("SIETE (7) DIAS DESPUES DE LA COMPRA")
                            'a.AnadirLineasDatosFinales("PRESENTAR TICKET ORIGINAL")
                            'a.AnadirLineasDatosFinales("maych_1@hotmail.com")
                            'a.AnadirLineasDatosFinales("TELEFONO DE ATENCION AL CLIENTE")
                            'a.AnadirLineasDatosFinales("(01)-12345678")
                            a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA")

                            'a.AnadirLineaSubcabeza("Boleta electronica    N° " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                        ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                            'a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA   N° " & CStr(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, "0"c) & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
                            a.tipoComprobante = 1
                            a.AnadirLineaComprobante("BOLETA")
                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                            'a.AnadirLineaSubcabeza("Boleta de venta    N° " & CStr(comprobante.serieVenta).PadLeft(3, "0"c) & "-" & comprobante.numeroVenta)
                        End If
                    Case "01"
                        If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
                            'a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA ELECTRONICA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
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
                            a.AnadirLineasDatosFinales("http://facturador.softpack.com.pe/login")
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


                            'a.AnadirLineaSubcabeza("Factura electronica    N° " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                        ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
                            'a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA   N° " & CStr(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, "0"c) & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
                            a.tipoComprobante = 1
                            a.AnadirLineaComprobante("FACTURA")
                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                            'a.AnadirLineaSubcabeza("Fartura    N° " & CStr(comprobante.serieVenta).PadLeft(3, "0"c) & "-" & comprobante.numeroVenta)
                        End If
                    Case "9901"
                        'a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "PROFORMA   N° " & 0, nombreCliente, DIRECCIONclIENTE, "", rucCliente, edido)))
                        a.AnadirLineaComprobante("PROFORMA")
                        a.AnadirLineaComprobante(0 & "-" & 0)
                        a.tipoComprobante = 1
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
                        a.AnadirLineasDatosFinales("http://facturador.softpack.com.pe/login")
                        a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia")
                        a.AnadirLineasDatosFinales("034-005-0010982")
                        a.AnadirLineasDatosFinales("")
                        a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA")
                    Case Else
                        'a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET NOTA   N° " & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente)
                        a.tipoComprobante = 1
                        a.AnadirLineaComprobante("NOTA")
                        a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
                        'a.AnadirLineaSubcabeza("Ticket nota    N° " & comprobante.numeroVenta)
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

                            a.AnadirLineasDescuento("PENDIENTE: " & importeTotalMN - importeSumMN)

                        Else


                    a.AnadirLineasDescuento("PENDIENTE: " & importeTotalMN - importeSumMN)
                        End If

                        a.headerImagenQR = QrCodeImgControl1.Image

                        'a.AnadirLineaDatos("Vendedor: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno, "Representacion impresa del comprobante", "http://facturador.softpack.com.pe/login")
                        '//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
                        '//parametro de tipo string que debe de ser el nombre de la impresora. 
                        a.ImprimeTicket(imprimir, txtNroImpresion.DecimalValue)

        End Select

    End Sub


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
            ImprimirTicket(ComboBox1.Text, DocumentoID, objDatosGenrales.formato)

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


#End Region

#Region "Events"
    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Close()
    End Sub

    Private Sub cboFormato_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboFormato.SelectionChangeCommitted
        If (Not IsNothing(cboFormato.SelectedValue)) Then
            cargarDatos(cboFormato.SelectedValue)
        End If
    End Sub

#End Region
End Class