Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports System.ComponentModel
Imports Syncfusion.GridHelperClasses
Public Class frmMasterGeneralVentas
    Inherits frmMaster
    Dim colorx As New GridMetroColors()
    Dim lblCenter As New Label
    Dim lblPedidosCount As New Label
    Dim lblAnulado As New Label
    Dim lblHistorial As New Label
    Dim lblpedidoGuia As New Label
    Dim listaventa As New List(Of documentoventaAbarrotes)
    Public Property ListadoProveedores As New List(Of entidad)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Meses()
        lblCenter = New Label
        lblPedidosCount = New Label
        lblHistorial = New Label
        lblpedidoGuia = New Label

        GridCFGVenta(dgvVentas)
        GridCFG(dgvCoti)
        GridCFG(dgvCliente)
        Me.WindowState = FormWindowState.Normal
        ' Add any initialization after the InitializeComponent() call.
        'If Not IsNothing(GFichaUsuarios) Then
        '    Dim UsuarioEstadoCaja As New UsuarioEstadoCaja
        '    UsuarioEstadoCaja.GetSaldoActual(GFichaUsuarios)
        '    Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
        'Else
        '    Me.CaptionLabels.RemoveAt(0)
        '    Me.CaptionImages.RemoveAt(0)
        '    '   Me.CaptionImages.RemoveAt(1)
        'End If
        proveeedor()
        ToolStripLabel2.Text = PeriodoGeneral
        NumCotizaciones()
        GetCountPedidos()
        GetCountVentasAnuladas()

        getdatoscenteoVentas()
        GetCargarVentasGuia()
        'GetCountHistorial()
        'GetCountPedidosGuia()
        cboTipoDoc.SelectedIndex = -1
        ComboBoxAdv2.SelectedIndex = -1
    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        'If Not parpadear Then
        '    lblEstado.ForeColor = lblEstado.BackColor
        '    lblEstado.BackColor = Color.Yellow
        'Else
        '    lblEstado.ForeColor = SystemColors.WindowText
        'End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            'lblEstado.ForeColor = Color.Navy
            'lblEstado.BackColor = Color.Transparent
            PanelError.Visible = False
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region
#Region "Métodos"

    Private Sub Meses()
        Dim listaMeses As New List(Of MesesAnio)
        Dim obj As New MesesAnio

        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = listaMeses
        cboMesCompra.SelectedValue = MesGeneral
    End Sub

    Public Sub GetCargarVentasGuia()
        Dim ventaSA As New documentoVentaAbarrotesSA

        listaventa.Clear()
        listaventa = New List(Of documentoventaAbarrotes)
        listaventa = ventaSA.GetListarAllVentasPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral)

        'listaOrdenes.Clear()
        'listaOrdenes = New List(Of documentocompra)
        'listaOrdenes = compraSA.GetListarOrdenComprasFullPorPeriodoGeneral(GEstableciento.IdEstablecimiento, PeriodoGeneral)

        Dim conteoTotal = (From a In listaventa Where a.estadoEntrega = "DC").Count

        Dim conteoPendiente = (From a In listaventa Where a.estadoEntrega = "PN").Count

        'Dim conteoAprobadoTransito = (From a In listaventa Where a.tipoCompra = TIPO_COMPRA.ORDEN_APROBADO_TRANSITO).Count

        lblpedidoGuia.Text = conteoPendiente
        lblHistorial.Text = conteoTotal

    End Sub

    Sub getdatoscenteoVentas()

        lblHistorial.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblHistorial.AutoSize = False
        lblHistorial.BackColor = Color.Transparent
        lblHistorial.Dock = DockStyle.Fill
        lblHistorial.ForeColor = Color.DarkRed
        lblHistorial.TextAlign = ContentAlignment.MiddleLeft

        lblpedidoGuia.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblpedidoGuia.AutoSize = False
        lblpedidoGuia.BackColor = Color.Transparent
        lblpedidoGuia.Dock = DockStyle.Fill
        lblpedidoGuia.ForeColor = Color.DarkRed
        lblpedidoGuia.TextAlign = ContentAlignment.MiddleLeft

        'lblOrdenAprobadoTransito.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        'lblOrdenAprobadoTransito.AutoSize = False
        'lblOrdenAprobadoTransito.BackColor = Color.Transparent
        'lblOrdenAprobadoTransito.Dock = DockStyle.Fill
        'lblOrdenAprobadoTransito.ForeColor = Color.Yellow
        'lblOrdenAprobadoTransito.TextAlign = ContentAlignment.MiddleLeft

    End Sub

    Sub consultarVentasAprobado(strNumero As Integer, srtTipo As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

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

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasGeneralAprobado(GEstableciento.IdEstablecimiento, PeriodoGeneral)

            If (i.NroDocEntidad = strNumero) Then
                If (i.tipoVenta = srtTipo) Then

                    Dim dr As DataRow = dt.NewRow()
                    str = Nothing
                    str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                    dr(0) = i.idDocumento
                    dr(1) = i.tipoVenta
                    dr(2) = str
                    dr(4) = i.tipoDocumento
                    dr(5) = i.serie
                    Select Case i.tipoVenta
                        Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                            'If i.tipoVenta = TIPO_VENTA.VENTA_AL_TICKET Then
                            '    dr(1) = "Venta Ticket"
                            'ElseIf i.tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA Then
                            '    dr(1) = "Venta Ticket directa"
                            'End If
                            dr(3) = i.nombrePedido
                            dr(6) = i.numeroDoc

                        Case TIPO_VENTA.COTIZACION
                            '    dr(1) = "Cotización"
                            dr(3) = i.nombrePedido
                            dr(6) = i.numeroDoc

                        Case TIPO_VENTA.VENTA_GENERAL

                            '    dr(1) = "Venta General"
                            dr(3) = "-"
                            dr(6) = i.numeroDocNormal

                        Case "NTC"
                            '   dr(1) = "Nota de crédito"
                            dr(3) = "-"
                            dr(6) = i.numeroDocNormal
                    End Select

                    dr(7) = i.NroDocEntidad
                    dr(8) = i.NombreEntidad
                    dr(9) = FormatNumber(i.ImporteNacional, 2)
                    dr(10) = i.tipoCambio
                    dr(11) = FormatNumber(i.ImporteExtranjero, 2)
                    dr(12) = i.moneda
                    dr(13) = i.usuarioActualizacion

                    Select Case i.tipoVenta
                        Case "NTC"
                            dr(14) = "-"
                        Case Else
                            Select Case i.usuarioActualizacion
                                Case TipoGuia.Entregado
                                    dr(14) = "CONFORME"
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

                    dt.Rows.Add(dr)

                End If
            End If

        Next
        dgvConfirmar.DataSource = dt
    End Sub

    Sub consultarVenta(strNumero As Integer, tipo As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String))) '5
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal))) '10
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoEntrega", GetType(String))) '15

        Dim str As String

        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasGeneralesPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral)

            If (i.NroDocEntidad = strNumero) Then
                If (i.tipoVenta = tipo) Then

                    Dim dr As DataRow = dt.NewRow()
                    str = Nothing
                    str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                    dr(0) = i.idDocumento
                    dr(1) = i.tipoVenta
                    dr(2) = str
                    dr(4) = i.tipoDocumento
                    dr(5) = i.serie
                    Select Case i.tipoVenta
                        Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                            'If i.tipoVenta = TIPO_VENTA.VENTA_AL_TICKET Then
                            '    dr(1) = "Venta Ticket"
                            'ElseIf i.tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA Then
                            '    dr(1) = "Venta Ticket directa"
                            'End If
                            dr(3) = i.nombrePedido
                            dr(6) = i.numeroDoc

                        Case TIPO_VENTA.COTIZACION
                            '    dr(1) = "Cotización"
                            dr(3) = i.nombrePedido
                            dr(6) = i.numeroDoc

                        Case TIPO_VENTA.VENTA_GENERAL

                            '    dr(1) = "Venta General"
                            dr(3) = "-"
                            dr(6) = i.numeroDocNormal

                        Case "NTC"
                            '   dr(1) = "Nota de crédito"
                            dr(3) = "-"
                            dr(6) = i.numeroDocNormal
                    End Select

                    dr(7) = i.NroDocEntidad
                    dr(8) = i.NombreEntidad
                    dr(9) = FormatNumber(i.ImporteNacional, 2)
                    dr(10) = i.tipoCambio
                    dr(11) = FormatNumber(i.ImporteExtranjero, 2)
                    dr(12) = i.moneda
                    dr(13) = i.usuarioActualizacion

                    Select Case i.tipoVenta
                        Case "NTC"
                            dr(14) = "-"
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


                    'Select Case i.notaCredito
                    '    Case StatusVentaMatizados.PorPreparar
                    '        dr(15) = "Pendiente"
                    '    Case StatusVentaMatizados.TerminadaYentregada
                    '        dr(15) = "Entregada"
                    'End Select

                    Select Case i.estadoEntrega
                        Case TipoEntregado.Entregado
                            dr(15) = "Entregado"
                        Case TipoEntregado.PorEntregar
                            dr(15) = "Por Entregar/Parcial"

                    End Select

                    dt.Rows.Add(dr)
                End If
            End If

        Next
        dgvVentaGeneral.DataSource = dt

    End Sub

    Sub proveeedor()
        Dim entidadSA As New entidadSA
        ListadoProveedores = New List(Of entidad)
        ListadoProveedores = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.CLIENTE, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
    End Sub

    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA

        Try
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ObtenerListaGuiaRemision(iddocumento As Integer)
        Dim DocumentoGuiaSA As New DocumentoGuiaSA

        Dim documentoGuia As New List(Of documentoGuia)

        documentoGuia = DocumentoGuiaSA.ListaGuiasPorCompra(iddocumento)

        Dim dt As New DataTable("Entidades financieras")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer))) '0
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaTraslado", GetType(String)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String))) '3
        dt.Columns.Add(New DataColumn("direccionPartida", GetType(String)))
        dt.Columns.Add(New DataColumn("idEntidadTransporte", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nombrentidad", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String))) '7

        For Each i In documentoGuia
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.idDocumento
            dr(1) = i.fechaDoc
            dr(2) = i.fechaTraslado
            Select Case i.monedaDoc
                Case 1
                    dr(3) = "NACIONAL"
                Case 2
                    dr(3) = "EXTRANJERA"
            End Select


            dr(4) = i.direccionPartida
            dr(5) = i.idEntidad
            dr(6) = i.usuarioActualizacion

            Select Case i.estado
                Case TipoGuia.Pendiente
                    dr(7) = "POR CONFIRMAR"
                Case TipoGuia.Transito
                    dr(7) = "PARCIAL"
                Case TipoGuia.Entregado
                    dr(7) = "CONFORME"
            End Select



            dt.Rows.Add(dr)

        Next
        GridGroupingControl2.DataSource = dt

    End Sub

    Public Sub ObtenerListaGuiaRemisionCompleto(iddocumento As Integer, strTipo As String)
        Dim DocumentoGuiaSA As New DocumentoGuiaSA

        Dim documentoGuia As New List(Of documentoGuia)

        If (strTipo = "CENTIDAD") Then
            documentoGuia = DocumentoGuiaSA.ListaGuiasPorCompra(iddocumento)
        Else
            documentoGuia = DocumentoGuiaSA.ListaGuiasPorCompraSinEntidad(iddocumento)
        End If


        Dim dt As New DataTable("Entidades financieras")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer))) '0
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaTraslado", GetType(String)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String))) '3
        dt.Columns.Add(New DataColumn("direccionPartida", GetType(String)))
        dt.Columns.Add(New DataColumn("idEntidadTransporte", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nombrentidad", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String))) '7

        For Each i In documentoGuia
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.idDocumento
            dr(1) = i.fechaDoc
            dr(2) = i.fechaTraslado
            Select Case i.monedaDoc
                Case 1
                    dr(3) = "NACIONAL"
                Case 2
                    dr(3) = "EXTRANJERA"
            End Select


            dr(4) = i.direccionPartida
            dr(5) = i.idEntidad
            dr(6) = i.usuarioActualizacion

            Select Case i.estado
                Case TipoGuia.Pendiente
                    dr(7) = "PENDIENTE"
                Case TipoGuia.Transito
                    dr(7) = "PARCIAL"
                Case TipoGuia.Entregado
                    dr(7) = "CONFORME"
            End Select

            dt.Rows.Add(dr)

        Next
        dgvHistorialConforme.DataSource = dt

    End Sub

    Public Sub ObtenerListaGuiaFuLL()
        Dim DocumentoGuiaSA As New DocumentoGuiaSA

        Dim documentoGuia As New List(Of documentoGuia)

        documentoGuia = DocumentoGuiaSA.UbicarGuiaPendiente()

        Dim dt As New DataTable("Entidades financieras")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("secuencia", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(Integer)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        For Each i In documentoGuia
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.idDocumento
            dr(1) = i.codigoLibro
            dr(2) = i.tipoDoc
            dr(3) = i.fechaDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = "PENDIENTE"

            dt.Rows.Add(dr)

        Next
        dgvConfirmar.DataSource = dt

    End Sub

    Private Sub GetListaVentasGeneralPorPeridod()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String))) '5
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal))) '10
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoEntrega", GetType(String))) '15

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasGeneralesPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str
            dr(4) = i.tipoDocumento
            dr(5) = i.serie
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    'If i.tipoVenta = TIPO_VENTA.VENTA_AL_TICKET Then
                    '    dr(1) = "Venta Ticket"
                    'ElseIf i.tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA Then
                    '    dr(1) = "Venta Ticket directa"
                    'End If
                    'dr(3) = i.nombrePedido
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.COTIZACION
                    '    dr(1) = "Cotización"
                    'dr(3) = i.nombrePedido
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL

                    '    dr(1) = "Venta General"
                    'dr(3) = "-"
                    dr(6) = i.numeroDocNormal

                Case "NTC"
                    '   dr(1) = "Nota de crédito"
                    'dr(3) = "-"
                    dr(6) = i.numeroDocNormal
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

            'dr(7) = i.NroDocEntidad
            'dr(8) = i.NombreEntidad
            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"
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

            'Select Case i.notaCredito
            '    Case StatusVentaMatizados.PorPreparar
            '        dr(15) = "Pendiente"
            '    Case StatusVentaMatizados.TerminadaYentregada
            '        dr(15) = "Entregada"
            'End Select

            Select Case i.estadoEntrega
                Case TipoEntregado.Entregado
                    dr(15) = "Entregado"
                Case TipoEntregado.PorEntregar
                    dr(15) = "Por Entregar/Parcial"

            End Select

            dt.Rows.Add(dr)
        Next
        dgvVentaGeneral.DataSource = dt

    End Sub

    Private Sub GetListaVentasGeneralAprobado()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

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

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasGeneralAprobado(GEstableciento.IdEstablecimiento, PeriodoGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str
            dr(4) = i.tipoDocumento
            dr(5) = i.serie
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    'If i.tipoVenta = TIPO_VENTA.VENTA_AL_TICKET Then
                    '    dr(1) = "Venta Ticket"
                    'ElseIf i.tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA Then
                    '    dr(1) = "Venta Ticket directa"
                    'End If
                    'dr(3) = i.nombrePedido
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.COTIZACION
                    '    dr(1) = "Cotización"
                    'dr(3) = i.nombrePedido
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL

                    '    dr(1) = "Venta General"
                    'dr(3) = "-"
                    dr(6) = i.numeroDocNormal

                Case "NTC"
                    '   dr(1) = "Nota de crédito"
                    'dr(3) = "-"
                    dr(6) = i.numeroDocNormal
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

            'dr(7) = i.NroDocEntidad
            'dr(8) = i.NombreEntidad
            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"
                Case Else
                    Select Case i.usuarioActualizacion
                        Case TipoGuia.Entregado
                            dr(14) = "CONFORME"
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

            dt.Rows.Add(dr)
        Next
        dgvConfirmar.DataSource = dt

    End Sub

    Public Sub GetCountVentasAnuladas()

        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA
        Dim cant As New List(Of documentoventaAbarrotes)

        cant = DocumentoVentaSA.GetListarAllVentasPeriodoAnulado(GEstableciento.IdEstablecimiento, PeriodoGeneral)
        '   lblCenter = New Label
        lblAnulado.Text = cant.Count
        lblAnulado.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblAnulado.AutoSize = False
        lblAnulado.BackColor = Color.Transparent
        lblAnulado.Dock = DockStyle.Fill
        lblAnulado.ForeColor = Color.DarkRed
        lblAnulado.TextAlign = ContentAlignment.MiddleLeft

    End Sub

    Public Sub GetCountHistorial()
        Dim ventaSA As New documentoVentaAbarrotesSA

        Dim venta = ventaSA.GetConteoPedidosAprobado(GEstableciento.IdEstablecimiento, PeriodoGeneral, "DC")
        '   lblCenter = New Label
        lblHistorial.Text = venta
        lblHistorial.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblHistorial.AutoSize = False
        lblHistorial.BackColor = Color.Transparent
        lblHistorial.Dock = DockStyle.Fill
        lblHistorial.ForeColor = Color.DarkRed
        lblHistorial.TextAlign = ContentAlignment.MiddleLeft

    End Sub
    Public Sub GetCountPedidosGuia()
        Dim ventaSA As New documentoVentaAbarrotesSA

        Dim venta = ventaSA.GetConteoPedidosAprobado(GEstableciento.IdEstablecimiento, PeriodoGeneral, "PN")
        '   lblCenter = New Label
        lblpedidoGuia.Text = venta
        lblpedidoGuia.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblpedidoGuia.AutoSize = False
        lblpedidoGuia.BackColor = Color.Transparent
        lblpedidoGuia.Dock = DockStyle.Fill
        lblpedidoGuia.ForeColor = Color.DarkRed
        lblpedidoGuia.TextAlign = ContentAlignment.MiddleLeft

    End Sub
    Public Sub GetCountPedidos()
        Dim ventaSA As New documentoVentaAbarrotesSA

        Dim venta = ventaSA.GetConteoPedidos(GEstableciento.IdEstablecimiento, PeriodoGeneral)
        '   lblCenter = New Label
        lblPedidosCount.Text = venta
        lblPedidosCount.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblPedidosCount.AutoSize = False
        lblPedidosCount.BackColor = Color.Transparent
        lblPedidosCount.Dock = DockStyle.Fill
        lblPedidosCount.ForeColor = Color.DarkRed
        lblPedidosCount.TextAlign = ContentAlignment.MiddleLeft

    End Sub

    Sub ElimnarCliente()
        Dim UsuarioEstadoCaja As New UsuarioEstadoCaja
        Dim entidad As New entidadSA
        Dim objEntidad As New entidad
        If Not IsNothing(Me.dgvCliente.Table.CurrentRecord) Then

            With objEntidad
                .idEntidad = Me.dgvCliente.Table.CurrentRecord.GetValue("idEntidad")
            End With

            entidad.DeleteEntidad(objEntidad)
            Me.dgvCliente.Table.CurrentRecord.Delete()
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            lblEstado.Text = "Proveedor eliminada!"

        End If
    End Sub

    Private Sub NumCotizaciones()
        Dim ventaSA As New documentoVentaAbarrotesSA

        lblCenter.Text = ventaSA.GetVentasPeriodoByClienteConteo(New documentoventaAbarrotes With {.idEstablecimiento = GEstableciento.IdEstablecimiento, .fechaPeriodo = PeriodoGeneral,
                                                                                                                       .idCliente = txtCliente.Tag})

    End Sub

    Public Sub UbicarEntidadPorRuc(strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                TextBoxExt2.Text = .nombreCompleto
                TextBoxExt2.Tag = .idEntidad
                '   txtCuenta.Text = .cuentaAsiento
                TextBoxExt1.Text = .nrodoc
            End With
        Else
            TextBoxExt2.Clear()
            '  txtCuenta.Clear()
            TextBoxExt1.Clear()
            If MessageBoxAdv.Show("Desea crear un nuevo cliente?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Dim f As New frmCrearENtidades
                f.CaptionLabels(0).Text = "Nuevo proveedor"
                f.strTipo = TIPO_ENTIDAD.CLIENTE
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        End If
    End Sub


    Public Sub UbicarEntidadPorRuc2(strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                TextBoxExt3.Text = .nombreCompleto
                TextBoxExt3.Tag = .idEntidad
                '   txtCuenta.Text = .cuentaAsiento
                TextBoxExt4.Text = .nrodoc
            End With
        Else
            TextBoxExt3.Clear()
            '  txtCuenta.Clear()
            TextBoxExt4.Clear()
            If MessageBoxAdv.Show("Desea crear un nuevo cliente?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Dim f As New frmCrearENtidades
                f.CaptionLabels(0).Text = "Nuevo proveedor"
                f.strTipo = TIPO_ENTIDAD.CLIENTE
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        End If
    End Sub
#Region "CLIENTES"
    Private Sub GetListaVentasPorPeriodoAnulado()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

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

        'lower case p
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasPeriodoAnulado(GEstableciento.IdEstablecimiento, PeriodoGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serie
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    'If i.tipoVenta = TIPO_VENTA.VENTA_AL_TICKET Then
                    '    dr(1) = "Venta Ticket"
                    'ElseIf i.tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA Then
                    '    dr(1) = "Venta Ticket directa"
                    'End If
                    'dr(3) = i.nombrePedido
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.COTIZACION
                    '    dr(1) = "Cotización"
                    'dr(3) = i.nombrePedido
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL

                    '    dr(1) = "Venta General"
                    'dr(3) = "-"
                    dr(6) = i.numeroDocNormal

                Case "NTC"
                    '   dr(1) = "Nota de crédito"
                    'dr(3) = "-"
                    dr(6) = i.numeroDocNormal
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

            'dr(7) = i.NroDocEntidad
            'dr(8) = i.NombreEntidad
            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"
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


            dt.Rows.Add(dr)
        Next
        GridGroupingControl1.DataSource = dt

    End Sub

    Private Sub GetListaNotasPedido()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Pedidos - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

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

        'lower case p
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        Dim str As String

        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllNotasPedido(GEstableciento.IdEstablecimiento, PeriodoGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serie
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_NOTA_PEDIDO
                    'dr(3) = i.nombrePedido
                    dr(6) = i.numeroDoc
                Case TIPO_VENTA.VENTA_GENERAL
                    'dr(3) = "-"
                    dr(6) = i.numeroDocNormal
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

            'dr(7) = i.NroDocEntidad
            'dr(8) = i.NombreEntidad
            dr(9) = i.ImporteNacional
            dr(10) = i.tipoCambio
            dr(11) = i.ImporteExtranjero
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion
            dr(14) = i.estadoCobro

            dt.Rows.Add(dr)
        Next
        dgvVentas.DataSource = dt

    End Sub



    Private Sub GetListaVentasPorPeriodo()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas de - " & cboMesCompra.SelectedValue & "/" & AnioGeneral)
        Dim documentoCajaSA As New DocumentoCajaSA

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


        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasPeriodo(GEstableciento.IdEstablecimiento, cboMesCompra.SelectedValue & "/" & AnioGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serie
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    'If i.tipoVenta = TIPO_VENTA.VENTA_AL_TICKET Then
                    '    dr(1) = "Venta Ticket"
                    'ElseIf i.tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA Then
                    '    dr(1) = "Venta Ticket directa"
                    'End If
                    'dr(3) = i.nombrePedido
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.COTIZACION
                    '    dr(1) = "Cotización"
                    'dr(3) = i.nombrePedido
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL

                    '    dr(1) = "Venta General"
                    'dr(3) = "-"
                    dr(6) = i.numeroDocNormal

                Case "NTC"
                    '   dr(1) = "Nota de crédito"
                    'dr(3) = "-"
                    dr(6) = i.numeroDocNormal
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

            dt.Rows.Add(dr)
        Next
        dgvVentas.DataSource = dt

    End Sub

    Private Sub GetVentasPeriodoByCliente()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal"))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS"))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))

        'lower case p
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetVentasPeriodoByCliente(New documentoventaAbarrotes With {.idEstablecimiento = GEstableciento.IdEstablecimiento, .fechaPeriodo = PeriodoGeneral,
                                                                                                                              .idCliente = txtCliente.Tag})
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serie
            dr(6) = String.Format("{0:00000000}", CInt(i.numeroDoc))

            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = CDec(i.ImporteNacional).ToString("N2")
            dr(10) = i.tipoCambio
            dr(11) = CDec(i.ImporteExtranjero).ToString("N2")
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion
            dr(14) = If(i.estadoCobro = "PN", "Pendiente", "Venta")

            dt.Rows.Add(dr)
        Next
        dgvCoti.DataSource = dt

    End Sub

    Public Sub EliminarAnticipo(IntIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim objDocumento As New documento

        With objDocumento
            .idDocumento = IntIdDocumento
        End With
        documentoSA.DeleteAnticipoSL(objDocumento)
    End Sub


    Private Sub ListaClientes()
        Dim dt As New DataTable()
        Dim entidad As New entidadSA

        dt.Columns.Add("idEntidad")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("nroDoc")
        dt.Columns.Add("tipo")
        dt.Columns.Add("razon")
        dt.Columns.Add("direc")
        dt.Columns.Add("fono")

        For Each i In entidad.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.CLIENTE, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idEntidad
            Select Case i.tipoDoc
                Case "6"
                    dr(1) = "RUC"
                Case "1"
                    dr(1) = "DNI"
                Case "7"
                    dr(1) = "PASSAPORTE"
                Case "4"
                    dr(1) = "CARNET DE EXTRANJERIA"
            End Select

            dr(2) = i.nrodoc
            dr(3) = IIf(i.tipoPersona = "N", "NATURAL", "JURIDICO")
            dr(4) = i.nombreCompleto
            dr(5) = i.direccion
            dr(6) = i.telefono
            dt.Rows.Add(dr)
        Next
        dgvCliente.DataSource = dt
    End Sub
#End Region
    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub
    Sub GridCFGVenta(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Public Sub EliminarNota(intIdDocumentoNota As Integer)
        Dim compraSA As New documentoVentaAbarrotesSA
        Dim objDocumento As New documento
        Dim notaCredito As documentoventaAbarrotes
        Try
            notaCredito = compraSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumentoNota)
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .IdDocumentoAfectado = notaCredito.idPadre ' venta
                .idDocumento = intIdDocumentoNota
            End With
            compraSA.EliminarNotaCreditoMetodoVenta(objDocumento)
            Me.dgvVentas.Table.CurrentRecord.Delete()
            lblEstado.Text = "Nota eliminada correctamente!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Public Sub EliminarPVDirecta(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim objDocumento As New documento
        Try
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = intIdDocumento
            End With

            documentoSA.EliminarConsumoDirecto(objDocumento)
            'documentoSA.EliminarVentaTicketDirecta(objDocumento)

            Me.dgvVentas.Table.CurrentRecord.Delete()
            lblEstado.Text = "Pedido eliminado!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Public Sub EliminarVentaGeneral(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim objDocumento As New documento
        Try
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = intIdDocumento
            End With

            documentoSA.EliminarVentaGeneralPV(objDocumento)
            'Me.dgvVentas.Table.CurrentRecord.Delete()
            lblEstado.Text = "Venta Anulada!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Public Sub EliminarPV(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim objDocumento As New documento
        Try
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = intIdDocumento
            End With

            documentoSA.EliminarVentaGeneralPV(objDocumento)
            Me.dgvVentas.Table.CurrentRecord.Delete()
            lblEstado.Text = "Pedido eliminado!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Public Sub EliminarNotaDebito(intIdDocumentoNota As Integer)
        Dim compraSA As New documentoVentaAbarrotesSA
        Dim objDocumento As New documento
        Dim notaCredito As documentoventaAbarrotes
        Try
            notaCredito = compraSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumentoNota)
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .IdDocumentoAfectado = notaCredito.idPadre ' venta
                .idDocumento = intIdDocumentoNota
                .ImporteMN = dgvVentas.Table.CurrentRecord.GetValue("importeTotal")
                .ImporteME = dgvVentas.Table.CurrentRecord.GetValue("importeUS")
            End With
            compraSA.EliminarNotaDebitoVenta(objDocumento)
            Me.dgvVentas.Table.CurrentRecord.Delete()
            lblEstado.Text = "Nota eliminada correctamente!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub
#End Region

    Private Function MatarProceso(ByVal StrNombreProceso As String, _
   Optional ByVal DecirSINO As Boolean = True) As Boolean
        ' Variables para usar Wmi  
        Dim ListaProcesos As Object
        Dim ObjetoWMI As Object
        Dim ProcesoACerrar As Object

        MatarProceso = False

        ObjetoWMI = GetObject("winmgmts:")

        If ObjetoWMI Is DBNull.Value = False Then

            'instanciamos la variable  
            ListaProcesos = ObjetoWMI.InstancesOf("win32_process")

            For Each ProcesoACerrar In ListaProcesos
                If UCase(ProcesoACerrar.Name) = UCase(StrNombreProceso) Then
                    If DecirSINO Then
                        '   If MsgBox("¿Matar el proceso " & _
                        'ProcesoACerrar.Name & vbNewLine & "...¿Está seguro?", _
                        '                      vbYesNo + vbCritical) = vbYes Then
                        ProcesoACerrar.Terminate(0)
                        MatarProceso = True
                        '  End If
                    Else
                        'Matamos el proceso con el método Terminate  
                        ProcesoACerrar.Terminate(0)
                        MatarProceso = True
                    End If
                End If

            Next
        End If

        'Elimina las variables  
        ListaProcesos = Nothing
        ObjetoWMI = Nothing
    End Function

    Private Sub frmMasterGeneralVentas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
        '    Case 2
        '        If MessageBoxAdv.Show("S O F T - P A C K, ¿Desea salir?", "Salir del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        '            MatarProceso("SMSvcHost.exe")
        '            Application.ExitThread()
        '        Else
        '            e.Cancel = True
        '        End If
        '    Case Else
        Dispose()
        'End Select
    End Sub

    Private Sub frmMasterGeneralVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtAnioCompra.Text = AnioGeneral
        treeViewAdv2.BackColor = Color.FromArgb(240, 158, 80)
        TabPageAdv1.Parent = TabControlAdv1
        TabCotizacion.Parent = Nothing
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = Nothing

        lblCenter.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblCenter.AutoSize = False
        lblCenter.BackColor = Color.Transparent
        lblCenter.Dock = DockStyle.Fill
        lblCenter.ForeColor = Color.DarkRed
        lblCenter.TextAlign = ContentAlignment.MiddleLeft

        Me.treeViewAdv2.Nodes(0).CustomControl = lblCenter ' Contozaciones
        Me.treeViewAdv2.Nodes(1).CustomControl = lblPedidosCount ' Pedidos
        Me.treeViewAdv2.Nodes(3).CustomControl = lblAnulado ' Anulados


        Me.treeViewAdv2.Nodes(6).CustomControl = lblpedidoGuia  ' Anulados
        Me.treeViewAdv2.Nodes(7).CustomControl = lblHistorial  ' Anulados

        treeViewAdv2.Nodes.RemoveAt(5)
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Venta de Existencias, Servicios y Activo Inmv."
                Dim f As New frmVenta
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.ShowDialog()
                Dim SaldoCaja As New UsuarioEstadoCaja
                SaldoCaja.GetSaldoActual(GFichaUsuarios)
                Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
            Case "POS - Venta de existencias."
                Dim f As New frmVentaPV
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                'f.txtFecha.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                'f.txtFecha.CustomFormat = "dd/MM/yyyy HH:mm tt"
                f.StartPosition = FormStartPosition.CenterScreen
                f.Show()
            Case "Administración de Clientes"
                Dim f As New frmCrearENtidades
                f.CaptionLabels(0).Text = "Nuevo cliente"
                f.strTipo = TIPO_ENTIDAD.CLIENTE
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            Case "Notas de Crédito"
                If Not IsNothing(GFichaUsuarios) Then
                    Dim f As New frmNotaVentaNew
                    f.ShowDialog()
                    Dim SaldoCaja As New UsuarioEstadoCaja
                    SaldoCaja.GetSaldoActual(GFichaUsuarios)
                    Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
                Else
                    lblEstado.Text = "Debe iniciar una caja, para realizar està tarea!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
            Case "Notas de Débito"
                If Not IsNothing(GFichaUsuarios) Then
                    Dim f As New frmNotaDebitoVenta
                    f.ShowDialog()
                    Dim SaldoCaja As New UsuarioEstadoCaja
                    SaldoCaja.GetSaldoActual(GFichaUsuarios)
                    Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
                Else
                    lblEstado.Text = "Debe iniciar una caja, para realizar està tarea!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub treeViewAdv2_AfterSelect(sender As Object, e As EventArgs) Handles treeViewAdv2.AfterSelect
        Me.Cursor = Cursors.WaitCursor

        Select Case treeViewAdv2.SelectedNode.Text
            Case "Administración de Clientes"
                GridCFG(dgvCliente)

                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = TabControlAdv1
                TabCotizacion.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                tabConfirmarGuia.Parent = Nothing
                ListaClientes()
            Case "Ventas del período"

                GridCFGVenta(dgvVentas)
                TabPageAdv1.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                TabCotizacion.Parent = Nothing
                GetListaVentasPorPeriodo()
                TabPageAdv3.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                tabConfirmarGuia.Parent = Nothing
            Case "Notas Pedido"
                TabPageAdv1.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                TabCotizacion.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                tabConfirmarGuia.Parent = Nothing
                GetListaNotasPedido()
            Case "Cotizaciones"
                GridCFG(dgvCoti)
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                tabConfirmarGuia.Parent = Nothing
                TabCotizacion.Parent = TabControlAdv1
            Case "Ventas Anuladas"
                GridCFG(GridGroupingControl1)
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabCotizacion.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                tabConfirmarGuia.Parent = Nothing
                TabPageAdv3.Parent = TabControlAdv1
                GetListaVentasPorPeriodoAnulado()
            Case "Pendiente de entrega"
                GridCFGVenta(GridGroupingControl2)
                GridCFGVenta(dgvVentaGeneral)
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabCotizacion.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                tabConfirmarGuia.Parent = Nothing
                TabVentaGeneral.Parent = TabControlAdv1
                GetListaVentasGeneralPorPeridod()
                ToolStripButton7.Visible = True
                ToolStripButton8.Visible = True
            Case "Historial"
                GridCFGVenta(dgvConfirmar)
                GridCFGVenta(dgvHistorialConforme)
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabCotizacion.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                tabConfirmarGuia.Parent = TabControlAdv1
                TabVentaGeneral.Parent = Nothing
                GetListaVentasGeneralAprobado()
                GridGroupingControl2.Table.Records.DeleteAll()

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub treeViewAdv2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles treeViewAdv2.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Administración de Clientes"
                ListaClientes()
            Case "Ventas del período"

            Case "Notas Pedido"
                GetListaNotasPedido()

            Case "Cotizaciones"

            Case "Ventas Anuladas"

                GetListaVentasPorPeriodoAnulado()

            Case "Pendiente de entrega"

                GetListaVentasGeneralPorPeridod()

            Case "Historial"

                GetListaVentasGeneralAprobado()

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click

    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            If Not IsNothing(Me.dgvVentas.Table.CurrentRecord) Then
                Select Case Me.dgvVentas.Table.CurrentRecord.GetValue("tipoCompra")
                    Case TIPO_VENTA.VENTA_GENERAL
                        Dim f As New frmVenta(Me.dgvVentas.Table.CurrentRecord.GetValue("idDocumento"))
                        'f.WindowState = FormWindowState.Maximized
                        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        f.ShowDialog()
                    Case TIPO_VENTA.VENTA_NOTA_PEDIDO
                        Dim f As New frmVentaPV(Me.dgvVentas.Table.CurrentRecord.GetValue("idDocumento"))
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        f.ShowDialog()

                    Case TIPO_VENTA.VENTA_POS_DIRECTA
                        Dim f As New frmVentaPVdirecta(Me.dgvVentas.Table.CurrentRecord.GetValue("idDocumento"))
                        'f.WindowState = FormWindowState.Maximized
                        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        f.ShowDialog()
                    Case TIPO_VENTA.VENTA_AL_TICKET
                        Dim f As New frmVentaPV(Me.dgvVentas.Table.CurrentRecord.GetValue("idDocumento"))
                        'f.WindowState = FormWindowState.Maximized
                        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        f.ShowDialog()

                End Select
            Else
                MessageBox.Show("Debe seleccionar un pedido/venta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        ElseIf TabControlAdv1.SelectedTab Is TabPageAdv2 Then
            If Not IsNothing(dgvCliente.Table.CurrentRecord) Then
                If dgvCliente.Table.CurrentRecord.GetValue("razon") <> "CLIENTES VARIOS" Then
                    Dim f As New frmCrearENtidades
                    f.CaptionLabels(0).Text = "Editar cliente"
                    f.strTipo = TIPO_ENTIDAD.CLIENTE
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.intIdEntidad = Me.dgvCliente.Table.CurrentRecord.GetValue("idEntidad")
                    f.UbicarEntidad(Me.dgvCliente.Table.CurrentRecord.GetValue("idEntidad"))
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                End If

            Else
                MessageBox.Show("Debe seleccionar un cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        ElseIf TabControlAdv1.SelectedTab Is TabCotizacion Then
            If Not IsNothing(dgvCoti.Table.CurrentRecord) Then
                Dim f As New frmVentaPV(Me.dgvCoti.Table.CurrentRecord.GetValue("idDocumento"))
                f.WindowState = FormWindowState.Maximized
                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.ShowDialog()
            Else
                MessageBox.Show("Debe seleccionar una cotización!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            If Not IsNothing(Me.dgvVentas.Table.CurrentRecord) Then
                If MessageBox.Show("Desea Elimiar el item seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Select Case Me.dgvVentas.Table.CurrentRecord.GetValue("tipoCompra")
                        Case TIPO_COMPRA.NOTA_CREDITO
                            EliminarNota(Me.dgvVentas.Table.CurrentRecord.GetValue("idDocumento"))

                        Case TIPO_COMPRA.NOTA_DEBITO
                            EliminarNotaDebito(Me.dgvVentas.Table.CurrentRecord.GetValue("idDocumento"))

                        Case TIPO_VENTA.VENTA_NOTA_PEDIDO
                            EliminarPV(Me.dgvVentas.Table.CurrentRecord.GetValue("idDocumento"))
                        Case TIPO_VENTA.VENTA_GENERAL
                            'se elimina atraves de las notas de credito

                            EliminarVentaGeneral(Val(Me.dgvVentas.Table.CurrentRecord.GetValue("idDocumento")))
                        Case TIPO_VENTA.VENTA_POS_DIRECTA, TIPO_VENTA.VENTA_AL_TICKET
                            EliminarPVDirecta(Val(Me.dgvVentas.Table.CurrentRecord.GetValue("idDocumento")))
                    End Select
                    GetCountVentasAnuladas()
                End If
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        ElseIf (TabControlAdv1.SelectedTab Is TabPageAdv2) Then
            Dim documentoVentasSA As New documentoVentaAbarrotesSA
            Dim SumVentaProveedor As Integer = 0
            If Not IsNothing(Me.dgvCliente.Table.CurrentRecord) Then
                SumVentaProveedor = documentoVentasSA.UbicarVentaPorClienteXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Me.dgvCliente.Table.CurrentRecord.GetValue("nroDoc"), PeriodoGeneral).Count

                If (SumVentaProveedor = 0) Then
                    ElimnarCliente()
                Else
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    lblEstado.Text = "El Cliente tiene movimientos, error al eliminar!"
                End If
            End If

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        GetCountPedidos()
        GetCountVentasAnuladas()
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Administración de Clientes"
                ListaClientes()
            Case "Ventas del período"
                '     GetListaVentasPorPeriodo()
            Case "Cotizaciones"
                '   GetVentasPeriodoByProveedor()
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        Dim f As New frmVenta
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.ShowDialog()
        'Dim SaldoCaja As New UsuarioEstadoCaja
        'SaldoCaja.GetSaldoActual(GFichaUsuarios)
        'Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        Dim f As New frmVentaPV
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.txtFecha.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
        'f.txtFecha.CustomFormat = "dd/MM/yyyy HH:mm tt"
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.Click
        'If Not IsNothing(GFichaUsuarios) Then
        Dim f As New frmNotaVentaNew
        f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
        f.ShowDialog()
        '    Dim SaldoCaja As New UsuarioEstadoCaja
        '    SaldoCaja.GetSaldoActual(GFichaUsuarios)
        '    Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
        'Else
        '    lblEstado.Text = "Debe iniciar una caja, para realizar està tarea!"
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        'End If
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        'If Not IsNothing(GFichaUsuarios) Then
        Dim f As New frmNotaDebitoVenta
        f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        'Dim SaldoCaja As New UsuarioEstadoCaja
        'SaldoCaja.GetSaldoActual(GFichaUsuarios)
        'Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
        'Else
        'lblEstado.Text = "Debe iniciar una caja, para realizar està tarea!"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)
        'End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)

    End Sub
    Dim filter As New GridExcelFilter()
    Private Sub ToolStripButton15_Click(sender As Object, e As EventArgs) Handles ToolStripButton15.Click
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            filter.ClearFilters(Me.dgvVentas)
            Me.dgvVentas.TopLevelGroupOptions.ShowFilterBar = False
        ElseIf TabControlAdv1.SelectedTab Is TabPageAdv2 Then
            filter.ClearFilters(Me.dgvCliente)
            Me.dgvCliente.TopLevelGroupOptions.ShowFilterBar = False
        End If

    End Sub

    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs) Handles ToolStripButton16.Click
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            dgvVentas.TableDescriptor.GroupedColumns.Clear()
            If dgvVentas.ShowGroupDropArea = True Then
                dgvVentas.ShowGroupDropArea = False
            Else
                dgvVentas.ShowGroupDropArea = True
            End If
        ElseIf TabControlAdv1.SelectedTab Is TabPageAdv2 Then
            dgvCliente.TableDescriptor.GroupedColumns.Clear()
            If dgvCliente.ShowGroupDropArea = True Then
                dgvCliente.ShowGroupDropArea = False
            Else
                dgvCliente.ShowGroupDropArea = True
            End If
        End If
    End Sub

    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs) Handles ToolStripButton17.Click
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            Me.dgvVentas.TopLevelGroupOptions.ShowFilterBar = True
            Me.dgvVentas.NestedTableGroupOptions.ShowFilterBar = True
            Me.dgvVentas.ChildGroupOptions.ShowFilterBar = True

            For Each col As GridColumnDescriptor In Me.dgvVentas.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True

            Me.dgvVentas.OptimizeFilterPerformance = True
            Me.dgvVentas.ShowNavigationBar = True

            filter.WireGrid(dgvVentas)
        ElseIf TabControlAdv1.SelectedTab Is TabPageAdv2 Then

            Me.dgvCliente.TopLevelGroupOptions.ShowFilterBar = True
            Me.dgvCliente.NestedTableGroupOptions.ShowFilterBar = True
            Me.dgvCliente.ChildGroupOptions.ShowFilterBar = True

            For Each col As GridColumnDescriptor In Me.dgvCliente.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True

            Me.dgvCliente.OptimizeFilterPerformance = True
            Me.dgvCliente.ShowNavigationBar = True

            filter.WireGrid(dgvCliente)

        End If
    End Sub

    Private Sub PrestaciónConBienesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim f As New frmVenta
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.ShowDialog()

        'Dim f As New frmServicioAlquiler
        'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim f As New frmCotizacion
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub PrestaciónDeServiciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrestaciónDeServiciosToolStripMenuItem.Click
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                Dim f As New frmVentaPV
                f.WindowState = FormWindowState.Maximized
                f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                GetCountPedidos()
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtRuc.Text.Trim.Length > 0 Then
                'If VAL_RUC(txtRuc.Text) = False Then
                '    MessageBoxAdv.Show("RUC NO VALIDO", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                '    MessageBoxAdv.Show("OK", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UbicarEntidadPorRuc(txtRuc.Text.Trim)
                'End If

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        If txtCliente.Tag.ToString.Trim.Length > 0 Then
            GetVentasPeriodoByCliente()
        Else
            MessageBox.Show("Debe identificar al cliente!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvCoti.Table.CurrentRecord) Then
            Dim f As New frmVentaPV(True, Val(dgvCoti.Table.CurrentRecord.GetValue("idDocumento")))
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            NumCotizaciones()
        Else
            MessageBox.Show("Debe seleccionar un cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub VentaPOSToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim f As New frmVentaPVdirecta
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterScreen
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub


    Private Sub txtRuc_TextChanged(sender As Object, e As EventArgs) Handles txtRuc.TextChanged

    End Sub

    Private Sub PanelError_Paint(sender As Object, e As PaintEventArgs) Handles PanelError.Paint

    End Sub

    Private Sub PrestaciónConConsumoDeInventariosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmVentaConsumo
        f = New frmVentaConsumo ' frmVentaConsumoDirecto
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgvVentas_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvVentas.QueryCellStyleInfo
        If Not IsNothing(e.TableCellIdentity.Column) Then
            If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
                'Checks for the column name when the cellvalue is greater than 5.
                If e.TableCellIdentity.Column.MappingName = "estadoPreparado" AndAlso ((e.Style.CellValue)) = "Entregada" Then
                    e.Style.BackColor = Color.FromArgb(92, 184, 92)
                    e.Style.TextColor = Color.White
                    'e.Style.Text = "Saldado"
                ElseIf e.TableCellIdentity.Column.MappingName = "estadoPreparado" AndAlso ((e.Style.CellValue)) = "Pendiente" Then
                    e.Style.BackColor = Color.FromArgb(183, 16, 0)
                    e.Style.TextColor = Color.White
                    'e.Style.Text = "Pendiente"
                End If
                'If e.TableCellIdentity.Column.MappingName = "importeMN" AndAlso CInt(Fix(e.Style.CellValue)) > 0 Then
                '    e.Style.BackColor = Color.LightYellow
                '    e.Style.Format = "S/.##.00"
                'End If
                'If e.TableCellIdentity.Column.MappingName = "almacenDestino" Then
                '    e.Style.BackColor = Color.LightYellow
                'End If
            End If
        End If
    End Sub

    Private Sub dgvVentas_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvVentas.TableControlCellClick

    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim venta As New documentoventaAbarrotes
        Me.Cursor = Cursors.WaitCursor
        Dim r As Record = dgvVentas.Table.CurrentRecord
        If Not IsNothing(r) Then

            venta = ventaSA.GetUbicar_documentoventaAbarrotesPorID(Val(dgvVentas.Table.CurrentRecord.GetValue("idDocumento")))

            If Not IsNothing(venta) Then
                If venta.notaCredito = StatusVentaMatizados.TerminadaYentregada Then
                    MessageBox.Show("La venta ya fue preprada, intente en otra ocasión", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                Dim f As New frmPrepararLista(Val(dgvVentas.Table.CurrentRecord.GetValue("idDocumento")))
                f.lblNomCliente.Text = r.GetValue("NombreEntidad")

                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If


        Else
            MessageBox.Show("Debe elegir una venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Dim f As New frmPlantilla
        f = New frmPlantilla
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs)

        Me.Cursor = Cursors.WaitCursor
        With frmVentaPVdirecta
            .btGrabar.Enabled = True
            .StartPosition = FormStartPosition.CenterParent
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .ShowDialog()
            dgvVentaGeneral.Table.Records.DeleteAll()
            GridGroupingControl2.Table.Records.DeleteAll()
            dgvConfirmar.Table.Records.DeleteAll()
            dgvHistorialConforme.Table.Records.DeleteAll()
            GetCargarVentasGuia()
        End With
        Me.Cursor = Cursors.Arrow


        'Dim f As New frmVentaPVdirecta
        'f.btGrabar.Enabled = True
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.ShowDialog()

        'Else
        'MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs)
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        'Dim usuarioSA As New UsuarioSA
        'Dim usuarioxls As New Usuario
        cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)

        If Not IsNothing(cajaUsuario) Then
            Dim f As New frmVentaPVDirectaCont
            f.btGrabar.Enabled = True
            'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            ''f.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
            ''f.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            f.lblPerido.Text = PeriodoGeneral
            'f.StartPosition = FormStartPosition.CenterScreen
            'f.Show()
            f.StartPosition = FormStartPosition.CenterParent
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.ShowDialog()

            dgvVentaGeneral.Table.Records.DeleteAll()
            GridGroupingControl2.Table.Records.DeleteAll()
            dgvConfirmar.Table.Records.DeleteAll()
            dgvHistorialConforme.Table.Records.DeleteAll()
            GetCargarVentasGuia()

        Else
            MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs)
        Dim f As New frmVenta
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        dgvVentaGeneral.Table.Records.DeleteAll()
        GridGroupingControl2.Table.Records.DeleteAll()
        dgvConfirmar.Table.Records.DeleteAll()
        dgvHistorialConforme.Table.Records.DeleteAll()
        GetCargarVentasGuia()

        Select Case treeViewAdv2.SelectedNode.Text
            Case "Ventas del período"
                GridCFGVenta(dgvVentas)
                TabPageAdv1.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                TabCotizacion.Parent = Nothing
                GetListaVentasPorPeriodo()
                TabPageAdv3.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                tabConfirmarGuia.Parent = Nothing
            Case "Pendiente de entrega"
                GridCFGVenta(GridGroupingControl2)
                GridCFGVenta(dgvVentaGeneral)
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabCotizacion.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                tabConfirmarGuia.Parent = Nothing
                TabVentaGeneral.Parent = TabControlAdv1
                GetListaVentasGeneralPorPeridod()
                ToolStripButton7.Visible = True
                ToolStripButton8.Visible = True
            Case "Historial"
                GridCFGVenta(dgvConfirmar)
                GridCFGVenta(dgvHistorialConforme)
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabCotizacion.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                tabConfirmarGuia.Parent = TabControlAdv1
                TabVentaGeneral.Parent = Nothing
                GetListaVentasGeneralAprobado()
                GridGroupingControl2.Table.Records.DeleteAll()

        End Select
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmVentaConsumo
        f = New frmVentaConsumo ' frmVentaConsumoDirecto
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub AnticipoPorVentaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmAnticipoXVenta
        f = New frmAnticipoXVenta ' frmVentaConsumoDirecto
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub VentaMultiempresaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmventaMultiempresa
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.WindowState = FormWindowState.Maximized
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Me.Cursor = Cursors.WaitCursor
        Dim r As Record = dgvVentaGeneral.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmControlEntregables(Val(dgvVentaGeneral.Table.CurrentRecord.GetValue("idDocumento")))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Else
            MessageBox.Show("Debe elegir una venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvVentaGeneral_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvVentaGeneral.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvVentaGeneral.Table.CurrentRecord) Then
            ObtenerListaGuiaRemision(Me.dgvVentaGeneral.Table.CurrentRecord.GetValue("idDocumento"))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        Me.Cursor = Cursors.WaitCursor
        Dim r As Record = GridGroupingControl2.Table.CurrentRecord
        If Not IsNothing(r) Then

            If (r.GetValue("estado") = "PARCIAL") Then
                Dim f As New frmReporteControlEntregable((GridGroupingControl2.Table.CurrentRecord.GetValue("idDocumento")))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                GridGroupingControl2.Table.Records.DeleteAll()
            ElseIf (r.GetValue("estado") = "POR CONFIRMAR") Then
                Dim objActualizar As New documentoVentaAbarrotesSA
                Dim f As New frmReporteControlEntregable((GridGroupingControl2.Table.CurrentRecord.GetValue("idDocumento")))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                GridGroupingControl2.Table.Records.DeleteAll()
            End If

            'dgvVentaGeneral.Table.Records.DeleteAll()
            'GridGroupingControl2.Table.Records.DeleteAll()
            'GetListaVentasGeneralPorPeridod()
            dgvVentaGeneral.Table.Records.DeleteAll()
            GridGroupingControl2.Table.Records.DeleteAll()
            dgvConfirmar.Table.Records.DeleteAll()
            dgvHistorialConforme.Table.Records.DeleteAll()
            GetCargarVentasGuia()
        Else
            MessageBox.Show("Debe elegir una venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton19_Click(sender As Object, e As EventArgs) Handles ToolStripButton19.Click
        Me.Cursor = Cursors.WaitCursor
        Dim r As Record = GridGroupingControl2.Table.CurrentRecord
        If Not IsNothing(r) Then

            Dim f As New frmHistorialRecepcion(GridGroupingControl2.Table.CurrentRecord.GetValue("idDocumento"))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

        Else
            MessageBox.Show("Debe elegir una venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvConfirmar_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvConfirmar.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvConfirmar.Table.CurrentRecord) Then

            If (Me.dgvConfirmar.Table.CurrentRecord.GetValue("NombreEntidad") = "") Then
                ObtenerListaGuiaRemisionCompleto(Me.dgvConfirmar.Table.CurrentRecord.GetValue("idDocumento"), "SENTIDAD")
            Else
                ObtenerListaGuiaRemisionCompleto(Me.dgvConfirmar.Table.CurrentRecord.GetValue("idDocumento"), "CENTIDAD")
            End If

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton20_Click(sender As Object, e As EventArgs) Handles ToolStripButton20.Click
        Me.Cursor = Cursors.WaitCursor
        Dim r As Record = dgvHistorialConforme.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmReporteControlEntregable((dgvHistorialConforme.Table.CurrentRecord.GetValue("idDocumento")), Nothing)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Else
            MessageBox.Show("Debe elegir una venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        'Me.Cursor = Cursors.WaitCursor
        'With frmVentaPVdirecta
        '    .btGrabar.Enabled = True
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    .ShowDialog()
        '    dgvVentaGeneral.Table.Records.DeleteAll()
        '    GridGroupingControl2.Table.Records.DeleteAll()
        '    dgvConfirmar.Table.Records.DeleteAll()
        '    dgvHistorialConforme.Table.Records.DeleteAll()
        '    GetCargarVentasGuia()
        'End With
        'Me.Cursor = Cursors.Arrow


        'Dim ef As New EstadosFinancierosSA
        'Dim cajaUsuario As New cajaUsuario
        'Dim cajaUsuarioSA As New cajaUsuarioSA
        'Dim usuarioSA As New UsuarioSA
        'Dim usuarioxls As New Usuario
        'cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
        'If Not IsNothing(cajaUsuario) Then
        'Dim f As New frmVentaPVdirecta
        'f.btGrabar.Enabled = True
        'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        ''f.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
        ''f.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        'f.lblPerido.Text = PeriodoGeneral
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.Show()
        'dgvVentaGeneral.Table.Records.DeleteAll()
        'GridGroupingControl2.Table.Records.DeleteAll()
        'dgvConfirmar.Table.Records.DeleteAll()
        'dgvHistorialConforme.Table.Records.DeleteAll()
        'GetCountHistorial()
        'GetCountPedidosGuia()
        'Else
        'MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        'Dim f As New frmVenta
        'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.ShowDialog()
        'dgvVentaGeneral.Table.Records.DeleteAll()
        'GridGroupingControl2.Table.Records.DeleteAll()
        'dgvConfirmar.Table.Records.DeleteAll()
        'dgvHistorialConforme.Table.Records.DeleteAll()
        'GetCountHistorial()
        'GetCountPedidosGuia()


    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                Dim f As New frmVentaPV
                f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.WindowState = FormWindowState.Maximized
                'f.txtFecha.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                'f.txtFecha.CustomFormat = "dd/MM/yyyy HH:mm tt"
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                dgvVentaGeneral.Table.Records.DeleteAll()
                GridGroupingControl2.Table.Records.DeleteAll()
                dgvConfirmar.Table.Records.DeleteAll()
                dgvHistorialConforme.Table.Records.DeleteAll()
                GetCargarVentasGuia()
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


    End Sub

    Private Sub FghfToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FghfToolStripMenuItem.Click
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Me.Cursor = Cursors.WaitCursor

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then

                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                     With frmAnticipoXVenta
                        .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()

                    End With
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                'Dim f As New frmAnticipoXVenta
                ''f = New frmAnticipoXVenta ' frmVentaConsumoDirecto
                'f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                'f.StartPosition = FormStartPosition.CenterParent
                'f.ShowDialog()
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If (RadioButton2.Checked = True) Then
            dgvVentaGeneral.Table.Records.DeleteAll()
            GridGroupingControl2.Table.Records.DeleteAll()
            Panel12.Enabled = True
            TextBoxExt2.Clear()
            TextBoxExt1.Clear()
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If (RadioButton1.Checked = True) Then
            Panel12.Enabled = False
            GetListaVentasGeneralPorPeridod()
            TextBoxExt2.Clear()
            TextBoxExt1.Clear()
        End If
    End Sub

    Private Sub TextBoxExt2_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt2.TextChanged
        TextBoxExt2.ForeColor = Color.Black
        TextBoxExt2.Tag = Nothing
    End Sub

    Private Sub TextBoxExt2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt2.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.[End] Then
        Else
            Me.popupControlContainer1.Font = New Font("Segoe UI", 8)
            Me.popupControlContainer1.Size = New Size(241, 110)
            Me.popupControlContainer1.ParentControl = Me.TextBoxExt2
            Me.popupControlContainer1.ShowPopup(Point.Empty)

            Dim con = (ListadoProveedores.Where(Function(s) s.nombreCompleto.StartsWith(TextBoxExt2.Text))).ToList()

            lsvProveedor.DataSource = con
            lsvProveedor.DisplayMember = "nombreCompleto"
            lsvProveedor.ValueMember = "idEntidad"

            'txtCliente.DataSource = CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtCliente.Text.Trim)
            'txtCliente.DisplayMember = "nombreCompleto"
            'txtCliente.ValueMember = "idEntidad"
        End If
        If e.KeyCode = Keys.Down Then
            Me.popupControlContainer1.Font = New Font("Segoe UI", 8)
            Me.popupControlContainer1.Size = New Size(241, 110)
            Me.popupControlContainer1.ParentControl = Me.TextBoxExt2
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            TextBoxExt2.Focus()
        End If

        If e.KeyCode = Keys.Escape Then
            If Me.popupControlContainer1.IsShowing() Then
                Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
            End If
        End If


        If e.Alt Then
            If e.KeyCode = Keys.Down Then
                If Not Me.popupControlContainer1.IsShowing() Then
                    ' Let the popup align around the source textBox.
                    Me.popupControlContainer1.ParentControl = Me.TextBoxExt2
                    ' Passing Point.Empty will align it automatically around the above ParentControl.
                    Me.popupControlContainer1.ShowPopup(Point.Empty)

                    e.Handled = True
                End If
            End If
        End If
        '' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.popupControlContainer1.IsShowing() Then
                Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TextBoxExt2.Text.Trim.Length > 0 Then
                Me.popupControlContainer1.ParentControl = Me.TextBoxExt2
                Me.popupControlContainer1.ShowPopup(Point.Empty)
                CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, TextBoxExt2.Text.Trim)
            End If
        End If
    End Sub

    Private Sub TextBoxExt1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt1.KeyDown

        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TextBoxExt1.Text.Trim.Length > 0 Then
                'If VAL_RUC(txtRuc.Text) = False Then
                '    MessageBoxAdv.Show("RUC NO VALIDO", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                '    MessageBoxAdv.Show("OK", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UbicarEntidadPorRuc(TextBoxExt1.Text.Trim)
                'End If

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                TextBoxExt2.Text = lsvProveedor.Text
                TextBoxExt2.Tag = lsvProveedor.SelectedValue
                TextBoxExt2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                Dim con = (ListadoProveedores.Where(Function(s) s.idEntidad = CInt(TextBoxExt2.Tag))).FirstOrDefault()

                If con IsNot Nothing Then
                    TextBoxExt1.Text = con.nrodoc
                End If
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.TextBoxExt2.Focus()
        End If
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Dim tipoventa As String = ""
        If (TextBoxExt1.Text.Length > 0) Then
            Select Case cboTipoDoc.Text
                Case "VENTA_GENERAL"
                    tipoventa = TIPO_VENTA.VENTA_GENERAL
                    consultarVenta(TextBoxExt1.Text, tipoventa)
                Case "VENTA_POS_DIRECTA"
                    tipoventa = TIPO_VENTA.VENTA_POS_DIRECTA
                    consultarVenta(TextBoxExt1.Text, tipoventa)
            End Select
        Else
            MessageBox.Show("Debe indicar un cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


    End Sub

    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDoubleClick
        If ListBox1.SelectedItems.Count > 0 Then
            PopupControlContainer2.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub PopupControlContainer2_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer2.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If ListBox1.SelectedItems.Count > 0 Then
                TextBoxExt3.Text = ListBox1.Text
                TextBoxExt3.Tag = ListBox1.SelectedValue
                TextBoxExt3.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                Dim con = (ListadoProveedores.Where(Function(s) s.idEntidad = CInt(TextBoxExt3.Tag))).FirstOrDefault()

                If con IsNot Nothing Then
                    TextBoxExt4.Text = con.nrodoc
                End If
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.TextBoxExt3.Focus()
        End If
    End Sub

    Private Sub TextBoxExt3_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt3.TextChanged
        TextBoxExt3.ForeColor = Color.Black
        TextBoxExt3.Tag = Nothing
    End Sub

    Private Sub TextBoxExt3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt3.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.[End] Then
        Else
            Me.PopupControlContainer2.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer2.Size = New Size(241, 110)
            Me.PopupControlContainer2.ParentControl = Me.TextBoxExt3
            Me.PopupControlContainer2.ShowPopup(Point.Empty)

            Dim con = (ListadoProveedores.Where(Function(s) s.nombreCompleto.StartsWith(TextBoxExt3.Text))).ToList()

            ListBox1.DataSource = con
            ListBox1.DisplayMember = "nombreCompleto"
            ListBox1.ValueMember = "idEntidad"

            'txtCliente.DataSource = CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtCliente.Text.Trim)
            'txtCliente.DisplayMember = "nombreCompleto"
            'txtCliente.ValueMember = "idEntidad"
        End If
        If e.KeyCode = Keys.Down Then
            Me.PopupControlContainer2.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer2.Size = New Size(241, 110)
            Me.PopupControlContainer2.ParentControl = Me.TextBoxExt3
            Me.PopupControlContainer2.ShowPopup(Point.Empty)
            TextBoxExt3.Focus()
        End If

        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer2.IsShowing() Then
                Me.PopupControlContainer2.HidePopup(PopupCloseType.Canceled)
            End If
        End If


        If e.Alt Then
            If e.KeyCode = Keys.Down Then
                If Not Me.PopupControlContainer2.IsShowing() Then
                    ' Let the popup align around the source textBox.
                    Me.PopupControlContainer2.ParentControl = Me.TextBoxExt3
                    ' Passing Point.Empty will align it automatically around the above ParentControl.
                    Me.PopupControlContainer2.ShowPopup(Point.Empty)

                    e.Handled = True
                End If
            End If
        End If
        '' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.popupControlContainer1.IsShowing() Then
                Me.PopupControlContainer2.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TextBoxExt3.Text.Trim.Length > 0 Then
                Me.PopupControlContainer2.ParentControl = Me.TextBoxExt3
                Me.PopupControlContainer2.ShowPopup(Point.Empty)
                CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, TextBoxExt3.Text.Trim)
            End If
        End If
    End Sub

    Private Sub TextBoxExt4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt4.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TextBoxExt4.Text.Trim.Length > 0 Then
                'If VAL_RUC(txtRuc.Text) = False Then
                '    MessageBoxAdv.Show("RUC NO VALIDO", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                '    MessageBoxAdv.Show("OK", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UbicarEntidadPorRuc2(TextBoxExt4.Text.Trim)
                'End If

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Dim tipoventa As String = ""

        If (TextBoxExt1.Text.Length > 0) Then
            Select Case ComboBoxAdv2.Text
                Case "VENTA_GENERAL"
                    tipoventa = TIPO_VENTA.VENTA_GENERAL
                    consultarVenta(TextBoxExt4.Text, tipoventa)
                Case "VENTA_POS_DIRECTA"
                    tipoventa = TIPO_VENTA.VENTA_POS_DIRECTA
                    consultarVenta(TextBoxExt4.Text, tipoventa)
            End Select
        Else
            MessageBox.Show("Debe indicar un cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If (RadioButton3.Checked = True) Then
            Panel13.Enabled = False
            GetListaVentasGeneralAprobado()
            TextBoxExt3.Clear()
            TextBoxExt4.Clear()
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If (RadioButton4.Checked = True) Then
            dgvConfirmar.Table.Records.DeleteAll()
            dgvHistorialConforme.Table.Records.DeleteAll()
            Panel13.Enabled = True
            TextBoxExt3.Clear()
            TextBoxExt4.Clear()
        End If
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ef As New EstadosFinancierosSA
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim usuarioSA As New UsuarioSA
        Dim usuarioxls As New Usuario
        cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)

        If Not IsNothing(cajaUsuario) Then
            usuarioxls = usuarioSA.UbicarUsuarioXid(New Usuario With {.IDUsuario = usuario.IDUsuario})

            Dim F As New frmCobroPedidos
            F.txtNomUser.Text = usuarioxls.Full_Name
            'F.txtCajaOrigen.Tag = CInt(cajaUsuario.idCajaOrigen)
            'F.txtCajaOrigen.Text = ef.GetUbicar_estadosFinancierosPorID(CInt(cajaUsuario.idCajaOrigen)).descripcion
            '   F.GetObtenerSaldoEF()
            'F.GridPago()


            If IsNothing(cajaUsuario.idPadre) Then
                F.txtTipoUser.Text = "Usuario Responsable"
                F.txtTipoUser.Tag = cajaUsuario.idcajaUsuario
            Else
                F.txtTipoUser.Text = "Usuario Dependiente"
                F.txtTipoUser.Tag = cajaUsuario.idcajaUsuario
            End If

            F.StartPosition = FormStartPosition.CenterParent
            F.ShowDialog()
            'Dim f As New frmCajaTicket
            'f.SinAnticipo()
            'f.Show()
        Else
            MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CréditoEntregaTotalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CréditoEntregaTotalToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmVentaPVdirecta
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .CargarTipoDeVenta(TIPO_VENTA.VENTA_CREDITO_TOTAL)
                    .StartPosition = FormStartPosition.CenterParent
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .ShowDialog()
                    dgvVentaGeneral.Table.Records.DeleteAll()
                    GridGroupingControl2.Table.Records.DeleteAll()
                    dgvConfirmar.Table.Records.DeleteAll()
                    dgvHistorialConforme.Table.Records.DeleteAll()
                    GetCargarVentasGuia()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CréditoEntregaParcialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CréditoEntregaParcialToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmVentaPVdirecta
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    '.btGrabar.Enabled = True
                    .CargarTipoDeVenta(TIPO_VENTA.VENTA_CREDITO_PARCIAL)
                    .StartPosition = FormStartPosition.CenterParent
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .ShowDialog()
                    dgvVentaGeneral.Table.Records.DeleteAll()
                    GridGroupingControl2.Table.Records.DeleteAll()
                    dgvConfirmar.Table.Records.DeleteAll()
                    dgvHistorialConforme.Table.Records.DeleteAll()
                    GetCargarVentasGuia()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub ContadoEntregaTotalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContadoEntregaTotalToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then

                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    With frmVentaPVdirecta
                        .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                        '.btGrabar.Enabled = True
                        .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_TOTAL)
                        .StartPosition = FormStartPosition.CenterParent
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .ShowDialog()
                        dgvVentaGeneral.Table.Records.DeleteAll()
                        GridGroupingControl2.Table.Records.DeleteAll()
                        dgvConfirmar.Table.Records.DeleteAll()
                        dgvHistorialConforme.Table.Records.DeleteAll()
                        GetCargarVentasGuia()
                    End With
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ContadoEntregaParcialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContadoEntregaParcialToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    With frmVentaPVdirecta
                        .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                        '.btGrabar.Enabled = True
                        .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_PARCIAL)
                        .StartPosition = FormStartPosition.CenterParent
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .ShowDialog()
                        dgvVentaGeneral.Table.Records.DeleteAll()
                        GridGroupingControl2.Table.Records.DeleteAll()
                        dgvConfirmar.Table.Records.DeleteAll()
                        dgvHistorialConforme.Table.Records.DeleteAll()
                        GetCargarVentasGuia()
                    End With
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub VentaAccesoTotalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaAccesoTotalToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmVentaPVdirecta
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    '.btGrabar.Enabled = True
                    .CargarTipoDeVenta(TIPO_VENTA.VENTA_ANULADA)
                    .StartPosition = FormStartPosition.CenterParent
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .ShowDialog()
                    dgvVentaGeneral.Table.Records.DeleteAll()
                    GridGroupingControl2.Table.Records.DeleteAll()
                    dgvConfirmar.Table.Records.DeleteAll()
                    dgvHistorialConforme.Table.Records.DeleteAll()
                    GetCargarVentasGuia()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub VentaCréditoEntregaTotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaCréditoEntregaTotaToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                Dim f As New frmVenta
                f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.CargarTipoDeVenta(TIPO_VENTA.VENTA_CREDITO_TOTAL)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                dgvVentaGeneral.Table.Records.DeleteAll()
                GridGroupingControl2.Table.Records.DeleteAll()
                dgvConfirmar.Table.Records.DeleteAll()
                dgvHistorialConforme.Table.Records.DeleteAll()
                GetCargarVentasGuia()
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
        'Select Case treeViewAdv2.SelectedNode.Text
        '    Case "Ventas del período"
        '        GridCFGVenta(dgvVentas)
        '        TabPageAdv1.Parent = TabControlAdv1
        '        TabPageAdv2.Parent = Nothing
        '        TabCotizacion.Parent = Nothing
        '        GetListaVentasPorPeriodo()
        '        TabPageAdv3.Parent = Nothing
        '        TabVentaGeneral.Parent = Nothing
        '        tabConfirmarGuia.Parent = Nothing
        '    Case "Pendiente de entrega"
        '        GridCFGVenta(GridGroupingControl2)
        '        GridCFGVenta(dgvVentaGeneral)
        '        TabPageAdv1.Parent = Nothing
        '        TabPageAdv2.Parent = Nothing
        '        TabCotizacion.Parent = Nothing
        '        TabPageAdv3.Parent = Nothing
        '        tabConfirmarGuia.Parent = Nothing
        '        TabVentaGeneral.Parent = TabControlAdv1
        '        GetListaVentasGeneralPorPeridod()
        '        ToolStripButton7.Visible = True
        '        ToolStripButton8.Visible = True
        '    Case "Historial"
        '        GridCFGVenta(dgvConfirmar)
        '        GridCFGVenta(dgvHistorialConforme)
        '        TabPageAdv1.Parent = Nothing
        '        TabPageAdv2.Parent = Nothing
        '        TabCotizacion.Parent = Nothing
        '        TabPageAdv3.Parent = Nothing
        '        tabConfirmarGuia.Parent = TabControlAdv1
        '        TabVentaGeneral.Parent = Nothing
        '        GetListaVentasGeneralAprobado()
        '        GridGroupingControl2.Table.Records.DeleteAll()

        'End Select

    End Sub

    Private Sub VentaCréditoEntregaParcialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaCréditoEntregaParcialToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                Dim f As New frmVenta
                f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.CargarTipoDeVenta(TIPO_VENTA.VENTA_CREDITO_PARCIAL)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                dgvVentaGeneral.Table.Records.DeleteAll()
                GridGroupingControl2.Table.Records.DeleteAll()
                dgvConfirmar.Table.Records.DeleteAll()
                dgvHistorialConforme.Table.Records.DeleteAll()
                GetCargarVentasGuia()
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub VentaContadoEntregaTotalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaContadoEntregaTotalToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    With frmVenta
                        .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_TOTAL)
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()

                        dgvVentaGeneral.Table.Records.DeleteAll()
                        GridGroupingControl2.Table.Records.DeleteAll()
                        dgvConfirmar.Table.Records.DeleteAll()
                        dgvHistorialConforme.Table.Records.DeleteAll()
                        GetCargarVentasGuia()
                    End With
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub VentaContadoEntregaParcialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaContadoEntregaParcialToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA


        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    With frmVenta
                        'Dim f As New frmVenta
                        .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_PARCIAL)
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()

                        dgvVentaGeneral.Table.Records.DeleteAll()
                        GridGroupingControl2.Table.Records.DeleteAll()
                        dgvConfirmar.Table.Records.DeleteAll()
                        dgvHistorialConforme.Table.Records.DeleteAll()
                        GetCargarVentasGuia()
                    End With
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub VentaAccesoTotalToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VentaAccesoTotalToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmVentaPVdirecta
                    Dim f As New frmVenta
                    'f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.CargarTipoDeVenta(TIPO_VENTA.VENTA_ANULADA)
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                    dgvVentaGeneral.Table.Records.DeleteAll()
                    GridGroupingControl2.Table.Records.DeleteAll()
                    dgvConfirmar.Table.Records.DeleteAll()
                    dgvHistorialConforme.Table.Records.DeleteAll()
                    GetCargarVentasGuia()
                End With

            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        Cursor = Cursors.WaitCursor
        GetListaVentasPorPeriodo()
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv18_Click(sender As Object, e As EventArgs) Handles ButtonAdv18.Click
        Dim r As Record = dgvVentas.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmCambiarPeriodo2(New documentoventaAbarrotes With {.idDocumento = Val(r.GetValue("idDocumento"))})
            f.operacion = StatusTipoOperacion.VENTA
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            ButtonAdv19_Click(sender, e)
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

    End Sub

    Private Sub VentaPOSContadoEntregaTotalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaPOSContadoEntregaTotalToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then

                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    With frmVentaPVdirecta
                        .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                        '.btGrabar.Enabled = True
                        .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_TOTAL)
                        .StartPosition = FormStartPosition.CenterParent
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .ShowDialog()
                        dgvVentaGeneral.Table.Records.DeleteAll()
                        GridGroupingControl2.Table.Records.DeleteAll()
                        dgvConfirmar.Table.Records.DeleteAll()
                        dgvHistorialConforme.Table.Records.DeleteAll()
                        GetCargarVentasGuia()
                    End With
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub VentaPOSCréditoEntregaParcialToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VentaPOSCréditoEntregaParcialToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmVentaPVdirecta
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    '.btGrabar.Enabled = True
                    .CargarTipoDeVenta(TIPO_VENTA.VENTA_CREDITO_PARCIAL)
                    .StartPosition = FormStartPosition.CenterParent
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .ShowDialog()
                    dgvVentaGeneral.Table.Records.DeleteAll()
                    GridGroupingControl2.Table.Records.DeleteAll()
                    dgvConfirmar.Table.Records.DeleteAll()
                    dgvHistorialConforme.Table.Records.DeleteAll()
                    GetCargarVentasGuia()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub VentaPOSCréditoEntregaTotalToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VentaPOSCréditoEntregaTotalToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmVentaPVdirecta
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .CargarTipoDeVenta(TIPO_VENTA.VENTA_CREDITO_TOTAL)
                    .StartPosition = FormStartPosition.CenterParent
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .ShowDialog()
                    dgvVentaGeneral.Table.Records.DeleteAll()
                    GridGroupingControl2.Table.Records.DeleteAll()
                    dgvConfirmar.Table.Records.DeleteAll()
                    dgvHistorialConforme.Table.Records.DeleteAll()
                    GetCargarVentasGuia()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub VentaContadoEntregaTotalToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles VentaContadoEntregaTotalToolStripMenuItem2.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA


        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    With frmVenta
                        'Dim f As New frmVenta
                        .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_PARCIAL)
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()

                        dgvVentaGeneral.Table.Records.DeleteAll()
                        GridGroupingControl2.Table.Records.DeleteAll()
                        dgvConfirmar.Table.Records.DeleteAll()
                        dgvHistorialConforme.Table.Records.DeleteAll()
                        GetCargarVentasGuia()
                    End With
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub VentaCréditoEntregaTotalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaCréditoEntregaTotalToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                Dim f As New frmVenta
                f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.CargarTipoDeVenta(TIPO_VENTA.VENTA_CREDITO_TOTAL)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                dgvVentaGeneral.Table.Records.DeleteAll()
                GridGroupingControl2.Table.Records.DeleteAll()
                dgvConfirmar.Table.Records.DeleteAll()
                dgvHistorialConforme.Table.Records.DeleteAll()
                GetCargarVentasGuia()
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub VentaCréditoEntrregaParcialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaCréditoEntrregaParcialToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                Dim f As New frmVenta
                f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.CargarTipoDeVenta(TIPO_VENTA.VENTA_CREDITO_PARCIAL)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                dgvVentaGeneral.Table.Records.DeleteAll()
                GridGroupingControl2.Table.Records.DeleteAll()
                dgvConfirmar.Table.Records.DeleteAll()
                dgvHistorialConforme.Table.Records.DeleteAll()
                GetCargarVentasGuia()
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub VentaContadoEntregaTotalToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VentaContadoEntregaTotalToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    With frmVenta
                        .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_TOTAL)
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()

                        dgvVentaGeneral.Table.Records.DeleteAll()
                        GridGroupingControl2.Table.Records.DeleteAll()
                        dgvConfirmar.Table.Records.DeleteAll()
                        dgvHistorialConforme.Table.Records.DeleteAll()
                        GetCargarVentasGuia()
                    End With
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub VENTAFORMATOGENERALMULTIUSOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VENTAFORMATOGENERALMULTIUSOToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                '   With frmVentaPVdirecta
                Dim f As New frmVenta
                    'f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.CargarTipoDeVenta(TIPO_VENTA.VENTA_ANULADA)
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                    dgvVentaGeneral.Table.Records.DeleteAll()
                    GridGroupingControl2.Table.Records.DeleteAll()
                    dgvConfirmar.Table.Records.DeleteAll()
                    dgvHistorialConforme.Table.Records.DeleteAll()
                    GetCargarVentasGuia()
                '    End With

            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub VentaPOSContadoEntregaParcialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaPOSContadoEntregaParcialToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    With frmVentaPVdirecta
                        .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                        '.btGrabar.Enabled = True
                        .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_PARCIAL)
                        .StartPosition = FormStartPosition.CenterParent
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .ShowDialog()
                        dgvVentaGeneral.Table.Records.DeleteAll()
                        GridGroupingControl2.Table.Records.DeleteAll()
                        dgvConfirmar.Table.Records.DeleteAll()
                        dgvHistorialConforme.Table.Records.DeleteAll()
                        GetCargarVentasGuia()
                    End With
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PUNTODEVENTAMULTIUSOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PUNTODEVENTAMULTIUSOToolStripMenuItem.Click

    End Sub
End Class