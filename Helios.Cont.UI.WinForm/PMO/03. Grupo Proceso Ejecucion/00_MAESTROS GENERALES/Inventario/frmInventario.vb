Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.GroupingGridExcelConverter

Public Class frmInventario
    Inherits frmMaster
    Dim colorx As New GridMetroColors()
    Dim lblCenter As Label
    Dim DocumentoCompra As New List(Of documentocompra)
    Dim DocumentoPendiente As New List(Of documentoGuia)
    Dim lblAlertaStock As Label
    Dim lbltransito As Label
    Dim lbltransito2 As Label
    Dim lblnumeracion As Label
    Dim lbltransitoConfirmado As Label
    Dim notif As New FeedbackForm
    Dim lblHistorial As New Label
    Dim lblpedidoGuia As New Label
    Dim listaventa As New List(Of documentoventaAbarrotes)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ToolStrip1.Visible = False
        ' Me.ToolStrip1.Enabled = False
        Me.WindowState = FormWindowState.Normal
        lblCenter = New Label
        lblAlertaStock = New Label
        lbltransito = New Label
        lbltransito2 = New Label
        lblnumeracion = New Label
        lblHistorial = New Label
        lblpedidoGuia = New Label
        lbltransitoConfirmado = New Label
        treeViewAdv2.BackColor = Color.MediumSeaGreen
        GetTransitoNumeracion()
        ' Add any initialization after the InitializeComponent() call.
        'GridCFGInventarios(dgvKardexVal)
        'GridCFG2(dgvTransito)
        'GridCFG2(dgvEnvioAlmacen)
        'GridCFGKardex(dgvKardex2)
        'GridCFGKardex(dgvStockMinimo)
        'CargarCMB()
        'GridColumnConfig()
        'GetCountExistenciaTransito()
        'GetInventarioEnAlertaConteo(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
        'GetProveedoresEnTransito(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
        '                                                                           .tipoCompra = TIPO_COMPRA.COMPRA})
        getdatoscenteoVentas()
        GetCargarVentasGuia()
        GetTransitoConteo()
        almacenTransito()

        Hilo()

        hiloCompleto()
        GridCFGInventarios(dgvKardexVal)
        GridCFG2(dgvTransito)
        GridCFG2(dgvEnvioAlmacen)
        GridCFGKardex(dgvKardex2)
        GridCFGKardex(dgvStockMinimo)
        ToolStrip1.Visible = True
    End Sub

#Region "Tba Almacenes"
    Sub GetAlmacenes()
        Dim almacenSA As New almacenSA
        Dim dt As New DataTable
        dt.Columns.Add("idalmacen")
        dt.Columns.Add("almacen")
        dt.Columns.Add("encargado")
        dt.Columns.Add("estado")

        For Each i In almacenSA.GetListar_almacenesTipobyEmpresa(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .tipo = TipoAlmacen.Deposito})
            dt.Rows.Add(i.idAlmacen, i.descripcionAlmacen, i.encargado, i.estado)
        Next
        dgAlmacen.DataSource = dt

    End Sub
#End Region

    Sub Hilo()
        Dim almacenSA As New almacenSA


        CargarCMB()
        GridColumnConfig()
        GetCountExistenciaTransito()
        GetInventarioEnAlertaConteo(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
        GetProveedoresEnTransito(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                   .tipoCompra = TIPO_COMPRA.COMPRA})


        Dim ggcStyle As GridTableCellStyleInfo = dgvEnvioAlmacen.TableDescriptor.Columns("almacenEnvio").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        ggcStyle.ValueMember = "idAlmacen"
        ggcStyle.DisplayMember = "descripcionAlmacen"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        dgvEnvioAlmacen.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell

        lblCenter.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblCenter.AutoSize = False
        lblCenter.BackColor = Color.Transparent
        lblCenter.Dock = DockStyle.Fill
        lblCenter.ForeColor = Color.Yellow
        lblCenter.TextAlign = ContentAlignment.MiddleLeft


        lblAlertaStock.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblAlertaStock.AutoSize = False
        lblAlertaStock.BackColor = Color.Transparent
        lblAlertaStock.Dock = DockStyle.Fill
        lblAlertaStock.ForeColor = Color.Yellow
        lblAlertaStock.TextAlign = ContentAlignment.MiddleLeft

        lbltransito.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lbltransito.AutoSize = False
        lbltransito.BackColor = Color.Transparent
        lbltransito.Dock = DockStyle.Fill
        lbltransito.ForeColor = Color.Yellow
        lbltransito.TextAlign = ContentAlignment.MiddleLeft

        lbltransitoConfirmado.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lbltransitoConfirmado.AutoSize = False
        lbltransitoConfirmado.BackColor = Color.Transparent
        lbltransitoConfirmado.Dock = DockStyle.Fill
        lbltransitoConfirmado.ForeColor = Color.Yellow
        lbltransitoConfirmado.TextAlign = ContentAlignment.MiddleLeft

        lbltransito2.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lbltransito2.AutoSize = False
        lbltransito2.BackColor = Color.Transparent
        lbltransito2.Dock = DockStyle.Fill
        lbltransito2.ForeColor = Color.Yellow
        lbltransito2.TextAlign = ContentAlignment.MiddleLeft

        lblnumeracion.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblnumeracion.AutoSize = False
        lblnumeracion.BackColor = Color.Transparent
        lblnumeracion.Dock = DockStyle.Fill
        lblnumeracion.ForeColor = Color.Yellow
        lblnumeracion.TextAlign = ContentAlignment.MiddleLeft
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
        lblHistorial.ForeColor = Color.Yellow
        lblHistorial.TextAlign = ContentAlignment.MiddleLeft

        lblpedidoGuia.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblpedidoGuia.AutoSize = False
        lblpedidoGuia.BackColor = Color.Transparent
        lblpedidoGuia.Dock = DockStyle.Fill
        lblpedidoGuia.ForeColor = Color.Yellow
        lblpedidoGuia.TextAlign = ContentAlignment.MiddleLeft

    End Sub

    Sub hiloCompleto()
        cboConsultaRotacion.DropDownStyle = ComboBoxStyle.DropDownList
        cboConsultaRotacion.SelectedIndex = 0

        TabAlmacen.Parent = Nothing
        TabDashboard.Parent = Nothing
        TabTransito.Parent = TabControlAdv1
        TabInventario.Parent = Nothing
        TabKardex.Parent = Nothing
        TabMovimientos.Parent = Nothing
        TabAlertaInventario.Parent = Nothing
        TabPageAdv2.Parent = Nothing
        TabRQ.Parent = Nothing

        ToolStripButton15.Visible = False
        ToolStripButton16.Visible = False



        Me.treeViewAdv2.Nodes(0).CustomControl = lblCenter
        Me.treeViewAdv2.Nodes(4).CustomControl = lblAlertaStock
        Me.treeViewAdv2.Nodes(8).Nodes(0).CustomControl = lbltransito
        Me.treeViewAdv2.Nodes(8).Nodes(1).CustomControl = lbltransito2
        Me.treeViewAdv2.Nodes(8).Nodes(2).CustomControl = lbltransitoConfirmado
        Me.treeViewAdv2.Nodes(8).Nodes(3).CustomControl = lblnumeracion

        Me.treeViewAdv2.Nodes(11).Nodes(0).CustomControl = lblpedidoGuia  ' Anulados
        Me.treeViewAdv2.Nodes(11).Nodes(1).CustomControl = lblHistorial  ' Anulados

        'rbTransito.Text = "Tránsito (" + lbltransito.Text + ")"
        Dim s As New DateTime
        s = DateTime.Now
        Dim addDay As DateTime = s.AddDays(CInt(-30))
        txtfecFin.Value = DateTime.Now
        txtfecInicio.Value = addDay

        lblPeriodo.Text = "Período: " & PeriodoGeneral
        txtPeriodo.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)
    End Sub
