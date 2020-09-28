Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmArticulosSinPrecio

#Region "Attributes"
    Dim totalesAlmacenSA As New TotalesAlmacenSA
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvPrecios, True)
        LoadProductosXalmacenSinAsignar()
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

    Sub LoadProductosXalmacenSinAsignar()
        Dim totalesAlmacen As New List(Of totalesAlmacen)
        Dim dt As New DataTable()

        dt.Columns.Add("idItem")
        dt.Columns.Add("item")
        dt.Columns.Add("destino")
        dt.Columns.Add("tipoEx")
        dt.Columns.Add("unidad")
        dt.Columns.Add("stock")
        dt.Columns.Add("btnUltimasEntradas")
        dt.Columns.Add("almacen") 'idalmacen
        dt.Columns.Add("idalmacen")
        totalesAlmacen = totalesAlmacenSA.NumProductosSinListaPrecio(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                            .idEstablecimiento = GEstableciento.IdEstablecimiento})

        For Each i In totalesAlmacen
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idItem
            dr(1) = i.descripcion
            dr(2) = i.origenRecaudo
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = "ultimas"
            dr(7) = i.NomAlmacen
            dr(8) = i.idAlmacen
            dt.Rows.Add(dr)
        Next
        dgvPrecios.DataSource = dt
        dgvPrecios.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

#End Region

#Region "Events"
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If Not IsNothing(dgvPrecios.Table.CurrentRecord) Then
            Dim f As New frmNuevoPrecio
            f.txtProducto.Tag = dgvPrecios.Table.CurrentRecord.GetValue("idItem")
            f.txtProducto.Text = dgvPrecios.Table.CurrentRecord.GetValue("item")
            f.txtGrav.Text = dgvPrecios.Table.CurrentRecord.GetValue("destino")
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            LoadProductosXalmacenSinAsignar()
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        LoadProductosXalmacenSinAsignar()
    End Sub

    Private Sub dgvPrecios_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvPrecios.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvPrecios.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvPrecios_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvPrecios.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvPrecios)
    End Sub
#End Region

End Class