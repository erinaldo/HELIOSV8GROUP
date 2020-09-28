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

Public Class TabRC_Cliente

    Private Property SelRazon As entidad
    Private Property entidadSA As New entidadSA
    Public Property FormPurchase As Tab_RecepcionControl

    Public Property TabRC_RecepcionHuesped As TabRC_RecepcionHuesped

    Public Property listaInfraestructura As List(Of distribucionInfraestructura)
    Public Property cliente As entidad

    Public Property listaOcupacionInfra As List(Of ocupacionInfraestructura)
    Public Property listaHospedados As New List(Of personaBeneficio)

    Public Property Infraestructura As distribucionInfraestructura

    Public Property listaInfra As New List(Of distribucionInfraestructura)

    Dim ImporteUnit As Decimal = 0
    Dim importeTotal As Decimal = 0
    Public Property listaid As New List(Of String)
    Dim IDDocumento As Integer = 0
    Dim LISTAiDdISTRIBUCION As New List(Of String)
    Public Property DocumentoVentaSA As New documentoVentaAbarrotesSA

    Public Sub New(formRepPiscina As Tab_RecepcionControl)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'FormPurchase = formRepPiscina
        'TabRC_RecepcionHuesped = New TabRC_RecepcionHuesped(Me)
        'TabRC_RecepcionHuesped.Dock = DockStyle.Fill
        'pnBody.Controls.Add(TabRC_RecepcionHuesped)
        'TabRC_RecepcionHuesped.Visible = False
        ''pnBody.Visible = False
        'pnPrincipal.Visible = True
    End Sub

