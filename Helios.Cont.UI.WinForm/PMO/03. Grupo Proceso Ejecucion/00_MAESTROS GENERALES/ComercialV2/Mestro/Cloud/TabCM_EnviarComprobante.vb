Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabCM_EnviarComprobante

    Property CierreSA As New empresaCierreMensualSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim filter As New GridExcelFilter()
    Private anioSel As String
    Private mesSel As String
    Dim ventaSA As New documentoVentaAbarrotesSA
    Private TabCM_EnviarComprobante As TabCM_EnviarComprobante
    Public Property listaClientes As New List(Of entidad)
    Friend Delegate Sub SetDataSourceDelegateEntidad(ByVal lista As List(Of entidad))
    Public Property entidadSA As New entidadSA
    Dim direccionArchivo As String = String.Empty
    Dim direccionArchivoXML As String = String.Empty

    Public Sub New(periodo As String, anio As String, mes As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GetCombos()
        FormatoGrid(dgPedidos)
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        anioSel = anio
        mesSel = mes
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorPeriodo(periodo)))
        thread.Start()

        threadClientes()

    End Sub

#Region "Methdos"
    Private Sub GetCombos()
        Dim empresaAnioSA As New empresaPeriodoSA
        cboMesPedido.DisplayMember = "Mes"
        cboMesPedido.ValueMember = "Codigo"
        cboMesPedido.DataSource = ListaDeMeses()
        cboMesPedido.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)

        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = DateTime.Now.Year
    End Sub

    Dim thread As System.Threading.Thread
    Private Sub threadClientes()
        Dim tipo = TIPO_ENTIDAD.CLIENTE
        Dim empresa = Gempresas.IdEmpresaRuc
        GetClientes(tipo, empresa)

    End Sub

    Private Sub GetClientes(tipo As String, empresa As String)
        Dim lista As New List(Of entidad)
        lista = New List(Of entidad)
        Dim varios = entidadSA.UbicarEntidadVarios("VR", Gempresas.IdEmpresaRuc, String.Empty, GEstableciento.IdEstablecimiento)
        'Dim lista = entidadSA.ObtenerListaEntidad(tipo, empresa)
        lista.Add(varios)
        lista.AddRange(entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = tipo, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}))
        listaClientes = New List(Of entidad)
        listaClientes = lista
    End Sub


