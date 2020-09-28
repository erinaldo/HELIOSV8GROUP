Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.General.Constantes
Imports OpenInvoicePeru.Comun.Dto.Intercambio
Imports OpenInvoicePeru.Comun.Dto.Modelos
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation

Public Class FormCrearVentaTransporteDirecto

#Region "Attributes"
    'Dim objPleaseWait As New FeedbackForm()
    Public Property ObjTareo As rutaTareoAutos
    Public Property tipopersonaSel As String
    Public Property formVentaPasajes As UC_VentaPasajes

    Public Property distribucionID As Integer

    Public Property manifiesto As String

    Dim entidadSA As New entidadSA

    Public objDatosGenrales As New datosGenerales

    Private FormImpresionNuevo As FormImpresionEquivalencia ' FormImpresionNuevo

    'Public Property hora As String
    'Public Property hora As DateTime

    Private Const FormatoFecha As String = "yyyy-MM-dd"

    Public Property Formatohora As String = "hh:mm:ss"

    Dim comprobanteTransporte As New documentoventaTransporte

    Dim comprobanteEntidad As New entidad

    Public Property sexo As String = String.Empty

    Dim listaCuentas As New List(Of estadosFinancierosConfiguracionPagos)

    Public Property tipoManipulacion As String = String.Empty

    Public Property idDocReferecia As Integer

    Dim instance As New Printing.PrinterSettings

    Dim impresosaPredt As String = instance.PrinterName

    Dim listaDatos As New List(Of datosGenerales)

    Public QR As String
    Public HASH As String

    Public destino As String
    Public descripcion As String
    Public Property nroPlaca As String
#End Region

