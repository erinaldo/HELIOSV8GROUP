Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmMovimientosSinNumGuia
#Region "Attributes"
    Dim hoveredIndex As Integer = 0
    Dim selectionColl As New Hashtable()
    Dim DocumentoGuiaSA As New DocumentoGuiaSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvPendiente, True)
        GuiaRemisionPendientes(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc)
    End Sub
#End Region

#Region "Methods"
    Private Sub GuiaRemisionPendientes(intIdEstablecimiento As Integer, idEmpresa As String)
        Dim documentoGuia As New List(Of documentoGuia)
        Dim dt As New DataTable("Guia remisión - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer))) '0
        dt.Columns.Add(New DataColumn("idEmpresa", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreEmpresa", GetType(String)))
        dt.Columns.Add(New DataColumn("idCentroCosto", GetType(Integer))) ' 3
        dt.Columns.Add(New DataColumn("nombreEstablecimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String))) '6
        dt.Columns.Add(New DataColumn("importeMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estadoGuia")) '9
        dt.Columns.Add(New DataColumn("idPadre", GetType(Integer))) '9

        documentoGuia = DocumentoGuiaSA.ListaGuiasPorCompraSinNumeracion(intIdEstablecimiento, Nothing, idEmpresa)

        Dim str As String
        For Each i As documentoGuia In documentoGuia
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.idEmpresa
            dr(2) = Gempresas.NomEmpresa
            dr(3) = i.idCentroCosto
            dr(4) = GEstableciento.NombreEstablecimiento
            dr(5) = i.fechaDoc
            dr(6) = i.tipoDoc
            dr(7) = i.importeMN
            dr(8) = i.importeME
            dr(9) = i.estadoGuia
            dr(10) = i.idEntidadTransporte

            dt.Rows.Add(dr)
        Next
        dgvPendiente.DataSource = dt
        dgvPendiente.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
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
    Private Sub dgvPendiente_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvPendiente.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvPendiente)
    End Sub

    Private Sub dgvPendiente_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvPendiente.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvPendiente.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Cursor = Cursors.WaitCursor
        GuiaRemisionPendientes(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc)
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            If dgvPendiente.Table.SelectedRecords.Count > 0 Then
                If dgvPendiente.Table.Records.Count > 0 Then
                    Dim f As New frmAsignarNumeroGuia
                    f.idPadre = dgvPendiente.Table.CurrentRecord.GetValue("idPadre")
                    f.idDocumento = dgvPendiente.Table.CurrentRecord.GetValue("idDocumento")
                    f.txtFecha.Value = dgvPendiente.Table.CurrentRecord.GetValue("fechaDoc")
                    f.txtEstablecimiento.Text = dgvPendiente.Table.CurrentRecord.GetValue("nombreEstablecimiento")
                    f.txtEmpresa.Text = dgvPendiente.Table.CurrentRecord.GetValue("nombreEmpresa")
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                    '    GetTransitoNumeracion()
                    dgvPendiente.Table.Records.DeleteAll()
                    'getTableGuiaRemision(GEstableciento.IdEstablecimiento, PeriodoGeneral, Gempresas.IdEmpresaRuc)
                Else
                    MessageBox.Show("Debe ingresar items a la canasta de distribución!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
#End Region

End Class