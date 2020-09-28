Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabMG_HistorialInfraestructura

#Region "Attributes"
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim filter As New GridExcelFilter()
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvCompras, True, False)

    End Sub
#End Region

#Region "Methods"

    Private Sub GetTableDetalle()
        Dim ocupacionInfraSA As New ocupacionInfraestructuraSA
        Dim ocupacionInfraBE As New ocupacionInfraestructura
        Dim dt As New DataTable
        ' Dim tables() As String = {"1", "2", "6", "10", "14", ""}

        ocupacionInfraBE.idEmpresa = Gempresas.IdEmpresaRuc
        ocupacionInfraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        ocupacionInfraBE.estado = "A"

        With dt.Columns
            .Add("idOcupacion")
            .Add("idDistribucion")
            .Add("nombreDistribucion")
            .Add("idEntidad")
            .Add("numeroCliente")
            .Add("nombreCliente")
            .Add("checkin")
            .Add("checkon")
        End With

        For Each i In ocupacionInfraSA.listaOcupacionInfraestructura(ocupacionInfraBE) '.Where(Function(o) tables.Contains(o.idtabla)).ToList
            dt.Rows.Add(i.idOcupacion, i.idDistribucion, i.usuarioActualizacion, i.idEntidad, i.nroEntidad, i.glosario, i.chek_in, i.check_on)
        Next

        dgvCompras.DataSource = dt
        dgvCompras.TableDescriptor.Columns("nombreDistribucion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvCompras.TableDescriptor.Columns("nombreDistribucion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
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
    Private Sub dgvCompras_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCompras.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvCompras.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvCompras_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvCompras.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvCompras)
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Cursor = Cursors.WaitCursor
        GetTableDetalle()
        Cursor = Cursors.Default
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        dgvCompras.TopLevelGroupOptions.ShowFilterBar = True
        dgvCompras.NestedTableGroupOptions.ShowFilterBar = True
        dgvCompras.ChildGroupOptions.ShowFilterBar = True
        For Each col As GridColumnDescriptor In dgvCompras.TableDescriptor.Columns
            col.AllowFilter = True
        Next
        filter.AllowResize = True
        filter.AllowFilterByColor = True
        filter.EnableDateFilter = True
        filter.EnableNumberFilter = True

        dgvCompras.OptimizeFilterPerformance = True
        dgvCompras.ShowNavigationBar = True
        filter.WireGrid(dgvCompras)
    End Sub

    Private Sub PictureLoad_Click(sender As Object, e As EventArgs) Handles PictureLoad.Click

    End Sub

#End Region

End Class
