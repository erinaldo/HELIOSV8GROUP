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
Imports Syncfusion.Windows.Forms.Grid
Imports System.Runtime.Serialization
Imports Syncfusion.Drawing

Public Class UCVentas

#Region "Attributes"
    Dim filter As New GridExcelFilter()
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Dim entidadSA As New entidadSA
    Dim documentoventaabarrotessa As New documentoVentaAbarrotesSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgPedidos, True, False, 9.0F, SelectionMode.MultiExtended)
        OrdenamientoGrid(dgPedidos, False)
        txtFecha.Value = Date.Now

        BunifuFlatButton8.Enabled = True

        dgPedidos.TableModel.CellModels.Add("LinkLabelCell", New LinkLabelCellModel(dgPedidos.TableModel))
        dgPedidos.GridGroupDropArea.DragColumnHeaderText = "Arrastre un encabezado de columna aquí para agrupar por esa columna."

        AddHandler dgPedidos.TableModel.QueryRowHeight, AddressOf TableModel_QueryRowHeight

    End Sub
#End Region

#Region "Methods"

    Private Sub TableModel_QueryRowHeight(ByVal sender As Object, ByVal e As GridRowColSizeEventArgs)
        If e.Index > 0 Then
            Dim graphicsProvider As IGraphicsProvider = Me.dgPedidos.TableModel.GetGraphicsProvider()
            Dim g As Graphics = graphicsProvider.Graphics
            Dim style As GridStyleInfo = Me.dgPedidos.TableModel(e.Index, 8)
            Dim model As GridCellModelBase = style.CellModel
            e.Size = model.CalculatePreferredCellSize(g, e.Index, 8, style, GridQueryBounds.Height).Height
            e.Handled = True
        End If
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

    Public Sub EnviarNotaBoletaEliminada(item As documentoventaAbarrotes)
        Try
            'GetNumeracion("RSD", Gempresas.IdEmpresaRuc)

            Dim numeracionsa As New NumeracionBoletaSA
            Dim entidadSA As New entidadSA
            Dim documentoSA As New documentoVentaAbarrotesSA
            'Dim numerobaja = numeracionsa.GenerarNumeroBaja(GConfiguracion2.ConfigComprobante)
            Dim numerobaja = numeracionsa.GenerarNumeroXTipo(GEstableciento.IdEstablecimiento, "RSD", "03")
            Dim numer As String = String.Format("{0:00000}", CInt(numerobaja))

            'Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(item.idDocumento)
            Dim comprobante = documentoSA.GetUbicar_NotaXID(item.idDocumento)


            Dim numerobol = String.Format("{0:00000000}", CInt(comprobante.numeroVenta))
            Dim receptor = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, comprobante.idCliente)

            Dim objeto As Helios.Fact.Sunat.Business.Entity.DocumentoResumenDetalle
            Dim Resumen = New Helios.Fact.Sunat.Business.Entity.DocumentoResumen
            'CABEZERA
            Resumen.Action = 0
            Resumen.idEmpresa = Gempresas.ubigeo
            Resumen.Contribuyente_id = Gempresas.IdEmpresaRuc
            Resumen.IdDocumento = String.Format("RC-{0:yyyyMMdd}-" & numer, DateTime.Today)
            Resumen.FechaEmision = DateTime.Now
            Resumen.FechaReferencia = comprobante.fechaDoc
            Resumen.FechaRecepcion = DateTime.Now
            Resumen.EnvioSunat = "NO"
            Resumen.TipoResumen = "AN"
            'DETALLE
            objeto = New Helios.Fact.Sunat.Business.Entity.DocumentoResumenDetalle
            objeto.idSecuencia = 1
            objeto.TipoDocumento = comprobante.tipoDocumento
            objeto.IdDocumento = comprobante.serieVenta & "-" & numerobol
            objeto.NroDocumentoReceptor = receptor.nrodoc
            objeto.TipoDocumentoReceptor = receptor.tipoDoc
            objeto.CodigoEstadoItem = 3 'CInt(i.GetValue("estado"))

            If comprobante.moneda = "1" Then
                objeto.Moneda = "PEN"
            ElseIf comprobante.moneda = "2" Then
                objeto.Moneda = "USD"
            End If

            objeto.TotalVenta = comprobante.ImporteNacional
            objeto.TotalIgv = comprobante.igv01
            objeto.Gravadas = comprobante.bi01
            objeto.Exoneradas = comprobante.bi02
            objeto.Icbper = comprobante.icbper.GetValueOrDefault



            Dim numeroafect As String = String.Format("{0:00000000}", comprobante.numeroDoc)

            objeto.TipoDocumentoRelacionado = comprobante.TipoDocNota
            objeto.DocumentoRelacionado = comprobante.serie & "-" & numeroafect

            Resumen.DocumentoResumenDetalle.Add(objeto)

            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoResumenSA.DocumentoResumenSaveValidado(Resumen, Nothing)

            If codigo.idResumen > 0 Then

                'ActualizarBoletas(listaActEstado, IIf(IsNothing(conf.ConfigComprobante), 0, conf.ConfigComprobante), "0")

                documentoSA.UpdateAnulacionEnviada(comprobante.idDocumento, numerobaja, 0)

                MessageBox.Show("El Resumen se Envio Correctamente al PSE")

            End If

        Catch ex As Exception

            MessageBox.Show("No se Pudo Enviar")

        End Try
    End Sub
    Public Sub EnviarBoletaEliminada(item As documentoventaAbarrotes)
        Try
            'GetNumeracion("RSD", Gempresas.IdEmpresaRuc)

            Dim numeracionsa As New NumeracionBoletaSA
            Dim entidadSA As New entidadSA
            Dim documentoSA As New documentoVentaAbarrotesSA
            'Dim numerobaja = numeracionsa.GenerarNumeroBaja(GConfiguracion2.ConfigComprobante)
            Dim numerobaja = numeracionsa.GenerarNumeroXTipo(GEstableciento.IdEstablecimiento, "RSD", "03")
            Dim numer As String = String.Format("{0:00000}", CInt(numerobaja))

            Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(item.idDocumento)

            Dim numerobol = String.Format("{0:00000000}", CInt(comprobante.numeroVenta))
            Dim receptor = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, comprobante.idCliente)

            Dim objeto As Helios.Fact.Sunat.Business.Entity.DocumentoResumenDetalle
            Dim Resumen = New Helios.Fact.Sunat.Business.Entity.DocumentoResumen
            'CABEZERA
            Resumen.Action = 0
            Resumen.idEmpresa = Gempresas.ubigeo
            Resumen.Contribuyente_id = Gempresas.IdEmpresaRuc
            Resumen.IdDocumento = String.Format("RC-{0:yyyyMMdd}-" & numer, DateTime.Today)
            Resumen.FechaEmision = DateTime.Now
            Resumen.FechaReferencia = comprobante.fechaDoc
            Resumen.FechaRecepcion = DateTime.Now
            Resumen.EnvioSunat = "NO"
            Resumen.TipoResumen = "AN"
            'DETALLE
            objeto = New Helios.Fact.Sunat.Business.Entity.DocumentoResumenDetalle
            objeto.idSecuencia = 1
            objeto.TipoDocumento = comprobante.tipoDocumento
            objeto.IdDocumento = comprobante.serieVenta & "-" & numerobol
            objeto.NroDocumentoReceptor = receptor.nrodoc
            objeto.TipoDocumentoReceptor = receptor.tipoDoc
            objeto.CodigoEstadoItem = 3 'CInt(i.GetValue("estado"))

            If comprobante.moneda = "1" Then
                objeto.Moneda = "PEN"
            ElseIf comprobante.moneda = "2" Then
                objeto.Moneda = "USD"
            End If

            objeto.TotalVenta = comprobante.ImporteNacional
            objeto.TotalIgv = comprobante.igv01
            objeto.Gravadas = comprobante.bi01
            objeto.Exoneradas = comprobante.bi02
            objeto.Icbper = comprobante.icbper.GetValueOrDefault

            Resumen.DocumentoResumenDetalle.Add(objeto)

            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoResumenSA.DocumentoResumenSaveValidado(Resumen, Nothing)

            If codigo.idResumen > 0 Then

                'ActualizarBoletas(listaActEstado, IIf(IsNothing(conf.ConfigComprobante), 0, conf.ConfigComprobante), "0")

                documentoSA.UpdateAnulacionEnviada(comprobante.idDocumento, numerobaja, 0)

                MessageBox.Show("El Resumen se Envio Correctamente al PSE")

            End If

        Catch ex As Exception

            MessageBox.Show("No se Pudo Enviar")

        End Try
    End Sub

    Public Sub EnviarComunicacionBaja(objeto As documentoventaAbarrotes)

        Try
            'GetNumeracion("BAJA", Gempresas.IdEmpresaRuc)
            Dim numeracionsa As New NumeracionBoletaSA
            Dim documentoventasa As New documentoVentaAbarrotesSA
            'Dim numerobaja = numeracionsa.GenerarNumeroBaja(GConfiguracion2.ConfigComprobante)
            Dim numerobaja = numeracionsa.GenerarNumeroXTipo(GEstableciento.IdEstablecimiento, "BAJA", "01")
            Dim objetoBaja As Helios.Fact.Sunat.Business.Entity.ComunicacionBajaDetalle

            'CABEZERA
            Dim comunicacion As New Helios.Fact.Sunat.Business.Entity.ComunicacionBaja
            comunicacion.Action = 0
            comunicacion.idEmpresa = Gempresas.ubigeo 'lblIdPse.Text
            comunicacion.IdDocumento = String.Format("RA-{0:yyyyMMdd}-" & numerobaja, DateTime.Today)
            comunicacion.FechaEmision = DateTime.Now
            comunicacion.FechaReferencia = objeto.fechaDoc  'dtpFechaDocs.Value
            comunicacion.FechaRecepcion = DateTime.Now
            comunicacion.EnvioSunat = "NO"
            comunicacion.Contribuyente_id = Gempresas.IdEmpresaRuc
            'DETALLE
            objetoBaja = New Helios.Fact.Sunat.Business.Entity.ComunicacionBajaDetalle
            objetoBaja.Id = 1
            objetoBaja.Serie = objeto.serieVenta ' i.GetValue("serie")
            objetoBaja.Correlativo = String.Format("{0:00000000}", CInt(objeto.numeroVenta))
            objetoBaja.TipoDocumento = objeto.tipoDocumento
            objetoBaja.MotivoBaja = "ANULACION DE LA FACTURA"
            comunicacion.ComunicacionBajaDetalle.Add(objetoBaja)

            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.ComunicacionBajaSA.ComunicacionBajaSaveValidado(comunicacion, Nothing)

            If codigo.idComunicacion > 0 Then
                'ActualizarEnvioSunat("0", objeto)
                documentoventasa.UpdateAnulacionEnviada(objeto.idDocumento, numerobaja, 0)

                MessageBox.Show("La comunicacion se Envio Correctamente al PSE")
            End If
        Catch ex As Exception
            MessageBox.Show("No se Pudo Enviar")
        End Try

    End Sub
    'Public Sub EnviarComunicacionBaja(objeto As documentoventaAbarrotes)

    '    Try
    '        'GetNumeracion("BAJA", Gempresas.IdEmpresaRuc)
    '        Dim numeracionsa As New NumeracionBoletaSA
    '        Dim documentoventasa As New documentoVentaAbarrotesSA
    '        'Dim numerobaja = numeracionsa.GenerarNumeroBaja(GConfiguracion2.ConfigComprobante)
    '        Dim numerobaja = numeracionsa.GenerarNumeroXTipo(GEstableciento.IdEstablecimiento, "BAJA", "01")
    '        Dim objetoBaja As Helios.Fact.Sunat.Business.Entity.ComunicacionBajaDetalle

    '        'CABEZERA
    '        Dim comunicacion As New Helios.Fact.Sunat.Business.Entity.ComunicacionBaja
    '        comunicacion.Action = 0
    '        comunicacion.idEmpresa = Gempresas.ubigeo 'lblIdPse.Text
    '        comunicacion.IdDocumento = String.Format("RA-{0:yyyyMMdd}-" & numerobaja, DateTime.Today)
    '        comunicacion.FechaEmision = DateTime.Now
    '        comunicacion.FechaReferencia = objeto.fechaDoc  'dtpFechaDocs.Value
    '        comunicacion.FechaRecepcion = DateTime.Now
    '        comunicacion.EnvioSunat = "NO"
    '        comunicacion.Contribuyente_id = Gempresas.IdEmpresaRuc
    '        'DETALLE
    '        objetoBaja = New Helios.Fact.Sunat.Business.Entity.ComunicacionBajaDetalle
    '        objetoBaja.Id = 1
    '        objetoBaja.Serie = objeto.serieVenta ' i.GetValue("serie")
    '        objetoBaja.Correlativo = String.Format("{0:00000000}", CInt(objeto.numeroVenta))
    '        objetoBaja.TipoDocumento = objeto.tipoDocumento
    '        objetoBaja.MotivoBaja = "ANULACION DE LA FACTURA"
    '        comunicacion.ComunicacionBajaDetalle.Add(objetoBaja)

    '        Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.ComunicacionBajaSA.ComunicacionBajaSaveValidado(comunicacion, Nothing)

    '        If codigo.idComunicacion > 0 Then
    '            'ActualizarEnvioSunat("0", objeto)
    '            documentoventasa.UpdateAnulacionEnviada(objeto.idDocumento, numerobaja, 0)

    '            MessageBox.Show("La comunicacion se Envio Correctamente al PSE")
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("No se Pudo Enviar")
    '    End Try

    'End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgPedidos.DataSource = table
            PictureLoad.Visible = False
            PictureLoad2.Visible = False
            BunifuFlatButton5.Enabled = True
            BunifuFlatButton3.Enabled = True
        End If
    End Sub

    Private Sub GetListaVentasPorTipoAnulados(period As String, tipo As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas anuladas de - " & period)
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
        dt.Columns.Add(New DataColumn("descuentosGlobal", GetType(Decimal)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasPeriodoXTipoAnulados(GEstableciento.IdEstablecimiento, period, tipo).OrderByDescending(Function(v) v.fechaDoc).ToList
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
            dr(18) = i.importeCostoMN.GetValueOrDefault
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Private Sub GetListaVentasPorTipoAnuladosDia(fechaLab As Date, tipo As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas anuladas día - " & fechaLab)
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
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasPeriodoXTipoAnuladosDia(GEstableciento.IdEstablecimiento, fechaLab, tipo).OrderByDescending(Function(v) v.fechaDoc).ToList
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


    Private Sub GetListaVentasNotas(period As String)
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
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("descuentosGlobal", GetType(Decimal)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasNotasPeriodo(GEstableciento.IdEstablecimiento, period).OrderByDescending(Function(v) v.fechaDoc).ToList
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

            dr(18) = i.fechaDoc
            dr(19) = i.importeCostoMN.GetValueOrDefault

            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub



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
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasPeriodoXTipo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, period, tipo, StatusTipoConsulta.XUNIDAD_ORGANICA).OrderByDescending(Function(v) v.fechaDoc).ToList
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

            dr(18) = i.fechaDoc

            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Private Sub GetListaVentasCliente(period As String, tipo As String, idCliente As Integer, Opcion As String, numeroVenta As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas por - " & Opcion)
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
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))

        Dim str As String
        Dim obj As documentoventaAbarrotes = Nothing
        Select Case Opcion
            Case "CLIENTE"
                obj = New documentoventaAbarrotes With
                {
                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                .fechaPeriodo = period,
                .tipoVenta = tipo,
                .idCliente = idCliente,
                .terminos = Opcion
                }

            Case "COMPROBANTE"
                Dim tipodoc As String
                If ToggleComprobante.ToggleState = ToggleButton2.ToggleButtonState.ON Then 'factura
                    tipodoc = "01"
                Else
                    tipodoc = "03"
                End If

                obj = New documentoventaAbarrotes With
                {
                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                .fechaPeriodo = period,
                .tipoDocumento = tipodoc,
                .tipoVenta = tipo,
                .serieVenta = numeroVenta,
                .numeroVenta = numeroVenta,
                .terminos = Opcion
                }
        End Select

        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetVentasCriterio(obj).OrderByDescending(Function(v) v.fechaDoc).ToList
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

            dr(18) = i.fechaDoc

            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Private Sub GetListaVentasPorDia(fechaLaboral As Date, idEstable As Integer, tipo As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas del día - " & fechaLaboral)
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
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("descuentosGlobal", GetType(Decimal)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasPorDiaEstablecimiento(New documentoventaAbarrotes With {.idEstablecimiento = idEstable, .fechaDoc = fechaLaboral, .tipoVenta = tipo}).OrderByDescending(Function(v) v.fechaDoc).ToList
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
            dr(18) = i.fechaDoc
            dr(19) = i.importeCostoMN.GetValueOrDefault
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Public Sub EliminarPV(intIdDocumento As Integer)
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim objDocumento As New documento
        ' Try
        With objDocumento
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .idDocumento = intIdDocumento
        End With

        documentoSA.EliminarVenta(objDocumento)
        'documentoSA.EliminarVentaGeneralPV(objDocumento)
        'dgPedidos.Table.CurrentRecord.Delete()
        MessageBox.Show("venta anulada!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'lblEstado.Text = "Pedido eliminado!"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)

        'Catch ex As Exception
        'MsgBox(ex.Message)
        ' End Try
    End Sub

    'Public Sub EliminarPV(intIdDocumento As Integer)
    '    Dim documentoSA As New documentoVentaAbarrotesSA
    '    Dim objDocumento As New documento
    '    ' Try
    '    With objDocumento
    '        .idEmpresa = Gempresas.IdEmpresaRuc
    '        .idCentroCosto = GEstableciento.IdEstablecimiento
    '        .idDocumento = intIdDocumento
    '    End With

    '    documentoSA.EliminarVenta(objDocumento)
    '    'documentoSA.EliminarVentaGeneralPV(objDocumento)
    '    dgPedidos.Table.CurrentRecord.Delete()
    '    MessageBox.Show("venta anulada!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    'lblEstado.Text = "Pedido eliminado!"
    '    'PanelError.Visible = True
    '    'Timer1.Enabled = True
    '    'TiempoEjecutar(10)

    '    'Catch ex As Exception
    '    'MsgBox(ex.Message)
    '    ' End Try
    'End Sub

#End Region


#Region "Class LinkLabel"
    Public Class LinkLabelCellModel
        Inherits GridStaticCellModel

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub

        Public Sub New(ByVal grid As GridModel)
            MyBase.New(grid)
        End Sub

        Public Overrides Function CreateRenderer(ByVal control As GridControlBase) As GridCellRendererBase
            Return New LinkLabelCellRenderer(control, Me)
        End Function
    End Class

    Public Class LinkLabelCellRenderer
        Inherits GridStaticCellRenderer

        Private _isMouseDown As Boolean
        Private _drawHotLink As Boolean
        Private _hotColor As Color
        Private _visitedColor As Color
        Private _EXEname As String

        Public Sub New(ByVal grid As GridControlBase, ByVal cellModel As GridCellModelBase)
            MyBase.New(grid, cellModel)
            _isMouseDown = False
            _drawHotLink = False
            _hotColor = Color.Red
            _visitedColor = Color.Purple
            _EXEname = "iexplore.exe"
        End Sub

        Public Property VisitedLinkColor As Color
            Get
                Return _visitedColor
            End Get
            Set(ByVal value As Color)
                _visitedColor = value
            End Set
        End Property

        Public Property ActiveLinkColor As Color
            Get
                Return _hotColor
            End Get
            Set(ByVal value As Color)
                _hotColor = value
            End Set
        End Property

        Public Property EXEname As String
            Get
                Return _EXEname
            End Get
            Set(ByVal value As String)
                _EXEname = value
            End Set
        End Property

        Private Sub DrawLink(ByVal useHotColor As Boolean, ByVal rowIndex As Integer, ByVal colIndex As Integer)
            If useHotColor Then _drawHotLink = True
            Me.Grid.RefreshRange(GridRangeInfo.Cell(rowIndex, colIndex), GridRangeOptions.None)
            _drawHotLink = False
        End Sub

        Protected Overrides Sub OnMouseDown(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseDown(rowIndex, colIndex, e)
            DrawLink(True, rowIndex, colIndex)
            _isMouseDown = True
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseUp(rowIndex, colIndex, e)
            Dim row, col As Integer
            Me.Grid.PointToRowCol(New Point(e.X, e.Y), row, col)

            If row = rowIndex AndAlso col = colIndex Then
                Dim style As GridStyleInfo = Me.Grid.Model(row, col)
                style.TextColor = VisitedLinkColor
            End If

            DrawLink(False, rowIndex, colIndex)
            _isMouseDown = False
        End Sub

        Protected Overrides Sub OnCancelMode(ByVal rowIndex As Integer, ByVal colIndex As Integer)
            MyBase.OnCancelMode(rowIndex, colIndex)
            _isMouseDown = False
            _drawHotLink = False
        End Sub

        Protected Overrides Function OnGetCursor(ByVal rowIndex As Integer, ByVal colIndex As Integer) As System.Windows.Forms.Cursor
            Dim pt As Point = Me.Grid.PointToClient(Cursor.Position)
            Dim row, col As Integer
            Me.Grid.PointToRowCol(pt, row, col)
            Return If((row = rowIndex AndAlso col = colIndex), Cursors.Hand, If((Me._isMouseDown), Cursors.No, MyBase.OnGetCursor(rowIndex, colIndex)))
        End Function

        Protected Overrides Function OnHitTest(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As MouseEventArgs, ByVal controller As IMouseController) As Integer
            If controller IsNot Nothing AndAlso controller.Name = "OleDataSource" Then Return 0
            Return 1
        End Function

        Protected Overrides Sub OnDraw(ByVal g As System.Drawing.Graphics, ByVal clientRectangle As System.Drawing.Rectangle, ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal style As Syncfusion.Windows.Forms.Grid.GridStyleInfo)
            style.Font.Underline = True

            If _drawHotLink Then
                style.TextColor = ActiveLinkColor
            End If

            MyBase.OnDraw(g, clientRectangle, rowIndex, colIndex, style)
        End Sub

        Protected Overrides Sub OnMouseHoverEnter(ByVal rowIndex As Integer, ByVal colIndex As Integer)
            MyBase.OnMouseHoverEnter(rowIndex, colIndex)
            DrawLink(True, rowIndex, colIndex)
        End Sub

        Protected Overrides Sub OnMouseHoverLeave(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As System.EventArgs)
            MyBase.OnMouseHoverLeave(rowIndex, colIndex, e)
            DrawLink(False, rowIndex, colIndex)
        End Sub
    End Class

#End Region

#Region "Events"
    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Dim f As New FormFiltroAvanzadoPeriodo()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim periodoSel = CType(f.Tag, DateTime?)
            PictureLoad.Visible = True
            BunifuFlatButton5.Enabled = False

            Select Case ComboVenta.Text
                Case "VENTAS ELECTRONICAS"
                    'Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorTipo(GetPeriodo(periodoSel, True), TIPO_VENTA.VENTA_ELECTRONICA)))
                    Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasNotas(GetPeriodo(periodoSel, True))))
                    thread.Start()
                Case "VENTAS ANULADAS"
                    Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorTipoAnulados(GetPeriodo(periodoSel, True), TIPO_VENTA.VENTA_ELECTRONICA)))
                    thread.Start()
            End Select


        End If
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click

        Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ELIMINAR__ANULAR_SI_Botón___, AutorizacionRolList) Then
        If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then
            If MessageBox.Show("Desea Eliminar el item seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Select Case Me.dgPedidos.Table.CurrentRecord.GetValue("tipoCompra")
                    Case TIPO_COMPRA.NOTA_CREDITO

                    Case TIPO_COMPRA.NOTA_DEBITO
                    ' 
                    Case TIPO_VENTA.VENTA_NOTA_PEDIDO

                    Case TIPO_VENTA.VENTA_GENERAL

                    Case TIPO_VENTA.VENTA_POS_DIRECTA, TIPO_VENTA.VENTA_AL_TICKET
                            'EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                        '   EliminarPVDirecta(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))


                    Case TIPO_COMPRA.NOTA_CREDITO_ELECTRONICA

                        If My.Computer.Network.IsAvailable = True Then
                            Dim f As New FormAnularVenta(CDate(Me.dgPedidos.Table.CurrentRecord.GetValue("fecha")))
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog(Me)
                            If f.Tag IsNot Nothing Then
                                Dim c = CType(f.Tag, Boolean)
                                If c = True Then 'fecha dentro del rango permitido

                                    Dim objeto As New documentoventaAbarrotes
                                    objeto.idDocumento = CInt(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                                    objeto.tipoDocumento = Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc")
                                    objeto.serieVenta = Me.dgPedidos.Table.CurrentRecord.GetValue("serie")
                                    objeto.numeroVenta = CInt(Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc"))
                                    objeto.fechaDoc = CDate(Me.dgPedidos.Table.CurrentRecord.GetValue("fecha"))

                                    If Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc") = "07" Then
                                        Try
                                            If Gempresas.ubigeo > 0 Then
                                                'If My.Computer.Network.IsAvailable = True Then
                                                If My.Computer.Network.Ping("138.128.171.106") Then

                                                    Try
                                                        EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))

                                                        If dgPedidos.Table.CurrentRecord IsNot Nothing Then
                                                            Dim envio = Me.dgPedidos.Table.CurrentRecord.GetValue("enviosunat")
                                                            If envio.ToString.Trim.Length > 0 Then
                                                                EnviarAnulacionDocumento(objeto)
                                                                dgPedidos.Table.CurrentRecord.Delete()
                                                            End If
                                                        End If

                                                    Catch ex As Exception
                                                        MsgBox(ex.Message)
                                                        'MessageBox.Show("No se pudo eliminar el periodo esta cerrado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                    End Try


                                                Else
                                                    MessageBox.Show("No tiene conexión con el servidor SPK!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End If
                                                'Else
                                                '    MessageBox.Show("No tiene conexión a internet!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                'End If
                                            Else
                                                EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                                            End If
                                            BunifuFlatButton1.Enabled = True
                                        Catch ex As Exception
                                            BunifuFlatButton1.Enabled = True
                                        End Try

                                    End If
                                Else
                                    MessageBox.Show("No puede anular la venta, debe estar dentro del rango de 5 días hábiles!", "Validar fechas", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If
                        Else
                            MessageBox.Show("No tiene conexión a internet!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If



                    Case TIPO_VENTA.VENTA_ELECTRONICA
                        If My.Computer.Network.IsAvailable = True Then
                            Dim f As New FormAnularVenta(CDate(Me.dgPedidos.Table.CurrentRecord.GetValue("fecha")))
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog(Me)
                            If f.Tag IsNot Nothing Then
                                Dim c = CType(f.Tag, Boolean)
                                If c = True Then 'fecha dentro del rango permitido


                                    Dim CantNotasActivas = documentoventaabarrotessa.NotasActivas(CInt(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))

                                    If CantNotasActivas > 0 Then
                                        MessageBox.Show("El documento tiene Notas de Credito Activas!", "Debe Anular las notas de credito", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Cursor = Cursors.Default
                                        Exit Sub
                                    End If


                                    Dim objeto As New documentoventaAbarrotes
                                    objeto.idDocumento = CInt(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                                    objeto.tipoDocumento = Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc")
                                    objeto.serieVenta = Me.dgPedidos.Table.CurrentRecord.GetValue("serie")
                                    objeto.numeroVenta = CInt(Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc"))
                                    objeto.fechaDoc = CDate(Me.dgPedidos.Table.CurrentRecord.GetValue("fecha"))


                                    Try
                                        If Gempresas.ubigeo > 0 Then
                                            'If My.Computer.Network.IsAvailable = True Then
                                            If My.Computer.Network.Ping("138.128.171.106") Then

                                                Try
                                                    EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                                                    'EnviarComunicacionBaja(objeto)

                                                    If dgPedidos.Table.CurrentRecord IsNot Nothing Then
                                                        Dim envio = Me.dgPedidos.Table.CurrentRecord.GetValue("enviosunat")
                                                        If envio.ToString.Trim.Length > 0 Then
                                                            EnviarAnulacionDocumento(objeto)
                                                            dgPedidos.Table.CurrentRecord.Delete()
                                                        End If
                                                    End If
                                                Catch ex As Exception
                                                    MsgBox(ex.Message)
                                                    'MessageBox.Show("No se pudo eliminar el periodo esta cerrado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End Try



                                            Else
                                                MessageBox.Show("No tiene conexión con el servidor SPK!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            End If
                                            'Else
                                            '    MessageBox.Show("No tiene conexión a internet!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            'End If
                                        Else
                                            EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                                        End If
                                        BunifuFlatButton1.Enabled = True
                                    Catch ex As Exception
                                        BunifuFlatButton1.Enabled = True
                                    End Try
                                Else
                                    MessageBox.Show("No puede anular la venta, debe estar dentro del rango de 5 días hábiles!", "Validar fechas", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If
                        Else
                            MessageBox.Show("No tiene conexión a internet!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If

                End Select
            End If
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        'Else
        'MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        Cursor = Cursors.Default
    End Sub

    'Cursor = Cursors.WaitCursor
    'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ELIMINAR__ANULAR_SI_Botón___, AutorizacionRolList) Then
    '    If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then
    '        If MessageBox.Show("Desea Eliminar el item seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '            Select Case Me.dgPedidos.Table.CurrentRecord.GetValue("tipoCompra")
    '                Case TIPO_COMPRA.NOTA_CREDITO

    '                Case TIPO_COMPRA.NOTA_DEBITO
    '            ' 
    '                Case TIPO_VENTA.VENTA_NOTA_PEDIDO

    '                Case TIPO_VENTA.VENTA_GENERAL

    '                Case TIPO_VENTA.VENTA_POS_DIRECTA, TIPO_VENTA.VENTA_AL_TICKET
    '                    'EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
    '                '   EliminarPVDirecta(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))


    '                Case TIPO_COMPRA.NOTA_CREDITO_ELECTRONICA

    '                    If My.Computer.Network.IsAvailable = True Then
    '                        Dim f As New FormAnularVenta(CDate(Me.dgPedidos.Table.CurrentRecord.GetValue("fecha")))
    '                        f.StartPosition = FormStartPosition.CenterParent
    '                        f.ShowDialog(Me)
    '                        If f.Tag IsNot Nothing Then
    '                            Dim c = CType(f.Tag, Boolean)
    '                            If c = True Then 'fecha dentro del rango permitido

    '                                Dim objeto As New documentoventaAbarrotes
    '                                objeto.idDocumento = CInt(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
    '                                objeto.tipoDocumento = Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc")
    '                                objeto.serieVenta = Me.dgPedidos.Table.CurrentRecord.GetValue("serie")
    '                                objeto.numeroVenta = CInt(Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc"))
    '                                objeto.fechaDoc = CDate(Me.dgPedidos.Table.CurrentRecord.GetValue("fecha"))

    '                                If Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc") = "07" Then
    '                                    Try
    '                                        If Gempresas.ubigeo > 0 Then
    '                                            'If My.Computer.Network.IsAvailable = True Then
    '                                            If My.Computer.Network.Ping("138.128.171.106") Then

    '                                                Try
    '                                                    EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))


    '                                                    If objeto.serieVenta.Substring(0, 1) = "F" Then

    '                                                        EnviarComunicacionBaja(objeto)
    '                                                    ElseIf objeto.serieVenta.Substring(0, 1) = "B" Then
    '                                                        EnviarNotaBoletaEliminada(objeto)
    '                                                    End If

    '                                                Catch ex As Exception
    '                                                    MsgBox(ex.Message)
    '                                                    'MessageBox.Show("No se pudo eliminar el periodo esta cerrado", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                                End Try



    '                                            Else
    '                                                MessageBox.Show("No tiene conexión con el servidor SPK!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                            End If
    '                                            'Else
    '                                            '    MessageBox.Show("No tiene conexión a internet!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                            'End If
    '                                        Else
    '                                            EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
    '                                        End If
    '                                        BunifuFlatButton1.Enabled = True
    '                                    Catch ex As Exception
    '                                        BunifuFlatButton1.Enabled = True
    '                                    End Try

    '                                End If
    '                            Else
    '                                MessageBox.Show("No puede anular la venta, debe estar dentro del rango de 5 días hábiles!", "Validar fechas", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                            End If
    '                        End If
    '                    Else
    '                        MessageBox.Show("No tiene conexión a internet!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    End If



    '                Case TIPO_VENTA.VENTA_ELECTRONICA
    '                    If My.Computer.Network.IsAvailable = True Then
    '                        Dim f As New FormAnularVenta(CDate(Me.dgPedidos.Table.CurrentRecord.GetValue("fecha")))
    '                        f.StartPosition = FormStartPosition.CenterParent
    '                        f.ShowDialog(Me)
    '                        If f.Tag IsNot Nothing Then
    '                            Dim c = CType(f.Tag, Boolean)
    '                            If c = True Then 'fecha dentro del rango permitido


    '                                Dim CantNotasActivas = documentoventaabarrotessa.NotasActivas(CInt(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))

    '                                If CantNotasActivas > 0 Then
    '                                    MessageBox.Show("El documento tiene Notas de Credito Activas!", "Debe Anular las notas de credito", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                    Cursor = Cursors.Default
    '                                    Exit Sub
    '                                End If


    '                                Dim objeto As New documentoventaAbarrotes
    '                                objeto.idDocumento = CInt(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
    '                                objeto.tipoDocumento = Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc")
    '                                objeto.serieVenta = Me.dgPedidos.Table.CurrentRecord.GetValue("serie")
    '                                objeto.numeroVenta = CInt(Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc"))
    '                                objeto.fechaDoc = CDate(Me.dgPedidos.Table.CurrentRecord.GetValue("fecha"))

    '                                If Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc") = "03" Then
    '                                    Try
    '                                        If Gempresas.ubigeo > 0 Then
    '                                            '  If My.Computer.Network.IsAvailable = True Then
    '                                            If My.Computer.Network.Ping("138.128.171.106") Then
    '                                                Try
    '                                                    EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
    '                                                    EnviarBoletaEliminada(objeto)

    '                                                Catch ex As Exception
    '                                                    MsgBox(ex.Message)
    '                                                    'MessageBox.Show("No se pudo eliminar el periodo esta cerrado", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                                End Try

    '                                            Else
    '                                                MessageBox.Show("No tiene conexión con el servidor SPK!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                            End If
    '                                            'Else
    '                                            '    MessageBox.Show("No tiene conexión a internet!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                            'End If
    '                                        Else
    '                                            EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
    '                                        End If
    '                                        BunifuFlatButton1.Enabled = True
    '                                    Catch ex As Exception
    '                                        BunifuFlatButton1.Enabled = True
    '                                    End Try
    '                                ElseIf Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc") = "01" Then
    '                                    Try
    '                                        If Gempresas.ubigeo > 0 Then
    '                                            'If My.Computer.Network.IsAvailable = True Then
    '                                            If My.Computer.Network.Ping("138.128.171.106") Then

    '                                                Try
    '                                                    EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
    '                                                    EnviarComunicacionBaja(objeto)
    '                                                Catch ex As Exception
    '                                                    MsgBox(ex.Message)
    '                                                    'MessageBox.Show("No se pudo eliminar el periodo esta cerrado", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                                End Try



    '                                            Else
    '                                                MessageBox.Show("No tiene conexión con el servidor SPK!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                            End If
    '                                            'Else
    '                                            '    MessageBox.Show("No tiene conexión a internet!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                            'End If
    '                                        Else
    '                                            EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
    '                                        End If
    '                                        BunifuFlatButton1.Enabled = True
    '                                    Catch ex As Exception
    '                                        BunifuFlatButton1.Enabled = True
    '                                    End Try

    '                                End If
    '                            Else
    '                                MessageBox.Show("No puede anular la venta, debe estar dentro del rango de 5 días hábiles!", "Validar fechas", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                            End If
    '                        End If
    '                    Else
    '                        MessageBox.Show("No tiene conexión a internet!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    End If

    '            End Select
    '        End If
    '    Else
    '        MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    End If
    'Else
    '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    'End If
    'Cursor = Cursors.Default
    'End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Dim f As New FormFiltroAvanzadoDia()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim FechaSel = CType(f.Tag, DateTime?)
            PictureLoad.Visible = True
            BunifuFlatButton3.Enabled = False

            Select Case ComboVenta.Text
                Case "VENTAS ELECTRONICAS"
                    Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorDia(FechaSel, GEstableciento.IdEstablecimiento, TIPO_VENTA.VENTA_ELECTRONICA)))
                    thread.Start()
                Case "VENTAS ANULADAS"
                    Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorTipoAnuladosDia(FechaSel, TIPO_VENTA.VENTA_ELECTRONICA)))
                    thread.Start()
            End Select
        End If
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        PictureLoad.Visible = True
        Dim r As Record = Me.dgPedidos.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim f As New FormVentaNueva(Integer.Parse(r.GetValue("idDocumento")))
            f.ToolStrip1.Enabled = False
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)

            'Dim f As New FormVentaCalzados(Integer.Parse(r.GetValue("idDocumento")))
            'f.ToolStrip1.Enabled = False
            'f.StartPosition = FormStartPosition.CenterParent
            'f.ShowDialog(Me)
        End If
        PictureLoad.Visible = False
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Cursor = Cursors.WaitCursor
        Dim r As Record = dgPedidos.Table.CurrentRecord
        If r IsNot Nothing Then
            UbicarDocumentoVenta(CInt(r.GetValue("idDocumento")))
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub UbicarDocumentoVenta(idDocumento As Integer)

        Dim ventaSA As New documentoVentaAbarrotesSA
        ClipBoardDocumento = New documento
        ClipBoardDocumento.documentoventaAbarrotes = ventaSA.GetVentaID(New Business.Entity.documento With {.idDocumento = idDocumento})
        MessageBox.Show("Formato copiado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        Cursor = Cursors.WaitCursor
        Dim r As Record = dgPedidos.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim formato As String = String.Empty
            If (r.GetValue("tipoDoc") = "07") Then
                formato = 1
            Else
                formato = 2
            End If

            Dim f As New FormImpresionEquivalencia(Integer.Parse(r.GetValue("idDocumento"))) 'FormImpresionNuevo(Integer.Parse(r.GetValue("idDocumento")))
            f.DocumentoID = (Integer.Parse(r.GetValue("idDocumento")))
            f.TIPOiMPESION = formato
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else
            MessageBox.Show("Debe seleccionar un documento válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub dgPedidos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgPedidos.TableControlCellClick
        Cursor = Cursors.WaitCursor
        Dim style3 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style3.Enabled Then
            If style3.TableCellIdentity.Column.Name = "estado" Then

                Dim iddoc = style3.TableCellIdentity.Table.CurrentRecord.GetValue("idDocumento")
                Dim serie = style3.TableCellIdentity.Table.CurrentRecord.GetValue("serie")
                Dim numero = style3.TableCellIdentity.Table.CurrentRecord.GetValue("numeroDoc")
                Dim cliente = style3.TableCellIdentity.Table.CurrentRecord.GetValue("NombreEntidad")

                Dim f As New FormHistorialCobros()
                f.CargarHistorial(iddoc)
                f.txtNumero.Text = $"{serie}-{numero}"
                f.txtCliente.Text = cliente
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)

                '       e.Inner.Cancel = True

            End If

        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton7.Click
        Try
            PictureLoad2.Visible = True
            FiltrarVentas(ComboBoxAdv1.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
            PictureLoad2.Visible = False
        End Try
    End Sub

    Private Sub FiltrarVentas(text As String)
        'Select Case text
        '    Case "CLIENTE"
        Dim numeroVenta = textNumeroVenta.DecimalValue
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasCliente(GetPeriodo(txtFecha.Value, True), TIPO_VENTA.VENTA_ELECTRONICA, txtFiltrar.Tag, text, numeroVenta)))
        thread.Start()
        '    Case "COMPROBANTE"

        'End Select
    End Sub
#End Region

#Region "Entidad Source"
    Private Sub TXTcOMPRADOR_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        ElseIf e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Dim consulta = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, txtFiltrar.Text)

            If consulta.Count > 0 Then
                'consulta.AddRange(consulta)
                FillLSVClientes(consulta)
                Me.pcLikeCategoria.Size = New Size(282, 128)
                Me.pcLikeCategoria.ParentControl = Me.txtFiltrar
                Me.pcLikeCategoria.ShowPopup(Point.Empty)
                e.Handled = True
            End If

        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.txtFiltrar
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            LsvProveedor.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcLikeCategoria.IsShowing() Then
                Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Me.Cursor = Cursors.WaitCursor

        If e.PopupCloseType = PopupCloseType.Done Then
            If LsvProveedor.SelectedItems.Count > 0 Then

                txtFiltrar.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                txtFiltrar.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                txtFiltrar.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtFiltrar.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick, txtFiltrar.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub FillLSVClientes(consulta As List(Of entidad))
        LsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            n.SubItems.Add(i.tipoDoc)
            LsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Sub ComboBoxAdv1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxAdv1.SelectedValueChanged
        If ComboBoxAdv1.Text = "CLIENTE" Then
            LabelNumeroventa.Visible = False
            textNumeroVenta.Visible = False
            ToggleComprobante.Visible = False
            '    TextImporte.Visible = False
            Label3.Visible = False
            txtFiltrar.Visible = True
        ElseIf ComboBoxAdv1.Text = "COMPROBANTE" Then
            LabelNumeroventa.Visible = True
            textNumeroVenta.Visible = True
            ToggleComprobante.Visible = True
            '    TextImporte.Visible = True
            Label3.Visible = True
            txtFiltrar.Visible = False
        End If
    End Sub

    Private Sub ComboBoxAdv1_Click(sender As Object, e As EventArgs) Handles ComboBoxAdv1.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
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
    End Sub

    Private Sub BunifuFlatButton8_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton8.Click
        Try
            Dim r As Record = dgPedidos.Table.CurrentRecord
            If Not IsNothing(r) Then
                ' If r.GetValue("monedaDoc") = "NACIONAL" Or r.GetValue("monedaDoc") = "EXTRANJERA" Then

                ' If r.GetValue("tipoDoc") = "01" Then 'Or r.GetValue("tipoDoc") = "03" Then
                Dim clas = (Me.dgPedidos.Table.CurrentRecord.GetValue("enviosunat"))

                If clas.ToString.Trim.Length > 0 Then
                    If Me.dgPedidos.Table.CurrentRecord.GetValue("enviosunat") = "SI" Then
                        Dim f As New formNotaCreditoVentas(CInt(r.GetValue("idDocumento"))) 'FormNotaVentaDescuentoFE(CInt(r.GetValue("idDocumento")))  'frmNotaVentaNewFE
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                    Else
                        MessageBox.Show("Debe enviar primero para poder emitir nota!", "Atención")
                    End If
                Else
                    MessageBox.Show("La Factura debe ser enviado a sunat para poder hacer notas de credito!", "Atención")
                End If

                'ElseIf r.GetValue("tipoDoc") = "03" Then

                'Else
                '    MessageBox.Show("Seleccione una Factura", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'End If
                'Else
                '    MessageBox.Show("Debe seleccionar moneda Nacional!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'End If
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged

    End Sub

    Private Sub UCVentas_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgPedidos.TableDescriptor.Columns("estado").Appearance.AnyRecordFieldCell.CellType = "LinkLabelCell"
    End Sub

    Private Sub Panel28_Paint(sender As Object, e As PaintEventArgs) Handles Panel28.Paint

    End Sub

    Private Sub Panel28_Click(sender As Object, e As EventArgs) Handles Panel28.Click
        Dim f As New FormRegistroVentaMensual() 'FormImpresionNuevo(Integer.Parse(r.GetValue("idDocumento")))
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
    End Sub

    Private Sub BunifuFlatButton9_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton9.Click
        PictureLoad.Visible = True
        Dim r As Record = Me.dgPedidos.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim ventaSA As New documentoVentaAbarrotesSA
            Dim venta = ventaSA.GetVentaID(New documento() With {.idDocumento = Integer.Parse(r.GetValue("idDocumento").ToString)})
            If venta IsNot Nothing Then
                Dim ucHistorial As New ucHistorialGuiaDoc(venta)
                ucHistorial.StartPosition = FormStartPosition.CenterParent
                ucHistorial.ShowDialog(Me)
            End If
        End If
        PictureLoad.Visible = False
    End Sub

    Private Sub dgPedidos_TableControlCellMouseDown(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgPedidos.TableControlCellMouseDown

    End Sub

    Private Sub dgPedidos_RecordCollapsing(sender As Object, e As RecordEventArgs) Handles dgPedidos.RecordCollapsing

    End Sub
#End Region

End Class
