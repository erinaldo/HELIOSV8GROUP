Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmArticulosConStockMinimo

#Region "Attributes"
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvStockMinimo, True)
        GetInventarioEnAlerta(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
    End Sub
#End Region

#Region "Methods"
    Public Sub GetInventarioEnAlerta(be As totalesAlmacen)
        Dim totalSA As New TotalesAlmacenSA
        Dim dt As New DataTable()

        dt.Columns.Add("idAlmacen")
        dt.Columns.Add("almacen")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("importeMN")
        dt.Columns.Add("importeME")
        dt.Columns.Add("cantidadMinima")
        dt.Columns.Add("iditem")
        dt.Columns.Add("item")
        dt.Columns.Add("unidad")

        For Each i In totalSA.GetAlertaIventarioMinimo(be)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idAlmacen
            dr(1) = i.NomAlmacen
            dr(2) = i.cantidad
            dr(3) = i.importeSoles
            dr(4) = i.importeDolares
            dr(5) = i.cantidadMinima
            dr(6) = i.idItem
            dr(7) = i.descripcion
            dr(8) = i.idUnidad
            dt.Rows.Add(dr)
        Next
        dgvStockMinimo.DataSource = dt

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
    Private Sub dgvStockMinimo_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvStockMinimo.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvStockMinimo.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvStockMinimo_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvStockMinimo.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvStockMinimo)
    End Sub
#End Region

End Class