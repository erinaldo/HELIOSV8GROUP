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
Imports Syncfusion.GroupingGridExcelConverter


Public Class UCPrincipalVentas

#Region "Atributos"
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)

    Public Property cajaUsuarioSA As New cajaUsuarioSA
    Dim documentoventaabarrotessa As New documentoVentaAbarrotesSA
#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        FormatoGridAvanzado(DgvComprobantes, False, False, 8.0F)
        'FormatoGrid(DgvComprobantes)
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPrincipal(DgvComprobantes)


    End Sub

#End Region



#Region "Metodos"

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
        ' Try
        With objDocumento
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .idDocumento = intIdDocumento
        End With

        documentoSA.EliminarVenta(objDocumento)
        'documentoSA.EliminarVentaGeneralPV(objDocumento)
        'dgPedidos.Table.CurrentRecord.Delete()



        'MessageBox.Show("venta anulada!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)


        FrmSuccess.ConfirmationForm("VENTA ANULADA")

        'lblEstado.Text = "Pedido eliminado!"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)

        'Catch ex As Exception
        'MsgBox(ex.Message)
        ' End Try
    End Sub
    Private Sub GetBuscarComprobante(tipoDoc As String, serie As String, numero As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas de - " & "")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("comprobante", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("bi", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("bi02", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("igv", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("icbper", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoVenta", GetType(String)))


        Dim be As New documentoventaAbarrotes

        be.tipoDocumento = tipoDoc
        be.serieVenta = serie
        be.numeroVenta = numero
        be.idEstablecimiento = GEstableciento.IdEstablecimiento

        Dim str As String

        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetBuscarComprobante(be)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.fechaDoc 'str
            dr(2) = i.tipoDocumento

            Select Case i.tipoDocumento
                Case "01"
                    dr(3) = "Factura"
                Case "03"
                    dr(3) = "Boleta"
                Case "07"
                    dr(3) = "Nota Credito"
                Case "08"
                    dr(3) = "Nota Debito"
            End Select


            dr(4) = i.serieVenta
            dr(5) = i.numeroVenta

            Select Case i.NroDocEntidad
                Case Is = Nothing

                    dr(6) = "-"
                    dr(7) = i.nombrePedido
                Case Else

                    dr(6) = i.NroDocEntidad
                    dr(7) = i.NombreEntidad
            End Select



            dr(8) = i.bi01
            dr(9) = i.bi02

            dr(10) = i.igv01
            dr(11) = i.icbper.GetValueOrDefault
            dr(12) = i.ImporteNacional


            Select Case i.estadoCobro
                Case "DC"
                    dr(13) = "Cobrado"
                Case "ANU"
                    dr(13) = "Anulado"
                Case TIPO_VENTA.AnuladaPorNotaCredito
                    dr(13) = "Anulado x NC."
                Case Else
                    dr(13) = "-"
            End Select

            If i.EnvioSunat IsNot Nothing Then
                dr(14) = i.EnvioSunat
            Else
                dr(14) = "NO"
            End If
            dr(15) = i.tipoVenta
            dt.Rows.Add(dr)
        Next


        setDatasource(dt)
    End Sub


    Private Sub GetListarRegistroVentasFisicas(period As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim ListaTipo As New List(Of String)

        ListaTipo.Add(TIPO_VENTA.VENTA_GENERAL)
        ListaTipo.Add(TIPO_VENTA.VENTA_HEREDAD)
        ListaTipo.Add(TIPO_VENTA.VENTA_POS_DIRECTA)
        ListaTipo.Add(TIPO_VENTA.VENTA_ANTICIPADA_OTORGADO)

        ListaTipo.Add(TIPO_VENTA.VENTA_AL_TICKET)
        ListaTipo.Add(TIPO_COMPRA.NOTA_CREDITO)
        ListaTipo.Add(TIPO_COMPRA.NOTA_DEBITO)



        Dim dt As New DataTable("Ventas de - " & period)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("comprobante", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("bi", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("bi02", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("igv", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("icbper", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoVenta", GetType(String)))


        Dim str As String
        'For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarRegistroVentasXTipo(GEstableciento.IdEstablecimiento, period, ListaTipo)
        '    Dim dr As DataRow = dt.NewRow()
        '    str = Nothing
        '    str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
        '    dr(0) = i.idDocumento
        '    dr(1) = str
        '    dr(2) = i.tipoDocumento
        '    dr(3) = i.serieVenta
        '    dr(4) = i.numeroVenta

        '    Select Case i.NroDocEntidad
        '        Case Is = Nothing

        '            dr(5) = "-"
        '            dr(6) = i.nombrePedido
        '        Case Else

        '            dr(5) = i.NroDocEntidad
        '            dr(6) = i.NombreEntidad
        '    End Select



        '    dr(7) = i.bi01
        '    dr(8) = i.bi02

        '    dr(9) = i.igv01
        '    dr(10) = i.icbper
        '    dr(11) = i.ImporteNacional


        '    Select Case i.estadoCobro
        '        Case "DC"
        '            dr(12) = "Cobrado"
        '        Case "ANU"
        '            dr(12) = "Anulado"
        '        Case TIPO_VENTA.AnuladaPorNotaCredito
        '            dr(12) = "Anulado x NC."
        '        Case Else
        '            dr(12) = "-"
        '    End Select



        '    dt.Rows.Add(dr)
        'Next


        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarRegistroNotasVentas(GEstableciento.IdEstablecimiento, period)
            If i.estadoCobro <> "ANU" Then
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.fechaDoc 'str
                dr(2) = i.tipoDocumento

                Select Case i.tipoDocumento
                    Case "01"
                        dr(3) = "Factura"
                    Case "03"
                        dr(3) = "Boleta"
                    Case "07"
                        dr(3) = "Nota Credito"
                    Case "08"
                        dr(3) = "Nota Debito"
                End Select


                dr(4) = i.serieVenta
                dr(5) = i.numeroVenta

                Select Case i.NroDocEntidad
                    Case Is = Nothing

                        dr(6) = "-"
                        dr(7) = i.nombrePedido
                    Case Else

                        dr(6) = i.NroDocEntidad
                        dr(7) = i.NombreEntidad
                End Select



                dr(8) = i.bi01
                dr(9) = i.bi02

                dr(10) = i.igv01
                dr(11) = i.icbper.GetValueOrDefault
                dr(12) = i.ImporteNacional


                Select Case i.estadoCobro
                    Case "DC"
                        dr(13) = "Cobrado"
                    Case "ANU"
                        dr(13) = "Anulado"
                    Case TIPO_VENTA.AnuladaPorNotaCredito
                        dr(13) = "Anulado x NC."
                    Case Else
                        dr(13) = "-"
                End Select

                If i.EnvioSunat IsNot Nothing Then
                    dr(14) = i.EnvioSunat
                Else
                    dr(14) = "NO"
                End If
                dr(15) = i.tipoVenta
                dt.Rows.Add(dr)
            End If
        Next

        setDatasource(dt)
    End Sub




    Private Sub ListarVentasTipoClientePeriodo(period As String, tipo As String, idClie As Integer)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim ListaTipo As New List(Of String)



        Select Case tipo
            Case "VENTAS ELECTRONICAS"
                ListaTipo.Add(TIPO_VENTA.VENTA_ELECTRONICA)
                ListaTipo.Add(TIPO_COMPRA.NOTA_CREDITO_ELECTRONICA)
            Case "VENTAS FISICAS"

                ListaTipo.Add(TIPO_VENTA.VENTA_GENERAL)
                ListaTipo.Add(TIPO_VENTA.VENTA_HEREDAD)
                ListaTipo.Add(TIPO_VENTA.VENTA_POS_DIRECTA)
                ListaTipo.Add(TIPO_VENTA.VENTA_ANTICIPADA_OTORGADO)

                ListaTipo.Add(TIPO_VENTA.VENTA_AL_TICKET)
                ListaTipo.Add(TIPO_COMPRA.NOTA_CREDITO)
                ListaTipo.Add(TIPO_COMPRA.NOTA_DEBITO)

            Case "TODAS LAS VENTAS"
                ListaTipo.Add(TIPO_VENTA.VENTA_ELECTRONICA)
                ListaTipo.Add(TIPO_COMPRA.NOTA_CREDITO_ELECTRONICA)
                ListaTipo.Add(TIPO_VENTA.NOTA_DE_VENTA)
                ListaTipo.Add(TIPO_VENTA.VENTA_GENERAL)
            Case "NOTAS DE VENTA"

                ListaTipo.Add(TIPO_VENTA.NOTA_DE_VENTA)
        End Select



        Dim be As New documentoventaAbarrotes
        be.fechaPeriodo = period
        be.idCliente = idClie
        be.idEstablecimiento = GEstableciento.IdEstablecimiento


        Dim dt As New DataTable("Ventas de - " & period)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("comprobante", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("bi", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("bi02", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("igv", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("icbper", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoVenta", GetType(String)))



        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.ListarVentasTipoClientePeriodo(be, ListaTipo)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.fechaDoc 'str
            dr(2) = i.tipoDocumento

            Select Case i.tipoDocumento
                Case "01"
                    dr(3) = "Factura"
                Case "03"
                    dr(3) = "Boleta"
                Case "07"
                    dr(3) = "Nota Credito"
                Case "08"
                    dr(3) = "Nota Debito"
            End Select


            dr(4) = i.serieVenta
            dr(5) = i.numeroVenta

            Select Case i.NroDocEntidad
                Case Is = Nothing

                    dr(6) = "-"
                    dr(7) = i.nombrePedido
                Case Else

                    dr(6) = i.NroDocEntidad
                    dr(7) = i.NombreEntidad
            End Select



            dr(8) = i.bi01
            dr(9) = i.bi02

            dr(10) = i.igv01
            dr(11) = i.icbper.GetValueOrDefault
            dr(12) = i.ImporteNacional


            Select Case i.estadoCobro
                Case "DC"
                    dr(13) = "Cobrado"
                Case "ANU"
                    dr(13) = "Anulado"
                Case TIPO_VENTA.AnuladaPorNotaCredito
                    dr(13) = "Anulado x NC."
                Case Else
                    dr(13) = "-"
            End Select

            If i.EnvioSunat IsNot Nothing Then
                dr(14) = i.EnvioSunat
            Else
                dr(14) = "NO"
            End If

            dr(15) = i.tipoVenta
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub


    Private Sub GetListarVentasAnuladasDelPeriodo(period As String, tipo As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        'Dim ListaTipo As New List(Of String)


        'ListaTipo.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        'ListaTipo.Add(TIPO_COMPRA.NOTA_CREDITO_ELECTRONICA)


        Dim dt As New DataTable("Ventas de - " & period)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("comprobante", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("bi", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("bi02", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("igv", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("icbper", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoVenta", GetType(String)))




        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasPeriodoXTipoAnulados(GEstableciento.IdEstablecimiento, period, tipo).OrderByDescending(Function(v) v.fechaDoc).ToList
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.fechaDoc 'str
            dr(2) = i.tipoDocumento

            Select Case i.tipoDocumento
                Case "01"
                    dr(3) = "Factura"
                Case "03"
                    dr(3) = "Boleta"
                Case "07"
                    dr(3) = "Nota Credito"
                Case "08"
                    dr(3) = "Nota Debito"
            End Select


            dr(4) = i.serieVenta
            dr(5) = i.numeroVenta

            Select Case i.NroDocEntidad
                Case Is = Nothing

                    dr(6) = "-"
                    dr(7) = i.nombrePedido
                Case Else

                    dr(6) = i.NroDocEntidad
                    dr(7) = i.NombreEntidad
            End Select



            dr(8) = i.bi01
            dr(9) = i.bi02

            dr(10) = i.igv01
            dr(11) = i.icbper.GetValueOrDefault
            dr(12) = i.ImporteNacional


            Select Case i.estadoCobro
                Case "DC"
                    dr(13) = "Cobrado"
                Case "ANU"
                    dr(13) = "Anulado"
                Case TIPO_VENTA.AnuladaPorNotaCredito
                    dr(13) = "Anulado x NC."
                Case Else
                    dr(13) = "-"
            End Select

            If i.EnvioSunat IsNot Nothing Then
                dr(14) = i.EnvioSunat
            Else
                dr(14) = "NO"
            End If
            dr(15) = i.tipoVenta
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub


    'ventas por dia

    Private Sub GetListarVentasPorDia(fechaLaboral As Date, idEstable As Integer, tipo As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        'Dim ListaTipo As New List(Of String)


        'ListaTipo.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        'ListaTipo.Add(TIPO_COMPRA.NOTA_CREDITO_ELECTRONICA)


        Dim dt As New DataTable("Ventas del Dia - " & fechaLaboral)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("comprobante", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("bi", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("bi02", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("igv", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("icbper", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoVenta", GetType(String)))




        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasPorDiaEstablecimiento(New documentoventaAbarrotes With {.idEstablecimiento = idEstable, .fechaDoc = fechaLaboral, .tipoVenta = tipo}).OrderByDescending(Function(v) v.fechaDoc).ToList
            If i.estadoCobro <> "ANU" Then
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.fechaDoc 'str
                dr(2) = i.tipoDocumento

                Select Case i.tipoDocumento
                    Case "01"
                        dr(3) = "Factura"
                    Case "03"
                        dr(3) = "Boleta"
                    Case "07"
                        dr(3) = "Nota Credito"
                    Case "08"
                        dr(3) = "Nota Debito"
                End Select


                dr(4) = i.serieVenta
                dr(5) = i.numeroVenta

                Select Case i.NroDocEntidad
                    Case Is = Nothing

                        dr(6) = "-"
                        dr(7) = i.nombrePedido
                    Case Else

                        dr(6) = i.NroDocEntidad
                        dr(7) = i.NombreEntidad
                End Select



                dr(8) = i.bi01
                dr(9) = i.bi02

                dr(10) = i.igv01
                dr(11) = i.icbper.GetValueOrDefault
                dr(12) = i.ImporteNacional


                Select Case i.estadoCobro
                    Case "DC"
                        dr(13) = "Cobrado"
                    Case "ANU"
                        dr(13) = "Anulado"
                    Case TIPO_VENTA.AnuladaPorNotaCredito
                        dr(13) = "Anulado x NC."
                    Case Else
                        dr(13) = "-"
                End Select

                If i.EnvioSunat IsNot Nothing Then
                    dr(14) = i.EnvioSunat
                Else
                    dr(14) = "NO"
                End If
                dr(15) = i.tipoVenta
                dt.Rows.Add(dr)
            End If
        Next
        setDatasource(dt)
    End Sub


    'electronicas
    Private Sub GetListarRegistroVentasElectronicas(period As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim ListaTipo As New List(Of String)


        ListaTipo.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        ListaTipo.Add(TIPO_COMPRA.NOTA_CREDITO_ELECTRONICA)


        Dim dt As New DataTable("Ventas de - " & period)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("comprobante", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("bi", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("bi02", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("igv", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("icbper", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoVenta", GetType(String)))




        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarRegistroVentasXTipo(GEstableciento.IdEstablecimiento, period, ListaTipo)
            If i.estadoCobro <> "ANU" Then
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.fechaDoc 'str
                dr(2) = i.tipoDocumento

                Select Case i.tipoDocumento
                    Case "01"
                        dr(3) = "Factura"
                    Case "03"
                        dr(3) = "Boleta"
                    Case "07"
                        dr(3) = "Nota Credito"
                    Case "08"
                        dr(3) = "Nota Debito"
                End Select


                dr(4) = i.serieVenta
                dr(5) = i.numeroVenta

                Select Case i.NroDocEntidad
                    Case Is = Nothing

                        dr(6) = "-"
                        dr(7) = i.nombrePedido
                    Case Else

                        dr(6) = i.NroDocEntidad
                        dr(7) = i.NombreEntidad
                End Select



                dr(8) = i.bi01
                dr(9) = i.bi02

                dr(10) = i.igv01
                dr(11) = i.icbper.GetValueOrDefault
                dr(12) = i.ImporteNacional


                Select Case i.estadoCobro
                    Case "DC"
                        dr(13) = "Cobrado"
                    Case "ANU"
                        dr(13) = "Anulado"
                    Case TIPO_VENTA.AnuladaPorNotaCredito
                        dr(13) = "Anulado x NC."
                    Case Else
                        dr(13) = "-"
                End Select

                If i.EnvioSunat IsNot Nothing Then
                    dr(14) = i.EnvioSunat
                Else
                    dr(14) = "NO"
                End If
                dr(15) = i.tipoVenta
                dt.Rows.Add(dr)
            End If
        Next
        setDatasource(dt)
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            DgvComprobantes.DataSource = table
            'ProgressBar1.Visible = False
        End If
    End Sub

    'solo notas

    Private Sub GetListaNotasVentasPorPeriodo(period As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas de - " & period)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("comprobante", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("bi", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("bi02", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("igv", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("icbper", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoVenta", GetType(String)))

        Dim str As String
        'For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarRegistroNotasVentas(GEstableciento.IdEstablecimiento, period)
        '    Dim dr As DataRow = dt.NewRow()
        '    str = Nothing
        '    str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
        '    dr(0) = i.idDocumento
        '    dr(1) = str
        '    dr(2) = i.tipoDocumento
        '    dr(3) = i.serieVenta
        '    dr(4) = i.numeroVenta

        '    Select Case i.NroDocEntidad
        '        Case Is = Nothing

        '            dr(5) = "-"
        '            dr(6) = i.nombrePedido
        '        Case Else

        '            dr(5) = i.NroDocEntidad
        '            dr(6) = i.NombreEntidad
        '    End Select



        '    dr(7) = i.bi01
        '    dr(8) = i.bi02

        '    dr(9) = i.igv01
        '    dr(10) = i.icbper
        '    dr(11) = i.ImporteNacional


        '    Select Case i.estadoCobro
        '        Case "DC"
        '            dr(12) = "Cobrado"
        '        Case "ANU"
        '            dr(12) = "Anulado"
        '        Case TIPO_VENTA.AnuladaPorNotaCredito
        '            dr(12) = "Anulado x NC."
        '        Case Else
        '            dr(12) = "-"
        '    End Select



        '    dt.Rows.Add(dr)
        'Next


        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarRegistroNotasVentas(GEstableciento.IdEstablecimiento, period)
            If i.estadoCobro <> "ANU" Then
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.fechaDoc 'str
                dr(2) = i.tipoDocumento

                Select Case i.tipoDocumento
                    Case "01"
                        dr(3) = "Factura"
                    Case "03"
                        dr(3) = "Boleta"
                    Case "07"
                        dr(3) = "Nota Credito"
                    Case "08"
                        dr(3) = "Nota Debito"
                End Select


                dr(4) = i.serieVenta
                dr(5) = i.numeroVenta

                Select Case i.NroDocEntidad
                    Case Is = Nothing

                        dr(6) = "-"
                        dr(7) = i.nombrePedido
                    Case Else

                        dr(6) = i.NroDocEntidad
                        dr(7) = i.NombreEntidad
                End Select



                dr(8) = i.bi01
                dr(9) = i.bi02

                dr(10) = i.igv01
                dr(11) = i.icbper.GetValueOrDefault
                dr(12) = i.ImporteNacional


                Select Case i.estadoCobro
                    Case "DC"
                        dr(13) = "Cobrado"
                    Case "ANU"
                        dr(13) = "Anulado"
                    Case TIPO_VENTA.AnuladaPorNotaCredito
                        dr(13) = "Anulado x NC."
                    Case Else
                        dr(13) = "-"
                End Select

                If i.EnvioSunat IsNot Nothing Then
                    dr(14) = i.EnvioSunat
                Else
                    dr(14) = "NO"
                End If
                dr(15) = i.tipoVenta
                dt.Rows.Add(dr)
            End If
        Next


        setDatasource(dt)
    End Sub

    'todos
    Private Sub GetListaVentasPorPeriodo(period As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas de - " & period)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("comprobante", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("bi", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("bi02", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("igv", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("icbper", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoVenta", GetType(String)))

        Dim str As String
        'For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarRegistroVentas(GEstableciento.IdEstablecimiento, period)
        '    Dim dr As DataRow = dt.NewRow()
        '    str = Nothing
        '    str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
        '    dr(0) = i.idDocumento
        '    dr(1) = str
        '    dr(2) = i.tipoDocumento
        '    dr(3) = i.serieVenta
        '    dr(4) = i.numeroVenta

        '    Select Case i.NroDocEntidad
        '        Case Is = Nothing

        '            dr(5) = "-"
        '            dr(6) = i.nombrePedido
        '        Case Else

        '            dr(5) = i.NroDocEntidad
        '            dr(6) = i.NombreEntidad
        '    End Select



        '    dr(7) = i.bi01
        '    dr(8) = i.bi02

        '    dr(9) = i.igv01
        '    dr(10) = i.icbper
        '    dr(11) = i.ImporteNacional


        '    Select Case i.estadoCobro
        '        Case "DC"
        '            dr(12) = "Cobrado"
        '        Case "ANU"
        '            dr(12) = "Anulado"
        '        Case TIPO_VENTA.AnuladaPorNotaCredito
        '            dr(12) = "Anulado x NC."
        '        Case Else
        '            dr(12) = "-"
        '    End Select



        '    dt.Rows.Add(dr)
        'Next


        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarRegistroVentas(GEstableciento.IdEstablecimiento, period)
            If i.estadoCobro <> "ANU" Then
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.fechaDoc 'str
                dr(2) = i.tipoDocumento

                Select Case i.tipoDocumento
                    Case "01"
                        dr(3) = "Factura"
                    Case "03"
                        dr(3) = "Boleta"
                    Case "07"
                        dr(3) = "Nota Credito"
                    Case "08"
                        dr(3) = "Nota Debito"
                End Select


                dr(4) = i.serieVenta
                dr(5) = i.numeroVenta

                Select Case i.NroDocEntidad
                    Case Is = Nothing

                        dr(6) = "-"
                        dr(7) = i.nombrePedido
                    Case Else

                        dr(6) = i.NroDocEntidad
                        dr(7) = i.NombreEntidad
                End Select



                dr(8) = i.bi01
                dr(9) = i.bi02

                dr(10) = i.igv01
                dr(11) = i.icbper.GetValueOrDefault
                dr(12) = i.ImporteNacional


                Select Case i.estadoCobro
                    Case "DC"
                        dr(13) = "Cobrado"
                    Case "ANU"
                        dr(13) = "Anulado"
                    Case TIPO_VENTA.AnuladaPorNotaCredito
                        dr(13) = "Anulado x NC."
                    Case Else
                        dr(13) = "-"
                End Select

                If i.EnvioSunat IsNot Nothing Then
                    dr(14) = i.EnvioSunat
                Else
                    dr(14) = "NO"
                End If
                dr(15) = i.tipoVenta
                dt.Rows.Add(dr)
            End If
        Next

        setDatasource(dt)
    End Sub

#End Region















    Private Sub btnNuevaVenta_Click(sender As Object, e As EventArgs) Handles btnNuevaVenta.Click
        If validarPermisos(PermisosDelSistema.VENTA_, AutorizacionRolList) = 1 Then
            If ListaCajasActivas.Count = 0 Or ListaCajasActivas Is Nothing Then
                MessageBox.Show("Debe registrar una caja para realizar la venta")
                ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                 .estadoCaja = "A"
                                                                 })
                Exit Sub
            End If
            If GconfigCaja = "2" Then
                Dim querybox As cajaUsuario
                If usuario.tipoCaja = Tipo_Caja.ADMINISTRATIVO Then
                    querybox = (From i In ListaCajasActivas
                                Where i.tipoCaja = Tipo_Caja.GENERAL And i.estadoCaja = "A").FirstOrDefault
                ElseIf usuario.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then
                    querybox = (From i In ListaCajasActivas
                                Where i.idPersona = usuario.IDUsuario And i.estadoCaja = "A" And i.IDRol = usuario.IDRol).FirstOrDefault

                End If
                If querybox IsNot Nothing Then
                Else
                    MessageBox.Show("Su usuario no tiene una caja aperturada")
                    Exit Sub
                End If
            End If
            'If Gempresas.ubigeo IsNot Nothing Then
            '    Dim f As New FormVentaNueva
            '    f.ComboComprobante.Text = "NOTA DE VENTA"
            '    f.StartPosition = FormStartPosition.CenterParent
            '    f.Show(Me)
            'Else
            '    Dim f As New FormVentaNueva
            '    f.ComboComprobante.Text = "VENTA"
            '    f.StartPosition = FormStartPosition.CenterParent
            '    f.Show(Me)
            'End If

            If Gempresas.ubigeo > 0 Then
                Dim f As New FormVentaNueva
                f.ComboComprobante.Text = "VENTA"
                f.StartPosition = FormStartPosition.CenterParent
                f.Show(Me)
            Else
                Dim f As New FormVentaNueva
                f.ComboComprobante.Text = "NOTA DE VENTA"
                f.StartPosition = FormStartPosition.CenterParent
                f.Show(Me)
            End If
            'If ButtonAdv5.Text = "NOTA VENTA" Then
            '    Dim f As New FormVentaNueva
            '    f.ComboComprobante.Text = "NOTA DE VENTA"
            '    f.StartPosition = FormStartPosition.CenterParent
            '    f.Show(Me)
            'Else
            '    Dim f As New FormVentaNueva
            '    f.ComboComprobante.Text = "VENTA"
            '    f.StartPosition = FormStartPosition.CenterParent
            '    f.Show(Me)
            'End If
            'End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnBuscarVenta_Click(sender As Object, e As EventArgs) Handles btnBuscarVenta.Click
        Select Case cboTipoBusqueda.Text
            Case "VENTAS DEL PERIODO"

                Dim datos As List(Of item) = item.Instance()
                datos.Clear()

                Dim f As New FormFiltroPeriodoComprobante()
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                If f.Tag IsNot Nothing Then
                    Dim periodoSel = CType(f.Tag, DateTime?)
                    Dim periodoString = GetPeriodo(periodoSel, True)

                    If datos.Count > 0 Then

                        Select Case datos(0).descripcion
                            Case "VENTAS ELECTRONICAS"
                                GetListarRegistroVentasElectronicas(periodoString)
                            Case "VENTAS FISICAS"
                                GetListarRegistroVentasFisicas(periodoString)
                            Case "TODAS LAS VENTAS"
                                GetListaVentasPorPeriodo(periodoString)
                            Case "NOTAS DE VENTA"
                                GetListaNotasVentasPorPeriodo(periodoString)
                        End Select
                    End If
                End If

            Case "VENTAS DEL DIA"


                Dim datos As List(Of item) = item.Instance()
                datos.Clear()

                Dim f As New FormFiltroDiaVentas()
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                If f.Tag IsNot Nothing Then
                    Dim periodoSel = CType(f.Tag, DateTime?)
                    Dim periodoString = GetPeriodo(periodoSel, True)

                    If datos.Count > 0 Then

                        Select Case datos(0).descripcion
                            Case "VENTAS ELECTRONICAS"
                                GetListarVentasPorDia(periodoSel, GEstableciento.IdEstablecimiento, TIPO_VENTA.VENTA_ELECTRONICA)
                            Case "VENTAS FISICAS"
                                'GetListarVentasPorDia(periodoSel, GEstableciento.IdEstablecimiento, TIPO_VENTA.VENTA_ELECTRONICA)
                            Case "TODAS LAS VENTAS"
                                'GetListarVentasPorDia(periodoString)
                            Case "NOTAS DE VENTA"
                                GetListarVentasPorDia(periodoSel, GEstableciento.IdEstablecimiento, TIPO_VENTA.NOTA_DE_VENTA)
                        End Select
                    End If
                End If


            Case "VENTAS POR CLIENTE"

                Dim datos As List(Of item) = item.Instance()
                datos.Clear()


                Dim f As New FormFiltroPeriodoCliente()
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                If f.Tag IsNot Nothing Then
                    Dim periodoSel = CType(f.Tag, DateTime?)
                    Dim periodoString = GetPeriodo(periodoSel, True)
                    'PictureLoad.Visible = True
                    If datos.Count > 0 Then
                        ListarVentasTipoClientePeriodo(periodoString, datos(0).descripcion, datos(0).idEntidad)
                    End If
                End If

            Case "BUSCAR COMPROBANTE"
                Try


                    Dim datos As List(Of item) = item.Instance()
                    datos.Clear()


                    Dim f As New FormFiltroComprobante()
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog(Me)
                    If f.Tag IsNot Nothing Then


                        If datos.Count > 0 Then
                            GetBuscarComprobante(datos(0).tipoDocumento, datos(0).serie, datos(0).numero)

                        End If


                    End If
                Catch ex As Exception

                End Try

            Case "VENTAS ANULADAS"


                'Dim f As New FormFiltroAvanzadoPeriodo()
                'f.StartPosition = FormStartPosition.CenterParent
                'f.ShowDialog(Me)
                'If f.Tag IsNot Nothing Then
                '    Dim periodoSel = CType(f.Tag, DateTime?)
                '    PictureLoad.Visible = True
                '    ' BunifuFlatButton5.Enabled = False

                '    GetListarVentasAnuladasDelPeriodo(GetPeriodo(periodoSel, True), TIPO_VENTA.VENTA_ELECTRONICA)


                'End If




                Dim datos As List(Of item) = item.Instance()
                datos.Clear()

                Dim f As New FormFiltroPeriodoComprobante()
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                If f.Tag IsNot Nothing Then
                    Dim periodoSel = CType(f.Tag, DateTime?)
                    Dim periodoString = GetPeriodo(periodoSel, True)

                    If datos.Count > 0 Then

                        Select Case datos(0).descripcion
                            Case "VENTAS ELECTRONICAS"

                                GetListarVentasAnuladasDelPeriodo(periodoString, TIPO_VENTA.VENTA_ELECTRONICA)
                            Case "VENTAS FISICAS"
                                GetListarVentasAnuladasDelPeriodo(periodoString, TIPO_VENTA.NOTA_DE_VENTA)
                            Case "TODAS LAS VENTAS"

                            Case "NOTAS DE VENTA"
                                GetListarVentasAnuladasDelPeriodo(periodoString, TIPO_VENTA.NOTA_DE_VENTA)
                        End Select
                    End If
                End If


        End Select
    End Sub

    Private Sub btnNuevoComprobanteAdicional_Click(sender As Object, e As EventArgs) Handles btnNuevoComprobanteAdicional.Click
        Select Case cboComprobantesAdicional.Text
            Case "NOTA DE CREDITO"
                Try
                    Dim r As Record = DgvComprobantes.Table.CurrentRecord
                    If Not IsNothing(r) Then


                        Dim typeInvoice = (Me.DgvComprobantes.Table.CurrentRecord.GetValue("tipoVenta"))
                        If Not typeInvoice = TIPO_VENTA.VENTA_ELECTRONICA Then
                            MessageBox.Show("Seleccione una Factura o Boleta Electrónica!", "Atención")
                            Exit Sub
                        End If
                        Dim stateInvoice = (Me.DgvComprobantes.Table.CurrentRecord.GetValue("estado"))
                        If stateInvoice = "Anulado" Then
                            MessageBox.Show("El comprobante esta anulado!", "Atención")
                            Exit Sub
                            'ElseIf stateInvoice = "Anulado x NC." Then
                            '    MessageBox.Show("El comprobante esta anulado!", "Atención")
                            '    Exit Sub
                        End If

                        Dim clas = (Me.DgvComprobantes.Table.CurrentRecord.GetValue("enviosunat"))

                        If clas.ToString.Trim.Length > 0 Then
                            If Me.DgvComprobantes.Table.CurrentRecord.GetValue("enviosunat") = "SI" Then
                                Dim f As New formNotaCreditoVentas(CInt(r.GetValue("idDocumento"))) 'FormNotaVentaDescuentoFE(CInt(r.GetValue("idDocumento")))  'frmNotaVentaNewFE
                                f.StartPosition = FormStartPosition.CenterParent
                                f.ShowDialog()
                            Else
                                MessageBox.Show("Debe enviar primero para poder emitir nota!", "Atención")
                            End If
                        Else
                            MessageBox.Show("La Factura debe ser enviado a sunat para poder hacer notas de credito!", "Atención")
                        End If

                    Else
                        MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Case "NOTA DE DEBITO"

            Case "GUIA DE REMISON"

                'PictureLoad.Visible = True
                Dim r As Record = Me.DgvComprobantes.Table.CurrentRecord
                If r IsNot Nothing Then

                    Dim typeInvoice = (Me.DgvComprobantes.Table.CurrentRecord.GetValue("tipoVenta"))
                    If Not typeInvoice = TIPO_VENTA.VENTA_ELECTRONICA Then
                        MessageBox.Show("Seleccione un Comprobante Electrónico!", "Atención")
                        Exit Sub
                    End If
                    Dim stateInvoice = (Me.DgvComprobantes.Table.CurrentRecord.GetValue("estado"))
                    If stateInvoice = "Anulado" Then
                        MessageBox.Show("El comprobante esta anulado!", "Atención")
                        Exit Sub
                    ElseIf stateInvoice = "Anulado x NC." Then
                        MessageBox.Show("El comprobante esta anulado!", "Atención")
                        Exit Sub
                    End If

                    Dim ventaSA As New documentoVentaAbarrotesSA
                    Dim venta = ventaSA.GetVentaID(New documento() With {.idDocumento = Integer.Parse(r.GetValue("idDocumento").ToString)})
                    If venta IsNot Nothing Then
                        'Dim ucHistorial As New ucHistorialGuiaDoc(venta)
                        Try
                            Dim ucHistorial As New FormGuiaRemision8(venta)
                            ucHistorial.StartPosition = FormStartPosition.CenterParent
                            ucHistorial.ShowDialog(Me)
                        Catch ex As Exception

                        End Try

                    End If
                End If
                'PictureLoad.Visible = False

        End Select
    End Sub

    Private Sub btnAnularVenta_Click(sender As Object, e As EventArgs) Handles btnAnularVenta.Click
        Cursor = Cursors.WaitCursor
        btnAnularVenta.Enabled = False
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ELIMINAR__ANULAR_SI_Botón___, AutorizacionRolList) Then
        If Not IsNothing(Me.DgvComprobantes.Table.CurrentRecord) Then


            Try
                Dim resultado = New DialogResult()
                Dim frm = New FrmInformation("¿ESTA SEGURO DE ELIMINAR EL REGISTRO?")
                resultado = frm.ShowDialog()
                If resultado = DialogResult.OK Then



                    ' If MessageBox.Show("Desea Eliminar el item seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Select Case Me.DgvComprobantes.Table.CurrentRecord.GetValue("tipoVenta")
                        Case TIPO_VENTA.NOTA_DE_VENTA
                            If Not IsNothing(Me.DgvComprobantes.Table.CurrentRecord) Then
                                If MessageBox.Show("Desea Eliminar el item seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    EliminarPV(Val(Me.DgvComprobantes.Table.CurrentRecord.GetValue("idDocumento")))
                                End If
                            Else
                                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Cursor = Cursors.WaitCursor
                                btnAnularVenta.Enabled = True
                            End If

                        Case TIPO_COMPRA.NOTA_CREDITO_ELECTRONICA

                            If My.Computer.Network.IsAvailable = True Then
                                Dim f As New FormAnularVenta(CDate(Me.DgvComprobantes.Table.CurrentRecord.GetValue("fechaDoc")))
                                f.StartPosition = FormStartPosition.CenterParent
                                f.ShowDialog(Me)
                                If f.Tag IsNot Nothing Then
                                    Dim c = CType(f.Tag, Boolean)
                                    If c = True Then 'fecha dentro del rango permitido

                                        Dim objeto As New documentoventaAbarrotes
                                        objeto.idDocumento = CInt(Me.DgvComprobantes.Table.CurrentRecord.GetValue("idDocumento"))
                                        objeto.tipoDocumento = Me.DgvComprobantes.Table.CurrentRecord.GetValue("comprobante")
                                        objeto.serieVenta = Me.DgvComprobantes.Table.CurrentRecord.GetValue("serie")
                                        objeto.numeroVenta = CInt(Me.DgvComprobantes.Table.CurrentRecord.GetValue("numero"))
                                        objeto.fechaDoc = CDate(Me.DgvComprobantes.Table.CurrentRecord.GetValue("fechaDoc"))




                                        If Me.DgvComprobantes.Table.CurrentRecord.GetValue("tipoDoc") = "07" Then
                                            Try
                                                If Gempresas.ubigeo > 0 Then

                                                    If My.Computer.Network.Ping("138.128.171.106") Then

                                                        Try
                                                            EliminarPV(Val(Me.DgvComprobantes.Table.CurrentRecord.GetValue("idDocumento")))

                                                            If DgvComprobantes.Table.CurrentRecord IsNot Nothing Then
                                                                Dim envio = Me.DgvComprobantes.Table.CurrentRecord.GetValue("enviosunat")
                                                                If envio.ToString.Trim.Length > 0 Then
                                                                    EnviarAnulacionDocumento(objeto)
                                                                    DgvComprobantes.Table.CurrentRecord.Delete()
                                                                End If
                                                            End If

                                                        Catch ex As Exception
                                                            MsgBox(ex.Message)

                                                        End Try


                                                    Else
                                                        MessageBox.Show("No tiene conexión con el servidor SPK!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                    End If

                                                Else
                                                    EliminarPV(Val(Me.DgvComprobantes.Table.CurrentRecord.GetValue("idDocumento")))
                                                End If
                                                btnAnularVenta.Enabled = True
                                            Catch ex As Exception
                                                btnAnularVenta.Enabled = True
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
                                Dim f As New FormAnularVenta(CDate(Me.DgvComprobantes.Table.CurrentRecord.GetValue("fechaDoc")))
                                f.StartPosition = FormStartPosition.CenterParent
                                f.ShowDialog(Me)
                                If f.Tag IsNot Nothing Then
                                    Dim c = CType(f.Tag, Boolean)
                                    If c = True Then 'fecha dentro del rango permitido

                                        Dim CantNotasActivas = documentoventaabarrotessa.NotasActivas(CInt(Me.DgvComprobantes.Table.CurrentRecord.GetValue("idDocumento")))

                                        If CantNotasActivas > 0 Then
                                            MessageBox.Show("El documento tiene Notas de Credito Activas!", "Debe Anular las notas de credito", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Cursor = Cursors.Default
                                            Exit Sub
                                        End If
                                        Dim objeto As New documentoventaAbarrotes
                                        objeto.idDocumento = CInt(Me.DgvComprobantes.Table.CurrentRecord.GetValue("idDocumento"))
                                        objeto.tipoDocumento = Me.DgvComprobantes.Table.CurrentRecord.GetValue("comprobante")
                                        objeto.serieVenta = Me.DgvComprobantes.Table.CurrentRecord.GetValue("serie")
                                        objeto.numeroVenta = CInt(Me.DgvComprobantes.Table.CurrentRecord.GetValue("numero"))
                                        objeto.fechaDoc = CDate(Me.DgvComprobantes.Table.CurrentRecord.GetValue("fechaDoc"))

                                        Try
                                            If Gempresas.ubigeo > 0 Then

                                                If My.Computer.Network.Ping("138.128.171.106") Then

                                                    Try
                                                        EliminarPV(Val(Me.DgvComprobantes.Table.CurrentRecord.GetValue("idDocumento")))

                                                        If DgvComprobantes.Table.CurrentRecord IsNot Nothing Then
                                                            Dim envio = Me.DgvComprobantes.Table.CurrentRecord.GetValue("enviosunat")
                                                            If envio.ToString.Trim.Length > 0 Then
                                                                EnviarAnulacionDocumento(objeto)
                                                                DgvComprobantes.Table.CurrentRecord.Delete()
                                                            End If
                                                        End If
                                                    Catch ex As Exception
                                                        MsgBox(ex.Message)
                                                    End Try
                                                Else
                                                    MessageBox.Show("No tiene conexión con el servidor SPK!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End If

                                            Else
                                                EliminarPV(Val(Me.DgvComprobantes.Table.CurrentRecord.GetValue("idDocumento")))
                                            End If
                                            btnAnularVenta.Enabled = True
                                        Catch ex As Exception
                                            btnAnularVenta.Enabled = True
                                        End Try
                                    Else
                                        MessageBox.Show("No puede anular la venta, debe estar dentro del rango de 5 días hábiles!", "Validar fechas", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If
                                End If
                            Else
                                MessageBox.Show("No tiene conexión a internet!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If

                    End Select
                    btnAnularVenta.Enabled = True
                Else
                    btnAnularVenta.Enabled = True
                End If




                'End If

            Catch ex As Exception

            End Try




        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub btnImportarExcel_Click(sender As Object, e As EventArgs) Handles btnImportarExcel.Click
        Dim converter As New GroupingGridExcelConverterControl

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Files(*.xls)|*.xls"
        saveFileDialog.DefaultExt = ".xls"


        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            'If radioButton1.Checked Then
            converter.GroupingGridToExcel(Me.DgvComprobantes, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.Visible)
            'ElseIf radioButton2.Checked Then
            '    converter.GroupingGridToExcel(Me.GridGroupingControl1, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.[Default])
            'End If

            If MessageBox.Show("Exportar Registro de Ventas a un archivo excel ahora?", "Exportar a Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim proc As New Process()
                proc.StartInfo.FileName = saveFileDialog.FileName
                proc.Start()
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Cursor = Cursors.WaitCursor
        Dim r As Record = DgvComprobantes.Table.CurrentRecord
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

    Private Sub btnVerDetalle_Click(sender As Object, e As EventArgs) Handles btnVerDetalle.Click
        PictureLoad.Visible = True
        Dim r As Record = Me.DgvComprobantes.Table.CurrentRecord
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

    Private Sub btnAfectaciones_Click(sender As Object, e As EventArgs) Handles btnAfectaciones.Click
        PictureLoad.Visible = True
        Dim r As Record = Me.DgvComprobantes.Table.CurrentRecord
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
End Class