#End Region

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

    Private Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean, GGC As GridGroupingControl)
        Dim color As New GridMetroColors()
        Dim id As GridTableCellStyleInfoIdentity = GGC.TableControl.GetTableViewStyleInfo(row, col).TableCellIdentity
        If id.DisplayElement.IsRecord() Then
            Dim key As Integer = id.DisplayElement.GetRecord().Id
            'if (selectionColl.Contains(key))
            '    selectionColl[key] = isHover;
            'else
            hoveredIndex = row
            selectionColl.Clear()
            'if (selectionColl.Count == 0)
            '    selectionColl.Add(key, isHover);
            GGC.TableControl.Refresh()
        End If

        GGC.TableControl.Selections.Clear()

    End Sub

    Public Sub EliminarPV(intIdDocumento As Integer)
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim objDocumento As New documento
        Try
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = intIdDocumento
            End With

            documentoSA.EliminarVenta(objDocumento)
            'documentoSA.EliminarVentaGeneralPV(objDocumento)
            dgPedidos.Table.CurrentRecord.Delete()
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
            Me.dgPedidos.Table.CurrentRecord.Delete()
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

    Public Function ValidarStock(idDocVenta As Integer)
        Dim documentoventa As New documentoVentaAbarrotesSA

        Dim sintock As Integer = 0
        sintock = documentoventa.StockEliminarNotaVenta(idDocVenta)

        Return sintock
    End Function

    Private Sub GetListaVentasPorPeriodo(period As String)
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

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasPeriodo(GEstableciento.IdEstablecimiento, period)
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
                    dr(6) = CStr(i.numeroVenta).PadLeft(8, "0"c)

                Case TIPO_VENTA.COTIZACION
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL
                    dr(6) = i.numeroVenta
                Case "NTC"
                    dr(6) = i.numeroVenta
                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    dr(6) = i.numeroDoc
                Case Else
                    dr(6) = CStr(i.numeroVenta).PadLeft(8, "0"c)
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

    Private Sub GetListaVentasPorCliente(idCliente As Integer)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA
        Dim objDocumento As New documentoventaAbarrotes

        Dim dt As New DataTable("Ventas de - " & idCliente)
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

        objDocumento.idEstablecimiento = GEstableciento.IdEstablecimiento
        objDocumento.idCliente = TXTcOMPRADOR.Tag

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasPorCliente(objDocumento)
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

    Private Sub GetListarAllVentasPorDia(Fecha As Date)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA
        Dim objDocumento As New documentoventaAbarrotes

        Dim dt As New DataTable("Ventas de - " & Fecha)
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

        objDocumento.idEmpresa = Gempresas.IdEmpresaRuc
        objDocumento.idEstablecimiento = GEstableciento.IdEstablecimiento
        objDocumento.fechaDoc = txtFechaHora.Value

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasPorDIa(objDocumento)
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

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgPedidos.DataSource = table
            ProgressBar1.Visible = False
        End If
    End Sub

    Private Sub dgPedidos_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgPedidos.TableControlCellClick

    End Sub

    Private Sub dgPedidos_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgPedidos.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgPedidos.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgPedidos_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgPedidos.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgPedidos)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(dgPedidos.Table.CurrentRecord) Then
            Select Case dgPedidos.Table.CurrentRecord.GetValue("tipoCompra")
                Case TIPO_VENTA.VENTA_GENERAL
                    Dim f As New frmVenta(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.ShowDialog()
                Case TIPO_VENTA.VENTA_NOTA_PEDIDO
                    Dim f As New frmVentaPV(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.ShowDialog()
                Case TIPO_VENTA.VENTA_POS_DIRECTA
                    'Dim f As New frmVentaPVdirecta(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                    'f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    'f.ShowDialog()
                    Dim f As New frmVentaNuevoFormato(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                    f.btGrabar.Enabled = False
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                Case TIPO_VENTA.VENTA_AL_TICKET
                    Dim f As New frmVentaPV(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.WindowState = FormWindowState.Maximized
                    f.ShowDialog()
            End Select
        Else
            MessageBox.Show("Debe seleccionar un pedido/venta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        ''Cursor = Cursors.WaitCursor
        ''If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then
        ''    Dim f As New FormEnviarCorreo(Gempresas.Ruc, 1)  ' frmVentaNuevoFormato
        ''    f.DocumentoID = Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")

        ''    Select Case Me.dgPedidos.Table.CurrentRecord.GetValue("serie")
        ''        Case "B001"
        ''            f.TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - BOLETA ELECTRONICA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        ''            f.txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA ELECTRONICA-" & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        ''            f.serieFactura = Me.dgPedidos.Table.CurrentRecord.GetValue("serie")
        ''            f.numeroFactura = Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        ''            f.tipoDocumento = Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc")
        ''            direccionArchivo = Gempresas.IdEmpresaRuc & "-BOLETA ELECTRONICA-" & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc") & ".pdf"
        ''        Case "F001"
        ''            f.TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA ELECTRONICA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        ''            f.txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA ELECTRONICA-" & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        ''            f.serieFactura = Me.dgPedidos.Table.CurrentRecord.GetValue("serie")
        ''            f.numeroFactura = Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        ''            f.tipoDocumento = Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc")
        ''            direccionArchivo = Gempresas.IdEmpresaRuc & "-FACTURA ELECTRONICA-" & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc") & ".pdf"
        ''            direccionArchivoXML = Gempresas.IdEmpresaRuc & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc") & ".xml"
        ''        Case Else
        ''            If (Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc") = "01") Then
        ''                f.TextBoxASUNTO.Text = Gempresas.NomEmpresa & " - FACTURA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        ''                f.txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-FACTURA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        ''                direccionArchivo = Gempresas.IdEmpresaRuc & "-FACTURA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc") & ".pdf"
        ''            ElseIf (Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc") = "03") Then
        ''                f.TextBoxASUNTO.Text = "BOLETA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        ''                f.txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-BOLETA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        ''                direccionArchivo = Gempresas.IdEmpresaRuc & "-BOLETA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc") & ".pdf"
        ''            ElseIf (Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc") = "9901") Then
        ''                f.TextBoxASUNTO.Text = "PROFORMA " & 0 & "-" & 0
        ''                f.txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-PROFORMA " & 0 & "-" & 0
        ''                direccionArchivo = Gempresas.IdEmpresaRuc & "-PROFORMA " & 0 & "-" & 0 & ".pdf"
        ''            Else
        ''                f.TextBoxASUNTO.Text = "NOTA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        ''                f.txtDireccionEnvio.Text = Gempresas.IdEmpresaRuc & "-NOTA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc")
        ''                direccionArchivo = Gempresas.IdEmpresaRuc & "-NOTA " & Me.dgPedidos.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgPedidos.Table.CurrentRecord.GetValue("numeroDoc") & ".pdf"
        ''            End If
        ''    End Select


        ''    If Not System.IO.File.Exists("C:\FACTURASELECTRONICAS\PDF\" & direccionArchivo) Then

        ''        f.ImprimirTicketA4(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"), direccionArchivoXML)

        ''    End If
        ''    f.DocumentoID = Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")
        ''    f.StartPosition = FormStartPosition.CenterScreen
        ''    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        ''    f.ShowDialog()
        ''Else
        ''    MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ''End If
        ''Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If ToolStripButton3.Tag = "Inactivo" Then
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
            ToolStripButton3.Tag = "activo"
        Else
            ToolStripButton3.Tag = "Inactivo"
            filter.ClearFilters(dgPedidos)
            dgPedidos.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs)
        Try
            Dim fechaAnt = New Date(anioSel, CInt(mesSel), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = CierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = CierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = anioSel, .mes = CInt(mesSel)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            Dim r As Record = dgPedidos.Table.CurrentRecord
            If Not IsNothing(r) Then
                Select Case r.GetValue("tipoCompra")

                    Case TIPO_VENTA.VENTA_POS_DIRECTA, TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_GENERAL, TIPO_VENTA.VENTA_ANTICIPADA, TIPO_VENTA.VENTA_ANTICIPADA_RECIBIDO, TIPO_VENTA.VENTA_ANTICIPADA_OTORGADO,
                        TIPO_VENTA.VENTA_CONTADO_TOTAL, TIPO_VENTA.VENTA_CONTADO_PARCIAL, TIPO_VENTA.VENTA_CREDITO_TOTAL, TIPO_VENTA.VENTA_CREDITO_PARCIAL

                        'If r.GetValue("estado") = "Anulado x NC." Then
                        '    MessageBox.Show("Este Documento ya fue anulado", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '    Exit Sub
                        'Else

                        If r.GetValue("tipoDoc") = "01" Then

                            Dim f As New frmNotaVentaNew(CInt(r.GetValue("idDocumento")))
                            f.lblPerido.Text = mesSel & "/" & anioSel
                            f.txtFecha.Value = New Date(CInt(anioSel), CInt(mesSel), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()

                        Else

                            MessageBox.Show("Seleccione una Factura", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        End If

                    Case Else
                        MessageBox.Show("Debe seleccionar una venta", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub



    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs)
        Dim r As Record = dgPedidos.Table.CurrentRecord
        Dim ventaDetSA As New documentoVentaAbarrotesDetSA
        If Not IsNothing(r) Then

            If r.GetValue("tipoDoc") = "01" Or r.GetValue("tipoDoc") = "03" Then

                ClipBoardDocumento = New documento
                ClipBoardDocumento.documentoventaAbarrotes = ventaSA.GetUbicar_documentoventaAbarrotesPorID(Val(r.GetValue("idDocumento")))
                'Dim listaDetalle = CompraDetSA.UbicarDetalleCompraEval(Val(r.GetValue("idDocumento")))
                Dim listaDetalle = ventaDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(Val(r.GetValue("idDocumento")))
                ClipBoardDocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = listaDetalle
                MessageBox.Show("Comprobante copiado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        End If
    End Sub

    Private Sub PanelError_Paint(sender As Object, e As PaintEventArgs) Handles PanelError.Paint

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then
            If MessageBox.Show("Desea Eliminar el item seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Select Case Me.dgPedidos.Table.CurrentRecord.GetValue("tipoCompra")
                    Case TIPO_COMPRA.NOTA_CREDITO
                        Dim tiene As Integer = ValidarStock(Me.dgPedidos.Table.CurrentRecord.GetValue("idPadre"))
                        If tiene = 0 Then
                            EliminarNota(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                        Else
                            MessageBox.Show("No se puede eliminar por que no hay stock!", "Atención")
                        End If
                        'EliminarNota(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                    Case TIPO_COMPRA.NOTA_DEBITO
                    '    EliminarNotaDebito(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                    Case TIPO_VENTA.VENTA_NOTA_PEDIDO
                        EliminarPV(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                    Case TIPO_VENTA.VENTA_GENERAL
                        'se elimina atraves de las notas de credito
                        EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                    Case TIPO_VENTA.VENTA_POS_DIRECTA ', TIPO_VENTA.VENTA_AL_TICKET
                        If Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc") = "03" Then


                            Dim clas = (Me.dgPedidos.Table.CurrentRecord.GetValue("enviosunat"))

                            If clas.ToString.Trim.Length > 0 Then
                                If Me.dgPedidos.Table.CurrentRecord.GetValue("enviosunat") = "VA" Then

                                    EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                                Else
                                    MessageBox.Show("La Boleta no se encuentra Validado!", "Atención")
                                End If
                            Else
                                MessageBox.Show("La Boleta no se encuentra Validado!", "Atención")
                            End If
                        Else
                            EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                        End If


                        'If Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc") = "03" Then

                        '    If Me.dgPedidos.Table.CurrentRecord.GetValue("enviosunat") = Nothing Then

                        '        MessageBox.Show("La Boleta no se encuentra Validado!", "Atención")
                        '    Else

                        '        If Me.dgPedidos.Table.CurrentRecord.GetValue("enviosunat") = "VA" Then

                        '            EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                        '        Else
                        '            MessageBox.Show("La Boleta no se encuentra Validado!", "Atención")
                        '        End If



                        '    End If




                        'Else
                        '        EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                        'End If




                    Case TIPO_VENTA.VENTA_AL_TICKET
                        EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                        '   EliminarPVDirecta(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                End Select
            End If
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TXTcOMPRADOR_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TXTcOMPRADOR.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub TXTcOMPRADOR_TextChanged(sender As Object, e As EventArgs) Handles TXTcOMPRADOR.TextChanged
        TXTcOMPRADOR.ForeColor = Color.Black
        TXTcOMPRADOR.Tag = Nothing
        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            txtruc.Visible = True
        Else
            txtruc.Visible = False
        End If
    End Sub

    Private Sub LsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Me.Cursor = Cursors.WaitCursor

        If e.PopupCloseType = PopupCloseType.Done Then
            If LsvProveedor.SelectedItems.Count > 0 Then

                TXTcOMPRADOR.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                    TXTcOMPRADOR.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                    TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtruc.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
                'txtTipoDocClie.Text = LsvProveedor.SelectedItems(0).SubItems(3).Text
                txtruc.Visible = True

                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.TXTcOMPRADOR.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim periodo = String.Format("{0:00}", cboMesPedido.SelectedValue)
        periodo = periodo & "/" & cboAnio.Text

        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListarAllVentasPorDia(txtFechaHora.Value)))
        thread.Start()

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim periodo = String.Format("{0:00}", cboMesPedido.SelectedValue)
        periodo = periodo & "/" & cboAnio.Text

        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorCliente(TXTcOMPRADOR.Tag)))
        thread.Start()

    End Sub

    Private Sub rbPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles rbPeriodo.CheckedChanged
        If (rbPeriodo.Checked = True) Then
            pnDia.Visible = False
            pnPeriodo.Visible = True
            pnCliente.Visible = False
            rbPeriodo.Checked = True
            rbDia.Checked = False
            rbCliente.Checked = False
        End If
    End Sub

    Private Sub rbDia_CheckedChanged(sender As Object, e As EventArgs) Handles rbDia.CheckedChanged
        If (rbDia.Checked = True) Then
            pnDia.Visible = True
            pnPeriodo.Visible = False
            pnCliente.Visible = False
            rbDia.Checked = True
            rbPeriodo.Checked = False
            rbCliente.Checked = False
        End If
    End Sub

    Private Sub rbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles rbCliente.CheckedChanged
        If (rbCliente.Checked = True) Then
            pnDia.Visible = False
            pnPeriodo.Visible = False
            pnCliente.Visible = True
            rbCliente.Checked = True
            rbPeriodo.Checked = False
            rbDia.Checked = False
        End If
    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        Dim periodoSel = String.Format("{0:00}", cboMesPedido.SelectedValue)
        periodoSel = periodoSel & "/" & cboAnio.Text
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorPeriodo(periodoSel)))
        thread.Start()
    End Sub

    Private Sub TXTcOMPRADOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTcOMPRADOR.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TXTcOMPRADOR
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            'consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})



            Dim consulta2 = (From n In listaClientes
                             Where n.nombreCompleto.StartsWith(TXTcOMPRADOR.Text) Or n.nrodoc.StartsWith(TXTcOMPRADOR.Text)).ToList

            consulta.AddRange(consulta2)
            FillLSVClientes(consulta)
            e.Handled = True
        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TXTcOMPRADOR
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
End Class
