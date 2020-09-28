Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Microsoft
Imports Syncfusion.Grouping
Public Class frmModalCompraEliminacion
    Inherits frmMaster

    Public Property codCompra() As Integer
    Public Sub New(intIdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvCompra)
        GridCFG(GridGroupingControl1)
        GridCFG(GridGroupingControl2)
        UbicarCompraDetalle(intIdDocumento)
        codCompra = intIdDocumento
        'dockingManager1.DockControlInAutoHideMode(PanelNota, Syncfusion.Windows.Forms.Tools.DockingStyle.Top, 246)
        'Me.DockingClientPanel1.AutoScroll = True
        'Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        'dockingManager1.SetDockLabel(PanelNota, "Notas Debito - Credito")
        'dockingManager1.CloseEnabled = False
        'ubicarNotasXidDocumentocompra()
    End Sub

#Region "métodos"
    Public Sub EliminarCompraGeneral(IntIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim obj As New documentocompradetalle
        Dim obj2 As New documentocompradetalle
        Dim ListaDetalle As New List(Of documentocompradetalle)

        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim ListaTotales As New List(Of totalesAlmacen)
        Try
            With objDocumento
                .idDocumento = IntIdDocumento
                .fechaProceso = PeriodoGeneral
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .usuarioActualizacion = usuario.IDUsuario
                .fechaProceso = Date.Now
                .tipoDoc = Nothing
                .nroDoc = Nothing ' Me.dgvCompras.Table.CurrentRecord.GetValue("serie") + "-" + Me.dgvCompras.Table.CurrentRecord.GetValue("numeroDoc")
                .tipoOperacion = 2
                .fechaActualizacion = Date.Now
            End With

            '     Dim compra As New documentocompra With
            '    {.idEmpresa = Gempresas.IdEmpresaRuc,
            '     .idCentroCosto = GEstableciento.IdEstablecimiento}

            'objDocumento.documentocompra = compra

            'For Each i In dgvCompra.Table.Records
            '    obj = New documentocompradetalle

            '    obj = documentoDetalleSA.GetUbicar_documentocompradetallePorID(i.GetValue("sec"))

            '    obj2 = New documentocompradetalle
            '    obj2.idItem = i.GetValue("iditem")
            '    obj2.destino = obj.destino
            '    obj2.descripcionItem = obj.destino
            '    obj2.unidad1 = obj.unidad1
            '    obj2.tipoExistencia = obj.tipoExistencia
            '    obj2.almacenRef = CInt(i.GetValue("idalmacen"))
            '    obj2.monto1 = CDec(i.GetValue("cantidad"))
            '    obj2.montokardex = CDec(i.GetValue("importe"))
            '    obj2.montokardexUS = CDec(i.GetValue("importeUS"))
            '    ListaDetalle.Add(obj2)
            'Next
            ' objDocumento.documentocompra.documentocompradetalle = ListaDetalle

            documentoSA.EliminarCompraGeneral(objDocumento)
            Me.Tag = "Eliminado"
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message)
        End Try
    End Sub


    Sub GridCFG(GGC As GridGroupingControl)
        Dim colorx As New GridMetroColors()

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

    Sub UbicarCompraDetalle(intIdDocumento As Integer)
        Dim compraSA As New DocumentoCompraDetalleSA
        Dim dt As New DataTable()
        dt.Columns.Add("iddoc")
        dt.Columns.Add("iditem")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("importe")
        dt.Columns.Add("importeUS")
        dt.Columns.Add("idalmacen")
        dt.Columns.Add("almacen")
        dt.Columns.Add("canDisponible")
        dt.Columns.Add("FecIngAlmacen")
        dt.Columns.Add("notas")
        dt.Columns.Add("pagos")
        dt.Columns.Add("venta")
        dt.Columns.Add("tipoEx")
        dt.Columns.Add("sec")

        For Each i In compraSA.SP_UbicarDetalleCompraControl(intIdDocumento)
            Dim dr As DataRow = dt.NewRow
            dr(0) = intIdDocumento
            dr(1) = i.idItem
            dr(2) = i.descripcionItem
            dr(3) = i.monto1
            dr(4) = i.importe
            dr(5) = i.importeUS
            dr(6) = i.almacenRef
            dr(7) = i.NomAlmacen
            dr(8) = i.CantidadDisponible
            dr(9) = i.fechaEntrega
            dr(10) = i.NumNotas
            dr(11) = i.NumPagos
            dr(12) = i.UltimaVenta
            dr(13) = i.tipoExistencia
            dr(14) = i.secuencia
            dt.Rows.Add(dr)
        Next
        dgvCompra.DataSource = dt
    End Sub

    Sub ubicarNotasXidDocumentocompra()
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable()
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("importe")
        dt.Columns.Add("importeUS")
        For Each i In compraSA.ListarNotasXidCompra(codCompra)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.fechaDoc
            dr(2) = i.tipoDoc
            dr(3) = i.serie
            dr(4) = i.numeroDoc
            dr(5) = i.importeTotal
            dr(6) = i.importeUS
            dt.Rows.Add(dr)
        Next
        GridGroupingControl1.DataSource = dt
    End Sub

    'Sub UbicarAsientosXfecha()
    '    Dim r As Record = dgvCompra.Table.CurrentRecord
    '    Dim movimientoSA As New MovimientoSA
    '    Dim dt As New DataTable()
    '    dt.Columns.Add("idAsiento")
    '    dt.Columns.Add("asiento")
    '    dt.Columns.Add("cuenta")
    '    dt.Columns.Add("descripcion")
    '    dt.Columns.Add("tipo")
    '    dt.Columns.Add("monto")
    '    dt.Columns.Add("montoUS")

    '    Dim comteo As Integer = 1
    '    Dim codAsiento As Integer = 0
    '    For Each i In movimientoSA.GetListaVentasXitemVerAsientos(r.GetValue("iditem"), r.GetValue("FecIngAlmacen"))
    '        Dim dr As DataRow = dt.NewRow
    '        dr(0) = i.idAsiento
    '        dr(1) = "Asiento"
    '        dr(2) = i.cuenta
    '        dr(3) = i.descripcion
    '        dr(4) = i.tipo
    '        dr(5) = i.monto
    '        dr(6) = i.montoUSD
    '        dt.Rows.Add(dr)

    '        codAsiento = i.idAsiento
    '    Next
    '    GridGroupingControl2.TableDescriptor.GroupedColumns.Clear()
    '    GridGroupingControl2.TableDescriptor.GroupedColumns.Add("idAsiento")
    '    GridGroupingControl2.DataSource = dt
    'End Sub
