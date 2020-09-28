Imports Syncfusion.Windows.Forms.Tools
Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Chart
Imports Syncfusion.Drawing

Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Public Class frmOrdenProduccionDocumento
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFGDetetail(dgvEntregables)
        GetSubProyectos(ProyectoGeneralSel.idCosto)
    End Sub

#Region "Métodos"
    'Sub GetAvanceCostosProyectos()
    '    Dim costoSA As New recursoCostoSA
    '    Dim costo As New List(Of recursoCostoDetalle)

    '    costo = costoSA.GetSumaTotalByProyecto(New recursoCostoDetalle With {.idCosto = IdSesionProyecto})

    '    If Not IsNothing(costo) Then
    '        For Each i In costo
    '            Select Case i.tipoCosto
    '                Case "PL"
    '                    lblTotalPlaneado.Text = i.montoMN.GetValueOrDefault.ToString("N2")
    '                Case "RL"
    '                    lblTotalEjecutado.Text = i.montoMN.GetValueOrDefault.ToString("N2")
    '            End Select

    '        Next
    '    Else
    '        lblTotalPlaneado.Text = 0
    '        lblTotalEjecutado.Text = 0
    '    End If



    'End Sub

    Public Sub GetLSVProductosEntregados(be As recursoCosto)
        Dim costoSA As New recursoCostoSA
        Dim costo As New List(Of recursoCosto)

        costo = costoSA.GetProductosProducidosEnPlanta(be)

        ListView1.Items.Clear()
        For Each i In costo
            Dim n As New ListViewItem(i.idCosto)
            n.UseItemStyleForSubItems = False
            n.SubItems.Add(i.inicio)
            n.SubItems.Add(i.detalle)
            n.SubItems.Add(i.cantidad)
            Select Case i.status
                Case StatusProductosTerminados.Entregado
                    n.SubItems.Add("Entregado")
                Case StatusProductosTerminados.Erroneo
                    n.SubItems.Add("Erroneo")
                Case StatusProductosTerminados.Observado
                    n.SubItems.Add("Observado")
                Case StatusProductosTerminados.Pendiente
                    n.SubItems.Add("En Planta").ForeColor = Color.Crimson
            End Select
            n.SubItems.Add(i.idCosto)
            n.SubItems.Add(i.codigo)
            n.SubItems.Add(i.EnvioAlmacen)
            ListView1.Items.Add(n)
        Next


    End Sub


    Sub GridCFGDetetail(grid As GridGroupingControl)
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
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub GetEntregablesProceso()
        Dim costoSA As New recursoCostoSA
        Dim costo As New List(Of recursoCosto)

        Dim dt As New DataTable()
        dt.Columns.Add("idcosto")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("entregable")
        dt.Columns.Add("fechaplan")
        dt.Columns.Add("fechareal")
        dt.Columns.Add("recurso")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("importeplan")
        dt.Columns.Add("puplan")
        dt.Columns.Add("cantidadReal")
        dt.Columns.Add("importereal")
        dt.Columns.Add("pureal")
        dt.Columns.Add("difCostoProd")
        dt.Columns.Add("CerrarPresupuesto")
        dt.Columns.Add("iditem")
        Dim conteo As Integer = 1
        If Not IsNothing(cboSubProyecto.SelectedValue) Then

            costo = costoSA.GetOrdenesDeProduccionInfo(New recursoCosto With {.idCosto = cboSubProyecto.SelectedValue, .status = StatusProductosTerminados.Pendiente})
            For Each i In costo
                Dim puReal = 0
                Dim tex As String = Nothing
                Dim pu As Decimal = 0
                If (i.cantidad.GetValueOrDefault) > 0 Then
                    If i.CostoPresupuesto.GetValueOrDefault > 0 Then
                        pu = i.CostoPresupuesto / i.cantidad
                    Else
                        pu = 0
                    End If
                Else
                    pu = 0
                End If

                Select Case i.tipoExistencia
                    Case TipoExistencia.ProductoTerminado
                        tex = "Producto terminado"
                    Case TipoExistencia.SubProductosDesechos
                        tex = "Sub producto"
                End Select

                If i.CantidadReal.GetValueOrDefault > 0 AndAlso i.CostoReal.GetValueOrDefault > 0 Then
                    puReal = i.CostoReal.GetValueOrDefault / i.CantidadReal.GetValueOrDefault
                Else
                    puReal = 0
                End If


                ' i.secuenciaCosto
                dt.Rows.Add(i.idCosto, conteo, i.nombreCosto, i.finaliza.GetValueOrDefault, i.finalizaActual.GetValueOrDefault,
                            tex, i.UnidadMedida, i.cantidad, i.CostoPresupuesto.GetValueOrDefault, pu, i.CantidadReal.GetValueOrDefault, i.CostoReal.GetValueOrDefault, puReal, 0, i.presupuesto, i.codigo) 'i.costoCierre.GetValueOrDefault

                conteo += 1
            Next
            dgvEntregables.DataSource = dt
        End If
    End Sub

    Sub GetEntregablesCulminados(status As String)
        Dim costoSA As New recursoCostoSA
        Dim costo As New List(Of recursoCosto)

        Dim dt As New DataTable()
        dt.Columns.Add("idcosto")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("entregable")
        dt.Columns.Add("fechaplan")
        dt.Columns.Add("fechareal")
        dt.Columns.Add("recurso")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("importeplan")
        dt.Columns.Add("puplan")
        dt.Columns.Add("cantidadReal")
        dt.Columns.Add("importereal")
        dt.Columns.Add("pureal")
        dt.Columns.Add("difCostoProd")
        dt.Columns.Add("CerrarPresupuesto")
        dt.Columns.Add("iditem")
        Dim conteo As Integer = 1
        If Not IsNothing(cboSubProyecto.SelectedValue) Then

            costo = costoSA.GetOrdenesDeProduccionInfo(New recursoCosto With {.idCosto = cboSubProyecto.SelectedValue, .status = status})
            For Each i In costo
                Dim puReal = 0
                Dim tex As String = Nothing
                Dim pu As Decimal = 0
                If (i.cantidad.GetValueOrDefault) > 0 Then
                    If i.CostoPresupuesto.GetValueOrDefault > 0 Then
                        pu = i.CostoPresupuesto / i.cantidad
                    Else
                        pu = 0
                    End If
                Else
                    pu = 0
                End If

                Select Case i.tipoExistencia
                    Case TipoExistencia.ProductoTerminado
                        tex = "Producto terminado"
                    Case TipoExistencia.SubProductosDesechos
                        tex = "Sub producto"
                End Select

                If i.CantidadReal.GetValueOrDefault > 0 AndAlso i.CostoReal.GetValueOrDefault > 0 Then
                    puReal = i.CostoReal.GetValueOrDefault / i.CantidadReal.GetValueOrDefault
                Else
                    puReal = 0
                End If


                ' i.secuenciaCosto
                dt.Rows.Add(i.idCosto, conteo, i.nombreCosto, i.finaliza.GetValueOrDefault, i.finalizaActual.GetValueOrDefault,
                            tex, i.UnidadMedida, i.cantidad, i.CostoPresupuesto.GetValueOrDefault, pu, i.CantidadReal.GetValueOrDefault, i.CostoReal.GetValueOrDefault, puReal, 0, i.presupuesto, i.codigo) 'i.costoCierre.GetValueOrDefault

                conteo += 1
            Next
            dgvEntregables.DataSource = dt
        End If
    End Sub

    Public Sub GetComboCellStatusPresupuesto()
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(1, "Abierto")
        dt.Rows.Add(0, "Cerrado")

        Dim ggcStyle As GridTableCellStyleInfo = dgvEntregables.TableDescriptor.Columns("CerrarPresupuesto").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = dt
        ggcStyle.ValueMember = "id"
        ggcStyle.DisplayMember = "name"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
    End Sub

    Public Sub GetSubProyectos(idProyectoGeneral As Integer)
        Dim dt As New DataTable()
        Dim recursoSA As New recursoCostoSA
        'idCosto
        'nombreCosto
        cboSubProyecto.DisplayMember = "nombreCosto"
        cboSubProyecto.ValueMember = "idCosto"
        cboSubProyecto.DataSource = recursoSA.GetListaProyectosBySubTipo(New recursoCosto With {.tipo = "HC", .idpadre = idProyectoGeneral, .subtipo = TipoCosto.OP_CONTINUA_DE_BIENES,
                                                                                                .status = StatusProductosTerminados.Pendiente})
    End Sub