#Region "métodos"

    Private Sub getTableComprasPorPeriodoContado(intIdEstablecimiento As Integer, strPeriodo As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim dt As New DataTable("Compras - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("Aprobado", GetType(String)))
        dt.Columns.Add(New DataColumn("ant", GetType(Integer)))
        dt.Columns.Add(New DataColumn("estadoEntrega", GetType(String)))
        dt.Columns.Add(New DataColumn("idEstablecimiento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nombreEstablecimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("almacenOrigen", GetType(String)))
        dt.Columns.Add(New DataColumn("almacenDestino", GetType(String)))

        Dim str As String
        For Each i As documentocompra In DocumentoCompra
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona

            If i.tipoCompra = "BOFR" Then
                dr(10) = CDec(0.0)
                dr(11) = CDec(0.0)
                dr(12) = CDec(0.0)
            Else
                dr(10) = i.importeTotal
                dr(11) = i.tcDolLoc
                dr(12) = i.importeUS
            End If

            'dr(11) = i.tcDolLoc
            'dr(12) = i.importeUS
            dr(13) = i.monedaDoc
            dr(14) = i.usuarioActualizacion
            dr(15) = i.situacion
            Select Case i.estadoPago
                Case TIPO_COMPRA.PAGO.PAGADO
                    dr(16) = "Saldado"
                Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    dr(16) = "Pendiente"
            End Select

            Select Case i.aprobado
                Case "S"
                    dr(17) = "Aprobado"
                Case Else
                    dr(17) = "Pendiente"
            End Select
            dr(18) = i.Atraso

            Select Case i.estadoEntrega
                Case "DC"
                    dr(19) = "ENTREGADO"
                Case "PN"
                    dr(19) = "POR ENTREGAR"
            End Select
            dr(20) = GEstableciento.IdEstablecimiento
            dr(21) = GEstableciento.NombreEstablecimiento
            dr(22) = i.NomAlmacenDestino
            dr(23) = i.NomAlmacenOrigen
            dt.Rows.Add(dr)
        Next
        dgvTransferencia.DataSource = dt
        dgvTransferencia.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
    End Sub


    Private Sub getTableComprasPorPeriodoContadoTipo(strTipo As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA


        Dim dt As New DataTable("Compras - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("Aprobado", GetType(String)))
        dt.Columns.Add(New DataColumn("ant", GetType(Integer)))
        dt.Columns.Add(New DataColumn("estadoEntrega", GetType(String)))

        dt.Columns.Add(New DataColumn("idEstablecimiento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nombreEstablecimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("almacenOrigen", GetType(String)))
        dt.Columns.Add(New DataColumn("almacenDestino", GetType(String)))

        Dim str As String
        For Each i As documentocompra In DocumentoCompra

            If (strTipo = i.estadoEntrega) Then
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.tipoCompra
                dr(2) = str
                dr(3) = i.tipoDoc
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                dr(6) = i.tipoDocEntidad
                dr(7) = i.NroDocEntidad
                dr(8) = i.NombreEntidad
                dr(9) = i.TipoPersona

                If i.tipoCompra = "BOFR" Then
                    dr(10) = CDec(0.0)
                    dr(11) = CDec(0.0)
                    dr(12) = CDec(0.0)
                Else
                    dr(10) = i.importeTotal
                    dr(11) = i.tcDolLoc
                    dr(12) = i.importeUS
                End If

                'dr(11) = i.tcDolLoc
                'dr(12) = i.importeUS
                dr(13) = i.monedaDoc
                dr(14) = i.usuarioActualizacion
                dr(15) = i.situacion
                Select Case i.estadoPago
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(16) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(16) = "Pendiente"
                End Select

                Select Case i.aprobado
                    Case "S"
                        dr(17) = "Aprobado"
                    Case Else
                        dr(17) = "Pendiente"
                End Select
                dr(18) = i.Atraso

                Select Case i.estadoEntrega
                    Case "DC"
                        dr(19) = "ENTREGADO"
                    Case "PN"
                        dr(19) = "POR ENTREGAR"
                End Select
                dr(20) = GEstableciento.IdEstablecimiento
                dr(21) = GEstableciento.NombreEstablecimiento
                dr(22) = i.NomAlmacenDestino
                dr(23) = i.NomAlmacenOrigen

                dt.Rows.Add(dr)

            ElseIf (strTipo = i.estadoEntrega) Then
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.tipoCompra
                dr(2) = str
                dr(3) = i.tipoDoc
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                dr(6) = i.tipoDocEntidad
                dr(7) = i.NroDocEntidad
                dr(8) = i.NombreEntidad
                dr(9) = i.TipoPersona

                If i.tipoCompra = "BOFR" Then
                    dr(10) = CDec(0.0)
                    dr(11) = CDec(0.0)
                    dr(12) = CDec(0.0)
                Else
                    dr(10) = i.importeTotal
                    dr(11) = i.tcDolLoc
                    dr(12) = i.importeUS
                End If

                'dr(11) = i.tcDolLoc
                'dr(12) = i.importeUS
                dr(13) = i.monedaDoc
                dr(14) = i.usuarioActualizacion
                dr(15) = i.situacion
                Select Case i.estadoPago
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(16) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(16) = "Pendiente"
                End Select

                Select Case i.aprobado
                    Case "S"
                        dr(17) = "Aprobado"
                    Case Else
                        dr(17) = "Pendiente"
                End Select
                dr(18) = i.Atraso

                Select Case i.estadoEntrega
                    Case "DC"
                        dr(19) = "ENTREGADO"
                    Case "PN"
                        dr(19) = "POR ENTREGAR"
                End Select
                dr(20) = GEstableciento.IdEstablecimiento
                dr(21) = GEstableciento.NombreEstablecimiento
                dr(22) = i.NomAlmacenDestino
                dr(23) = i.NomAlmacenOrigen

                dt.Rows.Add(dr)

            End If
        Next
        dgvTransferencia.DataSource = dt
        dgvTransferencia.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
    End Sub

    Private Sub getTableComprasPorPeriodoContadoBuscar(strbuscar As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA


        Dim dt As New DataTable("Compras - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("Aprobado", GetType(String)))
        dt.Columns.Add(New DataColumn("ant", GetType(Integer)))
        dt.Columns.Add(New DataColumn("estadoEntrega", GetType(String)))

        Dim i = (From a In DocumentoCompra Where a.idDocumento = strbuscar).FirstOrDefault

        Dim str As String
        'For Each i As documentocompra In DocumentoCompra


        Dim dr As DataRow = dt.NewRow()
        str = Nothing
        str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
        dr(0) = i.idDocumento
        dr(1) = i.tipoCompra
        dr(2) = str
        dr(3) = i.tipoDoc
        dr(4) = i.serie
        dr(5) = i.numeroDoc
        dr(6) = i.tipoDocEntidad
        dr(7) = i.NroDocEntidad
        dr(8) = i.NombreEntidad
        dr(9) = i.TipoPersona

        If i.tipoCompra = "BOFR" Then
            dr(10) = CDec(0.0)
            dr(11) = CDec(0.0)
            dr(12) = CDec(0.0)
        Else
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            dr(12) = i.importeUS
        End If

        'dr(11) = i.tcDolLoc
        'dr(12) = i.importeUS
        dr(13) = i.monedaDoc
        dr(14) = i.usuarioActualizacion
        dr(15) = i.situacion
        Select Case i.estadoPago
            Case TIPO_COMPRA.PAGO.PAGADO
                dr(16) = "Saldado"
            Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                dr(16) = "Pendiente"
        End Select

        Select Case i.aprobado
            Case "S"
                dr(17) = "Aprobado"
            Case Else
                dr(17) = "Pendiente"
        End Select
        dr(18) = i.Atraso

        Select Case i.estadoEntrega
            Case "DC"
                dr(19) = "ENTREGADO"
            Case "PN"
                dr(19) = "POR ENTREGAR"
        End Select


        dt.Rows.Add(dr)


        dgvTransferencia.DataSource = dt
        dgvTransferencia.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
    End Sub

    Sub GridCFGInventarios(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False


        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Private Sub getTableOrdenDeComprasPorPeriodo(intIdEstablecimiento As Integer, strPeriodo As String, tipoCompra As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim DocumentoCompra As New List(Of documentocompra)
        'Dim MONEDAORDEN As Integer
        Dim dt As New DataTable("Compras - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("nombrePersona", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))


        'Select Case AutorizacionRolList(0).IDRol
        '    Case 1


        DocumentoCompra = DocumentoCompraSA.GetListarOrdenComprasPorPeriodoGeneral(intIdEstablecimiento, strPeriodo, tipoCompra)
        '    Case 2
        'DocumentoCompra = DocumentoCompraSA.GetListarComprasPorPeriodoGeneral_CONT_CONTADO(intIdEstablecimiento, strPeriodo, GFichaUsuarios.IdCajaUsuario)
        'End Select

        Dim str As String
        For Each i As documentocompra In DocumentoCompra
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc

            dr(6) = i.NombreEntidad
            If i.tipoCompra = "BOFR" Then
                dr(7) = CDec(0.0)
                dr(8) = CDec(0.0)
                dr(9) = CDec(0.0)
            Else
                dr(7) = i.importeTotal
                dr(8) = i.tcDolLoc
                dr(9) = i.importeUS
            End If

            'dr(11) = i.tcDolLoc
            'dr(12) = i.importeUS
            dr(10) = i.monedaDoc
            'dr(12) = i.usuarioActualizacion
            dr(11) = i.situacion
            Select Case i.estadoPago
                Case TIPO_COMPRA.PAGO.PAGADO
                    dr(12) = "Saldado"
                Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    dr(12) = "Pendiente"
            End Select

            'Select Case i.aprobado
            '    Case "S"
            '        dr(15) = "Aprobado"
            '    Case Else
            '        dr(15) = "Pendiente"
            'End Select
            'dr(16) = i.Atraso
            dt.Rows.Add(dr)
        Next
        dgvOrdenCompra.DataSource = dt
        dgvOrdenCompra.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
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
        dgvVentaGeneralGuia.DataSource = dt

    End Sub

    Private Sub getTableComprasPorPeriodoCambioTipoInventario(strTipo As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim objCompra As New List(Of documentocompra)

        Dim dt As New DataTable("Compras - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("Aprobado", GetType(String)))
        dt.Columns.Add(New DataColumn("ant", GetType(Integer)))
        dt.Columns.Add(New DataColumn("estadoEntrega", GetType(String)))

        dt.Columns.Add(New DataColumn("idEstablecimiento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nombreEstablecimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("almacenOrigen", GetType(String)))
        dt.Columns.Add(New DataColumn("almacenDestino", GetType(String)))

        Dim str As String


        objCompra = DocumentoCompraSA.GetListarComprasPorPeriodoCambioGeneral(GEstableciento.IdEstablecimiento, PeriodoGeneral)

        For Each i As documentocompra In objCompra

            If (strTipo = i.estadoEntrega) Then
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.tipoCompra
                dr(2) = str
                dr(3) = i.tipoDoc
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                dr(6) = i.tipoDocEntidad
                dr(7) = i.NroDocEntidad
                dr(8) = i.NombreEntidad
                dr(9) = i.TipoPersona

                If i.tipoCompra = "BOFR" Then
                    dr(10) = CDec(0.0)
                    dr(11) = CDec(0.0)
                    dr(12) = CDec(0.0)
                Else
                    dr(10) = i.importeTotal
                    dr(11) = i.tcDolLoc
                    dr(12) = i.importeUS
                End If

                'dr(11) = i.tcDolLoc
                'dr(12) = i.importeUS
                dr(13) = i.monedaDoc
                dr(14) = i.usuarioActualizacion
                dr(15) = i.situacion
                Select Case i.estadoPago
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(16) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(16) = "Pendiente"
                End Select

                Select Case i.aprobado
                    Case "S"
                        dr(17) = "Aprobado"
                    Case Else
                        dr(17) = "Pendiente"
                End Select
                dr(18) = i.Atraso

                Select Case i.estadoEntrega
                    Case "DC"
                        dr(19) = "ENTREGADO"
                    Case "PN"
                        dr(19) = "POR ENTREGAR"
                End Select
                dr(20) = GEstableciento.IdEstablecimiento
                dr(21) = GEstableciento.NombreEstablecimiento
                dr(22) = i.NomAlmacenDestino
                dr(23) = i.NomAlmacenOrigen

                dt.Rows.Add(dr)

            ElseIf (strTipo = i.estadoEntrega) Then
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.tipoCompra
                dr(2) = str
                dr(3) = i.tipoDoc
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                dr(6) = i.tipoDocEntidad
                dr(7) = i.NroDocEntidad
                dr(8) = i.NombreEntidad
                dr(9) = i.TipoPersona

                If i.tipoCompra = "BOFR" Then
                    dr(10) = CDec(0.0)
                    dr(11) = CDec(0.0)
                    dr(12) = CDec(0.0)
                Else
                    dr(10) = i.importeTotal
                    dr(11) = i.tcDolLoc
                    dr(12) = i.importeUS
                End If

                'dr(11) = i.tcDolLoc
                'dr(12) = i.importeUS
                dr(13) = i.monedaDoc
                dr(14) = i.usuarioActualizacion
                dr(15) = i.situacion
                Select Case i.estadoPago
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(16) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(16) = "Pendiente"
                End Select

                Select Case i.aprobado
                    Case "S"
                        dr(17) = "Aprobado"
                    Case Else
                        dr(17) = "Pendiente"
                End Select
                dr(18) = i.Atraso

                Select Case i.estadoEntrega
                    Case "DC"
                        dr(19) = "ENTREGADO"
                    Case "PN"
                        dr(19) = "POR ENTREGAR"
                End Select
                dr(20) = GEstableciento.IdEstablecimiento
                dr(21) = GEstableciento.NombreEstablecimiento
                dr(22) = i.NomAlmacenDestino
                dr(23) = i.NomAlmacenOrigen

                dt.Rows.Add(dr)

            End If
        Next
        dgvCambioInventario.DataSource = dt
        dgvCambioInventario.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
    End Sub

    Private Sub getTableGuiaRemision(intIdEstablecimiento As Integer, strPeriodo As String, idEmpresa As String)
        Dim DocumentoGuiaSA As New DocumentoGuiaSA
        Dim documentoGuia As New List(Of documentoGuia)
        'Dim MONEDAORDEN As Integer
        Dim dt As New DataTable("Guia remisión - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer))) '0
        dt.Columns.Add(New DataColumn("idEmpresa", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreEmpresa", GetType(String)))
        dt.Columns.Add(New DataColumn("idCentroCosto", GetType(Integer))) ' 3
        dt.Columns.Add(New DataColumn("nombreEstablecimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String))) '6
        dt.Columns.Add(New DataColumn("importeMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estadoGuia")) '9
        dt.Columns.Add(New DataColumn("idPadre", GetType(Integer))) '9

        documentoGuia = DocumentoGuiaSA.ListaGuiasPorCompraSinNumeracion(intIdEstablecimiento, strPeriodo, idEmpresa)

        Dim str As String
        For Each i As documentoGuia In documentoGuia
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.idEmpresa
            dr(2) = Gempresas.NomEmpresa
            dr(3) = i.idCentroCosto
            dr(4) = GEstableciento.NombreEstablecimiento
            dr(5) = i.fechaDoc
            dr(6) = i.tipoDoc
            dr(7) = i.importeMN
            dr(8) = i.importeME
            dr(9) = i.estadoGuia
            dr(10) = i.idEntidadTransporte

            dt.Rows.Add(dr)
        Next
        dgvPendiente.DataSource = dt
        dgvPendiente.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
    End Sub

    Sub VentasCantidadStock(cantidad As String, fechaini As Date, fechafin As Date, mayor As Decimal, menor As Decimal, nombre As String)
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoventa As New List(Of documentoventaAbarrotesDet)
        Dim dt As New DataTable(nombre)


        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("monto")
        dt.Columns.Add("stock")
        dt.Columns.Add("idalmacen")


        documentoventa = documentoSA.VentasCantidadStock(cantidad, fechaini, fechafin, mayor, menor)

        For Each i In documentoventa
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idItem
            dr(1) = i.nombreItem
            dr(2) = i.monto1
            dr(3) = i.monto2

            dr(4) = i.NombreProveedor


            dt.Rows.Add(dr)
        Next
        dgvRotacion.DataSource = dt


    End Sub

    Public Sub GetInventarioEnAlertaConteo(be As totalesAlmacen)
        Dim totalSA As New TotalesAlmacenSA

        lblAlertaStock.Text = totalSA.GetAlertaIventarioMinimoConteo(be)

    End Sub

    Public Sub GetTransitoConteo()
        Dim DocumentoCompraSA As New DocumentoCompraSA

        DocumentoCompra = New List(Of documentocompra)
        DocumentoCompra = DocumentoCompraSA.GetListarComprasPorPeriodoGeneralTransferencia(GEstableciento.IdEstablecimiento, PeriodoGeneral)


        Dim i = (From a In DocumentoCompra Where a.estadoEntrega = "PN").Count
        Dim x = (From a In DocumentoCompra Where a.estadoEntrega = "DC").Count

        lbltransito.Text = i
        lbltransito2.Text = i
        lbltransitoConfirmado.Text = x



        'If (lbltransito.Text.Length > 0) Then
        '    rbTransito.Text = "Tránsito (" + lbltransito.Text + ")"
        'End If

    End Sub

    Public Sub GetTransitoNumeracion()
        Dim DocumentoPendientelSA As New DocumentoGuiaSA
        Dim z As Integer = 0
        DocumentoPendiente = New List(Of documentoGuia)
        DocumentoPendiente = DocumentoPendientelSA.ListaGuiasPorCompraSinNumeracion(GEstableciento.IdEstablecimiento, PeriodoGeneral, Gempresas.IdEmpresaRuc)
        If DocumentoPendiente.Count > 0 Then
            z = (From a In DocumentoPendiente Where a.estadoGuia = "PN").Count
        Else
            z = 0
        End If

        lblnumeracion.Text = z

        'If (lbltransito.Text.Length > 0) Then
        '    rbTransito.Text = "Tránsito (" + lbltransito.Text + ")"
        'End If

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
        dgvDetalleTransferencia.DataSource = dt

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

    Public Sub ObtenerListaGuiaRemisionVenta(iddocumento As Integer)
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
        dgvListaVentaGuia.DataSource = dt

    End Sub

    Public Sub GetInventarioEnAlerta(be As totalesAlmacen)
        Dim totalSA As New TotalesAlmacenSA
        Dim dt As New DataTable()

        dt.Columns.Add("idAlmacen")
        dt.Columns.Add("almacen")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("importeMN")
        dt.Columns.Add("importeME")
        dt.Columns.Add("cantidadMinima")
        dt.Columns.Add("iditem")
        dt.Columns.Add("item")
        dt.Columns.Add("unidad")

        For Each i In totalSA.GetAlertaIventarioMinimo(be)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idAlmacen
            dr(1) = i.NomAlmacen
            dr(2) = i.cantidad
            dr(3) = i.importeSoles
            dr(4) = i.importeDolares
            dr(5) = i.cantidadMinima
            dr(6) = i.idItem
            dr(7) = i.descripcion
            dr(8) = i.idUnidad
            dt.Rows.Add(dr)
        Next
        dgvStockMinimo.DataSource = dt

    End Sub

    Public Sub GetProveedoresEnTransito(be As documentocompra)
        Dim invSA As New inventarioMovimientoSA

        cboproveedor.DisplayMember = "nombreCompleto"
        cboproveedor.ValueMember = "idEntidad"
        cboproveedor.DataSource = invSA.GetProveedoresEnTransito(be)

    End Sub

    Public Sub EliminarTransferenciaAlmacen(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim objDestino As New totalesAlmacen
        Dim ListaOrigen As New List(Of totalesAlmacen)
        Dim ListaDestino As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
        End With
        'For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(IntIdDocumento)
        '    If Not IsNothing(i.almacenRef) Then
        '        almacen = almacenSA.GetUbicar_almacenPorID(i.almacenRef)
        '        If Not IsNothing(almacen) Then
        '            If Not almacen.tipo = "AV" Then
        '                objNuevo = New totalesAlmacen
        '                objNuevo.SecuenciaDetalle = i.secuencia
        '                objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
        '                objNuevo.idEstablecimiento = almacen.idEstablecimiento
        '                objNuevo.idAlmacen = almacen.idAlmacen
        '                objNuevo.origenRecaudo = i.destino
        '                objNuevo.idItem = i.idItem
        '                objNuevo.TipoDoc = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoDoc")

        '                objNuevo.importeSoles = i.importe
        '                objNuevo.importeDolares = i.importeUS

        '                objNuevo.cantidad = i.monto1
        '                objNuevo.precioUnitarioCompra = i.precioUnitario

        '                objNuevo.montoIsc = i.montoIsc
        '                objNuevo.montoIscUS = i.montoIscUS

        '                ListaOrigen.Add(objNuevo)
        '            End If
        '            almacen = almacenSA.GetUbicar_almacenPorID(i.almacenDestino)
        '            objDestino = New totalesAlmacen
        '            objDestino.SecuenciaDetalle = i.secuencia
        '            objDestino.idEmpresa = Gempresas.IdEmpresaRuc
        '            objDestino.idEstablecimiento = almacen.idEstablecimiento
        '            objDestino.idAlmacen = almacen.idAlmacen
        '            objDestino.origenRecaudo = i.destino
        '            objDestino.idItem = i.idItem
        '            objDestino.TipoDoc = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoDoc")

        '            objDestino.importeSoles = i.importe
        '            objDestino.importeDolares = i.importeUS

        '            objDestino.cantidad = i.monto1
        '            objDestino.precioUnitarioCompra = i.precioUnitario

        '            objDestino.montoIsc = i.montoIsc
        '            objDestino.montoIscUS = i.montoIscUS
        '            ListaDestino.Add(objDestino)
        '        End If

        '    End If

        'Next
        documentoSA.DeleteOtrasTransAlmacenOESL(objDocumento)
    End Sub

    Public Sub RemoveCompra(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
        End With
        For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(IntIdDocumento)
            If Not IsNothing(i.almacenRef) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.almacenRef)
                If Not IsNothing(almacen) Then
                    If Not almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = Me.dgvMov.Table.CurrentRecord.GetValue("tipoDoc")

                        objNuevo.importeSoles = i.importe
                        objNuevo.importeDolares = i.importeUS

                        objNuevo.cantidad = i.monto1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc
                        objNuevo.montoIscUS = i.montoIscUS

                        ListaTotales.Add(objNuevo)

                    End If
                End If

            End If

        Next
        documentoSA.DeleteOtrasEntradas(objDocumento, ListaTotales)
    End Sub

    Public Sub EliminarOtrasSalidas(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
        End With
        For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(IntIdDocumento)
            If Not IsNothing(i.almacenRef) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.almacenRef)
                If Not IsNothing(almacen) Then
                    If Not almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = Me.dgvMov.Table.CurrentRecord.GetValue("tipoDoc")

                        objNuevo.importeSoles = i.importe
                        objNuevo.importeDolares = i.importeUS

                        objNuevo.cantidad = i.monto1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc
                        objNuevo.montoIscUS = i.montoIscUS

                        ListaTotales.Add(objNuevo)

                    End If
                End If

            End If

        Next
        documentoSA.DeleteOtrasSalidasDeAlmacen(objDocumento, ListaTotales)
    End Sub

    Sub GridCFGKardex(GGC As GridGroupingControl)
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

        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Sub GridCFG2(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        Dim colorx As New GridMetroColors()
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Function ValidarExistenciaDisponible(column As String) As Decimal
        Dim sumaMN As Decimal = 0
        For Each i As Record In dgvEnvioAlmacen.Table.Records
            sumaMN += CDec(i.GetValue(column))
        Next

        Return sumaMN
    End Function


    Sub GuiaRemision(objDocumentoCompra As documento, envio As EnvioExistencia)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        Dim itemSA As New detalleitemsSA
        Dim entidadSA As New entidadSA
        'REGISTRANDO LA GUIA DE REMISION
        Dim sumaMN As Decimal = 0
        Dim sumaME As Decimal = 0

        Dim ent = entidadSA.UbicarEntidadPorID(cboproveedor.SelectedValue).FirstOrDefault

        With objDocumentoCompra
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .tipoDoc = "99"
            .fechaProceso = envio.FechaEnvio
            .nroDoc = envio.Serie & "-" & envio.Numero
            .idOrden = Nothing
            .moneda = "-"
            .idEntidad = ent.idEntidad
            .entidad = ent.nombreCompleto
            .nrodocEntidad = ent.nrodoc
            .tipoOperacion = StatusTipoOperacion.COMPRA
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With guiaRemisionBE
            .codigoLibro = "8"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = envio.FechaEnvio
            .periodo = PeriodoGeneral
            .tipoDoc = "99"
            .serie = envio.Serie
            .numeroDoc = envio.Numero
            .idEntidad = Nothing ' docCompra.idProveedor
            .monedaDoc = Nothing ' docCompra.monedaDoc
            .tasaIgv = Nothing ' docCompra.tasaIgv
            .tipoCambio = Nothing ' docCompra.tcDolLoc
            .importeMN = 0
            .importeME = 0
            .glosa = "Guía de remisión por compras realizadas, distribución masiva"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE
        sumaMN = 0
        sumaME = 0
        For Each i As SelectedRecord In dgvTransito.Table.SelectedRecords
            sumaMN += CDec(i.Record.GetValue("saldoMontoMN"))
            sumaME += CDec(i.Record.GetValue("saldoMontoME"))

            documentoguiaDetalle = New documentoguiaDetalle
            documentoguiaDetalle.idDocumento = 0
            documentoguiaDetalle.secuenciaRef = Val(i.Record.GetValue("secCompra"))
            documentoguiaDetalle.idItem = Val(i.Record.GetValue("idItem"))
            documentoguiaDetalle.descripcionItem = i.Record.GetValue("descripcion")
            documentoguiaDetalle.destino = i.Record.GetValue("origen")
            documentoguiaDetalle.unidadMedida = i.Record.GetValue("unidad")
            documentoguiaDetalle.cantidad = CDec(i.Record.GetValue("saldoCan"))
            documentoguiaDetalle.precioUnitario = 0
            documentoguiaDetalle.precioUnitarioUS = 0
            documentoguiaDetalle.importeMN = CDec(i.Record.GetValue("saldoMontoMN"))
            documentoguiaDetalle.importeME = CDec(i.Record.GetValue("saldoMontoME"))
            documentoguiaDetalle.idDocumentoPadre = Val(i.Record.GetValue("idDocumento"))
            documentoguiaDetalle.almacenRef = envio.Almacen

            documentoguiaDetalle.secuencia = Val(i.Record.GetValue("secCompra"))

            documentoguiaDetalle.usuarioModificacion = usuario.IDUsuario
            documentoguiaDetalle.fechaModificacion = DateTime.Now
            ListaGuiaDetalle.Add(documentoguiaDetalle)
        Next
        objDocumentoCompra.documentoGuia.importeMN = sumaMN
        objDocumentoCompra.documentoGuia.importeME = sumaME
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Sub GuiaRemisionParcial(objDocumentoCompra As documento, envio As EnvioExistencia)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION
        Dim sumaMN As Decimal = 0
        Dim sumaME As Decimal = 0
        Dim entidadSA As New entidadSA

        Dim ent = entidadSA.UbicarEntidadPorID(cboproveedor.SelectedValue).FirstOrDefault

        With objDocumentoCompra
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .tipoDoc = "99"
            .fechaProceso = CType(envio.FechaEnvio, DateTime)
            .nroDoc = envio.Serie & "-" & envio.Numero
            .idOrden = Nothing
            .moneda = "-"
            .idEntidad = ent.idEntidad
            .entidad = ent.nombreCompleto
            .nrodocEntidad = ent.nrodoc
            .tipoOperacion = StatusTipoOperacion.COMPRA
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With guiaRemisionBE
            .codigoLibro = "8"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = CType(envio.FechaEnvio, DateTime)
            .periodo = PeriodoGeneral
            .tipoDoc = "99"
            .serie = envio.Serie
            .numeroDoc = envio.Numero
            .idEntidad = Nothing ' docCompra.idProveedor
            .monedaDoc = Nothing ' docCompra.monedaDoc
            .tasaIgv = Nothing ' docCompra.tasaIgv
            .tipoCambio = Nothing ' docCompra.tcDolLoc
            .importeMN = 0
            .importeME = 0
            .glosa = "Guía de remisión por compras realizadas, distribución masiva"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE
        sumaMN = 0
        sumaME = 0

        For Each i As Record In dgvEnvioAlmacen.Table.Records
            sumaMN += CDec(i.GetValue("montoMN"))
            sumaME += CDec(i.GetValue("montoME"))

            documentoguiaDetalle = New documentoguiaDetalle
            documentoguiaDetalle.idDocumento = 0
            documentoguiaDetalle.secuenciaRef = Val(i.GetValue("secuencia")) 'secuencia
            documentoguiaDetalle.idItem = Val(i.GetValue("iditem"))
            documentoguiaDetalle.descripcionItem = i.GetValue("item")
            documentoguiaDetalle.destino = i.GetValue("gravado")
            documentoguiaDetalle.unidadMedida = i.GetValue("unidad")
            If Not CDec(i.GetValue("cantidad")) > 0 Then
                Throw New Exception("La cantidad Debe ser mayor a cero." & vbCrLf & "Item: " & i.GetValue("item"))
            End If
            documentoguiaDetalle.cantidad = CDec(i.GetValue("cantidad"))
            documentoguiaDetalle.precioUnitario = 0
            documentoguiaDetalle.precioUnitarioUS = 0

            If Not CDec(i.GetValue("montoMN")) > 0 Then
                Throw New Exception("El costo (MN.) Debe ser mayor a cero." & vbCrLf & "Item: " & i.GetValue("item"))
            End If

            If Not CDec(i.GetValue("montoME")) > 0 Then
                Throw New Exception("El costo (ME.) Debe ser mayor a cero." & vbCrLf & "Item: " & i.GetValue("item"))
            End If

            documentoguiaDetalle.importeMN = CDec(i.GetValue("montoMN"))
            documentoguiaDetalle.importeME = CDec(i.GetValue("montoME"))
            documentoguiaDetalle.idDocumentoPadre = Val(i.GetValue("idDocumento"))

            Dim codAlmacen = i.GetValue("almacenEnvio")
            If Not codAlmacen.ToString.Trim.Length > 0 Then
                Throw New Exception("Debe seleccionar un almacén." & vbCrLf & "Item: " & i.GetValue("item"))
            End If
            documentoguiaDetalle.almacenRef = Val(i.GetValue("almacenEnvio"))

            documentoguiaDetalle.secuencia = Val(i.GetValue("secuencia"))

            documentoguiaDetalle.usuarioModificacion = usuario.IDUsuario
            documentoguiaDetalle.fechaModificacion = DateTime.Now
            ListaGuiaDetalle.Add(documentoguiaDetalle)
        Next

        objDocumentoCompra.documentoGuia.importeMN = sumaMN
        objDocumentoCompra.documentoGuia.importeME = sumaME
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Private Sub GetMovPorPeriodo(intIdEstablecimiento As Integer, strPeriodo As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim dt As New DataTable("Movimientos - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("destino", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))

        Dim str As String
        For Each i As documentocompra In DocumentoCompraSA.GetListarPorPeriodoEntradas(Gempresas.IdEmpresaRuc, intIdEstablecimiento, strPeriodo, TIPO_COMPRA.OTRAS_ENTRADAS, StatusTipoConsulta.XUNIDAD_ORGANICA)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            Select Case i.destino
                Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES
                    dr(1) = "TRANSFERENCIA ENTRE ALMACENES"
                Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
                    dr(1) = "ENTRADA DE EXISTENCIAS"
                Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.SALIDA_EXISTENCIAS
                    dr(1) = "SALIDA DE EXISTENCIAS"
            End Select

            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            dr(12) = i.importeUS
            dr(13) = i.monedaDoc
            dt.Rows.Add(dr)
        Next
        dgvMov.DataSource = dt

    End Sub

    Private Sub GrabarEnvioMasivo(envio As EnvioExistencia)
        Dim invSA As New inventarioMovimientoSA
        Dim documento As New documento
        Dim obj As New InventarioMovimiento()
        Dim listaExistencias As New List(Of InventarioMovimiento)
        Dim almacenSA As New almacenSA
        Dim almacenTransito As New almacen

        Try
            dgvTransito.TableControl.CurrentCell.EndEdit()
            dgvTransito.TableControl.Table.TableDirty = True
            dgvTransito.TableControl.Table.EndEdit()

            listaExistencias = New List(Of InventarioMovimiento)

            GuiaRemision(documento, envio)
            ' CType(envio.FechaEnvio, DateTime)
            almacenTransito = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento)
            For Each i As SelectedRecord In dgvTransito.Table.SelectedRecords
                obj = New InventarioMovimiento With
                      {
                           .idorigenDetalle = Val(i.Record.GetValue("secCompra")),
                           .idEmpresa = Gempresas.IdEmpresaRuc,
                           .idEstablecimiento = GEstableciento.IdEstablecimiento,
                           .idAlmacen = envio.Almacen,
                           .TipoAlmacen = TipoAlmacen.Deposito,
                           .tipoOperacion = "02",
                           .tipoDocAlmacen = envio.TipoDoc,
                           .serie = envio.Serie,
                           .numero = envio.Numero,
                           .idDocumento = Val(i.Record.GetValue("idDocumento")),
                           .idDocumentoRef = Val(i.Record.GetValue("idDocumento")),
                           .idItem = Val(i.Record.GetValue("idItem")),
                           .descripcion = i.Record.GetValue("descripcion"),
                           .fecha = CType(envio.FechaEnvio, DateTime),
                           .tipoRegistro = Status.Entrada_almacen,
                           .destinoGravadoItem = i.Record.GetValue("origen"),
                           .tipoProducto = i.Record.GetValue("tipoExistencia"),
                           .cantidad = CType(i.Record.GetValue("saldoCan"), Decimal),
                           .unidad = i.Record.GetValue("unidad"),
                           .cantidad2 = 0,
                           .unidad2 = 0,
                           .precUnite = 0,
                           .precUniteUSD = 0,
                           .monto = CDec(i.Record.GetValue("saldoMontoMN")),
                           .montoUSD = CDec(i.Record.GetValue("saldoMontoME")),
                           .status = Status.Distribuido,
                           .entragado = Status.Entrada_almacen,
                           .usuarioActualizacion = usuario.IDUsuario,
                .fechaActualizacion = DateTime.Now
                    }
                listaExistencias.Add(obj)


                'Registro de la Salida

                obj = New InventarioMovimiento With
                     {
                          .idorigenDetalle = Val(i.Record.GetValue("secCompra")),
                          .idEmpresa = Gempresas.IdEmpresaRuc,
                          .idEstablecimiento = almacenTransito.idEstablecimiento,
                          .idAlmacen = almacenTransito.idAlmacen,
                          .TipoAlmacen = TipoAlmacen.transito,
                          .tipoOperacion = "02",
                          .tipoDocAlmacen = envio.TipoDoc,
                          .serie = envio.Serie,
                          .numero = envio.Numero,
                          .idDocumento = Val(i.Record.GetValue("idDocumento")),
                          .idDocumentoRef = Val(i.Record.GetValue("idDocumento")),
                          .idItem = Val(i.Record.GetValue("idItem")),
                          .descripcion = i.Record.GetValue("descripcion"),
                          .fecha = CType(envio.FechaEnvio, DateTime),
                          .tipoRegistro = Status.Salida_almacen,
                          .destinoGravadoItem = i.Record.GetValue("origen"),
                          .tipoProducto = i.Record.GetValue("tipoExistencia"),
                          .cantidad = CDec(i.Record.GetValue("saldoCan")) * -1,
                          .unidad = i.Record.GetValue("unidad"),
                          .cantidad2 = 0,
                          .unidad2 = 0,
                          .precUnite = 0,
                          .precUniteUSD = 0,
                          .monto = CDec(i.Record.GetValue("saldoMontoMN")) * -1,
                          .montoUSD = CDec(i.Record.GetValue("saldoMontoME")) * -1,
                          .status = Status.Distribuido,
                          .entragado = Status.Entrada_almacen,
                          .usuarioActualizacion = usuario.IDUsuario,
                          .fechaActualizacion = DateTime.Now
                   }
                listaExistencias.Add(obj)
            Next
            documento.InventarioMovimiento = listaExistencias

            If rbParcial.Checked = True Then
                documento.TipoEnvio = "PARCIAL"
            ElseIf rbCompleta.Checked = True Then
                documento.TipoEnvio = "MASIVO"
            End If

            invSA.GrabarEnvioTransito(documento)
            MessageBox.Show("Existencia enviada!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Verificar artículos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'Dispose()
    End Sub

    Private Sub GrabarEnvioParcial(envio As EnvioExistencia)
        Dim invSA As New inventarioMovimientoSA
        Dim documento As New documento
        Dim obj As New InventarioMovimiento()
        Dim listaExistencias As New List(Of InventarioMovimiento)
        Dim almacenSA As New almacenSA
        Dim almacenTransito As New almacen
        Try
            dgvEnvioAlmacen.TableControl.CurrentCell.EndEdit()
            dgvEnvioAlmacen.TableControl.Table.TableDirty = True
            dgvEnvioAlmacen.TableControl.Table.EndEdit()


            listaExistencias = New List(Of InventarioMovimiento)

            GuiaRemisionParcial(documento, envio)

            almacenTransito = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento)
            For Each i As Record In dgvEnvioAlmacen.Table.Records

                Dim codAlmacen = i.GetValue("almacenEnvio")
                If Not codAlmacen.ToString.Trim.Length > 0 Then
                    MessageBox.Show("Debe seleccionar un almacén." & vbCrLf & "item: " & i.GetValue("item"))
                    Exit Sub
                End If

                obj = New InventarioMovimiento With
                      {
                           .idorigenDetalle = Val(i.GetValue("secuencia")),
                           .idEmpresa = Gempresas.IdEmpresaRuc,
                           .idEstablecimiento = GEstableciento.IdEstablecimiento,
                           .idAlmacen = Val(i.GetValue("almacenEnvio")),
                           .TipoAlmacen = TipoAlmacen.Deposito,
                           .tipoOperacion = "02",
                           .tipoDocAlmacen = envio.TipoDoc,
                           .serie = envio.Serie,
                           .numero = envio.Numero,
                           .idDocumento = Val(i.GetValue("idDocumento")),
                           .idDocumentoRef = Val(i.GetValue("idDocumento")),
                           .idItem = Val(i.GetValue("iditem")),
                           .descripcion = i.GetValue("item"),
                           .fecha = CType(envio.FechaEnvio, DateTime),
                           .tipoRegistro = Status.Entrada_almacen,
                           .destinoGravadoItem = i.GetValue("gravado"),
                           .tipoProducto = i.GetValue("tipoEx"),
                           .cantidad = CType(i.GetValue("cantidad"), Decimal),
                           .unidad = i.GetValue("unidad"),
                           .cantidad2 = 0,
                           .unidad2 = 0,
                           .precUnite = 0,
                           .precUniteUSD = 0,
                           .monto = CDec(i.GetValue("montoMN")),
                           .montoUSD = CDec(i.GetValue("montoME")),
                           .status = Status.Distribuido,
                           .entragado = Status.Entrada_almacen,
                           .usuarioActualizacion = usuario.IDUsuario,
                .fechaActualizacion = DateTime.Now
                    }
                listaExistencias.Add(obj)


                'Registro de la Salida

                obj = New InventarioMovimiento With
                     {
                          .idorigenDetalle = Val(i.GetValue("secuencia")),
                          .idEmpresa = Gempresas.IdEmpresaRuc,
                          .idEstablecimiento = almacenTransito.idEstablecimiento,
                          .idAlmacen = almacenTransito.idAlmacen,
                          .TipoAlmacen = TipoAlmacen.transito,
                          .tipoOperacion = "02",
                          .tipoDocAlmacen = envio.TipoDoc,
                          .serie = envio.Serie,
                          .numero = envio.Numero,
                          .idDocumento = Val(i.GetValue("idDocumento")),
                          .idDocumentoRef = Val(i.GetValue("idDocumento")),
                          .idItem = Val(i.GetValue("iditem")),
                          .descripcion = i.GetValue("item"),
                          .fecha = CType(envio.FechaEnvio, DateTime),
                          .tipoRegistro = Status.Salida_almacen,
                          .destinoGravadoItem = i.GetValue("gravado"),
                          .tipoProducto = i.GetValue("tipoEx"),
                          .cantidad = CDec(i.GetValue("cantidad")) * -1,
                          .unidad = i.GetValue("unidad"),
                          .cantidad2 = 0,
                          .unidad2 = 0,
                          .precUnite = 0,
                          .precUniteUSD = 0,
                          .monto = CDec(i.GetValue("montoMN")) * -1,
                          .montoUSD = CDec(i.GetValue("montoME")) * -1,
                          .status = Status.Distribuido,
                          .entragado = Status.Entrada_almacen,
                          .usuarioActualizacion = usuario.IDUsuario,
                          .fechaActualizacion = DateTime.Now
                   }
                listaExistencias.Add(obj)
            Next
            documento.InventarioMovimiento = listaExistencias

            If rbParcial.Checked = True Then
                documento.TipoEnvio = "PARCIAL"
            ElseIf rbCompleta.Checked = True Then
                documento.TipoEnvio = "MASIVO"
            End If

            invSA.GrabarEnvioTransito(documento)
            MessageBox.Show("Existencia enviada!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Verificar artículos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function ItemEsCorrecto(r As Record) As Boolean
        dgvEnvioAlmacen.TableControl.CurrentCell.EndEdit()
        dgvEnvioAlmacen.TableControl.Table.TableDirty = True
        dgvEnvioAlmacen.TableControl.Table.EndEdit()
        For Each i As Record In dgvEnvioAlmacen.Table.Records
            If i.GetValue("iditem") = Val(r.GetValue("idItem")) AndAlso i.GetValue("almacenEnvio") = cboAlmacenDestino.SelectedValue Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub AsiganarItem(intNumero As Integer)

        'Select Case intNumero
        '    Case 1
        '        Dim r As Record = dgvTransito.Table.CurrentRecord

        '        Me.dgvEnvioAlmacen.Table.AddNewRecord.SetCurrent()
        '        Me.dgvEnvioAlmacen.Table.AddNewRecord.BeginEdit()
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("idDocumento", r.GetValue("idDocumento"))
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("secuencia", r.GetValue("secCompra"))
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("fecha", r.GetValue("fechaCompra"))
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("tipodoc", r.GetValue("comprobanteCompra"))
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("serie", 1)
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("numero", 1)
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("iditem", r.GetValue("idItem"))
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("gravado", r.GetValue("origen"))

        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("item", r.GetValue("descripcion"))
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("unidad", r.GetValue("unidad"))
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("tipoEx", r.GetValue("tipoExistencia"))
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("cantidad", r.GetValue("cantidad"))
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("montoMN", r.GetValue("importeMN"))
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("montoME", r.GetValue("importeME"))

        '        Me.dgvEnvioAlmacen.Table.AddNewRecord.EndEdit()
        '    Case Else

        If ItemEsCorrecto(dgvTransito.Table.CurrentRecord) = True Then
            For x = 0 To intNumero - 1
                Dim r As Record = dgvTransito.Table.CurrentRecord
                Dim cantidad As Decimal = Math.Round(CDec(r.GetValue("cantidad")) / intNumero, 2)
                Dim montoMN As Decimal = Math.Round(CDec(r.GetValue("importeMN")) / intNumero, 2)
                Dim montoME As Decimal = Math.Round(CDec(r.GetValue("importeME")) / intNumero, 2)
                Dim precunitMN As Decimal = CDec(r.GetValue("saldoMontoMN")) / CDec(r.GetValue("saldoCan"))
                Dim precunitME As Decimal = CDec(r.GetValue("saldoMontoME")) / CDec(r.GetValue("saldoCan"))

                Me.dgvEnvioAlmacen.Table.AddNewRecord.SetCurrent()
                Me.dgvEnvioAlmacen.Table.AddNewRecord.BeginEdit()
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("idDocumento", r.GetValue("idDocumento"))
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("secuencia", r.GetValue("secCompra"))
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("fecha", r.GetValue("fechaCompra"))
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("tipodoc", r.GetValue("comprobanteCompra"))
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("serie", 1)
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("numero", 1)
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("iditem", r.GetValue("idItem"))
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("gravado", r.GetValue("origen"))

                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("item", r.GetValue("descripcion"))
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("unidad", r.GetValue("unidad"))
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("tipoEx", r.GetValue("tipoExistencia"))
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("cantidad", 0) ' cantidad)
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("montoMN", 0) 'montoMN)
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("montoME", 0) ' montoME)
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("puMN", precunitMN) ' montoME)
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("puME", precunitME) ' montoME)almacenEnvio
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("almacenEnvio", cboAlmacenDestino.SelectedValue)
                Me.dgvEnvioAlmacen.Table.AddNewRecord.EndEdit()
            Next
        Else
            MessageBox.Show("El item ingresado ya esta en la canasta, ingreser otro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


        'End Select

    End Sub

    Private Sub GridColumnConfig()
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("iditem")
        dt.Columns.Add("gravado")
        dt.Columns.Add("item")
        dt.Columns.Add("unidad")
        dt.Columns.Add("tipoEx")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")
        dt.Columns.Add("almacenEnvio")
        dt.Columns.Add("puMN")
        dt.Columns.Add("puME")

        dgvEnvioAlmacen.DataSource = dt

        Dim dt2 As New DataTable
        dt2.Columns.Add("id")
        dt2.Columns.Add("descripcion")
        dt2.Columns.Add("cantDisponible")
        dt2.Columns.Add("cantidad")
        dt2.Columns.Add("um")
        dt2.Columns.Add("almacen")
        dt2.Columns.Add("costoSec")
        dt2.Columns.Add("proceso")

        GridGroupingControl2.DataSource = dt2

    End Sub

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
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub


    Private Sub GetCountExistenciaTransito()
        Dim compraSA As New DocumentoCompraSA


        lblCenter.Text = compraSA.GetCountExistenciaTransito(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                       .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                       .tipoCompra = TIPO_COMPRA.COMPRA})

    End Sub

    Dim saldoCantidadAnual As Decimal = 0
    Dim saldoImporteAnual As Decimal = 0
    Dim ImporteSaldo As Decimal = 0
    Dim canSaldo As Decimal = 0

    Public Sub ObtenerSaldoInicioXmes(intAnio As Integer, intMEs As Integer, intCodigoProducto As Integer, dt As DataTable)
        Dim cierreSA As New CierreInventarioSA
        Dim cierre As New cierreinventario

        cierre = cierreSA.RecuperarCierre(intAnio, intMEs, intCodigoProducto)

        If Not IsNothing(cierre) Then
            saldoCantidadAnual = cierre.cantidad
            saldoImporteAnual = cierre.importe
        Else
            saldoCantidadAnual = 0
            saldoImporteAnual = 0
        End If

        Dim dr As DataRow = dt.NewRow
        dr(0) = ""
        dr(1) = ""
        dr(2) = ""

        Select Case intMEs
            Case 1
                dr(3) = "Saldo: Mes-" & 12
            Case Else
                dr(3) = "Saldo: Mes-" & intMEs - 1
        End Select
        dr(4) = ""
        dr(5) = ""
        dr(6) = ""

        dr(7) = (0)
        dr(8) = (0)
        dr(9) = (0)

        dr(10) = (0)
        dr(11) = (0)
        dr(12) = (0)

        dr(13) = (saldoCantidadAnual)
        dr(14) = (saldoImporteAnual)

        If saldoCantidadAnual > 0 Then
            dr(15) = Math.Round(saldoImporteAnual / saldoCantidadAnual, 6)
            pmAcumnulado = Math.Round(saldoImporteAnual / saldoCantidadAnual, 6)
        Else
            dr(15) = 0
            pmAcumnulado = 0
        End If
        '      ImporteSaldo = saldoImporteAnual
        dt.Rows.Add(dr)

    End Sub

    Dim precUnit As Decimal = 0
    Dim pmAcumnulado As Decimal = 0

    Private Sub GetKardexByAnio()
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim listaInventario As New List(Of InventarioMovimiento)
        'Dim canSaldo As Decimal = 0
        'Dim ImporteSaldo As Decimal = 0
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing

        '-----------------------------------------------------------------------------------------------------

        Dim dt As New DataTable("kárdex - Año " & txtPeriodo.Value.Year)
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("Movimiento", GetType(String))) '0
        dt.Columns.Add(New DataColumn("fecha", GetType(String))) '1
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String))) '2
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal))) '.PM
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("codigo", GetType(Integer)))

        Dim str As String

        ImporteSaldo = 0
        canSaldo = 0
        '''''''''''''''m

        Select Case cboFechaFiltroKardex.Text
            Case "FECHA LABORAL"
                If CheckBox3.Checked = True Then
                    listaInventario = inventario.GetKardexByAnioDiaLaboralLote(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fechaLaboral = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1), .nrolote = txtFiltroLote.Text})
                Else
                    listaInventario = inventario.GetKardexByAnioDiaLaboral(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fechaLaboral = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)})
                End If

            Case "FECHA DOCUMENTO" '
                If CheckBox3.Checked = True Then
                    listaInventario = inventario.GetKardexByfechaDocumentoLote(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fecha = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1), .nrolote = txtFiltroLote.Text})
                Else
                    listaInventario = inventario.GetKardexByAnio(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fecha = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)})
                End If

        End Select

        For Each i As InventarioMovimiento In listaInventario
            cantidadDeficit = 0
            importeDeficit = 0

            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            dr(0) = i.tipoOperacion ' tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
            dr(1) = str
            dr(2) = i.destinoGravadoItem
            dr(3) = i.nombreItem
            If i.marca Is Nothing Then
                '      dr(4) = i.marca
            Else
                '     dr(4) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
            End If
            dr(5) = i.tipoProducto
            dr(6) = i.unidad
            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    If producto = i.idItem Then
                        productoCache = i.nombreItem
                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec(i.monto)
                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0

                        'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldo = canSaldo + saldoCantidadAnual
                        ImporteSaldo = ImporteSaldo + saldoImporteAnual
                        canSaldo = CDec(i.cantidad) + canSaldo
                        ImporteSaldo = CDec(i.monto) + ImporteSaldo

                    End If
                    dr(7) = (FormatNumber(i.cantidad, 4))
                    If CDec(i.cantidad) > 0 Then
                        dr(8) = (Math.Round(CDec(i.monto) / CDec(i.cantidad), 4))
                    Else
                        dr(8) = 0
                    End If
                    dr(9) = (FormatNumber(i.monto, 4))
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = ("0.00")
                    dr(13) = (FormatNumber(canSaldo, 4))
                    dr(14) = (FormatNumber(ImporteSaldo, 4))
                    If canSaldo > 0 Then
                        precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
                    Else
                        precUnit = 0
                    End If
                    dr(15) = precUnit
                    pmAcumnulado = precUnit
                Case "S", "D"
                    Dim co As Decimal = 0
                    co = Math.Round(CDec(i.cantidad) * pmAcumnulado, 6)

                    If producto = i.idItem Then
                        productoCache = i.nombreItem
                        'canSaldo += CDec(i.cantidad)

                        Select Case i.tipoOperacion
                            Case "9913"
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo = ImporteSaldo

                            Case "9914"
                                canSaldo = canSaldo
                                ImporteSaldo += i.monto

                            Case "9916"
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += i.monto

                                'Case "9926"
                                '    canSaldo += CDec(i.cantidad)
                                '    ImporteSaldo += i.monto

                            Case Else
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += co
                        End Select

                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0
                        'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldo = canSaldo + saldoCantidadAnual
                        ImporteSaldo = ImporteSaldo + saldoImporteAnual

                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
                    End If
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = ("0.00")

                    Select Case i.tipoOperacion
                        Case "9913"
                            dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            dr(11) = (0)
                            dr(12) = 0.0

                        Case "9914"
                            dr(10) = 0.0
                            dr(11) = (0)
                            dr(12) = i.monto * -1

                        Case "9916"
                            dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            dr(11) = (0)
                            dr(12) = i.monto * -1

                            'Case "9926"
                            '    dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            '    dr(11) = (0)
                            '    dr(12) = i.monto * -1

                        Case Else
                            dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            dr(11) = (0)
                            dr(12) = (Math.Round(CDec(i.cantidad) * pmAcumnulado, 4)) * -1 '(Math.Round(CDec(i.cantidad) * pmAcumnulado, 4))
                    End Select
                    dr(13) = (FormatNumber(canSaldo, 4))
                    dr(14) = (FormatNumber(ImporteSaldo, 4))
                    If canSaldo > 0 Then
                        precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
                    Else
                        precUnit = 0
                    End If
                    dr(15) = precUnit
                    pmAcumnulado = precUnit
            End Select
            dr(16) = i.idDocumento
            dr(17) = i.idInventario

            producto = i.idItem
            productoCache = i.nombreItem

            dt.Rows.Add(dr)
        Next
        dgvKardex2.DataSource = dt
        dgvKardex2.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvKardex2.TopLevelGroupOptions.ShowCaption = True
    End Sub

    Private Sub GetKardexByAnioCV()
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim listaInventario As New List(Of InventarioMovimiento)
        'Dim canSaldo As Decimal = 0
        'Dim ImporteSaldo As Decimal = 0
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing
        Dim sumaCostoVenta As Decimal = 0

        '-----------------------------------------------------------------------------------------------------

        ''Dim dt As New DataTable("kárdex - Año " & txtPeriodo.Value.Year)
        ''dt.Columns.Add(New DataColumn("Movimiento", GetType(String))) '0
        ''dt.Columns.Add(New DataColumn("fecha", GetType(String))) '1
        ''dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String))) '2
        ''dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        ''dt.Columns.Add(New DataColumn("marca", GetType(String)))
        ' ''lower case p
        ''dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        ''dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        ''dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        ''dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        ''dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        ''dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        ''dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        ''dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        ''dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        ''dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
        ''dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal))) '.PM
        ''dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        ''dt.Columns.Add(New DataColumn("codigo", GetType(Integer)))

        ''Dim str As String

        ImporteSaldo = 0
        canSaldo = 0
        '''''''''''''''m

        Select Case cboFechaFiltroKardex.Text
            Case "FECHA LABORAL"
                listaInventario = inventario.GetKardexByAnioDiaLaboral(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fechaLaboral = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)})
            Case "FECHA DOCUMENTO"
                listaInventario = inventario.GetKardexByAnio(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fecha = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)})

        End Select

        For Each i As InventarioMovimiento In listaInventario
            cantidadDeficit = 0
            importeDeficit = 0
            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    If producto = i.idItem Then
                        productoCache = i.nombreItem
                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec(i.monto)
                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0

                        'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldo = canSaldo + saldoCantidadAnual
                        ImporteSaldo = ImporteSaldo + saldoImporteAnual
                        canSaldo = CDec(i.cantidad) + canSaldo
                        ImporteSaldo = CDec(i.monto) + ImporteSaldo

                    End If

                    If canSaldo > 0 Then
                        precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
                    Else
                        precUnit = 0
                    End If

                    pmAcumnulado = precUnit
                Case "S", "D"
                    Dim co As Decimal = 0
                    co = Math.Round(CDec(i.cantidad) * pmAcumnulado, 6)

                    If producto = i.idItem Then
                        productoCache = i.nombreItem
                        'canSaldo += CDec(i.cantidad)

                        Select Case i.tipoOperacion
                            Case "9913"
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo = ImporteSaldo

                            Case "9914"
                                canSaldo = canSaldo
                                ImporteSaldo += i.monto

                            Case "9916"
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += i.monto

                            Case Else
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += co
                        End Select

                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0
                        'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldo = canSaldo + saldoCantidadAnual
                        ImporteSaldo = ImporteSaldo + saldoImporteAnual

                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
                    End If

                    Select Case i.tipoOperacion
                        Case "9913"
                            'dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            'dr(11) = (0)
                            'dr(12) = 0.0

                        Case "9914"
                            'dr(10) = 0.0
                            'dr(11) = (0)
                            'dr(12) = i.monto * -1

                        Case "9916"
                            'dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            'dr(11) = (0)
                            'dr(12) = i.monto * -1

                        Case Else
                            If i.tipoOperacion = "01" Then
                                Dim valCap = (Math.Round(CDec(i.cantidad) * pmAcumnulado, 4)) * -1
                                sumaCostoVenta += valCap
                            End If
                            'dr(12) =  '(Math.Round(CDec(i.cantidad) * pmAcumnulado, 4))
                    End Select
                    'dr(13) = (FormatNumber(canSaldo, 4))
                    'dr(14) = (FormatNumber(ImporteSaldo, 4))
                    If canSaldo > 0 Then
                        precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
                    Else
                        precUnit = 0
                    End If
                    'dr(15) = precUnit
                    pmAcumnulado = precUnit
            End Select

            producto = i.idItem
            productoCache = i.nombreItem

        Next
        MessageBox.Show("Costo de Ventas." & vbCrLf &
                           "Año -" & AnioGeneral & vbCrLf & sumaCostoVenta.ToString("N2"), "Resúmen Anual", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub




    Private Sub GetKardexByPerido()
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        'Dim canSaldo As Decimal = 0
        'Dim ImporteSaldo As Decimal = 0
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing

        '-----------------------------------------------------------------------------------------------------

        Dim dt As New DataTable("kárdex - período " & txtPeriodo.Value.Month & "/" & txtPeriodo.Value.Year)
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("Movimiento", GetType(String))) '0
        dt.Columns.Add(New DataColumn("fecha", GetType(String))) '1
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String))) '2
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal))) '.PM
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("codigo", GetType(Integer)))

        Dim str As String

        ImporteSaldo = 0
        canSaldo = 0
        '''''''''''''''m
        For Each i As InventarioMovimiento In inventario.GetKardexByPerido(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fecha = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)})
            cantidadDeficit = 0
            importeDeficit = 0

            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            dr(0) = tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
            dr(1) = str
            dr(2) = i.destinoGravadoItem
            dr(3) = i.nombreItem
            If i.marca Is Nothing Then
                '      dr(4) = i.marca
            Else
                '     dr(4) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
            End If
            dr(5) = i.tipoProducto
            dr(6) = i.unidad
            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    If producto = i.idItem Then
                        productoCache = i.nombreItem
                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec(i.monto)
                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0

                        ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldo = canSaldo + saldoCantidadAnual
                        ImporteSaldo = ImporteSaldo + saldoImporteAnual
                        canSaldo = CDec(i.cantidad) + canSaldo
                        ImporteSaldo = CDec(i.monto) + ImporteSaldo

                    End If
                    dr(7) = (FormatNumber(i.cantidad, 4))
                    If CDec(i.cantidad) > 0 Then
                        dr(8) = (Math.Round(CDec(i.monto) / CDec(i.cantidad), 4))
                    Else
                        dr(8) = 0
                    End If
                    dr(9) = (FormatNumber(i.monto, 4))
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = ("0.00")
                    dr(13) = (FormatNumber(canSaldo, 4))
                    dr(14) = (FormatNumber(ImporteSaldo, 4))
                    If canSaldo > 0 Then
                        precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
                    Else
                        precUnit = 0
                    End If
                    dr(15) = precUnit
                    pmAcumnulado = precUnit
                Case "S", "D"
                    Dim co As Decimal = 0
                    co = Math.Round(CDec(i.cantidad) * pmAcumnulado, 6)

                    If producto = i.idItem Then
                        productoCache = i.nombreItem
                        'canSaldo += CDec(i.cantidad)

                        Select Case i.tipoOperacion
                            Case "9913"
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo = ImporteSaldo

                            Case "9914"
                                canSaldo = canSaldo
                                ImporteSaldo += i.monto

                            Case "9916"
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += i.monto

                            Case Else
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += co
                        End Select

                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0
                        ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldo = canSaldo + saldoCantidadAnual
                        ImporteSaldo = ImporteSaldo + saldoImporteAnual

                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
                    End If
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = ("0.00")

                    Select Case i.tipoOperacion
                        Case "9913"
                            dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            dr(11) = (0)
                            dr(12) = 0.0

                        Case "9914"
                            dr(10) = 0.0
                            dr(11) = (0)
                            dr(12) = i.monto * -1

                        Case "9916"
                            dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            dr(11) = (0)
                            dr(12) = i.monto * -1

                        Case Else
                            dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            dr(11) = (0)
                            dr(12) = (Math.Round(CDec(i.cantidad) * pmAcumnulado, 4)) * -1 '(Math.Round(CDec(i.cantidad) * pmAcumnulado, 4))
                    End Select
                    dr(13) = (FormatNumber(canSaldo, 4))
                    dr(14) = (FormatNumber(ImporteSaldo, 4))
                    If canSaldo > 0 Then
                        precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
                    Else
                        precUnit = 0
                    End If
                    dr(15) = precUnit
                    pmAcumnulado = precUnit
            End Select
            dr(16) = i.idDocumento
            dr(17) = i.idInventario

            producto = i.idItem
            productoCache = i.nombreItem

            dt.Rows.Add(dr)
        Next
        dgvKardex2.DataSource = dt
        dgvKardex2.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvKardex2.TopLevelGroupOptions.ShowCaption = True
    End Sub

    Private Sub GetKardexPeridoByExistencia(envio As BusquedaExstencia)
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        'Dim canSaldo As Decimal = 0
        'Dim ImporteSaldo As Decimal = 0
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing

        '-----------------------------------------------------------------------------------------------------

        Dim dt As New DataTable("kárdex / " & envio.NombreExistencia & ", " & txtPeriodo.Value.Month & "/" & txtPeriodo.Value.Year)
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("Movimiento", GetType(String))) '0
        dt.Columns.Add(New DataColumn("fecha", GetType(String))) '1
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String))) '2
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal))) '.PM
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("codigo", GetType(Integer)))

        Dim str As String

        ImporteSaldo = 0
        canSaldo = 0
        '''''''''''''''m
        For Each i As InventarioMovimiento In inventario.GetKardexPeridoByExistencia(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fecha = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1),
                                                                                                                    .tipoExistencia = envio.TipoExistencia, .idItem = envio.IdExistencia})
            cantidadDeficit = 0
            importeDeficit = 0

            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            dr(0) = tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
            dr(1) = str
            dr(2) = i.destinoGravadoItem
            dr(3) = i.nombreItem
            If i.marca Is Nothing Then
                '      dr(4) = i.marca
            Else
                '     dr(4) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
            End If
            dr(5) = i.tipoProducto
            dr(6) = i.unidad
            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    If producto = i.idItem Then
                        productoCache = i.nombreItem
                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec(i.monto)
                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0

                        ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldo = canSaldo + saldoCantidadAnual
                        ImporteSaldo = ImporteSaldo + saldoImporteAnual
                        canSaldo = CDec(i.cantidad) + canSaldo
                        ImporteSaldo = CDec(i.monto) + ImporteSaldo

                    End If
                    dr(7) = (FormatNumber(i.cantidad, 4))
                    If CDec(i.cantidad) > 0 Then
                        dr(8) = (Math.Round(CDec(i.monto) / CDec(i.cantidad), 4))
                    Else
                        dr(8) = 0
                    End If
                    dr(9) = (FormatNumber(i.monto, 4))
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = ("0.00")
                    dr(13) = (FormatNumber(canSaldo, 4))
                    dr(14) = (FormatNumber(ImporteSaldo, 4))
                    If canSaldo > 0 Then
                        precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
                    Else
                        precUnit = 0
                    End If
                    dr(15) = precUnit
                    pmAcumnulado = precUnit
                Case "S", "D"
                    Dim co As Decimal = 0
                    co = Math.Round(CDec(i.cantidad) * pmAcumnulado, 6)

                    If producto = i.idItem Then
                        productoCache = i.nombreItem
                        'canSaldo += CDec(i.cantidad)

                        Select Case i.tipoOperacion
                            Case "9913"
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo = ImporteSaldo

                            Case "9914"
                                canSaldo = canSaldo
                                ImporteSaldo += i.monto

                            Case "9916"
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += i.monto

                            Case Else
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += co
                        End Select

                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0
                        ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldo = canSaldo + saldoCantidadAnual
                        ImporteSaldo = ImporteSaldo + saldoImporteAnual

                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
                    End If
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = ("0.00")

                    Select Case i.tipoOperacion
                        Case "9913"
                            dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            dr(11) = (0)
                            dr(12) = 0.0

                        Case "9914"
                            dr(10) = 0.0
                            dr(11) = (0)
                            dr(12) = i.monto * -1

                        Case "9916"
                            dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            dr(11) = (0)
                            dr(12) = i.monto * -1

                        Case Else
                            dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            dr(11) = (0)
                            dr(12) = (Math.Round(CDec(i.cantidad) * pmAcumnulado, 4)) * -1 '(Math.Round(CDec(i.cantidad) * pmAcumnulado, 4))
                    End Select
                    dr(13) = (FormatNumber(canSaldo, 4))
                    dr(14) = (FormatNumber(ImporteSaldo, 4))
                    If canSaldo > 0 Then
                        precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
                    Else
                        precUnit = 0
                    End If
                    dr(15) = precUnit
                    pmAcumnulado = precUnit
            End Select
            dr(16) = i.idDocumento
            dr(17) = i.idInventario

            producto = i.idItem
            productoCache = i.nombreItem

            dt.Rows.Add(dr)
        Next
        dgvKardex2.DataSource = dt
        dgvKardex2.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvKardex2.TopLevelGroupOptions.ShowCaption = True
    End Sub


    Public Sub GetComprobantesEnCola()
        Dim inventarioSA As New inventarioMovimientoSA
        Dim compra As New documentocompra
        compra = New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                           .tipoCompra = TIPO_COMPRA.COMPRA, .idProveedor = cboproveedor.SelectedValue, .TipoExistencia = cboTipoExistenciaTransito.SelectedValue}

        cboComprobantesCola.DisplayMember = "numeroDoc"
        cboComprobantesCola.ValueMember = "idDocumento"
        cboComprobantesCola.DataSource = inventarioSA.GetComprobantesEnTransito(compra)
    End Sub

    Public Sub GetInventarioTransito(strMes As String, strAnio As String, strTipoEx As String)
        Dim inventarioBL As New DocumentoCompraSA
        Dim compra As New documentocompra
        Dim dt As New DataTable()
        Dim str As String

        dt.Columns.Add("origen") ' 0
        dt.Columns.Add("tipoExistencia") ' 1
        dt.Columns.Add("idAlmacen") ' 2
        dt.Columns.Add("almacen") ' 3
        dt.Columns.Add("idDocumento") ' 4

        dt.Columns.Add("idProveedor") ' 5
        dt.Columns.Add("Razon") ' 6

        dt.Columns.Add("idItem") ' 7
        dt.Columns.Add("descripcion") ' 8
        dt.Columns.Add("cantidad") ' 9
        dt.Columns.Add("unidad") ' 10
        dt.Columns.Add("precUnit") '11
        dt.Columns.Add("importeMN") ' 12
        dt.Columns.Add("importeME") ' 13
        dt.Columns.Add("idInventario") ' 14
        dt.Columns.Add("cuenta") ' 15
        dt.Columns.Add("fechaCompra") ' 16

        dt.Columns.Add("comprobanteCompra") ' 17
        dt.Columns.Add("nroCompra") ' 18
        dt.Columns.Add("tipoCambio") ' 19
        dt.Columns.Add("precUnitME") ' 20
        dt.Columns.Add("origen2") ' 21
        dt.Columns.Add("docRef") ' 22
        dt.Columns.Add("evento") ' 23
        dt.Columns.Add("origen3") ' 24
        dt.Columns.Add("bonifica") ' 25
        dt.Columns.Add("empaque") ' 26
        dt.Columns.Add("fecVcto") ' 27
        dt.Columns.Add("proveedor") ' 28
        dt.Columns.Add("secCompra") ' 29
        dt.Columns.Add("tp") ' 29

        dt.Columns.Add("guiaCan") ' 29
        dt.Columns.Add("guiaMontoMN") ' 29
        dt.Columns.Add("guiaMontoME") ' 29
        dt.Columns.Add("saldoCan") ' 29
        dt.Columns.Add("saldoMontoMN") ' 29
        dt.Columns.Add("saldoMontoME") ' 29
        'dt.Columns.Add("fechaEnvio")
        compra = New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                           .tipoCompra = TIPO_COMPRA.COMPRA, .idProveedor = cboproveedor.SelectedValue, .TipoExistencia = cboTipoExistenciaTransito.SelectedValue}


        For Each i In inventarioBL.GetExistenciaTransito(compra)

            If i.SaldoCantidad > 0 Then
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.FechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = (i.destino)
                dr(1) = (i.tipoExistencia)
                dr(2) = (i.almacenRef)
                dr(3) = ("ALM. VIRT") 'i.NombreAlmacen)
                dr(4) = (i.idDocumento)
                dr(5) = (i.idEntidad)
                dr(6) = i.NombreProveedor
                dr(7) = i.idItem
                dr(8) = i.descripcionItem
                dr(9) = (i.monto1)
                dr(10) = (i.unidad1)
                If (CDec(i.monto1) > 0) Then
                    dr(11) = Math.Round(CDec(i.montokardex) / CDec(i.monto1), 2)
                    dr(20) = Math.Round(CDec(i.montokardexUS) / CDec(i.monto1), 2)
                End If
                dr(12) = (FormatNumber(i.montokardex, 2))
                dr(13) = (FormatNumber(i.montokardexUS, 2))
                dr(14) = String.Empty
                dr(15) = String.Empty
                dr(16) = (FormatDateTime(i.FechaDoc, DateFormat.GeneralDate))

                dr(17) = (i.TipoDoc)
                dr(18) = i.Serie & "-" & i.NumDoc
                dr(19) = (i.tipoCambio)
                dr(21) = (i.destino)
                dr(22) = (i.idDocumento)
                dr(23) = Nothing
                dr(24) = ("INTERNO")
                dr(25) = (i.Glosa)
                dr(26) = String.Empty
                dr(27) = ""
                dr(28) = (i.NombreProveedor)
                dr(29) = (i.secuencia)
                dr(30) = String.Empty

                dr(31) = i.GuiaCantidad
                dr(32) = i.GuiaMontoMN
                dr(33) = i.GuiaMontoME
                dr(34) = i.SaldoCantidad
                dr(35) = i.SaldoMontoMN
                dr(36) = i.SaldoMontoME
                'dr(37) = i.FechaDoc
                dt.Rows.Add(dr)
            End If


        Next
        dgvTransito.DataSource = dt
        dgvTransito.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
        'dgvPersonal.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Public Sub GetInventarioTransitoByIdDocumento()
        Dim inventarioBL As New inventarioMovimientoSA
        Dim compra As New documentocompra
        Dim dt As New DataTable()
        Dim str As String

        dt.Columns.Add("origen") ' 0
        dt.Columns.Add("tipoExistencia") ' 1
        dt.Columns.Add("idAlmacen") ' 2
        dt.Columns.Add("almacen") ' 3
        dt.Columns.Add("idDocumento") ' 4

        dt.Columns.Add("idProveedor") ' 5
        dt.Columns.Add("Razon") ' 6

        dt.Columns.Add("idItem") ' 7
        dt.Columns.Add("descripcion") ' 8
        dt.Columns.Add("cantidad") ' 9
        dt.Columns.Add("unidad") ' 10
        dt.Columns.Add("precUnit") '11
        dt.Columns.Add("importeMN") ' 12
        dt.Columns.Add("importeME") ' 13
        dt.Columns.Add("idInventario") ' 14
        dt.Columns.Add("cuenta") ' 15
        dt.Columns.Add("fechaCompra") ' 16

        dt.Columns.Add("comprobanteCompra") ' 17
        dt.Columns.Add("nroCompra") ' 18
        dt.Columns.Add("tipoCambio") ' 19
        dt.Columns.Add("precUnitME") ' 20
        dt.Columns.Add("origen2") ' 21
        dt.Columns.Add("docRef") ' 22
        dt.Columns.Add("evento") ' 23
        dt.Columns.Add("origen3") ' 24
        dt.Columns.Add("bonifica") ' 25
        dt.Columns.Add("empaque") ' 26
        dt.Columns.Add("fecVcto") ' 27
        dt.Columns.Add("proveedor") ' 28
        dt.Columns.Add("secCompra") ' 29
        dt.Columns.Add("tp") ' 29

        dt.Columns.Add("guiaCan") ' 29
        dt.Columns.Add("guiaMontoMN") ' 29
        dt.Columns.Add("guiaMontoME") ' 29
        dt.Columns.Add("saldoCan") ' 29
        dt.Columns.Add("saldoMontoMN") ' 29
        dt.Columns.Add("saldoMontoME") ' 29
        'dt.Columns.Add("fechaEnvio")
        compra = New documentocompra With {.idDocumento = cboComprobantesCola.SelectedValue, .idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                          .tipoCompra = TIPO_COMPRA.COMPRA, .idProveedor = cboproveedor.SelectedValue, .TipoExistencia = cboTipoExistenciaTransito.SelectedValue}
        For Each i In inventarioBL.GetExistenciaTransitoByCompra(compra)

            If i.SaldoCantidad > 0 Then
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.FechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = (i.destino)
                dr(1) = (i.tipoExistencia)
                dr(2) = (i.almacenRef)
                dr(3) = ("ALM. VIRT") 'i.NombreAlmacen)
                dr(4) = (i.idDocumento)
                dr(5) = (i.idEntidad)
                dr(6) = i.NombreProveedor
                dr(7) = i.idItem
                dr(8) = i.descripcionItem
                dr(9) = (i.monto1)
                dr(10) = (i.unidad1)
                If (CDec(i.monto1) > 0) Then
                    dr(11) = Math.Round(CDec(i.montokardex) / CDec(i.monto1), 2)
                    dr(20) = Math.Round(CDec(i.montokardexUS) / CDec(i.monto1), 2)
                End If
                dr(12) = (FormatNumber(i.montokardex, 2))
                dr(13) = (FormatNumber(i.montokardexUS, 2))
                dr(14) = String.Empty
                dr(15) = String.Empty
                dr(16) = (FormatDateTime(i.FechaDoc, DateFormat.GeneralDate))

                dr(17) = (i.TipoDoc)
                dr(18) = i.Serie & "-" & i.NumDoc
                dr(19) = (i.tipoCambio)
                dr(21) = (i.destino)
                dr(22) = (i.idDocumento)
                dr(23) = Nothing
                dr(24) = ("INTERNO")
                dr(25) = (i.Glosa)
                dr(26) = String.Empty
                dr(27) = ""
                dr(28) = (i.NombreProveedor)
                dr(29) = (i.secuencia)
                dr(30) = String.Empty

                dr(31) = i.GuiaCantidad
                dr(32) = i.GuiaMontoMN
                dr(33) = i.GuiaMontoME
                dr(34) = i.SaldoCantidad
                dr(35) = i.SaldoMontoMN
                dr(36) = i.SaldoMontoME
                'dr(37) = i.FechaDoc
                dt.Rows.Add(dr)
            End If


        Next
        dgvTransito.DataSource = dt
        dgvTransito.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
        'dgvPersonal.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Private Sub GetInventarioValorizadoCodigo(intIdAlmacen As Integer, codigobarra As String)
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)

        Dim dt As New DataTable("Lista de productos ")
        'Clasificicacion
        dt.Columns.Add(New DataColumn("Clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("origenRecaudo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))


        'lower case p
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("unidadMedida", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))

        dt.Columns.Add(New DataColumn("cantmax", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("cantmin", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idmovimiento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("presentacion", GetType(String)))

        For Each i As totalesAlmacen In totalesAlmacenSA.GetProductosByAlmacenCodigo(intIdAlmacen, codigobarra)
            Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.Clasificicacion
            dr(1) = strGravado
            dr(2) = i.descripcion
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = i.importeSoles
            dr(7) = i.idItem

            If i.cantidadMaxima Is Nothing Then
                dr(8) = CDec(0.0)
            Else
                dr(8) = i.cantidadMaxima
            End If


            If i.cantidadMinima Is Nothing Then
                dr(9) = CDec(0.0)
            Else
                dr(9) = i.cantidadMinima
            End If
            dr(10) = i.idMovimiento
            dr(11) = i.Marca
            dr(12) = i.Presentacion
            dt.Rows.Add(dr)
        Next
        dgvKardexVal.DataSource = dt

        If Not dt.Rows.Count > 0 Then
            MessageBox.Show("El Codigo Ingresado no existe", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub



    Private Sub GetInventarioValorizado(intIdAlmacen As Integer)
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)

        Dim dt As New DataTable("Lista de productos ")
        'Clasificicacion
        dt.Columns.Add(New DataColumn("Clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("origenRecaudo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))


        'lower case p
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("unidadMedida", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))

        dt.Columns.Add(New DataColumn("cantmax", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("cantmin", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idmovimiento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("presentacion", GetType(String)))

        For Each i As totalesAlmacen In totalesAlmacenSA.GetProductosByAlmacen(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                               .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                               .idAlmacen = intIdAlmacen,
                                                                               .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}, cboTipoExistencia.SelectedValue)
            Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.Clasificicacion
            dr(1) = strGravado
            dr(2) = i.descripcion
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = i.importeSoles
            dr(7) = i.idItem

            If i.cantidadMaxima Is Nothing Then
                dr(8) = CDec(0.0)
            Else
                dr(8) = i.cantidadMaxima
            End If


            If i.cantidadMinima Is Nothing Then
                dr(9) = CDec(0.0)
            Else
                dr(9) = i.cantidadMinima
            End If
            dr(10) = i.idMovimiento
            dr(11) = i.Marca
            dr(12) = i.Presentacion
            dt.Rows.Add(dr)
        Next
        dgvKardexVal.DataSource = dt
    End Sub

    Sub almacenTransito()
        Dim almacenSA As New almacenSA
        Dim lstAlmacen = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        cboAlmacenDestino.DataSource = lstAlmacen
        cboAlmacenDestino.DisplayMember = "descripcionAlmacen"
        cboAlmacenDestino.ValueMember = "idAlmacen"
    End Sub

    Sub CMBTablaDetalle()
        Dim tablaSA As New tablaDetalleSA
        Dim lista As New List(Of tabladetalle)
        lista = New List(Of tabladetalle)
        lista.Add(New tabladetalle With {.idtabla = 5, .codigoDetalle = "00", .codigoDetalle2 = "00", .descripcion = "-Todos-"})
        lista.AddRange(TablaSA.GetListaTablaDetalle(5, "1"))


        cboTipoExistenciaTransito.DisplayMember = "descripcion"
        cboTipoExistenciaTransito.ValueMember = "codigoDetalle"
        cboTipoExistenciaTransito.DataSource = lista
        'cboTipoExistenciaTransito.SelectedValue = "00"
    End Sub

    Private Sub CargarCMB()
        Dim almacenSA As New almacenSA
        Dim tablaSA As New tablaDetalleSA
        Dim lista As New List(Of tabladetalle)
        Dim listaAlmacen As New List(Of almacen)

        listaAlmacen = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = listaAlmacen

        cboalmacenKardex.DisplayMember = "descripcionAlmacen"
        cboalmacenKardex.ValueMember = "idAlmacen"
        cboalmacenKardex.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})


        CMBTablaDetalle()


        lista = New List(Of tabladetalle)
        lista = tablaSA.GetListaTablaDetalle(5, "1")
        lista.Add(New tabladetalle With {.idtabla = 5, .codigoDetalle = "00", .codigoDetalle2 = "00", .descripcion = "-Todos-"})

        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = lista
        '   cboTipoExistencia.SelectedValue = "00"

    End Sub

#End Region

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
    End Sub

#Region "Requerimientos"

    Public Sub GetRequeridosContenidos()
        Dim totalSA As New TotalesAlmacenSA

        lsvExistencias.Items.Clear()

        For Each i In totalSA.GetProductosParecidosRequeridos(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                       .descripcion = txtBuscarProducto.Text.Trim})

            Dim n As New ListViewItem(i.idMovimiento)
            n.SubItems.Add(i.descripcion)
            n.SubItems.Add(i.cantidad)
            n.SubItems.Add(i.idUnidad)
            n.SubItems.Add(i.tipoExistencia)
            n.SubItems.Add(i.origenRecaudo)
            n.SubItems.Add(i.NomAlmacen)
            lsvExistencias.Items.Add(n)
        Next

    End Sub

    Public Sub GetCostoCMB(be As recursoCosto)
        Dim recursoSA As New recursoCostoSA
        Dim costo As New List(Of recursoCosto)

        costo.Add(New recursoCosto With {.idCosto = 0, .nombreCosto = "-Todos-"})
        costo.AddRange(recursoSA.GetListaPryectosEnCarteraFull(New recursoCosto With {.tipo = be.tipo,
                                                                                      .subtipo = be.subtipo}))
        cboCosto.DataSource = costo
        cboCosto.DisplayMember = "nombreCosto"
        cboCosto.ValueMember = "idCosto"
        'cboCosto.SelectedIndex = 0
        cboCosto.Text = "-Todos-"
    End Sub

    Public Sub GetRequerimientosByProyecto(be As recursoCostoDetalle)
        Dim dt As New DataTable
        Dim recursoSA As New recursoCostoDetalleSA
        Dim recurso As New List(Of recursoCostoDetalle)

        dt.Columns.Add("secuencia")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("um")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("tipoRecurso")
        dt.Columns.Add("actividad")
        dt.Columns.Add("proyecto")
        dt.Columns.Add("Confirmar")
        dt.Columns.Add("cantEjecutada")
        dt.Columns.Add("fecha")

        recurso = recursoSA.GetRecursoPlaneadosPendientesAprobacion(be)

        For Each i In recurso
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.secuencia
            dr(1) = i.descripcion
            dr(2) = i.um
            dr(3) = i.cant
            'dr(4) = i.iditem
            Select Case i.iditem
                Case TipoRecursoPlaneado.Inventario
                    dr(4) = "INVENTARIO"
                Case TipoRecursoPlaneado.ManoDeObra
                    dr(4) = "MANO DE OBRA"
                Case TipoRecursoPlaneado.ActivoInmovilizado
                    dr(4) = "ACTIVOS INMOVILIZADOS"
                Case TipoRecursoPlaneado.Terceros
                    dr(4) = "TERCEROS"
            End Select


            dr(5) = i.idProceso
            dr(6) = i.NombreCosto
            dr(7) = i.IdProyecto
            dr(8) = i.CantEjecutada
            dr(9) = i.fechaRegistro.GetValueOrDefault
            dt.Rows.Add(dr)
        Next

        dgvRQ.DataSource = dt 'recursoSA.GetListadoRecursosByIdCosto(be)

    End Sub