#Region "Metodos"

    Public Sub GetCargarFechas()
        monthCalendarAdv1.MinValue = DateTime.Today
        MonthCalendarAdv2.Value = DateAdd(DateInterval.Day, 1, monthCalendarAdv1.Value)
        MonthCalendarAdv2.MinValue = DateAdd(DateInterval.Day, 1, monthCalendarAdv1.Value)
        txtdias.Text = 1

        Me.textBox1.Text = Me.monthCalendarAdv1.Value.ToLongDateString()
        Me.TextBox2.Text = Me.MonthCalendarAdv2.Value.ToLongDateString()
    End Sub

    Private Function GetConsultarDNIReniec(Dni As String) As String
        Dim CLIENTE As New WebClient
        Dim PAGINA As Stream = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" & Dni)
        Dim LECTOR As New StreamReader(PAGINA)
        Dim MIHTML As String = LECTOR.ReadToEnd
        ' Dim array = MIHTML.Split("|")

        Dim nombres = MIHTML.Replace("|", Space(1))
        Return Trim(nombres)
    End Function

    Private Sub GetConsultaSunatThread(ruc As String)
        SelRazon = New entidad
        Dim nroDoc = ruc.Substring(0, 1).ToString
        If nroDoc = "1" Then

            'getRuc donde ase llama como el company
            Dim sunat As New Helios.Consultas.Sunat.Sunat()
            sunat.GenerateCapchaTemporal()
            Dim valorCapcha = sunat.Decode_CapchaTemporal()
            Dim company As ProcesosJH.DatosRuc = ProcesosJH.ConsultarRUC(ruc, valorCapcha)

            'Dim datosSunat = New Helios.Sunat.Consulta.GetConsultaSunat()
            'Dim company = datosSunat.GetConsultaRuc(ruc)

            '  Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company.Ruc IsNot Nothing Then
                If company.RazonSocial = "ERROR" Then

                Else
                    SelRazon.tipoPersona = "N"
                    SelRazon.tipoDoc = "6"
                    SelRazon.tipoEntidad = "PR"
                    SelRazon.nombreCompleto = company.RazonSocial
                    SelRazon.nombreContacto = company.RazonSocial
                    SelRazon.estado = company.Estado_Contribuyente
                    SelRazon.nrodoc = company.Ruc
                    SelRazon.direccion = company.DireccionDomicilioFiscal
                End If

            Else

            End If
        ElseIf nroDoc = "2" Then
            Dim sunat As New Helios.Consultas.Sunat.Sunat()
            sunat.GenerateCapchaTemporal()
            Dim valorCapcha = sunat.Decode_CapchaTemporal()
            Dim company As ProcesosJH.DatosRuc = ProcesosJH.ConsultarRUC(ruc, valorCapcha)

            'Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company.Ruc IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                If company.RazonSocial = "ERROR" Then

                Else
                    SelRazon.tipoPersona = "J"
                    SelRazon.tipoDoc = "6"
                    SelRazon.tipoEntidad = "PR"
                    SelRazon.nombreCompleto = company.RazonSocial
                    SelRazon.nombreContacto = company.RazonSocial
                    SelRazon.estado = company.Estado_Contribuyente
                    SelRazon.direccion = company.DireccionDomicilioFiscal
                    SelRazon.nrodoc = company.Ruc

                End If
            Else

            End If
        End If
    End Sub

    Private Sub GrabarEntidadRapidaThread()
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
            obEntidad.nombreCompleto = SelRazon.nombreCompleto
            obEntidad.cuentaAsiento = "1213"
            obEntidad.direccion = SelRazon.direccion
            obEntidad.estado = StatusEntidad.Activo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            TextProveedor.Tag = codx
            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = TextNumIdentrazon.Text.Trim
            entidad.nombreCompleto = obEntidad.nombreCompleto
            entidad.tipoDoc = obEntidad.tipoDoc
            Me.Tag = entidad

        Catch ex As Exception
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
    End Sub

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
            obEntidad.nombreCompleto = TextProveedor.Text.Trim
            obEntidad.cuentaAsiento = "1213"
            obEntidad.direccion = SelRazon.direccion
            obEntidad.estado = StatusEntidad.Activo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            TextProveedor.Tag = codx
            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = TextNumIdentrazon.Text.Trim
            entidad.nombreCompleto = obEntidad.nombreCompleto
            entidad.tipoDoc = obEntidad.tipoDoc
            Me.Tag = entidad

        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
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
            TextProveedor.Text = ent.nombreCompleto
            TextProveedor.Tag = ent.idEntidad
        Else
            TextNumIdentrazon.Text = String.Empty
            TextProveedor.Text = String.Empty
            TextProveedor.Tag = Nothing
        End If
    End Sub

    Private Function GetValidarLocalDB(idEntidad As String) As Boolean
        GetValidarLocalDB = False
        Dim entidadSA As New entidadSA

        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", idEntidad)
        If entidad IsNot Nothing Then
            SelRazon = New entidad
            SelRazon = entidad
            TextProveedor.Text = entidad.nombreCompleto
            TextProveedor.Tag = entidad.idEntidad
            textDireccion.Text = entidad.direccion
            GetValidarLocalDB = True

            If TextProveedor.Text.Trim.Length > 0 Then
                'TextFiltrar.Select()
                'TextFiltrar.Focus()
            Else
                TextNumIdentrazon.Clear()
                textDireccion.Clear()
                TextNumIdentrazon.Select()
            End If
        End If
    End Function

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
                TextProveedor.Text = company.RazonSocial
                textDireccion.Text = company.DomicilioFiscal
                SelRazon.nombreContacto = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.nrodoc = company.Ruc
                SelRazon.direccion = company.DomicilioFiscal
                GrabarEntidadRapida()

            Else
                TextProveedor.Clear()
                textDireccion.Clear()

            End If
        ElseIf nroDoc = "2" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                SelRazon.tipoPersona = "J"
                SelRazon.tipoDoc = "6"
                '  End If
                SelRazon.nombreCompleto = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                TextProveedor.Text = company.RazonSocial
                textDireccion.Text = company.DomicilioFiscal
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.direccion = company.DomicilioFiscal
                SelRazon.nrodoc = company.Ruc

                GrabarEntidadRapida()

            Else
                TextProveedor.Clear()
                textDireccion.Clear()

            End If
        End If
        TextNumIdentrazon.ReadOnly = False
    End Sub

    Private Function GetCodigoVendedor() As Helios.Seguridad.Business.Entity.Usuario
        GetCodigoVendedor = Nothing
        Dim f As New FormCodigoVendedor
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim c = CType(f.Tag, Helios.Seguridad.Business.Entity.Usuario)
            GetCodigoVendedor = c
        End If
    End Function

    Private Sub Grabarventa()
        Dim base1 As Decimal = 0
        Dim base1ME As Decimal = 0
        Dim iva1 As Decimal = 0
        Dim iva1ME As Decimal = 0
        Dim totalME As Decimal = 0

        Dim envio As EnvioImpresionVendedorPernos = Nothing
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim obj As New documento
        importeTotal = 0.0
        Try
            obj = MappingDocumento()


            Dim Vendedor = GetCodigoVendedor()
            If Vendedor Is Nothing Then
                Throw New Exception("Debe indicar el codigo del vendedor!")
            End If
            obj.usuarioActualizacion = Vendedor.IDUsuario

            MappingDocumentoCompraCabecera(obj)
            MappingDocumentoCompraCabeceraDetalle(obj)

            Select Case obj.documentoventaAbarrotes.moneda
                Case "1"
                    base1 = Math.Round(CDec(importeTotal / 1.18), 2, MidpointRounding.ToEven)
                    base1ME = Math.Round(CDec(importeTotal / 1.18) * TmpTipoCambio, 2, MidpointRounding.ToEven)
                    iva1 = CDec(importeTotal - base1)
                    iva1ME = Math.Round(iva1 / TmpTipoCambio, 2)
                    totalME = Math.Round(CDec(importeTotal / TmpTipoCambio), 2)
            End Select

            obj.documentoventaAbarrotes.ImporteNacional = importeTotal
            obj.documentoventaAbarrotes.ImporteExtranjero = totalME
            obj.documentoventaAbarrotes.bi01 = base1
            obj.documentoventaAbarrotes.bi01us = base1ME
            obj.documentoventaAbarrotes.igv01 = iva1
            obj.documentoventaAbarrotes.igv01us = iva1ME

            Dim doc = ventaSA.GrabarVentaEquivalenciaXInfraMasivo(obj)
            IDDocumento = doc.idDocumento
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")

        End Try
    End Sub

    Private Function MappingDocumento() As documento
        MappingDocumento = New documento With
        {
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .idProyecto = 0,
        .tipoDoc = "1000",
        .fechaProceso = Date.Now,
        .moneda = 1,
        .idEntidad = TextProveedor.Tag,
        .entidad = TextProveedor.Text,
        .tipoEntidad = TIPO_ENTIDAD.CLIENTE,
        .nrodocEntidad = TextNumIdentrazon.Text,
        .nroDoc = "0",'$"{UCEstructuraCabeceraVentaV2.txtSerie.Text}-{UCEstructuraCabeceraVentaV2.txtNumero.Text}",
        .idOrden = 0,
        .tipoOperacion = StatusTipoOperacion.VENTA,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }

    End Function
    Public Sub limpiarCajas()
        textDireccion.Clear()
        textTelefono.Clear()
        TextNumIdentrazon.Clear()
        TextProveedor.Clear()
        GetCargarFechas()
    End Sub

    Private Sub MappingDocumentoCompraCabecera(be As documento)
        Dim tipoVenta As String = String.Empty
        Dim base1 As Decimal = 0
        Dim base2 As Decimal = 0

        Dim base1ME As Decimal = 0
        Dim base2ME As Decimal = 0

        Dim iva1 As Decimal = 0
        Dim iva1ME As Decimal = 0
        Dim iva2 As Decimal = 0
        Dim total As Decimal = importeTotal
        Dim totalME As Decimal = 0 ' UCEstructuraDocumentocabecera.txtTotalPagar.DecimalValue

        'Select Case be.moneda
        '    Case "1"
        '        base1 = Math.Round(CDec(total / 1.18), 2, MidpointRounding.ToEven)
        '        base2 = 0
        '        base1ME = Math.Round(CDec(total / 1.18) * TmpTipoCambio, 2, MidpointRounding.ToEven)
        '        base2ME = 0
        '        iva1 = CDec(importeTotal - base1)
        '        iva1ME = Math.Round(iva1 / TmpTipoCambio, 2)

        '        totalME = Math.Round(CDec(importeTotal / TmpTipoCambio), 2)

        'End Select


        'Select Case ComboComprobante.Text
        '    Case "VENTA"

        '        tipoVenta = TIPO_VENTA.VENTA_ELECTRONICA
        '    Case "PEDIDO"
        tipoVenta = TIPO_VENTA.VENTA_NOTA_PEDIDO

        '    Case "NOTA DE VENTA"
        '        tipoVenta = TIPO_VENTA.NOTA_DE_VENTA
        '        'Case "OTRA SALIDA DE ALMACEN"
        '        '    tipoVenta = TIPO_COMPRA.OTRAS_SALIDAS
        '        'Case "PROFORMA"
        '        '    tipoVenta = TIPO_VENTA.COTIZACION
        'End Select



        Dim obj As New documentoventaAbarrotes With
        {
        .codigoLibro = "8",
        .idEmpresa = be.idEmpresa,
        .idEstablecimiento = be.idCentroCosto,
        .fechaLaboral = Date.Now,
        .fechaDoc = be.fechaProceso,
        .fechaVcto = Nothing,
        .fechaPeriodo = GetPeriodo(be.fechaProceso, True),
        .tipoDocumento = be.tipoDoc,
        .idCliente = be.idEntidad,
        .nombrePedido = be.entidad,
        .moneda = be.moneda,
        .tasaIgv = 0.18,
        .tipoCambio = TmpTipoCambio,
        .bi01 = base1,
        .bi02 = base2,
        .isc01 = 0,
        .isc02 = 0,
        .igv01 = iva1,
        .igv02 = 0,
        .otc01 = 0,
        .otc02 = 0,
        .bi01us = base1ME,
        .bi02us = base2ME,
        .isc01us = 0,
        .isc02us = 0,
        .igv01us = iva1ME,
        .igv02us = 0,
        .otc01us = 0,
        .otc02us = 0,
        .importeCostoMN = 0,
        .terminos = "CREDITO",
        .ImporteNacional = total,
        .ImporteExtranjero = totalME,
        .tipoVenta = tipoVenta,
        .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
        .glosa = "Salida de mercadería",
        .sustentado = "S",
        .idPadre = 0,
            .estadoEntrega = "1",
        .usuarioActualizacion = be.usuarioActualizacion,' usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }

        be.documentoventaAbarrotes = obj
        be.documentoventaAbarrotes.estadoCobro = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
        be.documentoventaAbarrotes.documentoventaAbarrotesDet = New List(Of documentoventaAbarrotesDet)
    End Sub


    Private Sub MappingDocumentoCompraCabeceraDetalle(obj As documento)
        Dim objDet As documentoventaAbarrotesDet
        Dim precUnitEquivalencia As Decimal = 0
        'Dim listaHospedados As New List(Of personaBeneficio)
        Dim listaOcuapcion As New List(Of ocupacionInfraestructura)
        Dim objOcupacion = New ocupacionInfraestructura
        Dim objpER = New personaBeneficio
        For Each i In listaInfra
            Dim ConsultaOcupacion = (From x In listaOcupacionInfra Where x.idDistribucion = i.idDistribucion).FirstOrDefault

            If (Not IsNothing(ConsultaOcupacion)) Then
                objOcupacion = New ocupacionInfraestructura With
                           {
                          .[idEmpresa] = Gempresas.IdEmpresaRuc,
                          .[idEstablecimiento] = GEstableciento.IdEstablecimiento,
                          .[idDistribucion] = CInt(i.idDistribucion),
                          .[idEntidad] = CInt(TextProveedor.Tag),
                          .[chek_in] = ConsultaOcupacion.chek_in,
                          .[check_on] = ConsultaOcupacion.check_on,
                          .[estado] = "A",
                          .[glosario] = "OCUPADO",
                          .[usuarioActualizacion] = usuario.IDUsuario,
                          .[fechaActualizacion] = Date.Now
                          }
            Else
                objOcupacion = New ocupacionInfraestructura With
                           {
                          .[idEmpresa] = Gempresas.IdEmpresaRuc,
                          .[idEstablecimiento] = GEstableciento.IdEstablecimiento,
                          .[idDistribucion] = CInt(i.idDistribucion),
                          .[idEntidad] = CInt(TextProveedor.Tag),
                          .[chek_in] = monthCalendarAdv1.Value,
                          .[check_on] = MonthCalendarAdv2.Value,
                          .[estado] = "A",
                          .[glosario] = "OCUPADO",
                          .[usuarioActualizacion] = usuario.IDUsuario,
                          .[fechaActualizacion] = Date.Now
                          }
            End If


            Dim ConsultaPer = (From z In listaHospedados Where z.distribucionID = i.idDistribucion).ToList
            Dim listaHospedadosGrabar = New List(Of personaBeneficio)
            For Each ite In ConsultaPer
                objpER = New personaBeneficio With
                                {
                                .[idEmpresa] = Gempresas.IdEmpresaRuc,
                                .[idEstablecimiento] = GEstableciento.IdEstablecimiento,
                                .[idDocumento] = 0,
                                .nroDocumento = ite.nroDocumento,
                                .[idEntidad] = ite.[idEntidad],
                                .[nombrePersona] = ite.[nombrePersona],
                                .[glosario] = ite.[glosario],
                                .nacionalidad = ite.nacionalidad,
                                .sexo = ite.sexo,
                                .[estado] = "A",
                                .idDistribucion = i.idDistribucion,
                                .[usuarioActualizacion] = usuario.IDUsuario,
                                .[fechaActualizacion] = Date.Now
                                }
                listaHospedadosGrabar.Add(objpER)
            Next


            objDet = New documentoventaAbarrotesDet With
                  {
                  .AfectoInventario = True,
                  .CodigoCosto = 1,
                  .CustomProducto = Nothing,
                  .catalogo_id = 0,
                  .idItem = i.idDistribucion,
                  .nombreItem = i.numeracion,
                  .tipoExistencia = "IF",
                  .destino = 1,
                  .unidad1 = "NIU",
                  .monto1 = 1,
                  .equivalencia_id = 0,
                  .unidad2 = Nothing,
                  .monto2 = i.menor.GetValueOrDefault,
                  .precioUnitario = i.menor.GetValueOrDefault,
                  .precioUnitarioUS = i.menor.GetValueOrDefault * TmpTipoCambio,
                  .importeMN = i.menor.GetValueOrDefault,
                  .importeME = 0,
                  .montokardex = Math.Round(CDec(i.menor.GetValueOrDefault / 1.18), 2),
                  .montoIsc = 0,
                  .montoIgv = CDec(i.menor.GetValueOrDefault - Math.Round(CDec(i.menor.GetValueOrDefault / 1.18), 2)),
                  .otrosTributos = 0,
                  .montokardexUS = 0,
                  .montoIscUS = 0,
                  .montoIgvUS = 0,
                  .otrosTributosUS = 0,
                  .entregado = "1",
                  .estadoEntrega = "PN",
                  .estadoPago = "PN",
                  .bonificacion = False,
                  .descuentoMN = 0,
                  .idDistribucion = i.idDistribucion,
                      .estadoDistribucion = "A",
                       .usuarioModificacion = obj.usuarioActualizacion,' usuario.IDUsuario,
                  .fechaModificacion = Date.Now,
                  .ocupacionInfra = objOcupacion,
                                .listaPersonaHospedada = listaHospedadosGrabar
                  }

            objDet.ocupacionInfraestructura.Add(objOcupacion)
            objDet.personaBeneficio = listaHospedadosGrabar
            obj.documentoventaAbarrotes.documentoventaAbarrotesDet.Add(objDet)

            importeTotal += i.menor
            ImporteUnit += i.menor
        Next
    End Sub

    Private Sub TextNumIdentrazon_KeyDown(sender As Object, e As KeyEventArgs) Handles TextNumIdentrazon.KeyDown
        Dim nombres = String.Empty
        Try
            'TextNumIdentrazon.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case TextNumIdentrazon.Text.Trim.Length
                    Case 8 'dni

                        SelRazon = New entidad

                        If My.Computer.Network.IsAvailable = True Then

                            nombres = GetConsultarDNIReniec(TextNumIdentrazon.Text.Trim)

                            If nombres.Trim.Length > 0 Then

                                If nombres = "DNI no encontrado en Padrón Electoral" Then
                                    TextNumIdentrazon.Clear()
                                    TextProveedor.Text = String.Empty
                                    TextProveedor.Tag = Nothing
                                    textDireccion.Text = String.Empty

                                    Exit Sub
                                End If

                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = nombres
                                SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                TextProveedor.Text = nombres

                                Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)

                                If existeEnDB Is Nothing Then
                                    TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    GrabarEntidadRapida()

                                Else
                                    TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    TextProveedor.Tag = existeEnDB.idEntidad

                                End If
                            Else
                                TextNumIdentrazon.Clear()
                                TextProveedor.Text = String.Empty
                                TextProveedor.Tag = Nothing
                            End If

                        Else

                            'CUANDO NO HAY CONEXION A INTERNET
                            Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)
                            If existeEnDB Is Nothing Then
                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = TextProveedor.Text.Trim
                                SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'GrabarEntidadRapida()
                                GrabarEnFormBasico()

                            Else
                                TextProveedor.Text = existeEnDB.nombreCompleto
                                TextProveedor.Tag = existeEnDB.idEntidad
                                TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            End If
                        End If



                    Case 11 'razonSocial

                        Dim objeto As Boolean = ValidationRUC(TextNumIdentrazon.Text.Trim)
                        If objeto = False Then

                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            TextProveedor.Clear()
                            textDireccion.Clear()
                            Exit Sub
                        End If

                        If My.Computer.Network.IsAvailable = True Then
                            'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                            If GetValidarLocalDB(TextNumIdentrazon.Text.Trim) = False Then
                                TextNumIdentrazon.ReadOnly = True

                                Select Case ToggleConsultas.ToggleState
                                    Case ToggleButton2.ToggleButtonState.OFF ' API
                                        GetConsultaSunatAsync(TextNumIdentrazon.Text.Trim)
                                    Case ToggleButton2.ToggleButtonState.ON ' WEB
                                        BgProveedor.RunWorkerAsync()
                                End Select
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

                                    If TextProveedor.Text.Trim.Length > 0 Then
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

                                    If TextProveedor.Text.Trim.Length > 0 Then
                                        'TextFiltrar.Select()
                                        'TextFiltrar.Focus()
                                    Else
                                        TextNumIdentrazon.Clear()
                                        TextNumIdentrazon.Select()
                                        textDireccion.Clear()
                                    End If
                                End If
                            End If
                        End If

                    Case Else
                        TextProveedor.Text = String.Empty
                        textDireccion.Text = String.Empty
                        TextNumIdentrazon.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select

            End If
            '    TextNumIdentrazon.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then

                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
                TextNumIdentrazon.Focus()
                TextProveedor.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BgProveedor_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BgProveedor.DoWork
        GetConsultaSunatThread(TextNumIdentrazon.Text)
    End Sub

    Private Sub BgProveedor_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BgProveedor.RunWorkerCompleted
        If SelRazon.nrodoc IsNot Nothing Then
            SelRazon.tipoEntidad = "CL"
            SelRazon.nombreCompleto = SelRazon.nombreCompleto.ToString.Replace(Chr(34), "")
            GrabarEntidadRapidaThread()
            TextNumIdentrazon.Text = SelRazon.nrodoc
            TextProveedor.Text = SelRazon.nombreCompleto
            textDireccion.Text = SelRazon.direccion
            TextNumIdentrazon.ReadOnly = False
            SelRazon = New entidad

        Else
            TextProveedor.Clear()
            textDireccion.Clear()
            TextProveedor.Tag = Nothing
            TextNumIdentrazon.ReadOnly = False
            SelRazon = New entidad
            TextNumIdentrazon.Select()
        End If

    End Sub

    Private Sub Txtdias_TextChanged(sender As Object, e As EventArgs) Handles txtdias.TextChanged
        Dim nombres = String.Empty
        Try
            If (txtdias.Tag = 1) Then

                If (txtdias.Text.Length > 0) Then
                    If (txtdias.Text <> "0") Then
                        MonthCalendarAdv2.Tag = 1
                        MonthCalendarAdv2.Value = DateAdd(DateInterval.Day, CInt(txtdias.Text), monthCalendarAdv1.Value)
                        MonthCalendarAdv2.Tag = 0
                        Me.textBox1.Text = Me.monthCalendarAdv1.Value.ToLongDateString()
                        Me.TextBox2.Text = Me.MonthCalendarAdv2.Value.ToLongDateString()
                    Else
                        txtdias.Text = 1
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnRetorno_Click(sender As Object, e As EventArgs) Handles btnRetorno.Click
        Try
            If (btnRetorno.Tag = 1) Then
                Dim infraSA As New distribucionInfraestructuraSA

                If (listaInfraestructura.Count <= 0) Then
                    MessageBox.Show("Ingrese un tipo de habitación")
                    Exit Sub
                End If

                Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
                Dim distribucionInfraestructuraBE As New distribucionInfraestructura
                Dim LISTAPreVenta As New List(Of distribucionInfraestructura)
                distribucionInfraestructuraBE.listaEstado = New List(Of String)
                For Each ITEM In listaInfraestructura
                    distribucionInfraestructuraBE = New distribucionInfraestructura
                    distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                    distribucionInfraestructuraBE.idDistribucion = (ITEM.numeracion)
                    distribucionInfraestructuraBE.estado = "U"
                    distribucionInfraestructuraBE.menor = ITEM.menor
                    LISTAPreVenta.Add(distribucionInfraestructuraBE)
                    LISTAiDdISTRIBUCION.Add((ITEM.numeracion))
                Next

                listaInfra = infraSA.updateDistribucionRecepcionMasivo(LISTAPreVenta)
                Grabarventa()

                ToolStripButton1.Tag = 2
                btnRetorno.Tag = 2

                'If MessageBox.Show("¿Desea cobrar", "Pre Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                '    Dim venta = DocumentoVentaSA.GetVentaID(New documento With {.idDocumento = IDDocumento})
                '    Dim f As New FormCajeroIndependiente()
                '    f.LlamarPedido(venta)
                '    f.FormaVenta = 1
                '    f.StartPosition = FormStartPosition.CenterParent
                '    f.ShowDialog()

                '    If f.Tag IsNot Nothing Then
                '        listaHospedados.Clear()
                '        listaInfraestructura.Clear()
                '        listaInfraestructura.Clear()pre vent
                '        LISTAiDdISTRIBUCION.Clear()
                '        listaOcupacionInfra.Clear()
                '    End If

                '    TabRC_RecepcionHuesped.Visible = False
                '    pnPrincipal.Visible = True
                '    pnPrincipal.BringToFront()
                '    ToolStripButton1.Tag = 0
                '    btnRetorno.Tag = 0
                '    btnRetorno.Text = "Siquiente -[F2]"
                '    limpiarCajas()
                'Else
                TabRC_RecepcionHuesped.Visible = False
                pnPrincipal.Visible = True
                pnPrincipal.BringToFront()
                ToolStripButton1.Tag = 0
                btnRetorno.Tag = 0
                btnRetorno.Text = "Siquiente -[F2]"
                limpiarCajas()
                'End If

            ElseIf (btnRetorno.Tag = 0) Then
                Dim conteo As Integer = 0
                If (TextNumIdentrazon.Text.Length <= 0) Then
                    MessageBox.Show("Ingrese un Cliente valido")
                    Exit Sub
                End If

                Dim infraSA As New distribucionInfraestructuraSA
                listaHospedados = New List(Of personaBeneficio)
                listaInfraestructura = New List(Of distribucionInfraestructura)
                listaOcupacionInfra = New List(Of ocupacionInfraestructura)
                listaid = New List(Of String)
                pnPrincipal.Visible = False
                ToolStripButton1.Tag = 1
                btnRetorno.Tag = 1

                Dim estado As String = String.Empty
                estado = "A"
                If TabRC_RecepcionHuesped IsNot Nothing Then
                    TabRC_RecepcionHuesped.IDDocumento = IDDocumento
                    TabRC_RecepcionHuesped.fechainicio = monthCalendarAdv1.Value
                    TabRC_RecepcionHuesped.fechaFin = MonthCalendarAdv2.Value
                    TabRC_RecepcionHuesped.dias = txtdias.Text
                    TabRC_RecepcionHuesped.LLAMARiNFRAESTRUCTURA(listaid, estado)
                    TabRC_RecepcionHuesped.Visible = True
                    TabRC_RecepcionHuesped.BringToFront()
                    TabRC_RecepcionHuesped.Show()
                End If
                btnRetorno.Text = "Confirmar Pedido - [F2]"
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            If (ToolStripButton1.Tag = 1) Then
                If MessageBox.Show("¿Desea salir de la venta?", "Salir de la venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    Dim ventasa As New distribucionInfraestructuraSA
                    Infraestructura = New distribucionInfraestructura

                    Infraestructura.listaEstado = listaid
                    Infraestructura.idEmpresa = Gempresas.IdEmpresaRuc
                    Infraestructura.idEstablecimiento = GEstableciento.IdEstablecimiento
                    Infraestructura.estado = "A"
                    Infraestructura.idInfraestructura = IDDocumento

                    TabRC_RecepcionHuesped.Visible = False
                    pnPrincipal.Visible = True
                    pnPrincipal.BringToFront()
                    ventasa.updateDistribucioRecepciomMasivo(Infraestructura)
                    ToolStripButton1.Tag = 0
                    btnRetorno.Tag = 0
                    btnRetorno.Text = "Siquiente -[F2]"
                End If
            Else
                FormPurchase.TabRC_Cliente.Visible = False
                ToolStripButton1.Tag = 0
                btnRetorno.Tag = 0
                If FormPurchase.TabMG_RecepcionCliente IsNot Nothing Then
                    FormPurchase.TabMG_RecepcionCliente.Visible = True
                    FormPurchase.TabMG_RecepcionCliente.BringToFront()
                    FormPurchase.TabMG_RecepcionCliente.Show()
                End If
                btnRetorno.Text = "Siquiente -[F2]"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Txtdias_Click(sender As Object, e As EventArgs) Handles txtdias.Click
        Try
            txtdias.Tag = 1
            txtdias.Select(0, txtdias.Text.Length)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Txtdias_KeyDown(sender As Object, e As KeyEventArgs) Handles txtdias.KeyDown
        Dim nombres = String.Empty
        Try
            'TextNumIdentrazon.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                MonthCalendarAdv2.Tag = 1
                MonthCalendarAdv2.Value = DateAdd(DateInterval.Day, CInt(txtdias.Text), monthCalendarAdv1.Value)
                MonthCalendarAdv2.Tag = 0
                Me.textBox1.Text = Me.monthCalendarAdv1.Value.ToLongDateString()
                Me.TextBox2.Text = Me.MonthCalendarAdv2.Value.ToLongDateString()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Txtdias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdias.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub MonthCalendarAdv1_DateSelected(sender As Object, e As EventArgs) Handles monthCalendarAdv1.DateSelected
        Try
            Me.MonthCalendarAdv2.MinValue = DateAdd(DateInterval.Day, 1, monthCalendarAdv1.Value)
            MonthCalendarAdv2.Value = DateAdd(DateInterval.Day, 1, monthCalendarAdv1.Value)
            Me.textBox1.Text = Me.monthCalendarAdv1.Value.ToShortDateString()
            Me.TextBox2.Text = Me.MonthCalendarAdv2.Value.ToShortDateString()

            Dim Cant As Integer = 0                         ' Almacenar total de dias 
            Dim Ini As DateTime = monthCalendarAdv1.Value              ' Fecha Inicial
            Dim Fin As DateTime = MonthCalendarAdv2.Value              ' Fecha Final
            Dim diferencia As TimeSpan = Fin.Subtract(Ini)  ' Diferencia entre el rango 
            Dim dic As New Dictionary(Of String, String)    ' Diccionario.

            For i As Integer = 0 To diferencia.TotalDays
                Dim fecha As DateTime = Ini.AddDays(i)

                'If Not (fecha.DayOfWeek = DayOfWeek.Saturday Or fecha.DayOfWeek = DayOfWeek.Sunday) Then
                Cant = Cant + 1 ' Sumar contador
                ' Uso de diccionario, almacenar nombre del mes (ejemplo: septiembre) y los dias seleccionados del mismo (ejemplo: 04, 05, 06, 07, 10, 11)
                Dim currentValueA As String = If(dic.ContainsKey(MonthName(fecha.Month)), dic.Item(MonthName(fecha.Month)), "")
                If dic.ContainsKey(MonthName(fecha.Month)) Then
                    dic.Item(MonthName(fecha.Month)) = currentValueA & ", " & fecha.ToString("dd")
                Else
                    ' Agregar en el dicionario los valores.
                    dic.Add(MonthName(fecha.Month), currentValueA & " " & fecha.ToString("dd"))
                End If
                'End If
            Next

            txtdias.Text = Cant - 1

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub MonthCalendarAdv2_DateSelected(sender As Object, e As EventArgs) Handles MonthCalendarAdv2.DateSelected
        Try

            Dim Cant As Integer = 0                         ' Almacenar total de dias 
            Dim Ini As DateTime = monthCalendarAdv1.Value              ' Fecha Inicial
            Dim Fin As DateTime = MonthCalendarAdv2.Value              ' Fecha Final
            Dim diferencia As TimeSpan = Fin.Subtract(Ini)  ' Diferencia entre el rango 
            Dim dic As New Dictionary(Of String, String)    ' Diccionario.

            For i As Integer = 0 To diferencia.TotalDays
                Dim fecha As DateTime = Ini.AddDays(i)

                'If Not (fecha.DayOfWeek = DayOfWeek.Saturday Or fecha.DayOfWeek = DayOfWeek.Sunday) Then
                Cant = Cant + 1 ' Sumar contador
                ' Uso de diccionario, almacenar nombre del mes (ejemplo: septiembre) y los dias seleccionados del mismo (ejemplo: 04, 05, 06, 07, 10, 11)
                Dim currentValueA As String = If(dic.ContainsKey(MonthName(fecha.Month)), dic.Item(MonthName(fecha.Month)), "")
                If dic.ContainsKey(MonthName(fecha.Month)) Then
                    dic.Item(MonthName(fecha.Month)) = currentValueA & ", " & fecha.ToString("dd")
                Else
                    ' Agregar en el dicionario los valores.
                    dic.Add(MonthName(fecha.Month), currentValueA & " " & fecha.ToString("dd"))
                End If
                'End If
            Next

            txtdias.Text = Cant - 1

            MonthCalendarAdv2.Value = DateAdd(DateInterval.Day, CInt(txtdias.Text), monthCalendarAdv1.Value)
            Me.TextBox2.Text = Me.MonthCalendarAdv2.Value.ToLongDateString()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region


End Class
