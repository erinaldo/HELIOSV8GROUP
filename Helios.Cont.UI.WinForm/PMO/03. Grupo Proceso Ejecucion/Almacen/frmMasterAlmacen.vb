Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmMasterAlmacen
    Inherits frmMaster

    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.Click
        'Me.Cursor = Cursors.WaitCursor
        'With frmNuevoAlmacen
        '    '.lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    .limpiar()
        '    .txtEstablecimiento.Text = GEstableciento.NombreEstablecimiento
        '    .txtEmpresa.Text = Gempresas.NomEmpresa
        '    .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
        '    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        '    .lblPerido.Text = PeriodoGeneral
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnEditCompra_Click(sender As Object, e As EventArgs) Handles btnEditCompra.Click
        'Me.Cursor = Cursors.WaitCursor
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
        '    With frmNuevoAlmacen
        '        .lblIdDocumento.Text = (Me.dgvCompra.Table.CurrentRecord.GetValue("idAlmacen"))
        '        .txtEmpresa.Text = Gempresas.IdEmpresaRuc
        '        .txtEstablecimiento.Text = GEstableciento.IdEstablecimiento
        '        .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
        '        .UbicarDocumento(Me.dgvCompra.Table.CurrentRecord.GetValue("idAlmacen"))
        '        .StartPosition = FormStartPosition.CenterParent
        '        .ShowDialog()
        '    End With
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub btnEliminarCompra_Click(sender As Object, e As EventArgs) Handles btnEliminarCompra.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminarTransferenciaAlmacen(Me.dgvCompra.Table.CurrentRecord.GetValue("idAlmacen"))
                Me.dgvCompra.Table.CurrentRecord.Delete()
                PanelError.Visible = True
                lblEstado.Text = "entrada eliminada!"
            End If
        End If
    End Sub

    Public Sub EliminarTransferenciaAlmacen(IntIdAlmacen As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen

        With almacen
            .idAlmacen = IntIdAlmacen
        End With
        almacenSA.DeleteNuevoAlmacen(almacen)
    End Sub

    Private Function getParentTableAlmacen(intIdEstablecimiento As Integer) As DataTable
        Dim almacenSA As New almacenSA

        Dim dt As New DataTable("Almacén - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idAlmacen", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcionAlmacen", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("encargado", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaModificacion", GetType(String)))

        Dim str As String
        For Each i As almacen In almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = intIdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaModificacion).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idAlmacen
            dr(1) = i.descripcionAlmacen
            dr(2) = i.encargado
            dr(3) = i.tipo
            dr(4) = i.estado
            dr(5) = str
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Sub ListaEntradas(intIdEstablecimiento As Integer)
        Try

            Dim parentTable As DataTable = getParentTableAlmacen(GEstableciento.IdEstablecimiento)
            Me.dgvCompra.DataSource = parentTable
            dgvCompra.TableDescriptor.Relations.Clear()
            dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            dgvCompra.GroupDropPanel.Visible = True
            dgvCompra.TableDescriptor.GroupedColumns.Clear()
            PanelError.Visible = True
            lblEstado.Text = "Lista de movimientos período: - " & PeriodoGeneral
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        ListaEntradas(GEstableciento.IdEstablecimiento)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick

    End Sub

    Private Sub chFilter1_Click(sender As Object, e As EventArgs) Handles chFilter1.Click
        If chFilter1.Checked = True Then
            Me.dgvCompra.TopLevelGroupOptions.ShowFilterBar = True
            'Enable the filter for each columns 
            For i As Integer = 0 To dgvCompra.TableDescriptor.Columns.Count - 1
                dgvCompra.TableDescriptor.Columns(i).AllowFilter = True
            Next
        Else
            Me.dgvCompra.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

    Private Sub chFilter2_Click(sender As Object, e As EventArgs) Handles chFilter2.Click
        'If chFilter2.Checked Then
        '    Filter.WireGrid(dgvCompra)
        'Else
        '    Filter.UnWireGrid(dgvCompra)
        'End If
    End Sub

    Private Sub chAgrupa_Click(sender As Object, e As EventArgs) Handles chAgrupa.Click
        If chAgrupa.Checked Then
            dgvCompra.TableDescriptor.GroupedColumns.Clear()
            dgvCompra.ShowGroupDropArea = True
        Else
            dgvCompra.TableDescriptor.GroupedColumns.Clear()
            dgvCompra.ShowGroupDropArea = False
        End If
    End Sub
End Class