#End Region

    Private Sub frmInventario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Dispose()
    End Sub

    Private Sub frmInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EmpresaToolStripMenuItem.Text = "Empresa: " & Gempresas.NomEmpresa
        EstablecimientoToolStripMenuItem.Text = "Establecimiento: " & GEstableciento.NombreEstablecimiento
        txtAnioCompra.Text = AnioGeneral
        Meses()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        LoadingAnimator.Wire(Me.dgvKardexVal.TableControl)
        If cboAlmacen.SelectedIndex > -1 Then
            Dim codAlmacen = cboAlmacen.SelectedValue
            If IsNumeric(codAlmacen) Then
                GetInventarioValorizado(codAlmacen)
            End If
        End If
        LoadingAnimator.UnWire(Me.dgvKardexVal.TableControl)
    End Sub

    Private Sub treeViewAdv2_AfterSelect(sender As Object, e As EventArgs) Handles treeViewAdv2.AfterSelect
        Select Case treeViewAdv2.SelectedNode.Tag
            Case "Dashboard"
                TabAlmacen.Parent = Nothing
                ToolStripButton15.Visible = False
                ToolStripButton16.Visible = False
                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabInventario.Parent = Nothing
                TabKardex.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabRQ.Parent = Nothing
                TabCambioTipoInventario.Parent = Nothing
                TabNumeroGuiaPendiente.Parent = Nothing
                TabConfirmarGuia.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                TabTransferencia.Parent = Nothing
                ToolStripButton7.Visible = False
                ToolStripButton20.Visible = False
            Case "transito"
                GridCFG2(dgvTransito)
                ToolStripButton15.Visible = True
                ToolStripButton16.Visible = True
                TabDashboard.Parent = Nothing
                TabAlmacen.Parent = Nothing
                TabTransito.Parent = TabControlAdv1
                TabInventario.Parent = Nothing
                TabKardex.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabCambioTipoInventario.Parent = Nothing
                TabConfirmarGuia.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                TabRQ.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                TabNumeroGuiaPendiente.Parent = Nothing
                TabTransferencia.Parent = Nothing
                ToolStripButton7.Visible = False
                ToolStripButton20.Visible = False
            Case "resumen"
                ToolStripButton15.Visible = False
                ToolStripButton16.Visible = False
                GridCFG2(dgvKardexVal)
                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabKardex.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabRQ.Parent = Nothing
                TabAlmacen.Parent = Nothing
                TabCambioTipoInventario.Parent = Nothing
                TabInventario.Parent = TabControlAdv1
                TabNumeroGuiaPendiente.Parent = Nothing
                TabConfirmarGuia.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                TabTransferencia.Parent = Nothing
                ToolStripButton7.Visible = False
                ToolStripButton20.Visible = False
            Case "kardex"
                ToolStripButton15.Visible = False
                ToolStripButton16.Visible = False
                GridCFGKardex(dgvKardex2)
                ToolStripButton7.Visible = False
                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabInventario.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabRQ.Parent = Nothing
                TabAlmacen.Parent = Nothing
                TabNumeroGuiaPendiente.Parent = Nothing
                TabCambioTipoInventario.Parent = Nothing
                TabKardex.Parent = TabControlAdv1
                TabTransferencia.Parent = Nothing
                TabConfirmarGuia.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                ToolStripButton20.Visible = False
            Case "periodo"
                ToolStripButton15.Visible = False
                ToolStripButton16.Visible = False
                GridCFGKardex(dgvMov)
                ToolStripButton7.Visible = False
                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabInventario.Parent = Nothing
                TabCambioTipoInventario.Parent = Nothing
                TabMovimientos.Parent = TabControlAdv1
                TabKardex.Parent = Nothing
                TabRQ.Parent = Nothing
                TabAlmacen.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabNumeroGuiaPendiente.Parent = Nothing
                TabConfirmarGuia.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabTransferencia.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                ToolStripButton20.Visible = False
            Case "Alerta"

                ToolStripButton15.Visible = False
                ToolStripButton16.Visible = False
                GridCFGKardex(dgvStockMinimo)
                ToolStripButton7.Visible = False
                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabInventario.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabKardex.Parent = Nothing
                TabRQ.Parent = Nothing
                TabAlmacen.Parent = Nothing
                TabCambioTipoInventario.Parent = Nothing
                TabAlertaInventario.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                TabConfirmarGuia.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                TabNumeroGuiaPendiente.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                TabTransferencia.Parent = Nothing
                ToolStripButton20.Visible = False
            Case "rotacion"
                ToolStripButton15.Visible = False
                ToolStripButton16.Visible = False
                GridCFGKardex(dgvRotacion)
                ToolStripButton7.Visible = False
                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabInventario.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabKardex.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabRQ.Parent = Nothing
                TabAlmacen.Parent = Nothing
                TabTransferencia.Parent = Nothing
                TabCambioTipoInventario.Parent = Nothing
                TabPageAdv2.Parent = TabControlAdv1
                TabNumeroGuiaPendiente.Parent = Nothing
                TabConfirmarGuia.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                ToolStripButton20.Visible = False
            Case "Requerimiento"
                GetCostoCMB(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.Proyecto})
                ToolStripButton15.Visible = False
                ToolStripButton16.Visible = False
                GridCFGKardex(dgvRQ)
                GridCFG2(GridGroupingControl2)
                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabInventario.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabKardex.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabAlmacen.Parent = Nothing
                TabCambioTipoInventario.Parent = Nothing
                TabRQ.Parent = TabControlAdv1
                TabNumeroGuiaPendiente.Parent = Nothing
                TabConfirmarGuia.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                TabTransferencia.Parent = Nothing
                ToolStripButton7.Visible = False
                ToolStripButton20.Visible = False
            Case "ordenCompra"
                'GetCostoCMB(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.Proyecto})
                ToolStripButton15.Visible = False
                ToolStripButton16.Visible = False
                GridCFGKardex(dgvOrdenCompra)
                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabInventario.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabKardex.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabRQ.Parent = Nothing
                TabAlmacen.Parent = Nothing
                TabCambioTipoInventario.Parent = Nothing
                TabOrdenCompra.Parent = TabControlAdv1
                TabTransferencia.Parent = Nothing
                TabNumeroGuiaPendiente.Parent = Nothing
                TabConfirmarGuia.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                ToolStripButton7.Visible = True
                ToolStripButton20.Visible = False
            Case "Almacenes"
                GridCFG2(dgAlmacen)
                ToolStripButton15.Visible = False
                ToolStripButton16.Visible = False
                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabInventario.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabKardex.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabRQ.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                TabCambioTipoInventario.Parent = Nothing
                TabAlmacen.Parent = TabControlAdv1
                ToolStripButton7.Visible = True
                TabTransferencia.Parent = Nothing
                TabNumeroGuiaPendiente.Parent = Nothing
                TabConfirmarGuia.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                ToolStripButton20.Visible = False
                GetAlmacenes()
            Case "TransferenciaTransito"
                Dim DocumentoCompraSA As New DocumentoCompraSA
                dgvTransferencia.Table.Records.DeleteAll()
                dgvDetalleTransferencia.Table.Records.DeleteAll()
                GridCFG2(dgvTransferencia)
                GridCFG2(dgvDetalleTransferencia)
                ToolStripButton15.Visible = False
                ToolStripButton16.Visible = False
                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabInventario.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabKardex.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabRQ.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                TabAlmacen.Parent = Nothing
                TabCambioTipoInventario.Parent = Nothing
                TabTransferencia.Parent = TabControlAdv1
                ToolStripButton7.Visible = True
                TabNumeroGuiaPendiente.Parent = Nothing
                TabConfirmarGuia.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                ToolStripButton20.Visible = False
                dgvTransferencia.Dock = DockStyle.Fill
                pnHistorial.Dock = DockStyle.None
                pnHistorial.Visible = False
                'getTableComprasPorPeriodoContado(Nothing, Nothing)
                getTableComprasPorPeriodoContadoTipo("PN")
            Case "RecepcionTransferencia"
                Dim DocumentoCompraSA As New DocumentoCompraSA

                dgvTransferencia.Table.Records.DeleteAll()
                dgvDetalleTransferencia.Table.Records.DeleteAll()
                GridCFG2(dgvTransferencia)
                GridCFG2(dgvDetalleTransferencia)
                ToolStripButton15.Visible = False
                ToolStripButton16.Visible = False
                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabInventario.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabKardex.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabRQ.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                TabAlmacen.Parent = Nothing
                TabTransferencia.Parent = TabControlAdv1
                TabCambioTipoInventario.Parent = Nothing
                ToolStripButton7.Visible = True
                TabNumeroGuiaPendiente.Parent = Nothing
                TabConfirmarGuia.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                dgvTransferencia.Dock = DockStyle.Top
                pnHistorial.Dock = DockStyle.Fill
                pnHistorial.Visible = True
                ToolStripButton17.Visible = True
                ToolStripButton20.Visible = False
                'getTableComprasPorPeriodoContado(Nothing, Nothing)
                getTableComprasPorPeriodoContadoTipo("PN")
            Case "HistorialTransAlmacen"
                Dim DocumentoCompraSA As New DocumentoCompraSA
                GridCFG2(dgvTransferencia)
                GridCFG2(dgvDetalleTransferencia)
                ToolStripButton15.Visible = False
                ToolStripButton16.Visible = False
                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabInventario.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabKardex.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabRQ.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                TabAlmacen.Parent = Nothing
                TabTransferencia.Parent = TabControlAdv1
                TabNumeroGuiaPendiente.Parent = Nothing
                ToolStripButton7.Visible = True
                dgvTransferencia.Dock = DockStyle.Top
                pnHistorial.Dock = DockStyle.Fill
                pnHistorial.Visible = True
                ToolStripButton17.Visible = False
                TabCambioTipoInventario.Parent = Nothing
                TabConfirmarGuia.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                ToolStripButton20.Visible = False
                'getTableComprasPorPeriodoContado(Nothing, Nothing)
                getTableComprasPorPeriodoContadoTipo("DC")
            Case "numeroPendiente"
                Dim DocumentoCompraSA As New DocumentoCompraSA
                GridCFG2(dgvPendiente)
                ToolStripButton15.Visible = False
                ToolStripButton16.Visible = False
                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabInventario.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabKardex.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabRQ.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                TabAlmacen.Parent = Nothing
                TabTransferencia.Parent = Nothing
                TabCambioTipoInventario.Parent = Nothing
                TabConfirmarGuia.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                ToolStripButton20.Visible = True
                TabNumeroGuiaPendiente.Parent = TabControlAdv1
                'getTableGuiaRemision(GEstableciento.IdEstablecimiento, PeriodoGeneral, Gempresas.IdEmpresaRuc)
            Case "CambioInventario"
                Dim DocumentoCompraSA As New DocumentoCompraSA
                GridCFG2(dgvCambioInventario)
                ToolStripButton15.Visible = False
                ToolStripButton16.Visible = False
                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabInventario.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabKardex.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabRQ.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                TabAlmacen.Parent = Nothing
                TabTransferencia.Parent = Nothing
                ToolStripButton20.Visible = False
                TabCambioTipoInventario.Parent = TabControlAdv1
                TabNumeroGuiaPendiente.Parent = Nothing
                TabConfirmarGuia.Parent = Nothing
                TabVentaGeneral.Parent = Nothing
                getTableComprasPorPeriodoCambioTipoInventario("DC")
            Case "Pendientedeentrega"
                GridCFG2(dgvVentaGeneralGuia)
                GridCFG2(dgvListaVentaGuia)
                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabInventario.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabKardex.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabRQ.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                TabAlmacen.Parent = Nothing
                TabTransferencia.Parent = Nothing
                TabCambioTipoInventario.Parent = Nothing
                TabConfirmarGuia.Parent = Nothing
                TabVentaGeneral.Parent = TabControlAdv1
                'GetListaVentasGeneralPorPeridod()
                ToolStripButton7.Visible = True
                ToolStripButton8.Visible = True
            Case "Historial"
                GridCFG2(dgvConfirmar)
                GridCFG2(dgvHistorialConforme)
                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabInventario.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabKardex.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabRQ.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                TabAlmacen.Parent = Nothing
                TabTransferencia.Parent = Nothing
                TabCambioTipoInventario.Parent = Nothing
                TabConfirmarGuia.Parent = TabControlAdv1
                TabVentaGeneral.Parent = Nothing
                'GetListaVentasGeneralAprobado()
                GridGroupingControl2.Table.Records.DeleteAll()
        End Select
    End Sub

    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click

    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.Cursor = Cursors.WaitCursor
        If cboTipoExistenciaTransito.SelectedIndex > -1 Then
            GetInventarioTransitoByIdDocumento()
            'GetInventarioTransito(MesGeneral, AnioGeneral, cboTipoExistenciaTransito.SelectedValue)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton15_Click(sender As Object, e As EventArgs) Handles ToolStripButton15.Click
        Me.dgvTransito.Table.SelectedRecords.Clear()
        Me.dgvTransito.Table.Records.SelectAll()
    End Sub

    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs) Handles ToolStripButton16.Click
        Try
            If dgvTransito.Table.SelectedRecords.Count > 0 Then
                If rbParcial.Checked = True Then

                    If dgvEnvioAlmacen.Table.Records.Count > 0 Then
                        Dim f As New frmEnvioExistencia
                        '       f.txtFecha.Value = CType(dgvTransito.Table.CurrentRecord.GetValue("fechaCompra"), DateTime)
                        f.Movimiento = "Parcial"
                        f.Label6.Visible = False
                        f.Label2.Visible = False
                        f.cboAlmacen.Visible = False
                        f.cboAlmacen.Visible = False
                        f.cboEstable.Visible = False
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        If Not IsNothing(f.Tag) Then
                            Dim envio = CType(f.Tag, EnvioExistencia)
                            GrabarEnvioParcial(envio)
                        End If
                    Else
                        MessageBox.Show("Debe ingresar items a la canasta de distribución!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If


                Else
                    Dim f As New frmEnvioExistencia
                    '    Dim d = dgvTransferencia.Table.SelectedRecords(0).Record.GetValue("fechaCompra")
                    '     f.txtFecha.Value = CType(dgvTransito.Table.Records(0).GetValue("fechaCompra"), DateTime)
                    f.Movimiento = "Masivo"
                    f.StartPosition = FormStartPosition.CenterParent
                    f.Label6.Visible = True
                    f.Label2.Visible = True
                    f.cboAlmacen.Visible = True
                    f.cboAlmacen.Visible = True
                    f.ShowDialog()
                    If Not IsNothing(f.Tag) Then
                        Dim envio = CType(f.Tag, EnvioExistencia)
                        GrabarEnvioMasivo(envio)
                    End If
                End If
                dgvEnvioAlmacen.Table.Records.DeleteAll()
                ButtonAdv15_Click(sender, e)
                ButtonAdv20_Click(sender, e)
                GetCountExistenciaTransito()
            Else
                MessageBox.Show("Debe seleccionar items para el envio!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub Panel16_Click(sender As Object, e As EventArgs) Handles Panel16.Click
        If Not IsNothing(dgvTransito.Table.CurrentRecord) Then
            ' dgvEnvioAlmacen.Table.Records.DeleteAll()
            Dim sel = cboAlmacenDestino.SelectedValue
            If Not IsNothing(sel) Then
                If sel.ToString.Trim.Length > 0 Then
                    AsiganarItem(txtNumero.Value)
                Else
                    MessageBox.Show("Debe seleccionar un almacén de destino", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe seleccionar un almacén de destino", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If
    End Sub

    Private Sub Panel16_Paint(sender As Object, e As PaintEventArgs) Handles Panel16.Paint

    End Sub

    Private Sub rbCompleta_CheckChanged(sender As Object, e As EventArgs) Handles rbCompleta.CheckChanged
        If rbCompleta.Checked = True Then
            ToolStripButton15.Visible = True
            'ToolStripButton16.Visible = True
            Panel14.Visible = False
        End If
    End Sub

    Private Sub rbParcial_CheckChanged(sender As Object, e As EventArgs) Handles rbParcial.CheckChanged
        If rbParcial.Checked = True Then
            ToolStripButton15.Visible = False
            'ToolStripButton16.Visible = False
            Panel14.Visible = True
        End If
    End Sub

    Private Sub dgvTransito_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvTransito.QueryCellStyleInfo
        'If Not IsNothing(e.TableCellIdentity.Column) Then
        '    Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

        '    If e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Then
        '        If e.TableCellIdentity.Column.Name = "fechaEnvio" Then
        '            e.Style.Format = "dd/MM/yyyy"
        '        End If
        '        e.Handled = True
        '    End If


        'End If
    End Sub

    Private Sub dgvTransito_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvTransito.SelectedRecordsChanged
        If Not IsNothing(dgvTransito.Table.CurrentRecord) Then
            dgvEnvioAlmacen.Table.Records.DeleteAll()
            If Not IsNothing(e.SelectedRecord) Then
                txtCanDisponible.Text = CDec(e.SelectedRecord.Record.GetValue("saldoCan")).ToString("N2")
                txtMontoDisponible.Text = CDec(e.SelectedRecord.Record.GetValue("saldoMontoMN")).ToString("N2")
            End If
        End If
    End Sub

    Private Sub dgvTransito_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvTransito.TableControlCellClick

    End Sub

    Private Sub dgvEnvioAlmacen_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvEnvioAlmacen.SelectedRecordsChanged
        If Not IsNothing(dgvTransito.Table.CurrentRecord) Then
            If (CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan") > 0)) Then
                rbCompleta.Enabled = True
                rbParcial.Enabled = True
                txtCanDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan")).ToString("N2")
                txtMontoDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoMontoMN")).ToString("N2")
            Else
                ToolStripButton15.Visible = True
                rbCompleta.Checked = True
                Panel14.Visible = False
                rbCompleta.Enabled = True
                rbParcial.Enabled = False
                txtCanDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan")).ToString("N2")
                txtMontoDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoMontoMN")).ToString("N2")
            End If
        End If
    End Sub

    Private Sub dgvEnvioAlmacen_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvEnvioAlmacen.TableControlCellClick
        If Not IsNothing(dgvTransito.Table.CurrentRecord) Then
            If (CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan") > 0)) Then
                rbCompleta.Enabled = True
                rbParcial.Enabled = True
                txtCanDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan")).ToString("N2")
                txtMontoDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoMontoMN")).ToString("N2")
            Else
                ToolStripButton15.Visible = True
                rbCompleta.Checked = True
                Panel14.Visible = False
                rbCompleta.Enabled = True
                rbParcial.Enabled = False
                txtCanDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan")).ToString("N2")
                txtMontoDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoMontoMN")).ToString("N2")
            End If

        End If
    End Sub

    Private Sub dgvEnvioAlmacen_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvEnvioAlmacen.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim colMN As Decimal = 0
        Dim colME As Decimal = 0
        Dim PUmn As Decimal = 0
        Dim PUme As Decimal = 0
        If Not IsNothing(Me.dgvTransito.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 9
                    Dim colCan = ValidarExistenciaDisponible("cantidad")
                    If colCan <= 0 Then
                        MessageBox.Show("La cantidad debe ser mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    If CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan")) < colCan Then ' CDec(txtCanDisponible.Text) < colCan Then
                        MessageBox.Show("La cantidad disponible no debe exceder!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("cantidad", 0)
                        Exit Sub
                    Else
                        PUmn = CType(dgvEnvioAlmacen.Table.CurrentRecord.GetValue("puMN"), Decimal)
                        PUme = CType(dgvEnvioAlmacen.Table.CurrentRecord.GetValue("puME"), Decimal)

                        colMN = PUmn * Val(Me.dgvEnvioAlmacen.Table.CurrentRecord.GetValue("cantidad"))
                        colME = PUme * Val(Me.dgvEnvioAlmacen.Table.CurrentRecord.GetValue("cantidad"))
                        dgvEnvioAlmacen.Table.CurrentRecord.SetValue("montoMN", colMN)
                        dgvEnvioAlmacen.Table.CurrentRecord.SetValue("montoME", colME)
                    End If
                    'Case 10
                    '    Dim colMonto = ValidarExistenciaDisponible("montoMN")
                    '    If CDec(txtMontoDisponible.Text) < colMonto Then
                    '        MessageBox.Show("El monto disponible no debe exceder!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("montoMN", 0)
                    '        Exit Sub
                    '    End If
            End Select
        End If
    End Sub

    Private Sub Panel15_Click(sender As Object, e As EventArgs) Handles Panel15.Click
        If Not IsNothing(dgvEnvioAlmacen.Table.CurrentRecord) Then
            dgvEnvioAlmacen.Table.CurrentRecord.Delete()
        End If
    End Sub

    Private Sub Panel15_Paint(sender As Object, e As PaintEventArgs) Handles Panel15.Paint

    End Sub

    Private Sub ButtonAdv14_Click(sender As Object, e As EventArgs) Handles ButtonAdv14.Click
        LoadingAnimator.Wire(Me.dgvKardex2.TableControl)
        GetKardexByAnio()
        LoadingAnimator.UnWire(Me.dgvKardex2.TableControl)
    End Sub

    Private Sub CompraDeExistenciasServiciosToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CompraDeServiciosPúblicosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompraDeServiciosPúblicosToolStripMenuItem.Click

    End Sub

    Private Sub RegistroDeHonorariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeHonorariosToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmMovimientoAlmacen
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0)
                    '
                    '.cambioMovimiento()
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    GetTransitoNumeracion()
                    GetTransitoConteo()
                    getTableComprasPorPeriodoContadoTipo("PN")
                    'getTableComprasPorPeriodoContado(Nothing, Nothing)
                    dgvDetalleTransferencia.Table.Records.DeleteAll()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        'Dim f As New frmNuevoAlmacen
        'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
    End Sub

    Private Sub Panel22_Click(sender As Object, e As EventArgs) Handles Panel22.Click
        LoadingAnimator.Wire(Me.dgvKardex2.TableControl)
        Dim f As New frmBusquedaKardex(cboalmacenKardex.SelectedValue)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim envio = CType(f.Tag, BusquedaExstencia)
            GetKardexPeridoByExistencia(envio)
        End If
        LoadingAnimator.UnWire(Me.dgvKardex2.TableControl)
    End Sub

    Private Sub Panel22_Paint(sender As Object, e As PaintEventArgs) Handles Panel22.Paint

    End Sub

    Private Sub ConsignacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsignacionesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmOtrasSalidasDeAlmacen
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .cboOperacion.SelectedValue = "04.01"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"

                    '     .cambioMovimiento()
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PremioToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PremioToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmOtrasSalidasDeAlmacen
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .cboOperacion.SelectedValue = "08.02"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    ' .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    ' .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"

                    '     .cambioMovimiento()
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub DonaciónToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DonaciónToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmOtrasSalidasDeAlmacen
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .cboOperacion.SelectedValue = "09.02"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    ' .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"

                    '     .cambioMovimiento()
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub RetiroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RetiroToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmOtrasSalidasDeAlmacen
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .cboOperacion.SelectedValue = "12"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    ' .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    ' .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"

                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub MermasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MermasToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmOtrasSalidasDeAlmacen
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .cboOperacion.SelectedValue = "13"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"

                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub DesmedorsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesmedorsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then

                With frmOtrasSalidasDeAlmacen
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .cboOperacion.SelectedValue = "14"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    ' .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    ' .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"

                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub DestrucciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DestrucciónToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmOtrasSalidasDeAlmacen
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .cboOperacion.SelectedValue = "15"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    ' .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    '  .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"

                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmOtrasSalidasDeAlmacen
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .GroupBox2.Visible = True
                    .cboOperacion.SelectedValue = "10.01"
                    .rbCosto.Checked = True
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    ' .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    '  .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"

                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub DevolucionesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DevolucionesToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmOtrasSalidasDeAlmacen
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .cboOperacion.SelectedValue = "06"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    ' .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    '  .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"

                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub OtrosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OtrosToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmOtrasSalidasDeAlmacen
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .cboOperacion.SelectedValue = "0001"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '  .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    ' .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"

                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub treeViewAdv2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles treeViewAdv2.MouseDoubleClick
        LoadingAnimator.Wire(Me.dgvMov.TableControl)
        Select Case treeViewAdv2.SelectedNode.Tag
            Case "Dashboard"

            Case "transito"

            Case "resumen"

            Case "kardex"

            Case "periodo"
                '       GetMovPorPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral)

            Case "Alerta"
                GetInventarioEnAlerta(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
            Case "ordenCompra"
                getTableOrdenDeComprasPorPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral, TIPO_COMPRA.ORDEN_APROBADO)
            Case "TransferenciaTransito"
                'rbTodo.Checked = True
                'rbTransito.Checked = False
                'rbConfirmado.Checked = False
                getTableComprasPorPeriodoContadoTipo("PN")
                'getTableComprasPorPeriodoContado(GEstableciento.IdEstablecimiento, PeriodoGeneral)
            Case "RecepcionTransferencia"
                getTableComprasPorPeriodoContadoTipo("PN")
                'getTableComprasPorPeriodoContado(GEstableciento.IdEstablecimiento, PeriodoGeneral)
            Case "HistorialTransAlmacen"
                getTableComprasPorPeriodoContadoTipo("DC")
                'getTableComprasPorPeriodoContado(GEstableciento.IdEstablecimiento, PeriodoGeneral)
            Case "numeroPendiente"
                getTableGuiaRemision(GEstableciento.IdEstablecimiento, PeriodoGeneral, Gempresas.IdEmpresaRuc)
            Case "numeroPendiente"
                getTableComprasPorPeriodoContadoTipo("DC")
            Case "CambioInventario"
                getTableComprasPorPeriodoCambioTipoInventario("DC")
            Case "Pendientedeentrega"
                GetListaVentasGeneralPorPeridod()
            Case "Historial"
                GetListaVentasGeneralAprobado()
        End Select
        LoadingAnimator.UnWire(Me.dgvMov.TableControl)
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        LoadingAnimator.Wire(Me.dgvMov.TableControl)
        If TabControlAdv1.SelectedTab Is TabMovimientos Then
            If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
                If Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "TRANSFERENCIA ENTRE ALMACENES" Then ' TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES Then
                    With frmMovimientoAlmacen
                        .btGrabar.Enabled = False
                        .ToolStripButton1.Enabled = False
                        .GuardarToolStripButton.Enabled = False
                        .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        '.UbicarDocumento(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                        .StartPosition = FormStartPosition.CenterParent
                        .WindowState = FormWindowState.Normal
                        .ShowDialog()
                    End With '
                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "ENTRADA DE EXISTENCIAS" Then
                    With frmMovOtrasEntradas
                        .btGrabar.Enabled = False
                        .GuardarToolStripButton.Enabled = True
                        .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        .UbicarDocumento(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                        .WindowState = FormWindowState.Normal
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "SALIDA DE EXISTENCIAS" Then
                    With frmOtrasSalidasDeAlmacen
                        .btGrabar.Enabled = False
                        .GuardarToolStripButton.Enabled = True
                        .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        .UbicarDocumento(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                        .WindowState = FormWindowState.Normal
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                End If
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        LoadingAnimator.UnWire(Me.dgvMov.TableControl)
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
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        LoadingAnimator.Wire(Me.dgvMov.TableControl)
        If TabControlAdv1.SelectedTab Is TabMovimientos Then
            If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then

                '    If MessageBox.Show("eliminar el item seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "TRANSFERENCIA ENTRE ALMACENES" Then
                    MessageBox.Show("No se puede eliminar una transferencia!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    '    EliminarTransferenciaAlmacen(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                    '    Me.dgvMov.Table.CurrentRecord.Delete()
                    '    PanelError.Visible = True
                    '    lblEstado.Text = "entrada eliminada!"
                    '    Timer1.Enabled = True
                    '    TiempoEjecutar(10)
                    'End If
                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "ENTRADA DE EXISTENCIAS" Then
                    If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        RemoveCompra(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                        Me.dgvMov.Table.CurrentRecord.Delete()
                        PanelError.Visible = True
                        lblEstado.Text = "entrada eliminada!"
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    End If
                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "SALIDA DE EXISTENCIAS" Then
                    If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        EliminarOtrasSalidas(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                        Me.dgvMov.Table.CurrentRecord.Delete()
                        PanelError.Visible = True
                        lblEstado.Text = "Registro eliminado!"
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    End If
                End If
                '  End If


            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        LoadingAnimator.UnWire(Me.dgvMov.TableControl)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        LoadingAnimator.Wire(Me.dgvMov.TableControl)
        GetInventarioEnAlertaConteo(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
        GetCountExistenciaTransito()
        If TabControlAdv1.SelectedTab Is TabMovimientos Then
            GetMovPorPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral)
        ElseIf TabControlAdv1.SelectedTab Is TabAlertaInventario Then
            GetInventarioEnAlerta(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
        End If
        LoadingAnimator.UnWire(Me.dgvMov.TableControl)
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
    Dim hoveredIndex As Integer = 0

    Dim selectionColl As New Hashtable()
    Private Sub dgvKardex2_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvKardex2.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvKardex2.TableControl.Selections.Clear()
        End If

        If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
            'Checks for the column name when the cellvalue is greater than 5.
            'ENTRADAS A ALMACEN
            If e.TableCellIdentity.Column.MappingName = "cantidad" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
                e.Style.BackColor = Color.FromArgb(225, 240, 190)
            End If
            If e.TableCellIdentity.Column.MappingName = "monto" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
                e.Style.BackColor = Color.FromArgb(225, 240, 190)
            End If


            'SALIDAS A ALMACEN
            If e.TableCellIdentity.Column.MappingName = "cantidad1" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
                e.Style.BackColor = Color.FromArgb(255, 192, 192) '
            End If
            If e.TableCellIdentity.Column.MappingName = "monto1" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
                e.Style.BackColor = Color.FromArgb(255, 192, 192)
            End If

        End If
    End Sub

    Private Sub dgvKardex2_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvKardex2.TableControlCellClick

    End Sub
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
    Private Sub dgvKardex2_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvKardex2.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvKardex2)
    End Sub

    Private Sub PanelError_Paint(sender As Object, e As PaintEventArgs) Handles PanelError.Paint

    End Sub


    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.Cursor = Cursors.WaitCursor
        If cboConsultaRotacion.Text = "0 - 10 unidades" Then
            VentasCantidadStock("1", txtfecInicio.Value, txtfecFin.Value, CDec(10.0), CDec(0.0), "filtro de 0 - 10 unidades")
        ElseIf cboConsultaRotacion.Text = "11 - 100 unidades" Then
            VentasCantidadStock("2", txtfecInicio.Value, txtfecFin.Value, CDec(100.0), CDec(11), "filtro de 11 - 100 unidades")
        ElseIf cboConsultaRotacion.Text = "101 - 500 unidades" Then
            VentasCantidadStock("3", txtfecInicio.Value, txtfecFin.Value, CDec(500.0), CDec(101), "filtro de 101 - 500 unidades")
        ElseIf cboConsultaRotacion.Text = "501 - a mas" Then
            VentasCantidadStock("4", txtfecInicio.Value, txtfecFin.Value, CDec(99999999), CDec(501), "filtro de 501 - a mas unidades")
        ElseIf cboConsultaRotacion.Text = "0 - a mas" Then
            VentasCantidadStock("4", txtfecInicio.Value, txtfecFin.Value, CDec(99999999), CDec(0), "filtro de  0 - a mas unidades")
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtDiasAtraso_ValueChanged(sender As Object, e As EventArgs) Handles txtDiasAtraso.ValueChanged
        Dim valor = txtDiasAtraso.Value
        Dim s As New DateTime
        s = DateTime.Now
        Dim addDay As DateTime = s.AddDays(CInt(-(valor)))
        txtfecFin.Value = DateTime.Now
        txtfecInicio.Value = addDay
    End Sub
    Dim filter As New GridExcelFilter()
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If TabControlAdv1.SelectedTab Is TabInventario Then
            Me.dgvKardexVal.TopLevelGroupOptions.ShowFilterBar = True
            Me.dgvKardexVal.NestedTableGroupOptions.ShowFilterBar = True
            Me.dgvKardexVal.ChildGroupOptions.ShowFilterBar = True

            For Each col As GridColumnDescriptor In Me.dgvKardexVal.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True
        End If
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        If TabControlAdv1.SelectedTab Is TabInventario Then
            dgvKardexVal.TableDescriptor.GroupedColumns.Clear()
            If dgvKardexVal.ShowGroupDropArea = True Then
                dgvKardexVal.ShowGroupDropArea = False
            Else
                dgvKardexVal.ShowGroupDropArea = True
            End If
        End If

    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click, ToolStripButton21.Click
        If TabControlAdv1.SelectedTab Is TabInventario Then
            filter.ClearFilters(Me.dgvKardexVal)
            Me.dgvKardexVal.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

    Private Sub Panel28_Click(sender As Object, e As EventArgs) Handles Panel28.Click
        Dim converter As New GroupingGridExcelConverterControl

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Files(*.xls)|*.xls"
        saveFileDialog.DefaultExt = ".xls"


        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            'If radioButton1.Checked Then
            converter.GroupingGridToExcel(Me.dgvKardexVal, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.Visible)
            'ElseIf radioButton2.Checked Then
            '    converter.GroupingGridToExcel(Me.GridGroupingControl1, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.[Default])
            'End If

            If MessageBox.Show("Do you wish to open the xls file now?", "Export to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim proc As New Process()
                proc.StartInfo.FileName = saveFileDialog.FileName
                proc.Start()
            End If
        End If


    End Sub

    Private Sub Panel28_Paint(sender As Object, e As PaintEventArgs) Handles Panel28.Paint

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
    End Sub

    Private Sub dgvKardexVal_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvKardexVal.TableControlCellClick

    End Sub

    Private Sub dgvKardexVal_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvKardexVal.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim totalesSA As New TotalesAlmacenSA
        If Not IsNothing(Me.dgvKardexVal.Table.CurrentRecord) Then

            dgvKardexVal.TableControl.CurrentCell.EndEdit()
            dgvKardexVal.TableControl.Table.TableDirty = True
            dgvKardexVal.TableControl.Table.EndEdit()

            Select Case ColIndex
                Case 10 'max
                    If CDec(Me.dgvKardexVal.Table.CurrentRecord.GetValue("cantmax")) <= 0 Then
                        MessageBox.Show("El número ingresado debe ser mayor a cero", "Validar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    'If CDec(Me.dgvKardexVal.Table.CurrentRecord.GetValue("cantmin")) <= 0 Then
                    '    MessageBox.Show("El número ingresado debe ser mayor a cero", "Validar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    Exit Sub
                    'End If

                    Dim canMax As Decimal = CDec(Me.dgvKardexVal.Table.CurrentRecord.GetValue("cantmax"))
                    Dim canMin As Decimal = CDec(Me.dgvKardexVal.Table.CurrentRecord.GetValue("cantmin"))

                    If canMax <= canMin Then
                        MessageBox.Show("La cantidad máxima debe ser mayor a la cantidad mínima", "Informmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    totalesSA.ActulizarCantidadesByItem(New totalesAlmacen With {.idMovimiento = dgvKardexVal.Table.CurrentRecord.GetValue("idmovimiento"),
                                                                                 .cantidadMaxima = canMax, .cantidadMinima = canMin})

                    MessageBox.Show("Datos actualizados", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.dgvKardexVal.Table.CurrentRecord.SetValue("cantmax", canMax.ToString("N2"))

                    GetInventarioEnAlertaConteo(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
                Case 11 ' min

                    'If CDec(Me.dgvKardexVal.Table.CurrentRecord.GetValue("cantmax")) <= 0 Then
                    '    MessageBox.Show("El número ingresado debe ser mayor a cero", "Validar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    Exit Sub
                    'End If

                    If CDec(Me.dgvKardexVal.Table.CurrentRecord.GetValue("cantmin")) <= 0 Then
                        MessageBox.Show("El número ingresado debe ser mayor a cero", "Validar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    Dim canMax As Decimal = CDec(Me.dgvKardexVal.Table.CurrentRecord.GetValue("cantmax"))
                    Dim canMin As Decimal = CDec(Me.dgvKardexVal.Table.CurrentRecord.GetValue("cantmin"))

                    If canMin >= canMax Then
                        MessageBox.Show("La cantidad mínima no pueder ser mayor o igual a la cantidad máxima", "Informmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    totalesSA.ActulizarCantidadesByItem(New totalesAlmacen With {.idMovimiento = dgvKardexVal.Table.CurrentRecord.GetValue("idmovimiento"),
                                                                                 .cantidadMaxima = canMax, .cantidadMinima = canMin})

                    MessageBox.Show("Datos actualizados", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.dgvKardexVal.Table.CurrentRecord.SetValue("cantmin", canMin.ToString("N2"))
                    GetInventarioEnAlertaConteo(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
            End Select

        End If
    End Sub


    Private Sub cboTipoExistenciaTransito_Click(sender As Object, e As EventArgs) Handles cboTipoExistenciaTransito.Click

    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Me.Cursor = Cursors.WaitCursor
        If cboCosto.SelectedIndex > -1 Then
            GetRequerimientosByProyecto(New recursoCostoDetalle With {.idCosto = cboCosto.SelectedValue, .tipoCosto = "RQ", .procesado = "N"})
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtBuscarProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarProducto.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If txtBuscarProducto.Text.Trim.Length > 0 Then
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                GetRequeridosContenidos()

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtBuscarProducto_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarProducto.TextChanged

    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        GridGroupingControl2.Table.Records.DeleteAll()
    End Sub

    Private Sub lsvExistencias_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvExistencias.MouseDoubleClick
        If lsvExistencias.SelectedItems.Count > 0 Then
            Dim item As New ListViewItem
            item = lsvExistencias.SelectedItems(0)

            Me.GridGroupingControl2.Table.AddNewRecord.SetCurrent()
            Me.GridGroupingControl2.Table.AddNewRecord.BeginEdit()
            Me.GridGroupingControl2.Table.CurrentRecord.SetValue("id", item.SubItems(0).Text)
            Me.GridGroupingControl2.Table.CurrentRecord.SetValue("descripcion", item.SubItems(1).Text)
            Me.GridGroupingControl2.Table.CurrentRecord.SetValue("cantDisponible", item.SubItems(2).Text)
            Me.GridGroupingControl2.Table.CurrentRecord.SetValue("cantidad", 0)
            Me.GridGroupingControl2.Table.CurrentRecord.SetValue("um", item.SubItems(4).Text)
            Me.GridGroupingControl2.Table.CurrentRecord.SetValue("almacen", item.SubItems(6).Text)
            Me.GridGroupingControl2.Table.CurrentRecord.SetValue("costoSec", txtBuscarProducto.Tag)
            Me.GridGroupingControl2.Table.CurrentRecord.SetValue("proceso", CInt(dgvRQ.Table.CurrentRecord.GetValue("actividad")))
            Me.GridGroupingControl2.Table.AddNewRecord.EndEdit()
        End If
    End Sub

    Private Sub lsvExistencias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvExistencias.SelectedIndexChanged

    End Sub

    Private Sub dgvRQ_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvRQ.SelectedRecordsChanged
        If Not IsNothing(dgvRQ.Table.CurrentRecord) Then
            txtBuscarProducto.Text = dgvRQ.Table.CurrentRecord.GetValue("descripcion")
            txtBuscarProducto.Tag = Val(dgvRQ.Table.CurrentRecord.GetValue("secuencia"))
        End If

    End Sub

    Private Sub dgvRQ_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvRQ.TableControlCellClick

    End Sub

    Private Sub GridGroupingControl2_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridGroupingControl2.TableControlCellClick

    End Sub

    Private Sub GridGroupingControl2_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles GridGroupingControl2.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Try
            If Not IsNothing(Me.GridGroupingControl2.Table.CurrentRecord) Then
                Select Case ColIndex
                    Case 4
                        Dim colDisponible As Decimal = 0
                        Dim colProducir As Decimal = 0

                        colDisponible = CDec(Me.GridGroupingControl2.Table.CurrentRecord.GetValue("cantDisponible"))
                        colProducir = CDec(Me.GridGroupingControl2.Table.CurrentRecord.GetValue("cantidad"))

                        If colProducir > colDisponible Then
                            Me.GridGroupingControl2.Table.CurrentRecord.SetValue("cantidad", 0)
                            Throw New Exception("La cantidad a producir no puede ser mayor a la disponible")

                        End If

                End Select
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        If GridGroupingControl2.Table.Records.Count > 0 Then
            Dim f As New frmGenerarSalidaProduccion(GridGroupingControl2, dgvRQ.Table.CurrentRecord.GetValue("Confirmar"))
            f.txtProyecto.Text = dgvRQ.Table.CurrentRecord.GetValue("proyecto")
            f.txtProyecto.Tag = dgvRQ.Table.CurrentRecord.GetValue("Confirmar")
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If f.Tag = "Grabado" Then
                GridGroupingControl2.Table.Records.DeleteAll()
                lsvExistencias.Items.Clear()
                txtBuscarProducto.Clear()
                ButtonAdv3_Click(sender, e)
            End If
        Else
            MessageBox.Show("La canasta de producción no contiene artículos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        If Not IsNothing(GridGroupingControl2.Table.CurrentRecord) Then
            GridGroupingControl2.Table.CurrentRecord.Delete()
        Else
            MessageBox.Show("Seleccione un item válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub bgGeneral_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgGeneral.DoWork

        'Hilo()
    End Sub

    Private Sub bgGeneral_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgGeneral.RunWorkerCompleted
        'hiloCompleto()
        'GridCFGInventarios(dgvKardexVal)
        'GridCFG2(dgvTransito)
        'GridCFG2(dgvEnvioAlmacen)
        'GridCFGKardex(dgvKardex2)
        'GridCFGKardex(dgvStockMinimo)
        'ToolStrip1.Visible = True
        'notif.Close()
    End Sub

    Private Sub cboAlmacen_Click(sender As Object, e As EventArgs) Handles cboAlmacen.Click

    End Sub

    Private Sub frmInventario_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'notif = New FeedbackForm
        'notif.StartPosition = FormStartPosition.CenterScreen
        'notif.TopMost = True
        'notif.Show()
        'bgGeneral.RunWorkerAsync()
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        If Not IsNothing(Me.dgvOrdenCompra.Table.CurrentRecord) Then

            With frmDetalleOrdenDeCompra
                .UbicarDocumentoOrdenCompra(Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("idDocumento"))
                .idDocumento = (Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("idDocumento"))
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Normal
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .ShowDialog()
            End With

        Else
            MessageBox.Show("Debe seleccionar un item!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub txtNumero_ValueChanged(sender As Object, e As EventArgs) Handles txtNumero.ValueChanged

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub

    Private Sub txtCodigoBarra_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoBarra.KeyDown

        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If Not txtCodigoBarra.Text.Trim.Length > 0 Then

                MessageBox.Show("Ingrese un Codigo para Buscar", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If cboAlmacen.SelectedIndex > -1 Then
                Dim codAlmacen = cboAlmacen.SelectedValue
                If IsNumeric(codAlmacen) Then

                    GetInventarioValorizadoCodigo(codAlmacen, txtCodigoBarra.Text)

                End If


            Else
                MessageBox.Show("Seleccione un Almancen", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If




        End If
        Me.Cursor = Cursors.Arrow



    End Sub

    Private Sub txtCodigoBarra_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoBarra.TextChanged

    End Sub

    Private Sub CambioDeExistenciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambioDeExistenciaToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmCambioInventario
                    .lblMovimiento.Text = "CAMBIO TIPO INVENTARIO"
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0)

                    '.cambioMovimiento()
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        GetAlmacenes()
    End Sub

    Private Sub NewToolStripButton1_Click(sender As Object, e As EventArgs) Handles NewToolStripButton1.Click
        'Dim f As New frmNuevoAlmacen
        'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
        'GetAlmacenes()
    End Sub

    Private Sub OpenToolStripButton1_Click(sender As Object, e As EventArgs) Handles OpenToolStripButton1.Click
        'Me.Cursor = Cursors.WaitCursor
        'Dim r As Record = dgAlmacen.Table.CurrentRecord
        'If Not IsNothing(r) Then
        '    Dim f As New frmNuevoAlmacen
        '    f.UbicarDocumento(Val(r.GetValue("idalmacen")))
        '    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.ShowDialog()
        '    GetAlmacenes()
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel37_Click(sender As Object, e As EventArgs) Handles Panel37.Click
        Me.Cursor = Cursors.WaitCursor
        GetKardexByAnioCV()
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub dgvTransferencia_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvTransferencia.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvTransferencia.Table.CurrentRecord) Then
            ObtenerListaGuiaRemision(Me.dgvTransferencia.Table.CurrentRecord.GetValue("idDocumento"))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs) Handles ToolStripButton17.Click
        Me.Cursor = Cursors.WaitCursor
        Dim r As Record = dgvDetalleTransferencia.Table.CurrentRecord
        If Not IsNothing(r) Then

            If (r.GetValue("estado") = "PARCIAL") Then
                'Dim f As New frmControlEntregableTransferencia((dgvDetalleTransferencia.Table.CurrentRecord.GetValue("idDocumento")))
                'f.StartPosition = FormStartPosition.CenterParent
                'f.ShowDialog()
                'GetTransitoConteo()
                'getTableComprasPorPeriodoContado(Nothing, Nothing)
                'dgvDetalleTransferencia.Table.Records.DeleteAll()
            ElseIf (r.GetValue("estado") = "POR CONFIRMAR") Then
                'Dim objActualizar As New documentoVentaAbarrotesSA
                'Dim f As New frmControlEntregableTransferencia((dgvDetalleTransferencia.Table.CurrentRecord.GetValue("idDocumento")))
                'f.strTipo = "TRANSFERENCIA"
                'f.StartPosition = FormStartPosition.CenterParent
                'f.ShowDialog()
                'GetTransitoConteo()
                'getTableComprasPorPeriodoContadoTipo("DC")
                'dgvDetalleTransferencia.Table.Records.DeleteAll()
            End If


        Else
            MessageBox.Show("Debe elegir una venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton18_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim r As Record = dgvTransferencia.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmControlEntregables(Val(dgvTransferencia.Table.CurrentRecord.GetValue("idDocumento")))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Else
            MessageBox.Show("Debe elegir una venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton19_Click(sender As Object, e As EventArgs) Handles ToolStripButton19.Click, ToolStripButton22.Click
        Me.Cursor = Cursors.WaitCursor
        Dim r As Record = dgvDetalleTransferencia.Table.CurrentRecord
        If Not IsNothing(r) Then

            Dim f As New frmHistorialRecepcion(dgvDetalleTransferencia.Table.CurrentRecord.GetValue("idDocumento"))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

        Else
            MessageBox.Show("Debe elegir una venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If (CheckBox4.Checked = True) Then
            Panel39.Enabled = False
            txtBuscar.Clear()
            rbTodo.Checked = True
            dgvDetalleTransferencia.Table.Records.DeleteAll()
        Else
            Panel39.Enabled = True
            txtBuscar.Clear()
            rbTodo.Checked = True
            dgvDetalleTransferencia.Table.Records.DeleteAll()
        End If
    End Sub

    Private Sub rbTransito_CheckedChanged(sender As Object, e As EventArgs) Handles rbTransito.CheckedChanged
        If (rbTransito.Checked = True) Then
            rbTodo.Checked = False
            rbConfirmado.Checked = False
            getTableComprasPorPeriodoContadoTipo("PN")
            txtBuscar.Clear()
            Panel39.Enabled = False
            dgvDetalleTransferencia.Table.Records.DeleteAll()
        End If
    End Sub

    Private Sub rbTodo_CheckedChanged(sender As Object, e As EventArgs) Handles rbTodo.CheckedChanged
        If (rbTodo.Checked = True) Then
            rbTransito.Checked = False
            rbConfirmado.Checked = False
            getTableComprasPorPeriodoContado(GEstableciento.IdEstablecimiento, PeriodoGeneral)
            dgvDetalleTransferencia.Table.Records.DeleteAll()
        End If
    End Sub

    Private Sub rbConfirmado_CheckedChanged(sender As Object, e As EventArgs) Handles rbConfirmado.CheckedChanged
        If (rbConfirmado.Checked = True) Then
            rbTransito.Checked = False
            rbTodo.Checked = False
            getTableComprasPorPeriodoContadoTipo("DC")
            txtBuscar.Clear()
            Panel39.Enabled = False
            dgvDetalleTransferencia.Table.Records.DeleteAll()
        End If
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        If (txtBuscar.Text.Length > 0) Then
            getTableComprasPorPeriodoContadoTipo("DC")
            dgvDetalleTransferencia.Table.Records.DeleteAll()
        End If
    End Sub

    Private Sub ToolStripButton18_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton18.Click


        LoadingAnimator.Wire(Me.dgvMov.TableControl)
        Select Case treeViewAdv2.SelectedNode.Tag

            Case "TransferenciaTransito"
                If Not IsNothing(dgvTransferencia.Table.CurrentRecord) Then
                    Dim f As New frmMovimientoAlmacen((dgvTransferencia.Table.CurrentRecord.GetValue("idDocumento")))
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                Else
                    MessageBox.Show("Debe seleccionar un item!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If


            Case "RecepcionTransferencia"
                If Not IsNothing(dgvTransferencia.Table.CurrentRecord) Then
                    Dim f As New frmMovimientoAlmacen((dgvTransferencia.Table.CurrentRecord.GetValue("idDocumento")))
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                Else
                    MessageBox.Show("Debe seleccionar un item!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Case "HistorialTransAlmacen"
                If Not IsNothing(dgvTransferencia.Table.CurrentRecord) Then
                    Dim f As New frmMovimientoAlmacen((dgvTransferencia.Table.CurrentRecord.GetValue("idDocumento")))
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                Else
                    MessageBox.Show("Debe seleccionar un item!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Case "CambioInventario"
                If Not IsNothing(dgvCambioInventario.Table.CurrentRecord) Then
                    Dim f As New frmCambioInventario((dgvCambioInventario.Table.CurrentRecord.GetValue("idDocumento")))
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                Else
                    MessageBox.Show("Debe seleccionar un item!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
        End Select
        LoadingAnimator.UnWire(dgvMov.TableControl)

    End Sub

    Private Sub ToolStripButton20_Click(sender As Object, e As EventArgs) Handles ToolStripButton20.Click
        Try
            If dgvPendiente.Table.SelectedRecords.Count > 0 Then

                If dgvPendiente.Table.Records.Count > 0 Then
                    Dim f As New frmAsignarNumeroGuia
                    f.idPadre = dgvPendiente.Table.CurrentRecord.GetValue("idPadre")
                    f.idDocumento = dgvPendiente.Table.CurrentRecord.GetValue("idDocumento")
                    f.txtFecha.Value = dgvPendiente.Table.CurrentRecord.GetValue("fechaDoc")
                    f.txtEstablecimiento.Text = dgvPendiente.Table.CurrentRecord.GetValue("nombreEstablecimiento")
                    f.txtEmpresa.Text = dgvPendiente.Table.CurrentRecord.GetValue("nombreEmpresa")
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                    GetTransitoNumeracion()
                    dgvPendiente.Table.Records.DeleteAll()
                    'getTableGuiaRemision(GEstableciento.IdEstablecimiento, PeriodoGeneral, Gempresas.IdEmpresaRuc)

                Else
                    MessageBox.Show("Debe ingresar items a la canasta de distribución!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub ConsignacioneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsignacioneToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmMovOtrasEntradas
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .cboOperacion.SelectedValue = "03.01"
                    .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"

                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PromociónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PromociónToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor

        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmMovOtrasEntradas
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .cboOperacion.SelectedValue = "07.01"
                    .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"

                    '     .cambioMovimiento()
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PremioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PremioToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmMovOtrasEntradas
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .cboOperacion.SelectedValue = "08.01"
                    .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"

                    '     .cambioMovimiento()
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub DonaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DonaciónToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmMovOtrasEntradas
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .cboOperacion.SelectedValue = "09.01"
                    .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    '  .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"

                    '     .cambioMovimiento()
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ProductosTerminadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosTerminadosToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmMovOtrasEntradas
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .cboOperacion.SelectedValue = "10.03"
                    .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    ' .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    ' .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"

                    '     .cambioMovimiento()
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub SubProductosDesechosYDesperdiciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubProductosDesechosYDesperdiciosToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmMovOtrasEntradas
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .cboOperacion.SelectedValue = "9904"
                    .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '   .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    '  .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"

                    '     .cambioMovimiento()
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ProductosEnProcesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosEnProcesoToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmMovOtrasEntradas
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .cboOperacion.SelectedValue = "10.07"
                    .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '  .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    '  .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"

                    '     .cambioMovimiento()
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub DevolucionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevolucionesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmMovOtrasEntradas
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .cboOperacion.SelectedValue = "05"
                    .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    ' .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    '  .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"

                    '     .cambioMovimiento()
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
       
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub OtrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OtrosToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmMovOtrasEntradas
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .cboOperacion.SelectedValue = "0000"
                    .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    ' .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    '  .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"

                    '     .cambioMovimiento()
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel37_Paint(sender As Object, e As PaintEventArgs) Handles Panel37.Paint

    End Sub

    Private Sub Panel44_Paint(sender As Object, e As PaintEventArgs) Handles Panel44.Paint

    End Sub

    Private Sub Panel44_Click(sender As Object, e As EventArgs) Handles Panel44.Click
        Dim f As New frmCostoVentaTipoExistencia(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fecha = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)})
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click

    End Sub

    Private Sub TextBoxExt1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt1.KeyDown

    End Sub

    Private Sub TextBoxExt2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt2.KeyDown

    End Sub

    Private Sub TextBoxExt2_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt2.TextChanged

    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp

    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick

    End Sub

    Private Sub dgvVentaGeneral_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvVentaGeneral.TableControlCellClick

    End Sub

    Private Sub ToolStripButton23_Click(sender As Object, e As EventArgs) Handles ToolStripButton23.Click
        Me.Cursor = Cursors.WaitCursor
        Dim r As Record = dgvListaVentaGuia.Table.CurrentRecord
        If Not IsNothing(r) Then

            If (r.GetValue("estado") = "PARCIAL") Then
                Dim f As New frmReporteControlEntregable((dgvListaVentaGuia.Table.CurrentRecord.GetValue("idDocumento")))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                dgvListaVentaGuia.Table.Records.DeleteAll()
            ElseIf (r.GetValue("estado") = "POR CONFIRMAR") Then
                Dim objActualizar As New documentoVentaAbarrotesSA
                Dim f As New frmReporteControlEntregable((dgvListaVentaGuia.Table.CurrentRecord.GetValue("idDocumento")))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                dgvListaVentaGuia.Table.Records.DeleteAll()
            End If

            dgvVentaGeneralGuia.Table.Records.DeleteAll()
            dgvListaVentaGuia.Table.Records.DeleteAll()
            dgvConfirmar.Table.Records.DeleteAll()
            dgvHistorialConforme.Table.Records.DeleteAll()
            GetCargarVentasGuia()
        Else
            MessageBox.Show("Debe elegir una venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton24_Click(sender As Object, e As EventArgs) Handles ToolStripButton24.Click
        Me.Cursor = Cursors.WaitCursor
        Dim r As Record = dgvListaVentaGuia.Table.CurrentRecord
        If Not IsNothing(r) Then

            Dim f As New frmHistorialRecepcion(dgvListaVentaGuia.Table.CurrentRecord.GetValue("idDocumento"))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

        Else
            MessageBox.Show("Debe elegir una venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GridGroupingControl4_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvVentaGeneralGuia.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvVentaGeneralGuia.Table.CurrentRecord) Then
            ObtenerListaGuiaRemisionVenta(Me.dgvVentaGeneralGuia.Table.CurrentRecord.GetValue("idDocumento"))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton25_Click(sender As Object, e As EventArgs) Handles ToolStripButton25.Click
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

    Private Sub ToolStripButton26_Click(sender As Object, e As EventArgs) Handles ToolStripButton26.Click
        Me.Cursor = Cursors.WaitCursor
        Dim r As Record = dgvVentaGeneralGuia.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmControlEntregables(Val(dgvVentaGeneralGuia.Table.CurrentRecord.GetValue("idDocumento")))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Else
            MessageBox.Show("Debe elegir una venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        Cursor = Cursors.WaitCursor
        GetMovPorPeriodo(GEstableciento.IdEstablecimiento, cboMesCompra.SelectedValue & "/" & AnioGeneral)
        Cursor = Cursors.Default
    End Sub

    Private Sub txtAnioCompra_TextChanged(sender As Object, e As EventArgs) Handles txtAnioCompra.TextChanged

    End Sub

    Private Sub ButtonAdv18_Click(sender As Object, e As EventArgs) Handles ButtonAdv18.Click
        Dim r As Record = dgvMov.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmCambiarPeriodo2(New documentocompra With {.idDocumento = Val(r.GetValue("idDocumento"))})
            f.operacion = StatusTipoOperacion.COMPRA
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            ButtonAdv19_Click(sender, e)
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked = True Then

            dgvKardex2.TableDescriptor.Columns("precUnite").Width = 0
            dgvKardex2.TableDescriptor.Columns("precUnite1").Width = 0
            dgvKardex2.TableDescriptor.Columns("precUnite2").Width = 0
            dgvKardex2.TableDescriptor.Columns("monto").Width = 0
            dgvKardex2.TableDescriptor.Columns("monto1").Width = 0
            dgvKardex2.TableDescriptor.Columns("monto2").Width = 0


            dgvKardex2.TableDescriptor.Columns("cantidad").Width = 70
            dgvKardex2.TableDescriptor.Columns("cantidad1").Width = 70
            dgvKardex2.TableDescriptor.Columns("cantidad2").Width = 70

        Else

            dgvKardex2.TableDescriptor.Columns("precUnite").Width = 70
            dgvKardex2.TableDescriptor.Columns("precUnite1").Width = 70
            dgvKardex2.TableDescriptor.Columns("precUnite2").Width = 70
            dgvKardex2.TableDescriptor.Columns("monto").Width = 70
            dgvKardex2.TableDescriptor.Columns("monto1").Width = 70
            dgvKardex2.TableDescriptor.Columns("monto2").Width = 70

            dgvKardex2.TableDescriptor.Columns("cantidad").Width = 70
            dgvKardex2.TableDescriptor.Columns("cantidad1").Width = 70
            dgvKardex2.TableDescriptor.Columns("cantidad2").Width = 70

        End If
    End Sub

    Private Sub ButtonAdv20_Click(sender As Object, e As EventArgs) Handles ButtonAdv20.Click
        Me.Cursor = Cursors.WaitCursor
        If cboproveedor.SelectedIndex > -1 Then
            GetComprobantesEnCola()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If (RadioButton4.Checked = True) Then
            dgvConfirmar.Table.Records.DeleteAll()
            dgvHistorialConforme.Table.Records.DeleteAll()
            Panel49.Enabled = True
            TextBoxExt3.Clear()
            TextBoxExt4.Clear()
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If (RadioButton3.Checked = True) Then
            Panel49.Enabled = False
            'GetListaVentasGeneralPorPeridod()
            TextBoxExt3.Clear()
            TextBoxExt4.Clear()
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If (RadioButton5.Checked = True) Then
            Panel52.Enabled = False
            'GetListaVentasGeneralPorPeridod()
            TextBoxExt5.Clear()
            TextBoxExt6.Clear()
        End If
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        If (RadioButton6.Checked = True) Then
            dgvVentaGeneralGuia.Table.Records.DeleteAll()
            dgvListaVentaGuia.Table.Records.DeleteAll()
            Panel52.Enabled = True
            TextBoxExt5.Clear()
            TextBoxExt6.Clear()
        End If
    End Sub

    Private Sub dgvTransferencia_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvTransferencia.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvKardex2.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvTransferencia_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvTransferencia.TableControlCellMouseHoverEnter

    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged

    End Sub

    Private Sub txtFiltroLote_TextChanged(sender As Object, e As EventArgs) Handles txtFiltroLote.TextChanged

    End Sub
End Class