#Region "Constructors"
    Public Sub New(envio As rutaTareoAutos, tipopersona As String, form As UC_VentaPasajes, tipoImpuesto As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        formVentaPasajes = form
        'FormatoGridAvanzado(dgvCuentas, False, False, 10.0F)
        tipopersonaSel = tipopersona
        ObjTareo = envio

        destino = tipoImpuesto

        GetMappingVariables()
        'cargarCajas()
        'GetUsuarioUnico()
        GetDocsVenta()
        GetMappingColumnsGridByUsuario()
        txtFecha.Value = Date.Now
        'TextFechaProgramada.Value = Date.Now
        CargarDatos()
    End Sub

#End Region

#Region "Methods"


    Public Sub EnviarFacturaElectronica(idDocumento As Integer, idPSE As Integer)

        ' Dim documentoSA As New documentoVentaAbarrotesSA
        ' Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        ' Dim entidadSA As New entidadSA
        Dim DetalleFactura As Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle

        Dim documneotventaTransporte As New documentoventaTransporte
        Dim item As New documentoventaTransporte
        item.idDocumento = idDocumento
        Dim DocumentoventaTransporteSA As New DocumentoventaTransporteSA

        Try

            documneotventaTransporte = comprobanteTransporte ' DocumentoventaTransporteSA.DocumentoTransporteSelIDVer2(item)

            ' Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(idDocumento)
            ' Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(idDocumento)
            'Dim receptor = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, documneotventaTransporte.razonSocial)
            Dim numerovent As String = String.Format("{0:00000000}", documneotventaTransporte.numero)
            Dim tipoDoc = String.Format("{0:00}", documneotventaTransporte.tipoDocumento)
            Dim conteo As Integer = 0

            '//Enviando el documento

            Dim Factura As New Fact.Sunat.Business.Entity.DocumentoElectronico

            'Datos del Cliente 
            Factura.Action = 0
            Factura.idEmpresa = idPSE 'lblIdPse.Text
            Factura.Contribuyente_id = Gempresas.IdEmpresaRuc
            Factura.Contribuyente_id = Gempresas.IdEmpresaRuc
            Factura.EnvioSunat = "NO"
            'Receptor de la Factura
            Factura.NroDocumentoRec = comprobanteEntidad.nrodoc
            Factura.TipoDocumentoRec = comprobanteEntidad.tipoDoc
            Factura.NombreLegalRec = comprobanteEntidad.nombreCompleto
            'Datos Generales De La Factura
            Factura.IdDocumento = documneotventaTransporte.serie & "-" & numerovent
            Factura.FechaEmision = documneotventaTransporte.fechadoc
            Factura.FechaRecepcion = DateTime.Now 'fecha en la que se envia al PSE
            Factura.FechaVencimiento = DateTime.Now
            Factura.HoraEmision = documneotventaTransporte.fechadoc.Value.ToString(Formatohora)

            'If documneotventaTransporte.moneda = "1" Then
            Factura.Moneda = "PEN"
            'ElseIf documneotventaTransporte.moneda = "2" Then
            '    Factura.Moneda = "USD"
            'End If


            'If destino = "1" Then
            Factura.TipoDocumento = tipoDoc
            Factura.TotalIgv = documneotventaTransporte.igv1
            Factura.TotalVenta = documneotventaTransporte.total
            Factura.Gravadas = documneotventaTransporte.baseImponible1
            Factura.Exoneradas = documneotventaTransporte.baseImponible2
            'ElseIf destino = "2" Then
            '    Factura.TipoDocumento = tipoDoc
            '    Factura.TotalIgv = 0.0
            '    Factura.TotalVenta = documneotventaTransporte.total
            '    Factura.Gravadas = 0.0
            '    Factura.Exoneradas = documneotventaTransporte.total
            'End If




            Factura.TipoOperacion = "0101"

            'Cargando el Detalle de la Factura

            For Each i In documneotventaTransporte.documentoventaTransporteDetalle
                conteo += 1
                Dim preciounit As Decimal = Math.Round(CDec(i.importe / i.cantidad), 2)
                Dim calcbi As Decimal = Math.Round(CDec(CalculoBaseImponible(i.importe, 1.18)), 2)
                Dim calcigv As Decimal = Math.Round(CDec(i.importe - calcbi), 2)

                DetalleFactura = New Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
                DetalleFactura.Id = conteo
                DetalleFactura.Cantidad = i.cantidad
                DetalleFactura.PrecioReferencial = preciounit 'i.precioUnitario
                DetalleFactura.CodigoItem = i.secuencia
                DetalleFactura.Descripcion = i.detalle
                DetalleFactura.UnidadMedida = i.unidadMedida

                DetalleFactura.Manifiesto = manifiesto

                If i.destino = "1" Then
                    DetalleFactura.Impuesto = calcigv
                    DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
                    DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
                    DetalleFactura.PrecioUnitario = CalculoBaseImponible(preciounit, 1.18) 'FormatNumber
                    DetalleFactura.TotalVenta = CalculoBaseImponible(preciounit, 1.18)
                ElseIf i.destino = "2" Then
                    DetalleFactura.Impuesto = 0
                    DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
                    DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
                    DetalleFactura.PrecioUnitario = i.importe
                    DetalleFactura.TotalVenta = i.importe
                End If


                ' calcbi 'i.montokardex
                'DetalleItems .Descuento = "falta"
                'DetalleItems .ImpuestoSelectivo = "falta"
                'DetalleItems.OtroImpuesto = "falta"
                'DetalleItems.PlacaVehiculo = "falta"

                '//transporte
                DetalleFactura.NumeroAsiento = ObjTareo.Asiento
                DetalleFactura.Manifiesto = manifiesto
                DetalleFactura.PlacaVehiculo = documneotventaTransporte.nroPlaca
                DetalleFactura.NroDocPasajero = ObjTareo.customPersona.idPersona
                DetalleFactura.TipoDocPasajero = ObjTareo.customPersona.tipodoc
                DetalleFactura.NombrePasajero = ObjTareo.customPersona.nombreCompleto
                DetalleFactura.UbigeoDestino = ObjTareo.customRuta.ciudadDestinoUbigeo
                DetalleFactura.UbigeoOrigen = ObjTareo.customRuta.ciudadOrigenUbigeo
                DetalleFactura.Destino = ObjTareo.customRuta.ciudadDestino
                DetalleFactura.Origen = ObjTareo.customRuta.ciudadOrigen
                DetalleFactura.FechaProgramada = documneotventaTransporte.fechaProgramada.Value.ToString(FormatoFecha)

                DetalleFactura.HoraProgramada = documneotventaTransporte.fechaProgramada.Value.ToString(Formatohora)


                Factura.DocumentoElectronicoDetalle.Add(DetalleFactura)
            Next


            'Enviando al PSE
            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoElectronicoSA.DocumentoElectronicoSaveValidado(Factura, Nothing)

            If codigo.idDocumentoElectronico > 0 Then

                UpdateEnvioSunatEstado(documneotventaTransporte.idDocumento, "SI")
                'MessageBox.Show("La Factura se Envio Correctamente al PSE")
            End If

        Catch ex As Exception
            'MessageBox.Show(ex.Message)GRABAR
        End Try
    End Sub


    Public Sub UpdateEnvioSunatEstado(idDoc As Integer, estado As String)
        Try
            Dim docSA As New DocumentoventaTransporteSA
            docSA.UpdateFacturasXEstadoTrans(idDoc, estado)
        Catch ex As Exception
        End Try
    End Sub

    'Dim conf As New GConfiguracionModulo
    'Private Sub GetNumeracion(strIdModulo As String, strIDEmpresa As String)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, GEstableciento.IdEstablecimiento)
    '    conf = New GConfiguracionModulo
    '    conf = ConfigurarComprobanteVenta(moduloConfiguracion)
    '    'SetDataSourceNumeracion(moduloConfiguracion)
    'End Sub

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
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return GConfiguracion
    End Function

    Public Function ConfigurarComprobanteVenta(moduloConfiguracion As moduloConfiguracion) As GConfiguracionModulo
        Dim numeracionSA As New NumeracionBoletaSA
        Dim TablaSA As New tablaDetalleSA
        Dim almacenSA As New almacenSA
        Dim cajaSA As New EstadosFinancierosSA

        If Not IsNothing(moduloConfiguracion) Then
            With moduloConfiguracion
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.IdModulo = .idModulo
                GConfiguracion.TipoConfiguracion = .tipoConfiguracion
                Select Case .tipoConfiguracion
                    Case "P"
                        With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
                            GConfiguracion.ConfigComprobante = .IdEnumeracion

                            If cboTipoDoc.Text = "BOLETA" Then
                                GConfiguracion.TipoComprobante = "12.1" ' .tipo
                                GConfiguracion.Serie = .serie
                                GConfiguracion.ValorActual = .valorInicial

                            End If
                            If cboTipoDoc.Text = "FACTURA" Then
                                GConfiguracion.TipoComprobante = "12.2" '.tipo
                                GConfiguracion.Serie = .serie
                                GConfiguracion.ValorActual = .valorInicial

                            End If

                            If cboTipoDoc.Text = "FACTURA ELECTRONICA" Then

                                GConfiguracion.TipoComprobante = "01" '.tipo
                                GConfiguracion.Serie = .serie
                                GConfiguracion.ValorActual = .valorInicial


                            End If
                            If cboTipoDoc.Text = "BOLETA ELECTRONICA" Then
                                GConfiguracion.TipoComprobante = "03" ' .tipo
                                GConfiguracion.Serie = .serie
                                GConfiguracion.ValorActual = .valorInicial

                            End If

                            If cboTipoDoc.Text = "PROFORMA" Then
                                GConfiguracion.TipoComprobante = .tipo
                                GConfiguracion.Serie = .serie
                                GConfiguracion.ValorActual = .valorInicial
                            End If
                        End With
                    Case "M"

                End Select

            End With
        Else
            '  lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
            ' Timer1.Enabled = True
            'TabCompra.Enabled = False
            'TiempoEjecutar(5)
        End If
        Return GConfiguracion
    End Function

    'Private Sub GetUsuarioUnico()
    '    '    If CheckUsuarioUnico.Checked = True Then
    '    If UsuariosList IsNot Nothing Then
    '        Dim user = UsuariosList.Where(Function(o) o.IDUsuario = usuario.IDUsuario).SingleOrDefault
    '        If user IsNot Nothing Then
    '            TextCodigoVendedor.Text = user.codigo
    '        End If
    '    End If

    '    '   End If
    'End Sub

    'Sub cargarCajas()
    '    If ListaCajasActivas IsNot Nothing Then
    '        If ListaCajasActivas.Count > 0 Then
    '            ComboCaja.DataSource = ListaCajasActivas ' cajaUsuarioSA.ListadoCajaXEstado(UsuarioBE)
    '            ComboCaja.ValueMember = "idcajaUsuario" ' "IDUsuario"
    '            ComboCaja.DisplayMember = "NombrePersona"
    '        End If
    '    End If
    'End Sub

    Public Sub GetMappingVariables()
        LabelAsientoSel.Text = ObjTareo.Asiento
        Select Case tipopersonaSel
            Case "N"
                TextNombres.Text = ObjTareo.customPersona.nombreCompleto
                TextNombres.Tag = ObjTareo.customPersona.codigo
                TextCodigoIdentidad.Text = ObjTareo.customPersona.tipodoc
                Select Case ObjTareo.customPersona.tipodoc
                    Case "1"
                        TextTipoDocIdentidad.Text = "DNI"
                    Case "4"
                        TextTipoDocIdentidad.Text = "CARNET DE EXTRANJERIA"
                    Case "6"
                        TextTipoDocIdentidad.Text = "REGISTRO UNICO DE CONTRIBUYENTES"
                    Case "7"
                        TextTipoDocIdentidad.Text = "PASAPORTE"
                End Select
                TextNumIdent.Text = ObjTareo.customPersona.idPersona

                '------------------------------------------------------------------
                TextRaZonSocial.Text = ObjTareo.customPersona.nombreCompleto
                TextRaZonSocial.Tag = ObjTareo.customPersona.codigo
                TextRuc.Text = ObjTareo.customPersona.idPersona
                TextCodigoComprobanteRazon.Text = ObjTareo.customPersona.tipodoc
                Select Case ObjTareo.customPersona.tipodoc
                    Case "1"
                        TextTipoDocIdentidadRazon.Text = "DNI"
                    Case "4"
                        TextTipoDocIdentidadRazon.Text = "CARNET DE EXTRANJERIA"
                    Case "6"
                        TextTipoDocIdentidadRazon.Text = "REGISTRO UNICO DE CONTRIBUYENTES"
                    Case "7"
                        TextTipoDocIdentidadRazon.Text = "PASAPORTE"
                End Select
        '------------------------------------------------------------------

            Case "J"
                TextNombres.Text = ObjTareo.customPersona.nombreCompleto ' $"{ObjTareo.customPersona.nombres}, {ObjTareo.customPersona.appat}"
                TextNombres.Tag = ObjTareo.customPersona.codigo
                TextCodigoIdentidad.Text = ObjTareo.customPersona.tipodoc
                Select Case ObjTareo.customPersona.tipodoc
                    Case "1"
                        TextTipoDocIdentidad.Text = "DNI"
                    Case "4"
                        TextTipoDocIdentidad.Text = "CARNET DE EXTRANJERIA"
                    Case "6"
                        TextTipoDocIdentidad.Text = "REGISTRO UNICO DE CONTRIBUYENTES"
                    Case "7"
                        TextTipoDocIdentidad.Text = "PASAPORTE"
                End Select
                TextNumIdent.Text = ObjTareo.customPersona.idPersona

                '------------------------------------------------------------------
                TextRaZonSocial.Text = ObjTareo.customEntidad.nombreCompleto
                TextRaZonSocial.Tag = ObjTareo.customEntidad.idEntidad
                TextRuc.Text = ObjTareo.customEntidad.nrodoc
                TextCodigoComprobanteRazon.Text = ObjTareo.customEntidad.tipoDoc
                Select Case ObjTareo.customEntidad.tipoDoc
                    Case "1"
                        TextTipoDocIdentidadRazon.Text = "DNI"
                    Case "4"
                        TextTipoDocIdentidadRazon.Text = "CARNET DE EXTRANJERIA"
                    Case "6"
                        TextTipoDocIdentidadRazon.Text = "REGISTRO UNICO DE CONTRIBUYENTES"
                    Case "7"
                        TextTipoDocIdentidadRazon.Text = "PASAPORTE"
                End Select
                '------------------------------------------------------------------
        End Select

        txtTotalPagar.DecimalValue = ObjTareo.ImporteVenta

        'TextCiudadDestino.Text = ObjTareo.customRuta.ciudadDestino
        'TextDestinoUbigeo.Text = ObjTareo.customRuta.ciudadDestinoUbigeo

        'TextCiudadOrigen.Text = ObjTareo.customRuta.ciudadOrigen
        'TextOrigenUbigeo.Text = ObjTareo.customRuta.ciudadOrigenUbigeo

        If (destino = "1") Then
            Dim baseImponible = Math.Round(CDec(CalculoBaseImponible(ObjTareo.ImporteVenta, 1.18)), 2)
            Dim iva = Math.Round(ObjTareo.ImporteVenta - baseImponible, 2)

            txtTotalBase.DecimalValue = baseImponible
            txtTotalIva.DecimalValue = iva
            txtTotalBase2.DecimalValue = 0

        ElseIf (destino = "2") Then
            Dim baseImponible = 0 'Math.Round(CDec(CalculoBaseImponible(ObjTareo.ImporteVenta, 1.18)), 2)
            Dim iva = 0 ' Math.Round(ObjTareo.ImporteVenta - baseImponible, 2)

            txtTotalBase.DecimalValue = baseImponible
            txtTotalIva.DecimalValue = iva
            txtTotalBase2.DecimalValue = ObjTareo.ImporteVenta

        End If

    End Sub

    Private Sub GetMappingColumnsGridByUsuario()
        'Dim dt As New DataTable
        Dim SA As New EstadosFinancierosConfiguracionPagosSA
        Dim listCajas As New cajaUsuario

        listCajas = (ListaCajasActivas.Where(Function(o) o.estadoCaja = "A")).FirstOrDefault

        listaCuentas = SA.GetConfigurationPayCaja(New estadosFinancierosConfiguracionPagos With
                                                 {
                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                 .IDCaja = listCajas.idcajaUsuario
                                                 })


        '//impresion

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

    'Private Function SumaPagos() As Decimal
    '    SumaPagos = 0
    '    Dim pagoCupones As Decimal = 0
    '    For Each i In dgvCuentas.Table.Records
    '        'If i.GetValue("abonado") <= 0 Then
    '        '    Throw New Exception("El monto abonado debe sre mayor a cero")
    '        'End If
    '        SumaPagos += CDec(i.GetValue("abonado"))
    '    Next
    '    '    pagoCupones = TextCuponImporte.DecimalValue
    '    SumaPagos = SumaPagos + pagoCupones
    '    Return SumaPagos
    'End Function
    Public Sub GetDocsVenta()
        cboTipoDoc.Items.Clear()
        'cboTipoDoc.Items.Add("NOTA DE VENTA")
        'cboTipoDoc.Items.Add("BOLETA")
        'cboTipoDoc.Items.Add("FACTURA")
        cboTipoDoc.Items.Add("BOLETA ELECTRONICA")
        cboTipoDoc.Items.Add("FACTURA ELECTRONICA")
        'cboTipoDoc.Items.Add("RESERVAR")

        'cboTipoDoc.Text = "BOLETA ELECTRONICA"
    End Sub

    'Private Sub dgvCuentas_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) 
    '    Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
    '    Try
    '        Select Case ColIndex
    '            Case 3
    '                Dim pagos As Decimal = SumaPagos()

    '                lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(SumaPagos())

    '                If (lblPagoVenta.Text = CDec(0.0)) Then
    '                    ErrorProvider1.Clear()
    '                End If

    '                If pagos > CDec(txtTotalPagar.Text) Then
    '                    MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
    '                    Exit Sub
    '                End If
    '        End Select
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Verificar montos del pago")
    '    End Try
    'End Sub
#End Region

#Region "Events"
    Private Sub cboTipoDoc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedValueChanged
        If cboTipoDoc.Text.Trim.Length > 0 Then
            Select Case cboTipoDoc.Text
                Case "BOLETA"


                    'txtNumero.Clear()
                    'txtSerie.Visible = False
                    'txtSerie.ReadOnly = True
                    'txtNumero.Visible = False
                    'txtNumero.ReadOnly = True

                    'txtruc.Text = 0
                    'TXTcOMPRADOR.Text = "VARIOS"
                    'txtruc.Select(0, txtruc.Text.Length)
                    'txtruc.Focus()
                    'Getclientepedido()

                    ProgressBar2.Visible = True
                    ProgressBar2.Style = ProgressBarStyle.Marquee
                    BackgroundWorker1.RunWorkerAsync()


                Case "FACTURA"


                    'txtNumero.Clear()
                    'txtSerie.Visible = False
                    'txtSerie.ReadOnly = True
                    'txtNumero.Visible = False
                    'txtNumero.ReadOnly = True

                    'txtruc.Clear()
                    'TXTcOMPRADOR.Clear()
                    'txtruc.Select(0, txtruc.Text.Length)
                    'txtruc.Focus()
                    '  Getclientepedido()

                    ProgressBar2.Visible = True
                    ProgressBar2.Style = ProgressBarStyle.Marquee
                    BackgroundWorker1.RunWorkerAsync()



                Case "NOTA DE VENTA"

                    'txtruc.Text = 0
                    'TXTcOMPRADOR.Text = "VARIOS"
                    'txtruc.Select(0, txtruc.Text.Length)
                    'txtruc.Focus()

                Case "BOLETA ELECTRONICA"


                    'txtNumero.Clear()
                    'txtSerie.Visible = False
                    'txtSerie.ReadOnly = True
                    'txtNumero.Visible = False
                    'txtNumero.ReadOnly = True


                    ProgressBar2.Visible = True
                    ProgressBar2.Style = ProgressBarStyle.Marquee
                    BackgroundWorker1.RunWorkerAsync()
                Case "FACTURA ELECTRONICA"

                    'txtNumero.Clear()
                    'txtSerie.Visible = False
                    'txtSerie.ReadOnly = True
                    'txtNumero.Visible = False
                    'txtNumero.ReadOnly = True


                    ProgressBar2.Visible = True
                    ProgressBar2.Style = ProgressBarStyle.Marquee
                    BackgroundWorker1.RunWorkerAsync()

            End Select
            'GetResetCantidades()
        End If

    End Sub

    'Private Sub ChPagoAvanzado_OnChange(sender As Object, e As EventArgs) 
    '    If ChPagoAvanzado.Checked = True Then
    '        chCredito.Checked = False
    '        LblPagoCredito.Visible = False
    '        ErrorProvider1.Clear()
    '        If IsNumeric(ComboCaja.SelectedValue) Then
    '            GetMappingColumnsGridByUsuario(Integer.Parse(ComboCaja.SelectedValue))
    '        End If
    '    Else
    '        'ChPagoAvanzado.Checked = True
    '    End If
    'End Sub

    'Private Sub chCredito_OnChange(sender As Object, e As EventArgs) 
    '    If chCredito.Checked = True Then
    '        chCredito.Checked = True
    '        LblPagoCredito.Visible = True
    '        ChPagoAvanzado.Checked = False
    '        ErrorProvider1.Clear()
    '    Else
    '        ' chCredito.Checked = True
    '        LblPagoCredito.Visible = True
    '    End If
    'End Sub

    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0

        'If (ChPagoAvanzado.Checked = True And lblPagoVenta.Text > 0) Then
        '    ErrorProvider1.SetError(Label8, "Debe efectuar la totalidad del pago")
        '    listaErrores += 1
        'End If

        If txtTotalPagar.DecimalValue <= 0 Then
            ErrorProvider1.SetError(txtTotalPagar, "La venta debe ser mayor a cero")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtTotalPagar, Nothing)
        End If

        If listaErrores > 0 Then
            ValidarGrabado = False
        Else
            ValidarGrabado = True
        End If
    End Function

    'Public Function EstadoRed(ByVal mURL As String) As Boolean

    '    Try

    '        If My.Computer.Network.IsAvailable() Then
    '            If My.Computer.Network.Ping(mURL, 5000) Then 'Asignamos la pagina a consultar ejemplo www.google.cl y el tiempo de espera máximo
    '                EstadoRed = True
    '            Else
    '                EstadoRed = False
    '            End If
    '        Else
    '            EstadoRed = False
    '        End If

    '    Catch ex As Exception
    '        EstadoRed = False
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


    Private Sub GrabarVentaPasajeReservacion(envio As EnvioImpresionVendedorPernos)
        Dim ventaSA As New DocumentoventaTransporteSA


        txtFecha.Value = Date.Now
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
        .fechaProceso = txtFecha.Value,
        .moneda = "1",
        .idEntidad = TextNombres.Tag,
        .entidad = TextNombres.Text,
        .tipoEntidad = "PS",
        .nrodocEntidad = TextNumIdent.Text,
        .nroDoc = "1",
        .idOrden = 0,
          .IDCajaUsuario = envio.IDCaja,
        .tipoOperacion = StatusTipoOperacion.VENTA,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }

        documento.documentoventaTransporte = New documentoventaTransporte With
     {
     .tareo_id = 1,
     .programacion_id = Integer.Parse(LabelfechaProg.Tag),
      .TipoConfiguracion = If(GConfiguracion Is Nothing, Nothing, GConfiguracion.TipoConfiguracion),
       .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
     .tipoOperacion = StatusTipoOperacion.VENTA,
     .idEmpresa = Gempresas.IdEmpresaRuc,
     .idOrganizacion = GEstableciento.IdEstablecimiento,
     .UbigeoCiudadOrigen = TextOrigenUbigeo.Text,
     .ciudadOrigen = TextCiudadOrigen.Text,
     .UbigeoCiudadDestino = TextDestinoUbigeo.Text,
     .ciudadDestino = TextCiudadDestino.Text,
     .tipoDocumento = tipodoc,
     .fechaProgramada = LabelfechaProg.Text,
     .fechadoc = txtFecha.Value,
     .serie = GConfiguracion.Serie,
     .numero = 0,
     .idPersona = Integer.Parse(TextNombres.Tag),
     .razonSocial = Integer.Parse(TextRaZonSocial.Tag),
     .comprador = TextNombres.Text,
     .moneda = "1",
     .tipocambio = 1,
     .tasaIgv = txtTotalIva.DecimalValue,
     .baseImponible1 = txtTotalBase.DecimalValue,
     .baseImponible2 = txtTotalBase2.DecimalValue,
     .igv1 = txtTotalIva.DecimalValue,
     .igv2 = 0,
     .total = txtTotalPagar.DecimalValue,
     .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
     .glosa = "Venta de pasajes",
     .tipoVenta = TIPO_VENTA.VENTA_PASAJES,
     .numeroAsiento = Integer.Parse(LabelAsientoSel.Text),
     .nroPlaca = nroPlaca,
     .estado = 1,
     .edad = textEdad.Text,
     .usuarioActualizacion = usuario.IDUsuario,
     .fechaActualizacion = Date.Now
     }

        Dim docdet As documentoventaTransporteDetalle = New documentoventaTransporteDetalle With
        {
        .[tipo] = TIPO_VENTA.VENTA_PASAJES,
       .[codigoBarraSerie] = Nothing,
        .[detalle] = "POR VENTA DE PASAJE : ASIENTO - " & Integer.Parse(LabelAsientoSel.Text),
       .[sku] = destino,
         .destino = destino,
           .tipoExistencia = "GS",
        .[cantidad] = 1,
        .[unidadMedida] = "NIU",
        .[importe] = txtTotalPagar.DecimalValue,
        .[agencia_id] = Nothing,
        .[estado] = "1",
        .[manifiesto] = manifiesto,
        .[idDistribucion] = distribucionID,
        .[estadoDiustribucion] = "A",
        .[usuarioActualizacion] = usuario.IDUsuario,
        .[fechaActualizacion] = Date.Now
             }

        documento.documentoventaTransporte.documentoventaTransporteDetalle.Add(docdet)

        Dim ListaPagos = ListaPagosCajas(documento.documentoventaTransporte, envio)
        documento.documentoventaTransporte.estadoCobro = TIPO_VENTA.PAGO.COBRADO
        documento.ListaCustomDocumento = ListaPagos 'ListaPagosCajas(c)
        'documento.documentoventaTransporte.CustomVehiculoAsiento_Precios = vehiculoAsientoPrecios
        Dim codVenta = ventaSA.DocumentoventaTransporteReservacionSave(documento, idDocReferecia)
        'formVentaPasajes.ReiniciarForm(True, codVenta)
        'Dim miInterfaz As ICommitOperacionMKT = TryCast(Me.Owner.t, ICommitOperacionMKT)
        'If miInterfaz IsNot Nothing Then miInterfaz.Commit(True, codVenta)

        Dim documentoventaSA As New VehiculoAsiento_PreciosSA
        Dim documentoventaBE As New vehiculoAsiento_Precios

        documentoventaBE.idEmpresa = Gempresas.IdEmpresaRuc
        documentoventaBE.precio_id = distribucionID
        documentoventaBE.estado = "U"
        documentoventaBE.sexo = sexo
        documentoventaSA.updateAsientoTransporteConfirmacionxID(documentoventaBE)

        comprobanteTransporte = ventaSA.DocumentoTransporteSelIDVer2(New documentoventaTransporte With
                                                               {
                                                               .idDocumento = codVenta
                                                               })

        comprobanteEntidad = entidadSA.UbicarEntidadPorID(comprobanteTransporte.razonSocial).FirstOrDefault

        If Gempresas.ubigeo > 0 Then
            If EstadoRed("138.128.171.106") = True Then
                If cboTipoDoc.Text = "FACTURA ELECTRONICA" Or cboTipoDoc.Text = "BOLETA ELECTRONICA" Then
                    'EnvioPSE(Gempresas.IdEmpresaRuc, impresionTicketDoc.idDocumento)
                    EnviarFacturaElectronica(codVenta, Gempresas.ubigeo)
                End If
            End If
        End If

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

        'Me.Tag = 1

        'Close()
        'ImprimirTicket("\\192.168.1.30\TICKET", codVenta, "", comprobanteEntidad, comprobanteTransporte)
        ImprimirTicket("TICKET", codVenta, "", comprobanteEntidad, comprobanteTransporte)
        'ImprimirTicket("EPSON TM-T20II Receipt5", codVenta, "", comprobanteEntidad, comprobanteTransporte)  'LA MERCED
        Me.Tag = 1
        Close()
    End Sub

    Private Sub GrabarVentaPasaje(envio As EnvioImpresionVendedorPernos)
        Dim ventaSA As New DocumentoventaTransporteSA


        txtFecha.Value = Date.Now
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
        .fechaProceso = txtFecha.Value,
        .moneda = "1",
        .idEntidad = TextNombres.Tag,
        .entidad = TextNombres.Text,
        .tipoEntidad = "PS",
        .nrodocEntidad = TextNumIdent.Text,
        .nroDoc = "1",
        .idOrden = 0,
        .IDCajaUsuario = envio.IDCaja,
        .tipoOperacion = StatusTipoOperacion.VENTA,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }


        documento.documentoventaTransporte = New documentoventaTransporte With
     {
     .tareo_id = 1,
     .programacion_id = Integer.Parse(LabelfechaProg.Tag),
      .TipoConfiguracion = If(GConfiguracion Is Nothing, Nothing, GConfiguracion.TipoConfiguracion),
       .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
     .tipoOperacion = StatusTipoOperacion.VENTA,
     .idEmpresa = Gempresas.IdEmpresaRuc,
     .idOrganizacion = GEstableciento.IdEstablecimiento,
     .UbigeoCiudadOrigen = TextOrigenUbigeo.Text,
     .ciudadOrigen = TextCiudadOrigen.Text,
     .UbigeoCiudadDestino = TextDestinoUbigeo.Text,
     .ciudadDestino = TextCiudadDestino.Text,
     .tipoDocumento = tipodoc,
     .fechaProgramada = LabelfechaProg.Text,
     .fechadoc = txtFecha.Value,
     .serie = GConfiguracion.Serie,
     .numero = 0,
     .idPersona = Integer.Parse(TextNombres.Tag),
     .razonSocial = Integer.Parse(TextRaZonSocial.Tag),
     .comprador = TextNombres.Text,
     .moneda = "1",
     .tipocambio = 1,
     .tasaIgv = txtTotalIva.DecimalValue,
     .baseImponible1 = txtTotalBase.DecimalValue,
     .baseImponible2 = txtTotalBase2.DecimalValue,
     .igv1 = txtTotalIva.DecimalValue,
     .igv2 = 0,
     .total = txtTotalPagar.DecimalValue,
     .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
     .glosa = "Venta de pasajes",
     .tipoVenta = TIPO_VENTA.VENTA_PASAJES,
     .numeroAsiento = Integer.Parse(LabelAsientoSel.Text),
     .nroPlaca = nroPlaca,
     .estado = 1,
     .edad = textEdad.Text,
     .usuarioActualizacion = usuario.IDUsuario,
     .fechaActualizacion = Date.Now
     }

        Dim docdet As documentoventaTransporteDetalle = New documentoventaTransporteDetalle With
        {
        .[tipo] = TIPO_VENTA.VENTA_PASAJES,
       .[codigoBarraSerie] = destino,
        .[detalle] = descripcion & Integer.Parse(LabelAsientoSel.Text),
       .[sku] = destino,
         .destino = destino,
           .tipoExistencia = "GS",
        .[cantidad] = 1,
        .[unidadMedida] = "NIU",
        .[importe] = txtTotalPagar.DecimalValue,
        .[agencia_id] = Nothing,
        .[estado] = "1",
        .[manifiesto] = manifiesto,
        .[idDistribucion] = distribucionID,
        .[estadoDiustribucion] = "A",
        .[usuarioActualizacion] = usuario.IDUsuario,
        .[fechaActualizacion] = Date.Now
             }

        documento.documentoventaTransporte.documentoventaTransporteDetalle.Add(docdet)

        Dim ListaPagos = ListaPagosCajas(documento.documentoventaTransporte, envio)
        documento.documentoventaTransporte.estadoCobro = TIPO_VENTA.PAGO.COBRADO
        documento.ListaCustomDocumento = ListaPagos 'ListaPagosCajas(c)
        'documento.documentoventaTransporte.CustomVehiculoAsiento_Precios = vehiculoAsientoPrecios
        Dim codVenta = ventaSA.DocumentoventaTransporteSave(documento)
        'formVentaPasajes.ReiniciarForm(True, codVenta)
        'Dim miInterfaz As ICommitOperacionMKT = TryCast(Me.Owner.t, ICommitOperacionMKT)
        'If miInterfaz IsNot Nothing Then miInterfaz.Commit(True, codVenta)

        Dim documentoventaSA As New VehiculoAsiento_PreciosSA
        Dim documentoventaBE As New vehiculoAsiento_Precios

        documentoventaBE.idEmpresa = Gempresas.IdEmpresaRuc
        documentoventaBE.precio_id = distribucionID
        documentoventaBE.estado = "U"
        documentoventaBE.sexo = sexo
        documentoventaSA.updateAsientoTransporteConfirmacionxID(documentoventaBE)

        comprobanteTransporte = ventaSA.DocumentoTransporteSelIDVer2(New documentoventaTransporte With
                                                               {
                                                               .idDocumento = codVenta
                                                               })

        comprobanteEntidad = entidadSA.UbicarEntidadPorID(comprobanteTransporte.razonSocial).FirstOrDefault


        If Gempresas.ubigeo > 0 Then
            If EstadoRed("138.128.171.106") = True Then
                If cboTipoDoc.Text = "FACTURA ELECTRONICA" Or cboTipoDoc.Text = "BOLETA ELECTRONICA" Then
                    'EnvioPSE(Gempresas.IdEmpresaRuc, impresionTicketDoc.idDocumento)
                    EnviarFacturaElectronica(codVenta, Gempresas.ubigeo)
                End If
            End If
        End If

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

        'ImprimirTicket("\\192.168.1.30\TICKET", codVenta, "", comprobanteEntidad, comprobanteTransporte)

        ImprimirTicket("TICKET", codVenta, "", comprobanteEntidad, comprobanteTransporte)
        'ImprimirTicket("EPSON TM-T20II Receipt5", codVenta, "", comprobanteEntidad, comprobanteTransporte)  'LA MERCED

        Me.Tag = 1

        Close()
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

    ''Sub ImprimirTicket(imprimir As String, intIdDocumento As Integer, comprobante As documentoventaTransporte, entidad As entidad)

    ''    Dim a As TicketTransporte = New TicketTransporte
    ''    'a.HeaderImage = "C:\Documents and Settings\Administrador\Mis documentos\COMPU.jpg" 
    ''    Dim gravMN As Decimal = 0
    ''    Dim gravME As Decimal = 0
    ''    Dim ExoMN As Decimal = 0
    ''    Dim ExoME As Decimal = 0
    ''    Dim InaMN As Decimal = 0
    ''    Dim InaME As Decimal = 0
    ''    Dim precioUnit As Decimal = 0
    ''    Dim PrecioTotal As Decimal = 0

    ''    Dim nombreCliente As String
    ''    Dim rucCliente As String = String.Empty
    ''    Dim importeTotalMN As Decimal
    ''    Dim importeSumMN As Decimal

    ''    'If My.Computer.Network.IsAvailable = True Then
    ''    '    'If My.Computer.Network.Ping("148.102.27.231") Then
    ''    '    If (documentoBE.documentoventaAbarrotes.tipoDocumento = "01" And documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Or (documentoBE.documentoventaAbarrotes.tipoDocumento = "07" And documentoBE.documentoventaAbarrotes.tipoVenta = "NTCE") Then
    ''    '        XmlFactura(documentoBE.documentoventaAbarrotes, documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList)
    ''    '    End If
    ''    '    'End If
    ''    'End If

    ''    If (objDatosGenrales.logo.Length > 0) Then
    ''        ' Logo de la Empresa
    ''        a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
    ''    End If

    ''    If (objDatosGenrales.nombreImpresion = "C") Then
    ''        a.tipoImagen = False
    ''    ElseIf (objDatosGenrales.nombreImpresion = "R") Then
    ''        a.tipoImagen = True
    ''    End If

    ''    'Direccion de La empresa general
    ''    If (objDatosGenrales.tipoImpresion = "S") Then
    ''        a.tipoEncabezado = True
    ''        a.AnadirLineaEmpresa(objDatosGenrales.nombreCorto)
    ''        a.AnadirLineaNombrePropietario(objDatosGenrales.razonSocial)
    ''    ElseIf (objDatosGenrales.tipoImpresion = "N") Then
    ''        a.tipoEncabezado = False
    ''        a.AnadirLineaEmpresa(objDatosGenrales.razonSocial)

    ''    End If

    ''    If (objDatosGenrales.publicidad.Length > 0) Then
    ''        a.tipoPublicidad = True
    ''        a.AnadirLineaNombrePublidad(objDatosGenrales.publicidad)
    ''    Else
    ''        a.tipoPublicidad = False
    ''    End If

    ''    'Dim nombreCliente As String
    ''    'Dim rucCliente As String
    ''    'Dim nombreCliente As String
    ''    'Dim rucCliente As String

    ''    'ruc
    ''    a.TextoIzquierda("R.U.C.: " & objDatosGenrales.idEmpresa)
    ''    'direccion de la empresa
    ''    a.TextoIzquierda(objDatosGenrales.direccionPrincipal)
    ''    a.TextoIzquierda(objDatosGenrales.direccionSecudaria)
    ''    'Telefono de la empresa
    ''    If (objDatosGenrales.telefono3.Length > 0) Then
    ''        a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3)
    ''    ElseIf (objDatosGenrales.telefono2.Length > 0) Then
    ''        a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
    ''    Else
    ''        a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1)
    ''    End If

    ''    Dim DIRECCIONclIENTE As String = String.Empty
    ''    Dim NBoletaElectronica As String = String.Empty
    ''    'If documentoBE.documentoventaAbarrotes.idCliente <> 0 Then
    ''    Dim entidad = documentoBE.documentoventaAbarrotes.CustomEntidad  'entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault

    ''    Select Case entidad.tipoEntidad
    ''        Case "VR"
    ''            NBoletaElectronica = documentoBE.documentoventaAbarrotes.nombrePedido
    ''        Case Else
    ''            NBoletaElectronica = entidad.nombreCompleto
    ''    End Select


    ''    DIRECCIONclIENTE = entidad.DireccionSeleccionada ' entidad.direccion
    ''    nombreCliente = (NBoletaElectronica)

    ''    Select Case entidad.tipoEntidad
    ''        Case "VR"
    ''            rucCliente = "-"
    ''        Case Else
    ''            If (Not IsNothing(entidad.nrodoc)) Then
    ''                If entidad.nrodoc.Trim.Length = 11 Then
    ''                    rucCliente = "R.U.C. - " & entidad.nrodoc
    ''                ElseIf entidad.nrodoc.Trim.Length = 8 Then
    ''                    rucCliente = "D.N.I. - " & entidad.nrodoc
    ''                Else
    ''                    rucCliente = ("NRO DOC.: " & entidad.nrodoc)
    ''                End If
    ''            Else
    ''                rucCliente = "-"
    ''            End If
    ''    End Select

    ''    'Codigo qr

    ''    If (Not IsNothing(HASH)) Then
    ''        If HASH.Trim.Length > 0 Then
    ''            QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
    ''                                  "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
    ''                                  "|" & HASH & "|" & CERTIFICADO)

    ''            QrCodeImgControl1.Text = QR
    ''        Else
    ''            QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
    ''                                 "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

    ''            QrCodeImgControl1.Text = QR
    ''        End If
    ''    End If

    ''    QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
    ''                               "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

    ''    QrCodeImgControl1.Text = QR

    ''    'QrCodeImgControl1.Image

    ''    'Else
    ''    '    Dim NBoletaElectronica As String = documentoBE.documentoventaAbarrotes.nombrePedido
    ''    '    nombreCliente = (NBoletaElectronica)

    ''    '    'Codigo qr
    ''    '    QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
    ''    '              "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & "VARIOS" & "|" & "0")

    ''    '    QrCodeImgControl1.Text = QR

    ''    'End If

    ''    Select Case documentoBE.documentoventaAbarrotes.tipoDocumento
    ''        Case "12.1"
    ''            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET BOLETA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
    ''            a.tipoComprobante = 1
    ''            a.AnadirLineaComprobante("TICKET BOLETA")
    ''            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)

    ''            'a.AnadirLineaSubcabeza("Ticket Boleta    N° " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
    ''        Case "12.2"
    ''            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET FACTURA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
    ''            a.tipoComprobante = 1
    ''            a.AnadirLineaComprobante("TICKET FACTURA")
    ''            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
    ''            'a.AnadirLineaSubcabeza("Ticket Factura    N° " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
    ''        Case "03"
    ''            If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
    ''                a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA DE VENTA ELECTRONICA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
    ''                a.tipoComprobante = 2
    ''                a.AnadirLineaComprobante("BOLETA DE VENTA ELECTRONICA")
    ''                a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c))

    ''                Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = documentoBE.documentoventaAbarrotes.usuarioActualizacion).FirstOrDefault

    ''                If Not IsNothing(consultaNombre) Then
    ''                    a.AnadirLineasDatosFinales("VENDEDOR: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)
    ''                Else
    ''                    a.AnadirLineasDatosFinales("VENDEDOR: " & "VARIOS")
    ''                End If


    ''                a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE")
    ''                a.AnadirLineasDatosFinales("VENTA ELECTRONICA")
    ''                a.AnadirLineasDatosFinales("http://www.spk.com.pe")
    ''                a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia")
    ''                a.AnadirLineasDatosFinales("034-005-0010982")

    ''                a.AnadirLineasDatosFinales("")

    ''                'a.AnadirLineasDatosFinales("SIETE (7) DIAS DESPUES DE LA COMPRA")
    ''                'a.AnadirLineasDatosFinales("PRESENTAR TICKET ORIGINAL")
    ''                'a.AnadirLineasDatosFinales("maych_1@hotmail.com")
    ''                'a.AnadirLineasDatosFinales("TELEFONO DE ATENCION AL CLIENTE")
    ''                'a.AnadirLineasDatosFinales("(01)-12345678")
    ''                a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA")

    ''                'a.AnadirLineaSubcabeza("Boleta electronica    N° " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
    ''            ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
    ''                a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA   N° " & CStr(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, "0"c) & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
    ''                a.tipoComprobante = 1
    ''                a.AnadirLineaComprobante("BOLETA")
    ''                a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
    ''                'a.AnadirLineaSubcabeza("Boleta de venta    N° " & CStr(comprobante.serieVenta).PadLeft(3, "0"c) & "-" & comprobante.numeroVenta)
    ''            End If
    ''        Case "01"
    ''            If (documentoBE.documentoventaAbarrotes.tipoVenta = "VELC") Then
    ''                a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA ELECTRONICA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
    ''                a.tipoComprobante = 2
    ''                a.AnadirLineaComprobante("FACTURA ELECTRONICA")
    ''                a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c))

    ''                Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = documentoBE.documentoventaAbarrotes.usuarioActualizacion).FirstOrDefault

    ''                If Not IsNothing(consultaNombre) Then
    ''                    a.AnadirLineasDatosFinales("VENDEDOR: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)
    ''                Else
    ''                    a.AnadirLineasDatosFinales("VENDEDOR: " & "VARIOS")
    ''                End If

    ''                a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE")
    ''                a.AnadirLineasDatosFinales("VENTA ELECTRONICA")
    ''                a.AnadirLineasDatosFinales("http://www.spk.com.pe")
    ''                a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia")
    ''                a.AnadirLineasDatosFinales("034-005-0010982")

    ''                a.AnadirLineasDatosFinales("")

    ''                'a.AnadirLineasDatosFinales("CUALQUIER CAMBIO O DEVOLUCION SERA HASTA")
    ''                'a.AnadirLineasDatosFinales("SIETE (7) DIAS DESPUES DE LA COMPRA")
    ''                'a.AnadirLineasDatosFinales("PRESENTAR TICKET ORIGINAL")
    ''                'a.AnadirLineasDatosFinales("maych_1@hotmail.com")
    ''                'a.AnadirLineasDatosFinales("TELEFONO DE ATENCION AL CLIENTE")
    ''                'a.AnadirLineasDatosFinales("(01)-12345678")
    ''                a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA")


    ''                'a.AnadirLineaSubcabeza("Factura electronica    N° " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
    ''            ElseIf (documentoBE.documentoventaAbarrotes.tipoVenta = "VPOS") Then
    ''                a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA   N° " & CStr(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, "0"c) & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
    ''                a.tipoComprobante = 1
    ''                a.AnadirLineaComprobante("FACTURA")
    ''                a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
    ''                'a.AnadirLineaSubcabeza("Fartura    N° " & CStr(comprobante.serieVenta).PadLeft(3, "0"c) & "-" & comprobante.numeroVenta)
    ''            End If
    ''        Case "9901"
    ''            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "PROFORMA   N° " & 0, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
    ''            a.AnadirLineaComprobante("PROFORMA")
    ''            a.AnadirLineaComprobante(0 & "-" & 0)
    ''            a.tipoComprobante = 1
    ''        Case "07"

    ''            Dim tipoEmision As String = String.Empty

    ''            'Select Case comprobante.estadoCobro
    ''            '    Case "DC"
    ''            '        tipoVenta = "CONTADO"
    ''            '    Case "PN"
    ''            '        tipoVenta = "CREDITO"
    ''            'End Select

    ''            Select Case documentoBE.documentoventaAbarrotes.notaCredito
    ''                Case "01"
    ''                    tipoEmision = "Anulación de la Operación"
    ''                Case "02"
    ''                    tipoEmision = "Anulación por error en el RUC"
    ''                Case "03"
    ''                    tipoEmision = "Anulación por error en la descripción"
    ''                Case "04"
    ''                    tipoEmision = "Descuento global"
    ''                Case "05"
    ''                    tipoEmision = "Descuento por item"
    ''                Case "06"
    ''                    tipoEmision = "devolución total"
    ''                Case "07"
    ''                    tipoEmision = "devolución por item"
    ''                Case "08"
    ''                    tipoEmision = "Bonificación"
    ''                Case "09"
    ''                    tipoEmision = "disminución en el valor"
    ''                Case "10"
    ''                    tipoEmision = "Otros conceptos"
    ''                Case "11"
    ''                    tipoEmision = "Ajustes de Operaciones de exportación"
    ''            End Select

    ''            Dim NombreComprobante As String = String.Empty
    ''            Select Case documentoBE.documentoventaAbarrotes.TipoDocNota
    ''                Case "01"
    ''                    NombreComprobante = "FACTURA ELECTRONICA"
    ''                Case "02"
    ''                    NombreComprobante = "BOLETA ELECTRONICA"
    ''            End Select

    ''            'Dim numeroafect As String = String.Format("{0:00000000}", comprobante.numeroDoc)

    ''            a.AnadirLineaCaracteresDatosGEnerales(documentoBE.documentoventaAbarrotes.fechaDoc,
    ''                                                                  "",
    ''                                                                  nombreCliente,
    ''                                                                  DIRECCIONclIENTE,
    ''                                                                  documentoBE.documentoventaAbarrotes.fechaDoc,
    ''                                                                  rucCliente,
    ''                                                                  "NAC",
    ''                                                                 tipoEmision)
    ''            a.tipoComprobante = 2
    ''            a.AnadirLineaComprobante("NOTA DE CREDITO ELECTRONICA")
    ''            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & CStr(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, "0"c))

    ''            Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = documentoBE.documentoventaAbarrotes.usuarioActualizacion).FirstOrDefault

    ''            If Not IsNothing(consultaNombre) Then
    ''                a.AnadirLineasDatosFinales("VENDEDOR: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)
    ''            Else
    ''                a.AnadirLineasDatosFinales("VENDEDOR: " & "VARIOS")
    ''            End If
    ''            a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE")
    ''            a.AnadirLineasDatosFinales("VENTA ELECTRONICA")
    ''            a.AnadirLineasDatosFinales("http://www.spk.com.pe")
    ''            a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia")
    ''            a.AnadirLineasDatosFinales("034-005-0010982")
    ''            a.AnadirLineasDatosFinales("")
    ''            a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA")
    ''        Case Else
    ''            a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET NOTA   N° " & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
    ''            a.tipoComprobante = 1
    ''            a.AnadirLineaComprobante("NOTA")
    ''            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta)
    ''            'a.AnadirLineaSubcabeza("Ticket nota    N° " & comprobante.numeroVenta)
    ''    End Select
    ''    a.AnadirLineaComprobanteExtra(nombremesa)
    ''    For Each i In documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList

    ''        Select Case i.destino
    ''            Case OperacionGravada.Grabado
    ''                gravMN += CDec(i.montokardex)
    ''                gravME += CDec(i.montokardexUS)

    ''            Case OperacionGravada.Exonerado
    ''                ExoMN += CDec(i.montokardex)
    ''                ExoME += CDec(i.montokardexUS)

    ''            Case OperacionGravada.Inafecto
    ''                InaMN += CDec(i.montokardex)
    ''                InaME += CDec(i.montokardexUS)
    ''        End Select

    ''        precioUnit = (Math.Round(CDbl(i.importeMN / i.monto1), 2))
    ''        PrecioTotal = i.importeMN

    ''        If (Not IsNothing(i.CustomEquivalencia)) Then
    ''            a.AnadirLineaElementosFactura(i.monto1, $"{i.nombreItem} {i.detalleAdicional} ({i.CustomEquivalencia.unidadComercial})", i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", i.descuentoMN.GetValueOrDefault), String.Format("{0:0.00}", PrecioTotal))
    ''        Else
    ''            a.AnadirLineaElementosFactura(i.monto1, $"{i.nombreItem} {i.detalleAdicional}", i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", i.descuentoMN.GetValueOrDefault), String.Format("{0:0.00}", PrecioTotal))
    ''        End If

    ''        'a.AnadirElemento(i.monto1, i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal), i.nombreItem)
    ''        'a.AnadirNombreElemento(i.nombreItem)
    ''        importeTotalMN += i.importeMN
    ''    Next

    ''    a.AnadirDatosGenerales("S/", ExoMN)
    ''    a.AnadirDatosGenerales("S/", InaMN)
    ''    a.AnadirDatosGenerales("S/", gravMN)
    ''    a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.igv01.GetValueOrDefault)
    ''    a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.icbper.GetValueOrDefault)
    ''    a.AnadirDatosGenerales("S/", String.Format("{0:0.00}", documentoBE.documentoventaAbarrotes.ImporteNacional.GetValueOrDefault))

    ''    'a.AnadirDatosGenerales("S/",  )
    ''    'a.AnadirDatosGenerales("S/", )

    ''    a.AnadirLineasDatosDescripcionTotal(documentoBE.documentoventaAbarrotes.ImporteNacional)

    ''    If (Not IsNothing(documentoBE.ListaCustomDocumento)) Then
    ''        For Each item In documentoBE.ListaCustomDocumento.ToList
    ''            a.AnadirLineasDescuento(item.documentoCaja.formaPagoName & ": " & item.documentoCaja.montoSoles)
    ''            importeSumMN += item.documentoCaja.montoSoles
    ''        Next

    ''        a.AnadirLineasDescuento("PENDIENTE: " & importeTotalMN - importeSumMN)

    ''    Else
    ''        For Each item In listaDocumento
    ''            Dim formasPago = Helios.General.TablasGenerales.GetFormasDePago()
    ''            Dim formaSel = formasPago.Where(Function(o) o.codigoDetalle = item.sustentado).SingleOrDefault

    ''            'a.AnadirLineasDescuento(item.NombreEntidad & ": " & item.ImporteNacional & "     " & " N°" & item.NroDocEntidad & "  OPER." & item.numeroVenta)
    ''            a.AnadirLineasDescuento(formaSel.descripcion & ": " & item.ImporteNacional)
    ''            importeSumMN += item.ImporteNacional

    ''        Next

    ''        a.AnadirLineasDescuento("PENDIENTE: " & importeTotalMN - importeSumMN)
    ''    End If

    ''    a.headerImagenQR = QrCodeImgControl1.Image

    ''    'a.AnadirLineaDatos("Vendedor: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno, "Representacion impresa del comprobante", "http://www.spk.com.pe")
    ''    '//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
    ''    '//parametro de tipo string que debe de ser el nombre de la impresora. 
    ''    a.ImprimeTicket(imprimir, txtNroImpresion.DecimalValue)

    ''End Sub




    Public Function ListaPagosCajas(venta As documentoventaTransporte, envio As EnvioImpresionVendedorPernos) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)

        Dim CuentasPago As New estadosFinancierosConfiguracionPagos

        CuentasPago = (listaCuentas.Where(Function(o) o.tipo = 109)).FirstOrDefault


        'For Each i In dgvCuentas.Table.Records
        'If Decimal.Parse(i.GetValue("abonado")) > 0 Then
        nDocumentoCaja = New documento
        nDocumentoCaja.idDocumento = CInt(Me.Tag)
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
        nDocumentoCaja.tipoDoc = venta.tipoDocumento ' cbotipoDocPago.SelectedValue
        nDocumentoCaja.fechaProceso = txtFecha.Value
        nDocumentoCaja.nroDoc = GConfiguracion.Serie
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")

        nDocumentoCaja.idEntidad = venta.idPersona
        nDocumentoCaja.entidad = venta.comprador
        nDocumentoCaja.nrodocEntidad = TextNumIdent.Text

        nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario  ' usuario.IDUsuario
        nDocumentoCaja.fechaActualizacion = DateTime.Now


        'DOCUMENTO CAJA
        objCaja = New documentoCaja
        objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
        objCaja.idDocumento = 0
        objCaja.periodo = GetPeriodo(venta.fechadoc, True)
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
        objCaja.fechaProceso = txtFecha.Value
        objCaja.fechaCobro = txtFecha.Value
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO

        objCaja.codigoProveedor = venta.idPersona
        objCaja.IdProveedor = venta.idPersona
        objCaja.idPersonal = venta.idPersona

        objCaja.TipoDocumentoPago = venta.tipoDocumento 'cbotipoDocPago.SelectedValue
        objCaja.codigoLibro = "1"
        objCaja.tipoDocPago = venta.tipoDocumento
        objCaja.formapago = CuentasPago.IDFormaPago
        objCaja.NumeroDocumento = "-"
        Dim numeroop = "-"

        If numeroop.ToString.Trim.Length > 0 Then
            objCaja.numeroOperacion = "-"
        End If


        If CuentasPago.IDFormaPago = "006" Or CuentasPago.IDFormaPago = "007" Then
            objCaja.estadopago = 1

        End If
        objCaja.movimientoCaja = TIPO_VENTA.VENTA_PASAJES
        objCaja.montoSoles = Decimal.Parse(txtTotalPagar.Text)

        objCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
        objCaja.tipoCambio = TmpTipoCambio
        objCaja.montoUsd = Decimal.Parse(objCaja.montoSoles / TmpTipoCambio)

        objCaja.estado = "1"
        objCaja.glosa = "Por ventas de pasajes"
        objCaja.entregado = "SI"

        objCaja.entidadFinanciera = CuentasPago.identidad
        objCaja.NombreEntidad = CuentasPago.entidad
        objCaja.idCajaUsuario = envio.IDCaja 'GFichaUsuarios.IdCajaUsuario
        objCaja.usuarioModificacion = envio.IDCaja 'usuario.IDUsuario


        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja
        nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja, venta, envio)
        ' asientoDocumento(nDocumentoCaja.documentoCaja)
        ListaDoc.Add(nDocumentoCaja)
        'End If
        'Next

        Return ListaDoc
    End Function

    Private Function GetDetallePago(objCaja As documentoCaja, i As documentoventaTransporte, envio As EnvioImpresionVendedorPernos) As List(Of documentoCajaDetalle)

        Dim montoPago = objCaja.montoSoles
        GetDetallePago = New List(Of documentoCajaDetalle)
        GetDetallePago.Add(New documentoCajaDetalle With
                               {
                               .fecha = Date.Now,
                               .codigoLote = 0,
                               .otroMN = 0,
                               .idItem = i.numeroAsiento,
                               .DetalleItem = "VENTA PASAJE",
                               .montoSoles = i.total,
                               .montoUsd = FormatNumber(i.total / TmpTipoCambio, 2),
                               .diferTipoCambio = TmpTipoCambio,
                               .tipoCambioTransacc = TmpTipoCambio,
                               .entregado = "SI",
                               .idCajaUsuario = envio.IDCaja,
                               .usuarioModificacion = envio.IDCaja,' usuario.IDUsuario,
                               .documentoAfectado = CInt(Me.Tag),
                               .documentoAfectadodetalle = 0,
                               .EstadoCobro = "DC",
                               .fechaModificacion = DateTime.Now
                               })

    End Function

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            If BackgroundWorker1.CancellationPending Then
                ' MessageBox.Show("Up to here? ...")
                e.Cancel = True
            Else
                Dim strIdModulo As String = Nothing
                If cboTipoDoc.Text = "BOLETA" Then
                    strIdModulo = "VT2"
                ElseIf cboTipoDoc.Text = "FACTURA" Then
                    strIdModulo = "VT3"
                ElseIf cboTipoDoc.Text = "BOLETA ELECTRONICA" Then
                    strIdModulo = "VT2E"
                ElseIf cboTipoDoc.Text = "FACTURA ELECTRONICA" Then
                    strIdModulo = "VT3E"
                ElseIf cboTipoDoc.Text = "PROFORMA" Then
                    strIdModulo = "COTIZACION"
                End If
                Dim strIDEmpresa = General.Gempresas.IdEmpresaRuc
                configuracionModuloV2(strIDEmpresa, strIdModulo, "", GEstableciento.IdEstablecimiento)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub FormCrearVentaTransporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtConfirmarVenta.Select()
        BtConfirmarVenta.Focus()
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub BtConfirmarVenta_Click(sender As Object, e As EventArgs) Handles BtConfirmarVenta.Click
        Dim cajaUsuaroSA As New cajaUsuarioSA
        Dim entidadSA As New EstadosFinancierosSA
        Dim envio As EnvioImpresionVendedorPernos = Nothing
        Try
            'cargarCajas()

            Select Case cboTipoDoc.Text
                Case "FACTURA", "FACTURA ELECTRONICA"
                    Dim objeto As Boolean = ValidationRUC(TextRuc.Text.Trim)
                    If objeto = False Then
                        MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                Case "BOLETA ELECTRONICA", "BOLETA"
                    Dim rsp = validarDNI(TextNumIdent.Text.Trim)
                    If rsp = False Then
                        MessageBox.Show("Debe Ingresar un número correcto de DNI", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
            End Select


            'Dim codigoVendedor = TextCodigoVendedor.Text.Trim
            'Dim usuarioSel = UsuariosList.Where(Function(o) o.codigo = codigoVendedor).FirstOrDefault

            'If usuarioSel IsNot Nothing Then
            'Dim cajaUsuario = cajaUsuaroSA.UbicarCajaUsuarioPorID(ComboCaja.SelectedValue)

            '   Dim ef = entidadSA.GetUbicar_estadosFinancierosPorID(cajaUsuario.idCajaOrigen)

            envio = New EnvioImpresionVendedorPernos With
                    {
                    .CodigoVendedor = 11,
                    .IDCaja = ListaCajasActivas.Where(Function(O) O.idPersona = usuario.IDUsuario).FirstOrDefault.idcajaUsuario,
                    .IDVendedor = usuario.IDUsuario,
                    .print = True,
                    .Nombreprint = String.Empty,
                    .NombreCajero = ListaCajasActivas.Where(Function(O) O.idPersona = usuario.IDUsuario).FirstOrDefault.NombrePersona,
                    .EntidadFinanciera = 0,'ef.idestado,
                    .EntidadFinancieraName = String.Empty
                }

            If ValidarGrabado() = True Then
                txtFecha.Value = Date.Now

                'If Not chCredito.Checked = True Then
                '    Dim pagos As Decimal = SumaPagos()

                '    If pagos <= 0 Then
                '        MessageBox.Show("Debe ingresar un pago mayor a cero!", "Pagar venta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                '        'objPleaseWait.Close()
                '        Exit Sub
                '    End If

                '    If pagos > 0 AndAlso pagos < txtTotalPagar.DecimalValue Then
                '        If MessageBox.Show("Está realizando una cobranza parcial, Desea Continuar?", "Pagar venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                '            '   objPleaseWait.Close()
                '            Exit Sub
                '        End If
                '    End If
                'End If

                'objPleaseWait = New FeedbackForm()
                'objPleaseWait.StartPosition = FormStartPosition.CenterScreen
                'objPleaseWait.Show()

                Select Case tipoManipulacion
                    Case "VENTA"
                        GrabarVentaPasaje(envio)
                    Case "RESERVACION"
                        GrabarVentaPasajeReservacion(envio)
                End Select

            End If


            'Else
            '    MessageBox.Show("Ingrese un código valido", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    TextCodigoVendedor.Select()
            'End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Close()
    End Sub

    Sub ImprimirTicket(imprimir As String, intIdDocumento As Integer, formato As String, LLAMARENTIDAD As entidad, LLAMARTRANSPORTE As documentoventaTransporte)

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
                      "|" & HASH & "|")

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



            Case "01"



                a.AnadirLineaCaracteresDatosGEnerales(CDate(DOCUMENTOTransBE.fechaProgramada.Value).Date,
                        DOCUMENTOTransBE.ciudadOrigen,
                        "GENERAL",
                        CDate(DOCUMENTOTransBE.fechaProgramada.Value).ToLongTimeString,
                        DOCUMENTOTransBE.numeroAsiento,
                        DOCUMENTOTransBE.UbigeoCiudadOrigen & "-" & DOCUMENTOTransBE.UbigeoCiudadDestino,
                        DOCUMENTOTransBE.UbigeoCiudadOrigen,
                        DOCUMENTOTransBE.comprador,
                        LLAMARENTIDAD.nrodoc,
                        DOCUMENTOTransBE.ciudadDestino,
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


        End Select

        'a.AnadirLineaComprobanteExtra("ASIENTO N° " & DOCUMENTOTransBE.numeroAsiento)

        precioUnit = DOCUMENTOTransBE.total
        PrecioTotal = DOCUMENTOTransBE.total


        a.AnadirLineaElementosFactura(1, $"{descripcion}", "UND", String.Format("{0:0.00}", DOCUMENTOTransBE.total), String.Format("{0:0.00}", 0.0), String.Format("{0:0.00}", DOCUMENTOTransBE.total))

        If (destino = "1") Then
            a.AnadirDatosGenerales("S/", DOCUMENTOTransBE.baseImponible1)
            a.AnadirDatosGenerales("S/", DOCUMENTOTransBE.igv1)
            a.AnadirDatosGenerales("S/", String.Format("{0:0.00}", DOCUMENTOTransBE.total))
            a.DESTINO = 1
        ElseIf (destino = "2") Then
            a.AnadirDatosGenerales("S/", DOCUMENTOTransBE.total)
            a.AnadirDatosGenerales("S/", String.Format("{0:0.00}", DOCUMENTOTransBE.total))
            a.DESTINO = 2
        End If

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
        a.ImprimeTicket(imprimir, txtNroImpresion.DecimalValue)

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

#End Region

End Class