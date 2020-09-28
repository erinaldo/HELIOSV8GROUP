Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports OpenInvoicePeru.Comun.Dto.Intercambio
Imports OpenInvoicePeru.Comun.Dto.Modelos
Imports System.IO

Public Class FormImpresionNuevo

    Dim instance As New Printing.PrinterSettings
    Dim impresosaPredt As String = instance.PrinterName
    Public QR As String
    Public HASH As String
    Public CERTIFICADO As String
    Public DocumentoID As Integer
    Private documentoBE As New documentoGuia
    Public objDatosGenrales As New datosGenerales
    Private Const FormatoFecha As String = "yyyy-MM-dd"
    Dim listaDatos As New datosGenerales
    Public Property tienda As String = String.Empty
    Public Property FormaPago As String = String.Empty
    Public Property TIPOiMPESION As Integer = 0
    Public Property Email As String
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

    Public Sub New(DOCUMENTOgUIA As documentoGuia)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        cargarDatos()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        documentoBE = DOCUMENTOgUIA
        Me.KeyPreview = True
    End Sub

    Public Sub New(DOCUMENTOgUIA As documentoGuia, INTID As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        CargarDatos()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        documentoBE = DOCUMENTOgUIA
        TIPOiMPESION = INTID
        Me.KeyPreview = True
    End Sub

    Private Sub CargarDatosUNIDADCOMERCIAL()
        Dim Action As Boolean = True
        Try
            Dim datosGeneralesSA As New datosGeneralesSA
            Dim objDatosGenerales As New datosGenerales

            '    objDatosGenerales.idEmpresa = Gempresas.IdEmpresaRuc
            objDatosGenrales = CustomListaDatosGenerales.Where(Function(O) O.NombreFormato = "A4" And O.idEmpresa = Gempresas.IdEmpresaRuc And O.idEstablecimiento = GEstableciento.IdEstablecimiento).FirstOrDefault  ' datosGeneralesSA.UbicaEmpresaFull(objDatosGenerales)
            txtFormato.Text = "A4"

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CargarDatos()
        Dim Action As Boolean = True
        Try
            Dim datosGeneralesSA As New datosGeneralesSA
            Dim objDatosGenerales As New datosGenerales

            '    objDatosGenerales.idEmpresa = Gempresas.IdEmpresaRuc
            objDatosGenrales = CustomListaDatosGenerales.Where(Function(O) O.NombreFormato = "A4" And O.idEmpresa = Gempresas.IdEmpresaRuc And O.idEstablecimiento = GEstableciento.IdEstablecimiento).FirstOrDefault  ' datosGeneralesSA.UbicaEmpresaFull(objDatosGenerales)
            txtFormato.Text = "A4"

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub ImprimirTicketA4(imprimir As String, intIdDocumento As Integer, NumeroImpresion As Integer, Impresiontipo As String)
        Dim a As GuiaRemision = New GuiaRemision
        ' Logo de la Empresa
        Dim lista As New List(Of String)
        Dim numeracion As Integer = 1
        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        'Dim ticket As New CrearTicket()
        Dim nombreComprabante As String = String.Empty
        '  Dim r As Record = dgPedidos.Table.CurrentRecord
        Dim entidadSA As New entidadSA
        Dim LISTAREGIONES As New List(Of regiones)
        Dim tipocomprobante As String = String.Empty
        Dim REGIONSA As New regionesSA
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


        a.AnadirLineaEncabezadoDerecha(objDatosGenrales.ruc,
                                       documentoBE.serie & "-" & CStr(documentoBE.numeroDoc).PadLeft(8, "0"c),
                                       "GUÍA DE REMISIÓN REMITENTE")
        nombreComprabante = documentoBE.serie & documentoBE.numeroDoc
        a.tipoComprobante = "2"
        fileName = Gempresas.IdEmpresaRuc & "-" & documentoBE.tipoDoc & "-" _
                              & documentoBE.serie & "-" _
                              & CStr(documentoBE.numeroDoc).PadLeft(8, "0"c)
        tipocomprobante = "GUÍA DE REMISIÓN REMITENTE"

        Dim entidad = documentoBE.CustomEntidad ' entidadSA.UbicarEntidadPorID(documentoBE.documentoventaAbarrotes.idCliente).FirstOrDefault

        LISTAREGIONES = REGIONSA.ListarUbigeosActivos()



        'ticket.TextoIzquierda(NBoletaElectronica)

        'If (Not IsNothing(entidad.nrodoc)) Then
        '    If entidad.nrodoc.Trim.Length = 11 Then
        '        nBoletaNumero = "R.U.C. - " & entidad.nrodoc
        '    ElseIf entidad.nrodoc.Trim.Length = 8 Then
        '        nBoletaNumero = "D.N.I. - " & entidad.nrodoc
        '    Else
        '        nBoletaNumero = entidad.nrodoc
        '    End If
        'Else
        '    nBoletaNumero = "-"
        'End If

        'If entidad.tipoEntidad = "VR" Then
        '    'NBoletaElectronica = documentoBE.nombrePedido
        'Else
        '    NBoletaElectronica = entidad.nombreCompleto
        'End If


        'entidad.direccion = documentoBE.CustomEntidad.DireccionSeleccionada


        '//DATOS DEL CLIENTE
        'Fecha de Factura
        'Lugar de la factura
        'Nombre del cliente
        'direccion del cliente
        'numero del cliente
        'direccion de entrega
        'tipo moneda de la empresa
        'telefono de la empresa

        Dim FECHATRASLADO As String
        Dim DESCRIPCIONMOTIVO As String
        Dim tipoVehiculo As String
        If (Not IsNothing(documentoBE.fechaTraslado)) Then
            FECHATRASLADO = documentoBE.fechaTraslado.Value
        Else
            FECHATRASLADO = ""
        End If

        If (Not IsNothing(documentoBE.DescripcionMotivo)) Then
            DESCRIPCIONMOTIVO = documentoBE.DescripcionMotivo
        Else
            DESCRIPCIONMOTIVO = ""
        End If

        If (Not IsNothing(documentoBE.tipoVehiculo)) Then
            tipoVehiculo = documentoBE.tipoVehiculo
        Else
            tipoVehiculo = ""
        End If


        a.AnadirLineaCaracteresDatosGEnerales(documentoBE.fechaDoc,
                                            FECHATRASLADO,
                                             DESCRIPCIONMOTIVO,
                                             tipoVehiculo,
                                             "",
                                              documentoBE.PesoBruTotal)



        '//DATOS COMPLEMENTARIOS
        'Nro. Pedido
        'Fecha Pedido
        'Orden de compra
        'fecha de Orden de Compra
        'Guia de remisiionm
        'FEcha de guia de remisuion
        'forma de venta
        'Tipo de Venta


        a.AnadirLineaDatosComplementarios(documentoBE.nombreDestinatario,
                                          documentoBE.DocDestinatario
                                         )

        Dim REGION As New regiones
        Dim PROVINCIA As New provincias
        Dim DISTRITO As New distritos

        Dim REGIONL As New regiones
        Dim PROVINCIAL As New provincias
        Dim DISTRITOL As New distritos

        REGION = LISTAREGIONES.Where(Function(O) O.id = (documentoBE.puntoPartida.Substring(0, 2) & "0000")).FirstOrDefault
        PROVINCIA = REGION.provincias.Where(Function(Z) Z.id = (documentoBE.puntoPartida.Substring(0, 4) & "00")).FirstOrDefault
        DISTRITO = PROVINCIA.distritos.Where(Function(X) X.id = (documentoBE.puntoPartida.Substring(0, 6))).FirstOrDefault

        REGIONL = LISTAREGIONES.Where(Function(O) O.id = (documentoBE.puntoLlegada.Substring(0, 2) & "0000")).FirstOrDefault
        PROVINCIAL = REGIONL.provincias.Where(Function(Z) Z.id = (documentoBE.puntoLlegada.Substring(0, 4) & "00")).FirstOrDefault
        DISTRITOL = PROVINCIAL.distritos.Where(Function(X) X.id = (documentoBE.puntoLlegada.Substring(0, 6))).FirstOrDefault


        a.AnadirLineasDeDatosPuntoDePartida(documentoBE.direccionPartida & " " & REGION.name & "/" & PROVINCIA.name & "/" & DISTRITO.name,
                                          documentoBE.DireccionLlegada & " " & REGIONL.name & "/" & PROVINCIAL.name & "/" & DISTRITOL.name
                                         )

        Dim tipoVenta As String = String.Empty

        'Select Case documentoBE.documentoventaAbarrotes.estadoCobro
        '    Case "DC"
        '        tipoVenta = "CONTADO"
        '    Case "PN"
        '        tipoVenta = "CREDITO"
        'End Select

        'a.AnadirLineaDatosComplementarios("-",
        '                                  "-",
        '                                  documentoBE.documentoventaAbarrotes.nroOrdenVenta,
        '                                      "-",
        '                                      documentoBE.documentoventaAbarrotes.nroGuia,
        '                                      "-",
        '                                      "-",
        '                                  tipoVenta)

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


        For Each i In documentoBE.documentoguiaDetalle

            'Dim cpsnulta = i.unidadMedida

            If (TIPOiMPESION = 1) Then
                a.AnadirLineaElementosFactura(numeracion,
                                                    $"{i.descripcionItem } ",
                                                    i.codigoLote,
                                                   "-",
                                                    "1",
                                                    "2",
                                                  "3",
                                                    "4",
                                                    "5",
                                                    i.nombreComercial,
                                                    i.cantidad.GetValueOrDefault)
            Else
                a.AnadirLineaElementosFactura(numeracion,
                                                   $"{i.descripcionItem } ",
                                                   i.codigoLote,
                                                  "-",
                                                   "1",
                                                   "2",
                                                 "3",
                                                   "4",
                                                   "5",
                                                   i.nombreComercial,
                                                   i.cantidad)
            End If




            numeracion += 1

        Next

        a.AnadirLineasDeDatosConductor("DNI", documentoBE.nroDocTrasportista)


        For Each i In documentoBE.documentoGuiaProperties.Where(Function(o) o.tipo = "CONDUCTOR").ToList()


            a.AnadirLineasDeDatosConductor(i.property_value2,
                                                    i.property_value
)
            'For Each i In guia.documentoGuiaProperties.Where(Function(o) o.tipo = "CONDUCTOR").ToList()
            '    dt.Rows.Add(conteo, i.property_value2, i.property_value)
            '    conteo += 1
            'Next


            numeracion += 1

        Next


        'For Each i In documentoBE.documentoGuiaProperties.Where(Function(o) o.tipo = "PLACA").ToList()


        a.AnadirLineasDeDatosTransporte(documentoBE.placaVehiculo)



        '    numeracion += 1

        'Next


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

        ElseIf (Impresiontipo = "GUARDAR") Then
            a.ImprimeTicket(imprimir, 1)
        ElseIf (Impresiontipo = "DIRECTO") Then
            a.ImprimeTicket(imprimir, txtNroImpresion.Value)

        End If

    End Sub



    Private Sub cargarDatos(idConfiguracion As Integer)
        Try



            txtFormato.Text = "A4"

            txtNroImpresion.Value = 1


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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

        End If
        '   End If

    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try
            ImprimirTicketA4(ComboBox1.Text, DocumentoID, txtNroImpresion.Value, "DIRECTO")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub FormImpresion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Dispose()
        End If
    End Sub


    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Dispose()
    End Sub

    Private Sub btnPdf_Click(sender As Object, e As EventArgs) Handles btnPdf.Click
        Try
            ImprimirTicketA4(ComboBox1.Text, DocumentoID, txtNroImpresion.Value, "GUARDAR")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnCorreo_Click(sender As Object, e As EventArgs) Handles btnCorreo.Click

    End Sub

    Private Sub txtNroImpresion_ValueChanged(sender As Object, e As EventArgs) Handles txtNroImpresion.ValueChanged

    End Sub
End Class