#End Region

    Private Sub frmOrdenProduccionDocumento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmEntregable
        f.Manipulacion = ENTITY_ACTIONS.INSERT
        f.IdProyecto = cboSubProyecto.SelectedValue
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GetEntregablesProceso()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboSubProyecto_Click(sender As Object, e As EventArgs) Handles cboSubProyecto.Click

    End Sub

    Private Sub cboSubProyecto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubProyecto.SelectedIndexChanged
        Dim costoSA As New recursoCostoSA

        Dim cod = cboSubProyecto.SelectedValue

        If Not IsNothing(cod) Then
            If cod.ToString.Trim.Length > 0 Then
                With costoSA.GetCostoById(New recursoCosto With {.idCosto = Val(cod)})
                    Select Case .status
                        Case CInt(StatusProductosTerminados.Entregado)
                            Label3.Text = "Culminado"
                            Label3.Tag = CInt(StatusProductosTerminados.Entregado)
                        Case CInt(StatusProductosTerminados.Erroneo)
                            Label3.Text = "Erroneo"
                            Label3.Tag = CInt(StatusProductosTerminados.Erroneo)
                        Case CInt(StatusProductosTerminados.Observado)
                            Label3.Text = "Observado"
                            Label3.Tag = CInt(StatusProductosTerminados.Observado)
                        Case CInt(StatusProductosTerminados.Pendiente)
                            Label3.Text = "En Proceso"
                            Label3.Tag = CInt(StatusProductosTerminados.Pendiente)
                    End Select
                End With
            End If
        End If

    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Cursor = Cursors.WaitCursor
        GetSubProyectos(ProyectoGeneralSel.idCosto)
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvEntregables.Table.CurrentRecord) Then

            Dim f As New frmEntregable(Val(dgvEntregables.Table.CurrentRecord.GetValue("idcosto")))
            f.Manipulacion = ENTITY_ACTIONS.UPDATE
            'f.txtEntregable.Tag = Val(dgvEntregables.Table.CurrentRecord.GetValue("idcosto"))
            f.IdProyecto = cboSubProyecto.SelectedValue
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            'GetEntregables()
        Else
            MessageBox.Show("Debe seleccionar un entregable para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.Cursor = Cursors.WaitCursor
        Dim costoSA As New recursoCostoSA

        If Not IsNothing(dgvEntregables.Table.CurrentRecord) Then
            If MessageBox.Show("Desea eliminar el entregable seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                costoSA.EliminarEntregable(New recursoCosto With {.idCosto = Val(dgvEntregables.Table.CurrentRecord.GetValue("idcosto"))})
                dgvEntregables.Table.CurrentRecord.Delete()
            End If
        Else
            MessageBox.Show("Debe seleccionar un entregable para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim costo As New recursoCosto
        Dim costoSA As New recursoCostoSA

        Dim r As Record = dgvEntregables.Table.CurrentRecord
        If Not IsNothing(r) Then

            costo = costoSA.GetCostoById(New recursoCosto With {.idCosto = Val(r.GetValue("idcosto"))})

            Select Case costo.presupuesto
                Case StatusPresupestoProyecto.Abierto
                    MessageBox.Show("Debe cerrar el presupuesto del producto terminado, " & vbCrLf & "para realizar una entrega.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Case StatusPresupestoProyecto.Cerrado
                    Dim f As New frmcrearOrdenProd
                    f.CodigoProducto = costo.codigo
                    f.GetCantidadProducida(New recursoCosto With {.idCosto = Val(r.GetValue("idcosto"))})
                    f.txtActividadActual.Tag = Val(r.GetValue("idcosto"))
                    f.txtActividadActual.Text = r.GetValue("entregable")
                    f.txtPU.DecimalValue = CDec(r.GetValue("importeplan") / CDec(r.GetValue("cantidad")))
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    GetLSVProductosEntregados(New recursoCosto With {.idCosto = Val(r.GetValue("idcosto"))})
            End Select
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Cursor = Cursors.WaitCursor
        Dim r As Record = dgvEntregables.Table.CurrentRecord
        If Not IsNothing(r) Then
            GetLSVProductosEntregados(New recursoCosto With {.idCosto = Val(r.GetValue("idcosto"))})
        Else
            MessageBox.Show("Debe seleccionar una orden de producción", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Me.Cursor = Cursors.WaitCursor
        ButtonAdv9.Visible = False
        ButtonAdv8.Visible = True
        GetEntregablesProceso()
        GetComboCellStatusPresupuesto()
        Panel1.BackColor = Color.FromArgb(236, 133, 62)
        Label2.Text = "Productos en Proceso"
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvEntregables_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvEntregables.TableControlCellClick

    End Sub

    Private Sub dgvEntregables_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvEntregables.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()

        Dim r As Record = dgvEntregables.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim costo As New recursoCosto
            Dim costoSA As New recursoCostoSA

            costo = New recursoCosto
            costo.idCosto = r.GetValue("idcosto")
            costo.presupuesto = Val(r.GetValue("CerrarPresupuesto"))
            costoSA.GetCerrarPresupuesto(costo)

        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim listas As New List(Of documentocompradetalle)
        Dim articulo As New detalleitems
        Dim articuloSA As New detalleitemsSA
        Dim pmUnitario As Decimal = 0
        Dim r As Record = dgvEntregables.Table.CurrentRecord
        Dim costo As New recursoCosto
        Dim costoSA As New recursoCostoSA
        If Not IsNothing(r) Then
            pmUnitario = CDec(r.GetValue("puplan"))

            If ListView1.SelectedItems.Count > 0 Then
                Dim i As ListViewItem = ListView1.SelectedItems(0)

                articulo = articuloSA.InvocarProductoID(Val(i.SubItems(6).Text))
                costo = costoSA.GetCostoById(New recursoCosto With {.idCosto = Val(i.SubItems(5).Text)})

                If costo.status = StatusProductosTerminados.Pendiente Then
                    Dim obj As New documentocompradetalle With
                        {
                .idItem = articulo.codigodetalle,
                .tipoExistencia = articulo.tipoExistencia,
                .destino = articulo.origenProducto,
                .descripcionItem = articulo.descripcionItem,
                .unidad1 = articulo.unidad1,
                .unidad2 = articulo.presentacion,
                .monto1 = CDec(i.SubItems(3).Text),
                .precioUnitario = pmUnitario,
                .importe = pmUnitario * CDec(i.SubItems(3).Text),
                .importeUS = 0,
                .idCosto = Val(i.SubItems(5).Text)
                    }
                    listas.Add(obj)
                End If

                If listas.Count > 0 Then
                    Dim f As New frmEntregaProductosTerminados(listas)
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    GetLSVProductosEntregados(New recursoCosto With {.idCosto = Val(r.GetValue("idcosto"))})
                Else
                    MessageBox.Show("No contiene productos en planta para enviar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If





            'For Each i As ListViewItem In ListView1.Items
            '    articulo = articuloSA.InvocarProductoID(Val(i.SubItems(6).Text))
            '    costo = costoSA.GetCostoById(New recursoCosto With {.idCosto = Val(i.SubItems(5).Text)})

            '    If costo.status = StatusProductosTerminados.Pendiente Then
            '        Dim obj As New documentocompradetalle With
            '            {
            '    .idItem = articulo.codigodetalle,
            '    .tipoExistencia = articulo.tipoExistencia,
            '    .destino = articulo.origenProducto,
            '    .descripcionItem = articulo.descripcionItem,
            '    .unidad1 = articulo.unidad1,
            '    .unidad2 = articulo.presentacion,
            '    .monto1 = CDec(i.SubItems(3).Text),
            '    .precioUnitario = pmUnitario,
            '    .importe = pmUnitario * CDec(i.SubItems(3).Text),
            '    .importeUS = 0,
            '    .idCosto = Val(i.SubItems(5).Text)
            '        }
            '        listas.Add(obj)
            '    End If


            'Next



        Else
            MessageBox.Show("Debe seleccionar una orden de producto terminado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        Cursor = Cursors.WaitCursor
        Dim NumParciales As Integer = 0
        Dim numProductosEnPlanta As Integer = 0
        Dim costosa As New recursoCostoSA
        Dim r As Record = dgvEntregables.Table.CurrentRecord
        If Not IsNothing(r) Then

            'evaluando si la orden tiene distribuciones parciales en general
            NumParciales = costosa.GetNumRecursosConEntregaParcial(New recursoCosto With {.idpadre = Val(r.GetValue("idcosto"))})

            If NumParciales > 0 Then

                numProductosEnPlanta = costosa.GetNumRecursosEnPlanta(New recursoCosto With {.idpadre = Val(r.GetValue("idcosto"))})
                If numProductosEnPlanta > 0 Then
                    ' si existen articulos en planta no puede finalizar la orden de producción
                    MessageBox.Show("Existen productos terminados en 'PLANTA', no puede realizar la operación", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Cursor = Cursors.Default
                    Exit Sub
                Else
                    'aqui codigo definitivo de cierres parciales

                    Dim f As New frmCierreProduccionParcialCompleta(New recursoCosto With {.idCosto = Val(r.GetValue("idcosto"))})
                    f.txtEntregable.Tag = r.GetValue("idcosto")
                    f.txtEntregable.Text = r.GetValue("entregable")
                    f.txtUM.Text = r.GetValue("unidad")
                    f.txtCant.Text = r.GetValue("cantidad")
                    f.txtCosto.Text = r.GetValue("importeplan")
                    f.txtPlaneado.Text = CDec(r.GetValue("importeplan")).ToString("N2")
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                End If
            Else
                Dim f As New frmCierreTotalProduccion(dgvEntregables.Table.CurrentRecord)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If


        Else
            MessageBox.Show("Debe seleccionar una orden de producción válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub GradientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel1.Paint

    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click

        Me.Cursor = Cursors.WaitCursor
        ButtonAdv9.Visible = True
        ButtonAdv8.Visible = False

        GetEntregablesCulminados(StatusProductosTerminados.Entregado)
        GetComboCellStatusPresupuesto()
        Panel1.BackColor = Color.FromArgb(31, 189, 135)
        Label2.Text = "Productos culminados con entrega normal"
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv9_Click(sender As Object, e As EventArgs) Handles ButtonAdv9.Click
        Dim NumParciales As Integer = 0
        Dim numProductosEnPlanta As Integer = 0
        Dim compraSA As New DocumentoCompraSA
        Dim r As Record = dgvEntregables.Table.CurrentRecord
        Dim be As New recursoCosto
        Dim costosa As New recursoCostoSA
        If Not IsNothing(r) Then

            NumParciales = costosa.GetNumRecursosConEntregaParcial(New recursoCosto With {.idpadre = Val(r.GetValue("idcosto"))})

            If NumParciales > 0 Then
                'GetEliminarCierreParcialTotal
                Dim codCosto As Integer = r.GetValue("idcosto")
                be.idCosto = codCosto
                compraSA.GetEliminarCierreParcialTotal(be)
                MessageBox.Show("Orden abierta correctamente", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim codCosto As Integer = r.GetValue("idcosto")
                be.idCosto = codCosto
                compraSA.GetEliminarCierreTotal(be)
                MessageBox.Show("Orden abierta correctamente", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If


    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Cursor = Cursors.WaitCursor
        Dim costoSA As New recursoCostoSA
        Try
            Dim r As Record = dgvEntregables.Table.CurrentRecord
            If Not IsNothing(r) Then
                If ListView1.SelectedItems.Count > 0 Then
                    If MessageBox.Show("Desea eliminar el registro seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        costoSA.GetEliminarProductosEnPlanta(New recursoCosto With {.idCosto = CInt(ListView1.SelectedItems(0).SubItems(0).Text)})
                        ListView1.SelectedItems(0).Remove()
                        MessageBox.Show("Registro eliminado", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Debe seleccionar un registro válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Cursor = Cursors.WaitCursor
        Dim costoSA As New recursoCostoSA
        Try

            Dim r As Record = dgvEntregables.Table.CurrentRecord
            If Not IsNothing(r) Then
                If ListView1.SelectedItems.Count > 0 Then
                    If MessageBox.Show("Desea quitar el envío a almacén?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        costoSA.GetEliminarEnvioAalmacen(New recursoCosto With {.idCosto = CInt(ListView1.SelectedItems(0).SubItems(0).Text)})
                        GetLSVProductosEntregados(New recursoCosto With {.idCosto = Val(r.GetValue("idcosto"))})
                    End If
                Else
                    MessageBox.Show("Debe seleccionar una entrega válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Cursor = Cursors.Default
    End Sub
End Class