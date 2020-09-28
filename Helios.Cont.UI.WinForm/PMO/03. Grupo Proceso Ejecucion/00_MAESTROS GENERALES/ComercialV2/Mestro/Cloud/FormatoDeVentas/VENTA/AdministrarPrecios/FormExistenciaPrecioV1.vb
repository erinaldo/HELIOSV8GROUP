Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms

Public Class FormExistenciaPrecioV1

#Region "Attributes"
    Public listaProductos As List(Of detalleitems)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridBlack(GridProductos, False)
        GridProductos.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        Centrar(Me)
    End Sub


#End Region

#Region "Methods"
    Private Function GetParentTable() As DataTable
        Dim conteo As Integer = 0
        Dim dt As New DataTable("PRODUCTOS")
        dt.Columns.Add("categoria")
        dt.Columns.Add("gravado")
        dt.Columns.Add("idproducto")
        dt.Columns.Add("codigo")
        dt.Columns.Add("producto")
        dt.Columns.Add("unidad")
        dt.Columns.Add("composicion")
        dt.Columns.Add("tipoexistencia")
        dt.Columns.Add("estado")


        For Each i In listaProductos

            If i.detalleitem_equivalencias IsNot Nothing AndAlso i.detalleitem_equivalencias.Count > 0 Then
                dt.Rows.Add(
                    i.idItem,
                    i.origenProducto,
                    i.codigodetalle,
                    i.codigo,
                    i.descripcionItem,
                    i.unidad1,
                    If(i.detalleitem_equivalencias IsNot Nothing, i.detalleitem_equivalencias.FirstOrDefault.detalle, ""),
                    i.tipoExistencia,
                    i.estado
                    )
            Else
                dt.Rows.Add(
                    i.idItem,
                    i.origenProducto,
                    i.codigodetalle,
                    i.codigo,
                    i.descripcionItem,
                    i.unidad1,
                    "",
                    i.tipoExistencia,
                    i.estado
                    )
            End If


            conteo = conteo + 1
        Next
        Return dt
    End Function

    Private Function GetChildParent() As DataTable
        Dim UnidadesComerciales = (From prod In listaProductos
                                   From unidades In prod.detalleitem_equivalencias
                                   Select unidades).ToList


        Dim dt As New DataTable("UNIDADES COMERCIALES")
        dt.Columns.Add("IdEquivalencia")
        dt.Columns.Add("unidad")
        dt.Columns.Add("contenido")
        dt.Columns.Add("estado")
        dt.Columns.Add("idproducto")

        For Each i In UnidadesComerciales
            dt.Rows.Add(i.equivalencia_id, i.unidadComercial, i.contenido_neto, i.estado, i.codigodetalle)
        Next
        Return dt
    End Function

    Private Function GetGrandChildTable() As DataTable
        Dim Catalogos = (From prod In listaProductos
                         From unidades In prod.detalleitem_equivalencias
                         From cata In unidades.detalleitemequivalencia_catalogos
                         Select cata).ToList


        Dim dt As New DataTable("CATALOGO DE PRECIOS")
        dt.Columns.Add("IdCatalogo")
        dt.Columns.Add("catalogo")
        dt.Columns.Add("estado")
        dt.Columns.Add("IdEquivalencia")

        For Each i In Catalogos
            dt.Rows.Add(i.idCatalogo, i.nombre_corto, i.estado, i.equivalencia_id)
        Next
        Return dt
    End Function

    Private Function GetGrandChildTablePrecios() As DataTable
        Dim Precios = (From prod In listaProductos
                       From unidades In prod.detalleitem_equivalencias
                       From cata In unidades.detalleitemequivalencia_catalogos
                       From prec In cata.detalleitemequivalencia_precios
                       Select prec).ToList


        Dim dt As New DataTable("PRECIOS DE VENTA")
        dt.Columns.Add("IdPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("Contado")
        dt.Columns.Add("Credito")
        dt.Columns.Add("IdCatalogo")

        For Each i In Precios
            dt.Rows.Add(i.precio_id, i.precioCode, i.precio.GetValueOrDefault, i.precioCredito.GetValueOrDefault, i.idCatalogo)
        Next
        Return dt
    End Function

    Private Sub GetProductos()
        Dim conteo As Integer = 0
        Dim listaSA As New detalleitemsSA

        listaProductos = listaSA.GetProductosWithEquivalencias(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .descripcionItem = txtFiltrar.Text
                                                          })


        Dim engine As GridEngine = Me.GridProductos.Engine

        Dim dSet As New DataSet
        Dim parentTable As DataTable = GetParentTable()
        Dim childTable As DataTable = GetChildParent()
        Dim grandChildTable As DataTable = GetGrandChildTable()
        Dim grandChildTablePrecio As DataTable = GetGrandChildTablePrecios()
        dSet.Tables.AddRange(New DataTable() {parentTable, childTable, grandChildTable, grandChildTablePrecio})

        Dim parentColumn As DataColumn = parentTable.Columns("idproducto")
        Dim childColumn As DataColumn = childTable.Columns("idproducto")
        dSet.Relations.Add("ParentToChild", parentColumn, childColumn)
        parentColumn = childTable.Columns("IdEquivalencia")
        childColumn = grandChildTable.Columns("IdEquivalencia")
        dSet.Relations.Add("ChildToGrandChild", parentColumn, childColumn)

        parentColumn = grandChildTable.Columns("IdCatalogo")
        childColumn = grandChildTablePrecio.Columns("IdCatalogo")
        dSet.Relations.Add("ChildToGrandChildPrecio", parentColumn, childColumn)

        Me.GridProductos.DataSource = parentTable
        Me.GridProductos.Engine.BindToCurrencyManager = False

        Me.GridProductos.GridVisualStyles = GridVisualStyles.Metro
        Me.GridProductos.GridOfficeScrollBars = OfficeScrollBars.Metro
        Me.GridProductos.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.GridProductos.TopLevelGroupOptions.ShowAddNewRecordAfterDetails = False

        Me.GridProductos.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.GridProductos.NestedTableGroupOptions.ShowAddNewRecordAfterDetails = False

        Me.GridProductos.TopLevelGroupOptions.ShowCaption = False
        Me.GridProductos.TableOptions.ShowTreeLines = True
        Me.GridProductos.TableOptions.TreeLineBorder = New GridBorder(GridBorderStyle.Solid, Color.Red, GridBorderWeight.Thick)
        GridProductos.TableModel.ColWidths.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells)

        'Use the tabledesciptor to set the properties.
        'Sets some parent properties.
        Dim parentTD As GridTableDescriptor = CType(engine.TableDescriptor, GridTableDescriptor)
        'Sets backcolor to the column.
        'parentTD.Columns("ParentName").Appearance.AnyCell.BackColor = Color.LightGoldenrodYellow
        ''Sets width of the column.
        'parentTD.Columns("ParentName").Width = 120
        'Sets some child properties.
        Dim childTD As GridTableDescriptor = parentTD.Relations("ParentToChild").ChildTableDescriptor
        'Sets backcolor to the column.
        childTD.Columns("IdEquivalencia").Width = 0
        childTD.Columns("unidad").Appearance.AnyCell.BackColor = Color.WhiteSmoke
        childTD.Columns("unidad").Appearance.AnyCell.TextColor = Color.Black
        childTD.Columns("contenido").Appearance.AnyCell.BackColor = Color.WhiteSmoke
        childTD.Columns("contenido").Appearance.AnyCell.TextColor = Color.Black

        'Sets width of the column.
        childTD.Columns("unidad").Width = 160
        'Sets some grandchild properties.
        Dim grandChildTD As GridTableDescriptor = childTD.Relations("ChildToGrandChild").ChildTableDescriptor
        'Sets backcolor to the column.
        grandChildTD.Columns("IdCatalogo").Width = 0
        grandChildTD.Columns("catalogo").Appearance.AnyCell.BackColor = Color.FromArgb(193, 120, 25)
        grandChildTD.Columns("catalogo").Appearance.AnyCell.TextColor = Color.White

        grandChildTD.Columns("estado").Appearance.AnyCell.BackColor = Color.FromArgb(193, 120, 25)
        grandChildTD.Columns("estado").Appearance.AnyCell.TextColor = Color.White
        'Sets width of the column.
        grandChildTD.Columns("catalogo").Width = 190
    End Sub
