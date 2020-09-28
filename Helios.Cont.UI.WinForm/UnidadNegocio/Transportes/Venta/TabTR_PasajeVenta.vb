Imports System.IO
Imports System.Net
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports HtmlAgilityPack
Imports System.Net.Http
Imports System.Net.NetworkInformation
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class TabTR_PasajeVenta

#Region "Attributes"
    Public Property ListaRutasActivas As List(Of rutas)
    Dim thread As System.Threading.Thread
    Public Property personaSA As New PersonaSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of Persona))
    Friend Delegate Sub SetDataSourceDelegateEntidad(ByVal lista As List(Of entidad))

    Public Property listaPersonas As List(Of Persona)
    Public Property listaServicios As List(Of ruta_HorarioServicios)
    Public Property entidadSA As New entidadSA
    Public Property listaClientes As List(Of entidad)

    Dim listaDistribucion As New List(Of vehiculoAsiento_Precios)
    Dim tipoLista As String = "T"
    Dim programacion_ID As Integer
    Private Property SelRazon As entidad

    Private Property tipoSeleccion As Boolean

    Public Property manifiesto As String

    Public Property FormPurchase As FormControlTransporteVer2

    Public Property fechaEnvio As String

    Public Property ubigeoOrigen As Integer
    Public Property ubigeoDestino As Integer
    Public Property LISTAESTABLECIMIENTO As List(Of centrocosto)

    Public Property libres As Integer
    Public Property reservado As Integer

    Public Property vendidos As Integer

    Private FormImpresionNuevo As FormImpresionEquivalencia

    Public Property IdProg As Integer


    Public Property tipoManipulacion As String

    Public Property idDocReferecia As Integer

#End Region

    Public Sub New(formRepTransporte As FormControlTransporteVer2)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormPurchase = formRepTransporte
    End Sub

