Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmPreciosObservados

#Region "Attributes"
    Dim TotalesAlmacenSA As New TotalesAlmacenSA
    Dim precioSA As New ConfiguracionPrecioProductoSA
    Dim prodSA As New detalleitemsSA
    Dim hoveredIndex As Integer = 0
    Dim selectionColl As New Hashtable()
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvAlertas, True)
        FormatoGridPequeño(dgvHistorialAlertas, True)
        ListarPrecioAlertas()
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

    Public Sub UbicarUltimosPreciosXproducto_Alertas(r As Record)
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(r.GetValue("idalmacen"), r.GetValue("idAlerta"))
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.fecha
            dr(1) = i.idPrecio
            dr(2) = i.descripcion
            dr(3) = IIf(i.tipo = "1", "CON IVA", "SIN IVA")
            dr(4) = i.valPorcentaje
            dr(5) = i.precioMN
            dr(6) = i.precioME
            dt.Rows.Add(dr)
        Next
        dgvHistorialAlertas.DataSource = dt
    End Sub

    Sub ListarPrecioAlertas()
        Dim TotalesAlmacen As New List(Of totalesAlmacen)
        Dim dt As New DataTable()
        dt.Columns.Add("idalmacen")
        dt.Columns.Add("almacen")
        dt.Columns.Add("idAlerta")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("fechaInicio")
        dt.Columns.Add("fechaFin")
        TotalesAlmacen = TotalesAlmacenSA.ObtenerAlertaDePrecio(New totalesAlmacen With {.idAlmacen = 0})
        For Each i In TotalesAlmacen
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idAlmacen
            dr(1) = i.NomAlmacen
            dr(2) = i.idItem
            dr(3) = i.descripcion
            dr(4) = i.FechaUltimoPrecioKardex  'fecha inventario
            dr(5) = i.FechaUltimoPrecioConfigurado  ' fecha config precio
            dt.Rows.Add(dr)
        Next
        dgvAlertas.DataSource = dt
        dgvAlertas.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

#End Region

#Region "Events"
    Private Sub dgvAlertas_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvAlertas.SelectedRecordsChanging
        Cursor = Cursors.WaitCursor
        dgvHistorialAlertas.Table.Records.DeleteAll()
        If Not IsNothing(e.SelectedRecord) Then
            UbicarUltimosPreciosXproducto_Alertas(e.SelectedRecord.Record)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        ListarPrecioAlertas()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If Not IsNothing(dgvAlertas.Table.CurrentRecord) Then
            Dim f As New frmNuevoPrecio
            f.txtProducto.Tag = dgvAlertas.Table.CurrentRecord.GetValue("idAlerta")
            f.txtProducto.Text = dgvAlertas.Table.CurrentRecord.GetValue("descripcion")
            f.txtGrav.Text = prodSA.InvocarProductoID(CInt(dgvAlertas.Table.CurrentRecord.GetValue("idAlerta"))).origenProducto
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub dgvAlertas_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvAlertas.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvAlertas.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvAlertas_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvAlertas.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvAlertas)
    End Sub

    Private Sub dgvHistorialAlertas_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvHistorialAlertas.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvHistorialAlertas.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvHistorialAlertas_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvHistorialAlertas.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvHistorialAlertas)
    End Sub
#End Region

End Class