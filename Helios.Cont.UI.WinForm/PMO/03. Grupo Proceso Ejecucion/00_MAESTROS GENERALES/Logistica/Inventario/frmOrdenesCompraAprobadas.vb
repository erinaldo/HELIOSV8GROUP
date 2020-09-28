Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmOrdenesCompraAprobadas

#Region "Attributes"
    Dim hoveredIndex As Integer = 0
    Dim selectionColl As New Hashtable()
    Dim DocumentoCompraSA As New DocumentoCompraSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvOrdenCompra, True)
        getTableOrdenDeComprasPorPeriodo(GEstableciento.IdEstablecimiento, TIPO_COMPRA.ORDEN_APROBADO)
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

    Private Sub getTableOrdenDeComprasPorPeriodo(intIdEstablecimiento As Integer, tipoCompra As String)
        Dim DocumentoCompra As New List(Of documentocompra)
        Dim dt As New DataTable("Ordenes de compra aprobadas")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("nombrePersona", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        DocumentoCompra = DocumentoCompraSA.GetListarOrdenComprasPorPeriodoGeneral(intIdEstablecimiento, Nothing, tipoCompra)
        Dim str As String
        For Each i As documentocompra In DocumentoCompra
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc

            dr(6) = i.NombreEntidad
            If i.tipoCompra = "BOFR" Then
                dr(7) = CDec(0.0)
                dr(8) = CDec(0.0)
                dr(9) = CDec(0.0)
            Else
                dr(7) = i.importeTotal
                dr(8) = i.tcDolLoc
                dr(9) = i.importeUS
            End If

            'dr(11) = i.tcDolLoc
            'dr(12) = i.importeUS
            dr(10) = i.monedaDoc
            'dr(12) = i.usuarioActualizacion
            dr(11) = i.situacion
            Select Case i.estadoPago
                Case TIPO_COMPRA.PAGO.PAGADO
                    dr(12) = "Saldado"
                Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    dr(12) = "Pendiente"
            End Select

            'Select Case i.aprobado
            '    Case "S"
            '        dr(15) = "Aprobado"
            '    Case Else
            '        dr(15) = "Pendiente"
            'End Select
            'dr(16) = i.Atraso
            dt.Rows.Add(dr)
        Next
        dgvOrdenCompra.DataSource = dt
        dgvOrdenCompra.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
    End Sub
#End Region

#Region "Events"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not IsNothing(Me.dgvOrdenCompra.Table.CurrentRecord) Then
            With frmDetalleOrdenDeCompra
                .UbicarDocumentoOrdenCompra(Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("idDocumento"))
                .idDocumento = (Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("idDocumento"))
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Normal
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe seleccionar un item!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub dgvOrdenCompra_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvOrdenCompra.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If
            dgvOrdenCompra.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvOrdenCompra_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvOrdenCompra.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvOrdenCompra)
    End Sub
#End Region

End Class