#Region "Methods"

    Public Sub LimpiarCajasTransporte()
        LabelAsientoSel.Tag = Nothing
        LabelAsientoSel.Text = "0"
        lblPrecioTotal.Value = 0.0
        lblPrecioTotal.Text = "0.00"
        TextNumIdentrazon.Tag = Nothing
        TextNumIdentrazon.Clear()
        TextEmpresaPasajero.Tag = Nothing
        TextEmpresaPasajero.Clear()
        txtruc.Tag = Nothing
        txtruc.Clear()
        textPersona.Tag = Nothing
        textPersona.Clear()
        RBNatural.Checked = True
        txtEdad.Clear()
        chSinDNI.Checked = False
        cboSexo.Text = "GENERO"
        cboTipoDoc.Text = "BOLETA ELECTRONICA"
        CheckBox1.Checked = False
        CheckBox1.Visible = True
        tipoManipulacion = ""
        btnEliminarReserva.Visible = False
        btnReserva.Visible = False
        BtConfirmarVenta.Visible = True

    End Sub
    Public Sub EnviarAnulacionDocumento(objeto As documentoventaAbarrotes)
        Try
            Dim documentoventasa As New documentoVentaAbarrotesSA

            Dim objetoBaja As New Helios.Fact.Sunat.Business.Entity.RecepcionComunicacionBaja

            objetoBaja.IdDocumento = objeto.serieVenta & "-" & String.Format("{0:00000000}", CInt(objeto.numeroVenta))
            objetoBaja.TipoDocumento = objeto.tipoDocumento
            objetoBaja.idEmpresa = Gempresas.ubigeo
            objetoBaja.FechaEmision = objeto.fechaDoc
            objetoBaja.EnvioSunat = "NO"
            objetoBaja.estadoEnvio = "PE"
            objetoBaja.Contribuyente_id = Gempresas.IdEmpresaRuc

            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.RecepcionComunicacionBajaSA.RecepcionComunicacionBajaSave(objetoBaja, Nothing)

            If codigo.idAnulacion > 0 Then
                'ActualizarEnvioSunat("0", objeto)
                documentoventasa.UpdateAnulacionEnviada(objeto.idDocumento, codigo.idAnulacion, 0)

                MessageBox.Show("La comunicacion se Envio Correctamente al PSE")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub EliminarPV(intIdDocumento As Integer)
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim objDocumento As New documento
        Dim ventaSA As New DocumentoventaTransporteSA
        ' Try
        With objDocumento
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .idDocumento = intIdDocumento
        End With

        ventaSA.EliminarVentaEncomienda(New Business.Entity.documento With {.idDocumento = intIdDocumento,
                                            .idPse = Gempresas.ubigeo})

        'documentoSA.EliminarVenta(objDocumento)
        ''documentoSA.EliminarVentaGeneralPV(objDocumento)
        ''dgPedidos.Table.CurrentRecord.Delete()
        'MessageBox.Show("venta anulada!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'lblEstado.Text = "Pedido eliminado!"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)

        'Catch ex As Exception
        'MsgBox(ex.Message)
        ' End Try
    End Sub

    Sub ImprimirTicketA4v2(imprimir As String, intIdDocumento As Integer, comprobante As documentoventaTransporte, entidad As entidad)
        Dim a As FormatoA5Transporte = New FormatoA5Transporte

        a.HeaderImage = Image.FromFile("C:\LogoEmpresa\SELVATOURS_NEGRO.jpg")
        Dim lista As New List(Of String)

        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim ticket As New CrearTicket()
        Dim nombreComprabante As String
        Dim tipoComprobante As String = String.Empty



        a.tipoEncabezado = False
        a.AnadirLineaEmpresa(Gempresas.NomEmpresa)


        a.TextoIzquierda("Domicilio Fiscal: " & "AV. FERROCARRIL N° 1587 HUANCAYO - HUANCAYO - JUNIN")
        'a.TextoIzquierda("Establ. Anexo: " & objDatosGenrales.direccionSecudaria)
        'Telefono de la empresa
        a.TextoIzquierda("Telf: " & "-")
        a.TextoIzquierda("")

        Select Case comprobante.tipoDocumento
            Case "12.1"
                'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "BOLETA")
                'ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                nombreComprabante = "BOLETA" & comprobante.serie & comprobante.numero
                tipoComprobante = "1"
            Case "12.2"
                '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                'ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "FACTURA")
                nombreComprabante = "FACTURA" & comprobante.serie & comprobante.numero
                tipoComprobante = "1"
            Case "03"

                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "BOLETA ELECTRONICA")
                nombreComprabante = "FACTURA" & comprobante.serie & comprobante.numero
                tipoComprobante = "2"

            Case "01"
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "FACTURA ELECTRONICA")
                nombreComprabante = "FACTURA" & comprobante.serie & comprobante.numero
                tipoComprobante = "2"

            Case "9901"
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, 0 & " - " & CStr(0).PadLeft(8, "0"c), "PROFORMA")
                nombreComprabante = "PROFORMA" & comprobante.serie & comprobante.numero
                tipoComprobante = "1"
            Case Else

                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "NOTA")
                nombreComprabante = "NOTA" & comprobante.serie & comprobante.numero
                tipoComprobante = "1"
        End Select

        'a.TextoDerecha("RUC: " & "12345678911")
        'Numero de Ruc y Numeracion

        If comprobante.Consignado IsNot Nothing Then

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
            'LUGAR DE DESTINO
            'Nombre del REMITENTE
            'Nombre del CONSIGNADO
            'DNI CONSIGNADO
            'DNI REMITENTE
            'tipo moneda de la empresa
            'LUGAR DE ORIGEN
            If (entidad.nrodoc <> comprobante.CustomPerson.idPersona) Then
                'If (comprobante.Remitente <> comprobante.Consignado) Then
                a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                                            comprobante.ciudadDestino,
                                            comprobante.comprador,
                                           entidad.nombreCompleto,
                                           entidad.nrodoc,
                                            comprobante.CustomPerson.idPersona,
                                            CDate(comprobante.fechaProgramada).Date,
                                            comprobante.ciudadOrigen)
                'Else
                '    a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                '                            comprobante.ciudadDestino,
                '                            comprobante.comprador,
                '                           "",
                '                           "",
                '                            comprobante.CustomPerson.idPersona,
                '                            CDate(comprobante.fechaProgramada).Date,
                '                            comprobante.ciudadOrigen)
                'End If

            Else
                a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                                              comprobante.ciudadDestino,
                                          comprobante.comprador,
                                          "",
                                             "",
                                              comprobante.CustomPerson.idPersona,
                                             CDate(comprobante.fechaProgramada).Date,
                                              comprobante.ciudadOrigen)
            End If



            'PENIULTIMOFECHAPROGAR,CAION

            'If (Not IsNothing(HASH)) Then
            '    If HASH.Trim.Length > 0 Then
            '        QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
            '              "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
            '              "|" & HASH & "|" & CERTIFICADO)

            '        QrCodeImgControl1.Text = QR
            '    Else
            '        QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
            '             "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

            '        QrCodeImgControl1.Text = QR
            '    End If
            'Else
            '    QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
            '         "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

            '    QrCodeImgControl1.Text = QR
            'End If


        Else
            Dim NBoletaElectronica As String = comprobante.comprador
            'ticket.TextoIzquierda(NBoletaElectronica)
            'Fecha de Factura
            'Lugar de la factura
            'Nombre del cliente
            'direccion del cliente
            'numero del cliente
            'direccion de entrega
            'tipo moneda de la empresa
            'telefono de la empresa



            If (comprobante.Remitente <> comprobante.comprador) Then
                a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                                                 comprobante.ciudadDestino,
                                                comprobante.comprador,
                                                entidad.nombreCompleto,
                                                entidad.nrodoc,
                                                 comprobante.CustomPerson.idPersona,
                                                 comprobante.fechaProgramada,
                                                 comprobante.ciudadOrigen)
            Else
                a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                                              comprobante.ciudadDestino,
                                          comprobante.comprador,
                                          "",
                                             "",
                                              comprobante.CustomPerson.idPersona,
                                              comprobante.fechaProgramada,
                                              comprobante.ciudadOrigen)
            End If



            ''Codigo qr
            'QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
            '          "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & "VARIOS" & "|" & "0")

            'QrCodeImgControl1.Text = QR
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
        Dim baseImponible = 0
        Dim igv = 0
        Dim tipo As String = String.Empty
        For Each i In comprobante.documentoventaTransporteDetalle.ToList

            'baseImponible = Math.Round(CDec(CalculoBaseImponible(i.importe, 1.18)), 2)
            'igv = Math.Round(CDec(i.importe - baseImponible), 2)
            Select Case i.tipo
                Case "P"
                    tipo = "PAQUETE"
                Case "C"
                    tipo = "CAJA"
                Case "S"
                    tipo = "SOBRE"
                Case "CO"
                    tipo = "COSTAL"
                Case "O"
                    tipo = "OTRO"
            End Select

            a.AnadirLineaElementosFactura(
                tipo,
                i.detalle,
                i.cantidad,
                i.unidadMedida, 0,
                "0.00", 0, "0.00", 0, i.importe / i.cantidad, i.importe)
            'ticket.AgregaArticuloV2(i.nombreItem, String.Format("{0:0.00}", i.monto1), String.Format("{0:0.00}", i.importeMN / i.monto1), i.importeMN)
        Next

        '********************************** RESUMEN GENERAL DE LA FACTURA **************************
        'GRATUITAS
        a.AnadirDatosGenerales("S/", "0.00")
        'EXONERADAS
        a.AnadirDatosGenerales("S/", comprobante.total)
        'INAFECTA
        a.AnadirDatosGenerales("S/", "0.00")
        'GRAVADA
        a.AnadirDatosGenerales("S/", comprobante.baseImponible1)
        'TOTAL DESCUENTO
        a.AnadirDatosGenerales("S/", "0.00")
        'I.S.C.
        a.AnadirDatosGenerales("S/", "0.00")
        'I.G.V
        a.AnadirDatosGenerales("S/", comprobante.igv1)
        'IMPORTE TOTAL
        a.AnadirDatosGenerales("S/", comprobante.total)
        'DESCRIPCION DEL IMPORTE TOTAL EN LETRAS
        'a.AnadirLineaTotalFactura(comprobante.total)
        'IMPRIMIR LA FACTUIRA

        a.HORAsALIDA = comprobante.fechaProgramada.Value.ToLongTimeString

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


    Public Sub cargarBus(id As Integer, bus As String, idProgramacion As Integer)
        txtNombreBus.Text = bus
        txtNombreBus.Tag = id
        programacion_ID = idProgramacion
        lblPrecioTotal.Value = 0.0
        LabelAsientoSel.Text = "0"
        LLAMARiNFRAESTRUCTURA(txtNombreBus.Tag, idProgramacion)
    End Sub

    Public Sub LLAMARiNFRAESTRUCTURA(idActivo As Integer, idProgramacion As Integer)
        Try



            Dim atributos As New FileAttributes
            Dim distribucionInfraestructuraSA As New VehiculoAsiento_PreciosSA
            Dim distribucionInfraestructuraBE As New vehiculoAsiento_Precios
            Dim conteo As Integer = 0
            Dim sumatoriaBoton As Integer = 1

            Dim estado As String = String.Empty
            estado = "U, A, L"

            distribucionInfraestructuraBE.moneda = "1"
            distribucionInfraestructuraBE.numeracion = idProgramacion
            distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            distribucionInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            distribucionInfraestructuraBE.moneda = "VPN"
            distribucionInfraestructuraBE.estado = "A"
            distribucionInfraestructuraBE.usuarioActualizacion = estado
            distribucionInfraestructuraBE.piso = 1
            distribucionInfraestructuraBE.segmento = idActivo

            listaDistribucion = distribucionInfraestructuraSA.getInfraestructuraTransporteXProgramacion(distribucionInfraestructuraBE)

            DibujarControl(listaDistribucion)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub DibujarControl(listDistr As List(Of vehiculoAsiento_Precios))
        '//IMAGNE 
        FlowNumero1.Controls.Clear()
        FlowNumero2.Controls.Clear()
        FlowNumero3.Controls.Clear()
        FlowNumero4.Controls.Clear()
        FlowPiso2Medio.Controls.Clear()
        FlowPrimerPisoSector1.Controls.Clear()
        FlowPrimerPisoSector2.Controls.Clear()
        FlowPrimerPisoSector3.Controls.Clear()
        FlowPrimerPisoSector4.Controls.Clear()
        FlowPrimerPisoMedio.Controls.Clear()
        libres = 0
        vendidos = 0
        reservado = 0
        For Each items In listDistr

            Dim b As New RoundButton2

            'ContextMenuStrip = New ContextMenuStrip()
            'ContextMenuStrip.Items.Add("ANULAR")
            'b.ContextMenuStrip = ContextMenuStrip

            b.Text = items.numeracion
            b.TextAlign = ContentAlignment.MiddleLeft
            b.TabIndex = 0
            b.FlatStyle = FlatStyle.Standard
            b.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            b.ForeColor = System.Drawing.Color.White
            b.Size = New System.Drawing.Size(45, 45)
            b.Font = New Font(" Arial Narrow", 10, FontStyle.Bold)
            b.Tag = items


            'b.Image = ImageList1.Images(0)
            'b.ImageAlign = ContentAlignment.MiddleCenter
            'b.TextImageRelation = TextImageRelation.ImageAboveText
            'b.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            b.UseVisualStyleBackColor = False

            Select Case items.segmento
                Case "SECTOR 1"
                    Select Case items.piso
                        Case "PISO 1"
                            FlowPrimerPisoSector1.Controls.Add(b)
                        Case "PISO 2"
                            FlowNumero1.Controls.Add(b)
                    End Select
                Case "SECTOR 2"
                    Select Case items.piso
                        Case "PISO 1"
                            FlowPrimerPisoSector2.Controls.Add(b)
                        Case "PISO 2"
                            FlowNumero2.Controls.Add(b)
                    End Select
                Case "SECTOR 3"
                    Select Case items.piso
                        Case "PISO 1"
                            FlowPrimerPisoMedio.Controls.Add(b)
                        Case "PISO 2"
                            FlowPiso2Medio.Controls.Add(b)
                    End Select
                Case "SECTOR 4"
                    Select Case items.piso
                        Case "PISO 1"
                            FlowPrimerPisoSector3.Controls.Add(b)
                        Case "PISO 2"
                            FlowNumero3.Controls.Add(b)
                    End Select
                Case "SECTOR 5"
                    Select Case items.piso
                        Case "PISO 1"
                            FlowPrimerPisoSector4.Controls.Add(b)
                        Case "PISO 2"
                            FlowNumero4.Controls.Add(b)
                    End Select

            End Select

            Select Case items.estado
                Case "A"
                    libres = libres + 1
                    b.BackgroundImage = My.Resources.libreTrans
                    b.BackgroundImage.Tag = 1
                    b.BackgroundImageLayout = ImageLayout.Zoom
                    b.Name = 0
                Case "U"
                    vendidos = vendidos + 1
                    b.BackgroundImage = My.Resources.usadoTrans
                    b.BackgroundImage.Tag = 1
                    b.BackgroundImageLayout = ImageLayout.Zoom
                    'b.ContextMenuStrip.Tag = items
                    'b.ContextMenuStrip.Name = 1
                    'b.ContextMenuStrip.Text = items.descripcionDistribucion & " - " & items.numeracion
                    b.Name = 1
                Case "R"
                    reservado = reservado + 1
                    b.BackgroundImage = My.Resources.reservado4
                    b.BackgroundImage.Tag = 1
                    b.BackgroundImageLayout = ImageLayout.Zoom
                    'b.ContextMenuStrip.Tag = items
                    'b.ContextMenuStrip.Name = 1
                    'b.ContextMenuStrip.Text = items.descripcionDistribucion & " - " & items.numeracion
                    b.Name = 2
                Case "L"
                    libres = libres + 1
                    b.BackgroundImage = My.Resources.seleccioandoTrans
                    b.BackgroundImage.Tag = 1
                    b.BackgroundImageLayout = ImageLayout.Zoom
                    b.Name = 0

                Case "E"
                    b.Text = ""
                    b.Enabled = False
                    b.BackgroundImage = My.Resources.Text_Edit
                    b.BackgroundImage.Tag = 1
                    b.BackgroundImageLayout = ImageLayout.Zoom
                    b.Name = 3
            End Select

            'AddHandler b.ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
            Me.ToolTip1.IsBalloon = True

            Me.ToolTip1.SetToolTip(b, items.sexo)
            AddHandler b.Click, AddressOf Butto1
        Next
        lblLibres.Text = libres
        lblVendedios.Text = vendidos
        lblReserva.Text = reservado
    End Sub




    Private Sub Butto1(sender As Object, e As EventArgs)
        Dim productoBE As New documentoventaAbarrotes
        Dim distribucionInfraestructuraSA As New VehiculoAsiento_PreciosSA
        Dim distribucionInfraestructuraBE As New vehiculoAsiento_Precios
        Dim documentoventaSA As New VehiculoAsiento_PreciosSA
        Dim comprobanteTransporte As New documentoventaTransporte
        Dim comprobanteEntidad As New entidad
        Dim ventaSA As New DocumentoventaTransporteSA
        Try
            LimpiarCajasTransporte()

            Dim asiento = CType(sender.Tag, vehiculoAsiento_Precios)
            Select Case tipoLista
                Case "T"
                    If (sender.name = 0) Then


                        distribucionInfraestructuraBE = New vehiculoAsiento_Precios
                        distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                        distribucionInfraestructuraBE.precio_id = asiento.precio_id
                        distribucionInfraestructuraBE.estado = "L"
                        distribucionInfraestructuraBE.programacion_id = programacion_ID
                        distribucionInfraestructuraBE.idDistribucion = sender.TEXT

                        documentoventaSA.updateAsientoTransportexIDxVerificaion(distribucionInfraestructuraBE)

                        LLAMARiNFRAESTRUCTURA(txtNombreBus.Tag, programacion_ID)

                        ''If sender.BackgroundImage Is My.Resources.libreTrans Then
                        'sender.BackgroundImage = My.Resources.seleccioandoTrans
                        tipoSeleccion = True
                        LabelAsientoSel.Text = asiento.numeracion
                        LabelAsientoSel.Tag = asiento.precio_id
                        lblPrecioTotal.Value = 0.0 ' CDec(asiento.precioAsientoMN).ToString("N2")
                        txtDescripcion.Text = asiento.descripcionItem
                        txtDescripcion.Tag = asiento.destino
                        cboDestino.Select()
                        cboDestino.Focus()
                        cboDestino.DroppedDown = True
                        ''ElseIf sender.BackgroundImage Is My.Resources.seleccioandoTrans Then
                        ''    sender.BackgroundImage = My.Resources.libreTrans
                        ''    sender.BackgroundImage.tag = False
                        ''    LabelAsientoSel.Text = "0"
                        ''    lblPrecioTotal.Text = "0.00"
                        ''End If

                        tipoManipulacion = "VENTA"
                        CheckBox1.Visible = True
                        BtConfirmarVenta.Visible = True
                        btnReserva.Visible = False
                        CheckBox1.Visible = True
                        CheckBox1.Checked = False
                        BtConfirmarVenta.Visible = True
                        btnReserva.Visible = False
                        btnEliminarReserva.Visible = False
                    ElseIf (sender.NAME = 1) Then



                        comprobanteTransporte = ventaSA.DocumentoTransporteSelIDVehiculoXProg(New documentoventaTransporte With
                                                                                     {
                                                                                     .idDistribucion = CInt(asiento.numeracion),
                                                                                     .programacion_id = programacion_ID
                                                                                     })

                        If (Not IsNothing(comprobanteTransporte)) Then

                            comprobanteEntidad = entidadSA.UbicarEntidadPorID(comprobanteTransporte.idPersona).FirstOrDefault

                            tipoManipulacion = "VER"
                            CheckBox1.Visible = False
                            lblPrecioTotal.Value = comprobanteTransporte.total
                            textPersona.Text = comprobanteEntidad.nombreCompleto
                            textPersona.Tag = comprobanteEntidad.idEntidad
                            txtruc.Text = comprobanteEntidad.nrodoc
                            txtEdad.Text = comprobanteTransporte.edad
                            cboSexo.Text = asiento.sexo
                            textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                            tipoSeleccion = True
                            LabelAsientoSel.Text = asiento.numeracion
                            LabelAsientoSel.Tag = asiento.precio_id

                            cboTipoDoc.Text = "BOLETA ELECTRONNICA"
                            btnReserva.Visible = False
                            BtConfirmarVenta.Visible = True

                            BtConfirmarVenta.Visible = False
                            btnReserva.Visible = False
                            btnEliminarReserva.Visible = False

                            Dim IdCentro As Integer = 0
                            Dim lista = ListaAgencias.Where(Function(o) o.TipoEstab = "UN" And o.ubigeo <> ubigeoOrigen).ToList
                            Dim IDPADRE As New centrocosto

                            If (comprobanteTransporte.UbigeoCiudadDestino.Length > 0) Then
                                IDPADRE = LISTAESTABLECIMIENTO.Where(Function(O) O.TipoEstab = "UN" And O.ubigeo = comprobanteTransporte.UbigeoCiudadDestino).FirstOrDefault
                                txtUbigeo.Text = LISTAESTABLECIMIENTO.Where(Function(O) O.TipoEstab = "SE" And O.idCentroCosto = IDPADRE.idpadre).FirstOrDefault.nombre
                                txtUbigeo.Tag = IDPADRE.ubigeo
                                IdCentro = CInt(lista.Where(Function(o) o.TipoEstab = "UN" And o.idCentroCosto = IDPADRE.idCentroCosto).FirstOrDefault.idCentroCosto)
                                cboDestino.SelectedValue = IdCentro

                            End If
                        End If



                    ElseIf (sender.NAME = 2) Then

                        comprobanteTransporte = ventaSA.DocumentoTransporteSelIDVehiculoXProg(New documentoventaTransporte With
                                                                                 {
                                                                                 .idDistribucion = CInt(asiento.numeracion),
                                                                                 .programacion_id = programacion_ID
                                                                                 })

                        If (Not IsNothing(comprobanteTransporte)) Then

                            Dim IdCentro As Integer = 0
                            Dim lista = ListaAgencias.Where(Function(o) o.TipoEstab = "UN" And o.ubigeo <> ubigeoOrigen).ToList
                            Dim IDPADRE As New centrocosto

                            comprobanteEntidad = entidadSA.UbicarEntidadPorID(comprobanteTransporte.idPersona).FirstOrDefault

                            tipoManipulacion = "RESERVACION"
                            CheckBox1.Visible = False
                            tipoSeleccion = True
                            LabelAsientoSel.Text = asiento.numeracion
                            LabelAsientoSel.Tag = asiento.precio_id

                            If (comprobanteEntidad.nombreCompleto = "Varios") Then
                                textPersona.Text = comprobanteTransporte.comprador
                            Else
                                textPersona.Text = comprobanteEntidad.nombreCompleto
                            End If

                            lblPrecioTotal.Value = comprobanteTransporte.total

                            textPersona.Tag = comprobanteEntidad.idEntidad
                            txtruc.Text = comprobanteEntidad.nrodoc
                            txtEdad.Text = comprobanteTransporte.edad
                            cboSexo.Text = asiento.sexo
                            textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            idDocReferecia = comprobanteTransporte.idDocumento

                            If (comprobanteTransporte.UbigeoCiudadDestino.Length > 0) Then
                                IDPADRE = LISTAESTABLECIMIENTO.Where(Function(O) O.TipoEstab = "UN" And O.ubigeo = comprobanteTransporte.UbigeoCiudadDestino).FirstOrDefault
                                txtUbigeo.Text = LISTAESTABLECIMIENTO.Where(Function(O) O.TipoEstab = "SE" And O.idCentroCosto = IDPADRE.idpadre).FirstOrDefault.nombre
                                txtUbigeo.Tag = IDPADRE.ubigeo
                                IdCentro = CInt(lista.Where(Function(o) o.TipoEstab = "UN" And o.idCentroCosto = IDPADRE.idCentroCosto).FirstOrDefault.idCentroCosto)
                                cboDestino.SelectedValue = IdCentro

                            End If

                            cboTipoDoc.Text = "BOLETA ELECTRONNICA"
                            btnReserva.Visible = False
                            BtConfirmarVenta.Visible = True
                            btnEliminarReserva.Visible = True

                            'If MessageBox.Show("¿Desea Anular el pasaje?", "ANULAR PASAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

                            '    If My.Computer.Network.IsAvailable = True Then


                            '        Dim DOCUMENTOVENTABE As New documentoventaTransporteDetalle
                            '        DOCUMENTOVENTABE.idDistribucion = asiento.precio_id

                            '        Dim documentoTransportesa As New DocumentoventaTransporteSA
                            '        Dim IDDOCTRANSPORTE As Integer
                            '        Dim ENVIOSUNAT As String
                            '        Dim documentoTransporte As New documentoventaTransporte
                            '        documentoTransporte = documentoTransportesa.GetTransporteDocXIDAnulacion(DOCUMENTOVENTABE)

                            '        Dim f As New FormAnularVenta(CDate(documentoTransporte.fechadoc))
                            '        f.StartPosition = FormStartPosition.CenterParent
                            '        f.ShowDialog(Me)
                            '        If f.Tag IsNot Nothing Then
                            '            Dim c = CType(f.Tag, Boolean)
                            '            If c = True Then 'fecha dentro del rango permitido



                            '                Dim objeto As New documentoventaAbarrotes
                            '                objeto.idDocumento = CInt(documentoTransporte.idDocumento)
                            '                objeto.tipoDocumento = documentoTransporte.tipoDocumento
                            '                objeto.serieVenta = documentoTransporte.serie
                            '                objeto.numeroVenta = CInt(documentoTransporte.numero)
                            '                objeto.fechaDoc = CDate(documentoTransporte.fechadoc)
                            '                IDDOCTRANSPORTE = CInt(documentoTransporte.idDocumento)
                            '                ENVIOSUNAT = (documentoTransporte.EnvioSunat)

                            '                Try
                            '                    If Gempresas.ubigeo > 0 Then
                            '                        'If My.Computer.Network.IsAvailable = True Then
                            '                        If My.Computer.Network.Ping("138.128.171.106") Then

                            '                            Try
                            '                                EliminarPV(Val(IDDOCTRANSPORTE))

                            '                                MessageBox.Show("Documento anulado con exito!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            '                                Dim envio = ENVIOSUNAT
                            '                                If (Not IsNothing(envio)) Then
                            '                                    If envio.ToString.Trim.Length > 0 Then
                            '                                        EnviarAnulacionDocumento(objeto)
                            '                                    End If
                            '                                End If

                            '                                distribucionInfraestructuraBE = New vehiculoAsiento_Precios
                            '                                distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                            '                                distribucionInfraestructuraBE.precio_id = asiento.precio_id
                            '                                distribucionInfraestructuraBE.estado = "A"

                            '                                documentoventaSA.updateAsientoTransportexID(distribucionInfraestructuraBE)

                            '                                LLAMARiNFRAESTRUCTURA(txtNombreBus.Tag, programacion_ID)

                            '                            Catch ex As Exception
                            '                                MsgBox(ex.Message)
                            '                                'MessageBox.Show("No se pudo eliminar el periodo esta cerrado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '                            End Try

                            '                        Else
                            '                            MessageBox.Show("No tiene conexión con el servidor SPK!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '                        End If
                            '                        'Else
                            '                        '    MessageBox.Show("No tiene conexión a internet!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '                        'End If
                            '                    Else


                            '                        EliminarPV(Val(IDDOCTRANSPORTE))

                            '                        distribucionInfraestructuraBE = New vehiculoAsiento_Precios
                            '                        distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                            '                        distribucionInfraestructuraBE.precio_id = asiento.precio_id
                            '                        distribucionInfraestructuraBE.estado = "A"

                            '                        documentoventaSA.updateAsientoTransportexID(distribucionInfraestructuraBE)

                            '                        LLAMARiNFRAESTRUCTURA(txtNombreBus.Tag, programacion_ID)

                            '                    End If

                            '                Catch ex As Exception
                            '                    MessageBox.Show(ex.Message)
                            '                End Try
                            '            Else
                            '                MessageBox.Show("No puede anular la venta, debe estar dentro del rango de 5 días hábiles!", "Validar fechas", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '            End If
                            '        End If
                            '    Else
                            '        MessageBox.Show("No tiene conexión a internet!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '    End If

                            BtConfirmarVenta.Visible = True
                            btnReserva.Visible = False

                        End If
                    End If
            End Select

        Catch ex As Exception
            LLAMARiNFRAESTRUCTURA(txtNombreBus.Tag, programacion_ID)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    'Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    '    Try
    '        Dim ASIENTO = CType(sender.Tag, distribucionInfraestructura)

    '        If (sender.NAME = 1) Then



    '            If (e.ClickedItem.Text = "ANULAR") Then


    '                If My.Computer.Network.IsAvailable = True Then
    '                    Dim f As New FormAnularVenta(CDate(LabelfechaProg.Text))
    '                    f.StartPosition = FormStartPosition.CenterParent
    '                    f.ShowDialog(Me)
    '                    If f.Tag IsNot Nothing Then
    '                        Dim c = CType(f.Tag, Boolean)
    '                        If c = True Then 'fecha dentro del rango permitido

    '                            Dim DOCUMENTOVENTABE As New documentoventaTransporteDetalle
    '                            DOCUMENTOVENTABE.idDistribucion = ASIENTO.idDistribucion

    '                            Dim documentoTransportesa As New DocumentoventaTransporteSA
    '                            Dim IDDOCTRANSPORTE As Integer
    '                            Dim ENVIOSUNAT As String
    '                            Dim documentoTransporte As New documentoventaTransporte
    '                            documentoTransporte = documentoTransportesa.DocumentoTransportexID(DOCUMENTOVENTABE)

    '                            Dim objeto As New documentoventaAbarrotes
    '                            objeto.idDocumento = CInt(documentoTransporte.idDocumento)
    '                            objeto.tipoDocumento = documentoTransporte.tipoDocumento
    '                            objeto.serieVenta = documentoTransporte.serie
    '                            objeto.numeroVenta = CInt(documentoTransporte.numero)
    '                            objeto.fechaDoc = CDate(documentoTransporte.fechadoc)
    '                            IDDOCTRANSPORTE = CInt(documentoTransporte.idDocumento)
    '                            ENVIOSUNAT = (documentoTransporte.EnvioSunat)

    '                            Try
    '                                If Gempresas.ubigeo > 0 Then
    '                                    'If My.Computer.Network.IsAvailable = True Then
    '                                    If My.Computer.Network.Ping("138.128.171.106") Then

    '                                        Try
    '                                            EliminarPV(Val(IDDOCTRANSPORTE))
    '                                            'EnviarComunicacionBaja(objeto)

    '                                            Dim envio = ENVIOSUNAT
    '                                            If envio.ToString.Trim.Length > 0 Then
    '                                                EnviarAnulacionDocumento(objeto)
    '                                            End If

    '                                        Catch ex As Exception
    '                                            MsgBox(ex.Message)
    '                                            'MessageBox.Show("No se pudo eliminar el periodo esta cerrado", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                        End Try

    '                                    Else
    '                                        MessageBox.Show("No tiene conexión con el servidor SPK!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                    End If
    '                                    'Else
    '                                    '    MessageBox.Show("No tiene conexión a internet!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                    'End If
    '                                Else
    '                                    EliminarPV(Val(IDDOCTRANSPORTE))
    '                                End If

    '                            Catch ex As Exception
    '                                MessageBox.Show(ex.Message)
    '                            End Try
    '                        Else
    '                            MessageBox.Show("No puede anular la venta, debe estar dentro del rango de 5 días hábiles!", "Validar fechas", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                        End If
    '                    End If
    '                Else
    '                    MessageBox.Show("No tiene conexión a internet!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                End If

    '            End If
    '        Else
    '            MessageBox.Show("Debe seleccionar")
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub

    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0

        'If (ChPagoAvanzado.Checked = True And lblPagoVenta.Text > 0) Then
        '    ErrorProvider1.SetError(Label8, "Debe efectuar la totalidad del pago")
        '    listaErrores += 1
        'End If

        If lblPrecioTotal.Value <= 0 Then
            ErrorProvider1.SetError(lblPrecioTotal, "La venta debe ser mayor a cero")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(lblPrecioTotal, Nothing)
        End If

        If listaErrores > 0 Then
            ValidarGrabado = False
        Else
            ValidarGrabado = True
        End If
    End Function

    'Dim conf As New GConfiguracionModulo
    'Private Sub GetNumeracion(strIdModulo As String, strIDEmpresa As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    conf = New GConfiguracionModulo
    '    conf = ConfigurarComprobanteVenta(moduloConfiguracion)
    '    'SetDataSourceNumeracion(moduloConfiguracion)
    'End Sub

    'Public Function ConfigurarComprobanteVenta(moduloConfiguracion As moduloConfiguracion) As GConfiguracionModulo
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion2 = New GConfiguracionModulo
    '            GConfiguracion2.IdModulo = .idModulo
    '            GConfiguracion2.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion2.ConfigComprobante = .IdEnumeracion

    '                        If cboTipoDoc.Text = "BOLETA" Then
    '                            GConfiguracion2.TipoComprobante = "12.1" ' .tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial

    '                        End If
    '                        If cboTipoDoc.Text = "FACTURA" Then
    '                            GConfiguracion2.TipoComprobante = "12.2" '.tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial

    '                        End If

    '                        If cboTipoDoc.Text = "FACTURA ELECTRONICA" Then

    '                            GConfiguracion2.TipoComprobante = "01" '.tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial


    '                        End If
    '                        If cboTipoDoc.Text = "BOLETA ELECTRONICA" Then
    '                            GConfiguracion2.TipoComprobante = "03" ' .tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial

    '                        End If

    '                        If cboTipoDoc.Text = "PROFORMA" Then
    '                            GConfiguracion2.TipoComprobante = .tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial
    '                        End If

    '                        If cboTipoDoc.Text = "RESERVACION" Then
    '                            GConfiguracion2.TipoComprobante = "12"
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial
    '                        End If
    '                    End With
    '                Case "M"

    '            End Select

    '        End With
    '    Else
    '        '  lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        ' Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
    '    Return GConfiguracion
    'End Function

    Public Function configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer) As GConfiguracionModulo
        Try
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)

                If cboTipoDoc.Text = "BOLETA" Then
                    GConfiguracion.TipoComprobante = "12.1" ' .tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial

                End If
                If cboTipoDoc.Text = "FACTURA" Then
                    GConfiguracion.TipoComprobante = "12.2" '.tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial

                End If

                If cboTipoDoc.Text = "FACTURA ELECTRONICA" Then

                    GConfiguracion.TipoComprobante = "01" '.tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial


                End If
                If cboTipoDoc.Text = "BOLETA ELECTRONICA" Then
                    GConfiguracion.TipoComprobante = "03" ' .tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial

                End If

                If cboTipoDoc.Text = "PROFORMA" Then
                    GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
                End If

                If cboTipoDoc.Text = "RESERVACION" Then
                    GConfiguracion.TipoComprobante = "12"
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
                End If
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return GConfiguracion
    End Function

    Private Sub GrabarVentaPasaje(envio As EnvioImpresionVendedorPernos)
        Dim ventaSA As New DocumentoventaTransporteSA

        configuracionModuloV2(Gempresas.IdEmpresaRuc, "COTIZACION", "", GEstableciento.IdEstablecimiento)


        Dim tipodoc As String = String.Empty
        Select Case cboTipoDoc.Text
            Case "BOLETA ELECTRONICA"
                tipodoc = "03"
            Case "FACTURA ELECTRONICA"
                tipodoc = "01"
            Case "RESERVAR"
                tipodoc = "9901"
        End Select

        Dim documento As New documento With
        {
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .tipoDoc = tipodoc,
        .fechaProceso = Date.Now,
        .moneda = "1",
        .idEntidad = txtruc.Tag,
        .entidad = textPersona.Text,
        .tipoEntidad = "PS",
        .nrodocEntidad = txtruc.Text,
        .nroDoc = "1",
        .idOrden = 0,
        .tipoOperacion = StatusTipoOperacion.VENTA,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }

        documento.documentoventaTransporte = New documentoventaTransporte With
        {
        .tareo_id = 1,
        .programacion_id = Integer.Parse(programacion_ID),
        .TipoConfiguracion = If(GConfiguracion Is Nothing, Nothing, GConfiguracion.TipoConfiguracion),
        .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
        .tipoOperacion = StatusTipoOperacion.VENTA,
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idOrganizacion = GEstableciento.IdEstablecimiento,
        .UbigeoCiudadOrigen = ubigeoOrigen,
        .ciudadOrigen = txtOrigen.Text,
        .UbigeoCiudadDestino = txtUbigeo.Tag,
        .ciudadDestino = cboDestino.Text,
        .tipoDocumento = tipodoc,
        .fechaProgramada = LabelfechaProg.Text,
        .fechadoc = Date.Now,
        .serie = GConfiguracion.Serie,
        .numero = 0,
        .idPersona = Integer.Parse(textPersona.Tag),
        .razonSocial = Integer.Parse(textPersona.Tag),
        .comprador = textPersona.Text,
        .moneda = "1",
        .tipocambio = 1,
        .tasaIgv = 0.18,
        .baseImponible1 = lblPrecioTotal.Value,
        .baseImponible2 = 0,
        .igv1 = 0,
        .igv2 = 0,
        .total = lblPrecioTotal.Value,
        .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
        .glosa = "Venta de pasajes",
        .tipoVenta = TIPO_VENTA.VENTA_PASAJES_RESERVACION,
        .numeroAsiento = Integer.Parse(LabelAsientoSel.Text),
        .estado = 6,
        .edad = txtEdad.Text,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }

        Dim docdet As documentoventaTransporteDetalle = New documentoventaTransporteDetalle With
        {
        .[tipo] = TIPO_VENTA.VENTA_PASAJES_RESERVACION,
       .[codigoBarraSerie] = Nothing,
        .[detalle] = "POR VENTA DE PASAJE : ASIENTO - " & Integer.Parse(LabelAsientoSel.Text),
        .[sku] = Nothing,
        .[cantidad] = 1,
        .[unidadMedida] = "NIU",
        .[importe] = lblPrecioTotal.Value,
        .[agencia_id] = Nothing,
        .[estado] = "6",
        .[manifiesto] = manifiesto,
        .[idDistribucion] = LabelAsientoSel.Tag,
        .[estadoDiustribucion] = "A",
        .[usuarioActualizacion] = usuario.IDUsuario,
        .[fechaActualizacion] = Date.Now
             }

        documento.documentoventaTransporte.documentoventaTransporteDetalle.Add(docdet)

        documento.IDCajaUsuario = envio.IDCaja

        ''Dim ListaPagos = ListaPagosCajas(documento.documentoventaTransporte, envio)
        'documento.documentoventaTransporte.estadoCobro = TIPO_VENTA.PAGO.COBRADO
        'documento.ListaCustomDocumento = ListaPagos 'ListaPagosCajas(c)
        'documento.documentoventaTransporte.CustomVehiculoAsiento_Precios = vehiculoAsientoPrecios
        Dim codVenta = ventaSA.DocumentoventaTransporteSave(documento)
        'formVentaPasajes.ReiniciarForm(True, codVenta)
        'Dim miInterfaz As ICommitOperacionMKT = TryCast(Me.Owner.t, ICommitOperacionMKT)
        'If miInterfaz IsNot Nothing Then miInterfaz.Commit(True, codVenta)

        Dim documentoventaSA As New VehiculoAsiento_PreciosSA
        Dim documentoventaBE As New vehiculoAsiento_Precios

        documentoventaBE.idEmpresa = Gempresas.IdEmpresaRuc
        documentoventaBE.precio_id = LabelAsientoSel.Tag
        documentoventaBE.estado = "R"
        documentoventaBE.sexo = cboSexo.Text
        documentoventaSA.updateAsientoTransporteConfirmacionxID(documentoventaBE)

        'ventaSA.DocumentoTransporteSelIDVer2(New documentoventaTransporte With
        '                                                       {
        '                                                       .idDocumento = codVenta
        '                                                       })
        'comprobanteEntidad = entidadSA.UbicarEntidadPorID(comprobanteTransporte.razonSocial).FirstOrDefault

        'If Gempresas.ubigeo > 0 Then
        '    If My.Computer.Network.IsAvailable = True Then
        '        If My.Computer.Network.Ping("138.128.171.106") Then
        '            If cboTipoDoc.Text = "FACTURA ELECTRONICA" Or cboTipoDoc.Text = "BOLETA ELECTRONICA" Then
        '                'EnvioPSE(Gempresas.IdEmpresaRuc, impresionTicketDoc.idDocumento)
        '                EnviarFacturaElectronica(codVenta, Gempresas.ubigeo)
        '            End If
        '        End If
        '    End If
        'End If

        'ImprimirTicketA4v2("TICKET/RUTA", codVenta, comprobanteTransporte, comprobanteEntidad)

        'FormImpresionNuevo = New FormImpresionEquivalencia()
        ''FormImpresionNuevo.tienda = UCEstructuraCabeceraVentaV2.txtInfraestructura.Text
        'FormImpresionNuevo.FormaPago = ""
        'FormImpresionNuevo.DocumentoID = comprobanteTransporte.idDocumento
        'FormImpresionNuevo.Email = ""
        'FormImpresionNuevo.FormaPago = "TR"
        'FormImpresionNuevo.LLAMARENTIDAD = comprobanteEntidad
        'FormImpresionNuevo.LLAMARTRANSPORTE = comprobanteTransporte
        'FormImpresionNuevo.StartPosition = FormStartPosition.CenterScreen
        'FormImpresionNuevo.ShowDialog(Me)

        Me.Tag = 1
        If Tag IsNot Nothing Then
            If (Tag = 1) Then
                LimpiarCajasTransporte()
                LLAMARiNFRAESTRUCTURA(txtNombreBus.Tag, programacion_ID)
            End If
        End If
    End Sub

    Private Function GetMappingEnvio(id_ruta As Integer) As rutaTareoAutos
        Dim rutaSA As New RutasSA
        Dim persona As Persona = Nothing
        Dim razonSocialEmpresa As entidad = Nothing
        Dim rutaSel As rutas = Nothing
        Dim servicio As ruta_HorarioServicios = Nothing

        GetMappingEnvio = New rutaTareoAutos

        If RBJuridico.Checked = True Then
            GetMappingEnvio.tipoPersona = "J"

            persona = New Persona
            persona.idEmpresa = Gempresas.IdEmpresaRuc
            persona.idOrganizacion = GEstableciento.IdEstablecimiento
            persona.codigo = textPersona.Tag
            persona.idPersona = txtruc.Text
            persona.tipoPersona = "N"
            persona.tipodoc = "1"
            persona.nombreCompleto = textPersona.Text


            razonSocialEmpresa = New entidad
            razonSocialEmpresa.idEmpresa = Gempresas.IdEmpresaRuc
            razonSocialEmpresa.idOrganizacion = GEstableciento.IdEstablecimiento
            razonSocialEmpresa.tipoEntidad = ""
            razonSocialEmpresa.nrodoc = TextNumIdentrazon.Text
            razonSocialEmpresa.tipoPersona = "J"
            razonSocialEmpresa.tipoDoc = "6"
            razonSocialEmpresa.nombreCompleto = TextEmpresaPasajero.Text
            razonSocialEmpresa.idEntidad = TextEmpresaPasajero.Tag

            'persona = listaPersonas.Where(Function(o) o.codigo = CInt(textPersona.Tag)).SingleOrDefault
            'razonSocialEmpresa = listaClientes.Where(Function(o) o.idEntidad = CInt(TextEmpresaPasajero.Tag)).SingleOrDefault
            rutaSel = rutaSA.RutaSelID(New rutas With {.ruta_id = id_ruta}) ' ListaRutasActivas.Where(Function(o) o.ruta_id = id_ruta).SingleOrDefault
            'servicio = listaServicios.Where(Function(o) o.codigoServicio = CodigoServicio).SingleOrDefault
        ElseIf RBNatural.Checked = True Then
            GetMappingEnvio.tipoPersona = "N"
            'persona = listaPersonas.Where(Function(o) o.codigo = CInt(textPersona.Tag)).SingleOrDefault

            persona = New Persona
            persona.idEmpresa = Gempresas.IdEmpresaRuc
            persona.idOrganizacion = GEstableciento.IdEstablecimiento
            persona.codigo = textPersona.Tag
            persona.idPersona = txtruc.Text
            persona.tipoPersona = "N"
            persona.tipodoc = "1"
            persona.nombreCompleto = textPersona.Text

            'razonSocialEmpresa = listaClientes.Where(Function(o) o.idEntidad = CInt(TextEmpresaPasajero.Tag)).SingleOrDefault
            rutaSel = rutaSA.RutaSelID(New rutas With {.ruta_id = id_ruta}) 'ListaRutasActivas.Where(Function(o) o.ruta_id = id_ruta).SingleOrDefault
            'servicio = listaServicios.Where(Function(o) o.codigoServicio = CodigoServicio).SingleOrDefault
        End If


        Select Case cboTipoDoc.Text
            Case "BOLETA ELECTRONICA"
                GetMappingEnvio.TipoDocVenta = "03"
            Case "FACTURA ELECTRONICA"
                GetMappingEnvio.TipoDocVenta = "01"
            Case Else
                GetMappingEnvio.TipoDocVenta = "9901"
        End Select
        GetMappingEnvio.ImporteVenta = CDec(lblPrecioTotal.Value)
        GetMappingEnvio.Asiento = CInt(LabelAsientoSel.Text)
        GetMappingEnvio.customRuta = rutaSel ' Tareo.customRuta
        GetMappingEnvio.customruta_horarios = rutaSel.ruta_horarios.FirstOrDefault ' Tareo.customruta_horarios
        GetMappingEnvio.customRuta_HorarioServicios = servicio
        GetMappingEnvio.customPersona = persona
        GetMappingEnvio.customEntidad = razonSocialEmpresa
    End Function


    Public Sub getCargarCombos()
        Dim ActivosFijosSA As New ActivosFijosSA
        Dim activosFijosBE As New List(Of activosFijos)
        Dim NuevoActivo As New activosFijos

        NuevoActivo.idActivo = 0
        NuevoActivo.descripcionItem = "Elija una opción"

        activosFijosBE.Add(NuevoActivo)
        activosFijosBE.AddRange(ActivosFijosSA.GetListar_activosFijos())

        If NuevoActivo IsNot Nothing Then
            cboActivosFijos.DataSource = activosFijosBE
            cboActivosFijos.ValueMember = "idActivo"
            cboActivosFijos.DisplayMember = "descripcionItem"
            cboActivosFijos.ReadOnly = False
        End If
    End Sub

    Private Sub GetCerrarVentas(prog_id As Integer, estado As General.Transporte.ProgramacionEstado)
        Dim programacionSA As New RutaProgramacionSalidasSA
        Dim obj As New rutaProgramacionSalidas With
        {
        .programacion_id = prog_id,
        .estado = estado
        }
        programacionSA.UpdateEstadoProgramacion(obj)
        'If estado = ProgramacionEstado.VentaCerrada Then
        '    ListProgamacion.SelectedItems(0).Remove()
        'End If
        MessageBox.Show("Ruta enviada a zona de embarque!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'CerrarVenta()
    End Sub

#Region "BUSQUEDA RUC"

    Private Function GetConsultarDNIReniec(Dni As String) As String
        Dim CLIENTE As New WebClient
        'Dim PAGINA As Stream = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" & Dni)
        Dim PAGINA As Stream = CLIENTE.OpenRead("http://clientes.reniec.gob.pe/padronElectoral2012/consulta.htm?hTipo=2&hDni=" & Dni)
        Dim LECTOR As New StreamReader(PAGINA)
        Dim MIHTML As String = LECTOR.ReadToEnd
        Dim nombres = String.Empty
        ' Dim array = MIHTML.Split("|")
        Dim posicion = 0
        Dim doc As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument
        doc.LoadHtml(MIHTML)

        For Each node As HtmlTextNode In doc.DocumentNode.SelectNodes("//text()")
            Select Case posicion
                Case 36
                    nombres = node.Text
                    Exit For
                Case 42
                   ' TextDNI.Text = node.Text
                Case 60
                  '  TextProvincia.Text = node.Text
                Case 66
                 '   TextDepartamento.Text = node.Text
                Case 54
                    '   TextDistrito.Text = node.Text
            End Select
            posicion = posicion + 1
        Next


        '  nombres = MIHTML.Replace("|", Space(1))
        Return Trim(nombres)
    End Function

    Private Function GetValidarLocalDB(idEntidad As String) As Boolean
        GetValidarLocalDB = False
        Dim entidadSA As New entidadSA

        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", idEntidad)
        If entidad IsNot Nothing Then
            SelRazon = New entidad
            SelRazon = entidad
            TextEmpresaPasajero.Text = entidad.nombreCompleto
            TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            TextEmpresaPasajero.Tag = entidad.idEntidad
            GetValidarLocalDB = True
            PictureLoad.Visible = False

            If TextEmpresaPasajero.Text.Trim.Length > 0 Then

            Else
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
            End If
        End If
    End Function

    Private Sub GrabarEntidadRapida()
        Dim obEntidad As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            obEntidad.idEmpresa = Gempresas.IdEmpresaRuc
            obEntidad.idOrganizacion = GEstableciento.IdEstablecimiento
            obEntidad.tipoEntidad = "CL"
            obEntidad.tipoDoc = SelRazon.tipoDoc
            obEntidad.tipoPersona = SelRazon.tipoPersona
            obEntidad.nrodoc = SelRazon.nrodoc
            obEntidad.nombreCompleto = TextEmpresaPasajero.Text.Trim
            obEntidad.cuentaAsiento = "1213"
            obEntidad.direccion = SelRazon.direccion
            If SelRazon.direccion IsNot Nothing Then
                If SelRazon.direccion.Trim.Length > 0 Then
                    obEntidad.entidadAtributos = New List(Of entidadAtributos)
                    obEntidad.entidadAtributos.Add(New entidadAtributos With {
                                                   .Action = BaseBE.EntityAction.INSERT,
                                                   .tipo = "DOMICILIO",
                                                   .tipoVia = SelRazon.TipoVia,
                                                   .Via = SelRazon.Via,
                                                   .ubigeo = SelRazon.Ubigeo,
                                                   .estado = 1,
                                                   .valorAtributo = SelRazon.direccion,
                                                   .usuarioModificacion = usuario.IDUsuario,
                                                   .fechaModificacion = Date.Now
                                                   })
                End If
            End If
            obEntidad.estado = StatusEntidad.Activo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            TextEmpresaPasajero.Tag = codx
            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = TextNumIdentrazon.Text.Trim
            entidad.nombreCompleto = obEntidad.nombreCompleto
            entidad.tipoDoc = obEntidad.tipoDoc
            Me.Tag = entidad
            'If RadioButton2.Checked = True Then
            '    textPersona.Focus()
            '    textPersona.Select()
            'ElseIf RadioButton1.Checked = True Then
            '    txtruc.Focus()
            '    txtruc.Select()
            'End If
            'Transporte.ListaEmpresas.Add(entidad)

            '    Dispose()
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
    End Sub

    Private Async Sub GetConsultaSunatAsync(ruc As String)
        SelRazon = New entidad
        Dim nroDoc = ruc.Substring(0, 1).ToString
        If nroDoc = "1" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                ' If company.ContribuyenteTipo = "PERSONA NATURAL SIN NEGOCIO" Then
                SelRazon.tipoPersona = "N"
                SelRazon.tipoDoc = "6"
                ' End If
                SelRazon.tipoEntidad = "CL"
                SelRazon.nombreCompleto = company.RazonSocial
                TextEmpresaPasajero.Text = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.nrodoc = company.Ruc
                SelRazon.direccion = company.DomicilioFiscal
                GrabarEntidadRapida()
                PictureLoad.Visible = False
            Else
                TextEmpresaPasajero.Clear()
                PictureLoad.Visible = False
            End If
        ElseIf nroDoc = "2" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                SelRazon.tipoPersona = "J"
                SelRazon.tipoDoc = "6"
                SelRazon.tipoEntidad = "CL"
                '  End If
                SelRazon.nombreCompleto = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                TextEmpresaPasajero.Text = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.direccion = company.DomicilioFiscal
                SelRazon.nrodoc = company.Ruc
                'If company.RepresentanteLegal IsNot Nothing Then
                '    If company.RepresentanteLegal.Dni41094462 IsNot Nothing Then
                '        With company.RepresentanteLegal.Dni41094462
                '            txtContacto.Text = String.Format("{0}/{1}/{2}", .Cargo, .Nombre, .Desde)
                '        End With
                '    End If
                'End If
                GrabarEntidadRapida()
                PictureLoad.Visible = False
            Else
                TextEmpresaPasajero.Clear()
                PictureLoad.Visible = False
            End If
        End If
        TextNumIdentrazon.ReadOnly = False
    End Sub

    Private Async Sub GetApiSunat(ByVal nroruc As String)
        SelRazon = New entidad()

        Using client = New HttpClient()

            If nroruc.ToString().Trim().Substring(0, 1) = "1" Then
                SelRazon.tipoPersona = "N"
            ElseIf nroruc.ToString().Trim().Substring(0, 1) = "2" Then
                SelRazon.tipoPersona = "J"
            End If

            'client.BaseAddress = New Uri("https://api.peruonline.cloud/v1/?ruc=10449245691")
            Dim responseTask = Await client.GetAsync("https://api.peruonline.cloud/v1/?ruc=" & nroruc)
            ' responseTask.Wait()
            'Dim result = responseTask.Result

            If responseTask.IsSuccessStatusCode Then
                Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente)()
                readTask.Wait()
                Dim students = readTask.Result
                SelRazon.tipoDoc = "6"
                SelRazon.tipoEntidad = "CL"
                SelRazon.nombreCompleto = students.NombreORazonSocial
                SelRazon.nombreContacto = students.NombreORazonSocial
                TextEmpresaPasajero.Text = students.NombreORazonSocial
                TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                'TextNumIdentrazon.Text = txtBuscador.Text
                SelRazon.estado = students.EstadoDelContribuyente
                SelRazon.nrodoc = students.Ruc
                SelRazon.direccion = students.Direccion

                SelRazon.TipoVia = students.TipoDeVia
                SelRazon.Via = students.NombreDeVia
                SelRazon.Ubigeo = students.Ubigeo

                GrabarEntidadRapida()
                PictureLoad.Visible = False
            Else
                GetConsultaSunatAsync(nroruc)

                'TextProveedor.Clear()
                'PictureLoad.Visible = False
            End If
            TextNumIdentrazon.ReadOnly = False
        End Using
    End Sub

    Private Sub GrabarEnFormBasico()
        Dim f As New frmCrearENtidades
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim ent = CType(f.Tag, entidad)
            TextNumIdentrazon.Text = ent.nrodoc
            TextEmpresaPasajero.Text = ent.nombreCompleto
            TextEmpresaPasajero.Tag = ent.idEntidad
            TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        Else
            TextNumIdentrazon.Text = String.Empty
            TextEmpresaPasajero.Text = String.Empty
            TextEmpresaPasajero.Tag = Nothing
        End If
    End Sub


    '/////////////// BUSQUEDA RUC PERSONA

    Private Sub GrabarEnFormBasicoV2()
        Dim f As New frmCrearENtidades
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim ent = CType(f.Tag, entidad)
            txtruc.Text = ent.nrodoc
            textPersona.Text = ent.nombreCompleto
            textPersona.Tag = ent.idEntidad
            textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        Else
            txtruc.Text = String.Empty
            textPersona.Text = String.Empty
            textPersona.Tag = Nothing
        End If
    End Sub

    Private Function GetValidarLocalDB2(idEntidad As String) As Boolean
        GetValidarLocalDB2 = False
        Dim entidadSA As New entidadSA

        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", idEntidad)
        If entidad IsNot Nothing Then
            SelRazon = New entidad
            SelRazon = entidad
            textPersona.Text = entidad.nombreCompleto

            textPersona.Tag = entidad.idEntidad
            GetValidarLocalDB2 = True
            PictureLoad.Visible = False

            If textPersona.Text.Trim.Length > 0 Then

            Else
                txtruc.Clear()
                txtruc.Select()
            End If
        End If
    End Function

    Private Sub GrabarEntidadRapida2()
        Dim obEntidad As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            obEntidad.idEmpresa = Gempresas.IdEmpresaRuc
            obEntidad.idOrganizacion = GEstableciento.IdEstablecimiento
            obEntidad.tipoEntidad = "CL"
            obEntidad.tipoDoc = SelRazon.tipoDoc
            obEntidad.tipoPersona = SelRazon.tipoPersona
            obEntidad.nrodoc = SelRazon.nrodoc
            obEntidad.nombreCompleto = textPersona.Text.Trim
            obEntidad.cuentaAsiento = "1213"
            obEntidad.direccion = SelRazon.direccion
            If SelRazon.direccion IsNot Nothing Then
                If SelRazon.direccion.Trim.Length > 0 Then
                    obEntidad.entidadAtributos = New List(Of entidadAtributos)
                    obEntidad.entidadAtributos.Add(New entidadAtributos With {
                                                   .Action = BaseBE.EntityAction.INSERT,
                                                   .tipo = "DOMICILIO",
                                                   .tipoVia = SelRazon.TipoVia,
                                                   .Via = SelRazon.Via,
                                                   .ubigeo = SelRazon.Ubigeo,
                                                   .estado = 1,
                                                   .valorAtributo = SelRazon.direccion,
                                                   .usuarioModificacion = usuario.IDUsuario,
                                                   .fechaModificacion = Date.Now
                                                   })
                End If
            End If
            obEntidad.estado = StatusEntidad.Activo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            textPersona.Tag = codx
            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = txtruc.Text.Trim
            entidad.nombreCompleto = obEntidad.nombreCompleto
            entidad.tipoDoc = obEntidad.tipoDoc
            Me.Tag = entidad
            'If RadioButton2.Checked = True Then
            '    textPersona.Focus()
            '    textPersona.Select()
            'ElseIf RadioButton1.Checked = True Then
            '    txtruc.Focus()
            '    txtruc.Select()
            'End If
            'Transporte.ListaEmpresas.Add(entidad)

            '    Dispose()
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
    End Sub

    Private Async Sub GetConsultaSunatAsync2(ruc As String)
        SelRazon = New entidad
        Dim nroDoc = ruc.Substring(0, 1).ToString
        If nroDoc = "1" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                ' If company.ContribuyenteTipo = "PERSONA NATURAL SIN NEGOCIO" Then
                SelRazon.tipoPersona = "N"
                SelRazon.tipoDoc = "6"
                ' End If
                SelRazon.tipoEntidad = "CL"
                SelRazon.nombreCompleto = company.RazonSocial
                textPersona.Text = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.nrodoc = company.Ruc
                SelRazon.direccion = company.DomicilioFiscal
                GrabarEntidadRapida()
                PictureLoad.Visible = False
            Else
                textPersona.Clear()
                PictureLoad.Visible = False
            End If
        ElseIf nroDoc = "2" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                SelRazon.tipoPersona = "J"
                SelRazon.tipoDoc = "6"
                SelRazon.tipoEntidad = "CL"
                '  End If
                SelRazon.nombreCompleto = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                textPersona.Text = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.direccion = company.DomicilioFiscal
                SelRazon.nrodoc = company.Ruc
                'If company.RepresentanteLegal IsNot Nothing Then
                '    If company.RepresentanteLegal.Dni41094462 IsNot Nothing Then
                '        With company.RepresentanteLegal.Dni41094462
                '            txtContacto.Text = String.Format("{0}/{1}/{2}", .Cargo, .Nombre, .Desde)
                '        End With
                '    End If
                'End If
                GrabarEntidadRapida()
                PictureLoad.Visible = False
            Else
                textPersona.Clear()
                PictureLoad.Visible = False
            End If
        End If
        txtruc.ReadOnly = False
    End Sub

    Private Async Sub GetApiSunat2(ByVal nroruc As String)
        SelRazon = New entidad()

        Using client = New HttpClient()

            If nroruc.ToString().Trim().Substring(0, 1) = "1" Then
                SelRazon.tipoPersona = "N"
            ElseIf nroruc.ToString().Trim().Substring(0, 1) = "2" Then
                SelRazon.tipoPersona = "J"
            End If

            'client.BaseAddress = New Uri("https://api.peruonline.cloud/v1/?ruc=10449245691")
            Dim responseTask = Await client.GetAsync("https://api.peruonline.cloud/v1/?ruc=" & nroruc)
            ' responseTask.Wait()
            'Dim result = responseTask.Result

            If responseTask.IsSuccessStatusCode Then
                Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente)()
                readTask.Wait()
                Dim students = readTask.Result
                SelRazon.tipoDoc = "6"
                SelRazon.tipoEntidad = "CL"
                SelRazon.nombreCompleto = students.NombreORazonSocial
                SelRazon.nombreContacto = students.NombreORazonSocial
                textPersona.Text = students.NombreORazonSocial
                'TextNumIdentrazon.Text = txtBuscador.Text
                SelRazon.estado = students.EstadoDelContribuyente
                SelRazon.nrodoc = students.Ruc
                SelRazon.direccion = students.Direccion

                SelRazon.TipoVia = students.TipoDeVia
                SelRazon.Via = students.NombreDeVia
                SelRazon.Ubigeo = students.Ubigeo

                GrabarEntidadRapida()
                PictureLoad.Visible = False
            Else
                GetConsultaSunatAsync(nroruc)

                'TextProveedor.Clear()
                'PictureLoad.Visible = False
            End If
            txtruc.ReadOnly = False
        End Using
    End Sub

    Private Sub GrabarEnFormBasico2()
        Dim f As New frmCrearENtidades
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim ent = CType(f.Tag, entidad)
            txtruc.Text = ent.nrodoc
            textPersona.Text = ent.nombreCompleto
            textPersona.Tag = ent.idEntidad
            textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        Else
            txtruc.Text = String.Empty
            textPersona.Text = String.Empty
            textPersona.Tag = Nothing
        End If
    End Sub

#End Region

    Private Sub GetRutasPorDia()
        Dim status As String = String.Empty
        Dim rutaSA As New RutaProgramacionSalidasSA
        'ListProgamacion.Items.Clear()

        Dim lista = rutaSA.GetProgramacionPorFechaLaboral(New rutaProgramacionSalidas With
                                                          {
                                                          .fechaProgramacion = Date.Now ' TextFechaProgramada.Value
                                                          })


        For Each i In lista
            Select Case i.estado
                Case ProgramacionEstado.VehiculoAsignadoEnCurso
                    status = "En Curso"
                Case ProgramacionEstado.VehiculoAsignadoRutaCulminada
                    status = "Culminada"
                Case ProgramacionEstado.VentaCerrada
                    status = "Venta cerrada"
                Case ProgramacionEstado.VentaEnMostrador
                    status = "En mostrador"
                Case ProgramacionEstado.ZonaEmbarque
                    status = "Embarque"
            End Select

            Dim n As New ListViewItem(i.programacion_id)
            n.SubItems.Add(If(i.tipo = "I", "SALIDA", "VUELTA"))
            n.SubItems.Add(i.fechaProgramacion)
            n.SubItems.Add(i.fechaProgramacion.Value.ToShortTimeString)
            n.SubItems.Add(i.CustomRutas.CustomRuta_horarios.horario_id)
            n.SubItems.Add(i.ruta_id)
            n.SubItems.Add(i.CustomRutas.ciudadDestino)
            n.SubItems.Add(status)
            'ListProgamacion.Items.Add(n)
        Next
        'ListProgamacion.Refresh()

    End Sub

    Public Sub GetDocsVenta()

        Try
            If IsNumeric(LabelRuta.Tag) Then
                'Dim ListaRutas As New List(Of Integer)
                'ListaRutas.Add(3)
                'ListaRutas.Add(5)
                'ListaRutas.Add(6)
                'ListaRutas.Add(7)
                'ListaRutas.Add(8)
                'ListaRutas.Add(1017)
                'ListaRutas.Add(1010)
                'ListaRutas.Add(15)

                Dim IdCentro As Integer = 0
                Dim lista = ListaAgencias.Where(Function(o) o.TipoEstab = "UN" And o.ubigeo <> ubigeoOrigen).ToList

                ''solo pichanaqui
                'Dim lista = ListaAgencias.Where(Function(o) o.TipoEstab = "UN" And Not ListaRutas.Contains(o.idCentroCosto)).ToList

                Dim IDPADRE As New centrocosto
                cboDestino.DataSource = lista
                cboDestino.DisplayMember = "nombre"
                cboDestino.ValueMember = "idCentroCosto"


                IDPADRE = LISTAESTABLECIMIENTO.Where(Function(O) O.TipoEstab = "UN" And O.ubigeo = ubigeoDestino).FirstOrDefault
                txtUbigeo.Text = LISTAESTABLECIMIENTO.Where(Function(O) O.TipoEstab = "SE" And O.idCentroCosto = IDPADRE.idpadre).FirstOrDefault.nombre
                txtUbigeo.Tag = IDPADRE.ubigeo
                IdCentro = CInt(lista.Where(Function(o) o.TipoEstab = "UN" And o.idCentroCosto = IDPADRE.idCentroCosto).FirstOrDefault.idCentroCosto)
                cboDestino.SelectedValue = IdCentro
                txtOrigen.Text = LISTAESTABLECIMIENTO.Where(Function(o) o.TipoEstab = "UN" And o.ubigeo = ubigeoOrigen).FirstOrDefault.nombre

                cboTipoDoc.Items.Clear()
                'cboTipoDoc.Items.Add("NOTA DE VENTA")
                'cboTipoDoc.Items.Add("BOLETA")
                'cboTipoDoc.Items.Add("FACTURA")
                cboTipoDoc.Items.Add("BOLETA ELECTRONICA")
                cboTipoDoc.Items.Add("FACTURA ELECTRONICA")

                cboTipoDoc.Text = "BOLETA ELECTRONICA"


            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Public Sub GetRutasActivas()
        'Dim rutaSA As New RutaTareoAutoSA
        'Dim rutaSA As New RutasSA
        Dim rutaSA As New RutaProgramacionSalidasSA

        'ListaRutasActivas = rutaSA.GellAllRutas(New rutas With {.estado = 1})
        ListaRutasActivas = rutaSA.ProgramacionSelRutasActivas(New rutaProgramacionSalidas With {.estado = 1})
        'ComboRutasActivas.DataSource = ListaRutasActivas
        'ComboRutasActivas.DisplayMember = "GetNameLarge"
        'ComboRutasActivas.ValueMember = "ruta_id"
    End Sub

    Private Sub RBNatural_CheckedChanged(sender As Object, e As EventArgs) Handles RBNatural.CheckedChanged
        If RBNatural.Checked = True Then
            GroupBoxPasajero.Enabled = True
            GroupBoxEmpresa.Enabled = False
            cboTipoDoc.Text = "BOLETA ELECTRONICA"
        End If
    End Sub

    Private Sub RBJuridico_CheckedChanged(sender As Object, e As EventArgs) Handles RBJuridico.CheckedChanged
        If RBJuridico.Checked = True Then
            GroupBoxPasajero.Enabled = True
            GroupBoxEmpresa.Enabled = True
            cboTipoDoc.Text = "FACTURA ELECTRONICA"
        End If
    End Sub

    Private Sub TextNumIdentrazon_KeyDown(sender As Object, e As KeyEventArgs) Handles TextNumIdentrazon.KeyDown
        Dim nombres = String.Empty
        Try
            'TextNumIdentrazon.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case TextNumIdentrazon.Text.Trim.Length
                    Case 8 'dni

                        'SelRazon = New entidad

                        'If My.Computer.Network.IsAvailable = True Then
                        '    PictureLoad.Visible = True
                        '    nombres = GetConsultarDNIReniec(TextNumIdentrazon.Text.Trim)

                        '    If nombres.Trim.Length > 0 Then

                        '        If nombres = "DNI no encontrado en Padrón Electoral" Then
                        '            TextNumIdentrazon.Clear()
                        '            TextEmpresaPasajero.Text = String.Empty
                        '            TextEmpresaPasajero.Tag = Nothing
                        '            PictureLoad.Visible = False
                        '            Exit Sub
                        '        End If

                        '        SelRazon.tipoEntidad = "CL"
                        '        SelRazon.nombreCompleto = nombres
                        '        SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                        '        SelRazon.tipoDoc = "1"
                        '        SelRazon.tipoPersona = "N"
                        '        TextEmpresaPasajero.Text = nombres

                        '        Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)

                        '        If existeEnDB Is Nothing Then
                        '            TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        '            GrabarEntidadRapida()
                        '            PictureLoad.Visible = False
                        '        Else
                        '            TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        '            TextEmpresaPasajero.Tag = existeEnDB.idEntidad
                        '            'If RadioButton2.Checked = True Then
                        '            'TextFiltrar.Focus()
                        '            'TextFiltrar.Select()
                        '            'ElseIf RadioButton1.Checked = True Then
                        '            '    txtruc.Focus()
                        '            '    txtruc.Select()
                        '            'End If
                        '        End If
                        '    Else
                        '        TextNumIdentrazon.Clear()
                        '        TextEmpresaPasajero.Text = String.Empty
                        '        TextEmpresaPasajero.Tag = Nothing
                        '    End If
                        '    PictureLoad.Visible = False
                        'Else

                        '    'CUANDO NO HAY CONEXION A INTERNET
                        '    Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)
                        '    If existeEnDB Is Nothing Then
                        '        SelRazon.tipoEntidad = "CL"
                        '        SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                        '        SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                        '        SelRazon.tipoDoc = "1"
                        '        SelRazon.tipoPersona = "N"
                        '        'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        '        'GrabarEntidadRapida()
                        '        GrabarEnFormBasico()
                        '        PictureLoad.Visible = False
                        '    Else
                        '        TextEmpresaPasajero.Text = existeEnDB.nombreCompleto
                        '        TextEmpresaPasajero.Tag = existeEnDB.idEntidad
                        '        TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        '        'If RadioButton2.Checked = True Then
                        '        'TextFiltrar.Focus()
                        '        'TextFiltrar.Select()
                        '        'ElseIf RadioButton1.Checked = True Then
                        '        '    txtruc.Focus()
                        '        '    txtruc.Select()
                        '        'End If
                        '    End If
                        'End If

                    Case 11 'razonSocial
                        PictureLoad.Visible = True
                        Dim objeto As Boolean = ValidationRUC(TextNumIdentrazon.Text.Trim)
                        If objeto = False Then
                            PictureLoad.Visible = False
                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            TextEmpresaPasajero.Clear()
                            Exit Sub
                        End If

                        If EstadoRed("138.128.171.106") = True Then
                            'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                            If GetValidarLocalDB(TextNumIdentrazon.Text.Trim) = False Then
                                TextNumIdentrazon.ReadOnly = True

                                GetApiSunat(TextNumIdentrazon.Text.Trim)

                            End If
                        Else
                            'SI NO HAY CONEXION A INTERNET
                            If GetValidarLocalDB(TextNumIdentrazon.Text.Trim) = False Then
                                Dim nroDoc = TextNumIdentrazon.Text.Trim.Substring(0, 1).ToString
                                If nroDoc = "1" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "N"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico()
                                    PictureLoad.Visible = False
                                    If TextEmpresaPasajero.Text.Trim.Length > 0 Then
                                        'TextFiltrar.Select()
                                        'TextFiltrar.Focus()
                                    Else
                                        TextNumIdentrazon.Clear()
                                        TextNumIdentrazon.Select()
                                    End If
                                ElseIf nroDoc = "2" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "J"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico()
                                    PictureLoad.Visible = False
                                    If TextEmpresaPasajero.Text.Trim.Length > 0 Then
                                        'TextFiltrar.Select()
                                        'TextFiltrar.Focus()
                                    Else
                                        TextNumIdentrazon.Clear()
                                        TextNumIdentrazon.Select()
                                    End If
                                End If
                            End If
                        End If

                        txtruc.Select()
                        txtruc.Focus()

                    Case Else
                        TextEmpresaPasajero.Text = String.Empty
                        TextNumIdentrazon.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select

            End If
            '    TextNumIdentrazon.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then
                PictureLoad.Visible = False
                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
                TextNumIdentrazon.Focus()
                TextEmpresaPasajero.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Public Function VerificarConexionURL(ByVal mURL As String) As Boolean
    '    Dim Peticion As System.Net.WebRequest
    '    Dim Respuesta As System.Net.WebResponse
    '    Try
    '        Peticion = System.Net.WebRequest.Create(mURL)
    '        Respuesta = Peticion.GetResponse()
    '        Return True
    '    Catch ex As System.Net.WebException
    '        If ex.Status = Net.WebExceptionStatus.NameResolutionFailure Then
    '            Return False
    '        End If
    '        Return False
    '    End Try
    'End Function

    Public Function EstadoRed(ByVal mURL As String) As Boolean

        Try
            Dim conteo As Integer = 0
            Dim ip As IPAddress = IPAddress.Parse(mURL)
            If My.Computer.Network.IsAvailable() Then
                'If ip = True Then 'Asignamos la pagina a consultar ejemplo www.google.cl y el tiempo de espera máximo

                Dim ping As Ping = New Ping()

                For i As Integer = 0 To 2 - 1
                    Dim pr As PingReply = ping.Send(ip)

                    If (pr.Status.ToString() = "Success") Then
                        conteo = conteo + 1

                    End If
                Next
                If (conteo = 0) Then
                    EstadoRed = False
                ElseIf (conteo >= 1) Then
                    EstadoRed = True
                End If
                'Else
                '    EstadoRed = False
                'End If
            Else
                EstadoRed = False
            End If

        Catch ex As Exception
            EstadoRed = False
        End Try

    End Function

    Private Sub Txtruc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtruc.KeyDown

        Dim nombres = String.Empty
        Try
            'TextNumIdentrazon.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case txtruc.Text.Trim.Length
                    Case 8 'dni

                        SelRazon = New entidad

                        If EstadoRed("138.128.171.106") = True Then
                            PictureLoad.Visible = True
                            'nombres = GetConsultarDNIReniec(txtruc.Text.Trim)
                            'nombres = GetConsultarDNIReniecVER2(txtruc.Text.Trim)
                            nombres = GetConsultarDNIReniecAPIS(txtruc.Text.Trim)
                            If nombres.Trim.Length > 0 Then

                                If nombres = "DNI no encontrado en Padrón Electoral" Then
                                    txtruc.Clear()
                                    textPersona.Text = String.Empty
                                    textPersona.Tag = Nothing
                                    PictureLoad.Visible = False
                                    Exit Sub
                                End If

                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = nombres
                                SelRazon.nrodoc = txtruc.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                textPersona.Text = nombres

                                Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtruc.Text.Trim)

                                If existeEnDB Is Nothing Then
                                    textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    GrabarEntidadRapida2()
                                    PictureLoad.Visible = False
                                Else
                                    textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    textPersona.Tag = existeEnDB.idEntidad
                                    'If RadioButton2.Checked = True Then
                                    'TextFiltrar.Focus()
                                    'TextFiltrar.Select()
                                    'ElseIf RadioButton1.Checked = True Then
                                    '    txtruc.Focus()
                                    '    txtruc.Select()
                                    'End If
                                End If
                            Else
                                txtruc.Clear()
                                textPersona.Text = String.Empty
                                textPersona.Tag = Nothing
                            End If
                            PictureLoad.Visible = False
                        Else

                            'CUANDO NO HAY CONEXION A INTERNET
                            Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtruc.Text.Trim)
                            If existeEnDB Is Nothing Then
                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = textPersona.Text.Trim
                                SelRazon.nrodoc = txtruc.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'GrabarEntidadRapida()
                                GrabarEnFormBasico2()
                                PictureLoad.Visible = False
                            Else
                                textPersona.Text = existeEnDB.nombreCompleto
                                textPersona.Tag = existeEnDB.idEntidad
                                textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'If RadioButton2.Checked = True Then
                                'TextFiltrar.Focus()
                                'TextFiltrar.Select()
                                'ElseIf RadioButton1.Checked = True Then
                                '    txtruc.Focus()
                                '    txtruc.Select()
                                'End If
                            End If
                        End If

                        e.SuppressKeyPress = True

                        If (txtEdad.Text.Length > 0) Then
                            If (cboSexo.Text = "GENERO") Then
                                cboSexo.Select()
                                cboSexo.Focus()
                                cboSexo.DroppedDown = True
                            Else
                                BtConfirmarVenta.Select()
                                BtConfirmarVenta.Focus()
                            End If
                        Else
                            txtEdad.Select()
                            txtEdad.Focus()
                        End If

                    Case 11 'razonSocial
                        PictureLoad.Visible = True
                        Dim objeto As Boolean = ValidationRUC(txtruc.Text.Trim)
                        If objeto = False Then
                            PictureLoad.Visible = False
                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            textPersona.Clear()
                            Exit Sub
                        End If

                        If EstadoRed("138.128.171.106") = True Then
                            'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                            If GetValidarLocalDB2(txtruc.Text.Trim) = False Then
                                txtruc.ReadOnly = True

                                GetApiSunat2(txtruc.Text.Trim)

                            End If
                        Else
                            'SI NO HAY CONEXION A INTERNET
                            If GetValidarLocalDB2(txtruc.Text.Trim) = False Then
                                Dim nroDoc = txtruc.Text.Trim.Substring(0, 1).ToString
                                If nroDoc = "1" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "N"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico2()
                                    PictureLoad.Visible = False
                                    If textPersona.Text.Trim.Length > 0 Then
                                        'TextFiltrar.Select()
                                        'TextFiltrar.Focus()
                                    Else
                                        txtruc.Clear()
                                        txtruc.Select()
                                    End If
                                ElseIf nroDoc = "2" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "J"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico2()
                                    PictureLoad.Visible = False
                                    If textPersona.Text.Trim.Length > 0 Then
                                        'TextFiltrar.Select()
                                        'TextFiltrar.Focus()
                                    Else
                                        txtruc.Clear()
                                        txtruc.Select()
                                    End If
                                End If
                            End If
                        End If

                    Case Else
                        textPersona.Text = String.Empty
                        txtruc.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select

                e.SuppressKeyPress = True

                If (txtEdad.Text.Length > 0) Then
                    If (cboSexo.Text = "GENERO") Then
                        cboSexo.Select()
                        cboSexo.Focus()
                        cboSexo.DroppedDown = True
                    Else
                        BtConfirmarVenta.Select()
                        BtConfirmarVenta.Focus()
                    End If
                Else
                    txtEdad.Select()
                    txtEdad.Focus()
                End If
            End If
            '    TextNumIdentrazon.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then
                PictureLoad.Visible = False
                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
                TextNumIdentrazon.Focus()
                textPersona.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'Try
        '    'If ListProgamacion.SelectedItems.Count > 0 Then
        '    If MessageBox.Show("Desea enviar programación a zona de embarque?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '        GetCerrarVentas(Integer.Parse(LabelfechaProg.Tag), ProgramacionEstado.ZonaEmbarque)
        '    End If
        '    'End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        Try
            FormPurchase.WindowState = FormWindowState.Minimized
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Try
            'If MessageBox.Show("¿Desea salir de la venta?", "Salir de la venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

            '    'Dim documentoventaSA As New VehiculoAsiento_PreciosSA
            '    'Dim documentoventaBE As New vehiculoAsiento_Precios

            '    'Dim distribucionInfraturaBE = New vehiculoAsiento_Precios

            '    'If (Not IsNothing(LabelAsientoSel.Tag)) Then
            '    '    distribucionInfraturaBE.idEmpresa = Gempresas.IdEmpresaRuc
            '    '    distribucionInfraturaBE.precio_id = LabelAsientoSel.Tag
            '    '    distribucionInfraturaBE.estado = "A"

            '    '    documentoventaSA.updateAsientoTransportexID(distribucionInfraturaBE)
            '    'End If
            LimpiarCajasTransporte()
            FormPurchase.TabTR_PasajeVenta.Visible = False

            If FormPurchase.TabTR_IdentificacionRuta IsNot Nothing Then
                FormPurchase.TabTR_IdentificacionRuta.GetDocumentoVentaID()
                FormPurchase.TabTR_IdentificacionRuta.Visible = True
                FormPurchase.TabTR_IdentificacionRuta.BringToFront()
                FormPurchase.TabTR_IdentificacionRuta.Show()
            End If
            'End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtConfirmarVenta_Click(sender As Object, e As EventArgs) Handles BtConfirmarVenta.Click


        Try
            If IsDate(LabelfechaProg.Text) Then
                If CInt(LabelAsientoSel.Text) > 0 Then
                    If textPersona.Text.Trim.Length > 0 Then

                        If RBJuridico.Checked = True Then
                            If TextEmpresaPasajero.ForeColor <> Color.FromKnownColor(KnownColor.HotTrack) Then
                                MessageBox.Show("Ingrese una empresa valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                TextEmpresaPasajero.Select()
                                TextEmpresaPasajero.Focus()
                                Exit Sub
                            End If
                        End If

                        If txtEdad.Text.Length = 0 Then
                            MessageBox.Show("Ingrese una edad valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtEdad.Select()
                            txtEdad.Focus()
                            Exit Sub
                        End If

                        If cboSexo.Text = "GENERO" Then
                            MessageBox.Show("Ingrese un sexo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtEdad.Select()
                            txtEdad.Focus()
                            Exit Sub
                        End If


                        If lblPrecioTotal.Value <= 0 Then
                            MessageBox.Show("Ingrese un precio mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            lblPrecioTotal.Select()
                            lblPrecioTotal.Focus()
                            lblPrecioTotal.Select(0, lblPrecioTotal.Text.Length)
                            Exit Sub
                        End If


                        'If TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                        If textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then

                            Dim id_ruta = LabelRuta.Tag  ' Integer.Parse(ListProgamacion.SelectedItems(0).SubItems(5).Text)

                            Dim envio = GetMappingEnvio(id_ruta)
                            Dim f As New FormCrearVentaTransporteDirecto(envio, envio.tipoPersona, Nothing, txtDescripcion.Tag)
                            f.LabelfechaProg.Text = CDate(fechaEnvio)
                            f.LabelfechaProg.Tag = (LabelfechaProg.Tag)
                            f.txtHora.Value = dtpHoraProgramada.Value  'lblHora.Text
                            f.cboTipoDoc.Text = cboTipoDoc.Text
                            'f.TextFechaProgramada.Enabled = False
                            f.distribucionID = LabelAsientoSel.Tag
                            f.manifiesto = manifiesto
                            f.nroPlaca = txtNombreBus.Text
                            'f.hora = lblHora.Text
                            f.txtHora.Value = dtpHoraProgramada.Value
                            f.textEdad.Text = txtEdad.Text
                            f.LabelAsientoSel.Tag = LabelAsientoSel.Tag

                            f.TextCiudadDestino.Text = cboDestino.Text
                            f.TextCiudadDestino.Tag = txtUbigeo.Text
                            f.TextDestinoUbigeo.Text = txtUbigeo.Tag
                            f.TextDestinoUbigeo.Tag = txtUbigeo.Tag


                            f.TextCiudadOrigen.Text = txtOrigen.Text
                            f.TextCiudadOrigen.Tag = ubigeoOrigen
                            f.TextOrigenUbigeo.Text = ubigeoOrigen
                            f.TextOrigenUbigeo.Text = ubigeoOrigen


                            f.sexo = cboSexo.Text
                            'f.txtTotalBase2.Text = lblPrecioTotal.Value
                            f.tipoManipulacion = tipoManipulacion
                            f.idDocReferecia = idDocReferecia

                            f.descripcion = txtDescripcion.Text
                            f.GetMappingVariables()
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog(Me)

                            If f.Tag IsNot Nothing Then
                                If (f.Tag = 1) Then
                                    LimpiarCajasTransporte()
                                    LLAMARiNFRAESTRUCTURA(txtNombreBus.Tag, programacion_ID)
                                End If
                            End If
                        ElseIf (txtruc.Text = VarClienteGeneral.idEntidad) Then
                            Dim id_ruta = LabelRuta.Tag  ' Integer.Parse(ListProgamacion.SelectedItems(0).SubItems(5).Text)

                            Dim envio = GetMappingEnvio(id_ruta)
                            Dim f As New FormCrearVentaTransporteDirecto(envio, envio.tipoPersona, Nothing, txtDescripcion.Tag)
                            f.LabelfechaProg.Text = CDate(fechaEnvio)
                            f.LabelfechaProg.Tag = (LabelfechaProg.Tag)

                            f.cboTipoDoc.Text = cboTipoDoc.Text
                            f.distribucionID = LabelAsientoSel.Tag
                            f.manifiesto = manifiesto
                            f.txtHora.Value = dtpHoraProgramada.Value
                            f.nroPlaca = txtNombreBus.Text

                            f.textEdad.Text = txtEdad.Text
                            f.LabelAsientoSel.Tag = LabelAsientoSel.Tag





                            f.TextCiudadDestino.Text = cboDestino.Text
                            f.TextCiudadDestino.Tag = txtUbigeo.Text
                            f.TextDestinoUbigeo.Text = txtUbigeo.Tag
                            f.TextDestinoUbigeo.Tag = txtUbigeo.Tag


                            f.TextCiudadOrigen.Text = txtOrigen.Text
                            f.TextCiudadOrigen.Tag = ubigeoOrigen
                            f.TextOrigenUbigeo.Text = ubigeoOrigen
                            f.TextOrigenUbigeo.Text = ubigeoOrigen



                            f.tipoManipulacion = tipoManipulacion
                            f.idDocReferecia = idDocReferecia

                            f.descripcion = txtDescripcion.Text
                            'f.txtTotalBase2.Text = lblPrecioTotal.Value
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog(Me)

                            If f.Tag IsNot Nothing Then
                                If (f.Tag = 1) Then
                                    LimpiarCajasTransporte()
                                    LLAMARiNFRAESTRUCTURA(txtNombreBus.Tag, programacion_ID)
                                End If
                            End If
                        Else
                            MessageBox.Show("Ingrese un pasajero valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            textPersona.Select()
                            textPersona.Focus()
                        End If
                        'Else
                        '    MessageBox.Show("Ingreser una empresa valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '    TextEmpresaPasajero.Select()
                        '    TextEmpresaPasajero.Focus()
                        'End If
                    Else
                        MessageBox.Show("Ingrese un pasajero valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Debe indicar el asiento para seguir la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Indique una fecha programada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        GrabarEnFormBasicoV2()
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        Dim f As New FormComfPrecio
        f.pnBuscardor.Visible = True
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            lblPrecioTotal.Value = (f.Tag)
        End If
    End Sub

    Private Sub CboRutas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboDestino.SelectionChangeCommitted
        Try
            Dim IDPADRE As New centrocosto

            IDPADRE = LISTAESTABLECIMIENTO.Where(Function(O) O.TipoEstab = "UN" And O.idCentroCosto = cboDestino.SelectedValue).FirstOrDefault

            txtUbigeo.Text = LISTAESTABLECIMIENTO.Where(Function(O) O.TipoEstab = "SE" And O.idCentroCosto = IDPADRE.idpadre).FirstOrDefault.nombre
            txtUbigeo.Tag = IDPADRE.ubigeo
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LblPrecioTotal_Click(sender As Object, e As EventArgs) Handles lblPrecioTotal.Click
        lblPrecioTotal.Select(0, lblPrecioTotal.Text.Length)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Try


            Dim f As New FormViewResumenLiquidacion(Integer.Parse(programacion_ID), "pasajes")
            f.PLACA = txtNombreBus.Text
            f.DESTINO = cboDestino.Text
            f.ORIGEN = txtOrigen.Text
            f.TextSeriePlaca.Text = txtNombreBus.Text
            f.txtFecha.Text = LabelfechaProg.Text
            f.txtHora.Text = dtpHoraProgramada.Value.ToShortTimeString
            f.TextRuta.Text = txtOrigen.Text
            f.txtdestino.Text = cboDestino.Text
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If ListaCajasActivas IsNot Nothing Then
            If ListaCajasActivas.Count > 0 Then
                Dim f As New FormCrearEncomiendaV2()
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
            Else
                MessageBox.Show("No tiene configurada una caja", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("No tiene configurada una caja", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ChSinDNI_CheckedChanged(sender As Object, e As EventArgs) Handles chSinDNI.CheckedChanged
        If (chSinDNI.Checked = True) Then
            txtruc.Text = VarClienteGeneral.idEntidad
            textPersona.Text = VarClienteGeneral.nombreCompleto
            textPersona.Tag = VarClienteGeneral.idEntidad
            txtruc.Enabled = False
            textPersona.ReadOnly = False
            textPersona.Enabled = True
        ElseIf (chSinDNI.Checked = False) Then
            textPersona.Enabled = False
            txtruc.Enabled = True
            textPersona.Clear()
            txtruc.Clear()
        End If
    End Sub

    Private Sub TextPersona_Click(sender As Object, e As EventArgs) Handles textPersona.Click
        textPersona.Select(0, textPersona.Text.Length)
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Try

            Dim f As New FormConsolidarSalidaEmbarque(programacion_ID)
            f.RoundButton24.Visible = True
            'f.RoundButton23.Visible = False
            f.TextSeriePlaca.Tag = txtNombreBus.Tag
            f.TextSeriePlaca.Text = txtNombreBus.Text
            f.TextCodigoPlaca.Text = txtNombreBus.Text
            f.IDaCTIVO = txtNombreBus.Tag
            f.StartPosition = FormStartPosition.CenterParent
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim f As New frmCrearENtidades
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim ent = CType(f.Tag, entidad)
            TextNumIdentrazon.Text = ent.nrodoc
            TextEmpresaPasajero.Text = ent.nombreCompleto
            TextEmpresaPasajero.Tag = ent.idEntidad
            TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        Else
            TextNumIdentrazon.Text = String.Empty
            TextEmpresaPasajero.Text = String.Empty
            TextEmpresaPasajero.Tag = Nothing
        End If
    End Sub

    Private Sub LblPrecioTotal_KeyDown(sender As Object, e As KeyEventArgs) Handles lblPrecioTotal.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True

                txtruc.Select()
                txtruc.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            lblPrecioTotal.Value = 0.0
        End Try
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Try
            Dim comprobanteTransporte As New documentoventaTransporte
            Dim ventaSA As New DocumentoventaTransporteSA
            Dim comprobanteEntidad As New entidad

            Dim f As New formReimpresion
            f.pnBuscardor.Visible = True
            f.lblPrecioTotal.Select()
            f.lblPrecioTotal.Focus()
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            If f.Tag IsNot Nothing Then

                comprobanteTransporte = ventaSA.DocumentoTransporteSelIDVehiculoXProg(New documentoventaTransporte With
                                                                   {
                                                                   .idDistribucion = CInt(f.Tag),
                                                                   .programacion_id = programacion_ID
                                                                   })



                If ((comprobanteTransporte.idDocumento <> 0)) Then
                    If (comprobanteTransporte.estado <> 6) Then
                        comprobanteEntidad = entidadSA.UbicarEntidadPorID(comprobanteTransporte.razonSocial).FirstOrDefault

                        'programacion_ID

                        'ImprimirTicketA4v2("TICKET/RUTA", 0, comprobanteTransporte, comprobanteEntidad)

                        FormImpresionNuevo = New FormImpresionEquivalencia()
                        'FormImpresionNuevo.tienda = UCEstructuraCabeceraVentaV2.txtInfraestructura.Text
                        FormImpresionNuevo.FormaPago = ""
                        FormImpresionNuevo.DocumentoID = comprobanteTransporte.idDocumento
                        FormImpresionNuevo.Email = ""
                        FormImpresionNuevo.FormaPago = "TR"
                        FormImpresionNuevo.LLAMARENTIDAD = comprobanteEntidad
                        FormImpresionNuevo.LLAMARTRANSPORTE = comprobanteTransporte
                        FormImpresionNuevo.StartPosition = FormStartPosition.CenterScreen
                        FormImpresionNuevo.ShowDialog(Me)
                    Else
                        MessageBox.Show("ASIENTO EN RESERVA")
                    End If
                Else
                    MessageBox.Show("NO EXISTE ASIENTO")
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TxtEdad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEdad.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                cboSexo.Select()
                cboSexo.Focus()
                cboSexo.DroppedDown = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            lblPrecioTotal.Value = 0.0
        End Try
    End Sub

    Private Sub CboRutas_KeyDown(sender As Object, e As KeyEventArgs) Handles cboDestino.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                lblPrecioTotal.Select()
                lblPrecioTotal.Focus()
                lblPrecioTotal.Select(0, lblPrecioTotal.Text.Length)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            lblPrecioTotal.Value = 0.0
        End Try
    End Sub

    Private Sub CboSexo_KeyDown(sender As Object, e As KeyEventArgs) Handles cboSexo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                BtConfirmarVenta.Select()
                BtConfirmarVenta.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            lblPrecioTotal.Value = 0.0
        End Try
    End Sub

    Private Sub PnPrincipal_Paint(sender As Object, e As PaintEventArgs) Handles pnPrincipal.Paint

    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Try
            Dim f As New FormAnularPasaje()
            f.IdProg = programacion_ID
            f.pnBuscardor.Visible = True
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            LLAMARiNFRAESTRUCTURA(txtNombreBus.Tag, programacion_ID)
            LimpiarCajasTransporte()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Try
            Dim f As New FormConfigurarReservas()
            'f.programacion_ID = programacion_ID
            'f.placaBus = txtNombreBus.Tag
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            LLAMARiNFRAESTRUCTURA(txtNombreBus.Tag, programacion_ID)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If (CheckBox1.Checked = True) Then
            btnReserva.Visible = True
            BtConfirmarVenta.Visible = False
        ElseIf (CheckBox1.Checked = False) Then

            btnReserva.Visible = False
            BtConfirmarVenta.Visible = True
        End If
    End Sub

    Private Sub BtnReserva_Click(sender As Object, e As EventArgs) Handles btnReserva.Click
        Dim cajaUsuaroSA As New cajaUsuarioSA
        Dim entidadSA As New EstadosFinancierosSA
        Dim envio As EnvioImpresionVendedorPernos = Nothing
        Try
            'cargarCajas()

            Select Case cboTipoDoc.Text
                Case "FACTURA", "FACTURA ELECTRONICA"
                    Dim objeto As Boolean = ValidationRUC(TextNumIdentrazon.Text.Trim)
                    If objeto = False Then
                        MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                Case "BOLETA ELECTRONICA", "BOLETA"
                    Dim rsp = validarDNI(txtruc.Text.Trim)
                    If rsp = False Then
                        MessageBox.Show("Debe Ingresar un número correcto de DNI", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
            End Select


            Dim codigoVendedor = 11
            Dim usuarioSel = UsuariosList.Where(Function(o) o.codigo = codigoVendedor).FirstOrDefault

            If usuarioSel IsNot Nothing Then
                'Dim cajaUsuario = cajaUsuaroSA.UbicarCajaUsuarioPorID(ComboCaja.SelectedValue)

                ''   Dim ef = entidadSA.GetUbicar_estadosFinancierosPorID(cajaUsuario.idCajaOrigen)

                envio = New EnvioImpresionVendedorPernos With
                    {
                    .CodigoVendedor = 11,
                    .IDCaja = ListaCajasActivas.Where(Function(o) o.idPersona = usuarioSel.IDUsuario).FirstOrDefault.idcajaUsuario,' ComboCaja.SelectedValue,
                    .IDVendedor = usuarioSel.IDUsuario,
                    .print = True,
                    .Nombreprint = String.Empty,
                    .NombreCajero = Nothing,
                    .EntidadFinanciera = 0,'ef.idestado,
                    .EntidadFinancieraName = String.Empty
                }

                If ValidarGrabado() = True Then
                    'objPleaseWait = New FeedbackForm()
                    'objPleaseWait.StartPosition = FormStartPosition.CenterScreen
                    'objPleaseWait.Show()
                    GrabarVentaPasaje(envio)
                End If

            Else
                MessageBox.Show("Ingrese un código valido", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'TextCodigoVendedor.Select()
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnEliminarReserva_Click(sender As Object, e As EventArgs) Handles btnEliminarReserva.Click
        Try
            Select Case tipoManipulacion
                Case "RESERVACION"
                    Dim distribucionInfraestructuraSA As New VehiculoAsiento_PreciosSA
                    Dim distribucionInfraestructuraBE As New vehiculoAsiento_Precios
                    Dim DOCUMENTOVENTASA As New DocumentoventaTransporteSA
                    Dim documentoVehiculoSA As New VehiculoAsiento_PreciosSA
                    If (idDocReferecia > 0) Then
                        DOCUMENTOVENTASA.DocumentoTransporteReservacionEliminar(idDocReferecia)

                        idDocReferecia = 0

                        distribucionInfraestructuraBE = New vehiculoAsiento_Precios
                        distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                        distribucionInfraestructuraBE.precio_id = LabelAsientoSel.Tag
                        distribucionInfraestructuraBE.estado = "A"

                        documentoVehiculoSA.updateAsientoTransportexID(distribucionInfraestructuraBE)
                        LLAMARiNFRAESTRUCTURA(txtNombreBus.Tag, programacion_ID)
                        LimpiarCajasTransporte()
                        MessageBox.Show("Se elimino la reserva")
                    End If


            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Try
            LLAMARiNFRAESTRUCTURA(txtNombreBus.Tag, programacion_ID)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



#End Region

#Region "PRUEBA"

    Private Function GetConsultarDNIReniecAPIS(Dni As String) As String
        Dim strJSON As String = String.Empty
        Dim rClient As RESTClientAPI = New RESTClientAPI()
        Dim appat As String = String.Empty
        Dim apmat As String = String.Empty
        Dim nom As String = String.Empty
        Dim fullName As String = String.Empty
        Select Case ApiReniecOption
            Case ApisReniec.ApiReniecCloud
                rClient.endPoint = "https://api.reniec.cloud/dni/" & Dni
            Case ApisReniec.ApiGrupoTeComCom
                rClient.endPoint = "http://apis.grupotecom.com/api/ConsultaDni?dni=" & Dni
            Case ApisReniec.ApiConsultasDsdInformaticos
                rClient.endPoint = "http://consultas.dsdinformaticos.com/reniec.php?dni=" & Dni
        End Select

        strJSON = rClient.makeRequest()
        Dim res = JsonConvert.DeserializeObject(strJSON)

        Select Case ApiReniecOption
            Case ApisReniec.ApiReniecCloud
                appat = res("apellido_paterno").ToString() 'res.apellido_paterno
                apmat = res("apellido_materno").ToString() ' res.apellido_materno
                nom = res("nombres").ToString() 'res.nombres
                fullName = Trim($"{appat} {apmat} {nom}")
            Case ApisReniec.ApiGrupoTeComCom

                fullName = res("result")("NombreCompleto")
                fullName = Trim(fullName)
            Case ApisReniec.ApiConsultasDsdInformaticos
                appat = res("result")("ApellidoPaterno").ToString() 'res.apellido_paterno
                apmat = res("result")("ApellidoMaterno").ToString() ' res.apellido_materno
                nom = res("result")("Nombres").ToString() 'res.nombres
                fullName = Trim($"{appat} {apmat} {nom}")

                Dim SEXO As String = res("result")("Sexo").ToString()
                Dim FECHANACIMIENTO As String = res("result")("FechaNacimiento").ToString

                If (SEXO.Length > 0) Then
                    Select Case SEXO
                        Case "2"
                            cboSexo.Text = "M"
                        Case "3"
                            cboSexo.Text = "F"
                    End Select
                End If

                If (FECHANACIMIENTO.Length > 0) Then
                    Dim EDADPROMEDIO As String = CalcularEdad(CDate(FECHANACIMIENTO).Date.Day, CDate(FECHANACIMIENTO).Date.Month, CDate(FECHANACIMIENTO).Date.Year)
                    txtEdad.Text = EDADPROMEDIO
                End If


        End Select

        'Dim s = res("dni").ToString()




        '  nombres = MIHTML.Replace("|", Space(1))
        Return fullName
    End Function
    Private Function GetConsultarDNIReniecVER2(Dni As String) As String
        Try
            Using client = New HttpClient()

                Dim CLIENTE As New WebClient
                'Dim PAGINA As Stream = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" & Dni)
                Dim PAGINA As Stream = CLIENTE.OpenRead("http://consultas.dsdinformaticos.com/reniec.php?dni=" & Dni)
                Dim LECTOR As New StreamReader(PAGINA)
                Dim MIHTML As String = LECTOR.ReadToEnd
                Dim nombres = String.Empty
                ' Dim array = MIHTML.Split("|")
                Dim posicion = 0
                Dim doc As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument
                doc.LoadHtml(MIHTML)

                Dim readTask = doc.DocumentNode.InnerText.ToList

                'Dim obj As DNIContribuyente
                'obj = JsonConvert.DeserializeObject(Of DNIContribuyente)(doc.DocumentNode.InnerText)

                'MsgBox(obj.DNI)
                Dim json As JObject = JObject.Parse(doc.DocumentNode.InnerText)
                'MsgBox(json.SelectToken("result").SelectToken("Nombres"))

                Dim NOMBRECOMPLETO As String = json.SelectToken("result").SelectToken("Nombres")
                Dim APELLIDOPATERNO As String = json.SelectToken("result").SelectToken("ApellidoPaterno")
                Dim APELLIDOMATERNO As String = json.SelectToken("result").SelectToken("ApellidoMaterno")
                Dim FECHANACIMIENTO As String = json.SelectToken("result").SelectToken("FechaNacimiento")
                Dim SEXO As String = json.SelectToken("result").SelectToken("Sexo")

                Dim ENVIONOMBRECOMPLETO As String = NOMBRECOMPLETO & " " & APELLIDOPATERNO & " " & APELLIDOMATERNO

                If (SEXO.Length > 0) Then
                    Select Case SEXO
                        Case "2"
                            cboSexo.Text = "M"
                        Case "3"
                            cboSexo.Text = "F"
                    End Select
                End If

                If (FECHANACIMIENTO.Length > 0) Then
                    Dim EDADPROMEDIO As String = CalcularEdad(CDate(FECHANACIMIENTO).Date.Day, CDate(FECHANACIMIENTO).Date.Month, CDate(FECHANACIMIENTO).Date.Year)
                    txtEdad.Text = EDADPROMEDIO
                End If
                Return ENVIONOMBRECOMPLETO

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    'Function Edad(FechaNac As Date) As String
    '    Dim Años As Integer

    '    Años = Year(Date.Now) - Year(FechaNac)
    '    If Month(Date.Now) < Month(FechaNac) Then Años = Años - 1 'todavía no ha llegado el mes de su cumple
    '    If Month(Date.Now) = Month(FechaNac) And Day(Date.Now) < Date.Now.Day(FechaNac) Then Años = Años - 1 'es el mes pero no ha llegado el día de su cumple

    '    Edad = Años
    '    Return Edad
    'End Function

    Private Function CalcularEdad(ByVal DiaNacimiento As Integer, ByVal MesNacimiento As Integer, ByVal AñoNacimiento As Integer)
        ' SE DEFINEN LAS FECHAS ACTUALES
        Dim AñoActual As Integer = Year(Now)
        Dim MesActual As Integer = Month(Now)
        Dim DiaActual As Integer = Now.Day
        Dim Cumplidos As Boolean = False
        ' SE COMPRUEBA CUANDO FUE EL ULTIMOS CUMPLEAÑOS
        ' FORMULA:
        '   Años cumplidos = (Año del ultimo cumpleaños - Año de nacimiento)
        If (MesNacimiento <= MesActual) Then
            If (DiaNacimiento <= DiaActual) Then
                If (DiaNacimiento = DiaActual And MesNacimiento = MesActual) Then
                    MsgBox("Feliz Cumpleaños!")
                End If
                ' MsgBox("Ya cumplio")
                Cumplidos = True
            End If
        End If

        If (Cumplidos = False) Then
            AñoActual = (AñoActual - 1)
            'MsgBox("Ultimo cumpleaños: " & AñoActual)
        End If
        ' Se realiza la resta de años para definir los años cumplidos
        Dim EdadAños As Integer = (AñoActual - AñoNacimiento)
        '' DEFINICION DE LOS MESES LUEGO DEL ULTIMO CUMPLEAÑOS
        'Dim EdadMes As Integer
        'If Not (AñoActual = Now.Year) Then
        '    EdadMes = (12 - MesNacimiento)
        '    EdadMes = EdadMes + Now.Month
        'Else
        '    EdadMes = Math.Abs(Now.Month - MesNacimiento)
        'End If
        ''SACAMOS LA CANTIDAD DE DIAS EXACTOS
        'Dim EdadDia As Integer = (DiaActual - DiaNacimiento)

        'RETORNAMOS LOS VALORES EN UNA CADENA STRING
        Return EdadAños


    End Function

    Private Sub Txtruc_TextChanged(sender As Object, e As EventArgs) Handles txtruc.TextChanged

    End Sub

#End Region

End Class
