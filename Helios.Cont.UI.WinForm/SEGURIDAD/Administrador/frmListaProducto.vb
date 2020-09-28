Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmListaProducto

#Region "Attributes"
    Public Property productoSA As New ProductoSA
    Public Property productoBE As Producto
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgProducto, True)
        GetProductosSistema()
    End Sub
#End Region

#Region "Methods"
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

    Public Sub GetProductosSistema()

        Dim dt As New DataTable("Movimientos - período " & PeriodoGeneral & " ")
        dt.Columns.Add(New DataColumn("idProducto", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))

        For Each i In productoSA.ListadoProductoFull()
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.IDProducto
            dr(1) = i.nombre
            dr(2) = i.descripcion
            dr(3) = i.FechaActualizacion
            dt.Rows.Add(dr)
        Next

        dgProducto.DataSource = dt
        dgProducto.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Cursor = Cursors.WaitCursor
        GetProductosSistema()
        Cursor = Cursors.Default
    End Sub

    Private Sub dgUsuarios_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgProducto.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgProducto.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgUsuarios_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgProducto.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgProducto)
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmNuevoProducto
        f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GetProductosSistema()
        Cursor = Cursors.Default
    End Sub

#End Region

End Class