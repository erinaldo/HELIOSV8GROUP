Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Public Class frmModalPreciosVenta
    Inherits frmMaster

    Dim colorx As New GridMetroColors()
    Sub GridCFG(grid As GridGroupingControl)
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
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Public Sub New(intIdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvPrecios)
        GridCFG(GridGroupingControl1)
        GridCFG(dgvPreciosConfigurados)
        UbicarDocumento(intIdDocumento)
        ListadoPreciosVenta = New List(Of PreciosConfigurados)
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Dim comboTable As New DataTable
#Region "Métodos"
    Public Sub UbicarDocumento(intIdDocumento As Integer)
        Dim documentoCompraDetalleSA As New DocumentoCompraDetalleSA
        Dim almacenSA As New almacenSA
        Dim x As Integer = 1
        Try
            Dim dt As New DataTable()
            dt.Columns.Add("idAlmacen")
            dt.Columns.Add("nomAlmacen")
            dt.Columns.Add("grav")
            dt.Columns.Add("idItem")
            dt.Columns.Add("item")
            dt.Columns.Add("unidad")
            dt.Columns.Add("valCompraMN")
            dt.Columns.Add("IGVmn")
            dt.Columns.Add("valCompraME")
            dt.Columns.Add("IGVme")
            dt.Columns.Add("id")

            For Each i In documentoCompraDetalleSA.GetUbicar_documentocompradetallePorCompraEx(intIdDocumento)
                Dim dr As DataRow = dt.NewRow
                dr(0) = i.almacenRef
                dr(1) = almacenSA.GetUbicar_almacenPorID(i.almacenRef).descripcionAlmacen
                dr(2) = i.destino
                dr(3) = i.idItem
                dr(4) = i.descripcionItem
                dr(5) = i.unidad1
                dr(6) = i.montokardex
                dr(7) = i.montoIgv
                dr(8) = i.montokardexUS
                dr(9) = i.montoIgvUS
                dr(10) = x
                dt.Rows.Add(dr)
                x = x + 1
            Next
            dgvPrecios.DataSource = dt
            dgvPrecios.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetTablePrecios() As DataTable
        Dim PreciosSA As New ConfiguracionPrecioSA
        Dim dt As New DataTable()
        dt.Columns.Add("idPrecio", GetType(Integer))
        dt.Columns.Add("precio", GetType(String))

        For Each i In PreciosSA.ListadoPrecios()
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idPrecio
            dr(1) = i.precio
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Sub UbicarUltimosPreciosXproducto(r As Record)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(r.GetValue("idAlmacen"), r.GetValue("idItem"))
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.fecha
            dr(1) = i.idPrecio
            dr(2) = i.descripcion
            dr(3) = IIf(i.tipo = "P", "%", "Fijo")
            dr(4) = i.valPorcentaje
            dr(5) = i.precioMN
            dr(6) = i.precioME
            dt.Rows.Add(dr)
        Next
        GridGroupingControl1.DataSource = dt

    End Sub

    Sub Grabar()
        Dim objPrecio As New configuracionPrecioProducto
        Dim ListadoPrecio As New List(Of configuracionPrecioProducto)
        Dim objPrecioSA As New ConfiguracionPrecioProductoSA

        For Each i In ListadoPreciosVenta
            objPrecio = New configuracionPrecioProducto
            objPrecio.idPrecio = i.Movimiento
            objPrecio.idproducto = i.IdProducto
            objPrecio.fecha = DateTime.Now
            objPrecio.tipo = IIf(i.Tipo = "%", "P", "F")
            objPrecio.valPorcentaje = i.ValTipo
            objPrecio.descripcion = i.Movimiento
            objPrecio.precioMN = i.PrecioVentaMN
            objPrecio.precioME = i.PrecioVentaME
            ListadoPrecio.Add(objPrecio)
        Next
        objPrecioSA.GrabarListadoPrecios(ListadoPrecio)
        Dispose()
    End Sub
