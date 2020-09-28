Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports OpenInvoicePeru.Comun.Dto.Intercambio
Imports OpenInvoicePeru.Comun.Dto.Modelos
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.IO
Public Class FormImpresionPrecuenta
#Region "Attributes"
    Private VENTAsa As New documentoVentaAbarrotesSA
    Dim instance As New Printing.PrinterSettings
    Dim impresosaPredt As String = instance.PrinterName
    Public QR As String
    Public HASH As String
    Public CERTIFICADO As String
    Public DocumentoID As Integer
    Private documentoBE As New List(Of documentoventaAbarrotes)
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
    Public Sub New(distribucionID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.KeyPreview = True
        FormatoGridBlack(dgvPedidoDetalle, False)
        dgvPedidoDetalle.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell

        CargarDatos()

        Dim venta = VENTAsa.GetListarAllVentasXIdDistribucion(New distribucionInfraestructura With {.estado = "A", .idDistribucion = distribucionID})


        'Dim venta = VENTAsa.GetVentaID(New documento With {.idDocumento = ID})
        'documentoBE = New documento With {.idDocumento = ID}
        'documentoBE.documentoventaAbarrotes = venta.

        CargarDomiciliosCliente(venta)
    End Sub

    Public Sub New(distribucionID As Integer, TIPO As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.KeyPreview = True
        FormatoGridBlack(dgvPedidoDetalle, False)
        dgvPedidoDetalle.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell

        CargarDatos()

        Select Case TIPO
            Case True
                'Dim venta = VENTAsa.GetListarAllVentasXIdDistribucion(New distribucionInfraestructura With {.estado = "A", .idDistribucion = distribucionID})
                ListaProductos = VENTAsa.GetImprimirPedido(New documento With {.idDocumento = distribucionID})
                tipoImpresion = 1
            Case False
                ListaProductos = VENTAsa.GetImprimirPrecuenta(New documento With {.idDocumento = distribucionID, .entidad = "A"})
                tipoImpresion = 3
        End Select
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

    Sub ImprimirTicketPedido(imprimir As String, intIdDocumento As Integer, formato As String)
        Select Case FormaPago
            Case 1

                Dim a As TicketPedido = New TicketPedido
                'a.HeaderImage = "C:\Users\MAYKOL\Documents\LogoEmpresa\LOGO ROYAL BRANDING.jpg"
                Dim gravMN As Decimal = 0
                Dim gravME As Decimal = 0
                Dim ExoMN As Decimal = 0
                Dim ExoME As Decimal = 0
                Dim InaMN As Decimal = 0
                Dim InaME As Decimal = 0
                Dim precioUnit As Decimal = 0
                Dim PrecioTotal As Decimal = 0


                Dim rucCliente As String = String.Empty
                a.tipoImagen = False

                a.tipoEncabezado = False
                a.AnadirLineaEmpresa("PEDIDO")

                a.AnadirLineaCaracteresDatosGEnerales(Date.Now,
                                                      "ADMIN",
                                                       Email,
                                                     UsuariosList.Where(Function(o) o.IDUsuario = ListaProductos(0).usuarioModificacion).SingleOrDefault.Full_Name,
                                                      "",
                                                      tienda, "NAC", "966557413")


                ''CLIENTE
                'a.AnadirLineasElementosCliente(20602061583,
                '                               "INVERSIONES DISTRIBUCIONES Y ALMACENES ADRIANITO E.I.R.L.",
                '                                "PRO.HUANUCO NRO. 178 (A 1/2 CDRA MERCADO MODELO) JUNIN - HUANCAYO - HUANCAYO")



                For Each i In ListaProductos.ToList


                    If (i.tipoVenta = "PL") Then
                        If (Not IsNothing(i.detalleAdicional)) Then
                            a.AnadirLineaElementosFactura(CStr(CInt(i.monto1)), $"{i.nombreItem} ({i.detalleAdicional}) {"(PARA LLEVAR)"}", "", String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                        Else
                            a.AnadirLineaElementosFactura(CStr(CInt(i.monto1)), $"{i.nombreItem} {"(PARA LLEVAR)"}", i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                        End If
                    Else
                        If (Not IsNothing(i.detalleAdicional)) Then
                            If (i.detalleAdicional.Length = 0) Then
                                a.AnadirLineaElementosFactura(CStr(CInt(i.monto1)), $"{i.nombreItem}", i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                            Else
                                a.AnadirLineaElementosFactura(CStr(CInt(i.monto1)), $"{i.nombreItem} ({i.detalleAdicional})", "", String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                            End If

                        Else
                                a.AnadirLineaElementosFactura(CStr(CInt(i.monto1)), $"{i.nombreItem}", i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                        End If
                    End If

                    If (i.listaConexos.Count > 0) Then
                        For Each cox In i.listaConexos.Where(Function(o) o.idProducto = i.idItem).ToList
                            a.AnadirLineaElementosFactura("", $"    {cox.cantidad}  ({cox.detalle })", "", String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                        Next

                    End If

                Next

                a.ImprimeTicket(imprimir, 1)


            Case 2

                Dim a As TicketPedidoConfirmacion = New TicketPedidoConfirmacion
                'a.HeaderImage = "C:\Users\MAYKOL\Documents\LogoEmpresa\LOGO ROYAL BRANDING.jpg"
                Dim gravMN As Decimal = 0
                Dim gravME As Decimal = 0
                Dim ExoMN As Decimal = 0
                Dim ExoME As Decimal = 0
                Dim InaMN As Decimal = 0
                Dim InaME As Decimal = 0
                Dim precioUnit As Decimal = 0
                Dim PrecioTotal As Decimal = 0
                Dim rucCliente As String = String.Empty
                a.tipoImagen = False

                a.tipoEncabezado = False
                a.AnadirLineaEmpresa("PRE CUENTA")
                ''AJO
                'a.AnadirLineaEmpresa("PEDIDO")

                a.AnadirLineaCaracteresDatosGEnerales(Date.Now,
                                                      "ADMIN",
                                                       Email,
                                                     UsuariosList.Where(Function(o) o.IDUsuario = ListaProductos(0).usuarioModificacion).SingleOrDefault.Full_Name,
                                                      "",
                                                      tienda, "NAC", "966557413")


                ''CLIENTE
                'a.AnadirLineasElementosCliente(20602061583,
                '                               "INVERSIONES DISTRIBUCIONES Y ALMACENES ADRIANITO E.I.R.L.",
                '                                "PRO.HUANUCO NRO. 178 (A 1/2 CDRA MERCADO MODELO) JUNIN - HUANCAYO - HUANCAYO")

                Dim totalVenta As Decimal = 0.0

                For Each i In ListaProductos.ToList

                    precioUnit = Math.Round(CDbl(i.importeMN / i.monto1), 2)
                    PrecioTotal = CDec(i.importeMN)

                    If (i.tipoVenta = "PL") Then
                        If (Not IsNothing(i.detalleAdicional)) Then
                            a.AnadirLineaElementosFactura(CStr(CInt(i.monto1)), $"{i.nombreItem} ({i.detalleAdicional}) {"(PARA LLEVAR)"}", "", String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                        Else
                            a.AnadirLineaElementosFactura(CStr(CInt(i.monto1)), $"{i.nombreItem} {"(PARA LLEVAR)"}", i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                        End If
                    Else
                        If (Not IsNothing(i.detalleAdicional)) Then
                            If (i.detalleAdicional.Length = 0) Then
                                a.AnadirLineaElementosFactura(CStr(CInt(i.monto1)), $"{i.nombreItem}", i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                            Else
                                a.AnadirLineaElementosFactura(CStr(CInt(i.monto1)), $"{i.nombreItem} ({i.detalleAdicional})", "", String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                            End If
                        Else
                            a.AnadirLineaElementosFactura(CStr(CInt(i.monto1)), $"{i.nombreItem}", i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                        End If
                    End If

                    'If (i.listaConexos.Count > 0) Then
                    '    For Each cox In i.listaConexos.Where(Function(o) o.idProducto = i.idItem).ToList
                    '        a.AnadirLineaElementosFactura("", $"    {cox.cantidad}  ({cox.detalle })", "", String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                    '    Next

                    'End If
                    totalVenta = totalVenta + PrecioTotal
                Next

                a.AnadirDatosGenerales("S/. ", totalVenta)

                a.AnadirLineaDatos("R.U.C.: _____________________________________________________________:",
                                   "R. Social: ___________________________________________________________",
                                 "Dirección:_____________________________________________________________")


                a.ImprimeTicket(imprimir, 1)

        End Select

    End Sub


    Sub ImprimirTicket(imprimir As String, intIdDocumento As Integer, formato As String)
        Select Case FormaPago
            Case 1

                Dim a As TicketPedido = New TicketPedido
                'a.HeaderImage = "C:\Users\MAYKOL\Documents\LogoEmpresa\LOGO ROYAL BRANDING.jpg"
                Dim gravMN As Decimal = 0
                Dim gravME As Decimal = 0
                Dim ExoMN As Decimal = 0
                Dim ExoME As Decimal = 0
                Dim InaMN As Decimal = 0
                Dim InaME As Decimal = 0
                Dim precioUnit As Decimal = 0
                Dim PrecioTotal As Decimal = 0


                Dim rucCliente As String = String.Empty
                a.tipoImagen = False

                a.tipoEncabezado = False
                a.AnadirLineaEmpresa("PEDIDO")

                a.AnadirLineaCaracteresDatosGEnerales(Date.Now,
                                                      "ADMIN",
                                                       "PEDIDO" & "#",
                                                     UsuariosList.Where(Function(o) o.IDUsuario = documentoBE(0).usuarioActualizacion).SingleOrDefault.Full_Name,
                                                      "",
                                                      tienda, "NAC", "966557413")


                ''CLIENTE
                'a.AnadirLineasElementosCliente(20602061583,
                '                               "INVERSIONES DISTRIBUCIONES Y ALMACENES ADRIANITO E.I.R.L.",
                '                                "PRO.HUANUCO NRO. 178 (A 1/2 CDRA MERCADO MODELO) JUNIN - HUANCAYO - HUANCAYO")



                For Each ii In documentoBE.ToList
                    For Each i In ii.documentoventaAbarrotesDet

                        If (i.tipoVenta = "PL") Then
                            If (Not IsNothing(i.detalleAdicional)) Then
                                a.AnadirLineaElementosFactura(CStr(CInt(i.monto1)), $"{i.nombreItem} ({i.detalleAdicional}) {"(PARA LLEVAR)"}", "", String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                            Else
                                a.AnadirLineaElementosFactura(CStr(CInt(i.monto1)), $"{i.nombreItem}", i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                            End If
                        Else
                            If (Not IsNothing(i.detalleAdicional)) Then
                                a.AnadirLineaElementosFactura(CStr(CInt(i.monto1)), $"{i.nombreItem} ({i.detalleAdicional})", "", String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                            Else
                                a.AnadirLineaElementosFactura(CStr(CInt(i.monto1)), $"{i.nombreItem}", i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                            End If
                        End If
                    Next
                    'a.AnadirElemento(i.monto1, i.CustomEquivalencia.unidadComercial, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal), i.nombreItem)
                    'a.AnadirNombreElemento(i.nombreItem)
                    Exit For
                Next

                a.ImprimeTicket(imprimir, txtNroImpresion.DecimalValue)

            Case 2

                Dim a As TicketPedidoConfirmacion = New TicketPedidoConfirmacion
                'a.HeaderImage = "C:\Users\MAYKOL\Documents\LogoEmpresa\LOGO ROYAL BRANDING.jpg"
                Dim gravMN As Decimal = 0
                Dim gravME As Decimal = 0
                Dim ExoMN As Decimal = 0
                Dim ExoME As Decimal = 0
                Dim InaMN As Decimal = 0
                Dim InaME As Decimal = 0
                Dim precioUnit As Decimal = 0
                Dim PrecioTotal As Decimal = 0


                Dim rucCliente As String = String.Empty
                a.tipoImagen = False

                a.tipoEncabezado = False
                a.AnadirLineaEmpresa("PRE VENTA")


                'a.AnadirLineaCaracteresDatosGEnerales("14/05/2019",
                '                                      "ADMIN ADMIN ADMIN",
                '                                      "PEDIDO 1",
                '                                      "MAYKOL CHARLY SANCHEZ CORIS",
                '                                      "SELVA TOURS SRLTDA",
                '                                      "1",
                '                                      "MAYKOL CHARLY",
                '                                      "201058785452")

                a.AnadirLineaCaracteresDatosGEnerales(CStr(Date.Now),
                                                      "ADMIN",
                                                       "PRE CUENTA",
                                                    tienda,
                                                      "",
                                                      Email, "NAC", "966557413")


                ''CLIENTE
                'a.AnadirLineasElementosCliente(20602061583,
                '                               "INVERSIONES DISTRIBUCIONES Y ALMACENES ADRIANITO E.I.R.L.",
                '                                "PRO.HUANUCO NRO. 178 (A 1/2 CDRA MERCADO MODELO) JUNIN - HUANCAYO - HUANCAYO")



                For Each i In listaDocumentodET


                    precioUnit = (Math.Round(CDbl(i.importeMN / i.monto1), 2))
                    PrecioTotal = i.importeMN

                    If (i.tipoVenta = "PL") Then
                        If (Not IsNothing(i.detalleAdicional)) Then
                            a.AnadirLineaElementosFactura(CStr(CInt(i.monto1)), $"{i.nombreItem} ({i.detalleAdicional}) {"(PARA LLEVAR)"}", "", String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                        Else
                            a.AnadirLineaElementosFactura(CStr(CInt(i.monto1)), $"{i.nombreItem} {"(PARA LLEVAR)"}", i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                        End If
                    Else
                        If (Not IsNothing(i.detalleAdicional)) Then
                            a.AnadirLineaElementosFactura(CStr(CInt(i.monto1)), $"{i.nombreItem} ({i.detalleAdicional})", "", String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                        Else
                            a.AnadirLineaElementosFactura(CStr(CInt(i.monto1)), $"{i.nombreItem}", i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))
                        End If
                    End If

                    'a.AnadirElemento(i.monto1, i.CustomEquivalencia.unidadComercial, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal), i.nombreItem)
                    'a.AnadirNombreElemento(i.nombreItem)
                Next

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
            listaDocumento = New List(Of Integer)
            If (txtFormato.Text = "TICKET") Then
                If (Not IsNothing(objDatosGenrales)) Then


                    Select Case tipoImpresion
                        Case 1
                            ImprimirTicketPedido(ComboBox1.Text, DocumentoID, objDatosGenrales.formato)
                        Case 3
                            ImprimirTicketPedido(ComboBox1.Text, DocumentoID, objDatosGenrales.formato)
                        Case Else
                            'For Each item In dgvPedidoDetalle.Table.Records
                            '    If (item.GetValue("pedido") = True) Then
                            '        Dim codDocumento = Integer.Parse(item.GetValue("idDocumento"))
                            '        listaDocumento.Add(codDocumento)
                            '    End If
                            'Next

                            'Dim venta = VENTAsa.GetListaVentaID(New documento With {.ListaDocumentoID = listaDocumento, .tipoDoc = "VNP"})
                            ''documentoBE = New documento With {.idDocumento = ID}

                            'documentoBE = venta

                            If (Not IsNothing(dgvPedidoDetalle.Table.CurrentRecord)) Then
                                ListaProductos = VENTAsa.GetImprimirPedido(New documento With {.idDocumento = CInt(dgvPedidoDetalle.Table.CurrentRecord.GetValue("idDocumento"))})
                                'tipoImpresion = 1

                                ImprimirTicketPedido(ComboBox1.Text, DocumentoID, objDatosGenrales.formato)
                            Else
                                MessageBox.Show("Debe seleccinar un campo")
                            End If

                    End Select





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