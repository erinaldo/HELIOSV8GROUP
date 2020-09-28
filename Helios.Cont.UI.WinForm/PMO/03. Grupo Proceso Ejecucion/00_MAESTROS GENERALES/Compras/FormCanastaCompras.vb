Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormCanastaCompras
    Dim itemSA As New detalleitemsSA
#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.KeyPreview = True
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(GridItems, True, False, 11.5)
        ' OptimizeGridSettings(GridItems)
    End Sub
#End Region

#Region "Methods"
    Private Sub OptimizeGridSettings(ByVal grid As GridGroupingControl)
        grid.CounterLogic = EngineCounters.YAmount
        grid.AllowedOptimizations = EngineOptimizations.DisableCounters Or EngineOptimizations.RecordsAsDisplayElements
        grid.UseDefaultsForFasterDrawing = True
        grid.InvalidateAllWhenListChanged = False
        grid.InsertRemoveBehavior = GridListChangedInsertRemoveBehavior.ScrollWithImmediateUpdate
        grid.UpdateDisplayFrequency = 50
        grid.BlinkTime = 700
        grid.BindToCurrencyManager = False

        If GetType(Object).AssemblyQualifiedName.IndexOf("Version=1") = -1 Then
            grid.AllowSwapDataViewWithDataTableList = True
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            'Case Keys.F7
            '    ToolStripButton1.PerformClick()

            Case Keys.F9
                Me.Hide()

                'Case Keys.F10
                '    ToolStripButton2.PerformClick()

            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function


    ''' <summary>
    ''' Buscar producto por coincidencia
    ''' </summary>
    ''' <param name="empresa"></param>
    ''' <param name="name"></param>
    Private Sub GetItemsContains(empresa As String, tipo As String, name As String)


        Dim productos = itemSA.GetDetalleItemsXEmpresa(empresa, GEstableciento.IdEstablecimiento, tipo, name)
        Dim dt As New DataTable
        With dt.Columns
            .Add("destino")
            .Add("idItem")
            .Add("descripcion")
            .Add("unidad")
            .Add("tipoExistencia")
            .Add("marca")
            .Add("ultimaEntrada")
            .Add("precio")
            .Add("contenido")
        End With

        Dim fechaEntrada As String = String.Empty
        Dim UltimoPrecio As Decimal = 0

        For Each i In productos
            fechaEntrada = String.Empty
            UltimoPrecio = 0
            If i.CustomDetalleCompra IsNot Nothing Then
                If i.CustomDetalleCompra.monto1.GetValueOrDefault > 0 Then

                    If i.CustomDetalleCompra.documentocompra.tipoCompra = TIPO_COMPRA.COMPRA Then
                        Select Case i.CustomDetalleCompra.destino
                            Case 1
                                Dim precioTotalConIva =
                       i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                ' dr(13) = precioTotalSinIva
                                UltimoPrecio = precioTotalConIva
                                fechaEntrada = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                            Case Else

                                Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                '  dr(13) = precioTotalConIva
                                UltimoPrecio = precioTotalConIva
                                fechaEntrada = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                        End Select

                    Else

                        Select Case i.CustomDetalleCompra.destino
                            Case 1
                                Dim precioTotalConIva2 = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                Dim iva = precioTotalConIva2 * 0.18
                                precioTotalConIva2 = Math.Round(iva + precioTotalConIva2, 2)

                                Dim precioTotalConIva =
                       i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                UltimoPrecio = precioTotalConIva2
                                '   dr(14) = precioTotalConIva2 '0 'precioTotalConIva
                                fechaEntrada = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                            Case Else

                                Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                UltimoPrecio = precioTotalConIva
                                ' dr(14) = 0 'precioTotalConIva
                                fechaEntrada = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                        End Select

                    End If

                End If
            End If

            dt.Rows.Add(i.origenProducto, i.codigodetalle, i.descripcionItem, i.unidad1, i.tipoExistencia, i.NomMarca, fechaEntrada, UltimoPrecio, i.composicion)
        Next
        GridItems.DataSource = dt
        GridItems.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GridItems.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left

        GridItems.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GridItems.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GridItems.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GridItems.TableOptions.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#FFE2347A")

    End Sub

    Private Sub GetItems(empresa As String, name As String)
        Dim NuevaDescripcion As String = String.Empty
        Dim delimitadores() As String = {" "}
        Dim vectoraux = name.Split(delimitadores, StringSplitOptions.None)

        'mostrar resultado
        For Each item As String In vectoraux
            NuevaDescripcion += item & "%"
        Next

        Dim productos = itemSA.GetExistenciasByempresaNombreFull(empresa, NuevaDescripcion)
        Dim dt As New DataTable
        With dt.Columns
            .Add("destino")
            .Add("idItem")
            .Add("descripcion")
            .Add("unidad")
            .Add("tipoExistencia")
            .Add("marca")
            .Add("ultimaEntrada")
            .Add("precio")
            .Add("contenido")
        End With

        Dim fechaEntrada As String = String.Empty
        Dim UltimoPrecio As Decimal = 0

        For Each i In productos
            fechaEntrada = String.Empty
            UltimoPrecio = 0
            If i.CustomDetalleCompra IsNot Nothing Then
                If i.CustomDetalleCompra.monto1.GetValueOrDefault > 0 Then

                    If i.CustomDetalleCompra.documentocompra.tipoCompra = TIPO_COMPRA.COMPRA Then
                        Select Case i.CustomDetalleCompra.destino
                            Case 1
                                Dim precioTotalConIva =
                       i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                ' dr(13) = precioTotalSinIva
                                UltimoPrecio = precioTotalConIva
                                fechaEntrada = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                            Case Else

                                Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                '  dr(13) = precioTotalConIva
                                UltimoPrecio = precioTotalConIva
                                fechaEntrada = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                        End Select

                    Else

                        Select Case i.CustomDetalleCompra.destino
                            Case 1
                                Dim precioTotalConIva2 = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                Dim iva = precioTotalConIva2 * 0.18
                                precioTotalConIva2 = Math.Round(iva + precioTotalConIva2, 2)

                                Dim precioTotalConIva =
                       i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                UltimoPrecio = precioTotalConIva2
                                '   dr(14) = precioTotalConIva2 '0 'precioTotalConIva
                                fechaEntrada = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                            Case Else

                                Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                UltimoPrecio = precioTotalConIva
                                ' dr(14) = 0 'precioTotalConIva
                                fechaEntrada = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                        End Select

                    End If

                End If
            End If

            dt.Rows.Add(i.origenProducto, i.codigodetalle, i.descripcionItem, i.unidad1, i.tipoExistencia, i.NomMarca, fechaEntrada, UltimoPrecio, i.composicion)
        Next
        GridItems.DataSource = dt
        GridItems.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GridItems.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left

        GridItems.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GridItems.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GridItems.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GridItems.TableOptions.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#FFE2347A")

    End Sub

    Private Sub GetItems(name As String)
        Dim NuevaDescripcion As String = String.Empty
        Dim delimitadores() As String = {" "}
        Dim dt As New DataTable
        With dt.Columns
            .Add("destino")
            .Add("idItem")
            .Add("descripcion")
            .Add("unidad")
            .Add("tipoExistencia")
            .Add("marca")
        End With

        Dim vectoraux = name.Split(delimitadores, StringSplitOptions.None)

        'mostrar resultado
        For Each item As String In vectoraux
            NuevaDescripcion += item & "%"
        Next

        For Each i In itemSA.GetProductsSistemaByEmpresa(
            New Business.Entity.detalleitems With
            {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .descripcionItem = NuevaDescripcion
            }).Where(Function(o) o.estado = "A").ToList
            dt.Rows.Add(i.origenProducto, i.codigodetalle, i.descripcionItem, i.unidad1, i.tipoExistencia, i.descripcion)
        Next
        GridItems.DataSource = dt
        GridItems.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GridItems.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left

        GridItems.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GridItems.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GridItems.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GridItems.TableOptions.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#FFE2347A")
    End Sub

    Private Sub txtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged

    End Sub

    Private Sub txtFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyDown
        Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtFiltrar.Text.Trim.Length > 2 Then
                Select Case ChFiltro2.Checked
                    Case True
                        GetItemsContains(Gempresas.IdEmpresaRuc, TipoExistencia.Mercaderia, txtFiltrar.Text.Trim)
                    Case False
                        GetItems(Gempresas.IdEmpresaRuc, txtFiltrar.Text.Trim)
                End Select

            End If
        ElseIf e.KeyCode = Keys.Down Then
            If GridItems.Table.Records.Count > 0 Then

                Dim colIndex As Integer = Me.GridItems.TableDescriptor.FieldToColIndex(0)
                Dim rowIndex As Integer = Me.GridItems.Table.Records(0).GetRowIndex()
                Me.GridItems.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                Me.GridItems.Focus()
            End If
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub GridItems_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridItems.TableControlCellClick

    End Sub

    Private Sub GridItems_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridItems.TableControlCellDoubleClick
        If GridItems.Table.SelectedRecords.Count Then

            Dim codigo = GridItems.Table.CurrentRecord.GetValue("idItem")
            Dim obj = itemSA.InvocarProductoID(Integer.Parse(codigo))
            If Not IsNothing(obj) Then
                'Tag = obj.First
                'Close()

                Dim miInterfaz As IExistencias = TryCast(Me.Owner, IExistencias)
                If miInterfaz IsNot Nothing Then miInterfaz.EnviarItem(obj)
                Hide()
            End If
        End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridItems.TableControlCurrentCellKeyDown
        If e.Inner.KeyCode = Keys.Enter Then
            If Me.GridItems.Table.CurrentRecord IsNot Nothing Then
                Dim codigo = GridItems.Table.CurrentRecord.GetValue("idItem")
                Dim obj = itemSA.InvocarProductoID(Integer.Parse(codigo))
                If Not IsNothing(obj) Then
                    'Tag = obj.First
                    'Close()

                    Dim miInterfaz As IExistencias = TryCast(Me.Owner, IExistencias)
                    If miInterfaz IsNot Nothing Then miInterfaz.EnviarItem(obj)
                    Hide()
                End If
            End If
        End If
    End Sub

    Private Sub btnNuevoProd_Click(sender As Object, e As EventArgs) Handles btnNuevoProd.Click
        Dim almacen As New List(Of almacen)
        Dim almacenSA As New almacenSA
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA

        Dim cat As New item
        Dim ITEMSA As New itemSA
        Me.Cursor = Cursors.WaitCursor

        With frmNuevaExistencia
            If txtFiltrar.Text.Trim.Length > 0 Then
                .UCNuenExistencia.txtProductoNew.Text = txtFiltrar.Text.Trim
            End If
            If Gempresas.Regimen = "1" Then
                .UCNuenExistencia.cboIgv.Text = "1 - GRAVADO"
                .UCNuenExistencia.cboIgv.Enabled = True
            Else
                .UCNuenExistencia.cboIgv.Text = "2 - EXONERADO"
                .UCNuenExistencia.cboIgv.Enabled = True
            End If
            .UCNuenExistencia.cboUnidades.Text = "UNIDAD (BIENES)"
            '.UCNuenExistencia.chClasificacion.Checked = False
            .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If txtFiltrar.Text.Trim.Length > 0 Then
                GetItems(txtFiltrar.Text.Trim)
            End If
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub FormCanastaCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormCanastaCompras_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If GridItems.Table.Records.Count > 0 Then
            GridItems.Focus()
            'GridTotales.Table.Records(GridTotales.Table.Records.Count - 1).SetCurrent()
            'GridTotales.Table.Records(GridTotales.Table.Records.Count - 1).BeginEdit()
        End If
    End Sub

    Private Sub FormCanastaCompras_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            GridItems.Table.Records.DeleteAll()
            txtFiltrar.Clear()
            Me.Close()
        End If
    End Sub

    Private Sub FormCanastaCompras_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        txtFiltrar.Select()
    End Sub
#End Region

#Region "Events"

#End Region

#Region "Methods"

#End Region
End Class