#End Region

    Private Sub frmModalPreciosVenta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmModalPreciosVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboTable = Me.GetTablePrecios

        Dim ggcStyle As GridTableCellStyleInfo = dgvPreciosConfigurados.TableDescriptor.Columns(1).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = Me.comboTable
        ggcStyle.ValueMember = "idPrecio"
        ggcStyle.DisplayMember = "precio"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive

    End Sub

    Dim ListadoPreciosVenta As New List(Of PreciosConfigurados)

    Public Class PreciosConfigurados



        Public Sub New()

        End Sub
        Property Id() As Integer
        Property IdPadre() As Integer
        Property Movimiento As String
        Property Tipo As String
        Property ValTipo As String
        Property PrecioVentaMN() As Decimal
        Property PrecioVentaME() As Decimal

        Property IdAlmacen() As Integer
        Property IdProducto() As Integer

    End Class

    Sub EliminarPrecio(r As Record)

        Dim obj = (From n In ListadoPreciosVenta _
               Where n.Id = r.GetValue("id")).FirstOrDefault

        ListadoPreciosVenta.Remove(obj)

    End Sub

    Sub LLenarConfigurados(intIdpadre As Integer)
        Dim dt As New DataTable()
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("cboMov", GetType(String))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("valTipo", GetType(String))
        dt.Columns.Add("precioVentaMN", GetType(Decimal))
        dt.Columns.Add("precioVentaME", GetType(Decimal))
        dt.Columns.Add("idPadre", GetType(Integer))

        dt.Columns.Add("idAlmacen", GetType(Integer))
        dt.Columns.Add("idProducto", GetType(Integer))

        Dim consulta = (From n In ListadoPreciosVenta _
                         Where n.IdPadre = intIdpadre).ToList

        Dim x As Integer = 0
        For Each i In consulta
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.Id
            dr(1) = i.Movimiento
            dr(2) = i.Tipo
            dr(3) = i.ValTipo
            dr(4) = i.PrecioVentaMN
            dr(5) = i.PrecioVentaME
            dr(6) = i.IdPadre
            dr(7) = i.IdAlmacen
            dr(8) = i.IdProducto
            x = x + 1
            dt.Rows.Add(dr)
        Next

        dgvPreciosConfigurados.DataSource = dt
    End Sub

    Sub UbicarPrecio(r As Record)
        Dim obj = (From n In ListadoPreciosVenta _
                  Where n.Id = r.GetValue("id")).FirstOrDefault


        obj.Movimiento = r.GetValue("cboMov")
        obj.Tipo = r.GetValue("tipo")
        obj.ValTipo = r.GetValue("valTipo")
        obj.PrecioVentaMN = r.GetValue("precioVentaMN")
        obj.PrecioVentaME = r.GetValue("precioVentaME")

    End Sub

    Function ObtenerSecuencia() As Integer
        Dim codigo As Integer?
        If ListadoPreciosVenta.Count > 0 Then
            codigo = (From n In ListadoPreciosVenta Select n.Id).Max
            Return codigo.GetValueOrDefault
        Else

            Return 0
        End If
    End Function

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        '    If dgvPrecios.Table.SelectedRecords.Count > 0 Then

        Dim objPrecioBE As New PreciosConfigurados
        Try
            objPrecioBE.Id = ObtenerSecuencia() + 1
            objPrecioBE.Movimiento = String.Empty
            objPrecioBE.Tipo = Nothing
            objPrecioBE.PrecioVentaMN = 0
            objPrecioBE.PrecioVentaME = 0
            objPrecioBE.IdPadre = dgvPrecios.Table.CurrentRecord.GetValue("id")

            objPrecioBE.IdAlmacen = dgvPrecios.Table.CurrentRecord.GetValue("idAlmacen")
            objPrecioBE.IdProducto = dgvPrecios.Table.CurrentRecord.GetValue("idItem")

            ListadoPreciosVenta.Add(objPrecioBE)

            LLenarConfigurados(dgvPrecios.Table.CurrentRecord.GetValue("id"))
        Catch ex As Exception

        End Try
        'Else
        'MessageBoxAdv.Show("Debe Seleccionar el precio base!")
        'End If
    End Sub

    Private Sub dgvPreciosConfigurados_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPreciosConfigurados.TableControlCellClick

    End Sub

    Private Sub dgvPreciosConfigurados_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvPreciosConfigurados.TableControlCurrentCellEditingComplete
        Dim precioSA As New ConfiguracionPrecioSA
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Try
            If Not IsNothing(Me.dgvPreciosConfigurados.Table.CurrentRecord) Then
                Select Case ColIndex
                    Case 2
                        With precioSA.EncontrarPrecioXitem(New configuracionPrecio With {.idPrecio = Me.dgvPreciosConfigurados.Table.CurrentRecord.GetValue("cboMov")})
                            Select Case .tipo
                                Case "P"
                                    Me.dgvPreciosConfigurados.Table.CurrentRecord.SetValue("tipo", "%")

                                Case Else
                                    Me.dgvPreciosConfigurados.Table.CurrentRecord.SetValue("tipo", "FIJO")
                            End Select

                            Me.dgvPreciosConfigurados.Table.CurrentRecord.SetValue("valTipo", .tasaPorcentaje)
                        End With
                        UbicarPrecio(Me.dgvPreciosConfigurados.Table.CurrentRecord)

                        Dim montoUti As Decimal = 0
                        Dim montoUtime As Decimal = 0
                        Dim igv As Decimal = 0
                        Dim igvme As Decimal = 0
                        Dim pv As Decimal = 0
                        Dim pvme As Decimal = 0

                        Select Case Me.dgvPreciosConfigurados.Table.CurrentRecord.GetValue("tipo")
                            Case "%"
                                If dgvPrecios.Table.CurrentRecord.GetValue("grav") = 1 Then
                                    montoUti = CDec(dgvPrecios.Table.CurrentRecord.GetValue("valCompraMN")) * (CDec(Me.dgvPreciosConfigurados.Table.CurrentRecord.GetValue("valTipo")) / 100)
                                    montoUti = montoUti + CDec(dgvPrecios.Table.CurrentRecord.GetValue("valCompraMN"))
                                    igv = montoUti * 0.18
                                    pv = montoUti + igv

                                    montoUtime = CDec(dgvPrecios.Table.CurrentRecord.GetValue("valCompraME")) * (CDec(Me.dgvPreciosConfigurados.Table.CurrentRecord.GetValue("valTipo")) / 100)
                                    montoUtime = montoUtime + CDec(dgvPrecios.Table.CurrentRecord.GetValue("valCompraME"))
                                    igvme = montoUtime * 0.18
                                    pvme = montoUtime + igvme

                                    Me.dgvPreciosConfigurados.Table.CurrentRecord.SetValue("precioVentaMN", pv.ToString("N2"))
                                    Me.dgvPreciosConfigurados.Table.CurrentRecord.SetValue("precioVentaME", pvme.ToString("N2"))
                                Else

                                    montoUti = CDec(dgvPrecios.Table.CurrentRecord.GetValue("valCompraMN")) * (CDec(Me.dgvPreciosConfigurados.Table.CurrentRecord.GetValue("valTipo")) / 100)
                                    montoUti = montoUti + CDec(dgvPrecios.Table.CurrentRecord.GetValue("valCompraMN"))
                                    igv = montoUti
                                    pv = montoUti + igv

                                    montoUtime = CDec(dgvPrecios.Table.CurrentRecord.GetValue("valCompraME")) * (CDec(Me.dgvPreciosConfigurados.Table.CurrentRecord.GetValue("valTipo")) / 100)
                                    montoUtime = montoUtime + CDec(dgvPrecios.Table.CurrentRecord.GetValue("valCompraME"))
                                    igvme = montoUtime
                                    pvme = montoUtime + igvme

                                    Me.dgvPreciosConfigurados.Table.CurrentRecord.SetValue("precioVentaMN", pv.ToString("N2"))
                                    Me.dgvPreciosConfigurados.Table.CurrentRecord.SetValue("precioVentaME", pvme.ToString("N2"))
                                End If

                              
                            Case Else

                        End Select

                        UbicarPrecio(Me.dgvPreciosConfigurados.Table.CurrentRecord)
                 
                    Case 5
                        UbicarPrecio(Me.dgvPreciosConfigurados.Table.CurrentRecord)
                    Case 6
                        UbicarPrecio(Me.dgvPreciosConfigurados.Table.CurrentRecord)
                End Select
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvPrecios_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvPrecios.SelectedRecordsChanged
        LLenarConfigurados(dgvPrecios.Table.CurrentRecord.GetValue("id"))
        GridGroupingControl1.Table.Records.DeleteAll()
    End Sub

    Private Sub dgvPrecios_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvPrecios.SelectedRecordsChanging
        'LLenarConfigurados(dgvPrecios.Table.CurrentRecord.GetValue("id"))
        'UbicarUltimosPreciosXproducto(dgvPrecios.Table.CurrentRecord)
    End Sub

    Private Sub dgvPrecios_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPrecios.TableControlCellClick

    End Sub

    Private Sub dgvPrecios_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvPrecios.TableControlCurrentCellControlDoubleClick

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If ListadoPreciosVenta.Count > 0 Then
            EliminarPrecio(dgvPreciosConfigurados.Table.CurrentRecord)
            LLenarConfigurados(dgvPrecios.Table.CurrentRecord.GetValue("id"))
        End If
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.Cursor = Cursors.WaitCursor
        Grabar()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If Not IsNothing(dgvPrecios.Table.CurrentRecord) Then
            UbicarUltimosPreciosXproducto(dgvPrecios.Table.CurrentRecord)
        End If
    End Sub
End Class