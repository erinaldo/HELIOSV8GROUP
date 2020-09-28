Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Tools
Imports System.Collections
Imports Syncfusion.Windows.Forms.Grid
Imports System.Collections.Specialized
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmHojaTrabajoDetalle
    Inherits frmMaster
    Dim card As New GridCardView()
#Region "Métodos"
    Dim colorx As New GridMetroColors()
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

    Public Sub MostrarAsiento(intIdAsiento As Integer)
        Dim movimientoSA As New MovimientoSA
        Dim dt As New DataTable()

        dt.Columns.Add("cuenta")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("tipo")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")

        For Each i In movimientoSA.UbicarMovimientoPorAsiento(intIdAsiento)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.cuenta
            dr(1) = i.descripcion
            dr(2) = i.tipo
            dr(3) = CDec(i.monto).ToString("N2")
            dr(4) = CDec(i.montoUSD).ToString("N2")
            dt.Rows.Add(dr)
        Next
        GridGroupingControl1.DataSource = dt
    End Sub

    Public Sub MostrarAsientoLibro(intIdAsiento As Integer)
        Dim movimientoSA As New documentoLibroDiarioSA
        Dim dt As New DataTable()

        dt.Columns.Add("cuenta")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("tipo")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")

        For Each i In movimientoSA.GetUbicar_documentoLibroDiarioDetallePorIDDocumento(intIdAsiento)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.cuenta
            dr(1) = i.descripcion
            dr(2) = i.tipoAsiento
            dr(3) = CDec(i.importeMN).ToString("N2")
            dr(4) = CDec(i.importeME).ToString("N2")
            dt.Rows.Add(dr)
        Next
        GridGroupingControl1.DataSource = dt
    End Sub


    Sub MostrarAsientosMenu(intIdDocumento As Integer, node As TreeNodeAdv)
        Dim asientoSA As New AsientoSA
        Dim conteo As Integer = 1
        For Each i In asientoSA.UbicarAsientoPorDocumento(intIdDocumento)
            Dim SubNodesSin As TreeNodeAdv = New TreeNodeAdv()
            SubNodesSin.TextColor = Color.DimGray
            SubNodesSin.Font = New Font("Segoe UI Light", 8)
            SubNodesSin.Text = "Asiento Nro. " & conteo
            SubNodesSin.Tag = CInt(i.idAsiento)
            'Label2.Text = "OTRO"
            node.Nodes.Add(SubNodesSin)
            conteo += 1
        Next
    End Sub

    'Sub MostrarAstMenu(intIdDocumento As Integer, node As TreeNodeAdv)
    '    Dim asientoSA As New documentoLibroDiarioSA
    '    Dim conteo As Integer = 1
    '    For Each i In asientoSA.UbicarPorDocumento(intIdDocumento)
    '        Dim SubNodesSin As TreeNodeAdv = New TreeNodeAdv()
    '        SubNodesSin.TextColor = Color.DimGray
    '        SubNodesSin.Font = New Font("Segoe UI Light", 8)
    '        SubNodesSin.Text = "Asiento Nro. " & conteo
    '        SubNodesSin.Tag = CInt(i.idDocumento)
    '        Label2.Text = "LIBRO"
    '        node.Nodes.Add(SubNodesSin)
    '        conteo += 1
    '    Next
    'End Sub


    Private Sub ListarDetalleCuenta(Anio As String, Mes As String, cuenta As String, r As Record)
        Dim compraSA As New HojaTrabajoFinalRPTSA

        Dim dt As New DataTable("Detalle")
        dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("debe", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("haber", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("debeme", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("hamerme", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("iddoc", GetType(Integer)))
        dt.Columns.Add(New DataColumn("codLibro", GetType(String)))
        dt.Columns.Add(New DataColumn("operacion", GetType(String)))

        If CDec(r.GetValue("debe")) > 0 Then
            Dim dr0 As DataRow = dt.NewRow()
            dr0(0) = r.GetValue("cuenta")
            dr0(1) = r.GetValue("nomCuenta")
            dr0(2) = CDec(r.GetValue("debe")).ToString("N2")
            dr0(3) = 0
            dr0(4) = 0
            dr0(5) = 0
            dt.Rows.Add(dr0)
        ElseIf CDec(r.GetValue("haber")) > 0 Then
            Dim dr0 As DataRow = dt.NewRow()
            dr0(0) = r.GetValue("cuenta")
            dr0(1) = r.GetValue("nomCuenta")
            dr0(2) = 0
            dr0(3) = CDec(r.GetValue("haber")).ToString("N2")
            dr0(4) = 0
            dr0(5) = 0
            dt.Rows.Add(dr0)
        End If

        For Each i As movimiento In compraSA.ListarDetallexCuenta(Anio, Mes, cuenta)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.cuenta
            dr(1) = i.descripcion
            If i.tipo = "H" Then
                dr(2) = CDec(0.0).ToString("N2")
                dr(3) = CDec(i.monto).ToString("N2")
                dr(4) = CDec(0.0).ToString("N2")
                dr(5) = CDec(i.montoUSD).ToString("N2")
                dr(6) = i.glosa
                dr(7) = i.idDocumentoRef
                dr(8) = i.codigoLibro
                dr(9) = i.tipoOperacion
            ElseIf i.tipo = "D" Then
                dr(2) = CDec(i.monto).ToString("N2")
                dr(3) = CDec(0.0).ToString("N2")
                dr(4) = CDec(i.montoUSD).ToString("N2")
                dr(5) = CDec(0.0).ToString("N2")
                dr(6) = i.glosa
                dr(7) = i.idDocumentoRef
                dr(8) = i.codigoLibro
                dr(9) = i.tipoOperacion
            End If
            dt.Rows.Add(dr)
        Next
        dgvCuentaDetalle.DataSource = dt

    End Sub
#End Region

#Region "GRId"
    Private Sub Settings()
        card.ShowCardCellBorders = If(checkBox1.Checked, True, False)
        card.ApplyRoundedCorner = If(checkBox3.Checked, True, False)
        card.BrowseOnly = If(checkBox4.Checked, True, False)
        card.ShowCaption = If(checkBox2.Checked, True, False)
        AutoFit()
    End Sub

    Private Sub AutoFit()
        Me.GDBSource.Model.ColWidths.ResizeToFit(GridRangeInfo.Table())
        Me.GDBSource.Refresh()
    End Sub
#End Region

    Public Sub New(anio As String, mes As String, cuenta As String, r As Record)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Me.dgvCuentaDetalle.TableDescriptor.Appearance.AnyRecordFieldCell.MergeCell = GridMergeCellDirection.Both
        '' Set merge cells behavior for the Grid
        'Me.dgvCuentaDetalle.TableModel.Options.MergeCellsMode = GridMergeCellsMode.OnDemandCalculation Or GridMergeCellsMode.MergeColumnsInRow Or GridMergeCellsMode.MergeRowsInColumn


        'Me.dgvCuentaDetalle.TableDescriptor.Columns("glosa").Appearance.AnyRecordFieldCell.MergeCell = GridMergeCellDirection.Both
        'Me.dgvCuentaDetalle.TableModel.Options.MergeCellsMode = GridMergeCellsMode.OnDemandCalculation
        ''Sets the range of cells.
        'Me.dgvCuentaDetalle.TableModel.Options.MergeCellsLayout = GridMergeCellsLayout.Grid

        'Me.dgvCuentaDetalle.TableModel.MergeCells.DelayMergeCells(GridRangeInfo.Rows(, 5))

        GridCFG(dgvCuentaDetalle)
        GridCFG(GridGroupingControl1)
        ListarDetalleCuenta(anio, mes, cuenta, r)
        Me.WindowState = FormWindowState.Maximized


        'AddHandler dgvCuentaDetalle.TableModel.QueryCanMergeCells, AddressOf TableModel_QueryCanMergeCells
    End Sub

    Private Sub frmHojaTrabajoDetalle_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmHojaTrabajoDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.GDBSource.Model.RowHeights.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells)
        'Existing code to set merge cells.
        'Me.dgvCuentaDetalle.TableDescriptor.Columns("glosa").Appearance.AnyRecordFieldCell.MergeCell = GridMergeCellDirection.Both
        'Me.dgvCuentaDetalle.TableModel.Options.MergeCellsMode = GridMergeCellsMode.OnDemandCalculation Or GridMergeCellsMode.MergeColumnsInRow Or GridMergeCellsMode.MergeRowsInColumn
        Me.dgvCuentaDetalle.ContextMenu = Me.ContextMenu1
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub dgvCuentaDetalle_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCuentaDetalle.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        treeViewAdv2.Nodes.Clear()

        Select Case dgvCuentaDetalle.Table.CurrentRecord.GetValue("codLibro")
            Case "8"
                Dim NewNode As TreeNodeAdv = New TreeNodeAdv()
                NewNode.Text = "REGISTRO DE COMPRA"
                NewNode.TextColor = Color.FromKnownColor(KnownColor.HotTrack)
                NewNode.Tag = CInt(dgvCuentaDetalle.Table.CurrentRecord.GetValue("iddoc"))
                NewNode.Font = New Font("Segoe UI Light", 8)
                treeViewAdv2.Nodes.Add(NewNode)
                MostrarAsientosMenu(CInt(dgvCuentaDetalle.Table.CurrentRecord.GetValue("iddoc")), NewNode)
                MostrarComprobanteOrigen("8", CInt(dgvCuentaDetalle.Table.CurrentRecord.GetValue("iddoc")))
            Case "1"
                Dim NewNode As TreeNodeAdv = New TreeNodeAdv()
                NewNode.Text = "CAJA Y BANCOS"
                NewNode.TextColor = Color.FromKnownColor(KnownColor.HotTrack)
                NewNode.Font = New Font("Segoe UI Light", 8)
                treeViewAdv2.Nodes.Add(NewNode)
                MostrarAsientosMenu(CInt(dgvCuentaDetalle.Table.CurrentRecord.GetValue("iddoc")), NewNode)
                MostrarComprobanteOrigen("1", CInt(dgvCuentaDetalle.Table.CurrentRecord.GetValue("iddoc")))

            Case "5"
                Dim NewNode As TreeNodeAdv = New TreeNodeAdv()
                NewNode.Text = "LIBRO DIARIO"
                NewNode.TextColor = Color.FromKnownColor(KnownColor.HotTrack)
                NewNode.Font = New Font("Segoe UI Light", 8)
                treeViewAdv2.Nodes.Add(NewNode)
                MostrarAsientosMenu(CInt(dgvCuentaDetalle.Table.CurrentRecord.GetValue("iddoc")), NewNode)

                Select Case dgvCuentaDetalle.Table.CurrentRecord.GetValue("operacion")
                    Case "17" ' APORTE
                        MostrarComprobanteOrigen("5", CInt(dgvCuentaDetalle.Table.CurrentRecord.GetValue("iddoc")), "17")
                    Case Else 'ASIENTO MANUALES
                        MostrarComprobanteOrigen("5", CInt(dgvCuentaDetalle.Table.CurrentRecord.GetValue("iddoc")))
                End Select

            Case "14"
                Dim NewNode As TreeNodeAdv = New TreeNodeAdv()
                NewNode.Text = "REGISTRO DE VENTAS E INGRESOS"
                NewNode.TextColor = Color.FromKnownColor(KnownColor.HotTrack)
                NewNode.Font = New Font("Segoe UI Light", 8)
                treeViewAdv2.Nodes.Add(NewNode)
                MostrarAsientosMenu(CInt(dgvCuentaDetalle.Table.CurrentRecord.GetValue("iddoc")), NewNode)
                MostrarComprobanteOrigen("14", CInt(dgvCuentaDetalle.Table.CurrentRecord.GetValue("iddoc")))



            Case "13"
                Dim NewNode As TreeNodeAdv = New TreeNodeAdv()
                NewNode.Text = "REGISTRO DE INVENTARIO PERMANENTE VALORIZADO"
                NewNode.TextColor = Color.FromKnownColor(KnownColor.HotTrack)
                NewNode.Font = New Font("Segoe UI Light", 8)
                treeViewAdv2.Nodes.Add(NewNode)
                MostrarAsientosMenu(CInt(dgvCuentaDetalle.Table.CurrentRecord.GetValue("iddoc")), NewNode)
                MostrarComprobanteOrigen("13", CInt(dgvCuentaDetalle.Table.CurrentRecord.GetValue("iddoc")))

        End Select
        treeViewAdv2.ExpandAll()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TableModel_QueryCanMergeCells(ByVal sender As Object, ByVal e As GridQueryCanMergeCellsEventArgs)
        ' Checking whether it is already merged cells
        If Not e.Result Then
            ' Sets merging for two columns with different data
            If e.Style1.CellIdentity.ColIndex = 1 AndAlso e.Style2.CellIdentity.ColIndex = 2 Then
                e.Result = True
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub MenuItem1_Click(sender As Object, e As EventArgs) Handles MenuItem1.Click
        treeViewAdv2.Nodes.Clear()

        Select Case dgvCuentaDetalle.Table.CurrentRecord.GetValue("codLibro")
            Case "8"
                Dim NewNode As TreeNodeAdv = New TreeNodeAdv()
                NewNode.Text = "REGISTRO DE COMPRA"
                NewNode.TextColor = Color.FromKnownColor(KnownColor.HotTrack)
                NewNode.Tag = CInt(dgvCuentaDetalle.Table.CurrentRecord.GetValue("iddoc"))
                NewNode.Font = New Font("Segoe UI Light", 8)
                treeViewAdv2.Nodes.Add(NewNode)
                MostrarAsientosMenu(CInt(dgvCuentaDetalle.Table.CurrentRecord.GetValue("iddoc")), NewNode)
                MostrarComprobanteOrigen("8", CInt(dgvCuentaDetalle.Table.CurrentRecord.GetValue("iddoc")))
            Case "1"
                Dim NewNode As TreeNodeAdv = New TreeNodeAdv()
                NewNode.Text = "CAJA Y BANCOS"
                NewNode.TextColor = Color.FromKnownColor(KnownColor.HotTrack)
                NewNode.Font = New Font("Segoe UI Light", 8)
                treeViewAdv2.Nodes.Add(NewNode)

            Case "14"
                Dim NewNode As TreeNodeAdv = New TreeNodeAdv()
                NewNode.Text = "REGISTRO DE VENTA"
                NewNode.TextColor = Color.FromKnownColor(KnownColor.HotTrack)
                NewNode.Font = New Font("Segoe UI Light", 8)
                treeViewAdv2.Nodes.Add(NewNode)

        End Select
    End Sub

    Private Sub dgvCuentaDetalle_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCuentaDetalle.TableControlCellDoubleClick

    End Sub

    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click
        Me.Cursor = Cursors.WaitCursor

        'If Label2.Text = "LIBRO" Then
        ' MostrarAsientoLibro(treeViewAdv2.SelectedNode.Tag)
        'ElseIf Label2.Text = "OTRO" Then

        MostrarAsiento(treeViewAdv2.SelectedNode.Tag)
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub treeViewAdv2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles treeViewAdv2.MouseDoubleClick

    End Sub

    Private Sub MostrarComprobanteOrigen(caso As String, intIdDocumento As Integer, Optional CasoLibroDiario As String = Nothing)
        Select Case caso
            Case "8"
                CompraDefault(intIdDocumento)
            Case "1"

            Case "5"
                If CasoLibroDiario = "17" Then
                    AporteDefault(intIdDocumento)
                Else
                    AsientoManualDefault(intIdDocumento)
                End If

            Case "14"
                VentaDefault(intIdDocumento)


            Case "13"
                OtroDefault(intIdDocumento)

        End Select
    End Sub

    Sub AporteDefault(intIdDocumento As Integer)
        Dim compraSA As New saldoInicioSA
        Dim otrosSA As New saldoInicioSA
        Dim otros As New saldoInicio
        Dim entidadSA As New entidadSA

        Dim dt As New DataTable()
        dt.Columns.Add("Movimiento")
        dt.Columns.Add("fechaDoc")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("NroDoc")
        dt.Columns.Add("entidad")
        dt.Columns.Add("moneda")
        dt.Columns.Add("tipoCambio")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")
        dt.Columns.Add("destino")
        'dt.Columns.Add("otros")

        With compraSA.UbicarSaldoXidDocumento(intIdDocumento)

            Dim dr As DataRow = dt.NewRow()
            dr(0) = "VOUCHER CONTABLE"
            dr(1) = .fechaDoc
            dr(2) = .tipoDoc
            dr(3) = .serie & "-" & .numeroDoc
            'dr(4) = entidadSA.UbicarEntidadPorID(.idProveedor).FirstOrDefault.nombreCompleto
            dr(4) = ""

            If .monedaDoc = "1" Then
                dr(5) = "NACIONAL"
            ElseIf .monedaDoc = "2" Then
                dr(5) = "EXTRANJERA"
            End If

            dr(6) = .tcDolLoc
            dr(7) = .importeTotal
            dr(8) = .importeUS
            dr(9) = IIf(.destino = "IC", "Incremento capital", "Saldo de inicio")
            dt.Rows.Add(dr)


        End With
        GDBSource.DataSource = dt
        Me.GDBSource.BackColor = Color.White


        card.CaptionField = "Movimiento"
        card.CardSpacingWidth = 10
        card.CardSpacingHeight = 10
        card.MaxCardCols = 5
        card.CaptionHeight = 35
        card.CardBackColor = Color.Lavender
        card.WireGrid(Me.GDBSource)

        Settings()
    End Sub

    Sub AsientoManualDefault(intIdDocumento As Integer)
        Dim compraSA As New documentoLibroDiarioSA
        Dim otrosSA As New documentoLibroDiarioSA
        Dim otros As New documentoLibroDiario
        Dim entidadSA As New entidadSA

        Dim dt As New DataTable()
        dt.Columns.Add("Movimiento")
        dt.Columns.Add("fechaDoc")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("NroDoc")
        dt.Columns.Add("entidad")
        dt.Columns.Add("moneda")
        dt.Columns.Add("tipoCambio")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")
        dt.Columns.Add("destino")
        'dt.Columns.Add("otros")

        With compraSA.UbicarDocumentoLibroDiario(intIdDocumento)

            Dim dr As DataRow = dt.NewRow()
            dr(0) = "VOUCHER CONTABLE"
            dr(1) = .fecha
            dr(2) = .tipoDoc
            dr(3) = .nroDoc
            'dr(4) = entidadSA.UbicarEntidadPorID(.idProveedor).FirstOrDefault.nombreCompleto
            dr(4) = ""

            If .moneda = "1" Then
                dr(5) = "NACIONAL"
            ElseIf .moneda = "2" Then
                dr(5) = "EXTRANJERA"
            End If

            dr(6) = .tipoCambio
            dr(7) = .importeMN
            dr(8) = .importeME
            dr(9) = String.Empty
            dt.Rows.Add(dr)


        End With
        GDBSource.DataSource = dt
        Me.GDBSource.BackColor = Color.White


        card.CaptionField = "Movimiento"
        card.CardSpacingWidth = 10
        card.CardSpacingHeight = 10
        card.MaxCardCols = 5
        card.CaptionHeight = 35
        card.CardBackColor = Color.Lavender
        card.WireGrid(Me.GDBSource)

        Settings()
    End Sub



    Sub OtroDefault(intIdDocumento As Integer)
        Dim compraSA As New DocumentoCompraSA
        Dim otrosSA As New DocumentoCompraSA
        Dim otros As New documentocompra
        Dim entidadSA As New entidadSA

        Dim dt As New DataTable()
        dt.Columns.Add("Movimiento")
        dt.Columns.Add("fechaDoc")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("NroDoc")
        dt.Columns.Add("entidad")
        dt.Columns.Add("moneda")
        dt.Columns.Add("tipoCambio")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")
        dt.Columns.Add("destino")
        'dt.Columns.Add("otros")

        With compraSA.UbicarDocumentoCompra(intIdDocumento)

            Dim dr As DataRow = dt.NewRow()
            dr(0) = "GUIA DE REMISION - REMITENTE"
            dr(1) = .fechaDoc
            dr(2) = .tipoDoc
            dr(3) = .serie & "-" & .numeroDoc
            dr(4) = entidadSA.UbicarEntidadPorID(.idProveedor).FirstOrDefault.nombreCompleto
            dr(5) = .monedaDoc
            dr(6) = .tcDolLoc
            dr(7) = .importeTotal
            dr(8) = .importeUS
            dr(9) = String.Empty
            dt.Rows.Add(dr)


        End With
        GDBSource.DataSource = dt
        Me.GDBSource.BackColor = Color.White


        card.CaptionField = "Movimiento"
        card.CardSpacingWidth = 10
        card.CardSpacingHeight = 10
        card.MaxCardCols = 5
        card.CaptionHeight = 35
        card.CardBackColor = Color.Lavender
        card.WireGrid(Me.GDBSource)

        Settings()
    End Sub



    Sub CompraDefault(intIdDocumento As Integer)
        Dim compraSA As New DocumentoCompraSA
        Dim otrosSA As New DocumentoCompraSA
        Dim otros As New documentocompra
        Dim entidadSA As New entidadSA

        Dim dt As New DataTable()
        dt.Columns.Add("Movimiento")
        dt.Columns.Add("fechaDoc")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("NroDoc")
        dt.Columns.Add("entidad")
        dt.Columns.Add("moneda")
        dt.Columns.Add("tipoCambio")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")
        dt.Columns.Add("destino")
        'dt.Columns.Add("otros")

        With compraSA.UbicarDocumentoCompra(intIdDocumento)

            Select Case .tipoCompra
                Case TIPO_COMPRA.COMPRA
                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = "COMPRA GENERAL"
                    dr(1) = .fechaDoc
                    dr(2) = .tipoDoc
                    dr(3) = .serie & "-" & .numeroDoc
                    dr(4) = entidadSA.UbicarEntidadPorID(.idProveedor).FirstOrDefault.nombreCompleto
                    dr(5) = .monedaDoc
                    dr(6) = .tcDolLoc
                    dr(7) = .importeTotal
                    dr(8) = .importeUS
                    dr(9) = String.Empty
                    dt.Rows.Add(dr)

                Case TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO
                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = "SERVICIOS PUBLICOS"
                    dr(1) = .fechaDoc
                    dr(2) = .tipoDoc
                    dr(3) = .serie & "-" & .numeroDoc
                    dr(4) = entidadSA.UbicarEntidadPorID(.idProveedor).FirstOrDefault.nombreCompleto
                    dr(5) = .monedaDoc
                    dr(6) = .tcDolLoc
                    dr(7) = .importeTotal
                    dr(8) = .importeUS
                    dr(9) = String.Empty
                    dt.Rows.Add(dr)

                Case TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS
                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = "RECIBO POR HONORARIOS"
                    dr(1) = .fechaDoc
                    dr(2) = .tipoDoc
                    dr(3) = .serie & "-" & .numeroDoc
                    dr(4) = entidadSA.UbicarEntidadPorID(.idProveedor).FirstOrDefault.nombreCompleto
                    dr(5) = .monedaDoc
                    dr(6) = .tcDolLoc
                    dr(7) = .importeTotal
                    dr(8) = .importeUS
                    dr(9) = String.Empty
                    dt.Rows.Add(dr)

                Case TIPO_COMPRA.NOTA_CREDITO
                    otros = otrosSA.UbicarDocumentoCompra(.idPadre)

                    If Not IsNothing(otros) Then
                        Dim dr1 As DataRow = dt.NewRow()
                        dr1(0) = "COMPRA"
                        dr1(1) = otros.fechaDoc
                        dr1(2) = otros.tipoDoc
                        dr1(3) = otros.serie & "-" & otros.numeroDoc
                        dr1(4) = entidadSA.UbicarEntidadPorID(otros.idProveedor).FirstOrDefault.nombreCompleto
                        dr1(5) = otros.monedaDoc
                        dr1(6) = otros.tcDolLoc
                        dr1(7) = otros.importeTotal
                        dr1(8) = otros.importeUS
                        dr1(9) = String.Empty
                        dt.Rows.Add(dr1)
                    End If

                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = "NOTA DE CREDITO"
                    dr(1) = .fechaDoc
                    dr(2) = .tipoDoc
                    dr(3) = .serie & "-" & .numeroDoc
                    dr(4) = entidadSA.UbicarEntidadPorID(.idProveedor).FirstOrDefault.nombreCompleto
                    dr(5) = .monedaDoc
                    dr(6) = .tcDolLoc
                    dr(7) = .importeTotal
                    dr(8) = .importeUS
                    dr(9) = String.Empty
                    dt.Rows.Add(dr)

                Case TIPO_COMPRA.NOTA_DEBITO

                    otros = otrosSA.UbicarDocumentoCompra(.idPadre)

                    If Not IsNothing(otros) Then
                        Dim dr1 As DataRow = dt.NewRow()
                        dr1(0) = "COMPRA"
                        dr1(1) = otros.fechaDoc
                        dr1(2) = otros.tipoDoc
                        dr1(3) = otros.serie & "-" & otros.numeroDoc
                        dr1(4) = entidadSA.UbicarEntidadPorID(otros.idProveedor).FirstOrDefault.nombreCompleto
                        dr1(5) = otros.monedaDoc
                        dr1(6) = otros.tcDolLoc
                        dr1(7) = otros.importeTotal
                        dr1(8) = otros.importeUS
                        dr1(9) = String.Empty
                        dt.Rows.Add(dr1)
                    End If

                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = "NOTA DE DEBITO"
                    dr(1) = .fechaDoc
                    dr(2) = .tipoDoc
                    dr(3) = .serie & "-" & .numeroDoc
                    dr(4) = entidadSA.UbicarEntidadPorID(.idProveedor).FirstOrDefault.nombreCompleto
                    dr(5) = .monedaDoc
                    dr(6) = .tcDolLoc
                    dr(7) = .importeTotal
                    dr(8) = .importeUS
                    dr(9) = String.Empty
                    dt.Rows.Add(dr)

            End Select


        End With
        GDBSource.DataSource = dt
        Me.GDBSource.BackColor = Color.White


        card.CaptionField = "Movimiento"
        card.CardSpacingWidth = 10
        card.CardSpacingHeight = 10
        card.MaxCardCols = 5
        card.CaptionHeight = 35
        card.CardBackColor = Color.Lavender
        card.WireGrid(Me.GDBSource)

        Settings()
    End Sub

    Sub VentaDefault(intIdDocumento As Integer)
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim otrosSA As New documentoVentaAbarrotesSA
        Dim otros As New documentoventaAbarrotes
        Dim entidadSA As New entidadSA

        Dim dt As New DataTable()
        dt.Columns.Add("Movimiento")
        dt.Columns.Add("fechaDoc")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("NroDoc")
        dt.Columns.Add("entidad")
        dt.Columns.Add("moneda")
        dt.Columns.Add("tipoCambio")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")
        dt.Columns.Add("destino")

        With ventaSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)

            Select Case .tipoVenta
                Case TIPO_VENTA.VENTA_GENERAL
                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = "VENTA GENERAL"
                    dr(1) = .fechaDoc
                    dr(2) = .tipoDocumento
                    dr(3) = .serie & "-" & .numeroDoc
                    dr(4) = entidadSA.UbicarEntidadPorID(.idCliente).FirstOrDefault.nombreCompleto
                    dr(5) = .moneda
                    dr(6) = .tipoCambio
                    dr(7) = .ImporteNacional
                    dr(8) = .ImporteExtranjero
                    dr(9) = String.Empty
                    dt.Rows.Add(dr)
                Case TIPO_VENTA.VENTA_AL_TICKET

                Case TIPO_COMPRA.NOTA_CREDITO
                    otros = otrosSA.GetUbicar_documentoventaAbarrotesPorID(.idPadre)

                    If Not IsNothing(otros) Then
                        Dim dr1 As DataRow = dt.NewRow()
                        dr1(0) = "VENTA"
                        dr1(1) = otros.fechaDoc
                        dr1(2) = otros.tipoDocumento
                        dr1(3) = otros.serie & "-" & .numeroDoc
                        dr1(4) = entidadSA.UbicarEntidadPorID(otros.idCliente).FirstOrDefault.nombreCompleto
                        dr1(5) = otros.moneda
                        dr1(6) = otros.tipoCambio
                        dr1(7) = otros.ImporteNacional
                        dr1(8) = otros.ImporteExtranjero
                        dr1(9) = String.Empty
                        dt.Rows.Add(dr1)
                    End If

                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = "NOTA DE CREDITO"
                    dr(1) = .fechaDoc
                    dr(2) = .tipoDocumento
                    dr(3) = .serie & "-" & .numeroDoc
                    dr(4) = entidadSA.UbicarEntidadPorID(.idCliente).FirstOrDefault.nombreCompleto
                    dr(5) = .moneda
                    dr(6) = .tipoCambio
                    dr(7) = .ImporteNacional
                    dr(8) = .ImporteExtranjero
                    dr(9) = String.Empty
                    dt.Rows.Add(dr)

                Case TIPO_COMPRA.NOTA_DEBITO

                    otros = otrosSA.GetUbicar_documentoventaAbarrotesPorID(.idPadre)

                    If Not IsNothing(otros) Then
                        Dim dr1 As DataRow = dt.NewRow()
                        dr1(0) = "VENTA"
                        dr1(1) = otros.fechaDoc
                        dr1(2) = otros.tipoDocumento
                        dr1(3) = otros.serie & "-" & .numeroDoc
                        dr1(4) = entidadSA.UbicarEntidadPorID(otros.idCliente).FirstOrDefault.nombreCompleto
                        dr1(5) = otros.moneda
                        dr1(6) = otros.tipoCambio
                        dr1(7) = otros.ImporteNacional
                        dr1(8) = otros.ImporteExtranjero
                        dr1(9) = String.Empty
                        dt.Rows.Add(dr1)
                    End If

                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = "NOTA DE DEBITO"
                    dr(1) = .fechaDoc
                    dr(2) = .tipoDocumento
                    dr(3) = .serie & "-" & .numeroDoc
                    dr(4) = entidadSA.UbicarEntidadPorID(.idCliente).FirstOrDefault.nombreCompleto
                    dr(5) = .moneda
                    dr(6) = .tipoCambio
                    dr(7) = .ImporteNacional
                    dr(8) = .ImporteExtranjero
                    dr(9) = String.Empty
                    dt.Rows.Add(dr)
            End Select

        End With
        GDBSource.DataSource = dt
        Me.GDBSource.BackColor = Color.White


        card.CaptionField = "Movimiento"
        card.CardSpacingWidth = 10
        card.CardSpacingHeight = 10
        card.MaxCardCols = 5
        card.CaptionHeight = 35
        card.CardBackColor = Color.Lavender
        card.WireGrid(Me.GDBSource)

        Settings()
    End Sub

    Private Sub GridGroupingControl1_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridGroupingControl1.TableControlCellClick

    End Sub
End Class