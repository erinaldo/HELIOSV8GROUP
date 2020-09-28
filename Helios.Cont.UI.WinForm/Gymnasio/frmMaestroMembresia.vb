Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmMaestroMembresia
#Region "Attributes"
    Protected Friend Membresia As membresia_Gym
    Protected Friend MembresiaSA As New membresia_GymSA
    Protected Friend frmNuevaMembresia As frmNuevaMembresia
    Protected dt As New DataTable
    Protected Friend rec As Record
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        txtAnioCompra.Text = AnioGeneral
        FormatoGridAvanzado(dgvCompras, True, True)
        GetMembresiasByPeriodo()
    End Sub


#End Region

#Region "Methods"
    ''' <summary>
    ''' Nombre de las columnas del Data grid
    ''' </summary>
    Structure ColumnNameDGV
        Const idMembresia = "idMembresia"
        Const fechaRegistro = "fechaRegistro"
        Const tipoServicio = "tipoServicio"
        Const descripcion = "descripcion"
        Const tipo = "tipo"
        Const fechafin = "fechafin"
        Const status = "status"
        Const costo = "costo"
    End Structure

    Public Sub GetMembresiasByPeriodo()
        dt = New DataTable
        dt.Columns.Add(ColumnNameDGV.idMembresia).Caption = "ID"
        dt.Columns.Add(ColumnNameDGV.fechaRegistro).Caption = "Registro"
        dt.Columns.Add(ColumnNameDGV.tipoServicio).Caption = "Servicio"
        dt.Columns.Add(ColumnNameDGV.descripcion).Caption = "Producto/Servicio"
        dt.Columns.Add(ColumnNameDGV.tipo).Caption = "Periodicidad"
        dt.Columns.Add(ColumnNameDGV.costo).Caption = "Costo"
        dt.Columns.Add(ColumnNameDGV.fechafin).Caption = "Válido"
        dt.Columns.Add(ColumnNameDGV.status).Caption = "Estado"

        For Each i In membresia_GymSA.GetMembresiasByStatus(New membresia_Gym With {.idEmpresa = Gempresas.IdEmpresaRuc, .status = Gimnasio_EstadoMembresia.Activo})
            dt.Rows.Add(i.idMembresia,
                        i.fechaRegistro,
                        i.tipoServicio,
                        i.descripcion,
                        i.tipo,
                        i.costo.GetValueOrDefault,
                        i.fechafin,
                        i.status)
        Next
        dgvCompras.DataSource = dt

        dgvCompras.TableDescriptor.VisibleColumns.Remove(ColumnNameDGV.idMembresia)
        dgvCompras.TableDescriptor.VisibleColumns.Remove(ColumnNameDGV.fechafin)
    End Sub

#End Region

#Region "Events"
    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        Cursor = Cursors.WaitCursor
        frmNuevaMembresia = New frmNuevaMembresia
        frmNuevaMembresia.EntityAction = ENTITY_ACTIONS.INSERT
        frmNuevaMembresia.StartPosition = FormStartPosition.CenterParent
        frmNuevaMembresia.ShowDialog()
        GetMembresiasByPeriodo()
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Cursor = Cursors.WaitCursor
        rec = dgvCompras.Table.CurrentRecord
        If Not IsNothing(rec) Then
            frmNuevaMembresia = New frmNuevaMembresia(Integer.Parse(dgvCompras.Table.CurrentRecord.GetValue(ColumnNameDGV.idMembresia)))
            frmNuevaMembresia.EntityAction = ENTITY_ACTIONS.UPDATE
            frmNuevaMembresia.StartPosition = FormStartPosition.CenterParent
            frmNuevaMembresia.ShowDialog()
            GetMembresiasByPeriodo()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        rec = dgvCompras.Table.CurrentRecord
        If rec IsNot Nothing Then
            membresia_congelamientoSA.GetCambiarEstado(New membresia_Gym With {.idMembresia = rec.GetValue(ColumnNameDGV.idMembresia), .status = Gimnasio_EstadoMembresia.Baja})
            GetMembresiasByPeriodo()
        Else
            MessageBox.Show("Debe seleccionar un registro válido", "Seleccionar fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub dgvCompras_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvCompras.TableControlCellClick

    End Sub

    Private Sub dgvCompras_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCompras.QueryCellStyleInfo
        If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
            'Checks for the column name when the cellvalue is greater than 5.
            'ENTRADAS A ALMACEN
            If e.TableCellIdentity.Column.MappingName = ColumnNameDGV.tipoServicio AndAlso (e.Style.CellValue) = "1" Then
                e.Style.Text = "Normal"
            End If

            If e.TableCellIdentity.Column.MappingName = ColumnNameDGV.tipoServicio AndAlso (e.Style.CellValue) = "2" Then
                e.Style.Text = "Promoción"
            End If

            If e.TableCellIdentity.Column.MappingName = ColumnNameDGV.tipoServicio AndAlso (e.Style.CellValue) = "3" Then
                e.Style.Text = "Premio-regalo"
            End If

            If e.TableCellIdentity.Column.MappingName = ColumnNameDGV.tipoServicio AndAlso (e.Style.CellValue) = "4" Then
                e.Style.Text = "Otros"
            End If

        End If
    End Sub
#End Region


End Class