#End Region

    Private Sub frmModalCompraEliminacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmModalCompraEliminacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick
        'Me.Cursor = Cursors.WaitCursor
        ''If Not IsNothing(dgvCompra.Table.CurrentRecord) Then
        ''    UbicarAsientosXfecha()
        ''End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        LoadingAnimator.Wire(Me.dgvCompra.TableControl)
        Dim cantDisponible As Double = 0
        Dim cantCompra As Double = 0
        Try
            'For Each i In dgvCompra.Table.Records

            '    If i.GetValue("tipoEx") <> TipoRecurso.SERVICIO Then
            '        cantDisponible = CDbl(i.GetValue("canDisponible"))
            '        cantCompra = CDbl(i.GetValue("cantidad"))

            '        If cantCompra > cantDisponible Then
            '            LoadingAnimator.UnWire(Me.dgvCompra.TableControl)
            '            Throw New Exception("No puede eliminar el item, " & i.GetValue("descripcion") & vbCrLf & "verificar la cantidad disponible!")
            '        End If
            '    End If

            'Next
            EliminarCompraGeneral(codCompra)
            Dispose()
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message)
        End Try
        LoadingAnimator.UnWire(Me.dgvCompra.TableControl)
    End Sub

    Private Sub dgvCompra_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellDoubleClick
        'Dim montoCostoMN As Decimal = 0
        'Dim montoCostoME As Decimal = 0
        'Me.Cursor = Cursors.WaitCursor
        'Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        'Dim f As New frmModalAlmacenStock(CInt(dgvCompra.Table.CurrentRecord.GetValue("iditem")))
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
        'If datos.Count > 0 Then
        '    montoCostoMN = datos(0).Montomn * datos(0).PMmn
        '    montoCostoME = datos(0).Montomn * datos(0).PMme

        '    dgvCompra.Table.CurrentRecord.SetValue("idalmacen", datos(0).ID)
        '    dgvCompra.Table.CurrentRecord.SetValue("almacen", datos(0).NomProceso)
        '    dgvCompra.Table.CurrentRecord.SetValue("canDisponible", datos(0).Montomn)

        '    dgvCompra.Table.CurrentRecord.SetValue("importe", montoCostoMN)
        '    dgvCompra.Table.CurrentRecord.SetValue("importeUS", montoCostoME)
        'End If

        'Me.Cursor = Cursors.Arrow
    End Sub
End Class