Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmServiciosPrecios
#Region "Attributes"
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim servicioSA As New servicioSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvServicio, True)
        FormatoGridPequeño(dgvPreciosServicio, True)
        GetServiciosWithprecios()
    End Sub
#End Region

#Region "Methods"
    Private Sub GetServiciosWithprecios()
        Dim dt As New DataTable("ParentTable")
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("observaciones", GetType(String)))

        For Each i In servicioSA.ListadoServiciosHijosXIdTipo(New servicio With {.codigo = Nothing, .idPadre = 1015})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idServicio
            dr(1) = i.descripcion
            dr(2) = i.cuenta
            dr(3) = i.observaciones
            dt.Rows.Add(dr)
        Next
        Me.dgvServicio.DataSource = dt
        Me.dgvServicio.Engine.BindToCurrencyManager = False

        Me.dgvServicio.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvServicio.TopLevelGroupOptions.ShowCaption = False
    End Sub

    Public Sub UbicarUltimosPreciosServicio(intIdItem As Integer)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(0, intIdItem)
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
        dgvPreciosServicio.DataSource = dt
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
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If Not IsNothing(dgvServicio.Table.CurrentRecord) Then
            Dim f As New frmNuevoPrecio
            f.txtProducto.Tag = dgvServicio.Table.CurrentRecord.GetValue("idItem")
            f.txtProducto.Text = dgvServicio.Table.CurrentRecord.GetValue("descripcion")
            f.txtGrav.Text = "2"
            f.ChReferencia.Enabled = False
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Else
            MessageBox.Show("Debe seleccionar un servicio", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub dgvServicio_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvServicio.TableControlCellClick

    End Sub

    Private Sub dgvServicio_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvServicio.SelectedRecordsChanging
        Me.Cursor = Cursors.WaitCursor
        dgvPreciosServicio.Table.Records.DeleteAll()
        If Not IsNothing(e.SelectedRecord) Then
            UbicarUltimosPreciosServicio(e.SelectedRecord.Record.GetValue("idItem"))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvServicio_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvServicio.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvServicio.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvServicio_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvServicio.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvServicio)
    End Sub

    Private Sub dgvPreciosServicio_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvPreciosServicio.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvPreciosServicio.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvPreciosServicio_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvPreciosServicio.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvPreciosServicio)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Dim f As New frmNewServicio("SERVICIOS")
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GetServiciosWithprecios()
    End Sub
#End Region

End Class