#End Region

#Region "Events"
    Private Sub txtFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                GetProductos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub TxtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged

    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        Dim frmNuevaExistencia As New frmNuevaExistencia
        With frmNuevaExistencia
            If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                .UCNuenExistencia.cboTipoExistencia.Enabled = False
                .UCNuenExistencia.cboUnidades.SelectedIndex = -1
                .UCNuenExistencia.cboUnidades.Enabled = True
            Else

            End If

            If Gempresas.Regimen = "1" Then
                .UCNuenExistencia.cboIgv.Text = "1 - GRAVADO"
                .UCNuenExistencia.cboIgv.Enabled = True
            Else
                .UCNuenExistencia.cboIgv.Text = "2 - EXONERADO"
                .UCNuenExistencia.cboIgv.Enabled = True
            End If
            '.UCNuenExistencia.chClasificacion.Checked = False
            .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
            .UCNuenExistencia.cboUnidades.Text = "UNIDAD (BIENES)"
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        If frmNuevaExistencia.Tag IsNot Nothing Then
            Dim c = CType(frmNuevaExistencia.Tag, detalleitems)
            txtFiltrar.Text = c.descripcionItem
            GetProductos()
        End If
    End Sub

    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs) Handles BunifuThinButton22.Click
        '      Dim r As Record = GridProductos.Table.CurrentRecord
        'Dim NestedTable = r.GetRelatedChildTable

        Dim el As Element = Me.GridProductos.Table.GetInnerMostCurrentElement()

        If TypeOf el Is GridRecord Then
            Dim rex = el.ParentTable.CurrentRecord
            'Dim drv As DataRowView = TryCast(el.GetData(), DataRowView)
            'Console.WriteLine(drv(1))
            'Dim gct As GridChildTable = TryCast(el.ParentChildTable, GridChildTable)
            'Console.WriteLine(gct.ParentTable.FilteredChildTableOrTopLevelGroup.FilteredRecords.Count)
            'Console.WriteLine(gct.ParentTable.FilteredChildTableOrTopLevelGroup.FilteredRecords(0))
        End If


    End Sub

    Private Sub BunifuiOSSwitch1_OnValueChange(sender As Object, e As EventArgs) Handles BunifuiOSSwitch1.OnValueChange

    End Sub
#End Region
End Class