Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmGestionAlmacenes

#Region "Attributes"
    Dim almacenSA As New almacenSA
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid(dgAlmacen)
        GetAlmacenes()
    End Sub
#End Region

#Region "Methods"
    Sub GetAlmacenes()

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

    Private Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean, GGC As GridGroupingControl)
        Dim color As New GridMetroColors()
        Dim id As GridTableCellStyleInfoIdentity = GGC.TableControl.GetTableViewStyleInfo(row, col).TableCellIdentity
        If id.DisplayElement.IsRecord() Then
            Dim key As Integer = id.DisplayElement.GetRecord().Id
            hoveredIndex = row
            selectionColl.Clear()
            GGC.TableControl.Refresh()
        End If
        GGC.TableControl.Selections.Clear()
    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        'Dim f As New frmNuevoAlmacen
        'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
        'GetAlmacenes()
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        'Cursor = Cursors.WaitCursor
        'Dim r As Record = dgAlmacen.Table.CurrentRecord
        'If Not IsNothing(r) Then
        '    Dim f As New frmNuevoAlmacen
        '    f.UbicarDocumento(Val(r.GetValue("idalmacen")))
        '    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.ShowDialog()
        '    GetAlmacenes()
        'End If
        'Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        GetAlmacenes()
        Cursor = Cursors.Default
    End Sub

    Private Sub dgAlmacen_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgAlmacen.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgAlmacen)
    End Sub

    Private Sub dgAlmacen_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgAlmacen.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgAlmacen.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click

    End Sub

#End Region
End Class