Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Helios.General
Public Class frmAdminPrecios

#Region "Attributes"
    Dim hoveredIndex As Integer = 0
    Dim selectionColl As New Hashtable()
    Dim precioSA As New ConfiguracionPrecioSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvDetracciones, True)
        MasterPrecios()
    End Sub
#End Region

#Region "Methods"
    Private Sub MasterPrecios()
        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("tasa")
        dt.Columns.Add("confirmar")

        For Each i In precioSA.ListadoPrecios()
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idPrecio
            dr(1) = i.precio
            dr(2) = i.tasaPorcentaje
            dr(3) = i.activo
            dt.Rows.Add(dr)
        Next
        dgvDetracciones.DataSource = dt
    End Sub
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

#End Region

#Region "Events"
    Private Sub dgvDetracciones_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvDetracciones.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvDetracciones.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvDetracciones_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvDetracciones.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvDetracciones)
    End Sub
#End Region

End Class